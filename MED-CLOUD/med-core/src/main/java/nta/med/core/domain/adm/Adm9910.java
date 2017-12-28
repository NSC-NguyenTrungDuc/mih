package nta.med.core.domain.adm;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the ADM9910 database table.
 * 
 */
@Entity
@NamedQuery(name="Adm9910.findAll", query="SELECT a FROM Adm9910 a")
public class Adm9910 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String bunCode;
	private String hospCode;
	private String huGubunAlpha;
	private String huGubunNumMax;
	private String huGubunNumMin;
	private Date startDate;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Adm9910() {
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


	@Column(name="HU_GUBUN_ALPHA")
	public String getHuGubunAlpha() {
		return this.huGubunAlpha;
	}

	public void setHuGubunAlpha(String huGubunAlpha) {
		this.huGubunAlpha = huGubunAlpha;
	}


	@Column(name="HU_GUBUN_NUM_MAX")
	public String getHuGubunNumMax() {
		return this.huGubunNumMax;
	}

	public void setHuGubunNumMax(String huGubunNumMax) {
		this.huGubunNumMax = huGubunNumMax;
	}


	@Column(name="HU_GUBUN_NUM_MIN")
	public String getHuGubunNumMin() {
		return this.huGubunNumMin;
	}

	public void setHuGubunNumMin(String huGubunNumMin) {
		this.huGubunNumMin = huGubunNumMin;
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

}