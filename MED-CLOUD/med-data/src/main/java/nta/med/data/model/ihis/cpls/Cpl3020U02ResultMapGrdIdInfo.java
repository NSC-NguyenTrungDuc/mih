package nta.med.data.model.ihis.cpls;

import java.util.Date;

public class Cpl3020U02ResultMapGrdIdInfo {
	private Date resultDate;
	private String procTime;
	private String sampleId;
	private String specimenSer;
	private String patientId;

	public Cpl3020U02ResultMapGrdIdInfo(Date resultDate, String procTime,
			String sampleId, String specimenSer, String patientId) {
		super();
		this.resultDate = resultDate;
		this.procTime = procTime;
		this.sampleId = sampleId;
		this.specimenSer = specimenSer;
		this.patientId = patientId;
	}

	public Date getResultDate() {
		return resultDate;
	}

	public void setResultDate(Date resultDate) {
		this.resultDate = resultDate;
	}

	public String getProcTime() {
		return procTime;
	}

	public void setProcTime(String procTime) {
		this.procTime = procTime;
	}

	public String getSampleId() {
		return sampleId;
	}

	public void setSampleId(String sampleId) {
		this.sampleId = sampleId;
	}

	public String getSpecimenSer() {
		return specimenSer;
	}

	public void setSpecimenSer(String specimenSer) {
		this.specimenSer = specimenSer;
	}

	public String getPatientId() {
		return patientId;
	}

	public void setPatientId(String patientId) {
		this.patientId = patientId;
	}

}
