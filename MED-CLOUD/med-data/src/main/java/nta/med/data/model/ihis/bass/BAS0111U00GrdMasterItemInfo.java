package nta.med.data.model.ihis.bass;

import java.io.Serializable;

public class BAS0111U00GrdMasterItemInfo implements Serializable{
	private String johapGubun ;
	private String johap ;
	private String johapName ;
	public BAS0111U00GrdMasterItemInfo(String johapGubun, String johap,
			String johapName) {
		super();
		this.johapGubun = johapGubun;
		this.johap = johap;
		this.johapName = johapName;
	}
	public String getJohapGubun() {
		return johapGubun;
	}
	public void setJohapGubun(String johapGubun) {
		this.johapGubun = johapGubun;
	}
	public String getJohap() {
		return johap;
	}
	public void setJohap(String johap) {
		this.johap = johap;
	}
	public String getJohapName() {
		return johapName;
	}
	public void setJohapName(String johapName) {
		this.johapName = johapName;
	}

}
