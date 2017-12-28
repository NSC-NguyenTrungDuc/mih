package nta.med.data.model.ihis.ocso;

public class OcsoOCS1003P01GetChuciInfo {
	 private String code;
     private String groupKey;
	public OcsoOCS1003P01GetChuciInfo(String code, String groupKey) {
		super();
		this.code = code;
		this.groupKey = groupKey;
	}
	public String getCode() {
		return code;
	}
	public void setCode(String code) {
		this.code = code;
	}
	public String getGroupKey() {
		return groupKey;
	}
	public void setGroupKey(String groupKey) {
		this.groupKey = groupKey;
	}
     
}
