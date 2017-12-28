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
using IHIS.Framework;
#endregion

namespace IHIS.NURI
{
	/// <summary>
	/// NUR2005U00에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class NUR2005U00 : IHIS.Framework.XScreen
	{
		private IHIS.Framework.XPanel pnlTop;
		private IHIS.Framework.XPatientBox ptbPatient;
		private IHIS.Framework.XEditGridCell xEditGridCell3;
		private IHIS.Framework.XEditGridCell xEditGridCell4;
		private IHIS.Framework.XEditGridCell xEditGridCell5;
		private IHIS.Framework.XEditGridCell xEditGridCell6;
		private IHIS.Framework.XEditGridCell xEditGridCell7;
		private IHIS.Framework.XEditGridCell xEditGridCell1;
		private IHIS.Framework.XEditGridCell xEditGridCell2;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Splitter splitter1;
		private IHIS.Framework.XButtonList btnList;
		private IHIS.Framework.XEditGrid grdNUR2005;
		private IHIS.Framework.XEditGrid grdNUR0111;
		private IHIS.Framework.XTextBox txtFkinp1001;
		private IHIS.Framework.XEditGridCell xEditGridCell9;
		private IHIS.Framework.XEditGridCell xEditGridCell10;
		private IHIS.Framework.XEditGridCell xEditGridCell11;
		private IHIS.Framework.XEditGridCell xEditGridCell8;
		private IHIS.Framework.MultiLayout layNUR0112;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem1;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem2;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem3;
        private XPatientBox xPatientBox1;
        private XEditGridCell xEditGridCell12;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public NUR2005U00()
		{
			// 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();

            //저장 수행자 Set
            this.grdNUR2005.SavePerformer = new XSavePerformer(this);
            //저장 Layout List Set
            this.SaveLayoutList.Add(this.grdNUR2005);

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NUR2005U00));
            this.pnlTop = new IHIS.Framework.XPanel();
            this.txtFkinp1001 = new IHIS.Framework.XTextBox();
            this.ptbPatient = new IHIS.Framework.XPatientBox();
            this.grdNUR2005 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.grdNUR0111 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnList = new IHIS.Framework.XButtonList();
            this.panel2 = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.layNUR0112 = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem1 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem3 = new IHIS.Framework.MultiLayoutItem();
            this.xPatientBox1 = new IHIS.Framework.XPatientBox();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbPatient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdNUR2005)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdNUR0111)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layNUR0112)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xPatientBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.txtFkinp1001);
            this.pnlTop.Controls.Add(this.ptbPatient);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Padding = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.pnlTop.Size = new System.Drawing.Size(722, 36);
            this.pnlTop.TabIndex = 1;
            // 
            // txtFkinp1001
            // 
            this.txtFkinp1001.Location = new System.Drawing.Point(222, 62);
            this.txtFkinp1001.Name = "txtFkinp1001";
            this.txtFkinp1001.Size = new System.Drawing.Size(182, 20);
            this.txtFkinp1001.TabIndex = 2;
            // 
            // ptbPatient
            // 
            this.ptbPatient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ptbPatient.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ptbPatient.Location = new System.Drawing.Point(0, 0);
            this.ptbPatient.Name = "ptbPatient";
            this.ptbPatient.Padding = new System.Windows.Forms.Padding(0, 5, 0, 4);
            this.ptbPatient.Size = new System.Drawing.Size(722, 32);
            this.ptbPatient.TabIndex = 0;
            this.ptbPatient.PatientSelectionFailed += new System.EventHandler(this.ptbPatient_PatientSelectionFailed);
            this.ptbPatient.PatientSelected += new System.EventHandler(this.ptbPatient_PatientSelected);
            // 
            // grdNUR2005
            // 
            this.grdNUR2005.CallerID = '5';
            this.grdNUR2005.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell3,
            this.xEditGridCell12,
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell6,
            this.xEditGridCell7,
            this.xEditGridCell9,
            this.xEditGridCell10,
            this.xEditGridCell11,
            this.xEditGridCell8});
            this.grdNUR2005.ColPerLine = 3;
            this.grdNUR2005.Cols = 3;
            this.grdNUR2005.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdNUR2005.FixedRows = 1;
            this.grdNUR2005.FocusColumnName = "nur_so_code";
            this.grdNUR2005.HeaderHeights.Add(21);
            this.grdNUR2005.Location = new System.Drawing.Point(215, 0);
            this.grdNUR2005.Name = "grdNUR2005";
            this.grdNUR2005.QuerySQL = resources.GetString("grdNUR2005.QuerySQL");
            this.grdNUR2005.Rows = 2;
            this.grdNUR2005.Size = new System.Drawing.Size(507, 404);
            this.grdNUR2005.TabIndex = 4;
            this.grdNUR2005.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdNUR2005_QueryStarting);
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "bunho";
            this.xEditGridCell3.Col = -1;
            this.xEditGridCell3.IsNotNull = true;
            this.xEditGridCell3.IsVisible = false;
            this.xEditGridCell3.Row = -1;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellName = "pkocs2005";
            this.xEditGridCell12.Col = -1;
            this.xEditGridCell12.IsUpdatable = false;
            this.xEditGridCell12.IsVisible = false;
            this.xEditGridCell12.Row = -1;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "fkinp1001";
            this.xEditGridCell4.Col = -1;
            this.xEditGridCell4.IsNotNull = true;
            this.xEditGridCell4.IsVisible = false;
            this.xEditGridCell4.Row = -1;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "jukyong_date";
            this.xEditGridCell5.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell5.CellWidth = 134;
            this.xEditGridCell5.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell5.HeaderText = "適用日";
            this.xEditGridCell5.IsJapanYearType = true;
            this.xEditGridCell5.IsNotNull = true;
            this.xEditGridCell5.IsUpdatable = false;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "nur_md_code";
            this.xEditGridCell6.Col = -1;
            this.xEditGridCell6.IsNotNull = true;
            this.xEditGridCell6.IsVisible = false;
            this.xEditGridCell6.Row = -1;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "nur_so_code";
            this.xEditGridCell7.CellWidth = 238;
            this.xEditGridCell7.Col = 1;
            this.xEditGridCell7.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell7.HeaderText = "管理小項目";
            this.xEditGridCell7.IsNotNull = true;
            this.xEditGridCell7.MaxDropDownItems = 30;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "pk_seq";
            this.xEditGridCell9.Col = -1;
            this.xEditGridCell9.IsVisible = false;
            this.xEditGridCell9.Row = -1;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "input_gubun";
            this.xEditGridCell10.Col = -1;
            this.xEditGridCell10.IsVisible = false;
            this.xEditGridCell10.Row = -1;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "input_id";
            this.xEditGridCell11.Col = -1;
            this.xEditGridCell11.IsVisible = false;
            this.xEditGridCell11.Row = -1;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "input_id_name";
            this.xEditGridCell8.CellWidth = 105;
            this.xEditGridCell8.Col = 2;
            this.xEditGridCell8.HeaderText = "入力者";
            this.xEditGridCell8.IsReadOnly = true;
            // 
            // grdNUR0111
            // 
            this.grdNUR0111.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2});
            this.grdNUR0111.ColPerLine = 1;
            this.grdNUR0111.Cols = 2;
            this.grdNUR0111.Dock = System.Windows.Forms.DockStyle.Left;
            this.grdNUR0111.FixedCols = 1;
            this.grdNUR0111.FixedRows = 1;
            this.grdNUR0111.HeaderHeights.Add(21);
            this.grdNUR0111.Location = new System.Drawing.Point(0, 0);
            this.grdNUR0111.Name = "grdNUR0111";
            this.grdNUR0111.QuerySQL = resources.GetString("grdNUR0111.QuerySQL");
            this.grdNUR0111.ReadOnly = true;
            this.grdNUR0111.RowHeaderVisible = true;
            this.grdNUR0111.Rows = 2;
            this.grdNUR0111.Size = new System.Drawing.Size(212, 404);
            this.grdNUR0111.TabIndex = 5;
            this.grdNUR0111.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdNUR0111_QueryStarting);
            this.grdNUR0111.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdNUR0111_RowFocusChanged);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "nur_md_code";
            this.xEditGridCell1.Col = -1;
            this.xEditGridCell1.HeaderText = "管理項目";
            this.xEditGridCell1.IsReadOnly = true;
            this.xEditGridCell1.IsUpdCol = false;
            this.xEditGridCell1.IsVisible = false;
            this.xEditGridCell1.Row = -1;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "nur_md_name";
            this.xEditGridCell2.CellWidth = 164;
            this.xEditGridCell2.Col = 1;
            this.xEditGridCell2.HeaderText = "管理項目";
            this.xEditGridCell2.IsReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnList);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 440);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(722, 36);
            this.panel1.TabIndex = 6;
            // 
            // btnList
            // 
            this.btnList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.btnList.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnList.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnList.Location = new System.Drawing.Point(235, 0);
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Entry;
            this.btnList.Size = new System.Drawing.Size(487, 36);
            this.btnList.TabIndex = 1;
            this.btnList.PostButtonClick += new IHIS.Framework.PostButtonClickEventHandler(this.btnList_PostButtonClick);
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.grdNUR2005);
            this.panel2.Controls.Add(this.splitter1);
            this.panel2.Controls.Add(this.grdNUR0111);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 36);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(722, 404);
            this.panel2.TabIndex = 7;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(212, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 404);
            this.splitter1.TabIndex = 6;
            this.splitter1.TabStop = false;
            // 
            // layNUR0112
            // 
            this.layNUR0112.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem1,
            this.multiLayoutItem2,
            this.multiLayoutItem3});
            this.layNUR0112.QuerySQL = resources.GetString("layNUR0112.QuerySQL");
            this.layNUR0112.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layNUR0112_QueryStarting);
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "nur_md_code";
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "nur_so_code";
            // 
            // multiLayoutItem3
            // 
            this.multiLayoutItem3.DataName = "nur_so_name";
            // 
            // xPatientBox1
            // 
            this.xPatientBox1.Location = new System.Drawing.Point(327, 4);
            this.xPatientBox1.Name = "xPatientBox1";
            this.xPatientBox1.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.xPatientBox1.Size = new System.Drawing.Size(800, 32);
            this.xPatientBox1.TabIndex = 3;
            // 
            // NUR2005U00
            // 
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlTop);
            this.Name = "NUR2005U00";
            this.Size = new System.Drawing.Size(722, 476);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbPatient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdNUR2005)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdNUR0111)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layNUR0112)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xPatientBox1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region 스크린 로드
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);
			PostCallHelper.PostCall(new PostMethod(PostLoad));
		}

		private void PostLoad()
		{	
			if (this.OpenParam != null)
			{
				this.ptbPatient.SetPatientID(this.OpenParam["bunho"].ToString());
			}
			else
			{
				//현재스크린 환자번호
				XPatientInfo patientInfo = XScreen.GetPreviousScreenBunHo(true);
				if (patientInfo != null)
				{
					this.ptbPatient.SetPatientID(patientInfo.BunHo);
				}
			}
			
			//
			this.GetNUT0111();
		}
		private void GetNUT0111()
		{
            grdNUR0111.QueryLayout(true);
        }
		#endregion

		#region [환자정보 Reques/Receive Event]
		/// <summary>
		/// Docking Screen에서 환자정보 변경시 Raise
		/// </summary>
		public override void OnReceiveBunHo(XPatientInfo info)
		{
			if (info != null && !TypeCheck.IsNull(info.BunHo))
			{
				this.ptbPatient.Focus();
				this.ptbPatient.SetPatientID(info.BunHo);
			}
		}

		/// <summary>
		/// 현Screen의 등록번호를 타Screen에 넘긴다
		/// </summary>
		public override XPatientInfo OnRequestBunHo()
		{
			if (!TypeCheck.IsNull(this.ptbPatient.BunHo.ToString()))
			{
				return new XPatientInfo(this.ptbPatient.BunHo.ToString(), "", "", "", this.ScreenName);
			}

			return null;
		}
		#endregion

		// <summary>
		/// 
		/// </summary>
		/// <param name="aComboGubun">
		/// 콤보구분
		/// </param>
		#region 콤보박스 셋팅
		private void SetComboSetting()
        {
            this.layNUR0112.LayoutTable.Rows.Clear();

            if (layNUR0112.QueryLayout(false))
            {
                if (this.layNUR0112.LayoutTable.Rows.Count > 0)
                {
                    this.grdNUR2005.SetComboItems("nur_so_code", this.layNUR0112.LayoutTable, "nur_so_name", "nur_so_code");
                }
            }
            else
            {
                XMessageBox.Show(Service.ErrFullMsg.ToString());
                return;
            }
		}
		#endregion

		#region 대분류 선택시 소항목 콤보박스 리스트 업
		private void grdNUR0111_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
		{
			if (this.grdNUR0111.RowCount <= 0 ) return;

			SetComboSetting();

            if (!grdNUR2005.QueryLayout(false))
            {
                XMessageBox.Show(Service.ErrFullMsg.ToString());
                return;
            }
		}
		#endregion

		#region 버튼리스트에서 버튼을 클릭을 했을 때의 이벤트
		private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			switch(e.Func)
			{
                case FunctionType.Query:
                    this.CurrMQLayout = this.grdNUR0111;
                    break;

                case FunctionType.Insert:

                    this.CurrMSLayout = this.grdNUR2005;

					if(this.grdNUR2005.RowCount > 0)
					{
						int i = 0;
						for(i = 0; i < this.grdNUR2005.RowCount; i++)
						{
							if(this.grdNUR2005.LayoutTable.Rows[i].RowState == DataRowState.Added)
							{
								if (TypeCheck.IsNull(this.grdNUR2005.GetItemString(this.grdNUR2005.CurrentRowNumber,"jukyong_date")) ||
									TypeCheck.IsNull(this.grdNUR2005.GetItemString(this.grdNUR2005.CurrentRowNumber,"nur_so_code")) )
								{									
									e.IsBaseCall = false;
									break;
								}
							}
						}
					}

					if(!this.AcceptData())
					{
						e.IsBaseCall = false;
						e.IsSuccess = false;
					}

					if(this.ptbPatient.BunHo.ToString() == "" || this.txtFkinp1001.GetDataValue() == "")
					{
						e.IsBaseCall = false;
						this.GetMessage("bunho");
					}
					else
					{
					}

					break;

				case FunctionType.Update:
                    e.IsBaseCall = false;

					if(this.ptbPatient.BunHo.ToString() == "")
					{
						e.IsBaseCall = false;
						this.GetMessage("bunho");
						this.ptbPatient.Focus();
						return;
					}

					if(this.grdNUR2005.RowCount > 0)
					{
                        string bunho = ptbPatient.BunHo;
						for(int i = 0; i < this.grdNUR2005.RowCount; i++)
						{
							if(this.grdNUR2005.GetItemString(i, "nur_so_code") == "")
							{
								e.IsBaseCall = false;
								this.grdNUR2005.SetFocusToItem(i, "nur_so_code");
								break;
							}

							if(this.grdNUR2005.GetItemString(i, "jukyong_date") == "")
							{
								e.IsBaseCall = false;
								this.GetMessage("jukyong_date");
								this.grdNUR2005.SetFocusToItem(i, "jukyong_date");
								break;
							}
						}
                    }

                    if (!this.DupCheck())
                    {
                        GetMessage("validation_chk");
                        return;
                    }

                    if (grdNUR2005.SaveLayout())
                    {
                        GetMessage("save_true");
                    }
                    else
                    {
                        GetMessage("save_false");
                    }
					break;

				case FunctionType.Close:

					break;
					
				case FunctionType.Delete:
                    this.CurrMSLayout = this.grdNUR2005;
					if (this.grdNUR2005.GetRowState(this.grdNUR2005.CurrentRowNumber) != DataRowState.Added && this.grdNUR2005.GetItemString(this.grdNUR2005.CurrentRowNumber,"input_gubun") != "NR")
					{
						e.IsBaseCall = false;						
						this.GetMessage("input_gubun");
					}
					break;
					
				default:
					break;
			}
		}		
		#endregion

        #region 버튼리스트에서 버튼을 클릭 후의 이벤트
        private void btnList_PostButtonClick(object sender, IHIS.Framework.PostButtonClickEventArgs e)
		{
			switch(e.Func)
			{
				case FunctionType.Insert:
					if(this.ptbPatient.BunHo.ToString() != "")
					{
						if(this.grdNUR2005.RowCount > 0)
						{
							if(this.grdNUR2005.CurrentRowNumber >= 0)
							{
								this.grdNUR2005.SetItemValue(grdNUR2005.CurrentRowNumber, "bunho", this.ptbPatient.BunHo.ToString());
								this.grdNUR2005.SetItemValue(grdNUR2005.CurrentRowNumber, "nur_md_code", this.grdNUR0111.GetItemString(this.grdNUR0111.CurrentRowNumber,"nur_md_code"));
								this.grdNUR2005.SetItemValue(grdNUR2005.CurrentRowNumber, "fkinp1001", this.txtFkinp1001.GetDataValue().ToString());
                                this.grdNUR2005.SetItemValue(grdNUR2005.CurrentRowNumber, "input_id", IHIS.Framework.UserInfo.UserID);
                                this.grdNUR2005.SetItemValue(grdNUR2005.CurrentRowNumber, "input_id_name", UserInfo.UserName);
								this.grdNUR2005.SetItemValue(grdNUR2005.CurrentRowNumber,"jukyong_date",
									EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
							}
						}
					}
					break;
				default:
					break;
			}
		}
		#endregion

		#region 등록번호를 선택할때
		private void ptbPatient_PatientSelected(object sender, System.EventArgs e)
		{
			this.grdNUR2005.Reset();
			if(!TypeCheck.IsNull(this.ptbPatient.BunHo.ToString()))
			{
				this.GetFkinp1001();
			}
		}
		#endregion

		/// <summary>
		/// 환자번호로 입원키를 찾는다.
		/// </summary>
		#region 환자의 입원키를 찾는다.
		private void GetFkinp1001()
		{
            try
            {
                string cmdText = @"SELECT PKINP1001
								     FROM VW_OCS_INP1001_01
								    WHERE HOSP_CODE            = :f_hosp_code 
                                      AND NVL(CANCEL_YN,'N')   = 'N'
								      AND NVL(JAEWON_FLAG,'N') = 'Y'
								      AND BUNHO                = :f_bunho";
                BindVarCollection bindVars = new BindVarCollection();
                bindVars.Add("f_hosp_code", EnvironInfo.HospCode);
                bindVars.Add("f_bunho", ptbPatient.BunHo.Trim());
                object retVal = Service.ExecuteScalar(cmdText, bindVars);

                if (TypeCheck.IsNull(retVal))
                {
                    GetMessage("jeawonYn");
                    grdNUR2005.Enabled = false;
                    ptbPatient.Focus();
                    return;
                }
                else
                {
                    grdNUR2005.Enabled = true;

                    txtFkinp1001.SetDataValue(retVal.ToString());

                    grdNUR0111.QueryLayout(false);

                    //if (!grdNUR2005.QueryLayout(false))
                    //{
                    //    XMessageBox.Show(Service.ErrFullMsg + "\n\r" + Service.ErrCode);
                    //}
                }
            }
            catch (Exception ex)
            {
				//https://sofiamedix.atlassian.net/browse/MED-10610
                //XMessageBox.Show(ex.Message + "\n\r" + ex.StackTrace);
                return;
            }
		}
		#endregion

		#region 등록번호를 잘못 입력을 했을 때
		private void ptbPatient_PatientSelectionFailed(object sender, System.EventArgs e)
		{
            this.grdNUR2005.Reset();
		}
		#endregion

		/// <summary>
		/// 메세지 일괄 처리
		/// </summary>
		/// <param name="aMesgGubun">
		/// 메세지 구분
		/// </param>
		#region 메세지처리
		private void GetMessage(string aMesgGubun)
		{
			string msg = string.Empty;
			string caption = string.Empty;
			
			switch(aMesgGubun)
			{
				case "input_gubun":
					msg = (NetInfo.Language == LangMode.Ko ? "의사지시는 수정/삭제 불가능합니다.."
						: "医師指示は修正/削除出来ません。");
					caption = (NetInfo.Language == LangMode.Ko ? "알림"
                        : "注意");
					XMessageBox.Show(msg, caption);
					break;
				case "jeawonYn":
					msg = (NetInfo.Language == LangMode.Ko ? "재원중인 환자가 아닙니다." + " 환자번호를 확인해 주세요"
						: "在院中の患者ではありません。 患者番号を確認してください。");
					caption = (NetInfo.Language == LangMode.Ko ? "알림"
                        : "注意");
					XMessageBox.Show(msg, caption);
					break;
				case "bunho":
					msg = (NetInfo.Language == LangMode.Ko ? " 환자번호를 확인해 주세요"
						: "患者番号を確認してください。");
					caption = (NetInfo.Language == LangMode.Ko ? "알림"
                        : "注意");
					XMessageBox.Show(msg, caption);
					break;
				case "query":
					msg = (NetInfo.Language == LangMode.Ko ? "조회실패."
						: "照会出来ませんでした。");
					caption = (NetInfo.Language == LangMode.Ko ? "알림"
						: "エラー");
					XMessageBox.Show(msg, caption);
					break;
				case "validation_chk":
					msg = (NetInfo.Language == LangMode.Ko ? "이미 입력된 정보입니다."
						: "既に入力された情報があります。");
					caption = (NetInfo.Language == LangMode.Ko ? "알림"
						: "エラー");
					XMessageBox.Show(msg, caption);
					break;
				case "ganhodo":
					msg = (NetInfo.Language == LangMode.Ko ? "간호도를 입력해 주세요."
						: "看護度を入力してください。");
					caption = (NetInfo.Language == LangMode.Ko ? "알림"
						: "注意");
					XMessageBox.Show(msg, caption);
					break;
				case "jukyong_date":
					msg = (NetInfo.Language == LangMode.Ko ? "적용일자를 입력해 주세요."
						: "適用日付を入力してください。");
					caption = (NetInfo.Language == LangMode.Ko ? "알림"
                        : "注意");
					XMessageBox.Show(msg, caption);
					break;
				case "save_true":
					msg = NetInfo.Language == LangMode.Ko ? "보존했습니다."
						: "保存しました。";
					caption = NetInfo.Language == LangMode.Ko ? "알림" 
						: "保存";
					XMessageBox.Show(msg, caption);
					break;
				case "save_false":
					msg = NetInfo.Language == LangMode.Ko ? "저장 실패하였습니다. 확인바랍니다." 
						: "保存に失敗しました。";
                    msg += "\r\n[" + Service.ErrFullMsg + "]";
					caption = NetInfo.Language == LangMode.Ko ? "알림" 
						: "保存失敗";
					XMessageBox.Show(msg, caption);
					break;
				default:
					break;
			}
		}
		#endregion		

        #region layNUR0112 바인드변수 설정
        private void layNUR0112_QueryStarting(object sender, System.ComponentModel.CancelEventArgs e)
        {
            layNUR0112.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            layNUR0112.SetBindVarValue("f_nur_md_code", grdNUR0111.GetItemString(grdNUR0111.CurrentRowNumber, "nur_md_code"));
        }
        #endregion

        #region grdNUR2005 바인드변수 설정
        private void grdNUR2005_QueryStarting(object sender, CancelEventArgs e)
        {
            grdNUR2005.SetBindVarValue("f_hosp_code",   EnvironInfo.HospCode);
            grdNUR2005.SetBindVarValue("f_bunho",       ptbPatient.BunHo.Trim());
            grdNUR2005.SetBindVarValue("f_nur_md_code", grdNUR0111.GetItemString(grdNUR0111.CurrentRowNumber, "nur_md_code"));
        }
        #endregion

        #region 중복 체크 처리
        /// <summary>
        /// 저장 전, 중복체크를 실행한다.
        /// </summary>
        private bool DupCheck()
        {
            for (int i = 0; i < grdNUR2005.RowCount; i++)
            {
                for (int j = i + 1; j < grdNUR2005.RowCount; j++)
                {
                    if (grdNUR2005.GetItemValue(i, "jukyong_date").Equals(grdNUR2005.GetItemValue(j, "jukyong_date")))
                    {
                        grdNUR2005.SetFocusToItem(grdNUR2005.CurrentRowNumber, "jukyong_date");
                        return false;
                    }
                }
            }

            return true;

//            string cmdText = @"SELECT 'Y'
//                                 FROM OCS2005
//                                WHERE HOSP_CODE   = :f_hosp_code 
//                                  AND BUNHO       = :f_bunho
//                                  AND FKINP1001   = :f_fkinp1001
//                                  AND ORDER_DATE  = :f_jukyong_date
//                                  AND INPUT_GUBUN = 'NR'
//                                  AND DIRECT_CODE = :f_nur_md_code
//                                  AND ROWNUM = 1";
//            BindVarCollection bindVars = new BindVarCollection();
//            object retVal = null;
//            for (int i = 0; i < grdNUR2005.RowCount; i++)
//            {
//                retVal = null;
//                bindVars.Clear();
//                bindVars.Add("f_hosp_code", EnvironInfo.HospCode);
//                bindVars.Add("f_bunho", ptbPatient.BunHo);
//                bindVars.Add("f_fkinp1001", grdNUR2005.GetItemString(i, "fkinp1001"));
//                bindVars.Add("f_jukyong_date", grdNUR2005.GetItemString(i, "jukyong_date"));
//                bindVars.Add("f_nur_md_code", grdNUR2005.GetItemString(i, "nur_md_code"));

//                retVal = Service.ExecuteScalar(cmdText, bindVars);

//                if (!TypeCheck.IsNull(retVal))
//                {
//                    if (retVal.ToString().Equals("Y"))
//                    {
//                        grdNUR2005.SetFocusToItem(grdNUR2005.CurrentRowNumber, "jukyong_date");
//                        return false;
//                    }
//                }
//            }
//            return true;
        }
        #endregion

        #region XSavePerformer
        private class XSavePerformer : IHIS.Framework.ISavePerformer
        {
            private NUR2005U00 parent = null;
            public XSavePerformer(NUR2005U00 parent)
            {
                this.parent = parent;
            }
            public bool Execute(char callerID, RowDataItem item)
            {
                string cmdText = "";
                //Grid에서 넘어온 Bind 변수에 f_user_id SET
                item.BindVarList.Add("q_user_id", UserInfo.UserID);
                item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);

                switch (item.RowState)
                {
                    case DataRowState.Added:
                        string pkSeq = "";
                        string cmdPkSeq = @"SELECT NVL(MAX(PK_SEQ), 0) + 1
                                              FROM OCS2005
                                             WHERE HOSP_CODE   = :f_hosp_code 
                                               AND BUNHO       = :f_bunho
                                               AND FKINP1001   = :f_fkinp1001
                                               AND ORDER_DATE  = :f_jukyong_date
                                               AND INPUT_GUBUN = 'NR'";
                        pkSeq = Service.ExecuteScalar(cmdPkSeq, item.BindVarList).ToString();

                        item.BindVarList.Add("f_pk_seq", pkSeq);

                        cmdText
                            = @"INSERT INTO OCS2005
                                           ( SYS_DATE       , SYS_ID            , UPD_DATE          , UPD_ID        , 
                                             HOSP_CODE      , BUNHO             , PKOCS2005         , 
                                             FKINP1001      , ORDER_DATE        , INPUT_GUBUN       , INPUT_ID      ,
                                             PK_SEQ         , DIRECT_GUBUN      , DIRECT_CODE       , DIRECT_CONT1  )
                                     VALUES
                                           ( SYSDATE        , :q_user_id        , SYSDATE           , :q_user_id    , 
                                             :f_hosp_code   , :f_bunho          , OCS2005_SEQ.NEXTVAL      ,
                                             :f_fkinp1001   , :f_jukyong_date   , 'NR'              , :q_user_id     ,
                                             :f_pk_seq      , '00'              , :f_nur_md_code    , :f_nur_so_code )";
                        break;
                    case DataRowState.Modified:
                        cmdText
                            = @"UPDATE OCS2005
                                   SET UPD_ID       = :q_user_id     ,
                                       UPD_DATE     = SYSDATE        ,
                                       DIRECT_CONT1 = :f_nur_so_code
                                 WHERE HOSP_CODE    = :f_hosp_code
                                   AND BUNHO        = :f_bunho
                                   AND FKINP1001    = :f_fkinp1001
                                   AND ORDER_DATE   = :f_jukyong_date
                                   AND DIRECT_CODE  = :f_nur_md_code
                                   AND INPUT_GUBUN  = 'NR'";
                        break;
                    case DataRowState.Deleted:
                        cmdText
                            = @"DELETE OCS2005
                                 WHERE HOSP_CODE   = :f_hosp_code
                                   AND BUNHO       = :f_bunho
                                   AND FKINP1001   = :f_fkinp1001
                                   AND ORDER_DATE  = :f_jukyong_date
                                   AND INPUT_GUBUN = 'NR'
                                   AND DIRECT_CODE = :f_nur_md_code";
                        break;
                }

                return Service.ExecuteNonQuery(cmdText, item.BindVarList);
            }
        }
        #endregion

        private void grdNUR0111_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdNUR0111.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
        }
    }
}

