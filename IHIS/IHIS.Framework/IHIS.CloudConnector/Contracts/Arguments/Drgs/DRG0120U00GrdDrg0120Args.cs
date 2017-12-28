using System;
using IHIS.CloudConnector.Contracts.Models.Drgs;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Drgs
{
    public class DRG0120U00GrdDrg0120Args : IContractArgs
    {
        private String _bunryu1;
        private String _hospCode;

        public String Bunryu1
        {
            get { return this._bunryu1; }
            set { this._bunryu1 = value; }
        }

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public DRG0120U00GrdDrg0120Args() { }

        public DRG0120U00GrdDrg0120Args(String bunryu1, String hospCode)
        {
            this._bunryu1 = bunryu1;
            this._hospCode = hospCode;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.DRG0120U00GrdDrg0120Request();
        }
    }
}