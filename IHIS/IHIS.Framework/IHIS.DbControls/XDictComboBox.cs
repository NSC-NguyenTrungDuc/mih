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
using System.Data.OracleClient;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Caching;
using IHIS.CloudConnector.Contracts.Arguments.System;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.CloudConnector.Utility;

namespace IHIS.Framework
{
	/// <summary>
	/// XDictComboBox에 대한 요약 설명입니다.
	/// </summary>
	[DefaultProperty("SQLType")]
	[DefaultEvent("DataValidating")]
	[ToolboxBitmap(typeof(IHIS.Framework.XDictComboBox), "Images.XDictComboBox.bmp")]
	[Designer(typeof(XDictComboBoxDesigner))]
	public class XDictComboBox : IHIS.Framework.XComboBox
	{
		#region Fields
		private string dictColumn = "";
		private string userSQL = "";
		private bool codeDisplay = true;
		private XComboSQLType sqlType = XComboSQLType.DictColumn;
		private BindVarCollection bindVars = new BindVarCollection(); //User Sql사용시 Bind변수 관리
        private ExecuteQueryData executeQuery;
        private List<string> paramList = new List<string>();
		#endregion

		#region Properties
		[Browsable(true),
		Category("추가속성"),
		DefaultValue(true),
		Description("자료사전사용시 Code값을 Display할지 여부를 설정합니다.")]
		public bool CodeDisplay
		{
			get { return codeDisplay; }
			set { codeDisplay = value; }
		}
		[Browsable(true),
		Category("추가속성"),
		DefaultValue(XComboSQLType.DictColumn),
		Description("콤보설정시 자료사전을 쓸지 사용자SQL 쓸지 여부를 설정합니다.")]
		public XComboSQLType SQLType
		{
			get { return sqlType; }
			set { sqlType = value; }
		}
		[Browsable(true),Category("추가속성"),
		DefaultValue(""),Description("자료사전에서 조회하고자 하는 칼럼명을 입력합니다.")]
		public string DictColumn
		{
			get { return dictColumn;}
			set 
			{
				dictColumn = value;
				//Runtime시 DDLB SET
				if (!DesignMode && (dictColumn != "") && (sqlType == XComboSQLType.DictColumn))
				{
					try
					{
						SetDictDDLB();
					}
					catch{}
				}
			}
		}
        
		[Browsable(true),Category("추가속성"),
		DesignerSerializationVisibility(DesignerSerializationVisibility.Visible),
		DefaultValue(""),
		Editor(typeof(TextEditor), typeof(UITypeEditor)),
		Description("사용자 정의 SQL을 입력합니다.")]
		public string UserSQL
		{
			get { return userSQL; }
			set
			{
				userSQL = value;
				//RunType시 DDLB Set
				if (!DesignMode && (userSQL.Trim() != "") && (sqlType == XComboSQLType.UserSQL))
				{
					try
					{
						SetDictDDLB();
					}
					catch{}
				}
			}
		}
         
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
                SQLHelper.InitBindVarListFromParamList(paramList, this.bindVars);
            }
        }
        #endregion

        [Browsable(false)]
		protected virtual string DictSQL
		{
			//자료사전 조회 SQL
			//2006.07.11 Bind변수의 판단은 DB종류에 따른 BindSymbol로 판단 (Oracle-> :, SqlServer -> @
			get { return "SELECT A.CODE,A.CODE_NM  FROM ADM1110 A  WHERE A.COL_ID = " + Service.BindSymbol + "f_column ORDER BY A.COL_ID, A.CODE"; }
		}
		#endregion

		#region Event
		[Browsable(true),
		Category("추가이벤트"),
		Description("콤보박스에 자료사전,사용자 SQL로 데이타를 설정하기전에 발생합니다.(Bind 변수 Set)")]
		public event EventHandler DDLBSetting;
		#endregion 

		#region 생성자
		public XDictComboBox()
		{
		}
		#endregion


		#region OnDDLBSetting 
		protected virtual void OnDDLBSetting(EventArgs e)
		{
			if (DDLBSetting != null)
				DDLBSetting(this, e);
		}
		#endregion


		#region SetDictDDLB, SetDictDDLBSub
		/// <summary>
		/// 콤보박스에 자료사전을 설정합니다.
		/// </summary>
		/// <returns> 성공시 true, 실패시 false </returns>
		public bool SetDictDDLB()
		{
			// 자료사전에서 조회하거나 사용자 입력SQL문으로 DDLB SET
			if (this.sqlType == XComboSQLType.DictColumn)
			{
				if (dictColumn.Trim() == string.Empty)
				{
					//XMessageBox.Show("조회할 칼럼명이 입력되지 않았습니다.[XDictComboBox]","자료사전 컬럼설정");
					return false;
				}
				// SQL을 보내서 DataTable Return
				try
				{
					//데이타 설정전 Event Call
					this.OnDDLBSetting(EventArgs.Empty);
					
					//ComboItems Clear
					ComboItems.Clear();

                    // TODO comment use connect cloud
					//Bind 변수에 f_column에 자료사전컬럼명 SET
					/*BindVarCollection bindVarList = new BindVarCollection();
					bindVarList.Add("f_column", this.dictColumn);
					DataTable table = Service.ExecuteDataTable(this.DictSQL, bindVarList);
					SetDictDDLBSub(table);*/

                    // Connect to cloud
				    IList<object[]> listData = ExecuteQueryCboUserGubun();
                    SetDictDDLBSub(listData);

					// DataSource갱신
					this.RefreshComboItems();

					return true;
				}
				catch
				{
					return false;
				}
			}
			else
			{
				/*if (userSQL.Trim() == string.Empty)
				{
					//XMessageBox.Show("SQL문이 입력되지 않았습니다.[XDictComboBox]","설정 에러");
					return false;
				}*/

				try
				{
					//데이타 설정전 Event Call
					this.OnDDLBSetting(EventArgs.Empty);
				
					//ComboItems Clear
					ComboItems.Clear();

//					DataTable table = Service.ExecuteDataTable(this.userSQL, this.bindVars);
				    IList<object[]> listData = executeQuery(this.bindVars);
                    SetDictDDLBSub(listData);

					// DataSource갱신
					this.RefreshComboItems();

					return true;
				}
				catch (Exception e)
				{
                    Console.WriteLine("{0} Exception caught.", e);
					return false;
				}

			}
		}

	    public void SetDictDDLB(IList<object[]> lstData)
        {
            //데이타 설정전 Event Call
            this.OnDDLBSetting(EventArgs.Empty);
            //ComboItems Clear
            ComboItems.Clear();
            SetDictDDLBSub(lstData);
            // DataSource갱신
            this.RefreshComboItems();
	    }

		/// <summary>
		/// SQL조회후 조회 Data를 ComboItems에 Setting합니다.
		/// </summary>
		/// <param name="service"></param>
		// 각 Site에 따라 전문구조가 다르므로 자료사전 Setting 방법도 달라야 함
		protected virtual void SetDictDDLBSub(DataTable table)
		{
			if (table == null) return;

			if (table.Rows.Count < 1) return;

			foreach (DataRow dtRow in table.Rows)
			{
				// 자료사전으로 Setting시에 isCodeDisplay = true이면 DisplayItem = Code.Code명으로 Set
				if(this.sqlType == XComboSQLType.DictColumn && this.codeDisplay)
					this.ComboItems.Add(dtRow[0].ToString()	 , dtRow[0].ToString() + "." + dtRow[1].ToString());
				else
					this.ComboItems.Add(dtRow[0].ToString()	 , dtRow[1].ToString());
			}
		}

        protected virtual void SetDictDDLBSub(IList<object[]> table)
        {
            if (table == null) return;

            if (table.Count < 1) return;

            foreach (object[] dtRow in table)
            {
                // 자료사전으로 Setting시에 isCodeDisplay = true이면 DisplayItem = Code.Code명으로 Set
                if (this.sqlType == XComboSQLType.DictColumn && this.codeDisplay)
                    this.ComboItems.Add(dtRow[0].ToString(), dtRow[0].ToString() + "." + dtRow[1].ToString());
                else
                    this.ComboItems.Add(dtRow[0].ToString(), dtRow[1].ToString());
            }
        }
		#endregion

		#region SetBindVarList
		public void SetBindVarValue(string varName, string varValue)
		{
			//사용자정의 SQL에서 사용한 Bind 변수의 값을 설정
			this.bindVars.Add(varName, varValue);
		}
		#endregion

        #region Get data for XDictComboBox in cace DictSQL
        /// <summary>
        /// ExecuteQueryCboUserGubun
        /// </summary>
        /// <param name="var"></param>
        /// <returns></returns>
        private IList<object[]> ExecuteQueryCboUserGubun()
        {
            IList<object[]> res = new List<object[]>();
            ComboADM1110GetByColNameArgs args = new ComboADM1110GetByColNameArgs();
            args.ColName = this.dictColumn;

            ComboResult comboResult =
                CloudService.Instance.Submit<ComboResult, ComboADM1110GetByColNameArgs>(args);

            if (comboResult != null && comboResult.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (ComboListItemInfo info in comboResult.ComboItem)
                {
                    res.Add(new object[] { info.Code, info.CodeName });
                }
            }
            return res;
        }
        #endregion
    }

	#region XDictComboBoxDesigner
	/// <summary>
	/// XDictComboBox의 Designer입니다.
	/// </summary>
	internal class XDictComboBoxDesigner : System.Windows.Forms.Design.ControlDesigner
	{
		private XDictComboBox comboBox = null;
		private bool changeFlag = false;
		private ISelectionService iSvc;
		private IComponentChangeService iComp;
		private IDesignerHost iHost;
		/// <summary>
		/// Designer를 초기화 합니다.
		/// </summary>
		/// <param name="component"> Designer를 가진 IComponent 개체 </param>
		public override void Initialize(IComponent component)
		{
			base.Initialize(component);
			// Design하고있는 Control 등록
			comboBox = (XDictComboBox) component;

			// Hook up events
			iSvc = (ISelectionService) GetService(typeof(ISelectionService));
			iSvc.SelectionChanged += new EventHandler(OnSelectionChanged);
			iHost = (IDesignerHost) GetService(typeof(IDesignerHost));
			iComp = (IComponentChangeService) GetService(typeof(IComponentChangeService));
			iComp.ComponentRemoving += new ComponentEventHandler(OnComponentRemoving);
			iComp.ComponentChanged += new ComponentChangedEventHandler(OnComponentChanged);
		}

		/// <summary>
		/// 디자이너가 초기화될 때 호출되므로 디자이너는 구성 요소의 속성을 기본값으로 설정
		/// (override) 기본값을 정의하지 않음 
		/// </summary>
		//public override void OnSetComponentDefaults()
		//{
        // 2003용 기본값 설정 방법. 2005는 아래와 같이..
		//}
        public override void InitializeNewComponent(System.Collections.IDictionary defaultValues)
        {
            base.InitializeNewComponent(defaultValues);
            this.Control.Text = "";
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
				return comboBox.ComboItems;
			}
		}

		private void OnSelectionChanged(object sender, System.EventArgs e)
		{
			if (!changeFlag)
			{
				ISelectionService s = (ISelectionService) GetService(typeof(ISelectionService));
		
				//Selected된 상태이면 속성 동적으로 변경
				if (s.GetComponentSelected(this.Component))
				{
					changeFlag = true;
					// EditMaskType이 바뀌면 속성 동적으로 변경
					//Refresh를 하면 PreFilterProperties,PostFilterProperties call
					TypeDescriptor.Refresh(this.Component);
				}
			}
		}
		private void OnComponentChanged(object sender, ComponentChangedEventArgs e)
		{
			if (e.Component is XDictComboBox)
			{
				// Control삭제시 OnComponentChanged 발생, 이때 e.Member가 null이므로
				// e.Member Check 해야함
				if (e.Member != null)
				{
					if (e.Member.Name == "SQLType") //SQLType에 따라 속성 Browsable 변경
					{
						changeFlag = true;
						// EditMaskType이 바뀌면 속성 동적으로 변경
						//Refresh를 하면 PreFilterProperties,PostFilterProperties call
						TypeDescriptor.Refresh(this.Component);
					}
				}
			}
		}
		/// <summary>
		/// Designer의 리소스를 해제합니다.
		/// (override) 연결된 EventHandler를 해제합니다.
		/// </summary>
		/// <param name="disposing"> disposing 여부 </param>
		protected override void Dispose(bool disposing)
		{
			// Unhook events
			iSvc.SelectionChanged -= new EventHandler(OnSelectionChanged);
			iComp.ComponentChanged -= new ComponentChangedEventHandler(OnComponentChanged);
			iComp.ComponentRemoving -= new ComponentEventHandler(OnComponentRemoving);
			base.Dispose(disposing);
		}

		private void OnComponentRemoving(object sender, ComponentEventArgs e)
		{
			//XComboBoxEx가 제거될때 관련된 XComboItem도 같이 제거
			if (e.Component == comboBox)
			{
				XComboItem cItem = null;
				for (int idx = comboBox.ComboItems.Count - 1; idx >= 0; idx--)
				{
					cItem = comboBox.ComboItems[idx];
					iComp.OnComponentChanging(comboBox, null);
					comboBox.ComboItems.Remove(cItem);
					iHost.DestroyComponent(cItem);
					iComp.OnComponentChanged(comboBox, null, null, null);
				}
			}
		}

		/// <summary>
		/// 디자이너에서 TypeDescriptor를 통해 노출되는 속성 집합의 항목을 변경하거나 제거하도록 합니다.
		/// (override) EditMaskType에 따라 속성을 동적으로 변경합니다.
		/// </summary>
		/// <param name="properties"> 구성 요소의 클래스에 대한 속성입니다 </param>
		protected override void PostFilterProperties(System.Collections.IDictionary properties)
		{
			// MaskType속성 변경시만 Property Change
			if (changeFlag && (this.Control != null) && (this.Control is XDictComboBox))
			{
				XDictComboBox xCombo = (XDictComboBox) this.Control;
				if (xCombo.SQLType == XComboSQLType.DictColumn)
				{
					//사용자정의 SQL Remove
					properties.Remove("UserSQL");
				}
				else
				{
					//자료사전 관련 속성 Removde
					properties.Remove("DictColumn");
					properties.Remove("CodeDisplay");
				}
			}
			
			base.PostFilterProperties(properties);
		}
		/// <summary>
		/// 구성 요소가 TypeDescriptor를 통해 노출하는 속성 집합을 조정합니다.
		/// (override) EditMaskType에 따른 동적변경속성을 추가합니다.
		/// </summary>
		/// <param name="properties"> 구성 요소의 클래스에 대한 속성입니다 </param>
		protected override void PreFilterProperties(System.Collections.IDictionary properties)
		{
			base.PreFilterProperties(properties);
			// 동적으로 변경할 Property Add
			if ((this.Control != null) && (this.Control is XDictComboBox))
			{
				XDictComboBox xCombo = (XDictComboBox) this.Control;
				if (!properties.Contains("DictColumn"))
					properties.Add("DictColumn", xCombo.DictColumn);
				if (!properties.Contains("CodeDisplay"))
					properties.Add("CodeDisplay", xCombo.CodeDisplay);
//				if (!properties.Contains("UserSQL"))
//					properties.Add("UserSQL", xCombo.UserSQL);
			}
		}
	}
	#endregion

	#region enum XComboSQLType
	public enum XComboSQLType
	{
		/// <summary>
		/// 자료사전 컬럼을 이용한 자료사전 설정
		/// </summary>
		DictColumn,
		/// <summary>
		/// 사용자 정의 SQL을 이용한 자료사전 설정
		/// </summary>
		UserSQL
	}
	#endregion
}
