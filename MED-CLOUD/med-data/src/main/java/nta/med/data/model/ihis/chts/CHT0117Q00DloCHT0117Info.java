package nta.med.data.model.ihis.chts;

import java.io.Serializable;
import java.util.Date;

public class CHT0117Q00DloCHT0117Info implements Serializable {
	private Date startDate;
    private Date endDate;
    private String buwi;
    private String buwiName;
	public CHT0117Q00DloCHT0117Info(Date startDate, Date endDate, String buwi,
			String buwiName) {
		super();
		this.startDate = startDate;
		this.endDate = endDate;
		this.buwi = buwi;
		this.buwiName = buwiName;
	}
	public Date getStartDate() {
		return startDate;
	}
	public void setStartDate(Date startDate) {
		this.startDate = startDate;
	}
	public Date getEndDate() {
		return endDate;
	}
	public void setEndDate(Date endDate) {
		this.endDate = endDate;
	}
	public String getBuwi() {
		return buwi;
	}
	public void setBuwi(String buwi) {
		this.buwi = buwi;
	}
	public String getBuwiName() {
		return buwiName;
	}
	public void setBuwiName(String buwiName) {
		this.buwiName = buwiName;
	}
}
