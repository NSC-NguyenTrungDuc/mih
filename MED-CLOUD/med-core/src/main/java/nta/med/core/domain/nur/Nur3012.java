package nta.med.core.domain.nur;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the NUR3012 database table.
 * 
 */
@Entity
@NamedQuery(name="Nur3012.findAll", query="SELECT n FROM Nur3012 n")
public class Nur3012 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String bunho;
	private String doctor;
	private String gaJubsuGubun;
	private String gwa;
	private String gwaRoom;
	private String hospCode;
	private double jinryoSeq;
	private double jubsuNo;
	private String jubsuTime;
	private Date naewonDate;
	private String naewonType;
	private double pknur3001;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Nur3012() {
	}


	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}


	public String getDoctor() {
		return this.doctor;
	}

	public void setDoctor(String doctor) {
		this.doctor = doctor;
	}


	@Column(name="GA_JUBSU_GUBUN")
	public String getGaJubsuGubun() {
		return this.gaJubsuGubun;
	}

	public void setGaJubsuGubun(String gaJubsuGubun) {
		this.gaJubsuGubun = gaJubsuGubun;
	}


	public String getGwa() {
		return this.gwa;
	}

	public void setGwa(String gwa) {
		this.gwa = gwa;
	}


	@Column(name="GWA_ROOM")
	public String getGwaRoom() {
		return this.gwaRoom;
	}

	public void setGwaRoom(String gwaRoom) {
		this.gwaRoom = gwaRoom;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="JINRYO_SEQ")
	public double getJinryoSeq() {
		return this.jinryoSeq;
	}

	public void setJinryoSeq(double jinryoSeq) {
		this.jinryoSeq = jinryoSeq;
	}


	@Column(name="JUBSU_NO")
	public double getJubsuNo() {
		return this.jubsuNo;
	}

	public void setJubsuNo(double jubsuNo) {
		this.jubsuNo = jubsuNo;
	}


	@Column(name="JUBSU_TIME")
	public String getJubsuTime() {
		return this.jubsuTime;
	}

	public void setJubsuTime(String jubsuTime) {
		this.jubsuTime = jubsuTime;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="NAEWON_DATE")
	public Date getNaewonDate() {
		return this.naewonDate;
	}

	public void setNaewonDate(Date naewonDate) {
		this.naewonDate = naewonDate;
	}


	@Column(name="NAEWON_TYPE")
	public String getNaewonType() {
		return this.naewonType;
	}

	public void setNaewonType(String naewonType) {
		this.naewonType = naewonType;
	}


	public double getPknur3001() {
		return this.pknur3001;
	}

	public void setPknur3001(double pknur3001) {
		this.pknur3001 = pknur3001;
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