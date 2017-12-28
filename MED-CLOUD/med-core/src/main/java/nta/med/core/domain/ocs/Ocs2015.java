package nta.med.core.domain.ocs;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;

/**
 * The persistent class for the OCS2015 database table.
 * 
 */
@Entity
@Table(name = "OCS2015")
public class Ocs2015 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private Date actDate;
	private String actId;
	private String actResultCode;
	private String actResultText;
	private Double bloodSugar;
	private String bunho;
	private Double changeQty;
	private String directGubun;
	private Date drtDate;
	private Double dv;
	private Date endDate;
	private String endTime;
	private Double fio2;
	private Double fkinp1001;
	private Double fkocs2005;
	private String hospCode;
	private String inputDoctor;
	private String inputGubun;
	private String inputGwa;
	private String inputId;
	private Date orderDate;
	private Double pkSeq;
	private Double pkocs2015;
	private Double seq;
	private String siksaCode;
	private String startTime;
	private Double suryang;
	private Date sysDate;
	private String sysId;
	private String timeGubun;
	private Date updDate;
	private String updId;

	public Ocs2015() {
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "ACT_DATE")
	public Date getActDate() {
		return this.actDate;
	}

	public void setActDate(Date actDate) {
		this.actDate = actDate;
	}

	@Column(name = "ACT_ID")
	public String getActId() {
		return this.actId;
	}

	public void setActId(String actId) {
		this.actId = actId;
	}

	@Column(name = "ACT_RESULT_CODE")
	public String getActResultCode() {
		return this.actResultCode;
	}

	public void setActResultCode(String actResultCode) {
		this.actResultCode = actResultCode;
	}

	@Column(name = "ACT_RESULT_TEXT")
	public String getActResultText() {
		return this.actResultText;
	}

	public void setActResultText(String actResultText) {
		this.actResultText = actResultText;
	}

	@Column(name = "BLOOD_SUGAR")
	public Double getBloodSugar() {
		return this.bloodSugar;
	}

	public void setBloodSugar(Double bloodSugar) {
		this.bloodSugar = bloodSugar;
	}

	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}

	@Column(name = "CHANGE_QTY")
	public Double getChangeQty() {
		return this.changeQty;
	}

	public void setChangeQty(Double changeQty) {
		this.changeQty = changeQty;
	}

	@Column(name = "DIRECT_GUBUN")
	public String getDirectGubun() {
		return this.directGubun;
	}

	public void setDirectGubun(String directGubun) {
		this.directGubun = directGubun;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "DRT_DATE")
	public Date getDrtDate() {
		return this.drtDate;
	}

	public void setDrtDate(Date drtDate) {
		this.drtDate = drtDate;
	}

	public Double getDv() {
		return this.dv;
	}

	public void setDv(Double dv) {
		this.dv = dv;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "END_DATE")
	public Date getEndDate() {
		return this.endDate;
	}

	public void setEndDate(Date endDate) {
		this.endDate = endDate;
	}

	@Column(name = "END_TIME")
	public String getEndTime() {
		return this.endTime;
	}

	public void setEndTime(String endTime) {
		this.endTime = endTime;
	}

	public Double getFio2() {
		return this.fio2;
	}

	public void setFio2(Double fio2) {
		this.fio2 = fio2;
	}

	public Double getFkinp1001() {
		return this.fkinp1001;
	}

	public void setFkinp1001(Double fkinp1001) {
		this.fkinp1001 = fkinp1001;
	}

	public Double getFkocs2005() {
		return this.fkocs2005;
	}

	public void setFkocs2005(Double fkocs2005) {
		this.fkocs2005 = fkocs2005;
	}

	@Column(name = "HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}

	@Column(name = "INPUT_DOCTOR")
	public String getInputDoctor() {
		return this.inputDoctor;
	}

	public void setInputDoctor(String inputDoctor) {
		this.inputDoctor = inputDoctor;
	}

	@Column(name = "INPUT_GUBUN")
	public String getInputGubun() {
		return this.inputGubun;
	}

	public void setInputGubun(String inputGubun) {
		this.inputGubun = inputGubun;
	}

	@Column(name = "INPUT_GWA")
	public String getInputGwa() {
		return this.inputGwa;
	}

	public void setInputGwa(String inputGwa) {
		this.inputGwa = inputGwa;
	}

	@Column(name = "INPUT_ID")
	public String getInputId() {
		return this.inputId;
	}

	public void setInputId(String inputId) {
		this.inputId = inputId;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "ORDER_DATE")
	public Date getOrderDate() {
		return this.orderDate;
	}

	public void setOrderDate(Date orderDate) {
		this.orderDate = orderDate;
	}

	@Column(name = "PK_SEQ")
	public Double getPkSeq() {
		return this.pkSeq;
	}

	public void setPkSeq(Double pkSeq) {
		this.pkSeq = pkSeq;
	}

	public Double getPkocs2015() {
		return this.pkocs2015;
	}

	public void setPkocs2015(Double pkocs2015) {
		this.pkocs2015 = pkocs2015;
	}

	public Double getSeq() {
		return this.seq;
	}

	public void setSeq(Double seq) {
		this.seq = seq;
	}

	@Column(name = "SIKSA_CODE")
	public String getSiksaCode() {
		return this.siksaCode;
	}

	public void setSiksaCode(String siksaCode) {
		this.siksaCode = siksaCode;
	}

	@Column(name = "START_TIME")
	public String getStartTime() {
		return this.startTime;
	}

	public void setStartTime(String startTime) {
		this.startTime = startTime;
	}

	public Double getSuryang() {
		return this.suryang;
	}

	public void setSuryang(Double suryang) {
		this.suryang = suryang;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "SYS_DATE")
	public Date getSysDate() {
		return this.sysDate;
	}

	public void setSysDate(Date sysDate) {
		this.sysDate = sysDate;
	}

	@Column(name = "SYS_ID")
	public String getSysId() {
		return this.sysId;
	}

	public void setSysId(String sysId) {
		this.sysId = sysId;
	}

	@Column(name = "TIME_GUBUN")
	public String getTimeGubun() {
		return this.timeGubun;
	}

	public void setTimeGubun(String timeGubun) {
		this.timeGubun = timeGubun;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "UPD_DATE")
	public Date getUpdDate() {
		return this.updDate;
	}

	public void setUpdDate(Date updDate) {
		this.updDate = updDate;
	}

	@Column(name = "UPD_ID")
	public String getUpdId() {
		return this.updId;
	}

	public void setUpdId(String updId) {
		this.updId = updId;
	}

}