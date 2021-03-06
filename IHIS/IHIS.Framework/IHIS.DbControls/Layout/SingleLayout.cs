using System;
using System.Collections.Generic;
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
using System.Security;
using System.ComponentModel.Design;
using System.Windows.Forms.Design;

namespace IHIS.Framework
{
    #region SingleLayout
    [ToolboxItem(true),
    ToolboxBitmap(typeof(IHIS.Framework.SingleLayout), "Images.Layout.bmp"),
    DefaultProperty("LayoutItems"),
    DesignTimeVisible(true),
    Designer(typeof(SingleLayoutDesigner))]
    public class SingleLayout : System.ComponentModel.Component, ISaveLayout
    {
        #region Fields
        private SingleLayoutItemCollection layoutItems = new SingleLayoutItemCollection();
        private string querySQL = "";
        private BindVarCollection bindVarList = new BindVarCollection();
        //저장 관련
        private ISavePerformer savePerformer = null;  //저장 기능을 담당하는 수행자
        private char callerID = '1';  //수행자를 Call하는 Grid의 ID
        private ExecuteQueryData executeQuery;
        private List<string> paramList = new List<string>();
        #endregion

        #region Properties
        [Browsable(true), Category("추가속성")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public virtual SingleLayoutItemCollection LayoutItems
        {
            get { return layoutItems; }
        }
        
        [Category("추가속성"),
        DefaultValue(""),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Visible),
        Editor(typeof(SQLEditor), typeof(UITypeEditor)),
        Description("데이타를 조회할 SQL을 지정합니다.")]
        public string QuerySQL
        {
            get { return querySQL; }
            set
            {
                querySQL = value;
                //RunTime시에 SQL에 포함된 bindVar 분석
                if (!this.DesignMode)
                {
                    SQLHelper.InitBindVarList(querySQL, this.BindVarList);
                }
            }
        }
         
        [Category("추가속성"),
        DefaultValue(null),
        Description("저장시 저장 기능을 수행하는 수행 class 객체를 지정합니다.")]
        public ISavePerformer SavePerformer
        {
            get { return savePerformer; }
            set { savePerformer = value; }
        }
        [Category("추가속성"),
        DefaultValue('1'),
        Description("저장시 저장기능 수행자에게 넘겨줄 Layout의 ID를 지정합니다.")]
        public char CallerID
        {
            get { return callerID; }
            set { callerID = value; }
        }
        #endregion

        #region ExecuteQuery, ParamList
        public ExecuteQueryData ExecuteQuery
        {
            get { return executeQuery; }
            set { executeQuery = value; }
        }

        public List<string> ParamList
        {
            get { return paramList; }
            set
            {
                paramList = value;
                SQLHelper.InitBindVarListFromParamList(paramList, this.BindVarList);
            }
        }

        #endregion

        #region Event
        [Description("조회가 시작되었을때 발생합니다.(Bind변수에 값 설정, 조건에 따른 조회여부 설정)"),
        Category("추가이벤트"),
        Browsable(true)]
        public event CancelEventHandler QueryStarting;
        [Description("저장이 시작되었을때 발생합니다.(저장전 값 설정 및 저장여부 설정)"),
        Category("추가이벤트"),
        Browsable(true)]
        public event CancelEventHandler SaveStarting;
		//2007.11.08 조회종료, 저장종료 Event 추가 (성공여부에 따라 추가 처리시에 사용)
		[Description("조회가 끝났을때 발생합니다.(조회 성공여부에 따라 추가처리시 사용)"),
		Category("추가이벤트"),
		Browsable(true)]
		public event QueryEndEventHandler QueryEnd;
		[Description("저장이 끝났을때 발생합니다.(저장 성공여부에 따라 추가처리시 사용)"),
		Category("추가이벤트"),
		Browsable(true)]
		public event SaveEndEventHandler SaveEnd;
        #endregion

        #region 생성자
        public SingleLayout()
        {
        }
        #endregion

        #region GetItemValue, SetItemValue
        public object GetItemValue(string dataName)
        {
            return GetItemValueSub(this.layoutItems[dataName]);
        }
        private object GetItemValueSub(SingleLayoutItem item)
        {
            //DataName 잘못 지정
            if (item == null) return "";

            object dataValue = "";
            // Property
            if ((item.BindVariable != "") && (item.BindControl != null))
            {
                Type objectType = item.BindControl.GetType();
                MemberInfo[] mi = objectType.GetMember(item.BindVariable);
                if (mi.Length > 0)
                {
                    object valObj = null;
                    //Property만 BindVariable에서 GET
                    if (mi[0].MemberType == MemberTypes.Property)
                    {
                        PropertyInfo pi = (PropertyInfo)mi[0];
                        valObj = pi.GetValue(item.BindControl, null);
                    }
                    if ((valObj is byte[]) || (valObj is string))
                        dataValue = valObj;
                    else if (valObj == null)
                        dataValue = "";
                    else
                        dataValue = valObj.ToString();
                }
            }
            else if (item.BindControl is IDataControl)
            {
                dataValue = ((IDataControl)item.BindControl).DataValue;
            }
            else
            {
                dataValue = item.DataValue;
            }
            return dataValue;
        }
        public bool SetItemValue(string dataName, object data)
        {
            SingleLayoutItem layout = this.layoutItems[dataName];

            //DataName이 없으면 return
            if (layout == null) 
            {
                XMessageBox.Show("DataName[" + dataName + "]을 잘못 지정하셨습니다.[SetItemValue]");
                return false;
            }

            object dataValue = data;
            if (dataValue == null) dataValue = "";

            try
            {
                layout.DataValue = dataValue;

                // Property
                if ((layout.BindVariable != "") && (layout.BindControl != null))
                {
                    Type objectType = layout.BindControl.GetType();
                    MemberInfo[] mi = objectType.GetMember(layout.BindVariable);
                    if ((mi.Length > 0) && (mi[0].MemberType == MemberTypes.Property))
                    {
                        PropertyInfo pi = (PropertyInfo)mi[0];
                        if (pi.PropertyType == typeof(string))
                        {
                            pi.SetValue(layout.BindControl, dataValue, null);
                        }
                    }
                }
                else if (layout.BindControl is IDataControl)
                    ((IDataControl)layout.BindControl).DataValue = dataValue;

            }
            catch (Exception xe)
            {
                XMessageBox.Show("SingleLayout::SetItemValue[" + dataName + "] 에러[" + xe.Message + "]");
                return false;
            }
            return true;
        }
        #endregion

        #region QueryLayout, SaveLayout
        public bool QueryLayout()
        {
            //조회 시작 Event Call (Bind 변수 동적으로 할당, 조건에 따른 조회여부 설정)
            CancelEventArgs xe = new CancelEventArgs();
            OnQueryStarting(xe);
            if (xe.Cancel)
            {
                //Layout Reset
                this.Reset();
                return false;
            }

            //조회 Msg 처리
            //SetServiceMsg(ServiceType.Query, ServiceMsgType.Processing);  //조회중입니다. Msg

            //Layout Reset
            this.Reset();
			
			string msg = "";
            if (this.executeQuery == null)
            {
                msg = XMsg.GetMsg("M072"); //조회 SQL이 정의되지 않았습니다.
                //XMessageBox.Show(msg, "QueryLayout");
                Logs.WriteLog(msg);
                return false;
            }
            if (this.layoutItems.Count < 1)
            {
				msg = XMsg.GetMsg("M073"); //데이타를 받을 LayoutItems가 정의되지 않았습니다.
                XMessageBox.Show(msg, "QueryLayout");
                return false;
            }
//            DataTable table = Service.ExecuteDataTable(this.querySQL, this.bindVarList);
            
            IList<object[]> xSingleLayoutData = executeQuery(this.BindVarList);
            if ((xSingleLayoutData == null) || (xSingleLayoutData.Count < 1))
			{
				//2007.11.08 추가 QueryEnd Event Invoke (조회실패)
				msg = XMsg.GetMsg("M074") + "[" + Service.ErrMsg + "]"; //데이타 조회실패
				OnQueryEnd(new QueryEndEventArgs(this.callerID, false, msg));
				return false;
			}
            //조회된 순서대로 Data Set
            SingleLayoutItem item;
//            DataRow dtRow = table.Rows[0];  //Single 행
            object[] dtRow = xSingleLayoutData[0]; //Single 행
            try
            {
                for (int i = 0; i < dtRow.Length; i++)
                {
                    if (i < layoutItems.Count)
                    {
                        item = layoutItems[i];
                        item.DataValue = dtRow[i];
                        //Property, BincControl Data Set
                        if (item.BindVariable != "")
                        {
                            //Bind 속성 값 설정
                            Type objectType = item.BindControl.GetType();
                            MemberInfo[] mi = objectType.GetMember(item.BindVariable);
                            if ((mi.Length > 0) && (mi[0].MemberType == MemberTypes.Property))
                            {
                                PropertyInfo pi = (PropertyInfo)mi[0];
                                pi.SetValue(item.BindControl, dtRow[i], null);
                            }
                        }
                        else if (item.BindControl is IDataControl) //BindControl Set
                        {
                            ((IDataControl)item.BindControl).DataValue = dtRow[i];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
				msg = XMsg.GetMsg("M074") + "[" + ex.Message + "]"; //데이타 조회실패
				//2007.11.08 추가 QueryEnd Event Invoke (조회실패)
				OnQueryEnd(new QueryEndEventArgs(this.callerID, false, msg));
                return false;
            }
			//2007.11.08 추가 QueryEnd Event Invoke (조회성공)
			OnQueryEnd(new QueryEndEventArgs(this.callerID, true,""));
            return true;

        }
        public bool SaveLayout()
        {
            //저장 기능 수행자 미정의시 Return
            if (this.SavePerformer == null)
            {
                XMessageBox.Show("SavePerformer is not defined.", "SaveLayout");
                return false;
            }
            try
            {
                //조회 시작 Event Call (Bind 변수 동적으로 할당, 조건에 따른 조회여부 설정)
                CancelEventArgs xe = new CancelEventArgs();
                OnSaveStarting(xe);
                if (xe.Cancel) return false;

                //this.SetServiceMsg(ServiceType.Entry, ServiceMsgType.Processing); //처리중 Msg 처리

                RowDataItem dataItem = new RowDataItem(DataRowState.Unchanged);

                foreach (SingleLayoutItem item in this.layoutItems)
                {
                    if (item.IsUpdItem)
                    {
                        //저장할 데이타 Add
                        object data = GetItemValueSub(item);
                        //BindVarList Set
						//2007.10.15 BIND 변수는 컬럼의 CASE에 관계없이 Lower로 처리함.
						//2007.11.06 컬럼명 그대로 f_를 붙이는 것으로 처리한다.
                        //dataItem.BindVarList.Add("f_" + item.DataName.ToLower(), data.ToString());
						dataItem.BindVarList.Add("f_" + item.DataName, data.ToString());
                    }
                }
                //저장 수행자 Call (실패시는 throw)
                if (!this.SavePerformer.Execute(this.callerID, dataItem))
					throw new Exception(Service.ErrMsg);
            }
            catch (Exception xe)
            {
                string msg = XMsg.GetMsg("M074") + "[" + xe.Message + "]"; //데이타 조회실패
				//2007.11.08 SaveEnd Event Invoke (저장실패)
				OnSaveEnd(new SaveEndEventArgs(this.callerID, false, msg));
                return false;
            }

            //this.SetServiceMsg(ServiceType.Entry, ServiceMsgType.Normal);
			
			//2007.11.08 SaveEnd Event Invoke (저장성공)
			OnSaveEnd(new SaveEndEventArgs(this.callerID, true,""));

            return true;
        }
        #endregion

        #region Reset
        /// <summary>
        /// 관련 Control 초기화
        /// </summary>
        public virtual void Reset()
        {
            foreach (SingleLayoutItem layout in layoutItems)
            {
                //<미확정>Property는 Clear하지 않음
                //Layout의 DataValue Clear
                layout.DataValue = string.Empty;

                // Bind Control Clear
                if ((layout.BindControl != null) && (layout.BindControl is IDataControl))
                {
                    //2006.07.27 ApplyLayoutContainerReset 속성 적용함
                    if (((IDataControl)layout.BindControl).ApplyLayoutContainerReset)
                        ((IDataControl)layout.BindControl).ResetData();
                }
            }
        }
        #endregion

        #region Event Invoker
        /// <summary>
        /// QueryStarting Event 발생(Bind 변수 SET)
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnQueryStarting(CancelEventArgs e)
        {
            if (this.QueryStarting != null)
                QueryStarting(this, e);
        }
        protected virtual void OnSaveStarting(CancelEventArgs e)
        {
            if (this.SaveStarting != null)
                SaveStarting(this, e);
        }
		//2007.11.08 QueryEnd, SaveEnd Event Invoker 추가
		protected virtual void OnQueryEnd(QueryEndEventArgs e)
		{
			if (this.QueryEnd != null)
				QueryEnd(this, e);
		}
		protected virtual void OnSaveEnd(SaveEndEventArgs e)
		{
			if (this.SaveEnd != null)
				SaveEnd(this, e);
		}
        #endregion

        #region SetBindVarValue(QuerySQL의 BindVar에 값 설정)
        public void SetBindVarValue(string varName, string varValue)
        {
            //VarName이 정확하면 VarValue SET
            BindVar bVar = this.BindVarList[varName];
            if (bVar != null)
                bVar.VarValue = varValue;
        }
        //값과 ValueLen 설정
        public void SetBindVarValue(string varName, string varValue, int valueLen)
        {
            //VarName이 정확하면 VarValue SET
            BindVar bVar = this.BindVarList[varName];
            if (bVar != null)
            {
                bVar.VarValue = varValue;
                bVar.ValueLen = valueLen;
            }
        }
        #endregion

		#region ISaveLayout implemetation
		//SingleLayout은 Single행만 저장하므로 SaveLayout()시에 Trasaction을 사용하지 않는다.
		//따라서, 기능 구현이 필요없음
		bool ISaveLayout.UseDefaultTransaction
		{
			get { return true;}
			set { }
		}

        public BindVarCollection BindVarList
        {
            get { return bindVarList; }
        }

        #endregion


    }
    #endregion

    #region SingleLayoutDesigner
    internal class SingleLayoutDesigner : System.ComponentModel.Design.ComponentDesigner
    {
        private SingleLayout layout = null;
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
            layout = (SingleLayout)component;

            //Service Instance Set
            iSvc = (ISelectionService)GetService(typeof(ISelectionService));
            iComp = (IComponentChangeService)GetService(typeof(IComponentChangeService));
            iHost = (IDesignerHost)GetService(typeof(IDesignerHost));
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
                // uComboBoxItem을 관련 Component로 함
                return layout.LayoutItems;
            }
        }

        private void OnComponentRemoving(object sender, ComponentEventArgs e)
        {
            //SingleLayout이 제거될때 관련된 SingleLayoutItem도 같이 제거
            if (e.Component == layout)
            {
                SingleLayoutItem item = null;
                for (int idx = layout.LayoutItems.Count - 1; idx >= 0; idx--)
                {
                    item = layout.LayoutItems[idx];
                    iComp.OnComponentChanging(layout, null);
                    layout.LayoutItems.Remove(item);
                    iHost.DestroyComponent(item);
                    iComp.OnComponentChanged(layout, null, null, null);
                }
            }
        }
    }
    #endregion

	#region QueryEndEventArgs(QueryLayout call시 조회후 발생하는 Event, 조회후 추가처리시 사용한다.)
	[Serializable]
	public delegate void QueryEndEventHandler(object sender, QueryEndEventArgs e);

	public class QueryEndEventArgs : EventArgs
	{
		char callerID = '1'; //CallerID
		bool isSuccess = false; //조회 성공여부
		string errMsg = "";  //실패시 에러 메세지

		/// <summary>
		/// QueryLayout을 call한 caller의 ID를 가져옵니다.
		/// </summary>
		public char CallerID
		{
			get { return callerID; }
		}
		/// <summary>
		/// 조회 성공여부를 가져옵니다.
		/// </summary>
		public bool IsSuccess
		{
			get { return isSuccess; }
		}
		public string ErrMsg
		{
			get { return errMsg;}
		}
		public QueryEndEventArgs(char callerID, bool isSuccess, string errMsg)
		{
			this.callerID = callerID;
			this.isSuccess = isSuccess;
			this.errMsg = errMsg;
		}
	}
	#endregion

	#region SaveEndEventArgs(SaveLayout call시 저장후 발생하는 Event, 저장후 추가처리시 사용한다.)
	[Serializable]
	public delegate void SaveEndEventHandler(object sender, SaveEndEventArgs e);

	public class SaveEndEventArgs : EventArgs
	{
		char callerID; //CallerID
		bool isSuccess; //저장 성공여부
		string errMsg = "";  //실패시 에러 메세지

		/// <summary>
		/// SaveLayout을 call한 caller의 ID를 가져옵니다.
		/// </summary>
		public char CallerID
		{
			get { return callerID; }
		}
		/// <summary>
		/// 저장 성공여부를 가져옵니다.
		/// </summary>
		public bool IsSuccess
		{
			get { return isSuccess; }
		}
		public string ErrMsg
		{
			get { return errMsg;}
		}
		public SaveEndEventArgs(char callerID, bool isSuccess, string errMsg)
		{
			this.callerID = callerID;
			this.isSuccess = isSuccess;
			this.errMsg = errMsg;
		}
	}
	#endregion
}
