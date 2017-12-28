using System;
using IHIS.CloudConnector.Contracts.Models.Bill;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Bill
{
    public class LoadComboBIL2016U02Args : IContractArgs
    {
        private String _comboType;

        public String ComboType
        {
            get { return this._comboType; }
            set { this._comboType = value; }
        }

        public LoadComboBIL2016U02Args() { }

        public LoadComboBIL2016U02Args(String comboType)
        {
            this._comboType = comboType;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.LoadComboBIL2016U02Request();
        }
    }
}