using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using IHIS.Framework;
using IHIS.INPS.Properties;


namespace IHIS.INPS
{
    public partial class INP1001Q00 : XScreen
    {
        public INP1001Q00()
        {
            InitializeComponent();
        }

        #region Screen 변펯E

        ///////////////////////////////////////////////////////////////////////////////////
        // 라디오버튼 컖E?
        ///////////////////////////////////////////////////////////////////////////////////
        private XColor mSelectedBackColor = new XColor(Color.FromName("ActiveCaption"));
        private XColor mSelectedForeColor = new XColor(Color.FromName("ActiveCaptionText"));

        private XColor mUnSelectedBackColor = new XColor(Color.FromName("InactiveCaption"));
        private XColor mUnSelectedForeColor = new XColor(Color.FromName("InactiveCaptionText"));

        private string mCurrentSendYN = "";

        #endregion

        #region Screen 이벤트

        private void INP1001D00_Load(object sender, EventArgs e)
        {
            Rectangle rc = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;
            this.ParentForm.Size = new System.Drawing.Size(ParentForm.Size.Width , rc.Height - 105);
            
            this.InitScreen();

        }

        #endregion

        #region Function 

        #region InitScreen

        private void InitScreen()
        {
            this.dtpFromDate.SetDataValue(EnvironInfo.GetSysDate().AddMonths(-3).ToString("yyyy/MM/dd"));
            this.dtpToDate.SetDataValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));

            this.grdINP1001.QueryLayout(true);
        }

        #endregion

        #region 이미햨E컖E?

        #endregion

        #endregion

        #region Control Action

        #region cboHoDong Change

        private void cboHoDong_SelectedValueChanged(object sender, EventArgs e)
        {
            this.btnList.PerformClick(FunctionType.Query);
            grdINP1001.Focus();
        }

        #endregion

        #region Date Picker

        private void dtpQueryDate_DataValidating(object sender, DataValidatingEventArgs e)
        {
            if (e.DataValue != "")
            {
                PostCallHelper.PostCall(new PostMethod(PostDateValidating));
            }
        }

        private void PostDateValidating()
        {
            this.btnList.PerformClick(FunctionType.Query);
        }

        #endregion

        #region ButtonList

        private void btnList_ButtonClick(object sender, ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Query:

                    e.IsBaseCall = false;

                    this.grdINP1001.QueryLayout(true);

                    break;
            }
        }

        #endregion

        #region grdINP1001 Action

        private void grdINP1001_MouseDown(object sender, MouseEventArgs e)
        {
            XEditGrid grid = sender as XEditGrid;
            int rowNumber = -1;

            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                rowNumber = grid.GetHitRowNumber(e.Y);

                if (rowNumber < 0) return;
                
                
            }
        }

        private void grdINP1001_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdINP1001.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdINP1001.SetBindVarValue("f_bunho", paBox.BunHo);
            this.grdINP1001.SetBindVarValue("f_from_date", dtpFromDate.GetDataValue());
            this.grdINP1001.SetBindVarValue("f_to_date", dtpToDate.GetDataValue());
        }
        #endregion

        #endregion

        private void paBox_PatientSelected(object sender, EventArgs e)
        {
            grdINP1001.QueryLayout(false);
        }


        private void btnVital_Click(object sender, EventArgs e)
        {
            if (this.paBox.BunHo.ToString() == "")
            {
                XMessageBox.Show(Resources.MSG001_MSG);
                paBox.Focus();
                return;
            }
            else
            {
                string toiwon_date = this.grdINP1001.GetItemString(grdINP1001.CurrentRowNumber, "toiwon_date");

                if (toiwon_date == "")
                {
                    toiwon_date = EnvironInfo.GetSysDate().ToShortDateString();
                }

                CommonItemCollection openParams = new CommonItemCollection();
                openParams.Add("sysid", EnvironInfo.CurrSystemID);
                openParams.Add("screen", this.ScreenID.ToString());
                openParams.Add("bunho", this.paBox.BunHo);
                openParams.Add("date", toiwon_date);
                //openParams.Add("hodong", this.cboHo_dong.GetDataValue());
                openParams.Add("jaewon_yn", this.grdINP1001.GetItemString(grdINP1001.CurrentRowNumber, "jaewon_flag"));
                openParams.Add("fkinp1001", this.grdINP1001.GetItemString(grdINP1001.CurrentRowNumber, "pkinp1001"));


                XScreen.OpenScreenWithParam(this, "NURI", "NUR1020Q00", ScreenOpenStyle.PopUpFixed, ScreenAlignment.ParentTopLeft, openParams);
            }

        }

        private void btnChiryo_Click(object sender, EventArgs e)
        {
            if (this.paBox.BunHo.ToString() == "")
            {
                XMessageBox.Show(Resources.MSG001_MSG);
                paBox.Focus();
                return;
            }
            else
            {
                //IXScreen screen = XScreen.FindScreen("OCSI", "OCS6010U10");
                //if (screen == null)
                //{

                string toiwon_date = this.grdINP1001.GetItemString(grdINP1001.CurrentRowNumber, "toiwon_date");

                if (toiwon_date == "")
                {
                    toiwon_date = EnvironInfo.GetSysDate().ToShortDateString();
                }


                    CommonItemCollection openParams = new CommonItemCollection();
                    openParams.Add("sysid", "NURI");
                    openParams.Add("screen", this.ScreenID.ToString());
                    openParams.Add("bunho", this.paBox.BunHo);
                    openParams.Add("fkinp1001", this.grdINP1001.GetItemString(grdINP1001.CurrentRowNumber, "pkinp1001"));
                    openParams.Add("jaewon_yn", this.grdINP1001.GetItemString(grdINP1001.CurrentRowNumber, "jaewon_flag"));
                    openParams.Add("query_date", toiwon_date);


                    XScreen.OpenScreenWithParam(this, "OCSI", "OCS6010U10", ScreenOpenStyle.PopUpFixed, ScreenAlignment.ParentTopLeft, openParams);
                //}
                //else
                //{
                //    screen.Activate();
                //    XPatientInfo pInfo = new XPatientInfo(paBox.BunHo, "", "", "", this.grdINP1001.GetItemString(grdINP1001.CurrentRowNumber, "pkinp1001"), PatientPKGubun.In, this.ScreenID);
                //    XScreen.SendPatientInfo(pInfo);
                //}
            
            }
        }

    }
}