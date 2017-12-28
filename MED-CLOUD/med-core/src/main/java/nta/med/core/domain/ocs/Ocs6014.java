package nta.med.core.domain.ocs;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the OCS6014 database table.
 * 
 */
@Entity
@NamedQuery(name="Ocs6014.findAll", query="SELECT o FROM Ocs6014 o")
public class Ocs6014 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private double fkocs6010;
	private String headTitle;
	private String hospCode;
	private String inputGubun;
	private double jaewonil;
	private String ment;
	private Date planOrderDate;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Ocs6014() {
	}


	public double getFkocs6010() {
		return this.fkocs6010;
	}

	public void setFkocs6010(double fkocs6010) {
		this.fkocs6010 = fkocs6010;
	}


	@Column(name="HEAD_TITLE")
	public String getHeadTitle() {
		return this.headTitle;
	}

	public void setHeadTitle(String headTitle) {
		this.headTitle = headTitle;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="INPUT_GUBUN")
	public String getInputGubun() {
		return this.inputGubun;
	}

	public void setInputGubun(String inputGubun) {
		this.inputGubun = inputGubun;
	}


	public double getJaewonil() {
		return this.jaewonil;
	}

	public void setJaewonil(double jaewonil) {
		this.jaewonil = jaewonil;
	}


	public String getMent() {
		return this.ment;
	}

	public void setMent(String ment) {
		this.ment = ment;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="PLAN_ORDER_DATE")
	public Date getPlanOrderDate() {
		return this.planOrderDate;
	}

	public void setPlanOrderDate(Date planOrderDate) {
		this.planOrderDate = planOrderDate;
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