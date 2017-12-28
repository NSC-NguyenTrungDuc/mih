using System;

namespace IHIS.CloudConnector.Contracts.Models.Invs
{
    public class LoadComboINV0101Info
    {
        private String _codeType;
        private String _codeTypeName;

        public String CodeType
        {
            get { return this._codeType; }
            set { this._codeType = value; }
        }

        public String CodeTypeName
        {
            get { return this._codeTypeName; }
            set { this._codeTypeName = value; }
        }

        public LoadComboINV0101Info() { }

        public LoadComboINV0101Info(String codeType, String codeTypeName)
        {
            this._codeType = codeType;
            this._codeTypeName = codeTypeName;
        }

    }
}