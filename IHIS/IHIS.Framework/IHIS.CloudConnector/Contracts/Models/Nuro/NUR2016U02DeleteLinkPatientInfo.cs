using System;

namespace IHIS.CloudConnector.Contracts.Models.Nuro
{
    [Serializable]
    public class NUR2016U02DeleteLinkPatientInfo
    {
        private String _bunhoLink;
        private String _hospCodeLink;

        public String BunhoLink
        {
            get { return this._bunhoLink; }
            set { this._bunhoLink = value; }
        }

        public String HospCodeLink
        {
            get { return this._hospCodeLink; }
            set { this._hospCodeLink = value; }
        }

        public NUR2016U02DeleteLinkPatientInfo() { }

        public NUR2016U02DeleteLinkPatientInfo(String bunhoLink, String hospCodeLink)
        {
            this._bunhoLink = bunhoLink;
            this._hospCodeLink = hospCodeLink;
        }

    }
}