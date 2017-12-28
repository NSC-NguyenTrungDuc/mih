#region 사용 NameSpace 지정
using System;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.Data.OleDb;
using IHIS.Framework;
#endregion

namespace IHIS.CPLS
{
    /// <summary>
    /// CPLBMLUPLOADER에 대한 요약 설명입니다.
    /// </summary>
    [ToolboxItem(false)]
    public class CPLBMLUPLOADER : IHIS.Framework.XScreen
    {
        private IHIS.Framework.XPanel xPanel1;
        private IHIS.Framework.XPanel xPanel2;
        private IHIS.Framework.XPanel xPanel3;
        private IHIS.Framework.XButtonList btnList;
        private IHIS.Framework.XLabel lbBMLMasterFile;
        private IHIS.Framework.XEditGridCell xEditGridCell17;
        private DataGridView dataGridView;
        private OpenFileDialog openFileDialog;
        private XButton btnSearchFile;
        private XTextBox txtBMLFileName;
        private XTextBox txtWorkSheet;
        private XLabel xLabel1;
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.Container components = null;

        #region add fields
        Excel excel;
        private ProgressBar progBar;
        private XLabel xLabel2;
        private XCheckBox ckbEm;
        DataTable excelTable = new DataTable();
        #endregion

        public CPLBMLUPLOADER()
        {
            // 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();
        }

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Designer generated code
        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.progBar = new System.Windows.Forms.ProgressBar();
            this.btnList = new IHIS.Framework.XButtonList();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.txtWorkSheet = new IHIS.Framework.XTextBox();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.btnSearchFile = new IHIS.Framework.XButton();
            this.txtBMLFileName = new IHIS.Framework.XTextBox();
            this.lbBMLMasterFile = new IHIS.Framework.XLabel();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.ckbEm = new IHIS.Framework.XCheckBox();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.xPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.xPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // xPanel1
            // 
            this.xPanel1.Controls.Add(this.dataGridView);
            this.xPanel1.Controls.Add(this.xPanel3);
            this.xPanel1.Controls.Add(this.xPanel2);
            this.xPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Location = new System.Drawing.Point(5, 5);
            this.xPanel1.Name = "xPanel1";
            this.xPanel1.Size = new System.Drawing.Size(950, 580);
            this.xPanel1.TabIndex = 0;
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(0, 36);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowTemplate.Height = 23;
            this.dataGridView.Size = new System.Drawing.Size(948, 504);
            this.dataGridView.TabIndex = 0;
            // 
            // xPanel3
            // 
            this.xPanel3.Controls.Add(this.progBar);
            this.xPanel3.Controls.Add(this.btnList);
            this.xPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.xPanel3.DrawBorder = true;
            this.xPanel3.Location = new System.Drawing.Point(0, 540);
            this.xPanel3.Name = "xPanel3";
            this.xPanel3.Size = new System.Drawing.Size(948, 38);
            this.xPanel3.TabIndex = 1;
            // 
            // progBar
            // 
            this.progBar.Location = new System.Drawing.Point(7, 7);
            this.progBar.Name = "progBar";
            this.progBar.Size = new System.Drawing.Size(519, 23);
            this.progBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progBar.TabIndex = 2;
            this.progBar.Visible = false;
            // 
            // btnList
            // 
            this.btnList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnList.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnList.IsVisibleReset = false;
            this.btnList.Location = new System.Drawing.Point(530, 1);
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Entry;
            this.btnList.Size = new System.Drawing.Size(406, 34);
            this.btnList.TabIndex = 0;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // xPanel2
            // 
            this.xPanel2.Controls.Add(this.xLabel2);
            this.xPanel2.Controls.Add(this.ckbEm);
            this.xPanel2.Controls.Add(this.txtWorkSheet);
            this.xPanel2.Controls.Add(this.xLabel1);
            this.xPanel2.Controls.Add(this.btnSearchFile);
            this.xPanel2.Controls.Add(this.txtBMLFileName);
            this.xPanel2.Controls.Add(this.lbBMLMasterFile);
            this.xPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.xPanel2.DrawBorder = true;
            this.xPanel2.Location = new System.Drawing.Point(0, 0);
            this.xPanel2.Name = "xPanel2";
            this.xPanel2.Size = new System.Drawing.Size(948, 36);
            this.xPanel2.TabIndex = 0;
            // 
            // txtWorkSheet
            // 
            this.txtWorkSheet.Location = new System.Drawing.Point(485, 8);
            this.txtWorkSheet.Name = "txtWorkSheet";
            this.txtWorkSheet.Size = new System.Drawing.Size(166, 20);
            this.txtWorkSheet.TabIndex = 4;
            this.txtWorkSheet.Text = "Sheet3";
            // 
            // xLabel1
            // 
            this.xLabel1.Location = new System.Drawing.Point(382, 7);
            this.xLabel1.Name = "xLabel1";
            this.xLabel1.Size = new System.Drawing.Size(101, 21);
            this.xLabel1.TabIndex = 3;
            this.xLabel1.Text = "WorkSheet";
            this.xLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSearchFile
            // 
            this.btnSearchFile.Location = new System.Drawing.Point(349, 6);
            this.btnSearchFile.Name = "btnSearchFile";
            this.btnSearchFile.Size = new System.Drawing.Size(27, 23);
            this.btnSearchFile.TabIndex = 2;
            this.btnSearchFile.Click += new System.EventHandler(this.btnSearchFile_Click);
            // 
            // txtBMLFileName
            // 
            this.txtBMLFileName.Location = new System.Drawing.Point(109, 7);
            this.txtBMLFileName.Name = "txtBMLFileName";
            this.txtBMLFileName.Size = new System.Drawing.Size(238, 20);
            this.txtBMLFileName.TabIndex = 1;
            this.txtBMLFileName.Text = "C:\\Temp\\BMLSample.xls";
            // 
            // lbBMLMasterFile
            // 
            this.lbBMLMasterFile.Location = new System.Drawing.Point(6, 6);
            this.lbBMLMasterFile.Name = "lbBMLMasterFile";
            this.lbBMLMasterFile.Size = new System.Drawing.Size(101, 21);
            this.lbBMLMasterFile.TabIndex = 0;
            this.lbBMLMasterFile.Text = "BMLMasterFile";
            this.lbBMLMasterFile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.CellName = "group_gubun";
            this.xEditGridCell17.Col = -1;
            this.xEditGridCell17.IsVisible = false;
            this.xEditGridCell17.Row = -1;
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Excel File|*.xls;*.xlsx|모든 파일|*.*";
            this.openFileDialog.InitialDirectory = "C:\\Temp";
            // 
            // ckbEm
            // 
            this.ckbEm.AutoSize = true;
            this.ckbEm.Location = new System.Drawing.Point(694, 9);
            this.ckbEm.Name = "ckbEm";
            this.ckbEm.Size = new System.Drawing.Size(12, 11);
            this.ckbEm.TabIndex = 5;
            this.ckbEm.UseVisualStyleBackColor = false;
            // 
            // xLabel2
            // 
            this.xLabel2.AutoSize = true;
            this.xLabel2.Location = new System.Drawing.Point(712, 9);
            this.xLabel2.Name = "xLabel2";
            this.xLabel2.Size = new System.Drawing.Size(69, 13);
            this.xLabel2.TabIndex = 6;
            this.xLabel2.Text = "Emergency";
            // 
            // CPLBMLUPLOADER
            // 
            this.AutoCheckInputLayoutChanged = true;
            this.Controls.Add(this.xPanel1);
            this.Name = "CPLBMLUPLOADER";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.xPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.xPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.xPanel2.ResumeLayout(false);
            this.xPanel2.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        #region OnLoad
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            
            /*
            this.grdCode.SavePerformer = new XSavePerformer(this);

            this.SaveLayoutList.Add(grdCode);
             */
        }
        #endregion

        #region btnList_ButtonClick
        private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Query:
                    //excel load
                    excel = new Excel(txtBMLFileName.GetDataValue(), txtWorkSheet.GetDataValue());
                    excelTable = excel.GetDataTable();
                    this.dataGridView.DataSource = excelTable;
                    this.dataGridView.Refresh();
                    break;
                case FunctionType.Update:
                    //test export DataGrid
                    string datas = "";
                    int cnt = 0;
                    Service.BeginTransaction();

                    progBar.Visible = true;
                    progBar.Refresh();

                    progBar.Minimum = 1;

                    progBar.Maximum = excelTable.Rows.Count;

                    progBar.Value = 1;

                    progBar.Step = 1;

                    foreach (DataRow dtRow in excelTable.Rows)
                    {
                        progBar.PerformStep();

                        if (!TypeCheck.IsNull(dtRow["HANGMOG_CODE"].ToString())
                         && !TypeCheck.IsNull(dtRow["SPECIMEN_CODE"].ToString())
                         && !TypeCheck.IsNull(dtRow["SPECIMEN_NAME"].ToString()))
                        {
                            //저장 변수 셋팅
                            Hashtable inputList = new Hashtable();
                            inputList.Add("I_USER_ID", "BMLLHD");                                      //사용자 ID
                            //마스터에서 가져올 수 있는 데이터
                            inputList.Add("I_GROUP_GUBUN", dtRow["GROUP_GUBUN"].ToString().Trim());                 //그룹구분(마스터 데이터를 패키지 데이터로 변환하여 넣기)
                            inputList.Add("I_PARENT_CODE", dtRow["PARENT_CODE"].ToString().Trim());                 //부모 코드
                            inputList.Add("I_HANGMOG_CODE", dtRow["HANGMOG_CODE"].ToString().Trim());               //항목 코드
                            inputList.Add("I_SERIAL", dtRow["SERIAL"].ToString().Trim());                           //순번(bml 측에서는 자식 항목이 있을 때만 데이터가 존재)
                            inputList.Add("I_GUMSA_NAME_RE", dtRow["GUMSA_NAME_RE"].ToString().Trim());             //검사명 전각 8자리
                            inputList.Add("I_GUMSA_NAME", dtRow["GUMSA_NAME"].ToString().Trim());                   //검사명
                            inputList.Add("I_SLIP_CODE", dtRow["SLIP_CODE"].ToString().Trim());                     //슬립코드
                            inputList.Add("I_SLIP_NAME", dtRow["SLIP_NAME"].ToString().Trim());                     //슬립명
                            inputList.Add("I_JUNDAL_GUBUN", dtRow["JUNDAL_GUBUN"].ToString().Trim());               //전달구분코드
                            inputList.Add("I_JUNDAL_GUBUN_NAME", dtRow["JUNDAL_GUBUN_NAME"].ToString().Trim());     //전달구분명
                            inputList.Add("I_TUBE_NAME", dtRow["TUBE_NAME"].ToString().Trim());                     //용기코드(명)
                            inputList.Add("I_KEEP_MEANS_NAME", dtRow["KEEP_MEANS_NAME"].ToString().Trim());         //저장방법
                            inputList.Add("I_SPECIMEN_CODE", dtRow["SPECIMEN_CODE"].ToString().Trim());             //검체코드
                            inputList.Add("I_SPECIMEN_NAME", dtRow["SPECIMEN_NAME"].ToString().Trim());             //검체명
                            inputList.Add("I_DANUI", dtRow["DANUI"].ToString().Trim());                             //단위
                            inputList.Add("I_MEN_FROM_STANDARD", dtRow["MEN_FROM_STANDARD"].ToString().Trim());     //M LOW 기준치
                            inputList.Add("I_MEN_TO_STANDARD", dtRow["MEN_TO_STANDARD"].ToString().Trim());         //M HIGH 기준치
                            inputList.Add("I_WOMEN_FROM_STANDARD", dtRow["WOMEN_FROM_STANDARD"].ToString().Trim()); //F LOW 기준치
                            inputList.Add("I_WOMEN_TO_STANDARD", dtRow["WOMEN_TO_STANDARD"].ToString().Trim());     //F HIGH 기준치
                            inputList.Add("I_SG_CODE1", dtRow["SG_CODE"].ToString().Trim());                        //CPL의 SUGA_CODE에 넣기 추후 OCS0103의 SG_CODE는 BAS0310의 SG_UNION에 맵핑시켜 인서트하기
                            inputList.Add("I_SG_CODE2", dtRow["SG_CODE2"].ToString().Trim());                       //BML 미팅 후 해당 점수 코드의 의미 파악하기
                            if (TypeCheck.IsDecimal(JapanTextHelper.GetHalfKatakana(dtRow["SPECIMEN_AMT"].ToString().Trim(), false)))
                            {
                                inputList.Add("I_SPECIMEN_AMT", dtRow["SPECIMEN_AMT"].ToString().Trim());           //최소 검체량
                                inputList.Add("I_DETAIL_INFO", DBNull.Value);                                       //세부정보
                            }
                            else
                            {
                                inputList.Add("I_SPECIMEN_AMT", DBNull.Value);
                                if (!TypeCheck.IsNull(dtRow["SPECIMEN_AMT"].ToString().Trim()))
                                    inputList.Add("I_DETAIL_INFO", "最低必要量 : " + dtRow["SPECIMEN_AMT"].ToString().Trim());       //세부정보
                                else
                                    inputList.Add("I_DETAIL_INFO", DBNull.Value);                                                    //세부정보
                            }

                            //마스터에서 가져올 수 없는 데이터
                            inputList.Add("I_JUKYONG_DATE", null);               //적용일
                            inputList.Add("I_EMERGENCY", ckbEm.Checked?"Y":"N");                     //응급 여부
                            inputList.Add("I_JANGBI_CODE", null);                 //장비코드
                            inputList.Add("I_RESULT_YN", "Y");                     //결과가 나오는 항목
                            inputList.Add("I_UITAK_CODE", "BML");                   //BML
                            inputList.Add("I_JANGBI_OUT_CODE", dtRow["HANGMOG_CODE"].ToString().Trim());         //검체코드 + 항목코드 로 할지.. 항목코드만 넣을지 미팅 후 정하기
                            inputList.Add("I_CHUBANG_YN", "Y");                   //처방 yn
                            inputList.Add("I_DISPLAY_YN", "Y");                   //결과창 DEFAULT DISPLAY YN
                            //inputList.Add("I_DETAIL_INFO", "BML DETAIL_INFO");                 //세부정보

                            //inputList.Add("I_JUKYONG_DATE", dtRow["JUKYONG_DATE"].ToString());               //적용일
                            //inputList.Add("I_EMERGENCY", dtRow["EMERGENCY"].ToString());                     //응급 여부
                            //inputList.Add("I_JANGBI_CODE", dtRow["JANGBI_CODE"].ToString());                 //장비코드
                            //inputList.Add("I_RESULT_YN", dtRow["RESULT_YN"].ToString());                     //결과가 나오는 항목
                            //inputList.Add("I_UITAK_CODE", dtRow["UITAK_CODE"].ToString());                   //BML
                            //inputList.Add("I_JANGBI_OUT_CODE", dtRow["JANGBI_OUT_CODE"].ToString());         //검체코드 + 항목코드 로 할지.. 항목코드만 넣을지 미팅 후 정하기
                            //inputList.Add("I_CHUBANG_YN", dtRow["CHUBANG_YN"].ToString());                   //처방 yn
                            //inputList.Add("I_DISPLAY_YN", dtRow["DISPLAY_YN"].ToString());                   //결과창 DEFAULT DISPLAY YN
                            //inputList.Add("I_DETAIL_INFO", dtRow["DETAIL_INFO"].ToString());                 //세부정보


                            Hashtable outputList = new Hashtable();

                            if (Service.ExecuteProcedure("PR_CPL_BML_UPLOADER", inputList, outputList)) //성공
                            {
                                if ( !TypeCheck.IsNull(dtRow["SPECIMEN_CODE2"].ToString())
                                  && !TypeCheck.IsNull(dtRow["SPECIMEN_NAME2"].ToString()))
                                {
                                    inputList.Remove("I_SPECIMEN_CODE");
                                    inputList.Remove("I_SPECIMEN_NAME");
                                    inputList.Add("I_SPECIMEN_CODE", dtRow["SPECIMEN_CODE2"].ToString().Trim());             //검체코드
                                    inputList.Add("I_SPECIMEN_NAME", dtRow["SPECIMEN_NAME2"].ToString().Trim());             //검체명

                                    if (!Service.ExecuteProcedure("PR_CPL_BML_UPLOADER", inputList, outputList))
                                    {
                                        XMessageBox.Show(Service.ErrCode + " : " + Service.ErrFullMsg);
                                        Service.RollbackTransaction();
                                        progBar.Visible = false;
                                        progBar.Refresh();
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                //datas = "";
                                //for (int i = 0; i < excelTable.Columns.Count; i++)
                                //{
                                //    datas += excelTable.Columns[i].ColumnName + "[" + dtRow[i].ToString() + "] \r\n";
                                //}
                                //Service.debugFileWrite(datas);

                                XMessageBox.Show(Service.ErrCode + " : " + Service.ErrFullMsg);
                                Service.RollbackTransaction();
                                progBar.Visible = false;
                                progBar.Refresh();
                                break;
                            }

                        }
                    }
                    Service.CommitTransaction();
                    progBar.Visible = false;
                    progBar.Refresh();
                    break;
                case FunctionType.Insert:
                    e.IsBaseCall = false;
                    progBar.Visible = true;
                    progBar.Refresh();

                    progBar.Minimum = 1;

                    progBar.Maximum = excelTable.Rows.Count;

                    progBar.Value = 1;

                    progBar.Step = 1;
                    for (int i = 0; i < excelTable.Rows.Count; i++)
                    {
                        progBar.PerformStep();
                    }
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region Excel Class
        public class Excel
        {
            string _filepath = "";
            string _sheetname = "";

            /// <summary>
            /// Excel Data Conversion Class
            /// </summary>
            /// <param name="strFilePath">Excel File Path</param>
            /// <param name="strSheetName">Excel Sheet Name</param>
            public Excel(string strFilePath, string strSheetName)
            {
                _filepath = strFilePath;
                _sheetname = strSheetName;
            }

            public System.Data.DataTable GetDataTable()
            {
                string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;"
                    + "Data Source=" + _filepath + ";Extended Properties=\"Excel 8.0;\"";
                string strSel = "SELECT * FROM [" + _sheetname + "$]";

                OleDbDataAdapter oAdap = new OleDbDataAdapter(strSel, strConn);
                DataTable oTable = new DataTable();

                try
                {
                    oAdap.Fill(oTable);
                }
                catch (Exception ex)
                {
                    oTable.Columns.Add("Data Access failed in " + _filepath + " > " + _sheetname);
                    oTable.Columns.Add(ex.Message);
                }

                return oTable;
            }
        }
        #endregion

        #region XSavePerformer
        private class XSavePerformer : IHIS.Framework.ISavePerformer
        {
            private CPLBMLUPLOADER parent = null;
            public XSavePerformer(CPLBMLUPLOADER parent)
            {
                this.parent = parent;
            }
            public bool Execute(char callerID, RowDataItem item)
            {
                string cmdText = "";
                //Grid에서 넘어온 Bind 변수에 f_user_id SET
                item.BindVarList.Add("f_user_id", UserInfo.UserID);
                item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);


                switch (item.RowState)
                {
                    case DataRowState.Added:
                        cmdText = @"INSERT INTO CPL0106 (SYS_DATE         ,USER_ID             ,UPD_DATE
                                                        ,GROUP_GUBUN      ,HANGMOG_CODE        ,SPECIMEN_CODE    
                                                        ,EMERGENCY        ,SUB_HANGMOG_CODE    ,SUB_SPECIMEN_CODE
                                                        ,SUB_EMERGENCY    ,CONTINUE_YN      
                                               ) VALUES (SYSDATE          ,:f_user_id          ,SYSDATE
                                                        ,:f_group_gubun   ,:f_hangmog_code     ,:f_specimen_code    
                                                        ,:f_emergency     ,:f_sub_hangmog_code ,:f_sub_specimen_code
                                                        ,:f_sub_emergency ,:f_continue_yn      
                                                        )";
                        break;
                    case DataRowState.Modified:
                        cmdText = @"UPDATE CPL0106
                                       SET USER_ID           = :f_user_id
                                         , SYS_DATE          = SYSDATE
                                         , SUB_SPECIMEN_CODE = :f_sub_specimen_code                      
                                         , SUB_EMERGENCY     = :f_sub_emergency                              
                                         , CONTINUE_YN       = :f_continue_yn                            
                                     WHERE GROUP_GUBUN       = :f_group_gubun                          
                                       AND HANGMOG_CODE      = :f_hangmog_code                          
                                       AND SPECIMEN_CODE     = :f_specimen_code                        
                                       AND EMERGENCY         = :f_emergency
                                       AND SUB_HANGMOG_CODE  = :f_sub_hangmog_code";
                        break;
                    case DataRowState.Deleted:
                        cmdText = @"DELETE CPL0106
                                     WHERE GROUP_GUBUN      = :f_group_gubun                          
                                       AND HANGMOG_CODE     = :f_hangmog_code                          
                                       AND SPECIMEN_CODE    = :f_specimen_code                        
                                       AND EMERGENCY        = :f_emergency
                                       AND SUB_HANGMOG_CODE = :f_sub_hangmog_code";
                        break;
                }

                return Service.ExecuteNonQuery(cmdText, item.BindVarList);
            }
        }
        #endregion

        #region open file dialog logic
        private void btnSearchFile_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.txtBMLFileName.SetDataValue(this.openFileDialog.FileName);
            }
        }
        #endregion


    }
}

