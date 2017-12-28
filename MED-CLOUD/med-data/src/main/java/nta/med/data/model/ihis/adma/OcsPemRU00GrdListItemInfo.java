package nta.med.data.model.ihis.adma;

public class OcsPemRU00GrdListItemInfo {
	private String sysId;
	private String pgmId;
	private String pgmNm;
	private String dwId;
	private String shetshtid;
	private String sheetname;

	public OcsPemRU00GrdListItemInfo(String sysId, String pgmId, String pgmNm,
			String dwId, String shetshtid, String sheetname) {
		super();
		this.sysId = sysId;
		this.pgmId = pgmId;
		this.pgmNm = pgmNm;
		this.dwId = dwId;
		this.shetshtid = shetshtid;
		this.sheetname = sheetname;
	}

	public String getSysId() {
		return sysId;
	}

	public void setSysId(String sysId) {
		this.sysId = sysId;
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

	public String getDwId() {
		return dwId;
	}

	public void setDwId(String dwId) {
		this.dwId = dwId;
	}

	public String getShetshtid() {
		return shetshtid;
	}

	public void setShetshtid(String shetshtid) {
		this.shetshtid = shetshtid;
	}

	public String getSheetname() {
		return sheetname;
	}

	public void setSheetname(String sheetname) {
		this.sheetname = sheetname;
	}

}
