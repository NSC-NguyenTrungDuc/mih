using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Reflection;

namespace IHIS.Framework
{
	/// <summary>
	/// XListView에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxBitmap(typeof(System.Windows.Forms.ListView))]
	public class XListView : System.Windows.Forms.ListView
	{
		#region HeaderControl class
		internal class HeaderControl : NativeWindow
		{
			XListView parent;
			bool mouseDown;
			internal HeaderControl(XListView m)
			{
				parent = m;
				//Get the header control handle
				IntPtr header = User32.SendMessage(parent.Handle, (0x1000+31), IntPtr.Zero, IntPtr.Zero);
				this.AssignHandle(header);				
			}

			#region Overriden WndProc

			protected override void WndProc(ref Message m)
			{
				switch(m.Msg)
				{
					case (int) Win32.Msgs.WM_PAINT:
						//Detail 시 Paint
						if(parent.View == View.Details)
						{
							Win32.RECT update = new Win32.RECT();
							if(User32.GetUpdateRect(m.HWnd,ref update, false)==0)
								break;
							//Fill the paintstruct
							Win32.PAINTSTRUCT ps = new Win32.PAINTSTRUCT();
							IntPtr hdc = User32.BeginPaint(m.HWnd, ref ps);
							//Create graphics object from the hdc
							Graphics g = Graphics.FromHdc(hdc);
							//Get the non-item rectangle
							int left = 0;
							Win32.RECT itemRect = new Win32.RECT();
							for(int i=0; i<parent.Columns.Count; i++)
							{								
								//HDM_GETITEMRECT
								User32.SendMessage(m.HWnd, 0x1200+7, i, ref itemRect);
								left += itemRect.right-itemRect.left;								
							}
							parent.headerHeight = itemRect.bottom-itemRect.top;
							if(left >= ps.rcPaint.left)
								left = ps.rcPaint.left;

							Rectangle r = new Rectangle(left, ps.rcPaint.top, 
								ps.rcPaint.right-left, ps.rcPaint.bottom-ps.rcPaint.top);

							g.FillRectangle(new SolidBrush(SystemColors.Control),r);
							//HeaderBorder Draw
							parent.DrawHeaderBorder(g, r, itemRect.bottom - itemRect.top);
							//Now we have to check if we have owner-draw columns and fill
							//the DRAWITEMSTRUCT appropriately
							for (int i = 0 ; i < parent.Columns.Count ; i++)
							{
								Win32.DRAWITEMSTRUCT dis = new Win32.DRAWITEMSTRUCT();
								dis.ctrlType = 100;//ODT_HEADER
								dis.hwnd = m.HWnd;
								dis.hdc = hdc;
								dis.itemAction = 0x0001;//ODA_DRAWENTIRE
								dis.itemID = i;
								//Must find if some item is pressed
								Win32.HDHITTESTINFO hi = new Win32.HDHITTESTINFO();
								hi.pt.X = parent.PointToClient(MousePosition).X;
								hi.pt.Y = parent.PointToClient(MousePosition).Y;
								int hotItem = User32.SendMessage(m.HWnd, 0x1200+6, 0, ref hi);
								//If clicked on a divider - we don't have hot item
								if(hi.flags == 0x0004 || hotItem != i)
									hotItem = -1;
								if(hotItem != -1 && mouseDown)
									dis.itemState = 0x0001;//ODS_SELECTED
								else
									dis.itemState = 0x0020;
								//HDM_GETITEMRECT
								User32.SendMessage(m.HWnd, 0x1200+7, i, ref itemRect);
								dis.rcItem = itemRect;
								//Send message WM_DRAWITEM
								User32.SendMessage(parent.Handle,(int) Win32.Msgs.WM_DRAWITEM,0,ref dis);
							}
							User32.EndPaint(m.HWnd, ref ps);
							
						}
						else
							base.WndProc(ref m);						
						break;
					case (int) Win32.Msgs.WM_LBUTTONDOWN://WM_LBUTTONDOWN
						mouseDown = true;
						base.WndProc(ref m);
						break;
					case (int) Win32.Msgs.WM_LBUTTONUP://WM_LBUTTONUP
						mouseDown = false;
						base.WndProc(ref m);
						break;
					default:
						base.WndProc(ref m);
						break;
				}
			}

			#endregion
		}

		#endregion		

		#region Fields
		private XColumnHeaderCollection columns = null;
		private ImageList headerImageList = null;
		private int headerHeight = 0;
		private HeaderControl headerCont = null;
		private XColor xBackColor = XColor.XListViewBackColor;
		private XColor xForeColor = XColor.NormalForeColor;
		#endregion

		#region Base Property 재정의
		[DefaultValue(typeof(XColor),"XListViewBackColor"),
		Description("배경색을 지정합니다.")]
		public new XColor BackColor
		{
			get { return xBackColor;}
			set 
			{
				xBackColor = value;
				base.BackColor = value.Color;
			}
		}
		[DefaultValue(typeof(XColor),"NormalForeColor"),
		Description("텍스트색을 지정합니다.")]
		public new XColor ForeColor
		{
			get { return xForeColor;}
			set 
			{
				xForeColor = value;
				base.ForeColor = value.Color;
			}
		}
		[Category("헤더정보")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Description("컨트롤에 나타나는 모든 열 머리글의 컬렉션을 가져옵니다.")]
		public new XColumnHeaderCollection Columns
		{
			get { return columns;}
		}
		// 재정의 (SET 기능 없음: Default Value만 사용)
		[Browsable(false)]
		public new bool Scrollable
		{
			get { return base.Scrollable;}
			set { base.Scrollable = value;}
		}
		[Browsable(true), DefaultValue(typeof(Font), "MS UI Gothic, 9.75pt")]
		public override Font Font
		{
			get	{ return base.Font;	}
			set	{ base.Font = value;}
		}
		#endregion

		#region Properies
		[Category("헤더정보")]
		[DefaultValue(null)]
		[Description("헤더의 ImageList를 가져오거나 설정합니다.")]
		public ImageList HeaderImageList
		{
			get { return headerImageList;}
			set { headerImageList = value;}
		}
		#endregion

		#region 생성자
		public XListView()
		{
			//Default 색 지정
			this.BackColor = XColor.XListViewBackColor;
			this.ForeColor = XColor.NormalForeColor;
			columns = new XColumnHeaderCollection(this);
			columns.CollectionChanged += new EventHandler(OnCollectionChanged);
			// 2005/05/09 신종석 폰트 수정
			//this.Font = new Font("MS UI Gothic", 9.75f);

            // MED-14286
            if (NetInfo.Language == LangMode.Jr)
            {
                this.Font = new Font("MS UI Gothic", 9.75f);
            }
            else
            {
                this.Font = Service.COMMON_FONT;
            }
		}
		#endregion

		#region OnCollectionChanged
		private void OnCollectionChanged(object sender, EventArgs e)
		{
			this.Scrollable = false;
			this.Scrollable = true;
			// 다시 갱신
			Invalidate(true);
		}
		#endregion

		#region Override Method
		protected override void OnHandleCreated(EventArgs e)
		{
			//Create a new HeaderControl object
			headerCont = new HeaderControl(this);
			if(headerCont.Handle != IntPtr.Zero)
			{
//				if(this.headerImageList != null)//If we have a valid header handle and a valid ImageList for it
//					//send a message HDM_SETIMAGELIST
//					User32.SendMessage(headerCont.Handle,0x1200+8,IntPtr.Zero,headerImageList.Handle);
				//Insert all the columns in Columns collection
				//if((this.Columns.Count > 0) && (this.View == View.Details))
				if(this.Columns.Count > 0)
					InsertColumns();				
			}
			base.OnHandleCreated(e);
		}
		#endregion

		#region OnParentBackColorChanged
		protected override void OnParentBackColorChanged(EventArgs e)
		{
			//ColorStyle 적용 (자세한 설명은 XTrackBar::OnParentBackColorChanged 참조)
			base.BackColor = this.xBackColor.Color;
			base.ForeColor = this.xForeColor.Color;
			base.OnParentBackColorChanged(e);
		}
		#endregion

		#region WndProc
		protected override void WndProc(ref Message m)
		{
			Win32.NMHEADER nm;
			switch(m.Msg)
			{
				case (int) Win32.Msgs.WM_NOTIFY:
					base.WndProc(ref m);
					Win32.NMHDR nmhdr = (Win32.NMHDR)m.GetLParam(typeof(Win32.NMHDR));
					switch(nmhdr.code)
					{
						case (0-300-20)://HDN_ITEMCHANGING
							nm=(Win32.NMHEADER)m.GetLParam(typeof(Win32.NMHEADER));
							//Adjust the column width
							Win32.RECT rect = new Win32.RECT();
							//HDM_GETITEMRECT
							User32.SendMessage(headerCont.Handle, 0x1200+7, nm.iItem, ref rect);
							//Get the item height which is actually header's height
							this.headerHeight = rect.bottom-rect.top;
							this.Columns[nm.iItem].Width = rect.right - rect.left;
							break;
					}
					break;
				case (int) Win32.Msgs.WM_DRAWITEM://WM_DRAWITEM
					//Get the DRAWITEMSTRUCT from the LParam of the message
					Win32.DRAWITEMSTRUCT dis = (Win32.DRAWITEMSTRUCT)Marshal.PtrToStructure(
						m.LParam,typeof(Win32.DRAWITEMSTRUCT));
					//Check if this message comes from the header
					if(dis.ctrlType == 100)//ODT_HEADER - it do comes from the header
					{
						//Get the graphics from the hdc field of the DRAWITEMSTRUCT
						Graphics g = Graphics.FromHdc(dis.hdc);
						//Create a rectangle from the RECT struct
						Rectangle r = new Rectangle(dis.rcItem.left, dis.rcItem.top, dis.rcItem.right -
							dis.rcItem.left, dis.rcItem.bottom - dis.rcItem.top);

						//Create new DrawItemState in its default state					
						DrawItemState d = DrawItemState.Default;
						//Set the correct state for drawing
						if(dis.itemState == 0x0001)
							d = DrawItemState.Selected;
						//Create the DrawItemEventArgs object
						DrawItemEventArgs e = new DrawItemEventArgs(g,this.Font,r,dis.itemID,d);

						//Header Draw
						DrawHeader(this.Columns[dis.itemID],e);
						//Release the graphics object					
						g.Dispose();					
					}
					break;
				case (int) Win32.Msgs.WM_DESTROY://WM_DESTROY
					//Release the handle associated with the header control window
					headerCont.ReleaseHandle();
					base.WndProc(ref m);
					break;
				default:
					base.WndProc(ref m);
					break;
			}
		}
		#endregion

		#region Private Methods(InsertColumns, DrawHeader, DrawHeaderBorder
		private void DrawHeaderBorder(Graphics g, Rectangle bounds, int headerHeight)
		{
			if(bounds.Left == 0)
				g.DrawLine(SystemPens.ControlLightLight,bounds.Left,bounds.Bottom,bounds.Left,bounds.Top);
			if(bounds.Top == 0)
				g.DrawLine(SystemPens.ControlLightLight,bounds.Left,bounds.Top,bounds.Right,bounds.Top);
			if(bounds.Bottom == headerHeight)
				g.DrawLine(SystemPens.ControlDark,bounds.Left,bounds.Bottom-1,bounds.Right,bounds.Bottom-1);
		}
		private void DrawHeader(object sender, DrawItemEventArgs e)
		{
			XColumnHeader m = sender as XColumnHeader;			
			Graphics g = e.Graphics;
			Image image = null;
			
			Rectangle r = e.Bounds;
			int offSet = 3;
			
			StringFormat sFormat = new StringFormat();
			sFormat.FormatFlags = StringFormatFlags.NoWrap;
			sFormat.Trimming = StringTrimming.EllipsisCharacter;
			sFormat.LineAlignment = StringAlignment.Center;
			//Alignment 조정
			if (m.HeaderTextAlign == HorizontalAlignment.Left)
				sFormat.Alignment = StringAlignment.Near;
			else if (m.HeaderTextAlign == HorizontalAlignment.Center)
				sFormat.Alignment = StringAlignment.Center;
			else
				sFormat.Alignment = StringAlignment.Far;

			//Adjust the proper text bounds and get the correct image(if any)
			if(m.ImageIndex != -1 && this.headerImageList != null)
			{
				if(m.ImageIndex + 1 > headerImageList.Images.Count)
					image = null;
				else
					image = headerImageList.Images[m.ImageIndex];
			}

			RectangleF drawRectF = new RectangleF(r.Left+offSet, r.Top, r.Width - offSet*2, r.Height);
			Rectangle imageRect = Rectangle.Empty;
			//Image 영역 GET
			if (image != null)
			{
				PointF pointImage = GetObjAlignment(m.ImageAlign, (int) drawRectF.Left, (int) drawRectF.Top, (int) drawRectF.Width, (int) drawRectF.Height, image.Width, image.Height);
				RectangleF iRectF = drawRectF;
				iRectF.Intersect(new RectangleF(pointImage, image.PhysicalDimension));
				imageRect = Rectangle.Truncate(iRectF);
			}
			//Text영역 GET
			RectangleF textRectF = drawRectF;
			if (image != null)
			{
				if (m.ImageAlign == HorizontalAlignment.Left)
				{
					textRectF.X += image.Width;
					textRectF.Width -= image.Width;
				}
				else if (m.ImageAlign == HorizontalAlignment.Right)
				{
					textRectF.Width -= image.Width;
				}
			}
			
			//Fill Rect
			g.FillRectangle(new SolidBrush(m.HeaderBackColor.Color),r);

			Brush textBrush = new SolidBrush(m.HeaderForeColor.Color);
	
			//Border 그리기
			ControlPaint.DrawBorder(g, r,Color.WhiteSmoke,1,ButtonBorderStyle.Solid,
				Color.WhiteSmoke,1,ButtonBorderStyle.Solid,
				SystemColors.ControlLight,2,ButtonBorderStyle.Outset,
				SystemColors.ControlLight,2,ButtonBorderStyle.Outset);

			//This occurs when column is pressed
			if((e.State & DrawItemState.Selected) != 0)
			{
				//Press Line Draw
				g.DrawLine(SystemPens.ControlDark,r.Left+1, r.Bottom-2, r.Left+1, r.Top+1);
				g.DrawLine(SystemPens.ControlDark,r.Left+1, r.Top+1, r.Right-2, r.Top+1);
				g.DrawLine(SystemPens.ControlLightLight,r.Right-2, r.Top+1, r.Right-2, r.Bottom-2);
				g.DrawLine(SystemPens.ControlLightLight,r.Right-2, r.Bottom-2, r.Left+1, r.Bottom-2);

				if(image != null)
				{
					imageRect.Offset(1,1);
					g.DrawImage(image,imageRect);
					imageRect.Offset(-1,-1);
				}
				
				if (m.Text != "")
				{
					textRectF.Offset(1,1);
					g.DrawString(m.Text,m.HeaderFont,textBrush,textRectF, sFormat);
					textRectF.Offset(-1,-1);
				}
			}
				//Default state
			else
			{
				if(image != null)
					g.DrawImage(image,imageRect);
				
				if (m.Text != "")
				{
					g.DrawString(m.Text,m.HeaderFont,textBrush,textRectF,sFormat);
				}
			}

		}
		private PointF GetObjAlignment(HorizontalAlignment align, int clientLeft, int clientTop, int clientWidth, int clientHeight, float objWidth, float objHeight)
		{
			//default X left
			PointF pointf = new PointF((float)clientLeft,(float)clientTop);

			//Y 는 가운데
			pointf.Y = (float)clientTop + ((float)clientHeight)/2.0F - objHeight/2.0F;
			
			//X는 Align에 따라
			if ( align == HorizontalAlignment.Center)
				pointf.X = (float)clientLeft + ((float)clientWidth)/2.0F - objWidth/2.0F;
			else if (align == HorizontalAlignment.Right)
				pointf.X = (float)clientLeft + (float)clientWidth - objWidth;
			return pointf;
		}
		private void InsertColumns()
		{
			int counter = 0;
			foreach(XColumnHeader m in this.columns)
			{
				Win32.LVCOLUMN lvc = new Win32.LVCOLUMN();
				lvc.mask = 0x0001|0x0008|0x0002|0x0004;//LVCF_FMT|LVCF_SUBITEM|LVCF_WIDTH|LVCF_TEXT
				lvc.cx = m.Width;
				lvc.subItem = counter;
				lvc.text = m.Text;
				switch(m.TextAlign)
				{
					case HorizontalAlignment.Left:
						lvc.fmt = 0x0000;
						break;
					case HorizontalAlignment.Center:
						lvc.fmt = 0x0002;
						break;
					case HorizontalAlignment.Right:
						lvc.fmt = 0x0001;
						break;
				}
				if(this.headerImageList != null && m.ImageIndex != -1)
				{
					lvc.mask |= 0x0010;//LVCF_IMAGE
					lvc.iImage = m.ImageIndex;
					lvc.fmt |= 0x0800;//LVCFMT_IMAGE
				}
				//Send message LVN_INSERTCOLUMN
				User32.SendMessage(this.Handle,0x1000+97,counter,ref lvc);
				//Check if column is set to owner-draw
				//If so - send message HDM_SETITEM with HDF_OWNERDRAW flag set
				Win32.HDITEM hdi = new Win32.HDITEM();
				hdi.mask = (int)Win32.HDI.HDI_FORMAT;
				hdi.fmt = (int) Win32.HDF.HDF_OWNERDRAW;
				User32.SendMessage(headerCont.Handle,0x1200+12,counter,ref hdi);
				counter++;
			}
		}
		#endregion

	}
}
