using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CLR
{
    public class Sites
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

            private int _SiteID;
            public int SiteID
            {
	            get { return _SiteID; }
	            set { _SiteID = value; }
            }
            
            private string _SiteName;
            public string SiteName
            {
	            get { return _SiteName; }
	            set { _SiteName = value; }
            }
            
            private string _SiteDomain;
            public string SiteDomain
            {
	            get { return _SiteDomain; }
	            set { _SiteDomain = value; }
            }
            

        #endregion

        #region Methods

            private static DataAccess.SQL_Sites db = new DataAccess.SQL_Sites();

            public static List<Sites> GetAll()
            {
                return db.GetAll();
            }

            public static Sites GetSingle(int SiteID)
            {
                return db.GetSingle(SiteID);
            }

            public void Delete()
            {
                db.Delete(_SiteID);
            }

            public void Save()
            {
                if (_isNew)
                    _SiteID = db.Insert(this);
                else
                    db.Update(this);
            }

        #endregion
    }
}
