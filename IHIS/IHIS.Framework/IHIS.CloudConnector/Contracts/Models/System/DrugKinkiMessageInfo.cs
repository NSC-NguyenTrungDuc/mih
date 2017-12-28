using System;

namespace IHIS.CloudConnector.Contracts.Models.System
{
    [Serializable]
    public class DrugKinkiMessageInfo
    {
        private String _drugId;
        private String _branchNumber;
        private String _warningLevel;
        private String _kinkiId;
        private String _message;
        private String _category;

        public String DrugId
        {
            get { return this._drugId; }
            set { this._drugId = value; }
        }

        public String BranchNumber
        {
            get { return this._branchNumber; }
            set { this._branchNumber = value; }
        }

        public String WarningLevel
        {
            get { return this._warningLevel; }
            set { this._warningLevel = value; }
        }

        public String KinkiId
        {
            get { return this._kinkiId; }
            set { this._kinkiId = value; }
        }

        public String Message
        {
            get { return this._message; }
            set { this._message = value; }
        }

        public String Category
        {
            get { return this._category; }
            set { this._category = value; }
        }

        public DrugKinkiMessageInfo() { }

        public DrugKinkiMessageInfo(String drugId, String branchNumber, String warningLevel, String kinkiId, String message, String category)
        {
            this._drugId = drugId;
            this._branchNumber = branchNumber;
            this._warningLevel = warningLevel;
            this._kinkiId = kinkiId;
            this._message = message;
            this._category = category;
        }

    }
}