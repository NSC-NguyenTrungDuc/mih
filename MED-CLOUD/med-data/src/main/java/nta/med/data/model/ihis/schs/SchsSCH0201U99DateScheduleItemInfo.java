package nta.med.data.model.ihis.schs;

import java.util.Date;

public class SchsSCH0201U99DateScheduleItemInfo {
	private Date dayofmon;
	private String check_Yn;
	private String inwon;
	private String outwon;
	public SchsSCH0201U99DateScheduleItemInfo(Date dayofmon, String check_Yn, String inwon, String outwon) {
		super();
		this.dayofmon = dayofmon;
		this.check_Yn = check_Yn;
		this.inwon = inwon;
		this.outwon = outwon;
	}
	public Date getDayofmon() {
		return dayofmon;
	}
	public void setDayofmon(Date dayofmon) {
		this.dayofmon = dayofmon;
	}
	public String getCheck_Yn() {
		return check_Yn;
	}
	public void setCheck_Yn(String check_Yn) {
		this.check_Yn = check_Yn;
	}
	public String getInwon() {
		return inwon;
	}
	public void setInwon(String inwon) {
		this.inwon = inwon;
	}

	public String getOutwon() {
		return outwon;
	}

	public void setOutwon(String outwon) {
		this.outwon = outwon;
	}
}
