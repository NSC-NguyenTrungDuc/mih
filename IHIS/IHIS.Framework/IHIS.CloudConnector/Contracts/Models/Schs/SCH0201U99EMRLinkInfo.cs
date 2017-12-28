using System;

namespace IHIS.CloudConnector.Contracts.Models.Schs
{
    [Serializable]
    public class SCH0201U99EMRLinkInfo
    {
        private String _bunho;
        private String _hospCodeLink;

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

        public SCH0201U99EMRLinkInfo() { }

        public SCH0201U99EMRLinkInfo(String bunho, String hospCodeLink)
        {
            this._bunho = bunho;
            this._hospCodeLink = hospCodeLink;
        }

    }
}