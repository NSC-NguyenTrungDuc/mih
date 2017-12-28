package nta.med.core.domain.nur;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;

/**
 * The persistent class for the NUR5023 database table.
 * 
 */
@Entity
@Table(name = "NUR5023")
public class Nur5023 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String bigo;
	private String bunho;
	private Date date1;
	private Date date2;
	private String detailGubun;
	private String fromGwa;
	private String fromHoCode;
	private String gubun;
	private String gwa;
	private String hoCode;
	private String hoDong;
	private String hospCode;
	private Date nurWrdt;
	private Double pknur5023;
	private String sang;
	private Date sysDate;
	private String sysId;
	private String time1;
	private String time2;
	private String toGwa;
	private String toHoCode;
	private Date updDate;
	private String updId;

	public Nur5023() {
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

	@Temporal(TemporalType.TIMESTAMP)
	public Date getDate1() {
		return this.date1;
	}

	public void setDate1(Date date1) {
		this.date1 = date1;
	}

	@Temporal(TemporalType.TIMESTAMP)
	public Date getDate2() {
		return this.date2;
	}

	public void setDate2(Date date2) {
		this.date2 = date2;
	}

	@Column(name = "DETAIL_GUBUN")
	public String getDetailGubun() {
		return this.detailGubun;
	}

	public void setDetailGubun(String detailGubun) {
		this.detailGubun = detailGubun;
	}

	@Column(name = "FROM_GWA")
	public String getFromGwa() {
		return this.fromGwa;
	}

	public void setFromGwa(String fromGwa) {
		this.fromGwa = fromGwa;
	}

	@Column(name = "FROM_HO_CODE")
	public String getFromHoCode() {
		return this.fromHoCode;
	}

	public void setFromHoCode(String fromHoCode) {
		this.fromHoCode = fromHoCode;
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

	public Double getPknur5023() {
		return this.pknur5023;
	}

	public void setPknur5023(Double pknur5023) {
		this.pknur5023 = pknur5023;
	}

	public String getSang() {
		return this.sang;
	}

	public void setSang(String sang) {
		this.sang = sang;
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

	public String getTime1() {
		return this.time1;
	}

	public void setTime1(String time1) {
		this.time1 = time1;
	}

	public String getTime2() {
		return this.time2;
	}

	public void setTime2(String time2) {
		this.time2 = time2;
	}

	@Column(name = "TO_GWA")
	public String getToGwa() {
		return this.toGwa;
	}

	public void setToGwa(String toGwa) {
		this.toGwa = toGwa;
	}

	@Column(name = "TO_HO_CODE")
	public String getToHoCode() {
		return this.toHoCode;
	}

	public void setToHoCode(String toHoCode) {
		this.toHoCode = toHoCode;
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