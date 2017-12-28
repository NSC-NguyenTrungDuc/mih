package nta.med.data.model.ihis.nuri;

public class NUR1010Q00grdGwaCountInfo {
	private String gwa;
	private String gwaName;
	private String count;
	private String gwaColor;
	
	public NUR1010Q00grdGwaCountInfo(String gwa, String gwaName, String count, String gwaColor) {
		super();
		this.gwa = gwa;
		this.gwaName = gwaName;
		this.count = count;
		this.gwaColor = gwaColor;
	}

	public String getGwa() {
		return gwa;
	}

	public void setGwa(String gwa) {
		this.gwa = gwa;
	}

	public String getGwaName() {
		return gwaName;
	}

	public void setGwaName(String gwaName) {
		this.gwaName = gwaName;
	}

	public String getCount() {
		return count;
	}

	public void setCount(String count) {
		this.count = count;
	}

	public String getGwaColor() {
		return gwaColor;
	}

	public void setGwaColor(String gwaColor) {
		this.gwaColor = gwaColor;
	}
	
}
