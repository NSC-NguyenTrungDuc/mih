using System;

namespace IHIS.CloudConnector.Contracts.Results.Drgs
{
    [Serializable]
	public class DrgsDRG5100P01ProcAtcInterfaceResult : AbstractContractResult
	{
		private String _pkdrg4010;
		private String _rtnIfsCnt;
		private Boolean _procAtcInterface;

		public String Pkdrg4010
		{
			get { return this._pkdrg4010; }
			set { this._pkdrg4010 = value; }
		}

		public String RtnIfsCnt
		{
			get { return this._rtnIfsCnt; }
			set { this._rtnIfsCnt = value; }
		}

		public Boolean ProcAtcInterface
		{
			get { return this._procAtcInterface; }
			set { this._procAtcInterface = value; }
		}

		public DrgsDRG5100P01ProcAtcInterfaceResult() { }

	}
}