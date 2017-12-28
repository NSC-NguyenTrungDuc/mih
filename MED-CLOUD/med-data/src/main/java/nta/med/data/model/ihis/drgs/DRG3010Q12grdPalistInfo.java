package nta.med.data.model.ihis.drgs;

import java.util.Date;

public class DRG3010Q12grdPalistInfo {

	private String hoDong1;
	private String hoCode1;
	private String bedNo;
	private String bunho;
	private String suname;
	private Double pkinp1001;
	private String ageSex;
	private Date ipwonDate;
	private String doctorName;
	private String hoSort;

	public DRG3010Q12grdPalistInfo(String hoDong1, String hoCode1, String bedNo, String bunho, String suname,
			Double pkinp1001, String ageSex, Date ipwonDate, String doctorName, String hoSort) {
		super();
		this.hoDong1 = hoDong1;
		this.hoCode1 = hoCode1;
		this.bedNo = bedNo;
		this.bunho = bunho;
		this.suname = suname;
		this.pkinp1001 = pkinp1001;
		this.ageSex = ageSex;
		this.ipwonDate = ipwonDate;
		this.doctorName = doctorName;
		this.hoSort = hoSort;
	}

	public String getHoDong1() {
		return hoDong1;
	}

	public void setHoDong1(String hoDong1) {
		this.hoDong1 = hoDong1;
	}

	public String getHoCode1() {
		return hoCode1;
	}

	public void setHoCode1(String hoCode1) {
		this.hoCode1 = hoCode1;
	}

	public String getBedNo() {
		return bedNo;
	}

	public void setBedNo(String bedNo) {
		this.bedNo = bedNo;
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

	public Double getPkinp1001() {
		return pkinp1001;
	}

	public void setPkinp1001(Double pkinp1001) {
		this.pkinp1001 = pkinp1001;
	}

	public String getAgeSex() {
		return ageSex;
	}

	public void setAgeSex(String ageSex) {
		this.ageSex = ageSex;
	}

	public Date getIpwonDate() {
		return ipwonDate;
	}

	public void setIpwonDate(Date ipwonDate) {
		this.ipwonDate = ipwonDate;
	}

	public String getDoctorName() {
		return doctorName;
	}

	public void setDoctorName(String doctorName) {
		this.doctorName = doctorName;
	}

	public String getHoSort() {
		return hoSort;
	}

	public void setHoSort(String hoSort) {
		this.hoSort = hoSort;
	}

}
