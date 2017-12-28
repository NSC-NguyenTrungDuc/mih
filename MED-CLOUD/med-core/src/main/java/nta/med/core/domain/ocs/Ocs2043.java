package nta.med.core.domain.ocs;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the OCS2043 database table.
 * 
 */
@Entity
@NamedQuery(name="Ocs2043.findAll", query="SELECT o FROM Ocs2043 o")
public class Ocs2043 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String actBuseo;
	private String actDoctor;
	private String actGwa;
	private Date actingDate;
	private double actingDay;
	private String actingTime;
	private double amt;
	private String antiCancerYn;
	private String bannabConfirm;
	private String bannabConfirmUser;
	private String bannabYn;
	private String bogyongCode;
	private String bomOccurYn;
	private double bomSourceKey;
	private String bunho;
	private String dcGubun;
	private String dcYn;
	private String displayYn;
	private String doctor;
	private double drgBunho;
	private String drugTime;
	private double dv;
	private double dv1;
	private double dv2;
	private double dv3;
	private double dv4;
	private double dv5;
	private String dvTime;
	private double fkinp1001;
	private double groupSer;
	private String hangmogCode;
	private String hospCode;
	private String inputDoctor;
	private String inputGwa;
	private String ioGubun;
	private String jundalPart;
	private String jundalTable;
	private String mixGroup;
	private String muhyo;
	private double nalsu;
	private double newPkocs2003;
	private String ocsFlag;
	private String ordDanui;
	private Date orderDate;
	private String orderGubun;
	private String orderTime;
	private String pay;
	private double pkocs2043;
	private String regularYn;
	private double seq;
	private String sgCode;
	private Date sgYmd;
	private double sourceFkocs2003;
	private String subulDanui;
	private double subulSuryang;
	private double suryang;
	private Date sysDate;
	private String sysId;
	private String telYn;
	private String toiwonDrgYn;
	private String tpnYn;
	private Date updDate;
	private String updId;

	public Ocs2043() {
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


	@Column(name="DRUG_TIME")
	public String getDrugTime() {
		return this.drugTime;
	}

	public void setDrugTime(String drugTime) {
		this.drugTime = drugTime;
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


	@Column(name="DV_TIME")
	public String getDvTime() {
		return this.dvTime;
	}

	public void setDvTime(String dvTime) {
		this.dvTime = dvTime;
	}


	public double getFkinp1001() {
		return this.fkinp1001;
	}

	public void setFkinp1001(double fkinp1001) {
		this.fkinp1001 = fkinp1001;
	}


	@Column(name="GROUP_SER")
	public double getGroupSer() {
		return this.groupSer;
	}

	public void setGroupSer(double groupSer) {
		this.groupSer = groupSer;
	}


	@Column(name="HANGMOG_CODE")
	public String getHangmogCode() {
		return this.hangmogCode;
	}

	public void setHangmogCode(String hangmogCode) {
		this.hangmogCode = hangmogCode;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="INPUT_DOCTOR")
	public String getInputDoctor() {
		return this.inputDoctor;
	}

	public void setInputDoctor(String inputDoctor) {
		this.inputDoctor = inputDoctor;
	}


	@Column(name="INPUT_GWA")
	public String getInputGwa() {
		return this.inputGwa;
	}

	public void setInputGwa(String inputGwa) {
		this.inputGwa = inputGwa;
	}


	@Column(name="IO_GUBUN")
	public String getIoGubun() {
		return this.ioGubun;
	}

	public void setIoGubun(String ioGubun) {
		this.ioGubun = ioGubun;
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


	@Column(name="MIX_GROUP")
	public String getMixGroup() {
		return this.mixGroup;
	}

	public void setMixGroup(String mixGroup) {
		this.mixGroup = mixGroup;
	}


	public String getMuhyo() {
		return this.muhyo;
	}

	public void setMuhyo(String muhyo) {
		this.muhyo = muhyo;
	}


	public double getNalsu() {
		return this.nalsu;
	}

	public void setNalsu(double nalsu) {
		this.nalsu = nalsu;
	}


	@Column(name="NEW_PKOCS2003")
	public double getNewPkocs2003() {
		return this.newPkocs2003;
	}

	public void setNewPkocs2003(double newPkocs2003) {
		this.newPkocs2003 = newPkocs2003;
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


	public double getPkocs2043() {
		return this.pkocs2043;
	}

	public void setPkocs2043(double pkocs2043) {
		this.pkocs2043 = pkocs2043;
	}


	@Column(name="REGULAR_YN")
	public String getRegularYn() {
		return this.regularYn;
	}

	public void setRegularYn(String regularYn) {
		this.regularYn = regularYn;
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


	@Column(name="SOURCE_FKOCS2003")
	public double getSourceFkocs2003() {
		return this.sourceFkocs2003;
	}

	public void setSourceFkocs2003(double sourceFkocs2003) {
		this.sourceFkocs2003 = sourceFkocs2003;
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


	public double getSuryang() {
		return this.suryang;
	}

	public void setSuryang(double suryang) {
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


	@Column(name="TPN_YN")
	public String getTpnYn() {
		return this.tpnYn;
	}

	public void setTpnYn(String tpnYn) {
		this.tpnYn = tpnYn;
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