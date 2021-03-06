#region 사용 NameSpace 지정
using System;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.Framework;
#endregion

namespace IHIS.OCSI
{
	/// <summary>
	/// OCS6000U01에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class OCS6000U01 : IHIS.Framework.XScreen
	{
		#region [Instance Variable]
		//처방화면 
		string mMemb        = "";
		int    mFkinp1001   = 0;
		string mBunho       = "";
		string mInpwon_date = "";
		//Message처리
		string mbxMsg = "", mbxCap = "";	
		
		/////////////////////
        private IHIS.OCS.OrderBiz mOrderBiz = new IHIS.OCS.OrderBiz("OCS6000U01");
		#endregion

		private IHIS.Framework.XPanel xPanel1;
		private IHIS.Framework.XButtonList xButtonList1;
		private IHIS.Framework.XTreeView tvwOCS6000;
		private IHIS.Framework.XPanel pnlCPInfo;
		private IHIS.Framework.XFlatLabel xFlatLabel1;
		private IHIS.Framework.XDisplayBox dbxCp_code;
		private IHIS.Framework.XDisplayBox dbxCp_name;
		private IHIS.Framework.XFlatLabel xFlatLabel2;
		private IHIS.Framework.XDatePicker dpkApp_date;
		private IHIS.Framework.XTextBox txtRemark;
		private IHIS.Framework.XFlatLabel xFlatLabel3;
		private IHIS.Framework.MultiLayout dloOCS6000;
		private IHIS.Framework.MultiLayout dloCpInfo;
		private IHIS.Framework.XPanel xPanel7;
		private IHIS.Framework.XComboBox cboMemb;
		private IHIS.Framework.XLabel xLabel5;
		private System.Windows.Forms.Splitter splitter1;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem1;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem2;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem3;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem4;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem5;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem6;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem7;
        private MultiLayoutItem multiLayoutItem8;
        private MultiLayoutItem multiLayoutItem9;
        private MultiLayoutItem multiLayoutItem10;
        private MultiLayoutItem multiLayoutItem11;
        private MultiLayoutItem multiLayoutItem12;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public OCS6000U01()
		{
			// 이 호출은 Windows Form 디자이너에 필요합니다.
			InitializeComponent();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OCS6000U01));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.xButtonList1 = new IHIS.Framework.XButtonList();
            this.tvwOCS6000 = new IHIS.Framework.XTreeView();
            this.pnlCPInfo = new IHIS.Framework.XPanel();
            this.xFlatLabel3 = new IHIS.Framework.XFlatLabel();
            this.txtRemark = new IHIS.Framework.XTextBox();
            this.dpkApp_date = new IHIS.Framework.XDatePicker();
            this.xFlatLabel2 = new IHIS.Framework.XFlatLabel();
            this.dbxCp_name = new IHIS.Framework.XDisplayBox();
            this.dbxCp_code = new IHIS.Framework.XDisplayBox();
            this.xFlatLabel1 = new IHIS.Framework.XFlatLabel();
            this.dloOCS6000 = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem8 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem9 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem10 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem11 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem12 = new IHIS.Framework.MultiLayoutItem();
            this.dloCpInfo = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem1 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem3 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem4 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem5 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem6 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem7 = new IHIS.Framework.MultiLayoutItem();
            this.xPanel7 = new IHIS.Framework.XPanel();
            this.cboMemb = new IHIS.Framework.XComboBox();
            this.xLabel5 = new IHIS.Framework.XLabel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).BeginInit();
            this.pnlCPInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dloOCS6000)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dloCpInfo)).BeginInit();
            this.xPanel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "");
            this.ImageList.Images.SetKeyName(1, "");
            this.ImageList.Images.SetKeyName(2, "");
            this.ImageList.Images.SetKeyName(3, "");
            this.ImageList.Images.SetKeyName(4, "");
            this.ImageList.Images.SetKeyName(5, "닫힌폴더.gif");
            this.ImageList.Images.SetKeyName(6, "열린폴더.gif");
            this.ImageList.Images.SetKeyName(7, "처방16.ico");
            this.ImageList.Images.SetKeyName(8, "진료의사.gif");
            // 
            // xPanel1
            // 
            this.xPanel1.BorderColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xPanel1.Controls.Add(this.xButtonList1);
            this.xPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Location = new System.Drawing.Point(0, 248);
            this.xPanel1.Name = "xPanel1";
            this.xPanel1.Size = new System.Drawing.Size(814, 40);
            this.xPanel1.TabIndex = 0;
            // 
            // xButtonList1
            // 
            this.xButtonList1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.xButtonList1.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xButtonList1.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Process, System.Windows.Forms.Shortcut.F12, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Close, System.Windows.Forms.Shortcut.None, "", -1, "")});
            this.xButtonList1.IsVisibleReset = false;
            this.xButtonList1.Location = new System.Drawing.Point(644, 2);
            this.xButtonList1.Name = "xButtonList1";
            this.xButtonList1.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.xButtonList1.Size = new System.Drawing.Size(163, 34);
            this.xButtonList1.TabIndex = 0;
            this.xButtonList1.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.xButtonList1_ButtonClick);
            // 
            // tvwOCS6000
            // 
            this.tvwOCS6000.Dock = System.Windows.Forms.DockStyle.Left;
            this.tvwOCS6000.ImageIndex = 0;
            this.tvwOCS6000.ImageList = this.ImageList;
            this.tvwOCS6000.Location = new System.Drawing.Point(0, 30);
            this.tvwOCS6000.Name = "tvwOCS6000";
            this.tvwOCS6000.SelectedImageIndex = 0;
            this.tvwOCS6000.Size = new System.Drawing.Size(316, 218);
            this.tvwOCS6000.TabIndex = 1;
            this.tvwOCS6000.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvwOCS6000_AfterSelect);
            // 
            // pnlCPInfo
            // 
            this.pnlCPInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlCPInfo.Controls.Add(this.xFlatLabel3);
            this.pnlCPInfo.Controls.Add(this.txtRemark);
            this.pnlCPInfo.Controls.Add(this.dpkApp_date);
            this.pnlCPInfo.Controls.Add(this.xFlatLabel2);
            this.pnlCPInfo.Controls.Add(this.dbxCp_name);
            this.pnlCPInfo.Controls.Add(this.dbxCp_code);
            this.pnlCPInfo.Controls.Add(this.xFlatLabel1);
            this.pnlCPInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCPInfo.Location = new System.Drawing.Point(321, 30);
            this.pnlCPInfo.Name = "pnlCPInfo";
            this.pnlCPInfo.Size = new System.Drawing.Size(493, 218);
            this.pnlCPInfo.TabIndex = 2;
            // 
            // xFlatLabel3
            // 
            this.xFlatLabel3.Location = new System.Drawing.Point(16, 80);
            this.xFlatLabel3.Name = "xFlatLabel3";
            this.xFlatLabel3.Size = new System.Drawing.Size(76, 20);
            this.xFlatLabel3.TabIndex = 6;
            this.xFlatLabel3.Text = "参考";
            // 
            // txtRemark
            // 
            this.txtRemark.ApplyByteLimit = true;
            this.txtRemark.Location = new System.Drawing.Point(14, 104);
            this.txtRemark.MaxLength = 4000;
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(472, 108);
            this.txtRemark.TabIndex = 5;
            // 
            // dpkApp_date
            // 
            this.dpkApp_date.Location = new System.Drawing.Point(92, 58);
            this.dpkApp_date.Name = "dpkApp_date";
            this.dpkApp_date.Size = new System.Drawing.Size(106, 20);
            this.dpkApp_date.TabIndex = 4;
            this.dpkApp_date.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dpkApp_date.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dpkApp_date_DataValidating);
            // 
            // xFlatLabel2
            // 
            this.xFlatLabel2.Location = new System.Drawing.Point(14, 58);
            this.xFlatLabel2.Name = "xFlatLabel2";
            this.xFlatLabel2.Size = new System.Drawing.Size(78, 20);
            this.xFlatLabel2.TabIndex = 3;
            this.xFlatLabel2.Text = "適用開始日";
            // 
            // dbxCp_name
            // 
            this.dbxCp_name.Location = new System.Drawing.Point(160, 30);
            this.dbxCp_name.Name = "dbxCp_name";
            this.dbxCp_name.Size = new System.Drawing.Size(292, 22);
            this.dbxCp_name.TabIndex = 2;
            // 
            // dbxCp_code
            // 
            this.dbxCp_code.Location = new System.Drawing.Point(92, 30);
            this.dbxCp_code.Name = "dbxCp_code";
            this.dbxCp_code.Size = new System.Drawing.Size(66, 22);
            this.dbxCp_code.TabIndex = 1;
            // 
            // xFlatLabel1
            // 
            this.xFlatLabel1.Location = new System.Drawing.Point(14, 6);
            this.xFlatLabel1.Name = "xFlatLabel1";
            this.xFlatLabel1.Size = new System.Drawing.Size(140, 20);
            this.xFlatLabel1.TabIndex = 0;
            this.xFlatLabel1.Text = "クリニカルパスウェイコード";
            // 
            // dloOCS6000
            // 
            this.dloOCS6000.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem8,
            this.multiLayoutItem9,
            this.multiLayoutItem10,
            this.multiLayoutItem11,
            this.multiLayoutItem12});
            this.dloOCS6000.QuerySQL = resources.GetString("dloOCS6000.QuerySQL");
            this.dloOCS6000.QueryStarting += new System.ComponentModel.CancelEventHandler(this.dloOCS6000_QueryStarting);
            this.dloOCS6000.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.dloOCS6000_QueryEnd);
            // 
            // multiLayoutItem8
            // 
            this.multiLayoutItem8.DataName = "memb";
            this.multiLayoutItem8.IsNotNull = true;
            this.multiLayoutItem8.IsUpdItem = true;
            // 
            // multiLayoutItem9
            // 
            this.multiLayoutItem9.DataName = "cp_code";
            this.multiLayoutItem9.IsNotNull = true;
            this.multiLayoutItem9.IsUpdItem = true;
            // 
            // multiLayoutItem10
            // 
            this.multiLayoutItem10.DataName = "cp_name";
            this.multiLayoutItem10.IsNotNull = true;
            this.multiLayoutItem10.IsUpdItem = true;
            // 
            // multiLayoutItem11
            // 
            this.multiLayoutItem11.DataName = "remark";
            // 
            // multiLayoutItem12
            // 
            this.multiLayoutItem12.DataName = "app_yn";
            // 
            // dloCpInfo
            // 
            this.dloCpInfo.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem1,
            this.multiLayoutItem2,
            this.multiLayoutItem3,
            this.multiLayoutItem4,
            this.multiLayoutItem5,
            this.multiLayoutItem6,
            this.multiLayoutItem7});
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "bunho";
            this.multiLayoutItem1.IsNotNull = true;
            this.multiLayoutItem1.IsUpdItem = true;
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "fkinp1001";
            this.multiLayoutItem2.DataType = IHIS.Framework.DataType.Number;
            this.multiLayoutItem2.IsNotNull = true;
            this.multiLayoutItem2.IsUpdItem = true;
            // 
            // multiLayoutItem3
            // 
            this.multiLayoutItem3.DataName = "memb";
            this.multiLayoutItem3.IsNotNull = true;
            this.multiLayoutItem3.IsUpdItem = true;
            // 
            // multiLayoutItem4
            // 
            this.multiLayoutItem4.DataName = "cp_code";
            this.multiLayoutItem4.IsNotNull = true;
            this.multiLayoutItem4.IsUpdItem = true;
            // 
            // multiLayoutItem5
            // 
            this.multiLayoutItem5.DataName = "app_date";
            this.multiLayoutItem5.DataType = IHIS.Framework.DataType.Date;
            this.multiLayoutItem5.IsNotNull = true;
            this.multiLayoutItem5.IsUpdItem = true;
            // 
            // multiLayoutItem6
            // 
            this.multiLayoutItem6.DataName = "remark";
            this.multiLayoutItem6.IsUpdItem = true;
            // 
            // multiLayoutItem7
            // 
            this.multiLayoutItem7.DataName = "temp";
            this.multiLayoutItem7.IsUpdItem = true;
            // 
            // xPanel7
            // 
            this.xPanel7.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("xPanel7.BackgroundImage")));
            this.xPanel7.Controls.Add(this.cboMemb);
            this.xPanel7.Controls.Add(this.xLabel5);
            this.xPanel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.xPanel7.Location = new System.Drawing.Point(0, 0);
            this.xPanel7.Name = "xPanel7";
            this.xPanel7.Size = new System.Drawing.Size(814, 30);
            this.xPanel7.TabIndex = 24;
            // 
            // cboMemb
            // 
            this.cboMemb.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboMemb.ImageList = this.ImageList;
            this.cboMemb.Location = new System.Drawing.Point(101, 6);
            this.cboMemb.Name = "cboMemb";
            this.cboMemb.Size = new System.Drawing.Size(121, 21);
            this.cboMemb.TabIndex = 7;
            this.cboMemb.SelectedIndexChanged += new System.EventHandler(this.cboMemb_SelectedIndexChanged);
            // 
            // xLabel5
            // 
            this.xLabel5.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel5.EdgeRounding = false;
            this.xLabel5.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xLabel5.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel5.Location = new System.Drawing.Point(13, 6);
            this.xLabel5.Name = "xLabel5";
            this.xLabel5.Size = new System.Drawing.Size(88, 21);
            this.xLabel5.TabIndex = 6;
            this.xLabel5.Text = "使用者";
            this.xLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // splitter1
            // 
            this.splitter1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitter1.Location = new System.Drawing.Point(316, 30);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(5, 218);
            this.splitter1.TabIndex = 25;
            this.splitter1.TabStop = false;
            // 
            // OCS6000U01
            // 
            this.Controls.Add(this.pnlCPInfo);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.tvwOCS6000);
            this.Controls.Add(this.xPanel7);
            this.Controls.Add(this.xPanel1);
            this.Name = "OCS6000U01";
            this.Size = new System.Drawing.Size(814, 288);
            this.UserChanged += new System.EventHandler(this.OCS6000U01_UserChanged);
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.OCS6000U01_ScreenOpen);
            this.xPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).EndInit();
            this.pnlCPInfo.ResumeLayout(false);
            this.pnlCPInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dloOCS6000)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dloCpInfo)).EndInit();
            this.xPanel7.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		#region [Screen Event]

		protected override void OnLoad(EventArgs e)
		{	
			base.OnLoad (e);

			PostCallHelper.PostCall(new PostMethod(PostLoad));
		}        

		private void OCS6000U01_ScreenOpen(object sender, IHIS.Framework.XScreenOpenEventArgs e)
		{
			// Call된 경우
			if ( this.OpenParam != null ) 
			{
				try
				{
					if(OpenParam.Contains("bunho"))
					{
						if(TypeCheck.IsNull(OpenParam["bunho"].ToString().Trim()))
						{
							mbxMsg = NetInfo.Language == LangMode.Jr ? "患者番号が正確ではないです。 確認してください。" : "환자번호가 정확하지않습니다. 확인바랍니다.";
							mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
							XMessageBox.Show(mbxMsg, mbxCap);					
							return;
						}
						else
							mBunho = OpenParam["bunho"].ToString().Trim();
					}
					else
					{
						mbxMsg = NetInfo.Language == LangMode.Jr ? "患者番号が正確ではないです。 確認してください。" : "환자번호가 정확하지않습니다. 확인바랍니다.";
						mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
						XMessageBox.Show(mbxMsg, mbxCap);							
						return;
					}

					if(OpenParam.Contains("fkinp1001"))
					{
						if(!TypeCheck.IsInt(OpenParam["fkinp1001"].ToString()))
						{
							mbxMsg = NetInfo.Language == LangMode.Jr ? "入院情報が正確ではないです。 確認してください。" : "입원정보가 정확하지않습니다. 확인바랍니다.";
							mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
							XMessageBox.Show(mbxMsg, mbxCap);							
							return;
						}
						else
							mFkinp1001 = int.Parse(OpenParam["fkinp1001"].ToString().Trim());
					}
					else
					{
						mbxMsg = NetInfo.Language == LangMode.Jr ? "入院情報が正確ではないです。 確認してください。" : "입원정보가 정확하지않습니다. 확인바랍니다.";
						mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
						XMessageBox.Show(mbxMsg, mbxCap);							
						return;
					}

					mInpwon_date = EnvironInfo.GetSysDate().ToString("yyyy/MM/dd");

					if(OpenParam.Contains("ipwon_date"))
					{
						if(!TypeCheck.IsDateTime(OpenParam["ipwon_date"].ToString()))
						{
							mInpwon_date = LoadIpwon_date(mFkinp1001);
							if( !TypeCheck.IsDateTime(mInpwon_date) )
								mInpwon_date = EnvironInfo.GetSysDate().ToString("yyyy/MM/dd");
						}
					}
					else
					{
						mInpwon_date = LoadIpwon_date(mFkinp1001);
						if( !TypeCheck.IsDateTime(mInpwon_date) )
							mInpwon_date = EnvironInfo.GetSysDate().ToString("yyyy/MM/dd");
					}
				}
				catch (Exception ex)
				{
					XMessageBox.Show(ex.Message, "");						
				}
			}
			else
			{
				mBunho = "00026351";
				mFkinp1001 = 38084;				
			}		
		}

		private void PostLoad()
		{
			if( TypeCheck.IsDateTime(mInpwon_date) )
			{
				//입원일과 현재일을 비교해서 default 값 setting
				if(int.Parse(DateTime.Parse(mInpwon_date).ToString("yyyyMMdd")) > int.Parse(EnvironInfo.GetSysDate().ToString("yyyyMMdd")))
					dpkApp_date.SetDataValue(mInpwon_date);	
				else
					dpkApp_date.SetDataValue(EnvironInfo.GetSysDate());	
			}
			else
				dpkApp_date.SetDataValue(EnvironInfo.GetSysDate());	

			
			/// 사용자 변경 Event Call /////////////////////////////////////////////////////////////////////////////////////////////
			this.OCS6000U01_UserChanged(this, new System.EventArgs()); 
			////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		}

		private void OCS6000U01_UserChanged(object sender, System.EventArgs e)
		{
			//memb reset
			this.cboMemb.DataSource = null;
			XComboItem cboItem;			
            string name = "";
            bool isCpUser = false;

            // 사용자 권한 체크
            if (UserInfo.UserGubun != UserType.Doctor)
            {
                this.mbxMsg = "CP使用権限が有りません｡";
                this.mbxCap = "使用権限確認";

                MessageBox.Show(this.mbxMsg, this.mbxCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

                isCpUser = false;
            }
            else
            {
                string cmd = " SELECT NVL(A.CP_DOCTOR_YN, 'N') CP_DOCTOR_YN"
                           + "   FROM BAS0270 A "
                           + "  WHERE A.DOCTOR = '" + UserInfo.DoctorID + "' ";

                object resultval = Service.ExecuteScalar(cmd);

                if (resultval == null || resultval.ToString() == "N")
                {
                    this.mbxMsg = "CP使用権限が有りません｡";
                    this.mbxCap = "使用権限確認";

                    MessageBox.Show(this.mbxMsg, this.mbxCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

                    isCpUser = false;
                }
                else
                {
                    isCpUser = true;
                }
            }

            if (isCpUser)
            {
                // 병원공통
                this.cboMemb.ComboItems.Add(new XComboItem("ADMIN", "[病院共通]", 7));

                // 진료과 공통
                this.mOrderBiz.LoadColumnCodeName("gwa", UserInfo.Gwa, EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"), ref name);
                if (name != "")
                    this.cboMemb.ComboItems.Add(new XComboItem(UserInfo.Gwa, "[" + name + "]", 7));

                // 유저 
                // 공통유저
                this.cboMemb.ComboItems.Add(new XComboItem(UserInfo.UserID, "[共通]" + UserInfo.UserName, 8));

                // 사용자
                if (UserInfo.UserGubun == UserType.Doctor)
                    this.cboMemb.ComboItems.Add(new XComboItem(UserInfo.DoctorID, UserInfo.UserName, 8));

                this.cboMemb.RefreshComboItems();

                this.cboMemb.SetDataValue(UserInfo.DoctorID);

            }
            else
            {
                PostCallHelper.PostCall(new PostMethodObject(PostUserChange), isCpUser);
            }
		
		}

        private void PostUserChange(object aIsCpUser)
        {
            if (((bool)aIsCpUser) == false)
            {
                this.Close();
            }
        }
		#endregion

		#region [사용자 combo]

		/// <summary>
		/// 사용자변경
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cboMemb_SelectedIndexChanged(object sender, System.EventArgs e)
		{
            mMemb = this.cboMemb.GetDataValue();
			
			dbxCp_code.SetDataValue("");
			dbxCp_name.SetDataValue("");	
            
			dloCpInfo.Reset();
			int insertRow = dloCpInfo.InsertRow(-1);
			dloCpInfo.SetItemValue(insertRow, "memb"     , mMemb );
			dloCpInfo.SetItemValue(insertRow, "bunho"    , mBunho);
			dloCpInfo.SetItemValue(insertRow, "fkinp1001", mFkinp1001);
			
		
			this.dloOCS6000.QueryLayout(true);
			
		}
		#endregion

		#region [사용자공통 USER를 가져옵니다.]
        
		/// <summary>
		/// 해당 사용자의 공통 USER ID를 가져옵니다.
		/// </summary>
		/// <param name="aUser_gubun">공통사용자구분</param>
		/// <param name="aUser_id">사용자ID</param>
		/// <returns></returns>
		private string GetOCSCOM_USER_ID(string aUser_gubun, string aUser_id)
		{
			string comUser_id = "";
			string cmdText
				= " SELECT FN_OCS_LOAD_MEMB_COMID('" + aUser_gubun + "', '" + aUser_id + "' ) "
				+ "  FROM DUAL ";

			object retVal = Service.ExecuteScalar(cmdText);

			if( retVal != null )
				comUser_id = retVal.ToString();

			return comUser_id;
		}

		private string GetOCSCOM_USER_NAME(string aUser_id)
		{
			string comUser_name = "";

			string cmdText 
				= " SELECT MEMB_NAME "
				+ "   FROM OCS0130   "
				+ "  WHERE MEMB = '" + aUser_id + "' ";
					
			object retVal = Service.ExecuteScalar(cmdText);

			if( retVal != null )
				comUser_name = retVal.ToString();


			return comUser_name;
		}

		#endregion
		
		#region [TreeView CP정보]
        		
		private void ShowTreeViewCPInfo()
		{			
			tvwOCS6000.Nodes.Clear();			

			if(dloOCS6000.RowCount < 1) return;

			TreeNode node;		

			foreach(DataRow row in dloOCS6000.LayoutTable.Rows)
			{
				node = new TreeNode( "[" + row["cp_code"].ToString() + "]" + row["cp_name"].ToString() );
				node.Tag = row["cp_code"].ToString() + "|" + row["cp_name"].ToString();
				//이미적용되어 있는 마크를 한다.
				if(row["app_yn"].ToString() == "Y")
				{					
					node.ImageIndex = 1;
					node.SelectedImageIndex = 1;
				}
                //parentNode.Nodes.Add(node);
				tvwOCS6000.Nodes.Add(node);	
			}
		}
		
		/// <summary>
		/// CP 코드 및 명을 display
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tvwOCS6000_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			if (tvwOCS6000.SelectedNode == null) return;

			string cp_code = tvwOCS6000.SelectedNode.Tag.ToString().Split('|')[0];
            
			dbxCp_code.SetDataValue(cp_code);
			dbxCp_name.SetDataValue(tvwOCS6000.SelectedNode.Tag.ToString().Split('|')[1]);	

			txtRemark.SetEditValue("");
		
			foreach(DataRow row in this.dloOCS6000.LayoutTable.Select(" cp_code = '" + cp_code + "' and app_yn = 'Y' ", ""))
			{
				txtRemark.SetEditValue(row["remark"].ToString());
			}
		}

		#endregion
		
		#region [Control Event]

		private void dpkApp_date_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
			if(!TypeCheck.IsDateTime(e.DataValue) )
			{
				mbxMsg = NetInfo.Language == LangMode.Jr ? "適用開始日が正確でがはないです。 確認してください。" : "적용시작일이 정확하지않습니다. 확인바랍니다.";
				mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
				dpkApp_date.SetDataValue(EnvironInfo.GetSysDate());
				XMessageBox.Show(mbxMsg, mbxCap);
			}		
		}

		#endregion

		#region [Function]

		private bool SetInvalue()
		{
			bool returnValue = true;

			if(TypeCheck.IsNull(dbxCp_code.GetDataValue()))
			{				
				mbxMsg = NetInfo.Language == LangMode.Jr ? "クリニカルパスウェイコードが選択されていません。 確認してください。" : "CP코드가 선택되지않았습니다. 확인바랍니다.";
				mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
				XMessageBox.Show(mbxMsg, mbxCap);
				return false;
			}

			dloCpInfo.SetItemValue(0, "cp_code", dbxCp_code.GetDataValue());
            
			if(!TypeCheck.IsDateTime(dpkApp_date.GetDataValue()) )
			{
				mbxMsg = NetInfo.Language == LangMode.Jr ? "適用開始日が正確でがはないです。 確認してください。" : "적용시작일이 정확하지않습니다. 확인바랍니다.";
				mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
				XMessageBox.Show(mbxMsg, mbxCap);
				dpkApp_date.Focus();
				dpkApp_date.SelectAll();
				returnValue = false;
				return returnValue;
			}
            
			dloCpInfo.SetItemValue(0, "app_date" , dpkApp_date.GetDataValue() );
			dloCpInfo.SetItemValue(0, "remark"   , txtRemark.GetDataValue() );

			return returnValue;
		}

		#endregion

		#region [Button List Event]

		private void xButtonList1_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			SetMsg("");

			switch (e.Func)
			{
			
				case FunctionType.Process:

					e.IsBaseCall = false;

				    if(!SetInvalue()) break;

					string spName = "PR_OCSI_APPLY_CPINFO";

					ArrayList inputArrayList = new ArrayList();
					ArrayList outputArrayList = new ArrayList();
					inputArrayList.Clear();
					outputArrayList.Clear();
					inputArrayList.Add(mBunho);
					inputArrayList.Add(mFkinp1001.ToString());
					inputArrayList.Add(mMemb);
					inputArrayList.Add(dbxCp_code.GetDataValue());
					inputArrayList.Add(dpkApp_date.GetDataValue());
					inputArrayList.Add(txtRemark.GetDataValue());
                    inputArrayList.Add(UserInfo.Gwa);
					inputArrayList.Add(UserInfo.UserID);

                    Service.BeginTransaction();

					if(Service.ExecuteProcedure( spName, inputArrayList, outputArrayList))
					{

						if( outputArrayList[1].ToString() == "1")
						{
							XMessageBox.Show("Process Failed : [" +outputArrayList[0].ToString()+ "]");
                            Service.RollbackTransaction();
							return ;
						}
						else if( outputArrayList[1].ToString() != "0")
						{
                            XMessageBox.Show("Process Failed : [ PR_OCSI_APPLY_CPINFO ] ( flag != 0 ) FLAG=>" + outputArrayList[1].ToString() + " SERVICE ERR=>"+ outputArrayList[0].ToString());
                            Service.RollbackTransaction();
							return;
						}

						mbxMsg = NetInfo.Language == LangMode.Jr ? "処理が完了しました。" : "처리가 완료되었습니다.";
						SetMsg(mbxMsg);

						//약속코드선택정보가 있는 경우 Return Value
						IHIS.Framework.XScreen scrOpener = (XScreen)Opener;	

						CommonItemCollection commandParams  = new CommonItemCollection();
						commandParams.Add( "cp_code", dbxCp_code.GetDataValue());
						scrOpener.Command(ScreenID, commandParams);

                        Service.CommitTransaction();

						this.Close();

					}
					else
					{
						mbxMsg = NetInfo.Language == LangMode.Jr ? "処理が失敗しました。" : "처리가 실패하였습니다."; 
						mbxCap = NetInfo.Language == LangMode.Jr ? "Process Error" : "Save Error";
                        Service.RollbackTransaction();
						XMessageBox.Show(mbxMsg, mbxCap);
					}

					break;
		
				default:

					break;
			}
		}	

		#endregion

		#region [입원일(예약일)을 가져옵니다.]
		private string LoadIpwon_date(int fkinp1001)
		{
			string returnValue = "";

			string cmdText 
				= " SELECT A.IPWON_DATE "
				+ "   FROM VW_OCS_INP1001_RES A "
				+ "  WHERE A.HOSP_CODE = '" + EnvironInfo.HospCode + "' "
                + "    AND A.PKINP1001 = " + fkinp1001 + " ";
					
					
			object retVal = Service.ExecuteScalar(cmdText);

			if( retVal != null )
				returnValue = retVal.ToString();

			return returnValue;
		}
		#endregion

		private void dloOCS6000_QueryStarting(object sender, System.ComponentModel.CancelEventArgs e)
		{
			
			this.dloOCS6000.SetBindVarValue("f_memb", mMemb);
			this.dloOCS6000.SetBindVarValue("f_fkinp1001", mFkinp1001.ToString());
            this.dloOCS6000.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
		}

		private void dloOCS6000_QueryEnd(object sender, IHIS.Framework.QueryEndEventArgs e)
		{
			ShowTreeViewCPInfo();	
		}
	}
}

