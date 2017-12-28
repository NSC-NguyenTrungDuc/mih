using System;

namespace IHIS.CloudConnector.Contracts.Models.Outs
{
    [Serializable]
    public class OUT2016U00PatientLinkingContentInfo
    {
        private String _hospCodeLink;
        private String _bunhoLink;

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

        public OUT2016U00PatientLinkingContentInfo() { }

        public OUT2016U00PatientLinkingContentInfo(String hospCodeLink, String bunhoLink)
        {
            this._hospCodeLink = hospCodeLink;
            this._bunhoLink = bunhoLink;
        }

    }
}