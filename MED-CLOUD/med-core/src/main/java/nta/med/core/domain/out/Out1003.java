package nta.med.core.domain.out;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;

/**
 * The persistent class for the OUT1003 database table.
 * 
 */
@Entity
@Table(name = "OUT1003")
public class Out1003 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private Date actingDate;
	private String bunho;
	private String chojae;
	private String doctor;
	private Double fkout1001;
	private String gubun;
	private String gubunTransYn;
	private String gubunUuid;
	private String gwa;
	private String hospCode;
	private Double pkout1003;
	private String sanjungGubun;
	private Double seq;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Out1003() {
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "ACTING_DATE")
	public Date getActingDate() {
		return this.actingDate;
	}

	public void setActingDate(Date actingDate) {
		this.actingDate = actingDate;
	}

	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}

	public String getChojae() {
		return this.chojae;
	}

	public void setChojae(String chojae) {
		this.chojae = chojae;
	}

	public String getDoctor() {
		return this.doctor;
	}

	public void setDoctor(String doctor) {
		this.doctor = doctor;
	}

	public Double getFkout1001() {
		return this.fkout1001;
	}

	public void setFkout1001(Double fkout1001) {
		this.fkout1001 = fkout1001;
	}

	public String getGubun() {
		return this.gubun;
	}

	public void setGubun(String gubun) {
		this.gubun = gubun;
	}

	@Column(name = "GUBUN_TRANS_YN")
	public String getGubunTransYn() {
		return this.gubunTransYn;
	}

	public void setGubunTransYn(String gubunTransYn) {
		this.gubunTransYn = gubunTransYn;
	}

	@Column(name = "GUBUN_UUID")
	public String getGubunUuid() {
		return this.gubunUuid;
	}

	public void setGubunUuid(String gubunUuid) {
		this.gubunUuid = gubunUuid;
	}

	public String getGwa() {
		return this.gwa;
	}

	public void setGwa(String gwa) {
		this.gwa = gwa;
	}

	@Column(name = "HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}

	public Double getPkout1003() {
		return this.pkout1003;
	}

	public void setPkout1003(Double pkout1003) {
		this.pkout1003 = pkout1003;
	}

	@Column(name = "SANJUNG_GUBUN")
	public String getSanjungGubun() {
		return this.sanjungGubun;
	}

	public void setSanjungGubun(String sanjungGubun) {
		this.sanjungGubun = sanjungGubun;
	}

	public Double getSeq() {
		return this.seq;
	}

	public void setSeq(Double seq) {
		this.seq = seq;
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