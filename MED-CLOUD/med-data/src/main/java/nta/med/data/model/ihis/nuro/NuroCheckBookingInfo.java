package nta.med.data.model.ihis.nuro;

import java.sql.Timestamp;

public class NuroCheckBookingInfo {
	private String patientCode;
	private Timestamp reserDate;
	
	public NuroCheckBookingInfo(String patientCode, Timestamp reserDate) {
		this.patientCode = patientCode;
		this.reserDate = reserDate;
	}
	
	public String getPatientCode() {
		return patientCode;
	}
	public void setPatientCode(String patientCode) {
		this.patientCode = patientCode;
	}
	public Timestamp getReserDate() {
		return reserDate;
	}
	public void setReserDate(Timestamp reserDate) {
		this.reserDate = reserDate;
	}
}
