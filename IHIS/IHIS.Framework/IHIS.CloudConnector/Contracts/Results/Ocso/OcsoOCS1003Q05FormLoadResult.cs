using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Results.Ocso
{
    [Serializable]
	public class OcsoOCS1003Q05FormLoadResult : AbstractContractResult
	{
		private List<ComboListItemInfo> _jusaCboItem = new List<ComboListItemInfo>();
		private List<ComboListItemInfo> _payCboItem = new List<ComboListItemInfo>();
		private List<ComboListItemInfo> _portableYnCboItem = new List<ComboListItemInfo>();
		private List<ComboListItemInfo> _jusaSpdGubunCboItem = new List<ComboListItemInfo>();

		public List<ComboListItemInfo> JusaCboItem
		{
			get { return this._jusaCboItem; }
			set { this._jusaCboItem = value; }
		}

		public List<ComboListItemInfo> PayCboItem
		{
			get { return this._payCboItem; }
			set { this._payCboItem = value; }
		}

		public List<ComboListItemInfo> PortableYnCboItem
		{
			get { return this._portableYnCboItem; }
			set { this._portableYnCboItem = value; }
		}

		public List<ComboListItemInfo> JusaSpdGubunCboItem
		{
			get { return this._jusaSpdGubunCboItem; }
			set { this._jusaSpdGubunCboItem = value; }
		}

		public OcsoOCS1003Q05FormLoadResult() { }

	}
}