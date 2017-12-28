using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocso
{
    [Serializable]
    public class OCS2016U00LoadDiscussionInfo
    {
        private String _doctor;
        private String _doctorName;
        private String _content;
        private String _updated;
        private String _editedFlg;
        private String _grpQuestionId;
        private String _discussionId;
        private String _dataRowState;

        public String Doctor
        {
            get { return this._doctor; }
            set { this._doctor = value; }
        }

        public String DoctorName
        {
            get { return this._doctorName; }
            set { this._doctorName = value; }
        }

        public String Content
        {
            get { return this._content; }
            set { this._content = value; }
        }

        public String Updated
        {
            get { return this._updated; }
            set { this._updated = value; }
        }

        public String EditedFlg
        {
            get { return this._editedFlg; }
            set { this._editedFlg = value; }
        }

        public String GrpQuestionId
        {
            get { return this._grpQuestionId; }
            set { this._grpQuestionId = value; }
        }

        public String DiscussionId
        {
            get { return this._discussionId; }
            set { this._discussionId = value; }
        }

        public String DataRowState
        {
            get { return this._dataRowState; }
            set { this._dataRowState = value; }
        }

        public OCS2016U00LoadDiscussionInfo() { }

        public OCS2016U00LoadDiscussionInfo(String doctor, String doctorName, String content, String updated, String editedFlg, String grpQuestionId, String discussionId, String dataRowState)
        {
            this._doctor = doctor;
            this._doctorName = doctorName;
            this._content = content;
            this._updated = updated;
            this._editedFlg = editedFlg;
            this._grpQuestionId = grpQuestionId;
            this._discussionId = discussionId;
            this._dataRowState = dataRowState;
        }

    }
}