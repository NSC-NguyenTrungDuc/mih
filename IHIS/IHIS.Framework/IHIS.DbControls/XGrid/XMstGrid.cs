using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Drawing.Design;
using System.Data;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Arguments.System;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.CloudConnector.Contracts.Results;

namespace IHIS.Framework
{
	[DefaultProperty("CellInfos"),
	DefaultEvent("GridColumnChanged"),
	ToolboxItem(true),
	ToolboxBitmap(typeof(IHIS.Framework.XEditGrid), "Images.XGrid.bmp")]
	public class XMstGrid : XEditGrid, IMasterLayout
	{
		#region Fields
		private ArrayList detailLayouts = new ArrayList();
		#endregion

		#region IMasterLayout Implemetation
		ArrayList IMasterLayout.DetailLayouts
		{
			get { return detailLayouts;}
		}
		object IMasterLayout.GetItemValueFromRelatonKey(string keyColName)
		{
			object data = DBNull.Value;
			if (this.CellInfos.Contains(keyColName))
			{
				int rowNum = this.CurrentRowNumber;
				if (this.DisplayedRowCount < 0) return data;
				if ((rowNum < 0) || (rowNum >= this.DisplayedRowCount)) return data;
				return GetItemValue(rowNum, keyColName);
			}
			return data;
		}
		#endregion

		#region CheckDetailLayout
		/// <summary>
		/// 행삭제시에 DetailLayout의 상태에 따른 삭제 가능여부를 확인하는 Event입니다.
		/// </summary>
		[Description("행삭제시에 DetailLayout의 상태에 따른 삭제 가능여부를 확인합니다."),
		Category("추가이벤트"),	
		Browsable(true)]
		public event CancelEventHandler CheckDetailLayout;
		/// <summary>
		/// CheckDetailLayout Event를 발생시킵니다.
		/// </summary>
		/// <param name="e"> CancelEventArgs </param>
		/// <returns> 삭제가능시 true, 삭제불가시 false </returns>
		protected virtual bool OnCheckDetailLayout(CancelEventArgs e)
		{
			if (CheckDetailLayout != null)
				CheckDetailLayout(this, e);
			return e.Cancel;
		}
		#endregion

		#region 생성자
		public XMstGrid()
		{
		}
		#endregion

		#region Override Method
		/// <summary>
		/// RowFocusChanged Event를 발생시킵니다.
		/// (override) DetailLayout의 Data를 Clear합니다.
		/// </summary>
		/// <param name="e"></param>
		protected override void OnRowFocusChanged(RowFocusChangedEventArgs e)
		{
			base.OnRowFocusChanged(e);
			
			//Reset Detail Layout
			ResetDetailLayout();

			//DetailOutputLayout의 Service를 call
			DetailLayoutQuery();
		}
		/// <summary>
		/// 지정한 행뒤에 행을 삽입합니다.
		/// (override) DetailLayout의 Data를 Clear합니다.
		/// </summary>
		/// <param name="row"> 지정 행번호 </param>
		public override int InsertRow(int row, bool isEditMode)
		{
			int ret = base.InsertRow(row, isEditMode);
			//행입력 성공시에 DetailLayout Reset
			if (ret >= 0)
				ResetDetailLayout();
			return ret;
		}
		/// <summary>
		/// 지정한 행을 삭제합니다.
		/// (override) DetailLayout을 Check하여 행삭제여부를 확인합니다.
		/// </summary>
		/// <param name="row"> 행번호 </param>
		public override bool DeleteRow(int row)
		{
			//row가 범위밖이면 삭제불가
			if ((row < 0) || (row >= this.RowCount)) return false;

			//DetailLayout에 지정된 RelationKey와 RelationTableName이 있으면 해당 Table에 해당 Key값의 데이타가 있는지를
			//확인하여 값이 존재하면 삭제불가
			foreach (IDetailLayout layout in this.detailLayouts)
			{
				// Detail과 관계된 DB 테이블명이 지정되었으면
				if (layout.RelationTableName.Trim() != "")
				{
					string msg = XMsg.GetMsg("M065"); // RelationKey(컬럼명)나 RelationTable명을 잘못지정하셨습니다."
					try
                    {
                        #region deleted by Cloud
                        //string cmdText = "SELECT COUNT(1) FROM " + layout.RelationTableName + " WHERE ";
                        //int index = 0;
                        ////SQL (SELECT COUNT(1) FROM ADM0100 WHERE GRP_ID = 'AAA'  AND SYS_ID = 'BBB')
                        //foreach (string key in layout.RelationKeys.Keys)
                        //{
                        //    if (index > 0)
                        //        cmdText += " AND ";
                        //    cmdText += key.ToUpper() + " = '" + GetItemValue(row, layout.RelationKeys[key].ToString()).ToString() + "'";
                        //    index++;
                        //}
                        //object retValue = Service.ExecuteScalar(cmdText);
                        #endregion

                        // Cloud updated code START
                        object retValue = new object();
                        string cmdText = string.Empty;
                        int index = 0;

                        foreach (string key in layout.RelationKeys.Keys)
                        {
                            cmdText += " AND " + key.ToUpper() + " = '" + GetItemValue(row, layout.RelationKeys[key].ToString()).ToString() + "'";
                            index++;
                        }

                        XMstGridDeleteRowArgs args = new XMstGridDeleteRowArgs();
                        args.TableName = layout.RelationTableName;
                        args.WhereCmd = cmdText;
                        args.HospCode = Service.HospCode;
                        XMstGridDeleteRowResult res = CloudService.Instance.Submit<XMstGridDeleteRowResult, XMstGridDeleteRowArgs>(args);

                        if (res.ExecutionStatus == ExecutionStatus.Success)
                        {
                            retValue = res.Result;
                        }
                        // Cloud updated code END

						if (retValue != null && TypeCheck.IsInt(retValue))
						{
							//COUNT가 0보다 크면 세부내역이 있으므로 삭제불가
							if (Int32.Parse(retValue.ToString()) > 0)
							{
								msg = XMsg.GetMsg("M066") + "\n\n" + XMsg.GetMsg("M067"); // "세부내역이 있어 삭제할 수 없습니다.\n\n"  "세부내역을 먼저 삭제후 저장하십시오."
                                XMessageBox.Show(msg, XMsg.GetMsg("M075"));
								return false;
							}
						}
						else
						{
							XMessageBox.Show(Service.ErrMsg, XMsg.GetMsg("M075"));
							return false;
						}
					}
					catch(Exception xe)
					{
						msg += "\nError[" + xe.Message + "]";
						XMessageBox.Show(msg, XMsg.GetMsg("M075"));
						return false;
					}
				}
			}
			//삭제전 Check Detail Layout
			if (OnCheckDetailLayout(new CancelEventArgs(false)))
			{
				string msg = XMsg.GetMsg("M066"); //세부내역이 있어 삭제할 수 없습니다."
				XMessageBox.Show(msg, XMsg.GetMsg("M075"));
				return false;
			}
			
			//마지막 행 여부
			bool isLastRow = false;
			if (row == this.DisplayedRowCount - 1)
				isLastRow = true;
			else
				isLastRow = false;

			bool ret = base.DeleteRow(row);

			//삭제성공시
			if (ret)
			{
				//DetailLayout Reset및 조회처리
				//삭제후 행이 하나도 없으면 ResetDetailLayout, 있으면 DetailLayoutQuery call
				if (this.RowCount == 0)  //모두 삭제되었으면 BindControl의 DataValue Reset
					this.ResetDetailLayout();
					//현재Cell의 Data를 Control에 Set, 마지막컬럼 삭제시는 Delete후 OnRowFocusChanged Event가 발생함으로 Call하지 않고,
					//중간의 Row를 삭제시는 OnRowFocusChanged가 발생하지 안으므로 Control Set
				else if (!isLastRow)
					this.DetailLayoutQuery();
			}
			return ret;
		}
		/// <summary>
		/// Grid의 Data를 Clear합니다.
		/// (override) DetailLayout의 Data를 Clear합니다.
		/// </summary>
		public override void Reset()
		{
			base.Reset();

			//Detail Output Reset
			ResetDetailLayout();
		}
		#endregion

		#region IMasterLayout Implemetation
		//DetailLayout Service call(조회)
		/// <summary>
		/// 지정된 DetailLayout의 조회서비스를 Call합니다.
		/// </summary>
		/// <param name="checkRowState"> 새행일때 조회여부 </param>
		public void DetailLayoutQuery()
		{
			//checkRowState : ServiceEnd에서 Call시는 False로 OnRowFocusChanged, DeleteRow에서는 true로 SET
			//ServiceEnd에서는 아직 ResetUpdate가 되지 않아, RowState = New상태임
			int currRow = this.CurrentRowNumber;
			if (currRow < 0) return;

			//Row상태가 UnChanged, Modiefied가 아니면 Detail 조회할 필요 없음
			if ((this.LayoutTable.Rows[currRow].RowState != DataRowState.Unchanged) &&
				(this.LayoutTable.Rows[currRow].RowState != DataRowState.Modified)) return;
			
			foreach (IDetailLayout layout in this.detailLayouts)
			{
				//자신을 Detail로 잘못 지정한 경우 Query 무한 Loop 가능성 제거
				if (!layout.Equals(this))
				{
					//DetailLayout Query
					layout.QueryLayout(layout.IsAllDataQuery);
					//Detail이 또 Master이면
					if (layout is IMasterLayout)
						((IMasterLayout) layout).DetailLayoutQuery();
				}

			}
		}
		/// <summary>
		/// 지정된 DetailLayout의 Data를 Clear합니다.
		/// </summary>
		public void ResetDetailLayout()
		{
			foreach (IDetailLayout layout in this.detailLayouts)
			{
				//자신을 Detail로 잘못 지정한 경우 Reset 무한 Loop 가능성 제거
				if (!layout.Equals(this))
				{
					layout.Reset();
					if (layout is IMasterLayout)
						((IMasterLayout) layout).ResetDetailLayout();
				}
			}
		}
		#endregion
	}
}
