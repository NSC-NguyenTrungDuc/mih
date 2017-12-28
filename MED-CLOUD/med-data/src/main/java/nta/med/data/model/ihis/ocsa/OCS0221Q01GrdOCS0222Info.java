package nta.med.data.model.ihis.ocsa;

public class OCS0221Q01GrdOCS0222Info {
    private String memb; 
    private Double seq;
    private Double serial;
    private String commentTitle;
    private String commentText;
	public OCS0221Q01GrdOCS0222Info(String memb, Double seq, Double serial,
			String commentTitle, String commentText) {
		super();
		this.memb = memb;
		this.seq = seq;
		this.serial = serial;
		this.commentTitle = commentTitle;
		this.commentText = commentText;
	}
	public String getMemb() {
		return memb;
	}
	public void setMemb(String memb) {
		this.memb = memb;
	}
	public Double getSeq() {
		return seq;
	}
	public void setSeq(Double seq) {
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
