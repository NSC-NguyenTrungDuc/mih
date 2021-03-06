using System;
using System.Collections.Generic;
using System.Xml;
using System.IO;
using System.Text;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Drawing.Printing;
using System.Drawing.Drawing2D;
using System.Drawing.Design;
using System.Data;
using System.Data.OracleClient;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace IHIS.Framework
{
	/// <summary>
	/// XFindGrid(FindForm에서만 사용)에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	[DefaultProperty("TableStyles")]
	[DefaultEvent("GridColumnChanged")]
	internal class XFindGrid : XDataGrid
	{
		#region Fields
		const int MSG_CONT_CALL = (int) Win32.Msgs.WM_USER + 5;
		const   int QUERY_RECORD_UNIT = 200;  //한번 조회시에 Record 건수(200건씩 조회)
		//private IDataReader dataReader = null; //For Oracle 조회
	    private IList<object[]> findData;
		//private DataTable sourceTable = null;  //For SqlServer 조회
		//private int sourceRowIndex = 0;        //For SqlServer 조회 
		private bool isQueryCompleted = true; //조회 완료여부
		//private string querySQL = "";  //조회 SQL
	    private ExecuteQueryData queryDataDelegate;
        private List<string> paramList = new List<string>();
        private int mPage = 1;

	    public List<string> ParamList
	    {
	        get { return paramList; }
	        set
	        {
	            paramList = value;
                SQLHelper.InitBindVarListFromParamList(paramList, this.bindVarList);
                bindVarList.Add("f_offset", QUERY_RECORD_UNIT.ToString());
                if (this.bindVarList.Contains("f_page_number"))
                {
                    this.bindVarList["f_page_number"].VarValue = this.mPage.ToString();
                }
	        }
	    }

	    public ExecuteQueryData QueryDataDelegate
	    {
	        get { return queryDataDelegate; }
	        set { queryDataDelegate = value; }
	    }

	    private BindVarCollection bindVarList = new BindVarCollection(); //조회 SQL의 Bind변수 관리
		#endregion

		#region Property
		[Browsable(true), DefaultValue(typeof(Font), "MS UI Gothic, 9.75pt")]
		public override Font Font
		{
			get	{ return base.Font;	}
			set	{ base.Font = value;}
		}
		/*[Browsable(true), DefaultValue("")]
		public string QuerySQL
		{
			get { return querySQL;}
			set 
			{
				querySQL = value;
				//RunTime시에 SQL에 포함된 bindVar 분석
				if (!this.DesignMode)
				{
					SQLHelper.InitBindVarList(querySQL, this.bindVarList);
				}
			}
		}*/
		#endregion

		#region 생성자
		public XFindGrid()
		{
			this.Scroll += new EventHandler(VScrollChanged);  //Scroll Event Handler
			this.Font = new Font("MS UI Gothic", 9.75f);
		}
		#endregion


		#region 연속조회 메세지 관련
		private void VScrollChanged(object sender, EventArgs e)
		{
			// VertScrollBar 의 Maxinum은 DataTable의 Row수와 같음. Row를 추가할수록 Max도 함께 증가
			// Value도 Row단위로 움직임, 아래로 내릴때 Value가 1씩 증가.(Bar의 윗부분의 위치)
			// LargeChange는 ScrollBar에서 Bar부분이 차이하는 Row의 수
			// 따라서, Bar가 맨 아래에 오게되면 Value + LargeChange = Max + 1이 된다. 이때 ContCall 발생시킴
			// ContCall을 바로 Call하게 되면 ContCall후에 Scroll Event의 다른 동작이 발생하여 계속 ContCall을 부르는 현상이 발생함
			// 따라서, ContCall을 Post Message하여 Scroll 완료후에 발생하도록 수정함
            //2006.07.27 조회 미완료시만 MSG_CONT_CALL CALL
            if (!this.isQueryCompleted && (this.VertScrollBar.Value + this.VertScrollBar.LargeChange > this.VertScrollBar.Maximum))
			{
                mPage++;
                if (this.bindVarList.Contains("f_page_number"))
                {
                    this.bindVarList["f_page_number"].VarValue = this.mPage.ToString();
                }
				User32.PostMessage(this.Handle, MSG_CONT_CALL, 0, 0);
			}
		}
		protected override void WndProc(ref Message msg)
		{
			// 연속조회 Post Call
			if (msg.Msg == MSG_CONT_CALL)
			{
				int scrollValue = this.VertScrollBar.Value;
				// 연속조회 처리
                QueryData(false);
				GridVScrolled(this.VertScrollBar, new ScrollEventArgs(ScrollEventType.ThumbPosition, scrollValue));
			}

			base.WndProc(ref msg);
		}
		#endregion

		#region override Reset
		public override void Reset()
		{
			base.Reset();

			//기존 DataReader가 있을때 이미 Open되어 있으면 Close
            if ((this.findData != null))
			{
                this.findData = null;
			}
			//this.sourceTable = null;
			//this.sourceRowIndex = 0;

		}
		#endregion

		#region executeQuery
		public void QueryData(bool isAllDataQuery)
		{
			//<미확정> SqlServer 이외에는 Oracle (DataReader사용)
			/*if (Service.CurrentDBKind == DataBaseKind.SqlServer)
				QueryDataForSqlServer(isAllDataQuery);
			else*/
            QueryDataForOracle(isAllDataQuery);
		}
		protected virtual void QueryDataSub(bool isAllDataQuery)
		{
			//<미확정> SqlServer 이외에는 Oracle (DataReader사용)
			/*if (Service.CurrentDBKind == DataBaseKind.SqlServer)
				QueryDataSubForSqlServer(isAllDataQuery);
			else*/
				QueryDataSubForOracle(isAllDataQuery);
		}
		private void QueryDataForOracle(bool queryAllData)
		{
			//Layout Reset
            if (mPage <= 1)
            {
                this.Reset();
            }

			if (this.queryDataDelegate == null) return;
			
			this.isQueryCompleted = true; //조회 완료됨

			//기존 DataReader가 있을때 이미 Open되어 있으면 Close
			if ((this.findData != null))
			{
				this.findData = null;
			}
            
			//DataReader Get
			this.findData = QueryDataDelegate(this.bindVarList);
			//SQL 에러
            if (findData == null)
			{
				this.ShowErrMsg(Service.ErrMsg);
				return;
			}
			//조회된 데이타가 없으면 Return
			/*IDataReader는 HasRows 속성이 없고, 상속한 Class만 가지고 있다. 나머지 Read, GetValues()는 IDataReader로
			 * 사용하고 HasRows판단은 각 Class로 변환하여 판단하자 */
            bool hasRows = findData.Count > 0;

			if (!hasRows) return;

			QueryDataSub(queryAllData);
		}
		private void QueryDataSubForOracle(bool queryAllData)
		{

			try
			{
				// Data Setting시 시간 줄이기
				// Grid의 DataSource가 dtblGrid로 되어있는 상태에서 NewRow를 통해 Add를 하게 되면, 한번 Add시마다
				// Paint, Commit등 여러 Event가 발생하므로 Import시간이 많이 걸리게 된다.
				// 따라서, 시간을 줄이기 위해 DataSource를 이전 DataTable로 설정후에 Add후에 다시 설정하자.
				DataTable gridTable = this.DataSource;
				DataTable tempTable = this.DataSource.Clone();
				this.DataSource = tempTable;

				//DataReader에서 데이타를 읽어서 100건씩 담음
			
				//조회된 데이타로 LayoutTable에 담음, OrigDataTable에도 함께 담음
				DataRow dtRow = null;
				//받는 데이타 컬럼의 갯수는 Table 컬럼의 갯수
				int dataCount = 0;
				int rowCount = 0;
                foreach (object[] readDatas in findData)
			    {
                    dtRow = gridTable.NewRow();
                    dataCount = readDatas.Length;
                    for (int i = 0; i < gridTable.Columns.Count; i++)
                    {
                        if (dataCount > i)  //Data 갯수 Check
                            dtRow[i] = readDatas[i];
                    }
                    gridTable.Rows.Add(dtRow);
                    rowCount++;
                    //전체조회가 아니고 단위 조회당 건수(200건) 보다 크면 Break
                    if (!queryAllData && (rowCount >= QUERY_RECORD_UNIT))
                    {
                        this.isQueryCompleted = false; //계속조회중
                        break;
                    }   
			    }
				//데이타 모두 조회이면 조회 완료 Flag Set
				if (queryAllData || (rowCount < QUERY_RECORD_UNIT))
				{
					this.isQueryCompleted = true;
				}
			
				//ResetUpdate
				gridTable.AcceptChanges();

				// DataSource 다시 설정
				this.DataSource = gridTable;
				
			}
			catch(Exception xe)
			{
				this.isQueryCompleted = true;
				this.ShowErrMsg(xe.Message);
			}
			finally
			{
				//조회 완료시는 Reader Close
				if (this.isQueryCompleted && this.findData != null)
				{
					this.findData = null;
				}
			}

		}

		//For SqlServer
		/*private void QueryDataForSqlServer(bool queryAllData)
		{
			//Layout Reset
			this.Reset();

			if (this.querySQL == "") return;

			this.isQueryCompleted = true; //조회 완료됨

			//DataTable Get
			sourceTable = Service.ExecuteDataTable(this.querySQL, this.bindVarList);
			//SQL 에러
			if (sourceTable == null)
			{
				this.ShowErrMsg(Service.ErrMsg);
				return ;
			}

			//조회된 데이타가 없으면 Return
			if (sourceTable.Rows.Count < 1)
				return;

			QueryDataSubForSqlServer(queryAllData);
		}
		private void QueryDataSubForSqlServer(bool queryAllData)
		{

			try
			{
				// Data Setting시 시간 줄이기
				// Grid의 DataSource가 dtblGrid로 되어있는 상태에서 NewRow를 통해 Add를 하게 되면, 한번 Add시마다
				// Paint, Commit등 여러 Event가 발생하므로 Import시간이 많이 걸리게 된다.
				// 따라서, 시간을 줄이기 위해 DataSource를 이전 DataTable로 설정후에 Add후에 다시 설정하자.
				DataTable gridTable = this.DataSource;
				DataTable tempTable = this.DataSource.Clone();
				this.DataSource = tempTable;

				//DataReader에서 데이타를 읽어서 100건씩 담음

				//조회된 데이타로 LayoutTable에 담음, OrigDataTable에도 함께 담음
				DataRow dtRow = null, dataRow = null;
				//컬럼 갯수만큼 할당
				int dataCount = sourceTable.Columns.Count;
				int rowCount = 0;
				for (int i = this.sourceRowIndex; i < this.sourceTable.Rows.Count; i++)
				{
					dataRow = sourceTable.Rows[i];
					dtRow = gridTable.NewRow();
					for (int colIndex = 0; colIndex < gridTable.Columns.Count; colIndex++)
					{
						if (dataCount > colIndex)  //Data 갯수 Check
							dtRow[colIndex] = dataRow[colIndex];
					}
					gridTable.Rows.Add(dtRow);
					rowCount++;
					//sourceIndex 증가
					this.sourceRowIndex++;
					//전체조회가 아니고 단위 조회당 건수(200건) 보다 크면 Break
					if (!queryAllData && (rowCount >= QUERY_RECORD_UNIT))
					{
						this.isQueryCompleted = false; //계속조회중
						break;
					}
				}
				//데이타 모두 조회이면 조회 완료 Flag Set
				if (queryAllData || (rowCount < QUERY_RECORD_UNIT))
				{
					this.isQueryCompleted = true;
				}

				//ResetUpdate
				gridTable.AcceptChanges();

				// DataSource 다시 설정
				this.DataSource = gridTable;

			}
			catch (Exception xe)
			{
				this.isQueryCompleted = true;
				this.ShowErrMsg(xe.Message);
			}
		}*/
		#endregion

		#region SetBindVarValue
		public void SetBindVarValue(string varName, string varValue)
		{
			//VarName이 정확하면 VarValue SET
			BindVar bVar = this.bindVarList[varName];
			if (bVar != null)
				bVar.VarValue = varValue;
		}
		#endregion
	}
}
