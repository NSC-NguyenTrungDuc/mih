using IHIS.CloudConnector.Contracts.Models.Cpls;
using IHIS.CloudConnector.Contracts.Models.System;
using System;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Cpls
{
    [Serializable]
	public class CPL0000Q00InitializeResult : AbstractContractResult
	{
		private List<CPL0000Q00LayJungboListItemInfo> _layJungboList = new List<CPL0000Q00LayJungboListItemInfo>();
		private List<CPL0000Q00LaySigeyulTempListItemInfo> _laySigeyulList = new List<CPL0000Q00LaySigeyulTempListItemInfo>();
		private List<CPL0000Q00LaySubHangmogListItemInfo> _laySubHangmogList = new List<CPL0000Q00LaySubHangmogListItemInfo>();
		private List<ComboListItemInfo> _laymakeTabPageList = new List<ComboListItemInfo>();

		public List<CPL0000Q00LayJungboListItemInfo> LayJungboList
		{
			get { return this._layJungboList; }
			set { this._layJungboList = value; }
		}

		public List<CPL0000Q00LaySigeyulTempListItemInfo> LaySigeyulList
		{
			get { return this._laySigeyulList; }
			set { this._laySigeyulList = value; }
		}

		public List<CPL0000Q00LaySubHangmogListItemInfo> LaySubHangmogList
		{
			get { return this._laySubHangmogList; }
			set { this._laySubHangmogList = value; }
		}

		public List<ComboListItemInfo> LaymakeTabPageList
		{
			get { return this._laymakeTabPageList; }
			set { this._laymakeTabPageList = value; }
		}

		public CPL0000Q00InitializeResult() { }

	}
}