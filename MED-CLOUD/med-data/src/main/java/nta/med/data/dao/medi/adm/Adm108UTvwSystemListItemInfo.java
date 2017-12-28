package nta.med.data.dao.medi.adm;

public class Adm108UTvwSystemListItemInfo {
	private String pgmNm;
	private String sysId;
	private String sysNm;

	public Adm108UTvwSystemListItemInfo(String pgmNm, String sysId, String sysNm) {
		super();
		this.pgmNm = pgmNm;
		this.sysId = sysId;
		this.sysNm = sysNm;
	}

	public String getPgmNm() {
		return pgmNm;
	}

	public void setPgmNm(String pgmNm) {
		this.pgmNm = pgmNm;
	}

	public String getSysId() {
		return sysId;
	}

	public void setSysId(String sysId) {
		this.sysId = sysId;
	}

	public String getSysNm() {
		return sysNm;
	}

	public void setSysNm(String sysNm) {
		this.sysNm = sysNm;
	}

}
