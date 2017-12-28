package nta.med.data.model.ihis.ocsa;

public class OCS0103U00SunalAndSubulInfo {
	private String sunal;
	private String subul;
	
	public OCS0103U00SunalAndSubulInfo(String sunal, String subul) {
		super();
		this.sunal = sunal;
		this.subul = subul;
	}
	public String getSunal() {
		return sunal;
	}
	public void setSunal(String sunal) {
		this.sunal = sunal;
	}
	public String getSubul() {
		return subul;
	}
	public void setSubul(String subul) {
		this.subul = subul;
	}
	
}
