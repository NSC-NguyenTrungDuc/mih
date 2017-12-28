package nta.med.data.model.ihis.ocso;

public class OUTSANGQ00IsEnableSangCodeInfo {
	private String sangStartDate;
	private String startDate;
	public OUTSANGQ00IsEnableSangCodeInfo(String sangStartDate, String startDate) {
		super();
		this.sangStartDate = sangStartDate;
		this.startDate = startDate;
	}
	public String getSangStartDate() {
		return sangStartDate;
	}
	public void setSangStartDate(String sangStartDate) {
		this.sangStartDate = sangStartDate;
	}
	public String getStartDate() {
		return startDate;
	}
	public void setStartDate(String startDate) {
		this.startDate = startDate;
	}
}
