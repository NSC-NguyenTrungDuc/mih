using System;
using IHIS.CloudConnector.Contracts.Models.Ocso;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Ocso
{
    public class OUTSANGU00GrdOCS0301Result : AbstractContractResult
    {
        private List<OUTSANGU00GrdOCS0301Info> _listInfo = new List<OUTSANGU00GrdOCS0301Info>();

        public List<OUTSANGU00GrdOCS0301Info> ListInfo
        {
            get { return this._listInfo; }
            set { this._listInfo = value; }
        }

        public OUTSANGU00GrdOCS0301Result() { }

    }
}