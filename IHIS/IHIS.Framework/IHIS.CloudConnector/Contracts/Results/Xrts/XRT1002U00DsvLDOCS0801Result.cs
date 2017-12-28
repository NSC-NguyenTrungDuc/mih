using System;
using IHIS.CloudConnector.Contracts.Models.Xrts;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Xrts
{
    [Serializable]
    public class XRT1002U00DsvLDOCS0801Result : AbstractContractResult
    {
        private List<XRT1002U00DsvLDOCS0801Info> _dsvLdItem = new List<XRT1002U00DsvLDOCS0801Info>();

        public List<XRT1002U00DsvLDOCS0801Info> DsvLdItem
        {
            get { return this._dsvLdItem; }
            set { this._dsvLdItem = value; }
        }

        public XRT1002U00DsvLDOCS0801Result() { }

    }
}