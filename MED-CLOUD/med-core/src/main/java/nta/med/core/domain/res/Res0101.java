package nta.med.core.domain.res;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.NamedQuery;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;


/**
 * The persistent class for the RES0101 database table.
 * 
 */
@Entity
@NamedQuery(name="Res0101.findAll", query="SELECT r FROM Res0101 r")
public class Res0101 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String dayGubun;
	private Date holiDay;
	private String holidayName;
	private String holidayYn;
	private String jinEndHhmm;
	private String jinStartHhmm;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;
	private String yoilGubun;

	public Res0101() {
	}


	@Column(name="DAY_GUBUN")
	public String getDayGubun() {
		return this.dayGubun;
	}

	public void setDayGubun(String dayGubun) {
		this.dayGubun = dayGubun;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="HOLI_DAY")
	public Date getHoliDay() {
		return this.holiDay;
	}

	public void setHoliDay(Date holiDay) {
		this.holiDay = holiDay;
	}


	@Column(name="HOLIDAY_NAME")
	public String getHolidayName() {
		return this.holidayName;
	}

	public void setHolidayName(String holidayName) {
		this.holidayName = holidayName;
	}


	@Column(name="HOLIDAY_YN")
	public String getHolidayYn() {
		return this.holidayYn;
	}

	public void setHolidayYn(String holidayYn) {
		this.holidayYn = holidayYn;
	}

	@Column(name="JIN_END_HHMM")
	public String getJinEndHhmm() {
		return this.jinEndHhmm;
	}

	public void setJinEndHhmm(String jinEndHhmm) {
		this.jinEndHhmm = jinEndHhmm;
	}


	@Column(name="JIN_START_HHMM")
	public String getJinStartHhmm() {
		return this.jinStartHhmm;
	}

	public void setJinStartHhmm(String jinStartHhmm) {
		this.jinStartHhmm = jinStartHhmm;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="SYS_DATE")
	public Date getSysDate() {
		return this.sysDate;
	}

	public void setSysDate(Date sysDate) {
		this.sysDate = sysDate;
	}


	@Column(name="SYS_ID")
	public String getSysId() {
		return this.sysId;
	}

	public void setSysId(String sysId) {
		this.sysId = sysId;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="UPD_DATE")
	public Date getUpdDate() {
		return this.updDate;
	}

	public void setUpdDate(Date updDate) {
		this.updDate = updDate;
	}


	@Column(name="UPD_ID")
	public String getUpdId() {
		return this.updId;
	}

	public void setUpdId(String updId) {
		this.updId = updId;
	}


	@Column(name="YOIL_GUBUN")
	public String getYoilGubun() {
		return this.yoilGubun;
	}

	public void setYoilGubun(String yoilGubun) {
		this.yoilGubun = yoilGubun;
	}

}