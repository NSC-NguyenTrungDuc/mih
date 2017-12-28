package nta.med.data.model.ihis.drgs;

public class DRG3010Q12AntibioticListgrdAntibioticListInfo {
	private String hangmogCode;
	private String hangmogName;
	private String orderGubun;
	private String yakKijunCode;
	private String smallCode;
	
	public DRG3010Q12AntibioticListgrdAntibioticListInfo(String hangmogCode, String hangmogName, String orderGubun, String yakKijunCode, String smallCode){
		this.hangmogCode = hangmogCode;
		this.hangmogName = hangmogName;
		this.orderGubun = orderGubun;
		this.yakKijunCode = yakKijunCode;
		this.smallCode = smallCode;
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

	public String getYakKijunCode() {
		return yakKijunCode;
	}

	public void setYakKijunCode(String yakKijunCode) {
		this.yakKijunCode = yakKijunCode;
	}

	public String getSmallCode() {
		return smallCode;
	}

	public void setSmallCode(String smallCode) {
		this.smallCode = smallCode;
	}
	
}
