using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FOTFOld
{
    public class Threads
    {
        #region Constructor

            public Threads() { }

        #endregion

        #region Properties

            private bool _isNew = true;
            public bool isNew
            {
	            get { return _isNew; }
	            set { _isNew = value; }
            }

            private int _ThreadID;
            public int ThreadID
            {
	            get { return _ThreadID; }
	            set { _ThreadID = value; }
            }
            
            private int _ForumID;
            public int ForumID
            {
	            get { return _ForumID; }
	            set { _ForumID = value; }
            }
            
            private string _Title;
            public string Title
            {
	            get { return _Title; }
	            set { _Title = value; }
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
            
            private string _Locked;
            public string Locked
            {
	            get { return _Locked; }
	            set { _Locked = value; }
            }

            public List<Posts> Posts { get; set; }

        #endregion

        #region Constructor

            public static List<Threads> GetAll()
            {
                return SQL.SQL_Threads.GetAll();
            }
        #endregion
    }
}
