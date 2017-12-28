package nta.med.core.domain.nur;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the NUR3001 database table.
 * 
 */
@Entity
@NamedQuery(name="Nur3001.findAll", query="SELECT n FROM Nur3001 n")
public class Nur3001 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String amPmGubun;
	private String beforeGumsaYn;
	private String bunho;
	private String dangilGumsaYn;
	private String doctor;
	private String gaJubsuGubun;
	private String gwa;
	private String gwaRoom;
	private String hospCode;
	private double jinryoSeq;
	private String jinryoState;
	private String jinryoTime;
	private String jubsuGubun;
	private double jubsuNo;
	private String jubsuTime;
	private Date naewonDate;
	private String naewonType;
	private double pknur3001;
	private double sujinNo;
	private Date sysDate;
	private String sysId;
	private String telGubun;
	private Date updDate;
	private String updId;
	private String userSeqYn;

	public Nur3001() {
	}


	@Column(name="AM_PM_GUBUN")
	public String getAmPmGubun() {
		return this.amPmGubun;
	}

	public void setAmPmGubun(String amPmGubun) {
		this.amPmGubun = amPmGubun;
	}


	@Column(name="BEFORE_GUMSA_YN")
	public String getBeforeGumsaYn() {
		return this.beforeGumsaYn;
	}

	public void setBeforeGumsaYn(String beforeGumsaYn) {
		this.beforeGumsaYn = beforeGumsaYn;
	}


	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}


	@Column(name="DANGIL_GUMSA_YN")
	public String getDangilGumsaYn() {
		return this.dangilGumsaYn;
	}

	public void setDangilGumsaYn(String dangilGumsaYn) {
		this.dangilGumsaYn = dangilGumsaYn;
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


	@Column(name="JINRYO_STATE")
	public String getJinryoState() {
		return this.jinryoState;
	}

	public void setJinryoState(String jinryoState) {
		this.jinryoState = jinryoState;
	}


	@Column(name="JINRYO_TIME")
	public String getJinryoTime() {
		return this.jinryoTime;
	}

	public void setJinryoTime(String jinryoTime) {
		this.jinryoTime = jinryoTime;
	}


	@Column(name="JUBSU_GUBUN")
	public String getJubsuGubun() {
		return this.jubsuGubun;
	}

	public void setJubsuGubun(String jubsuGubun) {
		this.jubsuGubun = jubsuGubun;
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


	@Column(name="SUJIN_NO")
	public double getSujinNo() {
		return this.sujinNo;
	}

	public void setSujinNo(double sujinNo) {
		this.sujinNo = sujinNo;
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


	@Column(name="TEL_GUBUN")
	public String getTelGubun() {
		return this.telGubun;
	}

	public void setTelGubun(String telGubun) {
		this.telGubun = telGubun;
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


	@Column(name="USER_SEQ_YN")
	public String getUserSeqYn() {
		return this.userSeqYn;
	}

	public void setUserSeqYn(String userSeqYn) {
		this.userSeqYn = userSeqYn;
	}

}