using System;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
	public class NuroOut1001U01CheckDoctorScheduleResult : AbstractContractResult
	{
		private String _ret;
		private String _fromTime;
		private String _toTime;
		private String _schFlag;

		public String Ret
		{
			get { return this._ret; }
			set { this._ret = value; }
		}

		public String FromTime
		{
			get { return this._fromTime; }
			set { this._fromTime = value; }
		}

		public String ToTime
		{
			get { return this._toTime; }
			set { this._toTime = value; }
		}

		public String SchFlag
		{
			get { return this._schFlag; }
			set { this._schFlag = value; }
		}

		public NuroOut1001U01CheckDoctorScheduleResult() { }

	}
}