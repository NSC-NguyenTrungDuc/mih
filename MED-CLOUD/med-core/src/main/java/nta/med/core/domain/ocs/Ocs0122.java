package nta.med.core.domain.ocs;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.NamedQuery;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;


/**
 * The persistent class for the OCS0122 database table.
 * 
 */
@Entity
@NamedQuery(name="Ocs0122.findAll", query="SELECT o FROM Ocs0122 o")
public class Ocs0122 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String buseoCode;
	private String hangmogCode;
	private String hospCode;
	private Double jaegoQty;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Ocs0122() {
	}


	@Column(name="BUSEO_CODE")
	public String getBuseoCode() {
		return this.buseoCode;
	}

	public void setBuseoCode(String buseoCode) {
		this.buseoCode = buseoCode;
	}


	@Column(name="HANGMOG_CODE")
	public String getHangmogCode() {
		return this.hangmogCode;
	}

	public void setHangmogCode(String hangmogCode) {
		this.hangmogCode = hangmogCode;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="JAEGO_QTY")
	public Double getJaegoQty() {
		return this.jaegoQty;
	}

	public void setJaegoQty(Double jaegoQty) {
		this.jaegoQty = jaegoQty;
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