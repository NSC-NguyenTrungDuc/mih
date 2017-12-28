package nta.med.data.model.ihis.nuro;

import java.util.Date;

public class NuroRES1001U00ReservationScheduleListItemInfo {
	private String examPreTime;
	private String patientCode;
	private String patientName1;
	private String patientName2;
	private String examStatus;
	private String reserDate;
	private String pkout1001;
	private Date examPreDate;
	private String departmentCode;
	private String receptionNo;
	private String type;
	private String doctorCode;
	private String resType;
	private String resChanggu;
	private String resInputType;
	private String comingStatus;
	private String newRow;
	private String examState;

	public NuroRES1001U00ReservationScheduleListItemInfo(String examPreTime,
			String patientCode, String patientName1, String patientName2,
			String examStatus, String reserDate, String pkout1001,
			Date examPreDate, String departmentCode, String receptionNo,
			String type, String doctorCode, String resType, String resChanggu,
			String resInputType, String comingStatus, String newRow,
			String examState) {
		super();
		this.examPreTime = examPreTime;
		this.patientCode = patientCode;
		this.patientName1 = patientName1;
		this.patientName2 = patientName2;
		this.examStatus = examStatus;
		this.reserDate = reserDate;
		this.pkout1001 = pkout1001;
		this.examPreDate = examPreDate;
		this.departmentCode = departmentCode;
		this.receptionNo = receptionNo;
		this.type = type;
		this.doctorCode = doctorCode;
		this.resType = resType;
		this.resChanggu = resChanggu;
		this.resInputType = resInputType;
		this.comingStatus = comingStatus;
		this.newRow = newRow;
		this.examState = examState;
	}

	public String getExamPreTime() {
		return examPreTime;
	}

	public void setExamPreTime(String examPreTime) {
		this.examPreTime = examPreTime;
	}

	public String getPatientCode() {
		return patientCode;
	}

	public void setPatientCode(String patientCode) {
		this.patientCode = patientCode;
	}

	public String getPatientName1() {
		return patientName1;
	}

	public void setPatientName1(String patientName1) {
		this.patientName1 = patientName1;
	}

	public String getPatientName2() {
		return patientName2;
	}

	public void setPatientName2(String patientName2) {
		this.patientName2 = patientName2;
	}

	public String getExamStatus() {
		return examStatus;
	}

	public void setExamStatus(String examStatus) {
		this.examStatus = examStatus;
	}

	public String getReserDate() {
		return reserDate;
	}

	public void setReserDate(String reserDate) {
		this.reserDate = reserDate;
	}

	public String getPkout1001() {
		return pkout1001;
	}

	public void setPkout1001(String pkout1001) {
		this.pkout1001 = pkout1001;
	}

	public Date getExamPreDate() {
		return examPreDate;
	}

	public void setExamPreDate(Date examPreDate) {
		this.examPreDate = examPreDate;
	}

	public String getDepartmentCode() {
		return departmentCode;
	}

	public void setDepartmentCode(String departmentCode) {
		this.departmentCode = departmentCode;
	}

	public String getReceptionNo() {
		return receptionNo;
	}

	public void setReceptionNo(String receptionNo) {
		this.receptionNo = receptionNo;
	}

	public String getType() {
		return type;
	}

	public void setType(String type) {
		this.type = type;
	}

	public String getDoctorCode() {
		return doctorCode;
	}

	public void setDoctorCode(String doctorCode) {
		this.doctorCode = doctorCode;
	}

	public String getResType() {
		return resType;
	}

	public void setResType(String resType) {
		this.resType = resType;
	}

	public String getResChanggu() {
		return resChanggu;
	}

	public void setResChanggu(String resChanggu) {
		this.resChanggu = resChanggu;
	}

	public String getResInputType() {
		return resInputType;
	}

	public void setResInputType(String resInputType) {
		this.resInputType = resInputType;
	}

	public String getComingStatus() {
		return comingStatus;
	}

	public void setComingStatus(String comingStatus) {
		this.comingStatus = comingStatus;
	}

	public String getNewRow() {
		return newRow;
	}

	public void setNewRow(String newRow) {
		this.newRow = newRow;
	}

	public String getExamState() {
		return examState;
	}

	public void setExamState(String examState) {
		this.examState = examState;
	}

}
