package nta.med.data.model.ihis.system;

public class HospitalDetailInfo {
	
	private String hospCode;
    private String hospName;   
    private String address;
    private String tel;
    private String countryCode;
    
    
	public String getAddress() {
		return address;
	}
	public void setAddress(String address) {
		this.address = address;
	}
	public String getTel() {
		return tel;
	}
	public void setTel(String tel) {
		this.tel = tel;
	}
	public String getCountryCode() {
		return countryCode;
	}
	public void setCountryCode(String countryCode) {
		this.countryCode = countryCode;
	}
	public HospitalDetailInfo(String hospCode, String hospName, String address, String tel, String countryCode) {
		super();
		this.setHospCode(hospCode);
		this.setHospName(hospName);
		this.setAddress(address);
		this.setTel(tel);
		this.setCountryCode(countryCode);
	
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
	
}
