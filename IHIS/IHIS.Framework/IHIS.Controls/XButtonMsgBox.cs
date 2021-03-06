using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Drawing.Drawing2D;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace IHIS.Framework
{
	#region XButtonMsgBoxForm
	/// <summary>
	/// XButtonMsgBoxForm에 대한 요약 설명입니다.
	/// </summary>
	internal class XButtonMsgBoxForm : System.Windows.Forms.Form
	{
		#region Fields
		const int cBottomMargin = 6;
		const int cBtnMinWidth = 60;
		const int cBtnMinHeight = 24;
		const int cBtnGap = 16; //버튼사이의 간격
		const int cCaptionLeft = 3;
		const int cCaptionTop = 2;
		const int cMsgLeft = 10;
		const int cCaptionRegion = 30;
		const int cFormMinWidth = 250;
		const int cFormMaxWidth = 800;
		const int cFormMinHeight = 100;
		const int cFormMaxHeight = 700;
		private Font BTN_FONT = new Font("MS UI Gothic", 9.75f);

		private int btnMaxHeight = 23;  //버튼중 최대높이값
		private int btnTotalWidth = 0;  //버튼의 너비와 간격을 고려한 총 길이
		private ArrayList buttonList = new ArrayList();
		private XButton firstButton = null;
		private string clickedValue = "";
		private System.ComponentModel.IContainer components = null;
		#endregion

		#region Property
		internal string ClickedValue
		{
			get { return clickedValue;}
		}

		#endregion

		public XButtonMsgBoxForm(string msg, string caption, XButtonMsgBoxItemCollection buttons)
		{
			//
			// Windows Form 디자이너 지원에 필요합니다.
			//
			InitializeComponent();

			Graphics bg = this.CreateGraphics();
			//지정한 버튼에 의한 버튼Size Calc
			this.CalcButtonsSize(bg, buttons);

			//FormSize Calc
			int width = 0;
			int height = 0;
			// 버튼도 지정되지 않고, msg도 없으면 최소 Size로 설정
			if ((msg == "") && (buttons.Count < 1))
			{
				width = cFormMinWidth;
				height = cFormMinHeight;
			}
			else
			{
				//메세지의 Size 계산
				SizeF msgSize = bg.MeasureString(msg, this.Font);
				int msgSizeWidth = (int) (msgSize.Width + 1.0f); // 소수점 이하 고려 + 1
				//메세지의 Width와 Button의 TotalWidth중 큰 값으로 비교
				msgSizeWidth = Math.Max(msgSizeWidth, this.btnTotalWidth);

				if (msgSizeWidth <= (cFormMinWidth - cMsgLeft*2))
					width = cFormMinWidth;
				else if (msgSizeWidth <= (cFormMaxWidth - cMsgLeft*2))
					width = msgSizeWidth + cMsgLeft*2;
				else // Size가 Max보다 크면 width는 Max로 설정
					width = cFormMaxWidth;
				//Width를 주어 Height 다시 계산
				msgSize = bg.MeasureString(msg, this.Font, width - cMsgLeft*2);

				//Caption영역 Height = 30, Button영역 Height = 버튼의 최대높이 + BottomMargin
				height = Math.Min(cFormMaxHeight, Math.Max(cFormMinHeight, (int) (msgSize.Height + 8.3f) + cCaptionRegion + cBottomMargin + this.btnMaxHeight));
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
				RectangleF msgRectF = new RectangleF(cMsgLeft,cCaptionRegion, (float) width - cMsgLeft*2, (float) (height - cBottomMargin - cCaptionRegion - this.btnMaxHeight));
				g.DrawString(msg, new Font("MS UI Gothic",9.75f), Brushes.MidnightBlue, msgRectF, format);
			}
			format.Dispose();
			bg.Dispose();
			this.BackgroundImage = bmp;
			this.ClientSize = bmp.Size;
			this.MaximumSize = bmp.Size;
			
			//Button Set
			SetButtons();
		}
		
		private void CalcButtonsSize(Graphics g, XButtonMsgBoxItemCollection buttons)
		{
			if (buttons.Count < 1) return;

			StringFormat format  = new StringFormat();
			format.HotkeyPrefix  = HotkeyPrefix.Show;
			format.Trimming = StringTrimming.EllipsisWord;
			SizeF textSize;
			PointF point = new PointF(0,0);
			int width = 0;
			int height = 0;
			ButtonSizeInfo btnInfo;
			foreach (XButtonMsgBoxItem item in buttons)
			{
				textSize = g.MeasureString(item.DisplayText, this.Font, point, format);
				width = Math.Max((int) textSize.Width + 10, cBtnMinWidth);
				height = Math.Max((int) (textSize.Height + 8.3f), cBtnMinHeight);  //TextSize에 여분고려 8.3f + 처리
				btnInfo = new ButtonSizeInfo(item, width, height);
				this.buttonList.Add(btnInfo);
				//버튼의 최대높이값 저장
				this.btnMaxHeight = Math.Max(this.btnMaxHeight, height);
				//버튼의 총길이 저장
				this.btnTotalWidth += width;
			}
			//버튼의 총 길이에 간격고려, 좌우 Margin 고려
			this.btnTotalWidth += (buttons.Count - 1) * cBtnGap + cMsgLeft*2;
		}
		private void SetButtons()
		{
			if (buttonList.Count < 1) return;
			IHIS.Framework.XButton btn;
			int fHeight = this.Height;
			int btnCount = buttonList.Count;
			int xPos = 0;
			int yPos = 0;
			int center = this.Width/2;
			ButtonSizeInfo info;
			int xLeftDiff = 0;
			int xRightDiff = 0;
			int leftBtnIdx = 0;
			int rightBtnIdx = 0;
			float leftBtnTotalWidth = 0.0f;
			float rightBtnTotalWidth = 0.0f;

			//버튼 1개
			if (buttonList.Count == 1)
			{
				info = (ButtonSizeInfo) buttonList[0];
				btn = new XButton();
				btn.Font = BTN_FONT;
				btn.Text	= info.ButtonItem.DisplayText;
				btn.Tag		= info.ButtonItem.ValueText; //Tag에 Value값 저장
				btn.Scheme	= info.ButtonItem.Scheme;
				btn.Size	= new Size(info.Width, info.Height);
				btn.Click	+=new EventHandler(Button_Click);
				yPos		= fHeight - cBottomMargin - info.Height;
				xPos		= center - info.Width/2;
				btn.Location = new Point(xPos,yPos);
				this.Controls.Add(btn);
				return;
			}
			else if (btnCount%2 != 0)
			{
				//좌측기준,우측기준 SET
				leftBtnIdx = btnCount/2 - 1;
				rightBtnIdx = btnCount/2 + 1;
				//좌우측 전체 버튼 너비 SET
				leftBtnTotalWidth += ((ButtonSizeInfo)buttonList[btnCount%2]).Width/2 + cBtnGap;
				rightBtnTotalWidth += ((ButtonSizeInfo)buttonList[btnCount%2]).Width/2 + cBtnGap;
			}
			else
			{
				//좌측기준,우측기준 SET
				leftBtnIdx = btnCount/2 - 1;
				rightBtnIdx = btnCount/2;
				leftBtnTotalWidth += cBtnGap/2;
				rightBtnTotalWidth += cBtnGap/2;
			}
			for (int i = leftBtnIdx ; i >= 0 ; i--)
			{
				leftBtnTotalWidth += (float) ((ButtonSizeInfo)buttonList[i]).Width;
				if (i != leftBtnIdx) //버튼 Gap +
					leftBtnTotalWidth += cBtnGap;
			}
			for (int i = rightBtnIdx ; i < btnCount ; i++)
			{
				rightBtnTotalWidth += (float) ((ButtonSizeInfo)buttonList[i]).Width;
				if (i != rightBtnIdx) //버튼 Gap +
					rightBtnTotalWidth += cBtnGap;
			}
			
			//Center위치조정(좌측의 전체너비,우측의 전체너비 고려)
			if ((leftBtnTotalWidth + rightBtnTotalWidth > 0.0f) && (leftBtnTotalWidth != rightBtnTotalWidth))
			{
				center = (int)( ((float)this.Width) * (leftBtnTotalWidth/(leftBtnTotalWidth + rightBtnTotalWidth))); 
			}

			//Half를 기준으로 좌측과 우측을 나누어 버튼 Add
			if (btnCount%2 != 0)  // 홀수개이면 가운데 버튼부터 Add
			{
				info = (ButtonSizeInfo) buttonList[btnCount/2];
				btn = new XButton();
				btn.Font = BTN_FONT;
				btn.Text	= info.ButtonItem.DisplayText;
				btn.Tag		= info.ButtonItem.ValueText; //Tag에 Value값 저장
				btn.Scheme	= info.ButtonItem.Scheme;
				btn.Size	= new Size(info.Width, info.Height);
				btn.Click	+=new EventHandler(Button_Click);
				yPos		= fHeight - cBottomMargin - info.Height;
				xPos		= center - info.Width/2;
				btn.Location = new Point(xPos,yPos);
				this.Controls.Add(btn);

				//좌측,우측 Diff 계산
				xLeftDiff = center - info.Width/2 - cBtnGap;
				xRightDiff = center + info.Width/2 + cBtnGap;

				
			}
			else
			{
				//좌측,우측 Diff 계산
				xLeftDiff = center - cBtnGap/2;
				xRightDiff = center + cBtnGap/2;
			}
			//좌측은 Center에 가까운 버튼부터 Add
			for (int i = leftBtnIdx ; i >= 0 ; i--)
			{
				info = (ButtonSizeInfo) buttonList[i];
				btn = new XButton();
				btn.Font = BTN_FONT;
				btn.Text	= info.ButtonItem.DisplayText;
				btn.Tag		= info.ButtonItem.ValueText; //Tag에 Value값 저장
				btn.Scheme	= info.ButtonItem.Scheme;
				btn.Size	= new Size(info.Width, info.Height);
				btn.Click	+=new EventHandler(Button_Click);
				yPos		= fHeight - cBottomMargin - info.Height;
				xPos		= xLeftDiff - info.Width;
				btn.Location = new Point(xPos,yPos);
				this.Controls.Add(btn);
				//XLeftDiff 누적
				xLeftDiff -= (info.Width + cBtnGap);
				//첫번째 버튼 저장
				if (i == 0)
					this.firstButton = btn;
			}
			//우측은 Center에 가까운 버튼부터 Add
			for (int i = rightBtnIdx ; i < btnCount ; i++)
			{
				info = (ButtonSizeInfo) buttonList[i];
				btn = new XButton();
				btn.Font = BTN_FONT;
				btn.Text	= info.ButtonItem.DisplayText;
				btn.Tag		= info.ButtonItem.ValueText; //Tag에 Value값 저장
				btn.Scheme	= info.ButtonItem.Scheme;
				btn.Size	= new Size(info.Width, info.Height);
				btn.Click	+=new EventHandler(Button_Click);
				yPos		= fHeight - cBottomMargin - info.Height;
				xPos		= xRightDiff;
				btn.Location = new Point(xPos,yPos);
				this.Controls.Add(btn);
				//xRightDiff 누적
				xRightDiff += (info.Width + cBtnGap);
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
			// XButtonMsgBoxForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
			this.ClientSize = new System.Drawing.Size(350, 170);
			this.ControlBox = false;
			this.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.KeyPreview = true;
			this.Name = "XButtonMsgBoxForm";
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

		#region OnActivated
		protected override void OnActivated(EventArgs e)
		{
			base.OnActivated (e);
			//첫번째 버튼에 Focus
			if (this.firstButton != null)
				this.firstButton.Focus();
		}

		#endregion

		#region Button_Click
		private void Button_Click(object sender, EventArgs e)
		{
			//버튼 선택시 선택된 버튼값을 설정후 Close
			this.clickedValue = ((Control) sender).Tag.ToString();

			this.Close();
		}
		#endregion
	}
	#endregion

	#region XButtonMsgBox
	/// <summary>
	/// XButtonMsgBox에 대한 요약 설명입니다.
	/// </summary>
	public class XButtonMsgBox
	{
		public static string Show(string msg, XButtonMsgBoxItemCollection buttons)
		{
			return Show(msg,"",buttons);
		}
		public static string Show(string msg, string caption, XButtonMsgBoxItemCollection buttons)
		{
            try
            {
                string result = "";
                XButtonMsgBoxForm dlg = new XButtonMsgBoxForm(msg, caption, buttons);
                //Owner Get
                IntPtr hwnd = Process.GetCurrentProcess().MainWindowHandle;
                dlg.ShowDialog(new WindowWrapper(hwnd));
                result = dlg.ClickedValue;
                dlg.Dispose();
                return result;
            }
            catch
            {
                return string.Empty;
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

	#region ButtonSizeInfo (버튼의 Text에 따른 Size정보 관리)
	internal class ButtonSizeInfo
	{
		private int width = 0;
		private int height = 0;
		private XButtonMsgBoxItem buttonItem = null;

		internal int Width
		{
			get { return width;}
		}
		internal int Height
		{
			get { return height;}
		}
		internal XButtonMsgBoxItem ButtonItem
		{
			get { return buttonItem;}
		}
		internal ButtonSizeInfo(XButtonMsgBoxItem buttonItem, int width, int height)
		{
			this.buttonItem = buttonItem;
			this.width = width;
			this.height = height;
		}


	}
	#endregion

	#region XButtonMsgBoxItemCollection
	internal class XButtonMsgBoxItem
	{
		private string displayText = "";
		private string valueText = "";
		private XButtonSchemes scheme = XButtonSchemes.Blue;
		internal string DisplayText
		{
			get { return displayText;}
		}
		internal string ValueText
		{
			get { return valueText;}
		}
		internal XButtonSchemes Scheme
		{
			get { return scheme;}
		}
		internal XButtonMsgBoxItem(string displayText, string valueText, XButtonSchemes scheme)
		{
			this.displayText = displayText;
			this.valueText = valueText;
			this.scheme = scheme;
		}
	}
	/// <summary>
	/// XButtonMsgBoxItem 을 관리하는 컬렉션입니다.
	/// </summary>
	public class XButtonMsgBoxItemCollection : System.Collections.CollectionBase
	{
		/// <summary>
		/// 실제값과 보여줄값으로 XButtonMsgBoxItem을 만들어 컬렉션에 추가합니다.
		/// </summary>
		/// <param name="displayText"> 실제값 </param>
		/// <param name="valueText"> 보여줄값 </param>
		public void Add(string displayText, string valueText)
		{
			XButtonMsgBoxItem	bItem = new XButtonMsgBoxItem(displayText, valueText, XButtonSchemes.Blue);
			List.Add(bItem);
		}
		public void Add(string displayText, string valueText, XButtonSchemes scheme)
		{
			XButtonMsgBoxItem	bItem = new XButtonMsgBoxItem(displayText, valueText, scheme);
			List.Add(bItem);
		}
		/// <summary>
		/// 지정한 Index의 ComboItem을 삭제합니다.
		/// </summary>
		/// <param name="index"> 지정 Index </param>
		public void Remove(int index)
		{
			if ((index <= Count - 1) &&(index >= 0))
				List.RemoveAt(index); 
		}
	}
	#endregion
}
