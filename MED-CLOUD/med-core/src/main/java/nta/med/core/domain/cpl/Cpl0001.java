package nta.med.core.domain.cpl;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the CPL0001 database table.
 * 
 */
@Entity
@Table(name="CPL0001")
public class Cpl0001 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String hospCode;
	private String jundalGubun;
	private String slipCode;
	private String slipName;
	private String slipNameRe;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Cpl0001() {
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="JUNDAL_GUBUN")
	public String getJundalGubun() {
		return this.jundalGubun;
	}

	public void setJundalGubun(String jundalGubun) {
		this.jundalGubun = jundalGubun;
	}


	@Column(name="SLIP_CODE")
	public String getSlipCode() {
		return this.slipCode;
	}

	public void setSlipCode(String slipCode) {
		this.slipCode = slipCode;
	}


	@Column(name="SLIP_NAME")
	public String getSlipName() {
		return this.slipName;
	}

	public void setSlipName(String slipName) {
		this.slipName = slipName;
	}


	@Column(name="SLIP_NAME_RE")
	public String getSlipNameRe() {
		return this.slipNameRe;
	}

	public void setSlipNameRe(String slipNameRe) {
		this.slipNameRe = slipNameRe;
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