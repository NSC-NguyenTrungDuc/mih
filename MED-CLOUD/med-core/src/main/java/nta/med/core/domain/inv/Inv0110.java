package nta.med.core.domain.inv;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.PrePersist;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;

/**
 * The persistent class for the INV0110 database table.
 * 
 */
@Entity
@Table(name = "INV0110")
public class Inv0110 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String acctId;
	private String actJaeryoName;
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
	private double bugaseYul;
	private String bulyongCode;
	private Date bulyongDate;
	private Date bulyongToDate;
	private String bungiAcct;
	private String bunryuBunho1;
	private String bunryuBunho2;
	private String bunryuBunho3;
	private String bunryuBunho4;
	private String bunryuBunho5;
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
	private String chk1;
	private String chk2;
	private String chk3;
	private String chk4;
	private String chk5;
	private String chk6;
	private String chk7;
	private String chk8;
	private String chk9;
	private String chka;
	private String chkb;
	private String chkc;
	private String chkd;
	private String chke;
	private String chkf;
	private String companyCode;
	private String companyName;
	private String curency;
	private String customerCode;
	private String customerCode2;
	private String customerCode3;
	private double customerDanga;
	private double danga;
	private String dangaYn;
	private String deliveryGubun;
	private String drgComment;
	private String drgJibgyeGubun;
	private double drgMaxDv;
	private double drgMaxSuryang;
	private double drgTrunc;
	private String drgType;
	private Date endDate;
	private Date firstIbgoDate;
	private Date fromDangaDate;
	private String generationYn;
	private double gijunAmt;
	private double gijunAssureAmt;
	private double gijunDanga;
	private String gijunKyukyeok;
	private String hamryang;
	private String hamryangDanui;
	private String hospCode;
	private String hyoneungCode;
	private String iceYn;
	private String ipAddr;
	private String ipchalType;
	private String irJundalYn;
	private double jaegoAmt;
	private double jaegoQty;
	private String jaeryoCode;
	private String jaeryoEName;
	private String jaeryoGrade;
	private String jaeryoGubun;
	private String jaeryoName;
	private String jaeryoNameInx;
	private String jaeryoStatus;
	private double jejeGijunQty;
	private String jibgyeYn;
	private double jukjungQty;
	private Date jukyongDate;
	private String jusa;
	private String kyukyeok;
	private String labelDanui;
	private String labelDanui2;
	private String labelYn;
	private Date lastChulgoDate;
	private double lastIbgoDanga;
	private Date lastIbgoDate;
	private double laundryDanga;
	private double leadTime;
	private double limitDv;
	private String mainSungbunCode;
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
	private double minBaljuQty;
	private double minChungguQty;
	private String mixYn;
	private String mixYnInp;
	private String modelName;
	private String oldManageNo;
	private String orderDanui;
	private String orderSubulDanui;
	private String pathBmp;
	private String prisName;
	private String rackNo;
	private String rackNo2;
	private String reUseYn;
	private String remark;
	private String setCode;
	private String skinTestYn;
	private String smallCode;
	private String smallCode1;
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
	private String sutakYn;
	private Date sysDate;
	private String sysId;
	private String tbYn;
	private String textColor;
	private Date toDangaDate;
	private String toijangYn;
	private Date updDate;
	private String updId;
	private String useYn;
	private double weight;
	private String yongryang;
	private double yuhyoMonth;
	private Date yuhyoToDate;
	private String yuhyoYn;
	private String yunhapCode;
	private String yunhapJoinYn;
	private String modifyFlg;
	private String stockYn;
	private Double subulDanga;
	
	public Inv0110() {
	}

	@Column(name = "ACCT_ID")
	public String getAcctId() {
		return this.acctId;
	}

	public void setAcctId(String acctId) {
		this.acctId = acctId;
	}

	@Column(name = "ACT_JAERYO_NAME")
	public String getActJaeryoName() {
		return this.actJaeryoName;
	}

	public void setActJaeryoName(String actJaeryoName) {
		this.actJaeryoName = actJaeryoName;
	}

	@Column(name = "ATC_CODE")
	public String getAtcCode() {
		return this.atcCode;
	}

	public void setAtcCode(String atcCode) {
		this.atcCode = atcCode;
	}

	@Column(name = "ATC_YN")
	public String getAtcYn() {
		return this.atcYn;
	}

	public void setAtcYn(String atcYn) {
		this.atcYn = atcYn;
	}

	@Column(name = "ATC_YN_INP")
	public String getAtcYnInp() {
		return this.atcYnInp;
	}

	public void setAtcYnInp(String atcYnInp) {
		this.atcYnInp = atcYnInp;
	}

	@Column(name = "AVG_QTY_D")
	public double getAvgQtyD() {
		return this.avgQtyD;
	}

	public void setAvgQtyD(double avgQtyD) {
		this.avgQtyD = avgQtyD;
	}

	@Column(name = "AVG_QTY_M")
	public double getAvgQtyM() {
		return this.avgQtyM;
	}

	public void setAvgQtyM(double avgQtyM) {
		this.avgQtyM = avgQtyM;
	}

	@Column(name = "AVG_QTY_W")
	public double getAvgQtyW() {
		return this.avgQtyW;
	}

	public void setAvgQtyW(double avgQtyW) {
		this.avgQtyW = avgQtyW;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "BALJU_BULYONG_DATE")
	public Date getBaljuBulyongDate() {
		return this.baljuBulyongDate;
	}

	public void setBaljuBulyongDate(Date baljuBulyongDate) {
		this.baljuBulyongDate = baljuBulyongDate;
	}

	@Column(name = "BALJU_BUSEO")
	public String getBaljuBuseo() {
		return this.baljuBuseo;
	}

	public void setBaljuBuseo(String baljuBuseo) {
		this.baljuBuseo = baljuBuseo;
	}

	@Column(name = "BALJU_DANUI")
	public String getBaljuDanui() {
		return this.baljuDanui;
	}

	public void setBaljuDanui(String baljuDanui) {
		this.baljuDanui = baljuDanui;
	}

	@Column(name = "BANNAB_YN")
	public String getBannabYn() {
		return this.bannabYn;
	}

	public void setBannabYn(String bannabYn) {
		this.bannabYn = bannabYn;
	}

	@Column(name = "BOGYONG_CODE")
	public String getBogyongCode() {
		return this.bogyongCode;
	}

	public void setBogyongCode(String bogyongCode) {
		this.bogyongCode = bogyongCode;
	}

	@Column(name = "BOGYONG_CODE1")
	public String getBogyongCode1() {
		return this.bogyongCode1;
	}

	public void setBogyongCode1(String bogyongCode1) {
		this.bogyongCode1 = bogyongCode1;
	}

	@Column(name = "BOGYONG_CODE2")
	public String getBogyongCode2() {
		return this.bogyongCode2;
	}

	public void setBogyongCode2(String bogyongCode2) {
		this.bogyongCode2 = bogyongCode2;
	}

	@Column(name = "BOGYONG_CODE3")
	public String getBogyongCode3() {
		return this.bogyongCode3;
	}

	public void setBogyongCode3(String bogyongCode3) {
		this.bogyongCode3 = bogyongCode3;
	}

	@Column(name = "BOGYONG_CODE4")
	public String getBogyongCode4() {
		return this.bogyongCode4;
	}

	public void setBogyongCode4(String bogyongCode4) {
		this.bogyongCode4 = bogyongCode4;
	}

	@Column(name = "BUGASE_YUL")
	public double getBugaseYul() {
		return this.bugaseYul;
	}

	public void setBugaseYul(double bugaseYul) {
		this.bugaseYul = bugaseYul;
	}

	@Column(name = "BULYONG_CODE")
	public String getBulyongCode() {
		return this.bulyongCode;
	}

	public void setBulyongCode(String bulyongCode) {
		this.bulyongCode = bulyongCode;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "BULYONG_DATE")
	public Date getBulyongDate() {
		return this.bulyongDate;
	}

	public void setBulyongDate(Date bulyongDate) {
		this.bulyongDate = bulyongDate;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "BULYONG_TO_DATE")
	public Date getBulyongToDate() {
		return this.bulyongToDate;
	}

	public void setBulyongToDate(Date bulyongToDate) {
		this.bulyongToDate = bulyongToDate;
	}

	@Column(name = "BUNGI_ACCT")
	public String getBungiAcct() {
		return this.bungiAcct;
	}

	public void setBungiAcct(String bungiAcct) {
		this.bungiAcct = bungiAcct;
	}

	@Column(name = "BUNRYU_BUNHO1")
	public String getBunryuBunho1() {
		return this.bunryuBunho1;
	}

	public void setBunryuBunho1(String bunryuBunho1) {
		this.bunryuBunho1 = bunryuBunho1;
	}

	@Column(name = "BUNRYU_BUNHO2")
	public String getBunryuBunho2() {
		return this.bunryuBunho2;
	}

	public void setBunryuBunho2(String bunryuBunho2) {
		this.bunryuBunho2 = bunryuBunho2;
	}

	@Column(name = "BUNRYU_BUNHO3")
	public String getBunryuBunho3() {
		return this.bunryuBunho3;
	}

	public void setBunryuBunho3(String bunryuBunho3) {
		this.bunryuBunho3 = bunryuBunho3;
	}

	@Column(name = "BUNRYU_BUNHO4")
	public String getBunryuBunho4() {
		return this.bunryuBunho4;
	}

	public void setBunryuBunho4(String bunryuBunho4) {
		this.bunryuBunho4 = bunryuBunho4;
	}

	@Column(name = "BUNRYU_BUNHO5")
	public String getBunryuBunho5() {
		return this.bunryuBunho5;
	}

	public void setBunryuBunho5(String bunryuBunho5) {
		this.bunryuBunho5 = bunryuBunho5;
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

	@Column(name = "CAUTION_CODE")
	public String getCautionCode() {
		return this.cautionCode;
	}

	public void setCautionCode(String cautionCode) {
		this.cautionCode = cautionCode;
	}

	@Column(name = "CHANGE_QTYL")
	public double getChangeQtyl() {
		return this.changeQtyl;
	}

	public void setChangeQtyl(double changeQtyl) {
		this.changeQtyl = changeQtyl;
	}

	@Column(name = "CHANGE_QTYO")
	public double getChangeQtyo() {
		return this.changeQtyo;
	}

	public void setChangeQtyo(double changeQtyo) {
		this.changeQtyo = changeQtyo;
	}

	@Column(name = "CHANGE_QTYP")
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

	public String getChk1() {
		return this.chk1;
	}

	public void setChk1(String chk1) {
		this.chk1 = chk1;
	}

	public String getChk2() {
		return this.chk2;
	}

	public void setChk2(String chk2) {
		this.chk2 = chk2;
	}

	public String getChk3() {
		return this.chk3;
	}

	public void setChk3(String chk3) {
		this.chk3 = chk3;
	}

	public String getChk4() {
		return this.chk4;
	}

	public void setChk4(String chk4) {
		this.chk4 = chk4;
	}

	public String getChk5() {
		return this.chk5;
	}

	public void setChk5(String chk5) {
		this.chk5 = chk5;
	}

	public String getChk6() {
		return this.chk6;
	}

	public void setChk6(String chk6) {
		this.chk6 = chk6;
	}

	public String getChk7() {
		return this.chk7;
	}

	public void setChk7(String chk7) {
		this.chk7 = chk7;
	}

	public String getChk8() {
		return this.chk8;
	}

	public void setChk8(String chk8) {
		this.chk8 = chk8;
	}

	public String getChk9() {
		return this.chk9;
	}

	public void setChk9(String chk9) {
		this.chk9 = chk9;
	}

	public String getChka() {
		return this.chka;
	}

	public void setChka(String chka) {
		this.chka = chka;
	}

	public String getChkb() {
		return this.chkb;
	}

	public void setChkb(String chkb) {
		this.chkb = chkb;
	}

	public String getChkc() {
		return this.chkc;
	}

	public void setChkc(String chkc) {
		this.chkc = chkc;
	}

	public String getChkd() {
		return this.chkd;
	}

	public void setChkd(String chkd) {
		this.chkd = chkd;
	}

	public String getChke() {
		return this.chke;
	}

	public void setChke(String chke) {
		this.chke = chke;
	}

	public String getChkf() {
		return this.chkf;
	}

	public void setChkf(String chkf) {
		this.chkf = chkf;
	}

	@Column(name = "COMPANY_CODE")
	public String getCompanyCode() {
		return this.companyCode;
	}

	public void setCompanyCode(String companyCode) {
		this.companyCode = companyCode;
	}

	@Column(name = "COMPANY_NAME")
	public String getCompanyName() {
		return this.companyName;
	}

	public void setCompanyName(String companyName) {
		this.companyName = companyName;
	}

	public String getCurency() {
		return this.curency;
	}

	public void setCurency(String curency) {
		this.curency = curency;
	}

	@Column(name = "CUSTOMER_CODE")
	public String getCustomerCode() {
		return this.customerCode;
	}

	public void setCustomerCode(String customerCode) {
		this.customerCode = customerCode;
	}

	@Column(name = "CUSTOMER_CODE2")
	public String getCustomerCode2() {
		return this.customerCode2;
	}

	public void setCustomerCode2(String customerCode2) {
		this.customerCode2 = customerCode2;
	}

	@Column(name = "CUSTOMER_CODE3")
	public String getCustomerCode3() {
		return this.customerCode3;
	}

	public void setCustomerCode3(String customerCode3) {
		this.customerCode3 = customerCode3;
	}

	@Column(name = "CUSTOMER_DANGA")
	public double getCustomerDanga() {
		return this.customerDanga;
	}

	public void setCustomerDanga(double customerDanga) {
		this.customerDanga = customerDanga;
	}

	public double getDanga() {
		return this.danga;
	}

	public void setDanga(double danga) {
		this.danga = danga;
	}

	@Column(name = "DANGA_YN")
	public String getDangaYn() {
		return this.dangaYn;
	}

	public void setDangaYn(String dangaYn) {
		this.dangaYn = dangaYn;
	}

	@Column(name = "DELIVERY_GUBUN")
	public String getDeliveryGubun() {
		return this.deliveryGubun;
	}

	public void setDeliveryGubun(String deliveryGubun) {
		this.deliveryGubun = deliveryGubun;
	}

	@Column(name = "DRG_COMMENT")
	public String getDrgComment() {
		return this.drgComment;
	}

	public void setDrgComment(String drgComment) {
		this.drgComment = drgComment;
	}

	@Column(name = "DRG_JIBGYE_GUBUN")
	public String getDrgJibgyeGubun() {
		return this.drgJibgyeGubun;
	}

	public void setDrgJibgyeGubun(String drgJibgyeGubun) {
		this.drgJibgyeGubun = drgJibgyeGubun;
	}

	@Column(name = "DRG_MAX_DV")
	public double getDrgMaxDv() {
		return this.drgMaxDv;
	}

	public void setDrgMaxDv(double drgMaxDv) {
		this.drgMaxDv = drgMaxDv;
	}

	@Column(name = "DRG_MAX_SURYANG")
	public double getDrgMaxSuryang() {
		return this.drgMaxSuryang;
	}

	public void setDrgMaxSuryang(double drgMaxSuryang) {
		this.drgMaxSuryang = drgMaxSuryang;
	}

	@Column(name = "DRG_TRUNC")
	public double getDrgTrunc() {
		return this.drgTrunc;
	}

	public void setDrgTrunc(double drgTrunc) {
		this.drgTrunc = drgTrunc;
	}

	@Column(name = "DRG_TYPE")
	public String getDrgType() {
		return this.drgType;
	}

	public void setDrgType(String drgType) {
		this.drgType = drgType;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "END_DATE")
	public Date getEndDate() {
		return this.endDate;
	}

	public void setEndDate(Date endDate) {
		this.endDate = endDate;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "FIRST_IBGO_DATE")
	public Date getFirstIbgoDate() {
		return this.firstIbgoDate;
	}

	public void setFirstIbgoDate(Date firstIbgoDate) {
		this.firstIbgoDate = firstIbgoDate;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "FROM_DANGA_DATE")
	public Date getFromDangaDate() {
		return this.fromDangaDate;
	}

	public void setFromDangaDate(Date fromDangaDate) {
		this.fromDangaDate = fromDangaDate;
	}

	@Column(name = "GENERATION_YN")
	public String getGenerationYn() {
		return this.generationYn;
	}

	public void setGenerationYn(String generationYn) {
		this.generationYn = generationYn;
	}

	@Column(name = "GIJUN_AMT")
	public double getGijunAmt() {
		return this.gijunAmt;
	}

	public void setGijunAmt(double gijunAmt) {
		this.gijunAmt = gijunAmt;
	}

	@Column(name = "GIJUN_ASSURE_AMT")
	public double getGijunAssureAmt() {
		return this.gijunAssureAmt;
	}

	public void setGijunAssureAmt(double gijunAssureAmt) {
		this.gijunAssureAmt = gijunAssureAmt;
	}

	@Column(name = "GIJUN_DANGA")
	public double getGijunDanga() {
		return this.gijunDanga;
	}

	public void setGijunDanga(double gijunDanga) {
		this.gijunDanga = gijunDanga;
	}

	@Column(name = "GIJUN_KYUKYEOK")
	public String getGijunKyukyeok() {
		return this.gijunKyukyeok;
	}

	public void setGijunKyukyeok(String gijunKyukyeok) {
		this.gijunKyukyeok = gijunKyukyeok;
	}

	public String getHamryang() {
		return this.hamryang;
	}

	public void setHamryang(String hamryang) {
		this.hamryang = hamryang;
	}

	@Column(name = "HAMRYANG_DANUI")
	public String getHamryangDanui() {
		return this.hamryangDanui;
	}

	public void setHamryangDanui(String hamryangDanui) {
		this.hamryangDanui = hamryangDanui;
	}

	@Column(name = "HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}

	@Column(name = "HYONEUNG_CODE")
	public String getHyoneungCode() {
		return this.hyoneungCode;
	}

	public void setHyoneungCode(String hyoneungCode) {
		this.hyoneungCode = hyoneungCode;
	}

	@Column(name = "ICE_YN")
	public String getIceYn() {
		return this.iceYn;
	}

	public void setIceYn(String iceYn) {
		this.iceYn = iceYn;
	}

	@Column(name = "IP_ADDR")
	public String getIpAddr() {
		return this.ipAddr;
	}

	public void setIpAddr(String ipAddr) {
		this.ipAddr = ipAddr;
	}

	@Column(name = "IPCHAL_TYPE")
	public String getIpchalType() {
		return this.ipchalType;
	}

	public void setIpchalType(String ipchalType) {
		this.ipchalType = ipchalType;
	}

	@Column(name = "IR_JUNDAL_YN")
	public String getIrJundalYn() {
		return this.irJundalYn;
	}

	public void setIrJundalYn(String irJundalYn) {
		this.irJundalYn = irJundalYn;
	}

	@Column(name = "JAEGO_AMT")
	public double getJaegoAmt() {
		return this.jaegoAmt;
	}

	public void setJaegoAmt(double jaegoAmt) {
		this.jaegoAmt = jaegoAmt;
	}

	@Column(name = "JAEGO_QTY")
	public double getJaegoQty() {
		return this.jaegoQty;
	}

	public void setJaegoQty(double jaegoQty) {
		this.jaegoQty = jaegoQty;
	}

	@Column(name = "JAERYO_CODE")
	public String getJaeryoCode() {
		return this.jaeryoCode;
	}

	public void setJaeryoCode(String jaeryoCode) {
		this.jaeryoCode = jaeryoCode;
	}

	@Column(name = "JAERYO_E_NAME")
	public String getJaeryoEName() {
		return this.jaeryoEName;
	}

	public void setJaeryoEName(String jaeryoEName) {
		this.jaeryoEName = jaeryoEName;
	}

	@Column(name = "JAERYO_GRADE")
	public String getJaeryoGrade() {
		return this.jaeryoGrade;
	}

	public void setJaeryoGrade(String jaeryoGrade) {
		this.jaeryoGrade = jaeryoGrade;
	}

	@PrePersist
	public void prePersist() {
	    if(jaeryoGubun == null)
	    	jaeryoGubun = "A";
	}
	
	@Column(name = "JAERYO_GUBUN", nullable = false)
	public String getJaeryoGubun() {
		return this.jaeryoGubun;
	}

	public void setJaeryoGubun(String jaeryoGubun) {
		this.jaeryoGubun = jaeryoGubun;
	}

	@Column(name = "JAERYO_NAME")
	public String getJaeryoName() {
		return this.jaeryoName;
	}

	public void setJaeryoName(String jaeryoName) {
		this.jaeryoName = jaeryoName;
	}

	@Column(name = "JAERYO_NAME_INX")
	public String getJaeryoNameInx() {
		return this.jaeryoNameInx;
	}

	public void setJaeryoNameInx(String jaeryoNameInx) {
		this.jaeryoNameInx = jaeryoNameInx;
	}

	@Column(name = "JAERYO_STATUS")
	public String getJaeryoStatus() {
		return this.jaeryoStatus;
	}

	public void setJaeryoStatus(String jaeryoStatus) {
		this.jaeryoStatus = jaeryoStatus;
	}

	@Column(name = "JEJE_GIJUN_QTY")
	public double getJejeGijunQty() {
		return this.jejeGijunQty;
	}

	public void setJejeGijunQty(double jejeGijunQty) {
		this.jejeGijunQty = jejeGijunQty;
	}

	@Column(name = "JIBGYE_YN")
	public String getJibgyeYn() {
		return this.jibgyeYn;
	}

	public void setJibgyeYn(String jibgyeYn) {
		this.jibgyeYn = jibgyeYn;
	}

	@Column(name = "JUKJUNG_QTY")
	public double getJukjungQty() {
		return this.jukjungQty;
	}

	public void setJukjungQty(double jukjungQty) {
		this.jukjungQty = jukjungQty;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "JUKYONG_DATE")
	public Date getJukyongDate() {
		return this.jukyongDate;
	}

	public void setJukyongDate(Date jukyongDate) {
		this.jukyongDate = jukyongDate;
	}

	public String getJusa() {
		return this.jusa;
	}

	public void setJusa(String jusa) {
		this.jusa = jusa;
	}

	public String getKyukyeok() {
		return this.kyukyeok;
	}

	public void setKyukyeok(String kyukyeok) {
		this.kyukyeok = kyukyeok;
	}

	@Column(name = "LABEL_DANUI")
	public String getLabelDanui() {
		return this.labelDanui;
	}

	public void setLabelDanui(String labelDanui) {
		this.labelDanui = labelDanui;
	}

	@Column(name = "LABEL_DANUI2")
	public String getLabelDanui2() {
		return this.labelDanui2;
	}

	public void setLabelDanui2(String labelDanui2) {
		this.labelDanui2 = labelDanui2;
	}

	@Column(name = "LABEL_YN")
	public String getLabelYn() {
		return this.labelYn;
	}

	public void setLabelYn(String labelYn) {
		this.labelYn = labelYn;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "LAST_CHULGO_DATE")
	public Date getLastChulgoDate() {
		return this.lastChulgoDate;
	}

	public void setLastChulgoDate(Date lastChulgoDate) {
		this.lastChulgoDate = lastChulgoDate;
	}

	@Column(name = "LAST_IBGO_DANGA")
	public double getLastIbgoDanga() {
		return this.lastIbgoDanga;
	}

	public void setLastIbgoDanga(double lastIbgoDanga) {
		this.lastIbgoDanga = lastIbgoDanga;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "LAST_IBGO_DATE")
	public Date getLastIbgoDate() {
		return this.lastIbgoDate;
	}

	public void setLastIbgoDate(Date lastIbgoDate) {
		this.lastIbgoDate = lastIbgoDate;
	}

	@Column(name = "LAUNDRY_DANGA")
	public double getLaundryDanga() {
		return this.laundryDanga;
	}

	public void setLaundryDanga(double laundryDanga) {
		this.laundryDanga = laundryDanga;
	}

	@Column(name = "LEAD_TIME")
	public double getLeadTime() {
		return this.leadTime;
	}

	public void setLeadTime(double leadTime) {
		this.leadTime = leadTime;
	}

	@Column(name = "LIMIT_DV")
	public double getLimitDv() {
		return this.limitDv;
	}

	public void setLimitDv(double limitDv) {
		this.limitDv = limitDv;
	}

	@Column(name = "MAIN_SUNGBUN_CODE")
	public String getMainSungbunCode() {
		return this.mainSungbunCode;
	}

	public void setMainSungbunCode(String mainSungbunCode) {
		this.mainSungbunCode = mainSungbunCode;
	}

	@Column(name = "MAIN_USE_GWA1")
	public String getMainUseGwa1() {
		return this.mainUseGwa1;
	}

	public void setMainUseGwa1(String mainUseGwa1) {
		this.mainUseGwa1 = mainUseGwa1;
	}

	@Column(name = "MAIN_USE_GWA2")
	public String getMainUseGwa2() {
		return this.mainUseGwa2;
	}

	public void setMainUseGwa2(String mainUseGwa2) {
		this.mainUseGwa2 = mainUseGwa2;
	}

	@Column(name = "MAIN_USE_GWA3")
	public String getMainUseGwa3() {
		return this.mainUseGwa3;
	}

	public void setMainUseGwa3(String mainUseGwa3) {
		this.mainUseGwa3 = mainUseGwa3;
	}

	@Column(name = "MAIN_USE_GWA4")
	public String getMainUseGwa4() {
		return this.mainUseGwa4;
	}

	public void setMainUseGwa4(String mainUseGwa4) {
		this.mainUseGwa4 = mainUseGwa4;
	}

	@Column(name = "MAIN_USE_GWA5")
	public String getMainUseGwa5() {
		return this.mainUseGwa5;
	}

	public void setMainUseGwa5(String mainUseGwa5) {
		this.mainUseGwa5 = mainUseGwa5;
	}

	@Column(name = "MANAGE_NAME")
	public String getManageName() {
		return this.manageName;
	}

	public void setManageName(String manageName) {
		this.manageName = manageName;
	}

	@Column(name = "MANAGE_NO")
	public String getManageNo() {
		return this.manageNo;
	}

	public void setManageNo(String manageNo) {
		this.manageNo = manageNo;
	}

	@Column(name = "MANAGE_NO1")
	public String getManageNo1() {
		return this.manageNo1;
	}

	public void setManageNo1(String manageNo1) {
		this.manageNo1 = manageNo1;
	}

	@Column(name = "MANAGE_NO2")
	public String getManageNo2() {
		return this.manageNo2;
	}

	public void setManageNo2(String manageNo2) {
		this.manageNo2 = manageNo2;
	}

	@Column(name = "MANAGE_NO3")
	public String getManageNo3() {
		return this.manageNo3;
	}

	public void setManageNo3(String manageNo3) {
		this.manageNo3 = manageNo3;
	}

	@Column(name = "MANAGE_NO4")
	public String getManageNo4() {
		return this.manageNo4;
	}

	public void setManageNo4(String manageNo4) {
		this.manageNo4 = manageNo4;
	}

	@Column(name = "MAX_QTY_D")
	public double getMaxQtyD() {
		return this.maxQtyD;
	}

	public void setMaxQtyD(double maxQtyD) {
		this.maxQtyD = maxQtyD;
	}

	@Column(name = "MAX_QTY_M")
	public double getMaxQtyM() {
		return this.maxQtyM;
	}

	public void setMaxQtyM(double maxQtyM) {
		this.maxQtyM = maxQtyM;
	}

	@Column(name = "MAX_QTY_W")
	public double getMaxQtyW() {
		return this.maxQtyW;
	}

	public void setMaxQtyW(double maxQtyW) {
		this.maxQtyW = maxQtyW;
	}

	@Column(name = "MIN_BALJU_QTY")
	public double getMinBaljuQty() {
		return this.minBaljuQty;
	}

	public void setMinBaljuQty(double minBaljuQty) {
		this.minBaljuQty = minBaljuQty;
	}

	@Column(name = "MIN_CHUNGGU_QTY")
	public double getMinChungguQty() {
		return this.minChungguQty;
	}

	public void setMinChungguQty(double minChungguQty) {
		this.minChungguQty = minChungguQty;
	}

	@Column(name = "MIX_YN")
	public String getMixYn() {
		return this.mixYn;
	}

	public void setMixYn(String mixYn) {
		this.mixYn = mixYn;
	}

	@Column(name = "MIX_YN_INP")
	public String getMixYnInp() {
		return this.mixYnInp;
	}

	public void setMixYnInp(String mixYnInp) {
		this.mixYnInp = mixYnInp;
	}

	@Column(name = "MODEL_NAME")
	public String getModelName() {
		return this.modelName;
	}

	public void setModelName(String modelName) {
		this.modelName = modelName;
	}

	@Column(name = "OLD_MANAGE_NO")
	public String getOldManageNo() {
		return this.oldManageNo;
	}

	public void setOldManageNo(String oldManageNo) {
		this.oldManageNo = oldManageNo;
	}

	@Column(name = "ORDER_DANUI")
	public String getOrderDanui() {
		return this.orderDanui;
	}

	public void setOrderDanui(String orderDanui) {
		this.orderDanui = orderDanui;
	}

	@Column(name = "ORDER_SUBUL_DANUI")
	public String getOrderSubulDanui() {
		return this.orderSubulDanui;
	}

	public void setOrderSubulDanui(String orderSubulDanui) {
		this.orderSubulDanui = orderSubulDanui;
	}

	@Column(name = "PATH_BMP")
	public String getPathBmp() {
		return this.pathBmp;
	}

	public void setPathBmp(String pathBmp) {
		this.pathBmp = pathBmp;
	}

	@Column(name = "PRIS_NAME")
	public String getPrisName() {
		return this.prisName;
	}

	public void setPrisName(String prisName) {
		this.prisName = prisName;
	}

	@Column(name = "RACK_NO")
	public String getRackNo() {
		return this.rackNo;
	}

	public void setRackNo(String rackNo) {
		this.rackNo = rackNo;
	}

	@Column(name = "RACK_NO2")
	public String getRackNo2() {
		return this.rackNo2;
	}

	public void setRackNo2(String rackNo2) {
		this.rackNo2 = rackNo2;
	}

	@Column(name = "RE_USE_YN")
	public String getReUseYn() {
		return this.reUseYn;
	}

	public void setReUseYn(String reUseYn) {
		this.reUseYn = reUseYn;
	}

	public String getRemark() {
		return this.remark;
	}

	public void setRemark(String remark) {
		this.remark = remark;
	}

	@Column(name = "SET_CODE")
	public String getSetCode() {
		return this.setCode;
	}

	public void setSetCode(String setCode) {
		this.setCode = setCode;
	}

	@Column(name = "SKIN_TEST_YN")
	public String getSkinTestYn() {
		return this.skinTestYn;
	}

	public void setSkinTestYn(String skinTestYn) {
		this.skinTestYn = skinTestYn;
	}

	@Column(name = "SMALL_CODE")
	public String getSmallCode() {
		return this.smallCode;
	}

	public void setSmallCode(String smallCode) {
		this.smallCode = smallCode;
	}

	@Column(name = "SMALL_CODE1")
	public String getSmallCode1() {
		return this.smallCode1;
	}

	public void setSmallCode1(String smallCode1) {
		this.smallCode1 = smallCode1;
	}

	@Column(name = "SORT_KEY")
	public double getSortKey() {
		return this.sortKey;
	}

	public void setSortKey(double sortKey) {
		this.sortKey = sortKey;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "START_DATE")
	public Date getStartDate() {
		return this.startDate;
	}

	public void setStartDate(Date startDate) {
		this.startDate = startDate;
	}

	@Column(name = "STORAGE_YN")
	public String getStorageYn() {
		return this.storageYn;
	}

	public void setStorageYn(String storageYn) {
		this.storageYn = storageYn;
	}

	@Column(name = "SUBUL_BUSEO")
	public String getSubulBuseo() {
		return this.subulBuseo;
	}

	public void setSubulBuseo(String subulBuseo) {
		this.subulBuseo = subulBuseo;
	}

	@Column(name = "SUBUL_DANUI")
	public String getSubulDanui() {
		return this.subulDanui;
	}

	public void setSubulDanui(String subulDanui) {
		this.subulDanui = subulDanui;
	}

	@Column(name = "SUBUL_QCODE_ER")
	public String getSubulQcodeEr() {
		return this.subulQcodeEr;
	}

	public void setSubulQcodeEr(String subulQcodeEr) {
		this.subulQcodeEr = subulQcodeEr;
	}

	@Column(name = "SUBUL_QCODE_INP")
	public String getSubulQcodeInp() {
		return this.subulQcodeInp;
	}

	public void setSubulQcodeInp(String subulQcodeInp) {
		this.subulQcodeInp = subulQcodeInp;
	}

	@Column(name = "SUBUL_QCODE_OUT")
	public String getSubulQcodeOut() {
		return this.subulQcodeOut;
	}

	public void setSubulQcodeOut(String subulQcodeOut) {
		this.subulQcodeOut = subulQcodeOut;
	}

	@Column(name = "SUGB_JAERYO_YN")
	public String getSugbJaeryoYn() {
		return this.sugbJaeryoYn;
	}

	public void setSugbJaeryoYn(String sugbJaeryoYn) {
		this.sugbJaeryoYn = sugbJaeryoYn;
	}

	@Column(name = "SUIB_CUSTOMER")
	public String getSuibCustomer() {
		return this.suibCustomer;
	}

	public void setSuibCustomer(String suibCustomer) {
		this.suibCustomer = suibCustomer;
	}

	@Column(name = "SUIB_YN")
	public String getSuibYn() {
		return this.suibYn;
	}

	public void setSuibYn(String suibYn) {
		this.suibYn = suibYn;
	}

	@Column(name = "SUNGBUN_CODE")
	public String getSungbunCode() {
		return this.sungbunCode;
	}

	public void setSungbunCode(String sungbunCode) {
		this.sungbunCode = sungbunCode;
	}

	@Column(name = "SUNGBUN_NAME")
	public String getSungbunName() {
		return this.sungbunName;
	}

	public void setSungbunName(String sungbunName) {
		this.sungbunName = sungbunName;
	}

	@Column(name = "SUTAK_YN")
	public String getSutakYn() {
		return this.sutakYn;
	}

	public void setSutakYn(String sutakYn) {
		this.sutakYn = sutakYn;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "SYS_DATE")
	public Date getSysDate() {
		return this.sysDate;
	}

	public void setSysDate(Date sysDate) {
		this.sysDate = sysDate;
	}

	@Column(name = "SYS_ID")
	public String getSysId() {
		return this.sysId;
	}

	public void setSysId(String sysId) {
		this.sysId = sysId;
	}

	@Column(name = "TB_YN")
	public String getTbYn() {
		return this.tbYn;
	}

	public void setTbYn(String tbYn) {
		this.tbYn = tbYn;
	}

	@Column(name = "TEXT_COLOR")
	public String getTextColor() {
		return this.textColor;
	}

	public void setTextColor(String textColor) {
		this.textColor = textColor;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "TO_DANGA_DATE")
	public Date getToDangaDate() {
		return this.toDangaDate;
	}

	public void setToDangaDate(Date toDangaDate) {
		this.toDangaDate = toDangaDate;
	}

	@Column(name = "TOIJANG_YN")
	public String getToijangYn() {
		return this.toijangYn;
	}

	public void setToijangYn(String toijangYn) {
		this.toijangYn = toijangYn;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "UPD_DATE")
	public Date getUpdDate() {
		return this.updDate;
	}

	public void setUpdDate(Date updDate) {
		this.updDate = updDate;
	}

	@Column(name = "UPD_ID")
	public String getUpdId() {
		return this.updId;
	}

	public void setUpdId(String updId) {
		this.updId = updId;
	}

	@Column(name = "USE_YN")
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

	public String getYongryang() {
		return this.yongryang;
	}

	public void setYongryang(String yongryang) {
		this.yongryang = yongryang;
	}

	@Column(name = "YUHYO_MONTH")
	public double getYuhyoMonth() {
		return this.yuhyoMonth;
	}

	public void setYuhyoMonth(double yuhyoMonth) {
		this.yuhyoMonth = yuhyoMonth;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "YUHYO_TO_DATE")
	public Date getYuhyoToDate() {
		return this.yuhyoToDate;
	}

	public void setYuhyoToDate(Date yuhyoToDate) {
		this.yuhyoToDate = yuhyoToDate;
	}

	@Column(name = "YUHYO_YN")
	public String getYuhyoYn() {
		return this.yuhyoYn;
	}

	public void setYuhyoYn(String yuhyoYn) {
		this.yuhyoYn = yuhyoYn;
	}

	@Column(name = "YUNHAP_CODE")
	public String getYunhapCode() {
		return this.yunhapCode;
	}

	public void setYunhapCode(String yunhapCode) {
		this.yunhapCode = yunhapCode;
	}

	@Column(name = "YUNHAP_JOIN_YN")
	public String getYunhapJoinYn() {
		return this.yunhapJoinYn;
	}

	public void setYunhapJoinYn(String yunhapJoinYn) {
		this.yunhapJoinYn = yunhapJoinYn;
	}

	@Column(name = "MODIFY_FLG")
	public String getModifyFlg() {
		return modifyFlg;
	}

	public void setModifyFlg(String modifyFlg) {
		this.modifyFlg = modifyFlg;
	}

	@Column(name = "STOCK_YN")
	public String getStockYn() {
		return stockYn;
	}

	public void setStockYn(String stockYn) {
		this.stockYn = stockYn;
	}

	@Column(name = "SUBUL_DANGA")
	public Double getSubulDanga() {
		return subulDanga;
	}

	public void setSubulDanga(Double subulDanga) {
		this.subulDanga = subulDanga;
	}
	
	
}