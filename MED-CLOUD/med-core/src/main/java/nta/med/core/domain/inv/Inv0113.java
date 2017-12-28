package nta.med.core.domain.inv;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the INV0113 database table.
 * 
 */
@Entity
@NamedQuery(name="Inv0113.findAll", query="SELECT i FROM Inv0113 i")
public class Inv0113 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String acctId;
	private String atcCode;
	private String atcYn;
	private String atcYnInp;
	private double avgQtyD;
	private double avgQtyM;
	private double avgQtyW;
	private Date baljuBulyongDate;
	private String baljuBuseo;
	private String baljuDanui;
	private String bannabYn;
	private String bogyongCode;
	private String bogyongCode1;
	private String bogyongCode2;
	private String bogyongCode3;
	private String bogyongCode4;
	private String bulyongCode;
	private Date bulyongDate;
	private Date bulyongToDate;
	private String bungiAcct;
	private String bunryuBunho1;
	private String bunryuBunho2;
	private String bunryu1;
	private String bunryu2;
	private String bunryu3;
	private String bunryu4;
	private String bunryu5;
	private String bunryu6;
	private String bunryu7;
	private String bunryu8;
	private String bunryu9;
	private String cautionCode;
	private double changeQtyl;
	private double changeQtyo;
	private double changeQtyp;
	private String changgo1;
	private String changgo2;
	private String changgo3;
	private String companyCode;
	private String customerCode;
	private String customerCode2;
	private String customerCode3;
	private double danga;
	private String dangaYn;
	private double drgMaxDv;
	private double drgMaxSuryang;
	private String drgType;
	private Date endDate;
	private Date fromDangaDate;
	private double gijunAmt;
	private double gijunAssureAmt;
	private String hamryang;
	private String hamryangDanui;
	private String hospCode;
	private String hyoneungCode;
	private String iceYn;
	private String ipAddr;
	private String ipchalType;
	private String iudGubun;
	private double jaegoAmt;
	private double jaegoQty;
	private String jaeryoCode;
	private String jaeryoEName;
	private String jaeryoGrade;
	private String jaeryoGubun;
	private String jaeryoName;
	private String jaeryoNameInx;
	private double jejeGijunQty;
	private double jukjungQty;
	private Date jukyongDate;
	private String kyukyeok;
	private Date lastChulgoDate;
	private double lastIbgoDanga;
	private Date lastIbgoDate;
	private double laundryDanga;
	private double leadTime;
	private String mainUseGwa1;
	private String mainUseGwa2;
	private String mainUseGwa3;
	private String mainUseGwa4;
	private String mainUseGwa5;
	private String manageName;
	private String manageNo;
	private String manageNo1;
	private String manageNo2;
	private String manageNo3;
	private String manageNo4;
	private double maxQtyD;
	private double maxQtyM;
	private double maxQtyW;
	private String midGubun;
	private String mixYn;
	private String mixYnInp;
	private String oldManageNo;
	private String orderDanui;
	private String orderSubulDanui;
	private String prisName;
	private String remark;
	private String smallCode;
	private double sortKey;
	private Date startDate;
	private String storageYn;
	private String subulBuseo;
	private String subulDanui;
	private String subulQcodeEr;
	private String subulQcodeInp;
	private String subulQcodeOut;
	private String sugbJaeryoYn;
	private String suibCustomer;
	private String suibYn;
	private String sungbunCode;
	private String sungbunName;
	private Date sysDate;
	private String sysId;
	private Date toDangaDate;
	private Date updDate;
	private String updId;
	private String useYn;
	private double weight;
	private double yuhyoMonth;
	private Date yuhyoToDate;
	private String yuhyoYn;
	private String yunhapCode;
	private String yunhapJoinYn;

	public Inv0113() {
	}


	@Column(name="ACCT_ID")
	public String getAcctId() {
		return this.acctId;
	}

	public void setAcctId(String acctId) {
		this.acctId = acctId;
	}


	@Column(name="ATC_CODE")
	public String getAtcCode() {
		return this.atcCode;
	}

	public void setAtcCode(String atcCode) {
		this.atcCode = atcCode;
	}


	@Column(name="ATC_YN")
	public String getAtcYn() {
		return this.atcYn;
	}

	public void setAtcYn(String atcYn) {
		this.atcYn = atcYn;
	}


	@Column(name="ATC_YN_INP")
	public String getAtcYnInp() {
		return this.atcYnInp;
	}

	public void setAtcYnInp(String atcYnInp) {
		this.atcYnInp = atcYnInp;
	}


	@Column(name="AVG_QTY_D")
	public double getAvgQtyD() {
		return this.avgQtyD;
	}

	public void setAvgQtyD(double avgQtyD) {
		this.avgQtyD = avgQtyD;
	}


	@Column(name="AVG_QTY_M")
	public double getAvgQtyM() {
		return this.avgQtyM;
	}

	public void setAvgQtyM(double avgQtyM) {
		this.avgQtyM = avgQtyM;
	}


	@Column(name="AVG_QTY_W")
	public double getAvgQtyW() {
		return this.avgQtyW;
	}

	public void setAvgQtyW(double avgQtyW) {
		this.avgQtyW = avgQtyW;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="BALJU_BULYONG_DATE")
	public Date getBaljuBulyongDate() {
		return this.baljuBulyongDate;
	}

	public void setBaljuBulyongDate(Date baljuBulyongDate) {
		this.baljuBulyongDate = baljuBulyongDate;
	}


	@Column(name="BALJU_BUSEO")
	public String getBaljuBuseo() {
		return this.baljuBuseo;
	}

	public void setBaljuBuseo(String baljuBuseo) {
		this.baljuBuseo = baljuBuseo;
	}


	@Column(name="BALJU_DANUI")
	public String getBaljuDanui() {
		return this.baljuDanui;
	}

	public void setBaljuDanui(String baljuDanui) {
		this.baljuDanui = baljuDanui;
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


	@Column(name="BOGYONG_CODE1")
	public String getBogyongCode1() {
		return this.bogyongCode1;
	}

	public void setBogyongCode1(String bogyongCode1) {
		this.bogyongCode1 = bogyongCode1;
	}


	@Column(name="BOGYONG_CODE2")
	public String getBogyongCode2() {
		return this.bogyongCode2;
	}

	public void setBogyongCode2(String bogyongCode2) {
		this.bogyongCode2 = bogyongCode2;
	}


	@Column(name="BOGYONG_CODE3")
	public String getBogyongCode3() {
		return this.bogyongCode3;
	}

	public void setBogyongCode3(String bogyongCode3) {
		this.bogyongCode3 = bogyongCode3;
	}


	@Column(name="BOGYONG_CODE4")
	public String getBogyongCode4() {
		return this.bogyongCode4;
	}

	public void setBogyongCode4(String bogyongCode4) {
		this.bogyongCode4 = bogyongCode4;
	}


	@Column(name="BULYONG_CODE")
	public String getBulyongCode() {
		return this.bulyongCode;
	}

	public void setBulyongCode(String bulyongCode) {
		this.bulyongCode = bulyongCode;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="BULYONG_DATE")
	public Date getBulyongDate() {
		return this.bulyongDate;
	}

	public void setBulyongDate(Date bulyongDate) {
		this.bulyongDate = bulyongDate;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="BULYONG_TO_DATE")
	public Date getBulyongToDate() {
		return this.bulyongToDate;
	}

	public void setBulyongToDate(Date bulyongToDate) {
		this.bulyongToDate = bulyongToDate;
	}


	@Column(name="BUNGI_ACCT")
	public String getBungiAcct() {
		return this.bungiAcct;
	}

	public void setBungiAcct(String bungiAcct) {
		this.bungiAcct = bungiAcct;
	}


	@Column(name="BUNRYU_BUNHO1")
	public String getBunryuBunho1() {
		return this.bunryuBunho1;
	}

	public void setBunryuBunho1(String bunryuBunho1) {
		this.bunryuBunho1 = bunryuBunho1;
	}


	@Column(name="BUNRYU_BUNHO2")
	public String getBunryuBunho2() {
		return this.bunryuBunho2;
	}

	public void setBunryuBunho2(String bunryuBunho2) {
		this.bunryuBunho2 = bunryuBunho2;
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


	public String getBunryu5() {
		return this.bunryu5;
	}

	public void setBunryu5(String bunryu5) {
		this.bunryu5 = bunryu5;
	}


	public String getBunryu6() {
		return this.bunryu6;
	}

	public void setBunryu6(String bunryu6) {
		this.bunryu6 = bunryu6;
	}


	public String getBunryu7() {
		return this.bunryu7;
	}

	public void setBunryu7(String bunryu7) {
		this.bunryu7 = bunryu7;
	}


	public String getBunryu8() {
		return this.bunryu8;
	}

	public void setBunryu8(String bunryu8) {
		this.bunryu8 = bunryu8;
	}


	public String getBunryu9() {
		return this.bunryu9;
	}

	public void setBunryu9(String bunryu9) {
		this.bunryu9 = bunryu9;
	}


	@Column(name="CAUTION_CODE")
	public String getCautionCode() {
		return this.cautionCode;
	}

	public void setCautionCode(String cautionCode) {
		this.cautionCode = cautionCode;
	}


	@Column(name="CHANGE_QTYL")
	public double getChangeQtyl() {
		return this.changeQtyl;
	}

	public void setChangeQtyl(double changeQtyl) {
		this.changeQtyl = changeQtyl;
	}


	@Column(name="CHANGE_QTYO")
	public double getChangeQtyo() {
		return this.changeQtyo;
	}

	public void setChangeQtyo(double changeQtyo) {
		this.changeQtyo = changeQtyo;
	}


	@Column(name="CHANGE_QTYP")
	public double getChangeQtyp() {
		return this.changeQtyp;
	}

	public void setChangeQtyp(double changeQtyp) {
		this.changeQtyp = changeQtyp;
	}


	public String getChanggo1() {
		return this.changgo1;
	}

	public void setChanggo1(String changgo1) {
		this.changgo1 = changgo1;
	}


	public String getChanggo2() {
		return this.changgo2;
	}

	public void setChanggo2(String changgo2) {
		this.changgo2 = changgo2;
	}


	public String getChanggo3() {
		return this.changgo3;
	}

	public void setChanggo3(String changgo3) {
		this.changgo3 = changgo3;
	}


	@Column(name="COMPANY_CODE")
	public String getCompanyCode() {
		return this.companyCode;
	}

	public void setCompanyCode(String companyCode) {
		this.companyCode = companyCode;
	}


	@Column(name="CUSTOMER_CODE")
	public String getCustomerCode() {
		return this.customerCode;
	}

	public void setCustomerCode(String customerCode) {
		this.customerCode = customerCode;
	}


	@Column(name="CUSTOMER_CODE2")
	public String getCustomerCode2() {
		return this.customerCode2;
	}

	public void setCustomerCode2(String customerCode2) {
		this.customerCode2 = customerCode2;
	}


	@Column(name="CUSTOMER_CODE3")
	public String getCustomerCode3() {
		return this.customerCode3;
	}

	public void setCustomerCode3(String customerCode3) {
		this.customerCode3 = customerCode3;
	}


	public double getDanga() {
		return this.danga;
	}

	public void setDanga(double danga) {
		this.danga = danga;
	}


	@Column(name="DANGA_YN")
	public String getDangaYn() {
		return this.dangaYn;
	}

	public void setDangaYn(String dangaYn) {
		this.dangaYn = dangaYn;
	}


	@Column(name="DRG_MAX_DV")
	public double getDrgMaxDv() {
		return this.drgMaxDv;
	}

	public void setDrgMaxDv(double drgMaxDv) {
		this.drgMaxDv = drgMaxDv;
	}


	@Column(name="DRG_MAX_SURYANG")
	public double getDrgMaxSuryang() {
		return this.drgMaxSuryang;
	}

	public void setDrgMaxSuryang(double drgMaxSuryang) {
		this.drgMaxSuryang = drgMaxSuryang;
	}


	@Column(name="DRG_TYPE")
	public String getDrgType() {
		return this.drgType;
	}

	public void setDrgType(String drgType) {
		this.drgType = drgType;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="END_DATE")
	public Date getEndDate() {
		return this.endDate;
	}

	public void setEndDate(Date endDate) {
		this.endDate = endDate;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="FROM_DANGA_DATE")
	public Date getFromDangaDate() {
		return this.fromDangaDate;
	}

	public void setFromDangaDate(Date fromDangaDate) {
		this.fromDangaDate = fromDangaDate;
	}


	@Column(name="GIJUN_AMT")
	public double getGijunAmt() {
		return this.gijunAmt;
	}

	public void setGijunAmt(double gijunAmt) {
		this.gijunAmt = gijunAmt;
	}


	@Column(name="GIJUN_ASSURE_AMT")
	public double getGijunAssureAmt() {
		return this.gijunAssureAmt;
	}

	public void setGijunAssureAmt(double gijunAssureAmt) {
		this.gijunAssureAmt = gijunAssureAmt;
	}


	public String getHamryang() {
		return this.hamryang;
	}

	public void setHamryang(String hamryang) {
		this.hamryang = hamryang;
	}


	@Column(name="HAMRYANG_DANUI")
	public String getHamryangDanui() {
		return this.hamryangDanui;
	}

	public void setHamryangDanui(String hamryangDanui) {
		this.hamryangDanui = hamryangDanui;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="HYONEUNG_CODE")
	public String getHyoneungCode() {
		return this.hyoneungCode;
	}

	public void setHyoneungCode(String hyoneungCode) {
		this.hyoneungCode = hyoneungCode;
	}


	@Column(name="ICE_YN")
	public String getIceYn() {
		return this.iceYn;
	}

	public void setIceYn(String iceYn) {
		this.iceYn = iceYn;
	}


	@Column(name="IP_ADDR")
	public String getIpAddr() {
		return this.ipAddr;
	}

	public void setIpAddr(String ipAddr) {
		this.ipAddr = ipAddr;
	}


	@Column(name="IPCHAL_TYPE")
	public String getIpchalType() {
		return this.ipchalType;
	}

	public void setIpchalType(String ipchalType) {
		this.ipchalType = ipchalType;
	}


	@Column(name="IUD_GUBUN")
	public String getIudGubun() {
		return this.iudGubun;
	}

	public void setIudGubun(String iudGubun) {
		this.iudGubun = iudGubun;
	}


	@Column(name="JAEGO_AMT")
	public double getJaegoAmt() {
		return this.jaegoAmt;
	}

	public void setJaegoAmt(double jaegoAmt) {
		this.jaegoAmt = jaegoAmt;
	}


	@Column(name="JAEGO_QTY")
	public double getJaegoQty() {
		return this.jaegoQty;
	}

	public void setJaegoQty(double jaegoQty) {
		this.jaegoQty = jaegoQty;
	}


	@Column(name="JAERYO_CODE")
	public String getJaeryoCode() {
		return this.jaeryoCode;
	}

	public void setJaeryoCode(String jaeryoCode) {
		this.jaeryoCode = jaeryoCode;
	}


	@Column(name="JAERYO_E_NAME")
	public String getJaeryoEName() {
		return this.jaeryoEName;
	}

	public void setJaeryoEName(String jaeryoEName) {
		this.jaeryoEName = jaeryoEName;
	}


	@Column(name="JAERYO_GRADE")
	public String getJaeryoGrade() {
		return this.jaeryoGrade;
	}

	public void setJaeryoGrade(String jaeryoGrade) {
		this.jaeryoGrade = jaeryoGrade;
	}


	@Column(name="JAERYO_GUBUN")
	public String getJaeryoGubun() {
		return this.jaeryoGubun;
	}

	public void setJaeryoGubun(String jaeryoGubun) {
		this.jaeryoGubun = jaeryoGubun;
	}


	@Column(name="JAERYO_NAME")
	public String getJaeryoName() {
		return this.jaeryoName;
	}

	public void setJaeryoName(String jaeryoName) {
		this.jaeryoName = jaeryoName;
	}


	@Column(name="JAERYO_NAME_INX")
	public String getJaeryoNameInx() {
		return this.jaeryoNameInx;
	}

	public void setJaeryoNameInx(String jaeryoNameInx) {
		this.jaeryoNameInx = jaeryoNameInx;
	}


	@Column(name="JEJE_GIJUN_QTY")
	public double getJejeGijunQty() {
		return this.jejeGijunQty;
	}

	public void setJejeGijunQty(double jejeGijunQty) {
		this.jejeGijunQty = jejeGijunQty;
	}


	@Column(name="JUKJUNG_QTY")
	public double getJukjungQty() {
		return this.jukjungQty;
	}

	public void setJukjungQty(double jukjungQty) {
		this.jukjungQty = jukjungQty;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="JUKYONG_DATE")
	public Date getJukyongDate() {
		return this.jukyongDate;
	}

	public void setJukyongDate(Date jukyongDate) {
		this.jukyongDate = jukyongDate;
	}


	public String getKyukyeok() {
		return this.kyukyeok;
	}

	public void setKyukyeok(String kyukyeok) {
		this.kyukyeok = kyukyeok;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="LAST_CHULGO_DATE")
	public Date getLastChulgoDate() {
		return this.lastChulgoDate;
	}

	public void setLastChulgoDate(Date lastChulgoDate) {
		this.lastChulgoDate = lastChulgoDate;
	}


	@Column(name="LAST_IBGO_DANGA")
	public double getLastIbgoDanga() {
		return this.lastIbgoDanga;
	}

	public void setLastIbgoDanga(double lastIbgoDanga) {
		this.lastIbgoDanga = lastIbgoDanga;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="LAST_IBGO_DATE")
	public Date getLastIbgoDate() {
		return this.lastIbgoDate;
	}

	public void setLastIbgoDate(Date lastIbgoDate) {
		this.lastIbgoDate = lastIbgoDate;
	}


	@Column(name="LAUNDRY_DANGA")
	public double getLaundryDanga() {
		return this.laundryDanga;
	}

	public void setLaundryDanga(double laundryDanga) {
		this.laundryDanga = laundryDanga;
	}


	@Column(name="LEAD_TIME")
	public double getLeadTime() {
		return this.leadTime;
	}

	public void setLeadTime(double leadTime) {
		this.leadTime = leadTime;
	}


	@Column(name="MAIN_USE_GWA1")
	public String getMainUseGwa1() {
		return this.mainUseGwa1;
	}

	public void setMainUseGwa1(String mainUseGwa1) {
		this.mainUseGwa1 = mainUseGwa1;
	}


	@Column(name="MAIN_USE_GWA2")
	public String getMainUseGwa2() {
		return this.mainUseGwa2;
	}

	public void setMainUseGwa2(String mainUseGwa2) {
		this.mainUseGwa2 = mainUseGwa2;
	}


	@Column(name="MAIN_USE_GWA3")
	public String getMainUseGwa3() {
		return this.mainUseGwa3;
	}

	public void setMainUseGwa3(String mainUseGwa3) {
		this.mainUseGwa3 = mainUseGwa3;
	}


	@Column(name="MAIN_USE_GWA4")
	public String getMainUseGwa4() {
		return this.mainUseGwa4;
	}

	public void setMainUseGwa4(String mainUseGwa4) {
		this.mainUseGwa4 = mainUseGwa4;
	}


	@Column(name="MAIN_USE_GWA5")
	public String getMainUseGwa5() {
		return this.mainUseGwa5;
	}

	public void setMainUseGwa5(String mainUseGwa5) {
		this.mainUseGwa5 = mainUseGwa5;
	}


	@Column(name="MANAGE_NAME")
	public String getManageName() {
		return this.manageName;
	}

	public void setManageName(String manageName) {
		this.manageName = manageName;
	}


	@Column(name="MANAGE_NO")
	public String getManageNo() {
		return this.manageNo;
	}

	public void setManageNo(String manageNo) {
		this.manageNo = manageNo;
	}


	@Column(name="MANAGE_NO1")
	public String getManageNo1() {
		return this.manageNo1;
	}

	public void setManageNo1(String manageNo1) {
		this.manageNo1 = manageNo1;
	}


	@Column(name="MANAGE_NO2")
	public String getManageNo2() {
		return this.manageNo2;
	}

	public void setManageNo2(String manageNo2) {
		this.manageNo2 = manageNo2;
	}


	@Column(name="MANAGE_NO3")
	public String getManageNo3() {
		return this.manageNo3;
	}

	public void setManageNo3(String manageNo3) {
		this.manageNo3 = manageNo3;
	}


	@Column(name="MANAGE_NO4")
	public String getManageNo4() {
		return this.manageNo4;
	}

	public void setManageNo4(String manageNo4) {
		this.manageNo4 = manageNo4;
	}


	@Column(name="MAX_QTY_D")
	public double getMaxQtyD() {
		return this.maxQtyD;
	}

	public void setMaxQtyD(double maxQtyD) {
		this.maxQtyD = maxQtyD;
	}


	@Column(name="MAX_QTY_M")
	public double getMaxQtyM() {
		return this.maxQtyM;
	}

	public void setMaxQtyM(double maxQtyM) {
		this.maxQtyM = maxQtyM;
	}


	@Column(name="MAX_QTY_W")
	public double getMaxQtyW() {
		return this.maxQtyW;
	}

	public void setMaxQtyW(double maxQtyW) {
		this.maxQtyW = maxQtyW;
	}


	@Column(name="MID_GUBUN")
	public String getMidGubun() {
		return this.midGubun;
	}

	public void setMidGubun(String midGubun) {
		this.midGubun = midGubun;
	}


	@Column(name="MIX_YN")
	public String getMixYn() {
		return this.mixYn;
	}

	public void setMixYn(String mixYn) {
		this.mixYn = mixYn;
	}


	@Column(name="MIX_YN_INP")
	public String getMixYnInp() {
		return this.mixYnInp;
	}

	public void setMixYnInp(String mixYnInp) {
		this.mixYnInp = mixYnInp;
	}


	@Column(name="OLD_MANAGE_NO")
	public String getOldManageNo() {
		return this.oldManageNo;
	}

	public void setOldManageNo(String oldManageNo) {
		this.oldManageNo = oldManageNo;
	}


	@Column(name="ORDER_DANUI")
	public String getOrderDanui() {
		return this.orderDanui;
	}

	public void setOrderDanui(String orderDanui) {
		this.orderDanui = orderDanui;
	}


	@Column(name="ORDER_SUBUL_DANUI")
	public String getOrderSubulDanui() {
		return this.orderSubulDanui;
	}

	public void setOrderSubulDanui(String orderSubulDanui) {
		this.orderSubulDanui = orderSubulDanui;
	}


	@Column(name="PRIS_NAME")
	public String getPrisName() {
		return this.prisName;
	}

	public void setPrisName(String prisName) {
		this.prisName = prisName;
	}


	public String getRemark() {
		return this.remark;
	}

	public void setRemark(String remark) {
		this.remark = remark;
	}


	@Column(name="SMALL_CODE")
	public String getSmallCode() {
		return this.smallCode;
	}

	public void setSmallCode(String smallCode) {
		this.smallCode = smallCode;
	}


	@Column(name="SORT_KEY")
	public double getSortKey() {
		return this.sortKey;
	}

	public void setSortKey(double sortKey) {
		this.sortKey = sortKey;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="START_DATE")
	public Date getStartDate() {
		return this.startDate;
	}

	public void setStartDate(Date startDate) {
		this.startDate = startDate;
	}


	@Column(name="STORAGE_YN")
	public String getStorageYn() {
		return this.storageYn;
	}

	public void setStorageYn(String storageYn) {
		this.storageYn = storageYn;
	}


	@Column(name="SUBUL_BUSEO")
	public String getSubulBuseo() {
		return this.subulBuseo;
	}

	public void setSubulBuseo(String subulBuseo) {
		this.subulBuseo = subulBuseo;
	}


	@Column(name="SUBUL_DANUI")
	public String getSubulDanui() {
		return this.subulDanui;
	}

	public void setSubulDanui(String subulDanui) {
		this.subulDanui = subulDanui;
	}


	@Column(name="SUBUL_QCODE_ER")
	public String getSubulQcodeEr() {
		return this.subulQcodeEr;
	}

	public void setSubulQcodeEr(String subulQcodeEr) {
		this.subulQcodeEr = subulQcodeEr;
	}


	@Column(name="SUBUL_QCODE_INP")
	public String getSubulQcodeInp() {
		return this.subulQcodeInp;
	}

	public void setSubulQcodeInp(String subulQcodeInp) {
		this.subulQcodeInp = subulQcodeInp;
	}


	@Column(name="SUBUL_QCODE_OUT")
	public String getSubulQcodeOut() {
		return this.subulQcodeOut;
	}

	public void setSubulQcodeOut(String subulQcodeOut) {
		this.subulQcodeOut = subulQcodeOut;
	}


	@Column(name="SUGB_JAERYO_YN")
	public String getSugbJaeryoYn() {
		return this.sugbJaeryoYn;
	}

	public void setSugbJaeryoYn(String sugbJaeryoYn) {
		this.sugbJaeryoYn = sugbJaeryoYn;
	}


	@Column(name="SUIB_CUSTOMER")
	public String getSuibCustomer() {
		return this.suibCustomer;
	}

	public void setSuibCustomer(String suibCustomer) {
		this.suibCustomer = suibCustomer;
	}


	@Column(name="SUIB_YN")
	public String getSuibYn() {
		return this.suibYn;
	}

	public void setSuibYn(String suibYn) {
		this.suibYn = suibYn;
	}


	@Column(name="SUNGBUN_CODE")
	public String getSungbunCode() {
		return this.sungbunCode;
	}

	public void setSungbunCode(String sungbunCode) {
		this.sungbunCode = sungbunCode;
	}


	@Column(name="SUNGBUN_NAME")
	public String getSungbunName() {
		return this.sungbunName;
	}

	public void setSungbunName(String sungbunName) {
		this.sungbunName = sungbunName;
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
	@Column(name="TO_DANGA_DATE")
	public Date getToDangaDate() {
		return this.toDangaDate;
	}

	public void setToDangaDate(Date toDangaDate) {
		this.toDangaDate = toDangaDate;
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


	@Column(name="USE_YN")
	public String getUseYn() {
		return this.useYn;
	}

	public void setUseYn(String useYn) {
		this.useYn = useYn;
	}


	public double getWeight() {
		return this.weight;
	}

	public void setWeight(double weight) {
		this.weight = weight;
	}


	@Column(name="YUHYO_MONTH")
	public double getYuhyoMonth() {
		return this.yuhyoMonth;
	}

	public void setYuhyoMonth(double yuhyoMonth) {
		this.yuhyoMonth = yuhyoMonth;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="YUHYO_TO_DATE")
	public Date getYuhyoToDate() {
		return this.yuhyoToDate;
	}

	public void setYuhyoToDate(Date yuhyoToDate) {
		this.yuhyoToDate = yuhyoToDate;
	}


	@Column(name="YUHYO_YN")
	public String getYuhyoYn() {
		return this.yuhyoYn;
	}

	public void setYuhyoYn(String yuhyoYn) {
		this.yuhyoYn = yuhyoYn;
	}


	@Column(name="YUNHAP_CODE")
	public String getYunhapCode() {
		return this.yunhapCode;
	}

	public void setYunhapCode(String yunhapCode) {
		this.yunhapCode = yunhapCode;
	}


	@Column(name="YUNHAP_JOIN_YN")
	public String getYunhapJoinYn() {
		return this.yunhapJoinYn;
	}

	public void setYunhapJoinYn(String yunhapJoinYn) {
		this.yunhapJoinYn = yunhapJoinYn;
	}

}