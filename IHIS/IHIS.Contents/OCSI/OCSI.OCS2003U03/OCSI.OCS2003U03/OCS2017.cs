using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Data;

using IHIS.Framework;

namespace IHIS.OCSI
{
    public partial class OCS2017 : IHIS.Framework.XForm
    {
        private string mPkocs2003 = "";
        private string mBUNHO     = "";
        private string mORDERINFO = "";
        private string mGUBUN     = "";

        private string mFKINP1001 = "";
        private string mORDERDATE = "";
        private string mINPUTDOCTOR = "";

        private XEditGrid mGRDORDER;
        public OCS2017()
        {
            InitializeComponent();
        }


        #region [properties]
        public string FKINP1001
        {
            get
            {
                return mFKINP1001;
            }
            set
            {
                mFKINP1001 = value;
            }

        }
        public string ORDERDATE
        {
            get
            {
                return mORDERDATE;
            }
            set
            {
                mORDERDATE = value;
            }

        }
        public string INPUTDOCTOR
        {
            get
            {
                return mINPUTDOCTOR;
            }
            set
            {
                mINPUTDOCTOR = value;
            }

        }

        public string PKOCS2003
        {
            get
            {
                return mPkocs2003;
            }
            set
            {
                mPkocs2003 = value;
            }

        }
        public string BUNHO
        {
            get
            {
                return mBUNHO;
            }
            set
            {
                mBUNHO = value;
            }
        }
        public string ORDERINFO
        {
            get
            {
                return mORDERINFO;
            }
            set
            {
                mORDERINFO = value;
            }
        }
        public string GUBUN
        {
            get
            {
                return mGUBUN;
            }
            set
            {
                mGUBUN = value;
            }
        }
        public XEditGrid SOURCEGRD
        {
            get
            {
                return mGRDORDER;
            }
            set
            {
                mGRDORDER = value;
            }
        }
        #endregion

        private void OCS2017_Load(object sender, EventArgs e)
        {
            //this.grdOrder.AutoSizeColumn(9, 0);
            //this.grdOrder.AutoSizeColumn(10, 0);

            //this.grdOrder = this.mGRDORDER;

            //this.grdOrder.RowFocusChanged -= new IHIS.Framework.RowFocusChangedEventHandler(this.grdOrder_RowFocusChanged);
            //for (int i = 0; i < this.mGRDORDER.RowCount; i++)
            //{
            //    this.grdOrder.InsertRow(-1);

            //    foreach (XEditGridCell cell in mGRDORDER.CellInfos)
            //    {
            //        if (this.grdOrder.CellInfos.Contains(cell.CellName))
            //        {
            //            this.grdOrder.SetItemValue(this.grdOrder.CurrentRowNumber, cell.CellName, this.mGRDORDER.GetItemString(i, cell.CellName));
            //        }
            //    }
            //}
            //this.grdOrder.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdOrder_RowFocusChanged);

            this.paBox.SetPatientID(this.mBUNHO);
            //this.dtpKijunDate.SetDataValue(this.mORDERDATE);

            //DateTime dt = DateTime.Parse(this.dtpKijunDate.GetDataValue());

            //this.grdOrder.CellInfos[10].HeaderText = dt.ToString("dd");
            //this.grdOrder.CellInfos[11].HeaderText = dt.AddDays(1).ToString("dd");
            //this.grdOrder.CellInfos[12].HeaderText = dt.AddDays(2).ToString("dd");
            //this.grdOrder.CellInfos[13].HeaderText = dt.AddDays(3).ToString("dd");
            //this.grdOrder.CellInfos[14].HeaderText = dt.AddDays(4).ToString("dd");
            //this.grdOrder.CellInfos[15].HeaderText = dt.AddDays(5).ToString("dd");
            //this.grdOrder.CellInfos[16].HeaderText = dt.AddDays(6).ToString("dd");
            //this.grdOrder.CellInfos[17].HeaderText = dt.AddDays(7).ToString("dd");
            //this.grdOrder.CellInfos[18].HeaderText = dt.AddDays(8).ToString("dd");
            //this.grdOrder.CellInfos[19].HeaderText = dt.AddDays(9).ToString("dd");
            //this.grdOrder.CellInfos[20].HeaderText = dt.AddDays(10).ToString("dd");
            //this.grdOrder.CellInfos[21].HeaderText = dt.AddDays(11).ToString("dd");
            //this.grdOrder.CellInfos[22].HeaderText = dt.AddDays(12).ToString("dd");
            //this.grdOrder.CellInfos[23].HeaderText = dt.AddDays(13).ToString("dd");
            
            //this.grdOrder.InitializeColumns();

            this.btnList.PerformClick(FunctionType.Query);

            switch (this.mGUBUN)
            {
                case "ALL":
                    //this.grdOrder.Visible = true;
                    PostCallHelper.PostCall(this.setPartRow);
                    break;

                case "PART":
                    //this.grdOrder.Visible = false;
                    //this.Size = new Size(this.Width - this.grdOrder.Width, this.Height);
                    //this.emkOrderInfo.Text = this.mORDERINFO;
                    PostCallHelper.PostCall(this.setPartRow);
                    break;
            }

            if (this.grdOrder.DisplayRowCount > 0)
            {
                if (this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "start_date") != "")
                {
                    this.dtpKijunDate.SetDataValue(this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "start_date"));
                }
            }
        }

        private void setPartRow()
        {
            XEditGrid grd = this.grdOrder;

            if (this.mGUBUN == "PART")
            {
                for (int i = 0; i < this.grdOrder.RowCount; i++)
                {
                    if (this.grdOrder.GetItemString(i, "pkocs2003") == mPkocs2003)
                    {
                        this.grdOrder.SetFocusToItem(i, "order_date");
                        this.emkOrderInfo.Text = grd.GetItemString(i, "hangmog_name") + " " + DateTime.Parse(grd.GetItemString(i, "start_date")).ToString("MM/dd") + " Å` " + DateTime.Parse(TypeCheck.NVL(grd.GetItemString(i, "end_date"), grd.GetItemString(i, "start_date")).ToString()).ToString("MM/dd");
                    }
                }
            }
            else
            {
                int CurrRow = grd.CurrentRowNumber;

                if(CurrRow > -1)
                    this.emkOrderInfo.Text = grd.GetItemString(CurrRow, "hangmog_name") + " " + DateTime.Parse(grd.GetItemString(CurrRow, "start_date")).ToString("MM/dd") + " Å` " + DateTime.Parse(TypeCheck.NVL(grd.GetItemString(CurrRow, "end_date"), grd.GetItemString(CurrRow, "start_date")).ToString()).ToString("MM/dd");
            }
        }

        private void btnList_ButtonClick(object sender, ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Query:
                    e.IsBaseCall = false;
                    this.grdOrder.QueryLayout(false);
                    this.grdOCS2017.QueryLayout(false);
                    this.SetSiksaHisInfo(this.grdOCS2017);
                    break;
            }
        }

        private void grdOCS2017_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdOCS2017.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdOCS2017.SetBindVarValue("f_pkocs2003", this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "pkocs2003"));
        }

        private void ResetCalender()
        {
            this.calSiksa.ResetText();
            this.calSiksa.Dates.Clear();
            this.calSiksa.ResetCalendarDates();

            this.calSiksa.UnSelectAll();

            String Act_res_date = this.grdOCS2017.GetItemString(this.grdOCS2017.CurrentRowNumber, "act_res_date");

            if(Act_res_date != "")
            {
                this.calSiksa.SetActiveMonth(DateTime.Parse(Act_res_date).Year, DateTime.Parse(Act_res_date).Month);
            }
            this.calSiksa.Redraw = true;
        }

        private void SetSiksaHisInfo(XEditGrid aLayData)
        {
            string currentDate = "";

            string strText = "";
            XCalendarDate dateItem;

            this.ResetCalender();

            this.calSiksa.Redraw = false;
            foreach (DataRow dr in aLayData.LayoutTable.Rows)
            {

                if (dr["act_res_date"].ToString() != currentDate)
                {
                    if (strText != "")
                    {
                        dateItem = new XCalendarDate(DateTime.Parse(currentDate));
                        dateItem.ContentText = strText;
                        dateItem.ContentAlign = ContentAlignment.MiddleLeft;

                        dateItem.ContentTextColor = new XColor(Color.Black);
                        dateItem.ContentFont = new Font("Migu 1M", (float)9, FontStyle.Regular);

                        this.calSiksa.Dates.Add(dateItem);
                    }
                    currentDate = dr["act_res_date"].ToString();
                    strText = "";
                }

                strText += dr["pattern_gubun"].ToString() + " " + dr["pass_date"].ToString() + "\n";
            }

            if (currentDate != "")
            {
                dateItem = new XCalendarDate(DateTime.Parse(currentDate));
                dateItem.ContentText = strText;
                dateItem.ContentTextColor = new XColor(Color.Black);
                dateItem.ContentFont = new Font("Migu 1M", (float)9, FontStyle.Regular);
                dateItem.ContentAlign = ContentAlignment.MiddleLeft;

                this.calSiksa.Dates.Add(dateItem);
            }

            //this.SetPresentWeek(this.calSiksa);
            this.calSiksa.Redraw = true;

        }

        private void grdOrder_RowFocusChanged(object sender, RowFocusChangedEventArgs e)
        {
            XEditGrid grd = this.grdOrder;
            int CurrRow = grd.CurrentRowNumber;

            this.grdOCS2017.QueryLayout(false);
            this.emkOrderInfo.Text = grd.GetItemString(CurrRow, "hangmog_name") + " " + DateTime.Parse(grd.GetItemString(CurrRow, "start_date")).ToString("MM/dd") + " Å` " + DateTime.Parse(TypeCheck.NVL(grd.GetItemString(CurrRow, "end_date"), grd.GetItemString(CurrRow, "start_date")).ToString()).ToString("MM/dd");
            this.SetSiksaHisInfo(this.grdOCS2017);
        }

        private void grdOCS2017_QueryEnd(object sender, QueryEndEventArgs e)
        {
            if (this.mGUBUN == "PART")
            {
                for (int i = 0; i < this.grdOrder.RowCount; i++)
                {
                    if (this.grdOrder.GetItemString(i, "pkocs2003") == mPkocs2003)
                    {
                        this.grdOrder.SetFocusToItem(i, "act_res_date");
                    }
                }
            }
        }

        private void grdOrder_GridColumnChanged(object sender, GridColumnChangedEventArgs e)
        {

        }

        private void grdOrder_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdOrder.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdOrder.SetBindVarValue("f_fkinp1001", this.mFKINP1001);
            this.grdOrder.SetBindVarValue("f_input_doctor", this.mINPUTDOCTOR);
            this.grdOrder.SetBindVarValue("f_order_date", DateTime.Parse(this.mORDERDATE).ToString("yyyy/MM/dd"));
            this.grdOrder.SetBindVarValue("f_bunho", this.mBUNHO);
            this.grdOrder.SetBindVarValue("f_kijun_date", TypeCheck.NVL(this.dtpKijunDate.GetDataValue(), DateTime.Parse(this.mORDERDATE).ToString("yyyy/MM/dd")).ToString());
        }

        

        private void grdOrder_GridCellPainting(object sender, XGridCellPaintEventArgs e)
        {
            switch(e.ColName)
            {
                case "0":
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                case "10":
                case "11":
                case "12":
                case "13":
                    //if (DateTime.Parse(e.DataRow["start_date"].ToString()) <= DateTime.Parse(this.dtpKijunDate.GetDataValue()).AddDays(int.Parse(e.ColName))
                    //   && DateTime.Parse(e.DataRow["end_date"].ToString()) >= DateTime.Parse(this.dtpKijunDate.GetDataValue()).AddDays(int.Parse(e.ColName)))
                    //{
                    //    e.BackColor = Color.LightGray;
                    //}
                    //else
                    //{
                    //    e.DataRow[e.ColName] = "";
                    //    this.grdOrder.SetItemValue(e.RowNumber, e.ColName, "");
                    //}
                    if (e.DataRow["order_gubun"].ToString().Substring(1, 1) == "C"
                        || e.DataRow["order_gubun"].ToString().Substring(1, 1) == "D"
                        || e.DataRow["order_gubun"].ToString().Substring(1, 1) == "B")
                    {
                        if (e.DataRow["start_date"].ToString() != ""
                        && e.DataRow["end_date"].ToString() != ""
                        && TypeCheck.IsDateTime(e.DataRow["start_date"].ToString())
                        && TypeCheck.IsDateTime(e.DataRow["end_date"].ToString()))
                        {

                            if (DateTime.Parse(e.DataRow["start_date"].ToString()) <= DateTime.Parse(this.dtpKijunDate.GetDataValue()).AddDays(int.Parse(e.ColName))
                               && DateTime.Parse(e.DataRow["end_date"].ToString()) >= DateTime.Parse(this.dtpKijunDate.GetDataValue()).AddDays(int.Parse(e.ColName)))
                            {
                                //e.BackColor = Color.LightSkyBlue;
                                e.Font = new Font("MS UI Gothic", (float)9.75, FontStyle.Bold);
                            }
                            else
                                this.grdOrder.SetItemValue(e.RowNumber, e.ColName, ".");
                        }
                        else
                            this.grdOrder.SetItemValue(e.RowNumber, e.ColName, ".");
                    }
                    else
                    {
                        if (TypeCheck.NVL(e.DataRow["end_date"].ToString(), e.DataRow["start_date"].ToString()).ToString() != ""
                            && TypeCheck.IsDateTime(TypeCheck.NVL(e.DataRow["end_date"].ToString(), e.DataRow["start_date"].ToString())))
                        {
                            if (DateTime.Parse(TypeCheck.NVL(e.DataRow["end_date"].ToString(), e.DataRow["start_date"].ToString()).ToString()) == DateTime.Parse(this.dtpKijunDate.GetDataValue()).AddDays(int.Parse(e.ColName)))
                            {
                                //e.BackColor = Color.LightSkyBlue;
                                e.Font = new Font("MS UI Gothic", (float)9.75, FontStyle.Bold);

                                this.grdOrder.SetItemValue(e.RowNumber, e.ColName, "Å~");
                            }
                            else
                                this.grdOrder.SetItemValue(e.RowNumber, e.ColName, ".");
                        }
                        else
                            this.grdOrder.SetItemValue(e.RowNumber, e.ColName, ".");
                    }
                break;
                
            }
        }

        private void btnDatePlusMinus_Click(object sender, EventArgs e)
        {
            setDatePlusMinus(this.dtpKijunDate, ((Control)sender).Tag.ToString());
        }

        public void setDatePlusMinus(XDatePicker aKijunDate, string aGubun)
        {
            if (aKijunDate.GetDataValue() == "")
                aKijunDate.SetDataValue(EnvironInfo.GetSysDate());

            if (aGubun == "-" && aKijunDate.GetDataValue() != "")
                aKijunDate.SetDataValue(DateTime.Parse(aKijunDate.GetDataValue()).AddDays(-1));
            else if (aGubun == "+" && aKijunDate.GetDataValue() != "")
                aKijunDate.SetDataValue(DateTime.Parse(aKijunDate.GetDataValue()).AddDays(+1));

            aKijunDate.AcceptData();
        }


        private void dtpKijunDate_DataValidating(object sender, DataValidatingEventArgs e)
        {
            
        }

        private void dtpKijunDate_TextChanged(object sender, EventArgs e)
        {
            if (!TypeCheck.IsDateTime(this.dtpKijunDate.GetDataValue()))
                return;

            DateTime dt = DateTime.Parse(this.dtpKijunDate.GetDataValue());

            this.grdOrder.CellInfos[10].HeaderText = dt.ToString("dd");
            this.grdOrder.CellInfos[11].HeaderText = dt.AddDays(1).ToString("dd");
            this.grdOrder.CellInfos[12].HeaderText = dt.AddDays(2).ToString("dd");
            this.grdOrder.CellInfos[13].HeaderText = dt.AddDays(3).ToString("dd");
            this.grdOrder.CellInfos[14].HeaderText = dt.AddDays(4).ToString("dd");
            this.grdOrder.CellInfos[15].HeaderText = dt.AddDays(5).ToString("dd");
            this.grdOrder.CellInfos[16].HeaderText = dt.AddDays(6).ToString("dd");
            this.grdOrder.CellInfos[17].HeaderText = dt.AddDays(7).ToString("dd");
            this.grdOrder.CellInfos[18].HeaderText = dt.AddDays(8).ToString("dd");
            this.grdOrder.CellInfos[19].HeaderText = dt.AddDays(9).ToString("dd");
            this.grdOrder.CellInfos[20].HeaderText = dt.AddDays(10).ToString("dd");
            this.grdOrder.CellInfos[21].HeaderText = dt.AddDays(11).ToString("dd");
            this.grdOrder.CellInfos[22].HeaderText = dt.AddDays(12).ToString("dd");
            this.grdOrder.CellInfos[23].HeaderText = dt.AddDays(13).ToString("dd");
            //this.grdOrder.CellInfos[24].HeaderText = dt.AddDays(14).ToString("dd");

            this.grdOrder.InitializeColumns();

            this.grdOrder.QueryLayout(false);
        }

    }
}