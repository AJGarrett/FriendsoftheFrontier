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
    class SQL_Forums
    {
        public static List<Forums> GetAll()
        {
            List<Forums> results = new List<Forums>();

            string connString = ConfigurationManager.ConnectionStrings["FOTFOld"].ConnectionString;
            string providerName = ConfigurationManager.ConnectionStrings["FOTFOld"].ProviderName;
            DbProviderFactory provider = DbProviderFactories.GetFactory(providerName);

            using (DbConnection conn = provider.CreateConnection())
            {
                conn.ConnectionString = connString;

                using (DbCommand cmd = conn.CreateCommand())
                {

                    string sql = "Select * from tblForum";

                    cmd.CommandText = sql;
                    cmd.CommandType = CommandType.Text;

                    conn.Open();

                    using (DbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Forums temp = new Forums();

                            temp.isNew = false;
                            temp.ForumID = dr.GetInt32(0);
                            if (!dr.IsDBNull(1))
	                            temp.Title = dr.GetString(1);
                            if (!dr.IsDBNull(2))
	                            temp.Description = dr.GetString(2);
                            if (!dr.IsDBNull(3))
	                            temp.CreatorID = dr.GetInt32(3);
                            if (!dr.IsDBNull(4))
	                            temp.Date = dr.GetDateTime(4);
                            if (!dr.IsDBNull(5))
	                            temp.MMOnly = dr.GetString(5);

                            temp.Threads = Threads.GetAll().FindAll(delegate(Threads t) { return t.ForumID == temp.ForumID; });

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
