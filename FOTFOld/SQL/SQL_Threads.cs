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
    class SQL_Threads
    {
        public static List<Threads> GetAll()
        {
            List<Threads> results = new List<Threads>();

            string connString = ConfigurationManager.ConnectionStrings["FOTFOld"].ConnectionString;
            string providerName = ConfigurationManager.ConnectionStrings["FOTFOld"].ProviderName;
            DbProviderFactory provider = DbProviderFactories.GetFactory(providerName);

            using (DbConnection conn = provider.CreateConnection())
            {
                conn.ConnectionString = connString;

                using (DbCommand cmd = conn.CreateCommand())
                {

                    string sql = "Select * from tblThread";

                    cmd.CommandText = sql;
                    cmd.CommandType = CommandType.Text;

                    conn.Open();

                    using (DbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Threads temp = new Threads();

                            temp.isNew = false;
                            temp.ThreadID = dr.GetInt32(0);
                            if (!dr.IsDBNull(1))
	                            temp.ForumID = dr.GetInt32(1);
                            if (!dr.IsDBNull(2))
	                            temp.Title = dr.GetString(2);
                            if (!dr.IsDBNull(3))
	                            temp.MemberID = dr.GetInt32(3);
                            if (!dr.IsDBNull(4))
	                            temp.Date = dr.GetDateTime(4);
                            if (!dr.IsDBNull(5))
	                            temp.Locked = dr.GetString(5);

                            temp.Posts = Posts.GetAll().FindAll(delegate(Posts p) { return p.ThreadID == temp.ThreadID; });

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
