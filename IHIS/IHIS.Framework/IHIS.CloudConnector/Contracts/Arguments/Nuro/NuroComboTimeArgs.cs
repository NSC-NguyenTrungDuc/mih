using System;
using System.Collections.Generic;
using System.Text;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
    public class NuroComboTimeArgs : IContractArgs
    {
        protected bool Equals(NuroComboTimeArgs other)
        {
            return string.Equals(_codeType, other._codeType);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NuroComboTimeArgs) obj);
        }

        public override int GetHashCode()
        {
            return (_codeType != null ? _codeType.GetHashCode() : 0);
        }

        private string _codeType;
        public NuroComboTimeArgs()
        {
            
        }
        public NuroComboTimeArgs(string codeType)
        {
            CodeType = codeType;
        }

        public string CodeType
        {
            get { return _codeType; }
            set { _codeType = value; }
        }

        public IExtensible GetRequestInstance()
        {
            return new NuroComboTimeRequest();
        }
    }
}
