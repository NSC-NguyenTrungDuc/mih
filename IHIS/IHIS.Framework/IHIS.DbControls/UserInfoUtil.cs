using System;
using System.Collections.Generic;
using System.IO;
using System.Collections;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Caching;
using IHIS.CloudConnector.Contracts.Arguments.Outs;
using IHIS.CloudConnector.Contracts.Arguments.System;
using IHIS.CloudConnector.Contracts.Results.Outs;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.CloudConnector.Messaging;
using IHIS.CloudConnector.Utility;
using IHIS.Framework.Properties;
using Microsoft.Win32;
using ComboListItemInfo = IHIS.CloudConnector.Contracts.Models.System.ComboListItemInfo;
using FormGwaItemInfo = IHIS.CloudConnector.Contracts.Models.System.FormGwaItemInfo;
using UserItemInfo = IHIS.CloudConnector.Contracts.Models.System.UserItemInfo;
using IHIS.CloudConnector.Contracts.Results;

namespace IHIS.Framework
{
    /// <summary>
    /// UserInfo(사용자정보 Class)에 대한 요약 설명입니다.
    /// </summary>
    public class UserInfoUtil
    {
        private static List<ComboListItemInfo> buseoComboList;

        /// <summary>
        /// CheckUser (비밀번호 Check 하지 않음)
        /// </summary>
        /// <param name="systemID"></param>
        /// <param name="userID"></param>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        public static bool CheckUser(string systemID, string userID, out string errMsg)
        {
            errMsg = "";
            return CheckUserSub(systemID, userID, "", false, out errMsg);
        }
        /// <summary>
        /// CheckUser (비밀번호 Check 함 )
        /// </summary>
        /// <param name="systemID"></param>
        /// <param name="userID"></param>
        /// <param name="pswd"></param>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        public static bool CheckUser(string systemID, string userID, string pswd, out string errMsg)
        {
            errMsg = "";
            return CheckUserSub(systemID, userID, pswd, true, out errMsg);
        }

        public static bool CheckUser(string userID, string pswd, CheckUserLoginResult result, out string errMsg)
        {
            errMsg = "";
            return CheckUserSub(userID, pswd, true, result, out errMsg);
        }

        //2010.12.20 kimminsoo add
        public static bool CheckUserDoctor(string systemID, string userID, string pswd, string gwa, string gwaName, out string errMsg)
        {
            errMsg = "";
            return CheckUserSubDoctor(systemID, userID, pswd, true, gwa, gwaName, out errMsg);
        }

        //2013/02/10 insert by jc [オーダメイン画面でコンボボックスでユーザ変更時使用]
        public static bool CheckUserDoctor(string systemID, string userID, string pswd, bool checkPswd, string gwa, string gwaName, out string errMsg)
        {
            errMsg = "";
            return CheckUserSubDoctor(systemID, userID, pswd, checkPswd, gwa, gwaName, out errMsg);
        }

        public static bool CheckUserDoctor(string userID, string pswd, string gwa, string gwaName, CheckUserDoctorLoginResult result, out string errMsg)
        {
            errMsg = "";
            return CheckUserSubDoctor(userID, pswd, true, gwa, gwaName, result, out errMsg);
        }

        private static bool CheckUserSubDoctor(string systemID, string userID, string pswd, bool checkPswd, string gwa, string gwaName, out string errMsg)
        {
            errMsg = "";
            if (userID.Trim() == "")
            {
                errMsg = XMsg.GetMsg("M005"); // 사용자ID가 입력되지 않았습니다.
                return false;
            }
            //2005.11.23 비밀번호 Check 여부 추가
            if (checkPswd && pswd.Trim() == "")
            {
                errMsg = XMsg.GetMsg("M006"); // 비밀번호가 입력되지 않았습니다.
                return false;
            }

            /*<미확정> Input, Output은 협의후 확정 호출 PROC = PR_ADM_CHECK_LOGIN
            *Input = 시스템ID + UserID + Pswd + 비밀번호 Check여부(Y/N) + IP Addr
            *Output = 현재 총 21개
            */

            try
            {
                // Cloud service
                UserInfoCheckUserSubDoctorArgs checkUserSubDoctorArgs = new UserInfoCheckUserSubDoctorArgs(gwa, new IHIS.CloudConnector.Contracts.Models.System.UserRequestInfo());
                checkUserSubDoctorArgs.UserInfo.SysId = systemID.Trim();
                checkUserSubDoctorArgs.UserInfo.UserId = userID.Trim();
                checkUserSubDoctorArgs.UserInfo.UserScrt = pswd;
                checkUserSubDoctorArgs.UserInfo.ScrtCheckYn = checkPswd ? "Y" : "N";
                checkUserSubDoctorArgs.UserInfo.IpAddr = Service.ClientIP;
                checkUserSubDoctorArgs.Gwa = gwa;
                UserInfoCheckUserSubDoctorResult result =
                    CloudService.Instance.Submit<UserInfoCheckUserSubDoctorResult, UserInfoCheckUserSubDoctorArgs>(checkUserSubDoctorArgs);
                if (result != null)
                {
                    if (String.IsNullOrEmpty(result.ErrorMessage))
                    {
                        UserItemInfo user = result.UserItemInfo;
                        UserInfo.UserID = userID.Trim();
                        UserInfo.UserPswd = pswd.Trim();
                        UserInfo.UserName = user.UserNm;

                        buseoComboList = result.CboList;
                        SingleLayout buseoLayout = new SingleLayout();
                        buseoLayout.LayoutItems.Add("buseo_code");
                        buseoLayout.LayoutItems.Add("buseo_name");
                        buseoLayout.ExecuteQuery = GetBuseoList;
                        buseoLayout.QueryLayout();

                        if (TypeCheck.IsNull(buseoLayout.GetItemValue("buseo_code")))
                        {
                            UserInfo.BuseoCode = user.UserDept;
                            UserInfo.BuseoName = user.DeptNm;
                        }
                        else
                        {
                            UserInfo.BuseoCode = buseoLayout.GetItemValue("buseo_code").ToString();
                            UserInfo.BuseoName = buseoLayout.GetItemValue("buseo_name").ToString();
                        }
                        //UserInfo.Gwa = outputList["O_GWA_CODE"].ToString();
                        //UserInfo.GwaName = outputList["O_GWA_NAME"].ToString();
                        UserInfo.Gwa = gwa;
                        UserInfo.GwaName = gwaName;

                        try
                        {
                            UserInfo.UserLevel = Int32.Parse(user.UserLevel);
                        }
                        catch
                        {
                            UserInfo.UserLevel = 0;
                        }
                        UserInfo.UserGroup = user.UserGroup;
                        try
                        {
                            UserInfo.UserGubun = (UserType)(Int32.Parse(user.UserGubun));
                        }
                        catch
                        {
                            UserInfo.UserGubun = UserType.Normal;
                        }
                        try
                        {
                            UserInfo.BuseoGubun = (BuseoType)(Int32.Parse(user.BuseoGubun));
                        }
                        catch
                        {
                            UserInfo.BuseoGubun = BuseoType.Extra;
                        }

                        UserInfo.YaksokComID = user.YaksokComId;
                        UserInfo.YaksokOpenID = user.YaksokOpenId;
                        UserInfo.SlipComID = user.SlipComId;
                        UserInfo.SlipOpenID = user.SlipOpenId;
                        UserInfo.SangComID = user.SangComId;
                        UserInfo.SangOpenID = user.SangOpenId;
                        UserInfo.JindanComID = user.JindanComId;
                        UserInfo.JindanOpenID = user.JindanOpenId;

                        //2006.01.03 NurseTeam 추가
                        UserInfo.NurseTeam = user.NurseTeam;

                        //2006.01.26 CPComID, CPOpenID 추가
                        UserInfo.CPComID = user.CpComId;
                        UserInfo.CPOpenID = user.CpOpenId;
                        //2006.03.03 InputGubun  추가
                        UserInfo.InputGubun = user.InputGubun;


                        // 병동부서인 경우 과코드,과명은 ""이 되고, 병동코드,병동명 SET
                        // 대신 HoDong이 셋팅된다.
                        //if (UserInfo.BuseoGubun == BuseoType.Inp)
                        //{
                        //    UserInfo.HoDong = UserInfo.Gwa;
                        //    UserInfo.HoDongName = UserInfo.GwaName;
                        //}

                        //2010.07.06 doctorID  추가 --> 2010.12.20 kimminsoo add
                        UserInfo.DoctorID = gwa + UserInfo.UserID;//outputList["O_DOCTOR_ID"].ToString();
                    }
                    else
                    {
                        errMsg = result.ErrorMessage;
                        return false;
                    }
                }
                else  //실패
                {
                    //Service ErrCode -1.Oracle 이외의 에러, 그외는 Oracle 에러
                    errMsg = Resources.MSG_001;
                    return false;
                }

                /*string spName = "PR_ADM_CHECK_LOGIN";
                //INPUT SET = I_SYS_ID + I_USER_ID + I_USER_SCRT + I_SCRT_CHECK_YN: 비밀번호 Check 여부(Y/N) + I_IP_ADDR
                Hashtable inputList = new Hashtable();
                inputList.Add("I_SYS_ID", systemID.Trim());
                inputList.Add("I_USER_ID", userID.Trim());
                inputList.Add("I_USER_SCRT", pswd);
                inputList.Add("I_SCRT_CHECK_YN", (checkPswd ? "Y" : "N"));
                inputList.Add("I_IP_ADDR", Service.ClientIP);

                Hashtable outputList = new Hashtable();
                if (Service.ExecuteProcedure(spName, inputList, outputList))  //성공
                {
                    UserInfo.UserID = userID.Trim();
                    UserInfo.UserPswd = pswd.Trim();
                    UserInfo.UserName = outputList["O_USER_NM"].ToString();

                    SingleLayout buseoLayout = new SingleLayout();
                    buseoLayout.LayoutItems.Add("buseo_code");
                    buseoLayout.LayoutItems.Add("buseo_name");
                    buseoLayout.QuerySQL = @"SELECT A.BUSEO_CODE, A.BUSEO_NAME
                                               FROM BAS0260 A
                                              WHERE A.HOSP_CODE = '" + EnvironInfo.HospCode + "'"
                                            + " AND A.GWA = '" + gwa + "'";
                    buseoLayout.QueryLayout();

                    if (TypeCheck.IsNull(buseoLayout.GetItemValue("buseo_code")))
                    {
                        UserInfo.BuseoCode = outputList["O_USER_DEPT"].ToString();
                        UserInfo.BuseoName = outputList["O_DEPT_NM"].ToString();
                    }
                    else
                    {
                        UserInfo.BuseoCode = buseoLayout.GetItemValue("buseo_code").ToString();
                        UserInfo.BuseoName = buseoLayout.GetItemValue("buseo_name").ToString();
                    }
                    //UserInfo.Gwa = outputList["O_GWA_CODE"].ToString();
                    //UserInfo.GwaName = outputList["O_GWA_NAME"].ToString();
                    UserInfo.Gwa = gwa;
                    UserInfo.GwaName = gwaName;

                    try
                    {
                        UserInfo.UserLevel = Int32.Parse(outputList["O_USER_LEVEL"].ToString());
                    }
                    catch
                    {
                        UserInfo.UserLevel = 0;
                    }
                    UserInfo.UserGroup = outputList["O_USER_GROUP"].ToString();
                    try
                    {
                        UserInfo.UserGubun = (UserType)(Int32.Parse(outputList["O_USER_GUBUN"].ToString()));
                    }
                    catch
                    {
                        UserInfo.UserGubun = UserType.Normal;
                    }
                    try
                    {
                        UserInfo.BuseoGubun = (BuseoType)(Int32.Parse(outputList["O_BUSEO_GUBUN"].ToString()));
                    }
                    catch
                    {
                        UserInfo.BuseoGubun = BuseoType.Extra;
                    }

                    UserInfo.YaksokComID = outputList["O_YAKSOK_COM_ID"].ToString();
                    UserInfo.YaksokOpenID = outputList["O_YAKSOK_OPEN_ID"].ToString();
                    UserInfo.SlipComID = outputList["O_SLIP_COM_ID"].ToString();
                    UserInfo.SlipOpenID = outputList["O_SLIP_OPEN_ID"].ToString();
                    UserInfo.SangComID = outputList["O_SANG_COM_ID"].ToString();
                    UserInfo.SangOpenID = outputList["O_SANG_OPEN_ID"].ToString();
                    UserInfo.JindanComID = outputList["O_JINDAN_COM_ID"].ToString();
                    UserInfo.JindanOpenID = outputList["O_JINDAN_OPEN_ID"].ToString();

                    //2006.01.03 NurseTeam 추가
                    UserInfo.NurseTeam = outputList["O_NURSE_TEAM"].ToString();

                    //2006.01.26 CPComID, CPOpenID 추가
                    UserInfo.CPComID = outputList["O_CP_COM_ID"].ToString();
                    UserInfo.CPOpenID = outputList["O_CP_OPEN_ID"].ToString();
                    //2006.03.03 InputGubun  추가
                    UserInfo.InputGubun = outputList["O_INPUT_GUBUN"].ToString();


                    // 병동부서인 경우 과코드,과명은 ""이 되고, 병동코드,병동명 SET
                    // 대신 HoDong이 셋팅된다.
                    //if (UserInfo.BuseoGubun == BuseoType.Inp)
                    //{
                    //    UserInfo.HoDong = UserInfo.Gwa;
                    //    UserInfo.HoDongName = UserInfo.GwaName;
                    //}

                    //2010.07.06 doctorID  추가 --> 2010.12.20 kimminsoo add
                    UserInfo.DoctorID = gwa + UserInfo.userID;//outputList["O_DOCTOR_ID"].ToString();

                }
                else  //실패
                {
                    //Service ErrCode -1.Oracle 이외의 에러, 그외는 Oracle 에러
                    errMsg = Service.ErrMsg;
                    return false;
                }*/
            }
            catch (Exception xe)
            {
                errMsg = XMsg.GetMsg("M044", xe); // 사용자정보 생성에러[" + xe.Message + "]"
                return false;
            }
            return true;
        }

        private static bool CheckUserSubDoctor(string userID, string pswd, bool checkPswd, string gwa, string gwaName, CheckUserDoctorLoginResult result, out string errMsg)
        {
            errMsg = "";
            if (userID.Trim() == "")
            {
                errMsg = XMsg.GetMsg("M005"); // 사용자ID가 입력되지 않았습니다.
                return false;
            }
            //2005.11.23 비밀번호 Check 여부 추가
            if (checkPswd && pswd.Trim() == "")
            {
                errMsg = XMsg.GetMsg("M006"); // 비밀번호가 입력되지 않았습니다.
                return false;
            }

            /*<미확정> Input, Output은 협의후 확정 호출 PROC = PR_ADM_CHECK_LOGIN
            *Input = 시스템ID + UserID + Pswd + 비밀번호 Check여부(Y/N) + IP Addr
            *Output = 현재 총 21개
            */

            try
            {
                if (result != null)
                {
                    if (String.IsNullOrEmpty(result.ErrorMessage))
                    {
                        UserItemInfo user = result.UserItemInfo;
                        UserInfo.UserID = userID.Trim();
                        UserInfo.UserPswd = pswd.Trim();
                        UserInfo.UserName = user.UserNm;
                        UserInfo.HospCode = user.HospCode;
                        UserInfo.HospName = user.HospName;

                        buseoComboList = result.CboList;
                        SingleLayout buseoLayout = new SingleLayout();
                        buseoLayout.LayoutItems.Add("buseo_code");
                        buseoLayout.LayoutItems.Add("buseo_name");
                        buseoLayout.ExecuteQuery = GetBuseoList;
                        buseoLayout.QueryLayout();

                        if (TypeCheck.IsNull(buseoLayout.GetItemValue("buseo_code")))
                        {
                            UserInfo.BuseoCode = user.UserDept;
                            UserInfo.BuseoName = user.DeptNm;
                        }
                        else
                        {
                            UserInfo.BuseoCode = buseoLayout.GetItemValue("buseo_code").ToString();
                            UserInfo.BuseoName = buseoLayout.GetItemValue("buseo_name").ToString();
                        }
                        //UserInfo.Gwa = outputList["O_GWA_CODE"].ToString();
                        //UserInfo.GwaName = outputList["O_GWA_NAME"].ToString();
                        UserInfo.Gwa = gwa;
                        UserInfo.GwaName = gwaName;

                        try
                        {
                            UserInfo.UserLevel = Int32.Parse(user.UserLevel);
                        }
                        catch
                        {
                            UserInfo.UserLevel = 0;
                        }
                        UserInfo.UserGroup = user.UserGroup;
                        try
                        {
                            UserInfo.UserGubun = (UserType)(Int32.Parse(user.UserGubun));
                        }
                        catch
                        {
                            UserInfo.UserGubun = UserType.Normal;
                        }
                        try
                        {
                            UserInfo.BuseoGubun = (BuseoType)(Int32.Parse(user.BuseoGubun));
                        }
                        catch
                        {
                            UserInfo.BuseoGubun = BuseoType.Extra;
                        }

                        UserInfo.YaksokComID = user.YaksokComId;
                        UserInfo.YaksokOpenID = user.YaksokOpenId;
                        UserInfo.SlipComID = user.SlipComId;
                        UserInfo.SlipOpenID = user.SlipOpenId;
                        UserInfo.SangComID = user.SangComId;
                        UserInfo.SangOpenID = user.SangOpenId;
                        UserInfo.JindanComID = user.JindanComId;
                        UserInfo.JindanOpenID = user.JindanOpenId;

                        //2006.01.03 NurseTeam 추가
                        UserInfo.NurseTeam = user.NurseTeam;

                        //2006.01.26 CPComID, CPOpenID 추가
                        UserInfo.CPComID = user.CpComId;
                        UserInfo.CPOpenID = user.CpOpenId;
                        //2006.03.03 InputGubun  추가
                        UserInfo.InputGubun = user.InputGubun;


                        // 병동부서인 경우 과코드,과명은 ""이 되고, 병동코드,병동명 SET
                        // 대신 HoDong이 셋팅된다.
                        //if (UserInfo.BuseoGubun == BuseoType.Inp)
                        //{
                        //    UserInfo.HoDong = UserInfo.Gwa;
                        //    UserInfo.HoDongName = UserInfo.GwaName;
                        //}

                        //2010.07.06 doctorID  추가 --> 2010.12.20 kimminsoo add
                        UserInfo.DoctorID = gwa + UserInfo.UserID;//outputList["O_DOCTOR_ID"].ToString();
                    }
                    else
                    {
                        errMsg = result.ErrorMessage;
                        return false;
                    }
                }
                else  //실패
                {
                    //Service ErrCode -1.Oracle 이외의 에러, 그외는 Oracle 에러
                    errMsg = Resources.MSG_001;
                    return false;
                }
            }
            catch (Exception xe)
            {
                errMsg = XMsg.GetMsg("M044", xe); // 사용자정보 생성에러[" + xe.Message + "]"
                return false;
            }
            return true;
        }

        /// <summary>
        /// 사용자 ID, 비밀번호를 입력받아 Login Check 및 사용자 정보 구성 (ExecuteProcedure Hashtable 사용)
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="pswd"></param>
        /// <returns></returns>
        private static bool CheckUserSub(string systemID, string userID, string pswd, bool checkPswd, out string errMsg)
        {
            errMsg = "";
            if (userID.Trim() == "")
            {
                errMsg = XMsg.GetMsg("M005"); // 사용자ID가 입력되지 않았습니다.
                return false;
            }
            //2005.11.23 비밀번호 Check 여부 추가
            if (checkPswd && pswd.Trim() == "")
            {
                errMsg = XMsg.GetMsg("M006"); // 비밀번호가 입력되지 않았습니다.
                return false;
            }

            /*<미확정> Input, Output은 협의후 확정 호출 PROC = PR_ADM_CHECK_LOGIN
            *Input = 시스템ID + UserID + Pswd + 비밀번호 Check여부(Y/N) + IP Addr
            *Output = 현재 총 21개
            */

            try
            {
                // Cloud service
                UserInfoCheckUserSubArgs checkUserSubArgs = new UserInfoCheckUserSubArgs();
                checkUserSubArgs.UserInfo.SysId = systemID.Trim();
                checkUserSubArgs.UserInfo.UserId = userID.Trim();
                checkUserSubArgs.UserInfo.UserScrt = Utility.CreateMd5Hash(pswd, false); ;
                checkUserSubArgs.UserInfo.ScrtCheckYn = checkPswd ? "Y" : "N";
                checkUserSubArgs.UserInfo.IpAddr = Service.ClientIP;
                UserInfoCheckUserSubResult result =
                    CloudService.Instance.Submit<UserInfoCheckUserSubResult, UserInfoCheckUserSubArgs>(checkUserSubArgs);
                if (result.ExecutionStatus == ExecutionStatus.Success)
                {
                    if (String.IsNullOrEmpty(result.ErrorMessage))
                    {
                        UserItemInfo user = result.UserItemInfo;
                        UserInfo.UserID = userID.Trim();
                        UserInfo.UserPswd = pswd.Trim();
                        UserInfo.UserName = user.UserNm;
                        UserInfo.BuseoCode = user.UserDept;
                        UserInfo.BuseoName = user.DeptNm;
                        UserInfo.Gwa = user.GwaCode;
                        UserInfo.GwaName = user.GwaName;
                        // TODO 2015.06.18 AnhNV added
                        UserInfo.HospCode = user.HospCode;
                        UserInfo.HospName = user.HospName;

                        try
                        {
                            UserInfo.UserLevel = Int32.Parse(user.UserLevel);
                        }
                        catch
                        {
                            UserInfo.UserLevel = 0;
                        }
                        UserInfo.UserGroup = user.UserGroup;
                        try
                        {
                            UserInfo.UserGubun = (UserType)(Int32.Parse(user.UserGubun));
                        }
                        catch
                        {
                            UserInfo.UserGubun = UserType.Normal;
                        }
                        try
                        {
                            UserInfo.BuseoGubun = (BuseoType)(Int32.Parse(user.BuseoGubun));
                        }
                        catch
                        {
                            UserInfo.BuseoGubun = BuseoType.Extra;
                        }

                        UserInfo.YaksokComID = user.YaksokComId;
                        UserInfo.YaksokOpenID = user.YaksokOpenId;
                        UserInfo.SlipComID = user.SlipComId;
                        UserInfo.SlipOpenID = user.SlipOpenId;
                        UserInfo.SangComID = user.SangComId;
                        UserInfo.SangOpenID = user.SangOpenId;
                        UserInfo.JindanComID = user.JindanComId;
                        UserInfo.JindanOpenID = user.JindanOpenId;

                        //2006.01.03 NurseTeam 추가
                        UserInfo.NurseTeam = user.NurseTeam;

                        //2006.01.26 CPComID, CPOpenID 추가
                        UserInfo.CPComID = user.CpComId;
                        UserInfo.CPOpenID = user.CpOpenId;
                        //2006.03.03 InputGubun  추가
                        UserInfo.InputGubun = user.InputGubun;


                        // 병동부서인 경우 과코드,과명은 ""이 되고, 병동코드,병동명 SET
                        // 대신 HoDong이 셋팅된다.
                        if (UserInfo.BuseoGubun == BuseoType.Inp)
                        {
                            UserInfo.HoDong = UserInfo.Gwa;
                            UserInfo.HoDongName = UserInfo.GwaName;
                            UserInfo.Gwa = "";
                            UserInfo.GwaName = "";
                        }

                        //2010.07.06 doctorID  추가
                        UserInfo.DoctorID = user.DoctorId;
                    }
                    else
                    {
                        errMsg = result.ErrorMessage;
                        return false;
                    }
                }
                else  //실패
                {
                    //Service ErrCode -1.Oracle 이외의 에러, 그외는 Oracle 에러
                    errMsg = Resources.MSG_001;
                    return false;
                }

                /*string spName = "PR_ADM_CHECK_LOGIN";
				//INPUT SET = I_SYS_ID + I_USER_ID + I_USER_SCRT + I_SCRT_CHECK_YN: 비밀번호 Check 여부(Y/N) + I_IP_ADDR
				Hashtable inputList = new Hashtable();
				inputList.Add("I_SYS_ID",systemID.Trim());
				inputList.Add("I_USER_ID",userID.Trim());
				inputList.Add("I_USER_SCRT",pswd);
				inputList.Add("I_SCRT_CHECK_YN",(checkPswd ? "Y" : "N" ));
				inputList.Add("I_IP_ADDR", Service.ClientIP);
                			
				Hashtable outputList = new Hashtable();
				if(Service.ExecuteProcedure(spName, inputList, outputList))  //성공
				{
					UserInfo.UserID		= userID.Trim();
					UserInfo.UserPswd   = pswd.Trim();
					UserInfo.UserName   = outputList["O_USER_NM"].ToString();
					UserInfo.BuseoCode  = outputList["O_USER_DEPT"].ToString();
					UserInfo.BuseoName  = outputList["O_DEPT_NM"].ToString();
					UserInfo.Gwa		= outputList["O_GWA_CODE"].ToString();
					UserInfo.GwaName    = outputList["O_GWA_NAME"].ToString();

                    try
					{
						UserInfo.UserLevel = Int32.Parse(outputList["O_USER_LEVEL"].ToString());
					}
					catch
					{
						UserInfo.UserLevel = 0;
					}
					UserInfo.UserGroup    = outputList["O_USER_GROUP"].ToString();
					try
					{
						UserInfo.UserGubun    = (UserType)(Int32.Parse(outputList["O_USER_GUBUN"].ToString()));
					}
					catch
					{
						UserInfo.UserGubun = UserType.Normal;
					}
					try
					{
						UserInfo.BuseoGubun   = (BuseoType)(Int32.Parse(outputList["O_BUSEO_GUBUN"].ToString()));
					}
					catch
					{
						UserInfo.BuseoGubun = BuseoType.Extra;
					}
						
					UserInfo.YaksokComID	=outputList["O_YAKSOK_COM_ID"].ToString();
					UserInfo.YaksokOpenID	=outputList["O_YAKSOK_OPEN_ID"].ToString();
					UserInfo.SlipComID		=outputList["O_SLIP_COM_ID"].ToString();
					UserInfo.SlipOpenID		=outputList["O_SLIP_OPEN_ID"].ToString();
					UserInfo.SangComID		=outputList["O_SANG_COM_ID"].ToString();
					UserInfo.SangOpenID		=outputList["O_SANG_OPEN_ID"].ToString();
					UserInfo.JindanComID	=outputList["O_JINDAN_COM_ID"].ToString();
					UserInfo.JindanOpenID	=outputList["O_JINDAN_OPEN_ID"].ToString();

					//2006.01.03 NurseTeam 추가
					UserInfo.NurseTeam		=outputList["O_NURSE_TEAM"].ToString();

					//2006.01.26 CPComID, CPOpenID 추가
					UserInfo.CPComID		=outputList["O_CP_COM_ID"].ToString();
					UserInfo.CPOpenID		=outputList["O_CP_OPEN_ID"].ToString();
					//2006.03.03 InputGubun  추가
					UserInfo.InputGubun		=outputList["O_INPUT_GUBUN"].ToString();
						

					// 병동부서인 경우 과코드,과명은 ""이 되고, 병동코드,병동명 SET
					// 대신 HoDong이 셋팅된다.
					if (UserInfo.BuseoGubun == BuseoType.Inp)
					{
						UserInfo.HoDong		= UserInfo.Gwa;
						UserInfo.HoDongName = UserInfo.GwaName;
						UserInfo.Gwa        = "";
						UserInfo.GwaName    = "";
					}

                    //2010.07.06 doctorID  추가
                    UserInfo.DoctorID       = outputList["O_DOCTOR_ID"].ToString();
					
				}
				else  //실패
				{
					//Service ErrCode -1.Oracle 이외의 에러, 그외는 Oracle 에러
					errMsg = Service.ErrMsg;
					return false;
				}*/
            }
            catch (Exception xe)
            {
                errMsg = XMsg.GetMsg("M044", xe); // 사용자정보 생성에러[" + xe.Message + "]"
                return false;
            }
            return true;
        }

        private static bool CheckUserSub(string userID, string pswd, bool checkPswd, CheckUserLoginResult result, out string errMsg)
        {
            errMsg = "";
            if (userID.Trim() == "")
            {
                errMsg = XMsg.GetMsg("M005"); // 사용자ID가 입력되지 않았습니다.
                return false;
            }
            //2005.11.23 비밀번호 Check 여부 추가
            if (checkPswd && pswd.Trim() == "")
            {
                errMsg = XMsg.GetMsg("M006"); // 비밀번호가 입력되지 않았습니다.
                return false;
            }

            /*<미확정> Input, Output은 협의후 확정 호출 PROC = PR_ADM_CHECK_LOGIN
            *Input = 시스템ID + UserID + Pswd + 비밀번호 Check여부(Y/N) + IP Addr
            *Output = 현재 총 21개
            */

            try
            {
                if (result != null)
                {
                    if (String.IsNullOrEmpty(result.ErrorMessage))
                    {
                        UserItemInfo user = result.UserItemInfo;
                        // https://sofiamedix.atlassian.net/browse/MED-14853
                        //UserInfo.UserID = userID.Trim();
                        UserInfo.UserPswd = pswd.Trim();
                        // https://sofiamedix.atlassian.net/browse/MED-14853
                        //UserInfo.UserName = user.UserNm;
                        UserInfo.BuseoCode = user.UserDept;
                        UserInfo.BuseoName = user.DeptNm;
                        UserInfo.Gwa = user.GwaCode;
                        UserInfo.GwaName = user.GwaName;
                        // TODO 2015.06.18 AnhNV added
                        UserInfo.HospCode = user.HospCode;
                        UserInfo.HospName = user.HospName;

                        try
                        {
                            UserInfo.UserLevel = Int32.Parse(user.UserLevel);
                        }
                        catch
                        {
                            UserInfo.UserLevel = 0;
                        }
                        UserInfo.UserGroup = user.UserGroup;
                        try
                        {
                            UserInfo.UserGubun = (UserType)(Int32.Parse(user.UserGubun));
                        }
                        catch
                        {
                            UserInfo.UserGubun = UserType.Normal;
                        }
                        try
                        {
                            UserInfo.BuseoGubun = (BuseoType)(Int32.Parse(user.BuseoGubun));
                        }
                        catch
                        {
                            UserInfo.BuseoGubun = BuseoType.Extra;
                        }

                        UserInfo.YaksokComID = user.YaksokComId;
                        UserInfo.YaksokOpenID = user.YaksokOpenId;
                        UserInfo.SlipComID = user.SlipComId;
                        UserInfo.SlipOpenID = user.SlipOpenId;
                        UserInfo.SangComID = user.SangComId;
                        UserInfo.SangOpenID = user.SangOpenId;
                        UserInfo.JindanComID = user.JindanComId;
                        UserInfo.JindanOpenID = user.JindanOpenId;

                        //2006.01.03 NurseTeam 추가
                        UserInfo.NurseTeam = user.NurseTeam;

                        //2006.01.26 CPComID, CPOpenID 추가
                        UserInfo.CPComID = user.CpComId;
                        UserInfo.CPOpenID = user.CpOpenId;
                        //2006.03.03 InputGubun  추가
                        UserInfo.InputGubun = user.InputGubun;


                        // 병동부서인 경우 과코드,과명은 ""이 되고, 병동코드,병동명 SET
                        // 대신 HoDong이 셋팅된다.
                        if (UserInfo.BuseoGubun == BuseoType.Inp)
                        {
                            UserInfo.HoDong = UserInfo.Gwa;
                            UserInfo.HoDongName = UserInfo.GwaName;
                            UserInfo.Gwa = "";
                            UserInfo.GwaName = "";
                        }

                        //2010.07.06 doctorID  추가
                        UserInfo.DoctorID = user.DoctorId;
                    }
                    else
                    {
                        errMsg = result.ErrorMessage;
                        return false;
                    }
                }
                else  //실패
                {
                    //Service ErrCode -1.Oracle 이외의 에러, 그외는 Oracle 에러
                    errMsg = Resources.MSG_001;
                    return false;
                }
            }
            catch (Exception xe)
            {
                errMsg = XMsg.GetMsg("M044", xe); // 사용자정보 생성에러[" + xe.Message + "]"
                return false;
            }
            return true;
        }

        //사용자 ID Check ( (ExecuteProcedure ArrayList 사용)
        private static bool CheckUserSub1(string systemID, string userID, string pswd, bool checkPswd, out string errMsg)
        {
            errMsg = "";
            if (userID.Trim() == "")
            {
                errMsg = XMsg.GetMsg("M005"); // 사용자ID가 입력되지 않았습니다.
                return false;
            }
            //2005.11.23 비밀번호 Check 여부 추가
            if (checkPswd && pswd.Trim() == "")
            {
                errMsg = XMsg.GetMsg("M006"); // 비밀번호가 입력되지 않았습니다.
                return false;
            }

            /*<미확정> Input, Output은 협의후 확정 호출 PROC = PR_ADM_CHECK_LOGIN
            *Input = 시스템ID + UserID + Pswd + 비밀번호 Check여부(Y/N) + IP Addr
            *Output = 현재 총 21개
            */

            try
            {
                string spName = "PR_ADM_CHECK_LOGIN";
                //INPUT SET = SYS_ID + USER_ID + PSWD + 비밀번호 Check 여부(Y/N) + IP
                ArrayList inputList = new ArrayList();
                inputList.Add(systemID.Trim());
                inputList.Add(userID.Trim());
                inputList.Add(pswd);
                inputList.Add((checkPswd ? "Y" : "N"));
                inputList.Add(Service.ClientIP);

                ArrayList outputList = new ArrayList();
                if (Service.ExecuteProcedure(spName, inputList, outputList))  //성공
                {
                    UserInfo.UserID = userID.Trim();
                    UserInfo.UserPswd = pswd.Trim();
                    UserInfo.UserName = outputList[0].ToString();
                    UserInfo.BuseoCode = outputList[1].ToString();
                    UserInfo.BuseoName = outputList[2].ToString();
                    UserInfo.Gwa = outputList[3].ToString();
                    UserInfo.GwaName = outputList[4].ToString();
                    try
                    {
                        UserInfo.UserLevel = Int32.Parse(outputList[5].ToString());
                    }
                    catch
                    {
                        UserInfo.UserLevel = 0;
                    }
                    UserInfo.UserGroup = outputList[6].ToString();
                    try
                    {
                        UserInfo.UserGubun = (UserType)(Int32.Parse(outputList[7].ToString()));
                    }
                    catch
                    {
                        UserInfo.UserGubun = UserType.Normal;
                    }
                    try
                    {
                        UserInfo.BuseoGubun = (BuseoType)(Int32.Parse(outputList[8].ToString()));
                    }
                    catch
                    {
                        UserInfo.BuseoGubun = BuseoType.Extra;
                    }

                    UserInfo.YaksokComID = outputList[9].ToString();
                    UserInfo.YaksokOpenID = outputList[10].ToString();
                    UserInfo.SlipComID = outputList[11].ToString();
                    UserInfo.SlipOpenID = outputList[12].ToString();
                    UserInfo.SangComID = outputList[13].ToString();
                    UserInfo.SangOpenID = outputList[14].ToString();
                    UserInfo.JindanComID = outputList[15].ToString();
                    UserInfo.JindanOpenID = outputList[16].ToString();

                    //2006.01.03 NurseTeam 추가
                    UserInfo.NurseTeam = outputList[17].ToString();

                    //2006.01.26 CPComID, CPOpenID 추가
                    UserInfo.CPComID = outputList[18].ToString();
                    UserInfo.CPOpenID = outputList[19].ToString();
                    //2006.03.03 InputGubun  추가
                    UserInfo.InputGubun = outputList[20].ToString();


                    // 병동부서인 경우 과코드,과명은 ""이 되고, 병동코드,병동명 SET
                    // 대신 HoDong이 셋팅된다.
                    if (UserInfo.BuseoGubun == BuseoType.Inp)
                    {
                        UserInfo.HoDong = UserInfo.Gwa;
                        UserInfo.HoDongName = UserInfo.GwaName;
                        UserInfo.Gwa = "";
                        UserInfo.GwaName = "";
                    }

                    //2010.07.06 doctorID  추가
                    UserInfo.DoctorID = outputList[21].ToString();

                }
                else  //실패
                {
                    //Service ErrCode -1.Oracle 이외의 에러, 그외는 Oracle 에러
                    errMsg = Service.ErrMsg;
                    return false;
                }
            }
            catch (Exception xe)
            {
                errMsg = XMsg.GetMsg("M044", xe); // 사용자정보 생성에러[" + xe.Message + "]"
                return false;
            }
            return true;
        }

        /// <summary>
        /// 시스템 사용자 진입현황(ADM3400)을 등록합니다.
        /// </summary>
        /// <param name="systemID"></param>
        public static void RegisterSystemUser(string systemID, string userID)
        {
            try
            {
                /*BindVarCollection bindVars = new BindVarCollection();
                bindVars.Add("f_user_id", userID);
                bindVars.Add("f_system_id", systemID);
                bindVars.Add("f_ip_addr", Service.ClientIP);
                //INPUT = 사용자ID, ADM3400(사용자 진입현황) 에 INSERT 나 UPDATE
                string cmdText =  "BEGIN " 
                                + "  UPDATE ADM3400 A"
                                + "     SET A.ENTR_TIME = SYSDATE "
                                + "   WHERE A.HOSP_CODE  = '" + EnvironInfo.HospCode + "'"
                                + "     AND A.USER_ID = :f_user_id"
                                + "     AND A.SYS_ID  = :f_system_id"
                                + "     AND A.HOSP_CODE  = '" + EnvironInfo.HospCode + "'"
                                + "     AND A.IP_ADDR = :f_ip_addr; "
                                +	"  IF SQL%NOTFOUND THEN "
                                + "    INSERT INTO ADM3400(SYS_ID, USER_ID, IP_ADDR, ENTR_TIME, HOSP_CODE) " 
                                + "    VALUES(:f_system_id, :f_user_id, :f_ip_addr, SYSDATE, '" + EnvironInfo.HospCode + "'); "
                                + "  END IF; "
                                + "END;";
                // Service Call
                Service.ExecuteNonQuery(cmdText, bindVars);*/

                // Cloud service
                UserInfoSetSystemUserToRegistryArgs args = new UserInfoSetSystemUserToRegistryArgs();
                args.UserId = userID;
                args.SystemId = systemID;
                args.IpAddr = Service.ClientIP;
                CloudService.Instance.Submit<UpdateResult, UserInfoSetSystemUserToRegistryArgs>(args);
            }
            catch { }
        }
        /// <summary>
        /// 시스템 사용자 진입현황(ADM3400)을 등록해제합니다.
        /// </summary>
        /// <param name="systemID"></param>
        public static void UnRegisterSystemUser(string systemID, string userID)
        {
            try
            {
                //ADM3400(사용자 진입현황)에서 삭제 , 없어도 에러 발생시키지 않음
                /*BindVarCollection bindVars = new BindVarCollection();
                bindVars.Add("f_user_id", userID);
                bindVars.Add("f_system_id", systemID);
                bindVars.Add("f_ip_addr", Service.ClientIP);
                string cmdText =  "BEGIN" 
                                + "  DELETE ADM3400 A"
                                + "   WHERE A.HOSP_CODE  = '" + EnvironInfo.HospCode + "'"
                                + "     AND A.USER_ID = :f_user_id"
                                + "     AND A.SYS_ID = :f_system_id"
                                + "     AND A.HOSP_CODE = '" + EnvironInfo.HospCode + "'"
                                + "     AND A.IP_ADDR = :f_ip_addr; "
                                + "  IF SQL%NOTFOUND THEN "
                                + "     RETURN;"
                                + "  END IF; "
                                + "END;";
                // Service Call
                Service.ExecuteNonQuery(cmdText,bindVars);*/

                // Cloud service
                FormUserInfoUnRegisterSystemUserArgs args = new FormUserInfoUnRegisterSystemUserArgs();
                args.UserId = userID;
                args.SystemId = systemID;
                CloudService.Instance.Submit<UpdateResult, FormUserInfoUnRegisterSystemUserArgs>(args);

            }
            catch { }
        }
        /// <summary>
        /// 사용자를 변경한후 사용자진입현황을 변경합니다.
        /// </summary>
        /// <param name="bfUserID"></param>
        /// <param name="afUserID"></param>
        public static void ChangeSystemUser(string systemID, string bfUserID, string afUserID)
        {
            //try
            //{
            //    BindVarCollection bindVars = new BindVarCollection();
            //    bindVars.Add("f_bf_user_id", bfUserID);
            //    bindVars.Add("f_af_user_id", afUserID);
            //    bindVars.Add("f_system_id", systemID);
            //    bindVars.Add("f_ip_addr", Service.ClientIP);
            //    //INPUT = 사용자ID, ADM3400(사용자 진입현황) 에 INSERT 나 UPDATE
            //    string cmdText = "BEGIN "
            //                    + "UPDATE ADM3400 A"
            //                    + "   SET A.ENTR_TIME = SYSDATE "
            //                    + "     , A.USER_ID   = :f_af_user_id"
            //                    + " WHERE A.HOSP_CODE  = '" + EnvironInfo.HospCode + "'"
            //                    + "   AND A.USER_ID = :f_bf_user_id"
            //                    + "   AND A.SYS_ID  = :f_system_id"
            //                    + "   AND A.IP_ADDR = :f_ip_addr; "
            //                    + "  IF SQL%NOTFOUND THEN "
            //                    + "    INSERT INTO ADM3400(SYS_ID, USER_ID, IP_ADDR, ENTR_TIME, HOSP_CODE) "
            //                    + "    VALUES(:f_system_id, :f_af_user_id, :f_ip_addr, SYSDATE, '" + EnvironInfo.HospCode + "'); "
            //                    + "  END IF; "
            //                    + "END;";
            //    // Service Call
            //    Service.ExecuteNonQuery(cmdText, bindVars);
            //}
            //catch { }

            // updated by Cloud team
            try
            {
                ChangeSystemUserArgs args = new ChangeSystemUserArgs();
                args.AfUserId = afUserID;
                args.BfUserId = bfUserID;
                args.IpAddr = Service.ClientIP;
                args.SystemId = systemID;
                CloudService.Instance.Submit<UpdateResult, ChangeSystemUserArgs>(args);
            }
            catch { }
        }

        public static void SetSystemUserToRegistry(string sysID, string userID, bool isRegister)
        {
            string key = Constants.CacheKeyCbo.CACHE_COMMON_USER_PREFIX + sysID + ".ID";
            /*RegistryKey rkey = Registry.LocalMachine;
            RegistryKey rkey2 = rkey.OpenSubKey(@"SOFTWARE\IHIS\USER\" + sysID, true);*/
            if (isRegister)  //등록이면 ID SET
            {
                /*if (rkey2 == null)
                    rkey2 = rkey.CreateSubKey(@"SOFTWARE\IHIS\USER\" + sysID);

                if (rkey2 != null)
                {
                    rkey2.SetValue("ID", userID);
                    rkey2.Close();
                }*/
                CacheService.Instance.Set(key, userID, TimeSpan.MaxValue);
            }
            else //UnRegister시는 DeleteValue
            {
                /*if (rkey2 != null)
                {
                    if (rkey2.GetValue("ID") != null)
                    {
                        rkey2.DeleteValue("ID");
                        rkey2.Close();
                    }
                }*/
                if (CacheService.Instance.IsSet(key))
                {
                    CacheService.Instance.Remove(key);
                }
            }
            /*rkey.Close();*/
        }

        public static bool ChangePassword(string userID, string oldPswd, string newPswd, string pwdHis, int attemptTimes, out string errMsg)
        {
            errMsg = "";
            if (userID.Trim() == "")
            {
                errMsg = XMsg.GetMsg("M005"); // 사용자ID가 입력되지 않았습니다.
                return false;
            }
            if (oldPswd.Trim() == "")
            {
                errMsg = XMsg.GetMsg("M001"); // 이전비밀번호가 입력되지 않았습니다.
                return false;
            }
            if (newPswd.Trim() == "")
            {
                errMsg = XMsg.GetMsg("M002"); // 신규비밀번호가 입력되지 않았습니다.
                return false;
            }

            #region deleted by Cloud
            // 사용자정보(ADM3200)에서 비밀번호 확인하여 처리함.
            //BindVarCollection bindVars = new BindVarCollection();
            //bindVars.Add("f_user_id", userID);
            //bindVars.Add("f_old_pswd", oldPswd);
            //bindVars.Add("f_new_pswd", newPswd);
            //string cmdText
            //  =   "DECLARE "
            //    + "T_EXIST BOOLEAN := FALSE; "
            //    + "BEGIN "
            //    + "FOR C1 IN (SELECT A.USER_END_YMD USER_END_YMD "
            //    + "               ,A.USER_SCRT PSWD "
            //    + "           FROM ADM3200 A "
            //    + "          WHERE A.HOSP_CODE  = '" + EnvironInfo.HospCode + "'"
            //    + "            AND A.USER_ID = :f_user_id ) LOOP "  //사용자정보
            //    + " IF C1.USER_END_YMD <= SYSDATE THEN "
            //    + "    RAISE_APPLICATION_ERROR(-20001, FN_ADM_MSG(1)); "  // 사용권한이 없습니다.
            //    + " END IF; "
            //    + " IF TRIM(C1.PSWD) != TRIM(:f_old_pswd) THEN "
            //    + "    RAISE_APPLICATION_ERROR(-20002, FN_ADM_MSG(2)); "  // 비밀번호를 잘못 입력하셨습니다.
            //    + " END IF; "
            //    + " T_EXIST := TRUE; "
            //    + "END LOOP; "
            //    + "IF T_EXIST = FALSE THEN "  //사용자 ID
            //    + "  RAISE_APPLICATION_ERROR(-20003, FN_ADM_MSG(3)); "  // 사용자ID를 잘못 입력하셨습니다.
            //    + "END IF; "
            //    + "UPDATE ADM3200 A" // 비밀번호 변경
            //    + " SET   A.USER_SCRT = :f_new_pswd"
            //    + " WHERE A.HOSP_CODE  = '" + EnvironInfo.HospCode + "'"
            //    + "   AND A.USER_ID = :f_user_id; "
            //    + "END; ";

            //if (!Service.ExecuteNonQuery(cmdText, bindVars))  //실패
            //{
            //    errMsg = Service.ErrMsg;
            //    return false;
            //}
            #endregion
            //check change pass


            // updated by Cloud
            FwUserInfoChangePswArgs args = new FwUserInfoChangePswArgs();
            args.HospCode = ""; // Get from server
            args.UserId = userID;
            args.OldPassword = Utility.CreateMd5Hash(oldPswd, false);
            args.NewPassword = Utility.CreateMd5Hash(newPswd, false);
            args.Attempt = attemptTimes;
            //args.Attempt = 6;
            args.PwdHistory = pwdHis;
            UpdateResult res = CloudService.Instance.Submit<UpdateResult, FwUserInfoChangePswArgs>(args);

            if (res.ExecutionStatus != ExecutionStatus.Success || res.Result == false)
            {
                return false;
            }

            if (!TypeCheck.IsNull(res.Msg))
            {
                errMsg = res.Msg;
                return false;
            }

            errMsg = Resources.MSG_002;

            return true;
        }

        /// <summary>
        /// GWA_LIST 2010.07.07 kimminsoo
        /// 의사의 진료과 정보를 보여주기 위해 추가
        /// </summary>
        public static bool GetDocotorGwaList(string userID, ArrayList gwaInfoList, out string errMsg)
        {
            errMsg = "";
            if (userID == "")
            {
                errMsg = XMsg.GetMsg("M005");
                return false;
            }

            //INPUT = USER_ID
            //OUTPUT = 의사ID + 진료과CODE + 진료과명 LIST
            MultiLayout layMIO = new MultiLayout();
            layMIO.LayoutItems.Add("doctor_id", DataType.String);
            layMIO.LayoutItems.Add("gwa_code", DataType.String);
            layMIO.LayoutItems.Add("gwa_name", DataType.String);
            layMIO.InitializeLayoutTable();

            //INPUT, OUTPUT SET
            //layMIO.QuerySQL = "SELECT A.DOCTOR"
            //                + "     , A.DOCTOR_GWA"
            //                + "     , B.GWA_NAME"
            //                + "  FROM BAS0260 B"
            //                + "     , BAS0270 A"
            //                + " WHERE A.HOSP_CODE = '" + EnvironInfo.HospCode + "'"
            //                + "   AND A.SABUN = '" + userID + "'"
            //                + "   AND SYSDATE BETWEEN A.START_DATE AND A.END_DATE"
            //                + "   AND B.HOSP_CODE = A.HOSP_CODE"
            //                + "   AND B.GWA   = A.DOCTOR_GWA"
            //                + "   AND SYSDATE BETWEEN B.START_DATE AND B.END_DATE"
            //                + " ORDER BY A.MAIN_GWA_YN, A.HOSP_CODE, A.DOCTOR_GWA";

            layMIO.ExecuteQuery = GetGwaList;
            layMIO.ParamList = CreateGwaParamList();
            layMIO.SetBindVarValue("f_user_id", userID);
            if (!layMIO.QueryLayout(true)) //조회실패
            {
                errMsg = XMsg.GetMsg("M078");
                return false;
            }
            if (layMIO.RowCount < 1) //진료과정보가 없는 사용자입니다.
            {
                errMsg = XMsg.GetMsg("M079");
                return false;
            }

            //의사 진료과 정보 구성
            for (int i = 0; i < layMIO.RowCount; i++)
            {
                DoctorGwaInfo info = new DoctorGwaInfo();
                info.DoctorID = layMIO.GetItemString(i, "doctor_id");
                info.GwaCode = layMIO.GetItemString(i, "gwa_code");
                info.GwaName = layMIO.GetItemString(i, "gwa_name");
                //LIST ADD
                gwaInfoList.Add(info);
            }
            return true;
        }

        private static IList<object[]> GetGwaList(BindVarCollection list)
        {
            // set arguments
            FormGwaListArgs gwaListArgs = new FormGwaListArgs();
            gwaListArgs.UserId = list["f_user_id"].VarValue;
            // get results
            FormGwaListResult result =
                CloudService.Instance.Submit<FormGwaListResult, FormGwaListArgs>(gwaListArgs);
            List<object[]> gwaList = new List<object[]>();
            IList<FormGwaItemInfo> gwaItems = result.ItemInfo;
            foreach (FormGwaItemInfo item in gwaItems)
            {
                gwaList.Add(new object[]
                {
                    item.Doctor,
                    item.DoctorGwa,
                    item.GwaName,
                });
            }
            return gwaList;
        }

        private static List<string> CreateGwaParamList()
        {
            List<string> paramList = new List<string>();
            paramList.Add("f_user_id");
            return paramList;
        }

        private static IList<object[]> GetBuseoList(BindVarCollection list)
        {
            List<object[]> result = new List<object[]>();
            if (buseoComboList != null)
            {
                foreach (ComboListItemInfo item in buseoComboList)
                {
                    result.Add(new object[]
                {
                    item.Code,
                    item.CodeName
                });
                }
            }

            return result;
        }
    }
}
