using System;
using IHIS.CloudConnector.Contracts.Models.Ocso;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocso
{[Serializable]
    public class OCS2016U00GrdQuestionArgs : IContractArgs
    {
    protected bool Equals(OCS2016U00GrdQuestionArgs other)
    {
        return string.Equals(_hospCode, other._hospCode) && string.Equals(_doctor, other._doctor) && string.Equals(_datetime, other._datetime) && string.Equals(_questionType, other._questionType) && string.Equals(_gwa, other._gwa);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS2016U00GrdQuestionArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_hospCode != null ? _hospCode.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_doctor != null ? _doctor.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_datetime != null ? _datetime.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_questionType != null ? _questionType.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_gwa != null ? _gwa.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _hospCode;
        private String _doctor;
        private String _datetime;
        private String _questionType;
        private String _gwa;

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public String Doctor
        {
            get { return this._doctor; }
            set { this._doctor = value; }
        }

        public String Datetime
        {
            get { return this._datetime; }
            set { this._datetime = value; }
        }

        public String QuestionType
        {
            get { return this._questionType; }
            set { this._questionType = value; }
        }

        public String Gwa
        {
            get { return this._gwa; }
            set { this._gwa = value; }
        }

        public OCS2016U00GrdQuestionArgs() { }

        public OCS2016U00GrdQuestionArgs(String hospCode, String doctor, String datetime, String questionType, String gwa)
        {
            this._hospCode = hospCode;
            this._doctor = doctor;
            this._datetime = datetime;
            this._questionType = questionType;
            this._gwa = gwa;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCS2016U00GrdQuestionRequest();
        }
    }
}