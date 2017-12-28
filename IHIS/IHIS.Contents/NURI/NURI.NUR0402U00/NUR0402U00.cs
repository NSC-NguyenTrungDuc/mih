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
	/// NUR0402U00에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class NUR0402U00 : IHIS.Framework.XScreen
	{
        #region [자동 생성 코드]

        #region 컨트롤 변수
        private IHIS.Framework.XPanel xPanel2;
		private IHIS.Framework.XButtonList xButtonList1;
		private IHIS.Framework.XEditGrid grdNUR0402;
		private IHIS.Framework.XEditGridCell xEditGridCell6;
		private IHIS.Framework.XEditGridCell xEditGridCell7;
		private IHIS.Framework.XEditGridCell xEditGridCell8;
		private IHIS.Framework.XEditGridCell xEditGridCell9;
		private IHIS.Framework.XEditGridCell xEditGridCell10;
        private System.Windows.Forms.Splitter slpMid;
		private System.Windows.Forms.Splitter splitter1;
		private IHIS.Framework.XPanel xPanel1;
        private IHIS.Framework.XTreeView tvwNur_plan_bunryu;
        private MultiLayout layNUR0401;
        private MultiLayoutItem multiLayoutItem1;
        private MultiLayoutItem multiLayoutItem2;
        private MultiLayoutItem multiLayoutItem3;
        private MultiLayoutItem multiLayoutItem4;
        private MultiLayoutItem multiLayoutItem5;
        private MultiLayoutItem multiLayoutItem6;
        private MultiLayoutItem multiLayoutItem7;
        private MultiLayoutItem multiLayoutItem8;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion

		#region 생성자
		public NUR0402U00()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NUR0402U00));
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.xButtonList1 = new IHIS.Framework.XButtonList();
            this.slpMid = new System.Windows.Forms.Splitter();
            this.grdNUR0402 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.tvwNur_plan_bunryu = new IHIS.Framework.XTreeView();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.layNUR0401 = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem5 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem6 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem7 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem8 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem3 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem4 = new IHIS.Framework.MultiLayoutItem();
            this.xPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdNUR0402)).BeginInit();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layNUR0401)).BeginInit();
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
            this.xPanel2.Size = new System.Drawing.Size(990, 32);
            this.xPanel2.TabIndex = 1;
            // 
            // xButtonList1
            // 
            this.xButtonList1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.xButtonList1.Dock = System.Windows.Forms.DockStyle.Right;
            this.xButtonList1.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xButtonList1.IsVisibleReset = false;
            this.xButtonList1.Location = new System.Drawing.Point(582, 0);
            this.xButtonList1.Name = "xButtonList1";
            this.xButtonList1.PerformerType = IHIS.Framework.FunctionPerformerType.Entry;
            this.xButtonList1.Size = new System.Drawing.Size(406, 30);
            this.xButtonList1.TabIndex = 0;
            this.xButtonList1.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.xButtonList1_ButtonClick);
            // 
            // slpMid
            // 
            this.slpMid.Location = new System.Drawing.Point(0, 0);
            this.slpMid.Name = "slpMid";
            this.slpMid.Size = new System.Drawing.Size(3, 558);
            this.slpMid.TabIndex = 3;
            this.slpMid.TabStop = false;
            // 
            // grdNUR0402
            // 
            this.grdNUR0402.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdNUR0402.CallerID = '2';
            this.grdNUR0402.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell6,
            this.xEditGridCell7,
            this.xEditGridCell8,
            this.xEditGridCell9,
            this.xEditGridCell10});
            this.grdNUR0402.ColPerLine = 4;
            this.grdNUR0402.Cols = 5;
            this.grdNUR0402.FixedCols = 1;
            this.grdNUR0402.FixedRows = 1;
            this.grdNUR0402.FocusColumnName = "nur_plan_pro";
            this.grdNUR0402.HeaderHeights.Add(37);
            this.grdNUR0402.Location = new System.Drawing.Point(4, 6);
            this.grdNUR0402.Name = "grdNUR0402";
            this.grdNUR0402.QuerySQL = resources.GetString("grdNUR0402.QuerySQL");
            this.grdNUR0402.RowHeaderVisible = true;
            this.grdNUR0402.Rows = 2;
            this.grdNUR0402.Size = new System.Drawing.Size(594, 550);
            this.grdNUR0402.TabIndex = 0;
            this.grdNUR0402.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdNUR0402_MouseDown);
            this.grdNUR0402.DragDrop += new System.Windows.Forms.DragEventHandler(this.grdNUR0402_DragDrop);
            this.grdNUR0402.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdNUR0402_GridColumnChanged);
            this.grdNUR0402.DragEnter += new System.Windows.Forms.DragEventHandler(this.grdNUR0402_DragEnter);
            this.grdNUR0402.SaveEnd += new IHIS.Framework.SaveEndEventHandler(this.grdNUR0402_SaveEnd);
            this.grdNUR0402.GiveFeedback += new System.Windows.Forms.GiveFeedbackEventHandler(this.grdNUR0402_GiveFeedback);
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellLen = 3;
            this.xEditGridCell6.CellName = "nur_plan_jin";
            this.xEditGridCell6.Col = -1;
            this.xEditGridCell6.HeaderText = "nur_plan_jin";
            this.xEditGridCell6.IsUpdatable = false;
            this.xEditGridCell6.IsVisible = false;
            this.xEditGridCell6.Row = -1;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellLen = 2;
            this.xEditGridCell7.CellName = "nur_plan_pro";
            this.xEditGridCell7.CellWidth = 64;
            this.xEditGridCell7.Col = 1;
            this.xEditGridCell7.HeaderText = "問題リスト\r\nコード";
            this.xEditGridCell7.ImeMode = IHIS.Framework.ColumnImeMode.EngUpper;
            this.xEditGridCell7.IsUpdatable = false;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellLen = 200;
            this.xEditGridCell8.CellName = "nur_plan_proname";
            this.xEditGridCell8.CellWidth = 430;
            this.xEditGridCell8.Col = 2;
            this.xEditGridCell8.HeaderText = "問題リスト名";
            this.xEditGridCell8.ImeMode = IHIS.Framework.ColumnImeMode.Hiragana;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellLen = 1;
            this.xEditGridCell9.CellName = "vald";
            this.xEditGridCell9.CellWidth = 24;
            this.xEditGridCell9.Col = 3;
            this.xEditGridCell9.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell9.HeaderText = "有\r\n効";
            this.xEditGridCell9.InitValue = "Y";
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellLen = 2;
            this.xEditGridCell10.CellName = "sort_key";
            this.xEditGridCell10.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell10.CellWidth = 30;
            this.xEditGridCell10.Col = 4;
            this.xEditGridCell10.HeaderText = "順番";
            this.xEditGridCell10.InitValue = "99";
            this.xEditGridCell10.IsReadOnly = true;
            this.xEditGridCell10.MaxinumCipher = 3;
            // 
            // tvwNur_plan_bunryu
            // 
            this.tvwNur_plan_bunryu.Dock = System.Windows.Forms.DockStyle.Left;
            this.tvwNur_plan_bunryu.HideSelection = false;
            this.tvwNur_plan_bunryu.ImageIndex = 0;
            this.tvwNur_plan_bunryu.ImageList = this.ImageList;
            this.tvwNur_plan_bunryu.Location = new System.Drawing.Point(3, 0);
            this.tvwNur_plan_bunryu.Name = "tvwNur_plan_bunryu";
            this.tvwNur_plan_bunryu.SelectedImageIndex = 1;
            this.tvwNur_plan_bunryu.Size = new System.Drawing.Size(383, 558);
            this.tvwNur_plan_bunryu.TabIndex = 5;
            this.tvwNur_plan_bunryu.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvwNur_plan_bunryu_AfterSelect);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(386, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 558);
            this.splitter1.TabIndex = 6;
            this.splitter1.TabStop = false;
            // 
            // xPanel1
            // 
            this.xPanel1.Controls.Add(this.grdNUR0402);
            this.xPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xPanel1.Location = new System.Drawing.Point(389, 0);
            this.xPanel1.Name = "xPanel1";
            this.xPanel1.Size = new System.Drawing.Size(601, 558);
            this.xPanel1.TabIndex = 7;
            // 
            // layNUR0401
            // 
            this.layNUR0401.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem5,
            this.multiLayoutItem6,
            this.multiLayoutItem7,
            this.multiLayoutItem8});
            this.layNUR0401.QuerySQL = resources.GetString("layNUR0401.QuerySQL");
            // 
            // multiLayoutItem5
            // 
            this.multiLayoutItem5.DataName = "nur_plan_bunryu";
            // 
            // multiLayoutItem6
            // 
            this.multiLayoutItem6.DataName = "nur_plan_bunryu_name";
            // 
            // multiLayoutItem7
            // 
            this.multiLayoutItem7.DataName = "nur_plan_jin";
            // 
            // multiLayoutItem8
            // 
            this.multiLayoutItem8.DataName = "nur_plan_jinname";
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "nur_plan_bunryu";
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "nur_plan_bunryu_name";
            // 
            // multiLayoutItem3
            // 
            this.multiLayoutItem3.DataName = "nur_plan_jin";
            // 
            // multiLayoutItem4
            // 
            this.multiLayoutItem4.DataName = "nur_plan_jinname";
            // 
            // NUR0402U00
            // 
            this.AutoCheckInputLayoutChanged = true;
            this.Controls.Add(this.xPanel1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.tvwNur_plan_bunryu);
            this.Controls.Add(this.slpMid);
            this.Controls.Add(this.xPanel2);
            this.Name = "NUR0402U00";
            this.Size = new System.Drawing.Size(990, 590);
            this.xPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdNUR0402)).EndInit();
            this.xPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layNUR0401)).EndInit();
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

            mHospCode = EnvironInfo.HospCode;
			//panel 경계부분 splitter가 있는 경우 경계부분 panel bordColor처리
			slpMid.BackColor = XColor.XDisplayBoxGradientEndColor.Color;

            grdNUR0402.SavePerformer = new XSavePerformer(this);

			PostCallHelper.PostCall(new PostMethod(PostLoad));
        }
        #endregion

        #region PostLoad 이벤트
        private void PostLoad()
		{			
			//Set Current Grid
            this.CurrMSLayout = this.grdNUR0402;
            this.CurrMQLayout = this.grdNUR0402;

            layNUR0401.SetBindVarValue("f_hosp_code", this.mHospCode);
            layNUR0401.QueryLayout(true);

			ShowNur_plan_bunryu();
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
                case "NurPlanPronameNull":
                    msg = "問題リスト名を入力してください。";
                    cpt = "";
                    XMessageBox.Show(msg, cpt);
                    break;

                case "NurPlanProDup":
                    msg = String.Format("既に登録されている問題リストコードです。[{0}]ご確認ください。", code);
                    cpt = "";
                    XMessageBox.Show(msg, cpt);
                    break;

                case "ChildData":
                    msg = String.Format("[{0}]問題リストコードの詳細データがあります。ご確認ください。", code);
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
        /// 코드명:해당데이타 코드명
        /// 공백  :해당데이타 없음
        /// </returns>
        private string GetCodeName(string codeMode, string code)
        {
            string codeName = "";
            string cmdText = string.Empty;
            object retVal = null;
            BindVarCollection bindVals = new BindVarCollection();

            if (code.Trim() == "") return codeName;

            switch (codeMode)
            {
                case "nur_plan_jin":
                    cmdText = @"SELECT A.NUR_PLAN_JINNAME
                                  FROM NUR0401 A
                                 WHERE A.HOSP_CODE    = :f_hosp_code
                                   AND A.NUR_PLAN_JIN = :f_code";

                    bindVals.Add("f_hosp_code", this.mHospCode);
                    bindVals.Add("f_code", code);

                    retVal = Service.ExecuteScalar(cmdText, bindVals);

                    if (retVal == null || retVal.ToString().Equals(""))
                        codeName = "";
                    else
                        codeName = retVal.ToString();
                    break;

                case "nur_plan_pro":
                    string nur_plan_jin = grdNUR0402.GetItemString(grdNUR0402.CurrentRowNumber, "nur_plan_jin");

                    cmdText = @"SELECT A.NUR_PLAN_PRONAME
                                  FROM NUR0402 A
                                 WHERE A.HOSP_CODE    = :f_hosp_code
                                   AND A.NUR_PLAN_JIN = :f_nur_plan_jin
                                   AND A.NUR_PLAN_PRO = :f_code";

                    bindVals.Add("f_hosp_code", this.mHospCode);
                    bindVals.Add("f_nur_plan_jin", nur_plan_jin);
                    bindVals.Add("f_code", code);

                    retVal = Service.ExecuteScalar(cmdText, bindVals);

                    if (retVal == null || retVal.ToString().Equals(""))
                        codeName = "";
                    else
                        codeName = retVal.ToString();
                    
                    break;

                default:
                    break;
            }

            return codeName;
        }

        #endregion

        #region [문제리스트 데이타 체크 코드]

        #region 문제리스트 유효성 검사
        /// <summary>
        /// 저장 전 문제리스트 데이타의 유효성 검사를 실행한다.
        /// </summary>
        private bool Grid_Validating()
        {
            AcceptData();

            //grdNUR0402
            for (int rowIndex = 0; rowIndex < grdNUR0402.RowCount; rowIndex++)
            {
                if (grdNUR0402.LayoutTable.Rows[rowIndex].RowState == DataRowState.Added)
                {
                    //Key값이 없으면 삭제처리
                    if (grdNUR0402.GetItemString(rowIndex, "nur_plan_pro").Trim() == "")
                    {
                        grdNUR0402.DeleteRow(rowIndex);
                        rowIndex = rowIndex - 1;
                        continue;
                    }
                }

                if (grdNUR0402.GetItemString(rowIndex, "nur_plan_proname").Trim() == "")
                {
                    ShowMessage("NurPlanPronameNull", "");
                    grdNUR0402.SetFocusToItem(rowIndex, "nur_plan_proname");
                    return false;
                }
            }

            SetSequence();

            return true;
        }
        #endregion

        #region 문제리스트 데이타 디테일 데이타 체크
        /// <summary>
        /// 문제리스트 데이타에 대한 디테일 데이타의 유무를 체크한다.
        /// </summary>
        /// <returns>
        /// True  : 디테일 데이타 유 
        /// False : 디테일 데이타 무
        /// </returns>
        private bool CheckDetail(string aNur_plan_jin, string aNur_plan_pro)
        {
            bool check = false;
            string cmdText = string.Empty;
            object retVal = null;
            BindVarCollection bindVals = new BindVarCollection();

            cmdText = @"SELECT 'Y'
				          FROM NUR0403 A
				         WHERE A.HOSP_CODE      = :f_hosp_code
                           AND A.NUR_PLAN_JIN   = :f_aNur_plan_jin
				           AND A.NUR_PLAN_PRO   = :f_aNur_plan_pro
				           AND ROWNUM = 1";

            bindVals.Add("f_hosp_code", this.mHospCode);
            bindVals.Add("f_aNur_plan_jin", aNur_plan_jin);
            bindVals.Add("f_aNur_plan_pro", aNur_plan_pro);

            retVal = Service.ExecuteScalar(cmdText, bindVals);

            if (retVal != null && retVal.ToString().Equals("Y"))
                check = true;

            return check;
        }
        #endregion

        #region 문제리스트 데이타 중복 체크
        /// <summary>
        /// 문제리스트 데이타에 대한 중복 여부를 체크한다.
        /// </summary>
        private void grdNUR0402_GridColumnChanged(object sender, IHIS.Framework.GridColumnChangedEventArgs e)
        {
            e.Cancel = false;

            switch (e.ColName)
            {
                case "nur_plan_pro":

                    if (e.ChangeValue.ToString().Trim() == "") break;

                    //중복 Check
                    for (int i = 0; i < grdNUR0402.RowCount; i++)
                    {
                        if (i != e.RowNumber)
                        {
                            if (grdNUR0402.GetItemString(i, e.ColName).Trim() == e.ChangeValue.ToString().Trim())
                            {
                                ShowMessage("NurPlanProDup", e.ChangeValue.ToString());

                                e.Cancel = true;
                                break;
                            }
                        }
                    }

                    if (e.Cancel) break;

                    // Delete Table Check
                    // 현재 화면상에도 없으면서 DeleteTable에 존재하면 Not 중복
                    bool deleted = false;

                    if (grdNUR0402.DeletedRowTable != null)
                    {
                        foreach (DataRow row in grdNUR0402.DeletedRowTable.Rows)
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
                        ShowMessage("NurPlanProDup", e.ChangeValue.ToString());

                        e.Cancel = true;
                    }
                    break;

                default:
                    break;
            }

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

        /// <summary>
        /// 버튼리스트의 [입력/삭제/저장] 버튼 클릭에 대한 처리를 한다.
        /// </summary>
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

                        if (this.CurrMSLayout == grdNUR0402)
                        {
                            if (tvwNur_plan_bunryu.SelectedNode.Parent == null) return;

                            currentRow = grdNUR0402.InsertRow();
                            grdNUR0402.SetItemValue(currentRow, "nur_plan_jin", this.tvwNur_plan_bunryu.SelectedNode.Tag.ToString());
                            SetSequence();
                        }
                    }
                    else
                        ((XEditGrid)CurrMSLayout).SetFocusToItem(chkCell.RowNumber, chkCell.ColumnNumber);

                    break;

                case FunctionType.Delete:
                    if (grdNUR0402.CurrentRowNumber < 0) return;

                    e.IsBaseCall = false;

                    if (grdNUR0402.GetRowState(grdNUR0402.CurrentRowNumber) != DataRowState.Added)
                    {
                        string nur_plan_jin = grdNUR0402.GetItemString(grdNUR0402.CurrentRowNumber, "nur_plan_jin");
                        string nur_plan_pro = grdNUR0402.GetItemString(grdNUR0402.CurrentRowNumber, "nur_plan_pro");
                        if (CheckDetail(nur_plan_jin, nur_plan_pro))
                        {
                            grdNUR0402.SetItemValue(grdNUR0402.CurrentRowNumber, "vald", "N");
                            return;
                        }
                    }

                    grdNUR0402.DeleteRow(grdNUR0402.CurrentRowNumber);

                    SetSequence();

                    break;

                case FunctionType.Update:
                    if (Grid_Validating())
                    {
                        grdNUR0402.SaveLayout();
                    }
                    break;

                default:
                    break;
            }
        }

        #endregion

        #region [간호계획진단 데이타 취득 및 설정 코드]

        /// <summary>
        /// 간호계획진단 데이타 취득 후 트리뷰에 설정한다.
        /// </summary>
        private void ShowNur_plan_bunryu()
		{			
			tvwNur_plan_bunryu.Nodes.Clear();
            
            if (layNUR0401.RowCount < 1) return;
            
			string nur_plan_bunryu = string.Empty;
			TreeNode node;

            foreach (DataRow row in layNUR0401.LayoutTable.Rows)
			{
				if(nur_plan_bunryu != row["nur_plan_bunryu"].ToString())
				{
					node = new TreeNode( row["nur_plan_bunryu_name"].ToString() );
					node.Tag = row["nur_plan_bunryu"].ToString();
					tvwNur_plan_bunryu.Nodes.Add(node);
					nur_plan_bunryu = row["nur_plan_bunryu"].ToString();
				}

				node = new TreeNode( row["nur_plan_jinname"].ToString() );
				node.Tag = row["nur_plan_jin"].ToString();
				tvwNur_plan_bunryu.Nodes[tvwNur_plan_bunryu.Nodes.Count -1].Nodes.Add(node);				
			}

			tvwNur_plan_bunryu.SelectedNode = tvwNur_plan_bunryu.Nodes[0].Nodes[0];
        }

        #endregion

        #region [간호계획진단에 따른 문제리스트 취득 및 설정 코드]

        /// <summary>
        /// 간호계획진단에 해당하는 문제리스트를 취득 후 그리드에 설정한다.
        /// </summary>
        private void tvwNur_plan_bunryu_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{		
			if(tvwNur_plan_bunryu.SelectedNode.Parent == null) return;

			try
			{
				Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;	
				
				string nur_plan_jin = tvwNur_plan_bunryu.SelectedNode.Tag.ToString();

                grdNUR0402.SetBindVarValue("f_hosp_code", this.mHospCode);
                grdNUR0402.SetBindVarValue("f_nur_plan_jin", nur_plan_jin);
                grdNUR0402.QueryLayout(false);
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
            for (int i = 0; i < grdNUR0402.RowCount; i++)
            {
                sort_key = i + 1;
                if (grdNUR0402.GetItemString(i, "sort_key") != sort_key.ToString())
                    grdNUR0402.SetItemValue(i, "sort_key", sort_key);
            }

        }
        #endregion

        #region 마우스 드래그&드롭을 이용한 정렬순서 변경
        private void grdNUR0402_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (grdNUR0402.GetHitRowNumber(e.Y) < 0) return;
            int curRowIndex = grdNUR0402.GetHitRowNumber(e.Y);
            string dragInfo = "[" + grdNUR0402.GetItemString(curRowIndex, "nur_plan_pro") + "]" + grdNUR0402.GetItemString(curRowIndex, "nur_plan_proname");
            DragHelper.CreateDragCursor(grdNUR0402, dragInfo, this.Font);
            grdNUR0402.DoDragDrop(curRowIndex.ToString(), DragDropEffects.Move);

        }

        private void grdNUR0402_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            // Client Point
            int fromRowNum = int.Parse(e.Data.GetData("System.String").ToString());
            Point clientPoint = grdNUR0402.PointToClient(new Point(e.X, e.Y));

            int toRowNum = grdNUR0402.GetHitRowNumber(clientPoint.Y);

            if (toRowNum == fromRowNum || toRowNum < 0)
            {
                //Edit상태로 만든다.
                grdNUR0402.SetFocusToItem(toRowNum, grdNUR0402.CurrentColNumber);
                return;
            }

            DataRow backRow = grdNUR0402.LayoutTable.NewRow();
            foreach (DataColumn col in grdNUR0402.LayoutTable.Columns)
            {
                backRow[col.ColumnName] = grdNUR0402.GetItemString(toRowNum, col.ColumnName);
                grdNUR0402.SetItemValue(toRowNum, col.ColumnName, grdNUR0402.GetItemString(fromRowNum, col.ColumnName));
                grdNUR0402.SetItemValue(fromRowNum, col.ColumnName, backRow[col.ColumnName]);
            }

            grdNUR0402.SetFocusToItem(toRowNum, grdNUR0402.CurrentColNumber);

            SetSequence();
        }

        private void grdNUR0402_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;  // Move 표시			
        }

        private void grdNUR0402_GiveFeedback(object sender, System.Windows.Forms.GiveFeedbackEventArgs e)
        {
            e.UseDefaultCursors = false;
            // Drag시에 Cursor 바꿈
            if ((e.Effect & DragDropEffects.Move) == DragDropEffects.Move)
            {
                Cursor.Current = DragHelper.DragCursor;
            }
        }
        #endregion

        #endregion

        #region [데이타 저장 완료 메시지 설정 코드]

        // 지정 에러메세지 인지 확인하는 플레그
        private bool appointmentError = false;

        /// <summary>
        /// 그리드의 데이타 저장 완료 후, 메세지를 표시한다.
        /// </summary>
        private void grdNUR0402_SaveEnd(object sender, SaveEndEventArgs e)
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
            private NUR0402U00 parent = null;
            public XSavePerformer(NUR0402U00 parent)
            {
                this.parent = parent;
            }
            public bool Execute(char callerID, RowDataItem item)
            {
                string cmdText = "";
                object retVal = null;

                item.BindVarList.Add("q_user_id", UserInfo.UserID);
                item.BindVarList.Add("f_hosp_code", parent.mHospCode);

                switch (item.RowState)
                {
                    case DataRowState.Added:
                        cmdText = @"SELECT 'Y'
                                      FROM NUR0402 
                                     WHERE HOSP_CODE    = :f_hosp_code
                                       AND NUR_PLAN_JIN = :f_nur_plan_jin
                                       AND NUR_PLAN_PRO = :f_nur_plan_pro
                                       AND ROWNUM = 1";

                        retVal = Service.ExecuteScalar(cmdText, item.BindVarList);

                        if (Service.ErrCode == 0)
                        {
                            if (retVal != null && retVal.ToString().Equals("Y"))
                            {
                                parent.ShowMessage("NurPlanProDup", item.BindVarList["f_nur_plan_pro"].VarValue);
                                parent.appointmentError = true;
                                return false;
                            }
                        }
                        else
                        {
                            return false;
                        }

                        cmdText = @"INSERT INTO NUR0402 (SYS_DATE, 
                                                         SYS_ID, 
                                                         UPD_DATE,
                                                         UPD_ID,
                                                         HOSP_CODE,  
                                                         NUR_PLAN_JIN,
                                                         NUR_PLAN_PRO, 
                                                         NUR_PLAN_PRONAME, 
                                                         VALD, 
                                                         SORT_KEY)
                                                VALUES  (SYSDATE, 
                                                         :q_user_id, 
                                                         SYSDATE, 
                                                         :q_user_id, 
                                                         :f_hosp_code, 
                                                         :f_nur_plan_jin, 
                                                         :f_nur_plan_pro, 
                                                         :f_nur_plan_proname, 
                                                         'Y', 
                                                         :f_sort_key)";
                        break;

                    case DataRowState.Modified:
                        cmdText = @"UPDATE NUR0402
                                       SET UPD_ID           = :q_user_id,
                                           UPD_DATE         = SYSDATE,
                                           NUR_PLAN_PRONAME = :f_nur_plan_proname,
                                           VALD             = :f_vald, 
                                           SORT_KEY         = :f_sort_key        
                                     WHERE HOSP_CODE        = :f_hosp_code
                                       AND NUR_PLAN_JIN     = :f_nur_plan_jin
                                       AND NUR_PLAN_PRO     = :f_nur_plan_pro";
                        break;

                    case DataRowState.Deleted:
                        cmdText = @"SELECT 'Y'
                                      FROM NUR0403 
                                     WHERE HOSP_CODE    = :f_hosp_code
                                       AND NUR_PLAN_JIN = :f_nur_plan_jin
                                       AND NUR_PLAN_PRO = :f_nur_plan_pro
                                       AND ROWNUM = 1";

                        retVal = Service.ExecuteScalar(cmdText, item.BindVarList);

                        if (Service.ErrCode == 0)
                        {
                            if (retVal != null && retVal.ToString().Equals("Y"))
                            {
                                parent.ShowMessage("ChildData", item.BindVarList["f_nur_plan_pro"].VarValue);
                                parent.appointmentError = true;
                                return false;
                            }
                        }
                        else
                        {
                            return false;
                        }

                        cmdText = @"DELETE NUR0402 
                                     WHERE HOSP_CODE    = :f_hosp_code
                                       AND NUR_PLAN_JIN = :f_nur_plan_jin
                                       AND NUR_PLAN_PRO = :f_nur_plan_pro";
                        break;
                }

                return Service.ExecuteNonQuery(cmdText, item.BindVarList);
            }
        }

        #endregion
    }
}