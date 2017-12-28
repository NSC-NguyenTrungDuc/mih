using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocso
{
    public class OCS4001U00SangNameInfo
    {
        private String _sangName;

        public String SangName
        {
            get { return this._sangName; }
            set { this._sangName = value; }
        }

        public OCS4001U00SangNameInfo() { }

        public OCS4001U00SangNameInfo(String sangName)
        {
            this._sangName = sangName;
        }

    }
}