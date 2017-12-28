package nta.med.core.domain.bas;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the BAS0402 database table.
 * 
 */
@Entity
@NamedQuery(name="Bas0402.findAll", query="SELECT b FROM Bas0402 b")
public class Bas0402 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private double adlGijun;
	private Date endDate;
	private String hospCode;
	private String sangGasan;
	private String sgCode;
	private double standDay;
	private Date startDate;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Bas0402() {
	}


	@Column(name="ADL_GIJUN")
	public double getAdlGijun() {
		return this.adlGijun;
	}

	public void setAdlGijun(double adlGijun) {
		this.adlGijun = adlGijun;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="END_DATE")
	public Date getEndDate() {
		return this.endDate;
	}

	public void setEndDate(Date endDate) {
		this.endDate = endDate;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="SANG_GASAN")
	public String getSangGasan() {
		return this.sangGasan;
	}

	public void setSangGasan(String sangGasan) {
		this.sangGasan = sangGasan;
	}


	@Column(name="SG_CODE")
	public String getSgCode() {
		return this.sgCode;
	}

	public void setSgCode(String sgCode) {
		this.sgCode = sgCode;
	}


	@Column(name="STAND_DAY")
	public double getStandDay() {
		return this.standDay;
	}

	public void setStandDay(double standDay) {
		this.standDay = standDay;
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