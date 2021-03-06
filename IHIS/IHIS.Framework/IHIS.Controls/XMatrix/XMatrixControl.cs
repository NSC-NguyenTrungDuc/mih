using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing.Printing;


namespace IHIS.Framework
{
	/// <summary>
	/// XMatrix에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	internal class XMatrixControl : System.Windows.Forms.Control
	{
		#region Fields
		private ImageList imageList = null;
		private XMatrixItemCollection items = null;
		private XColMatrixItemCollection colItems = null;
		private XRowMatrixItemCollection rowItems = null;
		private int rowHeaderWidth = 80;  //RowHeader의 너비
		private Rectangle colHeaderRect = Rectangle.Empty; //ColHeader의 영역
		private Rectangle rowHeaderRect = Rectangle.Empty; //RowHeader의 영역
		private Rectangle itemRect = Rectangle.Empty;  //Items의 영역
		private bool reDraw = true;  //그리기 여부
		private bool enableMultiSelection = true;
		private bool toggleSelection = false; //여러개의 선택을 Ctrl을 누르지 않고 선택가능하게 하는 Option
		private XMatrixItemCollection selectedItems = null;
		private Hashtable colKeyRectList = new Hashtable(); //ColKey별 Rect관리
		private Hashtable levelColKeyList = new Hashtable(); //Level별 ColKey 관리 List
		private ItemInfoCollection itemInfoList = new ItemInfoCollection(); //ItemInfo 정보 보관 List
		internal Hashtable ColMatrixItemList = new Hashtable();  //이 Control에 있는 전체 XColMatrixItem의 List
		private int maxColumnLevel = 0;  //최대 컬럼의 Level
		private Point mousePoint = Point.Empty;
		private MouseButtons mouseButton = MouseButtons.Left;
		private XMatrixItem hitItem = null;
		//Print 관련
		private XMatrixPrintDocument printDoc = null;
		private PageSettings pageSettings = new PageSettings();
		#endregion

		#region Properties
		public ImageList ImageList
		{
			get { return imageList;}
			set { imageList = value;}
		}
		public XColMatrixItemCollection ColItems
		{
			get { return colItems;}
		}
		public XRowMatrixItemCollection RowItems
		{
			get { return rowItems;}
		}
		public XMatrixItemCollection Items
		{
			get { return items;}
		}
		public int RowHeaderWidth
		{
			get { return rowHeaderWidth;}
			set { rowHeaderWidth = Math.Max(50, value);}
		}
		public bool ReDraw
		{
			get { return reDraw;}
			set 
			{ 
				if (reDraw != value)
				{
					reDraw = value;
					if (value) //Redraw시에 다시 그리기
						this.Invalidate(true);
				}
			}
		}
		public bool EnableMultiSelection
		{
			get { return enableMultiSelection;}
			set { enableMultiSelection = value;}
		}
		public bool ToggleSelection
		{
			get { return toggleSelection;}
			set { toggleSelection = value;}
		}
		public XMatrixItemCollection SelectedItems
		{
			get { return selectedItems;}
		}
		#endregion

		#region Event
		public event XMatrixItemClickEventHandler ItemClick;
		public event XMatrixItemClickEventHandler ItemDoubleClick;
		public event XMatrixItemDragDropEventHandler ItemDragDrop;
		#endregion
		
		#region 생성자
		public XMatrixControl()
		{
			this.SetStyle(ControlStyles.DoubleBuffer, true);
			this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			this.SetStyle(ControlStyles.UserPaint, true);
			this.SetStyle(ControlStyles.ResizeRedraw, true);
			this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);

			//Collection Set
			this.items = new XMatrixItemCollection(this);
			this.colItems = new XColMatrixItemCollection(this);
			this.rowItems = new XRowMatrixItemCollection(this);
			this.selectedItems = new XMatrixItemCollection(this);

			//PrintDocument,PageSetup SET
			this.printDoc = new XMatrixPrintDocument(this);

			//Page Setting Margin 기본값 SET (원 기본값은 100milleInch = 2.54cm , 39milleInch = 1cm)
			this.pageSettings.Margins = new Margins(39,39,39,39);

		}
		#endregion

		#region Dispose
		/// <summary> 
		/// 사용 중인 모든 리소스를 정리합니다.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
			}
			base.Dispose( disposing );
		}
		#endregion

		#region Setup (주어진 컬렉션으로 그림판 Setup)
		public void Setup()
		{
			Setup(false);
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="arrangeOnlyItemRegion"> Items 영역만 다시 배치할치(true), 전체를 배치할지(false) </param>
		public void Setup(bool arrangeOnlyItemRegion)  //Header영역 Setup여부 Argument로 전달필요함
		{
			/* 1.ColItems의 속성으로 열 구성 (컬럼의 너비는 상위컬럼의 너비에 종속된다. 하위컬럼의 마지막컬럼은 자신의 Width가 아닌 나머지 Width를 가진다.)
			 * 2.RowItem의 속성으로 행 구성
			 * 3.Items로 Text에 따른 RowItem의 Height 계산
			 * 
			 * <에러 조건, 아직 Check하지 못했음 >
			 * 1.ColItems의 각각의 Level이 다르면 에러
			 * 2.동일한 Row를 가지는 XMatrixItem은 같은 Level의 ColKey를 가져야 한다.
			 * 
			 * 
			 */
			if (!arrangeOnlyItemRegion)  //전체 재배치시만 Clear
			{
				colKeyRectList.Clear();
				levelColKeyList.Clear();
				ColMatrixItemList.Clear();
			}

			itemInfoList.Clear();

			int yPos = 0;
			XRowMatrixItem rowItem = null;
			//전체 재배치시만 다시 설정
			if (!arrangeOnlyItemRegion) 
			{
				for (int i = 0 ; i < rowItems.Count ; i++)
				{
					rowItem = rowItems[i];
					//Item의 Rect 설정
					rowItem.Rect = new Rectangle(0, yPos, this.rowHeaderWidth, rowItem.Height);
					yPos += rowItem.Height;

				}
			}
			int currXPos = this.rowHeaderWidth;
			XColMatrixItem colItem = null;
			//전체 재배치시만 다시 설정
			if (!arrangeOnlyItemRegion) 
			{
				for (int i = 0 ; i < colItems.Count ; i++)
				{
					colItem = colItems[i];
					SetColItemRegion(null, colItem, currXPos, 0, (i == colItems.Count - 1));
					currXPos += colItem.Rect.Width;
				}
			}
			XMatrixItem item = null;

			//ItemInfoList 생성(각 Item을 자신이 속하는 Row와 ColKey에 배치함)
			ItemInfo itemInfo = null;
			for (int i = 0 ; i < items.Count ; i++)
			{
				//1.Row 잘못지정 Check, maxColumnLevel보다는 커야함.(컬럼Header영역)
				item = items[i];
				if ((item.Row <= maxColumnLevel) || (item.Row >= rowItems.Count))
					throw new Exception("XMatrixItem's Row is invalid");
				//2.ColKey 잘못 지정 Check
				if (!this.colKeyRectList.Contains(item.ColKey))
					throw new Exception("XMatrixItem's ColKey is invalid");
				
				itemInfo = itemInfoList[item.Row, item.ColKey];
				if (itemInfo == null) //해당하는 ItemInfo가 없으면 생성후 ItemList에 Item Add
				{
					itemInfo = itemInfoList.Add(item.Row, item.ColKey);
					itemInfo.ItemList.Add(item);
				}
				else //ItemList에 Add
					itemInfo.ItemList.Add(item);
			}
			//Header영역 아래의 MatrixItem영역에서 각 영역 계산
			Hashtable sameColKeyItemList = new Hashtable();
			Size size = Size.Empty;
			int rowHeight = 0, rowMaxHeight = 0;
			int startYPos = rowItems[maxColumnLevel + 1].Rect.Y;  //시작 Y위치
			Rectangle colRect;

			using (Graphics g = this.CreateGraphics())
			{
				for (int i = maxColumnLevel + 1 ; i < this.rowItems.Count; i++)
				{
					rowItem = rowItems[i];
					sameColKeyItemList.Clear();
					rowMaxHeight = 0;
					//Clear
					rowHeight = 0;
					foreach (ItemInfo info in itemInfoList)
					{
						if (info.Row == i) //동일한 Row에 있는 Item
							sameColKeyItemList.Add(info.ColKey, info.ItemList);
					}
					foreach (ArrayList itemList in sameColKeyItemList.Values)
					{
						//Clear
						rowHeight = 0;
						foreach (XMatrixItem mItem in itemList)
						{
							colRect = (Rectangle) colKeyRectList[mItem.ColKey];
							if (mItem.Text != "")
							{
								size = DrawHelper.GetTextSize(g, mItem.Text, mItem.TextFont, colRect.Width);
								mItem.Rect = new Rectangle(colRect.X, startYPos + rowHeight, colRect.Width, size.Height + 6);
							}
							else //기본Size 적용하여 Set
							{
								mItem.Rect = new Rectangle(colRect.X, startYPos + rowHeight, colRect.Width, XMatrixUtils.DefaultItemHeight);
							}
							//RowHeight 누적
							rowHeight += mItem.Rect.Height;
						}
						//행의 최대 높이값 설정
						rowMaxHeight = Math.Max(rowHeight, rowMaxHeight);
					}
					//rowItem의 height를 rowMaxHeight로 설정, Y는 startYPos로
					//rowMaxHeight가 지정한 Height보다 작으면 지정한 Height로 설정함
					rowMaxHeight = Math.Max(rowMaxHeight, rowItem.Height);
					rowItem.Rect = new Rectangle(rowItem.Rect.X, startYPos, rowItem.Rect.Width, rowMaxHeight);
					//StartYPos 증가
					startYPos += rowMaxHeight;
				}
			}

			//영역 설정(colHeaderRect, rowHeaderRect, itemRect)
			int totalHeight = 0, totalWidth = 0, headerHeight = 0;
			for (int i = 0 ; i < rowItems.Count ; i++)
			{
				rowItem = rowItems[i];
				totalHeight += rowItem.Rect.Height;
				if (i <= this.maxColumnLevel)
					headerHeight += rowItem.Rect.Height;
			}

			foreach (XColMatrixItem cItem in this.colItems)
				totalWidth += cItem.Rect.Width;

			rowHeaderRect	= new Rectangle(0,0, rowHeaderWidth, totalHeight);
			colHeaderRect	= new Rectangle(rowHeaderWidth, 0, totalWidth, headerHeight);
			itemRect		= new Rectangle(rowHeaderWidth, headerHeight, totalWidth, totalHeight - headerHeight);

			//Control의 Size Set
			this.Size = new Size(rowHeaderWidth + totalWidth, totalHeight);

			//Invalidate
			this.Invalidate(true);

		}
		private void SetColItemRegion(XColMatrixItem parentItem, XColMatrixItem item, int xPos, int level, bool isLastItem)
		{
			//최대컬럼Level 비교 SET
			maxColumnLevel = Math.Max(level, maxColumnLevel);

			XRowMatrixItem rowItem = this.rowItems[level];
			int width = item.Width;
			if (parentItem != null) //Parent에 따라 마지막 Child 컬럼의 너비 조정
			{
				//마지막 컬럼의 Width 조정
				if (isLastItem)
					width = parentItem.Rect.Right - xPos;
				else if (xPos + width > parentItem.Rect.Right)  //이전컬럼이 문제이면 에러
					throw new Exception("Width Error!");
			}
			//Item의 Rect 설정
			item.Rect = new Rectangle(xPos, rowItem.Rect.Y, width, rowItem.Rect.Height);
			//Item의 ParentItem Set
			item.ParentItem = parentItem;
			//ColKey별 Rect 관리
			colKeyRectList.Add(item.Key, item.Rect);
			//XColMatrixItemList 생성
			ColMatrixItemList.Add(item.Key, item);

			//Level별 ColKey리스트 관리
			if (!levelColKeyList.Contains(level.ToString()))
			{
				levelColKeyList.Add(level.ToString(), new ArrayList());
				((ArrayList) levelColKeyList[level.ToString()]).Add(item.Key);
			}
			else
				((ArrayList) levelColKeyList[level.ToString()]).Add(item.Key);

			XColMatrixItem childItem = null;
			int currXPos = xPos;
			for (int i = 0 ; i < item.Childs.Count ; i++)
			{
				childItem = item.Childs[i];
				SetColItemRegion(item, childItem, currXPos, level + 1, (i == item.Childs.Count - 1));
				currXPos += childItem.Rect.Width;
			}
		}
		#endregion

		#region Draw
		private void DrawLine(Graphics g)
		{
			//RowLine Draw
			foreach (XRowMatrixItem item in rowItems)
				g.DrawLine(XMatrixUtils.LinePen, item.Rect.X, item.Rect.Y, this.Width, item.Rect.Y);

			//levelColKeyList와 colKeyRectList를 조합하여 Level로 Line Draw
			Rectangle colRect;
			foreach (ArrayList colKeyList in this.levelColKeyList.Values)
			{
				foreach (string colKey in colKeyList)
				{
					colRect = (Rectangle) this.colKeyRectList[colKey];
					g.DrawLine(XMatrixUtils.LinePen, colRect.X, colRect.Y, colRect.X, this.Height);
				}
			}
		}
		private void Draw(Graphics g)
		{
			//Line Draw
			DrawLine(g);

			//Draw시에 전체를 다시 그리지 않고, Clip영역에 속하는 것만 다시 그리도록 IsVisible 판단 추가
			if (g.IsVisible(this.rowHeaderRect))
			{
				foreach (XRowMatrixItem item in rowItems)
					item.Draw(g);
			}
			if (g.IsVisible(this.colHeaderRect))
			{
				foreach (XColMatrixItem item in this.ColMatrixItemList.Values)
					item.Draw(g);
			}
			if (g.IsVisible(this.itemRect))
			{
				foreach (XMatrixItem item in this.items)
					item.Draw(g);
			}
			// Draw border (그릴 Items가 있을때 Draw)
			if (this.rowItems.Count > 0)
				ControlPaint.DrawBorder(g,this.ClientRectangle, XMatrixUtils.LinePen.Color, ButtonBorderStyle.Solid); 
		}
		#endregion

		#region override
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint (e);
			if (this.reDraw)
				Draw(e.Graphics);
		}
		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown (e);

			mousePoint = new Point(e.X, e.Y);
			mouseButton = e.Button;
			hitItem = null;

			//Mouse Point가 Item 영역이 아니면 Return
			if (!this.itemRect.Contains(e.X, e.Y)) return;

			hitItem = GetHitItem(mousePoint);

			if (e.Button == MouseButtons.Left)
			{
				if (hitItem == null)
				{
					UnSelectAll();  //기존 선택 Clear
					return;
				}

				//MultiSelect가 아니면 기존 선택영역 Clear
				if (!this.enableMultiSelection)
				{
					//현재 hitItem이 Selected상태이면 Clear, 아니면 기존 선택된 리스트 선택상태 해제후 선택
					if (hitItem.State == XMatrixItemState.Selected)
					{
						this.selectedItems.Clear();
						hitItem.State = XMatrixItemState.Normal;
						//해당 영역만 다시그림
						Invalidate(hitItem.Rect);
					}
					else
					{
						foreach (XMatrixItem item in this.selectedItems)
							item.State = XMatrixItemState.Normal;
						hitItem.State = XMatrixItemState.Selected;
						this.selectedItems.Add(hitItem);
						//Item 영역 다시 그림
						this.Invalidate(this.itemRect);
					}
				}
				else
				{
					//Toggle이거나 Ctrl Key를 누른상태에는 해당 Item만 선택 등록 및 해제
					if (this.toggleSelection || ((Control.ModifierKeys & Keys.Control) == Keys.Control))
					{
						//현재 hitItem이 Selected상태이면 Normal, Normal -> Select
						if (hitItem.State == XMatrixItemState.Selected)
						{
							hitItem.State =  XMatrixItemState.Normal;
							//선택리스트에 Remove
							this.selectedItems.Remove(hitItem);
							//해당 영역만 다시그림
							Invalidate(hitItem.Rect);
						}
						else //Normal -> Selected 선택리스트에 Add
						{
							hitItem.State =  XMatrixItemState.Selected;
							//선택리스트에 Add
							this.selectedItems.Add(hitItem);
							//해당 영역만 다시그림
							Invalidate(hitItem.Rect);	
						}
					}
					else  //Ctrl Key를 누르지 않은 상태
					{
						//현재 hitItem이 Selected상태이면 Normal 다른 선택영역도 Clear, Normal 상태이면 기존 선택영역 Clear후 해당 Item 선택
						if (hitItem.State == XMatrixItemState.Selected)
						{
							foreach (XMatrixItem item in this.selectedItems)
								item.State = XMatrixItemState.Normal;
							this.selectedItems.Clear();
							//Item 영역 다시 그림
							this.Invalidate(this.itemRect);
						}
						else //기존 선택영역 Clear후에 hitItem Selected로 변경
						{
							foreach (XMatrixItem item in this.selectedItems)
								item.State = XMatrixItemState.Normal;
							this.selectedItems.Clear();
							hitItem.State =  XMatrixItemState.Selected;
							//선택리스트에 Add
							this.selectedItems.Add(hitItem);
							//Item 영역 다시 그림
							this.Invalidate(this.itemRect);
						}
					}
				}
			}

		}
		protected override void OnDoubleClick(EventArgs e)
		{
			base.OnDoubleClick (e);

			//HitItem이 있으면 OnItemDoubleClick Call
			if (this.hitItem != null)
				if (ItemDoubleClick != null)
					OnItemDoubleClick(new XMatrixItemClickEventArgs(hitItem, this.mouseButton));
		}

		protected override void OnClick(EventArgs e)
		{
			base.OnClick (e);
			//HitItem이 있으면 OnItemDoubleClick Call
			if (this.hitItem != null)
				if (ItemClick != null)
					OnItemClick(new XMatrixItemClickEventArgs(hitItem, this.mouseButton));
		}
		protected override void OnDragDrop(DragEventArgs drgevent)
		{
			base.OnDragDrop (drgevent);
			
			if (this.ItemDragDrop != null)
			{
				//Drop되는 Point 계산
				Point dropPt = this.PointToClient(new Point(drgevent.X,drgevent.Y)); 
				//Drop되는 Point가 itemRect 영역에 있으면 ItemDragDrop Event Call
				if (!this.itemRect.Contains(dropPt)) return;
				//Drop되는 위치의 XMatrixItem Get
				XMatrixItem dropItem = this.GetHitItem(dropPt);
				//drop되는 위치의 Row와 ColKey 계산
				XRowMatrixItem dropRowItem = null;
				XColMatrixItem dropColItem = null;
				int dropRow = 0;
				string dropColKey = "";
				if (dropItem != null)
				{
					dropRow = dropItem.Row;
					dropColKey = dropItem.ColKey;
					dropRowItem = this.rowItems[dropItem.Row];
					dropColItem = this.ColMatrixItemList[dropItem.ColKey] as XColMatrixItem;
				}
				else //빈자리로 Drop시는 위치계산
				{
					int index = 0;
					foreach (XRowMatrixItem item in this.rowItems)
					{
						if (item.Rect.Contains(3, dropPt.Y))  //해당하는 영역에 속하면
						{
							dropRowItem = item;
							dropRow = index;
							break;
						}
						index++;
					}
					if (dropRowItem != null) //해당되는 RowItem의 ColLevel을 찾아서 ColKey Get
					{
						int colLevel = dropRowItem.ColLevel;
						Rectangle colRect;
						foreach (string colKey in (ArrayList)levelColKeyList[dropRowItem.ColLevel.ToString()])
						{
							colRect = (Rectangle) this.colKeyRectList[colKey];
							if (colRect.Contains(dropPt.X, colRect.Y + 3)) //해당영역에 속하면
							{
								dropColItem = this.ColMatrixItemList[colKey] as XColMatrixItem;
								dropColKey = colKey;
								break;
							}

						}
					}
				}

				//RowItem, ColItem이 있으면 Event Call
				if ((dropRowItem != null) && (dropColItem != null))
				{
					OnItemDragDrop(new XMatrixItemDragDropEventArgs(drgevent.Data,drgevent.KeyState, dropRow, dropColKey, dropRowItem, dropColItem, dropItem));
				}
			}
				
		}
		#endregion

		#region Event invoker
		protected void OnItemClick(XMatrixItemClickEventArgs e)
		{
			if (this.ItemClick != null)
				this.ItemClick(this, e);
		}
		protected void OnItemDoubleClick(XMatrixItemClickEventArgs e)
		{
			if (this.ItemDoubleClick != null)
				this.ItemDoubleClick(this, e);
		}
		protected void OnItemDragDrop(XMatrixItemDragDropEventArgs e)
		{
			if (this.ItemDragDrop != null)
				this.ItemDragDrop(this, e);
		}
		#endregion

		#region Methods
		public XMatrixItem GetHitItem(Point pt)
		{
			foreach (XMatrixItem item in this.items)
				if (item.HitTest(pt))
					return item;

			return null;
		}
		
		public void UnSelectAll()
		{
			//선택영역 Clear
			foreach (XMatrixItem item in this.selectedItems)
				item.State = XMatrixItemState.Normal;
			this.selectedItems.Clear();
			this.Invalidate(this.itemRect);
		}
		public void PageSetup()
		{
			float converter = 2.54f;
			PageSetupDialog dlg = new PageSetupDialog();
			dlg.AllowPrinter = false; //Print 단추 Disable
			//원래 Margin 보관
			Margins origMargins = (Margins) pageSettings.Margins.Clone();
			this.printDoc.DefaultPageSettings = this.pageSettings;
			dlg.Document = this.printDoc;
			//dlg의 PageSettings.Margins 변경 (PageSettings (1/100 inch)단위 dlg의 단위는 millecm 단위, 1inch = 2.54cm)
			dlg.PageSettings.Margins.Left = (int) ((float)dlg.PageSettings.Margins.Left * converter);
			dlg.PageSettings.Margins.Right = (int) ((float)dlg.PageSettings.Margins.Right * converter);
			dlg.PageSettings.Margins.Top = (int) ((float)dlg.PageSettings.Margins.Top * converter);
			dlg.PageSettings.Margins.Bottom = (int) ((float)dlg.PageSettings.Margins.Bottom * converter);
			//PageSetupDialog는 취소를 누르면 Margins가 변경되어 나온다. 따라서, 원 마진을 보관하였다가 취소시는 원래 Margin으로 복구처리함.
			if (dlg.ShowDialog() == DialogResult.Cancel)
				pageSettings.Margins = (Margins) origMargins.Clone();
		}
		/// <summary>
		/// XMatrix를 Print합니다.
		/// </summary>
		public void Print()
		{
			try
			{
				printDoc.DefaultPageSettings = this.pageSettings;
				//Page 설정
				printDoc.PrinterSettings.FromPage = 1;
				printDoc.PrinterSettings.ToPage = printDoc.CalcPageCount();
				printDoc.PrinterSettings.PrintRange = PrintRange.AllPages; // 최초 AllPages
				PrintDialog dlg = new PrintDialog();
				dlg.AllowSomePages = true; //부분인쇄 가능
				dlg.Document = printDoc;
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					//PrintDocument의 PageSetting의 PrinterSettings SET
					//전체인쇄, 부분인쇄시 변경시 DefaultPageSettings.PrinterSettings의 값을 변경해야함
					//변경하지 않으면 Print시 발생하는 OnPagePrint에서의 Argument로 전달되는 값이 항상 전체인쇄가 됨
					printDoc.DefaultPageSettings.PrinterSettings = dlg.PrinterSettings;
					// Print
					printDoc.Print();
				}
			}
			catch
			{
				string msg = XMsg.GetMsg("M016") + "\n" //출력에 실패하였습니다. 프린더의 전원을 확인해 주십시오.
					+ XMsg.GetMsg("M017") + "\n\n" //프린더 드라이버가 제대로 설정되어 있는지 확인해 주십시오.
					+ XMsg.GetMsg("M018");  //계속 출력이 안되면 전산실에 문의해 주십시오.
				MessageBox.Show(msg, "Print");
			}
		}
		/// <summary>
		/// Print 미리보기합니다.
		/// </summary>
		public void PrintPreview()
		{
			try
			{
				printDoc.DefaultPageSettings = this.pageSettings;
				// PreView일때는 전체 Page 인쇄로 설정
				printDoc.DefaultPageSettings.PrinterSettings.PrintRange = PrintRange.AllPages;
				PrintPreviewDialog dlg = new PrintPreviewDialog();
				dlg.Document = printDoc;
				dlg.ShowDialog();
			}
			catch
			{
				string msg = XMsg.GetMsg("M016") + "\n" //출력에 실패하였습니다. 프린더의 전원을 확인해 주십시오.
					+ XMsg.GetMsg("M017") + "\n\n" //프린더 드라이버가 제대로 설정되어 있는지 확인해 주십시오.
					+ XMsg.GetMsg("M018");  //계속 출력이 안되면 전산실에 문의해 주십시오.
				MessageBox.Show(msg, "PrintPreview");
			}
		}
		#endregion
	}
}

