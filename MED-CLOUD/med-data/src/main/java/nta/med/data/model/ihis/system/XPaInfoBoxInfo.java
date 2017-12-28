package nta.med.data.model.ihis.system;

public class XPaInfoBoxInfo {
	private String patientName;
    private String patientName2;
    private String sex;
    private Integer yearAge;
    private Integer monthAge;
    private String departmentCode;
    private String departmentName;
    private String birth;
    private String tel;
    private String tel1;
    private String telHp;
    private String email;
    private String zipCode1;
    private String zipCode2;
    private String address1;
    private String address2;
	public XPaInfoBoxInfo(String patientName, String patientName2, String sex,
			Integer yearAge, Integer monthAge, String departmentCode,
			String departmentName, String birth, String tel, String tel1,
			String telHp, String email, String zipCode1, String zipCode2,
			String address1, String address2) {
		super();
		this.patientName = patientName;
		this.patientName2 = patientName2;
		this.sex = sex;
		this.yearAge = yearAge;
		this.monthAge = monthAge;
		this.departmentCode = departmentCode;
		this.departmentName = departmentName;
		this.birth = birth;
		this.tel = tel;
		this.tel1 = tel1;
		this.telHp = telHp;
		this.email = email;
		this.zipCode1 = zipCode1;
		this.zipCode2 = zipCode2;
		this.address1 = address1;
		this.address2 = address2;
	}
	public String getPatientName() {
		return patientName;
	}
	public void setPatientName(String patientName) {
		this.patientName = patientName;
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
	public String getDepartmentCode() {
		return departmentCode;
	}
	public void setDepartmentCode(String departmentCode) {
		this.departmentCode = departmentCode;
	}
	public String getDepartmentName() {
		return departmentName;
	}
	public void setDepartmentName(String departmentName) {
		this.departmentName = departmentName;
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
    
}
