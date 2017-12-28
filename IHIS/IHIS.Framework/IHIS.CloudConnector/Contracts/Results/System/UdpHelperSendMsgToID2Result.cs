using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Ocs.Lib;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Results.Ocs.Lib
{
    [Serializable]
	public class UdpHelperSendMsgToID2Result : AbstractContractResult
	{
		private List<UdpHelperSendInfo> _sendInfo = new List<UdpHelperSendInfo>();

		public List<UdpHelperSendInfo> SendInfo
		{
			get { return this._sendInfo; }
			set { this._sendInfo = value; }
		}

		public UdpHelperSendMsgToID2Result() { }

	}
}