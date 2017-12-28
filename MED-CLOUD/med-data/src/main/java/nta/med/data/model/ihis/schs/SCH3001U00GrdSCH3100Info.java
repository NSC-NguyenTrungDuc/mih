package nta.med.data.model.ihis.schs;

import java.sql.Timestamp;

public class SCH3001U00GrdSCH3100Info {
	private String jundalTable;
    private String jundalPart;
    private String gumsaja;
    private Timestamp reserDate;
    private String reserYn;
	public SCH3001U00GrdSCH3100Info(String jundalTable, String jundalPart,
			String gumsaja, Timestamp reserDate, String reserYn) {
		super();
		this.jundalTable = jundalTable;
		this.jundalPart = jundalPart;
		this.gumsaja = gumsaja;
		this.reserDate = reserDate;
		this.reserYn = reserYn;
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
	public Timestamp getReserDate() {
		return reserDate;
	}
	public void setReserDate(Timestamp reserDate) {
		this.reserDate = reserDate;
	}
	public String getReserYn() {
		return reserYn;
	}
	public void setReserYn(String reserYn) {
		this.reserYn = reserYn;
	}
}
