package nta.med.core.domain.ocs;

import java.math.BigDecimal;
import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;

/**
 * The persistent class for the OCS6013 database table.
 * 
 */
@Entity
@Table(name = "OCS6013")
public class Ocs6013 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String actBuseo;
	private String actDoctor;
	private String actGwa;
	private Double amt;
	private String antiCancerYn;
	private String bogyongCode;
	private String bogyongCode2;
	private Double bomSourceKey;
	private String cpCode;
	private String cpPathCode;
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
	private Double fkocs2003;
	private Double fkocs6010;
	private Double groupSer;
	private String hangmogCode;
	private String hangmogName;
	private String hospCode;
	private String hubalChangeYn;
	private String inputDoctor;
	private String inputGubun;
	private String inputGwa;
	private String inputId;
	private String inputPart;
	private String inputTab;
	private String jaeryoJundalYn;
	private Double jaewonil;
	private String jundalPart;
	private String jundalTable;
	private String jusa;
	private String jusaSpdGubun;
	private String mixGroup;
	private String movePart;
	private String muhyo;
	private Double nalsu;
	private Date nurseHoldDate;
	private String nurseHoldTime;
	private String nurseHoldUser;
	private String nurseRemark;
	private String ordDanui;
	private String orderEndYn;
	private String orderGubun;
	private String orderRemark;
	private String pay;
	private String pharmacy;
	private Double pkocs6013;
	private Date planOrderDate;
	private String portableYn;
	private String powderYn;
	private String prnYn;
	private Double refFkocs2003;
	private String regularYn;
	private BigDecimal seq;
	private String specimenCode;
	private Double suryang;
	private Date sysDate;
	private String sysId;
	private String toiwonDrgYn;
	private Date updDate;
	private String updId;

	public Ocs6013() {
	}

	@Column(name = "ACT_BUSEO")
	public String getActBuseo() {
		return this.actBuseo;
	}

	public void setActBuseo(String actBuseo) {
		this.actBuseo = actBuseo;
	}

	@Column(name = "ACT_DOCTOR")
	public String getActDoctor() {
		return this.actDoctor;
	}

	public void setActDoctor(String actDoctor) {
		this.actDoctor = actDoctor;
	}

	@Column(name = "ACT_GWA")
	public String getActGwa() {
		return this.actGwa;
	}

	public void setActGwa(String actGwa) {
		this.actGwa = actGwa;
	}

	public Double getAmt() {
		return this.amt;
	}

	public void setAmt(Double amt) {
		this.amt = amt;
	}

	@Column(name = "ANTI_CANCER_YN")
	public String getAntiCancerYn() {
		return this.antiCancerYn;
	}

	public void setAntiCancerYn(String antiCancerYn) {
		this.antiCancerYn = antiCancerYn;
	}

	@Column(name = "BOGYONG_CODE")
	public String getBogyongCode() {
		return this.bogyongCode;
	}

	public void setBogyongCode(String bogyongCode) {
		this.bogyongCode = bogyongCode;
	}

	@Column(name = "BOGYONG_CODE_2")
	public String getBogyongCode2() {
		return this.bogyongCode2;
	}

	public void setBogyongCode2(String bogyongCode2) {
		this.bogyongCode2 = bogyongCode2;
	}

	@Column(name = "BOM_SOURCE_KEY")
	public Double getBomSourceKey() {
		return this.bomSourceKey;
	}

	public void setBomSourceKey(Double bomSourceKey) {
		this.bomSourceKey = bomSourceKey;
	}

	@Column(name = "CP_CODE")
	public String getCpCode() {
		return this.cpCode;
	}

	public void setCpCode(String cpCode) {
		this.cpCode = cpCode;
	}

	@Column(name = "CP_PATH_CODE")
	public String getCpPathCode() {
		return this.cpPathCode;
	}

	public void setCpPathCode(String cpPathCode) {
		this.cpPathCode = cpPathCode;
	}

	@Column(name = "DRG_PACK_YN")
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

	@Column(name = "DV_1")
	public Double getDv1() {
		return this.dv1;
	}

	public void setDv1(Double dv1) {
		this.dv1 = dv1;
	}

	@Column(name = "DV_2")
	public Double getDv2() {
		return this.dv2;
	}

	public void setDv2(Double dv2) {
		this.dv2 = dv2;
	}

	@Column(name = "DV_3")
	public Double getDv3() {
		return this.dv3;
	}

	public void setDv3(Double dv3) {
		this.dv3 = dv3;
	}

	@Column(name = "DV_4")
	public Double getDv4() {
		return this.dv4;
	}

	public void setDv4(Double dv4) {
		this.dv4 = dv4;
	}

	@Column(name = "DV_5")
	public Double getDv5() {
		return this.dv5;
	}

	public void setDv5(Double dv5) {
		this.dv5 = dv5;
	}

	@Column(name = "DV_6")
	public Double getDv6() {
		return this.dv6;
	}

	public void setDv6(Double dv6) {
		this.dv6 = dv6;
	}

	@Column(name = "DV_7")
	public Double getDv7() {
		return this.dv7;
	}

	public void setDv7(Double dv7) {
		this.dv7 = dv7;
	}

	@Column(name = "DV_8")
	public Double getDv8() {
		return this.dv8;
	}

	public void setDv8(Double dv8) {
		this.dv8 = dv8;
	}

	@Column(name = "DV_TIME")
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

	public Double getFkocs2003() {
		return this.fkocs2003;
	}

	public void setFkocs2003(Double fkocs2003) {
		this.fkocs2003 = fkocs2003;
	}

	public Double getFkocs6010() {
		return this.fkocs6010;
	}

	public void setFkocs6010(Double fkocs6010) {
		this.fkocs6010 = fkocs6010;
	}

	@Column(name = "GROUP_SER")
	public Double getGroupSer() {
		return this.groupSer;
	}

	public void setGroupSer(Double groupSer) {
		this.groupSer = groupSer;
	}

	@Column(name = "HANGMOG_CODE")
	public String getHangmogCode() {
		return this.hangmogCode;
	}

	public void setHangmogCode(String hangmogCode) {
		this.hangmogCode = hangmogCode;
	}

	@Column(name = "HANGMOG_NAME")
	public String getHangmogName() {
		return this.hangmogName;
	}

	public void setHangmogName(String hangmogName) {
		this.hangmogName = hangmogName;
	}

	@Column(name = "HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}

	@Column(name = "HUBAL_CHANGE_YN")
	public String getHubalChangeYn() {
		return this.hubalChangeYn;
	}

	public void setHubalChangeYn(String hubalChangeYn) {
		this.hubalChangeYn = hubalChangeYn;
	}

	@Column(name = "INPUT_DOCTOR")
	public String getInputDoctor() {
		return this.inputDoctor;
	}

	public void setInputDoctor(String inputDoctor) {
		this.inputDoctor = inputDoctor;
	}

	@Column(name = "INPUT_GUBUN")
	public String getInputGubun() {
		return this.inputGubun;
	}

	public void setInputGubun(String inputGubun) {
		this.inputGubun = inputGubun;
	}

	@Column(name = "INPUT_GWA")
	public String getInputGwa() {
		return this.inputGwa;
	}

	public void setInputGwa(String inputGwa) {
		this.inputGwa = inputGwa;
	}

	@Column(name = "INPUT_ID")
	public String getInputId() {
		return this.inputId;
	}

	public void setInputId(String inputId) {
		this.inputId = inputId;
	}

	@Column(name = "INPUT_PART")
	public String getInputPart() {
		return this.inputPart;
	}

	public void setInputPart(String inputPart) {
		this.inputPart = inputPart;
	}

	@Column(name = "INPUT_TAB")
	public String getInputTab() {
		return this.inputTab;
	}

	public void setInputTab(String inputTab) {
		this.inputTab = inputTab;
	}

	@Column(name = "JAERYO_JUNDAL_YN")
	public String getJaeryoJundalYn() {
		return this.jaeryoJundalYn;
	}

	public void setJaeryoJundalYn(String jaeryoJundalYn) {
		this.jaeryoJundalYn = jaeryoJundalYn;
	}

	public Double getJaewonil() {
		return this.jaewonil;
	}

	public void setJaewonil(Double jaewonil) {
		this.jaewonil = jaewonil;
	}

	@Column(name = "JUNDAL_PART")
	public String getJundalPart() {
		return this.jundalPart;
	}

	public void setJundalPart(String jundalPart) {
		this.jundalPart = jundalPart;
	}

	@Column(name = "JUNDAL_TABLE")
	public String getJundalTable() {
		return this.jundalTable;
	}

	public void setJundalTable(String jundalTable) {
		this.jundalTable = jundalTable;
	}

	public String getJusa() {
		return this.jusa;
	}

	public void setJusa(String jusa) {
		this.jusa = jusa;
	}

	@Column(name = "JUSA_SPD_GUBUN")
	public String getJusaSpdGubun() {
		return this.jusaSpdGubun;
	}

	public void setJusaSpdGubun(String jusaSpdGubun) {
		this.jusaSpdGubun = jusaSpdGubun;
	}

	@Column(name = "MIX_GROUP")
	public String getMixGroup() {
		return this.mixGroup;
	}

	public void setMixGroup(String mixGroup) {
		this.mixGroup = mixGroup;
	}

	@Column(name = "MOVE_PART")
	public String getMovePart() {
		return this.movePart;
	}

	public void setMovePart(String movePart) {
		this.movePart = movePart;
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

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "NURSE_HOLD_DATE")
	public Date getNurseHoldDate() {
		return this.nurseHoldDate;
	}

	public void setNurseHoldDate(Date nurseHoldDate) {
		this.nurseHoldDate = nurseHoldDate;
	}

	@Column(name = "NURSE_HOLD_TIME")
	public String getNurseHoldTime() {
		return this.nurseHoldTime;
	}

	public void setNurseHoldTime(String nurseHoldTime) {
		this.nurseHoldTime = nurseHoldTime;
	}

	@Column(name = "NURSE_HOLD_USER")
	public String getNurseHoldUser() {
		return this.nurseHoldUser;
	}

	public void setNurseHoldUser(String nurseHoldUser) {
		this.nurseHoldUser = nurseHoldUser;
	}

	@Column(name = "NURSE_REMARK")
	public String getNurseRemark() {
		return this.nurseRemark;
	}

	public void setNurseRemark(String nurseRemark) {
		this.nurseRemark = nurseRemark;
	}

	@Column(name = "ORD_DANUI")
	public String getOrdDanui() {
		return this.ordDanui;
	}

	public void setOrdDanui(String ordDanui) {
		this.ordDanui = ordDanui;
	}

	@Column(name = "ORDER_END_YN")
	public String getOrderEndYn() {
		return this.orderEndYn;
	}

	public void setOrderEndYn(String orderEndYn) {
		this.orderEndYn = orderEndYn;
	}

	@Column(name = "ORDER_GUBUN")
	public String getOrderGubun() {
		return this.orderGubun;
	}

	public void setOrderGubun(String orderGubun) {
		this.orderGubun = orderGubun;
	}

	@Column(name = "ORDER_REMARK")
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

	public Double getPkocs6013() {
		return this.pkocs6013;
	}

	public void setPkocs6013(Double pkocs6013) {
		this.pkocs6013 = pkocs6013;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "PLAN_ORDER_DATE")
	public Date getPlanOrderDate() {
		return this.planOrderDate;
	}

	public void setPlanOrderDate(Date planOrderDate) {
		this.planOrderDate = planOrderDate;
	}

	@Column(name = "PORTABLE_YN")
	public String getPortableYn() {
		return this.portableYn;
	}

	public void setPortableYn(String portableYn) {
		this.portableYn = portableYn;
	}

	@Column(name = "POWDER_YN")
	public String getPowderYn() {
		return this.powderYn;
	}

	public void setPowderYn(String powderYn) {
		this.powderYn = powderYn;
	}

	@Column(name = "PRN_YN")
	public String getPrnYn() {
		return this.prnYn;
	}

	public void setPrnYn(String prnYn) {
		this.prnYn = prnYn;
	}

	@Column(name = "REF_FKOCS2003")
	public Double getRefFkocs2003() {
		return this.refFkocs2003;
	}

	public void setRefFkocs2003(Double refFkocs2003) {
		this.refFkocs2003 = refFkocs2003;
	}

	@Column(name = "REGULAR_YN")
	public String getRegularYn() {
		return this.regularYn;
	}

	public void setRegularYn(String regularYn) {
		this.regularYn = regularYn;
	}

	public BigDecimal getSeq() {
		return this.seq;
	}

	public void setSeq(BigDecimal seq) {
		this.seq = seq;
	}

	@Column(name = "SPECIMEN_CODE")
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

	@Column(name = "TOIWON_DRG_YN")
	public String getToiwonDrgYn() {
		return this.toiwonDrgYn;
	}

	public void setToiwonDrgYn(String toiwonDrgYn) {
		this.toiwonDrgYn = toiwonDrgYn;
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