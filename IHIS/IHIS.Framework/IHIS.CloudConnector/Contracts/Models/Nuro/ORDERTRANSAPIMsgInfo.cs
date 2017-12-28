using System;

namespace IHIS.CloudConnector.Contracts.Models.Nuro
{
    public class ORDERTRANSAPIMsgInfo
    {
        private String _errCode;
        private String _apiResult;
        private String _medicalResult;
        private String _diseaseResult;

        public String ErrCode
        {
            get { return this._errCode; }
            set { this._errCode = value; }
        }

        public String ApiResult
        {
            get { return this._apiResult; }
            set { this._apiResult = value; }
        }

        public String MedicalResult
        {
            get { return this._medicalResult; }
            set { this._medicalResult = value; }
        }

        public String DiseaseResult
        {
            get { return this._diseaseResult; }
            set { this._diseaseResult = value; }
        }

        public ORDERTRANSAPIMsgInfo() { }

        public ORDERTRANSAPIMsgInfo(String errCode, String apiResult, String medicalResult, String diseaseResult)
        {
            this._errCode = errCode;
            this._apiResult = apiResult;
            this._medicalResult = medicalResult;
            this._diseaseResult = diseaseResult;
        }

    }
}