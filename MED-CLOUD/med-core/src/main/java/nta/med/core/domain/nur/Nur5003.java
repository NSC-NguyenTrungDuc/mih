package nta.med.core.domain.nur;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the NUR5003 database table.
 * 
 */
@Entity
@NamedQuery(name="Nur5003.findAll", query="SELECT n FROM Nur5003 n")
public class Nur5003 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String balzak;
	private double fknur5001;
	private String ganhul;
	private String hospCode;
	private String measureTime;
	private double simumsu;
	private String sungzil;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Nur5003() {
	}


	public String getBalzak() {
		return this.balzak;
	}

	public void setBalzak(String balzak) {
		this.balzak = balzak;
	}


	public double getFknur5001() {
		return this.fknur5001;
	}

	public void setFknur5001(double fknur5001) {
		this.fknur5001 = fknur5001;
	}


	public String getGanhul() {
		return this.ganhul;
	}

	public void setGanhul(String ganhul) {
		this.ganhul = ganhul;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="MEASURE_TIME")
	public String getMeasureTime() {
		return this.measureTime;
	}

	public void setMeasureTime(String measureTime) {
		this.measureTime = measureTime;
	}


	public double getSimumsu() {
		return this.simumsu;
	}

	public void setSimumsu(double simumsu) {
		this.simumsu = simumsu;
	}


	public String getSungzil() {
		return this.sungzil;
	}

	public void setSungzil(String sungzil) {
		this.sungzil = sungzil;
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