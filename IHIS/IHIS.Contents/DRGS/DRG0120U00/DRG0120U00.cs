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
using IHIS.CloudConnector.Contracts.Arguments.Drgs;
using IHIS.CloudConnector.Contracts.Arguments.Nuro;
using IHIS.CloudConnector.Contracts.Models.Drgs;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.Drgs;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.CloudConnector.Utility;
using IHIS.Framework;
using IHIS.DRGS.Properties;
using IHIS.CloudConnector.Contracts.Arguments.Adma;
using IHIS.CloudConnector.Contracts.Results.Adma;

#endregion

namespace IHIS.DRGS
{
	/// <summary>
	/// DRG0120U00에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class DRG0120U00 : IHIS.Framework.XScreen
	{
		private IHIS.Framework.XPanel pnlBottom;
		private IHIS.Framework.XButtonList xButtonList1;
		private IHIS.Framework.XTabControl tabDRG0120;
		private IHIS.X.Magic.Controls.TabPage tabPage1;
		private IHIS.X.Magic.Controls.TabPage tabPage2;
		private IHIS.Framework.XPanel xPanel1;
		private IHIS.Framework.XEditGrid grdDrg0120;
		private IHIS.Framework.XEditGridCell xEditGridCell1;
		private IHIS.Framework.XEditGridCell xEditGridCell2;
		private IHIS.Framework.XEditGridCell xEditGridCell3;
		private IHIS.Framework.XEditGridCell xEditGridCell4;
		private IHIS.Framework.XEditGridCell xEditGridCell5;
		private IHIS.Framework.XEditGridCell xEditGridCell6;
		private IHIS.Framework.XEditGridCell xEditGridCell7;
		private IHIS.Framework.XEditGridCell xEditGridCell8;
		private IHIS.Framework.XEditGridCell xEditGridCell9;
		private IHIS.Framework.XEditGridCell xEditGridCell10;
		private IHIS.Framework.XEditGridCell xEditGridCell11;
		private IHIS.Framework.XEditGridCell xEditGridCell12;
		private IHIS.Framework.XEditGridCell xEditGridCell13;
		private IHIS.Framework.XEditGridCell xEditGridCell14;
		private IHIS.Framework.XEditGridCell xEditGridCell15;
		private IHIS.Framework.XEditGridCell xEditGridCell16;
		private IHIS.Framework.XEditGridCell xEditGridCell17;
		private IHIS.Framework.XEditGridCell xEditGridCell18;
		private IHIS.Framework.XEditGridCell xEditGridCell19;
		private IHIS.Framework.XEditGridCell xEditGridCell20;
		private IHIS.Framework.XPanel xPanel2;
		private IHIS.Framework.XEditGridCell xEditGridCell21;
		private IHIS.Framework.XEditGridCell xEditGridCell22;
		private IHIS.Framework.XEditGridCell xEditGridCell23;
		private IHIS.Framework.XEditGridCell xEditGridCell24;
		private IHIS.Framework.XEditGridCell xEditGridCell25;
		private IHIS.Framework.XEditGridCell xEditGridCell26;
		private IHIS.Framework.XEditGridCell xEditGridCell27;
		private IHIS.Framework.XEditGridCell xEditGridCell28;
		private IHIS.Framework.XEditGridCell xEditGridCell29;
		private IHIS.Framework.XEditGridCell xEditGridCell30;
		private IHIS.Framework.XEditGridCell xEditGridCell31;
		private IHIS.Framework.XEditGridCell xEditGridCell32;
		private IHIS.Framework.XEditGridCell xEditGridCell33;
		private IHIS.Framework.XEditGridCell xEditGridCell34;
		private IHIS.Framework.XEditGridCell xEditGridCell35;
		private IHIS.Framework.XEditGridCell xEditGridCell36;
		private IHIS.Framework.XEditGridCell xEditGridCell37;
		private IHIS.Framework.XEditGridCell xEditGridCell38;
		private IHIS.Framework.XEditGridCell xEditGridCell39;
		private IHIS.Framework.XEditGridCell xEditGridCell40;
		private IHIS.Framework.XEditGrid grdDrg0120_1;
        private IHIS.Framework.XButton btnExcel;
		private IHIS.Framework.XEditGridCell xEditGridCell41;
		private IHIS.Framework.XEditGridCell xEditGridCell42;
		private IHIS.Framework.XEditGridCell xEditGridCell43;
		private IHIS.Framework.XEditGridCell xEditGridCell44;
		private IHIS.Framework.XEditGridCell xEditGridCell45;
		private IHIS.Framework.XEditGridCell xEditGridCell46;
		private IHIS.Framework.XEditGridCell xEditGridCell47;
		private IHIS.Framework.XEditGridCell xEditGridCell48;
		private IHIS.Framework.XEditGridCell xEditGridCell49;
		private IHIS.Framework.XEditGridCell xEditGridCell50;
		private IHIS.Framework.XEditGridCell xEditGridCell51;
		private IHIS.Framework.XEditGrid grdNaebog;
		private IHIS.Framework.XEditGrid grdYoiyong;
		private IHIS.Framework.XEditGridCell xEditGridCell52;
		private IHIS.Framework.XEditGridCell xEditGridCell53;
		private IHIS.Framework.XEditGridCell xEditGridCell54;
		private IHIS.Framework.XEditGridCell xEditGridCell55;
		private IHIS.Framework.XEditGridCell xEditGridCell56;
		private IHIS.Framework.XEditGridCell xEditGridCell57;
		private IHIS.Framework.XEditGridCell xEditGridCell58;
        private XEditGridCell xEditGridCell59;
        private XEditGridCell xEditGridCell61;
        private XEditGridCell xEditGridCell60;
        private XEditGridCell xEditGridCell62;
        private XEditGridCell xEditGridCell63;
        private XEditGridCell xEditGridCell64;
        private XEditGridCell xEditGridCell65;
        private XEditGridCell xEditGridCell66;
        private XEditGridCell xEditGridCell67;
        private XEditGridCell xEditGridCell68;
        private XEditGridCell xEditGridCell69;
        private XEditGridCell xEditGridCell70;
        private XEditGridCell xEditGridCell71;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

	    private DRG0120U00ComboListResult comboListResult;
        private XPanel pnlTop;
        private XDisplayBox dbxHospitalNm;
        private XFindBox fbxHospitalID;
        private XLabel xLabel4;
        private XFindWorker fwkHospitalID;

	    private bool unchanged = false;

		public DRG0120U00()
		{
//		    InitializeComboListItem();

        	/* SavePerformer 생성 */
	        // 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();

            //저장 수행자 Set
            //this.grdDrg0120.SavePerformer = new XSavePerformer(this);
            //this.grdDrg0120_1.SavePerformer = this.grdDrg0120.SavePerformer;
            //저장 Layout List Set
            this.SaveLayoutList.Add(this.grdDrg0120);
            this.SaveLayoutList.Add(this.grdDrg0120_1);

            this.grdDrg0120.ParamList = new List<string>(new String[] { "f_bunryu1" });
            this.grdDrg0120_1.ParamList = new List<string>(new String[] { "f_bunryu1" });

		    this.grdDrg0120.ExecuteQuery = LoadDataGrdDrg0120;
		    this.grdDrg0120_1.ExecuteQuery = LoadDataGrdDrg0120_1;
		    this.grdNaebog.ExecuteQuery = LoadDataGrdNaebog;
		    this.grdYoiyong.ExecuteQuery = LoadDataGrdYoiyong;

            // MED-14155
            this.ApplyMultiHospital();
		}

	    private IList<object[]> LoadDataGrdYoiyong(BindVarCollection varlist)
	    {
	        IList<object[]> dataList = new List<object[]>();
            DRG0120U00GrdYoiyongArgs args = new DRG0120U00GrdYoiyongArgs();
            args.HospCode = this.mHospCode;
	        DRG0120U00GrdYoiyongResult result =
	            CloudService.Instance.Submit<DRG0120U00GrdYoiyongResult, DRG0120U00GrdYoiyongArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                List<DRG0120U00Grd0120Item3Info> grdList = result.GrdYoiyongList;
                if (grdList != null && grdList.Count > 0)
                {
                    foreach (DRG0120U00Grd0120Item3Info info in grdList)
                    {
                        dataList.Add(new object[]
                        {
                            info.Bunryu1Name,
                            info.BogyongCode,
                            info.BogyongName,
                            info.Dv,
                            info.Banghyang,
                            info.Buwi,
                            info.Chiryo
                                 
                        });
                    }
                }
            }
            else
            {
                //XMessageBox.Show("Query grdDrg0120_1: " + result.ExecutionStatus.ToString());
            }
	        return dataList;
	    }

	    private IList<object[]> LoadDataGrdNaebog(BindVarCollection varlist)
	    {
            IList<object[]> dataList = new List<object[]>();
            DRG0120U00GrdNaebogArgs args = new DRG0120U00GrdNaebogArgs();
            args.HospCode = this.mHospCode;
            DRG0120U00GrdNaebogResult result =
                CloudService.Instance.Submit<DRG0120U00GrdNaebogResult, DRG0120U00GrdNaebogArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                List<DRG0120U00Grd0120Item2Info> grdList = result.GrdNaebogList;
                if (grdList != null && grdList.Count > 0)
                {
                    foreach (DRG0120U00Grd0120Item2Info info in grdList)
                    {
                        dataList.Add(new object[]
                        {
                            info.Bunryu1Name,   
                            info.BogyongCode,   
                            info.BogyongName,   
                            info.Dv,   
                            info.BogyongGubun,   
                            info.DonbogYn,   
                            info.AfWake,   
                            info.Morning,   
                            info.Afternoon,   
                            info.Evening,   
                            info.Night
                                 
                        });
                    }
                }
            }
            else
            {
                //XMessageBox.Show("Query grdDrg0120_1: " + result.ExecutionStatus.ToString());
            }

            return dataList;
	    }

	    /// <summary>
        /// get data for grdDrg0120_1
        /// </summary>
        /// <param name="varlist"></param>
        /// <returns></returns>
	    private IList<object[]> LoadDataGrdDrg0120_1(BindVarCollection varlist)
	    {
            IList<object[]> dataList = new List<object[]>();
            DRG0120U00GrdDrg0120Item1Args args = new DRG0120U00GrdDrg0120Item1Args(varlist["f_bunryu1"].VarValue, this.mHospCode);
            DRG0120U00GrdDrg0120Item1Result result =
                CloudService.Instance.Submit<DRG0120U00GrdDrg0120Item1Result, DRG0120U00GrdDrg0120Item1Args>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                List<DRG0120U00GrdDrg0120Item1Info> grdList = result.ListInfo;
                if (grdList != null && grdList.Count > 0)
                {
                    foreach (DRG0120U00GrdDrg0120Item1Info info in grdList)
                    {
                        dataList.Add(new object[]
                        {
                            info.BogyongCode      ,     
                            info.BogyongName      ,     
                            info.Pattern          ,      
                            info.BogyongGubun     ,     
                            info.DrgGrp           ,     
                            info.BogyongName2     ,    
                            info.BogyongGubunDefault,    
                            info.PrtGubun         ,     
                            info.Bunryu1          ,      
                            info.BogyongCodeFull  ,    
                            info.SpBogyongYn      ,    
                            info.BlockGubun       ,     
                            info.Banghyang        ,                                                                                             
                            info.ChiryoGubun      ,     
                            info.DonbogYn         ,     
                            info.Pattern1         ,      
                            info.Pattern2         ,      
                            info.Pattern3         ,      
                            info.Pattern4         ,      
                            info.Pattern5             
                                 
                        });
                    }
                }
            }
            else
            {
                //XMessageBox.Show("Query grdDrg0120_1: " + result.ExecutionStatus.ToString());
            }

            return dataList;
	    }

	    /// <summary>
        /// get data for grdDrg0120
        /// </summary>
        /// <param name="varlist"></param>
        /// <returns></returns>
	    private IList<object[]> LoadDataGrdDrg0120(BindVarCollection varlist)
	    {
	        IList<object[]> dataList = new List<object[]>();
            DRG0120U00GrdDrg0120Args args = new DRG0120U00GrdDrg0120Args(varlist["f_bunryu1"].VarValue, this.mHospCode);
            DRG0120U00GrdDrg0120Result result =
                CloudService.Instance.Submit<DRG0120U00GrdDrg0120Result, DRG0120U00GrdDrg0120Args>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                List<DRG0120U00GrdDrg0120ItemInfo> grdList = result.ListInfo;
                if (grdList != null && grdList.Count > 0)
                {
                    foreach (DRG0120U00GrdDrg0120ItemInfo info in grdList)
                    {
                        dataList.Add(new object[]
                        {
                            info.BogyongCode      ,     
                            info.BogyongName      ,     
                            info.Pattern          ,      
                            info.BogyongGubun     ,     
                            info.DrgGrp           ,     
                            info.BogyongName2     ,    
                            info.BogyongGubunDefault,    
                            info.PrtGubun         ,     
                            info.Bunryu1          ,      
                            info.BogyongCodeFull  ,    
                            info.SpBogyongYn      ,    
                            info.BlockGubun       ,     
                            info.Banghyang        ,                                                                                             
                            info.ChiryoGubun      ,     
                            info.DonbogYn         ,     
                            info.Pattern1         ,      
                            info.Pattern2         ,      
                            info.Pattern3         ,      
                            info.Pattern4         ,      
                            info.Pattern5         ,      
                            info.BogyongJoFlag    ,    
                            info.BogyongJuFlag    ,    
                            info.BogyongSeokFlag  ,    
                            info.BogyongTime1Flag ,    
                            info.BogyongTime2Flag ,    
                            info.BogyongTime3Flag ,    
                            info.BogyongTime4Flag ,    
                            info.BogyongTime5Flag ,    
                            info.BogyongTime6Flag ,    
                            info.BogyongTime7Flag ,    
                            info.RowState            
                        });
                    }
                }
            }
            else
            {
                //XMessageBox.Show("Query grdDrg0120: " + result.ExecutionStatus.ToString());
            }

	        return dataList;
	    }

        /// <summary>
        /// Get data for all combo box
        /// </summary>
	    private void InitializeComboListItem()
	    {
	        DRG0120U00ComboListArgs args = new DRG0120U00ComboListArgs();
	        args.Param32 = "32";
	        args.Param33 = "33";
	        args.Param34 = "34";
	        args.Param35 = "35";
	        args.ParamUA = "UA";

            //comboListResult =
            //    CacheService.Instance.Get<DRG0120U00ComboListArgs, DRG0120U00ComboListResult>(
            //        Constants.CacheKeyCbo.CACHE_DRG0120U00_KEYS, args);
            comboListResult = CacheService.Instance.Get<DRG0120U00ComboListArgs, DRG0120U00ComboListResult>(args);
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

		[Browsable(false), DataBindable]
		public string gubun
		{
			get {return tabDRG0120.SelectedIndex.ToString();}
		}
		

		#region Designer generated code
		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다.
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DRG0120U00));
            this.pnlBottom = new IHIS.Framework.XPanel();
            this.grdYoiyong = new IHIS.Framework.XEditGrid();
            this.xEditGridCell52 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell53 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell54 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell55 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell56 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell57 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell58 = new IHIS.Framework.XEditGridCell();
            this.grdNaebog = new IHIS.Framework.XEditGrid();
            this.xEditGridCell41 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell42 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell43 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell44 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell45 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell46 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell47 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell48 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell49 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell50 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell51 = new IHIS.Framework.XEditGridCell();
            this.btnExcel = new IHIS.Framework.XButton();
            this.xButtonList1 = new IHIS.Framework.XButtonList();
            this.grdDrg0120 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell18 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell19 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell20 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell62 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell63 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell64 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell65 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell66 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell67 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell68 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell69 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell70 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell71 = new IHIS.Framework.XEditGridCell();
            this.tabDRG0120 = new IHIS.Framework.XTabControl();
            this.tabPage1 = new IHIS.X.Magic.Controls.TabPage();
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.tabPage2 = new IHIS.X.Magic.Controls.TabPage();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.grdDrg0120_1 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell21 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell22 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell23 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell24 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell25 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell26 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell27 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell28 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell29 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell30 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell31 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell32 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell33 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell34 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell35 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell36 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell37 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell38 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell39 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell40 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell59 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell60 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell61 = new IHIS.Framework.XEditGridCell();
            this.pnlTop = new IHIS.Framework.XPanel();
            this.dbxHospitalNm = new IHIS.Framework.XDisplayBox();
            this.fbxHospitalID = new IHIS.Framework.XFindBox();
            this.fwkHospitalID = new IHIS.Framework.XFindWorker();
            this.xLabel4 = new IHIS.Framework.XLabel();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdYoiyong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdNaebog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDrg0120)).BeginInit();
            this.tabDRG0120.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.xPanel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.xPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDrg0120_1)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.grdYoiyong);
            this.pnlBottom.Controls.Add(this.grdNaebog);
            this.pnlBottom.Controls.Add(this.btnExcel);
            this.pnlBottom.Controls.Add(this.xButtonList1);
            resources.ApplyResources(this.pnlBottom, "pnlBottom");
            this.pnlBottom.DrawBorder = true;
            this.pnlBottom.Name = "pnlBottom";
            // 
            // grdYoiyong
            // 
            this.grdYoiyong.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell52,
            this.xEditGridCell53,
            this.xEditGridCell54,
            this.xEditGridCell55,
            this.xEditGridCell56,
            this.xEditGridCell57,
            this.xEditGridCell58});
            this.grdYoiyong.ColPerLine = 7;
            this.grdYoiyong.Cols = 7;
            this.grdYoiyong.ExecuteQuery = null;
            this.grdYoiyong.FixedRows = 1;
            this.grdYoiyong.HeaderHeights.Add(20);
            resources.ApplyResources(this.grdYoiyong, "grdYoiyong");
            this.grdYoiyong.Name = "grdYoiyong";
            this.grdYoiyong.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdYoiyong.ParamList")));
            this.grdYoiyong.QuerySQL = resources.GetString("grdYoiyong.QuerySQL");
            this.grdYoiyong.Rows = 2;
            this.grdYoiyong.ToolTipActive = true;
            this.grdYoiyong.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdYoiyong_QueryStarting);
            this.grdYoiyong.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.Excel_QueryEnd);
            // 
            // xEditGridCell52
            // 
            this.xEditGridCell52.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell52.CellName = "bunryu1_name";
            this.xEditGridCell52.ExecuteQuery = null;
            this.xEditGridCell52.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell52, "xEditGridCell52");
            this.xEditGridCell52.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell53
            // 
            this.xEditGridCell53.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell53.CellName = "bogyong_code";
            this.xEditGridCell53.Col = 1;
            this.xEditGridCell53.ExecuteQuery = null;
            this.xEditGridCell53.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell53, "xEditGridCell53");
            this.xEditGridCell53.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell54
            // 
            this.xEditGridCell54.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell54.CellName = "bogyong_name";
            this.xEditGridCell54.Col = 2;
            this.xEditGridCell54.ExecuteQuery = null;
            this.xEditGridCell54.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell54, "xEditGridCell54");
            this.xEditGridCell54.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell55
            // 
            this.xEditGridCell55.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell55.CellName = "dv";
            this.xEditGridCell55.Col = 3;
            this.xEditGridCell55.ExecuteQuery = null;
            this.xEditGridCell55.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell55, "xEditGridCell55");
            this.xEditGridCell55.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell56
            // 
            this.xEditGridCell56.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell56.CellName = "banghyang";
            this.xEditGridCell56.Col = 4;
            this.xEditGridCell56.ExecuteQuery = null;
            this.xEditGridCell56.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell56, "xEditGridCell56");
            this.xEditGridCell56.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell57
            // 
            this.xEditGridCell57.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell57.CellName = "buwi";
            this.xEditGridCell57.Col = 5;
            this.xEditGridCell57.ExecuteQuery = null;
            this.xEditGridCell57.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell57, "xEditGridCell57");
            this.xEditGridCell57.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell58
            // 
            this.xEditGridCell58.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell58.CellName = "chiryo";
            this.xEditGridCell58.Col = 6;
            this.xEditGridCell58.ExecuteQuery = null;
            this.xEditGridCell58.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell58, "xEditGridCell58");
            this.xEditGridCell58.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // grdNaebog
            // 
            this.grdNaebog.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell41,
            this.xEditGridCell42,
            this.xEditGridCell43,
            this.xEditGridCell44,
            this.xEditGridCell45,
            this.xEditGridCell46,
            this.xEditGridCell47,
            this.xEditGridCell48,
            this.xEditGridCell49,
            this.xEditGridCell50,
            this.xEditGridCell51});
            this.grdNaebog.ColPerLine = 11;
            this.grdNaebog.Cols = 11;
            this.grdNaebog.ExecuteQuery = null;
            this.grdNaebog.FixedRows = 1;
            this.grdNaebog.HeaderHeights.Add(21);
            resources.ApplyResources(this.grdNaebog, "grdNaebog");
            this.grdNaebog.Name = "grdNaebog";
            this.grdNaebog.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdNaebog.ParamList")));
            this.grdNaebog.QuerySQL = resources.GetString("grdNaebog.QuerySQL");
            this.grdNaebog.Rows = 2;
            this.grdNaebog.ToolTipActive = true;
            this.grdNaebog.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdNaebog_QueryStarting);
            this.grdNaebog.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.Excel_QueryEnd);
            // 
            // xEditGridCell41
            // 
            this.xEditGridCell41.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell41.CellName = "bunryu1_name";
            this.xEditGridCell41.ExecuteQuery = null;
            this.xEditGridCell41.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell41, "xEditGridCell41");
            this.xEditGridCell41.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell42
            // 
            this.xEditGridCell42.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell42.CellName = "bogyong_code";
            this.xEditGridCell42.Col = 1;
            this.xEditGridCell42.ExecuteQuery = null;
            this.xEditGridCell42.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell42, "xEditGridCell42");
            this.xEditGridCell42.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell43
            // 
            this.xEditGridCell43.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell43.CellName = "bogyong_name";
            this.xEditGridCell43.Col = 2;
            this.xEditGridCell43.ExecuteQuery = null;
            this.xEditGridCell43.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell43, "xEditGridCell43");
            this.xEditGridCell43.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell44
            // 
            this.xEditGridCell44.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell44.CellName = "dv";
            this.xEditGridCell44.Col = 3;
            this.xEditGridCell44.ExecuteQuery = null;
            this.xEditGridCell44.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell44, "xEditGridCell44");
            this.xEditGridCell44.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell45
            // 
            this.xEditGridCell45.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell45.CellName = "bogyong_gubun";
            this.xEditGridCell45.Col = 4;
            this.xEditGridCell45.ExecuteQuery = null;
            this.xEditGridCell45.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell45, "xEditGridCell45");
            this.xEditGridCell45.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell46
            // 
            this.xEditGridCell46.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell46.CellName = "donbog_yn";
            this.xEditGridCell46.Col = 5;
            this.xEditGridCell46.ExecuteQuery = null;
            this.xEditGridCell46.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell46, "xEditGridCell46");
            this.xEditGridCell46.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell47
            // 
            this.xEditGridCell47.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell47.CellName = "af_wake";
            this.xEditGridCell47.Col = 6;
            this.xEditGridCell47.ExecuteQuery = null;
            this.xEditGridCell47.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell47, "xEditGridCell47");
            this.xEditGridCell47.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell48
            // 
            this.xEditGridCell48.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell48.CellName = "morning";
            this.xEditGridCell48.Col = 7;
            this.xEditGridCell48.ExecuteQuery = null;
            this.xEditGridCell48.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell48, "xEditGridCell48");
            this.xEditGridCell48.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell49
            // 
            this.xEditGridCell49.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell49.CellName = "afternoon";
            this.xEditGridCell49.Col = 8;
            this.xEditGridCell49.ExecuteQuery = null;
            this.xEditGridCell49.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell49, "xEditGridCell49");
            this.xEditGridCell49.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell50
            // 
            this.xEditGridCell50.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell50.CellName = "evening";
            this.xEditGridCell50.Col = 9;
            this.xEditGridCell50.ExecuteQuery = null;
            this.xEditGridCell50.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell50, "xEditGridCell50");
            this.xEditGridCell50.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell51
            // 
            this.xEditGridCell51.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell51.CellName = "night";
            this.xEditGridCell51.Col = 10;
            this.xEditGridCell51.ExecuteQuery = null;
            this.xEditGridCell51.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell51, "xEditGridCell51");
            this.xEditGridCell51.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // btnExcel
            // 
            resources.ApplyResources(this.btnExcel, "btnExcel");
            this.btnExcel.Image = global::IHIS.DRGS.Properties.Resources.excel;
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Scheme = IHIS.Framework.XButtonSchemes.Green;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // xButtonList1
            // 
            resources.ApplyResources(this.xButtonList1, "xButtonList1");
            this.xButtonList1.Name = "xButtonList1";
            this.xButtonList1.PerformerType = IHIS.Framework.FunctionPerformerType.Entry;
            this.xButtonList1.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.xButtonList1_ButtonClick);
            // 
            // grdDrg0120
            // 
            this.grdDrg0120.CallerID = 'A';
            this.grdDrg0120.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell6,
            this.xEditGridCell7,
            this.xEditGridCell8,
            this.xEditGridCell9,
            this.xEditGridCell10,
            this.xEditGridCell11,
            this.xEditGridCell12,
            this.xEditGridCell13,
            this.xEditGridCell14,
            this.xEditGridCell15,
            this.xEditGridCell16,
            this.xEditGridCell17,
            this.xEditGridCell18,
            this.xEditGridCell19,
            this.xEditGridCell20,
            this.xEditGridCell62,
            this.xEditGridCell63,
            this.xEditGridCell64,
            this.xEditGridCell65,
            this.xEditGridCell66,
            this.xEditGridCell67,
            this.xEditGridCell68,
            this.xEditGridCell69,
            this.xEditGridCell70,
            this.xEditGridCell71});
            this.grdDrg0120.ColPerLine = 16;
            this.grdDrg0120.ColResizable = true;
            this.grdDrg0120.Cols = 17;
            resources.ApplyResources(this.grdDrg0120, "grdDrg0120");
            this.grdDrg0120.ExecuteQuery = null;
            this.grdDrg0120.FixedCols = 1;
            this.grdDrg0120.FixedRows = 1;
            this.grdDrg0120.FocusColumnName = "bogyong_code";
            this.grdDrg0120.HeaderHeights.Add(31);
            this.grdDrg0120.Name = "grdDrg0120";
            this.grdDrg0120.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdDrg0120.ParamList")));
            this.grdDrg0120.QuerySQL = resources.GetString("grdDrg0120.QuerySQL");
            this.grdDrg0120.RowHeaderVisible = true;
            this.grdDrg0120.Rows = 2;
            this.grdDrg0120.ToolTipActive = true;
            this.grdDrg0120.PreSaveLayout += new IHIS.Framework.GridRecordEventHandler(this.grdDrg0120_PreSaveLayout);
            this.grdDrg0120.ItemValueChanging += new IHIS.Framework.ItemValueChangingEventHandler(this.grdDrg0120_ItemValueChanging);
            this.grdDrg0120.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdDrg0120_GridColumnChanged);
            this.grdDrg0120.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdDrg0120_QueryStarting);
            this.grdDrg0120.PreEndInitializing += new System.EventHandler(this.grdDrg0120_PreEndInitializing);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell1.CellName = "bogyong_code";
            this.xEditGridCell1.CellWidth = 69;
            this.xEditGridCell1.Col = 1;
            this.xEditGridCell1.EnableSort = true;
            this.xEditGridCell1.ExecuteQuery = null;
            this.xEditGridCell1.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsUpdatable = false;
            this.xEditGridCell1.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell2.CellLen = 80;
            this.xEditGridCell2.CellName = "bogyong_name";
            this.xEditGridCell2.CellWidth = 239;
            this.xEditGridCell2.Col = 2;
            this.xEditGridCell2.EnableSort = true;
            this.xEditGridCell2.ExecuteQuery = null;
            this.xEditGridCell2.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell3.CellLen = 8;
            this.xEditGridCell3.CellName = "pattern";
            this.xEditGridCell3.CellWidth = 73;
            this.xEditGridCell3.Col = 6;
            this.xEditGridCell3.EnableSort = true;
            this.xEditGridCell3.ExecuteQuery = null;
            this.xEditGridCell3.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell4.CellLen = 2;
            this.xEditGridCell4.CellName = "bogyong_gubun";
            this.xEditGridCell4.CellWidth = 40;
            this.xEditGridCell4.Col = 3;
            this.xEditGridCell4.EnableSort = true;
            this.xEditGridCell4.ExecuteQuery = null;
            this.xEditGridCell4.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell5.CellLen = 1;
            this.xEditGridCell5.CellName = "drg_grp";
            this.xEditGridCell5.CellWidth = 55;
            this.xEditGridCell5.Col = -1;
            this.xEditGridCell5.EnableSort = true;
            this.xEditGridCell5.ExecuteQuery = null;
            this.xEditGridCell5.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.IsVisible = false;
            this.xEditGridCell5.Row = -1;
            this.xEditGridCell5.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell6.CellLen = 80;
            this.xEditGridCell6.CellName = "bogyong_name_2";
            this.xEditGridCell6.CellWidth = 182;
            this.xEditGridCell6.Col = -1;
            this.xEditGridCell6.EnableSort = true;
            this.xEditGridCell6.ExecuteQuery = null;
            this.xEditGridCell6.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.IsVisible = false;
            this.xEditGridCell6.Row = -1;
            this.xEditGridCell6.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell7.CellLen = 1;
            this.xEditGridCell7.CellName = "bogyong_gubun_default";
            this.xEditGridCell7.Col = -1;
            this.xEditGridCell7.ExecuteQuery = null;
            this.xEditGridCell7.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell7.IsVisible = false;
            this.xEditGridCell7.Row = -1;
            this.xEditGridCell7.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell8.CellLen = 1;
            this.xEditGridCell8.CellName = "prt_gubun";
            this.xEditGridCell8.CellWidth = 49;
            this.xEditGridCell8.Col = -1;
            this.xEditGridCell8.EnableSort = true;
            this.xEditGridCell8.ExecuteQuery = null;
            this.xEditGridCell8.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            this.xEditGridCell8.IsVisible = false;
            this.xEditGridCell8.Row = -1;
            this.xEditGridCell8.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell9.CellLen = 2;
            this.xEditGridCell9.CellName = "bunryu1";
            this.xEditGridCell9.CellWidth = 36;
            this.xEditGridCell9.Col = -1;
            this.xEditGridCell9.EnableSort = true;
            this.xEditGridCell9.ExecuteQuery = null;
            this.xEditGridCell9.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            this.xEditGridCell9.IsVisible = false;
            this.xEditGridCell9.Row = -1;
            this.xEditGridCell9.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell10.CellLen = 30;
            this.xEditGridCell10.CellName = "bogyong_code_full";
            this.xEditGridCell10.Col = -1;
            this.xEditGridCell10.ExecuteQuery = null;
            this.xEditGridCell10.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell10.IsVisible = false;
            this.xEditGridCell10.Row = -1;
            this.xEditGridCell10.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell11.CellLen = 1;
            this.xEditGridCell11.CellName = "sp_bogyong_yn";
            this.xEditGridCell11.CellWidth = 68;
            this.xEditGridCell11.Col = -1;
            this.xEditGridCell11.DictColumn = "SP_BOGYONG_YN";
            this.xEditGridCell11.EnableSort = true;
            this.xEditGridCell11.ExecuteQuery = null;
            this.xEditGridCell11.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell11, "xEditGridCell11");
            this.xEditGridCell11.IsVisible = false;
            this.xEditGridCell11.Row = -1;
            this.xEditGridCell11.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell12.CellName = "block_gubun";
            this.xEditGridCell12.CodeDisplay = false;
            this.xEditGridCell12.Col = -1;
            this.xEditGridCell12.ExecuteQuery = null;
            this.xEditGridCell12.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell12, "xEditGridCell12");
            this.xEditGridCell12.IsVisible = false;
            this.xEditGridCell12.MaxDropDownItems = 30;
            this.xEditGridCell12.Row = -1;
            this.xEditGridCell12.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell12.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell13.CellName = "banghyang";
            this.xEditGridCell13.CellWidth = 75;
            this.xEditGridCell13.CodeDisplay = false;
            this.xEditGridCell13.Col = 4;
            this.xEditGridCell13.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell13.ExecuteQuery = null;
            this.xEditGridCell13.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell13, "xEditGridCell13");
            this.xEditGridCell13.MaxDropDownItems = 30;
            this.xEditGridCell13.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell13.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.xEditGridCell13.UserSQL = resources.GetString("xEditGridCell13.UserSQL");
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell14.CellName = "chiryo_gubun";
            this.xEditGridCell14.CellWidth = 120;
            this.xEditGridCell14.CodeDisplay = false;
            this.xEditGridCell14.Col = -1;
            this.xEditGridCell14.ExecuteQuery = null;
            this.xEditGridCell14.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell14, "xEditGridCell14");
            this.xEditGridCell14.IsVisible = false;
            this.xEditGridCell14.MaxDropDownItems = 30;
            this.xEditGridCell14.Row = -1;
            this.xEditGridCell14.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell14.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell15.CellName = "donbog_yn";
            this.xEditGridCell15.CellWidth = 77;
            this.xEditGridCell15.Col = 5;
            this.xEditGridCell15.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell15.ExecuteQuery = null;
            this.xEditGridCell15.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell15, "xEditGridCell15");
            this.xEditGridCell15.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell16.CellName = "pattern1";
            this.xEditGridCell16.CellWidth = 30;
            this.xEditGridCell16.CheckedValue = "1";
            this.xEditGridCell16.Col = -1;
            this.xEditGridCell16.ExecuteQuery = null;
            this.xEditGridCell16.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell16, "xEditGridCell16");
            this.xEditGridCell16.IsVisible = false;
            this.xEditGridCell16.Row = -1;
            this.xEditGridCell16.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell16.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell16.UnCheckedValue = "0";
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell17.CellName = "pattern2";
            this.xEditGridCell17.CellWidth = 30;
            this.xEditGridCell17.CheckedValue = "1";
            this.xEditGridCell17.Col = -1;
            this.xEditGridCell17.ExecuteQuery = null;
            this.xEditGridCell17.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell17, "xEditGridCell17");
            this.xEditGridCell17.IsVisible = false;
            this.xEditGridCell17.Row = -1;
            this.xEditGridCell17.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell17.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell17.UnCheckedValue = "0";
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell18.CellName = "pattern3";
            this.xEditGridCell18.CellWidth = 30;
            this.xEditGridCell18.CheckedValue = "1";
            this.xEditGridCell18.Col = -1;
            this.xEditGridCell18.ExecuteQuery = null;
            this.xEditGridCell18.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell18, "xEditGridCell18");
            this.xEditGridCell18.IsVisible = false;
            this.xEditGridCell18.Row = -1;
            this.xEditGridCell18.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell18.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell18.UnCheckedValue = "0";
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell19.CellName = "pattern4";
            this.xEditGridCell19.CellWidth = 30;
            this.xEditGridCell19.CheckedValue = "1";
            this.xEditGridCell19.Col = -1;
            this.xEditGridCell19.ExecuteQuery = null;
            this.xEditGridCell19.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell19, "xEditGridCell19");
            this.xEditGridCell19.IsVisible = false;
            this.xEditGridCell19.Row = -1;
            this.xEditGridCell19.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell19.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell19.UnCheckedValue = "0";
            // 
            // xEditGridCell20
            // 
            this.xEditGridCell20.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell20.CellName = "pattern5";
            this.xEditGridCell20.CellWidth = 30;
            this.xEditGridCell20.CheckedValue = "1";
            this.xEditGridCell20.Col = -1;
            this.xEditGridCell20.ExecuteQuery = null;
            this.xEditGridCell20.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell20, "xEditGridCell20");
            this.xEditGridCell20.IsVisible = false;
            this.xEditGridCell20.Row = -1;
            this.xEditGridCell20.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell20.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell20.UnCheckedValue = "0";
            // 
            // xEditGridCell62
            // 
            this.xEditGridCell62.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell62.CellLen = 1;
            this.xEditGridCell62.CellName = "bogyong_jo_flag";
            this.xEditGridCell62.CellWidth = 43;
            this.xEditGridCell62.CheckedValue = "1";
            this.xEditGridCell62.Col = 8;
            this.xEditGridCell62.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell62.ExecuteQuery = null;
            this.xEditGridCell62.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell62, "xEditGridCell62");
            this.xEditGridCell62.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell62.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell62.UnCheckedValue = "0";
            // 
            // xEditGridCell63
            // 
            this.xEditGridCell63.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell63.CellLen = 1;
            this.xEditGridCell63.CellName = "bogyong_ju_flag";
            this.xEditGridCell63.CellWidth = 43;
            this.xEditGridCell63.CheckedValue = "1";
            this.xEditGridCell63.Col = 9;
            this.xEditGridCell63.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell63.ExecuteQuery = null;
            this.xEditGridCell63.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell63, "xEditGridCell63");
            this.xEditGridCell63.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell63.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell63.UnCheckedValue = "0";
            // 
            // xEditGridCell64
            // 
            this.xEditGridCell64.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell64.CellLen = 1;
            this.xEditGridCell64.CellName = "bogyong_seok_flag";
            this.xEditGridCell64.CellWidth = 43;
            this.xEditGridCell64.CheckedValue = "1";
            this.xEditGridCell64.Col = 10;
            this.xEditGridCell64.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell64.ExecuteQuery = null;
            this.xEditGridCell64.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell64, "xEditGridCell64");
            this.xEditGridCell64.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell64.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell64.UnCheckedValue = "0";
            // 
            // xEditGridCell65
            // 
            this.xEditGridCell65.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell65.CellLen = 1;
            this.xEditGridCell65.CellName = "bogyong_time1_flag";
            this.xEditGridCell65.CellWidth = 43;
            this.xEditGridCell65.CheckedValue = "1";
            this.xEditGridCell65.Col = 7;
            this.xEditGridCell65.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell65.ExecuteQuery = null;
            this.xEditGridCell65.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell65, "xEditGridCell65");
            this.xEditGridCell65.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell65.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell65.UnCheckedValue = "0";
            // 
            // xEditGridCell66
            // 
            this.xEditGridCell66.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell66.CellLen = 1;
            this.xEditGridCell66.CellName = "bogyong_time2_flag";
            this.xEditGridCell66.CellWidth = 43;
            this.xEditGridCell66.CheckedValue = "1";
            this.xEditGridCell66.Col = 12;
            this.xEditGridCell66.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell66.ExecuteQuery = null;
            this.xEditGridCell66.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell66, "xEditGridCell66");
            this.xEditGridCell66.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell66.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell66.UnCheckedValue = "0";
            // 
            // xEditGridCell67
            // 
            this.xEditGridCell67.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell67.CellLen = 1;
            this.xEditGridCell67.CellName = "bogyong_time3_flag";
            this.xEditGridCell67.CellWidth = 67;
            this.xEditGridCell67.CheckedValue = "1";
            this.xEditGridCell67.Col = 13;
            this.xEditGridCell67.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell67.ExecuteQuery = null;
            this.xEditGridCell67.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell67, "xEditGridCell67");
            this.xEditGridCell67.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell67.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell67.UnCheckedValue = "0";
            // 
            // xEditGridCell68
            // 
            this.xEditGridCell68.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell68.CellLen = 1;
            this.xEditGridCell68.CellName = "bogyong_time4_flag";
            this.xEditGridCell68.CellWidth = 43;
            this.xEditGridCell68.CheckedValue = "1";
            this.xEditGridCell68.Col = 14;
            this.xEditGridCell68.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell68.ExecuteQuery = null;
            this.xEditGridCell68.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell68, "xEditGridCell68");
            this.xEditGridCell68.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell68.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell68.UnCheckedValue = "0";
            // 
            // xEditGridCell69
            // 
            this.xEditGridCell69.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell69.CellLen = 1;
            this.xEditGridCell69.CellName = "bogyong_time5_flag";
            this.xEditGridCell69.CellWidth = 62;
            this.xEditGridCell69.CheckedValue = "1";
            this.xEditGridCell69.Col = 15;
            this.xEditGridCell69.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell69.ExecuteQuery = null;
            this.xEditGridCell69.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell69, "xEditGridCell69");
            this.xEditGridCell69.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell69.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell69.UnCheckedValue = "0";
            // 
            // xEditGridCell70
            // 
            this.xEditGridCell70.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell70.CellLen = 1;
            this.xEditGridCell70.CellName = "bogyong_time6_flag";
            this.xEditGridCell70.CellWidth = 43;
            this.xEditGridCell70.CheckedValue = "1";
            this.xEditGridCell70.Col = 16;
            this.xEditGridCell70.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell70.ExecuteQuery = null;
            this.xEditGridCell70.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell70, "xEditGridCell70");
            this.xEditGridCell70.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell70.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell70.UnCheckedValue = "0";
            // 
            // xEditGridCell71
            // 
            this.xEditGridCell71.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell71.CellLen = 1;
            this.xEditGridCell71.CellName = "bogyong_time7_flag";
            this.xEditGridCell71.CellWidth = 68;
            this.xEditGridCell71.CheckedValue = "1";
            this.xEditGridCell71.Col = 11;
            this.xEditGridCell71.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell71.ExecuteQuery = null;
            this.xEditGridCell71.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell71, "xEditGridCell71");
            this.xEditGridCell71.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell71.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell71.UnCheckedValue = "0";
            // 
            // tabDRG0120
            // 
            resources.ApplyResources(this.tabDRG0120, "tabDRG0120");
            this.tabDRG0120.IDEPixelArea = true;
            this.tabDRG0120.IDEPixelBorder = false;
            this.tabDRG0120.Name = "tabDRG0120";
            this.tabDRG0120.SelectedIndex = 0;
            this.tabDRG0120.SelectedTab = this.tabPage1;
            this.tabDRG0120.TabPages.AddRange(new IHIS.X.Magic.Controls.TabPage[] {
            this.tabPage1,
            this.tabPage2});
            this.tabDRG0120.SelectionChanged += new System.EventHandler(this.tabDRG0120_SelectionChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.xPanel1);
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Name = "tabPage1";
            // 
            // xPanel1
            // 
            this.xPanel1.Controls.Add(this.grdDrg0120);
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Name = "xPanel1";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.xPanel2);
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Selected = false;
            // 
            // xPanel2
            // 
            this.xPanel2.Controls.Add(this.grdDrg0120_1);
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.DrawBorder = true;
            this.xPanel2.Name = "xPanel2";
            // 
            // grdDrg0120_1
            // 
            this.grdDrg0120_1.CallerID = 'B';
            this.grdDrg0120_1.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell21,
            this.xEditGridCell22,
            this.xEditGridCell23,
            this.xEditGridCell24,
            this.xEditGridCell25,
            this.xEditGridCell26,
            this.xEditGridCell27,
            this.xEditGridCell28,
            this.xEditGridCell29,
            this.xEditGridCell30,
            this.xEditGridCell31,
            this.xEditGridCell32,
            this.xEditGridCell33,
            this.xEditGridCell34,
            this.xEditGridCell35,
            this.xEditGridCell36,
            this.xEditGridCell37,
            this.xEditGridCell38,
            this.xEditGridCell39,
            this.xEditGridCell40});
            this.grdDrg0120_1.ColPerLine = 8;
            this.grdDrg0120_1.ColResizable = true;
            this.grdDrg0120_1.Cols = 9;
            resources.ApplyResources(this.grdDrg0120_1, "grdDrg0120_1");
            this.grdDrg0120_1.ExecuteQuery = null;
            this.grdDrg0120_1.FixedCols = 1;
            this.grdDrg0120_1.FixedRows = 1;
            this.grdDrg0120_1.FocusColumnName = "bogyong_code";
            this.grdDrg0120_1.HeaderHeights.Add(31);
            this.grdDrg0120_1.Name = "grdDrg0120_1";
            this.grdDrg0120_1.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdDrg0120_1.ParamList")));
            this.grdDrg0120_1.QuerySQL = resources.GetString("grdDrg0120_1.QuerySQL");
            this.grdDrg0120_1.RowHeaderVisible = true;
            this.grdDrg0120_1.Rows = 2;
            this.grdDrg0120_1.PreSaveLayout += new IHIS.Framework.GridRecordEventHandler(this.grdDrg0120_1_PreSaveLayout);
            this.grdDrg0120_1.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdDrg0120_1_QueryStarting);
            this.grdDrg0120_1.PreEndInitializing += new System.EventHandler(this.grdDrg0120_1_PreEndInitializing);
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell21.CellName = "bogyong_code";
            this.xEditGridCell21.CellWidth = 69;
            this.xEditGridCell21.Col = 1;
            this.xEditGridCell21.EnableSort = true;
            this.xEditGridCell21.ExecuteQuery = null;
            this.xEditGridCell21.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell21, "xEditGridCell21");
            this.xEditGridCell21.IsUpdatable = false;
            this.xEditGridCell21.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell22
            // 
            this.xEditGridCell22.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell22.CellLen = 80;
            this.xEditGridCell22.CellName = "bogyong_name";
            this.xEditGridCell22.CellWidth = 399;
            this.xEditGridCell22.Col = 2;
            this.xEditGridCell22.EnableSort = true;
            this.xEditGridCell22.ExecuteQuery = null;
            this.xEditGridCell22.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell22, "xEditGridCell22");
            this.xEditGridCell22.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell23
            // 
            this.xEditGridCell23.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell23.CellLen = 8;
            this.xEditGridCell23.CellName = "pattern";
            this.xEditGridCell23.CellWidth = 67;
            this.xEditGridCell23.Col = -1;
            this.xEditGridCell23.EnableSort = true;
            this.xEditGridCell23.ExecuteQuery = null;
            this.xEditGridCell23.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell23, "xEditGridCell23");
            this.xEditGridCell23.IsVisible = false;
            this.xEditGridCell23.Row = -1;
            this.xEditGridCell23.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell24
            // 
            this.xEditGridCell24.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell24.CellLen = 2;
            this.xEditGridCell24.CellName = "bogyong_gubun";
            this.xEditGridCell24.CellWidth = 43;
            this.xEditGridCell24.Col = 3;
            this.xEditGridCell24.EnableSort = true;
            this.xEditGridCell24.ExecuteQuery = null;
            this.xEditGridCell24.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell24, "xEditGridCell24");
            this.xEditGridCell24.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell25
            // 
            this.xEditGridCell25.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell25.CellLen = 1;
            this.xEditGridCell25.CellName = "drg_grp";
            this.xEditGridCell25.CellWidth = 55;
            this.xEditGridCell25.Col = -1;
            this.xEditGridCell25.EnableSort = true;
            this.xEditGridCell25.ExecuteQuery = null;
            this.xEditGridCell25.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell25, "xEditGridCell25");
            this.xEditGridCell25.IsVisible = false;
            this.xEditGridCell25.Row = -1;
            this.xEditGridCell25.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell26
            // 
            this.xEditGridCell26.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell26.CellLen = 80;
            this.xEditGridCell26.CellName = "bogyong_name_2";
            this.xEditGridCell26.CellWidth = 182;
            this.xEditGridCell26.Col = -1;
            this.xEditGridCell26.EnableSort = true;
            this.xEditGridCell26.ExecuteQuery = null;
            this.xEditGridCell26.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell26, "xEditGridCell26");
            this.xEditGridCell26.IsVisible = false;
            this.xEditGridCell26.Row = -1;
            this.xEditGridCell26.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell27
            // 
            this.xEditGridCell27.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell27.CellLen = 1;
            this.xEditGridCell27.CellName = "bogyong_gubun_default";
            this.xEditGridCell27.Col = -1;
            this.xEditGridCell27.ExecuteQuery = null;
            this.xEditGridCell27.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell27.IsVisible = false;
            this.xEditGridCell27.Row = -1;
            this.xEditGridCell27.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell28
            // 
            this.xEditGridCell28.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell28.CellLen = 1;
            this.xEditGridCell28.CellName = "prt_gubun";
            this.xEditGridCell28.CellWidth = 49;
            this.xEditGridCell28.Col = -1;
            this.xEditGridCell28.EnableSort = true;
            this.xEditGridCell28.ExecuteQuery = null;
            this.xEditGridCell28.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell28, "xEditGridCell28");
            this.xEditGridCell28.IsVisible = false;
            this.xEditGridCell28.Row = -1;
            this.xEditGridCell28.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell29
            // 
            this.xEditGridCell29.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell29.CellLen = 2;
            this.xEditGridCell29.CellName = "bunryu1";
            this.xEditGridCell29.CellWidth = 91;
            this.xEditGridCell29.CodeDisplay = false;
            this.xEditGridCell29.Col = 4;
            this.xEditGridCell29.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell29.EnableSort = true;
            this.xEditGridCell29.ExecuteQuery = null;
            this.xEditGridCell29.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell29, "xEditGridCell29");
            this.xEditGridCell29.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell29.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.xEditGridCell29.UserSQL = resources.GetString("xEditGridCell29.UserSQL");
            // 
            // xEditGridCell30
            // 
            this.xEditGridCell30.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell30.CellLen = 30;
            this.xEditGridCell30.CellName = "bogyong_code_full";
            this.xEditGridCell30.Col = -1;
            this.xEditGridCell30.ExecuteQuery = null;
            this.xEditGridCell30.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell30.IsVisible = false;
            this.xEditGridCell30.Row = -1;
            this.xEditGridCell30.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell31
            // 
            this.xEditGridCell31.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell31.CellLen = 1;
            this.xEditGridCell31.CellName = "sp_bogyong_yn";
            this.xEditGridCell31.CellWidth = 68;
            this.xEditGridCell31.Col = -1;
            this.xEditGridCell31.DictColumn = "SP_BOGYONG_YN";
            this.xEditGridCell31.EnableSort = true;
            this.xEditGridCell31.ExecuteQuery = null;
            this.xEditGridCell31.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell31, "xEditGridCell31");
            this.xEditGridCell31.IsVisible = false;
            this.xEditGridCell31.Row = -1;
            this.xEditGridCell31.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell32
            // 
            this.xEditGridCell32.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell32.CellName = "block_gubun";
            this.xEditGridCell32.CodeDisplay = false;
            this.xEditGridCell32.Col = 7;
            this.xEditGridCell32.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell32.ExecuteQuery = null;
            this.xEditGridCell32.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell32, "xEditGridCell32");
            this.xEditGridCell32.MaxDropDownItems = 30;
            this.xEditGridCell32.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell32.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.xEditGridCell32.UserSQL = resources.GetString("xEditGridCell32.UserSQL");
            // 
            // xEditGridCell33
            // 
            this.xEditGridCell33.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell33.CellName = "banghyang";
            this.xEditGridCell33.CodeDisplay = false;
            this.xEditGridCell33.Col = 6;
            this.xEditGridCell33.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell33.ExecuteQuery = null;
            this.xEditGridCell33.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell33, "xEditGridCell33");
            this.xEditGridCell33.MaxDropDownItems = 30;
            this.xEditGridCell33.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell33.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.xEditGridCell33.UserSQL = resources.GetString("xEditGridCell33.UserSQL");
            // 
            // xEditGridCell34
            // 
            this.xEditGridCell34.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell34.CellName = "chiryo_gubun";
            this.xEditGridCell34.CellWidth = 124;
            this.xEditGridCell34.CodeDisplay = false;
            this.xEditGridCell34.Col = 8;
            this.xEditGridCell34.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell34.ExecuteQuery = null;
            this.xEditGridCell34.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell34, "xEditGridCell34");
            this.xEditGridCell34.MaxDropDownItems = 30;
            this.xEditGridCell34.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell34.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.xEditGridCell34.UserSQL = resources.GetString("xEditGridCell34.UserSQL");
            // 
            // xEditGridCell35
            // 
            this.xEditGridCell35.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell35.CellName = "donbog_yn";
            this.xEditGridCell35.CellWidth = 81;
            this.xEditGridCell35.Col = 5;
            this.xEditGridCell35.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell35.ExecuteQuery = null;
            this.xEditGridCell35.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell35, "xEditGridCell35");
            this.xEditGridCell35.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell36
            // 
            this.xEditGridCell36.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell36.CellName = "pattern1";
            this.xEditGridCell36.CellWidth = 40;
            this.xEditGridCell36.CheckedValue = "1";
            this.xEditGridCell36.Col = -1;
            this.xEditGridCell36.ExecuteQuery = null;
            this.xEditGridCell36.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell36, "xEditGridCell36");
            this.xEditGridCell36.IsVisible = false;
            this.xEditGridCell36.Row = -1;
            this.xEditGridCell36.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell36.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell36.UnCheckedValue = "0";
            // 
            // xEditGridCell37
            // 
            this.xEditGridCell37.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell37.CellName = "pattern2";
            this.xEditGridCell37.CellWidth = 40;
            this.xEditGridCell37.CheckedValue = "1";
            this.xEditGridCell37.Col = -1;
            this.xEditGridCell37.ExecuteQuery = null;
            this.xEditGridCell37.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell37, "xEditGridCell37");
            this.xEditGridCell37.IsVisible = false;
            this.xEditGridCell37.Row = -1;
            this.xEditGridCell37.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell37.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell37.UnCheckedValue = "0";
            // 
            // xEditGridCell38
            // 
            this.xEditGridCell38.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell38.CellName = "pattern3";
            this.xEditGridCell38.CellWidth = 40;
            this.xEditGridCell38.CheckedValue = "1";
            this.xEditGridCell38.Col = -1;
            this.xEditGridCell38.ExecuteQuery = null;
            this.xEditGridCell38.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell38, "xEditGridCell38");
            this.xEditGridCell38.IsVisible = false;
            this.xEditGridCell38.Row = -1;
            this.xEditGridCell38.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell38.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell38.UnCheckedValue = "0";
            // 
            // xEditGridCell39
            // 
            this.xEditGridCell39.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell39.CellName = "pattern4";
            this.xEditGridCell39.CellWidth = 40;
            this.xEditGridCell39.CheckedValue = "1";
            this.xEditGridCell39.Col = -1;
            this.xEditGridCell39.ExecuteQuery = null;
            this.xEditGridCell39.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell39, "xEditGridCell39");
            this.xEditGridCell39.IsVisible = false;
            this.xEditGridCell39.Row = -1;
            this.xEditGridCell39.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell39.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell39.UnCheckedValue = "0";
            // 
            // xEditGridCell40
            // 
            this.xEditGridCell40.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell40.CellName = "pattern5";
            this.xEditGridCell40.CellWidth = 40;
            this.xEditGridCell40.CheckedValue = "1";
            this.xEditGridCell40.Col = -1;
            this.xEditGridCell40.ExecuteQuery = null;
            this.xEditGridCell40.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell40, "xEditGridCell40");
            this.xEditGridCell40.IsVisible = false;
            this.xEditGridCell40.Row = -1;
            this.xEditGridCell40.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell40.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell40.UnCheckedValue = "0";
            // 
            // xEditGridCell59
            // 
            this.xEditGridCell59.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell59.CellName = "pattern";
            this.xEditGridCell59.Col = 11;
            this.xEditGridCell59.ExecuteQuery = null;
            this.xEditGridCell59.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell59, "xEditGridCell59");
            this.xEditGridCell59.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell60
            // 
            this.xEditGridCell60.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell60.CellName = "pattern";
            this.xEditGridCell60.Col = 11;
            this.xEditGridCell60.ExecuteQuery = null;
            this.xEditGridCell60.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell60, "xEditGridCell60");
            this.xEditGridCell60.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell61
            // 
            this.xEditGridCell61.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell61.CellName = "pattern";
            this.xEditGridCell61.Col = 11;
            this.xEditGridCell61.ExecuteQuery = null;
            this.xEditGridCell61.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell61, "xEditGridCell61");
            this.xEditGridCell61.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // pnlTop
            // 
            resources.ApplyResources(this.pnlTop, "pnlTop");
            this.pnlTop.Controls.Add(this.dbxHospitalNm);
            this.pnlTop.Controls.Add(this.fbxHospitalID);
            this.pnlTop.Controls.Add(this.xLabel4);
            this.pnlTop.Name = "pnlTop";
            // 
            // dbxHospitalNm
            // 
            resources.ApplyResources(this.dbxHospitalNm, "dbxHospitalNm");
            this.dbxHospitalNm.Name = "dbxHospitalNm";
            // 
            // fbxHospitalID
            // 
            this.fbxHospitalID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.fbxHospitalID.FindWorker = this.fwkHospitalID;
            resources.ApplyResources(this.fbxHospitalID, "fbxHospitalID");
            this.fbxHospitalID.Name = "fbxHospitalID";
            this.fbxHospitalID.FindClick += new System.ComponentModel.CancelEventHandler(this.fbxHospitalID_FindClick);
            this.fbxHospitalID.FindSelected += new IHIS.Framework.FindEventHandler(this.fbxID_FindSelected);
            this.fbxHospitalID.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxHospitalID_DataValidating);
            // 
            // fwkHospitalID
            // 
            this.fwkHospitalID.ExecuteQuery = null;
            this.fwkHospitalID.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("fwkHospitalID.ParamList")));
            // 
            // xLabel4
            // 
            this.xLabel4.BackColor = IHIS.Framework.XColor.XScreenBackColor;
            resources.ApplyResources(this.xLabel4, "xLabel4");
            this.xLabel4.Name = "xLabel4";
            // 
            // DRG0120U00
            // 
            this.Controls.Add(this.tabDRG0120);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            resources.ApplyResources(this, "$this");
            this.Name = "DRG0120U00";
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdYoiyong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdNaebog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDrg0120)).EndInit();
            this.tabDRG0120.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.xPanel1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.xPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDrg0120_1)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		 protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);
            this.CurrMQLayout = this.grdDrg0120;
            grdDrg0120.QueryLayout(false);			
		}

        private void tabDRG0120_SelectionChanged(object sender, System.EventArgs e)
		{
			if (gubun == "0")
			{
				this.CurrMQLayout = this.grdDrg0120;
                grdDrg0120.QueryLayout(false); 
            }
            else
            {
                this.CurrMQLayout = this.grdDrg0120_1;
                grdDrg0120_1.QueryLayout(false);
            }
		}

		private void xButtonList1_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			switch(e.Func)
			{
				case FunctionType.Query:
					if (gubun == "0")
                        this.CurrMQLayout = this.grdDrg0120;
					else
                        this.CurrMQLayout = this.grdDrg0120_1;
					break;
				case FunctionType.Update:
                    try
                    {
                        //if (gubun == "0")
                        //    this.grdDrg0120.SaveLayout();
                        //else
                        //    this.grdDrg0120_1.SaveLayout();

                        if (gubun == "0")
                        {
                            bool saveGrdDrg0120Result = SaveGrdDrg0120(true);
                            if (saveGrdDrg0120Result && !unchanged)
                            {
                                XMessageBox.Show(Resources.MSG_SAVE_SUCCESS, Resources.SAVE_CAP, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.grdDrg0120.QueryLayout(false);
                            }
                            if (!saveGrdDrg0120Result)
                            {
                                //XMessageBox.Show("Save failed");
                                XMessageBox.Show(Resources.MSG_SAVE_FAILED, Resources.SAVE_CAP, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                this.grdDrg0120.QueryLayout(false);
                            }   
                        }
                        else
                        {
                            bool saveGrdDrg0120_1Result = SaveGrdDrg0120(false);
                            if (saveGrdDrg0120_1Result && !unchanged)
                            {
                                this.grdDrg0120_1.QueryLayout(false);
                            }
                            if (!saveGrdDrg0120_1Result)
                            {
                                // XMessageBox.Show("Save failed");                                
                                XMessageBox.Show(Resources.MSG_SAVE_FAILED, Resources.SAVE_CAP, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch (Exception xe)
                    {
						//https://sofiamedix.atlassian.net/browse/MED-10610
                        //XMessageBox.Show(xe.Message + "\n\r" + xe.StackTrace);
                        return;
                    }
                    break;

				default:
					break;
			}
		}

        /// <summary>
        /// Save grdDrg0120 or grdDrg0120_1
        /// </summary>
        /// <param name="p0"></param>
        /// <returns></returns>
	    private bool SaveGrdDrg0120(bool p0)
        {
            List<DRG0120U00GrdDrg0120ItemInfo> inputList = null;
            if (p0)
            {
                inputList = GetListFromGrdDrg0120();
            }
            else
            {
                inputList = GetListFromGrdDrg0120_1();                
            }
            if (inputList.Count == 0)
            {
                this.unchanged = true;
                return true;
            }

            // MED-14416
            if (inputList.Find(delegate(DRG0120U00GrdDrg0120ItemInfo item) { return TypeCheck.IsNull(item.BogyongCode); }) != null)
            {
                XMessageBox.Show(Resources.MSG_REQUIRED_CODE, Resources.SAVE_CAP, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.unchanged = true;
                return true;
            }

            this.unchanged = false;
            DRG0120U00SaveLayoutArgs args = new DRG0120U00SaveLayoutArgs(UserInfo.UserID, this.mHospCode, inputList);
            UpdateResult result = CloudService.Instance.Submit<UpdateResult, DRG0120U00SaveLayoutArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                return result.Result;
            }

            return false;
        }

	    private List<DRG0120U00GrdDrg0120ItemInfo> GetListFromGrdDrg0120_1()
	    {
            List<DRG0120U00GrdDrg0120ItemInfo> dataList = new List<DRG0120U00GrdDrg0120ItemInfo>();
            for (int i = 0; i < grdDrg0120_1.RowCount; i++)
            {
                if (grdDrg0120_1.GetRowState(i) == DataRowState.Unchanged)
                {
                    continue;
                }
                DRG0120U00GrdDrg0120ItemInfo info = new DRG0120U00GrdDrg0120ItemInfo();
                if (grdDrg0120_1.GetRowState(i) == DataRowState.Added)
                {
                    info.Bunryu1 = "6";
                }
                else
                {
                    info.Bunryu1 = grdDrg0120_1.GetItemString(i, "bunryu1");
                }

                info.BogyongCode = grdDrg0120_1.GetItemString(i, "bogyong_code");
                info.BogyongName = grdDrg0120_1.GetItemString(i, "bogyong_name");
                info.Pattern = grdDrg0120_1.GetItemString(i, "pattern");
                info.BogyongGubun = grdDrg0120_1.GetItemString(i, "bogyong_gubun");
                info.DrgGrp = grdDrg0120_1.GetItemString(i, "drg_grp");
                info.BogyongName2 = grdDrg0120_1.GetItemString(i, "bogyong_name_2");
                info.BogyongGubunDefault = grdDrg0120_1.GetItemString(i, "bogyong_gubun_default");
                info.PrtGubun = grdDrg0120_1.GetItemString(i, "prt_gubun");
                //info.Bunryu1 = grdDrg0120_1.GetItemString(i, "bunryu1");
                info.BogyongCodeFull = grdDrg0120_1.GetItemString(i, "bogyong_code_full");
                info.SpBogyongYn = grdDrg0120_1.GetItemString(i, "sp_bogyong_yn");
                info.BlockGubun = grdDrg0120_1.GetItemString(i, "block_gubun");
                info.Banghyang = grdDrg0120_1.GetItemString(i, "banghyang");
                info.ChiryoGubun = grdDrg0120_1.GetItemString(i, "chiryo_gubun");
                info.DonbogYn = grdDrg0120_1.GetItemString(i, "donbog_yn");
                info.Pattern1 = grdDrg0120_1.GetItemString(i, "pattern1");
                info.Pattern2 = grdDrg0120_1.GetItemString(i, "pattern2");
                info.Pattern3 = grdDrg0120_1.GetItemString(i, "pattern3");
                info.Pattern4 = grdDrg0120_1.GetItemString(i, "pattern4");
                info.Pattern5 = grdDrg0120_1.GetItemString(i, "pattern5");
                info.RowState = grdDrg0120_1.GetRowState(i).ToString();

                dataList.Add(info);
            }

            if (grdDrg0120_1.DeletedRowTable != null && grdDrg0120_1.DeletedRowTable.Rows.Count > 0)
            {
                foreach (DataRow row in grdDrg0120_1.DeletedRowTable.Rows)
                {
                    DRG0120U00GrdDrg0120ItemInfo info = new DRG0120U00GrdDrg0120ItemInfo();
                    info.BogyongCode = row["bogyong_code"].ToString();
                    info.RowState = DataRowState.Deleted.ToString();

                    dataList.Add(info);
                }
            }

            return dataList;
	    }

	    private List<DRG0120U00GrdDrg0120ItemInfo> GetListFromGrdDrg0120()
	    {
	        List<DRG0120U00GrdDrg0120ItemInfo> dataList = new List<DRG0120U00GrdDrg0120ItemInfo>();
	        for (int i = 0; i < grdDrg0120.RowCount; i++)
	        {
	            if (grdDrg0120.GetRowState(i) == DataRowState.Unchanged)
	            {
	                continue;
	            }
                DRG0120U00GrdDrg0120ItemInfo info = new DRG0120U00GrdDrg0120ItemInfo();
                if (grdDrg0120.GetRowState(i) == DataRowState.Added)
                {
                    info.Bunryu1 = "1";
                }
                else
                {
                    info.Bunryu1 = grdDrg0120.GetItemString(i, "bunryu1");
                }

                info.BogyongCode = grdDrg0120.GetItemString(i, "bogyong_code");
                info.BogyongName = grdDrg0120.GetItemString(i, "bogyong_name");
                info.Pattern = grdDrg0120.GetItemString(i, "pattern");
                info.BogyongGubun = grdDrg0120.GetItemString(i, "bogyong_gubun");
                info.DrgGrp = grdDrg0120.GetItemString(i, "drg_grp");
                info.BogyongName2 = grdDrg0120.GetItemString(i, "bogyong_name_2");
                info.BogyongGubunDefault = grdDrg0120.GetItemString(i, "bogyong_gubun_default");
                info.PrtGubun = grdDrg0120.GetItemString(i, "prt_gubun");
                //info.Bunryu1 = grdDrg0120.GetItemString(i, "bunryu1");
                info.BogyongCodeFull = grdDrg0120.GetItemString(i, "bogyong_code_full");
                info.SpBogyongYn = grdDrg0120.GetItemString(i, "sp_bogyong_yn");
                info.BlockGubun = grdDrg0120.GetItemString(i, "block_gubun");
                info.Banghyang = grdDrg0120.GetItemString(i, "banghyang");
                info.ChiryoGubun = grdDrg0120.GetItemString(i, "chiryo_gubun");
                info.DonbogYn = grdDrg0120.GetItemString(i, "donbog_yn");
                info.Pattern1 = grdDrg0120.GetItemString(i, "pattern1");
                info.Pattern2 = grdDrg0120.GetItemString(i, "pattern2");
                info.Pattern3 = grdDrg0120.GetItemString(i, "pattern3");
                info.Pattern4 = grdDrg0120.GetItemString(i, "pattern4");
                info.Pattern5 = grdDrg0120.GetItemString(i, "pattern5");
                info.BogyongJoFlag = grdDrg0120.GetItemString(i, "bogyong_jo_flag");
                info.BogyongJuFlag = grdDrg0120.GetItemString(i, "bogyong_ju_flag");
                info.BogyongSeokFlag = grdDrg0120.GetItemString(i, "bogyong_seok_flag");
                info.BogyongTime1Flag = grdDrg0120.GetItemString(i, "bogyong_time1_flag");
                info.BogyongTime2Flag = grdDrg0120.GetItemString(i, "bogyong_time2_flag");
                info.BogyongTime3Flag = grdDrg0120.GetItemString(i, "bogyong_time3_flag");
                info.BogyongTime4Flag = grdDrg0120.GetItemString(i, "bogyong_time4_flag");
                info.BogyongTime5Flag = grdDrg0120.GetItemString(i, "bogyong_time5_flag");
                info.BogyongTime6Flag = grdDrg0120.GetItemString(i, "bogyong_time6_flag");
                info.BogyongTime7Flag = grdDrg0120.GetItemString(i, "bogyong_time7_flag");
	            info.RowState = grdDrg0120.GetRowState(i).ToString();

                dataList.Add(info);
	        }

	        if (grdDrg0120.DeletedRowTable != null && grdDrg0120.DeletedRowTable.Rows.Count > 0)
	        {
	            foreach (DataRow row in grdDrg0120.DeletedRowTable.Rows)
	            {
                    DRG0120U00GrdDrg0120ItemInfo info = new DRG0120U00GrdDrg0120ItemInfo();
	                info.BogyongCode = row["bogyong_code"].ToString();
	                info.RowState = DataRowState.Deleted.ToString();

                    dataList.Add(info);
	            }
	        }

	        return dataList;
	    }

	    private void grdDrg0120_PreSaveLayout(object sender, GridRecordEventArgs e)
        {
            if(e.RowState == DataRowState.Added)
            {
                grdDrg0120.SetItemValue(e.RowNumber, "bunryu1", "1");
            }
        }

        private void grdDrg0120_1_PreSaveLayout(object sender, GridRecordEventArgs e)
        {
            if(e.RowState == DataRowState.Added)
            {
                grdDrg0120_1.SetItemValue(e.RowNumber, "bunryu1", "6");
            }
        }

		private void btnExcel_Click(object sender, System.EventArgs e)
		{
			if (gubun == "0")
			{
                this.grdNaebog.Reset();
                this.grdNaebog.QueryLayout(true);
            }
            else
            {
                this.grdYoiyong.Reset();
                this.grdYoiyong.QueryLayout(true);
			}
		}

        private void Excel_QueryEnd(object sender, QueryEndEventArgs e)
        {
            if (e.IsSuccess == true)
            {
                if (gubun == "0")
                    this.grdNaebog.Export(true);
                else
                    this.grdYoiyong.Export(true);
            }
        }

        #region [ 各LAYOUT 에 바인드 변수 설정 20100618 ]
        private void grdDrg0120_QueryStarting(object sender, CancelEventArgs e)
        {
            grdDrg0120.SetBindVarValue("f_bunryu1", gubun);
            grdDrg0120.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
        }

        private void grdDrg0120_1_QueryStarting(object sender, CancelEventArgs e)
        {
            grdDrg0120_1.SetBindVarValue("f_bunryu1", gubun);
            grdDrg0120_1.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
        }

        private void grdNaebog_QueryStarting(object sender, CancelEventArgs e)
        {
            grdNaebog.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
        }

        private void grdYoiyong_QueryStarting(object sender, CancelEventArgs e)
        {
            grdYoiyong.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
        }
        #endregion





/* ====================================== SAVEPERFORMER ====================================== */

        #region XSavePerformer
//        private class XSavePerformer : IHIS.Framework.ISavePerformer
//        {
//            private DRG0120U00 parent = null;
//            public XSavePerformer(DRG0120U00 parent)
//            {
//                this.parent = parent;
//            }
//            public bool Execute(char callerID, RowDataItem item)
//            {
//                string cmdText = "";
//                //Grid에서 넘어온 Bind 변수에 f_user_id SET
//                item.BindVarList.Add("q_user_id", UserInfo.UserID);
//                item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);

//                switch (item.RowState)
//                {
//                    case DataRowState.Added:
//                        cmdText = @"INSERT INTO DRG0120 (
//                                                         SYS_DATE,   SYS_ID
//                                                       , BOGYONG_CODE
//                                                       , BOGYONG_NAME
//                                                       , PATTERN
//                                                       , BOGYONG_GUBUN
//                                                       , DRG_GRP
//                                                       , BOGYONG_NAME_2
//                                                       , BOGYONG_GUBUN_DEFAULT
//                                                       , PRT_GUBUN
//                                                       , BUNRYU1
//                                                       , BOGYONG_CODE_FULL
//                                                       , SP_BOGYONG_YN 
//                                                       , BLOCK_GUBUN 
//                                                       , BANGHYANG   
//                                                       , CHIRYO_GUBUN
//                                                       , DONBOG_YN
//                                                       , HOSP_CODE
//                                                       , BOGYONG_JO_FLAG
//                                                       , BOGYONG_JU_FLAG
//                                                       , BOGYONG_SEOK_FLAG
//                                                       , BOGYONG_TIME1_FLAG
//                                                       , BOGYONG_TIME2_FLAG
//                                                       , BOGYONG_TIME3_FLAG
//                                                       , BOGYONG_TIME4_FLAG
//                                                       , BOGYONG_TIME5_FLAG
//                                                       , BOGYONG_TIME6_FLAG
//                                                       , BOGYONG_TIME7_FLAG
//                                                       ) VALUES (
//                                                         SYSDATE,  :q_user_id
//                                                       , :f_bogyong_code         
//                                                       , :f_bogyong_name         
//                                                       --, '0' || NVL(:f_pattern1,'0') || NVL(:f_pattern2,'0') || NVL(:f_pattern3,'0') || NVL(:f_pattern4,'0') || NVL(:f_pattern5,'0') || '00'
//                                                       , :f_pattern
//                                                       , :f_bogyong_gubun        
//                                                       , :f_drg_grp
//                                                       , :f_bogyong_name_2       
//                                                       , :f_bogyong_gubun_default
//                                                       , :f_prt_gubun            
//                                                       , :f_bunryu1              
//                                                       , :f_bogyong_code_full    
//                                                       , :f_sp_bogyong_yn       
//                                                       , :f_block_gubun 
//                                                       , :f_banghyang   
//                                                       , :f_chiryo_gubun
//                                                       , :f_donbog_yn
//                                                       , :f_hosp_code
//                                                       , :f_bogyong_jo_flag   
//                                                       , :f_bogyong_ju_flag   
//                                                       , :f_bogyong_seok_flag 
//                                                       , :f_bogyong_time1_flag
//                                                       , :f_bogyong_time2_flag
//                                                       , :f_bogyong_time3_flag
//                                                       , :f_bogyong_time4_flag
//                                                       , :f_bogyong_time5_flag
//                                                       , :f_bogyong_time6_flag
//                                                       , :f_bogyong_time7_flag
//                                                       )";
//                        break;
//                    case DataRowState.Modified:
//                        cmdText = @"UPDATE DRG0120                    
//                                       SET UPD_DATE                = SYSDATE
//                                          ,BOGYONG_NAME            = :f_bogyong_name           
//                                          --,PATTERN               = '0' || NVL(:f_pattern1,'0') || NVL(:f_pattern2,'0') || NVL(:f_pattern3,'0') || NVL(:f_pattern4,'0') || NVL(:f_pattern5,'0') || '00'
//                                          ,PATTERN                 = :f_pattern
//                                          ,BOGYONG_GUBUN           = :f_bogyong_gubun        
//                                          ,DRG_GRP                 = :f_drg_grp              
//                                          ,BOGYONG_NAME_2          = :f_bogyong_name_2       
//                                          ,BOGYONG_GUBUN_DEFAULT   = :f_bogyong_gubun_default
//                                          ,PRT_GUBUN               = :f_prt_gubun            
//                                          ,BUNRYU1                 = :f_bunryu1              
//                                          ,BOGYONG_CODE_FULL       = :f_bogyong_code_full    
//                                          ,SP_BOGYONG_YN           = :f_sp_bogyong_yn       
//                                          ,BLOCK_GUBUN             = :f_block_gubun 
//                                          ,BANGHYANG               = :f_banghyang   
//                                          ,CHIRYO_GUBUN            = :f_chiryo_gubun
//                                          ,DONBOG_YN               = :f_donbog_yn
//                                          ,UPD_ID                  = :q_user_id
//                                          ,BOGYONG_JO_FLAG         = :f_bogyong_jo_flag   
//                                          ,BOGYONG_JU_FLAG         = :f_bogyong_ju_flag   
//                                          ,BOGYONG_SEOK_FLAG       = :f_bogyong_seok_flag 
//                                          ,BOGYONG_TIME1_FLAG      = :f_bogyong_time1_flag
//                                          ,BOGYONG_TIME2_FLAG      = :f_bogyong_time2_flag
//                                          ,BOGYONG_TIME3_FLAG      = :f_bogyong_time3_flag
//                                          ,BOGYONG_TIME4_FLAG      = :f_bogyong_time4_flag
//                                          ,BOGYONG_TIME5_FLAG      = :f_bogyong_time5_flag
//                                          ,BOGYONG_TIME6_FLAG      = :f_bogyong_time6_flag
//                                          ,BOGYONG_TIME7_FLAG      = :f_bogyong_time7_flag
//                                     WHERE BOGYONG_CODE = :f_bogyong_code
//                                       AND HOSP_CODE    = :f_hosp_code";
//                        break;
//                    case DataRowState.Deleted:
//                        cmdText = @"DELETE DRG0120
//                                     WHERE BOGYONG_CODE = :f_bogyong_code
//                                       AND HOSP_CODE    = :f_hosp_code";
//                        break;
//                }

//                return Service.ExecuteNonQuery(cmdText, item.BindVarList);
//            }
//        }
        #endregion


/* ====================================== SAVEPERFORMER ====================================== */

        //private void grdDrg0120_GridColumnChanged(object sender, GridColumnChangedEventArgs e)
        //{
        //    XMessageBox.Show(this.grdDrg0120.GetItemString(e.RowNumber,e.ColName));
        //    if(e.ColName.Equals("bogyong_time1_flag") || e.ColName.Equals("bogyong_jo_flag") || e.ColName.Equals("bogyong_ju_flag") || e.ColName.Equals("bogyong_seok_flag") || e.ColName.Equals("bogyong_time7_flag"))
        //        this.grdDrg0120.SetItemValue(this.grdDrg0120.CurrentRowNumber,"pattern", "0" 
        //            + this.grdDrg0120.GetItemString(this.grdDrg0120.CurrentRowNumber, "bogyong_time1_flag")
        //            + this.grdDrg0120.GetItemString(this.grdDrg0120.CurrentRowNumber, "bogyong_jo_flag")
        //            + this.grdDrg0120.GetItemString(this.grdDrg0120.CurrentRowNumber, "bogyong_ju_flag")
        //            + this.grdDrg0120.GetItemString(this.grdDrg0120.CurrentRowNumber, "bogyong_seok_flag")
        //            + this.grdDrg0120.GetItemString(this.grdDrg0120.CurrentRowNumber, "bogyong_time7_flag")
        //            + "00");

        //}

        private void grdDrg0120_ItemValueChanging(object sender, ItemValueChangingEventArgs e)
        {

        }

        private void grdDrg0120_GridColumnChanged(object sender, GridColumnChangedEventArgs e)
        {
            if (e.ColName.Equals("bogyong_time1_flag") || e.ColName.Equals("bogyong_jo_flag") || e.ColName.Equals("bogyong_ju_flag") || e.ColName.Equals("bogyong_seok_flag") || e.ColName.Equals("bogyong_time7_flag"))
                this.grdDrg0120.SetItemValue(this.grdDrg0120.CurrentRowNumber, "pattern", "0"
                    + this.isNullChk(this.grdDrg0120.GetItemString(this.grdDrg0120.CurrentRowNumber, "bogyong_time1_flag"))
                    + this.isNullChk(this.grdDrg0120.GetItemString(this.grdDrg0120.CurrentRowNumber, "bogyong_jo_flag"))
                    + this.isNullChk(this.grdDrg0120.GetItemString(this.grdDrg0120.CurrentRowNumber, "bogyong_ju_flag"))
                    + this.isNullChk(this.grdDrg0120.GetItemString(this.grdDrg0120.CurrentRowNumber, "bogyong_seok_flag"))
                    + this.isNullChk(this.grdDrg0120.GetItemString(this.grdDrg0120.CurrentRowNumber, "bogyong_time7_flag"))
                    + "00");
        }

        private string isNullChk(string str)
        {
            string rtnVal = '0'.ToString();

            if (TypeCheck.IsNull(str)) return rtnVal;
            else return str;
        }

        private void grdDrg0120_PreEndInitializing(object sender, EventArgs e)
        {
            InitializeComboListItem();
//            this.xEditGridCell12.ExecuteQuery = LoadCombo32;
            this.xEditGridCell13.ExecuteQuery = LoadCombo35;
//            this.xEditGridCell14.ExecuteQuery = LoadCombo34;
        }

	    private void grdDrg0120_1_PreEndInitializing(object sender, EventArgs e)
	    {
	        InitializeComboListItem();
            this.xEditGridCell29.ExecuteQuery = LoadComboUA;
            this.xEditGridCell32.ExecuteQuery = LoadCombo32;
            this.xEditGridCell33.ExecuteQuery = LoadCombo33;
            this.xEditGridCell34.ExecuteQuery = LoadCombo34;
        }

	    private IList<object[]> LoadCombo33(BindVarCollection varlist)
	    {
	        IList<object[]> dataList = new List<object[]>();
	        if (comboListResult.ExecutionStatus == ExecutionStatus.Success)
	        {
	            List<ComboListItemInfo> cboList = comboListResult.CboList33;
	            if (cboList != null && cboList.Count > 0)
	            {
	                foreach (ComboListItemInfo info in cboList)
	                {
	                    dataList.Add(new object[]
	                    {
	                        info.Code,
                            info.CodeName
	                    });
	                }
	            }
	        }
	        return dataList;
	    }

	    private IList<object[]> LoadComboUA(BindVarCollection varlist)
	    {
            IList<object[]> dataList = new List<object[]>();
            if (comboListResult.ExecutionStatus == ExecutionStatus.Success)
            {
                List<ComboListItemInfo> cboList = comboListResult.CboListUA;
                if (cboList != null && cboList.Count > 0)
                {
                    foreach (ComboListItemInfo info in cboList)
                    {
                        dataList.Add(new object[]
	                    {
	                        info.Code,
                            info.CodeName
	                    });
                    }
                }
            }
            return dataList;
	    }

        private IList<object[]> LoadCombo34(BindVarCollection varlist)
        {
            IList<object[]> dataList = new List<object[]>();
            if (comboListResult.ExecutionStatus == ExecutionStatus.Success)
            {
                List<ComboListItemInfo> cboList = comboListResult.CboList34;
                if (cboList != null && cboList.Count > 0)
                {
                    foreach (ComboListItemInfo info in cboList)
                    {
                        dataList.Add(new object[]
	                    {
	                        info.Code,
                            info.CodeName
	                    });
                    }
                }
            }
            return dataList;
        }

        private IList<object[]> LoadCombo35(BindVarCollection varlist)
        {
            IList<object[]> dataList = new List<object[]>();
            if (comboListResult.ExecutionStatus == ExecutionStatus.Success)
            {
                List<ComboListItemInfo> cboList = comboListResult.CboList35;
                if (cboList != null && cboList.Count > 0)
                {
                    foreach (ComboListItemInfo info in cboList)
                    {
                        dataList.Add(new object[]
	                    {
	                        info.Code,
                            info.CodeName
	                    });
                    }
                }
            }
            return dataList;
        }

        private IList<object[]> LoadCombo32(BindVarCollection varlist)
        {
            IList<object[]> dataList = new List<object[]>();
            if (comboListResult.ExecutionStatus == ExecutionStatus.Success)
            {
                List<ComboListItemInfo> cboList = comboListResult.CboList32;
                if (cboList != null && cboList.Count > 0)
                {
                    foreach (ComboListItemInfo info in cboList)
                    {
                        dataList.Add(new object[]
	                    {
	                        info.Code,
                            info.CodeName
	                    });
                    }
                }
            }
            return dataList;
        }

        #region MED-14155

        private string mHospCode = "";

        private void ApplyMultiHospital()
        {
            if (UserInfo.AdminType == AdminType.SuperAdmin)
            {
                // Show Findbox hospital
                pnlTop.Dock = DockStyle.Top;
                pnlTop.Visible = true;

                // FindWorker
                fwkHospitalID.ExecuteQuery = GetFwkHospitalId;
            }
            else
            {
                pnlTop.Dock = DockStyle.None;
                pnlTop.Visible = false;
                this.mHospCode = UserInfo.HospCode;
            }
        }

        private void fbxHospitalID_FindClick(object sender, CancelEventArgs e)
        {
            this.fwkHospitalID.ColInfos.Clear();
            this.fwkHospitalID.ColInfos.Add("code", Resources.FindBox_Title_Code, FindColType.String, 80, 0, true, FilterType.No);
            this.fwkHospitalID.ColInfos.Add("code_name", Resources.FindBox_Title_Name, FindColType.String, 200, 0, true, FilterType.No);
        }

        private void fbxHospitalID_DataValidating(object sender, DataValidatingEventArgs e)
        {
            this.mHospCode = fbxHospitalID.Text;

            ADM103UValidateFwkHospitalArgs args = new ADM103UValidateFwkHospitalArgs();
            args.HospCode = this.mHospCode;
            ADM103UValidateFwkHospitalResult result = CloudService.Instance.Submit<ADM103UValidateFwkHospitalResult, ADM103UValidateFwkHospitalArgs>(args);

            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                this.dbxHospitalNm.SetDataValue(result.HospName);
            }
            else
            {
                this.dbxHospitalNm.ResetData();
            }

            this.xButtonList1.PerformClick(FunctionType.Query);
        }

        private void fbxID_FindSelected(object sender, FindEventArgs e)
        {
            XFindBox control = (XFindBox)sender;
            XDisplayBox dbxBox = this.dbxHospitalNm;
            dbxBox = this.dbxHospitalNm;
            if (TypeCheck.IsNull(e.ReturnValues) == true)
            {
                dbxBox.SetDataValue("");
            }
            else
            {
                dbxBox.SetDataValue(e.ReturnValues[1].ToString());
                this.mHospCode = e.ReturnValues[0].ToString();
                this.xButtonList1.PerformClick(FunctionType.Query);
            }
        }

        private IList<object[]> GetFwkHospitalId(BindVarCollection bvc)
        {
            List<object[]> res = new List<object[]>();

            ADM103UGetFwkHospitalResult result = CloudService.Instance.Submit<ADM103UGetFwkHospitalResult, ADM103UGetFwkHospitalArgs>(new ADM103UGetFwkHospitalArgs());
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                result.HospList.ForEach(delegate(ComboListItemInfo item)
                {
                    res.Add(new object[] { item.Code, item.CodeName });
                });
            }

            return res;
        }

        #endregion
    }
}


/// Edit End 20100618 河中 ///