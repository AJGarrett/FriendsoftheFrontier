using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Configuration.Provider;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace FOTFOld.SQL
{
    class SQL_Members
    {
        public static List<Members> GetAll()
        {
            List<Members> results = new List<Members>();


            string connString = ConfigurationManager.ConnectionStrings["FOTFOld"].ConnectionString;
            string providerName = ConfigurationManager.ConnectionStrings["FOTFOld"].ProviderName; 
            DbProviderFactory provider = DbProviderFactories.GetFactory(providerName);

            using (DbConnection conn = provider.CreateConnection())
            {
                conn.ConnectionString = connString;

                using (DbCommand cmd = conn.CreateCommand())
                {

                    string sql = "Select * from Members";

                    cmd.CommandText = sql;
                    cmd.CommandType = CommandType.Text;

		            conn.Open();

                    using (DbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
			                Members temp = new Members();
                            
			                temp.isNew = false;
                            temp.ID = dr.GetInt32(0);
                            if (!dr.IsDBNull(1))
	                            temp.FName = dr.GetString(1);
                            if (!dr.IsDBNull(2))
	                            temp.LName = dr.GetString(2);
                            if (!dr.IsDBNull(3))
	                            temp.NickName = dr.GetString(3);
                            if (!dr.IsDBNull(4))
	                            temp.Email = dr.GetString(4);
                            if (!dr.IsDBNull(5))
	                            temp.Password = dr.GetString(5);
                            if (!dr.IsDBNull(6))
	                            temp.Address = dr.GetString(6);
                            if (!dr.IsDBNull(7))
	                            temp.City = dr.GetString(7);
                            if (!dr.IsDBNull(8))
	                            temp.State = dr.GetString(8);
                            if (!dr.IsDBNull(9))
	                            temp.Zip = dr.GetString(9);
                            if (!dr.IsDBNull(10))
	                            temp.Troop = dr.GetString(10);
                            if (!dr.IsDBNull(11))
	                            temp.TrpTown = dr.GetString(11);
                            if (!dr.IsDBNull(12))
	                            temp.PioneerYr = dr.GetString(12);
                            if (!dr.IsDBNull(13))
	                            temp.PioneerWk = dr.GetString(13);
                            if (!dr.IsDBNull(14))
	                            temp.TrapperYr = dr.GetString(14);
                            if (!dr.IsDBNull(15))
	                            temp.TrapperWk = dr.GetString(15);
                            if (!dr.IsDBNull(16))
	                            temp.MMYr = dr.GetString(16);
                            if (!dr.IsDBNull(17))
	                            temp.MMWk = dr.GetString(17);
                            if (!dr.IsDBNull(18))
	                            temp.MMCeremony = dr.GetString(18);
                            if (!dr.IsDBNull(19))
	                            temp.MMClaws = dr.GetString(19);
                            if (!dr.IsDBNull(20))
	                            temp.MMBC = dr.GetString(20);
                            if (!dr.IsDBNull(21))
	                            temp.Comments = dr.GetString(21);
                            if (!dr.IsDBNull(22))
	                            temp.Guestbook = dr.GetBoolean(22);
                            if (!dr.IsDBNull(23))
	                            temp.MMVerification = dr.GetBoolean(23);
                            if (!dr.IsDBNull(24))
	                            temp.Admin = dr.GetString(24);
                            if (!dr.IsDBNull(25))
	                            temp.LastLogon = dr.GetDateTime(25);
                            if (!dr.IsDBNull(26))
	                            temp.Moderator = dr.GetString(26);
                            if (!dr.IsDBNull(27))
	                            temp.Failed_Email = dr.GetString(27);

                            results.Add(temp);
                        }
                    }

                    conn.Close();
                    conn.Dispose();
                }
            }

            return results;
        }
    }
}
