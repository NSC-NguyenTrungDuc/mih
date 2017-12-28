using System;
using IHIS.CloudConnector.Contracts.Models.OcsEmr;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.OcsEmr
{
    public class OCS2015U00GetHtmlContentArgs : IContractArgs
    {
        private String _formatType;
        private String _tplType;

        public String FormatType
        {
            get { return this._formatType; }
            set { this._formatType = value; }
        }

        public String TplType
        {
            get { return this._tplType; }
            set { this._tplType = value; }
        }

        public OCS2015U00GetHtmlContentArgs() { }

        public OCS2015U00GetHtmlContentArgs(String formatType, String tplType)
        {
            this._formatType = formatType;
            this._tplType = tplType;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCS2015U00GetHtmlContentRequest();
        }
    }
}