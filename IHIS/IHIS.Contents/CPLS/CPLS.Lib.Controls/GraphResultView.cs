using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Arguments.Cpls;
using IHIS.CloudConnector.Contracts.Models.Cpls;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.Cpls;
using IHIS.Framework;
using System.ComponentModel.Design;

namespace IHIS.CPLS
{
	/// <summary>
	/// GraphResultView에 대한 요약 설명입니다.
	/// </summary>
    /// 
    [Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof(IDesigner))]
    public class GraphResultView : System.Windows.Forms.UserControl, ISupportInitialize
	{
		private Dundas.Charting.WinControl.Chart chartLine;
		private System.Windows.Forms.CheckBox cbxResultVisible;
		private IHIS.Framework.XButton btnLineBase;
		private IHIS.Framework.XCTrackBar tbLineY;
		private IHIS.Framework.XCTrackBar tbLineX;
		private System.Windows.Forms.CheckBox cbxLine3D;
		private IHIS.Framework.XButton btnNext;
		private IHIS.Framework.XButton btnPre;
		private IHIS.Framework.XButton btnNumVisible;
		private IHIS.Framework.MultiLayout laySigeyul;
        private IHIS.Framework.MultiLayout layPreSigeyul;
		private IHIS.Framework.XEditGrid grdSigeyul;
		private IHIS.Framework.XEditGridCell xEditGridCell1;
		private IHIS.Framework.XEditGridCell xEditGridCell2;
		private IHIS.Framework.XEditGridCell xEditGridCell3;
		private IHIS.Framework.XEditGridCell xEditGridCell4;
		private IHIS.Framework.XEditGridCell xEditGridCell5;
        private IHIS.Framework.XEditGridCell xEditGridCell6;
        private IContainer components;
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
        private ImageList imageList1;
        private Panel panel1;
        private Label label1;

		#region fields
		private DataTable lineTable = new DataTable("Line"); //LineChart의 DataSource (일별 결과를 조회하여 lineTable 구성함) 
		#endregion

        #region ISupportInitialize
        /// <summary>
        /// 초기화가 시작됨을 개체에 알립니다.
        /// </summary>
        void ISupportInitialize.BeginInit()
        {
        }
        /// <summary>
        /// 초기화 종료시 환자번호 BOX 초기화(InitialzePaComment)합니다.
        /// </summary>
        void ISupportInitialize.EndInit()
        {
        }
        #endregion

		#region 생성자
		public GraphResultView()
		{
            //try
            //{
                // 이 호출은 Windows.Forms Form 디자이너에 필요합니다.
                InitializeComponent();
            //}
            //catch(Exception x)
            //{
            //    //XMessageBox.Show(x.StackTrace + " - " + x.Message);                
            //}

		}
		#endregion

		#region Dispose
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

		#region 구성 요소 디자이너에서 생성한 코드
		/// <summary> 
		/// 디자이너 지원에 필요한 메서드입니다. 
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GraphResultView));
            Dundas.Charting.WinControl.ChartArea chartArea1 = new Dundas.Charting.WinControl.ChartArea();
            Dundas.Charting.WinControl.Legend legend1 = new Dundas.Charting.WinControl.Legend();
            Dundas.Charting.WinControl.Series series1 = new Dundas.Charting.WinControl.Series();
            Dundas.Charting.WinControl.Series series2 = new Dundas.Charting.WinControl.Series();
            Dundas.Charting.WinControl.Series series3 = new Dundas.Charting.WinControl.Series();
            Dundas.Charting.WinControl.Title title1 = new Dundas.Charting.WinControl.Title();
            this.chartLine = new Dundas.Charting.WinControl.Chart();
            this.cbxResultVisible = new System.Windows.Forms.CheckBox();
            this.btnLineBase = new IHIS.Framework.XButton();
            this.tbLineY = new IHIS.Framework.XCTrackBar();
            this.tbLineX = new IHIS.Framework.XCTrackBar();
            this.cbxLine3D = new System.Windows.Forms.CheckBox();
            this.btnNext = new IHIS.Framework.XButton();
            this.btnPre = new IHIS.Framework.XButton();
            this.btnNumVisible = new IHIS.Framework.XButton();
            this.laySigeyul = new IHIS.Framework.MultiLayout();
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
            this.layPreSigeyul = new IHIS.Framework.MultiLayout();
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
            this.grdSigeyul = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chartLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.laySigeyul)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layPreSigeyul)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSigeyul)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chartLine
            // 
            this.chartLine.AccessibleDescription = null;
            this.chartLine.AccessibleName = null;
            resources.ApplyResources(this.chartLine, "chartLine");
            this.chartLine.BackColor = System.Drawing.Color.WhiteSmoke;
            this.chartLine.BackGradientEndColor = System.Drawing.Color.White;
            this.chartLine.BackGradientType = Dundas.Charting.WinControl.GradientType.DiagonalLeft;
            this.chartLine.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            this.chartLine.BorderLineStyle = Dundas.Charting.WinControl.ChartDashStyle.Solid;
            chartArea1.Name = "Default";
            this.chartLine.ChartAreas.Add(chartArea1);
            legend1.Alignment = System.Drawing.StringAlignment.Center;
            legend1.AutoFitText = false;
            legend1.BackColor = System.Drawing.Color.White;
            legend1.BorderColor = System.Drawing.Color.Transparent;
            legend1.Docking = Dundas.Charting.WinControl.LegendDocking.Top;
            legend1.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            legend1.LegendStyle = Dundas.Charting.WinControl.LegendStyle.Row;
            legend1.Name = "Default";
            legend1.ShadowOffset = 2;
            this.chartLine.Legends.Add(legend1);
            this.chartLine.Name = "chartLine";
            this.chartLine.Palette = Dundas.Charting.WinControl.ChartColorPalette.Dundas;
            series1.ChartType = "Line";
            series1.CustomAttributes = "LabelStyle=TopRight";
            series1.EmptyPointStyle.BorderStyle = Dundas.Charting.WinControl.ChartDashStyle.Dash;
            series1.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold);
            series1.FontColor = System.Drawing.Color.DodgerBlue;
            series1.MarkerSize = 6;
            series1.MarkerStyle = Dundas.Charting.WinControl.MarkerStyle.Square;
            series1.Name = "前前月";
            series1.ShowLabelAsValue = true;
            series1.ToolTip = "#VALY";
            series1.XValueType = Dundas.Charting.WinControl.ChartValueTypes.DateTime;
            series1.YValueType = Dundas.Charting.WinControl.ChartValueTypes.Double;
            series2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            series2.BorderWidth = 2;
            series2.ChartType = "Line";
            series2.CustomAttributes = "LabelStyle=TopRight";
            series2.EmptyPointStyle.BorderStyle = Dundas.Charting.WinControl.ChartDashStyle.Dash;
            series2.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold);
            series2.FontColor = System.Drawing.Color.DarkOrange;
            series2.MarkerSize = 8;
            series2.MarkerStyle = Dundas.Charting.WinControl.MarkerStyle.Diamond;
            series2.Name = "当月";
            series2.ShadowOffset = 2;
            series2.ShowLabelAsValue = true;
            series2.ToolTip = "#VALY";
            series2.XValueType = Dundas.Charting.WinControl.ChartValueTypes.DateTime;
            series2.YValueType = Dundas.Charting.WinControl.ChartValueTypes.Double;
            series3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            series3.ChartType = "Line";
            series3.CustomAttributes = "LabelStyle=TopRight";
            series3.EmptyPointStyle.BorderStyle = Dundas.Charting.WinControl.ChartDashStyle.Dash;
            series3.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold);
            series3.FontColor = System.Drawing.Color.DarkRed;
            series3.MarkerSize = 6;
            series3.MarkerStyle = Dundas.Charting.WinControl.MarkerStyle.Circle;
            series3.Name = "前月";
            series3.ShowLabelAsValue = true;
            series3.ToolTip = "#VALY";
            series3.XValueType = Dundas.Charting.WinControl.ChartValueTypes.DateTime;
            series3.YValueType = Dundas.Charting.WinControl.ChartValueTypes.Double;
            this.chartLine.Series.Add(series1);
            this.chartLine.Series.Add(series2);
            this.chartLine.Series.Add(series3);
            title1.Name = "Title1";
            this.chartLine.Titles.Add(title1);
            // 
            // cbxResultVisible
            // 
            this.cbxResultVisible.AccessibleDescription = null;
            this.cbxResultVisible.AccessibleName = null;
            resources.ApplyResources(this.cbxResultVisible, "cbxResultVisible");
            this.cbxResultVisible.BackgroundImage = null;
            this.cbxResultVisible.Font = null;
            this.cbxResultVisible.Name = "cbxResultVisible";
            this.cbxResultVisible.UseVisualStyleBackColor = false;
            this.cbxResultVisible.Click += new System.EventHandler(this.cbxResultVisible_CheckedChanged);
            // 
            // btnLineBase
            // 
            this.btnLineBase.AccessibleDescription = null;
            this.btnLineBase.AccessibleName = null;
            resources.ApplyResources(this.btnLineBase, "btnLineBase");
            this.btnLineBase.BackgroundImage = null;
            this.btnLineBase.Image = global::IHIS.CPLS.Properties.Resources.로테이트;
            this.btnLineBase.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnLineBase.Name = "btnLineBase";
            this.btnLineBase.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnLineBase.Click += new System.EventHandler(this.btnLineBase_Click);
            // 
            // tbLineY
            // 
            this.tbLineY.AccessibleDescription = null;
            this.tbLineY.AccessibleName = null;
            resources.ApplyResources(this.tbLineY, "tbLineY");
            this.tbLineY.BarBorderColor = new IHIS.Framework.XColor(System.Drawing.Color.CadetBlue);
            this.tbLineY.BarColor = new IHIS.Framework.XColor(System.Drawing.Color.LightCyan);
            this.tbLineY.Maximum = 180;
            this.tbLineY.Minimum = -180;
            this.tbLineY.Name = "tbLineY";
            this.tbLineY.Value = 30;
            this.tbLineY.ValueChanged += new System.EventHandler(this.tbLineY_ValueChanged);
            // 
            // tbLineX
            // 
            this.tbLineX.AccessibleDescription = null;
            this.tbLineX.AccessibleName = null;
            resources.ApplyResources(this.tbLineX, "tbLineX");
            this.tbLineX.Maximum = 90;
            this.tbLineX.Minimum = -90;
            this.tbLineX.Name = "tbLineX";
            this.tbLineX.Value = 30;
            this.tbLineX.ValueChanged += new System.EventHandler(this.tbLineX_ValueChanged);
            // 
            // cbxLine3D
            // 
            this.cbxLine3D.AccessibleDescription = null;
            this.cbxLine3D.AccessibleName = null;
            resources.ApplyResources(this.cbxLine3D, "cbxLine3D");
            this.cbxLine3D.BackgroundImage = null;
            this.cbxLine3D.Font = null;
            this.cbxLine3D.Name = "cbxLine3D";
            this.cbxLine3D.UseVisualStyleBackColor = false;
            this.cbxLine3D.Click += new System.EventHandler(this.cbxLine3D_CheckedChanged);
            // 
            // btnNext
            // 
            this.btnNext.AccessibleDescription = null;
            this.btnNext.AccessibleName = null;
            resources.ApplyResources(this.btnNext, "btnNext");
            this.btnNext.BackgroundImage = null;
            this.btnNext.Image = ((System.Drawing.Image)(resources.GetObject("btnNext.Image")));
            this.btnNext.Name = "btnNext";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPre
            // 
            this.btnPre.AccessibleDescription = null;
            this.btnPre.AccessibleName = null;
            resources.ApplyResources(this.btnPre, "btnPre");
            this.btnPre.BackgroundImage = null;
            this.btnPre.Image = ((System.Drawing.Image)(resources.GetObject("btnPre.Image")));
            this.btnPre.Name = "btnPre";
            this.btnPre.Click += new System.EventHandler(this.btnPre_Click);
            // 
            // btnNumVisible
            // 
            this.btnNumVisible.AccessibleDescription = null;
            this.btnNumVisible.AccessibleName = null;
            resources.ApplyResources(this.btnNumVisible, "btnNumVisible");
            this.btnNumVisible.BackgroundImage = null;
            this.btnNumVisible.Image = ((System.Drawing.Image)(resources.GetObject("btnNumVisible.Image")));
            this.btnNumVisible.Name = "btnNumVisible";
            this.btnNumVisible.Click += new System.EventHandler(this.btnNumVisible_Click);
            // 
            // laySigeyul
            // 
            this.laySigeyul.ExecuteQuery = null;
            this.laySigeyul.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
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
            this.multiLayoutItem66});
            this.laySigeyul.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("laySigeyul.ParamList")));
            // 
            // multiLayoutItem45
            // 
            this.multiLayoutItem45.DataName = "gumsa_name";
            // 
            // multiLayoutItem46
            // 
            this.multiLayoutItem46.DataName = "result_date1";
            // 
            // multiLayoutItem47
            // 
            this.multiLayoutItem47.DataName = "result_1";
            // 
            // multiLayoutItem48
            // 
            this.multiLayoutItem48.DataName = "standard_yn_1";
            // 
            // multiLayoutItem49
            // 
            this.multiLayoutItem49.DataName = "result_date2";
            // 
            // multiLayoutItem50
            // 
            this.multiLayoutItem50.DataName = "result_2";
            // 
            // multiLayoutItem51
            // 
            this.multiLayoutItem51.DataName = "standard_yn_2";
            // 
            // multiLayoutItem52
            // 
            this.multiLayoutItem52.DataName = "result_date3";
            // 
            // multiLayoutItem53
            // 
            this.multiLayoutItem53.DataName = "result_3";
            // 
            // multiLayoutItem54
            // 
            this.multiLayoutItem54.DataName = "standard_yn_3";
            // 
            // multiLayoutItem55
            // 
            this.multiLayoutItem55.DataName = "result_date4";
            // 
            // multiLayoutItem56
            // 
            this.multiLayoutItem56.DataName = "result_4";
            // 
            // multiLayoutItem57
            // 
            this.multiLayoutItem57.DataName = "standard_yn_4";
            // 
            // multiLayoutItem58
            // 
            this.multiLayoutItem58.DataName = "result_date5";
            // 
            // multiLayoutItem59
            // 
            this.multiLayoutItem59.DataName = "result_5";
            // 
            // multiLayoutItem60
            // 
            this.multiLayoutItem60.DataName = "standard_yn_5";
            // 
            // multiLayoutItem61
            // 
            this.multiLayoutItem61.DataName = "result_date6";
            // 
            // multiLayoutItem62
            // 
            this.multiLayoutItem62.DataName = "result_6";
            // 
            // multiLayoutItem63
            // 
            this.multiLayoutItem63.DataName = "standard_yn_6";
            // 
            // multiLayoutItem64
            // 
            this.multiLayoutItem64.DataName = "result_date7";
            // 
            // multiLayoutItem65
            // 
            this.multiLayoutItem65.DataName = "result_7";
            // 
            // multiLayoutItem66
            // 
            this.multiLayoutItem66.DataName = "standard_yn_7";
            // 
            // layPreSigeyul
            // 
            this.layPreSigeyul.ExecuteQuery = null;
            this.layPreSigeyul.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
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
            this.multiLayoutItem22});
            this.layPreSigeyul.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layPreSigeyul.ParamList")));
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "gumsa_name";
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "result_date1";
            this.multiLayoutItem2.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem3
            // 
            this.multiLayoutItem3.DataName = "result_1";
            // 
            // multiLayoutItem4
            // 
            this.multiLayoutItem4.DataName = "standard_yn_1";
            // 
            // multiLayoutItem5
            // 
            this.multiLayoutItem5.DataName = "result_date2";
            this.multiLayoutItem5.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem6
            // 
            this.multiLayoutItem6.DataName = "result_2";
            // 
            // multiLayoutItem7
            // 
            this.multiLayoutItem7.DataName = "standard_yn_2";
            // 
            // multiLayoutItem8
            // 
            this.multiLayoutItem8.DataName = "result_date3";
            this.multiLayoutItem8.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem9
            // 
            this.multiLayoutItem9.DataName = "result_3";
            // 
            // multiLayoutItem10
            // 
            this.multiLayoutItem10.DataName = "standard_yn_3";
            // 
            // multiLayoutItem11
            // 
            this.multiLayoutItem11.DataName = "result_date4";
            this.multiLayoutItem11.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem12
            // 
            this.multiLayoutItem12.DataName = "result_4";
            // 
            // multiLayoutItem13
            // 
            this.multiLayoutItem13.DataName = "standard_yn_4";
            // 
            // multiLayoutItem14
            // 
            this.multiLayoutItem14.DataName = "result_date5";
            this.multiLayoutItem14.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem15
            // 
            this.multiLayoutItem15.DataName = "result_5";
            // 
            // multiLayoutItem16
            // 
            this.multiLayoutItem16.DataName = "standard_yn_5";
            // 
            // multiLayoutItem17
            // 
            this.multiLayoutItem17.DataName = "result_date6";
            this.multiLayoutItem17.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem18
            // 
            this.multiLayoutItem18.DataName = "result_6";
            // 
            // multiLayoutItem19
            // 
            this.multiLayoutItem19.DataName = "standard_yn_6";
            // 
            // multiLayoutItem20
            // 
            this.multiLayoutItem20.DataName = "result_date7";
            this.multiLayoutItem20.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem21
            // 
            this.multiLayoutItem21.DataName = "result_7";
            // 
            // multiLayoutItem22
            // 
            this.multiLayoutItem22.DataName = "standard_yn_7";
            // 
            // grdSigeyul
            // 
            resources.ApplyResources(this.grdSigeyul, "grdSigeyul");
            this.grdSigeyul.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell6});
            this.grdSigeyul.ColPerLine = 6;
            this.grdSigeyul.Cols = 6;
            this.grdSigeyul.ExecuteQuery = null;
            this.grdSigeyul.FixedRows = 1;
            this.grdSigeyul.HeaderHeights.Add(21);
            this.grdSigeyul.Name = "grdSigeyul";
            this.grdSigeyul.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdSigeyul.ParamList")));
            this.grdSigeyul.Rows = 2;
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell1.CellName = "bunho";
            this.xEditGridCell1.ExecuteQuery = null;
            this.xEditGridCell1.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell2.CellName = "hangmog_code";
            this.xEditGridCell2.Col = 1;
            this.xEditGridCell2.ExecuteQuery = null;
            this.xEditGridCell2.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell3.CellName = "hangmog_name";
            this.xEditGridCell3.Col = 2;
            this.xEditGridCell3.ExecuteQuery = null;
            this.xEditGridCell3.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell4.CellName = "gubun";
            this.xEditGridCell4.Col = 3;
            this.xEditGridCell4.ExecuteQuery = null;
            this.xEditGridCell4.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell5.CellName = "base_date";
            this.xEditGridCell5.Col = 4;
            this.xEditGridCell5.ExecuteQuery = null;
            this.xEditGridCell5.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell6.CellName = "dummy";
            this.xEditGridCell6.Col = 5;
            this.xEditGridCell6.ExecuteQuery = null;
            this.xEditGridCell6.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            // 
            // panel1
            // 
            this.panel1.AccessibleDescription = null;
            this.panel1.AccessibleName = null;
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.BackgroundImage = null;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.tbLineY);
            this.panel1.Controls.Add(this.cbxLine3D);
            this.panel1.Controls.Add(this.btnPre);
            this.panel1.Controls.Add(this.cbxResultVisible);
            this.panel1.Controls.Add(this.tbLineX);
            this.panel1.Controls.Add(this.btnNext);
            this.panel1.Controls.Add(this.btnLineBase);
            this.panel1.Font = null;
            this.panel1.Name = "panel1";
            // 
            // label1
            // 
            this.label1.AccessibleDescription = null;
            this.label1.AccessibleName = null;
            resources.ApplyResources(this.label1, "label1");
            this.label1.Font = null;
            this.label1.Name = "label1";
            // 
            // GraphResultView
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.chartLine);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.grdSigeyul);
            this.Controls.Add(this.btnNumVisible);
            this.Font = null;
            this.Name = "GraphResultView";
            ((System.ComponentModel.ISupportInitialize)(this.chartLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.laySigeyul)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layPreSigeyul)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSigeyul)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		#region Methods

        #region ResetData()
        public void ResetData()
        {
            this.chartLine.Series.Clear();
            this.chartLine.DataSource = null;
        }
        #endregion 

        #region GetSigeyulData
        private bool GetSigeyulData()
        {
            this.laySigeyul.Reset();
            // Connect to cloud
            List<MultiResultViewGrdSigeyulInfo> lsGrdSigeyulInfo = CreateListGrdSigeyulItem();
            if (lsGrdSigeyulInfo != null && lsGrdSigeyulInfo.Count > 0)
            {
                MultiResultViewGetJubsuSigeyulArgs args = new MultiResultViewGetJubsuSigeyulArgs();
                args.GrdSigeyulItem = lsGrdSigeyulInfo;
                args.UserId = UserInfo.UserID;
                MultiResultViewLaySigeyulResult result =
                    CloudService.Instance.Submit<MultiResultViewLaySigeyulResult, MultiResultViewGetJubsuSigeyulArgs>(
                        args);
                if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
                {
                    List<MultiResultViewLaySigeyulInfo> lstLaySigeyulInfo = result.LaySigeyulInfo;
                    if (lstLaySigeyulInfo == null || lstLaySigeyulInfo.Count < 0)
                    {
                        return false;
                    }

                    for (int i = 0; i < lstLaySigeyulInfo.Count; i++)
                    {
                        int rowNum = this.laySigeyul.InsertRow(i);
                        this.laySigeyul.SetItemValue(rowNum, "gumsa_name", lstLaySigeyulInfo[i].GumsaName);
                        List<MultiResultViewDataForLaySigeyulInfo> lstDataForLaySigeyulInfo = lstLaySigeyulInfo[i].DataInfo;
                        if (lstDataForLaySigeyulInfo != null && lstDataForLaySigeyulInfo.Count > 0)
                        {
                            int tCnt = 0;
                            foreach (MultiResultViewDataForLaySigeyulInfo info in lstDataForLaySigeyulInfo)
                            {
                                tCnt++;
                                if (tCnt > 7)
                                    break;

                                if (tCnt == Int32.Parse(info.TCnt))
                                {
                                    this.laySigeyul.SetItemValue(rowNum, "result_date" + tCnt.ToString(), info.ResultDate);
                                    this.laySigeyul.SetItemValue(rowNum, "result_" + tCnt.ToString(), info.Result);
                                    this.laySigeyul.SetItemValue(rowNum, "standard_yn_" + tCnt.ToString(), info.StandardYn);
                                    
                                }
                            }
                        }
                    }

                }
            }

            // TODO comment use connect to cloud
            /*string o_jubsu_date = "";
            string o_jubsu_time = "";
            string o_jubsu_time2 = "";
            string o_cpl_result = "";
            string o_standard_yn = "";
            string o_hangmog_name = "";

            string t_hangmog_code = "";
            string t_base_date = "";

            string cmdText = "";
            BindVarCollection bc = new BindVarCollection();

            cmdText = @"DELETE CPLTEMP
                         WHERE HOSP_CODE  = :f_hosp_code
                           AND IP_ADDRESS = :q_user_id -- 컬럼명 아이피지만 실데이타는 유저아이디
                           AND JUNDAL_GUBUN = 'XX'";

            bc.Add("f_hosp_code", EnvironInfo.HospCode);
            bc.Add("q_user_id", UserInfo.UserID);

            Service.ExecuteNonQuery(cmdText, bc);

            for (int i = 0; i < grdSigeyul.RowCount; i++)
            {
                cmdText = @"INSERT INTO CPLTEMP 
                                 ( IP_ADDRESS       , JUNDAL_GUBUN
                                 , SEQ_CODE         , HANGMOG_CODE      , HOSP_CODE   )
                            VALUES 
                                 ( :q_user_id       , 'XX'
                                 , TO_CHAR(:i)      , :f_hangmog_code   , :f_hosp_code )";

                bc.Add("i", i.ToString());
                bc.Add("f_hangmog_code", this.grdSigeyul.GetItemString(i, "hangmog_code"));

                Service.ExecuteNonQuery(cmdText, bc);
            }

            this.laySigeyul.Reset();
            bc.Clear();

            for (int i = 0; i < grdSigeyul.RowCount; i++)
            {
                int rowNum = this.laySigeyul.InsertRow(i);

                t_hangmog_code = this.grdSigeyul.GetItemString(i, "hangmog_code");
                t_base_date = this.grdSigeyul.GetItemString(i, "base_date");

                bc.Add("f_hosp_code", EnvironInfo.HospCode);
                bc.Add("q_user_id", UserInfo.UserID);
                bc.Add("f_bunho", this.grdSigeyul.GetItemString(i, "bunho"));
                bc.Add("f_hangmog_code", t_hangmog_code);
                bc.Add("f_hangmog_name", this.grdSigeyul.GetItemString(i, "hangmog_name"));
                bc.Add("f_base_date", t_base_date);

                this.laySigeyul.SetItemValue(rowNum, "gumsa_name", this.grdSigeyul.GetItemString(i, "hangmog_name"));

                if (this.grdSigeyul.GetItemString(i, "gubun") == "0")
                {
                    /*********** 결과일자 LOAD **********#1#
                    cmdText = @"  SELECT DISTINCT 
                                         TO_CHAR(A.PART_JUBSU_DATE, 'YYYY/MM/DD')   JUBSU_DATE
                                       , SUBSTR(A.PART_JUBSU_TIME,1,3)    JUBSU_TIME
                                       , TO_CHAR(A.PART_JUBSU_DATE,'YY.MM.DD')
                                         ||'('||SUBSTR(A.PART_JUBSU_TIME,1,2)||':'||SUBSTR(A.PART_JUBSU_TIME,3,1)||'0)' JUBSU_TIME2
                                    FROM CPLTEMP C,
                                         CPL3020 B,
                                         CPL2010 A
                                   WHERE A.HOSP_CODE     = :f_hosp_code
                                     AND B.HOSP_CODE     = A.HOSP_CODE
                                     AND C.HOSP_CODE     = A.HOSP_CODE
                                     AND A.BUNHO         = :f_bunho
                                     AND A.RESULT_DATE   IS NOT NULL
                                     AND B.SPECIMEN_SER  = A.SPECIMEN_SER
                                     AND C.IP_ADDRESS    = :q_user_id
                                     AND C.JUNDAL_GUBUN  = 'XX'
                                     AND B.HANGMOG_CODE  = C.HANGMOG_CODE
                                   ORDER BY TO_CHAR(A.PART_JUBSU_DATE, 'YYYY/MM/DD') , SUBSTR(A.PART_JUBSU_TIME,1,3)";


                    DataTable dt = Service.ExecuteDataTable(cmdText, bc);
                    if (dt.Rows.Count < 1)
                        return false;
                    int tCnt = 0;

                    foreach (DataRow row in dt.Rows)
                    {
                        tCnt++;
                        if (tCnt > 7)
                            break;

                        o_jubsu_date = row["jubsu_date"].ToString();
                        o_jubsu_time = row["jubsu_time"].ToString();
                        o_jubsu_time2 = row["jubsu_time2"].ToString();

                        cmdText = @"  SELECT B.CPL_RESULT       CPL_RESULT
                                            ,B.STANDARD_YN      STANDARD_YN
                                            ,C.GUMSA_NAME       GUMSA_NAME
                                        FROM CPL0101 C,
                                             CPL3020 B,
                                             CPL2010 A
                                       WHERE A.HOSP_CODE     = :f_hosp_code
                                         AND B.HOSP_CODE     = A.HOSP_CODE
                                         AND C.HOSP_CODE     = A.HOSP_CODE
                                         AND A.BUNHO         = :f_bunho
                                         AND B.FKCPL2010     = A.PKCPL2010
                                         AND B.HANGMOG_CODE  = :f_hangmog_code
                                         AND A.PART_JUBSU_DATE   = :o_jubsu_date
                                         AND SUBSTR(A.PART_JUBSU_TIME,1,3) = :o_jubsu_time
                                         AND C.HANGMOG_CODE  = B.HANGMOG_CODE
                                         AND C.SPECIMEN_CODE = B.SPECIMEN_CODE
                                         AND C.EMERGENCY     = B.EMERGENCY  ";

                        bc.Add("o_jubsu_date", o_jubsu_date);
                        bc.Add("o_jubsu_time", o_jubsu_time);

                        DataTable dt2 = Service.ExecuteDataTable(cmdText, bc);

                        if (Service.ErrCode != 0)
                            o_cpl_result = "";
                        o_standard_yn = "";
                        o_hangmog_name = "";

                        if (!TypeCheck.IsNull(dt2))
                        {
                            o_cpl_result = dt2.Rows[0]["cpl_result"].ToString();
                            o_standard_yn = dt2.Rows[0]["standard_yn"].ToString();
                            o_hangmog_name = dt2.Rows[0]["gumsa_name"].ToString();
                        }

                        this.laySigeyul.SetItemValue(rowNum, "result_date" + tCnt.ToString(), o_jubsu_time2);
                        this.laySigeyul.SetItemValue(rowNum, "result_" + tCnt.ToString(), o_cpl_result);
                        this.laySigeyul.SetItemValue(rowNum, "standard_yn_" + tCnt.ToString(), o_standard_yn);
                    }
                }
                else if (this.grdSigeyul.GetItemString(i, "gubun") == "1")
                {
                    /*********** 결과일자 LOAD **********#1#
                    cmdText = @"SELECT DISTINCT 
                                       TO_CHAR(A.PART_JUBSU_DATE, 'YYYY/MM/DD')   JUBSU_DATE
                                     , SUBSTR(A.PART_JUBSU_TIME,1,3)    JUBSU_TIME
                                     , TO_CHAR(A.PART_JUBSU_DATE,'YY.MM.DD')
                                       ||'('||SUBSTR(A.PART_JUBSU_TIME,1,2)||':'||SUBSTR(A.PART_JUBSU_TIME,3,1)||'0)'  JUBSU_TIME2
                                  FROM CPLTEMP C,
                                       CPL3020 B,
                                       CPL2010 A
                                 WHERE A.HOSP_CODE     = :f_hosp_code
                                   AND B.HOSP_CODE     = A.HOSP_CODE
                                   AND C.HOSP_CODE     = A.HOSP_CODE
                                   AND A.BUNHO         = :f_bunho
                                   AND A.RESULT_DATE   IS NOT NULL
                                   AND TO_CHAR(A.PART_JUBSU_DATE,'YY.MM.DD')||'('||SUBSTR(A.PART_JUBSU_TIME,1,2)||':'||SUBSTR(A.PART_JUBSU_TIME,3,1)||'0)' < :f_base_date
                                   AND B.SPECIMEN_SER  = A.SPECIMEN_SER
                                   AND C.IP_ADDRESS    = :q_user_id
                                   AND C.JUNDAL_GUBUN  = 'XX'
                                   AND B.HANGMOG_CODE  = C.HANGMOG_CODE
                                 ORDER BY TO_CHAR(A.PART_JUBSU_DATE, 'YYYY/MM/DD') DESC , SUBSTR(A.PART_JUBSU_TIME,1,3) DESC";

                    DataTable dt = Service.ExecuteDataTable(cmdText, bc);
                    if (dt.Rows.Count < 1)
                        return false;
                    int tCnt = 0;

                    foreach (DataRow row in dt.Rows)
                    {
                        tCnt++;
                        if (tCnt > 7)
                            break;

                        o_jubsu_date = row["jubsu_date"].ToString();
                        o_jubsu_time = row["jubsu_time"].ToString();
                        o_jubsu_time2 = row["jubsu_time2"].ToString();

                        cmdText = @"  SELECT B.CPL_RESULT
                                            ,B.STANDARD_YN
                                            ,C.GUMSA_NAME
                                        FROM CPL0101 C,
                                             CPL3020 B,
                                             CPL2010 A
                                       WHERE A.HOSP_CODE     = :f_hosp_code
                                         AND B.HOSP_CODE     = A.HOSP_CODE
                                         AND C.HOSP_CODE     = A.HOSP_CODE
                                         AND A.BUNHO         = :f_bunho
                                         AND B.FKCPL2010     = A.PKCPL2010
                                         AND B.HANGMOG_CODE  = :f_hangmog_code
                                         AND A.PART_JUBSU_DATE   = :o_jubsu_date
                                         AND SUBSTR(A.PART_JUBSU_TIME,1,3) = :o_jubsu_time
                                         AND C.HANGMOG_CODE  = B.HANGMOG_CODE
                                         AND C.SPECIMEN_CODE = B.SPECIMEN_CODE
                                         AND C.EMERGENCY     = B.EMERGENCY  ";

                        bc.Add("o_jubsu_date", o_jubsu_date);
                        bc.Add("o_jubsu_time", o_jubsu_time);

                        DataTable dt2 = Service.ExecuteDataTable(cmdText, bc);

                        o_cpl_result = "";
                        o_standard_yn = "";
                        o_hangmog_name = "";

                        if (!TypeCheck.IsNull(dt2))
                        {
                            o_cpl_result = dt2.Rows[0]["cpl_result"].ToString();
                            o_standard_yn = dt2.Rows[0]["standard_yn"].ToString();
                            o_hangmog_name = dt2.Rows[0]["gumsa_name"].ToString();
                        }

                        this.laySigeyul.SetItemValue(rowNum, "result_date" + tCnt.ToString(), o_jubsu_time2);
                        this.laySigeyul.SetItemValue(rowNum, "result_" + tCnt.ToString(), o_cpl_result);
                        this.laySigeyul.SetItemValue(rowNum, "standard_yn_" + tCnt.ToString(), o_standard_yn);
                    }
                }
                else
                {
                    /*********** 결과일자 LOAD **********#1#
                    cmdText = @"  SELECT DISTINCT 
                                         TO_CHAR(A.PART_JUBSU_DATE, 'YYYY/MM/DD')   JUBSU_DATE
                                       , SUBSTR(A.PART_JUBSU_TIME,1,3)              JUBSU_TIME
                                       , TO_CHAR(A.PART_JUBSU_DATE,'YY.MM.DD')
                                         ||'('||SUBSTR(A.PART_JUBSU_TIME,1,2)||':'||SUBSTR(A.PART_JUBSU_TIME,3,1)||'0)' JUBSU_TIME2
                                    FROM CPLTEMP C,
                                         CPL3020 B,
                                         CPL2010 A
                                   WHERE A.HOSP_CODE     = :f_hosp_code
                                     AND B.HOSP_CODE     = A.HOSP_CODE
                                     AND C.HOSP_CODE     = A.HOSP_CODE
                                     AND A.BUNHO         = :f_bunho
                                     AND A.RESULT_DATE   IS NOT NULL
                                     AND TO_CHAR(A.PART_JUBSU_DATE,'YY.MM.DD')||'('||SUBSTR(A.PART_JUBSU_TIME,1,2)||':'||SUBSTR(A.PART_JUBSU_TIME,3,1)||'0)' > :f_base_date
                                     AND B.SPECIMEN_SER  = A.SPECIMEN_SER
                                     AND C.IP_ADDRESS    = :q_user_id
                                     AND C.JUNDAL_GUBUN  = 'XX'
                                     AND B.HANGMOG_CODE  = C.HANGMOG_CODE
                                   ORDER BY TO_CHAR(A.PART_JUBSU_DATE, 'YYYY/MM/DD') , SUBSTR(A.PART_JUBSU_TIME,1,3)";

                    DataTable dt = Service.ExecuteDataTable(cmdText, bc);
                    if (dt.Rows.Count < 1)
                        return false;
                    int tCnt = 0;

                    foreach (DataRow row in dt.Rows)
                    {
                        tCnt++;
                        if (tCnt > 7)
                            break;

                        o_jubsu_date = row["jubsu_date"].ToString();
                        o_jubsu_time = row["jubsu_time"].ToString();
                        o_jubsu_time2 = row["jubsu_time2"].ToString();

                        cmdText = @"  SELECT B.CPL_RESULT
                                            ,B.STANDARD_YN
                                            ,C.GUMSA_NAME
                                        FROM CPL0101 C,
                                             CPL3020 B,
                                             CPL2010 A
                                       WHERE A.HOSP_CODE     = :f_hosp_code
                                         AND B.HOSP_CODE     = A.HOSP_CODE
                                         AND C.HOSP_CODE     = A.HOSP_CODE
                                         AND A.BUNHO         = :f_bunho
                                         AND B.FKCPL2010     = A.PKCPL2010
                                         AND B.HANGMOG_CODE  = :f_hangmog_code
                                         AND A.PART_JUBSU_DATE   = :o_jubsu_date
                                         AND SUBSTR(A.PART_JUBSU_TIME,1,3) = :o_jubsu_time
                                         AND C.HANGMOG_CODE  = B.HANGMOG_CODE
                                         AND C.SPECIMEN_CODE = B.SPECIMEN_CODE
                                         AND C.EMERGENCY     = B.EMERGENCY    ";
                        bc.Add("o_jubsu_date", o_jubsu_date);
                        bc.Add("o_jubsu_time", o_jubsu_time);

                        DataTable dt2 = Service.ExecuteDataTable(cmdText, bc);

                        o_cpl_result = "";
                        o_standard_yn = "";
                        o_hangmog_name = "";

                        if (!TypeCheck.IsNull(dt2))
                        {
                            o_cpl_result = dt2.Rows[0]["cpl_result"].ToString();
                            o_standard_yn = dt2.Rows[0]["standard_yn"].ToString();
                            o_hangmog_name = dt2.Rows[0]["gumsa_name"].ToString();
                        }

                        this.laySigeyul.SetItemValue(rowNum, "result_date" + tCnt.ToString(), o_jubsu_time2);
                        this.laySigeyul.SetItemValue(rowNum, "result_" + tCnt.ToString(), o_cpl_result);
                        this.laySigeyul.SetItemValue(rowNum, "standard_yn_" + tCnt.ToString(), o_standard_yn);
                    }
                }
            }*/
            return true;
        }


		private void SigeyulQry(string gubun)
		{
            if (GetSigeyulData())
			{
				this.lineTable.Reset();
				//데이터테이블에 일자/일시를 셋팅할 컬럼
				lineTable.Columns.Add("Day", typeof(string));
		
				this.chartLine.Series.Clear();
				this.chartLine.DataSource = null;

				//큰 결과 값
				double maxResult = 0;
				
				if ( gubun == "pre" )
				{
					layPreSigeyul.Reset();
					for (int i=0; i<this.laySigeyul.RowCount; i++) 
					{
						//이전조회시 결과 일자 뒤집기
						int rowNum = layPreSigeyul.InsertRow(i);
                        layPreSigeyul.SetItemValue(rowNum, "gumsa_name", laySigeyul.GetItemString(i, "gumsa_name"));
                        layPreSigeyul.SetItemValue(rowNum, "result_date1", laySigeyul.GetItemString(i, "result_date7"));
                        layPreSigeyul.SetItemValue(rowNum, "result_1", laySigeyul.GetItemString(i, "result_7"));
                        layPreSigeyul.SetItemValue(rowNum, "standard_yn_1", laySigeyul.GetItemString(i, "standard_yn_7"));
                        layPreSigeyul.SetItemValue(rowNum, "result_date2", laySigeyul.GetItemString(i, "result_date6"));
                        layPreSigeyul.SetItemValue(rowNum, "result_2", laySigeyul.GetItemString(i, "result_6"));
                        layPreSigeyul.SetItemValue(rowNum, "standard_yn_2", laySigeyul.GetItemString(i, "standard_yn_6"));
                        layPreSigeyul.SetItemValue(rowNum, "result_date3", laySigeyul.GetItemString(i, "result_date5"));
                        layPreSigeyul.SetItemValue(rowNum, "result_3", laySigeyul.GetItemString(i, "result_5"));
                        layPreSigeyul.SetItemValue(rowNum, "standard_yn_3", laySigeyul.GetItemString(i, "standard_yn_5"));
                        layPreSigeyul.SetItemValue(rowNum, "result_date4", laySigeyul.GetItemString(i, "result_date4"));
                        layPreSigeyul.SetItemValue(rowNum, "result_4", laySigeyul.GetItemString(i, "result_4"));
                        layPreSigeyul.SetItemValue(rowNum, "standard_yn_4", laySigeyul.GetItemString(i, "standard_yn_4"));
                        layPreSigeyul.SetItemValue(rowNum, "result_date5", laySigeyul.GetItemString(i, "result_date3"));
                        layPreSigeyul.SetItemValue(rowNum, "result_5", laySigeyul.GetItemString(i, "result_3"));
                        layPreSigeyul.SetItemValue(rowNum, "standard_yn_5", laySigeyul.GetItemString(i, "standard_yn_3"));
                        layPreSigeyul.SetItemValue(rowNum, "result_date6", laySigeyul.GetItemString(i, "result_date2"));
                        layPreSigeyul.SetItemValue(rowNum, "result_6", laySigeyul.GetItemString(i, "result_2"));
                        layPreSigeyul.SetItemValue(rowNum, "standard_yn_6", laySigeyul.GetItemString(i, "standard_yn_2"));
                        layPreSigeyul.SetItemValue(rowNum, "result_date7", laySigeyul.GetItemString(i, "result_date1"));
                        layPreSigeyul.SetItemValue(rowNum, "result_7", laySigeyul.GetItemString(i, "result_1"));
                        layPreSigeyul.SetItemValue(rowNum, "standard_yn_7", laySigeyul.GetItemString(i, "standard_yn_1"));
					}

					//데이터 그래프로 뿌리기
					for ( int i=0; i < layPreSigeyul.RowCount; i++ )
					{
						string col_gumsa_name = layPreSigeyul.GetItemString(i,"gumsa_name").Trim();

						Dundas.Charting.WinControl.Series series1 = new Dundas.Charting.WinControl.Series();
						series1.ChartType = "Line";
						series1.EmptyPointStyle.BorderStyle = Dundas.Charting.WinControl.ChartDashStyle.Dash;
						series1.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold);
						//series1.FontColor = series1.;//System.Drawing.Color.DarkOrange;//series1.MarkerColor;
						series1.MarkerSize = 6;
						series1.MarkerStyle = Dundas.Charting.WinControl.MarkerStyle.Square;
						series1.Name = col_gumsa_name;
						series1.ToolTip = "#VALY";
						series1.XValueType = Dundas.Charting.WinControl.ChartValueTypes.String;
						series1.YValueType = Dundas.Charting.WinControl.ChartValueTypes.Double;

						if (cbxResultVisible.Checked == true)
							series1.ShowLabelAsValue = true;

						this.chartLine.Series.Add(series1);

						chartLine.Series[col_gumsa_name].ValueMemberX = "Day";
						chartLine.Series[col_gumsa_name].ValueMembersY = col_gumsa_name;
						chartLine.Series[col_gumsa_name]["EmptyPointValue"] = "Zero";
			
						//chartLine의 DataSource를 LineTable로 구성(항목별 결과)
						lineTable.Columns.Add(col_gumsa_name, typeof(double));
						DataRow dtRow;
	
						string colname_date;
						string colname_result;
						
						for ( int j = 1; j <= 7; j++ )
						{
							colname_date = "result_date" + j.ToString();
							colname_result = "result_" + j.ToString();
							//새행 생성
							if ( i == 0 )
							{
                                dtRow = lineTable.NewRow();
								//데이터가 없으면 로우 생성안함
                                //try
                                //{
									string dtData = layPreSigeyul.GetItemString(i,colname_date).Replace("(","").Replace(")","").Replace(".","/");

                                    if (TypeCheck.IsNull(dtData))
                                        continue;
                                    DateTime dtTime = DateTime.Parse(dtData.Substring(0, 8) + " " + dtData.Substring(8));
									dtRow["Day"] = dtTime.ToString("yyyy-MM-dd HH:mm");
									//XMessageBox.Show(dtRow["Day"].ToString());
									if (TypeCheck.IsDouble(layPreSigeyul.GetItemString(i,colname_result)))
									{
										dtRow[col_gumsa_name] = layPreSigeyul.GetItemDouble(i,colname_result);
										maxResult = Math.Max(maxResult, layPreSigeyul.GetItemDouble(i,colname_result));
									}
									else
										dtRow[col_gumsa_name] = 0;
								
									lineTable.Rows.Add(dtRow);
                                //}
                                //catch(Exception x)
                                //{
                                //    //XMessageBox.Show(x.Message + "----" + x.StackTrace);
                                //}
							}
								//기존행에 업데이트
							else
							{
								//기존에 데이터가 없으면 업데이트 없음
                                //try
                                //{
                                    if (j > lineTable.Rows.Count)
                                        continue;
									dtRow = lineTable.Rows[j-1];
									if (TypeCheck.IsDouble(layPreSigeyul.GetItemString(i,colname_result)))
									{
										dtRow[col_gumsa_name] = layPreSigeyul.GetItemDouble(i,colname_result);
										maxResult = Math.Max(maxResult, layPreSigeyul.GetItemDouble(i,colname_result));
									}
									else
										dtRow[col_gumsa_name] = 0;
                                //}
                                //catch (Exception x)
                                //{
                                //   // XMessageBox.Show(x.Message + "----" + x.StackTrace);
                                //}
							}
						}
					}
				}
				else
				{
					//데이터 그래프로 뿌리기
					for ( int i=0; i < laySigeyul.RowCount; i++ )
					{
						string col_gumsa_name = laySigeyul.GetItemString(i,"gumsa_name").Trim();

						Dundas.Charting.WinControl.Series series1 = new Dundas.Charting.WinControl.Series();
						series1.ChartType = "Line";
						series1.EmptyPointStyle.BorderStyle = Dundas.Charting.WinControl.ChartDashStyle.Dash;
						series1.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold);
						//series1.FontColor = series1.;//System.Drawing.Color.DarkOrange;//series1.MarkerColor;
						series1.MarkerSize = 6;
						series1.MarkerStyle = Dundas.Charting.WinControl.MarkerStyle.Square;
						series1.Name = col_gumsa_name;
						series1.ToolTip = "#VALY";
						series1.XValueType = Dundas.Charting.WinControl.ChartValueTypes.String;
						series1.YValueType = Dundas.Charting.WinControl.ChartValueTypes.Double;

						if (cbxResultVisible.Checked == true)
							series1.ShowLabelAsValue = true;

						this.chartLine.Series.Add(series1);

						chartLine.Series[col_gumsa_name].ValueMemberX = "Day";
						chartLine.Series[col_gumsa_name].ValueMembersY = col_gumsa_name;
						chartLine.Series[col_gumsa_name]["EmptyPointValue"] = "Zero";
			
						//chartLine의 DataSource를 LineTable로 구성(항목별 결과)
						lineTable.Columns.Add(col_gumsa_name, typeof(double));
						DataRow dtRow;
	
						string colname_date;
						string colname_result;
						
						for ( int j = 1; j <= 7; j++ )
						{
							colname_date = "result_date" + j.ToString();
							colname_result = "result_" + j.ToString();
							//새행 생성
							if ( i == 0 )
							{
                                dtRow = lineTable.NewRow();
								//데이터가 없으면 로우 생성안함
                                //try
                                //{
									string dtData = laySigeyul.GetItemString(i,colname_date).Replace("(","").Replace(")","").Replace(".","/");

                                    if (TypeCheck.IsNull(dtData))
                                        continue;
                                    DateTime dtTime = DateTime.Parse(dtData.Substring(0, 8) + " " + dtData.Substring(8));
									dtRow["Day"] = dtTime.ToString("yyyy-MM-dd HH:mm");
									//XMessageBox.Show(dtRow["Day"].ToString());
									if (TypeCheck.IsDouble(laySigeyul.GetItemString(i,colname_result)))
									{
										dtRow[col_gumsa_name] = laySigeyul.GetItemDouble(i,colname_result);
										maxResult = Math.Max(maxResult, laySigeyul.GetItemDouble(i,colname_result));
									}
									else
										dtRow[col_gumsa_name] = 0;
								
									lineTable.Rows.Add(dtRow);
                                //}
                                //catch (Exception x)
                                //{
                                //    //XMessageBox.Show(x.Message + "----" + x.StackTrace);
                                //}
							}
								//기존행에 업데이트
							else
							{
								//기존에 데이터가 없으면 업데이트 없음
                                //try
                                //{
                                    if (j > lineTable.Rows.Count)
                                        continue;
									dtRow = lineTable.Rows[j-1];
									if (TypeCheck.IsDouble(laySigeyul.GetItemString(i,colname_result)))
									{
										dtRow[col_gumsa_name] = laySigeyul.GetItemDouble(i,colname_result);
										maxResult = Math.Max(maxResult, laySigeyul.GetItemDouble(i,colname_result));
									}
									else
										dtRow[col_gumsa_name] = 0;
                                //}
                                //catch (Exception x)
                                //{
                                //    //XMessageBox.Show(x.Message + "----" + x.StackTrace);
                                //}
							}
						}
					}
				}
				lineTable.AcceptChanges();

				try
				{
					//값을 조회하여 MAX값보다 조금 크게 마진 적용하여 설정해야함(50단위)
					maxResult = maxResult + maxResult/20 + 1;
					chartLine.ChartAreas["Default"].AxisY.Maximum = maxResult;
					this.chartLine.DataSource = lineTable;
					this.chartLine.DataBind();
				}
				catch(Exception ex)
				{
					//https://sofiamedix.atlassian.net/browse/MED-10610
                    //XMessageBox.Show(ex.Message);
                    //XMessageBox.Show(ex.StackTrace);
				}
			}
			else
			{
                if(Service.ErrFullMsg != "")
                    XMessageBox.Show(Service.ErrMsg);
			}
		}
		#endregion

		#region 이전 버튼 클릭
		private void btnPre_Click(object sender, System.EventArgs e)
		{
            //if ( this.laySigeyul.RowCount == 0 )
            //    return;
            if (TypeCheck.IsNull(this.laySigeyul.GetItemString(0, "result_date1")))
            {
                for (int i = 0; i < this.grdSigeyul.RowCount; i++)
                {
                    this.grdSigeyul.SetItemValue(i, "gubun", "0");
                    this.grdSigeyul.SetItemValue(i, "base_date", "");
                }
                SigeyulQry("post");
                return;
            }

			for ( int i=0; i < this.grdSigeyul.RowCount; i++ )
			{
				this.grdSigeyul.SetItemValue(i,"gubun","1");
				string col_name = "result_date";
				for(int k=7; k>=1; k--)
				{
					col_name = "result_date" + k.ToString();
					if (laySigeyul.GetItemString(i,col_name) != "")
						break;
				}
				this.grdSigeyul.SetItemValue(i,"base_date",this.laySigeyul.GetItemString(i,col_name));
			}
			SigeyulQry("pre");
		}
		#endregion

		#region 다음 버튼 클릭
		private void btnNext_Click(object sender, System.EventArgs e)
		{
            //if ( this.laySigeyul.RowCount == 0 )
            //    return;
            if (TypeCheck.IsNull(this.laySigeyul.GetItemString(0, "result_date1")))
            {
                for (int i = 0; i < this.grdSigeyul.RowCount; i++)
                {
                    this.grdSigeyul.SetItemValue(i, "gubun", "0");
                    this.grdSigeyul.SetItemValue(i, "base_date", "");
                }
                SigeyulQry("pre");
                return;
            }
			
			for ( int i=0; i < this.grdSigeyul.RowCount; i++ )
			{
				this.grdSigeyul.SetItemValue(i,"gubun","2");
				string col_name = "result_date";
				for(int k=7; k>=1; k--)
				{
					col_name = "result_date" + k.ToString();
					if (laySigeyul.GetItemString(i,col_name) != "")
						break;
				}
				this.grdSigeyul.SetItemValue(i,"base_date",this.laySigeyul.GetItemString(i,col_name));
				//this.grdSigeyul.SetItemValue(i,"base_date",this.laySigeyul.GetItemString(i,"result_date7"));
			}
			SigeyulQry("post");
		}
		#endregion

		#region 숫자보여주기
		private void btnNumVisible_Click(object sender, System.EventArgs e)
		{
			foreach ( Dundas.Charting.WinControl.Series series in chartLine.Series )
			{
				if ( series.ShowLabelAsValue == true )
					series.ShowLabelAsValue = false;
				else
					series.ShowLabelAsValue = true;
			}
		}
		#endregion

		#region 3D로 보여주시
		private void cbxLine3D_CheckedChanged(object sender, System.EventArgs e)
		{
			//2D, 3D 변형
			if (cbxLine3D.Checked)
			{
				//DataSource가 없으면 return
				if (chartLine.DataSource == null) return;

				chartLine.ChartAreas["Default"].Area3DStyle.Enable3D = true;
				//TrackBar visible
				tbLineX.Visible = true;
				tbLineY.Visible = true;
				btnLineBase.Visible = true;
			}
			else
			{
				chartLine.ChartAreas["Default"].Area3DStyle.Enable3D = false;
				//TrackBar visible
				tbLineX.Visible = false;
				tbLineY.Visible = false;
				btnLineBase.Visible = false;
			}
		}
		#endregion

		#region 기본정보로 셋팅
		private void btnLineBase_Click(object sender, System.EventArgs e)
		{
			//기본 Angle 설정 (30, 30)
			tbLineX.Value = 30;
			tbLineY.Value = 30;	
		}
		#endregion

		#region X,Y Line 벨류 체인지
		private void tbLineX_ValueChanged(object sender, System.EventArgs e)
		{
			chartLine.ChartAreas["Default"].Area3DStyle.XAngle = tbLineX.Value;
		}

		private void tbLineY_ValueChanged(object sender, System.EventArgs e)
		{
			chartLine.ChartAreas["Default"].Area3DStyle.YAngle = tbLineY.Value;
		}
		#endregion

		#region 결과보여주기
		private void cbxResultVisible_CheckedChanged(object sender, System.EventArgs e)
		{
			if (cbxResultVisible.Checked == true)
			{
				foreach ( Dundas.Charting.WinControl.Series series in chartLine.Series )
				{
					series.ShowLabelAsValue = true;
				}
			}
			else
			{
				foreach ( Dundas.Charting.WinControl.Series series in chartLine.Series )
				{
					series.ShowLabelAsValue = false;
				}
			}
		}
		#endregion

		#endregion

		#region 그래프 입력 그리드 설정 Method
		public void SetGraph(IHIS.Framework.XEditGrid arGrid)
		{
//			try
//			{
				this.grdSigeyul = arGrid;

                //dsvSigeyul.MInputLayout = grdSigeyul;

				for ( int i=0; i < this.grdSigeyul.RowCount; i++ )
				{
					this.grdSigeyul.SetItemValue(i,"gubun","1");
					string base_date = EnvironInfo.GetSysDate().ToString("yy.MM.dd") + "(24:00)";
					this.grdSigeyul.SetItemValue(i,"base_date",base_date);
				}
				SigeyulQry("pre");
//			}
//			catch(Exception ex)
//			{
//				XMessageBox.Show(ex.StackTrace);
//			}
		}
		
		public void SetGraph(string aBunho, string aGroupHangmog)
		{
            string querySQL = @"SELECT MIN(:f_bunho)
                                     , A.SUB_HANGMOG_CODE
                                     , MIN(B.GUMSA_NAME)
                                  FROM CPL0101 B
                                     , CPL0106 A
                                 WHERE A.HOSP_CODE      = :f_hosp_code
                                   AND B.HOSP_CODE      = A.HOSP_CODE
                                   AND A.HANGMOG_CODE   = :f_group_hangmog
                                   AND B.HANGMOG_CODE   = A.SUB_HANGMOG_CODE
                                   AND B.SPECIMEN_CODE  = A.SUB_SPECIMEN_CODE
                                   AND B.EMERGENCY      = A.SUB_EMERGENCY
                                 GROUP BY A.SUB_HANGMOG_CODE , B.SERIAL
                                 ORDER BY B.SERIAL
                                 --ORDER BY A.SUB_HANGMOG_CODE";

            string querySQL1 = @"SELECT :f_bunho  BUNHO
                                         , HANGMOG_CODE
                                         , GUMSA_NAME
                                      FROM CPL0101
                                     WHERE HOSP_CODE    = :f_hosp_code
                                       AND HANGMOG_CODE = :f_group_hangmog
                                       AND ROWNUM       = 1
                                     ORDER BY SERIAL ";

			try
			{
                this.grdSigeyul.ParamList = new List<string>(new String[] { "f_bunho", "f_group_hangmog" });
//                this.grdSigeyul.QuerySQL = querySQL;

                this.grdSigeyul.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                this.grdSigeyul.SetBindVarValue("f_bunho", aBunho);
                this.grdSigeyul.SetBindVarValue("f_group_hangmog", aGroupHangmog);
                this.grdSigeyul.ExecuteQuery = ExecuteQueryGrdSigeyul1;
                this.grdSigeyul.QueryLayout(true);

                if (this.grdSigeyul.RowCount <= 0)
                {
//                    this.grdSigeyul.QuerySQL = querySQL1;
                    this.grdSigeyul.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                    this.grdSigeyul.SetBindVarValue("f_bunho", aBunho);
                    this.grdSigeyul.SetBindVarValue("f_group_hangmog", aGroupHangmog);
                    this.grdSigeyul.ExecuteQuery = ExecuteQueryGrdSigeyul2;
                    this.grdSigeyul.QueryLayout(true);
//                    this.grdSigeyul.QuerySQL = querySQL; 
                    this.grdSigeyul.ExecuteQuery = ExecuteQueryGrdSigeyul1;
                    
                }


				//조회 아웃풋 설정
                //dsvSigeyul.MInputLayout = grdSigeyul;

				for ( int i=0; i < this.grdSigeyul.RowCount; i++ )
				{
					this.grdSigeyul.SetItemValue(i,"gubun","1");
					string base_date = EnvironInfo.GetSysDate().ToString("yy.MM.dd") + "(24:00)";
					this.grdSigeyul.SetItemValue(i,"base_date",base_date);
				}
				SigeyulQry("pre");
			}
			catch(Exception ex)
			{
				//https://sofiamedix.atlassian.net/browse/MED-10610
                //XMessageBox.Show(ex.StackTrace);
			}
		}
		#endregion

        #region connect to cloud
        /// <summary>
        /// ExecuteQueryGrdSigeyul
        /// </summary>
        /// <param name="var"></param>
        /// <returns></returns>
        private IList<object[]> ExecuteQueryGrdSigeyul1(BindVarCollection var)
        {
            IList<object[]> listObject = new List<object[]>();
            MultiResultViewGrdSigeyul1Args args = new MultiResultViewGrdSigeyul1Args();
            args.Bunho = var["f_bunho"].VarValue;
            args.GroupHangmog = var["f_group_hangmog"].VarValue;
            MultiResultViewGrdSigeyulResult result =
                CloudService.Instance.Submit<MultiResultViewGrdSigeyulResult, MultiResultViewGrdSigeyul1Args>(args);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                listObject = CreateListObjectGrdSigeyul(result.GrdSigeyulInfo);
            }
            return listObject;
        }

        /// <summary>
        /// ExecuteQueryGrdSigeyul
        /// </summary>
        /// <param name="var"></param>
        /// <returns></returns>
        private IList<object[]> ExecuteQueryGrdSigeyul2(BindVarCollection var)
        {
            IList<object[]> listObject = new List<object[]>();
            MultiResultViewGrdSigeyul2Args args = new MultiResultViewGrdSigeyul2Args();
            args.Bunho = var["f_bunho"].VarValue;
            args.GroupHangmog = var["f_group_hangmog"].VarValue;
            MultiResultViewGrdSigeyulResult result =
                CloudService.Instance.Submit<MultiResultViewGrdSigeyulResult, MultiResultViewGrdSigeyul2Args>(args);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                listObject = CreateListObjectGrdSigeyul(result.GrdSigeyulInfo);
            }
            return listObject;
        }

        /// <summary>
        /// CreateListObjectGrdSigeyul
        /// </summary>
        /// <param name="lstGrdSigeyulInfo"></param>
        /// <returns></returns>
        private IList<object[]> CreateListObjectGrdSigeyul(List<MultiResultViewGrdSigeyulInfo> lstGrdSigeyulInfo)
        {
            IList<object[]> listObject = new List<object[]>();
            if (lstGrdSigeyulInfo != null && lstGrdSigeyulInfo.Count > 0)
            {
                foreach (MultiResultViewGrdSigeyulInfo info in lstGrdSigeyulInfo)
                {
                    listObject.Add(new object[]
	                {
	                    info.Bunho,
                        info.HangmogCode, 
                        info.GumsaName
	                });
                }
            }
            return listObject;
        }

        /// <summary>
        /// CreateListGrdSigeyulItem
        /// </summary>
        /// <returns></returns>
        private List<MultiResultViewGrdSigeyulInfo> CreateListGrdSigeyulItem()
        {
            List<MultiResultViewGrdSigeyulInfo> lstResultViewGrdSigeyulInfo = new List<MultiResultViewGrdSigeyulInfo>();
            for (int i = 0; i < grdSigeyul.RowCount; i++)
            {
                MultiResultViewGrdSigeyulInfo sigeyulInfo = new MultiResultViewGrdSigeyulInfo();
                sigeyulInfo.Bunho = this.grdSigeyul.GetItemString(i, "bunho");
                sigeyulInfo.HangmogCode = this.grdSigeyul.GetItemString(i, "hangmog_code");
                sigeyulInfo.GumsaName = this.grdSigeyul.GetItemString(i, "hangmog_name");
                sigeyulInfo.Gubun = this.grdSigeyul.GetItemString(i, "gubun");
                sigeyulInfo.BaseDate = this.grdSigeyul.GetItemString(i, "base_date");

                lstResultViewGrdSigeyulInfo.Add(sigeyulInfo);
            }
            return lstResultViewGrdSigeyulInfo;
        }
        #endregion
    }
}
