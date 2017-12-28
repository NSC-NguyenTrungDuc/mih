package nta.med.data.model.ihis.schs;

import java.sql.Timestamp;

public class SCH3001U00GrdJukyongDateInfo {
	private Timestamp jukyongDate;
    private String jundalTable;
    private String jundalPart;
    private String gumsaja;
    private Timestamp oldJukyongDate;
    private String monDay;
    private String tueDay;
    private String wedDay;
    private String thuDay;
    private String friDay;
    private String staDay;
    private String sunDay;
	public SCH3001U00GrdJukyongDateInfo(Timestamp jukyongDate,
			String jundalTable, String jundalPart, String gumsaja,
			Timestamp oldJukyongDate, String monDay, String tueDay,
			String wedDay, String thuDay, String friDay, String staDay,
			String sunDay) {
		super();
		this.jukyongDate = jukyongDate;
		this.jundalTable = jundalTable;
		this.jundalPart = jundalPart;
		this.gumsaja = gumsaja;
		this.oldJukyongDate = oldJukyongDate;
		this.monDay = monDay;
		this.tueDay = tueDay;
		this.wedDay = wedDay;
		this.thuDay = thuDay;
		this.friDay = friDay;
		this.staDay = staDay;
		this.sunDay = sunDay;
	}
	public Timestamp getJukyongDate() {
		return jukyongDate;
	}
	public void setJukyongDate(Timestamp jukyongDate) {
		this.jukyongDate = jukyongDate;
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
	public Timestamp getOldJukyongDate() {
		return oldJukyongDate;
	}
	public void setOldJukyongDate(Timestamp oldJukyongDate) {
		this.oldJukyongDate = oldJukyongDate;
	}
	public String getMonDay() {
		return monDay;
	}
	public void setMonDay(String monDay) {
		this.monDay = monDay;
	}
	public String getTueDay() {
		return tueDay;
	}
	public void setTueDay(String tueDay) {
		this.tueDay = tueDay;
	}
	public String getWedDay() {
		return wedDay;
	}
	public void setWedDay(String wedDay) {
		this.wedDay = wedDay;
	}
	public String getThuDay() {
		return thuDay;
	}
	public void setThuDay(String thuDay) {
		this.thuDay = thuDay;
	}
	public String getFriDay() {
		return friDay;
	}
	public void setFriDay(String friDay) {
		this.friDay = friDay;
	}
	public String getStaDay() {
		return staDay;
	}
	public void setStaDay(String staDay) {
		this.staDay = staDay;
	}
	public String getSunDay() {
		return sunDay;
	}
	public void setSunDay(String sunDay) {
		this.sunDay = sunDay;
	}
    
}
