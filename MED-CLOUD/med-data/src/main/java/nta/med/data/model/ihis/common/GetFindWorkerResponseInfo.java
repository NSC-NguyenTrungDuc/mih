package nta.med.data.model.ihis.common;

public class GetFindWorkerResponseInfo {
	private String code;
    private String name;
    private String value1;
    private String value2;
	public GetFindWorkerResponseInfo(String code, String name, String value1,
			String value2) {
		super();
		this.code = code;
		this.name = name;
		this.value1 = value1;
		this.value2 = value2;
	}
	public String getCode() {
		return code;
	}
	public void setCode(String code) {
		this.code = code;
	}
	public String getName() {
		return name;
	}
	public void setName(String name) {
		this.name = name;
	}
	public String getValue1() {
		return value1;
	}
	public void setValue1(String value1) {
		this.value1 = value1;
	}
	public String getValue2() {
		return value2;
	}
	public void setValue2(String value2) {
		this.value2 = value2;
	}
}
