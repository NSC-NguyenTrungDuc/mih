using System;

namespace IHIS.CloudConnector.Contracts.Models.Bass
{
    [Serializable]
    public class ComBizLoadIFS0001Info
    {
        private String _codeType;
        private String _codeTypeName;
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

        public String CodeTypeName
        {
            get { return this._codeTypeName; }
            set { this._codeTypeName = value; }
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

        public ComBizLoadIFS0001Info() { }

        public ComBizLoadIFS0001Info(String codeType, String codeTypeName, String remark, String sysDate, String sysId, String updDate, String updId)
        {
            this._codeType = codeType;
            this._codeTypeName = codeTypeName;
            this._remark = remark;
            this._sysDate = sysDate;
            this._sysId = sysId;
            this._updDate = updDate;
            this._updId = updId;
        }

    }
}