package nta.med.core.domain.nut;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the NUT1001 database table.
 * 
 */
@Entity
@NamedQuery(name="Nut1001.findAll", query="SELECT n FROM Nut1001 n")
public class Nut1001 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String bunho;
	private String dcYn;
	private String doctor;
	private double fkocs1003;
	private double fkocs2003;
	private String gwa;
	private String hangmogCode;
	private String hoCode;
	private String hoDong;
	private String hospCode;
	private String inOutGubun;
	private Date jubsuDate;
	private String jubsuTime;
	private String jubsuYn;
	private String jundalPart;
	private String nutConsultor;
	private String nutRoom;
	private Date orderDate;
	private double pknut1001;
	private Date reserDate1;
	private Date reserDate2;
	private String reserTime1;
	private String reserTime2;
	private String resident;
	private Date sangdamDate;
	private Date sunabDate;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Nut1001() {
	}


	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
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


	@Column(name="HANGMOG_CODE")
	public String getHangmogCode() {
		return this.hangmogCode;
	}

	public void setHangmogCode(String hangmogCode) {
		this.hangmogCode = hangmogCode;
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


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="JUBSU_DATE")
	public Date getJubsuDate() {
		return this.jubsuDate;
	}

	public void setJubsuDate(Date jubsuDate) {
		this.jubsuDate = jubsuDate;
	}


	@Column(name="JUBSU_TIME")
	public String getJubsuTime() {
		return this.jubsuTime;
	}

	public void setJubsuTime(String jubsuTime) {
		this.jubsuTime = jubsuTime;
	}


	@Column(name="JUBSU_YN")
	public String getJubsuYn() {
		return this.jubsuYn;
	}

	public void setJubsuYn(String jubsuYn) {
		this.jubsuYn = jubsuYn;
	}


	@Column(name="JUNDAL_PART")
	public String getJundalPart() {
		return this.jundalPart;
	}

	public void setJundalPart(String jundalPart) {
		this.jundalPart = jundalPart;
	}


	@Column(name="NUT_CONSULTOR")
	public String getNutConsultor() {
		return this.nutConsultor;
	}

	public void setNutConsultor(String nutConsultor) {
		this.nutConsultor = nutConsultor;
	}


	@Column(name="NUT_ROOM")
	public String getNutRoom() {
		return this.nutRoom;
	}

	public void setNutRoom(String nutRoom) {
		this.nutRoom = nutRoom;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="ORDER_DATE")
	public Date getOrderDate() {
		return this.orderDate;
	}

	public void setOrderDate(Date orderDate) {
		this.orderDate = orderDate;
	}


	public double getPknut1001() {
		return this.pknut1001;
	}

	public void setPknut1001(double pknut1001) {
		this.pknut1001 = pknut1001;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="RESER_DATE_1")
	public Date getReserDate1() {
		return this.reserDate1;
	}

	public void setReserDate1(Date reserDate1) {
		this.reserDate1 = reserDate1;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="RESER_DATE_2")
	public Date getReserDate2() {
		return this.reserDate2;
	}

	public void setReserDate2(Date reserDate2) {
		this.reserDate2 = reserDate2;
	}


	@Column(name="RESER_TIME_1")
	public String getReserTime1() {
		return this.reserTime1;
	}

	public void setReserTime1(String reserTime1) {
		this.reserTime1 = reserTime1;
	}


	@Column(name="RESER_TIME_2")
	public String getReserTime2() {
		return this.reserTime2;
	}

	public void setReserTime2(String reserTime2) {
		this.reserTime2 = reserTime2;
	}


	public String getResident() {
		return this.resident;
	}

	public void setResident(String resident) {
		this.resident = resident;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="SANGDAM_DATE")
	public Date getSangdamDate() {
		return this.sangdamDate;
	}

	public void setSangdamDate(Date sangdamDate) {
		this.sangdamDate = sangdamDate;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="SUNAB_DATE")
	public Date getSunabDate() {
		return this.sunabDate;
	}

	public void setSunabDate(Date sunabDate) {
		this.sunabDate = sunabDate;
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