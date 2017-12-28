package nta.med.data.model.ihis.ocsa;

public class OCS0803U00grdOCS0803ItemInfo {
	private String patStatusGr   ; 
	private String patStatusGrName;
	private String ment ;
	private Double seq;
	public OCS0803U00grdOCS0803ItemInfo(String patStatusGr,
			String patStatusGrName, String ment, Double seq) {
		super();
		this.patStatusGr = patStatusGr;
		this.patStatusGrName = patStatusGrName;
		this.ment = ment;
		this.seq = seq;
	}
	public String getPatStatusGr() {
		return patStatusGr;
	}
	public void setPatStatusGr(String patStatusGr) {
		this.patStatusGr = patStatusGr;
	}
	public String getPatStatusGrName() {
		return patStatusGrName;
	}
	public void setPatStatusGrName(String patStatusGrName) {
		this.patStatusGrName = patStatusGrName;
	}
	public String getMent() {
		return ment;
	}
	public void setMent(String ment) {
		this.ment = ment;
	}
	public Double getSeq() {
		return seq;
	}
	public void setSeq(Double seq) {
		this.seq = seq;
	}
	

}
