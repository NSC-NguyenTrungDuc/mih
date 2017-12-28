using System;
using System.Runtime.InteropServices;
using System.Drawing;

namespace IHIS.Framework
{
	/// <summary>
	/// Win32에 대한 요약 설명입니다.
	/// </summary>
	public class Win32
	{
		#region Enums
		public enum PeekMessageFlags
		{
			PM_NOREMOVE		= 0,
			PM_REMOVE		= 1,
			PM_NOYIELD		= 2
		}

		public enum SetWindowPosFlags : uint
		{
			SWP_NOSIZE          = 0x0001,
			SWP_NOMOVE          = 0x0002,
			SWP_NOZORDER        = 0x0004,
			SWP_NOREDRAW        = 0x0008,
			SWP_NOACTIVATE      = 0x0010,
			SWP_FRAMECHANGED    = 0x0020,
			SWP_SHOWWINDOW      = 0x0040,
			SWP_HIDEWINDOW      = 0x0080,
			SWP_NOCOPYBITS      = 0x0100,
			SWP_NOOWNERZORDER   = 0x0200, 
			SWP_NOSENDCHANGING  = 0x0400,
			SWP_DRAWFRAME       = 0x0020,
			SWP_NOREPOSITION    = 0x0200,
			SWP_DEFERERASE      = 0x2000,
			SWP_ASYNCWINDOWPOS  = 0x4000
		}

		public enum SetWindowPosZ 
		{
			HWND_TOP        = 0,
			HWND_BOTTOM     = 1,
			HWND_TOPMOST    = -1,
			HWND_NOTOPMOST  = -2
		}

		public enum ShowWindowStyles : short
		{
			SW_HIDE             = 0,
			SW_SHOWNORMAL       = 1,
			SW_NORMAL           = 1,
			SW_SHOWMINIMIZED    = 2,
			SW_SHOWMAXIMIZED    = 3,
			SW_MAXIMIZE         = 3,
			SW_SHOWNOACTIVATE   = 4,
			SW_SHOW             = 5,
			SW_MINIMIZE         = 6,
			SW_SHOWMINNOACTIVE  = 7,
			SW_SHOWNA           = 8,
			SW_RESTORE          = 9,
			SW_SHOWDEFAULT      = 10,
			SW_FORCEMINIMIZE    = 11,
			SW_MAX              = 11
		}

		public enum WindowStyles : uint
		{
			WS_OVERLAPPED       = 0x00000000,
			WS_POPUP            = 0x80000000,
			WS_CHILD            = 0x40000000,
			WS_MINIMIZE         = 0x20000000,
			WS_VISIBLE          = 0x10000000,
			WS_DISABLED         = 0x08000000,
			WS_CLIPSIBLINGS     = 0x04000000,
			WS_CLIPCHILDREN     = 0x02000000,
			WS_MAXIMIZE         = 0x01000000,
			WS_CAPTION          = 0x00C00000,
			WS_BORDER           = 0x00800000,
			WS_DLGFRAME         = 0x00400000,
			WS_VSCROLL          = 0x00200000,
			WS_HSCROLL          = 0x00100000,
			WS_SYSMENU          = 0x00080000,
			WS_THICKFRAME       = 0x00040000,
			WS_GROUP            = 0x00020000,
			WS_TABSTOP          = 0x00010000,
			WS_MINIMIZEBOX      = 0x00020000,
			WS_MAXIMIZEBOX      = 0x00010000,
			WS_TILED            = 0x00000000,
			WS_ICONIC           = 0x20000000,
			WS_SIZEBOX          = 0x00040000,
			WS_POPUPWINDOW      = 0x80880000,
			WS_OVERLAPPEDWINDOW = 0x00CF0000,
			WS_TILEDWINDOW      = 0x00CF0000,
			WS_CHILDWINDOW      = 0x40000000
		}

		public enum WindowExStyles
		{
			WS_EX_DLGMODALFRAME     = 0x00000001,
			WS_EX_NOPARENTNOTIFY    = 0x00000004,
			WS_EX_TOPMOST           = 0x00000008,
			WS_EX_ACCEPTFILES       = 0x00000010,
			WS_EX_TRANSPARENT       = 0x00000020,
			WS_EX_MDICHILD          = 0x00000040,
			WS_EX_TOOLWINDOW        = 0x00000080,
			WS_EX_WINDOWEDGE        = 0x00000100,
			WS_EX_CLIENTEDGE        = 0x00000200,
			WS_EX_CONTEXTHELP       = 0x00000400,
			WS_EX_RIGHT             = 0x00001000,
			WS_EX_LEFT              = 0x00000000,
			WS_EX_RTLREADING        = 0x00002000,
			WS_EX_LTRREADING        = 0x00000000,
			WS_EX_LEFTSCROLLBAR     = 0x00004000,
			WS_EX_RIGHTSCROLLBAR    = 0x00000000,
			WS_EX_CONTROLPARENT     = 0x00010000,
			WS_EX_STATICEDGE        = 0x00020000,
			WS_EX_APPWINDOW         = 0x00040000,
			WS_EX_OVERLAPPEDWINDOW  = 0x00000300,
			WS_EX_PALETTEWINDOW     = 0x00000188,
			WS_EX_LAYERED			= 0x00080000
		}

		public enum WindowsHookCodes
		{
			WH_MSGFILTER        = (-1),
			WH_JOURNALRECORD    = 0,
			WH_JOURNALPLAYBACK  = 1,
			WH_KEYBOARD         = 2,
			WH_GETMESSAGE       = 3,
			WH_CALLWNDPROC      = 4,
			WH_CBT              = 5,
			WH_SYSMSGFILTER     = 6,
			WH_MOUSE            = 7,
			WH_HARDWARE         = 8,
			WH_DEBUG            = 9,
			WH_SHELL            = 10,
			WH_FOREGROUNDIDLE   = 11,
			WH_CALLWNDPROCRET   = 12,
			WH_KEYBOARD_LL      = 13,
			WH_MOUSE_LL         = 14
		}
		  
		public enum VirtualKeys
		{
			VK_LBUTTON		= 0x01,
			VK_CANCEL		= 0x03,
			VK_BACK			= 0x08,
			VK_TAB			= 0x09,
			VK_CLEAR		= 0x0C,
			VK_RETURN		= 0x0D,
			VK_SHIFT		= 0x10,
			VK_CONTROL		= 0x11,
			VK_MENU			= 0x12,
			VK_CAPITAL		= 0x14,
			VK_ESCAPE		= 0x1B,
			VK_SPACE		= 0x20,
			VK_PRIOR		= 0x21,
			VK_NEXT			= 0x22,
			VK_END			= 0x23,
			VK_HOME			= 0x24,
			VK_LEFT			= 0x25,
			VK_UP			= 0x26,
			VK_RIGHT		= 0x27,
			VK_DOWN			= 0x28,
			VK_SELECT		= 0x29,
			VK_EXECUTE		= 0x2B,
			VK_SNAPSHOT		= 0x2C,
			VK_HELP			= 0x2F,
			VK_0			= 0x30,
			VK_1			= 0x31,
			VK_2			= 0x32,
			VK_3			= 0x33,
			VK_4			= 0x34,
			VK_5			= 0x35,
			VK_6			= 0x36,
			VK_7			= 0x37,
			VK_8			= 0x38,
			VK_9			= 0x39,
			VK_A			= 0x41,
			VK_B			= 0x42,
			VK_C			= 0x43,
			VK_D			= 0x44,
			VK_E			= 0x45,
			VK_F			= 0x46,
			VK_G			= 0x47,
			VK_H			= 0x48,
			VK_I			= 0x49,
			VK_J			= 0x4A,
			VK_K			= 0x4B,
			VK_L			= 0x4C,
			VK_M			= 0x4D,
			VK_N			= 0x4E,
			VK_O			= 0x4F,
			VK_P			= 0x50,
			VK_Q			= 0x51,
			VK_R			= 0x52,
			VK_S			= 0x53,
			VK_T			= 0x54,
			VK_U			= 0x55,
			VK_V			= 0x56,
			VK_W			= 0x57,
			VK_X			= 0x58,
			VK_Y			= 0x59,
			VK_Z			= 0x5A,
			VK_NUMPAD0		= 0x60,
			VK_NUMPAD1		= 0x61,
			VK_NUMPAD2		= 0x62,
			VK_NUMPAD3		= 0x63,
			VK_NUMPAD4		= 0x64,
			VK_NUMPAD5		= 0x65,
			VK_NUMPAD6		= 0x66,
			VK_NUMPAD7		= 0x67,
			VK_NUMPAD8		= 0x68,
			VK_NUMPAD9		= 0x69,
			VK_MULTIPLY		= 0x6A,
			VK_ADD			= 0x6B,
			VK_SEPARATOR	= 0x6C,
			VK_SUBTRACT		= 0x6D,
			VK_DECIMAL		= 0x6E,
			VK_DIVIDE		= 0x6F,
			VK_ATTN			= 0xF6,
			VK_CRSEL		= 0xF7,
			VK_EXSEL		= 0xF8,
			VK_EREOF		= 0xF9,
			VK_PLAY			= 0xFA,  
			VK_ZOOM			= 0xFB,
			VK_NONAME		= 0xFC,
			VK_PA1			= 0xFD,
			VK_OEM_CLEAR	= 0xFE,
			VK_LWIN			= 0x5B,
			VK_RWIN			= 0x5C,
			VK_APPS			= 0x5D,   
			VK_LSHIFT		= 0xA0,   
			VK_RSHIFT		= 0xA1,   
			VK_LCONTROL		= 0xA2,   
			VK_RCONTROL		= 0xA3,   
			VK_LMENU		= 0xA4,   
			VK_RMENU		= 0xA5
		}

		public enum Msgs
		{
			WM_NULL                   = 0x0000,
			WM_CREATE                 = 0x0001,
			WM_DESTROY                = 0x0002,
			WM_MOVE                   = 0x0003,
			WM_SIZE                   = 0x0005,
			WM_ACTIVATE               = 0x0006,
			WM_SETFOCUS               = 0x0007,
			WM_KILLFOCUS              = 0x0008,
			WM_ENABLE                 = 0x000A,
			WM_SETREDRAW              = 0x000B,
			WM_SETTEXT                = 0x000C,
			WM_GETTEXT                = 0x000D,
			WM_GETTEXTLENGTH          = 0x000E,
			WM_PAINT                  = 0x000F,
			WM_CLOSE                  = 0x0010,
			WM_QUERYENDSESSION        = 0x0011,
			WM_QUIT                   = 0x0012,
			WM_QUERYOPEN              = 0x0013,
			WM_ERASEBKGND             = 0x0014,
			WM_SYSCOLORCHANGE         = 0x0015,
			WM_ENDSESSION             = 0x0016,
			WM_SHOWWINDOW             = 0x0018,
			WM_WININICHANGE           = 0x001A,
			WM_SETTINGCHANGE          = 0x001A,
			WM_DEVMODECHANGE          = 0x001B,
			WM_ACTIVATEAPP            = 0x001C,
			WM_FONTCHANGE             = 0x001D,
			WM_TIMECHANGE             = 0x001E,
			WM_CANCELMODE             = 0x001F,
			WM_SETCURSOR              = 0x0020,
			WM_MOUSEACTIVATE          = 0x0021,
			WM_CHILDACTIVATE          = 0x0022,
			WM_QUEUESYNC              = 0x0023,
			WM_GETMINMAXINFO          = 0x0024,
			WM_PAINTICON              = 0x0026,
			WM_ICONERASEBKGND         = 0x0027,
			WM_NEXTDLGCTL             = 0x0028,
			WM_SPOOLERSTATUS          = 0x002A,
			WM_DRAWITEM               = 0x002B,
			WM_MEASUREITEM            = 0x002C,
			WM_DELETEITEM             = 0x002D,
			WM_VKEYTOITEM             = 0x002E,
			WM_CHARTOITEM             = 0x002F,
			WM_SETFONT                = 0x0030,
			WM_GETFONT                = 0x0031,
			WM_SETHOTKEY              = 0x0032,
			WM_GETHOTKEY              = 0x0033,
			WM_QUERYDRAGICON          = 0x0037,
			WM_COMPAREITEM            = 0x0039,
			WM_GETOBJECT              = 0x003D,
			WM_COMPACTING             = 0x0041,
			WM_COMMNOTIFY             = 0x0044 ,
			WM_WINDOWPOSCHANGING      = 0x0046,
			WM_WINDOWPOSCHANGED       = 0x0047,
			WM_POWER                  = 0x0048,
			WM_COPYDATA               = 0x004A,
			WM_CANCELJOURNAL          = 0x004B,
			WM_NOTIFY                 = 0x004E,
			WM_INPUTLANGCHANGEREQUEST = 0x0050,
			WM_INPUTLANGCHANGE        = 0x0051,
			WM_TCARD                  = 0x0052,
			WM_HELP                   = 0x0053,
			WM_USERCHANGED            = 0x0054,
			WM_NOTIFYFORMAT           = 0x0055,
			WM_CONTEXTMENU            = 0x007B,
			WM_STYLECHANGING          = 0x007C,
			WM_STYLECHANGED           = 0x007D,
			WM_DISPLAYCHANGE          = 0x007E,
			WM_GETICON                = 0x007F,
			WM_SETICON                = 0x0080,
			WM_NCCREATE               = 0x0081,
			WM_NCDESTROY              = 0x0082,
			WM_NCCALCSIZE             = 0x0083,
			WM_NCHITTEST              = 0x0084,
			WM_NCPAINT                = 0x0085,
			WM_NCACTIVATE             = 0x0086,
			WM_GETDLGCODE             = 0x0087,
			WM_SYNCPAINT              = 0x0088,
			WM_NCMOUSEMOVE            = 0x00A0,
			WM_NCLBUTTONDOWN          = 0x00A1,
			WM_NCLBUTTONUP            = 0x00A2,
			WM_NCLBUTTONDBLCLK        = 0x00A3,
			WM_NCRBUTTONDOWN          = 0x00A4,
			WM_NCRBUTTONUP            = 0x00A5,
			WM_NCRBUTTONDBLCLK        = 0x00A6,
			WM_NCMBUTTONDOWN          = 0x00A7,
			WM_NCMBUTTONUP            = 0x00A8,
			WM_NCMBUTTONDBLCLK        = 0x00A9,
			WM_NCXBUTTONDOWN          = 0x00AB,
			WM_NCXBUTTONUP            = 0x00AC,
			WM_KEYDOWN                = 0x0100,
			WM_KEYUP                  = 0x0101,
			WM_CHAR                   = 0x0102,
			WM_DEADCHAR               = 0x0103,
			WM_SYSKEYDOWN             = 0x0104,
			WM_SYSKEYUP               = 0x0105,
			WM_SYSCHAR                = 0x0106,
			WM_SYSDEADCHAR            = 0x0107,
			WM_KEYLAST                = 0x0108,
			WM_IME_STARTCOMPOSITION   = 0x010D,
			WM_IME_ENDCOMPOSITION     = 0x010E,
			WM_IME_COMPOSITION        = 0x010F,
			WM_IME_KEYLAST            = 0x010F,
			WM_INITDIALOG             = 0x0110,
			WM_COMMAND                = 0x0111,
			WM_SYSCOMMAND             = 0x0112,
			WM_TIMER                  = 0x0113,
			WM_HSCROLL                = 0x0114,
			WM_VSCROLL                = 0x0115,
			WM_INITMENU               = 0x0116,
			WM_INITMENUPOPUP          = 0x0117,
			WM_MENUSELECT             = 0x011F,
			WM_MENUCHAR               = 0x0120,
			WM_ENTERIDLE              = 0x0121,
			WM_MENURBUTTONUP          = 0x0122,
			WM_MENUDRAG               = 0x0123,
			WM_MENUGETOBJECT          = 0x0124,
			WM_UNINITMENUPOPUP        = 0x0125,
			WM_MENUCOMMAND            = 0x0126,
			WM_CTLCOLORMSGBOX         = 0x0132,
			WM_CTLCOLOREDIT           = 0x0133,
			WM_CTLCOLORLISTBOX        = 0x0134,
			WM_CTLCOLORBTN            = 0x0135,
			WM_CTLCOLORDLG            = 0x0136,
			WM_CTLCOLORSCROLLBAR      = 0x0137,
			WM_CTLCOLORSTATIC         = 0x0138,
			WM_MOUSEMOVE              = 0x0200,
			WM_LBUTTONDOWN            = 0x0201,
			WM_LBUTTONUP              = 0x0202,
			WM_LBUTTONDBLCLK          = 0x0203,
			WM_RBUTTONDOWN            = 0x0204,
			WM_RBUTTONUP              = 0x0205,
			WM_RBUTTONDBLCLK          = 0x0206,
			WM_MBUTTONDOWN            = 0x0207,
			WM_MBUTTONUP              = 0x0208,
			WM_MBUTTONDBLCLK          = 0x0209,
			WM_MOUSEWHEEL             = 0x020A,
			WM_XBUTTONDOWN            = 0x020B,
			WM_XBUTTONUP              = 0x020C,
			WM_XBUTTONDBLCLK          = 0x020D,
			WM_PARENTNOTIFY           = 0x0210,
			WM_ENTERMENULOOP          = 0x0211,
			WM_EXITMENULOOP           = 0x0212,
			WM_NEXTMENU               = 0x0213,
			WM_SIZING                 = 0x0214,
			WM_CAPTURECHANGED         = 0x0215,
			WM_MOVING                 = 0x0216,
			WM_DEVICECHANGE           = 0x0219,
			WM_MDICREATE              = 0x0220,
			WM_MDIDESTROY             = 0x0221,
			WM_MDIACTIVATE            = 0x0222,
			WM_MDIRESTORE             = 0x0223,
			WM_MDINEXT                = 0x0224,
			WM_MDIMAXIMIZE            = 0x0225,
			WM_MDITILE                = 0x0226,
			WM_MDICASCADE             = 0x0227,
			WM_MDIICONARRANGE         = 0x0228,
			WM_MDIGETACTIVE           = 0x0229,
			WM_MDISETMENU             = 0x0230,
			WM_ENTERSIZEMOVE          = 0x0231,
			WM_EXITSIZEMOVE           = 0x0232,
			WM_DROPFILES              = 0x0233,
			WM_MDIREFRESHMENU         = 0x0234,
			WM_IME_SETCONTEXT         = 0x0281,
			WM_IME_NOTIFY             = 0x0282,
			WM_IME_CONTROL            = 0x0283,
			WM_IME_COMPOSITIONFULL    = 0x0284,
			WM_IME_SELECT             = 0x0285,
			WM_IME_CHAR               = 0x0286,
			WM_IME_REQUEST            = 0x0288,
			WM_IME_KEYDOWN            = 0x0290,
			WM_IME_KEYUP              = 0x0291,
			WM_MOUSEHOVER             = 0x02A1,
			WM_MOUSELEAVE             = 0x02A3,
			WM_NCMOUSEHOVER           = 0x02A0,
			WM_NCMOUSELEAVE           = 0x02A2,
			WM_CUT                    = 0x0300,
			WM_COPY                   = 0x0301,
			WM_PASTE                  = 0x0302,
			WM_CLEAR                  = 0x0303,
			WM_UNDO                   = 0x0304,
			WM_RENDERFORMAT           = 0x0305,
			WM_RENDERALLFORMATS       = 0x0306,
			WM_DESTROYCLIPBOARD       = 0x0307,
			WM_DRAWCLIPBOARD          = 0x0308,
			WM_PAINTCLIPBOARD         = 0x0309,
			WM_VSCROLLCLIPBOARD       = 0x030A,
			WM_SIZECLIPBOARD          = 0x030B,
			WM_ASKCBFORMATNAME        = 0x030C,
			WM_CHANGECBCHAIN          = 0x030D,
			WM_HSCROLLCLIPBOARD       = 0x030E,
			WM_QUERYNEWPALETTE        = 0x030F,
			WM_PALETTEISCHANGING      = 0x0310,
			WM_PALETTECHANGED         = 0x0311,
			WM_HOTKEY                 = 0x0312,
			WM_PRINT                  = 0x0317,
			WM_PRINTCLIENT            = 0x0318,
			WM_HANDHELDFIRST          = 0x0358,
			WM_HANDHELDLAST           = 0x035F,
			WM_AFXFIRST               = 0x0360,
			WM_AFXLAST                = 0x037F,
			WM_PENWINFIRST            = 0x0380,
			WM_PENWINLAST             = 0x038F,
			WM_APP                    = 0x8000,
			WM_USER                   = 0x0400
		}

		public enum Cursors : uint
		{
			IDC_ARROW		= 32512U,
			IDC_IBEAM       = 32513U,
			IDC_WAIT        = 32514U,
			IDC_CROSS       = 32515U,
			IDC_UPARROW     = 32516U,
			IDC_SIZE        = 32640U,
			IDC_ICON        = 32641U,
			IDC_SIZENWSE    = 32642U,
			IDC_SIZENESW    = 32643U,
			IDC_SIZEWE      = 32644U,
			IDC_SIZENS      = 32645U,
			IDC_SIZEALL     = 32646U,
			IDC_NO          = 32648U,
			IDC_HAND        = 32649U,
			IDC_APPSTARTING = 32650U,
			IDC_HELP        = 32651U
		}

		public enum TrackerEventFlags : uint
		{
			TME_HOVER		= 0x00000001,
			TME_LEAVE		= 0x00000002,
			TME_NONCLIENT	= 0x00000010,
			TME_QUERY		= 0x40000000,
			TME_CANCEL		= 0x80000000
		}

		public enum MouseActivateFlags
		{
			MA_ACTIVATE			= 1,
			MA_ACTIVATEANDEAT   = 2,
			MA_NOACTIVATE       = 3,
			MA_NOACTIVATEANDEAT = 4
		}

		public enum DialogCodes
		{
			DLGC_WANTARROWS			= 0x0001,
			DLGC_WANTTAB			= 0x0002,
			DLGC_WANTALLKEYS		= 0x0004,
			DLGC_WANTMESSAGE		= 0x0004,
			DLGC_HASSETSEL			= 0x0008,
			DLGC_DEFPUSHBUTTON		= 0x0010,
			DLGC_UNDEFPUSHBUTTON	= 0x0020,
			DLGC_RADIOBUTTON		= 0x0040,
			DLGC_WANTCHARS			= 0x0080,
			DLGC_STATIC				= 0x0100,
			DLGC_BUTTON				= 0x2000
		}
		public enum UpdateLayeredWindowsFlags
		{
			ULW_COLORKEY = 0x00000001,
			ULW_ALPHA    = 0x00000002,
			ULW_OPAQUE   = 0x00000004
		}

		public enum AlphaFlags : byte
		{
			AC_SRC_OVER  = 0x00,
			AC_SRC_ALPHA = 0x01
		}

		public enum RasterOperations : uint
		{
			SRCCOPY		= 0x00CC0020,
			SRCPAINT	= 0x00EE0086,
			SRCAND		= 0x008800C6,
			SRCINVERT	= 0x00660046,
			SRCERASE	= 0x00440328,
			NOTSRCCOPY	= 0x00330008,
			NOTSRCERASE = 0x001100A6,
			MERGECOPY	= 0x00C000CA,
			MERGEPAINT	= 0x00BB0226,
			PATCOPY		= 0x00F00021,
			PATPAINT	= 0x00FB0A09,
			PATINVERT	= 0x005A0049,
			DSTINVERT	= 0x00550009,
			BLACKNESS	= 0x00000042,
			WHITENESS	= 0x00FF0062
		}

		public enum BrushStyles
		{
			BS_SOLID			= 0,
			BS_NULL             = 1,
			BS_HOLLOW           = 1,
			BS_HATCHED          = 2,
			BS_PATTERN          = 3,
			BS_INDEXED          = 4,
			BS_DIBPATTERN       = 5,
			BS_DIBPATTERNPT     = 6,
			BS_PATTERN8X8       = 7,
			BS_DIBPATTERN8X8    = 8,
			BS_MONOPATTERN      = 9
		}

		public enum HatchStyles
		{
			HS_HORIZONTAL       = 0,
			HS_VERTICAL         = 1,
			HS_FDIAGONAL        = 2,
			HS_BDIAGONAL        = 3,
			HS_CROSS            = 4,
			HS_DIAGCROSS        = 5
		}

		public enum CombineFlags
		{
			RGN_AND		= 1,
			RGN_OR		= 2,
			RGN_XOR		= 3,
			RGN_DIFF	= 4,
			RGN_COPY	= 5
		}

		public enum HitTest
		{
			HTERROR			= -2,
			HTTRANSPARENT   = -1,
			HTNOWHERE		= 0,
			HTCLIENT		= 1,
			HTCAPTION		= 2,
			HTSYSMENU		= 3,
			HTGROWBOX		= 4,
			HTSIZE			= 4,
			HTMENU			= 5,
			HTHSCROLL		= 6,
			HTVSCROLL		= 7,
			HTMINBUTTON		= 8,
			HTMAXBUTTON		= 9,
			HTLEFT			= 10,
			HTRIGHT			= 11,
			HTTOP			= 12,
			HTTOPLEFT		= 13,
			HTTOPRIGHT		= 14,
			HTBOTTOM		= 15,
			HTBOTTOMLEFT	= 16,
			HTBOTTOMRIGHT	= 17,
			HTBORDER		= 18,
			HTREDUCE		= 8,
			HTZOOM			= 9 ,
			HTSIZEFIRST		= 10,
			HTSIZELAST		= 17,
			HTOBJECT		= 19,
			HTCLOSE			= 20,
			HTHELP			= 21
		}

		public enum AnimateFlags
		{
			AW_HOR_POSITIVE = 0x00000001,
			AW_HOR_NEGATIVE = 0x00000002,
			AW_VER_POSITIVE = 0x00000004,
			AW_VER_NEGATIVE = 0x00000008,
			AW_CENTER		= 0x00000010,
			AW_HIDE			= 0x00010000,
			AW_ACTIVATE		= 0x00020000,
			AW_SLIDE		= 0x00040000,
			AW_BLEND		= 0x00080000
		}

		public enum SPIActions
		{
			SPI_GETBEEP                         = 0x0001,
			SPI_SETBEEP                         = 0x0002,
			SPI_GETMOUSE                        = 0x0003,
			SPI_SETMOUSE                        = 0x0004,
			SPI_GETBORDER                       = 0x0005,
			SPI_SETBORDER                       = 0x0006,
			SPI_GETKEYBOARDSPEED                = 0x000A,
			SPI_SETKEYBOARDSPEED                = 0x000B,
			SPI_LANGDRIVER                      = 0x000C,
			SPI_ICONHORIZONTALSPACING           = 0x000D,
			SPI_GETSCREENSAVETIMEOUT            = 0x000E,
			SPI_SETSCREENSAVETIMEOUT            = 0x000F,
			SPI_GETSCREENSAVEACTIVE             = 0x0010,
			SPI_SETSCREENSAVEACTIVE             = 0x0011,
			SPI_GETGRIDGRANULARITY              = 0x0012,
			SPI_SETGRIDGRANULARITY              = 0x0013,
			SPI_SETDESKWALLPAPER                = 0x0014,
			SPI_SETDESKPATTERN                  = 0x0015,
			SPI_GETKEYBOARDDELAY                = 0x0016,
			SPI_SETKEYBOARDDELAY                = 0x0017,
			SPI_ICONVERTICALSPACING             = 0x0018,
			SPI_GETICONTITLEWRAP                = 0x0019,
			SPI_SETICONTITLEWRAP                = 0x001A,
			SPI_GETMENUDROPALIGNMENT            = 0x001B,
			SPI_SETMENUDROPALIGNMENT            = 0x001C,
			SPI_SETDOUBLECLKWIDTH               = 0x001D,
			SPI_SETDOUBLECLKHEIGHT              = 0x001E,
			SPI_GETICONTITLELOGFONT             = 0x001F,
			SPI_SETDOUBLECLICKTIME              = 0x0020,
			SPI_SETMOUSEBUTTONSWAP              = 0x0021,
			SPI_SETICONTITLELOGFONT             = 0x0022,
			SPI_GETFASTTASKSWITCH               = 0x0023,
			SPI_SETFASTTASKSWITCH               = 0x0024,
			SPI_SETDRAGFULLWINDOWS              = 0x0025,
			SPI_GETDRAGFULLWINDOWS              = 0x0026,
			SPI_GETNONCLIENTMETRICS             = 0x0029,
			SPI_SETNONCLIENTMETRICS             = 0x002A,
			SPI_GETMINIMIZEDMETRICS             = 0x002B,
			SPI_SETMINIMIZEDMETRICS             = 0x002C,
			SPI_GETICONMETRICS                  = 0x002D,
			SPI_SETICONMETRICS                  = 0x002E,
			SPI_SETWORKAREA                     = 0x002F,
			SPI_GETWORKAREA                     = 0x0030,
			SPI_SETPENWINDOWS                   = 0x0031,
			SPI_GETHIGHCONTRAST                 = 0x0042,
			SPI_SETHIGHCONTRAST                 = 0x0043,
			SPI_GETKEYBOARDPREF                 = 0x0044,
			SPI_SETKEYBOARDPREF                 = 0x0045,
			SPI_GETSCREENREADER                 = 0x0046,
			SPI_SETSCREENREADER                 = 0x0047,
			SPI_GETANIMATION                    = 0x0048,
			SPI_SETANIMATION                    = 0x0049,
			SPI_GETFONTSMOOTHING                = 0x004A,
			SPI_SETFONTSMOOTHING                = 0x004B,
			SPI_SETDRAGWIDTH                    = 0x004C,
			SPI_SETDRAGHEIGHT                   = 0x004D,
			SPI_SETHANDHELD                     = 0x004E,
			SPI_GETLOWPOWERTIMEOUT              = 0x004F,
			SPI_GETPOWEROFFTIMEOUT              = 0x0050,
			SPI_SETLOWPOWERTIMEOUT              = 0x0051,
			SPI_SETPOWEROFFTIMEOUT              = 0x0052,
			SPI_GETLOWPOWERACTIVE               = 0x0053,
			SPI_GETPOWEROFFACTIVE               = 0x0054,
			SPI_SETLOWPOWERACTIVE               = 0x0055,
			SPI_SETPOWEROFFACTIVE               = 0x0056,
			SPI_SETCURSORS                      = 0x0057,
			SPI_SETICONS                        = 0x0058,
			SPI_GETDEFAULTINPUTLANG             = 0x0059,
			SPI_SETDEFAULTINPUTLANG             = 0x005A,
			SPI_SETLANGTOGGLE                   = 0x005B,
			SPI_GETWINDOWSEXTENSION             = 0x005C,
			SPI_SETMOUSETRAILS                  = 0x005D,
			SPI_GETMOUSETRAILS                  = 0x005E,
			SPI_SETSCREENSAVERRUNNING           = 0x0061,
			SPI_SCREENSAVERRUNNING              = 0x0061,
			SPI_GETFILTERKEYS                   = 0x0032,
			SPI_SETFILTERKEYS                   = 0x0033,
			SPI_GETTOGGLEKEYS                   = 0x0034,
			SPI_SETTOGGLEKEYS                   = 0x0035,
			SPI_GETMOUSEKEYS                    = 0x0036,
			SPI_SETMOUSEKEYS                    = 0x0037,
			SPI_GETSHOWSOUNDS                   = 0x0038,
			SPI_SETSHOWSOUNDS                   = 0x0039,
			SPI_GETSTICKYKEYS                   = 0x003A,
			SPI_SETSTICKYKEYS                   = 0x003B,
			SPI_GETACCESSTIMEOUT                = 0x003C,
			SPI_SETACCESSTIMEOUT                = 0x003D,
			SPI_GETSERIALKEYS                   = 0x003E,
			SPI_SETSERIALKEYS                   = 0x003F,
			SPI_GETSOUNDSENTRY                  = 0x0040,
			SPI_SETSOUNDSENTRY                  = 0x0041,
			SPI_GETSNAPTODEFBUTTON              = 0x005F,
			SPI_SETSNAPTODEFBUTTON              = 0x0060,
			SPI_GETMOUSEHOVERWIDTH              = 0x0062,
			SPI_SETMOUSEHOVERWIDTH              = 0x0063,
			SPI_GETMOUSEHOVERHEIGHT             = 0x0064,
			SPI_SETMOUSEHOVERHEIGHT             = 0x0065,
			SPI_GETMOUSEHOVERTIME               = 0x0066,
			SPI_SETMOUSEHOVERTIME               = 0x0067,
			SPI_GETWHEELSCROLLLINES             = 0x0068,
			SPI_SETWHEELSCROLLLINES             = 0x0069,
			SPI_GETMENUSHOWDELAY                = 0x006A,
			SPI_SETMENUSHOWDELAY                = 0x006B,
			SPI_GETSHOWIMEUI                    = 0x006E,
			SPI_SETSHOWIMEUI                    = 0x006F,
			SPI_GETMOUSESPEED                   = 0x0070,
			SPI_SETMOUSESPEED                   = 0x0071,
			SPI_GETSCREENSAVERRUNNING           = 0x0072,
			SPI_GETDESKWALLPAPER                = 0x0073,
			SPI_GETACTIVEWINDOWTRACKING         = 0x1000,
			SPI_SETACTIVEWINDOWTRACKING         = 0x1001,
			SPI_GETMENUANIMATION                = 0x1002,
			SPI_SETMENUANIMATION                = 0x1003,
			SPI_GETCOMBOBOXANIMATION            = 0x1004,
			SPI_SETCOMBOBOXANIMATION            = 0x1005,
			SPI_GETLISTBOXSMOOTHSCROLLING       = 0x1006,
			SPI_SETLISTBOXSMOOTHSCROLLING       = 0x1007,
			SPI_GETGRADIENTCAPTIONS             = 0x1008,
			SPI_SETGRADIENTCAPTIONS             = 0x1009,
			SPI_GETKEYBOARDCUES                 = 0x100A,
			SPI_SETKEYBOARDCUES                 = 0x100B,
			SPI_GETMENUUNDERLINES               = 0x100A,
			SPI_SETMENUUNDERLINES               = 0x100B,
			SPI_GETACTIVEWNDTRKZORDER           = 0x100C,
			SPI_SETACTIVEWNDTRKZORDER           = 0x100D,
			SPI_GETHOTTRACKING                  = 0x100E,
			SPI_SETHOTTRACKING                  = 0x100F,
			SPI_GETMENUFADE                     = 0x1012,
			SPI_SETMENUFADE                     = 0x1013,
			SPI_GETSELECTIONFADE                = 0x1014,
			SPI_SETSELECTIONFADE                = 0x1015,
			SPI_GETTOOLTIPANIMATION             = 0x1016,
			SPI_SETTOOLTIPANIMATION             = 0x1017,
			SPI_GETTOOLTIPFADE                  = 0x1018,
			SPI_SETTOOLTIPFADE                  = 0x1019,
			SPI_GETCURSORSHADOW                 = 0x101A,
			SPI_SETCURSORSHADOW                 = 0x101B,
			SPI_GETMOUSESONAR                   = 0x101C,
			SPI_SETMOUSESONAR                   = 0x101D,
			SPI_GETMOUSECLICKLOCK               = 0x101E,
			SPI_SETMOUSECLICKLOCK               = 0x101F,
			SPI_GETMOUSEVANISH                  = 0x1020,
			SPI_SETMOUSEVANISH                  = 0x1021,
			SPI_GETFLATMENU                     = 0x1022,
			SPI_SETFLATMENU                     = 0x1023,
			SPI_GETDROPSHADOW                   = 0x1024,
			SPI_SETDROPSHADOW                   = 0x1025,
			SPI_GETUIEFFECTS                    = 0x103E,
			SPI_SETUIEFFECTS                    = 0x103F,
			SPI_GETFOREGROUNDLOCKTIMEOUT        = 0x2000,
			SPI_SETFOREGROUNDLOCKTIMEOUT        = 0x2001,
			SPI_GETACTIVEWNDTRKTIMEOUT          = 0x2002,
			SPI_SETACTIVEWNDTRKTIMEOUT          = 0x2003,
			SPI_GETFOREGROUNDFLASHCOUNT         = 0x2004,
			SPI_SETFOREGROUNDFLASHCOUNT         = 0x2005,
			SPI_GETCARETWIDTH                   = 0x2006,
			SPI_SETCARETWIDTH                   = 0x2007,
			SPI_GETMOUSECLICKLOCKTIME           = 0x2008,
			SPI_SETMOUSECLICKLOCKTIME           = 0x2009,
			SPI_GETFONTSMOOTHINGTYPE            = 0x200A,
			SPI_SETFONTSMOOTHINGTYPE            = 0x200B,
			SPI_GETFONTSMOOTHINGCONTRAST        = 0x200C,
			SPI_SETFONTSMOOTHINGCONTRAST        = 0x200D,
			SPI_GETFOCUSBORDERWIDTH             = 0x200E,
			SPI_SETFOCUSBORDERWIDTH             = 0x200F,
			SPI_GETFOCUSBORDERHEIGHT            = 0x2010,
			SPI_SETFOCUSBORDERHEIGHT            = 0x2011
		}

		public enum SPIWinINIFlags
		{
			SPIF_UPDATEINIFILE		= 0x0001,
			SPIF_SENDWININICHANGE	= 0x0002,
			SPIF_SENDCHANGE			= 0x0002
		}

		public enum DrawTextFormatFlags
		{
			DT_TOP              = 0x00000000,
			DT_LEFT             = 0x00000000,
			DT_CENTER           = 0x00000001,
			DT_RIGHT            = 0x00000002,
			DT_VCENTER          = 0x00000004,
			DT_BOTTOM           = 0x00000008,
			DT_WORDBREAK        = 0x00000010,
			DT_SINGLELINE       = 0x00000020,
			DT_EXPANDTABS       = 0x00000040,
			DT_TABSTOP          = 0x00000080,
			DT_NOCLIP           = 0x00000100,
			DT_EXTERNALLEADING  = 0x00000200,
			DT_CALCRECT         = 0x00000400,
			DT_NOPREFIX         = 0x00000800,
			DT_INTERNAL         = 0x00001000,
			DT_EDITCONTROL      = 0x00002000,
			DT_PATH_ELLIPSIS    = 0x00004000,
			DT_END_ELLIPSIS     = 0x00008000,
			DT_MODIFYSTRING     = 0x00010000,
			DT_RTLREADING       = 0x00020000,
			DT_WORD_ELLIPSIS    = 0x00040000
		}

		public enum BackgroundMode
		{
			TRANSPARENT = 1,
			OPAQUE = 2
		}

		public enum SetWindowPosZOrder
		{
			HWND_TOP        = 0,
			HWND_BOTTOM     = 1,
			HWND_TOPMOST    = -1,
			HWND_NOTOPMOST  = -2
		}

		public enum SystemMetricsCodes
		{
			SM_CXSCREEN             = 0,
			SM_CYSCREEN             = 1,
			SM_CXVSCROLL            = 2,
			SM_CYHSCROLL            = 3,
			SM_CYCAPTION            = 4,
			SM_CXBORDER             = 5,
			SM_CYBORDER             = 6,
			SM_CXDLGFRAME           = 7,
			SM_CYDLGFRAME           = 8,
			SM_CYVTHUMB             = 9,
			SM_CXHTHUMB             = 10,
			SM_CXICON               = 11,
			SM_CYICON               = 12,
			SM_CXCURSOR             = 13,
			SM_CYCURSOR             = 14,
			SM_CYMENU               = 15,
			SM_CXFULLSCREEN         = 16,
			SM_CYFULLSCREEN         = 17,
			SM_CYKANJIWINDOW        = 18,
			SM_MOUSEPRESENT         = 19,
			SM_CYVSCROLL            = 20,
			SM_CXHSCROLL            = 21,
			SM_DEBUG                = 22,
			SM_SWAPBUTTON           = 23,
			SM_RESERVED1            = 24,
			SM_RESERVED2            = 25,
			SM_RESERVED3            = 26,
			SM_RESERVED4            = 27,
			SM_CXMIN                = 28,
			SM_CYMIN                = 29,
			SM_CXSIZE               = 30,
			SM_CYSIZE               = 31,
			SM_CXFRAME              = 32,
			SM_CYFRAME              = 33,
			SM_CXMINTRACK           = 34,
			SM_CYMINTRACK           = 35,
			SM_CXDOUBLECLK          = 36,
			SM_CYDOUBLECLK          = 37,
			SM_CXICONSPACING        = 38,
			SM_CYICONSPACING        = 39,
			SM_MENUDROPALIGNMENT    = 40,
			SM_PENWINDOWS           = 41,
			SM_DBCSENABLED          = 42,
			SM_CMOUSEBUTTONS        = 43,
			SM_CXFIXEDFRAME         = SM_CXDLGFRAME, 
			SM_CYFIXEDFRAME         = SM_CYDLGFRAME,  
			SM_CXSIZEFRAME          = SM_CXFRAME,    
			SM_CYSIZEFRAME          = SM_CYFRAME,    
			SM_SECURE               = 44,
			SM_CXEDGE               = 45,
			SM_CYEDGE               = 46,
			SM_CXMINSPACING         = 47,
			SM_CYMINSPACING         = 48,
			SM_CXSMICON             = 49,
			SM_CYSMICON             = 50,
			SM_CYSMCAPTION          = 51,
			SM_CXSMSIZE             = 52,
			SM_CYSMSIZE             = 53,
			SM_CXMENUSIZE           = 54,
			SM_CYMENUSIZE           = 55,
			SM_ARRANGE              = 56,
			SM_CXMINIMIZED          = 57,
			SM_CYMINIMIZED          = 58,
			SM_CXMAXTRACK           = 59,
			SM_CYMAXTRACK           = 60,
			SM_CXMAXIMIZED          = 61,
			SM_CYMAXIMIZED          = 62,
			SM_NETWORK              = 63,
			SM_CLEANBOOT            = 67,
			SM_CXDRAG               = 68,
			SM_CYDRAG               = 69,
			SM_SHOWSOUNDS           = 70,
			SM_CXMENUCHECK          = 71,  
			SM_CYMENUCHECK          = 72,
			SM_SLOWMACHINE          = 73,
			SM_MIDEASTENABLED       = 74,
			SM_MOUSEWHEELPRESENT    = 75,
			SM_XVIRTUALSCREEN       = 76,
			SM_YVIRTUALSCREEN       = 77,
			SM_CXVIRTUALSCREEN      = 78,
			SM_CYVIRTUALSCREEN      = 79,
			SM_CMONITORS            = 80,
			SM_SAMEDISPLAYFORMAT    = 81,
			SM_CMETRICS             = 83
		}

		public enum PatBltTypes
		{
			SRCCOPY          =   0x00CC0020,
			SRCPAINT         =   0x00EE0086,
			SRCAND           =   0x008800C6,
			SRCINVERT        =   0x00660046,
			SRCERASE         =   0x00440328,
			NOTSRCCOPY       =   0x00330008,
			NOTSRCERASE      =   0x001100A6,
			MERGECOPY        =   0x00C000CA,
			MERGEPAINT       =   0x00BB0226,
			PATCOPY          =   0x00F00021,
			PATPAINT         =   0x00FB0A09,
			PATINVERT        =   0x005A0049,
			DSTINVERT        =   0x00550009,
			BLACKNESS        =   0x00000042,
			WHITENESS        =   0x00FF0062
		}

		public enum HDI : int//Header item
		{
			HDI_WIDTH             =  0x0001,
			HDI_HEIGHT            =  HDI_WIDTH,
			HDI_TEXT              =  0x0002,
			HDI_FORMAT            =  0x0004,
			HDI_LPARAM            =  0x0008,
			HDI_BITMAP            =  0x0010,
			HDI_IMAGE             =  0x0020,
			HDI_DI_SETITEM        =  0x0040,
			HDI_ORDER             =  0x0080,
			HDI_FILTER            =  0x0100
		}

		public enum HDF : int//Header format
		{
			HDF_LEFT             =   0x0000,
			HDF_RIGHT            =   0x0001,
			HDF_CENTER           =   0x0002,
			HDF_JUSTIFYMASK      =   0x0003,
			HDF_RTLREADING       =   0x0004,
			HDF_OWNERDRAW        =   0x8000,
			HDF_STRING           =   0x4000,
			HDF_BITMAP           =   0x2000,
			HDF_BITMAP_ON_RIGHT  =   0x1000,
			HDF_IMAGE            =   0x0800
		}
		public enum WmPrintFlags
		{
			/// <summary>
			/// Draws the window only if it is visible
			/// </summary>
			PRF_CHECKVISIBLE = 1,
			/// <summary>
			/// Draws the nonclient area of the window
			/// </summary>
			PRF_NONCLIENT = 2,
			/// <summary>
			/// Draws the client area of the window
			/// </summary>
			PRF_CLIENT = 4,
			/// <summary>
			/// Erases the background before drawing the window
			/// </summary>
			PRF_ERASEBKGND = 8,
			/// <summary>
			/// Draws all visible children windows
			/// </summary>
			PRF_CHILDREN = 16,
			/// <summary>
			/// Draws all owned windows
			/// </summary>
			PRF_OWNED = 32
		}
		[Flags]
		public enum SoundFlags : int 
		{
			SND_SYNC = 0x0000,  // play synchronously (default) 
			SND_ASYNC = 0x0001,  // play asynchronously 
			SND_NODEFAULT = 0x0002,  // silence (!default) if sound not found 
			SND_MEMORY = 0x0004,  // pszSound points to a memory file
			SND_LOOP = 0x0008,  // loop the sound until next sndPlaySound 
			SND_NOSTOP = 0x0010,  // don't stop any currently playing sound 
			SND_NOWAIT = 0x00002000, // don't wait if the driver is busy 
			SND_ALIAS = 0x00010000, // name is a registry alias 
			SND_ALIAS_ID = 0x00110000, // alias is a predefined ID
			SND_FILENAME = 0x00020000, // name is file name 
			SND_RESOURCE = 0x00040004  // name is resource name or atom 
		}

		public enum PenStyles
		{
			PS_SOLID		= 0,
			PS_DASH			= 1,
			PS_DOT			= 2,
			PS_DASHDOT		= 3,
			PS_DASHDOTDOT	= 4,
			PS_LINE         = 5
		}
		#endregion

		#region Structs
		[StructLayout(LayoutKind.Sequential)]
			public struct MSG 
		{
			public IntPtr hwnd;
			public int message;
			public IntPtr wParam;
			public IntPtr lParam;
			public int time;
			public int pt_x;
			public int pt_y;
		}

		[StructLayout(LayoutKind.Sequential)]
			public struct PAINTSTRUCT
		{
			public IntPtr hdc;
			public int fErase;
			public RECT rcPaint;
			public int fRestore;
			public int fIncUpdate;
			public int Reserved1;
			public int Reserved2;
			public int Reserved3;
			public int Reserved4;
			public int Reserved5;
			public int Reserved6;
			public int Reserved7;
			public int Reserved8;
		}

		[StructLayout(LayoutKind.Sequential)]
			public struct RECT
		{
			public int left;
			public int top;
			public int right;
			public int bottom;
		
			public RECT(Rectangle rect)
			{
				this.left = rect.Left;
				this.top = rect.Top;
				this.right = rect.Right;
				this.bottom = rect.Bottom;
			}
		}

		[StructLayout(LayoutKind.Sequential)]
			public struct POINT
		{
			public int x;
			public int y;
		}

		[StructLayout(LayoutKind.Sequential)]
			public struct SIZE
		{
			public int cx;
			public int cy;
		}

		[StructLayout(LayoutKind.Sequential, Pack=1)]
			public struct BLENDFUNCTION
		{
			public byte BlendOp;
			public byte BlendFlags;
			public byte SourceConstantAlpha;
			public byte AlphaFormat;
		}

		[StructLayout(LayoutKind.Sequential)]
			public struct TRACKMOUSEEVENTS
		{
			public uint cbSize;
			public uint dwFlags;
			public IntPtr hWnd;
			public uint dwHoverTime;
		}

		[StructLayout(LayoutKind.Sequential)]
			public struct LOGBRUSH
		{
			public uint lbStyle; 
			public uint lbColor; 
			public uint lbHatch; 
		}

		[StructLayout(LayoutKind.Sequential)]
			public struct NCCALCSIZE_PARAMS
		{
			public RECT rgrc0, rgrc1, rgrc2;
			public IntPtr lppos;
		}

		[StructLayout(LayoutKind.Sequential)]
			public struct WINDOWPOS
		{
			public IntPtr hwnd;
			public IntPtr hwndInsertAfter;
			public int x, y;
			public int cx, cy;
			public int flags;
		}

		[StructLayout(LayoutKind.Sequential)]
			public struct MOUSEHOOKSTRUCT 
		{ 
			public POINT     pt; 
			public IntPtr    hwnd; 
			public int       wHitTestCode; 
			public IntPtr    dwExtraInfo; 
		}

		[StructLayout(LayoutKind.Sequential, CharSet=CharSet.Auto)]
			public struct STRINGBUFFER
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst=512)]
			public string szText;
		}

		[StructLayout(LayoutKind.Sequential)]
			public struct COPYDATASTRUCT
		{
			public int dwData;
			public int cbData;
			public IntPtr lpData;
		}

		[StructLayout(LayoutKind.Sequential)]
			public struct HDHITTESTINFO 
		{  
			public Point pt;  
			public uint flags; 
			public int iItem; 
		}

		[StructLayout(LayoutKind.Sequential)]
			public struct HDLAYOUT
		{
			public IntPtr prc;//RECT*
			public IntPtr pwpos;//WINDOWPOS*
		}

		[StructLayout(LayoutKind.Sequential,CharSet=CharSet.Auto)]
			public struct HDITEM 
		{
			public int    mask; 
			public int     cxy; 
			public string  pszText; 
			public IntPtr  hbm; 
			public int     cchTextMax; 
			public int     fmt; 
			public int     lParam; 
			public int     iImage;
			public int     iOrder;
			public uint    type;
			public IntPtr  pvFilter;
		}
	
		[StructLayout(LayoutKind.Sequential)]
			public struct NMHDR
		{
			public IntPtr hwndFrom;
			public int idFrom;
			public int code;
		}

		[StructLayout(LayoutKind.Sequential)]
			public struct NMHEADER
		{
			public NMHDR nhdr;
			public int iItem;
			public int iButton;
			public IntPtr pHDITEM;
		}

		[StructLayout(LayoutKind.Sequential,CharSet=CharSet.Auto)]
			public struct DRAWITEMSTRUCT
		{
			public int ctrlType;
			public int ctrlID;
			public int itemID;
			public int itemAction;
			public int itemState;
			public IntPtr hwnd;
			public IntPtr hdc;
			public RECT rcItem;
			public IntPtr itemData;
		}

		[StructLayout(LayoutKind.Sequential,CharSet=CharSet.Auto)]
			public struct LVCOLUMN
		{
			public int mask;
			public int fmt;
			public int cx;
			public string text;
			public int textMax;
			public int subItem;
			public int iImage;
			public int iOrder;
		}
		[StructLayout(LayoutKind.Sequential)]
		public class SYSTEMTIME 
		{
			public ushort Year;
			public ushort Month;
			public ushort Dayofweek;
			public ushort Day;
			public ushort Hour;
			public ushort Minute;
			public ushort Second;
			public ushort Milliseconds;
		}
		#endregion
	}
}
