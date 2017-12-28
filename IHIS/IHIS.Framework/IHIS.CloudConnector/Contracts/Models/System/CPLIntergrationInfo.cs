using System;

namespace IHIS.CloudConnector.Contracts.Models.System
{
    public class CPLIntergrationInfo
    {
        private String _cplSpecimenAuto;
        private String _cplDevBlood;
        private String _cplDevUrine;
        private String _cplDevBio;
        private String _cplServer;
        private String _cplPort;
        private String _cplDatabase;
        private String _cplUserId;
        private String _cplPassword;

        public String CplSpecimenAuto
        {
            get { return this._cplSpecimenAuto; }
            set { this._cplSpecimenAuto = value; }
        }

        public String CplDevBlood
        {
            get { return this._cplDevBlood; }
            set { this._cplDevBlood = value; }
        }

        public String CplDevUrine
        {
            get { return this._cplDevUrine; }
            set { this._cplDevUrine = value; }
        }

        public String CplDevBio
        {
            get { return this._cplDevBio; }
            set { this._cplDevBio = value; }
        }

        public String CplServer
        {
            get { return this._cplServer; }
            set { this._cplServer = value; }
        }

        public String CplPort
        {
            get { return this._cplPort; }
            set { this._cplPort = value; }
        }

        public String CplDatabase
        {
            get { return this._cplDatabase; }
            set { this._cplDatabase = value; }
        }

        public String CplUserId
        {
            get { return this._cplUserId; }
            set { this._cplUserId = value; }
        }

        public String CplPassword
        {
            get { return this._cplPassword; }
            set { this._cplPassword = value; }
        }

        public CPLIntergrationInfo() { }

        public CPLIntergrationInfo(String cplSpecimenAuto, String cplDevBlood, String cplDevUrine, String cplDevBio, String cplServer, String cplPort, String cplDatabase, String cplUserId, String cplPassword)
        {
            this._cplSpecimenAuto = cplSpecimenAuto;
            this._cplDevBlood = cplDevBlood;
            this._cplDevUrine = cplDevUrine;
            this._cplDevBio = cplDevBio;
            this._cplServer = cplServer;
            this._cplPort = cplPort;
            this._cplDatabase = cplDatabase;
            this._cplUserId = cplUserId;
            this._cplPassword = cplPassword;
        }

    }
}