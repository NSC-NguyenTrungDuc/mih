package nta.med.data.model.ihis.nuro;

public class NuroPatientCommentInfo {
	 private String comment;
     private Double ser;
     private String patientCode ;
     private String contKey;
     
	
	public NuroPatientCommentInfo(String comment, Double ser,
			String patientCode, String contKey) {
		super();
		this.comment = comment;
		this.ser = ser;
		this.patientCode = patientCode;
		this.contKey = contKey;
	}
	public String getComment() {
		return comment;
	}
	public Double getSer() {
		return ser;
	}
	public void setSer(Double ser) {
		this.ser = ser;
	}
	public void setComment(String comment) {
		this.comment = comment;
	}
	
	public String getPatientCode() {
		return patientCode;
	}
	public void setPatientCode(String patientCode) {
		this.patientCode = patientCode;
	}
	public String getContKey() {
		return contKey;
	}
	public void setContKey(String contKey) {
		this.contKey = contKey;
	}
     
}
