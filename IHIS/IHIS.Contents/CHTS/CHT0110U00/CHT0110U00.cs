#region 사용 NameSpace 지정
using System;
using System.Collections.Generic;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.CHTS.Properties;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Arguments.Chts;
using IHIS.CloudConnector.Contracts.Models.Chts;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.Chts;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.Framework;
using IHIS.CloudConnector.Contracts.Arguments.System;
#endregion

namespace IHIS.CHTS
{
	/// <summary>
	/// CHT0110U00에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class CHT0110U00 : IHIS.Framework.XScreen
	{
		#region [DynService Control]
		private IHIS.Framework.SingleLayout mVsdCommon;	
		private IHIS.Framework.MultiLayout mDsdCombo;		
		#endregion

		#region [Instance Variable]
		//Control HashTable
		Hashtable htRow1;
		Hashtable htRow2;
		Hashtable htCurrent;
		//Message처리
		string mbxMsg = "", mbxCap = "";	
	    //insert 반영
		bool newData = false;
		#endregion

		private IHIS.Framework.XButtonList xButtonList1;
		private IHIS.Framework.XEditGrid grdCHT0110;
		private IHIS.Framework.XPanel xPanel3;
		private System.Windows.Forms.PictureBox pictureBox1;
		private IHIS.Framework.XLabel xLabel1;
		private IHIS.Framework.XPanel pnlRow1;
		private IHIS.Framework.XPanel pnlRow2;
		private IHIS.Framework.XLabel xLabel2;
		private IHIS.Framework.XLabel xLabel3;
		private IHIS.Framework.XLabel xLabel4;
        private IHIS.Framework.XLabel xLabel5;
		private IHIS.Framework.XLabel xLabel14;
		private IHIS.Framework.XTextBox txtSang_index;
		private IHIS.Framework.XTextBox txtRow1_Sang_code;
		private IHIS.Framework.XTextBox txtRow1_Sang_name;
		private IHIS.Framework.XTextBox txtRow1_Sang_name_han;
        private IHIS.Framework.XTextBox txtRow1_Sang_name_self;
        private IHIS.Framework.XDisplayBox dbxRow1_Suga_sang_name;
        private IHIS.Framework.XDisplayBox dbxRow2_Suga_sang_name;
        private IHIS.Framework.XLabel xLabel15;
		private IHIS.Framework.XTextBox txtRow2_Sang_name_self;
		private IHIS.Framework.XTextBox txtRow2_Sang_name_han;
		private IHIS.Framework.XTextBox txtRow2_Sang_name;
		private IHIS.Framework.XLabel xLabel24;
		private IHIS.Framework.XLabel xLabel25;
		private IHIS.Framework.XTextBox txtRow2_Sang_code;
		private IHIS.Framework.XLabel xLabel26;
        private IHIS.Framework.XLabel xLabel27;
		private IHIS.Framework.XEditGridCell xEditGridCell4;
		private IHIS.Framework.XEditGridCell xEditGridCell5;
		private IHIS.Framework.XEditGridCell xEditGridCell6;
        private IHIS.Framework.XEditGridCell xEditGridCell7;
        private XEditGridCell xEditGridCell35;
        private XEditGridCell xEditGridCell36;
        private XEditGridCell xEditGridCell37;
        private XEditGridCell xEditGridCell38;
        private XEditGridCell xEditGridCell39;
        private XEditGridCell xEditGridCell40;
        private XDatePicker dtpRow1_end_date;
        private XLabel xLabel7;
        private XDatePicker dtpRow1_start_date;
        private XLabel xLabel6;
        private XDatePicker dtpRow2_end_date;
        private XLabel xLabel8;
        private XDatePicker dtpRow2_start_date;
        private XLabel xLabel9;
        private XEditGridCell xEditGridCell1;
        private XDisplayBox dbxRow1_Suga_sang_code;
        private XDisplayBox dbxRow2_Suga_sang_code;
        private XCheckBox cbxRow1_bulyong_yn;
        private XCheckBox cbxRow2_bulyong_yn;
        private XButton btnUpdateMst;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public CHT0110U00()
		{
			// 이 호출은 Windows Form 디자이너에 필요합니다.
			InitializeComponent();

            //set ParamList
            this.grdCHT0110.ParamList = new List<string>(new String[] { "f_sang_inx", "f_page_number"});

            //set ExecuteQuery
            this.grdCHT0110.ExecuteQuery = LoadDataGrdCHT0110;
		}


	    #region CloudService

        private List<object[]> LoadDataGrdCHT0110(BindVarCollection bc)
	    {
	        List<object[]> res = new List<object[]>();
	        CHT0110U00grdCHT0110Args args = new CHT0110U00grdCHT0110Args();
            args.SangInx = bc["f_sang_inx"] != null ? bc["f_sang_inx"].VarValue : "";
            args.PageNumber = bc["f_page_number"].VarValue;
            args.Offset = "200";
	        CHT0110U00grdCHT0110Result result =
	            CloudService.Instance.Submit<CHT0110U00grdCHT0110Result, CHT0110U00grdCHT0110Args>(
	                args);
	        if (result.ExecutionStatus == ExecutionStatus.Success)
	        {
	            foreach (CHT0110U00grdCHT0110ItemInfo item in result.GrdItem)
	            {
	                object[] objects =
	                {
	                    item.SangCode,
	                    item.SangName,
	                    item.SangNameHan,
	                    item.SangNameSelf,
	                    item.StartDate,
	                    item.EndDate,
	                    item.BulyongYn,
	                    item.SugaSangCode,
	                    item.SugaSangName,
	                    item.JunyeomBuryn,
	                    item.JunyeomKind
	                };
	                res.Add(objects);
	            }
	        }
	        return res;
	    }

        private bool SaveGridCHT0110()
        {
            List<CHT0110U00grdCHT0110ItemInfo> inputList = GetListFromGrdCHT0110();
            if (inputList.Count == 0)
            {
                return true;
            }
            CHT0110U00ExecuteArgs args = new CHT0110U00ExecuteArgs(inputList, UserInfo.UserID);
            UpdateResult result = CloudService.Instance.Submit<UpdateResult, CHT0110U00ExecuteArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                return result.Result;
            }
            return false;
        }

	    private List<CHT0110U00grdCHT0110ItemInfo> GetListFromGrdCHT0110()
	    {
	        List<CHT0110U00grdCHT0110ItemInfo> dataList = new List<CHT0110U00grdCHT0110ItemInfo>();
	        for (int i = 0; i < grdCHT0110.RowCount; i++)
	        {
	            if (grdCHT0110.GetRowState(i) == DataRowState.Unchanged)
	            {
	                continue;
	            }

	            CHT0110U00grdCHT0110ItemInfo info = new CHT0110U00grdCHT0110ItemInfo();
                info.SangCode = grdCHT0110.GetItemString(i, "sang_code");
                info.SangName = grdCHT0110.GetItemString(i, "sang_name");
                info.SangNameHan = grdCHT0110.GetItemString(i, "sang_name_han");
                info.SangNameSelf = grdCHT0110.GetItemString(i, "sang_name_self");
                info.StartDate = grdCHT0110.GetItemString(i, "start_date");
                info.EndDate = grdCHT0110.GetItemString(i, "end_date");
                info.BulyongYn = grdCHT0110.GetItemString(i, "bulyong_yn");
                info.SugaSangCode = grdCHT0110.GetItemString(i, "suga_sang_code");
                info.SugaSangName = grdCHT0110.GetItemString(i, "suga_sang_name");
                info.JunyeomBuryn = grdCHT0110.GetItemString(i, "junyeom_bunryu");
                info.JunyeomKind = grdCHT0110.GetItemString(i, "junyeom_kind");
	            info.RowState = grdCHT0110.GetRowState(i).ToString();
                dataList.Add(info);
	        }

	        if (grdCHT0110.DeletedRowCount > 0)
	        {
	            foreach (DataRow row in grdCHT0110.DeletedRowTable.Rows)
	            {
                    CHT0110U00grdCHT0110ItemInfo info = new CHT0110U00grdCHT0110ItemInfo();
	                info.SangCode = row["sang_code"].ToString();
	                info.RowState = DataRowState.Deleted.ToString();

	                dataList.Add(info);
	            }
	        }
	        return dataList;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CHT0110U00));
            this.pnlRow1 = new IHIS.Framework.XPanel();
            this.cbxRow1_bulyong_yn = new IHIS.Framework.XCheckBox();
            this.dbxRow1_Suga_sang_code = new IHIS.Framework.XDisplayBox();
            this.dtpRow1_end_date = new IHIS.Framework.XDatePicker();
            this.xLabel7 = new IHIS.Framework.XLabel();
            this.dtpRow1_start_date = new IHIS.Framework.XDatePicker();
            this.xLabel6 = new IHIS.Framework.XLabel();
            this.dbxRow1_Suga_sang_name = new IHIS.Framework.XDisplayBox();
            this.xLabel14 = new IHIS.Framework.XLabel();
            this.txtRow1_Sang_name_self = new IHIS.Framework.XTextBox();
            this.txtRow1_Sang_name_han = new IHIS.Framework.XTextBox();
            this.txtRow1_Sang_name = new IHIS.Framework.XTextBox();
            this.xLabel5 = new IHIS.Framework.XLabel();
            this.xLabel4 = new IHIS.Framework.XLabel();
            this.txtRow1_Sang_code = new IHIS.Framework.XTextBox();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.pnlRow2 = new IHIS.Framework.XPanel();
            this.cbxRow2_bulyong_yn = new IHIS.Framework.XCheckBox();
            this.dbxRow2_Suga_sang_code = new IHIS.Framework.XDisplayBox();
            this.dtpRow2_end_date = new IHIS.Framework.XDatePicker();
            this.dbxRow2_Suga_sang_name = new IHIS.Framework.XDisplayBox();
            this.xLabel8 = new IHIS.Framework.XLabel();
            this.dtpRow2_start_date = new IHIS.Framework.XDatePicker();
            this.xLabel9 = new IHIS.Framework.XLabel();
            this.xLabel15 = new IHIS.Framework.XLabel();
            this.txtRow2_Sang_name_self = new IHIS.Framework.XTextBox();
            this.txtRow2_Sang_name_han = new IHIS.Framework.XTextBox();
            this.txtRow2_Sang_name = new IHIS.Framework.XTextBox();
            this.xLabel24 = new IHIS.Framework.XLabel();
            this.xLabel25 = new IHIS.Framework.XLabel();
            this.txtRow2_Sang_code = new IHIS.Framework.XTextBox();
            this.xLabel26 = new IHIS.Framework.XLabel();
            this.xLabel27 = new IHIS.Framework.XLabel();
            this.grdCHT0110 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell35 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell36 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell37 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell38 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell39 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell40 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xButtonList1 = new IHIS.Framework.XButtonList();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.txtSang_index = new IHIS.Framework.XTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnUpdateMst = new IHIS.Framework.XButton();
            this.pnlRow1.SuspendLayout();
            this.pnlRow2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCHT0110)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).BeginInit();
            this.xPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            resources.ApplyResources(this.ImageList, "ImageList");
            // 
            // pnlRow1
            // 
            this.pnlRow1.AccessibleDescription = null;
            this.pnlRow1.AccessibleName = null;
            resources.ApplyResources(this.pnlRow1, "pnlRow1");
            this.pnlRow1.BackgroundImage = null;
            this.pnlRow1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlRow1.Controls.Add(this.cbxRow1_bulyong_yn);
            this.pnlRow1.Controls.Add(this.dbxRow1_Suga_sang_code);
            this.pnlRow1.Controls.Add(this.dtpRow1_end_date);
            this.pnlRow1.Controls.Add(this.xLabel7);
            this.pnlRow1.Controls.Add(this.dtpRow1_start_date);
            this.pnlRow1.Controls.Add(this.xLabel6);
            this.pnlRow1.Controls.Add(this.dbxRow1_Suga_sang_name);
            this.pnlRow1.Controls.Add(this.xLabel14);
            this.pnlRow1.Controls.Add(this.txtRow1_Sang_name_self);
            this.pnlRow1.Controls.Add(this.txtRow1_Sang_name_han);
            this.pnlRow1.Controls.Add(this.txtRow1_Sang_name);
            this.pnlRow1.Controls.Add(this.xLabel5);
            this.pnlRow1.Controls.Add(this.xLabel4);
            this.pnlRow1.Controls.Add(this.txtRow1_Sang_code);
            this.pnlRow1.Controls.Add(this.xLabel3);
            this.pnlRow1.Controls.Add(this.xLabel2);
            this.pnlRow1.Font = null;
            this.pnlRow1.Name = "pnlRow1";
            // 
            // cbxRow1_bulyong_yn
            // 
            this.cbxRow1_bulyong_yn.AccessibleDescription = null;
            this.cbxRow1_bulyong_yn.AccessibleName = null;
            resources.ApplyResources(this.cbxRow1_bulyong_yn, "cbxRow1_bulyong_yn");
            this.cbxRow1_bulyong_yn.BackgroundImage = null;
            this.cbxRow1_bulyong_yn.Font = null;
            this.cbxRow1_bulyong_yn.Name = "cbxRow1_bulyong_yn";
            this.cbxRow1_bulyong_yn.UseVisualStyleBackColor = false;
            this.cbxRow1_bulyong_yn.CheckedChanged += new System.EventHandler(this.cbx_bulyong_yn_CheckedChanged);
            // 
            // dbxRow1_Suga_sang_code
            // 
            this.dbxRow1_Suga_sang_code.AccessibleDescription = null;
            this.dbxRow1_Suga_sang_code.AccessibleName = null;
            resources.ApplyResources(this.dbxRow1_Suga_sang_code, "dbxRow1_Suga_sang_code");
            this.dbxRow1_Suga_sang_code.BackColor = IHIS.Framework.XColor.XLabelBackColor;
            this.dbxRow1_Suga_sang_code.EdgeRounding = false;
            this.dbxRow1_Suga_sang_code.Font = null;
            this.dbxRow1_Suga_sang_code.Image = null;
            this.dbxRow1_Suga_sang_code.Name = "dbxRow1_Suga_sang_code";
            // 
            // dtpRow1_end_date
            // 
            this.dtpRow1_end_date.AccessibleDescription = null;
            this.dtpRow1_end_date.AccessibleName = null;
            resources.ApplyResources(this.dtpRow1_end_date, "dtpRow1_end_date");
            this.dtpRow1_end_date.BackgroundImage = null;
            this.dtpRow1_end_date.Font = null;
            this.dtpRow1_end_date.Name = "dtpRow1_end_date";
            // 
            // xLabel7
            // 
            this.xLabel7.AccessibleDescription = null;
            this.xLabel7.AccessibleName = null;
            resources.ApplyResources(this.xLabel7, "xLabel7");
            this.xLabel7.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel7.EdgeRounding = false;
            this.xLabel7.Font = null;
            this.xLabel7.ForeColor = IHIS.Framework.XColor.NormalForeColor;
            this.xLabel7.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel7.Image = null;
            this.xLabel7.Name = "xLabel7";
            // 
            // dtpRow1_start_date
            // 
            this.dtpRow1_start_date.AccessibleDescription = null;
            this.dtpRow1_start_date.AccessibleName = null;
            resources.ApplyResources(this.dtpRow1_start_date, "dtpRow1_start_date");
            this.dtpRow1_start_date.BackgroundImage = null;
            this.dtpRow1_start_date.Font = null;
            this.dtpRow1_start_date.Name = "dtpRow1_start_date";
            this.dtpRow1_start_date.Protect = true;
            this.dtpRow1_start_date.ReadOnly = true;
            this.dtpRow1_start_date.TabStop = false;
            // 
            // xLabel6
            // 
            this.xLabel6.AccessibleDescription = null;
            this.xLabel6.AccessibleName = null;
            resources.ApplyResources(this.xLabel6, "xLabel6");
            this.xLabel6.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel6.EdgeRounding = false;
            this.xLabel6.Font = null;
            this.xLabel6.ForeColor = IHIS.Framework.XColor.NormalForeColor;
            this.xLabel6.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel6.Image = null;
            this.xLabel6.Name = "xLabel6";
            // 
            // dbxRow1_Suga_sang_name
            // 
            this.dbxRow1_Suga_sang_name.AccessibleDescription = null;
            this.dbxRow1_Suga_sang_name.AccessibleName = null;
            resources.ApplyResources(this.dbxRow1_Suga_sang_name, "dbxRow1_Suga_sang_name");
            this.dbxRow1_Suga_sang_name.BackColor = IHIS.Framework.XColor.XLabelBackColor;
            this.dbxRow1_Suga_sang_name.EdgeRounding = false;
            this.dbxRow1_Suga_sang_name.Font = null;
            this.dbxRow1_Suga_sang_name.Image = null;
            this.dbxRow1_Suga_sang_name.Name = "dbxRow1_Suga_sang_name";
            // 
            // xLabel14
            // 
            this.xLabel14.AccessibleDescription = null;
            this.xLabel14.AccessibleName = null;
            resources.ApplyResources(this.xLabel14, "xLabel14");
            this.xLabel14.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel14.EdgeRounding = false;
            this.xLabel14.Font = null;
            this.xLabel14.ForeColor = IHIS.Framework.XColor.NormalForeColor;
            this.xLabel14.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel14.Image = null;
            this.xLabel14.Name = "xLabel14";
            // 
            // txtRow1_Sang_name_self
            // 
            this.txtRow1_Sang_name_self.AccessibleDescription = null;
            this.txtRow1_Sang_name_self.AccessibleName = null;
            resources.ApplyResources(this.txtRow1_Sang_name_self, "txtRow1_Sang_name_self");
            this.txtRow1_Sang_name_self.ApplyByteLimit = true;
            this.txtRow1_Sang_name_self.BackgroundImage = null;
            this.txtRow1_Sang_name_self.Font = null;
            this.txtRow1_Sang_name_self.Name = "txtRow1_Sang_name_self";
            // 
            // txtRow1_Sang_name_han
            // 
            this.txtRow1_Sang_name_han.AccessibleDescription = null;
            this.txtRow1_Sang_name_han.AccessibleName = null;
            resources.ApplyResources(this.txtRow1_Sang_name_han, "txtRow1_Sang_name_han");
            this.txtRow1_Sang_name_han.ApplyByteLimit = true;
            this.txtRow1_Sang_name_han.BackgroundImage = null;
            this.txtRow1_Sang_name_han.Font = null;
            this.txtRow1_Sang_name_han.Name = "txtRow1_Sang_name_han";
            // 
            // txtRow1_Sang_name
            // 
            this.txtRow1_Sang_name.AccessibleDescription = null;
            this.txtRow1_Sang_name.AccessibleName = null;
            resources.ApplyResources(this.txtRow1_Sang_name, "txtRow1_Sang_name");
            this.txtRow1_Sang_name.ApplyByteLimit = true;
            this.txtRow1_Sang_name.BackgroundImage = null;
            this.txtRow1_Sang_name.Font = null;
            this.txtRow1_Sang_name.Name = "txtRow1_Sang_name";
            // 
            // xLabel5
            // 
            this.xLabel5.AccessibleDescription = null;
            this.xLabel5.AccessibleName = null;
            resources.ApplyResources(this.xLabel5, "xLabel5");
            this.xLabel5.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel5.EdgeRounding = false;
            this.xLabel5.Font = null;
            this.xLabel5.ForeColor = IHIS.Framework.XColor.NormalForeColor;
            this.xLabel5.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel5.Image = null;
            this.xLabel5.Name = "xLabel5";
            // 
            // xLabel4
            // 
            this.xLabel4.AccessibleDescription = null;
            this.xLabel4.AccessibleName = null;
            resources.ApplyResources(this.xLabel4, "xLabel4");
            this.xLabel4.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel4.EdgeRounding = false;
            this.xLabel4.Font = null;
            this.xLabel4.ForeColor = IHIS.Framework.XColor.NormalForeColor;
            this.xLabel4.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel4.Image = null;
            this.xLabel4.Name = "xLabel4";
            // 
            // txtRow1_Sang_code
            // 
            this.txtRow1_Sang_code.AccessibleDescription = null;
            this.txtRow1_Sang_code.AccessibleName = null;
            resources.ApplyResources(this.txtRow1_Sang_code, "txtRow1_Sang_code");
            this.txtRow1_Sang_code.ApplyByteLimit = true;
            this.txtRow1_Sang_code.BackgroundImage = null;
            this.txtRow1_Sang_code.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRow1_Sang_code.Font = null;
            this.txtRow1_Sang_code.Name = "txtRow1_Sang_code";
            // 
            // xLabel3
            // 
            this.xLabel3.AccessibleDescription = null;
            this.xLabel3.AccessibleName = null;
            resources.ApplyResources(this.xLabel3, "xLabel3");
            this.xLabel3.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel3.EdgeRounding = false;
            this.xLabel3.Font = null;
            this.xLabel3.ForeColor = IHIS.Framework.XColor.NormalForeColor;
            this.xLabel3.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel3.Image = null;
            this.xLabel3.Name = "xLabel3";
            // 
            // xLabel2
            // 
            this.xLabel2.AccessibleDescription = null;
            this.xLabel2.AccessibleName = null;
            resources.ApplyResources(this.xLabel2, "xLabel2");
            this.xLabel2.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel2.EdgeRounding = false;
            this.xLabel2.Font = null;
            this.xLabel2.ForeColor = IHIS.Framework.XColor.NormalForeColor;
            this.xLabel2.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel2.Image = null;
            this.xLabel2.Name = "xLabel2";
            // 
            // pnlRow2
            // 
            this.pnlRow2.AccessibleDescription = null;
            this.pnlRow2.AccessibleName = null;
            resources.ApplyResources(this.pnlRow2, "pnlRow2");
            this.pnlRow2.BackgroundImage = null;
            this.pnlRow2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlRow2.Controls.Add(this.cbxRow2_bulyong_yn);
            this.pnlRow2.Controls.Add(this.dbxRow2_Suga_sang_code);
            this.pnlRow2.Controls.Add(this.dtpRow2_end_date);
            this.pnlRow2.Controls.Add(this.dbxRow2_Suga_sang_name);
            this.pnlRow2.Controls.Add(this.xLabel8);
            this.pnlRow2.Controls.Add(this.dtpRow2_start_date);
            this.pnlRow2.Controls.Add(this.xLabel9);
            this.pnlRow2.Controls.Add(this.xLabel15);
            this.pnlRow2.Controls.Add(this.txtRow2_Sang_name_self);
            this.pnlRow2.Controls.Add(this.txtRow2_Sang_name_han);
            this.pnlRow2.Controls.Add(this.txtRow2_Sang_name);
            this.pnlRow2.Controls.Add(this.xLabel24);
            this.pnlRow2.Controls.Add(this.xLabel25);
            this.pnlRow2.Controls.Add(this.txtRow2_Sang_code);
            this.pnlRow2.Controls.Add(this.xLabel26);
            this.pnlRow2.Controls.Add(this.xLabel27);
            this.pnlRow2.Font = null;
            this.pnlRow2.Name = "pnlRow2";
            // 
            // cbxRow2_bulyong_yn
            // 
            this.cbxRow2_bulyong_yn.AccessibleDescription = null;
            this.cbxRow2_bulyong_yn.AccessibleName = null;
            resources.ApplyResources(this.cbxRow2_bulyong_yn, "cbxRow2_bulyong_yn");
            this.cbxRow2_bulyong_yn.BackgroundImage = null;
            this.cbxRow2_bulyong_yn.Font = null;
            this.cbxRow2_bulyong_yn.Name = "cbxRow2_bulyong_yn";
            this.cbxRow2_bulyong_yn.UseVisualStyleBackColor = false;
            this.cbxRow2_bulyong_yn.CheckedChanged += new System.EventHandler(this.cbx_bulyong_yn_CheckedChanged);
            // 
            // dbxRow2_Suga_sang_code
            // 
            this.dbxRow2_Suga_sang_code.AccessibleDescription = null;
            this.dbxRow2_Suga_sang_code.AccessibleName = null;
            resources.ApplyResources(this.dbxRow2_Suga_sang_code, "dbxRow2_Suga_sang_code");
            this.dbxRow2_Suga_sang_code.BackColor = IHIS.Framework.XColor.XLabelBackColor;
            this.dbxRow2_Suga_sang_code.EdgeRounding = false;
            this.dbxRow2_Suga_sang_code.Font = null;
            this.dbxRow2_Suga_sang_code.Image = null;
            this.dbxRow2_Suga_sang_code.Name = "dbxRow2_Suga_sang_code";
            // 
            // dtpRow2_end_date
            // 
            this.dtpRow2_end_date.AccessibleDescription = null;
            this.dtpRow2_end_date.AccessibleName = null;
            resources.ApplyResources(this.dtpRow2_end_date, "dtpRow2_end_date");
            this.dtpRow2_end_date.BackgroundImage = null;
            this.dtpRow2_end_date.Font = null;
            this.dtpRow2_end_date.Name = "dtpRow2_end_date";
            // 
            // dbxRow2_Suga_sang_name
            // 
            this.dbxRow2_Suga_sang_name.AccessibleDescription = null;
            this.dbxRow2_Suga_sang_name.AccessibleName = null;
            resources.ApplyResources(this.dbxRow2_Suga_sang_name, "dbxRow2_Suga_sang_name");
            this.dbxRow2_Suga_sang_name.BackColor = IHIS.Framework.XColor.XLabelBackColor;
            this.dbxRow2_Suga_sang_name.EdgeRounding = false;
            this.dbxRow2_Suga_sang_name.Font = null;
            this.dbxRow2_Suga_sang_name.Image = null;
            this.dbxRow2_Suga_sang_name.Name = "dbxRow2_Suga_sang_name";
            // 
            // xLabel8
            // 
            this.xLabel8.AccessibleDescription = null;
            this.xLabel8.AccessibleName = null;
            resources.ApplyResources(this.xLabel8, "xLabel8");
            this.xLabel8.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel8.EdgeRounding = false;
            this.xLabel8.Font = null;
            this.xLabel8.ForeColor = IHIS.Framework.XColor.NormalForeColor;
            this.xLabel8.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel8.Image = null;
            this.xLabel8.Name = "xLabel8";
            // 
            // dtpRow2_start_date
            // 
            this.dtpRow2_start_date.AccessibleDescription = null;
            this.dtpRow2_start_date.AccessibleName = null;
            resources.ApplyResources(this.dtpRow2_start_date, "dtpRow2_start_date");
            this.dtpRow2_start_date.BackgroundImage = null;
            this.dtpRow2_start_date.Font = null;
            this.dtpRow2_start_date.Name = "dtpRow2_start_date";
            this.dtpRow2_start_date.Protect = true;
            this.dtpRow2_start_date.ReadOnly = true;
            this.dtpRow2_start_date.TabStop = false;
            // 
            // xLabel9
            // 
            this.xLabel9.AccessibleDescription = null;
            this.xLabel9.AccessibleName = null;
            resources.ApplyResources(this.xLabel9, "xLabel9");
            this.xLabel9.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel9.EdgeRounding = false;
            this.xLabel9.Font = null;
            this.xLabel9.ForeColor = IHIS.Framework.XColor.NormalForeColor;
            this.xLabel9.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel9.Image = null;
            this.xLabel9.Name = "xLabel9";
            // 
            // xLabel15
            // 
            this.xLabel15.AccessibleDescription = null;
            this.xLabel15.AccessibleName = null;
            resources.ApplyResources(this.xLabel15, "xLabel15");
            this.xLabel15.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel15.EdgeRounding = false;
            this.xLabel15.Font = null;
            this.xLabel15.ForeColor = IHIS.Framework.XColor.NormalForeColor;
            this.xLabel15.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel15.Image = null;
            this.xLabel15.Name = "xLabel15";
            // 
            // txtRow2_Sang_name_self
            // 
            this.txtRow2_Sang_name_self.AccessibleDescription = null;
            this.txtRow2_Sang_name_self.AccessibleName = null;
            resources.ApplyResources(this.txtRow2_Sang_name_self, "txtRow2_Sang_name_self");
            this.txtRow2_Sang_name_self.ApplyByteLimit = true;
            this.txtRow2_Sang_name_self.BackgroundImage = null;
            this.txtRow2_Sang_name_self.Font = null;
            this.txtRow2_Sang_name_self.Name = "txtRow2_Sang_name_self";
            // 
            // txtRow2_Sang_name_han
            // 
            this.txtRow2_Sang_name_han.AccessibleDescription = null;
            this.txtRow2_Sang_name_han.AccessibleName = null;
            resources.ApplyResources(this.txtRow2_Sang_name_han, "txtRow2_Sang_name_han");
            this.txtRow2_Sang_name_han.ApplyByteLimit = true;
            this.txtRow2_Sang_name_han.BackgroundImage = null;
            this.txtRow2_Sang_name_han.Font = null;
            this.txtRow2_Sang_name_han.Name = "txtRow2_Sang_name_han";
            // 
            // txtRow2_Sang_name
            // 
            this.txtRow2_Sang_name.AccessibleDescription = null;
            this.txtRow2_Sang_name.AccessibleName = null;
            resources.ApplyResources(this.txtRow2_Sang_name, "txtRow2_Sang_name");
            this.txtRow2_Sang_name.ApplyByteLimit = true;
            this.txtRow2_Sang_name.BackgroundImage = null;
            this.txtRow2_Sang_name.Font = null;
            this.txtRow2_Sang_name.Name = "txtRow2_Sang_name";
            // 
            // xLabel24
            // 
            this.xLabel24.AccessibleDescription = null;
            this.xLabel24.AccessibleName = null;
            resources.ApplyResources(this.xLabel24, "xLabel24");
            this.xLabel24.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel24.EdgeRounding = false;
            this.xLabel24.Font = null;
            this.xLabel24.ForeColor = IHIS.Framework.XColor.NormalForeColor;
            this.xLabel24.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel24.Image = null;
            this.xLabel24.Name = "xLabel24";
            // 
            // xLabel25
            // 
            this.xLabel25.AccessibleDescription = null;
            this.xLabel25.AccessibleName = null;
            resources.ApplyResources(this.xLabel25, "xLabel25");
            this.xLabel25.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel25.EdgeRounding = false;
            this.xLabel25.Font = null;
            this.xLabel25.ForeColor = IHIS.Framework.XColor.NormalForeColor;
            this.xLabel25.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel25.Image = null;
            this.xLabel25.Name = "xLabel25";
            // 
            // txtRow2_Sang_code
            // 
            this.txtRow2_Sang_code.AccessibleDescription = null;
            this.txtRow2_Sang_code.AccessibleName = null;
            resources.ApplyResources(this.txtRow2_Sang_code, "txtRow2_Sang_code");
            this.txtRow2_Sang_code.ApplyByteLimit = true;
            this.txtRow2_Sang_code.BackgroundImage = null;
            this.txtRow2_Sang_code.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRow2_Sang_code.Font = null;
            this.txtRow2_Sang_code.Name = "txtRow2_Sang_code";
            // 
            // xLabel26
            // 
            this.xLabel26.AccessibleDescription = null;
            this.xLabel26.AccessibleName = null;
            resources.ApplyResources(this.xLabel26, "xLabel26");
            this.xLabel26.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel26.EdgeRounding = false;
            this.xLabel26.Font = null;
            this.xLabel26.ForeColor = IHIS.Framework.XColor.NormalForeColor;
            this.xLabel26.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel26.Image = null;
            this.xLabel26.Name = "xLabel26";
            // 
            // xLabel27
            // 
            this.xLabel27.AccessibleDescription = null;
            this.xLabel27.AccessibleName = null;
            resources.ApplyResources(this.xLabel27, "xLabel27");
            this.xLabel27.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel27.EdgeRounding = false;
            this.xLabel27.Font = null;
            this.xLabel27.ForeColor = IHIS.Framework.XColor.NormalForeColor;
            this.xLabel27.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel27.Image = null;
            this.xLabel27.Name = "xLabel27";
            // 
            // grdCHT0110
            // 
            resources.ApplyResources(this.grdCHT0110, "grdCHT0110");
            this.grdCHT0110.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell6,
            this.xEditGridCell7,
            this.xEditGridCell35,
            this.xEditGridCell36,
            this.xEditGridCell37,
            this.xEditGridCell38,
            this.xEditGridCell39,
            this.xEditGridCell40,
            this.xEditGridCell1});
            this.grdCHT0110.ColPerLine = 2;
            this.grdCHT0110.Cols = 2;
            this.grdCHT0110.ExecuteQuery = null;
            this.grdCHT0110.FixedRows = 1;
            this.grdCHT0110.HeaderHeights.Add(21);
            this.grdCHT0110.Name = "grdCHT0110";
            this.grdCHT0110.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdCHT0110.ParamList")));
            this.grdCHT0110.QuerySQL = resources.GetString("grdCHT0110.QuerySQL");
            this.grdCHT0110.ReadOnly = true;
            this.grdCHT0110.Rows = 2;
            this.grdCHT0110.ToolTipActive = true;
            this.grdCHT0110.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdCHT0110_QueryEnd);
            this.grdCHT0110.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdCHT0110_RowFocusChanged);
            this.grdCHT0110.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdCHT0110_QueryStarting);
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.AlterateRowGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell4.CellName = "sang_code";
            this.xEditGridCell4.CellWidth = 130;
            this.xEditGridCell4.ExecuteQuery = null;
            this.xEditGridCell4.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.IsNotNull = true;
            this.xEditGridCell4.IsUpdatable = false;
            this.xEditGridCell4.SelectedBackColor = IHIS.Framework.XColor.ActiveBorderColor;
            this.xEditGridCell4.SelectedForeColor = IHIS.Framework.XColor.XDataGridParentRowsForeColor;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "sang_name";
            this.xEditGridCell5.CellWidth = 168;
            this.xEditGridCell5.Col = 1;
            this.xEditGridCell5.ExecuteQuery = null;
            this.xEditGridCell5.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.AlterateRowGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell6.CellName = "sang_name_han";
            this.xEditGridCell6.CellWidth = 173;
            this.xEditGridCell6.Col = -1;
            this.xEditGridCell6.ExecuteQuery = null;
            this.xEditGridCell6.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.IsVisible = false;
            this.xEditGridCell6.Row = -1;
            this.xEditGridCell6.SelectedBackColor = IHIS.Framework.XColor.ActiveBorderColor;
            this.xEditGridCell6.SelectedForeColor = IHIS.Framework.XColor.XDataGridParentRowsForeColor;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "sang_name_self";
            this.xEditGridCell7.Col = -1;
            this.xEditGridCell7.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            this.xEditGridCell7.IsVisible = false;
            this.xEditGridCell7.Row = -1;
            // 
            // xEditGridCell35
            // 
            this.xEditGridCell35.CellName = "start_date";
            this.xEditGridCell35.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell35.Col = -1;
            this.xEditGridCell35.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell35, "xEditGridCell35");
            this.xEditGridCell35.IsUpdatable = false;
            this.xEditGridCell35.IsVisible = false;
            this.xEditGridCell35.Row = -1;
            // 
            // xEditGridCell36
            // 
            this.xEditGridCell36.CellName = "end_date";
            this.xEditGridCell36.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell36.Col = -1;
            this.xEditGridCell36.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell36, "xEditGridCell36");
            this.xEditGridCell36.IsVisible = false;
            this.xEditGridCell36.Row = -1;
            // 
            // xEditGridCell37
            // 
            this.xEditGridCell37.CellName = "bulyong_yn";
            this.xEditGridCell37.Col = -1;
            this.xEditGridCell37.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell37, "xEditGridCell37");
            this.xEditGridCell37.IsVisible = false;
            this.xEditGridCell37.Row = -1;
            // 
            // xEditGridCell38
            // 
            this.xEditGridCell38.CellName = "suga_sang_code";
            this.xEditGridCell38.Col = -1;
            this.xEditGridCell38.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell38, "xEditGridCell38");
            this.xEditGridCell38.IsVisible = false;
            this.xEditGridCell38.Row = -1;
            // 
            // xEditGridCell39
            // 
            this.xEditGridCell39.CellName = "suga_sang_name";
            this.xEditGridCell39.Col = -1;
            this.xEditGridCell39.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell39, "xEditGridCell39");
            this.xEditGridCell39.IsVisible = false;
            this.xEditGridCell39.Row = -1;
            // 
            // xEditGridCell40
            // 
            this.xEditGridCell40.CellName = "junyeom_bunryu";
            this.xEditGridCell40.Col = -1;
            this.xEditGridCell40.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell40, "xEditGridCell40");
            this.xEditGridCell40.IsVisible = false;
            this.xEditGridCell40.Row = -1;
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "junyeom_kind";
            this.xEditGridCell1.Col = -1;
            this.xEditGridCell1.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsVisible = false;
            this.xEditGridCell1.Row = -1;
            // 
            // xButtonList1
            // 
            this.xButtonList1.AccessibleDescription = null;
            this.xButtonList1.AccessibleName = null;
            resources.ApplyResources(this.xButtonList1, "xButtonList1");
            this.xButtonList1.BackgroundImage = null;
            this.xButtonList1.Font = null;
            this.xButtonList1.Name = "xButtonList1";
            this.xButtonList1.PerformerType = IHIS.Framework.FunctionPerformerType.Entry;
            this.xButtonList1.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.xButtonList1_ButtonClick);
            // 
            // xPanel3
            // 
            this.xPanel3.AccessibleDescription = null;
            this.xPanel3.AccessibleName = null;
            resources.ApplyResources(this.xPanel3, "xPanel3");
            this.xPanel3.BackgroundImage = null;
            this.xPanel3.Controls.Add(this.xLabel1);
            this.xPanel3.Controls.Add(this.txtSang_index);
            this.xPanel3.Controls.Add(this.pictureBox1);
            this.xPanel3.DrawBorder = true;
            this.xPanel3.Font = null;
            this.xPanel3.Name = "xPanel3";
            // 
            // xLabel1
            // 
            this.xLabel1.AccessibleDescription = null;
            this.xLabel1.AccessibleName = null;
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel1.EdgeRounding = false;
            this.xLabel1.Font = null;
            this.xLabel1.ForeColor = IHIS.Framework.XColor.XDataGridLinkColor;
            this.xLabel1.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel1.Image = null;
            this.xLabel1.Name = "xLabel1";
            // 
            // txtSang_index
            // 
            this.txtSang_index.AccessibleDescription = null;
            this.txtSang_index.AccessibleName = null;
            resources.ApplyResources(this.txtSang_index, "txtSang_index");
            this.txtSang_index.BackgroundImage = null;
            this.txtSang_index.Font = null;
            this.txtSang_index.Name = "txtSang_index";
            this.txtSang_index.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.txtSang_index_DataValidating);
            // 
            // pictureBox1
            // 
            this.pictureBox1.AccessibleDescription = null;
            this.pictureBox1.AccessibleName = null;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Font = null;
            this.pictureBox1.ImageLocation = null;
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // btnUpdateMst
            // 
            this.btnUpdateMst.AccessibleDescription = null;
            this.btnUpdateMst.AccessibleName = null;
            resources.ApplyResources(this.btnUpdateMst, "btnUpdateMst");
            this.btnUpdateMst.BackgroundImage = null;
            this.btnUpdateMst.Font = null;
            this.btnUpdateMst.Name = "btnUpdateMst";
            this.btnUpdateMst.TabStop = false;
            this.btnUpdateMst.Click += new System.EventHandler(this.btnUpdateMst_Click);
            // 
            // CHT0110U00
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.btnUpdateMst);
            this.Controls.Add(this.xPanel3);
            this.Controls.Add(this.xButtonList1);
            this.Controls.Add(this.grdCHT0110);
            this.Controls.Add(this.pnlRow2);
            this.Controls.Add(this.pnlRow1);
            this.Font = null;
            this.Name = "CHT0110U00";
            this.pnlRow1.ResumeLayout(false);
            this.pnlRow1.PerformLayout();
            this.pnlRow2.ResumeLayout(false);
            this.pnlRow2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCHT0110)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).EndInit();
            this.xPanel3.ResumeLayout(false);
            this.xPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region [Screen Event]
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);
			PostCallHelper.PostCall(new PostMethod(PostLoad));
		}

		private void PostLoad()
		{	
			//Set Current Grid
			this.CurrMSLayout = this.grdCHT0110;
			this.CurrMQLayout = this.grdCHT0110;

            //this.grdCHT0110.SavePerformer = new XSavePerformer(this);

			//Create Dyn Service Control
			mVsdCommon = new IHIS.Framework.SingleLayout();
			mDsdCombo = new IHIS.Framework.MultiLayout();
			
			//Create Combo
			CreateCombo();

			//Control Binding
			SetControl(ref htRow1, pnlRow1);
			SetControl(ref htRow2, pnlRow2);			
            
			//상병조회
			this.grdCHT0110.QueryLayout(false);
		}

		/// <summary>
		/// Control Binding, Set Hashtable
		/// 1.Hashtable에 각 DataControl를 Load시켜서 해당 Control의 제어를 용이하게 한다.
		/// 2.해당Control Event Binding
		/// </summary>
		private void SetControl(ref Hashtable htControl, XPanel pnlControl)
		{
			htControl = new Hashtable();
			string colName = "";

			foreach(object obj in pnlControl.Controls)
			{
				try
				{
					if( obj.GetType().Name.ToString().IndexOf("XComboBox") >= 0)
					{
						colName = ((XComboBox)obj).Name.Substring(8).ToLower();
						htControl.Add(colName, obj);
						((XComboBox)obj).Enter += new System.EventHandler(this.SetCurrentHashTable_Enter);
						((XComboBox)obj).DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.Control_DataValidating);												
					}
					else if( obj.GetType().Name.ToString().IndexOf("XTextBox") >= 0)
					{
						colName = ((XTextBox)obj).Name.Substring(8).ToLower();
						htControl.Add(colName, obj);
						((XTextBox)obj).Enter += new System.EventHandler(this.SetCurrentHashTable_Enter);
						((XTextBox)obj).DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.Control_DataValidating);

					}
					else if( obj.GetType().Name.ToString().IndexOf("XEditMask" ) >= 0)
					{						
						colName = ((XEditMask)obj).Name.Substring(8).ToLower();
						htControl.Add(colName, obj);
						((XEditMask)obj).Enter += new System.EventHandler(this.SetCurrentHashTable_Enter);
						((XEditMask)obj).DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.Control_DataValidating);
					}
					else if( obj.GetType().ToString().IndexOf("XCheckBox" ) >= 0)
					{
						colName = ((XCheckBox)obj).Name.Substring(8).ToLower();
						htControl.Add(colName, obj);
						((XCheckBox)obj).Enter += new System.EventHandler(this.SetCurrentHashTable_Enter);
						((XCheckBox)obj).DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.Control_DataValidating);
					}
					else if( obj.GetType().ToString().IndexOf("XDisplayBox" ) >= 0)
					{
						colName = ((XDisplayBox)obj).Name.Substring(8).ToLower();
						htControl.Add(colName, obj);
					}
					else if( obj.GetType().ToString().IndexOf("XDatePicker" ) >= 0)
					{
                        colName = ((XDatePicker)obj).Name.Substring(8).ToLower();
						htControl.Add(colName, obj);
                        ((XDatePicker)obj).Enter += new System.EventHandler(this.SetCurrentHashTable_Enter);
                    }				
				}
				catch(Exception ex)
				{
					//https://sofiamedix.atlassian.net/browse/MED-10610
					//XMessageBox.Show(ex.Message);
				}
			}
		}

		
		
		#endregion

		#region [Control]

		private void txtSang_index_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
			this.grdCHT0110.QueryLayout(false);
		}
        
		/// <summary>
		/// Control 값들을 Clear한다.
		/// </summary>
		private void ClearControlData(Hashtable htControl)
		{
			foreach( object key in htControl.Keys)
			{
				((IDataControl)htControl[key]).DataValue = "";
			}
		}
                
		/// <summary>
		/// 해당 항목 Control의 컬럼명을 가져온다.
		/// </summary>
		/// <param name="obj"> 항목 Control</param>
		/// <returns></returns>
		private string GetColumnName(object obj)
		{
			string colName = "";

			if( obj.GetType().Name.ToString().IndexOf("XComboBox") >= 0)
			{
				colName = ((XComboBox)obj).Name.Substring(8).ToLower();
			}
			else if( obj.GetType().Name.ToString().IndexOf("XTextBox") >= 0)
			{
				colName = ((XTextBox)obj).Name.Substring(8).ToLower();
			}
			else if( obj.GetType().Name.ToString().IndexOf("XEditMask" ) >= 0)
			{						
				colName = ((XEditMask)obj).Name.Substring(8).ToLower();
			}
			else if( obj.GetType().ToString().IndexOf("XCheckBox" ) >= 0)
			{
				colName = ((XCheckBox)obj).Name.Substring(8).ToLower();
			}
			else if( obj.GetType().ToString().IndexOf("XDisplayBox" ) >= 0)
			{
				colName = ((XDisplayBox)obj).Name.Substring(8).ToLower();
			}
			else if( obj.GetType().ToString().IndexOf("XFindBox" ) >= 0)
			{
				colName = ((XFindBox)obj).Name.Substring(8).ToLower();
            }
            else if (obj.GetType().ToString().IndexOf("XDatePicker") >= 0)
            {
                colName = ((XDatePicker)obj).Name.Substring(8).ToLower();
            }	
			
			return colName;
		}

		/// <summary>
		/// Control의 protect를 설정한다.
		/// </summary>
		private void SetControlProtect(Hashtable htControl)
		{
			
			int rowIndex = grdCHT0110.CurrentRowNumber;

			if(rowIndex < 0 ) return;
			
			foreach(string key in htControl.Keys)
			{
				// Not Updatable 컬럼 protect설정
				if(grdCHT0110.GetRowState(rowIndex) != DataRowState.Added)
				{
					if(!((XEditGridCell)grdCHT0110.CellInfos[key]).IsUpdatable)
					{
						((IDataControl)htControl[key]).Protect = true;
						continue;
					}
					else
						((IDataControl)htControl[key]).Protect = false;					
				}
				else
					((IDataControl)htControl[key]).Protect = false;
			}
		}

		/// <summary>
		/// Control선택시 Current HashTable 설정
		/// </summary>
		private void SetCurrentHashTable_Enter(object sender, System.EventArgs e)
		{
			foreach(object obj in htRow1.Values)
			{
				if(obj == sender)
				{
					htCurrent = htRow1;
					break;
				}
			}

			foreach(object obj in htRow2.Values)
			{
				if(obj == sender)
				{
					htCurrent = htRow2;
					break;
				}
			}								
		}

		
		private void Control_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{	
			e.Cancel = false;
            
			string codeName = "";
			string colName  = GetColumnName(sender);

			switch (colName)
			{
				case "sang_code":

					if(e.DataValue.ToString().Trim() == "" ) break;
                    
					// 조건조회로 Data를 가져오는 경우 아래경우 다 check
					// 중복 Check
					// 현재 화면					
					for(int i = 0; i < grdCHT0110.RowCount; i++)
					{
						if(i != grdCHT0110.CurrentRowNumber)
						{
							if( grdCHT0110.GetItemString(i, "sang_code").Trim() == e.DataValue.ToString().Trim() )
							{
								mbxMsg = NetInfo.Language == LangMode.Jr ? "["+ e.DataValue.ToString().Trim() + Resource.mbxMsg_JP : Resource.mbxMsg_Ko;
								mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
								XMessageBox.Show(mbxMsg, mbxCap);
								e.Cancel= true;
                                return;
							}
						}
					} 

					// Delete Table Check
					// 현재 화면상에도 없으면서 DeleteTable에 존재하면 Not 중복
					if(grdCHT0110.DeletedRowTable != null)
					{
						foreach(DataRow row in grdCHT0110.DeletedRowTable.Rows)
						{
							if(row[colName].ToString() == e.DataValue.ToString())
								break;
						}
					}
                    
					//Check Origin Data
					codeName = this.GetCodeName(colName, e.DataValue.ToString());

					if(codeName != "")
					{
                        mbxMsg = NetInfo.Language == LangMode.Jr ? "[" + e.DataValue.ToString().Trim() + Resource.mbxMsg2_JP : Resource.mbxMsg_Ko;
						mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
						XMessageBox.Show(mbxMsg, mbxCap);
						e.Cancel= true;
                        return;
					}
					
					break;	

				case "suga_sang_code":

					if(e.DataValue.ToString().Trim() == "" ) 
					{
						((IDataControl)htCurrent["suga_sang_name"]).DataValue = "";
						break;
					}

					codeName = this.GetCodeName(colName, e.DataValue.ToString());

					if(codeName == "")		
						e.Cancel = true;
					
					((IDataControl)htCurrent["suga_sang_name"]).DataValue = codeName;

					break;					

				
                    

				default:
					break;
			}
		}		
		#endregion
	
		#region [Combo 생성]
		
		private void CreateCombo()
		{
            //IHIS.Framework.MultiLayout layoutCombo;
            //layoutCombo = new MultiLayout();
		           
            //mDsdCombo.Reset();
            //layoutCombo.Reset();
            //layoutCombo.LayoutItems.Clear();
            //layoutCombo.LayoutItems.Add("code" , DataType.String);
            //layoutCombo.LayoutItems.Add("code_name", DataType.String);
            //layoutCombo.LayoutItems.Add("seq" , DataType.String);
            //layoutCombo.InitializeLayoutTable();
			
            //mDsdCombo.QuerySQL = ""
            //    + "  SELECT '', '', '00' "
            //    + "    FROM DUAL "
            //    + "  UNION ALL   "
            //    +  " SELECT CODE, CODE||': '||CODE_NAME CODE_NAME, CODE SEQ "
            //    + "    FROM CHT0102 "
            //    + "   WHERE CODE_TYPE = 'G01' "
            //    + "   ORDER BY 3 ";
            //mDsdCombo.MOutputLayout = layoutCombo;
            //mDsdCombo.Call();
			

            //if(mDsdCombo.ErrTp == "0" && layoutCombo.LayoutTable != null)
            //{
            //    cboRow1_Junyeum_yn.SetComboItems( layoutCombo.LayoutTable, "code_name", "code");				
            //    cboRow2_Junyeum_yn.SetComboItems( layoutCombo.LayoutTable, "code_name", "code");				
            //}

		}

		#endregion

		#region [Load Code Name]
        
		/// <summary>
		/// 해당 코드에 대한 명을 가져옵니다.
		/// </summary>
		/// <param name="codeMode">코드구분</param>
		/// <param name="code">코드Value</param>
		/// <returns></returns>
		private string GetCodeName(string codeMode, string code)
		{
			string codeName = "";

			if(code.Trim() == "" ) return codeName;

            CHT0110U00GetCodeNameArgs args = new CHT0110U00GetCodeNameArgs();
            CHT0110U00GetCodeNameResult result = new CHT0110U00GetCodeNameResult();
			switch (codeMode)
			{
				case "sang_code":
                    
                    //mVsdCommon.Reset();
                    //mVsdCommon.QuerySQL = ""
                    //    + " SELECT A.SANG_NAME "   
                    //    + "   FROM CHT0110 A "
                    //    + "  WHERE A.HOSP_CODE = FN_ADM_LOAD_HOSP_CODE() " 
                    //    + "    AND A.SANG_CODE = '" + code + "' ";
					
                    //mVsdCommon.LayoutItems.Clear();
                    //mVsdCommon.LayoutItems.Add("sang_name");
                    
                    //mVsdCommon.QueryLayout();

			        args.Code = code;
			        args.CodeMode = "sang_code";
			     
			        result = CloudService.Instance.Submit<CHT0110U00GetCodeNameResult, CHT0110U00GetCodeNameArgs>(args);

			        //if(mVsdCommon.GetItemValue("sang_name").ToString() == "")
			        if (result.ExecutionStatus != ExecutionStatus.Success || result.CodeName == "")
			        {
			            codeName = "";
			        }
			        else
			            //codeName = mVsdCommon.GetItemValue("sang_name").ToString();
			            codeName = result.CodeName;

					break;

				case "suga_sang_code":
                    
                    //mVsdCommon.Reset();
                    //mVsdCommon.QuerySQL = ""
                    //    + " SELECT A.SANG_NAME "   
                    //    + "   FROM CHT0110 A "
                    //    + "  WHERE A.HOSP_CODE = FN_ADM_LOAD_HOSP_CODE() "
                    //    + "    AND A.SANG_CODE = '" + code + "' ";
					
                    //mVsdCommon.LayoutItems.Clear();
                    //mVsdCommon.LayoutItems.Add("sang_name");
                    
                    //mVsdCommon.QueryLayout();


			        args.Code = code;
			        args.CodeMode = "suga_sang_code";
                    result = CloudService.Instance.Submit<CHT0110U00GetCodeNameResult, CHT0110U00GetCodeNameArgs>(args);

			        if (result.ExecutionStatus != ExecutionStatus.Success || result.CodeName == "")
			            //if(mVsdCommon.GetItemValue("sang_name").ToString() == "")
			        {
			            //mbxMsg = NetInfo.Language == LangMode.Jr ? "傷病コードが有効ではありません｡ ご確認ください｡" : "상병코드가 정확하지않습니다. 확인바랍니다.";
			            //mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
			            //XMessageBox.Show(mbxMsg, mbxCap);						
			        }
			        else
			            //codeName = mVsdCommon.GetItemValue("sang_name").ToString();
			            codeName = result.CodeName;

					break;				
                    
				default:
					break;
			}

			return codeName;
		}

		#endregion

		#region [grdCHT0110 Event]
        bool mQueryFlag = true;
		private void grdCHT0110_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
		{
			object dataValue;

			if(e.PreviousRow > -1)
			{
				//Control의 Value를 Grid로 Accept Data
				foreach(string key in htRow1.Keys)
				{
					dataValue = ((IDataControl)htRow1[key]).DataValue;
					if(grdCHT0110.CellInfos.Contains(key))
					{
						if(grdCHT0110.GetItemString(e.PreviousRow, key).Replace("\0", "").Trim() != dataValue.ToString().Trim())
							grdCHT0110.SetItemValue(e.PreviousRow, key, dataValue);
				}
				}

				if( pnlRow2.Enabled && !newData)
				{
					//Control의 Value를 Grid로 Accept Data
					foreach(string key in htRow2.Keys)
					{
						dataValue = ((IDataControl)htRow2[key]).DataValue;
						if(grdCHT0110.CellInfos.Contains(key))
						{
							if(grdCHT0110.GetItemString(e.PreviousRow + 1, key).Replace("\0", "").ToString().Trim() != dataValue.ToString().Trim())
								grdCHT0110.SetItemValue(e.PreviousRow + 1, key, dataValue);
						}
					}
				}
				
				grdCHT0110.AcceptData();
			}

            this.ClearControlData(htRow1);
            this.ClearControlData(htRow2);

			if(e.CurrentRow > -1)
			{
				this.pnlRow1.Enabled = true;				

				//Grid의 Value를 Control로
                mQueryFlag = false;
				foreach(XGridCell cell in grdCHT0110.CellInfos)
				{
					if(htRow1.ContainsKey(cell.CellName))
					{
						((IDataControl)htRow1[cell.CellName]).DataValue = grdCHT0110.GetItemValue(e.CurrentRow, cell.CellName);
					}
                } 
                mQueryFlag = true;

				SetControlProtect(htRow1);

				if(newData)
				{
					txtRow1_Sang_code.Focus();
					txtRow1_Sang_code.SelectAll();
					newData = false;
				}


				if( e.CurrentRow + 1 < grdCHT0110.RowCount )
				{
					this.pnlRow2.Enabled = true;

					//Grid의 Value를 Control로
                    mQueryFlag = false;
					foreach(XGridCell cell in grdCHT0110.CellInfos)
					{
						if(htRow2.ContainsKey(cell.CellName))
						{
							((IDataControl)htRow2[cell.CellName]).DataValue = grdCHT0110.GetItemValue(e.CurrentRow + 1, cell.CellName);
						}
					}
                    mQueryFlag = true;

					SetControlProtect(htRow2);
				}
				else
					this.pnlRow2.Enabled = false;
			}
			else
			{
				this.pnlRow1.Enabled = false;
				this.pnlRow2.Enabled = false;
			}
		
		}
		#endregion

		#region [DataService Event]

        private void grdCHT0110_QueryEnd(object sender, QueryEndEventArgs e)
        {
            if (grdCHT0110.RowCount < 1)
            {
                this.ClearControlData(htRow1);
                this.ClearControlData(htRow2);

                this.pnlRow1.Enabled = false;
                this.pnlRow2.Enabled = false;
            }
        }		

		#endregion

		#region [Button List Event]

		private void xButtonList1_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			SetMsg("");

			switch (e.Func)
			{
				case FunctionType.Insert:
					
					DataGridCell chkCell = GetEmptyNewRow(CurrMSLayout);

					if(chkCell.RowNumber < 0)
					{
						newData = true;
						e.IsBaseCall = true;
					}
					else
					{
						e.IsBaseCall = false;
						((XEditGrid)CurrMSLayout).SetFocusToItem(chkCell.RowNumber, chkCell.ColumnNumber);
					}

					
					break;
				

				case FunctionType.Update:

                    e.IsBaseCall = false;

                    object dataValue;
                    this.mErrMsg = "";
                    if (grdCHT0110.CurrentRowNumber > -1)
                    {
                        //Control의 Value를 Grid로 Accept Data
                        foreach (string key in htRow1.Keys)
                        {
                            dataValue = ((IDataControl)htRow1[key]).DataValue;
                            if (grdCHT0110.CellInfos.Contains(key))
                            {
                                if (grdCHT0110.GetItemString(grdCHT0110.CurrentRowNumber, key) != dataValue.ToString())
                                    grdCHT0110.SetItemValue(grdCHT0110.CurrentRowNumber, key, dataValue);
                            }
                        }

                        if (pnlRow2.Enabled)
                        {
                            //Control의 Value를 Grid로 Accept Data
                            foreach (string key in htRow2.Keys)
                            {
                                dataValue = ((IDataControl)htRow2[key]).DataValue;
                                if (grdCHT0110.CellInfos.Contains(key))
                                {
                                    if (grdCHT0110.GetItemString(grdCHT0110.CurrentRowNumber + 1, key) != dataValue.ToString())
                                        grdCHT0110.SetItemValue(grdCHT0110.CurrentRowNumber + 1, key, dataValue);
                                }
                            }
                        }

                        this.AcceptData();
                    }

                    //grdCHT0110
                    for (int rowIndex = 0; rowIndex < grdCHT0110.RowCount; rowIndex++)
                    {
                        if (grdCHT0110.LayoutTable.Rows[rowIndex].RowState == DataRowState.Added)
                        {
                            //Key값이 없으면 삭제처리
                            if (grdCHT0110.GetItemString(rowIndex, "sang_code").Trim() == "")
                            {
                                grdCHT0110.DeleteRow(rowIndex);
                                rowIndex = rowIndex - 1;
                            }
                        }
                    }
		


                    //if(this.grdCHT0110.SaveLayout())
                    //{
                    //    mbxMsg = NetInfo.Language == LangMode.Jr ? Resource.mbxMsg3_JP : Resource.mbxMsg3_Ko;
                    //    SetMsg(mbxMsg);
                    //}
                    //else
                    //{
                    //    mbxMsg = NetInfo.Language == LangMode.Jr ? Resource.mbxMsg4_JP : Resource.mbxMsg4_Ko; 
                    //    mbxMsg = mbxMsg + Service.ErrMsg;
                    //    mbxCap = NetInfo.Language == LangMode.Jr ? Resource.mbxCap_JP : "Save Error";
                    //    XMessageBox.Show(mbxMsg, mbxCap);
                    //}

                    if (SaveGridCHT0110())
                    {
                        mbxMsg = NetInfo.Language == LangMode.Jr ? Resource.mbxMsg3_JP : Resource.mbxMsg3_Ko;
                        SetMsg(mbxMsg);
                        this.grdCHT0110.QueryLayout(false);
                    }
                    else
                    {
                        mbxMsg = NetInfo.Language == LangMode.Jr ? Resource.mbxMsg4_JP : Resource.mbxMsg4_Ko;
                        mbxMsg = mbxMsg + Service.ErrMsg;
                        mbxCap = NetInfo.Language == LangMode.Jr ? Resource.mbxCap_JP : "Save Error";
                        XMessageBox.Show(mbxMsg, mbxCap);
                    }

					break;
					
				default:

					break;
			}
		}


	    #endregion

		#region Insert한 Row 중에 Not Null필드 미입력 Row Search (GetEmptyNewRow)
		/// <summary>
		/// Insert한 Row 중에 Not Null필드 미입력 Row Search
		/// </summary>
		/// <remarks>
		/// Grid 컬럼 속성이 Not Null과 Visible, Not ReadOnly 항목으로 체크한다..
		/// </remarks>
		/// <param name="aGrd"> XEditGrid  </param>
		/// <returns> celReturn.RowNumber < 0 미입력데이타 없음 </returns>
		private DataGridCell GetEmptyNewRow(object aGrd)
		{
			DataGridCell celReturn = new DataGridCell(-1, -1);

			if (aGrd == null) return celReturn;

			XEditGrid grdChk = null;
            
			try
			{
				grdChk = (XEditGrid)aGrd;
			}
			catch
			{
				return celReturn;
			}

			foreach (XEditGridCell cell in grdChk.CellInfos)
			{
				// NotNull Check
				if (cell.IsNotNull && cell.IsVisible && !cell.IsReadOnly) 
				{
					for( int rowIndex = 0; rowIndex < grdChk.RowCount; rowIndex++)
					{
						if(grdChk.GetRowState(rowIndex) == DataRowState.Added && TypeCheck.IsNull(grdChk.GetItemString(rowIndex, cell.CellName)))
						{
							celReturn.ColumnNumber = cell.Col;
							celReturn.RowNumber   = rowIndex;
							break;
						}
					}

					if(celReturn.RowNumber < 0) 
						continue;
					else
						break;
				}

			}

			return celReturn;
		}

		#endregion		

        private void grdCHT0110_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdCHT0110.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdCHT0110.SetBindVarValue("f_sang_inx", this.txtSang_index.GetDataValue());
        }

        private void cbx_bulyong_yn_CheckedChanged(object sender, EventArgs e)
        {
            if (mQueryFlag)
            {
                XCheckBox cbx = sender as XCheckBox;

                if (cbx.Checked)
                {
                    switch (cbx.Name.Substring(3, 4))
                    {
                        case "Row1":
                            this.dtpRow1_end_date.SetDataValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
                            break;

                        case "Row2":
                            this.dtpRow2_end_date.SetDataValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
                            break;
                    }
                }
            }
        }

        string mErrMsg = "";

        private void btnUpdateMst_Click(object sender, EventArgs e)
        {
            if (XMessageBox.Show(Resource.MSG052_MSG, Resource.TEXT33, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Cursor.Current = Cursors.WaitCursor;
                UpdateMasterDataArgs args = new UpdateMasterDataArgs();
                args.ScreenName = this.ScreenID;
                UpdateResult result = CloudService.Instance.Submit<UpdateResult, UpdateMasterDataArgs>(args);
                if (result.ExecutionStatus == ExecutionStatus.Success && result.Result == true)
                {
                    XMessageBox.Show(Resource.MSG003_MSG, Resource.mbxCap_JP, MessageBoxIcon.Information);
                    Cursor.Current = Cursors.Default;
                }
                else
                {
                    XMessageBox.Show(Resource.MSG001_MSG, Resource.mbxCap_JP, MessageBoxIcon.Error);
                    Cursor.Current = Cursors.Default;
                }
            }
        }
        #region XSavePerformer
//        private class XSavePerformer : ISavePerformer
//        {
//            CHT0110U00 parent;

//            public XSavePerformer(CHT0110U00 parent)
//            {
//                this.parent = parent;
//            }

//            public bool Execute(char callerID, RowDataItem item)
//            {
//                string cmdText = "";
//                item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);
//                item.BindVarList.Add("q_user_id", UserInfo.UserID);
                
//                parent.mErrMsg = "";

//                switch (item.RowState)
//                { 
//                    case DataRowState.Added:

//                        cmdText = @"SELECT 'Y'
//                                      FROM CHT0110
//                                     WHERE HOSP_CODE = :f_hosp_code
//                                       AND SANG_CODE = :f_sang_code
//                                       AND ROWNUM = 1";
//                        object t_chk = Service.ExecuteScalar(cmdText, item.BindVarList);

//                        if (!TypeCheck.IsNull(t_chk))
//                        {
//                            if (t_chk.ToString() == "Y")
//                            {
//                                parent.mErrMsg = "[" + item.BindVarList["f_sang_code"].VarValue + Resource.parent;
//                                return false;
//                            }
//                        }

//                        cmdText = @"INSERT INTO CHT0110
//                                       ( SYS_DATE           , SYS_ID             , 
//                                         UPD_DATE           , UPD_ID             , HOSP_CODE          ,
//                                         SANG_CODE          , SANG_NAME          , SANG_NAME_HAN      , SANG_NAME_SELF     , 
//                                         START_DATE         , END_DATE           , BULYONG_YN         , 
//                                         SUGA_SANG_CODE     , SUGA_SANG_NAME     ,
//                                         JUNYEOM_BUNRYU     , JUNYEOM_KIND       , SAMANG_SANG_GROUP  )
//                                 VALUES
//                                       ( SYSDATE               , :q_user_id            , 
//                                         SYSDATE               , :q_user_id            , :f_hosp_code          , 
//                                         :f_sang_code          , :f_sang_name          , :f_sang_name_han      , :f_sang_name_self     ,
//                                         TRUNC(SYSDATE)        , :f_end_date           , :f_bulyong_yn         , 
//                                         :f_suga_sang_code     , :f_suga_sang_name     ,
//                                         :f_junyeom_bunryu     , :f_junyeom_kind       , :f_samang_sang_group  )";


//                        break;

//                    case DataRowState.Modified:

//                        cmdText = @"UPDATE CHT0110
//                                       SET UPD_ID              = :q_user_id            ,
//                                           UPD_DATE            = SYSDATE               ,
//                                           SANG_NAME           = :f_sang_name          ,
//                                           SANG_NAME_HAN       = :f_sang_name_han      ,
//                                           SANG_NAME_SELF      = :f_sang_name_self     ,
//                                           END_DATE            = :f_end_date           ,
//                                           BULYONG_YN          = :f_bulyong_yn         
//                                     WHERE HOSP_CODE = :f_hosp_code
//                                       AND SANG_CODE = :f_sang_code ";
//                        break;

//                    case DataRowState.Deleted:

//                        cmdText = @"DELETE CHT0110
//                                     WHERE HOSP_CODE = :f_hosp_code
//                                       AND SANG_CODE = :f_sang_code";
//                        break;
//                }

//                return Service.ExecuteNonQuery(cmdText, item.BindVarList);
//            }
//        }
        #endregion


    }
}

