package nta.med.data.model.ihis.ocsa;

public class OCS0103U10GrdGeneralInfo {
	private String slipCode     ;
	private String slipName     ;
	private String hangmogCode  ;
	private String hangmogName  ;
	private String wonnaeDrgYn ;
	public OCS0103U10GrdGeneralInfo(String slipCode, String slipName,
			String hangmogCode, String hangmogName, String wonnaeDrgYn) {
		super();
		this.slipCode = slipCode;
		this.slipName = slipName;
		this.hangmogCode = hangmogCode;
		this.hangmogName = hangmogName;
		this.wonnaeDrgYn = wonnaeDrgYn;
	}
	public String getSlipCode() {
		return slipCode;
	}
	public void setSlipCode(String slipCode) {
		this.slipCode = slipCode;
	}
	public String getSlipName() {
		return slipName;
	}
	public void setSlipName(String slipName) {
		this.slipName = slipName;
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
	public String getWonnaeDrgYn() {
		return wonnaeDrgYn;
	}
	public void setWonnaeDrgYn(String wonnaeDrgYn) {
		this.wonnaeDrgYn = wonnaeDrgYn;
	}
	
	

}
