using System;
using System.Drawing;
using System.Windows.Forms;
using System.Text;
using System.Diagnostics;

namespace IHIS.Framework
{
	/// <summary>
	/// XStatusProgressBar에 대한 요약 설명입니다.
	/// </summary>
	internal class XStatusProgressBar
	{
		const int SB_GETRECT = (int)(Win32.Msgs.WM_USER + 10);
		const int cMargin = 2;
		private ProgressBar progressBar = null;
		private StatusBar	statusBar = null;
		private int panelNumber = 0;

		internal XStatusProgressBar(ProgressBar progressBar, StatusBar statusBar, int panelNumber)
		{
			this.progressBar = progressBar;
			this.statusBar = statusBar;
			this.panelNumber = panelNumber;
			this.progressBar.Parent = statusBar;

			//Size Calc
			Resize();
			//최초 Not Visible
			this.progressBar.Visible = false;
		}

		internal void Resize()
		{
			Win32.RECT rect = new Win32.RECT(Rectangle.Empty);
			User32.SendMessage(this.statusBar.Handle, SB_GETRECT, this.panelNumber, ref rect);
			this.progressBar.Left = rect.left + cMargin;
			this.progressBar.Top  = rect.top + cMargin;
			this.progressBar.Height = rect.bottom - rect.top - 2*cMargin;
			this.progressBar.Width = 200;  //Width 200 고정
		}
		internal void Start()
		{
			this.progressBar.Value = 0;
			this.progressBar.Visible = true;
		}
		internal void Progress(int progress)
		{
			this.progressBar.Value = Math.Min(Math.Max(0, progress), this.progressBar.Maximum);
		}
		internal void Stop()
		{
			this.progressBar.Visible = false;
		}
				
	}
}
