using System;
using IHIS.CloudConnector.Contracts.Models.Cpls;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Cpls
{
    public class CPL3010U01GrdHangmogArgs : IContractArgs
    {
        private String _requestKey;
        private String _specimenSer;
        private String _uitakCode;

        public String RequestKey
        {
            get { return this._requestKey; }
            set { this._requestKey = value; }
        }

        public String SpecimenSer
        {
            get { return this._specimenSer; }
            set { this._specimenSer = value; }
        }

        public String UitakCode
        {
            get { return this._uitakCode; }
            set { this._uitakCode = value; }
        }

        public CPL3010U01GrdHangmogArgs() { }

        public CPL3010U01GrdHangmogArgs(String requestKey, String specimenSer, String uitakCode)
        {
            this._requestKey = requestKey;
            this._specimenSer = specimenSer;
            this._uitakCode = uitakCode;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.CPL3010U01GrdHangmogRequest();
        }
    }
}