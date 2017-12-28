package nta.med.core.domain.oif;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the OIF0001 database table.
 * 
 */
@Entity
@NamedQuery(name="Oif0001.findAll", query="SELECT o FROM Oif0001 o")
public class Oif0001 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String defaultYn;
	private Date endDate;
	private String hospCode;
	private String mapGubun;
	private String ocsCode;
	private String orcaCode;
	private Date startDate;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Oif0001() {
	}


	@Column(name="DEFAULT_YN")
	public String getDefaultYn() {
		return this.defaultYn;
	}

	public void setDefaultYn(String defaultYn) {
		this.defaultYn = defaultYn;
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


	@Column(name="MAP_GUBUN")
	public String getMapGubun() {
		return this.mapGubun;
	}

	public void setMapGubun(String mapGubun) {
		this.mapGubun = mapGubun;
	}


	@Column(name="OCS_CODE")
	public String getOcsCode() {
		return this.ocsCode;
	}

	public void setOcsCode(String ocsCode) {
		this.ocsCode = ocsCode;
	}


	@Column(name="ORCA_CODE")
	public String getOrcaCode() {
		return this.orcaCode;
	}

	public void setOrcaCode(String orcaCode) {
		this.orcaCode = orcaCode;
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