package nta.med.core.domain.cht;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;


/**
 * The persistent class for the CHT0118 database table.
 * 
 */
@Entity
@Table(name="CHT0118")
public class Cht0118 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String buwi;
	private Date endDate;
	private String hospCode;
	private Double nosaiJyRate;
	private String remark;
	private Double sortKey;
	private Date startDate;
	private String subBuwi;
	private String subBuwiName;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;
	private String language;
	
	public Cht0118() {
	}


	public String getBuwi() {
		return this.buwi;
	}

	public void setBuwi(String buwi) {
		this.buwi = buwi;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="END_DATE")
	public Date getEndDate() {
		return this.endDate;
	}

	public void setEndDate(Date endDate) {
		this.endDate = endDate;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="NOSAI_JY_RATE")
	public Double getNosaiJyRate() {
		return this.nosaiJyRate;
	}

	public void setNosaiJyRate(Double nosaiJyRate) {
		this.nosaiJyRate = nosaiJyRate;
	}


	public String getRemark() {
		return this.remark;
	}

	public void setRemark(String remark) {
		this.remark = remark;
	}


	@Column(name="SORT_KEY")
	public Double getSortKey() {
		return this.sortKey;
	}

	public void setSortKey(Double sortKey) {
		this.sortKey = sortKey;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="START_DATE")
	public Date getStartDate() {
		return this.startDate;
	}

	public void setStartDate(Date startDate) {
		this.startDate = startDate;
	}


	@Column(name="SUB_BUWI")
	public String getSubBuwi() {
		return this.subBuwi;
	}

	public void setSubBuwi(String subBuwi) {
		this.subBuwi = subBuwi;
	}


	@Column(name="SUB_BUWI_NAME")
	public String getSubBuwiName() {
		return this.subBuwiName;
	}

	public void setSubBuwiName(String subBuwiName) {
		this.subBuwiName = subBuwiName;
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

	@Column(name="LANGUAGE")
	public String getLanguage() {
		return language;
	}

	public void setLanguage(String language) {
		this.language = language;
	}
}