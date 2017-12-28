package nta.med.data.model.ihis.ocsa;

public class OCS0103U11GrdSlipHangMogListItemInfo {
	private String hangmogCode ;
	private String hangmogName ;
	private String orderGubun ;
	private String orderGubunName ;
	private String comment ;
	public OCS0103U11GrdSlipHangMogListItemInfo(String hangmogCode,
			String hangmogName, String orderGubun, String orderGubunName,
			String comment) {
		super();
		this.hangmogCode = hangmogCode;
		this.hangmogName = hangmogName;
		this.orderGubun = orderGubun;
		this.orderGubunName = orderGubunName;
		this.comment = comment;
	}
	public String getHangmogCode() {
		return hangmogCode;
	}
	public void setHangmogCode(String hangmogCode) {
		this.hangmogCode = hangmogCode;
	}
	public String getHangmogName() {
		return hangmogName;
	}
	public void setHangmogName(String hangmogName) {
		this.hangmogName = hangmogName;
	}
	public String getOrderGubun() {
		return orderGubun;
	}
	public void setOrderGubun(String orderGubun) {
		this.orderGubun = orderGubun;
	}
	public String getOrderGubunName() {
		return orderGubunName;
	}
	public void setOrderGubunName(String orderGubunName) {
		this.orderGubunName = orderGubunName;
	}
	public String getComment() {
		return comment;
	}
	public void setComment(String comment) {
		this.comment = comment;
	} 
	
}
