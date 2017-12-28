package nta.med.data.model.ihis.nuro;

public class RES1001R00ClinicInfo {
	private String yoyangName;
	private String bunho;
	public RES1001R00ClinicInfo(String yoyangName, String bunho) {
		super();
		this.yoyangName = yoyangName;
		this.bunho = bunho;
	}
	public String getYoyangName() {
		return yoyangName;
	}
	public void setYoyangName(String yoyangName) {
		this.yoyangName = yoyangName;
	}
	public String getBunho() {
		return bunho;
	}
	public void setBunho(String bunho) {
		this.bunho = bunho;
	}
	
}
