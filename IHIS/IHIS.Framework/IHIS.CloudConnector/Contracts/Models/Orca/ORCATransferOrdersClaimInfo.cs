using System;

namespace IHIS.CloudConnector.Contracts.Models.Orca
{
    [Serializable]
    public class ORCATransferOrdersClaimInfo
    {
        private String _docUid03;
        private String _confirmDate03;
        private String _performTime;
        private String _bundleNumber;
        private String _hangmogCode;
        private String _doctorId;
        private String _gwa;
        private String _gwaName;
        private String _sgCode;

        public String DocUid03
        {
            get { return this._docUid03; }
            set { this._docUid03 = value; }
        }

        public String ConfirmDate03
        {
            get { return this._confirmDate03; }
            set { this._confirmDate03 = value; }
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

        public String GwaName
        {
            get { return this._gwaName; }
            set { this._gwaName = value; }
        }

        public String SgCode
        {
            get { return this._sgCode; }
            set { this._sgCode = value; }
        }

        public ORCATransferOrdersClaimInfo() { }

        public ORCATransferOrdersClaimInfo(String docUid03, String confirmDate03, String performTime, String bundleNumber, String hangmogCode, String doctorId, String gwa, String gwaName, String sgCode)
        {
            this._docUid03 = docUid03;
            this._confirmDate03 = confirmDate03;
            this._performTime = performTime;
            this._bundleNumber = bundleNumber;
            this._hangmogCode = hangmogCode;
            this._doctorId = doctorId;
            this._gwa = gwa;
            this._gwaName = gwaName;
            this._sgCode = sgCode;
        }

    }
}