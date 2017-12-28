using System;
using IHIS.CloudConnector.Contracts.Models.Xrts;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Xrts
{[Serializable]
    public class XRT0001U00GrdXRTArgs : IContractArgs
    {
    protected bool Equals(XRT0001U00GrdXRTArgs other)
    {
        return string.Equals(_txtParam, other._txtParam) && string.Equals(_xrayGubun, other._xrayGubun) && string.Equals(_specialYn, other._specialYn);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((XRT0001U00GrdXRTArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_txtParam != null ? _txtParam.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_xrayGubun != null ? _xrayGubun.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_specialYn != null ? _specialYn.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _txtParam;
        private String _xrayGubun;
        private String _specialYn;

        public String TxtParam
        {
            get { return this._txtParam; }
            set { this._txtParam = value; }
        }

        public String XrayGubun
        {
            get { return this._xrayGubun; }
            set { this._xrayGubun = value; }
        }

        public String SpecialYn
        {
            get { return this._specialYn; }
            set { this._specialYn = value; }
        }

        public XRT0001U00GrdXRTArgs() { }

        public XRT0001U00GrdXRTArgs(String txtParam, String xrayGubun, String specialYn)
        {
            this._txtParam = txtParam;
            this._xrayGubun = xrayGubun;
            this._specialYn = specialYn;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.XRT0001U00GrdXRTRequest();
        }
    }
}