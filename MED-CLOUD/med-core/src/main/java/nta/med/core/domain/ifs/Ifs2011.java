package nta.med.core.domain.ifs;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the IFS2011 database table.
 * 
 */
@Entity
@NamedQuery(name="Ifs2011.findAll", query="SELECT i FROM Ifs2011 i")
public class Ifs2011 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String actingDate;
	private String actingGubun;
	private String actingStatus;
	private String buhagumsaCnt;
	private String bunho;
	private String buseoCode;
	private String buwiCode;
	private String changuFlag;
	private String chungguGubun;
	private String commentFlag;
	private String commentText;
	private String danui;
	private String dataGubun;
	private String dataKey;
	private String dataSeq;
	private String directionCnt;
	private String disCode;
	private String divideCnt;
	private String doctor;
	private String drgBunho;
	private String endGubun;
	private double fkifs1004;
	private double fkocs1003;
	private double fkout1003;
	private String gasanGubun1;
	private String gasanGubun10;
	private String gasanGubun2;
	private String gasanGubun3;
	private String gasanGubun4;
	private String gasanGubun5;
	private String gasanGubun6;
	private String gasanGubun7;
	private String gasanGubun8;
	private String gasanGubun9;
	private String gubunInfo;
	private String gubunInfo2;
	private String gwa;
	private String hangmogCode;
	private String hoDong;
	private String hospCode;
	private String houseOrderNalsu;
	private Date ifDate;
	private String ifErr;
	private String ifFlag;
	private String ifHospCode;
	private String ifTime;
	private String imsiYn;
	private String inOutGubun;
	private String jangheajaGubun;
	private String jinryoGubun;
	private String junsinMacheeGubun;
	private String jusaFlag;
	private String jusaMethod;
	private String measu;
	private String nalsu;
	private String orderDate;
	private String orderGroupNo;
	private String orderGubun;
	private String orderNo;
	private String orderNoSub;
	private double pkifs2011;
	private String powderGubun;
	private String procGubun;
	private String qty;
	private String sanjungForceYn;
	private String sanjungGubun;
	private double seq;
	private String sgIfCode;
	private String specimenCode;
	private String susulFlag;
	private String susulTime;
	private Date sysDate;
	private String sysId;
	private String taxGubun;
	private String timeGubun;
	private Date updDate;
	private String updId;
	private String weight;

	public Ifs2011() {
	}


	@Column(name="ACTING_DATE")
	public String getActingDate() {
		return this.actingDate;
	}

	public void setActingDate(String actingDate) {
		this.actingDate = actingDate;
	}


	@Column(name="ACTING_GUBUN")
	public String getActingGubun() {
		return this.actingGubun;
	}

	public void setActingGubun(String actingGubun) {
		this.actingGubun = actingGubun;
	}


	@Column(name="ACTING_STATUS")
	public String getActingStatus() {
		return this.actingStatus;
	}

	public void setActingStatus(String actingStatus) {
		this.actingStatus = actingStatus;
	}


	@Column(name="BUHAGUMSA_CNT")
	public String getBuhagumsaCnt() {
		return this.buhagumsaCnt;
	}

	public void setBuhagumsaCnt(String buhagumsaCnt) {
		this.buhagumsaCnt = buhagumsaCnt;
	}


	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}


	@Column(name="BUSEO_CODE")
	public String getBuseoCode() {
		return this.buseoCode;
	}

	public void setBuseoCode(String buseoCode) {
		this.buseoCode = buseoCode;
	}


	@Column(name="BUWI_CODE")
	public String getBuwiCode() {
		return this.buwiCode;
	}

	public void setBuwiCode(String buwiCode) {
		this.buwiCode = buwiCode;
	}


	@Column(name="CHANGU_FLAG")
	public String getChanguFlag() {
		return this.changuFlag;
	}

	public void setChanguFlag(String changuFlag) {
		this.changuFlag = changuFlag;
	}


	@Column(name="CHUNGGU_GUBUN")
	public String getChungguGubun() {
		return this.chungguGubun;
	}

	public void setChungguGubun(String chungguGubun) {
		this.chungguGubun = chungguGubun;
	}


	@Column(name="COMMENT_FLAG")
	public String getCommentFlag() {
		return this.commentFlag;
	}

	public void setCommentFlag(String commentFlag) {
		this.commentFlag = commentFlag;
	}


	@Column(name="COMMENT_TEXT")
	public String getCommentText() {
		return this.commentText;
	}

	public void setCommentText(String commentText) {
		this.commentText = commentText;
	}


	public String getDanui() {
		return this.danui;
	}

	public void setDanui(String danui) {
		this.danui = danui;
	}


	@Column(name="DATA_GUBUN")
	public String getDataGubun() {
		return this.dataGubun;
	}

	public void setDataGubun(String dataGubun) {
		this.dataGubun = dataGubun;
	}


	@Column(name="DATA_KEY")
	public String getDataKey() {
		return this.dataKey;
	}

	public void setDataKey(String dataKey) {
		this.dataKey = dataKey;
	}


	@Column(name="DATA_SEQ")
	public String getDataSeq() {
		return this.dataSeq;
	}

	public void setDataSeq(String dataSeq) {
		this.dataSeq = dataSeq;
	}


	@Column(name="DIRECTION_CNT")
	public String getDirectionCnt() {
		return this.directionCnt;
	}

	public void setDirectionCnt(String directionCnt) {
		this.directionCnt = directionCnt;
	}


	@Column(name="DIS_CODE")
	public String getDisCode() {
		return this.disCode;
	}

	public void setDisCode(String disCode) {
		this.disCode = disCode;
	}


	@Column(name="DIVIDE_CNT")
	public String getDivideCnt() {
		return this.divideCnt;
	}

	public void setDivideCnt(String divideCnt) {
		this.divideCnt = divideCnt;
	}


	public String getDoctor() {
		return this.doctor;
	}

	public void setDoctor(String doctor) {
		this.doctor = doctor;
	}


	@Column(name="DRG_BUNHO")
	public String getDrgBunho() {
		return this.drgBunho;
	}

	public void setDrgBunho(String drgBunho) {
		this.drgBunho = drgBunho;
	}


	@Column(name="END_GUBUN")
	public String getEndGubun() {
		return this.endGubun;
	}

	public void setEndGubun(String endGubun) {
		this.endGubun = endGubun;
	}


	public double getFkifs1004() {
		return this.fkifs1004;
	}

	public void setFkifs1004(double fkifs1004) {
		this.fkifs1004 = fkifs1004;
	}


	public double getFkocs1003() {
		return this.fkocs1003;
	}

	public void setFkocs1003(double fkocs1003) {
		this.fkocs1003 = fkocs1003;
	}


	public double getFkout1003() {
		return this.fkout1003;
	}

	public void setFkout1003(double fkout1003) {
		this.fkout1003 = fkout1003;
	}


	@Column(name="GASAN_GUBUN1")
	public String getGasanGubun1() {
		return this.gasanGubun1;
	}

	public void setGasanGubun1(String gasanGubun1) {
		this.gasanGubun1 = gasanGubun1;
	}


	@Column(name="GASAN_GUBUN10")
	public String getGasanGubun10() {
		return this.gasanGubun10;
	}

	public void setGasanGubun10(String gasanGubun10) {
		this.gasanGubun10 = gasanGubun10;
	}


	@Column(name="GASAN_GUBUN2")
	public String getGasanGubun2() {
		return this.gasanGubun2;
	}

	public void setGasanGubun2(String gasanGubun2) {
		this.gasanGubun2 = gasanGubun2;
	}


	@Column(name="GASAN_GUBUN3")
	public String getGasanGubun3() {
		return this.gasanGubun3;
	}

	public void setGasanGubun3(String gasanGubun3) {
		this.gasanGubun3 = gasanGubun3;
	}


	@Column(name="GASAN_GUBUN4")
	public String getGasanGubun4() {
		return this.gasanGubun4;
	}

	public void setGasanGubun4(String gasanGubun4) {
		this.gasanGubun4 = gasanGubun4;
	}


	@Column(name="GASAN_GUBUN5")
	public String getGasanGubun5() {
		return this.gasanGubun5;
	}

	public void setGasanGubun5(String gasanGubun5) {
		this.gasanGubun5 = gasanGubun5;
	}


	@Column(name="GASAN_GUBUN6")
	public String getGasanGubun6() {
		return this.gasanGubun6;
	}

	public void setGasanGubun6(String gasanGubun6) {
		this.gasanGubun6 = gasanGubun6;
	}


	@Column(name="GASAN_GUBUN7")
	public String getGasanGubun7() {
		return this.gasanGubun7;
	}

	public void setGasanGubun7(String gasanGubun7) {
		this.gasanGubun7 = gasanGubun7;
	}


	@Column(name="GASAN_GUBUN8")
	public String getGasanGubun8() {
		return this.gasanGubun8;
	}

	public void setGasanGubun8(String gasanGubun8) {
		this.gasanGubun8 = gasanGubun8;
	}


	@Column(name="GASAN_GUBUN9")
	public String getGasanGubun9() {
		return this.gasanGubun9;
	}

	public void setGasanGubun9(String gasanGubun9) {
		this.gasanGubun9 = gasanGubun9;
	}


	@Column(name="GUBUN_INFO")
	public String getGubunInfo() {
		return this.gubunInfo;
	}

	public void setGubunInfo(String gubunInfo) {
		this.gubunInfo = gubunInfo;
	}


	@Column(name="GUBUN_INFO2")
	public String getGubunInfo2() {
		return this.gubunInfo2;
	}

	public void setGubunInfo2(String gubunInfo2) {
		this.gubunInfo2 = gubunInfo2;
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


	@Column(name="HOUSE_ORDER_NALSU")
	public String getHouseOrderNalsu() {
		return this.houseOrderNalsu;
	}

	public void setHouseOrderNalsu(String houseOrderNalsu) {
		this.houseOrderNalsu = houseOrderNalsu;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="IF_DATE")
	public Date getIfDate() {
		return this.ifDate;
	}

	public void setIfDate(Date ifDate) {
		this.ifDate = ifDate;
	}


	@Column(name="IF_ERR")
	public String getIfErr() {
		return this.ifErr;
	}

	public void setIfErr(String ifErr) {
		this.ifErr = ifErr;
	}


	@Column(name="IF_FLAG")
	public String getIfFlag() {
		return this.ifFlag;
	}

	public void setIfFlag(String ifFlag) {
		this.ifFlag = ifFlag;
	}


	@Column(name="IF_HOSP_CODE")
	public String getIfHospCode() {
		return this.ifHospCode;
	}

	public void setIfHospCode(String ifHospCode) {
		this.ifHospCode = ifHospCode;
	}


	@Column(name="IF_TIME")
	public String getIfTime() {
		return this.ifTime;
	}

	public void setIfTime(String ifTime) {
		this.ifTime = ifTime;
	}


	@Column(name="IMSI_YN")
	public String getImsiYn() {
		return this.imsiYn;
	}

	public void setImsiYn(String imsiYn) {
		this.imsiYn = imsiYn;
	}


	@Column(name="IN_OUT_GUBUN")
	public String getInOutGubun() {
		return this.inOutGubun;
	}

	public void setInOutGubun(String inOutGubun) {
		this.inOutGubun = inOutGubun;
	}


	@Column(name="JANGHEAJA_GUBUN")
	public String getJangheajaGubun() {
		return this.jangheajaGubun;
	}

	public void setJangheajaGubun(String jangheajaGubun) {
		this.jangheajaGubun = jangheajaGubun;
	}


	@Column(name="JINRYO_GUBUN")
	public String getJinryoGubun() {
		return this.jinryoGubun;
	}

	public void setJinryoGubun(String jinryoGubun) {
		this.jinryoGubun = jinryoGubun;
	}


	@Column(name="JUNSIN_MACHEE_GUBUN")
	public String getJunsinMacheeGubun() {
		return this.junsinMacheeGubun;
	}

	public void setJunsinMacheeGubun(String junsinMacheeGubun) {
		this.junsinMacheeGubun = junsinMacheeGubun;
	}


	@Column(name="JUSA_FLAG")
	public String getJusaFlag() {
		return this.jusaFlag;
	}

	public void setJusaFlag(String jusaFlag) {
		this.jusaFlag = jusaFlag;
	}


	@Column(name="JUSA_METHOD")
	public String getJusaMethod() {
		return this.jusaMethod;
	}

	public void setJusaMethod(String jusaMethod) {
		this.jusaMethod = jusaMethod;
	}


	public String getMeasu() {
		return this.measu;
	}

	public void setMeasu(String measu) {
		this.measu = measu;
	}


	public String getNalsu() {
		return this.nalsu;
	}

	public void setNalsu(String nalsu) {
		this.nalsu = nalsu;
	}


	@Column(name="ORDER_DATE")
	public String getOrderDate() {
		return this.orderDate;
	}

	public void setOrderDate(String orderDate) {
		this.orderDate = orderDate;
	}


	@Column(name="ORDER_GROUP_NO")
	public String getOrderGroupNo() {
		return this.orderGroupNo;
	}

	public void setOrderGroupNo(String orderGroupNo) {
		this.orderGroupNo = orderGroupNo;
	}


	@Column(name="ORDER_GUBUN")
	public String getOrderGubun() {
		return this.orderGubun;
	}

	public void setOrderGubun(String orderGubun) {
		this.orderGubun = orderGubun;
	}


	@Column(name="ORDER_NO")
	public String getOrderNo() {
		return this.orderNo;
	}

	public void setOrderNo(String orderNo) {
		this.orderNo = orderNo;
	}


	@Column(name="ORDER_NO_SUB")
	public String getOrderNoSub() {
		return this.orderNoSub;
	}

	public void setOrderNoSub(String orderNoSub) {
		this.orderNoSub = orderNoSub;
	}


	public double getPkifs2011() {
		return this.pkifs2011;
	}

	public void setPkifs2011(double pkifs2011) {
		this.pkifs2011 = pkifs2011;
	}


	@Column(name="POWDER_GUBUN")
	public String getPowderGubun() {
		return this.powderGubun;
	}

	public void setPowderGubun(String powderGubun) {
		this.powderGubun = powderGubun;
	}


	@Column(name="PROC_GUBUN")
	public String getProcGubun() {
		return this.procGubun;
	}

	public void setProcGubun(String procGubun) {
		this.procGubun = procGubun;
	}


	public String getQty() {
		return this.qty;
	}

	public void setQty(String qty) {
		this.qty = qty;
	}


	@Column(name="SANJUNG_FORCE_YN")
	public String getSanjungForceYn() {
		return this.sanjungForceYn;
	}

	public void setSanjungForceYn(String sanjungForceYn) {
		this.sanjungForceYn = sanjungForceYn;
	}


	@Column(name="SANJUNG_GUBUN")
	public String getSanjungGubun() {
		return this.sanjungGubun;
	}

	public void setSanjungGubun(String sanjungGubun) {
		this.sanjungGubun = sanjungGubun;
	}


	public double getSeq() {
		return this.seq;
	}

	public void setSeq(double seq) {
		this.seq = seq;
	}


	@Column(name="SG_IF_CODE")
	public String getSgIfCode() {
		return this.sgIfCode;
	}

	public void setSgIfCode(String sgIfCode) {
		this.sgIfCode = sgIfCode;
	}


	@Column(name="SPECIMEN_CODE")
	public String getSpecimenCode() {
		return this.specimenCode;
	}

	public void setSpecimenCode(String specimenCode) {
		this.specimenCode = specimenCode;
	}


	@Column(name="SUSUL_FLAG")
	public String getSusulFlag() {
		return this.susulFlag;
	}

	public void setSusulFlag(String susulFlag) {
		this.susulFlag = susulFlag;
	}


	@Column(name="SUSUL_TIME")
	public String getSusulTime() {
		return this.susulTime;
	}

	public void setSusulTime(String susulTime) {
		this.susulTime = susulTime;
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


	@Column(name="TAX_GUBUN")
	public String getTaxGubun() {
		return this.taxGubun;
	}

	public void setTaxGubun(String taxGubun) {
		this.taxGubun = taxGubun;
	}


	@Column(name="TIME_GUBUN")
	public String getTimeGubun() {
		return this.timeGubun;
	}

	public void setTimeGubun(String timeGubun) {
		this.timeGubun = timeGubun;
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


	public String getWeight() {
		return this.weight;
	}

	public void setWeight(String weight) {
		this.weight = weight;
	}

}