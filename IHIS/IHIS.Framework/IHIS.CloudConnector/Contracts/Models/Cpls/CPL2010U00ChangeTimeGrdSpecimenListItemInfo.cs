using System;

namespace IHIS.CloudConnector.Contracts.Models.Cpls
{
    [Serializable]
    public class CPL2010U00ChangeTimeGrdSpecimenListItemInfo
    {
        private String _pkcpl2010;
        private String _sunabYn;
        private String _jubsuFlag;
        private String _slipName;
        private String _hangmogCode;
        private String _gumsaName;
        private String _specimenCode;
        private String _specimenName;
        private String _emergency;
        private String _tubeName;
        private String _specimenSer;
        private String _commentJuCode;
        private String _fkocs1003;
        private String _groupGubun;
        private String _partJubsuFlag;
        private String _gumJubsuFlag;
        private String _dummy;
        private String _modifyYn;
        private String _modifyYn1;
        private String _jundalGubun;
        private String _jubsuja;
        private String _orderDate;
        private String _bunho;
        private String _jubsuDate;
        private String _jubsuTime;
        private String _orderTime;

        public String Pkcpl2010
        {
            get { return this._pkcpl2010; }
            set { this._pkcpl2010 = value; }
        }

        public String SunabYn
        {
            get { return this._sunabYn; }
            set { this._sunabYn = value; }
        }

        public String JubsuFlag
        {
            get { return this._jubsuFlag; }
            set { this._jubsuFlag = value; }
        }

        public String SlipName
        {
            get { return this._slipName; }
            set { this._slipName = value; }
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

        public String Emergency
        {
            get { return this._emergency; }
            set { this._emergency = value; }
        }

        public String TubeName
        {
            get { return this._tubeName; }
            set { this._tubeName = value; }
        }

        public String SpecimenSer
        {
            get { return this._specimenSer; }
            set { this._specimenSer = value; }
        }

        public String CommentJuCode
        {
            get { return this._commentJuCode; }
            set { this._commentJuCode = value; }
        }

        public String Fkocs1003
        {
            get { return this._fkocs1003; }
            set { this._fkocs1003 = value; }
        }

        public String GroupGubun
        {
            get { return this._groupGubun; }
            set { this._groupGubun = value; }
        }

        public String PartJubsuFlag
        {
            get { return this._partJubsuFlag; }
            set { this._partJubsuFlag = value; }
        }

        public String GumJubsuFlag
        {
            get { return this._gumJubsuFlag; }
            set { this._gumJubsuFlag = value; }
        }

        public String Dummy
        {
            get { return this._dummy; }
            set { this._dummy = value; }
        }

        public String ModifyYn
        {
            get { return this._modifyYn; }
            set { this._modifyYn = value; }
        }

        public String ModifyYn1
        {
            get { return this._modifyYn1; }
            set { this._modifyYn1 = value; }
        }

        public String JundalGubun
        {
            get { return this._jundalGubun; }
            set { this._jundalGubun = value; }
        }

        public String Jubsuja
        {
            get { return this._jubsuja; }
            set { this._jubsuja = value; }
        }

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

        public String JubsuDate
        {
            get { return this._jubsuDate; }
            set { this._jubsuDate = value; }
        }

        public String JubsuTime
        {
            get { return this._jubsuTime; }
            set { this._jubsuTime = value; }
        }

        public String OrderTime
        {
            get { return this._orderTime; }
            set { this._orderTime = value; }
        }

        public CPL2010U00ChangeTimeGrdSpecimenListItemInfo() { }

        public CPL2010U00ChangeTimeGrdSpecimenListItemInfo(String pkcpl2010, String sunabYn, String jubsuFlag, String slipName, String hangmogCode, String gumsaName, String specimenCode, String specimenName, String emergency, String tubeName, String specimenSer, String commentJuCode, String fkocs1003, String groupGubun, String partJubsuFlag, String gumJubsuFlag, String dummy, String modifyYn, String modifyYn1, String jundalGubun, String jubsuja, String orderDate, String bunho, String jubsuDate, String jubsuTime, String orderTime)
        {
            this._pkcpl2010 = pkcpl2010;
            this._sunabYn = sunabYn;
            this._jubsuFlag = jubsuFlag;
            this._slipName = slipName;
            this._hangmogCode = hangmogCode;
            this._gumsaName = gumsaName;
            this._specimenCode = specimenCode;
            this._specimenName = specimenName;
            this._emergency = emergency;
            this._tubeName = tubeName;
            this._specimenSer = specimenSer;
            this._commentJuCode = commentJuCode;
            this._fkocs1003 = fkocs1003;
            this._groupGubun = groupGubun;
            this._partJubsuFlag = partJubsuFlag;
            this._gumJubsuFlag = gumJubsuFlag;
            this._dummy = dummy;
            this._modifyYn = modifyYn;
            this._modifyYn1 = modifyYn1;
            this._jundalGubun = jundalGubun;
            this._jubsuja = jubsuja;
            this._orderDate = orderDate;
            this._bunho = bunho;
            this._jubsuDate = jubsuDate;
            this._jubsuTime = jubsuTime;
            this._orderTime = orderTime;
        }

    }
}