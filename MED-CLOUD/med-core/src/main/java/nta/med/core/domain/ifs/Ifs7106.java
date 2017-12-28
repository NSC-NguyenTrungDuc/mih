package nta.med.core.domain.ifs;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the IFS7106 database table.
 * 
 */
@Entity
@NamedQuery(name="Ifs7106.findAll", query="SELECT i FROM Ifs7106 i")
@Table(name="IFS7106")
public class Ifs7106 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String bogyongStartDate;
	private String danui;
	private String danuiName;
	private String drgBunho;
	private String drgCmtCnt;
	private String drgCode;
	private String drgCodeHu;
	private String drgCodeName;
	private String drgCodeNameKana;
	private String drgGubun;
	private String drgPackYn;
	private String drgSeq;
	private String drgType;
	private String endFlag;
	private double fkifs7101;
	private String hospCode;
	private String mstInfo1;
	private String mstInfo2;
	private String mstInfo3;
	private String mstInfo4;
	private String mstInfo5;
	private String mstInfo6;
	private String powderYn;
	private String recGubun;
	private String remark;
	private double seqRp;
	private double seqRpDrg;
	private String suryang;
	private Date sysDate;
	private String sysId;
	private String unbalance1;
	private String unbalance2;
	private String unbalance3;
	private String unbalance4;
	private String unbalance5;
	private String unbalanceX;
	private String unbalanceYn;
	private Date updDate;
	private String updId;

	public Ifs7106() {
	}


	@Column(name="BOGYONG_START_DATE")
	public String getBogyongStartDate() {
		return this.bogyongStartDate;
	}

	public void setBogyongStartDate(String bogyongStartDate) {
		this.bogyongStartDate = bogyongStartDate;
	}


	public String getDanui() {
		return this.danui;
	}

	public void setDanui(String danui) {
		this.danui = danui;
	}


	@Column(name="DANUI_NAME")
	public String getDanuiName() {
		return this.danuiName;
	}

	public void setDanuiName(String danuiName) {
		this.danuiName = danuiName;
	}


	@Column(name="DRG_BUNHO")
	public String getDrgBunho() {
		return this.drgBunho;
	}

	public void setDrgBunho(String drgBunho) {
		this.drgBunho = drgBunho;
	}


	@Column(name="DRG_CMT_CNT")
	public String getDrgCmtCnt() {
		return this.drgCmtCnt;
	}

	public void setDrgCmtCnt(String drgCmtCnt) {
		this.drgCmtCnt = drgCmtCnt;
	}


	@Column(name="DRG_CODE")
	public String getDrgCode() {
		return this.drgCode;
	}

	public void setDrgCode(String drgCode) {
		this.drgCode = drgCode;
	}


	@Column(name="DRG_CODE_HU")
	public String getDrgCodeHu() {
		return this.drgCodeHu;
	}

	public void setDrgCodeHu(String drgCodeHu) {
		this.drgCodeHu = drgCodeHu;
	}


	@Column(name="DRG_CODE_NAME")
	public String getDrgCodeName() {
		return this.drgCodeName;
	}

	public void setDrgCodeName(String drgCodeName) {
		this.drgCodeName = drgCodeName;
	}


	@Column(name="DRG_CODE_NAME_KANA")
	public String getDrgCodeNameKana() {
		return this.drgCodeNameKana;
	}

	public void setDrgCodeNameKana(String drgCodeNameKana) {
		this.drgCodeNameKana = drgCodeNameKana;
	}


	@Column(name="DRG_GUBUN")
	public String getDrgGubun() {
		return this.drgGubun;
	}

	public void setDrgGubun(String drgGubun) {
		this.drgGubun = drgGubun;
	}


	@Column(name="DRG_PACK_YN")
	public String getDrgPackYn() {
		return this.drgPackYn;
	}

	public void setDrgPackYn(String drgPackYn) {
		this.drgPackYn = drgPackYn;
	}


	@Column(name="DRG_SEQ")
	public String getDrgSeq() {
		return this.drgSeq;
	}

	public void setDrgSeq(String drgSeq) {
		this.drgSeq = drgSeq;
	}


	@Column(name="DRG_TYPE")
	public String getDrgType() {
		return this.drgType;
	}

	public void setDrgType(String drgType) {
		this.drgType = drgType;
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


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="MST_INFO_1")
	public String getMstInfo1() {
		return this.mstInfo1;
	}

	public void setMstInfo1(String mstInfo1) {
		this.mstInfo1 = mstInfo1;
	}


	@Column(name="MST_INFO_2")
	public String getMstInfo2() {
		return this.mstInfo2;
	}

	public void setMstInfo2(String mstInfo2) {
		this.mstInfo2 = mstInfo2;
	}


	@Column(name="MST_INFO_3")
	public String getMstInfo3() {
		return this.mstInfo3;
	}

	public void setMstInfo3(String mstInfo3) {
		this.mstInfo3 = mstInfo3;
	}


	@Column(name="MST_INFO_4")
	public String getMstInfo4() {
		return this.mstInfo4;
	}

	public void setMstInfo4(String mstInfo4) {
		this.mstInfo4 = mstInfo4;
	}


	@Column(name="MST_INFO_5")
	public String getMstInfo5() {
		return this.mstInfo5;
	}

	public void setMstInfo5(String mstInfo5) {
		this.mstInfo5 = mstInfo5;
	}


	@Column(name="MST_INFO_6")
	public String getMstInfo6() {
		return this.mstInfo6;
	}

	public void setMstInfo6(String mstInfo6) {
		this.mstInfo6 = mstInfo6;
	}


	@Column(name="POWDER_YN")
	public String getPowderYn() {
		return this.powderYn;
	}

	public void setPowderYn(String powderYn) {
		this.powderYn = powderYn;
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


	@Column(name="SEQ_RP")
	public double getSeqRp() {
		return this.seqRp;
	}

	public void setSeqRp(double seqRp) {
		this.seqRp = seqRp;
	}


	@Column(name="SEQ_RP_DRG")
	public double getSeqRpDrg() {
		return this.seqRpDrg;
	}

	public void setSeqRpDrg(double seqRpDrg) {
		this.seqRpDrg = seqRpDrg;
	}


	public String getSuryang() {
		return this.suryang;
	}

	public void setSuryang(String suryang) {
		this.suryang = suryang;
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


	@Column(name="UNBALANCE_1")
	public String getUnbalance1() {
		return this.unbalance1;
	}

	public void setUnbalance1(String unbalance1) {
		this.unbalance1 = unbalance1;
	}


	@Column(name="UNBALANCE_2")
	public String getUnbalance2() {
		return this.unbalance2;
	}

	public void setUnbalance2(String unbalance2) {
		this.unbalance2 = unbalance2;
	}


	@Column(name="UNBALANCE_3")
	public String getUnbalance3() {
		return this.unbalance3;
	}

	public void setUnbalance3(String unbalance3) {
		this.unbalance3 = unbalance3;
	}


	@Column(name="UNBALANCE_4")
	public String getUnbalance4() {
		return this.unbalance4;
	}

	public void setUnbalance4(String unbalance4) {
		this.unbalance4 = unbalance4;
	}


	@Column(name="UNBALANCE_5")
	public String getUnbalance5() {
		return this.unbalance5;
	}

	public void setUnbalance5(String unbalance5) {
		this.unbalance5 = unbalance5;
	}


	@Column(name="UNBALANCE_X")
	public String getUnbalanceX() {
		return this.unbalanceX;
	}

	public void setUnbalanceX(String unbalanceX) {
		this.unbalanceX = unbalanceX;
	}


	@Column(name="UNBALANCE_YN")
	public String getUnbalanceYn() {
		return this.unbalanceYn;
	}

	public void setUnbalanceYn(String unbalanceYn) {
		this.unbalanceYn = unbalanceYn;
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