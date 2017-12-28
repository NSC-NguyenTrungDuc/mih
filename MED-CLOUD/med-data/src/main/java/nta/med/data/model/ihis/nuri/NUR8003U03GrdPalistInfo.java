package nta.med.data.model.ihis.nuri;

import java.util.Date;

public class NUR8003U03GrdPalistInfo {

	private String hoCode;
	private String bunho;
	private String suname;
	private Double pkinp1001;
	private String ageSex;
	private Date ipwonDate;
	private Date toiwonDate;
	private String doctorName;
	private String kaikeiHodong;

	public NUR8003U03GrdPalistInfo(String hoCode, String bunho, String suname, Double pkinp1001, String ageSex,
			Date ipwonDate, Date toiwonDate, String doctorName, String kaikeiHodong) {
		super();
		this.hoCode = hoCode;
		this.bunho = bunho;
		this.suname = suname;
		this.pkinp1001 = pkinp1001;
		this.ageSex = ageSex;
		this.ipwonDate = ipwonDate;
		this.toiwonDate = toiwonDate;
		this.doctorName = doctorName;
		this.kaikeiHodong = kaikeiHodong;
	}

	public String getHoCode() {
		return hoCode;
	}

	public void setHoCode(String hoCode) {
		this.hoCode = hoCode;
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

	public Date getToiwonDate() {
		return toiwonDate;
	}

	public void setToiwonDate(Date toiwonDate) {
		this.toiwonDate = toiwonDate;
	}

	public String getDoctorName() {
		return doctorName;
	}

	public void setDoctorName(String doctorName) {
		this.doctorName = doctorName;
	}

	public String getKaikeiHodong() {
		return kaikeiHodong;
	}

	public void setKaikeiHodong(String kaikeiHodong) {
		this.kaikeiHodong = kaikeiHodong;
	}

}
