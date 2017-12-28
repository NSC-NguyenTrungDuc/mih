package nta.med.data.model.ihis.ocsa;

public class OCS0103U13GrdSpecimenListInfo {
	private String sliCode;
	private String position;
	private Double seq;
	private String hangmogCode;
	private String hangmogName1;
	private String groupYn;
	private String bulyongCheck;
	private String wonnaeDrgYn;
	private String selectYn;
	private String hangmogName2;
	private String trialFlag;

	public OCS0103U13GrdSpecimenListInfo(String sliCode, String position,
			Double seq, String hangmogCode, String hangmogName1,
			String groupYn, String bulyongCheck, String wonnaeDrgYn,
			String selectYn, String hangmogName2, String trialFlag) {
		super();
		this.sliCode = sliCode;
		this.position = position;
		this.seq = seq;
		this.hangmogCode = hangmogCode;
		this.hangmogName1 = hangmogName1;
		this.groupYn = groupYn;
		this.bulyongCheck = bulyongCheck;
		this.wonnaeDrgYn = wonnaeDrgYn;
		this.selectYn = selectYn;
		this.hangmogName2 = hangmogName2;
		this.trialFlag = trialFlag;
	}

	public String getSliCode() {
		return sliCode;
	}

	public void setSliCode(String sliCode) {
		this.sliCode = sliCode;
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

	public String getHangmogName1() {
		return hangmogName1;
	}

	public void setHangmogName1(String hangmogName1) {
		this.hangmogName1 = hangmogName1;
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

	public String getSelectYn() {
		return selectYn;
	}

	public void setSelectYn(String selectYn) {
		this.selectYn = selectYn;
	}

	public String getHangmogName2() {
		return hangmogName2;
	}

	public void setHangmogName2(String hangmogName2) {
		this.hangmogName2 = hangmogName2;
	}

	public String getTrialFlag() {
		return trialFlag;
	}

	public void setTrialFlag(String trialFlag) {
		this.trialFlag = trialFlag;
	}

}