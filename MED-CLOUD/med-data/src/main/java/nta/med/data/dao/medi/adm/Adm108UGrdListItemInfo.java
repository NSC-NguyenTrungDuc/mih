package nta.med.data.dao.medi.adm;

public class Adm108UGrdListItemInfo {
	private String sysId;
	private Double seq;
	private String pgmSysId;
	private String sysNm;
	private String pgmId;
	private String pgmNm;

	public Adm108UGrdListItemInfo(String sysId, Double seq, String pgmSysId,
			String sysNm, String pgmId, String pgmNm) {
		super();
		this.sysId = sysId;
		this.seq = seq;
		this.pgmSysId = pgmSysId;
		this.sysNm = sysNm;
		this.pgmId = pgmId;
		this.pgmNm = pgmNm;
	}

	public String getSysId() {
		return sysId;
	}

	public void setSysId(String sysId) {
		this.sysId = sysId;
	}

	public Double getSeq() {
		return seq;
	}

	public void setSeq(Double seq) {
		this.seq = seq;
	}

	public String getPgmSysId() {
		return pgmSysId;
	}

	public void setPgmSysId(String pgmSysId) {
		this.pgmSysId = pgmSysId;
	}

	public String getSysNm() {
		return sysNm;
	}

	public void setSysNm(String sysNm) {
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

}