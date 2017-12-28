using System;

namespace IHIS.CloudConnector.Contracts.Models.OcsEmr
{
    public class OCS2015U00GetDataDosageInfo
    {
        private String _fkout1001;
        private String _inputtabAndGroupser;
        private String _bogyongName;

        public String Fkout1001
        {
            get { return this._fkout1001; }
            set { this._fkout1001 = value; }
        }

        public String InputtabAndGroupser
        {
            get { return this._inputtabAndGroupser; }
            set { this._inputtabAndGroupser = value; }
        }

        public String BogyongName
        {
            get { return this._bogyongName; }
            set { this._bogyongName = value; }
        }

        public OCS2015U00GetDataDosageInfo() { }

        public OCS2015U00GetDataDosageInfo(String fkout1001, String inputtabAndGroupser, String bogyongName)
        {
            this._fkout1001 = fkout1001;
            this._inputtabAndGroupser = inputtabAndGroupser;
            this._bogyongName = bogyongName;
        }

    }
}