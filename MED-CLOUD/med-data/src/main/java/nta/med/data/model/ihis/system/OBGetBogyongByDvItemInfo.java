package nta.med.data.model.ihis.system;

import java.io.Serializable;

public class OBGetBogyongByDvItemInfo implements Serializable {
	private String bogyoungGubun ; 
	private String banghyang ;
	public OBGetBogyongByDvItemInfo(String bogyoungGubun, String banghyang) {
		super();
		this.bogyoungGubun = bogyoungGubun;
		this.banghyang = banghyang;
	}
	public String getBogyoungGubun() {
		return bogyoungGubun;
	}
	public void setBogyoungGubun(String bogyoungGubun) {
		this.bogyoungGubun = bogyoungGubun;
	}
	public String getBanghyang() {
		return banghyang;
	}
	public void setBanghyang(String banghyang) {
		this.banghyang = banghyang;
	}
	

}
