#region 사용 NameSpace 지정
using System;
using System.IO;
using System.Text;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.Collections.Specialized;
using IHIS.BASS.Properties;
using IHIS.Framework;
#endregion

namespace IHIS.BASS
{
    public class OCSPEMRU00 : IHIS.Framework.XScreen
    {
        private IHIS.Framework.XFindBox fbxSysID;
        private IHIS.Framework.XLabel xLabel1;
        private IHIS.Framework.XEditGrid grdList;
        private IHIS.Framework.XEditGridCell xEditGridCell1;
        private IHIS.Framework.XEditGridCell xEditGridCell2;
        private IHIS.Framework.XEditGridCell xEditGridCell3;
        private IHIS.Framework.XEditGridCell xEditGridCell4;
        private IHIS.Framework.XEditGridCell xEditGridCell5;
        private IHIS.Framework.XPanel xPanel1;
        private IHIS.Framework.XPanel xPanel2;
        private IHIS.Framework.XPanel xPanel3;
        private IHIS.Framework.XButtonList btnList;
        private IHIS.Framework.XDisplayBox dbxSysNm;
        private XFindWorker fwkPgmID;
        private XFindWorker fwkEmrID;
        private XEditGridCell xEditGridCell6;
        private XButton btnEMRBarcode;
        private IHIS.Framework.XFindWorker fwkSysID;

    
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OCSPEMRU00));
            this.fbxSysID = new IHIS.Framework.XFindBox();
            this.fwkSysID = new IHIS.Framework.XFindWorker();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.grdList = new IHIS.Framework.XEditGrid();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.fwkPgmID = new IHIS.Framework.XFindWorker();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.fwkEmrID = new IHIS.Framework.XFindWorker();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.dbxSysNm = new IHIS.Framework.XDisplayBox();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.btnEMRBarcode = new IHIS.Framework.XButton();
            this.btnList = new IHIS.Framework.XButtonList();
            ((System.ComponentModel.ISupportInitialize)(this.grdList)).BeginInit();
            this.xPanel1.SuspendLayout();
            this.xPanel2.SuspendLayout();
            this.xPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            resources.ApplyResources(this.ImageList, "ImageList");
            // 
            // fbxSysID
            // 
            this.fbxSysID.AccessibleDescription = null;
            this.fbxSysID.AccessibleName = null;
            resources.ApplyResources(this.fbxSysID, "fbxSysID");
            this.fbxSysID.BackgroundImage = null;
            this.fbxSysID.FindWorker = this.fwkSysID;
            this.fbxSysID.Name = "fbxSysID";
            this.fbxSysID.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxSysID_DataValidating);
            // 
            // fwkSysID
            // 
            this.fwkSysID.FormText = global::IHIS.BASS.Properties.Resource.fwkSysIDName;
            this.fwkSysID.InputSQL = resources.GetString("fwkSysID.InputSQL");
            this.fwkSysID.SearchImeMode = System.Windows.Forms.ImeMode.Alpha;
            // 
            // xLabel1
            // 
            this.xLabel1.AccessibleDescription = null;
            this.xLabel1.AccessibleName = null;
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.Image = null;
            this.xLabel1.Name = "xLabel1";
            // 
            // grdList
            // 
            resources.ApplyResources(this.grdList, "grdList");
            this.grdList.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell6,
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5});
            this.grdList.ColPerLine = 6;
            this.grdList.Cols = 6;
            this.grdList.FixedRows = 1;
            this.grdList.HeaderHeights.Add(26);
            this.grdList.Name = "grdList";
            this.grdList.QuerySQL = resources.GetString("grdList.QuerySQL");
            this.grdList.Rows = 2;
            this.grdList.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdList_QueryStarting);
            this.grdList.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdList_GridColumnChanged);
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "system_id";
            this.xEditGridCell6.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.IsReadOnly = true;
            this.xEditGridCell6.IsUpdatable = false;
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellLen = 20;
            this.xEditGridCell1.CellName = "pgm_id";
            this.xEditGridCell1.CellWidth = 92;
            this.xEditGridCell1.Col = 1;
            this.xEditGridCell1.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell1.FindWorker = this.fwkPgmID;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsUpdatable = false;
            // 
            // fwkPgmID
            // 
            this.fwkPgmID.FormText = global::IHIS.BASS.Properties.Resource.fwkPgmIDName;
            this.fwkPgmID.InputSQL = "SELECT B.PGM_ID\r\n       , B.PGM_NM\r\n  FROM ADM0300 \t    B\r\n       , ADM0200    A\r" +
                "\n WHERE A.SYS_ID \tLIKE NVL(:f_sys_id,\'%\')\r\n   AND B.SYS_ID \t= A.SYS_ID\r\n ORDER B" +
                "Y 1\r\n";
            this.fwkPgmID.QueryStarting += new System.ComponentModel.CancelEventHandler(this.fwkPgmID_QueryStarting);
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellLen = 40;
            this.xEditGridCell2.CellName = "pgm_nm";
            this.xEditGridCell2.CellWidth = 141;
            this.xEditGridCell2.Col = 2;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.IsReadOnly = true;
            this.xEditGridCell2.IsUpdatable = false;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellLen = 30;
            this.xEditGridCell3.CellName = "dw_id";
            this.xEditGridCell3.CellWidth = 161;
            this.xEditGridCell3.Col = 3;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.IsUpdatable = false;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellLen = 100;
            this.xEditGridCell4.CellName = "shetshtid";
            this.xEditGridCell4.CellWidth = 119;
            this.xEditGridCell4.Col = 4;
            this.xEditGridCell4.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell4.FindWorker = this.fwkEmrID;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.IsUpdatable = false;
            // 
            // fwkEmrID
            // 
            this.fwkEmrID.FormText = global::IHIS.BASS.Properties.Resource.fwkEmrIDName;
            this.fwkEmrID.InputSQL = "SELECT A.SHEETID\r\n       , A.SHEETNAME\r\n  FROM EMR.EMRSHEET     A\r\n WHERE A.VIRTU" +
                "ALYN \t= \'Y\'\r\n ORDER BY 1\r\n";
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellLen = 100;
            this.xEditGridCell5.CellName = "sheetname";
            this.xEditGridCell5.CellWidth = 110;
            this.xEditGridCell5.Col = 5;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.IsReadOnly = true;
            this.xEditGridCell5.IsUpdatable = false;
            // 
            // xPanel1
            // 
            this.xPanel1.AccessibleDescription = null;
            this.xPanel1.AccessibleName = null;
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.BackgroundImage = null;
            this.xPanel1.Controls.Add(this.dbxSysNm);
            this.xPanel1.Controls.Add(this.xLabel1);
            this.xPanel1.Controls.Add(this.fbxSysID);
            this.xPanel1.Font = null;
            this.xPanel1.Name = "xPanel1";
            // 
            // dbxSysNm
            // 
            this.dbxSysNm.AccessibleDescription = null;
            this.dbxSysNm.AccessibleName = null;
            resources.ApplyResources(this.dbxSysNm, "dbxSysNm");
            this.dbxSysNm.Image = null;
            this.dbxSysNm.Name = "dbxSysNm";
            // 
            // xPanel2
            // 
            this.xPanel2.AccessibleDescription = null;
            this.xPanel2.AccessibleName = null;
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.BackgroundImage = null;
            this.xPanel2.Controls.Add(this.grdList);
            this.xPanel2.Font = null;
            this.xPanel2.Name = "xPanel2";
            // 
            // xPanel3
            // 
            this.xPanel3.AccessibleDescription = null;
            this.xPanel3.AccessibleName = null;
            resources.ApplyResources(this.xPanel3, "xPanel3");
            this.xPanel3.BackgroundImage = null;
            this.xPanel3.Controls.Add(this.btnEMRBarcode);
            this.xPanel3.Controls.Add(this.btnList);
            this.xPanel3.Font = null;
            this.xPanel3.Name = "xPanel3";
            // 
            // btnEMRBarcode
            // 
            this.btnEMRBarcode.AccessibleDescription = null;
            this.btnEMRBarcode.AccessibleName = null;
            resources.ApplyResources(this.btnEMRBarcode, "btnEMRBarcode");
            this.btnEMRBarcode.BackgroundImage = null;
            this.btnEMRBarcode.ImageIndex = 10;
            this.btnEMRBarcode.ImageList = this.ImageList;
            this.btnEMRBarcode.Name = "btnEMRBarcode";
            this.btnEMRBarcode.Click += new System.EventHandler(this.btnEMRBarcode_Click);
            // 
            // btnList
            // 
            this.btnList.AccessibleDescription = null;
            this.btnList.AccessibleName = null;
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.BackgroundImage = null;
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Entry;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // OCSPEMRU00
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.xPanel3);
            this.Controls.Add(this.xPanel1);
            this.Controls.Add(this.xPanel2);
            this.Name = "OCSPEMRU00";
            ((System.ComponentModel.ISupportInitialize)(this.grdList)).EndInit();
            this.xPanel1.ResumeLayout(false);
            this.xPanel1.PerformLayout();
            this.xPanel2.ResumeLayout(false);
            this.xPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.ResumeLayout(false);

        }


        public OCSPEMRU00()
        {
            InitializeComponent();

            this.SaveLayoutList.Add(this.grdList);

            this.grdList.SavePerformer = new XSavePerformer(this);

            grdList.QueryLayout(false);

            

        }


        private void fbxSysID_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
        {
            //시스템명 Clear
            this.dbxSysNm.SetDataValue("");

            //시스템ID 입력시 시스템명 SET (메세지 시스템은 제외)
            string cmdText = "SELECT SYS_NM FROM ADM0200 WHERE NVL(MSG_SYS_YN,'N') = 'N' AND SYS_ID LIKE NVL('" + e.DataValue + "','%')";
            object retVal = Service.ExecuteScalar(cmdText);
            if (e.DataValue == "")
            {
                retVal = "全体";
            }
            //시스템명 SET
            this.dbxSysNm.SetDataValue(retVal.ToString());
            //조회, 전체 조회
            this.grdList.QueryLayout(true);
        }

        private void grdList_QueryStarting(object sender, CancelEventArgs e)
        {
            grdList.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            grdList.SetBindVarValue("f_sys_id", this.fbxSysID.GetDataValue());
        }

        private void grdList_GridColumnChanged(object sender, GridColumnChangedEventArgs e)
        {
            string cmdText = "";
            object retVal = null;

            // 중복값 확인
            for (int i = 0; i < grdList.RowCount; i++)
            {
                if (i != e.RowNumber)
                {
                    if (grdList.GetItemString(i, "pgm_id").Equals(grdList.GetItemString(e.RowNumber, "pgm_id").ToUpper()))
                    {
                        if (grdList.GetItemString(i, "dw_id").Equals(grdList.GetItemString(e.RowNumber, "dw_id")))
                        {
                            if (grdList.GetItemString(i, "shetshtid").Equals(grdList.GetItemString(e.RowNumber, "shetshtid")))
                            {
                                XMessageBox.Show("入力した値が重複されました");
                                grdList.SetItemValue(e.RowNumber, e.ColName, "");
                                grdList.SetFocusToItem(e.RowNumber, e.ColName);
                                return;
                            }
                        }
                    }
                }
            }

            // 입력 값 유효성 검사 및 명칭 Display
            switch (e.ColName)
            {
                case "pgm_id":
                    grdList.SetItemValue(e.RowNumber, "pgm_nm", "");
                    cmdText = "SELECT PGM_NM FROM ADM0300 WHERE PGM_ID='" + e.ChangeValue.ToString() + "'";
                    retVal = Service.ExecuteScalar(cmdText);

                    if (retVal == null)
                    {
                        this.SetMsg(XMsg.GetMsg("M005"), MsgType.Error); //프로그램명을 잘못 입력하셨습니다.
                        e.Cancel = true;
                        return;
                    }
                    grdList.SetItemValue(e.RowNumber, "pgm_nm", retVal.ToString());

                    break;

                case "shetshtid":
                    grdList.SetItemValue(e.RowNumber, "sheetname", "");
                    cmdText = "SELECT SHEETNAME FROM EMR.EMRSHEET WHERE SHEETID = '" + e.ChangeValue.ToString() + "'";

                    retVal = Service.ExecuteScalar(cmdText);

                    if (retVal == null)
                    {
                        this.SetMsg(XMsg.GetMsg("M005"), MsgType.Error);
                        e.Cancel = true;
                        return;
                    }

                    grdList.SetItemValue(e.RowNumber, "sheetname", retVal.ToString());

                    break;
            }
        }

        private void fwkPgmID_QueryStarting(object sender, CancelEventArgs e)
        {
            fwkPgmID.BindVarList.Add("f_sys_id", fbxSysID.GetDataValue());
        }

        private void btnList_ButtonClick(object sender, ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Insert:

                    e.IsBaseCall = false;

                    grdList.InsertRow(-1);

                    grdList.SetItemValue(grdList.CurrentRowNumber, grdList.CurrentColName, fbxSysID.GetDataValue());

                    grdList.SetFocusToItem(grdList.CurrentRowNumber, "pgm_id", true);

                    break;

                case FunctionType.Query:
                    e.IsBaseCall = false;

                    grdList.QueryLayout(false);

                    break;
            }
        }

        private void btnEMRBarcode_Click(object sender, EventArgs e)
        {
            CommonItemCollection openParams = new CommonItemCollection();

            openParams.Add("bunho", "");
            openParams.Add("sheet_id", "");
            openParams.Add("print_name", "");
            openParams.Add("auto_close_yn", "Y");

            XScreen.OpenScreenWithParam(this, "BASS", "EMR0001Q01", ScreenOpenStyle.ResponseFixed, openParams);
        }

    }

    public class XSavePerformer : IHIS.Framework.ISavePerformer
    {
        private OCSPEMRU00 parent = null;

        public XSavePerformer(OCSPEMRU00 parent)
        {
            this.parent = parent;
        }

        public bool Execute(char callerID, RowDataItem item)
        {
            string cmdText = "";

            item.BindVarList.Add("f_sys_id", UserInfo.UserID);
            item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);

            switch (item.RowState)
            {
                case DataRowState.Added:
                    cmdText = @"INSERT INTO OCSPEMR(
                                                    SYS_DATE, 
                                                    SYS_ID, 
                                                    UPD_DATE, 
                                                    UPD_ID, 
                                                    HOSP_CODE,
                                                    PGM_ID,
                                                    DW_ID,
                                                    SHETSHTID)
                                             VALUES(SYSDATE,
                                                    :f_sys_id,
                                                    SYSDATE,
                                                    :f_sys_id,
                                                    :f_hosp_code,
                                                    :f_pgm_id,
                                                    :f_dw_id,
                                                    :f_shetshtid)";

                    break;

                case DataRowState.Deleted:
                    cmdText = @"DELETE OCSPEMR 
                                 WHERE HOSP_CODE = :f_hosp_code
                                   AND DW_ID     = :f_dw_id
                                   AND PGM_ID    = :f_pgm_id
                                   AND SHETSHTID = :f_shetshtid ";
                    
                    break;

            }

            return Service.ExecuteNonQuery(cmdText, item.BindVarList);

        }
    }


}
