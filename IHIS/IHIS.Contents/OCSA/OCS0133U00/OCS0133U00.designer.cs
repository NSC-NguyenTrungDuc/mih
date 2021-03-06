using System;
using System.Collections.Generic;
using System.Text;

namespace IHIS.OCSA
{
    partial class OCS0133U00
    {
        private IHIS.Framework.XPanel xPanel1;
        private IHIS.Framework.XPanel xPanel2;
        private IHIS.Framework.XButtonList xButtonList1;
        private IHIS.Framework.XEditGridCell xEditGridCell1;
        private IHIS.Framework.XEditGridCell xEditGridCell2;
        private IHIS.Framework.XEditGridCell xEditGridCell3;
        private IHIS.Framework.XEditGridCell xEditGridCell4;
        private IHIS.Framework.XEditGridCell xEditGridCell5;
        private IHIS.Framework.XEditGridCell xEditGridCell7;
        private IHIS.Framework.XEditGridCell xEditGridCell8;
        private IHIS.Framework.XEditGridCell xEditGridCell9;
        private IHIS.Framework.XEditGridCell xEditGridCell10;
        private IHIS.Framework.XEditGridCell xEditGridCell11;
        private IHIS.Framework.XEditGridCell xEditGridCell15;
        private IHIS.Framework.XEditGridCell xEditGridCell17;
        private IHIS.Framework.XEditGrid grdOCS0133;
        private System.Windows.Forms.PictureBox pictureBox1;
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.Container components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Designer generated code
        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OCS0133U00));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.xButtonList1 = new IHIS.Framework.XButtonList();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.grdOCS0133 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).BeginInit();
            this.xPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0133)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // xPanel1
            // 
            this.xPanel1.Controls.Add(this.xButtonList1);
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Name = "xPanel1";
            // 
            // xButtonList1
            // 
            resources.ApplyResources(this.xButtonList1, "xButtonList1");
            this.xButtonList1.IsVisibleReset = false;
            this.xButtonList1.Name = "xButtonList1";
            this.xButtonList1.PerformerType = IHIS.Framework.FunctionPerformerType.Entry;
            this.xButtonList1.PostButtonClick += new IHIS.Framework.PostButtonClickEventHandler(this.xButtonList1_PostButtonClick);
            this.xButtonList1.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.xButtonList1_ButtonClick);
            // 
            // xPanel2
            // 
            this.xPanel2.Controls.Add(this.grdOCS0133);
            this.xPanel2.Controls.Add(this.pictureBox1);
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.DrawBorder = true;
            this.xPanel2.Name = "xPanel2";
            // 
            // grdOCS0133
            // 
            this.grdOCS0133.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell7,
            this.xEditGridCell8,
            this.xEditGridCell9,
            this.xEditGridCell10,
            this.xEditGridCell11,
            this.xEditGridCell15,
            this.xEditGridCell17});
            this.grdOCS0133.ColPerLine = 10;
            this.grdOCS0133.Cols = 10;
            this.grdOCS0133.ExecuteQuery = null;
            this.grdOCS0133.FixedRows = 1;
            this.grdOCS0133.FocusColumnName = "input_control";
            this.grdOCS0133.HeaderHeights.Add(32);
            resources.ApplyResources(this.grdOCS0133, "grdOCS0133");
            this.grdOCS0133.Name = "grdOCS0133";
            this.grdOCS0133.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdOCS0133.ParamList")));
            this.grdOCS0133.QuerySQL = resources.GetString("grdOCS0133.QuerySQL");
            this.grdOCS0133.Rows = 2;
            this.grdOCS0133.PreSaveLayout += new IHIS.Framework.GridRecordEventHandler(this.grdOCS0133_SaveStarting);
            this.grdOCS0133.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdOCS0133_GridColumnChanged);
            this.grdOCS0133.SaveEnd += new IHIS.Framework.SaveEndEventHandler(this.grdOCS0133_SaveEnd);
            this.grdOCS0133.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdOCS0133_QueryStarting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellLen = 1;
            this.xEditGridCell1.CellName = "input_control";
            this.xEditGridCell1.CellWidth = 70;
            this.xEditGridCell1.ExecuteQuery = null;
            this.xEditGridCell1.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.ImeMode = IHIS.Framework.ColumnImeMode.OnlyEngUpper;
            this.xEditGridCell1.IsNotNull = true;
            this.xEditGridCell1.IsUpdatable = false;
            this.xEditGridCell1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellLen = 40;
            this.xEditGridCell2.CellName = "input_control_name";
            this.xEditGridCell2.CellWidth = 303;
            this.xEditGridCell2.Col = 1;
            this.xEditGridCell2.ExecuteQuery = null;
            this.xEditGridCell2.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.IsNotNull = true;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "specimen_cr_yn";
            this.xEditGridCell3.CellWidth = 50;
            this.xEditGridCell3.Col = 2;
            this.xEditGridCell3.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell3.ExecuteQuery = null;
            this.xEditGridCell3.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.IsNotNull = true;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "suryang_cr_yn";
            this.xEditGridCell4.CellWidth = 45;
            this.xEditGridCell4.Col = 3;
            this.xEditGridCell4.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell4.ExecuteQuery = null;
            this.xEditGridCell4.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.IsNotNull = true;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "ord_danui_cr_yn";
            this.xEditGridCell5.CellWidth = 45;
            this.xEditGridCell5.Col = 4;
            this.xEditGridCell5.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell5.ExecuteQuery = null;
            this.xEditGridCell5.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.IsNotNull = true;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "dv_cr_yn";
            this.xEditGridCell7.CellWidth = 45;
            this.xEditGridCell7.Col = 6;
            this.xEditGridCell7.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell7.ExecuteQuery = null;
            this.xEditGridCell7.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            this.xEditGridCell7.IsNotNull = true;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "nalsu_cr_yn";
            this.xEditGridCell8.CellWidth = 45;
            this.xEditGridCell8.Col = 7;
            this.xEditGridCell8.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell8.ExecuteQuery = null;
            this.xEditGridCell8.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            this.xEditGridCell8.IsNotNull = true;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "jusa_cr_yn";
            this.xEditGridCell9.CellWidth = 45;
            this.xEditGridCell9.Col = 8;
            this.xEditGridCell9.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell9.ExecuteQuery = null;
            this.xEditGridCell9.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            this.xEditGridCell9.IsNotNull = true;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "bogyong_code_cr_yn";
            this.xEditGridCell10.CellWidth = 65;
            this.xEditGridCell10.Col = 9;
            this.xEditGridCell10.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell10.ExecuteQuery = null;
            this.xEditGridCell10.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell10, "xEditGridCell10");
            this.xEditGridCell10.IsNotNull = true;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "toiwon_drg_cr_yn";
            this.xEditGridCell11.CellWidth = 45;
            this.xEditGridCell11.Col = 5;
            this.xEditGridCell11.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell11.ExecuteQuery = null;
            this.xEditGridCell11.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell11, "xEditGridCell11");
            this.xEditGridCell11.IsNotNull = true;
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.CellName = "portable_cr_yn";
            this.xEditGridCell15.CellWidth = 45;
            this.xEditGridCell15.Col = -1;
            this.xEditGridCell15.ExecuteQuery = null;
            this.xEditGridCell15.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell15, "xEditGridCell15");
            this.xEditGridCell15.IsVisible = false;
            this.xEditGridCell15.Row = -1;
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.CellName = "amt_cr_yn";
            this.xEditGridCell17.CellWidth = 45;
            this.xEditGridCell17.Col = -1;
            this.xEditGridCell17.ExecuteQuery = null;
            this.xEditGridCell17.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell17, "xEditGridCell17");
            this.xEditGridCell17.IsVisible = false;
            this.xEditGridCell17.Row = -1;
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // OCS0133U00
            // 
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.xPanel1);
            this.Name = "OCS0133U00";
            resources.ApplyResources(this, "$this");
            this.xPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).EndInit();
            this.xPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0133)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion
    }
}
