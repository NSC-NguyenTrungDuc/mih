package nta.med.data.model.ihis.nuri;

public class NUR1035U00grdNUR1035Info {
	private Double fkinp1001;
	private Double pknur1035;
	private String methodCode;
	private String startDate;
	private String endDate;
	private String inputId;
	private String inputName;
	private String checkYn;
	private String dataRowState;
	
	public NUR1035U00grdNUR1035Info(Double fkinp1001, Double pknur1035, String methodCode, String startDate,
			String endDate, String inputId, String inputName, String checkYn, String dataRowState) {
		super();
		this.fkinp1001 = fkinp1001;
		this.pknur1035 = pknur1035;
		this.methodCode = methodCode;
		this.startDate = startDate;
		this.endDate = endDate;
		this.inputId = inputId;
		this.inputName = inputName;
		this.checkYn = checkYn;
		this.dataRowState = dataRowState;
	}

	public Double getFkinp1001() {
		return fkinp1001;
	}

	public void setFkinp1001(Double fkinp1001) {
		this.fkinp1001 = fkinp1001;
	}

	public Double getPknur1035() {
		return pknur1035;
	}

	public void setPknur1035(Double pknur1035) {
		this.pknur1035 = pknur1035;
	}

	public String getMethodCode() {
		return methodCode;
	}

	public void setMethodCode(String methodCode) {
		this.methodCode = methodCode;
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

	public String getInputId() {
		return inputId;
	}

	public void setInputId(String inputId) {
		this.inputId = inputId;
	}

	public String getInputName() {
		return inputName;
	}

	public void setInputName(String inputName) {
		this.inputName = inputName;
	}

	public String getCheckYn() {
		return checkYn;
	}

	public void setCheckYn(String checkYn) {
		this.checkYn = checkYn;
	}

	public String getDataRowState() {
		return dataRowState;
	}

	public void setDataRowState(String dataRowState) {
		this.dataRowState = dataRowState;
	}
	
}
