package nta.med.data.model.ihis.ocsa;

import java.io.Serializable;

public class OcsaOCS0204U00SangCodeListInfo implements Serializable {
	private String sangCode;
	private String sangName;
	public OcsaOCS0204U00SangCodeListInfo(String sangCode, String sangName) {
		super();
		this.sangCode = sangCode;
		this.sangName = sangName;
	}
	public String getSangCode() {
		return sangCode;
	}
	public void setSangCode(String sangCode) {
		this.sangCode = sangCode;
	}
	public String getSangName() {
		return sangName;
	}
	public void setSangName(String sangName) {
		this.sangName = sangName;
	}
	
}
