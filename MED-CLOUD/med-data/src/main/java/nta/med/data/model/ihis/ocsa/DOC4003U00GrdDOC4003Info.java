package nta.med.data.model.ihis.ocsa;

import java.io.Serializable;
import java.sql.Timestamp;

public class DOC4003U00GrdDOC4003Info implements Serializable {
	private Timestamp sysDate;
	private String sysId;
	private String updDate;
	private String updId;
	private String hospCode;
	private Double pkdoc4003;
	private Double seq;
	private String createDate;
	private String toHospitalInfo;
	private String toSinryouka;
	private String toSinryouka2;
	private String toDoctor;
	private String toDoctor2;
	private String doctor;
	private String gwa;
	private String suname;
	private String sex;
	private String zip;
	private String aAddress;
	private String tel;
	private String birth;
	private String job;
	private String disease;
	private String checkupOpinion;
	private String prescription;
	private String bunho;
	private String zipCode;
	private String bAddress;
	private String fax;
	private String yoyangName;
	private String rowState;

	public DOC4003U00GrdDOC4003Info(Timestamp sysDate, String sysId, String updDate, String updId, String hospCode,
			Double pkdoc4003, Double seq, String createDate, String toHospitalInfo, String toSinryouka,
			String toSinryouka2, String toDoctor, String toDoctor2, String doctor, String gwa, String suname,
			String sex, String zip, String aAddress, String tel, String birth, String job, String disease,
			String checkupOpinion, String prescription, String bunho, String zipCode, String bAddress, String fax,
			String yoyangName) {
		super();
		this.sysDate = sysDate;
		this.sysId = sysId;
		this.updDate = updDate;
		this.updId = updId;
		this.hospCode = hospCode;
		this.pkdoc4003 = pkdoc4003;
		this.seq = seq;
		this.createDate = createDate;
		this.toHospitalInfo = toHospitalInfo;
		this.toSinryouka = toSinryouka;
		this.toSinryouka2 = toSinryouka2;
		this.toDoctor = toDoctor;
		this.toDoctor2 = toDoctor2;
		this.doctor = doctor;
		this.gwa = gwa;
		this.suname = suname;
		this.sex = sex;
		this.zip = zip;
		this.aAddress = aAddress;
		this.tel = tel;
		this.birth = birth;
		this.job = job;
		this.disease = disease;
		this.checkupOpinion = checkupOpinion;
		this.prescription = prescription;
		this.bunho = bunho;
		this.zipCode = zipCode;
		this.bAddress = bAddress;
		this.fax = fax;
		this.yoyangName = yoyangName;
	}

	public Timestamp getSysDate() {
		return sysDate;
	}

	public void setSysDate(Timestamp sysDate) {
		this.sysDate = sysDate;
	}

	public String getSysId() {
		return sysId;
	}

	public void setSysId(String sysId) {
		this.sysId = sysId;
	}

	public String getUpdDate() {
		return updDate;
	}

	public void setUpdDate(String updDate) {
		this.updDate = updDate;
	}

	public String getUpdId() {
		return updId;
	}

	public void setUpdId(String updId) {
		this.updId = updId;
	}

	public String getHospCode() {
		return hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}

	public Double getPkdoc4003() {
		return pkdoc4003;
	}

	public void setPkdoc4003(Double pkdoc4003) {
		this.pkdoc4003 = pkdoc4003;
	}

	public Double getSeq() {
		return seq;
	}

	public void setSeq(Double seq) {
		this.seq = seq;
	}

	public String getCreateDate() {
		return createDate;
	}

	public void setCreateDate(String createDate) {
		this.createDate = createDate;
	}

	public String getToHospitalInfo() {
		return toHospitalInfo;
	}

	public void setToHospitalInfo(String toHospitalInfo) {
		this.toHospitalInfo = toHospitalInfo;
	}

	public String getToSinryouka() {
		return toSinryouka;
	}

	public void setToSinryouka(String toSinryouka) {
		this.toSinryouka = toSinryouka;
	}

	public String getToSinryouka2() {
		return toSinryouka2;
	}

	public void setToSinryouka2(String toSinryouka2) {
		this.toSinryouka2 = toSinryouka2;
	}

	public String getToDoctor() {
		return toDoctor;
	}

	public void setToDoctor(String toDoctor) {
		this.toDoctor = toDoctor;
	}

	public String getToDoctor2() {
		return toDoctor2;
	}

	public void setToDoctor2(String toDoctor2) {
		this.toDoctor2 = toDoctor2;
	}

	public String getDoctor() {
		return doctor;
	}

	public void setDoctor(String doctor) {
		this.doctor = doctor;
	}

	public String getGwa() {
		return gwa;
	}

	public void setGwa(String gwa) {
		this.gwa = gwa;
	}

	public String getSuname() {
		return suname;
	}

	public void setSuname(String suname) {
		this.suname = suname;
	}

	public String getSex() {
		return sex;
	}

	public void setSex(String sex) {
		this.sex = sex;
	}

	public String getZip() {
		return zip;
	}

	public void setZip(String zip) {
		this.zip = zip;
	}

	public String getaAddress() {
		return aAddress;
	}

	public void setaAddress(String aAddress) {
		this.aAddress = aAddress;
	}

	public String getTel() {
		return tel;
	}

	public void setTel(String tel) {
		this.tel = tel;
	}

	public String getBirth() {
		return birth;
	}

	public void setBirth(String birth) {
		this.birth = birth;
	}

	public String getJob() {
		return job;
	}

	public void setJob(String job) {
		this.job = job;
	}

	public String getDisease() {
		return disease;
	}

	public void setDisease(String disease) {
		this.disease = disease;
	}

	public String getCheckupOpinion() {
		return checkupOpinion;
	}

	public void setCheckupOpinion(String checkupOpinion) {
		this.checkupOpinion = checkupOpinion;
	}

	public String getPrescription() {
		return prescription;
	}

	public void setPrescription(String prescription) {
		this.prescription = prescription;
	}

	public String getBunho() {
		return bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}

	public String getZipCode() {
		return zipCode;
	}

	public void setZipCode(String zipCode) {
		this.zipCode = zipCode;
	}

	public String getbAddress() {
		return bAddress;
	}

	public void setbAddress(String bAddress) {
		this.bAddress = bAddress;
	}

	public String getFax() {
		return fax;
	}

	public void setFax(String fax) {
		this.fax = fax;
	}

	public String getYoyangName() {
		return yoyangName;
	}

	public void setYoyangName(String yoyangName) {
		this.yoyangName = yoyangName;
	}

	public String getRowState() {
		return rowState;
	}

	public void setRowState(String rowState) {
		this.rowState = rowState;
	}

}
