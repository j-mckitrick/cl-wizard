(in-package #:cl-user)

(defpackage #:gen-php
  (:nicknames #:php)
  (:use #:cl #:cl-user #:cl-ppcre #:util)
  (:export
   #:generate-class-for-table
   #:generate-view-for-table
   ))

(in-package #:gen-php)

(defun get-default-value (column-spec)
  (let ((type (second column-spec))
		(default-value ""))
	(cond ((cl-ppcre:scan "int" type)
		   (setf default-value "0"))
		  ((cl-ppcre:scan "decimal" type)
		   (setf default-value "0.00"))
		  ((cl-ppcre:scan "timestamp" type)
		   (setf default-value "'1900-01-01 00:00:00'"))
          ((cl-ppcre:scan "datetime" type)
		   (setf default-value "'1900-01-01 00:00:00'"))
          ((cl-ppcre:scan "date" type)
		   (setf default-value "'1900-01-01'"))
		  ((cl-ppcre:scan "varchar" type)
		   (setf default-value "''"))
		  (t
           (setf default-value "'' /* XXX */")))
	default-value))

;;; Return result as a list so nil values
;;; can be ignored by MAPCAN.
(defun get-default-format (column-spec &optional suppress-id-p)
  (let* ((name (first column-spec))
		 (type (second column-spec))
		 (default-format nil))
	(cond ((cl-ppcre:scan "int" type)
		   (unless (and (string= "id" name) suppress-id-p)
			 (setf default-format (list (format nil "$this->~A" name)))))
		  (t
		   (setf default-format (list (format nil "'$this->~A'" name)))))
	default-format))

(defun generate-class-for-table (tablename &optional classname no-sprocs-p)
  "Generate a php class file for TABLENAME.
The name of the class is auto-generated from the capitalized TABLENAME.
If CLASSNAME is provided, it is used instead."
  (let ((columns (filter-columns (describe-table tablename) class-ignore-columns))
		(filename (format nil "generated/class.~A.php" tablename))
        (source-filename (if no-sprocs-p
                             "gen-php/class-nosproc.php"
                             "gen-php/class-sproc.php")))
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
						(setf line (cl-ppcre:regex-replace "Classname" line classname))
						(setf line (cl-ppcre:regex-replace "Classname" line (format nil "~@(~A~)" tablename))))
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
				   ((cl-ppcre:scan "sprocinsert" line)
					(setf line (cl-ppcre:regex-replace "sprocinsert" line
													   (format nil "~{~a~^, ~}"
															   (mapcan (lambda (c) (get-default-format c t))
																	   columns))))
					(write-lines line outfile))
				   ((cl-ppcre:scan "sprocupdate" line)
					(setf line (cl-ppcre:regex-replace "sprocupdate" line
													   (format nil "~{~a~^, ~}"
															   (mapcan (lambda (c) (get-default-format c))
																	   columns))))
					(write-lines line outfile))
				   ((cl-ppcre:scan "/. properties ./" line)
                    (transform-column-lines columns (lambda (c) (format nil "~4,0tpublic $~A;" (first c))) outfile)
                    ;;(write-lines (format nil "~4,0tpublic") outfile)
                    ;;(transform-column-lines columns (lambda (c) (format nil "~8,0t$~A;" (first c))) outfile)
                    )
				   ((cl-ppcre:scan "/. initialize ./" line)
					(transform-column-lines columns (lambda (c) (format nil "~8,0t$this->~A = ~A;" (first c) (get-default-value c))) outfile))
				   ((cl-ppcre:scan "/. getters ./" line)
					(transform-column-lines columns (lambda (c) (format nil "~8,0t$this->~A = $result['~A'];" (first c) (first c))) outfile))
				   (t
					(write-lines line outfile))))
		(write-line "" outfile)))
    (list source-filename filename)))

(defun generate-view-for-table (tablename)
  "Generate a php table view file for TABLENAME."
  (let ((columns (filter-columns (describe-table tablename) view-ignore-columns))
		(filename (format nil "view-~A.php" tablename)))
    (with-open-file (outfile filename :direction :output :if-exists :supersede)
      (write-lines "<?php if ($items) { ?>" outfile)
      (write-lines "<table>" outfile)
      ;; Headings
      (write-lines (format nil "~2,0t<thead>") outfile)
      (write-lines (format nil "~4,0t<tr>") outfile)
      (dolist (column columns)
        ;;(write-lines (format nil "~4,0t<th>") outfile)
        ;;(write-lines (format nil "~6,0t~A" (car column)) outfile)
        ;;(write-lines (format nil "~4,0t</th>") outfile)
        (write-lines (format nil "~6,0t<th>~A</th>" (car column)) outfile))
      (write-lines (format nil "~2,0t</tr>") outfile)
      (write-lines (format nil "~4,0t</thead>") outfile)
      ;; Data
      (write-lines (format nil "~2,0t<tbody>") outfile)
      (write-lines (format nil "~4,0t<?php foreach ($items as $item) { ?>") outfile)
      (write-lines (format nil "~4,0t<tr>") outfile)
      (dolist (column columns)
        (write-lines (format nil "~6,0t<td>") outfile)
        (write-lines (format nil "~8,0t<?php echo $item['~A']; ?>" (car column)) outfile)
        (write-lines (format nil "~6,0t</td>") outfile))
      (write-lines (format nil "~4,0t</tr>") outfile)
      (write-lines (format nil "~4,0t<?php } ?>") outfile)
      (write-lines (format nil "~2,0t</tbody>") outfile)
      (write-lines "</table>" outfile)
      (write-lines "<?php } else { ?>" outfile)
      (write-lines "No items to display." outfile)
      (write-lines "<?php } ?>" outfile)
      (write-line "" outfile))
    filename))
