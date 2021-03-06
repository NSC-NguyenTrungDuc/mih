using System;
using System.Data;
using System.ComponentModel;
using System.Collections;

namespace IHIS.Framework
{
	/// <summary>
	/// IMultiSavePerformer Interface
	/// 여러행의 데이타를 저장하는 기능을 담당하는 저장 수행 기능 정의 Interface
	/// 각 화면에서는 Grid의 Multi Record 저장시에 이 Interface를 구현한 업무 class를 구현하여
	/// 데이타 처리 Logic을 구현함.
	/// </summary>
	public interface ISavePerformer
	{
		/// <summary>
		/// 저장 기능 수행
		/// </summary>
		/// <param name="callerID"> Performer를 call한 Grid의 ID </param>
		/// <param name="item"> 한행의 데이타 </param>
		/// <returns>성공시 true, 실패시 false </returns>
		bool Execute(char callerID, RowDataItem item); 
	}
	/// <summary>
	/// Grid에서 한행의 데이타를 저장하기 위해 관리하는 class
	/// Grid에서 여러행을 한꺼번에 저장시 행의 상태에 따라 한행씩 데이타를 넘겨서 IMultiSavePerformer가 
	/// 저장 Logic을 수행할 수 있도록 넘겨준다.
	/// </summary>
	public class RowDataItem
	{
		private DataRowState rowState = DataRowState.Unchanged;  
		//저장 컬럼으로 구성된 Bind 변수 항목
		private BindVarCollection bindVarList = new BindVarCollection();
		public DataRowState RowState
		{
			get { return rowState; } 
		}
		public BindVarCollection BindVarList
		{
			get { return bindVarList; }
		}
		public RowDataItem(DataRowState rowState)
		{
			this.rowState = rowState;
		}
    
	}
}
