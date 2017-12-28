using System;
using System.Collections.Generic;
using System.Text;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
    public class NuroProcOcsoDoctorChange2Result : AbstractContractResult
    {
        private String _flag;

        public String Flag
        {
            get { return this._flag; }
            set { this._flag = value; }
        }

        public NuroProcOcsoDoctorChange2Result() { }

    }
}
