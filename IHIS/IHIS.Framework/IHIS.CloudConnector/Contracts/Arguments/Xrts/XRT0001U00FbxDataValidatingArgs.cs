using System;
using IHIS.CloudConnector.Contracts.Models.Xrts;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Xrts
{[Serializable]
    public class XRT0001U00FbxDataValidatingArgs : IContractArgs
    {
    protected bool Equals(XRT0001U00FbxDataValidatingArgs other)
    {
        return string.Equals(_fbName, other._fbName) && string.Equals(_code, other._code);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((XRT0001U00FbxDataValidatingArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return ((_fbName != null ? _fbName.GetHashCode() : 0)*397) ^ (_code != null ? _code.GetHashCode() : 0);
        }
    }

    private String _fbName;
        private String _code;

        public String FbName
        {
            get { return this._fbName; }
            set { this._fbName = value; }
        }

        public String Code
        {
            get { return this._code; }
            set { this._code = value; }
        }

        public XRT0001U00FbxDataValidatingArgs() { }

        public XRT0001U00FbxDataValidatingArgs(String fbName, String code)
        {
            this._fbName = fbName;
            this._code = code;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.XRT0001U00FbxDataValidatingRequest();
        }
    }
}