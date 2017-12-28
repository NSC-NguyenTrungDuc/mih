package nta.med.data.model.ihis.nuro;

import java.math.BigDecimal;
import java.math.BigInteger;

public class NuroOUT1001U01GetDoctorInfo {
	private String gwa;
	private String gwaName;
    private String doctor;
    private String doctorName;
    private BigDecimal waitingPatient;
    private BigInteger totalPatient;
	public NuroOUT1001U01GetDoctorInfo(String gwa, String gwaName,
			String doctor, String doctorName, BigDecimal waitingPatient,
			BigInteger totalPatient) {
		super();
		this.gwa = gwa;
		this.gwaName = gwaName;
		this.doctor = doctor;
		this.doctorName = doctorName;
		this.waitingPatient = waitingPatient;
		this.totalPatient = totalPatient;
	}
	public String getGwa() {
		return gwa;
	}
	public void setGwa(String gwa) {
		this.gwa = gwa;
	}
	public String getGwaName() {
		return gwaName;
	}
	public void setGwaName(String gwaName) {
		this.gwaName = gwaName;
	}
	public String getDoctor() {
		return doctor;
	}
	public void setDoctor(String doctor) {
		this.doctor = doctor;
	}
	public String getDoctorName() {
		return doctorName;
	}
	public void setDoctorName(String doctorName) {
		this.doctorName = doctorName;
	}
	public BigDecimal getWaitingPatient() {
		return waitingPatient;
	}
	public void setWaitingPatient(BigDecimal waitingPatient) {
		this.waitingPatient = waitingPatient;
	}
	public BigInteger getTotalPatient() {
		return totalPatient;
	}
	public void setTotalPatient(BigInteger totalPatient) {
		this.totalPatient = totalPatient;
	}
}
