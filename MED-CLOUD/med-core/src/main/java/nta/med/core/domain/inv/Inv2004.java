package nta.med.core.domain.inv;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;


/**
 * The persistent class for the INV2004 database table.
 * 
 */
@Entity
@Table(name="INV2004")
public class Inv2004 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private Double chulgoDanga;
	private Double chulgoQty;
	private Double fkinv2003;
	private String hospCode;
	private String jaeryoCode;
	private Double pkinv2004;
	private String remark;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Inv2004() {
	}

	@Column(name="CHULGO_DANGA")
	public Double getChulgoDanga() {
		return this.chulgoDanga;
	}

	public void setChulgoDanga(Double chulgoDanga) {
		this.chulgoDanga = chulgoDanga;
	}


	@Column(name="CHULGO_QTY")
	public Double getChulgoQty() {
		return this.chulgoQty;
	}

	public void setChulgoQty(Double chulgoQty) {
		this.chulgoQty = chulgoQty;
	}

	@Column(name="FKINV2003")
	public Double getFkinv2003() {
		return this.fkinv2003;
	}

	public void setFkinv2003(Double fkinv2003) {
		this.fkinv2003 = fkinv2003;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="JAERYO_CODE")
	public String getJaeryoCode() {
		return this.jaeryoCode;
	}

	public void setJaeryoCode(String jaeryoCode) {
		this.jaeryoCode = jaeryoCode;
	}

	@Column(name="PKINV2004")
	public Double getPkinv2004() {
		return this.pkinv2004;
	}

	public void setPkinv2004(Double pkinv2004) {
		this.pkinv2004 = pkinv2004;
	}

	@Column(name="REMARK")
	public String getRemark() {
		return this.remark;
	}

	public void setRemark(String remark) {
		this.remark = remark;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="SYS_DATE")
	public Date getSysDate() {
		return this.sysDate;
	}

	public void setSysDate(Date sysDate) {
		this.sysDate = sysDate;
	}


	@Column(name="SYS_ID", length=10)
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


	@Column(name="UPD_ID", length=10)
	public String getUpdId() {
		return this.updId;
	}

	public void setUpdId(String updId) {
		this.updId = updId;
	}

}