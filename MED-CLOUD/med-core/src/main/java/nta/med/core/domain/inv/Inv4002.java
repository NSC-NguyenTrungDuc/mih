package nta.med.core.domain.inv;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;


/**
 * The persistent class for the INV4002 database table.
 * 
 */
@Entity
@Table(name="INV4002")
public class Inv4002 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private Double fkinv4001;
	private String hospCode;
	private Double ipgoDanga;
	private Double ipgoQty;
	private String jaeryoCode;
	private Double pkinv4002;
	private String remark;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;
	private Date startDate;
	private String lot;
	private Date expiredDate;

	public Inv4002() {
	}


	public Double getFkinv4001() {
		return this.fkinv4001;
	}

	public void setFkinv4001(Double fkinv4001) {
		this.fkinv4001 = fkinv4001;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="IPGO_DANGA")
	public Double getIpgoDanga() {
		return this.ipgoDanga;
	}

	public void setIpgoDanga(Double ipgoDanga) {
		this.ipgoDanga = ipgoDanga;
	}


	@Column(name="IPGO_QTY")
	public Double getIpgoQty() {
		return this.ipgoQty;
	}

	public void setIpgoQty(Double ipgoQty) {
		this.ipgoQty = ipgoQty;
	}


	@Column(name="JAERYO_CODE")
	public String getJaeryoCode() {
		return this.jaeryoCode;
	}

	public void setJaeryoCode(String jaeryoCode) {
		this.jaeryoCode = jaeryoCode;
	}


	public Double getPkinv4002() {
		return this.pkinv4002;
	}

	public void setPkinv4002(Double pkinv4002) {
		this.pkinv4002 = pkinv4002;
	}


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

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="START_DATE")
	public Date getStartDate() {
		return startDate;
	}

	public void setStartDate(Date startDate) {
		this.startDate = startDate;
	}
	
	@Column(name="LOT")
	public String getLot() {
		return lot;
	}

	public void setLot(String lot) {
		this.lot = lot;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="EXPIRED_DATE")
	public Date getExpiredDate() {
		return expiredDate;
	}

	public void setExpiredDate(Date expiredDate) {
		this.expiredDate = expiredDate;
	}

}