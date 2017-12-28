using System;

namespace IHIS.CloudConnector.Contracts.Models.System
{
    [Serializable]
    public class MisaInfo
    {
        private String _misaIp;
        private String _misaUser;
        private String _misaPwd;
        private String _misaDbInsurName;
        private String _misaInstanceName;
        private String _misaDbNonInsurName;

        public String MisaIp
        {
            get { return this._misaIp; }
            set { this._misaIp = value; }
        }

        public String MisaUser
        {
            get { return this._misaUser; }
            set { this._misaUser = value; }
        }

        public String MisaPwd
        {
            get { return this._misaPwd; }
            set { this._misaPwd = value; }
        }

        public String MisaDbInsurName
        {
            get { return this._misaDbInsurName; }
            set { this._misaDbInsurName = value; }
        }

        public String MisaInstanceName
        {
            get { return this._misaInstanceName; }
            set { this._misaInstanceName = value; }
        }

        public String MisaDbNonInsurName
        {
            get { return this._misaDbNonInsurName; }
            set { this._misaDbNonInsurName = value; }
        }

        public MisaInfo() { }

        public MisaInfo(String misaIp, String misaUser, String misaPwd, String misaDbInsurName, String misaInstanceName, String misaDbNonInsurName)
        {
            this._misaIp = misaIp;
            this._misaUser = misaUser;
            this._misaPwd = misaPwd;
            this._misaDbInsurName = misaDbInsurName;
            this._misaInstanceName = misaInstanceName;
            this._misaDbNonInsurName = misaDbNonInsurName;
        }

    }
}