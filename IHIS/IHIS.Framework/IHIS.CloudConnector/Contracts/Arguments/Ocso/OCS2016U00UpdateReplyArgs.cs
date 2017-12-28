using System;
using IHIS.CloudConnector.Contracts.Models.Ocso;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocso
{[Serializable]
    public class OCS2016U00UpdateReplyArgs : IContractArgs
    {
    protected bool Equals(OCS2016U00UpdateReplyArgs other)
    {
        return Equals(_discussionList, other._discussionList);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS2016U00UpdateReplyArgs) obj);
    }

    public override int GetHashCode()
    {
        return (_discussionList != null ? _discussionList.GetHashCode() : 0);
    }

    private List<OCS2016U00LoadDiscussionInfo> _discussionList = new List<OCS2016U00LoadDiscussionInfo>();

        public List<OCS2016U00LoadDiscussionInfo> DiscussionList
        {
            get { return this._discussionList; }
            set { this._discussionList = value; }
        }

        public OCS2016U00UpdateReplyArgs() { }

        public OCS2016U00UpdateReplyArgs(List<OCS2016U00LoadDiscussionInfo> discussionList)
        {
            this._discussionList = discussionList;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCS2016U00UpdateReplyRequest();
        }
    }
}