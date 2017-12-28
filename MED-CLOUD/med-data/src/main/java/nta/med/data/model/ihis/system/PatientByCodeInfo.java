package nta.med.data.model.ihis.system;

public class PatientByCodeInfo {

	private String patientName1;
	private String patientName2;
	private String sex;
	private Integer yearAge;
	private Integer monthAge;
	private String type;
	private String codeNm;
	private String birth;
	private String tel;
	private String tel1;
	private String telHp;
	private String email;
	private String zipCode1;
	private String zipCode2;
	private String address1;
	private String address2;
	private String telGubun1;
	private String telGubun2;
	private String telGubun3;
	private String pwd;

	public PatientByCodeInfo(String patientName1, String patientName2, String sex, Integer yearAge, Integer monthAge,
			String type, String codeNm, String birth, String tel, String tel1, String telHp, String email,
			String zipCode1, String zipCode2, String address1, String address2, String telGubun1, String telGubun2,
			String telGubun3, String pwd) {
		super();
		this.patientName1 = patientName1;
		this.patientName2 = patientName2;
		this.sex = sex;
		this.yearAge = yearAge;
		this.monthAge = monthAge;
		this.type = type;
		this.codeNm = codeNm;
		this.birth = birth;
		this.tel = tel;
		this.tel1 = tel1;
		this.telHp = telHp;
		this.email = email;
		this.zipCode1 = zipCode1;
		this.zipCode2 = zipCode2;
		this.address1 = address1;
		this.address2 = address2;
		this.telGubun1 = telGubun1;
		this.telGubun2 = telGubun2;
		this.telGubun3 = telGubun3;
		this.pwd = pwd;
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

	public String getSex() {
		return sex;
	}

	public void setSex(String sex) {
		this.sex = sex;
	}

	public Integer getYearAge() {
		return yearAge;
	}

	public void setYearAge(Integer yearAge) {
		this.yearAge = yearAge;
	}

	public Integer getMonthAge() {
		return monthAge;
	}

	public void setMonthAge(Integer monthAge) {
		this.monthAge = monthAge;
	}

	public String getType() {
		return type;
	}

	public void setType(String type) {
		this.type = type;
	}

	public String getCodeNm() {
		return codeNm;
	}

	public void setCodeNm(String codeNm) {
		this.codeNm = codeNm;
	}

	public String getBirth() {
		return birth;
	}

	public void setBirth(String birth) {
		this.birth = birth;
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

	public String getEmail() {
		return email;
	}

	public void setEmail(String email) {
		this.email = email;
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

	public String getTelGubun1() {
		return telGubun1;
	}

	public void setTelGubun1(String telGubun1) {
		this.telGubun1 = telGubun1;
	}

	public String getTelGubun2() {
		return telGubun2;
	}

	public void setTelGubun2(String telGubun2) {
		this.telGubun2 = telGubun2;
	}

	public String getTelGubun3() {
		return telGubun3;
	}

	public void setTelGubun3(String telGubun3) {
		this.telGubun3 = telGubun3;
	}

	public String getPwd() {
		return pwd;
	}

	public void setPwd(String pwd) {
		this.pwd = pwd;
	}

}
