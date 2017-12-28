package nta.med.core.domain.ocs;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.NamedQuery;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;

/**
 * The persistent class for the OCS0103S database table.
 * 
 */
@Entity
@NamedQuery(name = "Ocs0103S.findAll", query = "SELECT o FROM Ocs0103S o")
@Table(name = "OCS0103S")
public class Ocs0103S extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String antiCancerYn;
	private String beforeUseYn;
	private String bomYn;
	private String chisikYn;
	private String defaultBogyongCode;
	private Double defaultDv;
	private String defaultJusa;
	private String defaultPortableYn;
	private Double defaultSuryang;
	private String defaultWonnaeSayu;
	private String defaultWonyoiYn;
	private String displayYn;
	private String dvTime;
	private String emergency;
	private Date endDate;
	private String groupYn;
	private String hangmogCode;

	private String hangmogName;
	private String hangmogNameInx;
	//private String hospCode;
	private String ifInputControl;
	private String inputControl;
	private String invJundalYn;
	private String jaeryoCode;
	private String jaeryoYn;
	private String jundalPartInp;
	private String jundalPartOut;
	private String jundalTableInp;
	private String jundalTableOut;
	private Double limitNalsu;
	private Double limitSuryang;
	private String movePart;
	private String muhyoYn;
	private String ndayYn;
	private String nurseInputYn;
	private String ordDanui;
	private String orderGubun;
	private String patStatusGr;
	private String portableCheck;
	private String position;
	private String powderYn;
	private String remark;
	private String reserYnInp;
	private String reserYnOut;
	private String resultGubun;
	private String returnYn;
	private Double seq;
	private String sgCode;
	private String sgName;
	private String slipCode;
	private String specificComment;
	private String specimenDefault;
	private String specimenYn;
	private Date startDate;
	private String subulConvertGubun;
	private String sugaYn;
	private String supplyInputYn;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;
	private String wonnaeDrgYn;
	private String wonyoiOrderYn;
	private String yakKijunCode;
	private String yjCode;
	private String trialFlg;
	private Integer clisProtocolId;
	private String modifyFlg;
	//private String outHospBookYn;
//	private String commonOrder;
//	private String groupCode;
	public Ocs0103S() {
	}

	@Column(name = "ANTI_CANCER_YN")
	public String getAntiCancerYn() {
		return this.antiCancerYn;
	}

	public void setAntiCancerYn(String antiCancerYn) {
		this.antiCancerYn = antiCancerYn;
	}

	@Column(name = "BEFORE_USE_YN")
	public String getBeforeUseYn() {
		return this.beforeUseYn;
	}

	public void setBeforeUseYn(String beforeUseYn) {
		this.beforeUseYn = beforeUseYn;
	}

	@Column(name = "BOM_YN")
	public String getBomYn() {
		return this.bomYn;
	}

	public void setBomYn(String bomYn) {
		this.bomYn = bomYn;
	}

	@Column(name = "CHISIK_YN")
	public String getChisikYn() {
		return this.chisikYn;
	}

	public void setChisikYn(String chisikYn) {
		this.chisikYn = chisikYn;
	}

	@Column(name = "DEFAULT_BOGYONG_CODE")
	public String getDefaultBogyongCode() {
		return this.defaultBogyongCode;
	}

	public void setDefaultBogyongCode(String defaultBogyongCode) {
		this.defaultBogyongCode = defaultBogyongCode;
	}

	@Column(name = "DEFAULT_DV")
	public Double getDefaultDv() {
		return this.defaultDv;
	}

	public void setDefaultDv(Double defaultDv) {
		this.defaultDv = defaultDv;
	}

	@Column(name = "DEFAULT_JUSA")
	public String getDefaultJusa() {
		return this.defaultJusa;
	}

	public void setDefaultJusa(String defaultJusa) {
		this.defaultJusa = defaultJusa;
	}

	@Column(name = "DEFAULT_PORTABLE_YN")
	public String getDefaultPortableYn() {
		return this.defaultPortableYn;
	}

	public void setDefaultPortableYn(String defaultPortableYn) {
		this.defaultPortableYn = defaultPortableYn;
	}

	@Column(name = "DEFAULT_SURYANG")
	public Double getDefaultSuryang() {
		return this.defaultSuryang;
	}

	public void setDefaultSuryang(Double defaultSuryang) {
		this.defaultSuryang = defaultSuryang;
	}

	@Column(name = "DEFAULT_WONNAE_SAYU")
	public String getDefaultWonnaeSayu() {
		return this.defaultWonnaeSayu;
	}

	public void setDefaultWonnaeSayu(String defaultWonnaeSayu) {
		this.defaultWonnaeSayu = defaultWonnaeSayu;
	}

	@Column(name = "DEFAULT_WONYOI_YN")
	public String getDefaultWonyoiYn() {
		return this.defaultWonyoiYn;
	}

	public void setDefaultWonyoiYn(String defaultWonyoiYn) {
		this.defaultWonyoiYn = defaultWonyoiYn;
	}

	@Column(name = "DISPLAY_YN")
	public String getDisplayYn() {
		return this.displayYn;
	}

	public void setDisplayYn(String displayYn) {
		this.displayYn = displayYn;
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

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "END_DATE")
	public Date getEndDate() {
		return this.endDate;
	}

	public void setEndDate(Date endDate) {
		this.endDate = endDate;
	}

	@Column(name = "GROUP_YN")
	public String getGroupYn() {
		return this.groupYn;
	}

	public void setGroupYn(String groupYn) {
		this.groupYn = groupYn;
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

	@Column(name = "HANGMOG_NAME_INX")
	public String getHangmogNameInx() {
		return this.hangmogNameInx;
	}

	public void setHangmogNameInx(String hangmogNameInx) {
		this.hangmogNameInx = hangmogNameInx;
	}

	/*@Column(name = "HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}*/

	@Column(name = "IF_INPUT_CONTROL")
	public String getIfInputControl() {
		return this.ifInputControl;
	}

	public void setIfInputControl(String ifInputControl) {
		this.ifInputControl = ifInputControl;
	}

	@Column(name = "INPUT_CONTROL")
	public String getInputControl() {
		return this.inputControl;
	}

	public void setInputControl(String inputControl) {
		this.inputControl = inputControl;
	}

	@Column(name = "INV_JUNDAL_YN")
	public String getInvJundalYn() {
		return this.invJundalYn;
	}

	public void setInvJundalYn(String invJundalYn) {
		this.invJundalYn = invJundalYn;
	}

	@Column(name = "JAERYO_CODE")
	public String getJaeryoCode() {
		return this.jaeryoCode;
	}

	public void setJaeryoCode(String jaeryoCode) {
		this.jaeryoCode = jaeryoCode;
	}

	@Column(name = "JAERYO_YN")
	public String getJaeryoYn() {
		return this.jaeryoYn;
	}

	public void setJaeryoYn(String jaeryoYn) {
		this.jaeryoYn = jaeryoYn;
	}

	@Column(name = "JUNDAL_PART_INP")
	public String getJundalPartInp() {
		return this.jundalPartInp;
	}

	public void setJundalPartInp(String jundalPartInp) {
		this.jundalPartInp = jundalPartInp;
	}

	@Column(name = "JUNDAL_PART_OUT")
	public String getJundalPartOut() {
		return this.jundalPartOut;
	}

	public void setJundalPartOut(String jundalPartOut) {
		this.jundalPartOut = jundalPartOut;
	}

	@Column(name = "JUNDAL_TABLE_INP")
	public String getJundalTableInp() {
		return this.jundalTableInp;
	}

	public void setJundalTableInp(String jundalTableInp) {
		this.jundalTableInp = jundalTableInp;
	}

	@Column(name = "JUNDAL_TABLE_OUT")
	public String getJundalTableOut() {
		return this.jundalTableOut;
	}

	public void setJundalTableOut(String jundalTableOut) {
		this.jundalTableOut = jundalTableOut;
	}

	@Column(name = "LIMIT_NALSU")
	public Double getLimitNalsu() {
		return this.limitNalsu;
	}

	public void setLimitNalsu(Double limitNalsu) {
		this.limitNalsu = limitNalsu;
	}

	@Column(name = "LIMIT_SURYANG")
	public Double getLimitSuryang() {
		return this.limitSuryang;
	}

	public void setLimitSuryang(Double limitSuryang) {
		this.limitSuryang = limitSuryang;
	}

	@Column(name = "MOVE_PART")
	public String getMovePart() {
		return this.movePart;
	}

	public void setMovePart(String movePart) {
		this.movePart = movePart;
	}

	@Column(name = "MUHYO_YN")
	public String getMuhyoYn() {
		return this.muhyoYn;
	}

	public void setMuhyoYn(String muhyoYn) {
		this.muhyoYn = muhyoYn;
	}

	@Column(name = "NDAY_YN")
	public String getNdayYn() {
		return this.ndayYn;
	}

	public void setNdayYn(String ndayYn) {
		this.ndayYn = ndayYn;
	}

	@Column(name = "NURSE_INPUT_YN")
	public String getNurseInputYn() {
		return this.nurseInputYn;
	}

	public void setNurseInputYn(String nurseInputYn) {
		this.nurseInputYn = nurseInputYn;
	}

	@Column(name = "ORD_DANUI")
	public String getOrdDanui() {
		return this.ordDanui;
	}

	public void setOrdDanui(String ordDanui) {
		this.ordDanui = ordDanui;
	}

	@Column(name = "ORDER_GUBUN")
	public String getOrderGubun() {
		return this.orderGubun;
	}

	public void setOrderGubun(String orderGubun) {
		this.orderGubun = orderGubun;
	}

	@Column(name = "PAT_STATUS_GR")
	public String getPatStatusGr() {
		return this.patStatusGr;
	}

	public void setPatStatusGr(String patStatusGr) {
		this.patStatusGr = patStatusGr;
	}

	@Column(name = "PORTABLE_CHECK")
	public String getPortableCheck() {
		return this.portableCheck;
	}

	public void setPortableCheck(String portableCheck) {
		this.portableCheck = portableCheck;
	}

	public String getPosition() {
		return this.position;
	}

	public void setPosition(String position) {
		this.position = position;
	}

	@Column(name = "POWDER_YN")
	public String getPowderYn() {
		return this.powderYn;
	}

	public void setPowderYn(String powderYn) {
		this.powderYn = powderYn;
	}

	public String getRemark() {
		return this.remark;
	}

	public void setRemark(String remark) {
		this.remark = remark;
	}

	@Column(name = "RESER_YN_INP")
	public String getReserYnInp() {
		return this.reserYnInp;
	}

	public void setReserYnInp(String reserYnInp) {
		this.reserYnInp = reserYnInp;
	}

	@Column(name = "RESER_YN_OUT")
	public String getReserYnOut() {
		return this.reserYnOut;
	}

	public void setReserYnOut(String reserYnOut) {
		this.reserYnOut = reserYnOut;
	}

	@Column(name = "RESULT_GUBUN")
	public String getResultGubun() {
		return this.resultGubun;
	}

	public void setResultGubun(String resultGubun) {
		this.resultGubun = resultGubun;
	}

	@Column(name = "RETURN_YN")
	public String getReturnYn() {
		return this.returnYn;
	}

	public void setReturnYn(String returnYn) {
		this.returnYn = returnYn;
	}

	public Double getSeq() {
		return this.seq;
	}

	public void setSeq(Double seq) {
		this.seq = seq;
	}

	@Column(name = "SG_CODE")
	public String getSgCode() {
		return this.sgCode;
	}

	public void setSgCode(String sgCode) {
		this.sgCode = sgCode;
	}

	@Column(name = "SG_NAME")
	public String getSgName() {
		return this.sgName;
	}

	public void setSgName(String sgName) {
		this.sgName = sgName;
	}

	@Column(name = "SLIP_CODE")
	public String getSlipCode() {
		return this.slipCode;
	}

	public void setSlipCode(String slipCode) {
		this.slipCode = slipCode;
	}

	@Column(name = "SPECIFIC_COMMENT")
	public String getSpecificComment() {
		return this.specificComment;
	}

	public void setSpecificComment(String specificComment) {
		this.specificComment = specificComment;
	}

	@Column(name = "SPECIMEN_DEFAULT")
	public String getSpecimenDefault() {
		return this.specimenDefault;
	}

	public void setSpecimenDefault(String specimenDefault) {
		this.specimenDefault = specimenDefault;
	}

	@Column(name = "SPECIMEN_YN")
	public String getSpecimenYn() {
		return this.specimenYn;
	}

	public void setSpecimenYn(String specimenYn) {
		this.specimenYn = specimenYn;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "START_DATE")
	public Date getStartDate() {
		return this.startDate;
	}

	public void setStartDate(Date startDate) {
		this.startDate = startDate;
	}

	@Column(name = "SUBUL_CONVERT_GUBUN")
	public String getSubulConvertGubun() {
		return this.subulConvertGubun;
	}

	public void setSubulConvertGubun(String subulConvertGubun) {
		this.subulConvertGubun = subulConvertGubun;
	}

	@Column(name = "SUGA_YN")
	public String getSugaYn() {
		return this.sugaYn;
	}

	public void setSugaYn(String sugaYn) {
		this.sugaYn = sugaYn;
	}

	@Column(name = "SUPPLY_INPUT_YN")
	public String getSupplyInputYn() {
		return this.supplyInputYn;
	}

	public void setSupplyInputYn(String supplyInputYn) {
		this.supplyInputYn = supplyInputYn;
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

	@Column(name = "WONNAE_DRG_YN")
	public String getWonnaeDrgYn() {
		return this.wonnaeDrgYn;
	}

	public void setWonnaeDrgYn(String wonnaeDrgYn) {
		this.wonnaeDrgYn = wonnaeDrgYn;
	}

	@Column(name = "WONYOI_ORDER_YN")
	public String getWonyoiOrderYn() {
		return this.wonyoiOrderYn;
	}

	public void setWonyoiOrderYn(String wonyoiOrderYn) {
		this.wonyoiOrderYn = wonyoiOrderYn;
	}

	@Column(name = "YAK_KIJUN_CODE")
	public String getYakKijunCode() {
		return this.yakKijunCode;
	}

	public void setYakKijunCode(String yakKijunCode) {
		this.yakKijunCode = yakKijunCode;
	}

	@Column(name = "YJ_CODE")
	public String getYjCode() {
		return this.yjCode;
	}

	public void setYjCode(String yjCode) {
		this.yjCode = yjCode;
	}

	@Column(name = "TRIAL_FLG")
	public String getTrialFlg() {
		return trialFlg;
	}

	public void setTrialFlg(String trialFlg) {
		this.trialFlg = trialFlg;
	}

	@Column(name = "CLIS_PROTOCOL_ID")
	public Integer getClisProtocolId() {
		return clisProtocolId;
	}

	public void setClisProtocolId(Integer clisProtocolId) {
		this.clisProtocolId = clisProtocolId;
	}

	/*@Column(name = "MODIFY_FLG")
	public String getModifyFlg() {
		return modifyFlg;
	}

	public void setModifyFlg(String modifyFlg) {
		this.modifyFlg = modifyFlg;
	}*/

/*	@Column(name = "OUT_HOSP_BOOK_YN")
	public String getOutHospBookYn() {
		return outHospBookYn;
	}

	public void setOutHospBookYn(String outHospBookYn) {
		this.outHospBookYn = outHospBookYn;
	}*/
//	@Column(name = "COMMON_YN")
//	public String getCommonOrder() {
//		return commonOrder;
//	}
//
//	public void setCommonOrder(String commonOrder) {
//		this.commonOrder = commonOrder;
//	}
//	@Column(name = "GROUP_CODE")
//	public String getGroupCode() {
//		return groupCode;
//	}
//
//	public void setGroupCode(String groupCode) {
//		this.groupCode = groupCode;
//	}
	
	
}