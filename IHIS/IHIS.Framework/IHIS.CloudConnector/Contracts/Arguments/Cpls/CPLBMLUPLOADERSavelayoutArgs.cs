using System;
using IHIS.CloudConnector.Contracts.Models.Cpls;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Cpls
{
    [Serializable]
    public class CPLBMLUPLOADERSavelayoutArgs : IContractArgs
    {
        protected bool Equals(CPLBMLUPLOADERSavelayoutArgs other)
        {
            return Equals(_uploaderSavelayoutInfo, other._uploaderSavelayoutInfo);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CPLBMLUPLOADERSavelayoutArgs) obj);
        }

        public override int GetHashCode()
        {
            return (_uploaderSavelayoutInfo != null ? _uploaderSavelayoutInfo.GetHashCode() : 0);
        }

        private List<CPLBMLUPLOADERSavelayoutInfo> _uploaderSavelayoutInfo = new List<CPLBMLUPLOADERSavelayoutInfo>();

        public List<CPLBMLUPLOADERSavelayoutInfo> UploaderSavelayoutInfo
        {
            get { return this._uploaderSavelayoutInfo; }
            set { this._uploaderSavelayoutInfo = value; }
        }

        public CPLBMLUPLOADERSavelayoutArgs() { }

        public CPLBMLUPLOADERSavelayoutArgs(List<CPLBMLUPLOADERSavelayoutInfo> uploaderSavelayoutInfo)
        {
            this._uploaderSavelayoutInfo = uploaderSavelayoutInfo;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.CPLBMLUPLOADERSavelayoutRequest();
        }
    }
}