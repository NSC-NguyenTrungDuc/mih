package nta.med.core.domain.cpl;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the CPL0613 database table.
 * 
 */
@Entity
@NamedQuery(name="Cpl0613.findAll", query="SELECT c FROM Cpl0613 c")
@Table(name="CPL0613")
public class Cpl0613 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private Date actingDate;
	private Date bannabDate;
	private double bannabQty;
	private double bannabSuryang;
	private String bannabTime;
	private String bannabYn;
	private String bannabja;
	private String bunho;
	private double chulgoQty;
	private String clossMatching;
	private String comments;
	private String dcYn;
	private String doctor;
	private String dpYn;
	private String endYn;
	private double fkinp1001;
	private double fkocs;
	private String fkout1001;
	private double gumsaQty;
	private String gwa;
	private String hangmogCode;
	private String hoCode;
	private String hoDong;
	private String hospCode;
	private String inOutGubun;
	private double nalsu;
	private Date orderDate;
	private String orderTime;
	private String pay;
	private String prnYn;
	private Date reserDate;
	private String slipCode;
	private double sourceFkocs;
	private String specimenSer;
	private Date sunabDate;
	private double sunabNalsu;
	private String sunabTime;
	private double suryang;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Cpl0613() {
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="ACTING_DATE")
	public Date getActingDate() {
		return this.actingDate;
	}

	public void setActingDate(Date actingDate) {
		this.actingDate = actingDate;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="BANNAB_DATE")
	public Date getBannabDate() {
		return this.bannabDate;
	}

	public void setBannabDate(Date bannabDate) {
		this.bannabDate = bannabDate;
	}


	@Column(name="BANNAB_QTY")
	public double getBannabQty() {
		return this.bannabQty;
	}

	public void setBannabQty(double bannabQty) {
		this.bannabQty = bannabQty;
	}


	@Column(name="BANNAB_SURYANG")
	public double getBannabSuryang() {
		return this.bannabSuryang;
	}

	public void setBannabSuryang(double bannabSuryang) {
		this.bannabSuryang = bannabSuryang;
	}


	@Column(name="BANNAB_TIME")
	public String getBannabTime() {
		return this.bannabTime;
	}

	public void setBannabTime(String bannabTime) {
		this.bannabTime = bannabTime;
	}


	@Column(name="BANNAB_YN")
	public String getBannabYn() {
		return this.bannabYn;
	}

	public void setBannabYn(String bannabYn) {
		this.bannabYn = bannabYn;
	}


	public String getBannabja() {
		return this.bannabja;
	}

	public void setBannabja(String bannabja) {
		this.bannabja = bannabja;
	}


	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}


	@Column(name="CHULGO_QTY")
	public double getChulgoQty() {
		return this.chulgoQty;
	}

	public void setChulgoQty(double chulgoQty) {
		this.chulgoQty = chulgoQty;
	}


	@Column(name="CLOSS_MATCHING")
	public String getClossMatching() {
		return this.clossMatching;
	}

	public void setClossMatching(String clossMatching) {
		this.clossMatching = clossMatching;
	}


	public String getComments() {
		return this.comments;
	}

	public void setComments(String comments) {
		this.comments = comments;
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


	@Column(name="DP_YN")
	public String getDpYn() {
		return this.dpYn;
	}

	public void setDpYn(String dpYn) {
		this.dpYn = dpYn;
	}


	@Column(name="END_YN")
	public String getEndYn() {
		return this.endYn;
	}

	public void setEndYn(String endYn) {
		this.endYn = endYn;
	}


	public double getFkinp1001() {
		return this.fkinp1001;
	}

	public void setFkinp1001(double fkinp1001) {
		this.fkinp1001 = fkinp1001;
	}


	public double getFkocs() {
		return this.fkocs;
	}

	public void setFkocs(double fkocs) {
		this.fkocs = fkocs;
	}


	public String getFkout1001() {
		return this.fkout1001;
	}

	public void setFkout1001(String fkout1001) {
		this.fkout1001 = fkout1001;
	}


	@Column(name="GUMSA_QTY")
	public double getGumsaQty() {
		return this.gumsaQty;
	}

	public void setGumsaQty(double gumsaQty) {
		this.gumsaQty = gumsaQty;
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


	public double getNalsu() {
		return this.nalsu;
	}

	public void setNalsu(double nalsu) {
		this.nalsu = nalsu;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="ORDER_DATE")
	public Date getOrderDate() {
		return this.orderDate;
	}

	public void setOrderDate(Date orderDate) {
		this.orderDate = orderDate;
	}


	@Column(name="ORDER_TIME")
	public String getOrderTime() {
		return this.orderTime;
	}

	public void setOrderTime(String orderTime) {
		this.orderTime = orderTime;
	}


	public String getPay() {
		return this.pay;
	}

	public void setPay(String pay) {
		this.pay = pay;
	}


	@Column(name="PRN_YN")
	public String getPrnYn() {
		return this.prnYn;
	}

	public void setPrnYn(String prnYn) {
		this.prnYn = prnYn;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="RESER_DATE")
	public Date getReserDate() {
		return this.reserDate;
	}

	public void setReserDate(Date reserDate) {
		this.reserDate = reserDate;
	}


	@Column(name="SLIP_CODE")
	public String getSlipCode() {
		return this.slipCode;
	}

	public void setSlipCode(String slipCode) {
		this.slipCode = slipCode;
	}


	@Column(name="SOURCE_FKOCS")
	public double getSourceFkocs() {
		return this.sourceFkocs;
	}

	public void setSourceFkocs(double sourceFkocs) {
		this.sourceFkocs = sourceFkocs;
	}


	@Column(name="SPECIMEN_SER")
	public String getSpecimenSer() {
		return this.specimenSer;
	}

	public void setSpecimenSer(String specimenSer) {
		this.specimenSer = specimenSer;
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
	public double getSunabNalsu() {
		return this.sunabNalsu;
	}

	public void setSunabNalsu(double sunabNalsu) {
		this.sunabNalsu = sunabNalsu;
	}


	@Column(name="SUNAB_TIME")
	public String getSunabTime() {
		return this.sunabTime;
	}

	public void setSunabTime(String sunabTime) {
		this.sunabTime = sunabTime;
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

}