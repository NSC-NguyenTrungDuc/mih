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

namespace IHIS.NURI
{
	/// <summary>
	/// NUR0401U00에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class NUR0401U00 : IHIS.Framework.XScreen
	{
        #region [자동 생성 코드]

        #region 컨트롤 변수
        private IHIS.Framework.XPanel xPanel2;
		private IHIS.Framework.XButtonList xButtonList1;
		private IHIS.Framework.XMstGrid grdNUR0401;
		private IHIS.Framework.XEditGridCell xEditGridCell1;
		private IHIS.Framework.XEditGridCell xEditGridCell2;
		private IHIS.Framework.XEditGridCell xEditGridCell3;
		private IHIS.Framework.XEditGridCell xEditGridCell4;
        private IHIS.Framework.XEditGridCell xEditGridCell5;
		private IHIS.Framework.XTreeView tvwNur_plan_bunryu;
		private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel1;
        private MultiLayout layNur_plan_bunryu;
        private MultiLayoutItem multiLayoutItem1;
        private MultiLayoutItem multiLayoutItem2;
        private MultiLayoutItem multiLayoutItem5;
        private MultiLayoutItem multiLayoutItem6;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion

		#region 생성자
		public NUR0401U00()
		{
			// 이 호출은 Windows Form 디자이너에 필요합니다.
			InitializeComponent();
		}
		#endregion

		#region 소멸자
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
		#endregion

		#region 디자인 코드
		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다.
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NUR0401U00));
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.xButtonList1 = new IHIS.Framework.XButtonList();
            this.grdNUR0401 = new IHIS.Framework.XMstGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.tvwNur_plan_bunryu = new IHIS.Framework.XTreeView();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel1 = new System.Windows.Forms.Panel();
            this.layNur_plan_bunryu = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem5 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem6 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2 = new IHIS.Framework.MultiLayoutItem();
            this.xPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdNUR0401)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layNur_plan_bunryu)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "");
            this.ImageList.Images.SetKeyName(1, "");
            // 
            // xPanel2
            // 
            this.xPanel2.Controls.Add(this.xButtonList1);
            this.xPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.xPanel2.DrawBorder = true;
            this.xPanel2.Location = new System.Drawing.Point(0, 558);
            this.xPanel2.Name = "xPanel2";
            this.xPanel2.Size = new System.Drawing.Size(995, 32);
            this.xPanel2.TabIndex = 1;
            // 
            // xButtonList1
            // 
            this.xButtonList1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.xButtonList1.Dock = System.Windows.Forms.DockStyle.Right;
            this.xButtonList1.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xButtonList1.IsVisibleReset = false;
            this.xButtonList1.Location = new System.Drawing.Point(587, 0);
            this.xButtonList1.Name = "xButtonList1";
            this.xButtonList1.PerformerType = IHIS.Framework.FunctionPerformerType.Entry;
            this.xButtonList1.Size = new System.Drawing.Size(406, 30);
            this.xButtonList1.TabIndex = 0;
            this.xButtonList1.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.xButtonList1_ButtonClick);
            // 
            // grdNUR0401
            // 
            this.grdNUR0401.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdNUR0401.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5});
            this.grdNUR0401.ColPerLine = 4;
            this.grdNUR0401.ColResizable = true;
            this.grdNUR0401.Cols = 5;
            this.grdNUR0401.FixedCols = 1;
            this.grdNUR0401.FixedRows = 1;
            this.grdNUR0401.FocusColumnName = "nur_plan_jin";
            this.grdNUR0401.HeaderHeights.Add(38);
            this.grdNUR0401.Location = new System.Drawing.Point(4, 4);
            this.grdNUR0401.Name = "grdNUR0401";
            this.grdNUR0401.QuerySQL = resources.GetString("grdNUR0401.QuerySQL");
            this.grdNUR0401.RowHeaderVisible = true;
            this.grdNUR0401.Rows = 2;
            this.grdNUR0401.Size = new System.Drawing.Size(633, 548);
            this.grdNUR0401.TabIndex = 0;
            this.grdNUR0401.GiveFeedback += new System.Windows.Forms.GiveFeedbackEventHandler(this.grdNUR0401_GiveFeedback);
            this.grdNUR0401.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdNUR0401_GridColumnChanged);
            this.grdNUR0401.DragEnter += new System.Windows.Forms.DragEventHandler(this.grdNUR0401_DragEnter);
            this.grdNUR0401.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdNUR0401_MouseDown);
            this.grdNUR0401.DragDrop += new System.Windows.Forms.DragEventHandler(this.grdNUR0401_DragDrop);
            this.grdNUR0401.SaveEnd += new IHIS.Framework.SaveEndEventHandler(this.grdNUR0401_SaveEnd);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellLen = 4;
            this.xEditGridCell1.CellName = "nur_plan_jin";
            this.xEditGridCell1.CellWidth = 42;
            this.xEditGridCell1.Col = 1;
            this.xEditGridCell1.HeaderText = "診断\r\nコード";
            this.xEditGridCell1.ImeMode = IHIS.Framework.ColumnImeMode.EngUpper;
            this.xEditGridCell1.IsNotNull = true;
            this.xEditGridCell1.IsUpdatable = false;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellLen = 200;
            this.xEditGridCell2.CellName = "nur_plan_jinname";
            this.xEditGridCell2.CellWidth = 481;
            this.xEditGridCell2.Col = 2;
            this.xEditGridCell2.HeaderText = "診断コード名";
            this.xEditGridCell2.ImeMode = IHIS.Framework.ColumnImeMode.Hiragana;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellLen = 2;
            this.xEditGridCell3.CellName = "nur_plan_bunryu";
            this.xEditGridCell3.CellWidth = 96;
            this.xEditGridCell3.Col = -1;
            this.xEditGridCell3.HeaderText = "診断分類";
            this.xEditGridCell3.IsVisible = false;
            this.xEditGridCell3.Row = -1;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellLen = 1;
            this.xEditGridCell4.CellName = "vald";
            this.xEditGridCell4.CellWidth = 30;
            this.xEditGridCell4.Col = 3;
            this.xEditGridCell4.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell4.HeaderText = "有\r\n効";
            this.xEditGridCell4.InitValue = "Y";
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellLen = 2;
            this.xEditGridCell5.CellName = "sort_key";
            this.xEditGridCell5.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell5.CellWidth = 35;
            this.xEditGridCell5.Col = 4;
            this.xEditGridCell5.HeaderText = "順番";
            this.xEditGridCell5.InitValue = "99";
            this.xEditGridCell5.IsReadOnly = true;
            this.xEditGridCell5.MaxinumCipher = 3;
            // 
            // tvwNur_plan_bunryu
            // 
            this.tvwNur_plan_bunryu.Dock = System.Windows.Forms.DockStyle.Left;
            this.tvwNur_plan_bunryu.HideSelection = false;
            this.tvwNur_plan_bunryu.ImageIndex = 0;
            this.tvwNur_plan_bunryu.ImageList = this.ImageList;
            this.tvwNur_plan_bunryu.Location = new System.Drawing.Point(0, 0);
            this.tvwNur_plan_bunryu.Name = "tvwNur_plan_bunryu";
            this.tvwNur_plan_bunryu.SelectedImageIndex = 1;
            this.tvwNur_plan_bunryu.Size = new System.Drawing.Size(350, 558);
            this.tvwNur_plan_bunryu.TabIndex = 2;
            this.tvwNur_plan_bunryu.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvwNur_plan_bunryu_AfterSelect);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(350, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 558);
            this.splitter1.TabIndex = 3;
            this.splitter1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.grdNUR0401);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(353, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(642, 558);
            this.panel1.TabIndex = 4;
            // 
            // layNur_plan_bunryu
            // 
            this.layNur_plan_bunryu.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem5,
            this.multiLayoutItem6});
            this.layNur_plan_bunryu.QuerySQL = "SELECT CODE      NUR_PLAN_BUNRYU,\r\n       CODE_NAME NUR_PLAN_BUNRYU_NAME\r\n  FROM " +
                "NUR0102\r\n WHERE HOSP_CODE = :f_hosp_code \r\n   AND CODE_TYPE = \'NUR_PLAN_BUNRYU\'\r" +
                "\n ORDER BY NVL(SORT_KEY, 99), CODE\r\n";
            // 
            // multiLayoutItem5
            // 
            this.multiLayoutItem5.DataName = "code";
            // 
            // multiLayoutItem6
            // 
            this.multiLayoutItem6.DataName = "code_name";
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "CODE";
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "CODE_NAME";
            // 
            // NUR0401U00
            // 
            this.AutoCheckInputLayoutChanged = true;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.tvwNur_plan_bunryu);
            this.Controls.Add(this.xPanel2);
            this.Name = "NUR0401U00";
            this.Size = new System.Drawing.Size(995, 590);
            this.xPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdNUR0401)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layNur_plan_bunryu)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

        #endregion 


        #region [APL 초기설정 관련 코드]

        #region OnLoad 이벤트
        private string mHospCode = "";
        protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);

            this.mHospCode = EnvironInfo.HospCode;
            // 그리드 SavePerformer 설정
            grdNUR0401.SavePerformer = new XSavePerformer(this);
            
            PostCallHelper.PostCall(new PostMethod(PostLoad));
        }
        #endregion

        #region PostLoad 이벤트
        private void PostLoad()
        {
            this.CurrMSLayout = this.grdNUR0401;
            this.CurrMQLayout = this.grdNUR0401;

            this.layNur_plan_bunryu.SetBindVarValue("f_hosp_code", this.mHospCode);
            if (this.layNur_plan_bunryu.QueryLayout(true))
            {
                ShowNur_plan_bunryu();
            }
            else
            {
                XMessageBox.Show(Service.ErrFullMsg);
                return;
            }
        }
        #endregion

        #endregion

        #region [메세지 처리 코드]

        /// <summary>
        /// 각종 메세지를 표시한다.
        /// </summary>
        /// <param name="separation">구분</param>
        /// <param name="code">코드</param>
        private void ShowMessage(string separation, string code)
        {
            string msg = string.Empty;
            string cpt = string.Empty;

            switch (separation)
            {
                case "NurPlanJinnameNull":
                    msg = "診断コード名を入力してください。";
                    cpt = "";
                    XMessageBox.Show(msg, cpt);
                    break;

                case "NurPlanBunryuNull":
                    msg = "診断分類が有効ではありません。ご確認ください。";
                    cpt = "";
                    XMessageBox.Show(msg, cpt);
                    break;

                case "NurPlanJinDup":
                    msg = String.Format("既に登録されている診断コードです。[{0}]\r\nご確認ください。", code);
                    cpt = "";
                    XMessageBox.Show(msg, cpt);
                    break;

                case "ChildData":
                    msg = String.Format("[{0}]診断コードの詳細データがあります。ご確認ください。", code);
                    cpt = "";
                    XMessageBox.Show(msg, cpt);
                    break;

                case "SaveSuccess":
                    msg = "保存が完了しました。";
                    SetMsg(msg);
                    break;

                case "SaveFail":
                    msg = String.Format("保存に失敗しました。\n[{0}]", Service.ErrFullMsg);
                    cpt = "エラー";
                    XMessageBox.Show(msg, cpt);
                    break;

                default:
                    break;
            }
        }

        #endregion

        #region [코드명 취득 코드]

        /// <summary>
        /// 해당 코드에 대한 코드명을 취득한다.
        /// </summary>
        /// <param name="codeMode">코드구분</param>
        /// <param name="code">코드Value</param>
        /// <returns>
        /// 코드명 : 해당데이타 코드명
        /// 공백   : 해당데이타 없음
        /// </returns>
        private string GetCodeName(string codeMode, string code)
        {
            string codeName = string.Empty;
            string cmdText = string.Empty;
            object retVal = null;
            BindVarCollection bindVars = new BindVarCollection();

            if (code.Trim() == "")
            {
                return codeName;
            }

            switch (codeMode)
            {
                case "nur_plan_jin":
                    cmdText = @"SELECT A.NUR_PLAN_JINNAME 
                                  FROM NUR0401 A 
                                 WHERE A.HOSP_CODE    = :f_hosp_code 
                                   AND A.NUR_PLAN_JIN = :f_code ";

                    bindVars.Add("f_hosp_code", this.mHospCode);
                    bindVars.Add("f_code", code);
                    
                    retVal = Service.ExecuteScalar(cmdText, bindVars);

                    if (Service.ErrCode == 0)
                    {
                        if (retVal == null || retVal.ToString().Equals(""))
                            codeName = "";
                        else
                            codeName = retVal.ToString();
                    }
                    else
                    {
                        codeName = "";
                    }
                    break;

                default:
                    break;
            }

            return codeName;
        }

        #endregion

        #region [진단 데이타 체크 코드]

        #region 진단 데이타 유효성 검사
        /// <summary>
        /// 저장 전 그리드 데이타의 유효성 검사를 실행한다.
        /// </summary>
        private bool Grid_Validating()
        {
            AcceptData();

            //grdNUR0401
            for (int rowIndex = 0; rowIndex < grdNUR0401.RowCount; rowIndex++)
            {
                if (grdNUR0401.LayoutTable.Rows[rowIndex].RowState == DataRowState.Added)
                {
                    //Key값이 없으면 삭제처리
                    if (grdNUR0401.GetItemString(rowIndex, "nur_plan_jin").Trim() == "")
                    {
                        grdNUR0401.DeleteRow(rowIndex);
                        rowIndex = rowIndex - 1;
                        continue;
                    }
                }

                if (grdNUR0401.GetItemString(rowIndex, "nur_plan_jinname").Trim() == "")
                {
                    ShowMessage("NurPlanJinnameNull", "");
                    grdNUR0401.SetFocusToItem(rowIndex, "nur_plan_jinname", true);
                    return false;
                }

                if (grdNUR0401.GetItemString(rowIndex, "nur_plan_bunryu").Trim() == "")
                {
                    ShowMessage("NurPlanBunryuNull", "");
                    grdNUR0401.SetFocusToItem(rowIndex, "");
                    return false;
                }
            }

            SetSequence();

            return true;
        }
        #endregion

        #region 진단 데이타 중복 체크 
        /// <summary>
        /// 진단 데이타에 대한 중복 여부를 체크한다.
        /// </summary>
        private void grdNUR0401_GridColumnChanged(object sender, IHIS.Framework.GridColumnChangedEventArgs e)
        {
            e.Cancel = false;

            switch (e.ColName)
            {
                case "nur_plan_jin":
                    if (e.ChangeValue.ToString().Trim() == "") break;

                    //중복 Check
                    for (int i = 0; i < grdNUR0401.RowCount; i++)
                    {
                        if (i != e.RowNumber)
                        {
                            if (grdNUR0401.GetItemString(i, e.ColName).Trim() == e.ChangeValue.ToString().Trim())
                            {
                                ShowMessage("NurPlanJinDup", e.ChangeValue.ToString());

                                e.Cancel = true;
                                break;
                            }
                        }
                    }

                    if (e.Cancel) break;

                    // Delete Table Check
                    // 현재 화면상에도 없으면서 DeleteTable에 존재하면 Not 중복
                    bool deleted = false;

                    if (grdNUR0401.DeletedRowTable != null)
                    {
                        foreach (DataRow row in grdNUR0401.DeletedRowTable.Rows)
                        {
                            if (row[e.ColName].ToString() == e.ChangeValue.ToString())
                            {
                                deleted = true;
                                break;
                            }
                        }
                    }

                    if (deleted) break;

                    string checkName = this.GetCodeName(e.ColName, e.ChangeValue.ToString());
                    if (checkName != "")
                    {
                        ShowMessage("NurPlanJinDup", e.ChangeValue.ToString());

                        e.Cancel = true;
                    }

                    break;

                default:
                    break;
            }
        }
        #endregion

        #region 진단 데이타 디테일 체크
        /// <summary>
        /// 진단 데이타에 대한 디테일 데이타 여부를 체크한다.
        /// </summary>
        /// <param name="aNur_plan_jin">체크코드</param>
        /// <returns>
        /// True :디테일 데이타 유
        /// False:디테일 데이타 무
        /// </returns>
        private bool CheckDetail(string aNur_plan_jin)
        {
            bool check = false;
            string cmdText = string.Empty;
            object retVal = null;
            BindVarCollection bindVars = new BindVarCollection();

            cmdText = @"SELECT 'Y' 
                          FROM NUR0402 A 
                         WHERE A.HOSP_CODE    = :f_hosp_code 
                           AND A.NUR_PLAN_JIN = :f_aNur_plan_jin
                           AND ROWNUM = 1 ";

            bindVars.Add("f_hosp_code", this.mHospCode);
            bindVars.Add("f_aNur_plan_jin", aNur_plan_jin);

            retVal = Service.ExecuteScalar(cmdText, bindVars);

            if (Service.ErrCode == 0)
            {
                if (retVal != null && retVal.ToString().Equals("Y"))
                {
                    check = true;
                }
            }

            return check;
        }
        #endregion

        #region 그리드 필수입력필드 체크
        /// <summary>
        /// 그리드에 입력한 로우 중, 필수입력(Not Null)필드를 입력하지 않은 컬럼를 검색한다.
        /// </summary>
        /// <remarks>
        /// Grid 컬럼 속성이 Not Null과 Visible, Not ReadOnly 항목으로 체크한다.
        /// </remarks>
        /// <param name="aGrd">XEditGrid</param>
        /// <returns>
        /// 검색결과 유:해당 컬럼
        /// 검색결과 무:해당 컬럼의 RowNumber가 [0]이하로 설정 후 리턴
        /// </returns>
        private DataGridCell GetEmptyNewRow(object aGrd)
        {
            DataGridCell celReturn = new DataGridCell(-1, -1);

            if (aGrd == null) return celReturn;

            XEditGrid grdChk = null;

            try
            {
                grdChk = (XEditGrid)aGrd;
            }
            catch
            {
                return celReturn;
            }

            foreach (XEditGridCell cell in grdChk.CellInfos)
            {
                // NotNull Check
                if (cell.IsNotNull && cell.IsVisible && !cell.IsReadOnly)
                {
                    for (int rowIndex = 0; rowIndex < grdChk.RowCount; rowIndex++)
                    {
                        if (grdChk.GetRowState(rowIndex) == DataRowState.Added && TypeCheck.IsNull(grdChk.GetItemString(rowIndex, cell.CellName)))
                        {
                            // cell.Col은 컬럼의 위치이기 때문에 인덱스 접근을 위해 -1을 연산함.
                            celReturn.ColumnNumber = cell.Col - 1;
                            celReturn.RowNumber = rowIndex;
                            break;
                        }
                    }

                    if (celReturn.RowNumber < 0)
                        continue;
                    else
                        break;
                }
            }

            return celReturn;
        }
        #endregion

        #endregion

        #region [입력/삭제/저장 처리 관련 코드]

        private void xButtonList1_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Insert:
                    e.IsBaseCall = false;

                    DataGridCell chkCell = GetEmptyNewRow(this.CurrMSLayout);

                    if (chkCell.RowNumber < 0)
                    {
                        int currentRow = -1;

                        if (this.CurrMSLayout == grdNUR0401)
                        {
                            if (tvwNur_plan_bunryu.SelectedNode == null)
                            {
                                return;
                            }

                            currentRow = grdNUR0401.InsertRow();
                            grdNUR0401.SetItemValue(currentRow, "nur_plan_bunryu", this.tvwNur_plan_bunryu.SelectedNode.Tag.ToString());
                            SetSequence();
                        }
                    }
                    else
                        ((XEditGrid)this.CurrMSLayout).SetFocusToItem(chkCell.RowNumber, chkCell.ColumnNumber);

                    break;

                case FunctionType.Delete:
                    if (grdNUR0401.CurrentRowNumber < 0) return;

                    e.IsBaseCall = false;

                    if (grdNUR0401.GetRowState(grdNUR0401.CurrentRowNumber) != DataRowState.Added)
                    {
                        string nur_plan_jin = grdNUR0401.GetItemString(grdNUR0401.CurrentRowNumber, "nur_plan_jin");
                        if (CheckDetail(nur_plan_jin))
                        {
                            grdNUR0401.SetItemValue(grdNUR0401.CurrentRowNumber, "vald", "N");
                            return;
                        }
                    }

                    grdNUR0401.DeleteRow(grdNUR0401.CurrentRowNumber);

                    SetSequence();

                    break;

                case FunctionType.Update:
                    if (Grid_Validating())
                    {
                        grdNUR0401.SaveLayout();
                    }
                    break;

                default:
                    break;
            }
        }

        #endregion

        #region [간호계획분류 데이타 취득 및 설정 코드]

        /// <summary>
        /// 간호계획분류 데이타 취득 후 트리뷰에 설정한다.
        /// </summary>
        private void ShowNur_plan_bunryu()
        {
            tvwNur_plan_bunryu.Nodes.Clear();

            if (layNur_plan_bunryu.RowCount < 1) return;

            TreeNode node;

            foreach (DataRow row in layNur_plan_bunryu.LayoutTable.Rows)
            {
                node = new TreeNode(row["code_name"].ToString());
                node.Tag = row["code"].ToString();
                tvwNur_plan_bunryu.Nodes.Add(node);
            }

            tvwNur_plan_bunryu.SelectedNode = tvwNur_plan_bunryu.Nodes[0];
        }

        #endregion

        #region [간호계획분류에 따른 진단 데이타 취득 및 설정 코드]

        /// <summary>
        /// 간호계획분류에 해당하는 진단 데이타를 취득 후 그리드에 설정한다.
        /// </summary>
        private void tvwNur_plan_bunryu_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
            if (tvwNur_plan_bunryu.SelectedNode == null)
            {
                return;
            }

			try
			{
				Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;

                grdNUR0401.SetBindVarValue("f_hosp_code", this.mHospCode);
                grdNUR0401.SetBindVarValue("f_nur_plan_bunryu", tvwNur_plan_bunryu.SelectedNode.Tag.ToString());
                grdNUR0401.QueryLayout(false);
			}
			finally
			{					
				Cursor.Current = System.Windows.Forms.Cursors.Default;
			}
		}

		#endregion

        #region [그리드 로우 정렬순서 설정 및 변경 코드]

        #region 그리드 로우 정렬순서 설정
        /// <summary>
        /// 그리드의 로우 정렬순서를 설정한다.
        /// </summary>
		private void SetSequence()
		{
			int sort_key = -1;

			for(int i = 0; i < grdNUR0401.RowCount; i++)
			{
                sort_key = i + 1;

				if(grdNUR0401.GetItemString(i, "sort_key") != sort_key.ToString())
                    grdNUR0401.SetItemValue(i, "sort_key", sort_key);
			}
        }
        #endregion

        #region 마우스 드래그&드롭을 이용한 정렬순서 변경
        private void grdNUR0401_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (grdNUR0401.GetHitRowNumber(e.Y) < 0) return;

            int curRowIndex = grdNUR0401.GetHitRowNumber(e.Y);

            string dragInfo = "[" + grdNUR0401.GetItemString(curRowIndex, "nur_plan_jin") + "]" + grdNUR0401.GetItemString(curRowIndex, "nur_plan_jinname");
            DragHelper.CreateDragCursor(grdNUR0401, dragInfo, this.Font);
            grdNUR0401.DoDragDrop(curRowIndex.ToString(), DragDropEffects.Move);
        }

        private void grdNUR0401_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;  // Move 표시			
        }

        private void grdNUR0401_GiveFeedback(object sender, System.Windows.Forms.GiveFeedbackEventArgs e)
        {
            e.UseDefaultCursors = false;

            // Drag시에 Cursor 바꿈
            if ((e.Effect & DragDropEffects.Move) == DragDropEffects.Move)
            {
                Cursor.Current = DragHelper.DragCursor;
            }
        }

        private void grdNUR0401_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            // Client Point
            int fromRowNum = int.Parse(e.Data.GetData("System.String").ToString());
            Point clientPoint = grdNUR0401.PointToClient(new Point(e.X, e.Y));

            int toRowNum = grdNUR0401.GetHitRowNumber(clientPoint.Y);

            if (toRowNum == fromRowNum || toRowNum < 0)
            {
                // Edit상태로 만든다.
                grdNUR0401.SetFocusToItem(toRowNum, grdNUR0401.CurrentColNumber);
                return;
            }

            DataRow backRow = grdNUR0401.LayoutTable.NewRow();

            foreach (DataColumn col in grdNUR0401.LayoutTable.Columns)
            {
                backRow[col.ColumnName] = grdNUR0401.GetItemString(toRowNum, col.ColumnName);
                grdNUR0401.SetItemValue(toRowNum, col.ColumnName, grdNUR0401.GetItemString(fromRowNum, col.ColumnName));
                grdNUR0401.SetItemValue(fromRowNum, col.ColumnName, backRow[col.ColumnName]);
            }

            grdNUR0401.SetFocusToItem(toRowNum, grdNUR0401.CurrentColNumber);

            SetSequence();
        }
        #endregion
        
        #endregion

        #region [데이타 저장 완료 메시지 설정 코드]

        // 지정 에러메세지 인지 확인하는 플레그
        private bool appointmentError = false;

        /// <summary>
        /// 그리드의 데이타 저장 완료 후, 메세지를 표시한다.
        /// </summary>
        private void grdNUR0401_SaveEnd(object sender, SaveEndEventArgs e)
        {
            if (e.IsSuccess)
            {
                ShowMessage("SaveSuccess", "");
            }
            else
            {
                if (!appointmentError)
                {
                    this.ShowMessage("SaveFail", "");
                }
                appointmentError = false;
            }
        }

        #endregion
     
  
        #region [XSavePerformer]

        private class XSavePerformer : IHIS.Framework.ISavePerformer
        {
            private NUR0401U00 parent = null;
            public XSavePerformer(NUR0401U00 parent)
            {
                this.parent = parent;
            }
            public bool Execute(char callerID, RowDataItem item)
            {
                string cmdText = "";
                object retVal = null;

                item.BindVarList.Add("q_user_id", UserInfo.UserID);
                item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);

                switch (item.RowState)
                {
                    case DataRowState.Added:
                        cmdText = @"SELECT 'Y'
                                      FROM NUR0401 
                                     WHERE HOSP_CODE    = :f_hosp_code
                                       AND NUR_PLAN_JIN = :f_nur_plan_jin
                                       AND ROWNUM = 1";

                        retVal = Service.ExecuteScalar(cmdText, item.BindVarList);

                        if (Service.ErrCode == 0)
                        {
                            if (retVal != null && retVal.ToString().Equals("Y"))
                            {
                                parent.ShowMessage("NurPlanJinDup", item.BindVarList["f_nur_plan_jin"].VarValue);
                                parent.appointmentError = true;
                                return false;
                            }
                        }
                        else
                        {
                            return false;
                        }

                        cmdText = @"INSERT INTO NUR0401 (SYS_DATE, 
                                                         SYS_ID, 
                                                         UPD_DATE,
                                                         UPD_ID,
                                                         HOSP_CODE, 
                                                         NUR_PLAN_JIN,
                                                         NUR_PLAN_JINNAME, 
                                                         NUR_PLAN_BUNRYU, 
                                                         VALD, 
                                                         SORT_KEY)
                                                VALUES  (SYSDATE, 
                                                         :q_user_id, 
                                                         SYSDATE,
                                                         :q_user_id, 
                                                         :f_hosp_code, 
                                                         :f_nur_plan_jin, 
                                                         :f_nur_plan_jinname, 
                                                         :f_nur_plan_bunryu, 
                                                         'Y', 
                                                         :f_sort_key )";
                        break;

                    case DataRowState.Modified:
                        cmdText = @"UPDATE NUR0401
                                       SET UPD_ID           = :q_user_id,
                                           UPD_DATE         = SYSDATE,
                                           NUR_PLAN_JINNAME = :f_nur_plan_jinname,
                                           NUR_PLAN_BUNRYU  = :f_nur_plan_bunryu ,
                                           VALD             = :f_vald, 
                                           SORT_KEY         = :f_sort_key        
                                     WHERE HOSP_CODE        = :f_hosp_code
                                       AND NUR_PLAN_JIN     = :f_nur_plan_jin";
                        break;

                    case DataRowState.Deleted:
                        cmdText = @"SELECT 'Y'
                                      FROM NUR0402 
                                     WHERE HOSP_CODE    = :f_hosp_code
                                       AND NUR_PLAN_JIN = :f_nur_plan_jin
                                       AND ROWNUM = 1";

                        retVal = Service.ExecuteScalar(cmdText, item.BindVarList);

                        if (Service.ErrCode == 0)
                        {
                            if (retVal != null && retVal.ToString().Equals("Y"))
                            {
                                parent.ShowMessage("ChildData", item.BindVarList["f_nur_plan_jin"].VarValue);
                                parent.appointmentError = true;
                                return false;
                            }
                        }
                        else
                        {
                            return false;
                        }

                        cmdText = @"DELETE NUR0401 
                                     WHERE HOSP_CODE    = :f_hosp_code
                                       AND NUR_PLAN_JIN = :f_nur_plan_jin";
                        break;
                }

                return Service.ExecuteNonQuery(cmdText, item.BindVarList);
            }
        }
        #endregion
	}
}