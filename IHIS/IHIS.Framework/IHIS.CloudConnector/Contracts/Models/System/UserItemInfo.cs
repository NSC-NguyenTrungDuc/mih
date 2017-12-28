using System;

namespace IHIS.CloudConnector.Contracts.Models.System
{
    [Serializable]
    public class UserItemInfo
    {
        private String _userNm;
        private String _userDept;
        private String _deptNm;
        private String _gwaCode;
        private String _gwaName;
        private String _userLevel;
        private String _userGroup;
        private String _userGubun;
        private String _buseoGubun;
        private String _yaksokComId;
        private String _yaksokOpenId;
        private String _slipComId;
        private String _slipOpenId;
        private String _sangComId;
        private String _sangOpenId;
        private String _jindanComId;
        private String _jindanOpenId;
        private String _nurseTeam;
        private String _cpComId;
        private String _cpOpenId;
        private String _inputGubun;
        private String _doctorId;
        private String _hospCode;
        private String _hospName;

        public String UserNm
        {
            get { return this._userNm; }
            set { this._userNm = value; }
        }

        public String UserDept
        {
            get { return this._userDept; }
            set { this._userDept = value; }
        }

        public String DeptNm
        {
            get { return this._deptNm; }
            set { this._deptNm = value; }
        }

        public String GwaCode
        {
            get { return this._gwaCode; }
            set { this._gwaCode = value; }
        }

        public String GwaName
        {
            get { return this._gwaName; }
            set { this._gwaName = value; }
        }

        public String UserLevel
        {
            get { return this._userLevel; }
            set { this._userLevel = value; }
        }

        public String UserGroup
        {
            get { return this._userGroup; }
            set { this._userGroup = value; }
        }

        public String UserGubun
        {
            get { return this._userGubun; }
            set { this._userGubun = value; }
        }

        public String BuseoGubun
        {
            get { return this._buseoGubun; }
            set { this._buseoGubun = value; }
        }

        public String YaksokComId
        {
            get { return this._yaksokComId; }
            set { this._yaksokComId = value; }
        }

        public String YaksokOpenId
        {
            get { return this._yaksokOpenId; }
            set { this._yaksokOpenId = value; }
        }

        public String SlipComId
        {
            get { return this._slipComId; }
            set { this._slipComId = value; }
        }

        public String SlipOpenId
        {
            get { return this._slipOpenId; }
            set { this._slipOpenId = value; }
        }

        public String SangComId
        {
            get { return this._sangComId; }
            set { this._sangComId = value; }
        }

        public String SangOpenId
        {
            get { return this._sangOpenId; }
            set { this._sangOpenId = value; }
        }

        public String JindanComId
        {
            get { return this._jindanComId; }
            set { this._jindanComId = value; }
        }

        public String JindanOpenId
        {
            get { return this._jindanOpenId; }
            set { this._jindanOpenId = value; }
        }

        public String NurseTeam
        {
            get { return this._nurseTeam; }
            set { this._nurseTeam = value; }
        }

        public String CpComId
        {
            get { return this._cpComId; }
            set { this._cpComId = value; }
        }

        public String CpOpenId
        {
            get { return this._cpOpenId; }
            set { this._cpOpenId = value; }
        }

        public String InputGubun
        {
            get { return this._inputGubun; }
            set { this._inputGubun = value; }
        }

        public String DoctorId
        {
            get { return this._doctorId; }
            set { this._doctorId = value; }
        }

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public String HospName
        {
            get { return this._hospName; }
            set { this._hospName = value; }
        }

        public UserItemInfo() { }

        public UserItemInfo(String userNm, String userDept, String deptNm, String gwaCode, String gwaName, String userLevel, String userGroup, String userGubun, String buseoGubun, String yaksokComId, String yaksokOpenId, String slipComId, String slipOpenId, String sangComId, String sangOpenId, String jindanComId, String jindanOpenId, String nurseTeam, String cpComId, String cpOpenId, String inputGubun, String doctorId, String hospCode, String hospName)
        {
            this._userNm = userNm;
            this._userDept = userDept;
            this._deptNm = deptNm;
            this._gwaCode = gwaCode;
            this._gwaName = gwaName;
            this._userLevel = userLevel;
            this._userGroup = userGroup;
            this._userGubun = userGubun;
            this._buseoGubun = buseoGubun;
            this._yaksokComId = yaksokComId;
            this._yaksokOpenId = yaksokOpenId;
            this._slipComId = slipComId;
            this._slipOpenId = slipOpenId;
            this._sangComId = sangComId;
            this._sangOpenId = sangOpenId;
            this._jindanComId = jindanComId;
            this._jindanOpenId = jindanOpenId;
            this._nurseTeam = nurseTeam;
            this._cpComId = cpComId;
            this._cpOpenId = cpOpenId;
            this._inputGubun = inputGubun;
            this._doctorId = doctorId;
            this._hospCode = hospCode;
            this._hospName = hospName;
        }

    }
}