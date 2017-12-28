package nta.med.core.domain.nur;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the NUR5004 database table.
 * 
 */
@Entity
@NamedQuery(name="Nur5004.findAll", query="SELECT n FROM Nur5004 n")
public class Nur5004 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private double fknur5001;
	private String gilokId;
	private String gilokNote;
	private String gilokTime;
	private String hospCode;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Nur5004() {
	}


	public double getFknur5001() {
		return this.fknur5001;
	}

	public void setFknur5001(double fknur5001) {
		this.fknur5001 = fknur5001;
	}


	@Column(name="GILOK_ID")
	public String getGilokId() {
		return this.gilokId;
	}

	public void setGilokId(String gilokId) {
		this.gilokId = gilokId;
	}


	@Column(name="GILOK_NOTE")
	public String getGilokNote() {
		return this.gilokNote;
	}

	public void setGilokNote(String gilokNote) {
		this.gilokNote = gilokNote;
	}


	@Column(name="GILOK_TIME")
	public String getGilokTime() {
		return this.gilokTime;
	}

	public void setGilokTime(String gilokTime) {
		this.gilokTime = gilokTime;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
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