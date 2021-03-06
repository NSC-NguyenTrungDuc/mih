#region 사용 NameSpace 지정
using System;
using System.IO;
using System.Text;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.Framework;
using System.Collections.Generic;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Arguments;
using IHIS.CloudConnector.Contracts.Arguments.Ocso;
using IHIS.CloudConnector.Contracts.Results.Ocso;
using IHIS.CloudConnector.Contracts.Models.Ocso;
using IHIS.OCSO.Properties;

#endregion

namespace IHIS.OCSO
{
	/// <summary>
	/// OCS1003R02에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class OCS1003R02 : IHIS.Framework.XScreen
	{
		#region 추가사항
		private string bunho       = string.Empty;
		private string naewon_date = string.Empty;
		private string gwa         = string.Empty;
		private string doctor      = string.Empty;
		private string naewon_type = string.Empty;
		private string jubsu_no    = string.Empty;
        private string pk_naewon   = string.Empty;
        
		//화면 Display 여부
		private bool mAuto_close = false;
        //HOSPITAL CODE
        private string mHospCode = EnvironInfo.HospCode;
		#endregion

		#region 자동생성

		private IHIS.Framework.XPanel pnlBottom;
		private IHIS.Framework.XButtonList btnList;
		private IHIS.Framework.XDataWindow dw_OCS1003R02;
		private IHIS.Framework.XPanel pnlTop;
		private IHIS.Framework.XRadioButton rbx02;
		private IHIS.Framework.XRadioButton rbx03;
		private IHIS.Framework.XPanel pnl02;
		private IHIS.Framework.XPanel pnl03;
		private IHIS.Framework.XDataWindow dw_OCS1003R03;
		private IHIS.Framework.XPanel pnl04;
		private IHIS.Framework.XDataWindow dw_OCS1003R04;
		private IHIS.Framework.XRadioButton rbx04;
		private IHIS.Framework.XRadioButton rbx05;
		private IHIS.Framework.XPanel pnl05;
		private IHIS.Framework.XDataWindow dw_OCS1003R05;
		#endregion

		private IHIS.Framework.MultiLayout layOCS1003R02;
        private IHIS.Framework.MultiLayout layOCS1003R03;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem11;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem12;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem13;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem14;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem15;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem16;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem17;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem18;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem19;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem20;
		private IHIS.Framework.MultiLayout layOCS1003R04;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem21;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem22;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem23;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem24;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem25;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem26;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem27;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem28;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem29;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem30;
		private IHIS.Framework.MultiLayout layOCS1003R05;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem41;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem42;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem43;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem44;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem45;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem46;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem47;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem48;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem49;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem50;
        private MultiLayoutItem multiLayoutItem1;
        private MultiLayoutItem multiLayoutItem2;
        private MultiLayoutItem multiLayoutItem3;
        private MultiLayoutItem multiLayoutItem4;
        private MultiLayoutItem multiLayoutItem5;
        private MultiLayoutItem multiLayoutItem6;
        private MultiLayoutItem multiLayoutItem7;
        private MultiLayoutItem multiLayoutItem8;
        private MultiLayoutItem multiLayoutItem9;
        private MultiLayoutItem multiLayoutItem10;
        private MultiLayoutItem multiLayoutItem53;
        private MultiLayoutItem multiLayoutItem54;
        private MultiLayoutItem multiLayoutItem55;
        private MultiLayoutItem multiLayoutItem56;
        private MultiLayoutItem multiLayoutItem57;
        private MultiLayoutItem multiLayoutItem58;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public OCS1003R02()
		{
			// 이 호출은 Windows Form 디자이너에 필요합니다.
			InitializeComponent();

            //added by Cloud version
            layOCS1003R02.ParamList = new List<String>(new String[] { "f_gwa", "f_bunho", "f_naewon_date", "f_doctor", "f_naewon_type", "f_jubsu_no", "f_fkout1001", "f_user_id" });
            layOCS1003R03.ParamList = new List<String>(new String[] { "f_gwa", "f_bunho", "f_naewon_date", "f_doctor", "f_naewon_type", "f_jubsu_no" });
            layOCS1003R04.ParamList = new List<String>(new String[] { "f_gwa", "f_bunho", "f_naewon_date", "f_doctor", "f_naewon_type", "f_jubsu_no" });
            layOCS1003R05.ParamList = new List<String>(new String[] { "f_gwa", "f_bunho", "f_naewon_date", "f_doctor", "f_naewon_type", "f_jubsu_no" });

            layOCS1003R02.ExecuteQuery = LoadDataLayOCS1003R02;
            layOCS1003R03.ExecuteQuery = LoadDataLayOCS1003R03;
            layOCS1003R04.ExecuteQuery = LoadDataLayOCS1003R03;
            layOCS1003R05.ExecuteQuery = LoadDataLayOCS1003R03;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OCS1003R02));
            this.pnlBottom = new IHIS.Framework.XPanel();
            this.btnList = new IHIS.Framework.XButtonList();
            this.dw_OCS1003R02 = new IHIS.Framework.XDataWindow();
            this.pnlTop = new IHIS.Framework.XPanel();
            this.rbx05 = new IHIS.Framework.XRadioButton();
            this.rbx04 = new IHIS.Framework.XRadioButton();
            this.rbx03 = new IHIS.Framework.XRadioButton();
            this.rbx02 = new IHIS.Framework.XRadioButton();
            this.pnl02 = new IHIS.Framework.XPanel();
            this.pnl03 = new IHIS.Framework.XPanel();
            this.dw_OCS1003R03 = new IHIS.Framework.XDataWindow();
            this.pnl04 = new IHIS.Framework.XPanel();
            this.dw_OCS1003R04 = new IHIS.Framework.XDataWindow();
            this.pnl05 = new IHIS.Framework.XPanel();
            this.dw_OCS1003R05 = new IHIS.Framework.XDataWindow();
            this.layOCS1003R02 = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem1 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem3 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem4 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem5 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem6 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem7 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem8 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem9 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem10 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem53 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem54 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem55 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem56 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem57 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem58 = new IHIS.Framework.MultiLayoutItem();
            this.layOCS1003R03 = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem11 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem12 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem13 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem14 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem15 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem16 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem17 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem18 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem19 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem20 = new IHIS.Framework.MultiLayoutItem();
            this.layOCS1003R04 = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem21 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem22 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem23 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem24 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem25 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem26 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem27 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem28 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem29 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem30 = new IHIS.Framework.MultiLayoutItem();
            this.layOCS1003R05 = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem41 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem42 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem43 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem44 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem45 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem46 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem47 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem48 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem49 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem50 = new IHIS.Framework.MultiLayoutItem();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.pnl02.SuspendLayout();
            this.pnl03.SuspendLayout();
            this.pnl04.SuspendLayout();
            this.pnl05.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layOCS1003R02)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layOCS1003R03)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layOCS1003R04)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layOCS1003R05)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            resources.ApplyResources(this.ImageList, "ImageList");
            // 
            // pnlBottom
            // 
            this.pnlBottom.AccessibleDescription = null;
            this.pnlBottom.AccessibleName = null;
            resources.ApplyResources(this.pnlBottom, "pnlBottom");
            this.pnlBottom.BackgroundImage = null;
            this.pnlBottom.Controls.Add(this.btnList);
            this.pnlBottom.Font = null;
            this.pnlBottom.Name = "pnlBottom";
            // 
            // btnList
            // 
            this.btnList.AccessibleDescription = null;
            this.btnList.AccessibleName = null;
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.BackgroundImage = null;
            this.btnList.IsVisiblePreview = false;
            this.btnList.IsVisibleReset = false;
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Report;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // dw_OCS1003R02
            // 
            resources.ApplyResources(this.dw_OCS1003R02, "dw_OCS1003R02");
            this.dw_OCS1003R02.DataWindowObject = "dw_ocs1003r02";
            this.dw_OCS1003R02.LibraryList = "OCSO\\ocso.ocs1003r02.pbd";
            this.dw_OCS1003R02.Name = "dw_OCS1003R02";
            this.dw_OCS1003R02.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Vertical;
            // 
            // pnlTop
            // 
            this.pnlTop.AccessibleDescription = null;
            this.pnlTop.AccessibleName = null;
            resources.ApplyResources(this.pnlTop, "pnlTop");
            this.pnlTop.BackgroundImage = null;
            this.pnlTop.Controls.Add(this.rbx05);
            this.pnlTop.Controls.Add(this.rbx04);
            this.pnlTop.Controls.Add(this.rbx03);
            this.pnlTop.Controls.Add(this.rbx02);
            this.pnlTop.Font = null;
            this.pnlTop.Name = "pnlTop";
            // 
            // rbx05
            // 
            this.rbx05.AccessibleDescription = null;
            this.rbx05.AccessibleName = null;
            resources.ApplyResources(this.rbx05, "rbx05");
            this.rbx05.BackgroundImage = null;
            this.rbx05.Name = "rbx05";
            this.rbx05.Tag = "";
            this.rbx05.UseVisualStyleBackColor = false;
            this.rbx05.CheckedChanged += new System.EventHandler(this.rbx02_CheckedChanged);
            // 
            // rbx04
            // 
            this.rbx04.AccessibleDescription = null;
            this.rbx04.AccessibleName = null;
            resources.ApplyResources(this.rbx04, "rbx04");
            this.rbx04.BackgroundImage = null;
            this.rbx04.Name = "rbx04";
            this.rbx04.Tag = "";
            this.rbx04.UseVisualStyleBackColor = false;
            this.rbx04.CheckedChanged += new System.EventHandler(this.rbx02_CheckedChanged);
            // 
            // rbx03
            // 
            this.rbx03.AccessibleDescription = null;
            this.rbx03.AccessibleName = null;
            resources.ApplyResources(this.rbx03, "rbx03");
            this.rbx03.BackgroundImage = null;
            this.rbx03.Name = "rbx03";
            this.rbx03.Tag = "";
            this.rbx03.UseVisualStyleBackColor = false;
            this.rbx03.CheckedChanged += new System.EventHandler(this.rbx02_CheckedChanged);
            // 
            // rbx02
            // 
            this.rbx02.AccessibleDescription = null;
            this.rbx02.AccessibleName = null;
            resources.ApplyResources(this.rbx02, "rbx02");
            this.rbx02.BackgroundImage = null;
            this.rbx02.Name = "rbx02";
            this.rbx02.Tag = "";
            this.rbx02.UseVisualStyleBackColor = false;
            this.rbx02.CheckedChanged += new System.EventHandler(this.rbx02_CheckedChanged);
            // 
            // pnl02
            // 
            this.pnl02.AccessibleDescription = null;
            this.pnl02.AccessibleName = null;
            resources.ApplyResources(this.pnl02, "pnl02");
            this.pnl02.BackgroundImage = null;
            this.pnl02.Controls.Add(this.dw_OCS1003R02);
            this.pnl02.Font = null;
            this.pnl02.Name = "pnl02";
            // 
            // pnl03
            // 
            this.pnl03.AccessibleDescription = null;
            this.pnl03.AccessibleName = null;
            resources.ApplyResources(this.pnl03, "pnl03");
            this.pnl03.BackgroundImage = null;
            this.pnl03.Controls.Add(this.dw_OCS1003R03);
            this.pnl03.Font = null;
            this.pnl03.Name = "pnl03";
            // 
            // dw_OCS1003R03
            // 
            resources.ApplyResources(this.dw_OCS1003R03, "dw_OCS1003R03");
            this.dw_OCS1003R03.DataWindowObject = "dw_ocs1003r03";
            this.dw_OCS1003R03.LibraryList = "OCSO\\ocso.ocs1003r02.pbd";
            this.dw_OCS1003R03.Name = "dw_OCS1003R03";
            this.dw_OCS1003R03.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Vertical;
            // 
            // pnl04
            // 
            this.pnl04.AccessibleDescription = null;
            this.pnl04.AccessibleName = null;
            resources.ApplyResources(this.pnl04, "pnl04");
            this.pnl04.BackgroundImage = null;
            this.pnl04.Controls.Add(this.dw_OCS1003R04);
            this.pnl04.Font = null;
            this.pnl04.Name = "pnl04";
            // 
            // dw_OCS1003R04
            // 
            resources.ApplyResources(this.dw_OCS1003R04, "dw_OCS1003R04");
            this.dw_OCS1003R04.DataWindowObject = "dw_ocs1003r04";
            this.dw_OCS1003R04.LibraryList = "OCSO\\ocso.ocs1003r02.pbd";
            this.dw_OCS1003R04.Name = "dw_OCS1003R04";
            this.dw_OCS1003R04.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Vertical;
            // 
            // pnl05
            // 
            this.pnl05.AccessibleDescription = null;
            this.pnl05.AccessibleName = null;
            resources.ApplyResources(this.pnl05, "pnl05");
            this.pnl05.BackgroundImage = null;
            this.pnl05.Controls.Add(this.dw_OCS1003R05);
            this.pnl05.Font = null;
            this.pnl05.Name = "pnl05";
            // 
            // dw_OCS1003R05
            // 
            resources.ApplyResources(this.dw_OCS1003R05, "dw_OCS1003R05");
            this.dw_OCS1003R05.DataWindowObject = "dw_ocs1003r05";
            this.dw_OCS1003R05.LibraryList = "OCSO\\ocso.ocs1003r02.pbd";
            this.dw_OCS1003R05.Name = "dw_OCS1003R05";
            this.dw_OCS1003R05.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Vertical;
            // 
            // layOCS1003R02
            // 
            this.layOCS1003R02.ExecuteQuery = null;
            this.layOCS1003R02.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem1,
            this.multiLayoutItem2,
            this.multiLayoutItem3,
            this.multiLayoutItem4,
            this.multiLayoutItem5,
            this.multiLayoutItem6,
            this.multiLayoutItem7,
            this.multiLayoutItem8,
            this.multiLayoutItem9,
            this.multiLayoutItem10,
            this.multiLayoutItem53,
            this.multiLayoutItem54,
            this.multiLayoutItem55,
            this.multiLayoutItem56,
            this.multiLayoutItem57,
            this.multiLayoutItem58});
            this.layOCS1003R02.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layOCS1003R02.ParamList")));
            this.layOCS1003R02.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layOCS1003R02_QueryStarting);
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "gwa";
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "gwa_name";
            // 
            // multiLayoutItem3
            // 
            this.multiLayoutItem3.DataName = "bunho";
            // 
            // multiLayoutItem4
            // 
            this.multiLayoutItem4.DataName = "suname";
            // 
            // multiLayoutItem5
            // 
            this.multiLayoutItem5.DataName = "balheang_date";
            // 
            // multiLayoutItem6
            // 
            this.multiLayoutItem6.DataName = "birth";
            // 
            // multiLayoutItem7
            // 
            this.multiLayoutItem7.DataName = "naewon_date";
            // 
            // multiLayoutItem8
            // 
            this.multiLayoutItem8.DataName = "comments";
            // 
            // multiLayoutItem9
            // 
            this.multiLayoutItem9.DataName = "bunho_1";
            // 
            // multiLayoutItem10
            // 
            this.multiLayoutItem10.DataName = "dangil_gumsa_result_yn";
            // 
            // multiLayoutItem53
            // 
            this.multiLayoutItem53.DataName = "fkout1001";
            this.multiLayoutItem53.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem54
            // 
            this.multiLayoutItem54.DataName = "acting_check_yn";
            // 
            // multiLayoutItem55
            // 
            this.multiLayoutItem55.DataName = "jaedan_name";
            // 
            // multiLayoutItem56
            // 
            this.multiLayoutItem56.DataName = "hosp_name";
            // 
            // multiLayoutItem57
            // 
            this.multiLayoutItem57.DataName = "tel";
            // 
            // multiLayoutItem58
            // 
            this.multiLayoutItem58.DataName = "homepage";
            // 
            // layOCS1003R03
            // 
            this.layOCS1003R03.ExecuteQuery = null;
            this.layOCS1003R03.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem11,
            this.multiLayoutItem12,
            this.multiLayoutItem13,
            this.multiLayoutItem14,
            this.multiLayoutItem15,
            this.multiLayoutItem16,
            this.multiLayoutItem17,
            this.multiLayoutItem18,
            this.multiLayoutItem19,
            this.multiLayoutItem20});
            this.layOCS1003R03.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layOCS1003R03.ParamList")));
            this.layOCS1003R03.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layOCS1003R03_QueryStarting);
            // 
            // multiLayoutItem11
            // 
            this.multiLayoutItem11.DataName = "gwa";
            // 
            // multiLayoutItem12
            // 
            this.multiLayoutItem12.DataName = "gwa_name";
            // 
            // multiLayoutItem13
            // 
            this.multiLayoutItem13.DataName = "bunho";
            // 
            // multiLayoutItem14
            // 
            this.multiLayoutItem14.DataName = "suname";
            // 
            // multiLayoutItem15
            // 
            this.multiLayoutItem15.DataName = "balheang_date";
            // 
            // multiLayoutItem16
            // 
            this.multiLayoutItem16.DataName = "birth";
            // 
            // multiLayoutItem17
            // 
            this.multiLayoutItem17.DataName = "naewon_date";
            // 
            // multiLayoutItem18
            // 
            this.multiLayoutItem18.DataName = "move_name";
            // 
            // multiLayoutItem19
            // 
            this.multiLayoutItem19.DataName = "bunho_1";
            // 
            // multiLayoutItem20
            // 
            this.multiLayoutItem20.DataName = "hope_date";
            // 
            // layOCS1003R04
            // 
            this.layOCS1003R04.ExecuteQuery = null;
            this.layOCS1003R04.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem21,
            this.multiLayoutItem22,
            this.multiLayoutItem23,
            this.multiLayoutItem24,
            this.multiLayoutItem25,
            this.multiLayoutItem26,
            this.multiLayoutItem27,
            this.multiLayoutItem28,
            this.multiLayoutItem29,
            this.multiLayoutItem30});
            this.layOCS1003R04.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layOCS1003R04.ParamList")));
            this.layOCS1003R04.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layOCS1003R04_QueryStarting);
            // 
            // multiLayoutItem21
            // 
            this.multiLayoutItem21.DataName = "gwa";
            // 
            // multiLayoutItem22
            // 
            this.multiLayoutItem22.DataName = "gwa_name";
            // 
            // multiLayoutItem23
            // 
            this.multiLayoutItem23.DataName = "bunho";
            // 
            // multiLayoutItem24
            // 
            this.multiLayoutItem24.DataName = "suname";
            // 
            // multiLayoutItem25
            // 
            this.multiLayoutItem25.DataName = "balheang_date";
            // 
            // multiLayoutItem26
            // 
            this.multiLayoutItem26.DataName = "birth";
            // 
            // multiLayoutItem27
            // 
            this.multiLayoutItem27.DataName = "naewon_date";
            // 
            // multiLayoutItem28
            // 
            this.multiLayoutItem28.DataName = "move_name";
            // 
            // multiLayoutItem29
            // 
            this.multiLayoutItem29.DataName = "bunho_1";
            // 
            // multiLayoutItem30
            // 
            this.multiLayoutItem30.DataName = "hope_date";
            // 
            // layOCS1003R05
            // 
            this.layOCS1003R05.ExecuteQuery = null;
            this.layOCS1003R05.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem41,
            this.multiLayoutItem42,
            this.multiLayoutItem43,
            this.multiLayoutItem44,
            this.multiLayoutItem45,
            this.multiLayoutItem46,
            this.multiLayoutItem47,
            this.multiLayoutItem48,
            this.multiLayoutItem49,
            this.multiLayoutItem50});
            this.layOCS1003R05.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layOCS1003R05.ParamList")));
            this.layOCS1003R05.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layOCS1003R05_QueryStarting);
            // 
            // multiLayoutItem41
            // 
            this.multiLayoutItem41.DataName = "gwa";
            // 
            // multiLayoutItem42
            // 
            this.multiLayoutItem42.DataName = "gwa_name";
            // 
            // multiLayoutItem43
            // 
            this.multiLayoutItem43.DataName = "bunho";
            // 
            // multiLayoutItem44
            // 
            this.multiLayoutItem44.DataName = "suname";
            // 
            // multiLayoutItem45
            // 
            this.multiLayoutItem45.DataName = "balheang_date";
            // 
            // multiLayoutItem46
            // 
            this.multiLayoutItem46.DataName = "birth";
            // 
            // multiLayoutItem47
            // 
            this.multiLayoutItem47.DataName = "naewon_date";
            // 
            // multiLayoutItem48
            // 
            this.multiLayoutItem48.DataName = "move_name";
            // 
            // multiLayoutItem49
            // 
            this.multiLayoutItem49.DataName = "bunho_1";
            // 
            // multiLayoutItem50
            // 
            this.multiLayoutItem50.DataName = "hope_date";
            // 
            // OCS1003R02
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.pnl05);
            this.Controls.Add(this.pnl04);
            this.Controls.Add(this.pnl03);
            this.Controls.Add(this.pnl02);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pnlBottom);
            this.Name = "OCS1003R02";
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.OCS1003R02_ScreenOpen);
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnl02.ResumeLayout(false);
            this.pnl03.ResumeLayout(false);
            this.pnl04.ResumeLayout(false);
            this.pnl05.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layOCS1003R02)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layOCS1003R03)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layOCS1003R04)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layOCS1003R05)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region 메세지처리
		private void GetMessage(string aMesgGubun)
		{
			string msg = string.Empty;
			string caption = string.Empty;
			
			switch(aMesgGubun)
			{
				case "Print_err":
					msg =  Resources.MSG001;
					caption =  Resources.MSG001_CAP;
					XMessageBox.Show(msg, caption, MessageBoxIcon.Error);
					break;
				default:
					break;
			}
		}
		#endregion

		#region 조회
		private void GetOCS1003R02()
		{
			if(this.rbx02.Checked == true)
			{
				/* 환자안내서 */
//				layOCS1003R02.SetBindVarValue("f_bunho", this.bunho.ToString());
//				layOCS1003R02.SetBindVarValue("f_naewon_date", this.naewon_date.ToString());
//				layOCS1003R02.SetBindVarValue("f_gwa", this.gwa.ToString());
//				layOCS1003R02.SetBindVarValue("f_doctor", this.doctor.ToString());
//				layOCS1003R02.SetBindVarValue("f_naewon_type", this.naewon_type.ToString());
//				layOCS1003R02.SetBindVarValue("f_jubsu_no", this.jubsu_no.ToString());

				this.dw_OCS1003R02.Reset();
                ApplyMutilanguage(dw_OCS1003R02);
                dw_OCS1003R02.Refresh();
				if(layOCS1003R02.QueryLayout(false))
				{
					if(this.layOCS1003R02.RowCount > 0)
					{
						this.dw_OCS1003R02.Reset();
						this.dw_OCS1003R02.FillData(this.layOCS1003R02.LayoutTable);
						return;
					}
					else
					{
						this.GetMessage("Print_err");
						return;
					}
				}
				else
				{
					XMessageBox.Show(Service.ErrFullMsg.ToString());
					return;
				}
			}
			else if(this.rbx03.Checked == true)
			{
				/* 점적일정표 */
//				layOCS1003R03.SetBindVarValue("f_bunho", this.bunho.ToString());
//				layOCS1003R03.SetBindVarValue("f_naewon_date", this.naewon_date.ToString());
//				layOCS1003R03.SetBindVarValue("f_gwa", this.gwa.ToString());
//				layOCS1003R03.SetBindVarValue("f_doctor", this.doctor.ToString());
//				layOCS1003R03.SetBindVarValue("f_naewon_type", this.naewon_type.ToString());
//				layOCS1003R03.SetBindVarValue("f_jubsu_no", this.jubsu_no.ToString());
//				layOCS1003R03.SetBindVarValue("f_order_gubun", "1");

				this.dw_OCS1003R03.Reset();
				if(layOCS1003R03.QueryLayout(false))
				{
					if(this.layOCS1003R03.RowCount > 0)
					{
						this.dw_OCS1003R03.Reset();
                        ApplyMutilanguage(dw_OCS1003R03);
						this.dw_OCS1003R03.FillData(this.layOCS1003R03.LayoutTable);
                        dw_OCS1003R03.Refresh();
						return;
					}
					else
					{
						return;
					}
				}
				else
				{
					XMessageBox.Show(Service.ErrFullMsg.ToString());
					return;
				}
			}

			else if(this.rbx04.Checked == true)
			{
				/* 리허빌리일정표 */
//				layOCS1003R04.SetBindVarValue("f_bunho", this.bunho.ToString());
//				layOCS1003R04.SetBindVarValue("f_naewon_date", this.naewon_date.ToString());
//				layOCS1003R04.SetBindVarValue("f_gwa", this.gwa.ToString());
//				layOCS1003R04.SetBindVarValue("f_doctor", this.doctor.ToString());
//				layOCS1003R04.SetBindVarValue("f_naewon_type", this.naewon_type.ToString());
//				layOCS1003R04.SetBindVarValue("f_jubsu_no", this.jubsu_no.ToString());
//				layOCS1003R04.SetBindVarValue("f_order_gubun", "2");

				this.dw_OCS1003R04.Reset();
				if(layOCS1003R04.QueryLayout(false))
				{
					if(this.layOCS1003R04.RowCount > 0)
					{
						this.dw_OCS1003R04.Reset();
                        ApplyMutilanguage(dw_OCS1003R04);
						this.dw_OCS1003R04.FillData(this.layOCS1003R04.LayoutTable);
                        dw_OCS1003R04.Refresh();
						return;
					}
					else
					{
						return;
					}
				}
				else
				{
					XMessageBox.Show(Service.ErrFullMsg.ToString());
					return;
				}
			}

			else
			{
				/* 점적일정표 */
//				layOCS1003R05.SetBindVarValue("f_bunho", this.bunho.ToString());
//				layOCS1003R05.SetBindVarValue("f_naewon_date", this.naewon_date.ToString());
//				layOCS1003R05.SetBindVarValue("f_gwa", this.gwa.ToString());
//				layOCS1003R05.SetBindVarValue("f_doctor", this.doctor.ToString());
//				layOCS1003R05.SetBindVarValue("f_naewon_type", this.naewon_type.ToString());
//				layOCS1003R05.SetBindVarValue("f_jubsu_no", this.jubsu_no.ToString());
//				layOCS1003R05.SetBindVarValue("f_order_gubun", "3");

				this.dw_OCS1003R05.Reset();
				if(layOCS1003R05.QueryLayout(false))
				{
					if(this.layOCS1003R05.RowCount > 0)
					{
						this.dw_OCS1003R05.Reset();
                        ApplyMutilanguage(dw_OCS1003R05);
						this.dw_OCS1003R05.FillData(this.layOCS1003R05.LayoutTable);
                        dw_OCS1003R05.Refresh();
						return;
					}
					else
					{
						return;
					}
				}
				else
				{
					XMessageBox.Show(Service.ErrFullMsg.ToString());
					return;
				}
			}
		}
		#endregion

		#region 팝업으로 오픈이 됐을 때
		private void OCS1003R02_ScreenOpen(object sender, IHIS.Framework.XScreenOpenEventArgs e)
		{
			if(this.OpenParam != null)
			{
				this.bunho       = this.OpenParam["bunho"].ToString();
				this.naewon_date = this.OpenParam["naewon_date"].ToString();
				this.gwa         = this.OpenParam["gwa"].ToString();
				this.doctor      = this.OpenParam["doctor"].ToString();
				this.naewon_type = this.OpenParam["naewon_type"].ToString();
				this.jubsu_no    = this.OpenParam["jubsu_no"].ToString();
                this.pk_naewon   = this.OpenParam["pk_naewon"].ToString();

				if( OpenParam.Contains("auto_close") )
				{
					mAuto_close = bool.Parse(OpenParam["auto_close"].ToString());
					if(mAuto_close) this.ParentForm.WindowState = FormWindowState.Minimized;
				}
		
				/* 조회 */
				this.rbx02.Checked = true;
                if (mAuto_close)
                {
                    try
                    {
                        if (this.dw_OCS1003R02.RowCount > 0)
                        {
                            this.dw_OCS1003R02.Reset();
                            ApplyMutilanguage(dw_OCS1003R02);
                            this.dw_OCS1003R02.Print(true);
                            dw_OCS1003R02.Refresh();
                            this.rbx03.Checked = true;
                            try
                            {
                                if (this.dw_OCS1003R03.RowCount > 0)
                                {
                                    this.dw_OCS1003R03.Reset();
                                    ApplyMutilanguage(dw_OCS1003R03);
                                    this.dw_OCS1003R03.Print(true);
                                    this.dw_OCS1003R03.Refresh();
                                }

                            }
                            catch (Exception Xe)
                            {
                                //https://sofiamedix.atlassian.net/browse/MED-10610
                                //XMessageBox.Show(Xe.Message.ToString());
                            }

                            this.rbx04.Checked = true;
                            try
                            {
                                if (this.dw_OCS1003R04.RowCount > 0)
                                {
                                    this.dw_OCS1003R04.Reset();
                                    ApplyMutilanguage(dw_OCS1003R04);
                                    this.dw_OCS1003R04.Print(true);
                                    this.dw_OCS1003R04.Refresh();
                                    this.Close();
                                }

                            }
                            catch (Exception Xe)
                            {
                                //https://sofiamedix.atlassian.net/browse/MED-10610
                                //XMessageBox.Show(Xe.Message.ToString());
                            }
                            this.Close();
                        }

                    }
                    catch (Exception Xe)
                    {
                        //https://sofiamedix.atlassian.net/browse/MED-10610
                        //XMessageBox.Show(Xe.Message.ToString());
                    }

                    this.Close();
                }              
			}
		}
		#endregion

		#region 버튼리스트에서 버튼을 클릭을 했을 때
		private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			switch(e.Func)
			{
				case FunctionType.Query:
					if(!this.AcceptData())
					{
						e.IsBaseCall = false;
						e.IsSuccess = false;
						return;
					}

					e.IsBaseCall = false;

					/* 조회 */
					this.GetOCS1003R02();
					break;
				case FunctionType.Print:
					if(!this.AcceptData())
					{
						e.IsBaseCall = false;
						e.IsSuccess = false;
						return;
					}

					e.IsBaseCall = false;

					try
					{
						if(this.rbx02.Checked == true)
						{
							if(this.dw_OCS1003R02.RowCount > 0)
							{
                                //this.dw_OCS1003R02.Reset();
                                ApplyMutilanguage(dw_OCS1003R02);
								this.dw_OCS1003R02.Print(true);
                                dw_OCS1003R02.Refresh();
							}
						}
						else if(this.rbx03.Checked == true)
						{
							if(this.dw_OCS1003R03.RowCount > 0)
							{
                                this.dw_OCS1003R03.Reset();
                                ApplyMutilanguage(dw_OCS1003R03);
								this.dw_OCS1003R03.Print(true);
                                dw_OCS1003R03.Refresh();
							}
						}
						else if(this.rbx04.Checked == true)
						{
							if(this.dw_OCS1003R04.RowCount > 0)
							{
                                this.dw_OCS1003R04.Reset();
                                ApplyMutilanguage(dw_OCS1003R04);
								this.dw_OCS1003R04.Print(true);
                                dw_OCS1003R04.Refresh();
							}
						}
						else
						{
							if(this.dw_OCS1003R05.RowCount > 0)
							{
                                this.dw_OCS1003R05.Reset();
                                ApplyMutilanguage(dw_OCS1003R05);
								this.dw_OCS1003R05.Print(true);
                                dw_OCS1003R05.Refresh();
							}
						}
					}
					catch(Exception Xe)
					{
                        //https://sofiamedix.atlassian.net/browse/MED-10610
                        //XMessageBox.Show(Xe.Message.ToString());
						return;
					}
					break;
				default:
					break;
			}
		}
		#endregion

		#region 출력물을 선택을 했을 때
		private void rbx02_CheckedChanged(object sender, System.EventArgs e)
		{
			if(this.rbx02.Checked == true)
			{
				this.pnl02.Visible = true;
				this.pnl03.Visible = false;
				this.pnl04.Visible = false;
				this.pnl05.Visible = false;
				this.pnl02.Dock = System.Windows.Forms.DockStyle.Fill;
				this.pnl03.Dock = System.Windows.Forms.DockStyle.None;
				this.pnl04.Dock = System.Windows.Forms.DockStyle.None;
				this.pnl05.Dock = System.Windows.Forms.DockStyle.None;
				/* 조회 */
				this.GetOCS1003R02();
			}
			else if(this.rbx03.Checked == true)
			{
				this.pnl02.Visible = false;
				this.pnl03.Visible = true;
				this.pnl04.Visible = false;
				this.pnl05.Visible = false;
				this.pnl02.Dock = System.Windows.Forms.DockStyle.None;
				this.pnl03.Dock = System.Windows.Forms.DockStyle.Fill;
				this.pnl04.Dock = System.Windows.Forms.DockStyle.None;
				this.pnl05.Dock = System.Windows.Forms.DockStyle.None;
				/* 조회 */
				this.GetOCS1003R02();
			}
			else if(this.rbx04.Checked == true)
			{
				this.pnl02.Visible = false;
				this.pnl03.Visible = false;
				this.pnl04.Visible = true;
				this.pnl05.Visible = false;
				this.pnl02.Dock = System.Windows.Forms.DockStyle.None;
				this.pnl03.Dock = System.Windows.Forms.DockStyle.None;
				this.pnl04.Dock = System.Windows.Forms.DockStyle.Fill;
				this.pnl05.Dock = System.Windows.Forms.DockStyle.None;
				/* 조회 */
				this.GetOCS1003R02();
			}
			else
			{
				this.pnl02.Visible = false;
				this.pnl03.Visible = false;
				this.pnl04.Visible = false;
				this.pnl05.Visible = true;
				this.pnl02.Dock = System.Windows.Forms.DockStyle.None;
				this.pnl03.Dock = System.Windows.Forms.DockStyle.None;
				this.pnl04.Dock = System.Windows.Forms.DockStyle.None;
				this.pnl05.Dock = System.Windows.Forms.DockStyle.Fill;
				/* 조회 */
				this.GetOCS1003R02();
			}
		}
		#endregion

		#region [Return QuerySQL]
		private void layOCS1003R02_QueryStarting(object sender, System.ComponentModel.CancelEventArgs e)
        {
            #region delete by Cloud version
            //            string strCmd = "";
//            string strCmd_hosp = "";
//            BindVarCollection bindVars = new BindVarCollection();
//            BindVarCollection bindVars_hosp = new BindVarCollection();

//            string o_err					= "";
//            string o_gwa                    = "";
//            string o_gwa_name               = "";
//            string o_bunho                  = "";
//            string o_suname                 = "";
//            string o_balheang_date          = "";
//            string o_birth                  = "";
//            string o_naewon_date            = "";
//            string o_bunho_1                = "";
//            string o_dangil_gumsa_result_yn = "";

//            //hosp_info
//            string o_jaedan_name = "";
//            string o_hosp_name = "";
//            string o_tel = "";
//            string o_homepage = "";

//            Hashtable inputList = new Hashtable();
//            Hashtable outputList = new Hashtable();

//            /* 환자의 기본정보를 조회한다. */
//            strCmd = @"SELECT :f_gwa                                                                          GWA
//                             ,FN_BAS_LOAD_GWA_NAME(:f_gwa, TRUNC(SYSDATE))                                    GWA_NAME
//                             ,A.BUNHO                                                                         BUNHO
//                             ,A.SUNAME                                                                        SUNAME
//                             ,FN_BAS_TO_JAPAN_DATE_CONVERT('1', TO_DATE(SYSDATE))                             BALHEANG_DATE
//                             ,FN_BAS_TO_JAPAN_DATE_CONVERT('1', TRUNC(A.BIRTH))                               BIRTH
//                             ,FN_BAS_TO_JAPAN_DATE_CONVERT('1', TRUNC(TO_DATE(:f_naewon_date, 'YYYY/MM/DD'))) NAEWON_DATE
//                             ,'*'||A.BUNHO||'*'                                                               BUNHO_1
//                             ,FN_NUR_DANGIL_GUMSA_RESULT_YN(:f_naewon_date,:f_bunho,:f_gwa,:f_doctor,:f_naewon_type,:f_jubsu_no) DANGIL_GUMSA_RESULT_YN
//                         FROM OUT0101 A
//                        WHERE A.BUNHO     = :f_bunho
//                          AND A.HOSP_CODE = :f_hosp_code";

//            bindVars.Add("f_gwa",gwa.ToString());
//            bindVars.Add("f_bunho", this.bunho.ToString());
//            bindVars.Add("f_naewon_date", this.naewon_date.ToString());
//            bindVars.Add("f_doctor", this.doctor.ToString());
//            bindVars.Add("f_naewon_type", this.naewon_type.ToString());
//            bindVars.Add("f_jubsu_no", this.jubsu_no.ToString());
//            bindVars.Add("f_hosp_code", mHospCode);

//            strCmd_hosp = @"SELECT A.JAEDAN_NAME
//                                  ,A.SIMPLE_YOYANG_NAME
//                                  ,A.TEL
//                                  ,A.HOMEPAGE
//                              FROM BAS0001 A 
//                             WHERE A.HOSP_CODE = :f_hosp_code
//                               AND SYSDATE BETWEEN A.START_DATE 
//                                               AND A.END_DATE ";
//            bindVars_hosp.Add("f_hosp_code", mHospCode);

//            try
//            {
//                DataTable dt = Service.ExecuteDataTable(strCmd, bindVars);
//                DataTable dt_hosp = Service.ExecuteDataTable(strCmd_hosp, bindVars_hosp);
//                if(dt.Rows.Count > 0)
//                {
//                    o_gwa                    = dt.Rows[0]["GWA"].ToString();
//                    o_gwa_name               = dt.Rows[0]["GWA_NAME"].ToString();
//                    o_bunho                  = dt.Rows[0]["BUNHO"].ToString();
//                    o_suname                 = dt.Rows[0]["SUNAME"].ToString();
//                    o_balheang_date          = dt.Rows[0]["BALHEANG_DATE"].ToString();
//                    o_birth                  = dt.Rows[0]["BIRTH"].ToString();
//                    o_naewon_date            = dt.Rows[0]["NAEWON_DATE"].ToString();
//                    o_bunho_1                = dt.Rows[0]["BUNHO_1"].ToString();
//                    o_dangil_gumsa_result_yn = dt.Rows[0]["DANGIL_GUMSA_RESULT_YN"].ToString();
//                }
//                else
//                {
//                    throw new Exception("Query Error Patient");
//                }

//                if (dt_hosp.Rows.Count > 0)
//                {
//                    o_jaedan_name   = dt_hosp.Rows[0]["JAEDAN_NAME"].ToString();
//                    o_hosp_name     = dt_hosp.Rows[0]["SIMPLE_YOYANG_NAME"].ToString();
//                    o_tel           = dt_hosp.Rows[0]["TEL"].ToString();
//                    o_homepage      = dt_hosp.Rows[0]["HOMEPAGE"].ToString();
//                }
//                else
//                {
//                    throw new Exception("Query Error Hosp Info");
//                }

//                /* 환자안내서 프로시져 호출하는 부분 */
//                inputList.Add("I_BUNHO", this.bunho);
//                inputList.Add("I_FKOUT1001", this.pk_naewon);
//                inputList.Add("I_USER_ID", UserInfo.UserID);
//                outputList.Add("IO_FLAG", "");

//                if(!Service.ExecuteProcedure("PR_NUR_MAKE_PATIENTINFO", inputList, outputList))
//                {
//                    XMessageBox.Show(Service.ErrFullMsg);
//                    return;
//                }

//                o_err = outputList["IO_FLAG"].ToString();
			
//            }
//            catch(Exception err)
//            {
//                XMessageBox.Show(err.ToString() + Service.ErrFullMsg);
//                return;
//            }

//            if(o_err != "0")
//            {
//                XMessageBox.Show(o_err);
//                e.Cancel = false;
//                return;
//            }
			
//             /* 환자안내서 내용을 조회한다 */
//            layOCS1003R02.QuerySQL = @"SELECT :f_gwa_out                    GWA,
//											  :f_gwa_name_out               GWA_NAME,
//											  :f_bunho_out                  BUNHO,
//											  :f_suname_out                 SUNAME,
//											  :f_balheang_date_out          BALHEANG_DATE,
//											  :f_birth_out                  BIRTH,
//											  :f_naewon_date_out            NAEWON_DATE, 
//											  A.COMMENTS,
//											  :f_bunho_1_out                BUNHO_1,
//											  :f_dangil_gumsa_result_yn_out DANGIL_GUMSA_RESULT_YN,
//                                              A.FKOUT1001                   FKOUT1001,
//                                              A.ACTING_CHECK_YN             ACTING_CHECK_YN,
//                                              :f_jaedan_name                JAEDAN_NAME,
//                                              :f_hosp_name                  HOSP_NAME,
//                                              :f_tel                        TEL,
//                                              :f_homepage                   HOMEPAGE
//										 FROM NUR1003 A
//									    WHERE A.HOSP_CODE = '" + EnvironInfo.HospCode + @"'
//                                          AND A.FKOUT1001 = :f_fkout1001
//                                        ORDER BY DATA_SORT";

//            layOCS1003R02.SetBindVarValue("f_bunho", bunho.ToString());
//            layOCS1003R02.SetBindVarValue("f_naewon_date", naewon_date.ToString());
//            layOCS1003R02.SetBindVarValue("f_gwa", gwa.ToString());
//            layOCS1003R02.SetBindVarValue("f_doctor", doctor.ToString());
//            layOCS1003R02.SetBindVarValue("f_naewon_type", naewon_type.ToString());
//            layOCS1003R02.SetBindVarValue("f_jubsu_no", jubsu_no.ToString());

//            layOCS1003R02.SetBindVarValue("f_gwa_out", o_gwa);
//            layOCS1003R02.SetBindVarValue("f_gwa_name_out", o_gwa_name);
//            layOCS1003R02.SetBindVarValue("f_bunho_out", o_bunho);
//            layOCS1003R02.SetBindVarValue("f_suname_out", o_suname);
//            layOCS1003R02.SetBindVarValue("f_balheang_date_out", o_balheang_date);
//            layOCS1003R02.SetBindVarValue("f_birth_out", o_birth);
//            layOCS1003R02.SetBindVarValue("f_naewon_date_out", o_naewon_date);
//            layOCS1003R02.SetBindVarValue("f_bunho_1_out", o_bunho_1);
//            layOCS1003R02.SetBindVarValue("f_dangil_gumsa_result_yn_out", o_dangil_gumsa_result_yn);

//            layOCS1003R02.SetBindVarValue("f_hosp_code", mHospCode);
//            layOCS1003R02.SetBindVarValue("f_fkout1001", this.pk_naewon);

//            layOCS1003R02.SetBindVarValue("f_jaedan_name", o_jaedan_name);
//            layOCS1003R02.SetBindVarValue("f_hosp_name", o_hosp_name);
//            layOCS1003R02.SetBindVarValue("f_tel", o_tel);
            //            layOCS1003R02.SetBindVarValue("f_homepage", o_homepage);
            #endregion

            layOCS1003R02.SetBindVarValue("f_gwa", gwa.ToString());
            layOCS1003R02.SetBindVarValue("f_bunho", this.bunho.ToString());
            layOCS1003R02.SetBindVarValue("f_naewon_date", this.naewon_date.ToString());
            layOCS1003R02.SetBindVarValue("f_doctor", this.doctor.ToString());
            layOCS1003R02.SetBindVarValue("f_naewon_type", this.naewon_type.ToString());
            layOCS1003R02.SetBindVarValue("f_jubsu_no", this.jubsu_no.ToString());
            layOCS1003R02.SetBindVarValue("f_fkout1001", this.pk_naewon.ToString());
            layOCS1003R02.SetBindVarValue("f_user_id", UserInfo.UserID.ToString());

		}

		private void layOCS1003R03_QueryStarting(object sender, System.ComponentModel.CancelEventArgs e)
        {
            #region delete by Cloud version
            //            string strCmd = "";
//            BindVarCollection bindVars = new BindVarCollection();

//            string o_gwa_name               = "";
//            string o_bunho                  = "";
//            string o_suname                 = "";
//            string o_balheang_date          = "";
//            string o_birth                  = "";
//            string o_naewon_date            = "";
//            string o_bunho_1                = "";

//            /* 환자의 기본정보를 조회한다. */
//            strCmd = @"SELECT FN_BAS_LOAD_GWA_NAME(:f_gwa, TRUNC(SYSDATE))                                     GWA_NAME
//                             ,A.BUNHO                                                                         BUNHO
//                             ,A.SUNAME                                                                        SUNAME
//                             ,FN_BAS_TO_JAPAN_DATE_CONVERT('1', TO_DATE(SYSDATE))                             BALHEANG_DATE
//                             ,FN_BAS_TO_JAPAN_DATE_CONVERT('1', TRUNC(A.BIRTH))                               BIRTH
//                             ,FN_BAS_TO_JAPAN_DATE_CONVERT('1', TRUNC(TO_DATE(:f_naewon_date, 'YYYY/MM/DD'))) NAEWON_DATE
//                             ,'*'||A.BUNHO||'*'                                                               BUNHO_1
//                         FROM OUT0101 A
//                        WHERE A.BUNHO     = :f_bunho
//                          AND A.HOSP_CODE = :f_hosp_code";

//            bindVars.Add("f_gwa",gwa.ToString());
//            bindVars.Add("f_bunho", this.bunho.ToString());
//            bindVars.Add("f_naewon_date", this.naewon_date.ToString());
//            bindVars.Add("f_hosp_code",   mHospCode);

//            try
//            {
//                DataTable dt = Service.ExecuteDataTable(strCmd, bindVars);

//                if(dt.Rows.Count > 0)
//                {
//                    o_gwa_name               = dt.Rows[0]["GWA_NAME"].ToString();
//                    o_bunho                  = dt.Rows[0]["BUNHO"].ToString();
//                    o_suname                 = dt.Rows[0]["SUNAME"].ToString();
//                    o_balheang_date          = dt.Rows[0]["BALHEANG_DATE"].ToString();
//                    o_birth                  = dt.Rows[0]["BIRTH"].ToString();
//                    o_naewon_date            = dt.Rows[0]["NAEWON_DATE"].ToString();
//                    o_bunho_1                = dt.Rows[0]["BUNHO_1"].ToString();
//                }
//                else
//                {
//                    throw new Exception("Query Error");
//                }
//            }
//            catch(Exception err)
//            {
//                XMessageBox.Show(err.ToString() + Service.ErrFullMsg);
//                return;
//            }

//             /* 예약증에 출력을 할 데이터를 조회한다. */
//            layOCS1003R03.QuerySQL = @"
//                                    SELECT DISTINCT
//                                          :f_gwa                                        GWA,
//                                          :f_gwa_name_out                               GWA_NAME,
//                                          :f_bunho_out                                  BUNHO,
//                                          :f_suname_out                                 SUNAME,
//                                          :f_balheang_date_out                          BALHEANG_DATE,
//                                          :f_birth_out                                  BIRTH,
//                                          :f_naewon_date_out                            NAEWON_DATE,
//                                          FN_BAS_LOAD_GWA_POSITION(A.MOVE_PART,SYSDATE) MOVE_NAME,
//                                          :f_bunho_1_out                                BUNHO_1,
//                                          A.HOPE_DATE                                   HOPE_DATE
//                                      FROM BAS0260 C,
//                                           VW_OCS_OCS1003 A
//                                     WHERE A.HOSP_CODE    = :f_hosp_code
//                                       AND A.ORDER_DATE   = TO_DATE(:f_naewon_date, 'YYYY/MM/DD')
//                                       AND A.BUNHO        = :f_bunho
//                                       AND A.GWA          = :f_gwa
//                                       AND A.NAEWON_TYPE  = :f_naewon_type
//                                       AND A.DOCTOR       = :f_doctor
//                                       AND A.MOVE_PART    <> 'HOM'
//                                       AND A.NALSU        > 0
//                                       AND C.HOSP_CODE    = A.HOSP_CODE
//                                       AND C.GWA          = A.MOVE_PART
//                                       AND NVL(A.WONYOI_ORDER_YN, 'N') = 'N'
//                                       AND (( :f_order_gubun = '1' AND A.MOVE_PART = 'IR')
//                                        OR  ( :f_order_gubun = '2' AND A.MOVE_PART = 'PT')
//                                        OR  ( :f_order_gubun = '3' AND A.MOVE_PART = 'TRT'))
//                                       AND NVL(A.DC_YN,'N') = 'N'
//                                       AND A.JUNDAL_PART  <> 'HOM'
//                                       AND A.HOPE_DATE > TO_DATE(:f_naewon_date, 'YYYY/MM/DD')
//                                     ORDER BY A.HOPE_DATE";
						
//            layOCS1003R03.SetBindVarValue("f_bunho", this.bunho.ToString());
//            layOCS1003R03.SetBindVarValue("f_naewon_date", this.naewon_date.ToString());
//            layOCS1003R03.SetBindVarValue("f_gwa", this.gwa.ToString());
//            layOCS1003R03.SetBindVarValue("f_doctor", this.doctor.ToString());
//            layOCS1003R03.SetBindVarValue("f_naewon_type", this.naewon_type.ToString());
//            layOCS1003R03.SetBindVarValue("f_jubsu_no", this.jubsu_no.ToString());
//            layOCS1003R03.SetBindVarValue("f_order_gubun", "1");

//            layOCS1003R03.SetBindVarValue("f_gwa_name_out", o_gwa_name);
//            layOCS1003R03.SetBindVarValue("f_bunho_out", o_bunho);
//            layOCS1003R03.SetBindVarValue("f_suname_out", o_suname);
//            layOCS1003R03.SetBindVarValue("f_balheang_date_out", o_balheang_date);
//            layOCS1003R03.SetBindVarValue("f_birth_out", o_birth);
//            layOCS1003R03.SetBindVarValue("f_naewon_date_out", o_naewon_date);
//            layOCS1003R03.SetBindVarValue("f_bunho_1_out", o_bunho_1);

            //            layOCS1003R03.SetBindVarValue("f_hosp_code", mHospCode);
            #endregion

            layOCS1003R03.SetBindVarValue("f_gwa", gwa.ToString());
            layOCS1003R03.SetBindVarValue("f_bunho", this.bunho.ToString());
            layOCS1003R03.SetBindVarValue("f_naewon_date", this.naewon_date.ToString());
            layOCS1003R03.SetBindVarValue("f_doctor", this.doctor.ToString());
            layOCS1003R03.SetBindVarValue("f_naewon_type", this.naewon_type.ToString());
            layOCS1003R03.SetBindVarValue("f_jubsu_no", this.jubsu_no.ToString());
        }

		private void layOCS1003R04_QueryStarting(object sender, System.ComponentModel.CancelEventArgs e)
        {
            #region delete by Cloud version
            //            string strCmd = "";
//            BindVarCollection bindVars = new BindVarCollection();

//            string o_gwa_name               = "";
//            string o_bunho                  = "";
//            string o_suname                 = "";
//            string o_balheang_date          = "";
//            string o_birth                  = "";
//            string o_naewon_date            = "";
//            string o_bunho_1                = "";

//            /* 환자의 기본정보를 조회한다. */
//            strCmd = @"SELECT 
//                            FN_BAS_LOAD_GWA_NAME(:f_gwa, TRUNC(SYSDATE))                                     GWA_NAME
//                            ,A.BUNHO                                                                         BUNHO
//                            ,A.SUNAME                                                                        SUNAME
//                            ,FN_BAS_TO_JAPAN_DATE_CONVERT('1', TO_DATE(SYSDATE))                             BALHEANG_DATE
//                            ,FN_BAS_TO_JAPAN_DATE_CONVERT('1', TRUNC(A.BIRTH))                               BIRTH
//                            ,FN_BAS_TO_JAPAN_DATE_CONVERT('1', TRUNC(TO_DATE(:f_naewon_date, 'YYYY/MM/DD'))) NAEWON_DATE
//                            ,'*'||A.BUNHO||'*'                                                               BUNHO_1
//                         FROM OUT0101 A
//                        WHERE A.BUNHO     = :f_bunho
//                          AND A.HOSP_CODE = :f_hosp_code";

//            bindVars.Add("f_gwa",gwa.ToString());
//            bindVars.Add("f_bunho", this.bunho.ToString());
//            bindVars.Add("f_naewon_date", this.naewon_date.ToString());
//            bindVars.Add("f_hosp_code", mHospCode);

//            try
//            {
//                DataTable dt = Service.ExecuteDataTable(strCmd, bindVars);

//                if(dt.Rows.Count > 0)
//                {
//                    o_gwa_name               = dt.Rows[0]["GWA_NAME"].ToString();
//                    o_bunho                  = dt.Rows[0]["BUNHO"].ToString();
//                    o_suname                 = dt.Rows[0]["SUNAME"].ToString();
//                    o_balheang_date          = dt.Rows[0]["BALHEANG_DATE"].ToString();
//                    o_birth                  = dt.Rows[0]["BIRTH"].ToString();
//                    o_naewon_date            = dt.Rows[0]["NAEWON_DATE"].ToString();
//                    o_bunho_1                = dt.Rows[0]["BUNHO_1"].ToString();
//                }
//                else
//                {
//                    throw new Exception("Query Error");
//                }
//            }
//            catch(Exception err)
//            {
//                XMessageBox.Show(err.ToString() + Service.ErrFullMsg);
//                return;
//            }

//            /* 예약증에 출력을 할 데이터를 조회한다. */
//            layOCS1003R04.QuerySQL = @"
//                                    SELECT DISTINCT
//                                          :f_gwa                                        GWA,
//                                          :f_gwa_name_out                               GWA_NAME,
//                                          :f_bunho_out                                  BUNHO,
//                                          :f_suname_out                                 SUNAME,
//                                          :f_balheang_date_out                          BALHEANG_DATE,
//                                          :f_birth_out                                  BIRTH,
//                                          :f_naewon_date_out                            NAEWON_DATE,
//                                          FN_BAS_LOAD_GWA_POSITION(A.MOVE_PART,SYSDATE) MOVE_NAME,
//                                          :f_bunho_1_out                                BUNHO_1,
//                                          A.HOPE_DATE                                   HOPE_DATE
//                                      FROM BAS0260 C,
//                                           VW_OCS_OCS1003 A
//                                     WHERE A.HOSP_CODE    = :f_hosp_code
//                                       AND A.ORDER_DATE   = TO_DATE(:f_naewon_date, 'YYYY/MM/DD')
//                                       AND A.BUNHO        = :f_bunho
//                                       AND A.GWA          = :f_gwa
//                                       AND A.NAEWON_TYPE  = :f_naewon_type
//                                       AND A.DOCTOR       = :f_doctor
//                                       AND A.MOVE_PART    <> 'HOM'
//                                       AND A.NALSU        > 0
//                                       AND C.HOSP_CODE    = A.HOSP_CODE
//                                       AND C.GWA          = A.MOVE_PART
//                                       AND NVL(A.WONYOI_ORDER_YN, 'N') = 'N'
//                                       AND (( :f_order_gubun = '1' AND A.MOVE_PART = 'IR')
//                                        OR  ( :f_order_gubun = '2' AND A.MOVE_PART = 'PT')
//                                        OR  ( :f_order_gubun = '3' AND A.MOVE_PART = 'TRT'))
//                                       AND NVL(A.DC_YN,'N') = 'N'
//                                       AND A.JUNDAL_PART  <> 'HOM'
//                                       AND A.HOPE_DATE > TO_DATE(:f_naewon_date, 'YYYY/MM/DD')
//                                     ORDER BY A.HOPE_DATE";
						
//            layOCS1003R04.SetBindVarValue("f_bunho", this.bunho.ToString());
//            layOCS1003R04.SetBindVarValue("f_naewon_date", this.naewon_date.ToString());
//            layOCS1003R04.SetBindVarValue("f_gwa", this.gwa.ToString());
//            layOCS1003R04.SetBindVarValue("f_doctor", this.doctor.ToString());
//            layOCS1003R04.SetBindVarValue("f_naewon_type", this.naewon_type.ToString());
//            layOCS1003R04.SetBindVarValue("f_jubsu_no", this.jubsu_no.ToString());
//            layOCS1003R04.SetBindVarValue("f_order_gubun", "2");

//            layOCS1003R04.SetBindVarValue("f_gwa_name_out", o_gwa_name);
//            layOCS1003R04.SetBindVarValue("f_bunho_out", o_bunho);
//            layOCS1003R04.SetBindVarValue("f_suname_out", o_suname);
//            layOCS1003R04.SetBindVarValue("f_balheang_date_out", o_balheang_date);
//            layOCS1003R04.SetBindVarValue("f_birth_out", o_birth);
//            layOCS1003R04.SetBindVarValue("f_naewon_date_out", o_naewon_date);
//            layOCS1003R04.SetBindVarValue("f_bunho_1_out", o_bunho_1);

            //            layOCS1003R04.SetBindVarValue("f_hosp_code", mHospCode);
            #endregion

            layOCS1003R04.SetBindVarValue("f_gwa", gwa.ToString());
            layOCS1003R04.SetBindVarValue("f_bunho", this.bunho.ToString());
            layOCS1003R04.SetBindVarValue("f_naewon_date", this.naewon_date.ToString());
            layOCS1003R04.SetBindVarValue("f_doctor", this.doctor.ToString());
            layOCS1003R04.SetBindVarValue("f_naewon_type", this.naewon_type.ToString());
            layOCS1003R04.SetBindVarValue("f_jubsu_no", this.jubsu_no.ToString());
        }

		private void layOCS1003R05_QueryStarting(object sender, System.ComponentModel.CancelEventArgs e)
        {
            #region delete by Cloud version
            //            string strCmd = "";
//            BindVarCollection bindVars = new BindVarCollection();

//            string o_gwa_name               = "";
//            string o_bunho                  = "";
//            string o_suname                 = "";
//            string o_balheang_date          = "";
//            string o_birth                  = "";
//            string o_naewon_date            = "";
//            string o_bunho_1                = "";

//            /* 환자의 기본정보를 조회한다. */
//            strCmd = @"SELECT 
//							FN_BAS_LOAD_GWA_NAME(:f_gwa, TRUNC(SYSDATE))                                     GWA_NAME
//							,A.BUNHO                                                                         BUNHO
//							,A.SUNAME                                                                        SUNAME
//							,FN_BAS_TO_JAPAN_DATE_CONVERT('1', TO_DATE(SYSDATE))                             BALHEANG_DATE
//							,FN_BAS_TO_JAPAN_DATE_CONVERT('1', TRUNC(A.BIRTH))                               BIRTH
//							,FN_BAS_TO_JAPAN_DATE_CONVERT('1', TRUNC(TO_DATE(:f_naewon_date, 'YYYY/MM/DD'))) NAEWON_DATE
//							,'*'||A.BUNHO||'*'                                                               BUNHO_1
//                         FROM OUT0101 A
//                        WHERE A.BUNHO = :f_bunho
//                          AND A.HOSP_CODE = :f_hosp_code";

//            bindVars.Add("f_gwa",gwa.ToString());
//            bindVars.Add("f_bunho", this.bunho.ToString());
//            bindVars.Add("f_naewon_date", this.naewon_date.ToString());
//            bindVars.Add("f_hosp_code", mHospCode);

//            try
//            {
//                DataTable dt = Service.ExecuteDataTable(strCmd, bindVars);

//                if(dt.Rows.Count > 0)
//                {
//                    o_gwa_name               = dt.Rows[0]["GWA_NAME"].ToString();
//                    o_bunho                  = dt.Rows[0]["BUNHO"].ToString();
//                    o_suname                 = dt.Rows[0]["SUNAME"].ToString();
//                    o_balheang_date          = dt.Rows[0]["BALHEANG_DATE"].ToString();
//                    o_birth                  = dt.Rows[0]["BIRTH"].ToString();
//                    o_naewon_date            = dt.Rows[0]["NAEWON_DATE"].ToString();
//                    o_bunho_1                = dt.Rows[0]["BUNHO_1"].ToString();
//                }
//                else
//                {
//                    throw new Exception("Query Error");
//                }
//            }
//            catch(Exception err)
//            {
//                XMessageBox.Show(err.ToString() + Service.ErrFullMsg);
//                return;
//            }

//            /* 예약증에 출력을 할 데이터를 조회한다. */
//            layOCS1003R05.QuerySQL = @"
//                                    SELECT DISTINCT
//                                          :f_gwa                                        GWA,
//                                          :f_gwa_name_out                               GWA_NAME,
//                                          :f_bunho_out                                  BUNHO,
//                                          :f_suname_out                                 SUNAME,
//                                          :f_balheang_date_out                          BALHEANG_DATE,
//                                          :f_birth_out                                  BIRTH,
//                                          :f_naewon_date_out                            NAEWON_DATE,
//                                          FN_BAS_LOAD_GWA_POSITION(A.MOVE_PART,SYSDATE) MOVE_NAME,
//                                          :f_bunho_1_out                                BUNHO_1,
//                                          A.HOPE_DATE                                   HOPE_DATE
//                                      FROM BAS0260 C,
//                                           VW_OCS_OCS1003 A
//                                     WHERE A.HOSP_CODE      = :f_hosp_code
//                                       AND A.ORDER_DATE   = TO_DATE(:f_naewon_date, 'YYYY/MM/DD')
//                                       AND A.BUNHO        = :f_bunho
//                                       AND A.GWA          = :f_gwa
//                                       AND A.NAEWON_TYPE  = :f_naewon_type
//                                       AND A.DOCTOR       = :f_doctor
//                                       AND A.MOVE_PART    <> 'HOM'
//                                       AND A.NALSU        > 0
//                                       AND C.HOSP_CODE    = A.HOSP_CODE
//                                       AND C.GWA          = A.MOVE_PART
//                                       AND NVL(A.WONYOI_ORDER_YN, 'N') = 'N'
//                                       AND (( :f_order_gubun = '1' AND A.MOVE_PART = 'IR')
//                                        OR  ( :f_order_gubun = '2' AND A.MOVE_PART = 'PT')
//                                        OR  ( :f_order_gubun = '3' AND A.MOVE_PART = 'TRT'))
//                                       AND NVL(A.DC_YN,'N') = 'N'
//                                       AND A.JUNDAL_PART  <> 'HOM'
//                                       AND A.HOPE_DATE > TO_DATE(:f_naewon_date, 'YYYY/MM/DD')
//                                     ORDER BY A.HOPE_DATE";
						
//            layOCS1003R05.SetBindVarValue("f_bunho", this.bunho.ToString());
//            layOCS1003R05.SetBindVarValue("f_naewon_date", this.naewon_date.ToString());
//            layOCS1003R05.SetBindVarValue("f_gwa", this.gwa.ToString());
//            layOCS1003R05.SetBindVarValue("f_doctor", this.doctor.ToString());
//            layOCS1003R05.SetBindVarValue("f_naewon_type", this.naewon_type.ToString());
//            layOCS1003R05.SetBindVarValue("f_jubsu_no", this.jubsu_no.ToString());
//            layOCS1003R05.SetBindVarValue("f_order_gubun", "3");

//            layOCS1003R05.SetBindVarValue("f_gwa_name_out", o_gwa_name);
//            layOCS1003R05.SetBindVarValue("f_bunho_out", o_bunho);
//            layOCS1003R05.SetBindVarValue("f_suname_out", o_suname);
//            layOCS1003R05.SetBindVarValue("f_balheang_date_out", o_balheang_date);
//            layOCS1003R05.SetBindVarValue("f_birth_out", o_birth);
//            layOCS1003R05.SetBindVarValue("f_naewon_date_out", o_naewon_date);
//            layOCS1003R05.SetBindVarValue("f_bunho_1_out", o_bunho_1);

            //            layOCS1003R05.SetBindVarValue("f_hosp_code", mHospCode);
            #endregion
            layOCS1003R05.SetBindVarValue("f_gwa", gwa.ToString());
            layOCS1003R05.SetBindVarValue("f_bunho", this.bunho.ToString());
            layOCS1003R05.SetBindVarValue("f_naewon_date", this.naewon_date.ToString());
            layOCS1003R05.SetBindVarValue("f_doctor", this.doctor.ToString());
            layOCS1003R05.SetBindVarValue("f_naewon_type", this.naewon_type.ToString());
            layOCS1003R05.SetBindVarValue("f_jubsu_no", this.jubsu_no.ToString());
        }
		#endregion

        #region Cloud-Service
        private List<object[]> LoadDataLayOCS1003R02(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();

            OCS1003R02LayR02QueryStartingArgs args = new OCS1003R02LayR02QueryStartingArgs();
            args.Gwa = bc["f_gwa"] != null ? bc["f_gwa"].VarValue : "";
            args.Bunho = bc["f_bunho"] != null ? bc["f_bunho"].VarValue : "";
            args.NaewonDate = bc["f_naewon_date"] != null ? bc["f_naewon_date"].VarValue : "";
            args.Doctor = bc["f_doctor"] != null ? bc["f_doctor"].VarValue : "";
            args.NaewonType = bc["f_naewon_type"] != null ? bc["f_naewon_type"].VarValue : "";
            args.JubsuNo = bc["f_jubsu_no"] != null ? bc["f_jubsu_no"].VarValue : "";
            args.Fkout1001 = bc["f_fkout1001"] != null ? bc["f_fkout1001"].VarValue : "";
            args.UserId = bc["f_user_id"] != null ? bc["f_user_id"].VarValue : "";
            OCS1003R02LayR02QueryStartingResult result = CloudService.Instance.Submit<OCS1003R02LayR02QueryStartingResult, OCS1003R02LayR02QueryStartingArgs>(args);

            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (OCS1003R02LayR02ListItemInfo item in result.Layr02List)
                {
                    object[] objects = 
						{ 
                        item.Gwa, 
                        item.GwaName, 
                        item.Bunho, 
                        item.Suname, 
                        item.BalheangDate, 
                        item.Birth, 
                        item.NaewonDate, 
                        item.Comment, 
                        item.Bunho1, 
                        item.DangilGumsaResultYn, 
                        item.Fkout1001, 
                        item.ActingCheckYn, 
                        item.JaedanName, 
                        item.HospName, 
                        item.Tel, 
                        item.Homepage
						};
                    res.Add(objects);
                }
            }
            return res;
        }
        private List<object[]> LoadDataLayOCS1003R03(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            OCS1003R02LayR03QueryStartingArgs args = new OCS1003R02LayR03QueryStartingArgs();
            args.Gwa = bc["f_gwa"] != null ? bc["f_gwa"].VarValue : "";
            args.Bunho = bc["f_bunho"] != null ? bc["f_bunho"].VarValue : "";
            args.NaewonDate = bc["f_naewon_date"] != null ? bc["f_naewon_date"].VarValue : "";
            args.Doctor = bc["f_doctor"] != null ? bc["f_doctor"].VarValue : "";
            args.NaewonType = bc["f_naewon_type"] != null ? bc["f_naewon_type"].VarValue : "";
            args.JubsuNo = bc["f_jubsu_no"] != null ? bc["f_jubsu_no"].VarValue : "";
            OCS1003R02LayR03QueryStartingResult result = CloudService.Instance.Submit<OCS1003R02LayR03QueryStartingResult, OCS1003R02LayR03QueryStartingArgs>(args);
            if (result != null)
            {
                foreach (OCS1003R02LayR03ListItemInfo item in result.Layr03List)
                {
                    object[] objects = 
				    { 
					    item.Gwa, 
					    item.GwaName, 
					    item.Bunho, 
					    item.Suname, 
					    item.BalheangDate, 
					    item.Birth, 
					    item.NaewonDate, 
					    item.MoveName, 
					    item.Bunho1, 
					    item.HopeDate
				    };
                    res.Add(objects);
                }
            }
            return res;
        }
        #endregion

	    private void ApplyMutilanguage(XDataWindow dw)
        {
            try
            {
                //dw_comment
                if (dw == dw_OCS1003R02)
                {
                    dw.Modify(string.Format("t_1.text =  '{0}'", Resources.DW_TXT_1));
                }
                else if (dw == dw_OCS1003R03)
                {
                    dw.Modify(string.Format("t_1.text =  '{0}'", Resources.DW_TXT_8));
                }
                else if (dw == dw_OCS1003R04)
                {
                    dw.Modify(string.Format("t_1.text =  '{0}'", Resources.DW_TXT_9));
                }
                else if (dw == dw_OCS1003R05)
                {
                    dw.Modify(string.Format("t_1.text =  '{0}'", Resources.DW_TXT_10));
                }
                dw.Modify(string.Format("t_2.text =  '{0}'", Resources.DW_TXT_2));
                dw.Modify(string.Format("t_3.text =  '{0}'", Resources.DW_TXT_3));
                dw.Modify(string.Format("t_4.text =  '{0}'", Resources.DW_TXT_4));
                dw.Modify(string.Format("t_5.text =  '{0}'", Resources.DW_TXT_5));
                dw.Modify(string.Format("t_6.text =  '{0}'", Resources.DW_TXT_6));
                dw.Modify(string.Format("t_7.text =  '{0}'", Resources.DW_TXT_7));
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
    }
}

