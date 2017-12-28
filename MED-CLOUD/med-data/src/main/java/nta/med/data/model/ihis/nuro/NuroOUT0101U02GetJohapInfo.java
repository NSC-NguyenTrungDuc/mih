package nta.med.data.model.ihis.nuro;

import java.io.Serializable;

public class NuroOUT0101U02GetJohapInfo implements Serializable{
	 private String johapName;
	 private String johapGubun;
	public NuroOUT0101U02GetJohapInfo(String johapName, String johapGubun) {
		super();
		this.johapName = johapName;
		this.johapGubun = johapGubun;
	}
	public String getJohapName() {
		return johapName;
	}
	public void setJohapName(String johapName) {
		this.johapName = johapName;
	}
	public String getJohapGubun() {
		return johapGubun;
	}
	public void setJohapGubun(String johapGubun) {
		this.johapGubun = johapGubun;
	}
	
	
	 
	 
}
