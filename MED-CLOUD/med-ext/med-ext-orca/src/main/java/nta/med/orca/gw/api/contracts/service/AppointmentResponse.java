package nta.med.orca.gw.api.contracts.service;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import com.fasterxml.jackson.dataformat.xml.annotation.JacksonXmlProperty;

@JsonIgnoreProperties(ignoreUnknown = true)
public class AppointmentResponse extends AbstractResponse {

	private String appointmentDate;
	private String appointmentTime;
	private String appointmentId;
	private String departmentCode;
	private String departmentWholeName;
	private String physicianCode;
	private String physicianWholeName;
	private String medicalInformation;
	private String appointmentInformation;
	private String appointmentNote;

	@JacksonXmlProperty(localName = "Appointment_Date")
	public String getAppointmentDate() {
		return appointmentDate;
	}

	public void setAppointmentDate(String appointmentDate) {
		this.appointmentDate = appointmentDate;
	}

	@JacksonXmlProperty(localName = "Appointment_Time")
	public String getAppointmentTime() {
		return appointmentTime;
	}

	public void setAppointmentTime(String appointmentTime) {
		this.appointmentTime = appointmentTime;
	}

	@JacksonXmlProperty(localName = "Appointment_Id")
	public String getAppointmentId() {
		return appointmentId;
	}

	public void setAppointmentId(String appointmentId) {
		this.appointmentId = appointmentId;
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

	@JacksonXmlProperty(localName = "Appointment_Information")
	public String getAppointmentInformation() {
		return appointmentInformation;
	}

	public void setAppointmentInformation(String appointmentInformation) {
		this.appointmentInformation = appointmentInformation;
	}

	@JacksonXmlProperty(localName = "Appointment_Note")
	public String getAppointmentNote() {
		return appointmentNote;
	}

	public void setAppointmentNote(String appointmentNote) {
		this.appointmentNote = appointmentNote;
	}

}
