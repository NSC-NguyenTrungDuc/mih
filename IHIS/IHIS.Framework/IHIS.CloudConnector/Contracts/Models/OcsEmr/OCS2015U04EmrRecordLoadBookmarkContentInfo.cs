using System;

namespace IHIS.CloudConnector.Contracts.Models.OcsEmr
{
    [Serializable]
    public class OCS2015U04EmrRecordLoadBookmarkContentInfo
    {
        private String _emrBookmarkId;
        private String _bookmarkText;
        private String _naewonDate;
        private String _sysId;
        private String _userNm;
        private String _gwa;
        private String _gwaName;

        public String EmrBookmarkId
        {
            get { return this._emrBookmarkId; }
            set { this._emrBookmarkId = value; }
        }

        public String BookmarkText
        {
            get { return this._bookmarkText; }
            set { this._bookmarkText = value; }
        }

        public String NaewonDate
        {
            get { return this._naewonDate; }
            set { this._naewonDate = value; }
        }

        public String SysId
        {
            get { return this._sysId; }
            set { this._sysId = value; }
        }

        public String UserNm
        {
            get { return this._userNm; }
            set { this._userNm = value; }
        }

        public String Gwa
        {
            get { return this._gwa; }
            set { this._gwa = value; }
        }

        public String GwaName
        {
            get { return this._gwaName; }
            set { this._gwaName = value; }
        }

        public OCS2015U04EmrRecordLoadBookmarkContentInfo() { }

        public OCS2015U04EmrRecordLoadBookmarkContentInfo(String emrBookmarkId, String bookmarkText, String naewonDate, String sysId, String userNm, String gwa, String gwaName)
        {
            this._emrBookmarkId = emrBookmarkId;
            this._bookmarkText = bookmarkText;
            this._naewonDate = naewonDate;
            this._sysId = sysId;
            this._userNm = userNm;
            this._gwa = gwa;
            this._gwaName = gwaName;
        }

    }
}