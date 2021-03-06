using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Design;
using System.Diagnostics;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Xml;

namespace IHIS.Framework
{
	public class ColorStyle
	{
		#region Fields and Properties
		private string styleName = "";
		internal string StyleName
		{
			get { return styleName; }
		}

		private Color[] colorArray;
		internal Color[] ColorArray
		{
			get { return colorArray; }
		}    
		#endregion

		#region 생성자
		internal ColorStyle()
		{
			string[] uColorNames = Enum.GetNames(typeof(IHIS.Framework.XDefinedColor));
			colorArray = new Color[uColorNames.Length];
		}    
		#endregion

		#region Methods
		/// <summary>
		/// Color 항목을 설정한다.
		/// </summary>
		/// <param name="platformColorName"></param>
		/// <param name="colorName"></param>
		/// <returns></returns>
		private bool SetColorEntry(string platformColorName, string colorName)
		{
			XDefinedColor platformDefinedColor = (XDefinedColor)Enum.Parse(typeof(XDefinedColor), platformColorName);
			int index = (int)platformDefinedColor;
			if ((index >= colorArray.Length) || (index < 0))
				return false;
			try
			{
				colorArray[index] = (Color)TypeDescriptor.GetConverter(typeof(Color)).ConvertFromString(colorName);
			}
			catch
			{
				return false;
			}
			return true;
		}
		#endregion

		#region static Fields and Properties
		private static ArrayList colorStyles = new ArrayList();
		private static ColorStyle activeColorStyle = null;
		public static ColorStyle ActiveColorStyle
		{
			get { return activeColorStyle; }
		}
		#endregion

		#region static 생성자
		static ColorStyle()
		{
			XmlReader xmlReader = null;
			string fileName = Application.StartupPath + "\\ColorStyles.xml";
			if (File.Exists(fileName))
			{
				// 기본은 리소스에서 읽지 않고, 구성 파일을 관리.
				TextReader textReader = new StreamReader(fileName, Service.BaseEncoding);
				xmlReader = new XmlTextReader(textReader);
			}
			else
			{
				// Resource XML에서 ColorStyle을 Load한다.
				try
				{
					Assembly asm = Assembly.GetExecutingAssembly();
					xmlReader = new XmlTextReader(asm.GetManifestResourceStream("IHIS.Framework.ColorStyles.xml"));
				}
				catch
				{
					xmlReader = null;
				}
			}
			if (xmlReader != null)
			{
				System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
				doc.Load(xmlReader);
				FromXml(doc);
				xmlReader.Close();
			}
			//if (colorStyles.Count > 0)
			//    SetActiveColorStyle((ColorStyle)colorStyles[0]);
		}
		#endregion

		#region static Methods
		/// <summary>
		/// XML로부터 ColorStyle을 Load한다.
		/// </summary>
		/// <param name="doc"></param>
		private static void FromXml(XmlDocument doc, ArrayList colorStyleArray)
		{
			colorStyleArray.Clear();
			XmlNodeList styleElements = doc.DocumentElement.ChildNodes;
			foreach (XmlElement styleElement in styleElements)
			{
				try
				{
					ColorStyle colorStyle = new ColorStyle();
					colorStyle.styleName = styleElement.Attributes["Name"].InnerXml;
					foreach (XmlElement colorElement in styleElement.ChildNodes)
					{
						string platformColorName = colorElement.Attributes["Name"].InnerXml;
						string colorName = colorElement.Attributes["Color"].InnerXml;
						colorStyle.SetColorEntry(platformColorName, colorName);
					}
					// 미설정 Color는 Default Color로 Set한다.
					for (int i = 0; i < colorStyle.colorArray.Length; i++)
					{
						if (colorStyle.colorArray[i] == Color.Empty)
							colorStyle.colorArray[i] = XColor.DefaultColorArray[i];
					}
					colorStyleArray.Add(colorStyle);
				}
				catch (Exception e)
				{
					Debug.WriteLine(e.Message);
				}
			}
		}

		private static void FromXml(XmlDocument doc)
		{
			FromXml(doc, colorStyles);
		}

		/// <summary>
		/// Active ColorStyle을 설정한다.
		/// </summary>
		/// <param name="styleName"></param>
		/// <returns></returns>
		public static bool SetActiveColorStyle(string styleName)
		{
			return SetActiveColorStyle(GetColorStyle(styleName));
		}

		/// <summary>
		/// Active ColorStyle을 설정한다.
		/// </summary>
		/// <param name="styleName"></param>
		/// <returns></returns>
		private static bool SetActiveColorStyle(ColorStyle colorStyle)
		{
			if ((colorStyle != null) && (colorStyle != activeColorStyle))
			{
				activeColorStyle = colorStyle;
				XColor.ActiveColorArray = activeColorStyle.colorArray;
				return true;
			}
			return false;
		}
		/// <summary>
		/// ColorStyle명으로 ColorStyle을 가져온다.
		/// </summary>
		/// <param name="styleName"></param>
		/// <returns></returns>
		private static ColorStyle GetColorStyle(string styleName)
		{
			foreach (ColorStyle colorStyle in colorStyles)
			{
				if (colorStyle.StyleName == styleName)
					return colorStyle;
			}
			return null;
		}
		#endregion
	}
}
