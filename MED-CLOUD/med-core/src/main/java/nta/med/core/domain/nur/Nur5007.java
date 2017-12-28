package nta.med.core.domain.nur;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the NUR5007 database table.
 * 
 */
@Entity
@NamedQuery(name="Nur5007.findAll", query="SELECT n FROM Nur5007 n")
public class Nur5007 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private double fknur5001;
	private String hospCode;
	private double pknur5007;
	private String sangText;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;
	private String vald;

	public Nur5007() {
	}


	public double getFknur5001() {
		return this.fknur5001;
	}

	public void setFknur5001(double fknur5001) {
		this.fknur5001 = fknur5001;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	public double getPknur5007() {
		return this.pknur5007;
	}

	public void setPknur5007(double pknur5007) {
		this.pknur5007 = pknur5007;
	}


	@Column(name="SANG_TEXT")
	public String getSangText() {
		return this.sangText;
	}

	public void setSangText(String sangText) {
		this.sangText = sangText;
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


	public String getVald() {
		return this.vald;
	}

	public void setVald(String vald) {
		this.vald = vald;
	}

}