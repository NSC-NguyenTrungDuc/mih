package nta.med.core.domain.ocs;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;


/**
 * The persistent class for the OCS0303 database table.
 * 
 */
@Entity
@Table(name="OCS0303")
public class Ocs0303 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private Double amt;
	private String bogyongCode;
	private Double bomSourceKey;
	private String dangilGumsaOrderYn;
	private String dangilGumsaResultYn;
	private String drgPackYn;
	private Double dv;
	private Double dv1;
	private Double dv2;
	private Double dv3;
	private Double dv4;
	private Double dv5;
	private Double dv6;
	private Double dv7;
	private Double dv8;
	private String dvTime;
	private String emergency;
	private Double fkocs0300Seq;
	private String generalDispYn;
	private Double groupSer;
	private String hangmogCode;
	private String hangmogName;
	private String hospCode;
	private String hubalChangeYn;
	private String inputTab;
	private String jundalPartInp;
	private String jundalPartOut;
	private String jundalTableInp;
	private String jundalTableOut;
	private String jusa;
	private String jusaSpdGubun;
	private String memb;
	private String membGubun;
	private String mixGroup;
	private String movePartInp;
	private String movePartOut;
	private String muhyo;
	private Double nalsu;
	private String ndayYn;
	private String nurseRemark;
	private String ordDanui;
	private String orderGubun;
	private String orderRemark;
	private String pay;
	private String pharmacy;
	private Double pkocs0303;
	private String portableYn;
	private String powderYn;
	private String prnYn;
	private Double seq;
	private String specimenCode;
	private Double suryang;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;
	private String wonyoiOrderYn;
	private String yaksokCode;

	public Ocs0303() {
	}


	public Double getAmt() {
		return this.amt;
	}

	public void setAmt(Double amt) {
		this.amt = amt;
	}


	@Column(name="BOGYONG_CODE")
	public String getBogyongCode() {
		return this.bogyongCode;
	}

	public void setBogyongCode(String bogyongCode) {
		this.bogyongCode = bogyongCode;
	}


	@Column(name="BOM_SOURCE_KEY")
	public Double getBomSourceKey() {
		return this.bomSourceKey;
	}

	public void setBomSourceKey(Double bomSourceKey) {
		this.bomSourceKey = bomSourceKey;
	}


	@Column(name="DANGIL_GUMSA_ORDER_YN")
	public String getDangilGumsaOrderYn() {
		return this.dangilGumsaOrderYn;
	}

	public void setDangilGumsaOrderYn(String dangilGumsaOrderYn) {
		this.dangilGumsaOrderYn = dangilGumsaOrderYn;
	}


	@Column(name="DANGIL_GUMSA_RESULT_YN")
	public String getDangilGumsaResultYn() {
		return this.dangilGumsaResultYn;
	}

	public void setDangilGumsaResultYn(String dangilGumsaResultYn) {
		this.dangilGumsaResultYn = dangilGumsaResultYn;
	}


	@Column(name="DRG_PACK_YN")
	public String getDrgPackYn() {
		return this.drgPackYn;
	}

	public void setDrgPackYn(String drgPackYn) {
		this.drgPackYn = drgPackYn;
	}


	public Double getDv() {
		return this.dv;
	}

	public void setDv(Double dv) {
		this.dv = dv;
	}


	@Column(name="DV_1")
	public Double getDv1() {
		return this.dv1;
	}

	public void setDv1(Double dv1) {
		this.dv1 = dv1;
	}


	@Column(name="DV_2")
	public Double getDv2() {
		return this.dv2;
	}

	public void setDv2(Double dv2) {
		this.dv2 = dv2;
	}


	@Column(name="DV_3")
	public Double getDv3() {
		return this.dv3;
	}

	public void setDv3(Double dv3) {
		this.dv3 = dv3;
	}


	@Column(name="DV_4")
	public Double getDv4() {
		return this.dv4;
	}

	public void setDv4(Double dv4) {
		this.dv4 = dv4;
	}


	@Column(name="DV_5")
	public Double getDv5() {
		return this.dv5;
	}

	public void setDv5(Double dv5) {
		this.dv5 = dv5;
	}


	@Column(name="DV_6")
	public Double getDv6() {
		return this.dv6;
	}

	public void setDv6(Double dv6) {
		this.dv6 = dv6;
	}


	@Column(name="DV_7")
	public Double getDv7() {
		return this.dv7;
	}

	public void setDv7(Double dv7) {
		this.dv7 = dv7;
	}


	@Column(name="DV_8")
	public Double getDv8() {
		return this.dv8;
	}

	public void setDv8(Double dv8) {
		this.dv8 = dv8;
	}


	@Column(name="DV_TIME")
	public String getDvTime() {
		return this.dvTime;
	}

	public void setDvTime(String dvTime) {
		this.dvTime = dvTime;
	}


	public String getEmergency() {
		return this.emergency;
	}

	public void setEmergency(String emergency) {
		this.emergency = emergency;
	}


	@Column(name="FKOCS0300_SEQ")
	public Double getFkocs0300Seq() {
		return this.fkocs0300Seq;
	}

	public void setFkocs0300Seq(Double fkocs0300Seq) {
		this.fkocs0300Seq = fkocs0300Seq;
	}


	@Column(name="GENERAL_DISP_YN")
	public String getGeneralDispYn() {
		return this.generalDispYn;
	}

	public void setGeneralDispYn(String generalDispYn) {
		this.generalDispYn = generalDispYn;
	}


	@Column(name="GROUP_SER")
	public Double getGroupSer() {
		return this.groupSer;
	}

	public void setGroupSer(Double groupSer) {
		this.groupSer = groupSer;
	}


	@Column(name="HANGMOG_CODE")
	public String getHangmogCode() {
		return this.hangmogCode;
	}

	public void setHangmogCode(String hangmogCode) {
		this.hangmogCode = hangmogCode;
	}


	@Column(name="HANGMOG_NAME")
	public String getHangmogName() {
		return this.hangmogName;
	}

	public void setHangmogName(String hangmogName) {
		this.hangmogName = hangmogName;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="HUBAL_CHANGE_YN")
	public String getHubalChangeYn() {
		return this.hubalChangeYn;
	}

	public void setHubalChangeYn(String hubalChangeYn) {
		this.hubalChangeYn = hubalChangeYn;
	}


	@Column(name="INPUT_TAB")
	public String getInputTab() {
		return this.inputTab;
	}

	public void setInputTab(String inputTab) {
		this.inputTab = inputTab;
	}


	@Column(name="JUNDAL_PART_INP")
	public String getJundalPartInp() {
		return this.jundalPartInp;
	}

	public void setJundalPartInp(String jundalPartInp) {
		this.jundalPartInp = jundalPartInp;
	}


	@Column(name="JUNDAL_PART_OUT")
	public String getJundalPartOut() {
		return this.jundalPartOut;
	}

	public void setJundalPartOut(String jundalPartOut) {
		this.jundalPartOut = jundalPartOut;
	}


	@Column(name="JUNDAL_TABLE_INP")
	public String getJundalTableInp() {
		return this.jundalTableInp;
	}

	public void setJundalTableInp(String jundalTableInp) {
		this.jundalTableInp = jundalTableInp;
	}


	@Column(name="JUNDAL_TABLE_OUT")
	public String getJundalTableOut() {
		return this.jundalTableOut;
	}

	public void setJundalTableOut(String jundalTableOut) {
		this.jundalTableOut = jundalTableOut;
	}


	public String getJusa() {
		return this.jusa;
	}

	public void setJusa(String jusa) {
		this.jusa = jusa;
	}


	@Column(name="JUSA_SPD_GUBUN")
	public String getJusaSpdGubun() {
		return this.jusaSpdGubun;
	}

	public void setJusaSpdGubun(String jusaSpdGubun) {
		this.jusaSpdGubun = jusaSpdGubun;
	}


	public String getMemb() {
		return this.memb;
	}

	public void setMemb(String memb) {
		this.memb = memb;
	}


	@Column(name="MEMB_GUBUN")
	public String getMembGubun() {
		return this.membGubun;
	}

	public void setMembGubun(String membGubun) {
		this.membGubun = membGubun;
	}


	@Column(name="MIX_GROUP")
	public String getMixGroup() {
		return this.mixGroup;
	}

	public void setMixGroup(String mixGroup) {
		this.mixGroup = mixGroup;
	}


	@Column(name="MOVE_PART_INP")
	public String getMovePartInp() {
		return this.movePartInp;
	}

	public void setMovePartInp(String movePartInp) {
		this.movePartInp = movePartInp;
	}


	@Column(name="MOVE_PART_OUT")
	public String getMovePartOut() {
		return this.movePartOut;
	}

	public void setMovePartOut(String movePartOut) {
		this.movePartOut = movePartOut;
	}


	public String getMuhyo() {
		return this.muhyo;
	}

	public void setMuhyo(String muhyo) {
		this.muhyo = muhyo;
	}


	public Double getNalsu() {
		return this.nalsu;
	}

	public void setNalsu(Double nalsu) {
		this.nalsu = nalsu;
	}


	@Column(name="NDAY_YN")
	public String getNdayYn() {
		return this.ndayYn;
	}

	public void setNdayYn(String ndayYn) {
		this.ndayYn = ndayYn;
	}


	@Column(name="NURSE_REMARK")
	public String getNurseRemark() {
		return this.nurseRemark;
	}

	public void setNurseRemark(String nurseRemark) {
		this.nurseRemark = nurseRemark;
	}


	@Column(name="ORD_DANUI")
	public String getOrdDanui() {
		return this.ordDanui;
	}

	public void setOrdDanui(String ordDanui) {
		this.ordDanui = ordDanui;
	}


	@Column(name="ORDER_GUBUN")
	public String getOrderGubun() {
		return this.orderGubun;
	}

	public void setOrderGubun(String orderGubun) {
		this.orderGubun = orderGubun;
	}


	@Column(name="ORDER_REMARK")
	public String getOrderRemark() {
		return this.orderRemark;
	}

	public void setOrderRemark(String orderRemark) {
		this.orderRemark = orderRemark;
	}


	public String getPay() {
		return this.pay;
	}

	public void setPay(String pay) {
		this.pay = pay;
	}


	public String getPharmacy() {
		return this.pharmacy;
	}

	public void setPharmacy(String pharmacy) {
		this.pharmacy = pharmacy;
	}


	public Double getPkocs0303() {
		return this.pkocs0303;
	}

	public void setPkocs0303(Double pkocs0303) {
		this.pkocs0303 = pkocs0303;
	}


	@Column(name="PORTABLE_YN")
	public String getPortableYn() {
		return this.portableYn;
	}

	public void setPortableYn(String portableYn) {
		this.portableYn = portableYn;
	}


	@Column(name="POWDER_YN")
	public String getPowderYn() {
		return this.powderYn;
	}

	public void setPowderYn(String powderYn) {
		this.powderYn = powderYn;
	}


	@Column(name="PRN_YN")
	public String getPrnYn() {
		return this.prnYn;
	}

	public void setPrnYn(String prnYn) {
		this.prnYn = prnYn;
	}


	public Double getSeq() {
		return this.seq;
	}

	public void setSeq(Double seq) {
		this.seq = seq;
	}


	@Column(name="SPECIMEN_CODE")
	public String getSpecimenCode() {
		return this.specimenCode;
	}

	public void setSpecimenCode(String specimenCode) {
		this.specimenCode = specimenCode;
	}


	public Double getSuryang() {
		return this.suryang;
	}

	public void setSuryang(Double suryang) {
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


	@Column(name="WONYOI_ORDER_YN")
	public String getWonyoiOrderYn() {
		return this.wonyoiOrderYn;
	}

	public void setWonyoiOrderYn(String wonyoiOrderYn) {
		this.wonyoiOrderYn = wonyoiOrderYn;
	}


	@Column(name="YAKSOK_CODE")
	public String getYaksokCode() {
		return this.yaksokCode;
	}

	public void setYaksokCode(String yaksokCode) {
		this.yaksokCode = yaksokCode;
	}

}