package nta.med.data.model.ihis.system;

public class LoadOftenUsedTabRequestInfo {
	private String memb ;
	private String inputTab ;
	public LoadOftenUsedTabRequestInfo(String memb, String inputTab) {
		super();
		this.memb = memb;
		this.inputTab = inputTab;
	}
	public String getMemb() {
		return memb;
	}
	public void setMemb(String memb) {
		this.memb = memb;
	}
	public String getInputTab() {
		return inputTab;
	}
	public void setInputTab(String inputTab) {
		this.inputTab = inputTab;
	}
	

}
