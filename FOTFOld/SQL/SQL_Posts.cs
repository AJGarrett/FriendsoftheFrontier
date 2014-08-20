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
    class SQL_Posts
    {
        public static List<Posts> GetAll()
        {
            List<Posts> results = new List<Posts>();

            string connString = ConfigurationManager.ConnectionStrings["FOTFOld"].ConnectionString;
            string providerName = ConfigurationManager.ConnectionStrings["FOTFOld"].ProviderName;
            DbProviderFactory provider = DbProviderFactories.GetFactory(providerName);

            using (DbConnection conn = provider.CreateConnection())
            {
                conn.ConnectionString = connString;

                using (DbCommand cmd = conn.CreateCommand())
                {

                    string sql = "Select * from tblPosts";

                    cmd.CommandText = sql;
                    cmd.CommandType = CommandType.Text;

                    conn.Open();

                    using (DbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Posts temp = new Posts();

                            temp.isNew = false;
                            temp.PostID = dr.GetInt32(0);
                            if (!dr.IsDBNull(1))
	                            temp.ThreadID = dr.GetInt32(1);
                            if (!dr.IsDBNull(2))
	                            temp.Post = dr.GetString(2);
                            if (!dr.IsDBNull(3))
	                            temp.MemberID = dr.GetInt32(3);
                            if (!dr.IsDBNull(4))
	                            temp.Date = dr.GetDateTime(4);

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
