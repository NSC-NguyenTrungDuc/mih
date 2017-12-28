package nta.med.core.domain.drg;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;


/**
 * The persistent class for the DRG2010 database table.
 * 
 */
@Entity
@Table(name="DRG2010")
public class Drg2010 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private Date actDate;
	private String actGwa;
	private Date actIlsi;
	private String actUser;
	private String antiSoyuYn;
	private String atcYn;
	private String bannabPrnYn;
	private String bannabYn;
	private String bogyongCode;
	private String boryuYn;
	private String bunho;
	private String bunryu1;
	private String bunryu2;
	private String bunryu3;
	private String bunryu4;
	private String cautionCode;
	private Double changeQty;
	private String chulgoBuseo;
	private Date chulgoDate;
	private Double chulgoQty;
	private String chulgoYn;
	private String dcYn;
	private String disGubun;
	private String divide;
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
	private Double fkdrg4010;
	private Double fkjihkey;
	private Double fkocs1003;
	private String fkout1001;
	private Double groupSer;
	private String groupYn;
	private String gwa;
	private String gyunbonYn;
	private String hospCode;
	private String hubalChangeYn;
	private String imsiDrugYn;
	private String inputGubun;
	private String inputPart;
	private String inv4004ChulgoBuseo;
	private Date inv4004ChulgoDate;
	private Double inv4004ChulgoSeq;
	private String inv4004ChulgoType;
	private Date iuJusaDate;
	private String jaeryoCode;
	private String jaeryoGubun;
	private Date jubsuDate;
	private Date jubsuIlsi;
	private String jubsuTime;
	private String jundalPart;
	private String jusa;
	private String jusaGubun;
	private String jusaSpdGubun;
	private String mixGroup;
	private String mixYn;
	private Date naewonDate;
	private Double nalsu;
	private Double ordSuryang;
	private String orderDanui;
	private Date orderDate;
	private Double orderSuryang;
	private String pharmacy;
	private String powderYn;
	private String printYn;
	private String remark;
	private Double sourceFkocs1003;
	private String subulDanui;
	private Double subulSuryang;
	private Date sunabDate;
	private Double sunabNalsu;
	private Date sysDate;
	private String sysId;
	private String tpnJojeGubun;
	private Date updDate;
	private String updId;
	private String wonnaeSayuCode;
	private String wonyoiOrderYn;

	public Drg2010() {
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="ACT_DATE")
	public Date getActDate() {
		return this.actDate;
	}

	public void setActDate(Date actDate) {
		this.actDate = actDate;
	}


	@Column(name="ACT_GWA")
	public String getActGwa() {
		return this.actGwa;
	}

	public void setActGwa(String actGwa) {
		this.actGwa = actGwa;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="ACT_ILSI")
	public Date getActIlsi() {
		return this.actIlsi;
	}

	public void setActIlsi(Date actIlsi) {
		this.actIlsi = actIlsi;
	}


	@Column(name="ACT_USER")
	public String getActUser() {
		return this.actUser;
	}

	public void setActUser(String actUser) {
		this.actUser = actUser;
	}


	@Column(name="ANTI_SOYU_YN")
	public String getAntiSoyuYn() {
		return this.antiSoyuYn;
	}

	public void setAntiSoyuYn(String antiSoyuYn) {
		this.antiSoyuYn = antiSoyuYn;
	}


	@Column(name="ATC_YN")
	public String getAtcYn() {
		return this.atcYn;
	}

	public void setAtcYn(String atcYn) {
		this.atcYn = atcYn;
	}


	@Column(name="BANNAB_PRN_YN")
	public String getBannabPrnYn() {
		return this.bannabPrnYn;
	}

	public void setBannabPrnYn(String bannabPrnYn) {
		this.bannabPrnYn = bannabPrnYn;
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


	@Column(name="BORYU_YN")
	public String getBoryuYn() {
		return this.boryuYn;
	}

	public void setBoryuYn(String boryuYn) {
		this.boryuYn = boryuYn;
	}


	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}


	public String getBunryu1() {
		return this.bunryu1;
	}

	public void setBunryu1(String bunryu1) {
		this.bunryu1 = bunryu1;
	}


	public String getBunryu2() {
		return this.bunryu2;
	}

	public void setBunryu2(String bunryu2) {
		this.bunryu2 = bunryu2;
	}


	public String getBunryu3() {
		return this.bunryu3;
	}

	public void setBunryu3(String bunryu3) {
		this.bunryu3 = bunryu3;
	}


	public String getBunryu4() {
		return this.bunryu4;
	}

	public void setBunryu4(String bunryu4) {
		this.bunryu4 = bunryu4;
	}


	@Column(name="CAUTION_CODE")
	public String getCautionCode() {
		return this.cautionCode;
	}

	public void setCautionCode(String cautionCode) {
		this.cautionCode = cautionCode;
	}


	@Column(name="CHANGE_QTY")
	public Double getChangeQty() {
		return this.changeQty;
	}

	public void setChangeQty(Double changeQty) {
		this.changeQty = changeQty;
	}


	@Column(name="CHULGO_BUSEO")
	public String getChulgoBuseo() {
		return this.chulgoBuseo;
	}

	public void setChulgoBuseo(String chulgoBuseo) {
		this.chulgoBuseo = chulgoBuseo;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="CHULGO_DATE")
	public Date getChulgoDate() {
		return this.chulgoDate;
	}

	public void setChulgoDate(Date chulgoDate) {
		this.chulgoDate = chulgoDate;
	}


	@Column(name="CHULGO_QTY")
	public Double getChulgoQty() {
		return this.chulgoQty;
	}

	public void setChulgoQty(Double chulgoQty) {
		this.chulgoQty = chulgoQty;
	}


	@Column(name="CHULGO_YN")
	public String getChulgoYn() {
		return this.chulgoYn;
	}

	public void setChulgoYn(String chulgoYn) {
		this.chulgoYn = chulgoYn;
	}


	@Column(name="DC_YN")
	public String getDcYn() {
		return this.dcYn;
	}

	public void setDcYn(String dcYn) {
		this.dcYn = dcYn;
	}


	@Column(name="DIS_GUBUN")
	public String getDisGubun() {
		return this.disGubun;
	}

	public void setDisGubun(String disGubun) {
		this.disGubun = disGubun;
	}


	public String getDivide() {
		return this.divide;
	}

	public void setDivide(String divide) {
		this.divide = divide;
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


	public Double getFkdrg4010() {
		return this.fkdrg4010;
	}

	public void setFkdrg4010(Double fkdrg4010) {
		this.fkdrg4010 = fkdrg4010;
	}


	public Double getFkjihkey() {
		return this.fkjihkey;
	}

	public void setFkjihkey(Double fkjihkey) {
		this.fkjihkey = fkjihkey;
	}


	public Double getFkocs1003() {
		return this.fkocs1003;
	}

	public void setFkocs1003(Double fkocs1003) {
		this.fkocs1003 = fkocs1003;
	}


	public String getFkout1001() {
		return this.fkout1001;
	}

	public void setFkout1001(String fkout1001) {
		this.fkout1001 = fkout1001;
	}


	@Column(name="GROUP_SER")
	public Double getGroupSer() {
		return this.groupSer;
	}

	public void setGroupSer(Double groupSer) {
		this.groupSer = groupSer;
	}


	@Column(name="GROUP_YN")
	public String getGroupYn() {
		return this.groupYn;
	}

	public void setGroupYn(String groupYn) {
		this.groupYn = groupYn;
	}


	public String getGwa() {
		return this.gwa;
	}

	public void setGwa(String gwa) {
		this.gwa = gwa;
	}


	@Column(name="GYUNBON_YN")
	public String getGyunbonYn() {
		return this.gyunbonYn;
	}

	public void setGyunbonYn(String gyunbonYn) {
		this.gyunbonYn = gyunbonYn;
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


	@Column(name="INPUT_PART")
	public String getInputPart() {
		return this.inputPart;
	}

	public void setInputPart(String inputPart) {
		this.inputPart = inputPart;
	}


	@Column(name="INV4004_CHULGO_BUSEO")
	public String getInv4004ChulgoBuseo() {
		return this.inv4004ChulgoBuseo;
	}

	public void setInv4004ChulgoBuseo(String inv4004ChulgoBuseo) {
		this.inv4004ChulgoBuseo = inv4004ChulgoBuseo;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="INV4004_CHULGO_DATE")
	public Date getInv4004ChulgoDate() {
		return this.inv4004ChulgoDate;
	}

	public void setInv4004ChulgoDate(Date inv4004ChulgoDate) {
		this.inv4004ChulgoDate = inv4004ChulgoDate;
	}


	@Column(name="INV4004_CHULGO_SEQ")
	public Double getInv4004ChulgoSeq() {
		return this.inv4004ChulgoSeq;
	}

	public void setInv4004ChulgoSeq(Double inv4004ChulgoSeq) {
		this.inv4004ChulgoSeq = inv4004ChulgoSeq;
	}


	@Column(name="INV4004_CHULGO_TYPE")
	public String getInv4004ChulgoType() {
		return this.inv4004ChulgoType;
	}

	public void setInv4004ChulgoType(String inv4004ChulgoType) {
		this.inv4004ChulgoType = inv4004ChulgoType;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="IU_JUSA_DATE")
	public Date getIuJusaDate() {
		return this.iuJusaDate;
	}

	public void setIuJusaDate(Date iuJusaDate) {
		this.iuJusaDate = iuJusaDate;
	}


	@Column(name="JAERYO_CODE")
	public String getJaeryoCode() {
		return this.jaeryoCode;
	}

	public void setJaeryoCode(String jaeryoCode) {
		this.jaeryoCode = jaeryoCode;
	}


	@Column(name="JAERYO_GUBUN")
	public String getJaeryoGubun() {
		return this.jaeryoGubun;
	}

	public void setJaeryoGubun(String jaeryoGubun) {
		this.jaeryoGubun = jaeryoGubun;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="JUBSU_DATE")
	public Date getJubsuDate() {
		return this.jubsuDate;
	}

	public void setJubsuDate(Date jubsuDate) {
		this.jubsuDate = jubsuDate;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="JUBSU_ILSI")
	public Date getJubsuIlsi() {
		return this.jubsuIlsi;
	}

	public void setJubsuIlsi(Date jubsuIlsi) {
		this.jubsuIlsi = jubsuIlsi;
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


	public String getJusa() {
		return this.jusa;
	}

	public void setJusa(String jusa) {
		this.jusa = jusa;
	}


	@Column(name="JUSA_GUBUN")
	public String getJusaGubun() {
		return this.jusaGubun;
	}

	public void setJusaGubun(String jusaGubun) {
		this.jusaGubun = jusaGubun;
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


	@Column(name="MIX_YN")
	public String getMixYn() {
		return this.mixYn;
	}

	public void setMixYn(String mixYn) {
		this.mixYn = mixYn;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="NAEWON_DATE")
	public Date getNaewonDate() {
		return this.naewonDate;
	}

	public void setNaewonDate(Date naewonDate) {
		this.naewonDate = naewonDate;
	}


	public Double getNalsu() {
		return this.nalsu;
	}

	public void setNalsu(Double nalsu) {
		this.nalsu = nalsu;
	}


	@Column(name="ORD_SURYANG")
	public Double getOrdSuryang() {
		return this.ordSuryang;
	}

	public void setOrdSuryang(Double ordSuryang) {
		this.ordSuryang = ordSuryang;
	}


	@Column(name="ORDER_DANUI")
	public String getOrderDanui() {
		return this.orderDanui;
	}

	public void setOrderDanui(String orderDanui) {
		this.orderDanui = orderDanui;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="ORDER_DATE")
	public Date getOrderDate() {
		return this.orderDate;
	}

	public void setOrderDate(Date orderDate) {
		this.orderDate = orderDate;
	}


	@Column(name="ORDER_SURYANG")
	public Double getOrderSuryang() {
		return this.orderSuryang;
	}

	public void setOrderSuryang(Double orderSuryang) {
		this.orderSuryang = orderSuryang;
	}


	public String getPharmacy() {
		return this.pharmacy;
	}

	public void setPharmacy(String pharmacy) {
		this.pharmacy = pharmacy;
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


	public String getRemark() {
		return this.remark;
	}

	public void setRemark(String remark) {
		this.remark = remark;
	}


	@Column(name="SOURCE_FKOCS1003")
	public Double getSourceFkocs1003() {
		return this.sourceFkocs1003;
	}

	public void setSourceFkocs1003(Double sourceFkocs1003) {
		this.sourceFkocs1003 = sourceFkocs1003;
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


	@Column(name="SUNAB_NALSU")
	public Double getSunabNalsu() {
		return this.sunabNalsu;
	}

	public void setSunabNalsu(Double sunabNalsu) {
		this.sunabNalsu = sunabNalsu;
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


	@Column(name="TPN_JOJE_GUBUN")
	public String getTpnJojeGubun() {
		return this.tpnJojeGubun;
	}

	public void setTpnJojeGubun(String tpnJojeGubun) {
		this.tpnJojeGubun = tpnJojeGubun;
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


	@Column(name="WONNAE_SAYU_CODE")
	public String getWonnaeSayuCode() {
		return this.wonnaeSayuCode;
	}

	public void setWonnaeSayuCode(String wonnaeSayuCode) {
		this.wonnaeSayuCode = wonnaeSayuCode;
	}


	@Column(name="WONYOI_ORDER_YN")
	public String getWonyoiOrderYn() {
		return this.wonyoiOrderYn;
	}

	public void setWonyoiOrderYn(String wonyoiOrderYn) {
		this.wonyoiOrderYn = wonyoiOrderYn;
	}

}