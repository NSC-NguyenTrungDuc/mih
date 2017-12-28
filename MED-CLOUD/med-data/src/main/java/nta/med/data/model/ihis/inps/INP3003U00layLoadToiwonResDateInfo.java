package nta.med.data.model.ihis.inps;

public class INP3003U00layLoadToiwonResDateInfo {
	private String toiwonResDate ;
	private String toiwonResTime ;
	private String sigiMagamDate ;
	private String sysDate        ;
	private String sysTime        ;
	public INP3003U00layLoadToiwonResDateInfo(String toiwonResDate, String toiwonResTime, String sigiMagamDate,
			String sysDate, String sysTime) {
		super();
		this.toiwonResDate = toiwonResDate;
		this.toiwonResTime = toiwonResTime;
		this.sigiMagamDate = sigiMagamDate;
		this.sysDate = sysDate;
		this.sysTime = sysTime;
	}
	public String getToiwonResDate() {
		return toiwonResDate;
	}
	public void setToiwonResDate(String toiwonResDate) {
		this.toiwonResDate = toiwonResDate;
	}
	public String getToiwonResTime() {
		return toiwonResTime;
	}
	public void setToiwonResTime(String toiwonResTime) {
		this.toiwonResTime = toiwonResTime;
	}
	public String getSigiMagamDate() {
		return sigiMagamDate;
	}
	public void setSigiMagamDate(String sigiMagamDate) {
		this.sigiMagamDate = sigiMagamDate;
	}
	public String getSysDate() {
		return sysDate;
	}
	public void setSysDate(String sysDate) {
		this.sysDate = sysDate;
	}
	public String getSysTime() {
		return sysTime;
	}
	public void setSysTime(String sysTime) {
		this.sysTime = sysTime;
	}
	
}
