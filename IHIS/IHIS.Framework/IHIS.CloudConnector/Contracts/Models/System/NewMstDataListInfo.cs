using System;

namespace IHIS.CloudConnector.Contracts.Models.System
{
    [Serializable]
    public class NewMstDataListInfo
    {
        private String _screenName;

        public String ScreenName
        {
            get { return this._screenName; }
            set { this._screenName = value; }
        }

        public NewMstDataListInfo() { }

        public NewMstDataListInfo(String screenName)
        {
            this._screenName = screenName;
        }

    }
}