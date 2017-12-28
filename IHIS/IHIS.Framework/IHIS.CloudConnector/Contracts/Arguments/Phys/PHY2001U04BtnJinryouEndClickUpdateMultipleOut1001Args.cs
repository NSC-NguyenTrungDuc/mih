using System;
using IHIS.CloudConnector.Contracts.Models.Phys;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Phys
{[Serializable]
    public class PHY2001U04BtnJinryouEndClickUpdateMultipleOut1001Args : IContractArgs
    {
    protected bool Equals(PHY2001U04BtnJinryouEndClickUpdateMultipleOut1001Args other)
    {
        return Equals(_pkout1001LstItem, other._pkout1001LstItem);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((PHY2001U04BtnJinryouEndClickUpdateMultipleOut1001Args) obj);
    }

    public override int GetHashCode()
    {
        return (_pkout1001LstItem != null ? _pkout1001LstItem.GetHashCode() : 0);
    }

    private List<PHY2001U04BtnJinryouEndClickUpdateMultipleOut1001Info> _pkout1001LstItem = new List<PHY2001U04BtnJinryouEndClickUpdateMultipleOut1001Info>();

        public List<PHY2001U04BtnJinryouEndClickUpdateMultipleOut1001Info> Pkout1001LstItem
        {
            get { return this._pkout1001LstItem; }
            set { this._pkout1001LstItem = value; }
        }

        public PHY2001U04BtnJinryouEndClickUpdateMultipleOut1001Args() { }

        public PHY2001U04BtnJinryouEndClickUpdateMultipleOut1001Args(List<PHY2001U04BtnJinryouEndClickUpdateMultipleOut1001Info> pkout1001LstItem)
        {
            this._pkout1001LstItem = pkout1001LstItem;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.PHY2001U04BtnJinryouEndClickUpdateMultipleOut1001Request();
        }
    }
}