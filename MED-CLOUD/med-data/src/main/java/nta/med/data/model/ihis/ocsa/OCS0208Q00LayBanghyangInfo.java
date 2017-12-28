package nta.med.data.model.ihis.ocsa;

import java.io.Serializable;

public class OCS0208Q00LayBanghyangInfo implements Serializable {
	private String banghyang ;
	private String donbogYn ;
	public OCS0208Q00LayBanghyangInfo(String banghyang, String donbogYn) {
		super();
		this.banghyang = banghyang;
		this.donbogYn = donbogYn;
	}
	public String getBanghyang() {
		return banghyang;
	}
	public void setBanghyang(String banghyang) {
		this.banghyang = banghyang;
	}
	public String getDonbogYn() {
		return donbogYn;
	}
	public void setDonbogYn(String donbogYn) {
		this.donbogYn = donbogYn;
	}
}
