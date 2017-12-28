using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
    public class OUT0101U02ComboListArgs : IContractArgs
    {
        protected bool Equals(OUT0101U02ComboListArgs other)
        {
            return string.Equals(_sexCodeType, other._sexCodeType) && string.Equals(_bunhoCodeType, other._bunhoCodeType) && string.Equals(_telCodeType, other._telCodeType) && string.Equals(_boninCodeType, other._boninCodeType);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((OUT0101U02ComboListArgs)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_sexCodeType != null ? _sexCodeType.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (_bunhoCodeType != null ? _bunhoCodeType.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (_telCodeType != null ? _telCodeType.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (_boninCodeType != null ? _boninCodeType.GetHashCode() : 0);
                return hashCode;
            }
        }
        private String _sexCodeType;
        private sealed class Out0101U02ComboListArgsEqualityComparer : IEqualityComparer<OUT0101U02ComboListArgs>
        {
            public bool Equals(OUT0101U02ComboListArgs x, OUT0101U02ComboListArgs y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return string.Equals(x._sexCodeType, y._sexCodeType) && string.Equals(x._bunhoCodeType, y._bunhoCodeType) && string.Equals(x._boninCodeType, y._boninCodeType) && string.Equals(x._telCodeType, y._telCodeType);
            }

            public int GetHashCode(OUT0101U02ComboListArgs obj)
            {
                unchecked
                {
                    int hashCode = (obj._sexCodeType != null ? obj._sexCodeType.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ (obj._bunhoCodeType != null ? obj._bunhoCodeType.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ (obj._boninCodeType != null ? obj._boninCodeType.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ (obj._telCodeType != null ? obj._telCodeType.GetHashCode() : 0);
                    return hashCode;
                }
            }
        }

        private static readonly IEqualityComparer<OUT0101U02ComboListArgs> Out0101U02ComboListArgsComparerInstance = new Out0101U02ComboListArgsEqualityComparer();

        public static IEqualityComparer<OUT0101U02ComboListArgs> Out0101U02ComboListArgsComparer
        {
            get { return Out0101U02ComboListArgsComparerInstance; }
        }
        private String _bunhoCodeType;
        private String _telCodeType;
        private String _boninCodeType;
        private String _billingCodeType;

        public String SexCodeType
        {
            get { return this._sexCodeType; }
            set { this._sexCodeType = value; }
        }

        public String BunhoCodeType
        {
            get { return this._bunhoCodeType; }
            set { this._bunhoCodeType = value; }
        }

        public String TelCodeType
        {
            get { return this._telCodeType; }
            set { this._telCodeType = value; }
        }

        public String BoninCodeType
        {
            get { return this._boninCodeType; }
            set { this._boninCodeType = value; }
        }

        public String BillingCodeType
        {
            get { return this._billingCodeType; }
            set { this._billingCodeType = value; }
        }

        public OUT0101U02ComboListArgs() { }

        public OUT0101U02ComboListArgs(String sexCodeType, String bunhoCodeType, String telCodeType, String boninCodeType, String billingCodeType)
        {
            this._sexCodeType = sexCodeType;
            this._bunhoCodeType = bunhoCodeType;
            this._telCodeType = telCodeType;
            this._boninCodeType = boninCodeType;
            this._billingCodeType = billingCodeType;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OUT0101U02ComboListRequest();
        }
    }
}