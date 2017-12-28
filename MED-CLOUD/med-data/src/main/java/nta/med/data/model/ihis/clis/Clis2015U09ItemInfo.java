package nta.med.data.model.ihis.clis;

import java.util.Date;

public class Clis2015U09ItemInfo {
	private Integer clisSmoId;
	private String smoCode;
	private Date startDate;
	private Date endDate;
	private String smoName;
	private String smoName1;
	private String zipCode1;
	private String zipCode2;
	private String address;
	private String address1;
	private String tel;
	private String tel1;
	private String fax;
	private String dodobuhyeunNo;
	private String codeName;
	private String homepage;
	private String email;

	public Clis2015U09ItemInfo(Integer clisSmoId, String smoCode,
			Date startDate, Date endDate, String smoName, String smoName1,
			String zipCode1, String zipCode2, String address, String address1,
			String tel, String tel1, String fax, String dodobuhyeunNo,
			String codeName, String homepage, String email) {
		super();
		this.clisSmoId = clisSmoId;
		this.smoCode = smoCode;
		this.startDate = startDate;
		this.endDate = endDate;
		this.smoName = smoName;
		this.smoName1 = smoName1;
		this.zipCode1 = zipCode1;
		this.zipCode2 = zipCode2;
		this.address = address;
		this.address1 = address1;
		this.tel = tel;
		this.tel1 = tel1;
		this.fax = fax;
		this.dodobuhyeunNo = dodobuhyeunNo;
		this.codeName = codeName;
		this.homepage = homepage;
		this.email = email;
	}

	public Integer getClisSmoId() {
		return clisSmoId;
	}

	public void setClisSmoId(Integer clisSmoId) {
		this.clisSmoId = clisSmoId;
	}

	public String getSmoCode() {
		return smoCode;
	}

	public void setSmoCode(String smoCode) {
		this.smoCode = smoCode;
	}

	public Date getStartDate() {
		return startDate;
	}

	public void setStartDate(Date startDate) {
		this.startDate = startDate;
	}

	public Date getEndDate() {
		return endDate;
	}

	public void setEndDate(Date endDate) {
		this.endDate = endDate;
	}

	public String getSmoName() {
		return smoName;
	}

	public void setSmoName(String smoName) {
		this.smoName = smoName;
	}

	public String getSmoName1() {
		return smoName1;
	}

	public void setSmoName1(String smoName1) {
		this.smoName1 = smoName1;
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

	public String getAddress() {
		return address;
	}

	public void setAddress(String address) {
		this.address = address;
	}

	public String getAddress1() {
		return address1;
	}

	public void setAddress1(String address1) {
		this.address1 = address1;
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

	public String getFax() {
		return fax;
	}

	public void setFax(String fax) {
		this.fax = fax;
	}

	public String getDodobuhyeunNo() {
		return dodobuhyeunNo;
	}

	public void setDodobuhyeunNo(String dodobuhyeunNo) {
		this.dodobuhyeunNo = dodobuhyeunNo;
	}

	public String getCodeName() {
		return codeName;
	}

	public void setCodeName(String codeName) {
		this.codeName = codeName;
	}

	public String getHomepage() {
		return homepage;
	}

	public void setHomepage(String homepage) {
		this.homepage = homepage;
	}

	public String getEmail() {
		return email;
	}

	public void setEmail(String email) {
		this.email = email;
	}

}