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
using IHIS.CloudConnector.Contracts.Arguments.Nuro;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using IHIS.CloudConnector.Contracts.Results.Nuro;
using IHIS.NURO.Properties;
#endregion

namespace IHIS.NURO
{
	/// <summary>
	/// NUR1001R00에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class NUR1001R00 : IHIS.Framework.XScreen
	{
		#region 자동생성
		private IHIS.Framework.XPanel pnlTop;
		private IHIS.Framework.XPanel pnlBottom;
		private IHIS.Framework.XDataWindow dwNUR1001R00;
		private IHIS.Framework.XButtonList btnList;
		private IHIS.Framework.XLabel lblMonth;
		private IHIS.Framework.XMonthBox mbxMonth;
		private IHIS.Framework.XLabel lblGwa;
		private IHIS.Framework.XBuseoCombo cboGwa;
		private IHIS.Framework.MultiLayout layQuery;
        private MultiLayout layTemp;
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
        private MultiLayoutItem multiLayoutItem11;
        private MultiLayoutItem multiLayoutItem12;
        private MultiLayoutItem multiLayoutItem13;
        private MultiLayoutItem multiLayoutItem14;
        private MultiLayoutItem multiLayoutItem15;
        private MultiLayoutItem multiLayoutItem16;
        private MultiLayoutItem multiLayoutItem17;
        private MultiLayoutItem multiLayoutItem18;
        private MultiLayoutItem multiLayoutItem19;
        private MultiLayoutItem multiLayoutItem20;
        private MultiLayoutItem multiLayoutItem21;
        private MultiLayoutItem multiLayoutItem22;
        private MultiLayoutItem multiLayoutItem23;
        private MultiLayoutItem multiLayoutItem24;
        private MultiLayoutItem multiLayoutItem25;
        private MultiLayoutItem multiLayoutItem26;
        private MultiLayoutItem multiLayoutItem27;
        private MultiLayoutItem multiLayoutItem28;
        private MultiLayoutItem multiLayoutItem29;
        private MultiLayoutItem multiLayoutItem30;
        private MultiLayoutItem multiLayoutItem31;
        private MultiLayoutItem multiLayoutItem32;
        private MultiLayoutItem multiLayoutItem33;
        private MultiLayout layGwaDoctor;
        private MultiLayoutItem multiLayoutItem34;
        private MultiLayoutItem multiLayoutItem35;
        private MultiLayoutItem multiLayoutItem36;
        private MultiLayoutItem multiLayoutItem37;
        private MultiLayoutItem multiLayoutItem38;
        private MultiLayoutItem multiLayoutItem39;
        private MultiLayoutItem multiLayoutItem40;
        private MultiLayoutItem multiLayoutItem41;
        private MultiLayoutItem multiLayoutItem42;
        private MultiLayoutItem multiLayoutItem43;
        private MultiLayoutItem multiLayoutItem44;
        private MultiLayoutItem multiLayoutItem45;
        private MultiLayoutItem multiLayoutItem46;
        private MultiLayoutItem multiLayoutItem47;
        private MultiLayoutItem multiLayoutItem48;
        private MultiLayoutItem multiLayoutItem49;
        private MultiLayoutItem multiLayoutItem50;
        private MultiLayoutItem multiLayoutItem51;
        private MultiLayoutItem multiLayoutItem52;
        private MultiLayoutItem multiLayoutItem53;
        private MultiLayoutItem multiLayoutItem54;
        private MultiLayoutItem multiLayoutItem55;
        private MultiLayoutItem multiLayoutItem56;
        private MultiLayoutItem multiLayoutItem57;
        private MultiLayoutItem multiLayoutItem58;
        private MultiLayoutItem multiLayoutItem59;
        private MultiLayoutItem multiLayoutItem60;
        private MultiLayoutItem multiLayoutItem61;
        private MultiLayoutItem multiLayoutItem62;
        private MultiLayoutItem multiLayoutItem63;
        private MultiLayoutItem multiLayoutItem64;
        private MultiLayoutItem multiLayoutItem65;
        private MultiLayoutItem multiLayoutItem66;
        private MultiLayoutItem multiLayoutItem67;
        private MultiLayoutItem multiLayoutItem68;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion

		#region 생성자
		public NUR1001R00()
		{
			// 이 호출은 Windows Form 디자이너에 필요합니다.
			InitializeComponent();

            this.layQuery.ExecuteQuery = GetLayGwaTemp;
		}
		#endregion

		#region 소멸자
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
		#endregion

		#region Designer generated code
		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다.
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NUR1001R00));
            this.pnlTop = new IHIS.Framework.XPanel();
            this.cboGwa = new IHIS.Framework.XBuseoCombo();
            this.lblGwa = new IHIS.Framework.XLabel();
            this.mbxMonth = new IHIS.Framework.XMonthBox();
            this.lblMonth = new IHIS.Framework.XLabel();
            this.pnlBottom = new IHIS.Framework.XPanel();
            this.btnList = new IHIS.Framework.XButtonList();
            this.dwNUR1001R00 = new IHIS.Framework.XDataWindow();
            this.layQuery = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem36 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem37 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem38 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem39 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem40 = new IHIS.Framework.MultiLayoutItem();
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
            this.multiLayoutItem51 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem52 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem53 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem54 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem55 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem56 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem57 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem58 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem59 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem60 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem61 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem62 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem63 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem64 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem65 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem66 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem67 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem68 = new IHIS.Framework.MultiLayoutItem();
            this.layTemp = new IHIS.Framework.MultiLayout();
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
            this.multiLayoutItem31 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem32 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem33 = new IHIS.Framework.MultiLayoutItem();
            this.layGwaDoctor = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem34 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem35 = new IHIS.Framework.MultiLayoutItem();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboGwa)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layTemp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layGwaDoctor)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            resources.ApplyResources(this.pnlTop, "pnlTop");
            this.pnlTop.Controls.Add(this.cboGwa);
            this.pnlTop.Controls.Add(this.lblGwa);
            this.pnlTop.Controls.Add(this.mbxMonth);
            this.pnlTop.Controls.Add(this.lblMonth);
            this.pnlTop.Name = "pnlTop";
            // 
            // cboGwa
            // 
            resources.ApplyResources(this.cboGwa, "cboGwa");
            this.cboGwa.Name = "cboGwa";
            this.cboGwa.SelectedIndexChanged += new System.EventHandler(this.cboGwa_SelectedIndexChanged);
            // 
            // lblGwa
            // 
            this.lblGwa.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblGwa.EdgeRounding = false;
            resources.ApplyResources(this.lblGwa, "lblGwa");
            this.lblGwa.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lblGwa.Name = "lblGwa";
            // 
            // mbxMonth
            // 
            resources.ApplyResources(this.mbxMonth, "mbxMonth");
            this.mbxMonth.Name = "mbxMonth";
            this.mbxMonth.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.mbxMonth_DataValidating);
            // 
            // lblMonth
            // 
            this.lblMonth.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblMonth.EdgeRounding = false;
            resources.ApplyResources(this.lblMonth, "lblMonth");
            this.lblMonth.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lblMonth.Name = "lblMonth";
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnList);
            resources.ApplyResources(this.pnlBottom, "pnlBottom");
            this.pnlBottom.Name = "pnlBottom";
            // 
            // btnList
            // 
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.IsVisiblePreview = false;
            this.btnList.IsVisibleReset = false;
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Report;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // dwNUR1001R00
            // 
            this.dwNUR1001R00.DataWindowObject = "dw_nur1001r00";
            resources.ApplyResources(this.dwNUR1001R00, "dwNUR1001R00");
            this.dwNUR1001R00.LibraryList = "NURO\\nuro.nur1001r00.pbd";
            this.dwNUR1001R00.Name = "dwNUR1001R00";
            this.dwNUR1001R00.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.dwNUR1001R00.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dwNUR1001R00_MouseDown);
            // 
            // layQuery
            // 
            this.layQuery.ExecuteQuery = null;
            this.layQuery.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem36,
            this.multiLayoutItem37,
            this.multiLayoutItem38,
            this.multiLayoutItem39,
            this.multiLayoutItem40,
            this.multiLayoutItem41,
            this.multiLayoutItem42,
            this.multiLayoutItem43,
            this.multiLayoutItem44,
            this.multiLayoutItem45,
            this.multiLayoutItem46,
            this.multiLayoutItem47,
            this.multiLayoutItem48,
            this.multiLayoutItem49,
            this.multiLayoutItem50,
            this.multiLayoutItem51,
            this.multiLayoutItem52,
            this.multiLayoutItem53,
            this.multiLayoutItem54,
            this.multiLayoutItem55,
            this.multiLayoutItem56,
            this.multiLayoutItem57,
            this.multiLayoutItem58,
            this.multiLayoutItem59,
            this.multiLayoutItem60,
            this.multiLayoutItem61,
            this.multiLayoutItem62,
            this.multiLayoutItem63,
            this.multiLayoutItem64,
            this.multiLayoutItem65,
            this.multiLayoutItem66,
            this.multiLayoutItem67,
            this.multiLayoutItem68});
            this.layQuery.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layQuery.ParamList")));
            // 
            // multiLayoutItem36
            // 
            this.multiLayoutItem36.DataName = "doctor_name";
            // 
            // multiLayoutItem37
            // 
            this.multiLayoutItem37.DataName = "num1";
            this.multiLayoutItem37.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem38
            // 
            this.multiLayoutItem38.DataName = "num2";
            this.multiLayoutItem38.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem39
            // 
            this.multiLayoutItem39.DataName = "num3";
            this.multiLayoutItem39.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem40
            // 
            this.multiLayoutItem40.DataName = "num4";
            this.multiLayoutItem40.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem41
            // 
            this.multiLayoutItem41.DataName = "num5";
            this.multiLayoutItem41.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem42
            // 
            this.multiLayoutItem42.DataName = "num6";
            this.multiLayoutItem42.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem43
            // 
            this.multiLayoutItem43.DataName = "num7";
            this.multiLayoutItem43.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem44
            // 
            this.multiLayoutItem44.DataName = "num8";
            this.multiLayoutItem44.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem45
            // 
            this.multiLayoutItem45.DataName = "num9";
            this.multiLayoutItem45.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem46
            // 
            this.multiLayoutItem46.DataName = "num10";
            this.multiLayoutItem46.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem47
            // 
            this.multiLayoutItem47.DataName = "num11";
            this.multiLayoutItem47.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem48
            // 
            this.multiLayoutItem48.DataName = "num12";
            this.multiLayoutItem48.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem49
            // 
            this.multiLayoutItem49.DataName = "num13";
            this.multiLayoutItem49.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem50
            // 
            this.multiLayoutItem50.DataName = "num14";
            this.multiLayoutItem50.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem51
            // 
            this.multiLayoutItem51.DataName = "num15";
            this.multiLayoutItem51.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem52
            // 
            this.multiLayoutItem52.DataName = "num16";
            this.multiLayoutItem52.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem53
            // 
            this.multiLayoutItem53.DataName = "num17";
            this.multiLayoutItem53.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem54
            // 
            this.multiLayoutItem54.DataName = "num18";
            this.multiLayoutItem54.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem55
            // 
            this.multiLayoutItem55.DataName = "num19";
            this.multiLayoutItem55.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem56
            // 
            this.multiLayoutItem56.DataName = "num20";
            this.multiLayoutItem56.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem57
            // 
            this.multiLayoutItem57.DataName = "num21";
            this.multiLayoutItem57.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem58
            // 
            this.multiLayoutItem58.DataName = "num22";
            this.multiLayoutItem58.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem59
            // 
            this.multiLayoutItem59.DataName = "num23";
            this.multiLayoutItem59.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem60
            // 
            this.multiLayoutItem60.DataName = "num24";
            this.multiLayoutItem60.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem61
            // 
            this.multiLayoutItem61.DataName = "num25";
            this.multiLayoutItem61.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem62
            // 
            this.multiLayoutItem62.DataName = "num26";
            this.multiLayoutItem62.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem63
            // 
            this.multiLayoutItem63.DataName = "num27";
            this.multiLayoutItem63.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem64
            // 
            this.multiLayoutItem64.DataName = "num28";
            this.multiLayoutItem64.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem65
            // 
            this.multiLayoutItem65.DataName = "num29";
            // 
            // multiLayoutItem66
            // 
            this.multiLayoutItem66.DataName = "num30";
            this.multiLayoutItem66.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem67
            // 
            this.multiLayoutItem67.DataName = "num31";
            this.multiLayoutItem67.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem68
            // 
            this.multiLayoutItem68.DataName = "max_day";
            // 
            // layTemp
            // 
            this.layTemp.ExecuteQuery = null;
            this.layTemp.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
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
            this.multiLayoutItem11,
            this.multiLayoutItem12,
            this.multiLayoutItem13,
            this.multiLayoutItem14,
            this.multiLayoutItem15,
            this.multiLayoutItem16,
            this.multiLayoutItem17,
            this.multiLayoutItem18,
            this.multiLayoutItem19,
            this.multiLayoutItem20,
            this.multiLayoutItem21,
            this.multiLayoutItem22,
            this.multiLayoutItem23,
            this.multiLayoutItem24,
            this.multiLayoutItem25,
            this.multiLayoutItem26,
            this.multiLayoutItem27,
            this.multiLayoutItem28,
            this.multiLayoutItem29,
            this.multiLayoutItem30,
            this.multiLayoutItem31,
            this.multiLayoutItem32,
            this.multiLayoutItem33});
            this.layTemp.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layTemp.ParamList")));
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "doctor_name";
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "num1";
            this.multiLayoutItem2.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem3
            // 
            this.multiLayoutItem3.DataName = "num2";
            this.multiLayoutItem3.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem4
            // 
            this.multiLayoutItem4.DataName = "num3";
            this.multiLayoutItem4.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem5
            // 
            this.multiLayoutItem5.DataName = "num4";
            this.multiLayoutItem5.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem6
            // 
            this.multiLayoutItem6.DataName = "num5";
            this.multiLayoutItem6.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem7
            // 
            this.multiLayoutItem7.DataName = "num6";
            this.multiLayoutItem7.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem8
            // 
            this.multiLayoutItem8.DataName = "num7";
            this.multiLayoutItem8.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem9
            // 
            this.multiLayoutItem9.DataName = "num8";
            this.multiLayoutItem9.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem10
            // 
            this.multiLayoutItem10.DataName = "num9";
            this.multiLayoutItem10.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem11
            // 
            this.multiLayoutItem11.DataName = "num10";
            this.multiLayoutItem11.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem12
            // 
            this.multiLayoutItem12.DataName = "num11";
            this.multiLayoutItem12.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem13
            // 
            this.multiLayoutItem13.DataName = "num12";
            this.multiLayoutItem13.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem14
            // 
            this.multiLayoutItem14.DataName = "num13";
            this.multiLayoutItem14.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem15
            // 
            this.multiLayoutItem15.DataName = "num14";
            this.multiLayoutItem15.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem16
            // 
            this.multiLayoutItem16.DataName = "num15";
            this.multiLayoutItem16.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem17
            // 
            this.multiLayoutItem17.DataName = "num16";
            this.multiLayoutItem17.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem18
            // 
            this.multiLayoutItem18.DataName = "num17";
            this.multiLayoutItem18.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem19
            // 
            this.multiLayoutItem19.DataName = "num18";
            this.multiLayoutItem19.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem20
            // 
            this.multiLayoutItem20.DataName = "num19";
            this.multiLayoutItem20.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem21
            // 
            this.multiLayoutItem21.DataName = "num20";
            this.multiLayoutItem21.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem22
            // 
            this.multiLayoutItem22.DataName = "num21";
            this.multiLayoutItem22.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem23
            // 
            this.multiLayoutItem23.DataName = "num22";
            this.multiLayoutItem23.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem24
            // 
            this.multiLayoutItem24.DataName = "num23";
            this.multiLayoutItem24.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem25
            // 
            this.multiLayoutItem25.DataName = "num24";
            this.multiLayoutItem25.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem26
            // 
            this.multiLayoutItem26.DataName = "num25";
            this.multiLayoutItem26.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem27
            // 
            this.multiLayoutItem27.DataName = "num26";
            this.multiLayoutItem27.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem28
            // 
            this.multiLayoutItem28.DataName = "num27";
            this.multiLayoutItem28.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem29
            // 
            this.multiLayoutItem29.DataName = "num28";
            this.multiLayoutItem29.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem30
            // 
            this.multiLayoutItem30.DataName = "num29";
            this.multiLayoutItem30.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem31
            // 
            this.multiLayoutItem31.DataName = "num30";
            this.multiLayoutItem31.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem32
            // 
            this.multiLayoutItem32.DataName = "num31";
            this.multiLayoutItem32.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem33
            // 
            this.multiLayoutItem33.DataName = "max_day";
            // 
            // layGwaDoctor
            // 
            this.layGwaDoctor.ExecuteQuery = null;
            this.layGwaDoctor.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem34,
            this.multiLayoutItem35});
            this.layGwaDoctor.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layGwaDoctor.ParamList")));
            this.layGwaDoctor.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layGwaDoctor_QueryStarting);
            // 
            // multiLayoutItem34
            // 
            this.multiLayoutItem34.DataName = "doctor";
            // 
            // multiLayoutItem35
            // 
            this.multiLayoutItem35.DataName = "doctor_name";
            // 
            // NUR1001R00
            // 
            this.Controls.Add(this.dwNUR1001R00);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            resources.ApplyResources(this, "$this");
            this.Name = "NUR1001R00";
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.NUR1001R00_ScreenOpen);
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboGwa)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layTemp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layGwaDoctor)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region Screen Load
		private void NUR1001R00_ScreenOpen(object sender, IHIS.Framework.XScreenOpenEventArgs e)
		{
			//조회월에 현재 월을 셋팅을 한다.
			this.mbxMonth.SetEditValue(EnvironInfo.GetSysDate().ToString("yyyyMM"));
			this.mbxMonth.AcceptData();
            ApplyMultiLanguages();
		}
		#endregion

		#region 조회
		private void GetQuery()
		{
			if(this.mbxMonth.GetDataValue().ToString() != "" && this.cboGwa.GetDataValue().ToString() != "")
            {
                this.layQuery.Reset();
                //this.layGwaDoctor.QueryLayout(true);

                    //this.layTemp.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                    //this.layTemp.SetBindVarValue("f_month", this.mbxMonth.GetDataValue());
                    //this.layTemp.SetBindVarValue("f_gwa", this.cboGwa.GetDataValue());

                //for(int i = 0 ; i < this.layGwaDoctor.RowCount ; i++)
                //{
                //    /* 의사별 월진료통계를 조회한다. */
                //    this.layTemp.SetBindVarValue("f_doctor", this.layGwaDoctor.GetItemString(i, "doctor"));
                //    this.layTemp.SetBindVarValue("f_doctor_name", this.layGwaDoctor.GetItemString(i, "doctor_name"));

                //this.layTemp.QueryLayout(true);

                //foreach (DataRow dr in this.layTemp.LayoutTable.Rows)
                //{
                //    this.layQuery.LayoutTable.ImportRow(dr);
                //}
                //}
                //this.layQuery.AcceptData();
                this.layQuery.QueryLayout(true);

				if(this.layQuery.RowCount > 0)
				{
					this.dwNUR1001R00.Reset();
					this.dwNUR1001R00.Modify("txtmonth.Text = '"+ this.mbxMonth.GetDataValue().Substring(0, 4) + " / " + this.mbxMonth.GetDataValue().Substring(4, 2) +"'");
					this.dwNUR1001R00.Modify("txtgwa_name.Text = '"+ this.cboGwa.Text +"'");
                    this.dwNUR1001R00.FillData(this.layQuery.LayoutTable);
				}
				else
				{
					//XMessageBox.Show(Service.ErrFullMsg);

                    // https://sofiamedix.atlassian.net/browse/MED-12783
                    //XMessageBox.Show("医師リストが存在していません。", "お知らせ", MessageBoxIcon.Warning);
                    XMessageBox.Show(Resources.MSG_001, Resources.CAP_001, MessageBoxIcon.Warning);
				}
			}
		}
		#endregion

		#region 조회년월을 변경을 했을 때
		private void mbxMonth_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
			if(this.cboGwa.GetDataValue().ToString() != "")
			{
				//조회
				this.GetQuery();
			}
		}
		#endregion

		#region 조회년월을 변경을 했을 때
		private void cboGwa_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(this.mbxMonth.GetDataValue().ToString() != "")
			{
				//조회
				this.GetQuery();
			}
		}
		#endregion

		#region 버튼리스트에서 버튼을 클릭을 했을 때의 이벤트
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

					//조회
					this.GetQuery();
					break;
				case FunctionType.Print:
					if(this.dwNUR1001R00.RowCount > 0)
					{
						this.dwNUR1001R00.Print(true);
					}
					break;
				default:
					break;
			}
		}
		#endregion

        private void layGwaDoctor_QueryStarting(object sender, CancelEventArgs e)
        {
            //this.layGwaDoctor.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            //this.layGwaDoctor.SetBindVarValue("f_gwa", this.cboGwa.GetDataValue());
            //this.layGwaDoctor.SetBindVarValue("f_month", this.mbxMonth.GetDataValue());
        }

        private void dwNUR1001R00_MouseDown(object sender, MouseEventArgs e)
        {

            this.dwNUR1001R00.Refresh();
        }

        #region Updated code

        #region GetLayGwaTemp
        /// <summary>
        /// GetLayGwaTemp
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private IList<object[]> GetLayGwaTemp(BindVarCollection list)
        {
            IList<object[]> lObj = new List<object[]>();

            NuroNUR1001R00GetGwaDoctorTempListArgs args = new NuroNUR1001R00GetGwaDoctorTempListArgs();
            args.Gwa = cboGwa.GetDataValue();
            args.Month = mbxMonth.GetDataValue();
            NuroNUR1001R00GetGwaDoctorTempListResult res = CloudService.Instance.Submit<NuroNUR1001R00GetGwaDoctorTempListResult,
                NuroNUR1001R00GetGwaDoctorTempListArgs>(args);

            if (null != res)
            {
                foreach (NuroNUR1001R00GetTempListItemInfo item in res.TemItem)
                {
                    lObj.Add(new object[]
                    {
                        item.DoctorName,
                        item.Num1,
                        item.Num2,
                        item.Num3,
                        item.Num4,
                        item.Num5,
                        item.Num6,
                        item.Num7,
                        item.Num8,
                        item.Num9,
                        item.Num10,
                        item.Num11,
                        item.Num12,
                        item.Num13,
                        item.Num14,
                        item.Num15,
                        item.Num16,
                        item.Num17,
                        item.Num18,
                        item.Num19,
                        item.Num20,
                        item.Num21,
                        item.Num22,
                        item.Num23,
                        item.Num24,
                        item.Num25,
                        item.Num26,
                        item.Num27,
                        item.Num28,
                        item.Num29,
                        item.Num30,
                        item.Num31,
                        item.LastDay,
                    });
                }
            }

            return lObj;
        }
        #endregion

        #endregion

        #region Apply multi languages
        private void ApplyMultiLanguages()
        {
            try
            {
                //dwNUR1001R00
                dwNUR1001R00.Refresh();
                dwNUR1001R00.Modify(string.Format("t_1.text = '{0}'",  Resources.DW_TXT_1));
                dwNUR1001R00.Modify(string.Format("t_34.text = '{0}'", Resources.DW_TXT_2));
                dwNUR1001R00.Modify(string.Format("t_35.text = '{0}'", Resources.DW_TXT_3));
                dwNUR1001R00.Modify(string.Format("t_33.text = '{0}'", Resources.DW_TXT_4));

                // https://sofiamedix.atlassian.net/browse/MED-12783
                dwNUR1001R00.Modify(string.Format("t_36.text = '{0}'", UserInfo.HospName));

                //MED-12694
                dwNUR1001R00.Modify(string.Format("t_sysdate.text = '{0}'", EnvironInfo.GetSysDateTime().ToString()));
            }
            catch// (Exception ex)
            {
                //https://sofiamedix.atlassian.net/browse/MED-10610
                //MessageBox.Show(ex.StackTrace);
            }
        }
        #endregion

    }
}

