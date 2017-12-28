package nta.med.data.model.ihis.schs;

public class ResultAndMessageCode {
	Boolean result;
	String msg;
	
	public ResultAndMessageCode() {
		super();
	}
	public ResultAndMessageCode(Boolean result, String msg) {
		super();
		this.result = result;
		this.msg = msg;
	}
	public Boolean getResult() {
		return result;
	}
	public void setResult(Boolean result) {
		this.result = result;
	}
	public String getMsg() {
		return msg;
	}
	public void setMsg(String msg) {
		this.msg = msg;
	}
	
}
