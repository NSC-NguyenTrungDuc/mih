package nta.med.orca.gw.api.contracts.service;

import nta.med.orca.gw.api.contracts.message.OrcaEnvInfo;

public class PatientInfoRequest {

	private String patientCode;
	private OrcaEnvInfo orcaEnvInfo;

	public PatientInfoRequest() {
		super();
	}

	public PatientInfoRequest(String patientCode) {
		super();
		this.patientCode = patientCode;
	}

	public PatientInfoRequest(String patientCode, OrcaEnvInfo orcaEnvInfo) {
		super();
		this.patientCode = patientCode;
		this.orcaEnvInfo = orcaEnvInfo;
	}

	public String getPatientCode() {
		return patientCode;
	}

	public void setPatientCode(String patientCode) {
		this.patientCode = patientCode;
	}

	public OrcaEnvInfo getOrcaEnvInfo() {
		return orcaEnvInfo;
	}

	public void setOrcaEnvInfo(OrcaEnvInfo orcaEnvInfo) {
		this.orcaEnvInfo = orcaEnvInfo;
	}

}
