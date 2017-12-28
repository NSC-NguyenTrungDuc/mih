	package nta.med.data.model.ihis.system;

public class MdiFormMenuItemInfo {
	private Double menuLevel;
    private String menuTp;
    private String pgmNm;
    private String trId;
    private String pgmId;
    private String pgmSysId;
    private Double pgmEntGrad;
    private Double pgmUpdGrad;
    private String pgmScrt;
    private String pgmDupYn;
    private String pgmOpenTp;
    private String shortCut;
    private String asmName;
    private String asmPath;
    private String asmVer;
    private String menuParam;
	public MdiFormMenuItemInfo(Double menuLevel, String menuTp, String pgmNm,
			String trId, String pgmId, String pgmSysId, Double pgmEntGrad,
			Double pgmUpdGrad, String pgmScrt, String pgmDupYn,
			String pgmOpenTp, String shortCut, String asmName, String asmPath,
			String asmVer, String menuParam) {
		super();
		this.menuLevel = menuLevel;
		this.menuTp = menuTp;
		this.pgmNm = pgmNm;
		this.trId = trId;
		this.pgmId = pgmId;
		this.pgmSysId = pgmSysId;
		this.pgmEntGrad = pgmEntGrad;
		this.pgmUpdGrad = pgmUpdGrad;
		this.pgmScrt = pgmScrt;
		this.pgmDupYn = pgmDupYn;
		this.pgmOpenTp = pgmOpenTp;
		this.shortCut = shortCut;
		this.asmName = asmName;
		this.asmPath = asmPath;
		this.asmVer = asmVer;
		this.menuParam = menuParam;
	}
	public Double getMenuLevel() {
		return menuLevel;
	}
	public void setMenuLevel(Double menuLevel) {
		this.menuLevel = menuLevel;
	}
	public String getMenuTp() {
		return menuTp;
	}
	public void setMenuTp(String menuTp) {
		this.menuTp = menuTp;
	}
	public String getPgmNm() {
		return pgmNm;
	}
	public void setPgmNm(String pgmNm) {
		this.pgmNm = pgmNm;
	}
	public String getTrId() {
		return trId;
	}
	public void setTrId(String trId) {
		this.trId = trId;
	}
	public String getPgmId() {
		return pgmId;
	}
	public void setPgmId(String pgmId) {
		this.pgmId = pgmId;
	}
	public String getPgmSysId() {
		return pgmSysId;
	}
	public void setPgmSysId(String pgmSysId) {
		this.pgmSysId = pgmSysId;
	}
	public Double getPgmEntGrad() {
		return pgmEntGrad;
	}
	public void setPgmEntGrad(Double pgmEntGrad) {
		this.pgmEntGrad = pgmEntGrad;
	}
	public Double getPgmUpdGrad() {
		return pgmUpdGrad;
	}
	public void setPgmUpdGrad(Double pgmUpdGrad) {
		this.pgmUpdGrad = pgmUpdGrad;
	}
	public String getPgmScrt() {
		return pgmScrt;
	}
	public void setPgmScrt(String pgmScrt) {
		this.pgmScrt = pgmScrt;
	}
	public String getPgmDupYn() {
		return pgmDupYn;
	}
	public void setPgmDupYn(String pgmDupYn) {
		this.pgmDupYn = pgmDupYn;
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
	public String getAsmName() {
		return asmName;
	}
	public void setAsmName(String asmName) {
		this.asmName = asmName;
	}
	public String getAsmPath() {
		return asmPath;
	}
	public void setAsmPath(String asmPath) {
		this.asmPath = asmPath;
	}
	public String getAsmVer() {
		return asmVer;
	}
	public void setAsmVer(String asmVer) {
		this.asmVer = asmVer;
	}
	public String getMenuParam() {
		return menuParam;
	}
	public void setMenuParam(String menuParam) {
		this.menuParam = menuParam;
	}
}
