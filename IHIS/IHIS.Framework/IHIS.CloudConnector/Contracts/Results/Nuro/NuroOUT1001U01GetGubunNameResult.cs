using System;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
    public class NuroOUT1001U01GetGubunNameResult : AbstractContractResult
    {
        private String _valueGubunName;

        public String ValueGubunName
        {
            get { return this._valueGubunName; }
            set { this._valueGubunName = value; }
        }

        public NuroOUT1001U01GetGubunNameResult() { }

    }
}