package nta.med.data.model.ihis.nuri;

public class NUR1123U00grdDetailInfo {

	private String codeType;
	private String code;
	private String codeName;
	private String sortKey;
	private String rowState;
	
	public NUR1123U00grdDetailInfo(String codeType, String code, String codeName, String sortKey, String rowState) {
		super();
		this.codeType = codeType;
		this.code = code;
		this.codeName = codeName;
		this.sortKey = sortKey;
		this.rowState = rowState;
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
	public String getSortKey() {
		return sortKey;
	}
	public void setSortKey(String sortKey) {
		this.sortKey = sortKey;
	}
	public String getRowState() {
		return rowState;
	}
	public void setRowState(String rowState) {
		this.rowState = rowState;
	}
	
}