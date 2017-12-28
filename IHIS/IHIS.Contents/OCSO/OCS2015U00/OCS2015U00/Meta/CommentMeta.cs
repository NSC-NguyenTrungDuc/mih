namespace IHIS.OCSO.Meta
{
    using System;

    public class CommentMeta : UserData
    {
        private int length;

        private string author;

        private string comment;

        private long id;

        public CommentMeta()
            : base(CustomMarkType.Comment, null)
        {
            
        }

        public CommentMeta(int length, string author, string comment) : base(CustomMarkType.Comment, null)
        {
            this.length = length;
            this.author = author;
            this.comment = comment;
            id = new DateTime().Millisecond;
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
    }
}