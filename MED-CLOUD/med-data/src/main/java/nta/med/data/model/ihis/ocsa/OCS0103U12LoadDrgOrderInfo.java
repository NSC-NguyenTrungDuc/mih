package nta.med.data.model.ihis.ocsa;

public class OCS0103U12LoadDrgOrderInfo {
	private String hangmogCode;
	private String hangmogName;
	private String wonyoiOrderCrYn;
	private String defaultWonyoiOrderYn;
	private String code1;
	private String drgInfo;
	private String orderGubun;
	private String orderGubunName;
	private String trialFlag;
	private String wonnaeDrgYn;

	public OCS0103U12LoadDrgOrderInfo(String hangmogCode, String hangmogName,
			String wonyoiOrderCrYn, String defaultWonyoiOrderYn, String code1,
			String drgInfo, String orderGubun, String orderGubunName,
			String trialFlag, String wonnaeDrgYn) {
		super();
		this.hangmogCode = hangmogCode;
		this.hangmogName = hangmogName;
		this.wonyoiOrderCrYn = wonyoiOrderCrYn;
		this.defaultWonyoiOrderYn = defaultWonyoiOrderYn;
		this.code1 = code1;
		this.drgInfo = drgInfo;
		this.orderGubun = orderGubun;
		this.orderGubunName = orderGubunName;
		this.trialFlag = trialFlag;
		this.wonnaeDrgYn = wonnaeDrgYn;
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

	public String getWonyoiOrderCrYn() {
		return wonyoiOrderCrYn;
	}

	public void setWonyoiOrderCrYn(String wonyoiOrderCrYn) {
		this.wonyoiOrderCrYn = wonyoiOrderCrYn;
	}

	public String getDefaultWonyoiOrderYn() {
		return defaultWonyoiOrderYn;
	}

	public void setDefaultWonyoiOrderYn(String defaultWonyoiOrderYn) {
		this.defaultWonyoiOrderYn = defaultWonyoiOrderYn;
	}

	public String getCode1() {
		return code1;
	}

	public void setCode1(String code1) {
		this.code1 = code1;
	}

	public String getDrgInfo() {
		return drgInfo;
	}

	public void setDrgInfo(String drgInfo) {
		this.drgInfo = drgInfo;
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

	public String getWonnaeDrgYn() {
		return wonnaeDrgYn;
	}

	public void setWonnaeDrgYn(String wonnaeDrgYn) {
		this.wonnaeDrgYn = wonnaeDrgYn;
	}

	public String getTrialFlag() {
		return trialFlag;
	}

	public void setTrialFlag(String trialFlag) {
		this.trialFlag = trialFlag;
	}
}
