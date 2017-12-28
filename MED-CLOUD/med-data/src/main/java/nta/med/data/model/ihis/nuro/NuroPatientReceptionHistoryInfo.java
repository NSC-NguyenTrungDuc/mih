package nta.med.data.model.ihis.nuro;

import java.util.Date;

public class NuroPatientReceptionHistoryInfo {
	private Date comingDate;
	private Date examDate;
	private String examTime;
	private String departmentCode;
	private String doctor;
	private String insurType;
	private String sunnabStatus;
	private String examStatus;
	private String comingStatus;
	private String patientCode;
	private String receptionTime;
	private String departmentName;
	private String sujinNo;
	private String dokuStatus;
	private String contKey;
	private Double pkout1001;
	private String sysId;

	public NuroPatientReceptionHistoryInfo(Date comingDate, Date examDate, String examTime, String departmentCode,
			String doctor, String insurType, String sunnabStatus, String examStatus, String comingStatus,
			String patientCode, String receptionTime, String departmentName, String sujinNo, String dokuStatus,
			String contKey, Double pkout1001, String sysId) {
		super();
		this.comingDate = comingDate;
		this.examDate = examDate;
		this.examTime = examTime;
		this.departmentCode = departmentCode;
		this.doctor = doctor;
		this.insurType = insurType;
		this.sunnabStatus = sunnabStatus;
		this.examStatus = examStatus;
		this.comingStatus = comingStatus;
		this.patientCode = patientCode;
		this.receptionTime = receptionTime;
		this.departmentName = departmentName;
		this.sujinNo = sujinNo;
		this.dokuStatus = dokuStatus;
		this.contKey = contKey;
		this.pkout1001 = pkout1001;
		this.sysId = sysId;
	}

	public Date getComingDate() {
		return comingDate;
	}

	public void setComingDate(Date comingDate) {
		this.comingDate = comingDate;
	}

	public Date getExamDate() {
		return examDate;
	}

	public void setExamDate(Date examDate) {
		this.examDate = examDate;
	}

	public String getExamTime() {
		return examTime;
	}

	public void setExamTime(String examTime) {
		this.examTime = examTime;
	}

	public String getDepartmentCode() {
		return departmentCode;
	}

	public void setDepartmentCode(String departmentCode) {
		this.departmentCode = departmentCode;
	}

	public String getDoctor() {
		return doctor;
	}

	public void setDoctor(String doctor) {
		this.doctor = doctor;
	}

	public String getInsurType() {
		return insurType;
	}

	public void setInsurType(String insurType) {
		this.insurType = insurType;
	}

	public String getSunnabStatus() {
		return sunnabStatus;
	}

	public void setSunnabStatus(String sunnabStatus) {
		this.sunnabStatus = sunnabStatus;
	}

	public String getExamStatus() {
		return examStatus;
	}

	public void setExamStatus(String examStatus) {
		this.examStatus = examStatus;
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

	public String getReceptionTime() {
		return receptionTime;
	}

	public void setReceptionTime(String receptionTime) {
		this.receptionTime = receptionTime;
	}

	public String getDepartmentName() {
		return departmentName;
	}

	public void setDepartmentName(String departmentName) {
		this.departmentName = departmentName;
	}

	public String getSujinNo() {
		return sujinNo;
	}

	public void setSujinNo(String sujinNo) {
		this.sujinNo = sujinNo;
	}

	public String getDokuStatus() {
		return dokuStatus;
	}

	public void setDokuStatus(String dokuStatus) {
		this.dokuStatus = dokuStatus;
	}

	public String getContKey() {
		return contKey;
	}

	public void setContKey(String contKey) {
		this.contKey = contKey;
	}

	public Double getPkout1001() {
		return pkout1001;
	}

	public void setPkout1001(Double pkout1001) {
		this.pkout1001 = pkout1001;
	}

	public String getSysId() {
		return sysId;
	}

	public void setSysId(String sysId) {
		this.sysId = sysId;
	}

}