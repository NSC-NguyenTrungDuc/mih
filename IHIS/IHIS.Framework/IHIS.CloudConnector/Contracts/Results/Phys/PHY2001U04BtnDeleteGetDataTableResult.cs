using System;
using IHIS.CloudConnector.Contracts.Models.Phys;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Phys
{
    [Serializable]
    public class PHY2001U04BtnDeleteGetDataTableResult : AbstractContractResult
    {
        private List<PHY2001U04BtnDeleteGetDataTableInfo> _tblItem = new List<PHY2001U04BtnDeleteGetDataTableInfo>();

        public List<PHY2001U04BtnDeleteGetDataTableInfo> TblItem
        {
            get { return this._tblItem; }
            set { this._tblItem = value; }
        }

        public PHY2001U04BtnDeleteGetDataTableResult() { }

    }
}