using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing.Imaging;
//
using IHIS.Framework;

namespace IHIS
{
	#region MsgBoxForm
	/// <summary>
	/// MsgBoxForm에 대한 요약 설명입니다.
	/// </summary>
	internal class MsgBoxForm : System.Windows.Forms.Form
	{
		const int cBottomMargin = 6;
		const int cBtnWidth = 76;
		const int cBtnHeight = 24;
		const int cCaptionLeft = 3;
		const int cCaptionTop = 2;
		const int cMsgLeft = 10;
		const int cCaptionRegion = 30;
		const int cBtnRegion = 40;
		const int cFormMinWidth = 250;
		const int cFormMaxWidth = 800;
		const int cFormMinHeight = 100;
		const int cFormMaxHeight = 700;

		private XPButton btn1 = null;
		private XPButton btn2 = null;
		private XPButton btn3 = null;
		private int buttonCount = 0;
		private MessageBoxDefaultButton defaultButton = MessageBoxDefaultButton.Button1;
		private System.ComponentModel.IContainer components = null;

		public MsgBoxForm(string msg, string caption, MessageBoxButtons buttons, MessageBoxDefaultButton defaultButton)
		{
			//
			// Windows Form 디자이너 지원에 필요합니다.
			//
			InitializeComponent();

			//FormSize Calc
			int width = 0;
			int height = 0;
			if (msg == "")
			{
				width = cFormMinWidth;
				height = cFormMinHeight;
			}
			else
			{
				Graphics bg = this.CreateGraphics();
				SizeF msgSize = bg.MeasureString(msg, this.Font);
				int msgSizeWidth = (int) (msgSize.Width + 1.0f); // 소수점 이하 고려 + 1
				if (msgSizeWidth <= (cFormMinWidth - cMsgLeft*2))
					width = cFormMinWidth;
				else if (msgSizeWidth <= (cFormMaxWidth - cMsgLeft*2))
					width = msgSizeWidth + cMsgLeft*2;
				else // Size가 Max보다 크면 width는 Max로 설정
					width = cFormMaxWidth;
				//Width를 주어 Height 다시 계산
				msgSize = bg.MeasureString(msg, this.Font, width - cMsgLeft*2);
				//Caption영역 Height = 40, Button영역 Height = 30
				height = Math.Min(cFormMaxHeight, Math.Max(cFormMinHeight, (int) (msgSize.Height + 8.3f) + cCaptionRegion + cBtnRegion));
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
				RectangleF capRectF = new RectangleF(cCaptionLeft, cCaptionTop, width - cCaptionLeft, 23.0f);
				g.DrawString(caption, new Font("MS UI Gothic",9.75f, FontStyle.Bold), Brushes.White, capRectF, format);
			}
			
			//Msg Draw
			if (msg != "")
			{
				RectangleF msgRectF = new RectangleF(cMsgLeft,cCaptionRegion, (float) width - cMsgLeft*2, (float) (height - cBtnRegion - cCaptionRegion));
				g.DrawString(msg, new Font("MS UI Gothic",9.75f), Brushes.MidnightBlue, msgRectF, format);
			}
			format.Dispose();
			this.BackgroundImage = bmp;
			this.ClientSize = bmp.Size;
			this.MaximumSize = bmp.Size;
			
			//최초 크기와 비교한 xRate 계산
			float xRate = (float)width /(float)350;
			//Button Set
			SetButtons(buttons, xRate);
			//DefaultButton Set
			this.defaultButton = defaultButton;
		}

		private void SetButtons(MessageBoxButtons buttons, float xRate)
		{
			//한글모드,일본어 모드로 나누어 SET
			switch (buttons)
			{
				case MessageBoxButtons.AbortRetryIgnore:
					btn1 = new XPButton();
					btn1.Text = XMsg.GetField("F003"); // 중 단(&A)
					btn1.DialogResult = DialogResult.Abort;
					btn2 = new XPButton();
					btn2.Text =  XMsg.GetField("F004"); // 다시시도(&R)" : "Retry(&R)");
					btn2.Scheme = Schemes.Silver;
					btn2.DialogResult = DialogResult.Retry;
					btn3 = new XPButton();
					btn3.Text =  XMsg.GetField("F005"); // 무 시(&I)" : "Ignore(&I)");
					btn3.Scheme = Schemes.OliveGreen;
					btn3.DialogResult = DialogResult.Ignore;
					buttonCount = 3;
					break;
				case MessageBoxButtons.OK:
					btn1 = new XPButton();
					btn1.Text =  XMsg.GetField("F001"); // 확 인" : "確 認");
					btn1.DialogResult = DialogResult.OK;
					buttonCount = 1;
					this.AcceptButton = btn1;
					break;
				case MessageBoxButtons.OKCancel:
					btn1 = new XPButton();
					btn1.Text =  XMsg.GetField("F001"); // 확 인" : "確 認");
					btn1.DialogResult = DialogResult.OK;
					btn2 = new XPButton();
					btn2.Text =  XMsg.GetField("F002"); // 취 소" : "取消し");
					btn2.Scheme = Schemes.OliveGreen;
					btn2.DialogResult = DialogResult.Cancel;
					buttonCount = 2;
					this.AcceptButton = btn1;
					this.CancelButton = btn2;
					break;
				case MessageBoxButtons.RetryCancel:
					btn1 = new XPButton();
					btn1.Text =  XMsg.GetField("F004"); // 다시시도(&R)" : "Retry(&R)");
					btn1.DialogResult = DialogResult.Retry;
					btn2 = new XPButton();
					btn2.Text =  XMsg.GetField("F002"); // 취 소" : "取消し");
					btn2.Scheme = Schemes.OliveGreen;
					btn2.DialogResult = DialogResult.Cancel;
					buttonCount = 2;
					this.CancelButton = btn2;
					break;
				case MessageBoxButtons.YesNo:
					btn1 = new XPButton();
					btn1.Text =  XMsg.GetField("F006"); // 예(&Y)" : "Yes(&Y)");
					btn1.DialogResult = DialogResult.Yes;
					btn2 = new XPButton();
					btn2.Text =  XMsg.GetField("F007"); // 아니오(&N)" : "No(&N)");
					btn2.Scheme = Schemes.OliveGreen;
					btn2.DialogResult = DialogResult.No;
					buttonCount = 2;
					break;
				case MessageBoxButtons.YesNoCancel:
					btn1 = new XPButton();
					btn1.Text =  XMsg.GetField("F006"); // 예(&Y)" : "Yes(&Y)");
					btn1.DialogResult = DialogResult.Yes;
					btn2 = new XPButton();
					btn2.Text =  XMsg.GetField("F007"); // 아니오(&N)" : "No(&N)");
					btn2.Scheme = Schemes.Silver;
					btn2.DialogResult = DialogResult.No;
					btn3 = new XPButton();
					btn3.Text =  XMsg.GetField("F002"); // 취 소" : "取消し");
					btn3.Scheme = Schemes.OliveGreen;
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
			// MsgBoxForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
			this.ClientSize = new System.Drawing.Size(350, 170);
			this.ControlBox = false;
			this.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.KeyPreview = true;
			this.Name = "MsgBoxForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.TopMost = true;
            this.BackgroundImageLayout = ImageLayout.Stretch;

		}
		#endregion

		#region WndProc
		protected override void WndProc(ref Message msg)
		{
			//WM_NCHITTEST시에 Caption을 선택한 것처럼 Msg Hook
			if (msg.Msg == (int) Msgs.WM_NCHITTEST)
				msg.Result = new IntPtr(2); //Hit Caption
			else
				base.WndProc(ref msg);
		}
		#endregion
		
		#region OnActivated
		protected override void OnActivated(EventArgs e)
		{
			base.OnActivated (e);
			//DefaultButton Set
			if ((this.buttonCount > 1) && (defaultButton == MessageBoxDefaultButton.Button2))
				btn2.Focus();
			else if ((this.buttonCount > 2) && (defaultButton == MessageBoxDefaultButton.Button3))
				btn3.Focus();

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

	#region XMessageBox
	/// <summary>
	/// XMessageBox에 대한 요약 설명입니다.
	/// </summary>
	public class XMessageBox
	{
		public static DialogResult Show(string msg)
		{
			return Show(msg,"",MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
		}
		public static DialogResult Show(string msg, string caption)
		{
			return Show(msg,caption,MessageBoxButtons.OK,MessageBoxDefaultButton.Button1);
		}
		public static DialogResult Show(string msg, string caption, MessageBoxButtons buttons)
		{
			return Show(msg,caption,buttons,MessageBoxDefaultButton.Button1);
		}
		public static DialogResult Show(string msg, string caption, MessageBoxButtons buttons, MessageBoxDefaultButton defaultButton)
		{
			MsgBoxForm dlg = new MsgBoxForm(msg, caption, buttons, defaultButton);
			DialogResult result = dlg.ShowDialog();
			dlg.Dispose();
			return result;
		}
	}
	#endregion
}
