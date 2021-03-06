using System;

namespace IHIS.Framework
{
	/// <summary>
	/// 프로그램화면의 OpenStyle을 정의한 Enum입니다.
	/// </summary>
	public enum ScreenOpenStyle
	{
		/// <summary>
		/// Docking Style로 연다.
		/// </summary>
		Docking,
		/// <summary>
		/// MdiForm의 Child형식(MdiClient내에서만 이동가능)의 PopUp창으로 연다(Modalless형식, Sizable)
		/// </summary>
		PopUpSizable,
		/// <summary>
		/// MdiForm의 Child형식(MdiClient내에서만 이동가능)의 PopUp창으로 연다(Modalless형식, Fixed)
		/// </summary>
		PopUpFixed,
		/// <summary>
		/// MdiForm의 Child가 아닌 PopUp창으로 연다(Modal형식, Sizable)
		/// </summary>
		ResponseSizable,
		/// <summary>
		/// MdiForm의 Child가 아닌 PopUp창으로 연다(Modal형식, Fixed)
		/// </summary>
		ResponseFixed,
		/// <summary>
		/// MdiForm의 Child형식이 아닌(Mdi와 관계없이 이동가능) Popup창으로 연다(Modaless형식, Fixed)
		/// </summary>
		PopupSingleFixed,
		/// <summary>
		/// MdiForm의 Child형식이 아닌(Mdi와 관계없이 이동가능) Popup창으로 연다(Modaless형식, Sizable)
		/// </summary>
		PopupSingleSizable
	}

	/// <summary>
	/// 화면이 Popup으로 Open할때 화면의 위치를 정의한 Enum입니다.
	/// Screen은 모니터 기준, Parent는 MdiForm 기준
	/// </summary>
	public enum ScreenAlignment
	{
		/// <summary>
		/// 기본값 (Modal은 ScreenMiddleCenter, Modalless는 ParentTopLeft
		/// </summary>
		Default,
		/// <summary>
		/// 모니터 기준 TopLeft
		/// </summary>
		ScreenTopLeft,
		/// <summary>
		/// 모니터 기준 TopCenter
		/// </summary>
		ScreenTopCenter,
		/// <summary>
		/// 모니터 기준 TopRight
		/// </summary>
		ScreenTopRight,
		/// <summary>
		/// 모니터 기준 MiddleLeft
		/// </summary>
		ScreenMiddleLeft,
		/// <summary>
		/// 모니터 기준 MiddleCenter
		/// </summary>
		ScreenMiddleCenter,
		/// <summary>
		/// 모니터 기준 MiddleRight
		/// </summary>
		ScreenMiddleRight,
		/// <summary>
		/// 모니터 기준 BottomLeft
		/// </summary>
		ScreenBottomLeft,
		/// <summary>
		/// 모니터 기준 BottomCenter
		/// </summary>
		ScreenBottomCenter,
		/// <summary>
		/// 모니터 기준 BottomRight
		/// </summary>
		ScreenBottomRight,
		/// <summary>
		/// MdiForm 기준 TopLeft
		/// </summary>
		ParentTopLeft,
		/// <summary>
		/// MdiForm 기준 TopCenter
		/// </summary>
		ParentTopCenter,
		/// <summary>
		/// MdiForm 기준 TopRight
		/// </summary>
		ParentTopRight,
		/// <summary>
		/// MdiForm 기준 MiddleLeft
		/// </summary>
		ParentMiddleLeft,
		/// <summary>
		/// MdiForm 기준 MiddleCenter
		/// </summary>
		ParentMiddleCenter,
		/// <summary>
		/// MdiForm 기준 MiddleRight
		/// </summary>
		ParentMiddleRight,
		/// <summary>
		/// MdiForm 기준 BottomLeft
		/// </summary>
		ParentBottomLeft,
		/// <summary>
		/// MdiForm 기준 BottomCenter
		/// </summary>
		ParentBottomCenter,
		/// <summary>
		/// MdiForm 기준 BottomRight
		/// </summary>
		ParentBottomRight
	}
	/// <summary>
	/// 화면 정보
	/// </summary>
	internal class ScreenInfo
	{
		private string	title = "";				//	Title
		private string	trCode = "";			//	TR Code
		private string	pgmID = "";				//	PGM ID
		private string	pgmGroupID = "";				//	PGM 그룹 ID
		private string  pgmSystemID = "";       //  프로그램의 시스템ID
		private int		entryPrivilege = 0;		//	PGM 진입등급
		private int		updatePrivilege = 0;	//	PGM 수정등급
		private string	password = "";			//	PassWord
		private bool	alowDupl = false;		//	프로그램 복수 open 여부
		private ScreenOpenStyle openStyle = ScreenOpenStyle.PopUpSizable;  //화면 Open Style
		private string  asmName = "";
		private string  asmPath = "";
		private string	version = "0.0.0.0";//	Version
		private ScreenAlignment screenAlign = ScreenAlignment.Default;
		private bool    isMainScreen = false;   //시스템의 MainScreen으로 Open되었는지 여부
		/// <summary>
		///	Title
		/// </summary>
		public string Title
		{
			get { return title;	}
			set { title = value; }
		}

		/// <summary>
		///	TR Code
		/// </summary>
		public string TrCode
		{
			get { return trCode; }
			set { trCode = value; }
		}

		/// <summary>
		/// PGM ID
		/// </summary>
		public string PgmID
		{
			get { return pgmID; }
			set { pgmID = value; }
		}

		/// <summary>
		/// PGM GroupID
		/// </summary>
		public string PgmGroupID
		{
			get { return pgmGroupID; }
			set { pgmGroupID = value; }
		}

		/// <summary>
		/// PGM SystemID
		/// </summary>
		public string PgmSystemID
		{
			get { return pgmSystemID; }
			set { pgmSystemID = value; }
		}

		/// <summary>
		/// PGM 진입등급
		/// </summary>
		public int EntryPrivilege
		{
			get { return entryPrivilege; }
			set { entryPrivilege = value; }
		}

		/// <summary>
		/// PGM 수정등급
		/// </summary>
		public int UpdatePrivilege
		{
			get { return updatePrivilege; }
			set { updatePrivilege = value; }
		}

		/// <summary>
		/// PassWord
		/// </summary>
		public string Password
		{
			get { return password; }
			set { password = value; }
		}

		/// <summary>
		/// 프로그램 복수 open 여부
		/// </summary>
		public bool AlowDupl
		{
			get { return alowDupl; }
			set { alowDupl = value; }
		}
		/// <summary>
		/// 어셈블리 버전
		/// </summary>
		public string Version
		{
			get { return version; }
			set
			{
				if (value.IndexOf(".") <= 0)
					version = "0.0.0.0";
				else
					version = value;
			}
		}
		public string AsmName
		{
			get { return asmName; }
			set { asmName = value;}
		}
		public string AsmPath
		{
			get { return asmPath; }
			set { asmPath = value;}
		}
		/// <summary>
		///	화면 Open Style (Docking으로 열 것인지, PopUp으로 열 것인지여부
		/// </summary>
		public ScreenOpenStyle OpenStyle
		{
			get { return openStyle; }
			set { openStyle = value; }
		}

		public ScreenAlignment ScreenAlign
		{
			get { return screenAlign;}
			set { screenAlign = value;}
		}
		//2006.01.09 메인화면여부 속성추가
		public bool IsMainScreen
		{
			get { return isMainScreen;}
			set { isMainScreen = value;}
		}
	}
	
	/// <summary>
	/// MyMenu(즐겨찾기 메뉴 정보 관리 Class, 즐겨찾기추가,메뉴구성시 사용)
	/// </summary>
	internal class MyMenuInfo
	{
		private string	menuLevel = "";  //Menu Level 1-> N
		private string	menuTp = "";    //Menu 구분 (M.Menu, P.Program메뉴)
		private string	menuID = "";    //Menu ID
		private string	menuTitle = ""; //Menu Title
		private string	pgmID = "";		   //프로그램 ID
		private ScreenOpenStyle openStyle = ScreenOpenStyle.PopUpSizable;  //화면 Open Style
		private string	menuParam = "";  //메뉴에 지정된 Param

		public string MenuLevel
		{
			get { return menuLevel;}
			set { menuLevel = value;}
		}
		public string MenuTp
		{
			get { return menuTp;}
			set { menuTp = value;}
		}
		public string MenuID
		{
			get { return menuID;}
			set { menuID = value;}
		}
		public string MenuTitle
		{
			get { return menuTitle;}
			set { menuTitle = value;}
		}
		public string PgmID
		{
			get { return pgmID;}
			set { pgmID = value;}
		}
		public ScreenOpenStyle OpenStyle
		{
			get { return openStyle;}
			set { openStyle = value;}
		}
		public string MenuParam
		{
			get { return menuParam;}
			set { menuParam = value;}
		}
	}
}
