package nta.med.data.model.ihis.nuri;

import java.util.Date;

public class NUR1020Q00layGraphInfo {

	private String ymd;
	private String timeGubun;
	private String prGubun;
	private Double prValue;
	private Date ymdDate;

	public NUR1020Q00layGraphInfo(String ymd, String timeGubun, String prGubun, Double prValue, Date ymdDate) {
		super();
		this.ymd = ymd;
		this.timeGubun = timeGubun;
		this.prGubun = prGubun;
		this.prValue = prValue;
		this.ymdDate = ymdDate;
	}

	public String getYmd() {
		return ymd;
	}

	public void setYmd(String ymd) {
		this.ymd = ymd;
	}

	public String getTimeGubun() {
		return timeGubun;
	}

	public void setTimeGubun(String timeGubun) {
		this.timeGubun = timeGubun;
	}

	public String getPrGubun() {
		return prGubun;
	}

	public void setPrGubun(String prGubun) {
		this.prGubun = prGubun;
	}

	public Double getPrValue() {
		return prValue;
	}

	public void setPrValue(Double prValue) {
		this.prValue = prValue;
	}

	public Date getYmdDate() {
		return ymdDate;
	}

	public void setYmdDate(Date ymdDate) {
		this.ymdDate = ymdDate;
	}

}
