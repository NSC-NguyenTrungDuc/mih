using System;
using IHIS.CloudConnector.Contracts.Models.Clis;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Clis
{
    [Serializable]
    public class CLIS2015U02SaveLayoutArgs : IContractArgs
    {
        protected bool Equals(CLIS2015U02SaveLayoutArgs other)
        {
            return Equals(_grdProtocolList, other._grdProtocolList) && Equals(_grdStatusList, other._grdStatusList);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CLIS2015U02SaveLayoutArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_grdProtocolList != null ? _grdProtocolList.GetHashCode() : 0)*397) ^ (_grdStatusList != null ? _grdStatusList.GetHashCode() : 0);
            }
        }

        private CLIS2015U02GrdProtocolInfo _grdProtocolList;
        private List<CLIS2015U02GrdStatusInfo> _grdStatusList = new List<CLIS2015U02GrdStatusInfo>();

        public CLIS2015U02GrdProtocolInfo GrdProtocolList
        {
            get { return this._grdProtocolList; }
            set { this._grdProtocolList = value; }
        }

        public List<CLIS2015U02GrdStatusInfo> GrdStatusList
        {
            get { return this._grdStatusList; }
            set { this._grdStatusList = value; }
        }

        public CLIS2015U02SaveLayoutArgs() { }

        public CLIS2015U02SaveLayoutArgs(CLIS2015U02GrdProtocolInfo grdProtocolList, List<CLIS2015U02GrdStatusInfo> grdStatusList)
        {
            this._grdProtocolList = grdProtocolList;
            this._grdStatusList = grdStatusList;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.CLIS2015U02SaveLayoutRequest();
        }
    }
}