using System;

namespace IHIS.CloudConnector.Contracts.Models.Orca
{
    [Serializable]
    public class ORCATransferOrdersClaimOrdersFeeInfo
    {
        private String _docUid;
        private String _confirmDate;
        private String _performTime;
        private String _bundleNumber;
        private String _hangmogCode;
        private String _doctorId;
        private String _gwa;
        private String _numb;
        private String _numberCode;
        private String _clsCode;
        private String _gwaName;
        private String _actingDate;

        public String DocUid
        {
            get { return this._docUid; }
            set { this._docUid = value; }
        }

        public String ConfirmDate
        {
            get { return this._confirmDate; }
            set { this._confirmDate = value; }
        }

        public String PerformTime
        {
            get { return this._performTime; }
            set { this._performTime = value; }
        }

        public String BundleNumber
        {
            get { return this._bundleNumber; }
            set { this._bundleNumber = value; }
        }

        public String HangmogCode
        {
            get { return this._hangmogCode; }
            set { this._hangmogCode = value; }
        }

        public String DoctorId
        {
            get { return this._doctorId; }
            set { this._doctorId = value; }
        }

        public String Gwa
        {
            get { return this._gwa; }
            set { this._gwa = value; }
        }

        public String Numb
        {
            get { return this._numb; }
            set { this._numb = value; }
        }

        public String NumberCode
        {
            get { return this._numberCode; }
            set { this._numberCode = value; }
        }

        public String ClsCode
        {
            get { return this._clsCode; }
            set { this._clsCode = value; }
        }

        public String GwaName
        {
            get { return this._gwaName; }
            set { this._gwaName = value; }
        }

        public String ActingDate
        {
            get { return this._actingDate; }
            set { this._actingDate = value; }
        }

        public ORCATransferOrdersClaimOrdersFeeInfo() { }

        public ORCATransferOrdersClaimOrdersFeeInfo(String docUid, String confirmDate, String performTime, String bundleNumber, String hangmogCode, String doctorId, String gwa, String numb, String numberCode, String clsCode, String gwaName, String actingDate)
        {
            this._docUid = docUid;
            this._confirmDate = confirmDate;
            this._performTime = performTime;
            this._bundleNumber = bundleNumber;
            this._hangmogCode = hangmogCode;
            this._doctorId = doctorId;
            this._gwa = gwa;
            this._numb = numb;
            this._numberCode = numberCode;
            this._clsCode = clsCode;
            this._gwaName = gwaName;
            this._actingDate = actingDate;
        }

    }
}