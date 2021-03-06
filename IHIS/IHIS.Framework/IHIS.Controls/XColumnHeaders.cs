using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Globalization;

namespace IHIS.Framework
{
	#region XColumnHeader
	/// <summary>
	/// XColumnHeaders에 대한 요약 설명입니다.
	/// </summary>
	public class XColumnHeader : System.Windows.Forms.ColumnHeader
	{
		#region Fields
		private Font headerFont = new Font("MS UI Gothic",9.75f);
		private HorizontalAlignment headerTextAlign = HorizontalAlignment.Left;
		private XColor headerBackColor = XColor.XListViewHeaderBackColor;
		private XColor headerForeColor = XColor.XListViewHeaderForeColor;
		private int imageIndex = -1;
		private HorizontalAlignment imageAlign = HorizontalAlignment.Left;
		private XListView parentListView = null;
		#endregion

		#region Base Property 재정의
		[Category("헤더모양")]
		public new string Text
		{
			get { return base.Text;}
			set { base.Text = value;}
		}
		#endregion

		#region Properties
		[Category("헤더모양")]
		[DefaultValue(typeof(Font), "MS UI Gothic, 9.75pt")]
		public Font HeaderFont
		{
			get { return headerFont;}
			set { headerFont = value;}
		}
		
		[Category("헤더모양")]
		[DefaultValue(HorizontalAlignment.Left)]
		public HorizontalAlignment HeaderTextAlign
		{
			get { return headerTextAlign;}
			set 
			{ 
				headerTextAlign = value;
				if (base.ListView != null)
					base.ListView.Invalidate(true);
			}
		}
		[Category("헤더모양")]
		[DefaultValue(typeof(XColor), "XListViewHeaderBackColor")]
		public XColor HeaderBackColor
		{
			get { return headerBackColor;}
			set { headerBackColor = value;}
		}
		
		[Category("헤더모양")]
		[DefaultValue(typeof(XColor), "XListViewHeaderForeColor")]
		public XColor HeaderForeColor
		{
			get { return headerForeColor;}
			set { headerForeColor = value;}
		}
		[Category("헤더모양")]
		[Editor(typeof(XColumnHeaderImageIndexEditor), typeof(UITypeEditor))]
		[TypeConverter(typeof(XColumnHeaderImageIndexConverter))]
		[DefaultValue(-1)]
		public new int ImageIndex
		{
			get { return imageIndex;}
			set { imageIndex = value;}
		}
		
		[Category("헤더모양")]
		[DefaultValue(HorizontalAlignment.Left)]
		public HorizontalAlignment ImageAlign
		{
			get { return imageAlign;}
			set { imageAlign = value;}
		}
		// 내부에서 쓰는 Property
		internal XListView ParentListView
		{
			get { return parentListView;}
			set { parentListView = value;}
		}
		#endregion
		
		#region 생성자
		public XColumnHeader()
		{
		}
		#endregion
	}
	#endregion

	#region XColumnHeaderCollection
	/// <summary>
	/// MyColumnHeaderCollection
	/// </summary>
	[Serializable]
	public class  XColumnHeaderCollection : System.Collections.CollectionBase
	{
		private XListView parent = null;
		internal event EventHandler CollectionChanged;
		internal XListView Parent
		{
			get { return parent;}
		}
		/// <summary>
		///  XColumnHeaderCollection 생성자
		/// </summary>
		public  XColumnHeaderCollection(XListView parent)
		{
			this.parent = parent;
		}
		
		/// <summary>
		/// 지정한 Index에 있는 XColumnHeader을 가져옵니다.
		/// </summary>
		public XColumnHeader this[int index]
		{
			get 
			{ 
				if (index > Count - 1 || index < 0)
					return null;
				else
					return (XColumnHeader)List[index];
			}
			
		}
		
		/// <summary>
		/// XColumnHeader 을 Collection의 끝에 추가합니다.
		/// </summary>
		/// <param name="item"> XColumnHeader class</param>
		public void Add(XColumnHeader item)
		{
			List.Add(item);
		}
		/// <summary>
		/// XColumnHeader[]를 Collection에 추가합니다.
		/// </summary>
		/// <param name="items"> XColumnHeader class Array</param>
		public void AddRange(XColumnHeader[] items)
		{
			List.Clear();
			foreach (XColumnHeader Item in items)
			{
				Add(Item);
			}
		}
		/// <summary>
		/// 해당 Index의 XColumnHeader을 제거합니다.
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
		/// 요소가 컬렉션에 있는지 여부를 확인합니다.
		/// </summary>
		/// <param name="item">컬렉션에서 찾을 XColumnHeader입니다.</param>
		/// <returns>XColumnHeader가 컬렉션에 있으면 true이고, 그렇지 않으면 false입니다.</returns>
		public bool Contains(XColumnHeader item)
		{
			return List.Contains(item);
		}

		protected override void OnRemoveComplete(int index,object value)
		{
			if (value is XColumnHeader)
			{
				((XColumnHeader) value).ParentListView = null;
			}
			OnCollectionChanged();
		}
		
		protected override void OnInsertComplete(int index,object value)
		{
			if (value is XColumnHeader)
			{
				((XColumnHeader) value).ParentListView = this.parent;
			}
			OnCollectionChanged();
		}

		protected override void OnClear()
		{
			foreach (object Item in List)
			{
				((XColumnHeader) Item).ParentListView = null;
			}
			OnCollectionChanged();
		}
		protected virtual void OnCollectionChanged()
		{
			if (CollectionChanged != null)
				CollectionChanged(this, EventArgs.Empty);
		}
	}
	#endregion

	#region XColumnHeaderImageIndexConverter
	/// <summary>
	/// XColumnHeaderImageIndexConverter에 대한 요약 설명입니다.
	/// </summary>
	internal class XColumnHeaderImageIndexConverter : ImageIndexConverter
	{
		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
		{
			if (value is string)	
			{
				if (((string) value) != "(none)" && ((string) value) != "")
				{
					try
					{
						return Int32.Parse(((string) value));
					}
					catch
					{
						return -1;
					}
				}
				else
					return -1;
			}
			else
				return null;
		}

		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
		{
			if (value is Int32)	
			{
				if (((int) value) >= 0)
					return ((int) value).ToString();
				else
					return "(none)";
			}
			else
				return null;
		}

		public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
		{
			ArrayList resultList = new ArrayList();
			ImageList imageList = null;
			if (context.Instance != null && context.Instance is XColumnHeader) 
			{
				// Step 1 - Determine who has the imagelist. 
				if (((XColumnHeader)context.Instance).ParentListView != null)
					imageList = ((XColumnHeader)context.Instance).ParentListView.HeaderImageList;
				// Step 2 - Construct list of index for the images in the ImageList if any.
				if (imageList != null)
				{
					for (int Idx = 0; Idx < imageList.Images.Count; Idx++)
					{
						resultList.Add(Idx);
					}
					resultList.Add(-1);
				}
			}
			StandardValuesCollection Result = new StandardValuesCollection(resultList);
			return Result;
		}

		public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
		{
			if (context.Instance != null)
				return true;
			else
				return false;
		}
	}
	#endregion

	#region XColumnHeaderImageIndexEditor
	internal class XColumnHeaderImageIndexEditor : UITypeEditor
	{
		public override bool GetPaintValueSupported(
			ITypeDescriptorContext context) 
		{
			return true;
		}

		public override void PaintValue(PaintValueEventArgs pe) 
		{
			// choose the right bitmap based on the value
			Image image = null;
			int imageIdx = (int) pe.Value;

			ArrayList resultList = new ArrayList();
			ImageList imageList = null;
			if (imageIdx >= 0 && pe.Context.Instance != null && pe.Context.Instance is XColumnHeader) 
			{
				// Step 1 - Determine who has the imagelist. 
				if (((XColumnHeader)pe.Context.Instance).ParentListView != null)
					imageList = ((XColumnHeader)pe.Context.Instance).ParentListView.HeaderImageList;
				// Step 2 - Construct list of index for the images in the ImageList if any.
				if (imageList != null && imageList.Images.Count > imageIdx)
				{
					image = imageList.Images[imageIdx];
				}
			}
			if (imageIdx < 0 || image == null) 
			{	// value -1 : Draws a cross to indicate no image. 
				pe.Graphics.DrawLine(Pens.Black, pe.Bounds.X + 1, pe.Bounds.Y + 1, 
					pe.Bounds.Right - 1, pe.Bounds.Bottom - 1);
				pe.Graphics.DrawLine(Pens.Black, pe.Bounds.Right - 1, pe.Bounds.Y + 1, 
					pe.Bounds.X + 1, pe.Bounds.Bottom - 1);
			}
			else 
			{
				pe.Graphics.DrawImage(image,pe.Bounds);
			}
		}
	}
	#endregion
}
