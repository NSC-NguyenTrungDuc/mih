using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Diagnostics;
using System.Globalization;
using System.ComponentModel.Design.Serialization;

namespace IHIS.Framework
{
	#region XGridComputedCell
	/// <summary>
	/// ComputedCell의 정보를 관리하는 class입니다.
	/// </summary>
	[Serializable,
	ToolboxItem(false),
	DesignTimeVisible(false)]
	[Designer(typeof(XGridComputedCellDesigner))]
	public class XGridComputedCell : Component
	{
		#region Fields
		private Guid identifier = Guid.NewGuid();
		private string groupName = "";
		private string expression = "";
		private XGridComputedKind computedKind = XGridComputedKind.Text;
		private int decimalDigits = 0;
		private ArrayList maskSymbols = new ArrayList();   //MaskSymbol을 관리하는 ArrayList

		private Font font = new Font("MS UI Gothic",9.75f);
		private XCellDrawMode drawMode = XCellDrawMode.Flat;
		private ContentAlignment textAlignment = ContentAlignment.MiddleRight;
		private ImageList	imageList = null;
		private int			imageIndex = -1;
		private Image image = null;
		private ContentAlignment imageAlign = ContentAlignment.MiddleLeft;
		private bool  imageStretch = false;
		private XColor backColor = XColor.XGridComputedCellBackColor;
		private XColor gradientStart = XColor.XGridColHeaderGradientStartColor;
		private XColor gradientEnd = XColor.XGridColHeaderGradientEndColor;
		private XColor foreColor = XColor.NormalForeColor;
		private XColor selectedBackColor = XColor.XGridSelectedCellBackColor;
		private XColor selectedForeColor = XColor.XGridSelectedCellForeColor;
		private int row = 0;
		private int col = 0;
		private int colSpan = 1;
		private int rowSpan = 1;
		#endregion

		#region Constructor
		/// <summary>
		/// CellInfo 생성자
		/// </summary>
		public XGridComputedCell()
		{
		}
		#endregion

		#region Properties
		/// <summary>
		/// Component를 식별할수 있는 식별자입니다.
		/// </summary>
		[Browsable(false),
		DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		internal Guid Identifier
		{
			get { return identifier;}
		}
		/// <summary>
		/// 컬럼의 Row의 위치를 가져오거나 설정합니다.
		/// </summary>
		[Browsable(false),
		DefaultValue(0)]
		public int Row
		{
			get { return row;}
			set { row = value;}
		}
		/// <summary>
		/// 컬럼의 Col의 위치를 가져오거나 설정합니다.
		/// </summary>
		[Browsable(false),
		DefaultValue(0)]
		public int Col
		{
			get { return col;}
			set { col = value;}
		}
		/// <summary>
		/// 컬럼의 RowSpan의 값을 가져오거나 설정합니다.
		/// </summary>
		[Browsable(false),
		DefaultValue(1)]
		public int RowSpan
		{
			get { return rowSpan;}
			set { rowSpan = value;}
		}
		/// <summary>
		/// 컬럼의 ColSpan의 값을 가져오거나 설정합니다.
		/// </summary>
		[Browsable(false),
		DefaultValue(1)]
		public int ColSpan
		{
			get { return colSpan;}
			set { colSpan = value;}
		}
		/// <summary>
		/// Compute Field의 그룹명을 가져오거나 설정합니다.
		/// </summary>
		[Browsable(false)]
		public string GroupName
		{
			get { return groupName; }
			set 
			{ 
				if (value != "")
					groupName = value ;
			}
		}
		/// <summary>
		/// Compute Field의 Expression에 따른 ComputeKind를 가져오거나 설정합니다.
		/// </summary>
		[Browsable(false),
		DefaultValue(XGridComputedKind.Text)]
		public XGridComputedKind ComputedKind
		{
			get { return computedKind; }
			set { computedKind = value;}
		}
		/// <summary>
		/// MaskSymbol을 관리하는 ArrayList를 가져옵니다.
		/// </summary>
		[Browsable(false)]
		public ArrayList MaskSymbols
		{
			get { return maskSymbols;}
		}
		/// <summary>
		/// Text Type일때 Compute Field에 Display할 Text를 가져오거나 설정합니다.
		/// </summary>
		[Category("Compute정보"),
		MergableProperty(false),
		Description("Computed 컬럼의 Expression을 설정합니다."),
		Editor(typeof(XGridComputedExpressionEditor), typeof(UITypeEditor))]
		public string Expression
		{
			get { return expression; }
			set { expression = value ;}
		}
		/// <summary>
		/// DecimalDigits를 가져오거나 설정합니다.
		/// </summary>
		[Category("컬럼모양"),
		DefaultValue(0),
		Description("DecimalDigits를 설정합니다.")]
		public int DecimalDigits
		{
			get { return decimalDigits;}
			set { decimalDigits = Math.Max(value,0);}
		}
		/// <summary>
		/// Computed 컬럼의 Font를 가져오거나 설정합니다.
		/// </summary>
		[Category("컬럼모양"),
		MergableProperty(true),
		DefaultValue(typeof(Font), "MS UI Gothic, 9.75pt"),
		Description("Computed 컬럼의 Font를 설정합니다.")]
		public Font Font
		{
			get { return font;}
			set { font = value;}
		}
		/// <summary>
		/// Computed 컬럼의 그리기모드를 가져오거나 설정합니다.
		/// </summary>
		[Category("컬럼모양"),
		MergableProperty(true),
		DefaultValue(XCellDrawMode.Flat),
		Description("Computed 컬럼의 그리기모드를 설정합니다.")]
		public XCellDrawMode DrawMode
		{
			get { return drawMode;}
			set { drawMode = value;}
		}
		/// <summary>
		/// Computed 컬럼의 배경색을 가져오거나 설정합니다.(Flat형일때 적용됨)
		/// </summary>
		[Category("컬럼모양"),
		DefaultValue(typeof(XColor), "XGridComputedCellBackColor"),
		Description("Computed 컬럼의 배경색을 설정합니다.(Flat형일때 적용됨)")]
		public XColor BackColor
		{
			get { return backColor;}
			set { backColor = value;}
		}
		/// <summary>
		/// Computed 컬럼의 Gradient 시작색을 가져오거나 설정합니다.(Gradient형일때 적용됨)
		/// </summary>
		[Category("컬럼모양"),
		DefaultValue(typeof(XColor), "XGridColHeaderGradientStartColor"),
		Description("Computed 컬럼의 Gradient 시작색을 설정합니다.(Gradient형일때 적용됨)")]
		public XColor GradientStart
		{
			get { return gradientStart;}
			set { gradientStart = value;}
		}
		/// <summary>
		/// Computed 컬럼의 Gradient 종료색을 가져오거나 설정합니다.(Gradient형일때 적용됨)
		/// </summary>
		[Category("컬럼모양"),
		DefaultValue(typeof(XColor), "XGridColHeaderGradientEndColor"),
		Description("Computed 컬럼의 Gradient 종료색을 설정합니다.(Gradient형일때 적용됨)")]
		public XColor GradientEnd
		{
			get { return gradientEnd;}
			set { gradientEnd = value;}
		}
		/// <summary>
		/// Computed 컬럼의 텍스트색을 가져오거나 설정합니다.
		/// </summary>
		[Category("컬럼모양"),
		DefaultValue(typeof(XColor), "NormalForeColor"),
		Description("Computed 컬럼의 텍스트색을 설정합니다.")]
		public XColor ForeColor
		{
			get { return foreColor;}
			set { foreColor = value;}
		}
		/// <summary>
		/// 컬럼이 선택될때 배경색을 가져오거나 설정합니다.
		/// </summary>
		[Category("컬럼모양"),
		DefaultValue(typeof(XColor), "XGridSelectedCellBackColor"),
		Description("컬럼이 선택될때 배경색을 설정합니다.")]
		public XColor SelectedBackColor
		{
			get { return selectedBackColor;}
			set { selectedBackColor = value;}
		}
		/// <summary>
		/// 컬럼이 선택될때 텍스트색을 가져오거나 설정합니다.
		/// </summary>
		[Category("컬럼모양"),
		DefaultValue(typeof(XColor), "XGridSelectedCellForeColor"),
		Description("컬럼이 선택될때 텍스트색을 설정합니다.")]
		public XColor SelectedForeColor
		{
			get { return selectedForeColor;}
			set { selectedForeColor = value;}
		}
		/// <summary>
		/// Text의 Align을 가져오거나 설정합니다.
		/// </summary>
		[Category("컬럼모양"),
		DefaultValue(ContentAlignment.MiddleRight),
		Description("Text의 Align을 설정합니다.")]
		public ContentAlignment TextAlignment
		{
			get { return textAlignment;}
			set { textAlignment = value;}
		}
		/// <summary>
		/// 이미지를 표시할 이미지목록을 가져오거나 설정합니다.
		/// </summary>
		[Browsable(true), Category("컬럼모양"),
		DefaultValue(null),
		MergableProperty(true),
		Description("이미지를 표시할 이미지목록을 설정합니다.")]
		public ImageList ImageList
		{
			get { return imageList; }
			set
			{
				if (imageList != value)
				{
					imageList = value;
					if (imageList == null)
					{
						this.imageIndex = -1;
						this.Image = null;
					}
					else
					{
						try	{this.Image = imageList.Images[imageIndex];	}
						catch {this.Image = null;}
					}
				}
			}
		}
		[Browsable(true), Category("컬럼모양"),
		DefaultValue(-1),
		MergableProperty(true),
		Description("이미지를 표시할 이미지목록의 인덱스를 설정합니다.")]
		[Editor(typeof(IHIS.Framework.ImageIndexesEditor), typeof(UITypeEditor))]
		[ImageList("ImageList")]
		public  int ImageIndex
		{
			get { return imageIndex; }
			set
			{
				if (imageIndex != value)
				{
					imageIndex = value;
					if (imageIndex < 0)
						this.Image = null;
					else
					{
						try{ this.Image = imageList.Images[value];}
						catch{this.Image = null;	}
					}
				}
			}
		}
		/// <summary>
		/// Image를 가져오거나 설정합니다.
		/// </summary>
		[Category("컬럼모양"),
		DefaultValue(null),
		Description("Image를 설정합니다.")]
		public Image Image
		{
			get { return image;}
			set { image = value;}
		}
		/// <summary>
		/// Image Alignment를 가져오거나 설정합니다.
		/// </summary>
		[Category("컬럼모양"),
		MergableProperty(true),
		DefaultValue(ContentAlignment.MiddleLeft),
		Description("Image Align을 설정합니다.")]
		public ContentAlignment ImageAlign
		{
			get { return imageAlign;}
			set { imageAlign = value;}
		}
		/// <summary>
		/// Image의 Stretch여부를 가져오거나 설정합니다.
		/// </summary>
		[Category("컬럼모양"),
		MergableProperty(true),
		DefaultValue(false),
		Description("Image의 Stretch여부를 설정합니다.")]
		public bool ImageStretch
		{
			get { return imageStretch;}
			set { imageStretch = value;}
		}
		#endregion
	}
	#endregion

	#region XGridComputedCell Type Converter
	/// <summary>
	/// XGridComputedCell Type Converter
	/// </summary>
	public class XGridComputedCellTypeConverter : TypeConverter
	{
		/// <summary>
		/// 이 변환기가 개체를 지정된 형식으로 변환할 수 있는지 여부를 반환합니다.
		/// </summary>
		/// <param name="context"> 형식 컨텍스트를 제공하는 ITypeDescriptorContext </param>
		/// <param name="destinationType"> 변환할 대상 형식을 나타내는 Type </param>
		/// <returns> 이 변환기가 변환을 수행할 수 있으면 true이고, 그렇지 않으면 false </returns>
		public override bool CanConvertTo (ITypeDescriptorContext context, System.Type destinationType)
		{
			if (destinationType == typeof(InstanceDescriptor))
				return true;

			return base.CanConvertTo(context, destinationType);
		}
		/// <summary>
		/// 지정된 값 개체를 지정된 형식으로 변환합니다.
		/// </summary>
		/// <param name="context"> 형식 컨텍스트를 제공하는 ITypeDescriptorContext </param>
		/// <param name="culture"> CultureInfo 개체 </param>
		/// <param name="value"> 변환할 Object </param>
		/// <param name="destinationType"> value 매개 변수를 변환할 Type </param>
		/// <returns> 변환된 값을 나타내는 Object </returns>
		public override object ConvertTo
			(ITypeDescriptorContext context, CultureInfo culture,
			object value, System.Type destinationType )
		{
			XGridComputedCell computedInfo;

			if (destinationType == typeof(InstanceDescriptor))
			{
				if (value is XGridComputedCell)
				{
					computedInfo = (XGridComputedCell)value;
					InstanceDescriptor id = new InstanceDescriptor(computedInfo.GetType().GetConstructor(Type.EmptyTypes), null, false);

					return id;
				}
			}

			return base.ConvertTo(context, culture, value, destinationType);
		}
	}
	#endregion

	#region XGridComputedCellCollection 
	// XGridComputedCell class 관리 Collection
	/// <summary>
	/// XGridComputedCell 객체를 관리하는 컬렉션입니다.
	/// </summary>
	[Serializable]
	public class XGridComputedCellCollection : CollectionBase
	{
		/// <summary>
		/// 해당 Index에 있는 XGridComputedCell 객체를 반환합니다.
		/// </summary>
		public XGridComputedCell this[int index]
		{
			get { return (XGridComputedCell)List[index]; }
		}
		/// <summary>
		/// 해당 key(Guid)를 가지는 XGridComputedCell를 반환합니다.
		/// </summary>
		public XGridComputedCell this[object key]
		{
			get
			{
				if (key == null) return null;
				if (!(key is Guid)) return null;
				foreach (XGridComputedCell item in this)
				{
					if (item.Identifier == (Guid) key) return item;
				}
				return null;
			}
		}

		/// <summary>
		/// 해당 그룹명, col을 가지는 AComputedCell를 반환합니다.
		/// </summary>
		public XGridComputedCell this[string groupName, int col]
		{
			get
			{
				foreach (XGridComputedCell item in this)
				{
					if ((item.GroupName == groupName) && (item.Col == col))
						return item;
				}
				return null;
			}
		}
		/// <summary>
		/// XGridComputedCell 객체를 컬렉션의 끝에 추가합니다.
		/// </summary>
		/// <param name="computedInfo"> XGridComputedCell 객체 </param>
		public void Add(XGridComputedCell computedInfo)
		{
			foreach (XGridComputedCell info in List)
			{
				if (info.Identifier == computedInfo.Identifier)
					throw(new Exception("이미 등록된 Computed 컬럼과 동일합니다."));
			}
			List.Add(computedInfo);
		}
		/// <summary>
		/// XGridComputedCell[] 를 컬렉션에 추가합니다.
		/// </summary>
		/// <param name="computedInfos"></param>
		public void AddRange(XGridComputedCell[] computedInfos)
		{
			List.Clear();
			foreach (XGridComputedCell info in computedInfos)
			{
				Add(info);
			}
		}
		/// <summary>
		/// 해당 Identifier를 가진 XGridComputedCell 객체를 컬렉션에서 제거합니다.
		/// </summary>
		/// <param name="identifier"> 개체의 식별자(Guid) </param>
		public void Remove(Guid identifier)
		{
			for (int index = 0; index < List.Count; index++)
			{
				XGridComputedCell item = (XGridComputedCell)List[index];
				if (item.Identifier == identifier)
					List.RemoveAt(index);
			}
		}
		/// <summary>
		/// 컬렉션에서 맨 처음 발견되는 XGridComputedCell객체를 제거합니다.
		/// </summary>
		/// <param name="computedInfo">제거할 XGridComputedCell객체</param>
		public void Remove(XGridComputedCell computedInfo)
		{
			List.Remove(computedInfo);
		}
		/// <summary>
		/// 요소가 컬렉션에 있는지 여부를 확인합니다.
		/// </summary>
		/// <param name="computedInfo">컬렉션에서 찾을 CellInfo입니다.</param>
		/// <returns>cellInfo가 컬렉션에 있으면 true이고, 그렇지 않으면 false입니다.</returns>
		public bool Contains(XGridComputedCell computedInfo)
		{
			return List.Contains(computedInfo);
		}
		/// <summary>
		/// 컬렉션에 속하는 XGridComputedCell을 XGridComputedCell[]에 복사하여 반환합니다.
		/// </summary>
		/// <returns> CellInfo[] </returns>
		public XGridComputedCell[] ToArray()
		{
			XGridComputedCell[] computedInfoArray = new XGridComputedCell[List.Count];
			for (int i = 0; i < List.Count; i++)
				computedInfoArray[i] = (XGridComputedCell) List[i];
			return computedInfoArray;
		}
	}
	#endregion

	#region XGridComputedCellDesigner
	/// <summary>
	/// CellInfoDesigner의 Designer입니다.
	/// </summary>
	internal class XGridComputedCellDesigner : System.ComponentModel.Design.ComponentDesigner, IDesignerFilter
	{
		private XGridCellCollection cellInfos = null;
		/// <summary>
		/// XGridComputedCell를 포함하는 ReportGrid의 XGridCellCollection을 가져오거나 설정합니다.
		/// </summary>
		[Browsable(false),
		DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public XGridCellCollection CellInfos
		{
			get { return cellInfos;}
			set { cellInfos = value;}
		}
		/// <summary>
		/// 구성 요소가 TypeDescriptor를 통해 노출하는 속성 집합을 조정합니다.
		/// (override) Designer에 XGridCellCollection 속성을 추가합니다.
		/// </summary>
		/// <param name="properties"> 구성 요소의 클래스에 대한 속성입니다 </param>
		protected override void PreFilterProperties(System.Collections.IDictionary properties)
		{
			base.PreFilterProperties(properties);

			properties.Add("CellInfos", TypeDescriptor.CreateProperty(typeof(XGridComputedCellDesigner), "CellInfos", typeof(XGridCellCollection), null));
		}
	}
	#endregion

}
