using System;
using IHIS.CloudConnector.Contracts.Models.Cpls;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Cpls
{
    [Serializable]
    public class CPL3020U02SetDataIFS7203Args : IContractArgs
    {
        protected bool Equals(CPL3020U02SetDataIFS7203Args other)
        {
            return string.Equals(_recordGubun, other._recordGubun) && string.Equals(_sentaCode, other._sentaCode) && string.Equals(_iraiKey, other._iraiKey) && string.Equals(_karuteNo, other._karuteNo) && string.Equals(_kanjamei, other._kanjamei) && string.Equals(_koumokusuu, other._koumokusuu) && string.Equals(_houkokubi, other._houkokubi) && string.Equals(_yobi1, other._yobi1) && string.Equals(_yobi2, other._yobi2);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CPL3020U02SetDataIFS7203Args) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_recordGubun != null ? _recordGubun.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_sentaCode != null ? _sentaCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_iraiKey != null ? _iraiKey.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_karuteNo != null ? _karuteNo.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_kanjamei != null ? _kanjamei.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_koumokusuu != null ? _koumokusuu.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_houkokubi != null ? _houkokubi.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_yobi1 != null ? _yobi1.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_yobi2 != null ? _yobi2.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _recordGubun;
        private String _sentaCode;
        private String _iraiKey;
        private String _karuteNo;
        private String _kanjamei;
        private String _koumokusuu;
        private String _houkokubi;
        private String _yobi1;
        private String _yobi2;

        public String RecordGubun
        {
            get { return this._recordGubun; }
            set { this._recordGubun = value; }
        }

        public String SentaCode
        {
            get { return this._sentaCode; }
            set { this._sentaCode = value; }
        }

        public String IraiKey
        {
            get { return this._iraiKey; }
            set { this._iraiKey = value; }
        }

        public String KaruteNo
        {
            get { return this._karuteNo; }
            set { this._karuteNo = value; }
        }

        public String Kanjamei
        {
            get { return this._kanjamei; }
            set { this._kanjamei = value; }
        }

        public String Koumokusuu
        {
            get { return this._koumokusuu; }
            set { this._koumokusuu = value; }
        }

        public String Houkokubi
        {
            get { return this._houkokubi; }
            set { this._houkokubi = value; }
        }

        public String Yobi1
        {
            get { return this._yobi1; }
            set { this._yobi1 = value; }
        }

        public String Yobi2
        {
            get { return this._yobi2; }
            set { this._yobi2 = value; }
        }

        public CPL3020U02SetDataIFS7203Args() { }

        public CPL3020U02SetDataIFS7203Args(String recordGubun, String sentaCode, String iraiKey, String karuteNo, String kanjamei, String koumokusuu, String houkokubi, String yobi1, String yobi2)
        {
            this._recordGubun = recordGubun;
            this._sentaCode = sentaCode;
            this._iraiKey = iraiKey;
            this._karuteNo = karuteNo;
            this._kanjamei = kanjamei;
            this._koumokusuu = koumokusuu;
            this._houkokubi = houkokubi;
            this._yobi1 = yobi1;
            this._yobi2 = yobi2;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.CPL3020U02SetDataIFS7203Request();
        }
    }
}