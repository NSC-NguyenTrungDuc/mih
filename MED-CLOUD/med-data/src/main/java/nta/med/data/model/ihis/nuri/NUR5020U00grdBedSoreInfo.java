package nta.med.data.model.ihis.nuri;

import java.util.Date;

public class NUR5020U00grdBedSoreInfo {

	private String hoDong;
	private Date nurWrdt;
	private String hoCode;
	private String bunho;
	private String suname;
	private Date fromDate;
	private String buwi;

	public NUR5020U00grdBedSoreInfo(String hoDong, Date nurWrdt, String hoCode, String bunho, String suname,
			Date fromDate, String buwi) {
		super();
		this.hoDong = hoDong;
		this.nurWrdt = nurWrdt;
		this.hoCode = hoCode;
		this.bunho = bunho;
		this.suname = suname;
		this.fromDate = fromDate;
		this.buwi = buwi;
	}

	public String getHoDong() {
		return hoDong;
	}

	public void setHoDong(String hoDong) {
		this.hoDong = hoDong;
	}

	public Date getNurWrdt() {
		return nurWrdt;
	}

	public void setNurWrdt(Date nurWrdt) {
		this.nurWrdt = nurWrdt;
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

	public Date getFromDate() {
		return fromDate;
	}

	public void setFromDate(Date fromDate) {
		this.fromDate = fromDate;
	}

	public String getBuwi() {
		return buwi;
	}

	public void setBuwi(String buwi) {
		this.buwi = buwi;
	}

}
