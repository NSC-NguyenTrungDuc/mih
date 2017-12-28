package nta.med.ext.cms.model.cms;

import com.fasterxml.jackson.annotation.JsonProperty;

public class HospitalInfoModel {

	@JsonProperty("hosp_code")
	private String hospCode;
	
	@JsonProperty("hosp_name")
	private String hospName;
	
	@JsonProperty("descrypt_code")
	private String descryptHospCode;
	
	@JsonProperty("logo")
	private String logo;
	
	@JsonProperty("address")
	private String address;
	
	@JsonProperty("locale")
	private String locale;

	public String getHospCode() {
		return hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}

	public String getHospName() {
		return hospName;
	}

	public void setHospName(String hospName) {
		this.hospName = hospName;
	}

	public String getLogo() {
		return logo;
	}

	public void setLogo(String logo) {
		this.logo = logo;
	}

	public String getAddress() {
		return address;
	}

	public void setAddress(String address) {
		this.address = address;
	}

	public String getLocale() {
		return locale;
	}

	public void setLocale(String locale) {
		this.locale = locale;
	}

	public String getDescryptHospCode() {
		return descryptHospCode;
	}

	public void setDescryptHospCode(String descryptHospCode) {
		this.descryptHospCode = descryptHospCode;
	}
}
