using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Drawing.Design;
using System.Reflection;
using Microsoft.Ink;

namespace IHIS.Framework
{
	/// <summary>
	/// XImageEditorPanel에 대한 요약 설명입니다.
	/// </summary>
	internal class XImageEditorPanel : System.Windows.Forms.Panel
	{
		public InkCollector InkCollector = null;		//Ink 
		public Ink InkPencil = null;
		public XImageEditorPanel()
		{
			this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor | ControlStyles.Selectable, true);
			this.UpdateStyles();
			InkPencil = new Ink();
		}
	}
}
