using System;

namespace IHIS.CloudConnector.Contracts.Models.Adma
{
    [Serializable]
    public class Adm107USaveLayoutInfo
    {
        private String _userId;
        private String _sysId;
        private String _trId;
        private String _trSeq;
        private String _upprMenu;
        private String _crMemb;
        private String _useYn;

        public String UserId
        {
            get { return this._userId; }
            set { this._userId = value; }
        }

        public String SysId
        {
            get { return this._sysId; }
            set { this._sysId = value; }
        }

        public String TrId
        {
            get { return this._trId; }
            set { this._trId = value; }
        }

        public String TrSeq
        {
            get { return this._trSeq; }
            set { this._trSeq = value; }
        }

        public String UpprMenu
        {
            get { return this._upprMenu; }
            set { this._upprMenu = value; }
        }

        public String CrMemb
        {
            get { return this._crMemb; }
            set { this._crMemb = value; }
        }

        public String UseYn
        {
            get { return this._useYn; }
            set { this._useYn = value; }
        }

        public Adm107USaveLayoutInfo() { }

        public Adm107USaveLayoutInfo(String userId, String sysId, String trId, String trSeq, String upprMenu, String crMemb, String useYn)
        {
            this._userId = userId;
            this._sysId = sysId;
            this._trId = trId;
            this._trSeq = trSeq;
            this._upprMenu = upprMenu;
            this._crMemb = crMemb;
            this._useYn = useYn;
        }

    }
}