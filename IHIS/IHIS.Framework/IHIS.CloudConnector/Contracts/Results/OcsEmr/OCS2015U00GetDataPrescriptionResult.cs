using System;
using IHIS.CloudConnector.Contracts.Models.OcsEmr;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Drgs;
using IHIS.CloudConnector.Contracts.Models.Nuro;

namespace IHIS.CloudConnector.Contracts.Results.OcsEmr
{
    public class OCS2015U00GetDataPrescriptionResult : AbstractContractResult
    {
        private List<OCS2015U00GetDataPrescriptionInfo> _dataPrescription = new List<OCS2015U00GetDataPrescriptionInfo>();
        private List<OCS2015U00GetDataDosageInfo> _lstDosage = new List<OCS2015U00GetDataDosageInfo>();
        private DrgsDRG5100P01LoadChebangPrintInfo _chebangPrintItem;
        private List<DrgsDRG5100P01DrgwonneaOWnCurListInfo> _drgwonneaOwnCur = new List<DrgsDRG5100P01DrgwonneaOWnCurListInfo>();
        private List<DrgsDRG5100P01WnSerialQryListItemInfo> _wnSerialItem = new List<DrgsDRG5100P01WnSerialQryListItemInfo>();
        private String _gigamDate;
        private String _boyongCode;
        private List<NuroManagePatientInfo> _patientInfo = new List<NuroManagePatientInfo>();
        private List<OCS2015U00GetDataInsPersonInfo> _insPersionInfoFirst = new List<OCS2015U00GetDataInsPersonInfo>();
        private List<OCS2015U00GetDataInsPersonInfo> _insPersionInfoSecond = new List<OCS2015U00GetDataInsPersonInfo>();
        private List<OCS2015U00InsProviderInfo> _insProviderInfo = new List<OCS2015U00InsProviderInfo>();
        private String _hospName;
        private String _jaedanName;
        private String _hospAddress1;
        private String _tell;
        private String _hospAddress;

        public List<OCS2015U00GetDataPrescriptionInfo> DataPrescription
        {
            get { return this._dataPrescription; }
            set { this._dataPrescription = value; }
        }

        public List<OCS2015U00GetDataDosageInfo> LstDosage
        {
            get { return this._lstDosage; }
            set { this._lstDosage = value; }
        }

        public DrgsDRG5100P01LoadChebangPrintInfo ChebangPrintItem
        {
            get { return this._chebangPrintItem; }
            set { this._chebangPrintItem = value; }
        }

        public List<DrgsDRG5100P01DrgwonneaOWnCurListInfo> DrgwonneaOwnCur
        {
            get { return this._drgwonneaOwnCur; }
            set { this._drgwonneaOwnCur = value; }
        }

        public List<DrgsDRG5100P01WnSerialQryListItemInfo> WnSerialItem
        {
            get { return this._wnSerialItem; }
            set { this._wnSerialItem = value; }
        }

        public String GigamDate
        {
            get { return this._gigamDate; }
            set { this._gigamDate = value; }
        }

        public String BoyongCode
        {
            get { return this._boyongCode; }
            set { this._boyongCode = value; }
        }

        public List<NuroManagePatientInfo> PatientInfo
        {
            get { return this._patientInfo; }
            set { this._patientInfo = value; }
        }

        public List<OCS2015U00GetDataInsPersonInfo> InsPersionInfoFirst
        {
            get { return this._insPersionInfoFirst; }
            set { this._insPersionInfoFirst = value; }
        }

        public List<OCS2015U00GetDataInsPersonInfo> InsPersionInfoSecond
        {
            get { return this._insPersionInfoSecond; }
            set { this._insPersionInfoSecond = value; }
        }

        public List<OCS2015U00InsProviderInfo> InsProviderInfo
        {
            get { return this._insProviderInfo; }
            set { this._insProviderInfo = value; }
        }

        public String HospName
        {
            get { return this._hospName; }
            set { this._hospName = value; }
        }

        public String JaedanName
        {
            get { return this._jaedanName; }
            set { this._jaedanName = value; }
        }

        public String HospAddress1
        {
            get { return this._hospAddress1; }
            set { this._hospAddress1 = value; }
        }

        public String Tell
        {
            get { return this._tell; }
            set { this._tell = value; }
        }

        public String HospAddress
        {
            get { return this._hospAddress; }
            set { this._hospAddress = value; }
        }

        public OCS2015U00GetDataPrescriptionResult() { }

    }
}