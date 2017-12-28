using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocsa
{
    [Serializable]
    public class OCS0118U00GrdSaveLayoutInfo
    {
        private String _sysId;
        private String _convCls;
        private String _convGubun;
        private String _hangmogCode;
        private String _convHangmog;
        private String _startDate;
        private String _remark;
        private String _rowState;

        public String SysId
        {
            get { return this._sysId; }
            set { this._sysId = value; }
        }

        public String ConvCls
        {
            get { return this._convCls; }
            set { this._convCls = value; }
        }

        public String ConvGubun
        {
            get { return this._convGubun; }
            set { this._convGubun = value; }
        }

        public String HangmogCode
        {
            get { return this._hangmogCode; }
            set { this._hangmogCode = value; }
        }

        public String ConvHangmog
        {
            get { return this._convHangmog; }
            set { this._convHangmog = value; }
        }

        public String StartDate
        {
            get { return this._startDate; }
            set { this._startDate = value; }
        }

        public String Remark
        {
            get { return this._remark; }
            set { this._remark = value; }
        }

        public String RowState
        {
            get { return this._rowState; }
            set { this._rowState = value; }
        }

        public OCS0118U00GrdSaveLayoutInfo() { }

        public OCS0118U00GrdSaveLayoutInfo(String sysId, String convCls, String convGubun, String hangmogCode, String convHangmog, String startDate, String remark, String rowState)
        {
            this._sysId = sysId;
            this._convCls = convCls;
            this._convGubun = convGubun;
            this._hangmogCode = hangmogCode;
            this._convHangmog = convHangmog;
            this._startDate = startDate;
            this._remark = remark;
            this._rowState = rowState;
        }

    }
}