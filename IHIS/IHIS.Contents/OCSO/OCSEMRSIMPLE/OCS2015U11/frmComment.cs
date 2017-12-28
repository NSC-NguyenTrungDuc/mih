using EmrDocker;
using EmrDockerS;

namespace IHIS.OCSO
{
    using System;
    using System.Windows.Forms;

    public partial class frmComment : Form
    {
        private readonly string tagId;

        private readonly int position;

        private readonly bool isNew;

        public delegate void CommentUpdateHandler(object sender, CommentEventArgs e);
        public event CommentUpdateHandler CommentUpdated;

        public frmComment(string tagId, string title, string comment, bool isNew)
        {
            this.tagId = tagId;
            this.isNew = isNew;
            InitializeComponent();
            txtComment.Text = comment;
            txtTitle.Text = title;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //if (CommentUpdated != null)
            //{
            //    CommentUpdated(this, new CommentEventArgs(tagId, true, position, length, txtComment.Text, isNew));
            //}
            this.Close();
        }

        protected override void OnActivated(EventArgs e)
        {
            txtTitle.Focus();
            txtTitle.SelectionStart = txtTitle.TextLength;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            lbAlert.Visible = true;
            lbAlert.Text = string.Empty;
            if (this.txtComment.Text.Trim().Length > 128)
            {
                this.lbAlert.Text = Resources.CMO_M14;
                return;
            }
            if (this.txtComment.Text.Trim().Length == 0)
            {
                lbAlert.Text = Resources.CONTENT_BLANK_WARN;
                return;
            }

            if (this.txtTitle.Text.Trim().Length == 0)
            {
                lbAlert.Text = Resources.TITLE_BLANK_WARN;
                return;
            }
            if (this.txtTitle.Text.Trim().Length > 64)
            {
                this.lbAlert.Text = Resources.CMO_M14;
                return;
            }

            if (CommentUpdated != null)
            {
                CommentUpdated(this, new CommentEventArgs(tagId, false, txtComment.Text.Trim(), isNew, txtTitle.Text.Trim()));
            }
            this.Close();
        }
    }

    public class CommentEventArgs : EventArgs
    {
        private readonly string tagId;

        private readonly bool cancel;

        private readonly string comment;

        private readonly bool isNew;

        private readonly string title;

        public CommentEventArgs(string tagId, bool cancel, string comment, bool isNew, string title)
        {
            this.tagId = tagId;
            this.cancel = cancel;
            this.comment = comment;
            this.isNew = isNew;
            this.title = title;
        }

        public string TagId
        {
            get
            {
                return tagId;
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

        public string Title
        {
            get
            {
                return title;
            }
        }
    }
}
