package nta.med.data.model.ihis.chts;

import java.io.Serializable;

public class CHT0117Q00GrdCHT0118Info implements Serializable {
	private String buwi;
    private String subBuwi;
    private String subBuwiName;
    private String contKey;
	public CHT0117Q00GrdCHT0118Info(String buwi, String subBuwi,
			String subBuwiName, String contKey) {
		super();
		this.buwi = buwi;
		this.subBuwi = subBuwi;
		this.subBuwiName = subBuwiName;
		this.contKey = contKey;
	}
	public String getBuwi() {
		return buwi;
	}
	public void setBuwi(String buwi) {
		this.buwi = buwi;
	}
	public String getSubBuwi() {
		return subBuwi;
	}
	public void setSubBuwi(String subBuwi) {
		this.subBuwi = subBuwi;
	}
	public String getSubBuwiName() {
		return subBuwiName;
	}
	public void setSubBuwiName(String subBuwiName) {
		this.subBuwiName = subBuwiName;
	}
	public String getContKey() {
		return contKey;
	}
	public void setContKey(String contKey) {
		this.contKey = contKey;
	}
}
