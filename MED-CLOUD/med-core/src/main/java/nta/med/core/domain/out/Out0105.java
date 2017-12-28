package nta.med.core.domain.out;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the OUT0105 database table.
 * 
 */
@Entity
@Table(name="OUT0105")
public class Out0105 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String budamjaBunho;
	private String bunho;
	private Date endDate;
	private String gongbiCode;
	private String hospCode;
	private String ifValidYn;
	private Date lastCheckDate;
	private String remark;
	private Date startDate;
	private String sugubjaBunho;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Out0105() {
	}


	@Column(name="BUDAMJA_BUNHO")
	public String getBudamjaBunho() {
		return this.budamjaBunho;
	}

	public void setBudamjaBunho(String budamjaBunho) {
		this.budamjaBunho = budamjaBunho;
	}


	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="END_DATE")
	public Date getEndDate() {
		return this.endDate;
	}

	public void setEndDate(Date endDate) {
		this.endDate = endDate;
	}


	@Column(name="GONGBI_CODE")
	public String getGongbiCode() {
		return this.gongbiCode;
	}

	public void setGongbiCode(String gongbiCode) {
		this.gongbiCode = gongbiCode;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="IF_VALID_YN")
	public String getIfValidYn() {
		return this.ifValidYn;
	}

	public void setIfValidYn(String ifValidYn) {
		this.ifValidYn = ifValidYn;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="LAST_CHECK_DATE")
	public Date getLastCheckDate() {
		return this.lastCheckDate;
	}

	public void setLastCheckDate(Date lastCheckDate) {
		this.lastCheckDate = lastCheckDate;
	}


	public String getRemark() {
		return this.remark;
	}

	public void setRemark(String remark) {
		this.remark = remark;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="START_DATE")
	public Date getStartDate() {
		return this.startDate;
	}

	public void setStartDate(Date startDate) {
		this.startDate = startDate;
	}


	@Column(name="SUGUBJA_BUNHO")
	public String getSugubjaBunho() {
		return this.sugubjaBunho;
	}

	public void setSugubjaBunho(String sugubjaBunho) {
		this.sugubjaBunho = sugubjaBunho;
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


	@Override
	public String toString() {
		return "Out0105 [budamjaBunho=" + budamjaBunho + ", bunho=" + bunho
				+ ", endDate=" + endDate + ", gongbiCode=" + gongbiCode
				+ ", hospCode=" + hospCode + ", ifValidYn=" + ifValidYn
				+ ", lastCheckDate=" + lastCheckDate + ", remark=" + remark
				+ ", startDate=" + startDate + ", sugubjaBunho=" + sugubjaBunho
				+ ", sysDate=" + sysDate + ", sysId=" + sysId + ", updDate="
				+ updDate + ", updId=" + updId + "]";
	}

}