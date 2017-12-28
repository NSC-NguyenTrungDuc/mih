package nta.med.data.model.ihis.schs;

public class SCH3001U00GrdSCH0002Info {
	private String jundalTable;
    private String jundalPart;
    private String gumsaja;
    private String hangmogCode;
    private String hangmogName;
    private Double gumsaTime;
	public SCH3001U00GrdSCH0002Info(String jundalTable, String jundalPart,
			String gumsaja, String hangmogCode, String hangmogName,
			Double gumsaTime) {
		super();
		this.jundalTable = jundalTable;
		this.jundalPart = jundalPart;
		this.gumsaja = gumsaja;
		this.hangmogCode = hangmogCode;
		this.hangmogName = hangmogName;
		this.gumsaTime = gumsaTime;
	}
	public String getJundalTable() {
		return jundalTable;
	}
	public void setJundalTable(String jundalTable) {
		this.jundalTable = jundalTable;
	}
	public String getJundalPart() {
		return jundalPart;
	}
	public void setJundalPart(String jundalPart) {
		this.jundalPart = jundalPart;
	}
	public String getGumsaja() {
		return gumsaja;
	}
	public void setGumsaja(String gumsaja) {
		this.gumsaja = gumsaja;
	}
	public String getHangmogCode() {
		return hangmogCode;
	}
	public void setHangmogCode(String hangmogCode) {
		this.hangmogCode = hangmogCode;
	}
	public String getHangmogName() {
		return hangmogName;
	}
	public void setHangmogName(String hangmogName) {
		this.hangmogName = hangmogName;
	}
	public Double getGumsaTime() {
		return gumsaTime;
	}
	public void setGumsaTime(Double gumsaTime) {
		this.gumsaTime = gumsaTime;
	}
}
