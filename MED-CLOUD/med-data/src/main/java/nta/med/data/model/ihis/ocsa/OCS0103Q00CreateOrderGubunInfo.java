package nta.med.data.model.ihis.ocsa;

public class OCS0103Q00CreateOrderGubunInfo {
	private String code;
	private String codeName;
	private Double sortKey;
	public OCS0103Q00CreateOrderGubunInfo(String code, String codeName,
			Double sortKey) {
		super();
		this.code = code;
		this.codeName = codeName;
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
	public Double getSortKey() {
		return sortKey;
	}
	public void setSortKey(Double sortKey) {
		this.sortKey = sortKey;
	}
}
