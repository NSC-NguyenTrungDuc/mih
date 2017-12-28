package nta.med.data.model.ihis.adma;

public class Adm102UGrdListItemInfo {
	private String pgmId;
	private String pgmNm;
	private String pgmTp;
	private String sysId;
	private String prodId;
	private String srvcId;
	private Double pgmEntGrad;
	private Double pgmUpdGrad;
	private String pgmScrt;
	private String pgmDupYn;
	private String endYn;
	private String pgmAcsYn;
	private String mangMemb;
	private String asmName;

	public Adm102UGrdListItemInfo(String pgmId, String pgmNm, String pgmTp,
			String sysId, String prodId, String srvcId, Double pgmEntGrad,
			Double pgmUpdGrad, String pgmScrt, String pgmDupYn, String endYn,
			String pgmAcsYn, String mangMemb, String asmName) {
		super();
		this.pgmId = pgmId;
		this.pgmNm = pgmNm;
		this.pgmTp = pgmTp;
		this.sysId = sysId;
		this.prodId = prodId;
		this.srvcId = srvcId;
		this.pgmEntGrad = pgmEntGrad;
		this.pgmUpdGrad = pgmUpdGrad;
		this.pgmScrt = pgmScrt;
		this.pgmDupYn = pgmDupYn;
		this.endYn = endYn;
		this.pgmAcsYn = pgmAcsYn;
		this.mangMemb = mangMemb;
		this.asmName = asmName;
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

	public String getPgmTp() {
		return pgmTp;
	}

	public void setPgmTp(String pgmTp) {
		this.pgmTp = pgmTp;
	}

	public String getSysId() {
		return sysId;
	}

	public void setSysId(String sysId) {
		this.sysId = sysId;
	}

	public String getProdId() {
		return prodId;
	}

	public void setProdId(String prodId) {
		this.prodId = prodId;
	}

	public String getSrvcId() {
		return srvcId;
	}

	public void setSrvcId(String srvcId) {
		this.srvcId = srvcId;
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

	public String getEndYn() {
		return endYn;
	}

	public void setEndYn(String endYn) {
		this.endYn = endYn;
	}

	public String getPgmAcsYn() {
		return pgmAcsYn;
	}

	public void setPgmAcsYn(String pgmAcsYn) {
		this.pgmAcsYn = pgmAcsYn;
	}

	public String getMangMemb() {
		return mangMemb;
	}

	public void setMangMemb(String mangMemb) {
		this.mangMemb = mangMemb;
	}

	public String getAsmName() {
		return asmName;
	}

	public void setAsmName(String asmName) {
		this.asmName = asmName;
	}

}