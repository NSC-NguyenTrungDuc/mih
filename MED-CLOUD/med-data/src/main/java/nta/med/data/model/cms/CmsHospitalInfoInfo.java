package nta.med.data.model.cms;

public class CmsHospitalInfoInfo {
	private String hospCode;
	private String hospName;
	private String logo;
	private String address;
	private String locale;
	
	public CmsHospitalInfoInfo(String hospCode, String hospName, String logo, String address, String locale) {
		super();
		this.hospCode = hospCode;
		this.hospName = hospName;
		this.logo = logo;
		this.address = address;
		this.locale = locale;
	}
	
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
	
	
}
