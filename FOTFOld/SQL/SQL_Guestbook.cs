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
    class SQL_Guestbook
    {
        public static List<Guestbook> GetAll()
        {
            List<Guestbook> results = new List<Guestbook>();

            string connString = ConfigurationManager.ConnectionStrings["FOTFOld"].ConnectionString;
            string providerName = ConfigurationManager.ConnectionStrings["FOTFOld"].ProviderName;
            DbProviderFactory provider = DbProviderFactories.GetFactory(providerName);

            using (DbConnection conn = provider.CreateConnection())
            {
                conn.ConnectionString = connString;

                using (DbCommand cmd = conn.CreateCommand())
                {

                    string sql = "Select * from Guestbook";

                    cmd.CommandText = sql;
                    cmd.CommandType = CommandType.Text;

                    conn.Open();

                    using (DbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Guestbook temp = new Guestbook();

                            temp.isNew = false;
                            temp.ID = dr.GetInt32(0);
                            if (!dr.IsDBNull(1))
	                            temp.MemberID = dr.GetInt32(1);
                            if (!dr.IsDBNull(2))
	                            temp.Comments = dr.GetString(2);
                            if (!dr.IsDBNull(3))
	                            temp.Date = dr.GetDateTime(3);

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
