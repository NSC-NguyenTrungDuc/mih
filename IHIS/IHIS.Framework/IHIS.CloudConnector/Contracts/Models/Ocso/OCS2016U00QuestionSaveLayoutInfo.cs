using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocso
{
    [Serializable]
    public class OCS2016U00QuestionSaveLayoutInfo
    {
        private String _reqDate;
        private String _reqGwa;
        private String _consultGwa;
        private String _consultDoctor;
        private String _consultHospCode;
        private String _bunho;
        private String _content;
        private String _grpQuestionId;
        private String _discussionId;
        private String _finishYn;
        private String _dataRowState;

        public String ReqDate
        {
            get { return this._reqDate; }
            set { this._reqDate = value; }
        }

        public String ReqGwa
        {
            get { return this._reqGwa; }
            set { this._reqGwa = value; }
        }

        public String ConsultGwa
        {
            get { return this._consultGwa; }
            set { this._consultGwa = value; }
        }

        public String ConsultDoctor
        {
            get { return this._consultDoctor; }
            set { this._consultDoctor = value; }
        }

        public String ConsultHospCode
        {
            get { return this._consultHospCode; }
            set { this._consultHospCode = value; }
        }

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public String Content
        {
            get { return this._content; }
            set { this._content = value; }
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

        public String FinishYn
        {
            get { return this._finishYn; }
            set { this._finishYn = value; }
        }

        public String DataRowState
        {
            get { return this._dataRowState; }
            set { this._dataRowState = value; }
        }

        public OCS2016U00QuestionSaveLayoutInfo() { }

        public OCS2016U00QuestionSaveLayoutInfo(String reqDate, String reqGwa, String consultGwa, String consultDoctor, String consultHospCode, String bunho, String content, String grpQuestionId, String discussionId, String finishYn, String dataRowState)
        {
            this._reqDate = reqDate;
            this._reqGwa = reqGwa;
            this._consultGwa = consultGwa;
            this._consultDoctor = consultDoctor;
            this._consultHospCode = consultHospCode;
            this._bunho = bunho;
            this._content = content;
            this._grpQuestionId = grpQuestionId;
            this._discussionId = discussionId;
            this._finishYn = finishYn;
            this._dataRowState = dataRowState;
        }

    }
}