package nta.med.core.domain.ifs;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;

import javax.persistence.*;

import java.util.Date;


/**
 * The persistent class for the IFS7104 database table.
 * 
 */
@Entity
@NamedQuery(name="Ifs7104.findAll", query="SELECT i FROM Ifs7104 i")
@Table(name="IFS7104")
public class Ifs7104 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String bogyongCode;
	private String bogyongCodeName;
	private String bogyongGubun;
	private String bogyongSigi;
	private String bogyongSigiGubun;
	private String dayDvCnt;
	private String dayDvGubun;
	private String drgBunho;
	private String drgCnt;
	private String drgRpCmtCnt;
	private String drgRpNo;
	private String dv;
	private String endFlag;
	private double fkifs7101;
	private String giganCnt;
	private String giganGubun;
	private String hospCode;
	private String recGubun;
	private String remark;
	private String remark1;
	private double seqRp;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;
	private String weekDays;

	public Ifs7104() {
	}


	@Column(name="BOGYONG_CODE")
	public String getBogyongCode() {
		return this.bogyongCode;
	}

	public void setBogyongCode(String bogyongCode) {
		this.bogyongCode = bogyongCode;
	}


	@Column(name="BOGYONG_CODE_NAME")
	public String getBogyongCodeName() {
		return this.bogyongCodeName;
	}

	public void setBogyongCodeName(String bogyongCodeName) {
		this.bogyongCodeName = bogyongCodeName;
	}


	@Column(name="BOGYONG_GUBUN")
	public String getBogyongGubun() {
		return this.bogyongGubun;
	}

	public void setBogyongGubun(String bogyongGubun) {
		this.bogyongGubun = bogyongGubun;
	}


	@Column(name="BOGYONG_SIGI")
	public String getBogyongSigi() {
		return this.bogyongSigi;
	}

	public void setBogyongSigi(String bogyongSigi) {
		this.bogyongSigi = bogyongSigi;
	}


	@Column(name="BOGYONG_SIGI_GUBUN")
	public String getBogyongSigiGubun() {
		return this.bogyongSigiGubun;
	}

	public void setBogyongSigiGubun(String bogyongSigiGubun) {
		this.bogyongSigiGubun = bogyongSigiGubun;
	}


	@Column(name="DAY_DV_CNT")
	public String getDayDvCnt() {
		return this.dayDvCnt;
	}

	public void setDayDvCnt(String dayDvCnt) {
		this.dayDvCnt = dayDvCnt;
	}


	@Column(name="DAY_DV_GUBUN")
	public String getDayDvGubun() {
		return this.dayDvGubun;
	}

	public void setDayDvGubun(String dayDvGubun) {
		this.dayDvGubun = dayDvGubun;
	}


	@Column(name="DRG_BUNHO")
	public String getDrgBunho() {
		return this.drgBunho;
	}

	public void setDrgBunho(String drgBunho) {
		this.drgBunho = drgBunho;
	}


	@Column(name="DRG_CNT")
	public String getDrgCnt() {
		return this.drgCnt;
	}

	public void setDrgCnt(String drgCnt) {
		this.drgCnt = drgCnt;
	}


	@Column(name="DRG_RP_CMT_CNT")
	public String getDrgRpCmtCnt() {
		return this.drgRpCmtCnt;
	}

	public void setDrgRpCmtCnt(String drgRpCmtCnt) {
		this.drgRpCmtCnt = drgRpCmtCnt;
	}


	@Column(name="DRG_RP_NO")
	public String getDrgRpNo() {
		return this.drgRpNo;
	}

	public void setDrgRpNo(String drgRpNo) {
		this.drgRpNo = drgRpNo;
	}


	public String getDv() {
		return this.dv;
	}

	public void setDv(String dv) {
		this.dv = dv;
	}


	@Column(name="END_FLAG")
	public String getEndFlag() {
		return this.endFlag;
	}

	public void setEndFlag(String endFlag) {
		this.endFlag = endFlag;
	}


	public double getFkifs7101() {
		return this.fkifs7101;
	}

	public void setFkifs7101(double fkifs7101) {
		this.fkifs7101 = fkifs7101;
	}


	@Column(name="GIGAN_CNT")
	public String getGiganCnt() {
		return this.giganCnt;
	}

	public void setGiganCnt(String giganCnt) {
		this.giganCnt = giganCnt;
	}


	@Column(name="GIGAN_GUBUN")
	public String getGiganGubun() {
		return this.giganGubun;
	}

	public void setGiganGubun(String giganGubun) {
		this.giganGubun = giganGubun;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="REC_GUBUN")
	public String getRecGubun() {
		return this.recGubun;
	}

	public void setRecGubun(String recGubun) {
		this.recGubun = recGubun;
	}


	public String getRemark() {
		return this.remark;
	}

	public void setRemark(String remark) {
		this.remark = remark;
	}


	public String getRemark1() {
		return this.remark1;
	}

	public void setRemark1(String remark1) {
		this.remark1 = remark1;
	}


	@Column(name="SEQ_RP")
	public double getSeqRp() {
		return this.seqRp;
	}

	public void setSeqRp(double seqRp) {
		this.seqRp = seqRp;
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


	@Column(name="WEEK_DAYS")
	public String getWeekDays() {
		return this.weekDays;
	}

	public void setWeekDays(String weekDays) {
		this.weekDays = weekDays;
	}

}