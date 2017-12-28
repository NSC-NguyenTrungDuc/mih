using System;
using IHIS.CloudConnector.Contracts.Models.Ocso;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocso
{[Serializable]
    public class OCS2016U00UpdateQuestionArgs : IContractArgs
    {
    protected bool Equals(OCS2016U00UpdateQuestionArgs other)
    {
        return string.Equals(_grpQuestionId, other._grpQuestionId) && string.Equals(_updId, other._updId) && string.Equals(_content, other._content) && string.Equals(_actionType, other._actionType);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS2016U00UpdateQuestionArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_grpQuestionId != null ? _grpQuestionId.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_updId != null ? _updId.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_content != null ? _content.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_actionType != null ? _actionType.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _grpQuestionId;
        private String _updId;
        private String _content;
        private String _actionType;

        public String GrpQuestionId
        {
            get { return this._grpQuestionId; }
            set { this._grpQuestionId = value; }
        }

        public String UpdId
        {
            get { return this._updId; }
            set { this._updId = value; }
        }

        public String Content
        {
            get { return this._content; }
            set { this._content = value; }
        }

        public String ActionType
        {
            get { return this._actionType; }
            set { this._actionType = value; }
        }

        public OCS2016U00UpdateQuestionArgs() { }

        public OCS2016U00UpdateQuestionArgs(String grpQuestionId, String updId, String content, String actionType)
        {
            this._grpQuestionId = grpQuestionId;
            this._updId = updId;
            this._content = content;
            this._actionType = actionType;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCS2016U00UpdateQuestionRequest();
        }
    }
}