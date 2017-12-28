package nta.med.data.model.ihis.nuri;

import java.util.Date;

public class NUR1020U00GrdDeleteInfo {

	private String bunho;
	private Date ymd;
	private Double fkinp1001;
	private String time;

	public NUR1020U00GrdDeleteInfo(String bunho, Date ymd, Double fkinp1001, String time) {
		super();
		this.bunho = bunho;
		this.ymd = ymd;
		this.fkinp1001 = fkinp1001;
		this.time = time;
	}

	public String getBunho() {
		return bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}

	public Date getYmd() {
		return ymd;
	}

	public void setYmd(Date ymd) {
		this.ymd = ymd;
	}

	public Double getFkinp1001() {
		return fkinp1001;
	}

	public void setFkinp1001(Double fkinp1001) {
		this.fkinp1001 = fkinp1001;
	}

	public String getTime() {
		return time;
	}

	public void setTime(String time) {
		this.time = time;
	}

}
