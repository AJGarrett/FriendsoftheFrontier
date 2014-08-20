using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CLR
{
    public class Members
    {
        #region Constructor

        #endregion

        #region Properties

            private bool _isNew = true;
            public bool isNew
            {
	            get { return _isNew; }
	            set { _isNew = value; }
            }

            private int _MemberID;
            public int MemberID
            {
	            get { return _MemberID; }
	            set { _MemberID = value; }
            }
            
            private string _FirstName;
            public string FirstName
            {
	            get { return _FirstName; }
	            set { _FirstName = value; }
            }
            
            private string _LastName;
            public string LastName
            {
	            get { return _LastName; }
	            set { _LastName = value; }
            }
            
            private string _Email;
            public string Email
            {
	            get { return _Email; }
	            set { _Email = value; }
            }
            
            private string _Nickname;
            public string Nickname
            {
	            get { return _Nickname; }
	            set { _Nickname = value; }
            }
            
            private string _CurrentTroop;
            public string CurrentTroop
            {
	            get { return _CurrentTroop; }
	            set { _CurrentTroop = value; }
            }
            
            private string _FormerTroop;
            public string FormerTroop
            {
	            get { return _FormerTroop; }
	            set { _FormerTroop = value; }
            }
            
            private string _Address;
            public string Address
            {
	            get { return _Address; }
	            set { _Address = value; }
            }
            
            private string _City;
            public string City
            {
	            get { return _City; }
	            set { _City = value; }
            }
            
            private string _State;
            public string State
            {
	            get { return _State; }
	            set { _State = value; }
            }
            
            private string _ZipCode;
            public string ZipCode
            {
	            get { return _ZipCode; }
	            set { _ZipCode = value; }
            }
            
            private DateTime _Birthday;
            public DateTime Birthday
            {
	            get { return _Birthday; }
	            set { _Birthday = value; }
            }
            
            private string _HighestRank;
            public string HighestRank
            {
	            get { return _HighestRank; }
	            set { _HighestRank = value; }
            }
            
            private string _Comments;
            public string Comments
            {
	            get { return _Comments; }
	            set { _Comments = value; }
            }
            
            private bool _isBadEmail;
            public bool isBadEmail
            {
	            get { return _isBadEmail; }
	            set { _isBadEmail = value; }
            }
            
            private string _Website;
            public string Website
            {
	            get { return _Website; }
	            set { _Website = value; }
            }
            
            private string _Facebook;
            public string Facebook
            {
	            get { return _Facebook; }
	            set { _Facebook = value; }
            }
            
            private string _Twitter;
            public string Twitter
            {
	            get { return _Twitter; }
	            set { _Twitter = value; }
            }
            
            private bool _isAlumni;
            public bool isAlumni
            {
	            get { return _isAlumni; }
	            set { _isAlumni = value; }
            }
            
            private bool _isFrontiersman;
            public bool isFrontiersman
            {
	            get { return _isFrontiersman; }
	            set { _isFrontiersman = value; }
            }
            
            private DateTime _dateCreated;
            public DateTime dateCreated
            {
	            get { return _dateCreated; }
	            set { _dateCreated = value; }
            }
            
            private DateTime _dateModified;
            public DateTime dateModified
            {
	            get { return _dateModified; }
	            set { _dateModified = value; }
            }

            private string _image;
            public string image
            {
                get { return _image; }
                set { _image = value; }
            }

            private FrontierHistory _FrontiersmanDetail;
            public FrontierHistory FrontiersmanDetail
            {
                get { return _FrontiersmanDetail; }
                set { _FrontiersmanDetail = value; }
            }
            

        #endregion

        #region Methods

            private static DataAccess.SQL_Members db = new DataAccess.SQL_Members();

            public static List<Members> GetAll()
            {
                return db.GetAll();
            }

            public static Members GetSingle(int MemberID)
            {
                return db.GetSingle(MemberID);
            }

            public static Members GetSingle(string Email)
            {
                return db.GetSingle(Email);
            }

            public void Delete()
            {
                GuestbookComments.DeleteAllMemberComments(_MemberID);
                db.Delete(_MemberID);
            }

            public void Save()
            {
                if (_isNew)
                    _MemberID = db.Insert(this);
                else
                    db.Update(this);
            }

        #endregion
    }
}
