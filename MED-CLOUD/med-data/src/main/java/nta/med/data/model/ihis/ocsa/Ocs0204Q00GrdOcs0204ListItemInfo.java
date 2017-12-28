package nta.med.data.model.ihis.ocsa;

public class Ocs0204Q00GrdOcs0204ListItemInfo {
	private String memb; 
	private String sangGubun;
	private String sangGubunName;
	private Double seq;
	
	public Ocs0204Q00GrdOcs0204ListItemInfo(String memb, String sangGubun,
			String sangGubunName, Double seq) {
		super();
		this.memb = memb;
		this.sangGubun = sangGubun;
		this.sangGubunName = sangGubunName;
		this.seq = seq;
	}
	public String getMemb() {
		return memb;
	}
	public void setMemb(String memb) {
		this.memb = memb;
	}
	public String getSangGubun() {
		return sangGubun;
	}
	public void setSangGubun(String sangGubun) {
		this.sangGubun = sangGubun;
	}
	public String getSangGubunName() {
		return sangGubunName;
	}
	public void setSangGubunName(String sangGubunName) {
		this.sangGubunName = sangGubunName;
	}
	public Double getSeq() {
		return seq;
	}
	public void setSeq(Double seq) {
		this.seq = seq;
	}
	
}
