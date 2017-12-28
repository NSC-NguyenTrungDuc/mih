namespace IHIS.OCSO
{
    using System;
    using System.Windows.Forms;

    public partial class frmComment : Form
    {
        private readonly long commentId;

        private readonly int position;

        private readonly int length;

        private readonly bool isNew;

        public delegate void CommentUpdateHandler(object sender, CommentEventArgs e);
        public event CommentUpdateHandler CommentUpdated;

        public frmComment(long commentId, int position, int length, string comment, bool isNew)
        {
            this.commentId = commentId;
            this.position = position;
            this.length = length;
            this.isNew = isNew;
            InitializeComponent();
            txtComment.Text = comment;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (CommentUpdated != null)
            {
                CommentUpdated(this, new CommentEventArgs(commentId, true, position, length, txtComment.Text, isNew));
            }
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            txtComment.Text.Trim();
            if (CommentUpdated != null)
            {
                CommentUpdated(this, new CommentEventArgs(commentId, false, position, length, txtComment.Text, isNew));
            }
            this.Close();
        }
    }

    public class CommentEventArgs : EventArgs
    {
        private readonly long commentId;

        private readonly bool cancel;

        private readonly int position;

        private readonly int length;

        private readonly string comment;

        private readonly bool isNew;

        public CommentEventArgs(long commentId, bool cancel, int position, int length, string comment, bool isNew)
        {
            this.commentId = commentId;
            this.cancel = cancel;
            this.position = position;
            this.length = length;
            this.comment = comment;
            this.isNew = isNew;
        }

        public long CommentId
        {
            get
            {
                return commentId;
            }
        }

        public bool Cancel
        {
            get
            {
                return cancel;
            }
        }

        public string Comment
        {
            get
            {
                return comment;
            }
        }

        public bool IsNew
        {
            get
            {
                return isNew;
            }
        }

        public int Position
        {
            get
            {
                return position;
            }
        }

        public int Length
        {
            get
            {
                return length;
            }
        }
    }
}
