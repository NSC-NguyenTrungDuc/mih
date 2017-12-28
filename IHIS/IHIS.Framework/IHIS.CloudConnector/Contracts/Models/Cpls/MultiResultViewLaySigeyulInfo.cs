using System;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Models.Cpls
{
    [Serializable]
	public class MultiResultViewLaySigeyulInfo
	{
		private String _gumsaName;
		private List<MultiResultViewDataForLaySigeyulInfo> _dataInfo = new List<MultiResultViewDataForLaySigeyulInfo>();

		public String GumsaName
		{
			get { return this._gumsaName; }
			set { this._gumsaName = value; }
		}

		public List<MultiResultViewDataForLaySigeyulInfo> DataInfo
		{
			get { return this._dataInfo; }
			set { this._dataInfo = value; }
		}

		public MultiResultViewLaySigeyulInfo() { }

		public MultiResultViewLaySigeyulInfo(String gumsaName, List<MultiResultViewDataForLaySigeyulInfo> dataInfo)
		{
			this._gumsaName = gumsaName;
			this._dataInfo = dataInfo;
		}

	}
}