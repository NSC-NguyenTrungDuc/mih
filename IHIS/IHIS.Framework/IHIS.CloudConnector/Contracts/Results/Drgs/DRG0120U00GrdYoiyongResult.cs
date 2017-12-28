using System;
using IHIS.CloudConnector.Contracts.Models.Drgs;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Drgs
{
    public class DRG0120U00GrdYoiyongResult : AbstractContractResult
    {
        private List<DRG0120U00Grd0120Item3Info> _grdYoiyongList = new List<DRG0120U00Grd0120Item3Info>();

        public List<DRG0120U00Grd0120Item3Info> GrdYoiyongList
        {
            get { return this._grdYoiyongList; }
            set { this._grdYoiyongList = value; }
        }

        public DRG0120U00GrdYoiyongResult() { }

    }
}