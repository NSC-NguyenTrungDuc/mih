package nta.med.core.domain.nur;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;

/**
 * The persistent class for the NUR5020 database table.
 * 
 */
@Entity
@Table(name = "NUR5020")
public class Nur5020 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private Double gamyum1Cnt;
	private Double gamyum2Cnt;
	private Double gamyum3Cnt;
	private Double gamyum4Cnt;
	private Double gamyum5Cnt;
	private Double gamyum6Cnt;
	private String gamyum6Name;
	private Double gamyum7Cnt;
	private String gamyum7Name;
	private Double gamyum8Cnt;
	private String gamyum8Name;
	private String hoDong;
	private String hospCode;
	private Double ipwonCnt;
	private Double jaewonCnt;
	private Double moveInCnt;
	private Double moveOutCnt;
	private Date nurWrdt;
	private Date sysDate;
	private String sysId;
	private Double toiwonCnt;
	private Date updDate;
	private String updId;
	private Double yesterdayCnt;
	private String yokchangComment;
	private String yokchangNurse;

	public Nur5020() {
	}

	@Column(name = "GAMYUM1_CNT")
	public Double getGamyum1Cnt() {
		return this.gamyum1Cnt;
	}

	public void setGamyum1Cnt(Double gamyum1Cnt) {
		this.gamyum1Cnt = gamyum1Cnt;
	}

	@Column(name = "GAMYUM2_CNT")
	public Double getGamyum2Cnt() {
		return this.gamyum2Cnt;
	}

	public void setGamyum2Cnt(Double gamyum2Cnt) {
		this.gamyum2Cnt = gamyum2Cnt;
	}

	@Column(name = "GAMYUM3_CNT")
	public Double getGamyum3Cnt() {
		return this.gamyum3Cnt;
	}

	public void setGamyum3Cnt(Double gamyum3Cnt) {
		this.gamyum3Cnt = gamyum3Cnt;
	}

	@Column(name = "GAMYUM4_CNT")
	public Double getGamyum4Cnt() {
		return this.gamyum4Cnt;
	}

	public void setGamyum4Cnt(Double gamyum4Cnt) {
		this.gamyum4Cnt = gamyum4Cnt;
	}

	@Column(name = "GAMYUM5_CNT")
	public Double getGamyum5Cnt() {
		return this.gamyum5Cnt;
	}

	public void setGamyum5Cnt(Double gamyum5Cnt) {
		this.gamyum5Cnt = gamyum5Cnt;
	}

	@Column(name = "GAMYUM6_CNT")
	public Double getGamyum6Cnt() {
		return this.gamyum6Cnt;
	}

	public void setGamyum6Cnt(Double gamyum6Cnt) {
		this.gamyum6Cnt = gamyum6Cnt;
	}

	@Column(name = "GAMYUM6_NAME")
	public String getGamyum6Name() {
		return this.gamyum6Name;
	}

	public void setGamyum6Name(String gamyum6Name) {
		this.gamyum6Name = gamyum6Name;
	}

	@Column(name = "GAMYUM7_CNT")
	public Double getGamyum7Cnt() {
		return this.gamyum7Cnt;
	}

	public void setGamyum7Cnt(Double gamyum7Cnt) {
		this.gamyum7Cnt = gamyum7Cnt;
	}

	@Column(name = "GAMYUM7_NAME")
	public String getGamyum7Name() {
		return this.gamyum7Name;
	}

	public void setGamyum7Name(String gamyum7Name) {
		this.gamyum7Name = gamyum7Name;
	}

	@Column(name = "GAMYUM8_CNT")
	public Double getGamyum8Cnt() {
		return this.gamyum8Cnt;
	}

	public void setGamyum8Cnt(Double gamyum8Cnt) {
		this.gamyum8Cnt = gamyum8Cnt;
	}

	@Column(name = "GAMYUM8_NAME")
	public String getGamyum8Name() {
		return this.gamyum8Name;
	}

	public void setGamyum8Name(String gamyum8Name) {
		this.gamyum8Name = gamyum8Name;
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

	@Column(name = "IPWON_CNT")
	public Double getIpwonCnt() {
		return this.ipwonCnt;
	}

	public void setIpwonCnt(Double ipwonCnt) {
		this.ipwonCnt = ipwonCnt;
	}

	@Column(name = "JAEWON_CNT")
	public Double getJaewonCnt() {
		return this.jaewonCnt;
	}

	public void setJaewonCnt(Double jaewonCnt) {
		this.jaewonCnt = jaewonCnt;
	}

	@Column(name = "MOVE_IN_CNT")
	public Double getMoveInCnt() {
		return this.moveInCnt;
	}

	public void setMoveInCnt(Double moveInCnt) {
		this.moveInCnt = moveInCnt;
	}

	@Column(name = "MOVE_OUT_CNT")
	public Double getMoveOutCnt() {
		return this.moveOutCnt;
	}

	public void setMoveOutCnt(Double moveOutCnt) {
		this.moveOutCnt = moveOutCnt;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "NUR_WRDT")
	public Date getNurWrdt() {
		return this.nurWrdt;
	}

	public void setNurWrdt(Date nurWrdt) {
		this.nurWrdt = nurWrdt;
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

	@Column(name = "TOIWON_CNT")
	public Double getToiwonCnt() {
		return this.toiwonCnt;
	}

	public void setToiwonCnt(Double toiwonCnt) {
		this.toiwonCnt = toiwonCnt;
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

	@Column(name = "YESTERDAY_CNT")
	public Double getYesterdayCnt() {
		return this.yesterdayCnt;
	}

	public void setYesterdayCnt(Double yesterdayCnt) {
		this.yesterdayCnt = yesterdayCnt;
	}

	@Column(name = "YOKCHANG_COMMENT")
	public String getYokchangComment() {
		return this.yokchangComment;
	}

	public void setYokchangComment(String yokchangComment) {
		this.yokchangComment = yokchangComment;
	}

	@Column(name = "YOKCHANG_NURSE")
	public String getYokchangNurse() {
		return this.yokchangNurse;
	}

	public void setYokchangNurse(String yokchangNurse) {
		this.yokchangNurse = yokchangNurse;
	}

}