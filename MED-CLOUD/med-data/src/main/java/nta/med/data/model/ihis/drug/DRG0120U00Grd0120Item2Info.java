package nta.med.data.model.ihis.drug;

public class DRG0120U00Grd0120Item2Info {
	 private String bunryu1Name;  
     private String bogyongCode;                                              
     private String bogyongName;                                              
     private String dv;            
     private String bogyongGubun; 
     private String donbogYn;     
     private String afWake;       
     private String morning;       
     private String afternoon;     
     private String evening;       
     private String night;
	public DRG0120U00Grd0120Item2Info(String bunryu1Name, String bogyongCode,
			String bogyongName, String dv, String bogyongGubun,
			String donbogYn, String afWake, String morning, String afternoon,
			String evening, String night) {
		super();
		this.bunryu1Name = bunryu1Name;
		this.bogyongCode = bogyongCode;
		this.bogyongName = bogyongName;
		this.dv = dv;
		this.bogyongGubun = bogyongGubun;
		this.donbogYn = donbogYn;
		this.afWake = afWake;
		this.morning = morning;
		this.afternoon = afternoon;
		this.evening = evening;
		this.night = night;
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
	public String getBogyongGubun() {
		return bogyongGubun;
	}
	public void setBogyongGubun(String bogyongGubun) {
		this.bogyongGubun = bogyongGubun;
	}
	public String getDonbogYn() {
		return donbogYn;
	}
	public void setDonbogYn(String donbogYn) {
		this.donbogYn = donbogYn;
	}
	public String getAfWake() {
		return afWake;
	}
	public void setAfWake(String afWake) {
		this.afWake = afWake;
	}
	public String getMorning() {
		return morning;
	}
	public void setMorning(String morning) {
		this.morning = morning;
	}
	public String getAfternoon() {
		return afternoon;
	}
	public void setAfternoon(String afternoon) {
		this.afternoon = afternoon;
	}
	public String getEvening() {
		return evening;
	}
	public void setEvening(String evening) {
		this.evening = evening;
	}
	public String getNight() {
		return night;
	}
	public void setNight(String night) {
		this.night = night;
	}
}
