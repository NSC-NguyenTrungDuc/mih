package nta.med.data.model.ihis.endo;

public class END1001U02GrdComment3Info {
	private String comments   ;
	private String numb       ;
	private Double ser        ;
	public END1001U02GrdComment3Info(String comments, String numb, Double ser) {
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
	public Double getSer() {
		return ser;
	}
	public void setSer(Double ser) {
		this.ser = ser;
	}

}
