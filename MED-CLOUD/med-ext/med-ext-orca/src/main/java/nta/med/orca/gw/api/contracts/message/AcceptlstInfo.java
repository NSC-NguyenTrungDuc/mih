package nta.med.orca.gw.api.contracts.message;

import java.util.Objects;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import com.fasterxml.jackson.dataformat.xml.annotation.JacksonXmlProperty;

@JsonIgnoreProperties(ignoreUnknown = true)
public class AcceptlstInfo {

	private String acceptanceTime;
	private String acceptanceId;
	private String departmentCode;
	private String departmentWholeName;
	private String physicianCode;
	private String physicianWholeName;
	private String medicalInformation;
	private String claimInfometion;
	private PatientInfo patientInformation;
	private HealthInsuranceInfo healthInsuranceInformation;

	private String appointmentYn;
	private String appointTime;
	
	@JacksonXmlProperty(localName = "Acceptance_Time")
	public String getAcceptanceTime() {
		return acceptanceTime;
	}

	public void setAcceptanceTime(String acceptanceTime) {
		this.acceptanceTime = acceptanceTime;
	}

	@JacksonXmlProperty(localName = "Acceptance_Id")
	public String getAcceptanceId() {
		return acceptanceId;
	}

	public void setAcceptanceId(String acceptanceId) {
		this.acceptanceId = acceptanceId;
	}

	@JacksonXmlProperty(localName = "Department_Code")
	public String getDepartmentCode() {
		return departmentCode;
	}

	public void setDepartmentCode(String departmentCode) {
		this.departmentCode = departmentCode;
	}

	@JacksonXmlProperty(localName = "Department_WholeName")
	public String getDepartmentWholeName() {
		return departmentWholeName;
	}

	public void setDepartmentWholeName(String departmentWholeName) {
		this.departmentWholeName = departmentWholeName;
	}

	@JacksonXmlProperty(localName = "Physician_Code")
	public String getPhysicianCode() {
		return physicianCode;
	}

	public void setPhysicianCode(String physicianCode) {
		this.physicianCode = physicianCode;
	}

	@JacksonXmlProperty(localName = "Physician_WholeName")
	public String getPhysicianWholeName() {
		return physicianWholeName;
	}

	public void setPhysicianWholeName(String physicianWholeName) {
		this.physicianWholeName = physicianWholeName;
	}

	@JacksonXmlProperty(localName = "Medical_Information")
	public String getMedicalInformation() {
		return medicalInformation;
	}

	public void setMedicalInformation(String medicalInformation) {
		this.medicalInformation = medicalInformation;
	}

	@JacksonXmlProperty(localName = "Claim_Infometion")
	public String getClaimInfometion() {
		return claimInfometion;
	}

	public void setClaimInfometion(String claimInfometion) {
		this.claimInfometion = claimInfometion;
	}

	@JacksonXmlProperty(localName = "Patient_Information")
	public PatientInfo getPatientInformation() {
		return patientInformation;
	}

	public void setPatientInformation(PatientInfo patientInformation) {
		this.patientInformation = patientInformation;
	}

	@JacksonXmlProperty(localName = "HealthInsurance_Information")
	public HealthInsuranceInfo getHealthInsuranceInformation() {
		return healthInsuranceInformation;
	}

	public void setHealthInsuranceInformation(HealthInsuranceInfo healthInsuranceInformation) {
		this.healthInsuranceInformation = healthInsuranceInformation;
	}

	public String getAppointmentYn() {
		return appointmentYn;
	}

	public void setAppointmentYn(String appointmentYn) {
		this.appointmentYn = appointmentYn;
	}
	
	public String getAppointTime() {
		return appointTime;
	}

	public void setAppointTime(String appointTime) {
		this.appointTime = appointTime;
	}

	@Override
	public int hashCode() {
		return Objects.hash(acceptanceTime, acceptanceId, departmentCode, departmentWholeName, physicianCode,
				physicianWholeName, medicalInformation, claimInfometion, patientInformation, healthInsuranceInformation,
				appointmentYn, appointTime);
	}
}
