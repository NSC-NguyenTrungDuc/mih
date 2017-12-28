using System;

namespace IHIS.CloudConnector.Contracts.Models.Orca
{
    [Serializable]
    public class ORCATransferOrdersClaimExaminationFeeInfo
    {
        private Boolean _ioFlag;
        private String _clsTime;
        private String _bundleNumber;
        private String _clsCode;
        private String _subClsCode;
        private String _hangmogCode;

        public Boolean IoFlag
        {
            get { return this._ioFlag; }
            set { this._ioFlag = value; }
        }

        public String ClsTime
        {
            get { return this._clsTime; }
            set { this._clsTime = value; }
        }

        public String BundleNumber
        {
            get { return this._bundleNumber; }
            set { this._bundleNumber = value; }
        }

        public String ClsCode
        {
            get { return this._clsCode; }
            set { this._clsCode = value; }
        }

        public String SubClsCode
        {
            get { return this._subClsCode; }
            set { this._subClsCode = value; }
        }

        public String HangmogCode
        {
            get { return this._hangmogCode; }
            set { this._hangmogCode = value; }
        }

        public ORCATransferOrdersClaimExaminationFeeInfo() { }

        public ORCATransferOrdersClaimExaminationFeeInfo(Boolean ioFlag, String clsTime, String bundleNumber, String clsCode, String subClsCode, String hangmogCode)
        {
            this._ioFlag = ioFlag;
            this._clsTime = clsTime;
            this._bundleNumber = bundleNumber;
            this._clsCode = clsCode;
            this._subClsCode = subClsCode;
            this._hangmogCode = hangmogCode;
        }

    }
}