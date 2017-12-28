package nta.med.core.domain.nur;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the NUR1021 database table.
 * 
 */
@Entity
@NamedQuery(name="Nur1021.findAll", query="SELECT n FROM Nur1021 n")
public class Nur1021 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String bunho;
	private double fkinp1001;
	private String hospCode;
	private String nutGubn;
	private double nutValue;
	private double nutValue2;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;
	private Date ymd;

	public Nur1021() {
	}


	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}


	public double getFkinp1001() {
		return this.fkinp1001;
	}

	public void setFkinp1001(double fkinp1001) {
		this.fkinp1001 = fkinp1001;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="NUT_GUBN")
	public String getNutGubn() {
		return this.nutGubn;
	}

	public void setNutGubn(String nutGubn) {
		this.nutGubn = nutGubn;
	}


	@Column(name="NUT_VALUE")
	public double getNutValue() {
		return this.nutValue;
	}

	public void setNutValue(double nutValue) {
		this.nutValue = nutValue;
	}


	@Column(name="NUT_VALUE2")
	public double getNutValue2() {
		return this.nutValue2;
	}

	public void setNutValue2(double nutValue2) {
		this.nutValue2 = nutValue2;
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


	@Temporal(TemporalType.TIMESTAMP)
	public Date getYmd() {
		return this.ymd;
	}

	public void setYmd(Date ymd) {
		this.ymd = ymd;
	}

}