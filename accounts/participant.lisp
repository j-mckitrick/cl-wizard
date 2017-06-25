;;;; -*- mode: lisp -*-

(in-package #:cl-user)

(defpackage #:participant
  (:nicknames #:ptp)
  (:use #:cl #:cl-user #:cl-ppcre #:clsql #:util)
  (:export
   #:get-all-purses
   ))

(in-package #:participant)

(defparameter *purse-query* "
SELECT
p.firstname,
p.lastname,
p.id AS PartID,
p.ssn,
p.status,
ap.id AS APID,
ap.fkAccountID as AccountID,
pt.abbreviation AS PurseType,
pf.tsyspurseid,
pf.tsysplanyearindr,
ap.status as PurseStatus,
pp.startDate,
pp.enddate,
pp.GracePeriodEndDate,
pp.RunOutEndDate,
ppty.priority,
ap.balance,
ap.ledgerBalance AS availBalance,
ap.annualelectionamount,
ap.annualcontributions,
ap.rolloveramount,
ap.PerPayContribution,
ap.AutoDepositStartDate,
ap.fkPurseCalendarID,
ap.YTDDisbursed,
pp.enableForRelayMedical,
pp.enableForRelayPharm,
pp.id AS PPID,
d.id AS DivID,
d.name AS employer,
df.AMFCode,
pn.TSYSPlanID,
pn.id as PlanID
FROM accountpurse ap 
INNER JOIN account a ON a.id = ap.fkAccountID 
INNER JOIN participant p ON p.id = a.fkParticipantID
LEFT OUTER JOIN planpurse pp ON pp.id = ap.fkPlanPurseID
left outer join planpursefsk pf on pf.fkplanpurseid = pp.id
LEFT OUTER JOIN pursetype pt ON pt.id = pp.fkPurseTypeID
LEFT OUTER JOIN plan pn ON pn.id = pp.fkPlanID
LEFT OUTER JOIN division d ON d.id = pn.fkDivisionID
LEFT OUTER JOIN divisionfsk df ON df.fkDivisionID = d.id
LEFT OUTER JOIN pursepriority ppty ON d.id = ppty.fkdivisionid
AND ppty.fkpursetypeid = pp.fkpursetypeid
WHERE p.id = ~A
ORDER BY ppty.priority,
 ap.effectiveDate
")

(defparameter *rh-query* "
SELECT a.id,
fkAccountID,
fkPlanPurseID,
balance,
ledgerBalance,
effectiveDate,
expirationDate,
a.runout,
coverageType,
rolloverAmount,
annualElectionAmount,
annualContributions,
YTDDisbursed,
a.status,
a.fkPurseCalendarID,
a.PerPayContribution,
a.AutoDepositStartDate
FROM accountpurse a
INNER JOIN account ac ON ac.id = a.fkAccountID
INNER JOIN planpurse p ON p.id = a.fkPlanPurseID AND p.enableForRelayPharm = 1
INNER JOIN plan pn ON pn.id = p.fkPlanID
LEFT OUTER JOIN pursepriority pp ON pp.fkdivisionid = pn.fkDivisionID AND p.fkPurseTypeID = pp.fkpursetypeid
WHERE ac.fkParticipantID = ~A AND p.startDate <= CURDATE() AND
(p.GracePeriodEndDate >= CURDATE()) AND a.status IN (1, 2)
ORDER BY pp.priority, p.startDate;
")

(defun get-all-purses (participant-id)
  (let* ((query (format nil *purse-query* participant-id))
         (purse-reports (clsql:query query)))
    ;;(format t "Query: ~A~%" query)
    (dolist (purse-report purse-reports)
      (format t "Participant: ~A ~A id: ~A ssn: ~A~%"
              (pop purse-report)
              (pop purse-report)
              (pop purse-report)
              (pop purse-report))
      (pop purse-report)
      (format t "Account Purse ID: ~A " (pop purse-report))
      (format t "Account ID: ~A " (pop purse-report))
      (format t "Purse type: ~A~%" (pop purse-report))
      (pop purse-report)
      (pop purse-report)
      (format t "Status: ~A~%" (pop purse-report))
      (format t "Start date: ~A~%" (pop purse-report))
      (format t "End date: ~A~%" (pop purse-report))
      (format t "Grace: ~A~%" (pop purse-report))
      (format t "Runout: ~A~%" (pop purse-report))
      (pop purse-report)
      (format t "Balance: ~A~%" (pop purse-report))
      ;;(format t "~%")
      )))

(defun get-rh-purses (participant-id)
  (let ((query (format nil *rh-query* participant-id)))
    (clsql:query query)))
