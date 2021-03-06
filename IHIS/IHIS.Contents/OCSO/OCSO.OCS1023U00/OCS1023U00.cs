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
using IHIS.CloudConnector.Contracts.Arguments.Ocso;
using IHIS.CloudConnector.Contracts.Models.Ocso;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.Ocso;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.Framework;
using IHIS.OCSO.Properties;

#endregion

namespace IHIS.OCSO
{
	/// <summary>
	/// OCS1023U00에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class OCS1023U00 : IHIS.Framework.XScreen
	{
		#region [OCS Library]
		//private IHIS.OCS.OrderBiz  mOrderBiz  = null;         // OCS 그룹 Business 라이브러리
		//private IHIS.OCS.OrderFunc mOrderFunc = null;         // OCS 그룹 Function 라이브러리		
		//private IHIS.OCS.HangmogInfo mHangmogInfo = null;     // OCS 항목정보 그룹 라이브러리
		//private IHIS.OCS.InputControl mInputControl = null;   // 입력제어 그룹 라이브러리 
		#endregion

		#region [Instance Variable]		
		//Message처리
		string mbxMsg = "", mbxCap = "";	

		//등록번호
		private string mBunho = "";
		//진료과
		private string mGwa = "";	

        // Parameter　　*주가
        private string mAutoClose = "N";

        // Parameter
        private string mInputTab = "%";

		//OCS1023_SEQ
		private string mSeq = string.Empty;
		#endregion

		#region 자동생성
		private IHIS.Framework.XPanel xPanel1;
		private IHIS.Framework.XButtonList xButtonList1;
		private IHIS.Framework.XButton btnProcess;
		private IHIS.Framework.XEditGridCell xEditGridCell10;
		private IHIS.Framework.XEditGridCell xEditGridCell11;
		private IHIS.Framework.XEditGridCell xEditGridCell12;
		private IHIS.Framework.XEditGridCell xEditGridCell13;
		private IHIS.Framework.XEditGridCell xEditGridCell14;
		private IHIS.Framework.XEditGridCell xEditGridCell15;
		private IHIS.Framework.XEditGridCell xEditGridCell16;
		private IHIS.Framework.XEditGridCell xEditGridCell17;
		private IHIS.Framework.XEditGridCell xEditGridCell18;
		private IHIS.Framework.XEditGridCell xEditGridCell8;
		private IHIS.Framework.XEditGridCell xEditGridCell19;
		private IHIS.Framework.XEditGridCell xEditGridCell20;
		private IHIS.Framework.XEditGridCell xEditGridCell21;
		private IHIS.Framework.XEditGridCell xEditGridCell94;
		private IHIS.Framework.XEditGridCell xEditGridCell95;
		private IHIS.Framework.XEditGridCell xEditGridCell96;
		private IHIS.Framework.XEditGridCell xEditGridCell97;
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
		private IHIS.Framework.XEditGridCell xEditGridCell106;
		private IHIS.Framework.XEditGridCell xEditGridCell40;
		private IHIS.Framework.XEditGridCell xEditGridCell67;
		private IHIS.Framework.XEditGridCell xEditGridCell41;
		private IHIS.Framework.XEditGridCell xEditGridCell42;
		private IHIS.Framework.XEditGridCell xEditGridCell103;
		private IHIS.Framework.XEditGridCell xEditGridCell98;
		private IHIS.Framework.XEditGridCell xEditGridCell116;
		private IHIS.Framework.XEditGridCell xEditGridCell43;
		private IHIS.Framework.XEditGridCell xEditGridCell44;
		private IHIS.Framework.XEditGridCell xEditGridCell45;
		private IHIS.Framework.XEditGridCell xEditGridCell46;
		private IHIS.Framework.XEditGridCell xEditGridCell47;
		private IHIS.Framework.XEditGridCell xEditGridCell48;
		private IHIS.Framework.XEditGridCell xEditGridCell49;
		private IHIS.Framework.XEditGridCell xEditGridCell50;
		private IHIS.Framework.XEditGridCell xEditGridCell51;
		private IHIS.Framework.XEditGridCell xEditGridCell52;
		private IHIS.Framework.XEditGridCell xEditGridCell53;
		private IHIS.Framework.XEditGridCell xEditGridCell54;
		private IHIS.Framework.XEditGridCell xEditGridCell55;
		private IHIS.Framework.XEditGridCell xEditGridCell56;
		private IHIS.Framework.XEditGridCell xEditGridCell57;
		private IHIS.Framework.XEditGridCell xEditGridCell58;
		private IHIS.Framework.XEditGridCell xEditGridCell59;
		private IHIS.Framework.XEditGridCell xEditGridCell60;
		private IHIS.Framework.XEditGridCell xEditGridCell61;
		private IHIS.Framework.XEditGridCell xEditGridCell62;
		private IHIS.Framework.XEditGridCell xEditGridCell63;
		private IHIS.Framework.XEditGridCell xEditGridCell64;
		private IHIS.Framework.XEditGridCell xEditGridCell65;
		private IHIS.Framework.XEditGridCell xEditGridCell66;
		private IHIS.Framework.XEditGridCell xEditGridCell99;
		private IHIS.Framework.XEditGridCell xEditGridCell100;
		private IHIS.Framework.XEditGridCell xEditGridCell101;
		private IHIS.Framework.XEditGridCell xEditGridCell102;
        private IHIS.Framework.XEditGridCell xEditGridCell104;
		private IHIS.Framework.XEditGridCell xEditGridCell108;
		private IHIS.Framework.XEditGridCell xEditGridCell109;
		private IHIS.Framework.XEditGridCell xEditGridCell107;
		private IHIS.Framework.XGridHeader xGridHeader1;
		private IHIS.Framework.XEditGrid grdOCS1023;
		private IHIS.Framework.XEditGridCell xEditGridCell1;
		private IHIS.Framework.XButton btnDelete;
		private IHIS.Framework.XEditGridCell xEditGridCell2;
		private IHIS.Framework.XGridHeader xGridHeader2;
		private IHIS.Framework.XLabel lblSelectOrder;
		private IHIS.Framework.MultiLayout dloSelectOCS1023;
        private XEditGridCell xEditGridCell3;
        private XEditGridCell xEditGridCell4;
        private XEditGridCell xEditGridCell5;
        private XEditGridCell xEditGridCell6;
        private XEditGridCell xEditGridCell7;
        private XEditGridCell xEditGridCell9;
        private XEditGridCell xEditGridCell68;
        private XCheckBox cbxGeneric_YN;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion

		public OCS1023U00()
		{
			// 이 호출은 Windows Form 디자이너에 필요합니다.
			InitializeComponent();

			//this.mOrderBiz  = new IHIS.OCS.OrderBiz();                      // OCS 그룹 Business 라이브러리
			//this.mOrderFunc = new IHIS.OCS.OrderFunc();                     // OCS 그룹 Function 라이브러리			
			//this.mHangmogInfo = new IHIS.OCS.HangmogInfo(this.ScreenID);    // OCS 항목정보 그룹 라이브러리
			//this.mInputControl = new IHIS.OCS.InputControl(this.ScreenID);  // 입력제어 그룹 라이브러리

            //this.SaveLayoutList.Add(this.grdOCS1023);
            //this.grdOCS1023.SavePerformer = new XSavePerformer(this);

            this.grdOCS1023.ParamList = new List<string>(new String[] { "f_bunho", "f_gwa", "f_input_tab", "f_generic_yn" });
		    this.grdOCS1023.ExecuteQuery = LoadDataGrdOCS1023;
		}

	    #region CloudService

        /// <summary>
        /// get data for grdOCS1023
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
	    private List<object[]> LoadDataGrdOCS1023(BindVarCollection bc)
	    {
	        List<object[]> res = new List<object[]>();
	        OCS1023U00GrdOCS1023Args args = new OCS1023U00GrdOCS1023Args();
	        args.GenericYn = bc["f_generic_yn"] != null ? bc["f_generic_yn"].VarValue : "";
	        args.Bunho = bc["f_bunho"] != null ? bc["f_bunho"].VarValue : "";
	        args.Gwa = bc["f_gwa"] != null ? bc["f_gwa"].VarValue : "";
	        args.InputTab = bc["f_input_tab"] != null ? bc["f_input_tab"].VarValue : "";
	        OCS1023U00GrdOCS1023Result result =
	            CloudService.Instance.Submit<OCS1023U00GrdOCS1023Result, OCS1023U00GrdOCS1023Args>(args);
	        if (result.ExecutionStatus == ExecutionStatus.Success)
	        {
	            foreach (OCS1023U00GrdOCS1023Info item in result.ListInfo)
	            {
	                object[] objects =
	                {
	                    item.Bunho,
	                    item.Gwa,
	                    item.Pkocs1023,
	                    item.GroupSer,
	                    item.Seq,
	                    item.HangmogCode,
	                    item.HangmogName,
	                    item.SpecimenCode,
	                    item.Suryang,
	                    item.OrdDanui,
	                    item.OrdDanuiName,
	                    item.DvTime,
	                    item.Dv,
	                    item.Dv1,
	                    item.Dv2,
	                    item.Dv3,
	                    item.Dv4,
	                    item.Nalsu,
	                    item.Jusa,
	                    item.BogyongCode,
	                    item.Emergency,
	                    item.Pay,
	                    item.FluidYn,
	                    item.TpnYn,
	                    item.AntiCancerYn,
	                    item.PortableYn,
	                    item.PowderYn,
	                    item.SpecialYn,
	                    item.ActDoctor,
	                    item.Muhyo,
	                    item.Symya,
	                    item.SpecialRate,
	                    item.ActDoctorName,
	                    item.PrnYn,
	                    item.PrepareYn,
	                    item.OrderGubun,
	                    item.OrderGubunBas,
	                    item.OrderGubunName,
	                    item.OrderRemark,
	                    item.NurseRemark,
	                    item.MixGroup,
	                    item.WonyoiOrderYn,
	                    item.WonnaeSayuCode,
	                    item.InputControl,
	                    item.SugaYn,
	                    item.JaeryoYn,
	                    item.SpecialCheck,
	                    item.PrisName,
	                    item.SlipCode,
	                    item.EmergencyCheck,
	                    item.SpecimenYn,
	                    item.MultiGumsaYn,
	                    item.SpecimenCrYn,
	                    item.SuryangCrYn,
	                    item.OrdDanuiCrYn,
	                    item.DvTimeCrYn,
	                    item.DvCrYn,
	                    item.NalsuCrYn,
	                    item.JusaCrYn,
	                    item.BogyongCodeCrYn,
	                    item.ToiwonDrgCrYn,
	                    item.TpnCrYn,
	                    item.AntiCancerCrYn,
	                    item.FluidCrYn,
	                    item.PortableCrYn,
	                    item.DonerCrYn,
	                    item.AmtCrYn,
	                    item.SpecimenName,
	                    item.JusaName,
	                    item.PayName,
	                    item.BogyongName,
	                    item.BunCode,
	                    item.LimitSuryang,
	                    item.LimitNalsu,
	                    item.BulyongCheck,
	                    item.InputTab,
	                    item.Dv5,
	                    item.Dv6,
	                    item.Dv7,
	                    item.Dv8,
	                    item.GeneralDispYn,
	                    item.GenericName
	                };
	                res.Add(objects);
	            }
	        }
	        return res;
	    }

        /// <summary>
        /// save gedOCS1023
        /// </summary>
        /// <returns></returns>
        private bool SaveGrdOCS1023()
        {
            List<OCS1023U00GrdOCS1023Info> inputList = GetListFromGrdOCS1023();
            if (inputList.Count == 0)
            {
                return true;
            }
            OCS1023U00SaveLayoutArgs args = new OCS1023U00SaveLayoutArgs(UserInfo.UserID, inputList);
            UpdateResult result = CloudService.Instance.Submit<UpdateResult, OCS1023U00SaveLayoutArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                return result.Result;
            }

            return false;
        }

        /// <summary>
        /// get list of object from grdOCS1023
        /// </summary>
        /// <returns></returns>
	    private List<OCS1023U00GrdOCS1023Info> GetListFromGrdOCS1023()
	    {
	        List<OCS1023U00GrdOCS1023Info> dataList = new List<OCS1023U00GrdOCS1023Info>();
            for (int i = 0; i < grdOCS1023.RowCount; i++)
            {
                if (grdOCS1023.GetRowState(i) == DataRowState.Unchanged)
                {
                    continue;
                }
                OCS1023U00GrdOCS1023Info info = new OCS1023U00GrdOCS1023Info();
                info.Bunho = grdOCS1023.GetItemString(i, "bunho");
                info.Gwa = grdOCS1023.GetItemString(i, "gwa");
                info.Pkocs1023 = grdOCS1023.GetItemString(i, "pkocs1023");
                info.GroupSer = grdOCS1023.GetItemString(i, "group_ser");
                info.Seq = grdOCS1023.GetItemString(i, "seq");
                info.HangmogCode = grdOCS1023.GetItemString(i, "hangmog_code");
                info.HangmogName = grdOCS1023.GetItemString(i, "hangmog_name");
                info.SpecimenCode = grdOCS1023.GetItemString(i, "specimen_code");
                info.Suryang = grdOCS1023.GetItemString(i, "suryang");
                info.OrdDanui = grdOCS1023.GetItemString(i, "ord_danui");
                info.OrdDanuiName = grdOCS1023.GetItemString(i, "ord_danui_name");
                info.DvTime = grdOCS1023.GetItemString(i, "dv_time");
                info.Dv = grdOCS1023.GetItemString(i, "dv");
                info.Dv1 = grdOCS1023.GetItemString(i, "dv_1");
                info.Dv2 = grdOCS1023.GetItemString(i, "dv_2");
                info.Dv3 = grdOCS1023.GetItemString(i, "dv_3");
                info.Dv4 = grdOCS1023.GetItemString(i, "dv_4");
                info.Nalsu = grdOCS1023.GetItemString(i, "nalsu");
                info.Jusa = grdOCS1023.GetItemString(i, "jusa");
                info.BogyongCode = grdOCS1023.GetItemString(i, "bogyong_code");
                info.Emergency = grdOCS1023.GetItemString(i, "emergency");
                info.Pay = grdOCS1023.GetItemString(i, "pay");
                info.FluidYn = grdOCS1023.GetItemString(i, "fluid_yn");
                info.TpnYn = grdOCS1023.GetItemString(i, "tpn_yn");
                info.AntiCancerYn = grdOCS1023.GetItemString(i, "anti_cancer_yn");
                info.PortableYn = grdOCS1023.GetItemString(i, "portable_yn");
                info.PowderYn = grdOCS1023.GetItemString(i, "powder_yn");
                info.SpecialYn = grdOCS1023.GetItemString(i, "special_yn");
                info.ActDoctor = grdOCS1023.GetItemString(i, "act_doctor");
                info.Muhyo = grdOCS1023.GetItemString(i, "muhyo");
                info.Symya = grdOCS1023.GetItemString(i, "symya");
                info.SpecialRate = grdOCS1023.GetItemString(i, "special_rate");
                info.ActDoctorName = grdOCS1023.GetItemString(i, "act_doctor_name");
                info.PrnYn = grdOCS1023.GetItemString(i, "prn_yn");
                info.PrepareYn = grdOCS1023.GetItemString(i, "prepare_yn");
                info.OrderGubun = grdOCS1023.GetItemString(i, "order_gubun");
                info.OrderGubunBas = grdOCS1023.GetItemString(i, "order_gubun_bas");
                info.OrderGubunName = grdOCS1023.GetItemString(i, "order_gubun_bas_name");
                info.OrderRemark = grdOCS1023.GetItemString(i, "order_remark");
                info.NurseRemark = grdOCS1023.GetItemString(i, "nurse_remark");
                info.MixGroup = grdOCS1023.GetItemString(i, "mix_group");
                info.WonyoiOrderYn = grdOCS1023.GetItemString(i, "wonyoi_order_yn");
                info.WonnaeSayuCode = grdOCS1023.GetItemString(i, "wonnae_sayu_code");
                info.InputControl = grdOCS1023.GetItemString(i, "input_control");
                info.SugaYn = grdOCS1023.GetItemString(i, "suga_yn");
                info.JaeryoYn = grdOCS1023.GetItemString(i, "jaeryo_yn");
                info.SpecialCheck = grdOCS1023.GetItemString(i, "special_check");
                info.PrisName = grdOCS1023.GetItemString(i, "pris_name");
                info.SlipCode = grdOCS1023.GetItemString(i, "slip_code");
                info.EmergencyCheck = grdOCS1023.GetItemString(i, "emergency_check");
                info.SpecimenYn = grdOCS1023.GetItemString(i, "specimen_yn");
                info.MultiGumsaYn = grdOCS1023.GetItemString(i, "multi_gumsa_yn");
                info.SpecimenCrYn = grdOCS1023.GetItemString(i, "specimen_cr_yn");
                info.SuryangCrYn = grdOCS1023.GetItemString(i, "suryang_cr_yn");
                info.OrdDanuiCrYn = grdOCS1023.GetItemString(i, "ord_danui_cr_yn");
                info.DvTimeCrYn = grdOCS1023.GetItemString(i, "dv_time_cr_yn");
                info.DvCrYn = grdOCS1023.GetItemString(i, "dv_cr_yn");
                info.NalsuCrYn = grdOCS1023.GetItemString(i, "nalsu_cr_yn");
                info.JusaCrYn = grdOCS1023.GetItemString(i, "jusa_cr_yn");
                info.BogyongCodeCrYn = grdOCS1023.GetItemString(i, "bogyong_code_cr_yn");
                info.ToiwonDrgCrYn = grdOCS1023.GetItemString(i, "toiwon_drg_cr_yn");
                info.TpnCrYn = grdOCS1023.GetItemString(i, "tpn_cr_yn");
                info.AntiCancerCrYn = grdOCS1023.GetItemString(i, "anti_cancer_cr_yn");
                info.FluidCrYn = grdOCS1023.GetItemString(i, "fluid_cr_yn");
                info.PortableCrYn = grdOCS1023.GetItemString(i, "portable_cr_yn");
                info.DonerCrYn = grdOCS1023.GetItemString(i, "doner_cr_yn");
                info.AmtCrYn = grdOCS1023.GetItemString(i, "amt_cr_yn");
                info.SpecimenName = grdOCS1023.GetItemString(i, "specimen_name");
                info.JusaName = grdOCS1023.GetItemString(i, "jusa_name");
                info.PayName = grdOCS1023.GetItemString(i, "pay_name");
                info.BogyongName = grdOCS1023.GetItemString(i, "bogyong_name");
                info.BunCode = grdOCS1023.GetItemString(i, "bun_code");
                info.LimitSuryang = grdOCS1023.GetItemString(i, "limit_suryang");
                info.LimitNalsu = grdOCS1023.GetItemString(i, "limit_nalsu");
                info.BulyongCheck = grdOCS1023.GetItemString(i, "bulyong_check");
                info.InputTab = grdOCS1023.GetItemString(i, "input_tab");
                info.Dv5 = grdOCS1023.GetItemString(i, "dv_5");
                info.Dv6 = grdOCS1023.GetItemString(i, "dv_6");
                info.Dv7 = grdOCS1023.GetItemString(i, "dv_7");
                info.Dv8 = grdOCS1023.GetItemString(i, "dv_8");
                info.GeneralDispYn = grdOCS1023.GetItemString(i, "general_disp_yn");
                info.GenericName = grdOCS1023.GetItemString(i, "generic_name");
                info.RowState = grdOCS1023.GetRowState(i).ToString();

                dataList.Add(info);
            }

            if (grdOCS1023.DeletedRowCount > 0)
            {
                foreach (DataRow row in grdOCS1023.DeletedRowTable.Rows)
                {
                    OCS1023U00GrdOCS1023Info info = new OCS1023U00GrdOCS1023Info();
                    info.Pkocs1023 = row["pkocs1023"].ToString();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OCS1023U00));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.cbxGeneric_YN = new IHIS.Framework.XCheckBox();
            this.btnDelete = new IHIS.Framework.XButton();
            this.btnProcess = new IHIS.Framework.XButton();
            this.xButtonList1 = new IHIS.Framework.XButtonList();
            this.grdOCS1023 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell18 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell19 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell20 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell21 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell94 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell95 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell96 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell97 = new IHIS.Framework.XEditGridCell();
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
            this.xEditGridCell106 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell40 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell67 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell41 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell42 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell103 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell98 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell116 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell43 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell44 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell45 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell46 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell47 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell48 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell49 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell50 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell51 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell52 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell53 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell54 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell55 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell56 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell57 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell58 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell59 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell60 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell61 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell62 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell63 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell64 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell65 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell66 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell99 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell100 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell101 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell102 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell104 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell108 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell109 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell68 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell107 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xGridHeader2 = new IHIS.Framework.XGridHeader();
            this.xGridHeader1 = new IHIS.Framework.XGridHeader();
            this.lblSelectOrder = new IHIS.Framework.XLabel();
            this.dloSelectOCS1023 = new IHIS.Framework.MultiLayout();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS1023)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dloSelectOCS1023)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            resources.ApplyResources(this.ImageList, "ImageList");
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "");
            this.ImageList.Images.SetKeyName(1, "");
            // 
            // xPanel1
            // 
            this.xPanel1.AccessibleDescription = null;
            this.xPanel1.AccessibleName = null;
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.BackgroundImage = null;
            this.xPanel1.Controls.Add(this.cbxGeneric_YN);
            this.xPanel1.Controls.Add(this.btnDelete);
            this.xPanel1.Controls.Add(this.btnProcess);
            this.xPanel1.Controls.Add(this.xButtonList1);
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Font = null;
            this.xPanel1.Name = "xPanel1";
            // 
            // cbxGeneric_YN
            // 
            this.cbxGeneric_YN.AccessibleDescription = null;
            this.cbxGeneric_YN.AccessibleName = null;
            resources.ApplyResources(this.cbxGeneric_YN, "cbxGeneric_YN");
            this.cbxGeneric_YN.BackgroundImage = null;
            this.cbxGeneric_YN.Name = "cbxGeneric_YN";
            this.cbxGeneric_YN.UseVisualStyleBackColor = false;
            this.cbxGeneric_YN.CheckedChanged += new System.EventHandler(this.cbxGeneric_YN_CheckedChanged);
            // 
            // btnDelete
            // 
            this.btnDelete.AccessibleDescription = null;
            this.btnDelete.AccessibleName = null;
            resources.ApplyResources(this.btnDelete, "btnDelete");
            this.btnDelete.BackgroundImage = null;
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnProcess
            // 
            this.btnProcess.AccessibleDescription = null;
            this.btnProcess.AccessibleName = null;
            resources.ApplyResources(this.btnProcess, "btnProcess");
            this.btnProcess.BackgroundImage = null;
            this.btnProcess.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProcess.Image = ((System.Drawing.Image)(resources.GetObject("btnProcess.Image")));
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // xButtonList1
            // 
            this.xButtonList1.AccessibleDescription = null;
            this.xButtonList1.AccessibleName = null;
            resources.ApplyResources(this.xButtonList1, "xButtonList1");
            this.xButtonList1.BackgroundImage = null;
            this.xButtonList1.IsVisibleReset = false;
            this.xButtonList1.Name = "xButtonList1";
            this.xButtonList1.PerformerType = IHIS.Framework.FunctionPerformerType.EntryS;
            this.xButtonList1.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.xButtonList1_ButtonClick);
            // 
            // grdOCS1023
            // 
            this.grdOCS1023.AddedHeaderLine = 1;
            resources.ApplyResources(this.grdOCS1023, "grdOCS1023");
            this.grdOCS1023.ApplyPaintEventToAllColumn = true;
            this.grdOCS1023.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell10,
            this.xEditGridCell11,
            this.xEditGridCell12,
            this.xEditGridCell13,
            this.xEditGridCell14,
            this.xEditGridCell15,
            this.xEditGridCell16,
            this.xEditGridCell17,
            this.xEditGridCell18,
            this.xEditGridCell8,
            this.xEditGridCell19,
            this.xEditGridCell20,
            this.xEditGridCell21,
            this.xEditGridCell94,
            this.xEditGridCell95,
            this.xEditGridCell96,
            this.xEditGridCell97,
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
            this.xEditGridCell106,
            this.xEditGridCell40,
            this.xEditGridCell67,
            this.xEditGridCell41,
            this.xEditGridCell42,
            this.xEditGridCell103,
            this.xEditGridCell98,
            this.xEditGridCell116,
            this.xEditGridCell43,
            this.xEditGridCell44,
            this.xEditGridCell45,
            this.xEditGridCell46,
            this.xEditGridCell47,
            this.xEditGridCell48,
            this.xEditGridCell49,
            this.xEditGridCell50,
            this.xEditGridCell51,
            this.xEditGridCell52,
            this.xEditGridCell53,
            this.xEditGridCell54,
            this.xEditGridCell55,
            this.xEditGridCell56,
            this.xEditGridCell57,
            this.xEditGridCell58,
            this.xEditGridCell59,
            this.xEditGridCell60,
            this.xEditGridCell61,
            this.xEditGridCell62,
            this.xEditGridCell63,
            this.xEditGridCell64,
            this.xEditGridCell65,
            this.xEditGridCell66,
            this.xEditGridCell99,
            this.xEditGridCell100,
            this.xEditGridCell101,
            this.xEditGridCell102,
            this.xEditGridCell104,
            this.xEditGridCell108,
            this.xEditGridCell109,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell6,
            this.xEditGridCell7,
            this.xEditGridCell9,
            this.xEditGridCell68,
            this.xEditGridCell107,
            this.xEditGridCell1});
            this.grdOCS1023.ColPerLine = 10;
            this.grdOCS1023.ColResizable = true;
            this.grdOCS1023.Cols = 11;
            this.grdOCS1023.ControlBinding = true;
            this.grdOCS1023.EnableMultiSelection = true;
            this.grdOCS1023.ExecuteQuery = null;
            this.grdOCS1023.FixedCols = 1;
            this.grdOCS1023.FixedRows = 2;
            this.grdOCS1023.FocusColumnName = "hangmog_code";
            this.grdOCS1023.HeaderHeights.Add(28);
            this.grdOCS1023.HeaderHeights.Add(0);
            this.grdOCS1023.HeaderInfos.AddRange(new IHIS.Framework.XGridHeader[] {
            this.xGridHeader2});
            this.grdOCS1023.Name = "grdOCS1023";
            this.grdOCS1023.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdOCS1023.ParamList")));
            this.grdOCS1023.QuerySQL = resources.GetString("grdOCS1023.QuerySQL");
            this.grdOCS1023.ReadOnly = true;
            this.grdOCS1023.RowHeaderDrawMode = IHIS.Framework.XCellDrawMode.Vertical;
            this.grdOCS1023.RowHeaderVisible = true;
            this.grdOCS1023.Rows = 3;
            this.grdOCS1023.RowStateCheckOnPaint = false;
            this.grdOCS1023.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
            this.grdOCS1023.SelectionModeChangeable = true;
            this.grdOCS1023.TogglingRowSelection = true;
            this.grdOCS1023.ToolTipActive = true;
            this.grdOCS1023.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdOCS1023_QueryEnd);
            this.grdOCS1023.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdOCS1023_MouseDown);
            this.grdOCS1023.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdOCS1023_RowFocusChanged);
            this.grdOCS1023.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdOCS1023_QueryStarting);
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "bunho";
            this.xEditGridCell10.Col = -1;
            this.xEditGridCell10.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell10, "xEditGridCell10");
            this.xEditGridCell10.IsNotNull = true;
            this.xEditGridCell10.IsUpdatable = false;
            this.xEditGridCell10.IsVisible = false;
            this.xEditGridCell10.Row = -1;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "gwa";
            this.xEditGridCell11.Col = -1;
            this.xEditGridCell11.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell11, "xEditGridCell11");
            this.xEditGridCell11.IsNotNull = true;
            this.xEditGridCell11.IsUpdatable = false;
            this.xEditGridCell11.IsVisible = false;
            this.xEditGridCell11.Row = -1;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellName = "pkocs1023";
            this.xEditGridCell12.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell12.Col = -1;
            this.xEditGridCell12.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell12, "xEditGridCell12");
            this.xEditGridCell12.IsUpdatable = false;
            this.xEditGridCell12.IsVisible = false;
            this.xEditGridCell12.Row = -1;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell13.CellLen = 2;
            this.xEditGridCell13.CellName = "group_ser";
            this.xEditGridCell13.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell13.CellWidth = 22;
            this.xEditGridCell13.Col = -1;
            this.xEditGridCell13.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell13, "xEditGridCell13");
            this.xEditGridCell13.IsVisible = false;
            this.xEditGridCell13.Row = -1;
            this.xEditGridCell13.RowGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellName = "seq";
            this.xEditGridCell14.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell14.Col = -1;
            this.xEditGridCell14.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell14, "xEditGridCell14");
            this.xEditGridCell14.IsUpdatable = false;
            this.xEditGridCell14.IsVisible = false;
            this.xEditGridCell14.Row = -1;
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell15.AutoTabDataSelected = true;
            this.xEditGridCell15.CellLen = 20;
            this.xEditGridCell15.CellName = "hangmog_code";
            this.xEditGridCell15.CellWidth = 86;
            this.xEditGridCell15.Col = 2;
            this.xEditGridCell15.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell15.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell15, "xEditGridCell15");
            this.xEditGridCell15.ImeMode = IHIS.Framework.ColumnImeMode.Hiragana;
            this.xEditGridCell15.IsNotNull = true;
            this.xEditGridCell15.IsUpdatable = false;
            this.xEditGridCell15.RowGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell15.RowSpan = 2;
            this.xEditGridCell15.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell16.CellLen = 80;
            this.xEditGridCell16.CellName = "hangmog_name";
            this.xEditGridCell16.CellWidth = 295;
            this.xEditGridCell16.Col = 3;
            this.xEditGridCell16.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell16, "xEditGridCell16");
            this.xEditGridCell16.IsReadOnly = true;
            this.xEditGridCell16.IsUpdatable = false;
            this.xEditGridCell16.RowGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell16.RowSpan = 2;
            this.xEditGridCell16.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell17.AutoTabDataSelected = true;
            this.xEditGridCell17.CellLen = 3;
            this.xEditGridCell17.CellName = "specimen_code";
            this.xEditGridCell17.CellWidth = 45;
            this.xEditGridCell17.Col = -1;
            this.xEditGridCell17.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell17, "xEditGridCell17");
            this.xEditGridCell17.InitValue = "*";
            this.xEditGridCell17.IsVisible = false;
            this.xEditGridCell17.Row = -1;
            this.xEditGridCell17.RowGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell18.CellName = "suryang";
            this.xEditGridCell18.CellWidth = 66;
            this.xEditGridCell18.Col = 4;
            this.xEditGridCell18.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.xEditGridCell18.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell18.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell18, "xEditGridCell18");
            this.xEditGridCell18.InitValue = "1";
            this.xEditGridCell18.MaxDropDownItems = 10;
            this.xEditGridCell18.RowGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell18.RowSpan = 2;
            this.xEditGridCell18.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell18.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellLen = 6;
            this.xEditGridCell8.CellName = "ord_danui";
            this.xEditGridCell8.Col = -1;
            this.xEditGridCell8.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            this.xEditGridCell8.IsUpdatable = false;
            this.xEditGridCell8.IsVisible = false;
            this.xEditGridCell8.Row = -1;
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell19.CellLen = 100;
            this.xEditGridCell19.CellName = "ord_danui_name";
            this.xEditGridCell19.CellWidth = 61;
            this.xEditGridCell19.Col = 5;
            this.xEditGridCell19.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell19.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell19, "xEditGridCell19");
            this.xEditGridCell19.IsUpdCol = false;
            this.xEditGridCell19.RowGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell19.RowSpan = 2;
            this.xEditGridCell19.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            // 
            // xEditGridCell20
            // 
            this.xEditGridCell20.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell20.CellLen = 1;
            this.xEditGridCell20.CellName = "dv_time";
            this.xEditGridCell20.CellWidth = 22;
            this.xEditGridCell20.Col = 6;
            this.xEditGridCell20.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell20, "xEditGridCell20");
            this.xEditGridCell20.InitValue = "*";
            this.xEditGridCell20.Row = 1;
            this.xEditGridCell20.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell20.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            this.xEditGridCell20.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell21.CellName = "dv";
            this.xEditGridCell21.CellWidth = 36;
            this.xEditGridCell21.Col = 7;
            this.xEditGridCell21.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell21, "xEditGridCell21");
            this.xEditGridCell21.InitValue = "1";
            this.xEditGridCell21.Row = 1;
            this.xEditGridCell21.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell21.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            this.xEditGridCell21.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xEditGridCell94
            // 
            this.xEditGridCell94.CellName = "dv_1";
            this.xEditGridCell94.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell94.Col = -1;
            this.xEditGridCell94.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell94, "xEditGridCell94");
            this.xEditGridCell94.IsVisible = false;
            this.xEditGridCell94.Row = -1;
            // 
            // xEditGridCell95
            // 
            this.xEditGridCell95.CellName = "dv_2";
            this.xEditGridCell95.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell95.Col = -1;
            this.xEditGridCell95.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell95, "xEditGridCell95");
            this.xEditGridCell95.IsVisible = false;
            this.xEditGridCell95.Row = -1;
            // 
            // xEditGridCell96
            // 
            this.xEditGridCell96.CellName = "dv_3";
            this.xEditGridCell96.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell96.Col = -1;
            this.xEditGridCell96.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell96, "xEditGridCell96");
            this.xEditGridCell96.IsVisible = false;
            this.xEditGridCell96.Row = -1;
            // 
            // xEditGridCell97
            // 
            this.xEditGridCell97.CellName = "dv_4";
            this.xEditGridCell97.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell97.Col = -1;
            this.xEditGridCell97.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell97, "xEditGridCell97");
            this.xEditGridCell97.IsVisible = false;
            this.xEditGridCell97.Row = -1;
            // 
            // xEditGridCell22
            // 
            this.xEditGridCell22.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell22.CellName = "nalsu";
            this.xEditGridCell22.CellWidth = 46;
            this.xEditGridCell22.Col = -1;
            this.xEditGridCell22.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.xEditGridCell22.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell22, "xEditGridCell22");
            this.xEditGridCell22.InitValue = "1";
            this.xEditGridCell22.IsVisible = false;
            this.xEditGridCell22.MaxDropDownItems = 10;
            this.xEditGridCell22.Row = -1;
            this.xEditGridCell22.RowGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell22.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xEditGridCell23
            // 
            this.xEditGridCell23.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell23.CellLen = 2;
            this.xEditGridCell23.CellName = "jusa";
            this.xEditGridCell23.CellWidth = 46;
            this.xEditGridCell23.Col = -1;
            this.xEditGridCell23.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell23, "xEditGridCell23");
            this.xEditGridCell23.IsVisible = false;
            this.xEditGridCell23.Row = -1;
            this.xEditGridCell23.RowGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            // 
            // xEditGridCell24
            // 
            this.xEditGridCell24.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell24.CellName = "bogyong_code";
            this.xEditGridCell24.CellWidth = 67;
            this.xEditGridCell24.Col = -1;
            this.xEditGridCell24.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell24, "xEditGridCell24");
            this.xEditGridCell24.IsVisible = false;
            this.xEditGridCell24.Row = -1;
            this.xEditGridCell24.RowGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            // 
            // xEditGridCell25
            // 
            this.xEditGridCell25.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell25.CellLen = 1;
            this.xEditGridCell25.CellName = "emergency";
            this.xEditGridCell25.CellWidth = 27;
            this.xEditGridCell25.Col = -1;
            this.xEditGridCell25.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell25, "xEditGridCell25");
            this.xEditGridCell25.IsVisible = false;
            this.xEditGridCell25.Row = -1;
            this.xEditGridCell25.RowGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            // 
            // xEditGridCell26
            // 
            this.xEditGridCell26.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell26.CellLen = 1;
            this.xEditGridCell26.CellName = "pay";
            this.xEditGridCell26.CellWidth = 36;
            this.xEditGridCell26.Col = -1;
            this.xEditGridCell26.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell26, "xEditGridCell26");
            this.xEditGridCell26.InitValue = "0";
            this.xEditGridCell26.IsVisible = false;
            this.xEditGridCell26.Row = -1;
            this.xEditGridCell26.RowGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            // 
            // xEditGridCell27
            // 
            this.xEditGridCell27.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell27.CellLen = 1;
            this.xEditGridCell27.CellName = "fluid_yn";
            this.xEditGridCell27.CellWidth = 43;
            this.xEditGridCell27.Col = -1;
            this.xEditGridCell27.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell27, "xEditGridCell27");
            this.xEditGridCell27.IsVisible = false;
            this.xEditGridCell27.Row = -1;
            this.xEditGridCell27.RowGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell27.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xEditGridCell27.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            // 
            // xEditGridCell28
            // 
            this.xEditGridCell28.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell28.CellLen = 1;
            this.xEditGridCell28.CellName = "tpn_yn";
            this.xEditGridCell28.CellWidth = 38;
            this.xEditGridCell28.Col = -1;
            this.xEditGridCell28.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell28, "xEditGridCell28");
            this.xEditGridCell28.IsVisible = false;
            this.xEditGridCell28.Row = -1;
            this.xEditGridCell28.RowGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell28.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xEditGridCell28.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            // 
            // xEditGridCell29
            // 
            this.xEditGridCell29.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell29.CellLen = 1;
            this.xEditGridCell29.CellName = "anti_cancer_yn";
            this.xEditGridCell29.CellWidth = 52;
            this.xEditGridCell29.Col = -1;
            this.xEditGridCell29.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell29, "xEditGridCell29");
            this.xEditGridCell29.IsVisible = false;
            this.xEditGridCell29.Row = -1;
            this.xEditGridCell29.RowGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell29.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xEditGridCell29.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            // 
            // xEditGridCell30
            // 
            this.xEditGridCell30.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell30.CellLen = 1;
            this.xEditGridCell30.CellName = "portable_yn";
            this.xEditGridCell30.CellWidth = 34;
            this.xEditGridCell30.Col = -1;
            this.xEditGridCell30.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell30, "xEditGridCell30");
            this.xEditGridCell30.IsVisible = false;
            this.xEditGridCell30.Row = -1;
            this.xEditGridCell30.RowGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            // 
            // xEditGridCell31
            // 
            this.xEditGridCell31.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell31.CellLen = 1;
            this.xEditGridCell31.CellName = "powder_yn";
            this.xEditGridCell31.CellWidth = 26;
            this.xEditGridCell31.Col = -1;
            this.xEditGridCell31.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell31, "xEditGridCell31");
            this.xEditGridCell31.IsVisible = false;
            this.xEditGridCell31.Row = -1;
            this.xEditGridCell31.RowGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            // 
            // xEditGridCell32
            // 
            this.xEditGridCell32.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell32.CellLen = 1;
            this.xEditGridCell32.CellName = "special_yn";
            this.xEditGridCell32.CellWidth = 47;
            this.xEditGridCell32.Col = -1;
            this.xEditGridCell32.ExecuteQuery = null;
            this.xEditGridCell32.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell32, "xEditGridCell32");
            this.xEditGridCell32.IsVisible = false;
            this.xEditGridCell32.Row = -1;
            this.xEditGridCell32.RowGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell32.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xEditGridCell32.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            // 
            // xEditGridCell33
            // 
            this.xEditGridCell33.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell33.CellLen = 5;
            this.xEditGridCell33.CellName = "act_doctor";
            this.xEditGridCell33.Col = -1;
            this.xEditGridCell33.ExecuteQuery = null;
            this.xEditGridCell33.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell33, "xEditGridCell33");
            this.xEditGridCell33.IsVisible = false;
            this.xEditGridCell33.Row = -1;
            this.xEditGridCell33.RowGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell33.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xEditGridCell33.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            // 
            // xEditGridCell34
            // 
            this.xEditGridCell34.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell34.CellLen = 1;
            this.xEditGridCell34.CellName = "muhyo";
            this.xEditGridCell34.CellWidth = 21;
            this.xEditGridCell34.Col = -1;
            this.xEditGridCell34.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell34, "xEditGridCell34");
            this.xEditGridCell34.IsVisible = false;
            this.xEditGridCell34.Row = -1;
            // 
            // xEditGridCell35
            // 
            this.xEditGridCell35.CellLen = 1;
            this.xEditGridCell35.CellName = "symya";
            this.xEditGridCell35.Col = -1;
            this.xEditGridCell35.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell35, "xEditGridCell35");
            this.xEditGridCell35.IsUpdatable = false;
            this.xEditGridCell35.IsVisible = false;
            this.xEditGridCell35.Row = -1;
            // 
            // xEditGridCell36
            // 
            this.xEditGridCell36.CellName = "special_rate";
            this.xEditGridCell36.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell36.Col = -1;
            this.xEditGridCell36.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell36, "xEditGridCell36");
            this.xEditGridCell36.InitValue = "0";
            this.xEditGridCell36.IsUpdatable = false;
            this.xEditGridCell36.IsVisible = false;
            this.xEditGridCell36.Row = -1;
            // 
            // xEditGridCell37
            // 
            this.xEditGridCell37.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell37.CellLen = 30;
            this.xEditGridCell37.CellName = "act_doctor_name";
            this.xEditGridCell37.CellWidth = 90;
            this.xEditGridCell37.Col = -1;
            this.xEditGridCell37.ExecuteQuery = null;
            this.xEditGridCell37.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell37, "xEditGridCell37");
            this.xEditGridCell37.IsReadOnly = true;
            this.xEditGridCell37.IsUpdatable = false;
            this.xEditGridCell37.IsVisible = false;
            this.xEditGridCell37.Row = -1;
            this.xEditGridCell37.RowGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell37.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xEditGridCell37.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            // 
            // xEditGridCell38
            // 
            this.xEditGridCell38.CellLen = 1;
            this.xEditGridCell38.CellName = "prn_yn";
            this.xEditGridCell38.Col = -1;
            this.xEditGridCell38.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell38, "xEditGridCell38");
            this.xEditGridCell38.IsUpdatable = false;
            this.xEditGridCell38.IsVisible = false;
            this.xEditGridCell38.Row = -1;
            // 
            // xEditGridCell39
            // 
            this.xEditGridCell39.CellLen = 1;
            this.xEditGridCell39.CellName = "prepare_yn";
            this.xEditGridCell39.Col = -1;
            this.xEditGridCell39.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell39, "xEditGridCell39");
            this.xEditGridCell39.IsUpdatable = false;
            this.xEditGridCell39.IsVisible = false;
            this.xEditGridCell39.Row = -1;
            // 
            // xEditGridCell106
            // 
            this.xEditGridCell106.CellName = "order_gubun";
            this.xEditGridCell106.Col = -1;
            this.xEditGridCell106.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell106, "xEditGridCell106");
            this.xEditGridCell106.IsUpdatable = false;
            this.xEditGridCell106.IsVisible = false;
            this.xEditGridCell106.Row = -1;
            // 
            // xEditGridCell40
            // 
            this.xEditGridCell40.CellLen = 2;
            this.xEditGridCell40.CellName = "order_gubun_bas";
            this.xEditGridCell40.Col = -1;
            this.xEditGridCell40.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell40, "xEditGridCell40");
            this.xEditGridCell40.IsUpdatable = false;
            this.xEditGridCell40.IsVisible = false;
            this.xEditGridCell40.Row = -1;
            // 
            // xEditGridCell67
            // 
            this.xEditGridCell67.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell67.CellName = "order_gubun_bas_name";
            this.xEditGridCell67.CellWidth = 76;
            this.xEditGridCell67.Col = -1;
            this.xEditGridCell67.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell67, "xEditGridCell67");
            this.xEditGridCell67.IsReadOnly = true;
            this.xEditGridCell67.IsUpdatable = false;
            this.xEditGridCell67.IsVisible = false;
            this.xEditGridCell67.Row = -1;
            this.xEditGridCell67.SuppressRepeating = true;
            // 
            // xEditGridCell41
            // 
            this.xEditGridCell41.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell41.CellLen = 2000;
            this.xEditGridCell41.CellName = "order_remark";
            this.xEditGridCell41.Col = -1;
            this.xEditGridCell41.DisplayMemoText = true;
            this.xEditGridCell41.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell41, "xEditGridCell41");
            this.xEditGridCell41.ImeMode = IHIS.Framework.ColumnImeMode.Hiragana;
            this.xEditGridCell41.IsVisible = false;
            this.xEditGridCell41.ReservedMemoClassName = "IHIS.OCS.ReservedComment";
            this.xEditGridCell41.ReservedMemoFileName = "C:\\IHIS\\OCSI\\OCS.Lib.CommonForms.dll";
            this.xEditGridCell41.Row = -1;
            this.xEditGridCell41.ShowReservedMemoButton = true;
            // 
            // xEditGridCell42
            // 
            this.xEditGridCell42.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell42.CellLen = 2000;
            this.xEditGridCell42.CellName = "nurse_remark";
            this.xEditGridCell42.CellWidth = 89;
            this.xEditGridCell42.Col = -1;
            this.xEditGridCell42.DisplayMemoText = true;
            this.xEditGridCell42.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell42, "xEditGridCell42");
            this.xEditGridCell42.ImeMode = IHIS.Framework.ColumnImeMode.Hiragana;
            this.xEditGridCell42.IsVisible = false;
            this.xEditGridCell42.ReservedMemoClassName = "IHIS.OCS.ReservedComment";
            this.xEditGridCell42.ReservedMemoFileName = "C:\\IHIS\\OCSI\\OCS.Lib.CommonForms.dll";
            this.xEditGridCell42.Row = -1;
            this.xEditGridCell42.ShowReservedMemoButton = true;
            // 
            // xEditGridCell103
            // 
            this.xEditGridCell103.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell103.CellLen = 2;
            this.xEditGridCell103.CellName = "mix_group";
            this.xEditGridCell103.CellWidth = 24;
            this.xEditGridCell103.Col = -1;
            this.xEditGridCell103.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell103, "xEditGridCell103");
            this.xEditGridCell103.IsVisible = false;
            this.xEditGridCell103.Row = -1;
            // 
            // xEditGridCell98
            // 
            this.xEditGridCell98.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell98.CellLen = 1;
            this.xEditGridCell98.CellName = "wonyoi_order_yn";
            this.xEditGridCell98.CellWidth = 21;
            this.xEditGridCell98.Col = -1;
            this.xEditGridCell98.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell98, "xEditGridCell98");
            this.xEditGridCell98.IsVisible = false;
            this.xEditGridCell98.Row = -1;
            // 
            // xEditGridCell116
            // 
            this.xEditGridCell116.CellName = "wonnae_sayu_code";
            this.xEditGridCell116.Col = -1;
            this.xEditGridCell116.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell116, "xEditGridCell116");
            this.xEditGridCell116.IsVisible = false;
            this.xEditGridCell116.Row = -1;
            // 
            // xEditGridCell43
            // 
            this.xEditGridCell43.CellLen = 1;
            this.xEditGridCell43.CellName = "input_control";
            this.xEditGridCell43.Col = -1;
            this.xEditGridCell43.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell43, "xEditGridCell43");
            this.xEditGridCell43.IsUpdatable = false;
            this.xEditGridCell43.IsVisible = false;
            this.xEditGridCell43.Row = -1;
            // 
            // xEditGridCell44
            // 
            this.xEditGridCell44.CellLen = 1;
            this.xEditGridCell44.CellName = "suga_yn";
            this.xEditGridCell44.Col = -1;
            this.xEditGridCell44.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell44, "xEditGridCell44");
            this.xEditGridCell44.IsUpdatable = false;
            this.xEditGridCell44.IsUpdCol = false;
            this.xEditGridCell44.IsVisible = false;
            this.xEditGridCell44.Row = -1;
            // 
            // xEditGridCell45
            // 
            this.xEditGridCell45.CellLen = 1;
            this.xEditGridCell45.CellName = "jaeryo_yn";
            this.xEditGridCell45.Col = -1;
            this.xEditGridCell45.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell45, "xEditGridCell45");
            this.xEditGridCell45.IsUpdatable = false;
            this.xEditGridCell45.IsUpdCol = false;
            this.xEditGridCell45.IsVisible = false;
            this.xEditGridCell45.Row = -1;
            // 
            // xEditGridCell46
            // 
            this.xEditGridCell46.CellLen = 1;
            this.xEditGridCell46.CellName = "special_check";
            this.xEditGridCell46.Col = -1;
            this.xEditGridCell46.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell46, "xEditGridCell46");
            this.xEditGridCell46.IsUpdatable = false;
            this.xEditGridCell46.IsUpdCol = false;
            this.xEditGridCell46.IsVisible = false;
            this.xEditGridCell46.Row = -1;
            // 
            // xEditGridCell47
            // 
            this.xEditGridCell47.CellLen = 80;
            this.xEditGridCell47.CellName = "pris_name";
            this.xEditGridCell47.Col = -1;
            this.xEditGridCell47.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell47, "xEditGridCell47");
            this.xEditGridCell47.IsUpdatable = false;
            this.xEditGridCell47.IsUpdCol = false;
            this.xEditGridCell47.IsVisible = false;
            this.xEditGridCell47.Row = -1;
            // 
            // xEditGridCell48
            // 
            this.xEditGridCell48.CellLen = 4;
            this.xEditGridCell48.CellName = "slip_code";
            this.xEditGridCell48.Col = -1;
            this.xEditGridCell48.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell48, "xEditGridCell48");
            this.xEditGridCell48.IsUpdatable = false;
            this.xEditGridCell48.IsUpdCol = false;
            this.xEditGridCell48.IsVisible = false;
            this.xEditGridCell48.Row = -1;
            // 
            // xEditGridCell49
            // 
            this.xEditGridCell49.CellLen = 1;
            this.xEditGridCell49.CellName = "emergency_check";
            this.xEditGridCell49.Col = -1;
            this.xEditGridCell49.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell49, "xEditGridCell49");
            this.xEditGridCell49.IsUpdatable = false;
            this.xEditGridCell49.IsUpdCol = false;
            this.xEditGridCell49.IsVisible = false;
            this.xEditGridCell49.Row = -1;
            // 
            // xEditGridCell50
            // 
            this.xEditGridCell50.CellLen = 1;
            this.xEditGridCell50.CellName = "specimen_yn";
            this.xEditGridCell50.Col = -1;
            this.xEditGridCell50.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell50, "xEditGridCell50");
            this.xEditGridCell50.IsUpdatable = false;
            this.xEditGridCell50.IsUpdCol = false;
            this.xEditGridCell50.IsVisible = false;
            this.xEditGridCell50.Row = -1;
            // 
            // xEditGridCell51
            // 
            this.xEditGridCell51.CellLen = 1;
            this.xEditGridCell51.CellName = "multi_gumsa_yn";
            this.xEditGridCell51.Col = -1;
            this.xEditGridCell51.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell51, "xEditGridCell51");
            this.xEditGridCell51.IsUpdatable = false;
            this.xEditGridCell51.IsUpdCol = false;
            this.xEditGridCell51.IsVisible = false;
            this.xEditGridCell51.Row = -1;
            // 
            // xEditGridCell52
            // 
            this.xEditGridCell52.CellLen = 1;
            this.xEditGridCell52.CellName = "specimen_cr_yn";
            this.xEditGridCell52.Col = -1;
            this.xEditGridCell52.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell52, "xEditGridCell52");
            this.xEditGridCell52.IsUpdatable = false;
            this.xEditGridCell52.IsUpdCol = false;
            this.xEditGridCell52.IsVisible = false;
            this.xEditGridCell52.Row = -1;
            // 
            // xEditGridCell53
            // 
            this.xEditGridCell53.CellLen = 1;
            this.xEditGridCell53.CellName = "suryang_cr_yn";
            this.xEditGridCell53.Col = -1;
            this.xEditGridCell53.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell53, "xEditGridCell53");
            this.xEditGridCell53.IsUpdatable = false;
            this.xEditGridCell53.IsUpdCol = false;
            this.xEditGridCell53.IsVisible = false;
            this.xEditGridCell53.Row = -1;
            // 
            // xEditGridCell54
            // 
            this.xEditGridCell54.CellLen = 1;
            this.xEditGridCell54.CellName = "ord_danui_cr_yn";
            this.xEditGridCell54.Col = -1;
            this.xEditGridCell54.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell54, "xEditGridCell54");
            this.xEditGridCell54.IsUpdatable = false;
            this.xEditGridCell54.IsUpdCol = false;
            this.xEditGridCell54.IsVisible = false;
            this.xEditGridCell54.Row = -1;
            // 
            // xEditGridCell55
            // 
            this.xEditGridCell55.CellLen = 1;
            this.xEditGridCell55.CellName = "dv_time_cr_yn";
            this.xEditGridCell55.Col = -1;
            this.xEditGridCell55.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell55, "xEditGridCell55");
            this.xEditGridCell55.IsUpdatable = false;
            this.xEditGridCell55.IsUpdCol = false;
            this.xEditGridCell55.IsVisible = false;
            this.xEditGridCell55.Row = -1;
            // 
            // xEditGridCell56
            // 
            this.xEditGridCell56.CellLen = 1;
            this.xEditGridCell56.CellName = "dv_cr_yn";
            this.xEditGridCell56.Col = -1;
            this.xEditGridCell56.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell56, "xEditGridCell56");
            this.xEditGridCell56.IsUpdatable = false;
            this.xEditGridCell56.IsUpdCol = false;
            this.xEditGridCell56.IsVisible = false;
            this.xEditGridCell56.Row = -1;
            // 
            // xEditGridCell57
            // 
            this.xEditGridCell57.CellLen = 1;
            this.xEditGridCell57.CellName = "nalsu_cr_yn";
            this.xEditGridCell57.Col = -1;
            this.xEditGridCell57.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell57, "xEditGridCell57");
            this.xEditGridCell57.IsUpdatable = false;
            this.xEditGridCell57.IsUpdCol = false;
            this.xEditGridCell57.IsVisible = false;
            this.xEditGridCell57.Row = -1;
            // 
            // xEditGridCell58
            // 
            this.xEditGridCell58.CellLen = 1;
            this.xEditGridCell58.CellName = "jusa_cr_yn";
            this.xEditGridCell58.Col = -1;
            this.xEditGridCell58.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell58, "xEditGridCell58");
            this.xEditGridCell58.IsUpdatable = false;
            this.xEditGridCell58.IsUpdCol = false;
            this.xEditGridCell58.IsVisible = false;
            this.xEditGridCell58.Row = -1;
            // 
            // xEditGridCell59
            // 
            this.xEditGridCell59.CellLen = 1;
            this.xEditGridCell59.CellName = "bogyong_code_cr_yn";
            this.xEditGridCell59.Col = -1;
            this.xEditGridCell59.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell59, "xEditGridCell59");
            this.xEditGridCell59.IsUpdatable = false;
            this.xEditGridCell59.IsUpdCol = false;
            this.xEditGridCell59.IsVisible = false;
            this.xEditGridCell59.Row = -1;
            // 
            // xEditGridCell60
            // 
            this.xEditGridCell60.CellLen = 1;
            this.xEditGridCell60.CellName = "toiwon_drg_cr_yn";
            this.xEditGridCell60.Col = -1;
            this.xEditGridCell60.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell60, "xEditGridCell60");
            this.xEditGridCell60.IsUpdatable = false;
            this.xEditGridCell60.IsUpdCol = false;
            this.xEditGridCell60.IsVisible = false;
            this.xEditGridCell60.Row = -1;
            // 
            // xEditGridCell61
            // 
            this.xEditGridCell61.CellLen = 1;
            this.xEditGridCell61.CellName = "tpn_cr_yn";
            this.xEditGridCell61.Col = -1;
            this.xEditGridCell61.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell61, "xEditGridCell61");
            this.xEditGridCell61.IsUpdatable = false;
            this.xEditGridCell61.IsUpdCol = false;
            this.xEditGridCell61.IsVisible = false;
            this.xEditGridCell61.Row = -1;
            // 
            // xEditGridCell62
            // 
            this.xEditGridCell62.CellLen = 1;
            this.xEditGridCell62.CellName = "anti_cancer_cr_yn";
            this.xEditGridCell62.Col = -1;
            this.xEditGridCell62.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell62, "xEditGridCell62");
            this.xEditGridCell62.IsUpdatable = false;
            this.xEditGridCell62.IsUpdCol = false;
            this.xEditGridCell62.IsVisible = false;
            this.xEditGridCell62.Row = -1;
            // 
            // xEditGridCell63
            // 
            this.xEditGridCell63.CellLen = 1;
            this.xEditGridCell63.CellName = "fluid_cr_yn";
            this.xEditGridCell63.Col = -1;
            this.xEditGridCell63.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell63, "xEditGridCell63");
            this.xEditGridCell63.IsUpdatable = false;
            this.xEditGridCell63.IsUpdCol = false;
            this.xEditGridCell63.IsVisible = false;
            this.xEditGridCell63.Row = -1;
            // 
            // xEditGridCell64
            // 
            this.xEditGridCell64.CellLen = 1;
            this.xEditGridCell64.CellName = "portable_cr_yn";
            this.xEditGridCell64.Col = -1;
            this.xEditGridCell64.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell64, "xEditGridCell64");
            this.xEditGridCell64.IsUpdatable = false;
            this.xEditGridCell64.IsUpdCol = false;
            this.xEditGridCell64.IsVisible = false;
            this.xEditGridCell64.Row = -1;
            // 
            // xEditGridCell65
            // 
            this.xEditGridCell65.CellLen = 1;
            this.xEditGridCell65.CellName = "doner_cr_yn";
            this.xEditGridCell65.Col = -1;
            this.xEditGridCell65.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell65, "xEditGridCell65");
            this.xEditGridCell65.IsUpdatable = false;
            this.xEditGridCell65.IsUpdCol = false;
            this.xEditGridCell65.IsVisible = false;
            this.xEditGridCell65.Row = -1;
            // 
            // xEditGridCell66
            // 
            this.xEditGridCell66.CellLen = 1;
            this.xEditGridCell66.CellName = "amt_cr_yn";
            this.xEditGridCell66.Col = -1;
            this.xEditGridCell66.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell66, "xEditGridCell66");
            this.xEditGridCell66.IsUpdatable = false;
            this.xEditGridCell66.IsUpdCol = false;
            this.xEditGridCell66.IsVisible = false;
            this.xEditGridCell66.Row = -1;
            // 
            // xEditGridCell99
            // 
            this.xEditGridCell99.CellName = "specimen_name";
            this.xEditGridCell99.Col = -1;
            this.xEditGridCell99.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell99, "xEditGridCell99");
            this.xEditGridCell99.IsUpdatable = false;
            this.xEditGridCell99.IsUpdCol = false;
            this.xEditGridCell99.IsVisible = false;
            this.xEditGridCell99.Row = -1;
            // 
            // xEditGridCell100
            // 
            this.xEditGridCell100.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell100.CellName = "jusa_name";
            this.xEditGridCell100.Col = 8;
            this.xEditGridCell100.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell100, "xEditGridCell100");
            this.xEditGridCell100.IsUpdatable = false;
            this.xEditGridCell100.IsUpdCol = false;
            this.xEditGridCell100.RowSpan = 2;
            this.xEditGridCell100.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell100.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell101
            // 
            this.xEditGridCell101.CellName = "pay_name";
            this.xEditGridCell101.Col = -1;
            this.xEditGridCell101.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell101, "xEditGridCell101");
            this.xEditGridCell101.IsUpdatable = false;
            this.xEditGridCell101.IsUpdCol = false;
            this.xEditGridCell101.IsVisible = false;
            this.xEditGridCell101.Row = -1;
            // 
            // xEditGridCell102
            // 
            this.xEditGridCell102.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell102.CellName = "bogyong_name";
            this.xEditGridCell102.CellWidth = 100;
            this.xEditGridCell102.Col = 9;
            this.xEditGridCell102.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell102, "xEditGridCell102");
            this.xEditGridCell102.IsUpdatable = false;
            this.xEditGridCell102.IsUpdCol = false;
            this.xEditGridCell102.RowSpan = 2;
            this.xEditGridCell102.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell102.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell104
            // 
            this.xEditGridCell104.CellName = "bun_code";
            this.xEditGridCell104.Col = -1;
            this.xEditGridCell104.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell104, "xEditGridCell104");
            this.xEditGridCell104.IsUpdatable = false;
            this.xEditGridCell104.IsUpdCol = false;
            this.xEditGridCell104.IsVisible = false;
            this.xEditGridCell104.Row = -1;
            // 
            // xEditGridCell108
            // 
            this.xEditGridCell108.CellName = "limit_suryang";
            this.xEditGridCell108.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell108.Col = -1;
            this.xEditGridCell108.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell108, "xEditGridCell108");
            this.xEditGridCell108.IsUpdatable = false;
            this.xEditGridCell108.IsUpdCol = false;
            this.xEditGridCell108.IsVisible = false;
            this.xEditGridCell108.Row = -1;
            // 
            // xEditGridCell109
            // 
            this.xEditGridCell109.CellName = "limit_nalsu";
            this.xEditGridCell109.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell109.Col = -1;
            this.xEditGridCell109.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell109, "xEditGridCell109");
            this.xEditGridCell109.IsUpdatable = false;
            this.xEditGridCell109.IsUpdCol = false;
            this.xEditGridCell109.IsVisible = false;
            this.xEditGridCell109.Row = -1;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "bulyong_check";
            this.xEditGridCell2.Col = -1;
            this.xEditGridCell2.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.IsUpdatable = false;
            this.xEditGridCell2.IsUpdCol = false;
            this.xEditGridCell2.IsVisible = false;
            this.xEditGridCell2.Row = -1;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "input_tab";
            this.xEditGridCell3.Col = -1;
            this.xEditGridCell3.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.IsVisible = false;
            this.xEditGridCell3.Row = -1;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "dv_5";
            this.xEditGridCell4.Col = -1;
            this.xEditGridCell4.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.IsVisible = false;
            this.xEditGridCell4.Row = -1;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "dv_6";
            this.xEditGridCell5.Col = -1;
            this.xEditGridCell5.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.IsVisible = false;
            this.xEditGridCell5.Row = -1;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "dv_7";
            this.xEditGridCell6.Col = -1;
            this.xEditGridCell6.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.IsVisible = false;
            this.xEditGridCell6.Row = -1;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "dv_8";
            this.xEditGridCell7.Col = -1;
            this.xEditGridCell7.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            this.xEditGridCell7.IsVisible = false;
            this.xEditGridCell7.Row = -1;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellLen = 1;
            this.xEditGridCell9.CellName = "general_disp_yn";
            this.xEditGridCell9.CellWidth = 120;
            this.xEditGridCell9.Col = 10;
            this.xEditGridCell9.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell9.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            this.xEditGridCell9.RowSpan = 2;
            // 
            // xEditGridCell68
            // 
            this.xEditGridCell68.CellLen = 50;
            this.xEditGridCell68.CellName = "generic_name";
            this.xEditGridCell68.Col = -1;
            this.xEditGridCell68.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell68, "xEditGridCell68");
            this.xEditGridCell68.IsVisible = false;
            this.xEditGridCell68.Row = -1;
            // 
            // xEditGridCell107
            // 
            this.xEditGridCell107.CellName = "hope_date";
            this.xEditGridCell107.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell107.Col = -1;
            this.xEditGridCell107.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell107, "xEditGridCell107");
            this.xEditGridCell107.IsUpdatable = false;
            this.xEditGridCell107.IsUpdCol = false;
            this.xEditGridCell107.IsVisible = false;
            this.xEditGridCell107.Row = -1;
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell1.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell1.CellName = "select";
            this.xEditGridCell1.CellWidth = 45;
            this.xEditGridCell1.Col = 1;
            this.xEditGridCell1.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell1.RowSpan = 2;
            this.xEditGridCell1.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            // 
            // xGridHeader2
            // 
            this.xGridHeader2.Col = 6;
            this.xGridHeader2.ColSpan = 2;
            resources.ApplyResources(this.xGridHeader2, "xGridHeader2");
            this.xGridHeader2.HeaderWidth = 22;
            // 
            // xGridHeader1
            // 
            this.xGridHeader1.Col = 8;
            this.xGridHeader1.ColSpan = 2;
            resources.ApplyResources(this.xGridHeader1, "xGridHeader1");
            this.xGridHeader1.HeaderWidth = 22;
            // 
            // lblSelectOrder
            // 
            this.lblSelectOrder.AccessibleDescription = null;
            this.lblSelectOrder.AccessibleName = null;
            resources.ApplyResources(this.lblSelectOrder, "lblSelectOrder");
            this.lblSelectOrder.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblSelectOrder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSelectOrder.ForeColor = IHIS.Framework.XColor.XDataGridLinkColor;
            this.lblSelectOrder.GradientEndColor = new IHIS.Framework.XColor(System.Drawing.Color.Silver);
            this.lblSelectOrder.ImageList = this.ImageList;
            this.lblSelectOrder.Name = "lblSelectOrder";
            this.lblSelectOrder.Click += new System.EventHandler(this.lblSelectOrder_Click);
            // 
            // dloSelectOCS1023
            // 
            this.dloSelectOCS1023.ExecuteQuery = null;
            this.dloSelectOCS1023.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("dloSelectOCS1023.ParamList")));
            // 
            // OCS1023U00
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.lblSelectOrder);
            this.Controls.Add(this.grdOCS1023);
            this.Controls.Add(this.xPanel1);
            this.Name = "OCS1023U00";
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.OCS1023U00_ScreenOpen);
            this.xPanel1.ResumeLayout(false);
            this.xPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS1023)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dloSelectOCS1023)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region [Screen Event]

		private void OCS1023U00_ScreenOpen(object sender, IHIS.Framework.XScreenOpenEventArgs e)
		{
			// Call된 경우
			if ( e.OpenParam != null ) 
			{
				try
				{
					if(OpenParam.Contains("bunho"))
						mBunho = OpenParam["bunho"].ToString().Trim();
					else
						return;

					if(OpenParam.Contains("gwa"))
						mGwa = OpenParam["gwa"].ToString().Trim();

                    //Prameter  추가
                    if (OpenParam.Contains("auto_close_yn"))
                        mAutoClose = OpenParam["auto_close_yn"].ToString().Trim();

                    //Parameter 추가
                    if (OpenParam.Contains("input_tab"))
                        mInputTab = OpenParam["input_tab"].ToString().Trim();
                        
              
                    //if ( this.mAutoClose == "Y")
                    //    this.ParentForm.WindowState = FormWindowState.Minimized;

                }
				catch (Exception ex)
				{
                    //https://sofiamedix.atlassian.net/browse/MED-10610
                    //XMessageBox.Show(ex.Message, "");	
					this.Close();
				}
				
			}
		
		}
		
		protected override void OnLoad(EventArgs e)
		{	
			base.OnLoad (e);
            
            PostLoad();
			
		}

		private void PostLoad()
		{      
            
            //Create Return DataLayout 
			CreateLayout();
            
			

			if(!this.grdOCS1023.QueryLayout(false))
			{
				XMessageBox.Show(Service.ErrFullMsg);
				return;
			}

            ////데이터 0건이고 AUTO_CLOSE_YN=Y 경우는 화면을 닫아버린다.
            //if (dloSelectOCS1023.LayoutTable.Rows.Count == 0 && mAutoClose == "Y")
            //{
            //     this.Close();
            //}
            //else
            //{
            //    //　데이터가 있으면 화면 사이즈를 Normal한다.
            //    if (mAutoClose == "Y")
            //        this.ParentForm.WindowState = FormWindowState.Normal;

            //}
         }
		/// <summary>
		/// DataLayout LayoutItems생성
		/// </summary>
		private void CreateLayout()
		{			
			//OCS1023
			foreach(XGridCell cell in this.grdOCS1023.CellInfos)
			{
				dloSelectOCS1023.LayoutItems.Add(cell.CellName, (DataType)cell.CellType);
			}

			dloSelectOCS1023.InitializeLayoutTable();				
		
		}

		#endregion

		#region [Return Layout 생성]
        
		private void CreateReturnLayout()
		{
			this.AcceptData();

			dloSelectOCS1023.Reset();
			
			for(int i = 0; i < grdOCS1023.RowCount; i++)
			{
				if(grdOCS1023.GetItemString(i, "select") == " ")
					dloSelectOCS1023.LayoutTable.ImportRow(grdOCS1023.LayoutTable.Rows[i]);

			}
			if(dloSelectOCS1023.LayoutTable.Rows.Count < 1 )
				return;

            // general_disp_yn = Y であるオーダはオーダ名を一般名に変えてlib.HangmogInfoに渡してそのまま一般名で返してもらう。
            DataRow row;

            for (int i = 0; i < dloSelectOCS1023.RowCount; i++)
            {
                row = dloSelectOCS1023.LayoutTable.Rows[i];

                if (row["general_disp_yn"].ToString().Trim() == "Y")
                {
                    row["hangmog_name"] = row["generic_name"].ToString().Trim();
                }
            }

			//약속코드선택정보가 있는 경우 Return Value
			IHIS.Framework.XScreen scrOpener = (XScreen)Opener;	

			CommonItemCollection commandParams  = new CommonItemCollection();
			commandParams.Add( "OCS1023", dloSelectOCS1023);
			scrOpener.Command(ScreenID, commandParams);
            
			ClearSelect();
		}
		
		#endregion

		#region [Control Event]
		
		private void btnProcess_Click(object sender, System.EventArgs e)
		{
			CreateReturnLayout();	
			Close();
		}

		private void btnDelete_Click(object sender, System.EventArgs e)
		{
			if(grdOCS1023.CurrentRowNumber < 0) return;	

			if(CurrMSLayout == grdOCS1023)
			{
				ArrayList isSelectedRow = new ArrayList();

				for (int i = grdOCS1023.RowCount - 1; i >= 0 ; i--)
				{
					if (grdOCS1023.IsSelectedRow(i) && grdOCS1023.IsVisibleRow(i)) 
						isSelectedRow.Add(i);
				}

				for (int i = 0; i < isSelectedRow.Count; i++)						
					grdOCS1023.DeleteRow((int)isSelectedRow[i]);
                        
				//select된 row가 없는 경우 현재 row삭제
				if(isSelectedRow.Count == 0) grdOCS1023.DeleteRow(grdOCS1023.CurrentRowNumber);
				
				grdOCS1023.UnSelectAll();
			}
		}
		
		
		#endregion

		#region [DataService Event]

		private void grdOCS1023_QueryEnd(object sender, IHIS.Framework.QueryEndEventArgs e)
		{                            

            SelectionBackColorChange(this.grdOCS1023);

     	}

//		private void dsvLDOCS1023_ServiceEnd(object sender, IHIS.Framework.ServiceEndArgs e)
//		{
//			SelectionBackColorChange(grdOCS1023);
//		}
//
//		private void dsvLDPATOCS1023_ServiceEnd(object sender, IHIS.Framework.ServiceEndArgs e)
//		{
//			SelectionBackColorChange(grdOCS1023);		
//		}

		#endregion

		#region [grdOCS1023 Event]
		
		private void grdOCS1023_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
		{
			return;
		}

		private void grdOCS1023_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			int curRowIndex = -1;

			if(e.Button == MouseButtons.Left && e.Clicks == 2)
			{
				curRowIndex = grdOCS1023.GetHitRowNumber(e.Y);
				if(curRowIndex < 0) return;
				CreateReturnLayout();
			}
			else if (e.Button == MouseButtons.Left && e.Clicks == 1 && grdOCS1023.CurrentColNumber == 0)
			{
				curRowIndex = grdOCS1023.GetHitRowNumber(e.Y);				
				if(curRowIndex < 0) return;

				if(grdOCS1023.CurrentColNumber == 0)
				{	
					//불용처리된 것은 선택을 막는다.
					if(grdOCS1023.GetItemString(curRowIndex, "bulyong_check") == "Y") return;

					if(grdOCS1023.GetItemString(curRowIndex, "select") == "")
					{
						grdOCS1023.SetItemValue(curRowIndex, "select", " ");
						SelectionBackColorChange(sender, curRowIndex, "Y");
					}
					else
					{
						grdOCS1023.SetItemValue(curRowIndex, "select", "");
						SelectionBackColorChange(sender, curRowIndex, "N");
					}
				}

			}
			else if (e.Button == MouseButtons.Left && e.Clicks == 1)
			{
				if(grdOCS1023.GetHitRowNumber(e.Y) < 0 ) return;		
				curRowIndex = grdOCS1023.GetHitRowNumber(e.Y);

				//Drag시 show info정보
				string dragInfo = "[" + grdOCS1023.GetItemString(curRowIndex, "hangmog_code") + "]" + grdOCS1023.GetItemString(curRowIndex, "hangmog_name");
				DragHelper.CreateDragCursor(grdOCS1023, dragInfo, this.Font);
				
				dloSelectOCS1023.Reset();
				for(int i = 0; i < grdOCS1023.RowCount; i++)
				{
					if(grdOCS1023.GetItemString(i, "select") == " ")
						dloSelectOCS1023.LayoutTable.ImportRow(grdOCS1023.LayoutTable.Rows[i]);

				}

				object[] dragData = new object[2];
				dragData[0] = this.ScreenID;
				dragData[1] = dloSelectOCS1023;
				grdOCS1023.DoDragDrop( dragData, DragDropEffects.Move);
			}
		
		}

		private void grdOCS1023_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
		{
			e.Effect = DragDropEffects.Move;  // Move 표시			
		}

		private void grdOCS1023_GiveFeedback(object sender, System.Windows.Forms.GiveFeedbackEventArgs e)
		{
			e.UseDefaultCursors = false;
			// Drag시에 Cursor 바꿈
			if ((e.Effect & DragDropEffects.Move) == DragDropEffects.Move)
			{
				Cursor.Current = DragHelper.DragCursor;
			}				
		}

		private void grdOCS1023_GridCellPainting(object sender, IHIS.Framework.XGridCellPaintEventArgs e)
		{
			if(e.DataRow["bulyong_check"].ToString() == "Y")
			{
				e.ForeColor = Color.Red;
			}
		}

		private void grdOCS1023_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
		{
			if (sender == null) return;

			XEditGrid grd = sender as XEditGrid;			

			if (e.CurrentRow >= 0) 
			{				
				// 상태에 따른 필드헤더변경 (수량/날수 (마취처방코드인 경우 시간/분으로 표시), 부수술 (체감인경우 체감))
				//this.mHangmogInfo.DisplaySpecialColHeader("O", grd, e.CurrentRow, grd.GetItemString(e.CurrentRow, "hangmog_code"));
			}		
		}
		
		#endregion

		#region [ButtonList]

		private void xButtonList1_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			switch (e.Func)
			{
				case FunctionType.Query:

					
					break;

				case FunctionType.Update:

                    //try
                    //{
                    //    this.AcceptData();
                    //    for(int i=0; i < this.grdOCS1023.RowCount; i++)
                    //    {
                    //        if(this.grdOCS1023.GetRowState(i) == DataRowState.Added)
                    //        {
                    //            string cmdTExt = "SELECT OCS1023_SEQ.NEXTVAL"
                    //                            +"  FROM DUAL";

                    //            BindVarCollection bindVars = new BindVarCollection();
								
                    //            object retVal = Service.ExecuteScalar(cmdTExt, bindVars);
                    //            if(retVal == null)
                    //            {
                    //                XMessageBox.Show(Service.ErrFullMsg);
                    //                return;
                    //            }
                    //            else
                    //            {
                    //                mSeq = retVal.ToString();
                    //            }
                    //        }
                    //    }
						
                    //    Service.BeginTransaction();

                    //    if(this.grdOCS1023.SaveLayout())
                    //    {
                    //        Service.CommitTransaction();
                    //        mbxMsg = NetInfo.Language == LangMode.Jr ? Resources.TEXT1 : Resources.TEXT2;
                    //        SetMsg(mbxMsg);
                    //        //키값 때문에 일단은...
                    //        if(!this.grdOCS1023.QueryLayout(false))
                    //        {
                    //            XMessageBox.Show(Service.ErrFullMsg);
                    //            return;
                    //        }
                    //    }
                    //    else
                    //    {
                    //        Service.RollbackTransaction();
                    //        mbxMsg = NetInfo.Language == LangMode.Jr ? Resources.TEXT3 : Resources.TEXT4; 
                    //        mbxMsg = mbxMsg + Service.ErrFullMsg;
                    //        mbxCap = NetInfo.Language == LangMode.Jr ? "Save Error" : "Save Error";
                    //        XMessageBox.Show(mbxMsg, mbxCap);
                    //    }
                    //}
                    //catch(Exception xe)
                    //{
                    //    Service.RollbackTransaction();
                    //    XMessageBox.Show("ButtonList Update CommitRransaction " + xe.Message);
                    //}

			        if (SaveGrdOCS1023())
			        {
                        mbxMsg = NetInfo.Language == LangMode.Jr ? Resources.TEXT1 : Resources.TEXT2;
                        SetMsg(mbxMsg);
                        //키값 때문에 일단은...
                        if (!this.grdOCS1023.QueryLayout(false))
                        {
                            XMessageBox.Show(Service.ErrFullMsg);
                            return;
                        }
			        }
			        else
			        {
                        mbxMsg = NetInfo.Language == LangMode.Jr ? Resources.TEXT3 : Resources.TEXT4;
                        mbxMsg = mbxMsg + Service.ErrFullMsg;
                        mbxCap = NetInfo.Language == LangMode.Jr ? "Save Error" : "Save Error";
                        XMessageBox.Show(mbxMsg, mbxCap);
			        }

					break;


				default:

					break;
			}			
		}



	    #endregion
		
		#region [Function]

		private void ClearSelect()
		{	
			//선택된 row Clear
			for(int i = 0; i < this.grdOCS1023.RowCount; i++)
			{
				grdOCS1023.SetItemValue(i, "select", "");
			}

			SelectionBackColorChange(grdOCS1023);

			dloSelectOCS1023.Reset();
		}
       
		
		
		#endregion

		#region 그리드에서 선택한 Row에 대한 BackColor를 변경한다
		private void SelectionBackColorChange(object grd, int currentRowIndex, string data)
		{
			XGrid grdObject = (XGrid)grd;
			//선택된 Row에대해서 색을 변경한다
			//data   Y :색을 변경, N :색을 변경 해제
			//image 설정
			if(data == "Y")
				grdObject[currentRowIndex + grdObject.HeaderHeights.Count, 1].Image = this.ImageList.Images[1];
			else
				grdObject[currentRowIndex + grdObject.HeaderHeights.Count, 1].Image = this.ImageList.Images[0];

			for(int liColCnt = 0; liColCnt < grdObject.Cols; liColCnt++)
			{
				if(data == "Y")
				{
					grdObject[currentRowIndex + grdObject.HeaderHeights.Count, liColCnt].BackColor = XColor.XGridSelectedCellBackColor;
					grdObject[currentRowIndex + grdObject.HeaderHeights.Count, liColCnt].ForeColor = XColor.XGridSelectedCellForeColor;
				}
				else 
				{
					grdObject[currentRowIndex + grdObject.HeaderHeights.Count, liColCnt].BackColor = XColor.XGridRowBackColor;
					grdObject[currentRowIndex + grdObject.HeaderHeights.Count, liColCnt].ForeColor = XColor.NormalForeColor;
				}
			}
			
		}

		
		
		private void SelectionBackColorChange(object grd)
		{
			XGrid grdObject = (XGrid)grd;

			//기존의 색으로 변경을 시킨다
			for(int rowIndex = 0; rowIndex < grdObject.RowCount; rowIndex++)
			{	
				//불용은 넘어간다.
				if(grdObject.GetItemString(rowIndex, "bulyong_check") == "Y" ) continue;

				if(grdObject.GetItemString(rowIndex, "select").ToString() == " ")
				{				
					//image 변경
					grdObject[rowIndex + grdObject.HeaderHeights.Count, 1].Image = this.ImageList.Images[1];					

					//ColorYn Y :색을 변경, N :색을 변경 해제
					for(int liColCnt = 0; liColCnt < grdObject.Cols; liColCnt++)
					{					
						grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].BackColor = XColor.XGridSelectedCellBackColor;
						grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].ForeColor = XColor.XGridSelectedCellForeColor;
					}
				}
				else
				{				
					//image 변경
					grdObject[rowIndex + grdObject.HeaderHeights.Count, 1].Image = this.ImageList.Images[0];
					for(int liColCnt = 0; liColCnt < grdObject.Cols; liColCnt++)
					{					
						grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].BackColor = XColor.XGridRowBackColor;
						grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].ForeColor = XColor.NormalForeColor;
					}
				}
			}
		}
		#endregion

		#region [전체선택]

		private void lblSelectOrder_Click(object sender, System.EventArgs e)
		{
			if(lblSelectOrder.ImageIndex == 0)
			{
				grdSelectAll(grdOCS1023, true);
				lblSelectOrder.ImageIndex = 1;
				lblSelectOrder.Text = Resources.TEXT5;
			}
			else
			{
				grdSelectAll(grdOCS1023, false);
				lblSelectOrder.ImageIndex = 0;
				lblSelectOrder.Text = Resources.TEXT6;
			}
		}
        
		/// <summary>
		/// 해당 Grid 전체선택 해제
		/// </summary>
		/// <param name="grd"></param>
		/// <param name="select"></param>
		private void grdSelectAll(XGrid grdObject, bool select)
		{
			int rowIndex = -1;

			if(select)
			{
				for(rowIndex = 0; rowIndex < grdObject.RowCount; rowIndex++)
				{
					if(grdObject.GetItemString( rowIndex, "bulyong_check") != "Y" ) grdObject.SetItemValue(rowIndex, "select", " ");
				}
			}
			else
			{
				for(rowIndex = 0; rowIndex < grdObject.RowCount; rowIndex++)
				{
					if(grdObject.GetItemString( rowIndex, "bulyong_check") != "Y" ) grdObject.SetItemValue(rowIndex, "select", "");
				}
			}

			SelectionBackColorChange(grdObject);
		}

		#endregion

		#region 저장로직
        //private class XSavePerformer : IHIS.Framework.ISavePerformer
        //{
        //    private OCS1023U00 parent = null;

        //    public XSavePerformer(OCS1023U00 parent)
        //    {
        //        this.parent = parent;
        //    }

        //    public bool Execute(char callerID, RowDataItem item)
        //    {
        //        String cmdQry = null;
				
        //        item.BindVarList.Add("f_user_id", UserInfo.UserID);
				
        //        switch(item.RowState)
        //        {
        //            case DataRowState.Added:
        //                item.BindVarList.Add("f_sequence", parent.mSeq.ToString());

        //                cmdQry = "INSERT INTO OCS1023"
        //                        + "                   ( SYS_DATE        , SYS_ID        , UPD_DATE      , BUNHO          ,"
        //                        + "                     GWA             , HANGMOG_CODE  , SEQ            ,"
        //                        + "                     PKOCS1023       , SPECIMEN_CODE , SURYANG       , ORD_DANUI      ,"
        //                        + "                     DV_TIME         , DV            , NALSU         , JUSA           ,"
        //                        + "                     BOGYONG_CODE    , PORTABLE_YN   ,"
        //                        + "                     ANTI_CANCER_YN  , POWDER_YN     , DV_1          ,"
        //                        + "                     DV_2            , DV_3          , DV_4          , JUSA_SPD_GUBUN ,"
        //                        + "                     UPD_ID          , HOSP_CODE     , BOM_SOOURCE_KEY )"
        //                        + "             VALUES"
        //                        + "                   ( SYSDATE            , :f_user_id       , SYSDATE          , :f_bunho          ,"
        //                        + "                     :f_gwa             , :f_hangmog_code  , :f_sequence       ,"
        //                        + "                     :f_pkocs1023       , :f_specimen_code , :f_suryang       , :f_ord_danui      ,"
        //                        + "                     :f_dv_time         , :f_dv            , :f_nalsu         , :f_jusa           ,"
        //                        + "                     :f_bogyong_code    , :f_portable_yn   ,"
        //                        + "                     :f_anti_cancer_yn  , :f_powder_yn     , :f_dv_1          ,"
        //                        + "                     :f_dv_2            , :f_dv_3          , :f_dv_4          , :f_jusa_spd_gubun ,"
        //                        + "                     :f_user_id         , '" + EnvironInfo.HospCode + "', :f_bom_source_key )";
        //                break;

        //            case DataRowState.Modified:
        //                cmdQry = "UPDATE OCS1023"
        //                        +"   SET UPD_ID           = :f_user_id         ,"
        //                        +"       UPD_DATE         = SYSDATE            ,"
        //                        +"       SEQ              = :f_seq             ,"
        //                        +"       SPECIMEN_CODE    = :f_specimen_code   ,"
        //                        +"       SURYANG          = :f_suryang         ,"
        //                        +"       ORD_DANUI        = :f_ord_danui       ,"
        //                        +"       DV_TIME          = :f_dv_time         ,"
        //                        +"       DV               = :f_dv              ,"
        //                        +"       DV_1             = :f_dv_1            ,"
        //                        +"       DV_2             = :f_dv_2            ,"
        //                        +"       DV_3             = :f_dv_3            ,"
        //                        +"       DV_4             = :f_dv_4            ,"
        //                        +"       NALSU            = :f_nalsu           ,"
        //                        +"       JUSA             = :f_jusa            ,"
        //                        +"       BOGYONG_CODE     = :f_bogyong_code    ,"
        //                        +"       PORTABLE_YN      = :f_portable_yn     ,"
        //                        +"       ANTI_CANCER_YN   = :f_anti_cancer_yn  ,"
        //                        +"       POWDER_YN        = :f_powder_yn        "
        //                        +" WHERE PKOCS1023        = :f_pkocs1023";
        //                break;

        //            case DataRowState.Deleted:
        //                cmdQry = "DELETE OCS1023"
        //                        +" WHERE PKOCS1023      = :f_pkocs1023";
        //                break;
        //        }
        //        return Service.ExecuteNonQuery(cmdQry,item.BindVarList);
        //    }
        //}
		#endregion

        private void grdOCS1023_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdOCS1023.SetBindVarValue("f_bunho", mBunho);
            this.grdOCS1023.SetBindVarValue("f_gwa", mGwa);
            this.grdOCS1023.SetBindVarValue("f_input_tab", mInputTab);
            this.grdOCS1023.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdOCS1023.SetBindVarValue("f_generic_yn", this.cbxGeneric_YN.GetDataValue());
        }

        private void cbxGeneric_YN_CheckedChanged(object sender, EventArgs e)
        {
            this.grdOCS1023.QueryLayout(true);
        }

   
	}
}

