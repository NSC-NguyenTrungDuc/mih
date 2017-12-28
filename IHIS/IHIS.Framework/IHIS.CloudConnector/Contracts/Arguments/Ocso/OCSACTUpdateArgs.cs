using System;
using IHIS.CloudConnector.Contracts.Models.Ocso;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocso
{[Serializable]
    public class OCSACTUpdateArgs : IContractArgs
    {
    protected bool Equals(OCSACTUpdateArgs other)
    {
        return _rbtNonAct.Equals(other._rbtNonAct) && _rbtAct.Equals(other._rbtAct) && _isUpdJaeryoProcess.Equals(other._isUpdJaeryoProcess) && string.Equals(_actYn, other._actYn) && string.Equals(_inOutGubun, other._inOutGubun) && string.Equals(_sortFkocskey, other._sortFkocskey) && string.Equals(_pkocs, other._pkocs) && string.Equals(_actingDate, other._actingDate) && string.Equals(_actingTime, other._actingTime) && string.Equals(_newOcsKey, other._newOcsKey) && string.Equals(_jundalPart, other._jundalPart) && string.Equals(_orderDate, other._orderDate) && string.Equals(_userId, other._userId) && string.Equals(_bunho, other._bunho) && Equals(_updateGrdOrderItem, other._updateGrdOrderItem) && Equals(_jaeryoWithUpdItem, other._jaeryoWithUpdItem) && Equals(_jaeryoItem, other._jaeryoItem) && Equals(_deleteJaeryoItem, other._deleteJaeryoItem);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCSACTUpdateArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = _rbtNonAct.GetHashCode();
            hashCode = (hashCode*397) ^ _rbtAct.GetHashCode();
            hashCode = (hashCode*397) ^ _isUpdJaeryoProcess.GetHashCode();
            hashCode = (hashCode*397) ^ (_actYn != null ? _actYn.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_inOutGubun != null ? _inOutGubun.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_sortFkocskey != null ? _sortFkocskey.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_pkocs != null ? _pkocs.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_actingDate != null ? _actingDate.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_actingTime != null ? _actingTime.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_newOcsKey != null ? _newOcsKey.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_jundalPart != null ? _jundalPart.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_orderDate != null ? _orderDate.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_userId != null ? _userId.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_bunho != null ? _bunho.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_updateGrdOrderItem != null ? _updateGrdOrderItem.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_jaeryoWithUpdItem != null ? _jaeryoWithUpdItem.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_jaeryoItem != null ? _jaeryoItem.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_deleteJaeryoItem != null ? _deleteJaeryoItem.GetHashCode() : 0);
            return hashCode;
        }
    }

    private Boolean _rbtNonAct;
        private Boolean _rbtAct;
        private Boolean _isUpdJaeryoProcess;
        private String _actYn;
        private String _inOutGubun;
        private String _sortFkocskey;
        private String _pkocs;
        private String _actingDate;
        private String _actingTime;
        private String _newOcsKey;
        private String _jundalPart;
        private String _orderDate;
        private String _userId;
        private String _bunho;
        private List<OCSACTUpdateGrdOrderInfo> _updateGrdOrderItem = new List<OCSACTUpdateGrdOrderInfo>();
        private List<OCSACTUpdJaeryoProcessWithUpdGubunInfo> _jaeryoWithUpdItem = new List<OCSACTUpdJaeryoProcessWithUpdGubunInfo>();
        private List<OCSACTUpdJaeryoProcessInfo> _jaeryoItem = new List<OCSACTUpdJaeryoProcessInfo>();
        private List<OCSACTDeleteJaeryoInfo> _deleteJaeryoItem = new List<OCSACTDeleteJaeryoInfo>();

        public Boolean RbtNonAct
        {
            get { return this._rbtNonAct; }
            set { this._rbtNonAct = value; }
        }

        public Boolean RbtAct
        {
            get { return this._rbtAct; }
            set { this._rbtAct = value; }
        }

        public Boolean IsUpdJaeryoProcess
        {
            get { return this._isUpdJaeryoProcess; }
            set { this._isUpdJaeryoProcess = value; }
        }

        public String ActYn
        {
            get { return this._actYn; }
            set { this._actYn = value; }
        }

        public String InOutGubun
        {
            get { return this._inOutGubun; }
            set { this._inOutGubun = value; }
        }

        public String SortFkocskey
        {
            get { return this._sortFkocskey; }
            set { this._sortFkocskey = value; }
        }

        public String Pkocs
        {
            get { return this._pkocs; }
            set { this._pkocs = value; }
        }

        public String ActingDate
        {
            get { return this._actingDate; }
            set { this._actingDate = value; }
        }

        public String ActingTime
        {
            get { return this._actingTime; }
            set { this._actingTime = value; }
        }

        public String NewOcsKey
        {
            get { return this._newOcsKey; }
            set { this._newOcsKey = value; }
        }

        public String JundalPart
        {
            get { return this._jundalPart; }
            set { this._jundalPart = value; }
        }

        public String OrderDate
        {
            get { return this._orderDate; }
            set { this._orderDate = value; }
        }

        public String UserId
        {
            get { return this._userId; }
            set { this._userId = value; }
        }

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public List<OCSACTUpdateGrdOrderInfo> UpdateGrdOrderItem
        {
            get { return this._updateGrdOrderItem; }
            set { this._updateGrdOrderItem = value; }
        }

        public List<OCSACTUpdJaeryoProcessWithUpdGubunInfo> JaeryoWithUpdItem
        {
            get { return this._jaeryoWithUpdItem; }
            set { this._jaeryoWithUpdItem = value; }
        }

        public List<OCSACTUpdJaeryoProcessInfo> JaeryoItem
        {
            get { return this._jaeryoItem; }
            set { this._jaeryoItem = value; }
        }

        public List<OCSACTDeleteJaeryoInfo> DeleteJaeryoItem
        {
            get { return this._deleteJaeryoItem; }
            set { this._deleteJaeryoItem = value; }
        }

        public OCSACTUpdateArgs() { }

        public OCSACTUpdateArgs(Boolean rbtNonAct, Boolean rbtAct, Boolean isUpdJaeryoProcess, String actYn, String inOutGubun, String sortFkocskey, String pkocs, String actingDate, String actingTime, String newOcsKey, String jundalPart, String orderDate, String userId, String bunho, List<OCSACTUpdateGrdOrderInfo> updateGrdOrderItem, List<OCSACTUpdJaeryoProcessWithUpdGubunInfo> jaeryoWithUpdItem, List<OCSACTUpdJaeryoProcessInfo> jaeryoItem, List<OCSACTDeleteJaeryoInfo> deleteJaeryoItem)
        {
            this._rbtNonAct = rbtNonAct;
            this._rbtAct = rbtAct;
            this._isUpdJaeryoProcess = isUpdJaeryoProcess;
            this._actYn = actYn;
            this._inOutGubun = inOutGubun;
            this._sortFkocskey = sortFkocskey;
            this._pkocs = pkocs;
            this._actingDate = actingDate;
            this._actingTime = actingTime;
            this._newOcsKey = newOcsKey;
            this._jundalPart = jundalPart;
            this._orderDate = orderDate;
            this._userId = userId;
            this._bunho = bunho;
            this._updateGrdOrderItem = updateGrdOrderItem;
            this._jaeryoWithUpdItem = jaeryoWithUpdItem;
            this._jaeryoItem = jaeryoItem;
            this._deleteJaeryoItem = deleteJaeryoItem;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCSACTUpdateRequest();
        }
    }
}