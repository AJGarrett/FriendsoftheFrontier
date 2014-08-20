using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CLR
{
    public class FrontierHistory
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
            
            private int _PioneerYr;
            public int PioneerYr
            {
	            get { return _PioneerYr; }
	            set { _PioneerYr = value; }
            }
            
            private int _PioneerWk;
            public int PioneerWk
            {
	            get { return _PioneerWk; }
	            set { _PioneerWk = value; }
            }
            
            private int _TrapperYr;
            public int TrapperYr
            {
	            get { return _TrapperYr; }
	            set { _TrapperYr = value; }
            }
            
            private int _TrapperWk;
            public int TrapperWk
            {
	            get { return _TrapperWk; }
	            set { _TrapperWk = value; }
            }
            
            private int _MMYr;
            public int MMYr
            {
	            get { return _MMYr; }
	            set { _MMYr = value; }
            }
            
            private int _MMWk;
            public int MMWk
            {
	            get { return _MMWk; }
	            set { _MMWk = value; }
            }
            
            private string _MMClaws;
            public string MMClaws
            {
	            get { return _MMClaws; }
	            set { _MMClaws = value; }
            }
            
            private int _MMClawsID;
            public int MMClawsID
            {
	            get { return _MMClawsID; }
	            set { _MMClawsID = value; }
            }
            
            private string _MMCeremony;
            public string MMCeremony
            {
	            get { return _MMCeremony; }
	            set { _MMCeremony = value; }
            }
            
            private bool _isMMApproved;
            public bool isMMApproved
            {
	            get { return _isMMApproved; }
	            set { _isMMApproved = value; }
            }
            

        #endregion

        #region Methods

            private static DataAccess.SQL_FrontierHistory db = new DataAccess.SQL_FrontierHistory();

            public static FrontierHistory GetSingle(int MemberID)
            {
                return db.GetSingle(MemberID);
            }

            public void Delete()
            {
                db.Delete(_MemberID);
            }

            public void Save()
            {
                if (_isNew)
                    db.Insert(this);
                else
                    db.Update(this);
            }

        #endregion
    }
}
