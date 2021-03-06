using System;
using System.Collections.Generic;
using System.Xml;
using System.IO;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Resources;
using System.Reflection;
using System.Runtime.InteropServices;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Arguments.System;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.X.Magic.Menus;

namespace IHIS.Framework
{
	/// <summary>
	/// MenuViewForm에 대한 요약 설명입니다.
	/// </summary>
	internal class MenuViewForm : System.Windows.Forms.Form
	{
		// Timer for scrolling
		private Timer timer = new Timer();
		private TreeNode tempDropNode = null; //DragDrop중에 이동중인 DropNode
		private MenuTreeNode tnMyMenuRoot = null;  //MyMenu의 Root
		private	MenuTreeNode tnSystemRoot = null;  //System Menu의 Root

		//PopUp Menu
		private IHIS.X.Magic.Menus.PopupMenu popupMenu = new IHIS.X.Magic.Menus.PopupMenu();
		private IHIS.X.Magic.Menus.PopupMenu popupMenu1 = new IHIS.X.Magic.Menus.PopupMenu();
		private IHIS.X.Magic.Menus.PopupMenu popupMenu2 = new IHIS.X.Magic.Menus.PopupMenu();

		private System.Windows.Forms.Splitter splitter1;
		private IHIS.X.Magic.Menus.MenuControl objMenu = null;
		private IHIS.Framework.XTreeView tvwMenu;
		private IHIS.Framework.XTabControl menuTab;
		private IHIS.X.Magic.Controls.TabPage tPageSearch;
		private IHIS.X.Magic.Controls.TabPage tPageResult;
		private System.Windows.Forms.ListView lvwResult;
		private IHIS.Framework.XTextBox txtSearch;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.Label lbTitle;
		private System.Windows.Forms.ImageList imageList;
		private System.Windows.Forms.ImageList imageListDrag;
		private IHIS.Framework.XButton btnRegen;
		private IHIS.Framework.XButton btnClose;
		private System.ComponentModel.IContainer components;

		public MenuViewForm(IHIS.X.Magic.Menus.MenuControl objMenu)
		{
			this.objMenu = objMenu;

			//
			// Windows Form 디자이너 지원에 필요합니다.
			//
			InitializeComponent();

			SetControlTextByLangMode();

			ResourceManager rmImage = new ResourceManager("IHIS.Framework.IHISImage", Assembly.GetExecutingAssembly());
			imageList.Images.Add((Image)rmImage.GetObject("Menu"));
			imageList.Images.Add((Image)rmImage.GetObject("CloseFolder"));
			imageList.Images.Add((Image)rmImage.GetObject("OpenFolder"));
			imageList.Images.Add((Image)rmImage.GetObject("Program"));
			imageList.Images.Add((Image)rmImage.GetObject("Query"));
			imageList.Images.Add((Image)rmImage.GetObject("Search"));

			//popUpMenu 생성 (새폴더,삭제,이름바꾸기)
			string title = XMsg.GetField("F033"); // 새메뉴
			popupMenu.MenuCommands.Add(new IHIS.X.Magic.Menus.MenuCommand(title,(Image)rmImage.GetObject("CloseFolder"), new EventHandler(MakeNewFolder)));
			title = XMsg.GetField("F034"); // 타이틀바꾸기
			popupMenu.MenuCommands.Add(new IHIS.X.Magic.Menus.MenuCommand(title,(Image)rmImage.GetObject("Modify"), new EventHandler(ChangeTitle)));
			title = XMsg.GetField("F035"); // 메뉴삭제
			popupMenu.MenuCommands.Add(new IHIS.X.Magic.Menus.MenuCommand(title,(Image)rmImage.GetObject("Delete"), new EventHandler(DeleteFolder)));

			//popupMenu1 생성(새폴더)
			title = XMsg.GetField("F033"); // 새메뉴
			popupMenu1.MenuCommands.Add(new IHIS.X.Magic.Menus.MenuCommand(title,(Image)rmImage.GetObject("CloseFolder"), new EventHandler(MakeNewFolder)));
			//popupMenu2 생성(삭제)
			title = XMsg.GetField("F035"); // 메뉴삭제
			popupMenu2.MenuCommands.Add(new IHIS.X.Magic.Menus.MenuCommand(title,(Image)rmImage.GetObject("Delete"), new EventHandler(DeleteFolder)));

			timer.Interval = 200;
			timer.Tick += new EventHandler(timer_Tick);

		}

		/// <summary>
		/// 사용 중인 모든 리소스를 정리합니다.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다.
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(MenuViewForm));
			this.menuTab = new IHIS.Framework.XTabControl();
			this.imageList = new System.Windows.Forms.ImageList(this.components);
			this.tPageSearch = new IHIS.X.Magic.Controls.TabPage();
			this.txtSearch = new IHIS.Framework.XTextBox();
			this.lbTitle = new System.Windows.Forms.Label();
			this.tPageResult = new IHIS.X.Magic.Controls.TabPage();
			this.lvwResult = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.tvwMenu = new IHIS.Framework.XTreeView();
			this.imageListDrag = new System.Windows.Forms.ImageList(this.components);
			this.btnRegen = new IHIS.Framework.XButton();
			this.btnClose = new IHIS.Framework.XButton();
			this.menuTab.SuspendLayout();
			this.tPageSearch.SuspendLayout();
			this.tPageResult.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuTab
			// 
			this.menuTab.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.menuTab.HotTrack = true;
			this.menuTab.IDEPixelArea = true;
			this.menuTab.IDEPixelBorder = false;
			this.menuTab.ImageList = this.imageList;
			this.menuTab.Location = new System.Drawing.Point(0, 430);
			this.menuTab.Name = "menuTab";
			this.menuTab.SelectedIndex = 0;
			this.menuTab.SelectedTab = this.tPageSearch;
			this.menuTab.Size = new System.Drawing.Size(272, 160);
			this.menuTab.TabIndex = 0;
			this.menuTab.TabPages.AddRange(new IHIS.X.Magic.Controls.TabPage[] {
																				   this.tPageSearch,
																				   this.tPageResult});
			// 
			// imageList
			// 
			this.imageList.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// tPageSearch
			// 
			this.tPageSearch.BackColor = System.Drawing.SystemColors.Control;
			this.tPageSearch.Controls.Add(this.txtSearch);
			this.tPageSearch.Controls.Add(this.lbTitle);
			this.tPageSearch.ImageIndex = 5;
			this.tPageSearch.ImageList = this.imageList;
			this.tPageSearch.Location = new System.Drawing.Point(0, 25);
			this.tPageSearch.Name = "tPageSearch";
			this.tPageSearch.Size = new System.Drawing.Size(272, 135);
			this.tPageSearch.TabIndex = 3;
			this.tPageSearch.Title = "검색";
			// 
			// txtSearch
			// 
			this.txtSearch.Location = new System.Drawing.Point(56, 56);
			this.txtSearch.MaxLength = 20;
			this.txtSearch.Name = "txtSearch";
			this.txtSearch.Size = new System.Drawing.Size(160, 20);
			this.txtSearch.TabIndex = 1;
			this.txtSearch.Validated += new System.EventHandler(this.txtSearch_Validated);
			// 
			// lbTitle
			// 
			this.lbTitle.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.lbTitle.Location = new System.Drawing.Point(56, 32);
			this.lbTitle.Name = "lbTitle";
			this.lbTitle.Size = new System.Drawing.Size(160, 23);
			this.lbTitle.TabIndex = 0;
			this.lbTitle.Text = "검색대상 화면명";
			// 
			// tPageResult
			// 
			this.tPageResult.Controls.Add(this.lvwResult);
			this.tPageResult.ImageIndex = 4;
			this.tPageResult.ImageList = this.imageList;
			this.tPageResult.Location = new System.Drawing.Point(0, 25);
			this.tPageResult.Name = "tPageResult";
			this.tPageResult.Selected = false;
			this.tPageResult.Size = new System.Drawing.Size(272, 135);
			this.tPageResult.TabIndex = 4;
			this.tPageResult.Title = "검색결과";
			// 
			// lvwResult
			// 
			this.lvwResult.AutoArrange = false;
			this.lvwResult.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						this.columnHeader1});
			this.lvwResult.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvwResult.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.lvwResult.LargeImageList = this.imageList;
			this.lvwResult.Location = new System.Drawing.Point(0, 0);
			this.lvwResult.MultiSelect = false;
			this.lvwResult.Name = "lvwResult";
			this.lvwResult.Size = new System.Drawing.Size(272, 135);
			this.lvwResult.SmallImageList = this.imageList;
			this.lvwResult.StateImageList = this.imageList;
			this.lvwResult.TabIndex = 0;
			this.lvwResult.View = System.Windows.Forms.View.Details;
			this.lvwResult.DoubleClick += new System.EventHandler(this.lvwResult_DoubleClick);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "화면명";
			this.columnHeader1.Width = 250;
			// 
			// splitter1
			// 
			this.splitter1.BackColor = System.Drawing.Color.Khaki;
			this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.splitter1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.splitter1.Location = new System.Drawing.Point(0, 426);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(272, 4);
			this.splitter1.TabIndex = 1;
			this.splitter1.TabStop = false;
			// 
			// tvwMenu
			// 
			this.tvwMenu.AllowDrop = true;
			this.tvwMenu.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tvwMenu.ImageList = this.imageList;
			this.tvwMenu.Indent = 19;
			this.tvwMenu.ItemHeight = 16;
			this.tvwMenu.Location = new System.Drawing.Point(0, 0);
			this.tvwMenu.Name = "tvwMenu";
			this.tvwMenu.Size = new System.Drawing.Size(272, 426);
			this.tvwMenu.TabIndex = 2;
			this.tvwMenu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tvwMenu_KeyDown);
			this.tvwMenu.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvwMenu_BeforeExpand);
			this.tvwMenu.DragOver += new System.Windows.Forms.DragEventHandler(this.tvwMenu_DragOver);
			this.tvwMenu.DragDrop += new System.Windows.Forms.DragEventHandler(this.tvwMenu_DragDrop);
			this.tvwMenu.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.tvwMenu_AfterLabelEdit);
			this.tvwMenu.DoubleClick += new System.EventHandler(this.tvwMenu_DoubleClick);
			this.tvwMenu.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tvwMenu_MouseUp);
			this.tvwMenu.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.tvwMenu_ItemDrag);
			this.tvwMenu.DragEnter += new System.Windows.Forms.DragEventHandler(this.tvwMenu_DragEnter);
			this.tvwMenu.DragLeave += new System.EventHandler(this.tvwMenu_DragLeave);
			this.tvwMenu.GiveFeedback += new System.Windows.Forms.GiveFeedbackEventHandler(this.tvwMenu_GiveFeedback);
			// 
			// imageListDrag
			// 
			this.imageListDrag.ImageSize = new System.Drawing.Size(16, 16);
			this.imageListDrag.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// btnRegen
			// 
			this.btnRegen.Enabled = false;
			this.btnRegen.Image = ((System.Drawing.Image)(resources.GetObject("btnRegen.Image")));
			this.btnRegen.Location = new System.Drawing.Point(2, 0);
			this.btnRegen.Name = "btnRegen";
			this.btnRegen.Scheme = IHIS.Framework.XButtonSchemes.Silver;
			this.btnRegen.Size = new System.Drawing.Size(186, 26);
			this.btnRegen.TabIndex = 3;
			this.btnRegen.Text = "마이메뉴 메뉴에 반영";
			this.btnRegen.Visible = false;
			this.btnRegen.Click += new System.EventHandler(this.btnRegen_Click);
			// 
			// btnClose
			// 
			this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
			this.btnClose.Location = new System.Drawing.Point(200, 0);
			this.btnClose.Name = "btnClose";
			this.btnClose.Scheme = IHIS.Framework.XButtonSchemes.OliveGreen;
			this.btnClose.Size = new System.Drawing.Size(72, 26);
			this.btnClose.TabIndex = 4;
			this.btnClose.Text = "닫 기";
			this.btnClose.Visible = false;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// MenuViewForm
			// 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(272, 590);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.btnRegen);
			this.Controls.Add(this.tvwMenu);
			this.Controls.Add(this.splitter1);
			this.Controls.Add(this.menuTab);
			this.Font = new System.Drawing.Font("MS UI Gothic", 9.75F);
			this.Name = "MenuViewForm";
			this.Text = "MenuViewForm";
			this.menuTab.ResumeLayout(false);
			this.tPageSearch.ResumeLayout(false);
			this.tPageResult.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region OnLoad
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);

			// Menu로 TreeView 작성
			if (!this.DesignMode)
				SetMenuTree();
		}
		#endregion

		#region 메뉴 생성 관련
		/// <summary>
		/// Menu로 TreeView 작성
		/// </summary>
		public virtual void SetMenuTree()
		{
			try
			{
				lvwResult.Items.Clear();
				tvwMenu.Nodes.Clear();
				//마이메뉴 Tree 생성
				string title = "[" + UserInfo.UserName + "]" + XMsg.GetField("F031");  //"[" + UserInfo.UserName + "]님 즐겨찾기"
				this.tnMyMenuRoot = new MenuTreeNode(NodeType.MyMenuRoot, NodeType.MyMenuRoot, title,0,0);
				CreateMyMenuTree(tnMyMenuRoot);
				tvwMenu.Nodes.Add(tnMyMenuRoot);
				//시스템메뉴 Tree 생성 업무시스템 메뉴";
				title = XMsg.GetField("F036"); // [업무시스템 메뉴]
				this.tnSystemRoot = new MenuTreeNode(NodeType.SysMenuRoot, NodeType.SysMenuRoot, title,0,0);
				CreateSystemMenuTree(tnSystemRoot, objMenu.MenuCommands);
				tvwMenu.Nodes.Add(tnSystemRoot);

				//Expand
				tnMyMenuRoot.ExpandAll();
				tnSystemRoot.Expand();
			}
			catch{}
		}

		private void CreateMyMenuTree(MenuTreeNode tn)
		{
			try
			{
				/*마이메뉴 생성 순서
				 * PR_ADM_GEN_MY_MENU Call 마이메뉴 생성
				 * ADM4500(사용자 즐겨찾기 메뉴) 조회하여 즐겨찾기 메뉴 구성
				 */
				/*string spName = "PR_ADM_GEN_MY_MENU";
				//Input = 사용자 ID
				//실패시 Msg Set
				if (!Service.ExecuteProcedure(spName, UserInfo.UserID))
				{
					SetErrMsg(Service.ErrMsg);
					return;
				}

				string cmdText 
					= "SELECT MENU_TP, MENU_LEVEL, TR_ID, MENU_TITLE, PGM_ID, PGM_OPEN_TP, MENU_PARAM "
					+ "  FROM ADM4500 A"
                    + " WHERE A.HOSP_CODE  = '" + EnvironInfo.HospCode + "'"
                    + "   AND A.USER_ID = '" + UserInfo.UserID + "'";
			
				DataTable table = Service.ExecuteDataTable(cmdText);
				if (table == null)  //조회 실패
				{
					SetErrMsg(Service.ErrMsg);
					return;
				}
				MyMenuInfo info = null;
				MenuTreeNode mNode = null, mNode1 = null, mNode2 = null,mNode3 = null,mNode4 = null,mNode5 = null,
					mNode6 = null,mNode7 = null,mNode8 = null,mNode9 = null,mNode10 = null;
				foreach (DataRow dtRow in table.Rows)
				{
					info = new MyMenuInfo();
					info.MenuTp = dtRow[0].ToString();
					info.MenuLevel = dtRow[1].ToString();
					info.MenuID	   = dtRow[2].ToString();
					info.MenuTitle = dtRow[3].ToString();
					info.PgmID = dtRow[4].ToString();
					info.OpenStyle = ScreenManager.GetOpenStyle(dtRow[5].ToString());
					info.MenuParam = dtRow[6].ToString().Trim();

					//Tag에 MyMenuInfo 저장
					if (info.MenuTp == "M")  //Menu (마이메뉴 Sub Menu)
					{
						mNode = new MenuTreeNode(NodeType.MyMenuRoot, NodeType.MyMenuSub, info.MenuTitle, 1,2);
						mNode.Tag = info;
					}
					else  //Program 메뉴
					{
						mNode = new MenuTreeNode(NodeType.MyMenuRoot, NodeType.MyMenuScreen, info.MenuTitle, 3,3);
						mNode.Tag = info;
					}

					//Menu Level에 따라 Add
					switch (info.MenuLevel)
					{
						case "1":
							mNode1 = mNode;
							tn.Nodes.Add(mNode1);
							break;
						case "2":
							mNode2 = mNode;
							if (mNode1 != null)
								mNode1.Nodes.Add(mNode2);
							break;
						case "3":
							mNode3 = mNode;
							if (mNode2 != null)
								mNode2.Nodes.Add(mNode3);
							break;
						case "4":
							mNode4 = mNode;
							if (mNode3 != null)
								mNode3.Nodes.Add(mNode4);
							break;
						case "5":
							mNode5 = mNode;
							if (mNode4 != null)
								mNode4.Nodes.Add(mNode5);
							break;
						case "6":
							mNode6 = mNode;
							if (mNode5 != null)
								mNode5.Nodes.Add(mNode6);
							break;
						case "7":
							mNode7 = mNode;
							if (mNode6 != null)
								mNode6.Nodes.Add(mNode7);
							break;
						case "8":
							mNode8 = mNode;
							if (mNode7 != null)
								mNode7.Nodes.Add(mNode8);
							break;
						case "9":
							mNode9 = mNode;
							if (mNode8 != null)
								mNode8.Nodes.Add(mNode9);
							break;
						case "10":
							mNode10 = mNode;
							if (mNode9 != null)
								mNode9.Nodes.Add(mNode10);
							break;
					}
				}*/
                // Cloud service
                MenuViewFormArgs args = new MenuViewFormArgs();
			    args.UserId = UserInfo.UserID;
                
                //Input = 사용자 ID
                //실패시 Msg Set
			    MenuViewFormResult result = CloudService.Instance.Submit<MenuViewFormResult, MenuViewFormArgs>(args);
                if (!result.Result)
                {
                    SetErrMsg(result.Msg);
                    return;
                }

			    List<MenuViewFormItemInfo> itemList = result.MenuViewFormItemInfo;

                if (itemList == null || itemList.Count == 0)  //조회 실패
                {
                    return;
                }
                MyMenuInfo info = null;
                MenuTreeNode mNode = null, mNode1 = null, mNode2 = null, mNode3 = null, mNode4 = null, mNode5 = null,
                    mNode6 = null, mNode7 = null, mNode8 = null, mNode9 = null, mNode10 = null;
                foreach (MenuViewFormItemInfo item in itemList)
                {
                    info = new MyMenuInfo();
                    info.MenuTp = item.MenuTp;
                    info.MenuLevel = item.MenuLevel;
                    info.MenuID = item.TrId;
                    info.MenuTitle = item.MenuTitle;
                    info.PgmID = item.PgmId;
                    info.OpenStyle = ScreenManager.GetOpenStyle(item.PgmOpenTp);
                    info.MenuParam = item.MenuParam.Trim();

                    //Tag에 MyMenuInfo 저장
                    if (info.MenuTp == "M")  //Menu (마이메뉴 Sub Menu)
                    {
                        mNode = new MenuTreeNode(NodeType.MyMenuRoot, NodeType.MyMenuSub, info.MenuTitle, 1, 2);
                        mNode.Tag = info;
                    }
                    else  //Program 메뉴
                    {
                        mNode = new MenuTreeNode(NodeType.MyMenuRoot, NodeType.MyMenuScreen, info.MenuTitle, 3, 3);
                        mNode.Tag = info;
                    }

                    //Menu Level에 따라 Add
                    switch (info.MenuLevel)
                    {
                        case "1":
                            mNode1 = mNode;
                            tn.Nodes.Add(mNode1);
                            break;
                        case "2":
                            mNode2 = mNode;
                            if (mNode1 != null)
                                mNode1.Nodes.Add(mNode2);
                            break;
                        case "3":
                            mNode3 = mNode;
                            if (mNode2 != null)
                                mNode2.Nodes.Add(mNode3);
                            break;
                        case "4":
                            mNode4 = mNode;
                            if (mNode3 != null)
                                mNode3.Nodes.Add(mNode4);
                            break;
                        case "5":
                            mNode5 = mNode;
                            if (mNode4 != null)
                                mNode4.Nodes.Add(mNode5);
                            break;
                        case "6":
                            mNode6 = mNode;
                            if (mNode5 != null)
                                mNode5.Nodes.Add(mNode6);
                            break;
                        case "7":
                            mNode7 = mNode;
                            if (mNode6 != null)
                                mNode6.Nodes.Add(mNode7);
                            break;
                        case "8":
                            mNode8 = mNode;
                            if (mNode7 != null)
                                mNode7.Nodes.Add(mNode8);
                            break;
                        case "9":
                            mNode9 = mNode;
                            if (mNode8 != null)
                                mNode8.Nodes.Add(mNode9);
                            break;
                        case "10":
                            mNode10 = mNode;
                            if (mNode9 != null)
                                mNode9.Nodes.Add(mNode10);
                            break;
                    }
                }
			}
			catch(Exception xe)
			{
				SetErrMsg("CreateMyMenu Error[" + xe.Message + "]");	
			}
		}
		
		private void SetErrMsg(string msg)
		{
			if (EnvironInfo.MdiForm != null)
				EnvironInfo.MdiForm.SetMsg(msg, MsgType.Error);
		}

		/// <summary>
		///　시스템 메뉴로 Menu로 TreeView 작성 (Recursive Call)
		/// </summary>
		private void CreateSystemMenuTree(TreeNode tn, IHIS.X.Magic.Collections.MenuCommandCollection mc)
		{

			MenuTreeNode	tnChild;

			foreach (MenuItem menuItem in mc)
			{
				//업무관리, 환자리스트 메뉴는 제외
				string title1 = XMsg.GetField("F017"); // 업무관리
				string title2 = XMsg.GetField("F037"); // 환자리스트
				if ((menuItem.Text != title1) && (menuItem.Text != title2))
				{
					// Seperator가 아니고, Enable한 Menu만 구성
					if (menuItem.Text != "-")
					{
						if (menuItem is ScreenMenuItem)
						{
							if (((ScreenMenuItem) menuItem).MenuTp == "M") //SubMenu
								tnChild = new MenuTreeNode(NodeType.SysMenuRoot, NodeType.SysMenuSub, menuItem.Text, 1, 2);
							else  //Program
								tnChild = new MenuTreeNode(NodeType.SysMenuRoot, NodeType.SysMenuScreen, menuItem.Text, 3, 3);

							tnChild.Tag = menuItem;
							tn.Nodes.Add(tnChild);
							if (menuItem.MenuCommands.Count > 0)
								CreateSystemMenuTree(tnChild, menuItem.MenuCommands);

						}
					}
				}
			}
		}
		#endregion

		#region TreeView Event Handler
		/// <summary>
		/// Tree View Double Click시 처리
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tvwMenu_DoubleClick(object sender, System.EventArgs e)
		{
			TreeView tv = (TreeView)sender;
			MenuTreeNode tn = tv.SelectedNode as MenuTreeNode;
			if (tn != null)
			{
				//시스템메뉴에서 Click시와 마이메뉴에서 Click시 분기
				if (tn.RootNodeType == NodeType.SysMenuRoot)
				{
					MenuItem menuItem = (MenuItem)tn.Tag;
					if (menuItem != null)
					{
						menuItem.OnClick(EventArgs.Empty);
					}
				}
				else //MyMenu에서는 MyMenuScreen일때만 해당 화면 Call
				{
					if (tn.NodeType == NodeType.MyMenuScreen)
					{
						try
						{
							//타업무시스템에서 해당 화면을 열 수 있는지 Check
							MyMenuInfo mInfo = (MyMenuInfo) tn.Tag;
							if (mInfo.MenuParam.Trim() != "")  //MenuParameter가 있으면 MenuParameter로 OpenParam을 만들어
							{
								//2006.03.24 OpenCommand로 변경
								OpenCommand openCmd = new OpenCommand("MENU_PARAM");
								openCmd.Items.Add("MenuParam", mInfo.MenuParam);
								ScreenManager.OpenScreenWithCommand(this, mInfo.PgmID, mInfo.OpenStyle, ScreenAlignment.Default, openCmd);
							}
							else
							{
								ScreenManager.OpenScreen(this, mInfo.PgmID, mInfo.OpenStyle, ScreenAlignment.Default);
							}
						}
						catch(Exception xe)
						{
							SetErrMsg("tvwMenu_DoubleClick, Error=" + xe.Message);
						}
					}
				}
			}
		}
		private void tvwMenu_AfterLabelEdit(object sender, System.Windows.Forms.NodeLabelEditEventArgs e)
		{
			//LabelEdit후 동작제어(텍스트입력여부 Check)
			string msg = "";
			if (e.Label != null)
			{
				if (e.Label.Length > 0)
				{
					// 이상한 문자 Check
					if (e.Label.IndexOfAny(new char[]{'@','.', ',','!'}) == -1)
					{
						//한글포함 40byte를 초과할 수 없음
						int length = Service.BaseEncoding.GetByteCount(e.Label);
						if (length > 40)
						{
							e.CancelEdit = true;
							msg = XMsg.GetMsg("M013"); // 타이틀은 20자리를 초과할 수 없습니다.
							SetErrMsg(msg);
							e.Node.BeginEdit();

						}
						else
						{
							e.Node.EndEdit(false);
							//이름 변경 저장
							//변경서비스 Input= UserID + MenuID + MenuTitle
							string cmdText 
								= "UPDATE ADM4400 A"
                                + "   SET A.MENU_TITLE ='" + e.Label + "'"
                                + " WHERE A.HOSP_CODE  = '" + EnvironInfo.HospCode + "'"
                                + "   AND A.USER_ID = '" + UserInfo.UserID + "'"
                                + "   AND A.TR_ID   ='" + ((MyMenuInfo)e.Node.Tag).MenuID + "'";
							//Update
							Service.ExecuteNonQuery(cmdText);
							//마이메뉴 반영 버튼 활성화
							this.btnRegen.Enabled = true;
						}
					}
					else
					{
						e.CancelEdit = true;
						msg = XMsg.GetMsg("M014"); // 타이틀이 제대로 입력되지 않았습니다."
						SetErrMsg(msg);
						e.Node.BeginEdit();
					}

				}
				else
				{
					e.CancelEdit = true;
					msg = XMsg.GetMsg("M015"); // 타이틀이 입력되지 않았습니다."
					SetErrMsg(msg);
					e.Node.BeginEdit();
				}

				//Label Edit false
				tvwMenu.LabelEdit = false;
			}
		}

		private void tvwMenu_BeforeExpand(object sender, System.Windows.Forms.TreeViewCancelEventArgs e)
		{
			//선택노드 다시 설정
			tvwMenu.SelectedNode = e.Node;
		}
		private void tvwMenu_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			//Right button PopUpMenu Show
			//마이메뉴이면 PopUp
			if (e.Button == MouseButtons.Right)
			{
				MenuTreeNode tn = tvwMenu.GetNodeAt(e.X,e.Y) as MenuTreeNode;
				if (tn != null)
				{
					//Selected Node를 MouseUp한 Node로 설정
					tvwMenu.SelectedNode = tn;

					if (tn.RootNodeType == NodeType.MyMenuRoot)
					{
						//마이메뉴ROOT이면 새폴더메뉴만 PopUp, 마이메뉴화면이면 삭제만 PopUp, 마이메뉴서브이면 3가지 모두
						if (tn.NodeType == NodeType.MyMenuSub)
							popupMenu.TrackPopup(tvwMenu.PointToScreen(new Point(e.X, e.Y)));
						else if (tn.NodeType == NodeType.MyMenuRoot)
							popupMenu1.TrackPopup(tvwMenu.PointToScreen(new Point(e.X, e.Y)));
						else if (tn.NodeType == NodeType.MyMenuScreen)
							popupMenu2.TrackPopup(tvwMenu.PointToScreen(new Point(e.X, e.Y)));
					}
				}
			}
		}

		private void tvwMenu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			//F2 Key Label Edit
			//Delete Key 삭제확인후 Node삭제
			//Insert Key Child추가여부 확인후 ChildNode추가
			if(tvwMenu.SelectedNode != null)
			{
				if (e.KeyData == Keys.F2)
				{
					EditTreeNodeTitle();
				}
				else if (e.Control)
				{
					//Ctrl + Insert는 Insert
					if ((e.KeyData & Keys.Insert) == Keys.Insert)
					{
						InsertTreeNode();
					}
					else if ((e.KeyData & Keys.Delete) == Keys.Delete)  //Ctrl + Delete는 Delete
					{
						DeleteTreeNode();
					}
				}
			}
		}
		#endregion

		#region TreeView DragDrop
		private void tvwMenu_GiveFeedback(object sender, System.Windows.Forms.GiveFeedbackEventArgs e)
		{
			if ((e.Effect & DragDropEffects.Move) == DragDropEffects.Move)
			{
				// Show pointer cursor while dragging
				e.UseDefaultCursors = false;
				this.tvwMenu.Cursor = Cursors.Default;
			}
			else 
				e.UseDefaultCursors = true;
		}
		private void tvwMenu_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
		{
			if (e.Data.GetDataPresent(typeof(IHIS.Framework.MenuTreeNode)))
			{
				//업무시스템은 화면Node만 가능, 마이메뉴Root는 불가
				MenuTreeNode tn = (MenuTreeNode) e.Data.GetData(typeof(IHIS.Framework.MenuTreeNode));
				if ((tn.NodeType == NodeType.MyMenuRoot)
					||((tn.RootNodeType == NodeType.SysMenuRoot) && (tn.NodeType != NodeType.SysMenuScreen)))
					e.Effect = DragDropEffects.None;
				else
					e.Effect = DragDropEffects.Move;

				DragWorker.ImageList_DragEnter(this.tvwMenu.Handle, e.X - this.tvwMenu.Left,e.Y - this.tvwMenu.Top);

				// Enable timer for scrolling dragged item
				this.timer.Enabled = true;
			}
			else
				e.Effect = DragDropEffects.None;
		}
		private void tvwMenu_DragOver(object sender, System.Windows.Forms.DragEventArgs e)
		{
			// Compute drag position and move image
			Point formPt = this.PointToClient(new Point(e.X, e.Y));
			DragWorker.ImageList_DragMove(formPt.X - this.tvwMenu.Left, formPt.Y - this.tvwMenu.Top);

			// Get actual drop node
			TreeNode dropNode = this.tvwMenu.GetNodeAt(this.tvwMenu.PointToClient(new Point(e.X, e.Y)));
			if(dropNode == null)
			{
				e.Effect = DragDropEffects.None;
				return;
			}
			e.Effect = DragDropEffects.Move;
			// if mouse is on a new node select it
			if(this.tempDropNode != dropNode)
			{
				DragWorker.ImageList_DragShowNolock(false);
				this.tvwMenu.SelectedNode = dropNode;
				DragWorker.ImageList_DragShowNolock(true);
				tempDropNode = dropNode;
			}
		}

		private void tvwMenu_DragLeave(object sender, System.EventArgs e)
		{
			DragWorker.ImageList_DragLeave(this.tvwMenu.Handle);

			// Disable timer for scrolling dragged item
			this.timer.Enabled = false;
		}

		private void tvwMenu_ItemDrag(object sender, System.Windows.Forms.ItemDragEventArgs e)
		{
			if((e.Button == MouseButtons.Left) && (e.Item is TreeNode))
			{
				TreeNode dragNode = e.Item as TreeNode;
				tvwMenu.SelectedNode = dragNode;
				// Reset image list used for drag image
				this.imageListDrag.Images.Clear();
				this.imageListDrag.ImageSize = new Size(dragNode.Bounds.Size.Width + this.tvwMenu.Indent, dragNode.Bounds.Height);

				// Create new bitmap
				// This bitmap will contain the tree node image to be dragged
				Bitmap bmp = new Bitmap(dragNode.Bounds.Width + this.tvwMenu.Indent, dragNode.Bounds.Height);

				// Get graphics from bitmap
				Graphics gfx = Graphics.FromImage(bmp);

				// Draw node icon into the bitmap
				gfx.DrawImage(this.imageList.Images[dragNode.ImageIndex], 0, 0);

				// Draw node label into bitmap
				using (Brush brush = new SolidBrush(tvwMenu.ForeColor.Color))
					gfx.DrawString(dragNode.Text, this.tvwMenu.Font, brush, (float)this.tvwMenu.Indent, 1.0f);

				gfx.Dispose();

				// Add bitmap to imagelist
				this.imageListDrag.Images.Add(bmp);

				// Get mouse position in client coordinates
				Point p = this.tvwMenu.PointToClient(Control.MousePosition);

				// Compute delta between mouse position and node bounds
				int dx = p.X + this.tvwMenu.Indent - dragNode.Bounds.Left;
				int dy = p.Y - dragNode.Bounds.Top;
				
				// Begin dragging image
				if (DragWorker.ImageList_BeginDrag(this.imageListDrag.Handle, 0, dx, dy))
				{
					// Begin dragging
					this.tvwMenu.DoDragDrop(e.Item, DragDropEffects.Move);
					// End dragging image
					DragWorker.ImageList_EndDrag();
				}
			}
		}

		private void tvwMenu_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
		{
			// Unlock updates
			DragWorker.ImageList_DragLeave(this.tvwMenu.Handle);
			// Disable scroll timer
			this.timer.Enabled = false;

			//DragDrop 규칙
			//시스템메뉴에서 마이메뉴로 Drag할 수 있는 메뉴는 화면메뉴밖에 안된다. (DragEnter에서 Check)
			//마이메뉴의 Root는 Drag할 수 없다. (DragEnter에서 Check)
			//마이메뉴에서 시스템메뉴로는 Drag할 수 없다. (DragDrop에서 Check)
			//시스템메뉴에서 시스템메뉴로는 Drag할 수 없다.(DragDrop에서 Check)
			//마이메뉴에서 화면메뉴에 Child를 추가할 수 없다. (DragDrop에서 Check)
			//동일한 Parent의 아래로 이동하는 것은 불가 (DragDrop에서 Check)
			//업무시스템ScreenNode,마이메뉴ScreenNode를 마이메뉴 Root에는 추가불가(Sub에만 추가가능) (DragDrop에서 check)
			//부모Node를 자식 Node로 이동불가(DragDrop에서 Check)
			MenuTreeNode dragNode = null, dropNode = null;
			Point dropPt;
			
			//Message Clear
			SetErrMsg("");
			string msg = "";

			if(e.Data.GetDataPresent(typeof(IHIS.Framework.MenuTreeNode)))
			{
				dragNode = (MenuTreeNode) e.Data.GetData(typeof(IHIS.Framework.MenuTreeNode));
				dropPt = tvwMenu.PointToClient(new Point(e.X, e.Y));
				dropNode = tvwMenu.GetNodeAt(dropPt) as MenuTreeNode;
				if (dropNode != null)
				{
					if (dragNode.Equals(dropNode)) return;

					if ((dragNode.RootNodeType == NodeType.MyMenuRoot)
						&& (dropNode.RootNodeType == NodeType.SysMenuRoot))
					{
						msg = XMsg.GetMsg("M016"); // 마이메뉴에서 시스템메뉴로는 Drop할수 없습니다.
						SetErrMsg(msg);
						return;
					}

					if ((dragNode.RootNodeType == NodeType.SysMenuRoot)
						&& (dropNode.RootNodeType == NodeType.SysMenuRoot))
					{
						msg = XMsg.GetMsg("M017"); // 시스템메뉴에서 시스템메뉴로는 Drop할수 없습니다."
						SetErrMsg(msg);
						return;
					}
					
					//동일한 부모의 둘다 MyMenuTree일 경우에는 제외
					if (dropNode.NodeType == NodeType.MyMenuScreen)
					{
						msg = XMsg.GetMsg("M018"); // 화면메뉴아래에는 DragDrop할 수 없습니다."
						SetErrMsg(msg);
						return;
					}
					if (((dragNode.NodeType == NodeType.MyMenuScreen) || (dragNode.NodeType == NodeType.SysMenuScreen))
						&& (dropNode.NodeType == NodeType.MyMenuRoot))
					{
						msg = XMsg.GetMsg("M019"); // 화면메뉴는 마이메뉴 바로아래에 Drop할 수 없습니다."
						SetErrMsg(msg);
						return;
					}
					if (DragNodeIsParent(dragNode, dropNode))
					{
						msg = XMsg.GetMsg("M020"); // 부모노드를 자식노드에 Drop할 수 없습니다."
						SetErrMsg(msg);
						return;
					}

					//마이메뉴내에서 이동시는 Move, 시스템메뉴 -> 마이메뉴로 이동시는 Copy
					if (dragNode.RootNodeType == NodeType.SysMenuRoot)
						CopyTreeNode(dragNode, dropNode);
					else
						MoveTreeNode(dragNode, dropNode);
				}
			}
		}
		//Drag하는 Node가 DropNode의 Parent인지를 검색
		private bool DragNodeIsParent(TreeNode dragNode, TreeNode dropNode)
		{
			if (dropNode.Parent == null)
				return false;
			else if (dropNode.Parent == dragNode)
				return true;
			else
				return DragNodeIsParent(dragNode, dropNode.Parent);
		}
		//Move Node
		private void MoveTreeNode(MenuTreeNode sourceNode, MenuTreeNode targetNode)
		{
			//sourceNode의 이동전 ParentNode의 MenuID Get
			MenuTreeNode bfParentNode = sourceNode.Parent as MenuTreeNode;
			if (bfParentNode == null) return;
				
			string bfParentMenuID = "", afParentMenuID;
			//soureNode의 이전 Parent가 MyMenuRoot이면 ParentMenuID = ""
			if (bfParentNode.NodeType == NodeType.MyMenuRoot)
				bfParentMenuID = "";
			else  //Tag에 저장된 MenuID
				bfParentMenuID = ((MyMenuInfo)bfParentNode.Tag).MenuID;

			//Target이 MyMenuRoot이면 afParentMenuID = ""
			if (targetNode.NodeType == NodeType.MyMenuRoot)
				afParentMenuID = "";
			else
				afParentMenuID =  ((MyMenuInfo)targetNode.Tag).MenuID;

			MenuTreeNode cloneNode = sourceNode.Clone() as MenuTreeNode;
			targetNode.Nodes.Insert(0,cloneNode);
			sourceNode.Remove();
			targetNode.ExpandAll();

			//ProcName = PR_ADM_UPDATE_MY_MENU
			//Input= UserID + MenuID + 변경전부모MenuID + 변경후 부모MenuID
			Service.ExecuteProcedure("PR_ADM_UPDATE_MY_MENU", UserInfo.UserID, ((MyMenuInfo)sourceNode.Tag).MenuID, bfParentMenuID, afParentMenuID);

			//마이메뉴 반영 버튼 활성화
			this.btnRegen.Enabled = true;

		}
		//Copy Node
		private void CopyTreeNode(MenuTreeNode sourceNode, MenuTreeNode targetNode)
		{
			//Copy는 시스템메뉴의 화면메뉴만 Copy가능함으로 Clone으로 하지 않고,
			//새로 MenuTreeNode를 생성하여 SET (Title = 화면명
			string title = sourceNode.Text;
			MenuTreeNode tn = new MenuTreeNode(NodeType.MyMenuRoot, NodeType.MyMenuScreen, title, sourceNode.ImageIndex, sourceNode.SelectedImageIndex);
			//Tag에 MyMenuInfo Set
			MyMenuInfo info = new MyMenuInfo();
			ScreenMenuItem mItem = (ScreenMenuItem) sourceNode.Tag;
			info.MenuParam = mItem.MenuParam;
			info.MenuTitle = mItem.MenuScreenInfo.Title;
			info.MenuTp = "P";
			info.OpenStyle = mItem.MenuScreenInfo.OpenStyle;
			info.PgmID = mItem.MenuScreenInfo.PgmID;
			tn.Tag = info;
			
			//ProcName = PR_ADM_ADD_MY_MENU
			//Input= UserID + ParentMenuID + MenuTitle + PgmMenuYn(Y) + PgmMenuID
			//Output MenuID
			ArrayList inputList = new ArrayList();
			inputList.Add(UserInfo.UserID);
			inputList.Add(((MyMenuInfo)targetNode.Tag).MenuID);
			inputList.Add(title);  //TITLE
			inputList.Add("Y"); //화면과 연결된 메뉴 Y
			inputList.Add(mItem.MenuScreenInfo.PgmSystemID);  //화면 SystemID
			inputList.Add(mItem.MenuScreenInfo.TrCode);  //화면 TR_ID
					
			ArrayList outputList = new ArrayList();
			if (Service.ExecuteProcedure("PR_ADM_ADD_MY_MENU", inputList, outputList)) //성공
			{
				info.MenuID = outputList[0].ToString();
				targetNode.Nodes.Insert(0, tn);
				targetNode.ExpandAll();

				//마이메뉴 반영 버튼 활성화
				this.btnRegen.Enabled = true;
			}
		}
		#endregion

		#region ListView Event Handler
		/// <summary>
		/// 검색결과 Double Click시 처리
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void lvwResult_DoubleClick(object sender, System.EventArgs e)
		{
			ListView lv = (ListView)sender;
			if (lv != null)
			{
				ListViewItem li = lv.FocusedItem;
				if (li != null)
				{
					MenuItem menuItem = li.Tag as MenuItem;
					if (menuItem != null)
						menuItem.OnClick(EventArgs.Empty);
				}
			}
		}
		#endregion

		#region 메뉴 검색 관련
		/// <summary>
		/// 검색처리
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void txtSearch_Validated(object sender, System.EventArgs e)
		{
			if (this.txtSearch.Text.Trim() != string.Empty)
			{
				this.lvwResult.Items.Clear();
				//메뉴 검색 //MyMenu에서는 검색하지 않고, 시스템메뉴에서만 검색함
				SearchTree(this.tnSystemRoot.Nodes, txtSearch.Text.Trim());
				if (lvwResult.Items.Count == 0)
				{
					string title = XMsg.GetMsg("M021"); // 해당 화면이 없습니다.
					lvwResult.Items.Add(new ListViewItem(title));
				}
				this.menuTab.SelectedTab = tPageResult;
				this.lvwResult.Focus();
			}
		}

		/// <summary>
		/// TreeView 검색 (Recursive Call)
		/// </summary>
		private void SearchTree(TreeNodeCollection tc, string str)
		{
			ListViewItem	li;
			
			foreach (MenuTreeNode tnChild in tc)
			{
				if (tnChild.Text.IndexOf(str) >= 0)
				{
					MenuItem menuItem = (MenuItem)tnChild.Tag;
					if (menuItem != null)
					{
						if (menuItem.MenuFunc == MenuFunc.Pgm)
						{
							li = new ListViewItem(tnChild.Text, tnChild.ImageIndex);
							li.Tag = menuItem;
							lvwResult.Items.Add(li);
						}
					}
				}
				if (tnChild.Nodes.Count > 0)
					SearchTree(tnChild.Nodes, str);
			}
		}
		#endregion

		#region Lang Set
		private void SetControlTextByLangMode()
		{
			this.lbTitle.Text = XMsg.GetField("F038"); // 검색대상 화면명
			this.tPageSearch.Title = XMsg.GetField("F039"); // 검색
			this.tPageResult.Title = XMsg.GetField("F040"); // 검색결과
			this.columnHeader1.Text = XMsg.GetField("F041"); // 화면명
			this.txtSearch.ImeMode = (NetInfo.Language == LangMode.Ko ? ImeMode.Hangul : ImeMode.Hiragana);
			this.btnClose.Text = XMsg.GetField("F042"); // 닫 기
			this.btnRegen.Text = XMsg.GetField("F043"); // 즐겨찾기 메뉴에 적용
		}
		#endregion

		#region timer_Tick
		private void timer_Tick(object sender, EventArgs e)
		{
			// get node at mouse position
			Point pt = this.tvwMenu.PointToClient(Control.MousePosition);
			TreeNode node = this.tvwMenu.GetNodeAt(pt);

			if(node == null) return;

			// if mouse is near to the top, scroll up
			if(pt.Y < 30)
			{
				// set actual node to the upper one
				if (node.PrevVisibleNode!= null) 
				{
					node = node.PrevVisibleNode;
				
					// hide drag image
					DragWorker.ImageList_DragShowNolock(false);
					// scroll and refresh
					node.EnsureVisible();
					this.tvwMenu.Refresh();
					// show drag image
					DragWorker.ImageList_DragShowNolock(true);
					
				}
			}
				// if mouse is near to the bottom, scroll down
			else if(pt.Y > this.tvwMenu.Size.Height - 30)
			{
				if (node.NextVisibleNode!= null) 
				{
					node = node.NextVisibleNode;
				
					DragWorker.ImageList_DragShowNolock(false);
					node.EnsureVisible();
					this.tvwMenu.Refresh();
					DragWorker.ImageList_DragShowNolock(true);
				}
			} 
		}
		#endregion

		#region PopUpMenu Event Handlers, Method
		private void MakeNewFolder(object sender, System.EventArgs e)
		{
			InsertTreeNode();
		}
		private void ChangeTitle(object sender, System.EventArgs e)
		{
			EditTreeNodeTitle();
		}
		private void DeleteFolder(object sender, System.EventArgs e)
		{
			DeleteTreeNode();
		}

		/// <summary>
		/// 새노드를 삽입합니다.
		/// </summary>
		private void InsertTreeNode()
		{
			//Node 추가 규칙
			//1.업무시스템메뉴Node, 마이메뉴ScreenNode에는 추가불가
			//추가확인후 추가처리
			try
			{
				if (tvwMenu.SelectedNode != null)
				{
					MenuTreeNode tn = (MenuTreeNode) tvwMenu.SelectedNode;
					if ((tn.RootNodeType == NodeType.SysMenuRoot)
						||(tn.NodeType == NodeType.MyMenuScreen))
					{
						string msg = XMsg.GetMsg("M022"); // 추가할 수 없는 메뉴입니다.
						SetErrMsg(msg);
						return;
					}
					//노드 추가
					string title = XMsg.GetField("F033"); // 새메뉴
					MenuTreeNode tNode = new MenuTreeNode(NodeType.MyMenuRoot, NodeType.MyMenuSub, title, 1,2);
					
					//ProcName = PR_ADM_ADD_MY_MENU
					//Input= UserID + ParentMenuID + MenuTitle + PgmMenuYn(Y) + PgmMenuID
					//Output은 MenuID
					ArrayList inputList = new ArrayList();
					inputList.Add(UserInfo.UserID);
					if (tn.NodeType == NodeType.MyMenuRoot)
						inputList.Add("");
					else
						inputList.Add(((MyMenuInfo)tn.Tag).MenuID);
					inputList.Add(title);  //TITLE
					inputList.Add("N"); //화면과 연결된 메뉴가 아님
					inputList.Add("");  //화면 SYS_ID 는 없음
					inputList.Add("");  //화면 TR_ID 는 없음
					
					ArrayList outputList = new ArrayList();
					if (Service.ExecuteProcedure("PR_ADM_ADD_MY_MENU", inputList, outputList)) //성공
					{
						//Tag에 MyMenuInfo 저장 (화면 정보는 없음)
						MyMenuInfo info = new MyMenuInfo();
						info.MenuTp = "M";
						info.MenuTitle = title;
						info.MenuID = outputList[0].ToString();
						tNode.Tag = info;
						tn.Nodes.Insert(0,tNode);
						tn.Expand();

						//마이메뉴 반영 버튼 활성화
						this.btnRegen.Enabled = true;
					}
				}
			}
			catch(Exception e)
			{
				Debug.WriteLine("InsertTreeNode, Error=" + e.Message);
			}
		}
		/// <summary>
		/// 노드를 삭제합니다.
		/// </summary>
		private void DeleteTreeNode()
		{
			//Node 삭제규칙
			//업무시스템메뉴Node, RootNode는 삭제불가
			//삭제확인후 확인시 삭제처리
			if (tvwMenu.SelectedNode != null)
			{
				MenuTreeNode tn = (MenuTreeNode) tvwMenu.SelectedNode;
				if ((tn.RootNodeType == NodeType.SysMenuRoot)
					||(tn.NodeType == NodeType.MyMenuRoot))
				{
					string msg = XMsg.GetMsg("M023"); // 삭제할 수 없는 메뉴입니다.
					SetErrMsg(msg);
					return;
				}
				//ProcName = PR_ADM_DELETE_MY_MENU
				//Input= UserID + MenuID
				//Output 없음
				if (Service.ExecuteProcedure("PR_ADM_DELETE_MY_MENU", UserInfo.UserID, ((MyMenuInfo)tn.Tag).MenuID))
				{
					//성공시 해당 노드 삭제
					tn.Remove();
					//마이메뉴 반영 버튼 활성화
					this.btnRegen.Enabled = true;
				}
			}
		}
		private void EditTreeNodeTitle()
		{
			//Title 바꾸기 규칙
			//1.Title은 MyMenu의 SubMenu만 편집가능하다.
			if (tvwMenu.SelectedNode != null)
			{
				MenuTreeNode tn = (MenuTreeNode) tvwMenu.SelectedNode;
				if ((tn.RootNodeType == NodeType.SysMenuRoot)
					||(tn.NodeType != NodeType.MyMenuSub))
				{
					string msg = XMsg.GetMsg("M024"); // 타이틀을 편집할 수 없는 메뉴입니다.
					SetErrMsg(msg);
					return;
				}
				//Edit 시작
				tvwMenu.LabelEdit = true;
				if (!tn.IsEditing)
					tn.BeginEdit();
			}
		}
		#endregion

		#region Button Event
		private void btnRegen_Click(object sender, System.EventArgs e)
		{
			//마이메뉴 재생성
			if (EnvironInfo.MdiForm != null)
				EnvironInfo.MdiForm.RegenMyMenu();
			//다시 비활성화
			this.btnRegen.Enabled = false;
		}

		private void btnClose_Click(object sender, System.EventArgs e)
		{
			//Docking 된 메뉴보기 Hide
			string title = XMsg.GetField("F020"); // 메뉴보기
			if (EnvironInfo.MdiForm != null)
				EnvironInfo.MdiForm.HideDockingScreen(title);
		}
		#endregion
	}

	internal enum NodeType
	{
		MyMenuRoot,    //마이메뉴 Root
		SysMenuRoot,   //시스템메뉴 Root
		MyMenuSub,     //마이메뉴 Sub(화면연결안된 메뉴)
		SysMenuSub,    //시스템메뉴 Sub(시스템메뉴중 화면연결안된 메뉴)
		MyMenuScreen,  //마이메뉴중 화면연결된 메뉴
		SysMenuScreen  //시스템메뉴중 화면연결된 메뉴
	}

	internal class MenuTreeNode : TreeNode
	{
		private NodeType rootNodeType;
		private NodeType nodeType;

		public NodeType RootNodeType
		{
			get { return rootNodeType;}
			set { rootNodeType = value;}
		}
		public NodeType NodeType
		{
			get { return nodeType;}
			set { nodeType = value;}
		}
		public MenuTreeNode()
		{
		}

		public MenuTreeNode(NodeType rootNodeType, NodeType nodeType, string text, int imageIndex, int selectedImageIndex)
			:base(text, imageIndex, selectedImageIndex)
		{
			this.rootNodeType = rootNodeType;
			this.nodeType = nodeType;
		}
		/// <summary>
		/// Clone시 해당 Node의 NodeType을 그대로 설정(설정하지 않으면 MyMenuRoot로 설정됨)
		/// </summary>
		/// <returns></returns>
		public override object Clone()
		{
			MenuTreeNode tn = (MenuTreeNode) base.Clone();
			tn.NodeType = this.NodeType;
			return tn;
		}
	}

	/// <summary>
	/// DragWorker에 대한 요약 설명입니다.
	/// </summary>
	internal class DragWorker
	{
		[DllImport("comctl32.dll")]
		public static extern bool InitCommonControls();

		[DllImport("comctl32.dll", CharSet=CharSet.Auto)]
		public static extern bool ImageList_BeginDrag(IntPtr himlTrack, int
			iTrack, int dxHotspot, int dyHotspot);

		[DllImport("comctl32.dll", CharSet=CharSet.Auto)]
		public static extern bool ImageList_DragMove(int x, int y);

		[DllImport("comctl32.dll", CharSet=CharSet.Auto)]
		public static extern void ImageList_EndDrag();

		[DllImport("comctl32.dll", CharSet=CharSet.Auto)]
		public static extern bool ImageList_DragEnter(IntPtr hwndLock, int x, int y);

		[DllImport("comctl32.dll", CharSet=CharSet.Auto)]
		public static extern bool ImageList_DragLeave(IntPtr hwndLock);

		[DllImport("comctl32.dll", CharSet=CharSet.Auto)]
		public static extern bool ImageList_DragShowNolock(bool fShow);

		static DragWorker()
		{
			InitCommonControls();
		}
	}
}
