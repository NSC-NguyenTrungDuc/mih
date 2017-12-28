package nta.med.data.model.ihis.drug;

public class DRG0120U00Grd0120Item3Info {
	private String bunryu1Name;  
    private String bogyongCode;                                              
    private String bogyongName;                                              
    private String dv;
    private String banghyang; 
    private String buwi;     
    private String chiryo;
	public DRG0120U00Grd0120Item3Info(String bunryu1Name, String bogyongCode,
			String bogyongName, String dv, String banghyang, String buwi,
			String chiryo) {
		super();
		this.bunryu1Name = bunryu1Name;
		this.bogyongCode = bogyongCode;
		this.bogyongName = bogyongName;
		this.dv = dv;
		this.banghyang = banghyang;
		this.buwi = buwi;
		this.chiryo = chiryo;
	}
	public String getBunryu1Name() {
		return bunryu1Name;
	}
	public void setBunryu1Name(String bunryu1Name) {
		this.bunryu1Name = bunryu1Name;
	}
	public String getBogyongCode() {
		return bogyongCode;
	}
	public void setBogyongCode(String bogyongCode) {
		this.bogyongCode = bogyongCode;
	}
	public String getBogyongName() {
		return bogyongName;
	}
	public void setBogyongName(String bogyongName) {
		this.bogyongName = bogyongName;
	}
	public String getDv() {
		return dv;
	}
	public void setDv(String dv) {
		this.dv = dv;
	}
	public String getBanghyang() {
		return banghyang;
	}
	public void setBanghyang(String banghyang) {
		this.banghyang = banghyang;
	}
	public String getBuwi() {
		return buwi;
	}
	public void setBuwi(String buwi) {
		this.buwi = buwi;
	}
	public String getChiryo() {
		return chiryo;
	}
	public void setChiryo(String chiryo) {
		this.chiryo = chiryo;
	}
}
