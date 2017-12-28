#region 사용 NameSpace 지정
using System;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.Framework;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Arguments.Cpls;
using IHIS.CloudConnector.Contracts.Results.Cpls;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Models.Cpls;
using IHIS.CloudConnector.Contracts.Results.System;
using System.Data.SqlClient;
using System.Text;
using IHIS.CloudConnector.Contracts.Arguments.System;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Caching;
using System.Globalization;
using IHIS.CPLS.Properties;
#endregion

namespace IHIS.CPLS
{
	/// <summary>
	/// CPL0000Q00
	/// </summary>
	[ToolboxItem(false)]
	public partial class CPL0000Q00 : IHIS.Framework.XScreen
    {

        #region [CPL0000Q00]
        public CPL0000Q00()
		{
            try
            {
                // Call Windows Form
                InitializeComponent();

                // https://sofiamedix.atlassian.net/browse/MED-16384
                this.grdOrderList.ParamList = new List<string>(new string[] { "f_hosp_code", "f_bunho" });
                this.grdOrderList.ExecuteQuery = GetGrdOrderList;
                this.grdResult.ParamList = new List<string>(new string[] { "f_hosp_code", "f_bunho", "f_order_date", "f_gwa", "f_jundal_gubun" });
                this.grdResult.ExecuteQuery = GetGrdResult;
                this.layMakeTabPage.ParamList = new List<string>(new string[] { "f_hosp_code" });
                this.layMakeTabPage.ExecuteQuery = GetLayTabPage;
                this.ApplyMultiLanguageForDW();
            }
            catch (Exception x)
            {
                XMessageBox.Show(x.Message + "---- " + x.StackTrace);
            }

		}
        #endregion

        #region [Reques/Receive Event]
        /// <summary>
        /// Docking Screen에서 환자정보 변경시 Raise
        /// </summary>
        public override void OnReceiveBunHo(XPatientInfo info)
        {
            if (info != null && !TypeCheck.IsNull(info.BunHo))
            {
                this.paBox.Focus();
                this.paBox.SetPatientID(info.BunHo);
            }
        }

        /// <summary>
        /// 현Screen의 등록번호를 타Screen에 넘긴다
        /// </summary>
        public override XPatientInfo OnRequestBunHo()
        {
            if (!TypeCheck.IsNull(this.paBox.BunHo))
            {
                return new XPatientInfo(this.paBox.BunHo, "", "", "", this.ScreenName);
            }

            return null;
        }
        #endregion 

        #region [CPL0000Q00_ScreenOpen]
        private void CPL0000Q00_ScreenOpen(object sender, IHIS.Framework.XScreenOpenEventArgs e)
        {
            MakeTabPage();

            if (e.OpenParam != null)
            {
                paBox.SetPatientID(e.OpenParam["bunho"].ToString());
            }
            else
            {
                // Get ScreenBunho from pre-screen.
                XPatientInfo patientInfo = XScreen.GetPreviousScreenBunHo(true);

                if (patientInfo == null || (patientInfo != null && TypeCheck.IsNull(patientInfo.BunHo)))
                {
                    // If not pre-screen, get ScreenBunho from Entire screen opened.
                    patientInfo = XScreen.GetOtherScreenBunHo(this, true);
                }

                if (patientInfo != null && !TypeCheck.IsNull(patientInfo.BunHo))
                {
                    this.paBox.Focus();
                    this.paBox.SetPatientID(patientInfo.BunHo);
                }
                else
                {
                    this.paBox.Focus();
                }
            }

            // Exclude Flashing on Order screen'button
            if (!TypeCheck.IsNull(paBox.BunHo))
            {
                if (UserInfo.UserGubun == UserType.Doctor)
                {
//                    string cmdText = @"UPDATE OCS5010
//                                           SET USER_ID      = :q_user_id,
//                                               UPD_DATE     = SYSDATE   ,
//                                               CONFIRM_YN   = 'Y'
//                                         WHERE HOSP_CODE    = :f_hosp_code
//                                           AND DOCTOR       = :f_doctor      
//                                           AND BUNHO        = :f_bunho       
//                                           AND JUNDAL_TABLE = :f_jundal_table";
//                    BindVarCollection bc = new BindVarCollection();
//                    bc.Add("f_hosp_code", EnvironInfo.HospCode);
//                    bc.Add("f_doctor", UserInfo.UserID);
//                    bc.Add("f_bunho", this.paBox.BunHo);
//                    bc.Add("f_jundal_table", "CPL");

//                    Service.ExecuteNonQuery(cmdText, bc);

                    // https://sofiamedix.atlassian.net/browse/MED-16384
                    CPL0000Q00UpdateOCS5010Args args = new CPL0000Q00UpdateOCS5010Args();
                    args.Bunho = this.paBox.BunHo;
                    args.Doctor = UserInfo.DoctorID;
                    args.HospCode = UserInfo.HospCode;
                    args.JundalTable = "CPL";
                    args.UserId = UserInfo.UserID;
                    UpdateResult res = CloudService.Instance.Submit<UpdateResult, CPL0000Q00UpdateOCS5010Args>(args);

                    Service.WriteLog("[CPL0000Q00 - UPDATE OCS0510]");
                    Service.WriteLog(res.ExecutionStatus.ToString());
                    Service.WriteLog("Result: " + res.Result.ToString());
                    Service.WriteLog("Message: " + res.Msg);
                }
            }
            this.paBox.Select();
            this.paBox.Focus();
        }
        #endregion

        #region [MakeTabPage]
        private void MakeTabPage()
        {
            //bool isExists = false;
            this.layMakeTabPage.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layMakeTabPage.QueryLayout(true);

            //2016.06.03 kdk 修正
            // 텝 페이지 생성
            for (int i = 0; i < layMakeTabPage.RowCount; i++)
            {
                IHIS.X.Magic.Controls.TabPage tabPage =
                    new IHIS.X.Magic.Controls.TabPage(layMakeTabPage.GetItemString(i, "ment"));
                tabPage.Tag = layMakeTabPage.GetItemString(i, "code");
                tabResult.TabPages.Add(tabPage);
            }


            //2016.06.03 kdk 既存のコード
             //텝 페이지 생성
            //this.tabResult.SelectionChanged -= new System.EventHandler(this.tabResult_SelectionChanged);
            //for (int i = 0; i < layMakeTabPage.RowCount; i++)
            //{
            //    IHIS.X.Magic.Controls.TabPage tabPage = new IHIS.X.Magic.Controls.TabPage(layMakeTabPage.GetItemString(i, "ment"));
            //    tabPage.Tag = layMakeTabPage.GetItemString(i, "code");

            //    foreach (IHIS.X.Magic.Controls.TabPage mtab in tabResult.TabPages)
            //    {
            //        if (tabPage.Title == mtab.Title)
            //        {
            //            isExists = true;
            //            break;
            //        }
            //    }
            //    if (!isExists) tabResult.TabPages.Add(tabPage);
            //}
           
            //this.tabResult.SelectionChanged += new System.EventHandler(this.tabResult_SelectionChanged);
        }
        #endregion

        #region [Control tabResult]
        private void tabResult_SelectionChanged(object sender, EventArgs e)
        {
            this.grdResult.QueryLayout(true);
        }

        private void SetTabColor()
        {
            for (int i = 0; i < this.tabResult.TabPages.Count; i++)
            {
                tabResult.TabPages[i].ImageIndex = -1;
            }

            for (int i = 0; i < this.grdResult.RowCount; i++)
            {
                tabResult.TabPages[0].ImageIndex = 0;

                for (int j = 0; j < tabResult.TabPages.Count; j++)
                {
                    if (this.grdResult.GetItemString(i, "jundal_gubun") == tabResult.TabPages[j].Tag.ToString())
                        tabResult.TabPages[j].ImageIndex = 0;
                }
            }
        }
        #endregion

        #region [paBox_PatientSelected]
        private void paBox_PatientSelected(object sender, System.EventArgs e)
        {
            //2016.03 kdk 修正
            this.tabResult.SelectionChanged -= new System.EventHandler(this.tabResult_SelectionChanged);
            this.tabResult.SelectedIndex = 0;
            this.tabResult.SelectionChanged += new System.EventHandler(this.tabResult_SelectionChanged);
            this.grdOrderList.QueryLayout(true);

            this.SetTabColor();
            this.grdResult.Refresh();
            if (this.grdOrderList.RowCount <=0)
            {
                for (int i = 0; i < this.tabResult.TabPages.Count; i++)
                {
                    tabResult.TabPages[i].ImageIndex = -1;
                }
                this.grdResult.QueryLayout(true);
            }

            // https://sofiamedix.atlassian.net/browse/MED-16384
            if (!TypeCheck.IsNull(paBox.BunHo))
            {
                this.SyncCPLResult();
                this.grdResult.QueryLayout(true);
            }
        }
        #endregion

        #region [btnLis_ButtonClick]
        private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Query:

                    e.IsBaseCall = false;
                    this.grdOrderList.QueryLayout(true);
                  
                    //this.paBox.Focus();

                    break;
                case FunctionType.Reset:

                    e.IsBaseCall = false;

                    break;
                default:
                    break;
            }
        }
        #endregion

        private void grdOrderList_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdOrderList.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdOrderList.SetBindVarValue("f_bunho", this.paBox.BunHo);
        }

        private void grdOrderList_RowFocusChanged(object sender, RowFocusChangedEventArgs e)
        {
            this.tabResult.SelectionChanged -= new System.EventHandler(this.tabResult_SelectionChanged);
            this.tabResult.SelectedIndex = 0;
            this.tabResult.SelectionChanged += new System.EventHandler(this.tabResult_SelectionChanged);
            this.grdResult.QueryLayout(true);
            this.SetTabColor();
            this.grdResult.Refresh();
        }

        private void grdResult_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdResult.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdResult.SetBindVarValue("f_bunho", this.paBox.BunHo);
            this.grdResult.SetBindVarValue("f_order_date", this.grdOrderList.GetItemString(this.grdOrderList.CurrentRowNumber, "order_date"));
            this.grdResult.SetBindVarValue("f_jundal_gubun", this.tabResult.SelectedTab.Tag.ToString());
            this.grdResult.SetBindVarValue("f_gwa", this.grdOrderList.GetItemString(this.grdOrderList.CurrentRowNumber, "gwa"));
            this.grdResult.SetBindVarValue("f_doctor", this.grdOrderList.GetItemString(this.grdOrderList.CurrentRowNumber, "doctor"));
        }

        //2016.06.03 必要ではない
        //private void grdResult_QueryEnd(object sender, QueryEndEventArgs e)
        //{
        //  //  if (this.grdResult.RowCount > 0) this.SetTabColor();

        //}


        #region [btnResultPrint_Click]
        private void btnResultPrint_Click(object sender, System.EventArgs e)
		{
            //dwResultPrint.FillData(grdResult.LayoutTable);
            //dwResultPrint.Print();
		}
        #endregion

        #region [btnSigeyul_Click]
        private void btnSigeyul_Click(object sender, System.EventArgs e)
		{
			SetGrdSigeyul();

			FrmSigeyul dlg = new FrmSigeyul(grdSigeyul);
			dlg.ShowDialog();
		}

        private void SetGrdSigeyul()
        {
            grdSigeyul.Reset();

            int row = 0;
            string bunho = paBox.BunHo;
            string hangmog_code, hangmog_name;

            for (int i = 0; i <= this.grdResult.RowCount; i++)
            {
                if (this.grdResult.GetItemString(i, "chk") == "Y")
                {
                    hangmog_code = this.grdResult.GetItemString(i, "hangmog_code");
                    hangmog_name = this.grdResult.GetItemString(i, "gumsa_name");
                    row = grdSigeyul.InsertRow();

                    grdSigeyul.SetItemValue(row, "bunho", bunho);
                    grdSigeyul.SetItemValue(row, "hangmog_code", hangmog_code);
                    grdSigeyul.SetItemValue(row, "hangmog_name", hangmog_name);
                }
            }

            grdSigeyul.AcceptData();
        }
        #endregion

        #region [btnBMLResult_Click]
        private void btnBMLResult_Click(object sender, EventArgs e)
        {
            CommonItemCollection openParams = new CommonItemCollection();
            openParams.Add("bunho", this.paBox.BunHo);
            openParams.Add("send_yn", "Y");
            openParams.Add("close_yn", "Y");

            XScreen.OpenScreenWithParam(this, "CPLS", "CPL0000Q01", ScreenOpenStyle.PopUpFixed, openParams);
        }
        #endregion

        #region https://sofiamedix.atlassian.net/browse/MED-16384

        private List<object[]> GetLayTabPage(BindVarCollection varCollection)
        {
            List<object[]> lstObject = new List<object[]>();

            ComboInOutGubunArgs comboResultFormArgs = new ComboInOutGubunArgs();
            comboResultFormArgs.CodeType = "01";
            ComboResult comboResult = CloudService.Instance.Submit<ComboResult, ComboInOutGubunArgs>(comboResultFormArgs);

            if (comboResult.ExecutionStatus == ExecutionStatus.Success)
            {
                comboResult.ComboItem.ForEach(delegate(ComboListItemInfo item)
                {
                    lstObject.Add(new object[] { item.Code, item.CodeName });
                });
            }

            return lstObject;
        }

        private List<object[]> GetGrdOrderList(BindVarCollection bc)
        {
            List<object[]> lObj = new List<object[]>();

            CPL0000Q00GrdOrderListArgs args = new CPL0000Q00GrdOrderListArgs();
            args.Bunho = bc["f_bunho"].VarValue;
            args.HospCode = bc["f_hosp_code"].VarValue;
            CPL0000Q00GrdOrderListResult res = CloudService.Instance.Submit<CPL0000Q00GrdOrderListResult, CPL0000Q00GrdOrderListArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.OrderListItem.ForEach(delegate(CPL0000Q00GrdOrderListInfo item)
                {
                    lObj.Add(new object[]
                    {
                        item.OrderDate,
                        item.InOutGubun,
                        item.Gwa,
                        item.GwaName,
                        item.Doctor,
                        item.DoctorName,
                    });
                });
            }

            return lObj;
        }

        private List<object[]> GetGrdResult(BindVarCollection bc)
        {
            List<object[]> lObj = new List<object[]>();

            CPL0000Q00GrdResArgs args = new CPL0000Q00GrdResArgs();
            args.Bunho = bc["f_bunho"].VarValue;
            args.Gwa = bc["f_gwa"].VarValue;
            args.HospCode = bc["f_hosp_code"].VarValue;
            args.JundalGubun = bc["f_jundal_gubun"].VarValue;
            args.OrderDate = bc["f_order_date"].VarValue;
            CPL0000Q00GrdResResult res = CloudService.Instance.Submit<CPL0000Q00GrdResResult, CPL0000Q00GrdResArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.ResItem.ForEach(delegate(CPL0000Q00GrdResInfo item)
                {
                    lObj.Add(new object[]
                    {
                        item.Fkcpl2010,
                        item.HangmogCode,
                        item.SpecimenCode,
                        item.SpecimenName,
                        item.GumsaName,
                        item.Emergency,
                        item.SourceGumsa,
                        item.CplResult,
                        item.ResultDate,
                        item.ResultTime,
                        item.ResultForm,
                        item.ConfirmDate,
                        item.S,
                        item.FromStandard,
                        item.ToStandard,
                        item.Standard,
                        item.PanicYn,
                        item.DeltaYn,
                        item.BeforeResult,
                        item.Danui,
                        item.DanuiName,
                        item.Bunho,
                        item.Gwa,
                        item.Doctor,
                        item.Gubun,
                        item.HoDong,
                        item.HoCode,
                        item.JundalGubun,
                        item.SlipCode,
                        item.SpecimenSer,
                        item.OrderDate,
                        item.OrderTime,
                        item.JubsuDate,
                        item.JubsuTime,
                        item.PartJubsuDate,
                        item.PartJubsuTime,
                        item.ModifyYn,
                        item.ModifyYn1,
                        item.Pkcpl3020,
                        item.GwaName,
                        item.DoctorName,
                        item.GroupHangmog,
                        item.Fkocs,
                        item.ResultStatus,
                        item.ResultComment1,
                        item.ResultComment2,
                        item.Suname,
                        item.Age,
                        item.Sex,
                        "N", // chk
                        item.Jlac10Code
                    });

                    if (!this._lstJlac10Code.Contains(item.Jlac10Code))
                    {
                        this._lstJlac10Code.Add(item.Jlac10Code);
                    }

                    if (!this._lstSpecimenSer.Contains(item.SpecimenSer))
                    {
                        this._lstSpecimenSer.Add(item.SpecimenSer);
                    }
                });
            }

            return lObj;
        }

        #endregion

        #region https://sofiamedix.atlassian.net/browse/MED-15740

        /// <summary>
        /// MSSQL connection
        /// </summary>
        private SqlConnection _connection;

        private List<string> _lstSpecimenSer = new List<string>();
        private List<string> _lstJlac10Code = new List<string>();
        private const string DEV_MACHINE_NAME = "Beckman_AU480";

        /// <summary>
        /// Connects to MSSQL, retrieves data and update its into KCCK DB.
        /// </summary>
        private void SyncCPLResult()
        {
            // Ignores logic sync data if cpl_result is found...
            if (this.IsCplResultExist()) return;

            // ...or spec_auto is not equal to "N"
            if (!UserInfo.CplSpecimenAuto.Equals("N")) return;

            // ...or system is not intergrated to CPL device
            if (NetInfo.Language != LangMode.Vi
                || UserInfo.CplDevBlood != DEV_MACHINE_NAME
                || UserInfo.CplDevUrine != DEV_MACHINE_NAME
                || UserInfo.CplDevBio != DEV_MACHINE_NAME)
            {
                return;
            }

            // Connects to MSSQL
            if (!this.SqlConnect()) return;

            // List hangmog_code mapping to Testcode (from YCao DB)
            //List<string> lstTestcode = new List<string>();
            //for (int i = 0; i < grdResult.RowCount; i++)
            //{
            //    string hangmogCode = grdResult.GetItemString(i, "hangmog_code");

            //    if (!lstTestcode.Contains(hangmogCode))
            //    {
            //        lstTestcode.Add(hangmogCode);
            //    }
            //}

            // Gets cpl_result from CPL devices
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" SELECT                                                                              ");
            sb.AppendLine("     Testcode                                                                        ");
            sb.AppendLine("     ,Result                                                                         ");
            sb.AppendLine("     ,UpdateTime                                                                     ");
            sb.AppendLine("     ,SID                                                                            ");
            sb.AppendLine(" FROM tbl_result                                                                     ");
            sb.AppendLine(" WHERE                                                                               ");
            sb.AppendLine("     1=1                                                                             ");

            if (this._lstSpecimenSer.Count > 0)
            {
                sb.AppendLine(" AND SID IN (" + this.CreateSqlInParam(this._lstSpecimenSer) + ")                ");
            }

            if (this._lstJlac10Code.Count > 0)
            {
                sb.AppendLine(" AND Testcode IN (" + this.CreateSqlInParam(this._lstJlac10Code) + ")            ");
            }
            Service.WriteLog(sb.ToString());

            try
            {
                // Parameters
                //string param = string.Join(",", this._lstSpecimenSer.ToArray());

                SqlCommand cm = new SqlCommand();
                cm.Connection = this._connection;
                cm.CommandText = sb.ToString();
                //cm.Parameters.Add("@specimen_sers", SqlDbType.VarChar).Value = param;

                DataTable resultTbl = new DataTable();
                using (SqlDataAdapter adapter = new SqlDataAdapter(cm))
                {
                    adapter.Fill(resultTbl);
                }

                // Save data into CPL3020
                List<CPL3020U00GrdResultListItemInfo> lstResult;
                List<CPL3020U00GrdNoteUpdateInfo> lstNote;
                this.GetListCPLResult(resultTbl, out lstResult, out lstNote);

                // No data to save
                if (lstResult.Count == 0 && lstNote.Count == 0) return;

                CPL3020U00SavePerformerArgs args = new CPL3020U00SavePerformerArgs();
                args.GrdNoteUpdateItem = lstNote;
                args.GrdResultItem = lstResult;
                args.UserId = UserInfo.UserID;
                UpdateResult res = CloudService.Instance.Submit<UpdateResult, CPL3020U00SavePerformerArgs>(args);

                if (res.ExecutionStatus == ExecutionStatus.Success && res.Result)
                {
                    // Succeeded.
                }
                else
                {
                    // Failed.
                }
            }
            catch (Exception ex)
            {
                Service.WriteLog(ex.Message);
                Service.WriteLog(ex.StackTrace);
            }
            finally
            {
                // Disconnect the current connection
                this.SqlDisconnect();
            }
        }

        private string CreateSqlInParam(List<string> paramList)
        {
            StringBuilder sb = new StringBuilder();
            string result = "";

            try
            {
                for (int i = 0; i < paramList.Count; i++)
                {
                    sb.Append("'" + paramList[i] + "',");
                }

                result = sb.ToString().Remove(sb.ToString().Length - 1);
            }
            catch (Exception ex)
            {
                Service.WriteLog(ex.Message);
                Service.WriteLog(ex.StackTrace);

                result = "";
            }
            finally { }

            return result;
        }

        private void GetListCPLResult(DataTable resultTbl, out List<CPL3020U00GrdResultListItemInfo> lstResult, out List<CPL3020U00GrdNoteUpdateInfo> lstNote)
        {
            lstResult = new List<CPL3020U00GrdResultListItemInfo>();
            lstNote = new List<CPL3020U00GrdNoteUpdateInfo>();
            CPL3020U00GrdResultListItemInfo resultItem;
            CPL3020U00GrdNoteUpdateInfo noteItem;
            //DataRow[] specimenRows = resultTbl.Select("", "SID desc");
            string tempSpecimenSer = null;

            for (int i = 0; i < grdResult.RowCount; i++)
            {
                try
                {
                    // Returns 1 row only
                    //string hangmogCode = grdResult.GetItemString(i, "hangmog_code");
                    //DataRow[] specimenRow = resultTbl.Select(string.Format("Testcode='{0}'", hangmogCode), "SID desc");
                    string jlacCode = grdResult.GetItemString(i, "jlac10_code");
                    DataRow[] specimenRow = resultTbl.Select(string.Format("Testcode='{0}'", jlacCode), "SID desc");

                    // Not mapping to YCao DB yet?
                    if (specimenRow.Length == 0) continue;

                    #region Get result items

                    resultItem = new CPL3020U00GrdResultListItemInfo();
                    resultItem.BeforeResult = grdResult.GetItemString(i, "before_result");
                    resultItem.Bunho = paBox.BunHo;
                    resultItem.Comments = "";
                    //resultItem.ConfirmYn = grdResult.GetItemString(i, "confirm_yn"); // TODO
                    resultItem.ConfirmYn = "Y";
                    resultItem.CplResult = specimenRow[0]["Result"].ToString(); // *****
                    resultItem.DanuiName = grdResult.GetItemString(i, "danui_name");
                    resultItem.DataRowState = DataRowState.Added.ToString();
                    resultItem.DeltaYn = grdResult.GetItemString(i, "delta_yn");
                    resultItem.DisplayYn = "Y";
                    resultItem.Emergency = grdResult.GetItemString(i, "emergency");
                    resultItem.Fkcpl2010 = grdResult.GetItemString(i, "fkcpl2010");
                    resultItem.Fkocs = grdResult.GetItemString(i, "fkocs");
                    //resultItem.GroupGubun = grdResult.GetItemString(i, "group_gubun"); // TODO
                    resultItem.GroupGubun = grdResult.GetItemString(i, "gubun");
                    resultItem.GroupHangmog = grdResult.GetItemString(i, "group_hangmog");
                    resultItem.Gumsaja = "";
                    resultItem.GumsaName = grdResult.GetItemString(i, "gumsa_name");
                    resultItem.HangmogCode = grdResult.GetItemString(i, "hangmog_code");
                    //resultItem.KeyValue = grdResult.GetItemString(i, "key_value"); // TODO
                    resultItem.KeyValue = ""; // TODO
                    resultItem.LabNo = ""; // TODO
                    resultItem.PanicYn = grdResult.GetItemString(i, "panic_yn");
                    resultItem.Pkcpl3020 = grdResult.GetItemString(i, "pkcpl3020");
                    resultItem.ResultDate = specimenRow[0]["UpdateTime"].ToString(); // *****
                    resultItem.ResultForm = grdResult.GetItemString(i, "result_form");
                    resultItem.SourceGumsa = grdResult.GetItemString(i, "source_gumsa");
                    resultItem.SpecimenCode = specimenRow[0]["Testcode"].ToString(); // *****
                    resultItem.SpecimenSer = specimenRow[0]["SID"].ToString(); // *****
                    resultItem.Standard = grdResult.GetItemString(i, "standard");
                    resultItem.StandardYn = grdResult.GetItemString(i, "standard_yn");
                    resultItem.DataRowState = "Modified";

                    if (!TypeCheck.IsNull(resultItem.Pkcpl3020))
                    {
                        lstResult.Add(resultItem);
                    }

                    #endregion

                    #region Get note items (Each specimen ser has only 1 noteItem)

                    if (tempSpecimenSer != specimenRow[0]["SID"].ToString())
                    {
                        noteItem = new CPL3020U00GrdNoteUpdateInfo();
                        noteItem.Code = "";
                        noteItem.DataRowState = DataRowState.Added.ToString();
                        noteItem.EtcComment = "";
                        noteItem.JundalGubun = "ETC";
                        noteItem.Note = "";
                        noteItem.SpecimenSer = specimenRow[0]["SID"].ToString();
                        noteItem.DataRowState = "Modified";

                        lstNote.Add(noteItem);
                    }

                    tempSpecimenSer = specimenRow[0]["SID"].ToString();

                    #endregion
                }
                catch (Exception ex)
                {
                    Service.WriteLog(ex.Message);
                    Service.WriteLog(ex.StackTrace);
                    continue;
                }
            }
        }

        /// <summary>
        /// Determines whether the cpl_result has value.
        /// </summary>
        /// <returns></returns>
        private bool IsCplResultExist()
        {
            for (int i = 0; i < grdResult.RowCount; i++)
            {
                if (!TypeCheck.IsNull(grdResult.GetItemString(i, "cpl_result")))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Open a connection to MSSQL
        /// </summary>
        private bool SqlConnect()
        {
            bool connected = true;

            string connectionString = string.Format("Data Source=\"{0}, {1}\";Initial Catalog={2};Persist Security Info=True;User ID={3};Password={4}",
                UserInfo.CplServer, UserInfo.CplPort, UserInfo.CplDatabase, UserInfo.CplUserId, UserInfo.CplPassword);
            this._connection = new SqlConnection(connectionString);

            try
            {
                this._connection.Open();
            }
            catch (Exception ex)
            {
                Service.WriteLog("MSSQL connection error. Message: " + ex.Message);
                Service.WriteLog("-at: " + ex.StackTrace);
                XMessageBox.Show(Resource.MSG_CONN_ERR, Resource.CAP_CONN_ERR, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Connection error
                connected = false;
            }
            finally { }

            return connected;
        }

        private void SqlDisconnect()
        {
            try
            {
                this._connection.Close();
            }
            finally { }
        }

        private void ColorizeResult()
        {
            //try
            //{
            //    // DataWindow when showing summary info
            //    this.dwNewResult2.Modify("cpl_result.Color='0~tIf((Number(cpl_result) > Number(to_standard)), 255, If((Number(cpl_result) < Number(from_standard)), 16711680, 0))'");
            //    this.dwNewResult1.Modify("cpl_result.Color='0~tIf((Number(cpl_result) > Number(to_standard)), 255, If((Number(cpl_result) < Number(from_standard)), 16711680, 0))'");

            //    // DataWindow when showing detail info
            //    // See: http://infocenter.sybase.com/help/index.jsp?topic=/com.sybase.dc00045_0250/html/ddref/DWFLen.htm for more detail
            //    this.dwResultList.Modify("cpl_result.Color='0~tIf((Number(cpl_result) > Number(Trim(Right(standard, Len(standard) - 2 - LastPos(standard, \" ~ \"))))), 255, If((Number(cpl_result) < Number(Trim(Left(standard, LastPos(standard, \" ~ \"))))), 16711680, 0))'");
            //}
            //catch (Exception ex)
            //{
            //    Service.WriteLog(ex.Message);
            //    Service.WriteLog(ex.StackTrace);
            //}
            //finally { }
        }

        #endregion

        private void grdResult_GridCellPainting(object sender, XGridCellPaintEventArgs e)
        {
            if (e.ColName != "cpl_result") return;

            float cplResult;
            float fromStandard;
            float toStandard;
            float.TryParse(grdResult.GetItemString(e.RowNumber, "cpl_result"), NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out cplResult);
            float.TryParse(grdResult.GetItemString(e.RowNumber, "from_standard"), NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out fromStandard);
            float.TryParse(grdResult.GetItemString(e.RowNumber, "to_standard"), NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out toStandard);

            if (!TypeCheck.IsNull(grdResult.GetItemString(e.RowNumber, "to_standard")) && cplResult > toStandard)
            {
                // Shows red color when result is higher than maximum value
                grdResult[e.RowNumber, e.ColName].ForeColor = XColor.ErrMsgForeColor;
            }
            else if (!TypeCheck.IsNull(grdResult.GetItemString(e.RowNumber, "from_standard")) && cplResult < fromStandard)
            {
                // Shows blue color when result is less than minimum value
                grdResult[e.RowNumber, e.ColName].ForeColor = XColor.InsertedForeColor;
            }
            else
            {
                // Default black color
                grdResult[e.RowNumber, e.ColName].ForeColor = XColor.NormalForeColor;
            }
        }

        private void ApplyMultiLanguageForDW()
        {
            //dwResultPrint.Modify(string.Format("t_11.Text = '{0}'", UserInfo.HospName));

            //dwResultPrint.Modify(string.Format("t_1.Text = '{0}'", Resource.DW_TXT_52));
            //dwResultPrint.Modify(string.Format("t_2.Text = '{0}'", Resource.DW_TXT_45));
            //dwResultPrint.Modify(string.Format("t_3.Text = '{0}'", Resource.DW_TXT_46));
            //dwResultPrint.Modify(string.Format("t_4.Text = '{0}'", Resource.DW_TXT_47));
            //dwResultPrint.Modify(string.Format("t_5.Text = '{0}'", Resource.DW_TXT_57));
            //dwResultPrint.Modify(string.Format("t_6.Text = '{0}'", Resource.DW_TXT_58));
            //dwResultPrint.Modify(string.Format("t_7.Text = '{0}'", Resource.DW_TXT_59));
            //dwResultPrint.Modify(string.Format("t_8.Text = '{0}'", Resource.DW_TXT_60));
            //dwResultPrint.Modify(string.Format("t_9.Text = '{0}'", Resource.DW_TXT_56));
            //dwResultPrint.Modify(string.Format("t_14.Text = '{0}'", Resource.DW_TXT_61));
            //dwResultPrint.Modify(string.Format("t_10.Text = '{0}'", Resource.DW_TXT_62));
            //dwResultPrint.Modify(string.Format("t_12.Text = '{0}'", Resource.DW_TXT_63));
            //dwResultPrint.Modify(string.Format("t_15.Text = '{0}'", Resource.DW_TXT_41));
            //dwResultPrint.Modify(string.Format("t_17.Text = '{0}'", Resource.DW_TXT_40));
            //dwResultPrint.Modify(string.Format("t_16.Text = '{0}'", Resource.DW_TXT_66));
            //dwResultPrint.Modify(string.Format("t_19.Text = '{0}'", Resource.DW_TXT_68));
        }
    }
}

