package nta.med.core.domain.out;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the OUT0000 database table.
 * 
 */
@Entity
@NamedQuery(name="Out0000.findAll", query="SELECT o FROM Out0000 o")
public class Out0000 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String arriveKaikeiYn;
	private String doctor;
	private double fkout1001;
	private String gwa;
	private String hospCode;
	private String kaikeiEndYn;
	private Date naewonDate;
	private Date sysDate;
	private String sysId;
	private String transKaikeiYn;
	private Date updDate;
	private String updId;

	public Out0000() {
	}


	@Column(name="ARRIVE_KAIKEI_YN")
	public String getArriveKaikeiYn() {
		return this.arriveKaikeiYn;
	}

	public void setArriveKaikeiYn(String arriveKaikeiYn) {
		this.arriveKaikeiYn = arriveKaikeiYn;
	}


	public String getDoctor() {
		return this.doctor;
	}

	public void setDoctor(String doctor) {
		this.doctor = doctor;
	}


	public double getFkout1001() {
		return this.fkout1001;
	}

	public void setFkout1001(double fkout1001) {
		this.fkout1001 = fkout1001;
	}


	public String getGwa() {
		return this.gwa;
	}

	public void setGwa(String gwa) {
		this.gwa = gwa;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="KAIKEI_END_YN")
	public String getKaikeiEndYn() {
		return this.kaikeiEndYn;
	}

	public void setKaikeiEndYn(String kaikeiEndYn) {
		this.kaikeiEndYn = kaikeiEndYn;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="NAEWON_DATE")
	public Date getNaewonDate() {
		return this.naewonDate;
	}

	public void setNaewonDate(Date naewonDate) {
		this.naewonDate = naewonDate;
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


	@Column(name="TRANS_KAIKEI_YN")
	public String getTransKaikeiYn() {
		return this.transKaikeiYn;
	}

	public void setTransKaikeiYn(String transKaikeiYn) {
		this.transKaikeiYn = transKaikeiYn;
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