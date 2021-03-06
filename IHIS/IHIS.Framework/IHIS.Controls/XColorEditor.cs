using System;
using System.Collections;
using System.CodeDom;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Drawing.Design;
using System.Data;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Reflection;
using System.Globalization;

namespace IHIS.Framework
{
	internal enum ZAxis
	{
		/// <summary>The Z Axis is red</summary>
		Red,
		/// <summary>The Z Axis is blue</summary>
		Blue,
		/// <summary>The Z Axis is green</summary>
		Green
	}


	/// <summary>
	/// IcmColorEditorControl에 대한 요약 설명입니다.
	/// </summary>
	internal class XColorEditorControl : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.TabControl tabColor;
		private System.Windows.Forms.TabPage tpUserColor;
		private System.Windows.Forms.TabPage tpWebColor;
		private System.Windows.Forms.TabPage tpSysColor;
		private System.Windows.Forms.TabPage tpIcmColor;
		private System.Windows.Forms.ListBox listWebColor;
		private System.Windows.Forms.ListBox listSysColor;
		private System.Windows.Forms.ListBox listIcmColor;
		private System.Windows.Forms.RadioButton rbBlue;
		private System.Windows.Forms.RadioButton rbRed;
		private System.Windows.Forms.RadioButton rbGreen;
		private System.Windows.Forms.NumericUpDown udRed;
		private System.Windows.Forms.NumericUpDown udGreen;
		private System.Windows.Forms.NumericUpDown udBlue;
		private System.Windows.Forms.Label lbColor;

		private ZAxis zaxis = ZAxis.Red;
		private int xVal = 0;
		private int yVal = 0;
		private bool bMouseDown = false;
		private System.Drawing.Bitmap imgColors = new System.Drawing.Bitmap(256, 256);
		private Color defaultColor = Color.Gray;

		public XColor SelectedColor;
		private System.Windows.Forms.PictureBox palette;
		public int	 SelectedColorType = 0;
		public event EventHandler ColorSelected;
		protected virtual void OnColorSelected(object sender, EventArgs e)
		{
			SelectedColorType = this.tabColor.SelectedIndex;
			if (tabColor.SelectedTab != tpUserColor)
			{
				ListBox listBox = (ListBox)sender;
				SelectedColor = (XColor) listBox.SelectedItem;
			}
			else  //UserColor는 lbColor의 BackColor
			{
				SelectedColor = new XColor(lbColor.BackColor);
			}
			if (ColorSelected != null)
				ColorSelected(this, e);
		}
		/// <summary> 
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public XColorEditorControl(object pColor)
		{
			// 이 호출은 Windows.Forms Form 디자이너에 필요합니다.
			InitializeComponent();
			
			//SelectedColor Set
			SelectedColor = pColor as XColor;

			//ListBox ClickEvent Hander
			this.listIcmColor.Click += new EventHandler(OnColorSelected);
			this.listSysColor.Click += new EventHandler(OnColorSelected);
			this.listWebColor.Click += new EventHandler(OnColorSelected);
			// TODO: InitForm을 호출한 다음 초기화 작업을 추가합니다.

			//Color, SystemColors, IcmColor ListBox에 Set
			PropertyInfo[] webColorInfos = typeof(System.Drawing.Color).GetProperties();
			PropertyInfo[] sysColorInfos = typeof(System.Drawing.SystemColors).GetProperties();
			PropertyInfo[] icmColorInfos = typeof(XColor).GetProperties(BindingFlags.Static|BindingFlags.GetProperty|BindingFlags.Public);

			//ListWebColor Set
			foreach (PropertyInfo info in webColorInfos)
				if (info.PropertyType == typeof(Color))
				{
					XColor itemColor = new XColor((Color)info.GetValue(null,null));
					listWebColor.Items.Add(itemColor);
				}
			//SysColor Set		
			foreach (PropertyInfo info in sysColorInfos)
				if (info.PropertyType == typeof(Color))
				{
					XColor itemColor = new XColor((Color)info.GetValue(null,null));
					listSysColor.Items.Add(itemColor);
				}
			//XColor set
			foreach (PropertyInfo info in icmColorInfos)
				if (info.PropertyType == typeof(XColor))
				{
					XColor itemColor = (XColor)info.GetValue(null,null);
					listIcmColor.Items.Add(itemColor);
				}
			
			//UserColor Palette Set
			this.palette.Image = imgColors;
			//DefaultColor Set
			udRed.Value = defaultColor.R;
			udGreen.Value = defaultColor.G;
			udBlue.Value = defaultColor.B;
			MakePalette();
			rbRed.Checked = true;

			// 서로 다른 색을 2개이상 선택시에 pColor == null 이때는 TabPage만 선택후 Return
			if (pColor == null)
			{
				this.tabColor.SelectedTab = this.tpIcmColor;
				return;
			}

			//Color로 Color ListBox의 Color Select
			//순서 :IcmColor -> SystemColor -> WebColor -> 사용자 정의
			// System,Web Color가 아니면 IcmColor에서 Find
			if (SelectedColor.IsXColor)
			{
				foreach (XColor item in this.listIcmColor.Items)
				{
					if (item.ColorName.Equals(SelectedColor.ColorName))
					{
						this.tabColor.SelectedTab = this.tpIcmColor;
						this.listIcmColor.SelectedItem = item;
						return;
					}
				}
			}
			//System Color
			else if (SelectedColor.Color.IsSystemColor)
			{
				foreach (XColor item in this.listSysColor.Items)
				{
					if (item.ColorName.Equals(SelectedColor.ColorName))
					{
						this.tabColor.SelectedTab = this.tpSysColor;
						this.listSysColor.SelectedItem = item;
						return;
					}
				}
			}
			//Web Color
			else if (SelectedColor.Color.IsKnownColor)
			{
				foreach (XColor item in this.listWebColor.Items)
				{
					if (item.ColorName.Equals(SelectedColor.ColorName))
					{
						this.tabColor.SelectedTab = this.tpWebColor;
						this.listWebColor.SelectedItem = item;
						return;
					}
				}
			}
			else
			{
				// 사용자정의 Color로 Set
				this.tabColor.SelectedTab = this.tpUserColor;
				//Value Set
				udRed.Value = SelectedColor.Color.R;
				udGreen.Value = SelectedColor.Color.G;
				udBlue.Value = SelectedColor.Color.B;
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

		#region Component Designer generated code
		/// <summary> 
		/// 디자이너 지원에 필요한 메서드입니다. 
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
		/// </summary>
		private void InitializeComponent()
		{
			this.tabColor = new System.Windows.Forms.TabControl();
			this.tpIcmColor = new System.Windows.Forms.TabPage();
			this.listIcmColor = new System.Windows.Forms.ListBox();
			this.tpWebColor = new System.Windows.Forms.TabPage();
			this.listWebColor = new System.Windows.Forms.ListBox();
			this.tpSysColor = new System.Windows.Forms.TabPage();
			this.listSysColor = new System.Windows.Forms.ListBox();
			this.tpUserColor = new System.Windows.Forms.TabPage();
			this.lbColor = new System.Windows.Forms.Label();
			this.udBlue = new System.Windows.Forms.NumericUpDown();
			this.udGreen = new System.Windows.Forms.NumericUpDown();
			this.udRed = new System.Windows.Forms.NumericUpDown();
			this.rbBlue = new System.Windows.Forms.RadioButton();
			this.rbGreen = new System.Windows.Forms.RadioButton();
			this.rbRed = new System.Windows.Forms.RadioButton();
			this.palette = new System.Windows.Forms.PictureBox();
			this.tabColor.SuspendLayout();
			this.tpIcmColor.SuspendLayout();
			this.tpWebColor.SuspendLayout();
			this.tpSysColor.SuspendLayout();
			this.tpUserColor.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.udBlue)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.udGreen)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.udRed)).BeginInit();
			this.SuspendLayout();
			// 
			// tabColor
			// 
			this.tabColor.Controls.Add(this.tpIcmColor);
			this.tabColor.Controls.Add(this.tpWebColor);
			this.tabColor.Controls.Add(this.tpSysColor);
			this.tabColor.Controls.Add(this.tpUserColor);
			this.tabColor.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabColor.Location = new System.Drawing.Point(0, 0);
			this.tabColor.Name = "tabColor";
			this.tabColor.SelectedIndex = 0;
			this.tabColor.Size = new System.Drawing.Size(264, 336);
			this.tabColor.TabIndex = 0;
			// 
			// tpIcmColor
			// 
			this.tpIcmColor.Controls.Add(this.listIcmColor);
			this.tpIcmColor.Location = new System.Drawing.Point(4, 21);
			this.tpIcmColor.Name = "tpIcmColor";
			this.tpIcmColor.Size = new System.Drawing.Size(256, 311);
			this.tpIcmColor.TabIndex = 3;
			this.tpIcmColor.Text = "XColor";
			// 
			// listIcmColor
			// 
			this.listIcmColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.listIcmColor.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listIcmColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
			this.listIcmColor.ItemHeight = 12;
			this.listIcmColor.Location = new System.Drawing.Point(0, 0);
			this.listIcmColor.Name = "listIcmColor";
			this.listIcmColor.Size = new System.Drawing.Size(256, 311);
			this.listIcmColor.TabIndex = 1;
			this.listIcmColor.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.MeasureItemEventHandler);
			this.listIcmColor.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.DrawItemEventHandler);
			// 
			// tpWebColor
			// 
			this.tpWebColor.Controls.Add(this.listWebColor);
			this.tpWebColor.Location = new System.Drawing.Point(4, 21);
			this.tpWebColor.Name = "tpWebColor";
			this.tpWebColor.Size = new System.Drawing.Size(256, 311);
			this.tpWebColor.TabIndex = 1;
			this.tpWebColor.Text = "Web";
			// 
			// listWebColor
			// 
			this.listWebColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.listWebColor.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listWebColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
			this.listWebColor.Location = new System.Drawing.Point(0, 0);
			this.listWebColor.Name = "listWebColor";
			this.listWebColor.Size = new System.Drawing.Size(256, 311);
			this.listWebColor.TabIndex = 0;
			this.listWebColor.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.MeasureItemEventHandler);
			this.listWebColor.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.DrawItemEventHandler);
			// 
			// tpSysColor
			// 
			this.tpSysColor.Controls.Add(this.listSysColor);
			this.tpSysColor.Location = new System.Drawing.Point(4, 21);
			this.tpSysColor.Name = "tpSysColor";
			this.tpSysColor.Size = new System.Drawing.Size(256, 311);
			this.tpSysColor.TabIndex = 2;
			this.tpSysColor.Text = "시스템";
			// 
			// listSysColor
			// 
			this.listSysColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.listSysColor.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listSysColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
			this.listSysColor.ItemHeight = 12;
			this.listSysColor.Location = new System.Drawing.Point(0, 0);
			this.listSysColor.Name = "listSysColor";
			this.listSysColor.Size = new System.Drawing.Size(256, 311);
			this.listSysColor.TabIndex = 1;
			this.listSysColor.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.MeasureItemEventHandler);
			this.listSysColor.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.DrawItemEventHandler);
			// 
			// tpUserColor
			// 
			this.tpUserColor.Controls.Add(this.lbColor);
			this.tpUserColor.Controls.Add(this.udBlue);
			this.tpUserColor.Controls.Add(this.udGreen);
			this.tpUserColor.Controls.Add(this.udRed);
			this.tpUserColor.Controls.Add(this.rbBlue);
			this.tpUserColor.Controls.Add(this.rbGreen);
			this.tpUserColor.Controls.Add(this.rbRed);
			this.tpUserColor.Controls.Add(this.palette);
			this.tpUserColor.DockPadding.Bottom = 55;
			this.tpUserColor.Location = new System.Drawing.Point(4, 21);
			this.tpUserColor.Name = "tpUserColor";
			this.tpUserColor.Size = new System.Drawing.Size(256, 311);
			this.tpUserColor.TabIndex = 0;
			this.tpUserColor.Text = "사용자정의";
			// 
			// lbColor
			// 
			this.lbColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lbColor.Location = new System.Drawing.Point(158, 264);
			this.lbColor.Name = "lbColor";
			this.lbColor.Size = new System.Drawing.Size(92, 42);
			this.lbColor.TabIndex = 7;
			this.lbColor.Click += new System.EventHandler(this.OnColorSelected);
			// 
			// udBlue
			// 
			this.udBlue.Location = new System.Drawing.Point(104, 288);
			this.udBlue.Maximum = new System.Decimal(new int[] {
																   255,
																   0,
																   0,
																   0});
			this.udBlue.Name = "udBlue";
			this.udBlue.Size = new System.Drawing.Size(48, 21);
			this.udBlue.TabIndex = 6;
			this.udBlue.TextChanged += new System.EventHandler(this.udBlue_TextChanged);
			this.udBlue.ValueChanged += new System.EventHandler(this.udBlue_ValueChanged);
			// 
			// udGreen
			// 
			this.udGreen.Location = new System.Drawing.Point(56, 288);
			this.udGreen.Maximum = new System.Decimal(new int[] {
																	255,
																	0,
																	0,
																	0});
			this.udGreen.Name = "udGreen";
			this.udGreen.Size = new System.Drawing.Size(48, 21);
			this.udGreen.TabIndex = 5;
			this.udGreen.TextChanged += new System.EventHandler(this.udGreen_TextChanged);
			this.udGreen.ValueChanged += new System.EventHandler(this.udGreen_ValueChanged);
			// 
			// udRed
			// 
			this.udRed.Enabled = false;
			this.udRed.Location = new System.Drawing.Point(8, 288);
			this.udRed.Maximum = new System.Decimal(new int[] {
																  255,
																  0,
																  0,
																  0});
			this.udRed.Name = "udRed";
			this.udRed.Size = new System.Drawing.Size(48, 21);
			this.udRed.TabIndex = 4;
			this.udRed.TextChanged += new System.EventHandler(this.udRed_TextChanged);
			this.udRed.ValueChanged += new System.EventHandler(this.udRed_ValueChanged);
			// 
			// rbBlue
			// 
			this.rbBlue.Appearance = System.Windows.Forms.Appearance.Button;
			this.rbBlue.BackColor = System.Drawing.Color.Blue;
			this.rbBlue.Cursor = System.Windows.Forms.Cursors.Default;
			this.rbBlue.Font = new System.Drawing.Font("굴림", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((System.Byte)(129)));
			this.rbBlue.Location = new System.Drawing.Point(104, 264);
			this.rbBlue.Name = "rbBlue";
			this.rbBlue.Size = new System.Drawing.Size(48, 20);
			this.rbBlue.TabIndex = 3;
			this.rbBlue.Text = "B";
			this.rbBlue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.rbBlue.CheckedChanged += new System.EventHandler(this.rbBlue_CheckedChanged);
			// 
			// rbGreen
			// 
			this.rbGreen.Appearance = System.Windows.Forms.Appearance.Button;
			this.rbGreen.BackColor = System.Drawing.Color.Green;
			this.rbGreen.Cursor = System.Windows.Forms.Cursors.Default;
			this.rbGreen.Font = new System.Drawing.Font("굴림", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((System.Byte)(129)));
			this.rbGreen.Location = new System.Drawing.Point(56, 264);
			this.rbGreen.Name = "rbGreen";
			this.rbGreen.Size = new System.Drawing.Size(48, 20);
			this.rbGreen.TabIndex = 2;
			this.rbGreen.Text = "G";
			this.rbGreen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.rbGreen.CheckedChanged += new System.EventHandler(this.rbGreen_CheckedChanged);
			// 
			// rbRed
			// 
			this.rbRed.Appearance = System.Windows.Forms.Appearance.Button;
			this.rbRed.BackColor = System.Drawing.Color.Red;
			this.rbRed.Cursor = System.Windows.Forms.Cursors.Default;
			this.rbRed.Font = new System.Drawing.Font("굴림", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((System.Byte)(129)));
			this.rbRed.Location = new System.Drawing.Point(8, 264);
			this.rbRed.Name = "rbRed";
			this.rbRed.Size = new System.Drawing.Size(48, 20);
			this.rbRed.TabIndex = 1;
			this.rbRed.Text = "R";
			this.rbRed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.rbRed.CheckedChanged += new System.EventHandler(this.rbRed_CheckedChanged);
			// 
			// palette
			// 
			this.palette.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.palette.Dock = System.Windows.Forms.DockStyle.Fill;
			this.palette.Location = new System.Drawing.Point(0, 0);
			this.palette.Name = "palette";
			this.palette.Size = new System.Drawing.Size(256, 256);
			this.palette.TabIndex = 0;
			this.palette.TabStop = false;
			this.palette.Paint += new System.Windows.Forms.PaintEventHandler(this.palette_Paint);
			this.palette.MouseUp += new System.Windows.Forms.MouseEventHandler(this.palette_MouseUp);
			this.palette.MouseMove += new System.Windows.Forms.MouseEventHandler(this.palette_MouseMove);
			this.palette.MouseDown += new System.Windows.Forms.MouseEventHandler(this.palette_MouseDown);
			// 
			// XColorEditorControl
			// 
			this.Controls.Add(this.tabColor);
			this.Name = "XColorEditorControl";
			this.Size = new System.Drawing.Size(264, 336);
			this.tabColor.ResumeLayout(false);
			this.tpIcmColor.ResumeLayout(false);
			this.tpWebColor.ResumeLayout(false);
			this.tpSysColor.ResumeLayout(false);
			this.tpUserColor.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.udBlue)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.udGreen)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.udRed)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region EventHandler
		private void DrawItemEventHandler(object sender, System.Windows.Forms.DrawItemEventArgs e)
		{
			ListBox listBox = (ListBox) sender;
			XColor item = (XColor) listBox.Items[e.Index];
			
			e.DrawBackground();
			e.DrawFocusRectangle();
			e.Graphics.FillRectangle(new SolidBrush(item.Color), e.Bounds.Left + 1, e.Bounds.Top + 1, 20, 12);
			e.Graphics.DrawRectangle(new Pen(Color.Black, 1), e.Bounds.Left + 1, e.Bounds.Top + 1, 20, 12);
			e.Graphics.DrawString(item.ColorName, this.Font, new SolidBrush(e.ForeColor),
				new Rectangle(e.Bounds.X + 25, e.Bounds.Y + 1, e.Bounds.Width, e.Bounds.Height));
		}

		private void MeasureItemEventHandler(object sender, System.Windows.Forms.MeasureItemEventArgs e)
		{
			ListBox listBox = (ListBox) sender;
			e.ItemHeight= listBox.Font.Height + 2;
		}

		private void palette_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			bMouseDown = true;
			SetCoords(e.X,e.Y);
		}

		private void palette_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if( bMouseDown )
			{
				SetCoords(e.X,e.Y);
			}
		}

		private void palette_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			bMouseDown = false;
		}

		private void palette_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			Pen p = new Pen(Color.Gray);

			const int offset = 5;

			e.Graphics.DrawLine( p, xVal, 0, xVal, yVal-offset );
			e.Graphics.DrawLine( p, xVal, yVal+offset, xVal, 255 );

			e.Graphics.DrawLine( p, 0, yVal, xVal-offset, yVal );
			e.Graphics.DrawLine( p, xVal+offset, yVal, 255, yVal );

			e.Graphics.DrawRectangle( p, xVal-offset, yVal-offset, 2*offset, 2*offset );

			p.Dispose();
			p = null;
		}
		private void rbRed_CheckedChanged(object sender, System.EventArgs e)
		{
			// 변경가능,불가 Set
			if (rbRed.Checked)
			{
				zaxis = ZAxis.Red;
				MakeRedPalette();
				GetCoords();
				palette.Refresh();
				udRed.Enabled = false;
			}
			else
				udRed.Enabled = true;
		}
		private void rbGreen_CheckedChanged(object sender, System.EventArgs e)
		{
			// 변경가능,불가 Set
			if (rbGreen.Checked)
			{
				zaxis = ZAxis.Green;
				MakeGreenPalette();
				GetCoords();
				palette.Refresh();
				udGreen.Enabled = false;
			}
			else
				udGreen.Enabled = true;
		}

		private void rbBlue_CheckedChanged(object sender, System.EventArgs e)
		{
			// 변경가능,불가 Set
			if (rbBlue.Checked)
			{
				zaxis = ZAxis.Blue;
				MakeBluePalette();
				GetCoords();
				palette.Refresh();
				udBlue.Enabled = false;
			}
			else
				udBlue.Enabled = true;
		}
		private void udRed_ValueChanged(object sender, System.EventArgs e)
		{
			//Coords로 PictureBox Refresh
			GetCoords();
			palette.Refresh();
		}

		private void udGreen_ValueChanged(object sender, System.EventArgs e)
		{
			//Coords로 PictureBox Refresh
			GetCoords();
			palette.Refresh();
		}

		private void udBlue_ValueChanged(object sender, System.EventArgs e)
		{
			//Coords로 PictureBox Refresh
			GetCoords();
			palette.Refresh();
		}

		private void udRed_TextChanged(object sender, System.EventArgs e)
		{
			GetCoords();
			palette.Refresh();
		}

		private void udGreen_TextChanged(object sender, System.EventArgs e)
		{
			GetCoords();
			palette.Refresh();
		}

		private void udBlue_TextChanged(object sender, System.EventArgs e)
		{
			GetCoords();
			palette.Refresh();
		}
		#endregion

		#region Private Method
		private void MakePalette()
		{
			switch( zaxis )
			{
				case ZAxis.Red:
					MakeRedPalette();
					break;
				case ZAxis.Blue:
					MakeBluePalette();
					break;
				case ZAxis.Green:
					MakeGreenPalette();
					break;
			}
		}
		private void MakeRedPalette()
		{
			int red_value = (int) udRed.Value;

			for( int i=0; i<255; i++ )
			{
				for( int j=0; j<255; j++ )
				{
					imgColors.SetPixel(i, j, Color.FromArgb(red_value, i, j) );
				}
			}
		}

		private void MakeBluePalette()
		{
			int blue_value = (int) udBlue.Value;

			for( int i=0; i<255; i++ )
			{
				for( int j=0; j<255; j++ )
				{
					imgColors.SetPixel(i, j, Color.FromArgb(i, j, blue_value) );
				}
			}
		}

		private void MakeGreenPalette()
		{
			int green_value = (int) udGreen.Value;

			for( int i=0; i<255; i++ )
			{
				for( int j=0; j<255; j++ )
				{
					imgColors.SetPixel(i, j, Color.FromArgb(i, green_value, j) );
				}
			}
		}

		private void GetCoords()
		{
			switch( zaxis )
			{
				case ZAxis.Green:
					xVal = (int) udRed.Value;
					yVal = (int) udBlue.Value;
					break;
				case ZAxis.Red:
					xVal = (int) udGreen.Value;
					yVal = (int) udBlue.Value;
					break;
				case ZAxis.Blue:
					xVal = (int) udRed.Value;
					yVal = (int) udGreen.Value;
					break;
			}

			//Label BackColor Set
			lbColor.BackColor = Color.FromArgb((int) udRed.Value, (int) udGreen.Value, (int) udBlue.Value);
		}

		private void SetCoordBound( ref int coord )
		{
			if( coord < 0 )
				coord = 0;
			if( coord > 255 )
				coord = 255;
		}

		private void SetCoords(int x, int y)
		{
			SetCoordBound( ref x );
			SetCoordBound( ref y );

			switch( zaxis )
			{
				case ZAxis.Green:
					udRed.Value   = x;
					udBlue.Value  = y;
					break;
				case ZAxis.Red:
					udGreen.Value = x;
					udBlue.Value  = y;
					break;
				case ZAxis.Blue:
					udRed.Value   = x;
					udGreen.Value = y;
					break;
			}

			//Label BackColor Set
			lbColor.BackColor = Color.FromArgb((int) udRed.Value, (int) udGreen.Value, (int) udBlue.Value);
		}
		#endregion

	}

	/// <summary>
	/// XColorEditor에 대한 요약 설명입니다.
	/// </summary>
	internal class XColorEditor : System.Drawing.Design.UITypeEditor
	{
	
		//IWindowsFormsEditorService Interface 
		//Windows Forms 대화 상자나 폼 그리고 드롭다운 목록 컨트롤을 표시할 인터페이스를 제공합니다
		private IWindowsFormsEditorService edSvc = null;
		
		/// <summary>
		/// GetEditStyle에 표시된 편집기 스타일을 사용하여 지정된 개체의 값을 편집합니다.
		/// </summary>
		/// <param name="context"> 추가 컨텍스트 정보를 얻는 데 사용할 수 있는 ITypeDescriptorContext </param>
		/// <param name="provider"> 이 편집기에서 서비스를 얻는 데 사용할 수 있는 IServiceProvider </param>
		/// <param name="value"> 편집할 개체입니다. </param>
		/// <returns> 개체의 새 값 </returns>
		public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value) 
		{
			if (context != null
				&& context.Instance != null
				&& provider != null) 
			{
				
				//서비스 개체 즉, 다른 개체에 대한 사용자 지정 지원을 제공하는 개체를 검색하는 메커니즘을 정의합니다.
				//[ComVisible(false)] object GetService(Type serviceType); 지정된 형식의 서비스 개체를 가져옵니다
				edSvc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));

				if (edSvc != null)
				{
					// 속성창 Dropdown시에 표시할 Form 생성
					XColorEditorControl icmColorPicker = new XColorEditorControl(value);
					// Event Handler 추가 (Control의 Event와 Event  연결
					// Editor의 Value를 바꾸면 바로 Dropdown한 Editor 닫기
					icmColorPicker.ColorSelected += new EventHandler(this.ValueChanged);

					// DropDown형식으로 Editor표시
					edSvc.DropDownControl(icmColorPicker);
					// Desiner개체에 전달할 속성 set
					value = icmColorPicker.SelectedColor;
				}
			}

			return value;
		}
		
		/// <summary>
		/// EditValue 메서드에서 사용하는 편집기 스타일을 가져옵니다.
		/// </summary>
		/// <param name="context"> 추가 컨텍스트 정보를 얻는 데 사용할 수 있는 ITypeDescriptorContext </param>
		/// <returns> EditValue에서 사용하는 편집기 스타일을 나타내는 UITypeEditorEditStyle 값 </returns>
		public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context) 
		{
			if (context != null && context.Instance != null) 
			{
				//UITypeEditorStyle Enum : UITypeEditor의 값 편집 스타일을 나타내는 식별자를 지정
				//DropDown 드롭다운 대화 상자에 호스팅될 사용자 인터페이스 및 아래쪽 화살표 단추를 표시합니다. 
				//Modal 모달 대화 상자를 시작하는 ... 단추를 표시합니다. 
				//None 대화형 UI(사용자 인터페이스) 구성 요소를 제공하지 않습니다. 
				return UITypeEditorEditStyle.DropDown;  //  Modal상자 형식으로 속성창에 표시
			}
			return base.GetEditStyle(context);
		}
		/// <summary>
		/// 지정된 PaintValueEventArgs를 사용하여 개체 값 표시를 칠합니다.
		/// </summary>
		/// <param name="e"> 칠할 대상과 칠할 위치를 나타내는 PaintValueEventArgs </param>
		public override void PaintValue(PaintValueEventArgs e)
		{
			XColor item = e.Value as XColor;

			//그리기 영역에 itemColor Set
			e.Graphics.FillRectangle(new SolidBrush(item.Color), e.Bounds);
		}
		/// <summary>
		/// 지정된 컨텍스트에서 지정된 컨텍스트 내의 개체 값 표시를 칠할 수 있는지 여부를 나타냅니다.
		/// </summary>
		/// <param name="context"> 추가 컨텍스트 정보를 얻는 데 사용할 수 있는 ITypeDescriptorContext </param>
		/// <returns> PaintValue가 구현되면 true이고, 그렇지 않으면 false </returns>
		public override bool GetPaintValueSupported(ITypeDescriptorContext context)
		{
			return true;
		}


		private void ValueChanged(object sender, EventArgs e) 
		{
			if (edSvc != null) 
			{
				// DropDonw한 Editor Close
				edSvc.CloseDropDown();
			}
		}
	}

	
}
