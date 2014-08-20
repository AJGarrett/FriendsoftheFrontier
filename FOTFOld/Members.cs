using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FOTFOld
{
    public class Members
    {
        #region Constructor

            public Members() { }

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
            
            private string _FName;
            public string FName
            {
	            get { return _FName; }
	            set { _FName = value; }
            }
            
            private string _LName;
            public string LName
            {
	            get { return _LName; }
	            set { _LName = value; }
            }
            
            private string _NickName;
            public string NickName
            {
	            get { return _NickName; }
	            set { _NickName = value; }
            }
            
            private string _Email;
            public string Email
            {
	            get { return _Email; }
	            set { _Email = value; }
            }
            
            private string _Password;
            public string Password
            {
	            get { return _Password; }
	            set { _Password = value; }
            }
            
            private string _Address;
            public string Address
            {
	            get { return _Address; }
	            set { _Address = value; }
            }
            
            private string _City;
            public string City
            {
	            get { return _City; }
	            set { _City = value; }
            }
            
            private string _State;
            public string State
            {
	            get { return _State; }
	            set { _State = value; }
            }
            
            private string _Zip;
            public string Zip
            {
	            get { return _Zip; }
	            set { _Zip = value; }
            }
            
            private string _Troop;
            public string Troop
            {
	            get { return _Troop; }
	            set { _Troop = value; }
            }
            
            private string _TrpTown;
            public string TrpTown
            {
	            get { return _TrpTown; }
	            set { _TrpTown = value; }
            }
            
            private string _PioneerYr;
            public string PioneerYr
            {
	            get { return _PioneerYr; }
	            set { _PioneerYr = value; }
            }
            
            private string _PioneerWk;
            public string PioneerWk
            {
	            get { return _PioneerWk; }
	            set { _PioneerWk = value; }
            }
            
            private string _TrapperYr;
            public string TrapperYr
            {
	            get { return _TrapperYr; }
	            set { _TrapperYr = value; }
            }
            
            private string _TrapperWk;
            public string TrapperWk
            {
	            get { return _TrapperWk; }
	            set { _TrapperWk = value; }
            }
            
            private string _MMYr;
            public string MMYr
            {
	            get { return _MMYr; }
	            set { _MMYr = value; }
            }
            
            private string _MMWk;
            public string MMWk
            {
	            get { return _MMWk; }
	            set { _MMWk = value; }
            }
            
            private string _MMCeremony;
            public string MMCeremony
            {
	            get { return _MMCeremony; }
	            set { _MMCeremony = value; }
            }
            
            private string _MMClaws;
            public string MMClaws
            {
	            get { return _MMClaws; }
	            set { _MMClaws = value; }
            }
            
            private string _MMBC;
            public string MMBC
            {
	            get { return _MMBC; }
	            set { _MMBC = value; }
            }
            
            private string _Comments;
            public string Comments
            {
	            get { return _Comments; }
	            set { _Comments = value; }
            }
            
            private bool _Guestbook;
            public bool Guestbook
            {
	            get { return _Guestbook; }
	            set { _Guestbook = value; }
            }
            
            private bool _MMVerification;
            public bool MMVerification
            {
	            get { return _MMVerification; }
	            set { _MMVerification = value; }
            }
            
            private string _Admin;
            public string Admin
            {
	            get { return _Admin; }
	            set { _Admin = value; }
            }
            
            private DateTime _LastLogon;
            public DateTime LastLogon
            {
	            get { return _LastLogon; }
	            set { _LastLogon = value; }
            }
            
            private string _Moderator;
            public string Moderator
            {
	            get { return _Moderator; }
	            set { _Moderator = value; }
            }
            
            private string _Failed_Email;
            public string Failed_Email
            {
	            get { return _Failed_Email; }
	            set { _Failed_Email = value; }
            }
            

        #endregion

        #region Constructor

            public static List<Members> GetAll()
            {
                return SQL.SQL_Members.GetAll();
            }

        #endregion
    }
}
