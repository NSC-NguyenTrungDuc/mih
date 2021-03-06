using System;
using System.Reflection;
using System.Data;
using System.Collections;
using System.Drawing;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Globalization;
using System.Runtime.InteropServices;
using System.ComponentModel.Design.Serialization;
using System.Security;
using System.ComponentModel.Design;
using System.Windows.Forms.Design;

namespace IHIS.Framework
{
	/// <summary>
	/// XDictListBox에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxBitmap(typeof(System.Windows.Forms.ListBox))]
	[DefaultProperty("ListItems")]
	[Designer(typeof(XDictListBoxDesigner))]
	public class XDictListBox : IHIS.Framework.XListBox , IDataControl, IEditorControl
	{
		#region Fields
		const int TOP_MARGIN = 2;
		private bool	enterKeyToTab	= true;	//Enter Key를 누르면 TAB Key를 발생시킬지 여부
		private bool	applyLayoutContainerReset = true;  //LayoutContainer의 Reset 호출시에 Reset를 적용할지 여부
		private XComboItemCollection listItems = new XComboItemCollection();
		private bool	dataChanged = false;
		private string dictColumn = "";
		private string userSQL = "";
		private bool codeDisplay = true;
		private XComboSQLType sqlType = XComboSQLType.DictColumn;
		private bool callSelectedIndexChangedEvent = true;
		//OnSelectedIndexChanged Invoker를 call할지 여부, OnBindingContextChanged에서 SelectedIndex변경시는 call하지 않음
		private bool callSelectedIndexChangedEventAtBindingContextChanged = true;
		private bool protect = false;
		private Image emptyImage = null;  //Image설정시 ImageIndex가 유효하지 않을때 그리는 Image
		private ImageList	imageList = null;
		private int origSelectedIndex = -1;
		private BindVarCollection bindVars = new BindVarCollection(); //User Sql사용시 Bind변수 관리
		#endregion

		#region Properties
		/// <summary>
		/// Enter Key를 입력시 TAB Key를 발생시킬지 여부를 설정합니다.
		/// </summary>
		[Browsable(true),Category("추가속성"),DefaultValue(true),
		MergableProperty(true),
		Description("Enter Key를 입력시 TAB Key를 발생시킬지 여부를 설정합니다.")]
		public bool EnterKeyToTab
		{
			get { return enterKeyToTab; }
			set { enterKeyToTab = value;}
		}
		/// <summary>
		/// LayoutContainer(XScreen,XForm)의 Reset호출시에 Reset을 적용할지 여부를 지정합니다.
		/// </summary>
		[Browsable(true),Category("추가속성"),DefaultValue(true),
		MergableProperty(true),
		Description("LayoutContainer(XScreen,XForm)의 Reset호출시에 Reset을 적용할지 여부를 지정합니다.")]
		public bool ApplyLayoutContainerReset
		{
			get { return applyLayoutContainerReset; }
			set { applyLayoutContainerReset = value;}
		}
		[Browsable(true), Category("추가속성")]
		[Description("ListBox를 구성할 Items를 설정합니다.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public virtual XComboItemCollection ListItems
		{
			get	{return listItems;}
		}
		[Browsable(true),
		Category("추가속성"),
		DefaultValue(true),
		Description("자료사전사용시 Code값을 Display할지 여부를 설정합니다.")]
		public bool CodeDisplay
		{
			get { return codeDisplay; }
			set { codeDisplay = value; }
		}
		[Browsable(true),
		Category("추가속성"),
		DefaultValue(XComboSQLType.DictColumn),
		Description("리스트박스설정시 자료사전을 쓸지 사용자SQL 쓸지 여부를 설정합니다.")]
		public XComboSQLType SQLType
		{
			get { return sqlType; }
			set { sqlType = value; }
		}
		[Browsable(true),Category("추가속성"),
		DefaultValue(""),Description("자료사전에서 조회하고자 하는 칼럼명을 입력합니다.")]
		public string DictColumn
		{
			get { return dictColumn;}
			set 
			{
				dictColumn = value;
				//Runtime시 DDLB SET
				if (!DesignMode && (dictColumn != "") && (sqlType == XComboSQLType.DictColumn))
				{
					try
					{
						SetDictDDLB();
					}
					catch{}
				}
			}
		}
		[Browsable(true),Category("추가속성"),
		DesignerSerializationVisibility(DesignerSerializationVisibility.Visible),
		DefaultValue(""),
		Editor(typeof(TextEditor), typeof(UITypeEditor)),
		Description("사용자 정의 SQL을 입력합니다.")]
		public string UserSQL
		{
			get { return userSQL; }
			set
			{
				userSQL = value;
				//RunType시 DDLB Set
				if (!DesignMode && (userSQL.Trim() != "") && (sqlType == XComboSQLType.UserSQL))
				{
					try
					{
						SetDictDDLB();
					}
					catch{}
				}
			}
		}
		/// <summary>
		/// 컨트롤이 편집가능한지 여부를 가져오거나 설정합니다.
		/// </summary>
		[Browsable(true),Category("추가속성"),DefaultValue(false),
		MergableProperty(true),
		Description("Protect속성을 지정합니다.")]
		public bool Protect
		{
			get { return protect; }
			set
			{
				protect = value;
				this.Enabled = !value;
				this.TabStop = !value;
			}
		}
		/// <summary>
		/// 이미지를 표시할 이미지목록을 가져오거나 설정합니다.
		/// </summary>
		[Browsable(true), Category("추가속성"),
		DefaultValue(null),
		MergableProperty(true),
		Description("이미지를 표시할 이미지목록을 설정합니다.")]
		public virtual ImageList ImageList
		{
			get { return imageList; }
			set
			{
				if (imageList != value)
				{
					imageList = value;
					//이미지가 없을때 그릴 Empty이미지 설정
					if (value == null)
						this.emptyImage = null;  
					else
						this.emptyImage = new Bitmap(this.imageList.ImageSize.Width, this.imageList.ImageSize.Height);
				}
			}
		}
		[Browsable(false)]
		protected virtual string DictSQL
		{
			//자료사전 조회 SQL
			//2006.07.11 Bind변수의 판단은 DB종류에 따른 BindSymbol로 판단 (Oracle-> :, SqlServer -> @
			get { return "SELECT A.CODE,A.CODE_NM  FROM ADM1110 A  WHERE A.COL_ID = " + Service.BindSymbol + "f_column ORDER BY A.COL_ID, A.CODE"; }
		}
		/// <summary>
		/// 컨트롤의 값이 변경되었는지 여부를 가져오거나 설정합니다.
		/// </summary>
		[Browsable(false),
		DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
		DefaultValue(false)]
		public bool DataChanged
		{
			get { return dataChanged; }
			set { dataChanged = value;}
		}
		/// <summary>
		/// XDictListBox가 Grid의 Editor로 쓰일때 EditMode로 전환시에 DataValue를 설정시에
		/// callSelectedIndexChangedEvent = false로 하여 SelectedIndexChanged Event가 발생하지 않게함
		/// Grid의 ItemValueChanging Event가 2번 Call되는 것을 방지
		/// </summary>
		internal bool CallSelectedIndexChangedEvent
		{
			get { return this.callSelectedIndexChangedEvent;}
			set { this.callSelectedIndexChangedEvent = value;}
		}
		/// <summary>
		/// DataValue는 외부로 노출하지 않고, Method(GetDataValue, SetDataValue(..)를 통해 접근함.
		/// </summary>
		protected virtual string DataValue
		{
			get	
			{
				if ( this.SelectedIndex >= 0)
					return this.listItems[this.SelectedIndex].ValueItem;
				else
					return string.Empty;
			}
			set	
			{
				bool found = false;
				int index = 0;
				foreach (XComboItem item in this.listItems)
				{
					if (item.ValueItem == value)
					{
						this.SelectedIndex = index;
						found = true;
						break;
					}
					index++;
				}
				if (!found)
					this.SelectedIndex = -1;
			}
		}
		#endregion

		#region Base Properties
		/// <summary>
		/// 컨트롤의 테두리 스타일을 가져오거나 설정합니다.
		/// </summary>	
		[DefaultValue(BorderStyle.FixedSingle)]
		public new BorderStyle BorderStyle
		{
			get { return base.BorderStyle; }
			set { base.BorderStyle = value; }
		}
		/// <summary>
		/// 값을 그릴 데이터 소스의 속성을 지정하는 문자열을 가져오거나 설정합니다.
		/// </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new string ValueMember
		{
			get { return base.ValueMember;}
			set { base.ValueMember = value;}
		}
		/// <summary>
		/// 내용을 표시할 데이터 소스의 속성을 지정하는 문자열을 가져오거나 설정합니다.
		/// </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new string DisplayMember
		{
			get { return base.DisplayMember;}
			set { base.DisplayMember = value;}
		}
		/// <summary>
		/// 이 ListControl 개체의 데이터 소스를 가져오거나 설정합니다.
		/// </summary>
		[Browsable(false),
		DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new object DataSource
		{
			get {return base.DataSource;}
			set {base.DataSource = value;}
		}
		/// <summary>
		/// ComboBox에 포함된 항목의 컬렉션을 나타내는 개체를 가져옵니다.
		/// </summary>
		[Browsable(false),
		DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new ListBox.ObjectCollection Items
		{
			get	{return base.Items;}
		}
		[Browsable(false),
		DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public override SelectionMode SelectionMode
		{
			get { return base.SelectionMode;}
			set {}  //Default 한개만 선택가능, Multi선택 불가
		}
		[Browsable(false),
		DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new bool Sorted
		{
			get { return base.Sorted;}
			set {}  //Set 기능은 없음(DataSource가 연결되어 있으면 Sorted 불가함.NET)
		}
		[Browsable(false),
		DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public override int SelectedIndex
		{
			get { return base.SelectedIndex;}
			set
			{
				if (base.SelectedIndex != value)
				{
					/*2005.11.28 해당되는 값이 없어서 DataValue에서 SelectedIndex를 -1로 설정시에 사용자가 Click하여
					 * 현재 SelectedIndex >= 0일때 base.SelectedIndex를 Set할때 DataManager.Position과 달라서 SelectedIndex가 -1이
					 * 안되고 0가 되는 경우가 발생함.(원인은 정확히 모르겠음)
					 * 따라서, value가 -1이면 Position을 -1로 설정하고 이때 발생하는 OnSelectedIndexChanged에서 Event를
					 * call하지 않도록 Flag를 설정한후 해제함
					*/
					if (value == -1)
					{
						this.callSelectedIndexChangedEvent = false;
						base.DataManager.Position = -1;
						this.callSelectedIndexChangedEvent = true;
					}
					base.SelectedIndex = value;
				}
			}
		}

		#endregion

		#region Event
		/// <summary>
		/// 데이타 유효성검사가 진행될 때 발생하는 Event입니다.
		/// </summary>
		[Browsable(true),Category("추가이벤트"),
		Description("데이타 유효성검사가 진행될 때 발생합니다.")]
		public event DataValidatingEventHandler DataValidating;

		[Browsable(true),
		Category("추가이벤트"),
		Description("ListBox에 자료사전,사용자 SQL로 데이타를 설정하기전에 발생합니다.(Bind 변수 Set)")]
		public event EventHandler DDLBSetting;
		#endregion 

		#region 생성자
		public XDictListBox()
		{
			BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			//DataSource Set
			this.DataSource = listItems;
			this.ValueMember = "ValueItem";
			this.DisplayMember = "DisplayItem";
		}
		#endregion

		#region OnDDLBSetting (ComboBox의 Service Call전에 발생하는 Event, 자료사전 설정시 발생시킴
		protected virtual void OnDDLBSetting(EventArgs e)
		{
			if (DDLBSetting != null)
				DDLBSetting(this, e);
		}
		#endregion

		#region Event Invoker
		/// <summary>
		/// DataValidating Event를 발생시킵니다.
		/// </summary>
		/// <param name="e"> 이벤트 데이터가 들어 있는 ValidateEventArgs </param>
		protected virtual void OnDataValidating(DataValidatingEventArgs e)
		{
			if (DataValidating != null)
				DataValidating(this, e);
		}
		#endregion

		#region override
		/// <summary>
		/// SelectedIndexChanged Event를 발생시킵니다.
		/// (override) 데이타변경여부 속성을 설정합니다.
		/// </summary>
		/// <param name="e"> 이벤트 데이터가 들어 있는 EventArgs </param>
		protected override void OnSelectedIndexChanged(EventArgs e)
		{
			// ListItems를 동적으로 Case에 따라 변경시키는 경우 case1: 2개 Add, case2: 3개 Add를 한후에
			// case2에서 3th를 선택후 case1으로 변경시에 SelectedIndex = 2이므로 out of range Error발생
			// 물론 개발자가 SelectedIndex = 0로 Clear후에 하면 에러가 발생하지 않으나, 안할 경우를 
			// 대비하여 try catch 함
			// Grid의 Editor로 쓰일때 callSelectedIndexChangedEvent가 true이고, BindingCotextChanged Event에서 
			// SelectedIndex를 변경하는 경우가 아니면
			try
			{
				if (this.callSelectedIndexChangedEvent && this.callSelectedIndexChangedEventAtBindingContextChanged)
				{
					//2005.11.28 원래 Index와 다르면 SelectedIndexChanged Event Call
					//ListBox는 사용자가 같은 Item을 선택하더라도 SelectedIndexChanged Event가 계속 발생함. 따라서, 다를 경우에만 Event를 발생시킴
					if (origSelectedIndex != this.SelectedIndex)
					{
						base.OnSelectedIndexChanged(e);
						dataChanged = true;
					}
					this.origSelectedIndex = this.SelectedIndex;
				}
			}
			catch{}
		}
		protected override void OnBindingContextChanged(EventArgs e)
		{
			//화면 동적 생성하여 SetComboItems로 콤보설정시에 SelectedIndex가 제대로
			//설정안되고,화면전환시 이전에 선택한 값이 Clear되는 문제가 발생
			//base.OnBindingContextChanged에서 처리후 SelectedIndex가 -1이 됨
			//이를 방지하기 위해 SelectedIndex 다시 설정
			//SelectedIndex변경시 SelectedIndexChanged Event call하지 않음
			this.callSelectedIndexChangedEventAtBindingContextChanged = false;
			int index = this.SelectedIndex;
			base.OnBindingContextChanged (e);
			if ((index != this.SelectedIndex) && (index < this.listItems.Count))
				this.SelectedIndex = index;

			//Flag Clear
			this.callSelectedIndexChangedEventAtBindingContextChanged = true;
		}
		/// <summary>
		/// Validating Event를 발생시킵니다.
		/// (override) 데이타 변경시 DataValidating Event를 발생시킵니다.
		/// </summary>
		/// <param name="e"> 이벤트 데이터가 들어 있는 CancelEventArgs </param>
		protected override void OnValidating(System.ComponentModel.CancelEventArgs e)
		{
			if (dataChanged)
			{
				DataValidatingEventArgs ve = new DataValidatingEventArgs(e.Cancel, DataValue);
				//Call전에 DataChanged Flag Clear (DataValidating에서 다른 Control에 Focus를 줄때 OnValidating에서 OnDataValidating을 Call하지 않도록 처리함.)
				dataChanged = false;
				OnDataValidating(ve);
				e.Cancel = ve.Cancel;
				//Cancel이면 dataChanged 다시 SET
				if (e.Cancel)
					dataChanged = true;
			}
			base.OnValidating(e);

			//Cancel이 아니면 dataChanged Clear
			if (!e.Cancel)
				dataChanged = false;
		}
		protected override void OnKeyPress(System.Windows.Forms.KeyPressEventArgs e)
		{
			base.OnKeyPress(e);
			// EnterKeyToTab 이고,MultiLine이 아니고, Enter Key 입력시 TAB Send
			if (this.enterKeyToTab && (e.KeyChar == (char)13))
			{
				SendKeys.Send("{TAB}");
			}
		}
		#endregion

		#region SetDictDDLB, SetDictDDLBSub
		/// <summary>
		/// 콤보박스에 자료사전을 설정합니다.
		/// </summary>
		/// <returns> 성공시 true, 실패시 false </returns>
		public bool SetDictDDLB()
		{
			// 자료사전에서 조회하거나 사용자 입력SQL문으로 DDLB SET
			if (this.sqlType == XComboSQLType.DictColumn)
			{
				if (dictColumn.Trim() == string.Empty)
				{
					//XMessageBox.Show("조회할 칼럼명이 입력되지 않았습니다.[XDictComboBox]","자료사전 컬럼설정");
					return false;
				}
				// SQL을 보내서 DataTable Return
				try
				{
					//데이타 설정전 Event Call
					this.OnDDLBSetting(EventArgs.Empty);
					
					//ComboItems Clear
					ListItems.Clear();
					//Bind 변수에 f_column에 자료사전컬럼명 SET
					BindVarCollection bindVarList = new BindVarCollection();
					bindVarList.Add("f_column", this.dictColumn);
					DataTable table = Service.ExecuteDataTable(this.DictSQL, bindVarList);
					SetDictDDLBSub(table);

					return true;
				}
				catch
				{
					return false;
				}
			}
			else
			{
				if (userSQL.Trim() == string.Empty)
				{
					//XMessageBox.Show("SQL문이 입력되지 않았습니다.[XDictComboBox]","설정 에러");
					return false;
				}
				try
				{
					//데이타 설정전 Event Call
					this.OnDDLBSetting(EventArgs.Empty);
				
					//ComboItems Clear
					ListItems.Clear();

					DataTable table = Service.ExecuteDataTable(this.userSQL, this.bindVars);
					SetDictDDLBSub(table);

					return true;
				}
				catch
				{
					return false;
				}

			}
		}
		/// <summary>
		/// SQL조회후 조회 Data를 ListItems에 Setting합니다.
		/// </summary>
		/// <param name="service"></param>
		// 각 Site에 따라 전문구조가 다르므로 자료사전 Setting 방법도 달라야 함
		protected virtual void SetDictDDLBSub(DataTable table)
		{
			if (table == null) return;

			if (table.Rows.Count < 1) return;

			foreach (DataRow dtRow in table.Rows)
			{
				// 자료사전으로 Setting시에 isCodeDisplay = true이면 DisplayItem = Code.Code명으로 Set
				if(this.sqlType == XComboSQLType.DictColumn && this.codeDisplay)
					this.ListItems.Add(dtRow[0].ToString()	 , dtRow[0].ToString() + "." + dtRow[1].ToString());
				else
					this.ListItems.Add(dtRow[0].ToString()	 , dtRow[1].ToString());
			}
		}
		#endregion

		#region SetBindVarList
		public void SetBindVarValue(string varName, string varValue)
		{
			//사용자정의 SQL에서 사용한 Bind 변수의 값을 설정
			this.bindVars.Add(varName, varValue);
		}
		#endregion

		#region Implement IDataControl 
		object IDataControl.DataValue
		{
			get	{ return this.DataValue; }
			set	
			{ 
				this.DataValue = (value == null ? "" : value.ToString());
				//IDataControl을 통해서 DataValue 설정시는 DataChanged = false (DataValidating Event call하지 않음)
				this.DataChanged = false;
			}
		}
		ControlDataType IDataControl.ContType
		{
			get{return ControlDataType.String;}
		}
		object IEditorControl.DataValue
		{
			get	{ return this.DataValue; }
			set	
			{ 
				this.DataValue = (value == null ? "" : value.ToString());
				//IEditorControl을 통해서 DataValue 설정시는 DataChanged = false (DataValidating Event call하지 않음)
				this.DataChanged = false;
			}
		}
		/// <summary>
		/// 편집중인 데이타를 컨트롤의 값으로 설정합니다.
		/// </summary>
		/// <returns> 설정 성공시 true, 실패시 false </returns>
		public virtual bool AcceptData()
		{
			if (dataChanged)
			{
				DataValidatingEventArgs ve = new DataValidatingEventArgs(false, DataValue);
				//2006.05.02 Call전에 DataChanged Flag Clear (DataValidating Event에서 AcceptData를 호출하는 Logic이 들어가는 경우 무한 Loop방지)
				dataChanged = false;
				OnDataValidating(ve);
				//Cancel시에 Flag 다시 설정
				if (ve.Cancel)
					dataChanged = true;

				return !ve.Cancel;
			}
			else
				return true;
		}
		/// <summary>
		/// 컨트롤의 값을 Clear합니다.
		/// </summary>
		public void ResetData()
		{
			this.SelectedItem = null; //선택된 Item Clear
			dataChanged = false;
		}
		#endregion

		#region SetListItems
		public virtual void SetListItems(DataTable dataTable, string displayMember, string valueMember, XComboSetType setType)
		{
			if (dataTable == null) return;
			//DisplayMember로 지정한 컬럼이 없으면 Return
			if (!dataTable.Columns.Contains(displayMember)) return;
			//ValueMember로 지정한 컬럼이 없으면 Return
			if (!dataTable.Columns.Contains(valueMember)) return;
			
			
			//DataSource Clear후 ComboItems, Items 다시 설정후 SET
			this.DataSource = null;

			this.listItems.Clear();
			//전체, 없음 추가
			if (setType == XComboSetType.AppendAll)
				this.listItems.Add("%", XMsg.GetField("F009")); //(전체)
			else if (setType == XComboSetType.AppendNone)
				this.listItems.Add("",XMsg.GetField("F009"));  //(없음)

			//DataRow Add
			foreach (DataRow dataRow in dataTable.Rows)
				this.listItems.Add(dataRow[valueMember].ToString(), dataRow[displayMember].ToString());

			this.DataSource = listItems;
			this.ValueMember = "ValueItem";
			this.DisplayMember = "DisplayItem";
		}
		/// <summary>
		/// 지정한 테이블로 ComboItems를 설정합니다.
		/// </summary>
		public virtual void SetListItems(DataTable dataTable, string displayMember, string valueMember)
		{
			SetListItems(dataTable, displayMember, valueMember, XComboSetType.NoAppend);
		}
		#endregion

		#region OnDrawItem override
		/// <summary>
		/// (override) ListBox의 상태에 따라 Item을 그립니다.
		/// </summary>
		/// <param name="e"> 이벤트 데이터가 들어 있는 DrawItemEventArgs </param>
		protected override void OnDrawItem(DrawItemEventArgs e)
		{
			if(Site!=null)
				return;
			if(e.Index > -1)
			{
				string text = string.Empty;
				Image image = null;
				int leftMargin = 0;
				//DataSource는 XComboItemCollection만 가능함.
				if ((this.DataSource != null) && (this.DataSource is XComboItemCollection))
				{
					XComboItem cItem = this.listItems[e.Index];
					text = cItem.DisplayItem;
					if (this.imageList != null)
					{
						leftMargin = this.imageList.ImageSize.Width;
						if ((cItem.ImageIndex >= 0) && (cItem.ImageIndex < this.imageList.Images.Count))
							image = this.imageList.Images[cItem.ImageIndex];
						else  //Index가 맞지 않으면 EmptyImage Set
							image = this.emptyImage;
					}
				}
				//현재 SelectedIndex < 0으면 보통으로 그림
				if (this.SelectedIndex < 0)
				{
					if (e.Index % 2 == 0)
						e.Graphics.FillRectangle(new SolidBrush(AlternatingItemBackColor.Color),e.Bounds);
					else
						e.Graphics.FillRectangle(new SolidBrush(ItemBackColor.Color),e.Bounds);
					//Image Draw
					if (image != null)
						e.Graphics.DrawImage(image, e.Bounds.X, e.Bounds.Y + TOP_MARGIN);
					e.Graphics.DrawString(text,Font,new SolidBrush(this.ForeColor.Color),
						e.Bounds.X + leftMargin , e.Bounds.Y + TOP_MARGIN);				
					e.Graphics.DrawRectangle(new Pen(ItemBorderColor.Color),e.Bounds);
				}
				else
				{
					//선택된 상태이면 Highlight
					if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
					{
						e.Graphics.FillRectangle(new SolidBrush(SystemColors.Highlight),e.Bounds);
						//Image Draw
						if (image != null)
							e.Graphics.DrawImage(image, e.Bounds.X, e.Bounds.Y + TOP_MARGIN);
						e.Graphics.DrawString(text,Font,new SolidBrush(SystemColors.HighlightText),
							e.Bounds.X + leftMargin , e.Bounds.Y + TOP_MARGIN);
						e.Graphics.DrawRectangle(new Pen(Color.Blue),e.Bounds);

					}
					else  //그외는 일반모양
					{
						if (e.Index % 2 == 0)
							e.Graphics.FillRectangle(new SolidBrush(AlternatingItemBackColor.Color),e.Bounds);
						else
							e.Graphics.FillRectangle(new SolidBrush(ItemBackColor.Color),e.Bounds);
						//Image Draw
						if (image != null)
							e.Graphics.DrawImage(image, e.Bounds.X, e.Bounds.Y + TOP_MARGIN);
						e.Graphics.DrawString(text,Font,new SolidBrush(this.ForeColor.Color),
							e.Bounds.X + leftMargin , e.Bounds.Y + TOP_MARGIN);				
						e.Graphics.DrawRectangle(new Pen(ItemBorderColor.Color),e.Bounds);
					}
				}
			}
		}
		#endregion

		#region Data 가져오기, 설정 Method
		/// <summary>
		/// 해당 컨트롤의 DataValue를 가져옵니다.
		/// </summary>
		/// <returns></returns>
		public string GetDataValue()
		{
			return this.DataValue;
		}
		/// <summary>
		/// 해당 컨트롤의 DataValue를 지정합니다.(이떄 DataChanged는 false로 설정합니다. Validation Check하지 않음)
		/// </summary>
		/// <param name="dataValue"></param>
		public void SetDataValue(object dataValue)
		{
			((IDataControl) this).DataValue = dataValue;
		}
		/// <summary>
		/// 해당 컨트롤의 DataValue를 지정합니다.(이떄 DataChanged는 true로 설정합니다. Validation Check함)
		/// </summary>
		public void SetEditValue(object dataValue)
		{
			((IDataControl) this).DataValue = dataValue;
			this.DataChanged = true;
		}
		#endregion

		#region Paint Subroutines
		private void DrawBorder(DrawState state)
		{
			//Border를 그리기 위한 Pen
			Pen borderPen = null;
			switch (state)
			{
				case DrawState.Hot :
					borderPen = new Pen(XColor.ActiveBorderColor.Color, 2);
					break;
				case DrawState.Disable :
					borderPen = SystemPens.ControlDark;
					break;
				default :
					borderPen = new Pen(XColor.NormalBorderColor.Color, 2);
					break;
			}

			IntPtr hDC = User32.GetDC(Handle);
			Rectangle rc = Bounds;
			using (Graphics g = Graphics.FromHdc(hDC))
			{
				//Draw Border
				g.DrawRectangle(borderPen, 0, 0, rc.Width , rc.Height );
			}

			// Release DC
			User32.ReleaseDC(Handle, hDC);
		}
		#endregion

	}

	#region XDictListBoxDesigner
	internal class XDictListBoxDesigner : System.Windows.Forms.Design.ControlDesigner
	{
		private XDictListBox listBox = null;
		private ISelectionService iSvc;
		private IComponentChangeService iComp;
		private IDesignerHost iHost;
		/// <summary>
		/// 디자이너를 지정된 구성 요소로 초기화합니다.
		/// </summary>
		/// <param name="component">디자이너에 연결할 IComponent</param>
		public override void Initialize(IComponent component)
		{
			base.Initialize(component);

			// Design하고있는 Control 등록
			listBox = (XDictListBox) component;

			//Service Instance Set
			iSvc = (ISelectionService) GetService(typeof(ISelectionService));
			iComp = (IComponentChangeService) GetService(typeof(IComponentChangeService));
			iHost = (IDesignerHost) GetService(typeof(IDesignerHost));
			iComp.ComponentRemoving += new ComponentEventHandler(OnComponentRemoving);
		}

		/// <summary>
		/// 관리되지 않는 리소스를 해제하고 필요에 따라 관리되는 리소스를 해제합니다.
		/// </summary>
		/// <param name="disposing">관리되는 리소스와 관리되지 않는 리소스를 모두 해제하려면 true로 설정하고, 관리되지 않는 리소스만 해제하려면 false로 설정합니다.</param>
		protected override void Dispose(bool disposing)
		{
			// Unhook events
			iComp.ComponentRemoving -= new ComponentEventHandler(OnComponentRemoving);
			base.Dispose(disposing);
		}

		/// <summary>
		/// 디자이너가 관리하는 구성 요소와 관련된 구성 요소 컬렉션을 가져옵니다.
		/// </summary>
		public override ICollection AssociatedComponents
		{
			get 
			{ 
				//복사, 끌기 또는 이동 작업 중에 디자이너가 관리하는 구성 요소와 함께 복사 또는 이동할 구성 요소를 지정
				// XComboBoxItem을 관련 Component로 함
				return listBox.ListItems;
			}
		}

		private void OnComponentRemoving(object sender, ComponentEventArgs e)
		{
			//XComboBox가 제거될때 관련된 XComboItem도 같이 제거
			if (e.Component == listBox)
			{
				XComboItem cItem = null;
				for (int idx = listBox.ListItems.Count - 1; idx >= 0; idx--)
				{
					cItem = listBox.ListItems[idx];
					iComp.OnComponentChanging(listBox, null);
					listBox.ListItems.Remove(cItem);
					iHost.DestroyComponent(cItem);
					iComp.OnComponentChanged(listBox, null, null, null);
				}
			}
		}
	}
	#endregion
}
