using System;
using IHIS.CloudConnector.Contracts.Models.Xrts;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Xrts
{
    [Serializable]
    public class XRT1002U00LayXRT0123Result : AbstractContractResult
    {
        private List<XRT1002U00LayXRT0123Info> _layXrtItem = new List<XRT1002U00LayXRT0123Info>();

        public List<XRT1002U00LayXRT0123Info> LayXrtItem
        {
            get { return this._layXrtItem; }
            set { this._layXrtItem = value; }
        }

        public XRT1002U00LayXRT0123Result() { }

    }
}