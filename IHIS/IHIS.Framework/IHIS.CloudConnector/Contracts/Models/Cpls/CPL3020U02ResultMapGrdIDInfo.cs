using System;

namespace IHIS.CloudConnector.Contracts.Models.Cpls
{
    [Serializable]
    public class CPL3020U02ResultMapGrdIDInfo
    {
        private String _resultDate;
        private String _procTime;
        private String _sampleId;
        private String _specimenSer;
        private String _patientId;

        public String ResultDate
        {
            get { return this._resultDate; }
            set { this._resultDate = value; }
        }

        public String ProcTime
        {
            get { return this._procTime; }
            set { this._procTime = value; }
        }

        public String SampleId
        {
            get { return this._sampleId; }
            set { this._sampleId = value; }
        }

        public String SpecimenSer
        {
            get { return this._specimenSer; }
            set { this._specimenSer = value; }
        }

        public String PatientId
        {
            get { return this._patientId; }
            set { this._patientId = value; }
        }

        public CPL3020U02ResultMapGrdIDInfo() { }

        public CPL3020U02ResultMapGrdIDInfo(String resultDate, String procTime, String sampleId, String specimenSer, String patientId)
        {
            this._resultDate = resultDate;
            this._procTime = procTime;
            this._sampleId = sampleId;
            this._specimenSer = specimenSer;
            this._patientId = patientId;
        }

    }
}