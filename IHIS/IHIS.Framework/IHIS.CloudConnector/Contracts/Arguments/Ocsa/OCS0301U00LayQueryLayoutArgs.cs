using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
    public class OCS0301U00LayQueryLayoutArgs : IContractArgs
    {
    protected bool Equals(OCS0301U00LayQueryLayoutArgs other)
    {
        return string.Equals(_memb, other._memb) && string.Equals(_fkocs0300Seq, other._fkocs0300Seq) && string.Equals(_yaksokCode, other._yaksokCode) && string.Equals(_hospCode, other._hospCode);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0301U00LayQueryLayoutArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_memb != null ? _memb.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_fkocs0300Seq != null ? _fkocs0300Seq.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_yaksokCode != null ? _yaksokCode.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_hospCode != null ? _hospCode.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _memb;
        private String _fkocs0300Seq;
        private String _yaksokCode;
        private String _hospCode;

        public String Memb
        {
            get { return this._memb; }
            set { this._memb = value; }
        }

        public String Fkocs0300Seq
        {
            get { return this._fkocs0300Seq; }
            set { this._fkocs0300Seq = value; }
        }

        public String YaksokCode
        {
            get { return this._yaksokCode; }
            set { this._yaksokCode = value; }
        }

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public OCS0301U00LayQueryLayoutArgs() { }

        public OCS0301U00LayQueryLayoutArgs(String memb, String fkocs0300Seq, String yaksokCode, String hospCode)
        {
            this._memb = memb;
            this._fkocs0300Seq = fkocs0300Seq;
            this._yaksokCode = yaksokCode;
            this._hospCode = hospCode;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCS0301U00LayQueryLayoutRequest();
        }
    }
}