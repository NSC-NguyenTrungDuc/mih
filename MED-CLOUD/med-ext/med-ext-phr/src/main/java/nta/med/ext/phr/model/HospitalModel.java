package nta.med.ext.phr.model;

import com.fasterxml.jackson.annotation.JsonProperty;

public class HospitalModel {

	private String hospCode;
	private String hospName;
	private String address;
	private String tel;
	private String countryCode;

	public HospitalModel() {
		super();
	}

	public HospitalModel(String hospCode, String hospName, String address, String tel, String countryCode) {
		super();
		this.setHospCode(hospCode);
		this.setHospName(hospName);
		this.setAddress(address);
		this.setTel(tel);
		this.setCountryCode(countryCode);

	}

	@JsonProperty("address")
	public String getAddress() {
		return address;
	}

	public void setAddress(String address) {
		this.address = address;
	}

	@JsonProperty("tel")
	public String getTel() {
		return tel;
	}

	public void setTel(String tel) {
		this.tel = tel;
	}

	@JsonProperty("country_code")
	public String getCountryCode() {
		return countryCode;
	}

	public void setCountryCode(String countryCode) {
		this.countryCode = countryCode;
	}

	@JsonProperty("hosp_code")
	public String getHospCode() {
		return hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}

	@JsonProperty("hosp_name")
	public String getHospName() {
		return hospName;
	}

	public void setHospName(String hospName) {
		this.hospName = hospName;
	}

}
