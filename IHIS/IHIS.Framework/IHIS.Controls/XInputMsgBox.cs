using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace IHIS.Framework
{
	#region XInputMsgBoxForm
	/// <summary>
	/// XInputMsgBoxForm에 대한 요약 설명입니다.
	/// </summary>
	internal class XInputMsgBoxForm : System.Windows.Forms.Form
	{
		#region Fields
		const int cBottomMargin = 6;
		const int cBtnWidth = 76;
		const int cBtnHeight = 24;
		const int cCaptionLeft = 3;
		const int cCaptionTop = 2;
		const int cTextBoxMargin = 5;
		const int cIconMargin = 5;
		const int cCaptionRegion = 35;
		const int cBtnRegion = 30;
		const int cFormMinWidth = 250;
		const int cFormMaxWidth = 800;
		const int cFormMinHeight = 110;
		const int cFormMaxHeight = 700;
		private XTextBox textBox = null;
		private Font BTN_FONT = new Font("MS UI Gothic", 9.75f);
		private int buttonCount = 0;

		private System.ComponentModel.IContainer components = null;
		#endregion
		
		#region Property
		internal string InputData
		{
			get { return textBox.Text;}
		}
		#endregion

		public XInputMsgBoxForm(string title, string inputData, bool isMultiLine, MessageBoxButtons buttons, Size msgBoxSize, Font textFont)
		{
			//
			// Windows Form 디자이너 지원에 필요합니다.
			//
			InitializeComponent();

			//FormSize Calc
			int width = 0;
			int height = 0;

			//지정한 Size에서 Max, Min 고려
			width = Math.Min(cFormMaxWidth, Math.Max(cFormMinWidth, msgBoxSize.Width));
			height = Math.Min(cFormMaxHeight, Math.Max(cFormMinHeight, msgBoxSize.Height));
			
			Bitmap bmp = new Bitmap(width,height);
			Graphics g = Graphics.FromImage(bmp);
			//전체 Fill, Draw
			g.FillRectangle(Brushes.AliceBlue, 0,0, width, height);
			g.DrawRectangle(Pens.Black, 0,0, width - 1, height -1);

			//Header Fill Rect
			Rectangle headerRect = new Rectangle(0,0, width - 1, 24);
			using (Brush hdr = new SolidBrush(SystemColors.Highlight))
				g.FillRectangle(hdr, headerRect);
			g.DrawRectangle(Pens.Black, headerRect);
			
			//Caption Draw
			StringFormat format = new StringFormat();
			format.Alignment = StringAlignment.Near;
			format.FormatFlags =StringFormatFlags.MeasureTrailingSpaces;
			format.Trimming = StringTrimming.EllipsisCharacter;
			format.LineAlignment = StringAlignment.Center;
			if (title != "")
			{
				RectangleF capRectF = new RectangleF(cCaptionLeft, cCaptionTop, width - cCaptionLeft, 23.0f);
				g.DrawString(title, new Font("MS UI Gothic",9.75f, FontStyle.Bold), Brushes.White, capRectF, format);
			}
			
			format.Dispose();
			this.BackgroundImage = bmp;
			this.ClientSize = bmp.Size;
			this.MaximumSize = bmp.Size;

			//Input TextBox Set
			this.textBox = new XTextBox();
			this.textBox.Font = textFont;
			//MultiInput 가능이면 MultiLine기능부여
			if (isMultiLine)
			{
				this.textBox.Multiline = true;
				this.textBox.AcceptsReturn = true;
				this.textBox.AcceptsTab = true;
				this.textBox.ScrollBars = ScrollBars.Vertical;
			}
			//Location, Size Set
			this.textBox.Location = new Point(cTextBoxMargin, cCaptionRegion);
			if (isMultiLine)
				this.textBox.Size = new Size(width - 2*cTextBoxMargin, height - cCaptionRegion - cBtnRegion - 5);
			else
				this.textBox.Size = new Size(width - 2*cTextBoxMargin, 23);

			//Text Set
			this.textBox.Text = inputData;
			//Controls Add
			this.Controls.Add(this.textBox);

			
			//최초 크기와 비교한 xRate 계산
			float xRate = (float)width /(float)350;
			//Button Set
			SetButtons(buttons, xRate);
		}

		private void SetButtons(MessageBoxButtons buttons, float xRate)
		{
			IHIS.Framework.XButton btn1 = null;
			IHIS.Framework.XButton btn2 = null;
			IHIS.Framework.XButton btn3 = null;
			switch (buttons)
			{
				case MessageBoxButtons.AbortRetryIgnore:
					btn1 = new XButton();
					btn1.Font = BTN_FONT;
					btn1.Text = XMsg.GetField("F006"); //중 단(&A)
					btn1.DialogResult = DialogResult.Abort;
					btn2 = new XButton();
					btn2.Font = BTN_FONT;
					btn2.Text = XMsg.GetField("F007"); //다시시도(&R)
					btn2.Scheme = XButtonSchemes.Silver;
					btn2.DialogResult = DialogResult.Retry;
					btn3 = new XButton();
					btn3.Font = BTN_FONT;
					btn3.Text = XMsg.GetField("F008"); //무 시(&I)
					btn3.Scheme = XButtonSchemes.OliveGreen;
					btn3.DialogResult = DialogResult.Ignore;
					buttonCount = 3;
					break;
				case MessageBoxButtons.OK:
					btn1 = new XButton();
					btn1.Font = BTN_FONT;
					btn1.Text = XMsg.GetField("F003"); //확 인
					btn1.DialogResult = DialogResult.OK;
					buttonCount = 1;
					this.AcceptButton = btn1;
					break;
				case MessageBoxButtons.OKCancel:
					btn1 = new XButton();
					btn1.Font = BTN_FONT;
					btn1.Text = XMsg.GetField("F003"); //확 인
					btn1.DialogResult = DialogResult.OK;
					btn2 = new XButton();
					btn2.Font = BTN_FONT;
					btn2.Text = XMsg.GetField("F001"); //취 소
					btn2.Scheme = XButtonSchemes.OliveGreen;
					btn2.DialogResult = DialogResult.Cancel;
					buttonCount = 2;
					this.AcceptButton = btn1;
					this.CancelButton = btn2;
					break;
				case MessageBoxButtons.RetryCancel:
					btn1 = new XButton();
					btn1.Font = BTN_FONT;
					btn1.Text = XMsg.GetField("F007"); //다시시도(&R)
					btn1.DialogResult = DialogResult.Retry;
					btn2 = new XButton();
					btn2.Font = BTN_FONT;
					btn2.Text = XMsg.GetField("F001"); //취 소
					btn2.Scheme = XButtonSchemes.OliveGreen;
					btn2.DialogResult = DialogResult.Cancel;
					buttonCount = 2;
					this.CancelButton = btn2;
					break;
				case MessageBoxButtons.YesNo:
					btn1 = new XButton();
					btn1.Font = BTN_FONT;
					btn1.Text = XMsg.GetField("F009"); //예(&Y)
					btn1.DialogResult = DialogResult.Yes;
					btn2 = new XButton();
					btn2.Font = BTN_FONT;
					btn2.Text = XMsg.GetField("F010"); //아니오(&N)
					btn2.Scheme = XButtonSchemes.OliveGreen;
					btn2.DialogResult = DialogResult.No;
					buttonCount = 2;
					break;
				case MessageBoxButtons.YesNoCancel:
					btn1 = new XButton();
					btn1.Font = BTN_FONT;
					btn1.Text = XMsg.GetField("F009"); //예(&Y)
					btn1.DialogResult = DialogResult.Yes;
					btn2 = new XButton();
					btn2.Font = BTN_FONT;
					btn2.Text = XMsg.GetField("F010"); //아니오(&N)
					btn2.Scheme = XButtonSchemes.Silver;
					btn2.DialogResult = DialogResult.No;
					btn3 = new XButton();
					btn3.Font = BTN_FONT;
					btn3.Text = XMsg.GetField("F001"); //취 소
					btn3.Scheme = XButtonSchemes.OliveGreen;
					btn3.DialogResult = DialogResult.Cancel;
					buttonCount = 3;
					this.CancelButton = btn3;
					break;
			}

			int fWidth = this.Width;
			int fHeight = this.Height;
			int xPos = 0; 
			int yPos = fHeight - cBottomMargin - cBtnHeight;
			switch (buttonCount)
			{
				case 1:
					btn1.Size = new Size(cBtnWidth, cBtnHeight);
					xPos = fWidth/2 - cBtnWidth/2; //가운데
					btn1.Location = new Point(xPos, yPos);
					this.Controls.Add(btn1);
					break;
				case 2:
					btn1.Size = new Size(cBtnWidth, cBtnHeight);
					btn2.Size = new Size(cBtnWidth, cBtnHeight);
					xPos = (int) (fWidth/2 - cBtnWidth*xRate/2 - cBtnWidth);
					btn1.Location = new Point(xPos, yPos);
					xPos = (int) (fWidth/2 + cBtnWidth*xRate/2);
					btn2.Location = new Point(xPos, yPos);
					this.Controls.Add(btn1);
					this.Controls.Add(btn2);
					break;
				case 3:
					btn1.Size = new Size(cBtnWidth, cBtnHeight);
					btn2.Size = new Size(cBtnWidth, cBtnHeight);
					btn3.Size = new Size(cBtnWidth, cBtnHeight);
					int btnGap = 0;
					if (fWidth < 270)
						btnGap = (fWidth - cBtnWidth*3 - 8)/2;
					else
						btnGap = (int) (14.0f*xRate);
					xPos = fWidth/2 - cBtnWidth/2 - btnGap - cBtnWidth;
					btn1.Location = new Point(xPos, yPos);
					xPos = fWidth/2 - cBtnWidth/2;  //가운데
					btn2.Location = new Point(xPos, yPos);
					xPos = fWidth/2 + cBtnWidth/2 + btnGap;
					btn3.Location = new Point(xPos, yPos);
					this.Controls.Add(btn1);
					this.Controls.Add(btn2);
					this.Controls.Add(btn3);
					break;
			}
		}

		/// <summary>
		/// 사용 중인 모든 리소스를 정리합니다.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form 디자이너에서 생성한 코드
		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다.
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
		/// </summary>
		private void InitializeComponent()
		{
			// 
			// XInputMsgBoxForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
			this.ClientSize = new System.Drawing.Size(350, 170);
			this.ControlBox = false;
			this.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.KeyPreview = true;
			this.Name = "XInputMsgBoxForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.TopMost = true;

		}
		#endregion

		#region WndProc
		protected override void WndProc(ref Message m)
		{
			//WM_NCHITTEST시에 Caption을 선택한 것처럼 Msg Hook
			if (m.Msg == (int) Win32.Msgs.WM_NCHITTEST)
				m.Result = new IntPtr(2); //Hit Caption
			else
				base.WndProc(ref m);
		}
		#endregion
		
		#region OnKeyDown
		protected override void OnKeyDown(KeyEventArgs e)
		{
			base.OnKeyDown (e);
			//Button이 1개일때 Escape Key 처리(닫기)
			if ((this.buttonCount == 1) && (e.KeyData == Keys.Escape))
				this.Close();
		}

		#endregion
	}
	#endregion

	#region XInputMsgBox
	/// <summary>
	/// XInputMsgBox에 대한 요약 설명입니다.
	/// </summary>
	public class XInputMsgBox
	{
		private static string inputData = "";
		private static Font defaultFont = new Font("MS UI Gothic",9.75f);
		private static Size defaultSize = new Size(250,110);
		public static string InputData
		{
			get { return inputData;}
		}
		public static DialogResult Show(string title)
		{
			return Show(title, "", false, MessageBoxButtons.OKCancel, defaultSize, defaultFont);
		}
		public static DialogResult Show(string title, Font textFont)
		{
			return Show(title, "", false, MessageBoxButtons.OKCancel, defaultSize, textFont);
		}
		public static DialogResult Show(string title, bool isMultiLine)
		{
			return Show(title, "", isMultiLine, MessageBoxButtons.OKCancel, defaultSize, defaultFont);
		}
		public static DialogResult Show(string title, bool isMultiLine, Font textFont)
		{
			return Show(title, "", isMultiLine, MessageBoxButtons.OKCancel, defaultSize, textFont);
		}
		public static DialogResult Show(string title, bool isMultiLine, Size msgBoxSize)
		{
			return Show(title, "", isMultiLine, MessageBoxButtons.OKCancel, msgBoxSize, defaultFont);
		}
		public static DialogResult Show(string title, bool isMultiLine, Size msgBoxSize, Font textFont)
		{
			return Show(title, "", isMultiLine, MessageBoxButtons.OKCancel, msgBoxSize, textFont);
		}
		public static DialogResult Show(string title, string inputData)
		{
			return Show(title, inputData, false, MessageBoxButtons.OKCancel, defaultSize, defaultFont);
		}
		public static DialogResult Show(string title, string inputData, Font textFont)
		{
			return Show(title, inputData, false, MessageBoxButtons.OKCancel, defaultSize, textFont);
		}
		public static DialogResult Show(string title, string inputData, bool isMultiLine)
		{
			return Show(title, inputData, isMultiLine, MessageBoxButtons.OKCancel, defaultSize, defaultFont);
		}
		public static DialogResult Show(string title, string inputData, bool isMultiLine, Font textFont)
		{
			return Show(title, inputData, isMultiLine, MessageBoxButtons.OKCancel, defaultSize, textFont);
		}
		public static DialogResult Show(string title, string inputData, bool isMultiLine, Size msgBoxSize)
		{
			return Show(title, inputData, isMultiLine, MessageBoxButtons.OKCancel, msgBoxSize, defaultFont);
		}
		public static DialogResult Show(string title, string inputData, bool isMultiLine, Size msgBoxSize, Font textFont)
		{
			return Show(title, inputData, isMultiLine, MessageBoxButtons.OKCancel, msgBoxSize, textFont);
		}
		public static DialogResult Show(string title, string inputData, bool isMultiLine, MessageBoxButtons buttons)
		{
			return Show(title, inputData, isMultiLine, buttons, defaultSize, defaultFont);
		}
		public static DialogResult Show(string title, string inputData, bool isMultiLine, MessageBoxButtons buttons, Font textFont)
		{
			return Show(title, inputData, isMultiLine, buttons, defaultSize, textFont);
		}
		public static DialogResult Show(string title, string inputData, bool isMultiLine, MessageBoxButtons buttons, Size msgBoxSize)
		{
			return Show(title, inputData, isMultiLine, buttons, defaultSize, defaultFont);
		}
		public static DialogResult Show(string title, string inputData, bool isMultiLine, MessageBoxButtons buttons, Size msgBoxSize, Font textFont)
		{
            try
            {
                XInputMsgBox.inputData = inputData;
                XInputMsgBoxForm dlg = new XInputMsgBoxForm(title, inputData, isMultiLine, buttons, msgBoxSize, textFont);
                //Owner Get
                IntPtr hwnd = Process.GetCurrentProcess().MainWindowHandle;
                DialogResult result = dlg.ShowDialog(new WindowWrapper(hwnd));
                XInputMsgBox.inputData = dlg.InputData;
                dlg.Dispose();
                return result;
            }
            catch
            {
                return DialogResult.None;
            }
		}
        //IWin32Window Wrapper class
        private class WindowWrapper : System.Windows.Forms.IWin32Window
        {
            private IntPtr hwnd;
            public IntPtr Handle
            {
                get { return hwnd; }
            }
            public WindowWrapper(IntPtr handle)
            {
                hwnd = handle;
            }
        }
	}
	#endregion
}
