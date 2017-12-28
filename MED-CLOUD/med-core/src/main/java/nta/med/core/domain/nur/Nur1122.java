package nta.med.core.domain.nur;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;

/**
 * The persistent class for the NUR1122 database table.
 * 
 */
@Entity
@Table(name = "NUR1122")
public class Nur1122 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String bunho;
	private Double fkinp1001;
	private String hangmogCode;
	private String hangmogName;
	private String hangmogValue1;
	private String hangmogValue2;
	private String hangmogValue3;
	private String hospCode;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;
	private Date ymd;

	public Nur1122() {
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

	@Column(name = "HANGMOG_CODE")
	public String getHangmogCode() {
		return this.hangmogCode;
	}

	public void setHangmogCode(String hangmogCode) {
		this.hangmogCode = hangmogCode;
	}

	@Column(name = "HANGMOG_NAME")
	public String getHangmogName() {
		return this.hangmogName;
	}

	public void setHangmogName(String hangmogName) {
		this.hangmogName = hangmogName;
	}

	@Column(name = "HANGMOG_VALUE1")
	public String getHangmogValue1() {
		return this.hangmogValue1;
	}

	public void setHangmogValue1(String hangmogValue1) {
		this.hangmogValue1 = hangmogValue1;
	}

	@Column(name = "HANGMOG_VALUE2")
	public String getHangmogValue2() {
		return this.hangmogValue2;
	}

	public void setHangmogValue2(String hangmogValue2) {
		this.hangmogValue2 = hangmogValue2;
	}

	@Column(name = "HANGMOG_VALUE3")
	public String getHangmogValue3() {
		return this.hangmogValue3;
	}

	public void setHangmogValue3(String hangmogValue3) {
		this.hangmogValue3 = hangmogValue3;
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