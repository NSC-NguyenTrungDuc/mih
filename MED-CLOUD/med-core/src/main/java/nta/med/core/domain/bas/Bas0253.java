package nta.med.core.domain.bas;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;


/**
 * The persistent class for the BAS0253 database table.
 * 
 */
@Entity
//@NamedQuery(name="Bas0253.findAll", query="SELECT b FROM Bas0253 b")
@Table(name="BAS0253")
public class Bas0253 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String bedLockText;
	private String bedNo;
	private String bedNoTel;
	private String bedStatus;
	private Date fromBedDate;
	private String hoCode;
	private String hoDong;
	private String hospCode;
	private Date sysDate;
	private String sysId;
	private Date toBedDate;
	private Date updDate;
	private String updId;

	public Bas0253() {
	}


	@Column(name="BED_LOCK_TEXT")
	public String getBedLockText() {
		return this.bedLockText;
	}

	public void setBedLockText(String bedLockText) {
		this.bedLockText = bedLockText;
	}


	@Column(name="BED_NO")
	public String getBedNo() {
		return this.bedNo;
	}

	public void setBedNo(String bedNo) {
		this.bedNo = bedNo;
	}


	@Column(name="BED_NO_TEL")
	public String getBedNoTel() {
		return this.bedNoTel;
	}

	public void setBedNoTel(String bedNoTel) {
		this.bedNoTel = bedNoTel;
	}


	@Column(name="BED_STATUS")
	public String getBedStatus() {
		return this.bedStatus;
	}

	public void setBedStatus(String bedStatus) {
		this.bedStatus = bedStatus;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="FROM_BED_DATE")
	public Date getFromBedDate() {
		return this.fromBedDate;
	}

	public void setFromBedDate(Date fromBedDate) {
		this.fromBedDate = fromBedDate;
	}


	@Column(name="HO_CODE")
	public String getHoCode() {
		return this.hoCode;
	}

	public void setHoCode(String hoCode) {
		this.hoCode = hoCode;
	}


	@Column(name="HO_DONG")
	public String getHoDong() {
		return this.hoDong;
	}

	public void setHoDong(String hoDong) {
		this.hoDong = hoDong;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
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
	@Column(name="TO_BED_DATE")
	public Date getToBedDate() {
		return this.toBedDate;
	}

	public void setToBedDate(Date toBedDate) {
		this.toBedDate = toBedDate;
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