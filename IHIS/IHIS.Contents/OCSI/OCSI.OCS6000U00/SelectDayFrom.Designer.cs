namespace IHIS.OCSI
{
    partial class SelectDayFrom
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectDayFrom));
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.nudIlsu = new IHIS.Framework.XNumericUpDown();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.btnList = new IHIS.Framework.XButtonList();
            ((System.ComponentModel.ISupportInitialize)(this.nudIlsu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.SuspendLayout();
            // 
            // xLabel1
            // 
            this.xLabel1.EdgeRounding = false;
            this.xLabel1.Location = new System.Drawing.Point(19, 17);
            this.xLabel1.Name = "xLabel1";
            this.xLabel1.Size = new System.Drawing.Size(96, 24);
            this.xLabel1.TabIndex = 1;
            this.xLabel1.Text = "日次選択";
            this.xLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nudIlsu
            // 
            this.nudIlsu.Font = new System.Drawing.Font("MS UI Gothic", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudIlsu.Location = new System.Drawing.Point(116, 17);
            this.nudIlsu.Name = "nudIlsu";
            this.nudIlsu.Size = new System.Drawing.Size(120, 24);
            this.nudIlsu.TabIndex = 2;
            this.nudIlsu.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // xLabel2
            // 
            this.xLabel2.BackColor = IHIS.Framework.XColor.XDisplayBoxBackColor;
            this.xLabel2.EdgeRounding = false;
            this.xLabel2.Location = new System.Drawing.Point(236, 17);
            this.xLabel2.Name = "xLabel2";
            this.xLabel2.Size = new System.Drawing.Size(40, 24);
            this.xLabel2.TabIndex = 3;
            this.xLabel2.Text = "日次";
            this.xLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnList
            // 
            this.btnList.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.btnList.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Process, System.Windows.Forms.Shortcut.F12, "選択", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Close, System.Windows.Forms.Shortcut.None, "", -1, "")});
            this.btnList.Location = new System.Drawing.Point(291, 12);
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.btnList.Size = new System.Drawing.Size(163, 34);
            this.btnList.TabIndex = 4;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // SelectDayFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(466, 80);
            this.Controls.Add(this.btnList);
            this.Controls.Add(this.xLabel2);
            this.Controls.Add(this.xLabel1);
            this.Controls.Add(this.nudIlsu);
            this.Name = "SelectDayFrom";
            this.Text = "日次選択";
            this.Load += new System.EventHandler(this.SelectDayFrom_Load);
            this.Controls.SetChildIndex(this.nudIlsu, 0);
            this.Controls.SetChildIndex(this.xLabel1, 0);
            this.Controls.SetChildIndex(this.xLabel2, 0);
            this.Controls.SetChildIndex(this.btnList, 0);
            ((System.ComponentModel.ISupportInitialize)(this.nudIlsu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private IHIS.Framework.XLabel xLabel1;
        private IHIS.Framework.XNumericUpDown nudIlsu;
        private IHIS.Framework.XLabel xLabel2;
        private IHIS.Framework.XButtonList btnList;
    }
}