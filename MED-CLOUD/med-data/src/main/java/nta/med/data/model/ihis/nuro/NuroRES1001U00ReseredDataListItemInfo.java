package nta.med.data.model.ihis.nuro;

import java.sql.Timestamp;

public class NuroRES1001U00ReseredDataListItemInfo {
	private String receptionTime;
	private String patientCode;
	private String patientName1;
	private String patientName2;
	private String examStatus;
	private String updDate;
	private Double pkout1001;
	private Timestamp comingDate;
	private String departmentCode;
	private Double receptionNo;
	private String type;
	private String doctorCode;
	private String resType;
	private String resUserName;
	private String resInputType;
	private String comingStatus;
	private String newRow;
	private String examState;
	private String examIraiState;
	private String resUser;
	private String ipwonStatus;
	private String reserComments;
	private String reserType;
	private String yoyangName;
	public NuroRES1001U00ReseredDataListItemInfo(String receptionTime,
			String patientCode, String patientName1, String patientName2,
			String examStatus, String updDate, Double pkout1001,
			Timestamp comingDate, String departmentCode, Double receptionNo,
			String type, String doctorCode, String resType, String resUserName,
			String resInputType, String comingStatus, String newRow,
			String examState, String examIraiState, String resUser,
			String ipwonStatus, String reserComments, String reserType, String yoyangName) {
		this.receptionTime = receptionTime;
		this.patientCode = patientCode;
		this.patientName1 = patientName1;
		this.patientName2 = patientName2;
		this.examStatus = examStatus;
		this.updDate = updDate;
		this.pkout1001 = pkout1001;
		this.comingDate = comingDate;
		this.departmentCode = departmentCode;
		this.receptionNo = receptionNo;
		this.type = type;
		this.doctorCode = doctorCode;
		this.resType = resType;
		this.resUserName = resUserName;
		this.resInputType = resInputType;
		this.comingStatus = comingStatus;
		this.newRow = newRow;
		this.examState = examState;
		this.examIraiState = examIraiState;
		this.resUser = resUser;
		this.ipwonStatus = ipwonStatus;
		this.reserComments = reserComments;
		this.reserType = reserType;
		this.yoyangName = yoyangName;
	}
	public String getReceptionTime() {
		return receptionTime;
	}
	public void setReceptionTime(String receptionTime) {
		this.receptionTime = receptionTime;
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
	public String getUpdDate() {
		return updDate;
	}
	public void setUpdDate(String updDate) {
		this.updDate = updDate;
	}
	public Double getPkout1001() {
		return pkout1001;
	}
	public void setPkout1001(Double pkout1001) {
		this.pkout1001 = pkout1001;
	}
	public Timestamp getComingDate() {
		return comingDate;
	}
	public void setComingDate(Timestamp comingDate) {
		this.comingDate = comingDate;
	}
	public String getDepartmentCode() {
		return departmentCode;
	}
	public void setDepartmentCode(String departmentCode) {
		this.departmentCode = departmentCode;
	}
	public Double getReceptionNo() {
		return receptionNo;
	}
	public void setReceptionNo(Double receptionNo) {
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
	public String getResUserName() {
		return resUserName;
	}
	public void setResUserName(String resUserName) {
		this.resUserName = resUserName;
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
	public String getExamIraiState() {
		return examIraiState;
	}
	public void setExamIraiState(String examIraiState) {
		this.examIraiState = examIraiState;
	}
	public String getResUser() {
		return resUser;
	}
	public void setResUser(String resUser) {
		this.resUser = resUser;
	}
	public String getIpwonStatus() {
		return ipwonStatus;
	}
	public void setIpwonStatus(String ipwonStatus) {
		this.ipwonStatus = ipwonStatus;
	}
	public String getReserComments() {
		return reserComments;
	}
	public void setReserComments(String reserComments) {
		this.reserComments = reserComments;
	}
	public String getReserType() {
		return reserType;
	}
	public void setReserType(String reserType) {
		this.reserType = reserType;
	}
	public String getYoyangName() {
		return yoyangName;
	}
	public void setYoyangName(String yoyangName) {
		this.yoyangName = yoyangName;
	}
	
	@Override
	public String toString() {
		return "NuroRES1001U00ReseredDataListItemInfo [receptionTime="
				+ receptionTime + ", patientCode=" + patientCode
				+ ", patientName1=" + patientName1 + ", patientName2="
				+ patientName2 + ", examStatus=" + examStatus + ", updDate="
				+ updDate + ", pkout1001=" + pkout1001 + ", comingDate="
				+ comingDate + ", departmentCode=" + departmentCode
				+ ", receptionNo=" + receptionNo + ", type=" + type
				+ ", doctorCode=" + doctorCode + ", resType=" + resType
				+ ", resUserName=" + resUserName + ", resInputType="
				+ resInputType + ", comingStatus=" + comingStatus + ", newRow="
				+ newRow + ", examState=" + examState + ", examIraiState="
				+ examIraiState + ", resUser=" + resUser + ", ipwonStatus="
				+ ipwonStatus + ", reserComments=" + reserComments
				+ ", reserType=" + reserType 
				+ ", yoyangName=" + yoyangName + "]";
	}
}
