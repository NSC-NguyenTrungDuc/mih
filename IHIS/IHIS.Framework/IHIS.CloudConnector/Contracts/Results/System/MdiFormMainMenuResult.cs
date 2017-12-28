using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Results.System
{
    [Serializable]
    public class MdiFormMainMenuResult : AbstractContractResult
    {
        private Boolean _result;
        private String _msg;
        private List<MdiFormMenuItemInfo> _menuItemInfo = new List<MdiFormMenuItemInfo>();
        private List<MdiFormMainMenuItemInfo> _mainMenuItemInfo = new List<MdiFormMainMenuItemInfo>();

        public Boolean Result
        {
            get { return this._result; }
            set { this._result = value; }
        }

        public String Msg
        {
            get { return this._msg; }
            set { this._msg = value; }
        }

        public List<MdiFormMenuItemInfo> MenuItemInfo
        {
            get { return this._menuItemInfo; }
            set { this._menuItemInfo = value; }
        }

        public List<MdiFormMainMenuItemInfo> MainMenuItemInfo
        {
            get { return this._mainMenuItemInfo; }
            set { this._mainMenuItemInfo = value; }
        }

        public MdiFormMainMenuResult() { }

    }
}