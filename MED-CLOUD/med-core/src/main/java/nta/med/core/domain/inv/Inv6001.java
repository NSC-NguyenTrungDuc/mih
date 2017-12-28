package nta.med.core.domain.inv;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;


/**
 * The persistent class for the INV6001 database table.
 * 
 */
@Entity
@Table(name="INV6001")
public class Inv6001 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private Double adjAmt;
	private Double chulgoQty;
	private Double danga;
	private Double fkinv6000;
	private String hospCode;
	private Double ipgoQty;
	private Double jaegoQty;
	private String jaeryoCode;
	private Date magamDate;
	private Double pkinv6001;
	private Double preMJaegoQty;
	private String subulBuseo;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Inv6001() {
	}

	@Column(name="ADJ_AMT")
	public Double getAdjAmt() {
		return this.adjAmt;
	}

	public void setAdjAmt(Double adjAmt) {
		this.adjAmt = adjAmt;
	}


	@Column(name="CHULGO_QTY")
	public Double getChulgoQty() {
		return this.chulgoQty;
	}

	public void setChulgoQty(Double chulgoQty) {
		this.chulgoQty = chulgoQty;
	}


	public Double getDanga() {
		return this.danga;
	}

	public void setDanga(Double danga) {
		this.danga = danga;
	}


	public Double getFkinv6000() {
		return this.fkinv6000;
	}

	public void setFkinv6000(Double fkinv6000) {
		this.fkinv6000 = fkinv6000;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="IPGO_QTY")
	public Double getIpgoQty() {
		return this.ipgoQty;
	}

	public void setIpgoQty(Double ipgoQty) {
		this.ipgoQty = ipgoQty;
	}


	@Column(name="JAEGO_QTY")
	public Double getJaegoQty() {
		return this.jaegoQty;
	}

	public void setJaegoQty(Double jaegoQty) {
		this.jaegoQty = jaegoQty;
	}


	@Column(name="JAERYO_CODE")
	public String getJaeryoCode() {
		return this.jaeryoCode;
	}

	public void setJaeryoCode(String jaeryoCode) {
		this.jaeryoCode = jaeryoCode;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="MAGAM_DATE")
	public Date getMagamDate() {
		return this.magamDate;
	}

	public void setMagamDate(Date magamDate) {
		this.magamDate = magamDate;
	}


	public Double getPkinv6001() {
		return this.pkinv6001;
	}

	public void setPkinv6001(Double pkinv6001) {
		this.pkinv6001 = pkinv6001;
	}


	@Column(name="PRE_M_JAEGO_QTY")
	public Double getPreMJaegoQty() {
		return this.preMJaegoQty;
	}

	public void setPreMJaegoQty(Double preMJaegoQty) {
		this.preMJaegoQty = preMJaegoQty;
	}


	@Column(name="SUBUL_BUSEO")
	public String getSubulBuseo() {
		return this.subulBuseo;
	}

	public void setSubulBuseo(String subulBuseo) {
		this.subulBuseo = subulBuseo;
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


	@Column(name="UPD_ID")
	public String getUpdId() {
		return this.updId;
	}

	public void setUpdId(String updId) {
		this.updId = updId;
	}

}