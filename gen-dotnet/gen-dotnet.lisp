(in-package #:cl-user)

(defpackage #:gen-dotnet
  (:nicknames #:dotnet)
  (:use #:cl #:cl-user #:cl-ppcre #:util)
  (:export
   #:generate-class-for-table
   #:generate-view-for-table
   ))

(in-package #:gen-dotnet)

(defun get-default-type (column-spec)
  (let ((type (second column-spec))
		(default-type "string"))
	(cond ((cl-ppcre:scan "int" type)
		   (setf default-type "int"))
          ((cl-ppcre:scan "bigint" type)
		   (setf default-type "long"))
		  ((cl-ppcre:scan "decimal" type)
		   (setf default-type "decimal"))
		  ((cl-ppcre:scan "timestamp" type)
		   (setf default-type "DateTime"))
          ((cl-ppcre:scan "datetime" type)
		   (setf default-type "DateTime"))
          ((cl-ppcre:scan "date" type)
		   (setf default-type "DateTime"))
          ((cl-ppcre:scan "time" type)
		   (setf default-type "DateTime"))
		  ((cl-ppcre:scan "varchar" type)
		   (setf default-type "string"))
		  (t
           (setf default-type "/* XXX */ string")))
	default-type))

(defun get-default-property (column-spec)
  (let ((default-type (get-default-type column-spec)))
    (format nil "~8,0tpublic ~A ~A~%~8,0t{~%~12,0tget~%~12,0t{~%~16,0treturn _~A;~%~12,0t}~%~12,0tset~%~12,0t{~%~16,0t_~A = value;~%~12,0t}~%~8,0t}~%"
            default-type (first column-spec) (first column-spec) (first column-spec))))

(defun get-getter (column-spec)
  (let ((type (second column-spec))
		(getter "string"))
	(cond ((cl-ppcre:scan "int" type)
		   (setf getter "0 : myRdr.GetInt32"))
          ((cl-ppcre:scan "bigint" type)
		   (setf getter "(long)0 : myRdr.GetInt64"))
		  ((cl-ppcre:scan "decimal" type)
		   (setf getter "0 : myRdr.GetDecimal"))
		  ((cl-ppcre:scan "timestamp" type)
		   (setf getter "Utility.GetNullDate() : myRdr.GetDateTime"))
          ((cl-ppcre:scan "datetime" type)
		   (setf getter "Utility.GetNullDate() : myRdr.GetDateTime"))
          ((cl-ppcre:scan "date" type)
		   (setf getter "Utility.GetNullDate() : myRdr.GetDateTime"))
          ((cl-ppcre:scan "time" type)
		   (setf getter "Utility.GetNullDate() : myRdr.GetDateTime"))
		  ((cl-ppcre:scan "varchar" type)
		   (setf getter "\"\" : myRdr.GetString"))
		  (t
           (setf getter "\"\" : myRdr.GetString")))
	getter))
(defparameter *column-counter* -1)

(defun generate-class-for-table (tablename &optional classname no-sprocs-p)
  "Generate a .NET class file for TABLENAME.
The name of the class is auto-generated from the capitalized TABLENAME.
If CLASSNAME is provided, it is used instead."
  (let ((columns (filter-columns (describe-table tablename) class-ignore-columns))
		(filename (format nil "generated/SW~A.cs" tablename))
        (source-filename (if no-sprocs-p
                             "gen-dotnet/class-nosproc.cs"
                             "gen-dotnet/class-sproc.cs")))
	#+nil(progn (format t "Columns: ~S~%" columns)
           (dolist (column columns)
             (destructuring-bind (name type allow-null key default extra) column
               (format t "Column name: ~A type: ~A Allow null: ~A Key: ~A Default: ~A Extra: ~A~%"
                       name type allow-null key default extra))))
	(with-open-file (infile source-filename)
	  (with-open-file (outfile filename :direction :output :if-exists :supersede)
		(loop for line = (read-line infile nil nil)
		   while line do
			 (cond ((cl-ppcre:scan "tablename" line)
					(setf line (cl-ppcre:regex-replace "tablename" line tablename))
					(write-lines line outfile))
				   ((cl-ppcre:scan "Classname" line)
					(if classname
						(setf line (cl-ppcre:regex-replace-all "Classname" line classname))
						(setf line (cl-ppcre:regex-replace-all "Classname" line (format nil "~@(~A~)" tablename))))
					(write-lines line outfile))
				   ((cl-ppcre:scan "Sprocname" line)
					(setf line (cl-ppcre:regex-replace "Sprocname" line (format nil "~@(~A~)" tablename)))
					(write-lines line outfile))
				   ((cl-ppcre:scan "columnnames" line)
					(setf line (cl-ppcre:regex-replace "columnnames" line (format nil "~{`~a`~^, ~}"
																				  (mapcar #'car columns))))
					(write-lines line outfile))
				   ((cl-ppcre:scan "columnvalues" line)
					(setf line (cl-ppcre:regex-replace "columnvalues" line (format nil "~{'$this->~a'~^, ~}"
																				   (mapcar #'car columns))))
					(write-lines line outfile))
                   ((cl-ppcre:scan "/. members ./" line)
                    (transform-column-lines columns (lambda (c) (format nil "~8,0tprivate ~A _~A;" (get-default-type c) (first c))) outfile))
                   ((cl-ppcre:scan "/. properties ./" line)
                    (transform-column-lines columns (lambda (c) (format nil "~A" (get-default-property c))) outfile))
                   ((cl-ppcre:scan "/. constructor-params ./" line)
                    (transform-column-lines (cdr columns) (lambda (c) (format nil "~12,0t,~A p~A" (get-default-type c) (first c))) outfile))
                   ((cl-ppcre:scan "/. construction ./" line)
                    (transform-column-lines (cdr columns) (lambda (c) (format nil "~12,0t~A = p~A;" (first c) (first c))) outfile))
                   ((cl-ppcre:scan "/. getters ./" line)
                    (setf *column-counter* -1)
					(transform-column-lines columns (lambda (c)
                                                      (incf *column-counter*)
                                                      (format nil "~16,0t~A(myRdr.IsDBNull(~A) == true ? ~A(~A))" (if (> *column-counter* 0) "," " ") *column-counter* (get-getter c) *column-counter*))
                                            outfile))
				   (t
					(write-lines line outfile))))
		(write-line "" outfile)))
    (list source-filename filename)))
