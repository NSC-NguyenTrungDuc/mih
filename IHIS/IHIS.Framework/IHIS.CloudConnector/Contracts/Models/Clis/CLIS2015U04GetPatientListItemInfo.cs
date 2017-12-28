using System;

namespace IHIS.CloudConnector.Contracts.Models.Clis
{
    [Serializable]
    public class CLIS2015U04GetPatientListItemInfo
    {
        private String _protocolPatientId;
        private String _bunho;
        private String _suname;
        private String _suname2;

        public String ProtocolPatientId
        {
            get { return this._protocolPatientId; }
            set { this._protocolPatientId = value; }
        }

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public String Suname
        {
            get { return this._suname; }
            set { this._suname = value; }
        }

        public String Suname2
        {
            get { return this._suname2; }
            set { this._suname2 = value; }
        }

        public CLIS2015U04GetPatientListItemInfo() { }

        public CLIS2015U04GetPatientListItemInfo(String protocolPatientId, String bunho, String suname, String suname2)
        {
            this._protocolPatientId = protocolPatientId;
            this._bunho = bunho;
            this._suname = suname;
            this._suname2 = suname2;
        }

    }
}