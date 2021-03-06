using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace IHIS.Framework
{
	/// <summary>
	/// XMatrix에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(true)]
	[ToolboxBitmap(typeof(IHIS.Framework.XMatrix), "Images.XTaskBar.bmp")]
	public class XMatrix : System.Windows.Forms.Panel
	{
		#region Fields
		private IHIS.Framework.XMatrixControl matrixCont;
		private XColor xBackColor = XColor.XMatrixBackColor;
		#endregion

		#region Base Properties (not Browse)
		[Category("추가속성")]
		[Description("컨트롤에서 끌어놓기 알림을 받는지 여부를 지정합니다.")]
		[DefaultValue(false)]
		public override bool AllowDrop
		{
			get { return matrixCont.AllowDrop;}
			set 
			{
				base.AllowDrop = value;
				matrixCont.AllowDrop = value;
			}
		}
		[DefaultValue(typeof(XColor),"XMatrixBackColor"),
		Description("배경색을 지정합니다.")]
		public new XColor BackColor
		{
			get { return xBackColor;}
			set 
			{
				xBackColor = value;
				base.BackColor = value.Color;
			}
		}
		[Browsable(false)]
		public override Image BackgroundImage
		{
			get { return base.BackgroundImage;}
			set {} //Set 기능 없음
		}
		[Browsable(false)]
		public override Color ForeColor
		{
			get { return base.ForeColor;}
			set { }  //Set 기능 없음
		}
		[Browsable(false)]
		public override Font Font
		{
			get { return base.Font;}
			set {}  //Set 기능없음
		}
		[Browsable(false)]
		public override RightToLeft RightToLeft
		{
			get { return base.RightToLeft;}
			set {}  //Set 기능없음
		}
		[Browsable(false)]
		[DefaultValue(true)]
		public override bool AutoScroll
		{
			get { return base.AutoScroll;}
			set { }  //True
		}
		[Browsable(false)]
		public new Size AutoScrollMargin
		{
			get { return base.AutoScrollMargin;}
			set { }  //Set 기능 없음
		}
		[Browsable(false)]
		public new Size AutoScrollMinSize
		{
			get { return base.AutoScrollMinSize;}
			set { }  //Set 기능 없음
		}
		#endregion

		#region Properties
		[Browsable(false)]
		public XMatrixItemCollection Items
		{
			get { return matrixCont.Items;}
		}
		[Browsable(false)]
		public XColMatrixItemCollection ColItems
		{
			get { return matrixCont.ColItems;}
		}
		[Browsable(false)]
		public XRowMatrixItemCollection RowItems
		{
			get { return matrixCont.RowItems;}
		}
		[Browsable(false)]
		public XMatrixItemCollection SelectedItems
		{
			get { return matrixCont.SelectedItems;}
		}
		[Browsable(false)]
		[DefaultValue(true)]
		public bool Redraw
		{
			get { return matrixCont.ReDraw;}
			set { matrixCont.ReDraw = value;}
		}
		[Category("추가속성"), DefaultValue(80)]
		[Description("Matrix의 RowHeader의 너비를 지정합니다.")]
		public int RowHeaderWidth
		{
			get { return matrixCont.RowHeaderWidth;}
			set { matrixCont.RowHeaderWidth = value;}
		}
		[Category("추가속성"), DefaultValue(null)]
		[Description("Matrix의 ImageList를 지정합니다.")]
		public ImageList ImageList
		{
			get { return matrixCont.ImageList;}
			set { matrixCont.ImageList = value;}
		}
		[Category("추가속성"), DefaultValue(true)]
		[Description("Matrix의 Item이 Multi 선택이 가능한지 여부를 지정합니다.")]
		public bool EnableMultiSelection
		{
			get { return matrixCont.EnableMultiSelection;}
			set { matrixCont.EnableMultiSelection = value;}
		}
		[Category("추가속성"), DefaultValue(false)]
		[Description("Multi선택이 가능할때 Ctrl Key를 누르지 않고 선택가능한지 여부를 지정합니다.")]
		public bool ToggleSelection
		{
			get { return matrixCont.ToggleSelection;}
			set { matrixCont.ToggleSelection = value;}
		}
		#endregion

		#region Event
		[Browsable(true)]
		[Description("Matrix의 Item을 Click했을때 발생하는 Event입니다.")]
		[Category("추가이벤트")]
		public event XMatrixItemClickEventHandler ItemClick;
		[Browsable(true)]
		[Description("Matrix의 Item을 DoubleClick했을때 발생하는 Event입니다.")]
		[Category("추가이벤트")]
		public event XMatrixItemClickEventHandler ItemDoubleClick;
		[Browsable(true)]
		[Description("Matrix의 Item을 DragDrop했을때 발생하는 Event입니다.")]
		[Category("추가이벤트")]
		public event XMatrixItemDragDropEventHandler ItemDragDrop;
		#endregion
		
		#region 생성자
		public XMatrix()
		{
			base.AutoScroll = true;
			this.BackColor = XColor.XMatrixBackColor;

			matrixCont = new XMatrixControl();
			matrixCont.Location = new Point(0,0);
			matrixCont.Size = new Size(100,100);
			matrixCont.BackColor = XColor.XMatrixBackColor.Color;
			this.Controls.Add(matrixCont);

			//Event 연결
			matrixCont.ItemClick += new XMatrixItemClickEventHandler(OnMatrixItemClick);
			matrixCont.ItemDoubleClick += new XMatrixItemClickEventHandler(OnMatrixItemDoubleClick);
			matrixCont.ItemDragDrop += new XMatrixItemDragDropEventHandler(OnMatrixItemDragDrop);
			matrixCont.MouseDown += new MouseEventHandler(OnMatrixMouseDown);
			matrixCont.MouseEnter += new EventHandler(OnMatrixMouseEnter);
			matrixCont.MouseHover += new EventHandler(OnMatrixMouseHover);
			matrixCont.MouseLeave += new EventHandler(OnMatrixMouseLeave);
			matrixCont.MouseMove += new MouseEventHandler(OnMatrixMouseMove);
			matrixCont.MouseUp += new MouseEventHandler(OnMatrixMouseUp);
			matrixCont.DragEnter += new DragEventHandler(OnMatrixDragEnter);
			matrixCont.DragLeave += new EventHandler(OnMatrixDragLeave);
			matrixCont.DragOver += new DragEventHandler(OnMatrixDragOver);
			matrixCont.GiveFeedback += new GiveFeedbackEventHandler(OnMatrixGiveFeedback);
		}
		#endregion

		#region XMatrixCont Event
		private void OnMatrixItemClick(object sender, XMatrixItemClickEventArgs e)
		{
			//XMatrix의 Event Call
			OnItemClick(e);
		}
		private void OnMatrixItemDoubleClick(object sender, XMatrixItemClickEventArgs e)
		{
			//XMatrix의 Event Call
			OnItemDoubleClick(e);
		}
		private void OnMatrixItemDragDrop(object sender, XMatrixItemDragDropEventArgs e)
		{
			//XMatrix의 Event Call
			OnItemDragDrop(e);
		}
		private void OnMatrixMouseDown(object sender, MouseEventArgs e)
		{
			OnMouseDown(e);
		}
		private void OnMatrixMouseMove(object sender, MouseEventArgs e)
		{
			OnMouseMove(e);
		}
		private void OnMatrixMouseUp(object sender, MouseEventArgs e)
		{
			OnMouseUp(e);
		}
		private void OnMatrixMouseEnter(object sender, EventArgs e)
		{
			OnMouseEnter(e);
		}
		private void OnMatrixMouseHover(object sender, EventArgs e)
		{
			OnMouseHover(e);
		}
		private void OnMatrixMouseLeave(object sender, EventArgs e)
		{
			OnMouseLeave(e);
		}
		private void OnMatrixDragEnter(object sender, DragEventArgs e)
		{
			OnDragEnter(e);
		}
		private void OnMatrixDragOver(object sender, DragEventArgs e)
		{
			OnDragOver(e);
		}
		private void OnMatrixDragLeave(object sender, EventArgs e)
		{
			OnMouseLeave(e);
		}
		private void OnMatrixGiveFeedback(object sender, GiveFeedbackEventArgs e)
		{
			OnGiveFeedback(e);
		}

		#endregion

		#region Event Invoker
		protected virtual void OnItemClick(XMatrixItemClickEventArgs e)
		{
			if (this.ItemClick != null)
				this.ItemClick(this, e);
		}
		protected virtual void OnItemDoubleClick(XMatrixItemClickEventArgs e)
		{
			if (this.ItemDoubleClick != null)
				this.ItemDoubleClick(this, e);
		}
		protected virtual void OnItemDragDrop(XMatrixItemDragDropEventArgs e)
		{
			if (this.ItemDragDrop != null)
				this.ItemDragDrop(this, e);
		}
		#endregion

		#region Public Methods
		public void Setup()
		{
			matrixCont.Setup();
		}
		//Items 영역만 다시 배치할치(true), 전체를 배치할지(false)
		public void Setup(bool arrangeOnlyItemRegion)
		{
			matrixCont.Setup(arrangeOnlyItemRegion);
		}
		public XMatrixItem GetHitItem(Point pt)
		{
			return matrixCont.GetHitItem(pt);
		}
		public void UnSelectAll()
		{
			matrixCont.UnSelectAll();
		}
		public void PageSetup()
		{
			matrixCont.PageSetup();
		}
		public void Print()
		{
			matrixCont.Print();
		}
		public void PrintPreview()
		{
			matrixCont.PrintPreview();
		}
		#endregion

		
	}
}
