package nta.med.core.domain.ifs;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the IFS7101 database table.
 * 
 */
@Entity
@Table(name="IFS7101")
public class Ifs7101 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String baebunFlag;
	private String bogyongStartDate;
	private String dataGubun;
	private String doctor;
	private String doctorName;
	private String drgInfoPrtYn;
	private String drgMybookPrtYn;
	private String drgOrdGubun;
	private String endFlag;
	private double fkdrg4010;
	private String gwa;
	private String gwaName;
	private String hoCode;
	private String hoCodeName;
	private String hoDong;
	private String hoDongName;
	private String hospCode;
	private Date ifDate;
	private String ifErr;
	private String ifFlag;
	private String ifTime;
	private String ioGubun;
	private String ipToiwonGubun;
	private String jojeDate;
	private String jubsuBunho;
	private String ordActYn;
	private String ordCmtCnt;
	private String ordNo;
	private String ordNoSrc;
	private String ordResultCode;
	private double pkifs7101;
	private String printGubun;
	private String printerGubun;
	private String recGubun;
	private String remark;
	private String rpCnt;
	private String sendDate;
	private String sendTime;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Ifs7101() {
	}


	@Column(name="BAEBUN_FLAG")
	public String getBaebunFlag() {
		return this.baebunFlag;
	}

	public void setBaebunFlag(String baebunFlag) {
		this.baebunFlag = baebunFlag;
	}


	@Column(name="BOGYONG_START_DATE")
	public String getBogyongStartDate() {
		return this.bogyongStartDate;
	}

	public void setBogyongStartDate(String bogyongStartDate) {
		this.bogyongStartDate = bogyongStartDate;
	}


	@Column(name="DATA_GUBUN")
	public String getDataGubun() {
		return this.dataGubun;
	}

	public void setDataGubun(String dataGubun) {
		this.dataGubun = dataGubun;
	}


	public String getDoctor() {
		return this.doctor;
	}

	public void setDoctor(String doctor) {
		this.doctor = doctor;
	}


	@Column(name="DOCTOR_NAME")
	public String getDoctorName() {
		return this.doctorName;
	}

	public void setDoctorName(String doctorName) {
		this.doctorName = doctorName;
	}


	@Column(name="DRG_INFO_PRT_YN")
	public String getDrgInfoPrtYn() {
		return this.drgInfoPrtYn;
	}

	public void setDrgInfoPrtYn(String drgInfoPrtYn) {
		this.drgInfoPrtYn = drgInfoPrtYn;
	}


	@Column(name="DRG_MYBOOK_PRT_YN")
	public String getDrgMybookPrtYn() {
		return this.drgMybookPrtYn;
	}

	public void setDrgMybookPrtYn(String drgMybookPrtYn) {
		this.drgMybookPrtYn = drgMybookPrtYn;
	}


	@Column(name="DRG_ORD_GUBUN")
	public String getDrgOrdGubun() {
		return this.drgOrdGubun;
	}

	public void setDrgOrdGubun(String drgOrdGubun) {
		this.drgOrdGubun = drgOrdGubun;
	}


	@Column(name="END_FLAG")
	public String getEndFlag() {
		return this.endFlag;
	}

	public void setEndFlag(String endFlag) {
		this.endFlag = endFlag;
	}


	public double getFkdrg4010() {
		return this.fkdrg4010;
	}

	public void setFkdrg4010(double fkdrg4010) {
		this.fkdrg4010 = fkdrg4010;
	}


	public String getGwa() {
		return this.gwa;
	}

	public void setGwa(String gwa) {
		this.gwa = gwa;
	}


	@Column(name="GWA_NAME")
	public String getGwaName() {
		return this.gwaName;
	}

	public void setGwaName(String gwaName) {
		this.gwaName = gwaName;
	}


	@Column(name="HO_CODE")
	public String getHoCode() {
		return this.hoCode;
	}

	public void setHoCode(String hoCode) {
		this.hoCode = hoCode;
	}


	@Column(name="HO_CODE_NAME")
	public String getHoCodeName() {
		return this.hoCodeName;
	}

	public void setHoCodeName(String hoCodeName) {
		this.hoCodeName = hoCodeName;
	}


	@Column(name="HO_DONG")
	public String getHoDong() {
		return this.hoDong;
	}

	public void setHoDong(String hoDong) {
		this.hoDong = hoDong;
	}


	@Column(name="HO_DONG_NAME")
	public String getHoDongName() {
		return this.hoDongName;
	}

	public void setHoDongName(String hoDongName) {
		this.hoDongName = hoDongName;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
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


	@Column(name="IF_TIME")
	public String getIfTime() {
		return this.ifTime;
	}

	public void setIfTime(String ifTime) {
		this.ifTime = ifTime;
	}


	@Column(name="IO_GUBUN")
	public String getIoGubun() {
		return this.ioGubun;
	}

	public void setIoGubun(String ioGubun) {
		this.ioGubun = ioGubun;
	}


	@Column(name="IP_TOIWON_GUBUN")
	public String getIpToiwonGubun() {
		return this.ipToiwonGubun;
	}

	public void setIpToiwonGubun(String ipToiwonGubun) {
		this.ipToiwonGubun = ipToiwonGubun;
	}


	@Column(name="JOJE_DATE")
	public String getJojeDate() {
		return this.jojeDate;
	}

	public void setJojeDate(String jojeDate) {
		this.jojeDate = jojeDate;
	}


	@Column(name="JUBSU_BUNHO")
	public String getJubsuBunho() {
		return this.jubsuBunho;
	}

	public void setJubsuBunho(String jubsuBunho) {
		this.jubsuBunho = jubsuBunho;
	}


	@Column(name="ORD_ACT_YN")
	public String getOrdActYn() {
		return this.ordActYn;
	}

	public void setOrdActYn(String ordActYn) {
		this.ordActYn = ordActYn;
	}


	@Column(name="ORD_CMT_CNT")
	public String getOrdCmtCnt() {
		return this.ordCmtCnt;
	}

	public void setOrdCmtCnt(String ordCmtCnt) {
		this.ordCmtCnt = ordCmtCnt;
	}


	@Column(name="ORD_NO")
	public String getOrdNo() {
		return this.ordNo;
	}

	public void setOrdNo(String ordNo) {
		this.ordNo = ordNo;
	}


	@Column(name="ORD_NO_SRC")
	public String getOrdNoSrc() {
		return this.ordNoSrc;
	}

	public void setOrdNoSrc(String ordNoSrc) {
		this.ordNoSrc = ordNoSrc;
	}


	@Column(name="ORD_RESULT_CODE")
	public String getOrdResultCode() {
		return this.ordResultCode;
	}

	public void setOrdResultCode(String ordResultCode) {
		this.ordResultCode = ordResultCode;
	}


	public double getPkifs7101() {
		return this.pkifs7101;
	}

	public void setPkifs7101(double pkifs7101) {
		this.pkifs7101 = pkifs7101;
	}


	@Column(name="PRINT_GUBUN")
	public String getPrintGubun() {
		return this.printGubun;
	}

	public void setPrintGubun(String printGubun) {
		this.printGubun = printGubun;
	}


	@Column(name="PRINTER_GUBUN")
	public String getPrinterGubun() {
		return this.printerGubun;
	}

	public void setPrinterGubun(String printerGubun) {
		this.printerGubun = printerGubun;
	}


	@Column(name="REC_GUBUN")
	public String getRecGubun() {
		return this.recGubun;
	}

	public void setRecGubun(String recGubun) {
		this.recGubun = recGubun;
	}


	public String getRemark() {
		return this.remark;
	}

	public void setRemark(String remark) {
		this.remark = remark;
	}


	@Column(name="RP_CNT")
	public String getRpCnt() {
		return this.rpCnt;
	}

	public void setRpCnt(String rpCnt) {
		this.rpCnt = rpCnt;
	}


	@Column(name="SEND_DATE")
	public String getSendDate() {
		return this.sendDate;
	}

	public void setSendDate(String sendDate) {
		this.sendDate = sendDate;
	}


	@Column(name="SEND_TIME")
	public String getSendTime() {
		return this.sendTime;
	}

	public void setSendTime(String sendTime) {
		this.sendTime = sendTime;
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

}