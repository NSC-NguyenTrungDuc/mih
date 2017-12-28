package nta.med.core.domain.ocs;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the OCS2022 database table.
 * 
 */
@Entity
@NamedQuery(name="Ocs2022.findAll", query="SELECT o FROM Ocs2022 o")
public class Ocs2022 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String autoInsertYn;
	private String bunho;
	private String hanjaGun;
	private String hospCode;
	private Date jukyongDate;
	private double pkinp1001;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;
	private String walkYn;

	public Ocs2022() {
	}


	@Column(name="AUTO_INSERT_YN")
	public String getAutoInsertYn() {
		return this.autoInsertYn;
	}

	public void setAutoInsertYn(String autoInsertYn) {
		this.autoInsertYn = autoInsertYn;
	}


	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}


	@Column(name="HANJA_GUN")
	public String getHanjaGun() {
		return this.hanjaGun;
	}

	public void setHanjaGun(String hanjaGun) {
		this.hanjaGun = hanjaGun;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="JUKYONG_DATE")
	public Date getJukyongDate() {
		return this.jukyongDate;
	}

	public void setJukyongDate(Date jukyongDate) {
		this.jukyongDate = jukyongDate;
	}


	public double getPkinp1001() {
		return this.pkinp1001;
	}

	public void setPkinp1001(double pkinp1001) {
		this.pkinp1001 = pkinp1001;
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


	@Column(name="WALK_YN")
	public String getWalkYn() {
		return this.walkYn;
	}

	public void setWalkYn(String walkYn) {
		this.walkYn = walkYn;
	}

}