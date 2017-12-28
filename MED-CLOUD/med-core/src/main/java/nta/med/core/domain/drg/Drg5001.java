package nta.med.core.domain.drg;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;

/**
 * The persistent class for the DRG5001 database table.
 * 
 */
@Entity
@Table(name = "DRG5001")
public class Drg5001 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String hoDong;
	private String hospCode;
	private Date magamDate;
	private String magamYn;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Drg5001() {
	}

	@Column(name = "HO_DONG")
	public String getHoDong() {
		return this.hoDong;
	}

	public void setHoDong(String hoDong) {
		this.hoDong = hoDong;
	}

	@Column(name = "HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "MAGAM_DATE")
	public Date getMagamDate() {
		return this.magamDate;
	}

	public void setMagamDate(Date magamDate) {
		this.magamDate = magamDate;
	}

	@Column(name = "MAGAM_YN")
	public String getMagamYn() {
		return this.magamYn;
	}

	public void setMagamYn(String magamYn) {
		this.magamYn = magamYn;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "SYS_DATE")
	public Date getSysDate() {
		return this.sysDate;
	}

	public void setSysDate(Date sysDate) {
		this.sysDate = sysDate;
	}

	@Column(name = "SYS_ID")
	public String getSysId() {
		return this.sysId;
	}

	public void setSysId(String sysId) {
		this.sysId = sysId;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "UPD_DATE")
	public Date getUpdDate() {
		return this.updDate;
	}

	public void setUpdDate(Date updDate) {
		this.updDate = updDate;
	}

	@Column(name = "UPD_ID")
	public String getUpdId() {
		return this.updId;
	}

	public void setUpdId(String updId) {
		this.updId = updId;
	}

}