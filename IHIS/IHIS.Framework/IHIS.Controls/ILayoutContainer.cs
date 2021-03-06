using System;
using System.Collections;

namespace IHIS.Framework
{
	#region MsgType
	/// <summary>
	/// Message 유형 열거형입니다.
	/// </summary>
	public enum MsgType
	{
		/// <summary>
		/// 정상 Message입니다.
		/// </summary>
		Normal,
		/// <summary>
		/// 오류 Message입니다.
		/// </summary>
		Error
	}
	#endregion

	#region Service Msg 관련 Enum
	public enum ServiceType
	{
		Entry,  //저장
		Query,  //조회
		Validation  //Vaidation Check
	}
	public enum ServiceMsgType
	{
		Processing, //처리중
		Normal,     //정상
		NoData,     //데이타없음
		ContQry		//연속조회중
	}
	#endregion

	/// <summary>
	/// ILayoutContainer에 대한 요약 설명입니다.
	/// DataLayout을 포함하는 Container Interface (XScreen에서 구현)
	/// </summary>
	public interface ILayoutContainer : IMsgContainer
	{

		/// <summary>
		/// 현재 Focus가 있는 IMultiSaveLayout을 가져오거나 설정합니다.
		/// </summary>
		IMultiSaveLayout CurrMSLayout { get; set;}
		/// <summary>
		/// 현재 Focus가 있는 IMultiQueryLayout을 가져오거나 설정합니다.
		/// </summary>
		IMultiQueryLayout CurrMQLayout { get; set;}

		/// <summary>
		/// Container를 닫습니다.
		/// </summary>
		void Close();

		/// <summary>
		/// Container를 초기화 합니다.
		/// </summary>
		void Reset();

		/// <summary>
		/// Container에 있는 입력값의 Validation을 Check합니다.
		/// 성공시 true, 실패시 false
		/// </summary>
		/// <returns></returns>
		bool AcceptData();

		/// <summary>
		/// 지정한 메세지를 MsgType에 따라 Display합니다.
		/// </summary>
		/// <param name="msg"></param>
		/// <param name="msgType"></param>
		void SetMsg(string msg, MsgType msgType);

		/// <summary>
		/// 서비스의 종류와 msg 종류에 따라 기본 Msg를 Display합니다.
		/// </summary>
		/// <param name="sType"></param>
		/// <param name="mType"></param>
		void SetServiceMsg(ServiceType sType, ServiceMsgType mType);

		/// <summary>
		/// LayoutContainer의 기능(조회,저장,입력,삭제,초기화,...)을 수행하는 수행자(XButtonList가 이 기능을 수행함)
		/// </summary>
		IFunctionPerformer FunctionPerformer { get; set;}

		/// <summary>
		/// LayoutContainer에서 출력기능을 수행하는 Worker
		/// </summary>
		IPrintWorker PrintWorker { get; set;}

		/// <summary>
		/// 저장 Layout의 List를 관리하는 ArrayList(ISaveLayout의 List를 관리)
		/// </summary>
		ArrayList SaveLayoutList { get;}
	}

	/// <summary>
	/// IMsgContainer에 대한 요약 설명입니다.
	/// Msg를 Display하는 Container
	/// </summary>
	public interface IMsgContainer
	{
		/// <summary>
		/// 지정한 에러 메세지를 Display합니다.
		/// </summary>
		/// <param name="msg"></param>
		void SetErrMsg(string msg);
		/// <summary>
		/// 지정한 메세지를 Display합니다.
		/// </summary>
		/// <param name="msg"></param>
		void SetMsg(string msg);
	}
}
