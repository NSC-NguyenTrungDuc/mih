using System;

namespace IHIS.CloudConnector.Contracts.Models.System
{
    [Serializable]
    public class MainFormGetMainMenuItemInfo
    {
        private String _grpId;
        private String _grpNm;
        private String _sysId;
        private String _sysNm;
        private String _dispGrpId;
        private String _dispGrpNm;
        private String _sysDesc;

        public String GrpId
        {
            get { return this._grpId; }
            set { this._grpId = value; }
        }

        public String GrpNm
        {
            get { return this._grpNm; }
            set { this._grpNm = value; }
        }

        public String SysId
        {
            get { return this._sysId; }
            set { this._sysId = value; }
        }

        public String SysNm
        {
            get { return this._sysNm; }
            set { this._sysNm = value; }
        }

        public String DispGrpId
        {
            get { return this._dispGrpId; }
            set { this._dispGrpId = value; }
        }

        public String DispGrpNm
        {
            get { return this._dispGrpNm; }
            set { this._dispGrpNm = value; }
        }

        public String SysDesc
        {
            get { return this._sysDesc; }
            set { this._sysDesc = value; }
        }

        public MainFormGetMainMenuItemInfo() { }

        public MainFormGetMainMenuItemInfo(String grpId, String grpNm, String sysId, String sysNm, String dispGrpId, String dispGrpNm, String sysDesc)
        {
            this._grpId = grpId;
            this._grpNm = grpNm;
            this._sysId = sysId;
            this._sysNm = sysNm;
            this._dispGrpId = dispGrpId;
            this._dispGrpNm = dispGrpNm;
            this._sysDesc = sysDesc;
        }

    }
}