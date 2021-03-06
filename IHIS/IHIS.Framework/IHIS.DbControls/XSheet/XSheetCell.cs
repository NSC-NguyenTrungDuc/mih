using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Drawing.Drawing2D;
using System.Data;
using System.Windows.Forms;
using System.Diagnostics;
using System.Globalization;
using System.ComponentModel.Design.Serialization;

namespace IHIS.Framework
{
	/// <summary>
	/// Cell class에 대한 요약설명입니다.
	/// </summary>
	public class XSheetCell
	{
		#region Fields With Property
		private string oldToolTipText = string.Empty;
		private int row = -1;
		private int col = -1;
		private int rowSpan = 1;
		private int colSpan = 1;
		private XSheet sheet;
		private string cellText = "";
		private bool focused = false;
		private bool select = false;
		private ContentAlignment textAlignment = ContentAlignment.MiddleCenter;
		private Color focusBorderColor = Color.Gray;
		private int focusBorderWidth = 2;
		private Color normalBorderColor = Color.LightGray;
		private int normalBorderWidth = 1;
		private string toolTipText = string.Empty;
		private Image image = null;
		private ContentAlignment imageAlignment = ContentAlignment.MiddleLeft;
		private bool  imageStretch = false;
		private object tag = null;
		private XSheetCellDrawMode drawMode = XSheetCellDrawMode.Flat;
		private Color backColor = Color.White;
		private Color gradientStart = Color.WhiteSmoke;
		private Color gradientEnd = Color.White;
		private Color foreColor = Color.Black;
		private Color selectedBackColor = Color.FromArgb(182,202,234);
		private Color selectedForeColor = Color.Black;
		private Font font = new Font("MS UI Gothic",9.75f);
		private bool drawBorder = true; //Border를 그릴지 여부
		#endregion

		#region Properties
		/// <summary>
		/// Cell의 Row 값을 가져오거나 설정합니다.
		/// </summary>
		public int Row
		{
			get {return row;}
			set {row = value;}
		}
		/// <summary>
		/// Cell의 Col 값을 가져오거나 설정합니다.
		/// </summary>
		public int Col
		{
			get {return col;}
			set {col = value;}
		}
		/// <summary>
		/// Cell의 ColSpan 값을 가져오거나 설정합니다.
		/// </summary>
		public int ColSpan
		{
			get{return colSpan;}
			set
			{
				if (rowSpan != value)
				{
					colSpan = value;
					InvokeInvalidate();
				}
			}
		}
		/// <summary>
		/// Cell의 RowSpan 값을 가져오거나 설정합니다.
		/// </summary>
		public int RowSpan
		{
			get{return rowSpan;}
			set
			{
				if (rowSpan != value)
				{
					rowSpan = value;
					InvokeInvalidate();
				}
			}
		}
		/// <summary>
		/// Cell의 Text 값을 가져오거나 설정합니다.
		/// </summary>
		public string CellText
		{
			get{return cellText;}
			set
			{
				if (cellText != value)
				{
					cellText = value;
					InvokeInvalidate();
				}
			}
		}
		/// <summary>
		/// Cell Font을 가져오거나 설정합니다.
		/// </summary>
		[Browsable(true),
		 DefaultValue(typeof(Font), "MS UI Gothic, 9.75pt")]
		public virtual Font Font
		{
			get { return font;}
			set 
			{
				if (font != value)
				{
					font = value;
					InvokeInvalidate();
				}
			}
		}
		/// <summary>
		/// Cell 그리기모드를 가져오거나 설정합니다.
		/// </summary>
		public virtual XSheetCellDrawMode DrawMode
		{
			get { return drawMode;}
			set 
			{
				if (drawMode != value)
				{
					drawMode = value;
					InvokeInvalidate();
				}
			}
		}
		/// <summary>
		/// Cell 배경색을 가져오거나 설정합니다.
		/// </summary>
		public virtual Color BackColor
		{
			get { return backColor;}
			set 
			{
				if (backColor != value)
				{
					backColor = value;
					InvokeInvalidate();
				}
			}
		}
		/// <summary>
		/// 배경을 Gradient로 그릴때 시작색을 가져오거나 설정합니다.
		/// </summary>
		public virtual Color GradientStartColor
		{
			get { return gradientStart;}
			set 
			{
				if (gradientStart != value)
				{
					gradientStart = value;
					InvokeInvalidate();
				}
			}
		}
		/// <summary>
		/// 배경을 Gradient로 그릴때 종료색을 가져오거나 설정합니다.
		/// </summary>
		public virtual Color GradientEndColor
		{
			get { return gradientEnd;}
			set 
			{
				if (gradientEnd != value)
				{
					gradientEnd = value;
					InvokeInvalidate();
				}
			}
		}
		/// <summary>
		/// Cell 텍스트색을 가져오거나 설정합니다.
		/// </summary>
		public virtual Color ForeColor
		{
			get { return foreColor;}
			set 
			{
				if (foreColor != value)
				{
					foreColor = value;
					InvokeInvalidate();
				}
			}
		}
		/// <summary>
		/// 선택된 Cell 배경색을 가져오거나 설정합니다.
		/// </summary>
		public virtual Color SelectedBackColor
		{
			get { return selectedBackColor;}
			set 
			{
				if (selectedBackColor != value)
				{
					selectedBackColor = value;
					InvokeInvalidate();
				}
			}
		}
		/// <summary>
		/// 선택된 Cell의 Text색을 가져오거나 설정합니다.
		/// </summary>
		public virtual Color SelectedForeColor
		{
			get { return selectedForeColor;}
			set 
			{
				if (selectedForeColor != value)
				{
					selectedForeColor = value;
					InvokeInvalidate();
				}
			}
		}
		/// <summary>
		/// Focus가 있을때 테두리색을 가져오거나 설정합니다.
		/// </summary>
		public virtual Color FocusBorderColor
		{
			get { return this.focusBorderColor;}
			set 
			{
				if (focusBorderColor != value)
				{
					focusBorderColor = value;
					InvokeInvalidate();
				}
			}
		}
		/// <summary>
		/// Focus가 없을때 테두리색을 가져오거나 설정합니다.
		/// </summary>
		public virtual Color NormalBorderColor
		{
			get { return this.normalBorderColor;}
			set 
			{
				if (normalBorderColor != value)
				{
					normalBorderColor = value;
					InvokeInvalidate();
				}
			}
		}
		/// <summary>
		/// Cell가 Attach된 Sheet를 가져옵니다.
		/// </summary>
		public virtual XSheet Sheet
		{
			get{return sheet;}
		}
		/// <summary>
		/// Cell의 Absolute Rectangle을 가져옵니다.
		/// </summary>
		[Browsable(false)]
		public Rectangle AbsoluteRectangle
		{
			get
			{
				if (this.sheet != null)
					return this.sheet.GetCellAbsoluteRectangle(this.row,this.col,this.rowSpan,this.colSpan);
				else
					return new Rectangle(0,0,0,0);
			}
		}
		/// <summary>
		/// Cell의 Display 영역에 기초한 Display Rectangle을 가져옵니다.
		/// </summary>
		[Browsable(false)]
		public Rectangle DisplayRectangle
		{
			get
			{
				if (this.sheet != null)
					return this.sheet.GetCellDisplayRectangle(this.row,this.col,this.rowSpan,this.colSpan);
				else
					return new Rectangle(0,0,0,0);
			}
		}
		/// <summary>
		/// Cell의 Focus를 가지고 있는지 여부를 가져옵니다.
		/// </summary>
		public bool Focused
		{
			get{return focused;}
		}
		/// <summary>
		/// Cell의 Selected 상태인지 여부를 가져오거나 설정합니다.
		/// </summary>
		public bool Select
		{
			get{return select;}
			set
			{
				if (select != value)
				{
					select = value;
					OnSelectionChange(EventArgs.Empty);
					InvokeInvalidate();
				}
			}
		}
		/// <summary>
		/// Cell의 Text 정렬방식(ContentAlignment)을 가져오거나 설정합니다.
		/// </summary>
		public ContentAlignment TextAlignment
		{
			get{	return textAlignment;}
			set
			{
				if (textAlignment != value)
				{
					textAlignment = value;
					InvokeInvalidate();
				}
			}
		}
		/// <summary>
		/// Cell의 ToolTipText를 가져오거나 설정합니다.
		/// </summary>
		public virtual string ToolTipText
		{
			get { return toolTipText;}
			set { toolTipText = value;}
		}
		/// <summary>
		/// Cell의 Image를 가져오거나 설정합니다.
		/// </summary>
		[DefaultValue(null)]
		public Image Image
		{
			get { return image;}
			set 
			{ 
				if (image != value)
				{
					image = value;
					//ImageFormat이 BMP이면 TransParent 지정
					if (image != null)
					{
						try
						{
							Bitmap bmp = (Bitmap) image;
							bmp.MakeTransparent();
							image = bmp;
						}
						catch{}
					}
					InvokeInvalidate();
				}
			}
		}
		/// <summary>
		/// Cell Image의 Alignmemt를 가져오거나 설정합니다.
		/// </summary>
		[DefaultValue(ContentAlignment.MiddleLeft)]
		public ContentAlignment ImageAlignment
		{
			get { return imageAlignment;}
			set 
			{ 
				if (imageAlignment != value)
				{
					imageAlignment = value;
					InvokeInvalidate();
				}
			}
		}
		/// <summary>
		/// Cell Image의 Alignmemt를 가져오거나 설정합니다.
		/// </summary>
		[DefaultValue(false)]
		public bool ImageStretch
		{
			get { return imageStretch;}
			set 
			{ 
				if (imageStretch != value)
				{
					imageStretch = value;
					InvokeInvalidate();
				}
			}
		}
		/// <summary>
		/// Cell의 기타필요정보를 관리하는 object입니다.
		/// </summary>
		public object Tag
		{
			get { return tag;}
			set { tag = value;}
		}
		#endregion

		#region 생성자
		/// <summary>
		/// Cell 생성자
		/// </summary>
		public XSheetCell()
		{
		}
		public XSheetCell(string cellText)
		{
			this.cellText = cellText;
		}
		#endregion

		#region Internal Methods
		/// <summary>
		/// Sheet에 Cell을 Binding합니다.
		/// </summary>
		/// <param name="sheet"> XSheet </param>
		/// <param name="row"> Row의 값 </param>
		/// <param name="col"> Col의 값 </param>
		internal void BindToSheet(XSheet sheet, int row, int col)
		{
			this.sheet = sheet;
			this.row = row;
			this.col = col;
		}
		/// <summary>
		/// Sheet에서 Cell을 UnBind합니다.
		/// </summary>
		internal void UnBindToSheet()
		{
			this.sheet = null;
			this.row = -1;
			this.col = -1;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Cell에 Focus를 설정합니다.
		/// </summary>
		/// <returns> Focus 상태가 되면 true, 아니면 false </returns>
		public virtual bool Focus()
		{
			return this.Focus(true);
		}

		/// <summary>
		/// Cell에 Focus를 설정합니다.
		/// </summary>
		/// <param name="checkSheetFocus"> Sheet에 Focus가 있을 경우에만 Focus를 줄지여부 </param>
		/// <returns> Focus 상태가 되면 true, 아니면 false </returns>
		public virtual bool Focus(bool checkSheetFocus)
		{
			// checkSheetFocus 이면 Sheet가 Focus를 가지지 않으면 Cell도 Focus 가질수 없음
			if ((this.sheet != null) && checkSheetFocus)
				if (!this.sheet.ContainsFocus)	return false;

			if ((Focused==false) && (this.sheet != null))
			{
				this.focused = true;
				// 다시 한번 더 Check
				if (this.sheet != null && this.sheet.FocusCell != null)
				{
					if (this.sheet.FocusCell.LeaveFocus())
					{
						OnFocusChange(EventArgs.Empty);
						InvokeInvalidate();
					}
					else
						this.focused = false;
				}
				else
				{
					OnFocusChange(EventArgs.Empty);
					InvokeInvalidate();
				}
			}
			return this.focused;
		}
		
		/// <summary>
		/// Cell의 Focus를 제거합니다.
		/// </summary>
		/// <returns>성공시 true, 실패시 false </returns>
		public virtual bool LeaveFocus()
		{
			if (Focused == true)
			{
				//Focus해제
				this.focused = false;
				InvokeInvalidate();
			}
			return !this.focused;
		}
		/// <summary>
		/// Cell이 display영역에 있는지 여부를 가져옵니다.
		/// </summary>
		/// <param name="displayRectangle"> Rectangle </param>
		/// <returns> Display영역에 있으면 True, 아니면 False </returns>
		public virtual bool IsInDisplayRegion(Rectangle displayRectangle)
		{
			Rectangle l_rc = this.DisplayRectangle;
			return l_rc.IntersectsWith(displayRectangle);
		}
		/// <summary>
		/// Cell이 Absolute 영역에 있는지 여부를 가져옵니다.
		/// </summary>
		/// <param name="absoluteRectangle"> Rectangle </param>
		/// <returns> Absolute 영역에 있으면 true, 아니면 false </returns>
		public virtual bool IsInAbsoluteRegion(Rectangle absoluteRectangle)
		{
			Rectangle l_rc = AbsoluteRectangle;
			return l_rc.IntersectsWith(absoluteRectangle);
		}
		#endregion

		#region Public Event
		/// <summary>
		/// 마우스 단추를 클릭하면 발생하는 Event입니다.
		/// </summary>
		public event MouseEventHandler MouseDown;
		/// <summary>
		/// 마우스 단추를 눌렀다 놓으면 발생하는 Event입니다.
		/// </summary>
		public event MouseEventHandler MouseUp;
		/// <summary>
		/// 마우스 포인터를 컨트롤 위로 이동하면 발생하는 Event입니다.
		/// </summary>
		public event MouseEventHandler MouseMove;
		/// <summary>
		/// 마우스 포인터가 컨트롤에 들어가면 발생하는 Event입니다.
		/// </summary>
		public event EventHandler MouseEnter;
		/// <summary>
		/// 마우스 포인터가 컨트롤을 벗어나면 발생하는 Event입니다.
		/// </summary>
		public event EventHandler MouseLeave;
		/// <summary>
		/// 컨트롤에 포커스가 있을 때 키를 누르면 발생하는 Event입니다.
		/// </summary>
		public event KeyPressEventHandler KeyPress;
		/// <summary>
		/// 컨트롤에 포커스가 있을 때 키를 누르면 발생하는 Event입니다.
		/// </summary>
		public event KeyEventHandler KeyDown;
		/// <summary>
		/// 컨트롤에 포커스가 있을 때 키를 눌렀다 놓으면 발생하는 Event입니다.
		/// </summary>
		public event KeyEventHandler KeyUp;
		/// <summary>
		/// 컨트롤을 클릭하면 발생하는 Event입니다.
		/// </summary>
		public event EventHandler Click;
		/// <summary>
		/// 컨트롤을 더블클릭하면 발생하는 Event입니다.
		/// </summary>
		public event EventHandler DoubleClick;
		/// <summary>
		/// Select상태가 변경되면 발생하는 Event입니다.
		/// </summary>
		public event EventHandler SelectionChange;
		/// <summary>
		/// Focus상태가 변경되면 발생하는 Event입니다.
		/// </summary>
		public event EventHandler FocusChange;
		/// <summary>
		/// 컨트롤 표시를 다시 그릴 필요가 있으면 발생하는 Event입니다.
		/// </summary>
		public event InvalidateEventHandler Invalidated;
		#endregion

		#region Event Raise Method
		/// <summary>
		/// Cell을 다시 그립니다.(InValidated Event를 발생시킵니다.)
		/// </summary>
		internal virtual void InvokeInvalidate()
		{
			if (this.sheet != null)
				OnInvalidated(new InvalidateEventArgs(DisplayRectangle));
		}

		/// <summary>
		/// Cell을 그립니다.
		/// </summary>
		/// <param name="e"> PaintEventArgs </param>
		/// <param name="absoluteRectangle"> Absolute Rectangle </param>
		/// <param name="chekIfIsRegion"> 절대영역 Check 여부 </param>
		internal void InvokePaint(PaintEventArgs e, Rectangle absoluteRectangle, bool chekIfIsRegion)
		{
			if (this.sheet==null)
				return;
			
			// FixedRows, FixedCols영역은 절대영역에 관계없이 그리고, NonFixedRows, NonFixedCols영역은
			// 절대영역밖이면 그리지 않음
			if (chekIfIsRegion == false || IsInAbsoluteRegion(absoluteRectangle))
			{
				// DisplayRect의 유효성 검사 (Width > 0, Height > 0)
				Rectangle l_rc = DisplayRectangle;
				Rectangle aRect = AbsoluteRectangle;
				if ((l_rc.Width <= 0) || (l_rc.Height <= 0))	return;

				Graphics g = e.Graphics;

				Region l_OldClip = g.Clip;
				// 그리기 영역은 Cell의 Display Rectangle 영역
				g.Clip = new Region(l_rc);
				
				int l_left = l_rc.X;
				int l_top = l_rc.Y;
				int l_width = l_rc.Width;
				int l_height = l_rc.Height;
								
				//HScroll에 의해 DispRect과 AbsolutRect이 다를때 Bottom이 FixedRowsHeight보다 작으면 그리지 않아도 됨
				if ((l_rc.Bottom != aRect.Bottom) && (l_rc.Bottom < Sheet.FixedRowsHeight))
					return;

			
				Color	bColor = this.backColor;
				Color	fColor = this.foreColor;
				Font	textFont = this.font;
				Color	gStartColor = this.gradientStart;
				Color	gEndColor	= this.gradientEnd;
				XSheetCellDrawMode cellDrawMode = this.drawMode;
				Image	cellImage = this.image;
				
				//normal cell (Not Selected Cell OR Focused Cell)
				if (!Select || Focused)
				{
					Brush br;
					if ((cellDrawMode == XSheetCellDrawMode.Flat) ||(cellDrawMode == XSheetCellDrawMode.Raised3D)||(cellDrawMode == XSheetCellDrawMode.Sunken3D))
					{
						br = new SolidBrush(bColor);

						g.FillRectangle(br,l_rc);
						//3D Style은 Border 그리기
						if (cellDrawMode == XSheetCellDrawMode.Raised3D)
							ControlPaint.DrawBorder(g, l_rc,Color.WhiteSmoke,1,ButtonBorderStyle.Solid,
								Color.WhiteSmoke,1,ButtonBorderStyle.Solid,
								Color.Silver,2,ButtonBorderStyle.Outset,
								Color.Silver,2,ButtonBorderStyle.Outset);
						else if (cellDrawMode == XSheetCellDrawMode.Sunken3D)
							ControlPaint.DrawBorder(g, l_rc,Color.Silver,2,ButtonBorderStyle.Inset,
								Color.Silver,2,ButtonBorderStyle.Inset,
								Color.WhiteSmoke,1,ButtonBorderStyle.Solid,
								Color.WhiteSmoke,1,ButtonBorderStyle.Solid);
						br.Dispose();

					}
					else  //Gradient
					{
						br = new LinearGradientBrush(l_rc, gStartColor, gEndColor, 
							(LinearGradientMode) Enum.Parse(typeof(LinearGradientMode), cellDrawMode.ToString())); 
						g.FillRectangle(br,l_rc);
						br.Dispose();
					}
						
					

					//Focus시 FocusBorder Draw
					if (Focused)
					{
						using (Pen p = new Pen(this.focusBorderColor, this.focusBorderWidth))
						{
							XSheetUtility.DrawRectangleWithExternBound(g,p,l_rc);
						}
					}
				}
				else if (Select) //Selected
				{
					using (SolidBrush br = new SolidBrush(this.selectedBackColor))
					{
						g.FillRectangle(br,l_rc);
					}
				}
				
				//<미확정> Border Draw시에 Draw하는데 Rectangle을 그리지 않고, Line을 그린다.
				//Row = 0 이면 Left를 그리고, Col = 0 이면 Top을 그리고, Bottom, Right는 둘다 그린다.
				//모양을 보고 그리기 다시 정의하자.
				float margin = this.normalBorderWidth;
				if (this.drawBorder)
				{
					using (Pen l_CurrentPen = new Pen(this.normalBorderColor, margin))
					{
						/* <미확정> Top, Left는 그리지 말자
						if (this.row == 0)  //Top Draw
							g.DrawLine(l_CurrentPen, l_left, l_top, l_left + l_width - margin, l_top);
						if (this.col == 0) //Left Draw
							g.DrawLine(l_CurrentPen, l_left, l_top, l_left, l_top + l_height);
						*/
						//Right
						g.DrawLine(l_CurrentPen, l_left + l_width - margin, l_top, l_left + l_width - margin, l_top + l_height);
						//Bottom
						g.DrawLine(l_CurrentPen, l_left + margin, l_top + l_height - margin, l_left + l_width - margin, l_top + l_height - margin);
					}
				}
				
				RectangleF drawRect = l_rc;
				drawRect.X += margin;
				drawRect.Y += margin;
				//Rect Valid Check
				drawRect.Width  = Math.Max(0, drawRect.Width - margin*2);
				drawRect.Height = Math.Max(0, drawRect.Height - margin*2);
				if ((drawRect.Width <= 0) || (drawRect.Height <= 0))
				{
					g.Clip = l_OldClip;
					return;
				}

				//Image Draw
				if (cellImage != null)
				{
					// 전체영역에 Image Draw
					if (imageStretch)
					{
						g.DrawImage(cellImage, drawRect);
					}
						// Alignment에 따라 Image Size에 따라 SET
					else
					{
						PointF pointImage = DrawHelper.GetObjAlignment(imageAlignment,(int) drawRect.Left, (int) drawRect.Top, (int) drawRect.Width, (int) drawRect.Height, cellImage.Width, cellImage.Height);
						RectangleF imageRect = drawRect;
						imageRect.Intersect(new RectangleF(pointImage, cellImage.PhysicalDimension));
						//Truncate the Rectangle for appreximation problem
						g.DrawImage(cellImage,Rectangle.Truncate(imageRect));
					}
				}
				string dispText = this.cellText;
				//Text Draw
				if ((dispText.Length > 0) && (l_width > 2) && (l_height > 2))
				{
					RectangleF textRect = drawRect;
					//Align Text To Image (Image가 있으면 Image Size에 맞추어 Text Size 조정)
					if ((cellImage != null) && !imageStretch)
					{
						//imageAlignment가 Left이면 X이동 Width 감소, Right이면 Width감소
						if (XSheetUtility.IsLeft(imageAlignment))
						{
							textRect.X += cellImage.Width;
							textRect.Width = Math.Max(0, textRect.Width - cellImage.Width);
						}
						else if (XSheetUtility.IsRight(imageAlignment))
						{
							textRect.Width = Math.Max(0, textRect.Width - cellImage.Width);
						}
					}

					//Rect Validation Check
					if ((textRect.Width <= 0) || (textRect.Height <= 0))
					{
						g.Clip = l_OldClip;
						return;
					}

					SizeF l_fontSize = DrawHelper.MeasureString(g, dispText, textFont, this.textAlignment);
					
					Color l_FontColor = fColor;
					//Draw string (Selected상태이면 SelectedText Color)
					if (Select && !Focused) 
					{
						l_FontColor = this.selectedForeColor;
					}
					
					using (SolidBrush br = new SolidBrush(l_FontColor))
					{
						g.DrawString(dispText,
							textFont,
							br,
							DrawHelper.GetObjAlignment(this.textAlignment,(int) textRect.Left,(int) textRect.Top, (int) textRect.Width, (int) textRect.Height,l_fontSize.Width,l_fontSize.Height));
					}
				}
				//Region 반환
				g.Clip = l_OldClip;
			}
		}
		/// <summary>
		/// MouseDown Event를 발생시킵니다.
		/// </summary>
		/// <param name="e"> MouseEventArgs </param>
		internal void InvokeMouseDown(MouseEventArgs e)
		{
			if (MouseDown != null)
				MouseDown(this,e);
		}
		/// <summary>
		/// MouseUp Event를 발생시킵니다.
		/// </summary>
		/// <param name="e"> MouseEventArgs </param>
		internal void InvokeMouseUp(MouseEventArgs e)
		{
			if (MouseUp != null)
				MouseUp(this,e);
		}
		/// <summary>
		/// MouseMove Event를 발생시킵니다.
		/// </summary>
		/// <param name="e"> MouseEventArgs </param>
		internal void InvokeMouseMove(MouseEventArgs e)
		{
			if (MouseMove != null)
				MouseMove(this,e);
		}
		/// <summary>
		/// MouseEnter Event를 발생시킵니다.
		/// </summary>
		/// <param name="e"> EventArgs </param>
		internal void InvokeMouseEnter(EventArgs e)
		{
			// ToolTipText SET
			ApplyToolTipText();

			if (MouseEnter!=null)
				MouseEnter(this,e);
		}
		/// <summary>
		/// MouseLeave Event를 발생시킵니다.
		/// </summary>
		/// <param name="e"> EventArgs </param>
		internal void InvokeMouseLeave(EventArgs e)
		{
			// ResetToolTipText
			ResetToolTipText();
			
			if (MouseLeave!=null)
				MouseLeave(this,e);
		}
		/// <summary>
		/// KeyUp Event를 발생시킵니다.
		/// </summary>
		/// <param name="e"> KeyEventArgs </param>
		internal void InvokeKeyUp ( KeyEventArgs e)
		{
			if (KeyUp!=null)
				KeyUp(this,e);
		}
		/// <summary>
		/// KeyPress Event를 발생시킵니다.
		/// </summary>
		/// <param name="e"> KeyPressEventArgs </param>
		internal void InvokeKeyPress ( KeyPressEventArgs e)
		{
			if (KeyPress!=null)
				KeyPress(this,e);
		}
		/// <summary>
		/// KeyDown Event를 발생시킵니다.
		/// </summary>
		/// <param name="e"> KeyEventArgs </param>
		internal void InvokeKeyDown ( KeyEventArgs e)
		{
			if (KeyDown!=null)
				KeyDown(this,e);
		
		}
		/// <summary>
		/// DoubleClick Event를 발생시킵니다.
		/// </summary>
		internal void InvokeDoubleClick ()
		{
			if (DoubleClick!=null)
				DoubleClick(this,EventArgs.Empty);
		}
		/// <summary>
		/// Click Event를 발생시킵니다.
		/// </summary>
		internal void InvokeClick ()
		{
			if (Click!=null)
				Click(this,EventArgs.Empty);
		}
		#endregion
		
		#region Select, Focus, Invalidate Event Invoker
		/// <summary>
		/// SelectionChange Event를 발생시킵니다.
		/// </summary>
		/// <param name="e"> EventArgs </param>
		protected void OnSelectionChange(EventArgs e)
		{
			if (SelectionChange!=null)
				SelectionChange(this,e);
		}
		/// <summary>
		/// FocusChange Event를 발생시킵니다.
		/// </summary>
		/// <param name="e"> EventArgs </param>
		protected virtual void OnFocusChange(EventArgs e)
		{
			if (FocusChange != null)
				FocusChange(this,e);
		}
		/// <summary>
		/// Invalidated Event를 발생시킵니다.
		/// </summary>
		/// <param name="e"> InvalidateEventArgs </param>
		protected virtual void OnInvalidated(InvalidateEventArgs e)
		{
			if (Invalidated!= null)
				Invalidated(this,e);
		}
		#endregion

		#region ToolTipText 관련
		/// <summary>
		/// ToolTipText를 반영합니다.
		/// </summary>
		protected virtual void ApplyToolTipText()
		{
			// Cell에 Setting된 ToolTipText가 없으면 Value SET
			try
			{
				oldToolTipText = Sheet.SheetToolTipText;
				if (ToolTipText.Length > 0)
					Sheet.SheetToolTipText = ToolTipText;
				else
					Sheet.SheetToolTipText = this.CellText;
			}
			catch{}
		}
		/// <summary>
		/// ToolTipText를 Reset합니다.
		/// </summary>
		protected virtual void ResetToolTipText()
		{
			try
			{
				Sheet.SheetToolTipText = oldToolTipText;
				oldToolTipText = string.Empty;
			}
			catch{}
		}
		#endregion
	}
}