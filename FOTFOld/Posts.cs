using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FOTFOld
{
    public class Posts
    {
        #region Constructor

            public Posts() { }

        #endregion

        #region Properties

            private bool _isNew = true;
            public bool isNew
            {
	            get { return _isNew; }
	            set { _isNew = value; }
            }

            private int _PostID;
            public int PostID
            {
	            get { return _PostID; }
	            set { _PostID = value; }
            }
            
            private int _ThreadID;
            public int ThreadID
            {
	            get { return _ThreadID; }
	            set { _ThreadID = value; }
            }
            
            private string _Post;
            public string Post
            {
	            get { return _Post; }
	            set { _Post = value; }
            }
            
            private int _MemberID;
            public int MemberID
            {
	            get { return _MemberID; }
	            set { _MemberID = value; }
            }
            
            private DateTime _Date;
            public DateTime Date
            {
	            get { return _Date; }
	            set { _Date = value; }
            }
            

        #endregion

        #region Constructor

            public static List<Posts> GetAll()
            {
                return SQL.SQL_Posts.GetAll();
            }
        #endregion
    }
}
