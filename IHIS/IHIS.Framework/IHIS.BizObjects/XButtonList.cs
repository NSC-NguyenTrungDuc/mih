using System;
using System.Drawing.Text;
using System.Text;
using System.Reflection;
using System.Data;
using System.Collections;
using System.Drawing;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Globalization;
using System.Runtime.InteropServices;
using System.ComponentModel.Design.Serialization;

using IHIS.Framework;

namespace IHIS.Framework
{
	#region XButtonList
	/// <summary>
	/// XButtonList에 대한 요약 설명입니다.
	/// </summary>
	[DefaultEvent("ButtonClick")]
	[DefaultProperty("ListType")]
	[ToolboxBitmap(typeof(IHIS.Framework.XButtonList), "Images.XButtonList.bmp")]
	public class XButtonList : System.Windows.Forms.UserControl, IFunctionPerformer, ISupportInitialize
	{
		#region Fields
		private static Hashtable  defaultImageList = new Hashtable();
		const string IMAGE_PATH = "IHIS.Framework.Images.";
		const int Y_POS = 3;
		const int BTN_GAP = 1;  //버튼사이의 간격
		const int BTN_WIDTH = 80;  //버튼의 너비(80)
		const int BTN_HEIGHT = 28; //버튼의 높이
		const int BTN_MIN_WIDTH = 60; //최소 길이 60
		private Hashtable buttonList = new Hashtable();
		private ILayoutContainer layoutContainer = null; //버튼 List가 LayoutContainer위에 놓일때 LayoutContainer
		private FunctionPerformerType performerType = FunctionPerformerType.None;
		private System.Windows.Forms.ToolTip toolTip;
		private System.ComponentModel.IContainer components;
		private XColor xBackColor = XColor.XButtonListBackColor;
		private bool isVisibleReset = true;  //Reset 버튼을 보여줄지 여부를 관리합니다.
		private bool isVisiblePreview = true;  //Preview 버튼을 보여줄지 여부를 관리합니다.
		private bool isFunctionSuccess = true;  //기능수행의 성공여부를 관리합니다.
		private CustomFunctionItemCollection functionItems = new CustomFunctionItemCollection(); //2006.04.14 Custom Type 정의가능하게 추가
		private ImageList imageList = null; //Custom Type 에서 사용할 ImageList
		#endregion

		#region Base Property
		[DefaultValue(typeof(XColor),"XButtonListBackColor"),
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
		//기본값 변경
		[DefaultValue(AnchorStyles.Bottom|AnchorStyles.Right)]
		public override AnchorStyles Anchor
		{
			get	{ return base.Anchor;}
			set	{ base.Anchor = value;}
		}
		[Browsable(true), DefaultValue(typeof(Font), "MS UI Gothic, 9.75pt")]
		public override Font Font
		{
			get	{ return base.Font;	}
			set	{ base.Font = value;}
		}
		#endregion

		#region Property
		[Browsable(true), Category("추가속성"),
		DefaultValue(FunctionPerformerType.None),
		MergableProperty(true),
		Description("버튼 리스트의 기본 기능 Type을 지정합니다.")]
		public FunctionPerformerType PerformerType
		{
			get { return performerType;}
			set 
			{
				if (performerType != value)
				{
					performerType = value;
					if (this.DesignMode)
						InitializeButtons();
				}
			}
		}
		[Browsable(true), Category("추가속성"),
		DefaultValue(true),
		MergableProperty(true),
		Description("초기화 버튼을 보여줄지 여부를 지정합니다.")]
		public bool IsVisibleReset
		{
			get { return isVisibleReset;}
			set 
			{
				if (isVisibleReset != value)
				{
					isVisibleReset = value;
					if (this.DesignMode)
						InitializeButtons();
				}
			}
		}
		[Browsable(true), Category("추가속성"),
		DefaultValue(true),
		MergableProperty(true),
		Description("미리보기 버튼을 보여줄지 여부를 지정합니다.")]
		public bool IsVisiblePreview
		{
			get { return isVisiblePreview;}
			set 
			{
				if (isVisiblePreview != value)
				{
					isVisiblePreview = value;
					if (this.DesignMode)
						InitializeButtons();
				}
			}
		}
		[Category("추가속성"),
		DesignerSerializationVisibility(DesignerSerializationVisibility.Content),
		NotifyParentProperty(true),
		Description("Custom Type의 버튼리스트의 기능을 정의하는 Item의 리스트를 관리합니다.")]
		public CustomFunctionItemCollection FunctionItems
		{
			get { return this.functionItems; }
		}
		[Category("추가속성"),
		DefaultValue(null),
		MergableProperty(true),
		Description("Custom Type의 버튼리스트에서 사용할 ImageList를 지정합니다.")]
		public ImageList ImageList
		{
			get { return imageList; }
			set { imageList = value;}
		}
		#endregion

		#region Event
		[Browsable(true),Category("추가이벤트"),
		Description("버튼을 Click했을때 발생합니다.")]
		public event ButtonClickEventHandler ButtonClick;

		[Browsable(true),Category("추가이벤트"),
		Description("버튼 Click 완료후에 발생합니다.(기본처리후 추가처리시 사용)")]
		public event PostButtonClickEventHandler PostButtonClick;
		#endregion

		#region 생성자
		static XButtonList()
		{
			//XButtonList에 사용되는 기본이미지 GET
			System.Reflection.Assembly l_as = System.Reflection.Assembly.GetExecutingAssembly();
			defaultImageList.Add("U", Bitmap.FromStream(l_as.GetManifestResourceStream(IMAGE_PATH + "Update.gif")));
			defaultImageList.Add("I", Bitmap.FromStream(l_as.GetManifestResourceStream(IMAGE_PATH + "Insert.gif")));
			defaultImageList.Add("Q", Bitmap.FromStream(l_as.GetManifestResourceStream(IMAGE_PATH + "Query.gif")));
			defaultImageList.Add("D", Bitmap.FromStream(l_as.GetManifestResourceStream(IMAGE_PATH + "Delete.gif")));
			defaultImageList.Add("R", Bitmap.FromStream(l_as.GetManifestResourceStream(IMAGE_PATH + "Reset.gif")));
			defaultImageList.Add("X", Bitmap.FromStream(l_as.GetManifestResourceStream(IMAGE_PATH + "Close.gif")));
			defaultImageList.Add("P", Bitmap.FromStream(l_as.GetManifestResourceStream(IMAGE_PATH + "Print.gif")));
			defaultImageList.Add("V", Bitmap.FromStream(l_as.GetManifestResourceStream(IMAGE_PATH + "Preview.gif")));
			defaultImageList.Add("S", Bitmap.FromStream(l_as.GetManifestResourceStream(IMAGE_PATH + "Process.gif")));
			defaultImageList.Add("C", Bitmap.FromStream(l_as.GetManifestResourceStream(IMAGE_PATH + "Cancel.gif")));

		}
		public XButtonList()
		{
			InitializeComponent();

			this.BackColor = XColor.XButtonListBackColor;
			this.Font = new Font("MS UI Gothic", 9.75f);
			this.Size = new Size(200,38);
			//Ancher는 BottomRight
			this.Anchor = AnchorStyles.Bottom|AnchorStyles.Right;

		}
		#endregion

		#region Dispose
		/// <summary>
		/// <MEMORY LEAK> 2007.10.12 이전에 Dispose 부분이 없어서 toolTip등이 Dispose 되지 않았음.
		/// toolTip을 사용하므로 반드시 Dispose 해 주어야 함.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if( components != null )
					components.Dispose();
			}
			base.Dispose( disposing );
		}
		#endregion

		#region ButtonClick, PostButtonClick 관련
		protected virtual void OnButtonClick(ButtonClickEventArgs e)
		{
			if (ButtonClick != null)
				ButtonClick(this, e);
		}
		protected virtual void OnPostButtonClick(PostButtonClickEventArgs e)
		{
			if (PostButtonClick != null)
				PostButtonClick(this, e);
		}
		private void Button_Click(object sender, EventArgs e)
		{
			FunctionType func = (FunctionType) ((XButton) sender).Tag ;
			this.isFunctionSuccess = true;  //기능수행 성공여부 (Reset)
			if (ButtonClick != null)
			{
				ButtonClickEventArgs xe = new ButtonClickEventArgs(func, true, true);
				OnButtonClick(xe);
				//ButtonClick 기능수행후 성공여부 SET
				this.isFunctionSuccess = xe.IsSuccess;
				//Base Call이면 PerformClickSub
				if (xe.IsBaseCall)
					this.isFunctionSuccess = PerformClickSub(func);
			}
			else //ButtonClick Event가 없으면 기본 수행
				this.isFunctionSuccess = PerformClickSub(func);

			//버튼 처리 완료후 Event Call
			if (PostButtonClick != null)
			{
				PostButtonClickEventArgs xxe = new PostButtonClickEventArgs(func, this.isFunctionSuccess);
				OnPostButtonClick(xxe);
			}
		}
		private void Button_MouseEnter(object sender, EventArgs e)
		{
			//각 버튼의 MouseHover시에 ToolTip Text Set
			FunctionType func = (FunctionType) ((Control) sender).Tag;
			string tipText = "";
			switch (func)
			{
				case FunctionType.Query:
					tipText = XMsg.GetField("F001") + "[F5]"; // 단축키[F5]
					this.toolTip.SetToolTip((Control) sender, tipText);
					break;
				case FunctionType.Insert:
					tipText = XMsg.GetField("F001") + "[F7]"; // 단축키[F7]
					this.toolTip.SetToolTip((Control) sender, tipText);
					break;
				case FunctionType.Delete:
					tipText = XMsg.GetField("F001") + "[F5]"; // 단축키[F9]
					this.toolTip.SetToolTip((Control) sender, tipText);
					break;
				case FunctionType.Print:
					tipText = XMsg.GetField("F001") + "[F12]"; // 단축키[F12]
					this.toolTip.SetToolTip((Control) sender, tipText);
					break;
				case FunctionType.Preview:
					tipText = XMsg.GetField("F001") + "[F11]"; // 단축키[F11]
					this.toolTip.SetToolTip((Control) sender, tipText);
					break;
				case FunctionType.Update:
					tipText = XMsg.GetField("F001") + "[F12]"; // 단축키[F12]
					this.toolTip.SetToolTip((Control) sender, tipText);
					break;
				case FunctionType.Reset:
					tipText = XMsg.GetField("F001") + "[F3]"; // 단축키[F3]
					this.toolTip.SetToolTip((Control) sender, tipText);
					break;
				case FunctionType.Process:
					tipText = XMsg.GetField("F001") + "[F12]"; // 단축키[F12]
					this.toolTip.SetToolTip((Control) sender, tipText);
					break;
				case FunctionType.Cancel:
					tipText = XMsg.GetField("F001") + "[F11]"; // 단축키[F11]
					this.toolTip.SetToolTip((Control) sender, tipText);
					break;
				case FunctionType.Close:
					tipText = XMsg.GetField("F002"); // 화면 닫기
					this.toolTip.SetToolTip((Control) sender, tipText);
					break;
			}
		}
		private bool PerformClickSub(FunctionType func)
		{
			bool result = true;
			switch (func)
			{
				case FunctionType.Insert:  //현재 MultiInputLayout Insert
					
					if (this.layoutContainer != null)
					{
						//Validation Check 현재 편집중인 값 AcceptData 처리 (Validation 통과못할땐 처리불가)
						if (!this.layoutContainer.AcceptData()) return false;
						
						//InsertRow 성공여부 Set
						if (this.layoutContainer.CurrMSLayout != null)
							result =  (this.layoutContainer.CurrMSLayout.InsertRow() >= 0 ? true : false);
					}
					break;
				case FunctionType.Delete: //현재 MultiInputLayout Delete
					if (this.layoutContainer != null)
					{
						//Validation Check 현재 편집중인 값 AcceptData 처리 (Validation 통과못할땐 처리불가)
						if (!this.layoutContainer.AcceptData()) return false;
						// 삭제 성공여부 SET
						if (this.layoutContainer.CurrMSLayout != null)
							result = this.layoutContainer.CurrMSLayout.DeleteRow();
					}
					
					break;
				case FunctionType.Query: //현재 MultiOutputLayout에 조회 Method Call
					if (this.layoutContainer != null)
					{
						//Validation Check 현재 편집중인 값 AcceptData 처리 (Validation 통과못할땐 처리불가)
						if (!this.layoutContainer.AcceptData()) return false; 

						// 조회 성공여부 SET
						if (this.layoutContainer.CurrMQLayout != null)
							result = this.layoutContainer.CurrMQLayout.QueryLayout(this.layoutContainer.CurrMQLayout.IsAllDataQuery);
					}

					break;
				case FunctionType.Update: //지정된 저장서비스 Call
					if ((this.layoutContainer != null) && (this.layoutContainer.SaveLayoutList.Count > 0))
					{
						//Validation Check 현재 편집중인 값 AcceptData 처리 (Validation 통과못할땐 처리불가)
						if (!this.layoutContainer.AcceptData()) return false;
						
						try
						{
							//여러개의 Layout 저장이면 여기서 Transaction 처리하고, Layout의 기본 Transaction을 사용하지 않음
							//한개의 Layout 저장이면 Layout의 기본 Transaction 사용함.
							if (this.layoutContainer.SaveLayoutList.Count > 1)
							{
								for (int i = 0 ; i < this.layoutContainer.SaveLayoutList.Count ; i++)
								{
									if (this.layoutContainer.SaveLayoutList[i] is ISaveLayout)
									{
										((ISaveLayout) this.layoutContainer.SaveLayoutList[i]).UseDefaultTransaction = false;
									}
								}
							}
							else
							{
								if (this.layoutContainer.SaveLayoutList[0] is ISaveLayout)
								{
									((ISaveLayout) this.layoutContainer.SaveLayoutList[0]).UseDefaultTransaction = true;
								}
							}

							if (this.layoutContainer.SaveLayoutList.Count > 1)
								Service.BeginTransaction();

							result = true;
							for (int i = 0; i < this.layoutContainer.SaveLayoutList.Count ; i++)
							{
								if (this.layoutContainer.SaveLayoutList[i] is ISaveLayout)
								{
									if (!((ISaveLayout) this.layoutContainer.SaveLayoutList[i]).SaveLayout())
									{
										throw new Exception("저장실패");
									}
								}
							}
							//여러 MultiLayout 저장시 Tran Commit
							if (this.layoutContainer.SaveLayoutList.Count > 1)
								Service.CommitTransaction();
						}
						catch
						{
							result = false;
							//여러 MultiLayout 저장시 Tran Rollback
							if (this.layoutContainer.SaveLayoutList.Count > 1)
								Service.RollbackTransaction();
						}
					}
					break;
				case FunctionType.Print:
					if ((this.layoutContainer != null) && (this.layoutContainer.PrintWorker != null))
					{
						this.layoutContainer.PrintWorker.Print();
					}
					
					break;
				case FunctionType.Reset:
					//Validation Check 없음
					if (this.layoutContainer != null)
						this.layoutContainer.Reset();
					break;
				case FunctionType.Close:
					//Validation Check 없음
					if (this.layoutContainer != null)
						this.layoutContainer.Close();
					break;
			}
			return result;
		}
		#endregion

		#region SetEnabled
		public void SetEnabled(FunctionType func, bool enabled)
		{
			if (this.buttonList.Contains(func.ToString()))
				((XButton) this.buttonList[func.ToString()]).Enabled = enabled;
		}
		#endregion

		#region IFunctionPerformer.PerformFunction
		void IFunctionPerformer.PerformFunction(FunctionType func)
		{
			//해당 기능을 가진 버튼이 있으면 버튼 Click
			if (this.buttonList.Contains(func.ToString()))
				((XButton)this.buttonList[func.ToString()]).PerformClick();
		}
		/// <summary>
		/// 특정기능수행을 성공했는지 여부를 가져옵니다.
		/// </summary>
		bool IFunctionPerformer.IsFunctionSuccess
		{
			get { return this.isFunctionSuccess;}
		}
		#endregion

		#region OnParentChanged
		protected override void OnParentChanged(EventArgs e)
		{
			base.OnParentChanged (e);
			//Parent가 LayoutContainer인지 여부 확인
			this.layoutContainer = null;
			Control parentControl = null;
			if (this.Parent != null)
			{
				// DataLayout Container의 Current DataLayout 초기화
				if(ParentIsILayoutContainer(this.Parent, out parentControl))
				{
					this.layoutContainer = (ILayoutContainer) parentControl;
					//LayoutContainer의 FunctionPerformer를 this로 설정
					this.layoutContainer.FunctionPerformer = this;
				}
			}
		}
		#endregion

		#region OnPaint
		protected override void OnPaint(PaintEventArgs e)
		{
			//Color Style 적용
			if (base.BackColor != xBackColor.Color)
				base.BackColor = xBackColor.Color;
			base.OnPaint(e);
		}
		#endregion

		#region InitializeButtonsSub( 기본 버튼 처리)
		private void InitializeButtonsSub(FunctionType func, ref int xPos)
		{
			XButton btn = new XButton();
			btn.Tag = func;
			btn.Size = new Size(BTN_WIDTH, BTN_HEIGHT);
			btn.Location = new Point(xPos, Y_POS);
			btn.Click += new EventHandler(Button_Click);
			btn.MouseEnter +=new EventHandler(Button_MouseEnter);
			switch (func)
			{
				case FunctionType.Insert:
					btn.Text = XMsg.GetField("F003"); // 입 력
					btn.Image = (Image) defaultImageList["I"];
					break;
				case FunctionType.Delete:
					btn.Text =  XMsg.GetField("F004"); // 삭 제
					btn.Image = (Image) defaultImageList["D"];
					break;
				case FunctionType.Query:
					btn.Text =  XMsg.GetField("F005"); // 조 회
					btn.Image = (Image) defaultImageList["Q"];
					break;
				case FunctionType.Reset:
					btn.Text =  XMsg.GetField("F006"); // 초기화
					btn.Image = (Image) defaultImageList["R"];
					btn.Scheme = XButtonSchemes.Green;
					break;
				case FunctionType.Update:
					btn.Text =  XMsg.GetField("F007"); // 저 장
					btn.Image = (Image) defaultImageList["U"];
					break;
				case FunctionType.Close:
					btn.Text =  XMsg.GetField("F008"); // 닫 기
					btn.Image = (Image) defaultImageList["X"];
					btn.Scheme = XButtonSchemes.OliveGreen;
					break;
				case FunctionType.Print:
					btn.Text =  XMsg.GetField("F009"); // 출 력
					btn.Image = (Image) defaultImageList["P"];
					break;
				case FunctionType.Preview:
					btn.Text =  XMsg.GetField("F010"); // 미리보기
					btn.Image = (Image) defaultImageList["V"];
					break;
				case FunctionType.Cancel:
					btn.Text =  XMsg.GetField("F011"); // 취 소
					btn.Image = (Image) defaultImageList["C"];
					btn.Scheme = XButtonSchemes.Green;
					break;
				case FunctionType.Process:
					btn.Text =  XMsg.GetField("F012"); // 처 리
					btn.Image = (Image) defaultImageList["S"];
					break;
			}
			this.Controls.Add(btn);
			//버튼 List에 버튼 관리
			this.buttonList.Add(func.ToString(), btn);
			xPos += BTN_WIDTH + BTN_GAP;
		}
		#endregion

		#region InitializeButtonsCustomSub(CustomFunctionItem에 따라 버튼 생성)
		private int GetButtonWidth(CustomFunctionItem funcItem)
		{
			//Text가 없으면 기본 Size
			if (funcItem.Text.Trim() == "") return BTN_WIDTH;
			
			int width = 0;
			using (Graphics g = this.CreateGraphics())
			{
				StringFormat format  = new StringFormat();
				format.HotkeyPrefix  = HotkeyPrefix.Show;
				format.Trimming = StringTrimming.EllipsisWord;
				SizeF textSize = g.MeasureString(funcItem.Text, this.Font, new PointF(0,0), format);
				width = Math.Max((int) textSize.Width + 10, BTN_MIN_WIDTH);
				//Image가 있으면 ImageSize 고려하여 처리함 (imageList.
				//이미지가 없으면 기본이미지를 적용하므로 모두 동일하게 적용함. (일단 20으로 고정)
				width += 20;
				//				if ((this.imageList != null) && (funcItem.ImageIndex >= 0) && (funcItem.ImageIndex < imageList.Images.Count))
				//					width += imageList.ImageSize.Width + 4; //보통 16일 경우 4fixel 정도 여부를 둠
			}

			return width;
		}
		private void InitializeButtonsCustomSub(CustomFunctionItem funcItem, ref int xPos)
		{
			XButton btn = new XButton();
			btn.Tag = funcItem.FuncType;
			int btnWidth = GetButtonWidth(funcItem);
			//Text가 있을 경우 Size 동적으로 계산, Image까지 고려하여 처리함.
			btn.Size = new Size(btnWidth, BTN_HEIGHT);
			btn.Location = new Point(xPos, Y_POS);
			btn.Click += new EventHandler(Button_Click);
			btn.MouseEnter +=new EventHandler(Button_MouseEnter);
			//Text는 Text가 없으면 기본 Text를 설정, 있으면 그 Text로 설정
			switch (funcItem.FuncType)
			{
				case FunctionType.Insert:
					btn.Text = (funcItem.Text != "" ? funcItem.Text : XMsg.GetField("F003")); // 입 력
					//이미지는 ImageList가 있고 ImageIndex가 유효하면 지정한 이미지, 아니면 기본 이미지
					if ((this.imageList != null) && (funcItem.ImageIndex >= 0) && (funcItem.ImageIndex < imageList.Images.Count))
						btn.Image = imageList.Images[funcItem.ImageIndex];
					else
						btn.Image = (Image) defaultImageList["I"];
					//Scheme 적용
					if (funcItem.Scheme != "")
					{
						try
						{
							btn.Scheme = (XButtonSchemes) Enum.Parse(typeof(XButtonSchemes), funcItem.Scheme);
						}
						catch{}
					}
					break;
				case FunctionType.Delete:
					btn.Text = (funcItem.Text != "" ? funcItem.Text : XMsg.GetField("F004")); // 삭 제
					//이미지는 ImageList가 있고 ImageIndex가 유효하면 지정한 이미지, 아니면 기본 이미지
					if ((this.imageList != null) && (funcItem.ImageIndex >= 0) && (funcItem.ImageIndex < imageList.Images.Count))
						btn.Image = imageList.Images[funcItem.ImageIndex];
					else
						btn.Image = (Image) defaultImageList["D"];
					//Scheme 적용
					if (funcItem.Scheme != "")
					{
						try
						{
							btn.Scheme = (XButtonSchemes) Enum.Parse(typeof(XButtonSchemes), funcItem.Scheme);
						}
						catch{}
					}
					break;
				case FunctionType.Query:
					btn.Text = (funcItem.Text != "" ? funcItem.Text : XMsg.GetField("F005")); // 조 회
					//이미지는 ImageList가 있고 ImageIndex가 유효하면 지정한 이미지, 아니면 기본 이미지
					if ((this.imageList != null) && (funcItem.ImageIndex >= 0) && (funcItem.ImageIndex < imageList.Images.Count))
						btn.Image = imageList.Images[funcItem.ImageIndex];
					else
						btn.Image = (Image) defaultImageList["Q"];
					//Scheme 적용
					if (funcItem.Scheme != "")
					{
						try
						{
							btn.Scheme = (XButtonSchemes) Enum.Parse(typeof(XButtonSchemes), funcItem.Scheme);
						}
						catch{}
					}
					break;
				case FunctionType.Reset:
					btn.Text = (funcItem.Text != "" ? funcItem.Text : XMsg.GetField("F006")); // 초기화
					//이미지는 ImageList가 있고 ImageIndex가 유효하면 지정한 이미지, 아니면 기본 이미지
					if ((this.imageList != null) && (funcItem.ImageIndex >= 0) && (funcItem.ImageIndex < imageList.Images.Count))
						btn.Image = imageList.Images[funcItem.ImageIndex];
					else
						btn.Image = (Image) defaultImageList["R"];
					//Scheme 적용
					if (funcItem.Scheme != "")
					{
						try
						{
							btn.Scheme = (XButtonSchemes) Enum.Parse(typeof(XButtonSchemes), funcItem.Scheme);
						}
						catch{}
					}
					else
						btn.Scheme = XButtonSchemes.Green;
					break;
				case FunctionType.Update:
					btn.Text = (funcItem.Text != "" ? funcItem.Text : XMsg.GetField("F007")); // 저 장
					//이미지는 ImageList가 있고 ImageIndex가 유효하면 지정한 이미지, 아니면 기본 이미지
					if ((this.imageList != null) && (funcItem.ImageIndex >= 0) && (funcItem.ImageIndex < imageList.Images.Count))
						btn.Image = imageList.Images[funcItem.ImageIndex];
					else
						btn.Image = (Image) defaultImageList["U"];
					//Scheme 적용
					if (funcItem.Scheme != "")
					{
						try
						{
							btn.Scheme = (XButtonSchemes) Enum.Parse(typeof(XButtonSchemes), funcItem.Scheme);
						}
						catch{}
					}
					break;
				case FunctionType.Close:
					btn.Text = (funcItem.Text != "" ? funcItem.Text : XMsg.GetField("F008")); // 닫 기
					//이미지는 ImageList가 있고 ImageIndex가 유효하면 지정한 이미지, 아니면 기본 이미지
					if ((this.imageList != null) && (funcItem.ImageIndex >= 0) && (funcItem.ImageIndex < imageList.Images.Count))
						btn.Image = imageList.Images[funcItem.ImageIndex];
					else
						btn.Image = (Image) defaultImageList["X"];
					//Scheme 적용
					if (funcItem.Scheme != "")
					{
						try
						{
							btn.Scheme = (XButtonSchemes) Enum.Parse(typeof(XButtonSchemes), funcItem.Scheme);
						}
						catch{}
					}
					else
						btn.Scheme = XButtonSchemes.OliveGreen;
					break;
				case FunctionType.Print:
					btn.Text = (funcItem.Text != "" ? funcItem.Text : XMsg.GetField("F009")); // 출 력
					//이미지는 ImageList가 있고 ImageIndex가 유효하면 지정한 이미지, 아니면 기본 이미지
					if ((this.imageList != null) && (funcItem.ImageIndex >= 0) && (funcItem.ImageIndex < imageList.Images.Count))
						btn.Image = imageList.Images[funcItem.ImageIndex];
					else
						btn.Image = (Image) defaultImageList["P"];
					//Scheme 적용
					if (funcItem.Scheme != "")
					{
						try
						{
							btn.Scheme = (XButtonSchemes) Enum.Parse(typeof(XButtonSchemes), funcItem.Scheme);
						}
						catch{}
					}
					break;
				case FunctionType.Preview:
					btn.Text = (funcItem.Text != "" ? funcItem.Text : XMsg.GetField("F010")); // 미리보기
					//이미지는 ImageList가 있고 ImageIndex가 유효하면 지정한 이미지, 아니면 기본 이미지
					if ((this.imageList != null) && (funcItem.ImageIndex >= 0) && (funcItem.ImageIndex < imageList.Images.Count))
						btn.Image = imageList.Images[funcItem.ImageIndex];
					else
						btn.Image = (Image) defaultImageList["V"];
					//Scheme 적용
					if (funcItem.Scheme != "")
					{
						try
						{
							btn.Scheme = (XButtonSchemes) Enum.Parse(typeof(XButtonSchemes), funcItem.Scheme);
						}
						catch{}
					}
					break;
				case FunctionType.Cancel:
					btn.Text = (funcItem.Text != "" ? funcItem.Text : XMsg.GetField("F011")); // 취 소
					//이미지는 ImageList가 있고 ImageIndex가 유효하면 지정한 이미지, 아니면 기본 이미지
					if ((this.imageList != null) && (funcItem.ImageIndex >= 0) && (funcItem.ImageIndex < imageList.Images.Count))
						btn.Image = imageList.Images[funcItem.ImageIndex];
					else
						btn.Image = (Image) defaultImageList["C"];
					//Scheme 적용
					if (funcItem.Scheme != "")
					{
						try
						{
							btn.Scheme = (XButtonSchemes) Enum.Parse(typeof(XButtonSchemes), funcItem.Scheme);
						}
						catch{}
					}
					else
						btn.Scheme = XButtonSchemes.Green;
					break;
				case FunctionType.Process:
					btn.Text = (funcItem.Text != "" ? funcItem.Text : XMsg.GetField("F012")); // 처 리
					//이미지는 ImageList가 있고 ImageIndex가 유효하면 지정한 이미지, 아니면 기본 이미지
					if ((this.imageList != null) && (funcItem.ImageIndex >= 0) && (funcItem.ImageIndex < imageList.Images.Count))
						btn.Image = imageList.Images[funcItem.ImageIndex];
					else
						btn.Image = (Image) defaultImageList["S"];
					//Scheme 적용
					if (funcItem.Scheme != "")
					{
						try
						{
							btn.Scheme = (XButtonSchemes) Enum.Parse(typeof(XButtonSchemes), funcItem.Scheme);
						}
						catch{}
					}
					break;
			}
			this.Controls.Add(btn);
			//버튼 List에 버튼 관리
			this.buttonList.Add(funcItem.FuncType.ToString(), btn);
			xPos += btnWidth + BTN_GAP;
		}
		#endregion

		#region InitializeButtons
		public void InitializeButtons()
		{
			//buttonItems로 버튼 동적 생성
			//1.기존 Controls Clear
			//2.ButtonItems에 지정된 순서대로 버튼 생성
			this.Controls.Clear();
			this.buttonList.Clear();

			int xPos = BTN_GAP;
			switch (this.performerType)
			{
				case FunctionPerformerType.Entry:  //조회,입력,삭제,저장,초기화,닫기
					InitializeButtonsSub(FunctionType.Query,		ref xPos);
					InitializeButtonsSub(FunctionType.Insert,	ref xPos);
					InitializeButtonsSub(FunctionType.Delete,	ref xPos);
					InitializeButtonsSub(FunctionType.Update,	ref xPos);
					if (this.isVisibleReset)
						InitializeButtonsSub(FunctionType.Reset,	ref xPos);
					InitializeButtonsSub(FunctionType.Close,		ref xPos);
					break;
				case FunctionPerformerType.EntryS:  //조회,저장,초기화,닫기
					InitializeButtonsSub(FunctionType.Query,	ref xPos);
					InitializeButtonsSub(FunctionType.Update,	ref xPos);
					if (this.isVisibleReset)
						InitializeButtonsSub(FunctionType.Reset,	ref xPos);
					InitializeButtonsSub(FunctionType.Close,		ref xPos);
					break;
				case FunctionPerformerType.Query: //조회,초기화,닫기
					InitializeButtonsSub(FunctionType.Query,		ref xPos);
					if (this.isVisibleReset)
						InitializeButtonsSub(FunctionType.Reset,	ref xPos);
					InitializeButtonsSub(FunctionType.Close,		ref xPos);
					break;
				case FunctionPerformerType.Report:  //조회,미리보기,출력,초기화,닫기
					InitializeButtonsSub(FunctionType.Query,		ref xPos);
					//2005.12.13 Report에 미리보기 버튼 추가
					if (this.isVisiblePreview)
						InitializeButtonsSub(FunctionType.Preview,	ref xPos);
					InitializeButtonsSub(FunctionType.Print,		ref xPos);
					if (this.isVisibleReset)
						InitializeButtonsSub(FunctionType.Reset,	ref xPos);
					InitializeButtonsSub(FunctionType.Close,		ref xPos);
					break;
				case FunctionPerformerType.Print:  //미리보기,출력,종료
					if (this.isVisiblePreview)
						InitializeButtonsSub(FunctionType.Preview,		ref xPos);
					InitializeButtonsSub(FunctionType.Print,		ref xPos);
					InitializeButtonsSub(FunctionType.Close,		ref xPos);
					break;
				case FunctionPerformerType.Process: //처리,취소,닫기
					InitializeButtonsSub(FunctionType.Process,	ref xPos);
					InitializeButtonsSub(FunctionType.Cancel,	ref xPos);
					InitializeButtonsSub(FunctionType.Close,	ref xPos);
					break;
				case FunctionPerformerType.Custom:  //Custom 처리
					//지정된 리스트로 버튼 구성
					foreach (CustomFunctionItem fItem in this.functionItems)
					{
						InitializeButtonsCustomSub(fItem, ref xPos);
					}
					break;
			}
			this.Size = new Size(xPos, Y_POS*2 + BTN_HEIGHT);
			//Size 조정후 버튼의 Docking Bottom,Right로 SET
			if (this.Controls.Count > 1)
			{
				foreach (Control cont in this.Controls)
					cont.Anchor = AnchorStyles.Bottom|AnchorStyles.Right;
			}
		}
		#endregion

		#region ISupportInitialize Implemetation
		/// <summary>
		/// 초기화가 시작됨을 개체에 알립니다.
		/// </summary>
		public virtual void BeginInit()
		{
		}
		/// <summary>
		/// 초기화 종료시 컬럼을 초기화(InitializeColumns)합니다.
		/// </summary>
		public virtual void EndInit()
		{
			this.InitializeButtons();
			
			if (!this.DesignMode)  //RunTime시
			{
				//layoutContainer SET
				//ButtonList가 Panel등 위에 있을때 InitializeComponents()에서 panel.Controls가 먼저 설정되고, 이때 OnParentChanged Event가 발생하는데
				//panel은 XScreen의 Controls에 나중에 Add되므로 layoutContainer를 설정하지 못한다.
				//따라서, panel이 XScreen의 Controls에 Add된 후에 다시 한번 확인하여 설정
				if (this.layoutContainer == null)
				{
					Control parentControl = null;
					if (this.Parent != null)
					{
						// DataLayout Container의 Current DataLayout 초기화
						if(ParentIsILayoutContainer(this.Parent, out parentControl))
						{
							this.layoutContainer = (ILayoutContainer) parentControl;
							//LayoutContainer의 FunctionPerformer를 this로 설정
							this.layoutContainer.FunctionPerformer = this;
						}
					}
				}
			}
		}
		#endregion

		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.toolTip = new System.Windows.Forms.ToolTip(this.components);
			// 
			// XButtonList
			// 
			this.Name = "XButtonList";

		}

		#region ParentIsILayoutContainer
		/// <summary>
		/// Parent Control이 ILayoutContainer인지 여부를 반환합니다.
		/// </summary>
		/// <param name="parent"> Parent Control </param>
		/// <param name="parentControl"> (out) Parent Control 개체 </param>
		/// <returns> ILayoutContainer이면 true, 아니면 false </returns>
		protected bool ParentIsILayoutContainer(Control parent, out Control parentControl)
		{
			parentControl = null;
			if(parent is ILayoutContainer)
			{
				parentControl = parent;
				return true;
			}
			else
			{
				if(parent.Parent != null)
					return ParentIsILayoutContainer(parent.Parent, out parentControl);
				else
					return false;
			}
		}
		#endregion

		#region PerformClick (버튼 Click 수행)
		public void PerformClick(FunctionType func)
		{
			if (this.buttonList.Contains(func.ToString()))
			{
				//Tag에 저장된 Button 객체로 Button_Click Event Call
				((XButton)this.buttonList[func.ToString()]).PerformClick();
			}
		}
		#endregion

	}
	#endregion

	#region ButtonClickEventHandler
	/// <summary>
	/// 버튼을 Click했을때 발생하는 Event입니다.
	/// </summary>
	[Serializable]
	public delegate void ButtonClickEventHandler(object sender, ButtonClickEventArgs e);
	
	public class ButtonClickEventArgs : EventArgs
	{
		FunctionType	func;
		bool isBaseCall = true; //Base Click을 처리할지 여부
		bool isSuccess  = true; //기능 수행 성공여부
		/// <summary>
		/// 버튼의 기능을 나타내는 Enum을 가져옵니다.
		/// </summary>
		public FunctionType Func
		{
			get { return func; }
		}
		/// <summary>
		/// 기본 기능을 수행할지 여부를 설정합니다.
		/// </summary>
		public bool IsBaseCall
		{
			get { return isBaseCall;}
			set { isBaseCall = value;}
		}
		/// <summary>
		/// 버튼 기능이 성공했는지 여부를 가져오거나 설정합니다.
		/// </summary>
		public bool IsSuccess
		{
			get { return isSuccess;}
			set { isSuccess = value;}
		}
		/// <summary>
		/// DataValidatingEventArgs 생성자
		/// </summary>
		/// <param name="cancel"> Event 취소여부 </param>
		/// <param name="dataValue"> 데이타 값 </param>
		public ButtonClickEventArgs(FunctionType func, bool isBaseCall, bool isSuccess)
		{
			this.func = func;
			this.isBaseCall = isBaseCall;
			this.isSuccess = isSuccess;
		}
	}
	#endregion

	#region PostButtonClickEventHandler
	/// <summary>
	/// 버튼을 Click했을때 발생하는 Event입니다.
	/// </summary>
	[Serializable]
	public delegate void PostButtonClickEventHandler(object sender, PostButtonClickEventArgs e);
	
	public class PostButtonClickEventArgs : EventArgs
	{
		private FunctionType	func;
		private bool isSuccess = true; //기능수행 성공여부
		/// <summary>
		/// 버튼의 기능을 나타내는 Enum을 가져옵니다.
		/// </summary>
		public FunctionType Func
		{
			get { return func; }
		}
		/// <summary>
		/// 기능 수행 성공여부 
		/// </summary>
		public bool IsSuccess
		{
			get { return isSuccess;}
		}
		/// <summary>
		/// DataValidatingEventArgs 생성자
		/// </summary>
		/// <param name="cancel"> Event 취소여부 </param>
		/// <param name="dataValue"> 데이타 값 </param>
		public PostButtonClickEventArgs(FunctionType func, bool isSuccess)
		{
			this.func = func;
			this.isSuccess = isSuccess;
		}
	}
	#endregion

	#region CustomFunctionItem (사용자 지정 기능수행 관리 Item)
	[Serializable]
	[TypeConverter(typeof(CustomFunctionItemTypeConverter))]
	public class CustomFunctionItem
	{
		#region Fields, Properties
		private FunctionType funcType = FunctionType.Close;
		private Shortcut shortCut = Shortcut.None;
		private string text = "";
		private int imageIndex = -1;
		private string scheme = "";  //버튼의 Scheme Text 지정
		[DefaultValue(FunctionType.Close)]
		public FunctionType FuncType
		{
			get { return funcType;}
			set { funcType = value;}
		}
		[DefaultValue(Shortcut.None)]
		public Shortcut ShortCut
		{
			get { return shortCut;}
			set { shortCut = value;}
		}
		[DefaultValue("")]
		public string Text
		{
			get { return text;}
			set { text = value;}
		}
		[DefaultValue(-1)]
		public int ImageIndex
		{
			get { return imageIndex;}
			set { imageIndex = value;}
		}
		[DefaultValue("")]
		public string Scheme
		{
			get { return scheme;}
			set { scheme = value;}
		}
		#endregion

		#region 생성자
		public CustomFunctionItem(FunctionType funcType, Shortcut shortCut, string text, int imageIndex, string scheme)
		{
			this.funcType = funcType;
			this.shortCut = shortCut;
			this.text = text;
			this.imageIndex = imageIndex;
			this.scheme = scheme;
		}
		#endregion
	}
	#endregion

	#region CustomFunctionItem Collection
	/// <summary>
	/// XComboItem 을 관리하는 컬렉션입니다.
	/// </summary>
	[Serializable]
	[Editor(typeof(CustomFunctionItemEditor), typeof(UITypeEditor))]
	public class CustomFunctionItemCollection : System.Collections.CollectionBase
	{
		/// <summary>
		/// 지정한 인덱스에 있는 ComboItem 가져옵니다.
		/// </summary>
		public CustomFunctionItem this[int index]
		{
			get 
			{ 
				if (index > Count - 1 || index < 0)
					return null;
				else
					return (CustomFunctionItem)List[index];
			}
		}
		/// <summary>
		/// 지정한 key(string)에 해당하는 ComboItem을 가져옵니다.
		/// </summary>
		public CustomFunctionItem this[FunctionType funcType]
		{
			get
			{
				foreach (CustomFunctionItem item in this)
				{
					if (item.FuncType == funcType) return item;
				}
				return null;
			}
		}
		/// <summary>
		/// CustomFunctionItem을 컬렉션의 끝에 추가합니다.
		/// </summary>
		/// <param name="comboItem"> CustomFunctionItem 개체 </param>
		/// <returns> 추가한 ComboItem 개체 </returns>
		public void Add(CustomFunctionItem funcItem)
		{
			//기존에 FuncType이 있으면 Propety만 변경
			foreach (CustomFunctionItem item in List)
			{
				if (item.FuncType == funcItem.FuncType)
				{
					item.ShortCut = funcItem.ShortCut;
					item.Text = funcItem.Text;
					item.ImageIndex = funcItem.ImageIndex;
					item.Scheme = funcItem.Scheme;
					return;
				}
			}
			
			List.Add(funcItem);
		}
		/// <summary>
		/// CustomFunctionItem[]를 컬렉션에 추가합니다.
		/// </summary>
		/// <param name="items"> CustomFunctionItem[] </param>
		public void AddRange(CustomFunctionItem[] items)
		{
			List.Clear();
			foreach (CustomFunctionItem Item in items)
			{
				Add(Item);
			}
		}
		/// <summary>
		/// 실제값과 보여줄값으로 CustomFunctionItem을 만들어 컬렉션에 추가합니다.
		/// </summary>
		/// <param name="valueItem"> 실제값 </param>
		/// <param name="displayItem"> 보여줄값 </param>
		/// <returns> 생성된 ComboItem 개체 </returns>
		public void Add(FunctionType funcType, Shortcut shortCut, string text, int imageIndex, string scheme)
		{
			foreach (CustomFunctionItem item in List)
			{
				if (item.FuncType == funcType)
				{
					item.ShortCut = shortCut;
					item.Text = text;
					item.ImageIndex = imageIndex;
					item.Scheme = scheme;
					return;
				}
			}
			CustomFunctionItem	funcItem = new CustomFunctionItem(funcType, shortCut, text, imageIndex, scheme);
			List.Add(funcItem);
		}
		/// <summary>
		/// 지정한 Index의 ComboItem을 삭제합니다.
		/// </summary>
		/// <param name="index"> 지정 Index </param>
		public void Remove(int index)
		{
			if (index > Count - 1 || index < 0)
			{
				throw (new System.IndexOutOfRangeException());
			}
			else
			{
				List.RemoveAt(index); 
			}
		}
		public void Remove(FunctionType funcType)
		{
			for (int i = 0 ; i < this.Count ; i++)
			{
				if (this[i].FuncType == funcType)
				{
					this.Remove(i);
					break;
				}

			}
		}
		public void Remove(CustomFunctionItem item)
		{
			List.Remove(item);
		}
		/// <summary>
		/// 컬렉션에 속하는 XComboItem을 ComboItem[]에 복사하여 반환합니다.
		/// </summary>
		/// <returns> XComboItem[] </returns>
		public CustomFunctionItem[] ToArray()
		{
			CustomFunctionItem[] itemArray = new CustomFunctionItem[List.Count];
			for (int i = 0; i < List.Count; i++)
				itemArray[i] = (CustomFunctionItem) List[i];
			return itemArray;
		}
		/// <summary>
		/// 해당이름의 요소가 컬렉션에 있는지 여부를 확인합니다.
		/// </summary>
		/// <param name="dataName"></param>
		/// <returns> PreDataItem가 컬렉션에 있으면 true이고, 그렇지 않으면 false입니다. </returns>
		public bool Contains(FunctionType funcType)
		{
			foreach (CustomFunctionItem item in List)
				if (item.FuncType == funcType)
					return true;
			return false;
		}
		public bool Contains(CustomFunctionItem item)
		{
			return List.Contains(item);
		}
	}
	#endregion

	#region CustomFunctionItem Type Converter
	/// <summary>
	/// CustomFunctionItem Type Converter
	/// </summary>
	public class CustomFunctionItemTypeConverter : TypeConverter
	{
		/// <summary>
		/// 이 변환기가 개체를 지정된 형식으로 변환할 수 있는지 여부를 반환합니다.
		/// </summary>
		/// <param name="context"> 형식 컨텍스트를 제공하는 ITypeDescriptorContext </param>
		/// <param name="destinationType"> 변환할 대상 형식을 나타내는 Type </param>
		/// <returns> 이 변환기가 변환을 수행할 수 있으면 true이고, 그렇지 않으면 false </returns>
		public override bool CanConvertTo (ITypeDescriptorContext context, System.Type destinationType)
		{
			if (destinationType == typeof(InstanceDescriptor))
				return true;

			return base.CanConvertTo(context, destinationType);
		}
		/// <summary>
		/// 지정된 값 개체를 지정된 형식으로 변환합니다.
		/// </summary>
		/// <param name="context"> 형식 컨텍스트를 제공하는 ITypeDescriptorContext </param>
		/// <param name="culture"> CultureInfo 개체 </param>
		/// <param name="value"> 변환할 Object </param>
		/// <param name="destinationType"> value 매개 변수를 변환할 Type </param>
		/// <returns> 변환된 값을 나타내는 Object </returns>
		public override object ConvertTo
			(ITypeDescriptorContext context, CultureInfo culture,
			object value, System.Type destinationType )
		{
			CustomFunctionItem funcItem;
			object[] args;

			System.Type[] Types = new Type[]{typeof(FunctionType), typeof(Shortcut), typeof(string), typeof(int), typeof(string)};

			if (destinationType == typeof(InstanceDescriptor))
			{
				if (value is CustomFunctionItem)
				{
					funcItem = (CustomFunctionItem)value;
					args = new Object[]{funcItem.FuncType, funcItem.ShortCut, funcItem.Text, funcItem.ImageIndex, funcItem.Scheme};

					InstanceDescriptor id = new InstanceDescriptor(funcItem.GetType().GetConstructor(Types), args);

					return id;
				}
			}

			return base.ConvertTo(context, culture, value, destinationType);
		}
	}
	#endregion

}
