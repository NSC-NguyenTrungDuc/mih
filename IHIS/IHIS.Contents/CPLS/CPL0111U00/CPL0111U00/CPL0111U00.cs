#region 사용 NameSpace 지정
using System;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.CPLS.Properties;
using IHIS.Framework;
#endregion

namespace IHIS.CPLS
{
	/// <summary>
	/// CPL0111U00에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class CPL0111U00 : IHIS.Framework.XScreen
	{
		private IHIS.Framework.XPanel xPanel1;
		private IHIS.Framework.XPanel xPanel2;
		private IHIS.Framework.XPanel xPanel3;
		private IHIS.Framework.XPanel xPanel5;
		private IHIS.Framework.XButtonList btnList;
		private IHIS.Framework.XLabel xLabel1;
		private IHIS.Framework.SingleLayout dsvDup;
		private IHIS.Framework.XFindBox fbxJundalGubun;
		private IHIS.Framework.XDisplayBox dbxJundalGubunName;
		private IHIS.Framework.FindColumnInfo findColumnInfo1;
		private IHIS.Framework.FindColumnInfo findColumnInfo2;
		private IHIS.Framework.SingleLayout vsvJundalGubun;
		private IHIS.Framework.XFindWorker fwkJundalGubun;
		private IHIS.Framework.XEditGrid grdComment;
		private IHIS.Framework.XEditGridCell xEditGridCell1;
		private IHIS.Framework.XEditGridCell xEditGridCell2;
		private IHIS.Framework.XEditGridCell xEditGridCell3;
		private IHIS.Framework.XRadioButton rbxJundalGubun;
		private IHIS.Framework.XRadioButton rbxPa;
		private IHIS.Framework.XEditGridCell xEditGridCell4;
        private SingleLayoutItem singleLayoutItem1;
        private SingleLayoutItem singleLayoutItem2;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public CPL0111U00()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CPL0111U00));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.xPanel5 = new IHIS.Framework.XPanel();
            this.grdComment = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.btnList = new IHIS.Framework.XButtonList();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.rbxPa = new IHIS.Framework.XRadioButton();
            this.rbxJundalGubun = new IHIS.Framework.XRadioButton();
            this.dbxJundalGubunName = new IHIS.Framework.XDisplayBox();
            this.fbxJundalGubun = new IHIS.Framework.XFindBox();
            this.fwkJundalGubun = new IHIS.Framework.XFindWorker();
            this.findColumnInfo1 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo2 = new IHIS.Framework.FindColumnInfo();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.dsvDup = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem1 = new IHIS.Framework.SingleLayoutItem();
            this.vsvJundalGubun = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem2 = new IHIS.Framework.SingleLayoutItem();
            this.xPanel1.SuspendLayout();
            this.xPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdComment)).BeginInit();
            this.xPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.xPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // xPanel1
            // 
            this.xPanel1.Controls.Add(this.xPanel5);
            this.xPanel1.Controls.Add(this.xPanel3);
            this.xPanel1.Controls.Add(this.xPanel2);
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Name = "xPanel1";
            // 
            // xPanel5
            // 
            this.xPanel5.Controls.Add(this.grdComment);
            resources.ApplyResources(this.xPanel5, "xPanel5");
            this.xPanel5.DrawBorder = true;
            this.xPanel5.Name = "xPanel5";
            // 
            // grdComment
            // 
            this.grdComment.CallerID = '2';
            this.grdComment.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell4});
            this.grdComment.ColPerLine = 3;
            this.grdComment.ColResizable = true;
            this.grdComment.Cols = 4;
            resources.ApplyResources(this.grdComment, "grdComment");
            this.grdComment.ExecuteQuery = null;
            this.grdComment.FixedCols = 1;
            this.grdComment.FixedRows = 1;
            this.grdComment.HeaderHeights.Add(21);
            this.grdComment.Name = "grdComment";
            this.grdComment.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdComment.ParamList")));
            this.grdComment.QuerySQL = "SELECT A.JUNDAL_GUBUN\r\n     , A.CODE\r\n     , A.NOTE     \r\n     , A.NOTE_RE\r\n  FRO" +
    "M CPL0111 A      \r\n WHERE A.HOSP_CODE    = :f_hosp_code\r\n   AND A.JUNDAL_GUBUN =" +
    " :f_jundal_gubun\r\n ORDER BY 2";
            this.grdComment.RowHeaderVisible = true;
            this.grdComment.Rows = 2;
            this.grdComment.PreSaveLayout += new IHIS.Framework.GridRecordEventHandler(this.grdComment_PreSaveLayout);
            this.grdComment.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdComment_GridColumnChanged);
            this.grdComment.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdComment_QueryStarting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellLen = 4;
            this.xEditGridCell1.CellName = "jundal_gubun";
            this.xEditGridCell1.Col = -1;
            this.xEditGridCell1.ExecuteQuery = null;
            this.xEditGridCell1.IsVisible = false;
            this.xEditGridCell1.Row = -1;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellLen = 4;
            this.xEditGridCell2.CellName = "code";
            this.xEditGridCell2.Col = 1;
            this.xEditGridCell2.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.IsUpdatable = false;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellLen = 200;
            this.xEditGridCell3.CellName = "note";
            this.xEditGridCell3.CellWidth = 739;
            this.xEditGridCell3.Col = 2;
            this.xEditGridCell3.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "note_re";
            this.xEditGridCell4.CellWidth = 81;
            this.xEditGridCell4.Col = 3;
            this.xEditGridCell4.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            // 
            // xPanel3
            // 
            this.xPanel3.Controls.Add(this.btnList);
            resources.ApplyResources(this.xPanel3, "xPanel3");
            this.xPanel3.DrawBorder = true;
            this.xPanel3.Name = "xPanel3";
            // 
            // btnList
            // 
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.IsVisibleReset = false;
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Entry;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // xPanel2
            // 
            this.xPanel2.Controls.Add(this.rbxPa);
            this.xPanel2.Controls.Add(this.rbxJundalGubun);
            this.xPanel2.Controls.Add(this.dbxJundalGubunName);
            this.xPanel2.Controls.Add(this.fbxJundalGubun);
            this.xPanel2.Controls.Add(this.xLabel1);
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.DrawBorder = true;
            this.xPanel2.Name = "xPanel2";
            // 
            // rbxPa
            // 
            resources.ApplyResources(this.rbxPa, "rbxPa");
            this.rbxPa.Name = "rbxPa";
            this.rbxPa.UseVisualStyleBackColor = false;
            this.rbxPa.CheckedChanged += new System.EventHandler(this.rbxPa_CheckedChanged);
            // 
            // rbxJundalGubun
            // 
            this.rbxJundalGubun.Checked = true;
            resources.ApplyResources(this.rbxJundalGubun, "rbxJundalGubun");
            this.rbxJundalGubun.Name = "rbxJundalGubun";
            this.rbxJundalGubun.TabStop = true;
            this.rbxJundalGubun.UseVisualStyleBackColor = false;
            this.rbxJundalGubun.CheckedChanged += new System.EventHandler(this.rbxJundalGubun_CheckedChanged);
            // 
            // dbxJundalGubunName
            // 
            resources.ApplyResources(this.dbxJundalGubunName, "dbxJundalGubunName");
            this.dbxJundalGubunName.Name = "dbxJundalGubunName";
            // 
            // fbxJundalGubun
            // 
            this.fbxJundalGubun.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.fbxJundalGubun.FindWorker = this.fwkJundalGubun;
            resources.ApplyResources(this.fbxJundalGubun, "fbxJundalGubun");
            this.fbxJundalGubun.Name = "fbxJundalGubun";
            this.fbxJundalGubun.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxJundalGubun_DataValidating);
            this.fbxJundalGubun.Enter += new System.EventHandler(this.fbxJundalGubun_Enter);
            // 
            // fwkJundalGubun
            // 
            this.fwkJundalGubun.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo1,
            this.findColumnInfo2});
            this.fwkJundalGubun.ExecuteQuery = null;
            this.fwkJundalGubun.FormText = global::IHIS.CPLS.Properties.Resources.FWKJUNDALGUBUN_FORMTEXT;
            this.fwkJundalGubun.InputSQL = resources.GetString("fwkJundalGubun.InputSQL");
            this.fwkJundalGubun.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("fwkJundalGubun.ParamList")));
            this.fwkJundalGubun.SearchImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.fwkJundalGubun.ServerFilter = true;
            this.fwkJundalGubun.QueryStarting += new System.ComponentModel.CancelEventHandler(this.fwkJundalGubun_QueryStarting);
            // 
            // findColumnInfo1
            // 
            this.findColumnInfo1.ColName = "gubun";
            this.findColumnInfo1.ColWidth = 106;
            this.findColumnInfo1.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo1, "findColumnInfo1");
            // 
            // findColumnInfo2
            // 
            this.findColumnInfo2.ColName = "gubun_name";
            this.findColumnInfo2.ColWidth = 315;
            this.findColumnInfo2.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo2, "findColumnInfo2");
            // 
            // xLabel1
            // 
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.Name = "xLabel1";
            // 
            // dsvDup
            // 
            this.dsvDup.ExecuteQuery = null;
            this.dsvDup.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem1});
            this.dsvDup.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("dsvDup.ParamList")));
            this.dsvDup.QuerySQL = resources.GetString("dsvDup.QuerySQL");
            this.dsvDup.QueryStarting += new System.ComponentModel.CancelEventHandler(this.dsvDup_QueryStarting);
            // 
            // singleLayoutItem1
            // 
            this.singleLayoutItem1.DataName = "dup_yn";
            // 
            // vsvJundalGubun
            // 
            this.vsvJundalGubun.ExecuteQuery = null;
            this.vsvJundalGubun.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem2});
            this.vsvJundalGubun.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("vsvJundalGubun.ParamList")));
            this.vsvJundalGubun.QuerySQL = "SELECT CODE_NAME\r\n  FROM CPL0109\r\n WHERE HOSP_CODE = :f_hosp_code\r\n   AND CODE_TY" +
    "PE = \'01\'\r\n   AND CODE = :f_code\r\n   AND SYSTEM_GUBUN = \'CPL\'";
            this.vsvJundalGubun.QueryStarting += new System.ComponentModel.CancelEventHandler(this.vsvJundalGubun_QueryStarting);
            // 
            // singleLayoutItem2
            // 
            this.singleLayoutItem2.BindControl = this.dbxJundalGubunName;
            this.singleLayoutItem2.DataName = "dbxJundalGubunName";
            // 
            // CPL0111U00
            // 
            this.AutoCheckInputLayoutChanged = true;
            this.Controls.Add(this.xPanel1);
            this.Name = "CPL0111U00";
            resources.ApplyResources(this, "$this");
            this.xPanel1.ResumeLayout(false);
            this.xPanel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdComment)).EndInit();
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
			base.OnLoad (e);
            this.grdComment.SavePerformer = new XSavePerformer(this);
			this.CurrMQLayout = this.grdComment;
			this.fbxJundalGubun.Focus();
		}
		#endregion

		

		#region vsvJundalGubun_PreServiceCall
		private void vsvJundalGubun_PreServiceCall(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
		}
		#endregion
		

		#region btnList_ButtonClick
		private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			switch ( e.Func )
			{
				case FunctionType.Insert:
					e.IsBaseCall = false;
					if ( this.fbxJundalGubun.GetDataValue().Length == 0 && this.rbxJundalGubun.Checked == true )
					{
						string msg = Resources.MSG001_MSG;
						XMessageBox.Show(msg);
						return;
					}
					this.grdComment.InsertRow();
					break;

                case FunctionType.Update:
                    e.IsBaseCall = false;

                    if (this.grdComment.SaveLayout())
                    {
                        XMessageBox.Show(Resources.MSG002_MSG, Resources.MSG002_CAP, MessageBoxIcon.Information);
                    }
                    else
                    {
                        XMessageBox.Show(Resources.MSG003_MSG, Resources.MSG003_CAP, MessageBoxIcon.Error);                    
                    }

                    break;

				default:
					break;
			}
		}
		#endregion

		private void grdComment_GridColumnChanged(object sender, IHIS.Framework.GridColumnChangedEventArgs e)
		{
			DataRowState rowState = this.grdComment.LayoutTable.Rows[this.grdComment.CurrentRowNumber].RowState;
			// 입력 버튼이 클릭 되었을 때만 체크
			if ( rowState == DataRowState.Added )
			{
				// 입력된 셀이 코드타입 컬럼이라면,
				if ( e.ColName == "code" )
				{
					// 만약 마스터테이블에 존재한다면, 'Y'를 그렇지않으면, 'N'을 리턴
                    this.dsvDup.SetBindVarValue("f_code", e.ChangeValue.ToString());

					this.dsvDup.QueryLayout();
					if ( this.dsvDup.GetItemValue("dup_yn").ToString() == "Y" )
					{
						string msg = Resources.MSG004_MSG;
						XMessageBox.Show( this.grdComment.GetItemString(this.grdComment.CurrentRowNumber,"code")  +
							msg,Resources.MSG004_CAP, MessageBoxButtons.OK );
						e.Cancel = true;
					}
				}
			}
		}

        private void dsvDup_QueryStarting(object sender, CancelEventArgs e)
        {
            this.dsvDup.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);

            if (rbxJundalGubun.Checked == true)
                this.dsvDup.SetBindVarValue("f_jundal_gubun", fbxJundalGubun.GetDataValue().ToString());
            else
                this.dsvDup.SetBindVarValue("f_jundal_gubun", "PA");

        }
        private void grdComment_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdComment.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);

            if (rbxJundalGubun.Checked == true)
                this.grdComment.SetBindVarValue("f_jundal_gubun", fbxJundalGubun.GetDataValue().ToString());
            else
                this.grdComment.SetBindVarValue("f_jundal_gubun", "PA");
        }

		private void rbxJundalGubun_CheckedChanged(object sender, System.EventArgs e)
		{
            this.grdComment.QueryLayout(false);
		}

		private void rbxPa_CheckedChanged(object sender, System.EventArgs e)
		{
			this.fbxJundalGubun.SetDataValue("");
			this.dbxJundalGubunName.SetDataValue("");
		}

		private void fbxJundalGubun_Enter(object sender, System.EventArgs e)
		{
			if ( this.rbxJundalGubun.Checked == false )
				this.rbxJundalGubun.Checked = true;
		}

        private void grdComment_PreSaveLayout(object sender, GridRecordEventArgs e)
        {
            if (e.RowState == DataRowState.Added)
            {
                if (rbxJundalGubun.Checked == true)
                    this.grdComment.SetItemValue(e.RowNumber, "jundal_gubun", this.fbxJundalGubun.GetDataValue());
                else
                    this.grdComment.SetItemValue(e.RowNumber, "jundal_gubun", "PA");
            }

        }

        private class XSavePerformer : ISavePerformer
        {
            CPL0111U00 parent;

            public XSavePerformer(CPL0111U00 parent)
            {
                this.parent = parent;
            }

            public bool Execute(char callerID, RowDataItem item)
            {
                string cmdText = "";

                item.BindVarList.Add("q_user_id", UserInfo.UserID);
                item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);

                switch (item.RowState)
                { 
                    case DataRowState.Added:
                        cmdText = @"INSERT INTO CPL0111 
                                         ( SYS_DATE             , SYS_ID        
                                         , UPD_DATE             , UPD_ID        , HOSP_CODE
                                         , JUNDAL_GUBUN         , CODE   
                                         , NOTE                 , NOTE_RE       ) 
                                    VALUES 
                                         ( SYSDATE              , :q_user_id
                                         , SYSDATE              , :q_user_id    , :f_hosp_code
                                         , :f_jundal_gubun      , :f_code
                                         , :f_note              , :f_note_re    )";

                        break;

                    case DataRowState.Modified:
                        cmdText = @"UPDATE CPL0111
                                       SET UPD_ID          = :q_user_id
                                         , UPD_DATE        = SYSDATE
                                         , NOTE            = :f_note   
                                         , NOTE_RE         = :f_note_re                           
                                     WHERE HOSP_CODE       = :f_hosp_code
                                       AND JUNDAL_GUBUN    = :f_jundal_gubun
                                       AND CODE            = :f_code";

                        break;

                    case DataRowState.Deleted:
                        cmdText = @"DELETE CPL0111
                                     WHERE HOSP_CODE    = :f_hosp_code
                                       AND JUNDAL_GUBUN = :f_jundal_gubun
                                       AND CODE         = :f_code";

                        break;
                }

                return Service.ExecuteNonQuery(cmdText, item.BindVarList);

            }
        }

        private void fwkJundalGubun_QueryStarting(object sender, CancelEventArgs e)
        {
            this.fwkJundalGubun.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
        }

        private void fbxJundalGubun_DataValidating(object sender, DataValidatingEventArgs e)
        {
            if (e.DataValue == "")
                return;

            this.vsvJundalGubun.QueryLayout();
            if (vsvJundalGubun.GetItemValue("dbxJundalGubunName").ToString() == "")
            {
                XMessageBox.Show(Resources.MSG005_MSG,Resources.MSG005_CAP, MessageBoxIcon.Warning);
                e.Cancel = true;
                return;
            }
            this.grdComment.QueryLayout(false);

        }

        private void vsvJundalGubun_QueryStarting(object sender, CancelEventArgs e)
        {
            this.vsvJundalGubun.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.vsvJundalGubun.SetBindVarValue("f_code", this.fbxJundalGubun.GetDataValue());
        }


	}
}

