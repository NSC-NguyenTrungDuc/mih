package nta.med.orca.gw.api.contracts.service;

import nta.med.orca.gw.api.contracts.message.OrcaEnvInfo;

public class AppointListRequest {

	private String appointmentDate;

	private String physicianCode;

	private OrcaEnvInfo orcaEnvInfo;

	public String getAppointmentDate() {
		return appointmentDate;
	}

	public void setAppointmentDate(String appointmentDate) {
		this.appointmentDate = appointmentDate;
	}

	public OrcaEnvInfo getOrcaEnvInfo() {
		return orcaEnvInfo;
	}

	public void setOrcaEnvInfo(OrcaEnvInfo orcaEnvInfo) {
		this.orcaEnvInfo = orcaEnvInfo;
	}

	public String getPhysicianCode() {
		return physicianCode;
	}

	public void setPhysicianCode(String physicianCode) {
		this.physicianCode = physicianCode;
	}

}
