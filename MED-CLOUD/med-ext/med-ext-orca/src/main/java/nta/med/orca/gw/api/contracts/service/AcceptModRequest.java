package nta.med.orca.gw.api.contracts.service;

import org.springframework.util.StringUtils;

import com.fasterxml.jackson.dataformat.xml.annotation.JacksonXmlProperty;

import nta.med.core.glossary.DataRowState;
import nta.med.core.glossary.OrcaApiConfig;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.OrcaUtils;
import nta.med.ext.support.proto.PatientModelProto;
import nta.med.orca.gw.api.contracts.message.HealthInsuranceInfo;

public class AcceptModRequest extends AbstractRequest {

	private String acceptType;
	private String patientID;
	private String acceptanceDate;
	private String acceptanceTime;
	private String acceptanceId;
	private String departmentCode;
	private String physicianCode;
	private String medicalInformation;
	private HealthInsuranceInfo healthIns;

	public String getAcceptType() {
		return acceptType;
	}

	public void setAcceptType(String acceptType) {
		this.acceptType = acceptType;
	}

	@JacksonXmlProperty(localName = "Patient_ID")
	public String getPatientID() {
		return patientID;
	}

	public void setPatientID(String patientID) {
		this.patientID = patientID;
	}

	@JacksonXmlProperty(localName = "Acceptance_Date")
	public String getAcceptanceDate() {
		return acceptanceDate;
	}

	public void setAcceptanceDate(String acceptanceDate) {
		this.acceptanceDate = acceptanceDate;
	}

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

	@JacksonXmlProperty(localName = "Physician_Code")
	public String getPhysicianCode() {
		return physicianCode;
	}

	public void setPhysicianCode(String physicianCode) {
		this.physicianCode = physicianCode;
	}

	@JacksonXmlProperty(localName = "Medical_Information")
	public String getMedicalInformation() {
		return medicalInformation;
	}

	public void setMedicalInformation(String medicalInformation) {
		this.medicalInformation = medicalInformation;
	}

	public HealthInsuranceInfo getHealthIns() {
		return healthIns;
	}

	public void setHealthIns(HealthInsuranceInfo healthIns) {
		this.healthIns = healthIns;
	}

	public void toRequest(PatientModelProto.AcceptInformation acceptInfo){
		String orcaPatientId = String.valueOf(CommonUtils.parseInteger(acceptInfo.getPatientCode()));
		this.setPatientID(orcaPatientId);
		this.setAcceptanceId("");
		this.setDepartmentCode(acceptInfo.getDepartmentCode());
		this.setPhysicianCode(acceptInfo.getPhysicianCode());
		this.setMedicalInformation(acceptInfo.getReceptionType());
		if(!StringUtils.isEmpty(acceptInfo.getAcceptanceDate())){
			this.setAcceptanceDate(acceptInfo.getAcceptanceDate().replace("/", "-"));
		}
		
		healthIns = new HealthInsuranceInfo();
		healthIns.setInsuranceCombinationNumber("");
		healthIns.setInsuranceProviderClass(OrcaUtils.getClassCodeByInsurCode(acceptInfo.getInsuranceCode()));
		
		String acceptType = DataRowState.ADDED.getValue().equals(acceptInfo.getDataRowState()) ? OrcaApiConfig.ACCEPT_NEW.getValue() : OrcaApiConfig.ACCEPT_DELETE.getValue();
		this.setAcceptType(acceptType);
	}
	
}
