package nta.med.core.domain.inj;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the INJ1002 database table.
 * 
 */
@Entity
@NamedQuery(name="Inj1002.findAll", query="SELECT i FROM Inj1002 i")
@Table(name = "INJ1002")
public class Inj1002 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private Date actingDate;
	private String actingFlag;
	private String actingJangso;
	private String actingTime;
	private String antiCancerYn;
	private String ast;
	private String chasuCode;
	private String chungguBuseo;
	private Date chungguDate;
	private String chungguGubun;
	private Double chungguSeq;
	private String companyCode;
	private Double csResult;
	private String dcYn;
	private Double drgBunho;
	private Double fkinj1001;
	private String fkout1001;
	private Double groupSer;
	private String gwa;
	private String hangmogCode;
	private String hospCode;
	private String inv4004ChulgoBuseo;
	private Date inv4004ChulgoDate;
	private Double inv4004ChulgoSeq;
	private String inv4004ChulgoType;
	private Date jubsuDate;
	private String jujongja;
	private String jusaBuui;
	private Double jusaTongCnt;
	private String jusaYn;
	private String lotNo;
	private Date magamDate;
	private String magamId;
	private String magamJangso;
	private Double magamSer;
	private String magamTime;
	private String mixGroup;
	private String otherBuseoYn;
	private Double pkinj1002;
	private Double pwResult;
	private Date reserDate;
	private String reserTime;
	private Double rpBunho;
	private Double seq;
	private String silsiRemark;
	private Double subulSuryang;
	private Date sunabDate;
	private Double sunabSuryang;
	private Date sysDate;
	private String sysId;
	private String tonggyeCode;
	private Date updDate;
	private String updId;

	public Inj1002() {
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="ACTING_DATE")
	public Date getActingDate() {
		return this.actingDate;
	}

	public void setActingDate(Date actingDate) {
		this.actingDate = actingDate;
	}


	@Column(name="ACTING_FLAG")
	public String getActingFlag() {
		return this.actingFlag;
	}

	public void setActingFlag(String actingFlag) {
		this.actingFlag = actingFlag;
	}


	@Column(name="ACTING_JANGSO")
	public String getActingJangso() {
		return this.actingJangso;
	}

	public void setActingJangso(String actingJangso) {
		this.actingJangso = actingJangso;
	}


	@Column(name="ACTING_TIME")
	public String getActingTime() {
		return this.actingTime;
	}

	public void setActingTime(String actingTime) {
		this.actingTime = actingTime;
	}


	@Column(name="ANTI_CANCER_YN")
	public String getAntiCancerYn() {
		return this.antiCancerYn;
	}

	public void setAntiCancerYn(String antiCancerYn) {
		this.antiCancerYn = antiCancerYn;
	}


	public String getAst() {
		return this.ast;
	}

	public void setAst(String ast) {
		this.ast = ast;
	}


	@Column(name="CHASU_CODE")
	public String getChasuCode() {
		return this.chasuCode;
	}

	public void setChasuCode(String chasuCode) {
		this.chasuCode = chasuCode;
	}


	@Column(name="CHUNGGU_BUSEO")
	public String getChungguBuseo() {
		return this.chungguBuseo;
	}

	public void setChungguBuseo(String chungguBuseo) {
		this.chungguBuseo = chungguBuseo;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="CHUNGGU_DATE")
	public Date getChungguDate() {
		return this.chungguDate;
	}

	public void setChungguDate(Date chungguDate) {
		this.chungguDate = chungguDate;
	}


	@Column(name="CHUNGGU_GUBUN")
	public String getChungguGubun() {
		return this.chungguGubun;
	}

	public void setChungguGubun(String chungguGubun) {
		this.chungguGubun = chungguGubun;
	}


	@Column(name="CHUNGGU_SEQ")
	public Double getChungguSeq() {
		return this.chungguSeq;
	}

	public void setChungguSeq(Double chungguSeq) {
		this.chungguSeq = chungguSeq;
	}


	@Column(name="COMPANY_CODE")
	public String getCompanyCode() {
		return this.companyCode;
	}

	public void setCompanyCode(String companyCode) {
		this.companyCode = companyCode;
	}


	@Column(name="CS_RESULT")
	public Double getCsResult() {
		return this.csResult;
	}

	public void setCsResult(Double csResult) {
		this.csResult = csResult;
	}


	@Column(name="DC_YN")
	public String getDcYn() {
		return this.dcYn;
	}

	public void setDcYn(String dcYn) {
		this.dcYn = dcYn;
	}


	@Column(name="DRG_BUNHO")
	public Double getDrgBunho() {
		return this.drgBunho;
	}

	public void setDrgBunho(Double drgBunho) {
		this.drgBunho = drgBunho;
	}


	public Double getFkinj1001() {
		return this.fkinj1001;
	}

	public void setFkinj1001(Double fkinj1001) {
		this.fkinj1001 = fkinj1001;
	}


	public String getFkout1001() {
		return this.fkout1001;
	}

	public void setFkout1001(String fkout1001) {
		this.fkout1001 = fkout1001;
	}


	@Column(name="GROUP_SER")
	public Double getGroupSer() {
		return this.groupSer;
	}

	public void setGroupSer(Double groupSer) {
		this.groupSer = groupSer;
	}


	public String getGwa() {
		return this.gwa;
	}

	public void setGwa(String gwa) {
		this.gwa = gwa;
	}


	@Column(name="HANGMOG_CODE")
	public String getHangmogCode() {
		return this.hangmogCode;
	}

	public void setHangmogCode(String hangmogCode) {
		this.hangmogCode = hangmogCode;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="INV4004_CHULGO_BUSEO")
	public String getInv4004ChulgoBuseo() {
		return this.inv4004ChulgoBuseo;
	}

	public void setInv4004ChulgoBuseo(String inv4004ChulgoBuseo) {
		this.inv4004ChulgoBuseo = inv4004ChulgoBuseo;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="INV4004_CHULGO_DATE")
	public Date getInv4004ChulgoDate() {
		return this.inv4004ChulgoDate;
	}

	public void setInv4004ChulgoDate(Date inv4004ChulgoDate) {
		this.inv4004ChulgoDate = inv4004ChulgoDate;
	}


	@Column(name="INV4004_CHULGO_SEQ")
	public Double getInv4004ChulgoSeq() {
		return this.inv4004ChulgoSeq;
	}

	public void setInv4004ChulgoSeq(Double inv4004ChulgoSeq) {
		this.inv4004ChulgoSeq = inv4004ChulgoSeq;
	}


	@Column(name="INV4004_CHULGO_TYPE")
	public String getInv4004ChulgoType() {
		return this.inv4004ChulgoType;
	}

	public void setInv4004ChulgoType(String inv4004ChulgoType) {
		this.inv4004ChulgoType = inv4004ChulgoType;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="JUBSU_DATE")
	public Date getJubsuDate() {
		return this.jubsuDate;
	}

	public void setJubsuDate(Date jubsuDate) {
		this.jubsuDate = jubsuDate;
	}


	public String getJujongja() {
		return this.jujongja;
	}

	public void setJujongja(String jujongja) {
		this.jujongja = jujongja;
	}


	@Column(name="JUSA_BUUI")
	public String getJusaBuui() {
		return this.jusaBuui;
	}

	public void setJusaBuui(String jusaBuui) {
		this.jusaBuui = jusaBuui;
	}


	@Column(name="JUSA_TONG_CNT")
	public Double getJusaTongCnt() {
		return this.jusaTongCnt;
	}

	public void setJusaTongCnt(Double jusaTongCnt) {
		this.jusaTongCnt = jusaTongCnt;
	}


	@Column(name="JUSA_YN")
	public String getJusaYn() {
		return this.jusaYn;
	}

	public void setJusaYn(String jusaYn) {
		this.jusaYn = jusaYn;
	}


	@Column(name="LOT_NO")
	public String getLotNo() {
		return this.lotNo;
	}

	public void setLotNo(String lotNo) {
		this.lotNo = lotNo;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="MAGAM_DATE")
	public Date getMagamDate() {
		return this.magamDate;
	}

	public void setMagamDate(Date magamDate) {
		this.magamDate = magamDate;
	}


	@Column(name="MAGAM_ID")
	public String getMagamId() {
		return this.magamId;
	}

	public void setMagamId(String magamId) {
		this.magamId = magamId;
	}


	@Column(name="MAGAM_JANGSO")
	public String getMagamJangso() {
		return this.magamJangso;
	}

	public void setMagamJangso(String magamJangso) {
		this.magamJangso = magamJangso;
	}


	@Column(name="MAGAM_SER")
	public Double getMagamSer() {
		return this.magamSer;
	}

	public void setMagamSer(Double magamSer) {
		this.magamSer = magamSer;
	}


	@Column(name="MAGAM_TIME")
	public String getMagamTime() {
		return this.magamTime;
	}

	public void setMagamTime(String magamTime) {
		this.magamTime = magamTime;
	}


	@Column(name="MIX_GROUP")
	public String getMixGroup() {
		return this.mixGroup;
	}

	public void setMixGroup(String mixGroup) {
		this.mixGroup = mixGroup;
	}


	@Column(name="OTHER_BUSEO_YN")
	public String getOtherBuseoYn() {
		return this.otherBuseoYn;
	}

	public void setOtherBuseoYn(String otherBuseoYn) {
		this.otherBuseoYn = otherBuseoYn;
	}


	public Double getPkinj1002() {
		return this.pkinj1002;
	}

	public void setPkinj1002(Double pkinj1002) {
		this.pkinj1002 = pkinj1002;
	}


	@Column(name="PW_RESULT")
	public Double getPwResult() {
		return this.pwResult;
	}

	public void setPwResult(Double pwResult) {
		this.pwResult = pwResult;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="RESER_DATE")
	public Date getReserDate() {
		return this.reserDate;
	}

	public void setReserDate(Date reserDate) {
		this.reserDate = reserDate;
	}


	@Column(name="RESER_TIME")
	public String getReserTime() {
		return this.reserTime;
	}

	public void setReserTime(String reserTime) {
		this.reserTime = reserTime;
	}


	@Column(name="RP_BUNHO")
	public Double getRpBunho() {
		return this.rpBunho;
	}

	public void setRpBunho(Double rpBunho) {
		this.rpBunho = rpBunho;
	}


	public Double getSeq() {
		return this.seq;
	}

	public void setSeq(Double seq) {
		this.seq = seq;
	}


	@Column(name="SILSI_REMARK")
	public String getSilsiRemark() {
		return this.silsiRemark;
	}

	public void setSilsiRemark(String silsiRemark) {
		this.silsiRemark = silsiRemark;
	}


	@Column(name="SUBUL_SURYANG")
	public Double getSubulSuryang() {
		return this.subulSuryang;
	}

	public void setSubulSuryang(Double subulSuryang) {
		this.subulSuryang = subulSuryang;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="SUNAB_DATE")
	public Date getSunabDate() {
		return this.sunabDate;
	}

	public void setSunabDate(Date sunabDate) {
		this.sunabDate = sunabDate;
	}


	@Column(name="SUNAB_SURYANG")
	public Double getSunabSuryang() {
		return this.sunabSuryang;
	}

	public void setSunabSuryang(Double sunabSuryang) {
		this.sunabSuryang = sunabSuryang;
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


	@Column(name="TONGGYE_CODE")
	public String getTonggyeCode() {
		return this.tonggyeCode;
	}

	public void setTonggyeCode(String tonggyeCode) {
		this.tonggyeCode = tonggyeCode;
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