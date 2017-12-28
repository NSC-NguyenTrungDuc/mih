package nta.med.data.model.ihis.xrts;

public class XRT1002U00GrdComment3Info {
	private String comments;
	private String numb;
	private String ser;
	public XRT1002U00GrdComment3Info(String comments, String numb, String ser) {
		super();
		this.comments = comments;
		this.numb = numb;
		this.ser = ser;
	}
	public String getComments() {
		return comments;
	}
	public void setComments(String comments) {
		this.comments = comments;
	}
	public String getNumb() {
		return numb;
	}
	public void setNumb(String numb) {
		this.numb = numb;
	}
	public String getSer() {
		return ser;
	}
	public void setSer(String ser) {
		this.ser = ser;
	}   

}
