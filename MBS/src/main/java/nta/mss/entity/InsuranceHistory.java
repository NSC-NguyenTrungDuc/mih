package nta.mss.entity;
/**
 * 
 * @author TungLT
 *
 */
public class InsuranceHistory {
	private String rowNum;
	private String reservationDateTime;
	private String referLink;
	public String getRowNum() {
		return rowNum;
	}
	public void setRowNum(String rowNum) {
		this.rowNum = rowNum;
	}
	public String getReservationDateTime() {
		return reservationDateTime;
	}
	public void setReservationDateTime(String reservationDateTime) {
		this.reservationDateTime = reservationDateTime;
	}
	public String getReferLink() {
		return referLink;
	}
	public void setReferLink(String referLink) {
		this.referLink = referLink;
	}
	public InsuranceHistory(String rowNum, String reservationDateTime, String referLink) {
		super();
		this.rowNum = rowNum;
		this.reservationDateTime = reservationDateTime;
		this.referLink = referLink;
	}
	
}
