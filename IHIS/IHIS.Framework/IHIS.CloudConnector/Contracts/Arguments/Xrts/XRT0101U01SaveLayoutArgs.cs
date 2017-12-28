using System;
using IHIS.CloudConnector.Contracts.Models.Xrts;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Xrts
{[Serializable]
    public class XRT0101U01SaveLayoutArgs : IContractArgs
    {
    protected bool Equals(XRT0101U01SaveLayoutArgs other)
    {
        return string.Equals(_userId, other._userId) && Equals(_inputMCode, other._inputMCode) && Equals(_inputDCode, other._inputDCode);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((XRT0101U01SaveLayoutArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_userId != null ? _userId.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_inputMCode != null ? _inputMCode.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_inputDCode != null ? _inputDCode.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _userId;
        private List<XRT0101U01GrdMcodeListItemInfo> _inputMCode = new List<XRT0101U01GrdMcodeListItemInfo>();
        private List<XRT0101U01GrdDcodeListItemInfo> _inputDCode = new List<XRT0101U01GrdDcodeListItemInfo>();

        public String UserId
        {
            get { return this._userId; }
            set { this._userId = value; }
        }

        public List<XRT0101U01GrdMcodeListItemInfo> InputMCode
        {
            get { return this._inputMCode; }
            set { this._inputMCode = value; }
        }

        public List<XRT0101U01GrdDcodeListItemInfo> InputDCode
        {
            get { return this._inputDCode; }
            set { this._inputDCode = value; }
        }

        public XRT0101U01SaveLayoutArgs() { }

        public XRT0101U01SaveLayoutArgs(String userId, List<XRT0101U01GrdMcodeListItemInfo> inputMCode, List<XRT0101U01GrdDcodeListItemInfo> inputDCode)
        {
            this._userId = userId;
            this._inputMCode = inputMCode;
            this._inputDCode = inputDCode;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.XRT0101U01SaveLayoutRequest();
        }
    }
}