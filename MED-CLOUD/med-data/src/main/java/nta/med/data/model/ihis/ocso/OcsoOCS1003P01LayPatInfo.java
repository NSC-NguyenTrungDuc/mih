package nta.med.data.model.ihis.ocso;

public class OcsoOCS1003P01LayPatInfo {
	private String gwa;
    private String bunho;
    private String doctor;
    private String groupKey;
    private String naewonYn;
	public OcsoOCS1003P01LayPatInfo(String gwa, String bunho, String doctor,
			String groupKey, String naewonYn) {
		super();
		this.gwa = gwa;
		this.bunho = bunho;
		this.doctor = doctor;
		this.groupKey = groupKey;
		this.naewonYn = naewonYn;
	}
	public String getGwa() {
		return gwa;
	}
	public void setGwa(String gwa) {
		this.gwa = gwa;
	}
	public String getBunho() {
		return bunho;
	}
	public void setBunho(String bunho) {
		this.bunho = bunho;
	}
	public String getDoctor() {
		return doctor;
	}
	public void setDoctor(String doctor) {
		this.doctor = doctor;
	}
	public String getGroupKey() {
		return groupKey;
	}
	public void setGroupKey(String groupKey) {
		this.groupKey = groupKey;
	}
	public String getNaewonYn() {
		return naewonYn;
	}
	public void setNaewonYn(String naewonYn) {
		this.naewonYn = naewonYn;
	}
}
