using System;

namespace IHIS.CloudConnector.Contracts.Models.Adma
{
    [Serializable]
    public class ADM103LayLoginSysListInfo
    {
        private String _sysId;
        private String _sysNm;

        public String SysId
        {
            get { return this._sysId; }
            set { this._sysId = value; }
        }

        public String SysNm
        {
            get { return this._sysNm; }
            set { this._sysNm = value; }
        }

        public ADM103LayLoginSysListInfo() { }

        public ADM103LayLoginSysListInfo(String sysId, String sysNm)
        {
            this._sysId = sysId;
            this._sysNm = sysNm;
        }

    }
}