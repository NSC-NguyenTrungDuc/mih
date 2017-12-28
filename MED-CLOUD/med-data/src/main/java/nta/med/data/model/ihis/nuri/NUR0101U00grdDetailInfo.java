package nta.med.data.model.ihis.nuri;

public class NUR0101U00grdDetailInfo {	
	private String codeType;
	private String code;
	private String codeName;
	private String sortKey;
	private String groupKey;
	private String startDate;
	private String endDate;
	private String ment;
	private String key;
	private String endYn;
	private String dataRowState;
	
	public NUR0101U00grdDetailInfo(String codeType, String code, String codeName, String sortKey, String groupKey,
			String startDate, String endDate, String ment, String key, String endYn, String dataRowState) {
		super();
		this.codeType = codeType;
		this.code = code;
		this.codeName = codeName;
		this.sortKey = sortKey;
		this.groupKey = groupKey;
		this.startDate = startDate;
		this.endDate = endDate;
		this.ment = ment;
		this.key = key;
		this.endYn = endYn;
		this.dataRowState = dataRowState;
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

	public String getGroupKey() {
		return groupKey;
	}

	public void setGroupKey(String groupKey) {
		this.groupKey = groupKey;
	}

	public String getStartDate() {
		return startDate;
	}

	public void setStartDate(String startDate) {
		this.startDate = startDate;
	}

	public String getEndDate() {
		return endDate;
	}

	public void setEndDate(String endDate) {
		this.endDate = endDate;
	}

	public String getMent() {
		return ment;
	}

	public void setMent(String ment) {
		this.ment = ment;
	}

	public String getKey() {
		return key;
	}

	public void setKey(String key) {
		this.key = key;
	}

	public String getEndYn() {
		return endYn;
	}

	public void setEndYn(String endYn) {
		this.endYn = endYn;
	}

	public String getDataRowState() {
		return dataRowState;
	}

	public void setDataRowState(String dataRowState) {
		this.dataRowState = dataRowState;
	}
	
}
