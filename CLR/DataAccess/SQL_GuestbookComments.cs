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
    class SQL_GuestbookComments
    {
        public List<GuestbookComments> GetAll()
        {
            List<GuestbookComments> results = new List<GuestbookComments>();

	        string connString = ConfigurationManager.ConnectionStrings["CLRDBConnection"].ConnectionString;
            string providerName = ConfigurationManager.ConnectionStrings["CLRDBConnection"].ProviderName;
            DbProviderFactory provider = DbProviderFactories.GetFactory(providerName);

            using (DbConnection conn = provider.CreateConnection())
            {
                conn.ConnectionString = connString;

                using (DbCommand cmd = conn.CreateCommand())
                {

                    string sql = "Select * from GuestbookComments";

                    cmd.CommandText = sql;
                    cmd.CommandType = CommandType.Text;

		            conn.Open();

                    using (DbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
			                GuestbookComments temp = new GuestbookComments();

			                temp.isNew = false;
                            temp.GBCommentID = dr.GetInt32(0);
                            if (!dr.IsDBNull(1))
	                            temp.GBID = dr.GetInt32(1);
                            if (!dr.IsDBNull(2))
	                            temp.MemberID = dr.GetInt32(2);
                            if (!dr.IsDBNull(3))
	                            temp.Comment = dr.GetString(3);
                            if (!dr.IsDBNull(4))
	                            temp.DateCreated = dr.GetDateTime(4);

                            results.Add(temp);
                        }
                    }

                    conn.Close();
                    conn.Dispose();
                }
            }

            return results;
        }

        public List<GuestbookComments> GetAllbyGuestbook(int GBID)
        {
            List<GuestbookComments> results = new List<GuestbookComments>();

	        string connString = ConfigurationManager.ConnectionStrings["CLRDBConnection"].ConnectionString;
            string providerName = ConfigurationManager.ConnectionStrings["CLRDBConnection"].ProviderName;
            DbProviderFactory provider = DbProviderFactories.GetFactory(providerName);

            using (DbConnection conn = provider.CreateConnection())
            {
                conn.ConnectionString = connString;

                using (DbCommand cmd = conn.CreateCommand())
                {

                    string sql = "Select * from GuestbookComments where GBID = @ID";

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
			                GuestbookComments temp = new GuestbookComments();

			                temp.isNew = false;
                            temp.GBCommentID = dr.GetInt32(0);
                            if (!dr.IsDBNull(1))
	                            temp.GBID = dr.GetInt32(1);
                            if (!dr.IsDBNull(2))
	                            temp.MemberID = dr.GetInt32(2);
                            if (!dr.IsDBNull(3))
	                            temp.Comment = dr.GetString(3);
                            if (!dr.IsDBNull(4))
	                            temp.DateCreated = dr.GetDateTime(4);

                            results.Add(temp);
                        }
                    }

                    conn.Close();
                    conn.Dispose();
                }
            }

            return results;
        }

        public GuestbookComments GetSingle (int CommentID)
        {
            GuestbookComments temp = new GuestbookComments();

            string connString = ConfigurationManager.ConnectionStrings["CLRDBConnection"].ConnectionString;
            string providerName = ConfigurationManager.ConnectionStrings["CLRDBConnection"].ProviderName;
            DbProviderFactory provider = DbProviderFactories.GetFactory(providerName);

            using (DbConnection conn = provider.CreateConnection())
            {
                conn.ConnectionString = connString;

                using (DbCommand cmd = conn.CreateCommand())
                {

                    string sql = "Select * from GuestbookComments where GBCommentID = @ID";

                    cmd.CommandText = sql;
                    cmd.CommandType = CommandType.Text;

                    DbParameter ID = provider.CreateParameter();
                    ID.ParameterName = "@ID";
                    ID.Value = CommentID;
                    cmd.Parameters.Add(ID);

                    conn.Open();

                    using (DbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            temp.isNew = false;
                            temp.GBCommentID = dr.GetInt32(0);
                            if (!dr.IsDBNull(1))
                                temp.GBID = dr.GetInt32(1);
                            if (!dr.IsDBNull(2))
                                temp.MemberID = dr.GetInt32(2);
                            if (!dr.IsDBNull(3))
                                temp.Comment = dr.GetString(3);
                            if (!dr.IsDBNull(4))
                                temp.DateCreated = dr.GetDateTime(4);
                        }
                    }

                    conn.Close();
                    conn.Dispose();
                }
            }

            return temp;
        }

        public void Delete(int CommentID)
        {
            string connString = ConfigurationManager.ConnectionStrings["CLRDBConnection"].ConnectionString;
            string providerName = ConfigurationManager.ConnectionStrings["CLRDBConnection"].ProviderName;
            DbProviderFactory provider = DbProviderFactories.GetFactory(providerName);

            using (DbConnection conn = provider.CreateConnection())
            {
                conn.ConnectionString = connString;

                using (DbCommand cmd = conn.CreateCommand())
                {

                    string sql = "Delete from GuestbookComments where GBCommentID = @ID";

                    cmd.CommandText = sql;
                    cmd.CommandType = CommandType.Text;

                    DbParameter ID = provider.CreateParameter();
                    ID.ParameterName = "@ID";
                    ID.Value = CommentID;
                    cmd.Parameters.Add(ID);

                    conn.Open();

                    cmd.ExecuteNonQuery();

                    conn.Close();
                    conn.Dispose();
                }
            }
        }

        public void DeleteGB(int GBID)
        {
            string connString = ConfigurationManager.ConnectionStrings["CLRDBConnection"].ConnectionString;
            string providerName = ConfigurationManager.ConnectionStrings["CLRDBConnection"].ProviderName;
            DbProviderFactory provider = DbProviderFactories.GetFactory(providerName);

            using (DbConnection conn = provider.CreateConnection())
            {
                conn.ConnectionString = connString;

                using (DbCommand cmd = conn.CreateCommand())
                {

                    string sql = "Delete from GuestbookComments where GBID = @ID";

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

        public void DeleteMemebers(int MemberID)
        {
            string connString = ConfigurationManager.ConnectionStrings["CLRDBConnection"].ConnectionString;
            string providerName = ConfigurationManager.ConnectionStrings["CLRDBConnection"].ProviderName;
            DbProviderFactory provider = DbProviderFactories.GetFactory(providerName);

            using (DbConnection conn = provider.CreateConnection())
            {
                conn.ConnectionString = connString;

                using (DbCommand cmd = conn.CreateCommand())
                {

                    string sql = "Delete from GuestbookComments where MemberID = @ID";

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

        public int Insert(GuestbookComments m)
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

                    string sql = "Insert into GuestbookComments (GBID, MemberID, Comment, DateCreated) VALUES (@GBID, @MemberID, @Comment, @DateCreated)";

                    cmd.CommandText = sql;
                    cmd.CommandType = CommandType.Text;

                    DbParameter GBID = provider.CreateParameter();
                    GBID.ParameterName = "@GBID";
                    GBID.Value =  m.GBID;
                    cmd.Parameters.Add(GBID);

                    DbParameter MemberID = provider.CreateParameter();
                    MemberID.ParameterName = "@MemberID";
                    MemberID.Value =  m.MemberID;
                    cmd.Parameters.Add(MemberID);

                    DbParameter Comment = provider.CreateParameter();
                    Comment.ParameterName = "@Comment";
                    if (m.Comment  == "" || m.Comment  ==  null)
	                    Comment.Value =  DBNull.Value;
                    else
	                    Comment.Value =  m.Comment;
                    cmd.Parameters.Add(Comment);

                    DbParameter DateCreated = provider.CreateParameter();
                    DateCreated.ParameterName = "@DateCreated";
                    if (m.DateCreated == DateTime.MinValue)
                        DateCreated.Value = DateTime.Now;
                    else
                        DateCreated.Value = m.DateCreated;
                    cmd.Parameters.Add(DateCreated);

                    conn.Open();

                    cmd.ExecuteNonQuery();

                    conn.Close();


                    sql = "Select MAX(GBCommentID) from GuestbookComments";
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

        public void Update(GuestbookComments m)
        {
            string connString = ConfigurationManager.ConnectionStrings["CLRDBConnection"].ConnectionString;
            string providerName = ConfigurationManager.ConnectionStrings["CLRDBConnection"].ProviderName;
            DbProviderFactory provider = DbProviderFactories.GetFactory(providerName);

            using (DbConnection conn = provider.CreateConnection())
            {
                conn.ConnectionString = connString;

                using (DbCommand cmd = conn.CreateCommand())
                {

                    string sql = "Update GuestbookComments SET Comment = @Comment where GBCommentID = @GBCommentID";

                    cmd.CommandText = sql;
                    cmd.CommandType = CommandType.Text;

                    DbParameter GBID = provider.CreateParameter();
                    GBID.ParameterName = "@GBCommentID";
                    GBID.Value =  m.GBCommentID;
                    cmd.Parameters.Add(GBID);

                    DbParameter Comment = provider.CreateParameter();
                    Comment.ParameterName = "@Comment";
                    if (m.Comment  == "" || m.Comment  ==  null)
	                    Comment.Value =  DBNull.Value;
                    else
	                    Comment.Value =  m.Comment;
                    cmd.Parameters.Add(Comment);

                    conn.Open();

                    cmd.ExecuteNonQuery();

                    conn.Close();
                    conn.Dispose();
                }
            }
        
        }
    }
}
