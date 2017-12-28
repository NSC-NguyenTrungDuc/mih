package nta.med.data.model.ihis.system;

public class FormScreenInfo {
	private String sysId;
    private String pgmNm;
    private Double pgmEntGrad;
    private Double pgmUpdGrad;
    private String pgmScrt;
    private String pgmDupYn;
    private String asmName;
    private String asmPath;
    private String asmVer;
    private String grpId;
	public FormScreenInfo(String sysId, String pgmNm, Double pgmEntGrad,
			Double pgmUpdGrad, String pgmScrt, String pgmDupYn, String asmName,
			String asmPath, String asmVer, String grpId) {
		super();
		this.sysId = sysId;
		this.pgmNm = pgmNm;
		this.pgmEntGrad = pgmEntGrad;
		this.pgmUpdGrad = pgmUpdGrad;
		this.pgmScrt = pgmScrt;
		this.pgmDupYn = pgmDupYn;
		this.asmName = asmName;
		this.asmPath = asmPath;
		this.asmVer = asmVer;
		this.grpId = grpId;
	}
	public String getSysId() {
		return sysId;
	}
	public void setSysId(String sysId) {
		this.sysId = sysId;
	}
	public String getPgmNm() {
		return pgmNm;
	}
	public void setPgmNm(String pgmNm) {
		this.pgmNm = pgmNm;
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
	public String getGrpId() {
		return grpId;
	}
	public void setGrpId(String grpId) {
		this.grpId = grpId;
	}
    
	}
