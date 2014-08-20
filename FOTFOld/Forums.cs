using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FOTFOld
{
    public class Forums
    {
        #region Constructor

            public Forums() { }

        #endregion

        #region Properties

            private bool _isNew = true;
            public bool isNew
            {
	            get { return _isNew; }
	            set { _isNew = value; }
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
            
            private string _Description;
            public string Description
            {
	            get { return _Description; }
	            set { _Description = value; }
            }
            
            private int _CreatorID;
            public int CreatorID
            {
	            get { return _CreatorID; }
	            set { _CreatorID = value; }
            }
            
            private DateTime _Date;
            public DateTime Date
            {
	            get { return _Date; }
	            set { _Date = value; }
            }
            
            private string _MMOnly;
            public string MMOnly
            {
	            get { return _MMOnly; }
	            set { _MMOnly = value; }
            }

            public List<Threads> Threads { get; set; }
            

        #endregion

        #region Constructor

            public static List<Forums> GetAll()
            {
                return SQL.SQL_Forums.GetAll();
            }
        #endregion
    }
}
