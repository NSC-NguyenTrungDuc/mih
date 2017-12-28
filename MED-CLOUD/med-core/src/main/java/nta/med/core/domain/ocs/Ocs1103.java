package nta.med.core.domain.ocs;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the OCS1103 database table.
 * 
 */
@Entity
@NamedQuery(name="Ocs1103.findAll", query="SELECT o FROM Ocs1103 o")
public class Ocs1103 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String actBuseo;
	private String actDoctor;
	private String actGwa;
	private Date actingDate;
	private double actingDay;
	private String actingTime;
	private String afterActYn;
	private double amt;
	private String antiCancerYn;
	private Date approveDate;
	private String approveId;
	private String approveTime;
	private String approveYn;
	private String bannabConfirm;
	private String bannabYn;
	private String bichiYn;
	private String bogyongCode;
	private String bomOccurYn;
	private double bomSourceKey;
	private String bunho;
	private String chisik;
	private String dangilGumsaOrderYn;
	private String dangilGumsaResultYn;
	private String dcGubun;
	private String dcYn;
	private String displayYn;
	private String doctor;
	private double drgBunho;
	private String drgPackYn;
	private double dv;
	private double dv1;
	private double dv2;
	private double dv3;
	private double dv4;
	private double dv5;
	private double dv6;
	private double dv7;
	private double dv8;
	private String dvTime;
	private String emergency;
	private double fkinp1001;
	private double fkocs2003;
	private double fkout1001;
	private double fkout1003;
	private String generalDispYn;
	private String gongbiCode;
	private double groupSer;
	private String gwa;
	private String hangmogCode;
	private String hangmogName;
	private String homeCareYn;
	private Date hopeDate;
	private String hopeTime;
	private String hospCode;
	private String hubalChangeYn;
	private Date ifDataSendDate;
	private String ifDataSendYn;
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
	private double nalsu;
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
	private double pkocs1003;
	private String portableYn;
	private String postapproveYn;
	private String powderYn;
	private String printYn;
	private String regularYn;
	private Date reserDate;
	private String reserTime;
	private Date resultDate;
	private String returnRemark;
	private double seq;
	private String sgCode;
	private Date sgYmd;
	private String slipCode;
	private double sortFkocskey;
	private double sourceFkocs1003;
	private String specimenCode;
	private String subSusul;
	private String subulDanui;
	private double subulSuryang;
	private Date sunabDate;
	private double sunabSuryang;
	private String sunabTime;
	private String sunabYn;
	private double suryang;
	private String sutakYn;
	private Date sysDate;
	private String sysId;
	private String telYn;
	private Date updDate;
	private String updId;
	private String wonyoiOrderYn;

	public Ocs1103() {
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
	public double getActingDay() {
		return this.actingDay;
	}

	public void setActingDay(double actingDay) {
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


	public double getAmt() {
		return this.amt;
	}

	public void setAmt(double amt) {
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


	@Column(name="BOM_OCCUR_YN")
	public String getBomOccurYn() {
		return this.bomOccurYn;
	}

	public void setBomOccurYn(String bomOccurYn) {
		this.bomOccurYn = bomOccurYn;
	}


	@Column(name="BOM_SOURCE_KEY")
	public double getBomSourceKey() {
		return this.bomSourceKey;
	}

	public void setBomSourceKey(double bomSourceKey) {
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
	public double getDrgBunho() {
		return this.drgBunho;
	}

	public void setDrgBunho(double drgBunho) {
		this.drgBunho = drgBunho;
	}


	@Column(name="DRG_PACK_YN")
	public String getDrgPackYn() {
		return this.drgPackYn;
	}

	public void setDrgPackYn(String drgPackYn) {
		this.drgPackYn = drgPackYn;
	}


	public double getDv() {
		return this.dv;
	}

	public void setDv(double dv) {
		this.dv = dv;
	}


	@Column(name="DV_1")
	public double getDv1() {
		return this.dv1;
	}

	public void setDv1(double dv1) {
		this.dv1 = dv1;
	}


	@Column(name="DV_2")
	public double getDv2() {
		return this.dv2;
	}

	public void setDv2(double dv2) {
		this.dv2 = dv2;
	}


	@Column(name="DV_3")
	public double getDv3() {
		return this.dv3;
	}

	public void setDv3(double dv3) {
		this.dv3 = dv3;
	}


	@Column(name="DV_4")
	public double getDv4() {
		return this.dv4;
	}

	public void setDv4(double dv4) {
		this.dv4 = dv4;
	}


	@Column(name="DV_5")
	public double getDv5() {
		return this.dv5;
	}

	public void setDv5(double dv5) {
		this.dv5 = dv5;
	}


	@Column(name="DV_6")
	public double getDv6() {
		return this.dv6;
	}

	public void setDv6(double dv6) {
		this.dv6 = dv6;
	}


	@Column(name="DV_7")
	public double getDv7() {
		return this.dv7;
	}

	public void setDv7(double dv7) {
		this.dv7 = dv7;
	}


	@Column(name="DV_8")
	public double getDv8() {
		return this.dv8;
	}

	public void setDv8(double dv8) {
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


	public double getFkinp1001() {
		return this.fkinp1001;
	}

	public void setFkinp1001(double fkinp1001) {
		this.fkinp1001 = fkinp1001;
	}


	public double getFkocs2003() {
		return this.fkocs2003;
	}

	public void setFkocs2003(double fkocs2003) {
		this.fkocs2003 = fkocs2003;
	}


	public double getFkout1001() {
		return this.fkout1001;
	}

	public void setFkout1001(double fkout1001) {
		this.fkout1001 = fkout1001;
	}


	public double getFkout1003() {
		return this.fkout1003;
	}

	public void setFkout1003(double fkout1003) {
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
	public double getGroupSer() {
		return this.groupSer;
	}

	public void setGroupSer(double groupSer) {
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


	public double getNalsu() {
		return this.nalsu;
	}

	public void setNalsu(double nalsu) {
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


	public double getPkocs1003() {
		return this.pkocs1003;
	}

	public void setPkocs1003(double pkocs1003) {
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


	public double getSeq() {
		return this.seq;
	}

	public void setSeq(double seq) {
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
	public double getSortFkocskey() {
		return this.sortFkocskey;
	}

	public void setSortFkocskey(double sortFkocskey) {
		this.sortFkocskey = sortFkocskey;
	}


	@Column(name="SOURCE_FKOCS1003")
	public double getSourceFkocs1003() {
		return this.sourceFkocs1003;
	}

	public void setSourceFkocs1003(double sourceFkocs1003) {
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
	public double getSubulSuryang() {
		return this.subulSuryang;
	}

	public void setSubulSuryang(double subulSuryang) {
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
	public double getSunabSuryang() {
		return this.sunabSuryang;
	}

	public void setSunabSuryang(double sunabSuryang) {
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


	public double getSuryang() {
		return this.suryang;
	}

	public void setSuryang(double suryang) {
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

}