package nta.med.core.domain.nur;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;

/**
 * The persistent class for the NUR0803 database table.
 * 
 */
@Entity
@Table(name = "NUR0803")
public class Nur0803 extends BaseEntity {
	private static final long serialVersionUID = 1L;

	private String copyYn;
	private Date endDate;
	private String globalYn;
	private String hospCode;
	private String needAsmtCode;
	private String needAsmtName;
	private String needGubun;
	private Double sortKey;
	private Date startDate;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Nur0803() {
	}

	@Column(name = "COPY_YN")
	public String getCopyYn() {
		return this.copyYn;
	}

	public void setCopyYn(String copyYn) {
		this.copyYn = copyYn;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "END_DATE")
	public Date getEndDate() {
		return this.endDate;
	}

	public void setEndDate(Date endDate) {
		this.endDate = endDate;
	}

	@Column(name = "GLOBAL_YN")
	public String getGlobalYn() {
		return this.globalYn;
	}

	public void setGlobalYn(String globalYn) {
		this.globalYn = globalYn;
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

	@Column(name = "NEED_ASMT_NAME")
	public String getNeedAsmtName() {
		return this.needAsmtName;
	}

	public void setNeedAsmtName(String needAsmtName) {
		this.needAsmtName = needAsmtName;
	}

	@Column(name = "NEED_GUBUN")
	public String getNeedGubun() {
		return this.needGubun;
	}

	public void setNeedGubun(String needGubun) {
		this.needGubun = needGubun;
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