using System;
using System.Collections.Generic;
using System.Text;

namespace IHIS.OCSA
{
    public class DOC0101R00 : IHIS.Framework.XScreen
    {
        private IHIS.Framework.XEditGridCell xEditGridCell1;
        private IHIS.Framework.XEditGridCell xEditGridCell2;
        private IHIS.Framework.XPanel xPanel1;
        private IHIS.Framework.XPanel xPanel2;
        private IHIS.Framework.XPanel xPanel3;
        private IHIS.Framework.XDataWindow xDataWindow1;
        private IHIS.Framework.XPanel xPanel4;
        private IHIS.Framework.XEditGrid xEditGrid1;

        private void InitializeComponent()
        {
            this.xEditGrid1 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.xDataWindow1 = new IHIS.Framework.XDataWindow();
            this.xPanel4 = new IHIS.Framework.XPanel();
            ((System.ComponentModel.ISupportInitialize)(this.xEditGrid1)).BeginInit();
            this.xPanel3.SuspendLayout();
            this.xPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // xEditGrid1
            // 
            this.xEditGrid1.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2});
            this.xEditGrid1.ColPerLine = 2;
            this.xEditGrid1.Cols = 2;
            this.xEditGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xEditGrid1.FixedRows = 1;
            this.xEditGrid1.HeaderHeights.Add(21);
            this.xEditGrid1.Location = new System.Drawing.Point(0, 0);
            this.xEditGrid1.Name = "xEditGrid1";
            this.xEditGrid1.QuerySQL = "SELECT CERT_JNCD, \r\n       CERT_JNNM\r\n  FROM DOC0101\r\n WHERE HOSP_CODE = FN_ADM_L" +
                "OAD_HOSP_CODE()";
            this.xEditGrid1.Rows = 2;
            this.xEditGrid1.Size = new System.Drawing.Size(225, 428);
            this.xEditGrid1.TabIndex = 0;
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "cert_jncd";
            this.xEditGridCell1.CellWidth = 53;
            this.xEditGridCell1.HeaderText = "CODE";
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "cert_jnnm";
            this.xEditGridCell2.CellWidth = 149;
            this.xEditGridCell2.Col = 1;
            this.xEditGridCell2.HeaderText = "文書名";
            // 
            // xPanel1
            // 
            this.xPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.xPanel1.Location = new System.Drawing.Point(0, 0);
            this.xPanel1.Name = "xPanel1";
            this.xPanel1.Size = new System.Drawing.Size(960, 62);
            this.xPanel1.TabIndex = 1;
            // 
            // xPanel2
            // 
            this.xPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.xPanel2.Location = new System.Drawing.Point(0, 490);
            this.xPanel2.Name = "xPanel2";
            this.xPanel2.Size = new System.Drawing.Size(960, 100);
            this.xPanel2.TabIndex = 2;
            // 
            // xPanel3
            // 
            this.xPanel3.Controls.Add(this.xEditGrid1);
            this.xPanel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.xPanel3.Location = new System.Drawing.Point(0, 62);
            this.xPanel3.Name = "xPanel3";
            this.xPanel3.Size = new System.Drawing.Size(225, 428);
            this.xPanel3.TabIndex = 3;
            // 
            // xDataWindow1
            // 
            this.xDataWindow1.DataWindowObject = "";
            this.xDataWindow1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xDataWindow1.LibraryList = "";
            this.xDataWindow1.Location = new System.Drawing.Point(0, 0);
            this.xDataWindow1.Name = "xDataWindow1";
            this.xDataWindow1.Size = new System.Drawing.Size(735, 428);
            this.xDataWindow1.TabIndex = 4;
            this.xDataWindow1.Text = "xDataWindow1";
            // 
            // xPanel4
            // 
            this.xPanel4.Controls.Add(this.xDataWindow1);
            this.xPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xPanel4.Location = new System.Drawing.Point(225, 62);
            this.xPanel4.Name = "xPanel4";
            this.xPanel4.Size = new System.Drawing.Size(735, 428);
            this.xPanel4.TabIndex = 5;
            // 
            // DOC0101R00
            // 
            this.Controls.Add(this.xPanel4);
            this.Controls.Add(this.xPanel3);
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.xPanel1);
            this.Name = "DOC0101R00";
            ((System.ComponentModel.ISupportInitialize)(this.xEditGrid1)).EndInit();
            this.xPanel3.ResumeLayout(false);
            this.xPanel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}
