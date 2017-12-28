package nta.med.data.model.ihis.xrts;

import java.io.Serializable;

public class XRT0122U00GrdDcodeInfo implements Serializable {
	private String buwiBunryu;
	private String buwiCode;
	private String buwiName;
	private Double sortSeq;
	private String key;

	public XRT0122U00GrdDcodeInfo(String buwiBunryu, String buwiCode,
			String buwiName, Double sortSeq, String key) {
		super();
		this.buwiBunryu = buwiBunryu;
		this.buwiCode = buwiCode;
		this.buwiName = buwiName;
		this.sortSeq = sortSeq;
		this.key = key;
	}

	public String getBuwiBunryu() {
		return buwiBunryu;
	}

	public void setBuwiBunryu(String buwiBunryu) {
		this.buwiBunryu = buwiBunryu;
	}

	public String getBuwiCode() {
		return buwiCode;
	}

	public void setBuwiCode(String buwiCode) {
		this.buwiCode = buwiCode;
	}

	public String getBuwiName() {
		return buwiName;
	}

	public void setBuwiName(String buwiName) {
		this.buwiName = buwiName;
	}

	public Double getSortSeq() {
		return sortSeq;
	}

	public void setSortSeq(Double sortSeq) {
		this.sortSeq = sortSeq;
	}

	public String getKey() {
		return key;
	}

	public void setKey(String key) {
		this.key = key;
	}

}
