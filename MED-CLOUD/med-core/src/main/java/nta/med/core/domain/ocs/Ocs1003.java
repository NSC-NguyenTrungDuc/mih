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
 * The persistent class for the OCS1003 database table.
 * 
 */
@Entity
@Table(name="OCS1003")
public class Ocs1003 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String actBuseo;
	private String actDoctor;
	private String actGwa;
	private Date actingDate;
	private Double actingDay;
	private String actingTime;
	private String afterActYn;
	private Double amt;
	private String antiCancerYn;
	private Date approveDate;
	private String approveId;
	private String approveTime;
	private String approveYn;
	private String bannabConfirm;
	private String bannabYn;
	private String bichiYn;
	private String bogyongCode;
	private String bogyongCodeSub;
	private String bomOccurYn;
	private Double bomSourceKey;
	private String bunho;
	private String chisik;
	private String dangilGumsaOrderYn;
	private String dangilGumsaResultYn;
	private String dcGubun;
	private String dcYn;
	private String displayYn;
	private String doctor;
	private Double drgBunho;
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
	private BigDecimal fkout1001;
	private Double fkout1003;
	private String generalDispYn;
	private String gongbiCode;
	private Double groupSer;
	private String gwa;
	private String hangmogCode;
	private String hangmogName;
	private String homeCareYn;
	private Date hopeDate;
	private String hopeTime;
	private String hospCode;
	private String hubalChangeYn;
	private String ifActSendYn;
	private Date ifDataSendDate;
	private String ifDataSendYn;
	private String imsiDrugYn;
	private String inputGubun;
	private String inputId;
	private String inputPart;
	private String inputTab;
	private Date insteadDate;
	private String insteadId;
	private String insteadTime;
	private String insteadYn;
	private String ioGubun;
	private String jaeryoJundalYn;
	private Date jubsuDate;
	private String jubsuTime;
	private String jundalPart;
	private String jundalTable;
	private String jusa;
	private String jusaSpdGubun;
	private String mixGroup;
	private String movePart;
	private String muhyo;
	private String naewonType;
	private Double nalsu;
	private String ndayYn;
	private Date nurseConfirmDate;
	private String nurseConfirmTime;
	private String nurseConfirmUser;
	private String nurseRemark;
	private String ocsFlag;
	private String ordDanui;
	private Date orderDate;
	private String orderGubun;
	private String orderRemark;
	private String pay;
	private String pharmacy;
	private Double pkocs1003;
	private String portableYn;
	private String postapproveYn;
	private String powderYn;
	private String printYn;
	private String regularYn;
	private Date reserDate;
	private String reserTime;
	private Date resultDate;
	private String returnRemark;
	private Double seq;
	private String sgCode;
	private Date sgYmd;
	private String slipCode;
	private Double sortFkocskey;
	private Double sourceFkocs1003;
	private String specimenCode;
	private String subSusul;
	private String subulDanui;
	private Double subulSuryang;
	private Date sunabDate;
	private Double sunabSuryang;
	private String sunabTime;
	private String sunabYn;
	private Double suryang;
	private String sutakYn;
	private Date sysDate;
	private String sysId;
	private String telYn;
	private Date updDate;
	private String updId;
	private String wonyoiOrderYn;
	private String xrtDrYn;
	private String paidYn;
	private String orderStatus;
	
	public Ocs1003() {
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


	@Column(name="AFTER_ACT_YN")
	public String getAfterActYn() {
		return this.afterActYn;
	}

	public void setAfterActYn(String afterActYn) {
		this.afterActYn = afterActYn;
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


	public Double getFkocs2003() {
		return this.fkocs2003;
	}

	public void setFkocs2003(Double fkocs2003) {
		this.fkocs2003 = fkocs2003;
	}

	@Column(name="FKOUT1001")
	public BigDecimal getFkout1001() {
		return this.fkout1001;
	}

	public void setFkout1001(BigDecimal fkout1001) {
		this.fkout1001 = fkout1001;
	}

	public Double getFkout1003() {
		return this.fkout1003;
	}

	public void setFkout1003(Double fkout1003) {
		this.fkout1003 = fkout1003;
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


	@Column(name="HANGMOG_NAME")
	public String getHangmogName() {
		return this.hangmogName;
	}

	public void setHangmogName(String hangmogName) {
		this.hangmogName = hangmogName;
	}


	@Column(name="HOME_CARE_YN")
	public String getHomeCareYn() {
		return this.homeCareYn;
	}

	public void setHomeCareYn(String homeCareYn) {
		this.homeCareYn = homeCareYn;
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


	@Column(name="INPUT_GUBUN")
	public String getInputGubun() {
		return this.inputGubun;
	}

	public void setInputGubun(String inputGubun) {
		this.inputGubun = inputGubun;
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


	@Column(name="NAEWON_TYPE")
	public String getNaewonType() {
		return this.naewonType;
	}

	public void setNaewonType(String naewonType) {
		this.naewonType = naewonType;
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


	@Column(name="NURSE_REMARK")
	public String getNurseRemark() {
		return this.nurseRemark;
	}

	public void setNurseRemark(String nurseRemark) {
		this.nurseRemark = nurseRemark;
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


	public Double getPkocs1003() {
		return this.pkocs1003;
	}

	public void setPkocs1003(Double pkocs1003) {
		this.pkocs1003 = pkocs1003;
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


	@Column(name="PRINT_YN")
	public String getPrintYn() {
		return this.printYn;
	}

	public void setPrintYn(String printYn) {
		this.printYn = printYn;
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


	@Column(name="SOURCE_FKOCS1003")
	public Double getSourceFkocs1003() {
		return this.sourceFkocs1003;
	}

	public void setSourceFkocs1003(Double sourceFkocs1003) {
		this.sourceFkocs1003 = sourceFkocs1003;
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


	@Column(name="SUNAB_TIME")
	public String getSunabTime() {
		return this.sunabTime;
	}

	public void setSunabTime(String sunabTime) {
		this.sunabTime = sunabTime;
	}


	@Column(name="SUNAB_YN")
	public String getSunabYn() {
		return this.sunabYn;
	}

	public void setSunabYn(String sunabYn) {
		this.sunabYn = sunabYn;
	}


	public Double getSuryang() {
		return this.suryang;
	}

	public void setSuryang(Double suryang) {
		this.suryang = suryang;
	}


	@Column(name="SUTAK_YN")
	public String getSutakYn() {
		return this.sutakYn;
	}

	public void setSutakYn(String sutakYn) {
		this.sutakYn = sutakYn;
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

	@Column(name="PAID_YN")
	public String getPaidYn() {
		return paidYn;
	}

	public void setPaidYn(String paidYn) {
		this.paidYn = paidYn;
	}

	@Column(name = "ORDER_STATUS")
	public String getOrderStatus() {
		return orderStatus;
	}

	public void setOrderStatus(String orderStatus) {
		this.orderStatus = orderStatus;
	}
	
	@Override
	public String toString() {
		return "Ocs1003 [actBuseo=" + actBuseo + ", actDoctor=" + actDoctor
				+ ", actGwa=" + actGwa + ", actingDate=" + actingDate
				+ ", actingDay=" + actingDay + ", actingTime=" + actingTime
				+ ", afterActYn=" + afterActYn + ", amt=" + amt
				+ ", antiCancerYn=" + antiCancerYn + ", approveDate="
				+ approveDate + ", approveId=" + approveId + ", approveTime="
				+ approveTime + ", approveYn=" + approveYn + ", bannabConfirm="
				+ bannabConfirm + ", bannabYn=" + bannabYn + ", bichiYn="
				+ bichiYn + ", bogyongCode=" + bogyongCode
				+ ", bogyongCodeSub=" + bogyongCodeSub + ", bomOccurYn="
				+ bomOccurYn + ", bomSourceKey=" + bomSourceKey + ", bunho="
				+ bunho + ", chisik=" + chisik + ", dangilGumsaOrderYn="
				+ dangilGumsaOrderYn + ", dangilGumsaResultYn="
				+ dangilGumsaResultYn + ", dcGubun=" + dcGubun + ", dcYn="
				+ dcYn + ", displayYn=" + displayYn + ", doctor=" + doctor
				+ ", drgBunho=" + drgBunho + ", drgPackYn=" + drgPackYn
				+ ", dv=" + dv + ", dv1=" + dv1 + ", dv2=" + dv2 + ", dv3="
				+ dv3 + ", dv4=" + dv4 + ", dv5=" + dv5 + ", dv6=" + dv6
				+ ", dv7=" + dv7 + ", dv8=" + dv8 + ", dvTime=" + dvTime
				+ ", emergency=" + emergency + ", fkocs2003=" + fkocs2003
				+ ", fkout1001=" + fkout1001 + ", fkout1003=" + fkout1003
				+ ", generalDispYn=" + generalDispYn + ", gongbiCode="
				+ gongbiCode + ", groupSer=" + groupSer + ", gwa=" + gwa
				+ ", hangmogCode=" + hangmogCode + ", hangmogName="
				+ hangmogName + ", homeCareYn=" + homeCareYn + ", hopeDate="
				+ hopeDate + ", hopeTime=" + hopeTime + ", hospCode="
				+ hospCode + ", hubalChangeYn=" + hubalChangeYn
				+ ", ifActSendYn=" + ifActSendYn + ", ifDataSendDate="
				+ ifDataSendDate + ", ifDataSendYn=" + ifDataSendYn
				+ ", imsiDrugYn=" + imsiDrugYn + ", inputGubun=" + inputGubun
				+ ", inputId=" + inputId + ", inputPart=" + inputPart
				+ ", inputTab=" + inputTab + ", insteadDate=" + insteadDate
				+ ", insteadId=" + insteadId + ", insteadTime=" + insteadTime
				+ ", insteadYn=" + insteadYn + ", ioGubun=" + ioGubun
				+ ", jaeryoJundalYn=" + jaeryoJundalYn + ", jubsuDate="
				+ jubsuDate + ", jubsuTime=" + jubsuTime + ", jundalPart="
				+ jundalPart + ", jundalTable=" + jundalTable + ", jusa="
				+ jusa + ", jusaSpdGubun=" + jusaSpdGubun + ", mixGroup="
				+ mixGroup + ", movePart=" + movePart + ", muhyo=" + muhyo
				+ ", naewonType=" + naewonType + ", nalsu=" + nalsu
				+ ", ndayYn=" + ndayYn + ", nurseConfirmDate="
				+ nurseConfirmDate + ", nurseConfirmTime=" + nurseConfirmTime
				+ ", nurseConfirmUser=" + nurseConfirmUser + ", nurseRemark="
				+ nurseRemark + ", ocsFlag=" + ocsFlag + ", ordDanui="
				+ ordDanui + ", orderDate=" + orderDate + ", orderGubun="
				+ orderGubun + ", orderRemark=" + orderRemark + ", pay=" + pay
				+ ", pharmacy=" + pharmacy + ", pkocs1003=" + pkocs1003
				+ ", portableYn=" + portableYn + ", postapproveYn="
				+ postapproveYn + ", powderYn=" + powderYn + ", printYn="
				+ printYn + ", regularYn=" + regularYn + ", reserDate="
				+ reserDate + ", reserTime=" + reserTime + ", resultDate="
				+ resultDate + ", returnRemark=" + returnRemark + ", seq="
				+ seq + ", sgCode=" + sgCode + ", sgYmd=" + sgYmd
				+ ", slipCode=" + slipCode + ", sortFkocskey=" + sortFkocskey
				+ ", sourceFkocs1003=" + sourceFkocs1003 + ", specimenCode="
				+ specimenCode + ", subSusul=" + subSusul + ", subulDanui="
				+ subulDanui + ", subulSuryang=" + subulSuryang
				+ ", sunabDate=" + sunabDate + ", sunabSuryang=" + sunabSuryang
				+ ", sunabTime=" + sunabTime + ", sunabYn=" + sunabYn
				+ ", suryang=" + suryang + ", sutakYn=" + sutakYn
				+ ", sysDate=" + sysDate + ", sysId=" + sysId + ", telYn="
				+ telYn + ", updDate=" + updDate + ", updId=" + updId
				+ ", wonyoiOrderYn=" + wonyoiOrderYn + ", xrtDrYn=" + xrtDrYn
				+ ", getActBuseo()=" + getActBuseo() + ", getActDoctor()="
				+ getActDoctor() + ", getActGwa()=" + getActGwa()
				+ ", getActingDate()=" + getActingDate() + ", getActingDay()="
				+ getActingDay() + ", getActingTime()=" + getActingTime()
				+ ", getAfterActYn()=" + getAfterActYn() + ", getAmt()="
				+ getAmt() + ", getAntiCancerYn()=" + getAntiCancerYn()
				+ ", getApproveDate()=" + getApproveDate()
				+ ", getApproveId()=" + getApproveId() + ", getApproveTime()="
				+ getApproveTime() + ", getApproveYn()=" + getApproveYn()
				+ ", getBannabConfirm()=" + getBannabConfirm()
				+ ", getBannabYn()=" + getBannabYn() + ", getBichiYn()="
				+ getBichiYn() + ", getBogyongCode()=" + getBogyongCode()
				+ ", getBogyongCodeSub()=" + getBogyongCodeSub()
				+ ", getBomOccurYn()=" + getBomOccurYn()
				+ ", getBomSourceKey()=" + getBomSourceKey() + ", getBunho()="
				+ getBunho() + ", getChisik()=" + getChisik()
				+ ", getDangilGumsaOrderYn()=" + getDangilGumsaOrderYn()
				+ ", getDangilGumsaResultYn()=" + getDangilGumsaResultYn()
				+ ", getDcGubun()=" + getDcGubun() + ", getDcYn()=" + getDcYn()
				+ ", getDisplayYn()=" + getDisplayYn() + ", getDoctor()="
				+ getDoctor() + ", getDrgBunho()=" + getDrgBunho()
				+ ", getDrgPackYn()=" + getDrgPackYn() + ", getDv()=" + getDv()
				+ ", getDv1()=" + getDv1() + ", getDv2()=" + getDv2()
				+ ", getDv3()=" + getDv3() + ", getDv4()=" + getDv4()
				+ ", getDv5()=" + getDv5() + ", getDv6()=" + getDv6()
				+ ", getDv7()=" + getDv7() + ", getDv8()=" + getDv8()
				+ ", getDvTime()=" + getDvTime() + ", getEmergency()="
				+ getEmergency() + ", getFkocs2003()=" + getFkocs2003()
				+ ", getFkout1001()=" + getFkout1001() + ", getFkout1003()="
				+ getFkout1003() + ", getGeneralDispYn()=" + getGeneralDispYn()
				+ ", getGongbiCode()=" + getGongbiCode() + ", getGroupSer()="
				+ getGroupSer() + ", getGwa()=" + getGwa()
				+ ", getHangmogCode()=" + getHangmogCode()
				+ ", getHangmogName()=" + getHangmogName()
				+ ", getHomeCareYn()=" + getHomeCareYn() + ", getHopeDate()="
				+ getHopeDate() + ", getHopeTime()=" + getHopeTime()
				+ ", getHospCode()=" + getHospCode() + ", getHubalChangeYn()="
				+ getHubalChangeYn() + ", getIfActSendYn()=" + getIfActSendYn()
				+ ", getIfDataSendDate()=" + getIfDataSendDate()
				+ ", getIfDataSendYn()=" + getIfDataSendYn()
				+ ", getImsiDrugYn()=" + getImsiDrugYn() + ", getInputGubun()="
				+ getInputGubun() + ", getInputId()=" + getInputId()
				+ ", getInputPart()=" + getInputPart() + ", getInputTab()="
				+ getInputTab() + ", getInsteadDate()=" + getInsteadDate()
				+ ", getInsteadId()=" + getInsteadId() + ", getInsteadTime()="
				+ getInsteadTime() + ", getInsteadYn()=" + getInsteadYn()
				+ ", getIoGubun()=" + getIoGubun() + ", getJaeryoJundalYn()="
				+ getJaeryoJundalYn() + ", getJubsuDate()=" + getJubsuDate()
				+ ", getJubsuTime()=" + getJubsuTime() + ", getJundalPart()="
				+ getJundalPart() + ", getJundalTable()=" + getJundalTable()
				+ ", getJusa()=" + getJusa() + ", getJusaSpdGubun()="
				+ getJusaSpdGubun() + ", getMixGroup()=" + getMixGroup()
				+ ", getMovePart()=" + getMovePart() + ", getMuhyo()="
				+ getMuhyo() + ", getNaewonType()=" + getNaewonType()
				+ ", getNalsu()=" + getNalsu() + ", getNdayYn()=" + getNdayYn()
				+ ", getNurseConfirmDate()=" + getNurseConfirmDate()
				+ ", getNurseConfirmTime()=" + getNurseConfirmTime()
				+ ", getNurseConfirmUser()=" + getNurseConfirmUser()
				+ ", getNurseRemark()=" + getNurseRemark() + ", getOcsFlag()="
				+ getOcsFlag() + ", getOrdDanui()=" + getOrdDanui()
				+ ", getOrderDate()=" + getOrderDate() + ", getOrderGubun()="
				+ getOrderGubun() + ", getOrderRemark()=" + getOrderRemark()
				+ ", getPay()=" + getPay() + ", getPharmacy()=" + getPharmacy()
				+ ", getPkocs1003()=" + getPkocs1003() + ", getPortableYn()="
				+ getPortableYn() + ", getPostapproveYn()="
				+ getPostapproveYn() + ", getPowderYn()=" + getPowderYn()
				+ ", getPrintYn()=" + getPrintYn() + ", getRegularYn()="
				+ getRegularYn() + ", getReserDate()=" + getReserDate()
				+ ", getReserTime()=" + getReserTime() + ", getResultDate()="
				+ getResultDate() + ", getReturnRemark()=" + getReturnRemark()
				+ ", getSeq()=" + getSeq() + ", getSgCode()=" + getSgCode()
				+ ", getSgYmd()=" + getSgYmd() + ", getSlipCode()="
				+ getSlipCode() + ", getSortFkocskey()=" + getSortFkocskey()
				+ ", getSourceFkocs1003()=" + getSourceFkocs1003()
				+ ", getSpecimenCode()=" + getSpecimenCode()
				+ ", getSubSusul()=" + getSubSusul() + ", getSubulDanui()="
				+ getSubulDanui() + ", getSubulSuryang()=" + getSubulSuryang()
				+ ", getSunabDate()=" + getSunabDate() + ", getSunabSuryang()="
				+ getSunabSuryang() + ", getSunabTime()=" + getSunabTime()
				+ ", getSunabYn()=" + getSunabYn() + ", getSuryang()="
				+ getSuryang() + ", getSutakYn()=" + getSutakYn()
				+ ", getSysDate()=" + getSysDate() + ", getSysId()="
				+ getSysId() + ", getTelYn()=" + getTelYn() + ", getUpdDate()="
				+ getUpdDate() + ", getUpdId()=" + getUpdId()
				+ ", getWonyoiOrderYn()=" + getWonyoiOrderYn()
				+ ", getXrtDrYn()=" + getXrtDrYn() + ", getId()=" + getId()
				+ ", getClass()=" + getClass() + ", hashCode()=" + hashCode()
				+ ", toString()=" + super.toString() + "]";
	}

}