package nta.med.core.domain.nur;

import java.math.BigDecimal;
import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;


/**
 * The persistent class for the NUR7001 database table.
 * 
 */
@Entity
@Table(name="NUR7001")
public class Nur7001 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private Double bodyHeat;
	private Double bpFrom;
	private Double bpTo;
	private Double breath;
	private String bunho;
	private Double height;
	private String hospCode;
	private Date measureDate;
	private String measureTime;
	private BigDecimal pulse;
	private Double seq;
	private Double spo2;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;
	private String vald;
	private Double weight;

	public Nur7001() {
	}


	@Column(name="BODY_HEAT")
	public Double getBodyHeat() {
		return this.bodyHeat;
	}

	public void setBodyHeat(Double bodyHeat) {
		this.bodyHeat = bodyHeat;
	}


	@Column(name="BP_FROM")
	public Double getBpFrom() {
		return this.bpFrom;
	}

	public void setBpFrom(Double bpFrom) {
		this.bpFrom = bpFrom;
	}


	@Column(name="BP_TO")
	public Double getBpTo() {
		return this.bpTo;
	}

	public void setBpTo(Double bpTo) {
		this.bpTo = bpTo;
	}


	public Double getBreath() {
		return this.breath;
	}

	public void setBreath(Double breath) {
		this.breath = breath;
	}


	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}


	public Double getHeight() {
		return this.height;
	}

	public void setHeight(Double height) {
		this.height = height;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="MEASURE_DATE")
	public Date getMeasureDate() {
		return this.measureDate;
	}

	public void setMeasureDate(Date measureDate) {
		this.measureDate = measureDate;
	}


	@Column(name="MEASURE_TIME")
	public String getMeasureTime() {
		return this.measureTime;
	}

	public void setMeasureTime(String measureTime) {
		this.measureTime = measureTime;
	}


	public BigDecimal getPulse() {
		return this.pulse;
	}

	public void setPulse(BigDecimal pulse) {
		this.pulse = pulse;
	}


	public Double getSeq() {
		return this.seq;
	}

	public void setSeq(Double seq) {
		this.seq = seq;
	}


	public Double getSpo2() {
		return this.spo2;
	}

	public void setSpo2(Double spo2) {
		this.spo2 = spo2;
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


	public String getVald() {
		return this.vald;
	}

	public void setVald(String vald) {
		this.vald = vald;
	}


	public Double getWeight() {
		return this.weight;
	}

	public void setWeight(Double weight) {
		this.weight = weight;
	}

	@Override
	public String toString() {
		return "Nur7001 [bodyHeat=" + bodyHeat + ", bpFrom=" + bpFrom
				+ ", bpTo=" + bpTo + ", breath=" + breath + ", bunho=" + bunho
				+ ", height=" + height + ", hospCode=" + hospCode
				+ ", measureDate=" + measureDate + ", measureTime="
				+ measureTime + ", pulse=" + pulse + ", seq=" + seq + ", spo2="
				+ spo2 + ", sysDate=" + sysDate + ", sysId=" + sysId
				+ ", updDate=" + updDate + ", updId=" + updId + ", vald="
				+ vald + ", weight=" + weight + "]";
	}
}