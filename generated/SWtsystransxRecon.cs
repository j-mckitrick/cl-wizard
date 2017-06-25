using System;
using System.Collections;
using System.Data;
using MySql.Data.MySqlClient;

/* Generated from tsystransxRecon */

namespace SideWinder_Batch.Classes
{
    public class TsystransxRecon
    {
        #region Members

        private int _id;
        private int _fkTsystransxpurse;
        private DateTime _dateSent;
        private DateTime _dateReconciled;

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

        public int fkTsystransxpurse
        {
            get
            {
                return _fkTsystransxpurse;
            }
            set
            {
                _fkTsystransxpurse = value;
            }
        }

        public DateTime dateSent
        {
            get
            {
                return _dateSent;
            }
            set
            {
                _dateSent = value;
            }
        }

        public DateTime dateReconciled
        {
            get
            {
                return _dateReconciled;
            }
            set
            {
                _dateReconciled = value;
            }
        }

        #endregion Properties

        #region Class LifeCycle

        public TsystransxRecon(
			int id
            ,int pfkTsystransxpurse
            ,DateTime pdateSent
            ,DateTime pdateReconciled
			)
        {
            fkTsystransxpurse = pfkTsystransxpurse;
            dateSent = pdateSent;
            dateReconciled = pdateReconciled;
        }

        #endregion Class LifeCycle

        public static ArrayList GetCollection(int flag_value)
        {           
            MySqlConnection myConn = DBProxy.GetMySqlConnection();
            DBProxy.OpenConnectionForObject(ref myConn);
            MySqlCommand myCmd = new MySqlCommand("SELECT * from `tsystransxRecon` WHERE flag_column = " + flag_value, myConn);
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
                TsystransxRecon me = new TsystransxRecon(
                 (myRdr.IsDBNull(0) == true ? 0 : myRdr.GetInt32(0))
                ,(myRdr.IsDBNull(1) == true ? 0 : myRdr.GetInt32(1))
                ,(myRdr.IsDBNull(2) == true ? Utility.GetNullDate() : myRdr.GetDateTime(2))
                ,(myRdr.IsDBNull(3) == true ? Utility.GetNullDate() : myRdr.GetDateTime(3))
                    );

                aCltn.Add(me);
            }

            myRdr.Close();
            DBProxy.CloseConnectionForObject(ref myConn);

            return aCltn;
        }
    }
}

