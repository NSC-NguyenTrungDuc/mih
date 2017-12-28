namespace EmrDocker
{
    partial class PopupEmrHistory
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
            this.calSchedule = new IHIS.Framework.XCalendar();
            this.xButtonList1 = new IHIS.Framework.XButtonList();
            this.xButtonList2 = new IHIS.Framework.XButtonList();
            ((System.ComponentModel.ISupportInitialize)(this.calSchedule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList2)).BeginInit();
            this.SuspendLayout();
            // 
            // calSchedule
            // 
            this.calSchedule.EnableMultiSelection = false;
            this.calSchedule.Location = new System.Drawing.Point(12, 12);
            this.calSchedule.MaxDate = new System.DateTime(2026, 1, 19, 0, 0, 0, 0);
            this.calSchedule.MinDate = new System.DateTime(2006, 1, 19, 0, 0, 0, 0);
            this.calSchedule.Name = "calSchedule";
            this.calSchedule.Size = new System.Drawing.Size(255, 190);
            this.calSchedule.TabIndex = 4;
            this.calSchedule.ToggleSelection = true;
            // 
            // xButtonList1
            // 
            this.xButtonList1.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Print, System.Windows.Forms.Shortcut.None, "In", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Close, System.Windows.Forms.Shortcut.None, "Đóng", -1, "")});
            this.xButtonList1.Location = new System.Drawing.Point(103, 212);
            this.xButtonList1.Name = "xButtonList1";
            this.xButtonList1.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.xButtonList1.Size = new System.Drawing.Size(163, 34);
            this.xButtonList1.TabIndex = 5;
            this.xButtonList1.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.xButtonList1_ButtonClick);
            // 
            // xButtonList2
            // 
            this.xButtonList2.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Print, System.Windows.Forms.Shortcut.None, "In tất cả", -1, "")});
            this.xButtonList2.Location = new System.Drawing.Point(12, 212);
            this.xButtonList2.Name = "xButtonList2";
            this.xButtonList2.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.xButtonList2.Size = new System.Drawing.Size(85, 34);
            this.xButtonList2.TabIndex = 6;
            this.xButtonList2.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.xButtonList2_ButtonClick);
            // 
            // PopupEmrHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.xButtonList2);
            this.Controls.Add(this.xButtonList1);
            this.Controls.Add(this.calSchedule);
            this.Name = "PopupEmrHistory";
            this.Text = "PopupEmrHistory";
            ((System.ComponentModel.ISupportInitialize)(this.calSchedule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private IHIS.Framework.XCalendar calSchedule;
        private IHIS.Framework.XButtonList xButtonList1;
        private IHIS.Framework.XButtonList xButtonList2;


    }
}