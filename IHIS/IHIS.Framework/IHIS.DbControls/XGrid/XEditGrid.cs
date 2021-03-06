using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Drawing.Design;
using System.Data;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Reflection;

namespace IHIS.Framework
{

	/// <summary>
	/// XEditGrid에 대한 요약 설명입니다.
	/// </summary>
	[DefaultProperty("CellInfos"),
	DefaultEvent("GridColumnChanged"),
	ToolboxItem(true),
	ToolboxBitmap(typeof(IHIS.Framework.XEditGrid), "Images.XGrid.bmp")]
	public class XEditGrid : XGrid, IMultiSaveLayout
	{
		#region Fields without Property
		private bool isEditing = false;  // Editor로 Editing중 여부
		private bool readOnlyColumnEditing = true;
		private ArrayList autoInsertColumnList = new ArrayList();  //XEditGridCell중에서 AutoInsertAtEnterKey 속성이 설정된 컬럼의 LIST(InitializeColumns에서 SET)
		private DataTable deletedRowTable;
		#endregion

		#region Fields having Property
		private XGridEditType editType = XGridEditType.SingleClick;
		private string  focusColumnName = string.Empty;  // 행삽입,행삭제후 Focus할 컬럼명
		private bool applyAutoInsertion = false; //EnterKey 입력시 XEditGridCell의 autoInsertAtEnterKey가 true인 컬럼의 경우 자동 Insert 처리
		private bool useDefaultTransaction = true;  //SaveLayout시에 Transaction을 사용할지 여부(MasterLayout인 경우 Detail이 정상적일때 Tran종료시 사용)
		private bool includeUnChangedRowAtSaving = false;  //저장시 변경되지 않은 Row를 포함할지 여부(변경안된Row 포함시는 N으로 처리함)
		//저장 관련
		private ISavePerformer savePerformer = null;  //저장 기능을 담당하는 수행자
		#endregion

		#region Properties
		[Category("데이타"),
		DefaultValue(null),
		Description("저장시 저장 기능을 수행하는 수행 class 객체를 지정합니다.")]
		public ISavePerformer SavePerformer
		{
			get { return savePerformer; }
			set { savePerformer = value; }
		}
		[Category("데이타"),
		DefaultValue('1'),
		Description("저장시 저장기능 수행자에게 넘겨줄 Grid의 ID를 지정합니다.")]
		public char CallerID
		{
			get { return callerID; }
			set { callerID = value; }
		}
		[Category("데이타"),
		DefaultValue(true),
		Description("저장시 Grid의 기본 Transaction을 사용할지 여부를 지정합니다.(여러개의 Grid처리시는 외부에서 Transaction 관리)")]
		public bool UseDefaultTransaction
		{
			get { return useDefaultTransaction;}
			set { useDefaultTransaction = value;}
		}
		[Category("데이타"),
		DefaultValue(false),
		Description("저장시 변경되지 않은 행의 데이타도 전송할지 여부를 지정합니다.(IUD가 N으로 설정)")]
		public bool IncludeUnChangedRowAtSaving
		{
			get { return includeUnChangedRowAtSaving;}
			set { includeUnChangedRowAtSaving = value;}
		}
		/// <summary>
		/// 컬럼정보를 관리합니다.
		/// </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content),
		Category("컬럼정보"),
		Editor(typeof(XEditGridCellEditor), typeof(UITypeEditor)),
		Bindable(true),
		Description("Column정보를 관리합니다.")]
		public override XGridCellCollection CellInfos
		{
			get { return base.CellInfos ;}
			set { base.CellInfos = value;}
		}
		/// <summary>
		/// EditMode로 전환하는 방법(SingleClick,DoubleClick)을 가져오거나 설정합니다.
		/// </summary>
		[Category("동작"),
		DefaultValue(XGridEditType.SingleClick),
		Description("EditMode로 전환하는 방법을 관리합니다.")]
		public XGridEditType EditType
		{
			get { return editType;}
			set { editType = value;}
		}
		/// <summary>
		/// 편집가능여부를 가져오거나 설정합니다.
		/// </summary>
		[Browsable(true),
		Category("동작"),
		DefaultValue(false),
		Description("Grid 편집가능여부를 설정합니다.")]
		public override bool ReadOnly
		{
			get {return base.ReadOnly;}
			set {base.ReadOnly = value;}
		}
		/// <summary>
		/// 행삽입,행삭제후 Focus를 줄 컬럼명을 가져오거나 설정합니다.
		/// (컬럼명이 없으면 첫번째 컬럼으로 Focus를 줍니다.)
		/// </summary>
		[Category("동작"),
		DefaultValue(""),
		Editor(typeof(FocusColumnNameEditor), typeof(UITypeEditor)),
		Description("행삽입,행삭제후 Focus를 줄 컬럼명을 설정합니다.(없으면 첫번째 컬럼으로 Focus를 줍니다.)")]
		public string FocusColumnName
		{
			get { return focusColumnName;}
			set { focusColumnName = value;}
		}
		/// <summary>
		/// Row의 상태에 따라 Text색깔을 변경할지 여부를 가져오거나 설정합니다.
		/// </summary>
		[Category("동작"),
		DefaultValue(true),
		Description("Row의 상태에 따라 Text색깔 변경여부를 관리합니다.")]
		public new bool RowStateCheckOnPaint
		{
			get { return base.RowStateCheckOnPaint;}
			set { base.RowStateCheckOnPaint = value;}
		}
		[Category("동작"),
		DefaultValue(false),
		Description("컬럼속성에 AutoInsertAtEnterKey가 true인 컬럼에 대해 Enter키 입력시 자동으로 행삽입을 처리할지 여부를 지정합니다.")]
		public bool ApplyAutoInsertion
		{
			get {return applyAutoInsertion;}
			set { applyAutoInsertion = value;}
		}
		/// <summary>
		/// 삭제된 행의 건수를 가져옵니다.
		/// </summary>
		[Browsable(false)]
		public int DeletedRowCount
		{
			get { return (this.deletedRowTable == null ? 0 : this.deletedRowTable.Rows.Count);}
		}
		/// <summary>
		/// 삭제된 행을 관리하는 DataTable을 가져옵니다.
		/// </summary>
		[Browsable(false)]
		public DataTable DeletedRowTable
		{
			get { return deletedRowTable;}
		}
		#endregion

		#region 생성자
		/// <summary>
		/// XEditGrid 생성자
		/// </summary>
		public XEditGrid()
		{
			//ReadOnly Default = false
			this.ReadOnly = false;
			//Display Complete
			this.DisplayCompleted = true;
			//RowStateCheckOnPaint = true
			this.RowStateCheckOnPaint = true;
		}
		#endregion

		#region Dispose
		/// <summary> 
		/// 사용된 자원을 해제합니다.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				//<MEMORY LEAK> 2007.10.15 XEditGrid가 Dispose될때 XDatePicker가 Dispose가 되지 않는 현상이 발생함.
				//왜 Dispose가 되지 않는지는 알 수 없으나, Dispose를 시켜야 하므로 XEditGridCell의 Editor를 Dispose하는 Logic 추가
				foreach (XEditGridCell info in this.CellInfos)
				{
					if ((info.CellEditor != null) && (info.CellEditor.Editor != null) && (info.CellEditor.Editor is Control))
						((Control) info.CellEditor.Editor).Dispose();
				}
			}
			base.Dispose( disposing );
		}
		#endregion

		#region SaveLayout (저장 처리)
		public virtual bool SaveLayout()
		{
			//저장 기능 수행자 미정의시 Return
			if (this.SavePerformer == null)
			{
				this.ShowErrMsg("Save Performer is not defined");
				return false;
			}
			
			int rowNumber = 0;
			int saveCount = 0;  //저장된 행의 전체 갯수(I,U,D,N 포함)
			object masterValue = DBNull.Value;

			try
			{
				this.SetServiceMsg(ServiceType.Entry, ServiceMsgType.Processing); //처리중 Msg 처리

				//Transaction Start (기본 Transaction 사용시만)
				if (this.UseDefaultTransaction)
					Service.BeginTransaction();
				/* 저장 순서는 삭제된 행 -> 입력,수정된 행
				 * IsUpdCol인 컬럼으로 RowDataItem의 Data구성 -> SavePerformer의 Execute call
				 */
				RowDataItem dataItem;
				//InputList는 IsUpdCol로 지정된 컬럼을 차례로 InputList에 Add
				//삭제 데이타로 서비스 Call
				if (deletedRowTable != null && deletedRowTable.Rows.Count > 0)
				{
					foreach(DataRow dtRow in deletedRowTable.Rows)
					{
						dataItem = new RowDataItem(DataRowState.Deleted);
						foreach (XEditGridCell item in this.CellInfos)
						{
							//Update컬럼만 Add
							if (item.IsUpdCol)
							{
								//NotNull Check
								if (item.IsNotNull && dtRow[item.CellName].ToString() == "")
								{
									string name = (item.HeaderText != "" ? item.HeaderText : item.CellName);
									string msg = "["+ name +"]" + XMsg.GetMsg("M024"); //의 값이 입력되지 않았습니다."
									throw(new Exception(msg));
								}
								//BindVarList Set
								//2007.10.15 BIND 변수는 컬럼의 CASE에 관계없이 Lower로 처리함.
								//2007.11.06 컬럼명 그대로 f_를 붙이는 것으로 처리한다.
								//dataItem.BindVarList.Add("f_" + item.CellName.ToLower(), dtRow[item.CellName].ToString());

                                dataItem.BindVarList.Add("f_" + item.CellName, dtRow[item.CellName].ToString());
                                
							}
						}
						//저장 수행자 Call (실패시는 Exception 발생시켜 Rollback 처리)
						if (!this.SavePerformer.Execute(this.callerID, dataItem))
						{
							throw new Exception( XMsg.GetMsg("M002") + "[" + Service.ErrMsg + "]"); //저장실패
						}
						saveCount++; //저장 갯수증가
					}
				}

				//I,U Row 전문 생성
				foreach(DataRow dtRow in LayoutTable.Rows)
				{
					//Added, Modified 상태일때만 Data Set
					//2006.04.04 변경안된 행 포함여부도 고려함
					if(this.includeUnChangedRowAtSaving || (dtRow.RowState == DataRowState.Added) || (dtRow.RowState == DataRowState.Modified))
					{
						dataItem = new RowDataItem(dtRow.RowState);

						// PreSaveLayout Event 호출
						OnPreSaveLayout(new GridRecordEventArgs(dtRow.RowState, rowNumber));
					
						foreach (XEditGridCell item in this.CellInfos)
						{
							//Update컬럼만 Add
							if (item.IsUpdCol)
							{
								//Added상태일때 MasterLayout이 있고, 컬럼이 RelationKeys에 적용된 컬럼이면 MasterLayout에서 값을 가져와서 설정
								if ((this.MasterLayout != null) && (dtRow.RowState == DataRowState.Added) && this.relationKeys.Contains(item.CellName))
								{
									masterValue = this.MasterLayout.GetItemValueFromRelatonKey(this.relationKeys[item.CellName].ToString());
									//dtRow의 값을 masterValue로 설정
									dtRow[item.CellName] = masterValue;
								}
								//NotNull Check
								if (item.IsNotNull && dtRow[item.CellName].ToString() == "")
								{
									string name = (item.HeaderText != "" ? item.HeaderText : item.CellName);
									string msg = "["+ name +"]" + XMsg.GetMsg("M024"); //의 값이 입력되지 않았습니다."
									throw(new Exception(msg));
								}
								//BindVarList Set
								//2007.10.15 BIND 변수는 컬럼의 CASE에 관계없이 Lower로 처리함.
								//2007.11.06 컬럼명 그대로 f_를 붙이는 것으로 처리한다.
								//dataItem.BindVarList.Add("f_" + item.CellName.ToLower(), dtRow[item.CellName].ToString());
                                //2010.05.25 kimminsoo - date type 일 경우에는 시간 제외
                                if ((item.CellType == XCellDataType.Date) && (TypeCheck.IsDateTime(dtRow[item.CellName].ToString())))
                                    dataItem.BindVarList.Add("f_" + item.CellName, DateTime.Parse(dtRow[item.CellName].ToString()).ToString("yyyy/MM/dd").Replace("-", "/"));
                                else
                                {
                                    //2011.05.19 mins add default size 100을 넘어가는 경우만 size 지정
                                    //Service.debugFileWrite("[mins test][" + item.CellLen.ToString() + "][" + item.CellName + "][" + dtRow[item.CellName].ToString() + "]");
                                    if (item.CellLen <= 100)
                                        dataItem.BindVarList.Add("f_" + item.CellName, dtRow[item.CellName].ToString());
                                    else
                                        dataItem.BindVarList.Add("f_" + item.CellName, dtRow[item.CellName].ToString(), item.CellLen);
                                }
                                 //   dataItem.BindVarList.Add("f_" + item.CellName, dtRow[item.CellName].ToString());

							}
						}
						//저장 수행자 Call (실패시는 return)
						if (!this.SavePerformer.Execute(this.callerID, dataItem))
						{
							//저장 수행자 Call (실패시는 Exception 발생시켜 Rollback 처리)
							throw new Exception( XMsg.GetMsg("M002") + "[" + Service.ErrMsg + "]"); //저장실패
						}
						saveCount++; //저장 갯수증가
					}
					//RowNumber 증가
					rowNumber ++;
				}
				//Transaction Commit (기본 Transaction 사용시만)
				if (this.UseDefaultTransaction)
					Service.CommitTransaction();
			}
			catch(Exception xe)
			{
				//2007.11.08 에러 MSG는 개발자가 판단하여 보여주기
				//this.ShowErrMsg(xe.Message); 

				//Transaction Rollback
				if (this.UseDefaultTransaction)
					Service.RollbackTransaction();

				//2007.11.08 SaveEnd Event Invoke (저장실패)
				OnSaveEnd(new SaveEndEventArgs(this.callerID, false, xe.Message));

				return false;
			}

			//저장 성공시 ResetUpdate
			this.ResetUpdate();

			//저장 완료, 저장할 내역 없음 Msg Set
			//여러 Grid를 한꺼번에 저장시 Master-Detail에서 Detail이 저장할 내역이 없으면 Masters는 저장되었는데,
			//처리할 내역이 없다고 나오므로 처리한 data가 있는 경우에만 Msg Set
			//if (saveCount > 0)
			this.SetServiceMsg(ServiceType.Entry, ServiceMsgType.Normal);

			//2007.11.08 SaveEnd Event Invoke (저장성공)
			OnSaveEnd(new SaveEndEventArgs(this.callerID, true,""));

			return true;
		}
		#endregion

		#region Event
		/// <summary>
		/// 데이타 항목값을 설정하는 이벤트입니다.
		/// </summary>
		[Category("추가이벤트"),
		Description("서비스로 보낼 자료작성전 발생 이벤트입니다.(조건에 따른 데이타 설정)")]
		public event GridRecordEventHandler PreSaveLayout;
		/// <summary>
		/// ColumnChanged : Column값을 변경시에 Validation Check 추가 Event Handler
		/// </summary>
		[Description("데이타에 따른 편집가능여부 설정시 발생합니다."),
		Category("추가이벤트"),
		Browsable(true)]
		public event GridColumnProtectModifyEventHandler GridColumnProtectModify;

		[Description("FindBox Column에서 Find후에 데이타를 처리합니다."),
		Category("추가이벤트"),	
		Browsable(true)]
		public event GridFindSelectedEventHandler GridFindSelected;

		[Description("FindBox Column에서 Click시에 발생합니다."),
		Category("추가이벤트"),	
		Browsable(true)]
		public event GridFindClickEventHandler GridFindClick;

		[Description("Check,Combo 컬럼에서 선택값을 변경시에 발생합니다."),
		Category("추가이벤트"),	
		Browsable(true)]
		public event ItemValueChangingEventHandler ItemValueChanging;

		[Description("Key 입력시 발생합니다.(Key값에 따른 처리시 핸들링하십시오)"),
		Category("추가이벤트"),	
		Browsable(true)]
		public event KeyEventHandler ProcessKeyDown;

		[Description("Grid에 있는 Button을 Click할 때 발생합니다."),
		Category("추가이벤트"),	
		Browsable(true)]
		public event GridButtonClickEventHandler GridButtonClick;

		[Description("Grid에 있는 Combo를 자료사전(UserSQL)로 설정할때 발생합니다."),
		Category("추가이벤트"),	
		Browsable(true)]
		public event GridDDLBSettingEventHandler GridDDLBSetting;

		[Description("Grid의 Edit를 시작할때 발생합니다."),
		Category("추가이벤트"),	
		Browsable(true)]
		public event GridEditStartingEventHandler EditStarting;

		[Description("MemoBox형 컬럼에서 메모창이 보여질때 발생합니다.(조건에 따라 메모창을 띄울지 여부 결정)"),
		Category("추가이벤트"),	
		Browsable(true)]
		public event GridMemoFormShowingEventHandler GridMemoFormShowing;

        [Description("MemoBox형 컬럼에서 메모창에서 예약글버튼을 누를때 발생합니다.(LoadParam 설정)"),
        Category("추가이벤트"),
        Browsable(true)]
        public event GridReservedMemoButtonClickEventHandler GridReservedMemoButtonClick;
        
        //2007.11.08 SaveEnd Event 추가
		[Description("저장이 끝났을때 발생합니다.(저장 성공여부에 따라 추가처리시 사용)"),
		Category("추가이벤트"),
		Browsable(true)]
		public event SaveEndEventHandler SaveEnd;
		#endregion

		#region Event Invoker (virtual)
		protected virtual void OnPreSaveLayout(GridRecordEventArgs e)
		{
			if (PreSaveLayout != null)
				PreSaveLayout(this, e);
		}
		protected virtual void OnGridColumnProtectModify(GridColumnProtectModifyEventArgs e)
		{
			if (GridColumnProtectModify != null)
				GridColumnProtectModify(this, e);
		}
		protected virtual void OnGridFindSelected(GridFindSelectedEventArgs e)
		{
			if (GridFindSelected != null)
				GridFindSelected(this, e);
		}
		protected virtual void OnGridFindClick(GridFindClickEventArgs e)
		{
			if (GridFindClick != null)
				GridFindClick(this, e);
		}
		protected virtual void OnItemValueChanging(ItemValueChangingEventArgs e)
		{
			if (ItemValueChanging != null)
				ItemValueChanging(this, e);
		}
		protected virtual void OnProcessKeyDown(KeyEventArgs e)
		{
			if (ProcessKeyDown != null)
				ProcessKeyDown(this, e);
		}
		protected virtual void OnGridButtonClick(GridButtonClickEventArgs e)
		{
			if (GridButtonClick != null)
				GridButtonClick(this, e);
		}
		protected virtual void OnGridDDLBSetting(GridDDLBSettingEventArgs e)
		{
			if (GridDDLBSetting != null)
				GridDDLBSetting(this, e);
		}
		protected virtual void OnEditStarting(GridEditStartingEventArgs e)
		{
			if (EditStarting != null)
				EditStarting(this, e);
		}
		protected virtual void OnGridMemoFormShowing(GridMemoFormShowingEventArgs e)
		{
			if (GridMemoFormShowing != null)
				GridMemoFormShowing(this, e);
		}
        protected virtual void OnGridReservedMemoButtonClick(GridReservedMemoButtonClickEventArgs e)
        {
            if (GridReservedMemoButtonClick != null)
                GridReservedMemoButtonClick(this, e);
        }
        //2007.11.08 SaveEnd Event Invoker 추가
		protected virtual void OnSaveEnd(SaveEndEventArgs e)
		{
			if (this.SaveEnd != null)
				SaveEnd(this, e);
		}
		#endregion

		#region ResetUpdate
		/// <summary>
		/// 자료상태를 Reset(UnChanged상태) 합니다.
		/// </summary>
		[Description("자료상태를 Reset합니다.")]
		public override void ResetUpdate()
		{
			//LayoutTable ResetUpdate
			this.LayoutTable.AcceptChanges();

			//DeletedDataTable Clear
			if (this.deletedRowTable != null)
				this.deletedRowTable.Clear();

			//InValidate
			this.InvalidateCells();
		}
		/// <summary>
		/// Grid의 자료를 Clear합니다.
		/// </summary>
		[Description("DataLayout 관련 Control 초기화합니다.")]
		public override void Reset()
		{
			//Editing상태이면 EndEdit(편집값 반영하지 않음)
			if (this.isEditing)
				this.EndEdit(true);
			
			// 삭제Table Clear
			if (this.deletedRowTable != null)
				this.deletedRowTable.Rows.Clear();

			base.Reset();
			//조회완료여부 Set
			this.DisplayCompleted = true;
		}
		/// <summary>
		/// 편집중은 값을 Grid에 설정합니다.
		/// </summary>
		/// <returns> 설정성공시 true, 실패시 false </returns>
		public override bool AcceptData()
		{
			//Editing중이면 EndEdit
			if (this.isEditing)
				this.EndEdit(false);

			//Error발생시
			if (this.HasErrors) return false;

			// Grid의 Row가 없으면 BindControl Reset, 있으면 BindControl AcceptData
			if (this.RowCount < 1)
				this.ResetBindControlDataValue();
			else if (!this.BindControlAcceptData()) return false;

			return true;
		}
		#endregion

		#region GetDisplayTextByInfo
		/// <summary>
		/// 컬럼정보를 이용하여 Display할 Text를 가져옵니다.
		/// </summary>
		/// <param name="info"> XGridCell 객체(컬럼정보) </param>
		/// <param name="dataValue"> 실제 값 </param>
		/// /// <param name="checkValue"> (out) CheckBox형에서 dataValue가 CheckValue인지 여부 </param>
		/// <returns> Display Text </returns>
		protected string GetDisplayTextByInfo(XGridCell info, object dataValue, out bool checkValue)
		{
			//ComboBox형이면 ValueMember.DisplayMember로, CheckBox이면 CheckedValue.CheckedText로 DisplayText를 보여줌
			//EditBox,FindBox형은 dataValue를 그대로 Display함으로 DisplayText가 따로 없음
			string displayText = string.Empty;
			XEditGridCell cellInfo = info as XEditGridCell;
			checkValue = false;

			// BinaryType은 displayText 없음
			if (info.CellType == XCellDataType.Binary) return displayText;
			if (cellInfo == null) return displayText;

			switch(info.EditorStyle)
			{
				case XCellEditorStyle.ComboBox:
					try
					{
						bool isFind = false;
						//AComboBox의 AComboItems에서 value와 일치하는 displayItem return;
						foreach (XComboItem colItem in ((XComboBox)cellInfo.CellEditor.Editor).ComboItems)
						{
							//dataValue와 일치하는 DisplayItem Get
							if (colItem.ValueItem.Equals(dataValue.ToString()))
							{
								displayText = colItem.DisplayItem;
								isFind = true;
								break;
							}
						}
						//Find가 안되었으면 dataValue를 보여줌
						if (!isFind)
							displayText = dataValue.ToString();
					}
					catch{}
					break;
				case XCellEditorStyle.ListBox:
					try
					{
						bool isFind = false;
						//AComboBox의 AComboItems에서 value와 일치하는 displayItem return;
						foreach (XComboItem colItem in ((XDictListBox)cellInfo.CellEditor.Editor).ListItems)
						{
							//dataValue와 일치하는 DisplayItem Get
							if (colItem.ValueItem.Equals(dataValue.ToString()))
							{
								displayText = colItem.DisplayItem;
								isFind = true;
								break;
							}
						}
						//Find가 안되었으면 dataValue를 보여줌
						if (!isFind)
							displayText = dataValue.ToString();
					}
					catch{}
					break;
				case XCellEditorStyle.CheckBox:
					try
					{
						//CheckBox형식은 displayText = dataValue가 CheckedValue이면 CheckedText를 아니면 UnCheckedText 
						//Cell::CellDisplayObject 에서 Cell의 Value와 비교하여 Icon을 다르게 가져와야함
						if (dataValue.ToString().Equals(cellInfo.CheckedValue))
						{
							displayText = cellInfo.CheckedText;
							checkValue = true;  // Check Value
						}
						else
						{
							displayText = cellInfo.UnCheckedText;
							checkValue = false;  //UnCheckValue
						}
					}
					catch{}
					break;
				case XCellEditorStyle.FindBox:
					displayText = dataValue.ToString();
					break;
				case XCellEditorStyle.MemoBox:
					displayText = "";
					//메모박스형이 DisplayMemoText이면 Data가 있을때 DisplayText Set
					if ((dataValue != null) && (dataValue.ToString() != "") && ((XEditGridCell) info).DisplayMemoText)
					{
						int index = dataValue.ToString().IndexOf('\n');
						if (index > 0)
							displayText = dataValue.ToString().Substring(0, index) + "...";
						else
							displayText = dataValue.ToString();
					}
					break;
				case XCellEditorStyle.ButtonBox:
					displayText = cellInfo.ButtonText;  //DisplayText는 ButtonText
					break;
				case XCellEditorStyle.DatePicker:
					displayText = this.GetDisplayTextByInfo(info, dataValue);
					break;
				case XCellEditorStyle.UpDownBox:  //2006.07.17 UpDownBox 반영
					displayText = dataValue.ToString();
					break;
				case XCellEditorStyle.EditBox:
					displayText = this.GetDisplayTextByInfo(info, dataValue);
					break;
			}
			return displayText;
		}
		/// <summary>
		/// 컬럼정보를 이용하여 초기값을 가져옵니다.
		/// </summary>
		/// <param name="info"> XEditGridCell 객체(컬럼정보) </param>
		/// <param name="fieldValueType"> Field Data형식으로 반환여부 </param>
		/// <returns> 초기값 </returns>
		protected virtual object GetInitValue(XEditGridCell info)
		{
			object initValue = string.Empty;
			DateTime dateTime = DateTime.Now;
			TimeSpan time ;
			if (info.InitValue == string.Empty) return initValue;
			switch (info.CellType)
			{
				case XCellDataType.Date:  //yyyymmdd or date형
					if (info.InitValue.ToUpper() == "TODAY")
					{
						//YYYYMMDD
						initValue = dateTime.ToString("yyyyMMdd");
					}
					else if (TypeCheck.IsDateTime(info.InitValue))
					{
						dateTime = DateTime.Parse(info.InitValue);
						initValue = dateTime.ToString("yyyyMMdd");
					}
					break;
				case XCellDataType.DateTime:  //yyyymmddhhmiss
					if (info.InitValue.ToUpper() == "TODAY")
					{
						initValue = dateTime;
					}
					else if(TypeCheck.IsDateTime(info.InitValue))
					{
						initValue = DateTime.Parse(info.InitValue);
					}
					break;
				case XCellDataType.Time:  //HHMISS
					if (info.InitValue.ToUpper() == "NOW")
					{
						time = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second); 
						//HHMISS
						initValue = time.Hours.ToString("00") + time.Minutes.ToString("00") + time.Seconds.ToString("00");
					}
					else if(TypeCheck.IsTime(info.InitValue))
					{
						time = TimeSpan.Parse(info.InitValue);
						initValue = time.Hours.ToString("00") + time.Minutes.ToString("00") + time.Seconds.ToString("00");
					}
					break;
				case XCellDataType.Number:
					if (TypeCheck.IsLong(info.InitValue))
						initValue = Int64.Parse(info.InitValue);
					break;
				case XCellDataType.Decimal:
					if (TypeCheck.IsDouble(info.InitValue))
						initValue = Double.Parse(info.InitValue);
					break;
				case XCellDataType.String:
					initValue = info.InitValue;
					break;
				default:
					initValue = string.Empty;
					break;
			}
			return initValue;
		}
		/// <summary>
		/// 컬럼정보를 이용 해당 Row의 Cell에 데이타를 설정합니다.
		/// </summary>
		/// <param name="info"> XGridCell 객체(컬럼정보) </param>
		/// <param name="row"> Row의 값 </param>
		/// <param name="rowSpan"> RowSpan값 </param>
		/// <param name="dataValue"> 설정할 Data </param>
		/// <param name="linesPerRow"> 한 행의 Line 수 </param>
		protected override void DisplayCell(XGridCell info, int row, int rowSpan, object dataValue, int linesPerRow, int rowNumber)
		{
			string displayText = "";
			bool   isCheckValue = false;
			if (info.IsVisible)
			{
				//EditorStyle에 따라 DisplayText Get
				//ComboBox형이면 ValueMember.DisplayMember로, CheckBox이면 CheckedValue.CheckedText로 DisplayText를 보여줌
				displayText = this.GetDisplayTextByInfo(info, dataValue, out isCheckValue);

				//ButtonBox형이면 IsButtonShape True
				if (info.EditorStyle == XCellEditorStyle.ButtonBox)
				{
					// Button형은 DataValue 의미 없음 (ButtonText로 Value Set) 
					this[row , info.Col] = CreateContentCell(info, displayText, displayText, rowSpan, IsAlterateRow(linesPerRow,row));

					this[row , info.Col].IsButtonShape = true;
					this[row , info.Col].TextAlignment = ContentAlignment.MiddleCenter;
					//버튼 Scheme, Image 설정
					this[row , info.Col].ButtonSheme = ((XEditGridCell) info).ButtonScheme;
					this[row , info.Col].Image = ((XEditGridCell) info).ButtonImage;
					//ReadOnly 컬럼은 Disabled 상태로 설정
					if (info.IsReadOnly)
						this[row , info.Col].ButtonDisabled = true;
				}
				else
				{
					this[row , info.Col] = CreateContentCell(info, dataValue, displayText, rowSpan, IsAlterateRow(linesPerRow,row));
					this[row , info.Col].RowNumber = rowNumber;

					//Binary이면 Image Set
					if (info.CellType == XCellDataType.Binary)
						SetImageByBinaryData(this[row, info.Col], dataValue);
					//CheckBox형이면 Image SET
					if (info.EditorStyle == XCellEditorStyle.CheckBox)
						SetCheckStyleCellImage(this[row, info.Col], isCheckValue, displayText);
					//MemoBox형 이면 MemoImage SET
					if (info.EditorStyle == XCellEditorStyle.MemoBox)
						SetMemoStyleCellImage(this[row, info.Col], ((XEditGridCell) info).DisplayMemoText);
                }
			}
		}
		#endregion

		#region Override Event Invoker
		protected override void OnEnter(EventArgs e)
		{
			base.OnEnter(e);

			if (this.LayoutContainer != null)
				this.LayoutContainer.CurrMSLayout = this;
		}
		protected override void OnParentChanged(EventArgs e)
		{
			base.OnParentChanged(e);
			if (this.LayoutContainer != null)
			{
				if (LayoutContainer.CurrMSLayout == null)
					LayoutContainer.CurrMSLayout = this;
			}
		}
		/// <summary>
		/// Validating Event를 발생시킵니다.
		/// (override) 에러상태이면 Cancel = true 설정
		/// </summary>
		/// <param name="e"> CancelEventArgs </param>
		protected override void OnValidating(CancelEventArgs e)
		{
			// DataTable에 Error가 있으면 Focus 이동 불가
			e.Cancel = this.HasErrors;
			base.OnValidating(e);
		}
		/// <summary>
		/// MouseMove Event를 발생시킵니다.
		/// (override) 에러발생시는 Mouse이동 불가
		/// </summary>
		/// <param name="e"></param>
		protected override void OnMouseMove(MouseEventArgs e)
		{
			// Error상태이면 MouseMove에 의한 Selection 반영하지 않음
			if (this.HasErrors) return;

			base.OnMouseMove(e);
		}
		/// <summary>
		/// MouseDown Event를 발생시킵니다.
		/// (override) 편집중일때 편집종료후 에러발생시 다른 Cell로 이동 불가
		/// </summary>
		/// <param name="e"> MouseEventArgs </param>
		protected override void OnMouseDown(MouseEventArgs e)
		{
			//LeftButton down시 Editing일때 EndEdit
			if (this.isEditing && (e.Button == MouseButtons.Left))
			{
				this.EndEdit(false);
				// Error발생시는 FocusChange하지 않음
				if (this.HasErrors) return;
			}

			base.OnMouseDown(e);
		}
		/// <summary>
		/// Click Event를 발생시킵니다.
		/// (override) EditMode가 SingleClick이면 Edit Start
		/// </summary>
		/// <param name="e"> EventArgs </param>
		protected override void OnClick(EventArgs e)
		{
			// 정상상태이고, Multi선택하지 않았으면 Start Edit(SingleClick Mode) , MouseDownCell 기준
			if ((editType == XGridEditType.SingleClick) && (this.MouseDownCell != null) && (this.GridStatus == XGridStatus.Normal))
			{
				this.StartEdit();
				XEditGridCell cellInfo = this.CellInfoList[MouseDownCell.CellName] as XEditGridCell;
				if (cellInfo != null)
				{
					//CheckBoxStyle은 Check상태 변경
					if(cellInfo.EditorStyle == XCellEditorStyle.CheckBox)
					{
						if ((cellInfo.CellEditor != null) && (((Control)cellInfo.CellEditor.Editor).Visible))
							((XCheckCellEditor)cellInfo.CellEditor).TogglingCheckState();
					}
						//MemoBoxStyle은 MemoForm Display
					else if (cellInfo.EditorStyle == XCellEditorStyle.MemoBox)
					{
						if ((cellInfo.CellEditor != null) && (((Control)cellInfo.CellEditor.Editor).Visible))
							((XMemoCellEditor)cellInfo.CellEditor).DisplayMemoForm();
					}
						//ButtonBox형은 Button PerformClick
					else if (cellInfo.EditorStyle == XCellEditorStyle.ButtonBox)
					{
						if ((cellInfo.CellEditor != null) && (((Control)cellInfo.CellEditor.Editor).Visible))
							((XButton)cellInfo.CellEditor.Editor).PerformClick();
					}
				}
			}
			base.OnClick(e);
		}
		/// <summary>
		/// DoubleClick Event를 발생시킵니다.
		/// (override) EditMode가 DoubleClick이면 Edit Start
		/// </summary>
		/// <param name="e"> EventArgs </param>
		protected override void OnDoubleClick(EventArgs e)
		{
			//Start Edit(DoubleClick Mode)
			if ((editType == XGridEditType.DoubleClick) && (this.FocusCell != null) && (this.GridStatus == XGridStatus.Normal))
			{
				this.StartEdit();
				XEditGridCell cellInfo = this.CellInfoList[FocusCell.CellName] as XEditGridCell;
				if (cellInfo != null)
				{
					//CheckBoxStyle은 Check상태 변경
					if(cellInfo.EditorStyle == XCellEditorStyle.CheckBox)
					{
						if ((cellInfo.CellEditor != null) && (((Control)cellInfo.CellEditor.Editor).Visible))
							((XCheckCellEditor)cellInfo.CellEditor).TogglingCheckState();
					}
						//MemoBoxStyle은 MemoForm Display
					else if (cellInfo.EditorStyle == XCellEditorStyle.MemoBox)
					{
						if ((cellInfo.CellEditor != null) && (((Control)cellInfo.CellEditor.Editor).Visible))
							((XMemoCellEditor)cellInfo.CellEditor).DisplayMemoForm();
					}
						//ButtonBox형은 Button PerformClick
					else if (cellInfo.EditorStyle == XCellEditorStyle.ButtonBox)
					{
						if ((cellInfo.CellEditor != null) && (((Control)cellInfo.CellEditor.Editor).Visible))
							((XButton)cellInfo.CellEditor.Editor).PerformClick();
					}
				}
			}
			
			base.OnDoubleClick(e);
		}
		/// <summary>
		/// Leave Event를 발생시킵니다.
		/// (override) 편집중이면 편집종료
		/// </summary>
		/// <param name="e"></param>
		protected override void OnLeave(EventArgs e)
		{
			//Editing중이면 EndEdit
			if (this.isEditing)
				this.EndEdit(false);

			base.OnLeave(e);
		}
		/// <summary>
		/// VScrollPositionChanged Event를 발생시킵니다.
		/// (override) 편집중일때 Scroll된 영역에 맞추어 편집기 이동
		/// </summary>
		protected override void OnVScrollChanged(int newValue, int oldValue)
		{
			base.OnVScrollChanged(newValue, oldValue);
			//2005.10.20 에러상태에서 Scroll시에 EndEdit를 Call하면 변경된 값 적용에 대한 문제가 발생하므로 EndEdit를 call하지 않고
			//Editor를 Hide하는 방향으로 변경함
//			if (this.HasErrors) //에러 상태이면 입력값이 Validation 통과를 못했을때는 cancel = true
//				this.EndEdit(true);
//			else
//				this.EndEdit(false);  //Editing중이면 편집값 반영
			
			//Editing중일때 HScrollBar영역이나 Header영역에 있으면 Editor를 숨김
			if (this.isEditing)
			{
				XCell cell = this.FocusCell;
				XEditGridCell cellInfo = null;
				if (cell != null)
				{
					Rectangle dRect = cell.DisplayRectangle;
					cellInfo = this.CellInfos[cell.CellName] as XEditGridCell;

					if (cellInfo.CellEditor != null)
					{
						//HScrollBar가 있으면 ClientRect가 CustomClientRect가 차이가 발생함. 따라서, 해당 Cell의 DisplayRect가
						//HScrollBar영역에 있으면 Editor를 뒤로 숨김, 또한 FixedRowsHeight영역에 있으면 뒤로 숨김
						try
						{
							if ((dRect.Bottom > this.CustomClientRectangle.Bottom) || (dRect.Y < this.FixedRowsHeight))
							{
								((Control)cellInfo.CellEditor.Editor).SendToBack();
							}
							else
							{
								((Control)cellInfo.CellEditor.Editor).BringToFront();
							}
						}
						catch{}

						// Editor의 Position 변경
						((Control)cellInfo.CellEditor.Editor).Location = dRect.Location;
					}
				}
			}
		}
		/// <summary>
		/// HScrollPositionChanged Event를 발생시킵니다.
		/// (override) 편집중일때 Scroll된 영역에 맞추어 편집기 이동
		/// </summary>
		/// <param name="e"></param>
		protected override void OnHScrollChanged(int newValue, int oldValue)
		{
			base.OnHScrollChanged(newValue, oldValue);

			//2005.10.20 에러상태에서 Scroll시에 EndEdit를 Call하면 변경된 값 적용에 대한 문제가 발생하므로 EndEdit를 call하지 않고
			//Editor를 Hide하는 방향으로 변경함
//			if (this.HasErrors) //에러 상태이면 입력값이 Validation 통과를 못했을때는 cancel = true
//				this.EndEdit(true);
//			else
//				this.EndEdit(false);  //Editing중이면 편집값 반영
			
			//Editing중일때 HScrollBar영역이나 Header영역에 있으면 Editor를 숨김
			if (this.isEditing)
			{
				XCell cell = this.FocusCell;
				XEditGridCell cellInfo = null;
				if (cell != null)
				{
					Rectangle dRect = cell.DisplayRectangle;
					cellInfo = this.CellInfos[cell.CellName] as XEditGridCell;

					if (cellInfo.CellEditor != null)
					{
						//HScrollBar가 있으면 ClientRect가 CustomClientRect가 차이가 발생함. 따라서, 해당 Cell의 DisplayRect가
						//HScrollBar영역에 있으면 Editor를 뒤로 숨김, 또한 FixedRowsHeight영역에 있으면 뒤로 숨김
						try
						{
							if ((dRect.Right > this.CustomClientRectangle.Right) || (dRect.X < this.FixedColsWidth))
							{
								((Control)cellInfo.CellEditor.Editor).SendToBack();
							}
							else
							{
								((Control)cellInfo.CellEditor.Editor).BringToFront();
							}
						}
						catch{}

						// Editor의 Position 변경
						((Control)cellInfo.CellEditor.Editor).Location = dRect.Location;
					}
				}
			}
		}
		#endregion

		#region StartEdit, EndEdit
		/// <summary>
		/// 편집을 시작합니다.
		/// </summary>
		public virtual void StartEdit()
		{
			this.readOnlyColumnEditing = false;

			// 1.Focus cell이 있으면 Edit가능
			if (this.FocusCell == null) return;

		
			//ReadOnly이면 Return
			if (this.ReadOnly) return;
			
			//FocusCell이 Content가 아니면 Edit불가
			if (FocusCell.Personality != XCellPersonality.Content) return;
			
			try
			{
				this.isEditing = true;  // Editing중

				// 현재Row의 상태를 고려해, ReadOnly이거나, 수정불가시는 return
				XEditGridCell cellInfo = this.CellInfoList[FocusCell.CellName] as XEditGridCell;

				if (cellInfo == null) return;

				// Editor가 없으면 Return
				if (cellInfo.CellEditor == null) return;

				//메모박스형 Editor의 편집불가여부 Clear
				if (cellInfo.EditorStyle == XCellEditorStyle.MemoBox)
					cellInfo.CellEditor.Editor.Protect = false;

				//ReadOnly이면 Editor보여주지 않음 
				if (cellInfo.IsReadOnly)
				{
					//메모형 Cell은 Editor를 보여주고 MemoBox에서 편집불가처리
					if (cellInfo.EditorStyle == XCellEditorStyle.MemoBox)
					{
						//Editor의 Protect 설정
						cellInfo.CellEditor.Editor.Protect = true;
						//StartEdit
						cellInfo.CellEditor.StartEdit(FocusCell);
					}
					else
					{
						//Flag Set
						this.readOnlyColumnEditing = true;
					}
					return;
				}
				//버튼형컬럼인 경우 FocusCell의 ButtonDisiabled = true이면 Edit 불가
				if ((cellInfo.EditorStyle == XCellEditorStyle.ButtonBox) && FocusCell.ButtonDisabled)
				{
					//Flag Set
					this.readOnlyColumnEditing = true;
					return;
				}
				//!IsUpdatable일때 DataRow의 상태가 Added가 아니면 수정불가
				int rowNumber = this.CurrentRowNumber;
				DataRow dataRow = this.LayoutTable.Rows[rowNumber];
				if (!cellInfo.IsUpdatable)
				{
					if (dataRow.RowState != DataRowState.Added)
					{
						//메모형 Cell은 Editor를 보여주고 MemoBox에서 편집불가처리
						if (cellInfo.EditorStyle == XCellEditorStyle.MemoBox)
						{
							//Editor의 Protect 설정
							cellInfo.CellEditor.Editor.Protect = true;
							//StartEdit
							cellInfo.CellEditor.StartEdit(FocusCell);
						}
						else
						{
							//Flag Set
							this.readOnlyColumnEditing = true;
						}
						return;
					}
				}
				
				//Protect Expression 분석
				object result = string.Empty;
				//개발자가 Coding한 조건에 따라 ReadOnly설정
				if (this.GridColumnProtectModify != null)
				{
					GridColumnProtectModifyEventArgs me = new GridColumnProtectModifyEventArgs(cellInfo.CellName, rowNumber, dataRow, cellInfo.IsReadOnly);
					OnGridColumnProtectModify(me);
					//Protect이면 return
					if (me.Protect)
					{
						//메모형 Cell은 Editor를 보여주고 MemoBox에서 편집불가처리
						if (cellInfo.EditorStyle == XCellEditorStyle.MemoBox)
						{
							//Editor의 Protect 설정
							cellInfo.CellEditor.Editor.Protect = true;
							//StartEdit
							cellInfo.CellEditor.StartEdit(FocusCell);
						}
						else
						{
							this.readOnlyColumnEditing = true;
						}
						return;
					}
				}
				
				//2005.10.20 EditStarting Event Call
				if (this.EditStarting != null)
				{
					GridEditStartingEventArgs ee = new GridEditStartingEventArgs(cellInfo.CellName, rowNumber, dataRow);
					OnEditStarting(ee);
				}
				//StartEdit
				cellInfo.CellEditor.StartEdit(FocusCell);
			}
			catch{}
		}
		
		// Edit를 끝내고, Table에도 Data Set(나중에 추가필요)
		/// <summary>
		/// 편집을 종료합니다.
		/// </summary>
		/// <param name="cancel"> 편집중인 값 미반영여부(미반영시 값 반영하지 않음) </param>
		/// <returns> 편집종료 성공시 true, 실패시 false </returns>
		public virtual bool EndEdit(bool cancel)
		{
			object originalValue = null;
			
			//Editing중이 아니면 Return
			if (!this.isEditing) return true;

			this.isEditing = false; // Editing End

			//ReadOnly Return
			if (this.ReadOnly) return true;

			// ReadOnly Column Editing이면 return
			if (this.readOnlyColumnEditing) return true;
			
			int currRow = this.CurrentRowNumber;
			// 현재행 Validation Check
			if ((currRow < 0) || (currRow >= this.LayoutTable.Rows.Count)) return true;

			XEditGridCell cellInfo = null;
			try
			{
				cellInfo = this.CellInfoList[FocusCell.CellName] as XEditGridCell;
				//Editor정보가 없으면 Return
				if (cellInfo == null) return true;
				if (cellInfo.CellEditor == null) return true;
				//ButtonBox형은 값 변경 없음, EndEdit후 Return
				if (cellInfo.EditorStyle == XCellEditorStyle.ButtonBox)
				{
					cellInfo.CellEditor.EndEdit(cancel);
					return true;
				}

				// cancel이면 HasError Clear
				if (cancel) this.HasErrors = false;
				
				object dataValue = cellInfo.CellEditor.Editor.DataValue;

				// cancel이 아니고, 편집중인 값과 현재값이 다르면 Apply Edit				
				//if (!cancel && !Object.Equals(FocusCell.Value, dataValue))
				if (!cancel && !FocusCell.Value.ToString().Equals(dataValue.ToString()))
				{
					//DataRow 편집시작 알림
					this.LayoutTable.Rows[currRow].BeginEdit();

					// 원 Data 보관
					originalValue = this.LayoutTable.Rows[currRow][FocusCell.CellName];
					//2005.09.08 Number형 일때 DataValue가 ""이면 DataRow에 설정시에 에러가 발생하므로 이 경우는 DBNull.Value로 SET
					if (dataValue.ToString() == "")
						dataValue = DBNull.Value;
					//DataTable Data Set
					this.LayoutTable.Rows[currRow][FocusCell.CellName] = dataValue;
					//OrigDataTable에도 Data SET
					//필터링중이면 RowIndexList에서 행번호를 구하여 SET, 아니면 RowNum 적용
					if (this.IsFiltering)
						this.OrigLayoutTable.Rows[(int) this.OrigTableRowIndexList[currRow]][FocusCell.CellName] = dataValue;
					else
						this.OrigLayoutTable.Rows[currRow][FocusCell.CellName] = dataValue;
					
					//XEditGridColumnChanged Event call
					GridColumnChangedEventArgs e = new GridColumnChangedEventArgs(currRow, FocusCell.CellName, this.LayoutTable.Rows[currRow], dataValue);
					OnGridColumnChanged(e);
					if (e.Cancel)
					{
						// 에러발생시에 원데이타로 복구
						this.LayoutTable.Rows[currRow][FocusCell.CellName] = originalValue;
						//필터링중이면 RowIndexList에서 행번호를 구하여 SET, 아니면 RowNum 적용
						if (this.IsFiltering)
							this.OrigLayoutTable.Rows[(int) this.OrigTableRowIndexList[currRow]][FocusCell.CellName] = originalValue;
						else
							this.OrigLayoutTable.Rows[currRow][FocusCell.CellName] = originalValue;
						HasErrors = true;
						// Cell의 값 변경
						cellInfo.CellEditor.ApplyEdit();
						// 계속 Editing 중 
						this.isEditing = true;
						// SelectText
						cellInfo.CellEditor.SelectText();
					}
					else
					{
						//2005.10.24 String형 Byte단위 길이 Check 추가
						if (!CheckByteLength(cellInfo, dataValue))  //Byte단위 문자열 길이초과시에는 Edit종료불가
						{
							HasErrors = true;
							// Cell의 값 변경
							cellInfo.CellEditor.ApplyEdit();
							// 계속 Editing 중 
							this.isEditing = true;
							// SelectText
							cellInfo.CellEditor.SelectText();
						}
						else
						{
							//Clear
							HasErrors = false;
					
							//EndEdit
							cellInfo.CellEditor.EndEdit(cancel);

							//InvalidateRow(Row전체 Invalidate)
							if (this.FocusCell != null)
								this.InvalidateRow(this.FocusCell.Row);
						}
					}
				}
				else  //Value가 바뀌지 않았을때도 계속 해당 Cell에 EditMode를 유지하기 위해 Error이면 계속 StartEdit
				{
					// 에러발생시는 Edit중 SET
					if (this.HasErrors)
					{
						this.isEditing = true;
						// SelectText
						cellInfo.CellEditor.SelectText();
					}
						// 에러가 발생하지 않으면 EndEdit
					else
					{
						cellInfo.CellEditor.EndEdit(cancel);
					}
				}
			}
			catch(Exception xe)
			{
				if ((cellInfo != null) && (cellInfo.CellEditor != null))
					cellInfo.CellEditor.EndEdit(true);
				//행오류, Edit Clear (다시 입력시 DataRowState반영되도록)
				this.LayoutTable.Rows[currRow].CancelEdit();
				Debug.WriteLine("XEditGrid::EndEdit 에러["+ xe.Message + "]");
			}
			finally
			{
                //MED-6833 edited on 2016.01.13
                if (this.LayoutTable.Rows.Count > 0)
                {
                    //DataRow 편집종료
                    this.LayoutTable.Rows[currRow].EndEdit(); 
                }
			}

			return !this.HasErrors;
		}
		protected virtual bool CheckByteLength(XEditGridCell cellInfo, object dataValue)
		{
			//String,StringFix5형, EditorStyle이 EditBox,FindBox일떄 Mask가 없을떄 2Byte문자고려하여 dataValue를 CellLen가 비교하여
			//크면 Validation통과 못하게 Check함
			if ((cellInfo.EditorStyle == XCellEditorStyle.EditBox) || (cellInfo.EditorStyle == XCellEditorStyle.FindBox))
			{
				if ((cellInfo.CellType == XCellDataType.String) && (cellInfo.Mask == ""))
				{
					string data = dataValue.ToString();
					this.ShowErrMsg("");  //Msg Clear
					if ((data != "") && (Service.BaseEncoding.GetByteCount(data) > cellInfo.CellLen))
					{
						string msg = XMsg.GetMsg("M025"); //입력한 문자열이 유효한 길이를 초과하였습니다."
						this.ShowErrMsg(msg);
						return false;
					}
				}
			}
			return true;
		}
		#endregion 

		#region InitailizeColumns  Method
		/// <summary>
		/// 컬럼정보로 Grid를 초기화합니다.
		/// </summary>
		public override void InitializeColumns()
		{
			//Base Call
			base.InitializeColumns();

			//DesignMode가 아니면
			if (!this.DesignMode)
			{
				try
				{
					object defaultValue = null;

					this.autoInsertColumnList.Clear();
				
					foreach (XEditGridCell info in this.CellInfos)
					{
						//LayoutTable의 Column에 DefaultValue Set
						defaultValue = this.GetInitValue(info);
						if (defaultValue.ToString() == string.Empty) 
							defaultValue = DBNull.Value;
						this.LayoutTable.Columns[info.CellName].DefaultValue = defaultValue;

						//Visible한 Column + Not Binary 만 Editor Set
						if (info.IsVisible && (info.CellType != XCellDataType.Binary))
						{
							switch(info.EditorStyle)
							{
								case XCellEditorStyle.EditBox:
									info.CellEditor = InitTextCellEditor(info);
									break;
								case XCellEditorStyle.CheckBox:
									info.CellEditor = InitCheckCellEditor(info);
									break;
								case XCellEditorStyle.ComboBox:
									info.CellEditor = InitComboCellEditor(info);
									break;
								case XCellEditorStyle.FindBox:
									info.CellEditor = InitFindCellEditor(info);
									break;
								case XCellEditorStyle.MemoBox:
									info.CellEditor = InitMemoCellEditor(info);
									break;
								case XCellEditorStyle.ButtonBox:
									info.CellEditor = InitButtonCellEditor(info);
									break;
								case XCellEditorStyle.DatePicker:
									info.CellEditor = InitDatePickerCellEditor(info);
									break;
								case XCellEditorStyle.ListBox:
									info.CellEditor = InitListCellEditor(info);
									break;
								case XCellEditorStyle.UpDownBox:  //2006.07.17 UpDownBox 추가
									info.CellEditor = InitUpDownCellEditor(info);
									break;
								default:
									break;
							}

							//AutoInsertAtEnterKey할 컬럼 LIST SET
							if (this.applyAutoInsertion && info.AutoInsertAtEnterKey)
								this.autoInsertColumnList.Add(info.CellName);
							
						}
					}
                    //<PARENT_RESIZE> Parent Resize Event를 Handling 해서 화면 Resize시에 Editing중이면 EndEdit하게 변경
                    //Editing상태에서 Resize를 하면 Editor Control의 위치가 이상해짐을 방지.
                    this.Parent.Resize += new EventHandler(OnParentResize);
				}
				catch(Exception e)
				{
					string msg = XMsg.GetMsg("M026", e); //XEditGrid::InitializeColumns, 에러[" + e.Message + "]"
					ShowErrMsg(msg);
				}
			}
		}
        //<PARENT_RESIZE>
        private void OnParentResize(object sender, EventArgs e)
        {
            this.EndEdit(true);
        }
		#endregion

		#region Event Handler
		private void OnXDictListBoxClick(object sender, EventArgs e)
		{
			//ListBox형 편집기의 ListBox를 Click시에 에디트모드 종료처리
			//Double Click으로 할지, Click으로 할지는 협의후 확정하기(일단은 DoubleClick에서 처리함)
			//2005.11.29 Click시에 EndEdit하기
			this.EndEdit(false);
		}
		//EditMode에서 Double Click시에 DoubleClick Event call
		private void EditGrid_DoubleClicked(object sender, EventArgs e)
		{
			this.OnDoubleClick(e);
			//ListBox Double Click시는 EndEdit (ListBox는 Click시에 편집종료)
//			if (sender is XDictListBox)
//				this.EndEdit(false);
//			else
//				this.OnDoubleClick(e);
		}
		//FindBox의 Find후에 Selected된 ReturnValues처리(컬럼에 데이타 Setting)
		private void EditGrid_FindSelected(object sender, FindEventArgs e)
		{
			if (this.FocusCell == null) return;

			if (GridFindSelected != null)
			{
				//Validation에 의해 Error발생시 Error Clear
				if (this.HasErrors)
					this.HasErrors = false;

				GridFindSelectedEventArgs xe = new GridFindSelectedEventArgs(this.FocusCell.CellName, this.CurrentRowNumber, e.ReturnValues);
				GridFindSelected(this, xe);
			}
		}
		private void EditGrid_FindClick(object sender, CancelEventArgs e)
		{
			if (this.FocusCell == null) return;
			if (GridFindClick != null)
			{
				GridFindClickEventArgs xe = new GridFindClickEventArgs(FocusCell.CellName, this.CurrentRowNumber, e.Cancel);
				OnGridFindClick(xe);
				//Cancel Set
				e.Cancel = xe.Cancel;
			}
		}
		private void EditGrid_ItemValueChanging(object sender, EventArgs e)
		{
			try
			{
				if (this.FocusCell == null) return;

				if (ItemValueChanging != null)
				{
					string colName = FocusCell.CellName;
					int	   rowNumber = this.CurrentRowNumber;
					DataRow dataRow = this.LayoutTable.Rows[rowNumber];
					object changeValue = ((IEditorControl) sender).DataValue;
					ItemValueChangingEventArgs xe = new ItemValueChangingEventArgs(rowNumber, colName, dataRow, changeValue);
					OnItemValueChanging(xe);
					this.Invalidate(true);
				}
			}
			catch{}
		}
		internal void EditGrid_DDLBSetting(object sender, EventArgs e)
		{
			if (this.GridDDLBSetting != null)
			{
				string colName = ((Control) sender).Name;
				GridDDLBSettingEventArgs xe = new GridDDLBSettingEventArgs(colName);
				OnGridDDLBSetting(xe);
			}
		}
		private void EditGrid_ButtonClick(object sender, EventArgs e)
		{
			if (this.FocusCell == null) return;

			if (this.GridButtonClick != null)
			{
				string colName = FocusCell.CellName;
				int	   rowNumber = this.CurrentRowNumber;
				DataRow dataRow = this.LayoutTable.Rows[rowNumber];
				GridButtonClickEventArgs xe = new GridButtonClickEventArgs(colName, rowNumber, dataRow);
				OnGridButtonClick(xe);
			}
		}
		private void EditGrid_MemoFormShowing(object sender, CancelEventArgs e)
		{
			if (this.FocusCell == null) return;

			if (this.GridMemoFormShowing != null)
			{
				string colName = FocusCell.CellName;
				int	   rowNumber = this.CurrentRowNumber;
				DataRow dataRow = this.LayoutTable.Rows[rowNumber];
				GridMemoFormShowingEventArgs xe = new GridMemoFormShowingEventArgs(rowNumber, colName, dataRow, e.Cancel);
				OnGridMemoFormShowing(xe);
				//Cancel 전달
				e.Cancel = xe.Cancel;
			}
		}
        private void EditGrid_ReservedMemoButtonClick(object sender, EventArgs e)
        {
            if (this.FocusCell == null) return;

            if (this.GridReservedMemoButtonClick != null)
            {
                string colName = FocusCell.CellName;
                int rowNumber = this.CurrentRowNumber;
                DataRow dataRow = this.LayoutTable.Rows[rowNumber];
                GridReservedMemoButtonClickEventArgs xe = new GridReservedMemoButtonClickEventArgs(rowNumber, colName, dataRow);
                OnGridReservedMemoButtonClick(xe);
            }
        }
        #endregion

		#region InitCellEditor Methods
		/// <summary>
		/// TextBox형 컬럼의 편집기를 설정합니다.
		/// </summary>
		/// <param name="info"> XEditGridCell 객체(컬럼정보) </param>
		/// <returns> ICellEditor 객체 </returns>
		protected virtual ICellEditor InitTextCellEditor(XEditGridCell info)
		{
			ICellEditor cellEditor = new XTextCellEditor(info);
			//Double Click
			((Control)cellEditor.Editor).DoubleClick += new EventHandler(EditGrid_DoubleClicked);

			return cellEditor;
		}
		/// <summary>
		/// ComboBox형 컬럼의 편집기를 설정합니다.
		/// </summary>
		/// <param name="info"> XEditGridCell 객체(컬럼정보) </param>
		/// <returns> ICellEditor 객체 </returns>
		protected virtual ICellEditor InitComboCellEditor(XEditGridCell info)
		{
			// ComboCellEditorInfo Get 
			ICellEditor cellEditor = new XComboCellEditor(info, this);
			//Double Click
			((XDictComboBox)cellEditor.Editor).DoubleClick += new EventHandler(EditGrid_DoubleClicked);
			//ItemValueChanging
			((XDictComboBox)cellEditor.Editor).SelectedIndexChanged += new EventHandler(EditGrid_ItemValueChanging);
			//DDLBSetting Event Handling (UserSQL을 쓸때 BindVarSet)
			//2005.11.28 DDLBSetting Event 연결은 SQL설정전에 해야하므로 XComboCellEditor 생성자에서 처리함
			//((XDictComboBox)cellEditor.Editor).DDLBSetting += new ServiceStartEventHandler(EditGrid_DDLBSetting);


			return cellEditor;
		}
		/// <summary>
		/// ListBox형 컬럼의 편집기를 설정합니다.
		/// </summary>
		/// <param name="info"> XEditGridCell 객체(컬럼정보) </param>
		/// <returns> ICellEditor 객체 </returns>
		protected virtual ICellEditor InitListCellEditor(XEditGridCell info)
		{
			// ComboCellEditorInfo Get 
			ICellEditor cellEditor = new XListCellEditor(info, this);
			//Double Click (Double Click 시에 편집종료하지 않고 Click시에 편집종료)
			//((XDictListBox)cellEditor.Editor).DoubleClick += new EventHandler(EditGrid_DoubleClicked);
			//ItemValueChanging
			((XDictListBox)cellEditor.Editor).SelectedIndexChanged += new EventHandler(EditGrid_ItemValueChanging);
			//DDLBSetting Event Handling (UserSQL을 쓸때 BindVarSet)
			//2005.11.28 DDLBSetting Event 연결은 SQL설정전에 해야하므로 XComboCellEditor 생성자에서 처리함
			//((XDictListBox)cellEditor.Editor).DDLBSetting += new ServiceStartEventHandler(EditGrid_DDLBSetting);
			//Click시에 편집종료할 수 있도록 Event 연결
			((XDictListBox)cellEditor.Editor).Click += new EventHandler(OnXDictListBoxClick);


			return cellEditor;
		}
		/// <summary>
		/// FindBox형 컬럼의 편집기를 설정합니다.
		/// </summary>
		/// <param name="info"> XEditGridCell 객체(컬럼정보) </param>
		/// <returns> ICellEditor 객체 </returns>
		protected virtual ICellEditor InitFindCellEditor(XEditGridCell info)
		{
			ICellEditor cellEditor = new XFindCellEditor(info);
			//Double Click
			((XFindBox)cellEditor.Editor).DoubleClick += new EventHandler(EditGrid_DoubleClicked);
			//FindClick
			((XFindBox)cellEditor.Editor).FindClick += new CancelEventHandler(EditGrid_FindClick);
			//FindSelected
			((XFindBox)cellEditor.Editor).FindSelected	+=new FindEventHandler(EditGrid_FindSelected);

			return cellEditor;
		}
		/// <summary>
		/// CheckBox형 컬럼의 편집기를 설정합니다.
		/// </summary>
		/// <param name="info"> XEditGridCell 객체(컬럼정보) </param>
		/// <returns> ICellEditor 객체 </returns>
		protected virtual ICellEditor InitCheckCellEditor(XEditGridCell info)
		{
			ICellEditor cellEditor = new XCheckCellEditor(info);
			//Double Click
			((XCheckBox)cellEditor.Editor).DoubleClick += new EventHandler(EditGrid_DoubleClicked);
			//ItemValueChanging
			((XCheckBox)cellEditor.Editor).CheckedChanged += new EventHandler(EditGrid_ItemValueChanging);
			
			return cellEditor;
		}
		/// <summary>
		/// MemoBox형 컬럼의 편집기를 설정합니다.
		/// </summary>
		/// <param name="info"> XEditGridCell 객체(컬럼정보) </param>
		/// <returns> ICellEditor 객체 </returns>
		protected virtual ICellEditor InitMemoCellEditor(XEditGridCell info)
		{
			ICellEditor cellEditor = new XMemoCellEditor(info);
			//Double Click
			((XMemoBox)cellEditor.Editor).DoubleClick += new EventHandler(EditGrid_DoubleClicked);
			((XMemoBox)cellEditor.Editor).MemoFormShowing += new CancelEventHandler(EditGrid_MemoFormShowing);
            ((XMemoBox)cellEditor.Editor).ReservedMemoButtonClick += new EventHandler(EditGrid_ReservedMemoButtonClick);
            return cellEditor;
		}
		/// <summary>
		/// ButtonBox형 컬럼의 편집기를 설정합니다.
		/// </summary>
		/// <param name="info"> XEditGridCell 객체(컬럼정보) </param>
		/// <returns> ICellEditor 객체 </returns>
		protected virtual ICellEditor InitButtonCellEditor(XEditGridCell info)
		{
			ICellEditor cellEditor = new XButtonCellEditor(info);
			//Double Click
			((Control)cellEditor.Editor).DoubleClick += new EventHandler(EditGrid_DoubleClicked);
			((Control)cellEditor.Editor).Click		+= new EventHandler(EditGrid_ButtonClick);
			return cellEditor;
		}
		/// <summary>
		/// DatePicker형 컬럼의 편집기를 설정합니다.
		/// </summary>
		/// <param name="info"> AEditGridCell 객체(컬럼정보) </param>
		/// <returns> ICellEditor 객체 </returns>
		protected virtual ICellEditor InitDatePickerCellEditor(XEditGridCell info)
		{
			ICellEditor cellEditor = new XDatePickerCellEditor(info);
			//Double Click
			((Control)cellEditor.Editor).DoubleClick += new EventHandler(EditGrid_DoubleClicked);
			//PickerClick시 처리
			((XDatePicker)cellEditor.Editor).PickerClick += new CancelEventHandler(EditGrid_FindClick);
			return cellEditor;
		}
		/// <summary>
		/// UpDownBox형 컬럼의 편집기를 설정합니다.
		/// </summary>
		/// <param name="info"> uEditGridCell 객체(컬럼정보) </param>
		/// <returns> ICellEditor 객체 </returns>
		protected virtual ICellEditor InitUpDownCellEditor(XEditGridCell info)
		{
			ICellEditor cellEditor = new XUpDownCellEditor(info);
			//Double Click
			((Control)cellEditor.Editor).DoubleClick += new EventHandler(EditGrid_DoubleClicked);
			//ItemValueChanging
			((XNumericUpDown)cellEditor.Editor).ValueChanged += new EventHandler(EditGrid_ItemValueChanging);

			return cellEditor;
		}
		#endregion

		#region InsertRow, DeleteRow
		/// <summary>
		/// 현재행 아래에 행을 삽입합니다.
		/// </summary>
		public virtual int InsertRow()
		{
			return InsertRow(this.CurrentRowNumber, true);
		}
		/// <summary>
		/// 지정한 행뒤에 행을 삽입합니다.
		/// </summary>
		/// <param name="row"> 지정 행번호 </param>
		public virtual int InsertRow(int rowNumber)
		{
			//Insert후에 EditMode로 전환
			return InsertRow(rowNumber, true);
		}
		/// <summary>
		/// 지정한 행뒤에 행을 삽입합니다.
		/// </summary>
		/// <param name="row"> 지정 행번호 </param>
		/// <param name="isEditMode"> 편집모드로 전환여부 </param>
		public virtual int InsertRow(int row, bool isEditMode)
		{
			
			string msg = "";
			//필터링중이면 Insert불가
			if (this.IsFiltering)
			{
				msg = XMsg.GetMsg("M027"); //필터링중에는 행입력 불가합니다.
				ShowErrMsg(msg);
				return -1;
			}
			//Computed 컬럼이 있거나, Grouping된 상태에서는 행입력불가
			if (this.GroupInfos.Count > 0)
			{
				msg = XMsg.GetMsg("M028"); //그룹핑한 Grid는 행입력 불가합니다."
				ShowErrMsg(msg);
				return -1;
			}
			if (this.ComputedCellInfos.Count > 0)
			{
				msg = XMsg.GetMsg("M029"); //Computed컬럼이 사용된 Grid는 행입력 불가합니다."
				ShowErrMsg(msg);
				return -1;
			}
			int bfRowCount = this.DisplayedRowCount; //현재 Display된 Row의 갯수
			int bfRows = this.Rows;  // Display되는 Rows(Header포함)
			int rowPos = 0;
			int rowSpan = 1;
			int sourceIndex = 0;
			int destinationIndex = 0;
			int copyLength = 0;
			int startRowIndex = 0;  
			int rowNumber = row + 1;
			int linesPerRow = this.GetLinesPerRow();
			int dispRowNumber = 0;
			int rowHeaderIndex = 0;
			string displayText = string.Empty;
			bool   isCheckValue = false;
			object initValue = string.Empty;
			
			if (this.LayoutTable == null) return -1;
			
			// 그리기 멈춤
			this.Redraw = false;

			try
			{	
				// Row증가
				this.Rows += linesPerRow;

				// 맨 아래에 Row Add
				if (row < 0 || (row >= bfRowCount -1))
				{
					rowNumber = bfRowCount;
					// RowHeaderVisible이면 RowHeader SET
					if (this.RowHeaderVisible)
					{
						// RowNumber를 보여주어야 하면 Value에도 RowNumber SET(실제 Row수 + 1)
						dispRowNumber = bfRowCount + 1;
						if (this.ShowNumberAtRowHeader)
							this[bfRows,0] = CreateRowHeaderCell(dispRowNumber.ToString() , dispRowNumber, linesPerRow);
						else
							this[bfRows,0] = CreateRowHeaderCell(dispRowNumber.ToString() , "", linesPerRow);
					}

					foreach (XEditGridCell info in this.CellInfos)
					{
						// 초기값
						initValue = this.GetInitValue(info);
						if (info.IsVisible)
						{
							// 추가된 Header가 있으면 info의 xPos와 rowSpan을 XGridCells의 정보와 조정하여 Get
							if (this.AddedHeaderLine > 0)
							{
								this.CellInfos.GetCellPositionByXGridCell(info, linesPerRow, out rowPos, out rowSpan);
							}
							else
							{
								rowPos = info.Row;
								rowSpan = info.RowSpan;
							}
							// Grid Add
							displayText = GetDisplayTextByInfo(info, initValue, out isCheckValue);
							//Button형과 다른 Style을 구분하여 설정
							if (info.EditorStyle == XCellEditorStyle.ButtonBox)
							{
								// Button형은 DataValue 의미 없음 (ButtonText로 Value Set) 
								this[rowPos + bfRows , info.Col] = CreateContentCell(info, displayText, displayText, rowSpan, (rowNumber%2 == 1));
								this[rowPos + bfRows , info.Col].IsButtonShape = true;
								this[rowPos + bfRows , info.Col].TextAlignment = ContentAlignment.MiddleCenter;
								//버튼 Scheme, Image 설정
								this[rowPos + bfRows , info.Col].ButtonSheme = ((XEditGridCell) info).ButtonScheme;
								this[rowPos + bfRows , info.Col].Image = ((XEditGridCell) info).ButtonImage;
								//ReadOnly 컬럼은 Disabled 상태로 설정
								if (info.IsReadOnly)
									this[rowPos + bfRows , info.Col].ButtonDisabled = true;
							}
							else
							{
								this[rowPos + bfRows , info.Col] = CreateContentCell(info, initValue, displayText, rowSpan, (rowNumber%2 == 1));
								this[rowPos + bfRows , info.Col].RowNumber = rowNumber;
								//CheckBox형이면 Image SET
								if (info.EditorStyle == XCellEditorStyle.CheckBox)
									SetCheckStyleCellImage(this[rowPos + bfRows , info.Col], isCheckValue, displayText);
								//MemoBox형 이면 MemoImage SET
								if (info.EditorStyle == XCellEditorStyle.MemoBox)
									SetMemoStyleCellImage(this[rowPos + bfRows , info.Col], info.DisplayMemoText);
							}
						}
					}
					//LayoutTable에 InsertAt
					//Display미완료시도 행삽입가능하므로 Rows의 중간에 Insert
					this.LayoutTable.Rows.InsertAt(this.LayoutTable.NewRow(), bfRowCount);
					this.OrigLayoutTable.Rows.InsertAt(this.OrigLayoutTable.NewRow(), bfRowCount);
					//한행 Insert되었으므로 DisplayCount 증가
					this.DisplayedRowCount += 1;
				}
				else // 중간에 Row Insert
				{
					//Copy시작 Index = Header의 수((AddedHeader수 + LinePerRow)*Cols) + DataRow의 수((row+1)*한Row의Line수*Cols)
					sourceIndex = (this.AddedHeaderLine + this.LinePerRow)*this.Cols + (row+1)*linesPerRow*this.Cols;
					//한 Row아래
					destinationIndex = sourceIndex + linesPerRow*this.Cols;
					// Copy수 = (bfRowCount - row -1)*한Row의Line수* Cols
					copyLength = (bfRowCount - row -1)*linesPerRow*this.Cols;
					Array.Copy(this.Cells, sourceIndex, this.Cells, destinationIndex, copyLength);
					// Copy된 Cell의 Row를 변경할 시작 Row = HeaderLine수 + row + 2의 Line수
					startRowIndex = this.AddedHeaderLine + this.LinePerRow + (row + 2)*linesPerRow;
					
					// 삽입된 Row의 Cells은 null로 Set
					for (int i = startRowIndex - linesPerRow ; i < startRowIndex ; i++)
						for (int j = 0 ; j < this.Cols ; j++)
							if (this[i,j] != null)
								Cells[i,j] = null;

					// RowHeaderVisible이면 RowHeader SET
					if (this.RowHeaderVisible)
					{
						// RowNumber를 보여주어야 하면 Value에도 RowNumber SET(실제 Row수 + 1)
						dispRowNumber = row + 2;
						rowHeaderIndex = this.AddedHeaderLine + this.LinePerRow + (row + 1)*linesPerRow;
						if (this.ShowNumberAtRowHeader)
							this[rowHeaderIndex,0] = CreateRowHeaderCell(dispRowNumber.ToString() , dispRowNumber,linesPerRow);
						else
							this[rowHeaderIndex,0] = CreateRowHeaderCell(dispRowNumber.ToString() , "", linesPerRow);

						//this[rowHeaderIndex,0].ColSpan = 1;
						//this[rowHeaderIndex,0].RowSpan = linesPerRow;
					}

					// Copy된 Cell의 Row를 변경
					XEditGridCell aGridCell = null;
					XCell cell = null;
					bool changeStyle = true;
					for (int i = startRowIndex ; i < this.Rows ; i++)
					{

						for (int j = 0 ; j < this.Cols ; j++)
						{
							cell = this[i,j];
							if (cell != null)
							{
								//RowNumer 증가
								cell.RowNumber++;

								cell.Row = i;
								changeStyle = true;
								//RowHeaderVisible일때 RowHeader는 Style변경하지 않음
								if (this.RowHeaderVisible && j == 0) changeStyle = false;
								if (changeStyle)
								{
									aGridCell = this.CellInfoList[cell.CellName] as XEditGridCell;
									// 교대로 반복되는 행이면 교대로 반복되는 행의 Style 적용
									// 단 버튼형은 적용하지 않음
									if ((aGridCell != null) && (aGridCell.EditorStyle != XCellEditorStyle.ButtonBox))
									{
										//속도향상을 위해 행과 교대로반복되는 행의 속성이 다를 경우에만 SET
										if (cell.RowNumber%2 == 1)
										{
											if (aGridCell.RowDrawMode != aGridCell.AlterateRowDrawMode)
												cell.DrawMode = aGridCell.AlterateRowDrawMode;
											if (aGridCell.RowFont != aGridCell.AlterateRowFont)
												cell.Font = aGridCell.AlterateRowFont;
											if (aGridCell.RowBackColor != aGridCell.AlterateRowBackColor)
												cell.BackColor = aGridCell.AlterateRowBackColor;
											if (aGridCell.RowGradientStart != aGridCell.AlterateRowGradientStart)
												cell.GradientStart = aGridCell.AlterateRowGradientStart;
											if (aGridCell.RowGradientEnd != aGridCell.AlterateRowGradientEnd)
												cell.GradientEnd = aGridCell.AlterateRowGradientEnd;
											if (aGridCell.RowForeColor != aGridCell.AlterateRowForeColor)
												cell.ForeColor = aGridCell.AlterateRowForeColor;
											if (cell.Image != null)
											{
												if (aGridCell.RowImage != aGridCell.AlterateRowImage)
													cell.Image= aGridCell.AlterateRowImage;
												if (aGridCell.RowImageAlign != aGridCell.AlterateRowImageAlign)
													cell.ImageAlignment = aGridCell.AlterateRowImageAlign;
												if (aGridCell.RowImageStretch != aGridCell.AlterateRowImageStretch)
													cell.ImageStretch = aGridCell.AlterateRowImageStretch;
											}
										}
										else //속도향상을 위해 행과 교대로반복되는 행의 속성이 다를 경우에만 SET
										{
											if (aGridCell.RowDrawMode != aGridCell.AlterateRowDrawMode)
												cell.DrawMode = aGridCell.RowDrawMode;
											if (aGridCell.RowFont != aGridCell.AlterateRowFont)
												cell.Font = aGridCell.RowFont;
											if (aGridCell.RowBackColor != aGridCell.AlterateRowBackColor)
												cell.BackColor = aGridCell.RowBackColor;
											if (aGridCell.RowGradientStart != aGridCell.AlterateRowGradientStart)
												cell.GradientStart = aGridCell.RowGradientStart;
											if (aGridCell.RowGradientEnd != aGridCell.AlterateRowGradientEnd)
												cell.GradientEnd = aGridCell.RowGradientEnd;
											if (aGridCell.RowForeColor != aGridCell.AlterateRowForeColor)
												cell.ForeColor = aGridCell.RowForeColor;
											if (cell.Image != null)
											{
												if (aGridCell.RowImage != aGridCell.AlterateRowImage)
													cell.Image= aGridCell.RowImage;
												if (aGridCell.RowImageAlign != aGridCell.AlterateRowImageAlign)
													cell.ImageAlignment = aGridCell.RowImageAlign;
												if (aGridCell.RowImageStretch != aGridCell.AlterateRowImageStretch)
													cell.ImageStretch = aGridCell.RowImageStretch;
											}
										}
										//CheckBox형이면 Image SET
										if (aGridCell.EditorStyle == XCellEditorStyle.CheckBox)
										{
											displayText = GetDisplayTextByInfo(aGridCell,cell.Value , out isCheckValue);
											SetCheckStyleCellImage(cell, isCheckValue, displayText);
										}
										//MemoBox형 이면 MemoImage SET
										if (aGridCell.EditorStyle == XCellEditorStyle.MemoBox)
											SetMemoStyleCellImage(cell, aGridCell.DisplayMemoText);
									}
								}
							}
						}
					}

					// RowHeaderVisible이면 이후행의 행번호 변경
					if (this.RowHeaderVisible)
					{
						for ( int i = startRowIndex ; i < this.Rows ; i++)
						{
							if (this[i,0] != null)
							{
								dispRowNumber = Int32.Parse(this[i,0].CellName) + 1;
								this[i,0].CellName = dispRowNumber.ToString();
								// RowNumber를 보여주면 Value도 SET
								if (this.ShowNumberAtRowHeader)
									this[i,0].Value = dispRowNumber;
							}
						}
					}
					
					//추가된 Row에 Cell Add
					foreach (XEditGridCell info in this.CellInfos)
					{
						// 초기값
						initValue = this.GetInitValue(info);

						//Visible한 Column만 Cell Set
						if (info.IsVisible)
						{
							// 추가된 Header가 있으면 info의 xPos와 rowSpan을 XGridCells의 정보와 조정하여 Get
							if (this.AddedHeaderLine > 0)
							{
								this.CellInfos.GetCellPositionByXGridCell(info, linesPerRow, out rowPos, out rowSpan);
							}
							else
							{
								rowPos = info.Row;
								rowSpan = info.RowSpan;
							}
							// Grid Add
							displayText = GetDisplayTextByInfo(info, initValue, out isCheckValue);
							if (info.EditorStyle == XCellEditorStyle.ButtonBox)
							{
								// Button형은 DataValue 의미 없음 (ButtonText로 Value Set) 
								this[rowPos + startRowIndex - linesPerRow , info.Col] = CreateContentCell(info, displayText, displayText, rowSpan, (rowNumber%2 == 1));
								this[rowPos + startRowIndex - linesPerRow , info.Col].IsButtonShape = true;
								this[rowPos + startRowIndex - linesPerRow , info.Col].TextAlignment = ContentAlignment.MiddleCenter;
								//버튼 Scheme, Image 설정
								this[rowPos + startRowIndex - linesPerRow , info.Col].ButtonSheme = ((XEditGridCell) info).ButtonScheme;
								this[rowPos + startRowIndex - linesPerRow , info.Col].Image = ((XEditGridCell) info).ButtonImage;
								//ReadOnly 컬럼은 Disabled 상태로 설정
								if (info.IsReadOnly)
									this[rowPos + startRowIndex - linesPerRow , info.Col].ButtonDisabled = true;
							}
							else
							{
								this[rowPos + startRowIndex - linesPerRow , info.Col] = CreateContentCell(info, initValue, displayText, rowSpan, (rowNumber%2 == 1));
								this[rowPos + startRowIndex - linesPerRow , info.Col].RowNumber = rowNumber;
								//CheckBox형이면 Image SET
								if (info.EditorStyle == XCellEditorStyle.CheckBox)
									SetCheckStyleCellImage(this[rowPos + startRowIndex - linesPerRow , info.Col], isCheckValue, displayText);
								//MemoBox형 이면 MemoImage SET
								if (info.EditorStyle == XCellEditorStyle.MemoBox)
									SetMemoStyleCellImage(this[rowPos + startRowIndex - linesPerRow , info.Col], info.DisplayMemoText);
							}
						}
					}
					//중간행에 삽입
					this.LayoutTable.Rows.InsertAt(this.LayoutTable.NewRow(), rowNumber);
					this.OrigLayoutTable.Rows.InsertAt(this.OrigLayoutTable.NewRow(),rowNumber);
					//한행 Insert되었으므로 DisplayCount 증가
					this.DisplayedRowCount += 1;
				}
			}
			catch(Exception e)
			{
				msg = XMsg.GetMsg("M30", e);//InsertRow, 에러[" + e.Message + "]"
				ShowErrMsg(msg);
				//Display된 행갯수 복구
				this.DisplayedRowCount = bfRowCount;
				this.Redraw = true;
				return - 1;
			}
			//FocusToItem (Focus컬럼이 있으면 해당컬럼으로 없으면 첫번째 컬럼으로
			if (this.CellInfoList.Contains(this.focusColumnName))
				this.SetFocusToItem(rowNumber, this.focusColumnName, isEditMode);
			else  
				this.SetFocusToItem(rowNumber, 0, isEditMode);
			
			// 그리기 시작
			this.Redraw = true;

			return rowNumber;

		}
		/// <summary>
		/// 현재행을 삭제합니다.
		/// </summary>
		public virtual bool DeleteRow()
		{
			return DeleteRow(this.CurrentRowNumber);
		}
		/// <summary>
		/// 지정한 행을 삭제합니다.
		/// </summary>
		/// <param name="row"> 행번호 </param>
		public virtual bool DeleteRow(int row)
		{
			string msg = "";
			//필터링중이면 Insert불가
			if (this.IsFiltering)
			{
				msg = XMsg.GetMsg("M031") ; // 필터링중에는 행삭제 불가합니다."
				ShowErrMsg(msg);
				return false;
			}
			//Computed 컬럼이 있거나, Grouping된 상태에서는 행입력불가
			if (this.GroupInfos.Count > 0)
			{
				msg = XMsg.GetMsg("M032") ; // 그룹핑한 Grid는 행삭제 불가합니다."
				ShowErrMsg(msg);
				return false;
			}
			if (this.ComputedCellInfos.Count > 0)
			{
				msg = XMsg.GetMsg("M033") ; // Computed컬럼이 사용된 Grid는 행삭제 불가합니다."
				ShowErrMsg(msg);
				return false;
			}
			DataRow dtRow = null;
			int		rowNumber = 0;
			int bfRowCount = this.DisplayedRowCount; // Display된 Row의 갯수
			int bfRows = this.Rows;  // Display되는 Rows(Header포함)
			int sourceIndex = 0;
			int destinationIndex = 0;
			int copyLength = 0;
			int startRowIndex = 0; 
			int linesPerRow = this.GetLinesPerRow();
			int dispRowNumber = 0;
			string	displayText = "";
			bool	isCheckValue = false;

			//Table의 RowCount < 1 return
			if (this.RowCount < 1) return false;
			//Row Validation Check
			if ((row < 0) || (row >= this.RowCount)) return false;

			// 삭제한 값을 저장할 DataTable Set
			if(deletedRowTable == null)
			{
				deletedRowTable = this.LayoutTable.Copy();
				deletedRowTable.Clear();
			}
			
			//2005.06.27 삭제하는 행이 Display된 행보다 큰 경우는 Cell 이동은 하지 않고, DataTable에서만 Row 삭제처리함.
			rowNumber = row;

			// 그리기 멈춤
			this.Redraw = false;

			try
			{
				//Editing중이면 EndEdit(삭제함으로 데이타를 반영하지 않음, true)
				if (this.isEditing)
					this.EndEdit(true);

				//Cell삭제
				// 맨마지막 Row이면 마지막 Row의 Cell을 Clear
				if (rowNumber == bfRowCount - 1)
				{
					// Rows감소
					this.Rows -= linesPerRow;
					//Display된 행갯수 감소
					this.DisplayedRowCount -= 1;
				}
				// 중간 Row 삭제, Array.Copy후 마지막 Row의 Cell Clear((rowNumber가 현재 Display된 RowNumber보다 작은 경우)
				else if (rowNumber < bfRowCount -1)
				{
					//Copy시작 Index = Header의 수((AddedHeader수 + LinePerRow)*Cols) + DataRow의 수((row+1)*한Row당Line수*Cols)
					sourceIndex = (this.AddedHeaderLine + this.LinePerRow)*this.Cols + (rowNumber+1)*linesPerRow*this.Cols;
					//해당 Row
					destinationIndex = sourceIndex - linesPerRow*this.Cols;
					// Copy수 = (bfRowCount - row -1)*LinePerRow* Cols
					copyLength = (bfRowCount - rowNumber -1)*linesPerRow*this.Cols;
					
					// Copy된 Cell의 Row를 변경할 시작 Row = Header의 수 + Row의 수
					startRowIndex = this.AddedHeaderLine + this.LinePerRow + rowNumber*linesPerRow;
					
					// 삭제되는 행의 Cell Remove
					for ( int i = startRowIndex ; i < startRowIndex + linesPerRow ; i++)
						for (int j = 0; j < this.Cols ; j++)
							if (this[i,j] != null)
								this.RemoveCell(i,j);

					Array.Copy(this.Cells, sourceIndex, this.Cells, destinationIndex, copyLength);
					
					// 마지막 행의 Cell 정보 null Set
					for ( int i = this.Rows - linesPerRow ; i < this.Rows ; i++)
						for (int j = 0; j < this.Cols ; j++)
							if (this[i,j] != null)
								Cells[i,j] = null;
					
					//Rows 감소
					this.Rows -= linesPerRow;

					// 삭제된 Cell 이후의 Cell의 Row값 변경
					XEditGridCell aGridCell = null;
					XCell cell = null;
					bool changeStyle = true;
					for (int i = startRowIndex ; i < this.Rows ; i++)
					{
						for (int j = 0; j < this.Cols ; j++)
						{
							cell = this[i,j];
							if (cell != null)
							{
								//RowNumber 감소
								cell.RowNumber--;

								changeStyle = true;
								cell.Row = i;
								//RowHeaderVisible일때 RowHeader는 Style변경하지 않음
								if (this.RowHeaderVisible && j == 0) changeStyle = false;

								//현재행 강조 
								if (this.RowHeaderVisible && (i == startRowIndex) && (j==0))
								{
									this[i,0].Font = this.CurrentRowHeaderFont;
									this[i,0].ForeColor = this.CurrentRowForeColor;
								}
								if (changeStyle)
								{
									aGridCell = this.CellInfoList[cell.CellName] as XEditGridCell;
									// 교대로 반복되는 행이면 교대로 반복되는 행의 Style 적용
									// 단 버튼형은 적용하지 않음
									if ((aGridCell != null) && (aGridCell.EditorStyle != XCellEditorStyle.ButtonBox))
									{
										if (cell.RowNumber%2 == 1)
										{
											if (aGridCell.RowDrawMode != aGridCell.AlterateRowDrawMode)
												cell.DrawMode = aGridCell.AlterateRowDrawMode;
											if (aGridCell.RowFont != aGridCell.AlterateRowFont)
												cell.Font = aGridCell.AlterateRowFont;
											if (aGridCell.RowBackColor != aGridCell.AlterateRowBackColor)
												cell.BackColor = aGridCell.AlterateRowBackColor;
											if (aGridCell.RowGradientStart != aGridCell.AlterateRowGradientStart)
												cell.GradientStart = aGridCell.AlterateRowGradientStart;
											if (aGridCell.RowGradientEnd != aGridCell.AlterateRowGradientEnd)
												cell.GradientEnd = aGridCell.AlterateRowGradientEnd;
											if (aGridCell.RowForeColor != aGridCell.AlterateRowForeColor)
												cell.ForeColor = aGridCell.AlterateRowForeColor;
											if (cell.Image != null)
											{
												if (aGridCell.RowImage != aGridCell.AlterateRowImage)
													cell.Image= aGridCell.AlterateRowImage;
												if (aGridCell.RowImageAlign != aGridCell.AlterateRowImageAlign)
													cell.ImageAlignment = aGridCell.AlterateRowImageAlign;
												if (aGridCell.RowImageStretch != aGridCell.AlterateRowImageStretch)
													cell.ImageStretch = aGridCell.AlterateRowImageStretch;
											}
										}
										else
										{
											if (aGridCell.RowDrawMode != aGridCell.AlterateRowDrawMode)
												cell.DrawMode = aGridCell.RowDrawMode;
											if (aGridCell.RowFont != aGridCell.AlterateRowFont)
												cell.Font = aGridCell.RowFont;
											if (aGridCell.RowBackColor != aGridCell.AlterateRowBackColor)
												cell.BackColor = aGridCell.RowBackColor;
											if (aGridCell.RowGradientStart != aGridCell.AlterateRowGradientStart)
												cell.GradientStart = aGridCell.RowGradientStart;
											if (aGridCell.RowGradientEnd != aGridCell.AlterateRowGradientEnd)
												cell.GradientEnd = aGridCell.RowGradientEnd;
											if (aGridCell.RowForeColor != aGridCell.AlterateRowForeColor)
												cell.ForeColor = aGridCell.RowForeColor;
											if (cell.Image != null)
											{
												if (aGridCell.RowImage != aGridCell.AlterateRowImage)
													cell.Image= aGridCell.RowImage;
												if (aGridCell.RowImageAlign != aGridCell.AlterateRowImageAlign)
													cell.ImageAlignment = aGridCell.RowImageAlign;
												if (aGridCell.RowImageStretch != aGridCell.AlterateRowImageStretch)
													cell.ImageStretch = aGridCell.RowImageStretch;
											}
										}
										//CheckBox형이면 Image SET
										if (aGridCell.EditorStyle == XCellEditorStyle.CheckBox)
										{
											displayText = GetDisplayTextByInfo(aGridCell,cell.Value , out isCheckValue);
											SetCheckStyleCellImage(cell, isCheckValue, displayText);
										}
										//MemoBox형 이면 MemoImage SET
										if (aGridCell.EditorStyle == XCellEditorStyle.MemoBox)
											SetMemoStyleCellImage(cell,aGridCell.DisplayMemoText);
									}
								}
							}
						}
					}

					//RowHeader Visible이면 삭제된행 이후의 행번호감소
					if (this.RowHeaderVisible)
					{
						for (int i = startRowIndex ; i < this.Rows ; i++)
						{
							if (this[i,0] != null)
							{
								dispRowNumber = Int32.Parse(this[i,0].CellName) - 1;
								this[i,0].CellName = dispRowNumber.ToString();
								// RowNumber를 보여주면 Value도 SET
								if (this.ShowNumberAtRowHeader)
									this[i,0].Value = dispRowNumber;
							}
						}
					}
					//Display된 행갯수 감소
					this.DisplayedRowCount -= 1;
					
				}

				//DataTable 삭제
				dtRow = this.LayoutTable.Rows[rowNumber];
				//데이타의 상태가 Modified, UnChanged Data는 DeletedRowTable에 저장
				if ((dtRow.RowState == DataRowState.Modified) || (dtRow.RowState == DataRowState.Unchanged))
					deletedRowTable.ImportRow(dtRow);
				//해당 Row의 DataRow 삭제
				this.LayoutTable.Rows.RemoveAt(rowNumber);
				//원 DataTable에서도 삭제
				this.OrigLayoutTable.Rows.RemoveAt(rowNumber);
			}
			catch(Exception e)
			{
				msg = XMsg.GetMsg("M034", e); //DeleteRow, 에러[" + e.Message + "]"
				ShowErrMsg(msg);
				//Display된 행갯수 복구
				this.DisplayedRowCount = bfRowCount;
				// 그리기 시작
				this.Redraw = true;
				return false;
			}

			//FocusToItem , 맨 마지막줄을 삭제했으면 한줄 위로 Focus
			int focusRow = rowNumber;
			if (rowNumber == bfRowCount - 1)
				focusRow = rowNumber -1;
			
			//Focus(Focuse컬럼명이 있으면 해당컬럼으로 없으면 첫번째 컬럼
			if ((this.RowCount > 0) && (focusRow < this.DisplayedRowCount))
			{
				if (this.CellInfoList.Contains(this.focusColumnName))
					this.SetFocusToItem(focusRow , this.focusColumnName , this.isEditing);
				else
				{
					if (this.RowHeaderVisible)
						this.SetFocusToItem(focusRow , 1, this.isEditing);
					else
						this.SetFocusToItem(focusRow , 0, this.isEditing);
				}
			}

			//Row가 하나도 없으면 BindControlReset, 있으면 SetBindControlValue
			if (this.RowCount == 0)
			{
				this.ResetBindControlDataValue();
				//2006.03.08 focusCell Clear (행을 완전 삭제시에 focusCell이 Clear안되어 CurrentRowNumber가 0로 설정됨)
				//focusCell과 PreRowNumber Reset
				this.focusCell = null;
				this.PreRowNumber = -1;
			}
			else if (focusRow < this.DisplayedRowCount)
				this.SetBindControlDataValue(focusRow);

			// 그리기 시작
			this.Redraw = true;

			return true;
		}
		#endregion

		#region ImportRowRange(DataRow를 그대로 지정한 행 아래에 Import)
		public override bool ImportRowRange(DataRow[] dtRows, int row)
		{
			string msg = "";
			//필터링중이면 Insert불가
			if (this.IsFiltering)
			{
				msg = XMsg.GetMsg("M035"); // 필터링중에는 행Import 불가합니다."
				ShowErrMsg(msg);
				return false;
			}
			//Computed 컬럼이 있거나, Grouping된 상태에서는 행입력불가
			if (this.GroupInfos.Count > 0)
			{
				msg = XMsg.GetMsg("M036"); // 그룹핑한 Grid는 행Import 불가합니다."
				ShowErrMsg(msg);
				return false;
			}
			if (this.ComputedCellInfos.Count > 0)
			{
				msg = XMsg.GetMsg("M037"); // Computed컬럼이 사용된 Grid는 행Import 불가합니다."
				ShowErrMsg(msg);
				return false;
			}
			//조회 미완료시는 Import불가
			if (!this.IsQueryCompleted)
			{
				msg = XMsg.GetMsg("M038"); // 조회미완료된 상태에서는 행Import 불가합니다."
				ShowErrMsg(msg);
				return false;
			}


			int bfRowCount = this.DisplayedRowCount; //현재 Display된 Row의 갯수
			int bfRows = this.Rows;  // Display되는 Rows(Header포함)
			int rowPos = 0;
			int rowSpan = 1;
			int sourceIndex = 0;
			int destinationIndex = 0;
			int copyLength = 0;
			int startRowIndex = 0;  
			int rowNumber = row ;
			int linesPerRow = this.GetLinesPerRow();
			int dispRowNumber = 0;
			int rowHeaderIndex = 0;
			string displayText = string.Empty;
			bool   isCheckValue = false;
			object dataValue = string.Empty;
			int importCount = dtRows.Length;
			ArrayList columnList = new ArrayList();
			DataRow dataRow = null, origDataRow = null;
			
			if (this.LayoutTable == null) return false;
			if (importCount <= 0) return false;
			
			//Cell의 Position 정보 계산
			this.CalcRowPosition();

			// 그리기 멈춤
			this.Redraw = false;

			try
			{	
				//dtRow에서 DataTable에서 포함된 컬럼중 Grid의 컬럼과 일치하는 컬럼 List Get
				foreach (XGridCell info in this.CellInfos)
					if (dtRows[0].Table.Columns.Contains(info.CellName))
						columnList.Add(info.CellName);
				// Row증가
				this.Rows += linesPerRow * importCount ;


				// 맨 아래에 Row Add
				if (row < 0 || (row >= bfRowCount -1))
				{
					for (int i = 0 ; i < importCount ; i++)
					{
						rowNumber = bfRowCount + i;
						// RowHeaderVisible이면 RowHeader SET
						if (this.RowHeaderVisible)
						{
							// RowNumber를 보여주어야 하면 Value에도 RowNumber SET(실제 Row수 + 1)
							dispRowNumber = bfRowCount + 1 + i;
							if (this.ShowNumberAtRowHeader)
								this[bfRows,0] = CreateRowHeaderCell(dispRowNumber.ToString() , dispRowNumber, linesPerRow);
							else
								this[bfRows,0] = CreateRowHeaderCell(dispRowNumber.ToString() , "", linesPerRow);
						}
						//행추가
						dataRow = this.LayoutTable.NewRow();
						origDataRow = this.OrigLayoutTable.NewRow();
						foreach (XEditGridCell info in this.CellInfos)
						{
							//Import하는 Row의 테이블의 컬럼과 일치하면
							if (columnList.Contains(info.CellName))
							{
								//GridTable, OrigGridTable의 행의 값 설정
								dataRow[info.CellName] = dtRows[i][info.CellName];
								origDataRow[info.CellName] = dtRows[i][info.CellName];
								//컬럼존재여부 확인
								if (info.IsVisible && (info.CellWidth > 0))
								{
									dataValue = dtRows[i][info.CellName];
									// 추가된 Header가 있으면 info의 xPos와 rowSpan을 AGridCells의 정보와 조정하여 Get
									if (this.AddedHeaderLine > 0)
									{
										this.CellInfos.GetCellPositionByXGridCell(info, linesPerRow, out rowPos, out rowSpan);
									}
									else
									{
										rowPos = info.Row;
										rowSpan = info.RowSpan;
									}
									// Grid Add
									displayText = GetDisplayTextByInfo(info, dataValue, out isCheckValue);

									//Button형과 다른 Style을 구분하여 설정
									if (info.EditorStyle == XCellEditorStyle.ButtonBox)
									{
										// Button형은 DataValue 의미 없음 (ButtonText로 Value Set)
										this[rowPos + bfRows , info.Col] = CreateContentCell(info, displayText, displayText, rowSpan, (rowNumber%2 == 1));
										this[rowPos + bfRows , info.Col].IsButtonShape = true;
										this[rowPos + bfRows , info.Col].TextAlignment = ContentAlignment.MiddleCenter;
										//버튼 Scheme, Image 설정
										this[rowPos + bfRows , info.Col].ButtonSheme = ((XEditGridCell) info).ButtonScheme;
										this[rowPos + bfRows , info.Col].Image = ((XEditGridCell) info).ButtonImage;
										//ReadOnly 컬럼은 Disabled 상태로 설정
										if (info.IsReadOnly)
											this[rowPos + bfRows , info.Col].ButtonDisabled = true;
									}
									else
									{
										this[rowPos + bfRows , info.Col] = CreateContentCell(info, displayText, displayText, rowSpan, (rowNumber%2 == 1));
										this[rowPos + bfRows , info.Col].RowNumber = rowNumber;
										//CheckBox형이면 Image SET
										if (info.EditorStyle == XCellEditorStyle.CheckBox)
											SetCheckStyleCellImage(this[rowPos + bfRows , info.Col], isCheckValue, displayText);
										//MemoBox형 이면 MemoImage SET
										if (info.EditorStyle == XCellEditorStyle.MemoBox)
											SetMemoStyleCellImage(this[rowPos + bfRows , info.Col], info.DisplayMemoText);
									}
								}
							}
						}

						//Row의 Height 자동조정
						if (this.ApplyAutoHeight)
							this.ApplyAutoHeightAtRow(bfRows, linesPerRow, dataRow, (rowNumber%2 == 0 ? false : true));

						this.LayoutTable.Rows.InsertAt(dataRow, rowNumber);
						this.OrigLayoutTable.Rows.InsertAt(origDataRow, rowNumber);
						//한행 Insert되었으므로 DisplayCount 증가
						this.DisplayedRowCount += 1;
						//Rows 증가
						bfRows += linesPerRow;
					}
				}
				else // 중간에 Row Insert
				{
					//Copy시작 Index = Header의 수((AddedHeader수 + LinePerRow)*Cols) + DataRow의 수(row*한Row의Line수*Cols)
					sourceIndex = (this.AddedHeaderLine + this.LinePerRow)*this.Cols + row*linesPerRow*this.Cols;
					//한 ImportCount 갯수만큼 아래로
					destinationIndex = sourceIndex + linesPerRow * importCount*this.Cols;
					// Copy수 = (bfRowCount - row)*한Row의Line수* Cols
					copyLength = (bfRowCount - row)*linesPerRow*this.Cols;
					Array.Copy(this.Cells, sourceIndex, this.Cells, destinationIndex, copyLength);
					// Copy된 Cell의 Row를 변경할 시작 Row = HeaderLine수 + row + importCount의 Line수
					startRowIndex = this.AddedHeaderLine + this.LinePerRow + (row + importCount)*linesPerRow;
					
					// 삽입된 Row의 Cells은 null로 Set
					for (int i = startRowIndex - importCount*linesPerRow ; i < startRowIndex ; i++)
						for (int j = 0 ; j < this.Cols ; j++)
							if (this[i,j] != null)
								Cells[i,j] = null;
					
					for (int i = 0 ; i < importCount ; i++)
					{
						// RowHeaderVisible이면 RowHeader SET
						if (this.RowHeaderVisible)
						{
							// RowNumber를 보여주어야 하면 Value에도 RowNumber SET(실제 Row수 + 1)
							dispRowNumber = row + 1 + i;
							rowHeaderIndex = this.AddedHeaderLine + this.LinePerRow + (row + i)*linesPerRow;
							if (this.ShowNumberAtRowHeader)
								this[rowHeaderIndex,0] = CreateRowHeaderCell(dispRowNumber.ToString() , dispRowNumber, linesPerRow);
							else
								this[rowHeaderIndex,0] = CreateRowHeaderCell(dispRowNumber.ToString() , "", linesPerRow);

							this[rowHeaderIndex,0].ColSpan = 1;
							this[rowHeaderIndex,0].RowSpan = linesPerRow;
						}
					}

					// Copy된 Cell의 Row를 변경
					XEditGridCell aGridCell = null;
					XCell cell = null;
					bool changeStyle = true;
					int  rowIndex = 0;
					for (int i = startRowIndex ; i < this.Rows ; i++)
					{
						//행 자동크기 조정 반영(한행의 line수를 고려하여 한 행 시작 Row일때만 적용함)
						if (this.ApplyAutoHeight && (i%linesPerRow == 0))
						{
							//자동크기를 조정할 DataRow는 아직 Import하는 행을 InsertAt하기 전이므로 기존의 RowNumber로 계산함)
							this.ApplyAutoHeightAtRow(i, linesPerRow, this.LayoutTable.Rows[row + rowIndex], ((row + rowIndex)%2 == 0 ? false : true));
							rowIndex++;
						}

						for (int j = 0 ; j < this.Cols ; j++)
						{
							cell = this[i,j];
							if (cell != null)
							{
								//RowNumer 증가
								cell.RowNumber += importCount;

								cell.Row = i;
								changeStyle = true;
								//RowHeaderVisible일때 RowHeader는 Style변경하지 않음
								if (this.RowHeaderVisible && j == 0) changeStyle = false;
								//짝수건 Import시는 변경할 필요없음
								if (changeStyle && (importCount%2 == 1))
								{
									aGridCell = this.CellInfoList[cell.CellName] as XEditGridCell;
									// 교대로 반복되는 행이면 교대로 반복되는 행의 Style 적용
									// 단 버튼형은 적용하지 않음
									if ((aGridCell != null) && (aGridCell.EditorStyle != XCellEditorStyle.ButtonBox))
									{
										//속도향상을 위해 행과 교대로반복되는 행의 속성이 다를 경우에만 SET
										if (cell.RowNumber%2 == 1)
										{
											if (aGridCell.RowDrawMode != aGridCell.AlterateRowDrawMode)
												cell.DrawMode = aGridCell.AlterateRowDrawMode;
											if (aGridCell.RowFont != aGridCell.AlterateRowFont)
												cell.Font = aGridCell.AlterateRowFont;
											if (aGridCell.RowBackColor != aGridCell.AlterateRowBackColor)
												cell.BackColor = aGridCell.AlterateRowBackColor;
											if (aGridCell.RowGradientStart != aGridCell.AlterateRowGradientStart)
												cell.GradientStart = aGridCell.AlterateRowGradientStart;
											if (aGridCell.RowGradientEnd != aGridCell.AlterateRowGradientEnd)
												cell.GradientEnd = aGridCell.AlterateRowGradientEnd;
											if (aGridCell.RowForeColor != aGridCell.AlterateRowForeColor)
												cell.ForeColor = aGridCell.AlterateRowForeColor;
											if (cell.Image != null)
											{
												if (aGridCell.RowImage != aGridCell.AlterateRowImage)
													cell.Image= aGridCell.AlterateRowImage;
												if (aGridCell.RowImageAlign != aGridCell.AlterateRowImageAlign)
													cell.ImageAlignment = aGridCell.AlterateRowImageAlign;
												if (aGridCell.RowImageStretch != aGridCell.AlterateRowImageStretch)
													cell.ImageStretch = aGridCell.AlterateRowImageStretch;
											}
										}
										else //속도향상을 위해 행과 교대로반복되는 행의 속성이 다를 경우에만 SET
										{
											if (aGridCell.RowDrawMode != aGridCell.AlterateRowDrawMode)
												cell.DrawMode = aGridCell.RowDrawMode;
											if (aGridCell.RowFont != aGridCell.AlterateRowFont)
												cell.Font = aGridCell.RowFont;
											if (aGridCell.RowBackColor != aGridCell.AlterateRowBackColor)
												cell.BackColor = aGridCell.RowBackColor;
											if (aGridCell.RowGradientStart != aGridCell.AlterateRowGradientStart)
												cell.GradientStart = aGridCell.RowGradientStart;
											if (aGridCell.RowGradientEnd != aGridCell.AlterateRowGradientEnd)
												cell.GradientEnd = aGridCell.RowGradientEnd;
											if (aGridCell.RowForeColor != aGridCell.AlterateRowForeColor)
												cell.ForeColor = aGridCell.RowForeColor;
											if (cell.Image != null)
											{
												if (aGridCell.RowImage != aGridCell.AlterateRowImage)
													cell.Image= aGridCell.RowImage;
												if (aGridCell.RowImageAlign != aGridCell.AlterateRowImageAlign)
													cell.ImageAlignment = aGridCell.RowImageAlign;
												if (aGridCell.RowImageStretch != aGridCell.AlterateRowImageStretch)
													cell.ImageStretch = aGridCell.RowImageStretch;
											}
										}
										//CheckBox형이면 Image SET
										if (aGridCell.EditorStyle == XCellEditorStyle.CheckBox)
										{
											displayText = GetDisplayTextByInfo(aGridCell,cell.Value , out isCheckValue);
											SetCheckStyleCellImage(cell, isCheckValue, displayText);
										}
										//MemoBox형 이면 MemoImage SET
										if (aGridCell.EditorStyle == XCellEditorStyle.MemoBox)
											SetMemoStyleCellImage(cell, aGridCell.DisplayMemoText);
									}
								}
							}
						}
					}

					// RowHeaderVisible이면 이후행의 행번호 변경
					if (this.RowHeaderVisible)
					{
						for ( int i = startRowIndex ; i < this.Rows ; i++)
						{
							if (this[i,0] != null)
							{
								dispRowNumber = Int32.Parse(this[i,0].CellName) + importCount;
								this[i,0].CellName = dispRowNumber.ToString();
								// RowNumber를 보여주면 Value도 SET
								if (this.ShowNumberAtRowHeader)
									this[i,0].Value = dispRowNumber;
							}
						}
					}
					
					startRowIndex = this.AddedHeaderLine + this.LinePerRow + row*linesPerRow;

					for (int i = 0 ; i < importCount ; i++)
					{
						rowNumber = row + i;
						//행추가
						dataRow = this.LayoutTable.NewRow();
						origDataRow = this.OrigLayoutTable.NewRow();
						//추가된 Row에 Cell Add
						foreach (XEditGridCell info in this.CellInfos)
						{
							//컬럼존재여부 확인
							if (columnList.Contains(info.CellName))
							{
								//GridTable, OrigGridTable의 행의 값 설정
								dataRow[info.CellName] = dtRows[i][info.CellName];
								origDataRow[info.CellName] = dtRows[i][info.CellName];

								//컬럼이 Visible이면 Cell Set
								if (info.IsVisible && (info.CellWidth > 0))
								{
									dataValue = dtRows[i][info.CellName];
									// 추가된 Header가 있으면 info의 xPos와 rowSpan을 AGridCells의 정보와 조정하여 Get
									if (this.AddedHeaderLine > 0)
									{
										this.CellInfos.GetCellPositionByXGridCell(info, linesPerRow, out rowPos, out rowSpan);
									}
									else
									{
										rowPos = info.Row;
										rowSpan = info.RowSpan;
									}
									// Grid Add
									displayText = GetDisplayTextByInfo(info, dataValue, out isCheckValue);
									if (info.EditorStyle == XCellEditorStyle.ButtonBox)
									{
										// Button형은 DataValue 의미 없음 (ButtonText로 Value Set) 
										this[rowPos + startRowIndex, info.Col] = CreateContentCell(info, displayText, displayText, rowSpan, (rowNumber%2 == 1));
										this[rowPos + startRowIndex, info.Col].IsButtonShape = true;
										this[rowPos + startRowIndex, info.Col].TextAlignment = ContentAlignment.MiddleCenter;
										//버튼 Scheme, Image 설정
										this[rowPos + startRowIndex, info.Col].ButtonSheme = ((XEditGridCell) info).ButtonScheme;
										this[rowPos + startRowIndex, info.Col].Image = ((XEditGridCell) info).ButtonImage;
										//ReadOnly 컬럼은 Disabled 상태로 설정
										if (info.IsReadOnly)
											this[rowPos + startRowIndex, info.Col].ButtonDisabled = true;
									}
									else
									{
										this[rowPos + startRowIndex, info.Col] = CreateContentCell(info, dataValue, displayText, rowSpan, (rowNumber%2 == 1));
										this[rowPos + startRowIndex, info.Col].RowNumber = rowNumber;
										//CheckBox형이면 Image SET
										if (info.EditorStyle == XCellEditorStyle.CheckBox)
											SetCheckStyleCellImage(this[rowPos + startRowIndex, info.Col], isCheckValue, displayText);
										//MemoBox형 이면 MemoImage SET
										if (info.EditorStyle == XCellEditorStyle.MemoBox)
											SetMemoStyleCellImage(this[rowPos + startRowIndex, info.Col], info.DisplayMemoText);
									}
								}
							}
						}

						//Row의 Height 자동조정
						if (this.ApplyAutoHeight)
							this.ApplyAutoHeightAtRow(startRowIndex, linesPerRow, dataRow, (rowNumber%2 == 0 ? false : true));

						//GridTable, OrigGridTable에 행삽입
						this.LayoutTable.Rows.InsertAt(dataRow, rowNumber);
						this.OrigLayoutTable.Rows.InsertAt(origDataRow, rowNumber);
						//한행 Insert되었으므로 DisplayCount 증가
						this.DisplayedRowCount += 1;

						startRowIndex += linesPerRow;
					}
				}
			}
			catch(Exception e)
			{
				msg = XMsg.GetMsg("M039", e); //ImportRowRange, 에러[" + e.Message + "]"
				ShowErrMsg(msg);
				//Display된 행갯수 복구
				this.DisplayedRowCount = bfRowCount;
				this.Redraw = true;
				return false;
			}
			// 그리기 시작
			this.Redraw = true;

			return true;

		}
		#endregion

		#region SetFocusToItem
		/// <summary>
		/// Cell(행번호, 컬럼명, EditMode여부) 에 Focus를 설정합니다.
		/// </summary>
		/// <param name="rowNumber"> 행번호 </param>
		/// <param name="colName"> 컬럼명 </param>
		/// <param name="isEditMode"> 편집모드 전환여부 </param>
		/// <returns> 성공시 true, 실패시 false </returns>
		[Description("Cell(행번호, 컬럼명, EditMode여부) 에 Focus를 설정합니다.")]
		public virtual bool SetFocusToItem(int rowNumber, string colName, bool isEditMode)
		{
			XEditGridCell cellInfo = null;
			int rowPos = 0;
			int rowSpan = 0;
			int linesPerRow = this.GetLinesPerRow();
			if (rowNumber < 0) return false;
            if (rowNumber >= this.RowCount) return false;
			
			try
			{
				cellInfo = this.CellInfoList[colName] as XEditGridCell;
				if (cellInfo == null) return false;
				//NonVisible Column
				if (!cellInfo.IsVisible) return false;
			
				//논리적인 rowNumber를 물리적인 row로 변경
				if (this.AddedHeaderLine > 0)
					this.CellInfos.GetCellPositionByXGridCell(cellInfo, linesPerRow, out rowPos, out rowSpan);
				else
					rowPos = cellInfo.Row;
			
				// 논리적인 rowNum으로 물리적인 row Get
				// = HeaderLine수 + rowNum보다 작은 GroupRow의 Line수 + rowNum * 한 Row의 Line수
				int row = (rowNumber*linesPerRow) + this.LinePerRow + this.AddedHeaderLine + this.GroupRowInfos.GetBelowGroupLineCount(true, rowNumber, linesPerRow) + rowPos;

				// 기존에 Editing중이면 EndEdit
				if (this.isEditing)
					this.EndEdit(false);

				//Cell Focus
				if (this[row, cellInfo.Col] != null)
					this[row, cellInfo.Col].Focus(false);

				//EditMode로 변경
				if (isEditMode)
					this.StartEdit();
			}
			catch
			{
				return false;
			}
			return true;
		}
		/// <summary>
		/// Cell(행번호, 컬럼명) 에 Focus를 설정합니다.
		/// </summary>
		/// <param name="rowNumber"> 행번호 </param>
		/// <param name="colName"> 컬럼명 </param>
		/// <returns> 성공시 true, 실패시 false </returns>
		[Description("Cell(행번호, 컬럼명) 에 Focus를 설정합니다.")]
		public override bool SetFocusToItem(int rowNumber, string colName)
		{
			return SetFocusToItem(rowNumber, colName, true);
		}

		/// <summary>
		/// Cell(행번호, 컬럼번호,EditMode여부) 에 Focus를 설정합니다.
		/// </summary>
		/// <param name="rowNumber"> 행번호 </param>
		/// <param name="colNum"> 컬럼번호 </param>
		/// <param name="isEditMode"> 편집모드 전환여부 </param>
		/// <returns> 성공시 true, 실패시 false </returns>
		[Description("Cell(행번호, 컬럼번호,EditMode여부) 에 Focus를 설정합니다.")]
		public virtual bool SetFocusToItem(int rowNumber, int colNum, bool isEditMode)
		{
			int index = 0;
			XEditGridCell cellInfo = null;
			int rowPos = 0;
			int rowSpan = 0;
			bool isMatch = false;
			int linesPerRow = this.GetLinesPerRow();
			int colNumber = colNum;

			if (rowNumber < 0) return false;
			if (rowNumber >= this.RowCount) return false;
            if (rowNumber >= this.RowCount) return false;

			//RowHeaderVisible이면 colNumber 하나 증가
			if (this.RowHeaderVisible)
				colNumber += 1;
			
			try
			{
				//xPos = 0 이고, yPos가 colNum인 AEditGridCell Get
				for (index = 0; index < this.CellInfos.Count ; index ++)
				{
					cellInfo = (XEditGridCell) this.CellInfos[index];
					if (this.AddedHeaderLine > 0)
						this.CellInfos.GetCellPositionByXGridCell(cellInfo, linesPerRow, out rowPos, out rowSpan);
					else
						rowPos = cellInfo.Row;
					if ((rowPos == 0) && (cellInfo.Col == colNumber))
					{
						isMatch = true;
						break;
					}
				}
				
				if (!isMatch) return false;

				//NonVisible Column
				if (!cellInfo.IsVisible) return false;
			
				//논리적인 rowNumber를 물리적인 row로 변경
				if (this.AddedHeaderLine > 0)
					this.CellInfos.GetCellPositionByXGridCell(cellInfo, linesPerRow, out rowPos, out rowSpan);
				else
					rowPos = cellInfo.Row;
			
				// 논리적인 rowNum으로 물리적인 row Get
				// = HeaderLine수 + rowNum보다 작은 GroupRow의 Line수 + rowNum * 한 Row의 Line수
				int row = (rowNumber*linesPerRow) + this.LinePerRow + this.AddedHeaderLine + this.GroupRowInfos.GetBelowGroupLineCount(true, rowNumber, linesPerRow) + rowPos;

				// 기존에 Editing중이면 EndEdit
				if (this.isEditing)
					this.EndEdit(false);

				//Cell Focus
				if (this[row, cellInfo.Col] != null)
					this[row, cellInfo.Col].Focus(false);

				// EditMode로 변경
				if (isEditMode)
					this.StartEdit();
			}
			catch
			{
				return false;
			}
			return true;
		}
		/// <summary>
		/// Cell(행번호, 컬럼번호) 에 Focus를 설정합니다.
		/// </summary>
		/// <param name="rowNumber"> 행번호 </param>
		/// <param name="colNum"> 컬럼번호 </param>
		/// <returns> 성공시 1, 실패시 -1 </returns>
		[Description("Cell(행번호, 컬럼번호) 에 Focus를 설정합니다.")]
		public override bool SetFocusToItem(int rowNumber, int colNum)
		{
			return SetFocusToItem(rowNumber, colNum, true);	
		}
		#endregion

		#region SetItemValue, SetItemSub
		public override bool SetItemValue(int rowNumber, string colName, object data)
		{
			bool result = base.SetItemValue(rowNumber, colName, data);

			//SetItem 성공시 Edit중이면 Editor의 DataValue도 변경
			if (result)
			{
				try
				{
					XEditGridCell cellInfo = this.CellInfoList[colName] as XEditGridCell;
					if (!cellInfo.IsVisible) return result;
					if (cellInfo.CellEditor == null) return result;
				
					//Editor가 Visible상태이면 Editing중인 DataValue SET(현재행과 동일한 행일때만)
					if (((Control) cellInfo.CellEditor.Editor).Visible && (this.CurrentRowNumber == rowNumber))
						cellInfo.CellEditor.Editor.DataValue = data;
				}
				catch{}
			}

			return result;
		}

		/// <summary>
		/// 컬럼정보를 이용 Cell의 값을 설정합니다.
		/// </summary>
		/// <param name="info"> XGridCell 객체(컬럼정보) </param>
		/// <param name="row"> 행번호 </param>
		/// <param name="data"> 설정할 값 </param>
		protected override void SetItemSub(XGridCell info ,int row, object data)
		{
			string displayText = string.Empty;
			bool   isCheckValue = false;
			if (this[row, info.Col] != null)
			{
				displayText = this.GetDisplayTextByInfo(info, data, out isCheckValue);
				this[row, info.Col].DisplayText = displayText;
				//Binary이면 Image Set
				if (info.CellType == XCellDataType.Binary)
				{
					this[row, info.Col].Value = data;
					SetImageByBinaryData(this[row, info.Col], data);
				}
				else
				{	
					this[row, info.Col].Value = data;
					//CheckBox형이면 Image SET
					if (info.EditorStyle == XCellEditorStyle.CheckBox)
						SetCheckStyleCellImage(this[row, info.Col], isCheckValue, displayText);
					//MemoBox형 이면 MemoImage SET
					if (info.EditorStyle == XCellEditorStyle.MemoBox)
						SetMemoStyleCellImage(this[row, info.Col], ((XEditGridCell) info).DisplayMemoText);
				}
			}
		}
		#endregion
		
		#region ProcessCmdKey (TAB KEY 통제)
		/// <summary>
		/// 명령 키를 처리합니다.
		/// (override) (Shift) + TAB 키 입력시 이전, 다음 Cell로 이동, 편집모드로 전환
		/// </summary>
		/// <param name="msg"> (ref) Message </param>
		/// <param name="keyData"> Keys Enum </param>
		/// <returns> 해당키가 처리되었으면 true, 아니면 false </returns>
		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			XCell moveCell = null;
			bool bfIsEditing = this.isEditing;
			Keys keyCode = (Keys)(((int)keyData << 16) >> 16);		// Modifier Clear
			Keys modifier = (Keys)(((int)keyData >> 16) << 16);		// Modifier
			//TAB Press
			if ((keyCode == Keys.Tab) && ((keyData & Keys.Shift) != Keys.Shift))
			{
				// 다음 Cell로 이동
				moveCell = this.GetNextCell(this.FocusCell);
				if (moveCell != null)
				{
					//EndEdit()
					this.EndEdit(false);
					//HasError이면 return True
					if (this.HasErrors) return true;

					//NextCell Focus
					moveCell.Focus();
					// Editing상태이면 다음 Cell에 Edit
					if (bfIsEditing)
						this.StartEdit();
					// TAB KEY 처리함
					return true;
				}
			}
			else if ((keyCode == Keys.Tab) && ((keyData & Keys.Shift) == Keys.Shift)) //Shift + TAB
			{
				// 이전 Cell로 이동
				moveCell = this.GetPrevCell(this.FocusCell);
				if (moveCell != null)
				{
					//EndEdit()
					this.EndEdit(false);
					//HasError이면 return True
					if (this.HasErrors) return true;

					//PrevCell Focus
					moveCell.Focus();

					// Shift + TAB시에 선택영역 해제
					this.Selection.Clear(moveCell);

					// Editing상태이면 다음 Cell에 Edit
					if (bfIsEditing)
						this.StartEdit();
					// TAB KEY 처리함
					return true;
				}
			}
			else if (keyData == Keys.Escape) // Escape Key 입력시 편집모드 종료
			{
				//2005.12.13 에러 발생시에는 EndEdit할 수 없음
				if (this.HasErrors) return true;

				this.EndEdit(true);
				return true;
			}
			else if (bfIsEditing && ((keyData == Keys.Up) || (keyData== Keys.Down)))
			{
				//Editing중에 Up,Down Key를 누를때 다음행,이전행으로 이동
				//단 ComboBox는 이동하지 않음
				XGridCell cellInfo = this.CellInfoList[this.FocusCell.CellName] as XGridCell;

				if (cellInfo == null) return true;
				
				//Combo, ListBox의 원래기능 그대로 사용
				if ((cellInfo.EditorStyle == XCellEditorStyle.ComboBox) || (cellInfo.EditorStyle == XCellEditorStyle.ListBox))
					return base.ProcessCmdKey(ref msg, keyData);
				//2005.11.07 DatePicker, IsJapanYearType이면 원래기능 그대로 처리함
				//2005.12.01 TextBox형일때 Date, Month형도 일본연호형식 표기 가능
				if ((cellInfo.EditorStyle == XCellEditorStyle.DatePicker) && cellInfo.IsJapanYearType)
					return base.ProcessCmdKey(ref msg, keyData);
				else if (cellInfo.IsJapanYearType && (cellInfo.EditorStyle == XCellEditorStyle.EditBox))
					return base.ProcessCmdKey(ref msg, keyData);

				int currRow = this.CurrentRowNumber;
				
				//첫번째행에서 Up 불가
				if ((keyData == Keys.Up) && (currRow < 1))
					return true;
				//마지막 행에서 Down 불가
				if ((keyData == Keys.Down) && (currRow >= this.RowCount - 1))
					return true;
				
				//EndEdit()
				this.EndEdit(false);
				//HasError이면 return True
				if (this.HasErrors) return true;

				if (keyData == Keys.Up)  //위로이동
					this.SetFocusToItem(currRow -1, this.FocusCell.CellName, bfIsEditing);
				else // 아래로 이동
					this.SetFocusToItem(currRow + 1, this.FocusCell.CellName, bfIsEditing);
				return true;
			}

			return base.ProcessCmdKey(ref msg, keyData);
		}
		protected override bool ProcessDialogKey(Keys keyData)
		{
			bool lb;
			try
			{
				lb = base.ProcessDialogKey(keyData);
			}
			catch
			{
				return true;
			}

			if (this.ProcessKeyDown != null)
			{
				KeyEventArgs xe = new KeyEventArgs(keyData);
				OnProcessKeyDown(xe);
			}

			//EnterKey입력시 자동개행 처리 LOGIC
			//2005.09.13 마지막행일때만 자동 Insert처리하고 InsertRow를 직접 Call하는 것이 아니라, IFuctionPerformer가 있으면 IFunctionPerformer의
			//InsertFunc를 call(개발자가 이 부분에 LOGIC 기술가능), 없으면 InsertRow
			if (this.applyAutoInsertion && (keyData == Keys.Enter) && (this.FocusCell != null) && (this.FocusCell.Personality == XCellPersonality.Content)
				&& this.autoInsertColumnList.Contains(this.FocusCell.CellName) && (this.CurrentRowNumber == (this.RowCount - 1)))
			{
				if ((this.LayoutContainer != null) && (this.LayoutContainer.FunctionPerformer != null))
					this.LayoutContainer.FunctionPerformer.PerformFunction(FunctionType.Insert);
				else  //없으면 InsertRow
					this.InsertRow();
				//Key 처리됨 (Edit상태에서 EnterToTab등의 다른 처리가 되지 않도록 Key처리됨으로 표시함)
				lb = true;
			}
			return lb;
		}
		#endregion

		#region SetListItems, GetListDisplayValue
		public virtual void SetListItems(string colName, DataTable dataTable, string displayMember, string valueMember, XComboSetType setType)
		{
			if (!this.CellInfoList.Contains(colName)) return;
			XEditGridCell info = this.CellInfoList[colName] as XEditGridCell;
			//ListBox Style이 아니면 Return
			if (info.EditorStyle != XCellEditorStyle.ListBox) return;
			if (info.CellEditor != null)
			{
				((XDictListBox) info.CellEditor.Editor).SetListItems(dataTable, displayMember, valueMember, setType);
				//XEditGridCell의 ComboItems의 Editor의 ComboItems를 일치시킴
				info.ComboItems.AddRange(((XDictListBox) info.CellEditor.Editor).ListItems.ToArray());
			}
		}
		/// <summary>
		/// 지정한 컬럼에, 지정한 테이블로 ComboItems를 설정합니다.
		/// </summary>
		public virtual void SetListItems(string colName, DataTable dataTable, string displayMember, string valueMember)
		{
			SetListItems(colName, dataTable, displayMember, valueMember, XComboSetType.NoAppend);
		}
		/// <summary>
		/// 지정한 행, 컬럼이 ListBox Style일때 ListBox의 Display값을 가져옵니다.
		/// </summary>
		/// <param name="rowNumber"></param>
		/// <param name="colName"></param>
		/// <returns></returns>
		public virtual string GetListDisplayValue(int rowNumber, string colName)
		{
			if ((rowNumber < 0) || (rowNumber >= this.RowCount)) return "";
			if (!this.CellInfoList.Contains(colName)) return "";
			XEditGridCell info = this.CellInfoList[colName] as XEditGridCell;
			if (info.EditorStyle != XCellEditorStyle.ListBox) return "";
			if (info.CellEditor == null) return "";
			//Editor가 Visible한 상태이면 Editor의 Text를 아니면 DisplayText
			if (((Control)info.CellEditor.Editor).Visible)
				return ((Control)info.CellEditor.Editor).Text;
			else
				return this[rowNumber, colName].DisplayText;
		}
		#endregion

		#region SetComboItems, RefreshComboItems, GetComboDisplayValue
		public virtual void SetComboItems(string colName, DataTable dataTable, string displayMember, string valueMember, XComboSetType setType)
		{
			if (!this.CellInfoList.Contains(colName)) return;
			XEditGridCell info = this.CellInfoList[colName] as XEditGridCell;
			//ComboBox Style이 아니면 Return
			if (info.EditorStyle != XCellEditorStyle.ComboBox) return;
			if (info.CellEditor != null)
			{
				((XComboBox) info.CellEditor.Editor).SetComboItems(dataTable, displayMember, valueMember, setType);
				//XEditGridCell의 ComboItems의 Editor의 ComboItems를 일치시킴
				info.ComboItems.AddRange(((XComboBox) info.CellEditor.Editor).ComboItems.ToArray());
			}
		}
		/// <summary>
		/// 지정한 컬럼에, 지정한 테이블로 ComboItems를 설정합니다.
		/// </summary>
		public virtual void SetComboItems(string colName, DataTable dataTable, string displayMember, string valueMember)
		{
			SetComboItems(colName, dataTable, displayMember, valueMember, XComboSetType.NoAppend);
		}
		/// <summary>
		/// XEditGridCell의 ComboItems에 직접 Add, Remove하고 나서 변경된 ComboItems를 적용합니다.
		/// </summary>
		/// <param name="colName"> 컬럼명 </param>
		public virtual void RefreshComboItems(string colName)
		{
			if (!this.CellInfoList.Contains(colName)) return;
			XEditGridCell info = this.CellInfoList[colName] as XEditGridCell;
			//ComboBox Style이 아니면 Return
			if (info.EditorStyle != XCellEditorStyle.ComboBox) return;
			if (info.CellEditor != null)
			{
				//Editor의 ComboItems를 컬럼정보의 ComboItems를 변경
				((XComboBox) info.CellEditor.Editor).ComboItems.AddRange(info.ComboItems.ToArray());
				//Refresh
				((XComboBox) info.CellEditor.Editor).RefreshComboItems();
			}
		}
		public virtual void SetComboBindVarValue(string colName, string varName, string varValue)
		{
			//Combo, ListBox설정을 UserSQL로 할때 Bind변수를 설정합니다.
			if (!this.CellInfoList.Contains(colName)) return;
			XEditGridCell info = this.CellInfoList[colName] as XEditGridCell;
			if ((info.EditorStyle != XCellEditorStyle.ComboBox) && (info.EditorStyle != XCellEditorStyle.ListBox)) return;
//			if (info.SQLType != XComboSQLType.UserSQL) return;
			if (info.UserSQL.Trim() == "") return;
			if (info.CellEditor != null)
			{
				if (info.EditorStyle == XCellEditorStyle.ComboBox)
					((XDictComboBox) info.CellEditor.Editor).SetBindVarValue(varName, varValue);
				else
					((XDictListBox) info.CellEditor.Editor).SetBindVarValue(varName, varValue);
			}
		}
		/// <summary>
		/// 지정한 행, 컬럼이 ComboStyle일때 ComboBox의 Display값을 가져옵니다.
		/// </summary>
		/// <param name="rowNumber"></param>
		/// <param name="colName"></param>
		/// <returns></returns>
		public virtual string GetComboDisplayValue(int rowNumber, string colName)
		{
			if ((rowNumber < 0) || (rowNumber >= this.RowCount)) return "";
			if (!this.CellInfoList.Contains(colName)) return "";
			XEditGridCell info = this.CellInfoList[colName] as XEditGridCell;
			if (info.EditorStyle != XCellEditorStyle.ComboBox) return "";
			if (info.CellEditor == null) return "";
			//Editor가 Visible한 상태이면 Editor의 Text를 아니면 DisplayText
			if (((Control)info.CellEditor.Editor).Visible)
				return ((Control)info.CellEditor.Editor).Text;
			else
				return this[rowNumber, colName].DisplayText;
		}
		#endregion

		#region ClearRowData
		/// <summary>
		/// 지정한 행의 데이타를 모두 Clear합니다.
		/// </summary>
		/// <param name="rowNumber"></param>
		/// <returns></returns>
		public bool ClearRowData(int rowNumber)
		{
			bool ret = true;
			try
			{
				if ((rowNumber >= 0) && (rowNumber < this.RowCount))
				{
					//편집종료
					if (this.isEditing)
						this.EndEdit(true);
					foreach (XGridCell info in this.CellInfos)
						this.SetItemValue(rowNumber, info.CellName, DBNull.Value);
				}
			}
			catch(Exception e)
			{
				Debug.WriteLine("XEditGrid::ClearRowData 에러[" + e.Message + "]");
				ret = false;
			}
			return ret;
		}
		#endregion

		#region SetContextMenu
		/// <summary>
		/// Grid에 ContextMenu를 설정합니다.(Grid의 Editor의 ContextMenu도 같이 설정)
		/// </summary>
		/// <param name="menu"></param>
		public override void SetContextMenu(ContextMenu menu)
		{
			try
			{
				this.ContextMenu = menu;
				foreach (XEditGridCell info in this.CellInfos)
				{
					//Visible한 컬럼, Binary 제외 ,CellEditor가 있을때
					if (info.IsVisible && (info.CellType != XCellDataType.Binary) && (info.CellEditor != null))
						((Control)info.CellEditor.Editor).ContextMenu = menu;
				}
			}
			catch{}
		}
		#endregion

		#region Sort Override
		public override bool Sort(string sortNotation)
		{

			//편집중인 값 반영 Accept실패시 return
			if (!this.AcceptData())
				return false;
			
			//Sort
			return base.Sort (sortNotation);
		}
		#endregion

		#region ExportSub Override
		protected override void ExportSub(bool isSaveFile, bool runExcel, bool onlyDisplayedColumn)
		{
			//편집중인 값 반영 Accept실패시 return
			if (!this.AcceptData())
			{
				string msg = XMsg.GetMsg("M040"); // 편집중인 값이 제대로 반영되지 않았습니다."
				ShowErrMsg(msg);
				return;
			}
			base.ExportSub (isSaveFile, runExcel, onlyDisplayedColumn);
		}
		#endregion

		#region SetEditorValue (Edit중일때 편집중인 Editor의 값만 바꿈)
		public void SetEditorValue(object dataValue)
		{
			//현재편집중인 Editor의 DataValue를 설정
			if ((this.FocusCell != null) && (this.FocusCell.Personality == XCellPersonality.Content))
			{
				try
				{
					XEditGridCell cellInfo = this.CellInfoList[FocusCell.CellName] as XEditGridCell;
					
					if (cellInfo != null)
					{
						//Editor가 Visible상태이면 Editing중인 DataValue SET
						if (((Control) cellInfo.CellEditor.Editor).Visible)
							cellInfo.CellEditor.Editor.DataValue = dataValue;
					}
				}
				catch(Exception xe)
				{
					Debug.WriteLine("XEditGrid::SetEditorValue, Error=" + xe.Message);
				}
			}
		}
		#endregion

		#region ChangeButton... (특정행,컬럼의 버튼상태 변경)
		public void ChangeButtonEnable(string colName, int rowNumber, bool isEnable)
		{
			int row = 0, col = 0;
			if (!IsValidButtonColumn(colName, rowNumber, out row, out col)) return;
			this[row,col].ButtonDisabled = !isEnable;
		}
		public void ChangeButtonText(string colName, int rowNumber, string buttonText)
		{
			int row = 0, col = 0;
			if (!IsValidButtonColumn(colName, rowNumber, out row, out col)) return;
			this[row,col].DisplayText = buttonText;
			this[row,col].Value = buttonText;
		}
		public void ChangeButtonSheme(string colName, int rowNumber, XButtonSchemes buttonScheme)
		{
			int row = 0, col = 0;
			if (!IsValidButtonColumn(colName, rowNumber, out row, out col)) return;
			this[row,col].ButtonSheme = buttonScheme;
		}
		public void ChangeButtonImage(string colName, int rowNumber, Image buttonImage)
		{
			int row = 0, col = 0;
			if (!IsValidButtonColumn(colName, rowNumber, out row, out col)) return;
			this[row,col].Image = buttonImage;
		}
		private bool IsValidButtonColumn(string colName, int rowNumber, out int row, out int col)
		{
			row = -1;
			col = -1;
			//Button형 컬럼인지 여부 확인
			XEditGridCell info = this.CellInfoList[colName] as XEditGridCell;
			string msg = "";
			if (info == null)
			{
				msg = XMsg.GetMsg("M041") + "[" + colName + "]" + XMsg.GetMsg("M042"); // 컬럼명[" + colName + "]을 잘못 지정하셨습니다."
				ShowErrMsg(msg);
				return false;
			}
			if (info.EditorStyle != XCellEditorStyle.ButtonBox)
			{
				msg = msg = XMsg.GetMsg("M043") + "[" + colName + "]" + XMsg.GetMsg("M044"); // 컬럼[" + colName + "]이 버튼형 컬럼이 아닙니다."
				ShowErrMsg(msg);
				return false;
			}
			if (!info.IsVisible)
			{
				msg = msg = XMsg.GetMsg("M043") + "[" + colName + "]" + XMsg.GetMsg("M045"); // 컬럼[" + colName + "]이 Visible하지 않습니다."
				ShowErrMsg(msg);
				return false;
			}
			//rowNumber 유효성 Check
			if ((rowNumber < 0) || (rowNumber >= this.RowCount))
			{
				msg = msg = XMsg.GetMsg("M046") + "[" + rowNumber.ToString() + "]" + XMsg.GetMsg("M042"); // 행번호[" + rowNumber.ToString() + "]를 잘못 지정하셨습니다."
				ShowErrMsg(msg);
				return false;
			}
			col = info.Col;
			try
			{
				//논리적인 RowNumber로 Cell의 위치인 row, col 계산
				int linesPerRow = this.GetLinesPerRow();
				int rowPos = 0, rowSpan = 0;
				// 논리적인 rowNum으로 물리적인 row Get
				// = HeaderLine수 + rowNum보다 작은 GroupRow의 Line수 + rowNum * 한 Row의 Line수
				row = (rowNumber*linesPerRow) + this.LinePerRow + this.AddedHeaderLine + this.GroupRowInfos.GetBelowGroupLineCount(true, rowNumber, linesPerRow);
				if (this.AddedHeaderLine > 0)
					this.CellInfos.GetCellPositionByXGridCell(info, linesPerRow , out rowPos, out rowSpan);
				else
					rowPos = info.Row;
				row += rowPos;
			}
			catch
			{
				msg = XMsg.GetMsg("M047"); // 버튼컬럼 상태변경중에 에러가 발생했습니다."
				ShowErrMsg(msg);
				return false;
			}
			if (this[row,col] == null)
			{
				msg = msg = XMsg.GetMsg("M048"); // 버튼컬럼에 해당하는 Cell이 없습니다."
				ShowErrMsg(msg);
				return false;
			}
			return true;
		}
		#endregion

		#region GetChangedRowCount (현재 그리드의 변경된 건수 GET, aiud는 A.전체, I.Inserted, U.Updated, D.Deleted
		public int GetChangedRowCount(char aiud) 
		{
			int delCount = this.DeletedRowCount;
			int addCount = 0;  //추가된 건수
			int modCount = 0;  //변경된 건수
			foreach (DataRow dtRow in this.LayoutTable.Rows)
			{
				if (dtRow.RowState == DataRowState.Added)
					addCount++;
				else if (dtRow.RowState == DataRowState.Modified)
					modCount++;
			}
			switch (aiud)
			{
				case 'I':
					return addCount;
				case 'U':
					return modCount;
				case 'D':
					return delCount;
				default:
					return addCount + modCount + delCount;
			}
		}
		/// <summary>
		/// 변경된 행의 건수를 가져옵니다. (IMultiSaveLayout 구현)
		/// </summary>
		/// <returns></returns>
		int IMultiSaveLayout.GetChangedRowCount()
		{
			return GetChangedRowCount('A');
		}
		#endregion

		#region SetReservedMemoControlLoadParam
		public virtual void SetReservedMemoControlLoadParam(string colName, object loadParam)
		{
			if (!this.CellInfoList.Contains(colName)) return;
			XEditGridCell info = this.CellInfoList[colName] as XEditGridCell;
			//MemoBox Style이 아니면 Return
			if (info.EditorStyle != XCellEditorStyle.MemoBox) return;
			if (info.CellEditor != null)
			{
				((XMemoBox) info.CellEditor.Editor).SetReservedMemoControlLoadParam(loadParam);
			}
		}
		#endregion

		#region ContDisplay, SetValueStarting override (연속조회시 편집중이면 편집 종료)
		protected override void ContDisplay(bool rePainting)
		{
			//편집중이면 편집해제
			if (this.isEditing)
				this.EndEdit(false);

			base.ContDisplay(rePainting);
		}
		protected override void QueryLayoutStarting()
		{
			if (this.isEditing)
				this.EndEdit(false);

			base.QueryLayoutStarting();
		}
		#endregion

		#region SetBindControlDataValue override
		protected override bool SetBindControlDataValue(int currRow)
		{
			//Binding 되지 않았으면 Return
			if (!base.SetBindControlDataValue (currRow)) return false;

			DataRowState rowState = this.LayoutTable.Rows[currRow].RowState;
			//2005.11.30 Control Binding 일때 XGridCell의 ReadOnly, Updatable 속성에 따라
			//Binding된 Control의 Protect 설정
			foreach (XEditGridCell info in this.CellInfos)
			{
				if (info.BindControl != null)
				{
					if (info.IsReadOnly)
						info.BindControl.Protect = true;
					else if (!info.IsUpdatable && (rowState != DataRowState.Added)) //Insert상태가 아닐때는 Protect
						info.BindControl.Protect = true;
					else
						info.BindControl.Protect = false;
				}
			}
			return true;
		}

		#endregion

		#region MoveRow override
		public override bool  MoveRow(int fromRowNumber, int toRowNumber)
		{
			//Edit중이면 Edit 종료 (편집중인 값 반영하지 않음)
			if (this.isEditing)
				this.EndEdit(true);
			return base.MoveRow(fromRowNumber, toRowNumber);
		}
		#endregion

		#region CloneToLayout override 
		public override MultiLayout CloneToLayout()
		{
			//XGrid에서는 CallerID, isNotNull, isUpdItem을 정의하지 못하므로 여기서는 명확히 정의함
			//Master관계 및 삭제된 Table은 복사하지 않음
			MultiLayout layout = new MultiLayout();
			layout.CallerID = this.callerID;
			foreach (XEditGridCell info in this.CellInfos)
			{
				MultiLayoutItem item = new MultiLayoutItem();
				item.DataName = info.CellName;
				item.DataType = XGridUtility.ConvertToDataType(info.CellType);
				item.IsNotNull = info.IsNotNull;
				item.IsUpdItem = info.IsUpdCol;
				layout.LayoutItems.Add(item);
			}
			//LayoutTable 생성
			layout.InitializeLayoutTable();

			return layout;

		}
		#endregion

        #region ValidateCell
        // Author: MinhLS
        // UpdDate: 2015/08/14
        public virtual bool ValidateCell()
        {
            if (deletedRowTable != null && deletedRowTable.Rows.Count > 0)
            {
                foreach (DataRow dtRow in deletedRowTable.Rows)
                {
                    foreach (XEditGridCell item in this.CellInfos)
                    {
                        //Update컬럼만 Add
                        if (item.IsUpdCol)
                        {
                            //NotNull Check
                            if (item.IsNotNull && dtRow[item.CellName].ToString() == "")
                            {
                                string name = (item.HeaderText != "" ? item.HeaderText : item.CellName);
                                string msg = "[" + name + "]" + XMsg.GetMsg("M024"); //의 값이 입력되지 않았습니다."
                                throw (new Exception(msg));
                            }

                        }
                    }
                }
            }

            //I,U Row 전문 생성
            foreach (DataRow dtRow in LayoutTable.Rows)
            {
                //Added, Modified 상태일때만 Data Set
                //2006.04.04 변경안된 행 포함여부도 고려함
                if (this.includeUnChangedRowAtSaving || (dtRow.RowState == DataRowState.Added) ||
                    (dtRow.RowState == DataRowState.Modified))
                {
                    foreach (XEditGridCell item in this.CellInfos)
                    {
                        //Update컬럼만 Add
                        if (item.IsUpdCol)
                        {
                            //Added상태일때 MasterLayout이 있고, 컬럼이 RelationKeys에 적용된 컬럼이면 MasterLayout에서 값을 가져와서 설정
                            if ((this.MasterLayout != null) && (dtRow.RowState == DataRowState.Added) &&
                                this.relationKeys.Contains(item.CellName))
                            {
                                //dtRow의 값을 masterValue로 설정
                                dtRow[item.CellName] = this.MasterLayout.GetItemValueFromRelatonKey(
                                        this.relationKeys[item.CellName].ToString()); ;
                            }
                            //NotNull Check
                            if (item.IsNotNull && dtRow[item.CellName].ToString() == "")
                            {
                                string name = (item.HeaderText != "" ? item.HeaderText : item.CellName);
                                string msg = "[" + name + "]" + XMsg.GetMsg("M024"); //의 값이 입력되지 않았습니다."
                                throw (new Exception(msg));
                            }
                        }
                    }
                }
            }
            return true;
        }
        #endregion
	}

	#region GridButtonClickEventHandler
	public delegate void GridButtonClickEventHandler(object sender, GridButtonClickEventArgs e);

	public class GridButtonClickEventArgs : EventArgs 
	{ 
		private string colName = "";   //컬럼명
		private int rowNumber = -1;
		private DataRow dataRow;
		
		public string ColName
		{
			get { return colName;}
		}
		public int RowNumber
		{
			get { return rowNumber;}
		}
		public DataRow DataRow
		{
			get { return dataRow;}
		}
		public GridButtonClickEventArgs(string colName, int rowNumber, DataRow dataRow)
		{ 
			this.colName = colName;
			this.rowNumber = rowNumber ;
			this.dataRow = dataRow;
		} 
	} 
	#endregion

	#region GridColumnProtectModifyEventHandler
	[Serializable]
	public delegate void GridColumnProtectModifyEventHandler(object sender, GridColumnProtectModifyEventArgs e);

	public class GridColumnProtectModifyEventArgs : EventArgs
	{
		private string	colName = "";
		private int		rowNumber = 0;
		private DataRow dataRow = null;
		private bool	protect = false;
		public string ColName
		{
			get { return colName;}
		}
		public int RowNumber
		{
			get { return rowNumber;}
		}
		public DataRow DataRow
		{
			get { return dataRow;}
		}
		public bool Protect
		{
			get { return protect;}
			set { protect = value;}
		}
		public GridColumnProtectModifyEventArgs(string colName, int rowNum, DataRow dataRow, bool protect)
		{
			this.colName = colName;
			this.rowNumber = rowNum;
			this.dataRow = dataRow;
			this.protect = protect;
		}
	}
	#endregion

	#region GridFindClickEventArgs
	[Serializable]
	public delegate void GridFindClickEventHandler(Object sender, GridFindClickEventArgs e);

	public class GridFindClickEventArgs : EventArgs
	{
		private string	colName;
		private int		rowNumber;
		private bool	cancel;
		public string ColName
		{
			get { return colName;}
		}
		public int RowNumber
		{
			get { return rowNumber;}
		}
		public bool Cancel
		{
			get { return cancel;}
			set { cancel = value;}
		}
		public GridFindClickEventArgs(string colName, int rowNum, bool cancel)
		{
			this.colName = colName;
			this.rowNumber = rowNum;
			this.cancel = cancel;
		}
	}
	#endregion

	#region GridFindSelectedEventHandler
	[Serializable]
	public delegate void GridFindSelectedEventHandler(Object sender, GridFindSelectedEventArgs e);

	public class GridFindSelectedEventArgs : EventArgs
	{
		private string colName;
		private int rowNumber;
		private object[] returnValues;
		public string ColName
		{
			get { return colName;}
		}
		public int RowNumber
		{
			get { return rowNumber;}
		}
		public object[] ReturnValues
		{
			get { return returnValues;}
		}
		public GridFindSelectedEventArgs(string colName, int rowNum, object[] data)
		{
			this.colName = colName;
			this.rowNumber = rowNum;
			this.returnValues = data;
		}
	}
	#endregion

	#region ItemValueChangingEventHandler
	/// <summary>
	/// Grid의 컬럼값이 변경될때 발생이벤트를 처리하는 메서드입니다.
	/// </summary>
	[Serializable]
	public delegate void ItemValueChangingEventHandler(object sender, ItemValueChangingEventArgs e);
	
	/// <summary>
	/// Grid의 컬럼값이 변경될때 발생이벤트에 데이타를 제공합니다.
	/// </summary>
	public class ItemValueChangingEventArgs : EventArgs
	{
		private int		rowNumber;
		private DataRow dataRow;
		private string	colName;
		private object	changeValue;
		/// <summary>
		/// 현재 행번호를 가져옵니다.
		/// </summary>
		public int RowNumber
		{
			get { return rowNumber;}
		}
		/// <summary>
		/// 현재 컬럼명을 가져옵니다.
		/// </summary>
		public string  ColName
		{
			get { return colName;}
		}
		/// <summary>
		/// 현재 행의 DataRow 객체를 가져옵니다.
		/// </summary>
		public DataRow  DataRow
		{
			get { return dataRow;}
		}
		/// <summary>
		/// 변경된 값을 가져옵니다.
		/// </summary>
		public object ChangeValue
		{
			get { return changeValue;}
		}
		/// <summary>
		/// GridColumnChangedEventArgs 생성자
		/// </summary>
		/// <param name="rowNumber"> 현재행번호 </param>
		/// <param name="colName"> 컬럼명 </param>
		/// <param name="dataRow"> 현재행의 DataRow객체 </param>
		/// <param name="changeValue"> 변경값 </param>
		public ItemValueChangingEventArgs(int rowNumber, string colName, DataRow dataRow, object changeValue)
		{
			this.rowNumber = rowNumber;
			this.colName = colName;
			this.dataRow = dataRow;
			this.changeValue = changeValue;
		}
	}
	#endregion

	#region GridDDLBSettingEventHandler
	[Serializable]
	public delegate void GridDDLBSettingEventHandler(Object sender, GridDDLBSettingEventArgs e);

	public class GridDDLBSettingEventArgs : EventArgs
	{
		private string	colName;
		public string ColName
		{
			get { return colName;}
		}
		public GridDDLBSettingEventArgs(string colName)
		{
			this.colName = colName;
		}
	}
	#endregion

	#region GridEditStartingEventHandler
	[Serializable]
	public delegate void GridEditStartingEventHandler(object sender, GridEditStartingEventArgs e);

	public class GridEditStartingEventArgs : EventArgs
	{
		private string	colName = "";
		private int		rowNumber = 0;
		private DataRow dataRow = null;
		public string ColName
		{
			get { return colName;}
		}
		public int RowNumber
		{
			get { return rowNumber;}
		}
		public DataRow DataRow
		{
			get { return dataRow;}
		}
		public GridEditStartingEventArgs(string colName, int rowNum, DataRow dataRow)
		{
			this.colName = colName;
			this.rowNumber = rowNum;
			this.dataRow = dataRow;
		}
	}
	#endregion

	#region GridMemoFormShowingEventHandler
	/// <summary>
	/// Grid의 메모박스에 있는 메모창이 Show될때 발생하는 이벤트입니다.
	/// </summary>
	[Serializable]
	public delegate void GridMemoFormShowingEventHandler(object sender, GridMemoFormShowingEventArgs e);
	
	/// <summary>
	/// Grid에서 MemoBox 컬럼에서 메모창이 Show될때 발생하는 Event의 Argument입니다.
	/// </summary>
	public class GridMemoFormShowingEventArgs : EventArgs
	{
		private int		rowNumber;
		private DataRow dataRow;
		private string	colName;
		private bool	cancel;
		/// <summary>
		/// 현재 행번호를 가져옵니다.
		/// </summary>
		public int RowNumber
		{
			get { return rowNumber;}
		}
		/// <summary>
		/// 현재 컬럼명을 가져옵니다.
		/// </summary>
		public string  ColName
		{
			get { return colName;}
		}
		/// <summary>
		/// 현재 행의 DataRow 객체를 가져옵니다.
		/// </summary>
		public DataRow  DataRow
		{
			get { return dataRow;}
		}
		public bool Cancel
		{
			get { return cancel;}
			set { cancel = value;}
		}
		/// <summary>
		/// GridColumnChangedEventArgs 생성자
		/// </summary>
		/// <param name="rowNumber"> 현재행번호 </param>
		/// <param name="colName"> 컬럼명 </param>
		/// <param name="dataRow"> 현재행의 DataRow객체 </param>
		public GridMemoFormShowingEventArgs(int rowNumber, string colName, DataRow dataRow, bool cancel)
		{
			this.rowNumber = rowNumber;
			this.colName = colName;
			this.dataRow = dataRow;
			this.cancel = cancel;
		}
	}
	#endregion

    #region GridReservedMemoButtonClick
    /// <summary>
    /// Grid의 메모박스에 있는 메모창에서 예약글 버튼을 Click시에 발생하는 Event
    /// </summary>
    [Serializable]
    public delegate void GridReservedMemoButtonClickEventHandler(object sender, GridReservedMemoButtonClickEventArgs e);

    /// <summary>
    /// Grid에서 MemoBox 컬럼에서 메모창이 Show될때 발생하는 Event의 Argument입니다.
    /// </summary>
    public class GridReservedMemoButtonClickEventArgs : EventArgs
    {
        private int rowNumber;
        private DataRow dataRow;
        private string colName;
        /// <summary>
        /// 현재 행번호를 가져옵니다.
        /// </summary>
        public int RowNumber
        {
            get { return rowNumber; }
        }
        /// <summary>
        /// 현재 컬럼명을 가져옵니다.
        /// </summary>
        public string ColName
        {
            get { return colName; }
        }
        /// <summary>
        /// 현재 행의 DataRow 객체를 가져옵니다.
        /// </summary>
        public DataRow DataRow
        {
            get { return dataRow; }
        }
        /// <summary>
        /// GridColumnChangedEventArgs 생성자
        /// </summary>
        /// <param name="rowNumber"> 현재행번호 </param>
        /// <param name="colName"> 컬럼명 </param>
        /// <param name="dataRow"> 현재행의 DataRow객체 </param>
        public GridReservedMemoButtonClickEventArgs(int rowNumber, string colName, DataRow dataRow)
        {
            this.rowNumber = rowNumber;
            this.colName = colName;
            this.dataRow = dataRow;
        }
    }
    #endregion

	#region GridRecordEventArgs(저장전 PreSaveLayout에서 조건에 따른 데이타 설정 Event)
	/// <summary>
	/// 서비스로 보낼 자료작성전 발생 이벤트를 처리하는 메서드를 나타냅니다.
	/// </summary>
	[Serializable]
	public delegate void GridRecordEventHandler(object sender, GridRecordEventArgs e);

	/// <summary>
	/// 서비스로 보낼 자료작성전 발생 이벤트에 데이타를 제공합니다.
	/// </summary>
	public class GridRecordEventArgs : EventArgs
	{
		DataRowState	rowState;
		int		rowNumber;
		
		/// <summary>
		/// 현재 Data의 상태를 가져옵니다.
		/// </summary>
		public DataRowState RowState
		{
			get { return rowState; }
		}
		/// <summary>
		/// 현재 Data의 행번호를 가져옵니다.
		/// </summary>
		public int RowNumber
		{
			get { return rowNumber; }
		}
		/// <summary>
		/// RecordEventArgs 생성자
		/// </summary>
		/// <param name="iud"> DataRow의 상태 (Added, Modified, Deleted) </param>
		/// <param name="rowNumber"> 행번호 </param>
		public GridRecordEventArgs(DataRowState rowState, int rowNumber)
		{
			this.rowState = rowState;
			this.rowNumber = rowNumber;
		}
	}
	#endregion
}
