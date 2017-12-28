package nta.med.core.domain.xrt;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the XRT0121 database table.
 * 
 */
@Entity
@Table(name="XRT0121")
public class Xrt0121 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String buwiBunryu;
	private String buwiBunryuName;
//	private String hospCode;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;
	private String workGubun;
	private String language;

	public Xrt0121() {
	}


	@Column(name="BUWI_BUNRYU")
	public String getBuwiBunryu() {
		return this.buwiBunryu;
	}

	public void setBuwiBunryu(String buwiBunryu) {
		this.buwiBunryu = buwiBunryu;
	}


	@Column(name="BUWI_BUNRYU_NAME")
	public String getBuwiBunryuName() {
		return this.buwiBunryuName;
	}

	public void setBuwiBunryuName(String buwiBunryuName) {
		this.buwiBunryuName = buwiBunryuName;
	}


//	@Column(name="HOSP_CODE")
//	public String getHospCode() {
//		return this.hospCode;
//	}
//
//	public void setHospCode(String hospCode) {
//		this.hospCode = hospCode;
//	}


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


	@Column(name="WORK_GUBUN")
	public String getWorkGubun() {
		return this.workGubun;
	}

	public void setWorkGubun(String workGubun) {
		this.workGubun = workGubun;
	}
	
	@Column(name="LANGUAGE")
	public String getLanguage() {
		return language;
	}

	public void setLanguage(String language) {
		this.language = language;
	}
}