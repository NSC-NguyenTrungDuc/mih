using System;
using IHIS.CloudConnector.Contracts.Models.Invs;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Invs
{
    public class INV2003U00SaveLayoutArgs : IContractArgs
    {
        private List<INV2003U00GrdINV2003Info> _info2003 = new List<INV2003U00GrdINV2003Info>();
        private List<INV2003U00GrdINV2004Info> _info2004 = new List<INV2003U00GrdINV2004Info>();

        public List<INV2003U00GrdINV2003Info> Info2003
        {
            get { return this._info2003; }
            set { this._info2003 = value; }
        }

        public List<INV2003U00GrdINV2004Info> Info2004
        {
            get { return this._info2004; }
            set { this._info2004 = value; }
        }

        public INV2003U00SaveLayoutArgs() { }

        public INV2003U00SaveLayoutArgs(List<INV2003U00GrdINV2003Info> info2003, List<INV2003U00GrdINV2004Info> info2004)
        {
            this._info2003 = info2003;
            this._info2004 = info2004;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.INV2003U00SaveLayoutRequest();
        }
    }
}