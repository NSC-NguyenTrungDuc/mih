using System;
using IHIS.CloudConnector.Contracts.Models.Ocso;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocso
{
    public class OCSACT2GetPatientListINJArgs : IContractArgs
    {
        private String _actingFlag;
        private String _reserDate;
        private String _gwa;

        public String ActingFlag
        {
            get { return this._actingFlag; }
            set { this._actingFlag = value; }
        }

        public String ReserDate
        {
            get { return this._reserDate; }
            set { this._reserDate = value; }
        }

        public String Gwa
        {
            get { return this._gwa; }
            set { this._gwa = value; }
        }

        public OCSACT2GetPatientListINJArgs() { }

        public OCSACT2GetPatientListINJArgs(String actingFlag, String reserDate, String gwa)
        {
            this._actingFlag = actingFlag;
            this._reserDate = reserDate;
            this._gwa = gwa;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCSACT2GetPatientListINJRequest();
        }
    }
}