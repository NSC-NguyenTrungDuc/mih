package nta.med.core.domain.nur;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;

/**
 * The persistent class for the NUR5024 database table.
 * 
 */
@Entity
@Table(name = "NUR5024")
public class Nur5024 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String bunho;
	private String comment1;
	private String comment2;
	private String comment3;
	private String detailGubun;
	private String gubun;
	private String gwa;
	private String hoCode;
	private String hoDong;
	private String hospCode;
	private Date nurWrdt;
	private String sang;
	private String sulsik;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Nur5024() {
	}

	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}

	public String getComment1() {
		return this.comment1;
	}

	public void setComment1(String comment1) {
		this.comment1 = comment1;
	}

	public String getComment2() {
		return this.comment2;
	}

	public void setComment2(String comment2) {
		this.comment2 = comment2;
	}

	public String getComment3() {
		return this.comment3;
	}

	public void setComment3(String comment3) {
		this.comment3 = comment3;
	}

	@Column(name = "DETAIL_GUBUN")
	public String getDetailGubun() {
		return this.detailGubun;
	}

	public void setDetailGubun(String detailGubun) {
		this.detailGubun = detailGubun;
	}

	public String getGubun() {
		return this.gubun;
	}

	public void setGubun(String gubun) {
		this.gubun = gubun;
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

	@Column(name = "HO_DONG")
	public String getHoDong() {
		return this.hoDong;
	}

	public void setHoDong(String hoDong) {
		this.hoDong = hoDong;
	}

	@Column(name = "HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "NUR_WRDT")
	public Date getNurWrdt() {
		return this.nurWrdt;
	}

	public void setNurWrdt(Date nurWrdt) {
		this.nurWrdt = nurWrdt;
	}

	public String getSang() {
		return this.sang;
	}

	public void setSang(String sang) {
		this.sang = sang;
	}

	public String getSulsik() {
		return this.sulsik;
	}

	public void setSulsik(String sulsik) {
		this.sulsik = sulsik;
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