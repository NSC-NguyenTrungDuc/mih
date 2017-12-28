using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;
using NaewonYNInfo1 = IHIS.CloudConnector.Contracts.Models.Ocs.Lib.NaewonYNInfo1;
using NotApproveOrderCntInfo = IHIS.CloudConnector.Contracts.Models.Ocs.Lib.NotApproveOrderCntInfo;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocso
{[Serializable]
	public class OCS1003P01SettingVisibleByUserArgs : IContractArgs
	{
    protected bool Equals(OCS1003P01SettingVisibleByUserArgs other)
    {
        return Equals(_naewonParam, other._naewonParam) && Equals(_countParam, other._countParam);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS1003P01SettingVisibleByUserArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return ((_naewonParam != null ? _naewonParam.GetHashCode() : 0)*397) ^ (_countParam != null ? _countParam.GetHashCode() : 0);
        }
    }

    private NaewonYNInfo1 _naewonParam;
		private NotApproveOrderCntInfo _countParam;

		public NaewonYNInfo1 NaewonParam
		{
			get { return this._naewonParam; }
			set { this._naewonParam = value; }
		}

		public NotApproveOrderCntInfo CountParam
		{
			get { return this._countParam; }
			set { this._countParam = value; }
		}

		public OCS1003P01SettingVisibleByUserArgs() { }

		public OCS1003P01SettingVisibleByUserArgs(NaewonYNInfo1 naewonParam, NotApproveOrderCntInfo countParam)
		{
			this._naewonParam = naewonParam;
			this._countParam = countParam;
		}

		public IExtensible GetRequestInstance()
		{
			return new OCS1003P01SettingVisibleByUserRequest();
		}
	}
}