package nta.med.data.model.ihis.ocsa;

public class OCS0103U16GrdSlipHangmogInfo {
	private String slipCode;
	private String position;
	private Double seq;
	private String hangmogCode;
	private String hangmogName;
	private String specimenCode;
	private String groupYn;
	private String bulyongCheck;
	private String wonnaeDrgYn;
	private String orderByKey;
	private String trialFlg;

	public OCS0103U16GrdSlipHangmogInfo(String slipCode, String position,
			Double seq, String hangmogCode, String hangmogName,
			String specimenCode, String groupYn, String bulyongCheck,
			String wonnaeDrgYn, String orderByKey, String trialFlg) {
		super();
		this.slipCode = slipCode;
		this.position = position;
		this.seq = seq;
		this.hangmogCode = hangmogCode;
		this.hangmogName = hangmogName;
		this.specimenCode = specimenCode;
		this.groupYn = groupYn;
		this.bulyongCheck = bulyongCheck;
		this.wonnaeDrgYn = wonnaeDrgYn;
		this.orderByKey = orderByKey;
		this.trialFlg = trialFlg;
	}

	public String getSlipCode() {
		return slipCode;
	}

	public void setSlipCode(String slipCode) {
		this.slipCode = slipCode;
	}

	public String getPosition() {
		return position;
	}

	public void setPosition(String position) {
		this.position = position;
	}

	public Double getSeq() {
		return seq;
	}

	public void setSeq(Double seq) {
		this.seq = seq;
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

	public String getSpecimenCode() {
		return specimenCode;
	}

	public void setSpecimenCode(String specimenCode) {
		this.specimenCode = specimenCode;
	}

	public String getGroupYn() {
		return groupYn;
	}

	public void setGroupYn(String groupYn) {
		this.groupYn = groupYn;
	}

	public String getBulyongCheck() {
		return bulyongCheck;
	}

	public void setBulyongCheck(String bulyongCheck) {
		this.bulyongCheck = bulyongCheck;
	}

	public String getWonnaeDrgYn() {
		return wonnaeDrgYn;
	}

	public void setWonnaeDrgYn(String wonnaeDrgYn) {
		this.wonnaeDrgYn = wonnaeDrgYn;
	}

	public String getOrderByKey() {
		return orderByKey;
	}

	public void setOrderByKey(String orderByKey) {
		this.orderByKey = orderByKey;
	}

	public String getTrialFlag() {
		return trialFlg;
	}

	public void setTrialFlag(String trialFlg) {
		this.trialFlg = trialFlg;
	}

}