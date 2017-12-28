package nta.med.data.model.ihis.nuro;

public class NUR2015U01GrdOrderInfo {
	private String examDate;
	private String gwa;
	private Double naewonKey;
	private String gwaName;

	public NUR2015U01GrdOrderInfo(String examDate, String gwa, Double naewonKey, String gwaName) {
		super();
		this.examDate = examDate;
		this.gwa = gwa;
		this.naewonKey = naewonKey;
		this.gwaName = gwaName;
	}

	public String getExamDate() {
		return examDate;
	}

	public void setExamDate(String examDate) {
		this.examDate = examDate;
	}

	public String getGwa() {
		return gwa;
	}

	public void setGwa(String gwa) {
		this.gwa = gwa;
	}

	public Double getNaewonKey() {
		return naewonKey;
	}

	public void setNaewonKey(Double naewonKey) {
		this.naewonKey = naewonKey;
	}

	public String getGwaName() {
		return gwaName;
	}

	public void setGwaName(String gwaName) {
		this.gwaName = gwaName;
	}

}
