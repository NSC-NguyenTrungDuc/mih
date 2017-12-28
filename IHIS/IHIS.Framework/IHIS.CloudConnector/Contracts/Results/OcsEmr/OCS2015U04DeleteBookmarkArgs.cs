using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.OcsEmr
{
    [Serializable]
	public class OCS2015U04DeleteBookmarkArgs : IContractArgs
	{
		private String _emrBookmarkId;

		public String EmrBookmarkId
		{
			get { return this._emrBookmarkId; }
			set { this._emrBookmarkId = value; }
		}

		public OCS2015U04DeleteBookmarkArgs() { }

		public OCS2015U04DeleteBookmarkArgs(String emrBookmarkId)
		{
			this._emrBookmarkId = emrBookmarkId;
		}

		public IExtensible GetRequestInstance()
		{
			return new OCS2015U04DeleteBookmarkRequest();
		}
	}
}