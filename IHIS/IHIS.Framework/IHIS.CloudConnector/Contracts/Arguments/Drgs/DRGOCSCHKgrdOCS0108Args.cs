using System;
using IHIS.CloudConnector.Contracts.Models.Drgs;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Drgs
{
    public class DRGOCSCHKgrdOCS0108Args : IContractArgs
    {
        private String _hospCode;
        private String _hangmogCode;
        private String _hangmogStartdate;

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public String HangmogCode
        {
            get { return this._hangmogCode; }
            set { this._hangmogCode = value; }
        }

        public String HangmogStartdate
        {
            get { return this._hangmogStartdate; }
            set { this._hangmogStartdate = value; }
        }

        public DRGOCSCHKgrdOCS0108Args() { }

        public DRGOCSCHKgrdOCS0108Args(String hospCode, String hangmogCode, String hangmogStartdate)
        {
            this._hospCode = hospCode;
            this._hangmogCode = hangmogCode;
            this._hangmogStartdate = hangmogStartdate;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.DRGOCSCHKgrdOCS0108Request();
        }
    }
}