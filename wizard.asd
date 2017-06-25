(defpackage :wizard (:use :cl :asdf))
(in-package :wizard)

(defsystem wizard
  :name "wizard"
  :components
  ((:module "util" :serial t
            :components ((:file "defpackage")
                         (:file "util")))
   (:module "gen-php" :depends-on ("util") :serial t
            :components ((:file "gen-php")))
   (:module "gen-dotnet" :depends-on ("util") :serial t
            :components ((:file "gen-dotnet")))
   (:module "accounts" :depends-on ("util") :serial t
            :components ((:file "participant")))
   (:file "start" :depends-on ("gen-php" "gen-dotnet")))
  :depends-on (:xml-emitter :s-xml :clsql :cl-ppcre :split-sequence :net-telent-date))
