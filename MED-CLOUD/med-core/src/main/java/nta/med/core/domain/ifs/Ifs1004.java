package nta.med.core.domain.ifs;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the IFS1004 database table.
 * 
 */
@Entity
@NamedQuery(name="Ifs1004.findAll", query="SELECT i FROM Ifs1004 i")
public class Ifs1004 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String actingDate;
	private String bunho;
	private String doctor;
	private double fkout1003;
	private String gubun;
	private String gwa;
	private String hospCode;
	private Date ifDate;
	private String ifErr;
	private String ifFlag;
	private String ifTime;
	private String orderGubun;
	private double pkifs1004;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Ifs1004() {
	}


	@Column(name="ACTING_DATE")
	public String getActingDate() {
		return this.actingDate;
	}

	public void setActingDate(String actingDate) {
		this.actingDate = actingDate;
	}


	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}


	public String getDoctor() {
		return this.doctor;
	}

	public void setDoctor(String doctor) {
		this.doctor = doctor;
	}


	public double getFkout1003() {
		return this.fkout1003;
	}

	public void setFkout1003(double fkout1003) {
		this.fkout1003 = fkout1003;
	}


	public String getGubun() {
		return this.gubun;
	}

	public void setGubun(String gubun) {
		this.gubun = gubun;
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


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="IF_DATE")
	public Date getIfDate() {
		return this.ifDate;
	}

	public void setIfDate(Date ifDate) {
		this.ifDate = ifDate;
	}


	@Column(name="IF_ERR")
	public String getIfErr() {
		return this.ifErr;
	}

	public void setIfErr(String ifErr) {
		this.ifErr = ifErr;
	}


	@Column(name="IF_FLAG")
	public String getIfFlag() {
		return this.ifFlag;
	}

	public void setIfFlag(String ifFlag) {
		this.ifFlag = ifFlag;
	}


	@Column(name="IF_TIME")
	public String getIfTime() {
		return this.ifTime;
	}

	public void setIfTime(String ifTime) {
		this.ifTime = ifTime;
	}


	@Column(name="ORDER_GUBUN")
	public String getOrderGubun() {
		return this.orderGubun;
	}

	public void setOrderGubun(String orderGubun) {
		this.orderGubun = orderGubun;
	}


	public double getPkifs1004() {
		return this.pkifs1004;
	}

	public void setPkifs1004(double pkifs1004) {
		this.pkifs1004 = pkifs1004;
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