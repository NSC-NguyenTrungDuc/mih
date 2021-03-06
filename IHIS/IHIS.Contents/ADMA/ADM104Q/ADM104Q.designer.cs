using System;
using System.Collections.Generic;
using System.Text;
using IHIS.ADM.Properties;

namespace IHIS.ADMA
{
    public partial class ADM104Q
    {
        private IHIS.Framework.XLabel xLabel4;
        private IHIS.Framework.XDisplayBox dbxUserName;
        private IHIS.Framework.XTextBox txtUserId;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ADM104Q));
            this.xLabel4 = new IHIS.Framework.XLabel();
            this.dbxUserName = new IHIS.Framework.XDisplayBox();
            this.txtUserId = new IHIS.Framework.XTextBox();
            this.btnList = new IHIS.Framework.XButtonList();
            this.lbMsg = new IHIS.Framework.XLabel();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            resources.ApplyResources(this.ImageList, "ImageList");
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "");
            // 
            // xLabel4
            // 
            this.xLabel4.AccessibleDescription = null;
            this.xLabel4.AccessibleName = null;
            resources.ApplyResources(this.xLabel4, "xLabel4");
            this.xLabel4.BackColor = IHIS.Framework.XColor.XScreenBackColor;
            this.xLabel4.Image = null;
            this.xLabel4.Name = "xLabel4";
            // 
            // dbxUserName
            // 
            this.dbxUserName.AccessibleDescription = null;
            this.dbxUserName.AccessibleName = null;
            resources.ApplyResources(this.dbxUserName, "dbxUserName");
            this.dbxUserName.Image = null;
            this.dbxUserName.Name = "dbxUserName";
            // 
            // txtUserId
            // 
            this.txtUserId.AccessibleDescription = null;
            this.txtUserId.AccessibleName = null;
            resources.ApplyResources(this.txtUserId, "txtUserId");
            this.txtUserId.BackgroundImage = null;
            this.txtUserId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.txtUserId_DataValidating);
            // 
            // btnList
            // 
            this.btnList.AccessibleDescription = null;
            this.btnList.AccessibleName = null;
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.BackgroundImage = null;
            this.btnList.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Process, System.Windows.Forms.Shortcut.None, global::IHIS.ADM.Properties.Resources.BTN_CONFIRM, -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Close, System.Windows.Forms.Shortcut.None, "", -1, "")});
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // lbMsg
            // 
            this.lbMsg.AccessibleDescription = null;
            this.lbMsg.AccessibleName = null;
            resources.ApplyResources(this.lbMsg, "lbMsg");
            this.lbMsg.BackColor = IHIS.Framework.XColor.XScreenBackColor;
            this.lbMsg.BorderColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.lbMsg.ForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Red);
            this.lbMsg.Image = null;
            this.lbMsg.Name = "lbMsg";
            // 
            // ADM104Q
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.lbMsg);
            this.Controls.Add(this.btnList);
            this.Controls.Add(this.txtUserId);
            this.Controls.Add(this.dbxUserName);
            this.Controls.Add(this.xLabel4);
            this.Name = "ADM104Q";
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.ADM104Q_ScreenOpen);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private IHIS.Framework.XButtonList btnList;
        private IHIS.Framework.XLabel lbMsg;
    }
}
