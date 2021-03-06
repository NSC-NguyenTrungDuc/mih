using System;
using System.Drawing; 
using System.Windows.Forms;
using System.Diagnostics;

namespace IHIS.Framework
{
	#region XMatrixItemBase
	/// <summary>
	/// XMatrixItem의 Base Class 에 대한 요약 설명입니다.
	/// </summary>
	public class XMatrixItemBase : IDisposable
	{
		#region Fields
		const int IMAGE_MARGIN = 2;
		private XMatrixControl matrix = null;
		private Rectangle rect = Rectangle.Empty;
		private Region region;
		private XMatrixItemState state = XMatrixItemState.Normal;
		private object tag = null;
		private string text = "";
		private ContentAlignment textAlign = ContentAlignment.MiddleLeft;
		private Font textFont = new Font("MS UI Gothic", 9.75f);
		private Color textColor = Color.Black;
		private Color backColor = XColor.XMatrixItemBackColor.Color;
		private int	  imageIndex = -1;
		private ContentAlignment imageAlign = ContentAlignment.MiddleLeft;
		#endregion

		#region Public Properties
		public virtual XMatrixItemType ItemType
		{
			get { return XMatrixItemType.Base;}
		}
		public string Text
		{
			get { return text;}
			set { text = value;}
		}
		public Font TextFont
		{
			get { return textFont;}
			set { textFont = value;}
		}
		public Color BackColor
		{
			get { return backColor;}
			set { backColor = value;}
		}
		public Color TextColor
		{
			get { return textColor;}
			set { textColor = value;}
		}
		public ContentAlignment TextAlign
		{
			get { return textAlign;}
			set { textAlign = value;}
		}
		public int ImageIndex
		{
			get { return imageIndex;}
			set { imageIndex = value;}
		}
		public ContentAlignment ImageAlign
		{
			get { return imageAlign;}
			set { imageAlign = value;}
		}
		public object Tag
		{
			get { return tag;}
			set { tag = value;}
		}
		public Rectangle Rect
		{
			get { return rect;}
			set
			{
				rect = value;
				//Region Set
				this.region = new Region(rect);
			}
		}
		#endregion

		#region Internal Properties
		internal XMatrixControl Matrix
		{
			get { return matrix;}
			set { matrix = value;}
		}
		internal XMatrixItemState State
		{
			get { return state;}
			set { state = value;}
		}
		#endregion

		#region 생성자
		public XMatrixItemBase()
		{
		}
		#endregion

		#region Dispose
		public void Dispose()
		{
			//Region Dispose
			region.Dispose();
		}
		#endregion

		#region Methods
		public Image GetImage()
		{
			if (this.imageIndex < 0) return null;

			// Check that an ImageList exists and that index is valid
			if (matrix.ImageList != null)
			{
				if ((imageIndex>=0) && (imageIndex <matrix.ImageList.Images.Count))
				{
					return matrix.ImageList.Images[imageIndex]; 
				}
				else return null;
			}
			else return null;
		}
//		internal void Draw(Graphics g)
//		{
//			//그리기  영역 밖이면 새로 그리지 않음
//			if (!g.IsVisible(this.rect)) return;
//
//			//Draw 순서
//			//1.현재 상태에 따라 BackColor Draw 
//			//2.Image가 있으면 Image Draw 
//			//3.Text가 있으면 Text Draw (Text가 MultiLine이 아닌경우 ImageAlign이 Left이면 Image Size고려하여 Draw, 아니면 그대로 Draw)
//			//4.선택된 상태이면 선택색깔 적용
//			Image  drawImage = null;
//			//Size는 MARGIN 적용하여 SET
//			Rectangle imageRect = new Rectangle(rect.X + IMAGE_MARGIN,rect.Y + IMAGE_MARGIN,rect.Width - IMAGE_MARGIN*2 ,rect.Height - IMAGE_MARGIN*2);
//			using (Brush bgBrush = new SolidBrush(this.backColor))
//				g.FillRectangle(bgBrush, this.rect);
//			
//			drawImage = GetImage();
//			//Image Draw
//			if (drawImage != null)
//			{
//				PointF pointImage = DrawHelper.GetObjAlignment(this.ImageAlign,imageRect.Left, imageRect.Top, imageRect.Width, imageRect.Height, drawImage.Width, drawImage.Height);
//				RectangleF iRectF = imageRect;
//				iRectF.Intersect(new RectangleF(pointImage, drawImage.PhysicalDimension));
//				imageRect = Rectangle.Truncate(iRectF);
//			}
//			if (this.text.TrimEnd() != "")
//			{
//				bool multiLine = (this.text.IndexOf("\n") >= 0 ? true : false);
//				StringFormat textFormat = XMatrixUtils.GetStringAlignment(this.textAlign);
//				textFormat.Trimming = StringTrimming.EllipsisCharacter;  //Text가 길면 ...표시
//				Rectangle textRect = this.rect;
//				if (!multiLine && (drawImage != null) && DrawHelper.IsLeft(this.imageAlign))
//				{
//					textRect.X += drawImage.Width;
//					textRect.Width = Math.Max(0, textRect.Width - drawImage.Width);
//				}
//				using (Brush txtBr = new SolidBrush(this.textColor))
//					g.DrawString(this.text.TrimEnd(), this.textFont, txtBr, textRect, textFormat);
//			}
//			//SELECT상태일때 반영
//			if (state == XMatrixItemState.Selected)
//			{
//				using (Brush selBrush = new SolidBrush(Color.FromArgb(125, XColor.XCalendarSelectedDateBackColor.Color)))  
//					g.FillRectangle(selBrush, this.rect); 
//			}
//		}
		//Line을 고려하여 약간 작게 그림
		internal void Draw(Graphics g)
		{
			//그리기  영역 밖이면 새로 그리지 않음
			if (!g.IsVisible(this.rect)) return;

			//Draw 순서
			//1.현재 상태에 따라 BackColor Draw 
			//2.Image가 있으면 Image Draw 
			//3.Text가 있으면 Text Draw (Text가 MultiLine이 아닌경우 ImageAlign이 Left이면 Image Size고려하여 Draw, 아니면 그대로 Draw)
			//4.선택된 상태이면 선택색깔 적용
			Image  drawImage = null;
			Rectangle drawRect = new Rectangle(rect.X + 1, rect.Y + 1, rect.Width - 1, rect.Height -1);
			//Size는 MARGIN 적용하여 SET
			Rectangle imageRect = new Rectangle(drawRect.X + IMAGE_MARGIN,drawRect.Y + IMAGE_MARGIN,drawRect.Width - IMAGE_MARGIN*2 ,drawRect.Height - IMAGE_MARGIN*2);
			using (Brush bgBrush = new SolidBrush(this.backColor))
				g.FillRectangle(bgBrush, drawRect);
			
			drawImage = GetImage();
			//Image Draw
			if (drawImage != null)
			{
				PointF pointImage = DrawHelper.GetObjAlignment(this.ImageAlign,imageRect.Left, imageRect.Top, imageRect.Width, imageRect.Height, drawImage.Width, drawImage.Height);
				RectangleF iRectF = imageRect;
				iRectF.Intersect(new RectangleF(pointImage, drawImage.PhysicalDimension));
				imageRect = Rectangle.Truncate(iRectF);
				g.DrawImageUnscaled(drawImage, imageRect);
			}
			if (this.text.TrimEnd() != "")
			{
				bool multiLine = (this.text.IndexOf("\n") >= 0 ? true : false);
				StringFormat textFormat = XMatrixUtils.GetStringAlignment(this.textAlign);
				textFormat.Trimming = StringTrimming.EllipsisCharacter;  //Text가 길면 ...표시
				Rectangle textRect = drawRect;
				if (!multiLine && (drawImage != null) && DrawHelper.IsLeft(this.imageAlign))
				{
					textRect.X += drawImage.Width;
					textRect.Width = Math.Max(0, textRect.Width - drawImage.Width);
				}
				using (Brush txtBr = new SolidBrush(this.textColor))
					g.DrawString(this.text.TrimEnd(), this.textFont, txtBr, textRect, textFormat);
			}
			//SELECT상태일때 반영
			if (state == XMatrixItemState.Selected)
			{
				using (Brush selBrush = new SolidBrush(Color.FromArgb(125, XColor.XCalendarSelectedDateBackColor.Color)))  
					g.FillRectangle(selBrush, drawRect); 
				//Border Draw
				ControlPaint.DrawBorder(g, drawRect, XColor.XCalendarSelectedDateBorderColor.Color, ButtonBorderStyle.Solid);
			}
		}
		internal bool HitTest(Point p)
		{
			if (region.IsVisible(p))
				return true;
			else
				return false;
		}
		//XMatrixPrintDocument에서 Call
		internal void Draw(Graphics g, Rectangle regionRect)
		{
			//Draw 순서
			//1.현재 상태에 따라 BackColor Draw 
			//2.Image가 있으면 Image Draw 
			//3.Text가 있으면 Text Draw (Text가 MultiLine이 아닌경우 ImageAlign이 Left이면 Image Size고려하여 Draw, 아니면 그대로 Draw)
			//4.선택된 상태이면 선택색깔 적용
			Image  drawImage = null;
			Rectangle drawRect = new Rectangle(regionRect.X + 1, regionRect.Y + 1, regionRect.Width - 2, regionRect.Height -2);
			//Size는 MARGIN 적용하여 SET
			Rectangle imageRect = new Rectangle(drawRect.X + IMAGE_MARGIN,drawRect.Y + IMAGE_MARGIN,drawRect.Width - IMAGE_MARGIN*2 ,drawRect.Height - IMAGE_MARGIN*2);
			using (Brush bgBrush = new SolidBrush(this.backColor))
				g.FillRectangle(bgBrush, drawRect);
			
			drawImage = GetImage();
			//Image Draw
			if (drawImage != null)
			{
				PointF pointImage = DrawHelper.GetObjAlignment(this.ImageAlign,imageRect.Left, imageRect.Top, imageRect.Width, imageRect.Height, drawImage.Width, drawImage.Height);
				RectangleF iRectF = imageRect;
				iRectF.Intersect(new RectangleF(pointImage, drawImage.PhysicalDimension));
				imageRect = Rectangle.Truncate(iRectF);
				g.DrawImageUnscaled(drawImage, imageRect);
			}
			if (this.text.TrimEnd() != "")
			{
				bool multiLine = (this.text.IndexOf("\n") >= 0 ? true : false);
				StringFormat textFormat = XMatrixUtils.GetStringAlignment(this.textAlign);
				textFormat.Trimming = StringTrimming.EllipsisCharacter;  //Text가 길면 ...표시
				Rectangle textRect = drawRect;
				if (!multiLine && (drawImage != null) && DrawHelper.IsLeft(this.imageAlign))
				{
					textRect.X += drawImage.Width;
					textRect.Width = Math.Max(0, textRect.Width - drawImage.Width);
				}
				using (Brush txtBr = new SolidBrush(this.textColor))
					g.DrawString(this.text.TrimEnd(), this.textFont, txtBr, textRect, textFormat);
			}
		}
		#endregion
	}
	#endregion

	#region XMatrixItem
	/// <summary>
	/// XMatrixItem에 대한 요약 설명입니다.
	/// </summary>
	public class XMatrixItem : XMatrixItemBase
	{
		#region Fields
		private int row = 0;  //Item이 속하는 Row
		private string colKey = "";  //Item이 속하는 XColMatrixItem의 Key
		#endregion

		#region Public Properties
		public override XMatrixItemType ItemType
		{
			get { return XMatrixItemType.Content;}
		}
		#endregion

		#region Internal Properties
		public int Row
		{
			get { return row;}
			set { row = Math.Max(0, value);}
		}
		public string ColKey
		{
			get { return colKey;}
			set { colKey = value;}
		}
		#endregion

		#region 생성자
		public XMatrixItem(int row, string colKey, string text)
			:this(row, colKey, text, -1)
		{
		}
		public XMatrixItem(int row, string colKey, string text, int imageIndex)
		{
			this.Text = text;
			this.Row = row;
			this.colKey = colKey;
			this.ImageIndex = imageIndex;
		}
		#endregion
	}
	#endregion

	#region XColMatrixItem
	public class XColMatrixItem : XMatrixItemBase
	{
		#region 속성
		private XColMatrixItemCollection childs = null;
		private string key = "";
		private XColMatrixItem parentItem = null;  //Item이 속하는 XColMatrixItem
		private int width = XMatrixUtils.DefaultItemWidth;  //Item의 Width
		public override XMatrixItemType ItemType
		{
			get { return XMatrixItemType.ColHeader;}
		}
		public XColMatrixItemCollection Childs
		{
			get { return childs;}
			set { childs = value;}
		}
		public int Width
		{
			get { return width;}
			set { width = Math.Max(10, value); }
		}
		internal string Key
		{
			get { return key;}
			set { key = value;}
		}
		internal XColMatrixItem ParentItem
		{
			get { return parentItem;}
			set { parentItem = value;}
		}
		#endregion

		#region 생성자
		public XColMatrixItem(string key, string text)
			: this(key, text, XMatrixUtils.DefaultItemWidth, -1) {}
		public XColMatrixItem(string key, string text, int width)
			: this(key, text, width, -1) {}
		public XColMatrixItem(string key, string text, int width, int imageIndex)
		{
			this.Key = key;
			this.Text = text;
			this.Width = width;
			this.ImageIndex = imageIndex;
			this.TextAlign = ContentAlignment.MiddleCenter;  //Header이므로 Middle Center Set
			this.BackColor = XColor.XMatrixColHeaderBackColor.Color;
		}
		#endregion
	}
	#endregion

	#region XRowMatrixItem
	public class XRowMatrixItem : XMatrixItemBase
	{
		#region 속성
		private int height = XMatrixUtils.DefaultItemHeight;
		private int colLevel = 0;  //해당 Row가 몇번째 Level의 ColKey를 가져야 하는지 정의한다.
		public override XMatrixItemType ItemType
		{
			get { return XMatrixItemType.RowHeader;}
		}
		public int Height
		{
			get { return height;}
			set { height = Math.Max(0, value);}
		}
		public int ColLevel
		{
			get { return colLevel;}
			set { colLevel = Math.Max(0,value);}
		}
		#endregion

		#region 생성자
		public XRowMatrixItem(string text, int colLevel)
			: this(text, 0, XMatrixUtils.DefaultItemHeight) {}
		public XRowMatrixItem(string text, int colLevel, int height)
		{
			this.Text = text;
			this.ColLevel = colLevel;
			this.Height = height;
			this.TextAlign = ContentAlignment.MiddleCenter;  //Header이므로 Middle Center Set
			this.BackColor = XColor.XMatrixRowHeaderBackColor.Color;
		}
		#endregion
	}
	#endregion
}
