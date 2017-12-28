using System;

namespace IHIS.CloudConnector.Contracts.Models.Adma
{
    [Serializable]
    public class ADM106UMakeQueryListItemInfo
    {
        private String _sysId;
        private String _trId;
        private String _trSeq;
        private String _pgmId;
        private String _upprMenu;
        private String _pgmNm;
        private String _pgmTp;
        private String _pgmOpenTp;
        private String _shortCut;
        private String _menuParam;
        private String _rowState;

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

        public String PgmOpenTp
        {
            get { return this._pgmOpenTp; }
            set { this._pgmOpenTp = value; }
        }

        public String ShortCut
        {
            get { return this._shortCut; }
            set { this._shortCut = value; }
        }

        public String MenuParam
        {
            get { return this._menuParam; }
            set { this._menuParam = value; }
        }

        public String RowState
        {
            get { return this._rowState; }
            set { this._rowState = value; }
        }

        public ADM106UMakeQueryListItemInfo() { }

        public ADM106UMakeQueryListItemInfo(String sysId, String trId, String trSeq, String pgmId, String upprMenu, String pgmNm, String pgmTp, String pgmOpenTp, String shortCut, String menuParam, String rowState)
        {
            this._sysId = sysId;
            this._trId = trId;
            this._trSeq = trSeq;
            this._pgmId = pgmId;
            this._upprMenu = upprMenu;
            this._pgmNm = pgmNm;
            this._pgmTp = pgmTp;
            this._pgmOpenTp = pgmOpenTp;
            this._shortCut = shortCut;
            this._menuParam = menuParam;
            this._rowState = rowState;
        }

    }
}