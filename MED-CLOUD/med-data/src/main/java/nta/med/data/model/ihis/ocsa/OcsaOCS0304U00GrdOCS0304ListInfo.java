package nta.med.data.model.ihis.ocsa;

public class OcsaOCS0304U00GrdOCS0304ListInfo {
	private String memb;
	private String membGubun;
	private String yaksokDirectCode;
	private String yaksokDirectName;
	private Double seq;
	private String ment;

	public OcsaOCS0304U00GrdOCS0304ListInfo(String memb, String membGubun,
			String yaksokDirectCode, String yaksokDirectName, Double seq,
			String ment) {
		super();
		this.memb = memb;
		this.membGubun = membGubun;
		this.yaksokDirectCode = yaksokDirectCode;
		this.yaksokDirectName = yaksokDirectName;
		this.seq = seq;
		this.ment = ment;
	}

	public String getMemb() {
		return memb;
	}

	public void setMemb(String memb) {
		this.memb = memb;
	}

	public String getMembGubun() {
		return membGubun;
	}

	public void setMembGubun(String membGubun) {
		this.membGubun = membGubun;
	}

	public String getYaksokDirectCode() {
		return yaksokDirectCode;
	}

	public void setYaksokDirectCode(String yaksokDirectCode) {
		this.yaksokDirectCode = yaksokDirectCode;
	}

	public String getYaksokDirectName() {
		return yaksokDirectName;
	}

	public void setYaksokDirectName(String yaksokDirectName) {
		this.yaksokDirectName = yaksokDirectName;
	}

	public Double getSeq() {
		return seq;
	}

	public void setSeq(Double seq) {
		this.seq = seq;
	}

	public String getMent() {
		return ment;
	}

	public void setMent(String ment) {
		this.ment = ment;
	}

}
