package nta.med.data.model.ihis.nuro;

import java.io.Serializable;

public class NuroOUT0101U02GetInsuranceCode implements Serializable{
	private String insuranceCode;

	public NuroOUT0101U02GetInsuranceCode(String insuranceCode) {
		super();
		this.insuranceCode = insuranceCode;
	}

	public String getInsuranceCode() {
		return insuranceCode;
	}

	public void setInsuranceCode(String insuranceCode) {
		this.insuranceCode = insuranceCode;
	}
	
	
}
