using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CLR
{
    public class GuestbookComments
    {
        #region Constructor

            public GuestbookComments() { }

            public GuestbookComments(int GuestbookID, int Member, string Comments)
            {
                _GBID = GuestbookID;
                _MemberID = Member;
                _Comment = Comments;
            }

        #endregion

        #region Properties

            private bool _isNew = true;
            public bool isNew
            {
	            get { return _isNew; }
	            set { _isNew = value; }
            }

            private int _GBCommentID;
            public int GBCommentID
            {
	            get { return _GBCommentID; }
	            set { _GBCommentID = value; }
            }
            
            private int _GBID;
            public int GBID
            {
	            get { return _GBID; }
	            set { _GBID = value; }
            }
            
            private int _MemberID;
            public int MemberID
            {
	            get { return _MemberID; }
	            set { _MemberID = value; }
            }
            
            private string _Comment;
            public string Comment
            {
	            get { return _Comment; }
	            set { _Comment = value; }
            }
            
            private DateTime _DateCreated;
            public DateTime DateCreated
            {
	            get { return _DateCreated; }
	            set { _DateCreated = value; }
            }

            private Members _Member;
            public Members Member
            {
                get { return _Member; }
                set { _Member = value; }
            }

            

        #endregion

        #region Methods

            private static DataAccess.SQL_GuestbookComments db = new DataAccess.SQL_GuestbookComments();

            public static List<GuestbookComments> GetAll()
            {
                return db.GetAll();
            }

            public static List<GuestbookComments> GetAll(int GBID)
            {
                return db.GetAllbyGuestbook(GBID);
            }

            public static GuestbookComments GetSingle(int ID)
            {
                return db.GetSingle(ID);
            }

            public void Delete()
            {
                db.Delete(_GBCommentID);
            }

            public static void DeleteAllGBComments(int GBID)
            {
                db.DeleteGB(GBID);
            }

            public static void DeleteAllMemberComments(int MemberID)
            {
                db.DeleteMemebers(MemberID);
            }

            public void Save()
            {
                if (_isNew)
                    _GBCommentID = db.Insert(this);
                else
                    db.Update(this);
            }

        #endregion
    }
}
