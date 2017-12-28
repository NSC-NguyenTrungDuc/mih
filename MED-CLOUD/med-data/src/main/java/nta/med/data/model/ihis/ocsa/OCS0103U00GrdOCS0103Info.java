package nta.med.data.model.ihis.ocsa;

import java.util.Date;

public class OCS0103U00GrdOCS0103Info {
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String hangmogCode;
	private String hangmogName;
	private String slipCode;
	private String groupYn;
	private String position;
	private Double seq;
	private String orderGubun;
	private String inputControl;
	private String jundalTableOut;
	private String jundalTableInp;
	private String jundalPartOut;
	private String jundalPartInp;
	private String movePart;
	private String dvTime;
	private String ordDanui;
	private String defaultBogyongCode;
	private String sugaYn;
	private String sgCode;
	private String jaeryoYn;
	private String jaeryoCode;
	private String hangmogNameInx;
	private String displayYn;
	private Date startDate;
	private Date endDate;
	private String specimenYn;
	private String specimenDefault;
	private String defaultPortableYn1;
	private String specificComment;
	private String reserYnOut;
	private String reserYnInp;
	private String emergency;
	private Double limitSuryang;
	private String bomYn;
	private String returnYn;
	private String subulConvertGubun;
	private String wonyoiOrderYn;
	private String defaultWonnaeSayu;
	private String antiCancerYn;
	private String chisikYn;
	private String ndayYn;
	private String muhyoYn;
	private String invJundalYn;
	private String powderYn;
	private String remark;
	private Double defaultDv;
	private Double defaultSuryang;
	private String nurseInputYn;
	private String supplyInputYn;
	private Double limitNalsu;
	private String defaultWonyoiYn;
	private String portableCheck;
	private String patStatusGr;
	private String updId;
	private String hospCode;
	private String defaultJusa;
	private String slipName;
	private String jundalPartOutName;
	private String jundalPartInpName;
	private String movePartName;
	private String jaeryoName;
	private String subulDanuiName;
	private String jearyoBulyongDate;
	private String defaultBogyongName;
	private String ifInputControl;
	private String hubalDrgYn;
	private String sgName;
	private String sgDanuiName;
	private String bulyongYmd;
	private String resultGubun;
	private String wonnaeDrgYn;
	// private String outHospBookYn;
	private String commonOrder;
	private String yakKijunCode;
	private String yjCode;
	private String ifCode;
	private String trial;
	private String protocol;
	private String defaultPortableYn2;

	public OCS0103U00GrdOCS0103Info(Date sysDate, String sysId, Date updDate, String hangmogCode, String hangmogName,
			String slipCode, String groupYn, String position, Double seq, String orderGubun, String inputControl,
			String jundalTableOut, String jundalTableInp, String jundalPartOut, String jundalPartInp, String movePart,
			String dvTime, String ordDanui, String defaultBogyongCode, String sugaYn, String sgCode, String jaeryoYn,
			String jaeryoCode, String hangmogNameInx, String displayYn, Date startDate, Date endDate, String specimenYn,
			String specimenDefault, String defaultPortableYn1, String specificComment, String reserYnOut,
			String reserYnInp, String emergency, Double limitSuryang, String bomYn, String returnYn,
			String subulConvertGubun, String wonyoiOrderYn, String defaultWonnaeSayu, String antiCancerYn,
			String chisikYn, String ndayYn, String muhyoYn, String invJundalYn, String powderYn, String remark,
			Double defaultDv, Double defaultSuryang, String nurseInputYn, String supplyInputYn, Double limitNalsu,
			String defaultWonyoiYn, String portableCheck, String patStatusGr, String updId, String hospCode,
			String defaultJusa, String slipName, String jundalPartOutName, String jundalPartInpName,
			String movePartName, String jaeryoName, String subulDanuiName, String jearyoBulyongDate,
			String defaultBogyongName, String ifInputControl, String hubalDrgYn, String sgName, String sgDanuiName,
			String bulyongYmd, String resultGubun, String wonnaeDrgYn, String commonOrder, String yakKijunCode,
			String yjCode, String ifCode, String trial, String protocol, String defaultPortableYn2) {
		super();
		this.sysDate = sysDate;
		this.sysId = sysId;
		this.updDate = updDate;
		this.hangmogCode = hangmogCode;
		this.hangmogName = hangmogName;
		this.slipCode = slipCode;
		this.groupYn = groupYn;
		this.position = position;
		this.seq = seq;
		this.orderGubun = orderGubun;
		this.inputControl = inputControl;
		this.jundalTableOut = jundalTableOut;
		this.jundalTableInp = jundalTableInp;
		this.jundalPartOut = jundalPartOut;
		this.jundalPartInp = jundalPartInp;
		this.movePart = movePart;
		this.dvTime = dvTime;
		this.ordDanui = ordDanui;
		this.defaultBogyongCode = defaultBogyongCode;
		this.sugaYn = sugaYn;
		this.sgCode = sgCode;
		this.jaeryoYn = jaeryoYn;
		this.jaeryoCode = jaeryoCode;
		this.hangmogNameInx = hangmogNameInx;
		this.displayYn = displayYn;
		this.startDate = startDate;
		this.endDate = endDate;
		this.specimenYn = specimenYn;
		this.specimenDefault = specimenDefault;
		this.defaultPortableYn1 = defaultPortableYn1;
		this.specificComment = specificComment;
		this.reserYnOut = reserYnOut;
		this.reserYnInp = reserYnInp;
		this.emergency = emergency;
		this.limitSuryang = limitSuryang;
		this.bomYn = bomYn;
		this.returnYn = returnYn;
		this.subulConvertGubun = subulConvertGubun;
		this.wonyoiOrderYn = wonyoiOrderYn;
		this.defaultWonnaeSayu = defaultWonnaeSayu;
		this.antiCancerYn = antiCancerYn;
		this.chisikYn = chisikYn;
		this.ndayYn = ndayYn;
		this.muhyoYn = muhyoYn;
		this.invJundalYn = invJundalYn;
		this.powderYn = powderYn;
		this.remark = remark;
		this.defaultDv = defaultDv;
		this.defaultSuryang = defaultSuryang;
		this.nurseInputYn = nurseInputYn;
		this.supplyInputYn = supplyInputYn;
		this.limitNalsu = limitNalsu;
		this.defaultWonyoiYn = defaultWonyoiYn;
		this.portableCheck = portableCheck;
		this.patStatusGr = patStatusGr;
		this.updId = updId;
		this.hospCode = hospCode;
		this.defaultJusa = defaultJusa;
		this.slipName = slipName;
		this.jundalPartOutName = jundalPartOutName;
		this.jundalPartInpName = jundalPartInpName;
		this.movePartName = movePartName;
		this.jaeryoName = jaeryoName;
		this.subulDanuiName = subulDanuiName;
		this.jearyoBulyongDate = jearyoBulyongDate;
		this.defaultBogyongName = defaultBogyongName;
		this.ifInputControl = ifInputControl;
		this.hubalDrgYn = hubalDrgYn;
		this.sgName = sgName;
		this.sgDanuiName = sgDanuiName;
		this.bulyongYmd = bulyongYmd;
		this.resultGubun = resultGubun;
		this.wonnaeDrgYn = wonnaeDrgYn;
		this.commonOrder = commonOrder;
		this.yakKijunCode = yakKijunCode;
		this.yjCode = yjCode;
		this.ifCode = ifCode;
		this.trial = trial;
		this.protocol = protocol;
		this.defaultPortableYn2 = defaultPortableYn2;
	}

	public Date getSysDate() {
		return sysDate;
	}

	public void setSysDate(Date sysDate) {
		this.sysDate = sysDate;
	}

	public String getSysId() {
		return sysId;
	}

	public void setSysId(String sysId) {
		this.sysId = sysId;
	}

	public Date getUpdDate() {
		return updDate;
	}

	public void setUpdDate(Date updDate) {
		this.updDate = updDate;
	}

	public String getHangmogCode() {
		return hangmogCode;
	}

	public void setHangmogCode(String hangmogCode) {
		this.hangmogCode = hangmogCode;
	}

	public String getHangmogName() {
		return hangmogName;
	}

	public void setHangmogName(String hangmogName) {
		this.hangmogName = hangmogName;
	}

	public String getSlipCode() {
		return slipCode;
	}

	public void setSlipCode(String slipCode) {
		this.slipCode = slipCode;
	}

	public String getGroupYn() {
		return groupYn;
	}

	public void setGroupYn(String groupYn) {
		this.groupYn = groupYn;
	}

	public String getPosition() {
		return position;
	}

	public void setPosition(String position) {
		this.position = position;
	}

	public Double getSeq() {
		return seq;
	}

	public void setSeq(Double seq) {
		this.seq = seq;
	}

	public String getOrderGubun() {
		return orderGubun;
	}

	public void setOrderGubun(String orderGubun) {
		this.orderGubun = orderGubun;
	}

	public String getInputControl() {
		return inputControl;
	}

	public void setInputControl(String inputControl) {
		this.inputControl = inputControl;
	}

	public String getJundalTableOut() {
		return jundalTableOut;
	}

	public void setJundalTableOut(String jundalTableOut) {
		this.jundalTableOut = jundalTableOut;
	}

	public String getJundalTableInp() {
		return jundalTableInp;
	}

	public void setJundalTableInp(String jundalTableInp) {
		this.jundalTableInp = jundalTableInp;
	}

	public String getJundalPartOut() {
		return jundalPartOut;
	}

	public void setJundalPartOut(String jundalPartOut) {
		this.jundalPartOut = jundalPartOut;
	}

	public String getJundalPartInp() {
		return jundalPartInp;
	}

	public void setJundalPartInp(String jundalPartInp) {
		this.jundalPartInp = jundalPartInp;
	}

	public String getMovePart() {
		return movePart;
	}

	public void setMovePart(String movePart) {
		this.movePart = movePart;
	}

	public String getDvTime() {
		return dvTime;
	}

	public void setDvTime(String dvTime) {
		this.dvTime = dvTime;
	}

	public String getOrdDanui() {
		return ordDanui;
	}

	public void setOrdDanui(String ordDanui) {
		this.ordDanui = ordDanui;
	}

	public String getDefaultBogyongCode() {
		return defaultBogyongCode;
	}

	public void setDefaultBogyongCode(String defaultBogyongCode) {
		this.defaultBogyongCode = defaultBogyongCode;
	}

	public String getSugaYn() {
		return sugaYn;
	}

	public void setSugaYn(String sugaYn) {
		this.sugaYn = sugaYn;
	}

	public String getSgCode() {
		return sgCode;
	}

	public void setSgCode(String sgCode) {
		this.sgCode = sgCode;
	}

	public String getJaeryoYn() {
		return jaeryoYn;
	}

	public void setJaeryoYn(String jaeryoYn) {
		this.jaeryoYn = jaeryoYn;
	}

	public String getJaeryoCode() {
		return jaeryoCode;
	}

	public void setJaeryoCode(String jaeryoCode) {
		this.jaeryoCode = jaeryoCode;
	}

	public String getHangmogNameInx() {
		return hangmogNameInx;
	}

	public void setHangmogNameInx(String hangmogNameInx) {
		this.hangmogNameInx = hangmogNameInx;
	}

	public String getDisplayYn() {
		return displayYn;
	}

	public void setDisplayYn(String displayYn) {
		this.displayYn = displayYn;
	}

	public Date getStartDate() {
		return startDate;
	}

	public void setStartDate(Date startDate) {
		this.startDate = startDate;
	}

	public Date getEndDate() {
		return endDate;
	}

	public void setEndDate(Date endDate) {
		this.endDate = endDate;
	}

	public String getSpecimenYn() {
		return specimenYn;
	}

	public void setSpecimenYn(String specimenYn) {
		this.specimenYn = specimenYn;
	}

	public String getSpecimenDefault() {
		return specimenDefault;
	}

	public void setSpecimenDefault(String specimenDefault) {
		this.specimenDefault = specimenDefault;
	}

	public String getDefaultPortableYn1() {
		return defaultPortableYn1;
	}

	public void setDefaultPortableYn1(String defaultPortableYn1) {
		this.defaultPortableYn1 = defaultPortableYn1;
	}

	public String getSpecificComment() {
		return specificComment;
	}

	public void setSpecificComment(String specificComment) {
		this.specificComment = specificComment;
	}

	public String getReserYnOut() {
		return reserYnOut;
	}

	public void setReserYnOut(String reserYnOut) {
		this.reserYnOut = reserYnOut;
	}

	public String getReserYnInp() {
		return reserYnInp;
	}

	public void setReserYnInp(String reserYnInp) {
		this.reserYnInp = reserYnInp;
	}

	public String getEmergency() {
		return emergency;
	}

	public void setEmergency(String emergency) {
		this.emergency = emergency;
	}

	public Double getLimitSuryang() {
		return limitSuryang;
	}

	public void setLimitSuryang(Double limitSuryang) {
		this.limitSuryang = limitSuryang;
	}

	public String getBomYn() {
		return bomYn;
	}

	public void setBomYn(String bomYn) {
		this.bomYn = bomYn;
	}

	public String getReturnYn() {
		return returnYn;
	}

	public void setReturnYn(String returnYn) {
		this.returnYn = returnYn;
	}

	public String getSubulConvertGubun() {
		return subulConvertGubun;
	}

	public void setSubulConvertGubun(String subulConvertGubun) {
		this.subulConvertGubun = subulConvertGubun;
	}

	public String getWonyoiOrderYn() {
		return wonyoiOrderYn;
	}

	public void setWonyoiOrderYn(String wonyoiOrderYn) {
		this.wonyoiOrderYn = wonyoiOrderYn;
	}

	public String getDefaultWonnaeSayu() {
		return defaultWonnaeSayu;
	}

	public void setDefaultWonnaeSayu(String defaultWonnaeSayu) {
		this.defaultWonnaeSayu = defaultWonnaeSayu;
	}

	public String getAntiCancerYn() {
		return antiCancerYn;
	}

	public void setAntiCancerYn(String antiCancerYn) {
		this.antiCancerYn = antiCancerYn;
	}

	public String getChisikYn() {
		return chisikYn;
	}

	public void setChisikYn(String chisikYn) {
		this.chisikYn = chisikYn;
	}

	public String getNdayYn() {
		return ndayYn;
	}

	public void setNdayYn(String ndayYn) {
		this.ndayYn = ndayYn;
	}

	public String getMuhyoYn() {
		return muhyoYn;
	}

	public void setMuhyoYn(String muhyoYn) {
		this.muhyoYn = muhyoYn;
	}

	public String getInvJundalYn() {
		return invJundalYn;
	}

	public void setInvJundalYn(String invJundalYn) {
		this.invJundalYn = invJundalYn;
	}

	public String getPowderYn() {
		return powderYn;
	}

	public void setPowderYn(String powderYn) {
		this.powderYn = powderYn;
	}

	public String getRemark() {
		return remark;
	}

	public void setRemark(String remark) {
		this.remark = remark;
	}

	public Double getDefaultDv() {
		return defaultDv;
	}

	public void setDefaultDv(Double defaultDv) {
		this.defaultDv = defaultDv;
	}

	public Double getDefaultSuryang() {
		return defaultSuryang;
	}

	public void setDefaultSuryang(Double defaultSuryang) {
		this.defaultSuryang = defaultSuryang;
	}

	public String getNurseInputYn() {
		return nurseInputYn;
	}

	public void setNurseInputYn(String nurseInputYn) {
		this.nurseInputYn = nurseInputYn;
	}

	public String getSupplyInputYn() {
		return supplyInputYn;
	}

	public void setSupplyInputYn(String supplyInputYn) {
		this.supplyInputYn = supplyInputYn;
	}

	public Double getLimitNalsu() {
		return limitNalsu;
	}

	public void setLimitNalsu(Double limitNalsu) {
		this.limitNalsu = limitNalsu;
	}

	public String getDefaultWonyoiYn() {
		return defaultWonyoiYn;
	}

	public void setDefaultWonyoiYn(String defaultWonyoiYn) {
		this.defaultWonyoiYn = defaultWonyoiYn;
	}

	public String getPortableCheck() {
		return portableCheck;
	}

	public void setPortableCheck(String portableCheck) {
		this.portableCheck = portableCheck;
	}

	public String getPatStatusGr() {
		return patStatusGr;
	}

	public void setPatStatusGr(String patStatusGr) {
		this.patStatusGr = patStatusGr;
	}

	public String getUpdId() {
		return updId;
	}

	public void setUpdId(String updId) {
		this.updId = updId;
	}

	public String getHospCode() {
		return hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}

	public String getDefaultJusa() {
		return defaultJusa;
	}

	public void setDefaultJusa(String defaultJusa) {
		this.defaultJusa = defaultJusa;
	}

	public String getSlipName() {
		return slipName;
	}

	public void setSlipName(String slipName) {
		this.slipName = slipName;
	}

	public String getJundalPartOutName() {
		return jundalPartOutName;
	}

	public void setJundalPartOutName(String jundalPartOutName) {
		this.jundalPartOutName = jundalPartOutName;
	}

	public String getJundalPartInpName() {
		return jundalPartInpName;
	}

	public void setJundalPartInpName(String jundalPartInpName) {
		this.jundalPartInpName = jundalPartInpName;
	}

	public String getMovePartName() {
		return movePartName;
	}

	public void setMovePartName(String movePartName) {
		this.movePartName = movePartName;
	}

	public String getJaeryoName() {
		return jaeryoName;
	}

	public void setJaeryoName(String jaeryoName) {
		this.jaeryoName = jaeryoName;
	}

	public String getSubulDanuiName() {
		return subulDanuiName;
	}

	public void setSubulDanuiName(String subulDanuiName) {
		this.subulDanuiName = subulDanuiName;
	}

	public String getJearyoBulyongDate() {
		return jearyoBulyongDate;
	}

	public void setJearyoBulyongDate(String jearyoBulyongDate) {
		this.jearyoBulyongDate = jearyoBulyongDate;
	}

	public String getDefaultBogyongName() {
		return defaultBogyongName;
	}

	public void setDefaultBogyongName(String defaultBogyongName) {
		this.defaultBogyongName = defaultBogyongName;
	}

	public String getTrial() {
		return trial;
	}

	public void setTrial(String trial) {
		this.trial = trial;
	}

	public String getIfInputControl() {
		return ifInputControl;
	}

	public void setIfInputControl(String ifInputControl) {
		this.ifInputControl = ifInputControl;
	}

	public String getHubalDrgYn() {
		return hubalDrgYn;
	}

	public void setHubalDrgYn(String hubalDrgYn) {
		this.hubalDrgYn = hubalDrgYn;
	}

	public String getSgName() {
		return sgName;
	}

	public void setSgName(String sgName) {
		this.sgName = sgName;
	}

	public String getSgDanuiName() {
		return sgDanuiName;
	}

	public void setSgDanuiName(String sgDanuiName) {
		this.sgDanuiName = sgDanuiName;
	}

	public String getBulyongYmd() {
		return bulyongYmd;
	}

	public void setBulyongYmd(String bulyongYmd) {
		this.bulyongYmd = bulyongYmd;
	}

	public String getResultGubun() {
		return resultGubun;
	}

	public void setResultGubun(String resultGubun) {
		this.resultGubun = resultGubun;
	}

	public String getWonnaeDrgYn() {
		return wonnaeDrgYn;
	}

	public void setWonnaeDrgYn(String wonnaeDrgYn) {
		this.wonnaeDrgYn = wonnaeDrgYn;
	}

	public String getYakKijunCode() {
		return yakKijunCode;
	}

	public void setYakKijunCode(String yakKijunCode) {
		this.yakKijunCode = yakKijunCode;
	}

	public String getYjCode() {
		return yjCode;
	}

	public void setYjCode(String yjCode) {
		this.yjCode = yjCode;
	}

	public String getIfCode() {
		return ifCode;
	}

	public void setIfCode(String ifCode) {
		this.ifCode = ifCode;
	}

	public String gettrial() {
		return trial;
	}

	public void settrial(String trial) {
		this.trial = trial;
	}

	public String getProtocol() {
		return protocol;
	}

	public void setProtocol(String protocol) {
		this.protocol = protocol;
	}

	public String getDefaultPortableYn2() {
		return defaultPortableYn2;
	}

	public void setDefaultPortableYn2(String defaultPortableYn2) {
		this.defaultPortableYn2 = defaultPortableYn2;
	}

	public String getCommonOrder() {
		return commonOrder;
	}

	public void setCommonOrder(String commonOrder) {
		this.commonOrder = commonOrder;
	}

	/*
	 * public String getOutHospBookYn() { return outHospBookYn; }
	 * 
	 * public void setOutHospBookYn(String outHospBookYn) { this.outHospBookYn =
	 * outHospBookYn; }
	 */

}
