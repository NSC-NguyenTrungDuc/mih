using System;
using IHIS.CloudConnector.Contracts.Models.Ocso;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocso
{[Serializable]
    public class OCS2016U00QuestionSaveLayoutArgs : IContractArgs
    {
    protected bool Equals(OCS2016U00QuestionSaveLayoutArgs other)
    {
        return string.Equals(_questionType, other._questionType) && Equals(_questionList, other._questionList) && Equals(_discussionList, other._discussionList);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS2016U00QuestionSaveLayoutArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_questionType != null ? _questionType.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_questionList != null ? _questionList.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_discussionList != null ? _discussionList.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _questionType;
        private List<OCS2016U00QuestionSaveLayoutInfo> _questionList = new List<OCS2016U00QuestionSaveLayoutInfo>();
        private List<OCS2016U00LoadDiscussionInfo> _discussionList = new List<OCS2016U00LoadDiscussionInfo>();

        public String QuestionType
        {
            get { return this._questionType; }
            set { this._questionType = value; }
        }

        public List<OCS2016U00QuestionSaveLayoutInfo> QuestionList
        {
            get { return this._questionList; }
            set { this._questionList = value; }
        }

        public List<OCS2016U00LoadDiscussionInfo> DiscussionList
        {
            get { return this._discussionList; }
            set { this._discussionList = value; }
        }

        public OCS2016U00QuestionSaveLayoutArgs() { }

        public OCS2016U00QuestionSaveLayoutArgs(String questionType, List<OCS2016U00QuestionSaveLayoutInfo> questionList, List<OCS2016U00LoadDiscussionInfo> discussionList)
        {
            this._questionType = questionType;
            this._questionList = questionList;
            this._discussionList = discussionList;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCS2016U00QuestionSaveLayoutRequest();
        }
    }
}