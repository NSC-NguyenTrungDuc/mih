package nta.med.core.domain.res;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.math.BigDecimal;
import java.util.Date;


/**
 * The persistent class for the RES0105 database table.
 * 
 */
@Entity
@NamedQuery(name="Res0105.findAll", query="SELECT r FROM Res0105 r")
public class Res0105 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String doctor;
	private String fri;
	private String friColor;
	private BigDecimal friInwon;
	private String hospCode;
	private String mon;
	private String monColor;
	private BigDecimal monInwon;
	private String sat;
	private String satColor;
	private BigDecimal satInwon;
	private String sun;
	private String sunColor;
	private BigDecimal sunInwon;
	private Date sysDate;
	private String sysId;
	private String thu;
	private String thuColor;
	private BigDecimal thuInwon;
	private String tue;
	private String tueColor;
	private BigDecimal tueInwon;
	private Date updDate;
	private String updId;
	private String wed;
	private String wedColor;
	private BigDecimal wedInwon;
	private double week;
	private String yymm;

	public Res0105() {
	}


	public String getDoctor() {
		return this.doctor;
	}

	public void setDoctor(String doctor) {
		this.doctor = doctor;
	}


	public String getFri() {
		return this.fri;
	}

	public void setFri(String fri) {
		this.fri = fri;
	}


	@Column(name="FRI_COLOR")
	public String getFriColor() {
		return this.friColor;
	}

	public void setFriColor(String friColor) {
		this.friColor = friColor;
	}


	@Column(name="FRI_INWON")
	public BigDecimal getFriInwon() {
		return this.friInwon;
	}

	public void setFriInwon(BigDecimal friInwon) {
		this.friInwon = friInwon;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	public String getMon() {
		return this.mon;
	}

	public void setMon(String mon) {
		this.mon = mon;
	}


	@Column(name="MON_COLOR")
	public String getMonColor() {
		return this.monColor;
	}

	public void setMonColor(String monColor) {
		this.monColor = monColor;
	}


	@Column(name="MON_INWON")
	public BigDecimal getMonInwon() {
		return this.monInwon;
	}

	public void setMonInwon(BigDecimal monInwon) {
		this.monInwon = monInwon;
	}


	public String getSat() {
		return this.sat;
	}

	public void setSat(String sat) {
		this.sat = sat;
	}


	@Column(name="SAT_COLOR")
	public String getSatColor() {
		return this.satColor;
	}

	public void setSatColor(String satColor) {
		this.satColor = satColor;
	}


	@Column(name="SAT_INWON")
	public BigDecimal getSatInwon() {
		return this.satInwon;
	}

	public void setSatInwon(BigDecimal satInwon) {
		this.satInwon = satInwon;
	}


	public String getSun() {
		return this.sun;
	}

	public void setSun(String sun) {
		this.sun = sun;
	}


	@Column(name="SUN_COLOR")
	public String getSunColor() {
		return this.sunColor;
	}

	public void setSunColor(String sunColor) {
		this.sunColor = sunColor;
	}


	@Column(name="SUN_INWON")
	public BigDecimal getSunInwon() {
		return this.sunInwon;
	}

	public void setSunInwon(BigDecimal sunInwon) {
		this.sunInwon = sunInwon;
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


	public String getThu() {
		return this.thu;
	}

	public void setThu(String thu) {
		this.thu = thu;
	}


	@Column(name="THU_COLOR")
	public String getThuColor() {
		return this.thuColor;
	}

	public void setThuColor(String thuColor) {
		this.thuColor = thuColor;
	}


	@Column(name="THU_INWON")
	public BigDecimal getThuInwon() {
		return this.thuInwon;
	}

	public void setThuInwon(BigDecimal thuInwon) {
		this.thuInwon = thuInwon;
	}


	public String getTue() {
		return this.tue;
	}

	public void setTue(String tue) {
		this.tue = tue;
	}


	@Column(name="TUE_COLOR")
	public String getTueColor() {
		return this.tueColor;
	}

	public void setTueColor(String tueColor) {
		this.tueColor = tueColor;
	}


	@Column(name="TUE_INWON")
	public BigDecimal getTueInwon() {
		return this.tueInwon;
	}

	public void setTueInwon(BigDecimal tueInwon) {
		this.tueInwon = tueInwon;
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


	public String getWed() {
		return this.wed;
	}

	public void setWed(String wed) {
		this.wed = wed;
	}


	@Column(name="WED_COLOR")
	public String getWedColor() {
		return this.wedColor;
	}

	public void setWedColor(String wedColor) {
		this.wedColor = wedColor;
	}


	@Column(name="WED_INWON")
	public BigDecimal getWedInwon() {
		return this.wedInwon;
	}

	public void setWedInwon(BigDecimal wedInwon) {
		this.wedInwon = wedInwon;
	}


	public double getWeek() {
		return this.week;
	}

	public void setWeek(double week) {
		this.week = week;
	}


	public String getYymm() {
		return this.yymm;
	}

	public void setYymm(String yymm) {
		this.yymm = yymm;
	}

}