package nta.med.data.model.ihis.nuro;

public class NuroOUT0101U02GetInsuranceInfo {
	 private String insurance_code;
	 private String insurance_name;
	 
	public NuroOUT0101U02GetInsuranceInfo(String insurance_code,
			String insurance_name) {
		super();
		this.insurance_code = insurance_code;
		this.insurance_name = insurance_name;
	}
	public String getInsurance_code() {
		return insurance_code;
	}
	public void setInsurance_code(String insurance_code) {
		this.insurance_code = insurance_code;
	}
	public String getInsurance_name() {
		return insurance_name;
	}
	public void setInsurance_name(String insurance_name) {
		this.insurance_name = insurance_name;
	}
	 
	 
}
