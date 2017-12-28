package nta.med.core.domain.inv;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;


/**
 * The persistent class for the INV6002 database table.
 * 
 */
@Entity
@Table(name="INV6002")
public class Inv6002 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private Double existCount;
	private String hospCode;
	private Date inputDate;
	private String inputUser;
	private String jaeryoCode;
	private String magamMonth;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Inv6002() {
	}


	@Column(name="EXIST_COUNT")
	public Double getExistCount() {
		return this.existCount;
	}

	public void setExistCount(Double existCount) {
		this.existCount = existCount;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
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


	@Column(name="JAERYO_CODE")
	public String getJaeryoCode() {
		return this.jaeryoCode;
	}

	public void setJaeryoCode(String jaeryoCode) {
		this.jaeryoCode = jaeryoCode;
	}


	@Column(name="MAGAM_MONTH")
	public String getMagamMonth() {
		return this.magamMonth;
	}

	public void setMagamMonth(String magamMonth) {
		this.magamMonth = magamMonth;
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