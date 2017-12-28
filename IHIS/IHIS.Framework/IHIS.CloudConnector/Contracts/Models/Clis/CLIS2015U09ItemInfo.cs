using System;

namespace IHIS.CloudConnector.Contracts.Models.Clis
{
    [Serializable]
    public class CLIS2015U09ItemInfo
    {
        private String _clisSmoId;
        private String _smoCode;
        private String _startDate;
        private String _endDate;
        private String _smoName;
        private String _smoName1;
        private String _zipCode1;
        private String _zipCode2;
        private String _address;
        private String _address1;
        private String _tel;
        private String _tel1;
        private String _fax;
        private String _dodobuhyeunNo;
        private String _codeName;
        private String _homepage;
        private String _email;
        private String _rowState;

        public String ClisSmoId
        {
            get { return this._clisSmoId; }
            set { this._clisSmoId = value; }
        }

        public String SmoCode
        {
            get { return this._smoCode; }
            set { this._smoCode = value; }
        }

        public String StartDate
        {
            get { return this._startDate; }
            set { this._startDate = value; }
        }

        public String EndDate
        {
            get { return this._endDate; }
            set { this._endDate = value; }
        }

        public String SmoName
        {
            get { return this._smoName; }
            set { this._smoName = value; }
        }

        public String SmoName1
        {
            get { return this._smoName1; }
            set { this._smoName1 = value; }
        }

        public String ZipCode1
        {
            get { return this._zipCode1; }
            set { this._zipCode1 = value; }
        }

        public String ZipCode2
        {
            get { return this._zipCode2; }
            set { this._zipCode2 = value; }
        }

        public String Address
        {
            get { return this._address; }
            set { this._address = value; }
        }

        public String Address1
        {
            get { return this._address1; }
            set { this._address1 = value; }
        }

        public String Tel
        {
            get { return this._tel; }
            set { this._tel = value; }
        }

        public String Tel1
        {
            get { return this._tel1; }
            set { this._tel1 = value; }
        }

        public String Fax
        {
            get { return this._fax; }
            set { this._fax = value; }
        }

        public String DodobuhyeunNo
        {
            get { return this._dodobuhyeunNo; }
            set { this._dodobuhyeunNo = value; }
        }

        public String CodeName
        {
            get { return this._codeName; }
            set { this._codeName = value; }
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

        public String RowState
        {
            get { return this._rowState; }
            set { this._rowState = value; }
        }

        public CLIS2015U09ItemInfo() { }

        public CLIS2015U09ItemInfo(String clisSmoId, String smoCode, String startDate, String endDate, String smoName, String smoName1, String zipCode1, String zipCode2, String address, String address1, String tel, String tel1, String fax, String dodobuhyeunNo, String codeName, String homepage, String email, String rowState)
        {
            this._clisSmoId = clisSmoId;
            this._smoCode = smoCode;
            this._startDate = startDate;
            this._endDate = endDate;
            this._smoName = smoName;
            this._smoName1 = smoName1;
            this._zipCode1 = zipCode1;
            this._zipCode2 = zipCode2;
            this._address = address;
            this._address1 = address1;
            this._tel = tel;
            this._tel1 = tel1;
            this._fax = fax;
            this._dodobuhyeunNo = dodobuhyeunNo;
            this._codeName = codeName;
            this._homepage = homepage;
            this._email = email;
            this._rowState = rowState;
        }

    }
}