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
    class SQL_StaffHistory
    {
        public List<StaffHistory> GetAll(int MemberID)
        {
            List<StaffHistory> results = new List<StaffHistory>();

	        string connString = ConfigurationManager.ConnectionStrings["CLRDBConnection"].ConnectionString;
            string providerName = ConfigurationManager.ConnectionStrings["CLRDBConnection"].ProviderName;
            DbProviderFactory provider = DbProviderFactories.GetFactory(providerName);

            using (DbConnection conn = provider.CreateConnection())
            {
                conn.ConnectionString = connString;

                using (DbCommand cmd = conn.CreateCommand())
                {

                    string sql = "Select * from StaffHistory where MemberID = @MemberID";

                    cmd.CommandText = sql;
                    cmd.CommandType = CommandType.Text;

                    DbParameter ID = provider.CreateParameter();
                    ID.ParameterName = "@MemberID";
                    ID.Value = MemberID;
                    cmd.Parameters.Add(ID);

		            conn.Open();

                    using (DbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
			                StaffHistory temp = new StaffHistory();

			                temp.isNew = false;
                            temp.JobID = dr.GetInt32(0);
                            if (!dr.IsDBNull(1))
	                            temp.MemberID = dr.GetInt32(1);
                            if (!dr.IsDBNull(2))
	                            temp.Summer = dr.GetInt32(2);
                            if (!dr.IsDBNull(3))
	                            temp.JobTitle = dr.GetString(3);
                            
                            results.Add(temp);
                        }
                    }

                    conn.Close();
                    conn.Dispose();
                }
            }

            return results;
        }

        public StaffHistory GetSingle (int JobID)
        {
            StaffHistory temp = new StaffHistory();

            string connString = ConfigurationManager.ConnectionStrings["CLRDBConnection"].ConnectionString;
            string providerName = ConfigurationManager.ConnectionStrings["CLRDBConnection"].ProviderName;
            DbProviderFactory provider = DbProviderFactories.GetFactory(providerName);

            using (DbConnection conn = provider.CreateConnection())
            {
                conn.ConnectionString = connString;

                using (DbCommand cmd = conn.CreateCommand())
                {

                    string sql = "Select * from StaffHistory where JobID = @JobID";

                    cmd.CommandText = sql;
                    cmd.CommandType = CommandType.Text;

                    DbParameter ID = provider.CreateParameter();
                    ID.ParameterName = "@JobID";
                    ID.Value = JobID;
                    cmd.Parameters.Add(ID);

                    conn.Open();

                    using (DbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            temp.isNew = false;
                            temp.JobID = dr.GetInt32(0);
                            if (!dr.IsDBNull(1))
                                temp.MemberID = dr.GetInt32(1);
                            if (!dr.IsDBNull(2))
                                temp.Summer = dr.GetInt32(2);
                            if (!dr.IsDBNull(3))
                                temp.JobTitle = dr.GetString(3);
                        }
                    }

                    conn.Close();
                    conn.Dispose();
                }
            }

            return temp;
        }

        public void Delete(int JobID)
        {
            string connString = ConfigurationManager.ConnectionStrings["CLRDBConnection"].ConnectionString;
            string providerName = ConfigurationManager.ConnectionStrings["CLRDBConnection"].ProviderName;
            DbProviderFactory provider = DbProviderFactories.GetFactory(providerName);

            using (DbConnection conn = provider.CreateConnection())
            {
                conn.ConnectionString = connString;

                using (DbCommand cmd = conn.CreateCommand())
                {

                    string sql = "Delete from StaffHistory where JobID = @JobID";

                    cmd.CommandText = sql;
                    cmd.CommandType = CommandType.Text;

                    DbParameter ID = provider.CreateParameter();
                    ID.ParameterName = "@JobID";
                    ID.Value = JobID;
                    cmd.Parameters.Add(ID);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    conn.Dispose();
                }
            }
        }

        public int Insert(StaffHistory h)
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

                    string sql = "Insert into StaffHistory (MemberID, Summer, JobTitle) VALUES (@MemberID, @Summer, SUBSTRING(@JobTitle, 1, 300))";

                    cmd.CommandText = sql;
                    cmd.CommandType = CommandType.Text;

                    DbParameter MemberID = provider.CreateParameter();
                    MemberID.ParameterName = "@MemberID";
                    MemberID.Value =  h.MemberID;
                    cmd.Parameters.Add(MemberID);

                    DbParameter Summer = provider.CreateParameter();
                    Summer.ParameterName = "@Summer";
                    if (h.Summer  == 0)
	                    Summer.Value =  DBNull.Value;
                    else
	                    Summer.Value =  h.Summer;
                    cmd.Parameters.Add(Summer);

                    DbParameter JobTitle = provider.CreateParameter();
                    JobTitle.ParameterName = "@JobTitle";
                    if (h.JobTitle  == "" || h.JobTitle  ==  null)
	                    JobTitle.Value =  DBNull.Value;
                    else
	                    JobTitle.Value =  h.JobTitle;
                    cmd.Parameters.Add(JobTitle);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    sql = "Select MAX(JobID) from StaffHistory";
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

        public void Update(StaffHistory h)
        {
            string connString = ConfigurationManager.ConnectionStrings["CLRDBConnection"].ConnectionString;
            string providerName = ConfigurationManager.ConnectionStrings["CLRDBConnection"].ProviderName;
            DbProviderFactory provider = DbProviderFactories.GetFactory(providerName);

            using (DbConnection conn = provider.CreateConnection())
            {
                conn.ConnectionString = connString;

                using (DbCommand cmd = conn.CreateCommand())
                {

                    string sql = "Update StaffHistory SET MemberID = @MemberID, Summer = @Summer, JobTitle = SUBSTRING(@JobTitle, 1, 300) WHERE JobID = @JobID";

                    cmd.CommandText = sql;
                    cmd.CommandType = CommandType.Text;

                    DbParameter MemberID = provider.CreateParameter();
                    MemberID.ParameterName = "@MemberID";
                    MemberID.Value = h.MemberID;
                    cmd.Parameters.Add(MemberID);

                    DbParameter Summer = provider.CreateParameter();
                    Summer.ParameterName = "@Summer";
                    if (h.Summer == 0)
                        Summer.Value = DBNull.Value;
                    else
                        Summer.Value = h.Summer;
                    cmd.Parameters.Add(Summer);

                    DbParameter JobTitle = provider.CreateParameter();
                    JobTitle.ParameterName = "@JobTitle";
                    if (h.JobTitle == "" || h.JobTitle == null)
                        JobTitle.Value = DBNull.Value;
                    else
                        JobTitle.Value = h.JobTitle;
                    cmd.Parameters.Add(JobTitle);

                    DbParameter JobID = provider.CreateParameter();
                    JobID.ParameterName = "@JobID";
                    JobID.Value =  h.JobID;
                    cmd.Parameters.Add(JobID);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    conn.Dispose();
                }
            }
        }
    }
}
