using System;
using IHIS.CloudConnector.Contracts.Models.Ocso;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocso
{[Serializable]
    public class OCSACTBtnReportViewerClickArgs : IContractArgs
    {
        protected bool Equals(OCSACTBtnReportViewerClickArgs other)
        {
            return string.Equals(_jundalPart, other._jundalPart);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((OCSACTBtnReportViewerClickArgs) obj);
        }

        public override int GetHashCode()
        {
            return (_jundalPart != null ? _jundalPart.GetHashCode() : 0);
        }

        private String _jundalPart;

        public String JundalPart
        {
            get { return this._jundalPart; }
            set { this._jundalPart = value; }
        }

        public OCSACTBtnReportViewerClickArgs() { }

        public OCSACTBtnReportViewerClickArgs(String jundalPart)
        {
            this._jundalPart = jundalPart;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCSACTBtnReportViewerClickRequest();
        }
    }
}