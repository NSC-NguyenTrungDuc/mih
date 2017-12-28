package nta.med.core.domain.bas;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;


/**
 * The persistent class for the BAS0230 database table.
 * 
 */
@Entity
@Table(name="BAS0230")
public class Bas0230 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String bunCode;
	private String bunName;
	private Date bunYmd;
	private String changeJinryoGubun;
	private String hospCode;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;
	private String language;
	
	public Bas0230() {
	}


	@Column(name="BUN_CODE")
	public String getBunCode() {
		return this.bunCode;
	}

	public void setBunCode(String bunCode) {
		this.bunCode = bunCode;
	}


	@Column(name="BUN_NAME")
	public String getBunName() {
		return this.bunName;
	}

	public void setBunName(String bunName) {
		this.bunName = bunName;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="BUN_YMD")
	public Date getBunYmd() {
		return this.bunYmd;
	}

	public void setBunYmd(Date bunYmd) {
		this.bunYmd = bunYmd;
	}


	@Column(name="CHANGE_JINRYO_GUBUN")
	public String getChangeJinryoGubun() {
		return this.changeJinryoGubun;
	}

	public void setChangeJinryoGubun(String changeJinryoGubun) {
		this.changeJinryoGubun = changeJinryoGubun;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
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