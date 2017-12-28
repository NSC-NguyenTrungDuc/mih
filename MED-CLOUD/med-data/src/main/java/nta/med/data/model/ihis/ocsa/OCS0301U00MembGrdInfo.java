package nta.med.data.model.ihis.ocsa;

public class OCS0301U00MembGrdInfo {
	private String memb;
	private Double keySeq;
	private String yaksok;
	private String yaksokName;
	private Double seq;
	private String hospCode;
	private String membGubun;
	private String inputTab;
	public OCS0301U00MembGrdInfo(String memb, Double keySeq, String yaksok,
			String yaksokName, Double seq, String hospCode, String membGubun,
			String inputTab) {
		super();
		this.memb = memb;
		this.keySeq = keySeq;
		this.yaksok = yaksok;
		this.yaksokName = yaksokName;
		this.seq = seq;
		this.hospCode = hospCode;
		this.membGubun = membGubun;
		this.inputTab = inputTab;
	}
	public String getMemb() {
		return memb;
	}
	public void setMemb(String memb) {
		this.memb = memb;
	}
	public Double getKeySeq() {
		return keySeq;
	}
	public void setKeySeq(Double keySeq) {
		this.keySeq = keySeq;
	}
	public String getYaksok() {
		return yaksok;
	}
	public void setYaksok(String yaksok) {
		this.yaksok = yaksok;
	}
	public String getYaksokName() {
		return yaksokName;
	}
	public void setYaksokName(String yaksokName) {
		this.yaksokName = yaksokName;
	}
	public Double getSeq() {
		return seq;
	}
	public void setSeq(Double seq) {
		this.seq = seq;
	}
	public String getHospCode() {
		return hospCode;
	}
	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}
	public String getMembGubun() {
		return membGubun;
	}
	public void setMembGubun(String membGubun) {
		this.membGubun = membGubun;
	}
	public String getInputTab() {
		return inputTab;
	}
	public void setInputTab(String inputTab) {
		this.inputTab = inputTab;
	}

	
}
