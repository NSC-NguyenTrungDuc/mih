using System;

namespace IHIS.CloudConnector.Contracts.Models.Cpls
{
    [Serializable]
    public class CPL2010U00OrderCancelGrdOrderListItemInfo
    {
        private String _fkocs1003;
        private String _hangmogCode;
        private String _gumsaName;
        private String _specimenCode;
        private String _specimenName;
        private String _specimenSer;
        private String _pkcpl2010;

        public String Fkocs1003
        {
            get { return this._fkocs1003; }
            set { this._fkocs1003 = value; }
        }

        public String HangmogCode
        {
            get { return this._hangmogCode; }
            set { this._hangmogCode = value; }
        }

        public String GumsaName
        {
            get { return this._gumsaName; }
            set { this._gumsaName = value; }
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

        public String SpecimenSer
        {
            get { return this._specimenSer; }
            set { this._specimenSer = value; }
        }

        public String Pkcpl2010
        {
            get { return this._pkcpl2010; }
            set { this._pkcpl2010 = value; }
        }

        public CPL2010U00OrderCancelGrdOrderListItemInfo() { }

        public CPL2010U00OrderCancelGrdOrderListItemInfo(String fkocs1003, String hangmogCode, String gumsaName, String specimenCode, String specimenName, String specimenSer, String pkcpl2010)
        {
            this._fkocs1003 = fkocs1003;
            this._hangmogCode = hangmogCode;
            this._gumsaName = gumsaName;
            this._specimenCode = specimenCode;
            this._specimenName = specimenName;
            this._specimenSer = specimenSer;
            this._pkcpl2010 = pkcpl2010;
        }

    }
}