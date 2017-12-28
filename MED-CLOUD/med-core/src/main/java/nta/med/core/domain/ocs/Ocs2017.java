package nta.med.core.domain.ocs;

import java.math.BigDecimal;
import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;


/**
 * The persistent class for the OCS2017 database table.
 * 
 */
@Entity
@Table(name="OCS2017")
public class Ocs2017 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private Date actFromDate;
	private String actFromTime;
	private String actFromUser;
	private Date actResDate;
	private Date actToDate;
	private String actToTime;
	private String actToUser;
	private String actUser;
	private Date actingDate;
	private Double actingSuryang;
	private String actingTime;
	private Double bannabFkocs2003;
	private String bannabYn;
	private String cancelYn;
	private Double displaySeq;
	private Double fkinp3010;
	private Double fkocs2003;
	private String hangmogCode;
	private String hospCode;
	private String ifDataSendYn;
	private Date orderDate;
	private Date passDate;
	private String passTime;
	private String passUser;
	private String remark;
	private BigDecimal seq;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Ocs2017() {
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="ACT_FROM_DATE")
	public Date getActFromDate() {
		return this.actFromDate;
	}

	public void setActFromDate(Date actFromDate) {
		this.actFromDate = actFromDate;
	}


	@Column(name="ACT_FROM_TIME")
	public String getActFromTime() {
		return this.actFromTime;
	}

	public void setActFromTime(String actFromTime) {
		this.actFromTime = actFromTime;
	}


	@Column(name="ACT_FROM_USER")
	public String getActFromUser() {
		return this.actFromUser;
	}

	public void setActFromUser(String actFromUser) {
		this.actFromUser = actFromUser;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="ACT_RES_DATE")
	public Date getActResDate() {
		return this.actResDate;
	}

	public void setActResDate(Date actResDate) {
		this.actResDate = actResDate;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="ACT_TO_DATE")
	public Date getActToDate() {
		return this.actToDate;
	}

	public void setActToDate(Date actToDate) {
		this.actToDate = actToDate;
	}


	@Column(name="ACT_TO_TIME")
	public String getActToTime() {
		return this.actToTime;
	}

	public void setActToTime(String actToTime) {
		this.actToTime = actToTime;
	}


	@Column(name="ACT_TO_USER")
	public String getActToUser() {
		return this.actToUser;
	}

	public void setActToUser(String actToUser) {
		this.actToUser = actToUser;
	}


	@Column(name="ACT_USER")
	public String getActUser() {
		return this.actUser;
	}

	public void setActUser(String actUser) {
		this.actUser = actUser;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="ACTING_DATE")
	public Date getActingDate() {
		return this.actingDate;
	}

	public void setActingDate(Date actingDate) {
		this.actingDate = actingDate;
	}


	@Column(name="ACTING_SURYANG")
	public Double getActingSuryang() {
		return this.actingSuryang;
	}

	public void setActingSuryang(Double actingSuryang) {
		this.actingSuryang = actingSuryang;
	}


	@Column(name="ACTING_TIME")
	public String getActingTime() {
		return this.actingTime;
	}

	public void setActingTime(String actingTime) {
		this.actingTime = actingTime;
	}


	@Column(name="BANNAB_FKOCS2003")
	public Double getBannabFkocs2003() {
		return this.bannabFkocs2003;
	}

	public void setBannabFkocs2003(Double bannabFkocs2003) {
		this.bannabFkocs2003 = bannabFkocs2003;
	}


	@Column(name="BANNAB_YN")
	public String getBannabYn() {
		return this.bannabYn;
	}

	public void setBannabYn(String bannabYn) {
		this.bannabYn = bannabYn;
	}


	@Column(name="CANCEL_YN")
	public String getCancelYn() {
		return this.cancelYn;
	}

	public void setCancelYn(String cancelYn) {
		this.cancelYn = cancelYn;
	}


	@Column(name="DISPLAY_SEQ")
	public Double getDisplaySeq() {
		return this.displaySeq;
	}

	public void setDisplaySeq(Double displaySeq) {
		this.displaySeq = displaySeq;
	}


	public Double getFkinp3010() {
		return this.fkinp3010;
	}

	public void setFkinp3010(Double fkinp3010) {
		this.fkinp3010 = fkinp3010;
	}


	public Double getFkocs2003() {
		return this.fkocs2003;
	}

	public void setFkocs2003(Double fkocs2003) {
		this.fkocs2003 = fkocs2003;
	}


	@Column(name="HANGMOG_CODE")
	public String getHangmogCode() {
		return this.hangmogCode;
	}

	public void setHangmogCode(String hangmogCode) {
		this.hangmogCode = hangmogCode;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="IF_DATA_SEND_YN")
	public String getIfDataSendYn() {
		return this.ifDataSendYn;
	}

	public void setIfDataSendYn(String ifDataSendYn) {
		this.ifDataSendYn = ifDataSendYn;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="ORDER_DATE")
	public Date getOrderDate() {
		return this.orderDate;
	}

	public void setOrderDate(Date orderDate) {
		this.orderDate = orderDate;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="PASS_DATE")
	public Date getPassDate() {
		return this.passDate;
	}

	public void setPassDate(Date passDate) {
		this.passDate = passDate;
	}


	@Column(name="PASS_TIME")
	public String getPassTime() {
		return this.passTime;
	}

	public void setPassTime(String passTime) {
		this.passTime = passTime;
	}


	@Column(name="PASS_USER")
	public String getPassUser() {
		return this.passUser;
	}

	public void setPassUser(String passUser) {
		this.passUser = passUser;
	}


	public String getRemark() {
		return this.remark;
	}

	public void setRemark(String remark) {
		this.remark = remark;
	}


	public BigDecimal getSeq() {
		return this.seq;
	}

	public void setSeq(BigDecimal seq) {
		this.seq = seq;
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