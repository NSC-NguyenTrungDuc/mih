using System;

namespace IHIS.CloudConnector.Contracts.Models.Adma
{
    [Serializable]
    public class Adm107ULayDownListInfo
    {
        private String _userId;
        private String _sysId;
        private String _trId;
        private String _trSeq;
        private String _pgmId;
        private String _upprMenu;
        private String _pgmNm;
        private String _pgmTp;
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

        public String PgmId
        {
            get { return this._pgmId; }
            set { this._pgmId = value; }
        }

        public String UpprMenu
        {
            get { return this._upprMenu; }
            set { this._upprMenu = value; }
        }

        public String PgmNm
        {
            get { return this._pgmNm; }
            set { this._pgmNm = value; }
        }

        public String PgmTp
        {
            get { return this._pgmTp; }
            set { this._pgmTp = value; }
        }

        public String UseYn
        {
            get { return this._useYn; }
            set { this._useYn = value; }
        }

        public Adm107ULayDownListInfo() { }

        public Adm107ULayDownListInfo(String userId, String sysId, String trId, String trSeq, String pgmId, String upprMenu, String pgmNm, String pgmTp, String useYn)
        {
            this._userId = userId;
            this._sysId = sysId;
            this._trId = trId;
            this._trSeq = trSeq;
            this._pgmId = pgmId;
            this._upprMenu = upprMenu;
            this._pgmNm = pgmNm;
            this._pgmTp = pgmTp;
            this._useYn = useYn;
        }

    }
}