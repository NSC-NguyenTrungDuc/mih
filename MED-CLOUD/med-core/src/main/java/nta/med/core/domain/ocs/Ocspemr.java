package nta.med.core.domain.ocs;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;

/**
 * The persistent class for the OCSPEMR database table.
 * 
 */
@Entity
@Table(name = "OCSPEMR")
public class Ocspemr extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String dwId;
	private String hospCode;
	private String pgmId;
	private String shetshtid;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;
	private String ioGubun;

	public Ocspemr() {
	}

	@Column(name = "DW_ID")
	public String getDwId() {
		return this.dwId;
	}

	public void setDwId(String dwId) {
		this.dwId = dwId;
	}

	@Column(name = "HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}

	@Column(name = "PGM_ID")
	public String getPgmId() {
		return this.pgmId;
	}

	public void setPgmId(String pgmId) {
		this.pgmId = pgmId;
	}

	public String getShetshtid() {
		return this.shetshtid;
	}

	public void setShetshtid(String shetshtid) {
		this.shetshtid = shetshtid;
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

	@Column(name = "IO_GUBUN")
	public String getIoGubun() {
		return ioGubun;
	}

	public void setIoGubun(String ioGubun) {
		this.ioGubun = ioGubun;
	}

}