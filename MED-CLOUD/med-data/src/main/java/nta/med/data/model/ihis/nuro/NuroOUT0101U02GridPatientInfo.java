package nta.med.data.model.ihis.nuro;

import java.sql.Timestamp;

public class NuroOUT0101U02GridPatientInfo {
	private String bunho;
	private String suname;
	private String sex;
	private Timestamp birth;
	private String zipCode1;
	private String zipCode2;
	private String address1;
	private String address2;
	private String tel;
	private String tel1;
	private String type;
	private String telHp;
	private String email;
	private String gubunName;
	private String dongName;
	private String suname2;
	private Integer age;
	private String telType;
	private String telType2;
	private String telType3;
	private String deleteYn;
	private String paceMakerYn;
	private String selfPaceMaker;
	private String patientType ;
	private String retrieveYn;
	private String refId;
	private String billingType;
	public NuroOUT0101U02GridPatientInfo(String bunho, String suname,
			String sex, Timestamp birth, String zipCode1, String zipCode2,
			String address1, String address2, String tel, String tel1,
			String type, String telHp, String email, String gubunName,
			String dongName, String suname2, Integer age, String telType,
			String telType2, String telType3, String deleteYn,
			String paceMakerYn, String selfPaceMaker, String patientType,
			String retrieveYn, String refId, String billingType) {
		super();
		this.bunho = bunho;
		this.suname = suname;
		this.sex = sex;
		this.birth = birth;
		this.zipCode1 = zipCode1;
		this.zipCode2 = zipCode2;
		this.address1 = address1;
		this.address2 = address2;
		this.tel = tel;
		this.tel1 = tel1;
		this.type = type;
		this.telHp = telHp;
		this.email = email;
		this.gubunName = gubunName;
		this.dongName = dongName;
		this.suname2 = suname2;
		this.age = age;
		this.telType = telType;
		this.telType2 = telType2;
		this.telType3 = telType3;
		this.deleteYn = deleteYn;
		this.paceMakerYn = paceMakerYn;
		this.selfPaceMaker = selfPaceMaker;
		this.patientType = patientType;
		this.retrieveYn = retrieveYn;
		this.refId = refId;
		this.billingType = billingType;
	}
	public String getBunho() {
		return bunho;
	}
	public void setBunho(String bunho) {
		this.bunho = bunho;
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
	public Timestamp getBirth() {
		return birth;
	}
	public void setBirth(Timestamp birth) {
		this.birth = birth;
	}
	public String getZipCode1() {
		return zipCode1;
	}
	public void setZipCode1(String zipCode1) {
		this.zipCode1 = zipCode1;
	}
	public String getZipCode2() {
		return zipCode2;
	}
	public void setZipCode2(String zipCode2) {
		this.zipCode2 = zipCode2;
	}
	public String getAddress1() {
		return address1;
	}
	public void setAddress1(String address1) {
		this.address1 = address1;
	}
	public String getAddress2() {
		return address2;
	}
	public void setAddress2(String address2) {
		this.address2 = address2;
	}
	public String getTel() {
		return tel;
	}
	public void setTel(String tel) {
		this.tel = tel;
	}
	public String getTel1() {
		return tel1;
	}
	public void setTel1(String tel1) {
		this.tel1 = tel1;
	}
	public String getType() {
		return type;
	}
	public void setType(String type) {
		this.type = type;
	}
	public String getTelHp() {
		return telHp;
	}
	public void setTelHp(String telHp) {
		this.telHp = telHp;
	}
	public String getEmail() {
		return email;
	}
	public void setEmail(String email) {
		this.email = email;
	}
	public String getGubunName() {
		return gubunName;
	}
	public void setGubunName(String gubunName) {
		this.gubunName = gubunName;
	}
	public String getDongName() {
		return dongName;
	}
	public void setDongName(String dongName) {
		this.dongName = dongName;
	}
	public String getSuname2() {
		return suname2;
	}
	public void setSuname2(String suname2) {
		this.suname2 = suname2;
	}
	public Integer getAge() {
		return age;
	}
	public void setAge(Integer age) {
		this.age = age;
	}
	public String getTelType() {
		return telType;
	}
	public void setTelType(String telType) {
		this.telType = telType;
	}
	public String getTelType2() {
		return telType2;
	}
	public void setTelType2(String telType2) {
		this.telType2 = telType2;
	}
	public String getTelType3() {
		return telType3;
	}
	public void setTelType3(String telType3) {
		this.telType3 = telType3;
	}
	public String getDeleteYn() {
		return deleteYn;
	}
	public void setDeleteYn(String deleteYn) {
		this.deleteYn = deleteYn;
	}
	public String getPaceMakerYn() {
		return paceMakerYn;
	}
	public void setPaceMakerYn(String paceMakerYn) {
		this.paceMakerYn = paceMakerYn;
	}
	public String getSelfPaceMaker() {
		return selfPaceMaker;
	}
	public void setSelfPaceMaker(String selfPaceMaker) {
		this.selfPaceMaker = selfPaceMaker;
	}
	public String getPatientType() {
		return patientType;
	}
	public void setPatientType(String patientType) {
		this.patientType = patientType;
	}
	public String getRetrieveYn() {
		return retrieveYn;
	}
	public void setRetrieveYn(String retrieveYn) {
		this.retrieveYn = retrieveYn;
	}

	public String getRefId() {
		return refId;
	}

	public void setRefId(String refId) {
		this.refId = refId;
	}
	public String getBillingType() {
		return billingType;
	}
	public void setBillingType(String billingType) {
		this.billingType = billingType;
	}
	
}
