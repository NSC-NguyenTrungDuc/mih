using System;
using System.Collections.Generic;
using System.Text;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
    public class NuroNUR2001U04DepartmentListArgs : IContractArgs
    {
        protected bool Equals(NuroNUR2001U04DepartmentListArgs other)
        {
            return string.Equals(_comingDate, other._comingDate);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NuroNUR2001U04DepartmentListArgs) obj);
        }

        public override int GetHashCode()
        {
            return (_comingDate != null ? _comingDate.GetHashCode() : 0);
        }

        private string _comingDate;

        public string ComingDate
        {
            get { return _comingDate; }
            set { _comingDate = value; }
        }

        public NuroNUR2001U04DepartmentListArgs(string comingDate)
        {
            _comingDate = comingDate;
        }

        public NuroNUR2001U04DepartmentListArgs()
        {
        }

        public IExtensible GetRequestInstance()
        {
            return new NuroNUR2001U04DepartmentListRequest();
        }
    }
}
