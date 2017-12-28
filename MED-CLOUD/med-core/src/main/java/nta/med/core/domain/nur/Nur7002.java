package nta.med.core.domain.nur;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;

/**
 * The persistent class for the NUR7002 database table.
 * 
 */
@Entity
@Table(name = "NUR7002")
public class Nur7002 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String bunho;
	private Double fkinp1001;
	private String hangmogGubun;
	private Double hangmogSeq;
	private String hangmogValue;
	private String hospCode;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;
	private Date ymd;

	public Nur7002() {
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

	@Column(name = "HANGMOG_GUBUN")
	public String getHangmogGubun() {
		return this.hangmogGubun;
	}

	public void setHangmogGubun(String hangmogGubun) {
		this.hangmogGubun = hangmogGubun;
	}

	@Column(name = "HANGMOG_SEQ")
	public Double getHangmogSeq() {
		return this.hangmogSeq;
	}

	public void setHangmogSeq(Double hangmogSeq) {
		this.hangmogSeq = hangmogSeq;
	}

	@Column(name = "HANGMOG_VALUE")
	public String getHangmogValue() {
		return this.hangmogValue;
	}

	public void setHangmogValue(String hangmogValue) {
		this.hangmogValue = hangmogValue;
	}

	@Column(name = "HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
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

	@Temporal(TemporalType.TIMESTAMP)
	public Date getYmd() {
		return this.ymd;
	}

	public void setYmd(Date ymd) {
		this.ymd = ymd;
	}

}