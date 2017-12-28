package nta.med.core.domain.ifs;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;

import javax.persistence.*;

import java.util.Date;


/**
 * The persistent class for the IFS0003 database table.
 * 
 */
@Entity
@Table(name="IFS0003")
public class Ifs0003 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String hospCode;
	private String ifCode;
	private String ifDefaultYn;
	private String mapGubun;
	private Date mapGubunYmd;
	private String ocsCode;
	private String ocsDefaultYn;
	private String remark;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;
	private String acctType;

	public Ifs0003() {
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="IF_CODE")
	public String getIfCode() {
		return this.ifCode;
	}

	public void setIfCode(String ifCode) {
		this.ifCode = ifCode;
	}


	@Column(name="IF_DEFAULT_YN")
	public String getIfDefaultYn() {
		return this.ifDefaultYn;
	}

	public void setIfDefaultYn(String ifDefaultYn) {
		this.ifDefaultYn = ifDefaultYn;
	}


	@Column(name="MAP_GUBUN")
	public String getMapGubun() {
		return this.mapGubun;
	}

	public void setMapGubun(String mapGubun) {
		this.mapGubun = mapGubun;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="MAP_GUBUN_YMD")
	public Date getMapGubunYmd() {
		return this.mapGubunYmd;
	}

	public void setMapGubunYmd(Date mapGubunYmd) {
		this.mapGubunYmd = mapGubunYmd;
	}


	@Column(name="OCS_CODE")
	public String getOcsCode() {
		return this.ocsCode;
	}

	public void setOcsCode(String ocsCode) {
		this.ocsCode = ocsCode;
	}


	@Column(name="OCS_DEFAULT_YN")
	public String getOcsDefaultYn() {
		return this.ocsDefaultYn;
	}

	public void setOcsDefaultYn(String ocsDefaultYn) {
		this.ocsDefaultYn = ocsDefaultYn;
	}


	public String getRemark() {
		return this.remark;
	}

	public void setRemark(String remark) {
		this.remark = remark;
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
	
	@Column(name="ACCT_TYPE")
	public String getAcctType() {
		return this.acctType;
	}

	public void setAcctType(String acctType) {
		this.acctType = acctType;
	}
}