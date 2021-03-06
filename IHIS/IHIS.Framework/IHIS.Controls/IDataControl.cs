using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Reflection;

namespace IHIS.Framework
{
	/// <summary>
	/// IDataControl Interface
	/// </summary>
	public interface IDataControl 
	{
		/// <summary>
		/// Control의 편집가능여부를 가져오거나 설정합니다.
		/// </summary>
		bool Protect { get; set; }
		/// <summary>
		/// Control의 값 변경여부를 가져오거나 설정합니다.
		/// </summary>
		bool DataChanged { get; set; }
		/// <summary>
		/// Control의 값을 가져오거나 설정합니다.
		/// </summary>
		object DataValue { get; set; }
		/// <summary>
		/// LayoutContainer의 Reset을 적용할지 여부를 지정합니다.
		/// true이면 XScreen, XForm의 Reset 호출시에 Reset되고, false이면 Reset하지 않습니다.
		/// </summary>
		bool ApplyLayoutContainerReset { get; set;}
		/// <summary>
		/// 편집중인 값을 DataValue에 Setting합니다.
		/// </summary>
		/// <returns></returns>
		bool AcceptData();
		/// <summary>
		/// Control의 값을 Clear합니다.
		/// </summary>
		void ResetData();
		/// <summary>
		/// 데이타 유효성검사가 진행될 때 발생하는 Event입니다.
		/// </summary>
		event DataValidatingEventHandler DataValidating;

		/// <summary>
		/// Control의 DataType을 가져옵니다.
		/// </summary>
		ControlDataType ContType {get;}

	}

	#region DataValidatingEventHandler
	/// <summary>
	/// 데이타의 유효성 검사를 하는 발생 이벤트를 처리하는 메서드를 나타냅니다.
	/// </summary>
	[Serializable]
	public delegate void DataValidatingEventHandler(Object sender, DataValidatingEventArgs e);
	
	/// <summary>
	/// 데이타의 유효성 검사를 하는 발생 이벤트에 데이타를 제공합니다.
	/// </summary>
	public class DataValidatingEventArgs : CancelEventArgs
	{
		string	dataValue;
		/// <summary>
		/// 유효성 검사시 사용될 데이타를 가져옵니다.
		/// </summary>
		public string DataValue
		{
			get { return dataValue; }
		}
		/// <summary>
		/// DataValidatingEventArgs 생성자
		/// </summary>
		/// <param name="cancel"> Event 취소여부 </param>
		/// <param name="dataValue"> 데이타 값 </param>
		public DataValidatingEventArgs(bool cancel, string dataValue)
			: base(cancel)
		{
			this.dataValue = dataValue;
		}
	}
	#endregion

	#region ControlDataType Enum
	/// <summary>
	/// ControlDataType Enum
	/// </summary>
	public enum ControlDataType
	{
		/// <summary>
		/// 모든 형식의 Data을 지원합니다.
		/// </summary>
		AllType,
		/// <summary>
		/// String 형식의 Data를 지원합니다.
		/// </summary>
		String,
		/// <summary>
		/// Number 형식의 Data를 지원합니다.
		/// </summary>
		Number,
		/// <summary>
		/// Date 형식(YYYYMMDD)의 Data를 지원합니다.
		/// </summary>
		Date,
		/// <summary>
		/// DateTime 형식(YYYYMMDDHHMISS)의 Data를 지원합니다.
		/// </summary>
		DateTime,
		/// <summary>
		/// Time 형식(HHMISS)의 Data를 지원합니다.
		/// </summary>
		Time,
		/// <summary>
		/// Binary 형식의 Data를 지원합니다.
		/// </summary>
		Binary
	}
	#endregion

	#region IEditorControl (Grid의 Editor로 쓰이는 Control Interface)
	public interface IEditorControl
	{
		/// <summary>
		/// Control의 값을 가져오거나 설정합니다.
		/// </summary>
		object DataValue { get; set; }
		/// <summary>
		/// 편집가능여부를 가져오거나 설정합니다.
		/// </summary>
		bool Protect	 { get; set; }
	}
	#endregion

}
