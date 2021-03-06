using System;

namespace IHIS.Framework
{
	

	/// <summary>
	/// DataTypeCheck에 대한 요약 설명입니다.
	/// </summary>
	public class TypeCheck
	{
		/// <summary>
		/// 데이타가 DateTime형인지를 검사합니다.
		/// </summary>
		/// <param name="data"></param>
		/// <returns> DateTime형이면 true, 아니면 false </returns>
		public static bool IsDateTime(object data)
		{
			try
			{
				DateTime.Parse(data.ToString());
			}
			catch
			{
				return false;
			}
			return true;
		}
		/// <summary>
		/// 데이타가 Time형인지를 검사합니다.
		/// </summary>
		/// <param name="data"></param>
		/// <returns> Time형이면 true, 아니면 false </returns>
		public static bool IsTime(object data)
		{
			try
			{
				//Number형 Check
				//ex> 1212를 넘길때 TimeSpan에서는 1212를 Day로 인식함
				//IsTime Method는 Day를 포함하지 않는 Time만 관리함
				if (IsInt(data))  
					return false;
				else
					TimeSpan.Parse(data.ToString());
			}
			catch
			{
				return false;
			}
			return true;
		}
		/// <summary>
		/// 데이타가 Int형인지를 검사합니다.
		/// </summary>
		/// <param name="data"></param>
		/// <returns> Int형이면 true, 아니면 false </returns>
		public static bool IsInt(object data)
		{
			try
			{
				Int32.Parse(data.ToString());
			}
			catch
			{
				return false;
			}
			return true;
		}
		/// <summary>
		/// 데이타가 long형인지를 검사합니다.
		/// </summary>
		/// <param name="data"></param>
		/// <returns> long형이면 true, 아니면 false </returns>
		public static bool IsLong(object data)
		{
			try
			{
				Int64.Parse(data.ToString());
			}
			catch
			{
				return false;
			}
			return true;
		}
		/// <summary>
		/// 데이타가 UInt형인지를 검사합니다.
		/// </summary>
		/// <param name="data"></param>
		/// <returns> UInt형이면 true, 아니면 false </returns>
		public static bool IsUInt(object data)
		{
			try
			{
				UInt32.Parse(data.ToString());
			}
			catch
			{
				return false;
			}
			return true;
		}
		/// <summary>
		/// 데이타가 Decimal형인지를 검사합니다.
		/// </summary>
		/// <param name="data"></param>
		/// <returns> Decimal형이면 true, 아니면 false </returns>
		public static bool IsDecimal(object data)
		{
			try
			{
				Decimal.Parse(data.ToString());
			}
			catch
			{
				return false;
			}
			return true;
		}
		/// <summary>
		/// 데이타가 double형인지를 검사합니다.
		/// </summary>
		/// <param name="data"></param>
		/// <returns> double형이면 true, 아니면 false </returns>
		public static bool IsDouble(object data)
		{
			try
			{
				Double.Parse(data.ToString());
			}
			catch
			{
				return false;
			}
			return true;
		}
		/// <summary>
		/// 데이타가 single형인지를 검사합니다.
		/// </summary>
		/// <param name="data"></param>
		/// <returns> single형이면 true, 아니면 false </returns>
		public static bool IsSingle(object data)
		{
			try
			{
				Single.Parse(data.ToString());
			}
			catch
			{
				return false;
			}
			return true;
		}
		/// <summary>
		/// 데이타가 bool형인지를 검사합니다.
		/// </summary>
		/// <param name="data"></param>
		/// <returns> bool형이면 true, 아니면 false </returns>
		public static bool IsBoolean(object data)
		{
			try
			{
				Boolean.Parse(data.ToString());
			}
			catch
			{
				return false;
			}
			return true;
		}
		/// <summary>
		/// 데이타가 byte형인지를 검사합니다.
		/// </summary>
		/// <param name="data"></param>
		/// <returns> byte형이면 true, 아니면 false </returns>
		public static bool IsByte(object data)
		{
			try
			{
				Byte.Parse(data.ToString());
			}
			catch
			{
				return false;
			}
			return true;
		}
		/// <summary>
		/// 데이타가 SByte형인지를 검사합니다.
		/// </summary>
		/// <param name="data"></param>
		/// <returns> SByte형이면 true, 아니면 false </returns>
		public static bool IsSByte(object data)
		{
			try
			{
				SByte.Parse(data.ToString());
			}
			catch
			{
				return false;
			}
			return true;
		}
		/// <summary>
		/// 데이타가 char형인지를 검사합니다.
		/// </summary>
		/// <param name="data"></param>
		/// <returns> char형이면 true, 아니면 false </returns>
		public static bool IsChar(object data)
		{
			try
			{
				Char.Parse(data.ToString());
			}
			catch
			{
				return false;
			}
			return true;
		}
		/// <summary>
		/// 데이타가 null인지 여부를 검사합니다.
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public static bool IsNull(object data)
		{
			if (data == null) return true;
			if (data is DBNull) return true;

            //2010.08.17 kimminsoo dataTable에 대해서는 테이블 로우를 카운팅 한다.
            try
			{
                System.Data.DataTable dtTemp = (System.Data.DataTable)data;

                if (dtTemp.Rows.Count > 0) return false;
                else return true;
			}
			catch
			{
				
			}
            
            if (data.ToString().TrimEnd() == string.Empty) return true;
			return false;
		}
		/// <summary>
		/// sourceData가 NULL이면 targetData를 Return, Null이 아니면 sourceData Return합니다.
		/// </summary>
		/// <param name="sourceData"> Null을 판단하는 Source Data </param>
		/// <param name="targetData"> SourceData가 Null일때 대체할 Target data </param>
		/// <returns></returns>
		public static object NVL(object sourceData, object targetData)
		{
			if (IsNull(sourceData))
				return targetData;
			return sourceData;
		}
	}
}
