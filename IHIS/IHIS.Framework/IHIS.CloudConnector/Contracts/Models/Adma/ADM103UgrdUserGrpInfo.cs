using System;

namespace IHIS.CloudConnector.Contracts.Models.Adma
{
    [Serializable]
    public class ADM103UgrdUserGrpInfo
    {
        private String _userGroup;
        private String _groupNm;
        private String _rowState;

        public String UserGroup
        {
            get { return this._userGroup; }
            set { this._userGroup = value; }
        }

        public String GroupNm
        {
            get { return this._groupNm; }
            set { this._groupNm = value; }
        }

        public String RowState
        {
            get { return this._rowState; }
            set { this._rowState = value; }
        }

        public ADM103UgrdUserGrpInfo() { }

        public ADM103UgrdUserGrpInfo(String userGroup, String groupNm, String rowState)
        {
            this._userGroup = userGroup;
            this._groupNm = groupNm;
            this._rowState = rowState;
        }

    }
}