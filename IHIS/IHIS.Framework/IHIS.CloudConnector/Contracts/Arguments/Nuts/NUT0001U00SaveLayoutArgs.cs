using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;
using NUT0001U00GrdNUT0001ItemInfo = IHIS.CloudConnector.Contracts.Models.Nuts.NUT0001U00GrdNUT0001ItemInfo;
using NUT0001U00GrdNUT0002ItemInfo = IHIS.CloudConnector.Contracts.Models.Nuts.NUT0001U00GrdNUT0002ItemInfo;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuts
{
    [Serializable]
	public class NUT0001U00SaveLayoutArgs : IContractArgs
	{
        protected bool Equals(NUT0001U00SaveLayoutArgs other)
        {
            return Equals(_grd001ItemInfo, other._grd001ItemInfo) && Equals(_grd002ItemInfo, other._grd002ItemInfo);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NUT0001U00SaveLayoutArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_grd001ItemInfo != null ? _grd001ItemInfo.GetHashCode() : 0)*397) ^ (_grd002ItemInfo != null ? _grd002ItemInfo.GetHashCode() : 0);
            }
        }

        private List<NUT0001U00GrdNUT0001ItemInfo> _grd001ItemInfo = new List<NUT0001U00GrdNUT0001ItemInfo>();
		private List<NUT0001U00GrdNUT0002ItemInfo> _grd002ItemInfo = new List<NUT0001U00GrdNUT0002ItemInfo>();

		public List<NUT0001U00GrdNUT0001ItemInfo> Grd001ItemInfo
		{
			get { return this._grd001ItemInfo; }
			set { this._grd001ItemInfo = value; }
		}

		public List<NUT0001U00GrdNUT0002ItemInfo> Grd002ItemInfo
		{
			get { return this._grd002ItemInfo; }
			set { this._grd002ItemInfo = value; }
		}

		public NUT0001U00SaveLayoutArgs() { }

		public NUT0001U00SaveLayoutArgs(List<NUT0001U00GrdNUT0001ItemInfo> grd001ItemInfo, List<NUT0001U00GrdNUT0002ItemInfo> grd002ItemInfo)
		{
			this._grd001ItemInfo = grd001ItemInfo;
			this._grd002ItemInfo = grd002ItemInfo;
		}

		public IExtensible GetRequestInstance()
		{
			return new NUT0001U00SaveLayoutRequest();
		}
	}
}