namespace IHIS.OCSO.Meta
{
    using System;

    public class CommentMeta : UserData
    {
        private int length;

        private string author;

        private string comment;

        private long id;

        private bool _isNew = false;

        private bool _isStart = true;
        private int p1;
        private string p2;
        private string p3;
        private long p4;
        private bool p5;
        private string _userId;
        private string _gwa;
        private string _gwaName;
        private string _naewonDate;

        private string title;

        public CommentMeta()
            : base(CustomMarkType.Comment, null)
        {
            
        }

        public CommentMeta(int length, string author, string comment) : base(CustomMarkType.Comment, null)
        {
            this.length = length;
            this.author = author;
            this.comment = comment;
            id = DateTime.Now.Ticks;
        }

        public CommentMeta(int length, string author, string comment, bool isNew) : base(CustomMarkType.Comment, null)
        {
            this.length = length;
            this.author = author;
            this.comment = comment;
            id = DateTime.Now.Ticks;
            this.IsNew = isNew;
        }
        public CommentMeta(int length, string author, string comment, long commentId)
            : base(CustomMarkType.Comment, null)
        {
            this.length = length;
            this.author = author;
            this.comment = comment;
            id = commentId;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="length"></param>
        /// <param name="author"></param>
        /// <param name="comment"></param>
        /// <param name="commentId"></param>
        /// <param name="isStart"></param>
        /// <param name="userId"></param>
        /// <param name="gwa"></param>
        /// <param name="gwaName"></param>
        /// <param name="naewonDate"></param>
        public CommentMeta(int length, string author, string comment, long commentId, bool isStart, string userId, string gwa, string gwaName, string naewonDate, string title)
            : base(CustomMarkType.Comment, null)
        {
            // TODO: Complete member initialization
            this.length = length;
            this.author = author;
            this.comment = comment;
            id = commentId;
            _isStart = isStart;
            _userId = userId;
            _gwa = gwa;
            _gwaName = gwaName;
            this._naewonDate = naewonDate;
            this.title = title;
            id = DateTime.Now.Ticks;
        }

        public long Id
        {
            get
            {
                return id;
            }
            set
            {
                this.id = value;
            }
        }

        public int Length
        {
            get
            {
                return length;
            }
            set
            {
                this.length = value;
            }
        }

        public string Author
        {
            get
            {
                return author;
            }
            set
            {
                this.author = value;
            }
        }

        public string Comment
        {
            get
            {
                return comment;
            }
            set
            {
                this.comment = value;
            }
        }

        public bool IsNew
        {
            get
            {
                return _isNew;
            }
            set
            {
                this._isNew = value;
            }
        }

        /// <summary>
        /// Flag shows if this comment is at start position of range or end position.
        /// </summary>
        public bool IsStart
        {
            get { return _isStart; }
            set { _isStart = value; }
        }

        public string UserId {
            get { return _userId; }
            set { this._userId = value; }
        }
        public string Gwa {
            get { return _gwa; }
            set { _gwa = value; }
        }
        public string GwaName {
            get { return _gwaName; }
            set { _gwaName = value; }
        }

        public string NaewonDate
        {
            get
            {
                return _naewonDate;
            }
            set
            {
                _naewonDate = value;
            }
        }

        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }
    }
}