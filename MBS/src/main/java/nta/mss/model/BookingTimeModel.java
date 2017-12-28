package nta.mss.model;

import java.io.Serializable;

/**
 * The Class BookingTimeModel.
 * 
 * @author DinhNX
 * @CrtDate Jul 29, 2014
 */
public class BookingTimeModel implements Serializable {
	
	/** The Constant serialVersionUID. */
	private static final long serialVersionUID = -1776301691497124376L;
	
	private String reservationId;
	private String startDate;
	private String endDate;
	private String selectedDate;
	private String selectedTime;
	private Integer doctorId;
	private String doctorName;
	private String templateCode;
	private String templateName; 
	private String doctorCode;
	
	public String getReservationId() {
		return reservationId;
	}

	public void setReservationId(String reservationId) {
		this.reservationId = reservationId;
	}

	public String getStartDate() {
		return startDate;
	}
	
	public void setStartDate(String startDate) {
		this.startDate = startDate;
	}
	
	public String getEndDate() {
		return endDate;
	}
	
	public void setEndDate(String endDate) {
		this.endDate = endDate;
	}
	
	public String getSelectedDate() {
		return selectedDate;
	}
	
	public void setSelectedDate(String selectedDate) {
		this.selectedDate = selectedDate;
	}
	
	public String getSelectedTime() {
		return selectedTime;
	}
	
	public void setSelectedTime(String selectedTime) {
		this.selectedTime = selectedTime;
	}

	public Integer getDoctorId() {
		return doctorId;
	}

	public void setDoctorId(Integer doctorId) {
		this.doctorId = doctorId;
	}

	/**
	 * @return the templateCode
	 */
	public String getTemplateCode() {
		return templateCode;
	}

	/**
	 * @param templateCode the templateCode to set
	 */
	public void setTemplateCode(String templateCode) {
		this.templateCode = templateCode;
	}

	/**
	 * @return the templateName
	 */
	public String getTemplateName() {
		return templateName;
	}

	/**
	 * @param templateName the templateName to set
	 */
	public void setTemplateName(String templateName) {
		this.templateName = templateName;
	}

	/**
	 * @return the doctorName
	 */
	public String getDoctorName() {
		return doctorName;
	}

	/**
	 * @param doctorName the doctorName to set
	 */
	public void setDoctorName(String doctorName) {
		this.doctorName = doctorName;
	}

	public String getDoctorCode() {
		return doctorCode;
	}

	public void setDoctorCode(String doctorCode) {
		this.doctorCode = doctorCode;
	}
	
	
}
