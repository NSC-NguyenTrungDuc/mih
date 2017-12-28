using System;

namespace IHIS.CloudConnector.Contracts.Models.Injs
{
    [Serializable]
	public class InjsINJ1001U01DiseaseListItemInfo
	{
		private String _pkSeq;
		private String _sangName;
		private String _juSangYn;
		private String _sangStartDate;

		public String PkSeq
		{
			get { return this._pkSeq; }
			set { this._pkSeq = value; }
		}

		public String SangName
		{
			get { return this._sangName; }
			set { this._sangName = value; }
		}

		public String JuSangYn
		{
			get { return this._juSangYn; }
			set { this._juSangYn = value; }
		}

		public String SangStartDate
		{
			get { return this._sangStartDate; }
			set { this._sangStartDate = value; }
		}

		public InjsINJ1001U01DiseaseListItemInfo() { }

		public InjsINJ1001U01DiseaseListItemInfo(String pkSeq, String sangName, String juSangYn, String sangStartDate)
		{
			this._pkSeq = pkSeq;
			this._sangName = sangName;
			this._juSangYn = juSangYn;
			this._sangStartDate = sangStartDate;
		}

	}
}