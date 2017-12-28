package nta.med.data.model.ihis.nuro;

public class NuroRES1001U00DoctorReservationStatusListItemInfo {
	private String doctorName;
	private String reservationStatus;
	
	public NuroRES1001U00DoctorReservationStatusListItemInfo(String doctorName,
			String reservationStatus) {
		this.doctorName = doctorName;
		this.reservationStatus = reservationStatus;
	}

	public String getDoctorName() {
		return doctorName;
	}

	public void setDoctorName(String doctorName) {
		this.doctorName = doctorName;
	}

	public String getReservationStatus() {
		return reservationStatus;
	}

	public void setReservationStatus(String reservationStatus) {
		this.reservationStatus = reservationStatus;
	}
}
