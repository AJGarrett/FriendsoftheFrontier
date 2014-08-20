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
    class SQL_GuestbookManagement
    {
        public List<GuestbookManagement> GetAll()
        {
            List<GuestbookManagement> results = new List<GuestbookManagement>();

	        string connString = ConfigurationManager.ConnectionStrings["CLRDBConnection"].ConnectionString;
            string providerName = ConfigurationManager.ConnectionStrings["CLRDBConnection"].ProviderName;
            DbProviderFactory provider = DbProviderFactories.GetFactory(providerName);

            using (DbConnection conn = provider.CreateConnection())
            {
                conn.ConnectionString = connString;

                using (DbCommand cmd = conn.CreateCommand())
                {

                    string sql = "Select * from GuestbookManager";

                    cmd.CommandText = sql;
                    cmd.CommandType = CommandType.Text;

		            conn.Open();

                    using (DbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
			                GuestbookManagement temp = new GuestbookManagement();

			                temp.isNew = false;
                            temp.GBID = dr.GetInt32(0);
                            if (!dr.IsDBNull(1))
	                            temp.SiteID = dr.GetInt32(1);
                            if (!dr.IsDBNull(2))
	                            temp.URL = dr.GetString(2);

                            results.Add(temp);
                        }
                    }

                    conn.Close();
                    conn.Dispose();
                }
            }

            return results;
        }

        public GuestbookManagement GetSingle (int GBID)
        {
            GuestbookManagement temp = new GuestbookManagement();

            string connString = ConfigurationManager.ConnectionStrings["CLRDBConnection"].ConnectionString;
            string providerName = ConfigurationManager.ConnectionStrings["CLRDBConnection"].ProviderName;
            DbProviderFactory provider = DbProviderFactories.GetFactory(providerName);

            using (DbConnection conn = provider.CreateConnection())
            {
                conn.ConnectionString = connString;

                using (DbCommand cmd = conn.CreateCommand())
                {

                    string sql = "Select * from GuestbookManager where GBID = @ID";

                    cmd.CommandText = sql;
                    cmd.CommandType = CommandType.Text;

                    DbParameter ID = provider.CreateParameter();
                    ID.ParameterName = "@ID";
                    ID.Value = GBID;
                    cmd.Parameters.Add(ID);

                    conn.Open();

                    using (DbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            temp.isNew = false;
                            temp.GBID = dr.GetInt32(0);
                            if (!dr.IsDBNull(1))
                                temp.SiteID = dr.GetInt32(1);
                            if (!dr.IsDBNull(2))
                                temp.URL = dr.GetString(2);
                        }
                    }

                    conn.Close();
                    conn.Dispose();
                }
            }

            return temp;
        }

        public void Delete(int GBID)
        {
            string connString = ConfigurationManager.ConnectionStrings["CLRDBConnection"].ConnectionString;
            string providerName = ConfigurationManager.ConnectionStrings["CLRDBConnection"].ProviderName;
            DbProviderFactory provider = DbProviderFactories.GetFactory(providerName);

            using (DbConnection conn = provider.CreateConnection())
            {
                conn.ConnectionString = connString;

                using (DbCommand cmd = conn.CreateCommand())
                {

                    string sql = "Delete from GuestbookManager where GBID = @ID";

                    cmd.CommandText = sql;
                    cmd.CommandType = CommandType.Text;

                    DbParameter ID = provider.CreateParameter();
                    ID.ParameterName = "@ID";
                    ID.Value = GBID;
                    cmd.Parameters.Add(ID);

                    conn.Open();

                    cmd.ExecuteNonQuery();
                    
                    conn.Close();
                    conn.Dispose();
                }
            }

        }

        public int Insert(GuestbookManagement m)
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

                    string sql = "Insert into GuestbookManager (SiteID, URL) VALUES (@SiteID, SUBSTRING(@URL, 1, 250))";

                    cmd.CommandText = sql;
                    cmd.CommandType = CommandType.Text;

                    DbParameter SiteID = provider.CreateParameter();
                    SiteID.ParameterName = "@SiteID";
                    SiteID.Value =  m.SiteID;
                    cmd.Parameters.Add(SiteID);
                    
                    DbParameter URL = provider.CreateParameter();
                    URL.ParameterName = "@URL";
                    if (m.URL  == "" || m.URL  ==  null)
	                    URL.Value =  DBNull.Value;
                    else
	                    URL.Value =  m.URL;
                    cmd.Parameters.Add(URL);

                    conn.Open();

                    cmd.ExecuteNonQuery();

                    conn.Close();

                    sql = "Select MAX(GBID) from GuestbookManager";
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

        public void Update(GuestbookManagement m)
        {
            string connString = ConfigurationManager.ConnectionStrings["CLRDBConnection"].ConnectionString;
            string providerName = ConfigurationManager.ConnectionStrings["CLRDBConnection"].ProviderName;
            DbProviderFactory provider = DbProviderFactories.GetFactory(providerName);

            using (DbConnection conn = provider.CreateConnection())
            {
                conn.ConnectionString = connString;

                using (DbCommand cmd = conn.CreateCommand())
                {

                    string sql = "Update GuestbookManager SET SiteID = @SiteID, URL = SUBSTRING(@URL, 1, 250) where GBID = @GBID";

                    cmd.CommandText = sql;
                    cmd.CommandType = CommandType.Text;

                    DbParameter SiteID = provider.CreateParameter();
                    SiteID.ParameterName = "@SiteID";
                    SiteID.Value = m.SiteID;
                    cmd.Parameters.Add(SiteID);

                    DbParameter URL = provider.CreateParameter();
                    URL.ParameterName = "@URL";
                    if (m.URL == "" || m.URL == null)
                        URL.Value = DBNull.Value;
                    else
                        URL.Value = m.URL;
                    cmd.Parameters.Add(URL);

                    DbParameter GBID = provider.CreateParameter();
                    GBID.ParameterName = "@GBID";
                    GBID.Value =  m.GBID;
                    cmd.Parameters.Add(GBID);

                    conn.Open();

                    cmd.ExecuteNonQuery();

                    conn.Close();
                    conn.Dispose();
                }
            }
        }
    }
}
