using System;

namespace IHIS.CloudConnector.Contracts.Models.OcsEmr
{
    [Serializable]
    public class NUR2001U04CheckExistMedicalRecordInfo
    {
        private String _emrRecordId;
        private String _content;
        private String _metadata;
        private String _version;
        private String _recordLog;
        private String _lockFlg;
        private String _hospCode;
        private String _bunho;
        private String _sysId;
        private String _updId;
        private String _created;
        private String _updated;

        public String EmrRecordId
        {
            get { return this._emrRecordId; }
            set { this._emrRecordId = value; }
        }

        public String Content
        {
            get { return this._content; }
            set { this._content = value; }
        }

        public String Metadata
        {
            get { return this._metadata; }
            set { this._metadata = value; }
        }

        public String Version
        {
            get { return this._version; }
            set { this._version = value; }
        }

        public String RecordLog
        {
            get { return this._recordLog; }
            set { this._recordLog = value; }
        }

        public String LockFlg
        {
            get { return this._lockFlg; }
            set { this._lockFlg = value; }
        }

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public String SysId
        {
            get { return this._sysId; }
            set { this._sysId = value; }
        }

        public String UpdId
        {
            get { return this._updId; }
            set { this._updId = value; }
        }

        public String Created
        {
            get { return this._created; }
            set { this._created = value; }
        }

        public String Updated
        {
            get { return this._updated; }
            set { this._updated = value; }
        }

        public NUR2001U04CheckExistMedicalRecordInfo() { }

        public NUR2001U04CheckExistMedicalRecordInfo(String emrRecordId, String content, String metadata, String version, String recordLog, String lockFlg, String hospCode, String bunho, String sysId, String updId, String created, String updated)
        {
            this._emrRecordId = emrRecordId;
            this._content = content;
            this._metadata = metadata;
            this._version = version;
            this._recordLog = recordLog;
            this._lockFlg = lockFlg;
            this._hospCode = hospCode;
            this._bunho = bunho;
            this._sysId = sysId;
            this._updId = updId;
            this._created = created;
            this._updated = updated;
        }

    }
}