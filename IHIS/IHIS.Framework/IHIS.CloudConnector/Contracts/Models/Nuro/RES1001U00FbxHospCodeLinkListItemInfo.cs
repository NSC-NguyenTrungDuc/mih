using System;

namespace IHIS.CloudConnector.Contracts.Models.Nuro
{
    [Serializable]
    public class RES1001U00FbxHospCodeLinkListItemInfo
    {
        private String _hospCode;
        private String _hospName;
        private String _address;
        private String _telephone;

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public String HospName
        {
            get { return this._hospName; }
            set { this._hospName = value; }
        }

        public String Address
        {
            get { return this._address; }
            set { this._address = value; }
        }

        public String Telephone
        {
            get { return this._telephone; }
            set { this._telephone = value; }
        }

        public RES1001U00FbxHospCodeLinkListItemInfo() { }

        public RES1001U00FbxHospCodeLinkListItemInfo(String hospCode, String hospName, String address, String telephone)
        {
            this._hospCode = hospCode;
            this._hospName = hospName;
            this._address = address;
            this._telephone = telephone;
        }

    }
}