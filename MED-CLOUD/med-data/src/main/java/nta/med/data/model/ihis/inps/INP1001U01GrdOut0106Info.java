package nta.med.data.model.ihis.inps;

public class INP1001U01GrdOut0106Info {

	private String ser;
	private String comment;
	private String bunho;

	public INP1001U01GrdOut0106Info(String ser, String comment, String bunho) {
		super();
		this.ser = ser;
		this.comment = comment;
		this.bunho = bunho;
	}

	public String getSer() {
		return ser;
	}

	public void setSer(String ser) {
		this.ser = ser;
	}

	public String getComment() {
		return comment;
	}

	public void setComment(String comment) {
		this.comment = comment;
	}

	public String getBunho() {
		return bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}

}
