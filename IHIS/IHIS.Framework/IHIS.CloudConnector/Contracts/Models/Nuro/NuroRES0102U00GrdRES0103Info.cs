using System;

namespace IHIS.CloudConnector.Contracts.Models.Nuro
{
    [Serializable]
	public class NuroRES0102U00GrdRES0103Info
	{
		private String _doctor;
		private String _jinryoPreDate;
		private String _amStartHhmm;
		private String _amEndHhmm;
		private String _pmStartHhmm;
		private String _pmEndHhmm;
		private String _remark;
		private String _amGwaRoom;
		private String _pmGwaRoom;
		private String _dataRowState;

		public String Doctor
		{
			get { return this._doctor; }
			set { this._doctor = value; }
		}

		public String JinryoPreDate
		{
			get { return this._jinryoPreDate; }
			set { this._jinryoPreDate = value; }
		}

		public String AmStartHhmm
		{
			get { return this._amStartHhmm; }
			set { this._amStartHhmm = value; }
		}

		public String AmEndHhmm
		{
			get { return this._amEndHhmm; }
			set { this._amEndHhmm = value; }
		}

		public String PmStartHhmm
		{
			get { return this._pmStartHhmm; }
			set { this._pmStartHhmm = value; }
		}

		public String PmEndHhmm
		{
			get { return this._pmEndHhmm; }
			set { this._pmEndHhmm = value; }
		}

		public String Remark
		{
			get { return this._remark; }
			set { this._remark = value; }
		}

		public String AmGwaRoom
		{
			get { return this._amGwaRoom; }
			set { this._amGwaRoom = value; }
		}

		public String PmGwaRoom
		{
			get { return this._pmGwaRoom; }
			set { this._pmGwaRoom = value; }
		}

		public String DataRowState
		{
			get { return this._dataRowState; }
			set { this._dataRowState = value; }
		}

		public NuroRES0102U00GrdRES0103Info() { }

		public NuroRES0102U00GrdRES0103Info(String doctor, String jinryoPreDate, String amStartHhmm, String amEndHhmm, String pmStartHhmm, String pmEndHhmm, String remark, String amGwaRoom, String pmGwaRoom, String dataRowState)
		{
			this._doctor = doctor;
			this._jinryoPreDate = jinryoPreDate;
			this._amStartHhmm = amStartHhmm;
			this._amEndHhmm = amEndHhmm;
			this._pmStartHhmm = pmStartHhmm;
			this._pmEndHhmm = pmEndHhmm;
			this._remark = remark;
			this._amGwaRoom = amGwaRoom;
			this._pmGwaRoom = pmGwaRoom;
			this._dataRowState = dataRowState;
		}

	}
}