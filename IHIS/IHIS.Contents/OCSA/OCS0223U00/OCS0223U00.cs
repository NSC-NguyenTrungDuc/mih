#region 사용 NameSpace 지정
using System;
using System.Collections.Generic;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Caching;
using IHIS.CloudConnector.Contracts.Arguments.Ocsa;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.Ocsa;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.CloudConnector.Utility;
using IHIS.Framework;
using IHIS.OCSA.Properties;

#endregion

namespace IHIS.OCSA
{
    public class OCS0223U00 : IHIS.Framework.XScreen
    {
        private IHIS.Framework.XEditGrid grdOCS0223;
        private IHIS.Framework.XDictComboBox cboSystem;
        private IHIS.Framework.XEditGridCell xEditGridCell2;
        private IHIS.Framework.XEditGridCell xEditGridCell3;
        private IHIS.Framework.XEditGridCell xEditGridCell4;
        private IHIS.Framework.XButtonList btnList;
        private IHIS.Framework.XEditGridCell xEditGridCell5;
        private IHIS.Framework.XEditGridCell xEditGridCell6;
        private IHIS.Framework.XPanel xPanel1;
        private IHIS.Framework.XPanel xPanel2;
        private IHIS.Framework.XPanel xPanel3;
        private IHIS.Framework.XPanel xPanel4;
        private XEditGridCell xEditGridCell1;
        private XHospBox xHospBox1;
        private IHIS.Framework.XLabel xLabel1;

        private string mHospCode = String.Empty;

        public OCS0223U00()
        {
            this.mHospCode = UserInfo.HospCode;
            if (String.IsNullOrEmpty(mHospCode))
            {
                this.mHospCode = EnvironInfo.HospCode;
            }

            InitializeComponent();

            // TODO comment use connect cloud
            /*this.grdOCS0223.SavePerformer = new XsavePerformer(this);
            this.SaveLayoutList.Add(this.grdOCS0223);*/

            //if (true)
            if (UserInfo.AdminType == AdminType.SuperAdmin)
            {
                xHospBox1.Visible = true;
                btnList.SetEnabled(FunctionType.Insert, false);
                btnList.SetEnabled(FunctionType.Delete, false);
                btnList.SetEnabled(FunctionType.Update, false);

            }
            else
            {
                xHospBox1.Visible = false;
            }

            grdOCS0223.ParamList = new List<string>(new String[] { "f_jundal_part" });
            grdOCS0223.ExecuteQuery = ExecuteQueryGrdOCS0223;
            grdOCS0223.QueryLayout(false);

            cboSystem.ExecuteQuery = ExecuteQueryComboActSystem;
            cboSystem.SetDictDDLB();

            if (!NetInfo.Language.Equals(LangMode.Jr))
            {
                xLabel1.Size = new Size(79, 23);
                xLabel1.Font = new System.Drawing.Font("Arial", 8.75F);
                cboSystem.Font = new System.Drawing.Font("Arial", 8.75F);
                cboSystem.Size = new Size(140, 23);
                this.xEditGridCell2.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
                this.xEditGridCell3.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
                this.xEditGridCell4.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
                this.xEditGridCell5.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            }
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OCS0223U00));
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.grdOCS0223 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.cboSystem = new IHIS.Framework.XDictComboBox();
            this.btnList = new IHIS.Framework.XButtonList();
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.xHospBox1 = new IHIS.Framework.XHospBox();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.xPanel4 = new IHIS.Framework.XPanel();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0223)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.xPanel1.SuspendLayout();
            this.xPanel2.SuspendLayout();
            this.xPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            resources.ApplyResources(this.ImageList, "ImageList");
            // 
            // xLabel1
            // 
            this.xLabel1.AccessibleDescription = null;
            this.xLabel1.AccessibleName = null;
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.Image = null;
            this.xLabel1.Name = "xLabel1";
            // 
            // grdOCS0223
            // 
            resources.ApplyResources(this.grdOCS0223, "grdOCS0223");
            this.grdOCS0223.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell6,
            this.xEditGridCell5,
            this.xEditGridCell3,
            this.xEditGridCell4});
            this.grdOCS0223.ColPerLine = 4;
            this.grdOCS0223.Cols = 4;
            this.grdOCS0223.ExecuteQuery = null;
            this.grdOCS0223.FixedRows = 1;
            this.grdOCS0223.HeaderHeights.Add(29);
            this.grdOCS0223.Name = "grdOCS0223";
            this.grdOCS0223.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdOCS0223.ParamList")));
            this.grdOCS0223.QuerySQL = resources.GetString("grdOCS0223.QuerySQL");
            this.grdOCS0223.Rows = 2;
            this.grdOCS0223.ToolTipActive = true;
            this.grdOCS0223.PreEndInitializing += new System.EventHandler(this.grdOCS0223_PreEndInitializing);
            this.grdOCS0223.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdOCS0223_QueryStarting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "jundal_part";
            this.xEditGridCell1.Col = -1;
            this.xEditGridCell1.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsVisible = false;
            this.xEditGridCell1.Row = -1;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellLen = 1000;
            this.xEditGridCell2.CellName = "jundal_part_name";
            this.xEditGridCell2.CellWidth = 157;
            this.xEditGridCell2.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell2.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "seq";
            this.xEditGridCell6.Col = -1;
            this.xEditGridCell6.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.IsVisible = false;
            this.xEditGridCell6.Row = -1;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "serial";
            this.xEditGridCell5.Col = 3;
            this.xEditGridCell5.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellLen = 100;
            this.xEditGridCell3.CellName = "comment_title";
            this.xEditGridCell3.CellWidth = 135;
            this.xEditGridCell3.Col = 1;
            this.xEditGridCell3.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellLen = 4000;
            this.xEditGridCell4.CellName = "comment_text";
            this.xEditGridCell4.CellWidth = 352;
            this.xEditGridCell4.Col = 2;
            this.xEditGridCell4.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            // 
            // cboSystem
            // 
            this.cboSystem.AccessibleDescription = null;
            this.cboSystem.AccessibleName = null;
            resources.ApplyResources(this.cboSystem, "cboSystem");
            this.cboSystem.BackgroundImage = null;
            this.cboSystem.ExecuteQuery = null;
            this.cboSystem.Name = "cboSystem";
            this.cboSystem.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cboSystem.ParamList")));
            this.cboSystem.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cboSystem.SelectedValueChanged += new System.EventHandler(this.cboSystem_SelectedValueChanged);
            // 
            // btnList
            // 
            this.btnList.AccessibleDescription = null;
            this.btnList.AccessibleName = null;
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.BackgroundImage = null;
            this.btnList.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Query, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Insert, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Delete, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Update, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Close, System.Windows.Forms.Shortcut.None, "", -1, "")});
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // xPanel1
            // 
            this.xPanel1.AccessibleDescription = null;
            this.xPanel1.AccessibleName = null;
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.Controls.Add(this.xHospBox1);
            this.xPanel1.Controls.Add(this.cboSystem);
            this.xPanel1.Controls.Add(this.xLabel1);
            this.xPanel1.Font = null;
            this.xPanel1.Name = "xPanel1";
            // 
            // xHospBox1
            // 
            this.xHospBox1.AccessibleDescription = null;
            this.xHospBox1.AccessibleName = null;
            resources.ApplyResources(this.xHospBox1, "xHospBox1");
            this.xHospBox1.BackColor = System.Drawing.Color.Transparent;
            this.xHospBox1.BackgroundImage = null;
            this.xHospBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.xHospBox1.HospCode = "";
            this.xHospBox1.Name = "xHospBox1";
            this.xHospBox1.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.xHospBox1_DataValidating);
            this.xHospBox1.FindClick += new System.EventHandler(this.xHospBox1_FindClick);
            // 
            // xPanel2
            // 
            this.xPanel2.AccessibleDescription = null;
            this.xPanel2.AccessibleName = null;
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.BackgroundImage = null;
            this.xPanel2.Controls.Add(this.xPanel3);
            this.xPanel2.Controls.Add(this.grdOCS0223);
            this.xPanel2.Font = null;
            this.xPanel2.Name = "xPanel2";
            // 
            // xPanel3
            // 
            this.xPanel3.AccessibleDescription = null;
            this.xPanel3.AccessibleName = null;
            resources.ApplyResources(this.xPanel3, "xPanel3");
            this.xPanel3.BackgroundImage = null;
            this.xPanel3.Font = null;
            this.xPanel3.Name = "xPanel3";
            // 
            // xPanel4
            // 
            this.xPanel4.AccessibleDescription = null;
            this.xPanel4.AccessibleName = null;
            resources.ApplyResources(this.xPanel4, "xPanel4");
            this.xPanel4.BackgroundImage = null;
            this.xPanel4.Controls.Add(this.btnList);
            this.xPanel4.Font = null;
            this.xPanel4.Name = "xPanel4";
            // 
            // OCS0223U00
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.xPanel4);
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.xPanel1);
            this.Name = "OCS0223U00";
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0223)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.xPanel1.ResumeLayout(false);
            this.xPanel2.ResumeLayout(false);
            this.xPanel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

//        private class XsavePerformer : ISavePerformer
//        {
//            OCS0223U00 parent = null;

//            public XsavePerformer(OCS0223U00 parent)
//            {
//                this.parent = parent;
//            }

//            public bool Execute(char callerID, RowDataItem item)
//            {
//                string cmdText = "";

//                item.BindVarList.Add("f_user_id", UserInfo.UserID);
//                item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);

//                //item.BindVarList.Add("f_jundal_part", parent.cboSystem.GetDataValue());

//                switch (item.RowState)
//                {
//                    case DataRowState.Added:
//                        cmdText = @" INSERT INTO OCS0223(
//                                            SYS_DATE,       SYS_ID,
//                                            UPD_DATE,       UPD_ID,
//                                            HOSP_CODE,      JUNDAL_PART,
//                                            SEQ,            SERIAL,
//                                            COMMENT_TITLE,  COMMENT_TEXT
//                                     ) VALUES (
//                                            SYSDATE,        :f_user_id,
//                                            SYSDATE,        :f_user_id,
//                                            :f_hosp_code,   :f_jundal_part_name,
//                                            OCS0223_SEQ.NEXTVAL,  :f_serial,
//                                            :f_comment_title, :f_comment_text )
//                                        ";
//                        break;

//                    case DataRowState.Modified:
//                        cmdText = @" UPDATE OCS0223
//                                        SET UPD_DATE      = SYSDATE,
//                                            UPD_ID        = :f_user_id,
//                                            SERIAL        = :f_serial,
//                                            COMMENT_TITLE = :f_comment_title,
//                                            COMMENT_TEXT  = :f_comment_text
//                                      WHERE JUNDAL_PART   = :f_jundal_part
//                                        AND SEQ           = :f_seq                                     
//                                    ";
//                        break;


//                    case DataRowState.Deleted:
//                        cmdText = @" DELETE OCS0223
//                                      WHERE JUNDAL_PART   = :f_jundal_part
//                                        AND SEQ           = :f_seq                                     
//                                   ";
//                        break;
//                }

//                return Service.ExecuteNonQuery(cmdText, item.BindVarList);
//            }

//        }

        private void cboSystem_SelectedValueChanged(object sender, EventArgs e)
        {
            grdOCS0223.QueryLayout(false);
        }

        private void grdOCS0223_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdOCS0223.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdOCS0223.SetBindVarValue("f_jundal_part", cboSystem.GetDataValue());
        }

        private void grdOCS0223_PreEndInitializing(object sender, EventArgs e)
        {
            xEditGridCell2.ExecuteQuery = ExecuteQueryComboActSystem;
        }

        private void btnList_ButtonClick(object sender, ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Update:
                    if (SaveLayout())
                    {
                        XMessageBox.Show(Resources.MSG001_MSG, Resources.MSG001_CAP, 2);
                        grdOCS0223.QueryLayout(true);
                        return;
                    }
                    else
                    {
                        XMessageBox.Show( Resources.MSG002_MSG,  Resources.MSG001_CAP, MessageBoxIcon.Hand);
                    }
                    break;
            }
        }

        #region Connect to cloud service

        /// <summary>
        /// ExecuteQueryGrdOCS0223
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> ExecuteQueryGrdOCS0223(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            OCS0223U00GrdOCS0223Args vOCS0223U00GrdOCS0223Args = new OCS0223U00GrdOCS0223Args();
            vOCS0223U00GrdOCS0223Args.HospCode = mHospCode;
            vOCS0223U00GrdOCS0223Args.JundalPart = bc["f_jundal_part"] != null ? bc["f_jundal_part"].VarValue : "";
            OCS0223U00GrdOCS0223Result result = CloudService.Instance.Submit<OCS0223U00GrdOCS0223Result, OCS0223U00GrdOCS0223Args>(vOCS0223U00GrdOCS0223Args);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (OCS0223U00GrdOCS0223Info item in result.Info)
                {
                    object[] objects =
                    {
                        item.JundalPart,
                        item.JundalPartName,
                        item.Seq,
                        item.Serial,
                        item.CommentTitle,
                        item.CommentText
                    };
                    res.Add(objects);
                }
            }
            return res;
        }

        /// <summary>
        /// ExecuteQueryComboActSystem
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> ExecuteQueryComboActSystem(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            OCS0223U00CboSystemArgs vOCS0223U00CboSystemArgs = new OCS0223U00CboSystemArgs();
            vOCS0223U00CboSystemArgs.HospCode = mHospCode;
            ComboResult result = CloudService.Instance.Submit<ComboResult, OCS0223U00CboSystemArgs>(vOCS0223U00CboSystemArgs);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (ComboListItemInfo item in result.ComboItem)
                {
                    object[] objects =
                    {
                        item.Code,
                        item.CodeName
                    };
                    res.Add(objects);
                }
            }
            return res;
        }
        
        /// <summary>
        /// SaveLayout
        /// </summary>
        /// <returns></returns>
        private bool SaveLayout()
        {
            OCS0223U00ExecutionArgs args = new OCS0223U00ExecutionArgs();
            args.Info = CreateListGrdOCS0223();
            if (args.Info.Count == 0)
            {
                return true;
            }
            args.UserId = UserInfo.UserID;
            args.HospCode = mHospCode;
            UpdateResult updateResult = CloudService.Instance.Submit<UpdateResult, OCS0223U00ExecutionArgs>(args);
            if (updateResult == null || updateResult.ExecutionStatus != ExecutionStatus.Success ||
                updateResult.Result == false)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// CreateListGrdOCS0223
        /// </summary>
        /// <returns></returns>
        private List<OCS0223U00GrdOCS0223Info> CreateListGrdOCS0223()
        {
            List<OCS0223U00GrdOCS0223Info> ListGrdOCS0223Item = new List<OCS0223U00GrdOCS0223Info>();
            for (int i = 0; i < grdOCS0223.RowCount; i++)
            {
                if (grdOCS0223.GetRowState(i) == DataRowState.Added ||
                    grdOCS0223.GetRowState(i) == DataRowState.Modified)
                {
                    OCS0223U00GrdOCS0223Info info = new OCS0223U00GrdOCS0223Info();
                    info.JundalPart = grdOCS0223.GetItemString(i, "jundal_part");
                    info.JundalPartName = grdOCS0223.GetItemString(i, "jundal_part_name");
                    info.Seq = grdOCS0223.GetItemString(i, "seq");
                    info.Serial = grdOCS0223.GetItemString(i, "serial");
                    info.CommentTitle = grdOCS0223.GetItemString(i, "comment_title");
                    info.CommentText = grdOCS0223.GetItemString(i, "comment_text");
                    info.RowState = grdOCS0223.GetRowState(i).ToString();

                    ListGrdOCS0223Item.Add(info);
                }
            }
            if (grdOCS0223.DeletedRowTable != null && grdOCS0223.DeletedRowCount > 0)
            {
                foreach (DataRow row in grdOCS0223.DeletedRowTable.Rows)
                {
                    OCS0223U00GrdOCS0223Info info = new OCS0223U00GrdOCS0223Info();
                    info.JundalPart = row["jundal_part"].ToString();
                    info.JundalPartName = row["jundal_part_name"].ToString();
                    info.Seq = row["seq"].ToString();
                    info.Serial = row["serial"].ToString();
                    info.CommentTitle = row["comment_title"].ToString();
                    info.CommentText = row["comment_text"].ToString();
                    info.RowState = DataRowState.Deleted.ToString();
                    ListGrdOCS0223Item.Add(info);
                }
            }
            return ListGrdOCS0223Item;
        }

        #endregion

        private void xHospBox1_FindClick(object sender, EventArgs e)
        {
            this.mHospCode = xHospBox1.HospCode;
            btnList.PerformClick(FunctionType.Query);
            cboSystem.SetDictDDLB();
        }

        private void xHospBox1_DataValidating(object sender, DataValidatingEventArgs e)
        {
            if (!e.Cancel)
            {
                this.mHospCode = xHospBox1.HospCode;
                btnList.PerformClick(FunctionType.Query);
                cboSystem.SetDictDDLB();
            }
        }

    }
}
