using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Phys;

namespace IHIS.CloudConnector.Contracts.Results.Phys
{
    [Serializable]
	public class PHY0001U00GrdRehaSinryouryouCodeResult : AbstractContractResult
	{
		private List<PHY0001U00GrdRehaSinryouryouCodeInfo> _grdInfo = new List<PHY0001U00GrdRehaSinryouryouCodeInfo>();

		public List<PHY0001U00GrdRehaSinryouryouCodeInfo> GrdInfo
		{
			get { return this._grdInfo; }
			set { this._grdInfo = value; }
		}

		public PHY0001U00GrdRehaSinryouryouCodeResult() { }

	}
}