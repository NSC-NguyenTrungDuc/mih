package nta.med.core.domain.xrt;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the XRT0201 database table.
 * 
 */
@Entity
@NamedQuery(name="Xrt0201.findAll", query="SELECT x FROM Xrt0201 x")
@Table(name="XRT0201")
public class Xrt0201 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String actDoctor;
	private String afterActYn;
	private String bunGwa;
	private String bunho;
	private Date cancelDate;
	private String cancelTime;
	private String cancelYn;
	private String dangilGumsaOrderYn;
	private String dangilGumsaResultYn;
	private String danilGumsaOrderYn;
	private String dcYn;
	private String doctor;
	private String emergency;
	private String filmReserYn;
	private double fkocs1003;
	private double fkocs2003;
	private double fluoroscopy;
	private String gwa;
	private String hoCode;
	private String hoDong;
	private Date hopeDate;
	private String hopeTime;
	private String hospCode;
	private String inOutGubun;
	private String inputUser;
	private Date jubsuDate;
	private String jubsuFlag;
	private double jubsuNo;
	private String jubsuTime;
	private String juminGumjin;
	private String jundalPart;
	private String muhyo;
	private Date orderDate;
	private String pacsGubun;
	private String pandokCheck;
	private Date pandokDate;
	private String pandokDoctor1;
	private String pandokDoctor2;
	private double pandokSerial;
	private String pandokStatus;
	private double pkxrt0201;
	private String portableYn;
	private String portableYn2;
	private String printYn;
	private String reXrayCode;
	private Date reXrayDate;
	private String reXrayTime;
	private String reXrayYn;
	private String reserPrintYn;
	private String reserYn;
	private String resident;
	private String riDanui;
	private String riJusabuwi;
	private String riKind;
	private double riSuryang;
	private String sgCode;
	private String slipCode;
	private String specialGwa;
	private double specialRate;
	private String specialYn;
	private double spotFkocs1;
	private double spotFkocs2;
	private String statusYn;
	private Date sunabDate;
	private double sunabSuryang;
	private double suryang;
	private String sutakYn;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;
	private String xrayCode;
	private Date xrayDate;
	private String xrayGubun;
	private Date xrayReserDate;
	private String xrayReserTime;
	private String xrayRoom;
	private String xrayTime;
	private String xrayUser;
	private String xrtComments;

	public Xrt0201() {
	}


	@Column(name="ACT_DOCTOR")
	public String getActDoctor() {
		return this.actDoctor;
	}

	public void setActDoctor(String actDoctor) {
		this.actDoctor = actDoctor;
	}


	@Column(name="AFTER_ACT_YN")
	public String getAfterActYn() {
		return this.afterActYn;
	}

	public void setAfterActYn(String afterActYn) {
		this.afterActYn = afterActYn;
	}


	@Column(name="BUN_GWA")
	public String getBunGwa() {
		return this.bunGwa;
	}

	public void setBunGwa(String bunGwa) {
		this.bunGwa = bunGwa;
	}


	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="CANCEL_DATE")
	public Date getCancelDate() {
		return this.cancelDate;
	}

	public void setCancelDate(Date cancelDate) {
		this.cancelDate = cancelDate;
	}


	@Column(name="CANCEL_TIME")
	public String getCancelTime() {
		return this.cancelTime;
	}

	public void setCancelTime(String cancelTime) {
		this.cancelTime = cancelTime;
	}


	@Column(name="CANCEL_YN")
	public String getCancelYn() {
		return this.cancelYn;
	}

	public void setCancelYn(String cancelYn) {
		this.cancelYn = cancelYn;
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


	@Column(name="DANIL_GUMSA_ORDER_YN")
	public String getDanilGumsaOrderYn() {
		return this.danilGumsaOrderYn;
	}

	public void setDanilGumsaOrderYn(String danilGumsaOrderYn) {
		this.danilGumsaOrderYn = danilGumsaOrderYn;
	}


	@Column(name="DC_YN")
	public String getDcYn() {
		return this.dcYn;
	}

	public void setDcYn(String dcYn) {
		this.dcYn = dcYn;
	}


	public String getDoctor() {
		return this.doctor;
	}

	public void setDoctor(String doctor) {
		this.doctor = doctor;
	}


	public String getEmergency() {
		return this.emergency;
	}

	public void setEmergency(String emergency) {
		this.emergency = emergency;
	}


	@Column(name="FILM_RESER_YN")
	public String getFilmReserYn() {
		return this.filmReserYn;
	}

	public void setFilmReserYn(String filmReserYn) {
		this.filmReserYn = filmReserYn;
	}


	public double getFkocs1003() {
		return this.fkocs1003;
	}

	public void setFkocs1003(double fkocs1003) {
		this.fkocs1003 = fkocs1003;
	}


	public double getFkocs2003() {
		return this.fkocs2003;
	}

	public void setFkocs2003(double fkocs2003) {
		this.fkocs2003 = fkocs2003;
	}


	public double getFluoroscopy() {
		return this.fluoroscopy;
	}

	public void setFluoroscopy(double fluoroscopy) {
		this.fluoroscopy = fluoroscopy;
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


	@Column(name="IN_OUT_GUBUN")
	public String getInOutGubun() {
		return this.inOutGubun;
	}

	public void setInOutGubun(String inOutGubun) {
		this.inOutGubun = inOutGubun;
	}


	@Column(name="INPUT_USER")
	public String getInputUser() {
		return this.inputUser;
	}

	public void setInputUser(String inputUser) {
		this.inputUser = inputUser;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="JUBSU_DATE")
	public Date getJubsuDate() {
		return this.jubsuDate;
	}

	public void setJubsuDate(Date jubsuDate) {
		this.jubsuDate = jubsuDate;
	}


	@Column(name="JUBSU_FLAG")
	public String getJubsuFlag() {
		return this.jubsuFlag;
	}

	public void setJubsuFlag(String jubsuFlag) {
		this.jubsuFlag = jubsuFlag;
	}


	@Column(name="JUBSU_NO")
	public double getJubsuNo() {
		return this.jubsuNo;
	}

	public void setJubsuNo(double jubsuNo) {
		this.jubsuNo = jubsuNo;
	}


	@Column(name="JUBSU_TIME")
	public String getJubsuTime() {
		return this.jubsuTime;
	}

	public void setJubsuTime(String jubsuTime) {
		this.jubsuTime = jubsuTime;
	}


	@Column(name="JUMIN_GUMJIN")
	public String getJuminGumjin() {
		return this.juminGumjin;
	}

	public void setJuminGumjin(String juminGumjin) {
		this.juminGumjin = juminGumjin;
	}


	@Column(name="JUNDAL_PART")
	public String getJundalPart() {
		return this.jundalPart;
	}

	public void setJundalPart(String jundalPart) {
		this.jundalPart = jundalPart;
	}


	public String getMuhyo() {
		return this.muhyo;
	}

	public void setMuhyo(String muhyo) {
		this.muhyo = muhyo;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="ORDER_DATE")
	public Date getOrderDate() {
		return this.orderDate;
	}

	public void setOrderDate(Date orderDate) {
		this.orderDate = orderDate;
	}


	@Column(name="PACS_GUBUN")
	public String getPacsGubun() {
		return this.pacsGubun;
	}

	public void setPacsGubun(String pacsGubun) {
		this.pacsGubun = pacsGubun;
	}


	@Column(name="PANDOK_CHECK")
	public String getPandokCheck() {
		return this.pandokCheck;
	}

	public void setPandokCheck(String pandokCheck) {
		this.pandokCheck = pandokCheck;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="PANDOK_DATE")
	public Date getPandokDate() {
		return this.pandokDate;
	}

	public void setPandokDate(Date pandokDate) {
		this.pandokDate = pandokDate;
	}


	@Column(name="PANDOK_DOCTOR1")
	public String getPandokDoctor1() {
		return this.pandokDoctor1;
	}

	public void setPandokDoctor1(String pandokDoctor1) {
		this.pandokDoctor1 = pandokDoctor1;
	}


	@Column(name="PANDOK_DOCTOR2")
	public String getPandokDoctor2() {
		return this.pandokDoctor2;
	}

	public void setPandokDoctor2(String pandokDoctor2) {
		this.pandokDoctor2 = pandokDoctor2;
	}


	@Column(name="PANDOK_SERIAL")
	public double getPandokSerial() {
		return this.pandokSerial;
	}

	public void setPandokSerial(double pandokSerial) {
		this.pandokSerial = pandokSerial;
	}


	@Column(name="PANDOK_STATUS")
	public String getPandokStatus() {
		return this.pandokStatus;
	}

	public void setPandokStatus(String pandokStatus) {
		this.pandokStatus = pandokStatus;
	}


	public double getPkxrt0201() {
		return this.pkxrt0201;
	}

	public void setPkxrt0201(double pkxrt0201) {
		this.pkxrt0201 = pkxrt0201;
	}


	@Column(name="PORTABLE_YN")
	public String getPortableYn() {
		return this.portableYn;
	}

	public void setPortableYn(String portableYn) {
		this.portableYn = portableYn;
	}


	@Column(name="PORTABLE_YN2")
	public String getPortableYn2() {
		return this.portableYn2;
	}

	public void setPortableYn2(String portableYn2) {
		this.portableYn2 = portableYn2;
	}


	@Column(name="PRINT_YN")
	public String getPrintYn() {
		return this.printYn;
	}

	public void setPrintYn(String printYn) {
		this.printYn = printYn;
	}


	@Column(name="RE_XRAY_CODE")
	public String getReXrayCode() {
		return this.reXrayCode;
	}

	public void setReXrayCode(String reXrayCode) {
		this.reXrayCode = reXrayCode;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="RE_XRAY_DATE")
	public Date getReXrayDate() {
		return this.reXrayDate;
	}

	public void setReXrayDate(Date reXrayDate) {
		this.reXrayDate = reXrayDate;
	}


	@Column(name="RE_XRAY_TIME")
	public String getReXrayTime() {
		return this.reXrayTime;
	}

	public void setReXrayTime(String reXrayTime) {
		this.reXrayTime = reXrayTime;
	}


	@Column(name="RE_XRAY_YN")
	public String getReXrayYn() {
		return this.reXrayYn;
	}

	public void setReXrayYn(String reXrayYn) {
		this.reXrayYn = reXrayYn;
	}


	@Column(name="RESER_PRINT_YN")
	public String getReserPrintYn() {
		return this.reserPrintYn;
	}

	public void setReserPrintYn(String reserPrintYn) {
		this.reserPrintYn = reserPrintYn;
	}


	@Column(name="RESER_YN")
	public String getReserYn() {
		return this.reserYn;
	}

	public void setReserYn(String reserYn) {
		this.reserYn = reserYn;
	}


	public String getResident() {
		return this.resident;
	}

	public void setResident(String resident) {
		this.resident = resident;
	}


	@Column(name="RI_DANUI")
	public String getRiDanui() {
		return this.riDanui;
	}

	public void setRiDanui(String riDanui) {
		this.riDanui = riDanui;
	}


	@Column(name="RI_JUSABUWI")
	public String getRiJusabuwi() {
		return this.riJusabuwi;
	}

	public void setRiJusabuwi(String riJusabuwi) {
		this.riJusabuwi = riJusabuwi;
	}


	@Column(name="RI_KIND")
	public String getRiKind() {
		return this.riKind;
	}

	public void setRiKind(String riKind) {
		this.riKind = riKind;
	}


	@Column(name="RI_SURYANG")
	public double getRiSuryang() {
		return this.riSuryang;
	}

	public void setRiSuryang(double riSuryang) {
		this.riSuryang = riSuryang;
	}


	@Column(name="SG_CODE")
	public String getSgCode() {
		return this.sgCode;
	}

	public void setSgCode(String sgCode) {
		this.sgCode = sgCode;
	}


	@Column(name="SLIP_CODE")
	public String getSlipCode() {
		return this.slipCode;
	}

	public void setSlipCode(String slipCode) {
		this.slipCode = slipCode;
	}


	@Column(name="SPECIAL_GWA")
	public String getSpecialGwa() {
		return this.specialGwa;
	}

	public void setSpecialGwa(String specialGwa) {
		this.specialGwa = specialGwa;
	}


	@Column(name="SPECIAL_RATE")
	public double getSpecialRate() {
		return this.specialRate;
	}

	public void setSpecialRate(double specialRate) {
		this.specialRate = specialRate;
	}


	@Column(name="SPECIAL_YN")
	public String getSpecialYn() {
		return this.specialYn;
	}

	public void setSpecialYn(String specialYn) {
		this.specialYn = specialYn;
	}


	@Column(name="SPOT_FKOCS1")
	public double getSpotFkocs1() {
		return this.spotFkocs1;
	}

	public void setSpotFkocs1(double spotFkocs1) {
		this.spotFkocs1 = spotFkocs1;
	}


	@Column(name="SPOT_FKOCS2")
	public double getSpotFkocs2() {
		return this.spotFkocs2;
	}

	public void setSpotFkocs2(double spotFkocs2) {
		this.spotFkocs2 = spotFkocs2;
	}


	@Column(name="STATUS_YN")
	public String getStatusYn() {
		return this.statusYn;
	}

	public void setStatusYn(String statusYn) {
		this.statusYn = statusYn;
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


	@Column(name="XRAY_CODE")
	public String getXrayCode() {
		return this.xrayCode;
	}

	public void setXrayCode(String xrayCode) {
		this.xrayCode = xrayCode;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="XRAY_DATE")
	public Date getXrayDate() {
		return this.xrayDate;
	}

	public void setXrayDate(Date xrayDate) {
		this.xrayDate = xrayDate;
	}


	@Column(name="XRAY_GUBUN")
	public String getXrayGubun() {
		return this.xrayGubun;
	}

	public void setXrayGubun(String xrayGubun) {
		this.xrayGubun = xrayGubun;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="XRAY_RESER_DATE")
	public Date getXrayReserDate() {
		return this.xrayReserDate;
	}

	public void setXrayReserDate(Date xrayReserDate) {
		this.xrayReserDate = xrayReserDate;
	}


	@Column(name="XRAY_RESER_TIME")
	public String getXrayReserTime() {
		return this.xrayReserTime;
	}

	public void setXrayReserTime(String xrayReserTime) {
		this.xrayReserTime = xrayReserTime;
	}


	@Column(name="XRAY_ROOM")
	public String getXrayRoom() {
		return this.xrayRoom;
	}

	public void setXrayRoom(String xrayRoom) {
		this.xrayRoom = xrayRoom;
	}


	@Column(name="XRAY_TIME")
	public String getXrayTime() {
		return this.xrayTime;
	}

	public void setXrayTime(String xrayTime) {
		this.xrayTime = xrayTime;
	}


	@Column(name="XRAY_USER")
	public String getXrayUser() {
		return this.xrayUser;
	}

	public void setXrayUser(String xrayUser) {
		this.xrayUser = xrayUser;
	}


	@Column(name="XRT_COMMENTS")
	public String getXrtComments() {
		return this.xrtComments;
	}

	public void setXrtComments(String xrtComments) {
		this.xrtComments = xrtComments;
	}

}