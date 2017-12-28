using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    public class ORDERTRANSAPICancelOrdersArgs : IContractArgs
    {
        private String _bunho;
        private String _pkout1001;
        private String _performDate;
        private String _orcaIp;
        private String _orcaPort;
        private String _orcaUser;
        private String _orcaPassword;

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public String Pkout1001
        {
            get { return this._pkout1001; }
            set { this._pkout1001 = value; }
        }

        public String PerformDate
        {
            get { return this._performDate; }
            set { this._performDate = value; }
        }

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

        public String OrcaPassword
        {
            get { return this._orcaPassword; }
            set { this._orcaPassword = value; }
        }

        public ORDERTRANSAPICancelOrdersArgs() { }

        public ORDERTRANSAPICancelOrdersArgs(String bunho, String pkout1001, String performDate, String orcaIp, String orcaPort, String orcaUser, String orcaPassword)
        {
            this._bunho = bunho;
            this._pkout1001 = pkout1001;
            this._performDate = performDate;
            this._orcaIp = orcaIp;
            this._orcaPort = orcaPort;
            this._orcaUser = orcaUser;
            this._orcaPassword = orcaPassword;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.ORDERTRANSAPICancelOrdersRequest();
        }
    }
}