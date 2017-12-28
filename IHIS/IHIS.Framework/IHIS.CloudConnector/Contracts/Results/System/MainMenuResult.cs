using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Results.System
{
    [Serializable]
    public class MainMenuResult : AbstractContractResult
    {
        private List<MainMenuItemInfo> _menuItem = new List<MainMenuItemInfo>();

        public List<MainMenuItemInfo> MenuItem
        {
            get { return _menuItem; }
            set { _menuItem = value; }
        }

        public MainMenuResult(List<MainMenuItemInfo> menuItem)
        {
            MenuItem = menuItem;
        }

        public MainMenuResult()
        {
        } 
    }
}