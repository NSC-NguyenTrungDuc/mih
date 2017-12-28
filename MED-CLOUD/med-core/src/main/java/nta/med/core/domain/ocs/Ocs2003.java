package nta.med.core.domain.ocs;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;


/**
 * The persistent class for the OCS2003 database table.
 * 
 */
@Entity
@Table(name="OCS2003")
public class Ocs2003 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String actBuseo;
	private String actDoctor;
	private String actGwa;
	private Date actingDate;
	private Double actingDay;
	private String actingTime;
	private Double amt;
	private String antiCancerYn;
	private String appendYn;
	private Date approveDate;
	private String approveId;
	private String approveTime;
	private String approveYn;
	private String bannabConfirm;
	private String bannabConfirmUser;
	private String bannabYn;
	private String bichiYn;
	private String bogyongCode;
	private String bogyongCodeSub;
	private String bomOccurYn;
	private Double bomSourceKey;
	private String broughtDrgYn;
	private String bunho;
	private String chisik;
	private String dcGubun;
	private String dcYn;
	private String displayYn;
	private String doctor;
	private String donerYn;
	private Double drgBunho;
	private String drgPackYn;
	private String drugTime;
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
	private String errorFlag;
	private Double fkinp1001;
	private Double fkinp3010;
	private Double fkocs1003;
	private Double fkocs6007;
	private String generalDispYn;
	private String gongbiCode;
	private Double groupSer;
	private String hangmogCode;
	private String hangmogName;
	private Date hopeDate;
	private String hopeTime;
	private String hospCode;
	private String hubalChangeYn;
	private String ifActSendYn;
	private Date ifDataSendDate;
	private String ifDataSendYn;
	private String imsiDrugYn;
	private String inputDoctor;
	private String inputGubun;
	private String inputGwa;
	private String inputId;
	private String inputPart;
	private String inputTab;
	private Date insteadDate;
	private String insteadId;
	private String insteadTime;
	private String insteadYn;
	private String ioGubun;
	private String ipwonType;
	private String jaeryoJundalYn;
	private Date jubsuDate;
	private String jubsuTime;
	private String jundalPart;
	private String jundalPartRun;
	private String jundalTable;
	private String jusa;
	private String jusaSpdGubun;
	private String labelPrintYn;
	private Double marumeFkocs2016;
	private String mixGroup;
	private String movePart;
	private String muhyo;
	private Double nalsu;
	private String ndayOccurYn;
	private String ndayYn;
	private Date nurseActDate;
	private String nurseActTime;
	private String nurseActUser;
	private Date nurseConfirmDate;
	private String nurseConfirmTime;
	private String nurseConfirmUser;
	private Date nurseHoldDate;
	private String nurseHoldTime;
	private String nurseHoldUser;
	private Date nursePickupDate;
	private String nursePickupTime;
	private String nursePickupUser;
	private String nurseRemark;
	private String nurseUpdate;
	private String ocsFlag;
	private String ordDanui;
	private Date orderDate;
	private String orderGubun;
	private String orderRemark;
	private String orderTime;
	private String pay;
	private String pharmacy;
	private Double pkocs1024;
	private Double pkocs2003;
	private String portableYn;
	private String postapproveYn;
	private String powderYn;
	private String prepareYn;
	private String printYn;
	private String prnNurse;
	private String prnYn;
	private String regularYn;
	private Date reserDate;
	private String reserTime;
	private String resident;
	private Date resultDate;
	private String returnRemark;
	private Double sanmoFkinp1001;
	private Double seq;
	private String sgCode;
	private Date sgYmd;
	private String slipCode;
	private Double sortFkocskey;
	private Double sourceFkocs2003;
	private String specimenCode;
	private String subSusul;
	private String subulDanui;
	private Double subulSuryang;
	private String sunabDanui;
	private Date sunabDate;
	private Double sunabSuryang;
	private Double suryang;
	private Date sysDate;
	private String sysId;
	private String telYn;
	private String toiwonDrgYn;
	private Date updDate;
	private String updId;
	private String wonyoiOrderYn;
	private String xrtDrYn;

	private Date startDate;
	private String startTime;
	private String startId;	
	private Date endDate;
	private String endTime;
	private String endId;
	
	public Ocs2003() {
	}


	@Column(name="ACT_BUSEO")
	public String getActBuseo() {
		return this.actBuseo;
	}

	public void setActBuseo(String actBuseo) {
		this.actBuseo = actBuseo;
	}


	@Column(name="ACT_DOCTOR")
	public String getActDoctor() {
		return this.actDoctor;
	}

	public void setActDoctor(String actDoctor) {
		this.actDoctor = actDoctor;
	}


	@Column(name="ACT_GWA")
	public String getActGwa() {
		return this.actGwa;
	}

	public void setActGwa(String actGwa) {
		this.actGwa = actGwa;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="ACTING_DATE")
	public Date getActingDate() {
		return this.actingDate;
	}

	public void setActingDate(Date actingDate) {
		this.actingDate = actingDate;
	}


	@Column(name="ACTING_DAY")
	public Double getActingDay() {
		return this.actingDay;
	}

	public void setActingDay(Double actingDay) {
		this.actingDay = actingDay;
	}


	@Column(name="ACTING_TIME")
	public String getActingTime() {
		return this.actingTime;
	}

	public void setActingTime(String actingTime) {
		this.actingTime = actingTime;
	}


	public Double getAmt() {
		return this.amt;
	}

	public void setAmt(Double amt) {
		this.amt = amt;
	}


	@Column(name="ANTI_CANCER_YN")
	public String getAntiCancerYn() {
		return this.antiCancerYn;
	}

	public void setAntiCancerYn(String antiCancerYn) {
		this.antiCancerYn = antiCancerYn;
	}


	@Column(name="APPEND_YN")
	public String getAppendYn() {
		return this.appendYn;
	}

	public void setAppendYn(String appendYn) {
		this.appendYn = appendYn;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="APPROVE_DATE")
	public Date getApproveDate() {
		return this.approveDate;
	}

	public void setApproveDate(Date approveDate) {
		this.approveDate = approveDate;
	}


	@Column(name="APPROVE_ID")
	public String getApproveId() {
		return this.approveId;
	}

	public void setApproveId(String approveId) {
		this.approveId = approveId;
	}


	@Column(name="APPROVE_TIME")
	public String getApproveTime() {
		return this.approveTime;
	}

	public void setApproveTime(String approveTime) {
		this.approveTime = approveTime;
	}


	@Column(name="APPROVE_YN")
	public String getApproveYn() {
		return this.approveYn;
	}

	public void setApproveYn(String approveYn) {
		this.approveYn = approveYn;
	}


	@Column(name="BANNAB_CONFIRM")
	public String getBannabConfirm() {
		return this.bannabConfirm;
	}

	public void setBannabConfirm(String bannabConfirm) {
		this.bannabConfirm = bannabConfirm;
	}


	@Column(name="BANNAB_CONFIRM_USER")
	public String getBannabConfirmUser() {
		return this.bannabConfirmUser;
	}

	public void setBannabConfirmUser(String bannabConfirmUser) {
		this.bannabConfirmUser = bannabConfirmUser;
	}


	@Column(name="BANNAB_YN")
	public String getBannabYn() {
		return this.bannabYn;
	}

	public void setBannabYn(String bannabYn) {
		this.bannabYn = bannabYn;
	}


	@Column(name="BICHI_YN")
	public String getBichiYn() {
		return this.bichiYn;
	}

	public void setBichiYn(String bichiYn) {
		this.bichiYn = bichiYn;
	}


	@Column(name="BOGYONG_CODE")
	public String getBogyongCode() {
		return this.bogyongCode;
	}

	public void setBogyongCode(String bogyongCode) {
		this.bogyongCode = bogyongCode;
	}


	@Column(name="BOGYONG_CODE_SUB")
	public String getBogyongCodeSub() {
		return this.bogyongCodeSub;
	}

	public void setBogyongCodeSub(String bogyongCodeSub) {
		this.bogyongCodeSub = bogyongCodeSub;
	}


	@Column(name="BOM_OCCUR_YN")
	public String getBomOccurYn() {
		return this.bomOccurYn;
	}

	public void setBomOccurYn(String bomOccurYn) {
		this.bomOccurYn = bomOccurYn;
	}


	@Column(name="BOM_SOURCE_KEY")
	public Double getBomSourceKey() {
		return this.bomSourceKey;
	}

	public void setBomSourceKey(Double bomSourceKey) {
		this.bomSourceKey = bomSourceKey;
	}


	@Column(name="BROUGHT_DRG_YN")
	public String getBroughtDrgYn() {
		return this.broughtDrgYn;
	}

	public void setBroughtDrgYn(String broughtDrgYn) {
		this.broughtDrgYn = broughtDrgYn;
	}


	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}


	public String getChisik() {
		return this.chisik;
	}

	public void setChisik(String chisik) {
		this.chisik = chisik;
	}


	@Column(name="DC_GUBUN")
	public String getDcGubun() {
		return this.dcGubun;
	}

	public void setDcGubun(String dcGubun) {
		this.dcGubun = dcGubun;
	}


	@Column(name="DC_YN")
	public String getDcYn() {
		return this.dcYn;
	}

	public void setDcYn(String dcYn) {
		this.dcYn = dcYn;
	}


	@Column(name="DISPLAY_YN")
	public String getDisplayYn() {
		return this.displayYn;
	}

	public void setDisplayYn(String displayYn) {
		this.displayYn = displayYn;
	}


	public String getDoctor() {
		return this.doctor;
	}

	public void setDoctor(String doctor) {
		this.doctor = doctor;
	}


	@Column(name="DONER_YN")
	public String getDonerYn() {
		return this.donerYn;
	}

	public void setDonerYn(String donerYn) {
		this.donerYn = donerYn;
	}


	@Column(name="DRG_BUNHO")
	public Double getDrgBunho() {
		return this.drgBunho;
	}

	public void setDrgBunho(Double drgBunho) {
		this.drgBunho = drgBunho;
	}


	@Column(name="DRG_PACK_YN")
	public String getDrgPackYn() {
		return this.drgPackYn;
	}

	public void setDrgPackYn(String drgPackYn) {
		this.drgPackYn = drgPackYn;
	}


	@Column(name="DRUG_TIME")
	public String getDrugTime() {
		return this.drugTime;
	}

	public void setDrugTime(String drugTime) {
		this.drugTime = drugTime;
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


	@Column(name="ERROR_FLAG")
	public String getErrorFlag() {
		return this.errorFlag;
	}

	public void setErrorFlag(String errorFlag) {
		this.errorFlag = errorFlag;
	}


	public Double getFkinp1001() {
		return this.fkinp1001;
	}

	public void setFkinp1001(Double fkinp1001) {
		this.fkinp1001 = fkinp1001;
	}


	public Double getFkinp3010() {
		return this.fkinp3010;
	}

	public void setFkinp3010(Double fkinp3010) {
		this.fkinp3010 = fkinp3010;
	}


	public Double getFkocs1003() {
		return this.fkocs1003;
	}

	public void setFkocs1003(Double fkocs1003) {
		this.fkocs1003 = fkocs1003;
	}


	public Double getFkocs6007() {
		return this.fkocs6007;
	}

	public void setFkocs6007(Double fkocs6007) {
		this.fkocs6007 = fkocs6007;
	}


	@Column(name="GENERAL_DISP_YN")
	public String getGeneralDispYn() {
		return this.generalDispYn;
	}

	public void setGeneralDispYn(String generalDispYn) {
		this.generalDispYn = generalDispYn;
	}


	@Column(name="GONGBI_CODE")
	public String getGongbiCode() {
		return this.gongbiCode;
	}

	public void setGongbiCode(String gongbiCode) {
		this.gongbiCode = gongbiCode;
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


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="HOPE_DATE")
	public Date getHopeDate() {
		return this.hopeDate;
	}

	public void setHopeDate(Date hopeDate) {
		this.hopeDate = hopeDate;
	}


	@Column(name="HOPE_TIME")
	public String getHopeTime() {
		return this.hopeTime;
	}

	public void setHopeTime(String hopeTime) {
		this.hopeTime = hopeTime;
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


	@Column(name="IF_ACT_SEND_YN")
	public String getIfActSendYn() {
		return this.ifActSendYn;
	}

	public void setIfActSendYn(String ifActSendYn) {
		this.ifActSendYn = ifActSendYn;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="IF_DATA_SEND_DATE")
	public Date getIfDataSendDate() {
		return this.ifDataSendDate;
	}

	public void setIfDataSendDate(Date ifDataSendDate) {
		this.ifDataSendDate = ifDataSendDate;
	}


	@Column(name="IF_DATA_SEND_YN")
	public String getIfDataSendYn() {
		return this.ifDataSendYn;
	}

	public void setIfDataSendYn(String ifDataSendYn) {
		this.ifDataSendYn = ifDataSendYn;
	}


	@Column(name="IMSI_DRUG_YN")
	public String getImsiDrugYn() {
		return this.imsiDrugYn;
	}

	public void setImsiDrugYn(String imsiDrugYn) {
		this.imsiDrugYn = imsiDrugYn;
	}


	@Column(name="INPUT_DOCTOR")
	public String getInputDoctor() {
		return this.inputDoctor;
	}

	public void setInputDoctor(String inputDoctor) {
		this.inputDoctor = inputDoctor;
	}


	@Column(name="INPUT_GUBUN")
	public String getInputGubun() {
		return this.inputGubun;
	}

	public void setInputGubun(String inputGubun) {
		this.inputGubun = inputGubun;
	}


	@Column(name="INPUT_GWA")
	public String getInputGwa() {
		return this.inputGwa;
	}

	public void setInputGwa(String inputGwa) {
		this.inputGwa = inputGwa;
	}


	@Column(name="INPUT_ID")
	public String getInputId() {
		return this.inputId;
	}

	public void setInputId(String inputId) {
		this.inputId = inputId;
	}


	@Column(name="INPUT_PART")
	public String getInputPart() {
		return this.inputPart;
	}

	public void setInputPart(String inputPart) {
		this.inputPart = inputPart;
	}


	@Column(name="INPUT_TAB")
	public String getInputTab() {
		return this.inputTab;
	}

	public void setInputTab(String inputTab) {
		this.inputTab = inputTab;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="INSTEAD_DATE")
	public Date getInsteadDate() {
		return this.insteadDate;
	}

	public void setInsteadDate(Date insteadDate) {
		this.insteadDate = insteadDate;
	}


	@Column(name="INSTEAD_ID")
	public String getInsteadId() {
		return this.insteadId;
	}

	public void setInsteadId(String insteadId) {
		this.insteadId = insteadId;
	}


	@Column(name="INSTEAD_TIME")
	public String getInsteadTime() {
		return this.insteadTime;
	}

	public void setInsteadTime(String insteadTime) {
		this.insteadTime = insteadTime;
	}


	@Column(name="INSTEAD_YN")
	public String getInsteadYn() {
		return this.insteadYn;
	}

	public void setInsteadYn(String insteadYn) {
		this.insteadYn = insteadYn;
	}


	@Column(name="IO_GUBUN")
	public String getIoGubun() {
		return this.ioGubun;
	}

	public void setIoGubun(String ioGubun) {
		this.ioGubun = ioGubun;
	}


	@Column(name="IPWON_TYPE")
	public String getIpwonType() {
		return this.ipwonType;
	}

	public void setIpwonType(String ipwonType) {
		this.ipwonType = ipwonType;
	}


	@Column(name="JAERYO_JUNDAL_YN")
	public String getJaeryoJundalYn() {
		return this.jaeryoJundalYn;
	}

	public void setJaeryoJundalYn(String jaeryoJundalYn) {
		this.jaeryoJundalYn = jaeryoJundalYn;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="JUBSU_DATE")
	public Date getJubsuDate() {
		return this.jubsuDate;
	}

	public void setJubsuDate(Date jubsuDate) {
		this.jubsuDate = jubsuDate;
	}


	@Column(name="JUBSU_TIME")
	public String getJubsuTime() {
		return this.jubsuTime;
	}

	public void setJubsuTime(String jubsuTime) {
		this.jubsuTime = jubsuTime;
	}


	@Column(name="JUNDAL_PART")
	public String getJundalPart() {
		return this.jundalPart;
	}

	public void setJundalPart(String jundalPart) {
		this.jundalPart = jundalPart;
	}


	@Column(name="JUNDAL_PART_RUN")
	public String getJundalPartRun() {
		return this.jundalPartRun;
	}

	public void setJundalPartRun(String jundalPartRun) {
		this.jundalPartRun = jundalPartRun;
	}


	@Column(name="JUNDAL_TABLE")
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


	@Column(name="JUSA_SPD_GUBUN")
	public String getJusaSpdGubun() {
		return this.jusaSpdGubun;
	}

	public void setJusaSpdGubun(String jusaSpdGubun) {
		this.jusaSpdGubun = jusaSpdGubun;
	}


	@Column(name="LABEL_PRINT_YN")
	public String getLabelPrintYn() {
		return this.labelPrintYn;
	}

	public void setLabelPrintYn(String labelPrintYn) {
		this.labelPrintYn = labelPrintYn;
	}


	@Column(name="MARUME_FKOCS2016")
	public Double getMarumeFkocs2016() {
		return this.marumeFkocs2016;
	}

	public void setMarumeFkocs2016(Double marumeFkocs2016) {
		this.marumeFkocs2016 = marumeFkocs2016;
	}


	@Column(name="MIX_GROUP")
	public String getMixGroup() {
		return this.mixGroup;
	}

	public void setMixGroup(String mixGroup) {
		this.mixGroup = mixGroup;
	}


	@Column(name="MOVE_PART")
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


	@Column(name="NDAY_OCCUR_YN")
	public String getNdayOccurYn() {
		return this.ndayOccurYn;
	}

	public void setNdayOccurYn(String ndayOccurYn) {
		this.ndayOccurYn = ndayOccurYn;
	}


	@Column(name="NDAY_YN")
	public String getNdayYn() {
		return this.ndayYn;
	}

	public void setNdayYn(String ndayYn) {
		this.ndayYn = ndayYn;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="NURSE_ACT_DATE")
	public Date getNurseActDate() {
		return this.nurseActDate;
	}

	public void setNurseActDate(Date nurseActDate) {
		this.nurseActDate = nurseActDate;
	}


	@Column(name="NURSE_ACT_TIME")
	public String getNurseActTime() {
		return this.nurseActTime;
	}

	public void setNurseActTime(String nurseActTime) {
		this.nurseActTime = nurseActTime;
	}


	@Column(name="NURSE_ACT_USER")
	public String getNurseActUser() {
		return this.nurseActUser;
	}

	public void setNurseActUser(String nurseActUser) {
		this.nurseActUser = nurseActUser;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="NURSE_CONFIRM_DATE")
	public Date getNurseConfirmDate() {
		return this.nurseConfirmDate;
	}

	public void setNurseConfirmDate(Date nurseConfirmDate) {
		this.nurseConfirmDate = nurseConfirmDate;
	}


	@Column(name="NURSE_CONFIRM_TIME")
	public String getNurseConfirmTime() {
		return this.nurseConfirmTime;
	}

	public void setNurseConfirmTime(String nurseConfirmTime) {
		this.nurseConfirmTime = nurseConfirmTime;
	}


	@Column(name="NURSE_CONFIRM_USER")
	public String getNurseConfirmUser() {
		return this.nurseConfirmUser;
	}

	public void setNurseConfirmUser(String nurseConfirmUser) {
		this.nurseConfirmUser = nurseConfirmUser;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="NURSE_HOLD_DATE")
	public Date getNurseHoldDate() {
		return this.nurseHoldDate;
	}

	public void setNurseHoldDate(Date nurseHoldDate) {
		this.nurseHoldDate = nurseHoldDate;
	}


	@Column(name="NURSE_HOLD_TIME")
	public String getNurseHoldTime() {
		return this.nurseHoldTime;
	}

	public void setNurseHoldTime(String nurseHoldTime) {
		this.nurseHoldTime = nurseHoldTime;
	}


	@Column(name="NURSE_HOLD_USER")
	public String getNurseHoldUser() {
		return this.nurseHoldUser;
	}

	public void setNurseHoldUser(String nurseHoldUser) {
		this.nurseHoldUser = nurseHoldUser;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="NURSE_PICKUP_DATE")
	public Date getNursePickupDate() {
		return this.nursePickupDate;
	}

	public void setNursePickupDate(Date nursePickupDate) {
		this.nursePickupDate = nursePickupDate;
	}


	@Column(name="NURSE_PICKUP_TIME")
	public String getNursePickupTime() {
		return this.nursePickupTime;
	}

	public void setNursePickupTime(String nursePickupTime) {
		this.nursePickupTime = nursePickupTime;
	}


	@Column(name="NURSE_PICKUP_USER")
	public String getNursePickupUser() {
		return this.nursePickupUser;
	}

	public void setNursePickupUser(String nursePickupUser) {
		this.nursePickupUser = nursePickupUser;
	}


	@Column(name="NURSE_REMARK")
	public String getNurseRemark() {
		return this.nurseRemark;
	}

	public void setNurseRemark(String nurseRemark) {
		this.nurseRemark = nurseRemark;
	}


	@Column(name="NURSE_UPDATE")
	public String getNurseUpdate() {
		return this.nurseUpdate;
	}

	public void setNurseUpdate(String nurseUpdate) {
		this.nurseUpdate = nurseUpdate;
	}


	@Column(name="OCS_FLAG")
	public String getOcsFlag() {
		return this.ocsFlag;
	}

	public void setOcsFlag(String ocsFlag) {
		this.ocsFlag = ocsFlag;
	}


	@Column(name="ORD_DANUI")
	public String getOrdDanui() {
		return this.ordDanui;
	}

	public void setOrdDanui(String ordDanui) {
		this.ordDanui = ordDanui;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="ORDER_DATE")
	public Date getOrderDate() {
		return this.orderDate;
	}

	public void setOrderDate(Date orderDate) {
		this.orderDate = orderDate;
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


	@Column(name="ORDER_TIME")
	public String getOrderTime() {
		return this.orderTime;
	}

	public void setOrderTime(String orderTime) {
		this.orderTime = orderTime;
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


	public Double getPkocs1024() {
		return this.pkocs1024;
	}

	public void setPkocs1024(Double pkocs1024) {
		this.pkocs1024 = pkocs1024;
	}


	public Double getPkocs2003() {
		return this.pkocs2003;
	}

	public void setPkocs2003(Double pkocs2003) {
		this.pkocs2003 = pkocs2003;
	}


	@Column(name="PORTABLE_YN")
	public String getPortableYn() {
		return this.portableYn;
	}

	public void setPortableYn(String portableYn) {
		this.portableYn = portableYn;
	}


	@Column(name="POSTAPPROVE_YN")
	public String getPostapproveYn() {
		return this.postapproveYn;
	}

	public void setPostapproveYn(String postapproveYn) {
		this.postapproveYn = postapproveYn;
	}


	@Column(name="POWDER_YN")
	public String getPowderYn() {
		return this.powderYn;
	}

	public void setPowderYn(String powderYn) {
		this.powderYn = powderYn;
	}


	@Column(name="PREPARE_YN")
	public String getPrepareYn() {
		return this.prepareYn;
	}

	public void setPrepareYn(String prepareYn) {
		this.prepareYn = prepareYn;
	}


	@Column(name="PRINT_YN")
	public String getPrintYn() {
		return this.printYn;
	}

	public void setPrintYn(String printYn) {
		this.printYn = printYn;
	}


	@Column(name="PRN_NURSE")
	public String getPrnNurse() {
		return this.prnNurse;
	}

	public void setPrnNurse(String prnNurse) {
		this.prnNurse = prnNurse;
	}


	@Column(name="PRN_YN")
	public String getPrnYn() {
		return this.prnYn;
	}

	public void setPrnYn(String prnYn) {
		this.prnYn = prnYn;
	}


	@Column(name="REGULAR_YN")
	public String getRegularYn() {
		return this.regularYn;
	}

	public void setRegularYn(String regularYn) {
		this.regularYn = regularYn;
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


	public String getResident() {
		return this.resident;
	}

	public void setResident(String resident) {
		this.resident = resident;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="RESULT_DATE")
	public Date getResultDate() {
		return this.resultDate;
	}

	public void setResultDate(Date resultDate) {
		this.resultDate = resultDate;
	}


	@Column(name="RETURN_REMARK")
	public String getReturnRemark() {
		return this.returnRemark;
	}

	public void setReturnRemark(String returnRemark) {
		this.returnRemark = returnRemark;
	}


	@Column(name="SANMO_FKINP1001")
	public Double getSanmoFkinp1001() {
		return this.sanmoFkinp1001;
	}

	public void setSanmoFkinp1001(Double sanmoFkinp1001) {
		this.sanmoFkinp1001 = sanmoFkinp1001;
	}


	public Double getSeq() {
		return this.seq;
	}

	public void setSeq(Double seq) {
		this.seq = seq;
	}


	@Column(name="SG_CODE")
	public String getSgCode() {
		return this.sgCode;
	}

	public void setSgCode(String sgCode) {
		this.sgCode = sgCode;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="SG_YMD")
	public Date getSgYmd() {
		return this.sgYmd;
	}

	public void setSgYmd(Date sgYmd) {
		this.sgYmd = sgYmd;
	}


	@Column(name="SLIP_CODE")
	public String getSlipCode() {
		return this.slipCode;
	}

	public void setSlipCode(String slipCode) {
		this.slipCode = slipCode;
	}


	@Column(name="SORT_FKOCSKEY")
	public Double getSortFkocskey() {
		return this.sortFkocskey;
	}

	public void setSortFkocskey(Double sortFkocskey) {
		this.sortFkocskey = sortFkocskey;
	}


	@Column(name="SOURCE_FKOCS2003")
	public Double getSourceFkocs2003() {
		return this.sourceFkocs2003;
	}

	public void setSourceFkocs2003(Double sourceFkocs2003) {
		this.sourceFkocs2003 = sourceFkocs2003;
	}


	@Column(name="SPECIMEN_CODE")
	public String getSpecimenCode() {
		return this.specimenCode;
	}

	public void setSpecimenCode(String specimenCode) {
		this.specimenCode = specimenCode;
	}


	@Column(name="SUB_SUSUL")
	public String getSubSusul() {
		return this.subSusul;
	}

	public void setSubSusul(String subSusul) {
		this.subSusul = subSusul;
	}


	@Column(name="SUBUL_DANUI")
	public String getSubulDanui() {
		return this.subulDanui;
	}

	public void setSubulDanui(String subulDanui) {
		this.subulDanui = subulDanui;
	}


	@Column(name="SUBUL_SURYANG")
	public Double getSubulSuryang() {
		return this.subulSuryang;
	}

	public void setSubulSuryang(Double subulSuryang) {
		this.subulSuryang = subulSuryang;
	}


	@Column(name="SUNAB_DANUI")
	public String getSunabDanui() {
		return this.sunabDanui;
	}

	public void setSunabDanui(String sunabDanui) {
		this.sunabDanui = sunabDanui;
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


	@Column(name="TEL_YN")
	public String getTelYn() {
		return this.telYn;
	}

	public void setTelYn(String telYn) {
		this.telYn = telYn;
	}


	@Column(name="TOIWON_DRG_YN")
	public String getToiwonDrgYn() {
		return this.toiwonDrgYn;
	}

	public void setToiwonDrgYn(String toiwonDrgYn) {
		this.toiwonDrgYn = toiwonDrgYn;
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


	@Column(name="XRT_DR_YN")
	public String getXrtDrYn() {
		return this.xrtDrYn;
	}

	public void setXrtDrYn(String xrtDrYn) {
		this.xrtDrYn = xrtDrYn;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="START_DATE")
	public Date getStartDate() {
		return startDate;
	}


	public void setStartDate(Date startDate) {
		this.startDate = startDate;
	}


	@Column(name="START_TIME")
	public String getStartTime() {
		return startTime;
	}


	public void setStartTime(String startTime) {
		this.startTime = startTime;
	}


	@Column(name="START_ID")
	public String getStartId() {
		return startId;
	}


	public void setStartId(String startId) {
		this.startId = startId;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="END_DATE")
	public Date getEndDate() {
		return endDate;
	}


	public void setEndDate(Date endDate) {
		this.endDate = endDate;
	}

	@Column(name="END_TIME")
	public String getEndTime() {
		return endTime;
	}


	public void setEndTime(String endTime) {
		this.endTime = endTime;
	}


	@Column(name="END_ID")
	public String getEndId() {
		return endId;
	}


	public void setEndId(String endId) {
		this.endId = endId;
	}	

}