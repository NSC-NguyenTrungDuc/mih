package nta.mss.entity;

import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;

import org.apache.commons.lang.StringUtils;

/**
 * 
 * @author HoanPC
 *
 */
public class PatientWaitingInfo {
	private String examinationDate;
	private String examinationTime;
	private String departmentName;
	private String patientName;
	private String patientCode;
	private String patientNameKana;
	private String receiptedTime;
	private String isOnline;
	private String status;
	
	private String doctorCode;
	private String doctorName;
	
	private String examinationTimeFrm;
	private String examinationTimeAmPm;
	
	private String reservationCode;
	
	public PatientWaitingInfo(String examinationDate, String examinationTime, String departmentName, String patientName,
			String patientCode, String patientNameKana, String receiptedTime, String isOnline, String status, String doctorCode, 
			String doctorName, String examinationTimeFrm, String examinationTimeAmPm, String reservationCode) {
		super();
		this.examinationDate = examinationDate;
		this.examinationTime = examinationTime;
		this.departmentName = departmentName;
		this.patientName = patientName;
		this.patientCode = patientCode;
		this.patientNameKana = patientNameKana;
		this.receiptedTime = receiptedTime;
		this.isOnline = isOnline;
		this.status = status;
		
		this.doctorCode = doctorCode;
		this.doctorName = doctorName;
		this.examinationTimeFrm = examinationTimeFrm;
		this.examinationTimeAmPm = examinationTimeAmPm;
		this.reservationCode = reservationCode;
	}
	
	public String getExaminationDate() {
		return examinationDate;
	}
	public void setExaminationDate(String examinationDate) {
		this.examinationDate = examinationDate;
	}
	public String getExaminationTime() {
		return examinationTime;
	}
	public void setExaminationTime(String examinationTime) {
		this.examinationTime = examinationTime;
	}
	public String getDepartmentName() {
		return departmentName;
	}
	public void setDepartmentName(String departmentName) {
		this.departmentName = departmentName;
	}
	public String getPatientName() {
		return patientName;
	}
	public void setPatientName(String patientName) {
		this.patientName = patientName;
	}
	public String getPatientCode() {
		return patientCode;
	}
	public void setPatientCode(String patientCode) {
		this.patientCode = patientCode;
	}
	public String getPatientNameKana() {
		return patientNameKana;
	}
	public void setPatientNameKana(String patientNameKana) {
		this.patientNameKana = patientNameKana;
	}
	public String getReceiptedTime() {
		return receiptedTime;
	}
	public void setReceiptedTime(String receiptedTime) {
		this.receiptedTime = receiptedTime;
	}
	public String getIsOnline() {
		return isOnline;
	}
	public void setIsOnline(String isOnline) {
		this.isOnline = isOnline;
	}
	public String getStatus() {
		return status;
	}
	public void setStatus(String status) {
		this.status = status;
	}

	public String getDoctorCode() {
		return doctorCode;
	}

	public void setDoctorCode(String doctorCode) {
		this.doctorCode = doctorCode;
	}

	public String getDoctorName() {
		return doctorName;
	}

	public void setDoctorName(String doctorName) {
		this.doctorName = doctorName;
	}

	public String getExaminationTimeFrm() {
		if(StringUtils.isNotBlank(examinationTime) && examinationTime.length() == 4) {
			return examinationTime.substring(0, 2) + ":" + examinationTime.substring(2, 4);
		}
		return "";
	}

	public void setExaminationTimeFrm(String examinationTimeFrm) {
		this.examinationTimeFrm = examinationTimeFrm;
	}

	public String getExaminationTimeAmPm() {
		if(StringUtils.isNotBlank(examinationTime) && examinationTime.length() == 4) {
			//SimpleDateFormat displayFormat = new SimpleDateFormat("HH:mm a");
			SimpleDateFormat displayFormat2 = new SimpleDateFormat("a");
		    SimpleDateFormat parseFormat = new SimpleDateFormat("hhmm");
		    Date date = null;
			try {
				date = parseFormat.parse(examinationTime);
				//System.out.println(parseFormat.format(date) + " = " + displayFormat.format(date) + "=" + displayFormat2.format(date));
				return displayFormat2.format(date);
			} catch (ParseException e) {
				e.printStackTrace();
			}
		}
		
		return "";
	}

	public void setExaminationTimeAmPm(String examinationTimeAmPm) {
		this.examinationTimeAmPm = examinationTimeAmPm;
	}

	public String getReservationCode() {
		return reservationCode;
	}

	public void setReservationCode(String reservationCode) {
		this.reservationCode = reservationCode;
	}
	
}
