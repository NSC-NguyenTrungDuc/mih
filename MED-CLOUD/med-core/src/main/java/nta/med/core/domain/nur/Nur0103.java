package nta.med.core.domain.nur;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the NUR0103 database table.
 * 
 */
@Entity
@NamedQuery(name="Nur0103.findAll", query="SELECT n FROM Nur0103 n")
public class Nur0103 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String abbrCode;
	private String buseoCode;
	private String displayYn;
	private String gynmuCode;
	private String gynmuGroupCode;
	private String gynmuName;
	private double gynmuTime;
	private double holTime;
	private double holTime2;
	private String hospCode;
	private double insuTime;
	private String magamYn;
	private double seq;
	private String suCode;
	private String sudangCode;
	private double sudangTime;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Nur0103() {
	}


	@Column(name="ABBR_CODE")
	public String getAbbrCode() {
		return this.abbrCode;
	}

	public void setAbbrCode(String abbrCode) {
		this.abbrCode = abbrCode;
	}


	@Column(name="BUSEO_CODE")
	public String getBuseoCode() {
		return this.buseoCode;
	}

	public void setBuseoCode(String buseoCode) {
		this.buseoCode = buseoCode;
	}


	@Column(name="DISPLAY_YN")
	public String getDisplayYn() {
		return this.displayYn;
	}

	public void setDisplayYn(String displayYn) {
		this.displayYn = displayYn;
	}


	@Column(name="GYNMU_CODE")
	public String getGynmuCode() {
		return this.gynmuCode;
	}

	public void setGynmuCode(String gynmuCode) {
		this.gynmuCode = gynmuCode;
	}


	@Column(name="GYNMU_GROUP_CODE")
	public String getGynmuGroupCode() {
		return this.gynmuGroupCode;
	}

	public void setGynmuGroupCode(String gynmuGroupCode) {
		this.gynmuGroupCode = gynmuGroupCode;
	}


	@Column(name="GYNMU_NAME")
	public String getGynmuName() {
		return this.gynmuName;
	}

	public void setGynmuName(String gynmuName) {
		this.gynmuName = gynmuName;
	}


	@Column(name="GYNMU_TIME")
	public double getGynmuTime() {
		return this.gynmuTime;
	}

	public void setGynmuTime(double gynmuTime) {
		this.gynmuTime = gynmuTime;
	}


	@Column(name="HOL_TIME")
	public double getHolTime() {
		return this.holTime;
	}

	public void setHolTime(double holTime) {
		this.holTime = holTime;
	}


	@Column(name="HOL_TIME2")
	public double getHolTime2() {
		return this.holTime2;
	}

	public void setHolTime2(double holTime2) {
		this.holTime2 = holTime2;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="INSU_TIME")
	public double getInsuTime() {
		return this.insuTime;
	}

	public void setInsuTime(double insuTime) {
		this.insuTime = insuTime;
	}


	@Column(name="MAGAM_YN")
	public String getMagamYn() {
		return this.magamYn;
	}

	public void setMagamYn(String magamYn) {
		this.magamYn = magamYn;
	}


	public double getSeq() {
		return this.seq;
	}

	public void setSeq(double seq) {
		this.seq = seq;
	}


	@Column(name="SU_CODE")
	public String getSuCode() {
		return this.suCode;
	}

	public void setSuCode(String suCode) {
		this.suCode = suCode;
	}


	@Column(name="SUDANG_CODE")
	public String getSudangCode() {
		return this.sudangCode;
	}

	public void setSudangCode(String sudangCode) {
		this.sudangCode = sudangCode;
	}


	@Column(name="SUDANG_TIME")
	public double getSudangTime() {
		return this.sudangTime;
	}

	public void setSudangTime(double sudangTime) {
		this.sudangTime = sudangTime;
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

}