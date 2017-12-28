package nta.med.data.model.ihis.nuri;

public class NUR5020U00grdCommentInfo {

	private String nurWrdt;
	private String hoDong;
	private String comment;
	private String seq;
	private String dataRowState;
	
	public NUR5020U00grdCommentInfo(String nurWrdt, String hoDong, String comment, String seq, String dataRowState) {
		super();
		this.nurWrdt = nurWrdt;
		this.hoDong = hoDong;
		this.comment = comment;
		this.seq = seq;
		this.dataRowState = dataRowState;
	}

	public String getNurWrdt() {
		return nurWrdt;
	}

	public void setNurWrdt(String nurWrdt) {
		this.nurWrdt = nurWrdt;
	}

	public String getHoDong() {
		return hoDong;
	}

	public void setHoDong(String hoDong) {
		this.hoDong = hoDong;
	}

	public String getComment() {
		return comment;
	}

	public void setComment(String comment) {
		this.comment = comment;
	}

	public String getSeq() {
		return seq;
	}

	public void setSeq(String seq) {
		this.seq = seq;
	}

	public String getDataRowState() {
		return dataRowState;
	}

	public void setDataRowState(String dataRowState) {
		this.dataRowState = dataRowState;
	}
	
}
