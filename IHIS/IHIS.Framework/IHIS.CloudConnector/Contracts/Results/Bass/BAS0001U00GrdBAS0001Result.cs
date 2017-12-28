using System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.System;


namespace IHIS.CloudConnector.Contracts.Results.Bass
{
    public class BAS0001U00GrdBAS0001Result : AbstractContractResult
    {
        private List<BAS0001U00GrdBAS0001Info> _itemInfo = new List<BAS0001U00GrdBAS0001Info>();
        private List<ComboListItemInfo> _bankInfo = new List<ComboListItemInfo>();

        public List<BAS0001U00GrdBAS0001Info> ItemInfo
        {
            get { return this._itemInfo; }
            set { this._itemInfo = value; }
        }

        public List<ComboListItemInfo> BankInfo
        {
            get { return this._bankInfo; }
            set { this._bankInfo = value; }
        }

        public BAS0001U00GrdBAS0001Result() { }

    }
}