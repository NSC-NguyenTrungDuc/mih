package nta.med.data.model.ihis.nuro;

public class KCCKCountTotalOfBookingInfo {
	private String naewonDate;
	private String jubsuTime;
	private String resInputGubun;
	public KCCKCountTotalOfBookingInfo(String naewonDate, String jubsuTime, String resInputGubun) {
		super();
		this.naewonDate = naewonDate;
		this.jubsuTime = jubsuTime;
		this.resInputGubun = resInputGubun;
	}
	public String getNaewonDate() {
		return naewonDate;
	}
	public void setNaewonDate(String naewonDate) {
		this.naewonDate = naewonDate;
	}
	public String getJubsuTime() {
		return jubsuTime;
	}
	public void setJubsuTime(String jubsuTime) {
		this.jubsuTime = jubsuTime;
	}
	public String getResInputGubun() {
		return resInputGubun;
	}
	public void setResInputGubun(String resInputGubun) {
		this.resInputGubun = resInputGubun;
	}
	
}
