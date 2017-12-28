package nta.med.core.domain.out;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;

import javax.persistence.*;

import java.util.Date;


/**
 * The persistent class for the OUT0102 database table.
 * 
 */
@Entity
@Table(name="OUT0102")
public class Out0102 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String bonGaGubun;
	private String bunho;
	private Date chuidukDate;
	private Date endDate;
	private String gaein;
	private String gaeinNo;
	private String gubun;
	private String hospCode;
	private String ifValidYn;
	private String johap;
	private Date lastCheckDate;
	private String piname;
	private String remark;
	private Date startDate;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Out0102() {
	}


	@Column(name="BON_GA_GUBUN")
	public String getBonGaGubun() {
		return this.bonGaGubun;
	}

	public void setBonGaGubun(String bonGaGubun) {
		this.bonGaGubun = bonGaGubun;
	}

	@Column(name="BUNHO")
	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="CHUIDUK_DATE")
	public Date getChuidukDate() {
		return this.chuidukDate;
	}

	public void setChuidukDate(Date chuidukDate) {
		this.chuidukDate = chuidukDate;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="END_DATE")
	public Date getEndDate() {
		return this.endDate;
	}

	public void setEndDate(Date endDate) {
		this.endDate = endDate;
	}

	@Column(name="GAEIN")
	public String getGaein() {
		return this.gaein;
	}

	public void setGaein(String gaein) {
		this.gaein = gaein;
	}


	@Column(name="GAEIN_NO")
	public String getGaeinNo() {
		return this.gaeinNo;
	}

	public void setGaeinNo(String gaeinNo) {
		this.gaeinNo = gaeinNo;
	}

	@Column(name="GUBUN")
	public String getGubun() {
		return this.gubun;
	}

	public void setGubun(String gubun) {
		this.gubun = gubun;
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

	@Column(name="JOHAP")
	public String getJohap() {
		return this.johap;
	}

	public void setJohap(String johap) {
		this.johap = johap;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="LAST_CHECK_DATE")
	public Date getLastCheckDate() {
		return this.lastCheckDate;
	}

	public void setLastCheckDate(Date lastCheckDate) {
		this.lastCheckDate = lastCheckDate;
	}

	@Column(name="PINAME")
	public String getPiname() {
		return this.piname;
	}

	public void setPiname(String piname) {
		this.piname = piname;
	}

	@Column(name="REMARK")
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
		return "Out0102 [bonGaGubun=" + bonGaGubun + ", bunho=" + bunho
				+ ", chuidukDate=" + chuidukDate + ", endDate=" + endDate
				+ ", gaein=" + gaein + ", gaeinNo=" + gaeinNo + ", gubun="
				+ gubun + ", hospCode=" + hospCode + ", ifValidYn=" + ifValidYn
				+ ", johap=" + johap + ", lastCheckDate=" + lastCheckDate
				+ ", piname=" + piname + ", remark=" + remark + ", startDate="
				+ startDate + ", sysDate=" + sysDate + ", sysId=" + sysId
				+ ", updDate=" + updDate + ", updId=" + updId + "]";
	}

}