package nta.med.data.model.ihis.nuri;

public class NUR1001U00GrdNUR1016Info {
	private String startDate;
	private String codeName;
	private String allergyInfo;
	private String dataRowState;
	
	public NUR1001U00GrdNUR1016Info(String startDate, String codeName, String allergyInfo, String dataRowState) {
		super();
		this.startDate = startDate;
		this.codeName = codeName;
		this.allergyInfo = allergyInfo;
		this.dataRowState = dataRowState;
	}

	public String getStartDate() {
		return startDate;
	}

	public void setStartDate(String startDate) {
		this.startDate = startDate;
	}

	public String getCodeName() {
		return codeName;
	}

	public void setCodeName(String codeName) {
		this.codeName = codeName;
	}

	public String getAllergyInfo() {
		return allergyInfo;
	}

	public void setAllergyInfo(String allergyInfo) {
		this.allergyInfo = allergyInfo;
	}

	public String getDataRowState() {
		return dataRowState;
	}

	public void setDataRowState(String dataRowState) {
		this.dataRowState = dataRowState;
	}
	
}
