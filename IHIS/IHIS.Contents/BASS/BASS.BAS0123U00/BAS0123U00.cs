#region 사용 NameSpace 지정
using System;
using System.Collections.Generic;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.Windows.Forms.VisualStyles;
using IHIS.BASS.Properties;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Arguments.Bass;
using IHIS.CloudConnector.Contracts.Models.Bass;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.Bass;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.Framework;
#endregion

namespace IHIS.BASS
{
	/// <summary>
	/// BAS0123U00에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class BAS0123U00 : IHIS.Framework.XScreen
	{
		private IHIS.Framework.XPanel xPanel1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private IHIS.Framework.XEditGridCell xEditGridCell1;
		private IHIS.Framework.XEditGridCell xEditGridCell2;
		private IHIS.Framework.XEditGridCell xEditGridCell3;
		private IHIS.Framework.XEditGridCell xEditGridCell4;
		private IHIS.Framework.XEditGridCell xEditGridCell5;
		private IHIS.Framework.XEditGridCell xEditGridCell6;
		private IHIS.Framework.XEditGridCell xEditGridCell7;
		private IHIS.Framework.XEditGridCell xEditGridCell8;
		private IHIS.Framework.XEditGrid grdBAS0123;
		private IHIS.Framework.XLabel xLabel1;
		private IHIS.Framework.XFindBox fbxZipCode;
		private IHIS.Framework.XDisplayBox dbxZipName;
		private IHIS.Framework.XButtonList xButtonList1;
		private IHIS.Framework.XFindWorker fwkZipCode;
		private IHIS.Framework.FindColumnInfo findColumnInfo1;
		private IHIS.Framework.FindColumnInfo findColumnInfo2;
		private IHIS.Framework.FindColumnInfo findColumnInfo3;
		private IHIS.Framework.FindColumnInfo findColumnInfo4;
		private IHIS.Framework.XFindWorker fwkTonggyeCode;
		private IHIS.Framework.FindColumnInfo findColumnInfo5;
		private IHIS.Framework.FindColumnInfo findColumnInfo6;
		private IHIS.Framework.XEditGrid xEditGrid1;
		private IHIS.Framework.XEditGridCell xEditGridCell9;
		private IHIS.Framework.XEditGridCell xEditGridCell10;
		private IHIS.Framework.XEditGridCell xEditGridCell11;
		private IHIS.Framework.XEditGridCell xEditGridCell12;
		private IHIS.Framework.XEditGridCell xEditGridCell13;
		private IHIS.Framework.XEditGridCell xEditGridCell14;
		private IHIS.Framework.XEditGridCell xEditGridCell15;
		private IHIS.Framework.XEditGridCell xEditGridCell16;
        private FindColumnInfo findColumnInfo7;
        private FindColumnInfo findColumnInfo8;
        private FindColumnInfo findColumnInfo9;
        private FindColumnInfo findColumnInfo10;
        private FindColumnInfo findColumnInfo11;
        private FindColumnInfo findColumnInfo12;
        private SingleLayout layTonggyeCode;
        private SingleLayoutItem singleLayoutItem1;
        private SingleLayout layZipCode;
        private SingleLayoutItem singleLayoutItem2;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public BAS0123U00()
		{
			// 이 호출은 Windows Form 디자이너에 필요합니다.
			InitializeComponent();

            // Create ParamList and ExecuteQuery
            grdBAS0123.ParamList = new List<string>(new String[] { "f_zip_code" });
		    grdBAS0123.ExecuteQuery = ExecuteQueryGrdBAS0123;

            layTonggyeCode.ParamList = new List<string>(new String[] { "f_code_type", "f_code" });
		    layTonggyeCode.ExecuteQuery = ExecuteQueryLayTonggyeCode;

            layZipCode.ParamList = new List<string>(new String[] { "f_code" });
		    layZipCode.ExecuteQuery = ExecuteQueryLayZipCode;

		    fwkZipCode.ExecuteQuery = ExecuteQueryFwkZipCode;
		}

		/// <summary>
		/// 사용 중인 모든 리소스를 정리합니다.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Designer generated code
		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다.
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BAS0123U00));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.dbxZipName = new IHIS.Framework.XDisplayBox();
            this.fbxZipCode = new IHIS.Framework.XFindBox();
            this.fwkZipCode = new IHIS.Framework.XFindWorker();
            this.findColumnInfo7 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo8 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo9 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo10 = new IHIS.Framework.FindColumnInfo();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.findColumnInfo1 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo2 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo3 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo4 = new IHIS.Framework.FindColumnInfo();
            this.grdBAS0123 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.fwkTonggyeCode = new IHIS.Framework.XFindWorker();
            this.findColumnInfo11 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo12 = new IHIS.Framework.FindColumnInfo();
            this.xButtonList1 = new IHIS.Framework.XButtonList();
            this.findColumnInfo5 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo6 = new IHIS.Framework.FindColumnInfo();
            this.xEditGrid1 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.layTonggyeCode = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem1 = new IHIS.Framework.SingleLayoutItem();
            this.layZipCode = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem2 = new IHIS.Framework.SingleLayoutItem();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBAS0123)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xEditGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // xPanel1
            // 
            this.xPanel1.Controls.Add(this.dbxZipName);
            this.xPanel1.Controls.Add(this.fbxZipCode);
            this.xPanel1.Controls.Add(this.xLabel1);
            this.xPanel1.Controls.Add(this.pictureBox1);
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.Name = "xPanel1";
            // 
            // dbxZipName
            // 
            resources.ApplyResources(this.dbxZipName, "dbxZipName");
            this.dbxZipName.Name = "dbxZipName";
            // 
            // fbxZipCode
            // 
            this.fbxZipCode.FindWorker = this.fwkZipCode;
            resources.ApplyResources(this.fbxZipCode, "fbxZipCode");
            this.fbxZipCode.Name = "fbxZipCode";
            this.fbxZipCode.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxZipCode_DataValidating);
            this.fbxZipCode.FindSelected += new IHIS.Framework.FindEventHandler(this.fbxZipCode_FindSelected);
            // 
            // fwkZipCode
            // 
            this.fwkZipCode.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo7,
            this.findColumnInfo8,
            this.findColumnInfo9,
            this.findColumnInfo10});
            this.fwkZipCode.ExecuteQuery = null;
            this.fwkZipCode.FormText = Resource.TEXT12;
            this.fwkZipCode.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("fwkZipCode.ParamList")));
            this.fwkZipCode.SearchImeMode = System.Windows.Forms.ImeMode.Inherit;
            this.fwkZipCode.ServerFilter = true;
            // 
            // findColumnInfo7
            // 
            this.findColumnInfo7.ColName = "zip_code";
            this.findColumnInfo7.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo7, "findColumnInfo7");
            // 
            // findColumnInfo8
            // 
            this.findColumnInfo8.ColName = "zip_name1";
            this.findColumnInfo8.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo8, "findColumnInfo8");
            // 
            // findColumnInfo9
            // 
            this.findColumnInfo9.ColName = "zip_name2";
            this.findColumnInfo9.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo9, "findColumnInfo9");
            // 
            // findColumnInfo10
            // 
            this.findColumnInfo10.ColName = "zip_name3";
            this.findColumnInfo10.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo10, "findColumnInfo10");
            // 
            // xLabel1
            // 
            this.xLabel1.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel1.EdgeRounding = false;
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel1.Name = "xLabel1";
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // findColumnInfo1
            // 
            this.findColumnInfo1.ColName = "zip_code";
            this.findColumnInfo1.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo1, "findColumnInfo1");
            // 
            // findColumnInfo2
            // 
            this.findColumnInfo2.ColName = "zip_name1";
            this.findColumnInfo2.ColWidth = 241;
            this.findColumnInfo2.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo2, "findColumnInfo2");
            // 
            // findColumnInfo3
            // 
            this.findColumnInfo3.ColName = "zip_name2";
            this.findColumnInfo3.ColWidth = 285;
            this.findColumnInfo3.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo3, "findColumnInfo3");
            // 
            // findColumnInfo4
            // 
            this.findColumnInfo4.ColName = "zip_name3";
            this.findColumnInfo4.ColWidth = 331;
            this.findColumnInfo4.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo4, "findColumnInfo4");
            // 
            // grdBAS0123
            // 
            this.grdBAS0123.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell6,
            this.xEditGridCell7,
            this.xEditGridCell8});
            this.grdBAS0123.ColPerLine = 7;
            this.grdBAS0123.Cols = 7;
            resources.ApplyResources(this.grdBAS0123, "grdBAS0123");
            this.grdBAS0123.ExecuteQuery = null;
            this.grdBAS0123.FixedRows = 1;
            this.grdBAS0123.HeaderHeights.Add(24);
            this.grdBAS0123.Name = "grdBAS0123";
            this.grdBAS0123.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdBAS0123.ParamList")));
            this.grdBAS0123.QuerySQL = resources.GetString("grdBAS0123.QuerySQL");
            this.grdBAS0123.Rows = 2;
            this.grdBAS0123.ToolTipActive = true;
            this.grdBAS0123.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdBAS0123_GridColumnChanged);
            this.grdBAS0123.SaveEnd += new IHIS.Framework.SaveEndEventHandler(this.grdBAS0123_SaveEnd);
            this.grdBAS0123.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdBAS0123_QueryStarting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellLen = 7;
            this.xEditGridCell1.CellName = "zip_code";
            this.xEditGridCell1.ExecuteQuery = null;
            this.xEditGridCell1.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsNotNull = true;
            this.xEditGridCell1.IsUpdatable = false;
            this.xEditGridCell1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellLen = 60;
            this.xEditGridCell2.CellName = "zip_name1";
            this.xEditGridCell2.CellWidth = 227;
            this.xEditGridCell2.Col = 1;
            this.xEditGridCell2.ExecuteQuery = null;
            this.xEditGridCell2.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellLen = 60;
            this.xEditGridCell3.CellName = "zip_name2";
            this.xEditGridCell3.CellWidth = 274;
            this.xEditGridCell3.Col = 2;
            this.xEditGridCell3.ExecuteQuery = null;
            this.xEditGridCell3.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellLen = 60;
            this.xEditGridCell4.CellName = "zip_name3";
            this.xEditGridCell4.CellWidth = 284;
            this.xEditGridCell4.Col = 3;
            this.xEditGridCell4.ExecuteQuery = null;
            this.xEditGridCell4.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellLen = 60;
            this.xEditGridCell5.CellName = "zip_name_gana1";
            this.xEditGridCell5.CellWidth = 288;
            this.xEditGridCell5.Col = 4;
            this.xEditGridCell5.ExecuteQuery = null;
            this.xEditGridCell5.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellLen = 60;
            this.xEditGridCell6.CellName = "zip_name_gana2";
            this.xEditGridCell6.CellWidth = 284;
            this.xEditGridCell6.Col = 5;
            this.xEditGridCell6.ExecuteQuery = null;
            this.xEditGridCell6.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellLen = 60;
            this.xEditGridCell7.CellName = "zip_name_gana3";
            this.xEditGridCell7.CellWidth = 286;
            this.xEditGridCell7.Col = 6;
            this.xEditGridCell7.ExecuteQuery = null;
            this.xEditGridCell7.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellLen = 5;
            this.xEditGridCell8.CellName = "zip_tonggye";
            this.xEditGridCell8.CellWidth = 85;
            this.xEditGridCell8.Col = -1;
            this.xEditGridCell8.ExecuteQuery = null;
            this.xEditGridCell8.FindWorker = this.fwkTonggyeCode;
            this.xEditGridCell8.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            this.xEditGridCell8.IsVisible = false;
            this.xEditGridCell8.Row = -1;
            this.xEditGridCell8.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fwkTonggyeCode
            // 
            this.fwkTonggyeCode.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo11,
            this.findColumnInfo12});
            this.fwkTonggyeCode.ExecuteQuery = null;
            this.fwkTonggyeCode.InputSQL = resources.GetString("fwkTonggyeCode.InputSQL");
            this.fwkTonggyeCode.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("fwkTonggyeCode.ParamList")));
            this.fwkTonggyeCode.SearchImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.fwkTonggyeCode.ServerFilter = true;
            this.fwkTonggyeCode.QueryStarting += new System.ComponentModel.CancelEventHandler(this.fwkTonggyeCode_QueryStarting);
            // 
            // findColumnInfo11
            // 
            this.findColumnInfo11.ColAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.findColumnInfo11.ColName = "code";
            resources.ApplyResources(this.findColumnInfo11, "findColumnInfo11");
            // 
            // findColumnInfo12
            // 
            this.findColumnInfo12.ColName = "code_name";
            this.findColumnInfo12.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo12, "findColumnInfo12");
            // 
            // xButtonList1
            // 
            resources.ApplyResources(this.xButtonList1, "xButtonList1");
            this.xButtonList1.Name = "xButtonList1";
            this.xButtonList1.PerformerType = IHIS.Framework.FunctionPerformerType.Entry;
            this.xButtonList1.PostButtonClick += new IHIS.Framework.PostButtonClickEventHandler(this.xButtonList1_PostButtonClick);
            this.xButtonList1.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList__ButtonClick);
            // 
            // findColumnInfo5
            // 
            this.findColumnInfo5.ColAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.findColumnInfo5.ColName = "code";
            resources.ApplyResources(this.findColumnInfo5, "findColumnInfo5");
            // 
            // findColumnInfo6
            // 
            this.findColumnInfo6.ColName = "code_name";
            this.findColumnInfo6.ColWidth = 254;
            this.findColumnInfo6.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo6, "findColumnInfo6");
            // 
            // xEditGrid1
            // 
            this.xEditGrid1.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell9,
            this.xEditGridCell10,
            this.xEditGridCell11,
            this.xEditGridCell12,
            this.xEditGridCell13,
            this.xEditGridCell14,
            this.xEditGridCell15,
            this.xEditGridCell16});
            this.xEditGrid1.ColPerLine = 8;
            this.xEditGrid1.Cols = 8;
            resources.ApplyResources(this.xEditGrid1, "xEditGrid1");
            this.xEditGrid1.ExecuteQuery = null;
            this.xEditGrid1.FixedRows = 1;
            this.xEditGrid1.HeaderHeights.Add(24);
            this.xEditGrid1.Name = "xEditGrid1";
            this.xEditGrid1.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("xEditGrid1.ParamList")));
            this.xEditGrid1.Rows = 2;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellLen = 7;
            this.xEditGridCell9.CellName = "zip_code";
            this.xEditGridCell9.ExecuteQuery = null;
            this.xEditGridCell9.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            this.xEditGridCell9.IsNotNull = true;
            this.xEditGridCell9.IsUpdatable = false;
            this.xEditGridCell9.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellLen = 60;
            this.xEditGridCell10.CellName = "zip_name1";
            this.xEditGridCell10.CellWidth = 227;
            this.xEditGridCell10.Col = 1;
            this.xEditGridCell10.ExecuteQuery = null;
            this.xEditGridCell10.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell10, "xEditGridCell10");
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellLen = 60;
            this.xEditGridCell11.CellName = "zip_name2";
            this.xEditGridCell11.CellWidth = 274;
            this.xEditGridCell11.Col = 2;
            this.xEditGridCell11.ExecuteQuery = null;
            this.xEditGridCell11.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell11, "xEditGridCell11");
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellLen = 60;
            this.xEditGridCell12.CellName = "zip_name3";
            this.xEditGridCell12.CellWidth = 284;
            this.xEditGridCell12.Col = 3;
            this.xEditGridCell12.ExecuteQuery = null;
            this.xEditGridCell12.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell12, "xEditGridCell12");
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellLen = 60;
            this.xEditGridCell13.CellName = "zip_name_gana1";
            this.xEditGridCell13.CellWidth = 288;
            this.xEditGridCell13.Col = 4;
            this.xEditGridCell13.ExecuteQuery = null;
            this.xEditGridCell13.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell13, "xEditGridCell13");
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellLen = 60;
            this.xEditGridCell14.CellName = "zip_name_gana2";
            this.xEditGridCell14.CellWidth = 284;
            this.xEditGridCell14.Col = 5;
            this.xEditGridCell14.ExecuteQuery = null;
            this.xEditGridCell14.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell14, "xEditGridCell14");
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.CellLen = 60;
            this.xEditGridCell15.CellName = "zip_name_gana3";
            this.xEditGridCell15.CellWidth = 286;
            this.xEditGridCell15.Col = 6;
            this.xEditGridCell15.ExecuteQuery = null;
            this.xEditGridCell15.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell15, "xEditGridCell15");
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.CellLen = 5;
            this.xEditGridCell16.CellName = "zip_tonggye";
            this.xEditGridCell16.CellWidth = 85;
            this.xEditGridCell16.Col = 7;
            this.xEditGridCell16.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell16.ExecuteQuery = null;
            this.xEditGridCell16.FindWorker = this.fwkTonggyeCode;
            this.xEditGridCell16.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell16, "xEditGridCell16");
            // 
            // layTonggyeCode
            // 
            this.layTonggyeCode.ExecuteQuery = null;
            this.layTonggyeCode.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem1});
            this.layTonggyeCode.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layTonggyeCode.ParamList")));
            this.layTonggyeCode.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layTonggyeCode_QueryStarting);
            // 
            // singleLayoutItem1
            // 
            this.singleLayoutItem1.DataName = "code_name";
            // 
            // layZipCode
            // 
            this.layZipCode.ExecuteQuery = null;
            this.layZipCode.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem2});
            this.layZipCode.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layZipCode.ParamList")));
            this.layZipCode.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layZipCode_QueryStarting);
            this.layZipCode.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.layZipCode_QueryEnd);
            // 
            // singleLayoutItem2
            // 
            this.singleLayoutItem2.BindControl = this.dbxZipName;
            this.singleLayoutItem2.DataName = "dbxZipName";
            // 
            // BAS0123U00
            // 
            this.Controls.Add(this.xButtonList1);
            this.Controls.Add(this.grdBAS0123);
            this.Controls.Add(this.xPanel1);
            this.Controls.Add(this.xEditGrid1);
            resources.ApplyResources(this, "$this");
            this.Name = "BAS0123U00";
            this.Load += new System.EventHandler(this.BAS0123U00_Load);
            this.xPanel1.ResumeLayout(false);
            this.xPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBAS0123)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xEditGrid1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region ZipCode Validation Service

        private void layZipCode_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layZipCode.SetBindVarValue("f_code", this.fbxZipCode.GetDataValue());
        }

        private void layZipCode_QueryEnd(object sender, QueryEndEventArgs e)
        {
            this.xButtonList1.PerformClick(FunctionType.Query);
        }
		#endregion

		#region FindBox Select

		private void fbxZipCode_FindSelected(object sender, IHIS.Framework.FindEventArgs e)
		{
			this.dbxZipName.SetEditValue(e.ReturnValues[1].ToString() + " " + e.ReturnValues[2].ToString() + " " + e.ReturnValues[3].ToString());
            this.grdBAS0123.QueryLayout(false);
		}

		#endregion

		#region XButtonList

		private void xButtonList1_PostButtonClick(object sender, IHIS.Framework.PostButtonClickEventArgs e)
		{
			switch (e.Func)
			{
				case FunctionType.Reset:
					this.fbxZipCode.Focus();
					break;
			}
		}

		#endregion

        private string mHospCode = "";
		private void BAS0123U00_Load(object sender, System.EventArgs e)
		{
            mHospCode = EnvironInfo.HospCode;
            // TODO comment use connect cloud
//            this.SaveLayoutList.Add(this.grdBAS0123);
//            this.grdBAS0123.SavePerformer = new XSavePeformer(this);

			this.fwkTonggyeCode.SetBindVarValue("f_code_type", "REGION_CODE");
			this.layTonggyeCode.SetBindVarValue("f_code_type", "REGION_CODE");
		}

		private void fbxZipCode_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
            this.grdBAS0123.QueryLayout(false);
		}

		#region XEditGrid

		private void grdBAS0123_GridColumnChanged(object sender, IHIS.Framework.GridColumnChangedEventArgs e)
		{
			string name = "";
			string msg  = "";

			switch(e.ColName)
			{
				case "zip_tonggye" :

					if (e.ChangeValue.ToString() == "")
					{
						this.SetMsg("");

						return;
					}

                    this.layTonggyeCode.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
					this.layTonggyeCode.SetBindVarValue("f_code", e.ChangeValue.ToString());

                    if (this.layTonggyeCode.QueryLayout())
					{
						name = this.layTonggyeCode.GetItemValue("code_name").ToString();

						if (name == "")
						{
							msg = (Resource.TEXT1);

							this.SetMsg (msg, MsgType.Error);

							e.Cancel = true;

							return;
						}
					}
					else
					{
						msg = (Resource.TEXT1);

						this.SetMsg (msg, MsgType.Error);

						e.Cancel = true;

						return;
					}

					this.SetMsg("");

					break;
			}
		}
		#endregion

        private void grdBAS0123_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdBAS0123.SetBindVarValue("f_zip_code", this.fbxZipCode.GetDataValue());
        }

        private void fwkTonggyeCode_QueryStarting(object sender, CancelEventArgs e)
        {
            this.fwkTonggyeCode.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.fwkTonggyeCode.SetBindVarValue("f_code_type", "REGION_CODE");
        }

        private void layTonggyeCode_QueryStarting(object sender, CancelEventArgs e)
        {
            this.fwkTonggyeCode.SetBindVarValue("f_code_type", EnvironInfo.HospCode);
            this.fwkTonggyeCode.SetBindVarValue("f_code_type", "REGION_CODE");
        }

        #region XSavePeformer
        private class XSavePeformer : ISavePerformer
        {
            private BAS0123U00 parent = null;

            public XSavePeformer(BAS0123U00 parent)
            {
                this.parent = parent;
            }

            public bool Execute(char callerID, RowDataItem item)
            {
                string cmdText = "";
                object t_dup_yn = "";

                item.BindVarList.Add("q_user_id", UserInfo.UserID);
                item.BindVarList.Add("f_hosp_code", parent.mHospCode);
                switch (callerID)
                {
                    case '1':
                        switch (item.RowState)
                        {
                            case DataRowState.Added:

                                cmdText = @"SELECT 'Y'
                                              FROM DUAL
                                             WHERE EXISTS ( SELECT 'X'
                                                              FROM BAS0123
                                                             WHERE ZIP_CODE  = :f_zip_code
                                                               AND ZIP_NAME1 = :f_zip_name1
                                                               AND ZIP_NAME2 = :f_zip_name2
                                                               AND ZIP_NAME3 = :f_zip_name3 )";

                                t_dup_yn = Service.ExecuteScalar(cmdText, item.BindVarList);

                                if (!TypeCheck.IsNull(t_dup_yn))
                                {
                                    if (t_dup_yn.ToString() == "Y")
                                    {
                                        XMessageBox.Show(Resource.TEXT2+"         : " + item.BindVarList["f_zip_code"].VarValue + "\r\n" +
                                                         Resource.TEXT3+"  : " + item.BindVarList["f_zip_name1"].VarValue + "\r\n" +
                                                         Resource.TEXT4+"  : " + item.BindVarList["f_zip_name2"].VarValue + "\r\n" +
                                                         Resource.TEXT5+"       : " + item.BindVarList["f_zip_name3"].VarValue + "\r\n" +
                                                         Resource.TEXT6, Resource.TEXT7, MessageBoxIcon.Warning);
                                        return false;
                                    }
                                }
                                item.BindVarList.Add("t_zip_code1", item.BindVarList["f_zip_code"].VarValue.Substring(0, 3));
                                item.BindVarList.Add("t_zip_code2", item.BindVarList["f_zip_code"].VarValue.Substring(3, 4));

                                cmdText = @"INSERT INTO BAS0123
                                                 ( SYS_DATE          , SYS_ID            , UPD_DATE  , UPD_ID
                                                 , ZIP_CODE          
                                                 , ZIP_NAME1         , ZIP_NAME2         , ZIP_NAME3
                                                 , ZIP_NAME_GANA1    , ZIP_NAME_GANA2    , ZIP_NAME_GANA3
                                                 , ZIP_TONGGYE       , ZIP_CODE1         , ZIP_CODE2        )
                                           VALUES  
                                                 ( SYSDATE           , :q_user_id        , SYSDATE    , :q_user_id 
                                                 , :f_zip_code
                                                 , :f_zip_name1      , :f_zip_name2      , :f_zip_name3
                                                 , :f_zip_name_gana1 , :f_zip_name_gana2 , :f_zip_name_gana3
                                                 , :f_zip_tonggye    , :t_zip_code1      , :t_zip_code2     )";

                                break;

                            case DataRowState.Modified:

                                cmdText = @"UPDATE BAS0123 A
                                               SET UPD_ID         = :q_user_id
                                                  ,UPD_DATE        = SYSDATE
                                                  ,ZIP_NAME1       = :f_zip_name1
                                                  ,ZIP_NAME2       = :f_zip_name2
                                                  ,ZIP_NAME3       = :f_zip_name3
                                                  ,ZIP_NAME_GANA1  = :f_zip_name_gana1
                                                  ,ZIP_NAME_GANA2  = :f_zip_name_gana2
                                                  ,ZIP_NAME_GANA3  = :f_zip_name_gana3
                                                  ,ZIP_TONGGYE     = :f_zip_tonggye
                                             WHERE ZIP_CODE  = :f_zip_code";

                                break;

                            case DataRowState.Deleted:

                                cmdText = @"DELETE FROM BAS0123 A
                                             WHERE ZIP_CODE  = :f_zip_code";

                                break;
                        }
                        break;
                }

                return Service.ExecuteNonQuery(cmdText, item.BindVarList);
            }
        }
        #endregion

        private string mMsg = "";
        private string mCap = "";
        private void grdBAS0123_SaveEnd(object sender, SaveEndEventArgs e)
        {
            if (e.IsSuccess)
            {
                this.mMsg = Resource.TEXT8;

                this.mCap = Resource.TEXT9;

                XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                this.mMsg = Resource.TEXT10;

                this.mMsg += "\r\n" + Service.ErrFullMsg;

                this.mCap = Resource.TEXT11;

                XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnList__ButtonClick(object sender, ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Update:
                    e.IsSuccess = false;
                    try
                    {
                        // Connect to cloud
                        UpdateResult updateResult = GrdBAS0123SaveLayout();
                        if (updateResult != null && updateResult.ExecutionStatus == ExecutionStatus.Success &&
                            updateResult.Result)
                        {
                            e.IsSuccess = true;
                        } 
                    }
                    catch (Exception ex)
                    {
                        e.IsSuccess = false;

                    }

                    if (e.IsSuccess)
                    {
                        this.mMsg = Resource.TEXT8;

                        this.mCap = Resource.TEXT9;

                        XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        this.mMsg = Resource.TEXT10;

                        this.mMsg += "\r\n" + Service.ErrFullMsg;

                        this.mCap = Resource.TEXT11;

                        XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    break;
            }
        }

        #region Connect to cloud service
        /// <summary>
        /// ExecuteQueryFwkZipCode
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> ExecuteQueryFwkZipCode(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            BAS0123U00FwkZipCodeArgs vBAS0123U00FwkZipCodeArgs = new BAS0123U00FwkZipCodeArgs();
            vBAS0123U00FwkZipCodeArgs.Code = bc["f_code"] != null ? bc["f_code"].VarValue : "";
            vBAS0123U00FwkZipCodeArgs.Find1 = bc["f_find_1"] != null ? bc["f_find_1"].VarValue : "";
            BAS0123U00FwkZipCodeResult result = CloudService.Instance.Submit<BAS0123U00FwkZipCodeResult, BAS0123U00FwkZipCodeArgs>(vBAS0123U00FwkZipCodeArgs);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (BAS0123U00FwkZipCodeInfo item in result.Info)
                {
                    object[] objects = 
				{ 
					item.ZipCode, 
					item.ZipName1, 
					item.ZipName2, 
					item.ZipName3
				};
                    res.Add(objects);
                }
            }
            return res;
        }

        /// <summary>
        /// ExecuteQueryGrdBAS0123
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> ExecuteQueryGrdBAS0123(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            BAS0123U00GrdBAS0123Args vBAS0123U00GrdBAS0123Args = new BAS0123U00GrdBAS0123Args();
            vBAS0123U00GrdBAS0123Args.Code = bc["f_zip_code"] != null ? bc["f_zip_code"].VarValue : "";
            BAS0123U00GrdBAS0123Result result = CloudService.Instance.Submit<BAS0123U00GrdBAS0123Result, BAS0123U00GrdBAS0123Args>(vBAS0123U00GrdBAS0123Args);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (BAS0123U00GrdBAS0123Info item in result.Info)
                {
                    object[] objects =
                    {
                        item.ZipCode,
                        item.ZipName1,
                        item.ZipName2,
                        item.ZipName3,
                        item.ZipNameGana1,
                        item.ZipNameGana2,
                        item.ZipNameGana3,
                        item.ZipTonggye
                    };
                    res.Add(objects);
                }
            }
            return res;
        }

        /// <summary>
        /// ExecuteQueryLayTonggyeCode
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> ExecuteQueryLayTonggyeCode(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            BAS0123U00LayTonggyeCodeArgs vBAS0123U00LayTonggyeCodeArgs = new BAS0123U00LayTonggyeCodeArgs();
            vBAS0123U00LayTonggyeCodeArgs.CodeType = bc["f_code_type"] != null ? bc["f_code_type"].VarValue : "";
            vBAS0123U00LayTonggyeCodeArgs.Code = bc["f_code"] != null ? bc["f_code"].VarValue : "";
            BAS0123U00LayTonggyeCodeResult result = CloudService.Instance.Submit<BAS0123U00LayTonggyeCodeResult, BAS0123U00LayTonggyeCodeArgs>(vBAS0123U00LayTonggyeCodeArgs);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (ComboListItemInfo item in result.Info)
                {
                    object[] objects =
                    {
                        item.Code,
                        item.CodeName
                    };
                    res.Add(objects);
                }
            }
            return res;
        }

        /// <summary>
        /// ExecuteQueryLayZipCode
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> ExecuteQueryLayZipCode(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            BAS0123U00LayZipCodeArgs vBAS0123U00LayZipCodeArgs = new BAS0123U00LayZipCodeArgs();
            vBAS0123U00LayZipCodeArgs.Code = bc["f_code"] != null ? bc["f_code"].VarValue : "";
            BAS0123U00LayZipCodeResult result =
                CloudService.Instance.Submit<BAS0123U00LayZipCodeResult, BAS0123U00LayZipCodeArgs>(
                    vBAS0123U00LayZipCodeArgs);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                res.Add(new object[] {result.Info});
            }
            return res;
        }

        /// <summary>
        /// GrdBAS0123SaveLayout
        /// </summary>
        /// <returns></returns>
	    private UpdateResult GrdBAS0123SaveLayout()
	    {
	        BAS0123U00SaveLayoutArgs args = new BAS0123U00SaveLayoutArgs();
	        args.ItemInfo = CreateListGrdBAS0123Item();
	        args.UserId = UserInfo.UserID;
	        return CloudService.Instance.Submit<UpdateResult, BAS0123U00SaveLayoutArgs>(args);
	    }

        /// <summary>
        /// CreateListGrdBAS0123Item
        /// </summary>
        /// <returns></returns>
	    private List<BAS0123U00GrdBAS0123Info> CreateListGrdBAS0123Item()
	    {
            List<BAS0123U00GrdBAS0123Info> lstGrdBas0123Info = new List<BAS0123U00GrdBAS0123Info>();
	        for (int i = 0; i < grdBAS0123.RowCount; i++)
	        {
	            if (grdBAS0123.GetRowState(i) == DataRowState.Added || grdBAS0123.GetRowState(i) == DataRowState.Modified)
	            {
	                BAS0123U00GrdBAS0123Info grdBas0123Info = new BAS0123U00GrdBAS0123Info();
	                grdBas0123Info.ZipCode = grdBAS0123.GetItemString(i, "zip_code");
	                grdBas0123Info.ZipName1 = grdBAS0123.GetItemString(i, "zip_name1");
	                grdBas0123Info.ZipName2 = grdBAS0123.GetItemString(i, "zip_name2");
	                grdBas0123Info.ZipName3 = grdBAS0123.GetItemString(i, "zip_name3");
	                grdBas0123Info.ZipNameGana1 = grdBAS0123.GetItemString(i, "zip_name_gana1");
	                grdBas0123Info.ZipNameGana2 = grdBAS0123.GetItemString(i, "zip_name_gana2");
	                grdBas0123Info.ZipNameGana3 = grdBAS0123.GetItemString(i, "zip_name_gana3");
	                grdBas0123Info.ZipTonggye = grdBAS0123.GetItemString(i, "zip_tonggye");
	                grdBas0123Info.ZipCode1 = grdBAS0123.GetItemString(i, "zip_code").Substring(0, 3);
                    grdBas0123Info.ZipCode2 = grdBAS0123.GetItemString(i, "zip_code").Substring(3, 4);
	                grdBas0123Info.DataRowState = grdBAS0123.GetRowState(i).ToString();

	                lstGrdBas0123Info.Add(grdBas0123Info);
	            }
	        }

	        if (grdBAS0123.DeletedRowTable != null && grdBAS0123.DeletedRowCount > 0)
	        {
                foreach (DataRow row in grdBAS0123.DeletedRowTable.Rows)
	            {
                    BAS0123U00GrdBAS0123Info grdBas0123Info = new BAS0123U00GrdBAS0123Info();
                    grdBas0123Info.ZipCode = row["zip_code"].ToString();
                    grdBas0123Info.ZipName1 = row["zip_name1"].ToString();
                    grdBas0123Info.ZipName2 = row["zip_name2"].ToString();
                    grdBas0123Info.ZipName3 = row["zip_name3"].ToString();
                    grdBas0123Info.ZipNameGana1 = row["zip_name_gana1"].ToString();
                    grdBas0123Info.ZipNameGana2 = row["zip_name_gana2"].ToString();
                    grdBas0123Info.ZipNameGana3 = row["zip_name_gana3"].ToString();
                    grdBas0123Info.ZipTonggye = row["zip_tonggye"].ToString();
                    grdBas0123Info.ZipCode1 = grdBas0123Info.ZipCode.Substring(0, 3);
                    grdBas0123Info.ZipCode2 = grdBas0123Info.ZipCode.Substring(3, 4);
	                grdBas0123Info.DataRowState = DataRowState.Deleted.ToString();

                    lstGrdBas0123Info.Add(grdBas0123Info);
	            }
	        }
	        return lstGrdBas0123Info;
	    }
        #endregion
    }
}

