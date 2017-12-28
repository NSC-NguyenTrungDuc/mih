package nta.med.orca.gw.api.contracts.message;

import java.util.Objects;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import com.fasterxml.jackson.dataformat.xml.annotation.JacksonXmlProperty;
import com.fasterxml.jackson.dataformat.xml.annotation.JacksonXmlRootElement;

@JsonIgnoreProperties(ignoreUnknown = true)
@JacksonXmlRootElement(localName = "Appointlst_Information_child")
public class AppointlstInformationChild {

	private String type;
	private BaseNode appointmentTime;
	private BaseNode medicalInformation;
	private BaseNode departmentCode;
	private BaseNode departmentWholeName;
	private BaseNode physicianCode;
	private BaseNode physicianWholeName;
	private BaseNode visitInformation;
	private PatientInformation patientInformation;

	@JacksonXmlProperty(localName = "type", isAttribute = true)
	public String getType() {
		return type;
	}

	public void setType(String type) {
		this.type = type;
	}

	@JacksonXmlProperty(localName = "Appointment_Time")
	public BaseNode getAppointmentTime() {
		return appointmentTime;
	}

	public void setAppointmentTime(BaseNode appointmentTime) {
		this.appointmentTime = appointmentTime;
	}

	@JacksonXmlProperty(localName = "Medical_Information")
	public BaseNode getMedicalInformation() {
		return medicalInformation;
	}

	public void setMedicalInformation(BaseNode medicalInformation) {
		this.medicalInformation = medicalInformation;
	}

	@JacksonXmlProperty(localName = "Department_Code")
	public BaseNode getDepartmentCode() {
		return departmentCode;
	}

	public void setDepartmentCode(BaseNode departmentCode) {
		this.departmentCode = departmentCode;
	}

	@JacksonXmlProperty(localName = "Department_WholeName")
	public BaseNode getDepartmentWholeName() {
		return departmentWholeName;
	}

	public void setDepartmentWholeName(BaseNode departmentWholeName) {
		this.departmentWholeName = departmentWholeName;
	}

	@JacksonXmlProperty(localName = "Physician_Code")
	public BaseNode getPhysicianCode() {
		return physicianCode;
	}

	public void setPhysicianCode(BaseNode physicianCode) {
		this.physicianCode = physicianCode;
	}

	@JacksonXmlProperty(localName = "Physician_WholeName")
	public BaseNode getPhysicianWholeName() {
		return physicianWholeName;
	}

	public void setPhysicianWholeName(BaseNode physicianWholeName) {
		this.physicianWholeName = physicianWholeName;
	}
	
	@JacksonXmlProperty(localName = "Visit_Information")
	public BaseNode getVisitInformation() {
		return visitInformation;
	}

	public void setVisitInformation(BaseNode visitInformation) {
		this.visitInformation = visitInformation;
	}

	@JacksonXmlProperty(localName = "Patient_Information")
	public PatientInformation getPatientInformation() {
		return patientInformation;
	}

	public void setPatientInformation(PatientInformation patientInformation) {
		this.patientInformation = patientInformation;
	}

	@Override
	public int hashCode() {
		return Objects.hash(appointmentTime, medicalInformation, departmentCode, departmentWholeName, physicianCode,
				physicianWholeName, visitInformation, patientInformation);
	}
}
