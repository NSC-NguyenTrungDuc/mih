using System;
using System.Data;
using System.Collections;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using IHIS.CloudConnector.Contracts.Arguments.System;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Results;

namespace IHIS.Framework
{
    public enum EMRIOTGubun
    {
        COM=0,         // 공통
        IN=1,          // 입원(재원중)
        OUT=2,         // 외래
        TOIWON = 3     // 퇴원
    }

    public class EMRHelper
    {
        #region  // static 맴버 선언
        internal static string mEMRVersion = "";
        internal static string mEMRInfo = "";
        internal static string mEMRPrintInfo = "";
        internal static string mEMRPrintIniFile = "";
        internal static string mEMRPrinterName = "";
        internal static string mEMRMBatchFile = "";
        internal static MultiLayout layResultLoad = new MultiLayout();
        #endregion // static 맴버 선언

        #region Static 생성자

        static EMRHelper()
        {
            string cmdText = " SELECT A.CODE, A.CODE_NAME "
                           + "   FROM BAS0102 A"
                           + "  WHERE A.HOSP_CODE = '" + EnvironInfo.HospCode + "' "
                           + "    AND A.CODE_TYPE = 'EMR_INFO' "
                           + "  ORDER BY A.CODE ";

            DataTable dt = Service.ExecuteDataTable(cmdText);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    switch (dr["code"].ToString())
                    {
                        case "01": // EMR 설치 경로 및 시작 프로그램 

                            EMRHelper.mEMRInfo = dr["code_name"].ToString();
                            
                            break;

                        case "02": // EMR 가상 프린터 프로그램 

                            EMRHelper.mEMRPrintInfo = dr["code_name"].ToString();

                            break;

                        case "03": // EMR 가상 프린터 사용 샘플 ini파일

                            EMRHelper.mEMRPrintIniFile = dr["code_name"].ToString();

                            break;

                        case "04": // EMR 출력용 프린터 이름

                            EMRHelper.mEMRPrinterName = dr["code_name"].ToString();

                            break;

                        case "05": // EMR version : OKADA, KUJYUKURI

                            EMRHelper.mEMRVersion = dr["code_name"].ToString();

                            break;

                        // <<2013.12.10>> LKH : EMRM 버전관리를 위해 bat 파일에서 버전관리 파일을 실행한 후 emr 을 실행한다.
                        case "06": 

                            EMRHelper.mEMRMBatchFile = dr["code_name"].ToString();

                            break;
                    }
                }
            }
        }

        #endregion

        #region EMR 설치 체크 

        private static bool checkExistEMR()
        {
            //bool returnValue = System.IO.File.Exists(@EMRHelper.mEMRInfo);
            bool returnValue = System.IO.File.Exists(@EMRHelper.mEMRMBatchFile);

            if (!returnValue)
            {
                string xMsg = NetInfo.Language == LangMode.Jr ? "電子カルテが設置されていません。担当者に連絡してください。" : "전자카르테가 설치되지 않았습니다. 담당자에게 연락바랍니다.";
                string xCap = NetInfo.Language == LangMode.Jr ? "" : "";
                MessageBox.Show(xMsg, xCap, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return returnValue;
        }

        #endregion

        #region EMR 실행 

        public static void ExecuteEMR (EMRIOTGubun aGubun, string aBunho, string aNaewonDate, string aGwa, string aDoctor, string aNaewonKey)
        {
            if (EMRHelper.checkExistEMR() == false)
                return;

            String command = "";
            String userid = "";
            String doctorId = "";

//            string cmd = @" SELECT A.DOCTOR        AS DOCTOR
//                              FROM BAS0270         A
//                            WHERE A.HOSP_CODE      = '" + EnvironInfo.HospCode + @"'
//                              AND A.SABUN          = '" + UserInfo.UserID + @"'
//                              AND A.DOCTOR_GWA     = '" + aGwa + @"'
//                          ";
            
//            // <<2014.02.11>> LKH : 과별의사가 아닌 원래의 의사코드로 EMR 사용하는 것으로 한다.
//            string cmda = @" SELECT A.ORG_DOCTOR     AS DOCTOR
//                             FROM BAS0270           A 
//                            WHERE A.HOSP_CODE       = '" + EnvironInfo.HospCode + @"'
//                              AND A.DOCTOR          = '" + UserInfo.UserID + @"'
//                          ";

            userid = UserInfo.UserID;
            doctorId = UserInfo.UserID;

            // updated by Cloud
            if (UserInfo.UserGubun == UserType.Doctor)
            {
                FwEMRHelperExecuteEMRArgs args = new FwEMRHelperExecuteEMRArgs();
                args.UserId = UserInfo.UserID;
                args.Gwa = aGwa;
                StringResult res = CloudService.Instance.Submit<StringResult, FwEMRHelperExecuteEMRArgs>(args);

                if (res.ExecutionStatus == ExecutionStatus.Success)
                {
                    if (!string.IsNullOrEmpty(res.Result))
                    {
                        doctorId = res.Result;
                    }
                }
            }

            //if (UserInfo.UserGubun == UserType.Doctor)
            //{
            //    object returnVal = Service.ExecuteScalar(cmd);

            //    if (returnVal != null && returnVal.ToString() != "")
            //    {
            //        doctorId = returnVal.ToString();
            //    }
            //}

            //
            try
            {
                if (mEMRVersion.Equals("OKADA")) // OKADA version
                {
                    if (aGubun == EMRIOTGubun.OUT) // 외래
                    {
                        //command = user id + user password + "2" 외래 + 환자번호+ 진료과 + 내원일자 + 내원, 입원 KEY
                        command = userid + "," + UserInfo.UserPswd + "," + "2" + "," + aBunho + "," + aGwa + "," + aNaewonDate.Replace("/", "") + "," + aNaewonKey;
                    }
                    else if (aGubun == EMRIOTGubun.IN) //입원
                    {
                        //command = user id + user password + "1" 입원 + 환자번호+ 진료과 + 입원일자 + 입원KEY
                        command = userid + "," + UserInfo.UserPswd + "," + "1" + "," + aBunho + "," + aGwa + "," + aNaewonDate.Replace("/", "") + "," + aNaewonKey;
                    }
                    else // 퇴원
                    {
                        //command = user id + user password + "3" 입원 + 환자번호+ 진료과 + 입원일자 + 입원KEY
                        command = userid + "," + UserInfo.UserPswd + "," + "3" + "," + aBunho + "," + aGwa + "," + aNaewonDate.Replace("/", "") + "," + aNaewonKey;
                    }
                }
                else if (mEMRVersion.Equals("KUJYUKURY")) // KUJYUKURY version
                {
                    command = "UI:" + userid + "," + "PW:" + UserInfo.UserPswd + "," + "PN:" + aBunho + "," + "IO:" + aGubun + "," + "DC:" + aGwa + "," + "DT:" + aNaewonDate.Replace("/", "") + "," + "DI:" + doctorId;

                }

                //if (command.Length > 0) Logs.WriteLog(String.Format("EMR Call Arguments=[{0}]", command.ToString()));
                Logs.WriteLog(String.Format("EMR Call Arguments=[{0}]", command.ToString()));

                System.Diagnostics.Process proExecute = new System.Diagnostics.Process();
                // <<2013.12.10>> LKH : EMRM 버전관리를 위해 bat 파일에서 버전관리 파일을 실행한 후 emr 을 실행한다.
                //proExecute.StartInfo.FileName = @EMRHelper.mEMRInfo;
                proExecute.StartInfo.CreateNoWindow = true;
                proExecute.StartInfo.UseShellExecute = false;
                proExecute.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                proExecute.StartInfo.FileName = @EMRHelper.mEMRMBatchFile;
                proExecute.StartInfo.Arguments = "\"" + command + "\"";
                //Logs.WriteLog(String.Format("EMR Call Arguments=[{0}]", proExecute.StartInfo.Arguments.ToString()));
                //
                proExecute.Start();
            }
            catch (Exception ex)
            {
                XMessageBox.Show(ex.Message, "ezEMR ERROR", MessageBoxIcon.Error);
            }
        }

        #endregion

        #region EMR로 출력 

        public static bool EMRPrint(XDataWindow aDataWindow, EMRIOTGubun aGubun, string aBunho, string aOrderDate, string aFkocskey, string aPgmID, string aNaewonKey)
        {
            Logs.WriteLog(String.Format("EMR Call(EMRPrint) Arguments=[{0}][{1}][{2}][{3}][{4}][{5}]", aGubun.ToString(), aBunho.ToString(), aOrderDate.ToString(), aFkocskey.ToString(), aPgmID.ToString(), aNaewonKey.ToString()));
            // EMR 설치여부
            if (!EMRHelper.checkExistEMR()) return false;
            //virtual Printer 유효여부
            bool installFlag = false;

            //ezConvert가 전 process를 실행중인지 check한다.
            Process[] localProcess;
            bool enablePrint = true;

            for (int i = 0; i < 1000000; i++)
            {
                localProcess = Process.GetProcesses();

                enablePrint = true;

                foreach (Process pr in localProcess)
                {
                    if (pr.ProcessName.IndexOf(EMRHelper.mEMRPrintInfo) >= 0)
                    {
                        enablePrint = false;
                        break;
                    }
                }

                if (enablePrint) break;

                System.Threading.Thread.Sleep(2000);
            }

            if (!enablePrint)
            {
                return false;
            }

            if (aDataWindow.RowCount == 0) return false;

            string aInDate = "";
            string aOutDate = "";
            string aChartKey2 = "";
            string aDwId = aDataWindow.DataWindowObject;
            string ioGubun = "";

            if (aGubun == EMRIOTGubun.OUT)
            {
                ioGubun = "O";
            }
            else
            {
                ioGubun = "I";
            }

            foreach (string s in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                if (s.IndexOf(EMRHelper.mEMRPrinterName) >= 0)
                {
                    installFlag = true;
                    //ini 파일 생성
                    //프로그램에 따라서 coding 바랍니다.

                    if (aGubun == EMRIOTGubun.OUT)
                    {
                        // 외래의 경우는 OutData 는 없고 InDate 는 OrderDate 와 동일하다
                        aInDate = aOrderDate;
                        aOutDate = "";

                        if (aFkocskey == "")
                            aChartKey2 = aNaewonKey;
                        else
                            aChartKey2 = aFkocskey;
                    }
                    else
                    {
                        // 입원정보 로드
                        if (EMRHelper.GetIpwonInfo(aNaewonKey, ref aInDate, ref aOutDate) == false)
                        {
                            return false;
                        }

                        if (aFkocskey == "")
                            aChartKey2 = aNaewonKey;
                        else
                            aChartKey2 = aFkocskey;

                    }

                    // ini 파일 생성
                    if (EMRMakeVirtualINIFile(aBunho, ioGubun, aInDate, aOutDate, aOrderDate, aChartKey2, aPgmID, aDwId, "Y") == false)
                        return false;

                    string origin_print = aDataWindow.PrintProperties.PrinterName;

                    //virtual drive print
                    aDataWindow.PrintProperties.PrinterName = EMRHelper.mEMRPrinterName;
                    aDataWindow.Print();
                    aDataWindow.PrintProperties.PrinterName = origin_print;

                    break;
                }
            }

            //virtual Driver가 설치되지 않은 경우
            if (!installFlag)
            {
                string xMsg = NetInfo.Language == LangMode.Jr ? "Virtual Driverが設置されていません。担当者に連絡してください。" : "Virtual Driver가 설치되지 않았습니다. 담당자에게 연락바랍니다.";
                string xCap = NetInfo.Language == LangMode.Jr ? "" : "";
                MessageBox.Show(xMsg, xCap);
            }

            return true;
        }

        #endregion

        #region EMR barcode 출력

        public static int GetEMRBarcodeReqSeq(EMRIOTGubun aGubun, String aBunho, String aSheetCD, String aOcsKey)
        {
            String ioGubun = "";
            String barSeq = "";

            switch (aGubun)
            {
                case EMRIOTGubun.OUT:
                    ioGubun = "O";
                    break;

                case EMRIOTGubun.COM:
                    ioGubun = "C";
                    break;

                default:
                    ioGubun = "I";
                    break;
            }

            try
            {
                string spName = "PR_EMR_GET_BARCODESEQ";
                //
                Hashtable inputList = new Hashtable();
                inputList.Add("I_INOUTGUBUN", ioGubun);
                inputList.Add("I_CHARTNO", aBunho);
                inputList.Add("I_CHEETCD", aSheetCD);
                inputList.Add("I_OCS_KEY", aOcsKey);
                inputList.Add("I_USERCD", UserInfo.UserID);
                inputList.Add("I_PCIP", Service.ClientIP);

                Hashtable outputList = new Hashtable();
                if (Service.ExecuteProcedure(spName, inputList, outputList))  //성공
                {
                    barSeq = outputList["O_BARSEQ"].ToString();
                }
                else  //실패
                {
                    //Service ErrCode -1.Oracle 이외의 에러, 그외는 Oracle 에러
                    throw new Exception(Service.ErrMsg);
                }
            }
            catch (Exception ex)
            {
                XMessageBox.Show(ex.Message, "ezEMR ERROR", MessageBoxIcon.Error);
                return 0;
            }

            return Int16.Parse(barSeq);
        }

        #endregion

        #region INI File Maker

        private static bool EMRMakeVirtualINIFile(string aBunho, string aInOutGubun, string aInDate, string aOutDate, string aOrderDate, string aChartKey2, string aPgm_id, string aDw_id, string aOverWrite)
        {
            bool sucessMake = false;

            try
            {
                string sheetID = EMRHelper.loadSheetID(aPgm_id, aDw_id);
                if (TypeCheck.IsNull(sheetID)) return sucessMake;

                sucessMake = true;

                string fileName = EMRHelper.mEMRPrintIniFile;

                if (mEMRVersion.Equals("OKADA")) // OKADA version
                {
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
                else if (mEMRVersion.Equals("KUJYUKURY")) // KUJYUKURY version
                {
                    IHIS.Framework.Kernel32.SetProfileString(fileName, "PATIENT", "PATIENTNO", aBunho);
                    IHIS.Framework.Kernel32.SetProfileString(fileName, "PATIENT", "INOUTFLAG", aInOutGubun);
                    IHIS.Framework.Kernel32.SetProfileString(fileName, "PATIENT", "INDATE", aInDate);
                    IHIS.Framework.Kernel32.SetProfileString(fileName, "PATIENT", "DISDATE", aOutDate);
                    IHIS.Framework.Kernel32.SetProfileString(fileName, "PATIENT", "USERID", UserInfo.UserID);
                    IHIS.Framework.Kernel32.SetProfileString(fileName, "PATIENT", "USERNAME", UserInfo.UserName);
                    IHIS.Framework.Kernel32.SetProfileString(fileName, "PATIENT", "SHEETCD", sheetID);
                    IHIS.Framework.Kernel32.SetProfileString(fileName, "PATIENT", "OVERWRITE", aOverWrite);
                    IHIS.Framework.Kernel32.SetProfileString(fileName, "PATIENT", "VPRTKEY", aInDate + "_" + sheetID);
                }

            }
            catch (Exception ex)
            {
                sucessMake = false;
                string xMsg = ex.Message;
                string xCap = "EMR FILE ERROR";
                XMessageBox.Show(xMsg, xCap, MessageBoxIcon.Error);
            }

            return sucessMake;
        }

        #endregion

        #region SHEET ID 로딩 

        private static string loadSheetID(string aPgm_id, string aDw_id)
        {
            string cmdText = "";
            object sheetid;

            cmdText = ""
                + "SELECT A.SHETSHTID "
                + "  FROM OCSPEMR A "
                + " WHERE A.HOSP_CODE  = '" + EnvironInfo.HospCode + "'"
                + "   AND A.PGM_ID = '" + aPgm_id + "'"
                + "   AND A.DW_ID  = '" + aDw_id + "'";

            sheetid = Service.ExecuteScalar(cmdText);

            if (TypeCheck.IsNull(sheetid))
            {
                string xMsg = NetInfo.Language == LangMode.Jr ? "書式紙が正確ではありません。 確認してください。" : "서식지가 정확하지않습니다. 확인바랍니다.";
                string xCap = NetInfo.Language == LangMode.Jr ? "" : "";
                MessageBox.Show(xMsg, xCap);
            }

            return sheetid.ToString();
        }

        #endregion

        #region 입원정보 로드

        private static bool GetIpwonInfo(string aNaewonKey, ref string aIpwonDate, ref string aToiwonDate)
        {
            string cmd = " SELECT TO_CHAR(A.IPWON_DATE, 'YYYY/MM/DD')  IPWON_DATE "
                       + "      , TO_CHAR(A.TOIWON_DATE, 'YYYY/MM/DD') TOIWON_DATE "
                       + "   FROM INP1001 A "
                       + "  WHERE A.HOSP_CODE  = '" + EnvironInfo.HospCode + "'"
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
