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

namespace IHIS.OCSA
{
    public partial class OCS0304Q00 : IHIS.Framework.XScreen
    {
        private string mMemb = "";
        private string mHospCode = "";
        private DataTable mOCS2005 = null;

        public OCS0304Q00()
        {
            InitializeComponent();
        }

        #region [APL 초기설정 관련 코드]

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            mHospCode = EnvironInfo.HospCode;
            //mMemb = UserInfo.UserID.ToString();
            mMemb = UserInfo.DoctorID;
            PostCallHelper.PostCall(new PostMethod(PostLoad));
        }

        private void PostLoad()
        {
            layOCS0304.QueryLayout(false);
            grdOCS0305.QueryLayout(false);
            grdOCS0306.QueryLayout(false);
            DataVisible();
        }

        #endregion

        #region [TreeView 관련 코드]
        private void ShowOCS0304()
        {
            tvwOCS0304.Nodes.Clear();
            if (layOCS0304.RowCount < 1) return;

            int nodeIndex = 0;
            TreeNode node;

            foreach (DataRow row in layOCS0304.LayoutTable.Rows)
            {
                row["node"] = nodeIndex;
                node = new TreeNode(row["yaksok_direct_name"].ToString());
                node.Tag = row["yaksok_direct_code"].ToString();
                tvwOCS0304.Nodes.Add(node);

                nodeIndex++;
            }

            if (layOCS0304.RowCount > 0) tvwOCS0304.SelectedNode = tvwOCS0304.Nodes[0];
        }

        private void tvwOCS0304_AfterSelect(object sender, TreeViewEventArgs e)
        {
            DataVisible();
        }
        #endregion

        #region [DataService Event]

        private void layOCS0304_QueryStarting(object sender, CancelEventArgs e)
        {
            layOCS0304.SetBindVarValue("f_memb", mMemb);
            layOCS0304.SetBindVarValue("f_hosp_code", mHospCode);
        }

        private void layOCS0304_QueryEnd(object sender, QueryEndEventArgs e)
        {
            ShowOCS0304();
        }

        private void grdOCS0305_QueryStarting(object sender, CancelEventArgs e)
        {
            grdOCS0305.SetBindVarValue("f_memb", mMemb);
            grdOCS0305.SetBindVarValue("f_hosp_code", mHospCode);
        }

        private void grdOCS0306_QueryStarting(object sender, CancelEventArgs e)
        {
            grdOCS0306.SetBindVarValue("f_memb", mMemb);
            grdOCS0306.SetBindVarValue("f_hosp_code", mHospCode);
        }

        #endregion

        #region [함수 코드]

        private void DataVisible()
        {
            bool imgChk = false;

            for (int i = 0; i < grdOCS0305.LayoutTable.Rows.Count; i++)
            {
                if (grdOCS0305.GetItemValue(i, "yaksok_direct_code").ToString() != tvwOCS0304.SelectedNode.Tag.ToString())
                {
                    grdOCS0305.SetRowVisible(i, false);
                }
                else
                {
                    grdOCS0305.SetRowVisible(i, true);

                    if (grdOCS0305.GetItemValue(i, "select").ToString() == "")
                    {
                        imgChk = false;
                    }
                }
            }

            if (imgChk)
            {
                lblSelectAll.ImageIndex = 1;
                lblSelectAll.Text = " 全体選択取消";
            }
            else
            {
                lblSelectAll.ImageIndex = 0;
                lblSelectAll.Text = " 全体選択";
            }
        }
        #endregion

        #region [ButtonList]

        private void btnList_ButtonClick(object sender, ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Query:
                    e.IsBaseCall = false;
                    PostLoad();
                    lblSelectAll.ImageIndex = 0;
                    lblSelectAll.Text = " 全体選択";
                    break;

                default:
                    break;
            }
        }

        #endregion

        #region [전체선택버튼 관련]

        private void lblSelectAll_Click(object sender, EventArgs e)
        {
            if (lblSelectAll.ImageIndex == 0)
            {
                grdSelectAll(this.grdOCS0305, true);
                lblSelectAll.ImageIndex = 1;
                lblSelectAll.Text = " 全体選択取消";
            }
            else
            {
                grdSelectAll(this.grdOCS0305, false);
                lblSelectAll.ImageIndex = 0;
                lblSelectAll.Text = " 全体選択";
            }
        }

        private void grdSelectAll(XGrid grdObject, bool select)
        {
            int rowIndex = -1;

            if (select)
            {
                for (rowIndex = 0; rowIndex < grdObject.RowCount; rowIndex++)
                {
                    if (   grdObject.GetItemValue(rowIndex, "yaksok_direct_code").ToString() == tvwOCS0304.SelectedNode.Tag.ToString()
                        && this.grdOCS0305.GetItemString(rowIndex, "dup_yn") != "Y")
                    grdObject.SetItemValue(rowIndex, "select", " ");
                }
            }
            else
            {
                for (rowIndex = 0; rowIndex < grdObject.RowCount; rowIndex++)
                {
                    if (   grdObject.GetItemValue(rowIndex, "yaksok_direct_code").ToString() == tvwOCS0304.SelectedNode.Tag.ToString()
                        && this.grdOCS0305.GetItemString(rowIndex, "dup_yn") != "Y")
                    grdObject.SetItemValue(rowIndex, "select", "");
                }
            }

            SelectionBackColorChange(grdObject);

            //선택된 Tab표시
            SetSelectTab();
        }

        #endregion

        #region [grdOCS0305_MouseDown Event]

        private void grdOCS0305_MouseDown(object sender, MouseEventArgs e)
        {
            int curRowIndex = -1;

            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                curRowIndex = grdOCS0305.GetHitRowNumber(e.Y);
                if (curRowIndex < 0) return;
                SetSelectTab();
                ClearSelect();
            }
            else if (e.Button == MouseButtons.Left && e.Clicks == 1 && grdOCS0305.CurrentColNumber == 0)
            {
                curRowIndex = grdOCS0305.GetHitRowNumber(e.Y);
                if (curRowIndex < 0) return;

                if (grdOCS0305.CurrentColNumber == 0)
                {
                    if (this.grdOCS0305.GetItemString(curRowIndex, "dup_yn") != "Y")
                    {
                        if (grdOCS0305.GetItemString(curRowIndex, "select") == "")
                        {
                            grdOCS0305.SetItemValue(curRowIndex, "select", " ");
                            SelectionBackColorChange(sender, curRowIndex, "Y");
                            SetSelectTab();
                        }
                        else
                        {
                            grdOCS0305.SetItemValue(curRowIndex, "select", "");
                            SelectionBackColorChange(sender, curRowIndex, "N");
                            SetSelectTab();
                        }
                    }
                }
            }
        }

        #endregion

        #region [선택 이미지 관련 코드]
        // grdOCS0305의 선택컬럼 이외의 컬럼을 2번 클릭할 시 선택된 항목 전부 해제
        private void ClearSelect()
        {
            //선택된 Tab
            ClearSelectTab();

            //선택된 row Clear
            for (int i = 0; i < this.grdOCS0305.RowCount; i++)
            {
                if (grdOCS0305.GetItemValue(i, "yaksok_direct_code").ToString() == tvwOCS0304.SelectedNode.Tag.ToString())
                {
                    grdOCS0305.SetItemValue(i, "select", "");
                }
            }

            SelectionBackColorChange(grdOCS0305);
        }

        // 선택하지 않은 Tab 이미지로 변경 
        private void ClearSelectTab()
        {
            if (grdOCS0305.RowCount <= 0) return;

            tvwOCS0304.Nodes[tvwOCS0304.SelectedNode.Index].ImageIndex = 0;
            tvwOCS0304.Nodes[tvwOCS0304.SelectedNode.Index].SelectedImageIndex = 0;
        }

        // 선택이미지 세팅부분
        private void SetSelectTab()
        {
            ClearSelectTab();

            DataRow[] yaksok_direct_code;
            int node;

            //선택되어진 항목
            foreach (DataRow row in grdOCS0305.LayoutTable.Rows)
            {
                if (row["select"].ToString() == " ")
                {
                    //해당 항목의 yaksok_direct_code정보를 가져온다.
                    yaksok_direct_code = layOCS0304.LayoutTable.Select(" yaksok_direct_code = '" + row["yaksok_direct_code"].ToString() + "' ", "");

                    if (yaksok_direct_code.Length < 1) continue;
                    node = int.Parse(yaksok_direct_code[0]["node"].ToString());
                    tvwOCS0304.Nodes[node].ImageIndex = 1;
                    tvwOCS0304.Nodes[node].SelectedImageIndex = 1;
                }
            }

            for (int rowIndex = 0; rowIndex < grdOCS0305.RowCount; rowIndex++)
            {
                if (grdOCS0305.GetItemString(rowIndex, "select") == "") continue;
                //해당 항목의 yaksok_direct_code정보를 가져온다.
                yaksok_direct_code = layOCS0304.LayoutTable.Select(" yaksok_direct_code = '" + grdOCS0305.GetItemString(rowIndex, "yaksok_direct_code") + "' ", "");

                if (yaksok_direct_code.Length < 1) continue;
                node = int.Parse(yaksok_direct_code[0]["node"].ToString());
                tvwOCS0304.Nodes[node].ImageIndex = 1;
                tvwOCS0304.Nodes[node].SelectedImageIndex = 1;
            }
        }

        #endregion

        #region 그리드에서 선택한 Row에 대한 BackColor를 변경한다

        private void SelectionBackColorChange(object grd, int currentRowIndex, string data)
        {
            XGrid grdObject = (XGrid)grd;
            //선택된 Row에대해서 색을 변경한다
            //data   Y :색을 변경, N :색을 변경 해제
            //image 설정
            if (data == "Y")
                grdObject[currentRowIndex + grdObject.HeaderHeights.Count, 0].Image = this.ImageList.Images[1];
            else
                grdObject[currentRowIndex + grdObject.HeaderHeights.Count, 0].Image = this.ImageList.Images[0];

            for (int liColCnt = 0; liColCnt < grdObject.Cols; liColCnt++)
            {
                if (data == "Y")
                {
                    grdObject[currentRowIndex + grdObject.HeaderHeights.Count, liColCnt].BackColor = XColor.XGridSelectedCellBackColor;
                    grdObject[currentRowIndex + grdObject.HeaderHeights.Count, liColCnt].ForeColor = XColor.XGridSelectedCellForeColor;
                }
                else
                {
                    grdObject[currentRowIndex + grdObject.HeaderHeights.Count, liColCnt].BackColor = XColor.XGridRowBackColor;
                    grdObject[currentRowIndex + grdObject.HeaderHeights.Count, liColCnt].ForeColor = XColor.NormalForeColor;
                }
            }

        }

        private void SelectionBackColorChange(object grd)
        {
            XGrid grdObject = (XGrid)grd;

            //기존의 색으로 변경을 시킨다
            for (int rowIndex = 0; rowIndex < grdObject.RowCount; rowIndex++)
            {
                if (grdObject.GetItemString(rowIndex, "select").ToString() == " ")
                {
                    //image 변경
                    grdObject[rowIndex + grdObject.HeaderHeights.Count, 0].Image = this.ImageList.Images[1];

                    //ColorYn Y :색을 변경, N :색을 변경 해제
                    for (int liColCnt = 0; liColCnt < grdObject.Cols; liColCnt++)
                    {
                        grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].BackColor = XColor.XGridSelectedCellBackColor;
                        grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].ForeColor = XColor.XGridSelectedCellForeColor;
                    }
                }
                else
                {
                    //image 변경
                    grdObject[rowIndex + grdObject.HeaderHeights.Count, 0].Image = this.ImageList.Images[0];
                    for (int liColCnt = 0; liColCnt < grdObject.Cols; liColCnt++)
                    {
                        grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].BackColor = XColor.XGridRowBackColor;
                        grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].ForeColor = XColor.NormalForeColor;
                    }
                }
            }
        }

        #endregion

        #region [Return Layout 생성]

        private void CreateReturnLayout()
        {
            this.AcceptData();

            //int insertRow = 0;

            foreach (DataRow row in grdOCS0305.LayoutTable.Rows)
            {
                if (row["select"].ToString() == " ")
                {
                    row["pkocs2005"] = PkOCS2005();
                    layOCS0305R.LayoutTable.ImportRow(row);

                    //int insertDtRow = 0;
                    foreach (DataRow dtRow in grdOCS0306.LayoutTable.Rows)
                    {
                        if (row["yaksok_direct_code"].ToString() == dtRow["yaksok_direct_code"].ToString() &&
                            row["pk_seq"].ToString() == dtRow["pk_seq"].ToString() &&
                            row["direct_gubun"].ToString() == dtRow["direct_gubun"].ToString() &&
                            row["direct_code"].ToString() == dtRow["direct_code"].ToString())
                        {
                            dtRow["fkocs2005"] = row["pkocs2005"];
                            layOCS0306R.LayoutTable.ImportRow(dtRow);
                        }
                    }
                }
            }

            if (layOCS0305R.LayoutTable.Rows.Count < 1) return;
            IHIS.Framework.XScreen scrOpener = (XScreen)Opener;

            CommonItemCollection commandParams = new CommonItemCollection();
            commandParams.Add("OCS0305", layOCS0305R);
            commandParams.Add("OCS0306", layOCS0306R);
            scrOpener.Command(ScreenID, commandParams);
        }

        private string PkOCS2005()
        {
            string pkOcs2005 = string.Empty;

            pkOcs2005 = Service.ExecuteScalar("SELECT OCS2005_SEQ.NEXTVAL FROM SYS.DUAL").ToString();
            return pkOcs2005;
        }
        #endregion

        private void xButton1_Click(object sender, EventArgs e)
        {
            CreateReturnLayout();
            Close();
        }

        private void OCS0304Q00_ScreenOpen(object sender, XScreenOpenEventArgs e)
        {
            if (this.OpenParam != null)
            {
                try
                {
                    if (OpenParam.Contains("OCS2005"))
                        mOCS2005 = (DataTable)OpenParam["OCS2005"];
                }
                catch (Exception ex)
                {
                    XMessageBox.Show(ex.Message, "");
                }
            }
        }

        private void grdOCS0305_QueryEnd(object sender, QueryEndEventArgs e)
        {
            DataRow [] dr = null;

            for (int i = 0; i < this.grdOCS0305.RowCount; i++)
            {
                dr = this.mOCS2005.Select("direct_code = '" + this.grdOCS0305.GetItemString(i, "direct_code") + "'");

                if (dr.Length > 0)
                    this.grdOCS0305.SetItemValue(i, "dup_yn", "Y");
                else
                    this.grdOCS0305.SetItemValue(i, "dup_yn", "N");
            }
        }

        private void grdOCS0305_GridCellPainting(object sender, XGridCellPaintEventArgs e)
        {
            XEditGrid grd = sender as XEditGrid;

            if (e.DataRow["dup_yn"].ToString() == "Y")
            {
                e.BackColor = Color.Gray;
            }
        }

        private void grdOCS0305_GridColumnProtectModify(object sender, GridColumnProtectModifyEventArgs e)
        {
            if (e.DataRow["dup_yn"].ToString() == "Y")
            {
                e.Protect = true;
            }
        }

    }
}