package nta.med.data.model.ihis.bass;

import java.sql.Timestamp;

public class BAS0270GrdBAS0271Info {
	private String doctor;
	private String doctorName;
	private String doctorGrade;
	private String ctorGradeName;
	private Timestamp startDate ;
	private String jubsuYn;
	private String reserYn;
	private Timestamp endDate;
	private String ocsStatus;
	private String licenseBunho;
	private String sabun;
	private String doctorSign;
	private String cpDoctorYn;
	private String doctorName2;
	private String mayakLicense;
	private String tonggyeDoctor;
	private String commonDoctorYn;
	private String button;
	private String doctorColor;
	public BAS0270GrdBAS0271Info(String doctor, String doctorName,
			String doctorGrade, String ctorGradeName, Timestamp startDate,
			String jubsuYn, String reserYn, Timestamp endDate,
			String ocsStatus, String licenseBunho, String sabun,
			String doctorSign, String cpDoctorYn, String doctorName2,
			String mayakLicense, String tonggyeDoctor, String commonDoctorYn,
			String button, String doctorColor) {
		super();
		this.doctor = doctor;
		this.doctorName = doctorName;
		this.doctorGrade = doctorGrade;
		this.ctorGradeName = ctorGradeName;
		this.startDate = startDate;
		this.jubsuYn = jubsuYn;
		this.reserYn = reserYn;
		this.endDate = endDate;
		this.ocsStatus = ocsStatus;
		this.licenseBunho = licenseBunho;
		this.sabun = sabun;
		this.doctorSign = doctorSign;
		this.cpDoctorYn = cpDoctorYn;
		this.doctorName2 = doctorName2;
		this.mayakLicense = mayakLicense;
		this.tonggyeDoctor = tonggyeDoctor;
		this.commonDoctorYn = commonDoctorYn;
		this.button = button;
		this.doctorColor = doctorColor;
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
	public String getDoctorGrade() {
		return doctorGrade;
	}
	public void setDoctorGrade(String doctorGrade) {
		this.doctorGrade = doctorGrade;
	}
	public String getCtorGradeName() {
		return ctorGradeName;
	}
	public void setCtorGradeName(String ctorGradeName) {
		this.ctorGradeName = ctorGradeName;
	}
	public Timestamp getStartDate() {
		return startDate;
	}
	public void setStartDate(Timestamp startDate) {
		this.startDate = startDate;
	}
	public String getJubsuYn() {
		return jubsuYn;
	}
	public void setJubsuYn(String jubsuYn) {
		this.jubsuYn = jubsuYn;
	}
	public String getReserYn() {
		return reserYn;
	}
	public void setReserYn(String reserYn) {
		this.reserYn = reserYn;
	}
	public Timestamp getEndDate() {
		return endDate;
	}
	public void setEndDate(Timestamp endDate) {
		this.endDate = endDate;
	}
	public String getOcsStatus() {
		return ocsStatus;
	}
	public void setOcsStatus(String ocsStatus) {
		this.ocsStatus = ocsStatus;
	}
	public String getLicenseBunho() {
		return licenseBunho;
	}
	public void setLicenseBunho(String licenseBunho) {
		this.licenseBunho = licenseBunho;
	}
	public String getSabun() {
		return sabun;
	}
	public void setSabun(String sabun) {
		this.sabun = sabun;
	}
	public String getDoctorSign() {
		return doctorSign;
	}
	public void setDoctorSign(String doctorSign) {
		this.doctorSign = doctorSign;
	}
	public String getCpDoctorYn() {
		return cpDoctorYn;
	}
	public void setCpDoctorYn(String cpDoctorYn) {
		this.cpDoctorYn = cpDoctorYn;
	}
	public String getDoctorName2() {
		return doctorName2;
	}
	public void setDoctorName2(String doctorName2) {
		this.doctorName2 = doctorName2;
	}
	public String getMayakLicense() {
		return mayakLicense;
	}
	public void setMayakLicense(String mayakLicense) {
		this.mayakLicense = mayakLicense;
	}
	public String getTonggyeDoctor() {
		return tonggyeDoctor;
	}
	public void setTonggyeDoctor(String tonggyeDoctor) {
		this.tonggyeDoctor = tonggyeDoctor;
	}
	public String getCommonDoctorYn() {
		return commonDoctorYn;
	}
	public void setCommonDoctorYn(String commonDoctorYn) {
		this.commonDoctorYn = commonDoctorYn;
	}
	public String getButton() {
		return button;
	}
	public void setButton(String button) {
		this.button = button;
	}
	public String getDoctorColor() {
		return doctorColor;
	}
	public void setDoctorColor(String doctorColor) {
		this.doctorColor = doctorColor;
	}
	
}
