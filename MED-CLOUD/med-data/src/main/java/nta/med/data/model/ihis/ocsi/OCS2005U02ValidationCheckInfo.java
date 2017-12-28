package nta.med.data.model.ihis.ocsi;

public class OCS2005U02ValidationCheckInfo {

	private String msgGetpkinp1001;
	private String msgIsnutcheckfromtodateObj;
	private String msg;
	private String bresult;
	
	public OCS2005U02ValidationCheckInfo(String msgGetpkinp1001, String msgIsnutcheckfromtodateObj, String msg, String bresult){
		this.msgGetpkinp1001 = msgGetpkinp1001;
		this.msgIsnutcheckfromtodateObj = msgIsnutcheckfromtodateObj;
		this.msg = msg;
		this.bresult = bresult;
	}

	public String getMsgGetpkinp1001() {
		return msgGetpkinp1001;
	}

	public void setMsgGetpkinp1001(String msgGetpkinp1001) {
		this.msgGetpkinp1001 = msgGetpkinp1001;
	}

	public String getMsgIsnutcheckfromtodateObj() {
		return msgIsnutcheckfromtodateObj;
	}

	public void setMsgIsnutcheckfromtodateObj(String msgIsnutcheckfromtodateObj) {
		this.msgIsnutcheckfromtodateObj = msgIsnutcheckfromtodateObj;
	}

	public String getMsg() {
		return msg;
	}

	public void setMsg(String msg) {
		this.msg = msg;
	}

	public String getBresult() {
		return bresult;
	}

	public void setBresult(String bresult) {
		this.bresult = bresult;
	}
}
