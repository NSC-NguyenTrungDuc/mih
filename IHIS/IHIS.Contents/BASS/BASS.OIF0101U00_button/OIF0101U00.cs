#region 사용 NameSpace 지정
using System;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.Framework;
using System.Text;
#endregion

namespace IHIS.BASS
{
	/// <summary>
    /// OIF0101U00에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class OIF0101U00 : IHIS.Framework.XScreen
    {
		private IHIS.Framework.XEditGrid grdDetail;
		private IHIS.Framework.XEditGridCell xEditGridCell1;
		private IHIS.Framework.XEditGridCell xEditGridCell2;
		private IHIS.Framework.XEditGridCell xEditGridCell3;
		private IHIS.Framework.XEditGridCell xEditGridCell4;
        private IHIS.Framework.XEditGridCell xEditGridCell5;
        private IHIS.Framework.XMstGrid grdMaster;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;
        private XEditGridCell xEditGridCell6;
        private XPanel xPanel1;
        private XPanel xPanel2;
        private XButtonList btnList;

		public OIF0101U00()
		{
			// 이 호출은 Windows Form 디자이너에 필요합니다.
			InitializeComponent();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OIF0101U00));
            this.grdMaster = new IHIS.Framework.XMstGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.grdDetail = new IHIS.Framework.XEditGrid();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.btnList = new IHIS.Framework.XButtonList();
            ((System.ComponentModel.ISupportInitialize)(this.grdMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDetail)).BeginInit();
            this.xPanel1.SuspendLayout();
            this.xPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.SuspendLayout();
            // 
            // grdMaster
            // 
            this.grdMaster.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2});
            this.grdMaster.ColPerLine = 2;
            this.grdMaster.Cols = 2;
            this.grdMaster.Dock = System.Windows.Forms.DockStyle.Left;
            this.grdMaster.FixedRows = 1;
            this.grdMaster.HeaderHeights.Add(22);
            this.grdMaster.Location = new System.Drawing.Point(0, 0);
            this.grdMaster.Name = "grdMaster";
            this.grdMaster.QuerySQL = resources.GetString("grdMaster.QuerySQL");
            this.grdMaster.Rows = 2;
            this.grdMaster.Size = new System.Drawing.Size(443, 621);
            this.grdMaster.TabIndex = 3;
            this.grdMaster.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdMaster_GridColumnChanged);
            this.grdMaster.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdMaster_QueryStarting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellLen = 20;
            this.xEditGridCell1.CellName = "code_type";
            this.xEditGridCell1.CellWidth = 168;
            this.xEditGridCell1.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell1.HeaderText = "コード類型";
            this.xEditGridCell1.ImeMode = IHIS.Framework.ColumnImeMode.EngUpper;
            this.xEditGridCell1.IsUpdatable = false;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellLen = 80;
            this.xEditGridCell2.CellName = "code_type_name";
            this.xEditGridCell2.CellWidth = 256;
            this.xEditGridCell2.Col = 1;
            this.xEditGridCell2.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell2.HeaderText = "コード類型名称";
            this.xEditGridCell2.ImeMode = IHIS.Framework.ColumnImeMode.Hiragana;
            // 
            // grdDetail
            // 
            this.grdDetail.CallerID = '2';
            this.grdDetail.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell6});
            this.grdDetail.ColPerLine = 3;
            this.grdDetail.Cols = 3;
            this.grdDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdDetail.FixedRows = 1;
            this.grdDetail.HeaderHeights.Add(23);
            this.grdDetail.Location = new System.Drawing.Point(443, 0);
            this.grdDetail.MasterLayout = this.grdMaster;
            this.grdDetail.Name = "grdDetail";
            this.grdDetail.QuerySQL = "SELECT A.CODE_TYPE\r\n     , A.CODE\r\n     , A.CODE_NAME\r\n     , A.MAP_TYPE\r\n  FROM " +
                "OIF0102 A\r\n WHERE A.HOSP_CODE = :f_hosp_code\r\n   AND A.CODE_TYPE = :f_code_type\r" +
                "\n ORDER BY A.CODE";
            this.grdDetail.Rows = 2;
            this.grdDetail.Size = new System.Drawing.Size(475, 621);
            this.grdDetail.TabIndex = 1;
            this.grdDetail.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdDetail_QueryStarting);
            this.grdDetail.GridColumnProtectModify += new IHIS.Framework.GridColumnProtectModifyEventHandler(this.grdDetail_GridColumnProtectModify);
            this.grdDetail.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdDetail_GridColumnChanged);
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellLen = 30;
            this.xEditGridCell3.CellName = "code_type";
            this.xEditGridCell3.Col = -1;
            this.xEditGridCell3.HeaderText = "코드유형";
            this.xEditGridCell3.IsUpdatable = false;
            this.xEditGridCell3.IsVisible = false;
            this.xEditGridCell3.Row = -1;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellLen = 20;
            this.xEditGridCell4.CellName = "code";
            this.xEditGridCell4.CellWidth = 90;
            this.xEditGridCell4.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell4.HeaderText = "コード";
            this.xEditGridCell4.IsUpdatable = false;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellLen = 80;
            this.xEditGridCell5.CellName = "code_name";
            this.xEditGridCell5.CellWidth = 255;
            this.xEditGridCell5.Col = 1;
            this.xEditGridCell5.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell5.HeaderText = "コード名称";
            this.xEditGridCell5.ImeMode = IHIS.Framework.ColumnImeMode.Hiragana;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellLen = 30;
            this.xEditGridCell6.CellName = "map_type";
            this.xEditGridCell6.CellWidth = 110;
            this.xEditGridCell6.Col = 2;
            this.xEditGridCell6.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell6.HeaderText = "マッピングタイプ";
            // 
            // xPanel1
            // 
            this.xPanel1.Controls.Add(this.grdDetail);
            this.xPanel1.Controls.Add(this.grdMaster);
            this.xPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xPanel1.Location = new System.Drawing.Point(4, 4);
            this.xPanel1.Name = "xPanel1";
            this.xPanel1.Size = new System.Drawing.Size(918, 621);
            this.xPanel1.TabIndex = 4;
            // 
            // xPanel2
            // 
            this.xPanel2.Controls.Add(this.btnList);
            this.xPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.xPanel2.Location = new System.Drawing.Point(4, 625);
            this.xPanel2.Name = "xPanel2";
            this.xPanel2.Size = new System.Drawing.Size(918, 34);
            this.xPanel2.TabIndex = 10;
            // 
            // btnList
            // 
            this.btnList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnList.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnList.Location = new System.Drawing.Point(426, 2);
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Entry;
            this.btnList.Size = new System.Drawing.Size(487, 34);
            this.btnList.TabIndex = 2;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // OIF0101U00
            // 
            this.AutoCheckInputLayoutChanged = true;
            this.Controls.Add(this.xPanel1);
            this.Controls.Add(this.xPanel2);
            this.Name = "OIF0101U00";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.Size = new System.Drawing.Size(926, 663);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.OIF0101U00_Closing);
            this.Load += new System.EventHandler(this.OIF0101U00_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDetail)).EndInit();
            this.xPanel1.ResumeLayout(false);
            this.xPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private bool tFlag = false;

        private void OIF0101U00_Load(object sender, System.EventArgs e)
		{
            this.grdMaster.SavePerformer = new XSavePeformer(this);
            this.grdDetail.SavePerformer = this.grdMaster.SavePerformer;

			// 마스터, 디테일 Relation 
			this.grdDetail.SetRelationKey("code_type", "code_type");
			this.grdDetail.SetRelationTable("oif0102");

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

                    //Service.ExecuteProcedure("PR_OUT_CHECK_DUP_OIF0101", inputList, outputList);

                    //if (!TypeCheck.IsNull(outputList[0]))
                    //{
                    //    if (outputList[0].ToString() == "Y")
                    //    {
                    //        XMessageBox.Show("既に同じコード類型が登録されています。", "注意", MessageBoxIcon.Warning);
                    //        e.Cancel = true;
                    //    }
                    //}
				}
			}
		}

		private void grdDetail_GridColumnChanged(object sender, IHIS.Framework.GridColumnChangedEventArgs e)
		{
			if (e.ColName == "code")
			{
            //    ArrayList inputList = new ArrayList();
            //    ArrayList outputList = new ArrayList();

            //    inputList.Add("N");           // master_check
            //    inputList.Add(this.grdMaster.GetItemString(grdMaster.CurrentRowNumber, "code_type")); //code_type
            //    inputList.Add(e.ChangeValue); //col_id　마스터에서는 무의미

            //    Service.ExecuteProcedure("PR_OUT_CHECK_DUP_OIF0101", inputList, outputList);

            //    if (!TypeCheck.IsNull(outputList[0]))
            //    {
            //        if (outputList[0].ToString() == "Y")
            //        {
            //            XMessageBox.Show("既に同じコードが登録されています。", "注意", MessageBoxIcon.Warning);
            //            e.Cancel = true;
            //        }
            //    }
            }
		}

        private string mMsg = "";
        private string mCap = "";
        private string mCheck = "";
        private bool boolSave = true;

		private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			tFlag = false;
            this.boolSave = true;
            this.mMsg = "";

			switch(e.Func)
			{
                case FunctionType.Query:
                    this.grdMaster.QueryLayout(false);
                    break;
				case FunctionType.Insert:
					tFlag = true;

                    if (this.CurrMSLayout == this.grdMaster)
                    {
                        if (Find_AddedRowState() == "Y")
                        {
                            XMessageBox.Show("修正されたデータがあります。先に保存して下さい。", "お知らせ");
                            e.IsBaseCall = false;
                        }
                    }
					break;
                case FunctionType.Update:
                    e.IsBaseCall = false;
                    try
                    {
                        if (this.grdMaster.SaveLayout())
                        {
                            //this.mMsg = "";
                            if (this.grdDetail.SaveLayout())
                            {
                                this.mMsg = NetInfo.Language == LangMode.Ko ? "저장이 완료되었습니다." : "保存が完了しました。";
                                this.mCap = NetInfo.Language == LangMode.Ko ? "저장완료" : "保存完了";
                                XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.grdDetail.QueryLayout(false);
                            }
                            else
                                throw new Exception();
                            if (this.CurrMSLayout == this.grdMaster)
                            {
                                this.btnList.PerformClick(FunctionType.Query);
                            }
                        }
                        else
                            throw new Exception();
                    }
                    catch
                    {
                        this.boolSave = false;
                        MessageBoxIcon bntIcon = MessageBoxIcon.Error;
                        //this.mMsg = NetInfo.Language == LangMode.Ko ? "저장에 실패 하였습니다." : "保存に失敗しました。";

                        if (Service.ErrMsg == "CAN NOT MODIFY")
                        {
                            this.mMsg += NetInfo.Language == LangMode.Ko ?
                                "\r\n" + "맴핑구분은삭제및타입변경은불가능합니다" : 
                                "\r\n" + "マッピング区分は削除及びマッピングタイプ更新はできません。";
                        }
                        else
                        {
                            if (this.mMsg != "")
                            {
                                this.mCap = NetInfo.Language == LangMode.Ko ? "주의" : "注意";
                                bntIcon = MessageBoxIcon.Warning;                                        
                            }
                            else 
                            {
                                this.mCap = NetInfo.Language == LangMode.Ko ? "저장실패" : "保存失敗";
                                if (Service.ErrFullMsg == "")
                                {
                                    string mesg = NetInfo.Language == LangMode.Ko ? "를 확인하여주십시요." : "を確認してください。";
                                    this.mMsg = this.mCheck + mesg;
                                    bntIcon = MessageBoxIcon.Information;
                                }
                                else
                                {
                                    this.mMsg = NetInfo.Language == LangMode.Ko ? "저장에 실패 하였습니다." : "保存に失敗しました。";
                                    this.mMsg += "\r\n" + Service.ErrFullMsg;
                                    
                                }
                            }
                        }
                        XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, bntIcon); 
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

        #region XSavePeformer
        private class XSavePeformer : ISavePerformer
        {
            private OIF0101U00 parent = null;

            public XSavePeformer(OIF0101U00 parent)
            {
                this.parent = parent;
            }
            #region 입력값 체크
            private int Validateion_Check(char callerId, BindVarCollection BindVarList)
            {
                int value = 0;
                string messg = "";
                switch (callerId)
                {
                    case '1':
                        if (BindVarList["f_code_type"].VarValue == "")
                        {
                            messg += NetInfo.Language == LangMode.Ko ? "코드유형" : "コード類型";
                            value = 1;
                        }
                        if (BindVarList["f_code_type_name"].VarValue == "")
                        {
                            if (value == 1)
                            {
                                messg += ",";
                            }
                            messg += NetInfo.Language == LangMode.Ko ? "코드유형명칭" : "コード類型名称";
                            value = 1;
                        }
                        break;
                    case '2':
                        if (BindVarList["f_code"].VarValue == "")
                        {
                            messg += NetInfo.Language == LangMode.Ko ? "코드" : "コード";
                            value = 1;
                        }
                        if (BindVarList["f_code_name"].VarValue == "")
                        {
                            if (value == 1)
                            {
                                messg += ",";
                            }
                            messg += NetInfo.Language == LangMode.Ko ? "코드명칭" : "コード名称";
                            value = 1;
                        }
                        break;
                }
                parent.mCheck = messg;
                return value;
            }
            #endregion
            public bool Execute(char callerId, RowDataItem item)
            {
                string cmdText = "";
                object t_chk = "";

                item.BindVarList.Add("f_user_id", UserInfo.UserID);
                item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);

                switch (item.RowState)
                {
                    case DataRowState.Added:
                    case DataRowState.Modified:
                        if (Validateion_Check(callerId, item.BindVarList) != 0)
                        {
                            return false;
                        }
                        break;
                }
                switch (callerId)
                { 
                    case '1':
                        switch (item.RowState)
                        { 
                            case DataRowState.Added:
                                
                                cmdText = @"SELECT 'Y'
                                              FROM DUAL
                                             WHERE EXISTS ( SELECT 'X'
                                                              FROM OIF0101
                                                             WHERE HOSP_CODE = :f_hosp_code 
                                                               AND CODE_TYPE = :f_code_type )";

                                t_chk = Service.ExecuteScalar(cmdText, item.BindVarList);

                                if (!TypeCheck.IsNull(t_chk))
                                {
                                    if (t_chk.ToString() == "Y")
                                    {
                                        //XMessageBox.Show("「" + item.BindVarList["f_code_type"].VarValue + "」は既に登録されています。", "注意", MessageBoxIcon.Warning);
                                        parent.mMsg = NetInfo.Language == LangMode.Ko ?
                                            "「" + item.BindVarList["f_code_type"].VarValue + "」는이미등록되어있습니다" :
                                            "「" + item.BindVarList["f_code_type"].VarValue + "」は既に登録されています。";
                                        
                                        return false;
                                    }
                                }
                                cmdText = @"INSERT INTO OIF0101
                                                 ( SYS_DATE　      , SYS_ID　　     , UPD_DATE          , UPD_ID
                                                 , HOSP_CODE       , CODE_TYPE　　　, CODE_TYPE_NAME            )
                                            VALUES(SYSDATE         , :f_user_id　   , SYSDATE           , :f_user_id　
                                                 , :f_hosp_code    , :f_code_type    , :f_code_type_name         )";
                                break;
                            case DataRowState.Modified:
                                cmdText = @"UPDATE OIF0101
                                               SET UPD_ID         = :f_user_id
                                                 , UPD_DATE       = SYSDATE
                                                 , CODE_TYPE_NAME = :f_code_type_name
                                             WHERE HOSP_CODE      = :f_hosp_code
                                               AND CODE_TYPE      = :f_code_type";
                                break;
                            case DataRowState.Deleted:
                                cmdText = @"SELECT 'Y'
                                              FROM DUAL
                                             WHERE EXISTS ( SELECT 'X'
                                                              FROM OIF0102
                                                             WHERE HOSP_CODE = :f_hosp_code
                                                               AND CODE_TYPE = :f_code_type )";
                                t_chk = Service.ExecuteScalar(cmdText, item.BindVarList);
                                if (!TypeCheck.IsNull(t_chk))
                                {
                                    if (t_chk.ToString() == "Y")
                                    {
                                        parent.mMsg = NetInfo.Language == LangMode.Ko ? 
                                            "「" + item.BindVarList["f_code_type"].VarValue + "」는상세코드가등록되어있어서삭제할수없습니다." : 
                                            "「" + item.BindVarList["f_code_type"].VarValue + "」は詳細コードが登録されているため削除出来ません。";
                                        //XMessageBox.Show("「" + item.BindVarList["f_code_type"].VarValue + "」は詳細コードが登録されているため削除出来ません。", "注意", MessageBoxIcon.Warning);
                                        return false;
                                    }
                                }
                                cmdText = @"DELETE FROM OIF0101
                                                WHERE HOSP_CODE = :f_hosp_code
                                                  AND CODE_TYPE = :f_code_type";
                                break;
                        }
                        break;
                    case '2':
                        switch (item.RowState)
                        {
                            case DataRowState.Added:
                                cmdText = @"SELECT 'Y'
                                              FROM DUAL
                                             WHERE EXISTS ( SELECT 'X'
                                                              FROM OIF0102
                                                             WHERE HOSP_CODE = :f_hosp_code
                                                               AND CODE_TYPE = :f_code_type
                                                               AND CODE      = :f_code        )";

                                t_chk = Service.ExecuteScalar(cmdText, item.BindVarList);

                                if (!TypeCheck.IsNull(t_chk))
                                {
                                    if (t_chk.ToString() == "Y")
                                    {
                                        //XMessageBox.Show("「" + item.BindVarList["f_code"].VarValue + "」は既に登録されています。", "注意", MessageBoxIcon.Warning);
                                        parent.mMsg = NetInfo.Language == LangMode.Ko ?
                                              "「" + item.BindVarList["f_code"].VarValue + "」는이미등록되어있습니다" :
                                              "「" + item.BindVarList["f_code"].VarValue + "」は既に登録されています。";

                                        return false;
                                    }
                                }

                                cmdText = @"INSERT INTO OIF0102
                                                 ( SYS_DATE         , SYS_ID         , UPD_DATE      , UPD_ID
                                                 , HOSP_CODE        , CODE_TYPE      , CODE          , CODE_NAME
                                                 , MAP_TYPE )
                                            VALUES(SYSDATE          , :f_user_id     , SYSDATE       , :f_user_id
                                                 , :f_hosp_code     , :f_code_type   , :f_code       , :f_code_name
                                                 , :f_map_type )";
                                break;
                            case DataRowState.Modified:
                                cmdText = @"UPDATE OIF0102
                                             SET UPD_ID    = :f_user_id
                                               , UPD_DATE  = SYSDATE
                                               , CODE_NAME = :f_code_name
                                               , MAP_TYPE  = :f_map_type
                                           WHERE HOSP_CODE = :f_hosp_code
                                             AND CODE_TYPE = :f_code_type
                                             AND CODE      = :f_code      ";
                                break;
                            case DataRowState.Deleted:
                                cmdText = @"DELETE FROM OIF0102
                                             WHERE HOSP_CODE = :f_hosp_code
                                               AND CODE_TYPE = :f_code_type
                                               AND CODE      = :f_code    ";
                                break;
                        }
                        break;
                }
                return Service.ExecuteNonQuery(cmdText, item.BindVarList);
            }
        }
        #endregion

        private void grdDetail_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdDetail.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdDetail.SetBindVarValue("f_code_type", this.grdMaster.GetItemString(this.grdMaster.CurrentRowNumber, "code_type"));
        }

        private void grdMaster_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdMaster.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
        }

        private void grdDetail_GridColumnProtectModify(object sender, GridColumnProtectModifyEventArgs e)
        {
            if (e.ColName == "map_type")
            {
                if (this.grdMaster.GetItemString(this.grdMaster.CurrentRowNumber, "code_type") == "MAP_GUBUN")
                {
                    e.Protect = false;
                }
                else
                {
                    e.Protect = true;
                }
            }
        }

        private void OIF0101U00_Closing(object sender, CancelEventArgs e)
        {
            if (this.boolSave == false)
            {
                e.Cancel = true;
            }
        }
	}
}

