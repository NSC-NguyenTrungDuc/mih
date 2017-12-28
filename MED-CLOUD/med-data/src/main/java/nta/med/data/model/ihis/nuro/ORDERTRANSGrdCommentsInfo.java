package nta.med.data.model.ihis.nuro;

public class ORDERTRANSGrdCommentsInfo {
	private String bunho     ;
	private Double ser       ;
	private String comments  ;
	public ORDERTRANSGrdCommentsInfo(String bunho, Double ser, String comments) {
		super();
		this.bunho = bunho;
		this.ser = ser;
		this.comments = comments;
	}
	public String getBunho() {
		return bunho;
	}
	public void setBunho(String bunho) {
		this.bunho = bunho;
	}
	public Double getSer() {
		return ser;
	}
	public void setSer(Double ser) {
		this.ser = ser;
	}
	public String getComments() {
		return comments;
	}
	public void setComments(String comments) {
		this.comments = comments;
	}
	
}
