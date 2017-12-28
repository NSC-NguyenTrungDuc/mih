using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    public class BIL0102U00GetHospInfoResult : AbstractContractResult
    {
        private String _yoyangName;
        private String _address;
        private String _tel;
        private String _email;
        private String _locale;

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

        public String Email
        {
            get { return this._email; }
            set { this._email = value; }
        }

        public String Locale
        {
            get { return this._locale; }
            set { this._locale = value; }
        }

        public BIL0102U00GetHospInfoResult() { }

    }
}