package nta.med.data.model.ihis.nuro;

import java.sql.Timestamp;

public class NuroRES1001U00DoctorReserListItemInfo {
	private Timestamp comingDate;
	private String examPreTime;
	private String departmentName;
	private String doctorName;
	private Double pkout1001;
	private String comingStatus;
	private String patientCode;
	private String departmentCode;
	private String doctorCode;
	private String examIraiStatus;
	private Timestamp iraiDate;
	private String resUser;
	private String reserComment;
	private String reserType;
	private String clinicName;
	
	public NuroRES1001U00DoctorReserListItemInfo(Timestamp comingDate, String examPreTime, String departmentName,
			String doctorName, Double pkout1001, String comingStatus, String patientCode, String departmentCode,
			String doctorCode, String examIraiStatus, Timestamp iraiDate, String resUser, String reserComment,
			String reserType, String clinicName) {
		super();
		this.comingDate = comingDate;
		this.examPreTime = examPreTime;
		this.departmentName = departmentName;
		this.doctorName = doctorName;
		this.pkout1001 = pkout1001;
		this.comingStatus = comingStatus;
		this.patientCode = patientCode;
		this.departmentCode = departmentCode;
		this.doctorCode = doctorCode;
		this.examIraiStatus = examIraiStatus;
		this.iraiDate = iraiDate;
		this.resUser = resUser;
		this.reserComment = reserComment;
		this.reserType = reserType;
		this.clinicName = clinicName;
	}
	public Timestamp getComingDate() {
		return comingDate;
	}
	public void setComingDate(Timestamp comingDate) {
		this.comingDate = comingDate;
	}
	public String getExamPreTime() {
		return examPreTime;
	}
	public void setExamPreTime(String examPreTime) {
		this.examPreTime = examPreTime;
	}
	public String getDepartmentName() {
		return departmentName;
	}
	public void setDepartmentName(String departmentName) {
		this.departmentName = departmentName;
	}
	public String getDoctorName() {
		return doctorName;
	}
	public void setDoctorName(String doctorName) {
		this.doctorName = doctorName;
	}
	public Double getPkout1001() {
		return pkout1001;
	}
	public void setPkout1001(Double pkout1001) {
		this.pkout1001 = pkout1001;
	}
	public String getComingStatus() {
		return comingStatus;
	}
	public void setComingStatus(String comingStatus) {
		this.comingStatus = comingStatus;
	}
	public String getPatientCode() {
		return patientCode;
	}
	public void setPatientCode(String patientCode) {
		this.patientCode = patientCode;
	}
	public String getDepartmentCode() {
		return departmentCode;
	}
	public void setDepartmentCode(String departmentCode) {
		this.departmentCode = departmentCode;
	}
	public String getDoctorCode() {
		return doctorCode;
	}
	public void setDoctorCode(String doctorCode) {
		this.doctorCode = doctorCode;
	}
	public String getExamIraiStatus() {
		return examIraiStatus;
	}
	public void setExamIraiStatus(String examIraiStatus) {
		this.examIraiStatus = examIraiStatus;
	}
	public Timestamp getIraiDate() {
		return iraiDate;
	}
	public void setIraiDate(Timestamp iraiDate) {
		this.iraiDate = iraiDate;
	}
	public String getResUser() {
		return resUser;
	}
	public void setResUser(String resUser) {
		this.resUser = resUser;
	}
	public String getReserComment() {
		return reserComment;
	}
	public void setReserComment(String reserComment) {
		this.reserComment = reserComment;
	}
	public String getReserType() {
		return reserType;
	}
	public void setReserType(String reserType) {
		this.reserType = reserType;
	}
	
	public String getClinicName() {
		return clinicName;
	}
	public void setClinicName(String clinicName) {
		this.clinicName = clinicName;
	}
	@Override
	public String toString() {
		return "NuroRES1001U00DoctorReserListItemInfo [comingDate="
				+ comingDate + ", examPreTime=" + examPreTime
				+ ", departmentName=" + departmentName + ", doctorName="
				+ doctorName + ", pkout1001=" + pkout1001 + ", comingStatus="
				+ comingStatus + ", patientCode=" + patientCode
				+ ", departmentCode=" + departmentCode + ", doctorCode="
				+ doctorCode + ", examIraiStatus=" + examIraiStatus
				+ ", iraiDate=" + iraiDate + ", resUser=" + resUser
				+ ", reserComment=" + reserComment + ", reserType=" + reserType
				+ ", clinicName=" + clinicName 
				+ "]";
	}
}
