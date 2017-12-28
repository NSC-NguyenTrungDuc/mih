package nta.med.data.model.ihis.nuro;

public class NuroOUT0101U02GridCommentInfo {
	private Double ser;
	private String comment;
    private String patientCode;
	  
	public NuroOUT0101U02GridCommentInfo(Double ser, String comment,
			String patientCode) {
		super();
		this.ser = ser;
		this.comment = comment;
		this.patientCode = patientCode;
	}
	
	public Double getSer() {
		return ser;
	}
	public void setSer(Double ser) {
		this.ser = ser;
	}
	public String getComment() {
		return comment;
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
	  
}
