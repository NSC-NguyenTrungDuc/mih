package nta.med.core.domain.doc;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;


/**
 * The persistent class for the DOC4003 database table.
 * 
 */
@Entity
@Table(name="DOC4003")
public class Doc4003 extends BaseEntity {
	private String address;
	private Date birth;
	private String bunho;
	private String checkupOpinion;
	private Date createDate;
	private String disease;
	private String doctor;
	private String doctorId;
	private String endDate;
	private String endYn;
	private String gwa;
	private String gwaCode;
	private String hospCode;
	private String ioGubun;
	private String job;
	private Double pkdoc4003;
	private String prescription;
	private Double seq;
	private String sex;
	private String suname;
	private Date sysDate;
	private String sysId;
	private String tel;
	private String toDoctor;
	private String toDoctor2;
	private String toHospitalInfo;
	private String toSinryouka;
	private String toSinryouka2;
	private Date updDate;
	private String updId;
	private String zip;

	public Doc4003() {
	}


	public String getAddress() {
		return this.address;
	}

	public void setAddress(String address) {
		this.address = address;
	}


	@Temporal(TemporalType.TIMESTAMP)
	public Date getBirth() {
		return this.birth;
	}

	public void setBirth(Date birth) {
		this.birth = birth;
	}


	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}


	@Column(name="CHECKUP_OPINION")
	public String getCheckupOpinion() {
		return this.checkupOpinion;
	}

	public void setCheckupOpinion(String checkupOpinion) {
		this.checkupOpinion = checkupOpinion;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="CREATE_DATE")
	public Date getCreateDate() {
		return this.createDate;
	}

	public void setCreateDate(Date createDate) {
		this.createDate = createDate;
	}


	public String getDisease() {
		return this.disease;
	}

	public void setDisease(String disease) {
		this.disease = disease;
	}


	public String getDoctor() {
		return this.doctor;
	}

	public void setDoctor(String doctor) {
		this.doctor = doctor;
	}


	@Column(name="DOCTOR_ID")
	public String getDoctorId() {
		return this.doctorId;
	}

	public void setDoctorId(String doctorId) {
		this.doctorId = doctorId;
	}


	@Column(name="END_DATE")
	public String getEndDate() {
		return this.endDate;
	}

	public void setEndDate(String endDate) {
		this.endDate = endDate;
	}


	@Column(name="END_YN")
	public String getEndYn() {
		return this.endYn;
	}

	public void setEndYn(String endYn) {
		this.endYn = endYn;
	}


	public String getGwa() {
		return this.gwa;
	}

	public void setGwa(String gwa) {
		this.gwa = gwa;
	}


	@Column(name="GWA_CODE")
	public String getGwaCode() {
		return this.gwaCode;
	}

	public void setGwaCode(String gwaCode) {
		this.gwaCode = gwaCode;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="IO_GUBUN")
	public String getIoGubun() {
		return this.ioGubun;
	}

	public void setIoGubun(String ioGubun) {
		this.ioGubun = ioGubun;
	}


	public String getJob() {
		return this.job;
	}

	public void setJob(String job) {
		this.job = job;
	}


	public Double getPkdoc4003() {
		return this.pkdoc4003;
	}

	public void setPkdoc4003(Double pkdoc4003) {
		this.pkdoc4003 = pkdoc4003;
	}


	public String getPrescription() {
		return this.prescription;
	}

	public void setPrescription(String prescription) {
		this.prescription = prescription;
	}


	public Double getSeq() {
		return this.seq;
	}

	public void setSeq(Double seq) {
		this.seq = seq;
	}


	public String getSex() {
		return this.sex;
	}

	public void setSex(String sex) {
		this.sex = sex;
	}


	public String getSuname() {
		return this.suname;
	}

	public void setSuname(String suname) {
		this.suname = suname;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="SYS_DATE")
	public Date getSysDate() {
		return this.sysDate;
	}

	public void setSysDate(Date sysDate) {
		this.sysDate = sysDate;
	}


	@Column(name="SYS_ID")
	public String getSysId() {
		return this.sysId;
	}

	public void setSysId(String sysId) {
		this.sysId = sysId;
	}


	public String getTel() {
		return this.tel;
	}

	public void setTel(String tel) {
		this.tel = tel;
	}


	@Column(name="TO_DOCTOR")
	public String getToDoctor() {
		return this.toDoctor;
	}

	public void setToDoctor(String toDoctor) {
		this.toDoctor = toDoctor;
	}


	@Column(name="TO_DOCTOR2")
	public String getToDoctor2() {
		return this.toDoctor2;
	}

	public void setToDoctor2(String toDoctor2) {
		this.toDoctor2 = toDoctor2;
	}


	@Column(name="TO_HOSPITAL_INFO")
	public String getToHospitalInfo() {
		return this.toHospitalInfo;
	}

	public void setToHospitalInfo(String toHospitalInfo) {
		this.toHospitalInfo = toHospitalInfo;
	}


	@Column(name="TO_SINRYOUKA")
	public String getToSinryouka() {
		return this.toSinryouka;
	}

	public void setToSinryouka(String toSinryouka) {
		this.toSinryouka = toSinryouka;
	}


	@Column(name="TO_SINRYOUKA2")
	public String getToSinryouka2() {
		return this.toSinryouka2;
	}

	public void setToSinryouka2(String toSinryouka2) {
		this.toSinryouka2 = toSinryouka2;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="UPD_DATE")
	public Date getUpdDate() {
		return this.updDate;
	}

	public void setUpdDate(Date updDate) {
		this.updDate = updDate;
	}


	@Column(name="UPD_ID")
	public String getUpdId() {
		return this.updId;
	}

	public void setUpdId(String updId) {
		this.updId = updId;
	}


	public String getZip() {
		return this.zip;
	}

	public void setZip(String zip) {
		this.zip = zip;
	}

}