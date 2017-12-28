package nta.med.core.domain.nur;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;

/**
 * The persistent class for the NUR5021 database table.
 * 
 */
@Entity
@Table(name = "NUR5021")
public class Nur5021 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private Double dansongCnt;
	private Double dokboCnt;
	private String hoDong;
	private Double hosongCnt;
	private String hospCode;
	private Date nurWrdt;
	private String stair;
	private String stairName;
	private Double stairTotalCnt;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Nur5021() {
	}

	@Column(name = "DANSONG_CNT")
	public Double getDansongCnt() {
		return this.dansongCnt;
	}

	public void setDansongCnt(Double dansongCnt) {
		this.dansongCnt = dansongCnt;
	}

	@Column(name = "DOKBO_CNT")
	public Double getDokboCnt() {
		return this.dokboCnt;
	}

	public void setDokboCnt(Double dokboCnt) {
		this.dokboCnt = dokboCnt;
	}

	@Column(name = "HO_DONG")
	public String getHoDong() {
		return this.hoDong;
	}

	public void setHoDong(String hoDong) {
		this.hoDong = hoDong;
	}

	@Column(name = "HOSONG_CNT")
	public Double getHosongCnt() {
		return this.hosongCnt;
	}

	public void setHosongCnt(Double hosongCnt) {
		this.hosongCnt = hosongCnt;
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

	public String getStair() {
		return this.stair;
	}

	public void setStair(String stair) {
		this.stair = stair;
	}

	@Column(name = "STAIR_NAME")
	public String getStairName() {
		return this.stairName;
	}

	public void setStairName(String stairName) {
		this.stairName = stairName;
	}

	@Column(name = "STAIR_TOTAL_CNT")
	public Double getStairTotalCnt() {
		return this.stairTotalCnt;
	}

	public void setStairTotalCnt(Double stairTotalCnt) {
		this.stairTotalCnt = stairTotalCnt;
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