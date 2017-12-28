package nta.med.core.domain.ocs;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;

/**
 * The persistent class for the OCS2005 database table.
 * 
 */
@Entity
@Table(name = "OCS2005")
public class Ocs2005 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String addsik;
	private String bldGubun;
	private String bunho;
	private String busikYudong;
	private String continueYn;
	private String directCode;
	private String directCodeD;
	private String directCont1;
	private String directCont1D;
	private String directCont2;
	private String directCont2D;
	private String directCont3;
	private String directCont3D;
	private String directGubun;
	private String directText;
	private Date drtFromDate;
	private String drtFromTime;
	private Date drtToDate;
	private String drtToTime;
	private Double fkinp1001;
	private Double fkocs6005;
	private Double fkocs6015;
	private String hospCode;
	private String inputDoctor;
	private String inputGubun;
	private String inputGwa;
	private String inputId;
	private String joriType;
	private String jusikYudong;
	private String kumjisik;
	private String kumjisikGita;
	private String nomimono;
	private String nonghuYudong;
	private Date orderDate;
	private Double pkSeq;
	private Double pkocs2005;
	private Double saltValue;
	private String sikStartGubun;
	private String supsik;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Ocs2005() {
	}

	public String getAddsik() {
		return this.addsik;
	}

	public void setAddsik(String addsik) {
		this.addsik = addsik;
	}

	@Column(name = "BLD_GUBUN")
	public String getBldGubun() {
		return this.bldGubun;
	}

	public void setBldGubun(String bldGubun) {
		this.bldGubun = bldGubun;
	}

	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}

	@Column(name = "BUSIK_YUDONG")
	public String getBusikYudong() {
		return this.busikYudong;
	}

	public void setBusikYudong(String busikYudong) {
		this.busikYudong = busikYudong;
	}

	@Column(name = "CONTINUE_YN")
	public String getContinueYn() {
		return this.continueYn;
	}

	public void setContinueYn(String continueYn) {
		this.continueYn = continueYn;
	}

	@Column(name = "DIRECT_CODE")
	public String getDirectCode() {
		return this.directCode;
	}

	public void setDirectCode(String directCode) {
		this.directCode = directCode;
	}

	@Column(name = "DIRECT_CODE_D")
	public String getDirectCodeD() {
		return this.directCodeD;
	}

	public void setDirectCodeD(String directCodeD) {
		this.directCodeD = directCodeD;
	}

	@Column(name = "DIRECT_CONT1")
	public String getDirectCont1() {
		return this.directCont1;
	}

	public void setDirectCont1(String directCont1) {
		this.directCont1 = directCont1;
	}

	@Column(name = "DIRECT_CONT1_D")
	public String getDirectCont1D() {
		return this.directCont1D;
	}

	public void setDirectCont1D(String directCont1D) {
		this.directCont1D = directCont1D;
	}

	@Column(name = "DIRECT_CONT2")
	public String getDirectCont2() {
		return this.directCont2;
	}

	public void setDirectCont2(String directCont2) {
		this.directCont2 = directCont2;
	}

	@Column(name = "DIRECT_CONT2_D")
	public String getDirectCont2D() {
		return this.directCont2D;
	}

	public void setDirectCont2D(String directCont2D) {
		this.directCont2D = directCont2D;
	}

	@Column(name = "DIRECT_CONT3")
	public String getDirectCont3() {
		return this.directCont3;
	}

	public void setDirectCont3(String directCont3) {
		this.directCont3 = directCont3;
	}

	@Column(name = "DIRECT_CONT3_D")
	public String getDirectCont3D() {
		return this.directCont3D;
	}

	public void setDirectCont3D(String directCont3D) {
		this.directCont3D = directCont3D;
	}

	@Column(name = "DIRECT_GUBUN")
	public String getDirectGubun() {
		return this.directGubun;
	}

	public void setDirectGubun(String directGubun) {
		this.directGubun = directGubun;
	}

	@Column(name = "DIRECT_TEXT")
	public String getDirectText() {
		return this.directText;
	}

	public void setDirectText(String directText) {
		this.directText = directText;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "DRT_FROM_DATE")
	public Date getDrtFromDate() {
		return this.drtFromDate;
	}

	public void setDrtFromDate(Date drtFromDate) {
		this.drtFromDate = drtFromDate;
	}

	@Column(name = "DRT_FROM_TIME")
	public String getDrtFromTime() {
		return this.drtFromTime;
	}

	public void setDrtFromTime(String drtFromTime) {
		this.drtFromTime = drtFromTime;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "DRT_TO_DATE")
	public Date getDrtToDate() {
		return this.drtToDate;
	}

	public void setDrtToDate(Date drtToDate) {
		this.drtToDate = drtToDate;
	}

	@Column(name = "DRT_TO_TIME")
	public String getDrtToTime() {
		return this.drtToTime;
	}

	public void setDrtToTime(String drtToTime) {
		this.drtToTime = drtToTime;
	}

	public Double getFkinp1001() {
		return this.fkinp1001;
	}

	public void setFkinp1001(Double fkinp1001) {
		this.fkinp1001 = fkinp1001;
	}

	public Double getFkocs6005() {
		return this.fkocs6005;
	}

	public void setFkocs6005(Double fkocs6005) {
		this.fkocs6005 = fkocs6005;
	}

	public Double getFkocs6015() {
		return this.fkocs6015;
	}

	public void setFkocs6015(Double fkocs6015) {
		this.fkocs6015 = fkocs6015;
	}

	@Column(name = "HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}

	@Column(name = "INPUT_DOCTOR")
	public String getInputDoctor() {
		return this.inputDoctor;
	}

	public void setInputDoctor(String inputDoctor) {
		this.inputDoctor = inputDoctor;
	}

	@Column(name = "INPUT_GUBUN")
	public String getInputGubun() {
		return this.inputGubun;
	}

	public void setInputGubun(String inputGubun) {
		this.inputGubun = inputGubun;
	}

	@Column(name = "INPUT_GWA")
	public String getInputGwa() {
		return this.inputGwa;
	}

	public void setInputGwa(String inputGwa) {
		this.inputGwa = inputGwa;
	}

	@Column(name = "INPUT_ID")
	public String getInputId() {
		return this.inputId;
	}

	public void setInputId(String inputId) {
		this.inputId = inputId;
	}

	@Column(name = "JORI_TYPE")
	public String getJoriType() {
		return this.joriType;
	}

	public void setJoriType(String joriType) {
		this.joriType = joriType;
	}

	@Column(name = "JUSIK_YUDONG")
	public String getJusikYudong() {
		return this.jusikYudong;
	}

	public void setJusikYudong(String jusikYudong) {
		this.jusikYudong = jusikYudong;
	}

	public String getKumjisik() {
		return this.kumjisik;
	}

	public void setKumjisik(String kumjisik) {
		this.kumjisik = kumjisik;
	}

	@Column(name = "KUMJISIK_GITA")
	public String getKumjisikGita() {
		return this.kumjisikGita;
	}

	public void setKumjisikGita(String kumjisikGita) {
		this.kumjisikGita = kumjisikGita;
	}

	public String getNomimono() {
		return this.nomimono;
	}

	public void setNomimono(String nomimono) {
		this.nomimono = nomimono;
	}

	@Column(name = "NONGHU_YUDONG")
	public String getNonghuYudong() {
		return this.nonghuYudong;
	}

	public void setNonghuYudong(String nonghuYudong) {
		this.nonghuYudong = nonghuYudong;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "ORDER_DATE")
	public Date getOrderDate() {
		return this.orderDate;
	}

	public void setOrderDate(Date orderDate) {
		this.orderDate = orderDate;
	}

	@Column(name = "PK_SEQ")
	public Double getPkSeq() {
		return this.pkSeq;
	}

	public void setPkSeq(Double pkSeq) {
		this.pkSeq = pkSeq;
	}

	public Double getPkocs2005() {
		return this.pkocs2005;
	}

	public void setPkocs2005(Double pkocs2005) {
		this.pkocs2005 = pkocs2005;
	}

	@Column(name = "SALT_VALUE")
	public Double getSaltValue() {
		return this.saltValue;
	}

	public void setSaltValue(Double saltValue) {
		this.saltValue = saltValue;
	}

	@Column(name = "SIK_START_GUBUN")
	public String getSikStartGubun() {
		return this.sikStartGubun;
	}

	public void setSikStartGubun(String sikStartGubun) {
		this.sikStartGubun = sikStartGubun;
	}

	public String getSupsik() {
		return this.supsik;
	}

	public void setSupsik(String supsik) {
		this.supsik = supsik;
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

}