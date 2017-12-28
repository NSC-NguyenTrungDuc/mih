using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocso
{
    public class OCS4001U00HospitalInfo
    {
        private String _yoyangName;
        private String _address;
        private String _tel;
        private String _fax;
        private String _homepage;
        private String _email;

        public String YoyangName
        {
            get { return this._yoyangName; }
            set { this._yoyangName = value; }
        }

        public String Address
        {
            get { return this._address; }
            set { this._address = value; }
        }

        public String Tel
        {
            get { return this._tel; }
            set { this._tel = value; }
        }

        public String Fax
        {
            get { return this._fax; }
            set { this._fax = value; }
        }

        public String Homepage
        {
            get { return this._homepage; }
            set { this._homepage = value; }
        }

        public String Email
        {
            get { return this._email; }
            set { this._email = value; }
        }

        public OCS4001U00HospitalInfo() { }

        public OCS4001U00HospitalInfo(String yoyangName, String address, String tel, String fax, String homepage, String email)
        {
            this._yoyangName = yoyangName;
            this._address = address;
            this._tel = tel;
            this._fax = fax;
            this._homepage = homepage;
            this._email = email;
        }

    }
}