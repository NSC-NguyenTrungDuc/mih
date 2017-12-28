package nta.med.data.model.ihis.schs;

public class SCH3001U00GrdSCH0001Info {
	private String jundalTable;
    private String jundalPart;
    private String gumsaja;
    private String gumsajaName;
    private String jundalPartName;
    private String gwaGubun;
	public SCH3001U00GrdSCH0001Info(String jundalTable, String jundalPart,
			String gumsaja, String gumsajaName, String jundalPartName,
			String gwaGubun) {
		super();
		this.jundalTable = jundalTable;
		this.jundalPart = jundalPart;
		this.gumsaja = gumsaja;
		this.gumsajaName = gumsajaName;
		this.jundalPartName = jundalPartName;
		this.gwaGubun = gwaGubun;
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
	public String getGumsajaName() {
		return gumsajaName;
	}
	public void setGumsajaName(String gumsajaName) {
		this.gumsajaName = gumsajaName;
	}
	public String getJundalPartName() {
		return jundalPartName;
	}
	public void setJundalPartName(String jundalPartName) {
		this.jundalPartName = jundalPartName;
	}
	public String getGwaGubun() {
		return gwaGubun;
	}
	public void setGwaGubun(String gwaGubun) {
		this.gwaGubun = gwaGubun;
	}
}
