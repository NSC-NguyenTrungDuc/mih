using System;

namespace IHIS.CloudConnector.Contracts.Models.Schs
{
    [Serializable]
    public class SCH0201U99BookingInfo
    {
        private String _bunhoLink;
        private String _hangmogName;
        private String _reserDate;
        private String _reserTime;
        private String _moveComment;

        public String BunhoLink
        {
            get { return this._bunhoLink; }
            set { this._bunhoLink = value; }
        }

        public String HangmogName
        {
            get { return this._hangmogName; }
            set { this._hangmogName = value; }
        }

        public String ReserDate
        {
            get { return this._reserDate; }
            set { this._reserDate = value; }
        }

        public String ReserTime
        {
            get { return this._reserTime; }
            set { this._reserTime = value; }
        }

        public String MoveComment
        {
            get { return this._moveComment; }
            set { this._moveComment = value; }
        }

        public SCH0201U99BookingInfo() { }

        public SCH0201U99BookingInfo(String bunhoLink, String hangmogName, String reserDate, String reserTime, String moveComment)
        {
            this._bunhoLink = bunhoLink;
            this._hangmogName = hangmogName;
            this._reserDate = reserDate;
            this._reserTime = reserTime;
            this._moveComment = moveComment;
        }

    }
}