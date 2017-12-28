package nta.med.data.model.ihis.nuro;

import java.io.Serializable;

public class NuroOUT0101U02GetInsuranceInfo2 implements Serializable {
	 private String insuranceCode;
	 private String insuranceName;
	 
	public NuroOUT0101U02GetInsuranceInfo2(String insuranceCode,
			String insuranceName) {
		super();
		this.insuranceCode = insuranceCode;
		this.insuranceName = insuranceName;
	}
	public String getInsuranceCode() {
		return insuranceCode;
	}
	public void setInsuranceCode(String insuranceCode) {
		this.insuranceCode = insuranceCode;
	}
	public String getInsuranceName() {
		return insuranceName;
	}
	public void setInsuranceName(String insuranceName) {
		this.insuranceName = insuranceName;
	}
	 
	
	 
	 
}
