package nta.med.data.model.ihis.ocso;

public class OUTSANGU00findBoxToGwaInfo {
	private String gwa;
	private String gwaName;
	private String buseoCode;

	public OUTSANGU00findBoxToGwaInfo(String gwa, String gwaName,
			String buseoCode) {
		super();
		this.gwa = gwa;
		this.gwaName = gwaName;
		this.buseoCode = buseoCode;
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

	public String getBuseoCode() {
		return buseoCode;
	}

	public void setBuseoCode(String buseoCode) {
		this.buseoCode = buseoCode;
	}

}
