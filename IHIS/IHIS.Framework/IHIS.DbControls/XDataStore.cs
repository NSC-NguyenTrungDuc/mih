using System;
using System.IO;
using System.Text;
using System.Data;
using System.Reflection;
using System.Windows.Forms;
using System.Collections;
using System.Diagnostics;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.ComponentModel.Design;
using System.Windows.Forms.Design;
using System.Runtime.InteropServices;
using Sybase.DataWindow;

namespace IHIS.Framework
{
	/// <summary>
	/// XDataStore에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxBitmap(typeof(IHIS.Framework.XDataStore),"Images.XDataWindow.bmp")]
	public class XDataStore : Sybase.DataWindow.DataStore
	{
		#region Fields
		const string TAB = "\t";  //필드구분자
		const string NL  = "\n";  //레코드구분자
		private DWColunmInfoCollection columnList = new DWColunmInfoCollection();
		private Hashtable childColumnList = new Hashtable();
		private string errMsg = "";  //동작간 발생한 에러에 대한 메세지
		#endregion
		
		#region Property
		/// <summary>
		/// 동작간 발생한 에러메세지를 가져옵니다.
		/// </summary>
		[Browsable(false)]
		public string ErrMsg
		{
			get { return errMsg;}
		}
		#endregion

		#region 생성자
		public XDataStore()
		{
		}
		#endregion

		#region FillData
		/// <summary>
		/// DataTable의 데이타로 DataWindow에 Data를 채웁니다.
		/// </summary>
		/// <param name="sourceTable"> DataTable </param>
		/// <returns></returns>
		public virtual bool FillData(DataTable sourceTable)
		{
			if (sourceTable == null) return false;
			if (sourceTable.Rows.Count < 1) return false;
			string msg = "";
			
			try
			{
				//데이타를 채울 컬럼 List Set
				if (!SetColumnList()) return false;
				
				StringBuilder sb = new StringBuilder();
				//Data Fill
				int idx = 0;
				foreach (DataRow dtRow in sourceTable.Rows)
				{
					foreach (DWColumnInfo info in this.columnList)
					{
						if (sourceTable.Columns.Contains(info.ColName)) //대소문자구분하지 않음
						{
							//DataTable에 저장된 값을 ImportString가능하도록 변환하여 String생성
							sb.Append(ConvertData(sourceTable.Columns[info.ColName].DataType, info.ColType, dtRow[info.ColName])	+ TAB);
						}
						else // 없으면 구분자만 설정
							sb.Append(TAB);
					}
					idx++;
					//마지막에 행구분자 Add
					sb.Append(NL);
				}
				//ImportString
				this.ImportString(sb.ToString(), Sybase.DataWindow.FileSaveAsType.Text);
				//ResetUpdate
				this.ResetUpdateStatus();
				//Group Calculate
				this.CalculateGroups();
			}
			catch(Exception xe)
			{
				msg = XMsg.GetMsg("M011", xe); //FillData 에러[" + xe.Message + "]"
				ShowErrMsg(msg);
				return false;
			}
			return true;
		}
		/// <summary>
		/// DataRow Array로 DataWindow를 채웁니다.
		/// </summary>
		/// <param name="sourceRows"> DataRow[] </param>
		/// <returns> 성공시 true, 실패시 false </returns>
		public virtual bool FillData(DataRow[] sourceRows)
		{
			//한건도 없으면 Return
			if (sourceRows.Length < 1) return false;
			//DataRow의 Table이 없으면 return
			if (sourceRows[0].Table == null ) return false;
			string msg = "";
			
			try
			{
				//데이타를 채울 컬럼 List Set (실패시 return)
				if (!SetColumnList()) return false;

				//sourceRows의 DataTable의 컬럼리스트 SET, Key는 컬럼명, 값은 DataType(컬럼Type)을 저장
				//컬럼명은 대소문자 구분하지 않기 위해 Upper로 SET
				Hashtable sourceColumnList = new Hashtable();
				foreach (DataColumn dtCol in sourceRows[0].Table.Columns)
					sourceColumnList.Add(dtCol.ColumnName.ToUpper(), dtCol.DataType);
				//Source컬럼List에 값이 없으면 Return
				if (sourceColumnList.Count < 1)
				{
					msg = XMsg.GetMsg("M012") + "[FillData]";  //"전달한 테이블에 컬럼이 없습니다.[FillData]"
					ShowErrMsg(msg);
					return false;
				}
				
				StringBuilder sb = new StringBuilder();
				//Data Fill
				foreach (DataRow dtRow in sourceRows)
				{
					foreach (DWColumnInfo info in this.columnList)
					{
						//DataWindow에 지정된 컬럼과 DataTable의 컬럼이 일치하면
						if (sourceColumnList.Contains(info.ColName.ToUpper())) //대소문자구분하지 않음
						{
							//DataTable에 저장된 값을 ImportString가능하도록 변환하여 String생성
							sb.Append(ConvertData((Type) sourceColumnList[info.ColName.ToUpper()], info.ColType, dtRow[info.ColName])	+ TAB);
						}
						else // 없으면 구분자만 설정
							sb.Append(TAB);
					}
					//마지막에 행구분자 Add
					sb.Append(NL);
				}
				//ImportString
				this.ImportString(sb.ToString(), Sybase.DataWindow.FileSaveAsType.Text);
				//ResetUpdate
				this.ResetUpdateStatus();
				//Group Calculate
				this.CalculateGroups();
			}
			catch(Exception xe)
			{
				msg = XMsg.GetMsg("M011", xe); //FillData 에러[" + xe.Message + "]"
				ShowErrMsg(msg);
				return false;
			}
			return true;
		}
		#endregion

		#region FillChildData, FillGroupedChildData
		/// <summary>
		/// DataTable의 데이타로 DataWindowChild에 Data를 채웁니다.
		/// </summary>
		/// <param name="sourceTable"> DataTable </param>
		/// <returns></returns>
		public virtual bool FillChildData(string childName, DataTable sourceTable)
		{
			if (sourceTable == null) return false;
			if (sourceTable.Rows.Count < 1) return false;
			string msg = "";

			//지정한 ChildName을 가진 DataWindowChild가 존재하는 여부 Check
			Sybase.DataWindow.DataWindowChild dwChild = null;
			try
			{
				dwChild = this.GetChild(childName);
			}
			catch(Exception e)
			{
				msg = XMsg.GetMsg("M013", e); //"FillChildData 에러[" + e.Message + "]"
				ShowErrMsg(msg);
				return false;
			}
			
			try
			{
				//Child 컬럼List Set (실패시 return)
				if (!this.SetChildColumnList(childName, dwChild)) return false;
				
				
				
				StringBuilder sb = new StringBuilder();
				//Data Fill
				foreach (DataRow dtRow in sourceTable.Rows)
				{
					foreach (DWColumnInfo info in (DWColunmInfoCollection) this.childColumnList[childName])
					{
						if (sourceTable.Columns.Contains(info.ColName))
						{
							//DataTable에 저장된 값을 ImportString가능하도록 변환하여 String생성
							sb.Append(ConvertData(sourceTable.Columns[info.ColName].DataType, info.ColType, dtRow[info.ColName])	+ TAB);
						}
						else // 없으면 구분자만 설정
							sb.Append(TAB);
					}
					//마지막에 행구분자 Add
					sb.Append(NL);
				}

				//ImportString
				dwChild.ImportString(sb.ToString(), Sybase.DataWindow.FileSaveAsType.Text);
				//ResetUpdate
				dwChild.ResetUpdateStatus();
				//Group Calculate
				dwChild.CalculateGroups();
			}
			catch(Exception xe)
			{
				msg = XMsg.GetMsg("M013", xe); //"FillChildData 에러[" + e.Message + "]"
				ShowErrMsg(msg);
				return false;
			}
			return true;
		}
		/// <summary>
		/// DataTable로 Grouping된 Child DataWindow를 채웁니다.
		/// </summary>
		/// <param name="childName"> Child DW Name </param>
		/// <param name="sourceTable"></param>
		/// <returns> 성공시 true, 실패시 false </returns>
		public virtual bool FillGroupedChildData(string childName, DataTable sourceTable)
		{
			if (sourceTable == null) return true;
			if (sourceTable.Rows.Count < 1) return true;
			string msg = "";

			//지정한 ChildName을 가진 DataWindowChild가 존재하는 여부 Check
			Sybase.DataWindow.DataWindowChild dwChild = null;
			try
			{
				dwChild = this.GetChild(childName);
			}
			catch(Exception e)
			{
				msg = XMsg.GetMsg("M014", e); //"FillGroupedChildData 에러[" + e.Message + "]"
				ShowErrMsg(msg);
				return false;
			}
			
			try
			{
				//Child 컬럼List Set (실패시 return)
				if (!this.SetChildColumnList(childName, dwChild)) return false;
				
				int rowNum = 0;
				object setData = null;
				//Data Fill
				foreach (DataRow dtRow in sourceTable.Rows)
				{
					rowNum = dwChild.InsertRow(dwChild.RowCount + 1);
					foreach (DWColumnInfo info in (DWColunmInfoCollection) this.childColumnList[childName])
					{
						if (sourceTable.Columns.Contains(info.ColName))
						{
							setData = ConvertData(info.ColType, dtRow[info.ColName]);
							//Null은 NullSet 나머지는 컬럼Type에 따라 SET, Number형은 모두 Decimal로 통일
							//Date형은 모두 DateTime으로 통일
							if (setData == null) //Null은 SetItemNull Set
								dwChild.SetItemNull(rowNum, info.ColName);
							else if (info.ColType == DWColType.String)
								dwChild.SetItemString(rowNum, info.ColName, (string) setData);
							else if ((info.ColType == DWColType.Number) ||(info.ColType == DWColType.Decimal)||(info.ColType == DWColType.Long)||(info.ColType == DWColType.Ulong))
								dwChild.SetItemDecimal(rowNum, info.ColName, (decimal) setData);
							else if (info.ColType == DWColType.Date)
								dwChild.SetItemDate(rowNum, info.ColName, (DateTime) setData);
							else if (info.ColType == DWColType.DateTime)
								dwChild.SetItemDateTime(rowNum, info.ColName, (DateTime) setData);
							else if (info.ColType == DWColType.Time)
								dwChild.SetItemTime(rowNum, info.ColName, (DateTime) setData);
						}
					}
				}
				//ResetUpdate
				dwChild.ResetUpdateStatus();
				//Group Calculate
				dwChild.CalculateGroups();
			}
			catch(Exception xe)
			{
				msg = XMsg.GetMsg("M014", xe); //"FillGroupedChildData 에러[" + e.Message + "]"
				ShowErrMsg(msg);
				return false;
			}
			return true;
		}
		#endregion

		#region Export,ShowToExcel
		/// <summary>
		/// Excel로 보기
		/// </summary>
		public virtual void ShowToExcel()
		{
			ExportSub(false, true);
		}
		/// <summary>
		/// Export
		/// </summary>
		/// <param name="runExcel"> Excel Run 여부 </param>
		public virtual void Export(bool runExcel)
		{
			ExportSub(true,true);
		}
		public virtual void Export()
		{
			ExportSub(true,false);
		}
		protected virtual void ExportSub(bool isSaveFile, bool runExcel)
		{
			try
			{
				string fileName = "";

				//파일을 Save하면 파일명칭지정하는 Dialog Show
				if (isSaveFile)
				{
					//Excel.ExcelApp를 사용하면 Interop.Excel등 다른 dll참조해야하고, 또한
					//Excel을 띄우게 되므로 html형식으로 Excel파일을 만듦
					SaveFileDialog dlg = new SaveFileDialog();
					dlg.Filter = "Excel files (*.xls)|*.xls"  ;
					dlg.FilterIndex = 1 ;
					dlg.RestoreDirectory = true ;
					if(dlg.ShowDialog() != DialogResult.OK)
						return;

					fileName = dlg.FileName;
				}
				else
				{
					//미지정이면 현재 Drive에 Temp Dir에 현재시간.xls 파일로 생성
					string path = Application.StartupPath.Substring(0,1) + ":\\Temp";
					if (!Directory.Exists(path))
						Directory.CreateDirectory(path);
					fileName = path + "\\" + DateTime.Now.ToString("HHmmss") + ".xls";
				}
				
				//확장자는 xls로 하고 TAB Seperated Text로 저장
				this.SaveAs(fileName, FileSaveAsType.Text, true, FileSaveAsEncoding.Ansi);

				//Excel Run
				try
				{
					if (runExcel)
					{
						//Dir명이 Space가 들어가 있는 경우에 대비하여 arguments를 전달시에 양쪽을 ""로 묶음
						Process.Start("EXCEL.exe", "\"" + fileName + "\"");
					}
				}
				catch (Exception xe)
				{
					Debug.WriteLine("ExportSub Run Excel error=" + xe.Message);
				}
			}
			catch(Exception e)
			{
				string msg = XMsg.GetMsg("M015", e); //"Export 에러[" + e.Message + "]"
				ShowErrMsg(msg);
			}
		}
		#endregion

		#region SetColumnList, SetChildColumnList
		private bool SetColumnList()
		{
			//DataWindowObject에서 컬럼을 조회하여 컬럼 List 구성
			//기존 컬럼 List Clear
			this.columnList.Clear();
			string msg = "";
			if (this.DataWindowObject == string.Empty)
			{
				msg = XMsg.GetMsg("M016"); //DataWindowObject가 지정되지 않았습니다.
				ShowErrMsg(msg);
				return false;
			}
			try
			{
				//Tab Seperated Column List Get
				string desc = this.Describe("DataWindow.Table.Columns");
				string[] columns = desc.Split(new char[]{'\t'});
				string colType = "";
				DWColType dwColType = DWColType.String;
				//컬럼 List에서 컬럼정보 GET (컬럼이 지정된 순서대로)
				foreach (string column in columns)
				{
					//컬럼Type이 datetime형이면 isDateTime true, 그외는 false
					colType = this.Describe(column + ".ColType");
					//string형은 char(10), decimal형은 decimal(2) 형식으로 Describe됨
					if (colType.IndexOf("char") >= 0)
						dwColType = DWColType.String;
					else if (colType == "number")
						dwColType = DWColType.Number;
					else if (colType.IndexOf("decimal") >= 0)
						dwColType = DWColType.Decimal;
					else if (colType == "date")
						dwColType = DWColType.Date;
					else if (colType == "datetime")
						dwColType = DWColType.DateTime;
					else if (colType == "time")
						dwColType = DWColType.Time;
					else if (colType == "long")
						dwColType = DWColType.Long;
					else if (colType == "ulong")
						dwColType = DWColType.Ulong;
					else
						dwColType = DWColType.String;
					this.columnList.Add(column, dwColType);
				}
			}
			catch(Exception xe)
			{
				msg = XMsg.GetMsg("M017",xe); //DataWindow SetColumnList 에러["+  xe.Message + "]"
				ShowErrMsg(msg);
				Debug.WriteLine("SetColumnList Error=" + xe.Message);
				return false;
			}
			//데이타를 채울 컬럼 존재여부 
			if (this.columnList.Count < 1)
			{
				msg = XMsg.GetMsg("M018") + "[SetColumnList]"; //데이타를 채울 컬럼이 지정되지 않았습니다.[SetColumnList]
				ShowErrMsg(msg);
				return false;
			}
			return true;
		}
		private bool SetChildColumnList(string childName, DataWindowChild dwChild)
		{
			if (dwChild == null) return false;
			string msg = "";

			//childName을 가진 컬럼List가 있으면 기존 컬럼List Clear
			if (this.childColumnList.Contains(childName))
				((DWColunmInfoCollection) this.childColumnList[childName]).Clear();
			else  //없으면 새로 생성
			{
				DWColunmInfoCollection colList = new DWColunmInfoCollection();
				this.childColumnList.Add(childName, colList);
			}
			DWColunmInfoCollection childColumnList = (DWColunmInfoCollection) this.childColumnList[childName];
			
			try
			{
				//Tab Seperated Column List Get
				string desc = dwChild.Describe("DataWindow.Table.Columns");
				string[] columns = desc.Split(new char[]{'\t'});
				string colType = "";
				DWColType dwColType = DWColType.String;
				//컬럼 List에서 컬럼정보 GET (컬럼이 지정된 순서대로)
				foreach (string column in columns)
				{
					//컬럼Type이 datetime형이면 isDateTime true, 그외는 false
					colType = dwChild.Describe(column + ".ColType");
					//string형은 char(10), decimal형은 decimal(2) 형식으로 Describe됨
					if (colType.IndexOf("char") >= 0)
						dwColType = DWColType.String;
					else if (colType == "number")
						dwColType = DWColType.Number;
					else if (colType.IndexOf("decimal") >= 0)
						dwColType = DWColType.Decimal;
					else if (colType == "date")
						dwColType = DWColType.Date;
					else if (colType == "datetime")
						dwColType = DWColType.DateTime;
					else if (colType == "time")
						dwColType = DWColType.Time;
					else if (colType == "long")
						dwColType = DWColType.Long;
					else if (colType == "ulong")
						dwColType = DWColType.Ulong;
					else
						dwColType = DWColType.String;
					childColumnList.Add(column, dwColType);
				}
			}
			catch(Exception xe)
			{
				msg = XMsg.GetMsg("M019",xe); //DataWindow SetChildColumnList 에러["+  xe.Message + "]"
				ShowErrMsg(msg);
				Debug.WriteLine("SetChildColumnList Error=" + xe.Message);
				return false;
			}

			//해당 Child의 컬럼List가 존재하지 않으면 Return
			if (!this.childColumnList.Contains(childName))
			{
				msg = XMsg.GetMsg("M020") + "[" + childName + "]" + XMsg.GetMsg("M021") + "[SetChildColumnList]"; //"지정한 ChildName[" + childName + "]이 존재하지 않습니다.[SetChildColumnList]"
				ShowErrMsg(msg);
				return false;
			}
			else if (((DWColunmInfoCollection) this.childColumnList[childName]).Count < 1)
			{
				msg = XMsg.GetMsg("M018") + "[SetChildColumnList]"; //데이타를 채울 컬럼이 지정되지 않았습니다.[SetColumnList]
				ShowErrMsg(msg);
				return false;
			}
			return true;

		}
		#endregion

		#region ConvertData
		private string ConvertData(Type columnType, DWColType dwColType, object data)
		{
			if (data == null) return "";
			if (data == DBNull.Value) return "";
			if (data.ToString() == "") return "";
			
			string strData = "";
			if (columnType == typeof(System.DateTime))
			{
				try
				{
					if (dwColType == DWColType.DateTime)
						strData = ((DateTime) data).ToString("yyyy-MM-dd HH:mm:ss");
					else
						strData = ((DateTime) data).ToString("yyyy-MM-dd");
				}
				catch
				{
					strData = "";
				}
			}
			else if (columnType == typeof(System.TimeSpan))
			{
				//TimeSpan형식은 HH:MI:SS:FFFFF형으로 변환
				try
				{
					TimeSpan tm = (TimeSpan) data;
					strData = tm.Hours.ToString("00") + ":" + tm.Minutes.ToString("00") + ":" + tm.Seconds.ToString() + ":" + tm.Milliseconds.ToString("00000");
				}
				catch
				{
					strData = "";
				}
			}
			else
			{
				try
				{
					//2005.06.15 data가 byte[]이면(Server에서 깨진문자를 Binary형식으로 보냄) String으로 변환하여 처리함.
					if ((columnType == typeof(object)) && data is byte[])
					{
						byte[] binary = data as byte[];
						strData = Encoding.Default.GetString(binary);
					}
					else
					{
						strData = data.ToString();
						//String일때 문자열내에 TAB, NL이 있으면 ""로 묶음
						if (columnType == typeof(string))
						{
							//문자열속에 ""있는 데이타는 에러가 발생함.( A ~"BBB~" C로 묶으면 PB에서는 되나, DW.NET은 안됨)
							//Data에 TAB, NL이 들어가 있으면 전체를 ""로 묶어서 처리해야함
							if ((strData.IndexOf(TAB) >= 0) || (strData.IndexOf(NL) >= 0))
								strData = "\"" + strData + "\"";
						}
					}
				}
				catch
				{
					strData = "";
				}
			}
			return strData;
		}
		private object ConvertData(DWColType dwColType, object data)
		{
			if (data == null) return "";
			if (data == DBNull.Value) return "";
			if (data.ToString() == "") return "";
			
			object returnData = null;
			switch (dwColType)
			{
				case DWColType.String:
					try
					{
						string strData = data.ToString();
						//Data에 TAB, NL이 들어가 있으면 전체를 ""로 묶어서 처리해야함
						if ((strData.IndexOf(TAB) >= 0) || (strData.IndexOf(NL) >= 0))
							returnData = "\"" + strData + "\"";
						else
							returnData = strData;
					}
					catch
					{
						returnData = "";
					}
					break;
				case DWColType.Number:
				case DWColType.Decimal:
				case DWColType.Long:
				case DWColType.Ulong:
					//Number형은 decimal로 통일
					try
					{
						returnData = Decimal.Parse(data.ToString());
					}
					catch
					{
						returnData = null;
					}
					break;
				case DWColType.Date:
					try
					{
						string dateStr = data.ToString();
						if (TypeCheck.IsDateTime(dateStr))
						{
							returnData = DateTime.Parse(dateStr);
						}
						else if (dateStr.Length == 8) // YYYYMMDD형
						{
							returnData = DateTime.Parse(dateStr.Substring(0,4) + "/" + dateStr.Substring(4,2) + "/" + dateStr.Substring(6));
						}
						else
							returnData = "";
					}
					catch
					{
						returnData = "";
					}
					break;
				case DWColType.DateTime:
					try
					{
						string dateStr = data.ToString();
						if (TypeCheck.IsDateTime(dateStr))
						{
							returnData = DateTime.Parse(dateStr);
						}
						else if (dateStr.Length == 14) // YYYYMMDDHHMISS형
						{
							returnData = DateTime.Parse(dateStr.Substring(0,4) + "/" + dateStr.Substring(4,2) + "/" + dateStr.Substring(6,2) + 
								" " + dateStr.Substring(8,2) + ":" + dateStr.Substring(10,2) + ":" + dateStr.Substring(12));
						}
						else
							returnData = "";
					}
					catch
					{
						returnData = "";
					}
					break;

				case DWColType.Time:
					//Date형은 DateTime으로 통일
					try
					{
						returnData = (DateTime) data;
					}
					catch
					{
						returnData = null;
					}
					break;
				default:
					try
					{
						returnData = data.ToString();
					}
					catch
					{
						returnData = null;
					}
					break;
			}
			return returnData;
		}
		#endregion

		#region ShowErrMsg
		private bool ParentIsILayoutContainer(Control parent, out Control parentControl)
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
		protected void ShowErrMsg(string msg)
		{
			//에러메세지 설정
			this.errMsg = msg;
			//Parent가 ILayoutContainer이면 ILayoutContainer의 SetMsg Call, 없으면 MsgBox
			//일단은 MSGBox로 통일함
			XMessageBox.Show(msg, "XDataStore");

//			Control parentControl = null;
//			if(ParentIsILayoutContainer(this.Parent, out parentControl))
//			{
//				((ILayoutContainer) parentControl).SetMsg(msg, MsgType.Error);
//			}
//			else
//				XMessageBox.Show(msg);
		}
		#endregion

		#region SetObjectText, SetObjectImage
		//DataWindow의 Text Object의 Text를 지정합니다.
		public void SetObjectText(string objectName, string text)
		{
			//DataWindow의 Text Control의 Text를 지정합니다.
			try
			{
				//DataWindow에 있는 Object 목록 Get
				string setting = this.Describe("DataWindow.Objects");
				if (setting.IndexOf(objectName) >= 0)
				{
					string modify = objectName + ".Text='" + text + "'";
					this.Modify(modify);
				}
			}
			catch(Exception xe)
			{
				string msg = XMsg.GetMsg("M022", xe); //SetObjectText 에러[" + xe.Message + "]"
				ShowErrMsg(msg);
			}
		}
		//DataWindow의 Computed Field에 이미지를 지정합니다.
		public void SetObjectImage(string objectName, string imageFileName)
		{
			try
			{
				//DataWindow에 있는 Object 목록 Get
				string setting = this.Describe("DataWindow.Objects");
				if (File.Exists(imageFileName) && (setting.IndexOf(objectName) >= 0))
				{
					string modify = objectName + ".Expression='Bitmap(\"" + imageFileName + "\")'";
					this.Modify(modify);
				}
			}
			catch(Exception xe)
			{
				string msg = XMsg.GetMsg("M023", xe); //SetObjectImage 에러[" + xe.Message + "]"
				ShowErrMsg(msg);
			}
		}
		// 공통 Footer Image Set
		public void SetFooterImage()
		{
			//Footer의 왼쪽, 오른쪽에 이미지를 공통으로 관리하여 DataWindow에 Set
			//Footer에 있는 Computed Field의 이름은 좌측은 hospital_image,
			//Image는 IFC/Images에서 관리하고 왼쪽은 LeftFooter.gif
			string path = Directory.GetParent(Application.StartupPath) + "\\Images\\";
			string fileName = path + "FOOTER.jpg";
			string modify;
			//DataWindow에 있는 Object 목록 Get
			string setting = this.Describe("DataWindow.Objects");
			//파일이 존재하고 Object가 있으면
			if (File.Exists(fileName) && (setting.IndexOf("hospital_image") >= 0))
			{
				try
				{
					modify = "hospital_image.Expression='Bitmap(\"" + fileName + "\")'";
					this.Modify(modify);
				}
				catch{}
			}
//			fileName = path + "RightFooter.gif";
//			if (File.Exists(fileName) && (setting.IndexOf("hospital_image") >= 0))
//			{
//				try
//				{
//					modify = "hospital_image.Expression='Bitmap(\"" + fileName + "\")'";
//					this.Modify(modify);
//				}
//				catch{}
//			}
		}

		#endregion
	}
}
