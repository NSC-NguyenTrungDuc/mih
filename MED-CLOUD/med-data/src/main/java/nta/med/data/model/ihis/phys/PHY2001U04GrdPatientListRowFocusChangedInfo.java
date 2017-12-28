package nta.med.data.model.ihis.phys;

public class PHY2001U04GrdPatientListRowFocusChangedInfo {
	private String bpFrom   ;
	private String bpTo     ;
	private String pulse    ;
	private String bodyHeat ;
	public PHY2001U04GrdPatientListRowFocusChangedInfo(String bpFrom, String bpTo,
			String pulse, String bodyHeat) {
		super();
		this.bpFrom = bpFrom;
		this.bpTo = bpTo;
		this.pulse = pulse;
		this.bodyHeat = bodyHeat;
	}
	public String getBpFrom() {
		return bpFrom;
	}
	public void setBpFrom(String bpFrom) {
		this.bpFrom = bpFrom;
	}
	public String getBpTo() {
		return bpTo;
	}
	public void setBpTo(String bpTo) {
		this.bpTo = bpTo;
	}
	public String getPulse() {
		return pulse;
	}
	public void setPulse(String pulse) {
		this.pulse = pulse;
	}
	public String getBodyHeat() {
		return bodyHeat;
	}
	public void setBodyHeat(String bodyHeat) {
		this.bodyHeat = bodyHeat;
	}
	
}
