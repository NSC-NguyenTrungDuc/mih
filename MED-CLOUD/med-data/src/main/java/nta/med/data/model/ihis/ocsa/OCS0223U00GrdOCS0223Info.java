package nta.med.data.model.ihis.ocsa;

public class OCS0223U00GrdOCS0223Info {
	private String jundalPart;
	private String jundalPartName;
	private Double seq;
	private Double serial;
	private String commentTitle;
	private String commentText;
	
	public OCS0223U00GrdOCS0223Info(String jundalPart, String jundalPartName,
			Double seq, Double serial, String commentTitle, String commentText) {
		super();
		this.jundalPart = jundalPart;
		this.jundalPartName = jundalPartName;
		this.seq = seq;
		this.serial = serial;
		this.commentTitle = commentTitle;
		this.commentText = commentText;
	}
	public String getJundalPart() {
		return jundalPart;
	}
	public void setJundalPart(String jundalPart) {
		this.jundalPart = jundalPart;
	}
	public String getJundalPartName() {
		return jundalPartName;
	}
	public void setJundalPartName(String jundalPartName) {
		this.jundalPartName = jundalPartName;
	}
	public Double getSeq() {
		return seq;
	}
	public void setSeq (Double seq) {
		this.seq = seq;
	}
	public Double getSerial() {
		return serial;
	}
	public void setSerial(Double serial) {
		this.serial = serial;
	}
	public String getCommentTitle() {
		return commentTitle;
	}
	public void setCommentTitle(String commentTitle) {
		this.commentTitle = commentTitle;
	}
	public String getCommentText() {
		return commentText;
	}
	public void setCommentText(String commentText) {
		this.commentText = commentText;
	}
}
