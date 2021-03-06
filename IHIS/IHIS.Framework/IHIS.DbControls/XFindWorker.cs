using System;
using System.Collections.Generic;
using System.Data;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Design;
using System.Globalization;
using System.Windows.Forms;

namespace IHIS.Framework
{
	#region XFindWorker
	/// <summary>
	/// XFindWorker에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(true),
	ToolboxBitmap(typeof(IHIS.Framework.XFindWorker) , "Images.XFindWorker.bmp" ),
	DefaultProperty("ColInfos"),
	DesignTimeVisible(true)]
	[Designer(typeof(XFindWorkerDesigner))]
	public class XFindWorker : System.ComponentModel.Component
	{
		#region Fields
		private FindColumnInfoCollection colInfos = new FindColumnInfoCollection();
		private bool autoQuery = true;
		private bool	serverFilter = false;  // 조회조건으로 Server에서 Filtering할지 여부
		private string  formText = "";
		private ImeMode searchImeMode = ImeMode.Hangul;
		private bool	isSetControlText = false;
		private CharacterCasing searchTextCasing = CharacterCasing.Upper;  //검색조건 TextBox의 CharacterCasing를 관리
		private BindVarCollection bindVarList = new BindVarCollection();
		private string inputSQL = "";  //조회 SQL
	    private ExecuteQueryData executeQuery;

        private List<string> paramList = new List<string>();

	    public List<string> ParamList
	    {
	        get { return paramList; }
	        set { paramList = value; }
	    }

	    public ExecuteQueryData ExecuteQuery
	    {
	        get { return executeQuery; }
	        set { executeQuery = value; }
	    }

	    #endregion

		#region Event (2007.11.08 QueryStarting Event 추가)
		[Description("조회가 시작되었을때 발생합니다.(Bind변수에 값 설정, 조건에 따른 조회여부 설정)"),
		Category("추가이벤트"),
		Browsable(true)]
		public event CancelEventHandler QueryStarting;
		#endregion

		#region Properties
		[Browsable(true),
		Category("추가속성"),
		DesignerSerializationVisibility(DesignerSerializationVisibility.Visible),
		DefaultValue(""),
		Editor(typeof(SQLEditor), typeof(UITypeEditor)),
		Description("조회 SQL을 지정합니다.")]
		public string InputSQL
		{
			get { return inputSQL; }
			set { inputSQL = value;}
		}
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content),
		Category("Find정보"),
		Description("Find창 Grid의 컬럼정보를 지정합니다."),
		Bindable(true)]
		public FindColumnInfoCollection ColInfos
		{
			get { return colInfos; }
		}
		
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
		Category("Find정보"),
		Editor(typeof(FindGridAppearanceEditor), typeof(UITypeEditor)),
		Description("Find창 Grid의 컬럼모양을 지정합니다."),
		Bindable(true)]
		public FindColumnInfoCollection ColAppearance
		{
			get { return colInfos; }
		}

		[Browsable(true),
		Category("Find정보"),
		DefaultValue(true),
		Description("창이 열릴 때 자동조회될 것인지를 설정합니다")]
		public bool AutoQuery
		{
			get { return autoQuery; }
			set { autoQuery = value; }
		}
		[Browsable(true),
		DefaultValue(false),
		Category("Find정보"),
		Description("검색조건창의 조회조건으로 Service를 Call하여 검색할지 여부를 설정합니다.")]	
		public bool ServerFilter
		{
			get { return serverFilter;}
			set { serverFilter = value;}
		}
		[Browsable(true),
		DefaultValue(""),
		Category("Find정보"),
		Description("Find창의 텍스트를 설정합니다.")]	
		public string FormText
		{
			get { return formText;}
			set { formText = value;}
		}
		[Browsable(true),
		DefaultValue(ImeMode.Hangul),
		Category("Find정보"),
		Description("Find창을 띄울때 검색 TextBox의 ImeMode를 설정합니다.")]	
		public ImeMode SearchImeMode
		{
			get { return searchImeMode;}
			set { searchImeMode = value;}
		}
		[Browsable(true),
		DefaultValue(false),
		Category("Find정보"),
		Description("Find창을 띄울때 Control에 있는 Text를 검색조건으로 설정할 것인지 여부를 관리합니다.")]	
		public bool IsSetControlText
		{
			get { return this.isSetControlText;}
			set { isSetControlText = value;}
		}
		[Browsable(true),
		DefaultValue(CharacterCasing.Upper),
		Category("Find정보"),
		Description("Find창을 띄울때 검색조건 TextBox의 CharacterCasing을 지정합니다.")]	
		public CharacterCasing SearchTextCasing
		{
			get { return searchTextCasing;}
			set { searchTextCasing = value;}
		}
		//조회조건 Bind변수관리 컬렉션
		[Browsable(false)]
		public BindVarCollection BindVarList
		{
			get { return bindVarList;}
		}
		#endregion

		#region 생성자
		public XFindWorker()
		{
		}
		#endregion

		#region OnQueryStarting (Event Invoker)
		/// <summary>
		/// QueryStarting Event 발생(Bind 변수 SET)
		/// XFindBox의 PopupFindDlg() Method에서 Call해야 하므로 Invoker를 Internal로 선언한다.
		/// </summary>
		/// <param name="e"></param>
		internal void OnQueryStarting(CancelEventArgs e)
		{
			if (this.QueryStarting != null)
				QueryStarting(this, e);
		}
		#endregion

		#region SetBindVarValue : BIND 변수 SET
		public void SetBindVarValue(string varName, string varValue)
		{
			//VarName이 정확하면 VarValue SET
			BindVar bVar = this.bindVarList[varName];
			if (bVar != null)
				bVar.VarValue = varValue;
			else  //없으면 생성하여 SET
			{
				this.bindVarList.Add(varName, varValue);
			}
		}
		#endregion

	}
	#endregion

	#region XFindWorkerDesigner
	internal class XFindWorkerDesigner : System.ComponentModel.Design.ComponentDesigner
	{
		private XFindWorker findWorker = null;
		private ISelectionService iSvc;
		private IComponentChangeService iComp;
		private IDesignerHost iHost;
		/// <summary>
		/// 디자이너를 지정된 구성 요소로 초기화합니다.
		/// </summary>
		/// <param name="component">디자이너에 연결할 IComponent</param>
		public override void Initialize(IComponent component)
		{
			base.Initialize(component);

			// Design하고있는 Control 등록
			findWorker = (XFindWorker) component;

			//Service Instance Set
			iSvc = (ISelectionService) GetService(typeof(ISelectionService));
			iComp = (IComponentChangeService) GetService(typeof(IComponentChangeService));
			iHost = (IDesignerHost) GetService(typeof(IDesignerHost));
			iComp.ComponentRemoving += new ComponentEventHandler(OnComponentRemoving);
		}

		/// <summary>
		/// 관리되지 않는 리소스를 해제하고 필요에 따라 관리되는 리소스를 해제합니다.
		/// </summary>
		/// <param name="disposing">관리되는 리소스와 관리되지 않는 리소스를 모두 해제하려면 true로 설정하고, 관리되지 않는 리소스만 해제하려면 false로 설정합니다.</param>
		protected override void Dispose(bool disposing)
		{
			// Unhook events
			iComp.ComponentRemoving -= new ComponentEventHandler(OnComponentRemoving);
			base.Dispose(disposing);
		}

		/// <summary>
		/// 디자이너가 관리하는 구성 요소와 관련된 구성 요소 컬렉션을 가져옵니다.
		/// </summary>
		public override ICollection AssociatedComponents
		{
			get 
			{ 
				//복사, 끌기 또는 이동 작업 중에 디자이너가 관리하는 구성 요소와 함께 복사 또는 이동할 구성 요소를 지정
				// XComboBoxItem을 관련 Component로 함
				return findWorker.ColInfos;
			}
		}

		private void OnComponentRemoving(object sender, ComponentEventArgs e)
		{
			//XComboBox가 제거될때 관련된 XComboItem도 같이 제거
			if (e.Component == findWorker)
			{
				FindColumnInfo info = null;
				for (int idx = findWorker.ColInfos.Count - 1; idx >= 0; idx--)
				{
					info = findWorker.ColInfos[idx];
					iComp.OnComponentChanging(findWorker, null);
					findWorker.ColInfos.Remove(info);
					iHost.DestroyComponent(info);
					iComp.OnComponentChanged(findWorker, null, null, null);
				}
			}
		}
	}
	#endregion
}
