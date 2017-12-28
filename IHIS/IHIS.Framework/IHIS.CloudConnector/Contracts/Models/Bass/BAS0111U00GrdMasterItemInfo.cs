using System;

namespace IHIS.CloudConnector.Contracts.Models.Bass
{
    [Serializable]
    public class BAS0111U00GrdMasterItemInfo
    {
        private String _johapGubun;
        private String _johap;
        private String _johapName;

        public String JohapGubun
        {
            get { return this._johapGubun; }
            set { this._johapGubun = value; }
        }

        public String Johap
        {
            get { return this._johap; }
            set { this._johap = value; }
        }

        public String JohapName
        {
            get { return this._johapName; }
            set { this._johapName = value; }
        }

        public BAS0111U00GrdMasterItemInfo() { }

        public BAS0111U00GrdMasterItemInfo(String johapGubun, String johap, String johapName)
        {
            this._johapGubun = johapGubun;
            this._johap = johap;
            this._johapName = johapName;
        }

    }
}