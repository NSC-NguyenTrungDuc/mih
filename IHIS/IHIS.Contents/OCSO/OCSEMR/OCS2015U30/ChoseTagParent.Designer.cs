//namespace OCS2015U30
namespace IHIS.OCSO
{
    partial class ChoseTagParent
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlChoseTagParent = new System.Windows.Forms.Panel();
            this.cblParentLst = new System.Windows.Forms.CheckedListBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlChoseTagParent.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlChoseTagParent
            // 
            this.pnlChoseTagParent.AutoScroll = true;
            this.pnlChoseTagParent.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pnlChoseTagParent.Controls.Add(this.cblParentLst);
            this.pnlChoseTagParent.Location = new System.Drawing.Point(12, 12);
            this.pnlChoseTagParent.Name = "pnlChoseTagParent";
            this.pnlChoseTagParent.Size = new System.Drawing.Size(260, 237);
            this.pnlChoseTagParent.TabIndex = 0;
            // 
            // cblParentLst
            // 
            this.cblParentLst.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.cblParentLst.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cblParentLst.FormattingEnabled = true;
            this.cblParentLst.Location = new System.Drawing.Point(0, 0);
            this.cblParentLst.Name = "cblParentLst";
            this.cblParentLst.Size = new System.Drawing.Size(260, 237);
            this.cblParentLst.TabIndex = 0;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(197, 256);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(116, 256);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "キャンセル";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ChoseTagParent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 282);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.pnlChoseTagParent);
            this.Name = "ChoseTagParent";
            this.Text = "ChoseTagParent";
            this.pnlChoseTagParent.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlChoseTagParent;
        private System.Windows.Forms.CheckedListBox cblParentLst;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;

    }
}