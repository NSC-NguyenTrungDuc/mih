package nta.med.data.model.ihis.ocsa;

public class Ocs0131U01Grd0132ListItemInfo {
	private String code;
	private String codeName;
	private Double sortKey;
	private String groupKey;
	private String ment;
	private Double valuePoint;
	private String userId;
	private String codeType;
	public Ocs0131U01Grd0132ListItemInfo(String code, String codeName,
			Double sortKey, String groupKey, String ment, Double valuePoint,
			String userId, String codeType) {
		super();
		this.code = code;
		this.codeName = codeName;
		this.sortKey = sortKey;
		this.groupKey = groupKey;
		this.ment = ment;
		this.valuePoint = valuePoint;
		this.userId = userId;
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
	public String getGroupKey() {
		return groupKey;
	}
	public void setGroupKey(String groupKey) {
		this.groupKey = groupKey;
	}
	public String getMent() {
		return ment;
	}
	public void setMent(String ment) {
		this.ment = ment;
	}
	public Double getValuePoint() {
		return valuePoint;
	}
	public void setValuePoint(Double valuePoint) {
		this.valuePoint = valuePoint;
	}
	public String getUserId() {
		return userId;
	}
	public void setUserId(String userId) {
		this.userId = userId;
	}
	public String getCodeType() {
		return codeType;
	}
	public void setCodeType(String codeType) {
		this.codeType = codeType;
	}
}
