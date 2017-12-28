package nta.med.core.domain.ocs;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the OCS0601 database table.
 * 
 */
@Entity
@NamedQuery(name="Ocs0601.findAll", query="SELECT o FROM Ocs0601 o")
public class Ocs0601 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String bogyongGubun;
	private String drugTimeCode;
	private String drugTimeName;
	private String hospCode;
	private String orderGubun;
	private double seq;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Ocs0601() {
	}


	@Column(name="BOGYONG_GUBUN")
	public String getBogyongGubun() {
		return this.bogyongGubun;
	}

	public void setBogyongGubun(String bogyongGubun) {
		this.bogyongGubun = bogyongGubun;
	}


	@Column(name="DRUG_TIME_CODE")
	public String getDrugTimeCode() {
		return this.drugTimeCode;
	}

	public void setDrugTimeCode(String drugTimeCode) {
		this.drugTimeCode = drugTimeCode;
	}


	@Column(name="DRUG_TIME_NAME")
	public String getDrugTimeName() {
		return this.drugTimeName;
	}

	public void setDrugTimeName(String drugTimeName) {
		this.drugTimeName = drugTimeName;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="ORDER_GUBUN")
	public String getOrderGubun() {
		return this.orderGubun;
	}

	public void setOrderGubun(String orderGubun) {
		this.orderGubun = orderGubun;
	}


	public double getSeq() {
		return this.seq;
	}

	public void setSeq(double seq) {
		this.seq = seq;
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