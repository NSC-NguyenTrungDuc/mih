using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.X.Magic.Menus;

namespace IHIS.Framework
{
	#region MenuFunc Enum
	/// <summary>
	/// MenuItem 기능
	/// </summary>
	public enum MenuFunc
	{
		None		= 0,		// None
		// File Menu
		RegFavorite	= 100,		// 즐겨찾기 등록
		ViewMenu	= 101,		// TreeView Menu 보기
		RegenMenu	= 102,		// 메뉴재생성
		Leave		= 103,		// 이석(화면잠금)
		PrtScreen	= 104,		// 화면인쇄
		CapScreen	= 105,		// 화면캡쳐
		PrtSetup	= 106,		// Printer Setup
		Exit		= 107,		// 종료
		UserChange	= 108,		// 사용자 변경
		PswdChange	= 109,		// 비밀번호 변경
		AllClose	= 110,		// 화면일괄닫기
		CloseScreen	= 111,		// 화면닫기
		TRCode		= 112,		// TR code 입력
		UserInfo	= 113,		// 사용자 정보
		LogoutUser	= 114,		// 사용자 로그아웃
		ChangeSystem = 115,		// 업무전환
		SelectMonitor = 116,    // MDI 모니터 설정
		// Program
		Pgm			= 201,		// Program(화면)
		PgmGroup	= 202,		// Program Group(화면그룹)
		// MyMenu
		MyPgm		= 203,		// 즐겨찾기 등록 화면
		MyPgmGroup	= 204,		//즐겨찾기에 등록된 화면이 연결안된 메뉴

		//메세지
		ViewMsg		= 301,		// Message 확인
		SendMsg		= 302,		// Message 전송

		Others		= 999		// 기타
	}
	#endregion

	#region MenuItem
	/// <summary>
	/// MenuItem
	/// </summary>
	internal class MenuItem : IHIS.X.Magic.Menus.MenuCommand
	{
		protected MenuFunc	menuFunc;

		public MenuFunc MenuFunc
		{
			get { return menuFunc; }
		}

		/// <summary>
		/// MenuItem 생성자
		/// </summary>
		public MenuItem(string caption, EventHandler onClick, Shortcut shortcut, MenuFunc func, Image image, IList menuItems)
			: base(caption, image, shortcut, onClick)
		{
			menuFunc = func;

			if (menuItems != null)
			{
				menuItems.Add(this);
			}
		}

		/// <summary>
		/// MenuItem 생성자
		/// </summary>
		public MenuItem(string caption, EventHandler onClick, Shortcut shortcut, MenuFunc func, Image image)
			: this(caption, onClick, shortcut, func, image, null)
		{
		}

		/// <summary>
		/// MenuItem 생성자
		/// </summary>
		public MenuItem(string caption, EventHandler onClick, Shortcut shortcut, MenuFunc func, IList menuItems)
			: this(caption, onClick, shortcut, func, null, menuItems)
		{
		}

		/// <summary>
		/// MenuItem 생성자
		/// </summary>
		public MenuItem(string caption, EventHandler onClick, Shortcut shortcut, MenuFunc func)
			: this(caption, onClick, shortcut, func, null, null)
		{
		}

		/// <summary>
		/// MenuItem 생성자
		/// </summary>
		public MenuItem(string caption, EventHandler onClick, MenuFunc func, Image image, IList menuItems)
			: this(caption, onClick, Shortcut.None, func, image, menuItems)
		{
		}

		/// <summary>
		/// MenuItem 생성자
		/// </summary>
		public MenuItem(string caption, EventHandler onClick, MenuFunc func, Image image)
			: this(caption, onClick, Shortcut.None, func, image, null)
		{
		}

		/// <summary>
		/// MenuItem 생성자
		/// </summary>
		public MenuItem(string caption, EventHandler onClick, MenuFunc func)
			: this(caption, onClick, Shortcut.None, func, null, null)
		{
		}

		/// <summary>
		/// MenuItem 생성자
		/// </summary>
		public MenuItem(string caption, EventHandler onClick, MenuFunc func, IList menuItems)
			: this(caption, onClick, Shortcut.None, func, null, menuItems)
		{
		}

		/// <summary>
		/// MenuItem 생성자
		/// </summary>
		public MenuItem(string caption, MenuFunc func, IList menuItems)
			: this(caption, null, Shortcut.None, func, null, menuItems)
		{
		}

		/// <summary>
		/// MenuItem 생성자
		/// </summary>
		public MenuItem(string caption, MenuFunc func)
			: this(caption, null, Shortcut.None, func, null, null)
		{
		}

		/// <summary>
		/// MenuItem 생성자
		/// </summary>
		public MenuItem(string caption)
			: this(caption, null, Shortcut.None, MenuFunc.None, null, null)
		{
		}

		/// <summary>
		/// Enabled 속성 set
		/// </summary>
		/// <param name="enabled"></param>
		public void SetStatus(bool enabled)
		{
			this.Enabled = enabled;
		}

		/// <summary>
		/// Visible 속성 set
		/// </summary>
		/// <param name="visible"></param>
		public void SetVisible(bool visible)
		{
			this.Visible = visible;
		}

		/// <summary>
		/// 하위 MenuItem중에서 해당기능의 Item Return
		/// </summary>
		/// <param name="func"></param>
		/// <returns></returns>
		public virtual MenuItem GetMenuItemByFunc(MenuFunc func)
		{
			MenuItem	retItem = null;
			foreach (MenuItem menuItem in this.MenuCommands)
			{
				if (menuItem.MenuFunc == func)
				{
					retItem = menuItem;
					break;
				}
			}
			return retItem;
		}
	}
	#endregion

	#region ScreenMenuItem
	/// <summary>
	/// 화면 Menu Item
	/// </summary>
	internal class ScreenMenuItem : MenuItem
	{
		private string	menuTp;				//	Menu 구분
		private string	menuLevel;			//	Menu Level
		private string  menuParam = "";     //  Menu Parameter
		private ScreenInfo	menuScreenInfo;		//	Menu 화면 정보
		private IList parentMenuItems;   // 부모 메뉴의 MenuItems

		/// <summary>
		///	Menu 구분
		/// </summary>
		public string MenuTp
		{
			get { return menuTp; }
		}

		/// <summary>
		///	Menu Level
		/// </summary>
		public string MenuLevel
		{
			get { return menuLevel; }
		
		}

		public string MenuParam
		{
			get { return menuParam;}
		}

		/// <summary>
		///	Menu Pgm Info
		/// </summary>
		public ScreenInfo MenuScreenInfo
		{
			get { return menuScreenInfo; }
		}

		/// <summary>
		///	Menu Pgm Info
		/// </summary>
		public IList ParentMenuItems
		{
			get { return parentMenuItems; }
		}


		/// <summary>
		/// 화면 메뉴 생성자
		/// Menu명과 화면정보를 지정한다.
		/// </summary>
		public ScreenMenuItem(DataRow dtRow, EventHandler onClick, IList menuItems)
			: base("", onClick, MenuFunc.Pgm, menuItems)
		{
			/*dtRow는 총 15개 컬럼
			 * 메뉴Level + 메뉴구분(M,P) + 프로그램명 + TR_ID + 프로그램ID + 프로그램시스템ID + 진입권한 + 수정권한
			 * 비밀번호 + 중복오픈가능여부 + 오픈Style + ShortCut + 어셈블리명 + 어셈블리다운Path + 어셈블리버젼 + 메뉴Param
			 */
			menuScreenInfo = new ScreenInfo();
			menuLevel = dtRow[0].ToString();
			menuTp = dtRow[1].ToString();
			menuScreenInfo.Title = dtRow[2].ToString();
			menuScreenInfo.TrCode = dtRow[3].ToString();
			menuScreenInfo.PgmID = dtRow[4].ToString();
			menuScreenInfo.PgmSystemID = dtRow[5].ToString();
			if (TypeCheck.IsInt(dtRow[6].ToString()))
				menuScreenInfo.EntryPrivilege = int.Parse(dtRow[6].ToString());
			if (TypeCheck.IsInt(dtRow[7].ToString()))
				menuScreenInfo.UpdatePrivilege = int.Parse(dtRow[7].ToString());
			menuScreenInfo.Password = dtRow[8].ToString();
			menuScreenInfo.AlowDupl = (dtRow[9].ToString() == "Y");
			menuScreenInfo.OpenStyle = ScreenManager.GetOpenStyle(dtRow[10].ToString());
			//ShortCut SET (프로그램)
			if ((menuTp == "P") && (dtRow[11].ToString().Trim() != ""))
			{
				try
				{
					this.Shortcut = (Shortcut) Enum.Parse(typeof(Shortcut), dtRow[11].ToString().Trim());
				}
				catch
				{
					this.Shortcut = Shortcut.None;
				}
			}
			menuScreenInfo.AsmName = dtRow[12].ToString();
			menuScreenInfo.AsmPath = dtRow[13].ToString();
			menuScreenInfo.Version = dtRow[14].ToString();

			//2005.10.10 MenuParam Set
			this.menuParam = dtRow[15].ToString().Trim();

			this.Text = menuScreenInfo.Title;
			// 중간 Menu면 기능 None으로 Set
			if (menuTp == "M")
				menuFunc = MenuFunc.PgmGroup;

			// 부모 MenuItems 보관
			parentMenuItems = menuItems;
		}

        public ScreenMenuItem(MdiFormMenuItemInfo item, EventHandler onClick, IList menuItems)
            : base("", onClick, MenuFunc.Pgm, menuItems)
        {
            /*dtRow는 총 15개 컬럼
             * 메뉴Level + 메뉴구분(M,P) + 프로그램명 + TR_ID + 프로그램ID + 프로그램시스템ID + 진입권한 + 수정권한
             * 비밀번호 + 중복오픈가능여부 + 오픈Style + ShortCut + 어셈블리명 + 어셈블리다운Path + 어셈블리버젼 + 메뉴Param
             */
            menuScreenInfo = new ScreenInfo();
            menuLevel = item.MenuLevel;
            menuTp = item.MenuTp;
            menuScreenInfo.Title = item.PgmNm;
            menuScreenInfo.TrCode = item.TrId;
            menuScreenInfo.PgmID = item.PgmId;
            menuScreenInfo.PgmSystemID = item.PgmSysId;
            if (TypeCheck.IsInt(item.PgmEntGrad))
                menuScreenInfo.EntryPrivilege = int.Parse(item.PgmEntGrad);
            if (TypeCheck.IsInt(item.PgmUpdGrad))
                menuScreenInfo.UpdatePrivilege = int.Parse(item.PgmUpdGrad);
            menuScreenInfo.Password = item.PgmScrt;
            menuScreenInfo.AlowDupl = (item.PgmDupYn == "Y");
            menuScreenInfo.OpenStyle = ScreenManager.GetOpenStyle(item.PgmOpenTp);
            //ShortCut SET (프로그램)
            if ((menuTp == "P") && (item.ShortCut.Trim() != ""))
            {
                try
                {
                    this.Shortcut = (Shortcut)Enum.Parse(typeof(Shortcut), item.ShortCut.Trim());
                }
                catch
                {
                    this.Shortcut = Shortcut.None;
                }
            }
            menuScreenInfo.AsmName = item.AsmName;
            menuScreenInfo.AsmPath = item.AsmPath;
            menuScreenInfo.Version = item.AsmVer;

            //2005.10.10 MenuParam Set
            this.menuParam = item.MenuParam.Trim();

            this.Text = menuScreenInfo.Title;
            // 중간 Menu면 기능 None으로 Set
            if (menuTp == "M")
                menuFunc = MenuFunc.PgmGroup;

            // 부모 MenuItems 보관
            parentMenuItems = menuItems;
        }
	}
	#endregion

	#region MyMenuItem
	/// <summary>
	/// 화면 Menu Item
	/// </summary>
	internal class MyMenuItem : MenuItem
	{
		private MyMenuInfo menuInfo = null;
		private IList parentMenuItems;   // 부모 메뉴의 MenuItems

		/// <summary>
		/// 메뉴 정보
		/// </summary>
		public MyMenuInfo MenuInfo
		{
			get { return menuInfo;}
		}
		/// <summary>
		///	프로그램메뉴의 부모 메뉴Item
		/// </summary>
		public IList ParentMenuItems
		{
			get { return parentMenuItems; }
		}

		/// <summary>
		/// ScreenMenuItem 생성자
		/// Menu명과 PGM Menu Info를 지정한다.
		/// </summary>
		public MyMenuItem(DataRow dtRow, EventHandler onClick, IList menuItems)
			: base("", onClick, MenuFunc.MyPgm, menuItems)
		{
			menuInfo = new MyMenuInfo();
			/*dtRow는 총 7개 컬럼
			 * 메뉴Level + 메뉴구분(M,P) + TR_ID(MyMenuID) + 메뉴Title + 화면ID + 오픈Style + 메뉴Param
			 */
			menuInfo.MenuLevel		= dtRow[0].ToString();
			menuInfo.MenuTp			= dtRow[1].ToString();
			menuInfo.MenuID			= dtRow[2].ToString();
			menuInfo.MenuTitle		= dtRow[3].ToString();
			if (menuInfo.MenuTp == "P")  //Program과 연결된 메뉴
			{
				menuInfo.PgmID			= dtRow[4].ToString();
				menuInfo.OpenStyle		= ScreenManager.GetOpenStyle(dtRow[5].ToString());
				menuInfo.MenuParam		= dtRow[6].ToString().Trim();
				//Image Set
				this.Image = EnvironInfo.MdiForm.GetIcon("Program");
			}
			else  //중간메뉴이면 기능이 없는 MyPgmGroup으로 설정
			{
				menuFunc = MenuFunc.MyPgmGroup;
				this.Image = EnvironInfo.MdiForm.GetIcon("CloseFolder");
			}
			
			//Title Set
			this.Text = menuInfo.MenuTitle;

			// 부모 MenuItems 보관
			parentMenuItems = menuItems;
		}
	}
	#endregion
}