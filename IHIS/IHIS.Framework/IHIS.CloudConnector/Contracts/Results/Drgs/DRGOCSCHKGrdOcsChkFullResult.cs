using System;
using IHIS.CloudConnector.Contracts.Models.Drgs;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Drgs
{
    public class DRGOCSCHKGrdOcsChkFullResult : AbstractContractResult
    {
        private List<DRGOCSCHKGrdOcsChkFullInfo> _listItem = new List<DRGOCSCHKGrdOcsChkFullInfo>();

        public List<DRGOCSCHKGrdOcsChkFullInfo> ListItem
        {
            get { return this._listItem; }
            set { this._listItem = value; }
        }

        public DRGOCSCHKGrdOcsChkFullResult() { }

    }
}