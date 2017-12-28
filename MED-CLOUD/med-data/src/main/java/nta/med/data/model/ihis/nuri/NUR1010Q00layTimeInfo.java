package nta.med.data.model.ihis.nuri;

public class NUR1010Q00layTimeInfo {
	private String code;
	private String codeName;
	private String groupKey;
	
	public NUR1010Q00layTimeInfo(String code, String codeName, String groupKey) {
		super();
		this.code = code;
		this.codeName = codeName;
		this.groupKey = groupKey;
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

	public String getGroupKey() {
		return groupKey;
	}

	public void setGroupKey(String groupKey) {
		this.groupKey = groupKey;
	}

}
