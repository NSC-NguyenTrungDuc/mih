package nta.med.data.model.ihis.system;

import java.io.Serializable;

public class LoadSearchOrderInfo implements Serializable {
	private String slipCode;
	private String slipName;
	private String hangmogCode;
	private String hangmogName;
	private String wonnaeDrgYn;
	private String yakKijunCode;
	private String trialFlag;

	public LoadSearchOrderInfo(String slipCode, String slipName,
			String hangmogCode, String hangmogName, String wonnaeDrgYn,
			String yakKijunCode, String trialFlag) {
		super();
		this.slipCode = slipCode;
		this.slipName = slipName;
		this.hangmogCode = hangmogCode;
		this.hangmogName = hangmogName;
		this.wonnaeDrgYn = wonnaeDrgYn;
		this.yakKijunCode = yakKijunCode;
		this.trialFlag = trialFlag;
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

	public String getYakKijunCode() {
		return yakKijunCode;
	}

	public void setYakKijunCode(String yakKijunCode) {
		this.yakKijunCode = yakKijunCode;
	}

	public String getTrialFlag() {
		return trialFlag;
	}

	public void setTrialFlag(String trialFlag) {
		this.trialFlag = trialFlag;
	}

}
