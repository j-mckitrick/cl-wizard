using System;
using System.Collections;
using System.Data;
using MySql.Data.MySqlClient;

/* Generated from eb */

namespace SideWinder_Batch.Classes
{
    public class SWEB
    {
        #region Members

        private int _id;
        private string _record_id;
        private string _tpa_id;
        private string _employer_id;
        private string _employee_id;
        private string _prefix;
        private string _lastname;
        private string _firstname;
        private string _middleinitial;
        private string _phone;
        private string _address_line1;
        private string _address_line2;
        private string _city;
        private string _state;
        private string _zip;
        private string _country;
        private string _reimbursement_code;
        private string _email;
        private string _userdefined_field;
        private string _employee_status;
        private string _gender;
        private string _marital_status;
        private string _shippingaddress_line1;
        private string _shippingaddress_line2;
        private string _shippingaddress_city;
        private string _shippingaddress_state;
        private string _shippingaddress_zip;
        private string _shippingaddress_country;
        private string _birthdate;
        private string _bank_routing_number;
        private string _bank_account_number;
        private string _bank_account_type_code;
        private string _remarks;
        private string _employee_ssn;
        private string _health_plan_id;
        private string _dental_id;
        private string _vision_id;
        private string _pbm_id;
        private string _healthcare_coverage_default;
        private string _medical_coverage;
        private string _pharmacy_coverage;
        private string _dental_coverage;
        private string _hospital_coverage;
        private string _vision_coverage;
        private string _hearing_coverage;
        private string _eligibility_date;
        private string _last_updated;
        private string _last_updated_time;
        private string _card_number;
        private string _termination_date;
        private string _division;
        private string _employer_name;
        private string _card_design_id;
        private int _converted_to_participant;
        private int _synced_to_sidewinder;
        private string _medicare_hicn;
        private /* XXX */ string _notes;

        #endregion Members

        #region Properties

        public int id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        public string record_id
        {
            get
            {
                return _record_id;
            }
            set
            {
                _record_id = value;
            }
        }

        public string tpa_id
        {
            get
            {
                return _tpa_id;
            }
            set
            {
                _tpa_id = value;
            }
        }

        public string employer_id
        {
            get
            {
                return _employer_id;
            }
            set
            {
                _employer_id = value;
            }
        }

        public string employee_id
        {
            get
            {
                return _employee_id;
            }
            set
            {
                _employee_id = value;
            }
        }

        public string prefix
        {
            get
            {
                return _prefix;
            }
            set
            {
                _prefix = value;
            }
        }

        public string lastname
        {
            get
            {
                return _lastname;
            }
            set
            {
                _lastname = value;
            }
        }

        public string firstname
        {
            get
            {
                return _firstname;
            }
            set
            {
                _firstname = value;
            }
        }

        public string middleinitial
        {
            get
            {
                return _middleinitial;
            }
            set
            {
                _middleinitial = value;
            }
        }

        public string phone
        {
            get
            {
                return _phone;
            }
            set
            {
                _phone = value;
            }
        }

        public string address_line1
        {
            get
            {
                return _address_line1;
            }
            set
            {
                _address_line1 = value;
            }
        }

        public string address_line2
        {
            get
            {
                return _address_line2;
            }
            set
            {
                _address_line2 = value;
            }
        }

        public string city
        {
            get
            {
                return _city;
            }
            set
            {
                _city = value;
            }
        }

        public string state
        {
            get
            {
                return _state;
            }
            set
            {
                _state = value;
            }
        }

        public string zip
        {
            get
            {
                return _zip;
            }
            set
            {
                _zip = value;
            }
        }

        public string country
        {
            get
            {
                return _country;
            }
            set
            {
                _country = value;
            }
        }

        public string reimbursement_code
        {
            get
            {
                return _reimbursement_code;
            }
            set
            {
                _reimbursement_code = value;
            }
        }

        public string email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
            }
        }

        public string userdefined_field
        {
            get
            {
                return _userdefined_field;
            }
            set
            {
                _userdefined_field = value;
            }
        }

        public string employee_status
        {
            get
            {
                return _employee_status;
            }
            set
            {
                _employee_status = value;
            }
        }

        public string gender
        {
            get
            {
                return _gender;
            }
            set
            {
                _gender = value;
            }
        }

        public string marital_status
        {
            get
            {
                return _marital_status;
            }
            set
            {
                _marital_status = value;
            }
        }

        public string shippingaddress_line1
        {
            get
            {
                return _shippingaddress_line1;
            }
            set
            {
                _shippingaddress_line1 = value;
            }
        }

        public string shippingaddress_line2
        {
            get
            {
                return _shippingaddress_line2;
            }
            set
            {
                _shippingaddress_line2 = value;
            }
        }

        public string shippingaddress_city
        {
            get
            {
                return _shippingaddress_city;
            }
            set
            {
                _shippingaddress_city = value;
            }
        }

        public string shippingaddress_state
        {
            get
            {
                return _shippingaddress_state;
            }
            set
            {
                _shippingaddress_state = value;
            }
        }

        public string shippingaddress_zip
        {
            get
            {
                return _shippingaddress_zip;
            }
            set
            {
                _shippingaddress_zip = value;
            }
        }

        public string shippingaddress_country
        {
            get
            {
                return _shippingaddress_country;
            }
            set
            {
                _shippingaddress_country = value;
            }
        }

        public string birthdate
        {
            get
            {
                return _birthdate;
            }
            set
            {
                _birthdate = value;
            }
        }

        public string bank_routing_number
        {
            get
            {
                return _bank_routing_number;
            }
            set
            {
                _bank_routing_number = value;
            }
        }

        public string bank_account_number
        {
            get
            {
                return _bank_account_number;
            }
            set
            {
                _bank_account_number = value;
            }
        }

        public string bank_account_type_code
        {
            get
            {
                return _bank_account_type_code;
            }
            set
            {
                _bank_account_type_code = value;
            }
        }

        public string remarks
        {
            get
            {
                return _remarks;
            }
            set
            {
                _remarks = value;
            }
        }

        public string employee_ssn
        {
            get
            {
                return _employee_ssn;
            }
            set
            {
                _employee_ssn = value;
            }
        }

        public string health_plan_id
        {
            get
            {
                return _health_plan_id;
            }
            set
            {
                _health_plan_id = value;
            }
        }

        public string dental_id
        {
            get
            {
                return _dental_id;
            }
            set
            {
                _dental_id = value;
            }
        }

        public string vision_id
        {
            get
            {
                return _vision_id;
            }
            set
            {
                _vision_id = value;
            }
        }

        public string pbm_id
        {
            get
            {
                return _pbm_id;
            }
            set
            {
                _pbm_id = value;
            }
        }

        public string healthcare_coverage_default
        {
            get
            {
                return _healthcare_coverage_default;
            }
            set
            {
                _healthcare_coverage_default = value;
            }
        }

        public string medical_coverage
        {
            get
            {
                return _medical_coverage;
            }
            set
            {
                _medical_coverage = value;
            }
        }

        public string pharmacy_coverage
        {
            get
            {
                return _pharmacy_coverage;
            }
            set
            {
                _pharmacy_coverage = value;
            }
        }

        public string dental_coverage
        {
            get
            {
                return _dental_coverage;
            }
            set
            {
                _dental_coverage = value;
            }
        }

        public string hospital_coverage
        {
            get
            {
                return _hospital_coverage;
            }
            set
            {
                _hospital_coverage = value;
            }
        }

        public string vision_coverage
        {
            get
            {
                return _vision_coverage;
            }
            set
            {
                _vision_coverage = value;
            }
        }

        public string hearing_coverage
        {
            get
            {
                return _hearing_coverage;
            }
            set
            {
                _hearing_coverage = value;
            }
        }

        public string eligibility_date
        {
            get
            {
                return _eligibility_date;
            }
            set
            {
                _eligibility_date = value;
            }
        }

        public string last_updated
        {
            get
            {
                return _last_updated;
            }
            set
            {
                _last_updated = value;
            }
        }

        public string last_updated_time
        {
            get
            {
                return _last_updated_time;
            }
            set
            {
                _last_updated_time = value;
            }
        }

        public string card_number
        {
            get
            {
                return _card_number;
            }
            set
            {
                _card_number = value;
            }
        }

        public string termination_date
        {
            get
            {
                return _termination_date;
            }
            set
            {
                _termination_date = value;
            }
        }

        public string division
        {
            get
            {
                return _division;
            }
            set
            {
                _division = value;
            }
        }

        public string employer_name
        {
            get
            {
                return _employer_name;
            }
            set
            {
                _employer_name = value;
            }
        }

        public string card_design_id
        {
            get
            {
                return _card_design_id;
            }
            set
            {
                _card_design_id = value;
            }
        }

        public int converted_to_participant
        {
            get
            {
                return _converted_to_participant;
            }
            set
            {
                _converted_to_participant = value;
            }
        }

        public int synced_to_sidewinder
        {
            get
            {
                return _synced_to_sidewinder;
            }
            set
            {
                _synced_to_sidewinder = value;
            }
        }

        public string medicare_hicn
        {
            get
            {
                return _medicare_hicn;
            }
            set
            {
                _medicare_hicn = value;
            }
        }

        public /* XXX */ string notes
        {
            get
            {
                return _notes;
            }
            set
            {
                _notes = value;
            }
        }

        #endregion Properties

        #region Class LifeCycle

        public SWEB(
			int id
            ,string precord_id
            ,string ptpa_id
            ,string pemployer_id
            ,string pemployee_id
            ,string pprefix
            ,string plastname
            ,string pfirstname
            ,string pmiddleinitial
            ,string pphone
            ,string paddress_line1
            ,string paddress_line2
            ,string pcity
            ,string pstate
            ,string pzip
            ,string pcountry
            ,string preimbursement_code
            ,string pemail
            ,string puserdefined_field
            ,string pemployee_status
            ,string pgender
            ,string pmarital_status
            ,string pshippingaddress_line1
            ,string pshippingaddress_line2
            ,string pshippingaddress_city
            ,string pshippingaddress_state
            ,string pshippingaddress_zip
            ,string pshippingaddress_country
            ,string pbirthdate
            ,string pbank_routing_number
            ,string pbank_account_number
            ,string pbank_account_type_code
            ,string premarks
            ,string pemployee_ssn
            ,string phealth_plan_id
            ,string pdental_id
            ,string pvision_id
            ,string ppbm_id
            ,string phealthcare_coverage_default
            ,string pmedical_coverage
            ,string ppharmacy_coverage
            ,string pdental_coverage
            ,string phospital_coverage
            ,string pvision_coverage
            ,string phearing_coverage
            ,string peligibility_date
            ,string plast_updated
            ,string plast_updated_time
            ,string pcard_number
            ,string ptermination_date
            ,string pdivision
            ,string pemployer_name
            ,string pcard_design_id
            ,int pconverted_to_participant
            ,int psynced_to_sidewinder
            ,string pmedicare_hicn
            ,/* XXX */ string pnotes
			)
        {
            record_id = precord_id;
            tpa_id = ptpa_id;
            employer_id = pemployer_id;
            employee_id = pemployee_id;
            prefix = pprefix;
            lastname = plastname;
            firstname = pfirstname;
            middleinitial = pmiddleinitial;
            phone = pphone;
            address_line1 = paddress_line1;
            address_line2 = paddress_line2;
            city = pcity;
            state = pstate;
            zip = pzip;
            country = pcountry;
            reimbursement_code = preimbursement_code;
            email = pemail;
            userdefined_field = puserdefined_field;
            employee_status = pemployee_status;
            gender = pgender;
            marital_status = pmarital_status;
            shippingaddress_line1 = pshippingaddress_line1;
            shippingaddress_line2 = pshippingaddress_line2;
            shippingaddress_city = pshippingaddress_city;
            shippingaddress_state = pshippingaddress_state;
            shippingaddress_zip = pshippingaddress_zip;
            shippingaddress_country = pshippingaddress_country;
            birthdate = pbirthdate;
            bank_routing_number = pbank_routing_number;
            bank_account_number = pbank_account_number;
            bank_account_type_code = pbank_account_type_code;
            remarks = premarks;
            employee_ssn = pemployee_ssn;
            health_plan_id = phealth_plan_id;
            dental_id = pdental_id;
            vision_id = pvision_id;
            pbm_id = ppbm_id;
            healthcare_coverage_default = phealthcare_coverage_default;
            medical_coverage = pmedical_coverage;
            pharmacy_coverage = ppharmacy_coverage;
            dental_coverage = pdental_coverage;
            hospital_coverage = phospital_coverage;
            vision_coverage = pvision_coverage;
            hearing_coverage = phearing_coverage;
            eligibility_date = peligibility_date;
            last_updated = plast_updated;
            last_updated_time = plast_updated_time;
            card_number = pcard_number;
            termination_date = ptermination_date;
            division = pdivision;
            employer_name = pemployer_name;
            card_design_id = pcard_design_id;
            converted_to_participant = pconverted_to_participant;
            synced_to_sidewinder = psynced_to_sidewinder;
            medicare_hicn = pmedicare_hicn;
            notes = pnotes;
        }

        #endregion Class LifeCycle

        public static ArrayList GetCollection(int flag_value)
        {           
            MySqlConnection myConn = DBProxy.GetMySqlConnection();
            DBProxy.OpenConnectionForObject(ref myConn);
            MySqlCommand myCmd = new MySqlCommand("SELECT * from `eb` WHERE flag_column = " + flag_value, myConn);
            MySqlDataReader myRdr = null;
            ArrayList aCltn = new ArrayList();

            if (DBProxy.ExecuteSQLReader(ref myCmd, ref myRdr, "GETTER") == false)
            {
                if (myRdr != null && myRdr.IsClosed == false)
                    myRdr.Close();

                DBProxy.CloseConnectionForObject(ref myConn);

                return aCltn;
            }
                        
            while (myRdr.Read())
            {
                SWEB me = new SWEB(
                 (myRdr.IsDBNull(0) == true ? 0 : myRdr.GetInt32(0))
                ,(myRdr.IsDBNull(1) == true ? "" : myRdr.GetString(1))
                ,(myRdr.IsDBNull(2) == true ? "" : myRdr.GetString(2))
                ,(myRdr.IsDBNull(3) == true ? "" : myRdr.GetString(3))
                ,(myRdr.IsDBNull(4) == true ? "" : myRdr.GetString(4))
                ,(myRdr.IsDBNull(5) == true ? "" : myRdr.GetString(5))
                ,(myRdr.IsDBNull(6) == true ? "" : myRdr.GetString(6))
                ,(myRdr.IsDBNull(7) == true ? "" : myRdr.GetString(7))
                ,(myRdr.IsDBNull(8) == true ? "" : myRdr.GetString(8))
                ,(myRdr.IsDBNull(9) == true ? "" : myRdr.GetString(9))
                ,(myRdr.IsDBNull(10) == true ? "" : myRdr.GetString(10))
                ,(myRdr.IsDBNull(11) == true ? "" : myRdr.GetString(11))
                ,(myRdr.IsDBNull(12) == true ? "" : myRdr.GetString(12))
                ,(myRdr.IsDBNull(13) == true ? "" : myRdr.GetString(13))
                ,(myRdr.IsDBNull(14) == true ? "" : myRdr.GetString(14))
                ,(myRdr.IsDBNull(15) == true ? "" : myRdr.GetString(15))
                ,(myRdr.IsDBNull(16) == true ? "" : myRdr.GetString(16))
                ,(myRdr.IsDBNull(17) == true ? "" : myRdr.GetString(17))
                ,(myRdr.IsDBNull(18) == true ? "" : myRdr.GetString(18))
                ,(myRdr.IsDBNull(19) == true ? "" : myRdr.GetString(19))
                ,(myRdr.IsDBNull(20) == true ? "" : myRdr.GetString(20))
                ,(myRdr.IsDBNull(21) == true ? "" : myRdr.GetString(21))
                ,(myRdr.IsDBNull(22) == true ? "" : myRdr.GetString(22))
                ,(myRdr.IsDBNull(23) == true ? "" : myRdr.GetString(23))
                ,(myRdr.IsDBNull(24) == true ? "" : myRdr.GetString(24))
                ,(myRdr.IsDBNull(25) == true ? "" : myRdr.GetString(25))
                ,(myRdr.IsDBNull(26) == true ? "" : myRdr.GetString(26))
                ,(myRdr.IsDBNull(27) == true ? "" : myRdr.GetString(27))
                ,(myRdr.IsDBNull(28) == true ? "" : myRdr.GetString(28))
                ,(myRdr.IsDBNull(29) == true ? "" : myRdr.GetString(29))
                ,(myRdr.IsDBNull(30) == true ? "" : myRdr.GetString(30))
                ,(myRdr.IsDBNull(31) == true ? "" : myRdr.GetString(31))
                ,(myRdr.IsDBNull(32) == true ? "" : myRdr.GetString(32))
                ,(myRdr.IsDBNull(33) == true ? "" : myRdr.GetString(33))
                ,(myRdr.IsDBNull(34) == true ? "" : myRdr.GetString(34))
                ,(myRdr.IsDBNull(35) == true ? "" : myRdr.GetString(35))
                ,(myRdr.IsDBNull(36) == true ? "" : myRdr.GetString(36))
                ,(myRdr.IsDBNull(37) == true ? "" : myRdr.GetString(37))
                ,(myRdr.IsDBNull(38) == true ? "" : myRdr.GetString(38))
                ,(myRdr.IsDBNull(39) == true ? "" : myRdr.GetString(39))
                ,(myRdr.IsDBNull(40) == true ? "" : myRdr.GetString(40))
                ,(myRdr.IsDBNull(41) == true ? "" : myRdr.GetString(41))
                ,(myRdr.IsDBNull(42) == true ? "" : myRdr.GetString(42))
                ,(myRdr.IsDBNull(43) == true ? "" : myRdr.GetString(43))
                ,(myRdr.IsDBNull(44) == true ? "" : myRdr.GetString(44))
                ,(myRdr.IsDBNull(45) == true ? "" : myRdr.GetString(45))
                ,(myRdr.IsDBNull(46) == true ? "" : myRdr.GetString(46))
                ,(myRdr.IsDBNull(47) == true ? "" : myRdr.GetString(47))
                ,(myRdr.IsDBNull(48) == true ? "" : myRdr.GetString(48))
                ,(myRdr.IsDBNull(49) == true ? "" : myRdr.GetString(49))
                ,(myRdr.IsDBNull(50) == true ? "" : myRdr.GetString(50))
                ,(myRdr.IsDBNull(51) == true ? "" : myRdr.GetString(51))
                ,(myRdr.IsDBNull(52) == true ? "" : myRdr.GetString(52))
                ,(myRdr.IsDBNull(53) == true ? 0 : myRdr.GetInt32(53))
                ,(myRdr.IsDBNull(54) == true ? 0 : myRdr.GetInt32(54))
                ,(myRdr.IsDBNull(55) == true ? "" : myRdr.GetString(55))
                ,(myRdr.IsDBNull(56) == true ? "" : myRdr.GetString(56))
                    );

                aCltn.Add(me);
            }

            myRdr.Close();
            DBProxy.CloseConnectionForObject(ref myConn);

            return aCltn;
        }
    }
}

