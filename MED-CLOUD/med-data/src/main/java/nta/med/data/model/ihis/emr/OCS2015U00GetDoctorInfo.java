package nta.med.data.model.ihis.emr;

public class OCS2015U00GetDoctorInfo {
	private String doctorName ;
	private String gwaName ;
	private String yotangName2 ;
	private String address ;
	private String tel1 ;
	private String fax;
	private String website;
	public OCS2015U00GetDoctorInfo(String doctorName, String gwaName, String yotangName2, String address, String tel1,
			String fax, String website) {
		super();
		this.doctorName = doctorName;
		this.gwaName = gwaName;
		this.yotangName2 = yotangName2;
		this.address = address;
		this.tel1 = tel1;
		this.fax = fax;
		this.website = website;
	}
	public String getDoctorName() {
		return doctorName;
	}
	public void setDoctorName(String doctorName) {
		this.doctorName = doctorName;
	}
	public String getGwaName() {
		return gwaName;
	}
	public void setGwaName(String gwaName) {
		this.gwaName = gwaName;
	}
	public String getYotangName2() {
		return yotangName2;
	}
	public void setYotangName2(String yotangName2) {
		this.yotangName2 = yotangName2;
	}
	public String getAddress() {
		return address;
	}
	public void setAddress(String address) {
		this.address = address;
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
	public String getWebsite() {
		return website;
	}
	public void setWebsite(String website) {
		this.website = website;
	}
	
}
