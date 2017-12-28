package nta.med.data.model.ihis.ocsa;

public class OcsaOCS0204U00GrdOCS0204ListInfo {
	private String memb;
	private Double fSeq;
	private String sangGubun;
	private String sangGubunName;
	public OcsaOCS0204U00GrdOCS0204ListInfo(String memb, Double fSeq,
			String sangGubun, String sangGubunName) {
		super();
		this.memb = memb;
		this.fSeq = fSeq;
		this.sangGubun = sangGubun;
		this.sangGubunName = sangGubunName;
	}
	public String getMemb() {
		return memb;
	}
	public void setMemb(String memb) {
		this.memb = memb;
	}
	public Double getfSeq() {
		return fSeq;
	}
	public void setfSeq(Double fSeq) {
		this.fSeq = fSeq;
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
	
}
