using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Resources;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace IHIS.Framework
{
	#region XTaskBarUtil Class
	internal class XTaskBarUtil
	{
		// pointer to a shellstyle dll
		private static IntPtr hModule = IntPtr.Zero;
		private static Font expandoTitleFont = new Font("MS UI Gothic",9.75f, FontStyle.Bold);
        //<FOR_WIN7>
        private static string resStringNormalColor = string.Empty;  //ColorName이 NormalColor일때 Win7에서 사용할 Resource string
        private static string resStringMetallic = string.Empty;  //ColorName이 Metallic일때 Win7에서 사용할 Resource string
        private static string resStringHomestead = string.Empty;  //ColorName이 Homestead일때 Win7에서 사용할 Resource string

		#region static Property
		public static Font ExpandoTitleFont
		{
			get { return expandoTitleFont;}
		}
		/// <summary>
		/// Reports whether the current application's user interface 
		/// displays using visual styles
		/// </summary>
		public static bool AppThemed
		{
			get
			{
				bool themed = false;
			
				OperatingSystem os = System.Environment.OSVersion;

				// check if the OS id XP or higher
				// fix:	Win2k3 now recognised
				//      Russkie (codeprj@webcontrol.net.au)
				if (os.Platform == PlatformID.Win32NT && ((os.Version.Major == 5 && os.Version.Minor >= 1) || os.Version.Major > 5))
				{
					themed = IsAppThemed();
				}

				return themed;
			}
		}
        //<FOR_WIN7>
        public static bool IsWindow7
        {
            get
            {
                //Window7 Version 이상의 OS인지를 확인, Resource File의 관리가 Window7이상에서는 다르게 바뀜.
                OperatingSystem os = System.Environment.OSVersion;
                //os.Version.Major >= 6 이면 Window 7
                if (os.Platform == PlatformID.Win32NT && os.Version.Major >= 6)
                    return true;
                else
                    return false;
            }
        }
		/// <summary>
		/// Retrieves the name of the current visual style
		/// </summary>
		public static String ThemeName
		{
			get
			{
				StringBuilder themeName = new StringBuilder(256);

				GetCurrentThemeName(themeName, 256, null, 0, null, 0);

				return themeName.ToString();
			}
		}
		/// <summary>
		/// Retrieves the color scheme name of the current visual style
		/// </summary>
		public static String ColorName
		{
			get
			{
				StringBuilder themeName = new StringBuilder(256);
				StringBuilder colorName = new StringBuilder(256);

				GetCurrentThemeName(themeName, 256, colorName, 256, null, 0);

				return colorName.ToString();
			}
		}
		#endregion

        #region 생성자
        static XTaskBarUtil()
        {
            //Win7 이상이면 Resource에서 XTaskBarUIResource에 있는 string GET
            //<FOR_WIN7>
            if (IsWindow7)
            {
                System.Reflection.Assembly l_as = System.Reflection.Assembly.GetExecutingAssembly();
                using (Stream sr = l_as.GetManifestResourceStream("IHIS.Framework.XTaskBar.XTaskBarResourceNormalColor.txt"))
                {
                    byte[] readBytes = new byte[sr.Length];
                    sr.Read(readBytes, 0, (int) sr.Length);
                    resStringNormalColor = Encoding.Default.GetString(readBytes);
                }
                using (Stream sr = l_as.GetManifestResourceStream("IHIS.Framework.XTaskBar.XTaskBarResourceMetallic.txt"))
                {
                    byte[] readBytes = new byte[sr.Length];
                    sr.Read(readBytes, 0, (int)sr.Length);
                    resStringMetallic = Encoding.Default.GetString(readBytes);
                }
                using (Stream sr = l_as.GetManifestResourceStream("IHIS.Framework.XTaskBar.XTaskBarResourceHomestead.txt"))
                {
                    byte[] readBytes = new byte[sr.Length];
                    sr.Read(readBytes, 0, (int)sr.Length);
                    resStringHomestead = Encoding.Default.GetString(readBytes);
                }
            }

        }
        #endregion


        /// <summary>
		/// Gets the System defined settings for the ExplorerBar according
		/// to the current System theme
		/// </summary>
		public static XTaskBarSetting GetTaskBarSetting()
		{
			XTaskBarSetting taskBarSetting = null;

			if (AppThemed && LoadShellStyleDll())
			{
				// get the uifile contained in the shellstyle.dll
				// and get ready to parse it
                // <FOR_WIN7> Window7이상에서는 GetResourceUIFile 하지 않고, resourceString 사용
                // Window7에서는 Resource 파일의 관리 Point가 달라서 GetResourceUIFile()한 string으로는 Parsing하지 못함.
                // 따라서, resourceString에 XP기반의 string을 넣어서 관리하고, 이를 사용한다.
                // 현재 PC에서 사용하는 ColorName에 따라 Resource String 변경
                string uiFile = "";
                if (IsWindow7)
                {
                    string colorName = ColorName;
                    if (colorName.ToUpper() == "NORMALCOLOR") //NormalColor
                        uiFile = resStringNormalColor;
                    else if (colorName.ToUpper() == "METALLIC") //Metallic
                        uiFile = resStringMetallic;
                    else if (colorName.ToUpper() == "HOMESTEAD") //HomeStead
                        uiFile = resStringNormalColor;
                    else //기타 NormalColor
                        uiFile = resStringNormalColor;
                }
                else
                {
                    uiFile = GetResourceUIFile();
                }
                XTaskBarParser parser = new XTaskBarParser(uiFile);

				// let the parser do its stuff
				taskBarSetting = parser.Parse();
				
				// unload the shellstyle.dll
				FreeShellStyleDll();
			}
			else
			{
				// no themes available, so use default settings
				taskBarSetting = new XTaskBarSetting();
				taskBarSetting.UseClassicTheme();

				// add non-themed arrows as the ExplorerBar will
				// look funny without them.
				taskBarSetting.SetUnthemedArrowImages();
			}
			
			return taskBarSetting;
		}
		

		private static bool LoadShellStyleDll()
		{
			// work out the path to the shellstyle.dll according
			// to the current theme
			string themeName = ThemeName.Substring(0, ThemeName.LastIndexOf('\\'));
			string styleName = themeName + "\\Shell\\" + ColorName;
			string stylePath = styleName + "\\shellstyle.dll";

			// if for some reason it doesn't exist, use the default 
			// shellstyle.dll in the windows\system32 directory
			if (!File.Exists(stylePath))
			{
				stylePath = Environment.GetFolderPath(Environment.SpecialFolder.System) + "\\shellstyle.dll";
			}
			// make sure Windows won't throw up any error boxes if for
			// some reason it can't find the dll
			int lastErrorMode = InternalSetErrorMode((int) (SetErrorModeFlags.SEM_FAILCRITICALERRORS | SetErrorModeFlags.SEM_NOOPENFILEERRORBOX));
			
			// attempt to load the shellstyle dll
			hModule = InternalLoadLibraryEx(stylePath, IntPtr.Zero, (int) LoadLibraryExFlags.LOAD_LIBRARY_AS_DATAFILE);

			// set the error mode back to its original value
			InternalSetErrorMode(lastErrorMode);
			
			// return whether we succeeded
			return (hModule != IntPtr.Zero);
		}
		private static void FreeShellStyleDll()
		{
			// unload the dll
			FreeLibrary(hModule);

			// reset the hModule pointer
			hModule = IntPtr.Zero;
		}
		
		#region InternalMethods
        public static string GetResourceUIFileByName(string name, string file)
        {
            // locate the "UIFILE" resource
            IntPtr hResource = FindResource(hModule, name, file);
            if (hResource == IntPtr.Zero)
                return string.Empty;

            // get its size
            int resourceSize = SizeofResource(hModule, hResource);

            // load the resource
            IntPtr resourceData = LoadResource(hModule, hResource);

            // copy the resource data into a byte array so we
            // still have a copy once the resource is freed
            // fix: use GCHandle.Alloc to pin uiBytes
            //      Paul Haley (phaley@mail.com)
            //      03/06/2004
            //      v1.1
            byte[] uiBytes = new byte[resourceSize];
            GCHandle gcHandle = GCHandle.Alloc(uiBytes, GCHandleType.Pinned);
            IntPtr firstCopyElement = Marshal.UnsafeAddrOfPinnedArrayElement(uiBytes, 0);
            CopyMemory(firstCopyElement, resourceData, resourceSize);

            // free the resource
            gcHandle.Free();
            FreeResource(resourceData);

            // convert the char array to an ansi string
            string s = Marshal.PtrToStringAnsi(firstCopyElement, resourceSize);

            return s;
        }

		public static string GetResourceUIFile()
		{
			// locate the "UIFILE" resource
			IntPtr hResource = FindResource(hModule, "#1", "UIFILE");

			// get its size
			int resourceSize = SizeofResource(hModule, hResource);
			
			// load the resource
			IntPtr resourceData = LoadResource(hModule, hResource);
			
			// copy the resource data into a byte array so we
			// still have a copy once the resource is freed
			// fix: use GCHandle.Alloc to pin uiBytes
			//      Paul Haley (phaley@mail.com)
			//      03/06/2004
			//      v1.1
			byte[] uiBytes = new byte[resourceSize];
			GCHandle gcHandle = GCHandle.Alloc(uiBytes, GCHandleType.Pinned);
			IntPtr firstCopyElement = Marshal.UnsafeAddrOfPinnedArrayElement(uiBytes, 0);
			CopyMemory(firstCopyElement, resourceData, resourceSize);

			// free the resource
			gcHandle.Free();
			FreeResource(resourceData);

			// convert the char array to an ansi string
			string s = Marshal.PtrToStringAnsi(firstCopyElement, resourceSize);
			
			return s;
		}
		/// <summary>
		/// Returns a Bitmap from the currently loaded ShellStyle.dll
		/// </summary>
		/// <param name="resourceName">The name of the Bitmap to load</param>
		/// <returns>The Bitmap specified by the resourceName</returns>
		public static Bitmap GetResourceBMP(string resourceName)
		{
            try
            {
                // find the resource
                IntPtr hBitmap = LoadBitmap(hModule, Int32.Parse(resourceName));

                // load the bitmap
                Bitmap bitmap = Bitmap.FromHbitmap(hBitmap);

                return bitmap;
            }
            catch (Exception ex)
            {
                MessageBox.Show("XTaskBarUtil::GetResourceBMP resourceName=" + resourceName + "," + ex.Message + "," + ex.StackTrace);
                return null;
            }
		}
		/// <summary>
		/// Returns a Png Bitmap from the currently loaded ShellStyle.dll
		/// </summary>
		/// <param name="resourceName">The name of the Png to load</param>
		/// <returns>The Bitmap specified by the resourceName</returns>
		public static Bitmap GetResourcePNG(string resourceName)
		{
            try
            {
                // the resource size includes some header information (for PNG's in shellstyle.dll this
                // appears to be the standard 40 bytes of BITMAPHEADERINFO).
                const int FILE_HEADER_BYTES = 40;

                // load the bitmap resource normally to get dimensions etc.
                Bitmap tmpNoAlpha = Bitmap.FromResource(hModule, "#" + resourceName);
                IntPtr hResource = FindResource(hModule, "#" + resourceName, 2 /*RT_BITMAP*/ );
                int resourceSize = SizeofResource(hModule, hResource);

                // initialise 32bit alpha bitmap (target)
                Bitmap bitmap = new Bitmap(tmpNoAlpha.Width, tmpNoAlpha.Height, PixelFormat.Format32bppArgb);

                // load the resource via kernel32.dll (preserves alpha)
                IntPtr hLoadedResource = LoadResource(hModule, hResource);

                // copy bitmap data into byte array directly
                // still have a copy once the resource is freed
                // fix: use GCHandle.Alloc to pin uiBytes
                //      Paul Haley (phaley@mail.com)
                //      03/06/2004
                //      v1.1
                byte[] bitmapBytes = new byte[resourceSize];
                GCHandle gcHandle = GCHandle.Alloc(bitmapBytes, GCHandleType.Pinned);
                IntPtr firstCopyElement = Marshal.UnsafeAddrOfPinnedArrayElement(bitmapBytes, 0);
                // nb. we only copy the actual PNG data (no header)
                CopyMemory(firstCopyElement, hLoadedResource, resourceSize);
                FreeResource(hLoadedResource);

                // copy the byte array contents back to a handle to the alpha bitmap (use lockbits)
                Rectangle copyArea = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
                BitmapData alphaBits = bitmap.LockBits(copyArea, ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

                // copymemory to bitmap data (Scan0)
                firstCopyElement = Marshal.UnsafeAddrOfPinnedArrayElement(bitmapBytes, FILE_HEADER_BYTES);
                CopyMemory(alphaBits.Scan0, firstCopyElement, resourceSize - FILE_HEADER_BYTES);
                gcHandle.Free();

                // complete operation
                bitmap.UnlockBits(alphaBits);
                GdiFlush();

                // flip bits (not sure why this is needed at the moment..)
                bitmap.RotateFlip(RotateFlipType.RotateNoneFlipY);

                return bitmap;
            }
            catch (Exception ex)
            {
                MessageBox.Show("XTaskBarUtil::GetResourcePNG resourceName=" + resourceName + "," + ex.Message + "," + ex.StackTrace);
                return null;
            }
		}
		public static string GetResourceString(int id)
		{
			// return null if shellstyle.dll isn't loaded
			if (hModule == IntPtr.Zero)
				return null;

			// get the string
			StringBuilder buffer = new StringBuilder(1024);
			LoadString(hModule, id, buffer, 1024);

			return buffer.ToString();
		}
		#endregion

		#region Extern Method
		/// <summary>
		/// Reports whether the current application's user interface 
		/// displays using visual styles
		/// </summary>
		/// <returns>TRUE if the application has a visual style applied,
		/// FALSE otherwise</returns>
		[DllImport("UxTheme.dll")]
		private static extern bool IsAppThemed();
		[DllImport("UxTheme.dll", ExactSpelling=true, CharSet=CharSet.Unicode)]
		private static extern int GetCurrentThemeName(StringBuilder pszThemeFileName, int dwMaxNameChars, StringBuilder pszColorBuff, int cchMaxColorChars, StringBuilder pszSizeBuff, int cchMaxSizeChars);
		[DllImport("Kernel32.dll", EntryPoint="SetErrorMode")] 
		private static extern int InternalSetErrorMode(int uMode);
		[DllImport("Kernel32.dll", EntryPoint="LoadLibraryEx")]
		private static extern IntPtr InternalLoadLibraryEx(string lpfFileName, IntPtr hFile, int dwFlags);
		[DllImport("User32.dll")]
		private static extern IntPtr LoadBitmap(IntPtr hInstance, long lpBitmapName);
		[DllImport("Kernel32.dll")]
		private static extern IntPtr FindResource(IntPtr hModule, IntPtr lpName, IntPtr lpType);
		[DllImport( "Kernel32.dll" )]
		private static extern IntPtr FindResource(IntPtr hModule, int lpName, int lpType);
		[DllImport( "Kernel32.dll" )]
		private static extern IntPtr FindResource(IntPtr hModule, int lpName, string lpType);
		[DllImport( "Kernel32.dll" )]
		private static extern IntPtr FindResource(IntPtr hModule, string lpName, int lpType);
		[DllImport( "Kernel32.dll" )]
		private static extern IntPtr FindResource(IntPtr hModule, string lpName, string lpType);
		[DllImport("Kernel32.dll")]
		private static extern int SizeofResource(IntPtr hModule, IntPtr hResInfo);
		[DllImport("Kernel32.dll")]
		private static extern System.IntPtr LoadResource(IntPtr hModule, IntPtr hResInfo);
		[DllImport("Kernel32.dll")] 
		private static extern void CopyMemory(IntPtr Destination, IntPtr Source, int Length);
		[DllImport("Kernel32.dll")]
		private static extern bool FreeLibrary(IntPtr hModule);
		[DllImport("Gdi32.dll")] 
		private static extern int GdiFlush();
		[DllImport("Kernel32.dll")] 
		private static extern int FreeResource(IntPtr hglbResource);
		[DllImport("User32.dll")]
		private static extern int LoadString(IntPtr hInstance, int uID, StringBuilder lpBuffer, int nBufferMax);
		#endregion

		#region Enum
		/// <summary>
		/// Summary description for SetErrorModeFlags
		/// </summary>
		private enum SetErrorModeFlags
		{
			/// <summary>
			/// Use the system default, which is to display all error dialog boxes
			/// </summary>
			SEM_DEFAULT = 0,
		
			/// <summary>
			/// The system does not display the critical-error-handler message box. 
			/// Instead, the system sends the error to the calling process
			/// </summary>
			SEM_FAILCRITICALERRORS = 1,
		
			/// <summary>
			/// The system does not display the general-protection-fault message box. 
			/// This flag should only be set by debugging applications that handle 
			/// general protection (GP) faults themselves with an exception handler
			/// </summary>
			SEM_NOGPFAULTERRORBOX = 2,
			
			/// <summary>
			/// After this value is set for a process, subsequent attempts to clear 
			/// the value are ignored. 64-bit Windows:  The system automatically fixes 
			/// memory alignment faults and makes them invisible to the application. 
			/// It does this for the calling process and any descendant processes
			/// </summary>
			SEM_NOALIGNMENTFAULTEXCEPT = 4,
			
			/// <summary>
			/// The system does not display a message box when it fails to find a 
			/// file. Instead, the error is returned to the calling process
			/// </summary>
			SEM_NOOPENFILEERRORBOX = 32768
		}
		/// <summary>
		/// Summary description for LoadLibraryExFlags
		/// </summary>
		private enum LoadLibraryExFlags
		{
			/// <summary>
			/// If this value is used, and the executable module is a DLL, 
			/// the system does not call DllMain for process and thread 
			/// initialization and termination. Also, the system does not 
			/// load additional executable modules that are referenced by 
			/// the specified module. If this value is not used, and the 
			/// executable module is a DLL, the system calls DllMain for 
			/// process and thread initialization and termination. The system 
			/// loads additional executable modules that are referenced by 
			/// the specified module
			/// </summary>
			DONT_RESOLVE_DLL_REFERENCES = 1,
		
			/// <summary>
			/// If this value is used, the system maps the file into the calling 
			/// process's virtual address space as if it were a data file. Nothing 
			/// is done to execute or prepare to execute the mapped file. Use 
			/// this flag when you want to load a DLL only to extract messages 
			/// or resources from it
			/// </summary>
			LOAD_LIBRARY_AS_DATAFILE = 2,
		
			/// <summary>
			/// If this value is used, and lpFileName specifies a path, the 
			/// system uses the alternate file search strategy to find associated 
			/// executable modules that the specified module causes to be loaded. 
			/// If this value is not used, or if lpFileName does not specify a 
			/// path, the system uses the standard search strategy to find 
			/// associated executable modules that the specified module causes 
			/// to be loaded
			/// </summary>
			LOAD_WITH_ALTERED_SEARCH_PATH = 8,
		
			/// <summary>
			/// If this value is used, the system does not perform automatic 
			/// trust comparisons on the DLL or its dependents when they are 
			/// loaded
			/// </summary>
			LOAD_IGNORE_CODE_AUTHZ_LEVEL = 16
		}
		#endregion
	}
	#endregion

	#region StringTokenizer Class
	internal class StringTokenizer
	{
		#region Fields
		private int CurrIndex;
		private int NumTokens;
		private ArrayList tokens;
		private string StrSource;
		private string StrDelimiter;
		#endregion
		
		#region Properties
		public string Source
		{
			get	{ return this.StrSource;}
		}
		public string Delim
		{
			get	{ return this.StrDelimiter;}
		}
		#endregion

		#region 생성자
		public StringTokenizer(string source, string delimiter) 
		{
			this.tokens = new ArrayList(10);
			this.StrSource = source;
			this.StrDelimiter = delimiter;

			if(delimiter.Length == 0)
			{
				this.StrDelimiter = " ";
			}
			this.Tokenize();
		}
		public StringTokenizer(string source, char[] delimiter) : this(source, new string(delimiter))
		{
		}
		public StringTokenizer(string source) : this(source, "")
		{
		}
		#endregion

		#region Methods
		private void Tokenize()
		{
			string TempSource = this.StrSource;
			StringBuilder sb = new StringBuilder();
			this.NumTokens = 0;
			this.tokens.Clear();
			this.CurrIndex = 0;
			
			int i = 0;

			while (i < this.StrSource.Length)
			{
				if (this.StrDelimiter.IndexOf(this.StrSource[i]) != -1)
				{
					if (sb.Length > 0)
					{
						this.tokens.Add(sb.ToString());

						sb.Remove(0, sb.Length);
					}
				}
				else
				{
					sb.Append(this.StrSource[i]);
				}

				i++;
			}

			this.NumTokens = this.tokens.Count;
		}
		public int CountTokens()
		{
			return this.tokens.Count;
		}
		public bool HasMoreTokens()
		{
			if(this.CurrIndex <= (this.tokens.Count-1))
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		public string NextToken()
		{
			String RetString = "";
			if(this.CurrIndex <= (this.tokens.Count-1))
			{
				RetString = (string)tokens[CurrIndex];
				this.CurrIndex ++;
				return RetString;
			}
			else
			{
				return null;
			}
		}
		public void SkipToken()
		{
			if (this.CurrIndex <= (this.tokens.Count-1))
			{
				this.CurrIndex ++;
			}
		}
		public string PeekToken()
		{
			String RetString = "";
			if(this.CurrIndex <= (this.tokens.Count-1))
			{
				RetString = (string)tokens[CurrIndex];

				return RetString;
			}
			else
			{
				return null;
			}
		}
		#endregion
	}

	#endregion

	#region XTaskBarParser Class

	internal class XTaskBarParser
	{
		//
		private const int UNKNOWN = 0;
		private const int MAINSECTIONSS = 1;
		private const int MAINSECTIONTASKSS = 2;
		private const int SECTIONSS = 3;
		private const int SECTIONTASKSS = 4;
		private const int TASKPANE = 5;
		//
		private int style;

		//
		private const int BUTTON = 1;
		private const int DESTINATIONTASK = 2;
		private const int ACTIONTASK = 4;
		private const int TITLE = 8;
		private const int ARROW = 16;
		private const int WATERMARK = 32;
		private const int TASKLIST = 64;
		private const int SECTIONLIST = 128;
		private const int SELECTED = 256;
		private const int MOUSEFOCUSED = 512;
		private const int KEYFOCUSED = 1024;
		private const int EXPANDO = 2048;
		private const int BACKDROP = 4096;
		//
		private int section;
	
		private const int CONTENT = 1;
		private const int CONTENTALIGN = 2;
		private const int FONTFACE = 3;
		private const int FONTSIZE = 4;
		private const int FONTWEIGHT = 5;
		private const int FONTSTYLE = 6;
		private const int BACKGROUND = 7;
		private const int FOREGROUND = 8;
		private const int BORDERTHICKNESS = 9;
		private const int BORDERDOLOR = 10;
		private const int PADDING = 11;
		private const int MARGIN = 12;
		//
		private int property;

		//
		private XTaskBarSetting info;

		//
		private StringTokenizer tokenizer;


		/// <summary>
		/// Creates a new XTaskBarParser
		/// </summary>
		/// <param name="uifile">The text from the UIFILE that is to be parsed</param>
		/// <param name="stringTable">The text from the String Table that is to be parsed</param>
		public XTaskBarParser(string uifile)
		{
			// I'm lazy so get rid of a few strings
			uifile = uifile.Replace("rp", " ");
			uifile = uifile.Replace("rcstr", " ");
			uifile = uifile.Replace("rcint", " ");
			uifile = uifile.Replace("pt", " ");
			uifile = uifile.Replace("rect", " ");
		
			// create a new StringTokenizer with lots of delimiters
			this.tokenizer = new StringTokenizer(uifile, " \t\n\r\f<>=()[]{}:;,\\");

			this.style = UNKNOWN;
			this.section = UNKNOWN;
			this.property = UNKNOWN;
		}


		/// <summary>
		/// 
		/// </summary>
		public XTaskBarSetting Parse()
		{
			this.info = new XTaskBarSetting();

			string token = null;

			// keep going till we run out of tokens
			while (this.tokenizer.HasMoreTokens())
			{
				// get the next token
				token = this.tokenizer.NextToken();

                //<FOR_TEST>
                //XTaskBarUtil.WriteLog("Parse() in loop token=" + token);
			
				// is the token the start of a style section
				if (token.Equals("style"))
				{
					// work out which style section it is
					style = GetStyle(token);
				}
					// is the token the end of a style section
				else if (token.Equals("/style"))
				{
					// reset the style
					style = UNKNOWN;
				}
					// is the token the start of a property section in a known style
				else if (style != UNKNOWN && IsSection(token))
				{
					// work out which property section it is
					section = GetSection(token);
				}
					// is the token a property that belongs to a known property 
					// section and style
				else if (style != UNKNOWN && section != UNKNOWN && IsProperty(token))
				{
					// get the property
					property = GetPropertyType(token);
					ExtractProperty();
				}
			}

			return info;
		}


		/// <summary>
		/// Returns the style name for the current style token
		/// </summary>
		private int GetStyle(string s)
		{
			// check if the next token is the string "resid"
			if (!this.tokenizer.PeekToken().Equals("resid"))
			{
				// shouldn't get here, but if we do, return
				// an unknown style
				return UNKNOWN;
			}

			// skip past the "resid" token and get the next token
			this.tokenizer.SkipToken();
			string t = this.tokenizer.NextToken();

			// ckeck if it is one of the styles we're looking for.
			// if so, return which style it is
			switch (t)
			{
				case "mainsectionss":		return MAINSECTIONSS;

				case "mainsectiontaskss":	return MAINSECTIONTASKSS;

				case "sectionss":			return SECTIONSS;

				case "sectiontaskss":		return SECTIONTASKSS;

				case "taskpane":			return TASKPANE;
			}

			// not one of our styles, so return unknown
			return UNKNOWN;
		}


		/// <summary>
		/// Returns whether the token is a property section that we are interested in
		/// </summary>
		private bool IsSection(string s)
		{
			return (s.Equals("button") || s.Equals("destinationtask") || 
				s.Equals("actiontask") || s.Equals("title") || 
				s.Equals("arrow") || s.Equals("watermark") || 
				s.Equals("tasklist") || s.Equals("sectionlist") ||
				s.Equals("backdrop") || s.Equals("expando"));
		}


		/// <summary>
		/// Returns the name of the property section for the current token
		/// </summary>
		private int GetSection(string s)
		{
			switch (s)
			{
				case "button":			
					if (this.tokenizer.PeekToken().Equals("keyfocused"))
					{
						this.tokenizer.SkipToken();
						return BUTTON + KEYFOCUSED;
					}
					return BUTTON;

				case "destinationtask":	
					return DESTINATIONTASK;
				case "actiontask":		
					return ACTIONTASK;
				case "title":			
					if (this.tokenizer.PeekToken().Equals("mousefocused"))
					{
						this.tokenizer.SkipToken();
						return TITLE + MOUSEFOCUSED;
					}
					return TITLE;

				case "arrow":			
					if (this.tokenizer.PeekToken().Equals("selected"))
					{
						this.tokenizer.SkipToken();
						if (this.tokenizer.PeekToken().Equals("mousefocused"))
						{
							this.tokenizer.SkipToken();
							return ARROW + SELECTED + MOUSEFOCUSED;
						}
						return ARROW + SELECTED;
					}
					else if (this.tokenizer.PeekToken().Equals("mousefocused"))
					{
						this.tokenizer.SkipToken();
						return ARROW + MOUSEFOCUSED;
					}
					return ARROW;
				case "watermark":
					return WATERMARK;
				case "tasklist":		
					return TASKLIST;
				case "sectionlist":		
					return SECTIONLIST;
				case "expando":			
					return EXPANDO;
				case "backdrop":		
					return BACKDROP;
			}
			return UNKNOWN;
		}


		/// <summary>
		/// Returns whether the token is a property that we are interested in
		/// </summary>
		private bool IsProperty(string s)
		{
			return (s.Equals("content") || s.Equals("contentalign") || 
				s.Equals("fontface") || s.Equals("fontsize") || 
				s.Equals("fontweight") || s.Equals("fontstyle") || 
				s.Equals("background") || s.Equals("foreground") || 
				s.Equals("borderthickness") || s.Equals("bordercolor") || 
				s.Equals("padding") || s.Equals("margin") || s.Equals("cursor"));
		}


		/// <summary>
		/// Returns the property type for the current proprty token
		/// </summary>
		private int GetPropertyType(string s)
		{
			switch (s)
			{
				case "content":			return CONTENT;

				case "contentalign":	return CONTENTALIGN;

				case "fontface":		return FONTFACE;

				case "fontsize":		return FONTSIZE;

				case "fontweight":		return FONTWEIGHT;

				case "fontstyle":		return FONTSTYLE;

				case "background":		return BACKGROUND;

				case "foreground":		return FOREGROUND;

				case "borderthickness":	return BORDERTHICKNESS;

				case "bordercolor":		return BORDERDOLOR;

				case "padding":			return PADDING;

				case "margin":			return MARGIN;
			}

			return UNKNOWN;
		}


		/// <summary>
		/// Extracts a property from the current property token
		/// </summary>
		private void ExtractProperty()
		{
			switch (property)
			{
				case CONTENT:			ExtractContent();
					break;

				case CONTENTALIGN:		ExtractContentAlignment();
					break;

				case FONTFACE:			ExtractFontFace();
					break;

				case FONTSIZE:			ExtractFontSize();
					break;

				case FONTWEIGHT:		ExtractFontWeight();
					break;

				case FONTSTYLE:			ExtractFontStyle();
					break;

				case BACKGROUND:		ExtractBackground();
					break;

				case FOREGROUND:		ExtractForeground();
					break;

				case BORDERTHICKNESS:	ExtractBorder();
					break;

				case BORDERDOLOR:		ExtractBorderColor();
					break;

				case PADDING:			ExtractPadding();
					break;
								
				case MARGIN:			ExtractMargin();
					break;
			}
		}


		/// <summary>
		/// Extracts a Bitmap from a "content" property
		/// </summary>
		private void ExtractContent()
		{
			// peek at the next token
			string token = this.tokenizer.PeekToken();

			// check if is a bitmap
			if (token.Equals("rcbmp"))
			{
				// skip past the "rcbmp" token
				this.tokenizer.SkipToken();
			
				// extract the bitmap
				ExtractBitmap();
			}
		}


		/// <summary>
		/// Extracts a ContentAlignment from a "contentalign" property
		/// </summary>
		private void ExtractContentAlignment()
		{
			// get the next token
			string token = this.tokenizer.NextToken();
		
			// get the content alignment
			ContentAlignment c = GetContentAlignment(token);

			// should the content be wrapped
			bool wrap = (token.IndexOf("wrap") != -1);

			// store the property in the current section
			if (style == MAINSECTIONSS)
			{
				if (section == TITLE)
				{
					info.Header.SpecialAlignment = c;
				}
				else if (section == WATERMARK)
				{
					info.Expando.WatermarkAlignment = c;
				}
			}
			else if (style == MAINSECTIONTASKSS)
			{
				if (section == TITLE)
				{
					info.TaskLink.Wrap = wrap;
				}
			}
			else if (style == SECTIONSS)
			{
				if (section == TITLE)
				{
					info.Header.NormalAlignment = c;
				}
				else if (section == WATERMARK)
				{
					info.Expando.WatermarkAlignment = c;
				}
			}
			else if (style == SECTIONTASKSS)
			{
				if (section == TITLE)
				{
					info.TaskLink.Wrap = wrap;
				}
			}
			else if (style == TASKPANE)
			{
				if (section == BACKDROP)
				{
					info.TaskBar.WatermarkAlignment = c;
				}
			}
		}


		/// <summary>
		/// Returns the ContentAlignment value contained in the specified string
		/// </summary>
		private ContentAlignment GetContentAlignment(string s)
		{
			ContentAlignment c;

			// is it aligned with the top
			if (s.IndexOf("top") != -1)
			{
				if (s.IndexOf("left") != -1)
				{
					c = ContentAlignment.TopLeft;
				}
				else if (s.IndexOf("center") != -1)
				{
					c = ContentAlignment.TopCenter;
				}
				else if (s.IndexOf("right") != -1)
				{
					c = ContentAlignment.TopRight;
				}
					// assume it's left aligned
				else 
				{
					c = ContentAlignment.TopLeft;
				}
			}
				// is it aligned with the middle
			else if (s.IndexOf("middle") != -1)
			{
				if (s.IndexOf("left") != -1)
				{
					c = ContentAlignment.MiddleLeft;
				}
				else if (s.IndexOf("center") != -1)
				{
					c = ContentAlignment.MiddleCenter;
				}
				else if (s.IndexOf("right") != -1)
				{
					c = ContentAlignment.MiddleRight;
				}
					// assume it's left aligned
				else 
				{
					c = ContentAlignment.MiddleLeft;
				}
			}
				// is it aligned with the bottom
			else if (s.IndexOf("bottom") != -1)
			{
				if (s.IndexOf("left") != -1)
				{
					c = ContentAlignment.BottomLeft;
				}
				else if (s.IndexOf("center") != -1)
				{
					c = ContentAlignment.BottomCenter;
				}
				else if (s.IndexOf("right") != -1)
				{
					c = ContentAlignment.BottomRight;
				}
					// assume it's left aligned
				else 
				{
					c = ContentAlignment.BottomLeft;
				}
			}
				// ckeck for wrapping
			else 
			{
				// assume values are aligned with the middle
				if (s.Equals("wrapleft"))
				{
					c = ContentAlignment.MiddleLeft;
				}
				if (s.Equals("wrapcenter"))
				{
					c = ContentAlignment.MiddleRight;
				}
				if (s.Equals("wrapright"))
				{
					c = ContentAlignment.MiddleRight;
				}
					// assume middle left alignment
				else
				{
					c = ContentAlignment.MiddleLeft;
				}
			}

			return c;
		}


		/// <summary>
		/// Gets the FontFace property
		/// </summary>
		private void ExtractFontFace()
		{
			// get the fontsize value
			int id = Int32.Parse(this.tokenizer.NextToken());
			string fontName = XTaskBarUtil.GetResourceString(id);

			if (style == MAINSECTIONSS || style == SECTIONSS)
			{
				if (section == EXPANDO)
				{
					if (fontName != null && fontName.Length > 0)
					{
						info.Header.FontName = fontName;
					}
				}
			}
		}


		/// <summary>
		/// Gets the FontFace property
		/// </summary>
		private void ExtractFontSize()
		{
			// get the fontsize value
			int id = Int32.Parse(this.tokenizer.NextToken());
			string fontSize = XTaskBarUtil.GetResourceString(id);

			if (style == MAINSECTIONSS || style == SECTIONSS)
			{
				if (section == EXPANDO)
				{
					if (fontSize != null && fontSize.Length > 0)
					{
						info.Header.FontSize = Single.Parse(fontSize);
					}
				}
			}
		}


		/// <summary>
		/// Gets the FontWeight property
		/// </summary>
		private void ExtractFontWeight()
		{
			// set a default value incase something goes wrong
			int weight = 400;
			
			// get the fontweight value
			int id = Int32.Parse(this.tokenizer.NextToken());
			string fontWeight = XTaskBarUtil.GetResourceString(id);
			
			if (fontWeight != null && fontWeight.Length > 0)
			{
				weight = Int32.Parse(fontWeight);
			}

			FontStyle fontStyle;

			// is it bold
			if (weight == 700)
			{
				fontStyle = FontStyle.Bold;
			}
			else 
			{
				fontStyle = FontStyle.Regular;
			}

			// update the property
			if (style == MAINSECTIONSS)
			{
				if (section == BUTTON)
				{
					info.Header.FontWeight = fontStyle;
				}
			}
			else if (style == SECTIONSS)
			{
				if (section == BUTTON)
				{
					info.Header.FontWeight = fontStyle;
				}
			}
		}


		/// <summary>
		/// Gets the FontStyle property
		/// </summary>
		private void ExtractFontStyle()
		{
			// get the next token
			string token = this.tokenizer.NextToken();

			FontStyle fontStyle;

			// get the fontstyle
			if (token.Equals("underline"))
			{
				fontStyle = FontStyle.Underline;
			}
			else if (token.Equals("italic"))
			{
				fontStyle = FontStyle.Italic;
			}
			else if (token.Equals("strikeout"))
			{
				fontStyle = FontStyle.Strikeout;
			}
			else
			{
				fontStyle = FontStyle.Regular;
			}

			// update the property
			if (style == MAINSECTIONSS || style == SECTIONSS)
			{
				if (section == TITLE)
				{	
					info.Header.FontStyle = fontStyle;
				}
			}
			else if (style == MAINSECTIONTASKSS)
			{
				if (section - MOUSEFOCUSED == BUTTON)
				{
					info.TaskLink.FontDecoration = fontStyle;
				}
			}
			else if (style == SECTIONTASKSS)
			{
				if (section - MOUSEFOCUSED == BUTTON)
				{
					info.TaskLink.FontDecoration = fontStyle;
				}
			}
		}


		/// <summary>
		/// Gets the Background property
		/// </summary>
		private void ExtractBackground()
		{
			// take a look at the next token
			string token = this.tokenizer.PeekToken();

			// is it a bitmap
			if (token.Equals("rcbmp"))
			{
				this.tokenizer.SkipToken();
			
				ExtractBitmap();
			}
				// is it a gradient
			else if (token.Equals("gradient"))
			{
				this.tokenizer.SkipToken();
			
				// get the gradient colors and direction
				info.TaskBar.GradientStartColor = ExtractColor();
				info.TaskBar.GradientEndColor = ExtractColor();
				info.TaskBar.GradientDirection = (LinearGradientMode) Int32.Parse(tokenizer.NextToken());
			}
				// just a normal color
			else
			{
				Color c = ExtractColor();

				// debug
				/*if (section == WATERMARK || section == EXPANDO || section == TASKLIST)
				{
					int x = 0;
				}*/

				// if all components are 0, don't bother
				if (c.A == 0 && c.R == 0 && c.G == 0 && c.B == 0)
				{
					return;
				}

				// update the property
				if (style == MAINSECTIONSS)
				{
					if (section == WATERMARK || section == TASKLIST)
					{
						info.Expando.SpecialBackColor = c;
					}
					else if (section == EXPANDO)
					{
						info.Header.SpecialBackColor = c;
						info.Header.NormalBackColor = c;

						info.Expando.SpecialBackColor = c;
						info.Expando.NormalBackColor = c;
					}
				}
				else if (style == SECTIONSS)
				{
					if (section == TASKLIST)
					{
						info.Expando.NormalBackColor = c;
					}
					else if (section == EXPANDO)
					{
						info.Header.SpecialBackColor = c;
						info.Header.NormalBackColor = c;

						info.Expando.SpecialBackColor = c;
						info.Expando.NormalBackColor = c;
					}
				}
				else if (style == TASKPANE)
				{
					if (section == BACKDROP || section == SECTIONLIST)
					{
						info.TaskBar.GradientStartColor = c;
						info.TaskBar.GradientEndColor = c;
						info.TaskBar.GradientDirection = LinearGradientMode.Vertical;
					}
				}
			}
		}


		/// <summary>
		/// Extracts bitmap specified by the current token from
		/// the ShellStyle.dll
		/// </summary>
		private void ExtractBitmap()
		{
			// get the bitmap id
			string id = this.tokenizer.NextToken();
			
			// don't care about the next token
			this.tokenizer.SkipToken();

			// get the transparency value
			string transparent = this.tokenizer.NextToken();

			Bitmap image = null;

			// if the transparency value starts with a #, then the image is
			// a bitmap, otherwise it is a 32bit png
			if (transparent.StartsWith("#"))
			{
				// get the bitmap
				image = XTaskBarUtil.GetResourceBMP(id);

				// set the transparency color
				byte[] bytes = GetBytes(transparent);
				image.MakeTransparent(Color.FromArgb((int) bytes[0], (int) bytes[1], (int) bytes[2]));
			}
			else
			{
				// get the png
				image = XTaskBarUtil.GetResourcePNG(id);
			}

			// update the property
			if (style == MAINSECTIONSS)
			{
				if (section == BUTTON)
				{
					info.Header.SpecialBackImage = image;
				}
				else if (section == ARROW)
				{
					info.Header.SpecialArrowDown = image;
				}
				else if (section - SELECTED - MOUSEFOCUSED == ARROW)
				{
					info.Header.SpecialArrowUpHot = image;
				}
				else if (section - SELECTED == ARROW)
				{
					info.Header.SpecialArrowUp = image;
				}
				else if (section - MOUSEFOCUSED == ARROW)
				{
					info.Header.SpecialArrowDownHot = image;
				}
			}
			else if (style == SECTIONSS)
			{
				if (section == BUTTON)
				{
					info.Header.NormalBackImage = image;
				}
				else if (section == ARROW)
				{
					info.Header.NormalArrowDown = image;
				}
				else if (section - SELECTED - MOUSEFOCUSED == ARROW)
				{
					info.Header.NormalArrowUpHot = image;
				}
				else if (section - SELECTED == ARROW)
				{
					info.Header.NormalArrowUp = image;
				}
				else if (section - MOUSEFOCUSED == ARROW)
				{
					info.Header.NormalArrowDownHot = image;
				}
			}
			else if (style == TASKPANE)
			{
				if (section == SECTIONLIST)
				{
					info.TaskBar.BackImage = image;
				}
				else if (section == BACKDROP)
				{
					info.TaskBar.Watermark = image;
				}
			}
		}


		/// <summary>
		/// Gets the Foreground color property
		/// </summary>
		private void ExtractForeground()
		{
			// get the foreground color
			Color c = ExtractColor();

			// update the property
			if (style == MAINSECTIONSS)
			{
				if (section == BUTTON)
				{
					info.Header.SpecialTitleColor = c;
				}
				else if (section == TITLE)
				{
					info.Header.SpecialTitleColor = c;
				}
				else if (section - MOUSEFOCUSED == TITLE)
				{
					info.Header.SpecialTitleHotColor = c;
				}
				else if (section - KEYFOCUSED == TITLE)
				{
					info.Header.SpecialTitleHotColor = c;
				}
			}
			else if (style == MAINSECTIONTASKSS)
			{
				if (section == BUTTON)
				{
					info.TaskLink.LinkColor = c;
				}
				else if (section == TITLE)
				{
					info.TaskLink.LinkColor = c;
				}
				else if (section - MOUSEFOCUSED == TITLE)
				{
					info.TaskLink.HotLinkColor = c;
				}
			}
			else if (style == SECTIONSS)
			{
				if (section == BUTTON)
				{
					info.Header.NormalTitleColor = c;
				}
				else if (section == TITLE)
				{
					info.Header.NormalTitleColor = c;
				}
				else if (section - MOUSEFOCUSED == TITLE)
				{
					info.Header.NormalTitleHotColor = c;
				}
				else if (section - KEYFOCUSED == TITLE)
				{
					info.Header.NormalTitleHotColor = c;
				}
			}
			else if (style == SECTIONTASKSS)
			{
				if (section == BUTTON)
				{
					info.TaskLink.LinkColor = c;
				}
				else if (section == TITLE)
				{
					info.TaskLink.LinkColor = c;
				}
				else if (section - MOUSEFOCUSED == TITLE)
				{
					info.TaskLink.HotLinkColor = c;
				}
			}
		}


		/// <summary>
		/// Gets the Padding property
		/// </summary>
		private void ExtractPadding()
		{
			// get the padding value
			XTaskBarPadding p = new XTaskBarPadding();
			p.Left = Int32.Parse(this.tokenizer.NextToken());
			p.Top = Int32.Parse(this.tokenizer.NextToken());
			p.Right = Int32.Parse(this.tokenizer.NextToken());
			p.Bottom = Int32.Parse(this.tokenizer.NextToken());

			// update the property
			if (style == MAINSECTIONSS)
			{
				if (section == BUTTON)
				{
					info.Header.SpecialPadding = p;
				}
				else if (section == TASKLIST)
				{
					info.Expando.SpecialPadding = p;
				}
			}
			else if (style == MAINSECTIONTASKSS)
			{
				if (section == TITLE)
				{
					info.TaskLink.BarPadding = p;
				}
			}
			else if (style == SECTIONSS)
			{
				if (section == BUTTON)
				{
					info.Header.NormalPadding = p;
				}
				else if (section == TASKLIST)
				{
					info.Expando.NormalPadding = p;
				}
			}
			else if (style == SECTIONTASKSS)
			{
				if (section == TITLE)
				{
					info.TaskLink.BarPadding = p;
				}
			}
			else if (style == TASKPANE)
			{
				if (section == SECTIONLIST)
				{
					info.TaskBar.Padding = p;
				}
			}
		}


		/// <summary>
		/// Gets the Margin property
		/// </summary>
		private void ExtractMargin()
		{
			// get the margin property
			XTaskBarMargin m = new XTaskBarMargin();
			m.Left = Int32.Parse(this.tokenizer.NextToken());
			m.Top = Int32.Parse(this.tokenizer.NextToken());
			m.Bottom = Int32.Parse(this.tokenizer.NextToken());
			m.Right = Int32.Parse(this.tokenizer.NextToken());

			// update the property
			if (style == MAINSECTIONTASKSS)
			{
				if (section == DESTINATIONTASK)
				{
					info.TaskLink.BarMargin = m;
				}
				else if (section == ACTIONTASK)
				{
                    info.TaskLink.BarMargin = m;
				}
			}
			else if (style == SECTIONTASKSS)
			{
				if (section == DESTINATIONTASK)
				{
                    info.TaskLink.BarMargin = m;
				}
				else if (section == ACTIONTASK)
				{
                    info.TaskLink.BarMargin = m;
				}
			}
		}


		/// <summary>
		/// Gets the Border property
		/// </summary>
		private void ExtractBorder()
		{
			// gets the border property
			XTaskBarBorder b = new XTaskBarBorder();
			b.Left = Int32.Parse(this.tokenizer.NextToken());
			b.Top = Int32.Parse(this.tokenizer.NextToken());
			b.Right = Int32.Parse(this.tokenizer.NextToken());
			b.Bottom = Int32.Parse(this.tokenizer.NextToken());

			// update the property
			if (style == MAINSECTIONSS)
			{
				if (section == BUTTON)
				{
					info.Header.SpecialBorder = b;
				}
				else if (section == TASKLIST)
				{
					info.Expando.SpecialBorder = b;
				}
			}
			else if (style == SECTIONSS)
			{
				if (section == BUTTON)
				{
					info.Header.NormalBorder = b;
				}
				else if (section == TASKLIST)
				{
					info.Expando.NormalBorder = b;
				}
			}
			else if (style == TASKPANE)
			{
				if (section == SECTIONLIST)
				{
					info.TaskBar.Border = b;
				}
			}
		}


		/// <summary>
		/// Gets the Border color property
		/// </summary>
		private void ExtractBorderColor()
		{
			// get the border color
			Color c = ExtractColor();

			// update the property
			if (style == MAINSECTIONSS)
			{
				if (section == BUTTON)
				{
					info.Header.SpecialBorderColor = c;
				}
				else if (section == TASKLIST)
				{
					info.Expando.SpecialBorderColor = c;
				}
			}
			else if (style == SECTIONSS)
			{
				if (section == BUTTON)
				{
					info.Header.NormalBorderColor = c;
				}
				else if (section == TASKLIST)
				{
					info.Expando.NormalBorderColor = c;
				}
			}
			else if (style == TASKPANE)
			{
				if (section == SECTIONLIST)
				{
					info.TaskBar.BorderColor = c;
				}
			}
		}


		/// <summary>
		/// Extracts a color from the current token
		/// </summary>
		private Color ExtractColor()
		{
			// take a look at the next token
			string token = this.tokenizer.PeekToken();

			Color c = Color.Transparent;

			// is it a rgb
			if (token.Equals("rgb"))
			{
				c = ExtractRGBColor();
			}
				// or an argb
			else if (token.Equals("argb"))
			{
				c = ExtractARGBColor();
			}
				// or a hex color
			else if (token.StartsWith("#"))
			{
				c = ExtractHexColor(token);
			}
				// it must be a color name
			else
			{
				c = Color.FromName(token);
			}

			return c;
		}


		/// <summary>
		/// Extracts a RGB color from the current token
		/// </summary>
		private Color ExtractRGBColor()
		{
			// if the next token is "rgb" then skip it
			if (this.tokenizer.PeekToken().Equals("rgb"))
			{
				tokenizer.SkipToken();
			}
			
			// extract and return the color
			return Color.FromArgb(Int32.Parse(this.tokenizer.NextToken()),			// Red
				Int32.Parse(this.tokenizer.NextToken()),		// Green
				Int32.Parse(this.tokenizer.NextToken()));		// Blue
		}


		/// <summary>
		/// Extracts an ARGB color from the current token
		/// </summary>
		private Color ExtractARGBColor()
		{
			// if the next token is "argb" then skip it
			if (this.tokenizer.PeekToken().Equals("argb"))
			{
				tokenizer.SkipToken();
			}
			
			// extract the color
			Color c =  Color.FromArgb(Int32.Parse(this.tokenizer.NextToken()),	// Alpha
				Int32.Parse(this.tokenizer.NextToken()),		// Red
				Int32.Parse(this.tokenizer.NextToken()),		// Green
				Int32.Parse(this.tokenizer.NextToken()));		// Blue

			// if all components are 0, return the color
			if (c.A == 0 && c.R == 0 && c.G == 0 && c.B == 0)
			{
				return c;
			}

			// adjust transparency
			c = Color.FromArgb(255 - c.A, c.R, c.G, c.B);

			return c;
		}


		/// <summary>
		/// Extracts a color from a hexadecimal string
		/// </summary>
		private Color ExtractHexColor(string s)
		{
			byte[] bytes = GetBytes(s.Substring(1));

			return Color.FromArgb((int) bytes[0], (int) bytes[1], (int) bytes[2]);
		}


		/// <summary>
		/// 
		/// </summary>
		public byte[] GetBytes(string hexString)
		{
			//discarded = 0;
			StringBuilder sb = new StringBuilder();
			char c;

			// remove all none A-F, 0-9, characters
			for (int i=0; i<hexString.Length; i++)
			{
				c = hexString[i];

				if (IsHexDigit(c))
				{
					sb.Append(c);
				}
			}
	
			// if odd number of characters, discard last character
			if (sb.Length % 2 != 0)
			{
				sb.Remove(sb.Length-1, 1);
			}

			int byteLength = sb.Length / 2;
			byte[] bytes = new byte[byteLength];
			string hex;
			int j = 0;
			for (int i=0; i<bytes.Length; i++)
			{
				hex = new String(new Char[] {sb[j], sb[j+1]});
				bytes[i] = HexToByte(hex);
				j = j+2;
			}

			return bytes;
		}


		/// <summary>
		/// 
		/// </summary>
		private bool IsHexDigit(Char c)
		{
			int numChar;
			int numA = Convert.ToInt32('A');
			int num1 = Convert.ToInt32('0');
			c = Char.ToUpper(c);
			numChar = Convert.ToInt32(c);

			if (numChar >= numA && numChar < (numA + 6))
			{
				return true;
			}

			if (numChar >= num1 && numChar < (num1 + 10))
			{
				return true;
			}

			return false;
		}


		/// <summary>
		/// 
		/// </summary>
		private byte HexToByte(string hex)
		{
			if (hex.Length > 2 || hex.Length <= 0)
			{
				throw new ArgumentException("hex must be 1 or 2 characters in length");
			}

			byte newByte = byte.Parse(hex, System.Globalization.NumberStyles.HexNumber);

			return newByte;
		}
	}

	#endregion
}
