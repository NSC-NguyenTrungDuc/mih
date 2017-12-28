using System;
using IHIS.CloudConnector.Contracts.Models.Drgs;
using System.Collections.Generic;
using ProtoBuf;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Arguments.Drgs
{
    public class DRG5100P01GetDiseaseArgs : IContractArgs
    {
        private String _gwa;
        private String _bunho;
        private String _hospCode;
        private List<DataStringListItemInfo> _naewonDate = new List<DataStringListItemInfo>();

        public String Gwa
        {
            get { return this._gwa; }
            set { this._gwa = value; }
        }

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public List<DataStringListItemInfo> NaewonDate
        {
            get { return this._naewonDate; }
            set { this._naewonDate = value; }
        }

        public DRG5100P01GetDiseaseArgs() { }

        public DRG5100P01GetDiseaseArgs(String gwa, String bunho, String hospCode, List<DataStringListItemInfo> naewonDate)
        {
            this._gwa = gwa;
            this._bunho = bunho;
            this._hospCode = hospCode;
            this._naewonDate = naewonDate;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.DRG5100P01GetDiseaseRequest();
        }
    }
}