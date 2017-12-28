using System;

namespace IHIS.CloudConnector.Contracts.Models.System
{
    public class OrcaInfo
    {
        private String _orcaIp;
        private String _orcaUser;
        private String _orcaPassword;
        private String _orcaPort;
        private String _orcaHospCode;
        private String _orcaPortRcvClaim;
        private String _orcaCloudYn;

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

        public String OrcaPort
        {
            get { return this._orcaPort; }
            set { this._orcaPort = value; }
        }

        public String OrcaHospCode
        {
            get { return this._orcaHospCode; }
            set { this._orcaHospCode = value; }
        }

        public String OrcaPortRcvClaim
        {
            get { return this._orcaPortRcvClaim; }
            set { this._orcaPortRcvClaim = value; }
        }

        public String OrcaCloudYn
        {
            get { return this._orcaCloudYn; }
            set { this._orcaCloudYn = value; }
        }

        public OrcaInfo() { }

        public OrcaInfo(String orcaIp, String orcaUser, String orcaPassword, String orcaPort, String orcaHospCode, String orcaPortRcvClaim, String orcaCloudYn)
        {
            this._orcaIp = orcaIp;
            this._orcaUser = orcaUser;
            this._orcaPassword = orcaPassword;
            this._orcaPort = orcaPort;
            this._orcaHospCode = orcaHospCode;
            this._orcaPortRcvClaim = orcaPortRcvClaim;
            this._orcaCloudYn = orcaCloudYn;
        }

    }
}