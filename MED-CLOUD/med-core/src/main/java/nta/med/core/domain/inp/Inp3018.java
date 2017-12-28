package nta.med.core.domain.inp;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the INP3018 database table.
 * 
 */
@Entity
@NamedQuery(name="Inp3018.findAll", query="SELECT i FROM Inp3018 i")
public class Inp3018 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private double fkinp3010;
	private String gongbiCode;
	private String gubun;
	private String hospCode;
	private double priority;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Inp3018() {
	}


	public double getFkinp3010() {
		return this.fkinp3010;
	}

	public void setFkinp3010(double fkinp3010) {
		this.fkinp3010 = fkinp3010;
	}


	@Column(name="GONGBI_CODE")
	public String getGongbiCode() {
		return this.gongbiCode;
	}

	public void setGongbiCode(String gongbiCode) {
		this.gongbiCode = gongbiCode;
	}


	public String getGubun() {
		return this.gubun;
	}

	public void setGubun(String gubun) {
		this.gubun = gubun;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	public double getPriority() {
		return this.priority;
	}

	public void setPriority(double priority) {
		this.priority = priority;
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