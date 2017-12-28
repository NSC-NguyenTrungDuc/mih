package nta.med.data.model.ihis.nuro;

public class CompanyInsurance {

	private String gubun;
	private String johap;
	private String startDate;
	private String endDate;
	private String gaein;
	private String gaeinNo;
	private String bonGaGubun;

	public CompanyInsurance(String gubun, String johap, String startDate, String endDate, String gaein, String gaeinNo,
			String bonGaGubun) {
		super();
		this.gubun = gubun;
		this.johap = johap;
		this.startDate = startDate;
		this.endDate = endDate;
		this.gaein = gaein;
		this.gaeinNo = gaeinNo;
		this.bonGaGubun = bonGaGubun;
	}

	public String getGubun() {
		return gubun;
	}

	public void setGubun(String gubun) {
		this.gubun = gubun;
	}

	public String getJohap() {
		return johap;
	}

	public void setJohap(String johap) {
		this.johap = johap;
	}

	public String getStartDate() {
		return startDate;
	}

	public void setStartDate(String startDate) {
		this.startDate = startDate;
	}

	public String getEndDate() {
		return endDate;
	}

	public void setEndDate(String endDate) {
		this.endDate = endDate;
	}

	public String getGaein() {
		return gaein;
	}

	public void setGaein(String gaein) {
		this.gaein = gaein;
	}

	public String getGaeinNo() {
		return gaeinNo;
	}

	public void setGaeinNo(String gaeinNo) {
		this.gaeinNo = gaeinNo;
	}

	public String getBonGaGubun() {
		return bonGaGubun;
	}

	public void setBonGaGubun(String bonGaGubun) {
		this.bonGaGubun = bonGaGubun;
	}

}
