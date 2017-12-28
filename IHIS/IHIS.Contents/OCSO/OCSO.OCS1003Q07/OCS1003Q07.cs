using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using IHIS.Framework;

namespace IHIS.OCSO
{
    public partial class OCS1003Q07 : XScreen
    {
        public OCS1003Q07()
        {
            InitializeComponent();
        }

        #region 스크린 변수

        ///////////////////////////////////////////////////////////////////////////////////
        // 라디오버튼 관련
        ///////////////////////////////////////////////////////////////////////////////////
        private XColor mSelectedBackColor = new XColor(Color.FromName("ActiveCaption"));
        private XColor mSelectedForeColor = new XColor(Color.FromName("ActiveCaptionText"));

        private XColor mUnSelectedBackColor = new XColor(Color.FromName("InactiveCaption"));
        private XColor mUnSelectedForeColor = new XColor(Color.FromName("InactiveCaptionText"));

        private string mCurrentIoGubun = "%";

        private string mParamGwa = "%";

        #endregion

        #region [ Screen 이벤트 ]

        private void OCS1003Q07_Load(object sender, EventArgs e)
        {
            this.InitScreen();

            PostCallHelper.PostCall(new PostMethod(PostLoad));
        }

        private void PostLoad()
        {
            if (TypeCheck.IsNull(this.paBox.BunHo))
            {
                XPatientInfo patientInfo = XScreen.GetPreviousScreenBunHo(true);

                if (patientInfo == null || (patientInfo != null && TypeCheck.IsNull(patientInfo.BunHo)))
                {
                    // 이전 스크린의 등록번호를 못가지고 온 경우, 열려있는 전체 스크린에서 등록번호를 가져온다
                    patientInfo = XScreen.GetOtherScreenBunHo(this, true);
                }

                if (patientInfo != null)
                {
                    this.paBox.SetPatientID(patientInfo.BunHo);
                }

            }
        }

        #endregion

        #region Function

        private void InitScreen()
        {
            

            // 입원 외래 
            this.rbnAll.Checked = true;

            // 전체 오더 구분
            this.tabOrderGubun.SelectedIndex = 0;

            if (mParamGwa != "")
            {
                this.cboGwa.SetDataValue(this.mParamGwa);
            }

            // 현재월
            //this.mbxMonth.SetDataValue(EnvironInfo.GetSysDate().ToString("yyyyMM"));
            string month = EnvironInfo.GetSysDate().ToString("yyyyMM");

            if (month != "")
                this.calOrder.SetActiveMonth(int.Parse(month.Substring(0, 4)), int.Parse(month.Substring(4, 2)));
        }

        private void ResetCalender()
        {
            this.calOrder.ResetText();
            this.calOrder.Dates.Clear();
            this.calOrder.ResetCalendarDates();
            
        }

        private string GetCurrentMonth()
        {
            return this.calOrder.CurrentMonth.Replace("/", "");
        }

        private void SetNaewonHisInfo(MultiLayout aLayData)
        {
            string currentDate = "";

            string strText = "";
            XCalendarDate dateItem;

            this.ResetCalender();

            this.calOrder.Redraw = false;
            foreach (DataRow dr in aLayData.LayoutTable.Rows)
            {
                if (dr["naewon_date"].ToString() != currentDate)
                {
                    currentDate = dr["naewon_date"].ToString();

                    if (strText != "")
                    {
                        dateItem = new XCalendarDate(DateTime.Parse(dr["naewon_date"].ToString()));
                        dateItem.ContentText = strText;
                        dateItem.ContentTextColor = new XColor(Color.Blue);
                        dateItem.ContentFont = new Font("MS UI Gothic", (float)9.75, FontStyle.Italic);
                        this.calOrder.Dates.Add(dateItem);
                    }

                    strText = "";
                }
                
                if (dr["io_gubun"].ToString() == "O")
                {
                    strText = "【" + "外来" + "】-" + dr["gwa_name"].ToString();
                }
                else
                {
                    strText = "【" + "入院" + "】-" + dr["gwa_name"].ToString();
                }

            }

            if (currentDate != "")
            {
                dateItem = new XCalendarDate(DateTime.Parse(currentDate));
                dateItem.ContentText = strText;
                dateItem.ContentTextColor = new XColor(Color.Blue);
                dateItem.ContentFont = new Font("MS UI Gothic", (float)9.75, FontStyle.Italic);
                this.calOrder.Dates.Add(dateItem);
            }

            this.calOrder.Redraw = true;
        }

        private void SetOrderHisInfo(MultiLayout aLayData)
        {
            string currentDate = "";
            string currentGwa = "";

            string strText = "";
            XCalendarDate dateItem;

            this.ResetCalender();

            this.calOrder.Redraw = false;
            foreach (DataRow dr in aLayData.LayoutTable.Rows)
            {
                if (dr["acting_date"].ToString() != currentDate)
                {
                    

                    if (strText != "")
                    {
                        dateItem = new XCalendarDate(DateTime.Parse(currentDate));
                        dateItem.ContentText = strText;
                        dateItem.ContentTextColor = new XColor(Color.Black);
                        dateItem.ContentFont = new Font("MS UI Gothic", (float)11, FontStyle.Bold);
                        dateItem.ContentAlign = ContentAlignment.MiddleLeft;
                        this.calOrder.Dates.Add(dateItem);
                    }

                    currentDate = dr["acting_date"].ToString();
                    strText = "";
                    currentGwa = "";
                }

                if (dr["gwa"].ToString() != currentGwa)
                {
                    if (strText != "")
                    {
                        strText += "\n";
                    }

                    strText += "【" + dr["gwa_name"].ToString() + "】\n";

                    currentGwa = dr["gwa"].ToString();
                }

                //if (strText != "")
                //    strText += "\n";

                strText += "  " + dr["order_gubun_name"].ToString() + ",";

                //if (dr["io_gubun"].ToString() == "O")
                //{
                //    strText = "【" + "外来" + "】-" + dr["gwa_name"].ToString();
                //}
                //else
                //{
                //    strText = "【" + "入院" + "】-" + dr["gwa_name"].ToString();
                //}

            }

            if (currentDate != "")
            {
                dateItem = new XCalendarDate(DateTime.Parse(currentDate));
                dateItem.ContentText = strText;
                dateItem.ContentTextColor = new XColor(Color.Black);
                dateItem.ContentFont = new Font("MS UI Gothic", (float)11, FontStyle.Bold);
                dateItem.ContentAlign = ContentAlignment.MiddleLeft;
                this.calOrder.Dates.Add(dateItem);
            }

            this.calOrder.Redraw = true;
        }

        #endregion

        #region Load Data

        private void LoadNaewonHis(string aIoGubun, string aBunho, string aGwa, string aMonth)
        {
            this.layNaewonList.SetBindVarValue("f_io_gubun", aIoGubun);
            this.layNaewonList.SetBindVarValue("f_bunho", aBunho);
            this.layNaewonList.SetBindVarValue("f_gwa", aGwa);
            this.layNaewonList.SetBindVarValue("f_query_yymm", aMonth);
            this.layNaewonList.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);

            this.layNaewonList.QueryLayout(true);

            this.SetNaewonHisInfo(this.layNaewonList);
        }

        private void LoadOrderHis(string aIoGubun, string aBunho, string aGwa, string aMonth, string aOrderGubun)
        {
            this.layOrderHistory.SetBindVarValue("f_io_gubun", aIoGubun);
            this.layOrderHistory.SetBindVarValue("f_bunho", aBunho);
            this.layOrderHistory.SetBindVarValue("f_gwa", aGwa);
            this.layOrderHistory.SetBindVarValue("f_query_yymm", aMonth);
            this.layOrderHistory.SetBindVarValue("f_order_gubun", aOrderGubun);
            this.layOrderHistory.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);

            this.layOrderHistory.QueryLayout(true);

            this.SetOrderHisInfo(this.layOrderHistory);
        }

        #endregion

        #region [ XPatient Box ]

        private void paBox_PatientSelected(object sender, EventArgs e)
        {
            //this.LoadNaewonHis(this.mCurrentIoGubun, this.paBox.BunHo, mParamGwa, mbxMonth.GetDataValue());
            if ( this.paBox.BunHo != "")
                this.LoadOrderHis(this.mCurrentIoGubun, this.paBox.BunHo, this.cboGwa.GetDataValue(), this.GetCurrentMonth(), this.tabOrderGubun.SelectedTab.Tag.ToString());
        }

        #endregion

        #region [ 컨트롤 이벤트 ]

        #region [ 라디오 버튼 ]

        private void rbnIoGubun_CheckedChanged(object sender, EventArgs e)
        {
            XRadioButton control = sender as XRadioButton;

            if (control.Checked)
            {
                control.BackColor = mSelectedBackColor;
                control.ForeColor = mSelectedForeColor;
                control.ImageIndex = 0;

                this.mCurrentIoGubun = control.Tag.ToString();
                if (this.paBox.BunHo != "")
                    this.LoadOrderHis(this.mCurrentIoGubun, this.paBox.BunHo, this.cboGwa.GetDataValue(), this.GetCurrentMonth(), this.tabOrderGubun.SelectedTab.Tag.ToString());

            }
            else
            {
                control.BackColor = mUnSelectedBackColor;
                control.ForeColor = mUnSelectedForeColor;
                control.ImageIndex = 1;
            }
        }

        #endregion

        #region [ 탭 페이지 ]

        private void tabOrderGubun_SelectionChanged(object sender, EventArgs e)
        {
            foreach (IHIS.X.Magic.Controls.TabPage tpg in this.tabOrderGubun.TabPages)
            {
                if (tpg == this.tabOrderGubun.SelectedTab)
                {
                    tpg.ImageIndex = 0;

                    this.LoadOrderHis(this.mCurrentIoGubun, this.paBox.BunHo, this.cboGwa.GetDataValue(), this.GetCurrentMonth(), this.tabOrderGubun.SelectedTab.Tag.ToString());
                }
                else
                {
                    tpg.ImageIndex = 1;
                }
            }
        }

        #endregion

        #region 진료과

        private void cboGwa_SelectedValueChanged(object sender, EventArgs e)
        {
            if( this.paBox.BunHo != "" && this.cboGwa.GetDataValue() != "")
                this.LoadOrderHis(this.mCurrentIoGubun, this.paBox.BunHo, this.cboGwa.GetDataValue(), this.GetCurrentMonth(), this.tabOrderGubun.SelectedTab.Tag.ToString());
        }

        #endregion

        

        private void calOrder_MonthChanged(object sender, XCalendarMonthChangedEventArgs e)
        {

            this.LoadOrderHis(this.mCurrentIoGubun, this.paBox.BunHo, this.cboGwa.GetDataValue(), this.GetCurrentMonth(), this.tabOrderGubun.SelectedTab.Tag.ToString());
        }

        #endregion

        
        
    }
}