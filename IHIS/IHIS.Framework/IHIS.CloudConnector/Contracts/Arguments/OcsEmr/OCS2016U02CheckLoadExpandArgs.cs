using System;
using IHIS.CloudConnector.Contracts.Models.OcsEmr;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.OcsEmr
{
    public class OCS2016U02CheckLoadExpandArgs : IContractArgs
    {
        private String _hospCode;
        private String _language;

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public String Language
        {
            get { return this._language; }
            set { this._language = value; }
        }

        public OCS2016U02CheckLoadExpandArgs() { }

        public OCS2016U02CheckLoadExpandArgs(String hospCode, String language)
        {
            this._hospCode = hospCode;
            this._language = language;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCS2016U02CheckLoadExpandRequest();
        }
    }
}