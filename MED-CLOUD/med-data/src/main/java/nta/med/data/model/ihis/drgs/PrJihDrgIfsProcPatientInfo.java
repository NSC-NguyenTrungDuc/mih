package nta.med.data.model.ihis.drgs;

public class PrJihDrgIfsProcPatientInfo {
	private String recGubunDrg;
	private String drgCode;
	private String suryang;
	private String drgType;
	private String bogyongCode;
	private String nalsu;
	
	public PrJihDrgIfsProcPatientInfo(String recGubunDrg, String drgCode,
			String suryang, String drgType, String bogyongCode, String nalsu) {
		this.recGubunDrg = recGubunDrg;
		this.drgCode = drgCode;
		this.suryang = suryang;
		this.drgType = drgType;
		this.bogyongCode = bogyongCode;
		this.nalsu = nalsu;
	}
	public String getRecGubunDrg() {
		return recGubunDrg;
	}
	public void setRecGubunDrg(String recGubunDrg) {
		this.recGubunDrg = recGubunDrg;
	}
	public String getDrgCode() {
		return drgCode;
	}
	public void setDrgCode(String drgCode) {
		this.drgCode = drgCode;
	}
	public String getSuryang() {
		return suryang;
	}
	public void setSuryang(String suryang) {
		this.suryang = suryang;
	}
	public String getDrgType() {
		return drgType;
	}
	public void setDrgType(String drgType) {
		this.drgType = drgType;
	}
	public String getBogyongCode() {
		return bogyongCode;
	}
	public void setBogyongCode(String bogyongCode) {
		this.bogyongCode = bogyongCode;
	}
	public String getNalsu() {
		return nalsu;
	}
	public void setNalsu(String nalsu) {
		this.nalsu = nalsu;
	}
}
