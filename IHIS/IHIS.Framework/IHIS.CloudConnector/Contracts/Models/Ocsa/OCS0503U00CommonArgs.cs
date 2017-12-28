using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{
    [Serializable]
	public class OCS0503U00CommonArgs : IContractArgs
	{
		private String _naewonKey;
		private String _reserDate;
		private String _reserTime;
		private String _reserDoctor;

		public String NaewonKey
		{
			get { return this._naewonKey; }
			set { this._naewonKey = value; }
		}

		public String ReserDate
		{
			get { return this._reserDate; }
			set { this._reserDate = value; }
		}

		public String ReserTime
		{
			get { return this._reserTime; }
			set { this._reserTime = value; }
		}

		public String ReserDoctor
		{
			get { return this._reserDoctor; }
			set { this._reserDoctor = value; }
		}

		public OCS0503U00CommonArgs() { }

		public OCS0503U00CommonArgs(String naewonKey, String reserDate, String reserTime, String reserDoctor)
		{
			this._naewonKey = naewonKey;
			this._reserDate = reserDate;
			this._reserTime = reserTime;
			this._reserDoctor = reserDoctor;
		}

		public IExtensible GetRequestInstance()
		{
			return new OCS0503U00CommonRequest();
		}
	}
}