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
    public partial class INP1001D01 : XScreen
    {
        public INP1001D01()
        {
            InitializeComponent();
        }

        #region Screen ∫ØºÅE

        ///////////////////////////////////////////////////////////////////////////////////
        // ∂Ûµø¿πˆ∆∞ ∞ÅE?
        ///////////////////////////////////////////////////////////////////////////////////
        private XColor mSelectedBackColor = new XColor(Color.FromName("ActiveCaption"));
        private XColor mSelectedForeColor = new XColor(Color.FromName("ActiveCaptionText"));

        private XColor mUnSelectedBackColor = new XColor(Color.FromName("InactiveCaption"));
        private XColor mUnSelectedForeColor = new XColor(Color.FromName("InactiveCaptionText"));

        private string mCurrentSendYN = "";

        #endregion

        #region Screen ¿Ã∫•∆Æ

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
            this.cboHoDong.SelectedValueChanged -= new EventHandler(cboHoDong_SelectedValueChanged);
            this.cboHoDong.SetDataValue("%");
            this.cboHoDong.SelectedValueChanged += new EventHandler(cboHoDong_SelectedValueChanged);
            this.cboHoDong.AcceptData();

            this.dtpQueryDate.SetDataValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));

            this.grdINP1001.QueryLayout(true);

            this.timer1.Start();
        }

        #endregion

        #region ¿ÃπÃ¡ÅE∞ÅE?

        private void SetDefaultGridImage()
        {
            for (int i = 0; i < this.grdINP1001.RowCount; i++)
            {

                // toi_res
                // 1:toiwon_goji, 2:reser, 3:normal
                switch (this.grdINP1001.GetItemString(i, "toi_res"))
                {
                    case "1":
                        this.grdINP1001[i + this.grdINP1001.HeaderHeights.Count, 0].Image = this.ImageList.Images[2];
                        this.grdINP1001[i + this.grdINP1001.HeaderHeights.Count, 0].ToolTipText = "ëﬁâ@ë“Çø";
                        break;

                    case "2":
                        this.grdINP1001[i + this.grdINP1001.HeaderHeights.Count, 0].Image = this.ImageList.Images[3];
                        this.grdINP1001[i + this.grdINP1001.HeaderHeights.Count, 0].ToolTipText = "ì¸â@ë“Çø";
                        break;

                    default:
                        this.grdINP1001[i + this.grdINP1001.HeaderHeights.Count, 0].ToolTipText = "ç›â@íÜ";
                        break;
                }
            }
        }

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

        #region ButtonList

        private void btnList_ButtonClick(object sender, ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Query:

                    e.IsBaseCall = false;

                    this.grdINP1001.QueryLayout(true);

                    break;

                case FunctionType.Close:

                    e.IsBaseCall = false;

                    this.HideDocking();

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

                //this.btnList.PerformClick(FunctionType.Close);

                //1 toiwon, 2 reservation, 3 normal

                
                switch (grdINP1001.GetItemString(rowNumber,"toi_res"))
                {
                    case "1":
                        OpenScreen(this, "INP3003U00", ScreenOpenStyle.PopUpFixed, ScreenAlignment.ParentTopRight);
                        break;

                    case "2":
                        OpenScreen(this, "INP1001U01", ScreenOpenStyle.PopUpFixed, ScreenAlignment.ParentTopRight);
                        break;

                    case "3":
                        OpenScreen(this, "INPORDERTRANS", ScreenOpenStyle.PopUpFixed, ScreenAlignment.ParentTopRight);
                        break;

                }

                this.SendPatient(rowNumber);
                
            }
        }

        private void grdINP1001_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdINP1001.SetBindVarValue("f_ho_dong1", cboHoDong.GetDataValue());
            this.grdINP1001.SetBindVarValue("f_query_date", dtpQueryDate.GetDataValue());
            this.grdINP1001.SetBindVarValue("f_suname2", txtName.Text);
        }

        private void grdINP1001_QueryEnd(object sender, QueryEndEventArgs e)
        {
            this.SetDefaultGridImage();
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (cbxAutoQuery.Checked)
            {
                this.grdINP1001.QueryLayout(true);
            }
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnList.PerformClick(FunctionType.Query);
            }
        }

    }
}