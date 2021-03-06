using System;
using System.IO;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Drawing.Design;
using System.Windows.Forms;
using IHIS.Framework.Properties;
using IHIS.CloudConnector.Caching;
using IHIS.CloudConnector.Utility;

namespace IHIS.Framework
{
	/// <summary>
	/// MdiChild에 대한 요약 설명입니다.
	/// </summary>
	public class MdiChild : System.Windows.Forms.Form
	{
        //protected override void OnResize(EventArgs e)
        //{
        //    if (this.Width <= this.MinimumSize.Width)
        //    {
        //        this.Width = this.MinimumSize.Width;
        //    }
        //    //            base.OnResize(e);
        //}        

		#region Fields

		protected System.Drawing.Printing.PrintDocument printDocument1;
		private System.Windows.Forms.Panel pnlMain;
        private bool isEMRFirstLoad = false;
        private CustomLayout lstCustomLayout;
		const int MARGIN = 20;


		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion

		#region ActiveScreen
		internal XScreen ActiveScreen
		{
			get
			{
				foreach (Control cont in pnlMain.Controls)
					if (cont is XScreen)
						return cont as XScreen;

				return null;
			}
		}
		#endregion

		#region Constructors
		public MdiChild(Form mdiParent)
		{
			//
			// Windows Form 디자이너 지원에 필요합니다.
			//
			InitializeComponent();

			if (mdiParent != null)
			{
				this.MdiParent = mdiParent;
				this.Icon = MdiParent.Icon;
			}
			//위치 조정(열려있는 화면에 수를 계산하여 조금씩 이동
			int count = ScreenManager.OpenScreenList.Length;
			//this.Location = new Point(MARGIN*count, MARGIN*count);
			this.Location = new Point(0,0);

            // MED-14286
            if (NetInfo.Language != LangMode.Jr)
            {
                this.Font = Service.COMMON_FONT;
            }
		}

		public MdiChild()
			: this(null)
		{
		}
		#endregion

		#region Dispose
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
		#endregion

		#region Windows Form Designer generated code
		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다.
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MdiChild));
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // pnlMain
            // 
            this.pnlMain.AutoScroll = true;
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(822, 546);
            this.pnlMain.TabIndex = 1;
            // 
            // MdiChild
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(822, 546);
            this.Controls.Add(this.pnlMain);
            this.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MdiChild";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "새 창";
            this.SizeChanged += new System.EventHandler(this.MdiChild_SizeChanged);
            this.LocationChanged += new System.EventHandler(this.MdiChild_LocationChanged);
            this.ResumeLayout(false);

		}
		#endregion

		#region Override Invoker
		protected override void OnClosing(CancelEventArgs e)
		{
			//화면을 닫을 수 있는 조건이 아니면 Return
			//IAScreen을 CanClose() 할 수 없으면 창도 Close 불가
			try
			{
				XScreen screen = this.ActiveScreen;

				if (screen != null)
				{
					if (!screen.CanClose())
					{
						e.Cancel = true;
						return;
					}
				}
			}
			catch{}
			base.OnClosing (e);
		}
		protected override void OnActivated(EventArgs e)
		{
			base.OnActivated (e);
			
			//화면의 Activated Event 발생시킴
			if (this.ActiveScreen != null)
			{
				this.ActiveScreen.OnActivated(EventArgs.Empty);
			}
		}

		#endregion

		#region OpenNewScreen
		internal void OpenNewScreen(object obj, ScreenInfo screenInfo, MdiForm mdiForm)
		{
			if (obj == null) return;

			if (!(obj is XScreen))
			{
				string msg = XMsg.GetMsg("M009"); // 지원되는 유형의 화면이 아닙니다.
				XMessageBox.Show(msg, EnvironInfo.Product);
				return;
			}

			XScreen screen = (XScreen) obj;

			//2006.02.27 screenInfo는 OpenArg로 ScreenLoader에서 Screen 생성시에 설정함
			//screen.ScreenInfo = screenInfo;
			screen.ContainerMdiForm = mdiForm;
			screen.ContainerMdiChild = this;

			//title Set , Controls Add
			//2006.02.16 Form의 Text는 Title[ScreenID]로 하고 Tag에 Title을 저장하였다가 MdiForm::AddTabPage시에는 Title만 사용
			this.Text = screenInfo.Title + "[" + screenInfo.PgmID + "]";
			this.Tag = screenInfo.Title;

            //if (EnvironInfo.IsReal)
            //    this.Text = screenInfo.Title + "[" + screenInfo.PgmID + "]";
            //else
            //    this.Text = screenInfo.Title + "[" + screenInfo.PgmID + "]" + Resources.MdiForm_OnLoad_text;

			//Screen의 Size에 맞추어 Form Size 조정
			Size screenSize = ((Control) obj).Size;
			Size regionSize = this.pnlMain.Size;
			int dWidth = screenSize.Width - regionSize.Width;
			int dHeight = screenSize.Height - regionSize.Height;
			this.Size += new Size(dWidth, dHeight);

			//Dock Fill, Panel에 Add
			((Control) obj).Dock = DockStyle.Fill;
			pnlMain.Controls.Add((Control) obj);

            if (this.ActiveScreen != null)
            {
                if (this.ActiveScreen.Name != "OCS1003P01")
                {
                    this.MinimumSize = new Size(this.ActiveScreen.Width, this.ActiveScreen.Height);
                }

                //added by Cloud
                if (this.ActiveScreen.Name == "OCS2015U00")
                {
                    this.isEMRFirstLoad = true;
                    this.lstCustomLayout = CacheService.Instance.Get<CustomLayout>(Constants.CacheKeyLayout.CACHE_USERS_LAYOUT);
                }
            }
		}
		#endregion

		#region 화면인쇄
		/// <summary>
		/// 화면 인쇄
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			Image newImage = Image.FromFile(@"c:\temp\temp.bmp");
			RectangleF srcRect = new Rectangle(0, 0, newImage.Width, newImage.Height);
            //
            //PaperSize ps = new PaperSize();
            //ps.RawKind = (int)PaperKind.A4;
            //printDocument1.PrinterSettings.DefaultPageSettings.PaperSize.RawKind = (int)PaperKind.A4;
            //
            //printDocument1.PrinterSettings.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("PaperA4",840,1180);
            //
            //int nWidth = printDocument1.PrinterSettings.DefaultPageSettings.PaperSize.Width;
            //int nHeight = printDocument1.PrinterSettings.DefaultPageSettings.PaperSize.Height;

            printDocument1.DefaultPageSettings.Margins.Left = 0;
            printDocument1.DefaultPageSettings.Margins.Top = 0;
            printDocument1.DefaultPageSettings.Margins.Right = 0;
            printDocument1.DefaultPageSettings.Margins.Bottom = 0;

            int nWidth = (int)printDocument1.DefaultPageSettings.PrintableArea.Width;
            int nHeight = (int)printDocument1.DefaultPageSettings.PrintableArea.Height;
            //
            // LandScape
            //RectangleF destRect = new Rectangle(0, 0, newImage.Width, newImage.Height);
            RectangleF destRect = new Rectangle(0, 0, nHeight, nWidth );

            e.Graphics.DrawImage(newImage, destRect, srcRect, GraphicsUnit.Pixel);

            e.Graphics.Flush();
            //
		}

		/// <summary>
		/// 화면 인쇄
		/// </summary>
		public void PrintScreen()
		{
            try
            {
                // Capture Form
                Graphics g1 = this.CreateGraphics();
                //Graphics g1 = this.ActiveScreen.CreateGraphics();
                //
                Image CapImage = new Bitmap(this.Width, this.Height, g1);
                Graphics g2 = Graphics.FromImage(CapImage);
                IntPtr dc1 = g1.GetHdc();
                IntPtr dc2 = g2.GetHdc();
                Point pos = this.Parent.PointToScreen(Location);
                //
                Gdi32.BitBlt(dc2, 0, 0, Width, Height, dc1, Bounds.X - 3, Bounds.Y - 22, 13369376);
                g1.ReleaseHdc(dc1);
                g2.ReleaseHdc(dc2);
                //C:\Temp Dir 확인
                if (!Directory.Exists(@"C:\Temp"))
                    Directory.CreateDirectory(@"C:\Temp");
                CapImage.Save(@"c:\Temp\temp.bmp", System.Drawing.Imaging.ImageFormat.Bmp);

                //printDocument1.DefaultPageSettings.Landscape = true;
                //printDocument1.Print();

                PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();
                printPreviewDialog1.Document = this.printDocument1;
                //LandScape로 처리
                printPreviewDialog1.Document.DefaultPageSettings.Landscape = true;
                //
                printPreviewDialog1.Document.DefaultPageSettings.Margins.Left = 0;
                printPreviewDialog1.Document.DefaultPageSettings.Margins.Top = 0;
                printPreviewDialog1.Document.DefaultPageSettings.Margins.Right = 0;
                printPreviewDialog1.Document.DefaultPageSettings.Margins.Bottom = 0;
                //
                printPreviewDialog1.FormBorderStyle = FormBorderStyle.Fixed3D;
                printPreviewDialog1.SetBounds(10, 10, this.Width / 2, this.Height);
                printPreviewDialog1.ShowDialog();

                g1.Dispose();
                g2.Dispose();
            }
            catch (Exception e)
            {
                string msg = XMsg.GetMsg("M010") + "\nError[" + e.Message + "]"; //화면 인쇄시 오류가 발생하였습니다!\nError[" + e.Message + "]"
                XMessageBox.Show(msg, EnvironInfo.Product);
            }

		}
		#endregion

        //added by Cloud
        private void MdiChild_SizeChanged(object sender, EventArgs e)
        {
            if (isEMRFirstLoad && null != this.ActiveScreen && this.ActiveScreen.Name == "OCS2015U00")
            {
                if (null != this.lstCustomLayout && this.lstCustomLayout.ContainsUser(UserInfo.UserID, UserInfo.HospCode))
                {
                    this.Size = new Size(this.lstCustomLayout.GetMainWidth(UserInfo.UserID, UserInfo.HospCode), this.lstCustomLayout.GetMainHeight(UserInfo.UserID, UserInfo.HospCode));
                    this.Location = lstCustomLayout.GetMainLocation(UserInfo.UserID, UserInfo.HospCode);
                }
                isEMRFirstLoad = false;
            }
            else if (null != this.ActiveScreen && this.ActiveScreen.Name == "OCS2015U00")
            {
                if (null != this.lstCustomLayout && !this.lstCustomLayout.ContainsUser(UserInfo.UserID, UserInfo.HospCode))
                {
                    UserCustomLayout userCL = new UserCustomLayout();
                    userCL.HospCode = UserInfo.HospCode;
                    userCL.MainHeight = this.Height;
                    userCL.MainLocation = this.Location;
                    userCL.MainWidth = this.Width;
                    userCL.UserId = UserInfo.UserID;
                    lstCustomLayout.lstLayout.Add(userCL);
                    CacheService.Instance.Set(Constants.CacheKeyLayout.CACHE_USERS_LAYOUT, lstCustomLayout, TimeSpan.MaxValue);
                }
                else if (null != this.lstCustomLayout && this.lstCustomLayout.ContainsUser(UserInfo.UserID, UserInfo.HospCode))
                {
                    lstCustomLayout.SetMainHeight(UserInfo.UserID, UserInfo.HospCode, this.Height);
                    lstCustomLayout.SetMainLocation(UserInfo.UserID, UserInfo.HospCode, this.Location);
                    lstCustomLayout.SetMainWidth(UserInfo.UserID, UserInfo.HospCode, this.Width);
                    CacheService.Instance.Set(Constants.CacheKeyLayout.CACHE_USERS_LAYOUT, lstCustomLayout, TimeSpan.MaxValue);
                }
            }
        }

        private void MdiChild_LocationChanged(object sender, EventArgs e)
        {
            if (isEMRFirstLoad) return;
            if (null != this.ActiveScreen && this.ActiveScreen.Name == "OCS2015U00")
            {
                if (null != this.lstCustomLayout && !this.lstCustomLayout.ContainsUser(UserInfo.UserID, UserInfo.HospCode))
                {
                    UserCustomLayout userCL = new UserCustomLayout();
                    userCL.HospCode = UserInfo.HospCode;
                    userCL.MainHeight = this.Height;
                    userCL.MainLocation = this.Location;
                    userCL.MainWidth = this.Width;
                    userCL.UserId = UserInfo.UserID;
                    lstCustomLayout.lstLayout.Add(userCL);
                    CacheService.Instance.Set(Constants.CacheKeyLayout.CACHE_USERS_LAYOUT, lstCustomLayout, TimeSpan.MaxValue);
                }
                else if (null != this.lstCustomLayout && this.lstCustomLayout.ContainsUser(UserInfo.UserID, UserInfo.HospCode))
                {
                    lstCustomLayout.SetMainHeight(UserInfo.UserID, UserInfo.HospCode, this.Height);
                    lstCustomLayout.SetMainLocation(UserInfo.UserID, UserInfo.HospCode, this.Location);
                    lstCustomLayout.SetMainWidth(UserInfo.UserID, UserInfo.HospCode, this.Width);
                    CacheService.Instance.Set(Constants.CacheKeyLayout.CACHE_USERS_LAYOUT, lstCustomLayout, TimeSpan.MaxValue);
                }
            }
        }
	}
}
