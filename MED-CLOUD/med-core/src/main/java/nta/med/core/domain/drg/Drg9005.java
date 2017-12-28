package nta.med.core.domain.drg;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the DRG9005 database table.
 * 
 */
@Entity
@NamedQuery(name="Drg9005.findAll", query="SELECT d FROM Drg9005 d")
public class Drg9005 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String bogyongName;
	private String bunho;
	private String doctor;
	private String donbokYn;
	private double dv;
	private String dvTime;
	private double groupSer;
	private String gwa;
	private String hoCode;
	private String hoDong;
	private String hospCode;
	private String inOut;
	private String inOutGubun;
	private String jaeryoCode;
	private String magamGubun;
	private Date maxHopeDate;
	private String mixGroup;
	private double nalsu;
	private double num01;
	private double num02;
	private double num03;
	private double num04;
	private double num05;
	private double num06;
	private double num07;
	private double num08;
	private double num09;
	private double num10;
	private double num11;
	private double num12;
	private double num13;
	private double num14;
	private double num15;
	private double num16;
	private double num17;
	private double num18;
	private double num19;
	private double num20;
	private double num21;
	private double num22;
	private double num23;
	private double num24;
	private double num25;
	private double num26;
	private double num27;
	private double num28;
	private double num29;
	private double num30;
	private double num31;
	private String orderDanui;
	private Date orderDate;
	private double seq;
	private double suryang;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;
	private String yyyymm;

	public Drg9005() {
	}


	@Column(name="BOGYONG_NAME")
	public String getBogyongName() {
		return this.bogyongName;
	}

	public void setBogyongName(String bogyongName) {
		this.bogyongName = bogyongName;
	}


	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}


	public String getDoctor() {
		return this.doctor;
	}

	public void setDoctor(String doctor) {
		this.doctor = doctor;
	}


	@Column(name="DONBOK_YN")
	public String getDonbokYn() {
		return this.donbokYn;
	}

	public void setDonbokYn(String donbokYn) {
		this.donbokYn = donbokYn;
	}


	public double getDv() {
		return this.dv;
	}

	public void setDv(double dv) {
		this.dv = dv;
	}


	@Column(name="DV_TIME")
	public String getDvTime() {
		return this.dvTime;
	}

	public void setDvTime(String dvTime) {
		this.dvTime = dvTime;
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


	@Column(name="IN_OUT")
	public String getInOut() {
		return this.inOut;
	}

	public void setInOut(String inOut) {
		this.inOut = inOut;
	}


	@Column(name="IN_OUT_GUBUN")
	public String getInOutGubun() {
		return this.inOutGubun;
	}

	public void setInOutGubun(String inOutGubun) {
		this.inOutGubun = inOutGubun;
	}


	@Column(name="JAERYO_CODE")
	public String getJaeryoCode() {
		return this.jaeryoCode;
	}

	public void setJaeryoCode(String jaeryoCode) {
		this.jaeryoCode = jaeryoCode;
	}


	@Column(name="MAGAM_GUBUN")
	public String getMagamGubun() {
		return this.magamGubun;
	}

	public void setMagamGubun(String magamGubun) {
		this.magamGubun = magamGubun;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="MAX_HOPE_DATE")
	public Date getMaxHopeDate() {
		return this.maxHopeDate;
	}

	public void setMaxHopeDate(Date maxHopeDate) {
		this.maxHopeDate = maxHopeDate;
	}


	@Column(name="MIX_GROUP")
	public String getMixGroup() {
		return this.mixGroup;
	}

	public void setMixGroup(String mixGroup) {
		this.mixGroup = mixGroup;
	}


	public double getNalsu() {
		return this.nalsu;
	}

	public void setNalsu(double nalsu) {
		this.nalsu = nalsu;
	}


	public double getNum01() {
		return this.num01;
	}

	public void setNum01(double num01) {
		this.num01 = num01;
	}


	public double getNum02() {
		return this.num02;
	}

	public void setNum02(double num02) {
		this.num02 = num02;
	}


	public double getNum03() {
		return this.num03;
	}

	public void setNum03(double num03) {
		this.num03 = num03;
	}


	public double getNum04() {
		return this.num04;
	}

	public void setNum04(double num04) {
		this.num04 = num04;
	}


	public double getNum05() {
		return this.num05;
	}

	public void setNum05(double num05) {
		this.num05 = num05;
	}


	public double getNum06() {
		return this.num06;
	}

	public void setNum06(double num06) {
		this.num06 = num06;
	}


	public double getNum07() {
		return this.num07;
	}

	public void setNum07(double num07) {
		this.num07 = num07;
	}


	public double getNum08() {
		return this.num08;
	}

	public void setNum08(double num08) {
		this.num08 = num08;
	}


	public double getNum09() {
		return this.num09;
	}

	public void setNum09(double num09) {
		this.num09 = num09;
	}


	public double getNum10() {
		return this.num10;
	}

	public void setNum10(double num10) {
		this.num10 = num10;
	}


	public double getNum11() {
		return this.num11;
	}

	public void setNum11(double num11) {
		this.num11 = num11;
	}


	public double getNum12() {
		return this.num12;
	}

	public void setNum12(double num12) {
		this.num12 = num12;
	}


	public double getNum13() {
		return this.num13;
	}

	public void setNum13(double num13) {
		this.num13 = num13;
	}


	public double getNum14() {
		return this.num14;
	}

	public void setNum14(double num14) {
		this.num14 = num14;
	}


	public double getNum15() {
		return this.num15;
	}

	public void setNum15(double num15) {
		this.num15 = num15;
	}


	public double getNum16() {
		return this.num16;
	}

	public void setNum16(double num16) {
		this.num16 = num16;
	}


	public double getNum17() {
		return this.num17;
	}

	public void setNum17(double num17) {
		this.num17 = num17;
	}


	public double getNum18() {
		return this.num18;
	}

	public void setNum18(double num18) {
		this.num18 = num18;
	}


	public double getNum19() {
		return this.num19;
	}

	public void setNum19(double num19) {
		this.num19 = num19;
	}


	public double getNum20() {
		return this.num20;
	}

	public void setNum20(double num20) {
		this.num20 = num20;
	}


	public double getNum21() {
		return this.num21;
	}

	public void setNum21(double num21) {
		this.num21 = num21;
	}


	public double getNum22() {
		return this.num22;
	}

	public void setNum22(double num22) {
		this.num22 = num22;
	}


	public double getNum23() {
		return this.num23;
	}

	public void setNum23(double num23) {
		this.num23 = num23;
	}


	public double getNum24() {
		return this.num24;
	}

	public void setNum24(double num24) {
		this.num24 = num24;
	}


	public double getNum25() {
		return this.num25;
	}

	public void setNum25(double num25) {
		this.num25 = num25;
	}


	public double getNum26() {
		return this.num26;
	}

	public void setNum26(double num26) {
		this.num26 = num26;
	}


	public double getNum27() {
		return this.num27;
	}

	public void setNum27(double num27) {
		this.num27 = num27;
	}


	public double getNum28() {
		return this.num28;
	}

	public void setNum28(double num28) {
		this.num28 = num28;
	}


	public double getNum29() {
		return this.num29;
	}

	public void setNum29(double num29) {
		this.num29 = num29;
	}


	public double getNum30() {
		return this.num30;
	}

	public void setNum30(double num30) {
		this.num30 = num30;
	}


	public double getNum31() {
		return this.num31;
	}

	public void setNum31(double num31) {
		this.num31 = num31;
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


	public double getSeq() {
		return this.seq;
	}

	public void setSeq(double seq) {
		this.seq = seq;
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


	public String getYyyymm() {
		return this.yyyymm;
	}

	public void setYyyymm(String yyyymm) {
		this.yyyymm = yyyymm;
	}

}