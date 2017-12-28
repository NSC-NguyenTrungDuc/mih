package nta.med.core.domain.drg;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the DRG3011 database table.
 * 
 */
@Entity
@NamedQuery(name="Drg3011.findAll", query="SELECT d FROM Drg3011 d")
public class Drg3011 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String appendYn;
	private String atcYn;
	private String bogyongCode;
	private String bunho;
	private String bunryu1;
	private String bunryu4;
	private double changeQty;
	private String divide;
	private String doctor;
	private double drgBunho;
	private String drgPackYn;
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
	private double groupSer;
	private String gwa;
	private String hoCode;
	private String hoDong;
	private String hospCode;
	private String jaeryoCode;
	private Date jubsuDate;
	private String jundalGubun;
	private String jundalPartRun;
	private double labelQty;
	private Date maxDate;
	private String mixYn;
	private double nalsu;
	private double ordSuryang;
	private String orderDanui;
	private Date orderDate;
	private String orderKey;
	private double orderSuryang;
	private String outBfDc;
	private String pharmacy;
	private double pkdrg3011;
	private String powderYn;
	private String remark;
	private String subulDanui;
	private double subulSuryang;
	private Date sysDate;
	private String sysId;
	private String toiwonDrgYn;
	private Date updDate;
	private String updId;

	public Drg3011() {
	}


	@Column(name="APPEND_YN")
	public String getAppendYn() {
		return this.appendYn;
	}

	public void setAppendYn(String appendYn) {
		this.appendYn = appendYn;
	}


	@Column(name="ATC_YN")
	public String getAtcYn() {
		return this.atcYn;
	}

	public void setAtcYn(String atcYn) {
		this.atcYn = atcYn;
	}


	@Column(name="BOGYONG_CODE")
	public String getBogyongCode() {
		return this.bogyongCode;
	}

	public void setBogyongCode(String bogyongCode) {
		this.bogyongCode = bogyongCode;
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


	public String getBunryu4() {
		return this.bunryu4;
	}

	public void setBunryu4(String bunryu4) {
		this.bunryu4 = bunryu4;
	}


	@Column(name="CHANGE_QTY")
	public double getChangeQty() {
		return this.changeQty;
	}

	public void setChangeQty(double changeQty) {
		this.changeQty = changeQty;
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


	@Column(name="HO_CODE")
	public String getHoCode() {
		return this.hoCode;
	}

	public void setHoCode(String hoCode) {
		this.hoCode = hoCode;
	}


	@Column(name="HO_DONG")
	public String getHoDong() {
		return this.hoDong;
	}

	public void setHoDong(String hoDong) {
		this.hoDong = hoDong;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="JAERYO_CODE")
	public String getJaeryoCode() {
		return this.jaeryoCode;
	}

	public void setJaeryoCode(String jaeryoCode) {
		this.jaeryoCode = jaeryoCode;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="JUBSU_DATE")
	public Date getJubsuDate() {
		return this.jubsuDate;
	}

	public void setJubsuDate(Date jubsuDate) {
		this.jubsuDate = jubsuDate;
	}


	@Column(name="JUNDAL_GUBUN")
	public String getJundalGubun() {
		return this.jundalGubun;
	}

	public void setJundalGubun(String jundalGubun) {
		this.jundalGubun = jundalGubun;
	}


	@Column(name="JUNDAL_PART_RUN")
	public String getJundalPartRun() {
		return this.jundalPartRun;
	}

	public void setJundalPartRun(String jundalPartRun) {
		this.jundalPartRun = jundalPartRun;
	}


	@Column(name="LABEL_QTY")
	public double getLabelQty() {
		return this.labelQty;
	}

	public void setLabelQty(double labelQty) {
		this.labelQty = labelQty;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="MAX_DATE")
	public Date getMaxDate() {
		return this.maxDate;
	}

	public void setMaxDate(Date maxDate) {
		this.maxDate = maxDate;
	}


	@Column(name="MIX_YN")
	public String getMixYn() {
		return this.mixYn;
	}

	public void setMixYn(String mixYn) {
		this.mixYn = mixYn;
	}


	public double getNalsu() {
		return this.nalsu;
	}

	public void setNalsu(double nalsu) {
		this.nalsu = nalsu;
	}


	@Column(name="ORD_SURYANG")
	public double getOrdSuryang() {
		return this.ordSuryang;
	}

	public void setOrdSuryang(double ordSuryang) {
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


	@Column(name="ORDER_KEY")
	public String getOrderKey() {
		return this.orderKey;
	}

	public void setOrderKey(String orderKey) {
		this.orderKey = orderKey;
	}


	@Column(name="ORDER_SURYANG")
	public double getOrderSuryang() {
		return this.orderSuryang;
	}

	public void setOrderSuryang(double orderSuryang) {
		this.orderSuryang = orderSuryang;
	}


	@Column(name="OUT_BF_DC")
	public String getOutBfDc() {
		return this.outBfDc;
	}

	public void setOutBfDc(String outBfDc) {
		this.outBfDc = outBfDc;
	}


	public String getPharmacy() {
		return this.pharmacy;
	}

	public void setPharmacy(String pharmacy) {
		this.pharmacy = pharmacy;
	}


	public double getPkdrg3011() {
		return this.pkdrg3011;
	}

	public void setPkdrg3011(double pkdrg3011) {
		this.pkdrg3011 = pkdrg3011;
	}


	@Column(name="POWDER_YN")
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

}