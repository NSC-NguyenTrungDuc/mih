using System;
using System.Drawing;
using System.Collections;
using System.Diagnostics;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace IHIS.Framework
{
	/// <summary>
	/// GridReportDocument class에 대한 요약설명입니다.
	/// </summary>
	internal class XGridPrintDocument : System.Drawing.Printing.PrintDocument
	{
		#region Fields
		private XGrid grid = null;
		private int currRow = 0;
		private int currCol = 0;
		private int nextFirstCol = 0;
		private int nextFirstRow = 0;
		private int numberOfPages = 0;
		private bool isPrintSomePages = false;
		private int fromPage = 0;
		private int toPage = 0;
		private ArrayList firstRowList = new ArrayList();  // Row의 Page에 따른 첫번째 Row의 List
		private ArrayList firstColList = new ArrayList();  // Col의 Page에 따른 첫번째 Col의 List
		private StringFormat textFormat = new StringFormat();
		#endregion

		#region Constructor
		/// <summary>
		/// GridReportDocument 생성자
		/// </summary>
		/// <param name="grid"></param>
		public XGridPrintDocument(XGrid grid)
		{
			this.grid = grid;
			//TextFormat 설정
			textFormat.FormatFlags =StringFormatFlags.NoWrap;
			textFormat.Trimming = StringTrimming.EllipsisCharacter;
		}
		#endregion

		#region override
		/// <summary>
		/// BeginPrint Event를 발생시킵니다.
		/// (override) 변수값을 초기화 합니다.(인쇄Page Check)
		/// </summary>
		/// <param name="e"></param>
		protected override void OnBeginPrint(PrintEventArgs e)
		{
			base.OnBeginPrint (e);
			// 변수 초기화
			currRow = 0;
			currCol = 0;
			nextFirstCol = 0;
			nextFirstRow = 0;
			numberOfPages = 0;
			// 부분인쇄시 부분인쇄 Page 적합성여부 Check
			this.isPrintSomePages = (this.DefaultPageSettings.PrinterSettings.PrintRange == PrintRange.SomePages ? true : false);
			if (isPrintSomePages)
			{
				int pageCnt = this.CalcPageCount();
				int currPage = 0;
				bool isFind = false;
				this.fromPage = this.DefaultPageSettings.PrinterSettings.FromPage;
				this.toPage = this.DefaultPageSettings.PrinterSettings.ToPage;
				if ((fromPage <= 0) || (toPage <= 0) || (fromPage > pageCnt) || (fromPage > toPage))
				{
					MessageBox.Show(XMsg.GetMsg("M071"), "Print"); //인쇄영역을 잘못 지정하셨습니다
					e.Cancel = true;
				}
				//fromPage에 따라 currRow, currCol SET, 저장된 firstRowList, firstColList에서 fromPage에 해당하는 Row, Col SET
				foreach (int col in firstColList)
				{
					foreach (int row in firstRowList)
					{
						currPage++;
						if (fromPage == currPage)
						{
							currRow = row;
							currCol = col;
							isFind = true;
							break;
						}
					}
					if (isFind)
						break;
				}
			}
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="e"></param>
		protected override void OnQueryPageSettings(QueryPageSettingsEventArgs e)
		{
			base.OnQueryPageSettings(e);
			numberOfPages++; // 인쇄 Page수 증가
			
			// 부분인쇄시 인쇄 Page수가 부분인쇄Page수보다 크면 인쇄하지 않음
			if (this.isPrintSomePages)
			{
				int pageCnt = this.toPage - this.fromPage + 1;
				if (numberOfPages > pageCnt)
					e.Cancel = true;
			}
		}
		/// <summary>
		/// PrintPage Event를 발생시킵니다.
		/// (override) Grid를 Print할 수 있도록 그립니다.
		/// </summary>
		/// <param name="e"></param>
		protected override void OnPrintPage(PrintPageEventArgs e)
		{
			base.OnPrintPage (e);
			nextFirstCol = 0;
			nextFirstRow = 0;

			int leftMargin = e.MarginBounds.Left;
			int topMargin = e.MarginBounds.Top;
			int yPosition = topMargin;
			int xPosition = leftMargin;
			int drawEndCol = 0;
			int drawEndRow = 0;
			int drawStartRow = this.currRow;
			int headerHeight = 0;
			int width = leftMargin;
			int height = topMargin;
			int headerRowCnt = grid.AddedHeaderLine + grid.LinePerRow;

			//HeaderHeight SET
			for (int i = 0 ; i < headerRowCnt ; i++)
				headerHeight += grid.CellRowInfo[i].Height;

			//Next FirstCol Find
			for (int c = currCol ; c < grid.CellColInfo.Count ; c++)
			{
				width += grid.CellColInfo[c].Width;
				if ((width > e.MarginBounds.Right) && (c > currCol))
				{
					nextFirstCol = c;
					break;
				}
			}
			//Next FirstRow Find
			for (int r = currRow ; r < grid.CellRowInfo.Count ; r++)
			{
				// 다음 Page일때는 Header를 먼저 그리므로 HeaderHeight까지 고려
				if ((currRow > 0) && (r == currRow)) height += headerHeight;
				height += grid.CellRowInfo[r].Height;
				if ((height > e.MarginBounds.Bottom) && (r > currRow))
				{
					nextFirstRow = r;
					break;
				}
			}
			//endPaintRow, endPaintCol Set
			if (nextFirstRow == 0)
				drawEndRow = grid.CellRowInfo.Count;
			else
				drawEndRow = nextFirstRow;

			if (nextFirstCol == 0)
				drawEndCol = grid.CellColInfo.Count;
			else
				drawEndCol = nextFirstCol;


			//Draw Header (currCol ~ nextFirstCol까지)
			for (int r = 0 ; r < headerRowCnt ; r++)
			{
				xPosition = leftMargin;
				for (int c = currCol ; c < drawEndCol ; c++)
				{
					this.DrawCell(e.Graphics, grid[r,c], xPosition,yPosition);
					//xPosition 누적
					xPosition += grid.CellColInfo[c].Width;
				}
				// yPosition 누적
				yPosition += grid.CellRowInfo[r].Height;
			}
			//drawStartRow SET (최초 그릴때 Header는 앞에서 그리므로 Row만 그림)
			if (currRow < grid.AddedHeaderLine + grid.LinePerRow)
				drawStartRow = grid.AddedHeaderLine + grid.LinePerRow;

			//Draw Cell
			for (int r = drawStartRow ; r < drawEndRow ; r++)
			{
				xPosition = leftMargin;
				for (int c = currCol ; c < drawEndCol ; c++)
				{
					this.DrawCell(e.Graphics, grid[r,c], xPosition,yPosition);
					//xPosition 누적
					xPosition += grid.CellColInfo[c].Width;
				}
				// yPosition 누적
				yPosition += grid.CellRowInfo[r].Height;
			}
			
			//CurrRow SET
			currRow = drawEndRow;

			//HasMorePages SET
			if (currRow < grid.Rows)
			{
				e.HasMorePages = true;
			}
			else
			{
				if (this.nextFirstCol == 0)
					e.HasMorePages = false;
				else
				{
					currRow = 0;
					currCol = nextFirstCol;
					e.HasMorePages = true;
				}
			}
		}
		#endregion

		#region DrawCell
		private void DrawCell(Graphics g, XCell cell, int xPos, int yPos)
		{
			if (cell == null) return;
			Rectangle cellRect = cell.AbsoluteRectangle;
			Rectangle drawRect;
			string dispText;

			drawRect = new Rectangle(xPos, yPos, cellRect.Width, cellRect.Height);
			//Content가 아니면 WhiteSmoke로 Fill
			if (cell.Personality != XCellPersonality.Content)
				g.FillRectangle(Brushes.WhiteSmoke, drawRect);
			//Border Draw
			g.DrawRectangle(Pens.LightGray,drawRect);
			//Image Draw
			if (cell.Image != null)
			{
				//전체영역 Image Draw
				if (cell.ImageStretch)
				{
					g.DrawImage(cell.Image, drawRect);
				}
				else
				{
					PointF pointImage = DrawHelper.GetObjAlignment(cell.ImageAlignment, drawRect.Left, drawRect.Top, drawRect.Width, drawRect.Height, cell.Image.Width, cell.Image.Height);
					RectangleF imageRect = drawRect;
					imageRect.Intersect(new RectangleF(pointImage, cell.Image.PhysicalDimension));
					//Truncate the Rectangle for appreximation problem
					g.DrawImage(cell.Image,Rectangle.Truncate(imageRect));
				}
			}
			//Text Draw
			dispText = cell.CellDisplayText;
			if ((dispText.Length > 0) && (drawRect.Width > 2) && (drawRect.Height > 2))
			{
				Rectangle textRect = drawRect;
				//Align Text To Image (Image가 있으면 Image Size에 맞추어 Text Size 조정)
				if ((cell.Image != null) && !cell.ImageStretch && cell.ChangeTextRegionByImageRegion)
				{
					//imageAlignment가 Left이면 X이동 Width 감소, Right이면 Width감소
					if (XGridUtility.IsLeft(cell.ImageAlignment))
					{
						textRect.X += cell.Image.Width;
						textRect.Width -= cell.Image.Width;
					}
					else if (XGridUtility.IsRight(cell.ImageAlignment))
					{
						textRect.Width -= cell.Image.Width;
					}
				}
				//TextFormat 설정
				//Text의 길이가 Rect보다 클 경우를 고려하여 TextFormat을 설정하여 Text Draw
				if (DrawHelper.IsLeft(cell.TextAlignment))
					textFormat.Alignment = StringAlignment.Near;
				else if (DrawHelper.IsHCenter(cell.TextAlignment))
					textFormat.Alignment = StringAlignment.Center;
				else
					textFormat.Alignment = StringAlignment.Far;
				if (DrawHelper.IsTop(cell.TextAlignment))
					textFormat.LineAlignment = StringAlignment.Near;
				else if (DrawHelper.IsVCenter(cell.TextAlignment))
					textFormat.LineAlignment = StringAlignment.Center;
				else
					textFormat.LineAlignment = StringAlignment.Far;

				g.DrawString(dispText, cell.Font, Brushes.Black, textRect, textFormat); 
			}
		}
		#endregion

		#region CalcPagesCount
		/// <summary>
		/// 출력할 Page의 Count를 계산합니다.
		/// </summary>
		/// <returns></returns>
		internal int CalcPageCount()
		{
			int leftMargin = this.DefaultPageSettings.Margins.Left;
			int topMargin = this.DefaultPageSettings.Margins.Top;
			int rightMargin = this.DefaultPageSettings.Margins.Right;
			int bottomMargin = this.DefaultPageSettings.Margins.Bottom;
			int boundRight = this.DefaultPageSettings.Bounds.Right - rightMargin;
			int boundBottom = this.DefaultPageSettings.Bounds.Bottom - bottomMargin;
			int xPageCount = 1;  // 마지막장 고려 1부터 시작
			int yPageCount = 1;  // 마지막장 고려 1부터 시작
			int headerHeight = 0;
			int width = leftMargin;
			int height = topMargin;
			int headerRowCnt = grid.AddedHeaderLine + grid.LinePerRow;
			int nextFirstColumn = 0;

			// List Clear, 첫번째 Row, Col = 0 SET
			firstRowList.Clear();
			firstColList.Clear();
			firstRowList.Add(0);
			firstColList.Add(0);

			//HeaderHeight SET
			for (int i = 0 ; i < headerRowCnt ; i++)
				headerHeight += grid.CellRowInfo[i].Height;

			//X축의 PageCount GET
			//0 ~ Cols까지에서 boundRight를 넘는 갯수 Count
			for (int c = 0 ; c < grid.CellColInfo.Count ; c++)
			{
				width += grid.CellColInfo[c].Width;
				if (width > boundRight)
				{
					width = leftMargin + grid.CellColInfo[c].Width;
					xPageCount++;
					//firstColList에 Add
					firstColList.Add(c);
				}
			}
			//Y축의 PageCount GET
			// 0 ~ Rows까지 boundBottom을 넘수 갯수 Count
			//Next FirstRow Find
			for (int r = 0 ; r < grid.CellRowInfo.Count ; r++)
			{

				// 다음 Page일때는 Header를 먼저 그리므로 HeaderHeight까지 고려
				if ((yPageCount > 1) && (r == nextFirstColumn)) height += headerHeight;
				height += grid.CellRowInfo[r].Height;
				if (height > boundBottom)
				{
					height = topMargin + grid.CellRowInfo[r].Height;
					yPageCount++;
					nextFirstColumn = r + 1;
					//firstRowList에 Add
					firstRowList.Add(r);
				}
			}

			//PageCount = XPage갯수 * YPage갯수
			return xPageCount * yPageCount;
		}
		#endregion
	}
	/// <summary>
	/// Grid의 PageSetup class에 대한 요약설명입니다.
	/// </summary>
	public class XGridPageSetup
	{
		private static PageSettings pageSettings = new PageSettings();
		/// <summary>
		/// PageSetting을 가져오거나 설정합니다.
		/// </summary>
		public static PageSettings PageSettings
		{
			get { return pageSettings;}
			set { pageSettings = value;}
		}
		/// <summary>
		/// Grid의 출력 Page를 Setup합니다.
		/// </summary>
		public static void PageSetup(PrintDocument pDoc)
		{
			//float converter = 2.54f;
			int converter = 254;
			PageSetupDialog dlg = new PageSetupDialog();
			pDoc.DefaultPageSettings = XGridPageSetup.PageSettings;
			dlg.Document = pDoc;
			//dlg의 PageSettings.Margins 변경 (PageSettings (1/100 inch)단위 dlg의 단위는 millscm 단위, 1inch = 2.54cm)
			dlg.PageSettings.Margins.Left = dlg.PageSettings.Margins.Left * converter/100;
			dlg.PageSettings.Margins.Right = dlg.PageSettings.Margins.Right * converter/100;
			dlg.PageSettings.Margins.Top = dlg.PageSettings.Margins.Top * converter/100;
			dlg.PageSettings.Margins.Bottom = dlg.PageSettings.Margins.Bottom * converter/100;
			dlg.ShowDialog();
		}
	}

}
