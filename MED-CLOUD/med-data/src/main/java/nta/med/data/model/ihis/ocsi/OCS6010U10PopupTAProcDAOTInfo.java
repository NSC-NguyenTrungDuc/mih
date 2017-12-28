package nta.med.data.model.ihis.ocsi;

public class OCS6010U10PopupTAProcDAOTInfo {
	private String msg;
	private String flag;
	public OCS6010U10PopupTAProcDAOTInfo(String msg, String flag) {
		super();
		this.msg = msg;
		this.flag = flag;
	}
	public String getMsg() {
		return msg;
	}
	public void setMsg(String msg) {
		this.msg = msg;
	}
	public String getFlag() {
		return flag;
	}
	public void setFlag(String flag) {
		this.flag = flag;
	}
	
}
