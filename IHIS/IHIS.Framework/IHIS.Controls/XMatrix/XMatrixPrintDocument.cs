using System;
using System.Drawing;
using System.Collections;
using System.Diagnostics;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace IHIS.Framework
{
	#region XMatrixPrintDocument
	/// <summary>
	/// XMatrixPrintDocument에 대한 요약 설명입니다.
	/// </summary>
	internal class XMatrixPrintDocument : System.Drawing.Printing.PrintDocument
	{
		#region Fields
		private XMatrixControl matrix = null;
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
		#endregion

		#region 생성자
		public XMatrixPrintDocument(XMatrixControl matrix)
		{
			this.matrix = matrix;
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
			//int boundRight = this.DefaultPageSettings.Bounds.Right - rightMargin;
			//int boundBottom = this.DefaultPageSettings.Bounds.Bottom - bottomMargin;
			int boundRight = this.DefaultPageSettings.Bounds.Right;
			int boundBottom = this.DefaultPageSettings.Bounds.Bottom;
			int xPageCount = 1;  // 마지막장 고려 1부터 시작
			int yPageCount = 1;  // 마지막장 고려 1부터 시작
			int width = leftMargin + matrix.RowHeaderWidth;  //시작위치는 Margin + RowHeader의 너비
			int height = topMargin;

			// List Clear 첫번째 Row, Col = 0 SET
			firstRowList.Clear();
			firstColList.Clear();
			firstRowList.Add(0);
			firstColList.Add(0);
			
			for (int c = 0; c < matrix.ColItems.Count ; c++)
			{
				width += matrix.ColItems[c].Rect.Width;
				//한 Page Col 영역 초과
				if (width > boundRight)
				{
					width = leftMargin + matrix.ColItems[c].Rect.Width;
					xPageCount++;
					firstColList.Add(c);
				}
			}
			//Y축의 PageCount GET
			// 0 ~ RowItems.Count까지 boundBottom을 넘수 갯수 Count
			//Next FirstRow Find
			for (int r = 0 ; r < matrix.RowItems.Count ; r++)
			{
				height += matrix.RowItems[r].Rect.Height;
				if (height > boundBottom)
				{
					height = topMargin + matrix.RowItems[r].Rect.Height;
					yPageCount++;
					//firstRowList에 Add
					firstRowList.Add(r);
				}
			}

			//PageCount = XPage갯수 * YPage갯수
			return xPageCount * yPageCount;
		}
		#endregion

		#region Print 관련 override
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
					MessageBox.Show(XMsg.GetMsg("M019"), "Print"); //인쇄영역을 잘못 지정하셨습니다
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
		protected override void OnPrintPage(PrintPageEventArgs e)
		{
			base.OnPrintPage (e);
			nextFirstCol = 0;
			nextFirstRow = 0;

			int leftMargin = e.MarginBounds.Left;
			int topMargin = e.MarginBounds.Top;
			int yPosition = topMargin;
			int drawEndCol = 0;
			int drawEndRow = 0;
			int drawStartRow = this.currRow;
			int widthPos = leftMargin;
			int heightPos = topMargin;
			int startX = leftMargin;
			Point basePoint = new Point(0,0);

			//currCol == 0일때 Matrix의 RowHeaderWidth도 같이 고려해야함.
			if (currCol == 0)
			{
				widthPos += matrix.RowHeaderWidth;
				startX += matrix.RowHeaderWidth;
			}

			//Next FirstCol Find
			for (int c = currCol ; c < matrix.ColItems.Count ; c++)
			{
				//기준위치는 c = currCol일때 SET
				if (c == currCol)
					basePoint.X = matrix.ColItems[c].Rect.X;

				widthPos += matrix.ColItems[c].Rect.Width;
				if ((widthPos > e.MarginBounds.Right) && (c > currCol))
				{
					nextFirstCol = c;
					//마지막 Width Pos는 마지막 Width 제거
					widthPos -= matrix.ColItems[c].Rect.Width;
					break;
				}
			}
			//Next FirstRow Find
			for (int r = currRow ; r < matrix.RowItems.Count ; r++)
			{
				//기준위치는 r = currRow일때 SET
				if (r == currRow)
					basePoint.Y = matrix.RowItems[r].Rect.Y;

				heightPos += matrix.RowItems[r].Rect.Height;
				if ((heightPos > e.MarginBounds.Bottom) && (r > currRow))
				{
					nextFirstRow = r;
					//마지막 Height Pos는 마지막 Height 제거
					heightPos -= matrix.RowItems[r].Rect.Height;
					break;
				}
			}
			//endPaintRow, endPaintCol Set
			if (nextFirstRow == 0)
				drawEndRow = matrix.RowItems.Count;
			else
				drawEndRow = nextFirstRow;

			if (nextFirstCol == 0)
				drawEndCol = matrix.ColItems.Count;
			else
				drawEndCol = nextFirstCol;

			ArrayList rowList = new ArrayList();  //그리기 영역에 속하는 Row List
			ArrayList colKeyList = new ArrayList();  //그리기 영역에 속하는 Column Key List

			//DrawLine (RowLine Draw, ColLine Draw)
			//RowLine Draw
			for (int r = drawStartRow ; r < drawEndRow ; r++)
			{
				rowList.Add(r); //RowList에 Add
				XRowMatrixItem item = matrix.RowItems[r];
				e.Graphics.DrawLine(XMatrixUtils.LinePen, leftMargin, yPosition, widthPos, yPosition);
				// yPosition 누적
				yPosition += item.Height;
			}
			//마지막 RowLine Draw
			e.Graphics.DrawLine(XMatrixUtils.LinePen, leftMargin, yPosition, widthPos, yPosition);
			
			XColMatrixItem colItem = null;
			//currCol == 0일때 맨앞 Line Draw (RowHeader Vertical Line)
			if (currCol == 0)
				e.Graphics.DrawLine(XMatrixUtils.LinePen, leftMargin, topMargin, leftMargin, heightPos);
			//ColLine Draw
			for (int c = currCol ; c < drawEndCol ; c++)
			{
				colItem = matrix.ColItems[c];
				//matrix의 ColKeyRectList에서 해당 item의 Rect 도출함, Child가 있으므로 Recursive를 돌며 Draw
				//drawStartRow가 0이 경우와 다음 경우일때 그리는 모양이 다르므로 주의
				DrawColumnLineSub(e.Graphics, drawStartRow, startX, topMargin, heightPos, basePoint, colItem, colKeyList);
			}
			//마지막 컬럼 Line Draw
			e.Graphics.DrawLine(XMatrixUtils.LinePen, startX + (colItem.Rect.Right - basePoint.X), topMargin, 
								startX + (colItem.Rect.Right - basePoint.X), heightPos);
			
			//Draw ColItem (전체 ColItem중에서 Key가 속하는 것만)
			foreach (XColMatrixItem item in matrix.ColMatrixItemList.Values)
			{
				//그리기행에 속하는 Item만 Draw, 이때 DrawRect 조정
				if (colKeyList.Contains(item.Key))
				{
					Rectangle drawRect = new Rectangle(startX + item.Rect.X - basePoint.X, topMargin + item.Rect.Y - basePoint.Y, item.Rect.Width, item.Rect.Height);
					item.Draw(e.Graphics, drawRect);
				}
			}

			//Draw RowItem(전체 RowItem중에서 해당하는 Row만, 단 currCol = 0인 경우)
			if (this.currCol == 0)
			{
				for (int r = drawStartRow ; r < drawEndRow ; r++)
				{
					XRowMatrixItem item = matrix.RowItems[r];
					Rectangle drawRect = new Rectangle(leftMargin , topMargin + item.Rect.Y - basePoint.Y, item.Rect.Width, item.Rect.Height);
					item.Draw(e.Graphics, drawRect);
				}
			}

			//Draw Item
			foreach (XMatrixItem item in matrix.Items)
			{
				//그리기 열, 그리기행에 속하는 Item만 Draw, 이때 DrawRect 조정
				if (rowList.Contains(item.Row) && colKeyList.Contains(item.ColKey))
				{
					Rectangle drawRect = new Rectangle(startX + item.Rect.X - basePoint.X, topMargin + item.Rect.Y - basePoint.Y, item.Rect.Width, item.Rect.Height);
					item.Draw(e.Graphics, drawRect);
				}
			}
			
			//CurrRow SET
			currRow = drawEndRow;

			//HasMorePages SET
			if (currRow < matrix.RowItems.Count)
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
		private void DrawColumnLineSub(Graphics g, int drawStartRow, int startX, int startY, int heightPos, Point basePt, XColMatrixItem item, ArrayList colKeyList)
		{
			colKeyList.Add(item.Key); //ColKey Add
			Rectangle itemRect = item.Rect;
			int YDiff = 0, XDiff = 0;
			if (drawStartRow == 0) //처음행이면 시작 위치 조정
				YDiff = itemRect.Y - basePt.Y;
			XDiff = itemRect.X - basePt.X; //X위치의 차이계산
			g.DrawLine(XMatrixUtils.LinePen, startX + XDiff, startY + YDiff, startX + XDiff, heightPos);
			//Sub Item
			foreach (XColMatrixItem subItem in item.Childs)
				DrawColumnLineSub(g, drawStartRow, startX, startY, heightPos, basePt, subItem, colKeyList);
		}
		#endregion
	}
	#endregion

	#region XMatrixPageSetup
	/// <summary>
	/// XMatrix의 PageSetup class에 대한 요약설명입니다.
	/// </summary>
	internal class XMatrixPageSetup
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
			pDoc.DefaultPageSettings = XMatrixPageSetup.PageSettings;
			dlg.Document = pDoc;
			//dlg의 PageSettings.Margins 변경 (PageSettings (1/100 inch)단위 dlg의 단위는 millscm 단위, 1inch = 2.54cm)
			dlg.PageSettings.Margins.Left = dlg.PageSettings.Margins.Left * converter/100;
			dlg.PageSettings.Margins.Right = dlg.PageSettings.Margins.Right * converter/100;
			dlg.PageSettings.Margins.Top = dlg.PageSettings.Margins.Top * converter/100;
			dlg.PageSettings.Margins.Bottom = dlg.PageSettings.Margins.Bottom * converter/100;
			dlg.ShowDialog();
		}
	}
	#endregion
}
