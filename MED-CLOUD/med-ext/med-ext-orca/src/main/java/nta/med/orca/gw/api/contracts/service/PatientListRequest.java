package nta.med.orca.gw.api.contracts.service;

import nta.med.orca.gw.api.contracts.message.OrcaEnvInfo;

public class PatientListRequest {

	private String baseStartDate;
	private String baseEndDate;
	private String containTestPatientFlag;
	private OrcaEnvInfo orcaEnvInfo;

	public PatientListRequest() {
		super();
	}

	public String getBaseStartDate() {
		return baseStartDate;
	}

	public void setBaseStartDate(String baseStartDate) {
		this.baseStartDate = baseStartDate;
	}

	public String getBaseEndDate() {
		return baseEndDate;
	}

	public void setBaseEndDate(String baseEndDate) {
		this.baseEndDate = baseEndDate;
	}

	public String getContainTestPatientFlag() {
		return containTestPatientFlag;
	}

	public void setContainTestPatientFlag(String containTestPatientFlag) {
		this.containTestPatientFlag = containTestPatientFlag;
	}

	public OrcaEnvInfo getOrcaEnvInfo() {
		return orcaEnvInfo;
	}

	public void setOrcaEnvInfo(OrcaEnvInfo orcaEnvInfo) {
		this.orcaEnvInfo = orcaEnvInfo;
	}

}
