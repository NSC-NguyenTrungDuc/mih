package nta.med.data.model.ihis.adma;

public class Adm106UMakeQueryListItemInfo {
	private String sysId;
	private String trId;
	private Double trSeq;
	private String pgmId;
	private String upprMenu;
	private String pgmNm;
	private String pgmTp;
	private String pgmOpenTp;
	private String shortCut;
	private String menuParam;

	public Adm106UMakeQueryListItemInfo(String sysId, String trId,
			Double trSeq, String pgmId, String upprMenu, String pgmNm,
			String pgmTp, String pgmOpenTp, String shortCut, String menuParam) {
		super();
		this.sysId = sysId;
		this.trId = trId;
		this.trSeq = trSeq;
		this.pgmId = pgmId;
		this.upprMenu = upprMenu;
		this.pgmNm = pgmNm;
		this.pgmTp = pgmTp;
		this.pgmOpenTp = pgmOpenTp;
		this.shortCut = shortCut;
		this.menuParam = menuParam;
	}

	public String getSysId() {
		return sysId;
	}

	public void setSysId(String sysId) {
		this.sysId = sysId;
	}

	public String getTrId() {
		return trId;
	}

	public void setTrId(String trId) {
		this.trId = trId;
	}

	public Double getTrSeq() {
		return trSeq;
	}

	public void setTrSeq(Double trSeq) {
		this.trSeq = trSeq;
	}

	public String getPgmId() {
		return pgmId;
	}

	public void setPgmId(String pgmId) {
		this.pgmId = pgmId;
	}

	public String getUpprMenu() {
		return upprMenu;
	}

	public void setUpprMenu(String upprMenu) {
		this.upprMenu = upprMenu;
	}

	public String getPgmNm() {
		return pgmNm;
	}

	public void setPgmNm(String pgmNm) {
		this.pgmNm = pgmNm;
	}

	public String getPgmTp() {
		return pgmTp;
	}

	public void setPgmTp(String pgmTp) {
		this.pgmTp = pgmTp;
	}

	public String getPgmOpenTp() {
		return pgmOpenTp;
	}

	public void setPgmOpenTp(String pgmOpenTp) {
		this.pgmOpenTp = pgmOpenTp;
	}

	public String getShortCut() {
		return shortCut;
	}

	public void setShortCut(String shortCut) {
		this.shortCut = shortCut;
	}

	public String getMenuParam() {
		return menuParam;
	}

	public void setMenuParam(String menuParam) {
		this.menuParam = menuParam;
	}

}