package nta.med.core.domain.ifs;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the IFS1011 database table.
 * 
 */
@Entity
@NamedQuery(name="Ifs1011.findAll", query="SELECT i FROM Ifs1011 i")
public class Ifs1011 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String bilGwaCode;
	private String bunho;
	private String chisigInfo;
	private String doctor;
	private String doubtSangFlag;
	private String doubtSangManFlag;
	private double fkinp3010;
	private double fkout1003;
	private double fkoutsang;
	private String gubun1;
	private String gubun2;
	private String gwa;
	private String gwaGubun;
	private String hospCode;
	private String icdCode;
	private Date ifDate;
	private String ifErr;
	private String ifFlag;
	private String ifHospCode;
	private String ifTime;
	private String inOutGubun;
	private String juSangFlag;
	private String manFlag;
	private String mansungFlag;
	private double pkifs1011;
	private String procGubun;
	private String remark;
	private String sangCmCode1;
	private String sangCmCode2;
	private String sangCmCode3;
	private String sangCmCode4;
	private String sangCmCode5;
	private String sangCmCode6;
	private String sangCmCode7;
	private String sangCode1;
	private String sangCode2;
	private String sangCode3;
	private String sangCode4;
	private String sangCode5;
	private String sangCode6;
	private String sangCode7;
	private String sangEndDate;
	private String sangEndSayu;
	private String sangKey;
	private String sangMCode;
	private String sangName;
	private String sangStartDate;
	private String secureFlag;
	private Date sysDate;
	private String sysId;
	private String termNo;
	private String tongGubun1;
	private String tongGubun2;
	private String tongGubun3;
	private String upFlag;
	private Date updDate;
	private String updId;
	private String workCode;
	private String workDate;
	private String workTime;

	public Ifs1011() {
	}


	@Column(name="BIL_GWA_CODE")
	public String getBilGwaCode() {
		return this.bilGwaCode;
	}

	public void setBilGwaCode(String bilGwaCode) {
		this.bilGwaCode = bilGwaCode;
	}


	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}


	@Column(name="CHISIG_INFO")
	public String getChisigInfo() {
		return this.chisigInfo;
	}

	public void setChisigInfo(String chisigInfo) {
		this.chisigInfo = chisigInfo;
	}


	public String getDoctor() {
		return this.doctor;
	}

	public void setDoctor(String doctor) {
		this.doctor = doctor;
	}


	@Column(name="DOUBT_SANG_FLAG")
	public String getDoubtSangFlag() {
		return this.doubtSangFlag;
	}

	public void setDoubtSangFlag(String doubtSangFlag) {
		this.doubtSangFlag = doubtSangFlag;
	}


	@Column(name="DOUBT_SANG_MAN_FLAG")
	public String getDoubtSangManFlag() {
		return this.doubtSangManFlag;
	}

	public void setDoubtSangManFlag(String doubtSangManFlag) {
		this.doubtSangManFlag = doubtSangManFlag;
	}


	public double getFkinp3010() {
		return this.fkinp3010;
	}

	public void setFkinp3010(double fkinp3010) {
		this.fkinp3010 = fkinp3010;
	}


	public double getFkout1003() {
		return this.fkout1003;
	}

	public void setFkout1003(double fkout1003) {
		this.fkout1003 = fkout1003;
	}


	public double getFkoutsang() {
		return this.fkoutsang;
	}

	public void setFkoutsang(double fkoutsang) {
		this.fkoutsang = fkoutsang;
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


	public String getGwa() {
		return this.gwa;
	}

	public void setGwa(String gwa) {
		this.gwa = gwa;
	}


	@Column(name="GWA_GUBUN")
	public String getGwaGubun() {
		return this.gwaGubun;
	}

	public void setGwaGubun(String gwaGubun) {
		this.gwaGubun = gwaGubun;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="ICD_CODE")
	public String getIcdCode() {
		return this.icdCode;
	}

	public void setIcdCode(String icdCode) {
		this.icdCode = icdCode;
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


	@Column(name="IF_HOSP_CODE")
	public String getIfHospCode() {
		return this.ifHospCode;
	}

	public void setIfHospCode(String ifHospCode) {
		this.ifHospCode = ifHospCode;
	}


	@Column(name="IF_TIME")
	public String getIfTime() {
		return this.ifTime;
	}

	public void setIfTime(String ifTime) {
		this.ifTime = ifTime;
	}


	@Column(name="IN_OUT_GUBUN")
	public String getInOutGubun() {
		return this.inOutGubun;
	}

	public void setInOutGubun(String inOutGubun) {
		this.inOutGubun = inOutGubun;
	}


	@Column(name="JU_SANG_FLAG")
	public String getJuSangFlag() {
		return this.juSangFlag;
	}

	public void setJuSangFlag(String juSangFlag) {
		this.juSangFlag = juSangFlag;
	}


	@Column(name="MAN_FLAG")
	public String getManFlag() {
		return this.manFlag;
	}

	public void setManFlag(String manFlag) {
		this.manFlag = manFlag;
	}


	@Column(name="MANSUNG_FLAG")
	public String getMansungFlag() {
		return this.mansungFlag;
	}

	public void setMansungFlag(String mansungFlag) {
		this.mansungFlag = mansungFlag;
	}


	public double getPkifs1011() {
		return this.pkifs1011;
	}

	public void setPkifs1011(double pkifs1011) {
		this.pkifs1011 = pkifs1011;
	}


	@Column(name="PROC_GUBUN")
	public String getProcGubun() {
		return this.procGubun;
	}

	public void setProcGubun(String procGubun) {
		this.procGubun = procGubun;
	}


	public String getRemark() {
		return this.remark;
	}

	public void setRemark(String remark) {
		this.remark = remark;
	}


	@Column(name="SANG_CM_CODE1")
	public String getSangCmCode1() {
		return this.sangCmCode1;
	}

	public void setSangCmCode1(String sangCmCode1) {
		this.sangCmCode1 = sangCmCode1;
	}


	@Column(name="SANG_CM_CODE2")
	public String getSangCmCode2() {
		return this.sangCmCode2;
	}

	public void setSangCmCode2(String sangCmCode2) {
		this.sangCmCode2 = sangCmCode2;
	}


	@Column(name="SANG_CM_CODE3")
	public String getSangCmCode3() {
		return this.sangCmCode3;
	}

	public void setSangCmCode3(String sangCmCode3) {
		this.sangCmCode3 = sangCmCode3;
	}


	@Column(name="SANG_CM_CODE4")
	public String getSangCmCode4() {
		return this.sangCmCode4;
	}

	public void setSangCmCode4(String sangCmCode4) {
		this.sangCmCode4 = sangCmCode4;
	}


	@Column(name="SANG_CM_CODE5")
	public String getSangCmCode5() {
		return this.sangCmCode5;
	}

	public void setSangCmCode5(String sangCmCode5) {
		this.sangCmCode5 = sangCmCode5;
	}


	@Column(name="SANG_CM_CODE6")
	public String getSangCmCode6() {
		return this.sangCmCode6;
	}

	public void setSangCmCode6(String sangCmCode6) {
		this.sangCmCode6 = sangCmCode6;
	}


	@Column(name="SANG_CM_CODE7")
	public String getSangCmCode7() {
		return this.sangCmCode7;
	}

	public void setSangCmCode7(String sangCmCode7) {
		this.sangCmCode7 = sangCmCode7;
	}


	@Column(name="SANG_CODE1")
	public String getSangCode1() {
		return this.sangCode1;
	}

	public void setSangCode1(String sangCode1) {
		this.sangCode1 = sangCode1;
	}


	@Column(name="SANG_CODE2")
	public String getSangCode2() {
		return this.sangCode2;
	}

	public void setSangCode2(String sangCode2) {
		this.sangCode2 = sangCode2;
	}


	@Column(name="SANG_CODE3")
	public String getSangCode3() {
		return this.sangCode3;
	}

	public void setSangCode3(String sangCode3) {
		this.sangCode3 = sangCode3;
	}


	@Column(name="SANG_CODE4")
	public String getSangCode4() {
		return this.sangCode4;
	}

	public void setSangCode4(String sangCode4) {
		this.sangCode4 = sangCode4;
	}


	@Column(name="SANG_CODE5")
	public String getSangCode5() {
		return this.sangCode5;
	}

	public void setSangCode5(String sangCode5) {
		this.sangCode5 = sangCode5;
	}


	@Column(name="SANG_CODE6")
	public String getSangCode6() {
		return this.sangCode6;
	}

	public void setSangCode6(String sangCode6) {
		this.sangCode6 = sangCode6;
	}


	@Column(name="SANG_CODE7")
	public String getSangCode7() {
		return this.sangCode7;
	}

	public void setSangCode7(String sangCode7) {
		this.sangCode7 = sangCode7;
	}


	@Column(name="SANG_END_DATE")
	public String getSangEndDate() {
		return this.sangEndDate;
	}

	public void setSangEndDate(String sangEndDate) {
		this.sangEndDate = sangEndDate;
	}


	@Column(name="SANG_END_SAYU")
	public String getSangEndSayu() {
		return this.sangEndSayu;
	}

	public void setSangEndSayu(String sangEndSayu) {
		this.sangEndSayu = sangEndSayu;
	}


	@Column(name="SANG_KEY")
	public String getSangKey() {
		return this.sangKey;
	}

	public void setSangKey(String sangKey) {
		this.sangKey = sangKey;
	}


	@Column(name="SANG_M_CODE")
	public String getSangMCode() {
		return this.sangMCode;
	}

	public void setSangMCode(String sangMCode) {
		this.sangMCode = sangMCode;
	}


	@Column(name="SANG_NAME")
	public String getSangName() {
		return this.sangName;
	}

	public void setSangName(String sangName) {
		this.sangName = sangName;
	}


	@Column(name="SANG_START_DATE")
	public String getSangStartDate() {
		return this.sangStartDate;
	}

	public void setSangStartDate(String sangStartDate) {
		this.sangStartDate = sangStartDate;
	}


	@Column(name="SECURE_FLAG")
	public String getSecureFlag() {
		return this.secureFlag;
	}

	public void setSecureFlag(String secureFlag) {
		this.secureFlag = secureFlag;
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


	@Column(name="TERM_NO")
	public String getTermNo() {
		return this.termNo;
	}

	public void setTermNo(String termNo) {
		this.termNo = termNo;
	}


	@Column(name="TONG_GUBUN1")
	public String getTongGubun1() {
		return this.tongGubun1;
	}

	public void setTongGubun1(String tongGubun1) {
		this.tongGubun1 = tongGubun1;
	}


	@Column(name="TONG_GUBUN2")
	public String getTongGubun2() {
		return this.tongGubun2;
	}

	public void setTongGubun2(String tongGubun2) {
		this.tongGubun2 = tongGubun2;
	}


	@Column(name="TONG_GUBUN3")
	public String getTongGubun3() {
		return this.tongGubun3;
	}

	public void setTongGubun3(String tongGubun3) {
		this.tongGubun3 = tongGubun3;
	}


	@Column(name="UP_FLAG")
	public String getUpFlag() {
		return this.upFlag;
	}

	public void setUpFlag(String upFlag) {
		this.upFlag = upFlag;
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


	@Column(name="WORK_CODE")
	public String getWorkCode() {
		return this.workCode;
	}

	public void setWorkCode(String workCode) {
		this.workCode = workCode;
	}


	@Column(name="WORK_DATE")
	public String getWorkDate() {
		return this.workDate;
	}

	public void setWorkDate(String workDate) {
		this.workDate = workDate;
	}


	@Column(name="WORK_TIME")
	public String getWorkTime() {
		return this.workTime;
	}

	public void setWorkTime(String workTime) {
		this.workTime = workTime;
	}

}