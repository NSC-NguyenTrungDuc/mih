package nta.med.data.model.ihis.system;

public class UdpHelperSendInfo {
	private String senderId;
    private String msgTitle;
    private String msgContents;
    private String recverId;
	public UdpHelperSendInfo(String senderId, String msgTitle,
			String msgContents, String recverId) {
		super();
		this.senderId = senderId;
		this.msgTitle = msgTitle;
		this.msgContents = msgContents;
		this.recverId = recverId;
	}
	public String getSenderId() {
		return senderId;
	}
	public void setSenderId(String senderId) {
		this.senderId = senderId;
	}
	public String getMsgTitle() {
		return msgTitle;
	}
	public void setMsgTitle(String msgTitle) {
		this.msgTitle = msgTitle;
	}
	public String getMsgContents() {
		return msgContents;
	}
	public void setMsgContents(String msgContents) {
		this.msgContents = msgContents;
	}
	public String getRecverId() {
		return recverId;
	}
	public void setRecverId(String recverId) {
		this.recverId = recverId;
	}
}
