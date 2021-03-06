// *****************************************************************************
// 
//  (c) Crownwood Consulting Limited 2002 
//  All rights reserved. The software and associated documentation 
//  supplied hereunder are the proprietary information of Crownwood Consulting 
//	Limited, Haxey, North Lincolnshire, England and are supplied subject to 
//	licence terms.
// 
//  Magic Version 1.7.4 	www.dotnetmagic.com
// *****************************************************************************

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.ComponentModel;
using System.Diagnostics;
using IHIS.X.Magic.Win32;
using IHIS.X.Magic.Common;
using IHIS.X.Magic.Controls;
using IHIS.X.Magic.Collections;

namespace IHIS.X.Magic.Docking
{
	[ToolboxItem(false)]
	public class AutoHidePanel : Panel
	{
		#region AutoHostPanel
		[ToolboxItem(false)]
			protected class AutoHostPanel : Panel, IResizeSource
		{
			protected Edge _borderEdge;
			protected ResizeAutoBar _resizeAutoBar;
			protected AutoHidePanel _autoHidePanel;
			protected DockingManager _manager;

			public AutoHostPanel(DockingManager manager, AutoHidePanel autoHidePanel, Edge borderEdge)
			{
				//2004.12.15 IFC용 (CausesValidation false)
				this.CausesValidation = false;
				// Remember parameters
				_manager = manager;
				_autoHidePanel = autoHidePanel;
				_borderEdge = borderEdge;
				
				Direction direction;
				
				if ((borderEdge == Edge.Left) || (borderEdge == Edge.Right))
					direction = Direction.Horizontal;
				else
					direction = Direction.Vertical;
				
				// Create a resizing bar
				_resizeAutoBar = new ResizeAutoBar(direction, this);
				
				// Add to the display
				Controls.Add(_resizeAutoBar);
				
				// Define correct position based on Edge
				switch(_borderEdge)
				{
					case Edge.Left:
						_resizeAutoBar.Dock = DockStyle.Left;
						break;
					case Edge.Right:
						_resizeAutoBar.Dock = DockStyle.Right;
						break;
					case Edge.Top:
						_resizeAutoBar.Dock = DockStyle.Top;
						break;
					case Edge.Bottom:
						_resizeAutoBar.Dock = DockStyle.Bottom;
						break;
				}
			}

			public Size ResizeBarSize()
			{
				return _resizeAutoBar.Size;
			}

			public int MinimumWidth 
			{ 
				get { return _resizeAutoBar.Width * 5; }
			}
		
			public int MinimumHeight
			{ 
				get { return _resizeAutoBar.Height * 6; } 
			}

			public Color ResizeBarColor
			{
				get { return _manager.ResizeBarColor; }
			}
            
			public int ResizeBarVector
			{
				get { return _manager.ResizeBarVector; }
			}
            
			public VisualStyle Style 
			{ 
				get { return _manager.Style; }
			}
            
			public Color BackgroundColor
			{
				get { return _manager.BackColor; }
			}

			public bool CanResize(ResizeBar bar)
			{
				return true;
			}
            
			public bool StartResizeOperation(ResizeBar bar, ref Rectangle screenBoundary)
			{
				// Set focus into the WCT to prevent it siding away during resize
				_autoHidePanel.SetFocusToWCT();    
            
				// Define resize boundary as the inner area of the Form containing the Zone
				screenBoundary = this.Parent.RectangleToScreen(_manager.InnerResizeRectangle(this));

				// Find the screen limits of this Zone
				Rectangle panelBoundary = RectangleToScreen(this.ClientRectangle);

				int minHeight = this.MinimumHeight;
				int minWidth = this.MinimumWidth;

				// Restrict resize based on which edge we are attached against
				switch(_borderEdge)
				{
					case Edge.Bottom:
					{
						// Restrict Zone being made smaller than its minimum height
						int diff = panelBoundary.Top - screenBoundary.Top + minHeight;
						screenBoundary.Y += diff;
						screenBoundary.Height -= diff;					

						// Restrict Zone from making inner control smaller than minimum allowed
						int innerMinimumWidth = _manager.InnerMinimum.Height;
						screenBoundary.Height -= innerMinimumWidth;
					}
						break;
					case Edge.Top:
					{
						// Restrict Zone being made smaller than its minimum height
						int diff = panelBoundary.Bottom - screenBoundary.Bottom - minHeight;
						screenBoundary.Height += diff;					

						// Restrict Zone from making inner control smaller than minimum allowed
						int innerMinimumWidth = _manager.InnerMinimum.Height;
						screenBoundary.Y += innerMinimumWidth;
						screenBoundary.Height -= innerMinimumWidth;
					}
						break;
					case Edge.Right:
					{
						// Restrict Zone being made smaller than its minimum width
						int diff = panelBoundary.Left - screenBoundary.Left + minWidth;
						screenBoundary.X += diff;
						screenBoundary.Width -= diff;					

						// Restrict Zone from making inner control smaller than minimum allowed
						int innerMinimumWidth = _manager.InnerMinimum.Width;
						screenBoundary.Width -=	innerMinimumWidth;
					}
						break;
					case Edge.Left:
					{
						// Restrict Zone being made smaller than its minimum width
						int diff = panelBoundary.Right - screenBoundary.Right - minWidth;
						screenBoundary.Width += diff;

						// Restrict Zone from making inner control smaller than minimum allowed
						int innerMinimumWidth = _manager.InnerMinimum.Width;
						screenBoundary.X += innerMinimumWidth;
						screenBoundary.Width -=	innerMinimumWidth;
					}
						break;
				}

				return true;
			}
            
			public void EndResizeOperation(ResizeBar bar, int delta)
			{
				switch(_borderEdge)
				{
					case Edge.Right:
						Controls[1].Width += delta;
						this.Width += delta;
						_autoHidePanel.UpdateContentSize(Controls[1].Width, true);
						break;
					case Edge.Left:
						Controls[1].Width -= delta;
						this.Width -= delta;
						this.Left += delta;
						_autoHidePanel.UpdateContentSize(Controls[1].Width, true);
						break;
					case Edge.Bottom:
						Controls[1].Height += delta;
						this.Height += delta;
						_autoHidePanel.UpdateContentSize(Controls[1].Height, false);
						break;
					case Edge.Top:
						Controls[1].Height -= delta;
						this.Height -= delta;
						this.Top += delta;
						_autoHidePanel.UpdateContentSize(Controls[1].Height, false);
						break;
				}
                
				_autoHidePanel.DefineRectangles();
			}

			public void PropogateNameValue(PropogateName name, object value)
			{
				switch(name)
				{
					case PropogateName.BackColor:
						this.BackColor = (Color)value;
						Invalidate();
						break;
				}

				// Pass onto the Resize bar control
				_resizeAutoBar.PropogateNameValue(name, value);            
			}

			protected override void OnPaintBackground(PaintEventArgs e)
			{
				// Overriden to prevent background being painted
			}

			protected override void OnPaint(PaintEventArgs e)
			{
				// Overriden to paint just the inward facing edge
			}
		}
		#endregion

		#region IHIS용 추가 Event (Panel을 Click했을때 Event)
		public event IHIS.X.Magic.Docking.TabStub.TabStubHandler TabStubClickAtContentHidden;
		protected virtual void OnTabStubClickAtContentHidden(IHIS.X.Magic.Docking.TabStub tabStub)
		{
			if (TabStubClickAtContentHidden != null)
				TabStubClickAtContentHidden(tabStub);
		}
		//Gradient Color 변경
		private Color gradientStart = Color.FromArgb(220,236,254);  //Gradient Start Color
		private Color gradientEnd   = Color.FromArgb(140,177,230);  //Gradient End Color
		public void SetGradientColor(Color gradientStart, Color gradientEnd)
		{
			this.gradientStart = gradientStart;
			this.gradientEnd = gradientEnd;
			this.Invalidate(true);
		}
		#endregion

		// Static fields
		protected static int _num = 0;
		protected static int _slideSteps = 4;
		protected static int _slideInterval = 15;
		protected static int _dismissInterval = 1000;
	
		// Instance fields
		protected int _number;
		protected bool _killing;
		protected bool _defaultColor;
		protected bool _dismissRunning;
		protected bool _slideRunning;
		protected bool _ignoreDismiss;
		protected bool _slideOut;
		protected int _slideStep;
		protected Timer _slideTimer;
		protected Timer _dismissTimer;
		protected Rectangle _slideRect;
		protected Rectangle _rememberRect;
		protected DockingManager _manager;
		protected AutoHostPanel _currentPanel;
		protected WindowContentTabbed _currentWCT;
		private	  bool isSameTabStubClick = false; //IFC용 동일한 Tab을 Click했는지 여부 (OnPageOver에서 SET, OnPageClicked에서 Event 발생여부 판단)
		private	  bool isClickedWhenDisplayed = false;  //IFC용 이미 Display된 상태에서 Panel을 또 Click했는지 여부 OnPanelLeave에서 상태관계없이 닫도록함(Toggle 가능하게)
		//2005.12.29 TabControl의 기본 BackColor 지정 (SystemColors.Control 대신에 사용)
		//private Color DEFAULT_BACKCOLOR = Color.FromArgb(217,228,247);
		private Color DEFAULT_BACKCOLOR = Color.FromArgb(227,235,249);
        
		public AutoHidePanel(DockingManager manager, DockStyle dockEdge)
		{
			// Define initial state
			_number = _num++;
			_defaultColor = true;
			_dismissRunning = false;
			_slideRunning = false;
			_ignoreDismiss = false;
			_killing = false;
			_manager = manager;
			_currentWCT = null;
			_currentPanel = null;
			_slideRect = new Rectangle();
			_rememberRect = new Rectangle();
            
			// Get the minimum vector length used for sizing
			int vector = TabStub.TabStubVector(this.Font);
            
			// Use for both directions, the appropriate one will be ignored because of docking style
			this.Size = new Size(vector, vector);

			// Dock ourself against requested position
			this.Dock = dockEdge;

			// We should be hidden until some Contents are added
			this.Hide();

			// We want to perform special action when container is resized
			//_manager.Container.Resize += new EventHandler(OnContainerResized);
		}
		
		public void PropogateNameValue(PropogateName name, object value)
		{
			switch(name)
			{
				case PropogateName.BackColor:
					this.BackColor = (Color)value;
					Invalidate();
					break;
				case PropogateName.CaptionFont:
					this.Font = (Font)value;
                    
					// Recalculate the window size
					int vector = TabStub.TabStubVector(this.Font); 
					this.Size = new Size(vector, vector);
                    
					Invalidate();
					break;
			}
            
			// Pass onto each TabStub instance
			foreach(TabStub ts in Controls)
				ts.PropogateNameValue(name, value);
                
			// Pass onto any current Panel object
			if (_currentPanel != null)
				_currentPanel.PropogateNameValue(name, value);
		}
        
		public override Color BackColor
		{
			get { return base.BackColor; }

			set
			{
				if (this.BackColor != value)
				{
					_defaultColor = (value == DEFAULT_BACKCOLOR);
					base.BackColor = value;
					Invalidate();
				}
			}
		}
                        
		protected override void OnSystemColorsChanged(EventArgs e)
		{
			if (_defaultColor)
				Invalidate();
		}
		public bool ContainsContent(Content c)
		{
			return (TabStubForContent(c) != null);
		}

		protected TabStub TabStubForContent(Content c)
		{
			// Test each of the TabStub child controls
			foreach(TabStub ts in this.Controls)
			{
				// Test each page inside the TabStub
				foreach(IHIS.X.Magic.Controls.TabPage page in ts.TabPages)
				{
					if (c.Title == (page.Tag as Content).Title)
						return ts;
				}
			}
            
			return null;
		}
        
		public void BringContentIntoView(Content c)
		{
			// Test each of the TabStub child controls
			foreach(TabStub ts in this.Controls)
			{
				// Test each page inside the TabStub
				foreach(IHIS.X.Magic.Controls.TabPage page in ts.TabPages)
				{
					if (c.Title == (page.Tag as Content).Title)
					{
						// Remove any existing window
						RemoveShowingWindow();

						// Use existing method to cause content to be displayed
						OnPageClicked(ts, ts.TabPages.IndexOf(page));                    
						return;
					}
				}
			}
		}
                
		public Restore RestoreObjectForContent(Content c)
		{
			StringCollection next = new StringCollection();
			StringCollection previous = new StringCollection();
			StringCollection nextAll = new StringCollection();
			StringCollection previousAll = new StringCollection();

			// Which group has the marked content?
			TabStub marked = TabStubForContent(c);

			// Have we found the marked group yet?
			bool foundGroup = false;
            
			// Found the content in the marked group yet?
			bool foundContent = false;

			int controlCount = this.Controls.Count;
        
			// Process each TabStub in turn
			for(int controlIndex=controlCount-1; controlIndex>=0; controlIndex--)
			{
				TabStub ts = this.Controls[controlIndex] as TabStub;
            
				// Process each Page in the TabStub
				foreach(IHIS.X.Magic.Controls.TabPage page in ts.TabPages)
				{
					Content content = page.Tag as Content;

					// Is this the marked group
					if (marked == ts)
					{
						// Add into the 'nextAll' rather than 'previousAll' groups from now on
						foundGroup = true;

						// No need to save ourself in our best friends list!
						if (content.Title == c.Title)
						{
							// Add into the 'next' rather than 'previous' contents now
							foundContent = true;
						}
						else
						{
							if (!foundContent)
								previous.Add(content.Title);
							else
								next.Add(content.Title);
						}
					}
					else
					{
						if (!foundGroup)
							previousAll.Add(content.Title);
						else
							nextAll.Add(content.Title);                    
					}
				}
			}

			// Calculate state from docking value
			State windowState = State.DockLeft;
		    
			// Define stub settings based on our docking position
			switch(this.Dock)
			{
				case DockStyle.Left:
					windowState = State.DockLeft;
					break;
				case DockStyle.Right:
					windowState = State.DockRight;
					break;
				case DockStyle.Top:
					windowState = State.DockTop;
					break;
				case DockStyle.Bottom:
					windowState = State.DockBottom;
					break;
			}
            
			return new RestoreAutoHideAffinity(null, windowState, c, next, previous, nextAll, previousAll);
		}
        
		public void AddContent(Content content, 
			StringCollection next, 
			StringCollection previous, 
			StringCollection nextAll, 
			StringCollection previousAll)
		{
			int nextIndex = 0;
			int previousIndex = 0;
			TabStub nextTabStub = null;
			TabStub previousTabStub = null;
			TabStub nextAllTabStub = null;
			TabStub previousAllTabStub = null;
        
			int controlCount = this.Controls.Count;
        
			// Process each TabStub in turn
			for(int controlIndex=controlCount-1; controlIndex>=0; controlIndex--)
			{
				TabStub ts = this.Controls[controlIndex] as TabStub;

				// Process each Page in the TabStub
				foreach(IHIS.X.Magic.Controls.TabPage page in ts.TabPages)
				{
					Content c = page.Tag as Content;

					// Always use the last 'previous' discovered
					if (previous.Contains(c.Title))
					{
						previousIndex = ts.TabPages.IndexOf(page);
						previousTabStub = ts;
					}
                    
					// Only remember the first 'next' discovered
					if (next.Contains(c.Title))
					{
						if (nextTabStub == null)
						{
							nextIndex = ts.TabPages.IndexOf(page);
							nextTabStub = ts;
						}
					}

					// Always use the last 'previousAll' discovered
					if (previousAll.Contains(c.Title))
						previousAllTabStub = ts;

					// Only remember the first 'next' discovered
					if (nextAll.Contains(c.Title))
					{
						if (nextAllTabStub == null)
							nextAllTabStub = ts;
					}
				}
			}            

			// If no matches at all found
			if ((previousTabStub == null) && (nextTabStub == null))
			{
				// Default to inserting at end of list
				int insertIndex = Controls.Count;
            
				// If found some friends contents, then insert relative to them
				if (previousAllTabStub != null)
					insertIndex = Controls.IndexOf(previousAllTabStub);
				else
				{
					if (nextAllTabStub != null)
						insertIndex = Controls.IndexOf(nextAllTabStub) + 1;
				}
            
				ContentCollection cs = new ContentCollection();
                
				cs.Add(content);
            
				// Add at end of current list of TabStubs
				AddContentsAsGroup(cs, insertIndex);
			}
			else
			{
				if (previousTabStub != null)
					AddContentIntoTabStub(content, previousTabStub, previousIndex + 1);
				else
					AddContentIntoTabStub(content, nextTabStub, nextIndex);
			}
		}

		public void AddContentIntoTabStub(Content content, TabStub ts, int index)
		{
			// Is focus leaving the entire WindowContentTabbed control?
			if ((_currentWCT != null) && (_currentWCT == ts.WindowContentTabbed))
			{
				// Remove Panel/WCT from display and stop timers
				RemoveDisplayedWindow();
			}                
        
			// Create a new tab page
			IHIS.X.Magic.Controls.TabPage page = new IHIS.X.Magic.Controls.TabPage();
		        
			// Copy across the visual properties
			page.Title = content.Title;
			page.ImageList = content.ImageList;
			page.ImageIndex = content.ImageIndex;
			page.Icon = content.Icon;
                
			// Remember reference to Content it represents
			page.Tag = content;
		        
			// Add into the stub
			ts.TabPages.Insert(index, page);
		        
			// Mark Content as being in AutoHide mode
			content.AutoHidePanel = this;
			content.AutoHidden = true;
        
			// Add content into the WCT of the TabStub
			ts.WindowContentTabbed.Contents.Insert(index, content);

			// Make sure this AutoHidePanel is visible
			if (!this.Visible)
				this.Show();
                
			Invalidate();
		}
        
		public void AddContentsAsGroup(ContentCollection contents)
		{
			// By default, insert new group at the end of display which is start of list
			AddContentsAsGroup(contents, 0);
		}
            
		public void AddContentsAsGroup(ContentCollection contents, int index)
		{
			// Create new TabStub to represent the Contents
			TabStub ts = new TabStub(_manager.Style);

			// Set manager requested settings
			ts.Font = _manager.CaptionFont;
			ts.BackColor = _manager.BackColor;
			ts.ForeColor = _manager.InactiveTextColor;

			// Hook into events
			//AMIS에서는 Docking 왼쪽고정되고, 눌렀을때만 처리되도록 PageOver, PageLeave 처리하지 않음
			ts.PageClicked += new TabStub.TabStubIndexHandler(OnPageClicked);
			//ts.PageOver += new TabStub.TabStubIndexHandler(OnPageOver);
			//ts.PagesLeave += new TabStub.TabStubHandler(OnPagesLeave);
		    
			// Add a page for each Content instance
			foreach(Content c in contents)
			{
				// Create page object
				IHIS.X.Magic.Controls.TabPage page = new IHIS.X.Magic.Controls.TabPage();
		        
				// Copy across the visual properties
				page.Title = c.Title;
				page.ImageList = c.ImageList;
				page.ImageIndex = c.ImageIndex;
				page.Icon = c.Icon;
                
				// Remember reference to Content it represents
				page.Tag = c;
				// Add into the stub
				ts.TabPages.Add(page);
		        
				// Mark Content as being in AutoHide mode
				c.AutoHidePanel = this;
				c.AutoHidden = true;
			}

			State windowState = State.DockLeft;
		    
			// Define stub settings based on our docking position
			switch(this.Dock)
			{
				case DockStyle.Left:
					windowState = State.DockLeft;
					ts.Edging = Edge.Left;
					ts.Dock = DockStyle.Top;
					break;
				case DockStyle.Right:
					windowState = State.DockRight;
					ts.Edging = Edge.Right;
					ts.Dock = DockStyle.Top;
					break;
				case DockStyle.Top:
					windowState = State.DockTop;
					ts.Edging = Edge.Top;
					ts.Dock = DockStyle.Left;
					break;
				case DockStyle.Bottom:
					windowState = State.DockBottom;
					ts.Edging = Edge.Bottom;
					ts.Dock = DockStyle.Left;
					break;
			}
		    
			// Add stub into the view
			Controls.Add(ts);
            
			// Set correct new position
			Controls.SetChildIndex(ts, index);
		    
			// Each TabStub has a WCT created and ready to be shown when needed
			WindowContentTabbed wct = _manager.CreateWindowForContent(null, new EventHandler(OnPageClose),
				null, new EventHandler(OnPageAutoHide),
				new ContextHandler(OnPageContextMenu)) as WindowContentTabbed;
            
			// Add each Content instance in turn
			foreach(Content c in contents)
				wct.Contents.Add(c);
                
			// By default the first Content added to a WCT will define the size
			// of the WCT control. We need to override this to use the AutoHideSize
			// from the first Content instead.
			wct.Size = contents[0].AutoHideSize;

			// Ensure Window caption bar reflects correct docking status
			wct.State = windowState;

			// Inform Window it should not allow user initiated redocking
			wct.RedockAllowed = false;

			// Hide tab selection from user
			wct.TabControl.HideTabsMode = Magic.Controls.TabControl.HideTabsModes.HideAlways;

			// Associate WCT with matching TabStub
			ts.WindowContentTabbed = wct;
            
			// Make sure this AutoHidePanel is visible
			if (!this.Visible)
				this.Show();

			Invalidate();
		}

		public void InvertAutoHideWindowContent(WindowContentTabbed wct)
		{
			UnAutoHideWindowContent(wct, true);
		}

		protected void RemoveDisplayedWindow()
		{
			//2005.10.14 IFC 용 (Docking된 화면을 열었다가 닫으면서 이 Method가 구동되는데, 
			//AutoHostPanel의 Controls에서 WCT를 Remove시에 IFC에서 여러화면이 열린 경우(MdiChild) 현재 Active한 MdiChild가
			//첫번째가 아니어도 MdiForm.cs의 첫번째 Open한 MdiChild의 Activate가 발생하면서 Form_Activated Event가 발생하여
			//첫번째 화면으로 이동함. 이를 해결하기 위해 Remove전에 먼저 _manager.Container가 MdiContainer이고 ActiveMdiChild가 있으면
			//이를 보관하였다가 다시 Activate시키는 방향으로 수정함. Stack Trace를 보면 WCT가 Remove되는데 SelectNextControl에서
			//MdiChild가 Select되면서 Activate되는 현상이 보임(왜 그렇게 되는지는 정확히 모르겠음)
			//SelectNextControl은 System.Windows.Forms.dll에서 처리하기 때문에 우리가 수정할 수가 없어서 BUG를 피하는 방법으로 수정함
			//문제는 첫번째 MdiChild와 현재 Focus가 있는 MdiChild
			//다시 activeChild로 이동시는 Form_Activated Event가 계속 발생하여 첫번째로 이동후 다시 원상태로 복귀하므로 잔상이 많이 생김
			//2005.10.17 Stack Flow를 조사해 보니 MdiCHild에 Focus가 갈때 MdiChild의 TabStop이 true이면 SelectNextChild시에 MdiChild를 선택함
			//NextControl이 MdiChild가 되지 않게 하기 위해 MdiForm::OpenNewScreen에서 mdiChild의 TabStop을 false로 설정함
			//이렇게 하면 위 현상을 사라짐(정확한 원인을 파악해야함)
//			Form activeChild = null;
//			Form containerForm = null;
//			//Remove전 ActiveChild 설정
//			if ((this._manager != null) && (this._manager.Container != null) && (this._manager.Container is Form))
//			{
//				containerForm = (Form) this._manager.Container;
//				if (containerForm.IsMdiContainer && (containerForm.ActiveMdiChild != null))
//				{
//					activeChild = containerForm.ActiveMdiChild;
//				}
//			}

			if (_currentPanel != null)
			{
				// Remove snooping of changes to focus 
				MonitorPanel(false);

				// Remove the child WindowContentTabbed 
				// BUG 발생 (AutoHostPanel의 Controls에서 WCT를 Remove시에 IFC에서 여러화면이 열린 경우(MdiChild) 현재 Active한 MdiChild가
				//첫번째가 아니어도 MdiForm.cs의 첫번째 Open한 MdiChild의 Activate가 발생하면서 Form_Activated Event가 발생하여
				//첫번째 화면으로 이동함. 
				ControlHelper.Remove(_currentPanel.Controls, _currentWCT);
				//_currentPanel.Controls.Remove(_currentWCT); //직접 Controls에서 Remove하는 TEST

				// Remove Panel from managed container
				ControlHelper.Remove(_manager.Container.Controls, _currentPanel);
				//_manager.Container.Controls.Remove(_currentPanel); //직접 Controls에서 Remove하는 TEST
			}

			
            
			if (_currentWCT != null)
			{            
				// Restore the original sizes
				_currentWCT.Width = _rememberRect.Width;
				_currentWCT.Height = _rememberRect.Height;
			}
                        
			if (_currentPanel != null)
			{
				// Destroy the panel
				_currentPanel.Dispose();
				_currentPanel = null;
			}
			
			//Remove후에 Remove전의 ActiveChild와 새로 설정된 ActiveMdiChild가 다르면 이전 MdiChild Activated
			//첫번째 MdiChild가 Active상태에서 Docking을 열었다가 두번쨰,세번째 MdiChild를 찍으면 이때는
			//먼저 두번째,세번째 MdiChild가 Activate된후에 이 Method가 Call되므로 이전과 이후가 같음
//			if ((activeChild != null) && (activeChild != containerForm.ActiveMdiChild))
//				activeChild.Activate();
		}

		protected void KillDisplayedWindow(WindowContentTabbed wct)
		{
			_killing = true;
            
			// Sometimes this method is called when _currentWCT is not set
			if (wct != null)
			{
				// Remove content objects from WCT to update state
				int count = wct.Contents.Count;
	            
				for(int index=0; index<count; index++)
				{
					// Remove it from collection
					wct.Contents.RemoveAt(0);
				}
	            
				// Get rid of the displayed Panel immediately
				RemoveDisplayedWindow();

				// No longer considered the shown window
				wct.Dispose();

				// Make sure instance reference is nulled where appropriate
				if (wct == _currentWCT)
					_currentWCT = null;
			}
            
			_killing = false;
		}

		protected void UpdateContentSize(int newVector, bool isWidth)
		{
			// Ensure we have a Panel to work with
			if (_currentPanel != null)
			{
				// Should always have WCT, but just in case...
				if (_currentWCT != null)
				{
					// Modify the remembered AutoHide vector
					foreach(Content c in _currentWCT.Contents)
					{
						// Get existing Size
						Size s = c.AutoHideSize;
                        
						// Update appropriate vector
						if (isWidth)
							s.Width = newVector;
						else
							s.Height = newVector;
                            
						// Save it away
						c.AutoHideSize = s;
					}
				}
			}
		}

		protected void DefineRectangles()
		{
			// Store original WCT size to be restored later
			_rememberRect = _currentWCT.ClientRectangle;        

			// Default showing size to that requested by WCT            
			_slideRect = _rememberRect;

			// Find actual available Form size for sliding into
			Rectangle availableSize = _manager.InnerResizeRectangle(this);
            
			// Reduce actual displayed size by limits of Form size
			if (availableSize.Width < _slideRect.Width)
				_slideRect.Width = availableSize.Width;

			if (availableSize.Height < _slideRect.Height)
				_slideRect.Height = availableSize.Height;
		}

		protected void SetFocusToWCT()
		{
			// Ensure we have a Panel to work with
			if (_currentPanel != null)
			{
				// If the Panel does not already contain the focus...
				if (_currentWCT != null)
				{
					if (!_currentWCT.ContainsFocus)
					{
						//원인을 알 수 없지만 Refresh할때 에러 발생
						try
						{
							_currentWCT.Focus();
							_currentWCT.Refresh();
						}
						catch{}
					}
				}
			}
		}
        
		protected void OnPageClicked(TabStub sender, int pageIndex)
		{
			//IFC용 Flag Reset
			this.isClickedWhenDisplayed = false;

			// Remove any showing auto hide windows except our own
			_manager.RemoveShowingAutoHideWindowsExcept(this);
            
			// A click is the same as an immediate hover over
			OnPageOver(sender, pageIndex);

			//2005.01.24 IFC 용 slideOut 상태에서 동일한 TabStub를 눌렀으면 Toggle 처리함
			if (this._slideOut && this.isSameTabStubClick)
			{
				//IFC용 Flag SET (Display된 상태에서 다시 Click -> Toggle 적용(OnPanelLeave)
				this.isClickedWhenDisplayed = true;
				//Display된 Window Remove
				OnPanelLeave(sender, EventArgs.Empty);
				return;
			}

			// A click implies the panel takes the focus immediately
			SetFocusToWCT();

			//IFC용 Content가 숨겨진 상태에서 다시 보이게 하는 Click이면, OnTabStubClickAtContentHidden 구동
			//판단은 _slideOut = true이고 SlideOut 상태에서 동일한 TabStub를 Click한 것이 아니면 숨겨진상태에서 Showing, false이면 이미 Showed된 상태임
			if (this._slideOut && !this.isSameTabStubClick)
				this.OnTabStubClickAtContentHidden(sender);

		}
		protected void OnPageOver(TabStub sender, int pageIndex)
		{
			//IFC용 동일한 TabStub Click 여부 Clear
			this.isSameTabStubClick = false;

			// Remove any showing auto hide windows except our own
			_manager.RemoveShowingAutoHideWindowsExcept(this);
            
			// Hovering over a different TabStub?
			if (_currentWCT != sender.WindowContentTabbed)
			{
				// Remove any currently displayed Panel/WCT
				if (_currentWCT != null)
				{
					RemoveDisplayedWindow();
				}
			}
			else
			{
				// Different tab in the same TabStub?
				if (pageIndex != _currentWCT.TabControl.SelectedIndex)
				{
					// Remove any currently displayed Panel/WCT
					if (_currentWCT != null)
					{
						RemoveDisplayedWindow();
					}
				}            
				else
				{
					// Hover over the current window, so do nothing
					//IFC용 동일한 TabStub Click 여부 Set
					this.isSameTabStubClick = true;
					return;
				}
			}

			Edge borderEdge = Edge.None;

			// Define which edge of the host panel shown have a border drawn
			switch(this.Dock)
			{
				case DockStyle.Left:
					borderEdge = Edge.Right;
					break;
				case DockStyle.Right:
					borderEdge = Edge.Left;
					break;
				case DockStyle.Top:
					borderEdge = Edge.Bottom;
					break;
				case DockStyle.Bottom:
					borderEdge = Edge.Top;
					break;
			}

			// Create a Panel that will host the actual WindowContentTabbed control,
			// the Panel is resized to slide into/from view. The WCT is a fixed size
			// within the Panel and so only the partial view of the WCT is shown and
			// at any point in time. Cannot resize the WCT into view as it would keep
			// repainting the caption details and effect and docking items inside it.
			_currentPanel = new AutoHostPanel(_manager, this, borderEdge);
            
			// Do not show it until we have resizing it as needed
			_currentPanel.Hide();                 
            
			// Get access to the WindowContentTabbed that is to be hosted
			_currentWCT = sender.WindowContentTabbed;

			//IFC용
			_currentWCT.CausesValidation = false;

			// Select the correct page for view in the WCT
			_currentWCT.TabControl.SelectedIndex = pageIndex;            
                
			// Place the WCT inside the host Panel
			_currentPanel.Controls.Add(_currentWCT);

			// Now add the Panel to the container display
			_manager.Container.Controls.Add(_currentPanel);
		    
			// Make it top of the Z-Order
			_manager.Container.Controls.SetChildIndex(_currentPanel, 0);

			// Define the remember and slide rectangle values
			DefineRectangles();

			// Set the modified WCT size
			_currentWCT.Width = _slideRect.Width;
			_currentWCT.Height = _slideRect.Height;

			Size barSize = _currentPanel.ResizeBarSize();

			// Set the initial size/location of Panel and hosted WCT
			switch(this.Dock)
			{
				case DockStyle.Left:
					_currentPanel.Size = new Size(0, this.Height);
					_currentPanel.Location = new Point(this.Right, this.Top);
					_currentWCT.Height = this.Height;
					break;
				case DockStyle.Right:
					_currentPanel.Size = new Size(0, this.Height);
					_currentPanel.Location = new Point(this.Left, this.Top);
					_currentWCT.Height = this.Height;
					break;
				case DockStyle.Top:
					_currentPanel.Size = new Size(this.Width, 0);
					_currentPanel.Location = new Point(this.Left, this.Bottom);
					_currentWCT.Width = this.Width;
					break;
				case DockStyle.Bottom:
					_currentPanel.Size = new Size(this.Width, 0);
					_currentPanel.Location = new Point(this.Left, this.Top);
					_currentWCT.Width = this.Width;
					break;
			}

			// Finally we are ready to show it
			_currentPanel.Show();
                
			// We want to snoop of changes of focus to and from Panel and its children
			MonitorPanel(true);

			//IFC용 Timer적용하지 않고 바로 Show
			ShowWindowContentTabbed();

			// 현재 Slide Out 됨
			_slideOut = true;
		}
        
		public void RemoveContent(Content c)
		{
			TabStub targetTS = null;
			IHIS.X.Magic.Controls.TabPage targetPage = null;
        
			// Find the TabStub group this content is inside
			foreach(TabStub ts in this.Controls)
			{
				// Test each page of the TabStub control
				foreach(IHIS.X.Magic.Controls.TabPage page in ts.TabPages)
				{
					Content pageC = page.Tag as Content;
                    
					if (pageC == c)
					{
						// Remember found target
						targetTS = ts;
						targetPage = page;
						break;
					}
				}
			}            
            
			// Found a target?
			if ((targetTS != null) && (targetPage != null))
			{
				// Are we removing the last entry in the WCT?
				if (targetTS.TabPages.Count == 1)
				{
					int count = targetTS.WindowContentTabbed.Contents.Count;
                    
					// Remove all contents from the WCT
					for(int i=0; i<count; i++)
						targetTS.WindowContentTabbed.Contents.RemoveAt(0);

					// If any panel/WCT showing
					if (targetTS.WindowContentTabbed == _currentWCT)
					{
						// Remove Panel/WCT from display and stop timers
						KillDisplayedWindow(_currentWCT);
					}
                                        
					// Remove the WCT from TabStub
					ControlHelper.Remove(targetTS.Controls, targetTS.WindowContentTabbed);

					// Remove the stub from this panel
					ControlHelper.Remove(this.Controls, targetTS);
                    
					// Cleanup gracefully
					targetTS.Dispose();                    
				}
				else
				{
					// Currently showing some pages?
					if (targetTS.WindowContentTabbed == _currentWCT)
					{
						bool found = false;
                    
						// Is it our page?
						foreach(Content cWCT in _currentWCT.Contents)
						{
							if (cWCT == c)
							{
								// Remove our page from view
								found = true;                     
								break;
							}
						}
                        
						// Remove unwanted page
						if (found)
						{
							// Find its position index
							int index = _currentWCT.Contents.IndexOf(c);
                        
							// Remove just the selected entry from stub
							targetTS.TabPages.RemoveAt(index);
                        
							// Remove the selected entry from WCT
							_currentWCT.Contents.RemoveAt(index);
						}
					}
                
					// Remove just the selected entry from stub
					targetTS.TabPages.Remove(targetPage);
				}

				// No longer inside an auto hidden panel                   
				c.AutoHidePanel = null;
			}

			// If no more contents remain then hide
			if (this.Controls.Count == 0)
				this.Hide();
		}
        
		protected void OnPageClose(object sender, EventArgs e)
		{
			// Find the TabStub instance for the showing WCT
			foreach(TabStub ts in this.Controls)
			{
				// Does this stub match the one showing?
				if (ts.WindowContentTabbed == _currentWCT)
				{
					ContentCollection cc = new ContentCollection();
                
					// Get access to Content instance being hidden
					Content current = _currentWCT.Contents[ts.SelectedIndex];
                    
					// Check if the hide button is allowed to work
					if (!_manager.OnContentHiding(current))
					{
						// Are we removing the last entry in the WCT?
						if (ts.TabPages.Count == 1)
						{
							// We need to update AutoHide property for all of them
							foreach(Content c in _currentWCT.Contents)
							{
								// Remember this AutoHide state for persistence
								c.RecordAutoHideRestore();

								cc.Add(c);
							}
                        
							// Remove Panel/WCT from display and stop timers
							KillDisplayedWindow(_currentWCT);

							// Remove the WCT from the WCT
							ControlHelper.Remove(ts.Controls, ts.WindowContentTabbed);

							// Remove the stub from this panel
							ControlHelper.Remove(this.Controls, ts);                    

							// Cleanup gracefully
							ts.Dispose();
						}
						else
						{
							// Which entry in the stub is currently selected?
							int index = ts.SelectedIndex;

							// Remember this AutoHide state for persistence
							_currentWCT.Contents[index].RecordAutoHideRestore();
							
							// Need to update AutoHide property for removed content
							cc.Add(_currentWCT.Contents[index]);

							// Remove just the selected entry from stub
							ts.TabPages.RemoveAt(index);
                            
							// Remove the selected entry from WCT
							_currentWCT.Contents.RemoveAt(index);
						}

						// Content instances no longer in AutoHidden state
						foreach(Content c in cc)
						{
							// No longer in the auto hidden mode                    
							c.AutoHidden = false;
							c.AutoHidePanel = null;
						}
					}
                    
					// Generate hidden event now content is not visible
					_manager.OnContentHidden(current);

					break;
				}
			}
            
			// If no more contents remain then hide
			if (this.Controls.Count == 0)
				this.Hide();
		}

		protected void OnPageAutoHide(object sender, EventArgs e)
		{
			UnAutoHideWindowContent(_currentWCT, false);
		}

		protected void UnAutoHideWindowContent(WindowContentTabbed wct, bool forceKill)
		{
			// Do not generate hiding/hidden/shown events
			_manager.SurpressVisibleEvents += 1;

			// Find the TabStub instance for the showing WCT
			foreach(TabStub ts in this.Controls)
			{
				// Does this stub match the one showing?
				if (ts.WindowContentTabbed == wct)
				{
					int count = ts.TabPages.Count;
                    
					// Record the auto hide state in reverse order, must record the state
					// before 'KillDisplayedWindow' as the process of recording state requires
					// the content to be inside a WindowContent instance
					for(int i=count-1; i>=0; i--)
					{
						// Get access to the content the page represents
						Content c = ts.TabPages[i].Tag as Content;

						// Remember this AutoHide state for persistence
						c.RecordAutoHideRestore();
					}
                        
					// Remove Panel/WCT from display and stop timers
					if (forceKill)
						KillDisplayedWindow(wct);
					else
						KillDisplayedWindow(_currentWCT);

					// Remove the stub from this panel
					ControlHelper.Remove(this.Controls, ts);
                    
					// Now that the Window/Panel have been killed we are ready to 
					// alter the AutoHidden state of each content and restore state
					for(int i=count-1; i>=0; i--)
					{
						// Get access to the content the page represents
						Content c = ts.TabPages[i].Tag as Content;

						// No longer in the auto hidden mode                    
						c.AutoHidden = false;
						c.AutoHidePanel = null;
                        
						// Restore into normal docked state
						_manager.ShowContent(c);
					}
                                        
					break;
				}
			}
            
			// If no more contents remain then hide
			if (this.Controls.Count == 0)
				this.Hide();

			// Enable generation hiding/hidden/shown events
			_manager.SurpressVisibleEvents -= 1;
		}
    
		protected void OnPageContextMenu(Point screenPos)
		{
			_manager.OnShowContextMenu(screenPos);
		}

		protected void ShowWindowContentTabbed()
		{
			if (this.IsDisposed || _currentPanel.IsDisposed || _currentWCT.IsDisposed)
				return;

			Rectangle rect = new Rectangle(_currentPanel.Left, _currentPanel.Top, 
				_currentPanel.Width, _currentPanel.Height);

			// How big is the resize bar inside the Panel?
			Size barSize = _currentPanel.ResizeBarSize();

			switch (this.Dock)
			{
				case DockStyle.Left:
					rect.Width = _slideRect.Width + barSize.Width;
					_currentWCT.Location = new Point(rect.Width - _currentWCT.Width - barSize.Width, 0);
					break;
				case DockStyle.Right:
					int right = _currentPanel.Right;
					rect.Width = _slideRect.Width + barSize.Width;
					rect.X -= rect.Right - right;
					_currentWCT.Location = new Point(barSize.Width, 0);
					break;
				case DockStyle.Top:
					rect.Height = _slideRect.Height + barSize.Height;
					// Want the bottom of the WCT showing
					_currentWCT.Location = new Point(0, rect.Height - _currentWCT.Height - barSize.Height);
					break;
				case DockStyle.Bottom:
					int bottom = _currentPanel.Bottom;
					rect.Height = _slideRect.Height + barSize.Height;
					rect.Y -= rect.Bottom - bottom;
					_currentWCT.Location = new Point(0, barSize.Height);
					break;
			}
			// Have to use Win32 API call to alter the Panel size and position at the same time, no 
			// Control method/property is available to do both at the same time. Otherwise you can see
			// the Panel being moved in two steps which looks naff!
			User32.MoveWindow(_currentPanel.Handle, rect.Left, rect.Top, rect.Width, rect.Height, true);
                    
			// If sliding into view from bottom
			if (this.Dock == DockStyle.Top)
			{
				// Must cause repaint to prevent artifacts
				_currentPanel.Refresh();
			}
			//PostFoucs (현재 Panel에 Focus)
			//User32.PostMessage(_currentPanel.Handle, (int) Win32.Msgs.WM_SETFOCUS, 0,0);
		}
		
		protected override void OnParentChanged(EventArgs e)
		{
			if (Parent != null)
				Parent.Resize += new EventHandler(OnContainerResized);
		}

		protected void OnContainerResized(object sender, EventArgs e)
		{
			RemoveShowingWindow();
		}

		public void RemoveShowingWindow()
		{
			_ignoreDismiss = false;

			// Is focus leaving the entire WindowContentTabbed control?
			if (_currentWCT != null)
			{
				// Remember current focus
				IntPtr hWnd = User32.GetFocus();

				// Remove Panel/WCT from display and stop timers
				RemoveDisplayedWindow();
                
				// No longer considered the shown window
				_currentWCT = null;

				// Replace the focus
				User32.SetFocus(hWnd);
			}	
            
			// Prevent drawing artifacts by invalidating window
			Invalidate();
		}

		protected void OnPanelEnter(object sender, EventArgs e)
		{
			_ignoreDismiss = true;
		}

		protected void OnPanelLeave(object sender, EventArgs e)
		{
			if (!this._slideOut) return;

			_ignoreDismiss = false;

			// Is focus leaving the entire WindowContentTabbed control?
			//2006.01.24 IFC isClickedWhenDisplayed(이미 DIsplay된 상태에서 다시 Panel Click시에는 상태 관계없이 Hide
			if (isClickedWhenDisplayed || (!_killing && (_currentWCT != null) && !_currentWCT.ContainsFocus))
			{
				// Remember current focus
				IntPtr hWnd = User32.GetFocus();
			
				// Remove Panel/WCT from display and stop timers
				RemoveDisplayedWindow();
                
				// No longer considered the shown window
				_currentWCT = null;

				// Replace the focus
				User32.SetFocus(hWnd);

				//SlideOut Flag Clear
				this._slideOut = false;
				//IFC용 동일한 TabStub Click 여부 Clear
				this.isSameTabStubClick = false;
			}
			//IFC용 Flag Reset
			this.isClickedWhenDisplayed = false;
		}
	
		protected void MonitorPanel(bool add)
		{
			MonitorControl(_currentPanel, add);
		}

		protected void MonitorControl(Control c, bool add)
		{
			if (add)
			{
				/*화면이나 폼위에 있는 컨트롤이 Popup창을 띄우는 컨트롤(ex : AMemoBox, ADateTimePicker, AFindBox)은
				 * Content가 자동숨기기 상태일때 Popup창을 띄우면 발생하는 LostFocus에 의해 Content가 숨어버리는
				 * 것을 방지하기 위해 Event Handling 하지 않음 */
				if (!(c is IPopupControl))
				{
					// Monitor focus changes on the Control
					c.GotFocus += new EventHandler(OnPanelEnter);
					c.LostFocus += new EventHandler(OnPanelLeave);
				}
			}
			else
			{
				if (!(c is IPopupControl))
				{
					// Unmonitor focus changes on the Control
					c.GotFocus -= new EventHandler(OnPanelEnter);
					c.LostFocus -= new EventHandler(OnPanelLeave);
				}
			}

			foreach(Control child in c.Controls)
				MonitorControl(child, add);
		}
        
		protected override void OnPaintBackground(PaintEventArgs e)
		{
//			Color backColor = base.BackColor;

//			if (_manager.Style == VisualStyle.IDE)
//			{
//				if (_defaultColor)
//					backColor = ColorHelper.TabBackgroundFromBaseColor(Color.FromArgb(242,247,252)); //Color.FromArgb(225,210,219));
//					//backColor = ColorHelper.TabBackgroundFromBaseColor(SystemColors.Control);
//				else
//					backColor = ColorHelper.TabBackgroundFromBaseColor(Color.FromArgb(242,247,252));
//					//backColor = ColorHelper.TabBackgroundFromBaseColor(backColor);
//			}
//			else if (_defaultColor)
//				backColor = SystemColors.Control;

			//IFC 용 2005.12.29 그라데이션 적용
			if (this.ClientRectangle.Width > 0 && this.ClientRectangle.Height > 0)
			{
				using (Brush br = new LinearGradientBrush(this.ClientRectangle, this.gradientStart, this.gradientEnd, LinearGradientMode.ForwardDiagonal))
					e.Graphics.FillRectangle(br, this.ClientRectangle);
			}
//			using(SolidBrush brush = new SolidBrush(backColor))
//				e.Graphics.FillRectangle(brush, this.ClientRectangle);
		}
        
		internal void HideContentWindow()
		{
			if (_currentPanel == null) return;
			
			// Use the current size/location as the starting point for changes
			Rectangle rect = new Rectangle(_currentPanel.Left, _currentPanel.Top, 
				_currentPanel.Width, _currentPanel.Height);

			// Move Window another step towards required position
			switch(this.Dock)
			{
				case DockStyle.Left:
				case DockStyle.Right:
					rect.Width = 0;
					break;
				case DockStyle.Top:
				case DockStyle.Bottom:
					rect.Height = 0;
					break;
			}
                    
			// Have to use Win32 API call to alter the Panel size and position at the same time, no 
			// Control method/property is available to do both at the same time. Otherwise you can see
			// the Panel being moved in two steps which looks naff!
			User32.MoveWindow(_currentPanel.Handle, rect.Left, rect.Top, rect.Width, rect.Height, true);

			// No longer need to show it
			RemoveDisplayedWindow();
                        
			// No longer considered the shown window
			_currentWCT = null;
		}

		internal void ResizeContentWindow(int oldWidth, int newWidth)
		{
			if (this._currentPanel == null) return;

			int delta = newWidth - oldWidth;
			this._currentPanel.EndResizeOperation(null, delta);

		}
	}
}
