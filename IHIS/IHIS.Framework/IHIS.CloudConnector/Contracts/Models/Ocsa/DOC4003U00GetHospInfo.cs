using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocsa
{
    [Serializable]
    public class DOC4003U00GetHospInfo
    {
        private String _zipCode;
        private String _address;
        private String _tel;
        private String _yoyangName;

        public String ZipCode
        {
            get { return this._zipCode; }
            set { this._zipCode = value; }
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

        public String YoyangName
        {
            get { return this._yoyangName; }
            set { this._yoyangName = value; }
        }

        public DOC4003U00GetHospInfo() { }

        public DOC4003U00GetHospInfo(String zipCode, String address, String tel, String yoyangName)
        {
            this._zipCode = zipCode;
            this._address = address;
            this._tel = tel;
            this._yoyangName = yoyangName;
        }

    }
}