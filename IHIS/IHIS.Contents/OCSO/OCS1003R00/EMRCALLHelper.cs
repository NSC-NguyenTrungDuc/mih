using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using IHIS.Framework;

namespace IHIS.OCSO
{
    public static class EMRCALLHelper
    {
        private static string mEMRLocation = "";
        private static string mEMRConvertLocation = "";
        private static string mEMRIniFileLocation = "";
        private static string mEMRPrinterName = "";

        static EMRCALLHelper()
        {
            EMRCALLHelper.LoadEMRInfo();
        }

        #region EMR 설치 정보 및 각종 경로 로드

        private static void LoadEMRInfo()
        {
            string cmd = " SELECT A.CODE, A.CODE_NAME "
                       + "   FROM BAS0102 A "
                       + "  WHERE A.HOSP_CODE = '" + EnvironInfo.HospCode + "' "
                       + "    AND A.CODE_TYPE = 'EMR_INFO' "
                       + "  ORDER BY A.CODE ";

            DataTable dt = Service.ExecuteDataTable(cmd);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    switch (dr["code"].ToString())
                    {
                        case "01":

                            EMRCALLHelper.mEMRLocation = dr["code_name"].ToString();

                            break;

                        case "02":

                            EMRCALLHelper.mEMRConvertLocation = dr["code_name"].ToString();

                            break;

                        case "03":

                            EMRCALLHelper.mEMRIniFileLocation = dr["code_name"].ToString();

                            break;

                        case "04":

                            EMRCALLHelper.mEMRPrinterName = dr["code_name"].ToString();

                            break;
                    }
                }
            }


        }

        #endregion

        #region EMR 출력 

        public static bool PrintToEmr(string aPgmID, XDataWindow aDataWindow, string aIOGubun, string aBunho, string aOrderDate, string aNaewonKey)
        {
            string aInDate     = "";
            string aOutDate    = "";
            string aChartKey2  = "";
            string aDwId = aDataWindow.DataWindowObject;
            
            if (aIOGubun == "O")
            {
                // 외래의 경우는 OutData 는 없고 InDate 는 OrderDate 와 동일하다
                aInDate  = aOrderDate;
                aOutDate = "";
                aChartKey2 = aNaewonKey;
            }
            else
            {
                // 입원정보 로드
                if (EMRCALLHelper.GetIpwonInfo(aNaewonKey, ref aInDate, ref aOutDate) == false)
                {
                    return false;
                }

                aChartKey2 = aNaewonKey;

            }

            // ini 파일 생성
            EMRMakeVirtualINIFile(aBunho, aIOGubun, aInDate, aOutDate, aOrderDate, aChartKey2, aPgmID, aDwId, "Y");

            string orginPrinter = aDataWindow.PrintProperties.PrinterName;
            aDataWindow.PrintProperties.PrinterName = EMRCALLHelper.mEMRPrinterName;
            aDataWindow.Print();
            aDataWindow.PrintProperties.PrinterName = orginPrinter;

            return true;
 
        }

        private static string GetEMRSheetID(string aPgmID, string aDwID)
        {
            string cmd = " SELECT A.SHETSHTID "
                       + "   FROM OCSPEMR A "
                       + "  WHERE A.HOSP_CODE = '" + EnvironInfo.HospCode + "' "
                       + "    AND A.PGM_ID    = '" + aPgmID + "' "
                       + "    AND A.DW_ID     = '" + aDwID + "' ";
            string sheetid = "";

            DataTable dt = Service.ExecuteDataTable(cmd);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    sheetid = dr["shetshtid"].ToString();
                }
            }

            return sheetid;
        }

        #region INI File Maker

        private static bool EMRMakeVirtualINIFile(string aBunho, string aInOutGubun, string aInDate, string aOutDate, string aOrderDate, string aChartKey2, string aPgm_id, string aDw_id, string aOverWrite)
        {
            bool sucessMake = false;

            try
            {
                string sheetID = GetEMRSheetID(aPgm_id, aDw_id);
                if (TypeCheck.IsNull(sheetID)) return sucessMake;

                sucessMake = true;

                string fileName = EMRCALLHelper.mEMRIniFileLocation;

                IHIS.Framework.Kernel32.SetProfileString(fileName, "PATIENT", "PatientNo", aBunho);
                IHIS.Framework.Kernel32.SetProfileString(fileName, "PATIENT", "InOutGubun", aInOutGubun);
                IHIS.Framework.Kernel32.SetProfileString(fileName, "PATIENT", "PatientInDate", aInDate);
                IHIS.Framework.Kernel32.SetProfileString(fileName, "PATIENT", "PatientOutDate", aOutDate);
                IHIS.Framework.Kernel32.SetProfileString(fileName, "PATIENT", "VChartKey1", aOrderDate);
                IHIS.Framework.Kernel32.SetProfileString(fileName, "PATIENT", "VChartKey2", aChartKey2);
                IHIS.Framework.Kernel32.SetProfileString(fileName, "PATIENT", "UserID", UserInfo.UserID);
                IHIS.Framework.Kernel32.SetProfileString(fileName, "PATIENT", "UserName", UserInfo.UserName);
                IHIS.Framework.Kernel32.SetProfileString(fileName, "PATIENT", "DeptCode", UserInfo.BuseoCode);
                IHIS.Framework.Kernel32.SetProfileString(fileName, "PATIENT", "SheetID", sheetID);
                IHIS.Framework.Kernel32.SetProfileString(fileName, "PATIENT", "OverWrite", aOverWrite);

            }
            catch (Exception ex)
            {
                sucessMake = false;
                //string xMsg = ex.Message;
                //string xCap = "EMR FILE ERROR";
                //https://sofiamedix.atlassian.net/browse/MED-10610
                //XMessageBox.Show(xMsg, xCap, MessageBoxIcon.Error);
            }

            return sucessMake;
        }

        #endregion

        #endregion

        #region 입원정보 로드 

        private static bool GetIpwonInfo(string aNaewonKey, ref string aIpwonDate, ref string aToiwonDate)
        {
            string cmd = " SELECT TO_CHAR(A.IPWON_DATE, 'YYYY/MM/DD')  IPWON_DATE "
                       + "      , TO_CHAR(A.TOIWON_DATE, 'YYYY/MM/DD') TOIWON_DATE "
                       + "   FROM INP1001 A "
                       + "  WHERE A.HOSP_CODE = '" + EnvironInfo.HospCode + "' "
                       + "    AND A.PKINP1001 = " + aNaewonKey;

            DataTable dt = Service.ExecuteDataTable(cmd);

            if (dt != null && dt.Rows.Count > 0)
            {
                aIpwonDate = dt.Rows[0]["ipwon_date"].ToString();
                aToiwonDate = dt.Rows[0]["toiwon_date"].ToString();
            }
            else
            {
                return false;
            }

            if (aIpwonDate == "") return false;

            return true;
            
        }

        #endregion
    }
}
