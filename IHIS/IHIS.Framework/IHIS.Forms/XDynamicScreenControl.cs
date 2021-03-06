using System;
using System.IO;
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

namespace IHIS.Framework
{
	/// <summary>
	/// XDynamicScreenControl에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class XDynamicScreenControl : System.Windows.Forms.UserControl, ISupportInitialize
	{
		#region Fields
		private string screenID = "";  
		private IXScreen dynScreen = null;  //Screen Control에 붙어 있는 화면
		#endregion

		#region Properties
		[Browsable(true), Category("추가속성"),
		DefaultValue(""),
		Description("화면의 ID를 설정합니다.")]
		public string ScreenID
		{
			get { return screenID;}
			set { screenID = value;}
		}
		#endregion

		#region base Properties
		[Browsable(false)]
		public override Color BackColor
		{
			get { return base.BackColor;}
			set { base.BackColor = value;}
		}
		[Browsable(false)]
		public override Color ForeColor
		{
			get { return base.BackColor;}
			set { base.BackColor = value;}
		}
		#endregion

		private System.Windows.Forms.Panel pnlFill;
		/// <summary> 
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public XDynamicScreenControl()
		{
			// 이 호출은 Windows.Forms Form 디자이너에 필요합니다.
			InitializeComponent();
			//Color Set
			this.BackColor = XColor.XScreenBackColor.Color;

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

		#region 구성 요소 디자이너에서 생성한 코드
		/// <summary> 
		/// 디자이너 지원에 필요한 메서드입니다. 
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(XDynamicScreenControl));
			this.pnlFill = new System.Windows.Forms.Panel();
			this.SuspendLayout();
			// 
			// pnlFill
			// 
			this.pnlFill.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlFill.Location = new System.Drawing.Point(0, 0);
			this.pnlFill.Name = "pnlFill";
			this.pnlFill.Size = new System.Drawing.Size(188, 48);
			this.pnlFill.TabIndex = 0;
			// 
			// XDynamicScreenControl
			// 
			this.Controls.Add(this.pnlFill);
			this.Name = "XDynamicScreenControl";
			this.Size = new System.Drawing.Size(188, 48);
			this.ResumeLayout(false);

		}
		#endregion

		#region InitializeControl
		public void InitializeControl()
		{
			/* 1.시스템ID Check, 현재시스템과 다른 시스템이면 해당시스템 어셈블리(FWL,BGL,BSL) Download
			 * 2.지정한 Dir에 지정한 어셈블리가 있는지 확인(없으면 Return)
			 * 3.어셈블리 Load후에 지정한 className으로 Instance 생성, 단 Class의 Type이 UserControl이 아니면 불가
			 */
			if (this.DesignMode) return;  //RunTime시만 적용

			if (this.screenID == "") return;

			//지정된 시스템ID,화면ID로 화면정보 Get
			ScreenInfo screenInfo = null;
			string msg = "";
			string title = "XDynamicScreenControl";
			try
			{
				screenInfo = ScreenManager.GetScreenInfo(this.screenID);
			}
			catch
			{
				msg = XMsg.GetMsg("M045"); //화면정보를 얻는데 실패하였습니다.
				XMessageBox.Show(msg, title);
				return;
			}
			if (screenInfo == null)
			{
				msg = XMsg.GetMsg("M045"); //화면정보를 얻는데 실패하였습니다.
				XMessageBox.Show(msg, title);
				return;
			}
			
			try
			{
				//현재시스템과 다르면 Download
				if (EnvironInfo.CurrSystemID != screenInfo.PgmSystemID)
				{
					VersionResult result = DownloadFromServer(screenInfo);
					//1.서버와 버전 비교 파일 DownLoad (성공시 Local에서 Load, 실패시 계속여부 확인후 처리)
					if (result == VersionResult.DownError) //다운로드 실패
					{
						msg = XMsg.GetMsg("M026") + "\n"  //파일을 다운로드하는데 실패하였습니다.
							+ XMsg.GetMsg("M027") + "\n"  //프로그램 종료후에 다시 한번 실행해 주십시오.
							+ XMsg.GetMsg("M028");        //계속 다운로드가 실패하면 전산실로 문의하시기 바랍니다.
						XMessageBox.Show(msg, title);
						return ;
					}
					else if (result == VersionResult.DeleteFail) //기존에 있던 Dummy파일 삭제실패
					{
						// 파일 Copy실패시 어떻게 처리할 것인가 결정필요함(일단 실행불가)
						msg = XMsg.GetMsg("M029") + "\n"  //다운로드 디렉토리에 있는 파일을 삭제하지 못했습니다.
							+ XMsg.GetMsg("M027") + "\n"  //프로그램 종료후에 다시 한번 실행해 주십시오.
							+ XMsg.GetMsg("M028");        //계속 다운로드가 실패하면 전산실로 문의하시기 바랍니다.
						XMessageBox.Show(msg, title);
						return ;
					}
					else if (result == VersionResult.CopyError) //현재 Load되어서  Copy 실패시 메세지 확인
					{
						msg = XMsg.GetMsg("M030") + "\n"  //화면이 업데이트되었습니다.
							+ XMsg.GetMsg("M027") + "\n"  //프로그램 종료후에 다시 한번 실행해 주십시오.
							+ XMsg.GetMsg("M028");        //계속 다운로드가 실패하면 전산실로 문의하시기 바랍니다.
						XMessageBox.Show(msg, title);
						return ;
					}
				}
				//어셈블리이름은 시스템ID.PGM_ID
				string	asmName = screenInfo.PgmSystemID + "." + screenInfo.PgmID;

				//파일 FullName은 IFC\화면시스템ID\화면시스템ID.화면ID.dll
				string fileName = Directory.GetParent(Application.StartupPath).FullName + "\\" + screenInfo.PgmSystemID + "\\" + asmName + ".dll";
			
				//File이 존재하는지 여부 Check
				if (!File.Exists(fileName))
				{
					msg = XMsg.GetMsg("M046") + "[" + fileName + "]\n" + XMsg.GetMsg("M047"); // 파일이 존재하지 않습니다.[" + fileName + "]\n" + "전산실에 문의하시기 바랍니다."
					XMessageBox.Show(msg, title);
					return ;
				}
				//해당 어셈블리가 Loaded 되어 있는지 확인
				Assembly asm = LoadedAssembly(asmName);
				if (asm == null)
				{
					// Assembly Load
					try
					{
						asm = Assembly.LoadFrom(fileName);
					}
					catch
					{
						msg = XMsg.GetMsg("M031") + "\n" + XMsg.GetMsg("M047");  // 해당 화면을 찾을 수 없습니다.\n" + "전산실에 문의하시기 바랍니다."
						XMessageBox.Show(msg , title);
						return;
					}
				}

				//화면 생성전에 OpenArg Set (OpenParam, OpenCommand는 없음)
				OpenArg.SetOpenArg(this, screenInfo, null, null);

				//화면의 Naming은 IFC.업무시스템ID.화면ID로 정의한다.
				string	typeName = EnvironInfo.Product + "." + screenInfo.PgmSystemID + "."  + screenInfo.PgmID;

				Type classType = asm.GetType(typeName);
				if (classType == null)
				{
					msg = XMsg.GetMsg("M031") + "\n" + XMsg.GetMsg("M047");  // 해당 화면을 찾을 수 없습니다.\n" + "전산실에 문의하시기 바랍니다."
					XMessageBox.Show(msg , title);
					return;
				}
				//Instance 생성
				object obj = null;
				try
				{
					obj = Activator.CreateInstance(classType);
				}
				catch
				{
					msg = XMsg.GetMsg("M032") + "\n" + XMsg.GetMsg("M047");  //  해당 화면을 Load할 수 없습니다.\n" + "전산실에 문의하시기 바랍니다."
					XMessageBox.Show(msg , title);
					return;
				}

				//Class가 AScreen 여부
				if (!(obj is XScreen))
				{
					msg = XMsg.GetMsg("M009");  //지원되는 유형의 화면이 아닙니다.
					XMessageBox.Show(msg, title);
					return;
				}
				this.dynScreen = obj as IXScreen;

				//ContainerMdiForm, OwnerForm Set
				((XScreen)this.dynScreen).ContainerMdiForm = EnvironInfo.MdiForm;
				((XScreen)this.dynScreen).ContainerMdiChild = this.ParentForm as MdiChild;

				//pnlFill에 Control Add (Docking Fill)
				((Control) obj).Dock = DockStyle.Fill;
				this.pnlFill.Controls.Add((Control) obj);
			}
			catch(Exception xe)
			{
				msg = "XDynamicScreenControl " + XMsg.GetMsg("M048",xe); // XDynamicScreenControl 생성중에 에러가 발생했습니다.[xe.Message]
				XMessageBox.Show(msg,"XDynamicScreenControl");
			}
			finally
			{
				//OpenArg Clear
				OpenArg.ResetOpenArg();
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
		/// 초기화 종료시 지정된 화면을 초기화(InitializeControl)합니다.
		/// </summary>
		public virtual void EndInit()
		{
			this.InitializeControl();
		}
		#endregion

		#region Command
		public object Command(string command, CommonItemCollection commandParam)
		{
			if (this.dynScreen != null)
				return this.dynScreen.Command(command, commandParam);
			return null;
		}
		#endregion

		#region Private Method
		private Assembly LoadedAssembly(string asmName)
		{
			Assembly[] asms = AppDomain.CurrentDomain.GetAssemblies();

			foreach (Assembly asm in asms)
			{
				if (asm.GetName().Name.ToLower() == asmName.ToLower())
					return asm;
			}

			return null;
		}
		private VersionResult DownloadFromServer(ScreenInfo screenInfo)
		{
			//DownloadManager생성, 이때 isScreenDownload는 true
			//지정된 화면정보로 화면 및 BGL,BSL 어셈블리 다운로드
			DownloadManager loader = new DownloadManager(screenInfo);
			return loader.DownloadFiles();
		}
		#endregion
	}
}
