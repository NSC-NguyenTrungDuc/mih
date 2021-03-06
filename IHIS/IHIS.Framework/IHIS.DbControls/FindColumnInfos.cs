using System;
using System.Collections;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;
using System.Text;
using System.Drawing;
using System.Drawing.Design;
using System.Data;
using System.ComponentModel.Design.Serialization;

namespace IHIS.Framework
{
	#region Enum
	public enum FindColType
	{
		String,
		Number,
		Date,
		DateTime
	}
	public enum FilterType
	{
		/// <summary>
		/// Filter 컬럼임
		/// </summary>
		Yes,
		/// <summary>
		/// Filter 컬럼이 아님
		/// </summary>
		No,
		/// <summary>
		/// Filter 컬럼이며 초기 Filter컬럼임
		/// </summary>
		InitYes,
	}
	#endregion

	#region FindColumnInfo
	/// <summary>
	/// FindColumnInfo에 대한 요약 설명입니다.
	/// </summary>
	[Serializable,
	ToolboxItem(false),
	DesignTimeVisible(false)]
	public class FindColumnInfo : System.ComponentModel.Component
	{
		#region Fields
		private string colName = string.Empty;   // Column Name
		private FindColType colType = FindColType.String;
		private string	mask = string.Empty;
		private HorizontalAlignment colAlign = HorizontalAlignment.Left;
		private string  headerText = string.Empty;     // Header Text
		private int		colWidth  = 80  ;   //ColumnWidth
		private bool    isVisible = true ;   // Column Visible 여부
		private int		decimalDigits = 0;   // Decimal의 소수자리수
		private FilterType	filterType = FilterType.No; //필터 컬럼인지 여부
		#endregion

		#region Properties
		[Category("컬럼정보"),DefaultValue("")]
		public string ColName
		{
			get { return colName; }
			set { colName = value;}
		}
		[Category("컬럼정보"),DefaultValue(FindColType.String)]
		public FindColType ColType
		{
			get { return colType; }
			set 
			{ 
				colType = value ;
//				switch (colType)
//				{
//					case FindColType.String:
//						this.mask = MaskHelper.CStringDefaultMask;
//						this.colAlign = HorizontalAlignment.Left;
//						break;
//					case FindColType.Date:
//						this.mask = MaskHelper.CDateDefaultMask;
//						this.colAlign = HorizontalAlignment.Center;
//						break;
//					case FindColType.DateTime:
//						this.mask = MaskHelper.CDateTimeDefaultMask;
//						this.colAlign = HorizontalAlignment.Center;
//						break;
//					case FindColType.Number:
//						this.mask = MaskHelper.CStringDefaultMask;
//						this.colAlign = HorizontalAlignment.Right;
//						break;
//				}
			}
		}
		[Category("컬럼정보"),DefaultValue("")]
		public string Mask
		{
			get { return mask ;}
			set 
			{ 
				//Number는 Mask없음
				if (this.colType == FindColType.Number)
				{
					mask = "";
					return;
				}
				string errMsg = "";
				MaskType mType = MaskType.String;
				if (this.ColType == FindColType.Date)
					mType = MaskType.Date;
				else if (this.ColType == FindColType.DateTime)
					mType = MaskType.DateTime;
				if (!MaskHelper.IsValidMask(mType, value, out errMsg))
				{
					MessageBox.Show(errMsg);
					return;
				}
				mask = value;
			}
		}
		[Category("컬럼정보"),DefaultValue("")]
        [Localizable(true)]
		public string HeaderText
		{
			get { return headerText ;}
			set { headerText = value ;}
		}
		[Category("컬럼정보"),DefaultValue(true)]
		public bool IsVisible
		{
			get { return isVisible ;}
			set 
			{ 
				isVisible = value ;
				if (isVisible)
					this.colWidth = 80;
				else
					this.colWidth = 0;
			}
		}
		[Category("컬럼정보"),DefaultValue(80)]
		public int ColWidth
		{
			get { return colWidth ;}
			set { colWidth = Math.Max( value, 0) ;}
		}
		[Category("컬럼정보"),DefaultValue(0)]
		public int DecimalDigits
		{
			get { return decimalDigits ;}
			set { decimalDigits = Math.Min(Math.Max(value, 0), 10) ;}
		}
		[Category("컬럼정보"),DefaultValue(FilterType.No)]
		public FilterType FilterType
		{
			get { return filterType ;}
			set 
			{ 
				//FilterColumn은 String만 가능 true 설정가능
				if (this.colType != FindColType.String)
				{
					if(value != FilterType.No)
					{
						MessageBox.Show("Filter컬럼은 String형만 지정가능합니다.");
						return;
					}
				}
				filterType = value ;
			}
		}
		[Category("컬럼정보"),DefaultValue(HorizontalAlignment.Left)]
		public HorizontalAlignment ColAlign
		{
			get { return colAlign;}
			set { colAlign = value;}
		}
		#endregion

		#region 생성자
		public FindColumnInfo()
		{
		}
		public FindColumnInfo(string colName, string headerText, FindColType colType, int colWidth, int decimalDigits, bool isVisible, FilterType filterType)
		{
			this.colName = colName;
			this.colType = colType;
			this.headerText = headerText;
			this.isVisible = isVisible;
			this.colWidth = colWidth;
			this.decimalDigits = decimalDigits;
			this.filterType = filterType;
		}
		public FindColumnInfo(string colName, string headerText, FindColType colType, int colWidth, int decimalDigits, bool isVisible, FilterType filterType, string mask, HorizontalAlignment colAlign)
			:this(colName, headerText, colType,colWidth,decimalDigits, isVisible, filterType)
		{
			this.mask = mask;
			this.colAlign = colAlign;
		}
		#endregion

	}
	#endregion

	#region FindColumnInfo Type Converter
	/// <summary>
	/// FindColumnInfo Type Converter
	/// </summary>
	public class FindColumnInfoTypeConverter : TypeConverter
	{
		public override bool CanConvertTo (ITypeDescriptorContext context, System.Type destinationType)
		{
			if (destinationType == typeof(InstanceDescriptor))
				return true;

			return base.CanConvertTo(context, destinationType);
		}

		public override object ConvertTo
			(ITypeDescriptorContext context, CultureInfo culture,
			object value, System.Type destinationType )
		{
			FindColumnInfo fInfo;
			object[] args;

			System.Type[] Types = new Type[]{typeof(string), typeof(string), typeof(FindColType), typeof(int), typeof(int), typeof(bool), typeof(FilterType), typeof(string), typeof(HorizontalAlignment)};

			if (destinationType == typeof(InstanceDescriptor))
			{
				if (value is FindColumnInfo)
				{
					fInfo = (FindColumnInfo)value;
					args = new Object[]{fInfo.ColName, fInfo.HeaderText, fInfo.ColType, fInfo.ColWidth, fInfo.DecimalDigits, fInfo.IsVisible, fInfo.FilterType, fInfo.Mask, fInfo.ColAlign };

					InstanceDescriptor id = new InstanceDescriptor(fInfo.GetType().GetConstructor(Types), args);

					return id;
				}
			}

			return base.ConvertTo(context, culture, value, destinationType);
		}
	}
	#endregion

	#region FindColumnInfo Collection
	/// <summary>
	/// Predata Item Collection
	/// </summary>
	[Serializable]
	[Editor(typeof(FindColumnInfoEditor), typeof(UITypeEditor))]
	public class FindColumnInfoCollection : CollectionBase
	{
		/// <summary>
		/// FindColumnInfoCollection 생성자
		/// </summary>
		public FindColumnInfoCollection()
		{
		}
		
		/// <summary>
		/// 지정한 Index에 있는 FindColumnInfo을 가져옵니다.
		/// </summary>
		public FindColumnInfo this[int index]
		{
			get 
			{ 
				if (index > Count - 1 || index < 0)
					return null;
				else
					return (FindColumnInfo)List[index];
			}
			
		}
		
		/// <summary>
		/// 지정한 Key에 있는 FindColumnInfo을 가져옵니다.
		/// </summary>
		public FindColumnInfo this[string key]
		{
			get
			{
				if (key == "") return null;
				foreach (FindColumnInfo item in this)
				{
					if (item.ColName == key) return item;
				}
				return null;
			}
		}

		/// <summary>
		/// FindColumnInfo 을 Collection의 끝에 추가합니다.
		/// </summary>
		/// <param name="item"> FindColumnInfo class</param>
		public void Add(FindColumnInfo item)
		{
			//InitializeComponents에서 Serialize되는 순서가 AddRange -> Add가 먼저 발생하고,
			//다음에 FindColumnInfo의 ColName등 Property가  설정되므로 ColName이 ""인 상태에서
			//Add가 발생하여 Exception이 발생함. 따라서, 동일한 값 확인여부를 Check하지 않음
//			foreach (FindColumnInfo pItem in List)
//			{
//				if (pItem.ColName == item.ColName)
//				{
//					throw(new Exception("[FindColumnInfo]이미 등록된 컬럼명과 동일합니다."));
//				}
//			}
			List.Add(item);
		}
		/// <summary>
		/// FindColumnInfo[]를 Collection에 추가합니다.
		/// </summary>
		/// <param name="items"> FindColumnInfo class Array</param>
		public void AddRange(FindColumnInfo[] items)
		{
			List.Clear();
			foreach (FindColumnInfo Item in items)
			{
				Add(Item);
			}
		}
		/// <summary>
		/// FindColumnInfo을 생성 Collection의 끝에 추가합니다.
		/// </summary>
		/// <param name="colName"> FindColumnInfo의 컬럼명 </param>
		/// <param name="headerText"> FindColumnInfo의 헤더의 텍스트 </param>
		/// <param name="colType"> FindColumnInfo의 컬럼타입 </param>
		/// <param name="colWidth"> FindColumnInfo의 컬럼의 너비 </param>
		/// <param name="decimalDigits"> FindColumnInfo의 Decimal Digits </param>
		/// <param name="isVisible"> FindColumnInfo의 Visible여부 </param>
		/// <param name="isFilterColumn"> FindColumnInfo의 Filterring컬럼여부 </param>
		public void Add(string colName, string headerText, FindColType colType, int colWidth, int decimalDigits, bool isVisible, FilterType filterType)
		{
			if (colName == "")
			{
				throw(new Exception("컬럼명이 입력되지 않았습니다."));
			}
			foreach (FindColumnInfo pItem in List)
			{
				if (pItem.ColName == colName)
					throw(new Exception("[FindColumnInfo]이미 등록된 컬럼명과 동일합니다."));
			}
			FindColumnInfo	item = new FindColumnInfo(colName,headerText,colType,colWidth,decimalDigits,isVisible,filterType);
			List.Add(item);
		}

		/// <summary>
		/// 해당 Index의 PreDataItem을 제거합니다.
		/// </summary>
		/// <param name="index"></param>
		public void Remove(int index)
		{
			if (index > Count - 1 || index < 0)
			{
				throw (new IndexOutOfRangeException());
			}
			else
			{
				List.RemoveAt(index); 
			}
		}
		/// <summary>
		/// 해당 이름의 PreDataItem을 제거합니다.
		/// </summary>
		/// <param name="dataName"> PreData 이름 </param>
		public void Remove(string colName)
		{
			for (int i = 0 ; i < List.Count ; i++)
			{
				FindColumnInfo pItem = (FindColumnInfo) List[i];
				if (pItem.ColName == colName)
					List.RemoveAt(i);
			}
		}

		/// <summary>
		/// 컬렉션에서 맨 처음 발견되는 FindColumnInfo객체를 제거합니다.
		/// </summary>
		/// <param name="item">제거할 FindColumnInfo객체</param>
		public void Remove(FindColumnInfo item)
		{
			List.Remove(item);
		}

		/// <summary>
		/// 요소가 컬렉션에 있는지 여부를 확인합니다.
		/// </summary>
		/// <param name="item">컬렉션에서 찾을 PreDataItem입니다.</param>
		/// <returns>FindColumnInfo가 컬렉션에 있으면 true이고, 그렇지 않으면 false입니다.</returns>
		public bool Contains(FindColumnInfo item)
		{
			return List.Contains(item);
		}
		/// <summary>
		/// 해당이름의 요소가 컬렉션에 있는지 여부를 확인합니다.
		/// </summary>
		/// <param name="colName"></param>
		/// <returns> FindColumnInfo가 컬렉션에 있으면 true이고, 그렇지 않으면 false입니다. </returns>
		public bool Contains(string colName)
		{
			foreach (FindColumnInfo item in List)
				if (item.ColName == colName)
					return true;
			return false;
		}
	}
	#endregion
}
