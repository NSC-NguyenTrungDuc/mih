package nta.med.core.domain.cpl;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the CPL0602 database table.
 * 
 */
@Entity
@NamedQuery(name="Cpl0602.findAll", query="SELECT c FROM Cpl0602 c")
public class Cpl0602 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String bloodType;
	private String code;
	private String hospCode;
	private String rhGubun;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Cpl0602() {
	}


	@Column(name="BLOOD_TYPE")
	public String getBloodType() {
		return this.bloodType;
	}

	public void setBloodType(String bloodType) {
		this.bloodType = bloodType;
	}


	public String getCode() {
		return this.code;
	}

	public void setCode(String code) {
		this.code = code;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="RH_GUBUN")
	public String getRhGubun() {
		return this.rhGubun;
	}

	public void setRhGubun(String rhGubun) {
		this.rhGubun = rhGubun;
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