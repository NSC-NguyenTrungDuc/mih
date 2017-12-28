package nta.med.data.model.ihis.bass;

public class BAS0001U00FbxDodobuHyeunDataValidatingInfo {
	private String codeName;
	private Double sortKey;
	public BAS0001U00FbxDodobuHyeunDataValidatingInfo(String codeName,
			Double sortKey) {
		super();
		this.codeName = codeName;
		this.sortKey = sortKey;
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
