using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    public class OUT0101U02ComboListResult : AbstractContractResult
    {
        private List<ComboListItemInfo> _sexComboListItem = new List<ComboListItemInfo>();
        private List<ComboListItemInfo> _bunhoComboListItem = new List<ComboListItemInfo>();
        private List<ComboListItemInfo> _telComboListItem = new List<ComboListItemInfo>();
        private List<ComboListItemInfo> _boninComboListItem = new List<ComboListItemInfo>();
        private List<ComboListItemInfo> _billingCodeType = new List<ComboListItemInfo>();

        public List<ComboListItemInfo> SexComboListItem
        {
            get { return this._sexComboListItem; }
            set { this._sexComboListItem = value; }
        }

        public List<ComboListItemInfo> BunhoComboListItem
        {
            get { return this._bunhoComboListItem; }
            set { this._bunhoComboListItem = value; }
        }

        public List<ComboListItemInfo> TelComboListItem
        {
            get { return this._telComboListItem; }
            set { this._telComboListItem = value; }
        }

        public List<ComboListItemInfo> BoninComboListItem
        {
            get { return this._boninComboListItem; }
            set { this._boninComboListItem = value; }
        }

        public List<ComboListItemInfo> BillingCodeType
        {
            get { return this._billingCodeType; }
            set { this._billingCodeType = value; }
        }

        public OUT0101U02ComboListResult() { }

    }
}