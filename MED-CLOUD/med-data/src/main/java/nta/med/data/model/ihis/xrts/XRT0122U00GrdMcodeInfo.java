package nta.med.data.model.ihis.xrts;

import java.io.Serializable;

public class XRT0122U00GrdMcodeInfo implements Serializable{
	private static final long serialVersionUID = 1L;
	private String buwiBunryu;
	private String buwiBunryuName;

	public XRT0122U00GrdMcodeInfo(String buwiBunryu, String buwiBunryuName) {
		super();
		this.buwiBunryu = buwiBunryu;
		this.buwiBunryuName = buwiBunryuName;
	}

	public String getBuwiBunryu() {
		return buwiBunryu;
	}

	public void setBuwiBunryu(String buwiBunryu) {
		this.buwiBunryu = buwiBunryu;
	}

	public String getBuwiBunryuName() {
		return buwiBunryuName;
	}

	public void setBuwiBunryuName(String buwiBunryuName) {
		this.buwiBunryuName = buwiBunryuName;
	}

}
