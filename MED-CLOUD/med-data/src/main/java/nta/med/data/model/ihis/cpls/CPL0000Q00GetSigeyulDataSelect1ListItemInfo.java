package nta.med.data.model.ihis.cpls;

public class CPL0000Q00GetSigeyulDataSelect1ListItemInfo {
	private String jubsuDate;
    private String jubsuTime;
    private String jubsuTime2;
	public CPL0000Q00GetSigeyulDataSelect1ListItemInfo(String jubsuDate,
			String jubsuTime, String jubsuTime2) {
		super();
		this.jubsuDate = jubsuDate;
		this.jubsuTime = jubsuTime;
		this.jubsuTime2 = jubsuTime2;
	}
	public String getJubsuDate() {
		return jubsuDate;
	}
	public void setJubsuDate(String jubsuDate) {
		this.jubsuDate = jubsuDate;
	}
	public String getJubsuTime() {
		return jubsuTime;
	}
	public void setJubsuTime(String jubsuTime) {
		this.jubsuTime = jubsuTime;
	}
	public String getJubsuTime2() {
		return jubsuTime2;
	}
	public void setJubsuTime2(String jubsuTime2) {
		this.jubsuTime2 = jubsuTime2;
	}
}
