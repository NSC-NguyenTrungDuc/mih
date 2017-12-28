package nta.med.core.domain.bas;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the BAS0270 database table.
 * 
 */
@Entity
@Table(name= "BAS0270")
public class Bas0270 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String commonDoctorYn;
	private String cpDoctorYn;
	private String doctor;
	private String doctorColor;
	private String doctorGrade;
	private String doctorGwa;
	private String doctorName;
	private String doctorName2;
	private String doctorSign;
	private Date endDate;
	private String hospCode;
	private String jubsuYn;
	private String licenseBunho;
	private String mainGwaYn;
	private String mayakLicense;
	private String ocsStatus;
	private String orgDoctor;
	private String reserYn;
	private String sabun;
	private double sortKey;
	private Date startDate;
	private String tonggyeDoctor;
	private String updId;

	public Bas0270() {
	}


	@Column(name="COMMON_DOCTOR_YN")
	public String getCommonDoctorYn() {
		return this.commonDoctorYn;
	}

	public void setCommonDoctorYn(String commonDoctorYn) {
		this.commonDoctorYn = commonDoctorYn;
	}


	@Column(name="CP_DOCTOR_YN")
	public String getCpDoctorYn() {
		return this.cpDoctorYn;
	}

	public void setCpDoctorYn(String cpDoctorYn) {
		this.cpDoctorYn = cpDoctorYn;
	}


	public String getDoctor() {
		return this.doctor;
	}

	public void setDoctor(String doctor) {
		this.doctor = doctor;
	}


	@Column(name="DOCTOR_COLOR")
	public String getDoctorColor() {
		return this.doctorColor;
	}

	public void setDoctorColor(String doctorColor) {
		this.doctorColor = doctorColor;
	}


	@Column(name="DOCTOR_GRADE")
	public String getDoctorGrade() {
		return this.doctorGrade;
	}

	public void setDoctorGrade(String doctorGrade) {
		this.doctorGrade = doctorGrade;
	}


	@Column(name="DOCTOR_GWA")
	public String getDoctorGwa() {
		return this.doctorGwa;
	}

	public void setDoctorGwa(String doctorGwa) {
		this.doctorGwa = doctorGwa;
	}


	@Column(name="DOCTOR_NAME")
	public String getDoctorName() {
		return this.doctorName;
	}

	public void setDoctorName(String doctorName) {
		this.doctorName = doctorName;
	}


	@Column(name="DOCTOR_NAME2")
	public String getDoctorName2() {
		return this.doctorName2;
	}

	public void setDoctorName2(String doctorName2) {
		this.doctorName2 = doctorName2;
	}


	@Column(name="DOCTOR_SIGN")
	public String getDoctorSign() {
		return this.doctorSign;
	}

	public void setDoctorSign(String doctorSign) {
		this.doctorSign = doctorSign;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="END_DATE")
	public Date getEndDate() {
		return this.endDate;
	}

	public void setEndDate(Date endDate) {
		this.endDate = endDate;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="JUBSU_YN")
	public String getJubsuYn() {
		return this.jubsuYn;
	}

	public void setJubsuYn(String jubsuYn) {
		this.jubsuYn = jubsuYn;
	}


	@Column(name="LICENSE_BUNHO")
	public String getLicenseBunho() {
		return this.licenseBunho;
	}

	public void setLicenseBunho(String licenseBunho) {
		this.licenseBunho = licenseBunho;
	}


	@Column(name="MAIN_GWA_YN")
	public String getMainGwaYn() {
		return this.mainGwaYn;
	}

	public void setMainGwaYn(String mainGwaYn) {
		this.mainGwaYn = mainGwaYn;
	}


	@Column(name="MAYAK_LICENSE")
	public String getMayakLicense() {
		return this.mayakLicense;
	}

	public void setMayakLicense(String mayakLicense) {
		this.mayakLicense = mayakLicense;
	}


	@Column(name="OCS_STATUS")
	public String getOcsStatus() {
		return this.ocsStatus;
	}

	public void setOcsStatus(String ocsStatus) {
		this.ocsStatus = ocsStatus;
	}


	@Column(name="ORG_DOCTOR")
	public String getOrgDoctor() {
		return this.orgDoctor;
	}

	public void setOrgDoctor(String orgDoctor) {
		this.orgDoctor = orgDoctor;
	}


	@Column(name="RESER_YN")
	public String getReserYn() {
		return this.reserYn;
	}

	public void setReserYn(String reserYn) {
		this.reserYn = reserYn;
	}


	public String getSabun() {
		return this.sabun;
	}

	public void setSabun(String sabun) {
		this.sabun = sabun;
	}


	@Column(name="SORT_KEY")
	public double getSortKey() {
		return this.sortKey;
	}

	public void setSortKey(double sortKey) {
		this.sortKey = sortKey;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="START_DATE")
	public Date getStartDate() {
		return this.startDate;
	}

	public void setStartDate(Date startDate) {
		this.startDate = startDate;
	}


	@Column(name="TONGGYE_DOCTOR")
	public String getTonggyeDoctor() {
		return this.tonggyeDoctor;
	}

	public void setTonggyeDoctor(String tonggyeDoctor) {
		this.tonggyeDoctor = tonggyeDoctor;
	}


	@Column(name="UPD_ID")
	public String getUpdId() {
		return this.updId;
	}

	public void setUpdId(String updId) {
		this.updId = updId;
	}

}