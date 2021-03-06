using System;
using System.Collections;
using System.CodeDom;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Drawing.Design;
using System.Data;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Reflection;
using System.Globalization;

namespace IHIS.Framework
{
	/// <summary>
	/// XColor TypeConverter에 대한 요약설명입니다.
	/// </summary>
	public class XColorTypeConverter : System.ComponentModel.TypeConverter
	{
		private PropertyInfo[] webColorInfos = typeof(System.Drawing.Color).GetProperties();
		private PropertyInfo[] sysColorInfos = typeof(System.Drawing.SystemColors).GetProperties();

		/// <summary>
		/// 이 변환기가 한 형식의 개체를 이 변환기의 형식으로 변환할 수 있는지 여부를 반환합니다.
		/// </summary>
		/// <param name="context">  형식 컨텍스트를 제공하는 ITypeDescriptorContext  </param>
		/// <param name="sourceType"> 변환할 원본 형식을 나타내는 Type </param>
		/// <returns> 이 변환기가 변환을 수행할 수 있으면 true이고, 그렇지 않으면 false </returns>
		public override bool CanConvertFrom (ITypeDescriptorContext context, System.Type sourceType)
		{
			if (sourceType == typeof(string))
				return true;

			return base.CanConvertFrom(context, sourceType);
		}
		/// <summary>
		/// 지정된 컨텍스트 및 culture 정보를 사용하여, 지정된 개체를 이 변환기의 형식으로 변환합니다.
		/// </summary>
		/// <param name="context"> 형식 컨텍스트를 제공하는 ITypeDescriptorContext </param>
		/// <param name="culture"> 현재 culture로 사용할 CultureInfo </param>
		/// <param name="value"> 변환할 Object </param>
		/// <returns> 변환된 값을 나타내는 Object </returns>
		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
		{
			if (value is string)
			{
				PropertyInfo[] aColorInfos = 	typeof(XColor).GetProperties(BindingFlags.Static|BindingFlags.GetProperty|BindingFlags.Public);
				foreach (PropertyInfo info in aColorInfos)
				{
					if (info.PropertyType == typeof(XColor))
					{
						if (info.Name.Equals(value.ToString()))
						{
							return (XColor) info.GetValue(null,null);
						}
					}
				}
				// Edit창에서 직접 RGB 값을 입력시에는 입력값을 Check하여 RGB값으로 XColor Return
				Color rgbColor = Color.Empty;
				Color knownColor = Color.Empty;
				bool  isFind = false;
				string[] rgbs = value.ToString().Split(new char[]{','});
				try
				{
					rgbColor = Color.FromArgb(Int32.Parse(rgbs[0]), Int32.Parse(rgbs[1]), Int32.Parse(rgbs[2]));
					// rgbColor와 RGB값과 KnownColor의 RGB값을 비교 같으면 knownColor로 SET
					foreach (PropertyInfo info in this.webColorInfos)
					{
						if (info.PropertyType == typeof(Color))
						{
							knownColor = (Color) info.GetValue(null,null);
							// RGB값이 같으면 rgbColor를 knownColor로 SET
							if ((rgbColor.R == knownColor.R) && (rgbColor.G == knownColor.G) && (rgbColor.B == knownColor.B))
							{
								rgbColor = knownColor;
								break;
							}
						}
					}
					return new XColor(rgbColor);
				}
				catch
				{
					// WebColor, SystemColor Name 직접입력시 WebColor -> SystemColor순으로 검색
					string colorName = value.ToString();
					foreach (PropertyInfo info in this.webColorInfos)
					{
						if (info.PropertyType == typeof(Color))
						{
							knownColor = (Color) info.GetValue(null,null);
							if (knownColor.Name == colorName)
							{
								isFind = true;
								break;
							}
						}
					}
					if (!isFind)  //SystemColor 검색
					{
						foreach (PropertyInfo info in this.sysColorInfos)
						{
							if (info.PropertyType == typeof(Color))
							{
								knownColor = (Color) info.GetValue(null,null);
								if (knownColor.Name == colorName)
								{
									isFind = true;
									break;
								}
							}
						}
					}
					if (isFind)
						return new XColor(knownColor);
					else
						return base.ConvertFrom(context, culture, value);
				}
			}
			else 
				return base.ConvertFrom(context, culture, value);
		}
		/// <summary>
		/// 이 변환기가 개체를 지정된 형식으로 변환할 수 있는지 여부를 반환합니다.
		/// </summary>
		/// <param name="context"> 형식 컨텍스트를 제공하는 ITypeDescriptorContext </param>
		/// <param name="destinationType"> 변환할 대상 형식을 나타내는 Type </param>
		/// <returns> 이 변환기가 변환을 수행할 수 있으면 true이고, 그렇지 않으면 false </returns>
		public override bool CanConvertTo (ITypeDescriptorContext context, System.Type destinationType)
		{
			if (destinationType == typeof(InstanceDescriptor))
				return true;

			return base.CanConvertTo(context, destinationType);
		}
		/// <summary>
		/// 지정된 값 개체를 지정된 형식으로 변환합니다.
		/// </summary>
		/// <param name="context"> 형식 컨텍스트를 제공하는 ITypeDescriptorContext </param>
		/// <param name="culture"> CultureInfo 개체 </param>
		/// <param name="value"> 변환할 Object </param>
		/// <param name="destinationType"> value 매개 변수를 변환할 Type </param>
		/// <returns> 변환된 값을 나타내는 Object </returns>
		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType) 
		{  
			XColor aColor;
			
			if (destinationType == typeof(InstanceDescriptor))
			{
				if (value is XColor)
				{
					aColor = (XColor) value;
					InstanceDescriptor id;
					if (aColor.IsXColor)
						id = new InstanceDescriptor(aColor.GetType().GetProperty(aColor.ColorName), null);
					else
					{
						System.Type[] Types = new Type[]{typeof(Color)};
						object[] args = new Object[] {aColor.Color};
						id = new InstanceDescriptor(aColor.GetType().GetConstructor(Types), args); 
					}
					return id;
				}
			}
			return base.ConvertTo(context, culture, value, destinationType);
		}
	}
}
