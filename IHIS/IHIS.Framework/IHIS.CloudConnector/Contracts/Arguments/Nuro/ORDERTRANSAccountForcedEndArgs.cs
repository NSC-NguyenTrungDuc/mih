using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
    public class ORDERTRANSAccountForcedEndArgs : IContractArgs
    {
        protected bool Equals(ORDERTRANSAccountForcedEndArgs other)
        {
            return string.Equals(_hospCode, other._hospCode) && string.Equals(_bunho, other._bunho) && string.Equals(_actingDate, other._actingDate) && string.Equals(_gubun, other._gubun) && string.Equals(_gwa, other._gwa) && string.Equals(_doctor, other._doctor) && string.Equals(_chojae, other._chojae) && string.Equals(_sunabDate, other._sunabDate) && Equals(_accForcedEndItem, other._accForcedEndItem);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ORDERTRANSAccountForcedEndArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_hospCode != null ? _hospCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_bunho != null ? _bunho.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_actingDate != null ? _actingDate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_gubun != null ? _gubun.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_gwa != null ? _gwa.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_doctor != null ? _doctor.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_chojae != null ? _chojae.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_sunabDate != null ? _sunabDate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_accForcedEndItem != null ? _accForcedEndItem.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _hospCode;
        private String _bunho;
        private String _actingDate;
        private String _gubun;
        private String _gwa;
        private String _doctor;
        private String _chojae;
        private String _sunabDate;
        private List<ORDERTRANSAccountForcedEndInfo> _accForcedEndItem = new List<ORDERTRANSAccountForcedEndInfo>();

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public String ActingDate
        {
            get { return this._actingDate; }
            set { this._actingDate = value; }
        }

        public String Gubun
        {
            get { return this._gubun; }
            set { this._gubun = value; }
        }

        public String Gwa
        {
            get { return this._gwa; }
            set { this._gwa = value; }
        }

        public String Doctor
        {
            get { return this._doctor; }
            set { this._doctor = value; }
        }

        public String Chojae
        {
            get { return this._chojae; }
            set { this._chojae = value; }
        }

        public String SunabDate
        {
            get { return this._sunabDate; }
            set { this._sunabDate = value; }
        }

        public List<ORDERTRANSAccountForcedEndInfo> AccForcedEndItem
        {
            get { return this._accForcedEndItem; }
            set { this._accForcedEndItem = value; }
        }

        public ORDERTRANSAccountForcedEndArgs() { }

        public ORDERTRANSAccountForcedEndArgs(String hospCode, String bunho, String actingDate, String gubun, String gwa, String doctor, String chojae, String sunabDate, List<ORDERTRANSAccountForcedEndInfo> accForcedEndItem)
        {
            this._hospCode = hospCode;
            this._bunho = bunho;
            this._actingDate = actingDate;
            this._gubun = gubun;
            this._gwa = gwa;
            this._doctor = doctor;
            this._chojae = chojae;
            this._sunabDate = sunabDate;
            this._accForcedEndItem = accForcedEndItem;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.ORDERTRANSAccountForcedEndRequest();
        }
    }
}