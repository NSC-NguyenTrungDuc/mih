package nta.med.data.model.ihis.nuro;

import java.math.BigInteger;

public class LinkEMRPatientInfo {
	private BigInteger patientId;
	private String bunhoLink;

	public LinkEMRPatientInfo(BigInteger patientId, String bunhoLink) {
		super();
		this.patientId = patientId;
		this.bunhoLink = bunhoLink;
	}

	public BigInteger getPatientId() {
		return patientId;
	}

	public void setPatientId(BigInteger patientId) {
		this.patientId = patientId;
	}

	public String getBunhoLink() {
		return bunhoLink;
	}

	public void setBunho(String bunhoLink) {
		this.bunhoLink = bunhoLink;
	}
}
