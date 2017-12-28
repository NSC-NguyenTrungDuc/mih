using System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Bass
{
    public class LoadCbxLanguageArgs : IContractArgs
    {
        private String _propertyCode;
        private String _activeFlg;

        public String PropertyCode
        {
            get { return this._propertyCode; }
            set { this._propertyCode = value; }
        }

        public String ActiveFlg
        {
            get { return this._activeFlg; }
            set { this._activeFlg = value; }
        }

        public LoadCbxLanguageArgs() { }

        public LoadCbxLanguageArgs(String propertyCode, String activeFlg)
        {
            this._propertyCode = propertyCode;
            this._activeFlg = activeFlg;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.LoadCbxLanguageRequest();
        }
    }
}