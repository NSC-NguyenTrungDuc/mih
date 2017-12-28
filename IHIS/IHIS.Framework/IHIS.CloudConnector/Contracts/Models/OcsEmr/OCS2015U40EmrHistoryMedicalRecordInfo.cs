using System;

namespace IHIS.CloudConnector.Contracts.Models.OcsEmr
{
    [Serializable]
    public class OCS2015U40EmrHistoryMedicalRecordInfo
    {
        private String _sysId;
        private String _created;
        private String _memo;
        private String _activeFlg;
        private String _version;
        private String _author;
        private String _emrRecordId;

        public String SysId
        {
            get { return this._sysId; }
            set { this._sysId = value; }
        }

        public String Created
        {
            get { return this._created; }
            set { this._created = value; }
        }

        public String Memo
        {
            get { return this._memo; }
            set { this._memo = value; }
        }

        public String ActiveFlg
        {
            get { return this._activeFlg; }
            set { this._activeFlg = value; }
        }

        public String Version
        {
            get { return this._version; }
            set { this._version = value; }
        }

        public String Author
        {
            get { return this._author; }
            set { this._author = value; }
        }

        public String EmrRecordId
        {
            get { return this._emrRecordId; }
            set { this._emrRecordId = value; }
        }

        public OCS2015U40EmrHistoryMedicalRecordInfo() { }

        public OCS2015U40EmrHistoryMedicalRecordInfo(String sysId, String created, String memo, String activeFlg, String version, String author, String emrRecordId)
        {
            this._sysId = sysId;
            this._created = created;
            this._memo = memo;
            this._activeFlg = activeFlg;
            this._version = version;
            this._author = author;
            this._emrRecordId = emrRecordId;
        }

    }
}