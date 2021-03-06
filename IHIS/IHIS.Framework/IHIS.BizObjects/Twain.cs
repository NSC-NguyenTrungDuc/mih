using System;
using System.Collections;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace IHIS.Framework
{
	#region Internal Enumerations
	[Flags]
	internal enum TwDG : short
	{									// DG_.....
		Control			= 0x0001,
		Image			= 0x0002,
		Audio			= 0x0004
	}

	internal enum TwDAT : short
	{									// DAT_....
		Null			= 0x0000,
		Capability		= 0x0001,
		Event			= 0x0002,
		Identity		= 0x0003,
		Parent			= 0x0004,
		PendingXfers	= 0x0005,
		SetupMemXfer	= 0x0006,
		SetupFileXfer	= 0x0007,
		Status			= 0x0008,
		UserInterface	= 0x0009,
		XferGroup		= 0x000a,
		TwunkIdentity	= 0x000b,
		CustomDSData	= 0x000c,
		DeviceEvent		= 0x000d,
		FileSystem		= 0x000e,
		PassThru		= 0x000f,

		ImageInfo		= 0x0101,
		ImageLayout		= 0x0102,
		ImageMemXfer	= 0x0103,
		ImageNativeXfer	= 0x0104,
		ImageFileXfer	= 0x0105,
		CieColor		= 0x0106,
		GrayResponse	= 0x0107,
		RGBResponse		= 0x0108,
		JpegCompression	= 0x0109,
		Palette8		= 0x010a,
		ExtImageInfo	= 0x010b,

		SetupFileXfer2	= 0x0301
	}

	internal enum TwMSG : short
	{									// MSG_.....
		Null			= 0x0000,
		Get				= 0x0001,
		GetCurrent		= 0x0002,
		GetDefault		= 0x0003,
		GetFirst		= 0x0004,
		GetNext			= 0x0005,
		Set				= 0x0006,
		Reset			= 0x0007,
		QuerySupport	= 0x0008,

		XFerReady		= 0x0101,
		CloseDSReq		= 0x0102,
		CloseDSOK		= 0x0103,
		DeviceEvent		= 0x0104,

		CheckStatus		= 0x0201,

		OpenDSM			= 0x0301,
		CloseDSM		= 0x0302,

		OpenDS			= 0x0401,
		CloseDS			= 0x0402,
		UserSelect		= 0x0403,

		DisableDS		= 0x0501,
		EnableDS		= 0x0502,
		EnableDSUIOnly	= 0x0503,

		ProcessEvent	= 0x0601,

		EndXfer			= 0x0701,
		StopFeeder		= 0x0702,

		ChangeDirectory	= 0x0801,
		CreateDirectory	= 0x0802,
		Delete			= 0x0803,
		FormatMedia		= 0x0804,
		GetClose		= 0x0805,
		GetFirstFile	= 0x0806,
		GetInfo			= 0x0807,
		GetNextFile		= 0x0808,
		Rename			= 0x0809,
		Copy			= 0x080A,
		AutoCaptureDir	= 0x080B,

		PassThru		= 0x0901
	}

	internal enum TwRC : short
	{									// TWRC_....
		Success				= 0x0000,
		Failure				= 0x0001,
		CheckStatus			= 0x0002,
		Cancel				= 0x0003,
		DSEvent				= 0x0004,
		NotDSEvent			= 0x0005,
		XferDone			= 0x0006,
		EndOfList			= 0x0007,
		InfoNotSupported	= 0x0008,
		DataNotAvailable	= 0x0009
	}

	internal enum TwCC : short
	{									// TWCC_....
		Success				= 0x0000,
		Bummer				= 0x0001,
		LowMemory			= 0x0002,
		NoDS				= 0x0003,
		MaxConnections		= 0x0004,
		OperationError		= 0x0005,
		BadCap				= 0x0006,
		BadProtocol			= 0x0009,
		BadValue			= 0x000a,
		SeqError			= 0x000b,
		BadDest				= 0x000c,
		CapUnsupported		= 0x000d,
		CapBadOperation		= 0x000e,
		CapSeqError			= 0x000f,
		Denied				= 0x0010,
		FileExists			= 0x0011,
		FileNotFound		= 0x0012,
		NotEmpty			= 0x0013,
		PaperJam			= 0x0014,
		PaperDoubleFeed		= 0x0015,
		FileWriteError		= 0x0016,
		CheckDeviceOnline	= 0x0017
	}

	internal enum TwOn : short
	{									// TWON_....
		Array			= 0x0003,
		Enum			= 0x0004,
		One				= 0x0005,
		Range			= 0x0006,
		DontCare		= -1
	}

	internal enum TwType : short
	{									// TWTY_....
		Int8			= 0x0000,
		Int16			= 0x0001,
		Int32			= 0x0002,
		UInt8			= 0x0003,
		UInt16			= 0x0004,
		UInt32			= 0x0005,
		Bool			= 0x0006,
		Fix32			= 0x0007,
		Frame			= 0x0008,
		Str32			= 0x0009,
		Str64			= 0x000a,
		Str128			= 0x000b,
		Str255			= 0x000c,
		Str1024			= 0x000d,
		Str512			= 0x000e
	}

	internal enum TwCap : short
	{
		CAP_XFERCOUNT			= 0x0001,
		ICAP_COMPRESSION		= 0x0100,
		ICAP_PIXELTYPE			= 0x0101,
		ICAP_UNITS				= 0x0102,
		ICAP_XFERMECH			= 0x0103,
		CAP_AUTHOR				= 0x1000,
		CAP_CAPTION				= 0x1001,
		CAP_FEEDERENABLED		= 0x1002,
		CAP_FEEDERLOADED		= 0x1003,
		CAP_TIMEDATE			= 0x1004,
		CAP_SUPPORTEDCAPS		= 0x1005,
		CAP_EXTENDEDCAPS		= 0x1006,
		CAP_AUTOFEED			= 0x1007,
		CAP_CLEARPAGE			= 0x1008,
		CAP_FEEDPAGE			= 0x1009,
		CAP_REWINDPAGE			= 0x100a,
		CAP_INDICATORS			= 0x100b,
		CAP_SUPPORTEDCAPSEXT	= 0x100c,
		CAP_PAPERDETECTABLE		= 0x100d,
		CAP_UICONTROLLABLE		= 0x100e,
		CAP_DEVICEONLINE		= 0x100f,
		CAP_AUTOSCAN			= 0x1010,
		CAP_THUMBNAILSENABLED	= 0x1011,
		CAP_DUPLEX				= 0x1012,
		CAP_DUPLEXENABLED		= 0x1013,
		CAP_ENABLEDSUIONLY		= 0x1014,
		CAP_CUSTOMDSDATA		= 0x1015,
		CAP_ENDORSER			= 0x1016,
		CAP_JOBCONTROL			= 0x1017,
		ICAP_AUTOBRIGHT			= 0x1100,
		ICAP_BRIGHTNESS			= 0x1101,
		ICAP_CONTRAST			= 0x1103,
		ICAP_CUSTHALFTONE		= 0x1104,
		ICAP_EXPOSURETIME		= 0x1105,
		ICAP_FILTER				= 0x1106,
		ICAP_FLASHUSED			= 0x1107,
		ICAP_GAMMA				= 0x1108,
		ICAP_HALFTONES			= 0x1109,
		ICAP_HIGHLIGHT			= 0x110a,
		ICAP_IMAGEFILEFORMAT	= 0x110c,
		ICAP_LAMPSTATE			= 0x110d,
		ICAP_LIGHTSOURCE		= 0x110e,
		ICAP_ORIENTATION		= 0x1110,
		ICAP_PHYSICALWIDTH		= 0x1111,
		ICAP_PHYSICALHEIGHT		= 0x1112,
		ICAP_SHADOW				= 0x1113,
		ICAP_FRAMES				= 0x1114,
		ICAP_XNATIVERESOLUTION	= 0x1116,
		ICAP_YNATIVERESOLUTION	= 0x1117,
		ICAP_XRESOLUTION		= 0x1118,
		ICAP_YRESOLUTION		= 0x1119,
		ICAP_MAXFRAMES			= 0x111a,
		ICAP_TILES				= 0x111b,
		ICAP_BITORDER			= 0x111c,
		ICAP_CCITTKFACTOR		= 0x111d,
		ICAP_LIGHTPATH			= 0x111e,
		ICAP_PIXELFLAVOR		= 0x111f,
		ICAP_PLANARCHUNKY		= 0x1120,
		ICAP_ROTATION			= 0x1121,
		ICAP_SUPPORTEDSIZES		= 0x1122,
		ICAP_THRESHOLD			= 0x1123,
		ICAP_XSCALING			= 0x1124,
		ICAP_YSCALING			= 0x1125,
		ICAP_BITORDERCODES		= 0x1126,
		ICAP_PIXELFLAVORCODES	= 0x1127,
		ICAP_JPEGPIXELTYPE		= 0x1128,
		ICAP_TIMEFILL			= 0x112a,
		ICAP_BITDEPTH			= 0x112b,
		ICAP_BITDEPTHREDUCTION	= 0x112c,
		ICAP_UNDEFINEDIMAGESIZE	= 0x112d,
		ICAP_IMAGEDATASET		= 0x112e,
		ICAP_EXTIMAGEINFO		= 0x112f,
		ICAP_MINIMUMHEIGHT		= 0x1130,
		ICAP_MINIMUMWIDTH		= 0x1131
	}

	internal enum TwXferMechType
	{
		TWSX_NATIVE		= 0,
		TWSX_FILE		= 1,
		TWSX_MEMORY		= 2
	}

	internal enum TwLang : short
	{
		TWLG_DAN		= 0,	// Danish
		TWLG_DUT		= 1,	// Dutch
		TWLG_ENG		= 2,	// International English
		TWLG_FCF		= 3,	// French Canadian
		TWLG_FIN		= 4,	// Finnish
		TWLG_FRN		= 5,	// French
		TWLG_GER		= 6,	// German
		TWLG_ICE		= 7,	// Icelandic
		TWLG_ITN		= 8,	// Italian
		TWLG_NOR		= 9,	// Norwegian
		TWLG_POR		= 10,	// Portuguese
		TWLG_SPA		= 11,	// Spanish
		TWLG_SWE		= 12,	// Swedish
		TWLG_USA		= 13	// U.S. English
	}

	internal enum TwState
	{
		TWAIN_PRESESSION		= 1,	// source manager not loaded
		TWAIN_SM_LOADED			= 2,	// source manager loaded
		TWAIN_SM_OPEN			= 3,	// source manager open
		TWAIN_SOURCE_OPEN		= 4,	// source open but not enabled
		TWAIN_SOURCE_ENABLED	= 5,	// source enabled to acquire
		TWAIN_TRANSFER_READY	= 6,	// image ready to transfer
		TWAIN_TRANSFERRING		= 7		// image in transit
	}
	#endregion

	#region Internal Class & Structs
	[StructLayout(LayoutKind.Sequential, Pack=2, CharSet=CharSet.Ansi)]
	internal class TwIdentity
	{									// TW_IDENTITY
		public IntPtr		Id;
		public TwVersion	Version;
		public short		ProtocolMajor;
		public short		ProtocolMinor;
		public int			SupportedGroups;
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst=34)]
		public string		Manufacturer;
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst=34)]
		public string		ProductFamily;
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst=34)]
		public string		ProductName;
	}

	[StructLayout(LayoutKind.Sequential, Pack=2, CharSet=CharSet.Ansi)]
	internal struct TwVersion
	{									// TW_VERSION
		public short		MajorNum;
		public short		MinorNum;
		public short		Language;
		public short		Country;
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst=34)]
		public string		Info;
	}

	[StructLayout(LayoutKind.Sequential, Pack=2)]
	internal class TwUserInterface
	{									// TW_USERINTERFACE
		public short		ShowUI;				// bool is strictly 32 bit, so use short
		public short		ModalUI;
		public IntPtr		ParentHand;
	}

	[StructLayout(LayoutKind.Sequential, Pack=2)]
	internal class TwStatus
	{									// TW_STATUS
		public short		ConditionCode = 0;		// TwCC
		public short		Reserved = 0;
	}

	[StructLayout(LayoutKind.Sequential, Pack=2)]
	internal struct TwEvent
	{									// TW_EVENT
		public IntPtr		EventPtr;
		public short		Message;
	}

	[StructLayout(LayoutKind.Sequential, Pack=2)]
	internal class TwImageInfo
	{									// TW_IMAGEINFO
		public int			XResolution = 0;
		public int			YResolution = 0;
		public int			ImageWidth = 0;
		public int			ImageLength = 0;
		public short		SamplesPerPixel = 0;
		[MarshalAs( UnmanagedType.ByValArray, SizeConst=8)]
		public short[]		BitsPerSample = null;
		public short		BitsPerPixel = 0;
		public short		Planar = 0;
		public short		PixelType = 0;
		public short		Compression = 0;
	}

	[StructLayout(LayoutKind.Sequential, Pack=2)]
	internal struct TwFrame
	{									// TW_FRAME
		public TwFix32	Left;
		public TwFix32	Top;
		public TwFix32	Right;
		public TwFix32	Bottom;
	}

	[StructLayout(LayoutKind.Sequential, Pack=2)]
	internal class TwImageLayout
	{										// TW_IMAGELAYOUT
		public TwFrame	Frame;				// Frame coords within larger document
		public uint		DocumentNumber = 0;
		public uint		PageNumber = 0;     // Reset when you go to next document
		public uint		FrameNumber = 0;    // Reset when you go to next page
	}

	[StructLayout(LayoutKind.Sequential, Pack=2)]
	internal class TwPendingXfers
	{									// TW_PENDINGXFERS
		public short		Count;
		public int			EOJ = 0;
	}

	[StructLayout(LayoutKind.Sequential, Pack=2)]
	internal struct TwFix32
	{												// TW_FIX32
		public short		Whole;
		public ushort		Frac;

		public TwFix32( float f )
		{
			int i = (int)((f * 65536.0f) + 0.5f);
			Whole = (short) (i >> 16);
			Frac = (ushort) (i & 0x0000ffff);
		}

		public float ToFloat()
		{
			return (float) Whole + ( (float)Frac /65536.0f );
		}
		public int ToInt()
		{
			return (int) (Frac << 16) + Whole;
		}
	}

	[StructLayout(LayoutKind.Sequential, Pack=2)]
	internal class TwCapability
	{
		public TwCapability( TwCap cap )
		{
			Cap = (short) cap;
			ConType = -1;
		}
		public TwCapability( TwCap cap, TwType itemType, int itemVal )
		{
			SetCapOneValue(cap, itemType, itemVal);
		}
		public TwCapability( TwCap cap, TwType itemType, float itemVal )
		{
			TwFix32  fix32 = new TwFix32(itemVal);
			SetCapOneValue(cap, itemType, fix32.ToInt());
		}
		~TwCapability()
		{
			if( Handle != IntPtr.Zero )
				Twain.GlobalFree( Handle );
		}
		public void SetCapOneValue(TwCap cap, TwType itemType, int itemVal)
		{
			Cap = (short) cap;
			ConType = (short) TwOn.One;
			Handle = Twain.GlobalAlloc( 0x42, 6 );
			IntPtr pv = Twain.GlobalLock( Handle );
			Marshal.WriteInt16( pv, 0, (short) itemType );
			Marshal.WriteInt32( pv, 2, itemVal );
			Twain.GlobalUnlock( Handle );
		}

		public short		Cap;
		public short		ConType;
		public IntPtr		Handle;
	}
	#endregion

	#region Public Enumerations
	/// <summary>
	/// TwainCommand enum
	/// </summary>
	public enum TwainCommand
	{
		/// <summary>
		/// Not
		/// </summary>
		Not				= -1,
		/// <summary>
		/// Null
		/// </summary>
		Null			= 0,
		/// <summary>
		/// TransferReady
		/// </summary>
		TransferReady	= 1,
		/// <summary>
		/// CloseRequest
		/// </summary>
		CloseRequest	= 2,
		/// <summary>
		/// CloseOk
		/// </summary>
		CloseOk			= 3,
		/// <summary>
		/// DeviceEvent
		/// </summary>
		DeviceEvent		= 4
	}
	/// <summary>
	/// TwainPixelType enum
	/// </summary>
	public enum TwainPixelType
	{
		/// <summary>
		/// TWPT_BW
		/// </summary>
		TWPT_BW			= 0,
		/// <summary>
		/// TWPT_GRAY
		/// </summary>
		TWPT_GRAY		= 1,
		/// <summary>
		/// TWPT_RGB
		/// </summary>
		TWPT_RGB		= 2,
		/// <summary>
		/// TWPT_PALETTE
		/// </summary>
		TWPT_PALETTE	= 3,
		/// <summary>
		/// TWPT_CMY
		/// </summary>
		TWPT_CMY		= 4,
		/// <summary>
		/// TWPT_CMYK
		/// </summary>
		TWPT_CMYK		= 5,
		/// <summary>
		/// TWPT_YUV
		/// </summary>
		TWPT_YUV		= 6,
		/// <summary>
		/// TWPT_YUVK
		/// </summary>
		TWPT_YUVK		= 7,
		/// <summary>
		/// TWPT_CIEXYZ
		/// </summary>
		TWPT_CIEXYZ		= 8
	}
	/// <summary>
	/// TwainBitDepth enum
	/// </summary>
	public enum TwainBitDepth
	{
		/// <summary>
		/// TWBR_THRESHOLD
		/// </summary>
		TWBR_THRESHOLD		= 0,
		/// <summary>
		/// TWBR_HALFTONE
		/// </summary>
		TWBR_HALFTONE		= 1,
		/// <summary>
		/// TWBR_CUSTHALFTONE
		/// </summary>
		TWBR_CUSTHALFTONE	= 2,
		/// <summary>
		/// TWBR_DIFFUSION
		/// </summary>
		TWBR_DIFFUSION		= 3
	}
	#endregion

	/// <summary>
	/// Twain Library Class
	/// </summary>
	public class Twain
	{
		#region Class Variables
		/// <summary>
		/// TWON_PROTOCOLMAJOR const
		/// </summary>
		public const short TWON_PROTOCOLMAJOR	= 1;
		/// <summary>
		/// TWON_PROTOCOLMINOR const
		/// </summary>
		public const short TWON_PROTOCOLMINOR	= 9;
		private const short CountryUSA		= 1;

		private IntPtr		hwnd;
		private TwIdentity	appid;
		private TwIdentity	srcds;
		private TwEvent		evtmsg;
		private Win32.MSG	winmsg;

		private Control		parent = null;
		private TwState		state = TwState.TWAIN_SM_LOADED;
		private string		errMsg = "";

		private bool		bBreakModalLoop = false;

		private float		resolutionX = 300.0f;
		private float		resolutionY = 300.0f;
		private bool		showUI = false;
		private bool		modalUI = false;
		#endregion

		#region Properties
		/// <summary>
		/// ResolutionX 를 가져오거나 설정합니다.
		/// </summary>
		public float ResolutionX
		{
			get { return resolutionX; }
			set { resolutionX = value; }
		}
		/// <summary>
		/// ResolutionY 를 가져오거나 설정합니다.
		/// </summary>
		public float ResolutionY
		{
			get { return resolutionY; }
			set { resolutionY = value; }
		}
		/// <summary>
		/// ShowUI 를 가져오거나 설정합니다.
		/// </summary>
		public bool	ShowUI
		{
			get { return showUI; }
			set { showUI = value; }
		}
		/// <summary>
		/// ModalUI 를 가져오거나 설정합니다.
		/// </summary>
		public bool ModalUI
		{
			get { return modalUI; }
			set { modalUI = value; }
		}
		/// <summary>
		/// 에러메세지를 가져옵니다.
		/// </summary>
		public string ErrMsg
		{
			get { return errMsg; }
		}
		#endregion

		#region Constructor and Destructor
		/// <summary>
		/// Twain 생성자
		/// </summary>
		public Twain()
		{
			appid = new TwIdentity();
			appid.Id				= IntPtr.Zero;
			appid.Version.MajorNum	= 1;
			appid.Version.MinorNum	= 1;
			appid.Version.Language	= (short)TwLang.TWLG_USA;
			appid.Version.Country	= CountryUSA;
			appid.Version.Info		= "ICM Twain 1.1";
			appid.ProtocolMajor		= TWON_PROTOCOLMAJOR;
			appid.ProtocolMinor		= TWON_PROTOCOLMINOR;
			appid.SupportedGroups	= (int)(TwDG.Image | TwDG.Control);
			appid.Manufacturer		= "ICM Inc.";
			appid.ProductFamily		= "ICM Twain Library";
			appid.ProductName		= "ICM ISS";

			srcds = new TwIdentity();
			srcds.Id = IntPtr.Zero;

			evtmsg.EventPtr = Marshal.AllocHGlobal( Marshal.SizeOf( winmsg ) );

			state = TwState.TWAIN_SM_LOADED;
		}
		/// <summary>
		/// Twain 소멸자
		/// </summary>
		~Twain()
		{
			Marshal.FreeHGlobal( evtmsg.EventPtr );
		}
		#endregion

		#region ScanImage
		/// <summary>
		/// Image를 Scan합니다.
		/// </summary>
		/// <param name="parent"></param>
		/// <param name="pixelType"></param>
		/// <param name="bitDepth"></param>
		/// <param name="showProgress"></param>
		/// <param name="scanRect"></param>
		/// <param name="imageSize"></param>
		/// <returns></returns>
		public Image ScanImage(Control parent, TwainPixelType pixelType, TwainBitDepth bitDepth, bool showProgress,
			RectangleF scanRect, Size imageSize)
		{
			if (parent == null)
			{
				errMsg = "Parent is null!";
				return null;
			}

			this.parent = parent;

			// Open Source Manager
			if (!Init(parent.Handle))
			{
				errMsg = "Initialize Error";
				Finish();
				return null;
			}

			CloseSrc();
			// Open the System Default Source
			if (!OpenDefaultSource())
			{
				errMsg = "Open the System Default Source Error";
				Finish();
				return null;
			}

			// 0:INCH, 1: CM
			if (!SetUnits(0))
			{
				errMsg = "SetUnits Error";
				Finish();
				return null;
			}

			// PixelType Set
			if (!SetPixelType(pixelType))
			{
				errMsg = "SetPixelType Error";
				Finish();
				return null;
			}

			// BitDepth Set
			if (!SetBitDepth(bitDepth))
			{
				errMsg = "SetBitDepth Error";
				Finish();
				return null;
			}

			// Progress Indicator
			if (!SetProgressIndicator(showProgress))
			{
				errMsg = "SetProgressIndicator Error";
				Finish();
				return null;
			}

			// Scan Resolution
			float screnResX = resolutionX * imageSize.Width / scanRect.Width;
			float screnResY = resolutionY * imageSize.Height / scanRect.Height;
			// ImageLayout Set
			if (!SetImageLayout(scanRect, screnResX, screnResY))
			{
				errMsg = "SetImageLayout Error";
				Finish();
				return null;
			}

			// SetXferMech to Native
			if (!SetXferMech(TwXferMechType.TWSX_NATIVE))
			{
				errMsg = "SetXferMech Error";
				Finish();
				return null;
			}

			// Create Pending Xfer
			TwPendingXfers pxfr = new TwPendingXfers();
			pxfr.Count = 0;

			// Acquire and Wait for Native Xfer
			IntPtr hbitmap = IntPtr.Zero;
			if (!WaitForXfer(pxfr, ref hbitmap))
			{
				errMsg = "WaitForXfer Error";
				Finish();
				return null;
			}

			Rectangle bmpRect = new Rectangle(0, 0, 0, 0);
			IntPtr bmpptr = GlobalLock(hbitmap);
			IntPtr pixptr = GetPixelInfo(bmpptr, ref bmpRect);

			//
			Bitmap image = new Bitmap(bmpRect.Width, bmpRect.Height);
			Graphics g = Graphics.FromImage(image);
			IntPtr hdc = g.GetHdc();
			SetDIBitsToDevice(hdc, 0, 0, bmpRect.Width, bmpRect.Height,
					0, 0, 0, bmpRect.Height, pixptr, bmpptr, 0 );
			g.ReleaseHdc(hdc);

			// Abort All PendingXfers
			EndXfer(pxfr);
			ResetXfer(pxfr);

			// Close Source Manager
			Finish();

			GlobalFree(hbitmap);

			return image;
		}
		#endregion
		/// <summary>
		/// Pixel정보를 가져옵니다.
		/// </summary>
		/// <param name="bmpptr"></param>
		/// <param name="bmpRect"></param>
		/// <returns></returns>
		protected IntPtr GetPixelInfo(IntPtr bmpptr, ref Rectangle bmpRect)
		{
			BITMAPINFOHEADER	bmi = new BITMAPINFOHEADER();
			Marshal.PtrToStructure( bmpptr, bmi );

			bmpRect.X = bmpRect.Y = 0;
			bmpRect.Width = bmi.biWidth;
			bmpRect.Height = bmi.biHeight;

			if( bmi.biSizeImage == 0 )
				bmi.biSizeImage = ((((bmi.biWidth * bmi.biBitCount) + 31) & ~31) >> 3) * bmi.biHeight;

			int p = bmi.biClrUsed;
			if( (p == 0) && (bmi.biBitCount <= 8) )
				p = 1 << bmi.biBitCount;
			p = (p * 4) + bmi.biSize + (int) bmpptr;
			return (IntPtr) p;
		}


		#region Parameter Set Methods
		private bool SetUnits(int nUnit)
		{
			TwRC rc = SetCapOneValue(TwCap.ICAP_UNITS, TwType.UInt16, nUnit);
			return (rc == TwRC.Success);
		}

		private bool SetPixelType(TwainPixelType pixelType)
		{
			TwRC rc = SetCapOneValue(TwCap.ICAP_PIXELTYPE, TwType.UInt16, (int)pixelType);
			return (rc == TwRC.Success);
		}

		private bool SetBitDepth(TwainBitDepth bitDepth)
		{
			TwRC rc = SetCapOneValue(TwCap.ICAP_BITDEPTH, TwType.UInt16, (int)bitDepth);
			return (rc == TwRC.Success);
		}

		private bool SetProgressIndicator(bool show)
		{
			TwRC rc = SetCapOneValue(TwCap.CAP_INDICATORS, TwType.Bool, (show ? 1 : 0));
			return (rc == TwRC.Success);
		}

		private bool SetXferMech(TwXferMechType mech)
		{
			TwRC rc = SetCapOneValue(TwCap.ICAP_XFERMECH, TwType.UInt16, (int)mech);
			return (rc == TwRC.Success);
		}

		private bool SetResolution(float xResolution, float yResolution)
		{
			TwRC rc = SetCapOneValue(TwCap.ICAP_XRESOLUTION, TwType.Fix32, xResolution);
			if (rc == TwRC.Success)
				rc = SetCapOneValue(TwCap.ICAP_YRESOLUTION, TwType.Fix32, yResolution);
			return (rc == TwRC.Success);
		}
		/// <summary>
		/// Image Layout을 Setting 합니다.
		/// </summary>
		/// <param name="frameRect"></param>
		/// <param name="xResolution"></param>
		/// <param name="yResolution"></param>
		/// <returns></returns>
		public bool SetImageLayout(RectangleF frameRect, float xResolution, float yResolution)
		{
			TwImageLayout imageLayout = new TwImageLayout();
			imageLayout.Frame.Left = new TwFix32(frameRect.Left / xResolution);
			imageLayout.Frame.Right = new TwFix32(frameRect.Right / xResolution);
			imageLayout.Frame.Top = new TwFix32(frameRect.Top / yResolution);
			imageLayout.Frame.Bottom = new TwFix32(frameRect.Bottom / yResolution);
			imageLayout.FrameNumber = 1;
			TwRC rc = TwRC.Failure;
			if (SetResolution(xResolution, yResolution))
				rc = DSilay(appid, srcds, TwDG.Image, TwDAT.ImageLayout, TwMSG.Set, imageLayout);
			return (rc == TwRC.Success);
		}

		internal TwRC SetCapOneValue(TwCap cap, TwType itemType, int itemVal)
		{
			TwCapability twCap = new TwCapability(cap, itemType, itemVal);
			return DScap( appid, srcds, TwDG.Control, TwDAT.Capability, TwMSG.Set, twCap );
		}
		internal TwRC SetCapOneValue(TwCap cap, TwType itemType, float itemVal)
		{
			TwCapability twCap = new TwCapability(cap, itemType, itemVal);
			return DScap( appid, srcds, TwDG.Control, TwDAT.Capability, TwMSG.Set, twCap );
		}
		#endregion

		#region Private
		// Open the System Default Source
		private bool OpenDefaultSource()
		{
			TwRC rc = DSMident( appid, IntPtr.Zero, TwDG.Control, TwDAT.Identity, TwMSG.OpenDS, srcds );
			if (rc == TwRC.Success)
			{
				state = TwState.TWAIN_SOURCE_OPEN;
				return true;
			}
			else
				return false;
		}

		// Enable Source
		private bool EnableSource()
		{
			TwUserInterface	guif = new TwUserInterface();
			guif.ShowUI = (short)(showUI ? 1 : 0);
			guif.ModalUI = (short)(modalUI ? 1 : 0);
			guif.ParentHand = hwnd;
			TwRC rc = DSuserif( appid, srcds, TwDG.Control, TwDAT.UserInterface, TwMSG.EnableDS, guif );
			if( rc != TwRC.Success )
			{
				CloseSrc();
				return false;
			}
			state = TwState.TWAIN_SOURCE_ENABLED;
			return true;
		}

		// Native Image Xfer
		private bool ImageNativeXfer(ref IntPtr hbitmap)
		{
			TwRC rc = DSixfer(appid, srcds, TwDG.Image, TwDAT.ImageNativeXfer, TwMSG.Get, ref hbitmap);
			if(rc != TwRC.XferDone)
			{
				CloseSrc();
				return false;
			}
			return true;
		}

		// End Xfer
		private bool EndXfer(TwPendingXfers pxfr)
		{
			TwRC rc = DSpxfer( appid, srcds, TwDG.Control, TwDAT.PendingXfers, TwMSG.EndXfer, pxfr );
			if( rc != TwRC.Success )
			{
				CloseSrc();
				return false;
			}
			state = (pxfr.Count > 0 ? TwState.TWAIN_TRANSFER_READY : TwState.TWAIN_SOURCE_ENABLED);
			return true;
		}

		// Reset Xfer
		private bool ResetXfer(TwPendingXfers pxfr)
		{
			TwRC rc = DSpxfer( appid, srcds, TwDG.Control, TwDAT.PendingXfers, TwMSG.Reset, pxfr );
			if( rc != TwRC.Success )
				return false;
			state = TwState.TWAIN_SOURCE_ENABLED;
			return true;
		}

		// Process Event
		private TwRC ProcessEvent(Win32.MSG msg)
		{
			Marshal.StructureToPtr(msg, evtmsg.EventPtr, false);
			evtmsg.Message = (short) TwMSG.Null;
			TwRC rc = DSevent( appid, srcds, TwDG.Control, TwDAT.Event, TwMSG.ProcessEvent, ref evtmsg );
			return rc;
		}

		private bool WaitForXfer(TwPendingXfers pxfr, ref IntPtr hbitmap)
		{
			bool bWasEnabled = parent.Enabled;
			// Disable the parent window during the modal acquire
			parent.Enabled = false;

			if (state == TwState.TWAIN_TRANSFER_READY)
			{
				DoOneTransfer(pxfr, ref hbitmap);
			}
			else if (state >= TwState.TWAIN_SOURCE_ENABLED || EnableSource())
			{
				// source is enabled, wait for transfer or source closed
				ModalEventLoop(pxfr, ref hbitmap);
			}
			else
			{
				errMsg = "Failed to enable Data Source.";
				parent.Enabled = bWasEnabled;
				return false;
			}

			// Re-enable the parent window if it was enabled
			parent.Enabled = bWasEnabled;
			return true;
		}

		private bool DoOneTransfer(TwPendingXfers pxfr, ref IntPtr hbitmap)
		{
			Debug.Assert(state == TwState.TWAIN_TRANSFER_READY,
				"State Not TRANSFER_READY.");
			if (!ImageNativeXfer(ref hbitmap))
				return false;

			// If inside ModalEventLoop, break out
			bBreakModalLoop = true;

			// Acknowledge transfer
			return EndXfer(pxfr);
		}

		private bool ModalEventLoop(TwPendingXfers pxfr, ref IntPtr hbitmap)
		{
			Win32.MSG msg = new Win32.MSG();
			// Clear global breakout flag
			bBreakModalLoop = false;

			while ((state >= TwState.TWAIN_SOURCE_ENABLED) && !bBreakModalLoop)
			{
				bool ret = User32.GetMessage(ref msg, 0, 0, 0);
				if (!ret) break;

				if (!MessageHook (pxfr, ref msg, ref hbitmap))
				{
					User32.TranslateMessage(ref msg);
					User32.DispatchMessage(ref msg);
				}
			}
			bBreakModalLoop = false;

			return true;
		}

		// returns true if msg processed by TWAIN (source)
		private bool MessageHook(TwPendingXfers pxfr, ref Win32.MSG msg, ref IntPtr hbitmap)
		{
			bool   bProcessed = false;

			if (state >= TwState.TWAIN_SOURCE_ENABLED) 
			{
				// see if source wants to process (eat) the message
				bProcessed = (ProcessEvent(msg) == TwRC.DSEvent);
				switch (evtmsg.Message)
				{
					case (short) TwMSG.XFerReady :
						state = TwState.TWAIN_TRANSFER_READY;
						DoOneTransfer(pxfr, ref hbitmap);
						break;
					case (short) TwMSG.CloseDSReq :
						// Disable Source
						CloseSrc(true);
						break;
					case (short) TwMSG.Null :
						// no message returned from DS
						break;
				}
			}
			return bProcessed;
		}
		#endregion

		#region Init
		/// <summary>
		/// 초기화합니다.
		/// </summary>
		/// <param name="hwndp"></param>
		/// <returns></returns>
		public bool Init( IntPtr hwndp )
		{
			Finish();
			// Open Source Manager
			TwRC rc = DSMparent( appid, IntPtr.Zero, TwDG.Control, TwDAT.Parent, TwMSG.OpenDSM, ref hwndp );
			if( rc == TwRC.Success )
			{
				state = TwState.TWAIN_SM_OPEN;
				rc = DSMident( appid, IntPtr.Zero, TwDG.Control, TwDAT.Identity, TwMSG.GetDefault, srcds );
				if( rc == TwRC.Success )
				{
					hwnd = hwndp;
					return true;
				}
				else
				{
					rc = DSMparent( appid, IntPtr.Zero, TwDG.Control, TwDAT.Parent, TwMSG.CloseDSM, ref hwndp );
					if( rc == TwRC.Success )
						state = TwState.TWAIN_SM_LOADED;
				}
			}
			return false;
		}
		#endregion

		#region Select
		// Select Image Source
		/// <summary>
		/// Image Source를 선택합니다.
		/// </summary>
		public void Select()
		{
			TwRC rc;
			CloseSrc();
			if( appid.Id == IntPtr.Zero )
			{
				Init( hwnd );
				if( appid.Id == IntPtr.Zero )
					return;
			}
			rc = DSMident( appid, IntPtr.Zero, TwDG.Control, TwDAT.Identity, TwMSG.UserSelect, srcds );
		}
		#endregion

		#region Acquire
		/// <summary>
		/// Image를 포착합니다.
		/// </summary>
		public void Acquire()
		{
			TwRC rc;
			CloseSrc();
			if( appid.Id == IntPtr.Zero )
			{
				Init( hwnd );
				if( appid.Id == IntPtr.Zero )
					return;
			}

			// Open the System Default Source
			if (!OpenDefaultSource())
				return;

			// Negotiate XferCount
			TwCapability cap = new TwCapability( TwCap.CAP_XFERCOUNT, TwType.Int16, 1 );
			rc = DScap( appid, srcds, TwDG.Control, TwDAT.Capability, TwMSG.Set, cap );
			if( rc != TwRC.Success )
			{
				CloseSrc();
				return;
			}

			// Enable Source
			EnableSource();
		}
		#endregion

		#region TransferPictures
		/// <summary>
		/// Image를 ArrayList 추가합니다.
		/// </summary>
		/// <returns> Image가 담긴 ArrayList </returns>
		public ArrayList TransferPictures()
		{
			ArrayList pics = new ArrayList();
			if( srcds.Id == IntPtr.Zero )
				return pics;

			TwRC rc;
			IntPtr hbitmap = IntPtr.Zero;
			TwPendingXfers pxfr = new TwPendingXfers();

			do
			{
				pxfr.Count = 0;
				hbitmap = IntPtr.Zero;

				TwImageInfo	iinf = new TwImageInfo();
				rc = DSiinf( appid, srcds, TwDG.Image, TwDAT.ImageInfo, TwMSG.Get, iinf );
				if( rc != TwRC.Success )
				{
					CloseSrc();
					return pics;
				}

				// Native Image Xfer
				if (!ImageNativeXfer(ref hbitmap))
					return pics;

				if (!EndXfer(pxfr))
					return pics;

				pics.Add( hbitmap );
			}
			while( pxfr.Count != 0 );

			// Reset Xfer
			ResetXfer(pxfr);

			return pics;
		}
		#endregion

		#region PassMessage
		/// <summary>
		/// Window Message를 Pass 합니다.
		/// </summary>
		/// <param name="m"> Window Message </param>
		/// <returns> TwainCommand enum </returns>
		public TwainCommand PassMessage( ref Message m )
		{
			if( srcds.Id == IntPtr.Zero )
				return TwainCommand.Not;

			int pos = User32.GetMessagePos();

			winmsg.hwnd		= m.HWnd;
			winmsg.message	= m.Msg;
			winmsg.wParam	= m.WParam;
			winmsg.lParam	= m.LParam;
			winmsg.time		= User32.GetMessageTime();
			winmsg.pt_x		= (short) pos;
			winmsg.pt_y		= (short) (pos >> 16);

			// Process Event
			TwRC rc = ProcessEvent(winmsg);
			if( rc == TwRC.NotDSEvent )
				return TwainCommand.Not;
			switch (evtmsg.Message)
			{
				case (short) TwMSG.XFerReady :
					state = TwState.TWAIN_TRANSFER_READY;
					return TwainCommand.TransferReady;
				case (short) TwMSG.CloseDSReq :
					return TwainCommand.CloseRequest;
				case (short) TwMSG.CloseDSOK :
					return TwainCommand.CloseOk;
				case (short) TwMSG.DeviceEvent :
					return TwainCommand.DeviceEvent;
			}

			return TwainCommand.Null;
		}
		#endregion

		#region CloseSrc
		/// <summary>
		/// Image Source를 닫습니다.
		/// </summary>
		/// <param name="disableOnly"></param>
		public void CloseSrc(bool disableOnly)
		{
			TwRC rc;
			if( srcds.Id != IntPtr.Zero )
			{
				if (state > TwState.TWAIN_SOURCE_OPEN)
				{
					TwUserInterface	guif = new TwUserInterface();
					rc = DSuserif( appid, srcds, TwDG.Control, TwDAT.UserInterface, TwMSG.DisableDS, guif );
					state = TwState.TWAIN_SOURCE_OPEN;
				}
				if (disableOnly) return;

				if (state > TwState.TWAIN_SM_OPEN)
				{
					rc = DSMident( appid, IntPtr.Zero, TwDG.Control, TwDAT.Identity, TwMSG.CloseDS, srcds );
					state = TwState.TWAIN_SM_OPEN;
				}
			}
		}
		/// <summary>
		/// Image Source를 닫습니다.
		/// </summary>
		public void CloseSrc()
		{
			CloseSrc(false);
		}
		#endregion

		#region Finish
		/// <summary>
		/// 종료합니다.
		/// </summary>
		public void Finish()
		{
			TwRC rc;
			CloseSrc();
			if( appid.Id != IntPtr.Zero )
			{
				if (state > TwState.TWAIN_SM_LOADED)
				{
					rc = DSMparent( appid, IntPtr.Zero, TwDG.Control, TwDAT.Parent, TwMSG.CloseDSM, ref hwnd );
					state = TwState.TWAIN_SM_LOADED;
				}
			}
			appid.Id = IntPtr.Zero;
		}
		#endregion

		#region Static Methods
		/// <summary>
		/// ScreenBitDepth를 가져옵니다.
		/// </summary>
		public static int ScreenBitDepth
		{
			get
			{
				IntPtr screenDC = Gdi32.CreateDC( "DISPLAY", null, null, IntPtr.Zero );
				int bitDepth = Gdi32.GetDeviceCaps( screenDC, 12 );
				bitDepth *= Gdi32.GetDeviceCaps( screenDC, 14 );
				Gdi32.DeleteDC( screenDC );
				return bitDepth;
			}
		}
		#endregion

		#region Extern DllImport Methods
		// ------ DSM entry point DAT_ variants:
		[DllImport("twain_32.dll", EntryPoint="#1")]
		private static extern TwRC DSMparent( [In, Out] TwIdentity origin, IntPtr zeroptr, TwDG dg, TwDAT dat, TwMSG msg, ref IntPtr refptr );

		[DllImport("twain_32.dll", EntryPoint="#1")]
		private static extern TwRC DSMident( [In, Out] TwIdentity origin, IntPtr zeroptr, TwDG dg, TwDAT dat, TwMSG msg, [In, Out] TwIdentity idds );

		[DllImport("twain_32.dll", EntryPoint="#1")]
		private static extern TwRC DSMstatus( [In, Out] TwIdentity origin, IntPtr zeroptr, TwDG dg, TwDAT dat, TwMSG msg, [In, Out] TwStatus dsmstat );


		// ------ DSM entry point DAT_ variants to DS:
		[DllImport("twain_32.dll", EntryPoint="#1")]
		private static extern TwRC DSuserif( [In, Out] TwIdentity origin, [In, Out] TwIdentity dest, TwDG dg, TwDAT dat, TwMSG msg, TwUserInterface guif );

		[DllImport("twain_32.dll", EntryPoint="#1")]
		private static extern TwRC DSevent( [In, Out] TwIdentity origin, [In, Out] TwIdentity dest, TwDG dg, TwDAT dat, TwMSG msg, ref TwEvent evt );

		[DllImport("twain_32.dll", EntryPoint="#1")]
		private static extern TwRC DSstatus( [In, Out] TwIdentity origin, [In] TwIdentity dest, TwDG dg, TwDAT dat, TwMSG msg, [In, Out] TwStatus dsmstat );

		[DllImport("twain_32.dll", EntryPoint="#1")]
		private static extern TwRC DScap( [In, Out] TwIdentity origin, [In] TwIdentity dest, TwDG dg, TwDAT dat, TwMSG msg, [In, Out] TwCapability capa );

		[DllImport("twain_32.dll", EntryPoint="#1")]
		private static extern TwRC DSiinf( [In, Out] TwIdentity origin, [In] TwIdentity dest, TwDG dg, TwDAT dat, TwMSG msg, [In, Out] TwImageInfo imginf );

		[DllImport("twain_32.dll", EntryPoint="#1")]
		private static extern TwRC DSilay( [In, Out] TwIdentity origin, [In] TwIdentity dest, TwDG dg, TwDAT dat, TwMSG msg, [In, Out] TwImageLayout imglay );

		[DllImport("twain_32.dll", EntryPoint="#1")]
		private static extern TwRC DSixfer( [In, Out] TwIdentity origin, [In] TwIdentity dest, TwDG dg, TwDAT dat, TwMSG msg, ref IntPtr hbitmap );

		[DllImport("twain_32.dll", EntryPoint="#1")]
		private static extern TwRC DSpxfer( [In, Out] TwIdentity origin, [In] TwIdentity dest, TwDG dg, TwDAT dat, TwMSG msg, [In, Out] TwPendingXfers pxfr );

		// Kernel32
		[DllImport("kernel32.dll", ExactSpelling=true)]
		internal static extern IntPtr GlobalAlloc( int flags, int size );

		[DllImport("kernel32.dll", ExactSpelling=true)]
		internal static extern IntPtr GlobalLock( IntPtr handle );

		[DllImport("kernel32.dll", ExactSpelling=true)]
		internal static extern bool GlobalUnlock( IntPtr handle );

		[DllImport("kernel32.dll", ExactSpelling=true)]
		internal static extern IntPtr GlobalFree( IntPtr handle );
		#endregion

		[DllImport("gdi32.dll", ExactSpelling=true)]
		internal static extern int SetDIBitsToDevice( IntPtr hdc, int xdst, int ydst,
			int width, int height, int xsrc, int ysrc, int start, int lines,
			IntPtr bitsptr, IntPtr bmiptr, int color );

		[StructLayout(LayoutKind.Sequential, Pack=2)]
		internal class BITMAPINFOHEADER
		{
			public int      biSize = 0;
			public int      biWidth = 0;
			public int      biHeight = 0;
			public short    biPlanes = 0;
			public short    biBitCount = 0;
			public int      biCompression = 0;
			public int      biSizeImage = 0;
			public int      biXPelsPerMeter = 0;
			public int      biYPelsPerMeter = 0;
			public int      biClrUsed = 0;
			public int      biClrImportant = 0;
		}

	}
}