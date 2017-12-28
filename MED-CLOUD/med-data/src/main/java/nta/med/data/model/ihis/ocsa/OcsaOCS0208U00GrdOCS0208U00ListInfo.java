package nta.med.data.model.ihis.ocsa;

public class OcsaOCS0208U00GrdOCS0208U00ListInfo {
	private String doctor;
    private Double seq;
    private String bogyongCode;
    private String bogyongName;
    private String bunryu1;
	public OcsaOCS0208U00GrdOCS0208U00ListInfo(String doctor, Double seq,
			String bogyongCode, String bogyongName, String bunryu1) {
		super();
		this.doctor = doctor;
		this.seq = seq;
		this.bogyongCode = bogyongCode;
		this.bogyongName = bogyongName;
		this.bunryu1 = bunryu1;
	}
	public String getDoctor() {
		return doctor;
	}
	public void setDoctor(String doctor) {
		this.doctor = doctor;
	}
	public Double getSeq() {
		return seq;
	}
	public void setSeq(Double seq) {
		this.seq = seq;
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
	public String getBunryu1() {
		return bunryu1;
	}
	public void setBunryu1(String bunryu1) {
		this.bunryu1 = bunryu1;
	}
    
}
