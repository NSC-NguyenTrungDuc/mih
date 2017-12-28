package nta.med.core.domain.nmr;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the NMR0201 database table.
 * 
 */
@Entity
@NamedQuery(name="Nmr0201.findAll", query="SELECT n FROM Nmr0201 n")
public class Nmr0201 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String actDoctor;
	private String buhaGubun;
	private String bunho;
	private String dangilGumsaOrderYn;
	private String dangilGumsaResultYn;
	private String dcYn;
	private String doctor;
	private String emergency;
	private double fkocs1003;
	private double fkocs2003;
	private String gwa;
	private String hoCode;
	private String hoDong;
	private String hospCode;
	private String inOutGubun;
	private String inputPart;
	private Date jubsuDate;
	private String jubsuFlag;
	private String jubsuTime;
	private String muhyo;
	private Date orderDate;
	private Date pandokDate;
	private String pandokDoctor;
	private double pandokSerial;
	private String pandokTime;
	private double pknmr0201;
	private String resident;
	private String slipCode;
	private Date sunabDate;
	private double sunabSuryang;
	private double suryang;
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

	public Nmr0201() {
	}


	@Column(name="ACT_DOCTOR")
	public String getActDoctor() {
		return this.actDoctor;
	}

	public void setActDoctor(String actDoctor) {
		this.actDoctor = actDoctor;
	}


	@Column(name="BUHA_GUBUN")
	public String getBuhaGubun() {
		return this.buhaGubun;
	}

	public void setBuhaGubun(String buhaGubun) {
		this.buhaGubun = buhaGubun;
	}


	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
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


	@Column(name="IN_OUT_GUBUN")
	public String getInOutGubun() {
		return this.inOutGubun;
	}

	public void setInOutGubun(String inOutGubun) {
		this.inOutGubun = inOutGubun;
	}


	@Column(name="INPUT_PART")
	public String getInputPart() {
		return this.inputPart;
	}

	public void setInputPart(String inputPart) {
		this.inputPart = inputPart;
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


	@Column(name="JUBSU_TIME")
	public String getJubsuTime() {
		return this.jubsuTime;
	}

	public void setJubsuTime(String jubsuTime) {
		this.jubsuTime = jubsuTime;
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


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="PANDOK_DATE")
	public Date getPandokDate() {
		return this.pandokDate;
	}

	public void setPandokDate(Date pandokDate) {
		this.pandokDate = pandokDate;
	}


	@Column(name="PANDOK_DOCTOR")
	public String getPandokDoctor() {
		return this.pandokDoctor;
	}

	public void setPandokDoctor(String pandokDoctor) {
		this.pandokDoctor = pandokDoctor;
	}


	@Column(name="PANDOK_SERIAL")
	public double getPandokSerial() {
		return this.pandokSerial;
	}

	public void setPandokSerial(double pandokSerial) {
		this.pandokSerial = pandokSerial;
	}


	@Column(name="PANDOK_TIME")
	public String getPandokTime() {
		return this.pandokTime;
	}

	public void setPandokTime(String pandokTime) {
		this.pandokTime = pandokTime;
	}


	public double getPknmr0201() {
		return this.pknmr0201;
	}

	public void setPknmr0201(double pknmr0201) {
		this.pknmr0201 = pknmr0201;
	}


	public String getResident() {
		return this.resident;
	}

	public void setResident(String resident) {
		this.resident = resident;
	}


	@Column(name="SLIP_CODE")
	public String getSlipCode() {
		return this.slipCode;
	}

	public void setSlipCode(String slipCode) {
		this.slipCode = slipCode;
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