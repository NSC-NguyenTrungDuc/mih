package nta.mss.entity;
/**
 * 
 * @author HoanPC
 *
 */
public class ExaminationInfo {
	private String examinationDate;
	private String examinationTime;
	private String departmentName;
	private String patientName;
	private String patientCode;
	private String patientNameKana;
	private String receiptedTime;
	private String isOnline;
	private String status;
	private String mtCallingId;
	private String reservationCode;
	private Integer reservationId;
	private boolean hasTokenDevice;
	public ExaminationInfo(String examinationDate, String examinationTime, String departmentName, String patientName,
			String patientCode, String patientNameKana, String receiptedTime, String isOnline, String status, String mtCallingId,String reservationCode,Integer reservationId ,boolean hasTokenDevice) {
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
		this.mtCallingId = mtCallingId;
		this.setReservationCode(reservationCode);
		this.reservationId = reservationId;
		this.hasTokenDevice = hasTokenDevice;
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

	public String getMtCallingId() {
		return mtCallingId;
	}

	public void setMtCallingId(String mtCallingId) {
		this.mtCallingId = mtCallingId;
	}

	public String getReservationCode() {
		return reservationCode;
	}

	public void setReservationCode(String reservationCode) {
		this.reservationCode = reservationCode;
	}

	public Integer getReservationId() {
		return reservationId;
	}

	public void setReservationId(Integer reservationId) {
		this.reservationId = reservationId;
	}

	public boolean isHasTokenDevice() {
		return hasTokenDevice;
	}

	public void setHasTokenDevice(boolean hasTokenDevice) {
		this.hasTokenDevice = hasTokenDevice;
	}
	
}
