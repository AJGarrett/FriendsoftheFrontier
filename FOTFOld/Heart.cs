using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FOTFOld
{
    public class Heart
    {
        #region Constructor

            public Heart() { }

        #endregion

        #region Properties

            private bool _isNew = true;
            public bool isNew
            {
	            get { return _isNew; }
	            set { _isNew = value; }
            }

            private int _ID;
            public int ID
            {
	            get { return _ID; }
	            set { _ID = value; }
            }
            
            private int _MemberID;
            public int MemberID
            {
	            get { return _MemberID; }
	            set { _MemberID = value; }
            }
            
            private string _Comments;
            public string Comments
            {
	            get { return _Comments; }
	            set { _Comments = value; }
            }
            
            private DateTime _Date;
            public DateTime Date
            {
	            get { return _Date; }
	            set { _Date = value; }
            }
            

        #endregion

        #region Constructor

            public static List<Heart> GetAll()
            {
                return SQL.SQL_Heart.GetAll();
            }
        #endregion
    }
}
