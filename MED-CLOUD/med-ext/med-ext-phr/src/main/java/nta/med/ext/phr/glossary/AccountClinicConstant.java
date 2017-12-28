package nta.med.ext.phr.glossary;

public enum AccountClinicConstant {
	HOSP_CODE("NTA"), 
	HOSP_NAME("NTA"),
	USER_NAME("PHR_COM_");
	
	private String value;

	private AccountClinicConstant(String value) {
		this.value = value;
	}

	public String getValue() {
		return value;
	}
	
	public String getValueName(Long profileId){
		return "PHR_COM_" + String.format("%010d%n", profileId);
	}
}
