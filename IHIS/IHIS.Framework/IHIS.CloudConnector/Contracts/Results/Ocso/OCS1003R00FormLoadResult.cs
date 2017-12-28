using System;
using IHIS.CloudConnector.Contracts.Models.Ocso;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Ocso
{
    [Serializable]
    public class OCS1003R00FormLoadResult : AbstractContractResult
    {
        private List<OCS1003R00LayOCS1001Info> _ocs1001Item = new List<OCS1003R00LayOCS1001Info>();
        private List<OCS1003R00LayOCS1003Info> _ocs1003Item = new List<OCS1003R00LayOCS1003Info>();
        private List<OCS1003R00LayOUT1001Info> _out1001Item = new List<OCS1003R00LayOUT1001Info>();

        public List<OCS1003R00LayOCS1001Info> Ocs1001Item
        {
            get { return this._ocs1001Item; }
            set { this._ocs1001Item = value; }
        }

        public List<OCS1003R00LayOCS1003Info> Ocs1003Item
        {
            get { return this._ocs1003Item; }
            set { this._ocs1003Item = value; }
        }

        public List<OCS1003R00LayOUT1001Info> Out1001Item
        {
            get { return this._out1001Item; }
            set { this._out1001Item = value; }
        }

        public OCS1003R00FormLoadResult() { }

    }
}