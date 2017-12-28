package nta.med.core.domain.nur;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;

/**
 * The persistent class for the NUR1020 database table.
 * 
 */
@Entity
@Table(name = "NUR1020")
public class Nur1020 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String bunho;
	private Double fkinp1001;
	private Double fkocs2003Bscheck;
	private Double fkocs2016;
	private String hospCode;
	private String prGubun;
	private Double prValue;
	private Date sysDate;
	private String sysId;
	private String timeGubun;
	private Date updDate;
	private String updId;
	private Date ymd;

	public Nur1020() {
	}

	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}

	public Double getFkinp1001() {
		return this.fkinp1001;
	}

	public void setFkinp1001(Double fkinp1001) {
		this.fkinp1001 = fkinp1001;
	}

	@Column(name = "FKOCS2003_BSCHECK")
	public Double getFkocs2003Bscheck() {
		return this.fkocs2003Bscheck;
	}

	public void setFkocs2003Bscheck(Double fkocs2003Bscheck) {
		this.fkocs2003Bscheck = fkocs2003Bscheck;
	}

	public Double getFkocs2016() {
		return this.fkocs2016;
	}

	public void setFkocs2016(Double fkocs2016) {
		this.fkocs2016 = fkocs2016;
	}

	@Column(name = "HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}

	@Column(name = "PR_GUBUN")
	public String getPrGubun() {
		return this.prGubun;
	}

	public void setPrGubun(String prGubun) {
		this.prGubun = prGubun;
	}

	@Column(name = "PR_VALUE")
	public Double getPrValue() {
		return this.prValue;
	}

	public void setPrValue(Double prValue) {
		this.prValue = prValue;
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

	@Column(name = "TIME_GUBUN")
	public String getTimeGubun() {
		return this.timeGubun;
	}

	public void setTimeGubun(String timeGubun) {
		this.timeGubun = timeGubun;
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

	@Temporal(TemporalType.TIMESTAMP)
	public Date getYmd() {
		return this.ymd;
	}

	public void setYmd(Date ymd) {
		this.ymd = ymd;
	}

}