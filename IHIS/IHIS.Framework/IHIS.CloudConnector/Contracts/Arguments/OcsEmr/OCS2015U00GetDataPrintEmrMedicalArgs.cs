using System;
using IHIS.CloudConnector.Contracts.Models.OcsEmr;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.OcsEmr
{
    public class OCS2015U00GetDataPrintEmrMedicalArgs : IContractArgs
    {
        private String _bunho;
        private String _doctor;
        private String _firstExaminationDate;
        private String _lastExaminationDate;

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public String Doctor
        {
            get { return this._doctor; }
            set { this._doctor = value; }
        }

        public String FirstExaminationDate
        {
            get { return this._firstExaminationDate; }
            set { this._firstExaminationDate = value; }
        }

        public String LastExaminationDate
        {
            get { return this._lastExaminationDate; }
            set { this._lastExaminationDate = value; }
        }

        public OCS2015U00GetDataPrintEmrMedicalArgs() { }

        public OCS2015U00GetDataPrintEmrMedicalArgs(String bunho, String doctor, String firstExaminationDate, String lastExaminationDate)
        {
            this._bunho = bunho;
            this._doctor = doctor;
            this._firstExaminationDate = firstExaminationDate;
            this._lastExaminationDate = lastExaminationDate;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCS2015U00GetDataPrintEmrMedicalRequest();
        }
    }
}