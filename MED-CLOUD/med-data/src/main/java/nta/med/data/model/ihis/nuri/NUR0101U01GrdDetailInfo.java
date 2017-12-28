package nta.med.data.model.ihis.nuri;

public class NUR0101U01GrdDetailInfo {
	private String codeType;
    private String code;
    private String codeName;
    private Double sortKey;
    private String key;
	public NUR0101U01GrdDetailInfo(String codeType, String code,
			String codeName, Double sortKey, String key) {
		super();
		this.codeType = codeType;
		this.code = code;
		this.codeName = codeName;
		this.sortKey = sortKey;
		this.key = key;
	}
	public String getCodeType() {
		return codeType;
	}
	public void setCodeType(String codeType) {
		this.codeType = codeType;
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
	public Double getSortKey() {
		return sortKey;
	}
	public void setSortKey(Double sortKey) {
		this.sortKey = sortKey;
	}
	public String getKey() {
		return key;
	}
	public void setKey(String key) {
		this.key = key;
	}
}
