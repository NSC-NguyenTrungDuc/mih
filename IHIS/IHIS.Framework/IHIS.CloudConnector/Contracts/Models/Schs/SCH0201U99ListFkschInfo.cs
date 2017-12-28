using System;

namespace IHIS.CloudConnector.Contracts.Models.Schs
{
    [Serializable]
    public class SCH0201U99ListFkschInfo
    {
        private String _fkshc;

        public String Fkshc
        {
            get { return this._fkshc; }
            set { this._fkshc = value; }
        }

        public SCH0201U99ListFkschInfo() { }

        public SCH0201U99ListFkschInfo(String fkshc)
        {
            this._fkshc = fkshc;
        }

    }
}