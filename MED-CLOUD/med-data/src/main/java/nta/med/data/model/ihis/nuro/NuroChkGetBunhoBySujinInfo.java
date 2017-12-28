package nta.med.data.model.ihis.nuro;

public class NuroChkGetBunhoBySujinInfo {
	private String bunho;
    private String suname;
	public NuroChkGetBunhoBySujinInfo(String bunho, String suname) {
		super();
		this.bunho = bunho;
		this.suname = suname;
	}
	public String getBunho() {
		return bunho;
	}
	public void setBunho(String bunho) {
		this.bunho = bunho;
	}
	public String getSuname() {
		return suname;
	}
	public void setSuname(String suname) {
		this.suname = suname;
	}
}
