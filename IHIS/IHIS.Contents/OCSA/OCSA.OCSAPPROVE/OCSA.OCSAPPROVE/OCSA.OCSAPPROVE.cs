using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Arguments.Ocs.Lib;
using IHIS.CloudConnector.Contracts.Arguments.Ocsa;
using IHIS.CloudConnector.Contracts.Models.Ocs.Lib;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Results.Ocs.Lib;
using IHIS.CloudConnector.Contracts.Results.Ocsa;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.Framework;
using IHIS.OCS;
using System.Threading;
using IHIS.OCSA.Properties;
using IHIS.CloudConnector.Contracts.Results;

namespace IHIS.OCSA
{
    public partial class OCSAPPROVE : IHIS.Framework.XScreen
    {
        public OCSAPPROVE()
        {
            InitializeComponent();

            this.mOrderBiz = new IHIS.OCS.OrderBiz();                      // OCS 그룹 Business 라이브러리
            this.mOrderFunc = new IHIS.OCS.OrderFunc();                     // OCS 그룹 Function 라이브러리			
            this.mHangmogInfo = new IHIS.OCS.HangmogInfo(this.ScreenID);    // OCS 항목정보 그룹 라이브러리
            this.mInputControl = new IHIS.OCS.InputControl(this.ScreenID);  // 입력제어 그룹 라이브러리 		
            this.mColumnControl = new IHIS.OCS.ColumnControl(this.ScreenID); // OCS 컬럼 컨트롤 그룹 라이브러리 

            //this.grdOrderList.SavePerformer = new XSavePeformer(this);

            grdOrderList.ParamList = new List<string>(new String[] { "f_bunho", "f_naewon_date", "f_gwa", "f_doctor", "f_naewon_type", "f_input_gubun", "f_input_tab", "f_jubsu_no", "f_pk_order", "f_hosp_code", "f_instead_yn", "f_approve_yn", "f_prepost_gubun" });
            grdOrderList.ExecuteQuery = LoadDataGrdOrderList;

            grdPatientList.ParamList = new List<string>(new String[] { "f_input_gubun", "f_instead_yn", "f_approve_yn", "f_hosp_code", "f_io_gubun", "f_doctor", "f_input_tab" });
            grdPatientList.ExecuteQuery = LoadDataGrdPatientList;

            //TODO disable IN Hospital Tab MED-5790
            rbtIn.Visible = false;
        }

        #region ConvertToDataTable
        /// <summary>
        /// ConvertToDataTable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <returns></returns>
        private DataTable ConvertToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                string input = prop.Name;
                StringBuilder sb = new StringBuilder();
                sb.Append(input[0].ToString().ToLower());
                for (int i = 1; i < input.Length; i++)
                {
                    char c = input[i];
                    if (Char.IsUpper(c))
                    {
                        sb.Append("_").Append(c.ToString().ToLower());
                    }
                    else
                    {
                        sb.Append(c);
                    }
                }
                dataTable.Columns.Add(sb.ToString());
            }
            foreach (T item in items)
            {
                object[] values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }

            return dataTable;
        }
        #endregion

        /// <summary>
        /// get data from server and fill into List object
        /// GrdPatient will use this list to import data
        /// </summary>
        /// <param name="varlist"></param>
        /// <returns></returns>
        private IList<object[]> LoadDataGrdPatientList(BindVarCollection varlist)
        {
            IList<object[]> dataList = new List<object[]>();
            OCSAPPROVEGrdPatientListArgs args = new OCSAPPROVEGrdPatientListArgs();
            args.ApproveYn = varlist["f_approve_yn"].VarValue;
            args.Doctor = varlist["f_doctor"].VarValue;
            args.InputGubun = varlist["f_input_gubun"].VarValue;
            args.InputTab = varlist["f_input_tab"].VarValue;
            args.InsteadYn = varlist["f_instead_yn"].VarValue;
            args.IoGubun = varlist["f_io_gubun"].VarValue;

            //args.ApproveYn = "N";
            //args.Doctor = "10001";
            //args.InputGubun = "NR";
            //args.InputTab = "10";
            //args.InsteadYn = "N";
            //args.IoGubun = "O";

            //args.ApproveYn = "N";
            //args.Doctor = "99999";
            //args.InputGubun = "NR";
            //args.InputTab = "%";
            //args.InsteadYn = "N";
            //args.IoGubun = "O";

            OCSAPPROVEGrdPatientListResult result =
                CloudService.Instance.Submit<OCSAPPROVEGrdPatientListResult, OCSAPPROVEGrdPatientListArgs>(args);
            if (result != null)
            {
                List<OCSAPPROVEGrdPatientListInfo> grdList = result.GrdPatientListInfo;
                if (grdList.Count > 0)
                {
                    foreach (OCSAPPROVEGrdPatientListInfo info in grdList)
                    {
                        dataList.Add(new object[]
                        {
                            info.NaewonDate ,
                            info.Gwa         ,
                            info.GwaName    ,
                            info.DoctorName ,
                            info.Nalsu       ,
                            info.Bunho       ,
                            info.Doctor      ,
                            info.GubunName  ,
                            info.ChojaeName ,
                            info.NaewonType ,
                            info.JubsuNo    ,
                            info.PkOrder    ,
                            info.InputGubun ,
                            info.ToiwonDrg  ,
                            info.InputTab   ,
                            info.IoGubun    ,
                            info.PatientName,
                            info.SelectYn   
                        });
                    }
                }
            }

            return dataList;
        }

        /// <summary>
        /// get data from server and fill into List object
        /// GrdOrder will use this list to import data
        /// </summary>
        /// <param name="varlist"></param>
        /// <returns></returns>
        private IList<object[]> LoadDataGrdOrderList(BindVarCollection varlist)
        {
            IList<object[]> dataList = new List<object[]>();
            OCSAPPROVEGrdOrderArgs args = new OCSAPPROVEGrdOrderArgs();
            args.ApproveYn = varlist["f_approve_yn"].VarValue;
            args.Bunho = varlist["f_bunho"].VarValue;
            args.Doctor = varlist["f_doctor"].VarValue;
            args.InputTab = varlist["f_input_tab"].VarValue;
            args.InsteadYn = varlist["f_instead_yn"].VarValue;
            args.JubsuNo = varlist["f_jubsu_no"].VarValue;
            args.NaewonDate = varlist["f_naewon_date"].VarValue;
            args.PkOrder = varlist["f_pk_order"].VarValue;
            args.PrepostGubun = varlist["f_prepost_gubun"].VarValue;
            //args.PrepostGubun = "N";
            OCSAPPROVEGrdOrderResult result =
                CloudService.Instance.Submit<OCSAPPROVEGrdOrderResult, OCSAPPROVEGrdOrderArgs>(args);
            if (result != null)
            {
                List<OCSAPPROVEGrdOrderInfo> grdList = result.GrdOrderInfo;
                if (grdList.Count > 0)
                {
                    foreach (OCSAPPROVEGrdOrderInfo info in grdList)
                    {
                        dataList.Add(new object[]
                        {
                            info.InputGubunName        ,
                            info.GroupSer               ,
                            info.OrderGubunName        ,
                            info.HangmogCode            ,
                            info.HangmogName      ,
                            info.SpecimenCode           ,
                            info.SpecimenName           ,
                            info.Suryang                 ,
                            info.OrdDanui               ,
                            info.OrdDanuiName          ,
                            info.DvTime                 ,
                            info.Dv                      ,
                            info.Nalsu                   ,
                            info.Jusa                    ,
                            info.JusaName               ,
                            info.BogyongCode            ,
                            info.BogyongName            ,
                            info.JusaSpdGubun          ,
                            info.HubalChangeYn         ,
                            info.Pharmacy                ,
                            info.DrgPackYn             ,
                            info.PowderYn               ,
                            info.WonyoiOrderYn         ,
                            info.DangilGumsaOrderYn   ,
                            info.DangilGumsaResultYn  ,
                            info.Emergency               ,
                            info.Pay                     ,
                            info.AntiCancerYn          ,
                            info.Muhyo                   ,
                            info.PortableYn             ,
                            info.OcsFlag                ,
                            info.OrderGubun             ,
                            info.InputTab               ,
                            info.InputGubun             ,
                            info.AfterActYn            ,
                            info.JundalTable            ,
                            info.JundalPart             ,
                            info.MovePart               ,
                            info.Bunho                   ,
                            info.OrderDate              ,
                            info.Gwa                     ,
                            info.Doctor                  ,
                            info.NaewonType             ,
                            info.PkOrder                ,
                            info.Seq                     ,
                            info.Pkocs1003               ,
                            info.SubSusul               ,
                            info.SutakYn                ,
                            info.Amt                     ,
                            info.Dv1                    ,
                            info.Dv2                    ,
                            info.Dv3                    ,
                            info.Dv4                    ,
                            info.HopeDate               ,
                            info.OrderRemark            ,
                            info.MixGroup               ,
                            info.HomeCareYn            ,
                            info.RegularYn              ,
                            info.GongbiCode             ,
                            info.GongbiName             ,
                            info.DonbokYn               ,
                            info.DvName                 ,
                            info.SlipCode               ,
                            info.GroupYn                ,
                            info.SgCode                 ,
                            info.OrderGubunBas         ,
                            info.InputControl           ,
                            info.SugaYn                 ,
                            info.EmergencyCheck         ,
                            info.LimitSuryang           ,
                            info.SpecimenYn             ,
                            info.JaeryoYn               ,
                            info.OrdDanuiCheck         ,
                            info.OrdDanuiBas           ,
                            info.JundalTableOut        ,
                            info.JundalPartOut         ,
                            info.MovePartOut           ,
                            info.JundalTableInp        ,
                            info.JundalPartInp         ,
                            info.MovePartInp           ,
                            info.BulyongCheck           ,
                            info.WonyoiOrderCrYn      ,
                            info.DefaultWonyoiOrderYn ,
                            info.NdayYn                 ,
                            info.MuhyoYn                ,
                            info.TelYn                  ,
                            info.DrgInfo                ,
                            info.DrgBunryu              ,
                            info.ChildYn,
                            info.BomSourceKey,
                            info.BomOccurYn,
                            info.OrgKey,
                            info.ParentKey,
                            info.BunCode  ,
                            info.ContKey,
                            info.Fkout1001, 
                            info.WonnaeDrgYn, 
                            info.DcYn,
                            info.ResultDate,              
                            info.ConfirmCheck,
                            info.SunabCheck,
                            info.Dv5,
                            info.Dv6,
                            info.Dv7,
                            info.Dv8,
                            info.GeneralDispYn,
                            info.GenericName,
                            info.NoValue,
                            info.BogyongCodeSub,
                            info.BogyongNameSub,
                            info.OriHopeDate,
                            info.IoYn,
                            info.BroughtDrgYn,
                            info.SpecificComment,
                            info.InsteadId,
                            info.PostapproveYn
                        });
                    }
                }
            }

            return dataList;
        }

        private string mCallerSysID = "";
        private string mBunho = "";
        private string mFk_io_key = "";
        private string mIO_GUBUN = "";
        private string mDoctor_id = "";

        private string SELECTED_IOGUBUN = "O";
        private string INSTEAD_YN = "Y";
        private string INPUT_TAB = "%";
        private string APPROVE_YN = "N";
        private string INPUT_GUBUN = "CK";

        private bool mPostApprove_Visible = false;
        private bool mApprove_Force = false;

        private IHIS.X.Magic.Menus.PopupMenu mSubMenu = new IHIS.X.Magic.Menus.PopupMenu();

        #region [OCS Library]
        private IHIS.OCS.OrderBiz mOrderBiz = null;         // OCS 그룹 Business 라이브러리
        private IHIS.OCS.OrderFunc mOrderFunc = null;         // OCS 그룹 Function 라이브러리		
        private IHIS.OCS.HangmogInfo mHangmogInfo = null;     // OCS 항목정보 그룹 라이브러리
        private IHIS.OCS.InputControl mInputControl = null;   // 입력제어 그룹 라이브러리 
        private IHIS.OCS.ColumnControl mColumnControl = null; // OCS 오더별 컬럼 컨트롤 라이브러리

        #endregion

        string mbxMsg = "", mbxCap = "";

        private void OCSAPPROVE_ScreenOpen(object sender, XScreenOpenEventArgs e)
        {
            if (e.OpenParam != null)
            {
                #region [パラメータセット]

                if (this.OpenParam.Contains("caller_sys_id"))
                {
                    this.mCallerSysID = this.OpenParam["caller_sys_id"].ToString();
                }

                if (this.OpenParam.Contains("io_gubun"))
                {
                    this.mIO_GUBUN = this.OpenParam["io_gubun"].ToString();
                }

                if (this.OpenParam.Contains("fk_key"))
                {
                    this.mFk_io_key = this.OpenParam["fk_key"].ToString();
                }

                if (this.OpenParam.Contains("doctor_id"))
                {
                    this.mDoctor_id = this.OpenParam["doctor_id"].ToString();
                }

                if (this.OpenParam.Contains("bunho"))
                {
                    this.mBunho = this.OpenParam["bunho"].ToString();
                    this.pbxSearch.SetPatientID(this.mBunho);
                }

                #endregion　[パラメータセット]
            }

            mSubMenu.MenuCommands.Clear();
            IHIS.X.Magic.Menus.MenuCommand popUpSubMenu;
            popUpSubMenu = new IHIS.X.Magic.Menus.MenuCommand(Resources.ScreenOpen, (Image)this.ImageList.Images[4], new EventHandler(mSubMenu_Click));
            popUpSubMenu.Tag = "R";
            mSubMenu.MenuCommands.Add(popUpSubMenu);

            this.tabPrePost.TabPages[0].Selected = true;

            this.initScreen();

            PostCallHelper.PostCall(new PostMethod(PostLoad));
        }

        private void PostLoad()
        {
            this.grdPatientList.QueryLayout(false);
        }

        private void initScreen()
        {
            OCSAPPROVEInitScreenArgs args = new OCSAPPROVEInitScreenArgs();

            List<ComboDataSourceInfo> cboList = new List<ComboDataSourceInfo>();
            ComboDataSourceInfo infoSuryang = new ComboDataSourceInfo();
            infoSuryang.ColName = "suryang";
            ComboDataSourceInfo infoNalsu = new ComboDataSourceInfo();
            infoNalsu.ColName = "nalsu";
            ComboDataSourceInfo infoDv = new ComboDataSourceInfo();
            infoDv.ColName = "dv";

            cboList.Add(infoSuryang);
            cboList.Add(infoNalsu);
            cboList.Add(infoDv);

            args.CboListInfo = cboList;
            OCSAPPROVEInitScreenResult result =
                CloudService.Instance.Submit<OCSAPPROVEInitScreenResult, OCSAPPROVEInitScreenArgs>(args);

            DataTable dtSuryang = new DataTable();
            DataTable dtNalsu = new DataTable();
            DataTable dtDv = new DataTable();

            if (result != null)
            {
                if (result.CboSuryang != null)
                {
                    dtSuryang = ConvertToDataTable<ComboListItemInfo>(result.CboSuryang);
                }
                if (result.CboNalsu != null)
                {
                    dtNalsu = ConvertToDataTable<ComboListItemInfo>(result.CboNalsu);
                }
                if (result.CboDv != null)
                {
                    dtDv = ConvertToDataTable<ComboListItemInfo>(result.CboDv);
                }
            }

            //this.mOrderBiz.SetNumCombo(this.grdOrderList, "suryang", true);
            //this.mOrderBiz.SetNumCombo(this.grdOrderList, "nalsu", false);
            //this.mOrderBiz.SetNumCombo(this.grdOrderList, "dv", false);

            this.mOrderBiz.SetNumCombo(this.grdOrderList, "suryang", true, dtSuryang);
            this.mOrderBiz.SetNumCombo(this.grdOrderList, "nalsu", false, dtNalsu);
            this.mOrderBiz.SetNumCombo(this.grdOrderList, "dv", false, dtDv);

            if (this.mIO_GUBUN == "O" || ((XScreen)Opener).ScreenID != "OCS2003P01")
            {
                this.btnProcessD0.Visible = true;
                this.btnProcessD0.Text = Resources.MsgBtnProcessD0;
                this.btnProcessD4.Visible = false;
                this.btnProcessD7.Visible = false;
            }

            //this.grdPatientList.AutoSizeColumn(3, 0); //bunho

            this.grdOrderList.AutoSizeColumn(3, 0);     // order_date
            this.grdOrderList.AutoSizeColumn(7, 0);     // ori_hosp_code
            this.grdOrderList.AutoSizeColumn(11, 0);    // hangmog_code
            this.grdOrderList.AutoSizeColumn(20, 0);    // mlhr
            this.grdOrderList.AutoSizeColumn(22, 0);    // specimen_code
            this.grdOrderList.AutoSizeColumn(24, 0);    // dangil_gumsa_order_yn
            this.grdOrderList.AutoSizeColumn(25, 0);    // dangil_gumsa_result_yn
            this.grdOrderList.AutoSizeColumn(27, 0);    // wonwoi
            this.grdOrderList.AutoSizeColumn(33, 0);    // buwi_code
            this.grdOrderList.AutoSizeColumn(34, 0);    // buwi_name


            if (this.mIO_GUBUN == "O")
            {
                this.grdOrderList.AutoSizeColumn(38, 0);    // jundal_table_inp
                this.grdOrderList.AutoSizeColumn(39, 0);    // jundal_part_inp
                this.grdOrderList.AutoSizeColumn(40, 0);    // move_part_inp

                this.rbtOut.PerformClick();
                this.rbtOut.Checked = true;
            }
            else
            {
                this.grdOrderList.AutoSizeColumn(35, 0);    // jundal_table_out
                this.grdOrderList.AutoSizeColumn(36, 0);    // jundal_part_out
                this.grdOrderList.AutoSizeColumn(37, 0);    // move_part_out

                this.rbtIn.PerformClick();
                this.rbtIn.Checked = true;
            }

            this.grdOrderList.AutoSizeColumn(41, 0);    // specific_comment

            // 承認プロセス関連FLAG取得
            //this.mOrderBiz.GetApproveFlags(ref this.mPostApprove_Visible, ref this.mApprove_Force);

            if (result.PostApproveVisible != null && result.ApproveForce != null)
            {
                this.mPostApprove_Visible = result.PostApproveVisible;
                this.mApprove_Force = result.ApproveForce;
            }
            //comment for MED-3784
            //if (!this.mPostApprove_Visible)
            //    this.tabPrePost.TabPages.Remove(this.tabPrePost.TabPages[1]);　// 事後承認を見せない
        }

        private void mSubMenu_Click(object sender, System.EventArgs e)
        {
            IHIS.X.Magic.Menus.MenuCommand btn = sender as IHIS.X.Magic.Menus.MenuCommand;
            ArrayList inList = new ArrayList();
            ArrayList outList = new ArrayList();
            int currRow = this.grdOrderList.CurrentRowNumber;

            if (currRow < 0) return;

            string specific_comment = this.grdOrderList.GetItemString(currRow, "specific_comment");

            if (specific_comment == "")
                XMessageBox.Show(Resources.MSG_mSubMenu_Click, Resources.mSubMenu_Click_2);
            else if (specific_comment == "18" || specific_comment == "19") // リハビリ依頼書
                this.OpenScreen_Reha_SpecificComment(this.grdOrderList, currRow, specific_comment);
            else if (specific_comment == "21") // 栄養食事相談依頼書
                this.OpenScreen_Nut_SpecificComment(this.grdOrderList, currRow);
        }

        /// <summary>
        /// 依頼書画面オープン
        /// </summary>
        /// <param name="aGrid"></param>
        /// <param name="aRowNumber"></param>
        private void OpenScreen_Reha_SpecificComment(XEditGrid aGrid, int aRowNumber, string aSpecific_Comment)
        {
            CommonItemCollection openParams = new CommonItemCollection();

            openParams.Add("bunho", aGrid.GetItemString(aRowNumber, "bunho"));
            //openParams.Add("order_date"     , aGrid.GetItemString(aRowNumber, "order_date"));
            openParams.Add("pkocskey", aGrid.GetItemString(aRowNumber, "pkocskey"));
            openParams.Add("in_out_gubun", this.SELECTED_IOGUBUN);
            openParams.Add("hangmog_code", aGrid.GetItemString(aRowNumber, "hangmog_code"));
            openParams.Add("gwa", aGrid.GetItemString(aRowNumber, "gwa"));
            openParams.Add("doctor", aGrid.GetItemString(aRowNumber, "doctor"));
            openParams.Add("jundal_part", aGrid.GetItemString(aRowNumber, "jundal_part"));

            openParams.Add("caller_screen_id", this.Name);
            //openParams.Add("naewon_key"     , aGrid.GetItemString(aRowNumber, "in_out_key"));

            if (aSpecific_Comment == "18")
                XScreen.OpenScreenWithParam(this, "PHYS", "PHY8002U00", ScreenOpenStyle.ResponseSizable, openParams);
            else if (aSpecific_Comment == "19")
                XScreen.OpenScreenWithParam(this, "PHYS", "PHY8002U01", ScreenOpenStyle.ResponseSizable, openParams);

        }
        private void OpenScreen_Nut_SpecificComment(XEditGrid aGrid, int aRowNumber)
        {
            CommonItemCollection openParams = new CommonItemCollection();

            openParams.Add("bunho", aGrid.GetItemString(aRowNumber, "bunho"));
            openParams.Add("order_date", aGrid.GetItemString(aRowNumber, "naewon_date"));
            openParams.Add("pkocskey", aGrid.GetItemString(aRowNumber, "pkocskey"));
            openParams.Add("in_out_gubun", this.SELECTED_IOGUBUN);
            openParams.Add("hangmog_code", aGrid.GetItemString(aRowNumber, "hangmog_code"));
            openParams.Add("gwa", aGrid.GetItemString(aRowNumber, "gwa"));
            openParams.Add("doctor", aGrid.GetItemString(aRowNumber, "doctor"));
            openParams.Add("hope_date", aGrid.GetItemString(aRowNumber, "hope_date"));
            openParams.Add("ocs_flag", aGrid.GetItemString(aRowNumber, "ocs_flag"));
            openParams.Add("caller_screen_id", this.Name);
            XScreen.OpenScreenWithParam(this, "NUTS", "NUT0001U00", ScreenOpenStyle.ResponseFixed, openParams);
        }

        private void grdPatientList_QueryStarting(object sender, CancelEventArgs e)
        {
            XEditGrid grd = sender as XEditGrid;

            grd.SetBindVarValue("f_input_gubun", INPUT_GUBUN);
            grd.SetBindVarValue("f_instead_yn", INSTEAD_YN);
            grd.SetBindVarValue("f_approve_yn", APPROVE_YN);
            grd.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            grd.SetBindVarValue("f_io_gubun", SELECTED_IOGUBUN);
            grd.SetBindVarValue("f_doctor", mDoctor_id);
            grd.SetBindVarValue("f_input_tab", INPUT_TAB);
        }

        private void grdOrderList_QueryStarting(object sender, CancelEventArgs e)
        {
            XEditGrid grd = sender as XEditGrid;

            grd.SetBindVarValue("f_bunho", grdPatientList.GetItemString(grdPatientList.CurrentRowNumber, "bunho"));
            grd.SetBindVarValue("f_naewon_date", grdPatientList.GetItemString(grdPatientList.CurrentRowNumber, "naewon_date").Replace(" 0:00:00", ""));
            grd.SetBindVarValue("f_gwa", grdPatientList.GetItemString(grdPatientList.CurrentRowNumber, "gwa"));
            grd.SetBindVarValue("f_doctor", grdPatientList.GetItemString(grdPatientList.CurrentRowNumber, "doctor"));
            grd.SetBindVarValue("f_naewon_type", grdPatientList.GetItemString(grdPatientList.CurrentRowNumber, "naewon_type"));
            grd.SetBindVarValue("f_input_gubun", this.INPUT_GUBUN);
            grd.SetBindVarValue("f_input_tab", grdPatientList.GetItemString(grdPatientList.CurrentRowNumber, "input_tab"));
            grd.SetBindVarValue("f_jubsu_no", grdPatientList.GetItemString(grdPatientList.CurrentRowNumber, "jubsu_no"));
            grd.SetBindVarValue("f_pk_order", grdPatientList.GetItemString(grdPatientList.CurrentRowNumber, "pk_order"));
            grd.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            grd.SetBindVarValue("f_instead_yn", this.INSTEAD_YN);
            grd.SetBindVarValue("f_approve_yn", this.APPROVE_YN);

            grd.SetBindVarValue("f_prepost_gubun", this.tabPrePost.SelectedTab.Tag.ToString());
        }

        private void rbtOut_CheckedChanged(object sender, EventArgs e)
        {
            this.grdOrderList.Reset();

            if (rbtOut.Checked)
            {
                SELECTED_IOGUBUN = "O";
            }
            else
            {
                SELECTED_IOGUBUN = "I";
            }

            if (!this.grdPatientList.QueryLayout(false)) XMessageBox.Show(Service.ErrFullMsg);

            this.setButton(this.rbtOut, this.tabPrePost);
        }

        private void grdPatientList_RowFocusChanged(object sender, RowFocusChangedEventArgs e)
        {
            this.pbxSearch.SetPatientID(this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "bunho"));
            this.grdOrderList.QueryLayout(false);
        }

        private bool grdSelectAll(XGrid grdObject)
        {
            int rowIndex = -1;

            for (rowIndex = 0; rowIndex < grdObject.RowCount; rowIndex++)
            {
                if (this.grdOrderList.GetItemString(rowIndex, "wonnae_drg_yn") != "Y"
                    && this.mIO_GUBUN == "I"
                    && (this.grdOrderList.GetItemString(rowIndex, "order_gubun").Substring(1) == "C"
                        || this.grdOrderList.GetItemString(rowIndex, "order_gubun").Substring(1) == "D"
                        || this.grdOrderList.GetItemString(rowIndex, "order_gubun").Substring(1) == "B"
                        )
                    )
                {
                    if (XMessageBox.Show("[ " + this.grdOrderList.GetItemString(rowIndex, "hangmog_name") + Resources.MSGgrdSelectAll_, Resources.mSubMenu_Click_2, MessageBoxButtons.YesNo) == DialogResult.No)
                        continue;
                }

                if (grdObject.GetItemString(rowIndex, "bulyong_check") != "Y")
                {
                    if (
                           (this.mIO_GUBUN == "I" && grdObject.GetItemString(rowIndex, "io_yn") != "O")
                        || (this.mIO_GUBUN == "O" && grdObject.GetItemString(rowIndex, "io_yn") != "I")
                        || this.INPUT_GUBUN == "D7"
                        )
                    {

                        this.SelectionBackColorChange(grdObject, rowIndex, "Y");
                        grdObject.SetItemValue(rowIndex, "select", "Y");
                    }
                    else
                    {

                    }
                }
            }


            //선택된 Row 표시
            SetSelectPatientList(this.grdPatientList.CurrentRowNumber);

            return true;

        }

        private bool grdDeleteAll(XGrid grdObject)
        {
            int rowIndex = -1;

            for (rowIndex = 0; rowIndex < grdObject.RowCount; rowIndex++)
            {
                if (grdObject.GetItemString(rowIndex, "bulyong_check") != "Y")
                {

                    this.SelectionBackColorChange(grdObject, rowIndex, "N");
                    grdObject.SetItemValue(rowIndex, "select", "N");
                }
            }
            //선택된 Row 표시
            SetSelectPatientList(this.grdPatientList.CurrentRowNumber);

            return true;
        }

        private void SelectionBackColorChange(object grid, int currentRowIndex, string data)
        {
            XEditGrid grdObject = (XEditGrid)grid;

            //선택된 Row에대해서 색을 변경한다
            //data   Y :색을 변경, N :색을 변경 해제
            //image 설정
            if (data == "Y")
            {
                //image 변경
                if (grdObject.RowHeaderVisible)
                    grdObject[currentRowIndex + grdObject.HeaderHeights.Count, 1].Image = this.ImageList.Images[1];
                else
                    grdObject[currentRowIndex + grdObject.HeaderHeights.Count, 0].Image = this.ImageList.Images[1];
            }
            else
            {
                //image 변경
                if (grdObject.RowHeaderVisible)
                    grdObject[currentRowIndex + grdObject.HeaderHeights.Count, 1].Image = this.ImageList.Images[0];
                else
                    grdObject[currentRowIndex + grdObject.HeaderHeights.Count, 0].Image = this.ImageList.Images[0];
            }
        }

        private void SetSelectPatientList(int aRowNumber)
        {
            int currentRow = aRowNumber;
            bool select = false;
            int start_row = -1;
            int end_row = -1;

            if (aRowNumber < 0)
            {
                start_row = 0;
                end_row = this.grdPatientList.RowCount;
            }
            else
            {
                start_row = aRowNumber;
                end_row = aRowNumber + 1;
            }

            for (int i = start_row; i < end_row; i++)
            {
                if (this.IsExistSelectedOrder(this.grdPatientList.GetItemString(i, "pk_order"),
                                              this.grdPatientList.GetItemString(i, "naewon_date"),
                                              this.grdPatientList.GetItemString(i, "gwa"),
                                              this.grdPatientList.GetItemString(i, "doctor")))
                    select = true;
                else
                    select = false;

                if (select)
                {
                    grdPatientList.SetItemValue(i, "select", "Y");
                    SelectionBackColorChange(grdPatientList, i, "Y");
                }
                else
                {
                    grdPatientList.SetItemValue(i, "select", "N");
                    SelectionBackColorChange(grdPatientList, i, "N");
                }
            }
            this.childSetImage();
        }

        private bool IsExistSelectedOrder(string aNaewonKey, string aOrderDate, string aGwa, string aDoctor)
        {
            if (rbtOut.Checked == true)
            {
                DataRow[] dr = this.grdOrderList.LayoutTable.Select("select = 'Y' AND pk_order=" + aNaewonKey);

                if (dr.Length > 0) return true;
            }
            else
            {
                DataRow[] dr = null;

                dr = this.grdOrderList.LayoutTable.Select("pk_order=" + aNaewonKey + " AND naewon_date='" + aOrderDate + "' AND gwa='" + aGwa + "' AND doctor='" + aDoctor + "' AND select = 'Y'");

                if (dr.Length > 0) return true;
            }

            return false;
        }

        private void childSetImage()
        {
            for (int i = 0; i < this.grdOrderList.RowCount; i++)
            {
                string child_yn = this.grdOrderList.GetItemString(i, "child_yn");

                switch (child_yn)
                {
                    case "Y":
                        this.grdOrderList[i, "child_yn"].Image = this.ImageList.Images[3];
                        break;
                    case "N":
                        this.grdOrderList[i, "child_yn"].Image = this.ImageList.Images[2];
                        break;
                    default:
                        this.grdOrderList[i, "child_yn"].Image = this.ImageList.Images[2];
                        break;

                }
                this.grdOrderList[i, "child_yn"].ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            }
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            this.grdSelectAll(this.grdOrderList);
        }
        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            this.grdDeleteAll(this.grdOrderList);
        }

        private void grdOrderList_QueryEnd(object sender, QueryEndEventArgs e)
        {
            childSetImage();
        }

        private void grdOrderList_MouseDown(object sender, MouseEventArgs e)
        {
            int rowIndex;
            if (e.Button == MouseButtons.Left && e.Clicks == 1)
            {
                rowIndex = grdOrderList.GetHitRowNumber(e.Y);
                if (rowIndex < 0) return;

                if (grdOrderList.CurrentColNumber == 0)
                {
                    if (
                          ((this.mIO_GUBUN == "I" && grdOrderList.GetItemString(rowIndex, "io_yn") != "O")
                           || (this.mIO_GUBUN == "O" && grdOrderList.GetItemString(rowIndex, "io_yn") != "I")
                          )
                          && this.INPUT_GUBUN != "D7"
                        )
                    {
                        //불용처리된 것은 선택을 막는다.
                        if (grdOrderList.GetItemString(rowIndex, "bulyong_check") == "Y")
                        {
                            //불용인 경우에는 해당 항목의 심사기준을 보여준다.
                            mbxMsg = this.mOrderBiz.LoadSimsa_comment(grdOrderList.GetItemString(rowIndex, "hangmog_code"));
                            mbxCap = NetInfo.Language == LangMode.Jr ? Resources.mSubMenu_Click_2 : "확인";
                            if (!TypeCheck.IsNull(mbxMsg)) XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Information);
                            return;
                        }

                        if (grdOrderList.GetItemString(rowIndex, "select") == "N")
                        {
                            // 入院オーダで院内採用薬ではない場合は確認メッセージ出力
                            if (this.grdOrderList.GetItemString(rowIndex, "wonnae_drg_yn") != "Y"
                                && this.mIO_GUBUN == "I"
                                && (this.grdOrderList.GetItemString(rowIndex, "order_gubun").Substring(1) == "C"
                                    || this.grdOrderList.GetItemString(rowIndex, "order_gubun").Substring(1) == "D"
                                    || this.grdOrderList.GetItemString(rowIndex, "order_gubun").Substring(1) == "B"
                                   )
                                )
                            {
                                if (XMessageBox.Show("[ " + this.grdOrderList.GetItemString(rowIndex, "hangmog_name") + Resources.MSGgrdSelectAll_, Resources.mSubMenu_Click_2, MessageBoxButtons.YesNo) == DialogResult.No)
                                    return;
                            }
                            grdOrderList.SetItemValue(rowIndex, "select", "Y");
                            SelectionBackColorChange(sender, rowIndex, "Y");
                        }
                        else
                        {
                            grdOrderList.SetItemValue(rowIndex, "select", "N");
                            SelectionBackColorChange(sender, rowIndex, "N");
                        }

                        SetSelectPatientList(this.grdPatientList.CurrentRowNumber);
                    }
                    else
                    {

                    }
                }
            }
            else if (e.Button == MouseButtons.Right && e.Clicks == 1)
            {
                this.grdOrderList.UnSelectAll();
                this.grdOrderList.SetFocusToItem(this.grdOrderList.GetHitRowNumber(e.Y), "select");

                string specific_comment = this.grdOrderList.GetItemString(this.grdOrderList.GetHitRowNumber(e.Y), "specific_comment");

                // リハビリ依頼書
                if (specific_comment == "18" || specific_comment == "19")
                    this.mSubMenu.TrackPopup(this.PointToScreen(new Point(e.X + this.pnlLeft.Width, e.Y + this.pnlTop.Height + this.pnlRTop.Height + this.tabPrePost.Height)));

                // 栄養食事相談依頼書
                if (specific_comment == "21")
                    this.mSubMenu.TrackPopup(this.PointToScreen(new Point(e.X + this.pnlLeft.Width, e.Y + this.pnlTop.Height + this.pnlRTop.Height + this.tabPrePost.Height)));
            }
        }

        private void grdPatientList_MouseDown(object sender, MouseEventArgs e)
        {
            //delete by jc [リストで選択機能を外してほしいって事で注釈処理] 2012/03/22
            int rowIndex;

            if (e.Button == MouseButtons.Left && e.Clicks == 1)
            {
                rowIndex = grdPatientList.GetHitRowNumber(e.Y);
                if (rowIndex < 0) return;

                if (grdPatientList.CurrentColName != "select")
                {
                    return;
                }
                if (grdPatientList.GetItemString(rowIndex, "select") == "N")
                {
                    grdPatientList.SetItemValue(rowIndex, "select", "Y");
                    SelectionBackColorChange(grdPatientList, rowIndex, "Y");
                    this.grdSelectAll(this.grdOrderList);
                }
                else
                {
                    grdPatientList.SetItemValue(rowIndex, "select", "N");
                    SelectionBackColorChange(grdPatientList, rowIndex, "N");
                    this.grdDeleteAll(this.grdOrderList);
                }

            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            int selecedRowCount = 0;

            for (int i = 0; i < this.grdOrderList.DisplayRowCount; i++)
            {
                if (this.grdOrderList.GetItemString(i, "select") == "Y")
                {
                    selecedRowCount++;

                    switch (this.grdOrderList.GetItemString(i, "input_tab"))
                    {
                        case "01":
                        case "03":

                            if (this.grdOrderList.GetItemString(i, "input_gubun") == "CK") // 代行オーダーのみinput_gubunを変更する。
                                this.grdOrderList.SetItemValue(i, "input_gubun", ((XButton)sender).Tag.ToString());

                            break;

                        case "04":
                        case "05":
                        case "06":
                        case "07":
                        case "08":
                        case "09":
                        case "10":
                        case "11":
                            this.grdOrderList.SetItemValue(i, "input_gubun", "D0");
                            break;
                    }
                    this.grdOrderList.SetItemValue(i, "muhyo", "N");
                }
            }

            if (selecedRowCount == 0 && this.grdOrderList.DeletedRowCount == 0)
            {
                if (XMessageBox.Show(Resources.MSG_btnProcess_Click_, Resources.mSubMenu_Click_2, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    this.pbxUnderArrow.Visible = true;
                    timer_icon.Start();
                    return;
                }
            }

            //if (!this.grdOrderList.SaveLayout())
            if (!SaveGridOrder())
            {
                XMessageBox.Show(Resources.MSG_btnProcess_Click_2 + rbtOut.Checked.ToString() + "rbtIn -> " + rbtIn.Checked.ToString(), Resources.mSubMenu_Click_2);
            }
            else
            {
                this.grdPatientList.QueryLayout(false);
            }
        }



        private void timer_icon_Tick(object sender, EventArgs e)
        {
            if (pbxUnderArrow.Visible == true)
            {
                pbxUnderArrow.Visible = false;
                timer_icon.Stop();
            }
        }

        private void grdPatientList_QueryEnd(object sender, QueryEndEventArgs e)
        {
            if (this.grdPatientList.RowCount == 0)
                this.grdOrderList.Reset();
        }

        private void btnList_ButtonClick(object sender, ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Query:
                    e.IsBaseCall = false;

                    this.grdPatientList.QueryLayout(false);
                    this.grdOrderList.QueryLayout(false);

                    break;
                case FunctionType.Delete:
                    e.IsBaseCall = false;

                    for (int i = this.grdOrderList.DisplayRowCount - 1; i >= 0; i--)
                    {
                        if (this.grdOrderList.GetItemString(i, "select") == "Y")
                        {
                            this.grdOrderList.DeleteRow(i);
                        }
                    }

                    //if (!this.grdOrderList.SaveLayout())
                    if (!SaveGridOrder())
                    {
                    }
                    else
                        this.grdPatientList.QueryLayout(false);

                    break;
                case FunctionType.Close:
                    e.IsBaseCall = false;
                    if (this.mApprove_Force)
                    {
                        if (this.mOrderBiz.GetNotApproveOrderCnt(this.mIO_GUBUN, UserInfo.UserID, "Y", "N", "%") > 0)
                        {
                            XMessageBox.Show(Resources.MSG_btnList_ButtonClick_3, Resources.mSubMenu_Click_2);
                            return;
                        }
                        else
                            Close();
                    }
                    else
                        Close();
                    break;
            }
        }

        private void grdOrderList_GridFindClick(object sender, GridFindClickEventArgs e)
        {
            XEditGrid grid = sender as XEditGrid;

            switch (e.ColName)
            {
                case "jundal_table_out":

                    //((XFindBox)((XEditGridCell)grid.CellInfos[e.ColName]).CellEditor.Editor).FindWorker = this.mOrderBiz.GetFindWorker("jundal_table_out_hangmog", grid.GetItemString(e.RowNumber, "hangmog_code"));
                    ((XFindBox)((XEditGridCell)grid.CellInfos[e.ColName]).CellEditor.Editor).FindWorker =
                        LoadFindWorker("jundal_table_out_hangmog", grid.GetItemString(e.RowNumber, "hangmog_code"));

                    break;

                case "jundal_part_out":

                    //((XFindBox)((XEditGridCell)grid.CellInfos[e.ColName]).CellEditor.Editor).FindWorker = this.mOrderBiz.GetFindWorker("jundal_part_out_hangmog", grid.GetItemString(e.RowNumber, "hangmog_code"));
                    ((XFindBox)((XEditGridCell)grid.CellInfos[e.ColName]).CellEditor.Editor).FindWorker =
                        LoadFindWorker("jundal_part_out_hangmog", grid.GetItemString(e.RowNumber, "hangmog_code"));

                    break;



                case "jundal_table_inp":

                    //((XFindBox)((XEditGridCell)grid.CellInfos[e.ColName]).CellEditor.Editor).FindWorker = this.mOrderBiz.GetFindWorker("jundal_table_inp_hangmog", grid.GetItemString(e.RowNumber, "hangmog_code"));
                    ((XFindBox)((XEditGridCell)grid.CellInfos[e.ColName]).CellEditor.Editor).FindWorker =
                        LoadFindWorker("jundal_table_inp_hangmog", grid.GetItemString(e.RowNumber, "hangmog_code"));

                    break;

                case "jundal_part_inp":

                    //((XFindBox)((XEditGridCell)grid.CellInfos[e.ColName]).CellEditor.Editor).FindWorker = this.mOrderBiz.GetFindWorker("jundal_part_inp_hangmog", grid.GetItemString(e.RowNumber, "hangmog_code"));
                    ((XFindBox)((XEditGridCell)grid.CellInfos[e.ColName]).CellEditor.Editor).FindWorker =
                        LoadFindWorker("jundal_part_inp_hangmog", grid.GetItemString(e.RowNumber, "hangmog_code"));

                    break;

                case "move_part_out":
                case "move_part_inp":

                    //((XFindBox)((XEditGridCell)grid.CellInfos[e.ColName]).CellEditor.Editor).FindWorker = this.mOrderBiz.GetFindWorker("move_part_hangmog", grid.GetItemString(e.RowNumber, "hangmog_code"));
                    ((XFindBox)((XEditGridCell)grid.CellInfos[e.ColName]).CellEditor.Editor).FindWorker =
                        LoadFindWorker("move_part_hangmog", grid.GetItemString(e.RowNumber, "hangmog_code"));

                    break;
            }
        }

        /// <summary>
        /// Load findworker instead of calling mOrderBiz.GetFindWorker method
        /// </summary>
        /// <param name="colName"></param>
        /// <param name="argu1"></param>
        /// <returns></returns>
        private XFindWorker LoadFindWorker(string colName, string argu1)
        {
            XFindWorker fdwTemp = new XFindWorker();
            fdwTemp.AutoQuery = true;
            fdwTemp.SearchImeMode = System.Windows.Forms.ImeMode.NoControl;
            fdwTemp.ParamList = new List<string>(new String[] { "colName", "argu1" });
            fdwTemp.SetBindVarValue("colName", colName);
            fdwTemp.SetBindVarValue("argu1", argu1);
            fdwTemp.ExecuteQuery = LoadDataFdwTemp;

            fdwTemp.ColInfos.Add("gwa", "部署コード", FindColType.String, 100, 0, true, FilterType.Yes);
            fdwTemp.ColInfos.Add("gwa_name", "部署名", FindColType.String, 300, 0, true, FilterType.No);

            return fdwTemp;
        }

        /// <summary>
        /// Execute query for fdwTemp
        /// </summary>
        /// <param name="varlist"></param>
        /// <returns></returns>
        private IList<object[]> LoadDataFdwTemp(BindVarCollection varlist)
        {
            IList<object[]> dataList = new List<object[]>();
            GetFindWorkerArgs args = new GetFindWorkerArgs();
            GetFindWorkerRequestInfo info = new GetFindWorkerRequestInfo(varlist["colName"].VarValue, varlist["argu1"].VarValue, "", "");
            args.Info1 = info;
            GetFindWorkerResult result = CloudService.Instance.Submit<GetFindWorkerResult, GetFindWorkerArgs>(args);
            if (result != null && result.Info1 != null && result.Info1.Count > 0)
            {
                foreach (GetFindWorkerResponseInfo infoC1 in result.Info1)
                {
                    dataList.Add(new object[]
                            {
                                infoC1.Code,
                                infoC1.Name
                            });
                }
            }
            return dataList;
        }

        /// <summary>
        /// Save grdOrder
        /// </summary>
        /// <returns></returns>
        private bool SaveGridOrder()
        {
            bool saveLayoutResult = false;
            //pre-saving actions
            if (this.rbtOut.Checked == true)
            {
                foreach (DataRow dr in this.grdOrderList.LayoutTable.Rows)
                {
                    if ((dr.RowState == DataRowState.Modified && dr["select"].ToString() == "Y") &&
                         (dr["jundal_part"].ToString() == "HOM" && (dr["specific_comment"].ToString() == "18" || dr["specific_comment"].ToString() == "19")))
                    {

                        OCS.PatientInfo.clsParameter mPatientInfoParam = new IHIS.OCS.PatientInfo.clsParameter();
                        OCS.PatientInfo mSelectedPatientInfo;
                        mSelectedPatientInfo = new IHIS.OCS.PatientInfo(this.Name);

                        mPatientInfoParam.NaewonDate = dr["naewon_date"].ToString();
                        mPatientInfoParam.NaewonKey = dr["pk_order"].ToString();
                        mPatientInfoParam.InputID = dr["doctor"].ToString();
                        mPatientInfoParam.Gwa = dr["gwa"].ToString();
                        mPatientInfoParam.Doctor = dr["doctor"].ToString();

                        mPatientInfoParam.IOEGubun = "O";
                        mPatientInfoParam.Bunho = dr["bunho"].ToString();
                        mPatientInfoParam.IsEnableIpwonReser = true;

                        mSelectedPatientInfo.Parameter = mPatientInfoParam;

                        if (mSelectedPatientInfo.LoadPatientInfo(IHIS.OCS.PatientInfo.QueryMode.NawonFullInfo) == false)
                            XMessageBox.Show(Resources.MSG_grdOrderList_PreSaveLayout, Resources.mSubMenu_Click_2);
                        else
                            this.mOrderBiz.procHQNInterface(mSelectedPatientInfo, "O");
                    }
                }
            }

            //Get all data from grdOrderList
            List<OCSAPPROVEGrdOrderInfo> grdList = LoadListFromGrdOrder();
            if (grdList == null || grdList.Count < 1)
            {
                return false;
            }
            OCSAPPROVESaveLayoutArgs args = new OCSAPPROVESaveLayoutArgs(grdList, UserInfo.UserID, this.SELECTED_IOGUBUN);
            UpdateResult result = CloudService.Instance.Submit<UpdateResult, OCSAPPROVESaveLayoutArgs>(args);
            if (result.ExecutionStatus != ExecutionStatus.Success)
            {
                return false;
            }
            return result.Result;
        }

        /// <summary>
        /// get all data from grdOrderList and put it into List<OCSAPPROVEGrdOrderInfo>
        /// </summary>
        /// <returns></returns>
        private List<OCSAPPROVEGrdOrderInfo> LoadListFromGrdOrder()
        {
            List<OCSAPPROVEGrdOrderInfo> dataList = new List<OCSAPPROVEGrdOrderInfo>();
            for (int i = 0; i < grdOrderList.RowCount; i++)
            {
                if (grdOrderList.GetRowState(i) == DataRowState.Unchanged)
                {
                    continue;
                }

                OCSAPPROVEGrdOrderInfo info = new OCSAPPROVEGrdOrderInfo();
                info.SelectValue = grdOrderList.GetItemString(i, "select");
                info.JundalPartOut = grdOrderList.GetItemString(i, "jundal_part_out");
                info.JundalTableOut = grdOrderList.GetItemString(i, "jundal_table_out");
                info.MovePartOut = grdOrderList.GetItemString(i, "move_part_out");
                info.InputGubun = grdOrderList.GetItemString(i, "input_gubun");
                info.Nalsu = grdOrderList.GetItemString(i, "nalsu");
                info.Suryang = grdOrderList.GetItemString(i, "suryang");
                info.Dv = grdOrderList.GetItemString(i, "dv");
                info.Muhyo = grdOrderList.GetItemString(i, "muhyo");
                info.Pkocs1003 = grdOrderList.GetItemString(i, "pkocskey");

                info.JundalPartInp = grdOrderList.GetItemString(i, "jundal_part_inp");
                info.JundalTableInp = grdOrderList.GetItemString(i, "jundal_table_inp");
                info.MovePartInp = grdOrderList.GetItemString(i, "move_part_inp");

                info.RowState = grdOrderList.GetRowState(i).ToString();

                dataList.Add(info);
            }
            if (grdOrderList.DeletedRowTable != null && grdOrderList.DeletedRowTable.Rows.Count > 0)
            {
                foreach (DataRow row in grdOrderList.DeletedRowTable.Rows)
                {
                    OCSAPPROVEGrdOrderInfo info = new OCSAPPROVEGrdOrderInfo();
                    info.Pkocs1003 = row["pkocskey"].ToString();
                    info.RowState = DataRowState.Deleted.ToString();
                    dataList.Add(info);
                }
            }

            return dataList;
        }

//        #region XSavePeformer
//        public class XSavePeformer : IHIS.Framework.ISavePerformer
//        {
//            private OCSAPPROVE parent = null;

//            public XSavePeformer(OCSAPPROVE parent)
//            {
//                this.parent = parent;
//            }

//            public bool Execute(char callerId, RowDataItem item)
//            {
//                string cmdText = "";
//                object t_chk = "";
//                string spName = "";

//                string aGubun = "";

//                bool result = true;
//                ArrayList inList = new ArrayList();
//                ArrayList outList = new ArrayList();

//                item.BindVarList.Add("q_user_id", UserInfo.UserID);
//                item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);

//                item.BindVarList.Add("f_approve_id", UserInfo.UserID);
//                item.BindVarList.Add("f_approve_date", EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
//                item.BindVarList.Add("f_approve_time", EnvironInfo.GetSysDateTime().ToString("HHmm"));

//                item.BindVarList.Add("f_input_id", UserInfo.UserID);

//                Service.BeginTransaction();


//                switch (item.RowState)
//                {
//                    case DataRowState.Modified:

//                        if (item.BindVarList["f_select"].VarValue == "Y")
//                        {
//                            // 事前承認の場合は既存のinput_gubunをそのまま使う。
//                            //if (item.BindVarList["f_postapprove_yn"].VarValue == "Y")
//                            //{

//                            //}

//                            if (parent.SELECTED_IOGUBUN == "O")
//                            {
//                                cmdText = @"UPDATE OCS1003 A
//                                               SET A.UPD_ID       = :q_user_id
//                                                 , A.UPD_DATE     = SYSDATE
//                                                 , A.JUNDAL_PART  = :f_jundal_part_out
//                                                 , A.JUNDAL_TABLE = :f_jundal_table_out
//                                                 , A.MOVE_PART    = :f_move_part_out
//                                                 , A.INPUT_GUBUN  = :f_input_gubun
//                                                 , A.NALSU        = :f_nalsu
//                                                 , A.SURYANG      = :f_suryang
//                                                 , A.DV           = :f_dv
//
//                                                 , A.APPROVE_YN   = 'Y'
//                                                 , A.APPROVE_ID   = :f_approve_id
//                                                 , A.APPROVE_DATE = :f_approve_date
//                                                 , A.APPROVE_TIME = :f_approve_time
//
//                                                 , A.INPUT_ID     = :f_input_id
//                                                 , A.MUHYO        = :f_muhyo
//                                                 
//                                             WHERE A.HOSP_CODE    = :f_hosp_code
//                                               AND A.PKOCS1003    = :f_pkocskey
//                                               ";
//                            }
//                            else
//                            {
//                                cmdText = @"UPDATE OCS2003 A
//                                               SET A.UPD_ID       = :q_user_id
//                                                 , A.UPD_DATE     = SYSDATE
//                                                 , A.JUNDAL_PART  = :f_jundal_part_inp
//                                                 , A.JUNDAL_TABLE = :f_jundal_table_inp
//                                                 , A.MOVE_PART    = :f_move_part_inp
//                                                 , A.INPUT_GUBUN  = :f_input_gubun
//                                                 , A.NALSU        = :f_nalsu
//                                                 , A.SURYANG      = :f_suryang
//                                                 , A.DV           = :f_dv
//
//                                                 , A.APPROVE_YN   = 'Y'
//                                                 , A.APPROVE_ID   = :f_approve_id
//                                                 , A.APPROVE_DATE = :f_approve_date
//                                                 , A.APPROVE_TIME = :f_approve_time
//
//                                                 , A.INPUT_ID     = :f_input_id
//                                                 , A.MUHYO        = :f_muhyo
//
//                                             WHERE A.HOSP_CODE    = :f_hosp_code
//                                               AND A.PKOCS2003    = :f_pkocskey
//                                               ";
//                            }

//                            result = Service.ExecuteNonQuery(cmdText, item.BindVarList);

//                            if (!result)
//                            {
//                                XMessageBox.Show(Service.ErrMsg + Service.ErrFullMsg + Service.ErrCode, "ERR");
//                            }
//                        }

//                        break;

//                    case DataRowState.Deleted:

//                        if (parent.SELECTED_IOGUBUN == "O")
//                        {
//                            cmdText = @"DELETE OCS1003 A
//                                         WHERE A.HOSP_CODE    = :f_hosp_code
//                                           AND A.PKOCS1003    = :f_pkocskey
//                                           ";
//                        }
//                        else
//                        {
//                            cmdText = @"DELETE OCS2003 A
//                                         WHERE A.HOSP_CODE    = :f_hosp_code
//                                           AND A.PKOCS2003    = :f_pkocskey
//                                           ";
//                        }

//                        result = Service.ExecuteNonQuery(cmdText, item.BindVarList);

//                        break;
//                }

//                if (result)
//                    Service.CommitTransaction();
//                else
//                    Service.RollbackTransaction();

//                return result;
//            }
//        }
//        #endregion XSavePerformer

        private void grdOrderList_GridCellPainting(object sender, XGridCellPaintEventArgs e)
        {
            if (e.ColName != "select" && e.ColName != "child_yn")
            {
                if (e.DataRow["postapprove_yn"].ToString() != "Y")
                {
                    e.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    e.ForeColor = Color.DarkGreen;
                }
            }
        }

        private void tabPrePost_SelectionChanged(object sender, EventArgs e)
        {
            this.setButton(this.rbtOut, this.tabPrePost);

            this.grdOrderList.QueryLayout(false);
        }

        private void setButton(RadioButton aRbt, XTabControl aTab)
        {
            if (aRbt.Checked == true)
            {
                this.btnProcessD0.Visible = true;
                this.btnProcessD0.Text = Resources.MsgBtnProcessD0;
                this.btnProcessD4.Visible = false;
                this.btnProcessD7.Visible = false;
            }
            else
            {
                if (aTab.SelectedTab.Tag.ToString() == "Y")
                {
                    this.btnProcessD0.Visible = true;
                    this.btnProcessD0.Text = Resources.MsgBtnProcessD0;
                    this.btnProcessD4.Visible = false;
                    this.btnProcessD7.Visible = false;
                }
                else
                {
                    this.btnProcessD0.Visible = true;
                    this.btnProcessD0.Text = Resources.MSG_setButton_1;
                    this.btnProcessD4.Visible = true;
                    this.btnProcessD4.Text = Resources.MSG_setButton_2;
                    this.btnProcessD7.Visible = true;
                    this.btnProcessD7.Text = Resources.MSG_setButton_3;
                }
            }
        }

        private void grdOrderList_PreSaveLayout(object sender, GridRecordEventArgs e)
        {
            //// 承認時、問診システムにデータ転送
            //if (this.rbtOut.Checked == true)
            //{
            //    foreach (DataRow dr in this.grdOrderList.LayoutTable.Rows)
            //    {
            //        if ((dr.RowState == DataRowState.Modified && dr["select"].ToString() == "Y") &&
            //             (dr["jundal_part"].ToString() == "HOM" && (dr["specific_comment"].ToString() == "18" || dr["specific_comment"].ToString() == "19")))
            //        {

            //            OCS.PatientInfo.clsParameter mPatientInfoParam = new IHIS.OCS.PatientInfo.clsParameter();
            //            OCS.PatientInfo mSelectedPatientInfo;
            //            mSelectedPatientInfo = new IHIS.OCS.PatientInfo(this.Name);

            //            mPatientInfoParam.NaewonDate = dr["naewon_date"].ToString();
            //            mPatientInfoParam.NaewonKey = dr["pk_order"].ToString();
            //            mPatientInfoParam.InputID = dr["doctor"].ToString();
            //            mPatientInfoParam.Gwa = dr["gwa"].ToString();
            //            mPatientInfoParam.Doctor = dr["doctor"].ToString();

            //            mPatientInfoParam.IOEGubun = "O";
            //            mPatientInfoParam.Bunho = dr["bunho"].ToString();
            //            mPatientInfoParam.IsEnableIpwonReser = true;

            //            mSelectedPatientInfo.Parameter = mPatientInfoParam;

            //            if (mSelectedPatientInfo.LoadPatientInfo(IHIS.OCS.PatientInfo.QueryMode.NawonFullInfo) == false)
            //                XMessageBox.Show(Resources.MSG_grdOrderList_PreSaveLayout, Resources.mSubMenu_Click_2);
            //            else
            //                this.mOrderBiz.procHQNInterface(mSelectedPatientInfo, "O");
            //        }
            //    }
            //}

        }
    }


}