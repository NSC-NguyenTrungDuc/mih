#region 사용 NameSpace 지정
using System;
using System.Collections.Generic;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Caching;
using IHIS.CloudConnector.Contracts.Arguments.System;
using IHIS.CloudConnector.Contracts.Arguments.Xrts;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Models.Xrts;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.CloudConnector.Contracts.Results.Xrts;
using IHIS.CloudConnector.Utility;
using IHIS.Framework;
using IHIS.XRTS.Properties;

#endregion

namespace IHIS.XRTS
{
	/// <summary>
	/// XRT0122U00에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class XRT0122Q00 : IHIS.Framework.XScreen
	{
		private IHIS.Framework.XMstGrid grdMcode;
		private System.Windows.Forms.Splitter splitter1;
		private IHIS.Framework.XEditGrid grdDcode;
		private IHIS.Framework.XEditGridCell xEditGridCell1;
		private IHIS.Framework.XEditGridCell xEditGridCell2;
		private IHIS.Framework.SingleLayout layDupM;
        private IHIS.Framework.SingleLayout layDupD;
        private IHIS.Framework.XButtonList btnList;
		private System.Windows.Forms.ToolTip toolTip;
		private IHIS.Framework.XEditGridCell xEditGridCell3;
		private IHIS.Framework.XEditGridCell xEditGridCell4;
		private IHIS.Framework.XEditGridCell xEditGridCell5;
        private SingleLayoutItem singleLayoutItem1;
        private SingleLayoutItem singleLayoutItem2;
        private MultiLayout layCombo;
        private MultiLayoutItem multiLayoutItem1;
        private MultiLayoutItem multiLayoutItem2;
        private SingleLayout layCodeName;
        private SingleLayoutItem singleLayoutItem3;
		private System.ComponentModel.IContainer components;

		public XRT0122Q00()
		{
			// 이 호출은 Windows Form 디자이너에 필요합니다.
			InitializeComponent();

            grdMcode.ParamList = new List<string>(new String[] { "f_buwi_bunryu" });
            layDupM.ParamList = new List<string>(new String[] { "f_buwi_bunryu" });
            layDupD.ParamList = new List<string>(new String[] { "f_buwi_bunryu", "f_buwi_code" });
            layCodeName.ParamList = new List<string>(new String[] { "f_code" });
            grdDcode.ParamList = new List<string>(new String[] { "f_buwi_bunryu", "f_buwi_code", "f_buwi_name", "f_flag" });

		    grdMcode.ExecuteQuery = LoadDataGrdMCode;
		    grdDcode.ExecuteQuery = LoadDataGrdDCode;
		    layDupM.ExecuteQuery = LoadDataLayDupM;
		    layDupD.ExecuteQuery = LoadDataLayDupD;
            layCodeName.ExecuteQuery = LoadDataLayCodeName;
            layCombo.ExecuteQuery = LoadDataLayCombo;

            ApplyFont();
		}


        private void ApplyFont()
        {
            if (NetInfo.Language == LangMode.Vi || NetInfo.Language == LangMode.En)
            {
                ((System.ComponentModel.ISupportInitialize)(this.grdMcode)).BeginInit();
                ((System.ComponentModel.ISupportInitialize)(this.grdDcode)).BeginInit();

                this.grdMcode.RowHeaderFont = Service.COMMON_FONT_BOLD;
                this.grdDcode.RowHeaderFont = Service.COMMON_FONT_BOLD;

                IHIS.Framework.BizCodeHelper.ApplyColumnFont(xEditGridCell1);
                IHIS.Framework.BizCodeHelper.ApplyColumnFont(xEditGridCell2);

                ((System.ComponentModel.ISupportInitialize)(this.grdMcode)).EndInit();
                ((System.ComponentModel.ISupportInitialize)(this.grdDcode)).EndInit();
            }
        }

	    #region CloudService

        private IList<object[]> LoadDataLayCombo(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            Xrt0122Q00LayComboArgs args = new Xrt0122Q00LayComboArgs();
            ComboResult result =
                CacheService.Instance.Get<Xrt0122Q00LayComboArgs, ComboResult>(args, delegate(ComboResult comboResult)
                    {
                        return comboResult.ExecutionStatus == ExecutionStatus.Success && comboResult.ComboItem != null &&
                               comboResult.ComboItem.Count > 0;
                    });
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (ComboListItemInfo item in result.ComboItem)
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

        private List<object[]> LoadDataLayCodeName(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            Xrt0122Q00LayCodeNameArgs args = new Xrt0122Q00LayCodeNameArgs();
            args.Code = bc["f_code"] != null ? bc["f_code"].VarValue : "";
            Xrt0122Q00LayCodeNameResult result = CloudService.Instance.Submit<Xrt0122Q00LayCodeNameResult, Xrt0122Q00LayCodeNameArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                res.Add(new object[]
                {
                    result.CodeName
                });
            }
            return res;
        } 



        private List<object[]> LoadDataLayDupD(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            Xrt0122Q00LayDupDArgs args = new Xrt0122Q00LayDupDArgs();
            args.BuwiBunryu = bc["f_buwi_bunryu"] != null ? bc["f_buwi_bunryu"].VarValue : "";
            args.BuwiCode = bc["f_buwi_code"] != null ? bc["f_buwi_code"].VarValue : "";
            Xrt0122Q00LayDupDResult result = CloudService.Instance.Submit<Xrt0122Q00LayDupDResult, Xrt0122Q00LayDupDArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                res.Add(new object[]
                {
                    result.YValue
                });
            }
            return res;
        } 



        private List<object[]> LoadDataLayDupM(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            Xrt0122Q00LayDupMArgs args = new Xrt0122Q00LayDupMArgs();
            args.BuwiBunryu = bc["f_buwi_bunryu"] != null ? bc["f_buwi_bunryu"].VarValue : "";
            Xrt0122Q00LayDupMResult result = CloudService.Instance.Submit<Xrt0122Q00LayDupMResult, Xrt0122Q00LayDupMArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                res.Add(new object[]
                {
                    result.YValue
                });
            }
            return res;
        } 



        private List<object[]> LoadDataGrdDCode(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            Xrt0122Q00GrdDCodeArgs args = new Xrt0122Q00GrdDCodeArgs();
            args.BuwiBunryu = bc["f_buwi_bunryu"] != null ? bc["f_buwi_bunryu"].VarValue : "";
            args.Flag = bc["f_flag"] != null ? bc["f_flag"].VarValue : "";
            args.BuwiCode = bc["f_buwi_code"] != null ? bc["f_buwi_code"].VarValue : "";
            args.BuwiName = bc["f_buwi_name"] != null ? bc["f_buwi_name"].VarValue : "";
            Xrt0122Q00GrdDCodeResult result = CloudService.Instance.Submit<Xrt0122Q00GrdDCodeResult, Xrt0122Q00GrdDCodeArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (Xrt0122Q00GrdDCodeListItemInfo item in result.InfoList)
                {
                    object[] objects = 
				{ 
					item.Bunryu, 
					item.Code, 
					item.Name, 
					item.Seq, 
					item.Key
				};
                    res.Add(objects);
                }
            }
            return res;
        } 



        private List<object[]> LoadDataGrdMCode(BindVarCollection bc)
	    {
	        List<object[]> res = new List<object[]>();
	        Xrt0122Q00GrdMCodeArgs args = new Xrt0122Q00GrdMCodeArgs();
	        args.BuwiBunryu = bc["f_buwi_bunryu"] != null ? bc["f_buwi_bunryu"].VarValue : "";
	        Xrt0122Q00GrdMCodeResult result =
	            CloudService.Instance.Submit<Xrt0122Q00GrdMCodeResult, Xrt0122Q00GrdMCodeArgs>(args);
	        if (result.ExecutionStatus == ExecutionStatus.Success)
	        {
	            foreach (ComboListItemInfo item in result.InfoList)
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

	    #endregion




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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XRT0122Q00));
            this.grdMcode = new IHIS.Framework.XMstGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.btnList = new IHIS.Framework.XButtonList();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.grdDcode = new IHIS.Framework.XEditGrid();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.layDupM = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem1 = new IHIS.Framework.SingleLayoutItem();
            this.layDupD = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem2 = new IHIS.Framework.SingleLayoutItem();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.layCombo = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem1 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2 = new IHIS.Framework.MultiLayoutItem();
            this.layCodeName = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem3 = new IHIS.Framework.SingleLayoutItem();
            ((System.ComponentModel.ISupportInitialize)(this.grdMcode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDcode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layCombo)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            resources.ApplyResources(this.ImageList, "ImageList");
            // 
            // grdMcode
            // 
            resources.ApplyResources(this.grdMcode, "grdMcode");
            this.grdMcode.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2});
            this.grdMcode.ColPerLine = 2;
            this.grdMcode.ColResizable = true;
            this.grdMcode.Cols = 3;
            this.grdMcode.ExecuteQuery = null;
            this.grdMcode.FixedCols = 1;
            this.grdMcode.FixedRows = 1;
            this.grdMcode.HeaderHeights.Add(21);
            this.grdMcode.Name = "grdMcode";
            this.grdMcode.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdMcode.ParamList")));
            this.grdMcode.ReadOnly = true;
            this.grdMcode.RowHeaderVisible = true;
            this.grdMcode.Rows = 2;
            this.toolTip.SetToolTip(this.grdMcode, resources.GetString("grdMcode.ToolTip"));
            this.grdMcode.ToolTipActive = true;
            this.grdMcode.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdMcode_QueryStarting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell1.CellName = "buwi_bunryu";
            this.xEditGridCell1.CellWidth = 96;
            this.xEditGridCell1.Col = 1;
            this.xEditGridCell1.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell1.ExecuteQuery = null;
            this.xEditGridCell1.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.ImeMode = IHIS.Framework.ColumnImeMode.EngUpper;
            this.xEditGridCell1.IsNotNull = true;
            this.xEditGridCell1.IsUpdatable = false;
            this.xEditGridCell1.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell2.CellLen = 50;
            this.xEditGridCell2.CellName = "buwi_bunryu_name";
            this.xEditGridCell2.CellWidth = 150;
            this.xEditGridCell2.Col = 2;
            this.xEditGridCell2.ExecuteQuery = null;
            this.xEditGridCell2.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.IsUpdatable = false;
            this.xEditGridCell2.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // btnList
            // 
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Process, System.Windows.Forms.Shortcut.None, global::IHIS.XRTS.Properties.Resources.TEXT1, -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Query, System.Windows.Forms.Shortcut.None, global::IHIS.XRTS.Properties.Resources.TEXT2, -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Close, System.Windows.Forms.Shortcut.None, global::IHIS.XRTS.Properties.Resources.TEXT3, -1, "")});
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.toolTip.SetToolTip(this.btnList, resources.GetString("btnList.ToolTip"));
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            this.btnList.PostButtonClick += new IHIS.Framework.PostButtonClickEventHandler(this.btnList_PostButtonClick);
            // 
            // splitter1
            // 
            resources.ApplyResources(this.splitter1, "splitter1");
            this.splitter1.Name = "splitter1";
            this.splitter1.TabStop = false;
            this.toolTip.SetToolTip(this.splitter1, resources.GetString("splitter1.ToolTip"));
            // 
            // grdDcode
            // 
            resources.ApplyResources(this.grdDcode, "grdDcode");
            this.grdDcode.CallerID = '2';
            this.grdDcode.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5});
            this.grdDcode.ColPerLine = 2;
            this.grdDcode.ColResizable = true;
            this.grdDcode.Cols = 3;
            this.grdDcode.ExecuteQuery = null;
            this.grdDcode.FixedCols = 1;
            this.grdDcode.FixedRows = 1;
            this.grdDcode.HeaderHeights.Add(21);
            this.grdDcode.MasterLayout = this.grdMcode;
            this.grdDcode.Name = "grdDcode";
            this.grdDcode.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdDcode.ParamList")));
            this.grdDcode.QuerySQL = resources.GetString("grdDcode.QuerySQL");
            this.grdDcode.ReadOnly = true;
            this.grdDcode.RowHeaderVisible = true;
            this.grdDcode.Rows = 2;
            this.toolTip.SetToolTip(this.grdDcode, resources.GetString("grdDcode.ToolTip"));
            this.grdDcode.ToolTipActive = true;
            this.grdDcode.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdDcode_QueryStarting);
            this.grdDcode.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdDcode_MouseDown);
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "buwi_bunryu";
            this.xEditGridCell3.Col = -1;
            this.xEditGridCell3.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.IsNotNull = true;
            this.xEditGridCell3.IsReadOnly = true;
            this.xEditGridCell3.IsUpdatable = false;
            this.xEditGridCell3.IsVisible = false;
            this.xEditGridCell3.Row = -1;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "buwi_code";
            this.xEditGridCell4.CellWidth = 99;
            this.xEditGridCell4.Col = 1;
            this.xEditGridCell4.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.IsNotNull = true;
            this.xEditGridCell4.IsReadOnly = true;
            this.xEditGridCell4.IsUpdatable = false;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellLen = 50;
            this.xEditGridCell5.CellName = "buwi_name";
            this.xEditGridCell5.CellWidth = 220;
            this.xEditGridCell5.Col = 2;
            this.xEditGridCell5.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.IsReadOnly = true;
            this.xEditGridCell5.IsUpdatable = false;
            // 
            // layDupM
            // 
            this.layDupM.ExecuteQuery = null;
            this.layDupM.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem1});
            this.layDupM.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layDupM.ParamList")));
            // 
            // singleLayoutItem1
            // 
            this.singleLayoutItem1.DataName = "dup_yn";
            // 
            // layDupD
            // 
            this.layDupD.ExecuteQuery = null;
            this.layDupD.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem2});
            this.layDupD.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layDupD.ParamList")));
            // 
            // singleLayoutItem2
            // 
            this.singleLayoutItem2.DataName = "dup_yn";
            // 
            // toolTip
            // 
            this.toolTip.ShowAlways = true;
            // 
            // layCombo
            // 
            this.layCombo.ExecuteQuery = null;
            this.layCombo.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem1,
            this.multiLayoutItem2});
            this.layCombo.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layCombo.ParamList")));
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "code";
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "code_name";
            // 
            // layCodeName
            // 
            this.layCodeName.ExecuteQuery = null;
            this.layCodeName.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem3});
            this.layCodeName.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layCodeName.ParamList")));
            // 
            // singleLayoutItem3
            // 
            this.singleLayoutItem3.DataName = "code_name";
            // 
            // XRT0122Q00
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.grdDcode);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.btnList);
            this.Controls.Add(this.grdMcode);
            this.Name = "XRT0122Q00";
            this.toolTip.SetToolTip(this, resources.GetString("$this.ToolTip"));
            ((System.ComponentModel.ISupportInitialize)(this.grdMcode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDcode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layCombo)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion
	
		#region OnLoad
		protected override void OnLoad(EventArgs e)
		{
            base.OnLoad(e);

            if (!this.grdMcode.QueryLayout(false))
                XMessageBox.Show(Resources.TEXT4, Resources.TEXT5, MessageBoxIcon.Error);
		}
		#endregion
	

		#region 버튼리스트 클릭 후 이벤트
		private void btnList_PostButtonClick(object sender, IHIS.Framework.PostButtonClickEventArgs e)
		{
			switch (e.Func)
			{
				//초기화가 된 후 포커스 마스터 그리드로..
				case FunctionType.Reset:
					this.CurrMQLayout = this.grdMcode;
					break;
				default:
					break;
			}
		}
		#endregion

		private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			switch (e.Func)
			{
				case FunctionType.Query:
					if ( this.CurrMQLayout == this.grdMcode )
					{
						this.grdMcode.SetBindVarValue("f_buwi_bunryu","");
					}
					else
					{
						this.grdDcode.SetBindVarValue("f_buwi_code","");
                        this.grdDcode.SetBindVarValue("f_buwi_name", "");
					}
					break;  
              
                case FunctionType.Process:

                    ReturnVals(this.grdDcode.CurrentRowNumber);

                    break;

				default:
					break;
			}
		}

        private void grdMcode_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdMcode.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
        }

        private void grdDcode_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdDcode.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdDcode.SetBindVarValue("f_buwi_bunryu", this.grdMcode.GetItemString(this.grdMcode.CurrentRowNumber, "buwi_bunryu"));

            //https://sofiamedix.atlassian.net/browse/MED-15263
            //this.grdDcode.SetBindVarValue("f_buwi_code", this.grdDcode.GetItemString(this.grdDcode.CurrentRowNumber, "buwi_code"));
            //this.grdDcode.SetBindVarValue("f_buwi_name", this.grdDcode.GetItemString(this.grdDcode.CurrentRowNumber, "buwi_name"));
        }

        private void ReturnVals(int rowNum)
        {
            if (this.grdDcode.RowCount < 0) return;
            if (rowNum < 0) return;

            SingleLayout sl = new SingleLayout();
            sl.LayoutItems.Add("buwi_code");
            sl.LayoutItems.Add("buwi_name");
            sl.SetItemValue("buwi_code", this.grdDcode.GetItemValue(rowNum, "buwi_code"));
            sl.SetItemValue("buwi_name", this.grdDcode.GetItemValue(rowNum, "buwi_name"));

            IHIS.Framework.XScreen scrOpener = (XScreen)Opener;

            CommonItemCollection commandParams = new CommonItemCollection();
            commandParams.Add("buwi_code", this.grdDcode.GetItemValue(rowNum, "buwi_code").ToString());
            commandParams.Add("buwi_name", this.grdDcode.GetItemValue(rowNum, "buwi_name").ToString());
            commandParams.Add("buwi_bunryu", this.grdMcode.GetItemValue(this.grdMcode.CurrentRowNumber, "buwi_bunryu").ToString());

            scrOpener.Command(ScreenID, commandParams);

            this.Close();
        }

        private void grdDcode_MouseDown(object sender, MouseEventArgs e)
        {
            int rowNum = this.grdDcode.GetHitRowNumber(e.Y);

            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                ReturnVals(rowNum);
            }
        }

        
	}
}

