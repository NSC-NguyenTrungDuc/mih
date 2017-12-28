using System;
using IHIS.CloudConnector.Contracts.Models.OcsEmr;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.OcsEmr
{
    public class OCS2015U00GetDataPrescriptionArgs : IContractArgs
    {
        private String _bunho;
        private String _pkout;
        private String _jubsuDate;

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public String Pkout
        {
            get { return this._pkout; }
            set { this._pkout = value; }
        }

        public String JubsuDate
        {
            get { return this._jubsuDate; }
            set { this._jubsuDate = value; }
        }

        public OCS2015U00GetDataPrescriptionArgs() { }

        public OCS2015U00GetDataPrescriptionArgs(String bunho, String pkout, String jubsuDate)
        {
            this._bunho = bunho;
            this._pkout = pkout;
            this._jubsuDate = jubsuDate;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCS2015U00GetDataPrescriptionRequest();
        }
    }
}