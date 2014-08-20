using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CLR
{
    public class CLRSAADues
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

            private int _DuesID;
            public int DuesID
            {
                get { return _DuesID; }
                set { _DuesID = value; }
            }
        
            private int _MemberID;
            public int MemberID
            {
	            get { return _MemberID; }
	            set { _MemberID = value; }
            }
            
            private DateTime _DatePaid;
            public DateTime DatePaid
            {
	            get { return _DatePaid; }
	            set { _DatePaid = value; }
            }
            
            private decimal _Amount;
            public decimal Amount
            {
	            get { return _Amount; }
	            set { _Amount = value; }
            }
            
            private DateTime _DateExpires;
            public DateTime DateExpires
            {
	            get { return _DateExpires; }
	            set { _DateExpires = value; }
            }
            

        #endregion

        #region Constructor

            private static DataAccess.SQL_CLRSAADues db = new DataAccess.SQL_CLRSAADues();
        
            public static List<CLRSAADues> GetAll(int MemberID)
            {
                return db.GetAll(MemberID);
            }

            public static CLRSAADues GetSingle(int DuesID)
            {
                return db.GetSingle(DuesID);
            }

            public void Delete()
            {
                db.Delete(_MemberID);
            }

            public void Save()
            {
                if (_isNew)
                    _DuesID = db.Insert(this);
                else
                    db.Update(this);
            }

        #endregion
    }
}
