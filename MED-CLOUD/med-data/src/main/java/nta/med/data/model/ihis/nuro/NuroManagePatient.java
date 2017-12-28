package nta.med.data.model.ihis.nuro;

import java.sql.Timestamp;

public class NuroManagePatient {
	private String patientCode ;
    private String patientName1;
    private String patientName2;
    private Timestamp birth ;
    private String sex ;
    private String zipCode1;
    private String zipCode2;
    private String address1;
    private String address2;
    private String tel;
    private String tel1;
    private String telHp;
    private String telType;
    private String telType2;
    private String telType3;
    private String email;
    private String paceMakerYn;
    private String selfPaceMaker;
    
	public NuroManagePatient(String patientCode, String patientName1,
			String patientName2, Timestamp birth, String sex, String zipCode1,
			String zipCode2, String address1, String address2, String tel,
			String tel1, String telHp, String telType, String telType2,
			String telType3, String email, String paceMakerYn,
			String selfPaceMaker) {
		super();
		this.patientCode = patientCode;
		this.patientName1 = patientName1;
		this.patientName2 = patientName2;
		this.birth = birth;
		this.sex = sex;
		this.zipCode1 = zipCode1;
		this.zipCode2 = zipCode2;
		this.address1 = address1;
		this.address2 = address2;
		this.tel = tel;
		this.tel1 = tel1;
		this.telHp = telHp;
		this.telType = telType;
		this.telType2 = telType2;
		this.telType3 = telType3;
		this.email = email;
		this.paceMakerYn = paceMakerYn;
		this.selfPaceMaker = selfPaceMaker;
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
	public Timestamp getBirth() {
		return birth;
	}
	public void setBirth(Timestamp birth) {
		this.birth = birth;
	}
	public String getSex() {
		return sex;
	}
	public void setSex(String sex) {
		this.sex = sex;
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
	public String getTelHp() {
		return telHp;
	}
	public void setTelHp(String telHp) {
		this.telHp = telHp;
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
	public String getEmail() {
		return email;
	}
	public void setEmail(String email) {
		this.email = email;
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
    
}
