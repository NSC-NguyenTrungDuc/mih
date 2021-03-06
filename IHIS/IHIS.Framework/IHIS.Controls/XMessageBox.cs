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
	#region XMessageBoxForm
	/// <summary>
	/// XMessageBoxForm에 대한 요약 설명입니다.
	/// </summary>
	internal class XMessageBoxForm : System.Windows.Forms.Form
	{
		const int BOTTOM_MARGIN = 6;
		const int BTN_WIDTH = 76;
		const int BTN_HEIGHT = 24;
		const int CAPTION_LEFT = 3;
		const int CAPTION_TOP = 2;
		const int MSG_LEFT = 10;
		const int CAPTION_REGION = 30;
		const int BTN_REGION = 40;
		const int MIN_WIDTH = 250;
		const int MAX_WIDTH = 800;
		const int MIN_HEIGHT = 100;
		const int MAX_HEIGHT = 700;
		const int ICON_SIZE = 42;
		private Font BTN_FONT = new Font("MS UI Gothic", 9.75f);

		private XButton btn1 = null;
		private XButton btn2 = null;
		private XButton btn3 = null;
		private int buttonCount = 0;
		private MessageBoxDefaultButton defaultButton = MessageBoxDefaultButton.Button1;
		private System.Windows.Forms.Timer timer1;
		private System.ComponentModel.IContainer components;

		public XMessageBoxForm(string msg, string caption, MessageBoxButtons buttons, MessageBoxDefaultButton defaultButton, MessageBoxIcon icon, int autoHideTime)
		{
			//
			// Windows Form 디자이너 지원에 필요합니다.
			//
			InitializeComponent();

            // MED-14286
            if (NetInfo.Language == LangMode.Jr)
            {
                this.BTN_FONT = new Font("MS UI Gothic", 9.75f);
            }
            else
            {
                this.BTN_FONT = Service.COMMON_FONT;
            }

			int width = 0;
			int height = 0;
			int iconWidth = (icon == MessageBoxIcon.None ? 0 : ICON_SIZE);  //MessageBoxIcon에 따라 Icon의 영역 설정
			if (msg == "")
			{
				width = MIN_WIDTH;
				height = MIN_HEIGHT;
			}
			else
			{
				Graphics bg = this.CreateGraphics();
				SizeF msgSize = bg.MeasureString(msg, this.Font);
				int msgSizeWidth = (int) (msgSize.Width + 1.0f); // 소수점 이하 고려 + 1
				if (msgSizeWidth <= (MIN_WIDTH - iconWidth - MSG_LEFT*2))
					width = MIN_WIDTH;
				else if (msgSizeWidth <= (MAX_WIDTH - iconWidth - MSG_LEFT*2))
					width = msgSizeWidth + iconWidth + MSG_LEFT*2;
				else // Size가 Max보다 크면 width는 Max로 설정
					width = MAX_WIDTH;
				//Width를 주어 Height 다시 계산
				msgSize = bg.MeasureString(msg, this.Font, width - iconWidth - MSG_LEFT*2);
				//Caption영역 Height = 40, Button영역 Height = 30
				height = Math.Min(MAX_HEIGHT, Math.Max(MIN_HEIGHT, (int) (msgSize.Height + 8.3f) + CAPTION_REGION + BTN_REGION));
				bg.Dispose();
			}

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
			if (caption != "")
			{
				RectangleF capRectF = new RectangleF(CAPTION_LEFT, CAPTION_TOP, width - CAPTION_LEFT, 23.0f);
				//g.DrawString(caption, new Font("MS UI Gothic",9.75f, FontStyle.Bold), Brushes.White, capRectF, format);

                // MED-14286
                if (NetInfo.Language == LangMode.Jr)
                {
                    g.DrawString(caption, new Font("MS UI Gothic", 9.75f, FontStyle.Bold), Brushes.White, capRectF, format);
                }
                else
                {
                    g.DrawString(caption, Service.COMMON_FONT_BOLD, Brushes.White, capRectF, format);
                }
			}

			//MsgIcon Draw
			if (icon != MessageBoxIcon.None)
			{
				Image msgIcon = GetMsgIcon(icon);
				g.DrawImage(msgIcon, 5, CAPTION_REGION);
			}

				
			//Msg Draw
			if (msg != "")
			{
				RectangleF msgRectF = new RectangleF(iconWidth + MSG_LEFT,CAPTION_REGION, (float) width - iconWidth - MSG_LEFT*2, (float) (height - BTN_REGION - CAPTION_REGION));
				// g.DrawString(msg, new Font("MS UI Gothic",9.75f), Brushes.MidnightBlue, msgRectF, format);

                // MED-14286
                if (NetInfo.Language == LangMode.Jr)
                {
                    g.DrawString(msg, new Font("MS UI Gothic", 9.75f), Brushes.MidnightBlue, msgRectF, format);
                }
                else
                {
                    g.DrawString(msg, Service.COMMON_FONT, Brushes.MidnightBlue, msgRectF, format);
                }
			}
			format.Dispose();
			this.BackgroundImage = bmp;
			this.ClientSize = bmp.Size;
			this.MaximumSize = bmp.Size;
				
			//최초 크기와 비교한 xRate 계산
			float xRate = (float)width /(float)350;
			//DefaultButton Set
			this.defaultButton = defaultButton;
			//Button Set
			SetButtons(buttons, xRate);

			//autoHideTime(초단위)
			if (autoHideTime > 0)
			{
				this.timer1.Interval = autoHideTime*1000;
				this.timer1.Enabled = true;
				this.timer1.Start();
			}
		}

		private Image GetMsgIcon(MessageBoxIcon icon)
		{
			Image msgIcon = null;
			if (icon == MessageBoxIcon.Error)
				msgIcon = DrawHelper.MsgIconError;
			else if (icon == MessageBoxIcon.Information)
				msgIcon = DrawHelper.MsgIconInformation;
			else if (icon == MessageBoxIcon.Stop)
				msgIcon = DrawHelper.MsgIconStop;
			else if (icon == MessageBoxIcon.Warning)
				msgIcon = DrawHelper.MsgIconWarning;
			else if (icon == MessageBoxIcon.Question)
				msgIcon = DrawHelper.MsgIconQuestion;
			else if (icon == MessageBoxIcon.Asterisk)
				msgIcon = DrawHelper.MsgIconAsterisk;
			else if (icon == MessageBoxIcon.Hand)
				msgIcon = DrawHelper.MsgIconHand;
			else if (icon == MessageBoxIcon.Exclamation)
				msgIcon = DrawHelper.MsgIconExclamation;

			return msgIcon;
		}

		private void SetButtons(MessageBoxButtons buttons, float xRate)
		{
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
			int yPos = fHeight - BOTTOM_MARGIN - BTN_HEIGHT;
			switch (buttonCount)
			{
				case 1:
					btn1.Size = new Size(BTN_WIDTH, BTN_HEIGHT);
					xPos = fWidth/2 - BTN_WIDTH/2; //가운데
					btn1.Location = new Point(xPos, yPos);
					this.Controls.Add(btn1);
					break;
				case 2:
					btn1.Size = new Size(BTN_WIDTH, BTN_HEIGHT);
					btn2.Size = new Size(BTN_WIDTH, BTN_HEIGHT);
					xPos = (int) (fWidth/2 - BTN_WIDTH*xRate/2 - BTN_WIDTH);
					btn1.Location = new Point(xPos, yPos);
					xPos = (int) (fWidth/2 + BTN_WIDTH*xRate/2);
					btn2.Location = new Point(xPos, yPos);
					this.Controls.Add(btn1);
					this.Controls.Add(btn2);
					//2006.02.09 기본 버튼에 따라 TabIndex 조정 (OnActivated에서 Focus가 제대로 먹지 않음)
					if (this.defaultButton == MessageBoxDefaultButton.Button2)
					{
						btn2.TabIndex = 0;
						btn1.TabIndex = 1;
					}
					break;
				case 3:
					btn1.Size = new Size(BTN_WIDTH, BTN_HEIGHT);
					btn2.Size = new Size(BTN_WIDTH, BTN_HEIGHT);
					btn3.Size = new Size(BTN_WIDTH, BTN_HEIGHT);
					int btnGap = 0;
					if (fWidth < 270)
						btnGap = (fWidth - BTN_WIDTH*3 - 8)/2;
					else
						btnGap = (int) (14.0f*xRate);
					xPos = fWidth/2 - BTN_WIDTH/2 - btnGap - BTN_WIDTH;
					btn1.Location = new Point(xPos, yPos);
					xPos = fWidth/2 - BTN_WIDTH/2;  //가운데
					btn2.Location = new Point(xPos, yPos);
					xPos = fWidth/2 + BTN_WIDTH/2 + btnGap;
					btn3.Location = new Point(xPos, yPos);
					this.Controls.Add(btn1);
					this.Controls.Add(btn2);
					this.Controls.Add(btn3);
					if (this.defaultButton == MessageBoxDefaultButton.Button2)
					{
						btn2.TabIndex = 0;
						btn3.TabIndex = 1;
						btn1.TabIndex = 2;
					}
					else if (this.defaultButton == MessageBoxDefaultButton.Button3)
					{
						btn3.TabIndex = 0;
						btn1.TabIndex = 1;
						btn2.TabIndex = 2;
					}
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
			this.components = new System.ComponentModel.Container();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			// 
			// timer1
			// 
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// XMessageBoxForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
			this.ClientSize = new System.Drawing.Size(350, 170);
			this.ControlBox = false;
			this.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.KeyPreview = true;
			this.Name = "XMessageBoxForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.TopMost = true;
            this.BackgroundImageLayout = ImageLayout.Stretch;

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
		
		#region Timer_Tick
		private void timer1_Tick(object sender, System.EventArgs e)
		{
			//Tick 발생시 Form Close
			this.Close();
		}
		#endregion


	}
	#endregion

	#region XMessageBox
	/// <summary>
	/// XMessageBox에 대한 요약 설명입니다.
	/// </summary>
	public class XMessageBox
	{
		public static DialogResult Show(string msg)
		{
			return Show(msg,"",MessageBoxButtons.OK, MessageBoxDefaultButton.Button1, MessageBoxIcon.None, 0);
		}
		public static DialogResult Show(string msg, int autoHideTime)
		{
			return Show(msg,"",MessageBoxButtons.OK,MessageBoxDefaultButton.Button1, MessageBoxIcon.None, autoHideTime);
		}
		public static DialogResult Show(string msg, string caption)
		{
			return Show(msg,caption,MessageBoxButtons.OK,MessageBoxDefaultButton.Button1, MessageBoxIcon.None, 0);
		}
		public static DialogResult Show(string msg, string caption, MessageBoxIcon icon)
		{
			return Show(msg,caption,MessageBoxButtons.OK,MessageBoxDefaultButton.Button1, icon, 0);
		}
		public static DialogResult Show(string msg, string caption, int autoHideTime)
		{
			return Show(msg,caption,MessageBoxButtons.OK,MessageBoxDefaultButton.Button1, MessageBoxIcon.None, autoHideTime);
		}
		public static DialogResult Show(string msg, string caption, MessageBoxButtons buttons)
		{
			return Show(msg,caption,buttons,MessageBoxDefaultButton.Button1, MessageBoxIcon.None, 0);
		}
		public static DialogResult Show(string msg, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
		{
			return Show(msg,caption,buttons,MessageBoxDefaultButton.Button1, icon, 0);	
		}
		public static DialogResult Show(string msg, string caption, MessageBoxButtons buttons, MessageBoxDefaultButton defaultButton)
		{
			return Show(msg,caption,buttons,defaultButton, 0);
		}
		public static DialogResult Show(string msg, string caption, MessageBoxButtons buttons, MessageBoxDefaultButton defaultButton, MessageBoxIcon icon)
		{
			return Show(msg,caption,buttons,defaultButton, icon, 0);
		}
		public static DialogResult Show(string msg, string caption, MessageBoxButtons buttons, int autoHideTime)
		{
			return Show(msg,caption,buttons,MessageBoxDefaultButton.Button1, MessageBoxIcon.None, autoHideTime);
		}
		public static DialogResult Show(string msg, string caption, MessageBoxButtons buttons, MessageBoxDefaultButton defaultButton, MessageBoxIcon icon, int autoHideTime)
		{
            try
            {
                XMessageBoxForm dlg = new XMessageBoxForm(msg, caption, buttons, defaultButton, icon, autoHideTime);
                //Owner Get
                IntPtr hwnd = Process.GetCurrentProcess().MainWindowHandle;
                DialogResult result = dlg.ShowDialog(new WindowWrapper(hwnd));
                dlg.Dispose();
                return result;
            }
            catch
            {
                return MessageBox.Show(msg, caption, buttons, icon, defaultButton);
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
