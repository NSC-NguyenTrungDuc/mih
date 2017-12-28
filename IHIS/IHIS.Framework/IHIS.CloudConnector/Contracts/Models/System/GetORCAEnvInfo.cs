using System;

namespace IHIS.CloudConnector.Contracts.Models.System
{
    [Serializable]
    public class GetORCAEnvInfo
    {
        private String _orcaIp;
        private String _orcaPort;
        private String _orcaUser;
        private String _orcaPwd;

        public String OrcaIp
        {
            get { return this._orcaIp; }
            set { this._orcaIp = value; }
        }

        public String OrcaPort
        {
            get { return this._orcaPort; }
            set { this._orcaPort = value; }
        }

        public String OrcaUser
        {
            get { return this._orcaUser; }
            set { this._orcaUser = value; }
        }

        public String OrcaPwd
        {
            get { return this._orcaPwd; }
            set { this._orcaPwd = value; }
        }

        public GetORCAEnvInfo() { }

        public GetORCAEnvInfo(String orcaIp, String orcaPort, String orcaUser, String orcaPwd)
        {
            this._orcaIp = orcaIp;
            this._orcaPort = orcaPort;
            this._orcaUser = orcaUser;
            this._orcaPwd = orcaPwd;
        }

    }
}