using System;

namespace IHIS.CloudConnector.Contracts.Models.Bass
{
    public class LoadDepartmentTypeInfo
    {
        private String _code;
        private String _codeType;
        private String _hospCode;
        private String _codeName;

        public String Code
        {
            get { return this._code; }
            set { this._code = value; }
        }

        public String CodeType
        {
            get { return this._codeType; }
            set { this._codeType = value; }
        }

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public String CodeName
        {
            get { return this._codeName; }
            set { this._codeName = value; }
        }

        public LoadDepartmentTypeInfo() { }

        public LoadDepartmentTypeInfo(String code, String codeType, String hospCode, String codeName)
        {
            this._code = code;
            this._codeType = codeType;
            this._hospCode = hospCode;
            this._codeName = codeName;
        }

    }
}