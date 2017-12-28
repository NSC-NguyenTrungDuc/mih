using System;
using IHIS.CloudConnector.Contracts.Models.Ocso;
using System.Collections.Generic;
using ProtoBuf;
using IHIS.CloudConnector.Contracts.Models.Ocs.Lib;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocso
{
    [Serializable]
    public class OCS1003Q09LoadComboDataSourceArgs : IContractArgs
    {
        protected bool Equals(OCS1003Q09LoadComboDataSourceArgs other)
        {
            return Equals(_forColPay, other._forColPay) && Equals(_forPortableYn, other._forPortableYn) && Equals(_forJusaSpdGubun, other._forJusaSpdGubun) && Equals(_forNalsu, other._forNalsu) && Equals(_forSuryang, other._forSuryang) && Equals(_forDv, other._forDv);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((OCS1003Q09LoadComboDataSourceArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_forColPay != null ? _forColPay.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_forPortableYn != null ? _forPortableYn.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_forJusaSpdGubun != null ? _forJusaSpdGubun.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_forNalsu != null ? _forNalsu.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_forSuryang != null ? _forSuryang.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_forDv != null ? _forDv.GetHashCode() : 0);
                return hashCode;
            }
        }

        private ComboDataSourceInfo _forColPay;
        private ComboDataSourceInfo _forPortableYn;
        private ComboDataSourceInfo _forJusaSpdGubun;
        private ComboDataSourceInfo _forNalsu;
        private ComboDataSourceInfo _forSuryang;
        private ComboDataSourceInfo _forDv;

        public ComboDataSourceInfo ForColPay
        {
            get { return this._forColPay; }
            set { this._forColPay = value; }
        }

        public ComboDataSourceInfo ForPortableYn
        {
            get { return this._forPortableYn; }
            set { this._forPortableYn = value; }
        }

        public ComboDataSourceInfo ForJusaSpdGubun
        {
            get { return this._forJusaSpdGubun; }
            set { this._forJusaSpdGubun = value; }
        }

        public ComboDataSourceInfo ForNalsu
        {
            get { return this._forNalsu; }
            set { this._forNalsu = value; }
        }

        public ComboDataSourceInfo ForSuryang
        {
            get { return this._forSuryang; }
            set { this._forSuryang = value; }
        }

        public ComboDataSourceInfo ForDv
        {
            get { return this._forDv; }
            set { this._forDv = value; }
        }

        public OCS1003Q09LoadComboDataSourceArgs() { }

        public OCS1003Q09LoadComboDataSourceArgs(ComboDataSourceInfo forColPay, ComboDataSourceInfo forPortableYn, ComboDataSourceInfo forJusaSpdGubun, ComboDataSourceInfo forNalsu, ComboDataSourceInfo forSuryang, ComboDataSourceInfo forDv)
        {
            this._forColPay = forColPay;
            this._forPortableYn = forPortableYn;
            this._forJusaSpdGubun = forJusaSpdGubun;
            this._forNalsu = forNalsu;
            this._forSuryang = forSuryang;
            this._forDv = forDv;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCS1003Q09LoadComboDataSourceRequest();
        }
    }
}