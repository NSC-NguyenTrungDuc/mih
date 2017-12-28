using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using IHIS.Framework;


namespace IHIS.NURI
{
    public partial class INP1001D00 : XScreen
    {
        public INP1001D00()
        {
            InitializeComponent();
        }

        #region Screen ｺｯｼ・

        ///////////////////////////////////////////////////////////////////////////////////
        // ｶﾀｹｰ ｰ・?
        ///////////////////////////////////////////////////////////////////////////////////
        private XColor mSelectedBackColor = new XColor(Color.FromName("ActiveCaption"));
        private XColor mSelectedForeColor = new XColor(Color.FromName("ActiveCaptionText"));

        private XColor mUnSelectedBackColor = new XColor(Color.FromName("InactiveCaption"));
        private XColor mUnSelectedForeColor = new XColor(Color.FromName("InactiveCaptionText"));

        private string mCurrentSendYN = "";

        #endregion

        #region Screen ﾀﾌｺ･ﾆｮ

        private void INP1001D00_Load(object sender, EventArgs e)
        {
            this.InitScreen();

            // ﾀｯﾀ・ｺｯｰ・ﾀﾌｺ･ﾆｮ 
            this.INP1001D00_UserChanged(this, new EventArgs());
        }

        private void INP1001D00_UserChanged(object sender, EventArgs e)
        {
            this.SetVisibleControlByUser();
        }

        private void INP1001D00_HiddenDockingScreenAppearing(object sender, EventArgs e)
        {
            this.btnList.PerformClick(FunctionType.Query);
        }

        #endregion

        #region Function 

        #region ﾃﾊｱ篳ｭ ｺｯｼ・

        private void InitScreen()
        {
            this.cboHoDong.SelectedValueChanged -= new EventHandler(cboHoDong_SelectedValueChanged);

            if (UserInfo.UserGubun == UserType.Nurse)
            {
                this.cboHoDong.SetDataValue(UserInfo.HoDong);
            }
            else
            {
                this.cboHoDong.SetDataValue("%");
            }            
            this.cboHoDong.SelectedValueChanged += new EventHandler(cboHoDong_SelectedValueChanged);

            this.dtpQueryDate.SetDataValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
        }

        private void SetVisibleControlByUser()
        {
            //if (UserInfo.UserGubun == UserType.Normal)
            //{
            //    this.rbnNotSend.Checked = true;
            //    this.pnlKaikei.Visible = true;
            //}
            //else
            //{
            this.rbnAll.Checked = true;
            this.pnlKaikei.Visible = false;
            //}
        }

        #endregion

        #region ﾀﾌｹﾌﾁ・ﾇﾔｼ・

        private void SetDefaultGridImage()
        {
            for (int i = 0; i < this.grdINP1001.RowCount; i++)
            {
                if (this.grdINP1001.GetItemString(i, "toiwon_goji_yn") == "Y")
                {
                    this.grdINP1001[i + this.grdINP1001.HeaderHeights.Count, 0].Image = this.ImageList.Images[2];
                    this.grdINP1001[i + this.grdINP1001.HeaderHeights.Count, 0].ToolTipText = "・褸・";
                }
            }
        }

        #endregion

        #endregion

        #region DataLoad

        private void LoadData(string aHoDong, string aQueryDate, string aSendYN)
        {
            this.grdINP1001.SetBindVarValue("f_ho_dong1", aHoDong);
            this.grdINP1001.SetBindVarValue("f_query_date", aQueryDate);
            this.grdINP1001.SetBindVarValue("f_send_yn", aSendYN);

            this.grdINP1001.QueryLayout(true);

            this.SetDefaultGridImage();
        }

        #endregion

        #region ﾄﾁﾆｮｷﾑ ﾀﾌｺ･ﾆｮ

        #region ﾄﾞｺｸ ｹﾚｽｺ

        private void cboHoDong_SelectedValueChanged(object sender, EventArgs e)
        {
            this.btnList.PerformClick(FunctionType.Query);
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

        #region Radio Button

        private void rbnSend_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton control = sender as RadioButton;

            if (control.Checked)
            {
                control.BackColor = this.mSelectedBackColor.Color;
                control.ForeColor = this.mSelectedForeColor.Color;
                control.ImageIndex = 0;

                this.mCurrentSendYN = control.Tag.ToString();

                this.btnList.PerformClick(FunctionType.Query);
            }
            else
            {
                control.BackColor = this.mUnSelectedBackColor.Color;
                control.ForeColor = this.mUnSelectedForeColor.Color;
                control.ImageIndex = 1;
            }
        }

        #endregion

        #region ｹｰｸｮｽｺﾆｮ

        private void btnList_ButtonClick(object sender, ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Query:

                    e.IsBaseCall = false;

                    this.LoadData(this.cboHoDong.GetDataValue(), this.dtpQueryDate.GetDataValue(), this.mCurrentSendYN);

                    break;

                case FunctionType.Close:

                    e.IsBaseCall = false;

                    this.HideDocking();

                    break;
            }
        }

        #endregion

        #region ｱﾗｸｮｵ・ﾀﾌｺ･ﾆｮ

        private void grdINP1001_MouseDown(object sender, MouseEventArgs e)
        {
            XEditGrid grid = sender as XEditGrid;
            int rowNumber = -1;

            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                rowNumber = grid.GetHitRowNumber(e.Y);

                if (rowNumber < 0) return;

                this.SendPatient(rowNumber);

                //this.btnList.PerformClick(FunctionType.Close);
            }
        }

        #endregion

        #endregion

        #region [Send Patient Info]

        private void SendPatient(int aRowNumber)
        {
            string bunho = this.grdINP1001.GetItemString(aRowNumber, "bunho");
            string suname = this.grdINP1001.GetItemString(aRowNumber, "suname");
            string gwa = this.grdINP1001.GetItemString(aRowNumber, "gwa");
            string hodong = this.grdINP1001.GetItemString(aRowNumber, "ho_dong");
            string pkinp1001 = this.grdINP1001.GetItemString(aRowNumber, "pkinp1001");

            XPatientInfo paInfo = new XPatientInfo(bunho, suname, gwa, hodong, pkinp1001, PatientPKGubun.In, this.ScreenName);

            XScreen.SendPatientInfo(paInfo);
        }

        #endregion

        private void grdINP1001_GridCellPainting(object sender, XGridCellPaintEventArgs e)
        {

            string status = grdINP1001.GetItemString(e.RowNumber, "order_status");
            switch (status)
            {
                case "Y1":
                    e.BackColor = Color.LightPink;
                    break;

                case "Y2":
                    e.BackColor = Color.SkyBlue;
                    break;
            }

            if (grdINP1001.GetItemString(e.RowNumber, "same_name_yn") == "Y")
            {
                e.ForeColor = Color.Red;
            }

        }

        
    }
}