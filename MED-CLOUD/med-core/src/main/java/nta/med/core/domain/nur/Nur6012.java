package nta.med.core.domain.nur;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.NamedQuery;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;


/**
 * The persistent class for the NUR6012 database table.
 * 
 */
@Entity
@Table(name = "NUR6012")
public class Nur6012 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String assessor;
	private Date assessorDate;
	private Double bedsoreAlb;
	private String bedsoreBuwi;
	private String bedsoreColor;
	private String bedsoreColor2;
	private String bedsoreColor3;
	private String bedsoreColor4;
	private String bedsoreDeath;
	private String bedsoreDeep;
	private Double bedsoreDepth;
	private Double bedsoreFbs;
	private String bedsoreGita;
	private Double bedsoreHb;
	private String bedsoreInfe;
	private String bedsoreMoist;
	private Double bedsoreMoistRate;
	private String bedsoreNut;
	private Double bedsorePoketFinish1;
	private Double bedsorePoketFinish2;
	private Double bedsorePoketStart1;
	private Double bedsorePoketStart2;
	private Double bedsorePoket1;
	private Double bedsorePoket2;
	private Double bedsoreSizeFinish1;
	private Double bedsoreSizeFinish2;
	private Double bedsoreSizeStart1;
	private Double bedsoreSizeStart2;
	private Double bedsoreSize1;
	private Double bedsoreSize2;
	private String bedsoreSkin;
	private Double bedsoreZn;
	private String bunho;
	private String chuchiText;
	private String endYn;
	private String exudationColor;
	private String exudationSmell;
	private String exudationState;
	private String exudationState1;
	private String exudationState2;
	private String exudationVolume;
	private String firstSayu;
	private Date fromDate;
	private String gaesajojik;
	private String hospCode;
	private String lastSayu;
	private String pocketGubun;
	private Double pocketSizeEnd;
	private Double pocketSizeStart;
	private String samchulYang;
	private Date sysDate;
	private String sysId;
	private Double totalCount;
	private Date updDate;
	private String updId;
	private Double yokchangAlb;
	private String yokchangDeep;
	private String yokchangGamyum;
	private Double yokchangHb;
	private String yokchangSize;
	private Double yokchangSizeEnd;
	private Double yokchangSizeStart;
	private String yokchangStage;
	private Double yokchangTp;
	private String yukajojik;
	private String yungyangSiksaGubun;
	private Double yungyangSiksaPercent;
	private Double yungyangSiksaYang;
	private Double yungyangSuaekYang;
	private String yungyangSuaekYn;

	public Nur6012() {
	}


	public String getAssessor() {
		return this.assessor;
	}

	public void setAssessor(String assessor) {
		this.assessor = assessor;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="ASSESSOR_DATE")
	public Date getAssessorDate() {
		return this.assessorDate;
	}

	public void setAssessorDate(Date assessorDate) {
		this.assessorDate = assessorDate;
	}


	@Column(name="BEDSORE_ALB")
	public Double getBedsoreAlb() {
		return this.bedsoreAlb;
	}

	public void setBedsoreAlb(Double bedsoreAlb) {
		this.bedsoreAlb = bedsoreAlb;
	}


	@Column(name="BEDSORE_BUWI")
	public String getBedsoreBuwi() {
		return this.bedsoreBuwi;
	}

	public void setBedsoreBuwi(String bedsoreBuwi) {
		this.bedsoreBuwi = bedsoreBuwi;
	}


	@Column(name="BEDSORE_COLOR")
	public String getBedsoreColor() {
		return this.bedsoreColor;
	}

	public void setBedsoreColor(String bedsoreColor) {
		this.bedsoreColor = bedsoreColor;
	}


	@Column(name="BEDSORE_COLOR2")
	public String getBedsoreColor2() {
		return this.bedsoreColor2;
	}

	public void setBedsoreColor2(String bedsoreColor2) {
		this.bedsoreColor2 = bedsoreColor2;
	}


	@Column(name="BEDSORE_COLOR3")
	public String getBedsoreColor3() {
		return this.bedsoreColor3;
	}

	public void setBedsoreColor3(String bedsoreColor3) {
		this.bedsoreColor3 = bedsoreColor3;
	}


	@Column(name="BEDSORE_COLOR4")
	public String getBedsoreColor4() {
		return this.bedsoreColor4;
	}

	public void setBedsoreColor4(String bedsoreColor4) {
		this.bedsoreColor4 = bedsoreColor4;
	}


	@Column(name="BEDSORE_DEATH")
	public String getBedsoreDeath() {
		return this.bedsoreDeath;
	}

	public void setBedsoreDeath(String bedsoreDeath) {
		this.bedsoreDeath = bedsoreDeath;
	}


	@Column(name="BEDSORE_DEEP")
	public String getBedsoreDeep() {
		return this.bedsoreDeep;
	}

	public void setBedsoreDeep(String bedsoreDeep) {
		this.bedsoreDeep = bedsoreDeep;
	}


	@Column(name="BEDSORE_DEPTH")
	public Double getBedsoreDepth() {
		return this.bedsoreDepth;
	}

	public void setBedsoreDepth(Double bedsoreDepth) {
		this.bedsoreDepth = bedsoreDepth;
	}


	@Column(name="BEDSORE_FBS")
	public Double getBedsoreFbs() {
		return this.bedsoreFbs;
	}

	public void setBedsoreFbs(Double bedsoreFbs) {
		this.bedsoreFbs = bedsoreFbs;
	}


	@Column(name="BEDSORE_GITA")
	public String getBedsoreGita() {
		return this.bedsoreGita;
	}

	public void setBedsoreGita(String bedsoreGita) {
		this.bedsoreGita = bedsoreGita;
	}


	@Column(name="BEDSORE_HB")
	public Double getBedsoreHb() {
		return this.bedsoreHb;
	}

	public void setBedsoreHb(Double bedsoreHb) {
		this.bedsoreHb = bedsoreHb;
	}


	@Column(name="BEDSORE_INFE")
	public String getBedsoreInfe() {
		return this.bedsoreInfe;
	}

	public void setBedsoreInfe(String bedsoreInfe) {
		this.bedsoreInfe = bedsoreInfe;
	}


	@Column(name="BEDSORE_MOIST")
	public String getBedsoreMoist() {
		return this.bedsoreMoist;
	}

	public void setBedsoreMoist(String bedsoreMoist) {
		this.bedsoreMoist = bedsoreMoist;
	}


	@Column(name="BEDSORE_MOIST_RATE")
	public Double getBedsoreMoistRate() {
		return this.bedsoreMoistRate;
	}

	public void setBedsoreMoistRate(Double bedsoreMoistRate) {
		this.bedsoreMoistRate = bedsoreMoistRate;
	}


	@Column(name="BEDSORE_NUT")
	public String getBedsoreNut() {
		return this.bedsoreNut;
	}

	public void setBedsoreNut(String bedsoreNut) {
		this.bedsoreNut = bedsoreNut;
	}


	@Column(name="BEDSORE_POKET_FINISH1")
	public Double getBedsorePoketFinish1() {
		return this.bedsorePoketFinish1;
	}

	public void setBedsorePoketFinish1(Double bedsorePoketFinish1) {
		this.bedsorePoketFinish1 = bedsorePoketFinish1;
	}


	@Column(name="BEDSORE_POKET_FINISH2")
	public Double getBedsorePoketFinish2() {
		return this.bedsorePoketFinish2;
	}

	public void setBedsorePoketFinish2(Double bedsorePoketFinish2) {
		this.bedsorePoketFinish2 = bedsorePoketFinish2;
	}


	@Column(name="BEDSORE_POKET_START1")
	public Double getBedsorePoketStart1() {
		return this.bedsorePoketStart1;
	}

	public void setBedsorePoketStart1(Double bedsorePoketStart1) {
		this.bedsorePoketStart1 = bedsorePoketStart1;
	}


	@Column(name="BEDSORE_POKET_START2")
	public Double getBedsorePoketStart2() {
		return this.bedsorePoketStart2;
	}

	public void setBedsorePoketStart2(Double bedsorePoketStart2) {
		this.bedsorePoketStart2 = bedsorePoketStart2;
	}


	@Column(name="BEDSORE_POKET1")
	public Double getBedsorePoket1() {
		return this.bedsorePoket1;
	}

	public void setBedsorePoket1(Double bedsorePoket1) {
		this.bedsorePoket1 = bedsorePoket1;
	}


	@Column(name="BEDSORE_POKET2")
	public Double getBedsorePoket2() {
		return this.bedsorePoket2;
	}

	public void setBedsorePoket2(Double bedsorePoket2) {
		this.bedsorePoket2 = bedsorePoket2;
	}


	@Column(name="BEDSORE_SIZE_FINISH1")
	public Double getBedsoreSizeFinish1() {
		return this.bedsoreSizeFinish1;
	}

	public void setBedsoreSizeFinish1(Double bedsoreSizeFinish1) {
		this.bedsoreSizeFinish1 = bedsoreSizeFinish1;
	}


	@Column(name="BEDSORE_SIZE_FINISH2")
	public Double getBedsoreSizeFinish2() {
		return this.bedsoreSizeFinish2;
	}

	public void setBedsoreSizeFinish2(Double bedsoreSizeFinish2) {
		this.bedsoreSizeFinish2 = bedsoreSizeFinish2;
	}


	@Column(name="BEDSORE_SIZE_START1")
	public Double getBedsoreSizeStart1() {
		return this.bedsoreSizeStart1;
	}

	public void setBedsoreSizeStart1(Double bedsoreSizeStart1) {
		this.bedsoreSizeStart1 = bedsoreSizeStart1;
	}


	@Column(name="BEDSORE_SIZE_START2")
	public Double getBedsoreSizeStart2() {
		return this.bedsoreSizeStart2;
	}

	public void setBedsoreSizeStart2(Double bedsoreSizeStart2) {
		this.bedsoreSizeStart2 = bedsoreSizeStart2;
	}


	@Column(name="BEDSORE_SIZE1")
	public Double getBedsoreSize1() {
		return this.bedsoreSize1;
	}

	public void setBedsoreSize1(Double bedsoreSize1) {
		this.bedsoreSize1 = bedsoreSize1;
	}


	@Column(name="BEDSORE_SIZE2")
	public Double getBedsoreSize2() {
		return this.bedsoreSize2;
	}

	public void setBedsoreSize2(Double bedsoreSize2) {
		this.bedsoreSize2 = bedsoreSize2;
	}


	@Column(name="BEDSORE_SKIN")
	public String getBedsoreSkin() {
		return this.bedsoreSkin;
	}

	public void setBedsoreSkin(String bedsoreSkin) {
		this.bedsoreSkin = bedsoreSkin;
	}


	@Column(name="BEDSORE_ZN")
	public Double getBedsoreZn() {
		return this.bedsoreZn;
	}

	public void setBedsoreZn(Double bedsoreZn) {
		this.bedsoreZn = bedsoreZn;
	}


	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}


	@Column(name="CHUCHI_TEXT")
	public String getChuchiText() {
		return this.chuchiText;
	}

	public void setChuchiText(String chuchiText) {
		this.chuchiText = chuchiText;
	}


	@Column(name="END_YN")
	public String getEndYn() {
		return this.endYn;
	}

	public void setEndYn(String endYn) {
		this.endYn = endYn;
	}


	@Column(name="EXUDATION_COLOR")
	public String getExudationColor() {
		return this.exudationColor;
	}

	public void setExudationColor(String exudationColor) {
		this.exudationColor = exudationColor;
	}


	@Column(name="EXUDATION_SMELL")
	public String getExudationSmell() {
		return this.exudationSmell;
	}

	public void setExudationSmell(String exudationSmell) {
		this.exudationSmell = exudationSmell;
	}


	@Column(name="EXUDATION_STATE")
	public String getExudationState() {
		return this.exudationState;
	}

	public void setExudationState(String exudationState) {
		this.exudationState = exudationState;
	}


	@Column(name="EXUDATION_STATE1")
	public String getExudationState1() {
		return this.exudationState1;
	}

	public void setExudationState1(String exudationState1) {
		this.exudationState1 = exudationState1;
	}


	@Column(name="EXUDATION_STATE2")
	public String getExudationState2() {
		return this.exudationState2;
	}

	public void setExudationState2(String exudationState2) {
		this.exudationState2 = exudationState2;
	}


	@Column(name="EXUDATION_VOLUME")
	public String getExudationVolume() {
		return this.exudationVolume;
	}

	public void setExudationVolume(String exudationVolume) {
		this.exudationVolume = exudationVolume;
	}


	@Column(name="FIRST_SAYU")
	public String getFirstSayu() {
		return this.firstSayu;
	}

	public void setFirstSayu(String firstSayu) {
		this.firstSayu = firstSayu;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="FROM_DATE")
	public Date getFromDate() {
		return this.fromDate;
	}

	public void setFromDate(Date fromDate) {
		this.fromDate = fromDate;
	}


	public String getGaesajojik() {
		return this.gaesajojik;
	}

	public void setGaesajojik(String gaesajojik) {
		this.gaesajojik = gaesajojik;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="LAST_SAYU")
	public String getLastSayu() {
		return this.lastSayu;
	}

	public void setLastSayu(String lastSayu) {
		this.lastSayu = lastSayu;
	}


	@Column(name="POCKET_GUBUN")
	public String getPocketGubun() {
		return this.pocketGubun;
	}

	public void setPocketGubun(String pocketGubun) {
		this.pocketGubun = pocketGubun;
	}


	@Column(name="POCKET_SIZE_END")
	public Double getPocketSizeEnd() {
		return this.pocketSizeEnd;
	}

	public void setPocketSizeEnd(Double pocketSizeEnd) {
		this.pocketSizeEnd = pocketSizeEnd;
	}


	@Column(name="POCKET_SIZE_START")
	public Double getPocketSizeStart() {
		return this.pocketSizeStart;
	}

	public void setPocketSizeStart(Double pocketSizeStart) {
		this.pocketSizeStart = pocketSizeStart;
	}


	@Column(name="SAMCHUL_YANG")
	public String getSamchulYang() {
		return this.samchulYang;
	}

	public void setSamchulYang(String samchulYang) {
		this.samchulYang = samchulYang;
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


	@Column(name="TOTAL_COUNT")
	public Double getTotalCount() {
		return this.totalCount;
	}

	public void setTotalCount(Double totalCount) {
		this.totalCount = totalCount;
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


	@Column(name="YOKCHANG_ALB")
	public Double getYokchangAlb() {
		return this.yokchangAlb;
	}

	public void setYokchangAlb(Double yokchangAlb) {
		this.yokchangAlb = yokchangAlb;
	}


	@Column(name="YOKCHANG_DEEP")
	public String getYokchangDeep() {
		return this.yokchangDeep;
	}

	public void setYokchangDeep(String yokchangDeep) {
		this.yokchangDeep = yokchangDeep;
	}


	@Column(name="YOKCHANG_GAMYUM")
	public String getYokchangGamyum() {
		return this.yokchangGamyum;
	}

	public void setYokchangGamyum(String yokchangGamyum) {
		this.yokchangGamyum = yokchangGamyum;
	}


	@Column(name="YOKCHANG_HB")
	public Double getYokchangHb() {
		return this.yokchangHb;
	}

	public void setYokchangHb(Double yokchangHb) {
		this.yokchangHb = yokchangHb;
	}


	@Column(name="YOKCHANG_SIZE")
	public String getYokchangSize() {
		return this.yokchangSize;
	}

	public void setYokchangSize(String yokchangSize) {
		this.yokchangSize = yokchangSize;
	}


	@Column(name="YOKCHANG_SIZE_END")
	public Double getYokchangSizeEnd() {
		return this.yokchangSizeEnd;
	}

	public void setYokchangSizeEnd(Double yokchangSizeEnd) {
		this.yokchangSizeEnd = yokchangSizeEnd;
	}


	@Column(name="YOKCHANG_SIZE_START")
	public Double getYokchangSizeStart() {
		return this.yokchangSizeStart;
	}

	public void setYokchangSizeStart(Double yokchangSizeStart) {
		this.yokchangSizeStart = yokchangSizeStart;
	}


	@Column(name="YOKCHANG_STAGE")
	public String getYokchangStage() {
		return this.yokchangStage;
	}

	public void setYokchangStage(String yokchangStage) {
		this.yokchangStage = yokchangStage;
	}


	@Column(name="YOKCHANG_TP")
	public Double getYokchangTp() {
		return this.yokchangTp;
	}

	public void setYokchangTp(Double yokchangTp) {
		this.yokchangTp = yokchangTp;
	}


	public String getYukajojik() {
		return this.yukajojik;
	}

	public void setYukajojik(String yukajojik) {
		this.yukajojik = yukajojik;
	}


	@Column(name="YUNGYANG_SIKSA_GUBUN")
	public String getYungyangSiksaGubun() {
		return this.yungyangSiksaGubun;
	}

	public void setYungyangSiksaGubun(String yungyangSiksaGubun) {
		this.yungyangSiksaGubun = yungyangSiksaGubun;
	}


	@Column(name="YUNGYANG_SIKSA_PERCENT")
	public Double getYungyangSiksaPercent() {
		return this.yungyangSiksaPercent;
	}

	public void setYungyangSiksaPercent(Double yungyangSiksaPercent) {
		this.yungyangSiksaPercent = yungyangSiksaPercent;
	}


	@Column(name="YUNGYANG_SIKSA_YANG")
	public Double getYungyangSiksaYang() {
		return this.yungyangSiksaYang;
	}

	public void setYungyangSiksaYang(Double yungyangSiksaYang) {
		this.yungyangSiksaYang = yungyangSiksaYang;
	}


	@Column(name="YUNGYANG_SUAEK_YANG")
	public Double getYungyangSuaekYang() {
		return this.yungyangSuaekYang;
	}

	public void setYungyangSuaekYang(Double yungyangSuaekYang) {
		this.yungyangSuaekYang = yungyangSuaekYang;
	}


	@Column(name="YUNGYANG_SUAEK_YN")
	public String getYungyangSuaekYn() {
		return this.yungyangSuaekYn;
	}

	public void setYungyangSuaekYn(String yungyangSuaekYn) {
		this.yungyangSuaekYn = yungyangSuaekYn;
	}

}