using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocsa
{
    [Serializable]
    public class OCS0118U00GrdOCS0118Info
    {
        private String _convCls;
        private String _convGubun;
        private String _hangmogCode;
        private String _hangmogName;
        private String _convHangmog;
        private String _convHangmogName;
        private String _remark;
        private String _startDate;

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

        public String HangmogName
        {
            get { return this._hangmogName; }
            set { this._hangmogName = value; }
        }

        public String ConvHangmog
        {
            get { return this._convHangmog; }
            set { this._convHangmog = value; }
        }

        public String ConvHangmogName
        {
            get { return this._convHangmogName; }
            set { this._convHangmogName = value; }
        }

        public String Remark
        {
            get { return this._remark; }
            set { this._remark = value; }
        }

        public String StartDate
        {
            get { return this._startDate; }
            set { this._startDate = value; }
        }

        public OCS0118U00GrdOCS0118Info() { }

        public OCS0118U00GrdOCS0118Info(String convCls, String convGubun, String hangmogCode, String hangmogName, String convHangmog, String convHangmogName, String remark, String startDate)
        {
            this._convCls = convCls;
            this._convGubun = convGubun;
            this._hangmogCode = hangmogCode;
            this._hangmogName = hangmogName;
            this._convHangmog = convHangmog;
            this._convHangmogName = convHangmogName;
            this._remark = remark;
            this._startDate = startDate;
        }

    }
}