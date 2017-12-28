using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Globalization;
using System.IO;
using System.Text;
using System.Web;
using System.Windows.Forms;
using EmrDocker;

namespace IHIS.OCSO
{
    using IHIS.Framework;
    using IHIS.OCSA;

    public partial class OCS2015U11 : XScreen
    {
        private OCS2015U00 mainScreen;

        #region Contructor
        public OCS2015U11(OCS2015U00 mainScreen)
        {
            this.mainScreen = mainScreen;
            InitializeComponent();

            #region MED-15437
            //todo: temporary fix to pass ex of dataWindow
            string curDir = Application.StartupPath;

            if (IsCharSpecial(curDir))
            {
                CopyFile(curDir);
                //this.dwOrderInfo.LibraryList = "D:\\ocso.ocs1003p01.pbd";
            }
            else
            {
                //this.dwOrderInfo.LibraryList = "OCSO\\ocso.ocs1003p01.pbd";
            }
            #endregion

            MakeControl();
        }

        #endregion

        #region Properties

        public XPanel PnlReserOrderList
        {
            get { return pnlReserOrderList; }
            set { pnlReserOrderList = value; }
        }

        public UCOCS0103U10C DrugControl
        {
            get
            {
                this.drugControl.EnsureInitialized();
                return this.drugControl;
            }
        }

        public UCOCS0103U11C UCOCS2015U11Control
        {
            get
            {                
                this.ucOCS0103U11Control.EnsureInitialized();
                return this.ucOCS0103U11Control;
            }
        }

        public UCOCS0103U12C UCOCS2015U12Control
        {
            get
            {
                this.ucOCS0103U12Control.EnsureInitialized();
                return this.ucOCS0103U12Control;
            }
        }

        public UCOCS0103U13C UCOCS2015U13Control
        {
            get
            {
                this.ucOCS0103U13Control.EnsureInitialized();
                return this.ucOCS0103U13Control;
            }
        }

        public UCOCS0103U14C UCOCS2015U14Control
        {
            get
            {
                this.ucOCS0103U14Control.EnsureInitialized();
                return this.ucOCS0103U14Control;
            }
        }

        public UCOCS0103U15C UCOCS2015U15Control
        {
            get
            {
                this.ucOCS0103U15Control.EnsureInitialized();
                return this.ucOCS0103U15Control;
            }
        }

        public UCOCS0103U16C UCOCS2015U16Control
        {
            get
            {
                this.ucOCS0103U16Control.EnsureInitialized();
                return this.ucOCS0103U16Control;
            }
        }

        public UCOCS0103U17C UCOCS2015U17Control
        {
            get
            {
                this.ucOCS0103U17Control.EnsureInitialized();
                return this.ucOCS0103U17Control;
            }
        }

        public UCOCS0103U18C UCOCS2015U18Control
        {
            get
            {
                this.ucOCS0103U18Control.EnsureInitialized();
                return this.ucOCS0103U18Control;
            }
        }

        public UCOCS0103U19C UCOCS2015U19Control
        {
            get
            {
                this.ucOCS0103U19Control.EnsureInitialized();
                return this.ucOCS0103U19Control;
            }
        }

        public XEditGrid GrdReserOrderList
        {
            get { return this.grdReserOrderList; }
        }

        public XPanel PnlInputTab
        {
            get { return this.pnlInputTab; }
        }

        public XTabControl TabInputGubun
        {
            get { return this.tabInputGubun; }
        }

        /// <summary>
        /// OCS0103U10
        /// </summary>
        public XEditGrid GrdOrder_Drug
        {
            //get { return this.grdOrder_Drug; }
            //set { grdOrder_Drug = value; }
            get { return DrugControl.GrdOrder; }
        }

        /// <summary>
        /// OCS0103U11
        /// </summary>
        public XEditGrid GrdOrder_Reha
        {
            //get { return this.grdOrder_Reha; }
            //set { grdOrder_Reha = value; }
            get { return UCOCS2015U11Control.GrdOrder; }
        }

        /// <summary>
        /// OCS0103U12
        /// </summary>
        public XEditGrid GrdOrder_Jusa
        {
            //get { return this.grdOrder_Jusa; }
            //set { grdOrder_Jusa = value; }
            get { return UCOCS2015U12Control.GrdOrder; }
        }

        /// <summary>
        /// OCS0103U13
        /// </summary>
        public XEditGrid GrdOrder_Cpl
        {
            //get { return this.grdOrder_Cpl; }
            //set { grdOrder_Cpl = value; }
            get { return UCOCS2015U13Control.GrdOrder; }
        }

        /// <summary>
        /// OCS0103U14
        /// </summary>
        public XEditGrid GrdOrder_Pfe
        {
            //get { return this.grdOrder_Pfe; }
            //set { grdOrder_Pfe = value; }
            get { return UCOCS2015U14Control.GrdOrder; }
        }

        /// <summary>
        /// OCS0103U15
        /// </summary>
        public XEditGrid GrdOrder_Apl
        {
            //get { return this.grdOrder_Apl; }
            //set { grdOrder_Apl = value; }
            get { return UCOCS2015U15Control.GrdOrder; }
        }

        /// <summary>
        /// OCS0103U16
        /// </summary>
        public XEditGrid GrdOrder_Xrt
        {
            //get { return this.grdOrder_Xrt; }
            //set { grdOrder_Xrt = value; }
            get { return UCOCS2015U16Control.GrdOrder; }
        }

        /// <summary>
        /// OCS0103U17
        /// </summary>
        public XEditGrid GrdOrder_Chuchi
        {
            //get { return this.grdOrder_Chuchi; }
            //set { grdOrder_Chuchi = value; }
            get { return UCOCS2015U17Control.GrdOrder; }
        }

        /// <summary>
        /// OCS0103U18
        /// </summary>
        public XEditGrid GrdOrder_Susul
        {
            //get { return this.grdOrder_Susul; }
            //set { grdOrder_Susul = value; }
            get { return UCOCS2015U18Control.GrdOrder; }
        }

        /// <summary>
        /// OCS0103U19
        /// </summary>
        public XEditGrid GrdOrder_Etc
        {
            //get { return this.grdOrder_Etc; }
            //set { grdOrder_Etc = value; }
            get { return UCOCS2015U19Control.GrdOrder; }
        }

        public XEditGrid GrdAllOrderList
        {
            get { return this.grdAllOrderList; }
        }

        public XEditGrid GrdDebug
        {
            get { return this.grdDebug; }
        }

        //public XDataWindow DwOrderInfo
        //{
        //    get { return this.dwOrderInfo; }
        //}

        public Control BtnExpand
        {
            get { return this.btnExpand; }
        }

        public XProgressBar PgbProgress
        {
            get { return this.pgbProgress; }
        }

        public Panel PnlStatus
        {
            get { return this.pnlStatus; }
        }

        public Label LbStatus
        {
            get { return this.lbStatus; }
        }

        public XEditGridCell XEditGridCell170
        {
            get { return this.xEditGridCell170; }
        }
        
        #endregion

        #region Event

        private void btnExpand_Click(object sender, EventArgs e)
        {
            if (mainScreen.MIsExpanded)
            {
                mainScreen.PnlSang.Size = new Size(mainScreen.PnlSang.Size.Width, mainScreen.MUnExpandedSize);
                this.btnExpand.ImageIndex = mainScreen.MUnExpandedIndex;

                mainScreen.MIsExpanded = false;
            }
            else
            {
                mainScreen.PnlSang.Size = new Size(mainScreen.PnlSang.Size.Width, mainScreen.MExpandedSize);
                this.btnExpand.ImageIndex = mainScreen.MExpandedIndex;

                mainScreen.MIsExpanded = true;
            }
        }

        internal void tabInputGubun_SelectionChanged(object sender, EventArgs e)
        {
            foreach (IHIS.X.Magic.Controls.TabPage tpg in this.tabInputGubun.TabPages)
            {
                if (tpg == this.tabInputGubun.SelectedTab)
                {
                    tpg.ImageIndex = 3;

                    mainScreen.DislplayOrderDataWindow(tpg.Tag.ToString(), mainScreen.MCurrentInputTab, false);
                    mainScreen.LoadOrderGrid(mainScreen.ConvertToGridModule(mainScreen.MCurrentInputTab), false);
                }
                else
                {
                    tpg.ImageIndex = 4;
                }
            }
        }

        private void dwOrderInfo_DoubleClick(object sender, EventArgs e)
        {
            /*
            try
            {
                Sybase.DataWindow.ObjectAtPointer oap = dwOrderInfo.ObjectUnderMouse;
                int row = oap.RowNumber;
                int startRowNum = -1;
                string colname, reser_yn, data_col, suntak_yn = "N", groupSer, groupSerSubStr, order_gubun, input_tab = "", bogyong_code_yn, hangmog_code = "";

                colname = oap.Gob.Name;

                //XMessageBox.Show("行" + row + "、hangmog_code：" + dwOrderInfo.GetItemString(row, "hangmog_code"));

                if (colname == "hangmog_name" || colname == "order_info" || colname == "order_detail")
                {
                    if (dwOrderInfo.GetItemString(row, colname).Trim() == "") return;
                    //groupSerSubStr = dwOrderInfo.GetItemString(row, "group_ser").Substring(0, dwOrderInfo.GetItemString(row, "group_ser").Length-2);
                    //groupSer = dwOrderInfo.GetItemString(row, "group_ser");
                    //order_gubun = dwOrderInfo.GetItemString(row, "order_gubun");
                    input_tab = dwOrderInfo.GetItemString(row, "input_tab");
                    bogyong_code_yn = dwOrderInfo.GetItemString(row, "bogyong_code_yn");
                    if (bogyong_code_yn == "N")
                    {
                        hangmog_code = dwOrderInfo.GetItemString(row, "hangmog_code");
                    }

                    for (int i = 1; i < dwOrderInfo.RowCount; i++)
                    {
                        if (dwOrderInfo.GetItemString(i, "input_tab") == input_tab)
                        {
                            startRowNum = i;
                            break;
                        }
                    }

                    switch (input_tab)
                    {
                        case "01":
                            mainScreen.OpenScreen_OCS0103U10(dwOrderInfo, row, colname, startRowNum);
                            break;
                        case "03":
                            mainScreen.OpenScreen_OCS0103U12(dwOrderInfo, row, colname, startRowNum);
                            break;
                        case "04":
                            //insert by jc string 調合してパラメーターとして送る。
                            mainScreen.OpenScreen_OCS0103U13(dwOrderInfo, row, colname, startRowNum);
                            break;
                        case "05":
                            mainScreen.OpenScreen_OCS0103U14(dwOrderInfo, row, colname, startRowNum);
                            break;
                        case "06":
                            mainScreen.OpenScreen_OCS0103U15(dwOrderInfo, row, colname, startRowNum);
                            //XMessageBox.Show("病理検査" + colname);
                            break;
                        case "07":
                            mainScreen.OpenScreen_OCS0103U16(dwOrderInfo, row, colname, startRowNum);
                            break;
                        case "08":
                            mainScreen.OpenScreen_OCS0103U17(dwOrderInfo, row, colname, startRowNum);
                            break;
                        case "09":
                            mainScreen.OpenScreen_OCS0103U18(dwOrderInfo, row, colname, startRowNum);
                            break;
                        // リハビリオーダ追加 2012/09/26
                        case "10":
                            mainScreen.OpenScreen_OCS0103U11(dwOrderInfo, row, colname, startRowNum);
                            break;
                        case "11":
                            mainScreen.OpenScreen_OCS0103U19(dwOrderInfo, row, colname, startRowNum);
                            break;

                    }
                }

            }
            catch (Exception ex)
            {
                //https://sofiamedix.atlassian.net/browse/MED-10610
                //XMessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);

            }
            */
        }

        private void grdReserOrderList_QueryEnd(object sender, QueryEndEventArgs e)
        {
            if (this.grdReserOrderList.RowCount > 0)
            {
                this.pbxReserOrderList.Visible = true;
                this.pnlReserOrderList.Width = 287;
                this.btnReserListExpend.Image = this.ImageList.Images[45];
            }
            else
            {
                this.pbxReserOrderList.Visible = false;
                this.pnlReserOrderList.Width = 50;
                this.btnReserListExpend.Image = this.ImageList.Images[46];
            }
        }

        private void grdReserOrderList_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdReserOrderList.ParamList = new List<string>(new string[] { "f_bunho", "f_naewon_date", "f_stat_flg" });
            this.grdReserOrderList.SetBindVarValue("f_hosp_code", UserInfo.HospCode);
            this.grdReserOrderList.SetBindVarValue("f_bunho", mainScreen.PaInfoBox.BunHo);
            this.grdReserOrderList.SetBindVarValue("f_naewon_date", mainScreen.DtpNaewonDate.GetDataValue());
        }

        public void btnReserListExpend_Click(object sender, EventArgs e)
        {
            if (this.pnlReserOrderList.Width > 50)
            {
                this.pnlReserOrderList.Width = 50;
                this.btnReserListExpend.Image = this.ImageList.Images[46];
            }
            else
            {
                this.pnlReserOrderList.Width = 287;
                this.btnReserListExpend.Image = this.ImageList.Images[45];
            }
        }

        private void xBtnReset_Click(object sender, EventArgs e)
        {
            this.grdReserOrderList.SetBindVarValue("f_stat_flg", ((XButton) sender).Tag.ToString());

            this.grdReserOrderList.ExecuteQuery = mainScreen.ExecuteQueryOcsoOCS1003P01GridReserOrderListInfo;
            this.grdReserOrderList.QueryLayout(false);
        }

        #endregion

        #region Methods

        #region MED-15437
        private static void CopyFile(string curDir)
        {
            try
            {
                string relativePath = "..\\OCSO\\ocso.ocs1003p01.pbd";
                string absolutePath = Path.GetFullPath(curDir + relativePath);

                string targetPath = @"D:\";
                if (!File.Exists("D:\\ocso.ocs1003p01.pbd"))
                {
                    File.Copy(absolutePath, targetPath + Path.GetFileName(absolutePath));
                }
            }
            catch (Exception ex)
            {
                Service.WriteLog("Error of CopyFile(): " + ex.StackTrace);
            }
        }

        private static bool IsCharSpecial(string txtTest)
        {
            bool isChineseTextPresent = false;
            try
            {
                char[] charArray = txtTest.ToCharArray();

                foreach (char character in charArray)
                {
                    UnicodeCategory cat = char.GetUnicodeCategory(character);

                    if (cat != UnicodeCategory.OtherLetter)
                    {
                        continue;
                    }

                    isChineseTextPresent = true;
                    break;
                }
            }
            catch (Exception ex)
            {
                Service.WriteLog("Error of IsCharSpecial(): " + ex.StackTrace);
            }

            return isChineseTextPresent;
        }
        #endregion

        private void MakeControl()
        {
            this.drugControl.Visible = false;
            this.ucOCS0103U11Control.Visible = false;
            this.ucOCS0103U12Control.Visible = false;
            this.ucOCS0103U13Control.Visible = false;
            this.ucOCS0103U14Control.Visible = false;
            this.ucOCS0103U15Control.Visible = false;
            this.ucOCS0103U16Control.Visible = false;
            this.ucOCS0103U17Control.Visible = false;
            this.ucOCS0103U18Control.Visible = false;
            this.ucOCS0103U19Control.Visible = false;

            #region UCOCS2015U10
            this.drugControl.Dock = DockStyle.Fill;
            this.drugControl.MContainer = this.mainScreen;
            this.drugControl.MOpener = this.mainScreen;
            #endregion

            #region UCOCS2015U11
            this.ucOCS0103U11Control.Dock = DockStyle.Fill;
            this.ucOCS0103U11Control.MContainer = this.mainScreen;
            this.ucOCS0103U11Control.MOpener = this.mainScreen;
            #endregion

            #region UCOCS2015U12
            this.ucOCS0103U12Control.Dock = DockStyle.Fill;
            this.ucOCS0103U12Control.MContainer = this.mainScreen;
            this.ucOCS0103U12Control.MOpener = this.mainScreen;
            #endregion

            #region UCOCS2015U13
            this.ucOCS0103U13Control.Dock = DockStyle.Fill;
            this.ucOCS0103U13Control.MContainer = this.mainScreen;
            this.ucOCS0103U13Control.MOpener = this.mainScreen;
            #endregion

            #region UCOCS2015U14
            this.ucOCS0103U14Control.Dock = DockStyle.Fill;
            this.ucOCS0103U14Control.MContainer = this.mainScreen;
            this.ucOCS0103U14Control.MOpener = this.mainScreen;
            #endregion

            #region UCOCS2015U15
            this.ucOCS0103U15Control.Dock = DockStyle.Fill;
            this.ucOCS0103U15Control.MContainer = this.mainScreen;
            this.ucOCS0103U15Control.MOpener = this.mainScreen;
            #endregion

            #region UCOCS2015U16
            this.ucOCS0103U16Control.Dock = DockStyle.Fill;
            this.ucOCS0103U16Control.MContainer = mainScreen;
            this.ucOCS0103U16Control.MOpener = this.mainScreen;
            #endregion

            #region UCOCS2015U17
            this.ucOCS0103U17Control.Dock = DockStyle.Fill;
            this.ucOCS0103U17Control.MContainer = this.mainScreen;
            this.ucOCS0103U17Control.MOpener = this.mainScreen;
            #endregion

            #region UCOCS2015U18
            this.ucOCS0103U18Control.Dock = DockStyle.Fill;
            this.ucOCS0103U18Control.MContainer = this.mainScreen;
            this.ucOCS0103U18Control.MOpener = this.mainScreen;
            #endregion

            #region UCOCS2015U19
            this.ucOCS0103U19Control.Dock = DockStyle.Fill;
            this.ucOCS0103U19Control.MContainer = this.mainScreen;
            this.ucOCS0103U19Control.MOpener = this.mainScreen;
            #endregion
        }

        #endregion

        private void grdAllOrderList_GridCellPainting(object sender, XGridCellPaintEventArgs e)
        {
            if (e.ColName == "order_info" || e.ColName == "order_detail")
            {
                if (e.DataRow["bogyong_code_yn"].ToString() == "Y")
                    e.BackColor = Color.Khaki;

                if (e.DataRow["sunab_yn"].ToString() == "Y")
                    e.BackColor = Color.Khaki;

                switch (e.DataRow["ocs_flag"].ToString())
                {
                    case "2":
                        e.ForeColor = Color.Green;   // 녹색
                        break;

                    case "3":
                        e.ForeColor = Color.Blue;    // 파랑색
                        e.BackColor = Color.SkyBlue; // 하늘색
                        break;

                    //case "4":
                    //e.BackColor = Color.Khaki;
                    //break;

                    //case "5":
                    //e.BackColor = Color.Khaki;
                    //break;
                }
            }
            if (e.ColName == "mix")
            {
                e.ForeColor = Color.Black;    // Orange
                e.Font = new Font(IHIS.Framework.XEditGrid.DefaultFont.FontFamily, IHIS.Framework.XEditGrid.DefaultFont.Size, FontStyle.Bold);
            }
        }

        private void grdAllOrderList_GridDataDisplayed(object sender, EventArgs e)
        {
            XEditGrid grd = sender as XEditGrid;

            grd.AutoSizeColumn(4, 0); // mix_info
            grd.AutoSizeColumn(7, 0); // dv_name
            grd.AutoSizeColumn(9, 0); // bogyong_code_yn
            grd.AutoSizeColumn(10, 0); // ocs_flag
            grd.AutoSizeColumn(11, 0); // sunab_yn

            for (int j = 0; j < grd.RowCount; j++)
            {
                switch (grd.GetItemString(j, "mix_info"))
                {
                    case "1":
                        grd.SetItemValue(j, "mix", "┏");
                        break;
                    case "2":
                        grd.SetItemValue(j, "mix", "┃");
                        break;
                    case "3":
                        grd.SetItemValue(j, "mix", "┗");
                        break;
                    default:

                        break;
                }
            }
        }
    }
}
