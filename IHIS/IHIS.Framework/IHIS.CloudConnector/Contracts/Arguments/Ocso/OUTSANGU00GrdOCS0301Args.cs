using System;
using IHIS.CloudConnector.Contracts.Models.Ocso;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocso
{
    public class OUTSANGU00GrdOCS0301Args : IContractArgs
    {
        private String _memb;
        private String _sangCode;
        private String _yaksokCode;
        private String _inputTab;

        public String Memb
        {
            get { return this._memb; }
            set { this._memb = value; }
        }

        public String SangCode
        {
            get { return this._sangCode; }
            set { this._sangCode = value; }
        }

        public String YaksokCode
        {
            get { return this._yaksokCode; }
            set { this._yaksokCode = value; }
        }

        public String InputTab
        {
            get { return this._inputTab; }
            set { this._inputTab = value; }
        }

        public OUTSANGU00GrdOCS0301Args() { }

        public OUTSANGU00GrdOCS0301Args(String memb, String sangCode, String yaksokCode, String inputTab)
        {
            this._memb = memb;
            this._sangCode = sangCode;
            this._yaksokCode = yaksokCode;
            this._inputTab = inputTab;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OUTSANGU00GrdOCS0301Request();
        }
    }
}