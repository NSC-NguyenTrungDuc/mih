package nta.med.core.domain.inv;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;


/**
 * The persistent class for the INV6000 database table.
 * 
 */
@Entity
@Table(name="INV6000")
public class Inv6000 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String hospCode;
	private Date inputDate;
	private String inputUser;
	private String magamMonth;
	private Double pkinv6000;
	private String remark;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Inv6000() {
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


	@Column(name="MAGAM_MONTH")
	public String getMagamMonth() {
		return this.magamMonth;
	}

	public void setMagamMonth(String magamMonth) {
		this.magamMonth = magamMonth;
	}


	public Double getPkinv6000() {
		return this.pkinv6000;
	}

	public void setPkinv6000(Double pkinv6000) {
		this.pkinv6000 = pkinv6000;
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

}