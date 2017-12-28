using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
    public class OCS0203U00LayOCS0212Result : AbstractContractResult
    {
        private List<OCS0203U00LayOCS0212Info> _infoList = new List<OCS0203U00LayOCS0212Info>();

        public List<OCS0203U00LayOCS0212Info> InfoList
        {
            get { return this._infoList; }
            set { this._infoList = value; }
        }

        public OCS0203U00LayOCS0212Result() { }

    }
}