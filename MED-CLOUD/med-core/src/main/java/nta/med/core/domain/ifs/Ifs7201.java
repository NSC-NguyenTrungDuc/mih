package nta.med.core.domain.ifs;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the IFS7201 database table.
 * 
 */
@Entity
@NamedQuery(name="Ifs7201.findAll", query="SELECT i FROM Ifs7201 i")
public class Ifs7201 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String day;
	private String gubun1;
	private String gubun2;
	private String hct;
	private String hctFlag;
	private String hgb;
	private String hgbFlag;
	private String hospCode;
	private Date ifDate;
	private String ifErr;
	private String ifFlag;
	private String ifTime;
	private String mch;
	private String mchFlag;
	private String mchc;
	private String mchcFlag;
	private String mcv;
	private String mcvFlag;
	private String month;
	private String mpv;
	private String mpvFlag;
	private String pLcr;
	private String pLcrFlag;
	private String pdw;
	private String pdwFlag;
	private double pkifs7201;
	private String plt;
	private String pltFlag;
	private String rbc;
	private String rbcFlag;
	private String rdwGubun;
	private String rdwSdcv;
	private String rdwSdcvFlag;
	private String resultFlag;
	private String resultMode;
	private String specGubun;
	private String specimenSer;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;
	private String wLcc;
	private String wLccGlag;
	private String wLcr;
	private String wLcrFlag;
	private String wMcc;
	private String wMccFlag;
	private String wMcr;
	private String wNcrFlag;
	private String wScc;
	private String wSccFlag;
	private String wScr;
	private String wScrFlag;
	private String wbc;
	private String wbcFlag;
	private String year;

	public Ifs7201() {
	}


	public String getDay() {
		return this.day;
	}

	public void setDay(String day) {
		this.day = day;
	}


	public String getGubun1() {
		return this.gubun1;
	}

	public void setGubun1(String gubun1) {
		this.gubun1 = gubun1;
	}


	public String getGubun2() {
		return this.gubun2;
	}

	public void setGubun2(String gubun2) {
		this.gubun2 = gubun2;
	}


	public String getHct() {
		return this.hct;
	}

	public void setHct(String hct) {
		this.hct = hct;
	}


	@Column(name="HCT_FLAG")
	public String getHctFlag() {
		return this.hctFlag;
	}

	public void setHctFlag(String hctFlag) {
		this.hctFlag = hctFlag;
	}


	public String getHgb() {
		return this.hgb;
	}

	public void setHgb(String hgb) {
		this.hgb = hgb;
	}


	@Column(name="HGB_FLAG")
	public String getHgbFlag() {
		return this.hgbFlag;
	}

	public void setHgbFlag(String hgbFlag) {
		this.hgbFlag = hgbFlag;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="IF_DATE")
	public Date getIfDate() {
		return this.ifDate;
	}

	public void setIfDate(Date ifDate) {
		this.ifDate = ifDate;
	}


	@Column(name="IF_ERR")
	public String getIfErr() {
		return this.ifErr;
	}

	public void setIfErr(String ifErr) {
		this.ifErr = ifErr;
	}


	@Column(name="IF_FLAG")
	public String getIfFlag() {
		return this.ifFlag;
	}

	public void setIfFlag(String ifFlag) {
		this.ifFlag = ifFlag;
	}


	@Column(name="IF_TIME")
	public String getIfTime() {
		return this.ifTime;
	}

	public void setIfTime(String ifTime) {
		this.ifTime = ifTime;
	}


	public String getMch() {
		return this.mch;
	}

	public void setMch(String mch) {
		this.mch = mch;
	}


	@Column(name="MCH_FLAG")
	public String getMchFlag() {
		return this.mchFlag;
	}

	public void setMchFlag(String mchFlag) {
		this.mchFlag = mchFlag;
	}


	public String getMchc() {
		return this.mchc;
	}

	public void setMchc(String mchc) {
		this.mchc = mchc;
	}


	@Column(name="MCHC_FLAG")
	public String getMchcFlag() {
		return this.mchcFlag;
	}

	public void setMchcFlag(String mchcFlag) {
		this.mchcFlag = mchcFlag;
	}


	public String getMcv() {
		return this.mcv;
	}

	public void setMcv(String mcv) {
		this.mcv = mcv;
	}


	@Column(name="MCV_FLAG")
	public String getMcvFlag() {
		return this.mcvFlag;
	}

	public void setMcvFlag(String mcvFlag) {
		this.mcvFlag = mcvFlag;
	}


	public String getMonth() {
		return this.month;
	}

	public void setMonth(String month) {
		this.month = month;
	}


	public String getMpv() {
		return this.mpv;
	}

	public void setMpv(String mpv) {
		this.mpv = mpv;
	}


	@Column(name="MPV_FLAG")
	public String getMpvFlag() {
		return this.mpvFlag;
	}

	public void setMpvFlag(String mpvFlag) {
		this.mpvFlag = mpvFlag;
	}


	@Column(name="P_LCR")
	public String getPLcr() {
		return this.pLcr;
	}

	public void setPLcr(String pLcr) {
		this.pLcr = pLcr;
	}


	@Column(name="P_LCR_FLAG")
	public String getPLcrFlag() {
		return this.pLcrFlag;
	}

	public void setPLcrFlag(String pLcrFlag) {
		this.pLcrFlag = pLcrFlag;
	}


	public String getPdw() {
		return this.pdw;
	}

	public void setPdw(String pdw) {
		this.pdw = pdw;
	}


	@Column(name="PDW_FLAG")
	public String getPdwFlag() {
		return this.pdwFlag;
	}

	public void setPdwFlag(String pdwFlag) {
		this.pdwFlag = pdwFlag;
	}


	public double getPkifs7201() {
		return this.pkifs7201;
	}

	public void setPkifs7201(double pkifs7201) {
		this.pkifs7201 = pkifs7201;
	}


	public String getPlt() {
		return this.plt;
	}

	public void setPlt(String plt) {
		this.plt = plt;
	}


	@Column(name="PLT_FLAG")
	public String getPltFlag() {
		return this.pltFlag;
	}

	public void setPltFlag(String pltFlag) {
		this.pltFlag = pltFlag;
	}


	public String getRbc() {
		return this.rbc;
	}

	public void setRbc(String rbc) {
		this.rbc = rbc;
	}


	@Column(name="RBC_FLAG")
	public String getRbcFlag() {
		return this.rbcFlag;
	}

	public void setRbcFlag(String rbcFlag) {
		this.rbcFlag = rbcFlag;
	}


	@Column(name="RDW_GUBUN")
	public String getRdwGubun() {
		return this.rdwGubun;
	}

	public void setRdwGubun(String rdwGubun) {
		this.rdwGubun = rdwGubun;
	}


	@Column(name="RDW_SDCV")
	public String getRdwSdcv() {
		return this.rdwSdcv;
	}

	public void setRdwSdcv(String rdwSdcv) {
		this.rdwSdcv = rdwSdcv;
	}


	@Column(name="RDW_SDCV_FLAG")
	public String getRdwSdcvFlag() {
		return this.rdwSdcvFlag;
	}

	public void setRdwSdcvFlag(String rdwSdcvFlag) {
		this.rdwSdcvFlag = rdwSdcvFlag;
	}


	@Column(name="RESULT_FLAG")
	public String getResultFlag() {
		return this.resultFlag;
	}

	public void setResultFlag(String resultFlag) {
		this.resultFlag = resultFlag;
	}


	@Column(name="RESULT_MODE")
	public String getResultMode() {
		return this.resultMode;
	}

	public void setResultMode(String resultMode) {
		this.resultMode = resultMode;
	}


	@Column(name="SPEC_GUBUN")
	public String getSpecGubun() {
		return this.specGubun;
	}

	public void setSpecGubun(String specGubun) {
		this.specGubun = specGubun;
	}


	@Column(name="SPECIMEN_SER")
	public String getSpecimenSer() {
		return this.specimenSer;
	}

	public void setSpecimenSer(String specimenSer) {
		this.specimenSer = specimenSer;
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


	@Column(name="W_LCC")
	public String getWLcc() {
		return this.wLcc;
	}

	public void setWLcc(String wLcc) {
		this.wLcc = wLcc;
	}


	@Column(name="W_LCC_GLAG")
	public String getWLccGlag() {
		return this.wLccGlag;
	}

	public void setWLccGlag(String wLccGlag) {
		this.wLccGlag = wLccGlag;
	}


	@Column(name="W_LCR")
	public String getWLcr() {
		return this.wLcr;
	}

	public void setWLcr(String wLcr) {
		this.wLcr = wLcr;
	}


	@Column(name="W_LCR_FLAG")
	public String getWLcrFlag() {
		return this.wLcrFlag;
	}

	public void setWLcrFlag(String wLcrFlag) {
		this.wLcrFlag = wLcrFlag;
	}


	@Column(name="W_MCC")
	public String getWMcc() {
		return this.wMcc;
	}

	public void setWMcc(String wMcc) {
		this.wMcc = wMcc;
	}


	@Column(name="W_MCC_FLAG")
	public String getWMccFlag() {
		return this.wMccFlag;
	}

	public void setWMccFlag(String wMccFlag) {
		this.wMccFlag = wMccFlag;
	}


	@Column(name="W_MCR")
	public String getWMcr() {
		return this.wMcr;
	}

	public void setWMcr(String wMcr) {
		this.wMcr = wMcr;
	}


	@Column(name="W_NCR_FLAG")
	public String getWNcrFlag() {
		return this.wNcrFlag;
	}

	public void setWNcrFlag(String wNcrFlag) {
		this.wNcrFlag = wNcrFlag;
	}


	@Column(name="W_SCC")
	public String getWScc() {
		return this.wScc;
	}

	public void setWScc(String wScc) {
		this.wScc = wScc;
	}


	@Column(name="W_SCC_FLAG")
	public String getWSccFlag() {
		return this.wSccFlag;
	}

	public void setWSccFlag(String wSccFlag) {
		this.wSccFlag = wSccFlag;
	}


	@Column(name="W_SCR")
	public String getWScr() {
		return this.wScr;
	}

	public void setWScr(String wScr) {
		this.wScr = wScr;
	}


	@Column(name="W_SCR_FLAG")
	public String getWScrFlag() {
		return this.wScrFlag;
	}

	public void setWScrFlag(String wScrFlag) {
		this.wScrFlag = wScrFlag;
	}


	public String getWbc() {
		return this.wbc;
	}

	public void setWbc(String wbc) {
		this.wbc = wbc;
	}


	@Column(name="WBC_FLAG")
	public String getWbcFlag() {
		return this.wbcFlag;
	}

	public void setWbcFlag(String wbcFlag) {
		this.wbcFlag = wbcFlag;
	}


	public String getYear() {
		return this.year;
	}

	public void setYear(String year) {
		this.year = year;
	}

}