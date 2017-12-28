using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
    public class OUT1001R01LayOut0101Result : AbstractContractResult
    {
        private List<OUT1001R01LayOut0101Info> _layoutList = new List<OUT1001R01LayOut0101Info>();

        public List<OUT1001R01LayOut0101Info> LayoutList
        {
            get { return this._layoutList; }
            set { this._layoutList = value; }
        }

        public OUT1001R01LayOut0101Result() { }

    }
}