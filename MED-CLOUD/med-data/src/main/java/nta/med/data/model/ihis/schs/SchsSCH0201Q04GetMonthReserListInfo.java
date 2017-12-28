package nta.med.data.model.ihis.schs;

import java.util.Date;

public class SchsSCH0201Q04GetMonthReserListInfo {
	private Date holiDay ;
	private Integer reserCnt;
	private Integer inwonCnt;
	public SchsSCH0201Q04GetMonthReserListInfo(Date holiDay, Integer reserCnt,
			Integer inwonCnt) {
		super();
		this.holiDay = holiDay;
		this.reserCnt = reserCnt;
		this.inwonCnt = inwonCnt;
	}
	public Date getHoliDay() {
		return holiDay;
	}
	public void setHoliDay(Date holiDay) {
		this.holiDay = holiDay;
	}
	public Integer getReserCnt() {
		return reserCnt;
	}
	public void setReserCnt(Integer reserCnt) {
		this.reserCnt = reserCnt;
	}
	public Integer getInwonCnt() {
		return inwonCnt;
	}
	public void setInwonCnt(Integer inwonCnt) {
		this.inwonCnt = inwonCnt;
	}
	
	

}
