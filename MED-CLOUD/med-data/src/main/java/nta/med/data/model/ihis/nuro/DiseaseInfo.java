package nta.med.data.model.ihis.nuro;

public class DiseaseInfo {

	private String diseaseCode;
	private String diseaseStartDate;
	private String diseaseEndDate;
	private String diseaseSuspectedFlag;
	private String diseaseName;
	private String diseaseOutCome;

	public DiseaseInfo(String diseaseCode, String diseaseStartDate, String diseaseEndDate, String diseaseSuspectedFlag,
			String diseaseName, String diseaseOutCome) {
		super();
		this.diseaseCode = diseaseCode;
		this.diseaseStartDate = diseaseStartDate;
		this.diseaseEndDate = diseaseEndDate;
		this.diseaseSuspectedFlag = diseaseSuspectedFlag;
		this.diseaseName = diseaseName;
		this.diseaseOutCome = diseaseOutCome;
	}

	public String getDiseaseCode() {
		return diseaseCode;
	}

	public void setDiseaseCode(String diseaseCode) {
		this.diseaseCode = diseaseCode;
	}

	public String getDiseaseStartDate() {
		return diseaseStartDate;
	}

	public void setDiseaseStartDate(String diseaseStartDate) {
		this.diseaseStartDate = diseaseStartDate;
	}

	public String getDiseaseEndDate() {
		return diseaseEndDate;
	}

	public void setDiseaseEndDate(String diseaseEndDate) {
		this.diseaseEndDate = diseaseEndDate;
	}

	public String getDiseaseSuspectedFlag() {
		return diseaseSuspectedFlag;
	}

	public void setDiseaseSuspectedFlag(String diseaseSuspectedFlag) {
		this.diseaseSuspectedFlag = diseaseSuspectedFlag;
	}

	public String getDiseaseName() {
		return diseaseName;
	}

	public void setDiseaseName(String diseaseName) {
		this.diseaseName = diseaseName;
	}

	public String getDiseaseOutCome() {
		return diseaseOutCome;
	}

	public void setDiseaseOutCome(String diseaseOutCome) {
		this.diseaseOutCome = diseaseOutCome;
	}

}
