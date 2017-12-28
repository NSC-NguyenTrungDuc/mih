package nta.med.data.model.ihis.nuro;

import java.util.Date;

public class KCCKScheduleDoctorStartEndDateHistory {
	private Date startDate;
	private Date endDate;
	public KCCKScheduleDoctorStartEndDateHistory(Date startDate, Date endDate) {
		super();
		this.startDate = startDate;
		this.endDate = endDate;
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
	
}
