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
    [ToolboxItem(true),
    ToolboxBitmap(typeof(IHIS.Framework.MultiLayout), "Images.Layout.bmp"),
    DefaultProperty("LayoutItems"),
    DesignTimeVisible(true),
    Designer(typeof(MultiLayoutDesigner))]
    public class MultiLayout : Component, IMultiSaveLayout, IMultiQueryLayout, IDetailLayout, ISupportInitialize
    {
        #region Fields
        private MultiLayoutItemCollection layoutItems = new MultiLayoutItemCollection();
        private DataTable layoutTable = new DataTable("LayoutTable");
        private DataTable deletedRowTable = null;	//삭제된 데이타를 관리하는 테이블
        private IMasterLayout masterLayout = null;  //이 Layout의 MasterLayout
        private Hashtable relationKeys = new Hashtable();  //(컬럼명, Master컬럼명)형태로 관리되는 Key 컬럼관리 List
        private string relationTableName = "";  //이 Layout이 Detail로 사용될때 이 Layout과 관련된 Table명(DB Table)
        private string querySQL = "";
        private BindVarCollection bindVarList = new BindVarCollection();
        private bool useDefaultTransaction = true;  //SaveLayout시에 Transaction을 사용할지 여부(MasterLayout인 경우 Detail이 정상적일때 Tran종료시 사용)
        private bool includeUnChangedRowAtSaving = false;  //저장시 변경되지 않은 Row를 포함할지 여부(변경안된Row 포함시는 N으로 처리함)
        //저장 관련
        private ISavePerformer savePerformer = null;  //저장 기능을 담당하는 수행자
        private char callerID = '1';  //수행자를 Call하는 Grid의 ID
        private ExecuteQueryData executeQuery;
        private List<string> paramList = new List<string>();
        #endregion

        #region Properties
        [Browsable(true), Category("추가속성")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public virtual MultiLayoutItemCollection LayoutItems
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
                    SQLHelper.InitBindVarList(querySQL, this.bindVarList);
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
        [Category("추가속성"),
        DefaultValue(true),
        Description("저장시 MutilLayout의 기본 Transaction을 사용할지 여부를 지정합니다.(여러개의 MultlLayout처리시는 외부에서 Transaction 관리)")]
        public bool UseDefaultTransaction
        {
            get { return useDefaultTransaction; }
            set { useDefaultTransaction = value; }
        }
        [Category("추가속성"),
        DefaultValue(null),
        Description("이 Layout이 Master가 되는 MultlLayout(Grid, MultiLayout)을 관리합니다.")]
        public IMasterLayout MasterLayout
        {
            get { return masterLayout; }
            set { masterLayout = value; }
        }
        [Category("추가속성"),
        DefaultValue(false),
        Description("저장시 변경되지 않은 행의 데이타도 전송할지 여부를 지정합니다.(UnChanged Row도 전송)")]
        public bool IncludeUnChangedRowAtSaving
        {
            get { return includeUnChangedRowAtSaving; }
            set { includeUnChangedRowAtSaving = value; }
        }
        /// <summary>
        /// MultlLayout의 RowCount(Data의 갯수)를 가져옵니다.
        /// </summary>
        [Browsable(false)]
        public int RowCount
        {
            get
            {
                if (this.layoutTable != null)
                    return this.layoutTable.Rows.Count;
                else
                    return 0;
            }
        }
        [Browsable(false)]
        public DataTable LayoutTable
        {
            get { return layoutTable; }
        }
        #endregion

        #region IDetailLayout Properties
        Hashtable IDetailLayout.RelationKeys
        {
            get { return relationKeys; }
        }
        string IDetailLayout.RelationTableName
        {
            get { return this.relationTableName; }
        }
        //Grid처럼 연속조회가 없이 전체 조회하므로 true
        bool IDetailLayout.IsAllDataQuery
        {
            get { return true; }
            set { }
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
                SQLHelper.InitBindVarListFromParamList(paramList, this.bindVarList);
            }
        }
        #endregion 


        #region Event
        [Description("조회가 시작되었을때 발생합니다.(Bind변수에 값 설정, 조건에 따른 조회여부 설정)"),
        Category("추가이벤트"),
        Browsable(true)]
        public event CancelEventHandler QueryStarting;
        /// <summary>
        /// 데이타 항목값을 설정하는 이벤트입니다.
        /// </summary>
        [Category("추가이벤트"),
        Description("데이타 저장시 한행씩 저장기능을 수행전에 발생하는 이벤트입니다.(조건에 따른 데이타 설정)")]
        public event MultiRecordEventHandler PreSaveLayout;
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
        protected virtual void OnPreSaveLayout(MultiRecordEventArgs e)
        {
            if (PreSaveLayout != null)
                PreSaveLayout(this, e);
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

        #region IMultiSaveLayout, IMultiQueryLayout Property Implemetation
        //DataLayoutMIO는 Grid처럼 Focus를 관리하지 않으므로 첫번째 값으로 처리함.
        int IMultiSaveLayout.CurrentRowNumber
        {
            get { return 0; }
        }
        string IMultiSaveLayout.CurrentColName
        {
            get
            {
                if (this.layoutTable != null && this.layoutTable.Columns.Count > 0)
                    return this.layoutTable.Columns[0].ColumnName;
                else
                    return "";
            }
        }
        bool IMultiSaveLayout.ApplyLayoutContainerReset  //Grid처럼 Control이 아니므로 기능 없음
        {
            get { return false; }
            set { }
        }
        /// <summary>
        /// 변경된 행의 건수를 가져옵니다. (IMultiSaveLayout 구현)
        /// </summary>
        /// <returns></returns>
        int IMultiSaveLayout.GetChangedRowCount()
        {
            return GetChangedRowCount('A');
        }
        int IMultiSaveLayout.InsertRow()  //MultiLayout에는 현재행이라는 개념이 없으므로 맨 마지막 행 Add
        {
            return InsertRow(-1);
        }
        bool IMultiSaveLayout.DeleteRow() //MultiLayout에는 현재행이라는 개념이 없으므로 맨 마지막 행 삭제
        {
            return DeleteRow(this.RowCount - 1);
        }
        int IMultiQueryLayout.CurrentRowNumber
        {
            get { return 0; }
        }
        string IMultiQueryLayout.CurrentColName
        {
            get
            {
                if (this.layoutTable != null && this.layoutTable.Columns.Count > 0)
                    return this.layoutTable.Columns[0].ColumnName;
                else
                    return "";
            }
        }
        //Grid처럼 연속조회가 없이 전체 조회하므로 true
        bool IMultiQueryLayout.IsAllDataQuery
        {
            get { return true; }
            set { }
        }
        bool IMultiQueryLayout.ApplyLayoutContainerReset  //Grid처럼 Control이 아니므로 기능 없음
        {
            get { return false; }
            set { }
        }
        #endregion

        #region InitializeLayoutTable (LayoutTable 설정, 지정한 MultiLayoutItem으로 DataColumn 생성)
        public void InitializeLayoutTable()
        {
            //데이타, 컬럼 Clear
            this.layoutTable.Clear();
            this.layoutTable.Columns.Clear();
            //MultiLayoutItem으로 DataColumn 생성
            DataColumn dtCol;
            foreach (MultiLayoutItem item in layoutItems)
            {
                dtCol = new DataColumn(item.DataName);
                dtCol.AllowDBNull = true;  // null 허용
                switch (item.DataType)
                {
                    case DataType.String:
                    case DataType.Date:
                    case DataType.DateTime:
                        //Date는 YYYYMMDD형, DateTime은 YYYYMMDDHHMISS형의 String으로 정의
                        dtCol.DataType = typeof(string);
                        break;
                    case DataType.Number:
                        //Number는 double로 설정
                        dtCol.DataType = typeof(double);
                        break;
                    default:
                        dtCol.DataType = typeof(string);
                        break;
                }
                layoutTable.Columns.Add(dtCol);
            }
        }
        #endregion

        #region ISupportInitialize Implementation
        void ISupportInitialize.BeginInit()
        {
        }
        void ISupportInitialize.EndInit()
        {
            //RunTime시에 layoutItems에 설정된 정보로 layoutTable 컬럼 정의
            if (!this.DesignMode)
                InitializeLayoutTable();
        }
        #endregion

        #region SaveLayout
        public bool SaveLayout()
        {
            //저장 기능 수행자 미정의시 Return
            if (this.SavePerformer == null)
            {
                XMessageBox.Show("SavePerformer is not defined.", "SaveLayout");
                return false;
            }

            int rowNumber = 0;
            int saveCount = 0;  //저장된 행의 전체 갯수(I,U,D,N 포함)
            object masterValue = DBNull.Value;
            
            try
            {
                //Transaction Start (기본 Transaction 사용시만)
                if (this.UseDefaultTransaction)
                    Service.BeginTransaction();
                /* 저장 순서는 삭제된 행 -> 입력,수정된 행
                 * IsUpdItem인 컬럼으로 RowDataItem의 Data구성 -> SavePerformer의 Execute call
                 */
                RowDataItem dataItem;
                //InputList는 IsUpdCol로 지정된 컬럼을 차례로 InputList에 Add
                //InputList의 처음값은 I,U,D 구분(모든 저장 Procedure 통일해야함)
                //InputList의 두번째 값은 UserID로 통일함.
                //삭제 데이타로 서비스 Call
                if (deletedRowTable != null && deletedRowTable.Rows.Count > 0)
                {
                    foreach (DataRow dtRow in deletedRowTable.Rows)
                    {
                        dataItem = new RowDataItem(DataRowState.Deleted);
                        foreach (MultiLayoutItem item in this.LayoutItems)
                        {
                            //Update컬럼만 Add
                            if (item.IsUpdItem)
                            {
                                //NotNull Check
                                if (item.IsNotNull && dtRow[item.DataName].ToString() == "")
                                {
                                    string msg = "[" + item.DataName + "]" + XMsg.GetMsg("M001"); //"[" + item.DataName + "]의 값이 입력되지 않았습니다.
                                    throw (new Exception(msg));
                                }
                                //BindVarList Set
								//2007.10.15 BIND 변수는 컬럼의 CASE에 관계없이 Lower로 처리함.
								//2007.11.06 컬럼명 그대로 f_를 붙이는 것으로 처리한다.
                                //dataItem.BindVarList.Add("f_" + item.DataName.ToLower(), dtRow[item.DataName].ToString());
                                dataItem.BindVarList.Add("f_" + item.DataName, dtRow[item.DataName].ToString());

                            }
                        }
                        //저장 수행자 Call (실패시는 Exception 발생시켜 Rollback 처리)
                        if (!this.SavePerformer.Execute(this.callerID, dataItem))
                        {
							string msg = XMsg.GetMsg("M002") + "[" + Service.ErrMsg + "]"; //저장실패
                            throw new Exception(msg);
                        }
                        saveCount++; //저장 갯수증가
                    }
                }

                //I,U Row 전문 생성
                foreach (DataRow dtRow in LayoutTable.Rows)
                {
                    //Added, Modified 상태일때만 Data Set
                    //2006.04.04 변경안된 행 포함여부도 고려함
                    if (this.includeUnChangedRowAtSaving || (dtRow.RowState == DataRowState.Added) || (dtRow.RowState == DataRowState.Modified))
                    {
                        dataItem = new RowDataItem(dtRow.RowState);

                        // PreSaveLayout Event 호출
                        OnPreSaveLayout(new MultiRecordEventArgs(dtRow.RowState, rowNumber));

                        foreach (MultiLayoutItem item in this.LayoutItems)
                        {
                            //Update컬럼만 Add
                            if (item.IsUpdItem)
                            {
                                //Added상태일때 MasterLayout이 있고, 컬럼이 RelationKeys에 적용된 컬럼이면 MasterLayout에서 값을 가져와서 설정
                                if ((this.MasterLayout != null) && (dtRow.RowState == DataRowState.Added) && this.relationKeys.Contains(item.DataName))
                                {
                                    masterValue = this.MasterLayout.GetItemValueFromRelatonKey(this.relationKeys[item.DataName].ToString());
                                    //dtRow의 값을 masterValue로 설정
                                    dtRow[item.DataName] = masterValue;
                                }
                                //NotNull Check
                                if (item.IsNotNull && dtRow[item.DataName].ToString() == "")
                                {
                                    string msg = "[" + item.DataName + "]" + XMsg.GetMsg("M001"); //"[" + item.DataName + "]의 값이 입력되지 않았습니다.
                                    throw (new Exception(msg));
                                }
                                //BindVarList Set
								//2007.10.15 BIND 변수는 컬럼의 CASE에 관계없이 Lower로 처리함.
								//2007.11.06 컬럼명 그대로 f_를 붙이는 것으로 처리한다.
                                //dataItem.BindVarList.Add("f_" + item.DataName.ToLower(), dtRow[item.DataName].ToString());
								dataItem.BindVarList.Add("f_" + item.DataName, dtRow[item.DataName].ToString());

                            }
                        }
                        //저장 수행자 Call (실패시는 return)
                        if (!this.SavePerformer.Execute(this.callerID, dataItem))
                        {
                            //저장 수행자 Call (실패시는 Exception 발생시켜 Rollback 처리)
							string msg = XMsg.GetMsg("M002") + "[" + Service.ErrMsg + "]"; //저장실패
                            throw new Exception(msg);
                        }
                        saveCount++; //저장 갯수증가
                    }
                    //RowNumber 증가
                    rowNumber++;
                }
                //Transaction Commit (기본 Transaction 사용시만)
                if (this.UseDefaultTransaction)
                    Service.CommitTransaction();
            }
            catch (Exception xe)
            {
                //Transaction Rollback
                if (this.UseDefaultTransaction)
                    Service.RollbackTransaction();
				//2007.11.08 SaveEnd Event Invoke (저장실패)
				OnSaveEnd(new SaveEndEventArgs(this.callerID, false, xe.Message));
                return false;
            }

            //저장 성공시 ResetUpdate
            this.ResetUpdate();

			//2007.11.08 SaveEnd Event Invoke (저장성공)
			OnSaveEnd(new SaveEndEventArgs(this.callerID, true,""));

            return true;
        }
        #endregion

        #region QueryLayout
        public bool QueryLayout(bool isAllDataQuery)
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

            //DataTable Get
            //DataTable sourceTable = Service.ExecuteDataTable(this.querySQL, this.bindVarList);

            // IList xMultiLayoutData
            IList<object[]> xMultiLayoutData = executeQuery(this.bindVarList);

            //SQL 에러
            if (xMultiLayoutData == null)
            {
				msg = XMsg.GetMsg("M074") + "[" + Service.ErrMsg + "]"; //데이타 조회실패
				//XMessageBox.Show(msg, "QueryLayout");
				//2007.11.08 추가 QueryEnd Event Invoke (조회실패)
				OnQueryEnd(new QueryEndEventArgs(this.callerID, false, msg));
                return false;
            }

            //조회된 데이타가 없으면 Return
            if (xMultiLayoutData.Count < 1)
			{
				//<미확정> MultiLayout에서 데이타 없는 경우는 성공으로 판단함. SingleLayout에서는 데이타가 없으면 실패로 판단.
				//2007.11.08 추가 QueryEnd Event Invoke (조회성공)
				OnQueryEnd(new QueryEndEventArgs(this.callerID, true, ""));
				return true;
			}

            //조회된 데이타로 LayoutTable에 담음
            DataRow dtRow = null;
//            int dataCount = xMultiLayoutData.Count;
            int colIndex = 0;
            foreach (object[] dataRow in xMultiLayoutData)
            {
//                 dataRow = xMultiLayoutData[i];
                int dataCount = dataRow.Length;
                dtRow = LayoutTable.NewRow();
                colIndex = 0;
                foreach (MultiLayoutItem item in this.layoutItems)
                {
                    switch (item.DataType)
                    {
                        case DataType.String:
                        case DataType.DateTime:
                            //Data의 갯수보다 작으면
                            if (colIndex < dataCount)
                            {
                                try
                                {
                                    dtRow[colIndex] = dataRow[colIndex];
                                }
                                catch
                                {
                                    dtRow[colIndex] = DBNull.Value;
                                }
                            }
                            break;
                        case DataType.Number:
                            //Data의 갯수보다 작으면
                            if (colIndex < dataCount)
                            {
                                try
                                {
                                    dtRow[colIndex] = Double.Parse(dataRow[colIndex].ToString());
                                }
                                catch
                                {
                                    dtRow[colIndex] = DBNull.Value;
                                }
                            }
                            break;
                        case DataType.Date:
                            //Data의 갯수보다 작으면
                            if (colIndex < dataCount)
                            {
                                try
                                {
                                    dtRow[colIndex] = DateTime.Parse(dataRow[colIndex].ToString()).ToString("yyyy/MM/dd").Replace("-","/");
                                }
                                catch
                                {
                                    dtRow[colIndex] = DBNull.Value;
                                }
                            }
                            break;
                    }
                    colIndex++;
                }
                LayoutTable.Rows.Add(dtRow);
                //2005.11.09 처음조회후 값을 수정하고 다시 연속조회하여 SetValue시에
                //LayoutTable전체를 AcceptChanges하면 이전에 수정된 값도 Unchanged상태가 됨
                //이를 방지하기 위해 DataRow별로 AcceptChange함, OrigLayoutTable은 관계없음
                dtRow.AcceptChanges();
            }

			//2007.11.08 추가 QueryEnd Event Invoke (조회성공)
			OnQueryEnd(new QueryEndEventArgs(this.callerID, true,""));

            return true;
        }
        #endregion

        #region InsertRow, DeleteRow, Reset, ResetUpdate, AcceptData
        public void Reset()
        {
            //기존의 데이타를 모두 삭제 처리
            this.layoutTable.Rows.Clear();
            if (this.deletedRowTable != null)
                this.deletedRowTable.Rows.Clear();
        }
        public void ResetUpdate()
        {
            //데이타의 상태 Update
            this.layoutTable.AcceptChanges();
            //삭제 데이타 관리 Table의 데이타 Clear
            if (deletedRowTable != null)
                deletedRowTable.Clear();
        }
        public bool AcceptData()
        {
            //편집중인 값을 반영(성공시 true, 실패시 false, MultiLayout은 Validation Check 필요없음
            return true;
        }
        public int InsertRow(int rowNumber)
        {
            //행 삽입 (rowNumber 가 유효하지 않으면 맨 아래에 삽입)
            //return은 삽입된 행번호의 위치
            DataRow dtRow = layoutTable.NewRow();
            if ((rowNumber < 0) || (rowNumber >= RowCount))
            {
                layoutTable.Rows.Add(dtRow);
                return RowCount - 1;
            }
            else
            {
                layoutTable.Rows.InsertAt(dtRow, rowNumber);
                return rowNumber;
            }
        }
        public bool DeleteRow(int rowNumber)
        {
            if ((rowNumber < 0) || (rowNumber >= RowCount))
            {
                XMessageBox.Show("행번호[" + rowNumber.ToString() + "]를 잘못입력하셨습니다.", "DeleteRow");
                return false;
            }
            DataRow dtRow = layoutTable.Rows[rowNumber];
            //삭제된 데이타를 관리하는 Table에 dtRow Add, 단 Row의 상태가 UnChanged, Modified된 Row만 Add
            //Added상태는 포함하지 않음
            if ((dtRow.RowState == DataRowState.Unchanged) || (dtRow.RowState == DataRowState.Modified))
            {
                if (deletedRowTable == null)
                {
                    deletedRowTable = layoutTable.Copy();
                    deletedRowTable.Clear();
                }
                deletedRowTable.ImportRow(dtRow);
            }
            //해당 행 삭제
            layoutTable.Rows.RemoveAt(rowNumber);

            return true;
        }
        #endregion

        #region GetItemValue, GetItemString ...
        public object GetItemValue(int rowNumber, string colName, bool isOriginal)
        {
            if (isOriginal)
                return GetItemValue(rowNumber, colName, DataBufferType.OriginalBuffer);
            else
                return GetItemValue(rowNumber, colName, DataBufferType.CurrentBuffer);
        }
        public object GetItemValue(int rowNumber, string colName)
        {
            return GetItemValue(rowNumber, colName, DataBufferType.CurrentBuffer);
        }
        public object GetItemValue(int rowNumber, string colName, DataBufferType bufferType)
        {
            object data = DBNull.Value;
            string msg = "";
            if ((rowNumber < 0) || (rowNumber >= RowCount))
            {
                return DBNull.Value;
            }
            if (!this.layoutItems.Contains(colName))
            {
                msg = XMsg.GetMsg("M003") + "[" + colName + "]" + XMsg.GetMsg("M004");//"컬럼명[" + colName + "]을 잘못입력하셨습니다.
                XMessageBox.Show(msg, "GetItemValue");
                return DBNull.Value;
            }
            try
            {
                DataRow dtRow = this.layoutTable.Rows[rowNumber];
                switch (dtRow.RowState)
                {
                    case DataRowState.Added:
                        if (bufferType == DataBufferType.CurrentBuffer) // 현재값
                            data = dtRow[colName];
                        else if (bufferType == DataBufferType.OriginalBuffer) //Added상태는 원래값과 현재값이 동일함.
                            data = dtRow[colName];
                        else // 이전값
                            data = dtRow[colName, DataRowVersion.Current];
                        break;
                    case DataRowState.Unchanged:
                    case DataRowState.Modified:
                        if (bufferType == DataBufferType.CurrentBuffer) // 현재값
                            data = dtRow[colName];
                        else if (bufferType == DataBufferType.OriginalBuffer) //원래값
                            data = dtRow[colName, DataRowVersion.Original];
                        else // 이전값
                            data = dtRow[colName, DataRowVersion.Current];
                        break;
                }
            }
            catch (Exception xe)
            {
                XMessageBox.Show("GetItemValue Error[" + xe.Message + "]", "GetItemValue");
                data = DBNull.Value;
            }
            //2010.05.25 김민수 추가 - 바인딩시 date 타입에 'yyyy/MM/dd' 형태로 들어가도록..
            //2003과 2005의 타입체크 방식이 틀림.
            MultiLayoutItem mItem = this.layoutItems[colName];
            if ((mItem.DataType == DataType.Date) && (TypeCheck.IsDateTime(data)))
                data = DateTime.Parse(data.ToString()).ToString("yyyy/MM/dd").Replace("-", "/");
            else if ((mItem.DataType == DataType.DateTime) && (TypeCheck.IsDateTime(data)))
                data = DateTime.Parse(data.ToString()).ToString("yyyy/MM/dd HH:mm:ss").Replace("-", "/");
            return data;
        }

        public virtual string GetItemString(int rowNumber, string colName)
        {
            return GetItemValue(rowNumber, colName).ToString();
        }
        public virtual string GetItemString(int rowNumber, string colName, bool isOriginal)
        {
            return GetItemValue(rowNumber, colName, isOriginal).ToString();
        }
        public virtual string GetItemString(int rowNumber, string colName, DataBufferType bufferType)
        {
            return GetItemValue(rowNumber, colName, bufferType).ToString();
        }
        public virtual int GetItemInt(int rowNumber, string colName)
        {
            try
            {
                return Int32.Parse(GetItemValue(rowNumber, colName).ToString());
            }
            catch
            {
                string msg = XMsg.GetMsg("M005"); //[GetItemInt]데이타가 Int형이 아닙니다.
                throw (new Exception(msg));
            }
        }
        public virtual int GetItemInt(int rowNumber, string colName, bool isOriginal)
        {
            try
            {
                return Int32.Parse(GetItemValue(rowNumber, colName, isOriginal).ToString());
            }
            catch
            {
                string msg = XMsg.GetMsg("M005"); //[GetItemInt]데이타가 Int형이 아닙니다.
                throw (new Exception(msg));
            }
        }
        public virtual int GetItemInt(int rowNumber, string colName, DataBufferType bufferType)
        {
            try
            {
                return Int32.Parse(GetItemValue(rowNumber, colName, bufferType).ToString());
            }
            catch
            {
                string msg = XMsg.GetMsg("M005"); //[GetItemInt]데이타가 Int형이 아닙니다.
                throw (new Exception(msg));
            }
        }
        public virtual long GetItemLong(int rowNumber, string colName)
        {
            try
            {
                return Int64.Parse(GetItemValue(rowNumber, colName).ToString());
            }
            catch
            {
                string msg = XMsg.GetMsg("M006"); //[GetItemLong]데이타가 Long형이 아닙니다.
                throw (new Exception(msg));
            }
        }
        public virtual long GetItemLong(int rowNumber, string colName, bool isOriginal)
        {
            try
            {
                return Int64.Parse(GetItemValue(rowNumber, colName, isOriginal).ToString());
            }
            catch
            {
                string msg = XMsg.GetMsg("M006"); //[GetItemLong]데이타가 Long형이 아닙니다.
                throw (new Exception(msg));
            }
        }
        public virtual long GetItemLong(int rowNumber, string colName, DataBufferType bufferType)
        {
            try
            {
                return Int64.Parse(GetItemValue(rowNumber, colName, bufferType).ToString());
            }
            catch
            {
                string msg = XMsg.GetMsg("M006"); //[GetItemLong]데이타가 Long형이 아닙니다.
                throw (new Exception(msg));
            }
        }
        public virtual double GetItemDouble(int rowNumber, string colName)
        {
            try
            {
                return double.Parse(GetItemValue(rowNumber, colName).ToString());
            }
            catch
            {
                string msg = XMsg.GetMsg("M007"); //[GetItemDouble]데이타가 Double형이 아닙니다.
                throw (new Exception(msg));
            }
        }
        public virtual double GetItemDouble(int rowNumber, string colName, bool isOriginal)
        {
            try
            {
                return double.Parse(GetItemValue(rowNumber, colName, isOriginal).ToString());
            }
            catch
            {
                string msg = XMsg.GetMsg("M007"); //[GetItemDouble]데이타가 Double형이 아닙니다.
                throw (new Exception(msg));
            }
        }
        public virtual double GetItemDouble(int rowNumber, string colName, DataBufferType bufferType)
        {
            try
            {
                return double.Parse(GetItemValue(rowNumber, colName, bufferType).ToString());
            }
            catch
            {
                string msg = XMsg.GetMsg("M007"); //[GetItemDouble]데이타가 Double형이 아닙니다.
                throw (new Exception(msg));
            }
        }
        public virtual DateTime GetItemDateTime(int rowNumber, string colName)
        {
            return GetItemDateTimeSub(colName, GetItemValue(rowNumber, colName));
        }
        public virtual DateTime GetItemDateTime(int rowNumber, string colName, bool isOriginal)
        {
            return GetItemDateTimeSub(colName, GetItemValue(rowNumber, colName, isOriginal));
        }
        public virtual DateTime GetItemDateTime(int rowNumber, string colName, DataBufferType bufferType)
        {
            return GetItemDateTimeSub(colName, GetItemValue(rowNumber, colName, bufferType));
        }
        private DateTime GetItemDateTimeSub(string colName, object dataValue)
        {
            string msg = XMsg.GetMsg("M008"); //[GetItemDateTime]데이타가 DateTime형이 아닙니다.
            string data = "";
            try
            {
                if (dataValue.GetType() == typeof(DateTime))
                    return (DateTime)dataValue;
                else if (dataValue.GetType() == typeof(string))
                {
                    //Date형(YYYYMMDD), DateTime형(YYYYMMDDHHMI, YYYYMMDDHHMISS)
                    MultiLayoutItem layItem = this.layoutItems[colName];
                    data = dataValue.ToString();
                    if (layItem.DataType == DataType.Date)
                    {
                        if (data.Length == 8)
                        {
                            data = data.Substring(0, 4) + "/" + data.Substring(4, 2) + "/" + data.Substring(6);
                            if (TypeCheck.IsDateTime(data))
                                return DateTime.Parse(data);
                            else
                                throw (new Exception(msg));
                        }
                        else
                            throw (new Exception(msg));
                    }
                    else if (layItem.DataType == DataType.DateTime)
                    {
                        if (data.Length == 14)
                        {
                            data = data.Substring(0, 4) + "/" + data.Substring(4, 2) + "/" + data.Substring(6, 2)
                                + " " + data.Substring(8, 2) + ":" + data.Substring(10, 2) + ":" + data.Substring(12);
                            if (TypeCheck.IsDateTime(data))
                                return DateTime.Parse(data);
                            else
                                throw (new Exception(msg));
                        }
                        else if (data.Length == 12) //YYYYMMDDHHMI
                        {
                            data = data.Substring(0, 4) + "/" + data.Substring(4, 2) + "/" + data.Substring(6, 2)
                                + " " + data.Substring(8, 2) + ":" + data.Substring(10, 2) + ":00";
                            if (TypeCheck.IsDateTime(data))
                                return DateTime.Parse(data);
                            else
                                throw (new Exception(msg));
                        }
                        else
                            throw (new Exception(msg));
                    }
                    else
                    {
                        //Data의 형식이 다름 에러
                        throw (new Exception(msg));
                    }
                }
                else
                {
                    //Data의 형식이 다름 에러
                    throw (new Exception(msg));
                }
            }
            catch
            {
                throw (new Exception(msg));
            }
        }
        #endregion

        #region SetItemValue
        public bool SetItemValue(int rowNumber, string colName, object dataValue)
        {
            string msg = "";
            if ((rowNumber < 0) || (rowNumber >= RowCount))
            {
                msg = XMsg.GetMsg("M009") + "[" + rowNumber.ToString() + "]" + XMsg.GetMsg("M004");//"행번호[" + rowNumber.ToString() + "]를 잘못입력하셨습니다.
                XMessageBox.Show(msg, "SetItemValue");
                return false;
            }
            if (!this.layoutItems.Contains(colName))
            {
               msg = XMsg.GetMsg("M003") + "[" + rowNumber.ToString() + "]" + XMsg.GetMsg("M004");//"행번호[" + rowNumber.ToString() + "]를 잘못입력하셨습니다.
                XMessageBox.Show(msg, "SetItemValue");
                return false;
            }
            try
            {
                //2006.02.20 Date형, DateTime형일때 dataValue가 DateTime형이면 Data를 string으로 변환하여 처리함
                MultiLayoutItem mItem = layoutItems[colName];
                if ((mItem.DataType == DataType.Date) && (dataValue is DateTime))
                    dataValue = ((DateTime)dataValue).ToString("yyyy/MM/dd").Replace("-", "/");
                else if ((mItem.DataType == DataType.DateTime) && (dataValue is DateTime))
                    dataValue = ((DateTime)dataValue).ToString("yyyy/MM/dd HH:mm:ss").Replace("-", "/");
                //2010.08.19 kimminsoo dataValue가 string 타입의 "" 일때도 null 로 취급
                layoutTable.Rows[rowNumber][colName] = ((dataValue == null || dataValue.ToString() == "") ? DBNull.Value : dataValue);
            }
            catch (Exception xe)
            {
                msg = XMsg.GetMsg("M010", xe); //데이타 설정시 에러발생[" + xe.Message + "]"
                XMessageBox.Show(msg, "SetItemValue");
                return false;
            }
            return true;
        }
        #endregion

        #region GetChangedRowCount (Layout의 변경된 건수 GET, aiud는 A.전체, I.Inserted, U.Updated, D.Deleted
        public int GetChangedRowCount(char aiud)
        {
            int delCount = (this.deletedRowTable == null ? 0 : this.deletedRowTable.Rows.Count);
            int addCount = 0;  //추가된 건수
            int modCount = 0;  //변경된 건수
            foreach (DataRow dtRow in this.LayoutTable.Rows)
            {
                if (dtRow.RowState == DataRowState.Added)
                    addCount++;
                else if (dtRow.RowState == DataRowState.Modified)
                    modCount++;
            }
            switch (aiud)
            {
                case 'I':
                    return addCount;
                case 'U':
                    return modCount;
                case 'D':
                    return delCount;
                default:
                    return addCount + modCount + delCount;
            }
        }
        #endregion

        #region Clone, Copy
        /// <summary>
        /// 이 MultiLayout와 동일한 구조를 가지는 MultiLayout를 return합니다.
        /// </summary>
        /// <returns></returns>
        public MultiLayout Clone()
        {
            MultiLayout layout = new MultiLayout();
            //2005.11.11 .Clone - 데이타구조, LayoutTable, CallerID, SavePerformer만 복사
            //Master관계 및 삭제된 Table은 복사하지 않음
            layout.CallerID = this.callerID;
            layout.SavePerformer = this.savePerformer;

            foreach (MultiLayoutItem item in this.layoutItems)
            {
                MultiLayoutItem layItem = new MultiLayoutItem();
                layItem.DataName = item.DataName;
                layItem.DataType = item.DataType;
                layItem.IsNotNull = item.IsNotNull;
                layItem.IsUpdItem = item.IsUpdItem;
                layout.LayoutItems.Add(layItem);
            }
            //LayoutTable 생성
            layout.InitializeLayoutTable();

            return layout;
        }
        /// <summary>
        /// 이 MultiLayout와 동일한 구조,데이타를 가지는 MultiLayout를 return합니다.
        /// </summary>
        /// <returns></returns>
        public MultiLayout Copy()
        {
            MultiLayout layout = this.Clone();

            //LayoutItems가 정의되지 않은 경우은 데이타가 없으므로 바로 Return
            if (layout.LayoutItems.Count < 1) return layout;

            int index = 0;
            DataRow dataRow = null;
            //Data Import
            foreach (DataRow dtRow in this.layoutTable.Rows)
            {
                //Data Add
                layout.LayoutTable.Rows.Add(dtRow.ItemArray);
                dataRow = layout.LayoutTable.Rows[index];
                //DataRow의 상태 설정
                if (dtRow.RowState == DataRowState.Unchanged)
                    dataRow.AcceptChanges();
                else if (dtRow.RowState == DataRowState.Modified)
                {
                    dataRow.AcceptChanges();  //Unchanged
                    dataRow[0] = dataRow[0];  //값을 하나 설정하여 Modified로 변경함
                }
                index++;
            }

            return layout;
        }
        #endregion

        #region SetBindVarValue(QuerySQL의 BindVar에 값 설정)
        public void SetBindVarValue(string varName, string varValue)
        {
            //VarName이 정확하면 VarValue SET
            BindVar bVar = this.bindVarList[varName];
            if (bVar != null)
                bVar.VarValue = varValue;
        }
        //값과 ValueLen 설정
        public void SetBindVarValue(string varName, string varValue, int valueLen)
        {
            //VarName이 정확하면 VarValue SET
            BindVar bVar = this.bindVarList[varName];
            if (bVar != null)
            {
                bVar.VarValue = varValue;
                bVar.ValueLen = valueLen;
            }
        }
        #endregion
    }

    #region MultiRecordEventArgs(저장전 PreSaveLayout에서 조건에 따른 데이타 설정 Event)
    /// <summary>
    /// 서비스로 보낼 자료작성전 발생 이벤트를 처리하는 메서드를 나타냅니다.
    /// </summary>
    [Serializable]
    public delegate void MultiRecordEventHandler(object sender, MultiRecordEventArgs e);

    /// <summary>
    /// 서비스로 보낼 자료작성전 발생 이벤트에 데이타를 제공합니다.
    /// </summary>
    public class MultiRecordEventArgs : EventArgs
    {
        DataRowState rowState;
        int rowNumber;

        /// <summary>
        /// 현재 Data의 상태를 가져옵니다.
        /// </summary>
        public DataRowState RowState
        {
            get { return rowState; }
        }
        /// <summary>
        /// 현재 Data의 행번호를 가져옵니다.
        /// </summary>
        public int RowNumber
        {
            get { return rowNumber; }
        }
        /// <summary>
        /// RecordEventArgs 생성자
        /// </summary>
        /// <param name="iud"> 행의 상태 DataRowState</param>
        /// <param name="rowNumber"> 행번호 </param>
        public MultiRecordEventArgs(DataRowState rowState, int rowNumber)
        {
            this.rowState = rowState;
            this.rowNumber = rowNumber;
        }
    }
    #endregion

    #region MultiLayoutDesigner
    internal class MultiLayoutDesigner : System.ComponentModel.Design.ComponentDesigner
    {
        private MultiLayout layout = null;
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
            layout = (MultiLayout)component;

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
                MultiLayoutItem item = null;
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
}
