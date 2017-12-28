using System;
using IHIS.CloudConnector.Contracts.Models.Cpls;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Cpls
{
    [Serializable]
    public class CPLBMLUPLOADERExcelInsertArgs : IContractArgs
    {
        protected bool Equals(CPLBMLUPLOADERExcelInsertArgs other)
        {
            return Equals(_uploaderExcelList, other._uploaderExcelList);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CPLBMLUPLOADERExcelInsertArgs) obj);
        }

        public override int GetHashCode()
        {
            return (_uploaderExcelList != null ? _uploaderExcelList.GetHashCode() : 0);
        }

        private List<CPLBMLUPLOADERExcelInsertInfo> _uploaderExcelList = new List<CPLBMLUPLOADERExcelInsertInfo>();

        public List<CPLBMLUPLOADERExcelInsertInfo> UploaderExcelList
        {
            get { return this._uploaderExcelList; }
            set { this._uploaderExcelList = value; }
        }

        public CPLBMLUPLOADERExcelInsertArgs() { }

        public CPLBMLUPLOADERExcelInsertArgs(List<CPLBMLUPLOADERExcelInsertInfo> uploaderExcelList)
        {
            this._uploaderExcelList = uploaderExcelList;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.CPLBMLUPLOADERExcelInsertRequest();
        }
    }
}