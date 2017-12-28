using System;
using IHIS.CloudConnector.Contracts.Models.Ocso;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocso
{[Serializable]
    public class OCS2016U00LoadDiscussionArgs : IContractArgs
    {
    protected bool Equals(OCS2016U00LoadDiscussionArgs other)
    {
        return string.Equals(_grpQuestionId, other._grpQuestionId);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS2016U00LoadDiscussionArgs) obj);
    }

    public override int GetHashCode()
    {
        return (_grpQuestionId != null ? _grpQuestionId.GetHashCode() : 0);
    }

    private String _grpQuestionId;

        public String GrpQuestionId
        {
            get { return this._grpQuestionId; }
            set { this._grpQuestionId = value; }
        }

        public OCS2016U00LoadDiscussionArgs() { }

        public OCS2016U00LoadDiscussionArgs(String grpQuestionId)
        {
            this._grpQuestionId = grpQuestionId;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCS2016U00LoadDiscussionRequest();
        }
    }
}