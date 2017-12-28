package nta.med.orca.gw.api.contracts.message;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import com.fasterxml.jackson.dataformat.xml.annotation.JacksonXmlProperty;

@JsonIgnoreProperties(ignoreUnknown = true)
public class AppointReq {

	private String type;
	private BaseNode patientID;
	private BaseNode wholeName;
	private BaseNode wholeNameInKana;
	private BaseNode appointmentDate;
	private BaseNode appointmentTime;
	private BaseNode appointmentId;
	private BaseNode departmentCode;
	private BaseNode physicianCode;
	private BaseNode medicalInformation;
	private BaseNode appointmentInformation;
	private BaseNode appointmentNote;

	@JacksonXmlProperty(localName = "type", isAttribute = true)
	public String getType() {
		return type;
	}

	public void setType(String type) {
		this.type = type;
	}

	@JacksonXmlProperty(localName = "Patient_ID")
	public BaseNode getPatientID() {
		return patientID;
	}

	public void setPatientID(BaseNode patientID) {
		this.patientID = patientID;
	}

	@JacksonXmlProperty(localName = "WholeName")
	public BaseNode getWholeName() {
		return wholeName;
	}

	public void setWholeName(BaseNode wholeName) {
		this.wholeName = wholeName;
	}

	@JacksonXmlProperty(localName = "WholeName_inKana")
	public BaseNode getWholeNameInKana() {
		return wholeNameInKana;
	}

	public void setWholeNameInKana(BaseNode wholeNameInKana) {
		this.wholeNameInKana = wholeNameInKana;
	}

	@JacksonXmlProperty(localName = "Appointment_Date")
	public BaseNode getAppointmentDate() {
		return appointmentDate;
	}

	public void setAppointmentDate(BaseNode appointmentDate) {
		this.appointmentDate = appointmentDate;
	}

	@JacksonXmlProperty(localName = "Appointment_Time")
	public BaseNode getAppointmentTime() {
		return appointmentTime;
	}

	public void setAppointmentTime(BaseNode appointmentTime) {
		this.appointmentTime = appointmentTime;
	}

	@JacksonXmlProperty(localName = "Appointment_Id")
	public BaseNode getAppointmentId() {
		return appointmentId;
	}

	public void setAppointmentId(BaseNode appointmentId) {
		this.appointmentId = appointmentId;
	}

	@JacksonXmlProperty(localName = "Department_Code")
	public BaseNode getDepartmentCode() {
		return departmentCode;
	}

	public void setDepartmentCode(BaseNode departmentCode) {
		this.departmentCode = departmentCode;
	}

	@JacksonXmlProperty(localName = "Physician_Code")
	public BaseNode getPhysicianCode() {
		return physicianCode;
	}

	public void setPhysicianCode(BaseNode physicianCode) {
		this.physicianCode = physicianCode;
	}

	@JacksonXmlProperty(localName = "Medical_Information")
	public BaseNode getMedicalInformation() {
		return medicalInformation;
	}

	public void setMedicalInformation(BaseNode medicalInformation) {
		this.medicalInformation = medicalInformation;
	}

	@JacksonXmlProperty(localName = "Appointment_Information")
	public BaseNode getAppointmentInformation() {
		return appointmentInformation;
	}

	public void setAppointmentInformation(BaseNode appointmentInformation) {
		this.appointmentInformation = appointmentInformation;
	}

	@JacksonXmlProperty(localName = "Appointment_Note")
	public BaseNode getAppointmentNote() {
		return appointmentNote;
	}

	public void setAppointmentNote(BaseNode appointmentNote) {
		this.appointmentNote = appointmentNote;
	}

}
