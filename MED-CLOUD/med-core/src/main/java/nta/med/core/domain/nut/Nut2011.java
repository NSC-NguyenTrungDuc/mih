package nta.med.core.domain.nut;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;

/**
 * The persistent class for the NUT2011 database table.
 * 
 */
@Entity
@Table(name = "NUT2011")
public class Nut2011 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String bldGubun;
	private String hospCode;
	private String ifSendFlag;
	private String magamKey;
	private Double magamSeq;
	private Date nutDate;
	private Double pknut2011;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Nut2011() {
	}

	@Column(name = "BLD_GUBUN")
	public String getBldGubun() {
		return this.bldGubun;
	}

	public void setBldGubun(String bldGubun) {
		this.bldGubun = bldGubun;
	}

	@Column(name = "HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}

	@Column(name = "IF_SEND_FLAG")
	public String getIfSendFlag() {
		return this.ifSendFlag;
	}

	public void setIfSendFlag(String ifSendFlag) {
		this.ifSendFlag = ifSendFlag;
	}

	@Column(name = "MAGAM_KEY")
	public String getMagamKey() {
		return this.magamKey;
	}

	public void setMagamKey(String magamKey) {
		this.magamKey = magamKey;
	}

	@Column(name = "MAGAM_SEQ")
	public Double getMagamSeq() {
		return this.magamSeq;
	}

	public void setMagamSeq(Double magamSeq) {
		this.magamSeq = magamSeq;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "NUT_DATE")
	public Date getNutDate() {
		return this.nutDate;
	}

	public void setNutDate(Date nutDate) {
		this.nutDate = nutDate;
	}

	public Double getPknut2011() {
		return this.pknut2011;
	}

	public void setPknut2011(Double pknut2011) {
		this.pknut2011 = pknut2011;
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