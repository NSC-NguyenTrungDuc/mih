package nta.med.data.model.ihis.system;

public class LoadColumnCodeNameInfo {
	private String colName ;
	private String arg1 ;
	private String arg2 ;
	private String arg3 ;
	private String value ;
	public LoadColumnCodeNameInfo(String colName, String arg1, String arg2,
			String arg3, String value) {
		super();
		this.colName = colName;
		this.arg1 = arg1;
		this.arg2 = arg2;
		this.arg3 = arg3;
		this.value = value;
	}
	public String getColName() {
		return colName;
	}
	public void setColName(String colName) {
		this.colName = colName;
	}
	public String getArg1() {
		return arg1;
	}
	public void setArg1(String arg1) {
		this.arg1 = arg1;
	}
	public String getArg2() {
		return arg2;
	}
	public void setArg2(String arg2) {
		this.arg2 = arg2;
	}
	public String getArg3() {
		return arg3;
	}
	public void setArg3(String arg3) {
		this.arg3 = arg3;
	}
	public String getValue() {
		return value;
	}
	public void setValue(String value) {
		this.value = value;
	}
	

}
