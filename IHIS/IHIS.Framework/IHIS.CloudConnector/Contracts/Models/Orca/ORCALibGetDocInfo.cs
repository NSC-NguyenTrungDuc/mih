using System;

namespace IHIS.CloudConnector.Contracts.Models.Orca
{
    [Serializable]
    public class ORCALibGetDocInfo
    {
        private String _yoyangGiho;
        private String _yoyangName;
        private String _zipCode;
        private String _address;
        private String _tel;
        private String _presidentName;
        private String _orcaGigwanCode;

        public String YoyangGiho
        {
            get { return this._yoyangGiho; }
            set { this._yoyangGiho = value; }
        }

        public String YoyangName
        {
            get { return this._yoyangName; }
            set { this._yoyangName = value; }
        }

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

        public String PresidentName
        {
            get { return this._presidentName; }
            set { this._presidentName = value; }
        }

        public String OrcaGigwanCode
        {
            get { return this._orcaGigwanCode; }
            set { this._orcaGigwanCode = value; }
        }

        public ORCALibGetDocInfo() { }

        public ORCALibGetDocInfo(String yoyangGiho, String yoyangName, String zipCode, String address, String tel, String presidentName, String orcaGigwanCode)
        {
            this._yoyangGiho = yoyangGiho;
            this._yoyangName = yoyangName;
            this._zipCode = zipCode;
            this._address = address;
            this._tel = tel;
            this._presidentName = presidentName;
            this._orcaGigwanCode = orcaGigwanCode;
        }

    }
}