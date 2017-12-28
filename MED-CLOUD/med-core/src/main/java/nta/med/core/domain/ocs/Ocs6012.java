package nta.med.core.domain.ocs;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the OCS6012 database table.
 * 
 */
@Entity
@NamedQuery(name="Ocs6012.findAll", query="SELECT o FROM Ocs6012 o")
public class Ocs6012 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String cpCode;
	private String cpPathCode;
	private double fkocs6010;
	private String hospCode;
	private double jaewonil;
	private String ment;
	private String ordOccurGubun;
	private Date planOrderDate;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Ocs6012() {
	}


	@Column(name="CP_CODE")
	public String getCpCode() {
		return this.cpCode;
	}

	public void setCpCode(String cpCode) {
		this.cpCode = cpCode;
	}


	@Column(name="CP_PATH_CODE")
	public String getCpPathCode() {
		return this.cpPathCode;
	}

	public void setCpPathCode(String cpPathCode) {
		this.cpPathCode = cpPathCode;
	}


	public double getFkocs6010() {
		return this.fkocs6010;
	}

	public void setFkocs6010(double fkocs6010) {
		this.fkocs6010 = fkocs6010;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
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


	@Column(name="ORD_OCCUR_GUBUN")
	public String getOrdOccurGubun() {
		return this.ordOccurGubun;
	}

	public void setOrdOccurGubun(String ordOccurGubun) {
		this.ordOccurGubun = ordOccurGubun;
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