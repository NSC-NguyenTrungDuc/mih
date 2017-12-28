package nta.med.core.domain.nur;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.NamedQuery;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;

/**
 * The persistent class for the NUR5010 database table.
 * 
 */
@Entity
@NamedQuery(name = "Nur5010.findAll", query = "SELECT n FROM Nur5010 n")
public class Nur5010 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String bigo;
	private String bunho;
	private String chojae;
	private String doctor;
	private String emergency;
	private String gwa;
	private String hoCode;
	private String hospCode;
	private String jinryoEndTime;
	private String jinryoStartTime;
	private String jubsuTime;
	private Date naewonDate;
	private String nurse;
	private String sangName;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;
	private Double fkout1001;

	public Nur5010() {
	}

	public String getBigo() {
		return this.bigo;
	}

	public void setBigo(String bigo) {
		this.bigo = bigo;
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

	public String getEmergency() {
		return this.emergency;
	}

	public void setEmergency(String emergency) {
		this.emergency = emergency;
	}

	public String getGwa() {
		return this.gwa;
	}

	public void setGwa(String gwa) {
		this.gwa = gwa;
	}

	@Column(name = "HO_CODE")
	public String getHoCode() {
		return this.hoCode;
	}

	public void setHoCode(String hoCode) {
		this.hoCode = hoCode;
	}

	@Column(name = "HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}

	@Column(name = "JINRYO_END_TIME")
	public String getJinryoEndTime() {
		return this.jinryoEndTime;
	}

	public void setJinryoEndTime(String jinryoEndTime) {
		this.jinryoEndTime = jinryoEndTime;
	}

	@Column(name = "JINRYO_START_TIME")
	public String getJinryoStartTime() {
		return this.jinryoStartTime;
	}

	public void setJinryoStartTime(String jinryoStartTime) {
		this.jinryoStartTime = jinryoStartTime;
	}

	@Column(name = "JUBSU_TIME")
	public String getJubsuTime() {
		return this.jubsuTime;
	}

	public void setJubsuTime(String jubsuTime) {
		this.jubsuTime = jubsuTime;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "NAEWON_DATE")
	public Date getNaewonDate() {
		return this.naewonDate;
	}

	public void setNaewonDate(Date naewonDate) {
		this.naewonDate = naewonDate;
	}

	public String getNurse() {
		return this.nurse;
	}

	public void setNurse(String nurse) {
		this.nurse = nurse;
	}

	@Column(name = "SANG_NAME")
	public String getSangName() {
		return this.sangName;
	}

	public void setSangName(String sangName) {
		this.sangName = sangName;
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

	@Column(name = "FKOUT1001")
	public Double getFkout1001() {
		return fkout1001;
	}

	public void setFkout1001(Double fkout1001) {
		this.fkout1001 = fkout1001;
	}

}