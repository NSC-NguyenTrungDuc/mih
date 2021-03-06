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
    public partial class OCS2005U00 : IHIS.Framework.XScreen
    {
        String mHospCode = EnvironInfo.HospCode;
        TreeNode preNode = null;
        private Hashtable htControl = new Hashtable();
        // '0': CP 기준정보
        // '1': CP 적용
        // '2': 일반지시사항
        // '3': 셋트지시사항
        string mDirectMode = "0";
        string mPlan_order_date = "";
        string mOrder_date = "";

        // CP Properties
        string mMembGubun    = "";
        string mMemb         = "";
        string mCp_code      = "";
        string mCp_path_code = "";
        string mJaewonil     = "";
        string mInputGubun   = "";
        string mFkocs6010    = "";
        string mInputGwa     = "";
        string mInputDoctor  = "";

        string mBunho = "";
        string mFkinp1001 = "";

        string mSelectInput  = "";

        private ArrayList range_from_list = new ArrayList();
        private ArrayList range_to_list = new ArrayList();
        private ArrayList suryang_list = new ArrayList();


        IHIS.OCS.OrderBiz mOrderBiz = new IHIS.OCS.OrderBiz();
        IHIS.OCS.OrderFunc mOrderFunc = new IHIS.OCS.OrderFunc();



        public OCS2005U00()
        {
            InitializeComponent();
        }

        #region [Screen Event]

        protected override void OnLoad(EventArgs e)
        {            
            base.OnLoad(e);
            PostCallHelper.PostCall(new PostMethod(PostLoad));

        }

        private void PostLoad()
        {
            this.CurrMQLayout = this.grdDirectData;
            this.CurrMSLayout = this.grdDirectData;

            //Control setting
            SetControl(this.pnlDirect);
            SetControl(this.pnlDirectText);
            SetControl(this.pnlDetail_2);
            SetControl(this.pnlDetail_3);

            SetControl(this.pnlSiksa);
            SetControl(this.pnlDetail_3_sub);
            
            //SetControl(this.pnlFromToCP);
            InitialDesign();

            // 콤보생성
            CreateCombo();

            //Control Data reset
            this.grdDirectData.Reset();
            ClearControlAll();
            LockControl(false);

            this.OCS2005U00_UserChanged(this, new System.EventArgs());

        }

        private void OCS2005U00_UserChanged(object sender, EventArgs e)
        {
            LoadDirectInfo();
        }

        private void OCS2005U00_ScreenOpen(object sender, XScreenOpenEventArgs e)
        {
            grdDirectData.Reset();

            if (this.OpenParam != null)
            {
                try
                {
                    if (OpenParam.Contains("bunho"))
                        mBunho = OpenParam["bunho"].ToString();
                    if (OpenParam.Contains("fkinp1001"))
                        mFkinp1001 = OpenParam["fkinp1001"].ToString();

                    if (OpenParam.Contains("direct_mode"))
                        mDirectMode = OpenParam["direct_mode"].ToString();
                    if (OpenParam.Contains("memb_gubun"))
                        mMembGubun = OpenParam["memb_gubun"].ToString();
                    if (OpenParam.Contains("memb"))
                        mMemb = OpenParam["memb"].ToString();
                    if (OpenParam.Contains("input_gubun"))
                        mInputGubun = OpenParam["input_gubun"].ToString();
                    if (OpenParam.Contains("fkocs6010"))
                        mFkocs6010 = OpenParam["fkocs6010"].ToString();
                    if (OpenParam.Contains("input_gwa"))
                        mInputGwa = OpenParam["input_gwa"].ToString();
                    if (OpenParam.Contains("input_doctor"))
                        mInputDoctor = OpenParam["input_doctor"].ToString();

                    if (OpenParam.Contains("cp_code"))
                        mCp_code = OpenParam["cp_code"].ToString();
                    if (OpenParam.Contains("cp_path_code"))
                        mCp_path_code = OpenParam["cp_path_code"].ToString();
                    if (OpenParam.Contains("jaewonil"))
                        mJaewonil = OpenParam["jaewonil"].ToString();
                    if (OpenParam.Contains("input_gubun"))
                        mInputGubun = OpenParam["input_gubun"].ToString();
                    if (OpenParam.Contains("fkocs6010"))
                        mFkocs6010 = OpenParam["fkocs6010"].ToString();
                    if (OpenParam.Contains("input_gwa"))
                        mInputGwa = OpenParam["input_gwa"].ToString();
                    if (OpenParam.Contains("input_doctor"))
                        mInputDoctor = OpenParam["input_doctor"].ToString();

                    if (OpenParam.Contains("plan_order_date"))
                        mPlan_order_date = OpenParam["plan_order_date"].ToString();
                    else
                        mPlan_order_date = EnvironInfo.GetSysDate().ToString("yyyy/MM/dd");

                    if (OpenParam.Contains("order_date"))
                        mOrder_date = OpenParam["order_date"].ToString();
                    else
                        mOrder_date = DateTime.Now.ToString("yyyy/MM/dd");

                    if (OpenParam.Contains("select_input_gubun"))
                        mSelectInput = OpenParam["select_input_gubun"].ToString();
                    else
                        mSelectInput = "new";

                    //Data
                    if (OpenParam.Contains("DIRECT"))
                    {
                        int insertRow = -1;

                        foreach (DataRow row in ((MultiLayout)OpenParam["DIRECT"]).LayoutTable.Rows)
                        {
                            insertRow = grdOriginDirectData.InsertRow(-1);

                            foreach (XEditGridCell cell in grdOriginDirectData.CellInfos)
                            {
                                if (((MultiLayout)OpenParam["DIRECT"]).LayoutItems.Contains(cell.CellName))
                                {
                                    grdOriginDirectData.SetItemValue(insertRow, cell.CellName, row[cell.CellName]);
                                }
                            }
                        }

                        grdOriginDirectData.AcceptData();
                        grdOriginDirectData.ResetUpdate();

                    }

                    if (OpenParam.Contains("DIRECT_DETAIL"))
                    {
                        int insertRow = -1;
                        foreach (DataRow row in ((MultiLayout)OpenParam["DIRECT_DETAIL"]).LayoutTable.Rows)
                        {
                            insertRow = grdOriginDirectDetail.InsertRow(-1);

                            foreach (XEditGridCell cell in grdOriginDirectDetail.CellInfos)
                            {
                                if (((MultiLayout)OpenParam["DIRECT_DETAIL"]).LayoutItems.Contains(cell.CellName))
                                    grdOriginDirectDetail.SetItemValue(insertRow, cell.CellName, row[cell.CellName]);
                            }
                        }

                        grdOriginDirectDetail.AcceptData();
                        grdOriginDirectDetail.ResetUpdate();
                    }
                }
                catch (Exception ex)
                {
                    XMessageBox.Show(ex.Message, "");
                }
            }	
        }

        /// <summary>
        /// 1.Hashtable에 각 DataControl를 Load시켜서 해당 Control의 제어를 용이하게 한다.
        /// </summary>
        private void SetControl(XPanel pnl)
        {
            string colName = "";

            foreach (object obj in pnl.Controls)
            {
                try
                {
                    if (obj.GetType().Name.ToString().IndexOf("XComboBox") >= 0)
                    {
                        colName = ((XComboBox)obj).Name.Substring(3).ToLower();
                        htControl.Add(colName, obj);
                    }
                    else if (obj.GetType().Name.ToString().IndexOf("XTextBox") >= 0)
                    {
                        colName = ((XTextBox)obj).Name.Substring(3).ToLower();
                        htControl.Add(colName, obj);
                    }
                    else if (obj.GetType().Name.ToString().IndexOf("XEditMask") >= 0)
                    {
                        colName = ((XEditMask)obj).Name.Substring(3).ToLower();

                        //if (colName == "emkSurayng1")
                            //XMessageBox.Show(colName);

                        htControl.Add(colName, obj);
                    }
                    else if (obj.GetType().ToString().IndexOf("XCheckBox") >= 0)
                    {
                        colName = ((XCheckBox)obj).Name.Substring(3).ToLower();
                        htControl.Add(colName, obj);
                    }
                    else if (obj.GetType().ToString().IndexOf("XDisplayBox") >= 0)
                    {
                        colName = ((XDisplayBox)obj).Name.Substring(3).ToLower();
                        htControl.Add(colName, obj);
                    }
                    else if (obj.GetType().ToString().IndexOf("XFindBox") >= 0)
                    {
                        colName = ((XFindBox)obj).Name.Substring(3).ToLower();
                        htControl.Add(colName, obj);
                    }
                    else if (obj.GetType().ToString().IndexOf("XDatePicker") >= 0)
                    {
                        colName = ((XDatePicker)obj).Name.Substring(3).ToLower();
                        htControl.Add(colName, obj);
                    }
                }
                catch (Exception ex)
                {
                    XMessageBox.Show(ex.Message);
                }
            }
        }

        #endregion

        #region [TreeView Info]

        private void CreateTreeVIewDirect_gubun()
        {
            preNode = null;
            tvwDirect_gubun.Nodes.Clear();
            if (this.dloNUR0110.RowCount < 1) return;

            TreeNode node;
            string direct_gubun = "";

            foreach (DataRow row in dloNUR0110.LayoutTable.Rows)
            {
                node = new TreeNode(row["nur_gr_name"].ToString());
                direct_gubun = row["nur_gr_code"].ToString();
                node.Tag = direct_gubun;

                if (this.grdOriginDirectData.LayoutTable.Select(" direct_gubun = '" + direct_gubun + "' ", "").Length > 0)
                {
                    node.SelectedImageIndex = 1;
                    node.ImageIndex = 1;
                }
                else
                {
                    node.SelectedImageIndex = 0;
                    node.ImageIndex = 0;
                }

                tvwDirect_gubun.Nodes.Add(node);
            }

            tvwDirect_gubun.ExpandAll();
            if (tvwDirect_gubun.Nodes.Count > 0) tvwDirect_gubun.SelectedNode = tvwDirect_gubun.Nodes[0];
        }

        private void tvwDirect_gubun_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (preNode != null && preNode.ImageIndex == 1)
            {
                string direct_gubun = preNode.Tag.ToString().Split('|')[0];
                string direct_code = preNode.Tag.ToString().Split('|')[1];

                ApplyDirectData(direct_gubun, direct_code);
            }

            ClearControlAll();
            LockControl(false);

            CreateTreeVIewDirect_code(e.Node.Tag.ToString());
        }

        private void direct_gubun_exists()
        {
            if (tvwDirect_gubun.SelectedNode == null) return;

            string direct_gubun = tvwDirect_gubun.SelectedNode.Tag.ToString();
            string currentDirect_code = tvwDirectInfo.SelectedNode.Tag.ToString().Split('|')[1];

            if (this.grdOriginDirectData.LayoutTable.Select(" direct_gubun = '" + direct_gubun + "' and direct_code <> '" + currentDirect_code + "' ", "").Length > 0 ||
               this.grdDirectData.RowCount > 0)
            {
                tvwDirect_gubun.SelectedNode.SelectedImageIndex = 1;
                tvwDirect_gubun.SelectedNode.ImageIndex = 1;
            }
            else
            {
                tvwDirect_gubun.SelectedNode.SelectedImageIndex = 0;
                tvwDirect_gubun.SelectedNode.ImageIndex = 0;
            }
        }

        #endregion

        #region InitialDesign()
        /// <summary>
        /// Load시 별도 Design할 부분이 있는 경우 여기서 Coding처리
        /// </summary>
        private void InitialDesign()
        {
            /// DirectMode
            /// '0':CP
            if (mDirectMode == "0" && !TypeCheck.IsNull(mJaewonil))
            {
                pnlFromToCP.Visible    = true;

                dbxJaewonil.SetEditValue(mJaewonil);
            }
            else
            {
                pnlFromToBasic.Visible = true;
                pnlFromToCP.Visible    = false;
            }
        }
        #endregion

        #region [Scroll]

        private void vsbNumber_Scroll(object sender, System.Windows.Forms.ScrollEventArgs e)
        {
            VScrollBar vsb = sender as VScrollBar;

            string colName = vsb.Name.Substring(3).ToLower();

            double incrementValue = 1;
            double maxIncrement = 999;
            double controlValue = 0;

            switch (colName)
            {
                case "cnt_perhour":
                    incrementValue = 1;
                    maxIncrement = 60;

                    break;
                case "cnt_perday":

                    incrementValue = 1;
                    maxIncrement = 5;
                    break;

                case "french":
                    incrementValue = 0.5;
                    maxIncrement = 10.0;
                    break;
            }

            switch (e.Type)
            {
                case System.Windows.Forms.ScrollEventType.LargeIncrement:
                case System.Windows.Forms.ScrollEventType.SmallIncrement:

                    controlValue = double.Parse(((IDataControl)htControl[colName]).DataValue.ToString() == "" ? "0" : ((IDataControl)htControl[colName]).DataValue.ToString());
                    controlValue = controlValue - incrementValue;

                    if (controlValue < 0) controlValue = 0;

                    ((IDataControl)htControl[colName]).DataValue = controlValue;

                    break;
                case System.Windows.Forms.ScrollEventType.LargeDecrement:
                case System.Windows.Forms.ScrollEventType.SmallDecrement:

                    controlValue = double.Parse(((IDataControl)htControl[colName]).DataValue.ToString() == "" ? "0" : ((IDataControl)htControl[colName]).DataValue.ToString());
                    controlValue = controlValue + incrementValue;

                    if (controlValue > maxIncrement) controlValue = 0;

                    ((IDataControl)htControl[colName]).DataValue = controlValue;

                    break;
            }

            if (pnlDetail_2.Visible) this.Detail_2_Create_text();
            if (pnlDetail_3.Visible) this.Detail_3_Create_text();
        }

        private void vsbTime_Scroll(object sender, System.Windows.Forms.ScrollEventArgs e)
        {
            VScrollBar vsb = sender as VScrollBar;
            string colName = vsb.Name.Substring(3).ToLower();

            XEditMask editor = (XEditMask)htControl[colName];
            bool selectHour = true;
            int selectStart = editor.SelectionStart;

            if (selectStart > 2)
                selectHour = false;

            int hours = 0;
            int min = 0;

            if (TypeCheck.IsInt(editor.GetDataValue().ToString().PadRight(4).Substring(0, 2)))
                hours = int.Parse(editor.GetDataValue().ToString().PadRight(4).Substring(0, 2));

            if (TypeCheck.IsInt(editor.GetDataValue().ToString().PadRight(4).Substring(2)))
                min = int.Parse(editor.GetDataValue().ToString().PadRight(4).Substring(2));

            switch (e.Type)
            {
                case System.Windows.Forms.ScrollEventType.LargeIncrement:
                case System.Windows.Forms.ScrollEventType.SmallIncrement:

                    if (selectHour)
                    {
                        hours = hours - 1;
                        if (hours < 0)
                            hours = 23;
                    }
                    else
                    {
                        min = min - 1;
                        if (min < 0)
                        {
                            min = 59;
                            hours = hours - 1;
                            if (hours < 0)
                                hours = 23;
                        }
                    }

                    break;
                case System.Windows.Forms.ScrollEventType.LargeDecrement:
                case System.Windows.Forms.ScrollEventType.SmallDecrement:

                    if (selectHour)
                    {
                        hours = hours + 1;
                        if (hours >= 24)
                            hours = 0;
                    }
                    else
                    {
                        min = min + 1;
                        if (min >= 60)
                        {
                            min = 0;
                            hours = hours + 1;
                            if (hours >= 24)
                                hours = 0;
                        }
                    }

                    break;
            }

            editor.SetDataValue(hours.ToString("00") + min.ToString("00"));
            editor.SelectionStart = selectStart;
        }

        #endregion

        #region [Fucntion]

        private void CreateCombo(string grCode, string mdCode)
        {
            layoutCombo.SetBindVarValue("f_nur_gr_code", grCode);
            layoutCombo.SetBindVarValue("f_nur_md_code", mdCode);
            layoutCombo.SetBindVarValue("f_hosp_code", mHospCode);
            layoutCombo.QueryLayout(false);

            if (layoutCombo.LayoutTable != null)
            {
                cboHangmog_code1.SetComboItems(layoutCombo.LayoutTable, "hangmog_name", "hangmog_code", XComboSetType.AppendNone);
                cboHangmog_code1.SelectedIndex = 0;

                cboHangmog_code2.SetComboItems(layoutCombo.LayoutTable, "hangmog_name", "hangmog_code", XComboSetType.AppendNone);
                cboHangmog_code2.SelectedIndex = 0;

                cboHangmog_code3.SetComboItems(layoutCombo.LayoutTable, "hangmog_name", "hangmog_code", XComboSetType.AppendNone);
                cboHangmog_code3.SelectedIndex = 0;

                cboHangmog_code4.SetComboItems(layoutCombo.LayoutTable, "hangmog_name", "hangmog_code", XComboSetType.AppendNone);
                cboHangmog_code4.SelectedIndex = 0;

                cboHangmog_code.SetComboItems(layoutCombo.LayoutTable, "hangmog_name", "hangmog_code", XComboSetType.AppendNone);
                cboHangmog_code.SelectedIndex = 0;
            }
        }

        private void CreateCombo()
        {
            MultiLayout layCombo = new MultiLayout();

            layCombo.LayoutItems.Add("code", DataType.String);
            layCombo.LayoutItems.Add("code_name", DataType.String);

            layCombo.InitializeLayoutTable();

            // dv time 콤보박스 셋팅
            layCombo.Reset();
            layCombo.QuerySQL = @"SELECT CODE, CODE_NAME
  FROM OCS0132
 WHERE CODE_TYPE = 'DV_TIME'
   AND HOSP_CODE = FN_ADM_LOAD_HOSP_CODE
 ORDER BY CODE";

            if (layCombo.QueryLayout(true))
            {
                grdNUR0115.SetComboItems("dv_time", layCombo.LayoutTable, "code_name", "code");
            }

            // 주사속도 구분 콤보박스 셋팅
            layCombo.Reset();
            layCombo.QuerySQL = @"SELECT CODE, CODE_NAME
  FROM OCS0132
 WHERE CODE_TYPE = 'JUSA_SPD_GUBUN'
   AND HOSP_CODE = FN_ADM_LOAD_HOSP_CODE
 ORDER BY CODE";

            if (layCombo.QueryLayout(true))
            {
                grdNUR0115.SetComboItems("jusa_spd_gubun", layCombo.LayoutTable, "code_name", "code");
            }
        }

        private void LoadDirectInfo()
        {
            this.dloDirectInfo.QueryLayout(false);

            if (this.dloDirectInfo.RowCount < 1) return;

            string nur_gr_code = "";
            int insertRow = -1;

            foreach (DataRow row in dloDirectInfo.LayoutTable.Rows)
            {
                if (nur_gr_code != row["nur_gr_code"].ToString())
                {
                    insertRow = dloNUR0110.InsertRow(-1);
                    dloNUR0110.SetItemValue(insertRow, "nur_gr_code", row["nur_gr_code"]);
                    dloNUR0110.SetItemValue(insertRow, "nur_gr_name", row["nur_gr_name"]);
                    nur_gr_code = row["nur_gr_code"].ToString();
                }
            }

            dloNUR0110.ResetUpdate();

            CreateTreeVIewDirect_gubun();
        }

        private void LoadDirect_cont(string aNur_gr_code, string aNur_md_code)
        {
            grdNUR0112.SetBindVarValue("f_hosp_code", mHospCode);
            grdNUR0112.SetBindVarValue("f_nur_gr_code", aNur_gr_code);
            grdNUR0112.SetBindVarValue("f_nur_md_code", aNur_md_code);
            grdNUR0112.QueryLayout(false);

            grdNUR0114.SetBindVarValue("f_hosp_code", mHospCode);
            grdNUR0114.SetBindVarValue("f_nur_gr_code", aNur_gr_code);
            grdNUR0114.SetBindVarValue("f_nur_md_code", aNur_md_code);
            grdNUR0114.QueryLayout(false);

            CreateCombo(aNur_gr_code, aNur_md_code);
        }

        private void LockControl(bool aLock)
        {
            pnlDirect.Enabled = aLock;
            pnlDirectText.Enabled = aLock;
            pnlDetail_2.Enabled = aLock;
            pnlDetail_3.Enabled = aLock;
            pnlFromTo.Enabled = aLock;

            if (aLock && this.tvwDirectInfo.SelectedNode != null)
                LockItem();
        }

        private void LockItem()
        {
            string direct_gubun = tvwDirectInfo.SelectedNode.Tag.ToString().Split('|')[0];
            string direct_code = tvwDirectInfo.SelectedNode.Tag.ToString().Split('|')[1];

            string cnt_perhour_yn = "";
            string cnt_perday_yn = "";
            string act_day_yn = "";
            string french_yn = "";
            string act_dq1_yn = "";
            string act_dq2_yn = "";
            string act_dq3_yn = "";
            string act_dq4_yn = "";
            string act_time_yn = "";
            string direct_cont_yn = "";
            string continue_yn = "";

            string filter = " nur_gr_code = '" + direct_gubun + "' and " + " nur_md_code = '" + direct_code + "' ";
            foreach (DataRow row in dloDirectInfo.LayoutTable.Select(filter, ""))
            {
                cnt_perhour_yn = row["cnt_perhour_yn"].ToString();
                cnt_perday_yn = row["cnt_perday_yn"].ToString();
                act_day_yn = row["act_day_yn"].ToString();
                french_yn = row["french_yn"].ToString();
                act_dq1_yn = row["act_dq1_yn"].ToString();
                act_dq2_yn = row["act_dq2_yn"].ToString();
                act_dq3_yn = row["act_dq3_yn"].ToString();
                act_dq4_yn = row["act_dq4_yn"].ToString();
                act_time_yn = row["act_time_yn"].ToString();
                direct_cont_yn = row["direct_cont_yn"].ToString();
                continue_yn = row["jisi_continue_yn"].ToString();
            }

            if (cnt_perhour_yn == "Y")
            {
                emkCnt_perhour.Enabled = true;
                btnCnt_perhour.Enabled = true;
                vsbCnt_perhour.Enabled = true;
            }
            else
            {
                emkCnt_perhour.Enabled = false;
                btnCnt_perhour.Enabled = false;
                vsbCnt_perhour.Enabled = false;
            }

            if (cnt_perday_yn == "Y")
            {
                emkCnt_perday.Enabled = true;
                btnCnt_perday.Enabled = true;
                vsbCnt_perday.Enabled = true;
            }
            else
            {
                emkCnt_perday.Enabled = false;
                btnCnt_perday.Enabled = false;
                vsbCnt_perday.Enabled = false;
            }


            if (french_yn == "Y")
            {
                emkFrench.Enabled = true;
                btnFrench.Enabled = true;
                vsbFrench.Enabled = true;
            }
            else
            {
                emkFrench.Enabled = false;
                btnFrench.Enabled = false;
                vsbFrench.Enabled = false;
            }

            if (act_time_yn == "Y")
            {
                emkAct_time.Enabled = true;
                btnAct_time.Enabled = true;
                vsbAct_time.Enabled = true;
            }
            else
            {
                emkAct_time.Enabled = false;
                btnAct_time.Enabled = false;
                vsbAct_time.Enabled = false;
            }

            btnAct_dq.Enabled = false;

            if (act_dq1_yn == "Y")
            {
                chkAct_dq1.Enabled = true;
                btnAct_dq.Enabled = true;
            }
            else
                chkAct_dq1.Enabled = false;

            if (act_dq2_yn == "Y")
            {
                chkAct_dq2.Enabled = true;
                btnAct_dq.Enabled = true;
            }
            else
                chkAct_dq2.Enabled = false;

            if (act_dq3_yn == "Y")
            {
                chkAct_dq3.Enabled = true;
                btnAct_dq.Enabled = true;
            }
            else
                chkAct_dq3.Enabled = false;

            if (act_dq4_yn == "Y")
            {
                chkAct_dq4.Enabled = true;
                btnAct_dq.Enabled = true;
            }
            else
                chkAct_dq4.Enabled = false;

            if (direct_cont_yn == "Y")
                txtDirect_text.ReadOnly = true;
            else
                txtDirect_text.ReadOnly = false;
        }

        private void ClearControlAll()
        {
            ClearControl(this.pnlDirect);
            ClearControl(this.pnlDetail_2);
            ClearControl(this.pnlDetail_3);
            ClearControl(this.pnlDirectText);

            grdNUR0112.Reset();
            grdNUR0114.Reset();

            ClearControl(this.pnlSiksa);
        }

        private void ClearControl(XPanel pnl)
        {
            foreach (object obj in pnl.Controls)
            {
                try
                {
                    if (obj.GetType().ToString().IndexOf("XComboBox") >= 0)
                    {
                        if (((XComboBox)obj).DataSource != null)
                            ((XComboBox)obj).SelectedIndex = 0;
                    }
                    else if (obj.GetType().ToString().IndexOf("XDisplayBox") >= 0)
                        ((XDisplayBox)obj).SetDataValue("");
                    else if (obj.GetType().Name.ToString().IndexOf("XTextBox") >= 0)
                        ((XTextBox)obj).SetDataValue("");
                    else if (obj.GetType().Name.ToString().IndexOf("XEditMask") >= 0)
                    {
                        if (((XEditMask)obj).EditMaskType == MaskType.Number || ((XEditMask)obj).EditMaskType == MaskType.Decimal)
                            ((XEditMask)obj).SetDataValue(0);
                        else if (((XEditMask)obj).Mask == "##:##")
                            ((XEditMask)obj).SetDataValue("0000");
                        else ((XEditMask)obj).SetDataValue("");

                    }
                    else if (obj.GetType().ToString().IndexOf("XCheckBox") >= 0)
                        ((XCheckBox)obj).Checked = false;
                    else if (obj.GetType().ToString().IndexOf("XRadioButton") >= 0)
                        ((XRadioButton)obj).Checked = false;
                    else if (obj.GetType().ToString().IndexOf("XDatePicker") >= 0)
                        ((XDatePicker)obj).SetDataValue("");
                    else if (obj.GetType().ToString().IndexOf("XEditGrid") >= 0)
                    {
                        ((XEditGrid)obj).Reset();
                    }

                }
                catch (Exception ex)
                {
                    XMessageBox.Show(ex.Message);
                }
            }
        }

        private void LoadData(int rowIndex, string masterOrDetailFlag)
        {
            if (rowIndex == -1) return;

            if (masterOrDetailFlag.Equals("M"))
            {
                foreach (XEditGridCell cell in grdDirectData.CellInfos)
                {
                    if (htControl.Contains(cell.CellName))
                        ((IDataControl)htControl[cell.CellName]).DataValue = grdDirectData.GetItemValue(rowIndex, cell.CellName);
                }

                string plan_from_date = grdDirectData.GetItemString(rowIndex, "drt_from_date");
                string direct_gubun   = grdDirectData.GetItemString(rowIndex, "direct_gubun");
                string direct_code    = grdDirectData.GetItemString(rowIndex, "direct_code");

                // 인슐린 스케일 입력처리
                if (pnlDetail_2.Visible == true)
                {
                    this.grdDetail_2.Reset();

                    foreach (DataRow row in this.grdOriginDirectDetail.LayoutTable.Select(" direct_gubun = '" + direct_gubun + "' and direct_code = '" + direct_code + "' ", " seq ASC"))
                    {
                        grdDetail_2.LayoutTable.ImportRow(row);

                        this.btnB.ImageIndex = int.Parse(TypeCheck.NVL(row["time_gubun"].ToString(), "0000").ToString().Substring(0, 1));
                        this.btnL.ImageIndex = int.Parse(TypeCheck.NVL(row["time_gubun"].ToString(), "0000").ToString().Substring(1, 1));
                        this.btnD.ImageIndex = int.Parse(TypeCheck.NVL(row["time_gubun"].ToString(), "0000").ToString().Substring(2, 1));
                        this.btnS.ImageIndex = int.Parse(TypeCheck.NVL(row["time_gubun"].ToString(), "0000").ToString().Substring(3, 1));
                    }

                    grdDetail_2.DisplayData();
                    grdDetail_2.ResetUpdate();
                }

                string jisi_order_gubun = "";

                foreach (DataRow row in dloDirectInfo.LayoutTable.Rows)
                {
                    if (row["nur_gr_code"].ToString() == direct_gubun && row["nur_md_code"].ToString() == direct_code)
                    {
                        jisi_order_gubun = row["jisi_order_gubun"].ToString();
                        break;
                    }
                }

                switch (jisi_order_gubun)
                {
                    case "0": // 일반
                        break;
                    case "1": // 인슐린 스케쥴
                        txtDirect_text.SetEditValue(grdDirectData.GetItemValue(rowIndex, "direct_text"));
                        break;
                    case "2": // 인슐린
                        txtDirect_text.SetEditValue(grdDirectData.GetItemValue(rowIndex, "direct_text"));
                        break;
                    case "3": // 산소
                    case "4": // 인공호흡기
                    case "5": // 약재
                        break;
                    case "6": // 입원당일 식사오더
                        break;
                    case "7": // 재원중 식사오더
                        break;
                }
            }
            else
            {
                foreach (XEditGridCell cell in grdDirectDetail.CellInfos)
                {
                    if (htControl.Contains(cell.CellName))
                        ((IDataControl)htControl[cell.CellName]).DataValue = grdDirectDetail.GetItemValue(rowIndex, cell.CellName);

                    //HashTable dup
                    if (cell.CellName == "hangmog_code")
                    {
                        if (pnlDetail_2.Visible)
                            cboHangmog_code.SetDataValue(grdDirectDetail.GetItemValue(rowIndex, cell.CellName));
                        else if (pnlDetail_3.Visible)
                        {
                            string timeGubun = grdDirectDetail.GetItemValue(rowIndex, "time_gubun").ToString();

                            switch (timeGubun)
                            {
                                case "0": // 아침
                                    emkSurayng1.SetDataValue(grdDirectDetail.GetItemValue(rowIndex, "suryang").ToString());
                                    cboHangmog_code1.SetDataValue(grdDirectDetail.GetItemValue(rowIndex, "hangmog_code").ToString());
                                    break;
                                case "1": // 점심
                                    emkSurayng2.SetDataValue(grdDirectDetail.GetItemValue(rowIndex, "suryang").ToString());
                                    cboHangmog_code2.SetDataValue(grdDirectDetail.GetItemValue(rowIndex, "hangmog_code").ToString());
                                    break;
                                case "2": // 저녁
                                    emkSurayng3.SetDataValue(grdDirectDetail.GetItemValue(rowIndex, "suryang").ToString());
                                    cboHangmog_code3.SetDataValue(grdDirectDetail.GetItemValue(rowIndex, "hangmog_code").ToString());
                                    break;
                                case "3": // 취침전
                                    emkSurayng4.SetDataValue(grdDirectDetail.GetItemValue(rowIndex, "suryang").ToString());
                                    cboHangmog_code4.SetDataValue(grdDirectDetail.GetItemValue(rowIndex, "hangmog_code").ToString());
                                    break;
                            }
                        }
                    }
                }
            }
        }

        private void ApplyData(int rowIndex)
        {
            if (rowIndex == -1) return;

            foreach (object obj in htControl.Keys)
            {
                //HashTable dup
                if (pnlDetail_2.Visible && obj.ToString() == "hangmog_code_1") continue;

                //HashTable dup
                if (pnlDetail_2.Visible && obj.ToString() == "hangmog_code")
                    grdDirectDetail.SetItemValue(rowIndex, "hangmog_code", ((IDataControl)htControl[obj.ToString()]).DataValue);

                if (grdDirectData.CellInfos.Contains(obj.ToString()))
                {
                    if ((((XGridCell)grdDirectData.CellInfos[obj.ToString()]).CellType == IHIS.Framework.XCellDataType.Number ||
                        ((XGridCell)grdDirectData.CellInfos[obj.ToString()]).CellType == IHIS.Framework.XCellDataType.Decimal) &&
                        TypeCheck.IsNull(((IDataControl)htControl[obj.ToString()]).DataValue.ToString()))
                        grdDirectData.SetItemValue(rowIndex, obj.ToString(), 0);
                    else
                        grdDirectData.SetItemValue(rowIndex, obj.ToString(), ((IDataControl)htControl[obj.ToString()]).DataValue);
                }
            }

            string plan_from_date = grdDirectData.GetItemString(rowIndex, "drt_from_date");
            string direct_gubun = grdDirectData.GetItemString(rowIndex, "direct_gubun");
            string direct_code = grdDirectData.GetItemString(rowIndex, "direct_code");
            string seq = "0";

            if (grdDetail_2.DeletedRowTable != null)
            {
                for (int i = 0; i < grdDetail_2.DeletedRowTable.Rows.Count; i++)
                {
                    seq = grdDetail_2.DeletedRowTable.Rows[i]["seq"].ToString();

                    for (int j = 0; j < this.grdDirectDetail.LayoutTable.Rows.Count; j++)
                    {
                        if (plan_from_date.Substring(0, 10) == grdDirectDetail.LayoutTable.Rows[j]["order_date"].ToString() &&
                            direct_gubun == grdDirectDetail.LayoutTable.Rows[j]["direct_gubun"].ToString() &&
                            direct_code == grdDirectDetail.LayoutTable.Rows[j]["direct_code"].ToString() &&
                            seq == grdDirectDetail.LayoutTable.Rows[j]["seq"].ToString())
                        {
                            grdDirectDetail.DeleteRow(j);
                            j--;
                        }
                    }
                }
            }

            if (pnlDetail_2.Visible)
            {
                for (int i = 0; i < grdDirectDetail.RowCount; i++)
                {
                    if (plan_from_date == grdDirectDetail.LayoutTable.Rows[i]["order_date"].ToString() &&
                        direct_gubun == grdDirectDetail.LayoutTable.Rows[i]["direct_gubun"].ToString() &&
                        direct_code == grdDirectDetail.LayoutTable.Rows[i]["direct_code"].ToString())
                    {
                        grdDirectDetail.LayoutTable.Rows.Remove(grdDirectDetail.LayoutTable.Rows[i]);
                        i--;
                    }
                }

                for (int i = 0; i < grdDetail_2.RowCount; i++)
                {
                    bool valid = true;

                    foreach (DataRow row in grdDirectDetail.LayoutTable.Rows)
                    {
                        if (grdDetail_2.GetItemString(i, "insulin_from") == row["insulin_from"].ToString() &&
                            grdDetail_2.GetItemString(i, "insulin_to") == row["insulin_to"].ToString() &&
                            grdDetail_2.GetItemString(i, "suryang") == row["suryang"].ToString())
                        {
                            valid = false;
                        }
                    }

                    if (valid)
                    {
                        grdDetail_2.LayoutTable.Rows[i]["seq"] = i + 1;
                        grdDirectDetail.LayoutTable.ImportRow(grdDetail_2.LayoutTable.Rows[i]);


                        grdDirectDetail.SetItemValue(i, "bunho",        grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "bunho"));
                        grdDirectDetail.SetItemValue(i, "fkinp1001",    grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "fkinp1001"));
                        grdDirectDetail.SetItemValue(i, "order_date",   grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "order_date"));
                        grdDirectDetail.SetItemValue(i, "input_gubun",  grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "input_gubun"));

                        grdDirectDetail.SetItemValue(i, "fkocs2005",    grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "pkocs2005"));
                        grdDirectDetail.SetItemValue(i, "fkocs6005",    grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "pkocs6005"));
                        grdDirectDetail.SetItemValue(i, "fkocs6015",    grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "pkocs6015"));
                        grdDirectDetail.SetItemValue(i, "fkocs6010",    grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "fkocs6010"));

                        // CP Insert
                        grdDirectDetail.SetItemValue(i, "memb",         mMemb);
                        grdDirectDetail.SetItemValue(i, "memb_gubun",   mMembGubun);
                        grdDirectDetail.SetItemValue(i, "cp_code",      mCp_code);
                        grdDirectDetail.SetItemValue(i, "cp_path_code", mCp_path_code);
                        grdDirectDetail.SetItemValue(i, "jaewonil",     mJaewonil);
                    }
                }
            }

            grdDirectDetail.DisplayData();
        }

        private string GetPKOCS(string pkGubun)
        {
            string cmdText = "";
            switch (pkGubun)
            {
                case "2005":
                    cmdText = "SELECT OCS2005_SEQ.NEXTVAL FROM DUAL";
                    break;
                case "6005":
                    cmdText = "SELECT OCS6005_SEQ.NEXTVAL FROM DUAL";
                    break;
                case "6015":
                    cmdText = "SELECT OCS6015_SEQ.NEXTVAL FROM DUAL";
                    break;
            }

            return Service.ExecuteScalar(cmdText).ToString();
        }

        #region Insert and Delete Direct [ Data ]
        private void InsertDirectData(TreeNode node)
        {
            this.AcceptData();

            this.grdNUR0115.Enabled = true;
            this.grdNUR0115_2.Enabled = true;

            string direct_gubun = node.Tag.ToString().Split('|')[0];
            string direct_gubun_name = tvwDirect_gubun.SelectedNode.Text;
            string direct_code = node.Tag.ToString().Split('|')[1];
            string direct_code_name = node.Text;

            if (mDirectMode == "0") // CP
            {
                LockControl(true);

                int insertRow = -1;

                if (direct_gubun == "02")
                {
                    for (int i = 0; i < grdOriginDirectData.RowCount; i++)
                    {
                        string orginCode = grdOriginDirectData.GetItemString(i, "direct_code").Substring(3, 1);
                        if (direct_code.Substring(3, 1) == orginCode && grdOriginDirectData.GetItemString(i, "direct_gubun") == "02")
                        {
                            string msg = string.Empty;
                            if(direct_code.Substring(3, 1) == "1") msg = "朝食指示";
                            else if(direct_code.Substring(3, 1) == "2") msg = "昼食指示";
                            else if(direct_code.Substring(3, 1) == "3") msg = "夕食指示";

                            XMessageBox.Show("既に [" + msg + "] 指示が入力されています。\n\r 先ず、入力された [" + msg + "] 指示の削除をしてから再入力してください。", "注意",
                                MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }

                insertRow = grdDirectData.InsertRow(-1);

                string plan_order_date = LoadPlanFromDate(insertRow);

                grdDirectData.SetItemValue(insertRow, "direct_gubun",      direct_gubun);
                grdDirectData.SetItemValue(insertRow, "direct_gubun_name", direct_gubun_name);
                grdDirectData.SetItemValue(insertRow, "direct_code",       direct_code);
                grdDirectData.SetItemValue(insertRow, "direct_code_name",  direct_code_name);

                grdDirectData.SetItemValue(insertRow, "pk_seq",       LoadDetailKey("pk"));
                grdDirectData.SetItemValue(insertRow, "continue_yn",  "Y");

                grdDirectData.SetItemValue(insertRow, "memb_gubun",   mMembGubun);
                grdDirectData.SetItemValue(insertRow, "memb",         mMemb);
                grdDirectData.SetItemValue(insertRow, "fkocs6010",    mFkocs6010);
                grdDirectData.SetItemValue(insertRow, "input_gwa",    mInputGwa);
                grdDirectData.SetItemValue(insertRow, "input_doctor", mInputDoctor);

                grdDirectData.SetItemValue(insertRow, "cp_code",      mCp_code);
                grdDirectData.SetItemValue(insertRow, "cp_path_code", mCp_path_code);
                grdDirectData.SetItemValue(insertRow, "input_gubun",  mInputGubun);
                grdDirectData.SetItemValue(insertRow, "jaewonil_from", dbxJaewonil.GetDataValue());
                grdDirectData.SetItemValue(insertRow, "jaewonil_to", TypeCheck.NVL(emkJaewon_to_il.GetDataValue(), 0));
                grdDirectData.SetItemValue(insertRow, "jaewonil",     mJaewonil);

                this.ClearControlAll();

                LoadDirect_cont(direct_gubun, direct_code);

                node.ImageIndex = 1;
                node.SelectedImageIndex = 1;

                direct_gubun_exists();

                SetSiksaControlLock("set");
            }
            else
            {
                LockControl(true);

                int insertRow = -1;

                if (direct_gubun == "02")
                {
                    for (int i = 0; i < grdOriginDirectData.RowCount; i++)
                    {
                        string orginCode = grdOriginDirectData.GetItemString(i, "direct_code").Substring(3, 1);
                        if (direct_code.Substring(3, 1) == orginCode && grdOriginDirectData.GetItemString(i, "direct_gubun") == "02")
                        {
                            string msg = string.Empty;
                            if (direct_code.Substring(3, 1) == "1") msg = "朝食";
                            else if (direct_code.Substring(3, 1) == "2") msg = "昼食";
                            else if (direct_code.Substring(3, 1) == "3") msg = "夕食";

                            XMessageBox.Show("既に [" + msg + "] 指示が入力されています。\n\r 先ず、入力された [" + msg + "] 指示の削除をしてから再入力してください。", "注意",
                                MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }

                insertRow = grdDirectData.InsertRow(-1);

                string plan_order_date = LoadPlanFromDate(insertRow);

                grdDirectData.SetItemValue(insertRow, "direct_gubun", direct_gubun);
                grdDirectData.SetItemValue(insertRow, "direct_gubun_name", direct_gubun_name);
                grdDirectData.SetItemValue(insertRow, "direct_code", direct_code);
                grdDirectData.SetItemValue(insertRow, "direct_code_name", direct_code_name);

                grdDirectData.SetItemValue(insertRow, "pk_seq", LoadDetailKey(grdDirectData.GetItemString(insertRow, "pkocs2005")));

                if (this.mDirectMode == "1")
                {
                    grdDirectData.SetItemValue(insertRow, "drt_from_date", plan_order_date);
                    grdDirectData.SetItemValue(insertRow, "continue_yn", "Y");

                    grdDirectData.SetItemValue(insertRow, "cp_code", mCp_code);
                    grdDirectData.SetItemValue(insertRow, "cp_path_code", mCp_path_code);
                    grdDirectData.SetItemValue(insertRow, "input_gubun", mInputGubun);
                    grdDirectData.SetItemValue(insertRow, "fkocs6010", mFkocs6010);
                    grdDirectData.SetItemValue(insertRow, "jaewonil", mJaewonil);

                    grdDirectData.SetItemValue(insertRow, "pkocs6015", GetPKOCS("6015"));
                }
                else if (this.mDirectMode == "2")
                {
                    grdDirectData.SetItemValue(insertRow, "drt_from_date", mOrder_date);
                    grdDirectData.SetItemValue(insertRow, "continue_yn", "Y");

                    grdDirectData.SetItemValue(insertRow, "pkocs2005", GetPKOCS("2005")); // 20110127
                }
                else if(this.mDirectMode != "3")
                {
                    grdDirectData.SetItemValue(insertRow, "drt_from_date", plan_order_date);
                    grdDirectData.SetItemValue(insertRow, "continue_yn", "Y");

                    grdDirectData.SetItemValue(insertRow, "pkocs2005", GetPKOCS("2005")); // 20110127
                }

                if (insertRow > 0)
                {
                    grdDirectData.SetItemValue(insertRow - 1, "drt_to_date", DateTime.Parse(plan_order_date).AddDays(-1));
                    grdDirectData.SetItemValue(insertRow - 1, "continue_yn", "N");
                }

                this.ClearControlAll();

                LoadDirect_cont(direct_gubun, direct_code);

                node.ImageIndex = 1;
                node.SelectedImageIndex = 1;

                direct_gubun_exists();

                SetSiksaControlLock("set");
            }
        }

        private void DeleteDirectData()
        {
            if (this.grdDirectData.CurrentRowNumber < 0)
                return;

            string plan_from_date = grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "drt_from_date");
            string direct_gubun   = grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "direct_gubun");
            string direct_code    = grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "direct_code");
            string pk_seq         = grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "pk_seq");


            /////////////////// 2011.06.01 test
            string pkocs2005      = grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "pkocs2005");
            /////////////////// 2011.06.01 test


            grdDirectData.DeleteRow(grdDirectData.CurrentRowNumber);
            
            for (int i = 0; i < this.grdDirectDetail.RowCount; i++)
            {
                //if (plan_from_date == grdDirectDetail.GetItemString(i, "order_date")   &&
                //    direct_gubun   == grdDirectDetail.GetItemString(i, "direct_gubun") &&
                //    direct_code    == grdDirectDetail.GetItemString(i, "direct_code"))
                //{
                //    grdDirectDetail.DeleteRow(i);
                //    i--;
                //}

                /////////////////// 2011.06.01 test
                if (pk_seq == grdDirectDetail.GetItemString(i, "pk_seq"))
                {
                    grdDirectDetail.DeleteRow(i);
                    i--;
                }
                /////////////////// 2011.06.01 test

            }

            if (grdDirectData.RowCount == 0)
            {
                tvwDirectInfo.SelectedNode.ImageIndex = 0;
                tvwDirectInfo.SelectedNode.SelectedImageIndex = 0;

                this.ClearControlAll();
                LockControl(false);

                for (int i = 0; i < grdOriginDirectData.RowCount; i++)
                {
                    //if (pk_seq == grdOriginDirectData.GetItemString(i, "pk_seq")
                    // && plan_from_date == grdOriginDirectData.GetItemString(i, "order_date"))
                    //{
                    //    grdOriginDirectData.DeleteRow(i);
                    //    i--;
                    //}

                    /////////////////// 2011.06.01 test
                    if (pk_seq == grdOriginDirectData.GetItemString(i, "pk_seq"))
                    {
                        grdOriginDirectData.DeleteRow(i);
                        i--;
                    }
                    /////////////////// 2011.06.01 test

                }
                for (int i = 0; i < grdOriginDirectDetail.RowCount; i++)
                {
                    //if (pk_seq == grdOriginDirectDetail.GetItemString(i, "pk_seq")
                    // && plan_from_date == grdOriginDirectDetail.GetItemString(i, "order_date"))
                    //{
                    //    grdOriginDirectDetail.DeleteRow(i);
                    //    i--;
                    //}

                    /////////////////// 2011.06.01 test
                    if (pk_seq == grdOriginDirectDetail.GetItemString(i, "pk_seq"))
                    {
                        grdOriginDirectDetail.DeleteRow(i);
                        i--;
                    }
                    /////////////////// 2011.06.01 test

                }
            }
            else
                ApplyData(grdDirectData.CurrentRowNumber);

            direct_gubun_exists();

            SetSiksaControlLock("delete");

        }
        #endregion


        #region Insert and Delete Direct [ Detail ]

        private void InsertDirectDetail(TreeNode node)
        {
            this.AcceptData();

            string direct_gubun = node.Tag.ToString().Split('|')[0];
            string direct_gubun_name = tvwDirect_gubun.SelectedNode.Text;
            string direct_code = node.Tag.ToString().Split('|')[1];
            string direct_code_name = node.Text;

            LockControl(true);

            int insertRow = grdDirectData.InsertRow(-1);

            string plan_order_date = LoadPlanFromDate(insertRow);

            grdDirectData.SetItemValue(insertRow, "direct_gubun",       direct_gubun);
            grdDirectData.SetItemValue(insertRow, "direct_gubun_name",  direct_gubun_name);
            grdDirectData.SetItemValue(insertRow, "direct_code",        direct_code);
            grdDirectData.SetItemValue(insertRow, "direct_code_name",   direct_code_name);

            grdDirectData.SetItemValue(insertRow, "fkocs6010", mFkocs6010);
            if (this.mDirectMode == "0")
            {
                grdDirectData.SetItemValue(insertRow, "memb_gubun",     mMembGubun);
                grdDirectData.SetItemValue(insertRow, "memb",           mMemb);
                grdDirectData.SetItemValue(insertRow, "input_gwa",      mInputGwa);
                grdDirectData.SetItemValue(insertRow, "input_doctor",   mInputDoctor);

                grdDirectData.SetItemValue(insertRow, "cp_code",        mCp_code);
                grdDirectData.SetItemValue(insertRow, "cp_path_code",   mCp_path_code);
                grdDirectData.SetItemValue(insertRow, "input_gubun",    mInputGubun);
                grdDirectData.SetItemValue(insertRow, "jaewonil",       mJaewonil);
            //}
            //else// if (this.mDirectMode == "1")
            //{
                grdDirectData.SetItemValue(insertRow, "drt_from_date", plan_order_date);
                //grdDirectData.SetItemValue(insertRow, "continue_yn", "Y");
            }

            if (insertRow > 0)
            {
                grdDirectData.SetItemValue(insertRow - 1, "drt_to_date", DateTime.Parse(plan_order_date).AddDays(-1));
                grdDirectData.SetItemValue(insertRow - 1, "continue_yn", "N");
            }

            this.ClearControlAll();

            LoadDirect_cont(direct_gubun, direct_code);

            node.ImageIndex = 1;
            node.SelectedImageIndex = 1;

            direct_gubun_exists();
        }

        private void DeleteDirectDetail()
        {
            if (this.grdDirectData.CurrentRowNumber < 0)
                return;

            grdDirectData.DeleteRow(grdDirectData.CurrentRowNumber);

            string plan_from_date = grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "drt_from_date");
            string direct_gubun   = grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "direct_gubun");
            string direct_code    = grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "direct_code");

            for (int i = 0; i < this.grdOriginDirectDetail.RowCount; i++)
            {
                if (plan_from_date == grdOriginDirectDetail.GetItemString(i, "order_date") &&
                    direct_gubun   == grdOriginDirectDetail.GetItemString(i, "direct_gubun") &&
                    direct_code    == grdOriginDirectDetail.GetItemString(i, "direct_code"))
                {
                    grdOriginDirectDetail.DeleteRow(i);
                    i--;
                }
            }

            if (grdDirectData.RowCount == 0)
            {
                tvwDirectInfo.SelectedNode.ImageIndex = 0;
                tvwDirectInfo.SelectedNode.SelectedImageIndex = 0;

                this.ClearControlAll();
                LockControl(false);
            }
            else
                ApplyData(grdDirectData.CurrentRowNumber);

            direct_gubun_exists();

        }

        #endregion


        private void InsertDirectDetailData_2(TreeNode node)
        {
            if (node.ImageIndex != 1)
                return;

            string direct_gubun = node.Tag.ToString().Split('|')[0];
            string direct_code = node.Tag.ToString().Split('|')[1];

            int seq = LoadDetailKey();

            int insertRow = grdDetail_2.InsertRow(-1);

            grdDetail_2.SetItemValue(insertRow, "order_date",   grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "drt_from_date"));
            grdDetail_2.SetItemValue(insertRow, "direct_gubun", direct_gubun);
            grdDetail_2.SetItemValue(insertRow, "direct_code",  direct_code);
            grdDetail_2.SetItemValue(insertRow, "direct_detail", "00");
            grdDetail_2.SetItemValue(insertRow, "pk_seq",       TypeCheck.NVL(grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "pk_seq"), "1"));
            grdDetail_2.SetItemValue(insertRow, "seq",          seq);

            grdDetail_2.SetItemValue(insertRow, "hangmog_code", cboHangmog_code.SelectedValue);

        }

        private int LoadDetailKey()
        {
            int seq = 1;

            try
            {
                foreach (DataRow row in grdDirectDetail.LayoutTable.Select("", " seq DESC "))
                {
                    if (row["seq"].ToString() == "")
                        seq = 1;
                    else
                        seq = int.Parse(row["seq"].ToString()) + 1;
                    break;
                }
            }
            catch { }

            return seq;
        }

        private string LoadDetailKey(string pk)
        {
            int pk_seq_db = 1;
            int pk_seq_local = 1;

            int pk_seq = 1;
            int maxSeq = 0;

            try
            {

                //foreach (DataRow row in grdOriginDirectData.LayoutTable.Select("", " pk_seq DESC"))
                //{
                //    pk_seq_local = int.Parse(row["pk_seq"].ToString()) + 1;
                //    break;
                //}

                for (int i = 0; i < grdOriginDirectData.RowCount; i++)
                {
                    if (maxSeq < grdOriginDirectData.GetItemInt(i, "pk_seq"))
                        maxSeq = grdOriginDirectData.GetItemInt(i, "pk_seq");
                }
                pk_seq_local = maxSeq + 1;


                string cmd = @" SELECT MAX(A.PK_SEQ)
                                  FROM OCS2005 A
                                 WHERE A.HOSP_CODE   = :f_hosp_code
                                   AND A.BUNHO       = :f_bunho
                                   AND A.FKINP1001   = :f_fkinp1001
--                                   AND :f_order_date BETWEEN NVL(A.DRT_FROM_DATE, A.ORDER_DATE) AND NVL(A.DRT_TO_DATE, '9999/12/31')
                                   AND :f_order_date BETWEEN A.ORDER_DATE AND NVL(A.DRT_TO_DATE, '9999/12/31')
                                 ORDER BY A.PK_SEQ";
                BindVarCollection bind = new BindVarCollection();
                bind.Add("f_hosp_code",  EnvironInfo.HospCode);
                bind.Add("f_bunho",      mBunho);
                bind.Add("f_fkinp1001",  mFkinp1001);
                bind.Add("f_order_date", mOrder_date);

                object obj = Service.ExecuteScalar(cmd, bind);

                if (obj.ToString() != "")
                    pk_seq_db = int.Parse(obj.ToString()) + 1;
                else
                    pk_seq_db = 1;

                pk_seq = pk_seq_local >= pk_seq_db ? pk_seq_local : pk_seq_db;


                //for (int i = 0; i < grdOriginDirectData.RowCount; i++)
                //{
                //    if (maxSeq < grdOriginDirectData.GetItemInt(i, "pk_seq"))
                //    {
                //        maxSeq = grdOriginDirectData.GetItemInt(i, "pk_seq");
                //    }
                //}

                //pk_seq = maxSeq + 1;

            }
            catch { }

            return pk_seq.ToString();
        }

        private string LoadBomSourceKey()
        {
            int bomSourceKey = 1;

            try
            {
                foreach (DataRow row in grdDirectDetail.LayoutTable.Select("", " bom_source_key DESC "))
                {
                    bomSourceKey = int.Parse(row["bomSourceKey"].ToString()) + 1;
                    break;
                }
            }
            catch { }

            return bomSourceKey.ToString();
        }

        private void ReturnValue()
        {
            IHIS.Framework.MultiLayout dloDirectData         = grdOriginDirectData.CloneToLayout();
            IHIS.Framework.MultiLayout dloDeleteDirectData   = grdOriginDirectData.CloneToLayout();

            IHIS.Framework.MultiLayout dloDirectDetail       = grdOriginDirectDetail.CloneToLayout();
            IHIS.Framework.MultiLayout dloDeleteDirectDetail = grdOriginDirectDetail.CloneToLayout();

            if (grdOriginDirectData.DeletedRowTable != null)
            {
                foreach (DataRow row in grdOriginDirectData.DeletedRowTable.Rows)
                {
                    dloDeleteDirectData.LayoutTable.ImportRow(row);
                }
            }

            for (int i = 0; i < grdOriginDirectData.RowCount; i++)
            {
                if (TypeCheck.IsNull(grdOriginDirectData.GetItemString(i, "direct_text").Trim()))
                {
                    if (grdOriginDirectData.GetRowState(i) != DataRowState.Added)
                        dloDeleteDirectData.LayoutTable.ImportRow(grdOriginDirectData.LayoutTable.Rows[i]);
                    else
                    {
                        grdOriginDirectData.DeleteRow(i);
                        i--;
                    }
                }
                else
                {
                    dloDirectData.LayoutTable.ImportRow(grdOriginDirectData.LayoutTable.Rows[i]);
                }
            }

            if (grdOriginDirectDetail.DeletedRowTable != null)
            {
                foreach (DataRow row in grdOriginDirectDetail.DeletedRowTable.Rows)
                {
                    dloDeleteDirectDetail.LayoutTable.ImportRow(row);
                }
            }

            for (int i = 0; i < grdOriginDirectDetail.RowCount; i++)
            {
                dloDirectDetail.LayoutTable.ImportRow(grdOriginDirectDetail.LayoutTable.Rows[i]);
            }

            IHIS.Framework.XScreen scrOpener = (XScreen)Opener;

            CommonItemCollection commandParams = new CommonItemCollection();
            commandParams.Add("DELETEDIRECT",       dloDeleteDirectData);
            commandParams.Add("DIRECT",             dloDirectData);
            commandParams.Add("DELETEDIRECTDETAIL", dloDeleteDirectDetail);
            commandParams.Add("DIRECTDETAIL",       dloDirectDetail);
            scrOpener.Command(ScreenID,             commandParams);

            this.Close();
        }

        private string LoadPlanFromDate(int rowIndex)
        {
            string plan_from_date;

            if (rowIndex > 0)
            {
                if (!TypeCheck.IsNull(grdDirectData.GetItemString(rowIndex - 1, "drt_to_date")))
                {
                    plan_from_date = grdDirectData.GetItemDateTime(rowIndex - 1, "drt_to_date").AddDays(1).ToString("yyyy/MM/dd");
                }
                else
                {
                    plan_from_date = grdDirectData.GetItemDateTime(rowIndex - 1, "drt_from_date").AddDays(1).ToString("yyyy/MM/dd");                    
                }

                if (this.BetweenDay(plan_from_date, EnvironInfo.GetSysDate().ToString("yyyy/MM/dd")) < 0)
                    plan_from_date = EnvironInfo.GetSysDate().ToString("yyyy/MM/dd");
            }
            else
            {
                if (!TypeCheck.IsNull(mPlan_order_date))
                    plan_from_date = mPlan_order_date;
                else
                    plan_from_date = EnvironInfo.GetSysDate().ToString("yyyy/MM/dd");
            }

            if (this.BetweenDay(plan_from_date, EnvironInfo.GetSysDate().ToString("yyyy/MM/dd")) < 0)
                plan_from_date = EnvironInfo.GetSysDate().ToString("yyyy/MM/dd");

            return plan_from_date;
        }

        private int BetweenDay(string A, string B)
        {
            int between = -1;
            if (!TypeCheck.IsDateTime(A))
                return between;

            if (!TypeCheck.IsDateTime(B))
                return between;

            string cmdText = string.Empty;
            BindVarCollection bindVals = new BindVarCollection();

            cmdText = "SELECT TO_DATE('" + A + "', 'YYYY/MM/DD') - TO_DATE('" + B + "', 'YYYY/MM/DD') FROM DUAL ";

            between = Int32.Parse(Service.ExecuteScalar(cmdText, bindVals).ToString());

            return between;
        }

        private void CreateTreeVIewDirect_code(string direct_gubun)
        {
            preNode = null;

            this.tvwDirectInfo.BeforeSelect -= new System.Windows.Forms.TreeViewCancelEventHandler(this.tvwDirectInfo_BeforeSelect);

            tvwDirectInfo.Nodes.Clear();
            if (this.dloDirectInfo.RowCount < 1) return;

            TreeNode node;
            string nur_md_code = "";

            foreach (DataRow row in dloDirectInfo.LayoutTable.Select(" nur_gr_code = '" + direct_gubun + "' ", ""))
            {
                if (nur_md_code != row["nur_md_code"].ToString())
                {
                    node = new TreeNode(row["nur_md_name"].ToString());
                    node.Tag = direct_gubun + "|" + row["nur_md_code"].ToString();

                    if (this.grdOriginDirectData.LayoutTable.Select(" direct_gubun = '" + direct_gubun + "' and direct_code = '" + row["nur_md_code"].ToString() + "' ", "").Length > 0)
                    {
                        node.SelectedImageIndex = 1;
                        node.ImageIndex = 1;
                    }
                    else
                    {
                        node.SelectedImageIndex = 0;
                        node.ImageIndex = 0;
                    }

                    tvwDirectInfo.Nodes.Add(node);
                    nur_md_code = row["nur_md_code"].ToString();
                }

            }

            this.tvwDirectInfo.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvwDirectInfo_BeforeSelect);

            tvwDirectInfo.ExpandAll();
            if (tvwDirectInfo.Nodes.Count > 0) tvwDirectInfo.SelectedNode = tvwDirectInfo.Nodes[0];
        }

        private void ApplyDirectData(string aDirect_gubun, string aDirect_code)
        {
            ApplyDeleteDirectData();

            for (int i = 0; i < grdOriginDirectData.RowCount; i++)
            {
                if (grdOriginDirectData.GetItemString(i, "direct_gubun") == aDirect_gubun &&
                    grdOriginDirectData.GetItemString(i, "direct_code") == aDirect_code         )
                {
                    grdOriginDirectData.LayoutTable.Rows.Remove(grdOriginDirectData.LayoutTable.Rows[i]);
                    i--;
                }
            }

            if (grdDirectData.CurrentRowNumber >= 0)
            {
                this.ApplyData(grdDirectData.CurrentRowNumber);
            }

            for (int i = 0; i < grdDirectData.RowCount; i++)
            {
                if (grdDirectData.GetItemString(i, "direct_text") != "")
                {
                    grdOriginDirectData.LayoutTable.ImportRow(grdDirectData.LayoutTable.Rows[i]);
                }
            }

            for (int i = 0; i < grdDirectData.RowCount; i++)
            {
                bool valid = true;

                foreach (DataRow row in grdOriginDirectData.LayoutTable.Rows)
                {
                    
                    if (grdDirectData.GetItemString(i, "direct_gubun") == row["direct_gubun"].ToString() &&
                        grdDirectData.GetItemString(i, "direct_code") == row["direct_code"].ToString())
                    {
                        valid = false;
                    }
                }

                if (valid)
                {
                    grdOriginDirectData.LayoutTable.ImportRow(grdDirectData.LayoutTable.Rows[i]);
                }
            }

            grdOriginDirectData.DisplayData();
            grdOriginDirectData.AcceptData();

            // grdOriginDirectDetail //

            for (int i = 0; i < grdOriginDirectDetail.RowCount; i++)
            {
                for (int j = 0; j < grdDirectDetail.RowCount; j++)
                {
                    if (grdOriginDirectDetail.GetItemString(i, "direct_gubun") == aDirect_gubun &&
                        grdOriginDirectDetail.GetItemString(i, "direct_code")  == aDirect_code &&
                        grdOriginDirectDetail.GetItemString(i, "pk_seq")       == grdDirectDetail.GetItemString(j, "pk_seq") &&
                        grdOriginDirectDetail.GetItemString(i, "seq")          == grdDirectDetail.GetItemString(j, "seq"))
                    {
                        grdOriginDirectDetail.LayoutTable.Rows.Remove(grdOriginDirectDetail.LayoutTable.Rows[i]);
                        i--;
                    }
                }
            }

            if (grdDirectDetail.CurrentRowNumber >= 0)
            {
                this.ApplyData(grdDirectDetail.CurrentRowNumber);
            }

            for (int i = 0; i < grdDirectDetail.RowCount; i++)
            {
                bool valid = true;

                foreach (DataRow row in grdOriginDirectDetail.LayoutTable.Rows)
                {
                    if (grdDirectDetail.GetItemString(i, "direct_gubun") == row["direct_gubun"].ToString() &&
                        grdDirectDetail.GetItemString(i, "direct_code") == row["direct_code"].ToString()   &&
                        grdDirectDetail.GetItemString(i, "seq") == row["seq"].ToString())
                    {
                        valid = false;
                    }
                }

                if (valid)
                {
                    grdOriginDirectDetail.LayoutTable.ImportRow(grdDirectDetail.LayoutTable.Rows[i]);
                }
            }

            grdOriginDirectDetail.DisplayData();
        }

        private void ApplyDeleteDirectData()
        {
            string plan_from_date = "";
            string direct_gubun = "";
            string direct_code = "";
            string seq = "";

            if (grdDirectData.DeletedRowTable != null)
            {
                for (int i = 0; i < grdDirectData.DeletedRowTable.Rows.Count; i++)
                {
                    plan_from_date = grdDirectData.DeletedRowTable.Rows[i]["order_date"].ToString();
                    direct_gubun = grdDirectData.DeletedRowTable.Rows[i]["direct_gubun"].ToString();
                    direct_code = grdDirectData.DeletedRowTable.Rows[i]["direct_code"].ToString();

                    for (int j = 0; j < grdOriginDirectData.LayoutTable.Rows.Count; j++)
                    {
                        if (plan_from_date == grdOriginDirectData.LayoutTable.Rows[j]["drt_from_date"].ToString() &&
                            direct_gubun == grdOriginDirectData.LayoutTable.Rows[j]["direct_gubun"].ToString() &&
                            direct_code == grdOriginDirectData.LayoutTable.Rows[j]["direct_code"].ToString())
                        {
                            grdOriginDirectData.DeleteRow(j);
                            j--;
                        }
                    }
                }
            }

            if (grdDirectDetail.DeletedRowTable != null)
            {
                for (int i = 0; i < grdDirectDetail.DeletedRowTable.Rows.Count; i++)
                {
                    plan_from_date = grdDirectDetail.DeletedRowTable.Rows[i]["order_date"].ToString();
                    direct_gubun = grdDirectDetail.DeletedRowTable.Rows[i]["direct_gubun"].ToString();
                    direct_code = grdDirectDetail.DeletedRowTable.Rows[i]["direct_code"].ToString();
                    seq = grdDirectDetail.DeletedRowTable.Rows[i]["seq"].ToString();

                    for (int j = 0; j < grdOriginDirectDetail.LayoutTable.Rows.Count; j++)
                    {
                        if (plan_from_date == grdOriginDirectDetail.LayoutTable.Rows[j]["order_date"].ToString() &&
                            direct_gubun == grdOriginDirectDetail.LayoutTable.Rows[j]["direct_gubun"].ToString() &&
                            direct_code == grdOriginDirectDetail.LayoutTable.Rows[j]["direct_code"].ToString() &&
                            seq == grdOriginDirectDetail.LayoutTable.Rows[j]["seq"].ToString())
                        {
                            grdOriginDirectDetail.DeleteRow(j);
                            j--;
                        }
                    }
                }
            }
        }

        private void SetDataFromTo()
        {
            string direct_gubun = tvwDirectInfo.SelectedNode.Tag.ToString().Split('|')[0];
            string direct_code = tvwDirectInfo.SelectedNode.Tag.ToString().Split('|')[1];

            for (int i = 0; i < grdDirectData.RowCount; i++)
            {
                if (grdDirectData.GetItemString(i, "direct_gubun") == direct_gubun && grdDirectData.GetItemString(i, "direct_code") == direct_code)
                {
                    grdDirectData.SetItemValue(i, "drt_from_date", dpkPlan_from_date.GetDataValue());
                    grdDirectData.SetItemValue(i, "drt_to_date", dpkPlan_to_date.GetDataValue());
                    grdDirectData.SetItemValue(i, "continue_yn", chkContinue_yn.GetDataValue());

                    if (!pnlDetail_2.Visible || !pnlDetail_3.Visible)
                    {
                        grdDirectData.SetItemValue(i, "direct_text", txtDirect_text.Text);
                    }
                }
            }
        }

        #endregion

		#region [Control Event]

        private void emkAct_time_DataValidating(object sender, DataValidatingEventArgs e)
        {
            if (!TypeCheck.IsDateTime(emkAct_time.Text))
            {
                emkAct_time.SetDataValue("0000");
            }
        }

        private void btnInsertDetail_2_Click(object sender, EventArgs e)
        {

            if (this.grdDetail_2.CurrentRowNumber < 0 || this.grdDetail_2.GetItemString(this.grdDetail_2.CurrentRowNumber, "insulin_from") != "")
            {
                if (tvwDirectInfo.SelectedNode != null)
                    this.InsertDirectDetailData_2(tvwDirectInfo.SelectedNode);
            }
            else
                return;

            int insertRow = grdDirectDetail.InsertRow(-1);

            string plan_order_date = EnvironInfo.GetSysDate().ToShortDateString();

            if (!TypeCheck.IsNull(dpkPlan_from_date.GetDataValue()))
            {
                plan_order_date = dpkPlan_from_date.GetDataValue();
            }

            string direct_gubun = grdDirectData.GetItemString(0, "direct_gubun");
            string direct_gubun_name = grdDirectData.GetItemString(0, "direct_gubun_name");
            string direct_code = grdDirectData.GetItemString(0, "direct_code");
            string direct_code_name = grdDirectData.GetItemString(0, "direct_code_name");
            string aHangmogCode = cboHangmog_code.GetDataValue();

            grdDirectDetail.SetItemValue(insertRow, "direct_gubun", direct_gubun);
            grdDirectDetail.SetItemValue(insertRow, "direct_code",  direct_code);
            grdDirectDetail.SetItemValue(insertRow, "hangmog_code", aHangmogCode);
            grdDirectDetail.SetItemValue(insertRow, "input_gubun",  mInputGubun);
            grdDirectDetail.SetItemValue(insertRow, "fkocs2005",    grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "pkocs2005"));

            // CP Detail Insert
            grdDirectDetail.SetItemValue(insertRow, "memb",         grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "memb"));
            grdDirectDetail.SetItemValue(insertRow, "memb_gubun",   grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "memb_gubun"));
            grdDirectDetail.SetItemValue(insertRow, "cp_code",      grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "cp_code"));
            grdDirectDetail.SetItemValue(insertRow, "cp_path_code", grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "cp_path_code"));
            grdDirectDetail.SetItemValue(insertRow, "jaewonil",     grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "jaewonil"));
            grdDirectDetail.SetItemValue(insertRow, "fkocs6005",    grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "pkocs6005"));
            grdDirectDetail.SetItemValue(insertRow, "fkocs6010",    grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "fkocs6010"));
            grdDirectDetail.SetItemValue(insertRow, "fkocs6015",    grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "pkocs6015"));

            grdDirectDetail.SetItemValue(insertRow, "direct_detail", "00");
        }

        private void btnDeleteDetail_2_Click(object sender, EventArgs e)
        {
            string seq = "-1";
            if (this.grdDetail_2.CurrentRowNumber < 0) return;

            seq = this.grdDetail_2.GetItemString(grdDetail_2.CurrentRowNumber, "seq");

            this.grdDetail_2.DeleteRow(this.grdDetail_2.CurrentRowNumber);

            for(int i = 0; i < grdDirectDetail.RowCount; i++)
            {
                if (grdDirectDetail.GetItemString(i, "seq") == seq)
                {
                    grdDirectDetail.DeleteRow(i);
                    i--;
                }
            }
        }

        private void grdDetail_2_GridColumnChanged(object sender, GridColumnChangedEventArgs e)
        {
            Detail_2_Create_text();
        }

        private void cbxHangmog_code_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < grdDetail_2.RowCount; i++)
            {
                grdDetail_2.SetItemValue(i, "hangmog_code", cboHangmog_code.GetDataValue());
            }

            Detail_2_Create_text();
        }

        private void cboHangmog_code_SelectedIndexChanged(object sender, EventArgs e)
        {
            XComboBox cbx = sender as XComboBox;
            int insertRow = 0;

            string delHCode, delSeq;
            bool isRow = false;
            switch (cbx.Name)
            {
                case "cboHangmog_code1":
                    if (cboHangmog_code1.SelectedIndex > 0)
                    {
                        emkSurayng1.Enabled = true;
                        vsbSurayng1.Enabled = true;

                        //for (int i = 0; i < grdDirectDetail.RowCount; i++)
                        //{
                        //    if (grdDirectDetail.GetItemString(i, "time_gubun").Equals("0"))
                        //    {

                        //        delHCode = grdDirectDetail.GetItemString(i, "hangmog_code");
                        //        delSeq = grdDirectDetail.GetItemString(i, "seq");

                        //        grdDirectDetail.DeleteRow(i);
                        //        i--;

                        //        for (int j = 0; j < grdOriginDirectDetail.RowCount; j++)
                        //        {
                        //            if (delHCode.Equals(grdOriginDirectDetail.GetItemString(j, "hangmog_code")) &&
                        //               delSeq.Equals(grdOriginDirectDetail.GetItemString(j, "seq")) &&
                        //               grdOriginDirectDetail.GetItemString(j, "time_gubun").Equals("0"))
                        //            {
                        //                grdOriginDirectDetail.DeleteRow(j);
                        //                j--;
                        //            }
                        //        }
                        //    }
                        //}
                        //grdDirectDetail.AcceptData();
                        //// 20121201
                        //insertRow = grdDirectDetail.InsertRow(-1);

                        //grdDirectDetail.SetItemValue(insertRow, "bunho", grdDirectData.GetItemString(0, "bunho"));
                        //grdDirectDetail.SetItemValue(insertRow, "fkinp1001", grdDirectData.GetItemString(0, "fkinp1001"));
                        //grdDirectDetail.SetItemValue(insertRow, "order_date", grdDirectData.GetItemString(0, "order_date"));
                        //grdDirectDetail.SetItemValue(insertRow, "input_gubun", grdDirectData.GetItemString(0, "input_gubun"));
                        //grdDirectDetail.SetItemValue(insertRow, "direct_gubun", grdDirectData.GetItemString(0, "direct_gubun"));
                        //grdDirectDetail.SetItemValue(insertRow, "direct_code", grdDirectData.GetItemString(0, "direct_code"));
                        //grdDirectDetail.SetItemValue(insertRow, "pk_seq", grdDirectData.GetItemString(0, "pk_seq"));
                        //grdDirectDetail.SetItemValue(insertRow, "seq", LoadDetailKey());
                        //grdDirectDetail.SetItemValue(insertRow, "time_gubun", "0"); // 조주석침구분 0 : 아침
                        //grdDirectDetail.SetItemValue(insertRow, "hangmog_code", cboHangmog_code1.GetDataValue());
                        //grdDirectDetail.SetItemValue(insertRow, "fkocs2005", grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "pkocs2005"));

                        //// CP Detail Insert
                        //grdDirectDetail.SetItemValue(insertRow, "memb", grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "memb"));
                        //grdDirectDetail.SetItemValue(insertRow, "memb_gubun", grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "memb_gubun"));
                        //grdDirectDetail.SetItemValue(insertRow, "cp_code", grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "cp_code"));
                        //grdDirectDetail.SetItemValue(insertRow, "cp_path_code", grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "cp_path_code"));
                        //grdDirectDetail.SetItemValue(insertRow, "jaewonil", grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "jaewonil"));
                        //grdDirectDetail.SetItemValue(insertRow, "fkocs6005", grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "pkocs6005"));
                        //grdDirectDetail.SetItemValue(insertRow, "fkocs6010", grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "fkocs6010"));
                        //grdDirectDetail.SetItemValue(insertRow, "fkocs6015", grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "pkocs6015"));
                        isRow = false;
                        if (grdDirectDetail.RowCount > 0)
                        {
                            for (int i = 0; i < grdDirectDetail.RowCount; i++)
                            {
                                if (grdDirectDetail.GetItemString(i, "time_gubun").Equals("0"))
                                {
                                    isRow = true;

                                    if(grdDirectDetail.GetItemString(i, "hangmog_code") != cboHangmog_code1.GetDataValue())
                                        grdDirectDetail.SetItemValue(i, "hangmog_code", cboHangmog_code1.GetDataValue());
                                }
                            }
                        }

                        if (grdDirectDetail.RowCount == 0 || !isRow)
                        {
                            grdDirectDetail.AcceptData();
                            // 20121201
                            insertRow = grdDirectDetail.InsertRow(-1);

                            grdDirectDetail.SetItemValue(insertRow, "bunho", grdDirectData.GetItemString(0, "bunho"));
                            grdDirectDetail.SetItemValue(insertRow, "fkinp1001", grdDirectData.GetItemString(0, "fkinp1001"));
                            grdDirectDetail.SetItemValue(insertRow, "order_date", grdDirectData.GetItemString(0, "order_date"));
                            grdDirectDetail.SetItemValue(insertRow, "input_gubun", grdDirectData.GetItemString(0, "input_gubun"));
                            grdDirectDetail.SetItemValue(insertRow, "direct_gubun", grdDirectData.GetItemString(0, "direct_gubun"));
                            grdDirectDetail.SetItemValue(insertRow, "direct_code", grdDirectData.GetItemString(0, "direct_code"));
                            grdDirectDetail.SetItemValue(insertRow, "pk_seq", grdDirectData.GetItemString(0, "pk_seq"));
                            grdDirectDetail.SetItemValue(insertRow, "seq", LoadDetailKey());
                            grdDirectDetail.SetItemValue(insertRow, "time_gubun", "0"); // 조주석침구분 0 : 아침
                            grdDirectDetail.SetItemValue(insertRow, "hangmog_code", cboHangmog_code1.GetDataValue());
                            grdDirectDetail.SetItemValue(insertRow, "fkocs2005", grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "pkocs2005"));

                            // CP Detail Insert
                            grdDirectDetail.SetItemValue(insertRow, "memb", grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "memb"));
                            grdDirectDetail.SetItemValue(insertRow, "memb_gubun", grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "memb_gubun"));
                            grdDirectDetail.SetItemValue(insertRow, "cp_code", grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "cp_code"));
                            grdDirectDetail.SetItemValue(insertRow, "cp_path_code", grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "cp_path_code"));
                            grdDirectDetail.SetItemValue(insertRow, "jaewonil", grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "jaewonil"));
                            grdDirectDetail.SetItemValue(insertRow, "fkocs6005", grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "pkocs6005"));
                            grdDirectDetail.SetItemValue(insertRow, "fkocs6010", grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "fkocs6010"));
                            grdDirectDetail.SetItemValue(insertRow, "fkocs6015", grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "pkocs6015"));
                        }
                        
                    }
                    else
                    {
                        emkSurayng1.Enabled = false;
                        vsbSurayng1.Enabled = false;
                        emkSurayng1.SetDataValue(0);
                        for (int i = 0; i < grdDirectDetail.RowCount; i++)
                        {
                            if (grdDirectDetail.GetItemString(i, "time_gubun").Equals("0"))
                            {
                                delHCode = grdDirectDetail.GetItemString(i, "hangmog_code");
                                delSeq = grdDirectDetail.GetItemString(i, "seq");

                                grdDirectDetail.DeleteRow(i);
                                i--;

                                for (int j = 0; j < grdOriginDirectDetail.RowCount; j++)
                                {
                                    if (delHCode.Equals(grdOriginDirectDetail.GetItemString(j, "hangmog_code")) &&
                                       delSeq.Equals(grdOriginDirectDetail.GetItemString(j, "seq")) &&
                                       grdOriginDirectDetail.GetItemString(j, "time_gubun").Equals("0"))
                                    {
                                        grdOriginDirectDetail.DeleteRow(j);
                                        j--;
                                    }
                                }
                            }
                        }
                        grdDirectDetail.AcceptData();
                    }
                    break;

                case "cboHangmog_code2":
                    if (cboHangmog_code2.SelectedIndex > 0)
                    {
                        emkSurayng2.Enabled = true;
                        vsbSurayng2.Enabled = true;

                        //for (int i = 0; i < grdDirectDetail.RowCount; i++)
                        //{
                        //    if (grdDirectDetail.GetItemString(i, "time_gubun").Equals("1"))
                        //    {
                        //        delHCode = grdDirectDetail.GetItemString(i, "hangmog_code");
                        //        delSeq = grdDirectDetail.GetItemString(i, "seq");

                        //        grdDirectDetail.DeleteRow(i);
                        //        i--;

                        //        for (int j = 0; j < grdOriginDirectDetail.RowCount; j++)
                        //        {
                        //            if (delHCode.Equals(grdOriginDirectDetail.GetItemString(j, "hangmog_code")) &&
                        //               delSeq.Equals(grdOriginDirectDetail.GetItemString(j, "seq")) &&
                        //               grdOriginDirectDetail.GetItemString(j, "time_gubun").Equals("1"))
                        //            {
                        //                grdOriginDirectDetail.DeleteRow(j);
                        //                j--;
                        //            }
                        //        }
                        //    }
                        //}
                        //grdDirectDetail.AcceptData();
                        //insertRow = grdDirectDetail.InsertRow(-1);

                        //grdDirectDetail.SetItemValue(insertRow, "bunho",        grdDirectData.GetItemString(0, "bunho"));
                        //grdDirectDetail.SetItemValue(insertRow, "fkinp1001",    grdDirectData.GetItemString(0, "fkinp1001"));
                        //grdDirectDetail.SetItemValue(insertRow, "order_date",   grdDirectData.GetItemString(0, "order_date"));
                        //grdDirectDetail.SetItemValue(insertRow, "input_gubun",  grdDirectData.GetItemString(0, "input_gubun"));
                        //grdDirectDetail.SetItemValue(insertRow, "direct_gubun", grdDirectData.GetItemString(0, "direct_gubun"));
                        //grdDirectDetail.SetItemValue(insertRow, "direct_code",  grdDirectData.GetItemString(0, "direct_code"));
                        //grdDirectDetail.SetItemValue(insertRow, "pk_seq",       grdDirectData.GetItemString(0, "pk_seq"));
                        //grdDirectDetail.SetItemValue(insertRow, "seq",          LoadDetailKey());
                        //grdDirectDetail.SetItemValue(insertRow, "time_gubun", "1"); // 조주석침구분 1 : 점심
                        //grdDirectDetail.SetItemValue(insertRow, "hangmog_code", cboHangmog_code2.GetDataValue());
                        //grdDirectDetail.SetItemValue(insertRow, "fkocs2005",    grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "pkocs2005"));
                        
                        //// CP Detail Insert
                        //grdDirectDetail.SetItemValue(insertRow, "memb",         grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "memb"));
                        //grdDirectDetail.SetItemValue(insertRow, "memb_gubun",   grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "memb_gubun"));
                        //grdDirectDetail.SetItemValue(insertRow, "cp_code",      grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "cp_code"));
                        //grdDirectDetail.SetItemValue(insertRow, "cp_path_code", grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "cp_path_code"));
                        //grdDirectDetail.SetItemValue(insertRow, "jaewonil",     grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "jaewonil"));
                        //grdDirectDetail.SetItemValue(insertRow, "fkocs6005",    grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "pkocs6005"));
                        //grdDirectDetail.SetItemValue(insertRow, "fkocs6010",    grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "fkocs6010"));
                        //grdDirectDetail.SetItemValue(insertRow, "fkocs6015",    grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "pkocs6015"));
                        isRow = false;
                        if (grdDirectDetail.RowCount > 0)
                        {
                            for (int i = 0; i < grdDirectDetail.RowCount; i++)
                            {
                                if (grdDirectDetail.GetItemString(i, "time_gubun").Equals("1"))
                                {
                                    isRow = true;
                                    if (grdDirectDetail.GetItemString(i, "hangmog_code") != cboHangmog_code2.GetDataValue())
                                        grdDirectDetail.SetItemValue(i, "hangmog_code", cboHangmog_code2.GetDataValue());
                                }
                            }
                        }

                        if (grdDirectDetail.RowCount == 0 || !isRow)
                        {
                            grdDirectDetail.AcceptData();
                            // 20121201
                            insertRow = grdDirectDetail.InsertRow(-1);

                            grdDirectDetail.SetItemValue(insertRow, "bunho", grdDirectData.GetItemString(0, "bunho"));
                            grdDirectDetail.SetItemValue(insertRow, "fkinp1001", grdDirectData.GetItemString(0, "fkinp1001"));
                            grdDirectDetail.SetItemValue(insertRow, "order_date", grdDirectData.GetItemString(0, "order_date"));
                            grdDirectDetail.SetItemValue(insertRow, "input_gubun", grdDirectData.GetItemString(0, "input_gubun"));
                            grdDirectDetail.SetItemValue(insertRow, "direct_gubun", grdDirectData.GetItemString(0, "direct_gubun"));
                            grdDirectDetail.SetItemValue(insertRow, "direct_code", grdDirectData.GetItemString(0, "direct_code"));
                            grdDirectDetail.SetItemValue(insertRow, "pk_seq", grdDirectData.GetItemString(0, "pk_seq"));
                            grdDirectDetail.SetItemValue(insertRow, "seq", LoadDetailKey());
                            grdDirectDetail.SetItemValue(insertRow, "time_gubun", "1"); // 조주석침구분 0 : 아침
                            grdDirectDetail.SetItemValue(insertRow, "hangmog_code", cboHangmog_code2.GetDataValue());
                            grdDirectDetail.SetItemValue(insertRow, "fkocs2005", grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "pkocs2005"));

                            // CP Detail Insert
                            grdDirectDetail.SetItemValue(insertRow, "memb", grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "memb"));
                            grdDirectDetail.SetItemValue(insertRow, "memb_gubun", grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "memb_gubun"));
                            grdDirectDetail.SetItemValue(insertRow, "cp_code", grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "cp_code"));
                            grdDirectDetail.SetItemValue(insertRow, "cp_path_code", grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "cp_path_code"));
                            grdDirectDetail.SetItemValue(insertRow, "jaewonil", grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "jaewonil"));
                            grdDirectDetail.SetItemValue(insertRow, "fkocs6005", grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "pkocs6005"));
                            grdDirectDetail.SetItemValue(insertRow, "fkocs6010", grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "fkocs6010"));
                            grdDirectDetail.SetItemValue(insertRow, "fkocs6015", grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "pkocs6015"));
                        }
                    }
                    else
                    {
                        emkSurayng2.Enabled = false;
                        vsbSurayng2.Enabled = false;
                        emkSurayng2.SetDataValue(0);
                        for (int i = 0; i < grdDirectDetail.RowCount; i++)
                        {
                            if (grdDirectDetail.GetItemString(i, "time_gubun").Equals("1"))
                            {
                                delHCode = grdDirectDetail.GetItemString(i, "hangmog_code");
                                delSeq = grdDirectDetail.GetItemString(i, "seq");

                                grdDirectDetail.DeleteRow(i);
                                i--;

                                for (int j = 0; j < grdOriginDirectDetail.RowCount; j++)
                                {
                                    if (delHCode.Equals(grdOriginDirectDetail.GetItemString(j, "hangmog_code")) &&
                                       delSeq.Equals(grdOriginDirectDetail.GetItemString(j, "seq")) &&
                                       grdOriginDirectDetail.GetItemString(j, "time_gubun").Equals("1"))
                                    {
                                        grdOriginDirectDetail.DeleteRow(j);
                                        j--;
                                    }
                                }
                            }
                        }
                        grdDirectDetail.AcceptData();
                    }
                    break;

                case "cboHangmog_code3":
                    if (cboHangmog_code3.SelectedIndex > 0)
                    {
                        emkSurayng3.Enabled = true;
                        vsbSurayng3.Enabled = true;

                        //for (int i = 0; i < grdDirectDetail.RowCount; i++)
                        //{
                        //    if (grdDirectDetail.GetItemString(i, "time_gubun").Equals("2"))
                        //    {
                        //        delHCode = grdDirectDetail.GetItemString(i, "hangmog_code");
                        //        delSeq = grdDirectDetail.GetItemString(i, "seq");

                        //        grdDirectDetail.DeleteRow(i);
                        //        i--;

                        //        for (int j = 0; j < grdOriginDirectDetail.RowCount; j++)
                        //        {
                        //            if (delHCode.Equals(grdOriginDirectDetail.GetItemString(j, "hangmog_code")) &&
                        //               delSeq.Equals(grdOriginDirectDetail.GetItemString(j, "seq")) &&
                        //               grdOriginDirectDetail.GetItemString(j, "time_gubun").Equals("2"))
                        //            {
                        //                grdOriginDirectDetail.DeleteRow(j);
                        //                j--;
                        //            }
                        //        }
                        //    }
                        //}
                        //grdDirectDetail.AcceptData();
                        //insertRow = grdDirectDetail.InsertRow(-1);

                        //grdDirectDetail.SetItemValue(insertRow, "bunho",        grdDirectData.GetItemString(0, "bunho"));
                        //grdDirectDetail.SetItemValue(insertRow, "fkinp1001",    grdDirectData.GetItemString(0, "fkinp1001"));
                        //grdDirectDetail.SetItemValue(insertRow, "order_date",   grdDirectData.GetItemString(0, "order_date"));
                        //grdDirectDetail.SetItemValue(insertRow, "input_gubun",  grdDirectData.GetItemString(0, "input_gubun"));
                        //grdDirectDetail.SetItemValue(insertRow, "direct_gubun", grdDirectData.GetItemString(0, "direct_gubun"));
                        //grdDirectDetail.SetItemValue(insertRow, "direct_code",  grdDirectData.GetItemString(0, "direct_code"));
                        //grdDirectDetail.SetItemValue(insertRow, "pk_seq",       grdDirectData.GetItemString(0, "pk_seq"));
                        //grdDirectDetail.SetItemValue(insertRow, "seq",          LoadDetailKey());
                        //grdDirectDetail.SetItemValue(insertRow, "time_gubun", "2"); // 조주석침구분 2 : 저녁
                        //grdDirectDetail.SetItemValue(insertRow, "hangmog_code", cboHangmog_code3.GetDataValue());
                        //grdDirectDetail.SetItemValue(insertRow, "fkocs2005",    grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "pkocs2005"));
                        
                        //// CP Detail Insert
                        //grdDirectDetail.SetItemValue(insertRow, "memb",         grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "memb"));
                        //grdDirectDetail.SetItemValue(insertRow, "memb_gubun",   grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "memb_gubun"));
                        //grdDirectDetail.SetItemValue(insertRow, "cp_code",      grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "cp_code"));
                        //grdDirectDetail.SetItemValue(insertRow, "cp_path_code", grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "cp_path_code"));
                        //grdDirectDetail.SetItemValue(insertRow, "jaewonil",     grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "jaewonil"));
                        //grdDirectDetail.SetItemValue(insertRow, "fkocs6005",    grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "pkocs6005"));
                        //grdDirectDetail.SetItemValue(insertRow, "fkocs6010",    grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "fkocs6010"));
                        //grdDirectDetail.SetItemValue(insertRow, "fkocs6015",    grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "pkocs6015"));
                        isRow = false;
                        if (grdDirectDetail.RowCount > 0)
                        {
                            for (int i = 0; i < grdDirectDetail.RowCount; i++)
                            {
                                if (grdDirectDetail.GetItemString(i, "time_gubun").Equals("2"))
                                {
                                    isRow = true;
                                    if (grdDirectDetail.GetItemString(i, "hangmog_code") != cboHangmog_code3.GetDataValue())
                                        grdDirectDetail.SetItemValue(i, "hangmog_code", cboHangmog_code3.GetDataValue());
                                }
                            }
                        }

                        if (grdDirectDetail.RowCount == 0 || !isRow)
                        {
                            grdDirectDetail.AcceptData();
                            // 20121201
                            insertRow = grdDirectDetail.InsertRow(-1);

                            grdDirectDetail.SetItemValue(insertRow, "bunho", grdDirectData.GetItemString(0, "bunho"));
                            grdDirectDetail.SetItemValue(insertRow, "fkinp1001", grdDirectData.GetItemString(0, "fkinp1001"));
                            grdDirectDetail.SetItemValue(insertRow, "order_date", grdDirectData.GetItemString(0, "order_date"));
                            grdDirectDetail.SetItemValue(insertRow, "input_gubun", grdDirectData.GetItemString(0, "input_gubun"));
                            grdDirectDetail.SetItemValue(insertRow, "direct_gubun", grdDirectData.GetItemString(0, "direct_gubun"));
                            grdDirectDetail.SetItemValue(insertRow, "direct_code", grdDirectData.GetItemString(0, "direct_code"));
                            grdDirectDetail.SetItemValue(insertRow, "pk_seq", grdDirectData.GetItemString(0, "pk_seq"));
                            grdDirectDetail.SetItemValue(insertRow, "seq", LoadDetailKey());
                            grdDirectDetail.SetItemValue(insertRow, "time_gubun", "2"); // 조주석침구분 0 : 아침
                            grdDirectDetail.SetItemValue(insertRow, "hangmog_code", cboHangmog_code3.GetDataValue());
                            grdDirectDetail.SetItemValue(insertRow, "fkocs2005", grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "pkocs2005"));

                            // CP Detail Insert
                            grdDirectDetail.SetItemValue(insertRow, "memb", grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "memb"));
                            grdDirectDetail.SetItemValue(insertRow, "memb_gubun", grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "memb_gubun"));
                            grdDirectDetail.SetItemValue(insertRow, "cp_code", grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "cp_code"));
                            grdDirectDetail.SetItemValue(insertRow, "cp_path_code", grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "cp_path_code"));
                            grdDirectDetail.SetItemValue(insertRow, "jaewonil", grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "jaewonil"));
                            grdDirectDetail.SetItemValue(insertRow, "fkocs6005", grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "pkocs6005"));
                            grdDirectDetail.SetItemValue(insertRow, "fkocs6010", grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "fkocs6010"));
                            grdDirectDetail.SetItemValue(insertRow, "fkocs6015", grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "pkocs6015"));
                        }
                    }
                    else
                    {
                        emkSurayng3.Enabled = false;
                        vsbSurayng3.Enabled = false;
                        emkSurayng3.SetDataValue(0);
                        for (int i = 0; i < grdDirectDetail.RowCount; i++)
                        {
                            if (grdDirectDetail.GetItemString(i, "time_gubun").Equals("2"))
                            {
                                delHCode = grdDirectDetail.GetItemString(i, "hangmog_code");
                                delSeq = grdDirectDetail.GetItemString(i, "seq");

                                grdDirectDetail.DeleteRow(i);
                                i--;

                                for (int j = 0; j < grdOriginDirectDetail.RowCount; j++)
                                {
                                    if (delHCode.Equals(grdOriginDirectDetail.GetItemString(j, "hangmog_code")) &&
                                       delSeq.Equals(grdOriginDirectDetail.GetItemString(j, "seq")) &&
                                       grdOriginDirectDetail.GetItemString(j, "time_gubun").Equals("2"))
                                    {
                                        grdOriginDirectDetail.DeleteRow(j);
                                        j--;
                                    }
                                }
                            }
                        }
                        grdDirectDetail.AcceptData();
                    }
                    break;

                case "cboHangmog_code4":
                    if (cboHangmog_code4.SelectedIndex > 0)
                    {
                        emkSurayng4.Enabled = true;
                        vsbSurayng4.Enabled = true;

                        //for (int i = 0; i < grdDirectDetail.RowCount; i++)
                        //{
                        //    if (grdDirectDetail.GetItemString(i, "time_gubun").Equals("3"))
                        //    {
                        //        delHCode = grdDirectDetail.GetItemString(i, "hangmog_code");
                        //        delSeq = grdDirectDetail.GetItemString(i, "seq");

                        //        grdDirectDetail.DeleteRow(i);
                        //        i--;

                        //        for (int j = 0; j < grdOriginDirectDetail.RowCount; j++)
                        //        {
                        //            if (delHCode.Equals(grdOriginDirectDetail.GetItemString(j, "hangmog_code")) &&
                        //               delSeq.Equals(grdOriginDirectDetail.GetItemString(j, "seq")) &&
                        //               grdOriginDirectDetail.GetItemString(j, "time_gubun").Equals("3"))
                        //            {
                        //                grdOriginDirectDetail.DeleteRow(j);
                        //                j--;
                        //            }
                        //        }
                        //    }
                        //}
                        //grdDirectDetail.AcceptData();
                        //insertRow = grdDirectDetail.InsertRow(-1);

                        //grdDirectDetail.SetItemValue(insertRow, "bunho",        grdDirectData.GetItemString(0, "bunho"));
                        //grdDirectDetail.SetItemValue(insertRow, "fkinp1001",    grdDirectData.GetItemString(0, "fkinp1001"));
                        //grdDirectDetail.SetItemValue(insertRow, "order_date",   grdDirectData.GetItemString(0, "order_date"));
                        //grdDirectDetail.SetItemValue(insertRow, "input_gubun",  grdDirectData.GetItemString(0, "input_gubun"));
                        //grdDirectDetail.SetItemValue(insertRow, "direct_gubun", grdDirectData.GetItemString(0, "direct_gubun"));
                        //grdDirectDetail.SetItemValue(insertRow, "direct_code",  grdDirectData.GetItemString(0, "direct_code"));
                        //grdDirectDetail.SetItemValue(insertRow, "pk_seq",       grdDirectData.GetItemString(0, "pk_seq"));
                        //grdDirectDetail.SetItemValue(insertRow, "seq",          LoadDetailKey());
                        //grdDirectDetail.SetItemValue(insertRow, "time_gubun", "3"); // 조주석침구분 3 : 취침
                        //grdDirectDetail.SetItemValue(insertRow, "hangmog_code", cboHangmog_code4.GetDataValue());
                        //grdDirectDetail.SetItemValue(insertRow, "fkocs2005",    grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "pkocs2005"));
                        
                        //// CP Detail Insert
                        //grdDirectDetail.SetItemValue(insertRow, "memb",         grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "memb"));
                        //grdDirectDetail.SetItemValue(insertRow, "memb_gubun",   grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "memb_gubun"));
                        //grdDirectDetail.SetItemValue(insertRow, "cp_code",      grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "cp_code"));
                        //grdDirectDetail.SetItemValue(insertRow, "cp_path_code", grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "cp_path_code"));
                        //grdDirectDetail.SetItemValue(insertRow, "jaewonil",     grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "jaewonil"));
                        //grdDirectDetail.SetItemValue(insertRow, "fkocs6005",    grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "pkocs6005"));
                        //grdDirectDetail.SetItemValue(insertRow, "fkocs6010",    grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "fkocs6010"));
                        //grdDirectDetail.SetItemValue(insertRow, "fkocs6015",    grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "pkocs6015"));
                        isRow = false;
                        if (grdDirectDetail.RowCount > 0)
                        {
                            for (int i = 0; i < grdDirectDetail.RowCount; i++)
                            {
                                if (grdDirectDetail.GetItemString(i, "time_gubun").Equals("3"))
                                {
                                    isRow = true;
                                    if (grdDirectDetail.GetItemString(i, "hangmog_code") != cboHangmog_code4.GetDataValue())
                                        grdDirectDetail.SetItemValue(i, "hangmog_code", cboHangmog_code4.GetDataValue());
                                }
                            }
                        }

                        if (grdDirectDetail.RowCount == 0 || !isRow)
                        {
                            grdDirectDetail.AcceptData();
                            // 20121201
                            insertRow = grdDirectDetail.InsertRow(-1);

                            grdDirectDetail.SetItemValue(insertRow, "bunho", grdDirectData.GetItemString(0, "bunho"));
                            grdDirectDetail.SetItemValue(insertRow, "fkinp1001", grdDirectData.GetItemString(0, "fkinp1001"));
                            grdDirectDetail.SetItemValue(insertRow, "order_date", grdDirectData.GetItemString(0, "order_date"));
                            grdDirectDetail.SetItemValue(insertRow, "input_gubun", grdDirectData.GetItemString(0, "input_gubun"));
                            grdDirectDetail.SetItemValue(insertRow, "direct_gubun", grdDirectData.GetItemString(0, "direct_gubun"));
                            grdDirectDetail.SetItemValue(insertRow, "direct_code", grdDirectData.GetItemString(0, "direct_code"));
                            grdDirectDetail.SetItemValue(insertRow, "pk_seq", grdDirectData.GetItemString(0, "pk_seq"));
                            grdDirectDetail.SetItemValue(insertRow, "seq", LoadDetailKey());
                            grdDirectDetail.SetItemValue(insertRow, "time_gubun", "3"); // 조주석침구분 0 : 아침
                            grdDirectDetail.SetItemValue(insertRow, "hangmog_code", cboHangmog_code4.GetDataValue());
                            grdDirectDetail.SetItemValue(insertRow, "fkocs2005", grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "pkocs2005"));

                            // CP Detail Insert
                            grdDirectDetail.SetItemValue(insertRow, "memb", grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "memb"));
                            grdDirectDetail.SetItemValue(insertRow, "memb_gubun", grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "memb_gubun"));
                            grdDirectDetail.SetItemValue(insertRow, "cp_code", grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "cp_code"));
                            grdDirectDetail.SetItemValue(insertRow, "cp_path_code", grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "cp_path_code"));
                            grdDirectDetail.SetItemValue(insertRow, "jaewonil", grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "jaewonil"));
                            grdDirectDetail.SetItemValue(insertRow, "fkocs6005", grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "pkocs6005"));
                            grdDirectDetail.SetItemValue(insertRow, "fkocs6010", grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "fkocs6010"));
                            grdDirectDetail.SetItemValue(insertRow, "fkocs6015", grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "pkocs6015"));
                        }
                    }
                    else
                    {
                        emkSurayng4.Enabled = false;
                        vsbSurayng4.Enabled = false;
                        emkSurayng4.SetDataValue(0);
                        for (int i = 0; i < grdDirectDetail.RowCount; i++)
                        {
                            if (grdDirectDetail.GetItemString(i, "time_gubun").Equals("3"))
                            {
                                delHCode = grdDirectDetail.GetItemString(i, "hangmog_code");
                                delSeq = grdDirectDetail.GetItemString(i, "seq");

                                grdDirectDetail.DeleteRow(i);
                                i--;

                                for (int j = 0; j < grdOriginDirectDetail.RowCount; j++)
                                {
                                    if (delHCode.Equals(grdOriginDirectDetail.GetItemString(j, "hangmog_code")) &&
                                       delSeq.Equals(grdOriginDirectDetail.GetItemString(j, "seq")) &&
                                       grdOriginDirectDetail.GetItemString(j, "time_gubun").Equals("3"))
                                    {
                                        grdOriginDirectDetail.DeleteRow(j);
                                        j--;
                                    }
                                }
                            }
                        }
                        grdDirectDetail.AcceptData();
                    }
                    break;
            }

            Detail_3_Create_text();
        }

        private void emkNum_val_DataValidating(object sender, DataValidatingEventArgs e)
        {
            XEditMask vsb = sender as XEditMask;

            if (e.DataValue == "")
                vsb.Text = "0";

            for (int i = 0; i < grdDirectDetail.RowCount; i++)
            {
                if(vsb.Tag.ToString().Equals(grdDirectDetail.GetItemString(i, "time_gubun")))
                {
                    grdDirectDetail.SetItemValue(i, "suryang", TypeCheck.NVL(e.DataValue, "0"));
                }
            }

            Detail_3_Create_text();
        }

        private void emkJaewon_to_il_DataValidating(object sender, DataValidatingEventArgs e)
        {
            grdDirectData.SetItemValue(grdDirectData.CurrentRowNumber, "jaewonil_to", TypeCheck.NVL(emkJaewon_to_il.GetDataValue(), 0));
        }

        private void vsbJaewon_to_il_Scroll(object sender, ScrollEventArgs e)
        {
            VScrollBar vsb = sender as VScrollBar;

            string colName = vsb.Name.Substring(3).ToLower();

            double incrementValue = 1;
            double maxIncrement = 999;
            double controlValue = 0;

            switch (e.Type)
            {
                case System.Windows.Forms.ScrollEventType.LargeIncrement:
                case System.Windows.Forms.ScrollEventType.SmallIncrement:

                    controlValue = Convert.ToInt32(emkJaewon_to_il.GetDataValue() == "" ? "0" : emkJaewon_to_il.GetDataValue());
                    controlValue = controlValue - incrementValue;

                    if (controlValue < 0) controlValue = 0;

                    emkJaewon_to_il.SetDataValue(controlValue);
                    grdDirectData.SetItemValue(grdDirectData.CurrentRowNumber, "jaewonil_to", controlValue.ToString());

                    break;
                case System.Windows.Forms.ScrollEventType.LargeDecrement:
                case System.Windows.Forms.ScrollEventType.SmallDecrement:

                    controlValue = Convert.ToInt32(emkJaewon_to_il.GetDataValue() == "" ? "0" : emkJaewon_to_il.GetDataValue());
                    controlValue = controlValue + incrementValue;

                    if (controlValue >= maxIncrement) controlValue = 0;

                    emkJaewon_to_il.SetDataValue(controlValue);
                    grdDirectData.SetItemValue(grdDirectData.CurrentRowNumber, "jaewonil_to", controlValue.ToString());

                    break;
            }

            if (pnlDetail_2.Visible) this.Detail_2_Create_text();
            if (pnlDetail_3.Visible) this.Detail_3_Create_text();
        }

        #endregion
        private void deleteBrankRow(XEditGrid grd, string mColumnName)
        {
            for (int i = 0; i < grd.RowCount; i++)
            {
                if (grd.GetItemString(i, mColumnName) == "")
                    grd.DeleteRow(i);
            }

        }

        #region [Button List Event]

        private void xButtonList_ButtonClick(object sender, ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Insert:

                    e.IsBaseCall = false;

                    if (tvwDirectInfo.SelectedNode.SelectedImageIndex == 0)
                    {
                        this.InsertDirectData(this.tvwDirectInfo.SelectedNode);
                    }

                    break;

                case FunctionType.Delete:

                    e.IsBaseCall = false;

                    this.DeleteDirectData();

                    break;

                case FunctionType.Update:

                    e.IsBaseCall = false;

                    #region 체크전 데이터 확인 ( 빈로우, 빈그룹 삭제 )

                    this.deleteBrankRow(this.grdDirectDetail, "pk_seq");
                    this.deleteBrankRow(this.grdDetail_2, "insulin_from");

                    #endregion


                    if (this.tvwDirectInfo.SelectedNode != null)
                    {
                        //if (!ValidationCheck())
                        //    return;

                        string direct_gubun = this.tvwDirectInfo.SelectedNode.Tag.ToString().Split('|')[0];
                        string direct_code = this.tvwDirectInfo.SelectedNode.Tag.ToString().Split('|')[1];

                        ApplyDirectData(direct_gubun, direct_code);
                    }

                    ReturnValue();

                    this.Close();

                    break;

                default:

                    break;
            }
        }

        #endregion

        private bool ValidationCheck()
        {
            string cmd = @"SELECT FN_OCSI_GET_JISI_ORDER_GUBUN(:f_hosp_code, :f_nur_gr_code) FROM SYS.DUAL";

            BindVarCollection bind = new BindVarCollection();
            bind.Add("f_hosp_code", EnvironInfo.HospCode);
            
            for (int j = 0; j < grdDirectDetail.RowCount; j++)
            {
                bind.Add("f_nur_gr_code", grdDirectData.GetItemString(j, "direct_gubun"));
                object jisi_order_gubun = Service.ExecuteScalar(cmd, bind);

                if (jisi_order_gubun.ToString() != "" && jisi_order_gubun.ToString() == "5") // 薬、注射の場合
                {
                    if (   TypeCheck.IsNull(this.grdDirectDetail.GetItemString(j, "suryang"))
                        || TypeCheck.IsNull(this.grdDirectDetail.GetItemString(j, "danui"))
                        || TypeCheck.IsNull(this.grdDirectDetail.GetItemString(j, "dv_time"))
                        || TypeCheck.IsNull(this.grdDirectDetail.GetItemString(j, "dv"))
                        || TypeCheck.IsNull(this.grdDirectDetail.GetItemString(j, "nalsu"))
                        || (TypeCheck.IsNull(this.grdDirectDetail.GetItemString(j, "jusa_code")) && TypeCheck.IsNull(this.grdDirectDetail.GetItemString(j, "bogyong_code"))))
                    {
                        XMessageBox.Show("入力情報が足りません。ご確認ください。");
                        return false;
                    }
                }
            }
            
            return true;
        }

        #region [Button Click Event]

        private void btnCnt_perhour_Click(object sender, EventArgs e)
        {
            string direct_text = "";
            if (!txtDirect_text.ReadOnly)
                direct_text = txtDirect_text.GetDataValue() + " " + emkCnt_perhour.Text + "時間毎";
            else
                direct_text = emkCnt_perhour.Text + "時間毎";

            txtDirect_text.SetEditValue(direct_text);

            txtDirect_text.Focus();
            txtDirect_text.SelectionStart = txtDirect_text.Text.Length;
        }

        private void btnCnt_perday_Click(object sender, EventArgs e)
        {
            string direct_text = "";
            if (!txtDirect_text.ReadOnly)
                direct_text = txtDirect_text.GetDataValue() + " " + emkCnt_perday.Text + "回/日";
            else
                direct_text = emkCnt_perday.Text + "回/日";

            txtDirect_text.SetEditValue(direct_text);

            txtDirect_text.Focus();
            txtDirect_text.SelectionStart = txtDirect_text.Text.Length;
        }

        private void btnFrench_Click(object sender, EventArgs e)
        {
            string direct_text = "";
            if (!txtDirect_text.ReadOnly)
                direct_text = txtDirect_text.GetDataValue() + " " + emkFrench.Text + "FR";
            else
                direct_text = emkFrench.Text + "FR";

            txtDirect_text.SetEditValue(direct_text);

            txtDirect_text.Focus();
            txtDirect_text.SelectionStart = txtDirect_text.Text.Length;
        }

        private void btnAct_time_Click(object sender, EventArgs e)
        {
            string direct_text = "";
            if (!txtDirect_text.ReadOnly)
                direct_text = txtDirect_text.GetDataValue() + " " + emkAct_time.Text + "実施";
            else
                direct_text = emkAct_time.Text + "実施";

            txtDirect_text.SetEditValue(direct_text);

            txtDirect_text.Focus();
            txtDirect_text.SelectionStart = txtDirect_text.Text.Length;
        }

        private void btnAct_dq_Click(object sender, EventArgs e)
        {
            string direct_text = "";
            if (!txtDirect_text.ReadOnly)
                direct_text = txtDirect_text.GetDataValue();
            else
                direct_text = "";


            if (chkAct_dq1.Checked)
                direct_text = direct_text + " 朝/";

            if (chkAct_dq2.Checked)
                direct_text = direct_text + " 昼/";

            if (chkAct_dq3.Checked)
                direct_text = direct_text + " 夕/";

            if (chkAct_dq4.Checked)
                direct_text = direct_text + " 寝前";

            txtDirect_text.SetEditValue(direct_text);

            txtDirect_text.Focus();
            txtDirect_text.SelectionStart = txtDirect_text.Text.Length;
        }

        private void Detail_2_Create_text()
        {
            string direct_text = "";

            direct_text = direct_text + "==================\r\n【血糖測定間隔】\r\n";

            if (this.btnB.ImageIndex == 1)
                direct_text = direct_text + " 朝 ";
            if (this.btnL.ImageIndex == 1)
                direct_text = direct_text + " 昼 ";
            if (this.btnD.ImageIndex == 1)
                direct_text = direct_text + " 夜 ";
            if (this.btnS.ImageIndex == 1)
                direct_text = direct_text + " 就寝前 ";
            if (this.txtETC.Text != "")
                direct_text = direct_text + " " +this.txtETC.Text;

            direct_text = direct_text + "\r\n";
            
            if (grdDetail_2.RowCount > 0)
            {
                direct_text = direct_text + "==================\r\n【基準単位(血糖)】\r\n";

                for (int i = 0; i < grdDetail_2.RowCount; i++)
                {
                    if (!TypeCheck.IsNull(grdDetail_2.GetItemString(i, "insulin_from")))
                    {
                        direct_text = direct_text + grdDetail_2.GetItemString(i, "insulin_from").PadRight(5) + "~ "
                            + grdDetail_2.GetItemString(i, "insulin_to").PadRight(5) + " ： "
                            + grdDetail_2.GetItemString(i, "suryang").PadLeft(2) + "単位sc \r\n";

                    }

                }

                direct_text = direct_text + "==================\r\n";
            }

            if (cboHangmog_code.SelectedIndex > 0)
                direct_text = direct_text + cboHangmog_code.Text;

            if (pnlDetail_2.Visible)
            {
                txtDirect_text.SetEditValue(direct_text);

                for (int i = 0; i < grdDetail_2.RowCount; i++)
                {
                    grdDirectDetail.SetItemValue(i, "hangmog_code", cboHangmog_code.GetDataValue());
                    grdDirectDetail.SetItemValue(i, "insulin_from", grdDetail_2.GetItemValue(i, "insulin_from"));
                    grdDirectDetail.SetItemValue(i, "insulin_to", grdDetail_2.GetItemValue(i, "insulin_to"));
                    grdDirectDetail.SetItemValue(i, "suryang", grdDetail_2.GetItemValue(i, "suryang"));

                    grdDirectDetail.SetItemValue(i, "seq", grdDetail_2.GetItemValue(i, "seq"));

                    grdDirectDetail.SetItemValue(i, "pk_seq", grdDetail_2.GetItemValue(i, "pk_seq"));
                    grdDirectDetail.SetItemValue(i, "time_gubun", grdDetail_2.GetItemValue(i, "time_gubun"));

                    //grdDirectData.SetItemValue(i, "direct_text", direct_text);
                }
            }
        }

        private void Detail_3_Create_text()
        {
            string direct_text = "";

            if (cboHangmog_code1.SelectedIndex > 0)
            {
                direct_text = direct_text + "朝/" + cboHangmog_code1.Text + "『 " + emkSurayng1.GetDataValue() + "単位sc 』\r\n";

                for (int i = 0; i < grdDirectDetail.RowCount; i++)
                {
                    if (grdDirectDetail.GetItemString(i, "time_gubun").Equals("0"))
                    {
                        grdDirectDetail.SetItemValue(i, "hangmog_code", cboHangmog_code1.SelectedValue.ToString());
                        grdDirectDetail.SetItemValue(i, "suryang", emkSurayng1.GetDataValue());
                    }
                }
            }

            if (cboHangmog_code2.SelectedIndex > 0)
            {
                direct_text = direct_text + "昼/" + cboHangmog_code2.Text + "『 " + emkSurayng2.GetDataValue() + "単位sc 』\r\n";

                for (int i = 0; i < grdDirectDetail.RowCount; i++)
                {
                    if (grdDirectDetail.GetItemString(i, "time_gubun").Equals("1"))
                    {
                        grdDirectDetail.SetItemValue(i, "hangmog_code", cboHangmog_code2.SelectedValue.ToString());
                        grdDirectDetail.SetItemValue(i, "suryang", emkSurayng2.GetDataValue());
                    }
                }
            }

            if (cboHangmog_code3.SelectedIndex > 0)
            {
                direct_text = direct_text + "夕/" + cboHangmog_code3.Text + "『 " + emkSurayng3.GetDataValue() + "単位sc 』\r\n";

                for (int i = 0; i < grdDirectDetail.RowCount; i++)
                {
                    if (grdDirectDetail.GetItemString(i, "time_gubun").Equals("2"))
                    {
                        grdDirectDetail.SetItemValue(i, "hangmog_code", cboHangmog_code3.SelectedValue.ToString());
                        grdDirectDetail.SetItemValue(i, "suryang", emkSurayng3.GetDataValue());
                    }
                }
            }

            if (cboHangmog_code4.SelectedIndex > 0)
            {
                direct_text = direct_text + "眠前/" + cboHangmog_code4.Text + "『 " + emkSurayng4.GetDataValue() + "単位sc 』\r\n";

                for (int i = 0; i < grdDirectDetail.RowCount; i++)
                {
                    if (grdDirectDetail.GetItemString(i, "time_gubun").Equals("3"))
                    {
                        grdDirectDetail.SetItemValue(i, "hangmog_code", cboHangmog_code4.SelectedValue.ToString());
                        grdDirectDetail.SetItemValue(i, "suryang", emkSurayng4.GetDataValue());
                    }
                }
            }

            txtDirect_text.SetEditValue(direct_text);

        }

        #endregion

        #region [TreeView Event]

        string jisi_order_gubun = "";
        private void tvwDirectInfo_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.grdDirectData.Reset();
            this.grdDirectDetail.Reset();
            this.ClearControlAll();

            string direct_gubun = e.Node.Tag.ToString().Split('|')[0];
            string direct_code  = e.Node.Tag.ToString().Split('|')[1];
            jisi_order_gubun = "";
            string jisi_continue_yn = "";

            string setDate = "";
            if (mDirectMode == "1") setDate = mPlan_order_date;         // 0 : CP 기준정보, 1 : CP 적용
            else if (mDirectMode.Equals("2")) setDate = mOrder_date;    // 2 : 일반지시사항

            foreach (DataRow row in dloDirectInfo.LayoutTable.Rows)
            {
                if (row["nur_gr_code"].ToString() == direct_gubun && row["nur_md_code"].ToString() == direct_code)
                {
                    jisi_order_gubun = row["jisi_order_gubun"].ToString();
                    jisi_continue_yn = row["jisi_continue_yn"].ToString();
                    break;
                }
            }

            grdNUR0112.Height = 315;
            grdNUR0114.Height = 315;
            pnlDetail_2.Visible = false;
            pnlDetail_3.Visible = false;
            pnlDirect.Visible = false;
            grdNUR0115.Visible = false;
            btnModify.Visible = false;
            lblOrder.Visible = false;
            //grdOCS2006.Visible = false;
            grdNUR0115_2.Visible = false;
            //grdOCS2006_2.Visible = false;
            pnlSiksa.Visible = false;

            switch (jisi_order_gubun)
            {
                case "0": // 일반
                    this.pnlDirect.Visible = true;
                    btnModify_4.Visible = true;
                    btnModify.Visible = false;
                    break;

                case "1": // 인슐린 스케쥴
                    this.pnlDetail_2.Visible = true;
                    SetInputControl("a");
                    break;

                case "2": // 인슐린
                    this.pnlDetail_3.Visible = true;
                    SetInputControl("a");
                    break;

                case "3": // 산소
                    grdNUR0112.Height = 158;
                    grdNUR0114.Height = 158;
                    grdNUR0115.Visible = true;
                    btnModify.Visible = true;
                    btnModify_4.Visible = false;
                    lblOrder.Visible = true;
                    //grdOCS2006.Visible = true;
                    this.pnlDirect.Visible = true;
                    SetInputControl("c");
                    break;

                case "4": // 인공호흡
                    grdNUR0112.Height = 158;
                    grdNUR0114.Height = 158;
                    grdNUR0115_2.Visible = true;
                    btnModify.Visible = true;
                    btnModify_4.Visible = false;
                    lblOrder.Visible = true;
                    //grdOCS2006_2.Visible = true;
                    this.pnlDirect.Visible = true;
                    SetInputControl("d");
                    break;

                case "5": // 약
                    grdNUR0112.Height = 158;
                    grdNUR0114.Height = 158;
                    grdNUR0115.Visible = true;
                    btnModify.Visible = true;
                    btnModify_4.Visible = false;
                    lblOrder.Visible = true;
                    //grdOCS2006.Visible = true;
                    this.pnlDirect.Visible = true;
                    SetInputControl("e");
                    break;

                case "6": // 처치
                    grdNUR0112.Height = 158;
                    grdNUR0114.Height = 158;
                    grdNUR0115_2.Visible = true;
                    btnModify.Visible = true;
                    btnModify_4.Visible = false;
                    lblOrder.Visible = true;
                    //grdOCS2006_2.Visible = true;
                    this.pnlDirect.Visible = true;
                    SetInputControl("f");
                    break;

                case "7": // 식사. 입원, 재원 구분 없음
                case "8":
                    grdNUR0112.Height = 158;
                    grdNUR0114.Height = 158;
                    //this.pnlSiksa.Visible = true;
                    this.pnlDirect.Visible = true;
                    btnModify.Visible = false;
                    btnModify_4.Visible = true;
                    
                    break;

                case "9": // 生理検査
                    grdNUR0112.Height = 158;
                    grdNUR0114.Height = 158;
                    grdNUR0115_2.Visible = true;
                    btnModify.Visible = true;
                    btnModify_4.Visible = false;
                    lblOrder.Visible = true;
                    this.pnlDirect.Visible = true;
                    SetInputControl("h");
                    break;
                default:
                    this.pnlDirect.Visible = true;
                    break;

            }

            dpkPlan_from_date.SetDataValue(setDate);
            dpkPlan_to_date.ResetData();

            LoadDirect_cont(direct_gubun, direct_code);

            // grdOriginDirectData
            foreach (DataRow row in grdOriginDirectData.LayoutTable.Select(" direct_gubun = '" + direct_gubun + "' and direct_code = '" + direct_code + "'  ", " drt_from_date ASC"))
            {
                grdDirectData.LayoutTable.ImportRow(row);
            }

            grdDirectData.DisplayData();
            dpkPlan_to_date.ResetData();

            if (jisi_continue_yn == "N") pnlFromTo.Visible = false;
            else if (jisi_continue_yn == "Y") pnlFromTo.Visible = true;
            
            // jisi_continue_yn 의 체크 여부에 따라 디폴트 셋팅. 계속 체크나 지시완료일은 둘 중 하나는 체크되어 있어야 한다.
            // 계속 체크를 풀면 오더일(지시개시일)을 셋팅. 기본 셋팅은 계속을 체크
            if (grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "drt_to_date") == "")
            {
                dpkPlan_to_date.ResetData();
                //dpkPlan_to_date.Enabled = false;
                chkContinue_yn.Checked = true;
            }
            else if(grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "drt_to_date") != "")
            {
                //dpkPlan_to_date.Enabled = true;
                dpkPlan_to_date.SetDataValue(TypeCheck.NVL(grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "drt_to_date"), setDate));
                chkContinue_yn.Checked = false;
            }

            //if (grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "drt_from_date") != "")
            //{
            //    dpkPlan_from_date.SetDataValue(TypeCheck.NVL(grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "drt_from_date"), setDate));
            //}


            // grdOriginDirect[ Detail ]
            int curRow = 0;
            foreach (DataRow row in grdOriginDirectDetail.LayoutTable.Select(" direct_gubun = '" + direct_gubun + "' and direct_code = '" + direct_code + "'  ", " seq ASC"))
            {
                grdDirectDetail.LayoutTable.ImportRow(row);
                grdDirectDetail.DisplayData();


                LoadData(curRow, "D");
                curRow++;
            }

            if (this.grdNUR0115.Visible == true)
            {
                if (grdDirectDetail.RowCount == 0)
                {
                    this.grdNUR0115.Enabled = true;
                }
                else
                {
                    for (int i = 0; i < grdNUR0115.RowCount; i++)
                    {
                        string hangmog_code = grdNUR0115.GetItemString(i, "hangmog_code");
                        for (int j = 0; j < grdDirectDetail.RowCount; j++)
                        {
                            if (   hangmog_code == grdDirectDetail.GetItemString(j, "hangmog_code")
                                && this.mSelectInput == grdDirectDetail.GetItemString(j, "input_gubun"))
                            {
                                foreach (XEditGridCell info in this.grdDirectDetail.CellInfos)
                                {
                                    if (this.grdNUR0115.CellInfos.Contains(info.CellName))
                                    {
                                        if (this.grdDirectDetail.GetItemString(j, info.CellName) != "")
                                            this.grdNUR0115.SetItemValue(i, info.CellName, this.grdDirectDetail.GetItemString(j, info.CellName));
                                    }
                                }
                                grdNUR0115.SetItemValue(i, "select_order", "Y");

                                grdNUR0115.LayoutTable.Rows[i].RejectChanges();

                            }
                        }
                    }

                    for (int i = 0; i < grdDirectDetail.RowCount; i++)
                    {
                        if (   this.grdDirectDetail.GetRowState(i) != DataRowState.Added
                            && mSelectInput == grdDirectDetail.GetItemString(i, "input_gubun"))
                        {
                            this.grdNUR0115.Enabled = false;
                            break;
                        }
                    }
                }

                //if (grdDirectDetail.RowCount > 0)
                //{
                //    for (int i = 0; i < grdNUR0115.RowCount; i++)
                //    {
                //        string hangmog_code = grdNUR0115.GetItemString(i, "hangmog_code");
                //        for (int j = 0; j < grdDirectDetail.RowCount; j++)
                //        {
                //            if (hangmog_code == grdDirectDetail.GetItemString(j, "hangmog_code"))
                //            {
                //                grdNUR0115.SetItemValue(i, "select_order", "Y");
                //            }
                //        }
                //    }
                //    this.grdNUR0115.Enabled = false;
                //}
            }

            if (this.grdNUR0115_2.Visible == true)
            {
                if (grdDirectDetail.RowCount == 0)
                {
                    this.grdNUR0115_2.Enabled = true;
                }
                else
                {
                    for (int i = 0; i < grdNUR0115_2.RowCount; i++)
                    {
                        string hangmog_code = grdNUR0115_2.GetItemString(i, "hangmog_code");
                        for (int j = 0; j < grdDirectDetail.RowCount; j++)
                        {
                            if (   hangmog_code == grdDirectDetail.GetItemString(j, "hangmog_code")
                                && mSelectInput == grdDirectDetail.GetItemString(j, "input_gubun"))
                            {
                                foreach (XEditGridCell info in this.grdDirectDetail.CellInfos)
                                {
                                    if (this.grdNUR0115_2.CellInfos.Contains(info.CellName))
                                    {
                                        if (this.grdDirectDetail.GetItemString(j, info.CellName) != "")
                                            this.grdNUR0115_2.SetItemValue(i, info.CellName, this.grdDirectDetail.GetItemString(j, info.CellName));
                                    }
                                }
                                grdNUR0115_2.SetItemValue(i, "select_order", "Y");
                                grdNUR0115_2.LayoutTable.Rows[i].RejectChanges();

                            }
                        }
                    }

                    for (int i = 0; i < grdDirectDetail.RowCount; i++)
                    {
                        if (   this.grdDirectDetail.GetRowState(i) != DataRowState.Added
                            && mSelectInput == grdDirectDetail.GetItemString(i, "input_gubun"))
                        {
                            this.grdNUR0115_2.Enabled = false;
                            break;
                        }
                    }
                }
            }

            if (this.pnlDetail_2.Visible == true)
            {
                if (grdDirectDetail.RowCount == 0)
                {
                    this.pnlDetail_2_sub.Enabled = true;
                }
                else
                {
                    for (int i = 0; i < grdDirectDetail.RowCount; i++)
                    {
                        if (this.grdDirectDetail.GetRowState(i) != DataRowState.Added)
                        {
                            this.pnlDetail_2_sub.Enabled = false;
                            break;
                        }
                    }
                }
            }

            if (this.pnlDetail_3.Visible == true)
            {
                if (grdDirectDetail.RowCount == 0)
                {
                    this.pnlDetail_3_sub.Enabled = true;
                }
                else
                {
                    for (int i = 0; i < grdDirectDetail.RowCount; i++)
                    {
                        if (this.grdDirectDetail.GetRowState(i) != DataRowState.Added)
                        {
                            this.pnlDetail_3_sub.Enabled = false;
                            break;
                        }
                    }
                }
            }

            if (jisi_order_gubun == "0")
            {
                if (grdDirectData.RowCount == 0)
                {
                    this.pnlDirect_sub.Enabled = true;
                }
                else
                {
                    for (int i = 0; i < grdDirectData.RowCount; i++)
                    {
                        if (this.grdDirectData.GetRowState(i) != DataRowState.Added)
                        {
                            this.pnlDirect_sub.Enabled = false;
                            break;
                        }
                    }
                }

                //if (this.txtDirect_text.Text != "")
                //{
                //    this.pnlDirect_sub.Enabled = false;
                //}
            }

            // 오더항목이 입력된 행을 선택하여 표시한다.
            // 선택된 grdNUR0112의 nur_so_code를 grdDirectDetail 의 direct_detail로 판단
            // input tab 의 구분에 의해 선택될 로우도 구분

            if (grdDirectDetail.RowCount > 0)
            {
                for (int i = 0; i < grdNUR0112.RowCount; i++)
                {
                    string nur0112 = grdNUR0112.GetItemString(i, "nur_so_code");
                    for (int j = 0; j < grdDirectDetail.RowCount; j++)
                    {
                        if (nur0112 == grdDirectDetail.GetItemString(j, "direct_detail") && mSelectInput == grdDirectDetail.GetItemString(j, "input_gubun"))
                        {
                            grdNUR0112.SelectRow(i);
                            //grdNUR0112.
                        }
                    }
                }
            }


            if (grdDirectData.RowCount > 0)
            {
                LockControl(true);
            }
            else
            {
                LockControl(false);
            }

            if (mDirectMode == "0") // CP 기준정보
            {
                if (grdDirectData.RowCount > 0)
                {
                    if (grdDirectData.GetItemString(0, "continue_yn").Equals("Y"))
                    {
                        chkContinue_yn.Checked = true;
                        emkJaewon_to_il.Enabled = false;
                        vsbJaewon_to_il.Enabled = false;
                    }
                    else
                    {
                        chkContinue_yn.Checked = false;
                        emkJaewon_to_il.Enabled = true;
                        vsbJaewon_to_il.Enabled = true;
                    }

                    if (grdDirectData.GetItemString(0, "jaewonil_to") != "")
                    {
                        emkJaewon_to_il.SetDataValue(grdDirectData.GetItemString(0, "jaewonil_to"));
                    }
                }
                else
                {
                    chkContinue_yn.Checked = true;
                    emkJaewon_to_il.ResetData();
                    emkJaewon_to_il.Enabled = false;
                    vsbJaewon_to_il.Enabled = false;
                }
            }

            SetSiksaControlLock("set");
                       
        }

        /// <summary>
        /// 식사 상세지시 컨트롤 활성화 여부
        /// </summary>
        private void SetSiksaControlLock(string setGubun)
        {
            foreach (Control control in pnlSiksa.Controls)
            {
                if (grdDirectData.RowCount > 0)
                {
                    if (control.Name == "emkJusik_Yudong" && grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "direct_cont1") != "06")
                    {
                        control.Enabled = false;
                    }
                    else if (control.Name == "emkBusik_Yudong" && grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "direct_cont2") != "06")
                    {
                        control.Enabled = false;
                    }
                    else
                    {
                        control.Enabled = true;
                    }
                }
                else
                {
                    control.Enabled = false;
                }
            }
        }

        private void tvwDirectInfo_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (preNode == null ) //|| preNode.ImageIndex != 1) 
            {
                preNode = e.Node;
                return;
            }

            string direct_gubun = preNode.Tag.ToString().Split('|')[0];
            string direct_code = preNode.Tag.ToString().Split('|')[1];

            ApplyDirectData(direct_gubun, direct_code);

            preNode = e.Node;
        }

        private void tvwDirectInfo_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                if (tvwDirectInfo.GetNodeAt(new Point(e.X, e.Y)).ImageIndex == 0)
                    this.InsertDirectData(tvwDirectInfo.GetNodeAt(new Point(e.X, e.Y)));
                //else
                //{
                //    this.DeleteDirectData();
                //}
            }
        }

        #endregion

		#region [grdNUR0112 Event]

        private void grdNUR0112_MouseDown(object sender, MouseEventArgs e)
        {
            int curRowIndex = -1;


            /** /
            string direct_text = "";

            curRowIndex = grdNUR0112.GetHitRowNumber(e.Y);
            if (curRowIndex < 0) return;

            int rowIndex = grdDirectData.CurrentRowNumber;
            if (rowIndex > -1) grdDirectData.SetItemValue(rowIndex, "direct_cont1", grdNUR0112.GetItemString(curRowIndex, "nur_so_code"));

            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                switch(jisi_order_gubun)
                {
                    case "3":
                    case "4":
                    case "5":
                    case "6":
                        // 오더발생 지시 입력 폼
                        InputOrderForm frm = new InputOrderForm();

                        frm.TopMost = false;
                        frm.StartPosition = FormStartPosition.CenterParent;

                        frm.LAY_PARENT       = grdDirectData.CopyToLayout();
                        frm.LAY_CHILD        = grdDirectDetail.CopyToLayout();
                        frm.JISI_ORDER_GUBUN = jisi_order_gubun;

                        frm.ShowDialog();
                        break;

                    default:
                        if (!txtDirect_text.ReadOnly && txtDirect_text.Enabled)
                            direct_text = txtDirect_text.GetDataValue() + " " + grdNUR0112.GetItemString(curRowIndex, "nur_so_name");
                        else
                            direct_text = grdNUR0112.GetItemString(curRowIndex, "nur_so_name");

                        txtDirect_text.SetEditValue(direct_text);

                        txtDirect_text.Focus();
                        txtDirect_text.SelectionStart = txtDirect_text.Text.Length;
                        break;
                }
            }
            /**/
            
            /**/
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {


                //if (tvwDirectInfo.SelectedNode.Tag.ToString().Split('|')[0].Equals("02"))
                //{
                //    SiksaSet("grdNUR0112");
                //    return;
                //}



                curRowIndex = grdNUR0112.GetHitRowNumber(e.Y);
                if (curRowIndex < 0) return;

                string direct_text = "";
                if (!txtDirect_text.ReadOnly && txtDirect_text.Enabled)
                    direct_text = txtDirect_text.GetDataValue() + " " + grdNUR0112.GetItemString(curRowIndex, "nur_so_name");
                else
                    direct_text = grdNUR0112.GetItemString(curRowIndex, "nur_so_name");

                txtDirect_text.SetEditValue(direct_text);

                txtDirect_text.Focus();
                txtDirect_text.SelectionStart = txtDirect_text.Text.Length;

                int rowIndex = grdDirectData.CurrentRowNumber;

                if (rowIndex > -1) grdDirectData.SetItemValue(rowIndex, "direct_cont1", grdNUR0112.GetItemString(curRowIndex, "nur_so_code"));
            }
            /* 마우스의 드랙 앤 드랍처리
            else if (e.Button == MouseButtons.Left && e.Clicks == 1)
            {
                curRowIndex = grdNUR0112.GetHitRowNumber(e.Y);
                if (curRowIndex < 0) return;

                string dragInfo = grdNUR0112.GetItemString(curRowIndex, "nur_so_name");
                DragHelper.CreateDragCursor(grdNUR0112, dragInfo, this.Font);
                txtDirect_text.DoDragDrop("NUR0112|" + grdNUR0112.GetItemString(curRowIndex, "nur_so_name"), DragDropEffects.Move);
            }
            */
        }

        private void grdNUR0112_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void grdNUR0112_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            e.UseDefaultCursors = false;

            if ((e.Effect & DragDropEffects.Move) == DragDropEffects.Move)
            {
                Cursor.Current = DragHelper.DragCursor;
            }
        }

        private void SiksaSet(string aCurrTableName)
        {
            string directText = txtDirect_text.Text;
            string directCode = CurrMQLayout.GetItemValue(CurrMQLayout.CurrentRowNumber, "nur_so_code").ToString();
            string directName = CurrMQLayout.GetItemValue(CurrMQLayout.CurrentRowNumber, "nur_so_name").ToString();
            switch (aCurrTableName)
            {
                case "grdNUR0112":
                    dbxJusik.ResetData();
                    directText = directText + " " + directName;

                    grdDirectData.SetItemValue(grdDirectData.CurrentRowNumber, "direct_cont1", directCode);

                    dbxJusik.SetDataValue(directName);

                    if (directCode == "06" && tvwDirectInfo.SelectedNode.Tag.ToString().Split('|')[1].Substring(2, 1).Equals("0"))
                        emkJusik_Yudong.Enabled = true;
                    else
                        emkJusik_Yudong.Enabled = false;

                    break;

                case "grdNUR0114":
                    // 부식
                    if (directCode.Substring(0, 1).Equals("0"))
                    {
                        dbxBusik.ResetData();
                        directText = directText + " " + directName;

                        grdDirectData.SetItemValue(grdDirectData.CurrentRowNumber, "direct_cont2", directCode);

                        dbxBusik.SetDataValue(directName);

                        if (directCode == "06") emkBusik_Yudong.Enabled = true;
                        else                    emkBusik_Yudong.Enabled = false;
                    }
                    else
                    {
                        // 조리형태
                        if (directCode.Substring(0, 1).Equals("1"))
                        {
                            string joriType = emkJori_Type.Text;
                            emkJori_Type.Text = joriType + " ・" + directName.Substring(7);
                        }
                        else // 금지식품
                        {
                            string kumjisik = emkKumjiSik.Text;
                            emkKumjiSik.Text = kumjisik + " ・" + directName.Substring(7);
                        }
                    }
                    break;

                default:
                    break;
            }
            txtDirect_text.SetEditValue(directText);
        }

        #endregion

        #region [grdNUR0114 Event]

        private void grdNUR0114_MouseDown(object sender, MouseEventArgs e)
        {
            int curRowIndex = -1;

            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {

                // 식사세팅
                if (tvwDirectInfo.SelectedNode.Tag.ToString().Split('|')[0].Equals("02"))
                {
                    SiksaSet("grdNUR0114");
                    return;
                }
                // 식사세팅


                curRowIndex = grdNUR0114.GetHitRowNumber(e.Y);
                if (curRowIndex < 0) return;
                string direct_text = "";
                if (!txtDirect_text.ReadOnly)
                    direct_text = txtDirect_text.GetDataValue() + " " + grdNUR0114.GetItemString(curRowIndex, "nur_so_name");
                else
                    direct_text = grdNUR0114.GetItemString(curRowIndex, "nur_so_name");

                txtDirect_text.SetEditValue(direct_text);

                txtDirect_text.Focus();
                txtDirect_text.SelectionStart = txtDirect_text.Text.Length;

                string direct_gubun = tvwDirectInfo.SelectedNode.Tag.ToString().Split('|')[0];
                string direct_code = tvwDirectInfo.SelectedNode.Tag.ToString().Split('|')[1];
                int rowIndex = grdDirectData.CurrentRowNumber;

                if (rowIndex > -1) grdDirectData.SetItemValue(rowIndex, "direct_cont2", grdNUR0114.GetItemString(curRowIndex, "nur_so_code"));
            }
            /* 마우스의 드랙 앤 드랍처리
            else if (e.Button == MouseButtons.Left && e.Clicks == 1)
            {
                curRowIndex = grdNUR0114.GetHitRowNumber(e.Y);
                if (curRowIndex < 0) return;

                string dragInfo = grdNUR0114.GetItemString(curRowIndex, "nur_so_name");
                DragHelper.CreateDragCursor(grdNUR0114, dragInfo, this.Font);
                txtDirect_text.DoDragDrop("NUR0114|" + grdNUR0114.GetItemString(curRowIndex, "nur_so_name"), DragDropEffects.Move);
            }
             */
        }

        private void grdNUR0114_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void grdNUR0114_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            e.UseDefaultCursors = false;

            if ((e.Effect & DragDropEffects.Move) == DragDropEffects.Move)
            {
                Cursor.Current = DragHelper.DragCursor;
            }
        }

        #endregion

        #region [txtDirect_text Event]

        private void txtDirect_text_DragDrop(object sender, DragEventArgs e)
        {
            string direct_text = "";
            if (!txtDirect_text.ReadOnly && txtDirect_text.Enabled)
                direct_text = txtDirect_text.GetDataValue() + " " + e.Data.GetData("System.String").ToString().Split('|')[1];
            else
                direct_text = e.Data.GetData("System.String").ToString().Split('|')[1];

            txtDirect_text.SetEditValue(direct_text);
            txtDirect_text.Focus();
            txtDirect_text.SelectionStart = txtDirect_text.Text.Length;

            string direct_gubun = tvwDirectInfo.SelectedNode.Tag.ToString().Split('|')[0];
            string direct_code = tvwDirectInfo.SelectedNode.Tag.ToString().Split('|')[1];
            int rowIndex = grdDirectData.CurrentRowNumber;

            if (e.Data.GetData("System.String").ToString().Split('|')[0] == "NUR0112")
                if (rowIndex > -1) grdDirectData.SetItemValue(rowIndex, "direct_cont1", grdNUR0112.GetItemString(grdNUR0112.CurrentRowNumber, "nur_so_code"));
                else
                    if (rowIndex > -1) grdDirectData.SetItemValue(rowIndex, "direct_cont2", grdNUR0114.GetItemString(grdNUR0114.CurrentRowNumber, "nur_so_code"));
        }

        private void txtDirect_text_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void txtDirect_text_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            e.UseDefaultCursors = false;

            if ((e.Effect & DragDropEffects.Move) == DragDropEffects.Move)
            {
                Cursor.Current = DragHelper.DragCursor;
            }
        }

        private void txtDirect_text_DataValidating(object sender, DataValidatingEventArgs e)
        {
            SetDataFromTo();
        }

        #endregion

        #region [FromToDate 유효성 관련]

        private void chkContinue_yn_Click(object sender, EventArgs e)
        {
            if (chkContinue_yn.Checked)
            {
                if (mDirectMode == "0")
                {
                    emkJaewon_to_il.ResetData();
                    emkJaewon_to_il.Enabled = false;
                    vsbJaewon_to_il.Enabled = false;
                    grdDirectData.SetItemValue(grdDirectData.CurrentRowNumber, "jaewonil_to", 0);
                }
                else
                {
                    //dpkPlan_to_date.Enabled = false;
                    dpkPlan_to_date.SetDataValue(null);
                }
            }
            else
            {
                if (mDirectMode == "0")
                {
                    emkJaewon_to_il.SetDataValue(dbxJaewonil.GetDataValue());
                    emkJaewon_to_il.Enabled = true;
                    vsbJaewon_to_il.Enabled = true;
                    grdDirectData.SetItemValue(grdDirectData.CurrentRowNumber, "jaewonil_to", TypeCheck.NVL(emkJaewon_to_il.GetDataValue(), 0));
                }
                else
                {
                    dpkPlan_to_date.ResetData();
                    //dpkPlan_to_date.Enabled = true;
                    if (mDirectMode == "1") dpkPlan_to_date.SetDataValue(mPlan_order_date);
                    else if (mDirectMode == "2") dpkPlan_to_date.SetDataValue(mOrder_date);
                }
            }

            SetDataFromTo();
        }

        private void dpkPlan_to_date_DataValidating(object sender, DataValidatingEventArgs e)
        {
            if (BetweenDay(dpkPlan_to_date.GetDataValue(), dpkPlan_from_date.GetDataValue()) < 0)
            {
                dpkPlan_to_date.SetDataValue(null);
            }

            SetDataFromTo();
        }

        #endregion

        #region [grdDirectData 관련]

        private void grdDirectData_RowFocusChanged(object sender, RowFocusChangedEventArgs e)
        {
            this.grdOCS2015.QueryLayout(false);

            if (e.PreviousRow >= 0)
            {
                this.ApplyData(e.PreviousRow);
            }

            ClearControlAll();

            string direct_gubun = tvwDirectInfo.SelectedNode.Tag.ToString().Split('|')[0];
            string direct_code = tvwDirectInfo.SelectedNode.Tag.ToString().Split('|')[1];

            LoadDirect_cont(direct_gubun, direct_code);

            LoadData(e.CurrentRow, "M");
        }

        #endregion

        #region [ SetHangmogName 해당항목명 조회 ]
        private void SetHangmogName(string hangmogCode, int insertRow)
        {
            string cmdText = @"SELECT A.HANGMOG_NAME, B.SLIP_NAME
  FROM OCS0103 A
     , OCS0102 B
 WHERE A.HANGMOG_CODE = '" + hangmogCode + @"'
   AND A.SLIP_CODE    = B.SLIP_CODE
   AND A.HOSP_CODE    = B.HOSP_CODE
   AND A.HOSP_CODE    = FN_ADM_LOAD_HOSP_CODE";

            DataTable dtTable = Service.ExecuteDataTable(cmdText);

            CurrMQLayout.SetItemValue(insertRow, "hangmog_name", dtTable.Rows[0]["hangmog_name"].ToString());
            CurrMQLayout.SetItemValue(insertRow, "slip_name", dtTable.Rows[0]["slip_name"].ToString());

            dtTable.Reset();
            cmdText = @"SELECT A.CODE_NAME
    FROM OCS0132 A
   WHERE A.HOSP_CODE = FN_ADM_LOAD_HOSP_CODE()
     AND A.CODE_TYPE = 'ORD_DANUI'
     AND A.CODE      = '" + CurrMQLayout.GetItemValue(insertRow, "ord_danui").ToString() + "'";// :f_code";
            dtTable = Service.ExecuteDataTable(cmdText);

            CurrMQLayout.SetItemValue(insertRow, "ord_danui", dtTable.Rows[0]["code_name"].ToString());
        }
        #endregion

        #region [ 지시오더 분류에 따른 그리드 쿼리 ( grdNUR0115 & grdNUR0115_2 ) ]
        private void grdNUR0112_RowFocusChanged(object sender, RowFocusChangedEventArgs e)
        {
            grdNUR0115.Reset();
            grdNUR0115_2.Reset();

            string fkocs2005 = "";
            string directDetail = "";

            foreach (DataRow row in grdOriginDirectDetail.LayoutTable.Rows)
            {
                if ( grdNUR0112.GetItemString(e.CurrentRow, "nur_gr_code") == row["direct_gubun"].ToString()
                 &&  grdNUR0112.GetItemString(e.CurrentRow, "nur_md_code") == row["direct_code"].ToString()
                 &&  grdNUR0112.GetItemString(e.CurrentRow, "nur_so_code") == row["direct_detail"].ToString())
                {
                    fkocs2005 = row["fkocs2005"].ToString();
                    directDetail = row["direct_detail"].ToString();
                }
            }

            #region OCS2006 에 입력된 내용을 조회

            #region grdNUR0115.QuerySQL
            if (grdNUR0115.Visible == true)
            {
//                grdNUR0115.QuerySQL = @"SELECT 'Y' SELECT_ORDER ,
//                                               C.SLIP_NAME      ,
//                                               A.HANGMOG_CODE   ,
//                                               B.HANGMOG_NAME   ,
//                                               A.SURYANG        ,
//                                               A.ORD_DANUI, 
//                                               FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORD_DANUI) ORD_DANUI_NAME ,
//                                               A.DV             ,
//                                               A.DV_TIME        ,
//                                               A.NALSU          ,
//                                               A.JUSA_CODE      ,
//                                               FN_DRG_LOAD_BOGYONG_JUSA_NAME('A', A.JUSA_CODE)   JUSA_NAME ,
//                                               A.JUSA_SPD_GUBUN ,
//                                               A.BOGYONG_CODE   ,
//                                               DECODE(C.SLIP_CODE, 'J01', A.BOGYONG_CODE || D.CODE_NAME, FN_DRG_LOAD_BOGYONG_JUSA_NAME('C', A.BOGYONG_CODE)) AS BOGYONG_NAME,
//                                               A.DIRECT_GUBUN   ,
//                                               A.DIRECT_CODE    ,
//                                               A.DIRECT_DETAIL  ,
//                                               A.SEQ            ,
//                                               A.BOM_SOURCE_KEY	,
//                                               A.BOM_YN		    ,
//                                               C.SLIP_CODE
//                                          FROM OCS2006 A,
//                                               OCS0103 B,
//                                               OCS0102 C,
//                                               OCS0132 D
//                                         WHERE A.FKOCS2005        = :f_fkocs2005
//                                           AND A.HOSP_CODE        = :f_hosp_code
//                                           AND A.DIRECT_DETAIL    = :f_direct_detail
//                                           AND A.INPUT_GUBUN      = :f_input_gubun
//                                           AND A.HANGMOG_CODE     = B.HANGMOG_CODE
//                                           AND A.HOSP_CODE        = B.HOSP_CODE
//                                           AND B.SLIP_CODE        = C.SLIP_CODE
//                                           AND B.HOSP_CODE        = C.HOSP_CODE
//                                           AND A.JUSA_SPD_GUBUN   = D.CODE(+)
//                                           AND 'JUSA_SPD_GUBUN'   = D.CODE_TYPE(+)
//                                           AND D.HOSP_CODE(+)     = A.HOSP_CODE
//                                         ORDER BY A.DIRECT_DETAIL, A.SEQ, A.HANGMOG_CODE";

//                grdNUR0115.SetBindVarValue("f_fkocs2005",     fkocs2005);
//                grdNUR0115.SetBindVarValue("f_hosp_code",     mHospCode);
//                grdNUR0115.SetBindVarValue("f_input_gubun",   mSelectInput);
//                grdNUR0115.SetBindVarValue("f_direct_detail", directDetail);

//                grdNUR0115.QueryLayout(false);

//                //grdOCS2006.SetBindVarValue("f_fkocs2005", fkocs2005);
//                //grdOCS2006.SetBindVarValue("f_hosp_code", mHospCode);
//                //grdOCS2006.SetBindVarValue("f_input_gubun", mSelectInput);
//                //grdOCS2006.SetBindVarValue("f_direct_detail", directDetail);

//                //grdOCS2006.QueryLayout(false);

//                if (grdNUR0115.RowCount > 0) return;
//                else if(grdNUR0115.RowCount > 0 && grdDirectDetail.RowCount > 0)
//                {
//                }
//                else
//                {
                    grdNUR0115.QuerySQL = @"SELECT 'N' SELECT_ORDER ,
                                                   ''               ,
                                                   C.SLIP_NAME      ,
                                                   A.HANGMOG_CODE   ,
                                                   B.HANGMOG_NAME   ,
                                                   A.SURYANG        ,
                                                   A.ORD_DANUI, 
                                                   FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORD_DANUI) ORD_DANUI_NAME ,
                                                   A.DV             ,
                                                   A.DV_TIME        ,
                                                   A.NALSU          ,
                                                   A.JUSA_CODE      ,
                                                   FN_DRG_LOAD_BOGYONG_JUSA_NAME('A', A.JUSA_CODE)   JUSA_NAME ,
                                                   A.JUSA_SPD_GUBUN ,
                                                   A.BOGYONG_CODE   ,
                                                   DECODE(C.SLIP_CODE, 'J01', A.BOGYONG_CODE || D.CODE_NAME, FN_DRG_LOAD_BOGYONG_JUSA_NAME('C', A.BOGYONG_CODE)) AS BOGYONG_NAME,
                                                   A.NUR_GR_CODE    ,
                                                   A.NUR_MD_CODE    ,
                                                   A.NUR_SO_CODE    ,
                                                   A.SEQ            ,
                                                   A.BOM_SOURCE_KEY	,
                                                   NVL(A.BOM_YN, 'P') BOM_YN		    ,
                                                   C.SLIP_CODE
                                              FROM NUR0115 A,
                                                   OCS0103 B,
                                                   OCS0102 C,
                                                   OCS0132 D
                                             WHERE/**/ A.NUR_GR_CODE  = :f_nur_gr_code
                                               AND A.NUR_MD_CODE    = :f_nur_md_code
                                               AND NVL(A.NUR_SO_CODE, '%') LIKE NVL(:f_nur_so_code, '%')
                                               AND/**/ A.HOSP_CODE  = :f_hosp_code
                                               AND TRUNC(SYSDATE) BETWEEN A.START_DATE AND NVL(A.END_DATE, TO_DATE('99991231', 'YYYYMMDD'))
                                               AND TRUNC(SYSDATE) BETWEEN B.START_DATE AND NVL(B.END_DATE, TO_DATE('99991231', 'YYYYMMDD'))
                                               AND A.HANGMOG_CODE   = B.HANGMOG_CODE
                                               AND A.HOSP_CODE      = B.HOSP_CODE
                                               AND B.SLIP_CODE      = C.SLIP_CODE
                                               AND B.HOSP_CODE      = C.HOSP_CODE
                                               AND A.JUSA_SPD_GUBUN = D.CODE(+)
                                               AND 'JUSA_SPD_GUBUN' = D.CODE_TYPE(+)
                                               AND D.HOSP_CODE(+)   = A.HOSP_CODE
                                             ORDER BY A.NUR_SO_CODE, A.SEQ, A.HANGMOG_CODE";
                //}
            }
            #endregion

            #region grdNUR0115_2.QuerySQL
            else if(grdNUR0115_2.Visible == true)
            {
//                grdNUR0115_2.QuerySQL = @"  SELECT 'Y' SELECT_ORDER ,
//                                                   ''               ,
//                                                   C.SLIP_NAME      ,
//                                                   A.HANGMOG_CODE   ,
//                                                   B.HANGMOG_NAME   ,
//                                                   A.SURYANG        ,
//                                                   A.ORD_DANUI, 
//                                                   FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORD_DANUI) ORD_DANUI_NAME ,
//                                                   A.NALSU          ,
//                                                   A.BOGYONG_CODE   ,
//                                                   FN_DRG_LOAD_BOGYONG_JUSA_NAME('C', A.BOGYONG_CODE) BOGYONG_NAME   ,
//                                                   A.DIRECT_GUBUN   ,
//                                                   A.DIRECT_CODE    ,
//                                                   A.DIRECT_DETAIL  ,
//                                                   A.SEQ            ,
//                                                   A.BOM_SOURCE_KEY ,
//                                                   A.BOM_YN,-- A.FKOCS2005            ,
//                                                   C.SLIP_CODE
//                                              FROM OCS2006  A
//                                                 , OCS0103  B
//                                                 , OCS0102  C
//                                             WHERE A.FKOCS2005      = :f_fkocs2005
//                                               AND A.HOSP_CODE      = :f_hosp_code
//                                               AND A.INPUT_GUBUN    = :f_input_gubun
//                                               AND A.HANGMOG_CODE   = B.HANGMOG_CODE
//                                               AND A.HOSP_CODE      = B.HOSP_CODE
//                                               AND B.SLIP_CODE      = C.SLIP_CODE
//                                               AND B.HOSP_CODE      = C.HOSP_CODE
//                                             ORDER BY A.DIRECT_DETAIL, A.SEQ, A.HANGMOG_CODE";
//                grdNUR0115_2.SetBindVarValue("f_fkocs2005",   fkocs2005);
//                grdNUR0115_2.SetBindVarValue("f_input_gubun", mSelectInput);
//                grdNUR0115_2.SetBindVarValue("f_hosp_code",   mHospCode);

//                grdNUR0115_2.QueryLayout(false);

//                if (grdNUR0115_2.RowCount > 0) return;
//                else
//                {
                    grdNUR0115_2.QuerySQL = @"  SELECT 'N' SELECT_ORDER ,
                                                       ''		,
                                                       C.SLIP_NAME      ,
                                                       A.HANGMOG_CODE   ,
                                                       B.HANGMOG_NAME   ,
                                                       A.SURYANG        ,
                                                       A.ORD_DANUI, 
                                                       FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORD_DANUI) ORD_DANUI_NAME ,
                                                       A.NALSU          ,
                                                       A.BOGYONG_CODE   ,
                                                       FN_DRG_LOAD_BOGYONG_JUSA_NAME('C', A.BOGYONG_CODE) BOGYONG_NAME   ,
                                                       A.NUR_GR_CODE    ,
                                                       A.NUR_MD_CODE    ,
                                                       A.NUR_SO_CODE    ,
                                                       A.SEQ		,
                                                       A.BOM_SOURCE_KEY	,
                                                       A.BOM_YN            ,
                                                       C.SLIP_CODE
                                                  FROM NUR0115 A,
                                                       OCS0103 B,
                                                       OCS0102 C
                                                 WHERE/**/ A.NUR_GR_CODE  = :f_nur_gr_code
                                                   AND A.NUR_MD_CODE    = :f_nur_md_code
                                                   AND NVL(A.NUR_SO_CODE, '%') LIKE NVL(:f_nur_so_code, '%')
                                                   AND/**/ A.HOSP_CODE  = :f_hosp_code
                                                   AND A.HANGMOG_CODE   = B.HANGMOG_CODE
                                                   AND A.HOSP_CODE      = B.HOSP_CODE
                                                   AND B.SLIP_CODE      = C.SLIP_CODE
                                                   AND B.HOSP_CODE      = C.HOSP_CODE
                                                 ORDER BY A.NUR_SO_CODE, A.SEQ, A.HANGMOG_CODE";
                //}
            }
            #endregion

            if (grdNUR0115.Visible)
            {
                grdNUR0115.SetBindVarValue("f_nur_gr_code", grdNUR0112.GetItemString(e.CurrentRow, "nur_gr_code"));
                grdNUR0115.SetBindVarValue("f_nur_md_code", grdNUR0112.GetItemString(e.CurrentRow, "nur_md_code"));
                grdNUR0115.SetBindVarValue("f_nur_so_code", grdNUR0112.GetItemString(e.CurrentRow, "nur_so_code"));
                grdNUR0115.SetBindVarValue("f_hosp_code",   mHospCode);

                grdNUR0115.QueryLayout(false);
            }
            else if (grdNUR0115_2.Visible)
            {
                grdNUR0115_2.SetBindVarValue("f_nur_gr_code", grdNUR0112.GetItemString(e.CurrentRow, "nur_gr_code"));
                grdNUR0115_2.SetBindVarValue("f_nur_md_code", grdNUR0112.GetItemString(e.CurrentRow, "nur_md_code"));
                grdNUR0115_2.SetBindVarValue("f_nur_so_code", grdNUR0112.GetItemString(e.CurrentRow, "nur_so_code"));
                grdNUR0115_2.SetBindVarValue("f_hosp_code",   mHospCode);

                grdNUR0115_2.QueryLayout(false);
            }
            #endregion

            if (this.grdNUR0115.Visible == true)
            {
                this.grdNUR0115.Enabled = true;

                if (grdDirectDetail.RowCount == 0)
                {
                    this.grdNUR0115.Enabled = true;
                }
                else
                {
                    for (int i = 0; i < grdNUR0115.RowCount; i++)
                    {
                        string hangmog_code = grdNUR0115.GetItemString(i, "hangmog_code");
                        for (int j = 0; j < grdDirectDetail.RowCount; j++)
                        {
                            if (   hangmog_code == grdDirectDetail.GetItemString(j, "hangmog_code")
                                && this.mSelectInput == grdDirectDetail.GetItemString(j, "input_gubun"))
                            {
                                grdNUR0115.SetItemValue(i, "select_order", "Y");
                            }
                        }
                    }

                    for (int i = 0; i < this.grdDirectDetail.RowCount; i++)
                    {
                        if (   this.grdDirectDetail.GetRowState(i) != DataRowState.Added
                            && this.mSelectInput == grdDirectDetail.GetItemString(i, "input_gubun"))
                        {
                            this.grdNUR0115.Enabled = false;
                            break;
                        }
                    }
                }
            }

            if (this.grdNUR0115_2.Visible == true)
            {
                this.grdNUR0115_2.Enabled = true;

                if (grdDirectDetail.RowCount == 0)
                {
                    this.grdNUR0115_2.Enabled = true;
                }
                else
                {
                    for (int i = 0; i < grdNUR0115_2.RowCount; i++)
                    {
                        string hangmog_code = grdNUR0115_2.GetItemString(i, "hangmog_code");
                        for (int j = 0; j < grdDirectDetail.RowCount; j++)
                        {
                            if (   hangmog_code == grdDirectDetail.GetItemString(j, "hangmog_code")
                                && this.mSelectInput == grdDirectDetail.GetItemString(j, "input_gubun"))
                            {
                                grdNUR0115_2.SetItemValue(i, "select_order", "Y");
                            }
                        }
                    }

                    for (int i = 0; i < this.grdDirectDetail.RowCount; i++)
                    {
                        if (   this.grdDirectDetail.GetRowState(i) != DataRowState.Added
                            && this.mSelectInput == grdDirectDetail.GetItemString(i, "input_gubun"))
                        {
                            this.grdNUR0115_2.Enabled = false;
                            break;
                        }
                    }
                }
            }
        }
        #endregion

        #region [ grdNUR0115 & grdNUR0115_2 Double Click Event ]
        private void grdNUR0115_DoubleClick(object sender, EventArgs e)
        {
            return;
            if (CurrMQLayout.GetItemValue(CurrMQLayout.CurrentRowNumber, "select_order").ToString() == "N")
            {
                CurrMQLayout.SetItemValue(CurrMQLayout.CurrentRowNumber, "select_order", "Y");
            }
            else
            {
                CurrMQLayout.SetItemValue(CurrMQLayout.CurrentRowNumber, "select_order", "N");
            }
            return;
            string direct_text = txtDirect_text.Text;
            int insertRow = -1;

            string bomSourceKey = "";

            for (int i = 0; i < grdNUR0115.RowCount; i++)
            {
                if (grdNUR0115.IsSelectedRow(i))
                {
                    if (grdNUR0115.GetItemString(i, "select_order") == "")
                    {
                        grdNUR0115.SetItemValue(i, "select_order", "Y");
                        insertRow = grdDirectDetail.InsertRow(-1);

                        grdDirectDetail.SetItemValue(insertRow, "bunho",        grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "bunho"));
                        grdDirectDetail.SetItemValue(insertRow, "fkinp1001",    grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "fkinp1001"));
                        grdDirectDetail.SetItemValue(insertRow, "order_date",   grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "order_date"));
                        grdDirectDetail.SetItemValue(insertRow, "input_gubun",  grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "input_gubun"));

                        grdDirectDetail.SetItemValue(insertRow, "pk_seq",       grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "pk_seq"));
                        grdDirectDetail.SetItemValue(insertRow, "direct_gubun", grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "direct_gubun"));
                        grdDirectDetail.SetItemValue(insertRow, "direct_code",  grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "direct_code"));
                        grdDirectDetail.SetItemValue(insertRow, "direct_detail", grdNUR0112.GetItemString(grdNUR0112.CurrentRowNumber, "nur_so_code"));
                        grdDirectDetail.SetItemValue(insertRow, "hangmog_code", grdNUR0115.GetItemString(i, "hangmog_code"));
                        grdDirectDetail.SetItemValue(insertRow, "suryang",      grdNUR0115.GetItemString(i, "suryang"));
                        grdDirectDetail.SetItemValue(insertRow, "nalsu",        grdNUR0115.GetItemString(i, "nalsu"));
                        grdDirectDetail.SetItemValue(insertRow, "ord_danui",    grdNUR0115.GetItemString(i, "ord_danui"));
                        grdDirectDetail.SetItemValue(insertRow, "dv",           grdNUR0115.GetItemString(i, "dv"));
                        grdDirectDetail.SetItemValue(insertRow, "dv_time",      grdNUR0115.GetItemString(i, "dv_time"));
                        grdDirectDetail.SetItemValue(insertRow, "jusa_code",    grdNUR0115.GetItemString(i, "jusa_code"));
                        grdDirectDetail.SetItemValue(insertRow, "jusa_spd_gubun", grdNUR0115.GetItemString(i, "jusa_spd_gubun"));
                        grdDirectDetail.SetItemValue(insertRow, "bogyong_code", grdNUR0115.GetItemString(i, "bogyong_code"));
                        grdDirectDetail.SetItemValue(insertRow, "seq",          grdNUR0115.GetItemString(i, "seq"));//LoadDetailKey());
                        grdDirectDetail.SetItemValue(insertRow, "fkocs2005",    grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "pkocs2005"));
                        grdDirectDetail.SetItemValue(insertRow, "select_order", "Y");
                        
                        // CP Detail Insert
                        grdDirectDetail.SetItemValue(insertRow, "memb",         grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "memb"));
                        grdDirectDetail.SetItemValue(insertRow, "memb_gubun",   grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "memb_gubun"));
                        grdDirectDetail.SetItemValue(insertRow, "cp_code",      grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "cp_code"));
                        grdDirectDetail.SetItemValue(insertRow, "cp_path_code", grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "cp_path_code"));
                        grdDirectDetail.SetItemValue(insertRow, "jaewonil",     grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "jaewonil"));
                        grdDirectDetail.SetItemValue(insertRow, "fkocs6005",    grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "pkocs6005"));
                        grdDirectDetail.SetItemValue(insertRow, "fkocs6010",    grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "fkocs6010"));
                        grdDirectDetail.SetItemValue(insertRow, "fkocs6015",    grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "pkocs6015"));
                        
                        if (mDirectMode == "0" || mDirectMode == "1") // CP OCS6006 & OCS6016
                        {
                            if (grdNUR0115.GetItemString(insertRow, "bom_yn").Equals("P"))
                            {
                                bomSourceKey = grdDirectDetail.GetItemString(insertRow, "seq");
                            }
                            else if (grdNUR0115.GetItemString(insertRow, "bom_yn").Equals("C"))
                            {
                                grdDirectDetail.SetItemValue(insertRow, "bom_source_key", bomSourceKey);
                            }
                        }
                        else // 지시사항
                        {
                            if (grdNUR0115.GetItemString(insertRow, "bom_yn").Equals("P"))
                            {
                                bomSourceKey = grdDirectDetail.GetItemString(insertRow, "fkocs2005");
                                //bomSourceKey = grdDirectDetail.GetItemString(insertRow, "fkocs2005") + grdDirectDetail.GetItemString(insertRow, "seq");
                            }
                            else if (grdNUR0115.GetItemString(insertRow, "bom_yn").Equals("C"))
                            {
                                grdDirectDetail.SetItemValue(insertRow, "bom_source_key", bomSourceKey);
                            }
                        }

                    }
                    else
                    {
                        grdNUR0115.SetItemValue(i, "select_order", "");
                        for (int j = 0; j < grdDirectDetail.RowCount; j++)
                        {
                            if (grdDirectDetail.GetItemString(j, "seq").Equals(grdNUR0115.GetItemString(i, "seq")))
                            {
                                grdDirectDetail.DeleteRow(j);
                                j--;
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < grdNUR0115.RowCount; i++)
            {
                if (grdNUR0115.GetItemString(i, "select_order").Equals("Y"))
                {
                    direct_text = direct_text + " " + "[ " + grdNUR0115.GetItemString(i, "hangmog_name") + " ]";
                }
            }
            txtDirect_text.SetDataValue(direct_text);

            txtDirect_text.Focus();
            txtDirect_text.SelectionStart = txtDirect_text.Text.Length;
        }

        private void grdNUR0115_2_DoubleClick(object sender, EventArgs e)
        {
            return;
            string direct_text = txtDirect_text.Text;
            int insertRow = -1;

            string bomSourceKey = "";

            for (int i = 0; i < grdNUR0115_2.RowCount; i++)
            {
                if (grdNUR0115_2.IsSelectedRow(i))
                {
                    if (grdNUR0115_2.GetItemString(i, "select_order") == "")
                    {
                        grdNUR0115_2.SetItemValue(i, "select_order", "Y");
                        insertRow = grdDirectDetail.InsertRow(-1);
                        
                        grdDirectDetail.SetItemValue(insertRow, "bunho",        grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "bunho"));
                        grdDirectDetail.SetItemValue(insertRow, "fkinp1001",    grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "fkinp1001"));
                        grdDirectDetail.SetItemValue(insertRow, "order_date",   grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "order_date"));
                        grdDirectDetail.SetItemValue(insertRow, "input_gubun",  grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "input_gubun"));
                        grdDirectDetail.SetItemValue(insertRow, "pk_seq",       grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "pk_seq"));
                        grdDirectDetail.SetItemValue(insertRow, "direct_gubun", grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "direct_gubun"));
                        grdDirectDetail.SetItemValue(insertRow, "direct_code",  grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "direct_code"));
                        grdDirectDetail.SetItemValue(insertRow, "select_order", "Y");


                        grdDirectDetail.SetItemValue(insertRow, "direct_detail", grdNUR0112.GetItemString(i, "nur_so_code"));
                        grdDirectDetail.SetItemValue(insertRow, "hangmog_code", grdNUR0115_2.GetItemString(i, "hangmog_code"));
                        grdDirectDetail.SetItemValue(insertRow, "suryang",      grdNUR0115_2.GetItemString(i, "suryang"));
                        grdDirectDetail.SetItemValue(insertRow, "nalsu",        grdNUR0115_2.GetItemString(i, "nalsu"));
                        grdDirectDetail.SetItemValue(insertRow, "ord_danui",    grdNUR0115_2.GetItemString(i, "ord_danui"));
                        grdDirectDetail.SetItemValue(insertRow, "bogyong_code", grdNUR0115_2.GetItemString(i, "bogyong_code"));
                        grdDirectDetail.SetItemValue(insertRow, "bom_yn",       grdNUR0115_2.GetItemString(i, "bom_yn"));
                        grdDirectDetail.SetItemValue(insertRow, "seq",          grdNUR0115_2.GetItemString(i, "seq"));//LoadDetailKey());
                        grdDirectDetail.SetItemValue(insertRow, "fkocs2005",    grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "pkocs2005"));

                        if (mDirectMode == "0" || mDirectMode == "1") // CP OCS6006 & OCS6016
                        {
                            if (grdNUR0115_2.GetItemString(insertRow, "bom_yn").Equals("P"))
                            {
                                bomSourceKey = grdDirectDetail.GetItemString(insertRow, "seq");
                            }
                            else if (grdNUR0115_2.GetItemString(insertRow, "bom_yn").Equals("C"))
                            {
                                grdDirectDetail.SetItemValue(insertRow, "bom_source_key", bomSourceKey);
                            }
                        }
                        else // 지시사항
                        {
                            if (grdNUR0115_2.GetItemString(insertRow, "bom_yn").Equals("P"))
                            {
                                bomSourceKey = grdDirectDetail.GetItemString(insertRow, "fkocs2005");
                                //bomSourceKey = grdDirectDetail.GetItemString(insertRow, "fkocs2005") + grdDirectDetail.GetItemString(insertRow, "seq");
                            }
                            else if (grdNUR0115_2.GetItemString(insertRow, "bom_yn").Equals("C"))
                            {
                                grdDirectDetail.SetItemValue(insertRow, "bom_source_key", bomSourceKey);
                            }
                        }
                        
                        // CP Detail Insert
                        grdDirectDetail.SetItemValue(insertRow, "memb",         grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "memb"));
                        grdDirectDetail.SetItemValue(insertRow, "memb_gubun",   grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "memb_gubun"));
                        grdDirectDetail.SetItemValue(insertRow, "cp_code",      grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "cp_code"));
                        grdDirectDetail.SetItemValue(insertRow, "cp_path_code", grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "cp_path_code"));
                        grdDirectDetail.SetItemValue(insertRow, "jaewonil",     grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "jaewonil"));
                        grdDirectDetail.SetItemValue(insertRow, "fkocs6005",    grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "pkocs6005"));
                        grdDirectDetail.SetItemValue(insertRow, "fkocs6010",    grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "fkocs6010"));
                        grdDirectDetail.SetItemValue(insertRow, "fkocs6015",    grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "pkocs6015"));
                        grdDirectDetail.SetItemValue(insertRow, "select_order", "Y");
                    }
                    else
                    {
                        grdNUR0115_2.SetItemValue(i, "select_order", "");
                        for (int j = 0; j < grdDirectDetail.RowCount; j++)
                        {
                            if (grdDirectDetail.GetItemString(j, "seq").Equals(grdNUR0115_2.GetItemString(i, "seq")))
                            {
                                grdDirectDetail.DeleteRow(j);
                                j--;
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < grdNUR0115_2.RowCount; i++)
            {
                if (grdNUR0115_2.GetItemString(i, "select_order").Equals("Y") && grdNUR0115_2.GetItemString(i, "bom_yn").Equals("P"))
                {
                    direct_text = direct_text + " " + "[ " + grdNUR0115_2.GetItemString(i, "hangmog_name") + " ]";
                }
            }
            txtDirect_text.SetDataValue(direct_text);

            txtDirect_text.Focus();
            txtDirect_text.SelectionStart = txtDirect_text.Text.Length;
        }
        #endregion

        #region [ grdNUR0115 & grdNUR0115_2 선택시 처리 ]
        private void grdNUR0115_ItemValueChanging(object sender, ItemValueChangingEventArgs e)
        {
            string bomSourceKey = "";

            if (e.ColName != "select_order") return;

            #region 일괄선택 & 일괄해제
            if (!e.ColName.Equals("select_order")) return;
                        
            if (grdNUR0115.GetItemString(e.RowNumber, "bom_yn").Equals("P"))
            {
                bomSourceKey = grdNUR0115.GetItemString(e.RowNumber, "hangmog_code");
            }
            else
            {
                bomSourceKey = grdNUR0115.GetItemString(e.RowNumber, "bom_source_key");
            }

            if (grdNUR0115.GetItemString(e.RowNumber, "bom_yn") == "P")
            {
                for (int i = 0; i < grdNUR0115.RowCount; i++)
                {
                    if (grdNUR0115.GetItemString(i, "hangmog_code") == bomSourceKey ||
                        grdNUR0115.GetItemString(i, "bom_source_key") == bomSourceKey )
                    {
                        grdNUR0115.SetItemValue(i, "select_order", e.ChangeValue);
                    }
                }
            }
            #endregion

            int seq = 0;
            for (int i = 0; i < grdDirectDetail.RowCount; i++)
            {
                if (seq < Convert.ToInt32(grdDirectDetail.GetItemString(i, "seq")))
                {
                    seq = Convert.ToInt32(grdDirectDetail.GetItemString(i, "seq"));
                }
            }
            seq++;

            #region 선택항목 오더발생
            string direct_text = txtDirect_text.Text;
            int insertRow = -1;

            bomSourceKey = "";

            for (int i = 0; i < grdNUR0115.RowCount; i++)
            {
                if (grdNUR0115.IsSelectedRow(i))
                {
                    if (grdNUR0115.GetItemString(i, "select_order") == "Y")
                    {
                        insertRow = grdDirectDetail.InsertRow(-1);

                        grdDirectDetail.SetItemValue(insertRow, "bunho",          grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "bunho"));
                        grdDirectDetail.SetItemValue(insertRow, "fkinp1001",      grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "fkinp1001"));
                        grdDirectDetail.SetItemValue(insertRow, "order_date",     grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "order_date"));
                        grdDirectDetail.SetItemValue(insertRow, "input_gubun",    grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "input_gubun"));

                        grdDirectDetail.SetItemValue(insertRow, "pk_seq",         grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "pk_seq"));
                        grdDirectDetail.SetItemValue(insertRow, "direct_gubun",   grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "direct_gubun"));
                        grdDirectDetail.SetItemValue(insertRow, "direct_code",    grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "direct_code"));

                        grdDirectDetail.SetItemValue(insertRow, "direct_detail",  grdNUR0115.GetItemString(i, "nur_so_code"));
                        grdDirectDetail.SetItemValue(insertRow, "hangmog_code",   grdNUR0115.GetItemString(i, "hangmog_code"));
                        grdDirectDetail.SetItemValue(insertRow, "suryang",        grdNUR0115.GetItemString(i, "suryang"));
                        grdDirectDetail.SetItemValue(insertRow, "nalsu",          grdNUR0115.GetItemString(i, "nalsu"));
                        grdDirectDetail.SetItemValue(insertRow, "ord_danui",      grdNUR0115.GetItemString(i, "ord_danui"));
                        grdDirectDetail.SetItemValue(insertRow, "dv",             grdNUR0115.GetItemString(i, "dv"));
                        grdDirectDetail.SetItemValue(insertRow, "dv_time",        grdNUR0115.GetItemString(i, "dv_time"));
                        grdDirectDetail.SetItemValue(insertRow, "jusa_code",      grdNUR0115.GetItemString(i, "jusa_code"));
                        grdDirectDetail.SetItemValue(insertRow, "jusa_spd_gubun", grdNUR0115.GetItemString(i, "jusa_spd_gubun"));
                        grdDirectDetail.SetItemValue(insertRow, "bogyong_code",   grdNUR0115.GetItemString(i, "bogyong_code"));
                        grdDirectDetail.SetItemValue(insertRow, "bom_yn",         grdNUR0115.GetItemString(i, "bom_yn"));
                        grdDirectDetail.SetItemValue(insertRow, "seq",            seq);
                        grdDirectDetail.SetItemValue(insertRow, "fkocs2005",      grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "pkocs2005"));
                        grdDirectDetail.SetItemValue(insertRow, "select_order",   "Y");


                        if (mDirectMode == "0" || mDirectMode == "1") // CP OCS6006 & OCS6016
                        {
                            if (grdNUR0115.GetItemString(insertRow, "bom_yn").Equals("P"))
                            {
                                bomSourceKey = grdDirectDetail.GetItemString(insertRow, "seq");
                            }
                            else if (grdNUR0115.GetItemString(insertRow, "bom_yn").Equals("C"))
                            {
                                grdDirectDetail.SetItemValue(insertRow, "bom_source_key", bomSourceKey);
                            }
                        }
                        else // 지시사항
                        {
                            if (grdNUR0115.GetItemString(insertRow, "bom_yn").Equals("P"))
                            {
                                bomSourceKey = grdDirectDetail.GetItemString(insertRow, "fkocs2005");
                                //bomSourceKey = grdDirectDetail.GetItemString(insertRow, "fkocs2005") + grdDirectDetail.GetItemString(insertRow, "seq");
                            }
                            else if (grdNUR0115.GetItemString(insertRow, "bom_yn").Equals("C"))
                            {
                                grdDirectDetail.SetItemValue(insertRow, "bom_source_key", bomSourceKey);
                            }
                        }

                        // CP Detail Insert
                        grdDirectDetail.SetItemValue(insertRow, "memb",           grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "memb"));
                        grdDirectDetail.SetItemValue(insertRow, "memb_gubun",     grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "memb_gubun"));
                        grdDirectDetail.SetItemValue(insertRow, "cp_code",        grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "cp_code"));
                        grdDirectDetail.SetItemValue(insertRow, "cp_path_code",   grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "cp_path_code"));
                        grdDirectDetail.SetItemValue(insertRow, "jaewonil",       grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "jaewonil"));
                        grdDirectDetail.SetItemValue(insertRow, "fkocs6005",      grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "pkocs6005"));
                        grdDirectDetail.SetItemValue(insertRow, "fkocs6010",      grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "fkocs6010"));
                        grdDirectDetail.SetItemValue(insertRow, "fkocs6015",      grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "pkocs6015"));

                        if (direct_text != "")
                            direct_text = direct_text + "\r\n";

                        direct_text = direct_text + seq +". [" + CurrMQLayout.GetItemValue(i, "hangmog_name") 
                                                  + " <" + CurrMQLayout.GetItemValue(i, "suryang")
                                                  +        CurrMQLayout.GetItemValue(i, "ord_danui_name")
                                                  +        CurrMQLayout.GetItemValue(i, "dv_time") 
                                                  +        CurrMQLayout.GetItemValue(i, "dv")
                                                  + ">]  "
                                                  ;
                        seq++;
                    }
                    else
                    {
                        for (int j = 0; j < grdDirectDetail.RowCount; j++)
                        {
                            if (grdDirectDetail.GetItemString(j, "hangmog_code").Equals(CurrMQLayout.GetItemValue(i, "hangmog_code")))
                            {
                                grdDirectDetail.DeleteRow(j);
                                j--;
                            }
                        }
                    }
                }
                
            }

            //txtDirect_text.SetDataValue(direct_text);

            //txtDirect_text.Focus();
            //txtDirect_text.SelectionStart = txtDirect_text.Text.Length;

            txtDirect_text.SetDataValue(direct_text);

            txtDirect_text.Focus();
            #endregion
        }

        #region [ grdNUR0115 변경값 셋팅 ]
        private void grdNUR0115_GridColumnChanged(object sender, GridColumnChangedEventArgs e)
        {
            if (e.ColName.Equals("select_order")) return;

            string seq = grdNUR0115.GetItemString(e.RowNumber, "seq");

            for (int i = 0; i < grdDirectDetail.RowCount; i++)
            {
                if (seq.Equals(grdDirectDetail.GetItemString(i, "seq")))
                {
                    grdDirectDetail.SetItemValue(i, e.ColName, e.ChangeValue);
                }
            }
        }
        #endregion

        #region [ grdNUR0115_2 변경값 셋팅 ]]
        private void grdNUR0115_2_GridColumnChanged(object sender, GridColumnChangedEventArgs e)
        {
            if (e.ColName.Equals("select_order")) return;

            string seq = grdNUR0115_2.GetItemString(e.RowNumber, "seq");

            for (int i = 0; i < grdDirectDetail.RowCount; i++)
            {
                if (seq.Equals(grdDirectDetail.GetItemString(i, "seq")))
                {
                    grdDirectDetail.SetItemValue(i, e.ColName, e.ChangeValue);
                }
            }
        }
        #endregion

        #endregion

        #region [ grdNUR0115 & _2 Event ]
        private void grdNUR0115_RowFocusChanged(object sender, RowFocusChangedEventArgs e)
        {
            //            return;

            //            CancelEventArgs CE = new CancelEventArgs();

            //            string cmdText = @"SELECT INPUT_CONTROL
            //  FROM OCS0103
            // WHERE HANGMOG_CODE = '" + grdNUR0115.GetItemString(e.CurrentRow, "hangmog_code") + @"'
            //   AND HOSP_CODE    = FN_ADM_LOAD_HOSP_CODE";

            //            string inputControl = Service.ExecuteScalar(cmdText).ToString();

            //            cmdText = @"SELECT NVL(SURYANG_CR_YN, 'N')      SURYANG
            //     , NVL(ORD_DANUI_CR_YN, 'N')    ORD_DANUI
            //     , NVL(DV_CR_YN, 'N')           DV
            //     , NVL(NALSU_CR_YN, 'N')        NALSU
            //     , NVL(JUSA_CR_YN, 'N')         JUSA_CODE
            //     , NVL(BOGYONG_CODE_CR_YN, 'N') BOGYONG_CODE
            //  FROM OCS0133
            // WHERE INPUT_CONTROL = '" + inputControl + @"'
            //   AND HOSP_CODE     = FN_ADM_LOAD_HOSP_CODE";


            //            DataTable dtTable = Service.ExecuteDataTable(cmdText);


            //            for (int i = 0; i < grdNUR0115.LayoutTable.Columns.Count; i++)
            //            {
            //                for (int j = 0; j < dtTable.Columns.Count; j++)
            //                {
            //                    if (grdNUR0115.LayoutTable.Columns[i].ColumnName == dtTable.Columns[j].ColumnName.ToLower())
            //                    {
            //                        if (dtTable.Rows[0][j].ToString().Equals("Y"))
            //                        {
            //                            if (grdNUR0115.GetItemString(grdNUR0115.CurrentRowNumber, grdNUR0115.LayoutTable.Columns[i].ColumnName).Trim() == "")
            //                            {
            //                                XMessageBox.Show("必須入力項目です。", "注意", MessageBoxIcon.Warning);
            //                                grdNUR0115.SetFocusToItem(grdNUR0115.CurrentRowNumber, grdNUR0115.LayoutTable.Columns[i].ColumnName);
            //                                CE.Cancel = true;
            //                                return;
            //                            }
            //                            else
            //                            {
            //                                CE.Cancel = false;
            //                            }
            //                        }
            //                    }
            //                }
            //            }
        }

        private void grdNUR0115_2_ItemValueChanging(object sender, ItemValueChangingEventArgs e)
        {
            #region 일괄선택 & 일괄해제
            if (!e.ColName.Equals("select_order")) return;

            string bomSourceKey = "";
            if (grdNUR0115_2.GetItemString(e.RowNumber, "bom_yn").Equals("P"))
            {
                bomSourceKey = grdNUR0115_2.GetItemString(e.RowNumber, "hangmog_code");
            }
            else
            {
                bomSourceKey = grdNUR0115_2.GetItemString(e.RowNumber, "bom_source_key");
            }

            for (int i = 0; i < grdNUR0115_2.RowCount; i++)
            {
                if (grdNUR0115_2.GetItemString(i, "hangmog_code") == bomSourceKey ||
                    grdNUR0115_2.GetItemString(i, "bom_source_key") == bomSourceKey)
                {
                    grdNUR0115_2.SetItemValue(i, "select_order", e.ChangeValue);
                }
            }
            #endregion

            #region 선택항목 오더발생
            string direct_text = txtDirect_text.Text;
            int insertRow = -1;

            bomSourceKey = "";

            for (int i = 0; i < grdNUR0115_2.RowCount; i++)
            {
                if (grdNUR0115_2.IsSelectedRow(i))
                {
                    if (grdNUR0115_2.GetItemString(i, "select_order") == "Y")
                    {
                        insertRow = grdDirectDetail.InsertRow(-1);

                        grdDirectDetail.SetItemValue(insertRow, "bunho", grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "bunho"));
                        grdDirectDetail.SetItemValue(insertRow, "fkinp1001", grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "fkinp1001"));
                        grdDirectDetail.SetItemValue(insertRow, "order_date", grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "order_date"));
                        grdDirectDetail.SetItemValue(insertRow, "input_gubun", grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "input_gubun"));
                        grdDirectDetail.SetItemValue(insertRow, "pk_seq", grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "pk_seq"));
                        grdDirectDetail.SetItemValue(insertRow, "direct_gubun", grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "direct_gubun"));
                        grdDirectDetail.SetItemValue(insertRow, "direct_code", grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "direct_code"));
                        grdDirectDetail.SetItemValue(insertRow, "select_order", "Y");


                        grdDirectDetail.SetItemValue(insertRow, "direct_detail", grdNUR0115_2.GetItemString(i, "nur_so_code"));
                        grdDirectDetail.SetItemValue(insertRow, "hangmog_code", grdNUR0115_2.GetItemString(i, "hangmog_code"));
                        grdDirectDetail.SetItemValue(insertRow, "suryang", grdNUR0115_2.GetItemString(i, "suryang"));
                        grdDirectDetail.SetItemValue(insertRow, "nalsu", grdNUR0115_2.GetItemString(i, "nalsu"));
                        grdDirectDetail.SetItemValue(insertRow, "ord_danui", grdNUR0115_2.GetItemString(i, "ord_danui"));
                        grdDirectDetail.SetItemValue(insertRow, "bogyong_code", grdNUR0115_2.GetItemString(i, "bogyong_code"));
                        grdDirectDetail.SetItemValue(insertRow, "bom_yn", grdNUR0115_2.GetItemString(i, "bom_yn"));
                        grdDirectDetail.SetItemValue(insertRow, "seq", grdNUR0115_2.GetItemString(i, "seq"));
                        grdDirectDetail.SetItemValue(insertRow, "fkocs2005", grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "pkocs2005"));

                        if (mDirectMode == "0" || mDirectMode == "1") // CP OCS6006 & OCS6016
                        {
                            if (grdNUR0115_2.GetItemString(insertRow, "bom_yn").Equals("P"))
                            {
                                bomSourceKey = grdDirectDetail.GetItemString(insertRow, "seq");
                            }
                            else if (grdNUR0115_2.GetItemString(insertRow, "bom_yn").Equals("C"))
                            {
                                grdDirectDetail.SetItemValue(insertRow, "bom_source_key", bomSourceKey);
                            }
                        }
                        else // 지시사항
                        {
                            if (grdNUR0115_2.GetItemString(insertRow, "bom_yn").Equals("P"))
                            {
                                //bomSourceKey = grdDirectDetail.GetItemString(insertRow, "fkocs2005") + grdDirectDetail.GetItemString(insertRow, "seq");
                                bomSourceKey = grdDirectDetail.GetItemString(insertRow, "fkocs2005");
                            }
                            else if (grdNUR0115_2.GetItemString(insertRow, "bom_yn").Equals("C"))
                            {
                                grdDirectDetail.SetItemValue(insertRow, "bom_source_key", bomSourceKey);
                            }
                        }

                        // CP Detail Insert
                        grdDirectDetail.SetItemValue(insertRow, "memb", grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "memb"));
                        grdDirectDetail.SetItemValue(insertRow, "memb_gubun", grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "memb_gubun"));
                        grdDirectDetail.SetItemValue(insertRow, "cp_code", grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "cp_code"));
                        grdDirectDetail.SetItemValue(insertRow, "cp_path_code", grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "cp_path_code"));
                        grdDirectDetail.SetItemValue(insertRow, "jaewonil", grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "jaewonil"));
                        grdDirectDetail.SetItemValue(insertRow, "fkocs6005", grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "pkocs6005"));
                        grdDirectDetail.SetItemValue(insertRow, "fkocs6010", grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "fkocs6010"));
                        grdDirectDetail.SetItemValue(insertRow, "fkocs6015", grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "pkocs6015"));
                        grdDirectDetail.SetItemValue(insertRow, "select_order", "Y");

                        if (direct_text != "")
                            direct_text = direct_text + "\r\n";

                        direct_text = direct_text + " " + "[ " + grdNUR0115_2.GetItemString(i, "hangmog_name") + "< "
                                                        + grdNUR0115_2.GetItemString(i, "suryang")
                                                        + grdNUR0115_2.GetItemString(i, "ord_danui_name") + " > ]";
                    }
                    else
                    {
                        for (int j = 0; j < grdDirectDetail.RowCount; j++)
                        {
                            if (grdDirectDetail.GetItemString(j, "seq").Equals(grdNUR0115_2.GetItemString(i, "seq")))
                            {
                                grdDirectDetail.DeleteRow(j);
                                j--;
                            }
                        }
                    }
                }
            }

            //for (int i = 0; i < grdNUR0115_2.RowCount; i++)
            //{
            //    if (grdNUR0115_2.GetItemString(i, "select_order").Equals("Y") && grdNUR0115_2.GetItemString(i, "bom_yn").Equals("P"))
            //    {
            //        direct_text = direct_text + " " + "[ " + grdNUR0115_2.GetItemString(i, "hangmog_name") + " ]";
            //    }
            //}
            txtDirect_text.SetDataValue(direct_text);

            txtDirect_text.Focus();
            txtDirect_text.SelectionStart = txtDirect_text.Text.Length;
            #endregion
        }
        #endregion

        #region [ 처치 부모/자식 아이콘 설정 ]
        private void grdNUR0115_2_QueryEnd(object sender, QueryEndEventArgs e)
        {
            for (int i = 0; i < grdNUR0115_2.RowCount; i++)
            {
                if (grdNUR0115_2.GetItemString(i, "bom_yn").Equals("P"))
                {
                    grdNUR0115_2[i, "child_gubun"].Image = ImageList.Images[2];
                }
                else if (grdNUR0115_2.GetItemString(i, "bom_yn").Equals("C"))
                {
                    grdNUR0115_2[i, "child_gubun"].Image = ImageList.Images[3];
                }
            }
        }
        #endregion

        #region [ 그룹선택 ]
        private void grdNUR0115_2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int parentRow = -1;

                string childGubun = this.grdNUR0115_2.GetItemString(grdNUR0115_2.CurrentRowNumber, "bom_yn");

                if (this.grdNUR0115_2.GetItemString(grdNUR0115_2.CurrentRowNumber, "bom_yn").Equals("C"))
                {
                    for (int i = grdNUR0115_2.CurrentRowNumber; i > -1; i--)
                    {
                        if (grdNUR0115_2.GetItemString(i, "bom_yn").Equals("P"))
                        {
                            grdNUR0115_2.SelectRow(i);
                            parentRow = i + 1;
                            break;
                        }
                    }

                    for (int i = parentRow; i < grdNUR0115_2.RowCount; i++)
                    {
                        if (grdNUR0115_2.GetItemString(i, "bom_yn") == "C")
                        {
                            grdNUR0115_2.SelectRow(i);
                        }
                        else if ((grdNUR0115_2.GetItemString(i, "bom_yn").Equals("P")))
                        {
                            return;
                        }
                    }
                }
                else
                {
                    grdNUR0115_2.SelectRow(grdNUR0115_2.CurrentRowNumber);

                    for (int i = grdNUR0115_2.CurrentRowNumber + 1; i < grdNUR0115_2.RowCount; i++)
                    {
                        if (grdNUR0115_2.GetItemString(i, "bom_yn").Equals("C"))
                        {
                            grdNUR0115_2.SelectRow(i);
                        }
                        else if((grdNUR0115_2.GetItemString(i, "bom_yn").Equals("P")))
                        {
                            return;
                        }
                    }
                }
            }
        }
        #endregion

        #region [ 오더발생 지시사항 구분에 따른 입력제어 컨트롤 - SetInputControl(string inputControl) ]
        /// <summary>
        /// 입력제어정보를 조회해서 NUR0115 기본정보 구성시 입력컬럼을 제어한다.
        /// </summary>
        /// <param name="inputControl">입력컨트롤의 구분</param>
        private void SetInputControl(string inputControl)
        {
            // 입력제어
            string cmdText = @"SELECT A.SURYANG_CR_YN         SURYANG_CR_YN
     , A.ORD_DANUI_CR_YN       ORD_DANUI_CR_YN
     , A.DV_CR_YN              DV_CR_YN
     , A.NALSU_CR_YN           NALSU_CR_YN
     , A.JUSA_CR_YN            JUSA_CR_YN
     , A.BOGYONG_CODE_CR_YN    BOGYONG_CODE_CR_YN
  FROM OCS0133 A
 WHERE A.INPUT_CONTROL LIKE TRIM(:f_input_control)||'%'
   AND A.INPUT_CONTROL IN ('a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k')
   AND A.HOSP_CODE = :f_hosp_code
 ORDER BY A.INPUT_CONTROL";

            BindVarCollection bindVars = new BindVarCollection();
            bindVars.Add("f_input_control", inputControl);
            bindVars.Add("f_hosp_code", mHospCode);

            DataTable dtReturn = new DataTable();

            XEditGrid currentGrid;
            XEditGrid currentGrid_S;

            dtReturn = Service.ExecuteDataTable(cmdText, bindVars);

            string gubun = "";

            if (CurrMSLayout == grdNUR0115)
            {
                grdNUR0115.Reset();
                //grdOCS2006.Reset();
            }
            else
            {
                grdNUR0115_2.Reset();
                //grdOCS2006_2.Reset();
            }

            if (grdNUR0115.Visible == true)
            {
                currentGrid = this.grdNUR0115;
                //currentGrid_S = this.grdOCS2006;
            }
            else if (grdNUR0115_2.Visible == true)
            {
                currentGrid = this.grdNUR0115_2;
                //currentGrid_S = this.grdOCS2006_2;
            }
            else
            {
                return;
            }

            if (!TypeCheck.IsNull(dtReturn))
            {
                for (int i = 0; i < dtReturn.Rows[0].Table.Columns.Count; i++)
                {
                    gubun = dtReturn.Rows[0].Table.Columns[i].ColumnName.ToLower();
                    switch (gubun)
                    {
                        case "suryang_cr_yn":       // 수량
                            if (dtReturn.Rows[0][gubun].Equals("N"))
                            {
                                if (currentGrid == this.grdNUR0115)
                                {
                                    this.grdNUR0115.AutoSizeColumn(5, 0);
                                    //this.grdOCS2006.AutoSizeColumn(5, 0);
                                }
                                else
                                {
                                    this.grdNUR0115_2.AutoSizeColumn(5, 0);
                                    //this.grdOCS2006_2.AutoSizeColumn(6, 0);
                                }
                            }
                            else
                            {
                                if (currentGrid == this.grdNUR0115)
                                {
                                    this.grdNUR0115.AutoSizeColumn(5, 32);
                                    //this.grdOCS2006.AutoSizeColumn(5, 32);
                                }
                                else
                                {
                                    this.grdNUR0115_2.AutoSizeColumn(5, 32);
                                    //this.grdOCS2006_2.AutoSizeColumn(6, 32);
                                }
                            }
                            break;
                        case "ord_danui_cr_yn":     // 오더단위
                            if (dtReturn.Rows[0][gubun].Equals("N"))
                            {
                                if (currentGrid == this.grdNUR0115)
                                {
                                    this.grdNUR0115.AutoSizeColumn(6, 0);
                                    //this.grdOCS2006.AutoSizeColumn(6, 0);
                                }
                                else
                                {
                                    this.grdNUR0115_2.AutoSizeColumn(6, 0);
                                    //this.grdOCS2006_2.AutoSizeColumn(7, 0);
                                }
                            }
                            else
                            {
                                if (currentGrid == this.grdNUR0115)
                                {
                                    this.grdNUR0115.AutoSizeColumn(6, 65);
                                    //this.grdOCS2006.AutoSizeColumn(6, 65);
                                }
                                else
                                {
                                    this.grdNUR0115_2.AutoSizeColumn(6, 65);
                                    //this.grdOCS2006_2.AutoSizeColumn(7, 65);
                                }
                            }
                            break;
                        case "dv_cr_yn":            // 회수
                            if (dtReturn.Rows[0][gubun].Equals("N"))
                            {
                                if (currentGrid == this.grdNUR0115)
                                {
                                    this.grdNUR0115.AutoSizeColumn(7, 0);
                                    this.grdNUR0115.AutoSizeColumn(8, 0);

                                    //this.grdOCS2006.AutoSizeColumn(7, 0);
                                    //this.grdOCS2006.AutoSizeColumn(8, 0);
                                }
                            }
                            else
                            {
                                if (currentGrid == this.grdNUR0115)
                                {
                                    this.grdNUR0115.AutoSizeColumn(7, 31);
                                    this.grdNUR0115.AutoSizeColumn(8, 35);

                                    //this.grdOCS2006.AutoSizeColumn(7, 31);
                                    //this.grdOCS2006.AutoSizeColumn(8, 35);
                                }
                            }
                            break;
                        case "nalsu_cr_yn":         // 날수
                            if (dtReturn.Rows[0][gubun].Equals("N"))
                            {
                                if (currentGrid == this.grdNUR0115)
                                {
                                    this.grdNUR0115.AutoSizeColumn(9, 0);
                                    //this.grdOCS2006.AutoSizeColumn(9, 0);
                                }
                                else
                                {
                                    this.grdNUR0115_2.AutoSizeColumn(7, 0);
                                    //this.grdOCS2006_2.AutoSizeColumn(8, 0);
                                }
                            }
                            else
                            {
                                if (currentGrid == this.grdNUR0115)
                                {
                                    this.grdNUR0115.AutoSizeColumn(9, 30);
                                    //this.grdOCS2006.AutoSizeColumn(9, 30);
                                }
                                else
                                {
                                    this.grdNUR0115_2.AutoSizeColumn(7, 30);
                                    //this.grdOCS2006_2.AutoSizeColumn(8, 30);
                                }
                            }
                            break;
                        case "jusa_cr_yn":          // 주사
                            if (dtReturn.Rows[0][gubun].Equals("N"))
                            {
                                if (currentGrid == this.grdNUR0115)
                                {
                                    this.grdNUR0115.AutoSizeColumn(10, 0);
                                    this.grdNUR0115.AutoSizeColumn(11, 0);
                                    this.grdNUR0115.AutoSizeColumn(12, 0);

                                    //this.grdOCS2006.AutoSizeColumn(8, 0);
                                    //this.grdOCS2006.AutoSizeColumn(11, 0);
                                    //this.grdOCS2006.AutoSizeColumn(12, 0);
                                }
                            }
                            else
                            {
                                if (currentGrid == this.grdNUR0115)
                                {
                                    this.grdNUR0115.AutoSizeColumn(10, 40);
                                    this.grdNUR0115.AutoSizeColumn(11, 120);
                                    this.grdNUR0115.AutoSizeColumn(12, 60);

                                    //this.grdOCS2006.AutoSizeColumn(10, 40);
                                    //this.grdOCS2006.AutoSizeColumn(11, 120);
                                    //this.grdOCS2006.AutoSizeColumn(12, 60);
                                }
                            }
                            break;
                        case "bogyong_code_cr_yn":  // 복용코드
                            if (dtReturn.Rows[0][gubun].Equals("N"))
                            {
                                if (currentGrid == this.grdNUR0115)
                                {
                                    this.grdNUR0115.AutoSizeColumn(13, 0);
                                    this.grdNUR0115.AutoSizeColumn(14, 0);

                                    //this.grdOCS2006.AutoSizeColumn(13, 0);
                                    //this.grdOCS2006.AutoSizeColumn(14, 0);
                                }
                            }
                            else
                            {
                                if (currentGrid == this.grdNUR0115)
                                {
                                    this.grdNUR0115.AutoSizeColumn(13, 90);
                                    this.grdNUR0115.AutoSizeColumn(14, 200);

                                    //this.grdOCS2006.AutoSizeColumn(13, 90);
                                    //this.grdOCS2006.AutoSizeColumn(14, 200);
                                }
                            }
                            break;
                    }
                }
            }
        }
        #endregion

        #region [ GridFindClick() Event ]
        /// <summary>
        /// 그리드의 파인드버튼 클릭 이벤트.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GridFindClick(object sender, GridFindClickEventArgs e)
        {
            XEditGrid grid = sender as XEditGrid;
            CommonItemCollection commonParam = new CommonItemCollection();
            switch (e.ColName)
            {
                case "ord_danui_name":
                    fwkCommon.ColInfos.Clear();
                    
                    fwkCommon.ColInfos.Add("code", "単位", FindColType.String, 50, 0, true, FilterType.InitYes);
                    fwkCommon.ColInfos.Add("code_name", "単位名称", FindColType.String, 150, 0, true, FilterType.InitYes);

                    fwkCommon.ColInfos[0].ColAlign = HorizontalAlignment.Center;

                    fwkCommon.InputSQL = @" SELECT A.ORD_DANUI, FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORD_DANUI) ORD_DANUI_NAME
                                              FROM OCS0108 A
                                                 , OCS0103 B
                                             WHERE A.HANGMOG_CODE = '" + CurrMQLayout.GetItemValue(e.RowNumber, "hangmog_code").ToString() + @"'
                                               AND A.HOSP_CODE    = FN_ADM_LOAD_HOSP_CODE
                                               --
                                               AND B.HOSP_CODE   = A.HOSP_CODE
                                               AND B.HANGMOG_CODE = A.HANGMOG_CODE
                                               AND B.START_DATE   = A.HANGMOG_START_DATE
                                               AND '" + this.mOrder_date + @"' BETWEEN B.START_DATE 
                                                                                   AND B.END_DATE
                                             ORDER BY 1, 2";
                    break;

                case "bogyong_code":

                    if (grid.GetItemString(e.RowNumber, e.ColName) == "J01") return;    // 주사일 경우 복용코드 파인드창 띄우지 않음

                    if (grid.Name == grdNUR0115.Name)
                    {
                        this.fwkCommon.ColInfos.Clear();

                        this.fwkCommon.ServerFilter = true;
                        this.fwkCommon.ColInfos.Add("code", "コード", FindColType.String, 80, 0, true, FilterType.InitYes);
                        this.fwkCommon.ColInfos.Add("code_name", "コード名称", FindColType.String, 200, 0, true, FilterType.InitYes);

                        this.fwkCommon.ColInfos[0].ColAlign = HorizontalAlignment.Center;

                        string yakGubun = "";
                        if (grid.GetItemString(e.RowNumber, "slip_code").Equals("P01"))
                        {
                            // 내복약
                            yakGubun = " AND A.BUNRYU1 <> 6 ";
                        }
                        else if (grid.GetItemString(e.RowNumber, "slip_code").Equals("P02"))
                        {
                            // 외용약
                            yakGubun = " AND A.BUNRYU1 = 6 ";
                        }

                        this.fwkCommon.InputSQL = @"SELECT A.BOGYONG_CODE,
       A.BOGYONG_NAME
  FROM DRG0120 A
 WHERE (A.BOGYONG_CODE LIKE '%' || :f_find1 || '%'
    OR A.BOGYONG_NAME LIKE '%' || :f_find1 || '%')
   AND A.HOSP_CODE = FN_ADM_LOAD_HOSP_CODE"
  + yakGubun +
" ORDER BY 1, 2";
                    }
                    else if(grid.Name == grdNUR0115_2.Name)
                    {
                        if (grid.GetItemString(e.RowNumber, "hangmog_code") != "")
                        {
                            string cmdText = @"SELECT DECODE(INPUT_CONTROL, 'A', 'Y', 'N')     INPUT_CONTROL
  FROM OCS0103
 WHERE HANGMOG_CODE = '" + grid.GetItemString(e.RowNumber, "hangmog_code") + @"'
   AND SYSDATE BETWEEN START_DATE AND END_DATE
   AND HOSP_CODE    = FN_ADM_LOAD_HOSP_CODE";

                            object retVal = Service.ExecuteScalar(cmdText);

                            if (TypeCheck.IsNull(retVal) || retVal.ToString() != "Y")
                            {
                                SetMsg("部位入力不可項目です。", MsgType.Error);
                                return;
                            }
                        }

                        OpenScreen(this, "CHT0117Q00", ScreenOpenStyle.ResponseFixed);
                    }
                    break;

                case "jusa_code":
                    fwkCommon.ColInfos.Clear();

                    fwkCommon.ColInfos.Add("code", "コード", FindColType.String, 50, 0, true, FilterType.InitYes);
                    fwkCommon.ColInfos.Add("code_name", "コード名称", FindColType.String, 150, 0, true, FilterType.InitYes);

                    fwkCommon.ColInfos[0].ColAlign = HorizontalAlignment.Center;

                    fwkCommon.InputSQL = @"SELECT A.CODE, A.CODE_NAME
  FROM OCS0132 A
 WHERE A.CODE_TYPE = 'JUSA'
   AND A.HOSP_CODE = FN_ADM_LOAD_HOSP_CODE()
   AND A.CODE_NAME LIKE '%'|| :f_find1 ||'%'
 ORDER BY A.SORT_KEY, A.CODE";
                    break;
            }
        }

        private void GridFindSelected(object sender, GridFindSelectedEventArgs e)
        {
            switch (e.ColName)
            {
                case "ord_danui_name":
                    this.CurrMQLayout.SetItemValue(e.RowNumber, "ord_danui", e.ReturnValues[0].ToString());
                    this.CurrMQLayout.SetItemValue(e.RowNumber, "ord_danui_name", e.ReturnValues[1].ToString());

                    if (CurrMQLayout == grdNUR0115_2)
                    {
                        for (int i = 0; i < grdDirectDetail.RowCount; i++)
                        {
                            if (grdNUR0115_2.GetItemString(e.RowNumber, "seq") == grdDirectDetail.GetItemString(i, "seq"))
                            {
                                grdDirectDetail.SetItemValue(i, "ord_danui", e.ReturnValues[0].ToString());
                            }
                        }
                    }
                    break;

                case "bogyong_code":
                    if (CurrMSLayout == grdNUR0115)
                    {
                        this.CurrMSLayout.SetItemValue(e.RowNumber, "bogyong_name", e.ReturnValues[1].ToString());
                    }
                    break;

                case "jusa_code":
                    if (e.ReturnValues[1].ToString().Trim().Length > 0)
                    {
                        this.CurrMSLayout.SetItemValue(e.RowNumber, "jusa_name", e.ReturnValues[1].ToString());
                    }
                    else
                    {
                        this.CurrMSLayout.SetItemValue(e.RowNumber, "jusa_name", "");
                    }

                    break;
            }
        }
        #endregion

        #region [ Command ]
        public override object Command(string command, CommonItemCollection commandParam)
        {
            switch (command)
            {
                #region 항목검색 [ CHT0110Q01 ]
                case "CHT0110Q01":

                    if (commandParam != null)
                    {
                        MultiLayout grid = ((MultiLayout)commandParam["CHT0110"]);

                        if (commandParam.Contains("CHT0110") && grid.RowCount > 0)
                        {
                            CurrMSLayout.SetItemValue(CurrMSLayout.CurrentRowNumber, "hangmog_code", grid.GetItemString(0, "sang_code"));
                            CurrMSLayout.SetItemValue(CurrMSLayout.CurrentRowNumber, "hangmog_name", grid.GetItemString(0, "sang_name"));
                        }
                    }
                    break;

                // 처치 재료
                case "OCS0103Q00":

                    if (commandParam != null)
                    {
                        MultiLayout grid = ((MultiLayout)commandParam["OCS0103"]);

                        if (commandParam.Contains("OCS0103") && grid.RowCount > 0)
                        {
                            CurrMSLayout.SetItemValue(CurrMSLayout.CurrentRowNumber, "hangmog_code", grid.GetItemString(0, "hangmog_code"));
                            CurrMSLayout.SetItemValue(CurrMSLayout.CurrentRowNumber, "hangmog_name", grid.GetItemString(0, "hangmog_name"));
                        }
                    }
                    break;

                case "CHT0117Q00":

                    if (commandParam != null)
                    {
                        if (commandParam.Contains("buwi_code"))
                        {
                            string buwi_code = commandParam["buwi_code"].ToString();

                            CurrMSLayout.SetItemValue(CurrMSLayout.CurrentRowNumber, "bogyong_code", buwi_code);

                            string cmdText = @"SELECT A.SUB_BUWI_NAME
  FROM CHT0118 A
 WHERE A.HOSP_CODE     = '" + mHospCode + @"'
   AND A.SUB_BUWI      = '" + buwi_code + @"'
   AND TRUNC(SYSDATE) BETWEEN A.START_DATE AND A.END_DATE";
                            object retVal = Service.ExecuteScalar(cmdText);

                            if (!TypeCheck.IsNull(retVal))
                            {
                                CurrMSLayout.SetItemValue(CurrMSLayout.CurrentRowNumber, "bogyong_name", retVal.ToString());
                            }

                            for (int i = 0; i < grdDirectDetail.RowCount; i++)
                            {
                                if (CurrMQLayout.GetItemValue(CurrMQLayout.CurrentRowNumber, "seq").ToString() == grdDirectDetail.GetItemString(i, "seq"))
                                {
                                    grdDirectDetail.SetItemValue(i, "bogyong_code", buwi_code);
                                }
                            }
                        }
                    }
                    break;
                #endregion
            }
            return base.Command(command, commandParam);
        }
        #endregion

        #region [ 식사관련 컨트롤 이벤트 ]
        private void emkJusikYudong_TextChanged(object sender, EventArgs e)
        {
            grdDirectData.SetItemValue(grdDirectData.CurrentRowNumber, "jusik_yudong", emkJusik_Yudong.Text);
        }

        private void emkBusikYudong_TextChanged(object sender, EventArgs e)
        {
            grdDirectData.SetItemValue(grdDirectData.CurrentRowNumber, "busik_yudong", emkBusik_Yudong.Text);
        }

        private void emkJoriType_TextChanged(object sender, EventArgs e)
        {
            grdDirectData.SetItemValue(grdDirectData.CurrentRowNumber, "jori_type", emkJori_Type.Text);
        }

        private void emkKumjiSik_TextChanged(object sender, EventArgs e)
        {
            grdDirectData.SetItemValue(grdDirectData.CurrentRowNumber, "kumjisik", emkKumjiSik.Text);
        }
        #endregion

        private void setDetail_2(string gubun)
        {
            range_from_list.Add(81);
            range_from_list.Add(101);
            range_from_list.Add(151);
            range_from_list.Add(201);
            range_from_list.Add(251);
            range_from_list.Add(331);
            range_from_list.Add(401);
            range_from_list.Add(501);

            range_to_list.Add(100);
            range_to_list.Add(150);
            range_to_list.Add(200);
            range_to_list.Add(250);
            range_to_list.Add(330);
            range_to_list.Add(400);
            range_to_list.Add(500);
            range_to_list.Add(1000);

            switch (gubun)
            {
                case "SSA":
                    suryang_list.Add(0);
                    suryang_list.Add(0);
                    suryang_list.Add(0);
                    suryang_list.Add(2);
                    suryang_list.Add(4);
                    suryang_list.Add(6);
                    suryang_list.Add(8);
                    suryang_list.Add(0);
                    break;
                case "SSB":
                    suryang_list.Add(0);
                    suryang_list.Add(0);
                    suryang_list.Add(2);
                    suryang_list.Add(4);
                    suryang_list.Add(6);
                    suryang_list.Add(8);
                    suryang_list.Add(10);
                    suryang_list.Add(0);
                    break;
            }

        }
        private void btnSSX_Click(object sender, EventArgs e)
        {
            Control ctl = sender as Control;
            this.setDetail_2(ctl.Tag.ToString());

            for (int i = 0; i < 8; i++)
            {
                this.btnInsertDetail_2.PerformClick();
                this.grdDetail_2.SetItemValue(i, "insulin_from", this.range_from_list[i].ToString());
                this.grdDetail_2.SetItemValue(i, "insulin_to", this.range_to_list[i].ToString());
                this.grdDetail_2.SetItemValue(i, "suryang", this.suryang_list[i].ToString());
                this.grdDetail_2.SetItemValue(i, "time_gubun", this.btnB.ImageIndex.ToString() + this.btnL.ImageIndex.ToString() + this.btnD.ImageIndex.ToString() + this.btnS.ImageIndex.ToString());

                Detail_2_Create_text();
            }

            
        }

        private void btnADD_Click(object sender, EventArgs e)
        {
            if (tvwDirectInfo.SelectedNode.SelectedImageIndex == 0)
            {
                this.InsertDirectData(this.tvwDirectInfo.SelectedNode);
            }
        }

        private void btnDELETE_Click(object sender, EventArgs e)
        {
            //if (this.grdOriginDirectData.RowCount > 0)
            //{
            //    //this.grdOCS2015.QueryLayout(false);

            //    if (this.grdOCS2015.RowCount > 0)
            //    {
            //        XMessageBox.Show("既に指示事項に実施履歴が存在します｡削除できません｡指示事項の中止の場合は終了日に日付を入れてください。");
            //        return;
            //    }
            //}
            this.DeleteDirectData();
        }

        private void grdOCS2015_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdOCS2015.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdOCS2015.SetBindVarValue("f_pk_seq", this.grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "pk_seq"));
            this.grdOCS2015.SetBindVarValue("f_input_gubun", "D4");
            this.grdOCS2015.SetBindVarValue("f_fkinp1001", this.grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "fkinp1001"));
            this.grdOCS2015.SetBindVarValue("f_bunho", this.grdDirectData.GetItemString(grdDirectData.CurrentRowNumber, "bunho"));
        }

        private void btn_Click(object sender, EventArgs e)
        {
            Control ctl = sender as Control;
            string tag = ctl.Tag.ToString();

            string direct_text = "";

            if (!txtDirect_text.ReadOnly)
                direct_text = txtDirect_text.GetDataValue() + " " + tag;

            txtDirect_text.SetEditValue(direct_text);

            txtDirect_text.Focus();
            txtDirect_text.SelectionStart = txtDirect_text.Text.Length;
        }

        private void xButton11_Click(object sender, EventArgs e)
        {
            Control ctl = sender as Control;
            string tag = ctl.Tag.ToString();

            string direct_text = "";

            if (!txtDirect_text.ReadOnly)
                direct_text = txtDirect_text.GetDataValue() + "\r\n" + tag + "\r\n";

            txtDirect_text.SetEditValue(direct_text);

            txtDirect_text.Focus();
            txtDirect_text.SelectionStart = txtDirect_text.Text.Length;
        }

        private void xButton12_Click(object sender, EventArgs e)
        {
            Control ctl = sender as Control;
            string tag = ctl.Tag.ToString();

            string direct_text = "";

            if (!txtDirect_text.ReadOnly)
                direct_text = txtDirect_text.GetDataValue() + "\r\n";

            txtDirect_text.SetEditValue(direct_text);

            txtDirect_text.Focus();
            txtDirect_text.SelectionStart = txtDirect_text.Text.Length;
        }

        private void btnBLDS_Click(object sender, EventArgs e)
        {
            XButton btn = sender as XButton;
            string BLDS = btn.Tag.ToString();

            if (btn.ImageIndex == 0)
                btn.ImageIndex = 1;
            else
                btn.ImageIndex = 0;

            for (int i = 0; i < this.grdDetail_2.RowCount; i++)
            {
                this.grdDetail_2.SetItemValue(i, "time_gubun", this.btnB.ImageIndex.ToString() + this.btnL.ImageIndex.ToString() + this.btnD.ImageIndex.ToString() + this.btnS.ImageIndex.ToString());
            }
            Detail_2_Create_text();
            

            //switch (BLDS)
            //{
            //    case "B":
            //        break;
            //    case "L":
            //        break;
            //    case "D":
            //        break;
            //    case "S":
            //        break;
            //}
        }

        private void txtETC_Validated(object sender, EventArgs e)
        {
            Detail_2_Create_text();
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            XButton btn = sender as XButton;
            bool fContinue_yn = false;
            //DirectDetail
            DataTable dtDirectDetailCopy = this.grdDirectDetail.LayoutTable.Clone();
            //insulin_scale
            DataTable dtDetail_2Copy = this.grdDetail_2.LayoutTable.Clone();
            string insulin_drug1 = "", insulin_drug2 = "", insulin_drug3 = "", insulin_drug4 = "";
            string insulin_drug1_suryang = "", insulin_drug2_suryang = "", insulin_drug3_suryang = "", insulin_drug4_suryang = "";
            string insulin_drug = "";
            string comment = "";

            if (XMessageBox.Show("前回の指示内容を読み込んできますか？", "確認", MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                fContinue_yn = true;

            if (fContinue_yn)
            {
                #region 削除する前にBACKUPしておく
                
                for (int i = 0; i < this.grdDirectDetail.RowCount; i++)
                {
                    dtDirectDetailCopy.ImportRow(this.grdDirectDetail.LayoutTable.Rows[i]);
                }

                if (btn.Tag.ToString() == "2")
                {
                    insulin_drug = this.cboHangmog_code.SelectedValue.ToString();

                    for (int i = 0; i < this.grdDetail_2.RowCount; i++)
                    {
                        dtDetail_2Copy.ImportRow(this.grdDetail_2.LayoutTable.Rows[i]);
                    }
                }

                if (btn.Tag.ToString() == "3")
                {
                    insulin_drug1 = this.cboHangmog_code1.GetDataValue();
                    insulin_drug2 = this.cboHangmog_code2.GetDataValue();
                    insulin_drug3 = this.cboHangmog_code3.GetDataValue();
                    insulin_drug4 = this.cboHangmog_code4.GetDataValue();

                    insulin_drug1_suryang = this.emkSurayng1.Text;
                    insulin_drug2_suryang = this.emkSurayng2.Text;
                    insulin_drug3_suryang = this.emkSurayng3.Text;
                    insulin_drug4_suryang = this.emkSurayng4.Text;
                }

                //DirectData
                comment = this.grdDirectData.GetItemString(this.grdDirectData.CurrentRowNumber, "direct_text");
                #endregion
            }

            #region 削除する
            btnDELETE.PerformClick();
            #endregion

            #region 新しいOCS2005となるものを作る
            btnADD.PerformClick();
            #endregion

            if (fContinue_yn)
            {
                #region 削除前にBACKUPしておいたデータを必要な部分だけ復元する。
                for (int i = 0; i < dtDirectDetailCopy.Rows.Count; i++)
                {
                    int rowNum = this.grdDirectDetail.InsertRow(-1);


                    foreach (XEditGridCell info in this.grdDirectDetail.CellInfos)
                    {
                        if (this.grdDirectDetail.CellInfos.Contains(info.CellName))
                        {
                            this.grdDirectDetail.SetItemValue(rowNum, info.CellName, dtDirectDetailCopy.Rows[i][info.CellName].ToString());
                        }
                    }


                    this.grdDirectDetail.SetItemValue(rowNum, "pk_seq", this.grdDirectData.GetItemString(this.grdDirectData.CurrentRowNumber, "pk_seq"));
                    this.grdDirectDetail.SetItemValue(rowNum, "order_date", this.mOrder_date);
                    this.grdDirectDetail.SetItemValue(rowNum, "fkocs2005", this.grdDirectData.GetItemString(this.grdDirectData.CurrentRowNumber, "pkocs2005"));

                }

                //insulin_scale
                if (btn.Tag.ToString() == "2")
                {
                    for (int i = 0; i < dtDetail_2Copy.Rows.Count; i++)
                    {
                        int rowNum = this.grdDetail_2.InsertRow(-1);

                        foreach (XEditGridCell info in this.grdDetail_2.CellInfos)
                        {
                            if (this.grdDetail_2.CellInfos.Contains(info.CellName))
                            {
                                this.grdDetail_2.SetItemValue(rowNum, info.CellName, dtDetail_2Copy.Rows[i][info.CellName].ToString());
                            }
                        }

                        this.grdDetail_2.SetItemValue(rowNum, "pk_seq", this.grdDirectData.GetItemString(this.grdDirectData.CurrentRowNumber, "pk_seq"));
                        this.grdDetail_2.SetItemValue(rowNum, "order_date", this.mOrder_date);
                        //this.grdDetail_2.SetItemValue(rowNum, "fkocs2005", this.grdDirectData.GetItemString(this.grdDirectData.CurrentRowNumber, "pkocs2005"));
                    }
                    this.cboHangmog_code.SetDataValue(insulin_drug);
                }

                //insulin_regular
                if (btn.Tag.ToString() == "3")
                {
                    this.cboHangmog_code1.SetDataValue(insulin_drug1);
                    this.cboHangmog_code2.SetDataValue(insulin_drug2);
                    this.cboHangmog_code3.SetDataValue(insulin_drug3);
                    this.cboHangmog_code4.SetDataValue(insulin_drug4);

                    this.emkSurayng1.Text = insulin_drug1_suryang;
                    this.emkSurayng2.Text = insulin_drug2_suryang;
                    this.emkSurayng3.Text = insulin_drug3_suryang;
                    this.emkSurayng4.Text = insulin_drug4_suryang;
                }
                #endregion


                #region grdNUR0115 チェックボックス適用
                if (this.grdNUR0115.Visible == true)
                {
                    if (grdDirectDetail.RowCount > 0)
                    {
                        for (int i = 0; i < grdNUR0115.RowCount; i++)
                        {
                            string hangmog_code = grdNUR0115.GetItemString(i, "hangmog_code");
                            for (int j = 0; j < grdDirectDetail.RowCount; j++)
                            {
                                if (   hangmog_code == grdDirectDetail.GetItemString(j, "hangmog_code")
                                    && this.mSelectInput == grdDirectDetail.GetItemString(j, "input_gubun"))
                                {
                                    foreach (XEditGridCell info in this.grdDirectDetail.CellInfos)
                                    {
                                        if (this.grdNUR0115.CellInfos.Contains(info.CellName))
                                        {
                                            if (this.grdDirectDetail.GetItemString(j, info.CellName) != "")
                                                this.grdNUR0115.SetItemValue(i, info.CellName, this.grdDirectDetail.GetItemString(j, info.CellName));
                                        }
                                    }
                                    grdNUR0115.SetItemValue(i, "select_order", "Y");

                                    grdNUR0115.LayoutTable.Rows[i].RejectChanges();

                                    //grdNUR0115.SetItemValue(i, "select_order", "Y");
                                }
                            }
                        }
                    }
                    this.grdNUR0115.Enabled = true;
                }

                if (this.grdNUR0115_2.Visible == true)
                {
                    if (grdDirectDetail.RowCount > 0)
                    {
                        for (int i = 0; i < grdNUR0115_2.RowCount; i++)
                        {
                            string hangmog_code = grdNUR0115_2.GetItemString(i, "hangmog_code");
                            for (int j = 0; j < grdDirectDetail.RowCount; j++)
                            {
                                if (   hangmog_code == grdDirectDetail.GetItemString(j, "hangmog_code")
                                    && this.mSelectInput == grdDirectDetail.GetItemString(j, "input_gubun"))
                                {
                                    foreach (XEditGridCell info in this.grdDirectDetail.CellInfos)
                                    {
                                        if (this.grdNUR0115_2.CellInfos.Contains(info.CellName))
                                        {
                                            if (this.grdDirectDetail.GetItemString(j, info.CellName) != "")
                                                this.grdNUR0115_2.SetItemValue(i, info.CellName, this.grdDirectDetail.GetItemString(j, info.CellName));
                                        }
                                    }
                                    grdNUR0115_2.SetItemValue(i, "select_order", "Y");
                                    grdNUR0115_2.LayoutTable.Rows[i].RejectChanges();
                                    //grdNUR0115_2.SetItemValue(i, "select_order", "Y");
                                }
                            }
                        }
                    }
                    this.grdNUR0115_2.Enabled = true;
                }

                if (this.pnlDetail_2.Visible == true)
                {
                    this.pnlDetail_2_sub.Enabled = true;
                }

                if (this.pnlDetail_3.Visible == true)
                {
                    this.pnlDetail_3_sub.Enabled = true;
                }
                #endregion

                if (btn.Tag.ToString() == "4")
                {
                    this.pnlDirect_sub.Enabled = true;
                }

                #region comment受け継ぎ
                this.grdDirectData.SetItemValue(this.grdDirectData.CurrentRowNumber, "direct_text", comment);
                txtDirect_text.Text = comment;
                #endregion
            }
        }

        private void object_EnabledChanged(object sender, EventArgs e)
        {
            //Control ctl = sender as Control;

            //if (ctl.Visible == true)
            //    this.txtDirect_text.Enabled = ctl.Enabled;
        }

        private void grdNUR0115_QueryEnd(object sender, QueryEndEventArgs e)
        {
            XEditGrid grd = sender as XEditGrid;

            for (int i = 0; i < grd.RowCount; i++)
            {
                if (grd.GetItemString(i, "bom_yn").Equals("P"))
                {
                    grd[i, "child_gubun"].Image = ImageList.Images[2];
                }
                else if (grd.GetItemString(i, "bom_yn").Equals("C"))
                {
                    grd[i, "child_gubun"].Image = ImageList.Images[3];
                }
            }
        }

        private void grdNUR0115_MouseDown(object sender, MouseEventArgs e)
        {
            XEditGrid grd = sender as XEditGrid;

            if (e.Button == MouseButtons.Left)
            {
                int parentRow = -1;

                string childGubun = grd.GetItemString(grd.CurrentRowNumber, "bom_yn");

                if (grd.GetItemString(grd.CurrentRowNumber, "bom_yn").Equals("C"))
                {
                    for (int i = grd.CurrentRowNumber; i > -1; i--)
                    {
                        if (grd.GetItemString(i, "bom_yn").Equals("P"))
                        {
                            grd.SelectRow(i);
                            parentRow = i + 1;
                            break;
                        }
                    }

                    for (int i = parentRow; i < grd.RowCount; i++)
                    {
                        if (grd.GetItemString(i, "bom_yn") == "C")
                        {
                            grd.SelectRow(i);
                        }
                        else if ((grd.GetItemString(i, "bom_yn").Equals("P")))
                        {
                            return;
                        }
                    }
                }
                else
                {
                    grd.SelectRow(grd.CurrentRowNumber);

                    for (int i = grd.CurrentRowNumber + 1; i < grd.RowCount; i++)
                    {
                        if (grd.GetItemString(i, "bom_yn").Equals("C"))
                        {
                            grd.SelectRow(i);
                        }
                        else if ((grd.GetItemString(i, "bom_yn").Equals("P")))
                        {
                            return;
                        }
                    }
                }
            }
        }

    }
}