package nta.med.core.domain.drg;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;


/**
 * The persistent class for the DRG9040 database table.
 * 
 */
@Entity
@Table(name="DRG9040")
public class Drg9040 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String bunho;
	private Double drgBunho;
	private String drgRemark;
	private String hospCode;
	private String inOutGubun;
	private Date inputDate;
	private String inputUser;
	private Date jubsuDate;
	private Date orderDate;
	private String orderRemark;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Drg9040() {
	}


	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}


	@Column(name="DRG_BUNHO")
	public Double getDrgBunho() {
		return this.drgBunho;
	}

	public void setDrgBunho(Double drgBunho) {
		this.drgBunho = drgBunho;
	}


	@Column(name="DRG_REMARK")
	public String getDrgRemark() {
		return this.drgRemark;
	}

	public void setDrgRemark(String drgRemark) {
		this.drgRemark = drgRemark;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="IN_OUT_GUBUN")
	public String getInOutGubun() {
		return this.inOutGubun;
	}

	public void setInOutGubun(String inOutGubun) {
		this.inOutGubun = inOutGubun;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="INPUT_DATE")
	public Date getInputDate() {
		return this.inputDate;
	}

	public void setInputDate(Date inputDate) {
		this.inputDate = inputDate;
	}


	@Column(name="INPUT_USER")
	public String getInputUser() {
		return this.inputUser;
	}

	public void setInputUser(String inputUser) {
		this.inputUser = inputUser;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="JUBSU_DATE")
	public Date getJubsuDate() {
		return this.jubsuDate;
	}

	public void setJubsuDate(Date jubsuDate) {
		this.jubsuDate = jubsuDate;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="ORDER_DATE")
	public Date getOrderDate() {
		return this.orderDate;
	}

	public void setOrderDate(Date orderDate) {
		this.orderDate = orderDate;
	}


	@Column(name="ORDER_REMARK")
	public String getOrderRemark() {
		return this.orderRemark;
	}

	public void setOrderRemark(String orderRemark) {
		this.orderRemark = orderRemark;
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