using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;
using PHY0001U00GrdOCS0132Info = IHIS.CloudConnector.Contracts.Models.Phys.PHY0001U00GrdOCS0132Info;
using PHY0001U00GrdRehaSinryouryouCodeInfo = IHIS.CloudConnector.Contracts.Models.Phys.PHY0001U00GrdRehaSinryouryouCodeInfo;

namespace IHIS.CloudConnector.Contracts.Arguments.Phys
{[Serializable]
    public class PHY0001U00SaveLayoutArgs : IContractArgs
    {
    protected bool Equals(PHY0001U00SaveLayoutArgs other)
    {
        return Equals(_grdRehaInfo, other._grdRehaInfo) && Equals(_grdOcsInfo, other._grdOcsInfo);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((PHY0001U00SaveLayoutArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return ((_grdRehaInfo != null ? _grdRehaInfo.GetHashCode() : 0)*397) ^ (_grdOcsInfo != null ? _grdOcsInfo.GetHashCode() : 0);
        }
    }

    private List<PHY0001U00GrdRehaSinryouryouCodeInfo> _grdRehaInfo = new List<PHY0001U00GrdRehaSinryouryouCodeInfo>();
        private List<PHY0001U00GrdOCS0132Info> _grdOcsInfo = new List<PHY0001U00GrdOCS0132Info>();

        public List<PHY0001U00GrdRehaSinryouryouCodeInfo> GrdRehaInfo
        {
            get { return this._grdRehaInfo; }
            set { this._grdRehaInfo = value; }
        }

        public List<PHY0001U00GrdOCS0132Info> GrdOcsInfo
        {
            get { return this._grdOcsInfo; }
            set { this._grdOcsInfo = value; }
        }

        public PHY0001U00SaveLayoutArgs() { }

        public PHY0001U00SaveLayoutArgs(List<PHY0001U00GrdRehaSinryouryouCodeInfo> grdRehaInfo, List<PHY0001U00GrdOCS0132Info> grdOcsInfo)
        {
            this._grdRehaInfo = grdRehaInfo;
            this._grdOcsInfo = grdOcsInfo;
        }

        public IExtensible GetRequestInstance()
        {
            return new PHY0001U00SaveLayoutRequest();
        }
    }
}