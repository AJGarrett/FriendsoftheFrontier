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
    class SQL_CLRSAADues
    {
        public List<CLRSAADues> GetAll(int MemberID)
        {
            List<CLRSAADues> results = new List<CLRSAADues>();
            string connString = ConfigurationManager.ConnectionStrings["CLRDBConnection"].ConnectionString;
            string providerName = ConfigurationManager.ConnectionStrings["CLRDBConnection"].ProviderName;
            DbProviderFactory provider = DbProviderFactories.GetFactory(providerName);

            using (DbConnection conn = provider.CreateConnection())
            {
                conn.ConnectionString = connString;

                using (DbCommand cmd = conn.CreateCommand())
                {

                    string sql = "Select * from CLRSAADues where MemberID = @ID";

                    cmd.CommandText = sql;
                    cmd.CommandType = CommandType.Text;

                    DbParameter ID = provider.CreateParameter();
                    ID.ParameterName = "@ID";
                    ID.Value = MemberID;
                    cmd.Parameters.Add(ID);

                    conn.Open();

                    using (DbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            CLRSAADues temp = new CLRSAADues(); 
                            temp.isNew = false;
                            temp.DuesID = dr.GetInt32(0);
                            temp.MemberID = dr.GetInt32(1);
                            if (!dr.IsDBNull(2))
                                temp.DatePaid = dr.GetDateTime(2);
                            if (!dr.IsDBNull(3))
                                temp.Amount = dr.GetDecimal(3);
                            if (!dr.IsDBNull(4))
                                temp.DateExpires = dr.GetDateTime(4);

                            results.Add(temp);
                        }
                    }

                    conn.Close();
                    conn.Dispose();
                }
            }
            return results;
        }
        
        public CLRSAADues GetSingle(int DuesID)
        {
            CLRSAADues temp = new CLRSAADues();
            string connString = ConfigurationManager.ConnectionStrings["CLRDBConnection"].ConnectionString;
            string providerName = ConfigurationManager.ConnectionStrings["CLRDBConnection"].ProviderName;
            DbProviderFactory provider = DbProviderFactories.GetFactory(providerName);

            using (DbConnection conn = provider.CreateConnection())
            {
                conn.ConnectionString = connString;

                using (DbCommand cmd = conn.CreateCommand())
                {

                    string sql = "Select * from CLRSAADues where DuesID = @ID";

                    cmd.CommandText = sql;
                    cmd.CommandType = CommandType.Text;

                    DbParameter ID = provider.CreateParameter();
                    ID.ParameterName = "@ID";
                    ID.Value = DuesID;
                    cmd.Parameters.Add(ID);

		            conn.Open();

                    using (DbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
			                temp.isNew = false;
                            temp.DuesID = dr.GetInt32(0);
                            temp.MemberID = dr.GetInt32(1);
                            if (!dr.IsDBNull(2))
	                            temp.DatePaid = dr.GetDateTime(2);
                            if (!dr.IsDBNull(3))
	                            temp.Amount = dr.GetDecimal(3);
                            if (!dr.IsDBNull(4))
	                            temp.DateExpires = dr.GetDateTime(4);
                        }
                    }

                    conn.Close();
                    conn.Dispose();
                }
            }
            return temp;
        }

        public void Delete(int DuesID)
        {
            string connString = ConfigurationManager.ConnectionStrings["CLRDBConnection"].ConnectionString;
            string providerName = ConfigurationManager.ConnectionStrings["CLRDBConnection"].ProviderName;
            DbProviderFactory provider = DbProviderFactories.GetFactory(providerName);

            using (DbConnection conn = provider.CreateConnection())
            {
                conn.ConnectionString = connString;

                using (DbCommand cmd = conn.CreateCommand())
                {

                    string sql = "Delete from CLRSAADues where DuesID = @MemberID";

                    cmd.CommandText = sql;
                    cmd.CommandType = CommandType.Text;

                    DbParameter ID = provider.CreateParameter();
                    ID.ParameterName = "@ID";
                    ID.Value = DuesID;
                    cmd.Parameters.Add(ID);

                    conn.Open();

                    cmd.ExecuteNonQuery();

                    conn.Close();
                    conn.Dispose();
                }
            }
        }

        public int Insert(CLRSAADues d)
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

                    string sql = "Insert into CLRSAADues (MemberID, DatePaid, Amount, DateExpires) VALUES (@MemberID, @DatePaid, @Amount, @DateExpires)";

                    cmd.CommandText = sql;
                    cmd.CommandType = CommandType.Text;

                    DbParameter MemberID = provider.CreateParameter();
                    MemberID.ParameterName = "@MemberID";
                    MemberID.Value =  d.MemberID;
                    cmd.Parameters.Add(MemberID);
                    
                    DbParameter DatePaid = provider.CreateParameter();
                    DatePaid.ParameterName = "@DatePaid";
                    if (d.DatePaid  == DateTime.MinValue)
	                    DatePaid.Value =  DBNull.Value;
                    else
	                    DatePaid.Value =  d.DatePaid;
                    cmd.Parameters.Add(DatePaid);
                    
                    DbParameter Amount = provider.CreateParameter();
                    Amount.ParameterName = "@Amount";
                    if (d.Amount  == 0)
	                    Amount.Value =  DBNull.Value;
                    else
	                    Amount.Value =  d.Amount;
                    cmd.Parameters.Add(Amount);
                    
                    DbParameter DateExpires = provider.CreateParameter();
                    DateExpires.ParameterName = "@DateExpires";
                    if (d.DateExpires  == DateTime.MinValue)
	                    DateExpires.Value =  DBNull.Value;
                    else
	                    DateExpires.Value =  d.DateExpires;
                    cmd.Parameters.Add(DateExpires);

                    conn.Open();

                    cmd.ExecuteNonQuery();

                    conn.Close();

                    sql = "Select MAX(GBID) from CLRSAADues";
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

        public void Update(CLRSAADues d)
        {
            string connString = ConfigurationManager.ConnectionStrings["CLRDBConnection"].ConnectionString;
            string providerName = ConfigurationManager.ConnectionStrings["CLRDBConnection"].ProviderName;
            DbProviderFactory provider = DbProviderFactories.GetFactory(providerName);

            using (DbConnection conn = provider.CreateConnection())
            {
                conn.ConnectionString = connString;

                using (DbCommand cmd = conn.CreateCommand())
                {

                    string sql = "Update CLRSAADues SET MemberID = @MemberID, " +
                                    "DatePaid = @DatePaid, " +
                                    "Amount = @Amount, " +
                                    "DateExpires = @DateExpires WHERE DuesID = @DuesID";

                    cmd.CommandText = sql;
                    cmd.CommandType = CommandType.Text;

                    DbParameter DuesID = provider.CreateParameter();
                    DuesID.ParameterName = "@DuesID";
                    DuesID.Value = d.DuesID;
                    cmd.Parameters.Add(DuesID);
                    
                    DbParameter MemberID = provider.CreateParameter();
                    MemberID.ParameterName = "@MemberID";
                    MemberID.Value = d.MemberID;
                    cmd.Parameters.Add(MemberID);

                    DbParameter DatePaid = provider.CreateParameter();
                    DatePaid.ParameterName = "@DatePaid";
                    if (d.DatePaid == DateTime.MinValue)
                        DatePaid.Value = DBNull.Value;
                    else
                        DatePaid.Value = d.DatePaid;
                    cmd.Parameters.Add(DatePaid);

                    DbParameter Amount = provider.CreateParameter();
                    Amount.ParameterName = "@Amount";
                    if (d.Amount == 0)
                        Amount.Value = DBNull.Value;
                    else
                        Amount.Value = d.Amount;
                    cmd.Parameters.Add(Amount);

                    DbParameter DateExpires = provider.CreateParameter();
                    DateExpires.ParameterName = "@DateExpires";
                    if (d.DateExpires == DateTime.MinValue)
                        DateExpires.Value = DBNull.Value;
                    else
                        DateExpires.Value = d.DateExpires;
                    cmd.Parameters.Add(DateExpires);

                    conn.Open();

                    cmd.ExecuteNonQuery();

                    conn.Close();
                    conn.Dispose();
                }
            }
        }
    }
}
