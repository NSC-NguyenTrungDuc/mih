namespace IHIS.OCSO
{
    using IHIS.OCSO.Properties;
    using System;
    using System.Windows.Forms;

    public partial class OCS2015U42 : Form
    {
        private readonly long commentId;

        private readonly int position;

        private readonly int length;

        private readonly bool isNew;

        public CheckBox EmailCheckBox
        {
            get { return checkBox1; }
        }

        public TextBox TxtRecordLog
        {
            get { return this.txtComment; }
        }

        private OCS2015U44 _parent;

        public OCS2015U42(OCS2015U44 parent)
            : this()
        {
            _parent = parent;
        }

        public OCS2015U42()
        {
            InitializeComponent();
            this.lbError.Visible = false;
        }

        public OCS2015U42(long commentId, int position, int length, string comment, bool isNew)
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
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.TxtRecordLog.Text.Trim()))
            {
                this.DialogResult = DialogResult.None;
                this.lbError.Visible = true;
            }
            if (this.TxtRecordLog.Text.Trim().Length > 128)
            {
                this.DialogResult = DialogResult.None;
                this.lbError.Text = string.Format(Resources.CMO_M14, " " + 128 + " ");
                this.lbError.Visible = true;
            }
        }
    }
}
