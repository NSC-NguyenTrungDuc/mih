package nta.med.core.domain.ifs;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the IFS7304 database table.
 * 
 */
@Entity
@NamedQuery(name="Ifs7304.findAll", query="SELECT i FROM Ifs7304 i")
public class Ifs7304 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String danui;
	private String drgCode;
	private String drgRpNo;
	private double drgSeq;
	private String dv;
	private double fkifs7303;
	private String hospCode;
	private String jusaDate;
	private String jusaGigan;
	private String jusaMethod;
	private String jusaSpeed;
	private String jusaTime;
	private String recGubunDrg;
	private String remark;
	private String root;
	private String rpFlag;
	private String startDate;
	private String suryang;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Ifs7304() {
	}


	public String getDanui() {
		return this.danui;
	}

	public void setDanui(String danui) {
		this.danui = danui;
	}


	@Column(name="DRG_CODE")
	public String getDrgCode() {
		return this.drgCode;
	}

	public void setDrgCode(String drgCode) {
		this.drgCode = drgCode;
	}


	@Column(name="DRG_RP_NO")
	public String getDrgRpNo() {
		return this.drgRpNo;
	}

	public void setDrgRpNo(String drgRpNo) {
		this.drgRpNo = drgRpNo;
	}


	@Column(name="DRG_SEQ")
	public double getDrgSeq() {
		return this.drgSeq;
	}

	public void setDrgSeq(double drgSeq) {
		this.drgSeq = drgSeq;
	}


	public String getDv() {
		return this.dv;
	}

	public void setDv(String dv) {
		this.dv = dv;
	}


	public double getFkifs7303() {
		return this.fkifs7303;
	}

	public void setFkifs7303(double fkifs7303) {
		this.fkifs7303 = fkifs7303;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="JUSA_DATE")
	public String getJusaDate() {
		return this.jusaDate;
	}

	public void setJusaDate(String jusaDate) {
		this.jusaDate = jusaDate;
	}


	@Column(name="JUSA_GIGAN")
	public String getJusaGigan() {
		return this.jusaGigan;
	}

	public void setJusaGigan(String jusaGigan) {
		this.jusaGigan = jusaGigan;
	}


	@Column(name="JUSA_METHOD")
	public String getJusaMethod() {
		return this.jusaMethod;
	}

	public void setJusaMethod(String jusaMethod) {
		this.jusaMethod = jusaMethod;
	}


	@Column(name="JUSA_SPEED")
	public String getJusaSpeed() {
		return this.jusaSpeed;
	}

	public void setJusaSpeed(String jusaSpeed) {
		this.jusaSpeed = jusaSpeed;
	}


	@Column(name="JUSA_TIME")
	public String getJusaTime() {
		return this.jusaTime;
	}

	public void setJusaTime(String jusaTime) {
		this.jusaTime = jusaTime;
	}


	@Column(name="REC_GUBUN_DRG")
	public String getRecGubunDrg() {
		return this.recGubunDrg;
	}

	public void setRecGubunDrg(String recGubunDrg) {
		this.recGubunDrg = recGubunDrg;
	}


	public String getRemark() {
		return this.remark;
	}

	public void setRemark(String remark) {
		this.remark = remark;
	}


	public String getRoot() {
		return this.root;
	}

	public void setRoot(String root) {
		this.root = root;
	}


	@Column(name="RP_FLAG")
	public String getRpFlag() {
		return this.rpFlag;
	}

	public void setRpFlag(String rpFlag) {
		this.rpFlag = rpFlag;
	}


	@Column(name="START_DATE")
	public String getStartDate() {
		return this.startDate;
	}

	public void setStartDate(String startDate) {
		this.startDate = startDate;
	}


	public String getSuryang() {
		return this.suryang;
	}

	public void setSuryang(String suryang) {
		this.suryang = suryang;
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