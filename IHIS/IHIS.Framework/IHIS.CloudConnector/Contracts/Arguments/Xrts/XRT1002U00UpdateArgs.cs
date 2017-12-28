using System;
using IHIS.CloudConnector.Contracts.Models.Xrts;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Xrts
{[Serializable]
    public class XRT1002U00UpdateArgs : IContractArgs
    {
    protected bool Equals(XRT1002U00UpdateArgs other)
    {
        return string.Equals(_fkocs, other._fkocs) && string.Equals(_updId, other._updId) && string.Equals(_inOutGubun, other._inOutGubun) && string.Equals(_hangmogCode, other._hangmogCode) && string.Equals(_bunho, other._bunho) && string.Equals(_gumsaMokjuk, other._gumsaMokjuk) && string.Equals(_xrayMethod, other._xrayMethod) && string.Equals(_pandokRequestYn, other._pandokRequestYn) && Equals(_grdPaItem, other._grdPaItem);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((XRT1002U00UpdateArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_fkocs != null ? _fkocs.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_updId != null ? _updId.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_inOutGubun != null ? _inOutGubun.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_hangmogCode != null ? _hangmogCode.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_bunho != null ? _bunho.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_gumsaMokjuk != null ? _gumsaMokjuk.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_xrayMethod != null ? _xrayMethod.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_pandokRequestYn != null ? _pandokRequestYn.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_grdPaItem != null ? _grdPaItem.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _fkocs;
        private String _updId;
        private String _inOutGubun;
        private String _hangmogCode;
        private String _bunho;
        private String _gumsaMokjuk;
        private String _xrayMethod;
        private String _pandokRequestYn;
        private List<XRT1002U00GrdPaStatusInfo> _grdPaItem = new List<XRT1002U00GrdPaStatusInfo>();

        public String Fkocs
        {
            get { return this._fkocs; }
            set { this._fkocs = value; }
        }

        public String UpdId
        {
            get { return this._updId; }
            set { this._updId = value; }
        }

        public String InOutGubun
        {
            get { return this._inOutGubun; }
            set { this._inOutGubun = value; }
        }

        public String HangmogCode
        {
            get { return this._hangmogCode; }
            set { this._hangmogCode = value; }
        }

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public String GumsaMokjuk
        {
            get { return this._gumsaMokjuk; }
            set { this._gumsaMokjuk = value; }
        }

        public String XrayMethod
        {
            get { return this._xrayMethod; }
            set { this._xrayMethod = value; }
        }

        public String PandokRequestYn
        {
            get { return this._pandokRequestYn; }
            set { this._pandokRequestYn = value; }
        }

        public List<XRT1002U00GrdPaStatusInfo> GrdPaItem
        {
            get { return this._grdPaItem; }
            set { this._grdPaItem = value; }
        }

        public XRT1002U00UpdateArgs() { }

        public XRT1002U00UpdateArgs(String fkocs, String updId, String inOutGubun, String hangmogCode, String bunho, String gumsaMokjuk, String xrayMethod, String pandokRequestYn, List<XRT1002U00GrdPaStatusInfo> grdPaItem)
        {
            this._fkocs = fkocs;
            this._updId = updId;
            this._inOutGubun = inOutGubun;
            this._hangmogCode = hangmogCode;
            this._bunho = bunho;
            this._gumsaMokjuk = gumsaMokjuk;
            this._xrayMethod = xrayMethod;
            this._pandokRequestYn = pandokRequestYn;
            this._grdPaItem = grdPaItem;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.XRT1002U00UpdateRequest();
        }
    }
}