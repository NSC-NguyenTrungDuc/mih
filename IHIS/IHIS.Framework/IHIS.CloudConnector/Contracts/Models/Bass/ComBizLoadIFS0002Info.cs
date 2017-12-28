using System;

namespace IHIS.CloudConnector.Contracts.Models.Bass
{
    [Serializable]
    public class ComBizLoadIFS0002Info
    {
        private String _codeType;
        private String _code;
        private String _codeName;
        private String _remark;
        private String _sysDate;
        private String _sysId;
        private String _updDate;
        private String _updId;

        public String CodeType
        {
            get { return this._codeType; }
            set { this._codeType = value; }
        }

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

        public String Remark
        {
            get { return this._remark; }
            set { this._remark = value; }
        }

        public String SysDate
        {
            get { return this._sysDate; }
            set { this._sysDate = value; }
        }

        public String SysId
        {
            get { return this._sysId; }
            set { this._sysId = value; }
        }

        public String UpdDate
        {
            get { return this._updDate; }
            set { this._updDate = value; }
        }

        public String UpdId
        {
            get { return this._updId; }
            set { this._updId = value; }
        }

        public ComBizLoadIFS0002Info() { }

        public ComBizLoadIFS0002Info(String codeType, String code, String codeName, String remark, String sysDate, String sysId, String updDate, String updId)
        {
            this._codeType = codeType;
            this._code = code;
            this._codeName = codeName;
            this._remark = remark;
            this._sysDate = sysDate;
            this._sysId = sysId;
            this._updDate = updDate;
            this._updId = updId;
        }

    }
}