using IHIS.CloudConnector.Contracts.Models.Injs;
using System;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Injs
{
    [Serializable]
	public class InjsINJ1001U01ActorListResult : AbstractContractResult
	{
		private List<InjsINJ1001U01ActorListItemInfo> _actorListItem = new List<InjsINJ1001U01ActorListItemInfo>();

		public List<InjsINJ1001U01ActorListItemInfo> ActorListItem
		{
			get { return this._actorListItem; }
			set { this._actorListItem = value; }
		}

		public InjsINJ1001U01ActorListResult() { }

	}
}