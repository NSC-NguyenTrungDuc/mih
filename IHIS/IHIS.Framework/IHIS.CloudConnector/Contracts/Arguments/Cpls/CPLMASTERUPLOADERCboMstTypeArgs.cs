using System;
using IHIS.CloudConnector.Contracts.Models.Cpls;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Cpls
{
    public class CPLMASTERUPLOADERCboMstTypeArgs : IContractArgs
    {
        private Boolean _isPopup;

        public Boolean IsPopup
        {
            get { return this._isPopup; }
            set { this._isPopup = value; }
        }

        public CPLMASTERUPLOADERCboMstTypeArgs() { }

        public CPLMASTERUPLOADERCboMstTypeArgs(Boolean isPopup)
        {
            this._isPopup = isPopup;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.CPLMASTERUPLOADERCboMstTypeRequest();
        }
    }
}