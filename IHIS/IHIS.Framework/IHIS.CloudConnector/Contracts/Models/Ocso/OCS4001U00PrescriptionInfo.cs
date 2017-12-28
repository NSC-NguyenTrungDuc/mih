using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocso
{
    public class OCS4001U00PrescriptionInfo
    {
        private String _hangmongName;
        private String _bogyongName;

        public String HangmongName
        {
            get { return this._hangmongName; }
            set { this._hangmongName = value; }
        }

        public String BogyongName
        {
            get { return this._bogyongName; }
            set { this._bogyongName = value; }
        }

        public OCS4001U00PrescriptionInfo() { }

        public OCS4001U00PrescriptionInfo(String hangmongName, String bogyongName)
        {
            this._hangmongName = hangmongName;
            this._bogyongName = bogyongName;
        }

    }
}