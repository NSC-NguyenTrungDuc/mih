using System;
using System.Data;
using System.IO;
using System.Threading;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Resources;
using System.Reflection;
using System.Windows.Forms;

namespace IHIS.Framework
{
	/// <summary>
	/// XScreen에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class XScreen : System.Windows.Forms.UserControl, IXScreen, ILayoutContainer
	{
		#region static Property
		private static XScreen currentScreen = null; //현재 Popup으로 활성화된 화면
		private static int previousScreenIndex = -1; //이전 Tab위에 있던 화면의 TagPage Index
		/// <summary>
		/// 현재 Popup 활성화된 Screen을 가져오거나 설정합니다.
		/// </summary>
		public static XScreen CurrentScreen
		{
			get { return currentScreen;}
			set { currentScreen = value;}
		}
		/// <summary>
		/// 이전의 활성화되었던 화면의 TagPage Index
		/// GetPrevScreenPaid() 이전Tagpage에 있던 화면의 환자가져오는 Method에서 사용함.
		/// MdiForm::OnTagControlSelectionChanging에서 SET, 화면이 닫힐때는 Reset(MdiForm::RemoveTabPage)
		/// </summary>
		internal static int PreviousScreenIndex
		{
			get { return previousScreenIndex;}
			set { previousScreenIndex = value;}
		}
		#endregion

		#region Fields
		private XColor xBackColor = XColor.XScreenBackColor;
		private XColor xForeColor = XColor.NormalForeColor;
		// Container 참조
		private MdiForm		containerMdiForm = null;
		private MdiChild	containerMdiChild = null;
		private CommonItemCollection openParam = null;
		private OpenCommand openCommand = null; //2006.02.27 OpenCommand로 Screen Open 추가
		// 프로그램 정보 Info
		private ScreenInfo	screenInfo = null;
		//화면을 Open한 Object
		private object opener = null;
		protected System.Windows.Forms.ImageList ImageList;
		private IMultiSaveLayout	currMSLayout = null;  //현재활성화된 Multi저장Layout
		private IMultiQueryLayout	currMQLayout = null;  //현재활성화된 Multi조회Layout
		private IFunctionPerformer  functionPerformer = null; //화면의 기능을 수행하는 수행자 Control(XButtonList)
		private IPrintWorker printWorker = null;
		private bool autoCheckInputLayoutChanged = false; //닫기전에 자동으로 InputLayout(Grid)의 변경사항을 Check할지 여부
		//Master-Detail 관계에서는 여러개의 Layout이 한꺼번에 저장되어야 하므로 처리해야함.
		private ArrayList	saveLayoutList = new ArrayList(); //<미확정> 일단 List로 구현하고, 나중에 Collecition으로 대체하자.

		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		#endregion

		#region Base Properties
		[Browsable(false)]
		public override Color BackColor
		{
			get { return base.BackColor;}
			set { base.BackColor = value;}
		}
		[DefaultValue(typeof(XColor),"NormalForeColor"),
		Description("텍스트색을 지정합니다.")]
		public new XColor ForeColor
		{
			get { return xForeColor;}
			set 
			{
				xForeColor = value;
				base.ForeColor = value.Color;
			}
		}
		[Browsable(true), DefaultValue(typeof(Font), "MS UI Gothic, 9.75pt")]
		public override Font Font
		{
			get	{ return base.Font;	}
			set	{ base.Font = value;}
		}
		#endregion

		#region Properties
		/// <summary>
		/// 화면의 배경색을 가져오거나 설정합니다.
		/// </summary>
		[Browsable(true),
		DefaultValue(typeof(XColor), "XScreenBackColor"),
		Description("화면의 배경색을 지정합니다.")]
		public XColor BackGroundColor
		{
			get {return xBackColor;}
			set 
			{
				xBackColor = value;
				this.BackColor = xBackColor.Color;
				Invalidate(ClientRectangle);
			}
		}
		/// <summary>
		/// ScreenID를 가져옵니다.
		/// </summary>
		[Browsable(false)]
		public string ScreenID
		{
			get 
			{
				if (this.screenInfo == null)
					return "";
				else
					return this.screenInfo.PgmID;
			}
		}
		/// <summary>
		/// Screen명을 가져옵니다.
		/// </summary>
		[Browsable(false)]
		public string ScreenName
		{
			get 
			{
				if (this.screenInfo == null)
					return "";
				else
					return this.screenInfo.Title;
			}
		}
		/// <summary>
		/// Screen의 OpenStyle을 가져옵니다.
		/// </summary>
		[Browsable(false)]
		public ScreenOpenStyle OpenStyle
		{
			get 
			{
				if (this.screenInfo == null)
					return ScreenOpenStyle.PopUpFixed;
				else
					return this.screenInfo.OpenStyle;
			}
		}
		/// <summary>
		///	화면정보
		/// </summary>
		[Browsable(false), DefaultValue(null)]
		internal ScreenInfo ScreenInfo
		{
			get { return screenInfo; }
			set { screenInfo = value; }
		}
		// Container MdiForm
		[Browsable(false), DefaultValue(null)]
		internal MdiForm ContainerMdiForm
		{
			get { return containerMdiForm; }
			set { containerMdiForm = value; }
		}
		/// <summary>
		/// 화면을 포함하는 Form을 가져오거나 설정합니다.
		/// </summary>
		[Browsable(false), DefaultValue(null)]
		internal MdiChild ContainerMdiChild
		{
			get { return containerMdiChild; }
			set { containerMdiChild = value; }
		}
		/// <summary>
		/// 화면을 Open한 Object를 가져오거나 설정합니다.
		/// </summary>
		[Browsable(false), DefaultValue(null)]
		public object Opener
		{
			get { return opener; }
			set { opener = value; }
		}
		/// <summary>
		/// ScreenOpen시 전달된 Parameter를 관리하는 컬렉션입니다.
		/// </summary>
		[Browsable(false), DefaultValue(null)]
		public CommonItemCollection OpenParam
		{
			get { return openParam; }
			set { openParam = value;}
		}
		/// <summary>
		/// ScreenOpen시 전달된 OpenCommand를 관리합니다.
		/// </summary>
		[Browsable(false), DefaultValue(null)]
		public OpenCommand OpenCommand
		{
			get { return openCommand; }
			set { openCommand = value;}
		}
		[Browsable(false), DefaultValue(null)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public IMultiSaveLayout CurrMSLayout
		{
			get { return currMSLayout;}
			set { currMSLayout = value;}
		}
		[Browsable(false), DefaultValue(null)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public IMultiQueryLayout CurrMQLayout
		{
			get { return currMQLayout;}
			set { currMQLayout = value;}
		}
		[Category("추가속성"), Browsable(true),DefaultValue(null),
		Description("이 화면의 출력기능을 담당하는 Worker를 지정합니다.")]
		public IPrintWorker PrintWorker
		{
			get { return printWorker;}
			set { printWorker = value;}
		}
		[Category("추가속성"), Browsable(true),DefaultValue(false),
		Description("화면을 닫기전 MultiInputLayout의 변경사항을 확인하여 경고창을 띄울지 여부를 지정합니다.")]
		public bool AutoCheckInputLayoutChanged
		{
			get { return autoCheckInputLayoutChanged;}
			set { autoCheckInputLayoutChanged = value;}
		}
		//ILayouContainer.FunctionPerformer 속성
		//IFunctionPerformer에서 LayoutContainer를 설정시에 자신을 이 속성에 설정
		IFunctionPerformer ILayoutContainer.FunctionPerformer
		{
			get { return functionPerformer;}
			set { functionPerformer = value;}
		}
		[Browsable(false)]
		public ArrayList SaveLayoutList
		{
			get { return this.saveLayoutList;}
		}
		#endregion

		#region Events
		/// <summary>
		/// 화면이 닫히는 동안 발생하는 Event (IScreen 구현)
		/// </summary>
		[Description("화면이 닫히는 동안 화면을 닫을 수 있는지 여부를 판단하는 이벤트입니다."),
		Category("업무"),
		Browsable(true)]
		public event CancelEventHandler Closing;

		/// <summary>
		/// 사용자가 변경되었을때 발생하는 Event
		/// </summary>
		[Description("사용자가 변경되었을때 발생합니다."),
		Category("업무"),
		Browsable(true)]
		public event EventHandler UserChanged;

		[Description("화면이 활성화될때 발생합니다."),
		Category("업무"),
		Browsable(true)]
		public event EventHandler Activated;

		[Description("화면이 오픈될때 발생합니다.(메뉴Click,OpenScreen(WithParam)으로 화면오픈시에 발생)"),
		Category("업무"),
		Browsable(true)]
		public event XScreenOpenEventHandler ScreenOpen;

		/// <summary>
		/// Docking된 화면이 숨겨진 상태에서 다시 보일때 발생합니다.
		/// </summary>
		[Description("Docking된 화면이 숨겨진 상태에서 다시 보일때 발생합니다."),
		Category("업무"),
		Browsable(true)]
		public event EventHandler HiddenDockingScreenAppearing;
		#endregion

		#region Contructor
		public XScreen()
		{
			// 이 호출은 Windows.Forms Form 디자이너에 필요합니다.
			InitializeComponent();

			this.BackColor = XColor.XScreenBackColor.Color;
			this.ForeColor = XColor.NormalForeColor;

            // MED-14286
            if (NetInfo.Language == LangMode.Jr)
            {
                this.Font = new Font("MS UI Gothic", 9.75f);
            }
            else
            {
                this.Font = Service.COMMON_FONT;
            }

			//Open시 전달된 Arg Set(2006.02.27)
			OpenArg.GetOpenArg(this);
		}
		#endregion

		#region IXScreen Implimentation
		/// <summary>
		/// 특정 Command명으로 commandParam을 전달하여 명령을 실행합니다.
		/// </summary>
		/// <param name="command"> Command 명 </param>
		/// <param name="commandParam"> Argument를 관리하는 CommonItemCollection </param>
		/// <returns> object </returns>
		public virtual object Command(string command, CommonItemCollection commandParam)
		{
			//개발화면에서 Override
			return null;
		}
		#endregion

		#region Dispose
		/// <summary>
		/// 사용 중인 모든 리소스를 정리합니다.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			// ScreenList 말소
			ScreenManager.RemoveScreenList(this);

			if( disposing )
			{
				if( components != null )
					components.Dispose();
			}
			base.Dispose( disposing );
		}
		#endregion

		#region Component Designer generated code
		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다. 
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.ImageList = new System.Windows.Forms.ImageList(this.components);
			// 
			// ImageList
			// 
			this.ImageList.ImageSize = new System.Drawing.Size(16, 16);
			this.ImageList.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// XScreen
			// 
			this.CausesValidation = false;
			this.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Name = "XScreen";
			this.Size = new System.Drawing.Size(960, 590);

		}
		#endregion

		#region OnLoad
		protected override void OnPaint(PaintEventArgs e)
		{
			//BackColor SET
			if (BackColor != xBackColor.Color)
				BackColor = xBackColor.Color;
			base.OnPaint(e);
		}
		/// <summary>
		/// Load시 처리
		/// </summary>
		/// <param name="e"></param>
		protected override void OnLoad(EventArgs e)
		{
			try
			{
				base.OnLoad(e);
			
			
				// ScreenList 등록
				ScreenManager.AddScreenList(this);

				//ScreenOpen Event 발생
				XScreenOpenEventArgs xe = new XScreenOpenEventArgs(this.openParam);
				xe.OpenCommand = this.openCommand;
				OnScreenOpen(xe);

				if (!this.DesignMode)
				{
					// 화면 Open시 TabIndex가 가장 먼저인 Control에 Focus
					Control firstControl = GetFistTabIndexControl(this);
					if (firstControl != null)
						firstControl.Focus();
				}
			}
			catch(Exception xe)
			{
				string msg = XMsg.GetMsg("M068") + "\nError[" + xe.Message + "]"; //"화면 Load시 에러가 발생했습니다.\r\n" + "Error[" + xe.Message + "]"
				// TODO: for DEMO version
                //화면로드
                /*XMessageBox.Show(msg, XMsg.GetMsg("M069"));*/
			}
		}
		/// <summary>
		/// TabIndex가 가장 빠른 Control Return
		/// </summary>
		/// <param name="parent"></param>
		/// <returns></returns>
		internal Control GetFistTabIndexControl(Control parent)
		{
			if (parent == null) return null;
			if (parent.Controls == null) return null;

			int	minIndex = int.MaxValue;
			Control	firstControl = null;
			foreach (Control ctl in parent.Controls)
			{
				if ((ctl.Enabled && ctl.Visible) &&	(ctl.TabStop || (ctl.Controls.Count > 0)))
				{
					if (ctl.TabIndex < minIndex)
					{
						minIndex = ctl.TabIndex;
						firstControl = ctl;
					}
				}
			}
			if (firstControl == null)
				return null;
			if (firstControl.Controls != null)
			{
				if (firstControl.Controls.Count > 0)
					return GetFistTabIndexControl(firstControl);
				else
					return firstControl;
			}
			else
				return firstControl;
		}
		#endregion

		#region CanClose
		/// <summary>
		/// 화면이 닫히는 조건 검사
		/// </summary>
		/// <returns></returns>
		public bool CanClose()
		{
			//2005.09.21 AutoCheckInputLayoutChanged 반영
			if (this.AutoCheckInputLayoutChanged)
			{
				
				int changedCount = 0;
				CheckMultiInputLayoutChanged(this, ref changedCount);
				if (changedCount > 0)
				{
					string msg = XMsg.GetMsg("M070") + "\n" + XMsg.GetMsg("M071"); // 변경된 내역이 있습니다.\n 저장후 닫으시겠습니까?"
					string title = XMsg.GetMsg("M070"); // 변경내역 확인
					DialogResult result = XMessageBox.Show(msg, title, MessageBoxButtons.YesNoCancel);
					if (result == DialogResult.Cancel)
						return false; // 닫지 않음
					else if (result == DialogResult.Yes)
					{
						if (this.functionPerformer != null)
						{
							this.functionPerformer.PerformFunction(FunctionType.Update);
							//2005.10.07 저장기능수행이 실패하였으면 닫지 못함
							if (!this.functionPerformer.IsFunctionSuccess) 
								return false;
						}
					}
				}
			}
			//2006.01.09 메인화면 Close 불가 추가
			if ((this.screenInfo != null) && screenInfo.IsMainScreen)
			{
				string msg = XMsg.GetMsg("M073"); // 메인화면은 닫을 수 없습니다.
				if (EnvironInfo.MdiForm != null)
					EnvironInfo.MdiForm.SetMsg(msg, MsgType.Error);
				return false;
			}
			CancelEventArgs e = new CancelEventArgs(false);
			OnClosing(e);
			return !e.Cancel;
		}
		/// <summary>
		/// IMultiSaveLayout의 변경된 건수 GET
		/// </summary>
		/// <param name="parent"></param>
		/// <param name="count"></param>
		private void CheckMultiInputLayoutChanged(Control parent, ref int count)
		{
			foreach (Control cont in parent.Controls)
			{
				//if ((cont is IMultiSaveLayout) && (((IMultiSaveLayout) cont).GetChangedRowCount() > 0))
				if (cont is IMultiSaveLayout)
					count += ((IMultiSaveLayout) cont).GetChangedRowCount();
				else if ((cont.Controls != null) && (cont.Controls.Count > 0))
					CheckMultiInputLayoutChanged(cont, ref count);
			}
		}
		#endregion

		#region Event Invoker
		/// <summary>
		/// 화면 닫히기 전 Closing Event를 발생시킨다.
		/// </summary>
		/// <param name="e"></param>
		protected virtual void OnClosing(CancelEventArgs e)
		{
			if (Closing != null)
				Closing(this, e);
		}
		/// <summary>
		/// 사용자 변경시 UserChanged Event를 발생시킵니다.
		/// MdiForm에서 Call하기 위해 Internal로 선언함
		/// </summary>
		internal void OnUserChanged()
		{
			if (this.UserChanged != null)
				UserChanged(this, EventArgs.Empty);
		}
		/// <summary>
		/// 화면이 새로 열리거나 열려있는 화면을 OpenScreen할때 ScreenOpen Event를 발생시킵니다.
		/// Invoker는 Protected가 아니라 내부에서만 사용(MdiForm에서 Call)
		/// </summary>
		/// <param name="e"></param>
		internal void OnScreenOpen(XScreenOpenEventArgs e)
		{
			if (this.ScreenOpen != null)
				ScreenOpen(this, e);
		}
		/// <summary>
		/// 화면이 활성화 될때 Activated Event를 발생시킵니다.
		/// Invoker는 Protected가 아니라 내부에서만 사용(MdiForm에서 Call)
		/// </summary>
		/// <param name="e"></param>
		internal void OnActivated(EventArgs e)
		{
			if (Activated != null)
				Activated(this, e);
		}
		/// <summary>
		/// Docking된 화면이 숨겨진 상태에서 다시 보일때 발생합니다.
		/// Invoker는 Protected가 아니라 내부에서만 사용(MdiForm에서 Call)
		/// </summary>
		/// <param name="e"></param>
		internal void OnHiddenDockingScreenAppearing(EventArgs e)
		{
			if (HiddenDockingScreenAppearing != null)
				HiddenDockingScreenAppearing(this, e);
		}
		#endregion
		
		#region Message 관련 Methods
		/// <summary>
		/// Message 를 Display합니다.
		/// </summary>
		/// <param name="msg"></param>
		/// <param name="msgType"></param>
		public virtual void SetMsg(string msg, MsgType msgType)
		{
			//Mdi창의 StatusBar에 Message Display
			if (containerMdiForm != null)
			{
				containerMdiForm.SetMsg(msg, msgType);
			}
		}

		/// <summary>
		/// Message 를 Display합니다.
		/// </summary>
		/// <param name="msg"></param>
		public virtual void SetMsg(string msg)
		{
			SetMsg(msg, MsgType.Normal);
		}
		/// <summary>
		/// MdiChild의 pnlWorkTime에 값을 설정합니다.
		/// </summary>
		public virtual void SetWorkTime()
		{
			if (this.containerMdiForm != null)
				this.containerMdiForm.SetWorkTime(DateTime.Now.ToString("HH:mm:ss"));
		}
		public void SetErrMsg(string msg)
		{
			this.SetMsg(msg, MsgType.Error);
		}
		#endregion

		#region Close, HideDocking, Reset Methods
		public void Reset()
		{
			//Screen에 있는 모든 Control중 IDataControl, IMultiSaveLayout, IMultiQueryLayout Reset
			ResetSub(this);
		}
		protected void ResetSub(Control parent)
		{
			//2006.05.08 Reset시 ApplyLayoutContainerReset 속성에 따라 true이면 Reset, false이면 Reset하지 않음
			foreach (Control cont in parent.Controls)
			{
				if (cont is IDataControl)
				{
					if (((IDataControl) cont).ApplyLayoutContainerReset)
						((IDataControl) cont).ResetData();
				}
				else if (cont is IMultiSaveLayout)
				{
					if (((IMultiSaveLayout) cont).ApplyLayoutContainerReset)
						((IMultiSaveLayout) cont).Reset();
				}
				else if (cont is IMultiQueryLayout)
				{
					if (((IMultiQueryLayout) cont).ApplyLayoutContainerReset)
						((IMultiQueryLayout) cont).Reset();
				}
				else if (cont is IUserObject)
				{
					if (((IUserObject) cont).ApplyLayoutContainerReset)
						((IUserObject) cont).Reset();
				}
				else if ((cont.Controls != null) && (cont.Controls.Count > 0))
					ResetSub(cont);
			}
		}
		/// <summary>
		/// Docking된 화면의 Width를 조정합니다.
		/// </summary>
		/// <param name="width"></param>
		public void ResizeDocking(int width)
		{
			if (width <= 0) return;

			if ((this.screenInfo != null) && (this.containerMdiForm != null))
				this.containerMdiForm.ResizeDockingScreen(this.screenInfo.Title, width);
		}
		/// <summary>
		/// Docking된 화면인 경우 보여진 화면을 Hide합니다.
		/// </summary>
		public void HideDocking()
		{
			if ((this.screenInfo != null) && (this.containerMdiForm != null))
				this.containerMdiForm.HideDockingScreen(this.screenInfo.Title);
		}
		/// <summary>
		/// 화면을 닫습니다.
		/// </summary>
		public void Close()
		{
			//Docking Style Open시 Docking Hide (Debugger에서 열때)
			if (this.screenInfo != null) 
			{
				if (this.screenInfo.OpenStyle == ScreenOpenStyle.Docking)
				{
					if (this.containerMdiForm != null)
					{
						//CanClose Check (화면을 닫을 수 있는지 여부 Check)
						if (!this.CanClose()) return;

						containerMdiForm.RemoveDockingScreen(this.screenInfo);
						//Docking된 화면은 Docking List에서 제거하더라도 Dispose가 안됨
						//명시적으로 Dispose 호출
						this.Dispose();
					}
				}
				else
				{
					//PopUp형태이면 PopUp창 Close
					if (this.containerMdiChild != null)
					{
						this.containerMdiChild.Close();
					}
				}
			}
		}
		#endregion

		#region AcceptData
		/// <summary>
		/// Screen에서 Active한 Control의 편집중인 데이타를 Accept합니다.
		/// </summary>
		/// <returns> 성공시 true, 실패시 false </returns>
		public bool AcceptData()
		{
			//현재 Active한 Control의 AcceptData Call
			if (this.ActiveControl != null)
			{
				if (this.ActiveControl is IDataControl)
				{
					//ActiveControl의 Parent가 ADataGrid, AEditGrid이면 Grid의 AcceptData Call
					if (this.ActiveControl.Parent != null)
					{
						if (this.ActiveControl.Parent is IMultiSaveLayout)
							return ((IMultiSaveLayout) this.ActiveControl.Parent).AcceptData();
						else
							return ((IDataControl) this.ActiveControl).AcceptData();
					}
					else
						return ((IDataControl) this.ActiveControl).AcceptData();
				}
				else if (this.ActiveControl is IMultiSaveLayout)
					return ((IMultiSaveLayout) this.ActiveControl).AcceptData();
				else
					return true;
			}
			else
				return true;
		}
		#endregion

		#region Activate
		public void Activate()
		{
			//해당 화면 활성화
			if (this.containerMdiForm != null)
			{
				this.containerMdiForm.Activate();
				this.containerMdiForm.ActivateScreen(this.screenInfo);
			}
		}
		#endregion

		#region ProcessDialogKey override
		protected override bool ProcessDialogKey(Keys keyData)
		{
			bool ret = base.ProcessDialogKey (keyData);
			//기능을 수행할 FunctionPerformer가 없으면 return
			if (this.functionPerformer == null) return ret;

			Keys keyCode = (Keys)(((int)keyData << 16) >> 16);		// Modifier Clear
			switch (keyCode)
			{
				case Keys.F5:  //조회
					functionPerformer.PerformFunction(FunctionType.Query);
					break;
				case Keys.F7:  //입력
					functionPerformer.PerformFunction(FunctionType.Insert);
					break;
				case Keys.F9:  //삭제
					functionPerformer.PerformFunction(FunctionType.Delete);
					break;
				case Keys.F12:  //저장,출력,처리
					if (functionPerformer.PerformerType == FunctionPerformerType.Report)
						functionPerformer.PerformFunction(FunctionType.Print);
					else if (functionPerformer.PerformerType == FunctionPerformerType.Print)
						functionPerformer.PerformFunction(FunctionType.Print);
					else if (functionPerformer.PerformerType == FunctionPerformerType.Process)
						functionPerformer.PerformFunction(FunctionType.Process);
					else
						functionPerformer.PerformFunction(FunctionType.Update);
					break;
				case Keys.F11:
					if (functionPerformer.PerformerType == FunctionPerformerType.Print)
						functionPerformer.PerformFunction(FunctionType.Preview);
					else if (functionPerformer.PerformerType == FunctionPerformerType.Process)
						functionPerformer.PerformFunction(FunctionType.Cancel);
					break;
				case Keys.F3:  //초기화
					functionPerformer.PerformFunction(FunctionType.Reset);
					break;
			}
			return ret;
		}
		#endregion

		#region	 OnRequestBunHo, OnReceiveBunHo
		/// <summary>
		/// 환자정보를 관리하는 화면에서 개발자가 Override하여 환자정보가 담긴 XPatientInfo을 반환한다.
		/// static XScreen.GetOtherScreenBunHo(), GetPreviousScreenBunHo에서 현재 열려있는 화면의 OnRequestBunHo()를 Call하여 각화면에 있는
		/// APatientInfo을 Get하여 여러환자가 있으면 선택할 수 있도록 함
		/// </summary>
		/// <returns></returns>
		public virtual XPatientInfo OnRequestBunHo()
		{
			return null;
		}
		/// <summary>
		/// 환자리스트에서 환자를 선택하여 화면에 환자정보를 보낼때 수신하는 Method
		/// 환자정보를 받을때 화면에서 받은 환자정보를 가지고 추가처리
		/// </summary>
		/// <param name="info"></param>
		public virtual void OnReceiveBunHo(XPatientInfo info)
		{
		}
		#endregion

		#region OpenScreen Method
		public static IXScreen OpenScreen(object opener, string screenID, ScreenOpenStyle openStyle, ScreenAlignment screenAlign)
		{
			return ScreenManager.OpenScreen(opener, screenID, openStyle, screenAlign);
		}
		public static IXScreen OpenScreen(object opener, string screenID, ScreenOpenStyle openStyle)
		{
			return ScreenManager.OpenScreen(opener, screenID, openStyle, ScreenAlignment.Default);
		}
		public static IXScreen OpenScreenWithParam(object opener, string systemID, string screenID, ScreenOpenStyle openStyle, CommonItemCollection openParam)
		{
			return ScreenManager.OpenScreenWithParam(opener, systemID, screenID, openStyle, ScreenAlignment.Default, openParam);
		}
		public static IXScreen OpenScreenWithParam(object opener, string systemID, string screenID, ScreenOpenStyle openStyle, ScreenAlignment screenAlign, CommonItemCollection openParam)
		{
			return ScreenManager.OpenScreenWithParam(opener, systemID, screenID, openStyle, screenAlign, openParam);
		}
		public static IXScreen OpenScreenWithCommand(object opener, string screenID, ScreenOpenStyle openStyle, OpenCommand openCommand)
		{
			return ScreenManager.OpenScreenWithCommand(opener, screenID, openStyle, ScreenAlignment.Default, openCommand);
		}
		public static IXScreen OpenScreenWithCommand(object opener, string screenID, ScreenOpenStyle openStyle, ScreenAlignment screenAlign, OpenCommand openCommand)
		{
			return ScreenManager.OpenScreenWithCommand(opener, screenID, openStyle, screenAlign, openCommand);
		}
		#endregion

		#region GetOtherScreenBunHo, GetPreviousScreenBunHo Method
		/// <summary>
		/// 이전에 활성화된 화면의 PAID 가져오기
		/// </summary>
		/// <param name="autoSelect"></param>
		/// <returns></returns>
		public static XPatientInfo GetCurrentScreenBunHo(bool autoSelect)
		{
			/* 환자정보 찾기 순서
			 * 1.현재화면의 OnRequestMyPatient Call
			 * autoSelect이면 바로 Return, 아니면 선택창 보여줌
			 */
			try
			{
				if (XScreen.CurrentScreen == null) return null;

				XPatientInfo info = XScreen.CurrentScreen.OnRequestBunHo();
				
				//환자ID없는데 보내는 경우가 많음 info.ID Check필요함
                if ((info != null) && (info.BunHo.Trim() != ""))
                {
                    if (autoSelect)
                        return info;
                    else
                    {
                        XListMsgBoxColumnCollection columns = new XListMsgBoxColumnCollection();
                        string text = XMsg.GetField("F047"); // 환자번호
                        columns.Add("bunHo", text, 80);
                        text = XMsg.GetField("F048"); // 이 름
                        columns.Add("suName", text, 80);
                        columns.Add("gwa", "", 0);  //진료과 보여주지 않음
                        columns.Add("hoDong", "", 0);  //병동 보여주지 않음
                        text = XMsg.GetField("F049"); // 화 면 명
                        columns.Add("screenName", text, 160);
                        DataTable table = new DataTable();
                        table.Columns.Add("bunHo", typeof(string));
                        table.Columns.Add("suName", typeof(string));
                        table.Columns.Add("gwa", typeof(string));
                        table.Columns.Add("hoDong", typeof(string));
                        table.Columns.Add("pk", typeof(string));
                        table.Columns.Add("pkGubun", typeof(string));
                        table.Columns.Add("screenName", typeof(string));
                        DataRow dtRow = table.NewRow();
                        dtRow[0] = info.BunHo;
                        dtRow[1] = info.SuName;
                        dtRow[2] = info.Gwa;
                        dtRow[3] = info.HoDong;
                        dtRow[4] = info.PK;
                        dtRow[5] = info.PKGubun.ToString();
                        dtRow[6] = info.ScreenName;
                        table.Rows.Add(dtRow);
                        table.AcceptChanges();
                        text = XMsg.GetField("F050"); // 환 자 번 호 선 택
                        if (XListMsgBox.Show(text, columns, table) != DialogResult.OK) return null;

                        dtRow = (DataRow)XListMsgBox.SelectedList[0];
                        //선택된 환자정보 Return
                        return new XPatientInfo(dtRow[0].ToString(), dtRow[1].ToString(), dtRow[2].ToString(), dtRow[3].ToString(),
                            dtRow[4].ToString(), (PatientPKGubun)Enum.Parse(typeof(PatientPKGubun), dtRow[5].ToString()), dtRow[6].ToString());
                    }
                }
				return null;
			}
			catch
			{
				return null;
			}
		}
		/// <summary>
		/// 이전에 활성화된 화면의 PAID 가져오기
		/// </summary>
		/// <param name="autoSelect"></param>
		/// <returns></returns>
		public static XPatientInfo GetPreviousScreenBunHo(bool autoSelect)
		{
            //mins test 2011.03.10
            //return null;

			/* 환자정보 찾기 순서
			 * 1.이전화면의 TabpageIndex로 해당화면 GET
			 * 2.해당화면이 있으면 OnRequestMyPatient Call
			 * autoSelect이면 바로 Return, 아니면 선택창 보여줌
			 */
            try
            {
                if (EnvironInfo.MdiForm == null) return null;

                //이전화면의 Index로 해당 Index에 있던 화면 GET
                XScreen prevScreen = EnvironInfo.MdiForm.GetScreenByTabPageIndex(XScreen.PreviousScreenIndex);
                if (prevScreen == null) return null;

                XPatientInfo info = prevScreen.OnRequestBunHo();

                //환자ID없는데 보내는 경우가 많음 info.ID Check필요함
                if ((info != null) && (info.BunHo.Trim() != ""))
                {
                    if (autoSelect)
                        return info;
                    else
                    {
                        XListMsgBoxColumnCollection columns = new XListMsgBoxColumnCollection();
                        string text = XMsg.GetField("F047"); // 환자번호
                        columns.Add("bunHo", text, 80);
                        text = XMsg.GetField("F048"); // 이 름
                        columns.Add("suName", text, 80);
                        columns.Add("gwa", "", 0);  //진료과 보여주지 않음
                        columns.Add("hoDong", "", 0);  //병동 보여주지 않음
                        text = XMsg.GetField("F049"); // 화 면 명
                        columns.Add("screenName", text, 160);
                        DataTable table = new DataTable();
                        table.Columns.Add("bunHo", typeof(string));
                        table.Columns.Add("suName", typeof(string));
                        table.Columns.Add("gwa", typeof(string));
                        table.Columns.Add("hoDong", typeof(string));
                        table.Columns.Add("pk", typeof(string));
                        table.Columns.Add("pkGubun", typeof(string));
                        table.Columns.Add("screenName", typeof(string));
                        DataRow dtRow = table.NewRow();
                        dtRow[0] = info.BunHo;
                        dtRow[1] = info.SuName;
                        dtRow[2] = info.Gwa;
                        dtRow[3] = info.HoDong;
                        dtRow[4] = info.PK;
                        dtRow[5] = info.PKGubun.ToString();
                        dtRow[6] = info.ScreenName;
                        table.Rows.Add(dtRow);
                        table.AcceptChanges();
                        text = XMsg.GetField("F050"); // 환 자 번 호 선 택
                        if (XListMsgBox.Show(text, columns, table) != DialogResult.OK) return null;

                        dtRow = (DataRow)XListMsgBox.SelectedList[0];
                        //선택된 환자정보 Return
                        return new XPatientInfo(dtRow[0].ToString(), dtRow[1].ToString(), dtRow[2].ToString(), dtRow[3].ToString(),
                            dtRow[4].ToString(), (PatientPKGubun)Enum.Parse(typeof(PatientPKGubun), dtRow[5].ToString()), dtRow[6].ToString());
                    }
                }
                return null;
            }
            catch
            {
                return null;
            }
		}
    	public static XPatientInfo GetOtherScreenBunHo(object caller, bool autoSelect)
		{
            //mins test 2011.03.10
            //return null;

			/* 환자정보 찾기 순서
			 * 1.현재 열려있는 화면의 환자정보를 모두 가져온다.
			 */
            try
            {
                //현재 열려있는 화면의 OnRequestMyPatient Method Call하여 환자List 구성
                //단 caller가 AScreen일때는 caller는 제외함
                XPatientInfo info = null;
                XScreen callerScreen = caller as XScreen;
                ArrayList infoList = new ArrayList();

                //열려있는 화면에서 환자정보 GET (Caller와 다른 화면에서만 가져옴)
                foreach (XScreen screen in ScreenManager.OpenScreenList)
                {
                    info = null;

                    //OpenStyle이 Popup인 경우의 화면만 환자리스트를 가져온다.
                    if ((screen.screenInfo != null) &&
                        ((screen.OpenStyle == ScreenOpenStyle.PopUpFixed) || (screen.OpenStyle == ScreenOpenStyle.PopUpSizable)))
                    {
                        if (callerScreen != null)
                        {
                            if (!callerScreen.Equals(screen))
                                info = screen.OnRequestBunHo();
                        }
                        else
                            info = screen.OnRequestBunHo();
                    }

                    //List에 Add  환자ID가 없는데 Check하지 않고 보내는 경우가 많음("" Check)
                    //동일한 ID일때 추가여부는 업무확정후 반영함
                    if ((info != null) && (info.BunHo.Trim() != ""))
                        infoList.Add(info);
                }
                if (infoList.Count < 1) return null;

                //리스트가 2개이상이거나, 한개이더라도 autoSelect = false이면 List를 보여줌
                if (!autoSelect || (infoList.Count > 1))
                {
                    XListMsgBoxColumnCollection columns = new XListMsgBoxColumnCollection();
                    string text = XMsg.GetField("F047"); // 환자번호
                    columns.Add("bunHo", text, 80);
                    text = XMsg.GetField("F048"); // 이 름
                    columns.Add("suName", text, 80);
                    columns.Add("gwa", "", 0);  //진료과 보여주지 않음
                    columns.Add("hoDong", "", 0);  //병동 보여주지 않음
                    text = XMsg.GetField("F049"); // 화 면 명
                    columns.Add("screenName", text, 160);
                    DataTable table = new DataTable();
                    table.Columns.Add("bunHo", typeof(string));
                    table.Columns.Add("suName", typeof(string));
                    table.Columns.Add("gwa", typeof(string));
                    table.Columns.Add("hoDong", typeof(string));
                    table.Columns.Add("pk", typeof(string));
                    table.Columns.Add("pkGubun", typeof(string));
                    table.Columns.Add("screenName", typeof(string));
                    DataRow dtRow = null;
                    foreach (XPatientInfo pInfo in infoList)
                    {
                        dtRow = table.NewRow();
                        dtRow[0] = pInfo.BunHo;
                        dtRow[1] = pInfo.SuName;
                        dtRow[2] = pInfo.Gwa;
                        dtRow[3] = pInfo.HoDong;
                        dtRow[4] = pInfo.PK;
                        dtRow[5] = pInfo.PKGubun.ToString();
                        dtRow[6] = pInfo.ScreenName;
                        table.Rows.Add(dtRow);
                    }
                    table.AcceptChanges();
                    text = XMsg.GetField("F050"); // 환 자 번 호 선 택
                    if (XListMsgBox.Show(text, columns, table) != DialogResult.OK) return null;

                    dtRow = (DataRow)XListMsgBox.SelectedList[0];
                    //선택된 환자정보 Return
                    //선택된 환자정보 Return
                    return new XPatientInfo(dtRow[0].ToString(), dtRow[1].ToString(), dtRow[2].ToString(), dtRow[3].ToString(),
                        dtRow[4].ToString(), (PatientPKGubun)Enum.Parse(typeof(PatientPKGubun), dtRow[5].ToString()), dtRow[6].ToString());
                }
                else
                    return (XPatientInfo)infoList[0];  //자동선택이면 리스트의 첫번째 환자정보 Return
            }
            catch
            {
                return null;
            }
		}
		#endregion

		#region 기타 static Methods
		/// <summary>
		/// 화면 ID로 Open된 화면을 찾습니다.
		/// </summary>
		/// <param name="screenID"> 화면 ID </param>
		/// <returns></returns>
		public static IXScreen FindScreen(string systemID, string screenID)
		{
			return ScreenManager.FindScreen(screenID);
		}
		/// <summary>
		/// 사용자 변경 Call
		/// </summary>
		/// <param name="userID"></param>
		/// <param name="isEditableUserID"></param>
		/// <returns></returns>
		public static DialogResult ChangeUser(string userID, bool isEditableUserID)
		{
			//사용자 변경 Method Call
			if (EnvironInfo.MdiForm != null)
				return EnvironInfo.MdiForm.ChangeUser(userID, isEditableUserID);
			return DialogResult.Cancel;
		}
		/// <summary>
		/// 사용자 Logout창 Call
		/// </summary>
		public static void LogoutUser()
		{
			//사용자 변경 Method Call
			if (EnvironInfo.MdiForm != null)
				EnvironInfo.MdiForm.LogoutUser();
		}
		/// <summary>
		/// 화면잠금 처리
		/// </summary>
		public static void LockupScreen()
		{
			//화면잠금 Method Call
			if (EnvironInfo.MdiForm != null)
				EnvironInfo.MdiForm.LockupScreen();
		}
		/// <summary>
		/// 현재활성화된 Screen으로 환자정보를 보냅니다.
		/// </summary>
		/// <param name="info"></param>
		public static void SendPatientInfo(XPatientInfo info)
		{
			if (XScreen.CurrentScreen != null)
				XScreen.CurrentScreen.OnReceiveBunHo(info);
		}
		#endregion

		#region SetServiceMsg (서비스의 종류에 따른 기본 Msg 설정)
		public void SetServiceMsg(ServiceType svcType, ServiceMsgType msgType)
		{
			string msg = "";
			switch (msgType)
			{
				case ServiceMsgType.Normal :
				switch (svcType)
				{
					case ServiceType.Entry :
						msg = XMsg.GetMsg("M049"); //처리가 완료되었습니다.
						break;
					case ServiceType.Query :
						msg = XMsg.GetMsg("M050"); // 조회가 완료되었습니다
					break;
				}
					break;
				case ServiceMsgType.NoData :
				switch (svcType)
				{
					case ServiceType.Entry :
						msg = XMsg.GetMsg("M051"); //처리할 대상이 없습니다...
						break;
					case ServiceType.Query :
						msg = XMsg.GetMsg("M052"); // 조회할 내역이 없습니다.
						break;
					case ServiceType.Validation :
						msg = XMsg.GetMsg("M053"); //자료를 찾을 수 없습니다.
						break;
				}
					break;

				case ServiceMsgType.Processing :
				switch (svcType)
				{
					case ServiceType.Entry :
						msg = XMsg.GetMsg("M054"); //처리 중입니다...
						break;
					case ServiceType.Query :
						msg = XMsg.GetMsg("M055"); //조회 중입니다...
						break;
				}
					break;

				case ServiceMsgType.ContQry :
				switch (svcType)
				{
					case ServiceType.Query :
						msg = XMsg.GetMsg("M056"); //조회가 계속됩니다...
						break;
				}
					break;
			}
			this.SetMsg(msg);
		}
		#endregion
	}

	#region XScreenOpenEventHandler
	/// <summary>
	/// 화면을 Open했을때 발생하는 이벤트 입니다.
	/// MenuClick 또는 OpenScreen(WithParam) Method에 화면이 열릴때 처음 화면 Open시는 XScreen의 OnLoad에서 발생
	/// 중복Open불가시 활성화만 시킬때는 FormMdiParent::OpenNewScreen에서 발생
	/// </summary>
	[Serializable]
	public delegate void XScreenOpenEventHandler(object sender, XScreenOpenEventArgs e);
	
	/// <summary>
	/// 화면을 Open했을때 발생하는 이벤트 입니다.
	/// </summary>
	public class XScreenOpenEventArgs : EventArgs
	{
		CommonItemCollection	openParam = null;
		OpenCommand				openCommand = null;
		/// <summary>
		/// 화면 Open시에 전달된 OpenParameter 객체
		/// </summary>
		public CommonItemCollection OpenParam
		{
			get { return openParam; }
		}
		//화면 Open시 전달된 Command 객체
		public OpenCommand OpenCommand
		{
			get { return openCommand;}
			set { openCommand = value;}
		}
		public XScreenOpenEventArgs(CommonItemCollection openParam)
		{
			this.openParam = openParam;
		}
		public XScreenOpenEventArgs(OpenCommand openCommand)
		{
			this.openCommand = openCommand;
		}
	}
	#endregion

	#region XPatientInfo class
	public enum PatientPKGubun  //환자번호 PK 구분 (None.PK없음, In.입원, Out.외래)
	{
		None,  //PK
		In,    //입원환자 PK
		Out    //외래환자 PK
	}
	public class XPatientInfo
	{
		private string bunHo = "";  //환자번호
		private string suName = ""; //환자명(한자)
		private string gwa = ""; //부서코드(진료과)
		private string hoDong = ""; //병동
		private string pk = "";  //환자번호 KEY
		private PatientPKGubun  pkGubun = PatientPKGubun.None;
		private string screenName = ""; //화면명
		public string BunHo
		{
			get { return bunHo;}
		}
		public string SuName
		{
			get { return suName;}
		}
		public string Gwa
		{
			get { return gwa;}
		}
		public string HoDong
		{
			get { return hoDong;}
		}
		public string ScreenName
		{
			get { return screenName;}
		}
		public string PK
		{
			get { return pk;}
		}
		public PatientPKGubun PKGubun
		{
			get { return pkGubun;}
		}
		public XPatientInfo(string bunHo, string suName, string gwa, string hoDong, string screenName)
		{
			this.bunHo = bunHo ;
			this.suName = suName;
			this.gwa = gwa;
			this.hoDong = hoDong;
			this.screenName = screenName;
		}
		public XPatientInfo(string bunHo, string suName, string gwa, string hoDong, string pk, PatientPKGubun pkGubun, string screenName)
			: this(bunHo, suName, gwa, hoDong, screenName)
		{
			this.pk = pk;
			this.pkGubun = pkGubun;
		}
	}
	#endregion

	#region OpenArg (화면 Open시 전달되는 Argument 관리 class)
	/// <summary>
	/// OpenArg에 대한 요약 설명입니다.
	/// 화면 Open시 전달되는 Argument를 관리하는 static Class
	/// </summary>
	internal class OpenArg
	{
		private static object opener = null;  //화면 Opener
		private static ScreenInfo screenInfo = null;  //화면 정보
		private static CommonItemCollection openParam = null;
		private static OpenCommand openCommand = null;
		
		//ScreenLoader에서 해당 객체 생성전에 SET
		public static void SetOpenArg(object opener, ScreenInfo screenInfo, CommonItemCollection openParam, OpenCommand openCommand)
		{
			OpenArg.opener = opener;
			OpenArg.screenInfo = screenInfo;
			OpenArg.openParam = openParam;
			OpenArg.openCommand = openCommand;
		}
		//XScreen의 생성자에서 생성되는 화면 자신을 넘겨서 화면의 정보 SET
		public static void GetOpenArg(XScreen screen)
		{
			screen.Opener = OpenArg.opener;
			screen.ScreenInfo = OpenArg.screenInfo;
			screen.OpenParam = OpenArg.openParam;
			screen.OpenCommand = OpenArg.openCommand;
		}
		//ScreenLoader에서 객체 생성후 호출 (Clear)
		public static void ResetOpenArg()
		{
			OpenArg.opener = null;
			OpenArg.screenInfo = null;
			OpenArg.openParam = null;
			OpenArg.openCommand = null;
		}
	}
	#endregion

}
