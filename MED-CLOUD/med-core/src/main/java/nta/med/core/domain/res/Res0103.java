package nta.med.core.domain.res;

import nta.med.core.domain.BaseEntity;

import javax.persistence.*;

import java.util.Date;


/**
 * The persistent class for the RES0103 database table.
 * 
 */
@Entity
@Table(name="RES0103")
public class Res0103 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String amEndHhmm;
	private String amGwaRoom;
	private String amStartHhmm;
	private String doctor;
	private String hospCode;
	private Date jinryoPreDate;
	private String pmEndHhmm;
	private String pmGwaRoom;
	private String pmStartHhmm;
	private String remark;
	private String resAmEndHhmm;
	private String resAmStartHhmm;
	private String resPmEndHhmm;
	private String resPmStartHhmm;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Res0103() {
	}


	@Column(name="AM_END_HHMM")
	public String getAmEndHhmm() {
		return this.amEndHhmm;
	}

	public void setAmEndHhmm(String amEndHhmm) {
		this.amEndHhmm = amEndHhmm;
	}


	@Column(name="AM_GWA_ROOM")
	public String getAmGwaRoom() {
		return this.amGwaRoom;
	}

	public void setAmGwaRoom(String amGwaRoom) {
		this.amGwaRoom = amGwaRoom;
	}


	@Column(name="AM_START_HHMM")
	public String getAmStartHhmm() {
		return this.amStartHhmm;
	}

	public void setAmStartHhmm(String amStartHhmm) {
		this.amStartHhmm = amStartHhmm;
	}


	public String getDoctor() {
		return this.doctor;
	}

	public void setDoctor(String doctor) {
		this.doctor = doctor;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="JINRYO_PRE_DATE")
	public Date getJinryoPreDate() {
		return this.jinryoPreDate;
	}

	public void setJinryoPreDate(Date jinryoPreDate) {
		this.jinryoPreDate = jinryoPreDate;
	}


	@Column(name="PM_END_HHMM")
	public String getPmEndHhmm() {
		return this.pmEndHhmm;
	}

	public void setPmEndHhmm(String pmEndHhmm) {
		this.pmEndHhmm = pmEndHhmm;
	}


	@Column(name="PM_GWA_ROOM")
	public String getPmGwaRoom() {
		return this.pmGwaRoom;
	}

	public void setPmGwaRoom(String pmGwaRoom) {
		this.pmGwaRoom = pmGwaRoom;
	}


	@Column(name="PM_START_HHMM")
	public String getPmStartHhmm() {
		return this.pmStartHhmm;
	}

	public void setPmStartHhmm(String pmStartHhmm) {
		this.pmStartHhmm = pmStartHhmm;
	}


	public String getRemark() {
		return this.remark;
	}

	public void setRemark(String remark) {
		this.remark = remark;
	}


	@Column(name="RES_AM_END_HHMM")
	public String getResAmEndHhmm() {
		return this.resAmEndHhmm;
	}

	public void setResAmEndHhmm(String resAmEndHhmm) {
		this.resAmEndHhmm = resAmEndHhmm;
	}


	@Column(name="RES_AM_START_HHMM")
	public String getResAmStartHhmm() {
		return this.resAmStartHhmm;
	}

	public void setResAmStartHhmm(String resAmStartHhmm) {
		this.resAmStartHhmm = resAmStartHhmm;
	}


	@Column(name="RES_PM_END_HHMM")
	public String getResPmEndHhmm() {
		return this.resPmEndHhmm;
	}

	public void setResPmEndHhmm(String resPmEndHhmm) {
		this.resPmEndHhmm = resPmEndHhmm;
	}


	@Column(name="RES_PM_START_HHMM")
	public String getResPmStartHhmm() {
		return this.resPmStartHhmm;
	}

	public void setResPmStartHhmm(String resPmStartHhmm) {
		this.resPmStartHhmm = resPmStartHhmm;
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