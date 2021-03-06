using System;
using System.Globalization;

namespace IHIS.Utils
{
    internal class JapaneseDateTime
    {
        /// <summary>
        ///     Convert to Japan Year short string
        ///     Format: H26.12
        /// </summary>
        /// <param name="dt">Object DateTime to convert</param>
        /// <returns>A short string japan date time</returns>
        static public string ConvertToJapanYearShortString(DateTime dt)
        {
            JapaneseCalendar japaneseCalendar = new JapaneseCalendar();
            return string.Format("{0}{1}.{2}",
                ConvertEarsToShortString(japaneseCalendar.GetEra(dt)),
                japaneseCalendar.GetYear(dt),
                japaneseCalendar.GetMonth(dt));
        }

        static public string JapanMonthToNormal()
        {
            //JapaneseCalendar jc = new JapaneseCalendar();
          //  jc.

            return "";
        }

        public string ConvertToJapanYearString(DateTime dt)
        {
            JapaneseCalendar japaneseCalendar = new JapaneseCalendar();
            return string.Format("{0} {1} {2}月",
                ConvertEarsToString(japaneseCalendar.GetEra(dt)),
                japaneseCalendar.GetYear(dt),
                japaneseCalendar.GetMonth(dt));
        }

        private string ConvertEarsToString(int eras)
        {
            switch (eras)
            {
                case 4:
                    return "平成";
                case 3:
                    return "昭和";
                case 2:
                    return "大正";
                case 1:
                    return "明治";
                default:
                    return "";
            }
        }

        static  private string ConvertEarsToShortString(int eras)
        {
            switch (eras)
            {
                case 4:
                    return "H";
                case 3:
                    return "S";
                case 2:
                    return "T";
                case 1:
                    return "M";
                default:
                    return "";
            }
        }
    }
}