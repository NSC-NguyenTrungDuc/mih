using System;
using IHIS.CloudConnector.Contracts.Models.Drgs;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Drgs
{
    public class DRG0120U00GrdNaebogResult : AbstractContractResult
    {
        private List<DRG0120U00Grd0120Item2Info> _grdNaebogList = new List<DRG0120U00Grd0120Item2Info>();

        public List<DRG0120U00Grd0120Item2Info> GrdNaebogList
        {
            get { return this._grdNaebogList; }
            set { this._grdNaebogList = value; }
        }

        public DRG0120U00GrdNaebogResult() { }

    }
}