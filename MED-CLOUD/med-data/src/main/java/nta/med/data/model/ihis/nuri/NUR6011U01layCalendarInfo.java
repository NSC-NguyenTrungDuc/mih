package nta.med.data.model.ihis.nuri;

public class NUR6011U01layCalendarInfo {
	private String bunho;
	private String fromDate;
	private String bedsoreBuwi;
	private String assessorDate;
	private String assessor;
	
	public NUR6011U01layCalendarInfo(String bunho, String fromDate, String bedsoreBuwi, String assessorDate,
			String assessor) {
		super();
		this.bunho = bunho;
		this.fromDate = fromDate;
		this.bedsoreBuwi = bedsoreBuwi;
		this.assessorDate = assessorDate;
		this.assessor = assessor;
	}

	public String getBunho() {
		return bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}

	public String getFromDate() {
		return fromDate;
	}

	public void setFromDate(String fromDate) {
		this.fromDate = fromDate;
	}

	public String getBedsoreBuwi() {
		return bedsoreBuwi;
	}

	public void setBedsoreBuwi(String bedsoreBuwi) {
		this.bedsoreBuwi = bedsoreBuwi;
	}

	public String getAssessorDate() {
		return assessorDate;
	}

	public void setAssessorDate(String assessorDate) {
		this.assessorDate = assessorDate;
	}

	public String getAssessor() {
		return assessor;
	}

	public void setAssessor(String assessor) {
		this.assessor = assessor;
	}

}
