using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    public class NUR2016CheckExitsEMRLinkArgs : IContractArgs
    {
        private String _hospCode;
        private String _bunho;
        private String _hospCodeLink;
        private String _bunhoLink;

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public String HospCodeLink
        {
            get { return this._hospCodeLink; }
            set { this._hospCodeLink = value; }
        }

        public String BunhoLink
        {
            get { return this._bunhoLink; }
            set { this._bunhoLink = value; }
        }

        public NUR2016CheckExitsEMRLinkArgs() { }

        public NUR2016CheckExitsEMRLinkArgs(String hospCode, String bunho, String hospCodeLink, String bunhoLink)
        {
            this._hospCode = hospCode;
            this._bunho = bunho;
            this._hospCodeLink = hospCodeLink;
            this._bunhoLink = bunhoLink;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.NUR2016CheckExitsEMRLinkRequest();
        }
    }
}