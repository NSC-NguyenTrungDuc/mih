using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace IHIS.Framework
{
	/// <summary>
	/// ColorHelper에 대한 요약설명입니다.
	/// </summary>
	public class ColorHelper
	{
		static Color backgroundColor = Color.Empty;
		static Color selectionColor = Color.Empty;
		static Color controlColor = Color.Empty;
		static Color pressedColor = Color.Empty;
		static Color checkedColor = Color.Empty;
		static Color borderColor = Color.Empty;
		static bool useCustomColor = false;
		
		// No need to construct this object
		private ColorHelper()
		{
		}
		/// <summary>
		/// 사용자정의 색 사용여부를 가져옵니다.
		/// </summary>
		static public bool UsingCustomColor
		{
			get { return useCustomColor;}
		}


		// Knowncolor names
		#region Knowncolor names
		/// <summary>
		/// KnownColor의 이름을 관리합니다.
		/// </summary>
		static public string[] KnownColorNames = 
		{
			"Transparent", "Black", "DimGray", "Gray", "DarkGray", "Silver", "LightGray", "Gainsboro", "WhiteSmoke", "White",
			"RosyBrown", "IndianRed", "Brown", "Firebrick", "LightCoral", "Maroon", "DarkRed", "Red", "Snow", "MistyRose",
			"Salmon", "Tomato", "DarkSalmon", "Coral", "OrangeRed", "LightSalmon", "Sienna", "SeaShell", "Chocalate",
			"SaddleBrown", "SandyBrown", "PeachPuff", "Peru", "Linen", "Bisque", "DarkOrange", "BurlyWood", "Tan", "AntiqueWhite",
			"NavajoWhite", "BlanchedAlmond", "PapayaWhip", "Mocassin", "Orange", "Wheat", "OldLace", "FloralWhite", "DarkGoldenrod",
			"Cornsilk", "Gold", "Khaki", "LemonChiffon", "PaleGoldenrod", "DarkKhaki", "Beige", "LightGoldenrod", "Olive",
			"Yellow", "LightYellow", "Ivory", "OliveDrab", "YellowGreen", "DarkOliveGreen", "GreenYellow", "Chartreuse", "LawnGreen",
			"DarkSeaGreen", "ForestGreen", "LimeGreen", "PaleGreen", "DarkGreen", "Green", "Lime", "Honeydew", "SeaGreen", "MediumSeaGreen",
			"SpringGreen", "MintCream", "MediumSpringGreen", "MediumAquaMarine", "YellowAquaMarine", "Turquoise", "LightSeaGreen",
			"MediumTurquoise", "DarkSlateGray", "PaleTurquoise", "Teal", "DarkCyan", "Aqua", "Cyan", "LightCyan", "Azure", "DarkTurquoise",
			"CadetBlue", "PowderBlue", "LightBlue", "DeepSkyBlue", "SkyBlue", "LightSkyBlue", "SteelBlue", "AliceBlue", "DodgerBlue",
			"SlateGray", "LightSlateGray", "LightSteelBlue", "CornflowerBlue", "RoyalBlue", "MidnightBlue", "Lavender", "Navy",
			"DarkBlue", "MediumBlue", "Blue", "GhostWhite", "SlateBlue", "DarkSlateBlue", "MediumSlateBlue", "MediumPurple",
			"BlueViolet", "Indigo", "DarkOrchid", "DarkViolet", "MediumOrchid", "Thistle", "Plum", "Violet", "Purple", "DarkMagenta",
			"Magenta", "Fuchsia", "Orchid", "MediumVioletRed", "DeepPink", "HotPink", "LavenderBlush", "PaleVioletRed", "Crimson",
			"Pink", "LightPink" };
		#endregion
		
		// Systemcolors names
		#region Systemcolors names
		/// <summary>
		/// SystemColor의 이름을 관리합니다.
		/// </summary>
		static public string[] SystemColorNames = 
		{
			"ActiveBorder", "ActiveCaption", "ActiveCaptionText", "AppWorkspace", "Control", "ControlDark", "ControlDarkDark",
			"ControlLight", "ControlLightLight", "ControlText", "Desktop", "GrayText", "HighLight", "HighLightText", 
			"HotTrack", "InactiveBorder", "InactiveCaption", "InactiveCaptionText", "Info", "InfoText", "Menu", "MenuText",
			"ScrollBar", "Window", "WindowFrame", "WindowText" };
		#endregion
		
		// Conversion between RGB and Hue, Saturation and Luminosity function helpers
		#region Conversion between RGB and HSL
		/// <summary>
		/// Hue, Saturation, Luminosity값을 RGB값으로 변환합니다.
		/// </summary>
		/// <param name="h"> Hue </param>
		/// <param name="s"> Saturation </param>
		/// <param name="l"> Luminosity </param>
		/// <param name="r"> (ref) Red </param>
		/// <param name="g"> (ref) Green </param>
		/// <param name="b"> (ref) Blue </param>
		static public void HSLToRGB(float h, float s, float l, ref float r, ref float g, ref float b)
		{
			// given h,s,l,[240 and r,g,b [0-255]
			// convert h [0-360], s,l,r,g,b [0-1]
			h=(h/240)*360;
			s /= 240;
			l /= 240;
			r /= 255;
			g /= 255;
			b /= 255;
					
			// Begin Foley
			float m1,m2;
			
			// Calc m2
			if (l<=0.5f) 
			{
				//m2=(l*(l+s)); seems to be typo in Foley??, replace l for 1
				m2=(l*(1+s));				
			} 
			else 
			{
				m2=(l+s-l*s);
			}
			
			//calc m1
			m1=2.0f*l-m2;
			
			//calc r,g,b in [0-1]
			if (s==0.0f) 
			{	// Achromatic: There is no hue
				// leave out the UNDEFINED part, h will always have value
				r=g=b=l;
			} 
			else 
			{	// Chromatic: There is a hue
				r= getRGBValue(m1,m2,h+120.0f);
				g= getRGBValue(m1,m2,h);
				b= getRGBValue(m1,m2,h-120.0f);
			}
						
			// End Foley
			// convert to 0-255 ranges
			r*=255;
			g*=255;
			b*=255;
            
		}
		static private float getRGBValue(float n1, float n2, float hue)
		{
			// Helper function for the HSLToRGB function above
			if (hue>360.0f) 
			{
				hue-=360.0f;
			} 
			else if (hue<0.0f) 
			{
				hue+=360.0f;
			}
		
			if (hue<60.0) 
			{
				return n1+(n2-n1)*hue/60.0f;
			} 
			else if (hue<180.0f) 
			{
				return n2;
			} 
			else if (hue<240.0f) 
			{
				return n1+(n2-n1)*(240.0f-hue)/60.0f;
			} 
			else 
			{
				return n1;
			}
		}

		/// <summary>
		/// RGB값을 Hue, Saturation, Luminosity값으로 변환합니다. 
		/// </summary>
		/// <param name="r"> Red </param>
		/// <param name="g"> Green </param>
		/// <param name="b"> Blue </param>
		/// <param name="h"> (ref) Hue </param>
		/// <param name="s"> (ref) Saturation </param>
		/// <param name="l"> (ref) Luminosity </param>
		static public void RGBToHSL(int r, int g, int b, ref float h, ref float s, ref float l)
		{

			//Computer Graphics - Foley p.595
			float delta;
			float fr = (float)r/255;
			float fg = (float)g/255;
			float fb = (float)b/255;
			float max = Math.Max(fr,Math.Max(fg,fb));
			float min = Math.Min(fr,Math.Min(fg,fb));
			
			//calc the lightness
			l = (max+min)/2;
			
			if (max==min)
			{
				//should be undefined but this works for what we need
				s = 0;
				h = 240.0f;		
			} 
			else 
			{
			
				delta = max-min;						
			
				//calc the Saturation
				if (l < 0.5) 
				{
					s = delta/(max+min);
				} 
				else 
				{
					s = delta/(2.0f-(max+min));
				}
				
				//calc the hue
				if (fr==max) 
				{
					h = (fg-fb)/delta;
				} 
				else if (fg==max) 
				{
					h = 2.0f + (fb-fr)/delta;
				} 
				else if (fb==max) 
				{
					h = 4.0f + (fr-fg)/delta;
				}
				
				//convert hue to degrees
				h*=60.0f;
				if (h<0.0f) 
				{
					h+=360.0f;
				}
			}
			//end foley

			//convert to 0-255 ranges
			//h [0-360], h,l [0-1]
			l*=240;
			s*=240;
			h=(h/360)*240;
            
		}
		#endregion

		// Visual Studio .NET colors calculation helpers
		#region Visual Studio .NET colors
		/// <summary>
		/// Visual Studio .NET에서의 배경색을 가져오거나 설정합니다.
		/// </summary>
		static public Color VSNetBackgroundColor
		{
			get 
			{
				if ( useCustomColor && backgroundColor != Color.Empty )
					return backgroundColor;
				else
					return CalculateColor(SystemColors.Window, SystemColors.Control, 220);
			}
			set
			{
				// Flag that we are going to use custom colors instead
				// of calculating the color based on the system colors
				// -- this is a way of hooking up into the VSNetColors that I use throughout
				// the UtilityLibrary
				useCustomColor = true;
				backgroundColor = value;
			}
		}
		/// <summary>
		/// Visual Studio .NET에서의 선택영역색을 가져오거나 설정합니다.
		/// </summary>
		static public Color VSNetSelectionColor
		{
			get 
			{
				if ( useCustomColor && selectionColor != Color.Empty )
					return selectionColor;
				else
					return CalculateColor(SystemColors.Highlight, SystemColors.Window, 70);
			}
			set
			{
				// Flag that we are going to use custom colors instead
				// of calculating the color based on the system colors
				// -- this is a way of hooking up into the VSNetColor that I use throughout
				// the UtilityLibrary
				useCustomColor = true;
				selectionColor = value;
			}
		}
		/// <summary>
		/// Visual Studio .NET에서의 컨트롤 색을 가져오거나 설정합니다.
		/// </summary>
		static public Color VSNetControlColor
		{
			get 
			{
				if ( useCustomColor && controlColor != Color.Empty )
					return controlColor;
				else
					return CalculateColor(SystemColors.Control, VSNetBackgroundColor, 195);
			}
			set
			{
				// Flag that we are going to use custom colors instead
				// of calculating the color based on the system colors
				// -- this is a way of hooking up into the VSNetColors that I use throughout
				// the UtilityLibrary
				useCustomColor = true;
				controlColor = value;
			}

		}
		/// <summary>
		/// Visual Studio .NET에서의 눌려진 색을 가져오거나 설정합니다.
		/// </summary>
		static public Color VSNetPressedColor
		{
			get 
			{
				if ( useCustomColor && pressedColor != Color.Empty )
					return pressedColor;
				else
					return CalculateColor(SystemColors.Highlight, ColorHelper.VSNetSelectionColor, 70);
			}
			set
			{
				// Flag that we are going to use custom colors instead
				// of calculating the color based on the system colors
				// -- this is a way of hooking up into the VSNetColors that I use throughout
				// the UtilityLibrary
				useCustomColor = true;
				pressedColor = value;
			}
		}
		/// <summary>
		/// Visual Studio .NET에서의 Checked 색을 가져오거나 설정합니다.
		/// </summary>
		static public Color VSNetCheckedColor
		{
			get 
			{
				if ( useCustomColor && pressedColor != Color.Empty )
					return checkedColor;
				else
					return CalculateColor(SystemColors.Highlight,  SystemColors.Window, 30);
			}
			set
			{
				// Flag that we are going to use custom colors instead
				// of calculating the color based on the system colors
				// -- this is a way of hooking up into the VSNetColors that I use throughout
				// the UtilityLibrary
				useCustomColor = true;
				checkedColor = value;
			}
		}
		/// <summary>
		/// Visual Studio .NET에서의 테두리 색을 가져오거나 설정합니다.
		/// </summary>
		static public Color VSNetBorderColor
		{
			get 
			{
				if ( useCustomColor && borderColor != Color.Empty )
					return borderColor;
				else
				{
					// This color is the default color unless we are using 
					// custom colors
					return SystemColors.Highlight;
				}
			}
			set
			{
				// Flag that we are going to use custom colors instead
				// of calculating the color based on the system colors
				// -- this is a way of hooking up into the VSNetColors that I use throughout
				// the UtilityLibrary
				useCustomColor = true;
				borderColor = value;
			}
		}

		private static Color CalculateColor(Color front, Color back, int alpha)
		{
			
			// Use alpha blending to brigthen the colors but don't use it
			// directly. Instead derive an opaque color that we can use.
			// -- if we use a color with alpha blending directly we won't be able 
			// to paint over whatever color was in the background and there
			// would be shadows of that color showing through
			Color frontColor = Color.FromArgb(255, front);
			Color backColor = Color.FromArgb(255, back);
									
			float frontRed = frontColor.R;
			float frontGreen = frontColor.G;
			float frontBlue = frontColor.B;
			float backRed = backColor.R;
			float backGreen = backColor.G;
			float backBlue = backColor.B;
			
			float fRed = frontRed*alpha/255 + backRed*((float)(255-alpha)/255);
			byte newRed = (byte)fRed;
			float fGreen = frontGreen*alpha/255 + backGreen*((float)(255-alpha)/255);
			byte newGreen = (byte)fGreen;
			float fBlue = frontBlue*alpha/255 + backBlue*((float)(255-alpha)/255);
			byte newBlue = (byte)fBlue;

			return  Color.FromArgb(255, newRed, newGreen, newBlue);

		}
		#endregion

		// General functions
		#region Helper Functions
		/// <summary>
		/// 특정 위치의 색을 가져옵니다.
		/// </summary>
		/// <param name="g"> Graphics 객체 </param>
		/// <param name="x"> X 위치 </param>
		/// <param name="y"> Y 위치 </param>
		/// <returns> 해당위치의 색 </returns>
		static public Color ColorFromPoint(Graphics g, int x, int y)
		{
			IntPtr hDC = g.GetHdc();
			// Get the color of the pixel first
			uint colorref = Gdi32.GetPixel(hDC, x, y);
			byte Red = GetRValue(colorref);
			byte Green = GetGValue(colorref);
			byte Blue = GetBValue(colorref);
			g.ReleaseHdc(hDC);
			return  Color.FromArgb(Red, Green, Blue);
		}
		/// <summary>
		/// 지정한 색이 KnownColor인지 여부를 가져옵니다.
		/// </summary>
		/// <param name="color"> 지정한 색 </param>
		/// <param name="knownColor"> (ref) KnowColor일때 지정색과 관련된 Color객체 </param>
		/// <param name="useTransparent"> Transparent사용여부 </param>
		/// <returns> KnownColor이면 true, 아니면 false </returns>
		static public bool IsKnownColor(Color color, ref Color knownColor, bool useTransparent)
		{

			// Using the Color structrure "FromKnowColor" does not work if 
			// we did not create the color as a known color to begin with
			// we need to compare the rgbs of both color 
			Color currentColor = Color.Empty;
			bool badColor = false;
			for (KnownColor enumValue = 0; enumValue <= KnownColor.YellowGreen; enumValue++)
			{
				currentColor = Color.FromKnownColor(enumValue);
				string colorName = currentColor.Name;
				if ( !useTransparent ) 
					badColor = (colorName == "Transparent");
				if ( color.A == currentColor.A && color.R == currentColor.R && color.G == currentColor.G 
					&& color.B == currentColor.B && !currentColor.IsSystemColor
					&& !badColor )
				{
					knownColor = currentColor;
					return true;
				}
				
			}
			return false;

		}
		/// <summary>
		/// 지정한 색이 SystemColor인지 여부를 가져옵니다.
		/// </summary>
		/// <param name="color"> 지정한 색 </param>
		/// <param name="knownColor"> (ref) SystemColor일때 지정색과 관련된 Color객체 </param>
		/// <returns> SystemColor이면 true, 아니면 false </returns>
		static public bool IsSystemColor(Color color, ref Color knownColor)
		{

			// Using the Color structrure "FromKnowColor" does not work if 
			// we did not create the color as a known color to begin with
			// we need to compare the rgbs of both color 
			Color currentColor = Color.Empty;
			for (KnownColor enumValue = 0; enumValue <= KnownColor.YellowGreen; enumValue++)
			{
				currentColor = Color.FromKnownColor(enumValue);
				string colorName = currentColor.Name;
				if ( color.R == currentColor.R && color.G == currentColor.G 
					&& color.B == currentColor.B && currentColor.IsSystemColor )
				{
					knownColor = currentColor;
					return true;
				}
				
			}
			return false;
		}
		/// <summary>
		/// 지정한 색의 RGB 환산값을 가져옵니다.
		/// </summary>
		/// <param name="color"> 지정색 </param>
		/// <returns> RGB 환산값 </returns>
		static public uint GetCOLORREF(Color color)
		{
			return RGB(color.R, color.G, color.B);
		}
		/// <summary>
		/// RGB를 표현하는 Text(R,G,B)로 색을 가져옵니다.
		/// </summary>
		/// <param name="text"> RGB표현 Text (R,G,B) </param>
		/// <returns> 색 </returns>
	
		static public Color ColorFromRGBString(string text)
		{
			
			Color rgbColor = Color.Empty;
			string[] RGBs = text.Split(','); 
			if ( RGBs.Length != 3 ) 
			{
				// If we don't have three pieces of information, then the
				// string is not properly formatted, inform the use
				throw new Exception("RGB color string is not well formed");
			}
		
			string stringR = RGBs[0];
			string stringG = RGBs[1];
			string stringB = RGBs[2];
			int R, G, B;
				
			try 
			{
				R = Convert.ToInt32(stringR);
				G = Convert.ToInt32(stringG);
				B = Convert.ToInt32(stringB);
				if ( ( R < 0 || R > 255 ) || ( G < 0 || G > 255 ) || ( B < 0 || B > 255 ) ) 
				{
					throw new Exception("Out of bounds RGB value");
				}
				else 
				{
					// Convert to color 
					rgbColor = Color.FromArgb(R, G, B);
					// See if we have either a web color or a systgem color
					Color knownColor = Color.Empty;
					bool isKnown = ColorHelper.IsKnownColor( rgbColor, ref knownColor, true);
					if ( !isKnown )
						isKnown = ColorHelper.IsSystemColor(rgbColor, ref knownColor);
					if ( isKnown )
						rgbColor = knownColor;
				}
			}
			catch ( InvalidCastException )
			{
				throw new Exception("Invalid RGB value");
			}

			return rgbColor;
		}
		#endregion
		
		// Windows RGB related macros
		#region Macros
		/// <summary>
		/// Color환산값중 Red Byte를 가져옵니다.
		/// </summary>
		/// <param name="color"> Color환산값 </param>
		/// <returns> Red를 표현하는 byte </returns>
		static public byte GetRValue(uint color)
		{
			return (byte)color;
		}
		/// <summary>
		/// Color환산값중 Green Byte를 가져옵니다.
		/// </summary>
		/// <param name="color"> Color환산값 </param>
		/// <returns> Green를 표현하는 byte </returns>
		static public byte GetGValue(uint color)
		{
			return ((byte)(((short)(color)) >> 8));
		}
		/// <summary>
		/// Color환산값중 Blue Byte를 가져옵니다.
		/// </summary>
		/// <param name="color"> Color환산값 </param>
		/// <returns> Blue를 표현하는 byte </returns>
		static public byte GetBValue(uint color)
		{
			return ((byte)((color)>>16));
		}
		/// <summary>
		/// RGB값으로 Color환산값을 가져옵니다.
		/// </summary>
		/// <param name="r"> Red </param>
		/// <param name="g"> Green </param>
		/// <param name="b"> Blue </param>
		/// <returns> Color 환산값 </returns>
		static public uint RGB(int r, int g, int b)
		{
			return ((uint)(((byte)(r)|((short)((byte)(g))<<8))|(((short)(byte)(b))<<16)));

		}
		#endregion
	}
}
