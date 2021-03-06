using System;
using System.Collections.Generic;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Arguments.System;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Results.System;

namespace IHIS.Framework
{
	/// <summary>
	/// DetailPaInfoForm에 대한 요약 설명입니다.
	/// </summary>
	internal class DetailPaInfoForm : System.Windows.Forms.Form
	{
		#region Field and Property
		private string bunHo = "";  //전달받은 환자번호
		private Hashtable tabQueryList = new Hashtable();  //List에 Tab의 Query여부를 관리함.
		#endregion

		private IHIS.X.Magic.Controls.TabPage tabNormal;
		private IHIS.X.Magic.Controls.TabPage tabVisitList;
		private IHIS.Framework.XGrid grdVisitList;
		private IHIS.X.Magic.Controls.TabPage tabComment;
		private System.Windows.Forms.Panel xPanel7;
		private IHIS.Framework.XGridCell xGridCell1;
		private IHIS.Framework.XGridCell xGridCell2;
		private IHIS.Framework.XGridCell xGridCell3;
		private IHIS.Framework.XGridCell xGridCell4;
		private IHIS.Framework.XGridCell xGridCell5;
		private IHIS.Framework.XTabControl tabControl;
		private System.Windows.Forms.Panel pnlTop;
		private IHIS.Framework.XDisplayBox dbxPaInfo;
		private IHIS.Framework.XButton btnClose;
		private System.Windows.Forms.Panel pnlTabTop;
		private IHIS.Framework.XDisplayBox dbxZipCode;
		private IHIS.Framework.XDisplayBox dbxAddress;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox gbxInsure;
		private IHIS.Framework.XGrid grdInsure;
		private IHIS.Framework.XGridCell xGridCell7;
		private IHIS.Framework.XGridCell xGridCell8;
		private IHIS.Framework.XGridCell xGridCell9;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private IHIS.Framework.XGridCell xGridCell10;
		private IHIS.Framework.XGrid grdCmmt;
		private IHIS.Framework.XDisplayBox dbxTel1;
		private IHIS.Framework.XDisplayBox dbxTel;
		private IHIS.Framework.XGridCell xGridCell6;
		private IHIS.Framework.XGridCell xGridCell11;
		private IHIS.Framework.XGridCell xGridCell12;
		private IHIS.Framework.XGridCell xGridCell13;
		private IHIS.Framework.XDisplayBox dbxGaeinNo;
		private IHIS.Framework.XDisplayBox dbxLastCheckDate;
		private IHIS.Framework.XDisplayBox dbxJohapName;
		private IHIS.Framework.XDisplayBox dbxGaein;
        System.Windows.Forms.ToolTip tooltipDbxPaInfo = new System.Windows.Forms.ToolTip();
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public DetailPaInfoForm(Patient paInfo, Control cont)
		{
			//
			// Windows Form 디자이너 지원에 필요합니다.
			//
			InitializeComponent();

            this.grdVisitList.ParamList = createParamList();
            this.grdInsure.ParamList = createParamList();
            this.grdCmmt.ParamList = createParamList();
			
			SetControlTextByLangMode();

            // Connect Cloud
            this.grdInsure.ExecuteQuery = grdInsure_GetInsureInfo;
            this.grdVisitList.ExecuteQuery = grdVisitList_GetDataForGridVisitList;
            this.grdCmmt.ExecuteQuery = grdCmmt_GetCommentInfo;
		    //
			// TODO: InitializeComponent를 호출한 다음 생성자 코드를 추가합니다.
			//
			// 위치조정(버튼 Control의 하단에)
			if (cont != null)
			{
				/*Screen이 2개이상일 경우에는 rc의 Width는 두 모니터의 Width를 더한값, Height는
				 *Second화면의 해상도가 같으면 관계없으나, 해상도가 다르면 Second화면의 WorkingArea의 Y는
				 *0부터시작하지않고, Primary의 기준에서 얼만큼 높이에 있는냐로 처리됨.
				 *ex> Primary : 1280*1024 Second 1024*768이면 Primary.WorkingArea(0,0,1280,994) Second.WorkingArea(1280,256,1024,768)
				 *따라서, 높이는 Second의 WorkingArea의 Y + Height로 설정해야함
				 */
				Rectangle rc = Screen.PrimaryScreen.WorkingArea;
				// 위치 조정(Dual Monitor일때 Second화면에 있으면 X값은 Primary화면의Width + Second에서의 위치로 표시됨
				// 2006.03.28 모니터 3개이상도 고려하여 반영
				Point pos = cont.PointToScreen(new Point(0, cont.Height));
				if (SystemInformation.MonitorCount > 1)
				{
					//pos.X가 Second Monitor 이상에 있으면 rc 변경
					if (pos.X > rc.Width)
					{
						//두번째 Monitor 부터 위치 파악
						for (int i = 1 ; i < SystemInformation.MonitorCount; i++)
						{
							Rectangle sRect = Screen.AllScreens[i].WorkingArea;
							//cont가 위치하는 Monitor 확인
							if ((pos.X >= sRect.Left) && (pos.X <= sRect.Right))
							{
								rc = new Rectangle(rc.X, rc.Y, sRect.Right, sRect.Y + sRect.Height);
								break;
							}
						}
					}
				}

				if (this.Width > rc.Width - pos.X)
				{
					pos.X = Math.Max(rc.Width - this.Width, 0);
				}
				if (this.Height > rc.Height - pos.Y)
				{
					if (this.Height > pos.Y - cont.Height)
						pos.Y = Math.Max(rc.Height - this.Height, 0);
					else
						pos.Y -= (this.Height + cont.Height);
				}
				this.Location = pos;
			}

			this.bunHo = paInfo.BunHo;
			//Display = 환자번호 + 한자 + 가나 + 성별/나이 생년월일 (XPaComment와 동일하게)
            this.dbxPaInfo.SetDataValue(paInfo.BunHo + "   " + paInfo.SuName + "   " + paInfo.SuName2 + "   " + XPatientBox.GetSex(paInfo.Sex) + " / " + XPatientBox.GetAge(paInfo.YearAge) + "   " + XPatientBox.GetBirth( paInfo.Birth));
            tooltipDbxPaInfo.SetToolTip(dbxPaInfo, dbxPaInfo.Text);
            //주소,우편번호, 전화번호 SET
			this.dbxAddress.SetDataValue(paInfo.Address1.Trim() + " " + paInfo.Address2.Trim());
			this.dbxZipCode.SetDataValue(paInfo.Zip1 + "-" + paInfo.Zip2);
			this.dbxTel.SetDataValue(paInfo.Tel);
			this.dbxTel1.SetDataValue(paInfo.Tel1);

			//TabPage별 조회여부 SET(기본값 False) - Key는 TabIndex로 하여 관리함(추후 Tab추가시 또 추가)
			this.tabQueryList.Add("0", false);
			this.tabQueryList.Add("1", false);
			this.tabQueryList.Add("2", false);

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

		#region Windows Form 디자이너에서 생성한 코드
		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다.
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DetailPaInfoForm));
            this.pnlTop = new System.Windows.Forms.Panel();
            this.btnClose = new IHIS.Framework.XButton();
            this.dbxPaInfo = new IHIS.Framework.XDisplayBox();
            this.tabControl = new IHIS.Framework.XTabControl();
            this.tabNormal = new IHIS.X.Magic.Controls.TabPage();
            this.gbxInsure = new System.Windows.Forms.GroupBox();
            this.dbxGaeinNo = new IHIS.Framework.XDisplayBox();
            this.dbxLastCheckDate = new IHIS.Framework.XDisplayBox();
            this.dbxJohapName = new IHIS.Framework.XDisplayBox();
            this.dbxGaein = new IHIS.Framework.XDisplayBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.grdInsure = new IHIS.Framework.XGrid();
            this.xGridCell7 = new IHIS.Framework.XGridCell();
            this.xGridCell8 = new IHIS.Framework.XGridCell();
            this.xGridCell9 = new IHIS.Framework.XGridCell();
            this.xGridCell6 = new IHIS.Framework.XGridCell();
            this.xGridCell11 = new IHIS.Framework.XGridCell();
            this.xGridCell12 = new IHIS.Framework.XGridCell();
            this.xGridCell13 = new IHIS.Framework.XGridCell();
            this.pnlTabTop = new System.Windows.Forms.Panel();
            this.dbxAddress = new IHIS.Framework.XDisplayBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dbxTel1 = new IHIS.Framework.XDisplayBox();
            this.dbxTel = new IHIS.Framework.XDisplayBox();
            this.dbxZipCode = new IHIS.Framework.XDisplayBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tabVisitList = new IHIS.X.Magic.Controls.TabPage();
            this.grdVisitList = new IHIS.Framework.XGrid();
            this.xGridCell1 = new IHIS.Framework.XGridCell();
            this.xGridCell2 = new IHIS.Framework.XGridCell();
            this.xGridCell3 = new IHIS.Framework.XGridCell();
            this.xGridCell4 = new IHIS.Framework.XGridCell();
            this.xGridCell5 = new IHIS.Framework.XGridCell();
            this.tabComment = new IHIS.X.Magic.Controls.TabPage();
            this.xPanel7 = new System.Windows.Forms.Panel();
            this.grdCmmt = new IHIS.Framework.XGrid();
            this.xGridCell10 = new IHIS.Framework.XGridCell();
            this.pnlTop.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabNormal.SuspendLayout();
            this.gbxInsure.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdInsure)).BeginInit();
            this.pnlTabTop.SuspendLayout();
            this.tabVisitList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdVisitList)).BeginInit();
            this.tabComment.SuspendLayout();
            this.xPanel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCmmt)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.AccessibleDescription = null;
            this.pnlTop.AccessibleName = null;
            resources.ApplyResources(this.pnlTop, "pnlTop");
            this.pnlTop.BackgroundImage = null;
            this.pnlTop.Controls.Add(this.btnClose);
            this.pnlTop.Controls.Add(this.dbxPaInfo);
            this.pnlTop.Font = null;
            this.pnlTop.Name = "pnlTop";
            // 
            // btnClose
            // 
            this.btnClose.AccessibleDescription = null;
            this.btnClose.AccessibleName = null;
            resources.ApplyResources(this.btnClose, "btnClose");
            this.btnClose.BackgroundImage = null;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = null;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Name = "btnClose";
            this.btnClose.Scheme = IHIS.Framework.XButtonSchemes.OliveGreen;
            // 
            // dbxPaInfo
            // 
            this.dbxPaInfo.AccessibleDescription = null;
            this.dbxPaInfo.AccessibleName = null;
            resources.ApplyResources(this.dbxPaInfo, "dbxPaInfo");
            this.dbxPaInfo.Font = null;
            this.dbxPaInfo.Image = null;
            this.dbxPaInfo.Name = "dbxPaInfo";
            // 
            // tabControl
            // 
            this.tabControl.AccessibleDescription = null;
            this.tabControl.AccessibleName = null;
            resources.ApplyResources(this.tabControl, "tabControl");
            this.tabControl.BackgroundImage = null;
            this.tabControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabControl.Font = null;
            this.tabControl.IDEPixelArea = true;
            this.tabControl.IDEPixelBorder = false;
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.SelectedTab = this.tabNormal;
            this.tabControl.TabPages.AddRange(new IHIS.X.Magic.Controls.TabPage[] {
            this.tabNormal,
            this.tabVisitList,
            this.tabComment});
            this.tabControl.SelectionChanged += new System.EventHandler(this.tabControl_SelectionChanged);
            // 
            // tabNormal
            // 
            this.tabNormal.AccessibleDescription = null;
            this.tabNormal.AccessibleName = null;
            resources.ApplyResources(this.tabNormal, "tabNormal");
            this.tabNormal.BackgroundImage = null;
            this.tabNormal.Controls.Add(this.gbxInsure);
            this.tabNormal.Controls.Add(this.pnlTabTop);
            this.tabNormal.Font = null;
            this.tabNormal.Name = "tabNormal";
            // 
            // gbxInsure
            // 
            this.gbxInsure.AccessibleDescription = null;
            this.gbxInsure.AccessibleName = null;
            resources.ApplyResources(this.gbxInsure, "gbxInsure");
            this.gbxInsure.BackgroundImage = null;
            this.gbxInsure.Controls.Add(this.dbxGaeinNo);
            this.gbxInsure.Controls.Add(this.dbxLastCheckDate);
            this.gbxInsure.Controls.Add(this.dbxJohapName);
            this.gbxInsure.Controls.Add(this.dbxGaein);
            this.gbxInsure.Controls.Add(this.label5);
            this.gbxInsure.Controls.Add(this.label4);
            this.gbxInsure.Controls.Add(this.label3);
            this.gbxInsure.Controls.Add(this.label2);
            this.gbxInsure.Controls.Add(this.grdInsure);
            this.gbxInsure.Font = null;
            this.gbxInsure.Name = "gbxInsure";
            this.gbxInsure.TabStop = false;
            // 
            // dbxGaeinNo
            // 
            this.dbxGaeinNo.AccessibleDescription = null;
            this.dbxGaeinNo.AccessibleName = null;
            resources.ApplyResources(this.dbxGaeinNo, "dbxGaeinNo");
            this.dbxGaeinNo.Font = null;
            this.dbxGaeinNo.Image = null;
            this.dbxGaeinNo.Name = "dbxGaeinNo";
            // 
            // dbxLastCheckDate
            // 
            this.dbxLastCheckDate.AccessibleDescription = null;
            this.dbxLastCheckDate.AccessibleName = null;
            resources.ApplyResources(this.dbxLastCheckDate, "dbxLastCheckDate");
            this.dbxLastCheckDate.EditMaskType = IHIS.Framework.MaskType.Date;
            this.dbxLastCheckDate.Font = null;
            this.dbxLastCheckDate.Image = null;
            this.dbxLastCheckDate.Name = "dbxLastCheckDate";
            // 
            // dbxJohapName
            // 
            this.dbxJohapName.AccessibleDescription = null;
            this.dbxJohapName.AccessibleName = null;
            resources.ApplyResources(this.dbxJohapName, "dbxJohapName");
            this.dbxJohapName.Font = null;
            this.dbxJohapName.Image = null;
            this.dbxJohapName.Name = "dbxJohapName";
            // 
            // dbxGaein
            // 
            this.dbxGaein.AccessibleDescription = null;
            this.dbxGaein.AccessibleName = null;
            resources.ApplyResources(this.dbxGaein, "dbxGaein");
            this.dbxGaein.Font = null;
            this.dbxGaein.Image = null;
            this.dbxGaein.Name = "dbxGaein";
            // 
            // label5
            // 
            this.label5.AccessibleDescription = null;
            this.label5.AccessibleName = null;
            resources.ApplyResources(this.label5, "label5");
            this.label5.Font = null;
            this.label5.Name = "label5";
            // 
            // label4
            // 
            this.label4.AccessibleDescription = null;
            this.label4.AccessibleName = null;
            resources.ApplyResources(this.label4, "label4");
            this.label4.Font = null;
            this.label4.Name = "label4";
            // 
            // label3
            // 
            this.label3.AccessibleDescription = null;
            this.label3.AccessibleName = null;
            resources.ApplyResources(this.label3, "label3");
            this.label3.Font = null;
            this.label3.Name = "label3";
            // 
            // label2
            // 
            this.label2.AccessibleDescription = null;
            this.label2.AccessibleName = null;
            resources.ApplyResources(this.label2, "label2");
            this.label2.Font = null;
            this.label2.Name = "label2";
            // 
            // grdInsure
            // 
            resources.ApplyResources(this.grdInsure, "grdInsure");
            this.grdInsure.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xGridCell7,
            this.xGridCell8,
            this.xGridCell9,
            this.xGridCell6,
            this.xGridCell11,
            this.xGridCell12,
            this.xGridCell13});
            this.grdInsure.ColPerLine = 3;
            this.grdInsure.Cols = 3;
            this.grdInsure.ControlBinding = true;
            this.grdInsure.ExecuteQuery = null;
            this.grdInsure.FixedRows = 1;
            this.grdInsure.HeaderHeights.Add(24);
            this.grdInsure.Name = "grdInsure";
            this.grdInsure.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdInsure.ParamList")));
            this.grdInsure.QuerySQL = resources.GetString("grdInsure.QuerySQL");
            this.grdInsure.Rows = 2;
            this.grdInsure.ToolTipActive = true;
            this.grdInsure.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdInsure_QueryStarting);
            // 
            // xGridCell7
            // 
            this.xGridCell7.CellName = "from_jy_date";
            this.xGridCell7.CellType = IHIS.Framework.XCellDataType.Date;
            this.xGridCell7.CellWidth = 118;
            resources.ApplyResources(this.xGridCell7, "xGridCell7");
            // 
            // xGridCell8
            // 
            this.xGridCell8.CellName = "gubun_name";
            this.xGridCell8.CellWidth = 102;
            this.xGridCell8.Col = 1;
            resources.ApplyResources(this.xGridCell8, "xGridCell8");
            // 
            // xGridCell9
            // 
            this.xGridCell9.CellName = "to_jy_date";
            this.xGridCell9.CellType = IHIS.Framework.XCellDataType.Date;
            this.xGridCell9.CellWidth = 118;
            this.xGridCell9.Col = 2;
            resources.ApplyResources(this.xGridCell9, "xGridCell9");
            // 
            // xGridCell6
            // 
            this.xGridCell6.BindControl = this.dbxJohapName;
            this.xGridCell6.CellName = "johap_name";
            this.xGridCell6.Col = -1;
            resources.ApplyResources(this.xGridCell6, "xGridCell6");
            this.xGridCell6.IsVisible = false;
            this.xGridCell6.Row = -1;
            // 
            // xGridCell11
            // 
            this.xGridCell11.BindControl = this.dbxGaein;
            this.xGridCell11.CellName = "gaein";
            this.xGridCell11.Col = -1;
            resources.ApplyResources(this.xGridCell11, "xGridCell11");
            this.xGridCell11.IsVisible = false;
            this.xGridCell11.Row = -1;
            // 
            // xGridCell12
            // 
            this.xGridCell12.BindControl = this.dbxGaeinNo;
            this.xGridCell12.CellName = "gaein_no";
            this.xGridCell12.Col = -1;
            resources.ApplyResources(this.xGridCell12, "xGridCell12");
            this.xGridCell12.IsVisible = false;
            this.xGridCell12.Row = -1;
            // 
            // xGridCell13
            // 
            this.xGridCell13.BindControl = this.dbxLastCheckDate;
            this.xGridCell13.CellName = "last_check_date";
            this.xGridCell13.CellType = IHIS.Framework.XCellDataType.Date;
            this.xGridCell13.Col = -1;
            resources.ApplyResources(this.xGridCell13, "xGridCell13");
            this.xGridCell13.IsVisible = false;
            this.xGridCell13.Row = -1;
            // 
            // pnlTabTop
            // 
            this.pnlTabTop.AccessibleDescription = null;
            this.pnlTabTop.AccessibleName = null;
            resources.ApplyResources(this.pnlTabTop, "pnlTabTop");
            this.pnlTabTop.BackgroundImage = null;
            this.pnlTabTop.Controls.Add(this.dbxAddress);
            this.pnlTabTop.Controls.Add(this.label1);
            this.pnlTabTop.Controls.Add(this.dbxTel1);
            this.pnlTabTop.Controls.Add(this.dbxTel);
            this.pnlTabTop.Controls.Add(this.dbxZipCode);
            this.pnlTabTop.Controls.Add(this.label6);
            this.pnlTabTop.Font = null;
            this.pnlTabTop.Name = "pnlTabTop";
            // 
            // dbxAddress
            // 
            this.dbxAddress.AccessibleDescription = null;
            this.dbxAddress.AccessibleName = null;
            resources.ApplyResources(this.dbxAddress, "dbxAddress");
            this.dbxAddress.Font = null;
            this.dbxAddress.Image = null;
            this.dbxAddress.Name = "dbxAddress";
            // 
            // label1
            // 
            this.label1.AccessibleDescription = null;
            this.label1.AccessibleName = null;
            resources.ApplyResources(this.label1, "label1");
            this.label1.Font = null;
            this.label1.Name = "label1";
            // 
            // dbxTel1
            // 
            this.dbxTel1.AccessibleDescription = null;
            this.dbxTel1.AccessibleName = null;
            resources.ApplyResources(this.dbxTel1, "dbxTel1");
            this.dbxTel1.Font = null;
            this.dbxTel1.Image = null;
            this.dbxTel1.Name = "dbxTel1";
            // 
            // dbxTel
            // 
            this.dbxTel.AccessibleDescription = null;
            this.dbxTel.AccessibleName = null;
            resources.ApplyResources(this.dbxTel, "dbxTel");
            this.dbxTel.Font = null;
            this.dbxTel.Image = null;
            this.dbxTel.Name = "dbxTel";
            // 
            // dbxZipCode
            // 
            this.dbxZipCode.AccessibleDescription = null;
            this.dbxZipCode.AccessibleName = null;
            resources.ApplyResources(this.dbxZipCode, "dbxZipCode");
            this.dbxZipCode.Font = null;
            this.dbxZipCode.Image = null;
            this.dbxZipCode.Name = "dbxZipCode";
            // 
            // label6
            // 
            this.label6.AccessibleDescription = null;
            this.label6.AccessibleName = null;
            resources.ApplyResources(this.label6, "label6");
            this.label6.Font = null;
            this.label6.Name = "label6";
            // 
            // tabVisitList
            // 
            this.tabVisitList.AccessibleDescription = null;
            this.tabVisitList.AccessibleName = null;
            resources.ApplyResources(this.tabVisitList, "tabVisitList");
            this.tabVisitList.BackgroundImage = null;
            this.tabVisitList.Controls.Add(this.grdVisitList);
            this.tabVisitList.Font = null;
            this.tabVisitList.Name = "tabVisitList";
            this.tabVisitList.Selected = false;
            // 
            // grdVisitList
            // 
            resources.ApplyResources(this.grdVisitList, "grdVisitList");
            this.grdVisitList.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xGridCell1,
            this.xGridCell2,
            this.xGridCell3,
            this.xGridCell4,
            this.xGridCell5});
            this.grdVisitList.ColPerLine = 5;
            this.grdVisitList.Cols = 5;
            this.grdVisitList.ExecuteQuery = null;
            this.grdVisitList.FixedRows = 1;
            this.grdVisitList.HeaderHeights.Add(24);
            this.grdVisitList.Name = "grdVisitList";
            this.grdVisitList.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdVisitList.ParamList")));
            this.grdVisitList.QuerySQL = resources.GetString("grdVisitList.QuerySQL");
            this.grdVisitList.Rows = 2;
            this.grdVisitList.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdVisitList_QueryStarting);
            // 
            // xGridCell1
            // 
            this.xGridCell1.CellName = "o_VisitDate";
            this.xGridCell1.CellType = IHIS.Framework.XCellDataType.Date;
            this.xGridCell1.CellWidth = 135;
            resources.ApplyResources(this.xGridCell1, "xGridCell1");
            // 
            // xGridCell2
            // 
            this.xGridCell2.CellName = "o_DeptName";
            this.xGridCell2.CellWidth = 99;
            this.xGridCell2.Col = 1;
            resources.ApplyResources(this.xGridCell2, "xGridCell2");
            // 
            // xGridCell3
            // 
            this.xGridCell3.CellName = "o_InOutMode";
            this.xGridCell3.CellWidth = 85;
            this.xGridCell3.Col = 2;
            resources.ApplyResources(this.xGridCell3, "xGridCell3");
            // 
            // xGridCell4
            // 
            this.xGridCell4.CellName = "o_DoctorName";
            this.xGridCell4.CellWidth = 109;
            this.xGridCell4.Col = 3;
            resources.ApplyResources(this.xGridCell4, "xGridCell4");
            // 
            // xGridCell5
            // 
            this.xGridCell5.CellName = "o_OutDate";
            this.xGridCell5.CellType = IHIS.Framework.XCellDataType.Date;
            this.xGridCell5.CellWidth = 119;
            this.xGridCell5.Col = 4;
            resources.ApplyResources(this.xGridCell5, "xGridCell5");
            // 
            // tabComment
            // 
            this.tabComment.AccessibleDescription = null;
            this.tabComment.AccessibleName = null;
            resources.ApplyResources(this.tabComment, "tabComment");
            this.tabComment.BackgroundImage = null;
            this.tabComment.Controls.Add(this.xPanel7);
            this.tabComment.Font = null;
            this.tabComment.Name = "tabComment";
            this.tabComment.Selected = false;
            // 
            // xPanel7
            // 
            this.xPanel7.AccessibleDescription = null;
            this.xPanel7.AccessibleName = null;
            resources.ApplyResources(this.xPanel7, "xPanel7");
            this.xPanel7.BackgroundImage = null;
            this.xPanel7.Controls.Add(this.grdCmmt);
            this.xPanel7.Font = null;
            this.xPanel7.Name = "xPanel7";
            // 
            // grdCmmt
            // 
            resources.ApplyResources(this.grdCmmt, "grdCmmt");
            this.grdCmmt.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xGridCell10});
            this.grdCmmt.ColPerLine = 1;
            this.grdCmmt.Cols = 2;
            this.grdCmmt.ExecuteQuery = null;
            this.grdCmmt.FixedCols = 1;
            this.grdCmmt.FixedRows = 1;
            this.grdCmmt.HeaderHeights.Add(26);
            this.grdCmmt.Name = "grdCmmt";
            this.grdCmmt.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdCmmt.ParamList")));
            this.grdCmmt.RowHeaderVisible = true;
            this.grdCmmt.Rows = 2;
            this.grdCmmt.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdCmmt_QueryStarting);
            // 
            // xGridCell10
            // 
            this.xGridCell10.CellName = "comment";
            this.xGridCell10.CellWidth = 501;
            this.xGridCell10.Col = 1;
            resources.ApplyResources(this.xGridCell10, "xGridCell10");
            // 
            // DetailPaInfoForm
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = null;
            this.CancelButton = this.btnClose;
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.pnlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = null;
            this.Name = "DetailPaInfoForm";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.DetailPaInfoForm_Load);
            this.pnlTop.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabNormal.ResumeLayout(false);
            this.gbxInsure.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdInsure)).EndInit();
            this.pnlTabTop.ResumeLayout(false);
            this.tabVisitList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdVisitList)).EndInit();
            this.tabComment.ResumeLayout(false);
            this.xPanel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdCmmt)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		//일본어, 한글 모드에 따른 Text 설정
		private void SetControlTextByLangMode()
		{
			this.Text = XMsg.GetField("F051"); //환자상세정보
			this.btnClose.Text = XMsg.GetField("F008");
		}

		#region Tab변경시에 다음사항을 조회하는데 이미 조회된 상태이면 조회하지 않음
		private void tabControl_SelectionChanged(object sender, System.EventArgs e)
		{
			int index = tabControl.SelectedIndex;
			if (index < 0) return;
			
			//조회여부 확인, 다시 조회하지는 않음
			bool isQueryed = (bool) this.tabQueryList[index.ToString()];
			if (isQueryed) return;  
			//index에 따라 조회할 GRID 다르게 설정
			XGrid qryGrid = null;
			switch (index)
			{
				case 0:    
					//보험사항조회
					qryGrid = this.grdInsure;
					break;
				case 1:
					//내원사항조회
					qryGrid = this.grdVisitList;
					break;
				case 2:
					//특이사항조회
					qryGrid = this.grdCmmt;
					break;
			}
			if (qryGrid != null)
			{
				//Grid 조회
				qryGrid.QueryLayout(true);
				//완료후 해당 Index의 조회여부 true로 설정
				this.tabQueryList[index.ToString()] = true;
			}
			
		}
		#endregion

		private void DetailPaInfoForm_Load(object sender, System.EventArgs e)
		{
			//Load시에 첫번째 Tab이 선택되어 있으므로 보험사항 조회하도록 Event Call
			tabControl_SelectionChanged(this.tabControl, EventArgs.Empty);
		}
		
		#region QueryStarting
		private void grdInsure_QueryStarting(object sender, System.ComponentModel.CancelEventArgs e)
		{
			//f_bunho Bind 변수 SET
			grdInsure.SetBindVarValue("f_bunho", this.bunHo);
		}

		private void grdVisitList_QueryStarting(object sender, System.ComponentModel.CancelEventArgs e)
		{
			//f_bunho Bind 변수 SET
			grdVisitList.SetBindVarValue("f_bunho", this.bunHo);
		}

		private void grdCmmt_QueryStarting(object sender, System.ComponentModel.CancelEventArgs e)
		{
			//f_bunho Bind 변수 SET
			grdCmmt.SetBindVarValue("f_bunho", this.bunHo);
		}
		#endregion

        #region Create ParamList
	    private List<string> createParamList()
	    {
	       List<string> lstParam = new List<string>();
           lstParam.Add("f_bunho");
	        return lstParam;
	    }
        #endregion

        #region Get data from Cloud

	    private IList<object[]> grdInsure_GetInsureInfo(BindVarCollection bindVarCollection)
	    {
            IList<object[]> listResult = new List<object[]>();
            DetailPaInfoFormGridInsureArgs detailPaInfoFormGridInsureArgs = new DetailPaInfoFormGridInsureArgs(bindVarCollection["f_bunho"].VarValue);
            DetailPaInfoFormGridInsureResult gridInsureResult =
                CloudService.Instance.Submit<DetailPaInfoFormGridInsureResult, DetailPaInfoFormGridInsureArgs>(
                    detailPaInfoFormGridInsureArgs);
            if (gridInsureResult != null)
            {
                IList<DetailPaInfoFormGridInsureInfo> lstGridInsureInfo = gridInsureResult.GridInsureItem;
                if (lstGridInsureInfo != null && lstGridInsureInfo.Count > 0)
                {
                    foreach (DetailPaInfoFormGridInsureInfo gridInsureInfo in lstGridInsureInfo)
                    {
                        object[] insureInfo =
                        {
                            gridInsureInfo.StartDate,
                            gridInsureInfo.TypeName,
                            gridInsureInfo.EndDate,
                            gridInsureInfo.JohapName,
                            gridInsureInfo.Percentage,
                            gridInsureInfo.PercentageNo,
                            gridInsureInfo.LastCheckDate
                        };
                        listResult.Add(insureInfo);
                    }
                }
            }
	        return listResult;
	    }

	    private IList<object[]> grdVisitList_GetDataForGridVisitList(BindVarCollection bindVarCollection)
	    {
            IList<object[]> listResult = new List<object[]>();
            DetailPaInfoFormGridVisitListArgs gridVisitListArg = new DetailPaInfoFormGridVisitListArgs(bindVarCollection["f_bunho"].VarValue);
            DetailPaInfoFormGridVisitListResult gridVisitListResult = gridVisitListResult =
                        CloudService.Instance
                            .Submit<DetailPaInfoFormGridVisitListResult, DetailPaInfoFormGridVisitListArgs>(
                                gridVisitListArg);
            if (gridVisitListResult != null)
            {
                IList<DetailPaInfoFormGridVisitListInfo> lstGridVisitListInfos =
                    gridVisitListResult.GridVisitItem;
                if (lstGridVisitListInfos != null && lstGridVisitListInfos.Count > 0)
                {
                    foreach (DetailPaInfoFormGridVisitListInfo dataInfo in lstGridVisitListInfos)
                    {
                        object[] insureInfo =
                        {
                            dataInfo.ComingDate,
                            dataInfo.DepartmentName,
                            dataInfo.TypeName,
                            dataInfo.DoctorName,
                            dataInfo.OutDate
                        };
                        listResult.Add(insureInfo);
                    }
                    
                }
            }
            return listResult;
	    }

	    private IList<object[]> grdCmmt_GetCommentInfo(BindVarCollection bindVarCollection)
	    {
            IList<object[]> listResult = new List<object[]>();
            DetailPaInfoFormGridCommentArgs gridCommentArgs = new DetailPaInfoFormGridCommentArgs(bindVarCollection["f_bunho"].VarValue);
            DetailPaInfoFormGridCommentResult gridCommentResult =
                CloudService.Instance.Submit<DetailPaInfoFormGridCommentResult, DetailPaInfoFormGridCommentArgs>
                    (gridCommentArgs);
            if (gridCommentResult != null)
            {
                IList<DetailPaInfoFormGridCommentInfo> lstGridCommentInfo = gridCommentResult.CommentItem;
                if (lstGridCommentInfo != null && lstGridCommentInfo.Count > 0)
                {
                    foreach (DetailPaInfoFormGridCommentInfo commentInfo in lstGridCommentInfo)
                    {
                        object[] comment =
                        {
                            commentInfo.Comment
                        };
                        listResult.Add(comment);
                    }

                }
            }
            return listResult;
	    }  
	    #endregion
	}
}
