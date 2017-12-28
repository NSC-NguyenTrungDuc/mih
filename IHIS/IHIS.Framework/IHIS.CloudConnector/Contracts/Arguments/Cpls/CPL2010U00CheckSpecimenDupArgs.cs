using System;
using IHIS.CloudConnector.Contracts.Models.Cpls;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Cpls
{
    public class CPL2010U00CheckSpecimenDupArgs : IContractArgs
    {
        private String _jundalGubunText;

        public String JundalGubunText
        {
            get { return this._jundalGubunText; }
            set { this._jundalGubunText = value; }
        }

        public CPL2010U00CheckSpecimenDupArgs() { }

        public CPL2010U00CheckSpecimenDupArgs(String jundalGubunText)
        {
            this._jundalGubunText = jundalGubunText;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.CPL2010U00CheckSpecimenDupRequest();
        }
    }
}