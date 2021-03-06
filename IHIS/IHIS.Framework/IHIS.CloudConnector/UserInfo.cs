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

// <<2017.07.20>> DLL_CROSS : DLL 의 교차참조 해결을 위함
//                Forms.UserInfo 를 DbControls로 옮김.
//                Forms 에서 Properties, Ressoures 를 DbControls 에 Copy 함
//                

namespace IHIS.Framework
{
    public enum AdminType
    {
        SuperAdmin,
        Admin,
        /* More types go here */
    }

    /// <summary>
    /// UserInfo(사용자정보 Class)에 대한 요약 설명입니다.
    /// </summary>
    public class UserInfo
    {
        /*<미확정> 협의후 확정필요 */
        private static string userID = "";       //사용자 ID
        private static string userName = "";      //사용자명
        private static string userPswd = "";		// 사용자 비밀번호
        private static string buseoCode = "";     // 사용자 부서코드
        private static string buseoName = "";     // 사용자 부서명
        private static string gwa = "";		// 사용자 과코드(진료과)
        private static string gwaName = "";	    // 사용자 과이름(진료과명)
        private static string hoDong = "";       // 사용자의 병동Code (부서구분이 병동일때)
        private static string hoDongName = "";    // 사용자의 병동명
        private static int userLevel = 0;		// 사용자 등급
        private static string userGroup = "";		// 사용자 GROUP
        private static BuseoType buseoGubun;     // 부서구분 (진료과, 병동, 진료지원부서, 행정부서, 인사급여부서)
        private static UserType userGubun;       // 사용자구분 (의사, 간호사, 기사, 부서)
        // 2005/05/18 신종석 필드 추가
        private static string yaksokComID = "";   // 약속처방 공통 ID   
        private static string yaksokOpenID = "";  // 약속처방 열람 ID
        private static string slipComID = "";     // 서식지   공통 ID
        private static string slipOpenID = "";    // 서식지   열람 ID
        private static string sangComID = "";     // 상병 공통 ID 
        private static string sangOpenID = "";    // 상병 열람 ID
        private static string jindanComID = "";   // 진단 공통 ID
        private static string jindanOpenID = "";  // 진단 열람 ID
        // 2006.01.03 간호팀 필드 추가
        private static string nurseTeam = "";		// 간호 Team
        //2006.01.26 CPComID, CPOpenID 추가
        private static string cpComID = "";
        private static string cpOpenID = "";
        //2006.03.03 InputGubun 추가 (과의 입력구분)
        private static string inputGubun = "";
        //2010.07.06 kim min soo
        private static string doctorID = "";      // doctorID (userID 와 doctorID 가 반드시 일치할 수 없다. userGubun 이 의사일 때만 셋팅)

        private static bool doctorDrugCheck;
        private static string changePwdFlg = "";
        private static string firstLoginFlg = "";
        private static string lastPwdChange = "";
        private static string pwdHistory = "";
        private static string currentTime = "";
        // 2015.12.04 AnhNV Medical Cloud
        private static string orcaIp = "";
        private static string orcaUser = "";
        private static string orcaPassword = "";
        // 2015.12.23 added by Cloud
        private static string orcaPort = "";
        private static string orcaHospCode = "";
        private static string orcaPortRcvClaim = "";
        // 2016.04.07 added by Cloud
        private static string usePHR = "";
        //MisaInfo
        private static string misaIp = "";
        private static string misaUser = "";
        private static string misaPwd = "";
        private static string misaDbInsurName = "";
        private static string misaInstanceName = "";
        private static string misaDbNonInsurName = "";
        // New master data
        private static List<string> newMstDataLst = new List<string>();
        // https://sofiamedix.atlassian.net/browse/MED-15742
        private static string cplSpecimenAuto = "";
        private static string cplDevBlood = "";
        private static string cplDevUrine = "";
        private static string cplDevBio = "";
        private static string cplServer = "";
        private static string cplPort = "";
        private static string cplDatabase = "";
        private static string cplUserId = "";
        private static string cplPassword = "";

        public static string CplSpecimenAuto
        {
            get { return cplSpecimenAuto; }
            set { cplSpecimenAuto = value; }
        }

        public static string CplDevBlood
        {
            get { return cplDevBlood; }
            set { cplDevBlood = value; }
        }

        public static string CplDevUrine
        {
            get { return cplDevUrine; }
            set { cplDevUrine = value; }
        }

        public static string CplDevBio
        {
            get { return cplDevBio; }
            set { cplDevBio = value; }
        }

        public static string CplServer
        {
            get { return cplServer; }
            set { cplServer = value; }
        }

        public static string CplPort
        {
            get { return cplPort; }
            set { cplPort = value; }
        }

        public static string CplDatabase
        {
            get { return cplDatabase; }
            set { cplDatabase = value; }
        }

        public static string CplUserId
        {
            get { return cplUserId; }
            set { cplUserId = value; }
        }

        public static string CplPassword
        {
            get { return cplPassword; }
            set { cplPassword = value; }
        }

        public static List<string> NewMstDataLst
        {
            get { return newMstDataLst; }
            set { newMstDataLst = value; }
        }

        public static string CurrentTime
        {
            get { return currentTime; }
            set { currentTime = value; }
        }
        public static string PwdHistory
        {
            get { return pwdHistory; }
            set { pwdHistory = value; }
        }
        public static string ChangePwdFlg
        {
            get { return changePwdFlg; }
            set { changePwdFlg = value; }
        }
        public static string FirstLoginFlg
        {
            get { return firstLoginFlg; }
            set { firstLoginFlg = value; }
        }
        public static string LastPwdChange
        {
            get { return lastPwdChange; }
            set { lastPwdChange = value; }
        }
        public static string OrcaIp
        {
            get { return orcaIp; }
            set { orcaIp = value; }
        }
        public static string OrcaUser
        {
            get { return orcaUser; }
            set { orcaUser = value; }
        }
        public static string OrcaPassword
        {
            get { return orcaPassword; }
            set { orcaPassword = value; }
        }
        public static string OrcaPort
        {
            get { return orcaPort; }
            set { orcaPort = value; }
        }
        public static string OrcaHospCode
        {
            get { return orcaHospCode; }
            set { orcaHospCode = value; }
        }
        public static string OrcaPortRcvClaim
        {
            get { return orcaPortRcvClaim; }
            set { orcaPortRcvClaim = value; }
        }
        public static string UsePHR
        {
            get { return usePHR; }
            set { usePHR = value; }
        }
        public static string MisaIp
        {
            get { return misaIp; }
            set { misaIp = value; }
        }
        public static string MisaUser
        {
            get { return misaUser; }
            set { misaUser = value; }
        }
        public static string MisaPwd
        {
            get { return misaPwd; }
            set { misaPwd = value; }
        }
        public static string MisaDbInsurName
        {
            get { return misaDbInsurName; }
            set { misaDbInsurName = value; }
        }
        public static string MisaInstanceName
        {
            get { return misaInstanceName; }
            set { misaInstanceName = value; }
        }
        public static string MisaDbNonInsurName
        {
            get { return misaDbNonInsurName; }
            set { misaDbNonInsurName = value; }
        }

        public static bool DoctorDrugCheck
        {
            get { return doctorDrugCheck; }
            set { doctorDrugCheck = value; }
        }
        private static bool checkKinki;
        public static bool CheckKinki
        {
            get { return checkKinki; }
            set { checkKinki = value; }
        }
        private static bool checkInteraction;
        public static bool CheckInteraction
        {
            get { return checkInteraction; }
            set { checkInteraction = value; }
        }
        private static bool checkDosage;
        public static bool CheckDosage
        {
            get { return checkDosage; }
            set { checkDosage = value; }
        }

        private static string versionDrugKinkiMessage;
        public static string VersionDrugKinkiMessage
        {
            get { return versionDrugKinkiMessage; }
            set { versionDrugKinkiMessage = value; }
        }
        private static string versionDrugKinkiDisease;
        public static string VersionDrugKinkiDisease
        {
            get { return versionDrugKinkiDisease; }
            set { versionDrugKinkiDisease = value; }
        }
        private static string versionDrugDosage;
        public static string VersionDrugDosage
        {
            get { return versionDrugDosage; }
            set { versionDrugDosage = value; }
        }
        private static string versionDrugDosageNormal;
        public static string VersionDrugDosageNormal
        {
            get { return versionDrugDosageNormal; }
            set { versionDrugDosageNormal = value; }
        }
        private static string versionDrugDosageStandard;
        public static string VersionDrugDosageStandard
        {
            get { return versionDrugDosageStandard; }
            set { versionDrugDosageStandard = value; }
        }
        private static string versionDrugDosageAddition;
        public static string VersionDrugDosageAddition
        {
            get { return versionDrugDosageAddition; }
            set { versionDrugDosageAddition = value; }
        }
        private static string versionDrugChecking;
        public static string VersionDrugChecking
        {
            get { return versionDrugChecking; }
            set { versionDrugChecking = value; }
        }
        private static string versionDrugInteraction;
        public static string VersionDrugInteraction
        {
            get { return versionDrugInteraction; }
            set { versionDrugInteraction = value; }
        }
        private static string versionDrugGenericName;
        public static string VersionDrugGenericName
        {
            get { return versionDrugGenericName; }
            set { versionDrugGenericName = value; }
        }


        // 2015.06.18 AnhNV Added START
        private static string hospCode = "";
        public static string HospCode
        {
            get { return hospCode; }
            set { hospCode = value; }
        }
        //MED-10202
        private static string orcaCloudYn = "";
        public static string OrcaCloudYn
        {
            get { return orcaCloudYn; }
            set { orcaCloudYn = value; }
        }

        // 2015.08.12 TungTX Added 
        private static string hospName = "";
        public static string HospName
        {
            get { return hospName; }
            set { hospName = value; }
        }

        // MED-10181
        private static bool vpnYn = false;
        /// <summary>
        /// Y: true
        /// N: false
        /// </summary>
        public static bool VpnYn
        {
            get { return vpnYn; }
            set { vpnYn = value; }
        }

        private static string _timeZone;
        public static string TimeZone
        {
            get { return _timeZone; }
            set { _timeZone = value; }
        }
        // https://sofiamedix.atlassian.net/browse/MED-10712
        private static string certExpired = "";
        /// <summary>
        /// Y: exprired
        /// N: avaiable
        /// </summary>
        public static string CertExpired
        {
            get { return certExpired; }
            set { certExpired = value; }
        }

        // MED-6861
        private static bool invUsage = false;
        /// <summary>
        /// Indicates whether the inventory module is using or not. TRUE if using, otherwise FALSE.
        /// </summary>
        public static bool InvUsage
        {
            get { return invUsage; }
            set { invUsage = value; }
        }

        public static AdminType AdminType
        {
            get
            {
                return hospCode == "NTA" && userGroup == "SAM" ? AdminType.SuperAdmin : AdminType.Admin;
            }
        }
        // 2015.06.18 AnhNV Added END

        public static string UserID
        {
            get { return userID; }
            set { userID = value; }
        }

        public static string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        public static string UserPswd
        {
            get { return userPswd; }
            set { userPswd = value; }
        }
        public static string BuseoCode
        {
            get { return buseoCode; }
            set { buseoCode = value; }
        }
        public static string BuseoName
        {
            get { return buseoName; }
            set { buseoName = value; }
        }
        public static string Gwa
        {
            get { return gwa; }
            set { gwa = value; }
        }
        public static string GwaName
        {
            get { return gwaName; }
            set { gwaName = value; }
        }
        public static string HoDong
        {
            get { return hoDong; }
            set { hoDong = value; }
        }
        public static string HoDongName
        {
            get { return hoDongName; }
            set { hoDongName = value; }
        }
        public static int UserLevel
        {
            get { return userLevel; }
            set { userLevel = value; }
        }
        public static string UserGroup
        {
            get { return userGroup; }
            set { userGroup = value; }
        }
        public static UserType UserGubun
        {
            get { return userGubun; }
            set { userGubun = value; }
        }
        public static BuseoType BuseoGubun
        {
            get { return buseoGubun; }
            set { buseoGubun = value; }
        }
        public static string YaksokComID
        {
            get { return yaksokComID; }
            set { yaksokComID = value; }
        }

        public static string YaksokOpenID
        {
            get { return yaksokOpenID; }
            set { yaksokOpenID = value; }
        }

        public static string SlipComID
        {
            get { return slipComID; }
            set { slipComID = value; }
        }

        public static string SlipOpenID
        {
            get { return slipOpenID; }
            set { slipOpenID = value; }
        }

        public static string SangComID
        {
            get { return sangComID; }
            set { sangComID = value; }
        }

        public static string SangOpenID
        {
            get { return sangOpenID; }
            set { sangOpenID = value; }
        }

        public static string JindanComID
        {
            get { return jindanComID; }
            set { jindanComID = value; }
        }

        public static string JindanOpenID
        {
            get { return jindanOpenID; }
            set { jindanOpenID = value; }
        }

        public static string NurseTeam
        {
            get { return nurseTeam; }
            set { nurseTeam = value; }
        }
        public static string CPComID
        {
            get { return cpComID; }
            set { cpComID = value; }
        }
        public static string CPOpenID
        {
            get { return cpOpenID; }
            set { cpOpenID = value; }
        }
        public static string InputGubun
        {
            get { return inputGubun; }
            set { inputGubun = value; }
        }
        public static string DoctorID
        {
            get { return doctorID; }
            set { doctorID = value; }
        }
    }
    //////////////////////////////////////////
    //////////////////////////////////////////
    //////////////////////////////////////////
    //////////////////////////////////////////
    /// <summary>
    /// 사용자 구분 (의사, 간호사, 일반)
    /// 2005.12.29 사용자구분은 1.의사, 2.간호사, 3.일반
    /// </summary>
    public enum UserType { Doctor = 1, Nurse = 2, Normal = 3 }

    /// <summary>
    /// 부서구분 (1.외래, 2.입원, 3.진료지원부서, 4.일반행정부서, 5.외래응급, 6.입원응급 9.인사급여부서)
    /// 2006.01.04 부서구분 변경 1.진료, 2.병동, 3.부문, 4.사무, 9.기타로 구분함 (5,6은 데이타가 없으므로 제외)
    /// </summary>
    public enum BuseoType { Out = 1, Inp = 2, Support = 3, General = 4, Extra = 9 }
    //public enum BuseoType {Out=1, Inp=2, SupportDiv=3, GeneralDiv=4, OutEmer=5, InpEmer=6, PersonalDiv=9}

    /// <summary>
    /// **GWA_LIST** 2010.07.07 의사과정보 class추가 (OCSI,OCSO Login시에 콤보로 구성해줄 과정보 class)
    public class DoctorGwaInfo
    {
        public string DoctorID = ""; //의사ID
        public string GwaCode = ""; //과코드
        public string GwaName = ""; //과명
    }
 }
