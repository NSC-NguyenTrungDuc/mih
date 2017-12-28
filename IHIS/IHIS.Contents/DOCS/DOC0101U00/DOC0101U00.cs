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
using IHIS.Framework;

namespace IHIS.DOCS
{
    public class DOC0101U00 : IHIS.Framework.XScreen
    {
        private IHIS.Framework.XEditGridCell xEditGridCell1;
        private IHIS.Framework.XEditGridCell xEditGridCell2;
        private IHIS.Framework.XEditGridCell xEditGridCell3;
        private IHIS.Framework.XEditGridCell xEditGridCell4;
        private IHIS.Framework.XEditGridCell xEditGridCell5;
        private IHIS.Framework.XEditGridCell xEditGridCell6;
        private IHIS.Framework.XEditGridCell xEditGridCell7;
        private IHIS.Framework.XEditGridCell xEditGridCell8;
        private IHIS.Framework.XEditGridCell xEditGridCell9;
        private IHIS.Framework.XPanel xPanel1;
        private IHIS.Framework.XPanel xPanel2;
        private IHIS.Framework.XPanel xPanel3;
        private IHIS.Framework.XButtonList xButtonList1;
        private IHIS.Framework.XEditGrid grdDoc0101;

        private void InitializeComponent()
        {
            this.grdDoc0101 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.xButtonList1 = new IHIS.Framework.XButtonList();
            this.xPanel3 = new IHIS.Framework.XPanel();
            ((System.ComponentModel.ISupportInitialize)(this.grdDoc0101)).BeginInit();
            this.xPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).BeginInit();
            this.xPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdDoc0101
            // 
            this.grdDoc0101.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell6,
            this.xEditGridCell7,
            this.xEditGridCell8,
            this.xEditGridCell9});
            this.grdDoc0101.ColPerLine = 9;
            this.grdDoc0101.Cols = 10;
            this.grdDoc0101.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdDoc0101.FixedCols = 1;
            this.grdDoc0101.FixedRows = 1;
            this.grdDoc0101.HeaderHeights.Add(21);
            this.grdDoc0101.Location = new System.Drawing.Point(0, 0);
            this.grdDoc0101.Name = "grdDoc0101";
            this.grdDoc0101.QuerySQL = "SELECT A.CERT_JNCD, A.CERT_VALD, A.CERT_RQGB, A.CERT_JNNM, A.CERT_IUSE, A.CERT_OU" +
                "SE, A.CERT_EUSE, A.CERT_WUSE, A.CERT_WMCD\r\nFROM DOC0101 A\r\nWHERE A.HOSP_CODE = F" +
                "N_ADM_LOAD_HOSP_CODE()";
            this.grdDoc0101.RowHeaderVisible = true;
            this.grdDoc0101.Rows = 2;
            this.grdDoc0101.Size = new System.Drawing.Size(723, 265);
            this.grdDoc0101.TabIndex = 0;
            this.grdDoc0101.ProcessKeyDown += new System.Windows.Forms.KeyEventHandler(this.grdDoc0101_ProcessKeyDown);
            this.grdDoc0101.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdDoc0101_KeyDown);
            this.grdDoc0101.GridCellFocusChanged += new IHIS.Framework.XGridCellFocusChangedEventHandler(this.grdDoc0101_GridCellFocusChanged);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellLen = 3;
            this.xEditGridCell1.CellName = "cert_jncd";
            this.xEditGridCell1.CellWidth = 61;
            this.xEditGridCell1.Col = 1;
            this.xEditGridCell1.HeaderText = "CODE";
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "cert_vald";
            this.xEditGridCell2.CellWidth = 43;
            this.xEditGridCell2.Col = 9;
            this.xEditGridCell2.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell2.HeaderText = "VALID";
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "cert_rqgb";
            this.xEditGridCell3.Col = 8;
            this.xEditGridCell3.HeaderText = "RQGB";
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellLen = 100;
            this.xEditGridCell4.CellName = "cert_jnnm";
            this.xEditGridCell4.CellWidth = 258;
            this.xEditGridCell4.Col = 2;
            this.xEditGridCell4.HeaderText = "NAME";
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "cert_iuse";
            this.xEditGridCell5.CellWidth = 32;
            this.xEditGridCell5.Col = 3;
            this.xEditGridCell5.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell5.HeaderText = "入院";
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "cert_ouse";
            this.xEditGridCell6.CellWidth = 30;
            this.xEditGridCell6.Col = 4;
            this.xEditGridCell6.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell6.HeaderText = "外来";
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "cert_euse";
            this.xEditGridCell7.CellWidth = 32;
            this.xEditGridCell7.Col = 5;
            this.xEditGridCell7.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell7.HeaderText = "緊急";
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "cert_wuse";
            this.xEditGridCell8.Col = 7;
            this.xEditGridCell8.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell8.HeaderText = "WUSE";
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "cert_wmcd";
            this.xEditGridCell9.Col = 6;
            this.xEditGridCell9.HeaderText = "WMCD";
            // 
            // xPanel1
            // 
            this.xPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.xPanel1.Location = new System.Drawing.Point(0, 0);
            this.xPanel1.Name = "xPanel1";
            this.xPanel1.Size = new System.Drawing.Size(723, 46);
            this.xPanel1.TabIndex = 1;
            // 
            // xPanel2
            // 
            this.xPanel2.Controls.Add(this.xButtonList1);
            this.xPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.xPanel2.Location = new System.Drawing.Point(0, 311);
            this.xPanel2.Name = "xPanel2";
            this.xPanel2.Size = new System.Drawing.Size(723, 47);
            this.xPanel2.TabIndex = 2;
            // 
            // xButtonList1
            // 
            this.xButtonList1.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Query, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Insert, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Update, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Close, System.Windows.Forms.Shortcut.None, "", -1, "")});
            this.xButtonList1.Location = new System.Drawing.Point(395, 6);
            this.xButtonList1.Name = "xButtonList1";
            this.xButtonList1.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.xButtonList1.Size = new System.Drawing.Size(325, 34);
            this.xButtonList1.TabIndex = 0;
            // 
            // xPanel3
            // 
            this.xPanel3.Controls.Add(this.grdDoc0101);
            this.xPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xPanel3.Location = new System.Drawing.Point(0, 46);
            this.xPanel3.Name = "xPanel3";
            this.xPanel3.Size = new System.Drawing.Size(723, 265);
            this.xPanel3.TabIndex = 3;
            // 
            // DOC0101U00
            // 
            this.Controls.Add(this.xPanel3);
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.xPanel1);
            this.Name = "DOC0101U00";
            this.Size = new System.Drawing.Size(723, 358);
            ((System.ComponentModel.ISupportInitialize)(this.grdDoc0101)).EndInit();
            this.xPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).EndInit();
            this.xPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        public DOC0101U00()
        {
            InitializeComponent();
            this.SaveLayoutList.Add(grdDoc0101);

            this.grdDoc0101.SavePerformer = new XSavePerformer(this);

            grdDoc0101.QueryLayout(false);
        }

        private void grdDoc0101_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void grdDoc0101_ProcessKeyDown(object sender, KeyEventArgs e)
        {
            XEditGrid grd = (XEditGrid)sender;

            if (grd.CurrentColName == "cert_jnnm")
            {
                switch (e.KeyCode)
                {
                    case Keys.Enter:
                        grd.SetItemValue(grd.CurrentRowNumber, "cert_jnnm", grd.GetItemString(grd.CurrentRowNumber, "cert_jnnm") + "\n\r");
                        grd[grd.CurrentRowNumber, "cert_jnnm"].Focus();
                        return;
                        break;
                }
            }
        }

        private void grdDoc0101_GridCellFocusChanged(object sender, XGridCellFocusChangedEventArgs e)
        {
            //XEditGrid grd = (XEditGrid)sender;
            //grd[grd.CurrentRowNumber, "cert_jnnm"].Focus();
        }
    }


    public class XSavePerformer : IHIS.Framework.ISavePerformer
    {
        private DOC0101U00 parent = null;

        public XSavePerformer(DOC0101U00 parent)
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
                    cmdText = @"INSERT INTO DOC0101(
                                                    SYS_DATE, 
                                                    UPD_ID, 
                                                    UPD_DATE, 
                                                    CERT_JNCD,
                                                    CERT_VALD,
                                                    CERT_RQGB,
                                                    CERT_JNNM,
                                                    CERT_IUSE,
                                                    CERT_OUSE,
                                                    CERT_EUSE,
                                                    CERT_WUSE,
                                                    CERT_WMCD,
                                                    SYS_ID,
                                                    HOSP_CODE)
                                             VALUES(SYSDATE,
                                                    :f_sys_id,
                                                    SYSDATE,
                                                    :f_cert_jncd,
                                                    :f_cert_vald,
                                                    :f_cert_rqgb,
                                                    :f_cert_jnnm,
                                                    :f_cert_iuse,
                                                    :f_cert_ouse,
                                                    :f_cert_euse,
                                                    :f_cert_wuse,
                                                    :f_cert_wmcd,
                                                    :f_sys_id,
                                                    :f_hosp_code)";
                    break;


                case DataRowState.Modified:
                    cmdText = @"UPDATE DOC0101
                                    SET UPD_ID =:f_sys_id,
                                        UPD_DATE =SYSDATE,
                                        CERT_VALD =:f_cert_vald,
                                        CERT_RQGB =:f_cert_rqgb,
                                        CERT_JNNM =:f_cert_jnnm,
                                        CERT_IUSE =:f_cert_iuse,
                                        CERT_OUSE =:f_cert_ouse,
                                        CERT_EUSE =:f_cert_euse,
                                        CERT_WUSE =:f_cert_wuse,
                                        CERT_WMCD =:f_cert_wmcd
                                  WHERE HOSP_CODE = FN_ADM_LOAD_HOSP_CODE()
                                    AND CERT_JNCD = :f_cert_jncd 
                                ";
                    break;
                                    
                                               

                case DataRowState.Deleted:
                    cmdText = @"DELETE DOC0101 
                                        WHERE DW_ID = :f_dw_id
                                        and PGM_ID = :f_pgm_id
                                        and SHETSHTID = :f_shetshtid ";

                    break;

            }

            return Service.ExecuteNonQuery(cmdText, item.BindVarList);

        }


    }
}
