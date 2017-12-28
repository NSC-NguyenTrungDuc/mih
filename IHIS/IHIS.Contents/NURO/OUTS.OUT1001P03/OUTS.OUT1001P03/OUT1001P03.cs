using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using IHIS.Framework;
using System.Collections.Generic;
using IHIS.NURO.Properties;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Arguments.Outs;
using IHIS.CloudConnector.Contracts.Models.Outs;
using IHIS.CloudConnector.Contracts.Results.Outs;
using IHIS.CloudConnector.Contracts.Results.System;
namespace IHIS.NURO
{
    public partial class OUT1001P03 : IHIS.Framework.XScreen
    {
        public OUT1001P03()
        {
            InitializeComponent();
            grdBeforeJubsu.ParamList = new List<string>(new string[]
                {
                    "f_bunho",
                    "f_io_gubun"
                });
            this.grdBeforeJubsu.ExecuteQuery = GetBeforeJubsu;

            grdBeforeOrder.ParamList = new List<string>(new string[]
                {
                    "f_bunho",
                    "f_io_gubun",
                    "f_naewon_key"
                });
            this.grdBeforeOrder.ExecuteQuery = GetBeforeOrder;

            grdAfterJubsu.ParamList = new List<string>(new string[]
                {
                    "f_bunho",
                    "f_io_gubun"
                });
            this.grdAfterJubsu.ExecuteQuery = GetAfterJubsu;

            grdAfterOrder.ParamList = new List<string>(new string[]
                {
                    "f_bunho",
                    "f_io_gubun",
                    "f_naewon_key"
                });
            this.grdAfterOrder.ExecuteQuery = GetAfterOrder;
        }

        #region [ Screen 변수 ]

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        // 라디오 버튼 관련 변수
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private XColor mSelectedForeColor = new XColor(Color.FromName("ActiveCaptionText"));
        private XColor mSelectedBackColor = new XColor(Color.FromName("ActiveCaption"));
        private XColor mUnSelectedForeColor = new XColor(Color.FromName("InactiveCaptionText"));
        private XColor mUnSelectedBackColor = new XColor(Color.FromName("InactiveCaption"));

        string mMsg = "";
        string mCap = "";

        #endregion

        #region [ ========== Screen 이벤트 ========== ]

        private void OUT1001P03_Load(object sender, EventArgs e)
        {
            // 외래가 기본
            this.rbnOut.Checked = true;

            // 초기화 시작
            if (this.OpenParam != null)
            {
                if (this.OpenParam.Contains("bunho"))
                {
                    this.paBeforeBox.SetPatientID(this.OpenParam["bunho"].ToString());
                }
            }
            else
            {
                //if (this.paBeforeBox.Text == "")
                //{
                //    XPatientInfo patientInfo = XScreen.GetPreviousScreenBunHo(true);

                //    if (patientInfo == null || (patientInfo != null && TypeCheck.IsNull(patientInfo.BunHo)))
                //    {
                //        // 이전 스크린의 등록번호를 못가지고 온 경우, 열려있는 전체 스크린에서 등록번호를 가져온다
                //        patientInfo = XScreen.GetOtherScreenBunHo(this, true);
                //    }

                //    if (patientInfo != null && !TypeCheck.IsNull(patientInfo.BunHo))
                //    {
                //        this.paBeforeBox.SetPatientID(patientInfo.BunHo);
                //    }
                //}

            }
            //this.paBeforeBox.Focus();
            this.grdAfterOrder.FixedCols = 3;
            this.grdBeforeOrder.FixedCols = 3;
        }

        #endregion

        #region [ ========== Function ========== ]

        #region Grid 선택 이미지 관련

        private void SetDefaultGridImage(XEditGrid aGrid)
        {
            for (int i = 0; i < aGrid.RowCount; i++)
            {
                if (aGrid.GetItemString(i, "select_yn") == "Y")
                {
                    aGrid[i, "select_yn"].Image = this.ImageList.Images[0];
                }
                else
                {
                    aGrid[i, "select_yn"].Image = this.ImageList.Images[1];
                }
            }
        }

        private void SelectGridRow(int aRowNumber)
        {
            if (this.grdBeforeJubsu.GetItemString(aRowNumber, "select_yn") == "Y")
            {
                this.grdBeforeJubsu.SetItemValue(aRowNumber, "select_yn", "N");
                this.grdBeforeJubsu[aRowNumber, "select_yn"].Image = this.ImageList.Images[1];
            }
            else
            {
                this.grdBeforeJubsu.SetItemValue(aRowNumber, "select_yn", "Y");
                this.grdBeforeJubsu[aRowNumber, "select_yn"].Image = this.ImageList.Images[0];
            }
        }

        #endregion

        #region Status Bar 관련

        private void InitStatusBar(int aMaxCount)
        {
            this.lbStatusText.Text = "";
            this.pgbStatus.Minimum = 0;
            this.pgbStatus.Maximum = 0;
        }

        private void SetStatusBarVisible(bool aIsVisible)
        {
            this.pnlStatus.Visible = aIsVisible;
        }

        private void SetStatusValue(string aMsg, int aCurrentValue)
        {
            this.lbStatusText.Text = aMsg;
            this.pgbStatus.Value = aCurrentValue;

            this.pnlStatus.Refresh();
            this.lbStatusText.Refresh();
            this.pgbStatus.Refresh();
        }

        #endregion

        #endregion

        #region [ ========= Data Load ========== ]

        private void LoadData(XEditGrid aGrid, string aBunho)
        {
            if (this.rbnOut.Checked)
                aGrid.SetBindVarValue("f_io_gubun", "O");
            else
                aGrid.SetBindVarValue("f_io_gubun", "I");
            aGrid.SetBindVarValue("f_bunho", aBunho);
            aGrid.QueryLayout(true);
        }

        private void LoadOrderData(XEditGrid aGrid, string aBunho, string aNaewonKey)
        {
            if (this.rbnOut.Checked)
                aGrid.SetBindVarValue("f_io_gubun", "O");
            else
                aGrid.SetBindVarValue("f_io_gubun", "I");

            aGrid.SetBindVarValue("f_bunho", aBunho);
            aGrid.SetBindVarValue("f_naewon_key", aNaewonKey);
            aGrid.QueryLayout(false);
        }

        #endregion

        #region [ ========== Process ========== ]

        private bool ProcessChange()
        {
            try
            {
                //Connect to cloud
                string msg = string.Empty;
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                this.InitStatusBar(this.grdBeforeJubsu.RowCount);
                this.SetStatusBarVisible(true);
                msg = Resources.OUT1001P03_CDL;

                OUT1001P03ProcessArgs agrs = new OUT1001P03ProcessArgs();
                agrs.FromBunho = this.paBeforeBox.BunHo;
                agrs.ToBunho = this.paAfterBox.BunHo;
                agrs.UserId = UserInfo.UserID;
                agrs.PkKeyInfo = this.GetData();

                UpdateResult res = CloudService.Instance.Submit<UpdateResult, OUT1001P03ProcessArgs>(agrs);
                if (!res.Result)
                {
                    mMsg = Resources.OUT1001P03_XLTB + Service.ErrFullMsg;
                    mCap = Resources.OUT1001P03_XLTB;
                    MessageBox.Show(mMsg, mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            finally
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
                this.SetStatusBarVisible(false);
            }
            return true;

            //string msg = "";
            //string spName = "PR_NUR_CHANGE_BUNHO";
            //ArrayList inList = new ArrayList();
            //ArrayList outList = new ArrayList();

            //try
            //{
            //    this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

            //    this.InitStatusBar(this.grdBeforeJubsu.RowCount);

            //    this.SetStatusBarVisible(true);

            //    Service.BeginTransaction();

            //    msg = Resources.OUT1001P03_CDL;

            //    for (int i = 0; i < this.grdBeforeJubsu.RowCount; i++)
            //    {
            //        this.SetStatusValue(msg, i + 1);

            //        if (this.grdBeforeJubsu.GetItemString(i, "select_yn") != "Y")
            //            continue;

            //        inList.Clear();
            //        if (this.rbnOut.Checked)
            //            inList.Add("O");
            //        else
            //            inList.Add("I");

            //        inList.Add(this.paBeforeBox.BunHo);
            //        inList.Add(this.grdBeforeJubsu.GetItemString(i, "pk_key"));
            //        inList.Add(this.paAfterBox.BunHo);
            //        inList.Add(UserInfo.UserID);

            //        if (Service.ExecuteProcedure(spName, inList, outList) == false)
            //        {
            //            Service.RollbackTransaction();

            //            mMsg = Resources.OUT1001P03_XLTB + Service.ErrFullMsg;
            //            mCap = Resources.OUT1001P03_XLTB;

            //            MessageBox.Show(mMsg, mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            return false;
            //        }
            //    }
            //}
            //finally
            //{
            //    this.Cursor = System.Windows.Forms.Cursors.Default;
            //    this.SetStatusBarVisible(false);
            //    Service.CommitTransaction();
            //}

            //return true;
        }

        private List<OUT1001P03ProcessInfo> GetData()
        {
            List<OUT1001P03ProcessInfo> beforeJubsuList = new List<OUT1001P03ProcessInfo>();
            OUT1001P03ProcessInfo beforeJubsuItem = new OUT1001P03ProcessInfo();
            for (int i = 0; i < this.grdBeforeJubsu.RowCount; i++)
            {
                if (this.grdBeforeJubsu.GetItemString(i, "select_yn") != "Y")
                    continue;
                if (this.rbnOut.Checked)
                    beforeJubsuItem.IoGubun = "O";
                else
                    beforeJubsuItem.IoGubun = "I";
                beforeJubsuItem.PkKey = this.grdBeforeJubsu.GetItemString(i, "pk_key");
                beforeJubsuList.Add(beforeJubsuItem);
            }
            return beforeJubsuList;
        }

        #endregion

        #region [ ========= Control 이벤트 ========== ]

        #region RadioButton

        private void rbnInOut_CheckedChanged(object sender, EventArgs e)
        {
            XRadioButton control = sender as XRadioButton;

            if (control.Checked)
            {
                control.BackColor = this.mSelectedBackColor;
                control.ForeColor = this.mSelectedForeColor;
                control.ImageIndex = 0;
            }
            else
            {
                control.BackColor = this.mUnSelectedBackColor;
                control.ForeColor = this.mUnSelectedForeColor;
                control.ImageIndex = 1;
            }
        }

        #endregion

        #region XPatient Box

        private void paBeforeBox_PatientSelected(object sender, EventArgs e)
        {
            XPatientBox control = sender as XPatientBox;
            SingleLayout layCommon = new SingleLayout();
            layCommon.ExecuteQuery = GetLayCommon;
            /*layCommon.QuerySQL = @" SELECT NVL(A.BUNHO_TYPE,'0') BUNHO_TYPE
                                      FROM OUT0101 A
                                     WHERE A.HOSP_CODE = :f_hosp_code
                                       AND A.BUNHO = :f_bunho ";
            layCommon.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);*/
            layCommon.LayoutItems.Add("bunho_type");
            
            layCommon.SetBindVarValue("f_bunho", this.paBeforeBox.BunHo);

            if (layCommon.QueryLayout())
            {
                object bunhoType = layCommon.GetItemValue("bunho_type");
                if (bunhoType != null && bunhoType.ToString() == "0")
                {
                    mMsg = "[" + this.paBeforeBox.BunHo + "] " + this.paBeforeBox.SuName
                                + Resources.OUT1001P03_BNKTTD;
                    mCap = Resources.OUT1001P03_XN;
                    XMessageBox.Show(mMsg, mCap, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.grdBeforeJubsu.Reset();
                    this.grdBeforeOrder.Reset();
                    this.paBeforeBox.SetPatientID("");
                    return;
                }
            }

            this.LoadData(this.grdBeforeJubsu, control.BunHo);
            this.SetDefaultGridImage(this.grdBeforeJubsu);
            if (this.grdBeforeJubsu.RowCount <= 0) this.grdBeforeOrder.Reset();
        }



        private void paBeforeBox_PatientSelectionFailed(object sender, EventArgs e)
        {
            this.grdBeforeJubsu.Reset();
            this.grdBeforeOrder.Reset();
        }

        private void paAfterBox_PatientSelected(object sender, EventArgs e)
        {
            XPatientBox control = sender as XPatientBox;

            this.LoadData(this.grdAfterJubsu, control.BunHo);

            if (this.grdAfterJubsu.RowCount <= 0) this.grdAfterOrder.Reset();
        }

        private void paAfterBox_PatientSelectionFailed(object sender, EventArgs e)
        {
            this.grdAfterJubsu.Reset();
            this.grdAfterOrder.Reset();
        }


        #endregion

        #region XEditGrid

        private void grdBeforeJubsu_RowFocusChanged(object sender, RowFocusChangedEventArgs e)
        {
            XEditGrid grid = sender as XEditGrid;

            this.LoadOrderData(this.grdBeforeOrder, this.paBeforeBox.BunHo, grid.GetItemString(e.CurrentRow, "pk_key"));
        }

        private void grdAfterJubsu_RowFocusChanged(object sender, RowFocusChangedEventArgs e)
        {
            XEditGrid grid = sender as XEditGrid;

            this.LoadOrderData(this.grdAfterOrder, this.paAfterBox.BunHo, grid.GetItemString(e.CurrentRow, "pk_key"));
        }

        private void grdBeforeJubsu_MouseDown(object sender, MouseEventArgs e)
        {
            XEditGrid grid = sender as XEditGrid;

            int rowNumber = -1;

            if (e.Button == MouseButtons.Left && e.Clicks == 1)
            {
                rowNumber = grid.GetHitRowNumber(e.Y);

                if (grid.CurrentColName == "select_yn")
                {
                    if (rowNumber < 0)
                        return;

                    this.SelectGridRow(rowNumber);
                }
            }
        }

        #endregion



        #endregion

        private void btnList_ButtonClick(object sender, ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Query:
                    e.IsBaseCall = false;
                    this.LoadData(this.grdBeforeJubsu, this.paBeforeBox.BunHo);
                    this.SetDefaultGridImage(this.grdBeforeJubsu);
                    break;
                case FunctionType.Process:
                    this.AcceptData();
                    if (this.paBeforeBox.BunHo == "" || this.paAfterBox.BunHo == "")
                    {
                        mMsg = Resources.OUT1001P03_NMSBN;
                        mCap = Resources.OUT1001P03_TB;
                        XMessageBox.Show(mMsg, mCap, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    mMsg = "[" + this.paBeforeBox.BunHo + "] " + this.paBeforeBox.SuName
                         + Resources.OUT1001P03_DLBN + "\n" + "[" + this.paAfterBox.BunHo + "] " + this.paAfterBox.SuName
                         + Resources.OUT1001P03_DC;
                    mCap = Resources.OUT1001P03_XN;

                    if (XMessageBox.Show(mMsg, mCap, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                        return;

                    //if (this.grdBeforeJubsu.GetItemString(this.grdBeforeJubsu.CurrentRowNumber, "bunho_type") == "0")
                    //{
                    //    mMsg = "[" + this.paBeforeBox.BunHo + "] " + this.paBeforeBox.SuName
                    //         + "様の実患者なので\n" + "[" + this.paAfterBox.BunHo + "] " + this.paAfterBox.SuName
                    //         + "に切替できません。?";
                    //    mCap = "確認";
                    //    XMessageBox.Show(mMsg, mCap, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //    return;
                    //}
                    if (this.ProcessChange() == true)
                    {
                        this.LoadData(this.grdBeforeJubsu, this.paBeforeBox.BunHo);
                        this.LoadData(this.grdAfterJubsu, this.paAfterBox.BunHo);
                        this.paBeforeBox.SetPatientID("");
                    }

                    break;

                case FunctionType.Cancel:

                    break;

                case FunctionType.Close:

                    break;
            }
        }
        private void grdGrid_GridCellPainting(object sender, XGridCellPaintEventArgs e)
        {
            XEditGrid grd = sender as XEditGrid;

            if (grd.GetItemString(e.RowNumber, "reser_yn") == "Y")
            {
                e.BackColor = Color.LightGreen;
            }
        }
        public string mReturnedBunho = "";
        private void btnPABunho_Click(object sender, EventArgs e)
        {
            mReturnedBunho = "";
            BunhoSelectForm bsf = new BunhoSelectForm();
            bsf.ShowDialog(this);
            this.mReturnedBunho = bsf.ReturnBunho;
            if (this.mReturnedBunho != "")
            {
                this.paBeforeBox.SetPatientID(this.mReturnedBunho);
            }
        }

        #region Connect to Cloud
        private IList<object[]> GetLayCommon(BindVarCollection list)
        {
            IList<object[]> lObj = new List<object[]>();
            OUT1001P03PaBeforeBoxArgs args = new OUT1001P03PaBeforeBoxArgs();
            args.Bunho = this.paBeforeBox.BunHo;
            OUT1001P03PaBeforeBoxResult res = CloudService.Instance.Submit<OUT1001P03PaBeforeBoxResult, OUT1001P03PaBeforeBoxArgs>(args);
            if (null != res)
            {
                lObj.Add(new object[]
                    {
                        res.BunhoType
                    });
            }
            return lObj;
        }

        private IList<object[]> GetBeforeJubsu(BindVarCollection bc)
        {
            IList<object[]> lObj = new List<object[]>();

            OUT1001P03GrdBeforeJubsuArgs args = new OUT1001P03GrdBeforeJubsuArgs();
            args.Bunho = this.paBeforeBox.BunHo;
            args.IoGubun = this.rbnOut.Checked? "O" : "I";
            args.Pkout1001 = "";
            OUT1001P03GrdBeforeJubsuResult res = CloudService.Instance.Submit<OUT1001P03GrdBeforeJubsuResult, OUT1001P03GrdBeforeJubsuArgs>(args);

            if (null != res)
            {
                foreach (OUT1001P03GrdBeforeJubsuInfo item in res.GrdBeforeJubsuInfo)
                {
                    lObj.Add(new object[]
                    {
                        item.IoGubun,
                        item.PkKey,
                        item.Bunho,
                        item.Suname,
                        item.NaewonDate,
                        item.Gwa,
                        item.GwaName,
                        item.Doctor,
                        item.DoctorName,
                        item.NaewonTime,
                        item.SelectYn,
                        item.Comments,
                        item.BunhoType,
                        item.ReserYn,
                        item.ReserGubun
                    });
                }
            }
            return lObj;
        }

        private IList<object[]> GetBeforeOrder(BindVarCollection bc)
        {
            IList<object[]> lObj = new List<object[]>();
            OUT1001P03GrdBeforeOrderArgs args = new OUT1001P03GrdBeforeOrderArgs();
            args.Bunho = this.paBeforeBox.BunHo;
            args.IoGubun = this.rbnOut.Checked ? "O" : "I";
            args.NaewonKey = bc["f_naewon_key"].VarValue;
            OUT1001P03GrdBeforeOrderResult res = CloudService.Instance.Submit<OUT1001P03GrdBeforeOrderResult, OUT1001P03GrdBeforeOrderArgs>(args);

            if (null != res)
            {
                foreach (OUT1001P03GrdOrderInfo item in res.GrdOrderInfo)
                {
                    lObj.Add(new object[]
                    {
                        item.Pkocskey,
                        item.OrderGubun,
                        item.OrderGubunName,
                        item.HangmogCode,
                        item.HangmogName,
                        item.Suryang,
                        item.OrdDanui,
                        item.Nalsu
                    });
                }
            }
            return lObj;
        }

        private IList<object[]> GetAfterJubsu(BindVarCollection list)
        {
            IList<object[]> lObj = new List<object[]>();

            OUT1001P03GrdAfterJubsuArgs args = new OUT1001P03GrdAfterJubsuArgs();
            args.Bunho = this.paBeforeBox.BunHo;
            args.IoGubun = this.rbnOut.Checked ? "O" : "I";
            OUT1001P03GrdAfterJubsuResult res = CloudService.Instance.Submit<OUT1001P03GrdAfterJubsuResult, OUT1001P03GrdAfterJubsuArgs>(args);

            if (null != res)
            {
                foreach (OUT1001P03GrdAfterJubsuInfo item in res.GrdAfterJubsuInfo)
                {
                    lObj.Add(new object[]
                    {
                        item.IoGubun,
                        item.PkKey,
                        item.Bunho,
                        item.Suname,
                        item.NaewonDate,
                        item.Gwa,
                        item.GwaName,
                        item.Doctor,
                        item.DoctorName,
                        item.NaewonTime,
                        item.Comments,
                        item.BunhoType,
                        item.ReserYn,
                        item.ReserGubun
                    });
                }
            }

            return lObj;
        }

        private IList<object[]> GetAfterOrder(BindVarCollection bc)
        {
            IList<object[]> lObj = new List<object[]>();

            OUT1001P03GrdAfterOrderArgs args = new OUT1001P03GrdAfterOrderArgs();
            args.Bunho = this.paBeforeBox.BunHo;
            args.IoGubun = this.rbnOut.Checked ? "O" : "I";
            args.NaewonKey = bc["f_naewon_key"].VarValue;
            OUT1001P03GrdAfterOrderResult res = CloudService.Instance.Submit<OUT1001P03GrdAfterOrderResult, OUT1001P03GrdAfterOrderArgs>(args);

            if (null != res)
            {
                foreach (OUT1001P03GrdOrderInfo item in res.GrdOrderInfo)
                {
                    lObj.Add(new object[]
                    {
                        item.Pkocskey,
                        item.OrderGubun,
                        item.OrderGubunName,
                        item.HangmogCode,
                        item.HangmogName,
                        item.Suryang,
                        item.OrdDanui,
                        item.Nalsu
                    });
                }
            }
            return lObj;
        }
        #endregion
    }
}