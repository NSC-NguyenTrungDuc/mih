package nta.med.data.model.ihis.schs;

import java.sql.Timestamp;

public class SCH3001U00GrdSCH3000Info {
	private Timestamp jukyongDate;
    private String jundalTable;
    private String jundalPart;
    private String gumsaja;
    private String yoilGubun; 
    private String startTime;
    private String endTime;
    private Double iwon;
    private Double addIwon;
    private Double outHospSlot;
	public SCH3001U00GrdSCH3000Info(Timestamp jukyongDate, String jundalTable,
			String jundalPart, String gumsaja, String yoilGubun,
			String startTime, String endTime, Double iwon, Double addIwon, Double outHospSlot) {
		super();
		this.jukyongDate = jukyongDate;
		this.jundalTable = jundalTable;
		this.jundalPart = jundalPart;
		this.gumsaja = gumsaja;
		this.yoilGubun = yoilGubun;
		this.startTime = startTime;
		this.endTime = endTime;
		this.iwon = iwon;
		this.addIwon = addIwon;
		this.outHospSlot = outHospSlot;
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
	public String getYoilGubun() {
		return yoilGubun;
	}
	public void setYoilGubun(String yoilGubun) {
		this.yoilGubun = yoilGubun;
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

	public Double getOutHospSlot() {
		return outHospSlot;
	}

	public void setOutHospSlot(Double outHospSlot) {
		this.outHospSlot = outHospSlot;
	}
}
