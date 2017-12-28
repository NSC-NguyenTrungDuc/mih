package nta.med.data.model.ihis.nuri;

public class NUR1001U00LayComboSetInfo {
	private String code;
	private String codeName;
	private String codeType;
	private String sortKey;
	public NUR1001U00LayComboSetInfo(String code, String codeName, String codeType, String sortKey) {
		super();
		this.code = code;
		this.codeName = codeName;
		this.codeType = codeType;
		this.sortKey = sortKey;
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
	public String getCodeType() {
		return codeType;
	}
	public void setCodeType(String codeType) {
		this.codeType = codeType;
	}
	public String getSortKey() {
		return sortKey;
	}
	public void setSortKey(String sortKey) {
		this.sortKey = sortKey;
	}
	
}
