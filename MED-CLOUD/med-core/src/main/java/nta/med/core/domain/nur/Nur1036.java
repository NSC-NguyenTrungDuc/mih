package nta.med.core.domain.nur;

import nta.med.core.domain.BaseEntity;

import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the NUR1036 database table.
 * 
 */
@Entity
@Table(name = "NUR1036")
public class Nur1036 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String changedSkin;
	private Date checkDate;
	private String checkTime;
	private String dangerAct;
	private String edema;
	private Double fknur1035;
	private String hospCode;
	private String inputId;
	private String numbness;
	private String petechia;
	private String remark;
	private String scratch;
	private Date sysDate;
	private String sysId;
	private String tubeTrouble;
	private Date updDate;
	private String updId;

	public Nur1036() {
	}


	@Column(name="CHANGED_SKIN")
	public String getChangedSkin() {
		return this.changedSkin;
	}

	public void setChangedSkin(String changedSkin) {
		this.changedSkin = changedSkin;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="CHECK_DATE")
	public Date getCheckDate() {
		return this.checkDate;
	}

	public void setCheckDate(Date checkDate) {
		this.checkDate = checkDate;
	}


	@Column(name="CHECK_TIME")
	public String getCheckTime() {
		return this.checkTime;
	}

	public void setCheckTime(String checkTime) {
		this.checkTime = checkTime;
	}


	@Column(name="DANGER_ACT")
	public String getDangerAct() {
		return this.dangerAct;
	}

	public void setDangerAct(String dangerAct) {
		this.dangerAct = dangerAct;
	}


	public String getEdema() {
		return this.edema;
	}

	public void setEdema(String edema) {
		this.edema = edema;
	}


	public Double getFknur1035() {
		return this.fknur1035;
	}

	public void setFknur1035(Double fknur1035) {
		this.fknur1035 = fknur1035;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="INPUT_ID")
	public String getInputId() {
		return this.inputId;
	}

	public void setInputId(String inputId) {
		this.inputId = inputId;
	}


	public String getNumbness() {
		return this.numbness;
	}

	public void setNumbness(String numbness) {
		this.numbness = numbness;
	}


	public String getPetechia() {
		return this.petechia;
	}

	public void setPetechia(String petechia) {
		this.petechia = petechia;
	}


	public String getRemark() {
		return this.remark;
	}

	public void setRemark(String remark) {
		this.remark = remark;
	}


	public String getScratch() {
		return this.scratch;
	}

	public void setScratch(String scratch) {
		this.scratch = scratch;
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


	@Column(name="TUBE_TROUBLE")
	public String getTubeTrouble() {
		return this.tubeTrouble;
	}

	public void setTubeTrouble(String tubeTrouble) {
		this.tubeTrouble = tubeTrouble;
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