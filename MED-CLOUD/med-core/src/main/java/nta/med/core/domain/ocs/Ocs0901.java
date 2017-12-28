package nta.med.core.domain.ocs;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the OCS0901 database table.
 * 
 */
@Entity
@NamedQuery(name="Ocs0901.findAll", query="SELECT o FROM Ocs0901 o")
public class Ocs0901 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String hospCode;
	private double num;
	private double pulse;
	private double respiration;
	private Date sysDate;
	private String sysId;
	private double temperature;
	private Date updDate;
	private String updId;

	public Ocs0901() {
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	public double getNum() {
		return this.num;
	}

	public void setNum(double num) {
		this.num = num;
	}


	public double getPulse() {
		return this.pulse;
	}

	public void setPulse(double pulse) {
		this.pulse = pulse;
	}


	public double getRespiration() {
		return this.respiration;
	}

	public void setRespiration(double respiration) {
		this.respiration = respiration;
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


	public double getTemperature() {
		return this.temperature;
	}

	public void setTemperature(double temperature) {
		this.temperature = temperature;
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