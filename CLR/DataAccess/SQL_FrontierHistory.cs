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
    class SQL_FrontierHistory
    {
        public FrontierHistory GetSingle (int MemberID)
        {
            FrontierHistory temp = new FrontierHistory();

            string connString = ConfigurationManager.ConnectionStrings["CLRDBConnection"].ConnectionString;
            string providerName = ConfigurationManager.ConnectionStrings["CLRDBConnection"].ProviderName;
            DbProviderFactory provider = DbProviderFactories.GetFactory(providerName);

            using (DbConnection conn = provider.CreateConnection())
            {
                conn.ConnectionString = connString;

                using (DbCommand cmd = conn.CreateCommand())
                {

                    string sql = "Select * from FrontierHistory where MemberID = @ID";

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
			     		    temp.isNew = false;
                            temp.MemberID = dr.GetInt32(0);
                            if (!dr.IsDBNull(1))
	                            temp.PioneerYr = dr.GetInt32(1);
                            if (!dr.IsDBNull(2))
	                            temp.PioneerWk = dr.GetInt32(2);
                            if (!dr.IsDBNull(3))
	                            temp.TrapperYr = dr.GetInt32(3);
                            if (!dr.IsDBNull(4))
	                            temp.TrapperWk = dr.GetInt32(4);
                            if (!dr.IsDBNull(5))
	                            temp.MMYr = dr.GetInt32(5);
                            if (!dr.IsDBNull(6))
	                            temp.MMWk = dr.GetInt32(6);
                            if (!dr.IsDBNull(7))
	                            temp.MMClaws = dr.GetString(7);
                            if (!dr.IsDBNull(8))
	                            temp.MMClawsID = dr.GetInt32(8);
                            if (!dr.IsDBNull(9))
	                            temp.MMCeremony = dr.GetString(9);
                            if (!dr.IsDBNull(10))
	                            temp.isMMApproved = dr.GetBoolean(10);
                 
                        }
                    }

                    conn.Close();
                    conn.Dispose();
                }
            }

            return temp;
        }

        public void Delete(int MemberID)
        {
            string connString = ConfigurationManager.ConnectionStrings["CLRDBConnection"].ConnectionString;
            string providerName = ConfigurationManager.ConnectionStrings["CLRDBConnection"].ProviderName;
            DbProviderFactory provider = DbProviderFactories.GetFactory(providerName);

            using (DbConnection conn = provider.CreateConnection())
            {
                conn.ConnectionString = connString;

                using (DbCommand cmd = conn.CreateCommand())
                {

                    string sql = "Delete from FrontierHistory where MemberID = @ID";

                    cmd.CommandText = sql;
                    cmd.CommandType = CommandType.Text;

                    DbParameter ID = provider.CreateParameter();
                    ID.ParameterName = "@ID";
                    ID.Value = MemberID;
                    cmd.Parameters.Add(ID);

                    conn.Open();

                    cmd.ExecuteNonQuery();

                    conn.Close();
                    conn.Dispose();
                }
            }
        }

        public void Insert(FrontierHistory f)
        {
            string connString = ConfigurationManager.ConnectionStrings["CLRDBConnection"].ConnectionString;
            string providerName = ConfigurationManager.ConnectionStrings["CLRDBConnection"].ProviderName;
            DbProviderFactory provider = DbProviderFactories.GetFactory(providerName);

            using (DbConnection conn = provider.CreateConnection())
            {
                conn.ConnectionString = connString;

                using (DbCommand cmd = conn.CreateCommand())
                {

                    string sql = "Insert into FrontierHistory (MemberID, PioneerYr, PioneerWk, TrapperYr, TrapperWk, MMYr, MMWk, MMClaws, MMClawsID, MMCeremony, isMMApproved) " +
                        "VALUES (@MemberID, @PioneerYr, @PioneerWk, @TrapperYr, @TrapperWk, @MMYr, @MMWk, SUBSTRING(@MMClaws, 1, 150), @MMClawsID, SUBSTRING(@MMCeremony, 1, 500), @isMMApproved)";
                    cmd.CommandText = sql;
                    cmd.CommandType = CommandType.Text;

                    DbParameter MemberID = provider.CreateParameter();
                    MemberID.ParameterName = "@MemberID";
                    if (f.MemberID  == 0)
	                    MemberID.Value =  DBNull.Value;
                    else
	                    MemberID.Value =  f.MemberID;
                    cmd.Parameters.Add(MemberID);
                    
                    DbParameter PioneerYr = provider.CreateParameter();
                    PioneerYr.ParameterName = "@PioneerYr";
                    if (f.PioneerYr  == 0)
	                    PioneerYr.Value =  DBNull.Value;
                    else
	                    PioneerYr.Value =  f.PioneerYr;
                    cmd.Parameters.Add(PioneerYr);
                    
                    DbParameter PioneerWk = provider.CreateParameter();
                    PioneerWk.ParameterName = "@PioneerWk";
                    if (f.PioneerWk  == 0)
	                    PioneerWk.Value =  DBNull.Value;
                    else
	                    PioneerWk.Value =  f.PioneerWk;
                    cmd.Parameters.Add(PioneerWk);
                    
                    DbParameter TrapperYr = provider.CreateParameter();
                    TrapperYr.ParameterName = "@TrapperYr";
                    if (f.TrapperYr  == 0)
	                    TrapperYr.Value =  DBNull.Value;
                    else
	                    TrapperYr.Value =  f.TrapperYr;
                    cmd.Parameters.Add(TrapperYr);
                    
                    DbParameter TrapperWk = provider.CreateParameter();
                    TrapperWk.ParameterName = "@TrapperWk";
                    if (f.TrapperWk  == 0)
	                    TrapperWk.Value =  DBNull.Value;
                    else
	                    TrapperWk.Value =  f.TrapperWk;
                    cmd.Parameters.Add(TrapperWk);
                    
                    DbParameter MMYr = provider.CreateParameter();
                    MMYr.ParameterName = "@MMYr";
                    if (f.MMYr  == 0)
	                    MMYr.Value =  DBNull.Value;
                    else
	                    MMYr.Value =  f.MMYr;
                    cmd.Parameters.Add(MMYr);
                    
                    DbParameter MMWk = provider.CreateParameter();
                    MMWk.ParameterName = "@MMWk";
                    if (f.MMWk  == 0)
	                    MMWk.Value =  DBNull.Value;
                    else
	                    MMWk.Value =  f.MMWk;
                    cmd.Parameters.Add(MMWk);
                    
                    DbParameter MMClaws = provider.CreateParameter();
                    MMClaws.ParameterName = "@MMClaws";
                    if (f.MMClaws  == "" || f.MMClaws  ==  null)
	                    MMClaws.Value =  DBNull.Value;
                    else
	                    MMClaws.Value =  f.MMClaws;
                    cmd.Parameters.Add(MMClaws);
                    
                    DbParameter MMClawsID = provider.CreateParameter();
                    MMClawsID.ParameterName = "@MMClawsID";
                    if (f.MMClawsID  == 0)
	                    MMClawsID.Value =  DBNull.Value;
                    else
	                    MMClawsID.Value =  f.MMClawsID;
                    cmd.Parameters.Add(MMClawsID);
                    
                    DbParameter MMCeremony = provider.CreateParameter();
                    MMCeremony.ParameterName = "@MMCeremony";
                    if (f.MMCeremony  == "" || f.MMCeremony == null)
	                    MMCeremony.Value =  DBNull.Value;
                    else
	                    MMCeremony.Value =  f.MMCeremony;
                    cmd.Parameters.Add(MMCeremony);
                    
                    DbParameter isMMApproved = provider.CreateParameter();
                    isMMApproved.ParameterName = "@isMMApproved";
                    isMMApproved.Value =  f.isMMApproved;
                    cmd.Parameters.Add(isMMApproved);

                    conn.Open();

                    cmd.ExecuteNonQuery();

                    conn.Close();
                    conn.Dispose();
                }
            }
        }

        public void Update(FrontierHistory f)
        {
            string connString = ConfigurationManager.ConnectionStrings["CLRDBConnection"].ConnectionString;
            string providerName = ConfigurationManager.ConnectionStrings["CLRDBConnection"].ProviderName;
            DbProviderFactory provider = DbProviderFactories.GetFactory(providerName);

            using (DbConnection conn = provider.CreateConnection())
            {
                conn.ConnectionString = connString;

                using (DbCommand cmd = conn.CreateCommand())
                {

                    string sql = "Update FrontierHistory SET " +
                                    "PioneerYr = @PioneerYr, " +
                                    "PioneerWk = @PioneerWk, " +
                                    "TrapperYr = @TrapperYr, " +
                                    "TrapperWk = @TrapperWk, " +
                                    "MMYr = @MMYr, " +
                                    "MMWk = @MMWk, " +
                                    "MMClaws = SUBSTRING(@MMClaws, 1, 150), " +
                                    "MMClawsID = @MMClawsID, " +
                                    "MMCeremony = SUBSTRING(@MMCeremony, 1, 500), " +
                                    "isMMApproved = @isMMApproved " +
                                    "Where MemberID = @MemberID";

                    cmd.CommandText = sql;
                    cmd.CommandType = CommandType.Text;

                    DbParameter MemberID = provider.CreateParameter();
                    MemberID.ParameterName = "@MemberID";
                    if (f.MemberID == 0)
                        MemberID.Value = DBNull.Value;
                    else
                        MemberID.Value = f.MemberID;
                    cmd.Parameters.Add(MemberID);

                    DbParameter PioneerYr = provider.CreateParameter();
                    PioneerYr.ParameterName = "@PioneerYr";
                    if (f.PioneerYr == 0)
                        PioneerYr.Value = DBNull.Value;
                    else
                        PioneerYr.Value = f.PioneerYr;
                    cmd.Parameters.Add(PioneerYr);

                    DbParameter PioneerWk = provider.CreateParameter();
                    PioneerWk.ParameterName = "@PioneerWk";
                    if (f.PioneerWk == 0)
                        PioneerWk.Value = DBNull.Value;
                    else
                        PioneerWk.Value = f.PioneerWk;
                    cmd.Parameters.Add(PioneerWk);

                    DbParameter TrapperYr = provider.CreateParameter();
                    TrapperYr.ParameterName = "@TrapperYr";
                    if (f.TrapperYr == 0)
                        TrapperYr.Value = DBNull.Value;
                    else
                        TrapperYr.Value = f.TrapperYr;
                    cmd.Parameters.Add(TrapperYr);

                    DbParameter TrapperWk = provider.CreateParameter();
                    TrapperWk.ParameterName = "@TrapperWk";
                    if (f.TrapperWk == 0)
                        TrapperWk.Value = DBNull.Value;
                    else
                        TrapperWk.Value = f.TrapperWk;
                    cmd.Parameters.Add(TrapperWk);

                    DbParameter MMYr = provider.CreateParameter();
                    MMYr.ParameterName = "@MMYr";
                    if (f.MMYr == 0)
                        MMYr.Value = DBNull.Value;
                    else
                        MMYr.Value = f.MMYr;
                    cmd.Parameters.Add(MMYr);

                    DbParameter MMWk = provider.CreateParameter();
                    MMWk.ParameterName = "@MMWk";
                    if (f.MMWk == 0)
                        MMWk.Value = DBNull.Value;
                    else
                        MMWk.Value = f.MMWk;
                    cmd.Parameters.Add(MMWk);

                    DbParameter MMClaws = provider.CreateParameter();
                    MMClaws.ParameterName = "@MMClaws";
                    if (f.MMClaws == "" || f.MMClaws == null)
                        MMClaws.Value = DBNull.Value;
                    else
                        MMClaws.Value = f.MMClaws;
                    cmd.Parameters.Add(MMClaws);

                    DbParameter MMClawsID = provider.CreateParameter();
                    MMClawsID.ParameterName = "@MMClawsID";
                    if (f.MMClawsID == 0)
                        MMClawsID.Value = DBNull.Value;
                    else
                        MMClawsID.Value = f.MMClawsID;
                    cmd.Parameters.Add(MMClawsID);

                    DbParameter MMCeremony = provider.CreateParameter();
                    MMCeremony.ParameterName = "@MMCeremony";
                    if (f.MMCeremony == "" || f.MMCeremony == null)
                        MMCeremony.Value = DBNull.Value;
                    else
                        MMCeremony.Value = f.MMCeremony;
                    cmd.Parameters.Add(MMCeremony);

                    DbParameter isMMApproved = provider.CreateParameter();
                    isMMApproved.ParameterName = "@isMMApproved";
                    isMMApproved.Value = f.isMMApproved;
                    cmd.Parameters.Add(isMMApproved);

                    conn.Open();

                    cmd.ExecuteNonQuery();

                    conn.Close();
                    conn.Dispose();
                }
            }
        }
    }
}
