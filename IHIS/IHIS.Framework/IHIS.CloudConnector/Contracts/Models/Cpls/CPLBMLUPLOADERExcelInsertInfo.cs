using System;

namespace IHIS.CloudConnector.Contracts.Models.Cpls
{
    [Serializable]
    public class CPLBMLUPLOADERExcelInsertInfo
    {
        private String _iUserId;
        private String _iGroupGubun;
        private String _iParentCode;
        private String _iHangmogCode;
        private String _iSerial;
        private String _iGumsaNameRe;
        private String _iGumsaName;
        private String _iSlipCode;
        private String _iSlipName;
        private String _iJundalGubun;
        private String _iJundalGubunName;
        private String _iTubeName;
        private String _iKeepMeansName;
        private String _iSpecimenCode;
        private String _iSpecimenName;
        private String _iDanui;
        private String _iMenFromStandard;
        private String _iMenToStandard;
        private String _iWomenFromStandard;
        private String _iWomenToStandard;
        private String _iSgCode1;
        private String _iSgCode2;
        private String _iSpecimenAmt;
        private String _iDetailInfo;
        private String _iJukyongDate;
        private String _iEmergency;
        private String _iJangbiCode;
        private String _iResultYn;
        private String _iUitakCode;
        private String _iJangbiOutCode;
        private String _iChubangYn;
        private String _iDisplayYn;
        private String _iDataRowState;

        public String IUserId
        {
            get { return this._iUserId; }
            set { this._iUserId = value; }
        }

        public String IGroupGubun
        {
            get { return this._iGroupGubun; }
            set { this._iGroupGubun = value; }
        }

        public String IParentCode
        {
            get { return this._iParentCode; }
            set { this._iParentCode = value; }
        }

        public String IHangmogCode
        {
            get { return this._iHangmogCode; }
            set { this._iHangmogCode = value; }
        }

        public String ISerial
        {
            get { return this._iSerial; }
            set { this._iSerial = value; }
        }

        public String IGumsaNameRe
        {
            get { return this._iGumsaNameRe; }
            set { this._iGumsaNameRe = value; }
        }

        public String IGumsaName
        {
            get { return this._iGumsaName; }
            set { this._iGumsaName = value; }
        }

        public String ISlipCode
        {
            get { return this._iSlipCode; }
            set { this._iSlipCode = value; }
        }

        public String ISlipName
        {
            get { return this._iSlipName; }
            set { this._iSlipName = value; }
        }

        public String IJundalGubun
        {
            get { return this._iJundalGubun; }
            set { this._iJundalGubun = value; }
        }

        public String IJundalGubunName
        {
            get { return this._iJundalGubunName; }
            set { this._iJundalGubunName = value; }
        }

        public String ITubeName
        {
            get { return this._iTubeName; }
            set { this._iTubeName = value; }
        }

        public String IKeepMeansName
        {
            get { return this._iKeepMeansName; }
            set { this._iKeepMeansName = value; }
        }

        public String ISpecimenCode
        {
            get { return this._iSpecimenCode; }
            set { this._iSpecimenCode = value; }
        }

        public String ISpecimenName
        {
            get { return this._iSpecimenName; }
            set { this._iSpecimenName = value; }
        }

        public String IDanui
        {
            get { return this._iDanui; }
            set { this._iDanui = value; }
        }

        public String IMenFromStandard
        {
            get { return this._iMenFromStandard; }
            set { this._iMenFromStandard = value; }
        }

        public String IMenToStandard
        {
            get { return this._iMenToStandard; }
            set { this._iMenToStandard = value; }
        }

        public String IWomenFromStandard
        {
            get { return this._iWomenFromStandard; }
            set { this._iWomenFromStandard = value; }
        }

        public String IWomenToStandard
        {
            get { return this._iWomenToStandard; }
            set { this._iWomenToStandard = value; }
        }

        public String ISgCode1
        {
            get { return this._iSgCode1; }
            set { this._iSgCode1 = value; }
        }

        public String ISgCode2
        {
            get { return this._iSgCode2; }
            set { this._iSgCode2 = value; }
        }

        public String ISpecimenAmt
        {
            get { return this._iSpecimenAmt; }
            set { this._iSpecimenAmt = value; }
        }

        public String IDetailInfo
        {
            get { return this._iDetailInfo; }
            set { this._iDetailInfo = value; }
        }

        public String IJukyongDate
        {
            get { return this._iJukyongDate; }
            set { this._iJukyongDate = value; }
        }

        public String IEmergency
        {
            get { return this._iEmergency; }
            set { this._iEmergency = value; }
        }

        public String IJangbiCode
        {
            get { return this._iJangbiCode; }
            set { this._iJangbiCode = value; }
        }

        public String IResultYn
        {
            get { return this._iResultYn; }
            set { this._iResultYn = value; }
        }

        public String IUitakCode
        {
            get { return this._iUitakCode; }
            set { this._iUitakCode = value; }
        }

        public String IJangbiOutCode
        {
            get { return this._iJangbiOutCode; }
            set { this._iJangbiOutCode = value; }
        }

        public String IChubangYn
        {
            get { return this._iChubangYn; }
            set { this._iChubangYn = value; }
        }

        public String IDisplayYn
        {
            get { return this._iDisplayYn; }
            set { this._iDisplayYn = value; }
        }

        public String IDataRowState
        {
            get { return this._iDataRowState; }
            set { this._iDataRowState = value; }
        }

        public CPLBMLUPLOADERExcelInsertInfo() { }

        public CPLBMLUPLOADERExcelInsertInfo(String iUserId, String iGroupGubun, String iParentCode, String iHangmogCode, String iSerial, String iGumsaNameRe, String iGumsaName, String iSlipCode, String iSlipName, String iJundalGubun, String iJundalGubunName, String iTubeName, String iKeepMeansName, String iSpecimenCode, String iSpecimenName, String iDanui, String iMenFromStandard, String iMenToStandard, String iWomenFromStandard, String iWomenToStandard, String iSgCode1, String iSgCode2, String iSpecimenAmt, String iDetailInfo, String iJukyongDate, String iEmergency, String iJangbiCode, String iResultYn, String iUitakCode, String iJangbiOutCode, String iChubangYn, String iDisplayYn, String iDataRowState)
        {
            this._iUserId = iUserId;
            this._iGroupGubun = iGroupGubun;
            this._iParentCode = iParentCode;
            this._iHangmogCode = iHangmogCode;
            this._iSerial = iSerial;
            this._iGumsaNameRe = iGumsaNameRe;
            this._iGumsaName = iGumsaName;
            this._iSlipCode = iSlipCode;
            this._iSlipName = iSlipName;
            this._iJundalGubun = iJundalGubun;
            this._iJundalGubunName = iJundalGubunName;
            this._iTubeName = iTubeName;
            this._iKeepMeansName = iKeepMeansName;
            this._iSpecimenCode = iSpecimenCode;
            this._iSpecimenName = iSpecimenName;
            this._iDanui = iDanui;
            this._iMenFromStandard = iMenFromStandard;
            this._iMenToStandard = iMenToStandard;
            this._iWomenFromStandard = iWomenFromStandard;
            this._iWomenToStandard = iWomenToStandard;
            this._iSgCode1 = iSgCode1;
            this._iSgCode2 = iSgCode2;
            this._iSpecimenAmt = iSpecimenAmt;
            this._iDetailInfo = iDetailInfo;
            this._iJukyongDate = iJukyongDate;
            this._iEmergency = iEmergency;
            this._iJangbiCode = iJangbiCode;
            this._iResultYn = iResultYn;
            this._iUitakCode = iUitakCode;
            this._iJangbiOutCode = iJangbiOutCode;
            this._iChubangYn = iChubangYn;
            this._iDisplayYn = iDisplayYn;
            this._iDataRowState = iDataRowState;
        }

    }
}