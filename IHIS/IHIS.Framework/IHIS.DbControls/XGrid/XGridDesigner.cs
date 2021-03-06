using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Design;
using System.Data;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace IHIS.Framework
{
	/// <summary>
	/// XGrid의 DesignTime 지원을 위한 Designer입니다.
	/// </summary>
	internal class XGridDesigner : ControlDesigner, ITypeDescriptorContext, IServiceProvider, IWindowsFormsEditorService
	{
		private XGrid grid = null;
		private bool gridOldAllowDrop = false;
		private ISelectionService iSvc;
		private IComponentChangeService iComp;
		private IDesignerHost iHost;
		private DesignerVerbCollection verbs;
		private ArrayList changeList = new ArrayList();
		private bool	canDrag = false;
		private int		dragX = 0;
		private int		dragY = 0;
		private XCell	mouseDownCell = null;
		private ArrayList dragDropList = new ArrayList();  //DragDrop List 관리
		private Hashtable groupNameList = new Hashtable(); //GroupName List 관리

		private IHIS.X.Magic.Menus.PopupMenu popupMenu = new IHIS.X.Magic.Menus.PopupMenu();

		protected override bool EnableDragRect 
		{
			get { return true;}
		}
		/// <summary>
		/// 디자이너를 지정된 구성 요소로 초기화합니다.
		/// </summary>
		/// <param name="component">디자이너에 연결할 IComponent</param>
		public override void Initialize(IComponent component)
		{
			base.Initialize(component);

			// Design하고있는 Control 등록
			grid = (XGrid) component;

			//Service Instance Set
			iSvc = (ISelectionService) GetService(typeof(ISelectionService));
			iComp = (IComponentChangeService) GetService(typeof(IComponentChangeService));
			iHost = (IDesignerHost) GetService(typeof(IDesignerHost));
			verbs = new DesignerVerbCollection();
			

			//Verbs Add
			verbs.Add( new DesignerVerb("&Edit Columns", new EventHandler(OnEditColumns)));
			verbs.Add( new DesignerVerb("&Add Headers", new EventHandler(OnAddHeaders)));
			verbs.Add( new DesignerVerb("&Default Height", new EventHandler(OnDefaultHeight)));
			verbs.Add( new DesignerVerb("&Create/Remove Group", new EventHandler(OnCreateRemoveGroup)));
			verbs.Add( new DesignerVerb("&Add ComputedColumn", new EventHandler(OnAddComputedColumn)));
			
			popupMenu.MenuCommands.Add(new IHIS.X.Magic.Menus.MenuCommand("&Padding Header",XGridImage.PaddingHeader, new EventHandler(OnPaddingHeader)));
			popupMenu.MenuCommands.Add(new IHIS.X.Magic.Menus.MenuCommand("&Recover Padding",XGridImage.RecoverPadding, new EventHandler(OnRecoverPadding)));
			popupMenu.MenuCommands.Add(new IHIS.X.Magic.Menus.MenuCommand("&Same Width",XGridImage.SameWidth, new EventHandler(OnSameWidth)));

			// Hook up events
			iSvc.SelectionChanged += new EventHandler(OnSelectionChanged);
			iComp.ComponentRemoving += new ComponentEventHandler(OnComponentRemoving);
			iComp.ComponentChanged += new ComponentChangedEventHandler(OnComponentChanged);
			iComp.ComponentAdding  += new ComponentEventHandler(OnComponentAdding);

			this.EnableDragDrop(true);
			
			//grid Event Hook up
			gridOldAllowDrop = grid.AllowDrop;
			grid.AllowDrop = true;
			grid.MouseDown += new MouseEventHandler(OnGridMouseDown);
			grid.MouseMove += new MouseEventHandler(OnGridMouseMove);
			grid.MouseUp   += new MouseEventHandler(OnGridMouseUp);
			grid.DragEnter += new DragEventHandler(OnGridDragEnter);
			grid.DragDrop  += new DragEventHandler(OnGridDragDrop);
			grid.GiveFeedback +=new GiveFeedbackEventHandler(OnGiveFeedBack);
		}
		
		private void OnGiveFeedBack(object sender, GiveFeedbackEventArgs e)
		{
			e.UseDefaultCursors = false;
			// Drag시에 Cursor 바꿈
			if ((e.Effect & DragDropEffects.Move) == DragDropEffects.Move)
			{
				Cursor.Current = XGridImage.DragCursor;
			}
		}

		private void OnGridMouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			// 정상상태에서 MouseMove시에
			if ((grid.GridStatus == XGridStatus.Normal) && (e.Button == MouseButtons.Left) && canDrag && (Math.Abs(e.X - dragX) > 3 || Math.Abs(e.Y - dragY) > 3))
			{
				canDrag = false;
				grid.DoDragDrop(mouseDownCell, DragDropEffects.Move);
			}
		}

		private void OnGridMouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if ((e.Button == MouseButtons.Right) && (grid.Selection.Count > 0))
			{
				popupMenu.MenuCommands[2].Enabled = (grid.Selection.Count > 1);
				popupMenu.TrackPopup(grid.PointToScreen(new Point(e.X,e.Y)));
			}
		}

		private void OnGridMouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			// AllowDrop시 DoDragDrop
			if (e.Button == MouseButtons.Left && grid.GridStatus == XGridStatus.Normal)
			{
				mouseDownCell = grid.CellAtPoint(new Point(e.X,e.Y));
				//RowHeader는 Drag할 수 없음
				if ((mouseDownCell != null) && (mouseDownCell.Personality != XCellPersonality.RowHeader))
				{
					canDrag = true;
					dragX = e.X;
					dragY = e.Y;
				}
			}
		}
		private void OnGridDragEnter(object sender, System.Windows.Forms.DragEventArgs e)
		{
			if (e.Data.GetDataPresent(typeof(IHIS.Framework.XColHeaderCell))
				||e.Data.GetDataPresent(typeof(IHIS.Framework.XComputedCell)))
			{
				e.Effect = DragDropEffects.Move;
			}
		}
		private void OnGridDragDrop(object sender, System.Windows.Forms.DragEventArgs e)
		{
			Point pt = grid.PointToClient(new Point(e.X, e.Y));
			XCell dropCell = grid.CellAtPoint(pt);
			XCell dragCell = null;
			if (e.Data.GetDataPresent(typeof(IHIS.Framework.XColHeaderCell)))
				dragCell = (XCell) e.Data.GetData(typeof(IHIS.Framework.XColHeaderCell));
			else if (e.Data.GetDataPresent(typeof(IHIS.Framework.XComputedCell)))
				dragCell = (XCell) e.Data.GetData(typeof(IHIS.Framework.XComputedCell));
			
			if (dragCell == null) return;

			int dragRow = dragCell.Row;
			int dragCol = dragCell.Col;
			int dragRowSpan = dragCell.RowSpan;
			int dragColSpan = dragCell.ColSpan;
			int dropRow = 0;
			int dropCol = 0;
			int dropRowSpan = 1;
			int dropColSpan = 1;
			int dragColWidth = grid.CellColInfo[dragCol].Width;
			int dropColWidth = 0;
			string dragCellName ="", dropCellName = "";
			int headerLines = grid.AddedHeaderLine + grid.LinePerRow;
			int computedDragRow = 0, computedDropRow = 0;
			int bfLinesPerRow = grid.GetLinesPerRow();
			XGridCell dragInfo = null, dropInfo = null;
			XGridHeader dragHInfo = null, dropHInfo = null;
			XGridComputedCell dragCInfo = null, dropCInfo = null;
			
			// DragDrop Valid Check
			if (dragCell.Personality == XCellPersonality.ColHeader)
			{
				if (dropCell != null)
				{
					//Row,Col이 같으면 Return
					if ((dragRow == dropCell.Row) && (dragCol == dropCell.Col)) return;

					if (dropCell.Personality == XCellPersonality.ColHeader)
					{
						// 추가된 Header는 추가된 Header영역에서만 DragDrop 가능
						if (dragCell.IsAddedHeader && (dropCell.Row + dropCell.RowSpan > grid.AddedHeaderLine))
						{
							MessageBox.Show("추가된 Header는 추가 Header영역내에서만 DragDrop가능합니다.");
							return;
						}
						if (dropCell.IsAddedHeader && (dragCell.Row + dragCell.RowSpan > grid.AddedHeaderLine))
						{
							MessageBox.Show("추가된 Header는 추가 Header영역내에서만 DragDrop가능합니다.");
							return;
						}

						//Row의 위치만 다르면 바꾸기, Col의 위치가 다르면 바꾸기와 위치이동 선택하게
						DialogResult result = DialogResult.Yes;
						if (dragCell.Col != dropCell.Col)
						{
							//바꾸기(두 Cell의 위치 바꿈), 위치이동(DragCell을 DropCell 앞으로 이동)
							result = MessageBox.Show("Drag하는 컬럼과 Drop하는 컬럼의 위치을 바꾸시겠습니까?\n\n" + 
								"Drag하는 컬럼을 Drop하는 컬럼의 앞으로 이동하시겠습니까?\n" + 
								"(컬럼의 앞으로 이동시에 같은 열에 있는 모든 컬럼이 이동됩니다.)\n\n" +
								"예를 선택하면 자리 바꾸기, 아니오를 선택하면 컬럼의 앞으로 이동" , "컬럼위치이동", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
						}
						if (result == DialogResult.Cancel) return;

						if (result == DialogResult.Yes)  //두 위치 바꾸기
						{
							dropRow = dropCell.Row;
							dropCol = dropCell.Col;
							dropRowSpan = dropCell.RowSpan;
							dropColSpan = dropCell.ColSpan;
							dropColWidth = grid.CellColInfo[dropCol].Width;
							grid[dragRow,dragCol] = null;
							grid[dropRow,dropCol] = null;
							grid[dragRow,dragCol] = dropCell;
							grid[dragRow,dragCol].RowSpan = dragRowSpan;
							grid[dragRow,dragCol].ColSpan = dragColSpan;
							grid[dropRow,dropCol] = dragCell;
							grid[dropRow,dropCol].RowSpan = dropRowSpan;
							grid[dropRow,dropCol].ColSpan = dropColSpan;
							grid.Invalidate(true);
				
							if (dragCell.IsAddedHeader && dropCell.IsAddedHeader)
							{
								dragHInfo = grid.HeaderInfos[dragRow,dragCol];
								dropHInfo = grid.HeaderInfos[dropRow,dropCol];
							}
							else if (dragCell.IsAddedHeader && !dropCell.IsAddedHeader)
							{
								dragHInfo = grid.HeaderInfos[dragRow,dragCol];
								dropInfo  = grid.CellInfos[dropCell.CellName];
							}
							else if (!dragCell.IsAddedHeader && dropCell.IsAddedHeader)
							{
								dragInfo  = grid.CellInfos[dragCell.CellName];
								dropHInfo = grid.HeaderInfos[dropRow,dropCol];
							}
							else
							{
								dragInfo  = grid.CellInfos[dragCell.CellName];
								dropInfo  = grid.CellInfos[dropCell.CellName];
							}
				
							iComp.OnComponentChanging(grid, null);

							if (dragInfo != null)
							{
								dragInfo.Row = dropRow;
								dragInfo.Col = dropCol;
								dragInfo.RowSpan = dropRowSpan;
								dragInfo.ColSpan = dropColSpan;
//								dragInfo.CellWidth = dropColWidth;
							}
							if (dropInfo != null)
							{
								dropInfo.Row = dragRow;
								dropInfo.Col = dragCol;
								dropInfo.RowSpan = dragRowSpan;
								dropInfo.ColSpan = dragColSpan;
//								dropInfo.CellWidth = dragColWidth;
							}
							if (dragHInfo != null)
							{
								dragHInfo.Row = dropRow;
								dragHInfo.Col = dropCol;
								dragHInfo.RowSpan = dropRowSpan;
								dragHInfo.ColSpan = dropColSpan;
//								dragHInfo.HeaderWidth = dropColWidth;
							}
							if (dropHInfo != null)
							{
								dropHInfo.Row = dragRow;
								dropHInfo.Col = dragCol;
								dropHInfo.RowSpan = dragRowSpan;
								dropHInfo.ColSpan = dragColSpan;
//								dropHInfo.HeaderWidth = dragColWidth;
							}
							//2005.09.06 DragDrop시에 컬럼의 너비는 변경하지 않고 원래크기 그대로 유지
							//DragColWidth와 DropColWidth를 변경하는 Logic은 제거하고
							//DragCol의 Grid의 Width를 DropColWidth로, DropCol의 Grid의 Width를 DragColWidth로 변경
							grid.SetColWidth(dropCol, dragColWidth);
							grid.SetColWidth(dragCol, dropColWidth);

							iComp.OnComponentChanged(grid, null, null, null);	
						}
						else //Drag하는 Cell의 위치를 DropCell앞으로 이동
						{
							//DragCell이 DropCell의 바로 앞의 Cell이면 위치이동해도 의미없음
							if (dragCell.Col == dropCell.Col - 1) return;
							//위치이동 가능여부 Check
							if (!CanMovePosition(dragCell, dropCell)) return;

//							//변경전 모양의 ColWidth 저장
//							Hashtable colWidthList = new Hashtable();
//							for(int i = 0 ; i < grid.CellColInfo.Count ; i++)
//								colWidthList.Add(i.ToString(), grid.CellColInfo[i].Width);

							//위치이동 불가 조건 1.ColSpan된 Cell은 위치이동 불가
							//2.dragCell의 위,아래에 ColSpan된 Cell이 있으면 불가
							//위치이동시에 같은 Col에 있는 모든 컬럼,추가Header, Computed컬럼 이동
							/*앞으로 이동시와 뒤로 이동시 구분하여 처리
							 * 앞으로 이동시 : dropCol > Col 은 그대로, dropCol <= Col < dragCol 은 Col + 1, dragCol은 dropCol로 변경
							 * 뒤로이동시    : dragCol > Col 은 그대로, dragCol < Col < dropCol 은 Col - 1, dragCol은 dropCol - 1로 변경
							*/
							dropCol = dropCell.Col;
							XCell cell = null;
							this.dragDropList.Clear();
							this.groupNameList.Clear();
							if (dragCol > dropCol) //앞으로 이동
							{
								for (int i = 0 ; i < grid.Rows ; i++)
								{
									for (int j = 0 ; j < grid.Cols ; j++)
									{
										cell = grid[i,j];
										if (cell != null)
										{
											if ((dropCol <= j) && (j < dragCol))
											{
												//성공시에 Grid[i,j] = null
												if (this.AddToDragDropList(cell, j + 1))
													grid[i,j] = null;
											}
											else if (j == dragCol)  //DragCol은 DropCol로 변경
											{
												if (this.AddToDragDropList(cell, dropCol))
													grid[i,j] = null;
											}
										}
									}
								}
							}
							else //뒤로 이동
							{
								for (int i = 0 ; i < grid.Rows ; i++)
								{
									for (int j = 0 ; j < grid.Cols ; j++)
									{
										cell = grid[i,j];
										if (cell != null)
										{
											if ((dragCol < j) && (j < dropCol))
											{
												if (this.AddToDragDropList(cell, j - 1))
													grid[i,j] = null;
											}
											else if (j == dragCol)  //DragCol은 DropCol - 1로 변경
											{
												if (this.AddToDragDropList(cell, dropCol - 1))
													grid[i,j] = null;
											}
										}
									}
								}
							}
							iComp.OnComponentChanging(grid, null);
							//위치조정처리
							foreach (DragDropInfo info in this.dragDropList)
							{
								grid[info.Row, info.Col] = info.Cell;
								if (info.InfoObj is XGridCell)
								{
									((XGridCell) info.InfoObj).Col = info.Col;
									//CellWidth 조정 (2005.09.06 CellWidth는 원래값을 반영함)
//									((XGridCell) info.InfoObj).CellWidth = info.Cell.AbsoluteRectangle.Width;
								}
								else if (info.InfoObj is XGridHeader)
									((XGridHeader) info.InfoObj).Col = info.Col;
								else if (info.InfoObj is XGridComputedCell)
									((XGridComputedCell) info.InfoObj).Col = info.Col;
							}
							//Group이나 Footer에 Cell이 없으면 GroupBandCell ,FooterCell Set
							//이동후에 Cell이 null로 변한 GroupBand, Footer를 채움
							int startCol = (grid.RowHeaderVisible ? 1 : 0); //RowHeader가 있으면 1부터 시작
							string groupName = "";
							for (int i = grid.AddedHeaderLine + grid.LinePerRow ; i < grid.Rows ; i++)
							{
								if (this.groupNameList.Contains(i.ToString())) //List에 있으면
								{
									groupName = this.groupNameList[i.ToString()].ToString();
									for (int j = startCol ; j < grid.Cols ; j++)
									{
										if (grid[i,j] == null)
										{
											if (groupName == XGridUtility.FooterGroupName)
												grid[i,j] = new XFooterCell(groupName, groupName);
											else
												grid[i,j] = new XGroupBandCell(groupName, groupName);
										}
									}
								}
							}

							//2005.09.06 Grid의 Cell Width를 XGridCell의 CellWidth로 변경
							//앞,뒤로 이동후에도 기 지정된 CellWidth가 반영되도록 함
							foreach (XGridCell info in grid.CellInfos)
							{
								if (info.Col >= 0 && info.Col < grid.Cols)
									grid.SetColWidth(info.Col, info.CellWidth);
							}
							// 변경전
							iComp.OnComponentChanged(grid, null, null, null);
							grid.Invalidate(true);
						}

					}
					//DragCell이 XGridCell의 Header를 GroupBand, Footer로 Drop시에는 Computed컬럼 Add
					else if (!dragCell.IsAddedHeader && ((dropCell.Personality == XCellPersonality.GroupBand)||(dropCell.Personality == XCellPersonality.Footer)))
					{
						string groupName = dropCell.CellName;
						string expression = "Sum(" + dragCell.CellName + ")";  //Expression은 Default Count로 SET
						XGridComputedExpressionEditorForm dlg = new XGridComputedExpressionEditorForm(false, grid.CellInfos, grid.GroupInfos, groupName, expression);
						if (dlg.ShowDialog() == DialogResult.OK)
						{
							CreateComputedColumn(dlg, dropCell.Row, dropCell.Col);  //XGridComputedCell, ComputedCell 생성
						}
					}
				}
				else
				{
					// Empty영역의 Row, Col정보 Find (찾기불가이면 Return;
					if(!FindEmptyCellRowAndCol(pt, out dropRow, out dropCol)) return;
					
					// dragCell이 추가된 Header일때 dropRow은 추가Header위치를 벗어날 수 없음
					if (dragCell.IsAddedHeader && (dropRow >= grid.AddedHeaderLine))
					{
						MessageBox.Show("추가된 Header는 추가 Header영역내에서만 DragDrop가능합니다.");
						return;
					}

					//ColHeader는 Header영역에서만 DragDrop가능
					if ((dropRow >= headerLines) || (dropCol >= grid.Cols))
					{
						MessageBox.Show("컬럼Header는 컬럼Header영역으로만 DragDrop가능합니다.");
						return;
					}

					dropColWidth = grid.CellColInfo[dropCol].Width;
					grid[dragRow,dragCol] = null;
					grid[dropRow,dropCol] = null;
					grid[dropRow,dropCol] = dragCell;
					grid[dropRow,dropCol].RowSpan = dropRowSpan;
					grid[dropRow,dropCol].ColSpan = dropColSpan;
					grid.Invalidate(true);
					//Component Change
					dragInfo = grid.CellInfos[dragCell.CellName];
					bool founded = false;
					if (dragInfo != null)
					{
						iComp.OnComponentChanging(grid, null);
						dragInfo.Row = dropRow;
						dragInfo.Col = dropCol;
						dragInfo.RowSpan = dropRowSpan;
						dragInfo.ColSpan = dropColSpan;
						dragInfo.CellWidth = dropColWidth;
						iComp.OnComponentChanged(grid, null, null, null);
						founded = true;
					}
					if (!founded)
					{
						// 추가 Header를 DragDrop시
						dragHInfo = grid.HeaderInfos[dragRow, dragCol];
						if (dragHInfo != null)
						{
							iComp.OnComponentChanging(grid, null);
							dragHInfo.Row = dropRow;
							dragHInfo.Col = dropCol;
							dragHInfo.RowSpan = dropRowSpan;
							dragHInfo.ColSpan = dropColSpan;
							dragHInfo.HeaderWidth = dropColWidth;
							iComp.OnComponentChanged(grid, null, null, null);
						}
					}
				}
				//DragDrop에 의해 한 Row의 Line수가 변경이 되면 GroupBand, Footer도 변경해야함
				this.ChangeGroupBandAndFooterAtRowChanging(bfLinesPerRow);
			}
			else if (dragCell.Personality == XCellPersonality.Compute)
			{
				computedDragRow = this.GetRowByGroupName(dragCell.CellName, true, 0);

				if (dropCell != null)
				{
					//Row,Col이 같으면 Return
					if ((dragRow == dropCell.Row) && (dragCol == dropCell.Col)) return;
					// Compute는 Compute, GroupBand, Footer와만 DragDrop 가능
					if ((dropCell.Personality != XCellPersonality.Compute) &&
						(dropCell.Personality != XCellPersonality.GroupBand) &&
						(dropCell.Personality != XCellPersonality.Footer))
					{
						MessageBox.Show("Computed컬럼은 컬럼Header와 DragDrop할 수 없습니다.");
						return;
					}
					
					computedDropRow = this.GetRowByGroupName(dropCell.CellName, true, 0);
					dragCellName = dragCell.CellName;
					dropCellName = dropCell.CellName;

					if (dropCell.Personality == XCellPersonality.Compute)
					{

						//Row의 위치만 다르면 바꾸기, Col의 위치가 다르면 바꾸기와 위치이동 선택하게
						DialogResult result = DialogResult.Yes;
						if (dragCell.Col != dropCell.Col)
						{
							//바꾸기(두 Cell의 위치 바꿈), 위치이동(DragCell을 DropCell 앞으로 이동)
							result = MessageBox.Show("Drag하는 컬럼과 Drop하는 컬럼의 위치을 바꾸시겠습니까?\n\n" + 
								"Drag하는 컬럼을 Drop하는 컬럼의 앞으로 이동하시겠습니까?\n" + 
								"(컬럼의 앞으로 이동시에 같은 열에 있는 모든 컬럼이 이동됩니다.)\n\n" +
								"예를 선택하면 자리 바꾸기, 아니오를 선택하면 컬럼의 앞으로 이동" , "컬럼위치이동", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
						}
						if (result == DialogResult.Cancel) return;

						if (result == DialogResult.Yes) //자리바꿈
						{
							//Cell 서로 바꿈
							dropRow = dropCell.Row;
							dropCol = dropCell.Col;
							dropRowSpan = dropCell.RowSpan;
							dropColSpan = dropCell.ColSpan;
							grid[dragRow,dragCol] = null;
							grid[dropRow,dropCol] = null;
							grid[dragRow,dragCol] = dropCell;
							grid[dragRow,dragCol].CellName = dragCellName; //Group Name 변경
							grid[dragRow,dragCol].RowSpan = dragRowSpan;
							grid[dragRow,dragCol].ColSpan = dragColSpan;
							grid[dropRow,dropCol] = dragCell;
							grid[dropRow,dropCol].CellName = dropCellName;
							grid[dropRow,dropCol].RowSpan = dropRowSpan;
							grid[dropRow,dropCol].ColSpan = dropColSpan;
							grid.Invalidate(true);

							//Cell의 Tag에 XGridComputedCell의 식별자인 Identifier저장된 
							dragCInfo = grid.ComputedCellInfos[dragCell.Tag];
							dropCInfo = grid.ComputedCellInfos[dropCell.Tag];
				
							iComp.OnComponentChanging(grid, null);

							if (dragCInfo != null)
							{
								dragCInfo.GroupName = dropCellName;//GroupName 변경
								dragCInfo.Row = dropRow - computedDropRow;
								dragCInfo.Col = dropCol;
								dragCInfo.RowSpan = dropRowSpan;
								dragCInfo.ColSpan = dropColSpan;
							}
							if (dropCInfo != null)
							{
								dropCInfo.GroupName = dragCellName;  //GroupName 변경
								dropCInfo.Row = dragRow - computedDragRow;
								dropCInfo.Col = dragCol;
								dropCInfo.RowSpan = dragRowSpan;
								dropCInfo.ColSpan = dragColSpan;
							}
							iComp.OnComponentChanged(grid, null, null, null);
						}
						else //컬럼 앞으로 이동
						{
							//DragCell이 DropCell의 바로 앞의 Cell이면 위치이동해도 의미없음
							if (dragCell.Col == dropCell.Col - 1) return;
							//위치이동 가능여부 Check
							if (!CanMovePosition(dragCell, dropCell)) return;
							//위치이동 불가 조건 1.ColSpan된 Cell은 위치이동 불가
							//2.dragCell의 위,아래에 ColSpan된 Cell이 있으면 불가
							//위치이동시에 같은 Col에 있는 모든 컬럼,추가Header, Computed컬럼 이동
							/*앞으로 이동시와 뒤로 이동시 구분하여 처리
							 * 앞으로 이동시 : dropCol > Col 은 그대로, dropCol <= Col < dragCol 은 Col + 1, dragCol은 dropCol로 변경
							 * 뒤로이동시    : dragCol > Col 은 그대로, dragCol < Col < dropCol 은 Col - 1, dragCol은 dropCol - 1로 변경
							*/
							dropCol = dropCell.Col;
							XCell cell = null;
							this.dragDropList.Clear();
							this.groupNameList.Clear();
							if (dragCol > dropCol) //앞으로 이동
							{
								for (int i = 0 ; i < grid.Rows ; i++)
								{
									for (int j = 0 ; j < grid.Cols ; j++)
									{
										cell = grid[i,j];
										if (cell != null)
										{
											if ((dropCol <= j) && (j < dragCol))
											{
												//성공시에 Grid[i,j] = null
												if (this.AddToDragDropList(cell, j + 1))
													grid[i,j] = null;
											}
											else if (j == dragCol)  //DragCol은 DropCol로 변경
											{
												if (this.AddToDragDropList(cell, dropCol))
													grid[i,j] = null;
											}
										}
									}
								}
							}
							else //뒤로 이동
							{
								for (int i = 0 ; i < grid.Rows ; i++)
								{
									for (int j = 0 ; j < grid.Cols ; j++)
									{
										cell = grid[i,j];
										if (cell != null)
										{
											if ((dragCol < j) && (j < dropCol))
											{
												if (this.AddToDragDropList(cell, j - 1))
													grid[i,j] = null;
											}
											else if (j == dragCol)  //DragCol은 DropCol - 1로 변경
											{
												if (this.AddToDragDropList(cell, dropCol - 1))
													grid[i,j] = null;
											}
										}
									}
								}
							}
							iComp.OnComponentChanging(grid, null);
							//위치조정처리
							foreach (DragDropInfo info in this.dragDropList)
							{
								grid[info.Row, info.Col] = info.Cell;
								if (info.InfoObj is XGridCell)
								{
									((XGridCell) info.InfoObj).Col = info.Col;
									//CellWidth 조정
									((XGridCell) info.InfoObj).CellWidth = info.Cell.AbsoluteRectangle.Width;
								}
								else if (info.InfoObj is XGridHeader)
									((XGridHeader) info.InfoObj).Col = info.Col;
								else if (info.InfoObj is XGridComputedCell)
									((XGridComputedCell) info.InfoObj).Col = info.Col;
							}
							//Group이나 Footer에 Cell이 없으면 GroupBandCell ,FooterCell Set
							//이동후에 Cell이 null로 변한 GroupBand, Footer를 채움
							int startCol = (grid.RowHeaderVisible ? 1 : 0); //RowHeader가 있으면 1부터 시작
							string groupName = "";
							for (int i = grid.AddedHeaderLine + grid.LinePerRow ; i < grid.Rows ; i++)
							{
								if (this.groupNameList.Contains(i.ToString())) //List에 있으면
								{
									groupName = this.groupNameList[i.ToString()].ToString();
									for (int j = startCol ; j < grid.Cols ; j++)
									{
										if (grid[i,j] == null)
										{
											if (groupName == XGridUtility.FooterGroupName)
												grid[i,j] = new XFooterCell(groupName, groupName);
											else
												grid[i,j] = new XGroupBandCell(groupName, groupName);
										}
									}
								}
							}
							iComp.OnComponentChanged(grid, null, null, null);
							grid.Invalidate(true);
						}
					}
					//GroupBand Or Footer와 DragDrop시에 
					else
					{
						//Drag하는 Computed컬럼은 dropRowSpan,dropColSpan으로 변경
						//Drop되는 GroupBand,Footer는 rowSpan, colSpan 1로 SET
						dropRow = dropCell.Row;
						dropCol = dropCell.Col;
						dropRowSpan = dropCell.RowSpan;
						dropColSpan = dropCell.ColSpan;
						grid[dragRow,dragCol] = null;
						grid[dropRow,dropCol] = null;
						//GroupBand, Footer
						if (dragCellName == XGridUtility.FooterGroupName)
							grid[dragRow,dragCol] = new XFooterCell(XGridUtility.FooterGroupName, XGridUtility.FooterName);
						else
							grid[dragRow,dragCol] = new XGroupBandCell(dragCell.CellName, dragCell.CellName);

						// 빈영역은 GroupBand, Footer로 SET
						if (dragRowSpan > 1)
						{
							for (int i = dragRow + 1 ; i < dragRow + dragRowSpan ; i++)
								if (dragCellName == XGridUtility.FooterGroupName) //Footer
									grid[i,dragCol] = new XFooterCell(XGridUtility.FooterGroupName,XGridUtility.FooterName);
								else // GroupBand
									grid[i,dragCol] = new XGroupBandCell(dragCell.CellName, dragCell.CellName);
						}
						if (dragColSpan > 1)
						{
							for (int i = dragCol + 1 ; i < dragCol + dragColSpan ; i++)
								if (dragCellName == XGridUtility.FooterGroupName) //Footer
									grid[dragRow,i] = new XFooterCell(XGridUtility.FooterGroupName,XGridUtility.FooterName);
								else // GroupBand
									grid[dragRow,i] = new XGroupBandCell(dragCell.CellName, dragCell.CellName);
						}

						//Computed컬럼
						grid[dropRow,dropCol] = dragCell;
						grid[dropRow,dropCol].CellName = dropCellName;
						grid[dropRow,dropCol].RowSpan = dropRowSpan;
						grid[dropRow,dropCol].ColSpan = dropColSpan;
						grid.Invalidate(true);

						dragCInfo = grid.ComputedCellInfos[dragCell.Tag];
						if (dragCInfo != null)
						{
							iComp.OnComponentChanging(grid, null);
							dragCInfo.GroupName = dropCellName;
							dragCInfo.Row = dropRow - computedDropRow;
							dragCInfo.Col = dropCol;
							dragCInfo.RowSpan = dropRowSpan;
							dragCInfo.ColSpan = dropColSpan;
							iComp.OnComponentChanged(grid, null, null, null);
						}
					}
				}
			}
		}

		private bool AddToDragDropList(XCell cell, int col)
		{
			if (cell.Personality == XCellPersonality.ColHeader)
			{
				if (cell.IsAddedHeader) //추가Header
				{
					dragDropList.Add(new DragDropInfo(cell.Row, col, cell, grid.HeaderInfos[cell.Row,cell.Col]));
				}
				else //컬럼
				{
					dragDropList.Add(new DragDropInfo(cell.Row, col, cell, grid.CellInfos[cell.Row,cell.Col]));
				}
				return true;
			}
			else if (cell.Personality == XCellPersonality.Compute)
			{
				//CellName에 저장된 GroupName과 Col로 AGridComputedCell Set
				dragDropList.Add(new DragDropInfo(cell.Row, col, cell, grid.ComputedCellInfos[cell.CellName,cell.Col]));
				//GroupName List에 Row를 Key로 하여 GroupName 저장 (CellName에 GroupName 관리함. Group1, Footer
				if (!groupNameList.Contains(cell.Row.ToString()))
					groupNameList.Add(cell.Row.ToString(), cell.CellName);
				return true;
			}
			return false;
		}
		
		private bool CanMovePosition(XCell dragCell, XCell dropCell)
		{
			//위치이동이 가능한지 여부
			//위치이동 불가 조건 1.ColSpan된 Cell은 위치이동 불가
			//2.dragCell의 위,아래에 ColSpan된 Cell이 있으면 불가
			//3.dropCell의 위,아래에 ColSpan된 Cell이 있으면 불가
			if (dragCell.ColSpan > 1)
			{
				MessageBox.Show("ColPadding된 컬럼은 위치이동 불가합니다.[ColPadding해제]");
				return false;
			}
			if (dropCell.ColSpan > 1)
			{
				MessageBox.Show("Drop위치에 있는 컬럼이 ColPadding되어있어 위치이동 불가합니다.[ColPadding해제]");
				return false;
			}
			XCell cell = null;
			for (int i = 0 ; i < grid.Rows ; i++)
			{
				for (int j = 0 ; j < grid.Cols ; j++)
				{
					cell = grid[i,j];
					if ((cell != null) &&((cell.Personality == XCellPersonality.ColHeader)||(cell.Personality == XCellPersonality.Compute)))
					{
						//DragCell의 위치확인
						if ((cell.Col != dragCell.Col) || (cell.Row != dragCell.Row))
						{
							if (((cell.Col < dragCell.Col) && (cell.Col + cell.ColSpan >= dragCell.Col + dragCell.ColSpan))
								||((cell.Col == dragCell.Col) && (cell.Col + cell.ColSpan > dragCell.Col + dragCell.ColSpan)))
							{
								MessageBox.Show("Drag하는 컬럼의 위,아래의 컬럼이 ColPadding되어 있어 위치이동 불가합니다.\n\n" +
									"위,아래 Cell의 ColPadding을 해제후에 위치이동하십시오");
								return false;
							}
						}
						//DropCell의 위치확인
						if ((cell.Col != dropCell.Col) || (cell.Row != dropCell.Row))
						{
							if (((cell.Col < dropCell.Col) && (cell.Col + cell.ColSpan >= dropCell.Col + dropCell.ColSpan))
								||((cell.Col == dropCell.Col) && (cell.Col + cell.ColSpan > dropCell.Col + dropCell.ColSpan)))
							{
								MessageBox.Show("Drop위치에 있는 컬럼의 위,아래의 컬럼이 ColPadding되어 있어 위치이동 불가합니다.\n\n" +
									"위,아래 Cell의 ColPadding을 해제후에 위치이동하십시오");
								return false;
							}
						}

						//Computed Cell이 RowPadding되어 있으면 불가
						if ((cell.Personality == XCellPersonality.Compute) && (cell.RowSpan > 1))
						{
							MessageBox.Show("Computed컬럼이 RowPadding되어 있으면 위치이동 불가합니다..\n\n" +
								"Computed컬럼의 RowPadding을 해제하십시오.");
							return false;
						}
					}
				}
			}
			return true;
		}

		private void OnSelectionChanged(object sender, System.EventArgs e)
		{
			bool  isSelected = false;
			
			// XGridCell가 선택되었는지 확인
			foreach (XGridCell info in grid.CellInfos)
			{
				if (iSvc.GetComponentSelected(info))
				{
					isSelected = true;
					break;
				}
			}
			//XGridHeader 선택여부 확인
			if (!isSelected)
			{
				foreach (XGridHeader info in grid.HeaderInfos)
				{
					if (iSvc.GetComponentSelected(info))
					{
						isSelected = true;
						break;
					}
				}
			}
			//XGridComputedCell 선택여부 확인
			if (!isSelected)
			{
				foreach (XGridComputedCell info in grid.ComputedCellInfos)
				{
					if (iSvc.GetComponentSelected(info))
					{
						isSelected = true;
						break;
					}
				}
			}

			// 선택되지 않았으면, Grid의 CellSelection 모두 Clear
			if (!isSelected)
				grid.Selection.Clear();
			
			//grid에 Attach된 XGridComputedCell의 Designer에 CellInfos 속성 SET
			//XGridComputedCellDesigner에 Grid SET
			foreach (XGridComputedCell info in grid.ComputedCellInfos)
			{
				((XGridComputedCellDesigner) iHost.GetDesigner(info)).CellInfos = grid.CellInfos;
			}
		}

		private void OnComponentChanged(object sender, ComponentChangedEventArgs e)
		{
			int width = 0;
			// XGridCell가 변경되는 경우
			if (e.Component is XGridCell)
			{
				// Control삭제시 OnComponentChanged 발생, 이때 e.Member가 null이므로
				// e.Member Check 해야함
				if (e.Member != null)
				{
					XGridCell cellInfo = (XGridCell) e.Component;
					if (grid.CellInfos.Contains(cellInfo))
					{
						switch (e.Member.Name)
						{
							case "CellName":
								// CellName은 "", 다른 컬럼명과 동일할 수 없음
								if (e.NewValue.ToString() == "")
								{
									cellInfo.CellName = e.OldValue.ToString();
									return;
								}
								else
								{
									foreach (XGridCell info in grid.CellInfos)
										// cellInfo 객체가 아닌 다른 컬럼정보의 CellName과 동일할 수 없음
										if (!info.Equals(cellInfo) && (info.CellName == e.NewValue.ToString()))
										{
											cellInfo.CellName = e.OldValue.ToString();
											return;
										}
								}
								bool groupChanged = grid.ModifyOtherColumnInfos(grid.CellInfos);
								if (groupChanged)
									grid.InitializeColumns();  //Group정보가 바뀌었으면 다시 초기화
								break;
							case "HeaderText":
								grid[cellInfo.Row, cellInfo.Col].Value = e.NewValue;
								break;
							case "HeaderTextAlign":
								grid[cellInfo.Row, cellInfo.Col].TextAlignment = cellInfo.HeaderTextAlign;
								break;
							case "CellWidth":
								width = Int32.Parse(e.NewValue.ToString());
								grid.SetColWidth(cellInfo.Col, width);
								// 동일한 YPos위치에 있는 다른 컬럼정보의 Width도 변경
								foreach (XGridHeader info in grid.HeaderInfos)
									if (info.Col == cellInfo.Col)
										info.HeaderWidth = width;
								foreach (XGridCell info in grid.CellInfos)
									if (info.Col == cellInfo.Col)
										info.CellWidth = width;
								break;
							case "ImageList":
								grid[cellInfo.Row, cellInfo.Col].Image = cellInfo.HeaderImage;
								break;
							case "HeaderImageIndex":
								grid[cellInfo.Row, cellInfo.Col].Image = cellInfo.HeaderImage;
								break;
							case "HeaderImage":
								grid[cellInfo.Row, cellInfo.Col].Image = cellInfo.HeaderImage;
								break;
							case "HeaderImageAlign":
								grid[cellInfo.Row, cellInfo.Col].ImageAlignment = cellInfo.HeaderImageAlign;
								break;
							case "HeaderImageStretch":
								grid[cellInfo.Row, cellInfo.Col].ImageStretch = cellInfo.HeaderImageStretch;
								break;
							case "HeaderFont":
								grid[cellInfo.Row, cellInfo.Col].Font = cellInfo.HeaderFont;
								break;
							case "HeaderDrawMode":
								grid[cellInfo.Row, cellInfo.Col].DrawMode = cellInfo.HeaderDrawMode;
								break;
							case "HeaderBackColor":
								grid[cellInfo.Row, cellInfo.Col].BackColor = cellInfo.HeaderBackColor;
								break;
							case "HeaderGradientStart":
								grid[cellInfo.Row, cellInfo.Col].GradientStart = cellInfo.HeaderGradientStart;
								break;
							case "HeaderGradientEnd":
								grid[cellInfo.Row, cellInfo.Col].GradientEnd = cellInfo.HeaderGradientEnd;
								break;
							case "HeaderForeColor":
								grid[cellInfo.Row, cellInfo.Col].ForeColor = cellInfo.HeaderForeColor;
								break;
							case "SelectedBackColor":
								grid[cellInfo.Row, cellInfo.Col].SelectedBackColor = cellInfo.SelectedBackColor;
								break;
							case "SelectedForeColor":
								grid[cellInfo.Row, cellInfo.Col].SelectedForeColor = cellInfo.SelectedForeColor;
								break;
							case "IsReadOnly":
								//ReadOnly를 false로 적용시 Check사항
								//그룹컬럼으로 지정된 컬럼은 ReadOnly 해제불가
								//Computed컬럼에 사용된 컬럼은 ReadOnly 해제 불가
								if (!((bool)e.NewValue))
								{
									//그룹컬럼정보에서 그룹리스트에 컬럼이 있으면
									foreach (XGridGroupInfo info in grid.GroupInfos)
									{
										if (info.ColumnList.Contains(cellInfo.CellName))
										{
											MessageBox.Show("그룹으로 지정된 컬럼은 ReadOnly해제 불가합니다.(그룹먼저 해제)");
											cellInfo.IsReadOnly = true;
											return;
										}
									}
									//Computed컬럼 Check
									foreach (XGridComputedCell info in grid.ComputedCellInfos)
									{
										if (info.ComputedKind != XGridComputedKind.Text)
										{
											if (info.Expression.IndexOf(cellInfo.CellName) >= 0)
											{
												MessageBox.Show("Computed컬럼에 사용된 컬럼은 ReadOnly해제 불가합니다.(Computed컬럼 먼저삭제)");
												cellInfo.IsReadOnly = true;
												return;
											}
										}
									}
								}
								break;
						}
					}
				}
			}
				// XGridHeader가 변경되는 경우
			else if (e.Component is XGridHeader)
			{
				// Control삭제시 OnComponentChanged 발생, 이때 e.Member가 null이므로
				// e.Member Check 해야함
				if (e.Member != null)
				{
					XGridHeader headerInfo = (XGridHeader) e.Component;
					if (grid.HeaderInfos.Contains(headerInfo))
					{
						switch (e.Member.Name)
						{
							case "HeaderText":
								grid[headerInfo.Row, headerInfo.Col].Value = e.NewValue;
								break;
							case "HeaderWidth":
								width = Int32.Parse(e.NewValue.ToString());
								grid.SetColWidth(headerInfo.Col, width);
								// 동일한 YPos위치에 있는 다른 컬럼정보의 Width도 변경
								foreach (XGridHeader info in grid.HeaderInfos)
									if (info.Col == headerInfo.Col)
										info.HeaderWidth = width;
								foreach (XGridCell info in grid.CellInfos)
									if (info.Col == headerInfo.Col)
										info.CellWidth = width;
								break;
							case "ImageList":
								grid[headerInfo.Row, headerInfo.Col].Image = headerInfo.HeaderImage;
								break;
							case "HeaderImageIndex":
								grid[headerInfo.Row, headerInfo.Col].Image = headerInfo.HeaderImage;
								break;
							case "HeaderImage":
								grid[headerInfo.Row, headerInfo.Col].Image = headerInfo.HeaderImage;
								break;
							case "HeaderImageAlign":
								grid[headerInfo.Row, headerInfo.Col].ImageAlignment = headerInfo.HeaderImageAlign;
								break;
							case "HeaderImageStretch":
								grid[headerInfo.Row, headerInfo.Col].ImageStretch = headerInfo.HeaderImageStretch;
								break;
							case "HeaderTextAlign":
								grid[headerInfo.Row, headerInfo.Col].TextAlignment = headerInfo.HeaderTextAlign;
								break;
							case "HeaderFont":
								grid[headerInfo.Row, headerInfo.Col].Font = headerInfo.HeaderFont;
								break;
							case "HeaderDrawMode":
								grid[headerInfo.Row, headerInfo.Col].DrawMode = headerInfo.HeaderDrawMode;
								break;
							case "HeaderBackColor":
								grid[headerInfo.Row, headerInfo.Col].BackColor = headerInfo.HeaderBackColor;
								break;
							case "HeaderGradientStart":
								grid[headerInfo.Row, headerInfo.Col].GradientStart = headerInfo.HeaderGradientStart;
								break;
							case "HeaderGradientEnd":
								grid[headerInfo.Row, headerInfo.Col].GradientEnd = headerInfo.HeaderGradientEnd;
								break;
							case "HeaderForeColor":
								grid[headerInfo.Row, headerInfo.Col].ForeColor = headerInfo.HeaderForeColor;
								break;
							case "SelectedBackColor":
								grid[headerInfo.Row, headerInfo.Col].SelectedBackColor = headerInfo.SelectedBackColor;
								break;
							case "SelectedForeColor":
								grid[headerInfo.Row, headerInfo.Col].SelectedForeColor = headerInfo.SelectedForeColor;
								break;
						}
					}
				}
			}
			else if (e.Component is XGridComputedCell)
			{
				// Control삭제시 OnComponentChanged 발생, 이때 e.Member가 null이므로
				// e.Member Check 해야함
				if (e.Member != null)
				{
					XGridComputedCell compInfo = (XGridComputedCell) e.Component;
					int row = this.GetRowByGroupName(compInfo.GroupName, true, compInfo.Row);
					if (grid.ComputedCellInfos.Contains(compInfo))
					{
						switch (e.Member.Name)
						{
							case "Expression":
								string errMsg = "";
								//Expression변경시 VerifyExpression
								if (!XGridUtility.VerifyExpression(grid.CellInfos, e.NewValue.ToString(), out errMsg))
								{
									MessageBox.Show(errMsg);
									compInfo.Expression = e.OldValue.ToString();
								}
								//ComputedKind SET 
								compInfo.ComputedKind = XGridUtility.GetXGridComputedKindByExpression(compInfo.Expression);
								grid[row, compInfo.Col].Value = compInfo.Expression;
								break;
							case "ImageList":
								grid[row, compInfo.Col].Image = compInfo.Image;
								break;
							case "ImageIndex":
								grid[row, compInfo.Col].Image = compInfo.Image;
								break;
							case "Image":
								grid[row, compInfo.Col].Image = compInfo.Image;
								break;
							case "ImageAlign":
								grid[row, compInfo.Col].ImageAlignment = compInfo.ImageAlign;
								break;
							case "ImageStretch":
								grid[row, compInfo.Col].ImageStretch = compInfo.ImageStretch;
								break;
							case "TextAlignment":
								grid[row, compInfo.Col].TextAlignment = compInfo.TextAlignment;
								break;
							case "Font":
								grid[row, compInfo.Col].Font = compInfo.Font;
								break;
							case "DrawMode":
								grid[row, compInfo.Col].DrawMode = compInfo.DrawMode;
								break;
							case "BackColor":
								grid[row, compInfo.Col].BackColor = compInfo.BackColor;
								break;
							case "GradientStart":
								grid[row, compInfo.Col].GradientStart = compInfo.GradientStart;
								break;
							case "GradientEnd":
								grid[row, compInfo.Col].GradientEnd = compInfo.GradientEnd;
								break;
							case "TextColor":
								grid[row, compInfo.Col].ForeColor = compInfo.ForeColor;
								break;
							case "SelectedBackColor":
								grid[row, compInfo.Col].SelectedBackColor = compInfo.SelectedBackColor;
								break;
							case "SelectedForeColor":
								grid[row, compInfo.Col].SelectedForeColor = compInfo.SelectedForeColor;
								break;
						}
					}
				}
			}
			else if ((e.Component == grid))  //편집중인 Grid이면
			{
				//ReadOnly변경시(XGrid에서는 변경불가하나 CellGrid에서는 변경가능, Designer를 따로 만들지 않기 위해 처리함
				if (e.Member != null)
				{
					switch (e.Member.Name)
					{
						case "RowHeaderDrawMode":
							//RowHeaderVisible이면 RowHeader DrawMode 변경
							if (grid.RowHeaderVisible && (grid.Rows > 0))
								grid[0,0].DrawMode = (XCellDrawMode) e.NewValue;
							break;
					}
				}
			}
		}
		private bool FindEmptyCellRowAndCol(Point pt, out int row, out int col)
		{
			// 현재 좌표가 위치한 위치의 Row와 Col을 찾음
			row = -1;
			col = -1;
			//ScrollPositin 고려 절대좌표로 변환
			Point aPoint = new Point(pt.X - grid.GridScrollPosition.X, pt.Y - grid.GridScrollPosition.Y);
			for (int i = 0 ; i < grid.CellRowInfo.Count ; i++)
			{
				// 현재 Grid의 모양에서 Top ~ pt.Y ~ Top + height인 Row 찾기
				if ((aPoint.Y >= grid.CellRowInfo[i].Top) && ((grid.CellRowInfo[i].Top + grid.CellRowInfo[i].Height) > aPoint.Y))
				{
					row = i;
					break;
				}
			}
			for (int i = 0 ; i < grid.CellColInfo.Count ; i++)
			{
				// 현재 Grid의 모양에서 Left ~ pt.X ~ Left + Width 인 Col 찾기
				if ((aPoint.X >= grid.CellColInfo[i].Left) && ((grid.CellColInfo[i].Left + grid.CellColInfo[i].Width) > aPoint.X))
				{
					col = i;
					break;
				}
			}
			if ((row >= 0) && (col >= 0)) 
				return true;
			else
				return false;
		}

		private void ChangeOtherProperties(bool isAddedHeader, int row, int col, int bfLinesPerRow)
		{
			bool changeRow = true;
			bool changeCol = true;
			// 같은 row위치에 있는 cell이 한개도 없으면 col이후의 cell은 ColSpan 앞으로 이동
			// 같은 col위치에 있는 cell이 한개도 없으면 row이후의 cell은 RowSpan 앞으로 이동
			// 같은 Col위치에 ComputedCell, GroupBand, Footer가 있을 수 있으므로 이경우에도 changeCol가능
			for (int i = 0 ; i < grid.Rows ; i++)
			{
				// 같은 Col영역에 ColHeader가 있으면 Col변경하지 않음
				if ((grid[i,col] != null) && (grid[i,col].Personality == XCellPersonality.ColHeader))
				{
					changeCol = false;
					break;
				}
			}
			//RowHeaderVisible이면 startCol = 1부터 시작
			int startCol = 0;
			XCell rowHeader = null;
			if (grid.RowHeaderVisible) 
			{
				startCol = 1;
				rowHeader = grid[0,0];
			}
			for (int i = startCol ; i < grid.Cols ; i++)
			{
				if (grid[row,i] != null)
				{
					changeRow = false;
					break;
				}
			}

			// 변경 List에 추가 (삭제된 row, col, change여부)
			changeList.Add(row.ToString() + "," + col.ToString() + "," + changeRow.ToString() + "," + changeCol.ToString());

			if (!changeRow && !changeCol) return;

			// 그리기 멈춤
			grid.Redraw = false;

			if (changeRow)
			{
				//추가Header삭제시는 addedHeaderLine 변경, XGridCell 삭제시는 LinePerRow 변경
				if (isAddedHeader)
					grid.AddedHeaderLine = Math.Max(0, grid.AddedHeaderLine -1);
				else
					grid.LinePerRow = Math.Max(0, grid.LinePerRow -1);
				
				//FixedRows Set (한행의 Line수 + 추가 Line수)
				grid.FixedRows = grid.LinePerRow + grid.AddedHeaderLine;

				// 해당 Row Remove
				grid.RemoveRow(row, 1);
				//RowHeaderVisible이면 rowHeader 추가
				if (grid.RowHeaderVisible && (grid.Rows > 0))
				{
					grid[0,0] = rowHeader;
					grid[0,0].RowSpan = grid.Rows;
				}
				// row이후의 XGridCell 정보는 1만큼 위로이동
				foreach (XGridCell info in grid.CellInfos)
				{
					if (info.IsVisible)
					{
						// info.Row > row일때
						if (info.Row > row)
							info.Row -= 1;
						//Row + RowSpan이 headerRowCount보다 크면 Rows만큼만 Padding
						if ((info.Row >= 0) && (info.Row + info.RowSpan > grid.AddedHeaderLine + grid.LinePerRow))
						{
							info.RowSpan = Math.Max(1, grid.AddedHeaderLine + grid.LinePerRow - info.Row);
							grid[info.Row, info.Col].RowSpan = info.RowSpan;
						}
					}
				}
				// row이후의 XGridHeader 정보 위로 이동
				foreach (XGridHeader info in grid.HeaderInfos)
				{
					// info.Row > row일때
					if (info.Row > row)
						info.Row -= 1;
					//Row + RowSpan이 grid.AddedHeaderLine보다 크면 AddedHeaderLine만큼만 Padding
					if (info.Row + info.RowSpan > grid.AddedHeaderLine)
					{
						info.RowSpan = Math.Max(1, grid.AddedHeaderLine - info.Row);
						grid[info.Row, info.Col].RowSpan = info.RowSpan;
					}
				}

				//관련 Property 변경 (HeaderHeights, LinePerRow)
				grid.HeaderHeights.Clear();
				//for (int i = 0; i < grid.Rows ; i++)
				for (int i = 0; i < grid.AddedHeaderLine + grid.LinePerRow ; i++)
					grid.HeaderHeights.Add(grid.CellRowInfo[i].Height);
				
				//Row변경에 따른 GroupBand,Footer변경
				ChangeGroupBandAndFooterAtRowChanging(bfLinesPerRow);
			}
			if (changeCol)
			{

				//관련 Property 변경 (ColPerLine)
				grid.ColPerLine = Math.Max(0, grid.ColPerLine -1);

				//해당 컬럼 Remove
				grid.RemoveColumn(col,1);
				//col이후의 XGridCell정보는 1만큼만 좌로이동
				foreach (XGridCell info in grid.CellInfos)
				{
					if (info.IsVisible)
					{
						// info.Col > col일때
						if (info.Col > col)
							info.Col -= 1;
							// col보다 적을때 Span영역이 Col을 초과하면 ColSpan -1
						else if ((info.Col < col) && (info.Col + info.ColSpan > col))
						{
							info.ColSpan--;
							grid[info.Row, info.Col].ColSpan--;
						}
						//Col + ColSpan이 grid.Cols보다 크면 Cols만큼만 Padding
						if ((info.Col >= 0) && (info.Col + info.ColSpan > grid.Cols))
						{
							info.ColSpan = Math.Max(1, grid.Cols - info.Col);
							grid[info.Row, info.Col].ColSpan = Math.Max(1, grid.Cols - info.Col);
						}
					}
				}
				// col이후의 XGridHeader 정보 좌로 이동
				foreach (XGridHeader info in grid.HeaderInfos)
				{
					// info.Col > col일때
					if (info.Col > col)
						info.Col -= 1;

					// col보다 적을때 Span영역이 Col을 초과하면 ColSpan -1
					else if ((info.Col < col) && (info.Col + info.ColSpan > col))
					{
						info.ColSpan--;
						grid[info.Row, info.Col].ColSpan--;
					}
					//Col + ColSpan이 grid.Cols보다 크면 Cols만큼만 Padding
					if (info.Col + info.ColSpan > grid.Cols)
					{
						info.ColSpan = Math.Max(1, grid.Cols - info.Col);
						grid[info.Row, info.Col].ColSpan = Math.Max(1, grid.Cols - info.Col);
					}
				}

				//Column변경에 따른 GroupBand, Footer 변경
				ChangeGroupBandAndFooterAtColChanging(col);
			}
			// 다시그림
			grid.Redraw = true;
		}

		private void RecoverOtherProperties(bool isAddedHeader)
		{
			if (changeList.Count < 1) return;
			iComp.OnComponentChanging(grid, null);
			string[] list = changeList[changeList.Count -1].ToString().Split(new char[] {','});
			int  row       = Int32.Parse(list[0]);
			int  col       = Int32.Parse(list[1]);
			bool changeRow = (list[2] == "True" ? true : false);
			bool changeCol = (list[3] == "True" ? true : false);

			if (changeRow)
			{
				// 해당 row보다 크거나 같은 정보의 Row위치를 + 1
				// row이후의 XGridCell 정보는 1만큼 위로이동
				foreach (XGridCell info in grid.CellInfos)
					if (info.IsVisible && info.Row >= row)
						info.Row ++;
				// row이후의 XGridHeader 정보 위로 이동
				foreach (XGridHeader info in grid.HeaderInfos)
					if (info.Row >= row)
						info.Row ++;
				
				//추가Header복구시 addedHeaderLine 변경, XGridCell 복구시 LinePerRow 변경
				if (isAddedHeader)
					grid.AddedHeaderLine++;
				else
					grid.LinePerRow++;

				//FixedRows Set (한행의 Line수 + 추가 Line수)
				grid.FixedRows = grid.LinePerRow + grid.AddedHeaderLine;
			}
			if (changeCol)
			{
				// 해당 col보가 크거나 같은 정보의 col위치 +1
				foreach (XGridCell info in grid.CellInfos)
					if (info.IsVisible && info.Col >= col)
						info.Col ++;
				foreach (XGridHeader info in grid.HeaderInfos)
					if (info.Col >= col)
						info.Col ++;
				foreach (XGridComputedCell info in grid.ComputedCellInfos)
					if (info.Col >= col)
						info.Col ++;
				//관련 Property 변경 (ColPerLine)
				grid.ColPerLine++;
			}
			// 변경 List에서 삭제
			changeList.RemoveAt(changeList.Count -1);
			iComp.OnComponentChanged(grid, null, null, null);
		}

		private void OnComponentAdding(object sender, ComponentEventArgs e)
		{
			if (e.Component is XGridCell)
				RecoverOtherProperties(false);
			else if (e.Component is XGridHeader)
				RecoverOtherProperties(true);
		}
		
		private void OnComponentRemoving(object sender, ComponentEventArgs e)
		{
			XGridCell cellInfo;
			XGridHeader headerInfo;
			XGridComputedCell compInfo;
			int idx;
			bool removable = true;
			int bfLinesPerRow = grid.GetLinesPerRow();
			
			// XGridCell가 제거되는 경우
			if (e.Component is XGridCell)
			{
				cellInfo = (XGridCell) e.Component;
				if (grid.CellInfos.Contains(cellInfo))
				{
					try
					{
						//EditorStyle이 Combo이고, ComboItems가 있는 경우는 XComboItem Component Destroy
						if (cellInfo is XEditGridCell)
						{
							XEditGridCell editInfo = (XEditGridCell) cellInfo;
							if ((editInfo.EditorStyle == XCellEditorStyle.ComboBox) && (editInfo.ComboItems.Count > 0))
							{
								XComboItem cboItem = null;
								for (int i = editInfo.ComboItems.Count - 1 ; i >= 0 ; i--)
								{
									cboItem = editInfo.ComboItems[i];
									editInfo.ComboItems.Remove(cboItem);
									//콤보 제거후 Component Destroy
									iHost.DestroyComponent(cboItem);
								}
							}
						}
					}
					catch(Exception xe)
					{
						MessageBox.Show("XGridDesigner::OnComponentRemoving Error=" + xe.Message + "," + xe.StackTrace);
					}

					iComp.OnComponentChanging(grid, null);
					grid.CellInfos.Remove(cellInfo);
					grid[cellInfo.Row, cellInfo.Col] = null;
					// 관련 항목 변경
					ChangeOtherProperties(false,cellInfo.Row,cellInfo.Col,bfLinesPerRow);
					iComp.OnComponentChanged(grid, null, null, null);
					//변경된 CellInfos로 다른 정보 변경
					bool groupChanged = grid.ModifyOtherColumnInfos(grid.CellInfos);
					if (groupChanged)
						grid.InitializeColumns();  //Group정보가 바뀌었으면 다시 초기화
					return;
				}
			}
			else if (e.Component is XGridHeader)
			{
				headerInfo = (XGridHeader) e.Component;
				if (grid.HeaderInfos.Contains(headerInfo))
				{
					// 추가된 Header를 모두 삭제시에 같은 Row를 가진 XGridCell가 있으면 삭제불가
					if (grid.HeaderInfos.Count == 1)
					{
						foreach (XGridCell info in grid.CellInfos)
							if (info.IsVisible && (info.Row == headerInfo.Row))
							{
								removable = false;
								break;
							}
					}
					if (!removable)
					{
						throw(new Exception("같은행에 컬럼정보가 있어 삭제불가합니다.(컬럼정보이동후 삭제)"));
					}
					iComp.OnComponentChanging(grid, null);
					grid.HeaderInfos.Remove(headerInfo);
					grid[headerInfo.Row, headerInfo.Col] = null;
					// 관련 항목 변경
					ChangeOtherProperties(true,headerInfo.Row,headerInfo.Col,bfLinesPerRow);
					iComp.OnComponentChanged(grid, null, null, null);
					return;
				}
			}
			else if (e.Component is XGridComputedCell)
			{
				compInfo = (XGridComputedCell) e.Component;
				if (grid.ComputedCellInfos.Contains(compInfo))
				{
					iComp.OnComponentChanging(grid, null);
					grid.ComputedCellInfos.Remove(compInfo);
					int row = this.GetRowByGroupName(compInfo.GroupName, true, compInfo.Row);
					grid[row, compInfo.Col] = null;
					//해당자리에 Bander추가
					if (compInfo.GroupName == XGridUtility.FooterGroupName)  //Footer
					{
						for (int i = row ; i < row + compInfo.RowSpan ; i++)
							for (int j = compInfo.Col ; j < compInfo.Col + compInfo.ColSpan ; j++)
								grid[i,j] = new XFooterCell(XGridUtility.FooterGroupName,XGridUtility.FooterName);

					}
					else //GroupBander
					{
						for (int i = row ; i < row + compInfo.RowSpan ; i++)
							for (int j = compInfo.Col ; j < compInfo.Col + compInfo.ColSpan ; j++)
								grid[i,j] = new XGroupBandCell(compInfo.GroupName,compInfo.GroupName);
					}
					iComp.OnComponentChanged(grid, null, null, null);
					return;
				}
			}

			// Grid자체가 제거되는 경우
			if (e.Component == grid)
			{
				for (idx = grid.CellInfos.Count - 1; idx >= 0; idx--)
				{
					cellInfo = grid.CellInfos[idx];
					//EditorStyle이 Combo이고, ComboItems가 있는 경우는 XComboItem Component Destroy
					if (cellInfo is XEditGridCell)
					{
						XEditGridCell editInfo = (XEditGridCell) cellInfo;
						if ((editInfo.EditorStyle == XCellEditorStyle.ComboBox) && (editInfo.ComboItems.Count > 0))
						{
							XComboItem cboItem = null;
							for (int i = editInfo.ComboItems.Count - 1 ; i >= 0 ; i--)
							{
								cboItem = editInfo.ComboItems[i];
								editInfo.ComboItems.Remove(cboItem);
								//콤보 제거후 Component Destroy
								iHost.DestroyComponent(cboItem);
							}
						}
					}
					iComp.OnComponentChanging(grid, null);
					grid.CellInfos.Remove(cellInfo);
					iHost.DestroyComponent(cellInfo);
					iComp.OnComponentChanged(grid, null, null, null);
				}
				for (idx = grid.HeaderInfos.Count - 1; idx >= 0; idx--)
				{
					headerInfo = grid.HeaderInfos[idx];
					iComp.OnComponentChanging(grid, null);
					grid.HeaderInfos.Remove(headerInfo);
					iHost.DestroyComponent(headerInfo);
					iComp.OnComponentChanged(grid, null, null, null);
				}
				for (idx = grid.ComputedCellInfos.Count - 1; idx >= 0; idx--)
				{
					compInfo = grid.ComputedCellInfos[idx];
					iComp.OnComponentChanging(grid, null);
					grid.ComputedCellInfos.Remove(compInfo);
					iHost.DestroyComponent(compInfo);
					iComp.OnComponentChanged(grid, null, null, null);
				}
			}
		}

		/// <summary>
		/// 관리되지 않는 리소스를 해제하고 필요에 따라 관리되는 리소스를 해제합니다.
		/// </summary>
		/// <param name="disposing">관리되는 리소스와 관리되지 않는 리소스를 모두 해제하려면 true로 설정하고, 관리되지 않는 리소스만 해제하려면 false로 설정합니다.</param>
		protected override void Dispose(bool disposing)
		{
			// Unhook events
			iSvc.SelectionChanged -= new EventHandler(OnSelectionChanged);
			iComp.ComponentRemoving -= new ComponentEventHandler(OnComponentRemoving);
			iComp.ComponentChanged -= new ComponentChangedEventHandler(OnComponentChanged);
			iComp.ComponentAdding  -= new ComponentEventHandler(OnComponentAdding);
			//grid Event Clear
			grid.AllowDrop = this.gridOldAllowDrop;
			grid.MouseDown -= new MouseEventHandler(OnGridMouseDown);
			grid.MouseMove -= new MouseEventHandler(OnGridMouseMove);
			grid.MouseUp   -= new MouseEventHandler(OnGridMouseUp);
			grid.DragEnter -= new DragEventHandler(OnGridDragEnter);
			grid.DragDrop  -= new DragEventHandler(OnGridDragDrop);
			grid.GiveFeedback -=new GiveFeedbackEventHandler(OnGiveFeedBack);
			base.Dispose(disposing);
		}

		/// <summary>
		/// 디자이너가 관리하는 구성 요소와 관련된 구성 요소 컬렉션을 가져옵니다.
		/// </summary>
		public override ICollection AssociatedComponents
		{
			get 
			{ 
				//복사, 끌기 또는 이동 작업 중에 디자이너가 관리하는 구성 요소와 함께 복사 또는 이동할 구성 요소를 지정
				// CellInfos, HeaderInfos,ComputedCellInfos 를 관련 Component로 함
				ArrayList comps = new ArrayList();
				foreach (XGridCell info in grid.CellInfos)
					comps.Add(info);
				foreach (XGridHeader hInfo in grid.HeaderInfos)
					comps.Add(hInfo);
				foreach (XGridComputedCell cInfo in grid.ComputedCellInfos)
					comps.Add(cInfo);
				return comps;
			}
		}

		/// <summary>
		/// 디자이너와 관련된 구성 요소에서 지원하는 디자인 타임 동사를 가져옵니다.
		/// </summary>
		public override DesignerVerbCollection Verbs
		{
			get { return verbs;}
		}

		private void OnCreateRemoveGroup(object sender, System.EventArgs e)
		{
			// 컬럼정보 입력확인
			// CellInfos가 있는지 먼저 확인
			if (grid.CellInfos.Count < 1) 
			{
				MessageBox.Show("컬럼정보를 먼저 입력하십시오");
				return;
			}
			XGridCreateGroupForm dlg = new XGridCreateGroupForm(grid.GroupInfos, grid.CellInfos);
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				// Component Changing
				iComp.OnComponentChanging(grid, null);
				int linesPerRow = grid.GetLinesPerRow();
				int groupBandRow = grid.AddedHeaderLine + grid.LinePerRow;  //최초시작위치는 Header다음

				//GroupList에서 제거된 GroupList Remove
				if (dlg.DeletedGroupList.Count > 0)
				{
					ArrayList infoList = new ArrayList();
					foreach (string groupName in dlg.DeletedGroupList)
					{
						groupBandRow += linesPerRow * (Int32.Parse(groupName.Substring(5)) -1);
						//grid의 GroupBand Remove
						grid.RemoveRow(groupBandRow, linesPerRow);
						grid.GroupInfos.Remove(groupName);
						
						foreach (XGridComputedCell info in grid.ComputedCellInfos)
							if (info.GroupName == groupName)
								infoList.Add(info);
						if (infoList.Count > 0)
						{
							// 해당 Group에 속하는 XGridComputedCell Remove, Destroy
							iComp.OnComponentChanging(grid, null);
							for (int i = 0 ; i < infoList.Count ; i++)
							{
								grid.ComputedCellInfos.Remove((XGridComputedCell) infoList[i]);
								iHost.DestroyComponent((XGridComputedCell)infoList[i]);
							}
							iComp.OnComponentChanged(grid, null, null, null);
						}
					}

					//groupBandRow는 Header영역 다음부터 시작
					groupBandRow = grid.AddedHeaderLine + grid.LinePerRow;
					// 3.Remove된 이후 Group은 GroupName -1(ex, Group1,Group2가 있을때, Group1이 삭제되면 Group2-> Group1)
					int index = 0;
					int startCol = 0;
					if (grid.RowHeaderVisible) startCol = 1;
					string bfGroupName = "";
					foreach (XGridGroupInfo groupInfo in grid.GroupInfos)
					{
						bfGroupName = groupInfo.GroupName;
						index++;
						groupInfo.GroupName = "Group" + index.ToString();

						//GroupName변경후에 이전 GroupName에 속해있던 XGridComputedCell의 GroupName도 변경
						foreach (XGridComputedCell info in grid.ComputedCellInfos)
							if (info.GroupName == bfGroupName)
								info.GroupName = groupInfo.GroupName;

						for (int i = groupBandRow ; i < groupBandRow + linesPerRow ; i++)
						{
							for (int j = startCol ; j < grid.Cols ; j++)
							{
								if (grid[i,j] != null)
								{
									// Computed 컬럼이면 CellName에 GroupName SET
									if (grid[i,j].Personality == XCellPersonality.Compute)
										grid[i,j].CellName = groupInfo.GroupName;
										//GroupBand이면 CellName,Value,Tag SET
									else
									{
										grid[i,j].CellName = groupInfo.GroupName;
										grid[i,j].Value = groupInfo.GroupName;
									}
								}
							}
						}

						groupBandRow += linesPerRow;
					}
				}
				if (dlg.GroupColumns.Count > 0)
				{
					string key = "Group" + (grid.GroupInfos.Count + 1).ToString();
					ArrayList columnList = new ArrayList();
					XGridCell info = null;
					foreach (ListViewItem item in dlg.GroupColumns)
					{
						info = grid.CellInfos[item.Text] as XGridCell;
						if (info != null)
							columnList.Add(info.CellName);
						info = null;
					}
					grid.GroupInfos.Add(new XGridGroupInfo(key, columnList.ToArray()));

					//GroupBand 추가(Footer제외 GroupBand의 위치)
					groupBandRow = grid.Rows - linesPerRow;
					//GroupBand위치에 Row Add
					grid.AddRow(groupBandRow, linesPerRow);
					int startCol = 0;
					if (grid.RowHeaderVisible) startCol = 1;
					
					for (int i = groupBandRow ; i < groupBandRow + linesPerRow ; i++)
					{
						for (int j = startCol ; j < grid.Cols ; j++)
						{
							grid[i,j] = new XGroupBandCell(key,key);
						}
					}
				}
				
				//변경된 정보로 컬럼 초기화
				grid.InitializeColumns();

				// Change 완료
				iComp.OnComponentChanged(grid, null, null, null);
			}
		}
		
		private void OnEditColumns(object sender, System.EventArgs e)
		{
			// 해당 속성의 UITypeEditor
			PropertyDescriptor propDescriptor = TypeDescriptor.GetProperties(grid)["CellInfos"];
			UITypeEditor editor = (UITypeEditor)propDescriptor.GetEditor(typeof(UITypeEditor));
			if (editor != null)
			{
				// Editor를 띄우면 복구용으로 저장된 changeList Clear
				// Editor를 띄운다는 것은 삭제처리한 Comp를 복구하지 않겠다는 의미
				this.changeList.Clear();
				editor.EditValue(this, this, grid.CellInfos);
			}
		}

		private void OnAddComputedColumn(object sender, System.EventArgs e)
		{
			//Edit창 Popup
			XGridComputedExpressionEditorForm dlg = new XGridComputedExpressionEditorForm(true,grid.CellInfos, grid.GroupInfos, XGridUtility.FooterGroupName,"");
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				CreateComputedColumn(dlg, -1, -1);
			}
		}
		
		private void CreateComputedColumn(XGridComputedExpressionEditorForm dlg, int row, int col)
		{
			XGridComputedCell computedInfo = null;
			
			//Row와 Col이 지정되었으면 해당 Row,Col에 생성
			if ((row >= 0) && (col >= 0))
			{
				int rowNum = this.GetRowByGroupName(dlg.GroupName, false, row);
				// Component Changing
				iComp.OnComponentChanging(grid, null);
				computedInfo = (XGridComputedCell) iHost.CreateComponent(typeof(XGridComputedCell));
				//grid의 CellInfos를 XGridComputedCell의 Designer의 Property로 SET
				((XGridComputedCellDesigner)iHost.GetDesigner(computedInfo)).CellInfos = grid.CellInfos;
				grid[row,col] = null;
				grid[row,col] = new XComputedCell(dlg.GroupName, dlg.Expression);
				//Tag에 Idetifier SET
				grid[row,col].Tag = computedInfo.Identifier;
				//Properties SET
				computedInfo.GroupName = dlg.GroupName;
				computedInfo.Expression = dlg.Expression;
				computedInfo.Row = rowNum;
				computedInfo.Col = col;
				computedInfo.ComputedKind = dlg.ComputedKind; // Expression에 의한 Compute종류 SET
				grid.ComputedCellInfos.Add(computedInfo);
				// Change 완료
				iComp.OnComponentChanged(grid, null, null, null);
			}
			else
			{
				int startRow = 0;
				int startCol = 0;
				int linesPerRow = grid.GetLinesPerRow();
				if (grid.RowHeaderVisible) startCol = 1;

				startRow = this.GetRowByGroupName(dlg.GroupName, true, 0);

				// 처음 발견되는 GroupBand, Footer에 ComputedCell SET
				for (int i = startRow ; i < startRow + linesPerRow ; i++)
				{
					for (int j = startCol; j < grid.Cols ; j++)
					{
						if (grid[i,j] != null)
						{
							if (grid[i,j].Personality != XCellPersonality.Compute)
							{
								// Component Changing
								iComp.OnComponentChanging(grid, null);
								// CreateComponent를 하게되면 InitializeComponents가 작동하여 Grid을 다시 초기화함
								// 따라서, grid에 ComputedCell을 SET하는 것은 Component생성후에 해야함.
								// 다른 경우에도 생성순서를 주의해야함 *****
								computedInfo = (XGridComputedCell) iHost.CreateComponent(typeof(XGridComputedCell));
								//grid의 CellInfos를 XGridComputedCell의 Designer의 Property로 SET
								((XGridComputedCellDesigner)iHost.GetDesigner(computedInfo)).CellInfos = grid.CellInfos;
								grid[i,j] = null;
								grid[i,j] = new XComputedCell(dlg.GroupName, dlg.Expression);
								//Tag에 Idetifier SET
								grid[i,j].Tag = computedInfo.Identifier;
								//Properties SET
								computedInfo.GroupName = dlg.GroupName;
								computedInfo.Expression = dlg.Expression;
								computedInfo.Row = i - startRow;
								computedInfo.Col = j;
								computedInfo.ComputedKind = dlg.ComputedKind; // Expression에 의한 Compute종류 SET
								grid.ComputedCellInfos.Add(computedInfo);
								// Change 완료
								iComp.OnComponentChanged(grid, null, null, null);
								return;
							}
						}
					}
				}
			}
		}
		private void OnAddHeaders(object sender, System.EventArgs e)
		{
			//Header추가 요건
			//1.Header추가는 grid의 AddedHeaderLine다음행에 추가한다.
			//2.추가된 행의 HeaderCell의 isAddedHeader = true, 한 Column만 Setting하고 나머지 컬럼은 dummyCell생성
			
			// CellInfos가 있는지 먼저 확인
			if (grid.CellInfos.Count < 1) 
			{
				MessageBox.Show("컬럼정보를 먼저 입력하십시오");
				return;
			}
			//AddHeaderForm call, DialogResult = OK이면 Header 추가
			XGridAddHeaderForm dlg = new XGridAddHeaderForm();
			if (dlg.ShowDialog() != DialogResult.OK) return;
			if (dlg.AddedHeaders.Count < 1) return;

			// 복구용으로 저장된 changeList Clear
			// Header가 추가되었으므로 기존 Data로는 복구불가
			this.changeList.Clear();

			int bfRows = grid.Rows;

			XCell[,] bfCells = new XCell[grid.Rows, grid.Cols];
			for ( int i = 0 ; i < grid.Rows ; i++)
				for (int j = 0 ; j < grid.Cols ; j++)
					bfCells[i,j] = grid[i,j];

			// 그리기 멈춤
			grid.Redraw = false;

			// Component Changing
			iComp.OnComponentChanging(grid, null);

			//Rows Clear
			grid.Rows = 0;
			grid.FixedRows = 0;
			
			// AddedHeaderLine수 증가
			grid.AddedHeaderLine ++;

			//Rows, FixedRows 다시 Set
			grid.Rows = bfRows + 1;
			//FixedRows = 한 Row의 Line수 + 추가된 Header의 Line수
			grid.FixedRows = grid.LinePerRow + grid.AddedHeaderLine;

			//dlg.AddedHeaders로 추가 Header Set, 
			// RowHeaderVisible이면 1부터시작, Not visible이면 0부터 시작
			if (grid.RowHeaderVisible)
			{
				for (int i = 1 ; i < grid.Cols ; i++)
					if (dlg.AddedHeaders.Count > (i -1))
						grid[0,i] = new XColHeaderCell("",dlg.AddedHeaders[i-1], true);
			}
			else
			{
				for (int i = 0 ; i < grid.Cols ; i++)
					if (dlg.AddedHeaders.Count > i)
						grid[0,i] = new XColHeaderCell("",dlg.AddedHeaders[i], true);
			}

			for ( int i = 1 ; i < grid.Rows ; i++)
			{
				for (int j = 0 ; j < grid.Cols ; j++)
				{
					if (grid.RowHeaderVisible && (j == 0) && (i == 1))
					{
						grid[0,0] = bfCells[0,0];
						grid[0,0].RowSpan = grid.FixedRows;
					}
					else if (bfCells[i-1,j] != null)
					{
						grid[i,j] = bfCells[i-1,j];
						grid[i,j].Row = i;  //Row 증가
					}
				}
			}

			// HeaderHeights 변경
			grid.HeaderHeights.Clear();
			//for (int i = 0; i < grid.Rows ; i++)
			for (int i = 0; i < grid.AddedHeaderLine + grid.LinePerRow ; i++)
				grid.HeaderHeights.Add(grid.CellRowInfo[i].Height);

            // 기존의 XGridCell, XGridHeader의 XPos 1증가
            /* .net 2003 context.OnComponentChanged() 만 Call하면 InitialzeComponent 에 변경된 Component의 속성이 반영
             * .NET 2005 context.OnComponentChanged() Call로 반영안됨
             *  따라서, 각 Compoent별로 Component가 변경됨을 Designer에 알려주어야 함.
             */
            foreach (XGridCell info in grid.CellInfos)
            {
                //Visible한 컬럼만 Row Add
                if (info.IsVisible)
                {
                    info.Row++;
                    iComp.OnComponentChanged(info, null, null, null); //.NET 2005
                }
            }
            foreach (XGridHeader info in grid.HeaderInfos)
            {
                info.Row++;
                iComp.OnComponentChanged(info, null, null, null); //.NET 2005
            }

			// XGridHeader 추가
			XGridHeader headerInfo = null;
			int startCol = 0;
			if (grid.RowHeaderVisible) startCol = 1;
			for (int i = startCol; i < grid.Cols ; i++)
			{
				if (grid[0,i] != null)
				{
					headerInfo = (XGridHeader) iHost.CreateComponent(typeof(XGridHeader));
					
					// grid[0,i].Tag에 info의 Identifier SET
					grid[0,i].Tag = headerInfo.Identifier;

					//Properties SET
					headerInfo.HeaderText = grid[0,i].Value.ToString();
					headerInfo.Row = 0;
					headerInfo.Col = i;
					grid.HeaderInfos.Add(headerInfo);
				}
			}
			// Change 완료
			iComp.OnComponentChanged(grid, null, null, null);
			// 그리기 시작
			grid.Redraw = true;

		}
		private void OnDefaultHeight(object sender, System.EventArgs e)
		{
			// 전체 Header 기본 높이로 복구
			// Component Changing
			iComp.OnComponentChanging(grid, null);
			
			int top = 0;
			// 전체 행높이 기본높이로 설정
			for ( int i = 0 ; i < grid.CellRowInfo.Count ; i++)
			{
				grid.CellRowInfo[i].Top = top;
				grid.CellRowInfo[i].Height = grid.AutoSizeHeight;
				top += grid.AutoSizeHeight;
				//HeaderHeights 변경
				try
				{
					grid.HeaderHeights[i] = grid.AutoSizeHeight;
				}
				catch{}
			}
			grid.Invalidate(true);

			// Change 완료
			iComp.OnComponentChanged(grid, null, null, null);

		}
		private void OnPaddingHeader(object sender, System.EventArgs e)
		{
			// Header의 Padding (선택된 Cell의 현위치에 아래,우측의 빈 부분을 Padding함)
			// 추가된 Header영역은 추가Header영역끼리만 가능
			// 선택된 Cell이 한개일때만 가능
			// Padding우선순위는 ColPadding우선, Row,Col둘다 Padding은 불가
			if (grid.Selection.Count < 1)
			{
				MessageBox.Show("Header를 선택하십시오.");
				return;
			}
			DialogResult dlgRet = MessageBox.Show("ColPadding하시겠습니까?\r\n No선택시는 RowPadding합니다.","Padding 방향지정", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
			bool isColPadding = true;
			if (dlgRet == DialogResult.No)
				isColPadding = false;
			else if (dlgRet == DialogResult.Cancel) return;

			int start, end;
			int paddingCnt = 0;
			XGridCell cellInfo = null;
			XGridHeader headerInfo = null;
			XGridComputedCell compInfo = null;
			foreach (XCell cell in grid.Selection)
			{
				paddingCnt = 0;

				if ((cell.RowSpan > 1) && isColPadding)
				{
					MessageBox.Show("RowPadding된 Header는 ColPadding할 수 없습니다.");
					return;
				}
				if ((cell.ColSpan > 1) && !isColPadding)
				{
					MessageBox.Show("ColPadding된 Header는 RowPadding할 수 없습니다.");
					return;
				}

				// ColHeader는 이미 RowPadding된 Cell은 ColPadding불가, ColPadding된 Cell은 RowPadding불가
				if (cell.Personality == XCellPersonality.ColHeader)
				{
					if (isColPadding)
					{
						start = cell.Col + cell.ColSpan;
						end = grid.Cols;
						for (int i = start ; i < end ; i++)
						{
							if (grid[cell.Row, i] == null)
							{
								// 다른 Cell의 Padding영역에 있으면 break
								if (IsInPaddingRegion(true,cell.Row, i)) break;
								paddingCnt++;
							}
							else
								break;
						}
						if (paddingCnt > 0)
						{
							iComp.OnComponentChanging(grid, null);
							cell.ColSpan += paddingCnt;
							if (cell.IsAddedHeader)
							{
								headerInfo = grid.HeaderInfos[cell.Tag];
								if (headerInfo != null)
									headerInfo.ColSpan += paddingCnt;
							}
							else
							{
								cellInfo = grid.CellInfos[cell.CellName];
								if (cellInfo != null)
									cellInfo.ColSpan += paddingCnt;
							}
							iComp.OnComponentChanged(grid, null, null, null);
						}
					}
					else
					{
						start = cell.Row + cell.RowSpan;
						// 추가된 Header이면 추가 Header영역까지만 Padding가능
						if (cell.IsAddedHeader)
							end = grid.AddedHeaderLine;
						else
							end = grid.Rows;
					
						for (int i = start ; i < end ; i++)
						{
							if (grid[i, cell.Col] == null)
							{
								// 다른 Cell의 Padding영역에 있으면 break
								if (IsInPaddingRegion(false, i, cell.Col)) break;
								paddingCnt++;
							}
							else
								break;
						}
						if (paddingCnt > 0)
						{
							iComp.OnComponentChanging(grid, null);
							cell.RowSpan += paddingCnt;
							if (cell.IsAddedHeader)
							{
								headerInfo = grid.HeaderInfos[cell.Tag];
								if (headerInfo != null)
									headerInfo.RowSpan += paddingCnt;
							}
							else
							{
								cellInfo = grid.CellInfos[cell.CellName];
								if (cellInfo != null)
									cellInfo.RowSpan += paddingCnt;
							}
							iComp.OnComponentChanged(grid, null, null, null);
						}
					}
				}
				//Computed컬럼은 GroupBand나 Footer 영역은 모두 Padding
				else if (cell.Personality == XCellPersonality.Compute)
				{
					if (isColPadding)
					{
						start = cell.Col + cell.ColSpan;
						end = grid.Cols;
						for (int i = start ; i < end ; i++)
						{
							if (grid[cell.Row, i] == null)
							{
								// 다른 Cell의 Padding영역에 있으면 break
								if (IsInPaddingRegion(true,cell.Row, i)) break;
								paddingCnt++;
							}
							// 같은 Row에 있는 ComputedCell이 있으면 Break
							else if (grid[cell.Row, i].Personality == XCellPersonality.Compute)
								break;
							// 같은 Row에 있는 GroupBand, Footer이면 paddingCnt++
							else
								paddingCnt++;
						}
						if (paddingCnt > 0)
						{
							//padding된 영역의 Cell은 null
							for (int i = cell.Col + 1 ; i < cell.Col + cell.ColSpan + paddingCnt ; i++)
								grid[cell.Row, i] = null;
							iComp.OnComponentChanging(grid, null);
							cell.ColSpan += paddingCnt;
							compInfo = grid.ComputedCellInfos[cell.Tag];
							if (compInfo != null)
								compInfo.ColSpan += paddingCnt;
							iComp.OnComponentChanged(grid, null, null, null);
						}
					}
					else
					{
						start = cell.Row + cell.RowSpan;

						// 해당 Group의 영역까지만 end로 SET (group의 시작Row + 한 Row의 Line수)
						end = this.GetRowByGroupName(cell.CellName, true, 0) + grid.GetLinesPerRow();

						for (int i = start ; i < end ; i++)
						{
							if (grid[i, cell.Col] == null)
							{
								// 다른 Cell의 Padding영역에 있으면 break
								if (IsInPaddingRegion(false, i, cell.Col)) break;
								paddingCnt++;
							}
							//Computed컬럼이면 break
							else if (grid[i, cell.Col].Personality == XCellPersonality.Compute)
								break;
							// 같은 Col에 있는 GroupBand, Footer이면 paddingCnt++
							else
								paddingCnt++;
						}
						if (paddingCnt > 0)
						{
							//padding된 영역의 Cell은 null
							for (int i = cell.Row + 1 ; i < cell.Row + cell.RowSpan + paddingCnt ; i++)
								grid[i, cell.Col] = null;
							iComp.OnComponentChanging(grid, null);
							cell.RowSpan += paddingCnt;
							compInfo = grid.ComputedCellInfos[cell.Tag];
							if (compInfo != null)
								compInfo.RowSpan += paddingCnt;
							iComp.OnComponentChanged(grid, null, null, null);
						}
					}
				}
			}
		}
		
		private bool IsInPaddingRegion(bool isColPadding, int row, int col)
		{
			if (isColPadding)
			{
				for (int i = 0; i < row ; i++)
					if (grid[i,col] != null)
						if (i + grid[i,col].RowSpan > row) return true;
				return false;
			}
			else
			{
				for (int i = 0; i < col ; i++)
					if (grid[row, i] != null)
						if (i + grid[row,i].ColSpan > col) return true;
				return false;
			}
		}
		private void OnRecoverPadding(object sender, System.EventArgs e)
		{
			// Padding된 Cell은 다시 원래대로 복구
			// 1개 Cell만 선택
			if (grid.Selection.Count < 1)
			{
				MessageBox.Show("Header를 선택하십시오.");
				return;
			}

			XGridCell cellInfo = null;
			XGridHeader headerInfo = null;
			XGridComputedCell compInfo = null;
			int bfColSpan = 1, bfRowSpan = 1;
			
			foreach (XCell cell in grid.Selection)
			{
				// ColSpan 복구
				if (cell.ColSpan > 1)
				{
					iComp.OnComponentChanging(grid, null);
					bfColSpan = cell.ColSpan;
					cell.ColSpan = 1;
					if (cell.Personality == XCellPersonality.ColHeader)
					{
						if (cell.IsAddedHeader)
						{
							headerInfo = grid.HeaderInfos[cell.Tag];
							if (headerInfo != null)
								headerInfo.ColSpan = 1;
						}
						else
						{
							cellInfo = grid.CellInfos[cell.CellName];
							if (cellInfo != null)
								cellInfo.ColSpan = 1;
						}
					}
					else if (cell.Personality == XCellPersonality.Compute)
					{
						// 빈자리는 GroupBand, Footer로 SET
						if (cell.CellName == XGridUtility.FooterGroupName) //Footer
						{
							for (int i = cell.Col + 1 ; i < cell.Col + bfColSpan ; i++)
								grid[cell.Row, i] = new XFooterCell(XGridUtility.FooterGroupName,XGridUtility.FooterName);
						}
						else  //GroupBand
						{
							for (int i = cell.Col + 1 ; i < cell.Col + bfColSpan ; i++)
								grid[cell.Row, i] = new XGroupBandCell(cell.CellName, cell.CellName);
						}
						compInfo = grid.ComputedCellInfos[cell.Tag];
						if (compInfo != null)
							compInfo.ColSpan = 1;
					}
					iComp.OnComponentChanged(grid, null, null, null);
				}
				else if (cell.RowSpan > 1)
				{
					iComp.OnComponentChanging(grid, null);
					bfRowSpan = cell.RowSpan;
					cell.RowSpan = 1;
					if (cell.Personality == XCellPersonality.ColHeader)
					{
						if (cell.IsAddedHeader)
						{
							headerInfo = grid.HeaderInfos[cell.Tag];
							if (headerInfo != null)
								headerInfo.RowSpan = 1;
						}
						else
						{
							cellInfo = grid.CellInfos[cell.CellName];
							if (cellInfo != null)
								cellInfo.RowSpan = 1;
						}
					}
					else if (cell.Personality == XCellPersonality.Compute)
					{
						// 빈자리는 GroupBand, Footer로 SET
						if (cell.CellName == XGridUtility.FooterGroupName) //Footer
						{
							for (int i = cell.Row + 1 ; i < cell.Row + bfRowSpan ; i++)
								grid[i, cell.Col] = new XFooterCell(XGridUtility.FooterGroupName,XGridUtility.FooterName);
						}
						else  //GroupBand
						{
							for (int i = cell.Row + 1 ; i < cell.Row + bfRowSpan ; i++)
								grid[i, cell.Col] = new XGroupBandCell(cell.CellName, cell.CellName);
						}
						compInfo = grid.ComputedCellInfos[cell.Tag];
						if (compInfo != null)
							compInfo.RowSpan = 1;
					}
					iComp.OnComponentChanged(grid, null, null, null);
				}
			}
			grid.Invalidate(true);
		}

		private void OnSameWidth(object sender, System.EventArgs e)
		{
			//2개이상의 Cell을 선택
			//이미 같은 너비이면 처리하지 않음
			int selectCount = grid.Selection.Count;
			int count = 0;
			if (selectCount < 2)
			{
				MessageBox.Show("2개이상의 Header를 선택하십시오.");
				return;
			}
			int sameWidth = grid.Selection[0].AbsoluteRectangle.Width;
			foreach (XCell cell in grid.Selection)
				if (cell.AbsoluteRectangle.Width != sameWidth)
					count++;

			if (count == 0)
			{
				MessageBox.Show("선택된 Header가 모두 같은 Width를 가집니다.");
				return;
			}

			XCell changeCell = null;

			iComp.OnComponentChanging(grid, null);
			
			for (int i = 1 ; i < selectCount ; i++)
			{
				changeCell = grid.Selection[i];
				grid.SetColWidth(changeCell.Col, sameWidth);
			}

			// XGridCell, XGridHeader의 Width 변경
			for (int i = 0 ; i < grid.CellColInfo.Count ; i++)
			{
				foreach (XGridHeader info in grid.HeaderInfos)
					if (info.Col == i)
						info.HeaderWidth = grid.CellColInfo[i].Width;
				foreach (XGridCell info in grid.CellInfos)
					if (info.Col == i)
						info.CellWidth = grid.CellColInfo[i].Width;
			}
			iComp.OnComponentChanged(grid, null, null, null);
		}
		
		/// <summary>
		/// Column과 ScrollBar에서는 Grid가 Mouse Event를 직접처리하도록 한다.
		/// </summary>
		/// <param name="point">화면 좌표에서 마우스를 클릭한 위치를 나타내는 Point입니다.</param>
		/// <returns>지정된 위치의 클릭을 컨트롤에서 처리해야 하면 true이고 그렇지 않으면 false입니다.</returns>
		protected override bool GetHitTest(Point point)
		{
			Rectangle wrct;
			XCell cell = null;

			point = grid.PointToClient(point);

			if (!grid.CustomClientRectangle.Contains(point))
				return true;
			
			// 최초 CellInfos 검색
			foreach (XGridCell cellInfo in grid.CellInfos)
			{
				cell = grid[cellInfo.Row, cellInfo.Col];
				if (cell != null)
				{
					wrct = cell.DisplayRectangle;
					if (wrct.Contains(point))
						return true;
				}
			}
			// 없으면 HeaderInfos 검색
			foreach (XGridHeader info in grid.HeaderInfos)
			{
				cell = grid[info.Row, info.Col];
				if (cell != null)
				{
					wrct = cell.DisplayRectangle;
					if (wrct.Contains(point))
						return true;
				}
			}
			int row = 0;
			// 없으면 XGridComputedCell 검색
			foreach (XGridComputedCell info in grid.ComputedCellInfos)
			{
				row = this.GetRowByGroupName(info.GroupName, true, info.Row);
				cell = grid[row, info.Col];
				if (cell != null)
				{
					wrct = cell.DisplayRectangle;
					if (wrct.Contains(point))
						return true;
				}
			}
			return false;
		}

		#region ITypeDescriptorContext 구현
		IContainer ITypeDescriptorContext.Container
		{
			get { return this.Component.Site.Container; }
		}
		object ITypeDescriptorContext.Instance
		{
			get { return this.Component; }
		}
		PropertyDescriptor propDescriptor = null;
		PropertyDescriptor ITypeDescriptorContext.PropertyDescriptor
		{
			get { return propDescriptor; }
		}
		void ITypeDescriptorContext.OnComponentChanged()
		{
			iComp.OnComponentChanged(grid, propDescriptor, null, null);
		}
		bool ITypeDescriptorContext.OnComponentChanging()
		{
			iComp.OnComponentChanging(grid, propDescriptor);
			return true;
		}
		#endregion

		#region IServiceProvider 구현
		object IServiceProvider.GetService(Type serviceType)
		{
			if (serviceType == typeof(IWindowsFormsEditorService))
			{
				return this;
			}
			else
				return this.GetService(serviceType);
		}
		#endregion

		#region IWindowsFormsEditorService 구현
		void IWindowsFormsEditorService.DropDownControl(Control control)
		{
		}
		void IWindowsFormsEditorService.CloseDropDown()
		{
		}
		DialogResult IWindowsFormsEditorService.ShowDialog(Form dialog)
		{
			return dialog.ShowDialog();
		}

		#endregion

		#region GetRowByGroupName
		private int GetRowByGroupName(string groupName, bool isDisplayPos, int row)
		{
			//Group명에 따라 row를 변환
			// DisplayPos이면 XGridComputedCell에 있는 Row -> Display할 Row로 변환
			// else Display된 Row를 XGridComputedCell의 Row로 변환
			int rowNum = 0;
			int headerLines = grid.AddedHeaderLine + grid.LinePerRow;
			int linesPerRow = grid.GetLinesPerRow();

			if (isDisplayPos)
			{
				if (groupName == XGridUtility.FooterGroupName) // Footer
					rowNum = headerLines + grid.GroupInfos.Count * linesPerRow + row;
				else  //Group2 -> (2 - 1) * linesPerRow
					rowNum = headerLines + (Int32.Parse(groupName.Substring(5)) -1) * linesPerRow + row;
			}
			else
			{
				if (groupName == XGridUtility.FooterGroupName)
					rowNum = row - headerLines - grid.GroupInfos.Count * linesPerRow;
				else
					rowNum = row - headerLines - (Int32.Parse(groupName.Substring(5)) -1) * linesPerRow;
			}
			return rowNum;
		}
		#endregion

		#region ChangeGroupBandAndFooter
		private void ChangeGroupBandAndFooterAtColChanging(int col)
		{
			// col의 위치에 있는 XGridComputedCell는 Remove
			// CompInfo의 ColSpan이 1보다 크면 빈영역은 GroupBand, Footer로 채움
			ArrayList infoList = new ArrayList();
			int dispRow = 0;
			foreach (XGridComputedCell info in grid.ComputedCellInfos)
			{
				if (info.Col == col)
				{
					infoList.Add(info);
					if (info.ColSpan > 1)
					{
						dispRow = this.GetRowByGroupName(info.GroupName, true, info.Row);							
						if (info.GroupName == XGridUtility.FooterGroupName)
						{
							for (int i = col ; i < col + info.ColSpan ; i++)
								if (grid[dispRow,i] == null)
									grid[dispRow, i] = new XFooterCell(XGridUtility.FooterGroupName, XGridUtility.FooterName);

						}
						else
						{
							for (int i = col ; i < col + info.ColSpan ; i++)
								if (grid[dispRow,i] == null)
									grid[dispRow, i] = new XGroupBandCell(info.GroupName, info.GroupName);
						}
					}
				}
			}
			//XGridComputedCell Remove, Destroy
			for (int i = 0 ; i < infoList.Count ; i++)
			{
				grid.ComputedCellInfos.Remove((XGridComputedCell) infoList[i]);
				iHost.DestroyComponent((XGridComputedCell)infoList[i]);
			}
			// col이후의 XGridComputedCell 정보 좌로 이동
			foreach (XGridComputedCell info in grid.ComputedCellInfos)
			{
				dispRow = this.GetRowByGroupName(info.GroupName, true, info.Row);
				if (info.Col > col)
					info.Col -= 1;
					// col보다 적을때 Span영역이 Col을 초과하면 ColSpan -1
				else if ((info.Col < col) && (info.Col + info.ColSpan > col))
				{
					info.ColSpan--;
					grid[dispRow, info.Col].ColSpan--;
				}
				//Col + ColSpan이 grid.Cols보다 크면 Cols만큼만 Padding
				if (info.Col + info.ColSpan > grid.Cols)
				{
					info.ColSpan = Math.Max(1, grid.Cols - info.Col);
					grid[dispRow, info.Col].ColSpan = Math.Max(1, grid.Cols - info.Col);
				}
			}
		}
		private void ChangeGroupBandAndFooterAtRowChanging(int bfLinesPerRow)
		{
			//한 Row의 Line수가 변경이 없으면 Return
			int afLinesPerRow = grid.GetLinesPerRow();
			int diff = afLinesPerRow - bfLinesPerRow;
			if (diff == 0) return;
			
			int newRowPos = 0;
			int startCol = 0;
			if (grid.RowHeaderVisible) startCol = 1;
			if (diff > 0)
			{
				//GroupBand의 Line 추가
				foreach (XGridGroupInfo info in grid.GroupInfos)
				{
					//새행 입력위치 = Group의 시작위치 + 이전의 Line수
					newRowPos = this.GetRowByGroupName(info.GroupName, true,0) + bfLinesPerRow;
					grid.AddRow(newRowPos, diff);
					// 새행위치에 GroupBand 추가
					for (int i = newRowPos ; i < newRowPos + diff ; i++)
						for (int j = startCol ; j < grid.Cols ; j++)
							grid[i,j] = new XGroupBandCell(info.GroupName, info.GroupName);
				}
				//Footer의 Line 추가
				newRowPos = this.GetRowByGroupName(XGridUtility.FooterGroupName, true, 0) + bfLinesPerRow;
				grid.AddRow(newRowPos, diff);
				// 새행위치에 Footer 추가
				for (int i = newRowPos ; i < newRowPos + diff ; i++)
					for (int j = startCol ; j < grid.Cols ; j++)
						grid[i,j] = new XFooterCell(XGridUtility.FooterGroupName,XGridUtility.FooterName);
			}
			else  
			{
				// Component Changing
				iComp.OnComponentChanging(grid, null);
				ArrayList delInfoList = new ArrayList();
				//GroupBand의 Line 감소
				foreach (XGridGroupInfo info in grid.GroupInfos)
				{
					delInfoList.Clear();
					//삭제 Row위치 = Group의 시작위치 + 이후의 Line 수
					newRowPos = this.GetRowByGroupName(info.GroupName, true,0) + afLinesPerRow;
					grid.RemoveRow(newRowPos, -diff);
					//해당 Group에서 if (compInfo.Row >= afLinesPerRow) XGridComputedCell 삭제
					// else if (compInfo.RowSpan > afLinesPerRow)이면 RowSpan 감소
					foreach (XGridComputedCell compInfo in grid.ComputedCellInfos)
					{
						if (compInfo.GroupName == info.GroupName)
						{
							if (compInfo.Row >= afLinesPerRow)
							{
								delInfoList.Add(compInfo);
							}
							else if (compInfo.RowSpan > afLinesPerRow)
							{
								compInfo.RowSpan = afLinesPerRow;
								grid[newRowPos - afLinesPerRow + compInfo.Row, compInfo.Col].RowSpan = afLinesPerRow;
							}
						}
					}
					for (int i = 0 ; i < delInfoList.Count ; i++)
					{
						grid.ComputedCellInfos.Remove((XGridComputedCell) delInfoList[i]);
						iHost.DestroyComponent((XGridComputedCell)delInfoList[i]);
					}
				}

				//Footer의 Line 감소 
				newRowPos = this.GetRowByGroupName(XGridUtility.FooterGroupName, true, 0) + afLinesPerRow;
				grid.RemoveRow(newRowPos, -diff);

				//Footer에서 if (compInfo.Row >= afLinesPerRow) XGridComputedCell 삭제
				// else if (compInfo.RowSpan > afLinesPerRow)이면 RowSpan 감소
				delInfoList.Clear();
				foreach (XGridComputedCell compInfo in grid.ComputedCellInfos)
				{
					if (compInfo.GroupName == XGridUtility.FooterGroupName)
					{
						if (compInfo.Row >= afLinesPerRow)
						{
							delInfoList.Add(compInfo);
						}
						else if (compInfo.RowSpan > afLinesPerRow)
						{
							compInfo.RowSpan = afLinesPerRow;
							grid[newRowPos - afLinesPerRow + compInfo.Row, compInfo.Col].RowSpan = afLinesPerRow;
						}
					}
				}
				for (int i = 0 ; i < delInfoList.Count ; i++)
				{
					grid.ComputedCellInfos.Remove((XGridComputedCell) delInfoList[i]);
					iHost.DestroyComponent((XGridComputedCell)delInfoList[i]);
				}
				// Change 완료
				iComp.OnComponentChanged(grid, null, null, null);
			}
		}
		#endregion

	}

	#region  DragDropInfo (DrapDrop하는 컬럼의 행,열 객체 저장)
	internal class DragDropInfo
	{
		private int row = 0;
		private int col = 0;
		private XCell cell = null;
		private object infoObj = null;
		public int Row
		{
			get { return row;}
		}
		public int Col
		{
			get { return col;}
		}
		public XCell Cell
		{
			get { return cell;}
		}
		public object InfoObj
		{
			get { return infoObj;}
		}
		public DragDropInfo(int row, int col, XCell cell, object infoObj)
		{
			this.row = row;
			this.col = col;
			this.cell = cell;
			this.infoObj = infoObj;
		}
	}
	#endregion
}
