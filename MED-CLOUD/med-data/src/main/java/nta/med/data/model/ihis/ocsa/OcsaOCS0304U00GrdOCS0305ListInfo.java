package nta.med.data.model.ihis.ocsa;

public class OcsaOCS0304U00GrdOCS0305ListInfo {
	private String memb;
	private String yaksokDirectCode;
	private Double pkSeq;
	private String directGubun;
	private String nurGrName;
	private String directCode;
	private String nurMdName;
	private String directCont1;
	private String directCont2;
	private String directText;
	private String directContYn;

	public OcsaOCS0304U00GrdOCS0305ListInfo(String memb,
			String yaksokDirectCode, Double pkSeq, String directGubun,
			String nurGrName, String directCode, String nurMdName,
			String directCont1, String directCont2, String directText,
			String directContYn) {
		super();
		this.memb = memb;
		this.yaksokDirectCode = yaksokDirectCode;
		this.pkSeq = pkSeq;
		this.directGubun = directGubun;
		this.nurGrName = nurGrName;
		this.directCode = directCode;
		this.nurMdName = nurMdName;
		this.directCont1 = directCont1;
		this.directCont2 = directCont2;
		this.directText = directText;
		this.directContYn = directContYn;
	}

	public String getMemb() {
		return memb;
	}

	public void setMemb(String memb) {
		this.memb = memb;
	}

	public String getYaksokDirectCode() {
		return yaksokDirectCode;
	}

	public void setYaksokDirectCode(String yaksokDirectCode) {
		this.yaksokDirectCode = yaksokDirectCode;
	}

	public Double getPkSeq() {
		return pkSeq;
	}

	public void setPkSeq(Double pkSeq) {
		this.pkSeq = pkSeq;
	}

	public String getDirectGubun() {
		return directGubun;
	}

	public void setDirectGubun(String directGubun) {
		this.directGubun = directGubun;
	}

	public String getNurGrName() {
		return nurGrName;
	}

	public void setNurGrName(String nurGrName) {
		this.nurGrName = nurGrName;
	}

	public String getDirectCode() {
		return directCode;
	}

	public void setDirectCode(String directCode) {
		this.directCode = directCode;
	}

	public String getNurMdName() {
		return nurMdName;
	}

	public void setNurMdName(String nurMdName) {
		this.nurMdName = nurMdName;
	}

	public String getDirectCont1() {
		return directCont1;
	}

	public void setDirectCont1(String directCont1) {
		this.directCont1 = directCont1;
	}

	public String getDirectCont2() {
		return directCont2;
	}

	public void setDirectCont2(String directCont2) {
		this.directCont2 = directCont2;
	}

	public String getDirectText() {
		return directText;
	}

	public void setDirectText(String directText) {
		this.directText = directText;
	}

	public String getDirectContYn() {
		return directContYn;
	}

	public void setDirectContYn(String directContYn) {
		this.directContYn = directContYn;
	}

}
