using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using IHIS.Framework;
    
namespace IHIS.CPLS
{
    public partial class CPL2010R02 : IHIS.Framework.XScreen
    {
        #region [생성자]
        public CPL2010R02()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception x)
            {
                //https://sofiamedix.atlassian.net/browse/MED-10610
                //XMessageBox.Show(x.StackTrace + "----" + x.Message);
            }
        }
        #endregion

        #region [fields]
        private string mBunho = ""; //환자번호
        private string mOrderDate = ""; //오더일
        private string mInOutGubun = "";    //외래 병동구분
        private string mMsg = "";   //메시지 내용
        private string mCap = "";   //메시지 박스 머리
        private string mGwa = "";   //과 코드
        private string mDoctor = "";    //의사 코드
        private string mSpecimenCode = "";  //검체명
        private string mNaewonKey = ""; //내원 
        private string mReOut = ""; //재출력인지 아닌지 체크
        #endregion

        #region [스크린 오픈]
        private void CPL2010R02_ScreenOpen(object sender, XScreenOpenEventArgs e)
        {
            if (this.OpenParam != null) //오더 후 바로 의뢰서 출력 부분
            {
                if (this.OpenParam.Contains("bunho"))
                {
                    this.mBunho = this.OpenParam["bunho"].ToString();
                    this.fbxBunho.DataValidating -= new DataValidatingEventHandler(fbxBunho_DataValidating);
                    this.fbxBunho.SetEditValue(this.mBunho);
                    this.fbxBunho.AcceptData();
                    this.fbxBunho.DataValidating += new DataValidatingEventHandler(fbxBunho_DataValidating);
                }
                if (this.OpenParam.Contains("order_date"))
                {
                    this.mOrderDate = this.OpenParam["order_date"].ToString();
                    this.dtpOrderDate.DataValidating -= new DataValidatingEventHandler(dtpOrderDate_DataValidating);
                    this.dtpOrderDate.SetEditValue(this.mOrderDate);
                    this.dtpOrderDate.AcceptData();
                    this.dtpOrderDate.DataValidating += new DataValidatingEventHandler(dtpOrderDate_DataValidating);
                }
                if (this.OpenParam.Contains("in_out_gubun"))
                {
                    this.mInOutGubun = this.OpenParam["in_out_gubun"].ToString();
                }
                if (this.OpenParam.Contains("gwa"))
                {
                    this.mGwa = this.OpenParam["gwa"].ToString();
                }
                if (this.OpenParam.Contains("doctor"))
                {
                    this.mDoctor = this.OpenParam["doctor"].ToString();
                }
                if (this.OpenParam.Contains("specimen_code"))
                {
                    this.mSpecimenCode = this.OpenParam["specimen_code"].ToString();
                }
                if (this.OpenParam.Contains("naewon_key"))
                {
                    this.mNaewonKey = this.OpenParam["naewon_key"].ToString();
                }
                this.mReOut = "N";
                this.ParentForm.WindowState = FormWindowState.Minimized;

                PostCallHelper.PostCall(new PostMethod(this.AutoCloseRoutine));
            }
            else //재 출력하기 위해 창을 여는 부분
            {
  //              this.dwcpllist.Modify("DataWindow.Print.Preview=Yes");
  //              this.dwcpllist.Modify("DataWindow.Print.Preview.Zoom= 70");
                this.mReOut = "Y";
                Rectangle rc = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;
                this.ParentForm.Size = new System.Drawing.Size(this.Width, (rc.Height - 120));
                this.dtpOrderDate.SetEditValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd").ToString());
                this.dtpOrderDate.AcceptData();
                this.fbxBunho.Focus();
                
            }
        }
        #endregion

        #region [DataLoad]

        private void    LoadOrderList() //환자에 따른 모든 검체 오더 출력
        {
            this.grdOrderList.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdOrderList.SetBindVarValue("f_bunho", this.fbxBunho.GetDataValue());
            this.grdOrderList.SetBindVarValue("f_order_date", this.dtpOrderDate.GetDataValue());
            this.grdOrderList.SetBindVarValue("f_in_out_gubun", this.mInOutGubun);
            this.grdOrderList.SetBindVarValue("f_re_output", this.mReOut);

            this.grdOrderList.QueryLayout(true);

            if (this.grdOrderList.RowCount <= 0)
            {
                this.grdcpllist.Reset();
    //            this.dwcpllist.Reset();
            }
        }

        private void LoadCplList(int aOrderRow) //검체 오더 선택
        {
            this.grdcpllist.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdcpllist.SetBindVarValue("f_bunho", this.grdOrderList.GetItemString(aOrderRow, "bunho"));
            this.grdcpllist.SetBindVarValue("f_in_out_gubun", this.grdOrderList.GetItemString(aOrderRow, "in_out_gubun"));
            this.grdcpllist.SetBindVarValue("f_order_date", this.grdOrderList.GetItemString(aOrderRow, "order_date"));
            this.grdcpllist.SetBindVarValue("f_pkocs", this.grdOrderList.GetItemString(aOrderRow, "pkocskey"));
            this.grdcpllist.SetBindVarValue("f_jundal_part", this.grdOrderList.GetItemString(aOrderRow, "jundal_part"));
            this.grdcpllist.SetBindVarValue("f_gwa",this.grdOrderList.GetItemString(aOrderRow,"gwa"));
            this.grdcpllist.SetBindVarValue("f_doctor", this.grdOrderList.GetItemString(aOrderRow, "doctor"));
            this.grdcpllist.SetBindVarValue("f_specimen_code", this.grdOrderList.GetItemString(aOrderRow, "specimen_code"));
            this.grdcpllist.SetBindVarValue("f_fkout1001", this.grdOrderList.GetItemString(aOrderRow, "naewon_key"));
            this.grdcpllist.SetBindVarValue("f_fkinp1001", this.grdOrderList.GetItemString(aOrderRow, "naewon_key"));
            this.grdcpllist.SetBindVarValue("f_re_output", this.mReOut);
            this.grdcpllist.QueryLayout(true);

 //           this.dwcpllist.Reset();
 //           this.dwcpllist.FillData(this.grdcpllist.LayoutTable);
        }

        #endregion

        #region [AutoCloseRoutine 리스트 출력하고 창 닫는 루틴]
        private void AutoCloseRoutine()
        {
            //this.LoadOrderList();
            this.grdcpllist.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdcpllist.SetBindVarValue("f_bunho", this.mBunho);
            this.grdcpllist.SetBindVarValue("f_in_out_gubun", this.mInOutGubun);
            this.grdcpllist.SetBindVarValue("f_order_date", this.mOrderDate);
            this.grdcpllist.SetBindVarValue("f_gwa", this.mGwa);
            this.grdcpllist.SetBindVarValue("f_doctor", this.mDoctor);
            this.grdcpllist.SetBindVarValue("f_specimen_code", this.mSpecimenCode);
            this.grdcpllist.SetBindVarValue("f_fkout1001", this.mNaewonKey);
            this.grdcpllist.SetBindVarValue("f_fkinp1001", this.mNaewonKey);
            this.grdcpllist.SetBindVarValue("f_re_output", this.mReOut);
            this.grdcpllist.QueryLayout(true);
            if (this.grdcpllist.RowCount > 0)
            {
                //this.dwcpllist.Reset();
                //this.dwcpllist.FillData(this.grdcpllist.LayoutTable);
                //dwcpllist.Print();
            }
            this.Close();
        }
        #endregion

        #region XFindBox

        private void fbxBunho_FindClick(object sender, CancelEventArgs e)
        {
            this.ScreenOpen_OUT0101Q01();
        }

        private void fbxBunho_DataValidating(object sender, DataValidatingEventArgs e)
        {
            if (e.DataValue == "")
            {
                this.dbxSuname.SetDataValue("");
                this.Reset();
  //              this.dwcpllist.Reset();
                this.dtpOrderDate.SetEditValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd").ToString());
                this.fbxBunho.Focus();
                this.SetMsg("");
                return;
            }

            string bunho = BizCodeHelper.GetStandardBunHo(e.DataValue);
            object name = null;
            Hashtable param = new Hashtable();

            string cmd = " SELECT   A.SUNAME"
                       + " FROM     OUT0101 A "
                       + " WHERE    A.BUNHO = '" + bunho + "' ";

            name = Service.ExecuteScalar(cmd);

            if (name == null || name.ToString() == "")
            {
                param.Add("success_yn", "N");
            }
            else
            {
                param.Add("success_yn", "Y");
                param.Add("bunho", bunho);
                param.Add("suname", name.ToString());
            }
            PostCallHelper.PostCall(new PostMethodObject(PostBunhoValidating), param);
        }

        private void PostBunhoValidating(object aParam)
        {
            Hashtable param = aParam as Hashtable;
            if (param.Contains("success_yn"))
            {
                if (param["success_yn"].ToString() == "Y")
                {
                    this.fbxBunho.SetDataValue(param["bunho"].ToString());
                    this.dbxSuname.SetDataValue(param["suname"].ToString());

                    this.btnList.PerformClick(FunctionType.Query);
                }
                else
                {
                    this.mMsg = "患者番号を確認してください。";
                    this.mCap = "確認";

                    XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

                    this.fbxBunho.SetDataValue("");
                    this.dbxSuname.SetDataValue("");
                    this.Reset();
   //                 this.dwcpllist.Reset();
                    this.dtpOrderDate.SetEditValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd").ToString());
                    this.fbxBunho.Focus();
                }
            }
        }

        #endregion

        #region [ Grid Event ]

        #region [ 오더 리스트 그리드 ]

        private void grdOrderList_RowFocusChanged(object sender, RowFocusChangedEventArgs e)
        {
            this.LoadCplList(e.CurrentRow);
        }

        #endregion

        #region [ 검체검사 출력 그리드 ]

        #endregion

        #endregion

        #region 다른화면 오픈

        private void ScreenOpen_OUT0101Q01()
        {
            XScreen.OpenScreen(this, "OUT0101Q01", ScreenOpenStyle.ResponseFixed);
        }

        #endregion 

        #region XDatePicker

        private void dtpOrderDate_DataValidating(object sender, DataValidatingEventArgs e)
        {
            this.LoadOrderList();
        }

        #endregion

        #region [XButtonList]

        private void btnList_ButtonClick(object sender, ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Query :

                    e.IsBaseCall = false;

                    this.LoadOrderList();

                    break;

                case FunctionType.Print :

                    //if (this.grdcpllist.RowCount > 0)
                    //{
                    //    this.dwcpllist.Print();
                    //}

                    break;
            }
        }

        #endregion

        #region 다른화면에서 값 받아오기
        public override object Command(string command, CommonItemCollection commandParam)
        {
            switch (command)
            {
                case "OUT0101":

                    if (commandParam != null)
                    {
                        this.fbxBunho.Focus();
                        this.fbxBunho.SetEditValue(((MultiLayout)commandParam[0]).GetItemString(0, "bunho"));
                        this.fbxBunho.AcceptData();
                    }

                    break;
            }
            return base.Command(command, commandParam);
        }
        #endregion

    }
}