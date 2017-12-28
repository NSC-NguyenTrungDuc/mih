using System;

namespace IHIS.CloudConnector.Contracts.Models.Nuro
{
    [Serializable ]
	public class NuroRES1001U00DoctorReservationStatusListItemInfo
	{
		private String _doctorName;
		private String _reservationStatus;

		public String DoctorName
		{
			get { return this._doctorName; }
			set { this._doctorName = value; }
		}

		public String ReservationStatus
		{
			get { return this._reservationStatus; }
			set { this._reservationStatus = value; }
		}

		public NuroRES1001U00DoctorReservationStatusListItemInfo() { }

		public NuroRES1001U00DoctorReservationStatusListItemInfo(String doctorName, String reservationStatus)
		{
			this._doctorName = doctorName;
			this._reservationStatus = reservationStatus;
		}

	}
}