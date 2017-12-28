package nta.med.core.domain.inj;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the INJ0201 database table.
 * 
 */
@Entity
@NamedQuery(name="Inj0201.findAll", query="SELECT i FROM Inj0201 i")
public class Inj0201 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String cancelYn;
	private String hospCode;
	private String jaeryoCode;
	private String lotNo;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Inj0201() {
	}


	@Column(name="CANCEL_YN")
	public String getCancelYn() {
		return this.cancelYn;
	}

	public void setCancelYn(String cancelYn) {
		this.cancelYn = cancelYn;
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


	@Column(name="LOT_NO")
	public String getLotNo() {
		return this.lotNo;
	}

	public void setLotNo(String lotNo) {
		this.lotNo = lotNo;
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