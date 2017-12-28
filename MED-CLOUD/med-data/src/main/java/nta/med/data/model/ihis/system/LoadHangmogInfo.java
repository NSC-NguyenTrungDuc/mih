package nta.med.data.model.ihis.system;

public class LoadHangmogInfo {
	private String hangmogCode            ;
	private String yjCode;
	private String hangmogName            ;    
	private String slipCode               ;    
	private String groupYn                ;    
	private String inputTab               ;    
	private String orderGubun             ;    
	private String inputControl           ;    
	private String jundalTableOut        ;     
	private String jundalTableInp        ;     
	private String jundalPartOut         ;     
	private String jundalPartInp         ;     
	private String jaeryoJundalYnOut    ;      
	private String jaeryoJundalYnInp    ;      
	private String movePart               ;    
	private Double suryang                 ;   
	private String ordDanui               ;    
	private String dvTime                 ;    
	private Double dv                      ;   
	private String jusa                    ;   
	private String bogyongCode            ;   
	private String sugaYn                 ;    
	private String sgCode                 ;    
	private String jaeryoYn               ;    
	private String jaeryoCode             ;    
	private String bulyongYmd             ;    
	private String bulyongCheck           ;    
	private String bulyongCheckOut       ;     
	private String specimenYn             ;    
	private String specimenDefault        ;    
	private String portableYn             ;    
	private String portableCheck          ;    
	private String xrayBuwi               ;    
	private String reserYnOut            ;     
	private String reserYnInp            ;     
	private String emergency               ;   
	private String emergencyCheck         ;    
	private String bomYn                  ;    
	private String bichiYn                ;    
	private String wonyoiOrderYn         ;     
	private String wonyoiCheck            ;    
	private String powderYn               ;    
	private String powderCheck            ;    
	private String ndayYn                 ;    
	private String chisikYn               ;    
	private String muhyoYn                ;    
	private String nurseInputYn          ;     
	private String supplyInputYn         ;     
	private Double limitSuryang           ;    
	private Double limitNalsu             ;    
	private String remark                  ;   
	private String nurseConfirmGubun     ;     
	private String specificComment        ;    
	private String hubalChangeCheck      ;     
	private String pharmacyCheck          ;    
	private String drgPackCheck          ;     
	private String dummy                   ;   
	private String dummy1                  ;   
	private String dummy2                  ;   
	private String dummy3                  ;   
	private String dummy4                  ;   
	private String dummy5                  ;   
	private String dummy6                  ;   
	private String dummy7                  ;   
	private String dummy8                  ;   
	private String dummy9                  ;   
	private String flag                    ;   
	private String msg                     ;
	private String commonYn                ;
	
	public LoadHangmogInfo(){
	}

	public LoadHangmogInfo(String hangmogCode, String yjCode, String hangmogName, String slipCode, String groupYn,
			String inputTab, String orderGubun, String inputControl, String jundalTableOut, String jundalTableInp,
			String jundalPartOut, String jundalPartInp, String jaeryoJundalYnOut, String jaeryoJundalYnInp,
			String movePart, Double suryang, String ordDanui, String dvTime, Double dv, String jusa, String bogyongCode,
			String sugaYn, String sgCode, String jaeryoYn, String jaeryoCode, String bulyongYmd, String bulyongCheck,
			String bulyongCheckOut, String specimenYn, String specimenDefault, String portableYn, String portableCheck,
			String xrayBuwi, String reserYnOut, String reserYnInp, String emergency, String emergencyCheck,
			String bomYn, String bichiYn, String wonyoiOrderYn, String wonyoiCheck, String powderYn, String powderCheck,
			String ndayYn, String chisikYn, String muhyoYn, String nurseInputYn, String supplyInputYn,
			Double limitSuryang, Double limitNalsu, String remark, String nurseConfirmGubun, String specificComment,
			String hubalChangeCheck, String pharmacyCheck, String drgPackCheck, String dummy, String dummy1,
			String dummy2, String dummy3, String dummy4, String dummy5, String dummy6, String dummy7, String dummy8,
			String dummy9, String flag, String msg, String commonYn) {
		super();
		this.hangmogCode = hangmogCode;
		this.yjCode = yjCode;
		this.hangmogName = hangmogName;
		this.slipCode = slipCode;
		this.groupYn = groupYn;
		this.inputTab = inputTab;
		this.orderGubun = orderGubun;
		this.inputControl = inputControl;
		this.jundalTableOut = jundalTableOut;
		this.jundalTableInp = jundalTableInp;
		this.jundalPartOut = jundalPartOut;
		this.jundalPartInp = jundalPartInp;
		this.jaeryoJundalYnOut = jaeryoJundalYnOut;
		this.jaeryoJundalYnInp = jaeryoJundalYnInp;
		this.movePart = movePart;
		this.suryang = suryang;
		this.ordDanui = ordDanui;
		this.dvTime = dvTime;
		this.dv = dv;
		this.jusa = jusa;
		this.bogyongCode = bogyongCode;
		this.sugaYn = sugaYn;
		this.sgCode = sgCode;
		this.jaeryoYn = jaeryoYn;
		this.jaeryoCode = jaeryoCode;
		this.bulyongYmd = bulyongYmd;
		this.bulyongCheck = bulyongCheck;
		this.bulyongCheckOut = bulyongCheckOut;
		this.specimenYn = specimenYn;
		this.specimenDefault = specimenDefault;
		this.portableYn = portableYn;
		this.portableCheck = portableCheck;
		this.xrayBuwi = xrayBuwi;
		this.reserYnOut = reserYnOut;
		this.reserYnInp = reserYnInp;
		this.emergency = emergency;
		this.emergencyCheck = emergencyCheck;
		this.bomYn = bomYn;
		this.bichiYn = bichiYn;
		this.wonyoiOrderYn = wonyoiOrderYn;
		this.wonyoiCheck = wonyoiCheck;
		this.powderYn = powderYn;
		this.powderCheck = powderCheck;
		this.ndayYn = ndayYn;
		this.chisikYn = chisikYn;
		this.muhyoYn = muhyoYn;
		this.nurseInputYn = nurseInputYn;
		this.supplyInputYn = supplyInputYn;
		this.limitSuryang = limitSuryang;
		this.limitNalsu = limitNalsu;
		this.remark = remark;
		this.nurseConfirmGubun = nurseConfirmGubun;
		this.specificComment = specificComment;
		this.hubalChangeCheck = hubalChangeCheck;
		this.pharmacyCheck = pharmacyCheck;
		this.drgPackCheck = drgPackCheck;
		this.dummy = dummy;
		this.dummy1 = dummy1;
		this.dummy2 = dummy2;
		this.dummy3 = dummy3;
		this.dummy4 = dummy4;
		this.dummy5 = dummy5;
		this.dummy6 = dummy6;
		this.dummy7 = dummy7;
		this.dummy8 = dummy8;
		this.dummy9 = dummy9;
		this.flag = flag;
		this.msg = msg;
		this.commonYn = commonYn;
	}

	public String getHangmogCode() {
		return hangmogCode;
	}

	public void setHangmogCode(String hangmogCode) {
		this.hangmogCode = hangmogCode;
	}

	public String getYjCode() {
		return yjCode;
	}

	public void setYjCode(String yjCode) {
		this.yjCode = yjCode;
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

	public String getInputTab() {
		return inputTab;
	}

	public void setInputTab(String inputTab) {
		this.inputTab = inputTab;
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

	public String getJaeryoJundalYnOut() {
		return jaeryoJundalYnOut;
	}

	public void setJaeryoJundalYnOut(String jaeryoJundalYnOut) {
		this.jaeryoJundalYnOut = jaeryoJundalYnOut;
	}

	public String getJaeryoJundalYnInp() {
		return jaeryoJundalYnInp;
	}

	public void setJaeryoJundalYnInp(String jaeryoJundalYnInp) {
		this.jaeryoJundalYnInp = jaeryoJundalYnInp;
	}

	public String getMovePart() {
		return movePart;
	}

	public void setMovePart(String movePart) {
		this.movePart = movePart;
	}

	public Double getSuryang() {
		return suryang;
	}

	public void setSuryang(Double suryang) {
		this.suryang = suryang;
	}

	public String getOrdDanui() {
		return ordDanui;
	}

	public void setOrdDanui(String ordDanui) {
		this.ordDanui = ordDanui;
	}

	public String getDvTime() {
		return dvTime;
	}

	public void setDvTime(String dvTime) {
		this.dvTime = dvTime;
	}

	public Double getDv() {
		return dv;
	}

	public void setDv(Double dv) {
		this.dv = dv;
	}

	public String getJusa() {
		return jusa;
	}

	public void setJusa(String jusa) {
		this.jusa = jusa;
	}

	public String getBogyongCode() {
		return bogyongCode;
	}

	public void setBogyongCode(String bogyongCode) {
		this.bogyongCode = bogyongCode;
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

	public String getBulyongYmd() {
		return bulyongYmd;
	}

	public void setBulyongYmd(String bulyongYmd) {
		this.bulyongYmd = bulyongYmd;
	}

	public String getBulyongCheck() {
		return bulyongCheck;
	}

	public void setBulyongCheck(String bulyongCheck) {
		this.bulyongCheck = bulyongCheck;
	}

	public String getBulyongCheckOut() {
		return bulyongCheckOut;
	}

	public void setBulyongCheckOut(String bulyongCheckOut) {
		this.bulyongCheckOut = bulyongCheckOut;
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

	public String getPortableYn() {
		return portableYn;
	}

	public void setPortableYn(String portableYn) {
		this.portableYn = portableYn;
	}

	public String getPortableCheck() {
		return portableCheck;
	}

	public void setPortableCheck(String portableCheck) {
		this.portableCheck = portableCheck;
	}

	public String getXrayBuwi() {
		return xrayBuwi;
	}

	public void setXrayBuwi(String xrayBuwi) {
		this.xrayBuwi = xrayBuwi;
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

	public String getEmergencyCheck() {
		return emergencyCheck;
	}

	public void setEmergencyCheck(String emergencyCheck) {
		this.emergencyCheck = emergencyCheck;
	}

	public String getBomYn() {
		return bomYn;
	}

	public void setBomYn(String bomYn) {
		this.bomYn = bomYn;
	}

	public String getBichiYn() {
		return bichiYn;
	}

	public void setBichiYn(String bichiYn) {
		this.bichiYn = bichiYn;
	}

	public String getWonyoiOrderYn() {
		return wonyoiOrderYn;
	}

	public void setWonyoiOrderYn(String wonyoiOrderYn) {
		this.wonyoiOrderYn = wonyoiOrderYn;
	}

	public String getWonyoiCheck() {
		return wonyoiCheck;
	}

	public void setWonyoiCheck(String wonyoiCheck) {
		this.wonyoiCheck = wonyoiCheck;
	}

	public String getPowderYn() {
		return powderYn;
	}

	public void setPowderYn(String powderYn) {
		this.powderYn = powderYn;
	}

	public String getPowderCheck() {
		return powderCheck;
	}

	public void setPowderCheck(String powderCheck) {
		this.powderCheck = powderCheck;
	}

	public String getNdayYn() {
		return ndayYn;
	}

	public void setNdayYn(String ndayYn) {
		this.ndayYn = ndayYn;
	}

	public String getChisikYn() {
		return chisikYn;
	}

	public void setChisikYn(String chisikYn) {
		this.chisikYn = chisikYn;
	}

	public String getMuhyoYn() {
		return muhyoYn;
	}

	public void setMuhyoYn(String muhyoYn) {
		this.muhyoYn = muhyoYn;
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

	public Double getLimitSuryang() {
		return limitSuryang;
	}

	public void setLimitSuryang(Double limitSuryang) {
		this.limitSuryang = limitSuryang;
	}

	public Double getLimitNalsu() {
		return limitNalsu;
	}

	public void setLimitNalsu(Double limitNalsu) {
		this.limitNalsu = limitNalsu;
	}

	public String getRemark() {
		return remark;
	}

	public void setRemark(String remark) {
		this.remark = remark;
	}

	public String getNurseConfirmGubun() {
		return nurseConfirmGubun;
	}

	public void setNurseConfirmGubun(String nurseConfirmGubun) {
		this.nurseConfirmGubun = nurseConfirmGubun;
	}

	public String getSpecificComment() {
		return specificComment;
	}

	public void setSpecificComment(String specificComment) {
		this.specificComment = specificComment;
	}

	public String getHubalChangeCheck() {
		return hubalChangeCheck;
	}

	public void setHubalChangeCheck(String hubalChangeCheck) {
		this.hubalChangeCheck = hubalChangeCheck;
	}

	public String getPharmacyCheck() {
		return pharmacyCheck;
	}

	public void setPharmacyCheck(String pharmacyCheck) {
		this.pharmacyCheck = pharmacyCheck;
	}

	public String getDrgPackCheck() {
		return drgPackCheck;
	}

	public void setDrgPackCheck(String drgPackCheck) {
		this.drgPackCheck = drgPackCheck;
	}

	public String getDummy() {
		return dummy;
	}

	public void setDummy(String dummy) {
		this.dummy = dummy;
	}

	public String getDummy1() {
		return dummy1;
	}

	public void setDummy1(String dummy1) {
		this.dummy1 = dummy1;
	}

	public String getDummy2() {
		return dummy2;
	}

	public void setDummy2(String dummy2) {
		this.dummy2 = dummy2;
	}

	public String getDummy3() {
		return dummy3;
	}

	public void setDummy3(String dummy3) {
		this.dummy3 = dummy3;
	}

	public String getDummy4() {
		return dummy4;
	}

	public void setDummy4(String dummy4) {
		this.dummy4 = dummy4;
	}

	public String getDummy5() {
		return dummy5;
	}

	public void setDummy5(String dummy5) {
		this.dummy5 = dummy5;
	}

	public String getDummy6() {
		return dummy6;
	}

	public void setDummy6(String dummy6) {
		this.dummy6 = dummy6;
	}

	public String getDummy7() {
		return dummy7;
	}

	public void setDummy7(String dummy7) {
		this.dummy7 = dummy7;
	}

	public String getDummy8() {
		return dummy8;
	}

	public void setDummy8(String dummy8) {
		this.dummy8 = dummy8;
	}

	public String getDummy9() {
		return dummy9;
	}

	public void setDummy9(String dummy9) {
		this.dummy9 = dummy9;
	}

	public String getFlag() {
		return flag;
	}

	public void setFlag(String flag) {
		this.flag = flag;
	}

	public String getMsg() {
		return msg;
	}

	public void setMsg(String msg) {
		this.msg = msg;
	}

	public String getCommonYn() {
		return commonYn;
	}

	public void setCommonYn(String commonYn) {
		this.commonYn = commonYn;
	};
	
}
