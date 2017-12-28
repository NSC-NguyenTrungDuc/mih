package nta.med.data.model.ihis.schs;

public class SCH0201U99BookingInfo {
	private String bunhoLink;
	private String hangmogName;
	private String reserDate;
	private String reserTime;
	private String moveComment;
	
	public SCH0201U99BookingInfo(String bunhoLink, String hangmogName, String reserDate, String reserTime,
			String moveComment) {
		super();
		this.bunhoLink = bunhoLink;
		this.hangmogName = hangmogName;
		this.reserDate = reserDate;
		this.reserTime = reserTime;
		this.moveComment = moveComment;
	}
	
	public String getBunhoLink() {
		return bunhoLink;
	}
	public void setBunhoLink(String bunhoLink) {
		this.bunhoLink = bunhoLink;
	}
	public String getHangmogName() {
		return hangmogName;
	}
	public void setHangmogName(String hangmogName) {
		this.hangmogName = hangmogName;
	}
	public String getReserDate() {
		return reserDate;
	}
	public void setReserDate(String reserDate) {
		this.reserDate = reserDate;
	}
	public String getReserTime() {
		return reserTime;
	}
	public void setReserTime(String reserTime) {
		this.reserTime = reserTime;
	}
	public String getMoveComment() {
		return moveComment;
	}
	public void setMoveComment(String moveComment) {
		this.moveComment = moveComment;
	}
	
	
}
