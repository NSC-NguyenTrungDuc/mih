package nta.med.data.model.ihis.orca;

public class ORCATransferOrdersHealthInsuranceInfo {
	private String priorityNumber         ;
	private String providerName           ;
	private String publicStartDate        ;
	private String publicEndDate          ;
	private String encounterDate          ;
	private String insuranceCode          ;
	private String insuranceNumber        ;
	private String insuranceStartDate     ;
	private String insuranceEndDate       ;
	public ORCATransferOrdersHealthInsuranceInfo(String priorityNumber,
			String providerName, String publicStartDate, String publicEndDate,
			String encounterDate, String insuranceCode, String insuranceNumber,
			String insuranceStartDate, String insuranceEndDate) {
		super();
		this.priorityNumber = priorityNumber;
		this.providerName = providerName;
		this.publicStartDate = publicStartDate;
		this.publicEndDate = publicEndDate;
		this.encounterDate = encounterDate;
		this.insuranceCode = insuranceCode;
		this.insuranceNumber = insuranceNumber;
		this.insuranceStartDate = insuranceStartDate;
		this.insuranceEndDate = insuranceEndDate;
	}
	public String getPriorityNumber() {
		return priorityNumber;
	}
	public void setPriorityNumber(String priorityNumber) {
		this.priorityNumber = priorityNumber;
	}
	public String getProviderName() {
		return providerName;
	}
	public void setProviderName(String providerName) {
		this.providerName = providerName;
	}
	public String getPublicStartDate() {
		return publicStartDate;
	}
	public void setPublicStartDate(String publicStartDate) {
		this.publicStartDate = publicStartDate;
	}
	public String getPublicEndDate() {
		return publicEndDate;
	}
	public void setPublicEndDate(String publicEndDate) {
		this.publicEndDate = publicEndDate;
	}
	public String getEncounterDate() {
		return encounterDate;
	}
	public void setEncounterDate(String encounterDate) {
		this.encounterDate = encounterDate;
	}
	public String getInsuranceCode() {
		return insuranceCode;
	}
	public void setInsuranceCode(String insuranceCode) {
		this.insuranceCode = insuranceCode;
	}
	public String getInsuranceNumber() {
		return insuranceNumber;
	}
	public void setInsuranceNumber(String insuranceNumber) {
		this.insuranceNumber = insuranceNumber;
	}
	public String getInsuranceStartDate() {
		return insuranceStartDate;
	}
	public void setInsuranceStartDate(String insuranceStartDate) {
		this.insuranceStartDate = insuranceStartDate;
	}
	public String getInsuranceEndDate() {
		return insuranceEndDate;
	}
	public void setInsuranceEndDate(String insuranceEndDate) {
		this.insuranceEndDate = insuranceEndDate;
	}
	
}
