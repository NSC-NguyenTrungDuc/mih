using System;
using System.IO;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Runtime.InteropServices;

namespace IHIS.Framework
{
	/// <summary>
	/// XRichTextEditor에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(true)]
	[ToolboxBitmap(typeof(IHIS.Framework.XRichTextEditor), "Images.XRichTextEditor.bmp")]
	public class XRichTextEditor : System.Windows.Forms.UserControl
	{
		#region API 관련
		[ StructLayout( LayoutKind.Sequential )]
		private struct RECT 
		{
			public int left;
			public int top;
			public int right;
			public int bottom;
		}
		[ StructLayout( LayoutKind.Sequential )]
		private struct CHARRANGE 
		{
			public int cpMin;
			public int cpMax;
		}
		[ StructLayout( LayoutKind.Sequential )]
		private struct FORMATRANGE 
		{
			public IntPtr hdc; 
			public IntPtr hdcTarget; 
			public RECT rc; 
			public RECT rcPage; 
			public CHARRANGE chrg; 
		}
		const int EM_FORMATRANGE = (int) Win32.Msgs.WM_USER + 57;
		#endregion

		#region Fields
		private Color selectedColor = Color.Black;
		private Font  selectedFont = new Font("굴림", 9.0f);
		private StreamReader excelReader = null;  //표삽입 Stream 객체
		private int firstChar = 0; // First character to be printed by RichTextBox
		#endregion

		#region Properties
		[Browsable(true), Category("추가속성"),DefaultValue(true),
		MergableProperty(true),
		Description("파일오픈메뉴 Enabled 여부를 지정합니다.")]
		public bool OpenEnabled
		{
			get { return this.tbOpen.Enabled;}
			set { this.tbOpen.Enabled = false;}
		}
		[Browsable(true), Category("추가속성"),DefaultValue(true),
		MergableProperty(true),
		Description("파일저장메뉴 Enabled 여부를 지정합니다.")]
		public bool SaveEnabled
		{
			get { return this.tbSave.Enabled;}
			set { this.tbSave.Enabled = false;}
		}
		#endregion

		private System.Windows.Forms.ToolBar toolBar;
		private System.Windows.Forms.ToolBarButton tbOpen;
		private System.Windows.Forms.ToolBarButton tbSave;
		private System.Windows.Forms.ImageList imgList;
		private System.Windows.Forms.ToolBarButton tbFont;
		private System.Windows.Forms.ToolBarButton tbSep1;
		private System.Windows.Forms.ToolBarButton tbBold;
		private System.Windows.Forms.ToolBarButton tbItalic;
		private System.Windows.Forms.ToolBarButton tbUnderline;
		private System.Windows.Forms.ToolBarButton tbStrikeout;
		private System.Windows.Forms.ToolBarButton tbSep2;
		private System.Windows.Forms.ToolBarButton tbLeft;
		private System.Windows.Forms.ToolBarButton tbCenter;
		private System.Windows.Forms.ToolBarButton tbRight;
		private System.Windows.Forms.ToolBarButton tbSep3;
		private System.Windows.Forms.ToolBarButton tbUndo;
		private System.Windows.Forms.ToolBarButton tbRedo;
		private System.Windows.Forms.ToolBarButton tbSep4;
		private System.Windows.Forms.ToolBarButton tbColor;
		private System.Windows.Forms.ToolBarButton tbImage;
		private System.Windows.Forms.RichTextBox txtEditor;
		private System.Windows.Forms.OpenFileDialog openDlg;
		private System.Windows.Forms.FontDialog fontDlg;
		private System.Windows.Forms.ColorDialog colorDlg;
		private System.Windows.Forms.OpenFileDialog imgDlg;
		private System.Windows.Forms.SaveFileDialog saveDlg;
		private System.Windows.Forms.ToolBarButton tbExcel;
		private System.Drawing.Printing.PrintDocument printDoc;
		private System.Windows.Forms.ToolBarButton tbPreview;
		private System.Windows.Forms.ToolBarButton tbPrint;
		private System.Windows.Forms.PrintPreviewDialog previewDlg;
		private System.Windows.Forms.PrintDialog printDlg;
		private System.Windows.Forms.ToolBarButton tbPageSetup;
		private System.Windows.Forms.PageSetupDialog pageSetDlg;
		private System.Windows.Forms.ToolBarButton tbSep5;
		private System.ComponentModel.IContainer components;

		#region 생성자
		//private ComboBox fontCombo = new ComboBox();
		public XRichTextEditor()
		{
			// 이 호출은 Windows.Forms Form 디자이너에 필요합니다.
			InitializeComponent();

			//Resource에 저장된 Excel.rtf 파일을 읽어서 excelReader Create
			System.Reflection.Assembly l_as = System.Reflection.Assembly.GetExecutingAssembly();
			this.excelReader = new StreamReader(l_as.GetManifestResourceStream("IHIS.Framework.XRichTextEditor.Excel.rtf"));


//			fontCombo.Size = new Size(100,21);
//			fontCombo.Location = new Point(10,10);
//			this.toolBar.Controls.Add(fontCombo);

			//일본어 ToolTip 설정
			SetControlTextByLangMode();

			// 최초 기본속성에 따라 Toolbar Update
			UpdateToolbar();



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

		#region 구성 요소 디자이너에서 생성한 코드
		/// <summary> 
		/// 디자이너 지원에 필요한 메서드입니다. 
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(XRichTextEditor));
			this.toolBar = new System.Windows.Forms.ToolBar();
			this.tbOpen = new System.Windows.Forms.ToolBarButton();
			this.tbSave = new System.Windows.Forms.ToolBarButton();
			this.tbSep1 = new System.Windows.Forms.ToolBarButton();
			this.tbPageSetup = new System.Windows.Forms.ToolBarButton();
			this.tbPreview = new System.Windows.Forms.ToolBarButton();
			this.tbPrint = new System.Windows.Forms.ToolBarButton();
			this.tbSep2 = new System.Windows.Forms.ToolBarButton();
			this.tbFont = new System.Windows.Forms.ToolBarButton();
			this.tbBold = new System.Windows.Forms.ToolBarButton();
			this.tbItalic = new System.Windows.Forms.ToolBarButton();
			this.tbUnderline = new System.Windows.Forms.ToolBarButton();
			this.tbStrikeout = new System.Windows.Forms.ToolBarButton();
			this.tbSep3 = new System.Windows.Forms.ToolBarButton();
			this.tbLeft = new System.Windows.Forms.ToolBarButton();
			this.tbCenter = new System.Windows.Forms.ToolBarButton();
			this.tbRight = new System.Windows.Forms.ToolBarButton();
			this.tbSep4 = new System.Windows.Forms.ToolBarButton();
			this.tbUndo = new System.Windows.Forms.ToolBarButton();
			this.tbRedo = new System.Windows.Forms.ToolBarButton();
			this.tbSep5 = new System.Windows.Forms.ToolBarButton();
			this.tbColor = new System.Windows.Forms.ToolBarButton();
			this.tbImage = new System.Windows.Forms.ToolBarButton();
			this.tbExcel = new System.Windows.Forms.ToolBarButton();
			this.imgList = new System.Windows.Forms.ImageList(this.components);
			this.txtEditor = new System.Windows.Forms.RichTextBox();
			this.openDlg = new System.Windows.Forms.OpenFileDialog();
			this.saveDlg = new System.Windows.Forms.SaveFileDialog();
			this.fontDlg = new System.Windows.Forms.FontDialog();
			this.colorDlg = new System.Windows.Forms.ColorDialog();
			this.imgDlg = new System.Windows.Forms.OpenFileDialog();
			this.printDoc = new System.Drawing.Printing.PrintDocument();
			this.previewDlg = new System.Windows.Forms.PrintPreviewDialog();
			this.printDlg = new System.Windows.Forms.PrintDialog();
			this.pageSetDlg = new System.Windows.Forms.PageSetupDialog();
			this.SuspendLayout();
			// 
			// toolBar
			// 
			this.toolBar.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
			this.toolBar.AutoSize = false;
			this.toolBar.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																					   this.tbOpen,
																					   this.tbSave,
																					   this.tbSep1,
																					   this.tbPageSetup,
																					   this.tbPreview,
																					   this.tbPrint,
																					   this.tbSep2,
																					   this.tbFont,
																					   this.tbBold,
																					   this.tbItalic,
																					   this.tbUnderline,
																					   this.tbStrikeout,
																					   this.tbSep3,
																					   this.tbLeft,
																					   this.tbCenter,
																					   this.tbRight,
																					   this.tbSep4,
																					   this.tbUndo,
																					   this.tbRedo,
																					   this.tbSep5,
																					   this.tbColor,
																					   this.tbImage,
																					   this.tbExcel});
			this.toolBar.Divider = false;
			this.toolBar.DropDownArrows = true;
			this.toolBar.ImageList = this.imgList;
			this.toolBar.Location = new System.Drawing.Point(0, 0);
			this.toolBar.Name = "toolBar";
			this.toolBar.ShowToolTips = true;
			this.toolBar.Size = new System.Drawing.Size(600, 20);
			this.toolBar.TabIndex = 0;
			this.toolBar.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar_ButtonClick);
			// 
			// tbOpen
			// 
			this.tbOpen.ImageIndex = 0;
			this.tbOpen.Tag = "Open";
			this.tbOpen.ToolTipText = "파일열기";
			// 
			// tbSave
			// 
			this.tbSave.ImageIndex = 1;
			this.tbSave.Tag = "Save";
			this.tbSave.ToolTipText = "파일저장";
			// 
			// tbSep1
			// 
			this.tbSep1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// tbPageSetup
			// 
			this.tbPageSetup.ImageIndex = 2;
			this.tbPageSetup.Tag = "PageSetup";
			this.tbPageSetup.ToolTipText = "출력페이지설정";
			// 
			// tbPreview
			// 
			this.tbPreview.ImageIndex = 3;
			this.tbPreview.Tag = "Preview";
			this.tbPreview.ToolTipText = "출력미리보기";
			// 
			// tbPrint
			// 
			this.tbPrint.ImageIndex = 4;
			this.tbPrint.Tag = "Print";
			this.tbPrint.ToolTipText = "출력";
			// 
			// tbSep2
			// 
			this.tbSep2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// tbFont
			// 
			this.tbFont.ImageIndex = 5;
			this.tbFont.Tag = "Font";
			this.tbFont.ToolTipText = "폰트설정";
			// 
			// tbBold
			// 
			this.tbBold.ImageIndex = 6;
			this.tbBold.Tag = "Bold";
			this.tbBold.ToolTipText = "굵게";
			// 
			// tbItalic
			// 
			this.tbItalic.ImageIndex = 7;
			this.tbItalic.Tag = "Italic";
			this.tbItalic.ToolTipText = "기울림꼴";
			// 
			// tbUnderline
			// 
			this.tbUnderline.ImageIndex = 8;
			this.tbUnderline.Tag = "Underline";
			this.tbUnderline.ToolTipText = "밑줄";
			// 
			// tbStrikeout
			// 
			this.tbStrikeout.ImageIndex = 9;
			this.tbStrikeout.Tag = "Strikeout";
			this.tbStrikeout.ToolTipText = "가운데선";
			// 
			// tbSep3
			// 
			this.tbSep3.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// tbLeft
			// 
			this.tbLeft.ImageIndex = 10;
			this.tbLeft.Tag = "Left";
			this.tbLeft.ToolTipText = "왼쪽정렬";
			// 
			// tbCenter
			// 
			this.tbCenter.ImageIndex = 11;
			this.tbCenter.Tag = "Center";
			this.tbCenter.ToolTipText = "가운데정렬";
			// 
			// tbRight
			// 
			this.tbRight.ImageIndex = 12;
			this.tbRight.Tag = "Right";
			this.tbRight.ToolTipText = "오른쪽정렬";
			// 
			// tbSep4
			// 
			this.tbSep4.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// tbUndo
			// 
			this.tbUndo.ImageIndex = 13;
			this.tbUndo.Tag = "Undo";
			this.tbUndo.ToolTipText = "실행취소";
			// 
			// tbRedo
			// 
			this.tbRedo.ImageIndex = 14;
			this.tbRedo.Tag = "Redo";
			this.tbRedo.ToolTipText = "실행복구";
			// 
			// tbSep5
			// 
			this.tbSep5.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// tbColor
			// 
			this.tbColor.ImageIndex = 15;
			this.tbColor.Tag = "Color";
			this.tbColor.ToolTipText = "색깔설정";
			// 
			// tbImage
			// 
			this.tbImage.ImageIndex = 16;
			this.tbImage.Tag = "Image";
			this.tbImage.ToolTipText = "그림삽입";
			// 
			// tbExcel
			// 
			this.tbExcel.ImageIndex = 17;
			this.tbExcel.Tag = "Excel";
			this.tbExcel.ToolTipText = "표삽입";
			// 
			// imgList
			// 
			this.imgList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
			this.imgList.ImageSize = new System.Drawing.Size(16, 16);
			this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
			this.imgList.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// txtEditor
			// 
			this.txtEditor.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtEditor.Location = new System.Drawing.Point(0, 20);
			this.txtEditor.Name = "txtEditor";
			this.txtEditor.Size = new System.Drawing.Size(600, 444);
			this.txtEditor.TabIndex = 1;
			this.txtEditor.Text = "";
			this.txtEditor.SelectionChanged += new System.EventHandler(this.txtEditor_SelectionChanged);
			// 
			// openDlg
			// 
			this.openDlg.DefaultExt = "rtf";
			this.openDlg.Filter = "Rich Text Files|*.rtf|Text File|*.txt";
			this.openDlg.Title = "Open File";
			// 
			// saveDlg
			// 
			this.saveDlg.DefaultExt = "rtf";
			this.saveDlg.Filter = "Rich Text File|*.rtf|Text File|*.txt";
			this.saveDlg.Title = "Save As";
			// 
			// imgDlg
			// 
			this.imgDlg.DefaultExt = "bmp";
			this.imgDlg.Filter = "All Image Files|*.bmp;*.ico;*.gif;*.jpeg;*.jpg;*.png;*.tif;*.tiff";
			this.imgDlg.Title = "Select Image";
			// 
			// printDoc
			// 
			this.printDoc.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.printDoc_BeginPrint);
			this.printDoc.EndPrint += new System.Drawing.Printing.PrintEventHandler(this.printDoc_EndPrint);
			this.printDoc.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDoc_PrintPage);
			// 
			// previewDlg
			// 
			this.previewDlg.AutoScrollMargin = new System.Drawing.Size(0, 0);
			this.previewDlg.AutoScrollMinSize = new System.Drawing.Size(0, 0);
			this.previewDlg.ClientSize = new System.Drawing.Size(400, 300);
			this.previewDlg.Document = this.printDoc;
			this.previewDlg.Enabled = true;
			this.previewDlg.Icon = ((System.Drawing.Icon)(resources.GetObject("previewDlg.Icon")));
			this.previewDlg.Location = new System.Drawing.Point(790, 17);
			this.previewDlg.MinimumSize = new System.Drawing.Size(375, 250);
			this.previewDlg.Name = "previewDlg";
			this.previewDlg.TransparencyKey = System.Drawing.Color.Empty;
			this.previewDlg.Visible = false;
			// 
			// printDlg
			// 
			this.printDlg.Document = this.printDoc;
			// 
			// pageSetDlg
			// 
			this.pageSetDlg.Document = this.printDoc;
			// 
			// XRichTextEditor
			// 
			this.Controls.Add(this.txtEditor);
			this.Controls.Add(this.toolBar);
			this.Name = "XRichTextEditor";
			this.Size = new System.Drawing.Size(600, 464);
			this.ResumeLayout(false);

		}
		#endregion

		#region ToolBar 버튼 Click
		private void toolBar_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			switch (e.Button.Tag.ToString())
			{
				case "Open":
					try
					{
						if (openDlg.ShowDialog() == DialogResult.OK)
						{
							//rtf File은 RichText 형식으로 
							if(System.IO.Path.GetExtension(openDlg.FileName).ToLower().Equals(".rtf")) 
								txtEditor.LoadFile(openDlg.FileName, RichTextBoxStreamType.RichText);
							else  //Text File은 PlainText
								txtEditor.LoadFile(openDlg.FileName, RichTextBoxStreamType.PlainText);
						}
					}
					catch (Exception xe)
					{
						XMessageBox.Show("File Open Error[" + xe.Message + "]");
					}
					break;
				case "Save":
					if(saveDlg.ShowDialog() == DialogResult.OK)
					{
						if(System.IO.Path.GetExtension(saveDlg.FileName).ToLower().Equals(".rtf"))
							txtEditor.SaveFile(saveDlg.FileName);
						else
							txtEditor.SaveFile(saveDlg.FileName, RichTextBoxStreamType.PlainText);
					}
					break;
				case "Font":
					if (txtEditor.SelectionFont != null)
						fontDlg.Font = txtEditor.SelectionFont;
					else
						fontDlg.Font = txtEditor.Font;
					//선택된 Color 설정
					fontDlg.Color = this.selectedColor;

					if (fontDlg.ShowDialog() == DialogResult.OK)
					{
						if (txtEditor.SelectionFont != null)
						{
							txtEditor.SelectionFont = fontDlg.Font;
							txtEditor.SelectionColor = fontDlg.Color;
						}
						else //Font 설정
						{
							txtEditor.Font = fontDlg.Font;
							txtEditor.ForeColor = fontDlg.Color;
						}
						this.selectedColor = fontDlg.Color;
						this.selectedFont = fontDlg.Font;
					}
					break;
				case "Bold":
					if (txtEditor.SelectionFont != null)
						txtEditor.SelectionFont = new Font(txtEditor.SelectionFont, txtEditor.SelectionFont.Style ^ FontStyle.Bold);
					break;
				case "Italic":
					if (txtEditor.SelectionFont != null)
						txtEditor.SelectionFont = new Font(txtEditor.SelectionFont, txtEditor.SelectionFont.Style ^ FontStyle.Italic);
					break;
				case "Underline":
					if (txtEditor.SelectionFont != null)
						txtEditor.SelectionFont = new Font(txtEditor.SelectionFont, txtEditor.SelectionFont.Style ^ FontStyle.Underline);
					break;
				case "Strikeout":
					if (txtEditor.SelectionFont != null)
						txtEditor.SelectionFont = new Font(txtEditor.SelectionFont, txtEditor.SelectionFont.Style ^ FontStyle.Strikeout);
					break;
				case "Left":
					txtEditor.SelectionAlignment = HorizontalAlignment.Left; 
					break;
				case "Center":
					txtEditor.SelectionAlignment = HorizontalAlignment.Center; 
					break;
				case "Right":
					txtEditor.SelectionAlignment = HorizontalAlignment.Right; 
					break;
				case "Undo":
					txtEditor.Undo();
					break;
				case "Redo":
					txtEditor.Redo();
					break;
				case "Color":
					colorDlg.Color = this.selectedColor;
					if (colorDlg.ShowDialog() == DialogResult.OK)
					{
						txtEditor.SelectionColor = colorDlg.Color;
						this.selectedColor = colorDlg.Color;
					}
					break;
				case "Image":
					if (imgDlg.ShowDialog() == DialogResult.OK)
					{
						//Icon 파일
						if (System.IO.Path.GetExtension(imgDlg.FileName).ToLower().Equals(".ico"))
						{
							InsertImage(Bitmap.FromHicon((new Icon(imgDlg.FileName)).Handle));
						}
						else //Image FIle
						{
							InsertImage(Image.FromFile(imgDlg.FileName));
						}
					}
					break;
				case "Excel":
					if (this.excelReader != null)
					{
						AppendRtf(this.excelReader.ReadToEnd());
					}
					break;
				case "PageSetup":
					this.pageSetDlg.ShowDialog();
					break;
				case "Preview":  //미리보기
					this.previewDlg.ShowDialog();
					break;
				case "Print":    //출력
					if (this.printDlg.ShowDialog() == DialogResult.OK)
						this.printDoc.Print();
					break;

			}
			//속성에 따라 Toolbar Update
			UpdateToolbar();
		}
		#endregion

		#region Private Methods
		private void AppendRtf(string rtf)
		{
			//txtEditor.SelectionStart = this.txtEditor.Text.Length;
			txtEditor.SelectedRtf = rtf;
		}
		private void UpdateToolbar()
		{
			Font font;
			if(txtEditor.SelectionFont != null)
				font = txtEditor.SelectionFont;
			else
				font = txtEditor.Font;

			//Do all the toolbar button checks
			tbBold.Pushed		= font.Bold; //bold button
			tbItalic.Pushed	= font.Italic; //italic button
			tbUnderline.Pushed	= font.Underline; //underline button
			tbStrikeout.Pushed	= font.Strikeout; //strikeout button
			tbLeft.Pushed		= (txtEditor.SelectionAlignment == HorizontalAlignment.Left); //justify left
			tbCenter.Pushed	= (txtEditor.SelectionAlignment == HorizontalAlignment.Center); //justify center
			tbRight.Pushed		= (txtEditor.SelectionAlignment == HorizontalAlignment.Right); //justify right
			txtEditor.SelectionColor = this.selectedColor;  //Color
			font = this.selectedFont; //Font 설정
		}
		private void InsertImage(Image image)
		{
			Clipboard.SetDataObject(image);
			DataFormats.Format myFormat = DataFormats.GetFormat (DataFormats.Bitmap);
			// After verifying that the data can be pasted, paste
			if(txtEditor.CanPaste(myFormat)) 
			{
				txtEditor.Paste(myFormat);
			}
			else 
			{
				XMessageBox.Show("The data format that you attempted site" + 
					" is not supportedby this control.");
			}
		}
		#endregion

		#region txtEditor_SelectionChanged
		private void txtEditor_SelectionChanged(object sender, System.EventArgs e)
		{
			//선택사항 변경시에 선택영역의 속성에 따라 ToolBar Update
			UpdateToolbar();
		}
		#endregion

		#region 출력, 미리보기 관련
		private void printDoc_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
		{
			// Start at the beginning of the text
			firstChar = 0;
		}

		private void printDoc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
		
			// make the RichTextBox calculate and render as much text as will fit on the page
			// and remember the last character printed for the next page
			firstChar = FormatRange(false, e, firstChar, txtEditor.TextLength);

			if (firstChar < txtEditor.TextLength)
				e.HasMorePages = true;
			else
				e.HasMorePages = false;
		}

		private void printDoc_EndPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
		{
			// Clean up cached information
			FormatRangeDone();
		}
		/// <summary>
		/// Calculate (and render) the contents of the RichTextBox for a printing page
		/// </summary>
		/// <param name="measureOnly">If true, only the calculation is performed, otherwise the text is rendered as well</param>
		/// <param name="e">The PrintPageEventArgs object from the PrintPage event</param>
		/// <param name="charFrom">Index of first character to be printed</param>
		/// <param name="charTo">Index of last character to be printed</param>
		/// <returns>(Index of last character that fitted on the page) + 1</returns>
		private int FormatRange(bool measureOnly, PrintPageEventArgs e, int charFrom, int charTo)
		{
			CHARRANGE cr;
			cr.cpMin=charFrom;
			cr.cpMax=charTo;

			RECT rc;
			rc.top		= HundredthInchToTwips(e.MarginBounds.Top);
			rc.bottom	= HundredthInchToTwips(e.MarginBounds.Bottom);
			rc.left		= HundredthInchToTwips(e.MarginBounds.Left);
			rc.right	= HundredthInchToTwips(e.MarginBounds.Right);

			RECT rcPage;
			rcPage.top		= HundredthInchToTwips(e.PageBounds.Top);
			rcPage.bottom	= HundredthInchToTwips(e.PageBounds.Bottom);
			rcPage.left		= HundredthInchToTwips(e.PageBounds.Left);
			rcPage.right	= HundredthInchToTwips(e.PageBounds.Right);

			IntPtr hdc = e.Graphics.GetHdc();

			FORMATRANGE fr;
			fr.chrg		 = cr;
			fr.hdc		 = hdc;
			fr.hdcTarget = hdc;
			fr.rc		 = rc;
			fr.rcPage	 = rcPage;

			IntPtr wpar = new IntPtr(measureOnly ? 0 : 1);
			IntPtr lpar = Marshal.AllocCoTaskMem( Marshal.SizeOf( fr ) ); 
			Marshal.StructureToPtr(fr, lpar, false);

			IntPtr result = User32.SendMessage(txtEditor.Handle, EM_FORMATRANGE, wpar, lpar);

			Marshal.FreeCoTaskMem(lpar);

			e.Graphics.ReleaseHdc(hdc);

			return result.ToInt32();
		}
		/// <summary>
		/// Needs to be called after the print job is finished to release cached information
		/// </summary>
		private void FormatRangeDone()
		{
			User32.SendMessage(txtEditor.Handle, EM_FORMATRANGE, IntPtr.Zero, IntPtr.Zero);
		}
		/// <summary>
		/// Convert between 1/100 inch (unit used by the .NET framework)
		/// and twips (1/1440 inch, used by Win32 API calls)
		/// </summary>
		/// <param name="n">Value in 1/100 inch</param>
		/// <returns>Value in twips</returns>
		private int HundredthInchToTwips(int n)
		{
			return (int)(n*14.4);
		}
		#endregion

		#region SetControlTextByLangMode
		private void SetControlTextByLangMode()
		{
			this.tbOpen.ToolTipText = XMsg.GetField("F033"); //파일열기
			this.tbSave.ToolTipText = XMsg.GetField("F034"); //파일저장
			this.tbPageSetup.ToolTipText = XMsg.GetField("F035"); //출력페이지설정
			this.tbPreview.ToolTipText = XMsg.GetField("F036"); //출력미리보기
			this.tbPrint.ToolTipText = XMsg.GetField("F037"); //출력
			this.tbFont.ToolTipText = XMsg.GetField("F038"); //폰트설정
			this.tbBold.ToolTipText = XMsg.GetField("F039"); //굵게
			this.tbItalic.ToolTipText = XMsg.GetField("F040"); //기울림꼴
			this.tbUnderline.ToolTipText = XMsg.GetField("F041"); //밑줄
			this.tbStrikeout.ToolTipText = XMsg.GetField("F042"); //가운데선
			this.tbLeft.ToolTipText = XMsg.GetField("F043"); //왼쪽정렬
			this.tbCenter.ToolTipText = XMsg.GetField("F044"); //가운데정렬
			this.tbRight.ToolTipText = XMsg.GetField("F045"); //오른쪽정렬
			this.tbUndo.ToolTipText = XMsg.GetField("F046"); //실행취소
			this.tbRedo.ToolTipText = XMsg.GetField("F047"); //실행복구
			this.tbColor.ToolTipText = XMsg.GetField("F048"); //색깔설정
			this.tbImage.ToolTipText = XMsg.GetField("F049"); //그림삽입
			this.tbExcel.ToolTipText = XMsg.GetField("F050"); //표삽입
		}
		#endregion


	}
}
