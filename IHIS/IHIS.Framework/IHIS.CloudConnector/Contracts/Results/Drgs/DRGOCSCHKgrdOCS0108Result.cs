using System;
using IHIS.CloudConnector.Contracts.Models.Drgs;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Drgs
{
    public class DRGOCSCHKgrdOCS0108Result : AbstractContractResult
    {
        private List<DRGOCSCHKgrdOCS0108Info> _listInfo = new List<DRGOCSCHKgrdOCS0108Info>();

        public List<DRGOCSCHKgrdOCS0108Info> ListInfo
        {
            get { return this._listInfo; }
            set { this._listInfo = value; }
        }

        public DRGOCSCHKgrdOCS0108Result() { }

    }
}