package nta.med.data.model.ihis.nuro;

public class OUT1001R01LayOut0101Info {
	private String suName;
    private String suName2;
    private String birth;
	public OUT1001R01LayOut0101Info(String suName, String suName2, String birth) {
		super();
		this.suName = suName;
		this.suName2 = suName2;
		this.birth = birth;
	}
	public String getSuName() {
		return suName;
	}
	public void setSuName(String suName) {
		this.suName = suName;
	}
	public String getSuName2() {
		return suName2;
	}
	public void setSuName2(String suName2) {
		this.suName2 = suName2;
	}
	public String getBirth() {
		return birth;
	}
	public void setBirth(String birth) {
		this.birth = birth;
	}
}
