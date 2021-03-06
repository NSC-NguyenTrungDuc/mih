using System;

namespace IHIS
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
				if (data == null) return false;
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
				if (data == null) return false;
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
				if (data == null) return false;
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
				if (data == null) return false;
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
				if (data == null) return false;
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
				if (data == null) return false;
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
				if (data == null) return false;
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
				if (data == null) return false;
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
				if (data == null) return false;
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
				if (data == null) return false;
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
				if (data == null) return false;
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
				if (data == null) return false;
				Char.Parse(data.ToString());
			}
			catch
			{
				return false;
			}
			return true;
		}
	}
}
