using System;
using System.Collections;
using System.Data;
using MySql.Data.MySqlClient;

/* Generated from ed */

namespace SideWinder_Batch.Classes
{
    public class SWED
    {
        #region Members

        private int _id;
        private string _record_id;
        private string _tpa_id;
        private string _employer_id;
        private string _employee_id;
        private string _dependent_id;
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
        private string _dependent_status;
        private string _gender;
        private string _relationship;
        private string _full_time_student;
        private string _shippingaddress_line1;
        private string _shippingaddress_line2;
        private string _shippingaddress_city;
        private string _shippingaddress_state;
        private string _shippingaddress_zip;
        private string _shippingaddress_country;
        private string _birthdate;
        private string _dependent_ssn;
        private string _employee_ssn;
        private string _last_updated;
        private string _last_updated_time;
        private string _health_plan_id;
        private string _pbm_id;
        private string _card_number;
        private int _converted_to_dependent;
        private int _synced_to_sidewinder;
        private string _medicare_hicn;
        private string _eligibility_date;
        private string _termination_date;

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

        public string dependent_id
        {
            get
            {
                return _dependent_id;
            }
            set
            {
                _dependent_id = value;
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

        public string dependent_status
        {
            get
            {
                return _dependent_status;
            }
            set
            {
                _dependent_status = value;
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

        public string relationship
        {
            get
            {
                return _relationship;
            }
            set
            {
                _relationship = value;
            }
        }

        public string full_time_student
        {
            get
            {
                return _full_time_student;
            }
            set
            {
                _full_time_student = value;
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

        public string dependent_ssn
        {
            get
            {
                return _dependent_ssn;
            }
            set
            {
                _dependent_ssn = value;
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

        public int converted_to_dependent
        {
            get
            {
                return _converted_to_dependent;
            }
            set
            {
                _converted_to_dependent = value;
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

        #endregion Properties

        #region Class LifeCycle

        public SWED(
			int id
            ,string precord_id
            ,string ptpa_id
            ,string pemployer_id
            ,string pemployee_id
            ,string pdependent_id
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
            ,string pdependent_status
            ,string pgender
            ,string prelationship
            ,string pfull_time_student
            ,string pshippingaddress_line1
            ,string pshippingaddress_line2
            ,string pshippingaddress_city
            ,string pshippingaddress_state
            ,string pshippingaddress_zip
            ,string pshippingaddress_country
            ,string pbirthdate
            ,string pdependent_ssn
            ,string pemployee_ssn
            ,string plast_updated
            ,string plast_updated_time
            ,string phealth_plan_id
            ,string ppbm_id
            ,string pcard_number
            ,int pconverted_to_dependent
            ,int psynced_to_sidewinder
            ,string pmedicare_hicn
            ,string peligibility_date
            ,string ptermination_date
			)
        {
            record_id = precord_id;
            tpa_id = ptpa_id;
            employer_id = pemployer_id;
            employee_id = pemployee_id;
            dependent_id = pdependent_id;
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
            dependent_status = pdependent_status;
            gender = pgender;
            relationship = prelationship;
            full_time_student = pfull_time_student;
            shippingaddress_line1 = pshippingaddress_line1;
            shippingaddress_line2 = pshippingaddress_line2;
            shippingaddress_city = pshippingaddress_city;
            shippingaddress_state = pshippingaddress_state;
            shippingaddress_zip = pshippingaddress_zip;
            shippingaddress_country = pshippingaddress_country;
            birthdate = pbirthdate;
            dependent_ssn = pdependent_ssn;
            employee_ssn = pemployee_ssn;
            last_updated = plast_updated;
            last_updated_time = plast_updated_time;
            health_plan_id = phealth_plan_id;
            pbm_id = ppbm_id;
            card_number = pcard_number;
            converted_to_dependent = pconverted_to_dependent;
            synced_to_sidewinder = psynced_to_sidewinder;
            medicare_hicn = pmedicare_hicn;
            eligibility_date = peligibility_date;
            termination_date = ptermination_date;
        }

        #endregion Class LifeCycle

        public static ArrayList GetCollection(int flag_value)
        {           
            MySqlConnection myConn = DBProxy.GetMySqlConnection();
            DBProxy.OpenConnectionForObject(ref myConn);
            MySqlCommand myCmd = new MySqlCommand("SELECT * from `ed` WHERE flag_column = " + flag_value, myConn);
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
                SWED me = new SWED(
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
                ,(myRdr.IsDBNull(35) == true ? 0 : myRdr.GetInt32(35))
                ,(myRdr.IsDBNull(36) == true ? 0 : myRdr.GetInt32(36))
                ,(myRdr.IsDBNull(37) == true ? "" : myRdr.GetString(37))
                ,(myRdr.IsDBNull(38) == true ? "" : myRdr.GetString(38))
                ,(myRdr.IsDBNull(39) == true ? "" : myRdr.GetString(39))
                    );

                aCltn.Add(me);
            }

            myRdr.Close();
            DBProxy.CloseConnectionForObject(ref myConn);

            return aCltn;
        }
    }
}

