using System;
using System.Collections;
using System.Drawing;

namespace IHIS.Framework
{
	#region JapanYearItem
	public class JapanYearItem
	{
		#region Field and Properties
		private string	period	= "平成";
		private int		year	= 0;
		private int		month	= 0;
		private int		day		= 0;
		public string Period
		{
			get { return period;}
		}
		public int Year
		{
			get { return year;}
		}
		public int Month
		{
			get { return month;}
		}
		public int Day
		{
			get { return day;}
		}
		#endregion

		#region 생성자
		public JapanYearItem(DateTime date)
		{
			JapanYearHelper.ConvertToJapanYear(date, out this.period, out this.year);
			//this.month = month;
			//this.day = day;
		}
		#endregion
	}
	#endregion

	/// <summary>
	/// JapanYearHelper(서기와 일본연호 변환)에 대한 요약 설명입니다.
	/// </summary>
	public class JapanYearHelper
	{
		private class YearItem
		{
			public string Name = "";
			public DateTime StartDate;
			public DateTime EndDate;
			public int	  MaxYear = 0;  //최대년수
			public YearItem(string name, DateTime startDate, DateTime endDate, int maxYear)
			{
				this.Name = name;
				this.StartDate = startDate;
				this.EndDate = endDate;
				this.MaxYear = maxYear;
			}
		}
		private static ArrayList periodList = new ArrayList();
		private static Hashtable yearItemList = new Hashtable();  //Key를 연호로 Value를 YearItem을 관리함.
		private static DateTime START_DATE = DateTime.Parse("1868/09/08");
		private static DateTime END_DATE = DateTime.Parse("9999/12/31");
		static JapanYearHelper()
		{
			//연호 List Set (천황바뀌면 계속 추가)
			YearItem item = new YearItem("明治", START_DATE, DateTime.Parse("1912/07/29") ,45);
			periodList.Add(item);  //명치는 45년(めいじ : M)
			yearItemList.Add("明治", item);
			item = new YearItem("大正", DateTime.Parse("1912/07/30"), DateTime.Parse("1926/12/24") ,15);
			periodList.Add(item);  //대정은 15년(たいしょう: T)
			yearItemList.Add("大正", item);
			item = new YearItem("昭和", DateTime.Parse("1926/12/25"), DateTime.Parse("1989/01/07") ,64);
			periodList.Add(item);  //소화는 64년(しょうわ : S)
			yearItemList.Add("昭和", item);
			item = new YearItem("平成", DateTime.Parse("1989/01/08"), END_DATE ,8010);
			periodList.Add(item);  //평성은 99년(へいせい : H)	
			yearItemList.Add("平成", item);
		}
		
		/// <summary>
		/// 서기 년도를 분석하여 연호와 년수를 계산
		/// </summary>
		/// <param name="year"></param>
		/// <param name="period"></param>
		/// <param name="convertedYear"></param>
		public static void ConvertToJapanYear(DateTime date, out string period, out int convertedYear)
		{
			period = "UnKnown";
			convertedYear = date.Year;

			if ((date < START_DATE) || (date > END_DATE))  return; //연호없음
			YearItem validItem = null;
			foreach (YearItem item in periodList)
			{
				if ((date >= item.StartDate) && (date <= item.EndDate))
				{
					validItem = item;
					break;
				}								 
			}
			period = validItem.Name;
			convertedYear = date.Year - validItem.StartDate.Year + 1;  //시작년을 1년으로 함
		}
		
		/// <summary>
		/// 연호와 연수로 서기년도 Return
		/// </summary>
		/// <param name="period"></param>
		/// <param name="year"></param>
		public static int ConvertToYear(string period, int year)
		{	
			foreach (YearItem item in periodList)
			{
				if (item.Name == period)
				{
					return item.StartDate.Year + year - 1;
				}
			}
			return year;
		}
		/// <summary>
		/// 년에 해당하는 연호 Return
		/// </summary>
		/// <param name="year"></param>
		/// <returns></returns>
		public static string GetJapanPeriod(DateTime date)
		{
			if ((date < START_DATE) || (date > END_DATE))  return "UnKnown"; //연호없음
			foreach (YearItem item in periodList)
			{
				if ((date >= item.StartDate) && (date <= item.EndDate))
					return item.Name;
			}
			return "UnKnown";
		}
		public static string GetNextJapanPeriod(string period, bool isIncreasing)
		{
			int index = 0, periodIndex = -1;
			foreach (YearItem item in periodList)
			{
				if (item.Name == period)
				{
					periodIndex = index;
					break;
				}
				index++;
			}
			if (periodIndex >= 0)
			{
				if (isIncreasing)
					return ((YearItem) periodList[(periodIndex + 1 == periodList.Count ? 0 : periodIndex + 1)]).Name;
				else
					return ((YearItem) periodList[(periodIndex - 1 == -1 ? periodList.Count - 1 : periodIndex - 1)]).Name;
			}
			else
				return "UnKnown";
		}
		//2006.05.20명치,대정,평성이 겹치는 날에 연호를 잘못쓴 경우 정확한  Text 를 Return함.
		//isWrongEndYear는 01년을 잘못 입력했는지(false), 말년을 잘못입력했는지 여부(true)
		private static string GetCorrectDateText(string period, DateTime date, bool isWrongEndYear)
		{
			//明治,大正,昭和,平成, 단 명치는 시작년은 Check하지 않고(이전연호가 없음), 말년만 Check함
			YearItem yItem = null;
			if (period == "明治")
			{
				if (isWrongEndYear)
					yItem = yearItemList["大正"] as YearItem;
			}
			else if (period == "大正")
			{
				if (isWrongEndYear)
					yItem = yearItemList["昭和"] as YearItem;
				else
					yItem = yearItemList["明治"] as YearItem;
			}
			else if (period == "昭和")
			{
				if (isWrongEndYear)
					yItem = yearItemList["平成"] as YearItem;
				else
					yItem = yearItemList["大正"] as YearItem;
			}
			else if (period == "平成")  //평성은 다음연호가 없으므로 End는  Check하지 않음
			{
				if (!isWrongEndYear)
					yItem = yearItemList["昭和"] as YearItem;
			}
			if (yItem != null)
			{
				if (isWrongEndYear) //말년이 틀렸으면 yItem.Name + "01/Month/Day", 초년이 틀렸으면 yItem.MaxYear + /Month/Day	
					return yItem.Name + " 01/" + date.Month.ToString("00") + "/" + date.Day.ToString("00");
				else
					return yItem.Name + " " + yItem.MaxYear.ToString("00") + "/" + date.Month.ToString("00") + "/" + date.Day.ToString("00");
			}
			return "";
		}
		//(2006/05/20)명치,대정,소화 01년과 끝년이 겹치는 해에 입력을 잘못한 경우는 NULLText로 설정하지 않고
		//정확한 데이타로 설정할 수 있도록 correctText를 Return하여 그 값으로 EditMask, DatePicker를 설정하도록 함.
		//XEditMask, XDatePicker에서 Date형 일때만 사용하기 위해 internal로 처리함.
		internal static bool IsValidJapanYear(string yearText, out string correctText)
		{
			//평성 00/00/00 형태의 데이타가 Valid하다고 처리(단 평성 00/01/01은 Valid가 아님)
			//(2006/05/20) 각 연호별로 겹치는 연도가 있으므로 날짜까지 비교함
			correctText = "";
			foreach (YearItem item in periodList)
			{
				if (yearText.IndexOf(item.Name) >= 0)
				{
					string text = yearText.Replace(item.Name, "").Trim();
					try
					{
						//2007.05.08 text가 45/01/01형식인데 이를 Datetime으로 변환하면 에러가 발생함. 
						//따라서, 년도만 2자리를 잘라서 Year를 구해야 한다., Month, Day도 동일함(BUG 수정)
						/*
						DateTime dt = DateTime.Parse(text);  //45/01/01 형식
						int year = Int32.Parse(dt.Year.ToString("0000").Substring(2));
						*/

                        //2010.11.01 김민수 수정

                        string[] splitDate = text.Split(new Char[] { '/' });

						int year = Int32.Parse(splitDate[0]);
						int month = Int32.Parse(splitDate[1]);
						int day = Int32.Parse(splitDate[2]);
                        //int year = Int32.Parse(text.Substring(0, 2));
                        //int month = Int32.Parse(text.Substring(3, 2));
                        //int day = Int32.Parse(text.Substring(6, 2));

						if (year == 0)  //00년은 없음
							return false;
						//Max 년수 확인
						if (year > item.MaxYear)
							return false;

						//정확한 일자로 변환
						int correctYear = ConvertToYear(item.Name, year);
						DateTime dt = DateTime.Parse(correctYear + "/" + month + "/" + day);
						//명치,대정,소화 겹치는 년도 확인, 겹치는 연도일때 종료일자보다 크면 Invalid
						//01년일때도 시작일자 Check해야함. (겹치는 해는 정확한 Text를 return하여 사용자가 편하도록 함)
						if ((year == item.MaxYear) && (dt > item.EndDate))
						{
							correctText = GetCorrectDateText(item.Name, dt, true);
							return false;
						}
						else if ((year == 1) && (dt < item.StartDate))
						{
							correctText = GetCorrectDateText(item.Name, dt, false);
							return false;
						}

						return true;
					}
					catch
					{
						return false;
					}

				}
			}
			return false;
		}
		public static bool IsValidJapanYear(string yearText)
		{
			//평성 00/00/00 형태의 데이타가 Valid하다고 처리(단 평성 00/01/01은 Valid가 아님)
			//(2006/05/20) 각 연호별로 겹치는 연도가 있으므로 날짜까지 비교함
			foreach (YearItem item in periodList)
			{
				if (yearText.IndexOf(item.Name) >= 0)
				{
					string text = yearText.Replace(item.Name, "").Trim();
					try
					{
						//2007.05.08 text가 45/01/01형식인데 이를 Datetime으로 변환하면 에러가 발생함. 
						//따라서, 년도만 2자리를 잘라서 Year를 구해야 한다., Month, Day도 동일함(BUG 수정)
						/*
						DateTime dt = DateTime.Parse(text);  //45/01/01 형식
						int year = Int32.Parse(dt.Year.ToString("0000").Substring(2));
						*/

                        //2010.11.01 김민수 수정

                        string[] splitDate = text.Split(new Char[] { '/' });

                        int year = Int32.Parse(splitDate[0]);
                        int month = Int32.Parse(splitDate[1]);
                        int day = Int32.Parse(splitDate[2]);
                        //int year = Int32.Parse(text.Substring(0, 2));
                        //int month = Int32.Parse(text.Substring(3, 2));
                        //int day = Int32.Parse(text.Substring(6, 2));

						if (year == 0)  //00년은 없음
							return false;
						//Max 년수 확인
						if (year > item.MaxYear)
							return false;

						//정확한 일자로 변환
						int correctYear = ConvertToYear(item.Name, year);
						DateTime dt = DateTime.Parse(correctYear + "/" + month + "/" + day);
						//명치,대정,소화 겹치는 년도 확인, 겹치는 연도일때 종료일자보다 크면 Invalid
						//01년일때도 시작일자 Check해야함.
						if ((year == item.MaxYear) && (dt > item.EndDate))
							return false;
						else if ((year == 1) && (dt < item.StartDate))
							return false;

						return true;
					}
					catch
					{
						return false;
					}

				}
			}
			return false;
		}

		public static string GetDataValue(MaskType mType, string yearText)
		{
			//Date와 Month형만 반영함
			if ((mType != MaskType.Date) && (mType != MaskType.Month)) return "";

			//평성 11/01/12 형태의 데이타를 DataValue(YYYY/MM/DD)형태로 변환하여 DataValue Get
			foreach (YearItem item in periodList)
			{
				if (yearText.IndexOf(item.Name) >= 0)
				{
					string text = yearText.Replace(item.Name, "").Trim();
					try
					{
						if (mType == MaskType.Month)
							text = text + "/01";  //YYYY/MM -> YYYY/MM/DD로 변경
						
						//2007.05.08 text가 45/01/01형식인데 이를 Datetime으로 변환하면 에러가 발생함. 
						//따라서, 년도만 2자리를 잘라서 Year를 구해야 한다., Month, Day도 동일함(BUG 수정)
						/*
						DateTime dt = DateTime.Parse(text);  //45/01/01 형식(정확한 서기력이 아님)
						int year = Int32.Parse(dt.Year.ToString("0000").Substring(2));
						*/

                        //2010.11.01 김민수 수정

                        string[] splitDate = text.Split(new Char[] { '/' });

                        int year = Int32.Parse(splitDate[0]);
                        int month = Int32.Parse(splitDate[1]);
                        int day = Int32.Parse(splitDate[2]);
                        
                        //int year = Int32.Parse(text.Substring(0, 2));
                        //int month = Int32.Parse(text.Substring(3, 2));
                        //int day = Int32.Parse(text.Substring(6, 2));
						
                        if (year == 0)  //00년은 없음
							return string.Empty;
						//Max 년수 확인
						if (year > item.MaxYear)
							return string.Empty;
						//연호 + 년 -> 년으로 변환
						int correctYear = ConvertToYear(item.Name, year);
						DateTime dt = DateTime.Parse(correctYear + "/" + month + "/" + day);
						//2006.05.20 명치,대정,소화 겹치는 년도 확인 겹치는 연도일때 종료일자보다 크면 Invalid
						//01년일때도 시작일자 Check해야함.
						if ((year == item.MaxYear) && (dt > item.EndDate))
						{
							//Date형은 사용자 편의를 위해 겹치는 년도에 날짜를 잘못 넣었을때 정확한 날짜 Text를 알 수 있으면 Valid하게 처리함.
							if ((mType == MaskType.Date) && (GetCorrectDateText(item.Name, dt, true) == ""))
								return string.Empty;
							else if (mType == MaskType.Month)													  
								return string.Empty;
						}
						else if ((year == 1) && (dt < item.StartDate))
						{
							//Date형은 사용자 편의를 위해 겹치는 년도에 날짜를 잘못 넣었을때 정확한 날짜 Text를 알 수 있으면 Valid하게 처리함.
							if ((mType == MaskType.Date) && (GetCorrectDateText(item.Name, dt, false) == ""))
								return string.Empty;
							else if (mType == MaskType.Month)													  
								return string.Empty;
						}
						
						if (mType == MaskType.Month) //YYYYMM
							return correctYear.ToString("0000") + dt.Month.ToString("00");
						else
							return correctYear.ToString("0000") + "/" + dt.Month.ToString("00") + "/" + dt.Day.ToString("00");
					}
					catch
					{
						return string.Empty;
					}
				}
			}
			return string.Empty;
		}
		public static int GetMaxYear(string period)
		{
			//해당 연호의 최대 년수 Return
			foreach (YearItem item in periodList)
			{
				if (item.Name == period)
					return item.MaxYear;
			}
			return 0;
		}
		public static string GetDisplayText(MaskType mType, object dataValue, bool invalidDateIsStringEmpty, out string period)
		{
			period = "";
			//Date와 Month형만 반영함
			if ((mType != MaskType.Date) && (mType != MaskType.Month)) return "";

			//YYYY/MM/DD, YYYYMMDD형의 데이타를 연호 YY/MM/DD형의 string으로 Return
			period = "平成";
			DateTime dt;
			int year = 0;
			if (mType == MaskType.Month) //Month형 데이타 (YYYYMM)
			{
				if (dataValue.ToString().Length == 6)
				{
					string dateStr = dataValue.ToString();
					dateStr = dateStr.Substring(0,4) + "/" + dateStr.Substring(4,2) + "/01";
					if (TypeCheck.IsDateTime(dateStr))
					{
						dt = DateTime.Parse(dateStr);
						JapanYearHelper.ConvertToJapanYear(dt, out period, out year);
						return period + " " + year.ToString("00") + "/" + dt.Month.ToString("00");

					}
					else
						return GetNullText(mType, invalidDateIsStringEmpty,out period);
				}
				else
					return GetNullText(mType, invalidDateIsStringEmpty, out period);
			}
			else
			{
				if (TypeCheck.IsDateTime(dataValue))  //Date형 값이면
				{
					dt = DateTime.Parse(dataValue.ToString());
					JapanYearHelper.ConvertToJapanYear(dt, out period, out year);
					return period + " " + year.ToString("00") + "/" + dt.Month.ToString("00") + "/" +  dt.Day.ToString("00");
				}
				else
				{
					//YYYYMMDD형은 허용함
					if (dataValue.ToString().Length == 8)
					{
						string dateStr = dataValue.ToString();
						dateStr = dateStr.Substring(0,4) + "/" + dateStr.Substring(4,2) + "/" + dateStr.Substring(6);
						if (TypeCheck.IsDateTime(dateStr))
						{
							dt = DateTime.Parse(dataValue.ToString());
							JapanYearItem item = new JapanYearItem(dt);
							JapanYearHelper.ConvertToJapanYear(dt, out period, out year);
							return period + " " + year.ToString("00") + "/" + dt.Month.ToString("00") + "/" +  dt.Day.ToString("00");
						}
						else
							return GetNullText(mType, invalidDateIsStringEmpty, out period);
					}
					else
						return GetNullText(mType, invalidDateIsStringEmpty, out period);
				}
			}
		}
		public static string GetDisplayText(MaskType mType, object dataValue)
		{
			string period = "";
			return GetDisplayText(mType, dataValue, false, out period);
		}
		//invalidDateIsStringEmpty = 유효한 날짜가 아닐때 StringEmpty를 보여줄지 기본값을 보여줄지 여부
		public static string GetDisplayText(MaskType mType, object dataValue, bool invalidDateIsStringEmpty)
		{
			string period = "";
			return GetDisplayText(mType, dataValue, invalidDateIsStringEmpty, out period);
		}
		public static string GetDisplayText(MaskType mType, object dataValue, out string period)
		{
			period = "";
			return GetDisplayText(mType, dataValue, false, out period);
		}
		//Null Text 값 Return
		public static string GetNullText(MaskType mType)
		{
			string period = "";
			return GetNullText(mType, out period);
		}
		public static string GetNullText(MaskType mType, out string period)
		{
			period = "";
			return GetNullText(mType, false, out period);
		}
		public static string GetNullText(MaskType mType, bool invalidDateIsStringEmpty, out string period)
		{
			period = "";
			//Date와 Month형만 반영함
			if ((mType != MaskType.Date) && (mType != MaskType.Month)) return "";
			period = "平成";

			if (invalidDateIsStringEmpty) return "";

			if (mType == MaskType.Date)
				return "平成 00/00/00";
			else
				return "平成 00/00";
		}
		public static void SetMaskSymbols(MaskType mType, ArrayList maskSymbols)
		{
			//Date와 Month형만 반영함
			if ((mType != MaskType.Date) && (mType != MaskType.Month)) return ;

			//기존 List Clear
			maskSymbols.Clear();

			if (mType == MaskType.Date) //Date 형 (YY/MM/DD)
			{
				maskSymbols.Add(new MaskSymbol('/', 5, "YY", 2));
				maskSymbols.Add(new MaskSymbol('/', 8, "MM", 2));
				maskSymbols.Add(new MaskSymbol((char) 0, 11, "DD", 2));				
			}
			else //Month형 YY/MM
			{
				maskSymbols.Add(new MaskSymbol('/', 5, "YY", 2));
				maskSymbols.Add(new MaskSymbol((char) 0, 8, "MM", 2));
			}
		}
		//해당 연호가 정확한 연호인지 확인
		public static bool IsValidPeriod(string period)
		{
			foreach (YearItem item in periodList)
			{
				if (item.Name == period)
					return true;
			}
			return false;
		}
	}
}
