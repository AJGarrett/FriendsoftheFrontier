using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CLR
{
    public class StaffHistory
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

            private int _JobID;
            public int JobID
            {
	            get { return _JobID; }
	            set { _JobID = value; }
            }
            
            private int _MemberID;
            public int MemberID
            {
	            get { return _MemberID; }
	            set { _MemberID = value; }
            }
            
            private int _Summer;
            public int Summer
            {
	            get { return _Summer; }
	            set { _Summer = value; }
            }
            
            private string _JobTitle;
            public string JobTitle
            {
	            get { return _JobTitle; }
	            set { _JobTitle = value; }
            }
            

        #endregion

        #region Methods

            private static DataAccess.SQL_StaffHistory db = new DataAccess.SQL_StaffHistory();

            public static List<StaffHistory> GetAllMembers(int MemberID)
            {
                return db.GetAll(MemberID);
            }
        
            public static StaffHistory GetSingle(int JobID)
            {
                return db.GetSingle(JobID);
            }

            public void Delete()
            {
                db.Delete(_JobID);
            }

            public void Save()
            {
                if (_isNew)
                    _JobID = db.Insert(this);
                else
                    db.Update(this);
            }

        #endregion
    }
}
