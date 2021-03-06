using System;
using System.Drawing;
using System.Globalization;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Reflection;

namespace IHIS.Framework
{
	[Serializable,
	ToolboxItem(false),
	DesignTimeVisible(false)]
	public class XRotatorItem : System.ComponentModel.Component
	{
		#region Members
		private string headerText = "";
		private string bodyText = "";
		private bool   measuredBodyTextSize = false; //BodyText의 영역을 계산했는지 여부 (TextAnimation의 DrawText에서 Measure후 SET)
		private RectangleF textArea = RectangleF.Empty; //Text를 Drawing할 Area
		#endregion

		#region Properties

		[Category("모양"),
		DefaultValue(""),
		Description("Header의 Text를 지정합니다.")]
		public string HeaderText
		{
			get { return headerText; }
			set { headerText = value; }
		}

		[Category("모양"),
		DefaultValue(""),
		Description("Body의 Text를 지정합니다.")]
		public string BodyText
		{
			get { return bodyText; }
			set { bodyText = value; }
		}
		//<IHIS>
		[Browsable(false)]
		internal bool MeasuredBodyTextSize
		{
			get { return measuredBodyTextSize;}
			set { measuredBodyTextSize = value;}
		}
		[Browsable(false)]
		internal RectangleF TextArea
		{
			get { return textArea;}
			set { textArea = value;}
		}
		#endregion
	}
}
