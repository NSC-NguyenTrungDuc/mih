package nta.med.data.model.ihis.schs;

import java.sql.Timestamp;

public class SCH3001U00GrdSCH3101Info {
	private String jundalTable;
    private String jundalPart;
    private String gumsaja;
    private Timestamp reserDate;
    private String startTime;
    private String endTime;
    private Double iwon;
    private Double addIwon;
	public SCH3001U00GrdSCH3101Info(String jundalTable, String jundalPart,
			String gumsaja, Timestamp reserDate, String startTime,
			String endTime, Double iwon, Double addIwon) {
		super();
		this.jundalTable = jundalTable;
		this.jundalPart = jundalPart;
		this.gumsaja = gumsaja;
		this.reserDate = reserDate;
		this.startTime = startTime;
		this.endTime = endTime;
		this.iwon = iwon;
		this.addIwon = addIwon;
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
	public String getStartTime() {
		return startTime;
	}
	public void setStartTime(String startTime) {
		this.startTime = startTime;
	}
	public String getEndTime() {
		return endTime;
	}
	public void setEndTime(String endTime) {
		this.endTime = endTime;
	}
	public Double getIwon() {
		return iwon;
	}
	public void setIwon(Double iwon) {
		this.iwon = iwon;
	}
	public Double getAddIwon() {
		return addIwon;
	}
	public void setAddIwon(Double addIwon) {
		this.addIwon = addIwon;
	}
}
