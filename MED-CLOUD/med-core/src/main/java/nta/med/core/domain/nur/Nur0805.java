package nta.med.core.domain.nur;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;

/**
 * The persistent class for the NUR0805 database table.
 * 
 */
@Entity
@Table(name = "NUR0805")
public class Nur0805 extends BaseEntity {
	private static final long serialVersionUID = 1L;

	private String hFileFlag;
	private String hospCode;
	private String needAsmtCode;
	private String needGubun;
	private String needResultCode;
	private String needSoCode;
	private String needSoName;
	private Double needSoPoint;
	private Double sortKey;
	private Date startDate;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Nur0805() {
	}

	@Column(name = "H_FILE_FLAG")
	public String getHFileFlag() {
		return this.hFileFlag;
	}

	public void setHFileFlag(String hFileFlag) {
		this.hFileFlag = hFileFlag;
	}

	@Column(name = "HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}

	@Column(name = "NEED_ASMT_CODE")
	public String getNeedAsmtCode() {
		return this.needAsmtCode;
	}

	public void setNeedAsmtCode(String needAsmtCode) {
		this.needAsmtCode = needAsmtCode;
	}

	@Column(name = "NEED_GUBUN")
	public String getNeedGubun() {
		return this.needGubun;
	}

	public void setNeedGubun(String needGubun) {
		this.needGubun = needGubun;
	}

	@Column(name = "NEED_RESULT_CODE")
	public String getNeedResultCode() {
		return this.needResultCode;
	}

	public void setNeedResultCode(String needResultCode) {
		this.needResultCode = needResultCode;
	}

	@Column(name = "NEED_SO_CODE")
	public String getNeedSoCode() {
		return this.needSoCode;
	}

	public void setNeedSoCode(String needSoCode) {
		this.needSoCode = needSoCode;
	}

	@Column(name = "NEED_SO_NAME")
	public String getNeedSoName() {
		return this.needSoName;
	}

	public void setNeedSoName(String needSoName) {
		this.needSoName = needSoName;
	}

	@Column(name = "NEED_SO_POINT")
	public Double getNeedSoPoint() {
		return this.needSoPoint;
	}

	public void setNeedSoPoint(Double needSoPoint) {
		this.needSoPoint = needSoPoint;
	}

	@Column(name = "SORT_KEY")
	public Double getSortKey() {
		return this.sortKey;
	}

	public void setSortKey(Double sortKey) {
		this.sortKey = sortKey;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "START_DATE")
	public Date getStartDate() {
		return this.startDate;
	}

	public void setStartDate(Date startDate) {
		this.startDate = startDate;
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