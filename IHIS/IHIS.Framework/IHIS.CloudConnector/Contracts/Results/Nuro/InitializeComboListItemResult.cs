using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
    public class InitializeComboListItemResult : AbstractContractResult
    {
        private List<ComboListItemInfo> _comboDepartmentItem = new List<ComboListItemInfo>();
        private List<ComboListItemInfo> _comboTypeItem = new List<ComboListItemInfo>();
        private List<ComboListItemInfo> _comboTimeItem = new List<ComboListItemInfo>();
        private List<ComboListItemInfo> _comboTelItem = new List<ComboListItemInfo>();
        private List<ComboListItemInfo> _comboChojaeItem = new List<ComboListItemInfo>();

        public List<ComboListItemInfo> ComboDepartmentItem
        {
            get { return this._comboDepartmentItem; }
            set { this._comboDepartmentItem = value; }
        }

        public List<ComboListItemInfo> ComboTypeItem
        {
            get { return this._comboTypeItem; }
            set { this._comboTypeItem = value; }
        }

        public List<ComboListItemInfo> ComboTimeItem
        {
            get { return this._comboTimeItem; }
            set { this._comboTimeItem = value; }
        }

        public List<ComboListItemInfo> ComboTelItem
        {
            get { return this._comboTelItem; }
            set { this._comboTelItem = value; }
        }

        public List<ComboListItemInfo> ComboChojaeItem
        {
            get { return this._comboChojaeItem; }
            set { this._comboChojaeItem = value; }
        }

        public InitializeComboListItemResult() { }

    }
}