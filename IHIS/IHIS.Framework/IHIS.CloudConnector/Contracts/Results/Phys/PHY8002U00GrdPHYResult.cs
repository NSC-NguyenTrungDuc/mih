using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Phys;

namespace IHIS.CloudConnector.Contracts.Results.Phys
{
    [Serializable]
	public class PHY8002U00GrdPHYResult : AbstractContractResult
	{
		private List<PHY8002U00GrdPHY8002Info> _grd8002Info = new List<PHY8002U00GrdPHY8002Info>();
		private List<PHY8002U00GrdPHY8003Info> _grd8003Info = new List<PHY8002U00GrdPHY8003Info>();
		private List<PHY8002U00GrdPHY8004Info> _grd8004Info = new List<PHY8002U00GrdPHY8004Info>();

		public List<PHY8002U00GrdPHY8002Info> Grd8002Info
		{
			get { return this._grd8002Info; }
			set { this._grd8002Info = value; }
		}

		public List<PHY8002U00GrdPHY8003Info> Grd8003Info
		{
			get { return this._grd8003Info; }
			set { this._grd8003Info = value; }
		}

		public List<PHY8002U00GrdPHY8004Info> Grd8004Info
		{
			get { return this._grd8004Info; }
			set { this._grd8004Info = value; }
		}

		public PHY8002U00GrdPHYResult() { }

	}
}