using System;
using IHIS.CloudConnector.Contracts.Models.Phys;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Phys
{
    [Serializable]
    public class PHY2001U04SetSinryouryouAutoResult : AbstractContractResult
    {
        private String _obj1;
        private String _obj2;

        public String Obj1
        {
            get { return this._obj1; }
            set { this._obj1 = value; }
        }

        public String Obj2
        {
            get { return this._obj2; }
            set { this._obj2 = value; }
        }

        public PHY2001U04SetSinryouryouAutoResult() { }

    }
}