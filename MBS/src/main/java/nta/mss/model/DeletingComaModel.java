package nta.mss.model;

import java.io.Serializable;

/**
 * The Class DeletingComaModel. 
 *
 * @author MinhLS
 * @crtDate Aug 12, 2014
 */
public class DeletingComaModel implements Serializable {

	/** The Constant serialVersionUID. */
	private static final long serialVersionUID = 3569099889093845042L;

	private Integer reservationId;
	private Integer originalDoctorId;
	private String originalDoctorName;
	private Integer doctorId;
	private String doctorName;
	private Boolean isSentEmail;
	
	public Integer getReservationId() {
		return reservationId;
	}
	public void setReservationId(Integer reservationId) {
		this.reservationId = reservationId;
	}
	public Integer getOriginalDoctorId() {
		return originalDoctorId;
	}
	public void setOriginalDoctorId(Integer originalDoctorId) {
		this.originalDoctorId = originalDoctorId;
	}
	public String getOriginalDoctorName() {
		return originalDoctorName;
	}
	public void setOriginalDoctorName(String originalDoctorName) {
		this.originalDoctorName = originalDoctorName;
	}
	public Integer getDoctorId() {
		return doctorId;
	}
	public void setDoctorId(Integer doctorId) {
		this.doctorId = doctorId;
	}
	public String getDoctorName() {
		return doctorName;
	}
	public void setDoctorName(String doctorName) {
		this.doctorName = doctorName;
	}
	public Boolean getIsSentEmail() {
		return isSentEmail;
	}
	public void setIsSentEmail(Boolean isSentEmail) {
		this.isSentEmail = isSentEmail;
	}
}
