using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Diagnostics;
using System.Globalization;
using System.ComponentModel.Design.Serialization;

namespace IHIS.Framework
{
	#region XGridHeader
	/// <summary>
	/// XGridHeader(추가 Header정보) class에 대한 요약설명입니다.
	/// </summary>
	[Serializable,
	ToolboxItem(false),
	DesignTimeVisible(false)]
	public class XGridHeader : Component
	{
		private Guid identifier = Guid.NewGuid();
		private string headerText = "";
		private int row = 0;
		private int col = 0;
		private int colSpan = 1;
		private int rowSpan = 1;
		private ImageList	imageList = null;
		private int			headerImageIndex = -1;
		private Image headerImage = null;
		private ContentAlignment headerImageAlign = ContentAlignment.MiddleLeft;
		private bool  headerImageStretch = false;
		private ContentAlignment headerTextAlign = ContentAlignment.MiddleCenter;  // Header Text Alignment
		private int headerWidth = 80;
		private Font headerFont = new Font("MS UI Gothic",9.75f);
		private XCellDrawMode headerDrawMode = XCellDrawMode.Vertical;
		private XColor headerBackColor = XColor.XGridColHeaderBackColor;
		private XColor headerGradientStart = XColor.XGridColHeaderGradientStartColor;
		private XColor headerGradientEnd = XColor.XGridColHeaderGradientEndColor;
		private XColor headerForeColor = XColor.XGridColHeaderForeColor;
		private XColor selectedBackColor = XColor.XGridSelectedCellBackColor;
		private XColor selectedForeColor = XColor.XGridSelectedCellForeColor;
		/// <summary>
		/// XGridHeader 생성자
		/// </summary>
		public XGridHeader()
		{
		}
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
		/// Header의 Text를 가져오거나 설정합니다.
		/// </summary>
		[Category("헤더모양"),
		MergableProperty(true),
		DefaultValue(""),
		Description("Header의 Text를 설정합니다.")]
        [Localizable(true)]
		public string HeaderText
		{
			get { return headerText; }
			set { headerText = value ;}
		}
		/// <summary>
		/// 컬럼 Header Text의 Alignment를 가져오거나 설정합니다.
		/// </summary>
		[Category("헤더모양"),
		DefaultValue(ContentAlignment.MiddleCenter),
		Description("컬럼 Header Text의 Alignment를 설정합니다.")]
		public ContentAlignment HeaderTextAlign
		{
			get { return headerTextAlign; }
			set { headerTextAlign = value ;}
		}
		/// <summary>
		/// Header의 Row위치를 가져오거나 설정합니다.
		/// </summary>
		[Browsable(false),
		DefaultValue(0)]
		public int Row
		{
			get { return row;}
			set { row = value;}
		}
		/// <summary>
		/// Header의 Col위치를 가져오거나 설정합니다.
		/// </summary>
		[Browsable(false),
		DefaultValue(0)]
		public int Col
		{
			get { return col;}
			set { col = value;}
		}
		/// <summary>
		/// Header의 RowSpan을 가져오거나 설정합니다.
		/// </summary>
		[Browsable(false),
		DefaultValue(1)]
		public int RowSpan
		{
			get { return rowSpan;}
			set { rowSpan = value;}
		}
		/// <summary>
		/// Header의 ColSpan을 가져오거나 설정합니다.
		/// </summary>
		[Browsable(false),
		DefaultValue(1)]
		public int ColSpan
		{
			get { return colSpan;}
			set { colSpan = value;}
		}
		/// <summary>
		/// 이미지를 표시할 이미지목록을 가져오거나 설정합니다.
		/// </summary>
		[Browsable(true), Category("헤더모양"),
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
						this.headerImageIndex = -1;
						this.HeaderImage = null;
					}
					else
					{
						try	{this.HeaderImage = imageList.Images[headerImageIndex];	}
						catch {this.HeaderImage = null;}
					}
				}
			}
		}
		[Browsable(true), Category("헤더모양"),
		DefaultValue(-1),
		MergableProperty(true),
		Description("이미지를 표시할 이미지목록의 인덱스를 설정합니다.")]
		[Editor(typeof(IHIS.Framework.ImageIndexesEditor), typeof(UITypeEditor))]
		[ImageList("ImageList")]
		public  int HeaderImageIndex
		{
			get { return headerImageIndex; }
			set
			{
				if (headerImageIndex != value)
				{
					headerImageIndex = value;
					if (headerImageIndex < 0)
						this.HeaderImage = null;
					else
					{
						try{ this.HeaderImage = imageList.Images[value];}
						catch{this.HeaderImage = null;	}
					}
				}
			}
		}
		/// <summary>
		/// Header의 Image를 가져오거나 설정합니다.
		/// </summary>
		[Category("헤더모양"),
		MergableProperty(true),
		DefaultValue(null),
		Description("Header의 Image를 설정합니다.")]
		public Image HeaderImage
		{
			get { return headerImage;}
			set { headerImage = value;}
		}
		/// <summary>
		/// Header의 Image의 Stretch여부를 가져오거나 설정합니다.
		/// </summary>
		[Category("헤더모양"),
		MergableProperty(true),
		DefaultValue(false),
		Description("Header의 Image의 Stretch여부를 설정합니다.")]
		public bool HeaderImageStretch
		{
			get { return headerImageStretch;}
			set { headerImageStretch = value;}
		}
		/// <summary>
		/// Header의 Image Alignment를 가져오거나 설정합니다.
		/// </summary>
		[Category("헤더모양"),
		MergableProperty(true),
		DefaultValue(ContentAlignment.MiddleLeft),
		Description("Header의 Image Align을 설정합니다.")]
		public ContentAlignment HeaderImageAlign
		{
			get { return headerImageAlign;}
			set { headerImageAlign = value;}
		}
		/// <summary>
		/// Header의 Width를 가져오거나 설정합니다.
		/// </summary>
		[Category("헤더모양"),
		MergableProperty(true),
		DefaultValue(80),
		Description("Header의 Width를 설정합니다.")]
		public int HeaderWidth
		{
			get { return headerWidth;}
			set 
			{ 
				// - 입력불가
				headerWidth = Math.Max(value,0);
			}
		}
		/// <summary>
		/// Header의 Font를 가져오거나 설정합니다.
		/// </summary>
		[Category("헤더모양"),
		MergableProperty(true),
		DefaultValue(typeof(Font), "MS UI Gothic, 9.75pt"),
		Description("Header의 Font를 설정합니다.")]
		public Font HeaderFont
		{
			get { return headerFont;}
			set { headerFont = value;}
		}
		/// <summary>
		/// Header의 그리기모드를 가져오거나 설정합니다.
		/// </summary>
		[Category("헤더모양"),
		MergableProperty(true),
		DefaultValue(XCellDrawMode.Vertical),
		Description("Header의 그리기모드를 설정합니다.")]
		public XCellDrawMode HeaderDrawMode
		{
			get { return headerDrawMode;}
			set { headerDrawMode = value;}
		}
		/// <summary>
		/// Header의 배경색을 가져오거나 설정합니다.(Flat형일때 적용됨)
		/// </summary>
		[Category("헤더모양"),
		DefaultValue(typeof(XColor), "XGridColHeaderBackColor"),
		Description("Header의 배경색을 설정합니다.(Flat형일때 적용됨)")]
		public XColor HeaderBackColor
		{
			get { return headerBackColor;}
			set { headerBackColor = value;}
		}
		/// <summary>
		/// Header의 Gradient 시작색을 가져오거나 설정합니다.(Gradient형일때 적용됨)
		/// </summary>
		[Category("헤더모양"),
		DefaultValue(typeof(XColor), "XGridColHeaderGradientStartColor"),
		Description("Header의 Gradient 시작색을 설정합니다.(Gradient형일때 적용됨)")]
		public XColor HeaderGradientStart
		{
			get { return headerGradientStart;}
			set { headerGradientStart = value;}
		}
		/// <summary>
		/// Header의 Gradient 종료색을 가져오거나 설정합니다.(Gradient형일때 적용됨)
		/// </summary>
		[Category("헤더모양"),
		DefaultValue(typeof(XColor), "XGridColHeaderGradientEndColor"),
		Description("Header의 Gradient 종료색을 설정합니다.(Gradient형일때 적용됨)")]
		public XColor HeaderGradientEnd
		{
			get { return headerGradientEnd;}
			set { headerGradientEnd = value;}
		}
		/// <summary>
		/// Header의 텍스트색을 가져오거나 설정합니다.
		/// </summary>
		[Category("헤더모양"),
		DefaultValue(typeof(XColor), "XGridColHeaderForeColor"),
		Description("Header의 텍스트색을 설정합니다.")]
		public XColor HeaderForeColor
		{
			get { return headerForeColor;}
			set { headerForeColor = value;}
		}
		/// <summary>
		/// Header가 선택될때 배경색을 가져오거나 설정합니다.
		/// </summary>
		[Category("헤더모양"),
		DefaultValue(typeof(XColor), "XGridSelectedCellBackColor"),
		Description("Header가 선택될때 배경색을 설정합니다.")]
		public XColor SelectedBackColor
		{
			get { return selectedBackColor;}
			set { selectedBackColor = value;}
		}
		/// <summary>
		/// Header가 선택될때 텍스트색을 가져오거나 설정합니다.
		/// </summary>
		[Category("헤더모양"),
		DefaultValue(typeof(XColor), "XGridSelectedCellForeColor"),
		Description("Header가 선택될때 텍스트색을 설정합니다.")]
		public XColor SelectedForeColor
		{
			get { return selectedForeColor;}
			set { selectedForeColor = value;}
		}
	}
	#endregion

	#region XGridHeader Type Converter
	/// <summary>
	/// XGridHeaderTypeConverter TypeConverter
	/// </summary>
	public class XGridHeaderTypeConverter : TypeConverter
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
			if (destinationType == typeof(InstanceDescriptor))
			{
				if (value is XGridHeader)
				{
					XGridHeader headerInfo = (XGridHeader)value;
					InstanceDescriptor id = new InstanceDescriptor(headerInfo.GetType().GetConstructor(Type.EmptyTypes),null,false);
					return id;
				}
			}

			return base.ConvertTo(context, culture, value, destinationType);
		}
	}
	#endregion

	#region XGridHeaderCollection 
	/// <summary>
	/// XGridHeader 관리 컬렉션입니다.
	/// </summary>
	[Serializable]
	public class XGridHeaderCollection : CollectionBase
	{
		/// <summary>
		/// 해당 Index에 있는 XGridHeader를 반환합니다.
		/// </summary>
		public XGridHeader this[int index]
		{
			get { return (XGridHeader)List[index]; }
		}
		/// <summary>
		/// 해당 key(Guid)를 가지는 XGridHeader를 반환합니다.
		/// </summary>
		public XGridHeader this[object key]
		{
			get
			{
				if (key == null) return null;
				if (!(key is Guid)) return null;
				foreach (XGridHeader item in this)
				{
					if (item.Identifier == (Guid) key) return item;
				}
				return null;
			}
		}
		/// <summary>
		/// 해당 row, col을 가지는 XGridHeader를 반환합니다.
		/// </summary>
		public XGridHeader this[int row, int col]
		{
			get
			{
				foreach (XGridHeader item in this)
				{
					if ((item.Row == row) && (item.Col == col))
						return item;
				}
				return null;
			}
		}
		/// <summary>
		/// XGridHeader 객체를 컬렉션의 끝에 추가합니다.
		/// </summary>
		/// <param name="headerInfo"> XGridHeader 객체 </param>
		public void Add(XGridHeader headerInfo)
		{
			foreach (XGridHeader info in List)
			{
				if (info.Identifier == headerInfo.Identifier)
					throw(new Exception("[XGridHeader]이미 등록된 Header와 동일합니다."));
			}
			List.Add(headerInfo);
		}
		/// <summary>
		/// XGridHeader[] 를 컬렉션에 추가합니다.
		/// </summary>
		/// <param name="headerInfos"> XGridHeader[] </param>
		public void AddRange(XGridHeader[] headerInfos)
		{
			List.Clear();
			foreach (XGridHeader info in headerInfos)
			{
				Add(info);
			}
		}
		/// <summary>
		/// 해당 text를 가진 XGridHeader 객체를 컬렉션에서 제거합니다.
		/// </summary>
		/// <param name="identifier"> 개체의 식별자(Guid) </param>
		public void Remove(Guid identifier)
		{
			for (int index = 0; index < List.Count; index++)
			{
				XGridHeader item = (XGridHeader)List[index];
				if (item.Identifier == identifier)
					List.RemoveAt(index);
			}
		}
		/// <summary>
		/// 컬렉션에서 맨 처음 발견되는 XGridHeader 객체를 제거합니다.
		/// </summary>
		/// <param name="info">제거할 CellInfo객체</param>
		public void Remove(XGridHeader info)
		{
			List.Remove(info);
		}
		/// <summary>
		/// 요소가 컬렉션에 있는지 여부를 확인합니다.
		/// </summary>
		/// <param name="info">컬렉션에서 찾을 XGridHeader입니다.</param>
		/// <returns>cellInfo가 컬렉션에 있으면 true이고, 그렇지 않으면 false입니다.</returns>
		public bool Contains(XGridHeader info)
		{
			return List.Contains(info);
		}
		/// <summary>
		/// XGridHeader의 row와 Matching되는 XGridHeader 객체를 반환합니다.
		/// </summary>
		/// <param name="col"> column Index </param>
		/// <returns> XGridHeader 객체 (없으면 null) </returns>
		public XGridHeader GetXGridHeaderByColIndex(int col)
		{
			foreach (XGridHeader info in this)
			{
				if ( info.Col == col)
					return info;
			}
			return null;
		}
	}
	#endregion

}
