package nta.med.orca.gw.api.contracts.message;

import java.util.Objects;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import com.fasterxml.jackson.dataformat.xml.annotation.JacksonXmlProperty;

@JsonIgnoreProperties(ignoreUnknown = true)
public class PublicInsuranceInfo {

	private String publicInsuranceClass;
	private String publicInsuranceName;
	private String publicInsurerNumber;
	private String publicInsuredPersonNumber;
	private String rateAdmission;
	private String moneyAdmission;
	private String rateOutpatient;
	private String moneyOutpatient;
	private String certificateIssuedDate;
	private String certificateExpiredDate;

	@JacksonXmlProperty(localName = "PublicInsurance_Class")
	public String getPublicInsuranceClass() {
		return publicInsuranceClass;
	}

	public void setPublicInsuranceClass(String publicInsuranceClass) {
		this.publicInsuranceClass = publicInsuranceClass;
	}

	@JacksonXmlProperty(localName = "PublicInsurance_Name")
	public String getPublicInsuranceName() {
		return publicInsuranceName;
	}

	public void setPublicInsuranceName(String publicInsuranceName) {
		this.publicInsuranceName = publicInsuranceName;
	}

	@JacksonXmlProperty(localName = "PublicInsurer_Number")
	public String getPublicInsurerNumber() {
		return publicInsurerNumber;
	}

	public void setPublicInsurerNumber(String publicInsurerNumber) {
		this.publicInsurerNumber = publicInsurerNumber;
	}

	@JacksonXmlProperty(localName = "PublicInsuredPerson_Number")
	public String getPublicInsuredPersonNumber() {
		return publicInsuredPersonNumber;
	}

	public void setPublicInsuredPersonNumber(String publicInsuredPersonNumber) {
		this.publicInsuredPersonNumber = publicInsuredPersonNumber;
	}

	@JacksonXmlProperty(localName = "Rate_Admission")
	public String getRateAdmission() {
		return rateAdmission;
	}

	public void setRateAdmission(String rateAdmission) {
		this.rateAdmission = rateAdmission;
	}

	@JacksonXmlProperty(localName = "Money_Admission")
	public String getMoneyAdmission() {
		return moneyAdmission;
	}

	public void setMoneyAdmission(String moneyAdmission) {
		this.moneyAdmission = moneyAdmission;
	}

	@JacksonXmlProperty(localName = "Rate_Outpatient")
	public String getRateOutpatient() {
		return rateOutpatient;
	}

	public void setRateOutpatient(String rateOutpatient) {
		this.rateOutpatient = rateOutpatient;
	}

	@JacksonXmlProperty(localName = "Money_Outpatient")
	public String getMoneyOutpatient() {
		return moneyOutpatient;
	}

	public void setMoneyOutpatient(String moneyOutpatient) {
		this.moneyOutpatient = moneyOutpatient;
	}

	@JacksonXmlProperty(localName = "Certificate_IssuedDate")
	public String getCertificateIssuedDate() {
		return certificateIssuedDate;
	}

	public void setCertificateIssuedDate(String certificateIssuedDate) {
		this.certificateIssuedDate = certificateIssuedDate;
	}

	@JacksonXmlProperty(localName = "Certificate_ExpiredDate")
	public String getCertificateExpiredDate() {
		return certificateExpiredDate;
	}

	public void setCertificateExpiredDate(String certificateExpiredDate) {
		this.certificateExpiredDate = certificateExpiredDate;
	}

	@Override
	public int hashCode() {
		return Objects.hash(publicInsuranceClass, publicInsuranceName, publicInsurerNumber, publicInsuredPersonNumber,
				rateAdmission, moneyAdmission, rateOutpatient, moneyOutpatient, certificateIssuedDate,
				certificateExpiredDate);
	}
	
}
