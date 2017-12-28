package nta.med.data.dao.medi.adm;

public class Adm108UFwkPgmIdListItemInfo {
	private String pgmId;
	private String pgmNm;
	private String sysId;
	private String sysNm;

	public Adm108UFwkPgmIdListItemInfo(String pgmId, String pgmNm,
			String sysId, String sysNm) {
		super();
		this.pgmId = pgmId;
		this.pgmNm = pgmNm;
		this.sysId = sysId;
		this.sysNm = sysNm;
	}

	public String getPgmId() {
		return pgmId;
	}

	public void setPgmId(String pgmId) {
		this.pgmId = pgmId;
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
