using System;

namespace IHIS.CloudConnector.Contracts.Models.Xrts
{
    [Serializable]
    public class XRT1002U00LayCPLInfo
    {
        private String _hangmogName;
        private String _hangmogResult;
        private String _hangmogResultDate;

        public String HangmogName
        {
            get { return this._hangmogName; }
            set { this._hangmogName = value; }
        }

        public String HangmogResult
        {
            get { return this._hangmogResult; }
            set { this._hangmogResult = value; }
        }

        public String HangmogResultDate
        {
            get { return this._hangmogResultDate; }
            set { this._hangmogResultDate = value; }
        }

        public XRT1002U00LayCPLInfo() { }

        public XRT1002U00LayCPLInfo(String hangmogName, String hangmogResult, String hangmogResultDate)
        {
            this._hangmogName = hangmogName;
            this._hangmogResult = hangmogResult;
            this._hangmogResultDate = hangmogResultDate;
        }

    }
}