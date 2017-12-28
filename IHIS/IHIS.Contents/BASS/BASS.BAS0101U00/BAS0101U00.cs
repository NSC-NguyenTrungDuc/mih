#region 사용 NameSpace 지정
using System;
using System.Collections.Generic;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.BASS.Properties;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Arguments.Bass;
using IHIS.CloudConnector.Contracts.Models.Bass;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.Bass;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.Framework;
using System.Text;
#endregion

namespace IHIS.BASS
{
	/// <summary>
	/// BAS0101U00에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class BAS0101U00 : IHIS.Framework.XScreen
	{
		private System.Windows.Forms.Splitter splitter1;
		private IHIS.Framework.XEditGrid grdDetail;
		private IHIS.Framework.XEditGridCell xEditGridCell1;
		private IHIS.Framework.XEditGridCell xEditGridCell2;
		private IHIS.Framework.XEditGridCell xEditGridCell3;
		private IHIS.Framework.XEditGridCell xEditGridCell4;
		private IHIS.Framework.XEditGridCell xEditGridCell5;
		private IHIS.Framework.XButtonList btnList;
		private IHIS.Framework.XMstGrid grdMaster;
		private IHIS.Framework.XEditGridCell xEditGridCell6;
		private IHIS.Framework.XEditGridCell xEditGridCell7;
		private IHIS.Framework.XEditGridCell xEditGridCell8;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

        private string mHospCode = "";
        private int TheFlag;

		public BAS0101U00()
		{
			// 이 호출은 Windows Form 디자이너에 필요합니다.
			InitializeComponent();
            ////
            //aaa

            this.grdMaster.ParamList = new List<string>(new String[] { "f_code_type" });
            this.grdDetail.ParamList = new List<string>(new String[] { "f_code_type" });

		    this.grdMaster.ExecuteQuery = LoadDataGrdMaster;
		    this.grdDetail.ExecuteQuery = LoadDataGrdDetail;
		}

		/// <summary>
		/// 사용 중인 모든 리소스를 정리합니다.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Designer generated code
		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다.
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BAS0101U00));
            this.btnList = new IHIS.Framework.XButtonList();
            this.grdMaster = new IHIS.Framework.XMstGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.grdDetail = new IHIS.Framework.XEditGrid();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // btnList
            // 
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Entry;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // grdMaster
            // 
            this.grdMaster.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2});
            this.grdMaster.ColPerLine = 1;
            this.grdMaster.Cols = 1;
            resources.ApplyResources(this.grdMaster, "grdMaster");
            this.grdMaster.ExecuteQuery = null;
            this.grdMaster.FixedRows = 1;
            this.grdMaster.HeaderHeights.Add(22);
            this.grdMaster.Name = "grdMaster";
            this.grdMaster.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdMaster.ParamList")));
            this.grdMaster.QuerySQL = resources.GetString("grdMaster.QuerySQL");
            this.grdMaster.Rows = 2;
            this.grdMaster.ToolTipActive = true;
            this.grdMaster.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdMaster_GridColumnChanged);
            this.grdMaster.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdMaster_QueryStarting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellLen = 30;
            this.xEditGridCell1.CellName = "code_type";
            this.xEditGridCell1.CellWidth = 168;
            this.xEditGridCell1.Col = -1;
            this.xEditGridCell1.ExecuteQuery = null;
            this.xEditGridCell1.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.ImeMode = IHIS.Framework.ColumnImeMode.EngUpper;
            this.xEditGridCell1.IsNotNull = true;
            this.xEditGridCell1.IsReadOnly = true;
            this.xEditGridCell1.IsUpdatable = false;
            this.xEditGridCell1.IsVisible = false;
            this.xEditGridCell1.Row = -1;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellLen = 30;
            this.xEditGridCell2.CellName = "code_type_name";
            this.xEditGridCell2.CellWidth = 280;
            this.xEditGridCell2.ExecuteQuery = null;
            this.xEditGridCell2.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.ImeMode = IHIS.Framework.ColumnImeMode.Hiragana;
            this.xEditGridCell2.IsNotNull = true;
            this.xEditGridCell2.IsReadOnly = true;
            // 
            // splitter1
            // 
            resources.ApplyResources(this.splitter1, "splitter1");
            this.splitter1.Name = "splitter1";
            this.splitter1.TabStop = false;
            // 
            // grdDetail
            // 
            this.grdDetail.CallerID = '2';
            this.grdDetail.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell6,
            this.xEditGridCell7,
            this.xEditGridCell8});
            this.grdDetail.ColPerLine = 5;
            this.grdDetail.Cols = 5;
            resources.ApplyResources(this.grdDetail, "grdDetail");
            this.grdDetail.ExecuteQuery = null;
            this.grdDetail.FixedRows = 1;
            this.grdDetail.HeaderHeights.Add(23);
            this.grdDetail.MasterLayout = this.grdMaster;
            this.grdDetail.Name = "grdDetail";
            this.grdDetail.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdDetail.ParamList")));
            this.grdDetail.QuerySQL = resources.GetString("grdDetail.QuerySQL");
            this.grdDetail.Rows = 2;
            this.grdDetail.ToolTipActive = true;
            this.grdDetail.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdDetail_GridColumnChanged);
            this.grdDetail.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdDetail_QueryStarting);
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellLen = 30;
            this.xEditGridCell3.CellName = "code_type";
            this.xEditGridCell3.Col = -1;
            this.xEditGridCell3.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.IsNotNull = true;
            this.xEditGridCell3.IsUpdatable = false;
            this.xEditGridCell3.IsVisible = false;
            this.xEditGridCell3.Row = -1;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "code";
            this.xEditGridCell4.CellWidth = 98;
            this.xEditGridCell4.ExecuteQuery = null;
            this.xEditGridCell4.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.ImeMode = IHIS.Framework.ColumnImeMode.EngUpper;
            this.xEditGridCell4.IsNotNull = true;
            this.xEditGridCell4.IsUpdatable = false;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellLen = 80;
            this.xEditGridCell5.CellName = "code_name";
            this.xEditGridCell5.CellWidth = 270;
            this.xEditGridCell5.Col = 1;
            this.xEditGridCell5.ExecuteQuery = null;
            this.xEditGridCell5.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.ImeMode = IHIS.Framework.ColumnImeMode.Hiragana;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "group_key";
            this.xEditGridCell6.CellWidth = 100;
            this.xEditGridCell6.Col = 2;
            this.xEditGridCell6.ExecuteQuery = null;
            this.xEditGridCell6.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellLen = 4000;
            this.xEditGridCell7.CellName = "remark";
            this.xEditGridCell7.CellWidth = 128;
            this.xEditGridCell7.Col = 3;
            this.xEditGridCell7.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell7.ExecuteQuery = null;
            this.xEditGridCell7.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "sort_key";
            this.xEditGridCell8.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell8.CellWidth = 45;
            this.xEditGridCell8.Col = 4;
            this.xEditGridCell8.ExecuteQuery = null;
            this.xEditGridCell8.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            // 
            // BAS0101U00
            // 
            this.Controls.Add(this.grdDetail);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.grdMaster);
            this.Controls.Add(this.btnList);
            this.Name = "BAS0101U00";
            resources.ApplyResources(this, "$this");
            this.Load += new System.EventHandler(this.BAS0101U00_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDetail)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private bool tFlag = false;

		private void BAS0101U00_Load(object sender, System.EventArgs e)
		{
            this.mHospCode = EnvironInfo.HospCode;

            //this.grdMaster.SavePerformer = new XSavePeformer(this);
            //this.grdDetail.SavePerformer = this.grdMaster.SavePerformer;

			// 마스터, 디테일 Relation 
			this.grdDetail.SetRelationKey("code_type", "code_type");
			this.grdDetail.SetRelationTable("bas0102");

			((XTextBox)((XEditGridCell)grdMaster.CellInfos["code_type_name"]).CellEditor.Editor).ApplyByteLimit = true;
			((XTextBox)((XEditGridCell)grdMaster.CellInfos["code_type_name"]).CellEditor.Editor).MaxLength = 30;			

			((XTextBox)((XEditGridCell)grdMaster.CellInfos["code_type_name"]).CellEditor.Editor).TextChanged += new System.EventHandler(this.xTextBox1_TextChanged);

            this.grdMaster.QueryLayout(false);
		}

		private void grdMaster_GridColumnChanged(object sender, IHIS.Framework.GridColumnChangedEventArgs e)
		{
			if (tFlag)
			{
				if (e.ColName == "code_type")	
				{
                    //ArrayList inputList = new ArrayList();
                    //ArrayList outputList = new ArrayList();

                    //inputList.Add("Y");           // master_check
                    //inputList.Add(e.ChangeValue); //code_type
                    //inputList.Add(e.ChangeValue); //col_id　마스터에서는 무의미

                    //Service.ExecuteProcedure("PR_OUT_CHECK_DUP_BAS0101", inputList, outputList);

                    //if (!TypeCheck.IsNull(outputList[0]))
                    //{
                    //    if (outputList[0].ToString() == "Y")
                    //    {
                    //        XMessageBox.Show(Resource.BAS0101U00_TEXT_MSG1, Resource.BAS0101U00_TEXT_CY, MessageBoxIcon.Warning);
                    //        e.Cancel = true;
                    //    }
                    //}


                    //tungtx
                    BAS0101U00PrBasGridColumnChangedArgs args = new BAS0101U00PrBasGridColumnChangedArgs();
				    args.CodeType = e.ChangeValue.ToString();
                    args.ColId = e.ChangeValue.ToString();
				    args.MasterCheck = "Y";
				    BAS0101U00PrBasGridColumnChangedResult result =
				        CloudService.Instance.Submit<BAS0101U00PrBasGridColumnChangedResult, BAS0101U00PrBasGridColumnChangedArgs>(
				            args);
                    if (result.ExecutionStatus != ExecutionStatus.Success || (result.ExecutionStatus == ExecutionStatus.Success && result.GrdMaster != null && result.GrdMaster.DupYn == "Y"))
				    {
                        XMessageBox.Show(Resource.BAS0101U00_TEXT_MSG1, Resource.BAS0101U00_TEXT_CY, MessageBoxIcon.Warning);
                        e.Cancel = true;
				    }
				}
			}
		}

		private void grdDetail_GridColumnChanged(object sender, IHIS.Framework.GridColumnChangedEventArgs e)
		{
			if (e.ColName == "code")
			{
                //ArrayList inputList = new ArrayList();
                //ArrayList outputList = new ArrayList();

                //inputList.Add("N");           // master_check
                //inputList.Add(this.grdMaster.GetItemString(grdMaster.CurrentRowNumber, "code_type")); //code_type
                //inputList.Add(e.ChangeValue); //col_id　마스터에서는 무의미

                //Service.ExecuteProcedure("PR_OUT_CHECK_DUP_BAS0101", inputList, outputList);

                //if (!TypeCheck.IsNull(outputList[0]))
                //{
                //    if (outputList[0].ToString() == "Y")
                //    {
                //        XMessageBox.Show(Resource.BAS0101U00_TEXT_MSG2, Resource.BAS0101U00_TEXT_CY, MessageBoxIcon.Warning);
                //        e.Cancel = true;
                //    }
                //}



                //tungtx
                BAS0101U00PrBasGridColumnChangedArgs args = new BAS0101U00PrBasGridColumnChangedArgs();
			    args.CodeType = this.grdMaster.GetItemString(grdMaster.CurrentRowNumber, "code_type");
                args.ColId = e.ChangeValue.ToString();
                args.MasterCheck = "N";
                BAS0101U00PrBasGridColumnChangedResult result =
                    CloudService.Instance.Submit<BAS0101U00PrBasGridColumnChangedResult, BAS0101U00PrBasGridColumnChangedArgs>(
                        args);
                if (result.ExecutionStatus != ExecutionStatus.Success || (result.ExecutionStatus == ExecutionStatus.Success && result.GrdMaster != null && result.GrdMaster.DupYn == "Y"))
                {
                    XMessageBox.Show(Resource.BAS0101U00_TEXT_MSG2, Resource.BAS0101U00_TEXT_CY, MessageBoxIcon.Warning);
                    e.Cancel = true;
                }
			}
		}

        private string mMsg = "";
        private string mCap = "";
		private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			tFlag = false;

			switch(e.Func)
			{
                case FunctionType.Query:
                    this.grdMaster.QueryLayout(false);
                    break;
				case FunctionType.Insert:

					tFlag = true;

                    //if (this.CurrMSLayout == this.grdMaster)
                    //{
                    //    if (Find_AddedRowState() == "Y")
                    //    {
                    //        XMessageBox.Show("修正されたデータがあります。先に保存して下さい。", "お知らせ");
                    //        e.IsBaseCall = false;
                    //    }
                    //}
                    e.IsBaseCall = false;
                    if (this.CurrMQLayout == this.grdDetail)
                    {
                        if (this.grdMaster.RowCount > 0)
                        {
                            int rowNum = this.grdDetail.InsertRow(-1);
                            this.grdDetail.SetFocusToItem(rowNum, "code");
                        }
                    }
					break;

                case FunctionType.Delete:
                    if (this.CurrMQLayout != this.grdDetail)
                    {
                        e.IsBaseCall = false;
                        return;
                    }
                    break;

                case FunctionType.Update:
                    e.IsBaseCall = false;

                    //try
                    //{
                    //    Service.BeginTransaction();

                    //    //if (this.grdMaster.SaveLayout())
                    //    //{
                    //        if (this.grdDetail.SaveLayout())
                    //        {
                    //            this.mMsg = NetInfo.Language == LangMode.Ko ? "저장이 완료되었습니다." : Resource.BAS0101U00_TEXT_MSG3;

                    //            this.mCap = NetInfo.Language == LangMode.Ko ? "저장완료" : Resource.BAS0101U00_TEXT_HTL;

                    //            XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //        }
                    //        else
                    //            throw new Exception();
                    //    //}
                    //    //else
                    //    //    throw new Exception();

                    //    Service.CommitTransaction();
                    //}
                    //catch
                    //{
                    //    Service.RollbackTransaction();
                    //    this.mMsg = NetInfo.Language == LangMode.Ko ? "저장에 실패 하였습니다." : Resource.BAS0101U00_TEXT_MSG4;

                    //    this.mMsg += "\r\n" + Service.ErrFullMsg;

                    //    this.mCap = NetInfo.Language == LangMode.Ko ? "저장실패" : Resource.BAS0101U00_TEXT_LTB;

                    //    XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error); 

                    //    break;
                    //}


                    try
                    {
                        if (SaveGrdDetail())
                        {
                            this.mMsg = Resource.BAS0101U00_TEXT_MSG3;

                            this.mCap = Resource.BAS0101U00_TEXT_HTL;

                            XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            grdMaster.QueryLayout(false);
                        }
                        else
                            throw new Exception();
                    }
                    catch
                    {
                        this.mMsg = Resource.BAS0101U00_TEXT_MSG4;

                        this.mMsg += "\r\n" + Service.ErrFullMsg;

                        this.mCap = Resource.BAS0101U00_TEXT_LTB;
                        XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

                        break;
                    }
                    break;
			}
		}


	    private string Find_AddedRowState()
		{
			if (this.CurrMSLayout == this.grdMaster)	
			{
				// 마스터 그리드 새로 삽입된 행 검색
				for (int i=0; i<this.grdMaster.RowCount; i++)
				{
					if (this.grdMaster.LayoutTable.Rows[i].RowState == DataRowState.Added)
						return "Y";
				}

				// 마스터에 새로운 행이 없을경우 디테일도 검색
				for (int i=0; i<this.grdDetail.RowCount; i++)
				{
					if (this.grdDetail.LayoutTable.Rows[i].RowState == DataRowState.Added)
						return "Y";
				}
			}
			return "N";
		}

		private void xButton1_Click(object sender, System.EventArgs e)
		{
			Color color = Color.Silver;

			XMessageBox.Show(color.R.ToString() + "." + color.G.ToString() + "." + color.B.ToString());
		}
	
		private int GetStringByte(string s)
		{   
			int returnByte = 0;

			if(s.Length == 0)
			{
				return returnByte;
			}

			Encoding JisEncoding = Encoding.GetEncoding("Shift-JIS");   
			returnByte = JisEncoding.GetByteCount(s);
			return returnByte;
		}

		private string SubstringByte(string s, int startIndex, int length)
		{   
			string returnString = "";
			int    limitLen,  cutLen;
			string padSpace = " ";
   
			if(GetStringByte(s) == 0 || GetStringByte(s) < startIndex || length < 1)
			{
				return returnString;
			}

			limitLen = GetStringByte(s) - startIndex ;
            
			if (length > limitLen)
			{
				cutLen = limitLen;
			}
			else
			{
				cutLen = length;
			}

			Encoding JisEncoding = Encoding.GetEncoding("Shift-JIS");   
			Byte[] encodingByte = JisEncoding.GetBytes(s);
   
			returnString = JisEncoding.GetString(encodingByte, startIndex,  cutLen);
			encodingByte = JisEncoding.GetBytes(returnString);
            
			if(encodingByte[encodingByte.Length-1] == 0)
			{
				returnString = JisEncoding.GetString(encodingByte, 0,  cutLen -1);
			}
            
			if(length > cutLen)
			{
				padSpace = padSpace.PadRight(length - cutLen);
				returnString = returnString + padSpace;
			}
			return returnString;
		}

		private void xTextBox1_TextChanged(object sender, System.EventArgs e)
		{
			XTextBox st = (XTextBox) sender;

			if (GetStringByte(st.GetDataValue()) > st.MaxLength)
			{
				st.Text = SubstringByte(st.GetDataValue(), 0, 30); 
				st.Select(st.Text.Length, 1);
			}
        }

        private void grdDetail_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdDetail.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdDetail.SetBindVarValue("f_code_type", this.grdMaster.GetItemString(this.grdMaster.CurrentRowNumber, "code_type"));
        }

        private void grdMaster_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdMaster.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
        }

        #region XSavePeformer
//        private class XSavePeformer : ISavePerformer
//        {
//            private BAS0101U00 parent = null;

//            public XSavePeformer(BAS0101U00 parent)
//            {
//                this.parent = parent;
//            }

//            public bool Execute(char callerId, RowDataItem item)
//            {
//                string cmdText = "";
//                object t_chk = "";

//                item.BindVarList.Add("q_user_id", UserInfo.UserID);
//                item.BindVarList.Add("f_hosp_code", parent.mHospCode);
//                switch (callerId)
//                { 
//                    case '1':
//                        switch (item.RowState)
//                        { 
//                            case DataRowState.Added:

//                                cmdText = @"SELECT 'Y'
//                                              FROM DUAL
//                                             WHERE EXISTS ( SELECT 'X'
//                                                              FROM BAS0101
//                                                             WHERE HOSP_CODE = :f_hosp_code 
//                                                               AND CODE_TYPE = :f_code_type )";

//                                t_chk = Service.ExecuteScalar(cmdText, item.BindVarList);

//                                if (!TypeCheck.IsNull(t_chk))
//                                {
//                                    if (t_chk.ToString() == "Y")
//                                    {
//                                        XMessageBox.Show("「" + item.BindVarList["f_code_type"].VarValue + Resource.BAS0101U00_TEXT_DDK, Resource.BAS0101U00_TEXT_CY, MessageBoxIcon.Warning);
//                                        return false;
//                                    }
//                                }

//                                cmdText = @"INSERT INTO BAS0101
//                                                 ( SYS_DATE　      , SYS_ID　　     , UPD_DATE          , UPD_ID
//                                                 , HOSP_CODE       , CODE_TYPE　　　, CODE_TYPE_NAME            )
//                                            VALUES(SYSDATE         , :q_user_id　   , SYSDATE           , :q_user_id　
//                                                 , :f_hosp_code    , :f_code_type    , :f_code_type_name         )";

//                                break;

//                            case DataRowState.Modified:

//                                cmdText = @"UPDATE BAS0101
//                                               SET UPD_ID         = :q_user_id
//                                                 , UPD_DATE       = SYSDATE
//                                                 , CODE_TYPE_NAME = :f_code_type_name
//                                             WHERE HOSP_CODE      = :f_hosp_code
//                                               AND CODE_TYPE      = :f_code_type";

//                                break;

//                            case DataRowState.Deleted:

//                                cmdText = @"SELECT 'Y'
//                                              FROM DUAL
//                                             WHERE EXISTS ( SELECT 'X'
//                                                              FROM BAS0102
//                                                             WHERE HOSP_CODE = :f_hosp_code
//                                                               AND CODE_TYPE = :f_code_type )";

//                                t_chk = Service.ExecuteScalar(cmdText, item.BindVarList);

//                                if (!TypeCheck.IsNull(t_chk))
//                                {
//                                    if (t_chk.ToString() == "Y")
//                                    {
//                                        XMessageBox.Show("「" + item.BindVarList["f_code_type"].VarValue + "」は詳細コードが登録されているため削除出来ません。", Resource.BAS0101U00_TEXT_CY, MessageBoxIcon.Warning);
//                                        return false;
//                                    }
//                                }

//                                cmdText = @"DELETE FROM BAS0101
//                                                WHERE HOSP_CODE = :f_hosp_code
//                                                  AND CODE_TYPE = :f_code_type";

//                                break;
//                        }
//                        break;

//                    case '2':
//                        switch (item.RowState)
//                        {
//                            case DataRowState.Added:

//                                cmdText = @"SELECT 'Y'
//                                              FROM DUAL
//                                             WHERE EXISTS ( SELECT 'X'
//                                                              FROM BAS0102
//                                                             WHERE HOSP_CODE = :f_hosp_code
//                                                               AND CODE_TYPE = :f_code_type
//                                                               AND CODE      = :f_code        )";

//                                t_chk = Service.ExecuteScalar(cmdText, item.BindVarList);

//                                if (!TypeCheck.IsNull(t_chk))
//                                {
//                                    if (t_chk.ToString() == "Y")
//                                    {
//                                        XMessageBox.Show("「" + item.BindVarList["f_code"].VarValue + Resource.BAS0101U00_TEXT_DDK, Resource.BAS0101U00_TEXT_CY, MessageBoxIcon.Warning);
//                                        return false;
//                                    }
//                                }

//                                cmdText = @"INSERT INTO BAS0102
//                                                 ( SYS_DATE         , SYS_ID         , UPD_DATE      , UPD_ID
//                                                 , HOSP_CODE        , CODE_TYPE      , CODE          , CODE_NAME
//                                                 , GROUP_KEY        , REMARK         , SORT_KEY   )
//                                            VALUES(SYSDATE          , :q_user_id     , SYSDATE       , :q_user_id
//                                                 , :f_hosp_code     , :f_code_type   , :f_code       , :f_code_name
//                                                 , :f_group_key     , :f_remark      , :f_sort_key     )";

//                                break;

//                            case DataRowState.Modified:

//                                cmdText = @"UPDATE BAS0102
//                                             SET UPD_ID    = :q_user_id
//                                               , UPD_DATE  = SYSDATE
//                                               , CODE_NAME = :f_code_name
//                                               , GROUP_KEY = :f_group_key
//                                               , REMARK    = :f_remark
//                                               , SORT_KEY  = :f_sort_key
//                                           WHERE HOSP_CODE = :f_hosp_code
//                                             AND CODE_TYPE = :f_code_type
//                                             AND CODE      = :f_code      ";

//                                break;

//                            case DataRowState.Deleted:

//                                cmdText = @"DELETE FROM BAS0102
//                                             WHERE HOSP_CODE = :f_hosp_code
//                                               AND CODE_TYPE = :f_code_type
//                                               AND CODE      = :f_code    ";

//                                break;
//                        }

//                        break;
//                }

//                return Service.ExecuteNonQuery(cmdText, item.BindVarList);
//            }
//        }
        #endregion

        #region CloudService LoadData

        /// <summary>
        /// Get data from Cloud for grdMaster
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> LoadDataGrdMaster(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            BAS0101U00grdMasterArgs args = new BAS0101U00grdMasterArgs();
            args.CodeType = bc["f_code_type"] != null ? bc["f_code_type"].VarValue : "";
            BAS0101U00grdMasterResult result =
                CloudService.Instance.Submit<BAS0101U00grdMasterResult, BAS0101U00grdMasterArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (BAS0101U00GrdMasterItemInfo item in result.GrdMaster)
                {
                    object[] objects =
	                {
	                    item.CodeType,
	                    item.CodeTypeName,
	                    item.RowState
	                };
                    res.Add(objects);
                }
            }
            return res;
        }


        /// <summary>
        /// Get data from Cloud for grdDetail
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> LoadDataGrdDetail(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            BAS0101U00grdDetailArgs args = new BAS0101U00grdDetailArgs();
            args.CodeType = bc["f_code_type"] != null ? bc["f_code_type"].VarValue : "";
            BAS0101U00grdDetailResult result =
                CloudService.Instance.Submit<BAS0101U00grdDetailResult, BAS0101U00grdDetailArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (BAS0101U00grdDetailItemInfo item in result.GrdDetail)
                {
                    object[] objects =
	                {
	                    item.CodeType,
	                    item.Code,
	                    item.CodeName,
	                    item.GroupKey,
	                    item.Remark,
	                    item.SortKey,
	                    item.RowState
	                };
                    res.Add(objects);
                }
            }
            return res;
        }

        /// <summary>
        /// Save all changed data in grdDetail
        /// </summary>
        /// <returns></returns>
        private bool SaveGrdDetail()
        {
            List<BAS0101U00grdDetailItemInfo> inputDetailList = GetListFromGrdDetail();
            if (inputDetailList.Count == 0 && TheFlag == 0)
            {
                return true;
            }

            BAS0101U00ExecuteArgs args = new BAS0101U00ExecuteArgs();
            args.DetailInputList = inputDetailList;
            args.MasterInputList = new List<BAS0101U00GrdMasterItemInfo>();
            args.UserId = UserInfo.UserID;

            UpdateResult result = CloudService.Instance.Submit<UpdateResult, BAS0101U00ExecuteArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                if (result.Result == false)
                {
                                           
                        if (!String.IsNullOrEmpty(result.Msg))
                        {
                            XMessageBox.Show("「" + result.Msg + Resource.BAS0101U00_TEXT_DDK, Resource.BAS0101U00_TEXT_CY, MessageBoxIcon.Warning);
                        }
                }
                return result.Result;
               
            }

            return false;
        }

        /// <summary>
        /// get List of Info from grdDetail
        /// </summary>
        /// <returns></returns>
	    private List<BAS0101U00grdDetailItemInfo> GetListFromGrdDetail()
	    {
	        List<BAS0101U00grdDetailItemInfo> dataList = new List<BAS0101U00grdDetailItemInfo>();
            for (int i = 0; i < grdDetail.RowCount; i++)
            {
                if (grdDetail.GetRowState(i) == DataRowState.Unchanged)
                {
                    continue;
                }
                BAS0101U00grdDetailItemInfo info = new BAS0101U00grdDetailItemInfo();
                info.Code = grdDetail.GetItemString(i, "code");
                info.CodeName = grdDetail.GetItemString(i, "code_name");
                info.CodeType = this.grdMaster.GetItemString(this.grdMaster.CurrentRowNumber, "code_type");
                info.GroupKey = grdDetail.GetItemString(i, "group_key");
                info.Remark = grdDetail.GetItemString(i, "remark");
                info.SortKey = grdDetail.GetItemString(i, "sort_key");
                info.RowState = grdDetail.GetRowState(i).ToString();
                if (info.Code != "" && info.CodeName != "")
                {
                    dataList.Add(info);
                    TheFlag = 0;
                }
                else
                {
                    TheFlag =1;
                }
                
            }

            if (grdDetail.DeletedRowCount > 0)
            {
                foreach (DataRow row in grdDetail.DeletedRowTable.Rows)
                {
                    BAS0101U00grdDetailItemInfo info = new BAS0101U00grdDetailItemInfo();
                    info.Code = row["code"].ToString();
                    info.CodeType = this.grdMaster.GetItemString(this.grdMaster.CurrentRowNumber, "code_type");
                    info.RowState = DataRowState.Deleted.ToString();

                    dataList.Add(info);
                }
            }

            return dataList;
	    }

	    #endregion
	}
}

