using System;

namespace IHIS.CloudConnector.Contracts.Models.Bill
{
    public class LoadComboBIL2016U02Info
    {
        private String _code;
        private String _codeName;

        public String Code
        {
            get { return this._code; }
            set { this._code = value; }
        }

        public String CodeName
        {
            get { return this._codeName; }
            set { this._codeName = value; }
        }

        public LoadComboBIL2016U02Info() { }

        public LoadComboBIL2016U02Info(String code, String codeName)
        {
            this._code = code;
            this._codeName = codeName;
        }

    }
}