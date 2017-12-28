package nta.med.core.domain.ifs;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the IFS0005 database table.
 * 
 */
@Entity
@Table(name="IFS0005")
public class Ifs0005 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String bunCode;
	private String hospCode;
	private String nuCode;
	private String nuGubun;
	private Date nuYmd;
	private String sgCode;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Ifs0005() {
	}


	@Column(name="BUN_CODE")
	public String getBunCode() {
		return this.bunCode;
	}

	public void setBunCode(String bunCode) {
		this.bunCode = bunCode;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="NU_CODE")
	public String getNuCode() {
		return this.nuCode;
	}

	public void setNuCode(String nuCode) {
		this.nuCode = nuCode;
	}


	@Column(name="NU_GUBUN")
	public String getNuGubun() {
		return this.nuGubun;
	}

	public void setNuGubun(String nuGubun) {
		this.nuGubun = nuGubun;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="NU_YMD")
	public Date getNuYmd() {
		return this.nuYmd;
	}

	public void setNuYmd(Date nuYmd) {
		this.nuYmd = nuYmd;
	}


	@Column(name="SG_CODE")
	public String getSgCode() {
		return this.sgCode;
	}

	public void setSgCode(String sgCode) {
		this.sgCode = sgCode;
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

}