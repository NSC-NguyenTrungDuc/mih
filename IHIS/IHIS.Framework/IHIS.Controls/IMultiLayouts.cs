using System;
using System.Collections;
using System.Data;
using System.ComponentModel;

namespace IHIS.Framework
{
	#region ISaveLayout (저장기능 수행 Layout(SingleLayout, MultiLayout, XEditGrid, XMstGrid)
	public interface ISaveLayout
	{
		bool	UseDefaultTransaction { get; set;}		   //저장시에 기본 제공 Transaction 을 사용할지 여부 관리
		bool	SaveLayout();			// Layout 저장 처리
	}
	#endregion
	#region IMultiSaveLayout (저장기능 수행 Multi Record 관리 Layout)
	public interface IMultiSaveLayout : ISaveLayout
	{
		DataTable LayoutTable { get ;} //확정(노출할지 여부 나중에 결정, 개발자가 DataTable에 바로 Access할 수 없게 해야한다)
		int		RowCount { get;}		//Record의 건수
		int     CurrentRowNumber { get;}  //현재 Focus가 있는 행번호 Return
		string	CurrentColName   { get;}  //현재 Focus가 있는 컬럼의 컬럼명
		void	Reset();
		bool	AcceptData();
		object	GetItemValue(int rowNumber, string dataName);
		bool	SetItemValue(int rowNumber, string dataName, object dataValue);
		int		InsertRow(); //현재행 아래에 행을 삽입합니다.
		int		InsertRow(int rowNumber);
		bool	DeleteRow(); //현재행을 삭제합니다.
		bool	DeleteRow(int rowNumber);
		int		GetChangedRowCount();  //변경된 행의 건수를 가져옵니다.
		/// <summary>
		/// LayoutContainer의 Reset을 적용할지 여부를 지정합니다.
		/// true이면 XScreen, XForm의 Reset 호출시에 Reset되고, false이면 Reset하지 않습니다.
		/// </summary>
		bool ApplyLayoutContainerReset { get; set;}
	}
	#endregion

	#region IMultiQueryLayout (조회기능 수행 MultiLayout)
	public interface IMultiQueryLayout
	{
		DataTable LayoutTable { get ;}  //Layout에서 관리하는 Table입니다.
		int		RowCount { get;}		//Record의 건수
		int     CurrentRowNumber { get;}  //현재 Focus가 있는 행번호 Return
		string	CurrentColName   { get;}  //현재 Focus가 있는 컬럼의 컬럼명
		object	GetItemValue(int rowNumber, string dataName);
		bool	SetItemValue(int rowNumber, string dataName, object dataValue); //성공시 true, 실패시 false
		void	ResetUpdate();
		void	Reset();
		bool	QueryLayout(bool isAllDataQuery);  //데이타를 조회하여 채웁니다.
		bool	IsAllDataQuery { get; set;}        //전체 데이타 조회여부(false이면 연속조회, true이면 전체데이타 조회)
		/// <summary>
		/// LayoutContainer의 Reset을 적용할지 여부를 지정합니다.
		/// true이면 XScreen, XForm의 Reset 호출시에 Reset되고, false이면 Reset하지 않습니다.
		/// </summary>
		bool ApplyLayoutContainerReset { get; set;}

	}
	#endregion

	#region IMasterLayout
	/// <summary>
	/// Master-Detail 관계에서 Master Layout, XMstGrid에서 구현
	/// </summary>
	public interface IMasterLayout
	{
		/// <summary>
		/// Master Layout의 DetailLayout(IMultiOutputLayout)을 관리하는 ArrayList입니다.
		/// </summary>
		ArrayList DetailLayouts { get;}

		/// <summary>
		/// Detail과 RelationKey로 적용된 컬럼의 현재행의 값을 가져옵니다.
		/// </summary>
		/// <param name="rowNumber"></param>
		/// <param name="dataName"></param>
		/// <returns></returns>
		object GetItemValueFromRelatonKey(string keyColName);

		/// <summary>
		/// Detail Layout의 조회 Service를 call합니다.
		/// </summary>
		[Description("Detail Layout의 조회합니다.")]
		void DetailLayoutQuery();
		
		/// <summary>
		/// Detail Layout의 Data를 Clear합니다.
		/// </summary>
		[Description("Detail Layout의 Data를 Clear합니다.")]
		void ResetDetailLayout();
	}
	#endregion

	#region IDetailLayout
	public interface IDetailLayout
	{
		/// <summary>
		/// DetailLayout의 MasterLayout을 지정
		/// </summary>
		IMasterLayout   MasterLayout { get; set;}
		/// <summary>
		/// DetailLayout과 관련된 테이블명을 지정
		/// </summary>
		string RelationTableName { get;}
		/// <summary>
		/// Master와 Detail의 Relation컬럼을 지정한 Hashtable(컬럼명, Master컬럼명) 형태로 저장됨
		/// </summary>
		Hashtable RelationKeys { get;}
		/// <summary>
		/// DataLayout의 Data를 Clear합니다.
		/// </summary>
		[Description("DataLayout의 Data를 Clear합니다.")]
		void	Reset();

		bool	QueryLayout(bool isAllDataQuery);  //데이타를 조회하여 채웁니다.

		bool	IsAllDataQuery { get; set;}        //전체 데이타 조회여부(false이면 연속조회, true이면 전체데이타 조회)

	}
	#endregion

}
