using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocso
{
    [Serializable]
    public class OCS1003R00LayOCS1003Info
    {
        private String _inputGubun;
        private String _inputGubunName;
        private String _groupSer;
        private String _mixGroup;
        private String _orderGubun;
        private String _orderGubunName;
        private String _orderGubunBas;
        private String _hangmogCode;
        private String _hangmogName;
        private String _sgCode;
        private String _sgName;
        private String _suryang;
        private String _ordDanui;
        private String _ordDanuiName;
        private String _dvTime;
        private String _dv;
        private String _nalsu;
        private String _wonyoiOrderYn;
        private String _specimenCode;
        private String _specimenName;
        private String _jusa;
        private String _jusaName;
        private String _bogyongCode;
        private String _bogyongName;
        private String _hopeDate;
        private String _orderRemark;
        private String _dangilGumsaOrderYn;
        private String _dangilGumsaResultYn;
        private String _emergency;
        private String _reserYn;
        private String _seq;
        private String _reserDate;
        private String _actingDate;
        private String _orderByKey;

        public String InputGubun
        {
            get { return this._inputGubun; }
            set { this._inputGubun = value; }
        }

        public String InputGubunName
        {
            get { return this._inputGubunName; }
            set { this._inputGubunName = value; }
        }

        public String GroupSer
        {
            get { return this._groupSer; }
            set { this._groupSer = value; }
        }

        public String MixGroup
        {
            get { return this._mixGroup; }
            set { this._mixGroup = value; }
        }

        public String OrderGubun
        {
            get { return this._orderGubun; }
            set { this._orderGubun = value; }
        }

        public String OrderGubunName
        {
            get { return this._orderGubunName; }
            set { this._orderGubunName = value; }
        }

        public String OrderGubunBas
        {
            get { return this._orderGubunBas; }
            set { this._orderGubunBas = value; }
        }

        public String HangmogCode
        {
            get { return this._hangmogCode; }
            set { this._hangmogCode = value; }
        }

        public String HangmogName
        {
            get { return this._hangmogName; }
            set { this._hangmogName = value; }
        }

        public String SgCode
        {
            get { return this._sgCode; }
            set { this._sgCode = value; }
        }

        public String SgName
        {
            get { return this._sgName; }
            set { this._sgName = value; }
        }

        public String Suryang
        {
            get { return this._suryang; }
            set { this._suryang = value; }
        }

        public String OrdDanui
        {
            get { return this._ordDanui; }
            set { this._ordDanui = value; }
        }

        public String OrdDanuiName
        {
            get { return this._ordDanuiName; }
            set { this._ordDanuiName = value; }
        }

        public String DvTime
        {
            get { return this._dvTime; }
            set { this._dvTime = value; }
        }

        public String Dv
        {
            get { return this._dv; }
            set { this._dv = value; }
        }

        public String Nalsu
        {
            get { return this._nalsu; }
            set { this._nalsu = value; }
        }

        public String WonyoiOrderYn
        {
            get { return this._wonyoiOrderYn; }
            set { this._wonyoiOrderYn = value; }
        }

        public String SpecimenCode
        {
            get { return this._specimenCode; }
            set { this._specimenCode = value; }
        }

        public String SpecimenName
        {
            get { return this._specimenName; }
            set { this._specimenName = value; }
        }

        public String Jusa
        {
            get { return this._jusa; }
            set { this._jusa = value; }
        }

        public String JusaName
        {
            get { return this._jusaName; }
            set { this._jusaName = value; }
        }

        public String BogyongCode
        {
            get { return this._bogyongCode; }
            set { this._bogyongCode = value; }
        }

        public String BogyongName
        {
            get { return this._bogyongName; }
            set { this._bogyongName = value; }
        }

        public String HopeDate
        {
            get { return this._hopeDate; }
            set { this._hopeDate = value; }
        }

        public String OrderRemark
        {
            get { return this._orderRemark; }
            set { this._orderRemark = value; }
        }

        public String DangilGumsaOrderYn
        {
            get { return this._dangilGumsaOrderYn; }
            set { this._dangilGumsaOrderYn = value; }
        }

        public String DangilGumsaResultYn
        {
            get { return this._dangilGumsaResultYn; }
            set { this._dangilGumsaResultYn = value; }
        }

        public String Emergency
        {
            get { return this._emergency; }
            set { this._emergency = value; }
        }

        public String ReserYn
        {
            get { return this._reserYn; }
            set { this._reserYn = value; }
        }

        public String Seq
        {
            get { return this._seq; }
            set { this._seq = value; }
        }

        public String ReserDate
        {
            get { return this._reserDate; }
            set { this._reserDate = value; }
        }

        public String ActingDate
        {
            get { return this._actingDate; }
            set { this._actingDate = value; }
        }

        public String OrderByKey
        {
            get { return this._orderByKey; }
            set { this._orderByKey = value; }
        }

        public OCS1003R00LayOCS1003Info() { }

        public OCS1003R00LayOCS1003Info(String inputGubun, String inputGubunName, String groupSer, String mixGroup, String orderGubun, String orderGubunName, String orderGubunBas, String hangmogCode, String hangmogName, String sgCode, String sgName, String suryang, String ordDanui, String ordDanuiName, String dvTime, String dv, String nalsu, String wonyoiOrderYn, String specimenCode, String specimenName, String jusa, String jusaName, String bogyongCode, String bogyongName, String hopeDate, String orderRemark, String dangilGumsaOrderYn, String dangilGumsaResultYn, String emergency, String reserYn, String seq, String reserDate, String actingDate, String orderByKey)
        {
            this._inputGubun = inputGubun;
            this._inputGubunName = inputGubunName;
            this._groupSer = groupSer;
            this._mixGroup = mixGroup;
            this._orderGubun = orderGubun;
            this._orderGubunName = orderGubunName;
            this._orderGubunBas = orderGubunBas;
            this._hangmogCode = hangmogCode;
            this._hangmogName = hangmogName;
            this._sgCode = sgCode;
            this._sgName = sgName;
            this._suryang = suryang;
            this._ordDanui = ordDanui;
            this._ordDanuiName = ordDanuiName;
            this._dvTime = dvTime;
            this._dv = dv;
            this._nalsu = nalsu;
            this._wonyoiOrderYn = wonyoiOrderYn;
            this._specimenCode = specimenCode;
            this._specimenName = specimenName;
            this._jusa = jusa;
            this._jusaName = jusaName;
            this._bogyongCode = bogyongCode;
            this._bogyongName = bogyongName;
            this._hopeDate = hopeDate;
            this._orderRemark = orderRemark;
            this._dangilGumsaOrderYn = dangilGumsaOrderYn;
            this._dangilGumsaResultYn = dangilGumsaResultYn;
            this._emergency = emergency;
            this._reserYn = reserYn;
            this._seq = seq;
            this._reserDate = reserDate;
            this._actingDate = actingDate;
            this._orderByKey = orderByKey;
        }

    }
}