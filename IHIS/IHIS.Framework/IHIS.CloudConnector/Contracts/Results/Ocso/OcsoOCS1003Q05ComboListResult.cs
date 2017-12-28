using System;
using IHIS.CloudConnector.Contracts.Models.System;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Ocso
{
    [Serializable]
	public class OcsoOCS1003Q05ComboListResult : AbstractContractResult
	{
		private List<ComboListItemInfo> _jusaCboItem = new List<ComboListItemInfo>();
		private List<ComboListItemInfo> _payCboItem = new List<ComboListItemInfo>();
		private List<ComboListItemInfo> _portableYnCboItem = new List<ComboListItemInfo>();
		private List<ComboListItemInfo> _jusaSpdGubunCboItem = new List<ComboListItemInfo>();
		private List<ComboListItemInfo> _suryangCboItem = new List<ComboListItemInfo>();
		private List<ComboListItemInfo> _nalsuCboItem = new List<ComboListItemInfo>();
		private List<ComboListItemInfo> _dvCboItem = new List<ComboListItemInfo>();

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

		public List<ComboListItemInfo> SuryangCboItem
		{
			get { return this._suryangCboItem; }
			set { this._suryangCboItem = value; }
		}

		public List<ComboListItemInfo> NalsuCboItem
		{
			get { return this._nalsuCboItem; }
			set { this._nalsuCboItem = value; }
		}

		public List<ComboListItemInfo> DvCboItem
		{
			get { return this._dvCboItem; }
			set { this._dvCboItem = value; }
		}

		public OcsoOCS1003Q05ComboListResult() { }

	}
}