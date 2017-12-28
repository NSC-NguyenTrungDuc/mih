package nta.med.core.domain.nur;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the NUR1019 database table.
 * 
 */
@Entity
@NamedQuery(name="Nur1019.findAll", query="SELECT n FROM Nur1019 n")
public class Nur1019 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String bunho;
	private String comments;
	private String doctor;
	private double fkinp1001;
	private String gwa;
	private String hoCode;
	private String hoDong;
	private String hospCode;
	private String junipJunchulGubun;
	private Date nurWrdt;
	private double pknur1019;
	private String sangName;
	private Date sysDate;
	private String sysId;
	private double transCnt;
	private Date updDate;
	private String updId;

	public Nur1019() {
	}


	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}


	public String getComments() {
		return this.comments;
	}

	public void setComments(String comments) {
		this.comments = comments;
	}


	public String getDoctor() {
		return this.doctor;
	}

	public void setDoctor(String doctor) {
		this.doctor = doctor;
	}


	public double getFkinp1001() {
		return this.fkinp1001;
	}

	public void setFkinp1001(double fkinp1001) {
		this.fkinp1001 = fkinp1001;
	}


	public String getGwa() {
		return this.gwa;
	}

	public void setGwa(String gwa) {
		this.gwa = gwa;
	}


	@Column(name="HO_CODE")
	public String getHoCode() {
		return this.hoCode;
	}

	public void setHoCode(String hoCode) {
		this.hoCode = hoCode;
	}


	@Column(name="HO_DONG")
	public String getHoDong() {
		return this.hoDong;
	}

	public void setHoDong(String hoDong) {
		this.hoDong = hoDong;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="JUNIP_JUNCHUL_GUBUN")
	public String getJunipJunchulGubun() {
		return this.junipJunchulGubun;
	}

	public void setJunipJunchulGubun(String junipJunchulGubun) {
		this.junipJunchulGubun = junipJunchulGubun;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="NUR_WRDT")
	public Date getNurWrdt() {
		return this.nurWrdt;
	}

	public void setNurWrdt(Date nurWrdt) {
		this.nurWrdt = nurWrdt;
	}


	public double getPknur1019() {
		return this.pknur1019;
	}

	public void setPknur1019(double pknur1019) {
		this.pknur1019 = pknur1019;
	}


	@Column(name="SANG_NAME")
	public String getSangName() {
		return this.sangName;
	}

	public void setSangName(String sangName) {
		this.sangName = sangName;
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


	@Column(name="TRANS_CNT")
	public double getTransCnt() {
		return this.transCnt;
	}

	public void setTransCnt(double transCnt) {
		this.transCnt = transCnt;
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