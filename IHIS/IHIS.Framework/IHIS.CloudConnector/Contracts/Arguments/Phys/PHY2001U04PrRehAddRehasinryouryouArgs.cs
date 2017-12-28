using System;
using IHIS.CloudConnector.Contracts.Models.Phys;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Phys
{[Serializable]
    public class PHY2001U04PrRehAddRehasinryouryouArgs : IContractArgs
    {
    protected bool Equals(PHY2001U04PrRehAddRehasinryouryouArgs other)
    {
        return string.Equals(_orderDate, other._orderDate) && string.Equals(_bunho, other._bunho) && string.Equals(_fkout1001, other._fkout1001) && string.Equals(_doctor, other._doctor) && string.Equals(_inputId, other._inputId) && string.Equals(_iudGubun, other._iudGubun) && Equals(_sinryouryouGubun, other._sinryouryouGubun) && string.Equals(_inputTab, other._inputTab);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((PHY2001U04PrRehAddRehasinryouryouArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_orderDate != null ? _orderDate.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_bunho != null ? _bunho.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_fkout1001 != null ? _fkout1001.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_doctor != null ? _doctor.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_inputId != null ? _inputId.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_iudGubun != null ? _iudGubun.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_sinryouryouGubun != null ? _sinryouryouGubun.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_inputTab != null ? _inputTab.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _orderDate;
        private String _bunho;
        private String _fkout1001;
        private String _doctor;
        private String _inputId;
        private String _inputTab;
        private String _iudGubun;
        private List<PHY2001U04PrRehAddRehasinryouryouInfo> _sinryouryouGubun = new List<PHY2001U04PrRehAddRehasinryouryouInfo>();

        public String OrderDate
        {
            get { return this._orderDate; }
            set { this._orderDate = value; }
        }

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public String Fkout1001
        {
            get { return this._fkout1001; }
            set { this._fkout1001 = value; }
        }

        public String Doctor
        {
            get { return this._doctor; }
            set { this._doctor = value; }
        }

        public String InputId
        {
            get { return this._inputId; }
            set { this._inputId = value; }
        }

        public String InputTab
        {
            get { return this._inputTab; }
            set { this._inputTab = value; }
        }

        public String IudGubun
        {
            get { return this._iudGubun; }
            set { this._iudGubun = value; }
        }

        public List<PHY2001U04PrRehAddRehasinryouryouInfo> SinryouryouGubun
        {
            get { return this._sinryouryouGubun; }
            set { this._sinryouryouGubun = value; }
        }

        public PHY2001U04PrRehAddRehasinryouryouArgs() { }

        public PHY2001U04PrRehAddRehasinryouryouArgs(String orderDate, String bunho, String fkout1001, String doctor, String inputId, String inputTab, String iudGubun, List<PHY2001U04PrRehAddRehasinryouryouInfo> sinryouryouGubun)
        {
            this._orderDate = orderDate;
            this._bunho = bunho;
            this._fkout1001 = fkout1001;
            this._doctor = doctor;
            this._inputId = inputId;
            this._inputTab = inputTab;
            this._iudGubun = iudGubun;
            this._sinryouryouGubun = sinryouryouGubun;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.PHY2001U04PrRehAddRehasinryouryouRequest();
        }
    }
}