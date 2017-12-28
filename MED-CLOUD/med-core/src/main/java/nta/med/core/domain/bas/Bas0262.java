package nta.med.core.domain.bas;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the BAS0262 database table.
 * 
 */
@Entity
@NamedQuery(name="Bas0262.findAll", query="SELECT b FROM Bas0262 b")
public class Bas0262 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String gwa;
	private String hospCode;
	private double sort;
	private Date sysDate;
	private String sysId;
	private String tonggye;
	private String tonggyeGwa;
	private Date tonggyeYmd;
	private Date updDate;
	private String updId;

	public Bas0262() {
	}


	public String getGwa() {
		return this.gwa;
	}

	public void setGwa(String gwa) {
		this.gwa = gwa;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	public double getSort() {
		return this.sort;
	}

	public void setSort(double sort) {
		this.sort = sort;
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


	public String getTonggye() {
		return this.tonggye;
	}

	public void setTonggye(String tonggye) {
		this.tonggye = tonggye;
	}


	@Column(name="TONGGYE_GWA")
	public String getTonggyeGwa() {
		return this.tonggyeGwa;
	}

	public void setTonggyeGwa(String tonggyeGwa) {
		this.tonggyeGwa = tonggyeGwa;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="TONGGYE_YMD")
	public Date getTonggyeYmd() {
		return this.tonggyeYmd;
	}

	public void setTonggyeYmd(Date tonggyeYmd) {
		this.tonggyeYmd = tonggyeYmd;
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