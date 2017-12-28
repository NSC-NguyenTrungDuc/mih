package nta.med.orca.gw.api.contracts.message;

import java.util.List;
import java.util.Objects;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import com.fasterxml.jackson.dataformat.xml.annotation.JacksonXmlProperty;

@JsonIgnoreProperties(ignoreUnknown = true)
public class HealthInsuranceInfo {
	
	private String insuranceCombinationRateAdmission;
	private String insuranceCombinationRateOutpatient;
	private String healthInsuredPersonAssistanceName;
	private String insuranceCheckDate;
	
	private String insuranceCombinationNumber;
	private String insuranceProviderClass;
	private String insuranceProviderNumber;
	private String insuranceProviderWholeName;
	private String healthInsuredPersonSymbol;
	private String healthInsuredPersonNumber;
	private String healthInsuredPersonContinuation;
	private String healthInsuredPersonAssistance;
	private String relationToInsuredPerson;
	private String healthInsuredPersonWholeName;
	private String certificateStartDate;
	private String certificateExpiredDate;
	private List<PublicInsuranceInfo> publicInsuranceInformation;
	
	private String rateClass;
	private String certificateGetDate;
	
	@JacksonXmlProperty(localName = "Insurance_Combination_Number")
	public String getInsuranceCombinationNumber() {
		return insuranceCombinationNumber;
	}

	public void setInsuranceCombinationNumber(String insuranceCombinationNumber) {
		this.insuranceCombinationNumber = insuranceCombinationNumber;
	}

	@JacksonXmlProperty(localName = "InsuranceCombination_Rate_Admission")
	public String getInsuranceCombinationRateAdmission() {
		return insuranceCombinationRateAdmission;
	}

	public void setInsuranceCombinationRateAdmission(String insuranceCombinationRateAdmission) {
		this.insuranceCombinationRateAdmission = insuranceCombinationRateAdmission;
	}

	@JacksonXmlProperty(localName = "InsuranceCombination_Rate_Outpatient")
	public String getInsuranceCombinationRateOutpatient() {
		return insuranceCombinationRateOutpatient;
	}

	public void setInsuranceCombinationRateOutpatient(String insuranceCombinationRateOutpatient) {
		this.insuranceCombinationRateOutpatient = insuranceCombinationRateOutpatient;
	}

	@JacksonXmlProperty(localName = "HealthInsuredPerson_Assistance_Name")
	public String getHealthInsuredPersonAssistanceName() {
		return healthInsuredPersonAssistanceName;
	}

	public void setHealthInsuredPersonAssistanceName(String healthInsuredPersonAssistanceName) {
		this.healthInsuredPersonAssistanceName = healthInsuredPersonAssistanceName;
	}

	@JacksonXmlProperty(localName = "Insurance_CheckDate")
	public String getInsuranceCheckDate() {
		return insuranceCheckDate;
	}

	public void setInsuranceCheckDate(String insuranceCheckDate) {
		this.insuranceCheckDate = insuranceCheckDate;
	}

	@JacksonXmlProperty(localName = "InsuranceProvider_Class")
	public String getInsuranceProviderClass() {
		return insuranceProviderClass;
	}

	public void setInsuranceProviderClass(String insuranceProviderClass) {
		this.insuranceProviderClass = insuranceProviderClass;
	}

	@JacksonXmlProperty(localName = "InsuranceProvider_Number")
	public String getInsuranceProviderNumber() {
		return insuranceProviderNumber;
	}

	public void setInsuranceProviderNumber(String insuranceProviderNumber) {
		this.insuranceProviderNumber = insuranceProviderNumber;
	}

	@JacksonXmlProperty(localName = "InsuranceProvider_WholeName")
	public String getInsuranceProviderWholeName() {
		return insuranceProviderWholeName;
	}

	public void setInsuranceProviderWholeName(String insuranceProviderWholeName) {
		this.insuranceProviderWholeName = insuranceProviderWholeName;
	}

	@JacksonXmlProperty(localName = "HealthInsuredPerson_Symbol")
	public String getHealthInsuredPersonSymbol() {
		return healthInsuredPersonSymbol;
	}

	public void setHealthInsuredPersonSymbol(String healthInsuredPersonSymbol) {
		this.healthInsuredPersonSymbol = healthInsuredPersonSymbol;
	}

	@JacksonXmlProperty(localName = "HealthInsuredPerson_Number")
	public String getHealthInsuredPersonNumber() {
		return healthInsuredPersonNumber;
	}

	public void setHealthInsuredPersonNumber(String healthInsuredPersonNumber) {
		this.healthInsuredPersonNumber = healthInsuredPersonNumber;
	}

	@JacksonXmlProperty(localName = "HealthInsuredPerson_Assistance")
	public String getHealthInsuredPersonAssistance() {
		return healthInsuredPersonAssistance;
	}

	public void setHealthInsuredPersonAssistance(String healthInsuredPersonAssistance) {
		this.healthInsuredPersonAssistance = healthInsuredPersonAssistance;
	}

	@JacksonXmlProperty(localName = "RelationToInsuredPerson")
	public String getRelationToInsuredPerson() {
		return relationToInsuredPerson;
	}

	public void setRelationToInsuredPerson(String relationToInsuredPerson) {
		this.relationToInsuredPerson = relationToInsuredPerson;
	}

	@JacksonXmlProperty(localName = "HealthInsuredPerson_WholeName")
	public String getHealthInsuredPersonWholeName() {
		return healthInsuredPersonWholeName;
	}

	public void setHealthInsuredPersonWholeName(String healthInsuredPersonWholeName) {
		this.healthInsuredPersonWholeName = healthInsuredPersonWholeName;
	}

	@JacksonXmlProperty(localName = "Certificate_StartDate")
	public String getCertificateStartDate() {
		return certificateStartDate;
	}

	public void setCertificateStartDate(String certificateStartDate) {
		this.certificateStartDate = certificateStartDate;
	}

	@JacksonXmlProperty(localName = "Certificate_ExpiredDate")
	public String getCertificateExpiredDate() {
		return certificateExpiredDate;
	}

	public void setCertificateExpiredDate(String certificateExpiredDate) {
		this.certificateExpiredDate = certificateExpiredDate;
	}

	@JacksonXmlProperty(localName = "PublicInsurance_Information")
	public List<PublicInsuranceInfo> getPublicInsuranceInformation() {
		return publicInsuranceInformation;
	}

	public void setPublicInsuranceInformation(List<PublicInsuranceInfo> publicInsuranceInformation) {
		this.publicInsuranceInformation = publicInsuranceInformation;
	}

	@JacksonXmlProperty(localName = "HealthInsuredPerson_Continuation")
	public String getHealthInsuredPersonContinuation() {
		return healthInsuredPersonContinuation;
	}

	public void setHealthInsuredPersonContinuation(String healthInsuredPersonContinuation) {
		this.healthInsuredPersonContinuation = healthInsuredPersonContinuation;
	}
	
	@JacksonXmlProperty(localName = "Rate_Class")
	public String getRateClass() {
		return rateClass;
	}

	public void setRateClass(String rateClass) {
		this.rateClass = rateClass;
	}
	
	@JacksonXmlProperty(localName = "Certificate_GetDate")
	public String getCertificateGetDate() {
		return certificateGetDate;
	}

	public void setCertificateGetDate(String certificateGetDate) {
		this.certificateGetDate = certificateGetDate;
	}
	
	@Override
	public int hashCode() {
		return Objects.hash(insuranceCombinationRateAdmission, insuranceCombinationRateOutpatient,
				healthInsuredPersonAssistanceName, insuranceCheckDate, insuranceCombinationNumber,
				insuranceProviderClass, insuranceProviderNumber, insuranceProviderWholeName, healthInsuredPersonSymbol,
				healthInsuredPersonNumber, healthInsuredPersonContinuation, healthInsuredPersonAssistance,
				relationToInsuredPerson, healthInsuredPersonWholeName, certificateStartDate, certificateExpiredDate,
				publicInsuranceInformation, rateClass, certificateGetDate);
	}
}
