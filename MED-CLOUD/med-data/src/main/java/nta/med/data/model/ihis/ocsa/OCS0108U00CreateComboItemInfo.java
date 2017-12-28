package nta.med.data.model.ihis.ocsa;

public class OCS0108U00CreateComboItemInfo {
	private String code;
	private String codeName;
	private String seq;
	public OCS0108U00CreateComboItemInfo(String code, String codeName,
			String seq) {
		super();
		this.code = code;
		this.codeName = codeName;
		this.seq = seq;
	}
	public String getCode() {
		return code;
	}
	public void setCode(String code) {
		this.code = code;
	}
	public String getCodeName() {
		return codeName;
	}
	public void setCodeName(String codeName) {
		this.codeName = codeName;
	}
	public String getSeq() {
		return seq;
	}
	public void setSeq(String seq) {
		this.seq = seq;
	}
	

}
