using System;

namespace IHIS.CloudConnector.Contracts.Models.Nuro
{
    [Serializable]
    public class NUR2016Q00LinkPatientInfo
    {
        private String _hospCode;
        private String _bunho;
        private String _hospCodeLink;
        private String _bunhoLink;
        private String _emrLinkFlg;
        private String _linkType;
        private String _activeFlg;

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

        public String HospCodeLink
        {
            get { return this._hospCodeLink; }
            set { this._hospCodeLink = value; }
        }

        public String BunhoLink
        {
            get { return this._bunhoLink; }
            set { this._bunhoLink = value; }
        }

        public String EmrLinkFlg
        {
            get { return this._emrLinkFlg; }
            set { this._emrLinkFlg = value; }
        }

        public String LinkType
        {
            get { return this._linkType; }
            set { this._linkType = value; }
        }

        public String ActiveFlg
        {
            get { return this._activeFlg; }
            set { this._activeFlg = value; }
        }

        public NUR2016Q00LinkPatientInfo() { }

        public NUR2016Q00LinkPatientInfo(String hospCode, String bunho, String hospCodeLink, String bunhoLink, String emrLinkFlg, String linkType, String activeFlg)
        {
            this._hospCode = hospCode;
            this._bunho = bunho;
            this._hospCodeLink = hospCodeLink;
            this._bunhoLink = bunhoLink;
            this._emrLinkFlg = emrLinkFlg;
            this._linkType = linkType;
            this._activeFlg = activeFlg;
        }

    }
}