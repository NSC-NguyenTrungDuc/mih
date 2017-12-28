package nta.med.data.model.ihis.system;

public class BuseoInfo {
	private String buseoCode;
    private String buseoName;
	public BuseoInfo(String buseoCode, String buseoName) {
		super();
		this.buseoCode = buseoCode;
		this.buseoName = buseoName;
	}
	public String getBuseoCode() {
		return buseoCode;
	}
	public void setBuseoCode(String buseoCode) {
		this.buseoCode = buseoCode;
	}
	public String getBuseoName() {
		return buseoName;
	}
	public void setBuseoName(String buseoName) {
		this.buseoName = buseoName;
	}
}
