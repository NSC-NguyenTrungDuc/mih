using System;
using IHIS.CloudConnector.Contracts.Models.Xrts;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Xrts
{
    public class XRT0201U00LoadLinkArgs : IContractArgs
    {
        private String _bunho;
        private String _date;
        private String _client;

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public String Date
        {
            get { return this._date; }
            set { this._date = value; }
        }

        public String Client
        {
            get { return this._client; }
            set { this._client = value; }
        }

        public XRT0201U00LoadLinkArgs() { }

        public XRT0201U00LoadLinkArgs(String bunho, String date, String client)
        {
            this._bunho = bunho;
            this._date = date;
            this._client = client;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.XRT0201U00LoadLinkRequest();
        }
    }
}