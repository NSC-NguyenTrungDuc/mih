using System;

namespace IHIS.CloudConnector.Contracts.Models.Bass
{
    [Serializable]
    public class BAS0311U00GridListItemInfo
    {
        private String _sgCode;
        private String _groupGubun;
        private String _sgName;
        private String _sgNameKana;
        private String _sgYmd;
        private String _sugaChange;
        private String _sugaChangeNmD;
        private String _bulyongYmd;
        private String _bulyongSayu;
        private String _bulyongSayuNmD;
        private String _danui;
        private String _danuiName;
        private String _bunCode;
        private String _bunCodeName;
        private String _marumeGubun;
        private String _sgUnion;
        private String _remark;
        private String _marumeName;
        private String _hubalDrgYn;
        private String _sunabQcodeOutName;
        private String _sunabQcodeInpName;
        private String _taxYn;

        public String SgCode
        {
            get { return this._sgCode; }
            set { this._sgCode = value; }
        }

        public String GroupGubun
        {
            get { return this._groupGubun; }
            set { this._groupGubun = value; }
        }

        public String SgName
        {
            get { return this._sgName; }
            set { this._sgName = value; }
        }

        public String SgNameKana
        {
            get { return this._sgNameKana; }
            set { this._sgNameKana = value; }
        }

        public String SgYmd
        {
            get { return this._sgYmd; }
            set { this._sgYmd = value; }
        }

        public String SugaChange
        {
            get { return this._sugaChange; }
            set { this._sugaChange = value; }
        }

        public String SugaChangeNmD
        {
            get { return this._sugaChangeNmD; }
            set { this._sugaChangeNmD = value; }
        }

        public String BulyongYmd
        {
            get { return this._bulyongYmd; }
            set { this._bulyongYmd = value; }
        }

        public String BulyongSayu
        {
            get { return this._bulyongSayu; }
            set { this._bulyongSayu = value; }
        }

        public String BulyongSayuNmD
        {
            get { return this._bulyongSayuNmD; }
            set { this._bulyongSayuNmD = value; }
        }

        public String Danui
        {
            get { return this._danui; }
            set { this._danui = value; }
        }

        public String DanuiName
        {
            get { return this._danuiName; }
            set { this._danuiName = value; }
        }

        public String BunCode
        {
            get { return this._bunCode; }
            set { this._bunCode = value; }
        }

        public String BunCodeName
        {
            get { return this._bunCodeName; }
            set { this._bunCodeName = value; }
        }

        public String MarumeGubun
        {
            get { return this._marumeGubun; }
            set { this._marumeGubun = value; }
        }

        public String SgUnion
        {
            get { return this._sgUnion; }
            set { this._sgUnion = value; }
        }

        public String Remark
        {
            get { return this._remark; }
            set { this._remark = value; }
        }

        public String MarumeName
        {
            get { return this._marumeName; }
            set { this._marumeName = value; }
        }

        public String HubalDrgYn
        {
            get { return this._hubalDrgYn; }
            set { this._hubalDrgYn = value; }
        }

        public String SunabQcodeOutName
        {
            get { return this._sunabQcodeOutName; }
            set { this._sunabQcodeOutName = value; }
        }

        public String SunabQcodeInpName
        {
            get { return this._sunabQcodeInpName; }
            set { this._sunabQcodeInpName = value; }
        }

        public String TaxYn
        {
            get { return this._taxYn; }
            set { this._taxYn = value; }
        }

        public BAS0311U00GridListItemInfo() { }

        public BAS0311U00GridListItemInfo(String sgCode, String groupGubun, String sgName, String sgNameKana, String sgYmd, String sugaChange, String sugaChangeNmD, String bulyongYmd, String bulyongSayu, String bulyongSayuNmD, String danui, String danuiName, String bunCode, String bunCodeName, String marumeGubun, String sgUnion, String remark, String marumeName, String hubalDrgYn, String sunabQcodeOutName, String sunabQcodeInpName, String taxYn)
        {
            this._sgCode = sgCode;
            this._groupGubun = groupGubun;
            this._sgName = sgName;
            this._sgNameKana = sgNameKana;
            this._sgYmd = sgYmd;
            this._sugaChange = sugaChange;
            this._sugaChangeNmD = sugaChangeNmD;
            this._bulyongYmd = bulyongYmd;
            this._bulyongSayu = bulyongSayu;
            this._bulyongSayuNmD = bulyongSayuNmD;
            this._danui = danui;
            this._danuiName = danuiName;
            this._bunCode = bunCode;
            this._bunCodeName = bunCodeName;
            this._marumeGubun = marumeGubun;
            this._sgUnion = sgUnion;
            this._remark = remark;
            this._marumeName = marumeName;
            this._hubalDrgYn = hubalDrgYn;
            this._sunabQcodeOutName = sunabQcodeOutName;
            this._sunabQcodeInpName = sunabQcodeInpName;
            this._taxYn = taxYn;
        }

    }
}