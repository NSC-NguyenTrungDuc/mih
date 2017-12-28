using System;
using IHIS.CloudConnector.Contracts.Models.System;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.System
{
    [Serializable]
    public class MainFormGetSuperAdminMenuItemResult : AbstractContractResult
    {
        private List<MainFormGetMainMenuItemInfo> _menuItem = new List<MainFormGetMainMenuItemInfo>();

        public List<MainFormGetMainMenuItemInfo> MenuItem
        {
            get { return this._menuItem; }
            set { this._menuItem = value; }
        }

        public MainFormGetSuperAdminMenuItemResult() { }

    }
}