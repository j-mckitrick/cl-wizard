;;;; -*- mode: lisp -*-

(in-package #:cl-user)

(defpackage #:util
  (:use #:cl #:cl-user #:clsql #:cl-ppcre #:xml-emitter #:s-xml #:split-sequence)
  (:export

   ;; variables
   #:class-ignore-columns
   #:view-ignore-columns

   ;; functions
   #:filter-columns
   #:transform-column-lines
   #:connect-to-flex
   #:disconnect-from-flex
   #:describe-table
   #:write-lines
   #:find-sproc
   #:show-sproc
   ))

(in-package #:util)

;;(defparameter *db-connect-spec* '("" "s-flex-sql" "sidewinder_front" "(32p9v209$4652"))
;;(defparameter *db-connect-spec* '("ameriflex.info" "dbaf_sidewinder" "sidewinder_front" "(32p9v209$4652"))
;;(defparameter *db-connect-spec* '("127.0.0.1" "dbaf_sidewinder" "donnymcK" "m3P455t1m3." "3307"))
;;(defparameter *db-connect-spec* '("127.0.0.1" "dbaf_sidewinder" "sidewinder" "#[v923-9v2hk" "3307"))
(defparameter *db-connect-spec* '("127.0.0.1" "dbaf_sidewinder" "swuser" "Dq3P2nf24" "3307") "Sidewinder")
;;(defparameter *db-connect-spec* '("127.0.0.1" "sidewinder" "sidewinder" "51d3w!ndeR" "3307") "IM")

(defparameter *backend-language* 'php)

(defun connect-to-flex ()
  ;;(clsql:connect *db-connect-spec* :database-type :odbc :if-exists :old)
  (clsql:connect *db-connect-spec* :database-type :mysql :if-exists :old)
  (format t "; --> Connected to db.~%"))

(defun disconnect-from-flex ()
  (clsql:disconnect))

(defun write-lines (line stream)
  (write-line line)
  (write-line line stream))

(defun get-query-column (column query)
  (when (first query)
	(destructuring-bind ((vals &rest rest) cols) query
	  (declare (ignorable rest))
	  (when (position column cols :test #'equal)
		(nth (position column cols :test #'equal) vals)))))

(defun describe-table (table)
  (clsql:query (format nil "describe ~A" table)))

(defparameter class-ignore-columns
  (list "updatedByUser" "updatedByUserType" "updatedAt" "createdByUser" "createdByUserType" "createdAt"))

(defparameter view-ignore-columns
  (cons "id" class-ignore-columns))

(defun filter-columns (columns ignore-list)
  (let ((filtered-columns ()))
    (setf filtered-columns (remove-if (lambda (arg) (member (car arg) ignore-list :test #'string=)) columns))
    #- (and)
    (dolist (column filtered-columns)
      (format t "Table description row: ~A~%" column))
    filtered-columns))

(defun transform-column-lines (columns fn outfile)
  (dolist (column columns)
	(let ((out-line (funcall fn column)))
	  (write-lines out-line outfile))))

;;; select * from mysql.proc where proc.body like '%email_address%';
(defun find-sproc (sproc-name-part &optional db-name)
  "Find all sprocs that contain SPROC-NAME-PART in DB-NAME or all databases."
  (let ((result
         (clsql:query (format nil "SELECT db, name FROM mysql.proc where proc.name like '%~A%'" sproc-name-part))))
    (dolist (sproc result)
      (when (or (null db-name)
                (ppcre:scan db-name (first sproc)))
        (format t "db: ~A name: ~A~%" (first sproc) (second sproc))))))

(defun show-sproc (sproc-name &optional (db-name "dbaf"))
  "Show the code for SPROC-NAME in DB-NAME or all databases."
  (let ((result
         (clsql:query (format nil "SELECT name, param_list, body, db FROM mysql.proc where proc.name like '%~A%'" sproc-name))))
    (dolist (sproc result)
      (when (or (null db-name)
                (ppcre:scan db-name (fourth sproc)))
        (format t "name: ~A~%" (first sproc))
        (format t "params: ~A~%" (second sproc))
        (format t "body: ~A~%~%" (third sproc))))))

(defparameter *config-file* "conf/config.xml")

(defun save-config ()
    (with-open-file
      (s *config-file* :direction :output :if-exists :supersede)
      (with-xml-output (s)
        (with-tag ("wizard")
          (with-tag ("db"
                     `(("server" "ameriflex.info")
                       ("database" "dbaf_sidewinder")
                       ("username" "sidewinder_front")
                       ("password" "(32p9v209$4652"))))
          (with-tag ("backend"
                     `(("language" "php")
                       ("sprocs" "yes"))))))))

(defun load-element-fn (name attributes seed)
  (cond
    ((string= name "db")
     (setf *db-connect-spec*
           (list
            (cdr (assoc :|server| attributes))
            (cdr (assoc :|database| attributes))
            (cdr (assoc :|username| attributes))
            (cdr (assoc :|password| attributes)))))
    ((string= name "backend")
     (setf *backend-language* (cdr (assoc :language attributes)))))
  seed)

(defun done-element-fn (name attributes parent-seed seed)
  (declare (ignorable name attributes parent-seed seed))
  seed)

(defun load-content-fn (text seed)
  (declare (ignorable text seed))
  seed)

(defun load-config ()
  (with-open-file
      (s *config-file* :direction :input)
    (start-parse-xml s
                     (make-instance 'xml-parser-state
                                    :seed nil
                                    :new-element-hook #'load-element-fn
                                    :finish-element-hook #'done-element-fn
                                    :text-hook #'load-content-fn))))

(defun read-rh ()
  (dolist (filename (directory (make-pathname :name :wild :type :wild :defaults "/home/jcm/arc/rhstuff/")))
    (with-open-file (s filename)
      (format t "~%File: ~A~%" filename)
      (loop for line = (read-line s nil nil) while line do
           (setf line (string-right-trim '(#\Newline #\Linefeed #\Return) line))
         ;;(format t "Line: ~A~%" line)
           (let ((vals (split-sequence #\| line)))
             (unless (string= (first vals) "RHBIN")
               ;;(format t "Vals: ~A~%" vals)
               (insert-records :into '|relaysleeveordersarchive|
                               :attributes '(rhbin rxpcn rhgroupid rhmemberid firstname lastname
                                             address1 address2 city st zip dateissued)
                               :values vals)))))))

;;(defun get-archive-record (id))

(defun get-ptp-records-by-name-division (firstname lastname division-id)
  (declare (ignorable division-id))
  (let* ((sql (format nil
                      "SELECT id, firstname, lastname, fkdivisionid, hasrelaysleeve FROM participant WHERE firstname = '~A' AND lastname = '~A' AND fkdivisionid = ~A"
                      ;;"SELECT id, firstname, lastname, fkdivisionid, hasrelaysleeve FROM participant WHERE firstname = '~A' AND lastname = '~A'"
                      firstname (substitute #\" #\' lastname)
                      division-id
                      ))
         (result (query sql)))
    result))

(defun get-ptp-record-by-id (id)
  (let* ((sql (format nil
                      "SELECT firstname, lastname, fkdivisionid FROM participant WHERE id = ~A" id))
         (result (query sql :flatp t)))
    (first result)))

(defun get-group-by-amfcode (amfcode)
  (let* ((sql (format nil "SELECT fkdivisionid FROM divisionfsk WHERE amfcode = '~A'" amfcode))
         (result (query sql :flatp t)))
    (format t "Result: ~A~%" result)))

(defun get-group-by-rhid (rhid)
  (let* ((sql (format nil "SELECT fkdivisionid, amfcode FROM divisionfsk WHERE rhemployerid = '~A'" rhid))
         (result (query sql :flatp t)))
    ;;(format t "SQL: ~A~%" sql)
    ;;(format t "Result: ~A~%" result)
    (first result)))

(defun get-ptp-id-by-name-amfcode (fname lname rhid)
  (let* ((division (get-group-by-rhid rhid))
         (sql (format nil
                      "SELECT id FROM participant WHERE firstname LIKE '%~A%' AND lastname LIKE '%~A%' AND fkdivisionid = ~A"
                      (substitute #\" #\' fname) (substitute #\" #\' lname) (first division)))
         (result (query sql :flatp t)))
    (first result)))

(defun update-archive-not-found (id)
  (let ((sql (format nil "UPDATE relaysleeveordersarchive SET participantNotFound = 1 WHERE id = ~A" id)))
    ;;(format t "SQL: ~A~%" sql)
    (execute-command sql)
    ))

(defun update-archive-no-card (id)
  (let ((sql (format nil "UPDATE relaysleeveordersarchive SET cardNotFound = 1 WHERE id = ~A" id)))
    ;;(format t "SQL: ~A~%" sql)
    (execute-command sql)
    ))

(defun query-rh-by-name ()
  (let ((count 0)
        (result-set (query (format nil "SELECT fkparticipantid FROM relaysleeveorders WHERE orderdate >= '2011-05-01'"))))
    (dolist (result result-set)
      (let* ((ptp (get-ptp-record-by-id (first result)))
             (dupes (get-ptp-records-by-name-division (first ptp) (second ptp) (third ptp))))
        ;;(format t "~A: ~A ~A~%" (first result) (first ptp) (second ptp))
        ;;(format t "Found ~A~%" (length dupes))
        (when (> (length dupes) 1)
          (dolist (dupe dupes)
            (when (> (fifth dupe) 0)
              (incf count)
              ;;(format t "~A: ~A ~A~%" (first result) (first ptp) (second ptp))
              (format t "-- ~A: ~A ~A ~A~%" (first dupe) (second dupe) (third dupe) (fifth dupe)))))
        ))
    (format t "Count: ~A~%" count)
    ;;(return-from update-rh-by-name)
    ))

(defun update-rh-by-name ()
  (let ((current-id 0))
    (loop for result-set = (query (format nil "SELECT id, rhmemberid, firstname, lastname, dateissued, rhgroupid FROM relaysleeveordersarchive WHERE id > ~A LIMIT 100" current-id))
       while result-set do
         (dolist (result result-set)
           (destructuring-bind (id rhmemberid firstname lastname dateissued rhgroupid) result
             ;;(format t "Ptp: ~A ~A, ~A : ~A ~A~%" rhmemberid lastname firstname dateissued rhgroupid)
             (setf current-id id)
             (let* ((ptp-id (get-ptp-id-by-name-amfcode firstname lastname rhgroupid)))
               ;;(format t " Result: ~A~%" ptp-id)
               (if ptp-id
                   (let* ((ptp-result (query (format nil "SELECT hasrelaysleeve FROM participant WHERE id = ~A" ptp-id) :flatp t)))
                     ;;(format t " Has relay sleeve result: ~A~%" (first ptp-result))
                     (when (= (first ptp-result) 0)
                       (format t "Ptp: ~A ~A ~A, ~A : ~A ~A No card?~%" ptp-id rhmemberid lastname firstname dateissued rhgroupid)
                       (update-archive-no-card id)
                       ;;(format t "No card?~%")
                       ;;(format t "Ptp: ~A, ~A : ~A ~A~%" lastname firstname rhmemberid dateissued)
                       ;;(format t " Result: ~A~%" ptp-id)
                       ;;(format t "  Result: ~A~%" (first ptp-result))
                       ))
                   ;; else
                   (progn
                     (format t "Ptp: ~A ~A ~A, ~A : ~A ~A PTP NOT FOUND~%" id rhmemberid lastname firstname dateissued rhgroupid)
                     (update-archive-not-found id)
                     ;;(format t "Did not find ptp: ~A~%" ptp-id)
                     ))
               )))
         ;;(return-from update-rh-by-name)
         )))

(defun update-rh-by-id ()
  (let ((current-id 0))
    (loop for result-set =
         (query (format nil "SELECT id, rhmemberid, firstname, lastname, dateissued, rhgroupid FROM relaysleeveordersarchive WHERE id > ~A LIMIT 10" current-id))
       while result-set do
         (dolist (result result-set)
           (destructuring-bind (id rhmemberid firstname lastname dateissued rhgroupid) result
             (format t "Ptp: ~A, ~A : ~A ~A ~A~%" lastname firstname rhmemberid dateissued rhgroupid)
             (setf current-id id)
             (let* ((the-query (format nil "SELECT id FROM participant WHERE firstname LIKE '' AND lastname LIKE '' "))
                    ;;(the-query (format nil "SELECT fkparticipantid FROM participantfsk WHERE rhmemberid = '~A'" rhmemberid))
                    (ptpk-result (query the-query :flatp t))
                    (ptp-id (first ptpk-result)))
               (format t " Result: ~A ~A~%" ptpk-result ptp-id)
               (when ptp-id
                 (let* ((ptp-result (query (format nil "SELECT hasrelaysleeve FROM participant WHERE id = ~A" ptp-id) :flatp t)))
                   (format t " Has relay sleeve result: ~A~%" (first ptp-result))
                   (when (= (first ptp-result) 0)
                     (format t "Ptp: ~A, ~A : ~A ~A~%" lastname firstname rhmemberid dateissued)
                     (format t " Result: ~A ~A~%" ptpk-result ptp-id)
                     (format t "  Result: ~A~%" (first ptp-result)))))
               )))
         (break))))

(defun radix-values (radix)
  (assert (<= 2 radix 35)
          (radix)
          "RADIX must be between 2 and 35 (inclusive), not ~D." radix)
  (make-array radix
              :displaced-to "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ"
              :displaced-index-offset 0
              :element-type 'character))

(defun trim-string (string &optional (char '(#\Space #\Tab #\Newline
                                             #\Return #\Linefeed)))
  (let ((chars char))
    (subseq string 
			(loop for index upfrom 0 below (length string)
			   when (not (member (aref string index) chars)) 
			   do (return index)
			   ;; if we get here we're trimming the entire string
			   finally (return-from trim-string ""))
			(loop for index downfrom (length string)
			   when (not (member (aref string (1- index)) chars))
			   do (return index)))))

(defun parse-float (float-string
                    &key (start 0) (end nil) (radix 10)
					(junk-allowed t)
					(type 'single-float)
					(decimal-character #\.))
  (let ((radix-array (radix-values radix))
        (integer-part 0)
        (mantissa 0)
        (mantissa-size 1)
        (sign 1))
    (with-input-from-string
		(float-stream (string-upcase (trim-string float-string)) :start start :end end)
	  (labels ((peek () (peek-char nil float-stream nil nil nil))
			   (next () (read-char float-stream nil nil nil))
			   (sign () ;; reads the (optional) sign of the number
				 (cond
				   ((char= (peek) #\+) (next) (setf sign 1))
				   ((char= (peek) #\-) (next) (setf sign -1)))
				 (integer-part))
			   (integer-part ()
				 (cond
				   ((position (peek) radix-array)
					;; the next char is a valid char
					(setf integer-part (+ (* integer-part radix)
										  (position (next) radix-array)))
					;; again
					(return-from integer-part (integer-part)))
				   ((null (peek))
					;; end of string
					(done))
				   ((char= decimal-character (peek))
					;; the decimal seperator
					(next)
					(return-from integer-part (mantissa)))                   
				   ;; junk
				   (junk-allowed (done))
				   (t (bad-string))))
			   (mantissa ()                 
				 (cond
				   ((position (peek) radix-array)
					(setf mantissa (+ (* mantissa radix)
									  (position (next) radix-array))
						  mantissa-size (* mantissa-size radix))
					(return-from mantissa
					  (mantissa)))
				   ((or (null (peek)) junk-allowed)
					;; end of string
					(done))
				   (t (bad-string))))
			   (bad-string ()
				 (error "Unable to parse ~S." float-string))
			   (done ()
				 (return-from parse-float
				   (coerce (* sign (+ integer-part (/ mantissa mantissa-size))) type))))
		(sign)))))

(defun adjust-declines (&optional commit)
  (let ((q (concatenate 'string
                        "SELECT"
                        " g.mbi_id,"
                        " p.ssn,"
                        " t.account_type, t.group_id, t.participant_id, t.total_amt_paid,"
                        " t.invoice_type, t.transx_type_id, t.merchant_name, t.purchase_date, t.processed_date, t.location, t.plan_start_date, t.plan_end_date, t.invoice_id, transx_status_id"
                        " FROM `transaction` t"
                        " INNER JOIN `group` g ON g.id = t.group_id"
                        " INNER JOIN participant p ON p.id = t.participant_id"
                        " WHERE t.transx_status_id >= 30 AND t.invoice_id IS NOT NULL AND t.total_amt_paid != 0"
                        " ORDER BY g.mbi_id, p.ssn"
                        ;;" LIMIT 1"
                        ))
        (result-set)
        (count 1))
    (format t "-- ~A~%" q)
    (setf result-set (query q))
    (format t "-- Total rows: ~A~%" (length result-set))
    (dolist (result result-set)
      (destructuring-bind (amfcode ssn account-type group-id participant-id total-amount-paid invoice-type transx-type-id merchant-name purchase-date processed-date location plan-start-date plan-end-date invoice-id transx-status-id)
          result
        (format t "--  ~A. ~A ~A ssn ~A ~A account ~A ~A ~A ~A~%" count amfcode group-id ssn participant-id account-type total-amount-paid invoice-id invoice-type)
        (unless commit
          (setf participant-id 21930800)
          (setf group-id 147672))
        (setf total-amount-paid (parse-float total-amount-paid))
        (let ((reversal (if commit
                             (concatenate 'string
                                     "INSERT INTO `transaction` (account_type, group_id, participant_id, total_amt_paid,"
                                     "  invoice_type, transx_type_id, merchant_name, purchase_date, processed_date, location, plan_start_date, plan_end_date, transx_status_id)"
                                     (format nil
                                             " VALUES ('~A', ~A, ~A, ~A, '~A', ~A, 'REVERSAL of inv #~A ~A', '~A', '~A', '~A', '~A', '~A', ~A);"
                                             account-type group-id participant-id (- total-amount-paid)
                                             invoice-type transx-type-id invoice-id merchant-name purchase-date processed-date location plan-start-date plan-end-date transx-status-id))
                            (concatenate 'string
                                     "INSERT INTO `transaction` (account_type, group_id, participant_id, total_amt_paid,"
                                     "  invoice_type, transx_type_id, merchant_name, purchase_date, processed_date, location, plan_start_date, plan_end_date, ignore_for_invoicing, transx_status_id)"
                                     (format nil
                                             " VALUES ('~A', ~A, ~A, ~A, '~A', ~A, 'REVERSAL of inv #~A ~A', '~A', '~A', '~A', '~A', '~A', ~A, ~A);"
                                             account-type group-id participant-id (- total-amount-paid)
                                             invoice-type transx-type-id invoice-id merchant-name purchase-date processed-date location plan-start-date plan-end-date 1 transx-status-id)))))
          (format t "~A~%" reversal)))
      (when (= (rem count 10) 0)
        (format t "~%~%~%"))
      (incf count))))

(defun find-rh-dupes ()
  (format t "member id, last name, first name, current group, other groups~%")
  (let ((q "SELECT rhmemberid, fkparticipantid FROM participantfsk WHERE rhmemberid IS NOT NULL AND rhmemberid != ''")
        (result-set)
        (count 0))
    (setf result-set (query q))
    (dolist (result result-set)
      (let ((q (format nil "SELECT rhgroupid FROM relaysleeveordersarchive WHERE rhmemberid = '~A' AND rhgroupid IS NOT NULL AND rhgroupid != ''" (first result)))
            (result-set-2))
        ;;(format t "Q: ~A~%" q)
        (setf result-set-2 (query q))
        (when (> (length result-set-2) 2)
          (format t "Result-2 1: ~A~%" result-set-2)
          (setf result-set-2 (delete-duplicates result-set-2 :test #'string= :key #'first))
          (format t "Result-2 2: ~A~%" result-set-2))
        (when (> (length result-set-2) 1)
          (incf count)
          (let ((q (format nil "SELECT p.lastname, p.firstname, d.amfcode FROM participant p JOIN divisionfsk d ON d.fkdivisionid = p.fkdivisionid WHERE p.id = ~A" (second result)))
                (result-set-3)
                (r3))
            (setf result-set-3 (query q))
            (setf r3 (first result-set-3))
            (format t "~A," (first result))
            ;;(format t "For groups: ")
            #+nil (dolist (r2 result-set-2)
              (format t "~A " (first r2)))
            (format t "~A,~A,~A" (first r3) (second r3) (third r3))
            (dolist (r2 result-set-2)
              (let ((q (format nil "SELECT amfcode FROM divisionfsk WHERE rhemployerid = '~A'" (first r2)))
                    (result-set-4)
                    (r4))
                (setf result-set-4 (query q))
                (setf r4 (first result-set-4))
                (if (string/= (first r4) (third r3))
                    (format t ",~A" (first r4))))
              ;;(format t "~A " (first r2))
              )
            (format t "~%")
            ))))
    (format t "Total found: ~A~%" count)))

(defun fix-rh-dupes ()
  (let* ((datetime (date:decode-universal-time/plist (get-universal-time) 4))
         (dateheader (format nil "~A~2,'0d~2,'0d" (getf datetime :year) (getf datetime :month) (getf datetime :day)))
         (timeheader (format nil "~2,'0d~2,'0d~2,'0d" (getf datetime :hour) (getf datetime :minute) (getf datetime :second))))
    (format t "HDR|ELIG|~A|~A~%" dateheader timeheader)
    ;; Get all ptp's that have ever had a RH id.
    (let ((q "SELECT rhmemberid, fkparticipantid FROM participantfsk WHERE rhmemberid IS NOT NULL AND rhmemberid != ''"))
      (let ((participantfsks (query q))
            (count 0))
        (dolist (participantfsk participantfsks)
          (destructuring-bind (rhmemberid fkparticipantid) participantfsk
            ;; Get all groups associated with this ptp from historical sleeve orders.
            (let* ((q (format nil "SELECT rhgroupid FROM relaysleeveordersarchive WHERE rhmemberid = '~A' AND rhgroupid IS NOT NULL AND rhgroupid != ''" rhmemberid))
                   (before-list (query q))
                   (relaysleeveordersarchives (delete-duplicates before-list :test #'string= :key #'first)))
              ;; Look for cases where there are more than one group for a ptp.
              (when (> (length relaysleeveordersarchives) 1)
                (incf count)
                ;; Get all ptp info needed to generate eligibility row.
                (let* ((q (concatenate 'string
                                       "SELECT p.lastname, p.firstname, d.amfcode, p.fkdivisionid, p.birthdate, p.personcode, p.altid "
                                       ", pc.startdate, pc.enddate "
                                       "FROM participant p "
                                       "JOIN divisionfsk d ON d.fkdivisionid = p.fkdivisionid "
                                       "LEFT JOIN participantcoverage pc ON pc.fkParticipantID = p.id "
                                       (format nil "WHERE p.id = ~A" fkparticipantid)))
                       (participant (first (query q))))
                  (when (not (null participant))
                    (destructuring-bind (lastname firstname p-amfcode fkdivisionid birthdate personcode altid startdate enddate) participant
                      (declare (ignorable fkdivisionid enddate))
                      (dolist (relaysleeveordersarchive relaysleeveordersarchives)
                        (destructuring-bind (rhgroupid) relaysleeveordersarchive
                          (let* ((q (format nil "SELECT amfcode FROM divisionfsk WHERE rhemployerid = '~A'" rhgroupid))
                                 (divisionfsk (first (query q))))
                            (destructuring-bind (d-amfcode) divisionfsk
                              ;; Look for group amfcodes that do not match the ptp's current group.
                              (if (string/= d-amfcode p-amfcode)
                                  ;; Generate a zero balance for the ptp for this group.
                                  (format t
                                          "DTL|012825|AMF|~A|~A|~A|~A|~A|~A|~A|~A|~A|0.0|~%"
                                          ;;"DTL|012825|AMF|~A|~A|~A|~A|~A|~A|~A|~A|0.0|~%"
                                          rhgroupid rhmemberid personcode altid
                                          (ppcre:regex-replace-all "-" birthdate "")
                                          firstname lastname
                                          (or (ppcre:regex-replace-all "-" startdate "") "20110701")
                                          dateheader)))))))))))))
        (format t "TRL|~A~%" count)
        (format t "Total found: ~A~%" count)))))

(defun compare-counts-old ()
  (let* ((q "SELECT amfcode, pcount FROM participantCountsByAMFCode")
         (old-counts (query q)))
    (dolist (old-count old-counts)
      (destructuring-bind (amfcode pcounts) old-count
        (let* ((q (format nil "SELECT numemployees FROM participantCountsByAMFCODE_ec WHERE employer_id = '~A'" amfcode))
               (new-counts (query q)))
          (destructuring-bind (numemployees) (first new-counts)
            (format t "~A: ~A - ~A~%" amfcode pcounts numemployees)))))))

(defun compare-counts-pop ()
  (let* ((q "SELECT amfcode, pcount FROM participantCountsByAMFCode")
         (old-counts (query q))
         (q "SELECT employer_id, numemployees FROM participantCountsByAMFCODE_ec")
         (new-counts (query q))
         (old-hash (make-hash-table :test 'equal))
         (new-hash (make-hash-table :test 'equal))
         (count 0))
    (dolist (old-count old-counts)
      (destructuring-bind (amfcode pcounts) old-count
        (setf (gethash amfcode old-hash) pcounts)
        (setf (gethash amfcode old-hash-new) pcounts)))
    (dolist (new-count new-counts)
      (destructuring-bind (amfcode pcounts) new-count
        (setf (gethash amfcode new-hash) pcounts)
        (setf (gethash amfcode new-hash-new) pcounts)))
    (loop for key being the hash-keys of old-hash
          using (hash-value value)
          do
             (let ((new-value (gethash key new-hash 0)))
               (when (not (equalp value new-value))
                 (format t "~A: ~A - ~A~%" key value new-value)
                 (incf count))))
    (format t "Total: ~A~%" count)))

(defparameter old-hash-new (make-hash-table :test 'equal))
(defparameter new-hash-new (make-hash-table :test 'equal))

(defun compare-counts ()
  (let ((count 0))
    (loop for key being the hash-keys of old-hash-new
          using (hash-value value)
          do
             (let ((new-value (gethash key new-hash-new 0)))
               (when (not (equalp value new-value))
                 (format t "~A: ~A - ~A~%" key value new-value)
                 (when (> new-value 0)
                   (incf count)))))
    (format t "Total: ~A~%" count)))

(defun find-deposit-dupes-old ()
  (let ((q (concatenate 'string
                        "SELECT dep.id, p.id, dep.employeePreTax, dep.employerPreTax, dk.amfcode, count(*) FROM deposit dep "
                        "INNER JOIN participant p ON p.id = dep.fkParticipantID "
                        "INNER JOIN division d ON d.id = p.fkDivisionID "
                        "INNER JOIN divisionfsk dk ON dk.fkDivisionID = d.id "
                        "WHERE dep.depositDate >= '2012-04-27' "
                        "AND dep.depositDate <= '2012-05-01' "
                        "GROUP BY "
                        "dep.fkParticipantID "
                        "HAVING COUNT(*) > 1 "
                        "ORDER BY dk.amfcode")))
    (format t "~A~%" q)
    (return-from find-deposit-dupes-old)
    (let ((result-set (query q)))
      (dolist (result-row result-set)
        (format t "Row: ~A~%" result-row)))))

(defparameter *deposit-join-query*
  (concatenate 'string
               "SELECT * FROM deposit dep "
               ;;"SELECT dep.id FROM deposit dep "
               "INNER JOIN participant p ON p.id = dep.fkParticipantID "
               "INNER JOIN division d ON d.id = p.fkDivisionID "
               "INNER JOIN divisionfsk dk ON dk.fkDivisionID = d.id "
               "WHERE dk.amfcode = '~A' "
               "AND p.ssn = '~A' "
               "AND "
               "( "
               "dep.postedToProcessorDateTime = '~A' OR "
               "dep.postedToProcessorDateTime BETWEEN date_add('~A', interval -70 second) AND date_add('~A', interval 70 second) "
               ;;"dep.postedToProcessorDateTime BETWEEN '2012-05-01 12:22' AND '2012-05-01 14:01' ) "
               ") "
               "AND dep.employeePreTax = ~A"))

(defun find-deposit-dupes ()
  (let* ((target-q "SELECT * FROM _jcmTargetDeposits LIMIT 4000")
         (target-rows (query target-q))
         (row-count 0)
         (row-count-ok 0)
         (row-count-weird 0)
         (row-count-3 0)
         (row-count-4 0)
         (deletes 0))
    (dolist (target-row target-rows)
      (destructuring-bind (amfcode firstname lastname ssn txn-date txn-amount update-date) target-row
        (declare (ignorable firstname lastname update-date))
        ;;(format t "Target-Row: ~A ~A ~A ~A ~A ~A ~A~%" amfcode firstname lastname ssn txn-date txn-amount update-date)
        (let* ((deposits-q (format nil *deposit-join-query*
                                   amfcode
                                   ssn
                                   txn-date
                                   update-date
                                   update-date
                                   txn-amount))
               (deposits-rows (query deposits-q)))
          ;;(format t "~A~%" deposits-q)
          (incf row-count (length deposits-rows))
          (let* ((ids (mapcar #'car deposits-rows))
                 (deposit-dupe-q (format nil "DELETE from deposit WHERE id = ~A;" (car ids))))
            (declare (ignorable deposit-dupe-q))
            ;;(format t "IDs: ~A~%" ids)
            (case (length deposits-rows)
              (2
               (incf row-count-ok)
               (progn
                 (dolist (deposit-row deposits-rows)
                   (declare (ignorable deposit-row))
                   ;;(format t "D: ~A~%" (car deposit-row))
                   )))
              (3
               (incf row-count-3)
               (progn               
                 (format t "-- Found ~A~%" (length deposits-rows))
                 (format t "~A;~%" deposits-q)
                 (dolist (deposit-row deposits-rows)
                   (declare (ignorable deposit-row))
                   ;;(format t "D: ~A~%" deposit-row)
                   )))
              (4
               (incf row-count-4)
               (progn
                 (format t "Found ~A~%" (length deposits-rows))
                 (format t "~A~%" deposits-q)
                 (dolist (deposit-row deposits-rows)
                   (declare (ignorable deposit-row))
                   ;;(format t "D: ~A~%" deposit-row)
                   )))
              (otherwise
               (incf row-count-weird)
               (format t "-- Found ~A~%" (length deposits-rows))
               (format t "~A;~%" deposits-q)
               (progn
                 (dolist (deposit-row deposits-rows)
                   (declare (ignorable deposit-row))
                   ;;(format t "D: ~A~%" (car deposit-row))
                   ))))
            ;;(format t "~A~%" deposit-dupe-q)
            (incf deletes)
            )
          )))
    (format t "Target-Rows: ~A~%" (length target-rows))
    (format t "Target-Rows: ~A~%" (* (length target-rows) 2))
    ;;(format t "Deposit-Rows: ~A~%" row-count)
    (format t "Deposit-Rows OK: ~A~%" row-count-ok)
    (format t "Deposit-Rows Weird: ~A~%" row-count-weird)
    (format t "Deposit-Rows 3: ~A~%" row-count-3)
    (format t "Deposit-Rows 4: ~A~%" row-count-4)
    (format t "Deletes ~A~%" deletes)))

(defparameter *deposit-join-query-1*
  (concatenate 'string
               "SELECT * FROM deposit dep "
               "INNER JOIN participant p ON p.id = dep.fkParticipantID "
               "INNER JOIN division d ON d.id = p.fkDivisionID "
               "INNER JOIN divisionfsk dk ON dk.fkDivisionID = d.id "
               "WHERE dk.amfcode = '~A' "
               "AND p.ssn = '~A' "
               "AND dep.postedToProcessorDateTime = '~A' "
               "AND dep.employeePreTax = ~A;"))

(defparameter *deposit-join-query-2*
  (concatenate 'string
               "SELECT * FROM deposit dep "
               "INNER JOIN participant p ON p.id = dep.fkParticipantID "
               "INNER JOIN division d ON d.id = p.fkDivisionID "
               "INNER JOIN divisionfsk dk ON dk.fkDivisionID = d.id "
               "WHERE dk.amfcode = '~A' "
               "AND p.ssn = '~A' "
               "AND dep.postedToProcessorDateTime BETWEEN date_add('~A', interval -70 second) AND date_add('~A', interval 70 second) "
               "AND dep.employeePreTax = ~A;"))

(defun delete-deposit-dupes ()
  (let* ((target-q "SELECT * FROM _jcmTargetDeposits LIMIT 4000")
         (target-rows (query target-q))
         (deletes 0))
    (dolist (target-row target-rows)
      (destructuring-bind (amfcode firstname lastname ssn txn-date txn-amount update-date) target-row
        (declare (ignorable firstname lastname update-date))
        (let* ((deposits-q-1 (format nil *deposit-join-query-1*
                                   amfcode
                                   ssn
                                   txn-date
                                   txn-amount))
               (deposits-q-2 (format nil *deposit-join-query-2*
                                   amfcode
                                   ssn
                                   update-date
                                   update-date
                                   txn-amount))
               (deposits-rows-1 (query deposits-q-1))
               (deposits-rows-2 (query deposits-q-2)))
          (let* ((ids-1 (mapcar #'car deposits-rows-1))
                 (ids-2 (mapcar #'car deposits-rows-2))
                 (deposit-dupe-q-1 (format nil "DELETE from deposit WHERE id = ~A;" (car ids-1)))
                 (deposit-dupe-q-2 (format nil "DELETE from deposit WHERE id = ~A;" (car ids-2))))
            (format t "~A~%" deposit-dupe-q-1)
            (format t "~A~%" deposit-dupe-q-2)
            (format t "---~%")
            (with-transaction ()
              (when (and ids-1 ids-2)
                (query deposit-dupe-q-1)
                (query deposit-dupe-q-2)
                (incf deletes))
              (unless (and ids-1 ids-2)
                (format t "FAIL: ~%~A~%~A~%" deposits-q-1 deposits-q-2)))))))
    (format t "Target-Rows: ~A~%" (length target-rows))
    (format t "Deletes ~A~%" deletes)))
