package nta.med.data.model.ihis.system;

public class OBCheckRegularDrugInfo {
	private Double suryang ;
	private String danui ;
	private Double dv ;
	private String dvTime ;
	private String jusa ;
	private String bogyongCode;
	public OBCheckRegularDrugInfo(Double suryang, String danui, Double dv,
			String dvTime, String jusa, String bogyongCode) {
		super();
		this.suryang = suryang;
		this.danui = danui;
		this.dv = dv;
		this.dvTime = dvTime;
		this.jusa = jusa;
		this.bogyongCode = bogyongCode;
	}
	public Double getSuryang() {
		return suryang;
	}
	public void setSuryang(Double suryang) {
		this.suryang = suryang;
	}
	public String getDanui() {
		return danui;
	}
	public void setDanui(String danui) {
		this.danui = danui;
	}
	public Double getDv() {
		return dv;
	}
	public void setDv(Double dv) {
		this.dv = dv;
	}
	public String getDvTime() {
		return dvTime;
	}
	public void setDvTime(String dvTime) {
		this.dvTime = dvTime;
	}
	public String getJusa() {
		return jusa;
	}
	public void setJusa(String jusa) {
		this.jusa = jusa;
	}
	public String getBogyongCode() {
		return bogyongCode;
	}
	public void setBogyongCode(String bogyongCode) {
		this.bogyongCode = bogyongCode;
	}
	
}
