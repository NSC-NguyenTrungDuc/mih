package nta.med.data.model.ihis.adma;

public class Adm501UListItemInfo {
	private Double adm0002Pk;
	private String msgGubun;
	private String koreaMsg;
	private String japanMsg;
	private String speakMsg;
	public Adm501UListItemInfo(Double adm0002Pk, String msgGubun,
			String koreaMsg, String japanMsg, String speakMsg) {
		super();
		this.adm0002Pk = adm0002Pk;
		this.msgGubun = msgGubun;
		this.koreaMsg = koreaMsg;
		this.japanMsg = japanMsg;
		this.speakMsg = speakMsg;
	}
	public Double getAdm0002Pk() {
		return adm0002Pk;
	}
	public void setAdm0002Pk(Double adm0002Pk) {
		this.adm0002Pk = adm0002Pk;
	}
	public String getMsgGubun() {
		return msgGubun;
	}
	public void setMsgGubun(String msgGubun) {
		this.msgGubun = msgGubun;
	}
	public String getKoreaMsg() {
		return koreaMsg;
	}
	public void setKoreaMsg(String koreaMsg) {
		this.koreaMsg = koreaMsg;
	}
	public String getJapanMsg() {
		return japanMsg;
	}
	public void setJapanMsg(String japanMsg) {
		this.japanMsg = japanMsg;
	}
	public String getSpeakMsg() {
		return speakMsg;
	}
	public void setSpeakMsg(String speakMsg) {
		this.speakMsg = speakMsg;
	}
}
