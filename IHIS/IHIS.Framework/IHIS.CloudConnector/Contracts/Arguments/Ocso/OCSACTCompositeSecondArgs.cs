using System;
using IHIS.CloudConnector.Contracts.Models.Ocso;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocso
{
    public class OCSACTCompositeSecondArgs : IContractArgs
    {
        private OCSACTGrdJearyoArgs _grdJearyoParam;
        private OCSACTGrdSangByungArgs _grdSangParam;
        private OCSACTDefaultJearyoArgs _grdDefaultParam;

        public OCSACTGrdJearyoArgs GrdJearyoParam
        {
            get { return this._grdJearyoParam; }
            set { this._grdJearyoParam = value; }
        }

        public OCSACTGrdSangByungArgs GrdSangParam
        {
            get { return this._grdSangParam; }
            set { this._grdSangParam = value; }
        }

        public OCSACTDefaultJearyoArgs GrdDefaultParam
        {
            get { return this._grdDefaultParam; }
            set { this._grdDefaultParam = value; }
        }

        public OCSACTCompositeSecondArgs() { }

        public OCSACTCompositeSecondArgs(OCSACTGrdJearyoArgs grdJearyoParam, OCSACTGrdSangByungArgs grdSangParam, OCSACTDefaultJearyoArgs grdDefaultParam)
        {
            this._grdJearyoParam = grdJearyoParam;
            this._grdSangParam = grdSangParam;
            this._grdDefaultParam = grdDefaultParam;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCSACTCompositeSecondRequest();
        }
    }
}