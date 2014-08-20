using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CLR
{
    public class GuestbookManagement
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

            private int _GBID;
            public int GBID
            {
	            get { return _GBID; }
	            set { _GBID = value; }
            }
            
            private int _SiteID;
            public int SiteID
            {
	            get { return _SiteID; }
	            set { _SiteID = value; }
            }
            
            private string _URL;
            public string URL
            {
	            get { return _URL; }
	            set { _URL = value; }
            }
            

        #endregion

        #region Methods

            private static DataAccess.SQL_GuestbookManagement db = new DataAccess.SQL_GuestbookManagement();

            public static List<GuestbookManagement> GetAll()
            {
                return db.GetAll();
            }

            public static GuestbookManagement GetSingle(int GBID)
            {
                return db.GetSingle(GBID);
            }

            public void Delete()
            {
                db.Delete(_GBID);
            }

            public void Save()
            {
                if (_isNew)
                    _GBID = db.Insert(this);
                else
                    db.Update(this);
            }

        #endregion
    }
}
