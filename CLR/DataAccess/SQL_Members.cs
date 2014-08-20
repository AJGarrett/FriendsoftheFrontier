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
    class SQL_Members
    {
        public List<Members> GetAll()
        {
            List<Members> results = new List<Members>();

	        string connString = ConfigurationManager.ConnectionStrings["CLRDBConnection"].ConnectionString;
            string providerName = ConfigurationManager.ConnectionStrings["CLRDBConnection"].ProviderName;
            DbProviderFactory provider = DbProviderFactories.GetFactory(providerName);

            using (DbConnection conn = provider.CreateConnection())
            {
                conn.ConnectionString = connString;

                using (DbCommand cmd = conn.CreateCommand())
                {

                    string sql = "Select * from Members";

                    cmd.CommandText = sql;
                    cmd.CommandType = CommandType.Text;

		            conn.Open();

                    using (DbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
			                Members temp = new Members();

			                temp.isNew = false;
                            temp.MemberID = dr.GetInt32(0);
                            if (!dr.IsDBNull(1))
	                            temp.FirstName = dr.GetString(1);
                            if (!dr.IsDBNull(2))
	                            temp.LastName = dr.GetString(2);
                            if (!dr.IsDBNull(3))
	                            temp.Email = dr.GetString(3);
                            if (!dr.IsDBNull(4))
	                            temp.Nickname = dr.GetString(4);
                            if (!dr.IsDBNull(5))
	                            temp.CurrentTroop = dr.GetString(5);
                            if (!dr.IsDBNull(6))
	                            temp.FormerTroop = dr.GetString(6);
                            if (!dr.IsDBNull(7))
	                            temp.Address = dr.GetString(7);
                            if (!dr.IsDBNull(8))
	                            temp.City = dr.GetString(8);
                            if (!dr.IsDBNull(9))
	                            temp.State = dr.GetString(9);
                            if (!dr.IsDBNull(10))
	                            temp.ZipCode = dr.GetString(10);
                            if (!dr.IsDBNull(11))
	                            temp.Birthday = dr.GetDateTime(11);
                            if (!dr.IsDBNull(12))
	                            temp.HighestRank = dr.GetString(12);
                            if (!dr.IsDBNull(13))
	                            temp.Comments = dr.GetString(13);
                            if (!dr.IsDBNull(14))
	                            temp.isBadEmail = dr.GetBoolean(14);
                            if (!dr.IsDBNull(15))
	                            temp.Website = dr.GetString(15);
                            if (!dr.IsDBNull(16))
	                            temp.Facebook = dr.GetString(16);
                            if (!dr.IsDBNull(17))
	                            temp.Twitter = dr.GetString(17);
                            if (!dr.IsDBNull(18))
	                            temp.isAlumni = dr.GetBoolean(18);
                            if (!dr.IsDBNull(19))
	                            temp.isFrontiersman = dr.GetBoolean(19);
                            if (!dr.IsDBNull(20))
	                            temp.dateCreated = dr.GetDateTime(20);
                            if (!dr.IsDBNull(21))
	                            temp.dateModified = dr.GetDateTime(21);
                            if (!dr.IsDBNull(22))
                                temp.image = dr.GetString(22);
                            else
                                temp.image = "none.jpg";

                            results.Add(temp);
                        }
                    }

                    conn.Close();
                    conn.Dispose();
                }
            }

            return results;
        }

        public Members GetSingle (int MemberID)
        {
            Members temp = new Members();

            string connString = ConfigurationManager.ConnectionStrings["CLRDBConnection"].ConnectionString;
            string providerName = ConfigurationManager.ConnectionStrings["CLRDBConnection"].ProviderName;
            DbProviderFactory provider = DbProviderFactories.GetFactory(providerName);

            using (DbConnection conn = provider.CreateConnection())
            {
                conn.ConnectionString = connString;

                using (DbCommand cmd = conn.CreateCommand())
                {

                    string sql = "Select * from Members where MemberID = @ID "; 

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
                                temp.FirstName = dr.GetString(1);
                            if (!dr.IsDBNull(2))
                                temp.LastName = dr.GetString(2);
                            if (!dr.IsDBNull(3))
                                temp.Email = dr.GetString(3);
                            if (!dr.IsDBNull(4))
                                temp.Nickname = dr.GetString(4);
                            if (!dr.IsDBNull(5))
                                temp.CurrentTroop = dr.GetString(5);
                            if (!dr.IsDBNull(6))
                                temp.FormerTroop = dr.GetString(6);
                            if (!dr.IsDBNull(7))
                                temp.Address = dr.GetString(7);
                            if (!dr.IsDBNull(8))
                                temp.City = dr.GetString(8);
                            if (!dr.IsDBNull(9))
                                temp.State = dr.GetString(9);
                            if (!dr.IsDBNull(10))
                                temp.ZipCode = dr.GetString(10);
                            if (!dr.IsDBNull(11))
                                temp.Birthday = dr.GetDateTime(11);
                            if (!dr.IsDBNull(12))
                                temp.HighestRank = dr.GetString(12);
                            if (!dr.IsDBNull(13))
                                temp.Comments = dr.GetString(13);
                            if (!dr.IsDBNull(14))
                                temp.isBadEmail = dr.GetBoolean(14);
                            if (!dr.IsDBNull(15))
                                temp.Website = dr.GetString(15);
                            if (!dr.IsDBNull(16))
                                temp.Facebook = dr.GetString(16);
                            if (!dr.IsDBNull(17))
                                temp.Twitter = dr.GetString(17);
                            if (!dr.IsDBNull(18))
                                temp.isAlumni = dr.GetBoolean(18);
                            if (!dr.IsDBNull(19))
                                temp.isFrontiersman = dr.GetBoolean(19);
                            if (!dr.IsDBNull(20))
                                temp.dateCreated = dr.GetDateTime(20);
                            if (!dr.IsDBNull(21))
                                temp.dateModified = dr.GetDateTime(21);
                            if (!dr.IsDBNull(22))
                                temp.image = dr.GetString(22);
                            else
                                temp.image = "none.jpg";
                        }
                    }

                    conn.Close();
                    conn.Dispose();
                }
            }

            return temp;
        }

        public Members GetSingle(string Email)
        {
            Members temp = new Members();

            string connString = ConfigurationManager.ConnectionStrings["CLRDBConnection"].ConnectionString;
            string providerName = ConfigurationManager.ConnectionStrings["CLRDBConnection"].ProviderName;
            DbProviderFactory provider = DbProviderFactories.GetFactory(providerName);

            using (DbConnection conn = provider.CreateConnection())
            {
                conn.ConnectionString = connString;

                using (DbCommand cmd = conn.CreateCommand())
                {

                    string sql = "Select * from Members where Email = @ID ";

                    cmd.CommandText = sql;
                    cmd.CommandType = CommandType.Text;

                    DbParameter ID = provider.CreateParameter();
                    ID.ParameterName = "@ID";
                    ID.Value = Email;
                    cmd.Parameters.Add(ID);

                    conn.Open();

                    using (DbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            temp.isNew = false;
                            temp.MemberID = dr.GetInt32(0);
                            if (!dr.IsDBNull(1))
                                temp.FirstName = dr.GetString(1);
                            if (!dr.IsDBNull(2))
                                temp.LastName = dr.GetString(2);
                            if (!dr.IsDBNull(3))
                                temp.Email = dr.GetString(3);
                            if (!dr.IsDBNull(4))
                                temp.Nickname = dr.GetString(4);
                            if (!dr.IsDBNull(5))
                                temp.CurrentTroop = dr.GetString(5);
                            if (!dr.IsDBNull(6))
                                temp.FormerTroop = dr.GetString(6);
                            if (!dr.IsDBNull(7))
                                temp.Address = dr.GetString(7);
                            if (!dr.IsDBNull(8))
                                temp.City = dr.GetString(8);
                            if (!dr.IsDBNull(9))
                                temp.State = dr.GetString(9);
                            if (!dr.IsDBNull(10))
                                temp.ZipCode = dr.GetString(10);
                            if (!dr.IsDBNull(11))
                                temp.Birthday = dr.GetDateTime(11);
                            if (!dr.IsDBNull(12))
                                temp.HighestRank = dr.GetString(12);
                            if (!dr.IsDBNull(13))
                                temp.Comments = dr.GetString(13);
                            if (!dr.IsDBNull(14))
                                temp.isBadEmail = dr.GetBoolean(14);
                            if (!dr.IsDBNull(15))
                                temp.Website = dr.GetString(15);
                            if (!dr.IsDBNull(16))
                                temp.Facebook = dr.GetString(16);
                            if (!dr.IsDBNull(17))
                                temp.Twitter = dr.GetString(17);
                            if (!dr.IsDBNull(18))
                                temp.isAlumni = dr.GetBoolean(18);
                            if (!dr.IsDBNull(19))
                                temp.isFrontiersman = dr.GetBoolean(19);
                            if (!dr.IsDBNull(20))
                                temp.dateCreated = dr.GetDateTime(20);
                            if (!dr.IsDBNull(21))
                                temp.dateModified = dr.GetDateTime(21);
                            if (!dr.IsDBNull(22))
                                temp.image = dr.GetString(22);
                            else
                                temp.image = "none.jpg";
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

                    string sql = "Delete from Members where MemberID = @ID ";

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

        public int Insert(Members m)
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

                    string sql = "Insert into Members (FirstName, LastName, Email, Nickname, CurrentTroop, FormerTroop, Address, City, " +
                        "State, ZipCode, Birthday, HighestRank, Comments, isBadEmail, Website, Facebook, Twitter, isAlumni, isFrontiersman, dateCreated, dateModified, image) " +
                        "Values (SUBSTRING(@FirstName, 1, 150), SUBSTRING(@LastName, 1, 150), SUBSTRING(@Email, 1, 250), SUBSTRING(@Nickname, 1, 150), SUBSTRING(@CurrentTroop, 1, 150), " +
                        "SUBSTRING(@FormerTroop, 1, 150), SUBSTRING(@Address, 1, 150), SUBSTRING(@City, 1, 150), SUBSTRING(@State, 1, 10), SUBSTRING(@ZipCode, 1, 10), @Birthday, SUBSTRING(@HighestRank, 1, 50), " +
                        "@Comments, @isBadEmail, SUBSTRING(@Website, 1, 500),  SUBSTRING(@Facebook, 1, 500), SUBSTRING(@Twitter, 1, 500), @isAlumni, @isFrontiersman, @dateCreated, @dateModified, Substring(@image, 1, 50))";

                    cmd.CommandText = sql;
                    cmd.CommandType = CommandType.Text;

                    DbParameter FirstName = provider.CreateParameter();
                    FirstName.ParameterName = "@FirstName";
                    if (m.FirstName  == "" || m.FirstName  ==  null)
	                    FirstName.Value =  DBNull.Value;
                    else
	                    FirstName.Value =  m.FirstName;
                    cmd.Parameters.Add(FirstName);

                    DbParameter LastName = provider.CreateParameter();
                    LastName.ParameterName = "@LastName";
                    if (m.LastName  == "" || m.LastName  ==  null)
	                    LastName.Value =  DBNull.Value;
                    else
	                    LastName.Value =  m.LastName;
                    cmd.Parameters.Add(LastName);
                    
                    DbParameter Email = provider.CreateParameter();
                    Email.ParameterName = "@Email";
                    if (m.Email  == "" || m.Email  ==  null)
	                    Email.Value =  DBNull.Value;
                    else
	                    Email.Value =  m.Email;
                    cmd.Parameters.Add(Email);
                    
                    DbParameter Nickname = provider.CreateParameter();
                    Nickname.ParameterName = "@Nickname";
                    if (m.Nickname  == "" || m.Nickname  ==  null)
	                    Nickname.Value =  DBNull.Value;
                    else
	                    Nickname.Value =  m.Nickname;
                    cmd.Parameters.Add(Nickname);
                    
                    DbParameter CurrentTroop = provider.CreateParameter();
                    CurrentTroop.ParameterName = "@CurrentTroop";
                    if (m.CurrentTroop  == "" || m.CurrentTroop  ==  null)
	                    CurrentTroop.Value =  DBNull.Value;
                    else
	                    CurrentTroop.Value =  m.CurrentTroop;
                    cmd.Parameters.Add(CurrentTroop);
                    
                    DbParameter FormerTroop = provider.CreateParameter();
                    FormerTroop.ParameterName = "@FormerTroop";
                    if (m.FormerTroop  == "" || m.FormerTroop  ==  null)
	                    FormerTroop.Value =  DBNull.Value;
                    else
	                    FormerTroop.Value =  m.FormerTroop;
                    cmd.Parameters.Add(FormerTroop);
                    
                    DbParameter Address = provider.CreateParameter();
                    Address.ParameterName = "@Address";
                    if (m.Address  == "" || m.Address  ==  null)
	                    Address.Value =  DBNull.Value;
                    else
	                    Address.Value =  m.Address;
                    cmd.Parameters.Add(Address);
                    
                    DbParameter City = provider.CreateParameter();
                    City.ParameterName = "@City";
                    if (m.City  == "" || m.City  ==  null)
	                    City.Value =  DBNull.Value;
                    else
	                    City.Value =  m.City;
                    cmd.Parameters.Add(City);
                    
                    DbParameter State = provider.CreateParameter();
                    State.ParameterName = "@State";
                    if (m.State  == "" || m.State  ==  null)
	                    State.Value =  DBNull.Value;
                    else
	                    State.Value =  m.State;
                    cmd.Parameters.Add(State);
                    
                    DbParameter ZipCode = provider.CreateParameter();
                    ZipCode.ParameterName = "@ZipCode";
                    if (m.ZipCode  == "" || m.ZipCode  ==  null)
	                    ZipCode.Value =  DBNull.Value;
                    else
	                    ZipCode.Value =  m.ZipCode;
                    cmd.Parameters.Add(ZipCode);
                    
                    DbParameter Birthday = provider.CreateParameter();
                    Birthday.ParameterName = "@Birthday";
                    if (m.Birthday  == DateTime.MinValue)
	                    Birthday.Value =  DBNull.Value;
                    else
	                    Birthday.Value =  m.Birthday;
                    cmd.Parameters.Add(Birthday);
                    
                    DbParameter HighestRank = provider.CreateParameter();
                    HighestRank.ParameterName = "@HighestRank";
                    if (m.HighestRank  == "" || m.HighestRank  ==  null)
	                    HighestRank.Value =  DBNull.Value;
                    else
	                    HighestRank.Value =  m.HighestRank;
                    cmd.Parameters.Add(HighestRank);
                    
                    DbParameter Comments = provider.CreateParameter();
                    Comments.ParameterName = "@Comments";
                    if (m.Comments  == "" || m.Comments  ==  null)
	                    Comments.Value =  DBNull.Value;
                    else
	                    Comments.Value =  m.Comments;
                    cmd.Parameters.Add(Comments);
                    
                    DbParameter isBadEmail = provider.CreateParameter();
                    isBadEmail.ParameterName = "@isBadEmail";
                    if (!m.isBadEmail)
	                    isBadEmail.Value =  DBNull.Value;
                    else
	                    isBadEmail.Value =  m.isBadEmail;
                    cmd.Parameters.Add(isBadEmail);
                    
                    DbParameter Website = provider.CreateParameter();
                    Website.ParameterName = "@Website";
                    if (m.Website  == "" || m.Website  ==  null)
	                    Website.Value =  DBNull.Value;
                    else
	                    Website.Value =  m.Website;
                    cmd.Parameters.Add(Website);
                    
                    DbParameter Facebook = provider.CreateParameter();
                    Facebook.ParameterName = "@Facebook";
                    if (m.Facebook  == "" || m.Facebook  ==  null)
	                    Facebook.Value =  DBNull.Value;
                    else
	                    Facebook.Value =  m.Facebook;
                    cmd.Parameters.Add(Facebook);
                    
                    DbParameter Twitter = provider.CreateParameter();
                    Twitter.ParameterName = "@Twitter";
                    if (m.Twitter  == "" || m.Twitter  ==  null)
	                    Twitter.Value =  DBNull.Value;
                    else
	                    Twitter.Value =  m.Twitter;
                    cmd.Parameters.Add(Twitter);
                    
                    DbParameter isAlumni = provider.CreateParameter();
                    isAlumni.ParameterName = "@isAlumni";
                    if (!m.isAlumni)
	                    isAlumni.Value =  DBNull.Value;
                    else
	                    isAlumni.Value =  m.isAlumni;
                    cmd.Parameters.Add(isAlumni);
                    
                    DbParameter isFrontiersman = provider.CreateParameter();
                    isFrontiersman.ParameterName = "@isFrontiersman";
                    if (!m.isFrontiersman)
	                    isFrontiersman.Value =  DBNull.Value;
                    else
	                    isFrontiersman.Value =  m.isFrontiersman;
                    cmd.Parameters.Add(isFrontiersman);
                    
                    DbParameter dateCreated = provider.CreateParameter();
                    dateCreated.ParameterName = "@dateCreated";
                    dateCreated.Value = DateTime.Now;
                    cmd.Parameters.Add(dateCreated);
                    
                    DbParameter dateModified = provider.CreateParameter();
                    dateModified.ParameterName = "@dateModified";
                    dateModified.Value = DateTime.Now;
                    cmd.Parameters.Add(dateModified);

                    DbParameter image = provider.CreateParameter();
                    image.ParameterName = "@image";
                    if (m.image == "" || m.image == null)
                        image.Value = DBNull.Value;
                    else
                        image.Value = m.image;
                    cmd.Parameters.Add(image);
                    
                    
                    conn.Open();

                    cmd.ExecuteNonQuery();

                    conn.Close();

                    sql = "Select MAX(MemberID) from Members";
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

        public void Update(Members m)
        {
            string connString = ConfigurationManager.ConnectionStrings["CLRDBConnection"].ConnectionString;
            string providerName = ConfigurationManager.ConnectionStrings["CLRDBConnection"].ProviderName;
            DbProviderFactory provider = DbProviderFactories.GetFactory(providerName);

            using (DbConnection conn = provider.CreateConnection())
            {
                conn.ConnectionString = connString;

                using (DbCommand cmd = conn.CreateCommand())
                {

                    string sql = "Update Members SET FirstName = SUBSTRING(@FirstName, 1, 150), " +
                        "LastName = SUBSTRING(@LastName, 1, 150), " +
                        "Email = SUBSTRING(@Email, 1, 250), " +
                        "Nickname = SUBSTRING(@Nickname, 1, 150), " +
                        "CurrentTroop = SUBSTRING(@CurrentTroop, 1, 150), " +
                        "FormerTroop = SUBSTRING(@FormerTroop, 1, 150), " +
                        "Address = SUBSTRING(@Address, 1, 150), " +
                        "City = SUBSTRING(@City, 1, 150), " +
                        "State = SUBSTRING(@State, 1, 10), " +
                        "ZipCode = SUBSTRING(@ZipCode, 1, 10), " +
                        "Birthday = @Birthday, " +
                        "HighestRank = SUBSTRING(@HighestRank, 1, 50), " +
                        "Comments = @Comments, " +
                        "isBadEmail = @isBadEmail, " +
                        "Website = SUBSTRING(@Website, 1, 500), " +
                        "Facebook = SUBSTRING(@Facebook, 1, 500), " +
                        "Twitter = SUBSTRING(@Twitter, 1, 500), " +
                        "isAlumni = @isAlumni, " +
                        "isFrontiersman = @isFrontiersman, " +
                        "dateModified = @dateModified, image=SUBSTRING(@image, 1, 50) WHERE MemberID = @MemberID";

                    cmd.CommandText = sql;
                    cmd.CommandType = CommandType.Text;

                    DbParameter FirstName = provider.CreateParameter();
                    FirstName.ParameterName = "@FirstName";
                    if (m.FirstName == "" || m.FirstName == null)
                        FirstName.Value = DBNull.Value;
                    else
                        FirstName.Value = m.FirstName;
                    cmd.Parameters.Add(FirstName);

                    DbParameter LastName = provider.CreateParameter();
                    LastName.ParameterName = "@LastName";
                    if (m.LastName == "" || m.LastName == null)
                        LastName.Value = DBNull.Value;
                    else
                        LastName.Value = m.LastName;
                    cmd.Parameters.Add(LastName);

                    DbParameter Email = provider.CreateParameter();
                    Email.ParameterName = "@Email";
                    if (m.Email == "" || m.Email == null)
                        Email.Value = DBNull.Value;
                    else
                        Email.Value = m.Email;
                    cmd.Parameters.Add(Email);

                    DbParameter Nickname = provider.CreateParameter();
                    Nickname.ParameterName = "@Nickname";
                    if (m.Nickname == "" || m.Nickname == null)
                        Nickname.Value = DBNull.Value;
                    else
                        Nickname.Value = m.Nickname;
                    cmd.Parameters.Add(Nickname);

                    DbParameter CurrentTroop = provider.CreateParameter();
                    CurrentTroop.ParameterName = "@CurrentTroop";
                    if (m.CurrentTroop == "" || m.CurrentTroop == null)
                        CurrentTroop.Value = DBNull.Value;
                    else
                        CurrentTroop.Value = m.CurrentTroop;
                    cmd.Parameters.Add(CurrentTroop);

                    DbParameter FormerTroop = provider.CreateParameter();
                    FormerTroop.ParameterName = "@FormerTroop";
                    if (m.FormerTroop == "" || m.FormerTroop == null)
                        FormerTroop.Value = DBNull.Value;
                    else
                        FormerTroop.Value = m.FormerTroop;
                    cmd.Parameters.Add(FormerTroop);

                    DbParameter Address = provider.CreateParameter();
                    Address.ParameterName = "@Address";
                    if (m.Address == "" || m.Address == null)
                        Address.Value = DBNull.Value;
                    else
                        Address.Value = m.Address;
                    cmd.Parameters.Add(Address);

                    DbParameter City = provider.CreateParameter();
                    City.ParameterName = "@City";
                    if (m.City == "" || m.City == null)
                        City.Value = DBNull.Value;
                    else
                        City.Value = m.City;
                    cmd.Parameters.Add(City);

                    DbParameter State = provider.CreateParameter();
                    State.ParameterName = "@State";
                    if (m.State == "" || m.State == null)
                        State.Value = DBNull.Value;
                    else
                        State.Value = m.State;
                    cmd.Parameters.Add(State);

                    DbParameter ZipCode = provider.CreateParameter();
                    ZipCode.ParameterName = "@ZipCode";
                    if (m.ZipCode == "" || m.ZipCode == null)
                        ZipCode.Value = DBNull.Value;
                    else
                        ZipCode.Value = m.ZipCode;
                    cmd.Parameters.Add(ZipCode);

                    DbParameter Birthday = provider.CreateParameter();
                    Birthday.ParameterName = "@Birthday";
                    if (m.Birthday == DateTime.MinValue)
                        Birthday.Value = DBNull.Value;
                    else
                        Birthday.Value = m.Birthday;
                    cmd.Parameters.Add(Birthday);

                    DbParameter HighestRank = provider.CreateParameter();
                    HighestRank.ParameterName = "@HighestRank";
                    if (m.HighestRank == "" || m.HighestRank == null)
                        HighestRank.Value = DBNull.Value;
                    else
                        HighestRank.Value = m.HighestRank;
                    cmd.Parameters.Add(HighestRank);

                    DbParameter Comments = provider.CreateParameter();
                    Comments.ParameterName = "@Comments";
                    if (m.Comments == "" || m.Comments == null)
                        Comments.Value = DBNull.Value;
                    else
                        Comments.Value = m.Comments;
                    cmd.Parameters.Add(Comments);

                    DbParameter isBadEmail = provider.CreateParameter();
                    isBadEmail.ParameterName = "@isBadEmail";
                    if (!m.isBadEmail)
                        isBadEmail.Value = DBNull.Value;
                    else
                        isBadEmail.Value = m.isBadEmail;
                    cmd.Parameters.Add(isBadEmail);

                    DbParameter Website = provider.CreateParameter();
                    Website.ParameterName = "@Website";
                    if (m.Website == "" || m.Website == null)
                        Website.Value = DBNull.Value;
                    else
                        Website.Value = m.Website;
                    cmd.Parameters.Add(Website);

                    DbParameter Facebook = provider.CreateParameter();
                    Facebook.ParameterName = "@Facebook";
                    if (m.Facebook == "" || m.Facebook == null)
                        Facebook.Value = DBNull.Value;
                    else
                        Facebook.Value = m.Facebook;
                    cmd.Parameters.Add(Facebook);

                    DbParameter Twitter = provider.CreateParameter();
                    Twitter.ParameterName = "@Twitter";
                    if (m.Twitter == "" || m.Twitter == null)
                        Twitter.Value = DBNull.Value;
                    else
                        Twitter.Value = m.Twitter;
                    cmd.Parameters.Add(Twitter);

                    DbParameter isAlumni = provider.CreateParameter();
                    isAlumni.ParameterName = "@isAlumni";
                    if (!m.isAlumni)
                        isAlumni.Value = DBNull.Value;
                    else
                        isAlumni.Value = m.isAlumni;
                    cmd.Parameters.Add(isAlumni);

                    DbParameter isFrontiersman = provider.CreateParameter();
                    isFrontiersman.ParameterName = "@isFrontiersman";
                    if (!m.isFrontiersman)
                        isFrontiersman.Value = DBNull.Value;
                    else
                        isFrontiersman.Value = m.isFrontiersman;
                    cmd.Parameters.Add(isFrontiersman);

                    DbParameter dateModified = provider.CreateParameter();
                    dateModified.ParameterName = "@dateModified";
                    dateModified.Value = DateTime.Now;
                    cmd.Parameters.Add(dateModified);

                    DbParameter image = provider.CreateParameter();
                    image.ParameterName = "@image";
                    if (m.image == "" || m.image == null)
                        image.Value = DBNull.Value;
                    else
                        image.Value = m.image;
                    cmd.Parameters.Add(image);

                    DbParameter MemberID = provider.CreateParameter();
                    MemberID.ParameterName = "@MemberID";
                    MemberID.Value =  m.MemberID;
                    cmd.Parameters.Add(MemberID);

                    conn.Open();

                    cmd.ExecuteNonQuery();

                    conn.Close();
                    conn.Dispose();
                }
            }
        }
    }
}
