using System;
using IHIS.CloudConnector.Contracts.Models.Ocso;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocso
{[Serializable]
    public class OCS2016U00AddQuestionArgs : IContractArgs
    {
    protected bool Equals(OCS2016U00AddQuestionArgs other)
    {
        return string.Equals(_reqDate, other._reqDate) && string.Equals(_reqGwa, other._reqGwa) && string.Equals(_consultGwa, other._consultGwa) && string.Equals(_consultDoctor, other._consultDoctor) && string.Equals(_consultHospCode, other._consultHospCode) && string.Equals(_bunho, other._bunho) && string.Equals(_content, other._content);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS2016U00AddQuestionArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_reqDate != null ? _reqDate.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_reqGwa != null ? _reqGwa.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_consultGwa != null ? _consultGwa.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_consultDoctor != null ? _consultDoctor.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_consultHospCode != null ? _consultHospCode.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_bunho != null ? _bunho.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_content != null ? _content.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _reqDate;
        private String _reqGwa;
        private String _consultGwa;
        private String _consultDoctor;
        private String _consultHospCode;
        private String _bunho;
        private String _content;

        public String ReqDate
        {
            get { return this._reqDate; }
            set { this._reqDate = value; }
        }

        public String ReqGwa
        {
            get { return this._reqGwa; }
            set { this._reqGwa = value; }
        }

        public String ConsultGwa
        {
            get { return this._consultGwa; }
            set { this._consultGwa = value; }
        }

        public String ConsultDoctor
        {
            get { return this._consultDoctor; }
            set { this._consultDoctor = value; }
        }

        public String ConsultHospCode
        {
            get { return this._consultHospCode; }
            set { this._consultHospCode = value; }
        }

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public String Content
        {
            get { return this._content; }
            set { this._content = value; }
        }

        public OCS2016U00AddQuestionArgs() { }

        public OCS2016U00AddQuestionArgs(String reqDate, String reqGwa, String consultGwa, String consultDoctor, String consultHospCode, String bunho, String content)
        {
            this._reqDate = reqDate;
            this._reqGwa = reqGwa;
            this._consultGwa = consultGwa;
            this._consultDoctor = consultDoctor;
            this._consultHospCode = consultHospCode;
            this._bunho = bunho;
            this._content = content;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCS2016U00AddQuestionRequest();
        }
    }
}