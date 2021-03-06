using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Windows.Forms;

namespace IHIS.Framework
{
	#region XRotatorBaseControl
	/// <summary>
	/// Panel 확장 Double Buffering 사용 (XRotator Base Class)
	/// </summary>
	[ToolboxItem(false)]
	public class XRotatorBaseControl : Panel
	{
		#region Fields
		//Corner Margin
		protected int cornerSquare = 0;
		protected XColor borderColor = XColor.XRotatorBorderColor;
		//Graphics Path
		protected GraphicsPath graphicPath = null;
		protected GraphicsPath regionPath = null;
		#endregion

		#region Properties
		[Browsable(true)]
		[DefaultValue(typeof(XColor),"XRotatorBorderColor")]
		[Description("Border의 색을 지정합니다.")]
		public XColor BorderColor
		{
			get  { return borderColor;}
			set
			{
				this.borderColor = value;
				this.Refresh();
			}
		}
		#endregion

		#region 생성자
		public XRotatorBaseControl()
		{
			this.SetStyle(  ControlStyles.AllPaintingInWmPaint |ControlStyles.UserPaint | ControlStyles.DoubleBuffer,true);
			UpdateStyles();
		}
		#endregion

		#region Methods
		public override void Refresh()
		{
			if (graphicPath != null)
				InitializeGraphicPath();

			base.Refresh();
		}
		protected virtual void InitializeGraphicPath()
		{
			//<IHIS용> BUG 수정 (최소화 시킬때 Path 설정시 에러)
			if (cornerSquare <= 0) return;

			if (graphicPath != null)
			{
				graphicPath.Dispose();
				graphicPath = null;
			}

			if (regionPath != null)
			{
				regionPath.Dispose();
				regionPath = null;
			}

			graphicPath = new GraphicsPath();
			regionPath = new GraphicsPath();
            
			graphicPath.AddArc(0, 0, cornerSquare, cornerSquare, 180, 90);
			regionPath.AddArc(-1, -1, cornerSquare, cornerSquare, 180, 90);
			graphicPath.AddLine(cornerSquare - cornerSquare / 2, 0, Width - cornerSquare + cornerSquare / 2 - 1, 0);
			regionPath.AddLine(cornerSquare - cornerSquare / 2, -1, Width - cornerSquare + cornerSquare / 2, -1);
			graphicPath.AddArc(Width - cornerSquare - 1, 0, cornerSquare, cornerSquare, -90, 90);
			regionPath.AddArc(Width - cornerSquare, -1, cornerSquare, cornerSquare, -90, 90);

			graphicPath.AddLine(Width - 1, cornerSquare - cornerSquare / 2, Width - 1, Height - cornerSquare + cornerSquare / 2);
			regionPath.AddLine(Width, cornerSquare - cornerSquare / 2, Width, Height - cornerSquare + cornerSquare / 2);
			graphicPath.AddArc(Width - cornerSquare - 1, Height - 1 - cornerSquare, cornerSquare, cornerSquare, 0, 90);
			regionPath.AddArc(Width - cornerSquare, Height - cornerSquare, cornerSquare, cornerSquare, 0, 90);
			graphicPath.AddLine(cornerSquare - cornerSquare / 2, Height - 1, Width - cornerSquare + cornerSquare / 2, Height - 1);
			regionPath.AddLine(cornerSquare - cornerSquare / 2, Height, Width - cornerSquare + cornerSquare / 2, Height);

			graphicPath.AddArc(0, Height - cornerSquare - 1, cornerSquare, cornerSquare, 90, 90);
			regionPath.AddArc(-1, Height - cornerSquare, cornerSquare, cornerSquare, 90, 90);

			graphicPath.AddLine(0, cornerSquare - cornerSquare / 2, 0, Height - cornerSquare + cornerSquare / 2);
			regionPath.AddLine(-1, cornerSquare - cornerSquare / 2, -1, Height - cornerSquare + cornerSquare / 2);
		}
		#endregion

	}
	#endregion

	#region enums
	public enum XRotatorAnimationMode
	{
		None =0,
		Fading = 1,
		Typing = 2
	}
	public enum XRotatorAxisMode
	{
		XAxis = 0,
		YAxis =1
	}
	public enum XRotatorBrushType
	{
		Solid = 0,
		Gradient = 1
	}
	#endregion
}
