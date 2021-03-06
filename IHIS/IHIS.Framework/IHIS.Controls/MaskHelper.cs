using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading;

namespace IHIS.Framework
{
    /// <summary>
    /// Mask를 지정한 Control에서 쓰이는 Helper Class입니다.
    /// </summary>
    public class MaskHelper
    {
        /// <summary>
        /// String형의 Mask로 지정가능한 문자List입니다.(다른 문자는 모두 Seperator로 처리함)
        /// </summary>
        public static string[] CStringMaskStrs = new string[] { "#", "X" };  // 지정가능한 String의 Mask Char List
        /// <summary>
        /// Date형의 Mask로 지정가능한 문자List입니다.
        /// </summary>
        public static string[] CDateMaskStrs = new string[] { "YYYY/MM/DD", "YYYY-MM-DD" };  // 지정가능한 Date Mask List

        public static string[] CMonthMaskStrs = new string[] { "YYYY/MM", "YYYY-MM" };  // 지정가능한 Date Mask List

        /// <summary>
        /// Time형의 Mask로 지정가능한 문자List입니다.
        /// </summary>
        public static string[] CTimeMaskStrs = new string[] { "HH:MI:SS", "HH:MI" };  // 지정가능한 Time Mask List
        /// <summary>
        /// Space Char 입니다.
        /// </summary>
        public const char CSpaceChar = (char)32;
        /// <summary>
        /// Zero Char 입니다.
        /// </summary>
        public const char CZeroChar = '0';
        /// <summary>
        /// Date형 Mask의 Default(YYYY/MM/DD)입니다.
        /// </summary>
        public const string CDateDefaultMask = "YYYY/MM/DD";
        /// <summary>
        /// Date형 Mask의 Vietnam(DD/MM/YYYY)입니다.
        /// </summary>
        public const string CDateVietnameseMask = "dd/MM/yyyy"; //MED-11258
        public const string ViMonhMask = "MM/yyyy";
        /// <summary>
        /// DateTime형 Mask의 Default(YYYY/MM/DD HH:MI:SS)입니다.
        /// </summary>
        public const string CDateTimeDefaultMask = "YYYY/MM/DD HH:MI:SS";
        public const string CMonthDefaultMask = "YYYY/MM";
        public const string CMonthVietnameseMask = "MM/YYYY"; //MED-11258
        /// <summary>
        /// Time형 Mask의 Default(HH:MI:SS)입니다.
        /// </summary>
        public const string CTimeDefaultMask = "HH:MI:SS";
        /// <summary>
        /// String형 Mask의 Default("")입니다.
        /// </summary>
        public const string CStringDefaultMask = "";

        public static string Comma
        {
            get
            {
                double t = 1.1;
                string text = t.ToString("n");
                if (text.Contains("."))
                {
                    return ".";
                }
                else
                    return ",";
            }
        }
        public static string SplitNumber
        {
            get
            {
                double t = 1.1;
                string text = t.ToString("n");
                if (text.Contains("."))
                {
                    return ",";
                }
                else
                    return ".";
            }
        }

        private static char maskSeperator = (char)0;
        public static char MaskSeperator
        {
            get { return maskSeperator; }
        }
        /// <summary>
        /// 지정한 Mask가 유효한지 여부를 Check합니다.
        /// </summary>
        /// <param name="mType"> MaskType Enum </param>
        /// <param name="maskStr"> Mask String </param>
        /// <param name="errMsg"> (out) ErrMsg </param>
        /// <returns> 유효한 Mask이면 true, 아니면 false </returns>
        public static bool IsValidMask(MaskType mType, string maskStr, out string errMsg)
        {
            //Date : yyyy/mm/dd, yyyy-mm-dd, yyyymmdd
            //Time : hh:mi:ss, hh:mi
            //DateTime은 Date, Time 조합만 가능
            //String : MaskString은 X,#만 가능(혼용불가), 그외는 모두 Seperator로 처리, 마지막에는 Sep올 수 없음
            errMsg = "";
            int count = 0;
            string dateTimeStr = "";

            if (maskStr.Trim() == "") return true;
            switch (mType)
            {
                case MaskType.String:
                    for (int i = 0; i < CStringMaskStrs.Length; i++)
                        if (maskStr.IndexOf(CStringMaskStrs[i]) >= 0)
                            count++;

                    if (count == 0)
                    {
                        errMsg = (NetInfo.Language == LangMode.Ko ? "Mask가 제대로 지정되지 않았습니다.(XXX-XX OR ###-##)"
                            : "Maskが指定が間違っています。(XXX-XX OR ###-##)");
                        return false;
                    }
                    if (count > 1)
                    {
                        if (NetInfo.Language == LangMode.Ko)
                        {
                            errMsg = "Mask에는 ";
                            for (int i = 0; i < CStringMaskStrs.Length; i++)
                                errMsg += CStringMaskStrs[i] + ",";
                            errMsg += " 혼용하여 지정할 수 없습니다.";
                        }
                        else
                        {
                            errMsg = "Maskには[";
                            for (int i = 0; i < CStringMaskStrs.Length; i++)
                                errMsg += CStringMaskStrs[i] + ",";
                            errMsg += "]混用して指定できません。";
                        }
                        return false;
                    }
                    break;
                case MaskType.Month:
                    for (int i = 0; i < CMonthMaskStrs.Length; i++)
                        if (maskStr.ToUpper() == CMonthMaskStrs[i])
                            count++;
                    if (count == 0)
                    {
                        if (NetInfo.Language == LangMode.Ko)
                        {
                            errMsg = "Month의 Mask는 ";
                            for (int i = 0; i < CMonthMaskStrs.Length; i++)
                                errMsg += CMonthMaskStrs[i] + ",";
                            errMsg += " 만 지정가능합니다.";
                        }
                        else
                        {
                            errMsg = "MonthのMaskは[";
                            for (int i = 0; i < CMonthMaskStrs.Length; i++)
                                errMsg += CMonthMaskStrs[i] + ",";
                            errMsg += "]のみ指定可能です。";
                        }
                        return false;
                    }
                    break;
                case MaskType.Date:
                    for (int i = 0; i < CDateMaskStrs.Length; i++)
                        if (maskStr.ToUpper() == CDateMaskStrs[i])
                            count++;
                    if (count == 0)
                    {
                        if (NetInfo.Language == LangMode.Ko)
                        {
                            errMsg = "Date의 Mask는 ";
                            for (int i = 0; i < CDateMaskStrs.Length; i++)
                                errMsg += CDateMaskStrs[i] + ",";
                            errMsg += " 만 지정가능합니다.";
                        }
                        else
                        {
                            errMsg = "DateのMaskは[";
                            for (int i = 0; i < CDateMaskStrs.Length; i++)
                                errMsg += CDateMaskStrs[i] + ",";
                            errMsg += "]のみ指定可能です。";
                        }
                        return false;
                    }
                    break;
                case MaskType.Time:
                    for (int i = 0; i < CTimeMaskStrs.Length; i++)
                        if (maskStr.ToUpper() == CTimeMaskStrs[i])
                            count++;
                    if (count == 0)
                    {
                        if (NetInfo.Language == LangMode.Ko)
                        {
                            errMsg = "Time의 Mask는 ";
                            for (int i = 0; i < CTimeMaskStrs.Length; i++)
                                errMsg += CTimeMaskStrs[i] + ",";
                            errMsg += " 만 지정가능합니다.";
                        }
                        else
                        {
                            errMsg = "TimeのMaskは[";
                            for (int i = 0; i < CTimeMaskStrs.Length; i++)
                                errMsg += CTimeMaskStrs[i] + ",";
                            errMsg += "]のみ指定可能です。";
                        }
                        return false;
                    }
                    break;
                case MaskType.DateTime:
                    for (int i = 0; i < CDateMaskStrs.Length; i++)
                    {
                        for (int j = 0; j < CTimeMaskStrs.Length; j++)
                        {
                            dateTimeStr = CDateMaskStrs[i] + " " + CTimeMaskStrs[j];
                            if (maskStr.ToUpper() == dateTimeStr)
                                count++;
                        }
                    }
                    if (count == 0)
                    {
                        errMsg = (NetInfo.Language == LangMode.Ko ? "DateTime Mask가 잘못지정되었습니다.(ex:YYYY-MM-DD HH:MI:SS)"
                            : "DateTime Maskが間違って指定されています。(ex:YYYY-MM-DD HH:MI:SS)");
                        return false;
                    }
                    break;
            }
            return true;
        }
        public static string GetNullText(MaskType mType, ArrayList maskSymbols, int decimalDigits)
        {
            return GetNullText(mType, maskSymbols, decimalDigits, true, false);
        }
        public static string GetNullText(MaskType mType, ArrayList maskSymbols, int decimalDigits, bool isApplyDecimalDigits)
        {
            return GetNullText(mType, maskSymbols, decimalDigits, isApplyDecimalDigits, false);
        }
        /// <summary>
        /// MaskType, mask에 따른 Null일때의 Text를 가져옵니다.
        /// </summary>
        /// <param name="mType"> MaskType enum </param>
        /// <param name="maskSymbols"> MaskSymbol을 관리하는 ArrayList </param>
        /// <param name="decimalDigits"> Decimal Digits </param>
        /// <param name="isApplyDecimalDigits"> Decimal형의 경우 Digits를 표시할지 여부 </param>
        /// <returns> Null Text </returns>
        public static string GetNullText(MaskType mType, ArrayList maskSymbols, int decimalDigits, bool isApplyDecimalDigits, bool invalidDateIsStringEmpty)
        {
            //2006.01.10 invalidDateIsStringEmpty 추가(Date,Time,DateTime,Month형의 경우 유효한 값이 아니면 "" return 여부)
            string text = "", temp = "";
            char padChar = CZeroChar;
            switch (mType)
            {
                case MaskType.Date:
                case MaskType.Time:
                case MaskType.DateTime:
                case MaskType.Month:
                    try
                    {
                        if (invalidDateIsStringEmpty) return "";

                        foreach (MaskSymbol symbol in maskSymbols)
                        {
                            // (char) 0 Seperator는 유효하지 않음
                            if (symbol.Seperator != (char)0)
                                text += temp.PadLeft(symbol.MaskStrLen, padChar) + symbol.Seperator;
                            else
                                text += temp.PadLeft(symbol.MaskStrLen, padChar);
                            temp = "";
                        }
                    }
                    catch { }
                    break;
                case MaskType.String:
                    // String은 Space를 채움
                    padChar = CSpaceChar;
                    try
                    {
                        foreach (MaskSymbol symbol in maskSymbols)
                        {
                            // (char) 0 Seperator는 유효하지 않음
                            if (symbol.Seperator != (char)0)
                                text += temp.PadLeft(symbol.MaskStrLen, padChar) + symbol.Seperator;
                            else
                                text += temp.PadLeft(symbol.MaskStrLen, padChar);
                            temp = "";
                        }
                    }
                    catch { }
                    break;
                case MaskType.Decimal:
                    if (isApplyDecimalDigits && (decimalDigits > 0))
                        text = Comma + temp.PadLeft(decimalDigits, padChar);
                    break;
            }
            return text;
        }

        private static string ConvertDataValue(MaskType maskType, object dataValue)
        {
            //MaskType에 따라 data를 Convert하여 DisplayText를 구성할 수 있도록 변환
            if (dataValue == null) return "";
            if (dataValue.ToString() == "") return "";

            string data = string.Empty;
            switch (maskType)
            {
                case MaskType.String:
                case MaskType.Number:
                case MaskType.Decimal:
                    data = dataValue.ToString();
                    break;
                case MaskType.Month:
                    //YYYYMM형만 허용함
                    if (dataValue.ToString().Length == 6)
                    {
                        string monthStr = dataValue.ToString();
                        monthStr = monthStr.Substring(0, 4) + "/" + monthStr.Substring(4, 2) + "/01";
                        if (TypeCheck.IsDateTime(monthStr))
                            data = dataValue.ToString();
                        else
                            data = "";
                    }
                    else
                        data = "";
                    break;
                case MaskType.Date:
                    try
                    {
                        //YYYYMMDD도 데이타로 가능함
                        if (!TypeCheck.IsDateTime(dataValue))
                        {
                            if (dataValue.ToString().Length == 8)
                            {
                                string dateStr = dataValue.ToString();
                                dateStr = dateStr.Substring(0, 4) + "/" + dateStr.Substring(4, 2) + "/" + dateStr.Substring(6);
                                if (TypeCheck.IsDateTime(dateStr))
                                    data = dataValue.ToString();
                                else
                                    data = "";
                            }
                            else
                                data = "";
                        }
                        else
                        {
                            DateTime dt = DateTime.Parse(dataValue.ToString());
                            //YYYYMMDD 형태로 Return
                            data = dt.ToString("yyyyMMdd");
                        }
                    }
                    catch
                    {
                        data = "";
                    }
                    break;
                case MaskType.DateTime:
                    try
                    {
                        //YYYYMMDDHHMISS, YYYYMMDDHHMI도 데이타로 가능함
                        if (!TypeCheck.IsDateTime(dataValue))
                        {
                            if (dataValue.ToString().Length == 14)
                            {
                                string dateStr = dataValue.ToString();
                                dateStr = dateStr.Substring(0, 4) + "/" + dateStr.Substring(4, 2) + "/" + dateStr.Substring(6, 2)
                                    + " " + dateStr.Substring(8, 2) + ":" + dateStr.Substring(10, 2) + ":" + dateStr.Substring(12);
                                if (TypeCheck.IsDateTime(dateStr))
                                    data = dataValue.ToString();
                                else
                                    data = "";
                            }
                            else if (dataValue.ToString().Length == 12) //YYYYMMDDHHMI
                            {
                                string dateStr = dataValue.ToString();
                                dateStr = dateStr.Substring(0, 4) + "/" + dateStr.Substring(4, 2) + "/" + dateStr.Substring(6, 2)
                                    + " " + dateStr.Substring(8, 2) + ":" + dateStr.Substring(10, 2) + ":00";
                                if (TypeCheck.IsDateTime(dateStr))
                                    data = dataValue.ToString();
                                else
                                    data = "";
                            }
                            else
                                data = "";
                        }
                        else
                        {
                            DateTime dt = DateTime.Parse(dataValue.ToString());
                            //YYYYMMDDHHMISS 형태로 Return
                            data = dt.ToString("yyyyMMddHHmmss");
                        }
                    }
                    catch
                    {
                        data = "";
                    }
                    break;
                case MaskType.Time:
                    try
                    {
                        //HHMI,HHMISS도 가능함
                        if (!TypeCheck.IsTime(dataValue))
                        {
                            if (dataValue.ToString().Length == 6) //HHMISS
                            {
                                string timeStr = dataValue.ToString();
                                timeStr = timeStr.Substring(0, 2) + ":" + timeStr.Substring(2, 2) + ":" + timeStr.Substring(4);
                                if (TypeCheck.IsTime(timeStr))
                                    data = dataValue.ToString();
                                else
                                    data = "";
                            }
                            else if (dataValue.ToString().Length == 4) //HHMI
                            {
                                string timeStr = dataValue.ToString();
                                timeStr = timeStr.Substring(0, 2) + ":" + timeStr.Substring(2, 2) + ":00";
                                if (TypeCheck.IsTime(timeStr))
                                    data = dataValue.ToString();
                                else
                                    data = "";
                            }
                            else
                                data = "";
                        }
                        else
                        {
                            TimeSpan ts = TimeSpan.Parse(dataValue.ToString());
                            if (ts.Seconds == 0)  //HHMI
                                data = ts.Hours.ToString("00") + ts.Minutes.ToString("00");
                            else	//MMHISS
                                data = ts.Hours.ToString("00") + ts.Minutes.ToString("00") + ts.Seconds.ToString("00");
                        }
                    }
                    catch
                    {
                        data = "";
                    }
                    break;
            }
            return data;
        }

        //MED-11258
        private static string ConvertVietnameseDataValue(MaskType maskType, object dataValue)
        {
            //MaskType에 따라 data를 Convert하여 DisplayText를 구성할 수 있도록 변환
            if (dataValue == null) return "";
            if (dataValue.ToString() == "") return "";

            string data = string.Empty;
            switch (maskType)
            {
                case MaskType.Month:
                    //YYYYMM형만 허용함
                    if (dataValue.ToString().Length == 6)
                    {
                        string monthStr = dataValue.ToString();
                        //MED-11258
                        monthStr = "01/" + monthStr.Substring(4, 2) + "/" + monthStr.Substring(0, 4);
                        if (TypeCheck.IsDateTime(monthStr))
                            data = dataValue.ToString().Substring(4, 2) + dataValue.ToString().Substring(0, 4);
                        else
                            data = "";
                    }
                    else
                        data = "";
                    break;
                case MaskType.Date:
                    try
                    {
                        //YYYYMMDD도 데이타로 가능함
                        if (!TypeCheck.IsDateTime(dataValue))
                        {
                            if (dataValue.ToString().Length == 8)
                            {
                                string dateStr = dataValue.ToString();
                                dateStr = dateStr.Substring(0, 4) + "/" + dateStr.Substring(4, 2) + "/" + dateStr.Substring(6);
                                if (TypeCheck.IsDateTime(dateStr))
                                    data = dataValue.ToString();
                                else
                                    data = "";
                            }
                            else
                                data = "";
                        }
                        else
                        {
                            DateTime dt = DateTime.Parse(dataValue.ToString());
                            //YYYYMMDD 형태로 Return
                            data = dt.ToString("ddMMyyyy");

                        }
                    }
                    catch
                    {
                        data = "";
                    }
                    break;
            }
            return data;
        }

        public static string GetDisplayText(MaskType mType, ArrayList maskSymbols, int decimalDigits, bool generalNumberFormat, object dataValue)
        {
            return GetDisplayText(mType, maskSymbols, decimalDigits, generalNumberFormat, dataValue, true, false);
        }
        public static string GetDisplayText(MaskType mType, ArrayList maskSymbols, int decimalDigits, bool generalNumberFormat, object dataValue, bool isApplyDecimalDigits)
        {
            return GetDisplayText(mType, maskSymbols, decimalDigits, generalNumberFormat, dataValue, isApplyDecimalDigits, false);
        }
        /// <summary>
        /// Mask 정보에 따른 Display할 Text를 가져옵니다.
        /// 2006.01.06 invalidDateIsStringEmpty (Date,DateTime,Time,Month형의 경우 InValid하면 ""로 return할지 여부 추가
        /// </summary>
        /// <param name="mType"> MaskType Enum </param>
        /// <param name="maskSymbols"> MaskSymbol을 관리하는 ArrayList </param>
        /// <param name="decimalDigits"> Decimal Digits </param>
        /// <param name="dataValue"> DataValue string </param>
        /// <param name="isApplyDecimalDigits"> Decimal형일때 n2 형식으로 보여줄지 그냥 데이타를 보여줄지 여부 </param>
        /// <returns> Display Text </returns>
        public static string GetDisplayText(MaskType mType, ArrayList maskSymbols, int decimalDigits, bool generalNumberFormat, object dataValue, bool isApplyDecimalDigits, bool invalidDateIsStringEmpty)
        {
            string dispText = "", tempText = "";
            char padChar = CZeroChar;  // Pad 문자는 0
            int startIdx = 0, padLen = 0;

            string data = ConvertDataValue(mType, dataValue);
            //Text를 Mask에 맞추어 Set
            switch (mType)
            {
                case MaskType.String:
                case MaskType.Date:
                case MaskType.Time:
                case MaskType.DateTime:
                case MaskType.Month:
                    //String형은 Space로 Pad
                    if (mType == MaskType.String) padChar = CSpaceChar;
                    else if ((data == "") && invalidDateIsStringEmpty) return "";  //2006.01.06 유효한날짜가 아닐때 ""를 Return하여야 하면 Return ""
                    try
                    {
                        foreach (MaskSymbol symbol in maskSymbols)
                        {
                            if (startIdx <= data.Length)
                            {
                                // MaskStrLen보다 남은 문자가 적으면 cSpaceChar Pad
                                if (symbol.MaskStrLen > data.Length - startIdx)
                                {
                                    padLen = symbol.MaskStrLen - data.Length + startIdx;
                                    // (char) 0 Seperator는 유효하지 않음
                                    if (symbol.Seperator != (char)0)
                                        dispText += data.Substring(startIdx, symbol.MaskStrLen - padLen) + tempText.PadRight(padLen, padChar) + symbol.Seperator;
                                    else
                                        dispText += data.Substring(startIdx, symbol.MaskStrLen - padLen) + tempText.PadRight(padLen, padChar);

                                }
                                else
                                {
                                    // (char) 0 Seperator는 유효하지 않음
                                    if (symbol.Seperator != (char)0)
                                        dispText += data.Substring(startIdx, symbol.MaskStrLen) + symbol.Seperator;
                                    else
                                        dispText += data.Substring(startIdx, symbol.MaskStrLen);
                                }
                            }
                            else  // Space, Zero로 채움
                            {
                                // (char) 0 Seperator는 유효하지 않음
                                if (symbol.Seperator != (char)0)
                                    dispText += tempText.PadRight(symbol.MaskStrLen, padChar) + symbol.Seperator;
                                else
                                    dispText += tempText.PadRight(symbol.MaskStrLen, padChar);
                            }

                            tempText = "";
                            startIdx += symbol.MaskStrLen;
                        }
                    }
                    catch { }


                    //MED-12235: Change display text in grid view
                    if (mType == MaskType.Date && !string.IsNullOrEmpty(dataValue+""))
                    {
                        if (System.Threading.Thread.CurrentThread.CurrentUICulture.Name == "vi-VN")
                        {
                            DateTime date = GetDateTime(dataValue, maskSymbols);
                            dispText = date.ToString(MaskHelper.CDateVietnameseMask);
                        }
                    }

                    // maskSymbols가 없으면 Text그대로 SET
                    if (maskSymbols.Count < 1)
                        dispText = data;
                    // Date,DateTime,Time은 Valid Check
                    if ((mType == MaskType.Date) || (mType == MaskType.DateTime))
                    {
                        try
                        {
                            DateTime.Parse(dispText);
                        }
                        catch
                        {
                            dispText = GetNullText(mType, maskSymbols, decimalDigits);
                        }
                    }
                    else if (mType == MaskType.Time)
                    {
                        try
                        {
                            TimeSpan.Parse(dispText);
                        }
                        catch
                        {
                            dispText = GetNullText(mType, maskSymbols, decimalDigits);
                        }
                    }
                    else if (mType == MaskType.Month)
                    {
                        try
                        {
                            DateTime.Parse(dispText + "/01");
                        }
                        catch
                        {
                            dispText = GetNullText(mType, maskSymbols, decimalDigits);
                        }
                    }
                    break;
                case MaskType.Number:   // 111111 -> 111,111
                    try
                    {
                        //Number형식은 generalNumberFormat은 11111, 숫자형식은 n0
                        if (generalNumberFormat)
                            dispText = Convert.ToDouble(dataValue).ToString("g");
                        else
                            dispText = Convert.ToDouble(dataValue).ToString("n0");
                    }
                    catch
                    {
                        dispText = GetNullText(mType, maskSymbols, decimalDigits);
                    }
                    break;
                case MaskType.Decimal:  //111111.11 -> 111,111.11
                    try
                    {
                        //소수점이하 Format을 정확히 맞추어야 하면
                        if (isApplyDecimalDigits)
                        {
                            //Decimal형식은 generalNumberFormat은 11111.11, 숫자형식은 n2(11,111.11)
                            if (generalNumberFormat)
                                dispText = Convert.ToDouble(dataValue).ToString("n" + decimalDigits.ToString()).Replace(SplitNumber, "");
                            else
                                dispText = Convert.ToDouble(dataValue).ToString("n" + decimalDigits.ToString());
                        }
                        else
                        {
                            if (generalNumberFormat)
                                dispText = Convert.ToDouble(dataValue).ToString("g");
                            else
                            {
                                int digitCnt = 0;
                                int dotIndex = dataValue.ToString().IndexOf(Comma);
                                if (dotIndex >= 0)
                                    digitCnt = dataValue.ToString().Length - dotIndex - 1;
                                dispText = Convert.ToDouble(dataValue).ToString("n" + digitCnt.ToString());
                            }
                        }
                    }
                    catch
                    {
                        dispText = GetNullText(mType, maskSymbols, decimalDigits, isApplyDecimalDigits);
                    }
                    break;
                default:
                    dispText = data;
                    break;
            }
            return dispText;
        }

        //MED-11258
        public static string GetVietnameseDisplayText(MaskType mType, ArrayList maskSymbols, int decimalDigits, bool generalNumberFormat, object dataValue, bool isApplyDecimalDigits, bool invalidDateIsStringEmpty)
        {
            string dispText = "", tempText = "";
            char padChar = CZeroChar;  // Pad 문자는 0
            int startIdx = 0, padLen = 0;

            string data = ConvertVietnameseDataValue(mType, dataValue);
            //Text를 Mask에 맞추어 Set
            switch (mType)
            {
                case MaskType.String:
                case MaskType.Date:
                case MaskType.Time:
                case MaskType.DateTime:
                case MaskType.Month:
                    //String형은 Space로 Pad
                    if (mType == MaskType.String) padChar = CSpaceChar;
                    else if ((data == "") && invalidDateIsStringEmpty) return "";  //2006.01.06 유효한날짜가 아닐때 ""를 Return하여야 하면 Return ""
                    try
                    {
                        foreach (MaskSymbol symbol in maskSymbols)
                        {
                            if (startIdx <= data.Length)
                            {
                                // MaskStrLen보다 남은 문자가 적으면 cSpaceChar Pad
                                if (symbol.MaskStrLen > data.Length - startIdx)
                                {
                                    padLen = symbol.MaskStrLen - data.Length + startIdx;
                                    // (char) 0 Seperator는 유효하지 않음
                                    if (symbol.Seperator != (char)0)
                                        dispText += data.Substring(startIdx, symbol.MaskStrLen - padLen) + tempText.PadRight(padLen, padChar) + symbol.Seperator;
                                    else
                                        dispText += data.Substring(startIdx, symbol.MaskStrLen - padLen) + tempText.PadRight(padLen, padChar);

                                }
                                else
                                {
                                    // (char) 0 Seperator는 유효하지 않음
                                    if (symbol.Seperator != (char)0)
                                        dispText += data.Substring(startIdx, symbol.MaskStrLen) + symbol.Seperator;
                                    else
                                        dispText += data.Substring(startIdx, symbol.MaskStrLen);
                                }
                            }
                            else  // Space, Zero로 채움
                            {
                                // (char) 0 Seperator는 유효하지 않음
                                if (symbol.Seperator != (char)0)
                                    dispText += tempText.PadRight(symbol.MaskStrLen, padChar) + symbol.Seperator;
                                else
                                    dispText += tempText.PadRight(symbol.MaskStrLen, padChar);
                            }

                            tempText = "";
                            startIdx += symbol.MaskStrLen;
                        }
                    }
                    catch { }

                    // maskSymbols가 없으면 Text그대로 SET
                    if (maskSymbols.Count < 1)
                        dispText = data;
                    // Date,DateTime,Time은 Valid Check
                    if ((mType == MaskType.Date) || (mType == MaskType.DateTime))
                    {
                        try
                        {
                            DateTime.Parse(dispText);
                        }
                        catch
                        {
                            dispText = GetNullText(mType, maskSymbols, decimalDigits);
                        }
                    }
                    else if (mType == MaskType.Time)
                    {
                        try
                        {
                            TimeSpan.Parse(dispText);
                        }
                        catch
                        {
                            dispText = GetNullText(mType, maskSymbols, decimalDigits);
                        }
                    }
                    else if (mType == MaskType.Month)
                    {
                        try
                        {
                            DateTime.Parse(dispText + "/01");
                        }
                        catch
                        {
                            dispText = GetNullText(mType, maskSymbols, decimalDigits);
                        }
                    }
                    break;
                case MaskType.Number:   // 111111 -> 111,111
                    try
                    {
                        //Number형식은 generalNumberFormat은 11111, 숫자형식은 n0
                        if (generalNumberFormat)
                            dispText = Convert.ToDouble(dataValue).ToString("g");
                        else
                            dispText = Convert.ToDouble(dataValue).ToString("n0");
                    }
                    catch
                    {
                        dispText = GetNullText(mType, maskSymbols, decimalDigits);
                    }
                    break;
                case MaskType.Decimal:  //111111.11 -> 111,111.11
                    try
                    {
                        //소수점이하 Format을 정확히 맞추어야 하면
                        if (isApplyDecimalDigits)
                        {
                            //Decimal형식은 generalNumberFormat은 11111.11, 숫자형식은 n2(11,111.11)
                            if (generalNumberFormat)
                                dispText = Convert.ToDouble(dataValue).ToString("n" + decimalDigits.ToString()).Replace(SplitNumber, "");
                            else
                                dispText = Convert.ToDouble(dataValue).ToString("n" + decimalDigits.ToString());
                        }
                        else
                        {
                            if (generalNumberFormat)
                                dispText = Convert.ToDouble(dataValue).ToString("g");
                            else
                            {
                                int digitCnt = 0;
                                int dotIndex = dataValue.ToString().IndexOf(Comma);
                                if (dotIndex >= 0)
                                    digitCnt = dataValue.ToString().Length - dotIndex - 1;
                                dispText = Convert.ToDouble(dataValue).ToString("n" + digitCnt.ToString());
                            }
                        }
                    }
                    catch
                    {
                        dispText = GetNullText(mType, maskSymbols, decimalDigits, isApplyDecimalDigits);
                    }
                    break;
                default:
                    dispText = data;
                    break;
            }
            return dispText;
        }

        /// <summary>
        /// MaskType에 따른 DisplayText의 실제 DataValue를 가져옵니다.
        /// </summary>
        /// <param name="mType"> MaskType Enum </param>
        /// <param name="maskSymbols"> MaskSymbol을 관리하는 ArrayList </param>
        /// <param name="dispText"> Display Text </param>
        /// <returns> DataValue String </returns>
        public static string GetDataValue(MaskType mType, ArrayList maskSymbols, string dispText)
        {
            if (dispText.Length == 0) return string.Empty;
            string dataValue = string.Empty;
            switch (mType)
            {
                case MaskType.String:
                    try
                    {
                        string data = dispText;
                        foreach (MaskSymbol symbol in maskSymbols)
                            data = data.Replace(symbol.Seperator.ToString(), "");
                        // Space 문자 제거
                        dataValue = data.Trim();
                    }
                    catch
                    {
                        dataValue = string.Empty;
                    }
                    break;
                case MaskType.Month:  //YYYYMM
                    try
                    {
                        DateTime dt = DateTime.Parse(dispText + "/01");
                        return dt.ToString("yyyyMM");
                    }
                    catch
                    {
                        dataValue = string.Empty;
                    }
                    break;
                case MaskType.Date:  //yyyymmdd -> 2005.09.06 YYYY/MM/DD
                    try
                    {
                        //yyyy/MM/dd로 해도 1999-01-01형태로 나오므로 - -> /로 변경함
                        DateTime dt = DateTime.Parse(dispText);
                        return dt.ToString("yyyy/MM/dd").Replace("-", "/");
                    }
                    catch
                    {
                        dataValue = string.Empty;
                    }
                    break;
                case MaskType.DateTime:  //yyyymmddhhmiss  -> 2005.09.06 YYYY/MM/DD HH:MI:SS
                    // DateTime Valid Check
                    try
                    {
                        //yyyy/MM/dd로 해도 1999-01-01형태로 나오므로 - -> /로 변경함
                        DateTime dt = DateTime.Parse(dispText);
                        return dt.ToString("yyyy/MM/dd HH:mm:ss").Replace("-", "/");
                    }
                    catch
                    {
                        dataValue = string.Empty;
                    }
                    break;
                case MaskType.Time:
                    // Time Valid Check (HH:MI OR HH:MI:SS) -> HHMI, HHMISS
                    try
                    {
                        TimeSpan.Parse(dispText);
                        if ((dispText == "00:00") || (dispText == "00:00:00"))
                            dataValue = string.Empty;
                        else
                            dataValue = dispText.Replace(":", "");
                    }
                    catch
                    {
                        dataValue = string.Empty;
                    }
                    break;
                case MaskType.Number:
                    try
                    {
                        dataValue = Convert.ToDouble(dispText).ToString();
                    }
                    catch
                    {
                        dataValue = string.Empty;
                    }
                    break;
                case MaskType.Decimal:
                    try
                    {
                        dataValue = Convert.ToDouble(dispText).ToString();
                    }
                    catch
                    {
                        dataValue = string.Empty;
                    }
                    break;
            }
            return dataValue;
        }
        /// <summary>
        /// MaskType에 따른 Seperator를 반환합니다.
        /// </s	ummary>
        /// <param name="mType"> MaskType Enum </param>
        /// <param name="maskSymbols"> MaskSymbol을 관리하는 ArrayList </param>
        /// <returns> Seperator Char </returns>
        public static char GetSeperator(MaskType mType, ArrayList maskSymbols)
        {
            // MaskType에 따른 Seperator를 가져옵니다.
            // String형은 Seperator가 여러개 가능, 첫번째 Seperator
            // Date형은 /,-, Time형은 :
            char seperator = (char)0;
            int idx = 0;
            switch (mType)
            {
                case MaskType.String:
                    try
                    {
                        seperator = ((MaskSymbol)maskSymbols[0]).Seperator;
                    }
                    catch { }
                    break;
                case MaskType.Date:
                case MaskType.Month:
                    try
                    {
                        foreach (MaskSymbol symbol in maskSymbols)
                        {
                            if (symbol.MaskStr.ToUpper() == "YYYY")
                            {
                                if (symbol.Seperator != (char)0)
                                    seperator = symbol.Seperator;
                                else
                                    seperator = ((MaskSymbol)maskSymbols[idx - 1]).Seperator;
                                break;
                            }
                            idx++;
                        }
                    }
                    catch { }
                    break;
                case MaskType.Time:
                    try
                    {
                        foreach (MaskSymbol symbol in maskSymbols)
                        {
                            if (symbol.MaskStr.ToUpper() == "HH")
                            {
                                if (symbol.Seperator != (char)0)
                                    seperator = symbol.Seperator;
                                else
                                    seperator = ((MaskSymbol)maskSymbols[idx - 1]).Seperator;
                                break;
                            }
                            idx++;
                        }
                    }
                    catch { }
                    break;
            }
            return seperator;
        }
        /// <summary>
        /// MaskType, Mask에 따라 MaskSymbol 정보를 설정합니다.
        /// </summary>
        /// <param name="mType"> MaskType Enum </param>
        /// <param name="maskStr"> Mask String </param>
        /// <param name="maskSymbols"> MaskSymbol을 관리하는 ArrayList </param>
        public static void SetMaskSymbols(MaskType mType, string maskStr, ArrayList maskSymbols)
        {
            //maskSeperator /
            maskSeperator = (char)0;

            //기존 MaskSymbols clear
            maskSymbols.Clear();

            //Date(yyyy/mm/dd),DateTime(yyyy/mm/dd hh:mi:ss),Time(hh:mi:ss)은 mask가 없을때는 Default Mask로 SET
            string mask = maskStr;
            if (mask.Trim() == "")
            {
                if (mType == MaskType.Date)
                    mask = MaskHelper.CDateDefaultMask;
                else if (mType == MaskType.Month)
                    mask = MaskHelper.CMonthDefaultMask;
                else if (mType == MaskType.Time)
                    mask = MaskHelper.CTimeDefaultMask;
                else if (mType == MaskType.DateTime)
                    mask = MaskHelper.CDateTimeDefaultMask;
                else
                    return;
            }

            int strLength = 0;
            string strMask = "";
            char timeSeperator = ':';
            MaskSymbol symbol;
            switch (mType)
            {
                case MaskType.String:
                    for (int i = 0; i < MaskHelper.CStringMaskStrs.Length; i++)
                        if (mask.IndexOf(MaskHelper.CStringMaskStrs[i]) >= 0)
                        {
                            maskSeperator = MaskHelper.CStringMaskStrs[i][0];
                            break;
                        }
                    for (int i = 0; i < mask.Length; i++)
                    {
                        if (mask[i] == maskSeperator)
                        {
                            strMask += mask[i];
                            strLength++;
                        }
                        //Seperator이면 MaskSymbol SET
                        else
                        {
                            symbol = new MaskSymbol(mask[i], i, strMask, strLength);
                            maskSymbols.Add(symbol);
                            // 변수 Clear
                            strMask = "";
                            strLength = 0;
                        }
                    }
                    // 마지막에 Seperator가 없으면 마지막 MaskSymbol Set
                    if (mask[mask.Length - 1] == maskSeperator)
                    {
                        symbol = new MaskSymbol((char)0, mask.Length, strMask, strLength);
                        maskSymbols.Add(symbol);
                    }
                    break;
                case MaskType.Date:
                case MaskType.Month:
                    maskSeperator = GetSeperator(mask);
                    for (int i = 0; i < mask.Length; i++)
                    {
                        if (mask[i] == maskSeperator)
                        {
                            symbol = new MaskSymbol(mask[i], i, strMask, strLength);
                            maskSymbols.Add(symbol);
                            // 변수 Clear
                            strMask = "";
                            strLength = 0;
                        }
                        else
                        {
                            strMask += mask[i];
                            strLength++;
                        }
                    }
                    if (mask[mask.Length - 1] != maskSeperator)
                    {
                        symbol = new MaskSymbol((char)0, mask.Length, strMask, strLength);
                        maskSymbols.Add(symbol);
                    }
                    break;
                case MaskType.Time:
                    for (int i = 0; i < mask.Length; i++)
                    {
                        if (mask[i] == timeSeperator)
                        {
                            symbol = new MaskSymbol(mask[i], i, strMask, strLength);
                            maskSymbols.Add(symbol);
                            // 변수 Clear
                            strMask = "";
                            strLength = 0;
                        }
                        else
                        {
                            strMask += mask[i];
                            strLength++;
                        }
                    }
                    if (mask[mask.Length - 1] != timeSeperator)
                    {
                        symbol = new MaskSymbol((char)0, mask.Length, strMask, strLength);
                        maskSymbols.Add(symbol);
                    }
                    break;
                case MaskType.DateTime:
                    maskSeperator = mask[4];
                    for (int i = 0; i < mask.Length; i++)
                    {
                        if ((mask[i] == maskSeperator) || (mask[i] == timeSeperator) || (mask[i] == (char)32))
                        {
                            symbol = new MaskSymbol(mask[i], i, strMask, strLength);
                            maskSymbols.Add(symbol);
                            // 변수 Clear
                            strMask = "";
                            strLength = 0;
                        }
                        else
                        {
                            strMask += mask[i];
                            strLength++;
                        }
                    }
                    if (mask[mask.Length - 1] != timeSeperator)
                    {
                        symbol = new MaskSymbol((char)0, mask.Length, strMask, strLength);
                        maskSymbols.Add(symbol);
                    }
                    break;
                default:
                    break;
            }
        }


        //MED-11258
        public static void SetVietnameseMaskSymbols(MaskType mType, string maskStr, ArrayList maskSymbols)
        {
            //maskSeperator /
            maskSeperator = (char)0;

            //기존 MaskSymbols clear
            maskSymbols.Clear();

            //Date(yyyy/mm/dd),DateTime(yyyy/mm/dd hh:mi:ss),Time(hh:mi:ss)은 mask가 없을때는 Default Mask로 SET
            string mask = maskStr;
            if (mask.Trim() == "")
            {
                if (mType == MaskType.Date)
                    mask = MaskHelper.CDateDefaultMask;
                else if (mType == MaskType.Month)
                    mask = MaskHelper.CMonthDefaultMask;
                else if (mType == MaskType.Time)
                    mask = MaskHelper.CTimeDefaultMask;
                else if (mType == MaskType.DateTime)
                    mask = MaskHelper.CDateTimeDefaultMask;
                else
                    return;
            }

            int strLength = 0;
            string strMask = "";
            //char timeSeperator = ':';
            MaskSymbol symbol;
            switch (mType)
            {
                case MaskType.Date:
                case MaskType.Month:
                    maskSeperator = mask[2];
                    for (int i = 0; i < mask.Length; i++)
                    {
                        if (mask[i] == maskSeperator)
                        {
                            symbol = new MaskSymbol(mask[i], i, strMask, strLength);
                            maskSymbols.Add(symbol);
                            // 변수 Clear
                            strMask = "";
                            strLength = 0;
                        }
                        else
                        {
                            strMask += mask[i];
                            strLength++;
                        }
                    }
                    if (mask[mask.Length - 1] != maskSeperator)
                    {
                        symbol = new MaskSymbol((char)0, mask.Length, strMask, strLength);
                        maskSymbols.Add(symbol);
                    }
                    break;

            }
        }

        private static DateTime GetDateTime(object dataValue, ArrayList maskSymbols)
        {
            string dataText = dataValue + "";
            string[] separators = { "-", "/", " " };
            string[] words = dataText.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            
            int year = int.Parse(words[0]);
            int month = int.Parse(words[1]);
            int day = int.Parse(words[2]);
            if (words.Length > 3)
            {
                year = int.Parse(words[2]);
                month = int.Parse(words[1]);
                day = int.Parse(words[0]);
            }

            DateTime date = new DateTime(year, month, day);
            return date;
        }

        private static char GetSeperator(string mask)
        {
            if (mask.Contains("/")) return '/';
            if (mask.Contains("-")) return '-';
            return ' ';
        }
    }
}
