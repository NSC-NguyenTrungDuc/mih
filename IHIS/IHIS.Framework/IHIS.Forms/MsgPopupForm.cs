using System;
using System.ComponentModel;
using System.Drawing;
using System.Net;
using System.Windows.Forms;

namespace IHIS.Framework
{
	/// <summary>
	/// MsgPopupForm에 대한 요약 설명입니다.
	/// </summary>
	internal class MsgPopupForm : System.Windows.Forms.Form
	{
		/// <summary>
		/// List of the different popup animation status
		/// </summary>
		private enum TaskbarState
		{
			Hidden = 0,
			Appearing = 1,
			Visible = 2,
			Disappearing = 3
		}
		
		#region Fields
		const int cIncrement = 4;
		const int cStayInterval = 10000;
		const int cMoveInterval = 10;
		private UdpMessage message = null;
		private string sendTime = "",senderIP = "", sendMsg = "";
		private Rectangle workAreaRect = Rectangle.Empty;
		private Rectangle textRect = new Rectangle(15,45,320,155);
		private Bitmap	closeBitmap = null;
		private Point	closeBitmapLocation = Point.Empty;
		private Size	closeBitmapSize = Size.Empty;
		private TaskbarState state = TaskbarState.Hidden;
		private StringFormat sFormat = new StringFormat();
//		private bool isMouseOver = false;
		private bool isMouseDown = false;
		private bool isMouseOverCloseButton = false;
		#endregion

		private System.Windows.Forms.Timer timer;
		private System.ComponentModel.IContainer components;

		public MsgPopupForm()
		{
			InitializeComponent();
			//언어모드에 따른 이미지 설정
			SetBackgroundImage();

			//Resource에서 닫기 이미지 GET
			SetCloseBitmap();
			//StringFormat Set
			sFormat.Alignment = StringAlignment.Near;
			sFormat.LineAlignment = StringAlignment.Near;
			sFormat.FormatFlags = StringFormatFlags.MeasureTrailingSpaces;
			sFormat.Trimming = StringTrimming.Word;
			this.Location = new Point(-1000,-1000);
			//최초 Hide,Show하여 위치조정
			base.Show();
			base.Hide();
			//Timer Enable
			timer.Enabled = true;
		}
		private void SetCloseBitmap()
		{
			System.Reflection.Assembly l_as = System.Reflection.Assembly.GetExecutingAssembly();
			closeBitmap = (Bitmap) Bitmap.FromStream(l_as.GetManifestResourceStream("IHIS.Framework.Images.Close.bmp"));
			closeBitmap.MakeTransparent();
			closeBitmapSize = new Size(closeBitmap.Width/3, closeBitmap.Height);
			closeBitmapLocation = new Point(320,10);

		}
		private void SetBackgroundImage()
		{
			//한국어,일본어 모드에 따라 배경 이미지 설정
			try
			{
                //string resName = (NetInfo.Language == LangMode.Ko ? "IHIS.Framework.Images.MessageKo.gif" : "IHIS.Framework.Images.MessageJr.gif");
                string resName = "";
                switch (NetInfo.Language)
                {
                    case LangMode.En:
                        resName = "IHIS.Images.MessageEn.gif";
                        break;
                    case LangMode.Jr:
                        resName = "IHIS.Images.MessageJr.gif";
                        break;
                    case LangMode.Ko:
                        resName = "IHIS.Images.MessageKo.gif";
                        break;
                    case LangMode.Vi:
                        resName = "IHIS.Images.MessageVi.gif";
                        break;
                    default:
                        resName = "IHIS.Images.MessageJr.gif";
                        break;
                }

				System.Reflection.Assembly l_as = System.Reflection.Assembly.GetExecutingAssembly();
				this.BackgroundImage = (Bitmap) Bitmap.FromStream(l_as.GetManifestResourceStream(resName));
			}
			catch{}
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

		#region Windows Form Designer generated code
		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다.
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(MsgPopupForm));
			this.timer = new System.Windows.Forms.Timer(this.components);
			// 
			// timer
			// 
			this.timer.Tick += new System.EventHandler(this.timer_Tick);
			// 
			// MsgPopupForm
			// 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.ClientSize = new System.Drawing.Size(350, 200);
			this.ControlBox = false;
			this.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "MsgPopupForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.TopMost = true;

		}
		#endregion

		#region Override
		protected override void OnMouseEnter(EventArgs e)
		{
			base.OnMouseEnter(e);
//			isMouseOver = true;
		}
		protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave(e);
//			isMouseOver = false;
			isMouseOverCloseButton = false;
			Refresh();
		}
		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);

			//Mouse가 CloseButton영역에 있으면 Cursor, MouseOver Set			
			if ( (e.X > closeBitmapLocation.X) && (e.X < closeBitmapLocation.X + closeBitmapSize.Width) && (e.Y > closeBitmapLocation.Y) && (e.Y < closeBitmapLocation.Y + closeBitmapSize.Height))
			{
				isMouseOverCloseButton = true;
				Cursor = Cursors.Hand;
				//MouseOver Image Draw
				Refresh();
			}
			else
			{
				bool redraw = isMouseOverCloseButton;
				isMouseOverCloseButton = false;
				if (redraw)
				{
					Cursor = Cursors.Default;
					Refresh();
				}
			}
		}
		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			//LeftButton Click시 Flag Set
			if (e.Button == MouseButtons.Left)
			{
				isMouseDown = true;
				//CloseButton영역에 있으면 누른상태 버튼 그리기
				if (this.isMouseOverCloseButton)
					Refresh();
			}
		}
		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			if (e.Button == MouseButtons.Left)
			{
				//Flag Clear
				isMouseDown = false;
			
				//CloseButton을 눌렀으면 Hide
				if (this.isMouseOverCloseButton)
					Hide();
			}
		}
		public new void Hide()
		{
			if (state != TaskbarState.Hidden)
			{
				timer.Stop();
				state = TaskbarState.Hidden;
				base.Hide();
			}
		}
		protected override void OnPaintBackground(PaintEventArgs pe)
		{
			Graphics g = pe.Graphics;
			g.PageUnit = GraphicsUnit.Pixel;
			
			Graphics screenGraphics;
			Bitmap screenBitmap;
			
			screenBitmap = new Bitmap(this.BackgroundImage.Width, BackgroundImage.Height);
			//Bitmap의 Graphics Get
			screenGraphics = Graphics.FromImage(screenBitmap);
			
			//배경이미지 Draw
			screenGraphics.DrawImage(this.BackgroundImage, 0, 0, BackgroundImage.Width, BackgroundImage.Height);	
			
			//Button, Text Draw
			DrawCloseButton(screenGraphics);
			DrawText(screenGraphics);
			//TransParent하지 않음
			//screenBitmap.MakeTransparent();
			g.DrawImage(screenBitmap, 0, 0);
			
			screenGraphics.Dispose();
			screenBitmap.Dispose();
			
		}
		#endregion

		#region Private Methods
		private void DrawCloseButton(Graphics g)
		{
			Rectangle rectDest = new Rectangle(closeBitmapLocation, closeBitmapSize);
			Rectangle rectSrc;
			
			//닫기 버튼 누름상태에 따라 Source 위치 변경
			if (this.isMouseOverCloseButton)
			{
				if (this.isMouseDown)
					rectSrc = new Rectangle(new Point(closeBitmapSize.Width*2, 0), closeBitmapSize);
				else
					rectSrc = new Rectangle(new Point(closeBitmapSize.Width, 0), closeBitmapSize);
			}		
			else
				rectSrc = new Rectangle(new Point(0, 0), closeBitmapSize);
				
			//Image Draw
			g.DrawImage(closeBitmap, rectDest, rectSrc, GraphicsUnit.Pixel);
		}

		private void DrawText(Graphics g)
		{
			if (this.sendMsg != string.Empty)
			{
				//DrawString
				g.DrawString(this.sendMsg, this.Font, Brushes.Black, this.textRect, this.sFormat); 
			}
		}
		#endregion

		#region ShowMessage
		// Mdi가 메시지를 수신하면 이 Method호출
		public void ShowMessage(IPEndPoint remoteEP, UdpMessage message)
		{
			workAreaRect = Screen.GetWorkingArea(workAreaRect);

			this.message = message;
			sendTime = DateTime.Now.ToString("yyyy/MM/dd hh:mm").Replace('-','/');
			senderIP = remoteEP.Address.ToString();
			sendMsg  = message.Message.TrimEnd('\n', ' ');
			

			switch (state)
			{
				case TaskbarState.Hidden:
					state = TaskbarState.Appearing;
					SetBounds(workAreaRect.Right- this.Width - 10, workAreaRect.Bottom -1, this.Width, 0);
					timer.Interval = cMoveInterval;
					timer.Start();
					// Focus 없이 Window Show
					User32.ShowWindow(this.Handle, 4);
					break;
				case TaskbarState.Appearing:
					Refresh();
					break;
				case TaskbarState.Visible:
					timer.Stop();
					Refresh();
					break;
			}
		}
		#endregion

		#region Timer
		private void timer_Tick(object sender, System.EventArgs e)
		{
			switch (state)
			{
				case TaskbarState.Appearing:
					if (this.Height < this.BackgroundImage.Height)
						SetBounds(Left, Top- cIncrement ,Width, Height + cIncrement);
					else
					{
						timer.Stop();
						Height = BackgroundImage.Height;
						state = TaskbarState.Visible;
						timer.Interval = cStayInterval;
						timer.Start();
					}
					break;
//				case TaskbarState.Visible:
//					timer.Stop();
//					timer.Interval = cMoveInterval;
//					state = TaskbarState.Disappearing;
//					timer.Start();
//					break;
//				case TaskbarState.Disappearing:
//					//MouseOver시 다시 Appearing
//					if (this.isMouseOver)
//						state = TaskbarState.Appearing;
//					else // 없으면 Hide
//					{
//						if (Top < this.workAreaRect.Bottom)
//							SetBounds(Left, Top + cIncrement, Width, Height - cIncrement);
//						else
//							Hide();
//					}
//					break;
			}
		}
		#endregion
	}
}
