package nta.med.data.model.ihis.nuro;

public class PublicInsurance {

	private String priority;
	private String gongbiCode;
	private String startDate;
	private String endDate;
	private String sugubjaBunho;
	private String budamja;

	public PublicInsurance(String priority, String gongbiCode, String startDate, String endDate, String sugubjaBunho,
			String budamja) {
		super();
		this.priority = priority;
		this.gongbiCode = gongbiCode;
		this.startDate = startDate;
		this.endDate = endDate;
		this.sugubjaBunho = sugubjaBunho;
		this.budamja = budamja;
	}

	public String getPriority() {
		return priority;
	}

	public void setPriority(String priority) {
		this.priority = priority;
	}

	public String getGongbiCode() {
		return gongbiCode;
	}

	public void setGongbiCode(String gongbiCode) {
		this.gongbiCode = gongbiCode;
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

	public String getSugubjaBunho() {
		return sugubjaBunho;
	}

	public void setSugubjaBunho(String sugubjaBunho) {
		this.sugubjaBunho = sugubjaBunho;
	}

	public String getBudamja() {
		return budamja;
	}

	public void setBudamja(String budamja) {
		this.budamja = budamja;
	}

}
