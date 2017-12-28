package nta.med.data.model.ihis.nuri;

public class NUR1010U00grdNur1010Info {
	private String bunho;
	private Double fkinp1001;
	private String damdangNurse;
	private String damdangNurseName;
	private String jukyongDate;
	private String dataRowState;
	
	public NUR1010U00grdNur1010Info(String bunho, Double fkinp1001, String damdangNurse, String damdangNurseName,
			String jukyongDate, String dataRowState) {
		super();
		this.bunho = bunho;
		this.fkinp1001 = fkinp1001;
		this.damdangNurse = damdangNurse;
		this.damdangNurseName = damdangNurseName;
		this.jukyongDate = jukyongDate;
		this.dataRowState = dataRowState;
	}

	public String getBunho() {
		return bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}

	public Double getFkinp1001() {
		return fkinp1001;
	}

	public void setFkinp1001(Double fkinp1001) {
		this.fkinp1001 = fkinp1001;
	}

	public String getDamdangNurse() {
		return damdangNurse;
	}

	public void setDamdangNurse(String damdangNurse) {
		this.damdangNurse = damdangNurse;
	}

	public String getDamdangNurseName() {
		return damdangNurseName;
	}

	public void setDamdangNurseName(String damdangNurseName) {
		this.damdangNurseName = damdangNurseName;
	}

	public String getJukyongDate() {
		return jukyongDate;
	}

	public void setJukyongDate(String jukyongDate) {
		this.jukyongDate = jukyongDate;
	}

	public String getDataRowState() {
		return dataRowState;
	}

	public void setDataRowState(String dataRowState) {
		this.dataRowState = dataRowState;
	}
	
}
