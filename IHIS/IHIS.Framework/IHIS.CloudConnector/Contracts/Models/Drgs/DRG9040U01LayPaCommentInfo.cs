using System;

namespace IHIS.CloudConnector.Contracts.Models.Drgs
{
    [Serializable]
	public class DRG9040U01LayPaCommentInfo
	{
		private String _orderRemark;
		private String _drgRemark;

		public String OrderRemark
		{
			get { return this._orderRemark; }
			set { this._orderRemark = value; }
		}

		public String DrgRemark
		{
			get { return this._drgRemark; }
			set { this._drgRemark = value; }
		}

		public DRG9040U01LayPaCommentInfo() { }

		public DRG9040U01LayPaCommentInfo(String orderRemark, String drgRemark)
		{
			this._orderRemark = orderRemark;
			this._drgRemark = drgRemark;
		}

	}
}