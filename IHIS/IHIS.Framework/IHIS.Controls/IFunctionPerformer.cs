using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace IHIS.Framework
{

	#region IFunctionPerformer
	/// <summary>
	/// IFunctionPerformer에 대한 요약 설명입니다.
	/// LayoutContainer의 기능(조회,저장,입력,삭제,초기화,닫기...)을 수행하는 수행자 Interface
	/// IHIS.BizObjects의 XButtonList에서 구현
	/// </summary>
	public interface IFunctionPerformer
	{
		/// <summary>
		/// 지정한 기능을 수행합니다.
		/// </summary>
		/// <param name="func"></param>
		void PerformFunction(FunctionType func);
		
		/// <summary>
		/// 기능 수행자의 Type
		/// </summary>
		FunctionPerformerType PerformerType { get; set;}

		/// <summary>
		/// 기능 수행이 성공했는지 여부를 가져옵니다.
		/// </summary>
		bool IsFunctionSuccess { get ; }
	}
	#endregion

	
	#region FunctionPerformerType Enum
	/// <summary>
	/// 기능의 성격을 관리하는 Enum
	/// </summary>
	public enum FunctionPerformerType
	{
		/// <summary>
		/// Entry(조회,입력,삭제,저장,초기화, 닫기)
		/// </summary>
		Entry,
		/// <summary>
		/// EntryS(조회,저장,초기화,닫기)
		/// </summary>
		EntryS,
		/// <summary>
		/// 조회 Type (조회,출력,초기화,닫기)
		/// </summary>
		Query,
		/// <summary>
		/// Report Type (조회,출력,초기화,닫기)
		/// </summary>
		Report,
		/// <summary>
		/// 출력 전용 Type(출력, 미리보기, 닫기)
		/// </summary>
		Print,
		/// <summary>
		/// 처리 Type(처리,취소,닫기)
		/// </summary>
		Process,
		/// <summary>
		/// 버튼 Type 없음
		/// </summary>
		None,
		/// <summary>
		/// 사용자 지정
		/// </summary>
		Custom
	}
	#endregion

	#region FunctionType Enum
	/// <summary>
	/// 기능의 성격을 관리하는 Enum
	/// </summary>
	public enum FunctionType
	{
		Query,  //조회
		Insert, //입력
		Delete, //삭제
		Update, //저장
		Reset,  //초기화
		Close,  //닫기
		Print,  //출력
		Preview, //미리보기
		Process, //처리
		Cancel   //취소
	}
	#endregion

	#region IPrintWorker
	/// <summary>
	/// IPrintWorker에 대한 요약 설명입니다.
	/// LayoutContainer의 출력기능을 수행하는 수행자 Interface
	/// IHIS.BizObjects의 XUbiWorker, XDWWorker에서 구현
	/// </summary>
	public interface IPrintWorker
	{
		/// <summary>
		/// 출력기능을 수행합니다. (PrintEnd까지 정상적으로 수행시는 true, 그외 실패시는 false)
		/// </summary>
		bool Print();
	}
	#endregion
}
