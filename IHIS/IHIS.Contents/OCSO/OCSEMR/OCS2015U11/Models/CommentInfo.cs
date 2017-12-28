using System;
using EmrDocker.Glossary;

namespace EmrDocker.Models
{
    [Serializable]
    public class CommentInfo
    {
        private string _commentId;
        private string _tagId;
        private string _author;
        private string _title;
        private string _comment;
        private string _userId;
        private string _gwa;
        private string _gwaName;
        private string _naewonDate;
        private bool _isOfDoctor;
        private string _pkout;
        public string CommentId
        {
            get { return _commentId; }
            set { _commentId = value; }
        }
        public string TagId
        {
            get { return _tagId; }
            set { _tagId = value; }
        }

        public string Author
        {
            get { return _author; }
            set { _author = value; }
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public string Comment
        {
            get { return _comment; }
            set { _comment = value; }
        }

        public string UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }

        public string Gwa
        {
            get { return _gwa; }
            set { _gwa = value; }
        }
        public string GwaName
        {
            get { return _gwaName; }
            set { _gwaName = value; }
        }

        public string NaewonDate
        {
            get { return _naewonDate; }
            set { _naewonDate = value; }
        }

        public bool IsOfDoctor
        {
            get { return _isOfDoctor; }
            set { _isOfDoctor = value; }
        }

        public string Pkout
        {
            get { return _pkout; }
            set { _pkout = value; }
        }

        public CommentInfo() { }

        public CommentInfo(string tagId, string author, string title, string comment, string userId, string gwa, string gwaName, string naewonDate, bool isDoctor, string pkout)
        {
            _tagId = tagId;
            _author = author;
            _title = title;
            _comment = comment;
            _userId = userId;
            _gwa = gwa;
            _gwaName = gwaName;
            _naewonDate = naewonDate;
            _isOfDoctor = isDoctor;
            _pkout = pkout;
        }
    }
}