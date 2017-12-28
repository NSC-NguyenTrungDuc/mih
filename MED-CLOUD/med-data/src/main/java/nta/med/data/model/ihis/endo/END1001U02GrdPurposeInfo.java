package nta.med.data.model.ihis.endo;

public class END1001U02GrdPurposeInfo {
	private String n         ;
	private String codeName ;
	public END1001U02GrdPurposeInfo(String n, String codeName) {
		super();
		this.n = n;
		this.codeName = codeName;
	}
	public String getN() {
		return n;
	}
	public void setN(String n) {
		this.n = n;
	}
	public String getCodeName() {
		return codeName;
	}
	public void setCodeName(String codeName) {
		this.codeName = codeName;
	}

}
