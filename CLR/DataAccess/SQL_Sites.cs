using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Configuration.Provider;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace CLR.DataAccess
{
    class SQL_Sites
    {
        public List<Sites> GetAll()
        {
            List<Sites> results = new List<Sites>();

	        string connString = ConfigurationManager.ConnectionStrings["CLRDBConnection"].ConnectionString;
            string providerName = ConfigurationManager.ConnectionStrings["CLRDBConnection"].ProviderName;
            DbProviderFactory provider = DbProviderFactories.GetFactory(providerName);

            using (DbConnection conn = provider.CreateConnection())
            {
                conn.ConnectionString = connString;

                using (DbCommand cmd = conn.CreateCommand())
                {

                    string sql = "Select * from Sites";

                    cmd.CommandText = sql;
                    cmd.CommandType = CommandType.Text;

		            conn.Open();

                    using (DbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
			                Sites temp = new Sites();

			                temp.isNew = false;
                            temp.SiteID = dr.GetInt32(0);
                            if (!dr.IsDBNull(1))
	                            temp.SiteName = dr.GetString(1);
                            if (!dr.IsDBNull(2))
	                            temp.SiteDomain = dr.GetString(2);


                            results.Add(temp);
                        }
                    }

                    conn.Close();
                    conn.Dispose();
                }
            }

            return results;
        }

        public Sites GetSingle (int SiteID)
        {
            Sites temp = new Sites();

            string connString = ConfigurationManager.ConnectionStrings["CLRDBConnection"].ConnectionString;
            string providerName = ConfigurationManager.ConnectionStrings["CLRDBConnection"].ProviderName;
            DbProviderFactory provider = DbProviderFactories.GetFactory(providerName);

            using (DbConnection conn = provider.CreateConnection())
            {
                conn.ConnectionString = connString;

                using (DbCommand cmd = conn.CreateCommand())
                {

                    string sql = "Select * from Sites where SiteID = @ID";

                    cmd.CommandText = sql;
                    cmd.CommandType = CommandType.Text;

                    DbParameter ID = provider.CreateParameter();
                    ID.ParameterName = "@ID";
                    ID.Value = SiteID;
                    cmd.Parameters.Add(ID);

                    conn.Open();

                    using (DbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            temp.isNew = false;
                            temp.SiteID = dr.GetInt32(0);
                            if (!dr.IsDBNull(1))
                                temp.SiteName = dr.GetString(1);
                            if (!dr.IsDBNull(2))
                                temp.SiteDomain = dr.GetString(2);

                        }
                    }

                    conn.Close();
                    conn.Dispose();
                }
            }

            return temp;
        }

        public void Delete(int SiteID)
        {
            string connString = ConfigurationManager.ConnectionStrings["CLRDBConnection"].ConnectionString;
            string providerName = ConfigurationManager.ConnectionStrings["CLRDBConnection"].ProviderName;
            DbProviderFactory provider = DbProviderFactories.GetFactory(providerName);

            using (DbConnection conn = provider.CreateConnection())
            {
                conn.ConnectionString = connString;

                using (DbCommand cmd = conn.CreateCommand())
                {

                    string sql = "Delete from Sites where SiteID = @ID";

                    cmd.CommandText = sql;
                    cmd.CommandType = CommandType.Text;

                    DbParameter ID = provider.CreateParameter();
                    ID.ParameterName = "@ID";
                    ID.Value = SiteID;
                    cmd.Parameters.Add(ID);

                    conn.Open();

                    cmd.ExecuteNonQuery();

                    conn.Close();
                    conn.Dispose();
                }
            }
        }

        public int Insert(Sites s)
        {
            int ID = 0;

            string connString = ConfigurationManager.ConnectionStrings["CLRDBConnection"].ConnectionString;
            string providerName = ConfigurationManager.ConnectionStrings["CLRDBConnection"].ProviderName;
            DbProviderFactory provider = DbProviderFactories.GetFactory(providerName);

            using (DbConnection conn = provider.CreateConnection())
            {
                conn.ConnectionString = connString;

                using (DbCommand cmd = conn.CreateCommand())
                {

                    string sql = "Insert into Sites (SiteName, SiteDomain) VALUES (SUBSTRING(@SiteName, 1, 50), SUBSTRING(@SiteDomain, 1, 250))";

                    cmd.CommandText = sql;
                    cmd.CommandType = CommandType.Text;

                    DbParameter SiteName = provider.CreateParameter();
                    SiteName.ParameterName = "@SiteName";
                    if (s.SiteName  == "" || s.SiteName  ==  null)
	                    SiteName.Value =  DBNull.Value;
                    else
	                    SiteName.Value =  s.SiteName;
                    cmd.Parameters.Add(SiteName);

                    DbParameter SiteDomain = provider.CreateParameter();
                    SiteDomain.ParameterName = "@SiteDomain";
                    if (s.SiteDomain  == "" || s.SiteDomain  ==  null)
	                    SiteDomain.Value =  DBNull.Value;
                    else
	                    SiteDomain.Value = s.SiteDomain;
                    cmd.Parameters.Add(SiteDomain);

                    conn.Open();

                    cmd.ExecuteNonQuery();

                    conn.Close();


                    sql = "Select MAX(SiteID) from Sites";
                    cmd.CommandText = sql;
                    conn.Open();

                    using (DbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            ID = dr.GetInt32(0);
                        }
                    }

                    conn.Close();

                    conn.Dispose();
                }
            }

            return ID;
        }

        public void Update(Sites s)
        {
            string connString = ConfigurationManager.ConnectionStrings["CLRDBConnection"].ConnectionString;
            string providerName = ConfigurationManager.ConnectionStrings["CLRDBConnection"].ProviderName;
            DbProviderFactory provider = DbProviderFactories.GetFactory(providerName);

            using (DbConnection conn = provider.CreateConnection())
            {
                conn.ConnectionString = connString;

                using (DbCommand cmd = conn.CreateCommand())
                {

                    string sql = "Update Sites SET SiteName = SUBSTRING(@SiteName, 1, 50), , SiteDomain = SUBSTRING(@SiteDomain, 1, 250) WHERE SiteID = @SiteID";

                    cmd.CommandText = sql;
                    cmd.CommandType = CommandType.Text;

                    DbParameter SiteName = provider.CreateParameter();
                    SiteName.ParameterName = "@SiteName";
                    if (s.SiteName == "" || s.SiteName == null)
                        SiteName.Value = DBNull.Value;
                    else
                        SiteName.Value = s.SiteName;
                    cmd.Parameters.Add(SiteName);

                    DbParameter SiteDomain = provider.CreateParameter();
                    SiteDomain.ParameterName = "@SiteDomain";
                    if (s.SiteDomain == "" || s.SiteDomain == null)
                        SiteDomain.Value = DBNull.Value;
                    else
                        SiteDomain.Value = s.SiteDomain;
                    cmd.Parameters.Add(SiteDomain);

                    DbParameter SiteID = provider.CreateParameter();
                    SiteID.ParameterName = "@SiteID";
                    SiteID.Value =  s.SiteID;
                    cmd.Parameters.Add(SiteID);

                    conn.Open();

                    cmd.ExecuteNonQuery();

                    conn.Close();
                    conn.Dispose();
                }
            }
        }
    }
}
