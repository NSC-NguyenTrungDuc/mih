package nta.med.data.model.ihis.injs;

public class InjsINJ1001U01XEditGridCell89ItemInfo {
	private String code;
	private String codeName;
	private String sortKey;

	public InjsINJ1001U01XEditGridCell89ItemInfo(String code, String codeName,
			String sortKey) {
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

	public String getSortKey() {
		return sortKey;
	}

	public void setSortKey(String sortKey) {
		this.sortKey = sortKey;
	}

}
