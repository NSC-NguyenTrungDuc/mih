package nta.med.core.domain.ocs;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the OCS9000 database table.
 * 
 */
@Entity
@NamedQuery(name="Ocs9000.findAll", query="SELECT o FROM Ocs9000 o")
public class Ocs9000 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String bunho;
	private double curgroupSer;
	private double fkinp1001;
	private double groupSer;
	private String hospCode;
	private String inputDoctor;
	private double nextGroupSer;
	private Date orderDate;
	private String orderGubun;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Ocs9000() {
	}


	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}


	@Column(name="CURGROUP_SER")
	public double getCurgroupSer() {
		return this.curgroupSer;
	}

	public void setCurgroupSer(double curgroupSer) {
		this.curgroupSer = curgroupSer;
	}


	public double getFkinp1001() {
		return this.fkinp1001;
	}

	public void setFkinp1001(double fkinp1001) {
		this.fkinp1001 = fkinp1001;
	}


	@Column(name="GROUP_SER")
	public double getGroupSer() {
		return this.groupSer;
	}

	public void setGroupSer(double groupSer) {
		this.groupSer = groupSer;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="INPUT_DOCTOR")
	public String getInputDoctor() {
		return this.inputDoctor;
	}

	public void setInputDoctor(String inputDoctor) {
		this.inputDoctor = inputDoctor;
	}


	@Column(name="NEXT_GROUP_SER")
	public double getNextGroupSer() {
		return this.nextGroupSer;
	}

	public void setNextGroupSer(double nextGroupSer) {
		this.nextGroupSer = nextGroupSer;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="ORDER_DATE")
	public Date getOrderDate() {
		return this.orderDate;
	}

	public void setOrderDate(Date orderDate) {
		this.orderDate = orderDate;
	}


	@Column(name="ORDER_GUBUN")
	public String getOrderGubun() {
		return this.orderGubun;
	}

	public void setOrderGubun(String orderGubun) {
		this.orderGubun = orderGubun;
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