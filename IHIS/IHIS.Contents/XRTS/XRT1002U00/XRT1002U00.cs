using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using IHIS.Framework;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Arguments.Xrts;
using IHIS.CloudConnector.Contracts.Models.Xrts;
using IHIS.CloudConnector.Contracts.Results.Xrts;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.XRTS.Properties;

namespace IHIS.XRTS
{
    public partial class XRT1002U00 : IHIS.Framework.XScreen
    {
        #region Fields
        private string mHospCode;
        private string mDoctor;
        private string mBunho;
        private string mOrderDate;
        private string mFkOcs;
        private string mInOutGubun;
        private string mHangmogCode;
        private string mReadOnly = "N";
        private string mPrintOnly = "Y";
        private string mFkOut1001 = "";
        private string mFkInp1001 = "";
        private string mJundalPart = "";
        private string xray_gubun = "";
        private string old_gumsa_mokjuk = "";
        private string old_xray_method = "";
        private string old_pandok_request_yn = "";
        #endregion

        #region Constructor
        /// <summary>
        /// XRT1002U00
        /// </summary>
        public XRT1002U00()
        {
            try
            {
                InitializeComponent();

                // updated by Cloud
                InitializeCloud();
            }
            catch /*(Exception x)*/
            {
                //XMessageBox.Show(x.StackTrace + "----" + x.Message);
            }
        }
        #endregion

        #region Events

        private void btnList_ButtonClick(object sender, ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Query:
                    e.IsBaseCall = false;
                    this.dsvRequestData.QueryLayout();
                    this.grdPaStatus.QueryLayout(false);
                    SetReadOnly();

                    break;
                case FunctionType.Update:
                    e.IsBaseCall = false;
                    this.grdXrayMethod.ResetUpdate();

                    if (mReadOnly == "Y")
                        return;

                    SetMsg("");
                    if (PaStatusCheck())
                    {
                        try
                        {
                            //Service.BeginTransaction();

                            //if (!XRT1002_IU())
                            //    throw new Exception();

                            //if (!OCS1801_IU())
                            //    throw new Exception();

                            //Service.CommitTransaction();

                            // updated by Cloud
                            if (!DoUpdate()) throw new Exception();

                            SetMsg(Resources.XMsg00001);

                            if (this.mPrintOnly == "Y")
                            {
                                //조사록 출력
                                //PrintOrder();
                                PrintOrderByJudalPart();
                            }
                        }
                        catch
                        {
                            //Service.RollbackTransaction();
                            XMessageBox.Show(Resources.XMsg00002 + Service.ErrFullMsg, Resources.XMsg00003, MessageBoxIcon.Error);
                            return;
                        }
                        //
                        this.btnList.PerformClick(FunctionType.Query);
                        this.Close();
                    }
                    break;

                case FunctionType.Close:

                    this.grdXrayMethod.ResetUpdate();
                    break;

                default:
                    break;
            }
        }

        private void XRT1002U00_ScreenOpen(object sender, XScreenOpenEventArgs e)
        {
            this.mHospCode = EnvironInfo.HospCode;
            this.mPrintOnly = "N";

            if (this.OpenParam != null)
            {
                this.mDoctor = this.OpenParam["doctor"].ToString();
                this.mBunho = this.OpenParam["bunho"].ToString();
                this.mOrderDate = this.OpenParam["order_date"].ToString();
                this.mFkOcs = this.OpenParam["pkocskey"].ToString();
                this.mInOutGubun = this.OpenParam["in_out_gubun"].ToString();
                this.mHangmogCode = this.OpenParam["hangmog_code"].ToString();
                this.mReadOnly = this.OpenParam["isReadOnly"].ToString();
                this.mFkOut1001 = this.OpenParam["naewon_key"].ToString();
                this.mFkInp1001 = this.OpenParam["naewon_key"].ToString();
                this.mJundalPart = this.OpenParam["jundal_part"].ToString();


                if (this.OpenParam["print_only"] != null)
                    this.mPrintOnly = this.OpenParam["print_only"].ToString();

                if (this.mPrintOnly == "")
                    this.mPrintOnly = "N";

                this.paInfoBox.SetPatientID(mBunho);

                lbBunho.Text = mBunho;
                lbSuname.Text = paInfoBox.SuName;
                lbSex.Text = paInfoBox.Sex;
                lbAge.Text = paInfoBox.YearAge.ToString();
                lbOrderDate.Text = mOrderDate;

                //라디오 버튼 부하 내퓖E표시
                //CreateBuha();                

                if (this.mPrintOnly == "Y")
                {
                    this.ParentForm.WindowState = FormWindowState.Minimized;
                    //조사록 출력    
                    //PrintOrder(); 
                    PrintOrderByJudalPart();
                }
                else
                {
                    this.ParentForm.WindowState = FormWindowState.Normal;
                    //의뢰 데이터 조회
                    this.dsvRequestData.QueryLayout();

                    //촬영구분 데이터 조회
                    this.dsvXrayGubun.QueryLayout();

                    xray_gubun = dsvXrayGubun.GetItemValue("xray_gubun").ToString();
                    string hangmog_name = dsvXrayGubun.GetItemValue("xray_name").ToString();

                    lbHangmogName.Text = hangmog_name;
                    if (xray_gubun != "C")
                    {
                        this.ParentForm.Size = new Size(ParentForm.Size.Width - pnlCTMethod.Size.Width, ParentForm.Size.Height);
                        //this.Refresh();
                        //this.txtGumsaMokjuk.Size = new Size(txtGumsaMokjuk.Size.Width, txtGumsaMokjuk.Size.Height + 25);
                        //this.txtXrayMethod.Visible = false;
                        //this.lbXrayMethod.Visible = false;
                        this.pnlCTMethod.Dock = System.Windows.Forms.DockStyle.None;
                        this.pnlCTMethod.Visible = false;
                        this.splXrayInfo.Visible = false;
                        this.pnlXrayInfo.Dock = System.Windows.Forms.DockStyle.Left;
                        //this.pnlGrd.Visible = false;

                        //this.pnlXrayMethod.Size = new Size(308,140);
                    }

                    //핵의학 오큱E의뢰시 부하 항툈E체크(방사선 마스터에 없으므로 NULL)
                    //if (TypeCheck.IsNull(xray_gubun))
                    //{
                    //    rbtBuha1.Visible = true;
                    //    rbtBuha2.Visible = true;
                    //}

                    //부작퓖E데이터 조회
                    LoadComments();

                    //촬영방법 데이터 조회
                    this.grdXrayMethod.QueryLayout(false);

                    //환자상태기준정보조회
                    this.dsvLDOCS0801.QueryLayout(true);

                    //환자상태 조회
                    this.grdPaStatus.QueryLayout(false);

                    //독영 컨트롤 활성화 여부 체크
                    SetRequestYn();

                    //is read only mode??
                    SetReadOnly();
                }
            }
            else
            {
                //this.Close();
            }
        }

        private void tabControl_SelectionChanged(object sender, EventArgs e)
        {
            this.grdComment3.QueryLayout(false);
        }

        private void rbt_Click(object sender, System.EventArgs e)
        {
            RadioButton rbt = sender as RadioButton;

            foreach (object obj in ((Panel)rbt.Parent).Controls)
            {
                if (obj.GetType().ToString().IndexOf("RadioButton") >= 0)
                {
                    if (((RadioButton)obj).Checked)
                    {
                        ((RadioButton)obj).ForeColor = Color.LightSalmon;
                        ((RadioButton)obj).Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));

                        string pat_status = ((RadioButton)obj).Tag.ToString().Split('|')[0];
                        string pat_status_code = ((RadioButton)obj).Tag.ToString().Split('|')[1];

                        for (int i = 0; i < grdPaStatus.RowCount; i++)
                        {
                            if (grdPaStatus.GetItemString(i, "pat_status") == pat_status)
                                this.grdPaStatus.SetItemValue(i, "pat_status_code", pat_status_code);
                        }

                    }
                    else
                    {
                        ((RadioButton)obj).ForeColor = Color.Black;
                        ((RadioButton)obj).Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
                    }
                }
            }
        }

        private void dsvBuhaGubun_QueryStarting(object sender, CancelEventArgs e)
        {
            dsvBuhaGubun.SetBindVarValue("f_code_type", "R09");
            dsvBuhaGubun.SetBindVarValue("f_hosp_code", this.mHospCode);
        }

        private void dsvRequestData_QueryStarting(object sender, CancelEventArgs e)
        {
            dsvRequestData.SetBindVarValue("f_fkocs", this.mFkOcs);
            dsvRequestData.SetBindVarValue("f_hosp_code", this.mHospCode);
        }

        private void dsvXrayGubun_QueryStarting(object sender, CancelEventArgs e)
        {
            dsvXrayGubun.SetBindVarValue("f_code", this.mHangmogCode);
            dsvXrayGubun.SetBindVarValue("f_hosp_code", this.mHospCode);
        }

        private void dsvSideEffect_QueryStarting(object sender, CancelEventArgs e)
        {
            dsvSideEffect.SetBindVarValue("f_bunho", this.mBunho);
            dsvSideEffect.SetBindVarValue("f_hosp_code", this.mHospCode);
        }

        private void grdXrayMethod_QueryStarting(object sender, CancelEventArgs e)
        {
            if (xray_gubun == "C")
                grdXrayMethod.SetBindVarValue("f_code_type", "CT_METHOD");
            else
                grdXrayMethod.SetBindVarValue("f_code_type", "CR_METHOD");

            grdXrayMethod.SetBindVarValue("f_hosp_code", this.mHospCode);
        }

        private void dsvLDOCS0801_QueryStarting(object sender, CancelEventArgs e)
        {
            dsvLDOCS0801.SetBindVarValue("f_hangmog_code", this.mHangmogCode);
            dsvLDOCS0801.SetBindVarValue("f_hosp_code", this.mHospCode);
        }

        private void grdPaStatus_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdPaStatus.SetBindVarValue("f_hosp_code", this.mHospCode);
            this.grdPaStatus.SetBindVarValue("f_hangmog_code", this.mHangmogCode);
            this.grdPaStatus.SetBindVarValue("f_bunho", this.mBunho);
        }

        private void grdPaStatus_QueryEnd(object sender, QueryEndEventArgs e)
        {
            PatStatusDisplayData();
        }

        private void dsvRequestData_QueryEnd(object sender, QueryEndEventArgs e)
        {
            old_gumsa_mokjuk = dsvRequestData.GetItemValue("gumsa_mokjuk").ToString();
            old_xray_method = dsvRequestData.GetItemValue("xray_method").ToString();
            old_pandok_request_yn = dsvRequestData.GetItemValue("pandok_request_yn").ToString();

            SetRequestYn();

            string buha_gubun = dsvRequestData.GetItemValue("buha_gubun").ToString();

            //if (rbtBuha1.Tag != null)
            //{
            //if (rbtBuha1.Tag.ToString() == buha_gubun)
            //{
            //    rbtBuha1.Checked = true;
            //}
            //else
            //{
            //    rbtBuha2.Checked = true;
            //}
            //}
        }

        private void grdXrayMethod_ItemValueChanging(object sender, ItemValueChangingEventArgs e)
        {
            if (e.ChangeValue.ToString() == "Y")
            {
                string text = txtXrayMethod.GetDataValue();
                if (text.Trim().Length == 0)
                    text = e.DataRow["method"].ToString();
                else
                    text = text + ", " + e.DataRow["method"].ToString();

                txtXrayMethod.SetDataValue(text);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!txtGumsaMokjuk.Enabled)
                return;

            #region deleted by Cloud
//            string cmdDelete = string.Empty;
//            BindVarCollection bindValDelete = new BindVarCollection();

//            cmdDelete = @"DELETE XRT1002
//                           WHERE FKOCS       = :f_fkocs
//                             AND HOSP_CODE   = :f_hosp_code";

//            bindValDelete.Add("f_fkocs", this.mFkOcs);
//            bindValDelete.Add("f_hosp_code", this.mHospCode);

//            Service.ExecuteNonQuery(cmdDelete, bindValDelete);

//            // DB 처리 성컖E
//            if (Service.ErrCode == 0)
//            {

//            }
//            // DB 처리 실패
//            else
//            {
//                XMessageBox.Show(Service.ErrFullMsg);
//            }
            #endregion

            // updated by Cloud
            XRT1002U00BtnDeleteClickArgs args = new XRT1002U00BtnDeleteClickArgs();
            args.Fkocs = this.mFkOcs;
            UpdateResult res = CloudService.Instance.Submit<UpdateResult, XRT1002U00BtnDeleteClickArgs>(args);

            if (res.ExecutionStatus != ExecutionStatus.Success)
            {
                XMessageBox.Show(Service.ErrFullMsg);
            }

            this.dsvRequestData.QueryLayout();
        }

        private void grdComment1_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdComment1.SetBindVarValue("f_hosp_code", this.mHospCode);
            this.grdComment1.SetBindVarValue("f_bunho", paInfoBox.BunHo);
        }

        private void grdComment2_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdComment2.SetBindVarValue("f_hosp_code", this.mHospCode);
            this.grdComment2.SetBindVarValue("f_bunho", paInfoBox.BunHo);
        }

        private void grdComment3_QueryStarting(object sender, CancelEventArgs e)
        {
            string order_date = tabControl.SelectedTab.Title;
            this.grdComment3.SetBindVarValue("f_hosp_code", this.mHospCode);
            this.grdComment3.SetBindVarValue("f_bunho", paInfoBox.BunHo);
            this.grdComment3.SetBindVarValue("f_order_date", order_date);
        }

        private void layOrderDate_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layOrderDate.SetBindVarValue("f_hosp_code", this.mHospCode);
            this.layOrderDate.SetBindVarValue("f_bunho", paInfoBox.BunHo);
        }

        private void btnPrintRe_Click(object sender, EventArgs e)
        {
            //조사록 출력
            //PrintOrder(); 

            PrintOrderByJudalPart();
        }

        private void XRT1002U00_Closing(object sender, CancelEventArgs e)
        {
            if (!CheckClosing())
            {
                DialogResult dr = XMessageBox.Show(Resources.XMsg00004 +
                                                   Resources.XMsg00005, Resources.XMsg0006, MessageBoxButtons.YesNoCancel, MessageBoxDefaultButton.Button3, MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        #region deleted by Cloud
                        //Service.BeginTransaction();

                        //if (!XRT1002_IU())
                        //    throw new Exception();

                        //if (!OCS1801_IU())
                        //    throw new Exception();

                        //Service.CommitTransaction();
                        #endregion

                        // updated by Cloud
                        if (!DoUpdate()) throw new Exception();

                        SetMsg(Resources.XMsg00001);

                        if (this.mPrintOnly == "Y")
                        {
                            //조사록 출력
                            //PrintOrder();
                            PrintOrderByJudalPart();
                        }
                    }
                    catch
                    {
                        //Service.RollbackTransaction();
                        XMessageBox.Show(Resources.XMsg00002 + Service.ErrFullMsg, Resources.XMsg00003, MessageBoxIcon.Error);
                        e.Cancel = true;
                        return;
                    }
                }
                else if (dr == DialogResult.No)
                {

                }
                else if (dr == DialogResult.Cancel)
                {
                    e.Cancel = true;
                    return;
                }
            }
        }

        #endregion

        #region Methods(private)

        private void SetReadOnly()
        {
            if (mReadOnly == "Y")
            {
                foreach (Control aPnl in pnlPatStatus.Controls)
                {
                    if (aPnl is Panel)
                    {
                        foreach (Control aCtl in ((Panel)aPnl).Controls)
                        {
                            if (aCtl is RadioButton)
                            {
                                ((RadioButton)aCtl).Enabled = false;
                            }
                        }
                    }
                }

                this.grdXrayMethod.ReadOnly = true;
                this.txtGumsaMokjuk.Enabled = false;
                this.txtXrayMethod.Enabled = false;
                this.cbxRequestYn.Enabled = false;
                rbtBuha1.Enabled = false;
                rbtBuha2.Enabled = false;
            }
        }

        private void CreateBuha()
        {
            //this.dsvBuhaGubun.QueryLayout(true);

            //for (int i = 0; i < dsvBuhaGubun.RowCount; i++)
            //{
            //    switch (i)
            //    {
            //        case 0:
            //            rbtBuha1.Text = dsvBuhaGubun.GetItemString(i, "code_name");
            //            rbtBuha1.Tag = dsvBuhaGubun.GetItemString(i, "code");
            //            break;
            //        case 1:
            //            rbtBuha2.Text = dsvBuhaGubun.GetItemString(i, "code_name");
            //            rbtBuha2.Tag = dsvBuhaGubun.GetItemString(i, "code");
            //            break;
            //        default:
            //            break;
            //    }
            //}
        }

        private void LoadComments()
        {
            this.grdComment1.QueryLayout(false);
            this.grdComment2.QueryLayout(false);

            this.layOrderDate.QueryLayout(true);
            if (this.layOrderDate.RowCount > 0)
            {
                TabCreate();
                this.grdComment3.QueryLayout(false);
            }
        }

        private void TabCreate()
        {
            //this.dsvSideEffect.QueryLayout(true);

            // 텝 페이햨E생성시 첫번째 페이지가 선택된것으로 간주된다.
            // 따라서 픸E셉똑린?되므로 잠시 이벤트를 없애놓음
            this.tabControl.SelectionChanged -= new System.EventHandler(this.tabControl_SelectionChanged);

            // 텝 페이햨E생성
            for (int i = 0; i < layOrderDate.RowCount; i++)
            {
                string xray_date = layOrderDate.GetItemString(i, "order_date");

                IHIS.X.Magic.Controls.TabPage tabPage =
                    new IHIS.X.Magic.Controls.TabPage(layOrderDate.GetItemString(i, "order_date"));
                tabPage.Tag = i;
                tabControl.TabPages.Add(tabPage);
            }

            this.tabControl.SelectionChanged += new System.EventHandler(this.tabControl_SelectionChanged);
        }

        private void SetRequestYn()
        {
            string ls = dsvXrayGubun.GetItemValue("request_yn").ToString();

            if (dsvXrayGubun.GetItemValue("request_yn").ToString() == "Y")
            {
                cbxRequestYn.SetDataValue("Y");
                cbxRequestYn.Enabled = false;
            }
            else
            {
                cbxRequestYn.Enabled = true;
            }
        }

        private void PatStatusDisplayData()
        {
            this.pnlPatStatus.Controls.Clear();

            if (this.grdPaStatus.RowCount == 0) return;

            try
            {
                Cursor.Current = System.Windows.Forms.Cursors.WaitCursor; // 마퓖E?모래시컖E

                pnlPatStatus.SuspendLayout();

                Panel pnlRow = new System.Windows.Forms.Panel();
                Label lblPatStatus;
                RadioButton rbtPatStatusCode;

                string oldPatStatus = "";

                int rowLocationY = 5;
                int rowIndex = 0;
                int rowWidth = 0;

                int rbtLocationX = 295;

                for (int i = 0; i < this.dsvLDOCS0801.RowCount; i++)
                {
                    if (oldPatStatus != dsvLDOCS0801.GetItemString(i, "pat_status"))
                    {
                        //Row가 바뀔때 Row Panel사이짊濤 조정한다.
                        if (i != 0)
                        {
                            //pnlRow.Size = new Size( rbtLocationX, pnlRow.Size.Height);
                            if (rbtLocationX > rowWidth)
                                rowWidth = rbtLocationX;
                        }

                        //Row Container 생성
                        pnlRow = new System.Windows.Forms.Panel();
                        pnlRow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                        pnlRow.BackColor = System.Drawing.Color.Honeydew;
                        pnlRow.Location = new System.Drawing.Point(10, rowLocationY);
                        pnlRow.Name = "pnl_" + i.ToString();
                        pnlRow.Size = new System.Drawing.Size(1044, 25);
                        pnlRow.TabIndex = 0;
                        pnlRow.Tag = rowIndex;

                        this.pnlPatStatus.Controls.Add(pnlRow);

                        //Pat status 뫄夕 Label
                        lblPatStatus = new System.Windows.Forms.Label();
                        lblPatStatus.Dock = System.Windows.Forms.DockStyle.Left;
                        lblPatStatus.Location = new System.Drawing.Point(0, 0);
                        //lblPatStatus.Location = new System.Drawing.Point(10, rowLocationY);
                        lblPatStatus.Name = "lbl_" + dsvLDOCS0801.GetItemString(i, "pat_status");
                        lblPatStatus.Size = new System.Drawing.Size(180, 25);
                        lblPatStatus.TabIndex = 0;
                        lblPatStatus.Text = "   " + dsvLDOCS0801.GetItemString(i, "pat_status_name");

                        if (dsvLDOCS0801.GetItemString(i, "indispensable_yn") == "Y")
                            lblPatStatus.ForeColor = Color.Red;
                        else
                            lblPatStatus.ForeColor = Color.MediumSlateBlue;

                        //lblPatStatus.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
                        lblPatStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        lblPatStatus.Tag = dsvLDOCS0801.GetItemString(i, "pat_status");
                        pnlRow.Controls.Add(lblPatStatus);

                        //pnlPatStatus.Controls.Add(lblPatStatus);

                        //다음 Row위치 + 5
                        rowLocationY = rowLocationY + 30;
                        rowIndex++;

                        //radio item Location 초기화
                        rbtLocationX = 185;

                        oldPatStatus = dsvLDOCS0801.GetItemString(i, "pat_status");
                    }

                    rbtPatStatusCode = new System.Windows.Forms.RadioButton();
                    rbtPatStatusCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                    rbtPatStatusCode.Location = new System.Drawing.Point(rbtLocationX, 0);
                    rbtPatStatusCode.Name = "rbt_" + dsvLDOCS0801.GetItemString(i, "pat_status") + dsvLDOCS0801.GetItemString(i, "pat_status_code");
                    rbtPatStatusCode.Size = new System.Drawing.Size(90, 25);
                    rbtPatStatusCode.TabIndex = 0;
                    rbtPatStatusCode.Text = dsvLDOCS0801.GetItemString(i, "pat_status_code_name");
                    rbtPatStatusCode.Tag = dsvLDOCS0801.GetItemString(i, "pat_status") + "|" + dsvLDOCS0801.GetItemString(i, "pat_status_code");
                    rbtPatStatusCode.Cursor = System.Windows.Forms.Cursors.Hand;
                    rbtPatStatusCode.Click += new System.EventHandler(this.rbt_Click);
                    if (this.grdPaStatus.LayoutTable.Select("pat_status = '" + dsvLDOCS0801.GetItemString(i, "pat_status") + "' and pat_status_code = '" + dsvLDOCS0801.GetItemString(i, "pat_status_code") + "' ", "").Length > 0)
                    {
                        rbtPatStatusCode.Checked = true;
                        rbtPatStatusCode.ForeColor = Color.LightSalmon;
                        rbtPatStatusCode.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
                    }

                    pnlRow.Controls.Add(rbtPatStatusCode);

                    rbtLocationX = rbtLocationX + 95;
                }

                if (rbtLocationX > rowWidth)
                    rowWidth = rbtLocationX;

                if (rowWidth < pnlPatStatus.Width - 30)
                    rowWidth = pnlPatStatus.Width - 30;

                //row panel을 맞춘다.
                foreach (object obj in pnlPatStatus.Controls)
                {
                    if (obj.GetType().ToString().IndexOf("Panel") >= 0)
                        ((Panel)obj).Size = new Size(rowWidth, ((Panel)obj).Size.Height);
                }

                if (this.grdPaStatus.RowCount == 0)
                    pnlPatStatus.Enabled = false;
                else
                    pnlPatStatus.Enabled = true;


                pnlPatStatus.ResumeLayout();

            }
            finally
            {
                Cursor.Current = System.Windows.Forms.Cursors.Default; // 마퓖E?원상복귀
            }
        }

        //true : 필펯E항목이 입력된 상태
        //false: 필펯E항목이 입력되햨E않은 상태
        private bool PaStatusCheck()
        {
            for (int i = 0; i < grdPaStatus.RowCount; i++)
            {
                if (grdPaStatus.GetItemString(i, "indispensable") == "Y" && TypeCheck.IsNull(grdPaStatus.GetItemString(i, "pat_status_code")))
                {
                    //grdPaStatus.SetFocusToItem(i,"pat_status_code");

                    string msg = Resources.XMsg00007;
                    string caption = Resources.XMsg00008;

                    XMessageBox.Show(msg, caption);
                    return false;
                }
            }
            return true;
        }

        #region deleted by Cloud
//        private bool XRT1002_IU()
//        {
//            string cmdText = string.Empty;
//            object retVal = null;
//            BindVarCollection bindVals = new BindVarCollection();

//            cmdText = @"SELECT 'Y'
//                          FROM DUAL
//                         WHERE EXISTS ( SELECT 'X'
//                                          FROM XRT1002 A
//                                         WHERE A.FKOCS     = :f_fkocs
//                                           AND A.HOSP_CODE = :f_hosp_code)";

//            bindVals.Add("f_fkocs", this.mFkOcs);
//            bindVals.Add("f_hosp_code", this.mHospCode);

//            retVal = Service.ExecuteScalar(cmdText, bindVals);

//            if (Service.ErrCode == 0)
//            {
//                if (retVal != null && retVal.ToString().Equals("Y"))
//                {
//                    string cmdUpdate = string.Empty;
//                    BindVarCollection bindValUpdate = new BindVarCollection();

//                    cmdUpdate = @"UPDATE XRT1002
//                                     SET UPD_ID            = :f_upd_id
//                                       , UPD_DATE          = SYSDATE
//                                       , IN_OUT_GUBUN      = :f_in_out_gubun     
//                                       , HANGMOG_CODE      = :f_hangmog_code     
//                                       , BUNHO             = :f_bunho            
//                                       , GUMSA_MOKJUK      = :f_gumsa_mokjuk     
//                                       , XRAY_METHOD       = :f_xray_method      
//                                       , PANDOK_REQUEST_YN = :f_pandok_request_yn
//                                   WHERE FKOCS             = :f_fkocs            
//                                     AND HOSP_CODE         = :f_hosp_code";

//                    bindValUpdate.Add("f_upd_id", this.mDoctor);
//                    bindValUpdate.Add("f_in_out_gubun", this.mInOutGubun);
//                    bindValUpdate.Add("f_hangmog_code", this.mHangmogCode);
//                    bindValUpdate.Add("f_bunho", this.mBunho);
//                    bindValUpdate.Add("f_gumsa_mokjuk", txtGumsaMokjuk.Text);
//                    bindValUpdate.Add("f_xray_method", txtXrayMethod.GetDataValue());
//                    bindValUpdate.Add("f_pandok_request_yn", cbxRequestYn.GetDataValue());
//                    bindValUpdate.Add("f_fkocs", this.mFkOcs);
//                    bindValUpdate.Add("f_hosp_code", this.mHospCode);

//                    Service.ExecuteNonQuery(cmdUpdate, bindValUpdate);

//                    // DB 처리 성컖E
//                    if (Service.ErrCode == 0)
//                    {

//                    }
//                    // DB 처리 실패
//                    else
//                    {
//                        return false;
//                        //XMessageBox.Show(Service.ErrFullMsg);
//                    }
//                }
//                else
//                {
//                    string cmdInsert = string.Empty;
//                    BindVarCollection bindValInsert = new BindVarCollection();

//                    cmdInsert = @"INSERT INTO XRT1002 
//                                       ( SYS_DATE         , UPD_ID           , UPD_DATE
//                                       , IN_OUT_GUBUN     , HANGMOG_CODE     , BUNHO            
//                                       , GUMSA_MOKJUK     , XRAY_METHOD      , PANDOK_REQUEST_YN
//                                       , FKOCS            , HOSP_CODE        ) 
//                                  VALUES 
//                                       ( SYSDATE          , :f_user_id       , SYSDATE
//                                       , :f_in_out_gubun  , :f_hangmog_code  , :f_bunho            
//                                       , :f_gumsa_mokjuk  , :f_xray_method   , :f_pandok_request_yn
//                                       , :f_fkocs         , :f_hosp_code     )";

//                    bindValInsert.Add("f_upd_id", this.mDoctor);
//                    bindValInsert.Add("f_in_out_gubun", this.mInOutGubun);
//                    bindValInsert.Add("f_hangmog_code", this.mHangmogCode);
//                    bindValInsert.Add("f_bunho", this.mBunho);
//                    bindValInsert.Add("f_gumsa_mokjuk", txtGumsaMokjuk.Text);
//                    bindValInsert.Add("f_xray_method", txtXrayMethod.GetDataValue());
//                    bindValInsert.Add("f_pandok_request_yn", cbxRequestYn.GetDataValue());
//                    bindValInsert.Add("f_fkocs", this.mFkOcs);
//                    bindValInsert.Add("f_hosp_code", this.mHospCode);

//                    Service.ExecuteNonQuery(cmdInsert, bindValInsert);

//                    // DB 처리 성컖E
//                    if (Service.ErrCode == 0)
//                    {

//                    }
//                    // DB 처리 실패
//                    else
//                    {
//                        return false;
//                        //XMessageBox.Show(Service.ErrFullMsg);
//                    }
//                }
//            }
//            else
//            {
//                return false;
//                //XMessageBox.Show(Service.ErrFullMsg);
//            }
//            return true;
//        }
        #endregion

        #region deleted by Cloud
//        private bool OCS1801_IU()
//        {
//            foreach (DataRow row in grdPaStatus.LayoutTable.Rows)
//            {
//                string cmdText = string.Empty;
//                object retVal = null;
//                BindVarCollection bindVals = new BindVarCollection();

//                cmdText = @"SELECT 'Y'
//                              FROM DUAL
//                             WHERE EXISTS ( SELECT 'X'
//                                              FROM OCS1801 A
//                                             WHERE A.BUNHO           = :f_bunho
//                                               AND PAT_STATUS       = :f_pat_status
//                                               AND A.HOSP_CODE       = :f_hosp_code)";

//                bindVals.Add("f_bunho", this.mBunho);
//                bindVals.Add("f_pat_status", row["pat_status"].ToString());
//                //bindVals.Add("f_pat_status_code", row["pat_status_code"].ToString());
//                bindVals.Add("f_hosp_code", this.mHospCode);

//                retVal = Service.ExecuteScalar(cmdText, bindVals);

//                if (Service.ErrCode == 0)
//                {
//                    if (retVal != null && retVal.ToString().Equals("Y"))
//                    {
//                        string cmdUpdate = string.Empty;
//                        BindVarCollection bindValUpdate = new BindVarCollection();

//                        cmdUpdate = @"UPDATE OCS1801
//                                         SET UPD_ID           = :f_upd_id         ,
//                                             UPD_DATE         = SYSDATE           ,
//                                             PAT_STATUS       = :f_pat_status     ,
//                                             PAT_STATUS_CODE  = :f_pat_status_code,
//                                             MENT             = :f_ment           ,
//                                             SEQ              = :f_seq
//                                       WHERE BUNHO            = :f_bunho
//                                         AND PAT_STATUS       = :f_pat_status
//                                         AND HOSP_CODE        = :f_hosp_code";

//                        bindValUpdate.Add("f_upd_id", this.mDoctor);
//                        bindValUpdate.Add("f_pat_status", row["pat_status"].ToString());
//                        bindValUpdate.Add("f_pat_status_code", row["pat_status_code"].ToString());
//                        bindValUpdate.Add("f_ment", row["ment"].ToString());
//                        bindValUpdate.Add("f_seq", row["seq"].ToString());
//                        bindValUpdate.Add("f_bunho", this.mBunho);
//                        bindValUpdate.Add("f_hosp_code", this.mHospCode);

//                        Service.ExecuteNonQuery(cmdUpdate, bindValUpdate);

//                        // DB 처리 성컖E
//                        if (Service.ErrCode == 0)
//                        {

//                        }
//                        // DB 처리 실패
//                        else
//                        {
//                            return false;
//                            //XMessageBox.Show(Service.ErrFullMsg);
//                        }
//                    }
//                    else
//                    {
//                        string cmdInsert = string.Empty;
//                        BindVarCollection bindValInsert = new BindVarCollection();

//                        cmdInsert = @"INSERT INTO OCS1801
//                                                  ( SYS_DATE          , UPD_ID       , UPD_DATE   , BUNHO    , PAT_STATUS    ,
//                                                    PAT_STATUS_CODE   , MENT         , SEQ        , HOSP_CODE )
//                                            VALUES
//                                                  ( SYSDATE           , :f_upd_id    , SYSDATE    , :f_bunho , :f_pat_status ,
//                                                    :f_pat_status_code, :f_ment      , :f_seq     , :f_hosp_code )";

//                        bindValInsert.Add("f_upd_id", this.mDoctor);
//                        bindValInsert.Add("f_pat_status", row["pat_status"].ToString());
//                        bindValInsert.Add("f_pat_status_code", row["pat_status_code"].ToString());
//                        bindValInsert.Add("f_ment", row["ment"].ToString());
//                        bindValInsert.Add("f_seq", row["seq"].ToString());
//                        bindValInsert.Add("f_bunho", this.mBunho);
//                        bindValInsert.Add("f_hosp_code", this.mHospCode);

//                        Service.ExecuteNonQuery(cmdInsert, bindValInsert);

//                        // DB 처리 성컖E
//                        if (Service.ErrCode == 0)
//                        {

//                        }
//                        // DB 처리 실패
//                        else
//                        {
//                            return false;
//                            //XMessageBox.Show(Service.ErrFullMsg);
//                        }
//                    }
//                }
//                else
//                {
//                    return false;
//                    //XMessageBox.Show(Service.ErrFullMsg);
//                }
//            }
//            return true;
//        }
        #endregion

        private void PrintOrderByJudalPart()
        {
            this.layPrintDate.SetBindVarValue("f_hosp_code", this.mHospCode);
            this.layPrintDate.SetBindVarValue("f_in_out_gubun", this.mInOutGubun);
            this.layPrintDate.SetBindVarValue("f_gwa", UserInfo.Gwa);
            this.layPrintDate.SetBindVarValue("f_order_date", this.mOrderDate);
            this.layPrintDate.SetBindVarValue("f_pkocs", this.mFkOcs);
            this.layPrintDate.SetBindVarValue("f_fkout1001", this.mFkOut1001);
            this.layPrintDate.SetBindVarValue("f_fkinp1001", this.mFkInp1001);
            this.layPrintDate.SetBindVarValue("f_jundal_part", this.mJundalPart);
            this.layPrintDate.SetBindVarValue("f_print_only", this.mPrintOnly);
            this.layPrintDate.QueryLayout(true);

            foreach (DataRow row in this.layPrintDate.LayoutTable.Rows)
            {
                this.layPrint.Reset();

                this.layOrderByJundalPart.SetBindVarValue("f_hosp_code", this.mHospCode);
                this.layOrderByJundalPart.SetBindVarValue("f_in_out_gubun", this.mInOutGubun);
                this.layOrderByJundalPart.SetBindVarValue("f_gwa", UserInfo.Gwa);
                this.layOrderByJundalPart.SetBindVarValue("f_order_date", this.mOrderDate);
                this.layOrderByJundalPart.SetBindVarValue("f_pkocs", this.mFkOcs);
                this.layOrderByJundalPart.SetBindVarValue("f_fkout1001", this.mFkOut1001);
                this.layOrderByJundalPart.SetBindVarValue("f_fkinp1001", this.mFkInp1001);
                this.layOrderByJundalPart.SetBindVarValue("f_jundal_part", this.mJundalPart);
                this.layOrderByJundalPart.SetBindVarValue("f_print_only", this.mPrintOnly);

                string print_date = row["print_date"].ToString();
                this.layOrderByJundalPart.SetBindVarValue("f_print_date", print_date);

                this.layOrderByJundalPart.QueryLayout(true);

                if (this.layOrderByJundalPart.RowCount > 0)
                {
                    this.layCPLResult.SetBindVarValue("f_hosp_code", this.mHospCode);
                    this.layCPLResult.SetBindVarValue("f_bunho", this.mBunho);
                    this.layCPLResult.QueryLayout();

                    string hangmog_codes = "";

                    //촬영조건 
                    for (int i = 0; i < this.layOrderByJundalPart.RowCount; i++)
                    {
                        this.layPrint.LayoutTable.ImportRow(this.layOrderByJundalPart.LayoutTable.Rows[i]);

                        hangmog_codes += ", '" + layOrderByJundalPart.GetItemString(i, "xray_code") + "'";

                        this.layXRT0123.SetBindVarValue("f_hosp_code", this.mHospCode);
                        this.layXRT0123.SetBindVarValue("f_buwi_code", layOrderByJundalPart.GetItemString(i, "buwi_code"));
                        this.layXRT0123.SetBindVarValue("f_age", this.lbAge.Text);
                        this.layXRT0123.SetBindVarValue("f_xray_gubun", layOrderByJundalPart.GetItemString(i, "xray_gubun"));
                        this.layXRT0123.QueryLayout();

                        layPrint.SetItemValue(i, "valtage", layXRT0123.GetItemValue("valtage"));
                        layPrint.SetItemValue(i, "cur_electric", layXRT0123.GetItemValue("cur_electric"));
                        layPrint.SetItemValue(i, "time", layXRT0123.GetItemValue("time"));
                        layPrint.SetItemValue(i, "distance", layXRT0123.GetItemValue("distance"));
                        layPrint.SetItemValue(i, "grid", layXRT0123.GetItemValue("grid"));
                        layPrint.SetItemValue(i, "note", layXRT0123.GetItemValue("note"));
                        layPrint.SetItemValue(i, "mas_val", layXRT0123.GetItemValue("mas_val"));

                        layPrint.SetItemValue(i, "cpl_value", this.layCPLResult.GetItemValue("cpl_value").ToString());
                        layPrint.SetItemValue(i, "cpl_date", this.layCPLResult.GetItemValue("cpl_date").ToString());
                    }

                    hangmog_codes = hangmog_codes.Substring(1);

                    #region unused code
                    //                this.layPaStatus.QuerySQL = @"SELECT A.BUNHO                ,
                    //                                                   A.PAT_STATUS           ,
                    //                                                   B.PAT_STATUS_NAME      ,
                    //                                                   NVL(A.PAT_STATUS_CODE,B.DEFAULT_PAT_STATUS_CODE)      ,  /* 디폴트 값 넣어주도록 수정 2008.03.09 김민수 --A.PAT_STATUS_CODE      , */
                    //                                                   NVL(C.PAT_STATUS_CODE_NAME,F.PAT_STATUS_CODE_NAME)    ,  /* 디폴트 값 넣어주도록 수정 2008.03.09 김민수 --C.PAT_STATUS_CODE_NAME , */
                    //                                                   A.MENT                 ,
                    //                                                   E.SEQ                  ,
                    //                                                   E.INDISPENSABLE_YN     ,
                    //                                                   LTRIM(TO_CHAR(NVL(E.SEQ, 99), '00000'))||A.PAT_STATUS CONT_KEY
                    //                                              FROM OCS0802 F,
                    //                                                   OCS0804 E,
                    //                                                   OCS0103 D,
                    //                                                   OCS0802 C,
                    //                                                   OCS0801 B,
                    //                                                   OCS1801 A
                    //                                             WHERE A.HOSP_CODE          = :f_hosp_code
                    //                                               AND B.HOSP_CODE          = A.HOSP_CODE
                    //                                               AND C.HOSP_CODE      (+) = A.HOSP_CODE
                    //                                               AND D.HOSP_CODE          = A.HOSP_CODE
                    //                                               AND E.HOSP_CODE          = A.HOSP_CODE
                    //                                               AND F.HOSP_CODE      (+) = B.HOSP_CODE
                    //                                               AND A.BUNHO              = :f_bunho
                    //                                               AND B.PAT_STATUS         = A.PAT_STATUS
                    //                                               AND C.PAT_STATUS     (+) = A.PAT_STATUS
                    //                                               AND C.PAT_STATUS_CODE(+) = A.PAT_STATUS_CODE
                    //                                               AND D.HANGMOG_CODE       = :f_hangmog_code
                    //                                               AND E.PAT_STATUS_GR      = D.PAT_STATUS_GR
                    //                                               AND E.PAT_STATUS         = A.PAT_STATUS
                    //                                               AND F.PAT_STATUS     (+) = B.PAT_STATUS
                    //                                               AND F.PAT_STATUS_CODE(+) = B.DEFAULT_PAT_STATUS_CODE
                    //                                            UNION ALL
                    //                                            SELECT :f_bunho          BUNHO                          ,
                    //                                                   B.PAT_STATUS                                     ,
                    //                                                   C.PAT_STATUS_NAME                                ,
                    //                                                   C.DEFAULT_PAT_STATUS_CODE    PAT_STATUS_CODE     ,  /* 디폴트 값 넣어주도록 수정 2008.03.09 김민수 --NULL              PAT_STATUS_CODE     ,*/
                    //                                                   D.PAT_STATUS_CODE_NAME       PAT_STATUS_CODE_NAME,  /* 디폴트 값 넣어주도록 수정 2008.03.09 김민수 --NULL              PAT_STATUS_CODE_NAME,*/
                    //                                                   B.MENT                                           ,
                    //                                                   B.SEQ                                            ,
                    //                                                   B.INDISPENSABLE_YN                               ,
                    //                                                   LTRIM(TO_CHAR(NVL(B.SEQ, 99), '00000'))||B.PAT_STATUS CONT_KEY
                    //                                              FROM OCS0802 D,
                    //                                                   OCS0801 C,
                    //                                                   OCS0804 B,
                    //                                                   OCS0103 A
                    //                                             WHERE A.HOSP_CODE          = :f_hosp_code
                    //                                               AND B.HOSP_CODE          = A.HOSP_CODE
                    //                                               AND C.HOSP_CODE          = A.HOSP_CODE
                    //                                               AND D.HOSP_CODE      (+) = C.HOSP_CODE
                    //                                               AND A.HANGMOG_CODE       = :f_hangmog_code
                    //                                               AND B.PAT_STATUS_GR      = A.PAT_STATUS_GR
                    //                                               AND C.PAT_STATUS         = B.PAT_STATUS
                    //                                               AND D.PAT_STATUS     (+) = C.PAT_STATUS
                    //                                               AND D.PAT_STATUS_CODE(+) = C.DEFAULT_PAT_STATUS_CODE
                    //                                               AND NOT EXISTS ( SELECT 'X'
                    //                                                                  FROM OCS1801 D
                    //                                                                 WHERE D.HOSP_CODE  = C.HOSP_CODE
                    //                                                                   AND D.BUNHO      = :f_bunho
                    //                                                                   AND D.PAT_STATUS = B.PAT_STATUS )
                    //                                            ORDER BY 9";
                    #endregion

                    #region deleted by Cloud
//                    this.layPaStatus.QuerySQL = @"SELECT   DISTINCT
//                                                       A.BUNHO                ,
//                                                       A.PAT_STATUS           ,
//                                                       B.PAT_STATUS_NAME      ,
//                                                       NVL(A.PAT_STATUS_CODE,B.DEFAULT_PAT_STATUS_CODE)      ,  /* 디폴트 값 넣어주도록 수정 2008.03.09 김민수 --A.PAT_STATUS_CODE      , */
//                                                       NVL(C.PAT_STATUS_CODE_NAME,F.PAT_STATUS_CODE_NAME)    ,  /* 디폴트 값 넣어주도록 수정 2008.03.09 김민수 --C.PAT_STATUS_CODE_NAME , */
//                                                       A.MENT                 ,
//                                                       E.SEQ                  ,
//                                                       E.INDISPENSABLE_YN     ,
//                                                       LTRIM(TO_CHAR(NVL(E.SEQ, 99), '00000'))||A.PAT_STATUS CONT_KEY
//                                                  FROM OCS0802 F,
//                                                       OCS0804 E,
//                                                       OCS0103 D,
//                                                       OCS0802 C,
//                                                       OCS0801 B,
//                                                       OCS1801 A
//                                                 WHERE A.HOSP_CODE          = :f_hosp_code
//                                                   AND B.HOSP_CODE          = A.HOSP_CODE
//                                                   AND C.HOSP_CODE      (+) = A.HOSP_CODE
//                                                   AND D.HOSP_CODE          = A.HOSP_CODE
//                                                   AND E.HOSP_CODE          = A.HOSP_CODE
//                                                   AND F.HOSP_CODE      (+) = B.HOSP_CODE
//                                                   AND A.BUNHO              = :f_bunho
//                                                   AND B.PAT_STATUS         = A.PAT_STATUS
//                                                   AND C.PAT_STATUS     (+) = A.PAT_STATUS
//                                                   AND C.PAT_STATUS_CODE(+) = A.PAT_STATUS_CODE
//                                                   AND D.HANGMOG_CODE       IN (" + hangmog_codes + @")
//                                                   AND E.PAT_STATUS_GR      = D.PAT_STATUS_GR
//                                                   AND E.PAT_STATUS         = A.PAT_STATUS
//                                                   AND F.PAT_STATUS     (+) = B.PAT_STATUS
//                                                   AND F.PAT_STATUS_CODE(+) = B.DEFAULT_PAT_STATUS_CODE
//                                                UNION ALL
//                                                SELECT DISTINCT
//                                                       :f_bunho          BUNHO                          ,
//                                                       B.PAT_STATUS                                     ,
//                                                       C.PAT_STATUS_NAME                                ,
//                                                       C.DEFAULT_PAT_STATUS_CODE    PAT_STATUS_CODE     ,  /* 디폴트 값 넣어주도록 수정 2008.03.09 김민수 --NULL              PAT_STATUS_CODE     ,*/
//                                                       D.PAT_STATUS_CODE_NAME       PAT_STATUS_CODE_NAME,  /* 디폴트 값 넣어주도록 수정 2008.03.09 김민수 --NULL              PAT_STATUS_CODE_NAME,*/
//                                                       B.MENT                                           ,
//                                                       B.SEQ                                            ,
//                                                       B.INDISPENSABLE_YN                               ,
//                                                       LTRIM(TO_CHAR(NVL(B.SEQ, 99), '00000'))||B.PAT_STATUS CONT_KEY
//                                                  FROM OCS0802 D,
//                                                       OCS0801 C,
//                                                       OCS0804 B,
//                                                       OCS0103 A
//                                                 WHERE A.HOSP_CODE          = :f_hosp_code
//                                                   AND B.HOSP_CODE          = A.HOSP_CODE
//                                                   AND C.HOSP_CODE          = A.HOSP_CODE
//                                                   AND D.HOSP_CODE      (+) = C.HOSP_CODE
//                                                   AND A.HANGMOG_CODE       IN (" + hangmog_codes + @")
//                                                   AND B.PAT_STATUS_GR      = A.PAT_STATUS_GR
//                                                   AND C.PAT_STATUS         = B.PAT_STATUS
//                                                   AND D.PAT_STATUS     (+) = C.PAT_STATUS
//                                                   AND D.PAT_STATUS_CODE(+) = C.DEFAULT_PAT_STATUS_CODE
//                                                   AND NOT EXISTS ( SELECT 'X'
//                                                                      FROM OCS1801 D
//                                                                     WHERE D.HOSP_CODE  = C.HOSP_CODE
//                                                                       AND D.BUNHO      = :f_bunho
//                                                                       AND D.PAT_STATUS = B.PAT_STATUS )
//                                                ORDER BY 9";
                    #endregion

                    // updated by Cloud
                    this.layPaStatus.ExecuteQuery = GetGrdPaStatusForPrintOrder;
                    this.layPaStatus.SetBindVarValue("f_hosp_code", this.mHospCode);
                    this.layPaStatus.SetBindVarValue("f_bunho", this.mBunho);
                    this.layPaStatus.SetBindVarValue("f_hangmog_codes", hangmog_codes);

                    this.layPaStatus.QueryLayout(true);
                    //XMessageBox.Show(layPrint.RowCount.ToString());

                    for (int i = 0; i < this.layPaStatus.RowCount; i++)
                    {
                        int tempInt = i % 2;
                        //double rowCount = (double)(i/2);
                        double tRowNum = Math.Ceiling((double)(i / 2));
                        int rowNum = (int)tRowNum;

                        if (tempInt == 0)
                        {

                            if (this.layPrint.RowCount - 1 < rowNum)
                            {
                                this.layPrint.InsertRow(-1);
                            }
                        }

                        if (tempInt == 0)
                        {
                            layPrint.SetItemValue(rowNum, "pat_status_name", layPaStatus.GetItemString(i, "pat_status_name"));
                            layPrint.SetItemValue(rowNum, "pat_status_code_name", layPaStatus.GetItemString(i, "pat_status_code_name"));
                        }
                        else
                        {
                            layPrint.SetItemValue(rowNum, "pat_status_name2", layPaStatus.GetItemString(i, "pat_status_name"));
                            layPrint.SetItemValue(rowNum, "pat_status_code_name2", layPaStatus.GetItemString(i, "pat_status_code_name"));
                        }
                    }

 //                   dwJubsuPrint.Reset();
                    //XMessageBox.Show(this.layPrint.RowCount.ToString());

                    //조사록
                    for (int i = 0; i < this.layPrint.RowCount; i++)
                    {
                        layPrint.SetItemValue(i, "print_name_flag", "1");
                    }
                    layPrint.AcceptData();
                    layPrint.ResetUpdate();

//                    dwJubsuPrint.FillData(layPrint.LayoutTable);
//                    dwJubsuPrint.Refresh();

                    //return;
                    try
                    {
  //                      dwJubsuPrint.Print(true);
                    }
                    catch (Exception xe)
                    {
                        this.ParentForm.WindowState = FormWindowState.Normal;
                        //https://sofiamedix.atlassian.net/browse/MED-10610
                        //XMessageBox.Show(Resources.XMsg00009 + xe.Message, Resources.XMsg00010, MessageBoxIcon.Information);
                        return;
                    }

 //                   dwJubsuPrint.Reset();
                    //소견서
                    for (int i = 0; i < this.layPrint.RowCount; i++)
                    {
                        layPrint.SetItemValue(i, "print_name_flag", "2");
                    }

                    layPrint.AcceptData();
                    layPrint.ResetUpdate();

 //                   dwJubsuPrint.FillData(layPrint.LayoutTable);
 //                   dwJubsuPrint.Refresh();

                    try
                    {
 //                       dwJubsuPrint.Print(true);
                    }
                    catch (Exception xe)
                    {
                        this.ParentForm.WindowState = FormWindowState.Normal;
                        //https://sofiamedix.atlassian.net/browse/MED-10610
                        //XMessageBox.Show(Resources.XMsg00011 + xe.Message, Resources.XMsg00010, MessageBoxIcon.Information);
                        return;
                    }
                }
                else //조회결과없을경우
                {
                    if (this.mPrintOnly == "N")
                        XMessageBox.Show(Resources.XMsg00012, Resources.XMsg00010, MessageBoxIcon.Information);
                    this.Close();
                    //this.ParentForm.WindowState = FormWindowState.Normal;
                }
            }

            if (this.mPrintOnly == "Y")
            {
                this.Close();
            }

        }

        private void PrintOrder()
        {
            return;

            string gumsaMokjuk = "";
            string xrtComments = "";
            string orderComments = "";

            this.layPrint.Reset();

            this.layPrintOrder.SetBindVarValue("f_hosp_code", this.mHospCode);
            this.layPrintOrder.SetBindVarValue("f_gwa", UserInfo.Gwa);
            this.layPrintOrder.SetBindVarValue("f_order_date", this.mOrderDate);
            this.layPrintOrder.SetBindVarValue("f_pkocs", this.mFkOcs);
            this.layPrintOrder.SetBindVarValue("f_in_out_gubun", this.mInOutGubun);

            this.layPrintOrder.QueryLayout();

            if (!TypeCheck.IsNull(this.layPrintOrder.GetItemValue("bunho")))
            {
                this.layCPLResult.SetBindVarValue("f_hosp_code", this.mHospCode);
                this.layCPLResult.SetBindVarValue("f_bunho", this.mBunho);
                this.layCPLResult.QueryLayout();

                this.layXRT0123.SetBindVarValue("f_hosp_code", this.mHospCode);
                this.layXRT0123.SetBindVarValue("f_buwi_code", layPrintOrder.GetItemValue("buwi_code").ToString());
                this.layXRT0123.SetBindVarValue("f_age", this.lbAge.Text);
                this.layXRT0123.SetBindVarValue("f_xray_gubun", layPrintOrder.GetItemValue("xray_gubun").ToString());
                this.layXRT0123.QueryLayout();

                this.layPaStatus.SetBindVarValue("f_hosp_code", this.mHospCode);
                this.layPaStatus.SetBindVarValue("f_bunho", this.layPrintOrder.GetItemValue("bunho").ToString());
                this.layPaStatus.SetBindVarValue("f_hangmog_code", this.layPrintOrder.GetItemValue("xray_code").ToString());

                this.layPaStatus.QueryLayout(true);

                if (layPaStatus.RowCount == 0)
                {
                    this.layPrint.InsertRow(-1);

                    // CT의 경퓖E?검사목픸E3행이후에 촬영방법을 출력한다.
                    // CT제외의 경퓖E?촬영방법 코멘트 없슴.
                    if (layPrintOrder.GetItemValue("xray_gubun").ToString() == "C")
                        gumsaMokjuk = layPrintOrder.GetItemValue("gumsa_mokjuk2").ToString() + "\n\n\n\n" + "[撮影方法]" + "\n" + layPrintOrder.GetItemValue("xray_method").ToString();
                    else
                        gumsaMokjuk = layPrintOrder.GetItemValue("gumsa_mokjuk2").ToString();

                    // 의사지시의 경퓖E?코멘트 앞에 별표 표시를 한다.
                    orderComments = this.layPrintOrder.GetItemValue("comment").ToString();
                    // 방사선 자체 코멘트
                    xrtComments = this.layPrintOrder.GetItemValue("xrt_comments").ToString();

                    if (orderComments != "")
                        orderComments = "★ " + orderComments;

                    if (xrtComments != "")
                        orderComments = orderComments + "\n\n\n\n" + "[放射線科コメント]" + "\n" + xrtComments;

                    this.layPrint.SetItemValue(0, "bunho", layPrintOrder.GetItemValue("bunho"));
                    layPrint.SetItemValue(0, "suname", layPrintOrder.GetItemValue("suname"));
                    layPrint.SetItemValue(0, "ho_dong", layPrintOrder.GetItemValue("ho_dong"));
                    layPrint.SetItemValue(0, "ho_code", layPrintOrder.GetItemValue("ho_code"));
                    layPrint.SetItemValue(0, "birth", layPrintOrder.GetItemValue("birth"));
                    layPrint.SetItemValue(0, "sex", layPrintOrder.GetItemValue("sex"));
                    layPrint.SetItemValue(0, "age", layPrintOrder.GetItemValue("age"));
                    layPrint.SetItemValue(0, "order_date", layPrintOrder.GetItemValue("order_date"));
                    layPrint.SetItemValue(0, "gwa_name", layPrintOrder.GetItemValue("gwa_name"));
                    layPrint.SetItemValue(0, "doctor_name", layPrintOrder.GetItemValue("doctor_name"));
                    layPrint.SetItemValue(0, "xray_name", layPrintOrder.GetItemValue("xray_name"));
                    layPrint.SetItemValue(0, "order_comments", textEnter(orderComments, 20, "\n"));
                    layPrint.SetItemValue(0, "gumsa_mokjuk", textEnter(gumsaMokjuk, 23, "\n"));
                    layPrint.SetItemValue(0, "fkocs", layPrintOrder.GetItemValue("fkocs"));
                    layPrint.SetItemValue(0, "xray_gubun_name", layPrintOrder.GetItemValue("xray_gubun_name"));
                    layPrint.SetItemValue(0, "cpl_value", this.layCPLResult.GetItemValue("cpl_result").ToString());
                    layPrint.SetItemValue(0, "cpl_date", this.layCPLResult.GetItemValue("cpl_gumsa_date").ToString());
                    layPrint.SetItemValue(0, "suname2", layPrintOrder.GetItemValue("suname2"));
                    layPrint.SetItemValue(0, "xray_method", textEnter(layPrintOrder.GetItemValue("xray_method").ToString(), 23, "\n"));
                    layPrint.SetItemValue(0, "xray_gubun", layPrintOrder.GetItemValue("xray_gubun"));
                    layPrint.SetItemValue(0, "order_time", layPrintOrder.GetItemValue("order_time"));
                    layPrint.SetItemValue(0, "birth_japan", layPrintOrder.GetItemValue("birth_japan"));

                    if (TypeCheck.IsNull(layPrintOrder.GetItemValue("xray_reser_date")))
                    {
                        layPrint.SetItemValue(0, "xray_reser_date", layPrintOrder.GetItemValue("order_date"));
                    }
                    else
                    {
                        layPrint.SetItemValue(0, "xray_reser_date", layPrintOrder.GetItemValue("xray_reser_date"));
                        layPrint.SetItemValue(0, "xray_reser_time", layPrintOrder.GetItemValue("xray_reser_time"));
                    }

                    layPrint.SetItemValue(0, "weight", layPrintOrder.GetItemValue("weight"));
                    layPrint.SetItemValue(0, "height", layPrintOrder.GetItemValue("height"));
                    layPrint.SetItemValue(0, "xray_code", layPrintOrder.GetItemValue("xray_code"));
                    layPrint.SetItemValue(0, "comment", layPrintOrder.GetItemValue("comment"));
                    layPrint.SetItemValue(0, "buwi_code", layPrintOrder.GetItemValue("buwi_code"));
                    layPrint.SetItemValue(0, "buwi_code_name", layPrintOrder.GetItemValue("buwi_code_name"));
                    layPrint.SetItemValue(0, "valtage", layXRT0123.GetItemValue("valtage"));
                    layPrint.SetItemValue(0, "cur_electric", layXRT0123.GetItemValue("cur_electric"));
                    layPrint.SetItemValue(0, "time", layXRT0123.GetItemValue("time"));
                    layPrint.SetItemValue(0, "distance", layXRT0123.GetItemValue("distance"));
                    layPrint.SetItemValue(0, "grid", layXRT0123.GetItemValue("grid"));
                    layPrint.SetItemValue(0, "note", layXRT0123.GetItemValue("note"));
                    layPrint.SetItemValue(0, "mas_val", layXRT0123.GetItemValue("mas_val"));
                }
                else
                {
                    for (int i = 0; i < layPaStatus.RowCount; i++)
                    {
                        int rowNum = this.layPrint.InsertRow(-1);

                        // CT의 경퓖E?검사목픸E3행이후에 촬영방법을 출력한다.
                        // CT제외의 경퓖E?촬영방법 코멘트 없슴.
                        if (layPrintOrder.GetItemValue("xray_gubun").ToString() == "C")
                            gumsaMokjuk = layPrintOrder.GetItemValue("gumsa_mokjuk2") + "\n\n\n\n" + "[撮影方法]" + "\n" + layPrintOrder.GetItemValue("xray_method").ToString();
                        else
                            gumsaMokjuk = layPrintOrder.GetItemValue("gumsa_mokjuk2").ToString();

                        // 의사지시의 경퓖E?코멘트 앞에 손가턿E표시를 한다.
                        orderComments = this.layPrintOrder.GetItemValue("comment").ToString();
                        // 방사선 자체 코멘트
                        xrtComments = this.layPrintOrder.GetItemValue("xrt_comments").ToString();

                        if (orderComments != "")
                            orderComments = "★ " + orderComments;

                        if (xrtComments != "")
                            orderComments = orderComments + "\n\n\n\n" + "[放射線科コメント]" + "\n" + xrtComments;

                        layPrint.SetItemValue(rowNum, "bunho", layPrintOrder.GetItemValue("bunho"));
                        layPrint.SetItemValue(rowNum, "suname", layPrintOrder.GetItemValue("suname"));
                        layPrint.SetItemValue(rowNum, "ho_dong", layPrintOrder.GetItemValue("ho_dong"));
                        layPrint.SetItemValue(rowNum, "ho_code", layPrintOrder.GetItemValue("ho_code"));
                        layPrint.SetItemValue(rowNum, "birth", layPrintOrder.GetItemValue("birth"));
                        layPrint.SetItemValue(rowNum, "sex", layPrintOrder.GetItemValue("sex"));
                        layPrint.SetItemValue(rowNum, "age", layPrintOrder.GetItemValue("age"));
                        layPrint.SetItemValue(rowNum, "order_date", layPrintOrder.GetItemValue("order_date"));
                        layPrint.SetItemValue(rowNum, "gwa_name", layPrintOrder.GetItemValue("gwa_name"));
                        layPrint.SetItemValue(rowNum, "doctor_name", layPrintOrder.GetItemValue("doctor_name"));
                        layPrint.SetItemValue(rowNum, "xray_name", layPrintOrder.GetItemValue("xray_name"));
                        layPrint.SetItemValue(rowNum, "order_comments", textEnter(orderComments, 20, "\n"));
                        layPrint.SetItemValue(rowNum, "gumsa_mokjuk", textEnter(gumsaMokjuk, 23, "\n"));
                        layPrint.SetItemValue(rowNum, "fkocs", layPrintOrder.GetItemValue("fkocs"));
                        layPrint.SetItemValue(rowNum, "xray_gubun_name", layPrintOrder.GetItemValue("xray_gubun_name"));
                        layPrint.SetItemValue(rowNum, "suname2", layPrintOrder.GetItemValue("suname2"));
                        layPrint.SetItemValue(rowNum, "xray_method", textEnter(layPrintOrder.GetItemValue("xray_method").ToString(), 23, "\n"));
                        layPrint.SetItemValue(rowNum, "xray_gubun", layPrintOrder.GetItemValue("xray_gubun"));
                        layPrint.SetItemValue(rowNum, "order_time", layPrintOrder.GetItemValue("order_time"));
                        layPrint.SetItemValue(rowNum, "birth_japan", this.layPrintOrder.GetItemValue("birth_japan"));

                        if (TypeCheck.IsNull(this.layPrintOrder.GetItemValue("xray_reser_date")))
                        {
                            layPrint.SetItemValue(rowNum, "xray_reser_date", layPrintOrder.GetItemValue("order_date"));
                        }
                        else
                        {
                            layPrint.SetItemValue(rowNum, "xray_reser_date", layPrintOrder.GetItemValue("xray_reser_date"));
                            layPrint.SetItemValue(rowNum, "xray_reser_time", layPrintOrder.GetItemValue("xray_reser_time"));
                        }
                        layPrint.SetItemValue(rowNum, "pat_status_name", layPaStatus.GetItemString(rowNum, "pat_status_name"));
                        layPrint.SetItemValue(rowNum, "pat_status_code_name", layPaStatus.GetItemString(rowNum, "pat_status_code_name"));
                        layPrint.SetItemValue(rowNum, "cpl_value", this.layCPLResult.GetItemValue("cpl_result").ToString());
                        layPrint.SetItemValue(rowNum, "cpl_date", this.layCPLResult.GetItemValue("cpl_gumsa_date").ToString());

                        layPrint.SetItemValue(rowNum, "weight", layPrintOrder.GetItemValue("weight"));
                        layPrint.SetItemValue(rowNum, "height", layPrintOrder.GetItemValue("height"));
                        layPrint.SetItemValue(rowNum, "xray_code", layPrintOrder.GetItemValue("xray_code"));
                        layPrint.SetItemValue(rowNum, "comment", layPrintOrder.GetItemValue("comment"));
                        layPrint.SetItemValue(rowNum, "buwi_code", layPrintOrder.GetItemValue("buwi_code"));
                        layPrint.SetItemValue(rowNum, "buwi_code_name", layPrintOrder.GetItemValue("buwi_code_name"));
                        layPrint.SetItemValue(rowNum, "valtage", layXRT0123.GetItemValue("valtage"));
                        layPrint.SetItemValue(rowNum, "cur_electric", layXRT0123.GetItemValue("cur_electric"));
                        layPrint.SetItemValue(rowNum, "time", layXRT0123.GetItemValue("time"));
                        layPrint.SetItemValue(rowNum, "distance", layXRT0123.GetItemValue("distance"));
                        layPrint.SetItemValue(rowNum, "grid", layXRT0123.GetItemValue("grid"));
                        layPrint.SetItemValue(rowNum, "note", layXRT0123.GetItemValue("note"));
                        layPrint.SetItemValue(rowNum, "mas_val", layXRT0123.GetItemValue("mas_val"));
                    }
                }

                //dwJubsuPrint.Reset();
                //dwJubsuPrint.FillData(layPrint.LayoutTable);
                //dwJubsuPrint.Refresh();

                try
                {
              //      dwJubsuPrint.Print(true);
                }
                catch (Exception xe)
                {
                    this.ParentForm.WindowState = FormWindowState.Normal;
                    //https://sofiamedix.atlassian.net/browse/MED-10610
                    //XMessageBox.Show(Resources.XMsg00009 + xe.Message);
                    return;
                }

                if (this.mPrintOnly == "Y")
                {
                    this.Close();
                }
            }
            else
            {
                this.ParentForm.WindowState = FormWindowState.Normal;
            }
        }

        private string textEnter(string argString, int enterLength, string entervalue)
        {
            string targetchar;
            string puttext = "";
            string fullText = "";
            string last_check = "N";

            if (argString.Length < enterLength)
            {
                fullText = argString;
            }
            else
            {
                for (int i = 0; i < argString.Length; i++)
                {
                    if (last_check == "N")
                    {
                        targetchar = argString.Substring(i, 1);
                        if (targetchar == "\"")
                        {
                            targetchar = "”";
                        }
                        puttext = puttext + targetchar;

                        if (puttext.Length == enterLength)
                        {
                            fullText = fullText + puttext + entervalue;
                            puttext = "";

                            if (argString.Substring(i + 1).Length < enterLength)
                            {
                                last_check = "Y";
                                fullText = fullText + entervalue + argString.Substring(i + 1);
                            }
                        }

                        if (targetchar == entervalue && last_check != "Y")
                        {
                            fullText = fullText + puttext;
                            puttext = "";

                            if (argString.Substring(i + 1).Length < enterLength)
                            {
                                last_check = "Y";
                                fullText = fullText + argString.Substring(i + 1);
                            }
                        }
                    }
                    else
                    {
                        break;
                    }

                    /*
                    if (argString.Substring(i).Length < enterLength)
                    {
                        if (puttext != "" && puttext.Length <= enterLength)
                        {
                            fullText = fullText + puttext + argString.Substring(i + 1);
                        }
                        else
                        {
                            fullText = fullText + argString.Substring(i + 1);
                        }
                        break;
                    }
                    */
                }
            }
            return fullText;
        }

        private bool CheckClosing()
        {
            if (this.mPrintOnly == "Y")
                return true;

            //삭제안하므로 없겠지만 혹시 모르니까.
            if (this.grdPaStatus.DeletedRowCount > 0)
            {
                return false;
            }

            foreach (DataRow row in this.grdPaStatus.LayoutTable.Rows)
            {
                if (row.RowState == DataRowState.Modified || row.RowState == DataRowState.Added)//Added는 없겠지만 혹시 모르니까
                {
                    return false;
                }
            }

            if ((this.old_gumsa_mokjuk != this.txtGumsaMokjuk.Text) ||
               (this.old_xray_method != this.txtXrayMethod.GetDataValue()) ||
               (this.old_pandok_request_yn != this.cbxRequestYn.GetDataValue()))
            {
                return false;
            }
            return true;

        }

        #endregion

        #region Cloud updated code

        #region InitializeCloud
        /// <summary>
        /// InitializeCloud
        /// </summary>
        private void InitializeCloud()
        {
            // dsvLDOCS0801
            dsvLDOCS0801.ParamList = new List<string>(new string[] { "f_hangmog_code" });
            dsvLDOCS0801.ExecuteQuery = GetDsvLDOCS0801;

            // dsvRequestData
            dsvRequestData.ParamList = new List<string>(new string[] { "f_fkocs" });
            dsvRequestData.ExecuteQuery = GetDsvRequestData;

            // dsvSideEffect
            dsvSideEffect.ParamList = new List<string>(new string[] { "f_bunho" });
            dsvSideEffect.ExecuteQuery = GetDsvSideEffect;

            // grdComment1
            grdComment1.ParamList = new List<string>(new string[] { "f_bunho", "f_order_date" });
            grdComment1.ExecuteQuery = GetGrdComment1;

            // grdComment2
            grdComment2.ParamList = new List<string>(new string[] { "f_bunho" });
            grdComment2.ExecuteQuery = GetGrdComment2;

            // grdComment3
            grdComment3.ParamList = new List<string>(new string[] { "f_bunho", "f_order_date" });
            grdComment3.ExecuteQuery = GetGrdComment3;

            // grdPaStatus
            grdPaStatus.ParamList = new List<string>(new string[] { "f_bunho", "f_hangmog_code", "f_hangmog_codes" });
            grdPaStatus.ExecuteQuery = GetGrdPaStatus;

            // layCPLResult
            layCPLResult.ParamList = new List<string>(new string[] { "f_bunho" });
            layCPLResult.ExecuteQuery = GetLayCPLResult;

            // layOrderByJundalPart
            layOrderByJundalPart.ParamList = new List<string>(new string[]
                {
                    "f_order_date",
                    "f_in_out_gubun",
                    "f_fkout1001",
                    "f_print_date",
                    "f_print_only",
                    "f_jundal_part",
                    "f_pkocs",
                    "f_fkinp1001",
                });
            layOrderByJundalPart.ExecuteQuery = GetLayOrderByJundalPart;

            // layOrderDate
            layOrderDate.ParamList = new List<string>(new string[] { "f_bunho" });
            layOrderDate.ExecuteQuery = GetLayOrderDate;

            // layPrintDate
            layPrintDate.ParamList = new List<string>(new string[]
                {
                    "f_order_date",
                    "f_in_out_gubun",
                    "f_fkout1001",
                    "f_print_only",
                    "f_jundal_part",
                    "f_pkocs",
                    "f_fkinp1001",
                });
            layPrintDate.ExecuteQuery = GetLayPrintDate;

            // layPrintOrder
            layPrintOrder.ParamList = new List<string>(new string[]
                {
                    "f_order_date",
                    "f_gwa",
                    "f_in_out_gubun",
                    "f_pkocs",
                });
            layPrintOrder.ExecuteQuery = GetLayPrintOrder;

            // layXRT0123
            layXRT0123.ParamList = new List<string>(new string[] { "f_buwi_code", "f_xray_gubun" });
            layXRT0123.ExecuteQuery = GetLayXRT0123;

            // grdXrayMethod
            grdXrayMethod.ParamList = new List<string>(new string[] { "f_code_type" });
            grdXrayMethod.ExecuteQuery = GetGrdXrayMethod;

            // dsvBuhaGubun
            dsvBuhaGubun.ParamList = new List<string>(new string[] { "f_code_type" });
            dsvBuhaGubun.ExecuteQuery = GetDsvBuhaGubun;

            // dsvXrayGubun
            dsvXrayGubun.ParamList = new List<string>(new string[] { "f_code" });
            dsvXrayGubun.ExecuteQuery = GetDsvXrayGubun;
        }
        #endregion

        #region GetDsvLDOCS0801
        /// <summary>
        /// GetDsvLDOCS0801
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetDsvLDOCS0801(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            XRT1002U00DsvLDOCS0801Args args = new XRT1002U00DsvLDOCS0801Args();
            args.HangmogCode = bvc["f_hangmog_code"].VarValue;
            XRT1002U00DsvLDOCS0801Result res = CloudService.Instance.Submit<XRT1002U00DsvLDOCS0801Result, XRT1002U00DsvLDOCS0801Args>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.DsvLdItem.ForEach(delegate(XRT1002U00DsvLDOCS0801Info item)
                {
                    lObj.Add(new object[]
                    {
                        item.PatStatus,
                        item.PatStatusName,
                        item.PatStatusCode,
                        item.PatStatusCodeName,
                        item.IndispensableYn,
                    });
                });
            }

            return lObj;
        }
        #endregion

        #region GetDsvRequestData
        /// <summary>
        /// GetDsvRequestData
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetDsvRequestData(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            XRT1002U00DsvArgsDataArgs args = new XRT1002U00DsvArgsDataArgs();
            args.Fkocs = bvc["f_fkocs"].VarValue;
            XRT1002U00DsvRequestDataResult res = CloudService.Instance.Submit<XRT1002U00DsvRequestDataResult, XRT1002U00DsvArgsDataArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.DsvReqDataItem.ForEach(delegate(XRT1002U00DsvRequestDataInfo item)
                {
                    lObj.Add(new object[]
                    {
                        item.Fkocs,
                        item.InOutGubun,
                        item.HangmogCode,
                        item.Bunho,
                        item.GumsaMokjuk,
                        item.XrayMethod,
                        item.PandokRequestYn,
                        item.BuhaGubun,
                    });
                });
            }

            return lObj;
        }
        #endregion

        #region GetDsvSideEffect
        /// <summary>
        /// GetDsvSideEffect
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetDsvSideEffect(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            XRT1002U00DsvSideEffectArgs args = new XRT1002U00DsvSideEffectArgs();
            args.Bunho = bvc["f_bunho"].VarValue;
            XRT1002U00DsvSideEffectResult res = CloudService.Instance.Submit<XRT1002U00DsvSideEffectResult, XRT1002U00DsvSideEffectArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.DsvSideEffectItem.ForEach(delegate(XRT1002U00DsvSideEffectInfo item)
                {
                    lObj.Add(new object[]
                    {
                        item.Fkxrt0201,
                        item.XrayDate,
                        item.XrayName,
                        item.JaeryoName,
                        item.Remark,
                        item.SideEffect1,
                        item.SideEffect2,
                        item.SideEffect3,
                        item.SideEffect4,
                        item.SideEffect5,
                        item.SideEffect6,
                        item.SideEffect7,
                        item.SideEffectText,
                    });
                });
            }

            return lObj;
        }
        #endregion

        #region GetGrdComment3
        /// <summary>
        /// GetGrdComment3
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetGrdComment3(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            XRT1002U00GrdComment3Args args = new XRT1002U00GrdComment3Args();
            args.Bunho = bvc["f_bunho"].VarValue;
            args.OrderDate = bvc["f_order_date"].VarValue;
            XRT1002U00GrdComment3Result res = CloudService.Instance.Submit<XRT1002U00GrdComment3Result, XRT1002U00GrdComment3Args>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.GrdCommentItem.ForEach(delegate(XRT1002U00GrdComment3Info item)
                {
                    lObj.Add(new object[]
                    {
                        item.Comments,
                        item.Numb,
                        item.Ser,
                    });
                });
            }

            return lObj;
        }
        #endregion

        #region GetGrdPaStatus
        /// <summary>
        /// GetGrdPaStatus
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetGrdPaStatus(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            XRT1002U00GrdPaStatusArgs args = new XRT1002U00GrdPaStatusArgs();
            args.Bunho = bvc["f_bunho"].VarValue;
            args.HangmogCode = bvc["f_hangmog_code"].VarValue;
            XRT1002U00GrdPaStatusResult res = CloudService.Instance.Submit<XRT1002U00GrdPaStatusResult, XRT1002U00GrdPaStatusArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.GrdPaStatusItem.ForEach(delegate(XRT1002U00GrdPaStatusInfo item)
                {
                    lObj.Add(new object[]
                    {
                        item.Bunho,
                        item.PatStatus,
                        item.PatStatusName,
                        item.PatStatusCode,
                        item.PatStatusCodeName,
                        item.Ment,
                        item.Seq,
                        item.IndispensableYn,
                        item.ContKey,
                    });
                });
            }

            return lObj;
        }
        #endregion

        #region GetGrdPaStatusForPrintOrder
        /// <summary>
        /// GetGrdPaStatusForPrintOrder
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetGrdPaStatusForPrintOrder(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            XRT1002U00PrintOrderByJudalPartArgs args = new XRT1002U00PrintOrderByJudalPartArgs();
            args.Bunho = bvc["f_bunho"].VarValue;
            args.HangmogCodes = bvc["f_hangmog_codes"].VarValue;
            XRT1002U00PrintOrderByJudalPartResult res = CloudService.Instance.Submit<XRT1002U00PrintOrderByJudalPartResult,
                XRT1002U00PrintOrderByJudalPartArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.GrdPaStatusItem.ForEach(delegate(XRT1002U00GrdPaStatusInfo item)
                {
                    lObj.Add(new object[]
                    {
                        item.Bunho,
                        item.PatStatus,
                        item.PatStatusName,
                        item.PatStatusCode,
                        item.PatStatusCodeName,
                        item.Ment,
                        item.Seq,
                        item.IndispensableYn,
                        item.ContKey,
                    });
                });
            }

            return lObj;
        }
        #endregion

        #region GetLayCPLResult
        /// <summary>
        /// GetLayCPLResult
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetLayCPLResult(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            XRT1002U00LayCPLArgs args = new XRT1002U00LayCPLArgs();
            args.Bunho = bvc["f_bunho"].VarValue;
            XRT1002U00LayCPLResult res = CloudService.Instance.Submit<XRT1002U00LayCPLResult, XRT1002U00LayCPLArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.LayCplItem.ForEach(delegate(XRT1002U00LayCPLInfo item)
                {
                    lObj.Add(new object[]
                    {
                        item.HangmogName,
                        item.HangmogResult,
                        item.HangmogResultDate,
                    });
                });
            }

            return lObj;
        }
        #endregion

        #region GetLayOrderByJundalPart
        /// <summary>
        /// GetLayOrderByJundalPart
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetLayOrderByJundalPart(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            XRT1002U00LayOrderByJundalPartArgs args = new XRT1002U00LayOrderByJundalPartArgs();
            args.Fkinp1001          = bvc["f_fkinp1001"].VarValue;
            args.Fkout1001          = bvc["f_fkout1001"].VarValue;
            args.InOutGubun         = bvc["f_in_out_gubun"].VarValue;
            args.JundalPart         = bvc["f_jundal_part"].VarValue;
            args.OrderDate          = bvc["f_order_date"].VarValue;
            args.Pkocs              = bvc["f_pkocs"].VarValue;
            args.PrintDate          = bvc["f_print_date"].VarValue;
            args.PrintOnly          = bvc["f_print_only"].VarValue;
            XRT1002U00LayOrderByJundalPartResult res = CloudService.Instance.Submit<XRT1002U00LayOrderByJundalPartResult,
                XRT1002U00LayOrderByJundalPartArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.LayOrderByJundItem.ForEach(delegate(XRT1002U00LayOrderByJundalPartInfo item)
                {
                    lObj.Add(new object[]
                    {
                        item.Bunho,
                        item.Suname,
                        item.HoDong,
                        item.Hocode,
                        item.Birth,
                        item.Sex,
                        item.Age,
                        item.OrderDate,
                        item.GwaName,
                        item.DoctorName,
                        item.XrayName,
                        item.XrtComments,
                        item.GumsaMokjuk2,
                        item.Pkocs,
                        item.XrayGubunName,
                        item.XrayReserDate,
                        item.XrayReserTime,
                        item.PatStatusName,
                        item.PatStatusCodeName,
                        item.CplResult,
                        item.CplGumsaDate,
                        item.PacsSuname2,
                        item.XrayMethod,
                        item.XrayGubun,
                        item.OrderTime,
                        item.BirthJapan,
                        item.Weight,
                        item.Height,
                        item.XrayCode,
                        item.Comment,
                        item.BuwiCode,
                        item.BuwiCodeName,
                        item.XrayDate,
                        item.Valtage,
                        item.CurElectric,
                        item.Time,
                        item.Distance,
                        item.Grid,
                        item.Note,
                        item.PrintDate,
                        item.Pkxrt0201,
                    });
                });
            }

            return lObj;
        }
        #endregion

        #region GetLayOrderDate
        /// <summary>
        /// GetLayOrderDate
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetLayOrderDate(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            XRT1002U00LayOrderDateArgs args = new XRT1002U00LayOrderDateArgs();
            args.Bunho = bvc["f_bunho"].VarValue;
            XRT1002U00LayOrderDateResult res = CloudService.Instance.Submit<XRT1002U00LayOrderDateResult, XRT1002U00LayOrderDateArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.LayOrderDateItem.ForEach(delegate(XRT1002U00LayOrderDateInfo item)
                {
                    lObj.Add(new object[] { item.OrderDate });
                });
            }

            return lObj;
        }
        #endregion

        #region GetLayPrintDate
        /// <summary>
        /// GetLayPrintDate
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetLayPrintDate(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            XRT1002U00LayPrintDateArgs args = new XRT1002U00LayPrintDateArgs();
            args.Fkinp1001          = bvc["f_fkinp1001"].VarValue;
            args.Fkout1001          = bvc["f_fkout1001"].VarValue;
            args.InOutGubun         = bvc["f_in_out_gubun"].VarValue;
            args.JundalPart         = bvc["f_jundal_part"].VarValue;
            args.OrderDate          = bvc["f_order_date"].VarValue;
            args.Pkocs              = bvc["f_pkocs"].VarValue;
            args.PrintOnly          = bvc["f_print_only"].VarValue;
            XRT1002U00LayPrintDateResult res = CloudService.Instance.Submit<XRT1002U00LayPrintDateResult, XRT1002U00LayPrintDateArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.LayPrintDateItem.ForEach(delegate(XRT1002U00LayPrintDateInfo item)
                {
                    lObj.Add(new object[] { item.PrintDate });
                });
            }

            return lObj;
        }
        #endregion

        #region GetLayPrintOrder
        /// <summary>
        /// GetLayPrintOrder
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetLayPrintOrder(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            XRT1002U00LayPrintOrderArgs args = new XRT1002U00LayPrintOrderArgs();
            args.Gwa            = bvc["f_gwa"].VarValue;
            args.InOutGubun     = bvc["f_in_out_gubun"].VarValue;
            args.OrderDate      = bvc["f_order_date"].VarValue;
            args.Pkocs          = bvc["f_pkocs"].VarValue;
            XRT1002U00LayPrintOrderResult res = CloudService.Instance.Submit<XRT1002U00LayPrintOrderResult, XRT1002U00LayPrintOrderArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.LayPrintOrderItem.ForEach(delegate(XRT1002U00LayPrintOrderInfo item)
                {
                    lObj.Add(new object[]
                    {
                        item.Bunho,
                        item.Suname,
                        item.HoDong,
                        item.Hocode,
                        item.Birth,
                        item.Sex,
                        item.Age,
                        item.OrderDate,
                        item.GwaName,
                        item.DoctorName,
                        item.XrayName,
                        item.XrtComments,
                        item.GumsaMokjuk2,
                        item.Pkocs,
                        item.XrayGubunName,
                        item.XrayReserDate,
                        item.XrayReserTime,
                        item.PatStatusName,
                        item.PatStatusCodeName,
                        item.CplResult,
                        item.CplGumsaDate,
                        item.PacsSuname2,
                        item.XrayMethod,
                        item.XrayGubun,
                        item.OrderTime,
                        item.BirthJapan,
                        item.Weight,
                        item.Height,
                        item.XrayCode,
                        item.Comment,
                        item.BuwiCode,
                        item.BuwiCodeName,
                        item.Valtage,
                        item.CurElectric,
                        item.Time,
                        item.Distance,
                        item.Grid,
                        item.Note,
                        item.Pkxrt0201,
                    });
                });
            }

            return lObj;
        }
        #endregion

        #region GetLayXRT0123
        /// <summary>
        /// GetLayXRT0123
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetLayXRT0123(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            XRT1002U00LayXRT0123Args args = new XRT1002U00LayXRT0123Args();
            args.BuwiCode = bvc["f_buwi_code"].VarValue;
            args.XrayGubun = bvc["f_xray_gubun"].VarValue;
            XRT1002U00LayXRT0123Result res = CloudService.Instance.Submit<XRT1002U00LayXRT0123Result, XRT1002U00LayXRT0123Args>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.LayXrtItem.ForEach(delegate(XRT1002U00LayXRT0123Info item)
                {
                    lObj.Add(new object[]
                    {
                        item.Valtage,
                        item.CurElectric,
                        item.Time,
                        item.Distance,
                        item.Grid,
                        item.Note,
                        item.MasVal,
                    });
                });
            }

            return lObj;
        }
        #endregion

        #region GetGrdComment1
        /// <summary>
        /// GetGrdComment1
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetGrdComment1(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            XRT1002U00GrdComment1Args args = new XRT1002U00GrdComment1Args();
            args.Bunho = bvc["f_bunho"].VarValue;
            args.OrderDate = bvc["f_order_date"].VarValue;
            XRT1002U00GrdComment1Result res = CloudService.Instance.Submit<XRT1002U00GrdComment1Result, XRT1002U00GrdComment1Args>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.GrdCommentItem.ForEach(delegate(XRT1002U00GrdCommentInfo item)
                {
                    lObj.Add(new object[] { item.Comments });
                });
            }

            return lObj;
        }
        #endregion

        #region GetGrdComment2
        /// <summary>
        /// GetGrdComment2
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetGrdComment2(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            XRT1002U00GrdComment2Args args = new XRT1002U00GrdComment2Args();
            args.Bunho = bvc["f_bunho"].VarValue;
            XRT1002U00GrdComment2Result res = CloudService.Instance.Submit<XRT1002U00GrdComment2Result, XRT1002U00GrdComment2Args>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.GrdCommentItem.ForEach(delegate(XRT1002U00GrdCommentInfo item)
                {
                    lObj.Add(new object[] { item.Comments });
                });
            }

            return lObj;
        }
        #endregion

        #region GetGrdXrayMethod
        /// <summary>
        /// GetGrdXrayMethod
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetGrdXrayMethod(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            XRT1002U00GrdXrayMethodArgs args = new XRT1002U00GrdXrayMethodArgs();
            args.CodeType = bvc["f_code_type"].VarValue;
            ComboResult res = CloudService.Instance.Submit<ComboResult, XRT1002U00GrdXrayMethodArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.ComboItem.ForEach(delegate(ComboListItemInfo item)
                {
                    lObj.Add(new object[] { item.Code, item.CodeName });
                });
            }

            return lObj;
        }
        #endregion

        #region GetDsvBuhaGubun
        /// <summary>
        /// GetDsvBuhaGubun
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetDsvBuhaGubun(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            XRT1002U00DsvBuhaGubunArgs args = new XRT1002U00DsvBuhaGubunArgs();
            args.CodeType = bvc["f_code_type"].VarValue;
            ComboResult res = CloudService.Instance.Submit<ComboResult, XRT1002U00DsvBuhaGubunArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.ComboItem.ForEach(delegate(ComboListItemInfo item)
                {
                    lObj.Add(new object[] { item.Code, item.CodeName });
                });
            }

            return lObj;
        }
        #endregion

        #region GetDsvXrayGubun
        /// <summary>
        /// GetDsvXrayGubun
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetDsvXrayGubun(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            XRT1002U00DsvXrayGubunArgs args = new XRT1002U00DsvXrayGubunArgs();
            args.Code = bvc["f_code"].VarValue;
            XRT1002U00DsvXrayGubunResult res = CloudService.Instance.Submit<XRT1002U00DsvXrayGubunResult, XRT1002U00DsvXrayGubunArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.XrayGubunItem.ForEach(delegate(XRT1002U00DsvXrayGubunInfo item)
                {
                    lObj.Add(new object[]
                    {
                        item.XrayGubun,
                        item.XrayName,
                        item.RequestYn,
                    });
                });
            }

            return lObj;
        }
        #endregion

        #region GetListDataForSaveLayout
        /// <summary>
        /// GetListDataForSaveLayout
        /// </summary>
        /// <returns></returns>
        private List<XRT1002U00GrdPaStatusInfo> GetListDataForSaveLayout()
        {
            List<XRT1002U00GrdPaStatusInfo> lstData = new List<XRT1002U00GrdPaStatusInfo>();

            foreach (DataRow row in grdPaStatus.LayoutTable.Rows)
            {
                XRT1002U00GrdPaStatusInfo item = new XRT1002U00GrdPaStatusInfo();

                item.Ment = Convert.ToString(row["ment"]);
                item.PatStatus = Convert.ToString(row["pat_status"]);
                item.PatStatusCode = Convert.ToString(row["pat_status_code"]);
                item.Seq = Convert.ToString(row["seq"]);

                lstData.Add(item);
            }

            return lstData;
        }
        #endregion

        #region DoUpdate
        /// <summary>
        /// DoUpdate
        /// </summary>
        /// <returns></returns>
        private bool DoUpdate()
        {
            XRT1002U00UpdateArgs args   = new XRT1002U00UpdateArgs();
            args.Bunho                  = this.mBunho;
            args.Fkocs                  = this.mFkOcs;
            args.GumsaMokjuk            = txtGumsaMokjuk.Text;
            args.HangmogCode            = this.mHangmogCode;
            args.InOutGubun             = this.mInOutGubun;
            args.PandokRequestYn        = cbxRequestYn.GetDataValue();
            args.UpdId                  = this.mDoctor;
            args.XrayMethod             = txtXrayMethod.GetDataValue();
            args.GrdPaItem              = GetListDataForSaveLayout();
            UpdateResult res = CloudService.Instance.Submit<UpdateResult, XRT1002U00UpdateArgs>(args);

            return res.Result;
        }
        #endregion

        #endregion
    }
}