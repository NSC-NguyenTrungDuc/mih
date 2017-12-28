package nta.med.data.model.ihis.ocsa;

public class OCS0103U12IsUpdateCheckSelectInfo {
	private String suryang;
	private String dv;
	private String dvTime;
	private String nalsu;

	public OCS0103U12IsUpdateCheckSelectInfo(String suryang, String dv, String dvTime, String nalsu) {
		super();
		this.suryang = suryang;
		this.dv = dv;
		this.dvTime = dvTime;
		this.nalsu = nalsu;
	}

	public String getSuryang() {
		return suryang;
	}

	public void setSuryang(String suryang) {
		this.suryang = suryang;
	}

	public String getDv() {
		return dv;
	}

	public void setDv(String dv) {
		this.dv = dv;
	}

	public String getDvTime() {
		return dvTime;
	}

	public void setDvTime(String dvTime) {
		this.dvTime = dvTime;
	}

	public String getNalsu() {
		return nalsu;
	}

	public void setNalsu(String nalsu) {
		this.nalsu = nalsu;
	}

}
