using System;
using System.Collections;
using System.Data;
using MySql.Data.MySqlClient;

/* Generated from tablename */

namespace SideWinder_Batch.Classes
{
    public class Classname
    {
        #region Members

		/* members */

        #endregion Members

        #region Properties

		/* properties */
        #endregion Properties

        #region Class LifeCycle

        public Classname(
			int id
			/* constructor-params */
			)
        {
			/* construction */
        }

        #endregion Class LifeCycle

        public static ArrayList GetCollection(int flag_value)
        {           
            MySqlConnection myConn = DBProxy.GetMySqlConnection();
            DBProxy.OpenConnectionForObject(ref myConn);
            MySqlCommand myCmd = new MySqlCommand("SELECT * from `tablename` WHERE flag_column = " + flag_value, myConn);
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
                Classname me = new Classname(
					/* getters */
                    );

                aCltn.Add(me);
            }

            myRdr.Close();
            DBProxy.CloseConnectionForObject(ref myConn);

            return aCltn;
        }
    }
}
