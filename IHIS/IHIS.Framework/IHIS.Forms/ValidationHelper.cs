using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace IHIS.Framework
{
    /// <summary>
    /// Supports all common validation methods.
    /// </summary>
    public class ValidationHelper
    {
        /// <summary>
        /// Indicates a string that matches some specific formats
        /// </summary>
        /// <param name="dateStr">Input date string</param>
        /// <param name="formats">Valid formats</param>
        /// <returns>True, if input string matched. Otherwise False.</returns>
        public static bool IsValidDateFormat(string dateStr, string[] formats)
        {
            DateTime fromDateValue;
            // To avoid double bytes
            string date = Encoding.UTF8.GetString(Encoding.Default.GetBytes(dateStr));

            if (DateTime.TryParseExact(date, formats, CultureInfo.CurrentCulture, DateTimeStyles.None, out fromDateValue))
            {
                // String is valid
                return true;
            }

            // String did not valid
            return false;
        }
    }
}
