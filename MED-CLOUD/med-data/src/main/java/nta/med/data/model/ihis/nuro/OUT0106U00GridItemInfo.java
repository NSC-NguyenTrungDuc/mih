package nta.med.data.model.ihis.nuro;

public class OUT0106U00GridItemInfo {
	private String comments;
    private Double ser;
    private String bunho;
    private String displayYn;
	public OUT0106U00GridItemInfo(String comments, Double ser, String bunho,
			String displayYn) {
		super();
		this.comments = comments;
		this.ser = ser;
		this.bunho = bunho;
		this.displayYn = displayYn;
	}
	public String getComments() {
		return comments;
	}
	public void setComments(String comments) {
		this.comments = comments;
	}
	public Double getSer() {
		return ser;
	}
	public void setSer(Double ser) {
		this.ser = ser;
	}
	public String getBunho() {
		return bunho;
	}
	public void setBunho(String bunho) {
		this.bunho = bunho;
	}
	public String getDisplayYn() {
		return displayYn;
	}
	public void setDisplayYn(String displayYn) {
		this.displayYn = displayYn;
	}
}
