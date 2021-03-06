using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace IHIS.Framework
{
	/// <summary>
	/// XForm에 대한 요약 설명입니다.
	/// </summary>
	public class XForm : System.Windows.Forms.Form, IHIS.Framework.ILayoutContainer
	{
		#region Base Properties
		[Browsable(true), DefaultValue(typeof(Font), "MS UI Gothic, 9.75pt")]
		public override Font Font
		{
			get	{ return base.Font;	}
			set	{ base.Font = value;}
		}
		[Browsable(false)]
		public override Color BackColor
		{
			get { return base.BackColor;}
			set { base.BackColor = value;}
		}
		private XColor xBackColor = XColor.XFormBackColor;
		[Browsable(true),
		DefaultValue(typeof(XColor), "XFormBackColor"),
		Description("폼의 배경색을 지정합니다.")]
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
		#endregion

		#region ILayoutContainer Properties
		//Master-Detail 관계에서는 여러개의 Layout이 한꺼번에 저장되어야 하므로 처리해야함.
		private ArrayList	saveLayoutList = new ArrayList(); //<미확정> 일단 List로 구현하고, 나중에 Collecition으로 대체하자.
		[Browsable(false)]
		public ArrayList SaveLayoutList
		{
			get { return this.saveLayoutList;}
		}
		#endregion

		private System.Windows.Forms.StatusBar statusBar;
		private System.Windows.Forms.StatusBarPanel pnlMessage;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public XForm()
		{
			//
			// Windows Form 디자이너 지원에 필요합니다.
			//
			InitializeComponent();

			//Font는 MS UI Gothic
			this.Font = new Font("MS UI Gothic", 9.75f);
			this.BackColor = XColor.XFormBackColor.Color;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(XForm));
			this.statusBar = new System.Windows.Forms.StatusBar();
			this.pnlMessage = new System.Windows.Forms.StatusBarPanel();
			((System.ComponentModel.ISupportInitialize)(this.pnlMessage)).BeginInit();
			this.SuspendLayout();
			// 
			// statusBar
			// 
			this.statusBar.Location = new System.Drawing.Point(0, 416);
			this.statusBar.Name = "statusBar";
			this.statusBar.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
																						 this.pnlMessage});
			this.statusBar.ShowPanels = true;
			this.statusBar.Size = new System.Drawing.Size(624, 22);
			this.statusBar.SizingGrip = false;
			this.statusBar.TabIndex = 0;
			this.statusBar.DrawItem += new System.Windows.Forms.StatusBarDrawItemEventHandler(this.statusBar_DrawItem);
			// 
			// pnlMessage
			// 
			this.pnlMessage.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
			this.pnlMessage.Width = 624;
			// 
			// XForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
			this.ClientSize = new System.Drawing.Size(624, 438);
			this.Controls.Add(this.statusBar);
			this.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "XForm";
			this.ShowInTaskbar = false;
			((System.ComponentModel.ISupportInitialize)(this.pnlMessage)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region ILayoutCOntainer Implemetation
		private IMultiSaveLayout	currMSLayout = null;  //현재활성화된 Multi저장 Layout
		private IMultiQueryLayout	currMQLayout = null;  //현재활성화된 Multi조회 Layout
		private IFunctionPerformer  functionPerformer = null; //화면의 기능을 수행하는 수행자 Control(XButtonList)
		private IPrintWorker	printWorker = null;
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
		//ILayouContainer.FunctionPerformer 속성
		//IFunctionPerformer에서 LayoutContainer를 설정시에 자신을 이 속성에 설정
		IFunctionPerformer ILayoutContainer.FunctionPerformer
		{
			get { return functionPerformer;}
			set { functionPerformer = value;}
		}
		public virtual void SetMsg(string msg, MsgType msgType)
		{
			pnlMessage.Text = msg;
			switch (msgType)
			{
				case MsgType.Normal :
					if (pnlMessage.Style != StatusBarPanelStyle.Text)
						pnlMessage.Style = StatusBarPanelStyle.Text;
					break;
				case MsgType.Error :
					if (pnlMessage.Style != StatusBarPanelStyle.OwnerDraw)
						pnlMessage.Style = StatusBarPanelStyle.OwnerDraw;
					break;
			}
			this.statusBar.Refresh();
		}
		/// <summary>
		/// Message 를 Display합니다.
		/// </summary>
		/// <param name="msg"></param>
		public virtual void SetMsg(string msg)
		{
			SetMsg(msg, MsgType.Normal);
		}
		private void statusBar_DrawItem(object sender, System.Windows.Forms.StatusBarDrawItemEventArgs sbdevent)
		{
			if (sbdevent.Panel == pnlMessage)
				if (pnlMessage.Style == StatusBarPanelStyle.OwnerDraw)
				{
					sbdevent.Graphics.DrawString(pnlMessage.Text,
						new Font(statusBar.Font, FontStyle.Bold),
						new SolidBrush(XColor.ErrMsgForeColor.Color),
						new Rectangle(sbdevent.Bounds.X + 2, sbdevent.Bounds.Y + 2,
						sbdevent.Bounds.Width - 2, sbdevent.Bounds.Height - 2));
				}
		}
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
		public void SetErrMsg(string msg)
		{
			this.SetMsg(msg, MsgType.Error);
		}
		#endregion

		#region ProcessDialogKey (단축키 처리하기)
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

		#region Command
		/// <summary>
		/// 특정 Command명으로 commandParam을 전달하여 명령을 실행합니다.
		/// </summary>
		/// <param name="command"> Command 명 </param>
		/// <param name="commandParam"> Argument를 관리하는 CommonItemCollection </param>
		/// <returns> object </returns>
		public virtual object Command(string command, CommonItemCollection commandParam)
		{
			//개발XForm에서 Override
			return null;
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
}
