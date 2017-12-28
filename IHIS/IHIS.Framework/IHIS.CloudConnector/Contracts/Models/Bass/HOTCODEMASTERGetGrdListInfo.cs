using System;

namespace IHIS.CloudConnector.Contracts.Models.Bass
{
    [Serializable]
    public class HOTCODEMASTERGetGrdListInfo
    {
        private String _hotCode;
        private String _hotCode7;
        private String _cinCode;
        private String _dispenseCode;
        private String _logisticCode;
        private String _janCode;
        private String _yakKijunCode;
        private String _yjCode;
        private String _sgCode;
        private String _sgCode1;
        private String _hangmogName;
        private String _hangmogName1;
        private String _hangmogName2;
        private String _standardUnit;
        private String _pkgStatus;
        private String _pkgNumUnit;
        private String _ordDanui;
        private String _pkgTotal;
        private String _pkgTotalUnit;
        private String _clsif;
        private String _manufComp;
        private String _salesComp;
        private String _clsifUpd;
        private String _sgYmd;

        public String HotCode
        {
            get { return this._hotCode; }
            set { this._hotCode = value; }
        }

        public String HotCode7
        {
            get { return this._hotCode7; }
            set { this._hotCode7 = value; }
        }

        public String CinCode
        {
            get { return this._cinCode; }
            set { this._cinCode = value; }
        }

        public String DispenseCode
        {
            get { return this._dispenseCode; }
            set { this._dispenseCode = value; }
        }

        public String LogisticCode
        {
            get { return this._logisticCode; }
            set { this._logisticCode = value; }
        }

        public String JanCode
        {
            get { return this._janCode; }
            set { this._janCode = value; }
        }

        public String YakKijunCode
        {
            get { return this._yakKijunCode; }
            set { this._yakKijunCode = value; }
        }

        public String YjCode
        {
            get { return this._yjCode; }
            set { this._yjCode = value; }
        }

        public String SgCode
        {
            get { return this._sgCode; }
            set { this._sgCode = value; }
        }

        public String SgCode1
        {
            get { return this._sgCode1; }
            set { this._sgCode1 = value; }
        }

        public String HangmogName
        {
            get { return this._hangmogName; }
            set { this._hangmogName = value; }
        }

        public String HangmogName1
        {
            get { return this._hangmogName1; }
            set { this._hangmogName1 = value; }
        }

        public String HangmogName2
        {
            get { return this._hangmogName2; }
            set { this._hangmogName2 = value; }
        }

        public String StandardUnit
        {
            get { return this._standardUnit; }
            set { this._standardUnit = value; }
        }

        public String PkgStatus
        {
            get { return this._pkgStatus; }
            set { this._pkgStatus = value; }
        }

        public String PkgNumUnit
        {
            get { return this._pkgNumUnit; }
            set { this._pkgNumUnit = value; }
        }

        public String OrdDanui
        {
            get { return this._ordDanui; }
            set { this._ordDanui = value; }
        }

        public String PkgTotal
        {
            get { return this._pkgTotal; }
            set { this._pkgTotal = value; }
        }

        public String PkgTotalUnit
        {
            get { return this._pkgTotalUnit; }
            set { this._pkgTotalUnit = value; }
        }

        public String Clsif
        {
            get { return this._clsif; }
            set { this._clsif = value; }
        }

        public String ManufComp
        {
            get { return this._manufComp; }
            set { this._manufComp = value; }
        }

        public String SalesComp
        {
            get { return this._salesComp; }
            set { this._salesComp = value; }
        }

        public String ClsifUpd
        {
            get { return this._clsifUpd; }
            set { this._clsifUpd = value; }
        }

        public String SgYmd
        {
            get { return this._sgYmd; }
            set { this._sgYmd = value; }
        }

        public HOTCODEMASTERGetGrdListInfo() { }

        public HOTCODEMASTERGetGrdListInfo(String hotCode, String hotCode7, String cinCode, String dispenseCode, String logisticCode, String janCode, String yakKijunCode, String yjCode, String sgCode, String sgCode1, String hangmogName, String hangmogName1, String hangmogName2, String standardUnit, String pkgStatus, String pkgNumUnit, String ordDanui, String pkgTotal, String pkgTotalUnit, String clsif, String manufComp, String salesComp, String clsifUpd, String sgYmd)
        {
            this._hotCode = hotCode;
            this._hotCode7 = hotCode7;
            this._cinCode = cinCode;
            this._dispenseCode = dispenseCode;
            this._logisticCode = logisticCode;
            this._janCode = janCode;
            this._yakKijunCode = yakKijunCode;
            this._yjCode = yjCode;
            this._sgCode = sgCode;
            this._sgCode1 = sgCode1;
            this._hangmogName = hangmogName;
            this._hangmogName1 = hangmogName1;
            this._hangmogName2 = hangmogName2;
            this._standardUnit = standardUnit;
            this._pkgStatus = pkgStatus;
            this._pkgNumUnit = pkgNumUnit;
            this._ordDanui = ordDanui;
            this._pkgTotal = pkgTotal;
            this._pkgTotalUnit = pkgTotalUnit;
            this._clsif = clsif;
            this._manufComp = manufComp;
            this._salesComp = salesComp;
            this._clsifUpd = clsifUpd;
            this._sgYmd = sgYmd;
        }

    }
}