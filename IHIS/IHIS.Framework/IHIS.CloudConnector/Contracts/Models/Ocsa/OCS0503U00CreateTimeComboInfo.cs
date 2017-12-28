using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocsa
{
    [Serializable]
	public class OCS0503U00CreateTimeComboInfo
	{
		private String _amStart;
		private String _amEnd;
		private String _pmStart;
		private String _pmEnd;
		private String _avgTime;

		public String AmStart
		{
			get { return this._amStart; }
			set { this._amStart = value; }
		}

		public String AmEnd
		{
			get { return this._amEnd; }
			set { this._amEnd = value; }
		}

		public String PmStart
		{
			get { return this._pmStart; }
			set { this._pmStart = value; }
		}

		public String PmEnd
		{
			get { return this._pmEnd; }
			set { this._pmEnd = value; }
		}

		public String AvgTime
		{
			get { return this._avgTime; }
			set { this._avgTime = value; }
		}

		public OCS0503U00CreateTimeComboInfo() { }

		public OCS0503U00CreateTimeComboInfo(String amStart, String amEnd, String pmStart, String pmEnd, String avgTime)
		{
			this._amStart = amStart;
			this._amEnd = amEnd;
			this._pmStart = pmStart;
			this._pmEnd = pmEnd;
			this._avgTime = avgTime;
		}

	}
}