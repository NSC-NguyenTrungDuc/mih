using System;

namespace IHIS.CloudConnector.Contracts.Models.Schs
{
    [Serializable]
    public class Schs0201U99CheckORCAEnvInfoInfo
    {
        private String _ifCodeGwa;
        private String _ifCodeDoctor;
        private String _orcaIp;
        private String _orcaUser;
        private String _orcaPassword;
        private String _accType;

        public String IfCodeGwa
        {
            get { return this._ifCodeGwa; }
            set { this._ifCodeGwa = value; }
        }

        public String IfCodeDoctor
        {
            get { return this._ifCodeDoctor; }
            set { this._ifCodeDoctor = value; }
        }

        public String OrcaIp
        {
            get { return this._orcaIp; }
            set { this._orcaIp = value; }
        }

        public String OrcaUser
        {
            get { return this._orcaUser; }
            set { this._orcaUser = value; }
        }

        public String OrcaPassword
        {
            get { return this._orcaPassword; }
            set { this._orcaPassword = value; }
        }

        public String AccType
        {
            get { return this._accType; }
            set { this._accType = value; }
        }

        public Schs0201U99CheckORCAEnvInfoInfo() { }

        public Schs0201U99CheckORCAEnvInfoInfo(String ifCodeGwa, String ifCodeDoctor, String orcaIp, String orcaUser, String orcaPassword, String accType)
        {
            this._ifCodeGwa = ifCodeGwa;
            this._ifCodeDoctor = ifCodeDoctor;
            this._orcaIp = orcaIp;
            this._orcaUser = orcaUser;
            this._orcaPassword = orcaPassword;
            this._accType = accType;
        }

    }
}